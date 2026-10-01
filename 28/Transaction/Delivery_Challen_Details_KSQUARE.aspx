<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Delivery_Challen_Details_KSQUARE.aspx.cs" Inherits="Export_Export_GSP_Front_DetailsK2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import - Delivery Report</title>
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
                        Import - Delivery Note
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
                           
                    
                            <%--<div id="tag_label_transact_Src">
                                
                            </div>--%>
                           
                            <%--<div id="txtcon-m_src">
                                
            
                             <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" 
                             Style="display: none;" />
                            </div>--%>
                            
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
            <td colspan="15"  align="center">
               
                <font face="Times New Roman" size="2"><b>DELIVERY NOTE</b></font>
               
          
            </td>
            
        </tr>
          <tr>
           <%--<td align="center" colspan="14">
                <asp:Image ID="Image1" runat="server" Width="150px" Height="50px" ImageUrl="" onmouseover="Big(this);" onmouseout="Small(this);"/>
                </FONT>
            </td>--%>
         
      
          </tr>
             <tr VALIGN="TOP" style="width:100px">
            <td style="width:50px;" colspan="14" align="left">
                <font face="Times New Roman" size="2">
                <b>K SQUARE LOGISTICS</b> 
                NO: 43/44, BALAJI NAGAR,
                3rd STREET, KORATTUR,
                CHENNAI - 600 076.
                PH : 7305016030.
                G.S.T NO: 33AANFK8631Q1ZM
                    <%--<asp:TextBox ID="txt_CHA_Name" runat="server" BorderStyle="None"   size="25" 
                        Text="AIRLIFT CONTAINER LINE" style="text-align:center"></asp:TextBox>--%>
                    </font>
            </td>
            <td style="width:700px;" align="right"">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                <asp:ListItem>PACKING</asp:ListItem>
                <asp:ListItem>SHIPPING</asp:ListItem>
                <asp:ListItem>CLEARING</asp:ListItem>
                <asp:ListItem>FORWARDING</asp:ListItem>
                <asp:ListItem>TRANSPORT</asp:ListItem>
                </asp:CheckBoxList>
            
            </td>
        </tr>
        <tr>
            <td colspan="14" align="center">
                <font face="Times New Roman" size="2"><b>
                    <%--<asp:TextBox ID="txt_CHA_Name_sub" runat="server" BorderStyle="None" size="25" 
                        Text="Airlift (U.S.A),Inc."></asp:TextBox>--%>
                    </b></font>
            </td>
        </tr>
          </table>
          </td>
         
     
          </tr>
       
      
        <tr valign="TOP">
          <td align="left"  >
          <table width="500px">
         
          <tr  valign="top" >
         <td colspan="2" valign="top">
       <table width="400px">
        <tr>
          <td colspan="2" class="bottom_border_style" valign="top"><font face="Times New Roman" size="2">
              <%--<asp:TextBox ID="txt_Cha_Address" runat="server" align="left" BorderStyle="None" Height="35px" 
                  Width="100%" TextMode="MultiLine"></asp:TextBox>--%>
              </font>
          
          </td>
          </tr>
       <tr>
    
         
           <td class="border_style" valign="top">
               <table width="450px">
                   <tr>
                       <td width="500px">
                           <font face="Times New Roman" size="2">CONSIGNEE: </font>
                       </td>
                   </tr>
                   <tr>
                       <td>
                       <asp:TextBox ID="txtConsignee" runat="server" Width="450px"></asp:TextBox>
                           <asp:TextBox ID="txtConsigneeaddress" runat="server"  TextMode="MultiLine" align="left" BorderStyle="None" 
                             Width="450px" Height="50px"  size="72"></asp:TextBox>
                           
                       </td>
                   </tr>
                   <tr>
                       <td width="500px">
                           <font face="Times New Roman" size="2">DELIVERY AT: </font>
                       </td>
                   </tr>
                   <tr>
                       <td>
                       <asp:TextBox ID="txtDeliveryat" runat="server" Width="450px"></asp:TextBox>
                           <asp:TextBox ID="txtDeliveryataddress" runat="server" align="left" BorderStyle="None" TextMode="MultiLine" Wrap="true"
                               Width="450px" Height="50px"></asp:TextBox>
                       </td>
                   </tr>
               </table>
           </td>
           <td class="left_border_style">
               <table width="450px">
                   <tr>
                       <td>
                           <font face="Times New Roman" size="2">D.C. No: </font>
                           <asp:TextBox ID="txtDcno" runat="server" align="left" BorderStyle="None" 
                               ></asp:TextBox>
                       </td>
                       <td>
                           DT :
                           <asp:TextBox ID="txtDcdt" runat="server" align="left" BorderStyle="None" 
                               ></asp:TextBox>
                               <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDcdt"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDcdt"
                                PopupButtonID="txtDcdt" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                       </td>
                   </tr>
                   <tr>
                       <td >
                           <font face="Times New Roman" size="2">Ref. No: </font>
                           <asp:TextBox ID="txtRefno" runat="server" align="left" BorderStyle="None" 
                               ></asp:TextBox>

                       </td>
                       <td>
                           
                       </td>
                   </tr>
                   <tr>
                       <td >
                           <font face="Times New Roman" size="2">B./E. No: </font>
                           <asp:TextBox ID="txtBeno" runat="server" align="left" BorderStyle="None" 
                               ></asp:TextBox>
                       </td>
                       <td>
                           DT :
                           <asp:TextBox ID="txtBedt" runat="server" align="left" BorderStyle="None" 
                               ></asp:TextBox>
                               <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtBedt"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBedt"
                                PopupButtonID="txtBedt" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                       </td>
                   </tr>
                   <tr>
                       <td >
                           <font face="Times New Roman" size="2">Duty No: </font>
                           <asp:TextBox ID="txtDutyno" runat="server" align="left" BorderStyle="None" 
                              ></asp:TextBox>
                       </td>
                       <td>
                           DT :
                           <asp:TextBox ID="txtDutydt" runat="server" align="left" BorderStyle="None" 
                               ></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDutydt"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtDutydt"
                                PopupButtonID="txtDutydt" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                       </td>
                   </tr>
                    <tr>
                       <td >
                           <font face="Times New Roman" size="2">L.R. No: </font>
                           <asp:TextBox ID="txtLrno" runat="server" align="left" BorderStyle="None" 
                               ></asp:TextBox>
                       </td>
                       <td>
                           DT :
                           <asp:TextBox ID="txtLrdt" runat="server" align="left" BorderStyle="None" 
                               ></asp:TextBox>
                               <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtLrdt"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtLrdt"
                                PopupButtonID="txtLrdt" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                       </td>
                   </tr>
                  
               </table>
           </td>
             </tr>
             <%--<tr>
                  <td class="top_border_style" colspan="2" >
                      <asp:TextBox ID="txt_Body_contents" runat="server" align="left" style="min-height:90px;max-height:90px;min-width:100%;max-width:100%"
                          BorderStyle="None" Height="90px" TextMode="MultiLine" Width="900px"></asp:TextBox>
                  </td>
              </tr>--%>
              <%--<tr>
                  <td colspan="2">
                      <font face="Times New Roman" size="2">Marks &amp; No's : </font>
                      <font face="Times New Roman" size="2">
                      <asp:TextBox ID="txt_Marks_Nos" runat="server" align="left" BorderStyle="None" 
                          Width="85%"></asp:TextBox>
                      </font>
                  </td>
              </tr>--%>
              <%--<tr>
                  <td  colspan="2">
                      <table width="910px">
                          <tr>
                              <td style="height:60px;width:820px" valign="top" class="border_style">
                                  No of Pkgs : <font face="Times New Roman" size="2">
                                  <asp:TextBox ID="txt_noofpackage" runat="server" align="left" BorderStyle="None"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                      Width="100%" Height="34px" TextMode="MultiLine"></asp:TextBox>
                                  </font>
                              </td>
                              <td style="height:60px;width:180px" valign="top" class="left_border_style">
                                  Gross Weight : <font face="Times New Roman" size="2">
                                  <asp:TextBox ID="txt_gross_weight" runat="server" align="left" BorderStyle="None" 
                                      Width="95%" Height="35px" TextMode="MultiLine"></asp:TextBox>
                                  </font>
                              </td>
                          </tr>
                      </table>
                  </td>
              </tr>--%>
                
             </table>
         
          </td>
          
          </tr>
        
              
            
   
          </table>
          </td>
          </tr>
          <tr>
          <td>
          <table width="400px">
           <tr valign="TOP">
                            
                              <td colspan="4" style="width:160px" align="center">
                                  <font face="Times New Roman" size="2">Marks & Nos </font>
                              </td>
                              <td colspan="1"  style="width:330px" align="center">
                                  <font face="Times New Roman" size="2">Description of goods</font>
                              </td>
                              <td colspan="2"  style="width:250px" align="center">
                                  <font face="Times New Roman" size="2">Gr.Weight</font>
                              </td>
                               <td colspan="1"  style="width:250px" align="center">
                                  <font face="Times New Roman" size="2">No.of.Pkg</font>
                              </td>

                          </tr>
                          <tr valign="TOP">
                              
                              <td class="right_border_style" colspan="4">
                                  <font face="Times New Roman" size="2">
                                  <asp:TextBox ID="txtMarksno" runat="server" align="left" BorderStyle="None" 
                                      Height="300px" Width="140px" TextMode="MultiLine"></asp:TextBox>
                                  </font>
                              </td>
                              <td class="right_border_style">
                                  <font face="Times New Roman" size="2">
                                  <asp:TextBox ID="txtDesc" runat="server" align="left" BorderStyle="None" 
                                      Height="300px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                                  </font>
                              </td>
                              <td class="border_style" colspan="2">
                                  <font face="Times New Roman" size="2">
                                  <asp:TextBox ID="txtGrweight" runat="server" align="left" BorderStyle="None" 
                                      Height="300px" Width="220px" TextMode="MultiLine"></asp:TextBox>
                                  </font>
                              </td>
                              <td class="border_style" colspan="2">
                                  <font face="Times New Roman" size="2">
                                  <asp:TextBox ID="txtNoofpkg" runat="server" align="left" BorderStyle="None" 
                                      Height="300px" Width="220px" TextMode="MultiLine"></asp:TextBox>
                                  </font>
                              </td>
                          </tr>
                          </table>
                          <table width="900px">
                          <tr valign="TOP">
                              <td >
                                  <font face="Times New Roman" size="2"><b>From : </b></font>
                              </td>
                               <td >
                                   <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                              </td>
                               <td >
                                  <font face="Times New Roman" size="2"><b>To : </b></font>
                              </td>
                               <td >
                                   <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                              </td>
                              <td >
                                  <font face="Times New Roman" size="2"><b>Vehicle No : </b></font>
                              </td>
                               <td >
                                   <asp:TextBox ID="txtVehino" runat="server"></asp:TextBox>
                              </td>

                          </tr>
                          <tr valign="TOP">
                          <td colspan="4"></td>
                              <td >
                                  <font face="Times New Roman" size="2">Name Of Driver</font>
                              </td>
                              <td >
                                  <asp:TextBox ID="txtDriver" runat="server"></asp:TextBox>
                              </td>
                          </tr>
                          <%--<tr valign="TOP">
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
          <table width="910px">
          
                        
                          <tr valign="TOP" style="height:120px">
                             
                              <td  class="border_style" style="width:400px;height:120px" a valign="top">
                                  <font face="Times New Roman" size="2">Received above in good condition</font>
                              </td>
                             
                              <td class="left_border_style" style="width:400px;height:120px" align="center" valign="top">  
                                  <font face="Times New Roman" size="2">Signature of person to whom delivered
                                  <%--<asp:TextBox ID="txt_CHA_Name_sub1" runat="server" align="left" BorderStyle="None" 
                                      Width="280px"></asp:TextBox>--%>
                                  </font>
                              </td>
                              <td class="left_border_style" style="width:400px;height:120px;vertical-align:bottom" align="center" >  
                                  <font face="Times New Roman" size="2">Delivery Clerk
                                  <%--<asp:TextBox ID="txt_CHA_Name_sub1" runat="server" align="left" BorderStyle="None" 
                                      Width="280px"></asp:TextBox>--%>
                                  </font>
                              </td>
                          </tr>
                       
          </table>
          </td>
          </tr>
          </table>
          <table>
          
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
                     var DCid = document.getElementById("<%=txtDcno.ClientID %>").value;
                     NewWindow1('../Report/Import_Delivery_Challan_Rpt_viewer.aspx?jobno=' + DCid + '', 'List', '810', '1024', 'yes');
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
