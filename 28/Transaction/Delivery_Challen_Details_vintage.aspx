<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Delivery_Challen_Details_vintage.aspx.cs" Inherits="Transaction_Delivery_Challen_Details_vintage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export - GSP</title>
    <style type="text/css">
        .border_style
        {
            border:1px;border-style:solid;
        }
        .top_border_style
        {
            border:1px;
            border-left-style:solid;
            border-right-style:solid;
            border-bottom-style:solid;
        }
        .bottom_border_style
        {
            border:1px;
            border-left-style:solid;
            border-right-style:solid;
            border-top-style:solid;
        }
        .left_border_style
        {
            border:1px;
            border-top-style:solid;
            border-right-style:solid;
            border-bottom-style:solid;
        }
        .right_border_style
        {
            border:1px;
            border-left-style:solid;
            border-top-style:solid;
            border-bottom-style:solid;
        }
        .style1
        {
            width: 503px;
        }
        .style2
        {
            width: 503px;
            height: 59px;
        }
    </style>
  
   
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    
</head>
<body style="overflow:hidden;">
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
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Import - Delivery Challan
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
                                
                                 <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none"
        AutoPostBack="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged" Width="100px">
    
    </asp:DropDownList>
                            
                           
                            </div>
                           
                    
                            <div id="tag_label_transact_Src">
                                Img Upload
                            </div>
                           
                            <div id="txtcon-m_src">
                                
            
                             <asp:FileUpload ID="FileUpload1" runat="server" onchange="document.getElementById('btn_upload').click();"/>
                             <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" 
                             Style="display: none;" />
                            </div>
                            
                        </div>
                    </div>
                   
                </div>
                  
                <div id="tag_transact_srcinner_rght" style="margin-right:90px;margin-top: 25px;
    width: 320px;">
                 <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="bond" CssClass="save" OnClick="btnSave_Click"
                            TabIndex="4" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" ValidationGroup="bond" CssClass="updates"
                            TabIndex="4" OnClick="btnUpdate_Click" Visible="false"
                             />
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
                         <asp:Button ID="btn_Report" CssClass="generate" runat="server" 
                         OnClientClick="open_jobno(); return false;" Visible="false"/>
                              
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
                    <div id="innerbox_MidMain_Trans_new" style="background-image:none;height:auto;">
                     <div class="content" id="page-1" style="overflow:scroll;height:400px">
                      
               <div  align="center" id="s" runat="server" >


<table cellpadding="0" cellspacing="0" width="900px">


              <tr valign="TOP" >
          <td  >
          <table width="900px">
          <tr VALIGN="TOP">
            <td colspan="14" align="center">
               
                <font face="Times New Roman" size="2"><b>DELIVERY CHALLAN</b></font>
               
          
            </td>
        </tr>
          <tr>
           <td align="center" colspan="14">
                <asp:Image ID="Image1" runat="server" Width="150px" Height="50px" ImageUrl="" onmouseover="Big(this);" onmouseout="Small(this);"/>
                </FONT>
            </td>
         <%--<td ="right">
              <input type="checkbox"  id="Ch_ori" name="original" value="ORIGINAL" />
              <label>ORIGINAL</label><br />
                <input type="checkbox"  id="Ch_dup" name="duplicate" value="DUPLICATE" />
              <label>DUPLICATE</label><br />
               <input type="checkbox"  id="Ch_tri" name="triplicate" value="TRIPLICATE" />
              <label>TRIPLICATE</label><br />
            </td>--%>
      
          </tr>
             <tr VALIGN="TOP">
            <td colspan="14" align="center">
                <font face="Times New Roman" size="2"><b>
                    <asp:TextBox ID="txt_CHA_Name_sub" runat="server" BorderStyle="None"   size="25" 
                         style="text-align:center"></asp:TextBox>
                        <td colspan="14" align="center">
                         <asp:TextBox ID="txt_Cha_Address" runat="server" align="Center" BorderStyle="None" Height="35px" 
                  Width="50%" TextMode="MultiLine"></asp:TextBox>
                    </b></font>
                    </td>
            </td>
                 
       </tr>
    
          </table>
          </td>
         
     
          </tr>
       
      
          </table>
                   </td>
                   </tr>
                   </table>
                   </td>
                   </tr>
                   <tr valign="TOP">
                       <td align="left">
                           <table width="500px">
                               <tr valign="top">
                                   <td colspan="2" valign="top">
                                       <table width="400px">
                                           <tr>
                                               <td class="bottom_border_style" colspan="2" valign="top">
                                                   <font face="Times New Roman" size="2">
                                                   <div ID="tag_label_transact_Src" style=align:"left">
                                                       Transport mode
                                                   </div>
                                                   <asp:TextBox ID="txt_trans_mode" runat="server" align="left" BorderStyle="None" 
                                                       Height="35px"></asp:TextBox>
                                                   <asp:DropDownList ID="ddl_tran_mode" runat="server" AutoPostBack="true" 
                                                       CssClass="txtbox_none">
                                                       <asp:ListItem Value="air">Air</asp:ListItem>
                                                       <asp:ListItem Value="sea">Sea</asp:ListItem>
                                                       <asp:ListItem Value="Land">Land</asp:ListItem>
                                                   </asp:DropDownList>
                                                   </font>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td class="border_style">
                                                   <table width="450px">
                                                       <tr>
                                                           <td>
                                                               Date :
                                                               <asp:TextBox ID="txt_Todate_Date" runat="server" align="left" BorderStyle="None" 
                                                                   size="50"></asp:TextBox>
                                                           </td>
                                                     <%--  </tr>
                                                      
                                                           <tr>--%>
                                                               <td width="100px">
                                                                   <font face="Times New Roman" size="2">Ref No : </font>
                                                                   <asp:TextBox ID="txt_Imp_Refno" runat="server" align="right" BorderStyle="None" 
                                                                       size="100"></asp:TextBox>
                                                               </td>
                                                           </tr>
                                                    
                                                   </table>
                                               </td>
                                               <table width="450px">
                                                   <tr>
                                                       <td class="right_border_style">
                                                           <font face="Times New Roman" size="2">From, </font>
                                                            <asp:TextBox ID="txt_CHA_Name" runat="server" align="left" BorderStyle="None" 
                                                               size="72"></asp:TextBox>
                                                               <asp:TextBox ID="txt_Cha_Adress" runat="server" align="left" 
                                                               BorderStyle="None" Height="50px" TextMode="MultiLine" Width="450px" Wrap="true"></asp:TextBox>
                                                       </td>
                                                        <td class="left_border_style" width="450px">
                                                           <font face="Times New Roman" size="2">To, </font>  
                                                           <asp:TextBox ID="txtImporter" runat="server" align="right" 
                                                                BorderStyle="None" size="72"></asp:TextBox>
                                                               <asp:TextBox ID="txt_Importer_Address" runat="server" align="right" 
                                                                    Height="55px" TextMode="MultiLine" Width="461px" 
                                                                 BorderStyle="None"   Wrap="true"></asp:TextBox>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                       <%--<td>
                                                           <asp:TextBox ID="txt_CHA_Name" runat="server" align="left" BorderStyle="None" 
                                                               size="72"></asp:TextBox>

                                                       </td>--%>
                                                     <%--  <td>
                                                           <asp:TextBox ID="txtImporter" runat="server" align="right" 
                                                               BorderStyle="None" size="72"></asp:TextBox>
                                                       </td>--%>
                                               </tr>
                                                   <tr>
                                                       <td>
                                                           <%--<asp:TextBox ID="txt_Cha_Adress" runat="server" align="left" 
                                                               BorderStyle="None" Height="50px" TextMode="MultiLine" Width="450px" Wrap="true"></asp:TextBox>--%>
                                                              <%--   <asp:TextBox ID="txt_Importer" runat="server" align="right" 
                                                               BorderStyle="None" size="72"></asp:TextBox>--%>
                                                       </td>
                                               <%--        <td class="style1">
                                                               <asp:TextBox ID="txtImporter" runat="server" align="right" 
                                                                   BorderStyle="None" Height="55px" TextMode="MultiLine" Width="461px" 
                                                                   Wrap="true"></asp:TextBox>
                                                           </td>--%>
                                                           <%-- <td>
                                                               <asp:TextBox ID="txt_Importer_Address" runat="server" align="right" 
                                                                   BorderStyle="None" Height="55px" TextMode="MultiLine" Width="461px" 
                                                                   Wrap="true"></asp:TextBox>
                                                           </td>--%>
                                                   </tr>
                                                    <%--  <tr>--%>
                                                       <%--<td width="500px">
                                                           <font face="Times New Roman" size="2">To, </font>  
                                                       </td>--%>
                                                 <%-- </tr>
                                                   <tr>--%>
                                                <%--   <tr>
                                                       <td class="style1">
                                                           <asp:TextBox ID="txtImporter" runat="server" align="right" 
                                                               BorderStyle="None" size="72"></asp:TextBox>
                                                       </td>
                                                          </tr>--%>
                                                      <%-- <tr>
                                                           <td class="style1">
                                                               <asp:TextBox ID="txt_Importer_Address" runat="server" align="right" 
                                                                   BorderStyle="None" Height="55px" TextMode="MultiLine" Width="461px" 
                                                                   Wrap="true"></asp:TextBox>
                                                           </td>
                                                       </tr>--%>
                                                       <%-- <tr>
                                                       <td class="left_border_style">
                                                            <table width="450px">
                                                               <tr>
                                                           <td width="500px">
                                                               <font face="Times New Roman" size="2">Imp Ref No : </font>
                                                               <asp:TextBox ID="txt_Imp_Refno" runat="server" align="left" BorderStyle="None" 
                                                                   size="40"></asp:TextBox>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td>
                                                               Date :
                                                               <asp:TextBox ID="txt_Todate_Date" runat="server" align="left" 
                                                                   BorderStyle="None" size="60"></asp:TextBox>
                                                           </td>
                                                       </tr>
                                                           </table>
                                                       </td>
                                                   </tr>--%>
                                                       <tr>
                                                           <td  class="border_style" colspan="2">
                                                               <font face="Times New Roman" size="2">Marks &amp; No's : </font>
                                                               <font face="Times New Roman" size="2">
                                                               <asp:TextBox ID="txt_Marks_Nos" runat="server" align="left" BorderStyle="None" 
                                                                   Width="40%"></asp:TextBox>
                                                               </font>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td class="border_style" colspan="2">
                                                               <asp:TextBox ID="txt_Body_contents" runat="server" align="left" 
                                                                   BorderStyle="None" Height="90px" 
                                                                   style="min-height:90px;max-height:90px;min-width:100%;max-width:100%" 
                                                                   TextMode="MultiLine" Width="900px"></asp:TextBox>
                                                           </td>
                                                       </tr>
                                                       <tr>
                                                           <td colspan="2">
                                                               <table width="910px">
                                                                   <tr style="width:220px">
                                                                       <td class="border_style" style="height:60px;width:1100px" valign="top">
                                                                           No of Pkgs : <font face="Times New Roman" size="2">
                                                                           <asp:TextBox ID="txt_noofpackage" runat="server" align="left" 
                                                                               BorderStyle="None" Height="34px" 
                                                                               onkeypress="return blockNonNumbers(this, event, true, false);" 
                                                                              ></asp:TextBox>
                                                                           </font>
                                                                     <%--  </td>--%>
                                                                       </tr>
                                                                           <tr>
                                                                           <td class="border_style">
                                                                Mawbl/Mbl No :
                                                                               <asp:TextBox ID="txt_mabl" runat="server" align="left" BorderStyle="None" size="50"></asp:TextBox>
                                                                               <font face="Times New Roman" size="2">Mawbl_Date : </font>
                                                                               <asp:TextBox ID="txt_dt" runat="server" align="right" BorderStyle="None"></asp:TextBox>
                                                               </td>
                                                                              <%-- <td class="border_style" style="height:60px;width:100px" valign="top">
                                                                                   Mawbl/Mbl No: <font face="Times New Roman" size="2">
                                                                                   <asp:TextBox ID="txt_mabl" runat="server" align="left" BorderStyle="None" 
                                                                                       Height="34px"></asp:TextBox>
                                                                                   </font>
                                                                                   <td class="border_style" style="height:60px;width:100px" valign="top">
                                                                                   Mawbl_Date : <font face="Times New Roman" size="2">
                                                                                   <asp:TextBox ID="txt_dt" runat="server" align="left" BorderStyle="None" 
                                                                                       Height="34px"></asp:TextBox>
                                                                                   </font>
                                                                               </td>--%>
                                                                               </tr>
                                                                               <tr>
                                                                                <td class="border_style">
                                                                Hawbl/Hbl No :
                                                               <asp:TextBox ID="txt_habl" runat="server" align="left" BorderStyle="None" 
                                                                   size="50"></asp:TextBox>
                                                        
                                                                   <font face="Times New Roman" size="2"> Hawbl_Date : </font>
                                                                                    <asp:TextBox ID="txt_dat" runat="server" align="right" BorderStyle="None"></asp:TextBox>
                                                               </td>
                                                                              <%-- <td class="border_style" style="height: 60px; width: 100px" valign="top">
                                                                                   Hawbl/Hbl No : <font face="Times New Roman" size="2">
                                                                                   <asp:TextBox ID="txt_habl" runat="server" align="left" BorderStyle="None" 
                                                                                       Height="34px"></asp:TextBox>
                                                                                   </font>
                                                                                   <td class="border_style" style="height: 60px; width: 100px" valign="top">
                                                                                   Hawbl_date : <font face="Times New Roman" size="2">
                                                                                   <asp:TextBox ID="txt_dat" runat="server" align="left" BorderStyle="None" 
                                                                                       Height="34px"></asp:TextBox>
                                                                                   </font>--%>
                                                                              <%-- </td>--%>
                                                                               </tr>
                                                                               <tr>
                                                                               <td class="border_style" style="height:60px;width:100px" valign="top">
                                                                                   Gross Weight : <font face="Times New Roman" size="2">
                                                                                   <asp:TextBox ID="txt_gross_weight" runat="server" align="left" 
                                                                                       BorderStyle="None" Height="35px"></asp:TextBox>
                                                                                   </font>
                                                                            </td>
                                                                   </tr>
                                                                   </tr>
                                                               </table>
                                                           </td>
                                                       </tr>
                                                   </tr>
                                                    
                           </table>
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <table width="400px">
                               <tr valign="TOP">
                                   <td colspan="4" >
                                       <font face="Times New Roman" size="2">BE No &amp; Date </font>
                                   </td>
                                  <%-- <td colspan="1">
                                       <font face="Times New Roman" size="2">MAWB / HAWB No</font>
                                   </td>--%>
                                   <td colspan="4">
                                       <font face="Times New Roman" size="2">Description of goods</font>
                                   </td>
                               </tr>
                               <tr valign="TOP">
                                   <td class="right_border_style" colspan="4">
                                       <font face="Times New Roman" size="2">
                                       <asp:TextBox ID="txt_BE_No_Date" runat="server" align="left" BorderStyle="None" 
                                           Height="140px" TextMode="MultiLine" Width="140px"></asp:TextBox>
                                       </font>
                                   </td>
                              <%--     <td class="right_border_style">
                                       <font face="Times New Roman" size="2">
                                       <asp:TextBox ID="txt_Mawb_Hawb_No" runat="server" align="left" 
                                           BorderStyle="None" Height="300px" TextMode="MultiLine" Width="220px"></asp:TextBox>
                                       </font>
                                   </td>--%>
                                   <td class="border_style" colspan="2">
                                       <font face="Times New Roman" size="2">
                                       <asp:TextBox ID="txt_Description" runat="server" align="left" 
                                           BorderStyle="None" Height="90px" TextMode="MultiLine" Width="760px"></asp:TextBox>
                                       </font>
                                   </td>
                               </tr>
                               <%--<tr valign="TOP">
                                   <td colspan="8">
                                       <font face="Times New Roman" size="2"><b>Note : </b></font>
                                   </td>
                               </tr>
                               <tr valign="TOP">
                                   <td colspan="11">
                                       <font face="Times New Roman" size="2">Enclosed Documents</font>
                                   </td>
                               </tr>--%>
                            <%--   <tr valign="TOP">
                                   <td colspan="11" rowspan="2">
                                       <table cellspacing="0" width="900px">
                                           <tr>
                                               <td align="LEFT">
                                                   <font face="Times New Roman" size="2">Yellow B/E ------ Original , Duplicate , 
                                                   Triplicate , Quadruplicate &amp; STPI Approved</font>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td align="LEFT">
                                                   <font face="Times New Roman" size="2">White B/E ------ Duplicate , Triplicate / 
                                                   Quadruplicate &amp; Duty paid challan</font>
                                               </td>
                                           </tr>
                                       </table>
                                   </td>
                               </tr>--%>
                           </table>
                       </td>
                   </tr>
                   <tr>
                   <td>
                   <table width="400px">
                <%--          <tr valign="TOP">
                                   <td colspan="4" >
                                       <font face="Times New Roman" size="2">INVOICE NO: </font>
                                   </td>
                                   <td colspan="1">
                                       <font face="Times New Roman" size="2">CONTAINER NO:</font>
                                   </td>
                                    <td colspan="1">
                                       <font face="Times New Roman" size="2">CONTAINER SIZE:</font>
                                   </td>
                                    <td colspan="1">
                                       <font face="Times New Roman" size="2">SEAL NO:</font>
                                   </td>
                                   <td colspan="4">
                                       <font face="Times New Roman" size="2">INVOICE DATE:</font>
                                   </td>
                               </tr>
                               <tr valign="TOP">
                                   <td class="right_border_style" colspan="4">
                                       <font face="Times New Roman" size="2">
                                       <asp:TextBox ID="txtinvoice" runat="server" align="left" BorderStyle="None" 
                                           Height="140px"Width="140px"></asp:TextBox>
                                       </font>
                                   </td>
                                   <td class="right_border_style">
                                       <font face="Times New Roman" size="2">
                                       <asp:TextBox ID="txt_container_no" runat="server" align="left" 
                                           BorderStyle="None" Height="140px"  Width="140px"></asp:TextBox>
                                       </font>
                                   </td>
                                     <td class="right_border_style">
                                       <font face="Times New Roman" size="2">
                                       <asp:TextBox ID="txt_container_size" runat="server" align="left" 
                                           BorderStyle="None" Height="140px"  Width="140px"></asp:TextBox>
                                       </font>
                                   </td>
                                    <td class="right_border_style">
                                       <font face="Times New Roman" size="2">
                                       <asp:TextBox ID="txt_seal_no" runat="server" align="left" 
                                           BorderStyle="None" Height="140px"  Width="140px"></asp:TextBox>
                                       </font>
                                   </td>
                                   <td class="border_style" colspan="2">
                                       <font face="Times New Roman" size="2">
                                       <asp:TextBox ID="txt_invoice_dt" runat="server" align="left" 
                                           BorderStyle="None" Height="140px" Width="140px"></asp:TextBox>
                                       </font>
                                   </td>
                               </tr>--%>
                     <%--              <tr>
                       <td>--%>
                 <%--          <table width="910px">
                               <tr style="height:120px" valign="TOP">
                                   <td class="border_style" style="width:400px;" valign="top">
                                       <font face="Times New Roman" size="2">Name and Signature of receiver with seal :</font>
                                   </td>
                                   <td align="right" class="left_border_style" style="width:400px" valign="top">
                                       <font face="Times New Roman" size="2">For
                                       <asp:TextBox ID="txt_CHA_Name_sub1" runat="server" align="left" 
                                           BorderStyle="None" Width="280px"></asp:TextBox>
                                       </font>
                                   </td>
                               </tr>
                           </table>
                       </td>
                   </tr>--%>
                       </tr>
                                                                           <tr>
                                                                           <td class="border_style">
                                                                Invoice No:
                                                               <asp:TextBox ID="txtinvoice" runat="server" align="left" BorderStyle="None" 
                                                                   size="50"></asp:TextBox>
                                                        
                                                                   <font face="Times New Roman" size="2"> Invoice Date : </font>
                                                                               <asp:TextBox ID="txt_invoice_dt" runat="server" align="right" BorderStyle="None"></asp:TextBox>
                                                               </td>
                                                                               </tr>
                                                                               <tr>
                                                                                <td class="border_style">
                                                                Container No:
                                                               <asp:TextBox ID="txt_container_no" runat="server" align="left" BorderStyle="None" 
                                                                   size="50"></asp:TextBox>
                                                        
                                                                   <font face="Times New Roman" size="2"> Container Size: </font>
                                                                   <asp:TextBox ID="txt_container_size" runat="server" align="right" BorderStyle="None"></asp:TextBox>
                                                               </td>
                                                                              <%-- <td class="border_style" style="height: 60px; width: 100px" valign="top">
                                                                                   Hawbl/Hbl No : <font face="Times New Roman" size="2">
                                                                                   <asp:TextBox ID="txt_habl" runat="server" align="left" BorderStyle="None" 
                                                                                       Height="34px"></asp:TextBox>
                                                                                   </font>
                                                                                   <td class="border_style" style="height: 60px; width: 100px" valign="top">
                                                                                   Hawbl_date : <font face="Times New Roman" size="2">
                                                                                   <asp:TextBox ID="txt_dat" runat="server" align="left" BorderStyle="None" 
                                                                                       Height="34px"></asp:TextBox>
                                                                                   </font>--%>
                                                                              <%-- </td>--%>
                                                                               </tr>
                                                                               <tr>
                                                                               <td class="border_style" style="height:60px;width:100px" valign="top">
                                                                                  Seal No: <font face="Times New Roman" size="2">
                                                                                   <asp:TextBox ID="txt_seal_no" runat="server" align="left" 
                                                                                       BorderStyle="None" Height="35px"></asp:TextBox>
                                                                                   </font>
                                                                            </td>
                                                                   </tr>
                               <tr valign="TOP">
                                   <td colspan="8">
                                       <font face="Times New Roman" size="2"><b>Declaration:</b></font>
                                   </td>
                               </tr>
                               <tr valign="TOP">
                                   <td colspan="11">
                                       <font face="Times New Roman" size="2">we hereby received cargo in good condition</font>
                                   </td>
                               </tr>
                               <tr valign="TOP">
                                   <td colspan="11" rowspan="2">
                                       <table cellspacing="0" width="900px">
                                           <tr>
                                               <td align="LEFT">
                                                   <font face="Times New Roman" size="2">Name and Signature of receiver with seal :</font>
                                               </td>
                                           </tr>
                                           <tr>
                                               <td align="LEFT">
                                                   <font face="Times New Roman" size="2">Date:</font>
                                                   <tr>
                                                   <td align="LEFT">
                                                     <font face="Times New Roman" size="2">Time:</font>
                                               </td>
                                               </tr>
                                               </td>
                                               <tr>
                                                   <td align="RIGHT">
                                                       <font face="Times New Roman" size="2">Authorised Signatory</font>
                                                   </td>
                                                   <%--<td align="LEFT">
                                                   <font face="Times New Roman" size="2">TIME:</font>
                                               </td>--%>
                                               </tr>
                                           </tr>
                                       </table>
                                   </td>
                               </tr>
                           </table>
                   
                 <%-- </td>
                   </tr></table><table>--%>
          
          </table>

  </div>
                
          </div>
          </div>
           
             <asp:HiddenField ID="HiddenField1" runat="server" />
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
                     NewWindow1('../Report/Import_Delivery_Challan_Rpt_viewer.aspx?jobno=' + jobno + '', 'List', '810', '1024', 'yes');
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
//        function fill(f) {
//            if (f.chkBx.checked == true) {
//                f.txtAdd5.value = f.txtaddr1.value;
//                f.txtAdd6.value = f.txtaddr2.value;
//                f.txtAdd7.value = f.txtaddr3.value;
//            }
//        }

        
    </script>
</body>
</html>
