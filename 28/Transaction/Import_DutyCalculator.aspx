<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_DutyCalculator.aspx.cs" Inherits="Import_DutyCalculator" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

        <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
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


    <script type="text/javascript">

        function calc_Insurance() {
            var Freight_val = document.getElementById("txtFreight").value;
            var txtInsuranceINR = document.getElementById("txtInsuranceINR").value;
            var txtInsurance = document.getElementById("txtInsurance").value;
            var txtMISC = document.getElementById("txtMISC").value;

            var insurance = Freight_val + txtMISC;          
        }
    </script>


     <script type="text/javascript">

         function Checking_Freight() {

             var txtInvoiceValFC = document.getElementById("txtInvoiceValFC").value;

             if (txtInvoiceValFC != '') {

                 var txtExRate = document.getElementById("txtExRate").value;
                 //          var InvoiceValueINR = document.getElementById("InvoiceValueINR").value;
                 var InvoiceValueINR1 = txtInvoiceValFC * txtExRate;
                 InvoiceValueINR.value = InvoiceValueINR1;

                 var txtFreightValue = document.getElementById("txtFreight").value;
                 var txtInsuranceValue = document.getElementById("txtInsurance").value;


                 var txtMISC = document.getElementById("txtMISC").value;
                 if (txtMISC != '') {
                     var txtMISCVal = txtMISC * 100 / 100;
                     var txtMISC1 = txtMISC / 100;
                     txtMISC.value = txtMISC1;
                 }
                 else {
                     txtMISCVal = 0.00;
                     txtMISC.value = txtMISC1;
                     $('#txtMISC').val(0.00);
                 }

//                 var txtMISC = document.getElementById("txtMISC").value;
//                 if (txtMISC != '') {
//                 }
//                 else {
//                     txtMISC = 0.00;
//                     txtMISC.value = txtMISC;
//                 }


                 var txtFreightINR = document.getElementById("txtFreightINR").value;
                 if (txtFreightINR == '0.00' || txtFreightINR == '') {
                     if (txtFreightValue != '') {
                     }
                     else {
                         txtFreightValue = 0.00;
                     }
                 }
                 else {
                     var txtFreight1 = (parseFloat(InvoiceValueINR1, 10) + parseFloat(txtMISCVal, 10)) * txtFreightINR / 100;
                     txtFreight.value = txtFreight1.toFixed(2);
                 }

                 var txtInsuranceINR = document.getElementById("txtInsuranceINR").value;

                 if (txtInsuranceINR == '0.00' || txtInsuranceINR == '') {
                     if (txtInsuranceValue != '') {
                         var txtInsurance1 = txtInsuranceValue;
                     }
                     else {
                         var txtInsurance1 = 0.00;
                     }
                 }
                 else {
                     var txtInsurance1 = (parseFloat(InvoiceValueINR1, 10) + parseFloat(txtMISCVal, 10)) * txtInsuranceINR / 100;
                     $('#txtInsurance').val(txtInsurance1.toFixed(2));
                 }
               

////                 var txtLandingCharges1 = (parseFloat(InvoiceValueINR1, 10) + parseFloat(txtFreightValue, 10) + parseFloat(txtInsurance, 10)) * 1 / 100 + txtMISC1;
////                 txtLandingCharges.value = txtLandingCharges1.toFixed(2);

                 var txtAssesableValue1 = (parseFloat(InvoiceValueINR1, 10) + parseFloat(txtFreightValue, 10) + parseFloat(txtInsurance1, 10) + parseFloat(txtMISCVal, 10))
                 txtAssesableValue.value = txtAssesableValue1.toFixed(2);

                 var txtBasicDutyPercentage = document.getElementById("txtBasicDutyPercentage").value;
                 var txtBasicDuty1 = txtAssesableValue1 * txtBasicDutyPercentage / 100;
                 txtBasicDuty.value = txtBasicDuty1.toFixed(2);

                 var txtCVDDutyPercentage = document.getElementById("txtCVDDutyPercentage").value;
                 var txtCVDDuty1 = (txtAssesableValue1 + txtBasicDuty1) * txtCVDDutyPercentage / 100;
                 txtCVDDuty.value = txtCVDDuty1.toFixed(2);

                 var txtCessPercentage = document.getElementById("txtCessPercentage").value;
                 var txtCess1 = (txtAssesableValue1 + txtBasicDuty1) * txtCessPercentage / 100;
                 txtCess.value = txtCess1.toFixed(2);

                 var txtCess_OnCVDPercentage = document.getElementById("txtCess_OnCVD_Percentage").value;
                 var txtCessOnCVD1 = (txtCVDDuty1 + txtCess1) * txtCess_OnCVDPercentage / 100;
                 txtCessOnCVD.value = txtCessOnCVD1.toFixed(2);
              

                 var txtCustoms_CessPercentage = document.getElementById("txtCustoms_CessPercentage").value;
                 var txtCustoms_Cess1 = (txtBasicDuty1 + txtCVDDuty1 + txtCess1 + txtCessOnCVD1) * txtCustoms_CessPercentage / 100;
                 //          var txtCustomcess1digit = txtCustoms_Cess1.toFixed(2);
                 txtCustoms_Cess.value = txtCustoms_Cess1.toFixed(2);

//                 var txtAdditional_DutyPercentage = document.getElementById("txtAdditional_DutyPercentage").value;
//                 var txtAdditional_Duty1 = (txtAssesableValue1 + txtBasicDuty1 + txtCVDDuty1 + txtCess1 + txtCustoms_Cess1 + txtCessOnCVD1) * txtAdditional_DutyPercentage / 100;
//                 txtAdditional_Duty.value = txtAdditional_Duty1.toFixed(2);


                 var txtTotal_Customs_Duty1 = txtBasicDuty1 + txtCVDDuty1 + txtCess1 + txtCustoms_Cess1 + txtCessOnCVD1;
                 txtTotal_Customs_Duty.value = txtTotal_Customs_Duty1.toFixed(2);

                 var txt_totIGST_Rate= document.getElementById("txt_totIGST_Rate").value;
                 var txt_totalIGST_Duty1 = (txtAssesableValue1 + txtTotal_Customs_Duty1) * txt_totIGST_Rate / 100;
                 txt_totalIGST_Duty.value = txt_totalIGST_Duty1.toFixed(2);

                 var txt_tot_Compensation_Rate = document.getElementById("txt_tot_Compensation_Rate").value;
                 var txt_tot_Compensation_Rate1 = (txtAssesableValue1 + txtTotal_Customs_Duty1) * txt_tot_Compensation_Rate / 100;
                 txt_tot_Compensation_Duty.value = txt_tot_Compensation_Rate1.toFixed(2);


                 var txtTotal_Duty1 = txtBasicDuty1 + txtCVDDuty1 + txtCess1 + txtCustoms_Cess1 + txtCessOnCVD1 + txt_totalIGST_Duty1 + txt_tot_Compensation_Rate1;
                 txtTotal_Duty.value = txtTotal_Duty1.toFixed(2);
             }
             else {
                 document.getElementById('txtInvoiceValFC').focus();
//                 txtInvoiceValFC.Focus();
                 alert('Enter Invoice Value');
                 
                //                 txtExRate.value = 1;
                 document.getElementById("txtExRate").value = "1";
                 document.getElementById("txtBasicDutyPercentage").value = "10";
                 document.getElementById("txtCVDDutyPercentage").value = "0";
                 document.getElementById("txtCessPercentage").value = "";
                 document.getElementById("txtCustoms_CessPercentage").value = "3";
////                 document.getElementById("txtAdditional_DutyPercentage").value = "4";

//                 txtBasicDutyPercentage.value = 10;
//                 txtCVDDutyPercentage.value = "12";
//                 txtCessPercentage.value = "";
//                 txtCustoms_CessPercentage.value = "3";
//                 txtAdditional_DutyPercentage.value = "4";
                 
             }
         }
  
  </script>

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

</head>
<body>
    <form id="form1" runat="server">

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

    <div>
    
    <div id="s" runat="server" align="center">

<table>
  <tr>
   <td style="height:10px"></td>
   
    </tr>


<td style="width:1040px; height:35px; margin:auto; background-image:url(images/inner_popup1_top.gif); background-repeat:repeat-x; font-family:Arial;font-size:13px; font-weight:bold; color:#2b2b2b; text-align:center; line-height:40px; margin-top:1px;" >
<%--<td>--%>
 Duty Calculator                     
</td>

</tr>
</table>

    <table>
    <tr>
   <td style="height:10px"></td>
    </tr>
    <tr>
    <td width="10px"></td>
    <td width="10px"></td><td width="10px"></td><td width="10px"></td><td width="10px"></td><td width="10px"></td><td width="10px"></td>
    <td width="10px"></td><td width="10px"></td><td width="10px"></td><td width="10px"></td><td width="10px"></td><td width="10px"></td>
     <td width="10px"></td><td width="10px"></td><td width="10px"></td><td width="10px"></td><td width="10px"></td><td width="10px"></td>
  
    </tr>
    <tr>
    <td colspan="4"></td>
    <td>
    </td><td>
    </td>
    </tr>

    <tr>
    <td colspan="2"></td>
    <%--<td>InvoiceValue(FC)</td>--%>
    <td>
    <div id="tag_label_adcode">InvoiceValue(FC)</div>   
    </td>
    <td colspan="6"></td>
     <td>
    <asp:TextBox ID="txtInvoiceValFC" runat="server"   MaxLength="15" TabIndex="1"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None" style="direction:rtl"
            onkeypress="return blockNonNumbers(this, event, true, false);" onkeyup="return Checking_Freight();"></asp:TextBox>  
    </td>
    <td></td>
     <%--<div id="tag_label_adcode">ExRate</div>   --%>
    <td style="font-family:Arial; font-size:13px;">ExRate</td><td>:</td>
    <td><asp:TextBox ID="txtExRate" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" BorderStyle="None" Text="1" MaxLength="5" TabIndex="1"
    style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" onkeyup="return Checking_Freight();"></asp:TextBox></td>
            
    </tr>

      <tr><td></td></tr>
        <tr>
            <td colspan="2">
            </td>
            <td style="font-family: Arial; font-size: 13px;">
                InvoiceValue(INR)
            </td>
            <td colspan="6">
            </td>
            <td>
                <asp:TextBox ID="InvoiceValueINR" runat="server" MaxLength="15" TabIndex="2" CssClass="txtbox_none_Mid_transac_Inv_No"
                    BorderStyle="None" Style="direction: rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
            </td>
        </tr>

      <tr><td></td></tr>
        <%--<tr><td></td></tr>--%>

    <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px; width:50px;">Freight(INR)</td> 
    <td colspan="6" align="left"><asp:TextBox ID="txtFreightINR" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" Text="0.00" MaxLength="5" TabIndex="3"
    style="direction:ltr" onkeypress="return blockNonNumbers(this, event, true, false);" BorderStyle="None" Width="38px" onkeyup="return Checking_Freight();"></asp:TextBox>%</td>
 <%--    <td style="width:20px">%</td>--%>
     <td >
    <asp:TextBox ID="txtFreight" runat="server" style="direction:rtl" MaxLength="15" TabIndex="4"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None" onkeypress="return blockNonNumbers(this, event, true, false);" onkeyup="return Checking_Freight();"></asp:TextBox>
    </td>
    </tr>

      <tr><td></td></tr>


        <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;">MISC(INR)</td> 
    <td colspan="6"></td>
     <td>
  
    <asp:TextBox ID="txtMISC" runat="server" MaxLength="15" TabIndex="4" Text="0"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"
            style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" onkeyup="return Checking_Freight();"></asp:TextBox>  
    </td>
    </tr>

     <tr><td></td></tr>
        <%--<tr><td></td></tr>--%>

    <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;">Insurance(INR)</td> 
    <td colspan="6" align="left"><asp:TextBox ID="txtInsuranceINR" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" Text="0.00" MaxLength="5" TabIndex="5"
    style="direction:ltr" onkeypress="return blockNonNumbers(this, event, true, false);" BorderStyle="None" Width="38px" onkeyup="return Checking_Freight();"></asp:TextBox>%</td>
     <td >
    <asp:TextBox ID="txtInsurance" runat="server" style="direction:rtl" MaxLength="15" TabIndex="6" 
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None" onkeypress="return blockNonNumbers(this, event, true, false);" onkeyup="return Checking_Freight();"></asp:TextBox>
    </td>
    </tr>

      <tr><td></td></tr>
        <%--<tr><td></td></tr>--%>

   <%-- <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;">MISC(INR)</td> 
    <td colspan="6"></td>
     <td>
  
    <asp:TextBox ID="txtMISC" runat="server" MaxLength="15" TabIndex="7"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"
            style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" onkeyup="return Checking_Freight();"></asp:TextBox>  
    </td>
    </tr>--%>

     <%-- <tr><td></td></tr>--%>
        <%--<tr><td></td></tr>--%>
    
   <%-- <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;">Landing Charges</td> 
    <td colspan="6"><asp:TextBox ID="txtLandingpercent" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" BorderStyle="None" Width="38px" Text="1" 
   TabIndex="8" style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>%</td>
     <td>
    <asp:TextBox ID="txtLandingCharges" runat="server" TabIndex="8"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"
            style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>  
    </td>
    </tr>--%>
    <tr><td></td></tr>
     <%--<tr><td></td></tr>--%>
 
     <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;">Assesable Value</td> 
    <td colspan="6"></td>
     <td>
    <asp:TextBox ID="txtAssesableValue" runat="server" TabIndex="9"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"
            style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>  
    </td>
    </tr>

     <tr><td></td></tr>
   <%-- <tr><td></td></tr>--%>

     <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;">Basic Duty</td> 
    <td colspan="6" align="left"><asp:TextBox ID="txtBasicDutyPercentage" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" BorderStyle="None" Width="38px" Text="10"
       TabIndex="10" style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="5"
        onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"></asp:TextBox>%</td>
     <td >
    <asp:TextBox ID="txtBasicDuty" runat="server" TabIndex="11"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"
            style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
    </td>
    </tr>

    <tr><td></td></tr>
      <%--<tr><td></td></tr>--%>

    <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;"> CVD Duty</td> 
    <td colspan="6" align="left"><asp:TextBox ID="txtCVDDutyPercentage" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" BorderStyle="None" Width="39px" Text="0"
    TabIndex="12" style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="5"
    onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"></asp:TextBox>%</td>
     <td >
    <asp:TextBox ID="txtCVDDuty" runat="server" 
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None" TabIndex="13"
            style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
    </td>
    </tr>

     <tr><td></td></tr>
      <%-- <tr><td></td></tr>--%>

        

    <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;">Cess</td> 
    <td colspan="6" align="left"><asp:TextBox ID="txtCessPercentage" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" BorderStyle="None"
    style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" Width="39px" TabIndex="14" MaxLength="5"
    onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"></asp:TextBox>%</td>
     <td >
    <asp:TextBox ID="txtCess" runat="server" 
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None" TabIndex="15"
            style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
    </td>
    </tr>

     <tr><td></td></tr>
      <%-- <tr><td></td></tr>--%>

        <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;"> Edu. Cess On Cvd</td> 
    <td colspan="6" align="left"><asp:TextBox ID="txtCess_OnCVD_Percentage" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" BorderStyle="None" Width="39px" Text=""
    TabIndex="16" style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="5"
    onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"></asp:TextBox>%</td>
     <td >
    <asp:TextBox ID="txtCessOnCVD" runat="server" 
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None" TabIndex="17"
            style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
    </td>
    </tr>

     <tr><td></td></tr>
      <%-- <tr><td></td></tr>--%>

     <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px; height:40px;">Customs Cess</td> 
    <td colspan="6" align="left"><asp:TextBox ID="txtCustoms_CessPercentage" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" Text="3"
    style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" BorderStyle="None" Width="39px" TabIndex="18" MaxLength="5"
    onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"></asp:TextBox>%</td>
     <td >
    <asp:TextBox ID="txtCustoms_Cess" runat="server" TabIndex="19"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"  MaxLength="5" style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
    </td>
    </tr>

     <tr><td></td></tr>
     
     <%-- IGST FILEDS ADDED BY CHITHRA 04-10-2017 --%>

             <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;">Total Customs Duty</td> 
    <td colspan="6"></td>

     <td>
    <asp:TextBox ID="txtTotal_Customs_Duty" runat="server" style="direction:rtl" TabIndex="20"  Font-Bold="true" ReadOnly="true"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"></asp:TextBox>  
    </td>
    </tr>
  <tr><td></td></tr>

     <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;">IGST Duty</td> 
    <td colspan="6" align="left"><asp:TextBox ID="txt_totIGST_Rate" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small"  Text="0"
    style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" BorderStyle="None" Width="39px" TabIndex="21" MaxLength="5"
    onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"></asp:TextBox>%</td>
     <td >
    <asp:TextBox ID="txt_totalIGST_Duty" runat="server" TabIndex="22"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"  MaxLength="5" style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
    </td>
    </tr>

     <tr><td></td></tr>

     <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px; height:30px;">Compensation Duty</td> 
    <td colspan="6" align="left"><asp:TextBox ID="txt_tot_Compensation_Rate" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" Text="0"
    style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" BorderStyle="None" Width="39px" TabIndex="23" MaxLength="5"
    onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"></asp:TextBox>%</td>
     <td >
    <asp:TextBox ID="txt_tot_Compensation_Duty" runat="server" TabIndex="24"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"  MaxLength="5" style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
    </td>
    </tr>

     <tr><td></td></tr>

       <%--<tr><td></td></tr>--%>

     <%--<tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px;">Additional Duty</td> 
    <td colspan="6" align="left"><asp:TextBox ID="txtAdditional_DutyPercentage" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" Text="4"
    style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);" BorderStyle="None" Width="39px" TabIndex="18" MaxLength="5"
    onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"></asp:TextBox>%</td>
     <td >
    <asp:TextBox ID="txtAdditional_Duty" runat="server" style="direction:rtl" TabIndex="19"
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"></asp:TextBox>
    </td>
    </tr>--%>

     <tr><td></td></tr>
       <%--<tr><td></td></tr>--%>

        <tr>
    <td colspan="2"></td>
    <td style="font-family:Arial; font-size:13px; font-weight:bold;">Total Duty</td> 
    <td colspan="6"></td>

     <td>
    <asp:TextBox ID="txtTotal_Duty" runat="server" style="direction:rtl" TabIndex="25" Font-Bold="true" 
            CssClass="txtbox_none_Mid_transac_Inv_No" BorderStyle="None"></asp:TextBox>  
    </td>
    </tr>
  <tr><td></td></tr>
    <tr><td></td></tr>
      <tr><td></td></tr>
        <tr><td></td></tr>
          <tr><td></td></tr>
            <tr><td></td></tr>
    </table>
    
    </div>
    <div id="aa" runat="server"></div>

    <div id="ss" runat="server" align="center" style="width:50px">
    <table>

    <tr>
    <td>
   
    <asp:Button ID="btn_print" runat="server" Text="Print" CssClass="print_btn"
                           onclick="btn_print_Click"/>
                              
    </td>
    <td>
    <input type="submit" value="Submit" class="scancel" onclick="win_hide();parent.adcodewindow.hide();return false;"
                                            id="btnCancel" tabindex="55" />
    </td>
    </tr>
    </table>
     
    </div>
    </div>

      
    </form>

    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
     <%--<script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>--%>
    <script src="../js/Validation.js" type="text/javascript"></script>
  
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
</body>
</html>
