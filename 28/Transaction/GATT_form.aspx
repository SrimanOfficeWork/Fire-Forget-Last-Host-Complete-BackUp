<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GATT_form.aspx.cs" Inherits="Transaction_GATT_form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>GATT</title>
 <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
  <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
<link href="../css/printstyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
<script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
     <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>

  <script language="javascript" type="text/javascript">

      function PrintGridData() {

          var prtGrid = document.getElementById('<%=s.ClientID %>');
          prtGrid.border = 0;
          var prtwin = window.open('','PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
          prtwin.document.write(prtGrid.outerHTML);
          prtwin.document.close();
          prtwin.focus();
          prtwin.print();
          //prtwin.close();
            }
   
    </script> 

    <script language="javascript">
    function Gatt() {
        var jobno = document.getElementById("<%=ddlJobNo.ClientID %>").value;
        var Type = 'Print';

        if (jobno != '') {
//            NewWindow1('../Report/Gatt_Rpt.aspx?jobno=' + document.getElementById("<%=ddlJobNo.ClientID %>").value + '', 'List', '810', '1024', 'yes');
            NewWindow1('../Report/Gatt_Rpt.aspx?jobno=' + jobno + '&Type=' + Type + '', 'List', '810', '1024', 'yes');

        }
        else {
            alert('Select a Job');
        }
    }

    </script>

    <script language="javascript">
        function Gatt_PrePrint() {
            var jobno = document.getElementById("<%=ddlJobNo.ClientID %>").value;
            var Type = 'PrePrint';

            if (jobno != '') {
                //            NewWindow1('../Report/Gatt_Rpt.aspx?jobno=' + document.getElementById("<%=ddlJobNo.ClientID %>").value + '', 'List', '810', '1024', 'yes');
                NewWindow1('../Report/Gatt_Rpt.aspx?jobno=' + jobno + '&Type=' + Type + '', 'List', '810', '1024', 'yes');

            }
            else {
                alert('Select a Job');
            }
        }
    </script>

    <style type="text/css">
        .style1
        {
            width: 1%;
        }
        .style2
        {
            width: 3%;
        }
        .style3
        {
            width: 5%;
        }
        .style4
        {
            width: 2%;
        }
        .style5
        {
            width: 4%;
        }
        .style6
        {
            width: 10px;
        }
    </style>
</head>
<body BGCOLOR="FFFFFF">
    <form id="form1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="JOBNO"></asp:Label>
     <asp:DropDownList ID="ddlJobNo" runat="server" Width="100" 
        AutoPostBack="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    
    </asp:DropDownList>


        <asp:Button ID="btn_print" runat="server" Text="print" onclick="btn_print_Click" />
         
         <asp:Button ID="btnSave" runat="server"  
                        CssClass="save" TabIndex="115" onclick="btnSave_Click1" />
     
     <asp:Button ID="btnupdate" runat="server"  
                        CssClass="updates" onclick="btnupdate_Click"   />

                        <%-- <div id="editbu">--%>
                    
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'GATT FORM', function(r) {
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

                                              
                    

    <asp:Button ID="btnRpt" runat="server" Text="Report" OnClientClick="Gatt();return false;" />
    <asp:Button ID="btn_PrePrint" runat="server" Text="Pre-Print" OnClientClick="Gatt_PrePrint();return false;" />

     <asp:Button ID="btn_ReGenerate" runat="server" CssClass="autowidmovebut" 
                            Text="Re-Generate Job Details" Width="200px" 
        onclick="btn_ReGenerate_Click" />

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
<TABLE ALIGN=BLEEDLEFT WIDTH=100% CELLSPACING=0 CELLPADDING=0 BORDER=0>
<TR>
<TD WIDTH=2.423% class="style1"></TD>
<TD WIDTH=1.088% class="style1"></TD>
<TD WIDTH=1.530% class="style1"></TD>
<TD WIDTH=0.060% class="style1"></TD>
<TD WIDTH=0.765% class="style1"></TD>
<TD WIDTH=1.275% class="style1"></TD>
<TD WIDTH=2.806% class="style1"></TD>
<TD WIDTH=0.315% class="style1"></TD>
<TD WIDTH=0.706% class="style1"></TD>
<TD WIDTH=1.173% class="style1"></TD>
<TD WIDTH=0.051% class="style1"></TD>
<TD WIDTH=7.185% class="style2"></TD>
<TD WIDTH=3.129% class="style1"></TD>
<TD WIDTH=1.445% class="style1"></TD>
<TD WIDTH=0.536% class="style1"></TD>
<TD WIDTH=0.383% class="style1"></TD>
<TD WIDTH=1.403% class="style1"></TD>
<TD WIDTH=1.726% class="style1"></TD>
<TD WIDTH=0.570% class="style1"></TD>
<TD WIDTH=0.842% class="style1"></TD>
<TD WIDTH=0.179% class="style1"></TD>
<TD WIDTH=0.553% class="style1"></TD>
<TD WIDTH=1.369% class="style1"></TD>
<TD WIDTH=0.119% class="style1"></TD>
<TD WIDTH=1.020% class="style1"></TD>
<TD WIDTH=0.765% class="style1"></TD>
<TD WIDTH=0.842% class="style3"></TD>
<TD WIDTH=0.434% class="style3"></TD>
<TD WIDTH=2.389% class="style1"></TD>
<TD WIDTH=0.485% class="style3"></TD>
<TD WIDTH=1.207% class="style1"></TD>
<TD WIDTH=4.847% class="style4"></TD>
<TD WIDTH=0.255% class="style1"></TD>
<TD WIDTH=3.316% class="style1"></TD>
<TD WIDTH=0.765% class="style1"></TD>
<TD WIDTH=0.799% class="style1"></TD>
<TD WIDTH=1.624% class="style1"></TD>
<TD WIDTH=0.578% class="style1"></TD>
<TD WIDTH=0.060% class="style1"></TD>
<TD WIDTH=0.986% class="style1"></TD>
<TD WIDTH=0.034% class="style1"></TD>
<TD WIDTH=0.757% class="style1"></TD>
<TD WIDTH=0.264% class="style1"></TD>
<TD WIDTH=1.020% class="style1"></TD>
<TD WIDTH=0.340% class="style1"></TD>
<TD WIDTH=1.318% class="style1"></TD>
<TD WIDTH=3.189% class="style1"></TD>
<TD WIDTH=0.255% class="style1"></TD>
<TD WIDTH=0.765% class="style1"></TD>
<TD WIDTH=11.479% class="style5"></TD>
<TD WIDTH=0.383% class="style1"></TD>
<TD WIDTH=3.699% class="style1"></TD>
<TD WIDTH=0.383% class="style5"></TD>
<TD WIDTH=6.122% class="style4"></TD>
<TD WIDTH=3.316% class="style1"></TD>
<TD WIDTH=0.383% class="style3"></TD>
<TD WIDTH=1.020% class="style1"></TD>
<TD WIDTH=3.061% class="style1"></TD>
<TD WIDTH=4.081% class="style4"></TD>
<TD WIDTH=1.020% class="style1"></TD>
<TD WIDTH=1.054% class="style1"></TD>
<TD WIDTH=0.986% class="style1"></TD>
<TD WIDTH=0.264% class="style1"></TD>
<TD WIDTH=0.060% class="style1"></TD>
<TD class="style6"></TD>
<TD class="style1"></TD>
<TD WIDTH=0.731% class="style1"></TD>
<TD WIDTH=0.289% class="style1"></TD>
<TD WIDTH=0.383% class="style1"></TD>
<TD WIDTH=0.638% class="style1"></TD>
<TD WIDTH=0.009% class="style1"></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=58> </TD>
<TD ALIGN=RIGHT COLSPAN=5 NOWRAP><FONT SIZE=2 FACE="Times New Roman"></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=8><FONT SIZE=2 FACE="Times New Roman"><B>ANNEXURE  I</B></FONT></TD>
<TD COLSPAN=9> </TD>
<TD COLSPAN=10 ROWSPAN=2><FONT SIZE=2 FACE="Times New Roman"><B>DECLARATION  FORM</B></FONT><FONT SIZE=3 FACE="Times New Roman"><B> </B></FONT></TD>
<TD COLSPAN=2><FONT SIZE=2 FACE="Times New Roman"><B>ORIGINAL</B></FONT></TD>
<TD COLSPAN=3 align="left"><FONT SIZE=2 FACE="Times New Roman"><B><asp:Label ID="Label2" runat="server" Text=""></asp:Label></B></FONT></TD>
    
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=25> </TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=12> </TD>
<TD COLSPAN=22 align="center"Trebuchet MS">(See Rule 10 of Customs Valuation  , 1988) </FONT></TD>
<TD COLSPAN=2 align="center"><FONT SIZE=2 FACE="Times New Roman"><B>DUPLICATE</B></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=12> </TD><TD COLSPAN=40><asp:TextBox runat="server"  BorderStyle="None"></asp:TextBox></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=12> </TD><TD COLSPAN=40> </TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=4><FONT SIZE=2 FACE="Times New Roman">Note :</FONT></TD>
<TD COLSPAN=35 ROWSPAN=2><TABLE CELLSPACING=0>
<TR><TD ALIGN=LEFT><FONT SIZE=2 FACE="Times New Roman">This declaration shall  be not required for goods imported as passenger's Baggage,
</FONT></TD></TR>
<TR><TD ALIGN=LEFT><FONT SIZE=2 FACE="Times New Roman"> goods imported for personal use up to value of Rs 1000/- Samples of no
</FONT></TD></TR>
<TR><TD ALIGN=LEFT><FONT SIZE=2 FACE="Times New Roman">  commercial value, or where the goods are subject to specific rate of Duty
</FONT></TD></TR>
</TABLE>
</TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=7> </TD>
</TR>
<%--<tr valign="top">
<td colspan=5></td>
<td colspan=20><FONT SIZE=2 FACE="Times New Roman">JOBNO</FONT></td>
<td colspan=4><FONT SIZE=2 FACE="Times New Roman">
    <asp:DropDownList ID="ddlJobNo" runat="server" Width="150" 
        AutoPostBack="true" onselectedindexchanged="DropDownList1_SelectedIndexChanged">
    
    </asp:DropDownList>
    </FONT></td>

</tr>--%>

<TR VALIGN=TOP>
<TD COLSPAN=4> &nbsp;</TD>
<TD COLSPAN=21>&nbsp;</TD>
<TD COLSPAN=41>&nbsp;</TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=3> </TD>
<TD COLSPAN=22><FONT SIZE=2 FACE="Times New Roman">1. Importer's Name and Address </FONT></TD><td>:</td>
<TD COLSPAN=35><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtImporter" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=26></TD>
<TD COLSPAN=35 ROWSPAN=2><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtImporterAddress" runat="server" size="100" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=25> </TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=26></TD>
<TD COLSPAN=36 ROWSPAN=2><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtImporterAddress1" runat="server" size="100" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=25> </TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=3> </TD>
<TD COLSPAN=22><FONT SIZE=2 FACE="Times New Roman">2. Supplier's Name and Address </FONT></TD><td>:</td>
<TD COLSPAN=35 ROWSPAN=2><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtSupName" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=25> </TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=26></TD>
<TD COLSPAN=35 ROWSPAN=2><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtSupAddress" runat="server" size="100" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=50><FONT SIZE=1>&nbsp;</FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=26></TD>
<TD COLSPAN=35 ROWSPAN=2><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtSupAddress1" runat="server" size="100" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=50><FONT SIZE=1>&nbsp;</FONT></TD>
</TR>
<TR VALIGN=TOP>
<td colspan=3></td>
<TD COLSPAN=22><FONT SIZE=2 FACE="Times New Roman">3. Name and  Address of  Agent, if any </FONT></TD><td>:</td>
<TD COLSPAN=35 ROWSPAN=2><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtAgentName" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=25> </TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=25></TD>
<TD COLSPAN=35><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtAgentAddress" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">4. Description of Goods </FONT></TD><td>:</td>
<TD COLSPAN=35><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtDescription" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">5. Country of  Origin  </FONT></TD><td>:</td>
<TD COLSPAN=43><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtCountry" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">6. Port  of  Shipment </FONT></TD><td>:</td>
<TD COLSPAN=43><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtPortShip" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">7. AWB/BL  Number and  Date     </FONT></TD><td>:</td>
<TD COLSPAN=40><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtAWBNo" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">8. IGM  Number  and  Date          </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtIGMNo" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">9. Contract Number and  Date        </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtContact" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">10. Nature of  Transaction {Sale, Consignment , Hire, Gift etc }</FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtTransaction" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">11. Invoice Number and Date </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtInvoiceNo" runat="server" size="60" align="left" BorderStyle="None" MaxLength="60"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">12. Invoice Value </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtInvoiceVal" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">13. Terms of  Payment </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtTerms" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">14. Currency of  Payment </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtCurrency" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">15. Exchange  Rate </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtExchange" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">16. Terms of  Delivery </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtTermsDelivery" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">17. Relationship  between  buyer  and  </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtRelationship" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>

<tr><TD COLSPAN=4> </TD><TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman"> seller  [ Rule2  (2)] </FONT></TD></tr>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">18. If  related ,what is the basis of  declared  value  -</FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtDeclaredVal" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">19. Condition or  Restrictions attached  with  the  sale [Rule 4 (2) ]</FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtCondition" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">20. Valuation  Method  Applicable ,</FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtValuation" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
<tr><TD COLSPAN=4> </TD><TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">  (See  Rule 4  to  8 ) </FONT></TD></tr>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">21. Cost  and  Services not  included in the  invoice value  ( Rule 9 ) </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtCost" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(a). Brokerage and Commissions    </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtBrokerage" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(b). Cost of Containers   </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtContainers" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(c). Packing  Cost </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtPacking" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(d). Cost of goods and  services  supplied by the buyer   </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtCostOfGoods" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(e). Royalties and  License  fees    </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtRoyalities" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(f).  Value of  proceeds which accure to  seller   </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtProceeds" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(g). Freight  </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtFreight" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(h). Insurance </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtInsurance" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(i). Loading , Unloading, Handling  charges  </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtLoading" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(j). Landing  charges  </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtLanding" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">(k). Other payments , if any  </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtPayments" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">22. Assessable value in  Rs . </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtAssessable" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">23. Previous Imports of  identical / similar  goods,  if any    </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtPreviousImport" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman"> (a). Bill  of  Entry  Number  and  Date    </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="BOENumber" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman"> (b). IGM  Number  and  Date    </FONT></TD><td>:</td>
<TD COLSPAN=37><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtIgmNumber" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=21><FONT SIZE=2 FACE="Times New Roman">24. Any other  relevant  information  (Attach separate  sheet,  if  necessary )   </FONT></TD><td>:</td>
<TD COLSPAN=17><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtRelevent" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>


<TR VALIGN=TOP>
<TD COLSPAN=25> </TD>
<TD COLSPAN=20><FONT SIZE=2 FACE="Times New Roman"><B>DECLARATION </B></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=50><FONT SIZE=2 FACE="Times New Roman"> 1.  I/We  hereby declare that  the  information  furnished  above  is true ,complete and  correct  in  every respect .</FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=62 ROWSPAN=2><TABLE CELLSPACING=0>

<TR><TD ALIGN=LEFT><FONT SIZE=2 FACE="Times New Roman"> 2.  I/We  also undertake to bring  to the notice of  proper  office  any  particulars which
</FONT></TD></TR>

<TR><TD ALIGN=LEFT><FONT SIZE=2 FACE="Times New Roman">      Subsequently come to my/our knowledge which will have a bearing on valuation .
</FONT></TD></TR>
</TABLE>
</TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=5><FONT SIZE=2 FACE="Times New Roman">Place </FONT></TD><td>:</td>

<TD ALIGN=RIGHT COLSPAN=8 NOWRAP><FONT SIZE=2 FACE="Times New Roman">
    <asp:TextBox ID="txtPlace" runat="server" BorderStyle="None" ClientIDMode="Static"></asp:TextBox></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=5><FONT SIZE=2 FACE="Times New Roman">Date </FONT></TD><td>:</td>
<TD ALIGN=RIGHT COLSPAN=8 NOWRAP><FONT SIZE=2 FACE="Times New Roman">
    <asp:TextBox ID="txtDate" runat="server" BorderStyle="None"></asp:TextBox></FONT></TD>
<TD COLSPAN=10> </TD>
<TD ALIGN=CENTER COLSPAN=9 align="right"><FONT SIZE=3 FACE="Times New Roman"><B>Signatue of Importer</B></FONT></TD>
</TR>
<tr>
<td colspan=2></td>
<%--<td colspan=75 align="left">______________________________________________________________________________________________________________________________________-----------</td>--%>
<td colspan=60 align="left">--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td>
</tr>
<TR VALIGN=TOP>
<TD COLSPAN=18> </TD>
<TD COLSPAN=23><FONT SIZE=2 FACE="Times New Roman"><B><U>FOR  CUSTOMS  HOUSE  USE</U></B></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=3> </TD>
<TD COLSPAN=23><FONT SIZE=2 FACE="Times New Roman">1.  Bill  of  Entry  Number  and  Date </FONT></TD><td>:</td>
<td colspan=4></td>
<TD COLSPAN=2><FONT SIZE=2 FACE="Times New Roman">Dt .</FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=3> </TD>
<TD COLSPAN=23><FONT SIZE=2 FACE="Times New Roman">2.  Valuation  Method  Applied  (See  Rules 4  to  8 ) </FONT></TD><td>:</td>
<TD COLSPAN=15><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtValuationRules" runat="server" size="60" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=3> </TD>
<TD COLSPAN=23><FONT SIZE=2 FACE="Times New Roman">3.  If  Declared  value  not  accepted  ,brief  reasons    --</FONT></TD><td>:</td>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=3> </TD>
<TD COLSPAN=23> <FONT SIZE=2 FACE="Times New Roman">4.  Reference  Number  and  Date of  any previous decisions / ruling    --</FONT></TD><td>:</td>
</TR>

<TR VALIGN=TOP>
<TD COLSPAN=3></td>
<td colspan=23><FONT SIZE=2 FACE="Times New Roman">5.  Value  Assessed :  Rs .</FONT></TD><td>:</td>
<TD COLSPAN=2><FONT SIZE=2 FACE="Times New Roman"><asp:TextBox ID="txtAssessed" runat="server" size="25" align="left" BorderStyle="None"></asp:TextBox></FONT></TD>
<TD ALIGN=left COLSPAN=12 align="left"><FONT SIZE=3 FACE="Times New Roman"><B>A.O (Asistant Collector)</B></FONT></TD>
</TR>

<tr>
<td colspan=2></td>
<%--<td colspan=75 align="left">______________________________________________________________________________________________________________________________________-----------</td>--%>
<td colspan=60 align="left">-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------</td>
</tr>

<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=55><FONT SIZE=2 FACE="Times New Roman">Note : - 1. Declaration form in duplicate duly signed by the Importer should be attached with orignal Bill of  Entry.</FONT></TD>
<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=55><FONT SIZE=2 FACE="Times New Roman">2. In case Order-in-Original (Speaking Order) is required, importer/CHA are requested to apply within 30 days . 
</FONT></TD></TR>
<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
<TD COLSPAN=55><FONT SIZE=2 FACE="Times New Roman">No request on this account  will be considered after 30 days .
</FONT></TD></TR>
</TABLE>
</TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=4> </TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=71><FONT SIZE=1>&nbsp;</FONT></TD>
</TR>
<TR VALIGN=TOP>
<TD COLSPAN=71><FONT SIZE=1>&nbsp;</FONT></TD>
</TR>
</TABLE>
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
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
   
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
  


</body>
 
</html>

