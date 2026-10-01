<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LTR_DOC.aspx.cs" Inherits="Transaction_Import_KKForm" %>

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

     <style type="text/css">
input.underlined
{
   border:0;
   border-bottom:solid 1px #000;
   outline:none; /* prevents textbox highlight in chrome */
}
</style>


    <style type="text/css">
udl {    
    border-bottom: 1px dotted #000;
    text-decoration:underline;
}
</style>

<style>
        u.dotted{
          border-bottom: 1px dashed #999;
          text-decoration: none; 
          border-bottom-color:Red;
        }
    </style>



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
                NewWindow1('../BOXCO_Rpt/LTR_DOC_Rpt.aspx?jobno=' + document.getElementById("<%=ddlJobNo.ClientID %>").value + '', 'List', '810', '750', 'yes');               
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
    <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'LTR DOCUMENT ', function(r) {
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

    <TABLE ALIGN=BLEEDLEFT WIDTH=100% CELLSPACING=0 CELLPADDING=0 BORDER=0 height="50x">
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


    <table align="left">
    
    
    <tr>
    <td width="100px"></td>
   <td colspan="2">
     Ref:
    </td>
   
    <td colspan="1">
        :<asp:TextBox ID="txtImporterName" runat="server" Width="250px" BorderStyle="None" MaxLength="50" CssClass="u"></asp:TextBox>
    </td>
    <td width="150px"></td>
     <td colspan="4">
    Current Date:
    </td>
  
    <td colspan="1">
        <u class="dotted">:<asp:TextBox ID="txt_CurrentDate" runat="server" Width="250px" BorderStyle="None" MaxLength="50" text-decoration="dotted"></asp:TextBox></u>
    </td>
    </tr>

        <tr>
    <td width="100px"></td>
   <td colspan="2">
   
    </td>
   
    <td colspan="1">
        :<asp:TextBox ID="txt_ADDRESS1" runat="server" Width="250px" BorderStyle="None" MaxLength="50" CssClass="underlined"></asp:TextBox>
    </td>
    </tr>

        <tr>
    <td width="100px"></td>
   <td colspan="2">
   
    </td>
  
    <td colspan="1">
        :<asp:TextBox ID="txt_ADDRESS2" runat="server" Width="250px" BorderStyle="None" MaxLength="50" ></asp:TextBox>
    </td>
    </tr>

        <tr>
    <td width="100px"></td>
   <td colspan="2">
    
    </td>
  
    <td colspan="1">
        :<asp:TextBox ID="txt_ADDRESS3" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>

        <tr>
    <td width="100px"></td>
   <td colspan="2">
   
    </td>
 
    <td colspan="1">
        :<asp:TextBox ID="txt_ADDRESS4" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>

  <tr>
    <td width="100px"></td>
   <td colspan="2">
  
    </td>
   
    <td colspan="1">
        :<asp:TextBox ID="txt_ADDRESS5" runat="server" Width="250px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>


      <tr height="30px">
    <td width="100px"></td>
   <td colspan="3" align="left">
    Kind Attn:
    </td>
    </tr>

     <tr height="30px">
    <td width="100px"></td>
   <td colspan="3" align="left">
   <asp:Label ID="Label2" runat="server" Text="Dear Sir," Font-Bold="false"></asp:Label>
  
    </td>
    </tr>

   

      <tr align="left">
    <td width="100px"></td>
   <td colspan="15">
     Sub: Shipping Documents of
     :<asp:TextBox ID="txt_NO_OF_PKGS" runat="server" BorderStyle="None" MaxLength="50" Width="170px"></asp:TextBox>
      x20’Cntr. STC 
       :<asp:TextBox ID="txt_PRODUCT_QUANTITY" runat="server" Width="170px" BorderStyle="None" MaxLength="50"></asp:TextBox>
       Mts of 
    </td>
    </tr>



    <tr align="left">
    <td width="100px"></td>
    <td colspan="9">
       :<asp:TextBox ID="txt_PRODUCT_DESCRIPTION" runat="server" Width="650px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>


    <tr align="left" height="50px">
   <td width="100px"></td>
     <td colspan="9">
     pertaining to Vsl. M.V. 
        :<asp:TextBox ID="txt_VESSEL_FLIGHT_NO" runat="server" Width="150px" BorderStyle="None" MaxLength="50"></asp:TextBox>
        Voy.
        :<asp:TextBox ID="txt_VOYAGE" runat="server" Width="150px" BorderStyle="None" MaxLength="50" ></asp:TextBox>
    </td>
    </tr>


   <tr align="left">
   <td width="100px"></td>
     <td colspan="9">
     <asp:Label ID="Label3" runat="server" Text=" We are enclosing herewith the following original documents, in respect of the above import for your " Font-Bold="false"></asp:Label>
    
    </td>
    </tr>

       <tr align="left">
   <td width="100px"></td>
     <td colspan="9">
      <asp:Label ID="Label4" runat="server" Text="information and records:" Font-Bold="false"></asp:Label>
     
    </td>
    </tr>

     <tr align="left"> 
     <td></td>
      </tr>

     <%-- <tr align="left">
   <td width="100px"></td>
     <td colspan="4" width="360px">
    1.	Original Duplicate Copy (Importer Copy) of B/EntryNo.</td>
     <td colspan="8">:<asp:TextBox ID="TextBox9" runat="server" Width="150px" BorderStyle="None" MaxLength="50"></asp:TextBox>
     Dt
      :<asp:TextBox ID="TextBox11" runat="server" Width="100px" BorderStyle="None" MaxLength="50"></asp:TextBox>
    </td>
    </tr>--%>

     <tr align="left">
   <td width="100px"></td>
   <td colspan="9" font:bold="false">
   <asp:Label ID="Label5" runat="server" Text="1.Original Duplicate Copy (Importer Copy) of B/EntryNo." Font-Bold="false"></asp:Label>
    
    :<asp:TextBox ID="txt_BE_NO" runat="server" Width="150px" BorderStyle="None" MaxLength="50" Font-Bold="true"></asp:TextBox>
     Dt
      :<asp:TextBox ID="txt_BE_DATE" runat="server" Width="100px" BorderStyle="None" MaxLength="50" Font-Bold="true"></asp:TextBox>
    </td>
    </tr>


      <tr align="left">
   <td width="100px"></td>
     <td colspan="9">
     <asp:Label ID="Label6" runat="server" Text="2.Copy of Triplicate (Exchange Control Copy) of B/Entry No. " Font-Bold="false"></asp:Label>
    
     :<asp:TextBox ID="txt_Copy_BE_NO" runat="server" Width="150px" BorderStyle="None" MaxLength="50" Font-Bold="true"></asp:TextBox>
     Dt
      :<asp:TextBox ID="txt_Copy_BE_Date" runat="server" Width="100px" BorderStyle="None" MaxLength="50" Font-Bold="true"></asp:TextBox>
    </td>
    </tr>

     <tr align="left">
   <td width="100px"></td>
     <td colspan="3">
      <asp:Label ID="Label7" runat="server" Text=" 3.Customs Duty paid E-Receipt No." Font-Bold="false"></asp:Label>
   </td>
    <td colspan="8">:<asp:TextBox ID="txt_E_RECEIPT_NO" runat="server" Width="150px" Font-Bold="true"
            BorderStyle="None" MaxLength="50" style="margin-right: 0px"></asp:TextBox>
     Dt
      :<asp:TextBox ID="txt_E_RECEIPT_DATE" runat="server" Width="100px" BorderStyle="None" MaxLength="50" CssClass="u" Font-Bold="true" ></asp:TextBox>
    </td>
    </tr>


    <tr align="left">
   <td width="100px"></td>
     <td colspan="3">
     <asp:Label ID="Label8" runat="server" Text=" 4.Copy of B/L No." Font-Bold="false"></asp:Label>
    </td>
      <td colspan="8"> :<asp:TextBox ID="txt_MAWB_NO" runat="server" Width="150px" BorderStyle="None" MaxLength="50" Font-Bold="true"></asp:TextBox> 
    Dt
      :<asp:TextBox ID="txt_MAWB_DATE" runat="server" Width="100px" BorderStyle="None" MaxLength="50" Font-Bold="true"></asp:TextBox>
    </td>
    </tr>

    <tr align="left">
   <td width="100px"></td>
     <td colspan="3">
      <asp:Label ID="Label9" runat="server" Text=" 5.Original Commercial Inv. No." Font-Bold="false"></asp:Label>
  </td>
    <td colspan="8"> :<asp:TextBox ID="txt_INVOICE_NO" runat="server" Width="150px" BorderStyle="None" MaxLength="50" Font-Bold="true"></asp:TextBox>
     Dt
      :<asp:TextBox ID="txt_INVOICE_DATE" runat="server" Width="100px" BorderStyle="None" MaxLength="50" Font-Bold="true"></asp:TextBox>
    </td>
    </tr>

     <tr align="left">
   <td width="100px"></td>
     <td colspan="3">
      <asp:Label ID="Label10" runat="server" Text=" 6.Packing List dt." Font-Bold="false"></asp:Label>
  </td>
    <td colspan="8"> 
    <%--:<asp:TextBox ID="TextBox20" runat="server" Width="150px" BorderStyle="None" MaxLength="50"></asp:TextBox>--%>
     Dt
      :<asp:TextBox ID="txt_PACK_INVOICE_DATE" runat="server" Width="100px" BorderStyle="None" MaxLength="50" Font-Bold="true"></asp:TextBox>
    </td>
    </tr>

      <tr align="left">
   <td width="100px"></td>
     <td colspan="3">
      <asp:Label ID="Label11" runat="server" Text="7.Original Certificate of Origin No. Nil dt." Font-Bold="false"></asp:Label>
  </td>
     <td colspan="8">
     <%--:<asp:TextBox ID="TextBox22" runat="server" Width="150px" BorderStyle="None" MaxLength="50"></asp:TextBox>--%>
     Dt
      :<asp:TextBox ID="txt_CERT_INVOICE_DATE" runat="server" Width="100px" BorderStyle="None" MaxLength="50" Font-Bold="true"></asp:TextBox>
    </td>
    </tr>


          <tr align="left">
   <td width="100px"></td>
     <td colspan="3">
     <asp:Label ID="Label12" runat="server" Text="8.Certificate of Weight and analysis No. Nil dt." Font-Bold="false"></asp:Label>
 </td>
    <td colspan="8"> 
    <%--:<asp:TextBox ID="TextBox24" runat="server" Width="150px" BorderStyle="None" MaxLength="50"></asp:TextBox>--%>
     Dt
      :<asp:TextBox ID="txt_CERT_WEIGHT_INVOICE_DATE" runat="server" Width="100px" BorderStyle="None" MaxLength="50"  Font-Bold="true"></asp:TextBox>
    </td>
    </tr>

              <tr align="left">
   <td width="100px"></td>
     <td colspan="3">
      <asp:Label ID="Label13" runat="server" Text=" 9.Original & Duplicate of Certificate of Insurance No." Font-Bold="false"></asp:Label>
</td>
    <td colspan="8"> :<asp:TextBox ID="txt_INSURANCE_NO" runat="server" Width="150px" BorderStyle="None" MaxLength="50"  Font-Bold="true"></asp:TextBox>
     Dt
      :<asp:TextBox ID="txt_INSURANCE_DATE" runat="server" Width="100px" BorderStyle="None" MaxLength="50"  Font-Bold="true"></asp:TextBox>
    </td>
    </tr>

       <tr align="left">
   <td width="100px"></td>
     <td colspan="3">
      <asp:Label ID="Label14" runat="server" Text="10.Copy of D.O. No." Font-Bold="false"></asp:Label>
</td>
     <td colspan="8">:<asp:TextBox ID="txt_DO_NO" runat="server" Width="150px" BorderStyle="None" MaxLength="50"  Font-Bold="true"></asp:TextBox>
     Dt
      :<asp:TextBox ID="txt_DO_DATE" runat="server" Width="150px" BorderStyle="None" MaxLength="50"  Font-Bold="true"></asp:TextBox>
      <asp:Label ID="Label19" runat="server" Text=" duly franked" Font-Bold="false"></asp:Label>
     
    </td>
    </tr>

     <tr align="left">
   <td width="100px"></td>
     <td colspan="3">
     <asp:Label ID="Label15" runat="server" Text="11.Fertilizer Sample drawn Form “J” Certificate No." Font-Bold="false"></asp:Label>
</td>
     <td colspan="8">:<asp:TextBox ID="txt_J_CERT_NO" runat="server" Width="150px" BorderStyle="None"  Font-Bold="true"
             MaxLength="50" ></asp:TextBox>
     Dt
      :<asp:TextBox ID="txt_J_CERT_DATE" runat="server" Width="100px" BorderStyle="None" MaxLength="50"  Font-Bold="true"></asp:TextBox>
     
    </td>
    </tr>

      <tr height="10px">
    <td></td>
    </tr>

         <tr align="left">
   <td width="100px"></td>
     <td colspan="9">
     <asp:Label ID="Label16" runat="server" Text="Kindly acknowledge the receipt." Font-Bold="false"></asp:Label>
    
    </td>
    </tr>

      <tr align="left">
   <td width="100px"></td>
     <td colspan="9">
     <asp:Label ID="Label17" runat="server" Text=" Thanking you and assuring you of  our best services at all times." Font-Bold="false"></asp:Label>

    </td>
    </tr>

        <tr align="left">
            <td width="100px">
            </td>
            <td colspan="9">
             <asp:Label ID="Label18" runat="server" Text=" Yours faithfully," Font-Bold="false"></asp:Label>
               
            </td>
        </tr>

         <tr height="10px">
    <td></td>
    </tr>


         <tr align="left">
            <td width="100px">
            </td>
            <td colspan="9">
            <asp:Label ID="lbl_for" runat="server" Text="For" Font-Bold="false"></asp:Label>
               
                :<asp:TextBox ID="txt_FOR" runat="server" Width="500px" BorderStyle="None" MaxLength="50"  Font-Bold="true"></asp:TextBox>
            </td>
        </tr>



    <tr height="50px">
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
