<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Duty_Calculator.aspx.cs"
    Inherits="Duty_Calculator" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import - Duty Calculator</title>
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


     <%--allow Decimal Only--%>
        <script type="text/javascript">
        function isNumber(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 45 && (charCode != 46 || $(this).val().indexOf('.') != -1) &&
                (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>

           <script type="text/javascript">

               function open_jobno() {
               
                   NewWindow1('../Report/Import_DutyCalculator_Rpt_viewer.aspx', 'List', '885', '1024', 'yes');
                   return false
                   //alert(f);                
               }

     </script>

<script type="text/javascript">
    function showDialogue() {

        PageMethods.GetData();

        NewWindow1('../Report/Import_DutyCalculator_Rpt_viewer.aspx', 'List', '885', '1024', 'yes');
        return false

//        alert("Mithra.");
    } 
  </script>

  <script type="text/javascript">

      function Checking_Freight() {
        

          var InvoiceValueINR = document.getElementById("InvoiceValueINR").value;
          var InvoiceValueINR1 = InvoiceValueINR;
          //          alert(InvoiceValueINR1);

          var txtFreightValue = document.getElementById("txtFreight").value;
          var txtInsurance = document.getElementById("txtInsurance").value;

          var txtMISC = document.getElementById("txtMISC").value;
          var txtMISCVal = txtMISC * 100 / 100;
          var txtMISC1 = txtMISC / 100;
          txtMISC.value = txtMISC1;

          var txtLandingCharges1 = (parseFloat(InvoiceValueINR1, 10) + parseFloat(txtFreightValue, 10) + parseFloat(txtInsurance, 10)) * 1 / 100 + txtMISC1;
          txtLandingCharges.value = txtLandingCharges1.toFixed(2);

          var txtAssesableValue1 = (parseFloat(InvoiceValueINR1, 10) + parseFloat(txtFreightValue, 10) + parseFloat(txtInsurance, 10) + parseFloat(txtLandingCharges.value, 10) + parseFloat(txtMISCVal, 10))
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

          var txtCustoms_CessPercentage = document.getElementById("txtCustoms_CessPercentage").value;
          var txtCustoms_Cess1 = (txtBasicDuty1 + txtCVDDuty1 + txtCess1) * txtCustoms_CessPercentage / 100;
          //          var txtCustomcess1digit = txtCustoms_Cess1.toFixed(2);
          txtCustoms_Cess.value = txtCustoms_Cess1.toFixed(2);

          var txtAdditional_DutyPercentage = document.getElementById("txtAdditional_DutyPercentage").value;
          var txtAdditional_Duty1 = (txtAssesableValue1 + txtBasicDuty1 + txtCVDDuty1 + txtCess1 + txtCustoms_Cess1) * txtAdditional_DutyPercentage / 100;
          txtAdditional_Duty.value = txtAdditional_Duty1.toFixed(2);


          var txtTotal_Duty1 = txtBasicDuty1 + txtCVDDuty1 + txtCess1 + txtCustoms_Cess1 + txtAdditional_Duty1;
          txtTotal_Duty.value = txtTotal_Duty1.toFixed(2);

      }
  
  </script>

  <script type="text/javascript">
      function chlval() {


          var txtInvoiceValFC = document.getElementById("txtInvoiceValFC").value;
          var txtExRate = document.getElementById("txtExRate").value;         
          //          var InvoiceValueINR = document.getElementById("InvoiceValueINR").value;
          var InvoiceValueINR1 = txtInvoiceValFC * txtExRate;
          InvoiceValueINR.value = InvoiceValueINR1;
          HiddenField1.value = InvoiceValueINR1;

              var txtFreightINR = document.getElementById("txtFreightINR").value;
              var txtFreight1 = InvoiceValueINR1 * txtFreightINR / 100;
              txtFreight.value = txtFreight1.toFixed(2);



          var txtInsuranceINR = document.getElementById("txtInsuranceINR").value;   
          //          var txtInsurance = document.getElementById("txtInsurance").value;
          var txtInsurance1 = InvoiceValueINR1 * txtInsuranceINR / 100;
          txtInsurance.value = txtInsurance1.toFixed(2);

          var txtMISC = document.getElementById("txtMISC").value;
          var txtMISCVal = txtMISC * 100 / 100;
          var txtMISC1 = txtMISC / 100;
          txtMISC.value = txtMISC1;
//          alert(txtMISC1);

          var txtLandingCharges1 = (InvoiceValueINR1 + txtFreight1 + txtInsurance1) * 1 / 100 + txtMISC1;
          txtLandingCharges.value = txtLandingCharges1.toFixed(2);

          
          var txtAssesableValue1 = InvoiceValueINR1 + txtFreight1 + txtInsurance1 + txtLandingCharges1 + txtMISCVal;
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

          var txtCustoms_CessPercentage = document.getElementById("txtCustoms_CessPercentage").value;
          var txtCustoms_Cess1 = (txtBasicDuty1 + txtCVDDuty1 + txtCess1) * txtCustoms_CessPercentage / 100;
          //          var txtCustomcess1digit = txtCustoms_Cess1.toFixed(2);
          txtCustoms_Cess.value = txtCustoms_Cess1.toFixed(2);

          var txtAdditional_DutyPercentage = document.getElementById("txtAdditional_DutyPercentage").value;
          var txtAdditional_Duty1 = (txtAssesableValue1 + txtBasicDuty1 + txtCVDDuty1 + txtCess1 + txtCustoms_Cess1) * txtAdditional_DutyPercentage / 100;
          txtAdditional_Duty.value = txtAdditional_Duty1.toFixed(2);


          var txtTotal_Duty1 = txtBasicDuty1 + txtCVDDuty1 + txtCess1 + txtCustoms_Cess1 + txtAdditional_Duty1;
          txtTotal_Duty.value = txtTotal_Duty1.toFixed(2);




      }
  </script>

  <script type="text/javascript">
      function Check_BCDValue() {

          alert('1');

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
            <%--<div id="innerbox_MidMain_Transact_popup_new" >
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" >
                       Duty Calculator
                      
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                        
                    </div>
                    
                </div>
           
            </div>--%>
            <div id="innerbox_MidMain_Transact_popup_new" >
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Duty Calculator
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
            </div>
         


            <div id="innerbox_MidMain_Trans_new" style="background-image:none">
                
                <div class="content" id="page-1" style="overflow:scroll;height:430px;width:960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:160px;" >
                         <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            InvoiceValue(FC)
                        </div>
                         
                        <div id="txtcon-m_transaction_pop_gen1" style="padding-left:65px">

                                     <asp:TextBox ID="txtInvoiceValFC" runat="server" MaxLength="15"  AutoPostBack="true"
                                style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                TabIndex="1" CssClass="txtbox_none_Mid_transac_Inv_No" 
                                onkeyup="return chlval();"></asp:TextBox> 
                                
                                </div>

                                <div id="tag_label_transaction_popup_trans_cth_label_tariff">
                                ExRate
                            </div>
                       
                    
                        <div id="txtcon-m_transaction_pop_gen1">

                        <asp:TextBox ID="txtExRate" runat="server"  Text="1" maxlength="5" tabindex="2" AutoPostBack="true"
                                class="txtbox_none_Mid_transac_item_CTH_small" style="direction:rtl" 
                                onkeypress="return blockNonNumbers(this, event, true, false);"  onblur="return chlval();" onkeyup="return chlval();"
                                ></asp:TextBox>
                     
                        </div>
                    </div>

                    

                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            InvoiceValue(INR)
                        </div>
                         
                        <div id="txtcon-m_transaction_pop_gen1" style="padding-left:65px">
                          <asp:TextBox ID="InvoiceValueINR" runat="server" MaxLength="15" ClientIDMode="Static"  AutoPostBack="true"
                          style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                TabIndex="3" CssClass="txtbox_none_Mid_transac_Inv_No" onblur="return chlval();" onkeyup="return chlval();"></asp:TextBox>
                        </div>

                    </div>
                   
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                           Freight(INR)

                        </div>
                        
                        <div id="txtcon-m_transaction_pop_gen1">
                        <asp:TextBox ID="txtFreightINR" runat="server"  maxlength="5" tabindex="4" AutoPostBack="true"  Text="0.00"
                                class="txtbox_none_Mid_transac_item_CTH_small"  
                                onkeypress="return blockNonNumbers(this, event, true, false);" 
                                onblur="return chlval();" onkeyup="return chlval();"></asp:TextBox>%
                        
                            <asp:TextBox ID="txtFreight" runat="server" ClientIDMode="Static" AutoPostBack="true"  Text="0.00" 
                                style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"  
                                CssClass="txtbox_none_Mid_transac_Inv_No" MaxLength="15" TabIndex="5" 
                                 onkeyup="return Checking_Freight();"></asp:TextBox>
                        </div>

                          <div id="magnify_area">
                        </div>

                    </div>
                  
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                           Insurance(INR)
                         
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                        <asp:TextBox ID="txtInsuranceINR" runat="server"  maxlength="5" tabindex="6" AutoPostBack="true"  Text="0.00"
                        class="txtbox_none_Mid_transac_item_CTH_small" 
                        onkeypress="return blockNonNumbers(this, event, true, false);" onblur="return chlval();" onkeyup="return chlval();" ></asp:TextBox>%
                        
                                 <asp:TextBox ID="txtInsurance" runat="server" MaxLength="15" AutoPostBack="true" Text="0.00"
                                    ClientIDMode="Static"  style="direction:rtl" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    TabIndex="7" CssClass="txtbox_none_Mid_transac_Inv_No"  onblur="return Checking_Freight();" onkeyup="return Checking_Freight();" ></asp:TextBox>
                              
                        </div>
                      
                                              
                    </div>

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            MISC(INR)
                        </div>
                        
                        <div id="txtcon-m_transaction_pop_gen1" style="padding-left:65px">
                         <asp:TextBox ID="txtMISC" runat="server" MaxLength="15" style="direction:rtl" ClientIDMode="Static" AutoPostBack="true"
                         onkeypress="return blockNonNumbers(this, event, true, false);"
                      TabIndex="8" CssClass=" txtbox_none_Mid_transac_Inv_No" onkeyup="return Checking_Freight();" ></asp:TextBox>
                        </div>
                      
                                              
                    </div>

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                           Landing Charges(1%)
                            
                        </div>
                        
                        <div id="txtcon-m_transaction_pop_gen1" style="padding-left:65px">
                         <asp:TextBox ID="txtLandingCharges" runat="server" MaxLength="15"  style="direction:rtl"
                           TabIndex="9"   CssClass=" txtbox_none_Mid_transac_Inv_No" 
                                onkeypress="return blockNonNumbers(this, event, true, false);" 
                                BackColor="#E3E3D7"></asp:TextBox>
                        </div>
                      
                         </div>

                          <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                           Assesable Value
                        </div>
                       
                    <div id="txtcon-m_transaction_pop_gen1" style="padding-left:65px">
                         <asp:TextBox ID="txtAssesableValue" runat="server" MaxLength="15" 
                             ClientIDMode="Static"  style="direction:rtl"
                                           TabIndex="10"  CssClass=" txtbox_none_Mid_transac_Inv_No" 
                             onkeypress="return blockNonNumbers(this, event, true, false);" 
                             BackColor="#E3E3D7"></asp:TextBox>
                        </div>
                          </div>
                      

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Basic Duty
                        </div>
                       
                        <div id="txtcon-m_transaction_pop_gen1">
                        <asp:TextBox ID="txtBasicDutyPercentage" runat="server"  value="10" maxlength="5" AutoPostBack="true"
                                tabindex="11" class="txtbox_none_Mid_transac_item_CTH_small" onkeypress="return blockNonNumbers(this, event, true, false);"
                               onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"  ></asp:TextBox>%
                               
                        
                         <asp:TextBox ID="txtBasicDuty" runat="server" MaxLength="15" ClientIDMode="Static" style="direction:rtl"
                                              
                                onkeypress="return blockNonNumbers(this, event, true, false);"  TabIndex="12" 
                                CssClass=" txtbox_none_Mid_transac_Inv_No" BackColor="#E3E3D7"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        </div>
                        <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                           CVD Duty
                        </div>
                     
                    <div id="txtcon-m_transaction_pop_gen1" >
                    <asp:TextBox ID="txtCVDDutyPercentage" runat="server" value="12" maxlength="5" AutoPostBack="true"
                            tabindex="13" class="txtbox_none_Mid_transac_item_CTH_small" onkeypress="return blockNonNumbers(this, event, true, false);"
                           onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"></asp:TextBox>%
                           
                    
                         <asp:TextBox ID="txtCVDDuty" runat="server" MaxLength="15" 
                            ClientIDMode="Static" style="direction:rtl"
                                            
                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="14" 
                            CssClass=" txtbox_none_Mid_transac_Inv_No" BackColor="#E3E3D7"></asp:TextBox>
                        </div>
                            </div>                   
                    

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                         Cess
                        </div>
                        
                        <div id="txtcon-m_transaction_pop_gen1">
                        <asp:TextBox ID="txtCessPercentage" runat="server"  maxlength="35" tabindex="5" AutoPostBack="true"
                                class="txtbox_none_Mid_transac_item_CTH_small"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                 onblur="return Checking_Freight();" onkeyup="return Checking_Freight();" ></asp:TextBox>%
                       
                         <asp:TextBox ID="txtCess" runat="server" MaxLength="15" ClientIDMode="Static"  style="direction:rtl"
                                              
                                onkeypress="return blockNonNumbers(this, event, true, false);"  TabIndex="16" 
                                CssClass=" txtbox_none_Mid_transac_Inv_No" BackColor="#E3E3D7"></asp:TextBox>
                        </div>
                       </div>

                        <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                             Customs Cess
                        </div>
                   <div id="txtcon-m_transaction_pop_gen1">
                   <asp:TextBox ID="txtCustoms_CessPercentage" runat="server" value="3"  AutoPostBack="true"
                           maxlength="5" tabindex="17" class="txtbox_none_Mid_transac_item_CTH_small" 
                           onkeypress="return blockNonNumbers(this, event, true, false);"
                           onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"  ></asp:TextBox>%
                          
                  
                         <asp:TextBox ID="txtCustoms_Cess" runat="server" MaxLength="15" 
                           ClientIDMode="Static" style="direction:rtl"
                                              onkeypress="return blockNonNumbers(this, event, true, false);"
                                                TabIndex="18" 
                           CssClass=" txtbox_none_Mid_transac_Inv_No" BackColor="#E3E3D7"></asp:TextBox>
                        </div>
                          </div>

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                          Additional Duty
                        </div>
                      
                        <div id="txtcon-m_transaction_pop_gen1">
                        <asp:TextBox ID="txtAdditional_DutyPercentage" runat="server"  value="4" AutoPostBack="true"
                                maxlength="5" tabindex="19" class="txtbox_none_Mid_transac_item_CTH_small" 
                                onkeypress="return blockNonNumbers(this, event, true, false);"
                                 onblur="return Checking_Freight();" onkeyup="return Checking_Freight();"  ></asp:TextBox>%
                               
                       
                         <asp:TextBox ID="txtAdditional_Duty" runat="server" MaxLength="15" 
                                ClientIDMode="Static" style="direction:rtl"
                         onkeypress="return blockNonNumbers(this, event, true, false);"
                                                TabIndex="20" CssClass=" txtbox_none_Mid_transac_Inv_No" 
                                BackColor="#E3E3D7"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                         </div>

                         <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                           Total Duty
                        </div>
                      
                    <div id="txtcon-m_transaction_pop_gen1" style="padding-left:65px">
                   

                         <asp:TextBox ID="txtTotal_Duty" runat="server" MaxLength="15" 
                             ClientIDMode="Static"    style="direction:rtl" 
                         onkeypress="return blockNonNumbers(this, event, true, false);"
                                                TabIndex="21" 
                             CssClass=" txtbox_none_Mid_transac_Inv_No" BackColor="#E3E3D7"></asp:TextBox>

                <%--<asp:Button ID="btnShowDialogue" runat="server" Text="Print" 
                           onclick="btnShowDialogue_Click1"   /> --%>

                          <%-- <asp:Button ID="btnShowDialogue" runat="server" Text="Print" CssClass="print_btn"
                            OnClientClick="return open_jobno();" 
                              /> --%> 

                               <asp:Button ID="btnShowDialogue" runat="server" Text="Print" CssClass="print_btn"
                            OnClientClick="showDialogue();" 
                              /> 

                             
                     <%--<input id="Button2" type="button" value="print" CssClass="print_btn" onclick="showDialogue()" />
--%>
          

               </div>                              
                  </div>                           
                    </div>
                        </div>
                    
                    

             <div id="innerbox_MidMain_bot_transact_invoice" style="margin-top: 215px;">
                  
                </div>

                </div>
                <div class="content" id="page-2" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_export_invoice_Iframe">
                    </iframe>
                </div>
                <div class="content" id="page-3" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_export_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-4" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_igm_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-5" style="display:none;">
                  
                </div>
                <div class="content" id="page-6" style="display:none;">
                   
                </div>
                <div class="content" id="page-7" style="display:none;">
                   
                </div>
                <div class="content" id="page-8" style="display:none;">
                    
                </div>
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
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

             function open_jobno() {

             document.getElementById("<%=btnShowDialogue.ClientID%>").click();
                     NewWindow1('../Report/Import_DutyCalculator_Rpt_viewer.aspx', 'List', '885', '1094', 'yes');
                     return false
                     //alert(f);                
             }

     </script>

 <%--    <script type="text/javascript">

         function open_jobno() {

             if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                     NewWindow1('../Report/Import_Duty_Intimation_Rpt_Viewer.aspx?jobno=' + f + '', 'List', '885', '1024', 'yes');

                     //opennew_Import_report(f);
                     return false
                     //alert(f);
                 }
             }

         }
     </script>--%>
</body>
</html>
