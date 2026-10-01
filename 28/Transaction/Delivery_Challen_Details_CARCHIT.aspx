<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Delivery_Challen_Details_CARCHIT.aspx.cs"
    Inherits="Delivery_Challen_CARCHIT" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export - GSP</title>
    <style type="text/css">
        .border_style
        {
            border: 1px;
            border-style: solid;
        }
        .top_border_style
        {
            border: 1px;
            border-left-style: solid;
            border-right-style: solid;
            border-bottom-style: solid;
        }
        .bottom_border_style
        {
            border: 1px;
            border-left-style: solid;
            border-right-style: solid;
            border-top-style: solid;
        }
        .left_border_style
        {
            border: 1px;
            border-top-style: solid;
            border-right-style: solid;
            border-bottom-style: solid;
        }
        .right_border_style
        {
            border: 1px;
            border-left-style: solid;
            border-top-style: solid;
            border-bottom-style: solid;
        }
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Import - Delivery Challan (Carchit)
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1000px">
                    <div id="tag_Exchange_inner_lft">
                        <div id="tag_transact_lft_in1">
                            <div id="tag_transac_exp_drawback" style="width: 700px; margin-top: 10px;">
                                <div id="tag_label_transact_Src">
                                    Job No
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="100px">
                                    </asp:DropDownList>
                                </div>
                                <%--<div id="tag_label_transact_Src">
                                    Img Upload
                                </div>
                                <div id="txtcon-m_src">
                                    <asp:FileUpload ID="FileUpload1" runat="server" onchange="document.getElementById('btn_upload').click();" />
                                    <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" Style="display: none;" />
                                </div>--%>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transact_srcinner_rght" style="margin-right: 90px; margin-top: 25px;
                        width: 320px;">
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" ValidationGroup="bond" CssClass="save" OnClick="btnSave_Click"
                                TabIndex="4" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" ValidationGroup="bond" CssClass="updates"
                                TabIndex="4" OnClick="btnUpdate_Click" Visible="false" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'DELIVERY_CHALLAN', function(r) {
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
                        <div id="editbu">
                            <%--<a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" onclick="page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                        </a>--%>
                            <asp:Button ID="btn_Report" CssClass="generate" runat="server" OnClientClick="open_jobno(); return false;"
                                Visible="false" />
                        </div>
                        <%-- <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                    </div>--%>
                        <%-- <div id="editbu">
                         <asp:Button ID="btn_print" runat="server" Text="print" 
         onclick="btn_print_Click" />
                    </div>--%>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new" style="background-image: none; height: auto;">
                <div class="content" id="page-1" style="overflow: scroll; height: 485px">
                    <div align="center" id="s" runat="server">
                        <table cellpadding="0" cellspacing="0" width="900px">
                            <tr valign="TOP">
                                <td>
                                    <table width="900px">
                                        <tr valign="TOP" height="35px">
                                            <td colspan="14" align="center">
                                                <font face="Times New Roman" size="2"><b>DESPATCH FROM HOM'X WAREHOUSE GODOWN (Carchit
                                                    -Cum- Delivery Challan)</b></font>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td align="center" colspan="14">
                                                <asp:Image ID="Image1" runat="server" Width="150px" Height="50px" ImageUrl="" onmouseover="Big(this);"
                                                    onmouseout="Small(this);" />
                                                </FONT>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td colspan="1" align="left">
                                                <asp:Label ID="lbl_CHA_Name" runat="server" Text="Name & Address of the Clearing Agent  "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_CHA_Name" runat="server" BorderStyle="None" size="55" 
                                                        Style="text-align: center"></asp:TextBox>
                                                </b></font>
                                            </td>
                                            <td style="width: 250px;">
                                                <asp:Label ID="lbl_refNo" runat="server" Text="Ref.No  "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_RefNo" runat="server" BorderStyle="None" size="25" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                            </td>
                                        </tr>
                                        <tr valign="TOP">
                                            <td colspan="1" align="left">
                                                <asp:Label ID="lbl_License_No" runat="server" Text="Customs License No. "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_License_No" runat="server" BorderStyle="None" size="15" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font><font face="Times New Roman" size="2"><b>
                                                  
                                                    <asp:TextBox ID="txt_Cha_Address" runat="server"  Style="text-align: center" BorderStyle="None"
                                                        Height="35px" Width="350px" TextMode="MultiLine"></asp:TextBox>
                                                </b></font>
                                            </td>
                                            <td style="width: 250px;">
                                                <asp:Label ID="lbl_Phone" runat="server" Text="Phone  "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_Phone" runat="server" BorderStyle="None" size="25" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                                <asp:Label ID="lbl_Telex" runat="server" Text="Telex  "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_Telex" runat="server" BorderStyle="None" size="25" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                            </td>
                                        </tr>
                                        <tr valign="TOP" style="height: 15px; width: 1000px;">
                                            <td colspan="1" align="left">
                                                <asp:Label ID="lbl_BE_No" runat="server" Text="BE.No  "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_BE_No" runat="server" BorderStyle="None" size="15" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                                <%--<asp:Label ID="Label2" runat="server" Text="I/A No.  "></asp:Label>--%>
                                                     <asp:Label ID="Label2" runat="server" Text="Assbl"></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_IA_No" runat="server" BorderStyle="None" size="20" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                                <asp:Label ID="Label1" runat="server" Text="Waybill No/R.R. No "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_WaybillNo" runat="server" BorderStyle="None" size="20" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                            </td>
                                            <td style="width: 250px;">
                                                <asp:Label ID="Label3" runat="server" Text="Vehicle "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_Vehicle" runat="server" BorderStyle="None" size="25" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                            </td>
                                        </tr>
                                        <tr valign="TOP" style="height: 15px; width: 1000px;">
                                            <td colspan="1" align="left">
                                                <asp:Label ID="Label4" runat="server" Text="& Date  "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_BE_Date" runat="server" BorderStyle="None" size="15" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                                <%--<asp:Label ID="Label5" runat="server" Text="& Date  "></asp:Label>--%>
                                                <asp:Label ID="Label5" runat="server" Text="RITC  "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_IA_Date" runat="server" BorderStyle="None" size="20" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                                <asp:Label ID="Label6" runat="server" Text="& Date "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_Waybill_Date" runat="server" BorderStyle="None" size="20" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                            </td>
                                        </tr>
                                        <tr valign="TOP" style="height: 35px; margin-top: 10px; width: 1000px;">
                                            <td colspan="1" align="left">
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:Label ID="Label7" runat="server" Text="Details of Cargo  " Width="150px"></asp:Label>
                                                </b></font>
                                                <asp:Label ID="Label8" runat="server" Text="Steamer  "></asp:Label>
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_Steamer" runat="server" BorderStyle="None" size="60" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                                <asp:Label ID="Label9" runat="server" Text="Inv. No "></asp:Label>
                                            </td>
                                            <td style="width: 250px;">
                                                <font face="Times New Roman" size="2"><b>
                                                    <asp:TextBox ID="txt_InvoiceNo" runat="server" BorderStyle="None" size="35" Style="text-align: left;
                                                        border-bottom-style: dotted; border-color: Black;"></asp:TextBox>
                                                </b></font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="14" align="center">
                                                <font face="Times New Roman" size="2"><b>
                                                    <%--<asp:TextBox ID="txt_CHA_Name_sub" runat="server" BorderStyle="None" size="25" Text="Airlift (U.S.A),Inc."></asp:TextBox>--%>
                                                </b></font>
                                            </td>
                                        </tr>
                        </table>
                        </td> </tr>
                        <tr>
                            <td>
                                <table width="400px">
                                    <tr valign="TOP">
                                        <td colspan="4">
                                            <font face="Times New Roman" size="2">Quantity </font>
                                        </td>
                                        <td colspan="1">
                                            <font face="Times New Roman" size="2">Description</font>
                                        </td>
                                        <td colspan="2">
                                            <font face="Times New Roman" size="2">Marks & Nos</font>
                                        </td>
                                        <td colspan="1">
                                            <font face="Times New Roman" size="2">Pkg.Nos opened for Customs Survey</font>
                                        </td>
                                        <td colspan="1">
                                            <font face="Times New Roman" size="2">Condition of goods when despatched</font>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td class="right_border_style" colspan="4">
                                            <font face="Times New Roman" size="2">
                                                <asp:TextBox ID="txt_Quantity" runat="server" align="left" BorderStyle="None" Height="200px"
                                                    Width="120px" TextMode="MultiLine"></asp:TextBox>
                                            </font>
                                        </td>
                                        <td class="right_border_style">
                                            <font face="Times New Roman" size="2">
                                                <asp:TextBox ID="txt_Description" runat="server" align="left" BorderStyle="None"
                                                    Height="200px" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                            </font>
                                        </td>
                                        <td class="border_style" colspan="2">
                                            <font face="Times New Roman" size="2">
                                                <asp:TextBox ID="txt_MawbNo" runat="server" align="left" BorderStyle="None"
                                                    Height="200px" Width="230px" TextMode="MultiLine"></asp:TextBox>
                                            </font>
                                        </td>
                                        <td class="right_border_style">
                                            <font face="Times New Roman" size="2">
                                                <asp:TextBox ID="txt_PKG" runat="server" align="left" BorderStyle="None" Height="200px"
                                                    Width="100px" TextMode="MultiLine"></asp:TextBox>
                                            </font>
                                        </td>
                                        <td class="border_style" colspan="2">
                                            <font face="Times New Roman" size="2">
                                                <asp:TextBox ID="txt_GoodsCondition" runat="server" align="left" BorderStyle="None" Height="200px"
                                                    Width="100px" TextMode="MultiLine"></asp:TextBox>
                                            </font>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="11">
                                            <asp:Label ID="Label10" runat="server" Text="Name & Local Address of Transporter "></asp:Label>
                                            <asp:TextBox ID="txt_transporterName" runat="server" align="left" BorderStyle="None"
                                                Style="text-align: left; border-bottom-style: dotted; border-color: Black;" Width="600px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="11">
                                            <asp:Label ID="Label11" runat="server" Text="Name of driver and his Signature "></asp:Label>
                                            <asp:TextBox ID="txt_DriverName" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="640px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="11">
                                            <asp:Label ID="Label12" runat="server" Text="From Place of Despatch "></asp:Label>
                                            <asp:TextBox ID="txt_Place_of_Despatch" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="690px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="11">
                                            <asp:Label ID="Label13" runat="server" Text="Address of the Godown where goods are delivered "></asp:Label>
                                            <asp:TextBox ID="txt_Godown_Address" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="530px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="11">
                                            <asp:Label ID="Label14" runat="server" Text="Name & Address of the person to who delivered "></asp:Label>
                                            <asp:TextBox ID="txt_delivered_PersonName" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="550px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="4" align="center">
                                            <asp:Label ID="Label15" runat="server" Text="Signature  "></asp:Label>
                                        </td>
                                        <td colspan="1">
                                            <asp:Label ID="Label16" runat="server" Text="-do-        "></asp:Label>
                                        </td>
                                        <td colspan="6" align="left">
                                            <asp:TextBox ID="txt_delivered_Address1" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="550px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="4" align="left">
                                            <asp:Label ID="Label17" runat="server" Text="BE/I.A Quantity "></asp:Label>
                                        </td>
                                        <td colspan="1">
                                            <asp:TextBox ID="txt_BE_IA_Qty" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="150px"></asp:TextBox>
                                        </td>
                                        <td colspan="6" align="left">
                                            <asp:TextBox ID="txt_delivered_Address2" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="550px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="4" align="left">
                                            <asp:Label ID="Label18" runat="server" Text="Cleared till Date "></asp:Label>
                                        </td>
                                        <td colspan="1">
                                            <asp:TextBox ID="txt_Cleared_tilldate" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="150px"></asp:TextBox>
                                        </td>
                                        <td colspan="6" align="left">
                                            <asp:TextBox ID="txt_delivered_Address3" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="550px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="4" align="left">
                                            <asp:Label ID="Label19" runat="server" Text="Balance "></asp:Label>
                                        </td>
                                        <td colspan="1">
                                            <asp:TextBox ID="txt_balance" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="150px"></asp:TextBox>
                                        </td>
                                        <td colspan="6" align="left">
                                            <%--<asp:TextBox ID="TextBox17" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="550px"></asp:TextBox>--%>
                                                <asp:Label ID="Label22" runat="server" Text="Signature of the person(who delivered the goods) "></asp:Label>
                                        </td>
                                    </tr>
                                    <tr valign="TOP" style="height:20px;"> 
                                    <td></td></tr>
                                    <tr valign="TOP">
                                        <td colspan="4" align="left">
                                            <asp:Label ID="Label20" runat="server" Text=" "></asp:Label>
                                        </td>
                                        <td colspan="1">
                                            <asp:Label ID="Label21" runat="server" Text="Customs Check "></asp:Label>
                                        </td>
                                        <td colspan="6" align="center">
                                            <%--<asp:Label ID="Label22" runat="server" Text="Signature of the person(who delivered the goods) "></asp:Label>--%>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="4" align="left">
                                            <asp:Label ID="Label23" runat="server" Text=" "></asp:Label>
                                        </td>
                                        <td colspan="1">
                                            <asp:Label ID="Label24" runat="server" Text="Godown Check "></asp:Label>
                                        </td>
                                        <td colspan="6" align="center">
                                            <asp:TextBox ID="txt_Signature" runat="server" align="left" BorderStyle="None"  Width="550px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="TOP">
                                        <td colspan="4" align="left">
                                            <asp:Label ID="Label26" runat="server" Text=" "></asp:Label>
                                        </td>
                                        <td colspan="1">
                                            <asp:Label ID="Label27" runat="server" Text="Godown Superintendent "></asp:Label>
                                        </td>
                                        <td colspan="6" align="center">
                                            <asp:Label ID="Label28" runat="server" Text="Date : "></asp:Label>
                                            <asp:TextBox ID="txt_Date" runat="server" align="left" BorderStyle="None" Style="text-align: left;
                                                border-bottom-style: dotted; border-color: Black;" Width="150px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr valign="TOP" style="height:60px;"> 
                                    <td></td></tr>
                                </table>
                            </td>
                        </tr>
                        <%--<tr>
                            <td>
                                <table width="910px">
                                    <tr valign="TOP" style="height: 120px">
                                        <td  style="width: 400px;" valign="top">
                                            <font face="Times New Roman" size="2">Customs Check</font>
                                            <font face="Times New Roman" size="2">Godown  Check</font>                                        
                                            </td>
                                        <td class="left_border_style" style="width: 400px" align="right" valign="top">
                                            <font face="Times New Roman" size="2">For
                                                <asp:TextBox ID="txt_CHA_Name_sub1" runat="server" align="left" BorderStyle="None"
                                                    Width="280px"></asp:TextBox>
                                            </font>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                        </table>
                        <table>
                        </table>
                    </div>
                </div>
            </div>

            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="hdn_Jobno_PS" runat="server" />
            <asp:HiddenField ID="hdn_filename" runat="server" />
            <script src="../js/listpopup.js" type="text/javascript"></script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script language="javascript" type="text/javascript">
        function Big(me) {
            me.height *= N;
        }
        function Small(me) {
            me.height /= N;
        }
        function PrintGridData() {

            var prtGrid = document.getElementById('<%=s.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            //prtwin.close();
        }
        function open_jobno() {
            if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {
                document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;

                if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {
                    var jobno = document.getElementById("<%=HiddenField1.ClientID %>").value;
                    NewWindow1('../Report/Import_Delivery_Challan_Carchit_Rpt_viewer.aspx?jobno=' + jobno + '', 'List', '1010', '1024', 'yes');
                    return false

                }
            }

        }
    </script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
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
</body>
</html>
