<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_KKForm.aspx.cs" Inherits="Transaction_Import_KKForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
<link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
<link href="../css/printstyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
<script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
      <%--<script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>--%>




  <script language="javascript" type="text/javascript">

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
   
    </script> 

    <script language="javascript">
        function KKForm() {          
            var jobno = document.getElementById("<%=ddlJobNo.ClientID %>").value;
            if (jobno != '') {
                NewWindow1('../Report/Import_KK_Form.aspx?jobno=' + document.getElementById("<%=ddlJobNo.ClientID %>").value + '', 'List', '810', '750', 'yes');               
            }
            else {
                alert('Select a Job');
            }
        }
    </script>

    </head>
<body BGCOLOR="FFFFFF">
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="JOBNO"></asp:Label>
     <asp:DropDownList ID="ddlJobNo" runat="server" Width="100" 
        AutoPostBack="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    
    </asp:DropDownList>
    <asp:Button ID="btn_print" runat="server" Text="print" OnClick="btn_print_Click" />

    <asp:Button ID="btnSave" runat="server" CssClass="save" TabIndex="115" OnClick="btnSave_Click1" />

    <asp:Button ID="btnupdate" runat="server" CssClass="updates" OnClick="btnupdate_Click" />
    <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'KK FORM ', function(r) {
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

    <input type="submit" value="Submit" class="scancel" onclick="win_hide();parent.adcodewindow.hide();return false;"
        id="btnCancel" tabindex="55" />

    <asp:Button ID="btnRpt" runat="server" Text="Report" OnClientClick="KKForm();return false;" />

    <div  align="center" id="s" runat="server">

    <TABLE ALIGN=BLEEDLEFT WIDTH=100% CELLSPACING=0 CELLPADDING=0 BORDER=0>
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
    <table align="center" width="700px">
    <tr align="center" >
    <td >
        <asp:Label ID="Label2" runat="server" Text="KK Form"></asp:Label>      
    </td>
    </tr>
   <tr align="center">
   <td>
   <asp:Label ID="lable3" Text="Form filed by clearing and forwarding agent" runat="server"></asp:Label>
   </td>
   </tr>
   <tr align="center">
   <td>
   <asp:Label ID="label3" runat="server" Text="[See rule 15(14), 15(15), 15(18)]"></asp:Label>
   </td>
   </tr>
    </table>

    <table>
    <tr>
    <td ></td>
    </tr>
    <tr>
    <td>
     Original     : 
    </td>
    <td> To be furnished to the prescribed authority 
    </td>
    <td> SL NO </td>
    </tr>

     <tr>
    <td>
     Duplicate  : 
    </td>
    <td>  To be retained by the clearing or forwarding agent  
    </td>
    </tr>

     <tr>
    <td>
     Triplicate  :  
    </td>
    <td> To be retained by the selling dealer or forwarding agent 
    </td>
    </tr>
    </table>

    <table>
     <tr>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="10px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="700px"></td>
     </tr>

    <tr>
   <td colspan="6">
      I   Name and Address of the clearing 
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtChaName" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan="6" align="center">forwarding agent</td><td></td>
    <td colspan="5">
        <asp:TextBox ID="txtChaAdd1" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan="6"></td><td></td>
     <td colspan="5">
        <asp:TextBox ID="txtChaAdd2" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan="6">  II   (a)  Full name and address of the  
    </td>
    <td align="right">:</td>
     <td colspan="5">
        <asp:TextBox ID="txtdealerName" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan="6" align="center">selling or buying dealer </td>
    <td colspan="5">
        &nbsp;</td>
    </tr>
    <tr>
    <td colspan="6"> (b)  TIN  
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtTIN" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan="6">  (c)  CST Registration No  
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtCSTRegNo" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td colspan="6">  (d)  Designation or registering authority  
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtDesignation" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>
     <tr>
    <td colspan="6">    (2)  Description of the goods 
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtDescription" runat="server" Width="450px" BorderStyle="None" MaxLength="120"></asp:TextBox>
    </td>
    </tr>

     <tr>
    <td colspan="6">  (3)  Quality and weight    
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtQuality" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>

     <tr>
    <td colspan="6">   (4)  Value of the goods 
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtValueOfGoods" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>

     <tr>
    <td colspan="6">  (5)  Clearing and forwarding  
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtClearingBENo" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td colspan="6" align="center"> B/E NO:    DATE:
    </td>
    </tr>

      <tr>
    <td colspan="6">    (6)  Signature of the selling dealer or    
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtSignature1" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td colspan="6">consignor of person delivering the goods 
    </td>
    </tr>

    <tr>
    <td colspan="6" align="center">to  the clearing / forwarding agent </td>
    </tr>


     <tr>
    <td colspan="6">     (7)  Signature of the clearing or forwarding   
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtSignatureCl_Fwd" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td colspan="6"> agent or any person authorised by him  
    </td>
    </tr>

    <tr>
    <td colspan="6" align="center">  to sign on behalf of him </td>
    </tr>


     <tr>
    <td colspan="6">         (8)  Name of the transport Company,      
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtTransportName" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td colspan="6"> vehicle No. or the person to whom the 
    </td>
    </tr>

     <tr>
    <td colspan="6" align="center">  goods are delivered for transport  </td>
    </tr>

    <tr>
    <td colspan="6" style=" font-family:Times New Roman">(9)  Signature of the person taking delivery of      
    </td>
    <td align="right">:</td>
    <td colspan="5">
        <asp:TextBox ID="txtdeliveryOfTrans" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td colspan="6"> the goods for the transport 
    </td>
    </tr>

    <tr>
    <td colspan="12" align="center" style=" font-family:Times New Roman font-size:larger">     DECLARATION   </td>
    </tr>

    <tr>
    <td colspan="12" align="center"> I/We DEMO declare that to the best of my/our knowledge and behalf the information 
    </td>
    </tr>

      <tr>
    <td colspan="12" > furnished in the above statement is true, correct and complete. 
    </td>
    </tr>
     <tr>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="700px"></td>
     </tr>

     <tr>
     <td colspan="2"> Place :</td>
     <td colspan="3"> <asp:TextBox ID="txtPlace" runat="server" Width="140px" BorderStyle="None" MaxLength="50"></asp:TextBox></td></td>
     <td colspan="1"> FOR </td>
     <td colspan="6"> <asp:TextBox ID="txtFOR" runat="server" Width="300px" BorderStyle="None" MaxLength="50"></asp:TextBox></td>
     </tr>

      <tr>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="50px"></td>
     <td width="700px"></td>
     </tr>

     <tr>
     <td colspan="2">Date:</td>     
      <td colspan="3"> <asp:TextBox ID="txtDate" runat="server" Width="140px" BorderStyle="None" MaxLength="50"></asp:TextBox></td></td>
     </tr>

     <tr>
     <td colspan="6"> </td>
     <td colspan="6"> Authorised Signatory</td>
     </tr>

     <tr>
     <td colspan="6"> </td>
     <td colspan="6"> Signature of the Clearing & Forwarding Agents. </td>
     </tr>

     <tr>
     <td colspan="2"> Note: </td>
     </tr>

     <tr>
     <td colspan="13">(1) The documents prescribed in sub-rule (14) of rule 15 shall also accompany this delivery note. 
     </td>
     </tr>

     <tr>
     <td colspan="13">(2) In cases of bulk consignment sent in different goods vehicles or boats, on various 
     </td>
     </tr>

     <tr>
     <td colspan="13">  dates, copies of the documents prescribed in sub-rule(14) of rule 15 shall be sent along with the
     </td>
     </tr>

     <tr>
     <td colspan="13">  goods vehicle or boat, duly certified as 'True copy' by the clearing or importer, as the case may be 
     </td>
     </tr>
     
    </table>
    </div>
    </form>

       <script src="../js/Validation.js" type="text/javascript"></script>

         <script src="../js/query.js" type="text/javascript"></script>
     <script src="../js/Validation.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
   
   
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
  
</body>
</html>
