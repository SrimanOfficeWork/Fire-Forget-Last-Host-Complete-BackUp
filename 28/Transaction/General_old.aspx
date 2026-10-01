<%@ Page Language="C#" AutoEventWireup="true" CodeFile="General_old.aspx.cs" Inherits="Transaction_General_New" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

   <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
<link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
<link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
<script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
<link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
<script type="text/javascript" src="../modalfiles/modal.js"></script>
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
  <%-- <script type="text/javascript" src="../js/jquery.min.js"></script>
<script  type="text/javascript" src="../js/jquery-ui.min.js"></script>--%>
<script type="text/javascript" src="../js/slide.js"></script>
<script type="text/javascript" src="../js/jscolor.js"></script>
   
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
     <script src="../js/listpopup.js" type="text/javascript"></script>
   <%-- <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>--%>

   <%-- <script src="../js/checkboxJScript.js" type="text/javascript"></script>--%>
    <%--<script type="text/javascript" src="https:////www.google.com/jsapi"></script>--%>
  

  <%--<script src="https:////ajax.googleapis.com/ajax/libs/jquery/1.7.1/jquery.min.js"></script>--%>
<script src="../js/checkboxJScript.js" type="text/javascript"></script>

<script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
     <script src="../js/Validation.js" type="text/javascript"></script>
      
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
   
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
     <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
  
	
    <script >
        function close_button() {
            //document.getElementById("btnCancel").click();
            document.getElementById("General").click();
        }
        window.onload = happycode;
        function happycode() {
            document.getElementById("General").click();
        }
</script>
      <!-- VALIDATION SCRIPT -->
       <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
        <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
      <%-- <script src="../Validation Files/jquery-1.js" type="text/javascript">
        </script>--%>
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
        </script>    
  <script type="text/javascript">
      $('#btnNew').click(function () {
          $('#form1').validationEngine('detach');
      });
      $('#btnDelete').click(function () {
          $('#form1').validationEngine('detach');
      });
     

</script>

 
</head>
<body >
    <form id="form1" runat="server">
    
   
   
   <script type="text/javascript">
       function updateTextbox() {
           var txt1 = document.getElementById('txtCountryName');
           var txt2 = document.getElementById('txtCountryShipment');
           txt2.value = txt1.value;
       }

       function updateTextbox2() {

            document.getElementById('txtPortShipment').value=document.getElementById('txtPortOrigin').value;

        }
        function updateTextbox3() {

            document.getElementById('txtPortOrigin').value = document.getElementById('txtPortShipment').value;

        }


    
</script>


     <asp:ScriptManager ID="ScriptManager1" runat="server"  EnablePartialRendering="false" EnablePageMethods="true">


    </asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
   
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
        
   <div id="innerbox_MidMain_Transact_popup_new" >
        <div id="tag_srcinner1_new">
            <div id="editbu">
                <a href="#" class="edit"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1">
                Transaction
                 
                </div>
                  <div id="popupwindow_closebut_right_new"><input type="close" value="Submit" class="clsicon_new"  onclick="parent.adcodewindow.hide()" /> </div>
                <%--<div id="mainmastop2container_lft_tag2_txt1" style="float:right;">
               <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide()" /></div>
                </div>--%>
        </div>
      <div id="tag_transaction_inner_new">
           
                <div id="tag_Exchange_lft_in1_new1">
                    <div id="tag_label_transaction_Src_new">
                        Job No
                    </div>
                   
                    <div id="txtcon-m_transaction_code">
                        
                          <asp:TextBox ID="txtJobNo" runat="server" MaxLength="10"  CssClass="txtbox_none_Mid_transac_code_new"
                        ReadOnly="True" TabIndex="1" ClientIDMode="Static"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="draw"
                        ErrorMessage="*" ForeColor="Red" ControlToValidate="txtJobNo"></asp:RequiredFieldValidator>
                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator10"  ValidationGroup="hawb" runat="server" ErrorMessage="min 1" ControlToValidate="txtJobNo" ValidationExpression="[^\s]{0>}"></asp:RegularExpressionValidator>--%>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtJobNo"
                        FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></cc1:FilteredTextBoxExtender>
                    </div>
                   
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                   
                    <div id="tag_label_transaction_date">
                        Job Date
                    </div>
                   
                    <div id="txtcon-m_transaction_code">
                       
                          <asp:TextBox ID="txtJobDate" runat="server" 
                              CssClass="txtbox_none_Mid_transac_code_new" MaxLength="10" TabIndex="2" ></asp:TextBox>
                           
                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate" 
                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True"></cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate" PopupButtonID="txtJobDate" 
                                            Format="dd/MM/yyyy" ></cc1:CalendarExtender>

                  <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  CssClass="formErrorContent"
                        runat="server" ControlToValidate="txtJobDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date" Display="None"></asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator1" PopupPosition="Right" ></cc1:ValidatorCalloutExtender>
                   --%>
                        
                    </div>
                   
                      <div id="tag_label_transaction_popup_mode_empty">
                    </div>
                   <%-- <div id="txt-container_transaction_list_src2">--%>
                        <div id="tag_label_transaction_Src_longlabel">
                            Transport Mode</div>
                       
                        <div id="txtcon-m_transaction_mode">
                        <asp:DropDownList ID="ddlTransportMode" runat="server" 
                                CssClass="listtxt_transac_mode_new" TabIndex="3">
                    </asp:DropDownList>
                          
                        </div>
                       
                   <%-- </div>--%>

                   
                    <div id="tag_label_transaction_popup_no_empty">
                    </div>
                    <div id="tag_label_transaction_Src">
                        BE No
                    </div>
                   
                    <div id="txtcon-m_transaction_code">
                        
                          <asp:TextBox ID="TextBox3" runat="server" MaxLength="10"  CssClass="txtbox_none_Mid_transac_code_new"
                        ReadOnly="True" TabIndex="4" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="draw"
                        ErrorMessage="*" ForeColor="Red" ControlToValidate="txtJobNo"></asp:RequiredFieldValidator>
                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator10"  ValidationGroup="hawb" runat="server" ErrorMessage="min 1" ControlToValidate="txtJobNo" ValidationExpression="[^\s]{0>}"></asp:RegularExpressionValidator>--%>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtJobNo"
                        FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></cc1:FilteredTextBoxExtender>
                    </div>

                    <div id="tag_label_transaction_popup_no_empty">
                    </div>
                   

                 
                    <%--   <div id="tag_label_transaction_Src">
                        BE Date
                    </div>
                    <div id="txtcon_l_Exchange">
                    </div>
                    <div id="txtcon-m_transaction_code">
                    <asp:TextBox ID="txtBEDate" runat="server" Enabled="False" 
                            CssClass="txtbox_none_Mid_transac_code" MaxLength="10" TabIndex="4"
                       ></asp:TextBox>
                      
                    </div>
                    <div id="txtcon-r_Exchange">
                    </div>--%>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty_gen"></div>
                <div id="tag_Exchange_lft_in1_new1">
                    <div id="tag_label_transaction_Src_new">
                        BE Type</div>
                   
                    <div id="txtcon-m_transaction_code">
                        
                          <asp:DropDownList ID="ddlBEType" runat="server" 
                              CssClass="listtxt_transac_mode_new" TabIndex="5">
                          </asp:DropDownList>
                  </div>
                   
                    <div id="tag_label_transaction_popup_IGM2_empty_Exbond" >
                    <a href="#" id="lnkbtn_Exbond" runat="server" style="display:none;" onclick="open_Exbond_Details();return false;">Ex</a>
                     <%--  <asp:LinkButton id="lnk_btn_Exbond" runat="server"  >Ex</asp:LinkButton>--%>
                    </div>

                   
                    <div id="tag_label_transaction_date">
                        Custom House</div>
                   
                    <div id="txtcon-m_transaction_code">
                       
                          <asp:TextBox ID="txtCustomsHouse" runat="server" 
                              CssClass="txtbox_none_Mid_transac_code_new" MaxLength="10" TabIndex="6" ClientIDMode="Static"></asp:TextBox>
                           
                  

                  <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1"  CssClass="formErrorContent"
                        runat="server" ControlToValidate="txtJobDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                        ErrorMessage="Invalid Date" Display="None"></asp:RegularExpressionValidator>
                        <cc1:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator1" PopupPosition="Right" ></cc1:ValidatorCalloutExtender>
                   --%>
                        
                    </div>
                   <div id="magnify_area" >
                          <a href="#" class="magnfy" onclick="OpenPopupCustom_House(); return false" tabindex="7"></a>
                     
                      </div>

                      <div id="tag_label_transaction_popup_mode_empty">
                    </div>
                   <%-- <div id="txt-container_transaction_list_src2">--%>
                       
                   <%-- </div>--%>

                   
                    <div id="tag_label_transaction_popup_no_empty_new">
                    </div>
                   <div id="tag_label_transaction_Src">
                        BE Date
                    </div>
                   
                    <div id="txtcon-m_transaction_code">
                        
                          <asp:TextBox ID="TextBox1" runat="server" MaxLength="10"  CssClass="txtbox_none_Mid_transac_code_new"
                        ReadOnly="True" TabIndex="8" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="draw"
                        ErrorMessage="*" ForeColor="Red" ControlToValidate="txtJobNo"></asp:RequiredFieldValidator>
                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator10"  ValidationGroup="hawb" runat="server" ErrorMessage="min 1" ControlToValidate="txtJobNo" ValidationExpression="[^\s]{0>}"></asp:RegularExpressionValidator>--%>
                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtJobNo"
                        FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></cc1:FilteredTextBoxExtender>
                    </div>


                 
                    <%--   <div id="tag_label_transaction_Src">
                        BE Date
                    </div>
                    <div id="txtcon_l_Exchange">
                    </div>
                    <div id="txtcon-m_transaction_code">
                    <asp:TextBox ID="txtBEDate" runat="server" Enabled="False" 
                            CssClass="txtbox_none_Mid_transac_code" MaxLength="10" TabIndex="4"
                       ></asp:TextBox>
                      
                    </div>
                    <div id="txtcon-r_Exchange">
                    </div>--%>
                </div>
         </div>
    </div>
    <div id="innerbox_MidMain_Trans_new">
        <ol id="toc_new">
            <li><a href="#page-1" onclick="tab_page1();" id="General" ><span>General</span></a></li>
            <li><a href="#page-2" onclick="tab_page2();" id="IGM"><span>IGM</span></a></li>
            <li><a href="#page-3" onclick="tab_page3();" id="INVOICE"><span>Invoice</span></a></li>
            <li><a href="#page-4" onclick="tab_page4();" id="ITEM"><span>Product</span></a></li>
            <li><a href="#page-5" target="maineroyal" onclick="tab('0');"><span>Docket</span></a></li>
            <li><a href="#page-6" target="maineroyal" onclick="tab('0');"><span>Tracking</span></a></li>
            <li><a href="#page-7" target="maineroyal" onclick="tab('0');"><span>Submission</span></a></li>
            <li><a href="#page-8" target="maineroyal" onclick="tab('0');"><span>Job History</span></a></li>
        </ol>
      
        <div class="content" id="page-1" >
            <div id="area_transac_container_genral" >

              <asp:Panel ID="Panel1" runat="server" >
                <div id="pop_text_area_transac_popup_inn_container_new">
                    <div id="pop_text_area_transac_popup_inn_container_left_new">
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                Importer Name</div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                               
                                
                            <asp:TextBox ID="txtImporterName" runat="server" MaxLength="40" onblur="ChangeCase(this);" 
                            ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new" 
                                     Onkeypress="return numcharspl1(event)" TabIndex="7" 
                                    ></asp:TextBox>
                             </div>
                            
                            <div id="magnify_area">
                          <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporter_Master(''); return false" tabindex="8">
                          </a>
                                
                                               </div><a href="#" onclick="jQuery('#form1').validationEngine('hideAll');openclient_Masternew(); return false">New</a>
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                IEC_No
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen1">
                             
                                 
                                 <asp:TextBox ID="txtIECNo" runat="server" MaxLength="10" 
                            ClientIDMode="Static" CssClass="validate[required,minSize[10],custom[number]] txtbox_none_Mid_transac_pop_gen" TabIndex="9" onkeypress="return pin(event)"></asp:TextBox>
                          
                            </div>
                           
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                Branch_SL_No</div>
                           
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                
                                 
                             <asp:TextBox ID="txtBranchNo" runat="server" MaxLength="3" CssClass="validate[required,custom[number]]  txtbox_none_Mid_transac_pop_gen_srcic"
                            ClientIDMode="Static" TabIndex="10" onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                            
                             <div id="magnify_area">
                          <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporter_Master_BranchSlno('Import_Branch');" tabindex="11"></a>
                                
                                               </div>
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                Address</div>
                           
                            <div id="txtcon-m_transaction_pop_gen1">
                               
                              
                               <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" 
                            ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen" TabIndex="12"></asp:TextBox>
                        
                                    </div>
                           
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1">
                               
                            
                             <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" 
                            ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen" TabIndex="13"></asp:TextBox>

                            </div>
                           
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1">
                               
                                
                           <asp:TextBox ID="txtAddress3" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen" 
                            ClientIDMode="Static" TabIndex="14" ></asp:TextBox>
                           
                            </div>
                           
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen1">
                                
                             
                      <asp:TextBox ID="txtAddress4" runat="server"  
                                    MaxLength="35"  ClientIDMode="Static"
                            CssClass="txtbox_none_Mid_transac_pop_gen" TabIndex="15" ></asp:TextBox>


                            </div>
                            
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen1">
                                
                             

                             <asp:TextBox ID="txtAddress5" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_pop_gen"
                            ClientIDMode="Static" TabIndex="16" ></asp:TextBox>


                        <%--<cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtAddress5"
                            FilterMode="InvalidChars" 
                            InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></cc1:FilteredTextBoxExtender>--%>
                            </div>
                           
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                Country Origin
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                
                                  

                                  <asp:TextBox ID="txtCountryName" runat="server" MaxLength="50" onkeyup="ChangeCase(this);"  onblur="ChangeCase(this);updateTextbox();"  CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"
                              ClientIDMode="Static" TabIndex="17" onkeypress="return char(event)" 
                                          
                               onchange="updateTextbox()" onfocus="updateTextbox();" onkeydown="updateTextbox();"></asp:TextBox>

                            <asp:HiddenField ID="txtCountryCode" runat="server" 
                            ClientIDMode="Static" />
                           
                            </div>
                            
                            <div id="magnify_area">
                          <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false" tabindex="18"></a>
                                
                          </div>
                        </div>
                        <div id="tag_transac_lft_in1">
                           <div id="tag_label_transaction_popup_gen">
                                Country of Shipment
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                
                              
                            <asp:TextBox ID="txtCountryShipment" runat="server" MaxLength="50" onblur="ChangeCase(this);"   CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"  ClientIDMode="Static" 
                                   TabIndex="19" onkeypress="return char(event)" onkeyup="ChangeCase(this);"></asp:TextBox>

                              <asp:HiddenField ID="txtCountryShipmentCode" runat="server" 
                            ClientIDMode="Static" />
                            </div>
                            
                            <div id="magnify_area">
                          <a href="#"  class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('ship'); return false" tabindex="20"></a>
                               
                             
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                Port of Origin
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                               
                               

                           <asp:TextBox ID="txtPortOrigin" runat="server" MaxLength="50" onkeypress="return char(event),TextBoxes(this);" onblur="ChangeCase(this);updateTextbox2();"
              onkeyup="ChangeCase(this);" onfocus="updateTextbox2();" onkeydown="var data = val;Port_origin(this);"    onchange="updateTextbox2();" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static" TabIndex="21"
                          ></asp:TextBox>
                        



                            </div>
                            
                            <div id="magnify_area">
                        
                          <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_Master(''); return false" tabindex="22"></a>

                             
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                Port of Shipment
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                           

                             <asp:TextBox ID="txtPortShipment" runat="server" MaxLength="50" onkeypress="return char(event)" onblur="ChangeCase(this);" 
              onkeyup="ChangeCase(this);"  onkeydown="ChangeCase(this);var data = val;Port_origin(this);"    CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static" TabIndex="23"
                          ></asp:TextBox>    
                                
                            </div>
                           
                            <div id="magnify_area">
                          <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_Master('Port_Ship'); return false" tabindex="24"></a>
                               
                                       </div>
                        </div>
                         <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Commercial Tax Details[Y/N]
                            </div>
                            
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                           
<asp:DropDownList ID="ddlCommercial_Tax_yn" CssClass="listtxt_transac_item_gen_notn" 
                        runat="server" TabIndex="107">
                        <asp:ListItem >N</asp:ListItem>
                        <asp:ListItem >Y</asp:ListItem>
                      
                    </asp:DropDownList>
                            </div>
                           
                            
                        </div>
                        <div id="div_CommercialTax" style="display:none;">
                        <div id="tag_transac_lft_in1" >
                            <div id="tag_label_transaction_popup_gen">

                                State Code
                            </div>
                            
                            <div id="txtcon-m_transaction_item_CTH_small">

                           

                             <asp:TextBox ID="TextBox2" runat="server" MaxLength="50" onkeypress="return char(event)" onblur="ChangeCase(this);" 
              onkeyup="ChangeCase(this);"  onkeydown="ChangeCase(this);var data = val;Port_origin(this);"    CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="23"
                          ></asp:TextBox>    
                                
                            </div>
                           
                            <div id="magnify_area">

                          <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_Master('Port_Ship'); return false" tabindex="24"></a>
                               
                                       </div>
                                       <div id="tag_label_transaction_popup_trans_cth_label">
                                Commercial Tax Type[V/C/S]
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">

                           

                             <asp:TextBox ID="TextBox4" runat="server" MaxLength="50" onkeypress="return char(event)" onblur="ChangeCase(this);" 
              onkeyup="ChangeCase(this);"  onkeydown="ChangeCase(this);var data = val;Port_origin(this);"    CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="23"
                          ></asp:TextBox>    
                                
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">

                                Registration No
                            </div>
                            
                            <div id="tag_label_transaction_popup_gen">

                           

                             <asp:TextBox ID="TextBox5" runat="server" MaxLength="50" onkeypress="return char(event)" onblur="ChangeCase(this);" 
              onkeyup="ChangeCase(this);"  onkeydown="ChangeCase(this);var data = val;Port_origin(this);"    CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static" TabIndex="23"
                          ></asp:TextBox>    
                                
                            </div>
                           
                           
                        </div>
                        </div>
                        
                        
                        <div id="tag" runat="server" >
                            <div id="tag_label_transaction_popup_gen"  >
                               
                                Ware House Name
                             </div>
                           
                            <div id="txtcon-m_transaction_gen_warehouse">
                                
                                

                            <asp:TextBox ID="txtWarehouseName" runat="server" CssClass="txtbox_none_Mid_transac_gen_ware"  
                            MaxLength="50"  TabIndex="25"></asp:TextBox>

                            </div>
                           
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_gen_smal_label"  >
                                Code</div>
                           
                            <div id="txtcon-m_transaction_item_maindet">
                              
                          

                            <asp:TextBox ID="txtWarehouseCode" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"  
                            MaxLength="50"  TabIndex="26"></asp:TextBox>

                            </div>
                           
                        </div>
                    </div>
                    <div id="pop_text_area_transac_popup_inn_container_rght_new">
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen2">
                                Filing Status
                            </div>
                            
                            <div id="txtcon-m_transaction_list1">
                                                                
                            
                         <asp:DropDownList ID="ddlFilingStatus" runat="server" 
                                     CssClass="listtxt_transac_src1" TabIndex="27">
                        </asp:DropDownList>
                                </div>
                           
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen2">
                                Section 46
                            </div>
                            <div id="txtcon_transac_checkbox">

                               
                                 <asp:CheckBox ID="chkSection46" runat="server" Checked="false" TabIndex="28" />
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                              
                      

                           <asp:TextBox ID="txtSection46Desc" runat="server" MaxLength="50" Onkeypress="return numchar(event)"
                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic" Enabled="False" TabIndex="29"></asp:TextBox>

                            </div>
                            
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen2">
                                First Check
                            </div>
                            <div id="txtcon_transac_checkbox">


                                <asp:CheckBox ID="chkFirstCheck" runat="server" Checked="false" 
                                     TabIndex="30"  />

                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                
                              <asp:TextBox ID="txtFirstCheckDesc" runat="server" MaxLength="50" 
                                    Onkeypress="return numchar(event)" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                             Enabled="False" TabIndex="31"></asp:TextBox>

                            </div>
                            
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen2">
                                Green Channel
                            </div>
                            <div id="txtcon_transac_checkbox">

                                   <asp:CheckBox ID="chkGreenChannel" runat="server" Checked="false" 
                                      TabIndex="32"  />
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                
                           <asp:TextBox ID="txtGreenChannelDesc" runat="server" MaxLength="50" Onkeypress="return numchar(event)" 
                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic" Enabled="False" TabIndex="33"></asp:TextBox>
                            </div>
                            
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen2">
                                Kachha B/E
                            </div>
                            <div id="txtcon_transac_checkbox">
                              
                               <asp:CheckBox ID="chkKachha" runat="server" Checked="false" TabIndex="34"  />
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                       
                            <asp:TextBox ID="txtKachhaDesc" runat="server" Onkeypress="return numchar(event)" 
                                    MaxLength="50" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                            Enabled="False" TabIndex="35"></asp:TextBox>
                            </div>
                           
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen2">
                                Section 48
                            </div>
                            <div id="txtcon_transac_checkbox">
                             
                                <asp:CheckBox ID="chkSection48" runat="server" Checked="false" TabIndex="36" />

                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                              
                                
                        
                              <asp:TextBox ID="txtSection48Desc" runat="server" MaxLength="50" 
                                    Onkeypress="return numchar(event)" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                             Enabled="False" TabIndex="37"></asp:TextBox>

                            </div>
                           
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="txtcon_transac_checkbox">
                                
                               <asp:CheckBox ID="chkHighSeaSale" runat="server" Checked="false" onclick="jQuery('#form1').validationEngine('hideAll')"
                                    TabIndex="38"  />
              
                            </div>
                            <div id="tag_label_transaction_HighSeaSale_label">
                                High Sea Br.Sr.No 
                            </div>
                        </div>


                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                Seller Name
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                               
                              
                           <asp:TextBox ID="txtSellerName" runat="server" MaxLength="40" onblur="ChangeCase(this);" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"
                                            ClientIDMode="Static" Enabled="False"  TabIndex="39" Onkeypress="return numcharspl1(event)"></asp:TextBox>
                            <%--<asp:TextBox ID="txtMRP_SL_NO" runat="server" Enabled="False" MaxLength="10" onkeypress= "return numchar(event)"
                                                       CssClass="validate[required] txtbox_none_Promas2" TabIndex="4"></asp:TextBox>--%>
                            </div>
                           
                            <div id="magnify_area">
                               
                          <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporter_Master('seller'); return false" tabindex="40"></a>
                         
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                IEC No
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen3">
                               
                               <asp:TextBox ID="txtHighSeaSaleIECNo" runat="server" MaxLength="10" 
                                            CssClass="validate[required,minSize[10],custom[number]] txtbox_none_Mid_transac_pop_gen3"  Enabled="False" 
                                     ClientIDMode="Static" TabIndex="41" onkeypress="return pin(event)"></asp:TextBox>

                                        
                            </div>
                           
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                Branch SL. No
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                            
                                                                          <asp:TextBox ID="txtBranchSLNo" runat="server" MaxLength="3"  CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_pop_gen_srcic"
                                          Enabled="False" ClientIDMode="Static" TabIndex="42" onkeypress="return pin(event)"></asp:TextBox>

                                      
                            </div>
                            
                          
                            <div id="magnify_area">
                               
                          <a href="#" class="magnfy" tabindex="43" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporter_Master_HighSea_BranchSlno('Import_HighSea_Branch');return false"></a>
                         
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                                Address
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen3">
                                
                               <asp:TextBox ID="txtHighSeaSaleAddress" runat="server" MaxLength="35" 
                                            CssClass="validate[required] txtbox_none_Mid_transac_pop_gen3"  Enabled="False" 
                                    ClientIDMode="Static" TabIndex="44"></asp:TextBox>
                            
                            </div>
                           
                            
                        </div>
                        <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen3">
                               
                                 
                            
                             <asp:TextBox ID="txtHighSeaSaleAddress1" runat="server" MaxLength="35" 
                                            CssClass="txtbox_none_Mid_transac_pop_gen3"  Enabled="False" 
                                     ClientIDMode="Static" TabIndex="45"></asp:TextBox>
                            </div>
                            
                          
                        </div>
                         <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen3">
                                
                               
                              <asp:TextBox ID="txtHighSeaSaleAddress2" runat="server" MaxLength="35" 
                                            CssClass="txtbox_none_Mid_transac_pop_gen3"  Enabled="False" 
                                     ClientIDMode="Static" TabIndex="46"></asp:TextBox>
                            </div>
                            
                          
                        </div>
                         <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen3">
                               
                            
                             <asp:TextBox ID="txtHighSeaSaleAddress3" runat="server" MaxLength="35" 
                                            CssClass="txtbox_none_Mid_transac_pop_gen3"  Enabled="False" 
                                      ClientIDMode="Static" TabIndex="47"></asp:TextBox>
                            
                            </div>
                           
                          
                        </div>
                         <div id="tag_transac_lft_in1">
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen3">
                               
                            <asp:TextBox ID="txtHighSeaSaleAddress4" runat="server" MaxLength="35" 
                                            CssClass="txtbox_none_Mid_transac_pop_gen3"  Enabled="False" 
                                    ClientIDMode="Static" TabIndex="48"></asp:TextBox>
                            
                            </div>
                          
                          
                        </div>
                     

                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container2" style="display:none;">
                    <div id="pop_text_area_Transact_remarks">
                        <div id="tag_label_transaction_popup_gen">
                            Remarks</div>
                        
                        <div id="txtcon-m_Maxtxt_trans_gen_remarks">
                           
                            
                        <asp:TextBox ID="txtRemarks" CssClass="txtbox_none_transac_gen_remarks" onkeyDown="return checkTextAreaMaxLength(this,event,'120');" 
                              TextMode="MultiLine" runat="server"  TabIndex="49"  MaxLength="120" onpaste="return checkTextAreaMaxLength(this,event,'120');"></asp:TextBox>
                       
                        </div>
                        
                    </div>
                     <div id="lblMsg2" style="display:none;">
                </div>

                </div>
             
                <div id="innerbox_MidMain_bot_transact" runat="server">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                         
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"  OnClick="btnNew_Click" onclientclick="jQuery('#form1').validationEngine('hideAll')" TabIndex="52"/>
                            </div>
                        <div id="editbu">
                          
                             <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();" TabIndex="50"

                                  onclick="btnSave_Click" />
                           
                           
                            </div>
                        <div id="editbu">
                           
                             <asp:Button ID="btnUpdate" runat="server" CssClass="updates" onclick="btnUpdate_Click" OnClientClick="return validate();" TabIndex="50"/>
                            </div>
                        <div id="editbu">
                           <asp:Button ID="btnDelete" runat="server" TabIndex="51" CausesValidation="false" UseSubmitBehavior="false"   CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'GENERAL', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;"/>
  <asp:Button ID="btn" runat="server" TabIndex="51" OnClick="btnDelete_Click" CausesValidation="false" UseSubmitBehavior="false"  OnClientClick="jQuery('#form1').validationEngine('hideAll');"  CssClass="dlete" Style="display: none;"/>
  
                            
                            </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide()" id="btnCancel" tabindex="52"></div>
                    </div>
                </div>
                       </asp:Panel>
            </div>
        </div>
        <div class="content" id="page-2" style="display:none;">
<iframe src="#" name="maineroyal" scrolling="no" id="Trans_igm_Iframe" ></iframe>
</div>
<div class="content" id="page-3" style="display:none;">
  <iframe src="#" name="maineroyal1" scrolling="no" id="Trans_igm_Invoice_Iframe"></iframe>
</div>
<div class="content" id="page-4" style="display:none;">
   <iframe src="#" name="maineroyal2" scrolling="no" id="Trans_igm_item_Iframe" ></iframe>
</div>
        
    <%--  <iframe src="#" name="maineroyal" scrolling="no" id="mainiframecontainer" style="display:none;">
    </iframe>--%>
     
     
    </div>
 <script src="../activatables.js" type="text/javascript"></script>
<script type="text/javascript">
    activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
</script>
    <script type="text/javascript">
   
        function tab_page1() {
            
            document.getElementById('page-1').style.display = 'Block';
           document.getElementById('page-2').style.display = 'none';
            document.getElementById('page-3').style.display = 'none';
            document.getElementById('page-4').style.display = 'none';
           
            //.getElementById('Trans_igm_Iframe').style.display = 'none';
           
        }
        function tab_page2() {




            if (document.getElementById('hdn_Jobno').value != '') {
                document.getElementById('page-1').style.display = 'none';
                document.getElementById('page-2').style.display = 'Block';
                document.getElementById('page-3').style.display = 'none';
                document.getElementById('page-4').style.display = 'none';

                document.getElementById("Trans_igm_Iframe").src = "../Transaction/IGM_Details.aspx";
            }
            else {

               
                happycode();
               
            }
        }
        function tab_page3() {
           
           
          

            if (document.getElementById('hdn_Jobno').value != '') {
                document.getElementById('page-1').style.display = 'none';
                document.getElementById('page-2').style.display = 'none';
                document.getElementById('page-3').style.display = 'Block';
                document.getElementById('page-4').style.display = 'none';

                document.getElementById("Trans_igm_Invoice_Iframe").src = "../Transaction/Invoice_Details.aspx";
            }
            else {

                happycode();

            }
        }
        function tab_page4() {
        
            if (document.getElementById('hdn_Jobno').value != '') {
                document.getElementById('page-1').style.display = 'none';
                document.getElementById('page-2').style.display = 'none';
                document.getElementById('page-3').style.display = 'none';
                document.getElementById('page-4').style.display = 'Block';

                document.getElementById("Trans_igm_item_Iframe").src = "../Transaction/Item_Details.aspx";
            }
            else {

                happycode();

            }
        }
    </script>
   <div style="display:none;">
    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        <%-- <asp:TextBox ID="chksec46" runat="server"></asp:TextBox>--%>
                        <asp:HiddenField ID="chksec46" runat="server" Value="N" />
                        <asp:HiddenField ID="chkFirCheck" runat="server" Value="N"/>
                        <asp:HiddenField ID="chkGrnChannel" runat="server" Value="N"/>
                        <asp:HiddenField ID="chkKach" runat="server" Value="N"/>
                        <asp:HiddenField ID="chkSec48" runat="server" Value="N"/>
                        <asp:HiddenField ID="chkHghSeaSale" runat="server" Value="N"/>
                        <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                 <asp:HiddenField ID="hdn_val_updateid" runat="server" />
                 <asp:HiddenField ID="hdn_Jobno" runat="server" />
                 <asp:HiddenField ID="hdn_ImporterType" runat="server" ClientIDMode="Static" />
                 <asp:HiddenField ID="hdn_Update_General" runat="server" />

    </div>
      
       <script type="text/javascript" language="javascript" >
          
           function OpenPopupCustom_House() {


               if (document.getElementById('hdfTransport_mode').value != '') {
                  
                   var s = document.getElementById('hdfTransport_mode').value;
                   
                   OpenPopupCustom_House_Details(s);
                   
                   return false
               }
           }
           function OpenPopupCustom_House3() {


               if (document.getElementById('hdfTransport_mode').value != '') {
                   var s = document.getElementById('hdfTransport_mode').value;

                   OpenPopupCustom_House_Details_Port(s, '23');

                   return false
               }
           }
           function OpenPopupPort_Master(val) {

               if (document.getElementById('hdfTransport_mode').value != '') {

                   OpenPopupPortDetails(val);
                   return false
               }
           }
           function OpenPopupImporter_Master(val) {

               if (document.getElementById('hdfTransport_mode').value != '') {

                   if (val == 'seller') {

                       if (document.getElementById('chkHighSeaSale').checked == true) {

                           OpenPopupImporterDetails(val);
                           return false
                       }
                   }

                   else if (val == '') {
                       OpenPopupImporterDetails(val);
                       return false
                   }
               }
           }
          
           function OpenPopupImporter_Master_BranchSlno(val1) {

               if (document.getElementById('hdfTransport_mode').value != '') {

                   var val = document.getElementById('txtIECNo').value;
                   val=val.replace(/\s+$/g, '');
                   if (val != '' && val.length == 10) {

                       OpenPopupImporterDetails_New(val, val1);
                   }

               }
           }
           function OpenPopupImporter_Master_HighSea_BranchSlno(val1) {

               if (document.getElementById('hdfTransport_mode').value != '') {

                   var val =document.getElementById('txtHighSeaSaleIECNo').value;

                   val = val.replace(/\s+$/g, '');
                   if (val != '') {

                       OpenPopupImporterDetails_New(val, val1);
                   }

               }
           }
           function OpenPopupCountry_Master(val) {

               if (document.getElementById('hdfTransport_mode').value != '') {

                   OpenPopupCountryOrigin(val);
                   return false
               }
           }
           function tab(val) {

               document.getElementById('page-1').style.display = 'none'; 
               document.getElementById('mainiframecontainer').style.display = 'Block';
               //document.getElementById('innerbox_MidMain_Transact_popup').style.display = 'none';


           }
           function tab1(val) {

               document.getElementById('page-1').style.display = 'Block';
               document.getElementById('mainiframecontainer').style.display = 'none';
               //document.getElementById('innerbox_MidMain_Transact_popup').style.display = 'Block';

           }


           $(function () {

               $('#<%= chkSection46.ClientID  %>').click(function (e) {

                   var txtSection46Desc = $('#<%= txtSection46Desc.ClientID %>');
                   var chksec46 = $('#<%= chksec46.ClientID %>');


                   if (this.checked) {
                       txtSection46Desc.attr('disabled', false);
                       chksec46.val('Y');



                       //chksec46.text = 'Y';


                   }
                   else {

                       txtSection46Desc.attr('disabled', true);
                       chksec46.val('N');
                       txtSection46Desc.val("");
                   }
               });


           });

           $(function () {

               $('#<%= chkFirstCheck.ClientID  %>').click(function (e) {

                   var txtFirstCheckDesc = $('#<%= txtFirstCheckDesc.ClientID %>');
                   var chkFirCheck = $('#<%= chkFirCheck.ClientID %>');


                   if (this.checked) {
                       txtFirstCheckDesc.attr('disabled', false);
                       chkFirCheck.val('Y');

                   }
                   else {
                       txtFirstCheckDesc.attr('disabled', true);
                       chkFirCheck.val('N');
                       txtFirstCheckDesc.val("");
                   }
               });




           });

           $(function () {

               $('#<%= chkGreenChannel.ClientID  %>').click(function (e) {

                   var txtGreenChannelDesc = $('#<%= txtGreenChannelDesc.ClientID %>');
                   var chkGrnChannel = $('#<%= chkGrnChannel.ClientID %>');


                   if (this.checked) {
                       txtGreenChannelDesc.attr('disabled', false);
                       chkGrnChannel.val('Y');

                   }
                   else {
                       txtGreenChannelDesc.attr('disabled', true);
                       chkGrnChannel.val('N');
                       txtGreenChannelDesc.val("");

                   }
               });




           });

           $(function () {

               $('#<%= chkKachha.ClientID  %>').click(function (e) {

                   var txtKachhaDesc = $('#<%= txtKachhaDesc.ClientID %>');
                   var chkKach = $('#<%= chkKach.ClientID %>');


                   if (this.checked) {
                       txtKachhaDesc.attr('disabled', false);
                       chkKach.val('Y');

                   }
                   else {
                       txtKachhaDesc.attr('disabled', true);
                       chkKach.val('N');
                       txtKachhaDesc.val("");

                   }
               });




           });


           $(function () {

               $('#<%= chkSection48.ClientID  %>').click(function (e) {

                   var txtSection48Desc = $('#<%= txtSection48Desc.ClientID %>');
                   var chkSec48 = $('#<%= chkSec48.ClientID %>');


                   if (this.checked) {
                       txtSection48Desc.attr('disabled', false);
                       chkSec48.val('Y');

                   }
                   else {
                       txtSection48Desc.attr('disabled', true);
                       chkSec48.val('N');
                       txtSection48Desc.val("");

                   }
               });




           });

           $(function () {

               $('#<%= chkHighSeaSale.ClientID  %>').click(function (e) {

                   var txtSellerName = $('#<%= txtSellerName.ClientID %>');
                   var txtHighSeaSaleIECNo = $('#<%= txtHighSeaSaleIECNo.ClientID %>');
                   var txtBranchSLNo = $('#<%= txtBranchSLNo.ClientID %>');
                   var txtHighSeaSaleAddress = $('#<%= txtHighSeaSaleAddress.ClientID %>');
                   var txtHighSeaSaleAddress1 = $('#<%= txtHighSeaSaleAddress1.ClientID %>');
                   var txtHighSeaSaleAddress2 = $('#<%= txtHighSeaSaleAddress2.ClientID %>');
                   var txtHighSeaSaleAddress3 = $('#<%= txtHighSeaSaleAddress3.ClientID %>');
                   var txtHighSeaSaleAddress4 = $('#<%= txtHighSeaSaleAddress4.ClientID %>');

                   var chkHghSeaSale = $('#<%= chkHghSeaSale.ClientID %>');


                   if (this.checked) {
                       txtSellerName.attr('disabled', false);
                       txtHighSeaSaleIECNo.attr('disabled', false);
                       txtBranchSLNo.attr('disabled', false);
                       txtHighSeaSaleAddress.attr('disabled', false);
                       txtHighSeaSaleAddress1.attr('disabled', false);
                       txtHighSeaSaleAddress2.attr('disabled', false);
                       txtHighSeaSaleAddress3.attr('disabled', false);
                       txtHighSeaSaleAddress4.attr('disabled', false);
                       // imgbtnseller.attr('disabled', false);
                       chkHghSeaSale.val('Y');

                   }
                   else {
                       txtSellerName.val("");
                       txtHighSeaSaleIECNo.val("");
                       txtBranchSLNo.val("");
                       txtHighSeaSaleAddress.val("");
                       txtHighSeaSaleAddress1.val("");
                       txtHighSeaSaleAddress2.val("");
                       txtHighSeaSaleAddress3.val("");
                       txtHighSeaSaleAddress4.val("");
                       txtSellerName.attr('disabled', true);
                       txtHighSeaSaleIECNo.attr('disabled', true);
                       txtBranchSLNo.attr('disabled', true);
                       txtHighSeaSaleAddress.attr('disabled', true);
                       txtHighSeaSaleAddress1.attr('disabled', true);
                       txtHighSeaSaleAddress2.attr('disabled', true);
                       txtHighSeaSaleAddress3.attr('disabled', true);
                       txtHighSeaSaleAddress4.attr('disabled', true);
                       //imgbtnseller.attr('disabled', true);
                       chkHghSeaSale.val('N');



                   }
               });




           });

          
        </script>

        <script type="text/javascript">



            function clear() {

                var txtCustomsHouse = $('#<%= txtCustomsHouse.ClientID %>');

                var txtImporterName = $('#<%= txtImporterName.ClientID %>');
                var txtAddress1 = $('#<%= txtAddress1.ClientID %>');
                var txtAddress2 = $('#<%= txtAddress2.ClientID %>');
                var txtAddress3 = $('#<%= txtAddress3.ClientID %>');
                var txtBranchNo = $('#<%= txtBranchNo.ClientID %>');
                var txtIECNo = $('#<%= txtIECNo.ClientID %>');
                var txtAddress4 = $('#<%= txtAddress4.ClientID %>');
                var txtAddress5 = $('#<%= txtAddress5.ClientID %>');
                var txtCountryName = $('#<%= txtCountryName.ClientID %>');
                var txtPortOrigin = $('#<%= txtPortOrigin.ClientID %>');
                var txtPortShipment = $('#<%= txtPortShipment.ClientID %>');
                var txtCountryShipment = $('#<%= txtCountryShipment.ClientID %>');
                var txtWarehouseName = $('#<%= txtWarehouseName.ClientID %>');
                var txtWarehouseCode = $('#<%= txtWarehouseCode.ClientID %>');
                var ddlFilingStatus = $('#<%= ddlFilingStatus.ClientID %>');
                var txtRemarks = $('#<%= txtRemarks.ClientID %>');

                var txtSection46Desc = $('#<%= txtSection46Desc.ClientID %>');
                var txtFirstCheckDesc = $('#<%= txtFirstCheckDesc.ClientID %>');
                var txtGreenChannelDesc = $('#<%= txtGreenChannelDesc.ClientID %>');
                var txtKachhaDesc = $('#<%= txtKachhaDesc.ClientID %>');
                var txtSection48Desc = $('#<%= txtSection48Desc.ClientID %>');
                var txtSellerName = $('#<%= txtSellerName.ClientID %>');
                var txtHighSeaSaleIECNo = $('#<%= txtHighSeaSaleIECNo.ClientID %>');
                var txtBranchSLNo = $('#<%= txtBranchSLNo.ClientID %>');
                var txtHighSeaSaleAddress = $('#<%= txtHighSeaSaleAddress.ClientID %>');
                var txtHighSeaSaleAddress2 = $('#<%= txtHighSeaSaleAddress2.ClientID %>');
                var txtHighSeaSaleAddress4 = $('#<%= txtHighSeaSaleAddress4.ClientID %>');
                var txtHighSeaSaleAddress1 = $('#<%= txtHighSeaSaleAddress1.ClientID %>');
                var txtHighSeaSaleAddress3 = $('#<%= txtHighSeaSaleAddress3.ClientID %>');

                txtImporterName.val("");
                txtCustomsHouse.val("");
                txtAddress1.val("");
                txtAddress2.val("");
                txtAddress3.val("");
                txtAddress4.val("");
                txtAddress5.val("");
                txtBranchNo.val("");
                txtIECNo.val("");
                txtCountryName.val("");
                txtPortOrigin.val("");
                txtPortShipment.val("");
                txtCountryShipment.val("");
                txtWarehouseName.val("");
                txtWarehouseCode.val("");
                txtRemarks.val("");

                txtSection46Desc.val("");
                txtFirstCheckDesc.val("");
                txtGreenChannelDesc.val("");
                txtKachhaDesc.val("");
                txtSection48Desc.val("");
                txtSellerName.val("");
                txtHighSeaSaleIECNo.val("");
                txtBranchSLNo.val("");
                txtHighSeaSaleAddress.val("");
                txtHighSeaSaleAddress1.val("");
                txtHighSeaSaleAddress2.val("");
                txtHighSeaSaleAddress3.val("");
                txtHighSeaSaleAddress4.val("");


            }

            function disabled_true() {

                var txtCustomsHouse = $('#<%= txtCustomsHouse.ClientID %>');

                var txtImporterName = $('#<%= txtImporterName.ClientID %>');
                var txtAddress1 = $('#<%= txtAddress1.ClientID %>');
                var txtAddress2 = $('#<%= txtAddress2.ClientID %>');
                var txtAddress3 = $('#<%= txtAddress3.ClientID %>');
                var txtBranchNo = $('#<%= txtBranchNo.ClientID %>');
                var txtIECNo = $('#<%= txtIECNo.ClientID %>');
                var txtAddress4 = $('#<%= txtAddress4.ClientID %>');
                var txtAddress5 = $('#<%= txtAddress5.ClientID %>');
                var txtCountryName = $('#<%= txtCountryName.ClientID %>');
                var txtPortOrigin = $('#<%= txtPortOrigin.ClientID %>');
                var txtPortShipment = $('#<%= txtPortShipment.ClientID %>');
                var txtCountryShipment = $('#<%= txtCountryShipment.ClientID %>');
                var txtWarehouseName = $('#<%= txtWarehouseName.ClientID %>');
                var txtWarehouseCode = $('#<%= txtWarehouseCode.ClientID %>');
                var ddlFilingStatus = $('#<%= ddlFilingStatus.ClientID %>');
                var txtRemarks = $('#<%= txtRemarks.ClientID %>');

                var txtSection46Desc = $('#<%= txtSection46Desc.ClientID %>');
                var txtFirstCheckDesc = $('#<%= txtFirstCheckDesc.ClientID %>');
                var txtGreenChannelDesc = $('#<%= txtGreenChannelDesc.ClientID %>');
                var txtKachhaDesc = $('#<%= txtKachhaDesc.ClientID %>');
                var txtSection48Desc = $('#<%= txtSection48Desc.ClientID %>');
                var txtSellerName = $('#<%= txtSellerName.ClientID %>');
                var txtHighSeaSaleIECNo = $('#<%= txtHighSeaSaleIECNo.ClientID %>');
                var txtBranchSLNo = $('#<%= txtBranchSLNo.ClientID %>');
                var txtHighSeaSaleAddress = $('#<%= txtHighSeaSaleAddress.ClientID %>');
                var txtHighSeaSaleAddress2 = $('#<%= txtHighSeaSaleAddress2.ClientID %>');
                var txtHighSeaSaleAddress4 = $('#<%= txtHighSeaSaleAddress4.ClientID %>');
                var txtHighSeaSaleAddress1 = $('#<%= txtHighSeaSaleAddress1.ClientID %>');
                var txtHighSeaSaleAddress3 = $('#<%= txtHighSeaSaleAddress3.ClientID %>');





                var chkSection46 = $('#<%= chkSection46.ClientID %>');

                var chkFirstCheck = $('#<%= chkFirstCheck.ClientID %>');

                var chkGreenChannel = $('#<%= chkGreenChannel.ClientID %>');

                var chkKachha = $('#<%= chkKachha.ClientID %>');

                var chkSection48 = $('#<%= chkSection48.ClientID %>');

                var chkHighSeaSale = $('#<%= chkHighSeaSale.ClientID %>');




                clear();
                txtImporterName.attr('disabled', true);
                txtCustomsHouse.attr('disabled', true);
                txtAddress1.attr('disabled', true);
                txtAddress2.attr('disabled', true);
                txtAddress3.attr('disabled', true);
                txtAddress4.attr('disabled', true);
                txtAddress5.attr('disabled', true);
                txtBranchNo.attr('disabled', true);
                txtIECNo.attr('disabled', true);
                txtCountryName.attr('disabled', true);
                txtPortOrigin.attr('disabled', true);
                txtPortShipment.attr('disabled', true);
                txtCountryShipment.attr('disabled', true);
                txtWarehouseName.attr('disabled', true);
                txtWarehouseCode.attr('disabled', true);
                txtRemarks.attr('disabled', true);

                //Imgbtn_Importer.attr('disabled', true);
                ddlFilingStatus.attr('disabled', true);
                // Imgbtn_Importer.attr('disabled', true);
                //imgbtn_Port_Origin.attr('disabled', true);
                //imgbtn_Port_Shipment.attr('disabled', true);
                //Imgbtn_CountryShipment.attr('disabled', true);
                chkSection46.attr('disabled', true);
                chkFirstCheck.attr('disabled', true);
                chkGreenChannel.attr('disabled', true);
                chkKachha.attr('disabled', true);
                chkSection48.attr('disabled', true);
                chkHighSeaSale.attr('disabled', true);
                //imgCustomHouse.attr('disabled', true);
                // imgbtnseller.attr('disabled', true);

                txtSection46Desc.attr('disabled', true);
                txtFirstCheckDesc.attr('disabled', true);
                txtGreenChannelDesc.attr('disabled', true);
                txtSection48Desc.attr('disabled', true);
                txtSellerName.attr('disabled', true);
                txtHighSeaSaleIECNo.attr('disabled', true);
                txtBranchSLNo.attr('disabled', true);
                txtHighSeaSaleAddress.attr('disabled', true);
                txtHighSeaSaleAddress1.attr('disabled', true);
                txtHighSeaSaleAddress2.attr('disabled', true);
                txtHighSeaSaleAddress3.attr('disabled', true);
                txtHighSeaSaleAddress4.attr('disabled', true);




            }

            $(function () {

                var dropDownList1 = $('#<%= ddlBEType.ClientID %>');

                dropDownList1.change(function (e) {
                    var selectedValue = $(this).val();

                    if (selectedValue != '') {

                        if (selectedValue == 'Home') {
                            document.getElementById('tag').style.display = 'none';
                        }
                        else if (selectedValue == 'Warehouse') {
                            document.getElementById('tag').style.display = 'Block';
                        }
                        else if (selectedValue == 'Ex-Bond') {
                            document.getElementById('tag').style.display = 'none';
                        }
                    }


                });



            });


            $(function () {

                var dropDownList1 = $('#<%= ddlTransportMode.ClientID %>');

                dropDownList1.change(function (e) {
                    
                    var e = document.getElementById("ddlTransportMode");
                    var selectedValue = e.options[e.selectedIndex].text;


                    var txtCustomsHouse = $('#<%= txtCustomsHouse.ClientID %>');

                    var txtImporterName = $('#<%= txtImporterName.ClientID %>');
                    var txtAddress1 = $('#<%= txtAddress1.ClientID %>');
                    var txtAddress2 = $('#<%= txtAddress2.ClientID %>');
                    var txtAddress3 = $('#<%= txtAddress3.ClientID %>');
                    var txtBranchNo = $('#<%= txtBranchNo.ClientID %>');
                    var txtIECNo = $('#<%= txtIECNo.ClientID %>');
                    var txtAddress4 = $('#<%= txtAddress4.ClientID %>');
                    var txtAddress5 = $('#<%= txtAddress5.ClientID %>');
                    var txtCountryName = $('#<%= txtCountryName.ClientID %>');
                    var txtPortOrigin = $('#<%= txtPortOrigin.ClientID %>');
                    var txtPortShipment = $('#<%= txtPortShipment.ClientID %>');
                    var txtCountryShipment = $('#<%= txtCountryShipment.ClientID %>');
                    var txtWarehouseName = $('#<%= txtWarehouseName.ClientID %>');
                    var txtWarehouseCode = $('#<%= txtWarehouseCode.ClientID %>');
                    var ddlFilingStatus = $('#<%= ddlFilingStatus.ClientID %>');
                    var txtRemarks = $('#<%= txtRemarks.ClientID %>');

                    var txtSection46Desc = $('#<%= txtSection46Desc.ClientID %>');
                    var txtFirstCheckDesc = $('#<%= txtFirstCheckDesc.ClientID %>');
                    var txtGreenChannelDesc = $('#<%= txtGreenChannelDesc.ClientID %>');
                    var txtKachhaDesc = $('#<%= txtKachhaDesc.ClientID %>');
                    var txtSection48Desc = $('#<%= txtSection48Desc.ClientID %>');
                    var txtSellerName = $('#<%= txtSellerName.ClientID %>');
                    var txtHighSeaSaleIECNo = $('#<%= txtHighSeaSaleIECNo.ClientID %>');
                    var txtBranchSLNo = $('#<%= txtBranchSLNo.ClientID %>');
                    var txtHighSeaSaleAddress = $('#<%= txtHighSeaSaleAddress.ClientID %>');
                    var txtHighSeaSaleAddress2 = $('#<%= txtHighSeaSaleAddress2.ClientID %>');
                    var txtHighSeaSaleAddress4 = $('#<%= txtHighSeaSaleAddress4.ClientID %>');
                    var txtHighSeaSaleAddress1 = $('#<%= txtHighSeaSaleAddress1.ClientID %>');
                    var txtHighSeaSaleAddress3 = $('#<%= txtHighSeaSaleAddress3.ClientID %>');



                    var chkSection46 = $('#<%= chkSection46.ClientID %>');

                    var chkFirstCheck = $('#<%= chkFirstCheck.ClientID %>');

                    var chkGreenChannel = $('#<%= chkGreenChannel.ClientID %>');

                    var chkKachha = $('#<%= chkKachha.ClientID %>');

                    var chkSection48 = $('#<%= chkSection48.ClientID %>');

                    var chkHighSeaSale = $('#<%= chkHighSeaSale.ClientID %>');

                    if (selectedValue == 'Select') {
                        document.getElementById('hdfTransport_mode').value = '';
                        selectedValue = '';
                    }

                    if (selectedValue != '') {

                        document.getElementById('hdfTransport_mode').value = selectedValue;


                        $.ajax({
                            url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/SessionCreate_Transport_Mode_Port",
                            data: "{ 'mail': '" + selectedValue + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8"

                        });




                        txtImporterName.attr('disabled', false);
                        txtCustomsHouse.attr('disabled', false);
                        txtAddress1.attr('disabled', false);
                        txtAddress2.attr('disabled', false);
                        txtAddress3.attr('disabled', false);
                        txtAddress4.attr('disabled', false);
                        txtAddress5.attr('disabled', false);
                        txtBranchNo.attr('disabled', false);
                        txtIECNo.attr('disabled', false);
                        txtCountryName.attr('disabled', false);
                        txtPortOrigin.attr('disabled', false);
                        txtPortShipment.attr('disabled', false);
                        txtCountryShipment.attr('disabled', false);

                        txtWarehouseName.attr('disabled', false);
                        txtWarehouseCode.attr('disabled', false);
                        txtRemarks.attr('disabled', false);



                        //Imgbtn_Importer.attr('disabled', false);
                        ddlFilingStatus.attr('disabled', false);
                        //Imgbtn_Importer.attr('disabled', false);
                        //imgbtn_Port_Origin.attr('disabled', false);
                        // imgbtn_Port_Shipment.attr('disabled', false);
                        //Imgbtn_CountryShipment.attr('disabled', false);
                        chkSection46.attr('disabled', false);
                        chkFirstCheck.attr('disabled', false);
                        chkGreenChannel.attr('disabled', false);
                        chkKachha.attr('disabled', false);
                        chkSection48.attr('disabled', false);
                        chkHighSeaSale.attr('disabled', false);
                        ///imgCustomHouse.attr('disabled', false);
                        // imgbtn_Countryname.attr('disabled', false);
                        //imgbtnseller.attr('disabled', false);
                        //document.getElementById('btnNew').disabled = false;
                        //document.getElementById('btnSave').disabled = false;

                        //document.getElementById('btnDelete').disabled = false;
                        // document.getElementById('btnUpdate').disabled = false;

                        //Opensession(selectedValue);


                        var btnNew = $('#<%= btnNew.ClientID %>');
                        var btnsave = $('#<%= btnSave.ClientID %>');
                        var btnDelete = $('#<%= btnDelete.ClientID %>');
                        var btnUpdate = $('#<%= btnUpdate.ClientID %>');
                        btnNew.attr('disabled', false);
                        btnsave.attr('disabled', false);
                        btnDelete.attr('disabled', false);
                        btnUpdate.attr('disabled', false);

                    }
                    else {


                        disabled_true();
                        var btn_New = $('#<%= btnNew.ClientID %>');
                        var btn_save = $('#<%= btnSave.ClientID %>');
                        var btn_Delete = $('#<%= btnDelete.ClientID %>');
                        var btn_Update = $('#<%= btnUpdate.ClientID %>');
                        btn_New.attr('disabled', true);
                        btn_save.attr('disabled', true);
                        btn_Delete.attr('disabled', true);
                        btn_Update.attr('disabled', true);
                        //document.getElementById('btnNew').disabled = true;
                        //document.getElementById('btnSave').disabled = true;

                        //document.getElementById('btnDelete').disabled = true;
                        //document.getElementById('btnUpdate').disabled = true;
                        //alert('Transport_Mode Cannot be empty');


                        // alert('Transport_Mode Cannot be empty');
                        jAlert('Transport_Mode Cannot be empty', 'GENERAL', function (r) { document.getElementById("ddlTransportMode").focus(); });

                    }

                });



            });

                     
    
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtCountryName').focus(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryName').change(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryName').keyup(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryName').keydown(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryShipment').focus(function () {

                var data = $(this).val();
                country_shipment(data);

            });
            $('#txtCountryShipment').change(function () {

                var data = $(this).val();
                country_shipment(data);

            });
            $('#txtCountryShipment').keyup(function () {

                var data = $(this).val();
                country_shipment(data);

            });
            $('#txtCountryShipment').keydown(function () {

                var data = $(this).val();
                country_shipment(data);

            });
        });

        function country(val) {

            var data = val;
            if (data == '') {
                $('#txtCountryShipment').val('');
            }
            //$('#hdn_Autosearch').val(data);

            if (data.indexOf("-") != -1) {


                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtCountryShipment').val(before);
                $('#txtCountryName').val(before);




            }
            else {

            }
        }
        function country_shipment(val) {

            var data = val;
            if (data == '') {
                $('#txtCountryShipment').val('');
            }
            //$('#hdn_Autosearch').val(data);

            if (data.indexOf("-") != -1) {


                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtCountryShipment').val(before);
                




            }
            else {

            }
        }

        function Port_origin(val) {

            var data = val;
            if (data == '') {
                //$('#txtCountryCode').val('');
            }

            $('#txtPortOrigin').val(val);
            $('#txtPortShipment').val(val);

        }

        $(function () {
            $("#txtCustomsHouse").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                        data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;




        });
        $(function () {
            $("#txtImporterName,#txtSellerName").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List",
                        data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {

                            response(data.d);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });

       
        $(function () {
            $("#txtCountryName,#txtCountryShipment").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Country_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
        
        $(function () {
            $("#txtPortOrigin,#txtPortShipment").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Port_Master_List",
                        data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
        
        $(function () {
            $("#txtBranchNo").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List",
                        data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('txtIECNo').value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });

        $(function () {
            $("#txtBranchSLNo").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_Branch_List",
                        data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('txtHighSeaSaleIECNo').value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });

        // call server side method
        //---------------------IMPORTER----------------------//
        function CallServerside_Importer(src, dest) {
            var ctrl = document.getElementById(src);
            // call server side method
            
            PageMethods.GetImporter(ctrl.value, CallSuccess_Importer, CallFailed, dest);

        }
        function CallServerside_Importer_Branch(src, dest) {
            var ctrl = document.getElementById(src).value;
            var ctrl1 = document.getElementById(dest).value;
            // call server side method
            //alert('l');
            if (ctrl != '') {

                var ieccode;
                ieccode = document.getElementById("txtIECNo").value;
                txtImporterName = document.getElementById("txtImporterName").value;

                if (txtImporterName.length <= 0) {

                    jAlert('ImporterName Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtImporterName").focus(); });


                    return false;


                }

                else {

                    if (ieccode.length < 10) {
                        jAlert('IEC code  Should be 10 digit numbers', 'GENERAL', function (r) { document.getElementById("txtIECNo").focus(); });

                        return false;
                    }

                    else {

                        PageMethods.GetImporter_Branchwise(ctrl, ctrl1, CallSuccess_Importer, CallFailed, dest);

                    }
                }
            }
        }

        //---------------------IMPORTER----------------------//
        //---------------------SELLER------------------------//

        function CallServerside_Seller(src, dest) {
            var ctrl = document.getElementById(src);
            // call server side method

            PageMethods.GetImporter(ctrl.value, CallSuccess_seller, CallFailed, dest);

        }

        function CallServerside_BranchSeller(src, dest) {
            var ctrl = document.getElementById(src).value;
            var ctrl1 = document.getElementById(dest).value;
            // call server side method
            //alert('l');
            if (ctrl != '') {

                var ieccode;
                ieccode = document.getElementById("txtHighSeaSaleIECNo").value;
                txtSellerName = document.getElementById("txtSellerName").value;

                if (txtImporterName.length <= 0) {

                    jAlert('Seller Name Field cannot be blank', 'GENERAL', function (r) { document.getElementById("txtSellerName").focus(); });


                    return false;


                }

                else {

                    if (ieccode.length < 10) {
                        jAlert('IEC code  Should be 10 digit numbers', 'GENERAL', function (r) { document.getElementById("txtHighSeaSaleIECNo").focus(); });

                        return false;
                    }

                    else {

                        PageMethods.GetImporter_Branchwise(ctrl, ctrl1, CallSuccess_seller, CallFailed, dest);

                    }
                }
            }

            //$(document).ready(function(){{jAlert('IEC', 'Adcode', function (r) {});}});
        }

        //---------------------SELLER------------------------//

       
        // call server side method

        // calling Importer

        // set the destination textbox value with the ContactName
        function CallSuccess_Importer(res, destCtrl) {
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
                var after6 = s[6];
                var after7 = s[7];

                document.getElementById("txtAddress1").value = before;
                document.getElementById("txtAddress2").value = after1;
                document.getElementById("txtAddress3").value = after2;
                document.getElementById("txtAddress4").value = after3;
                document.getElementById("txtAddress5").value = after4;
                document.getElementById("txtIECNo").value = after5;
                document.getElementById("txtBranchNo").value = after6;
                document.getElementById("hdn_ImporterType").value = after7;



            }
            else {

                document.getElementById("txtAddress1").value = "";
                document.getElementById("txtAddress2").value = "";
                document.getElementById("txtAddress3").value = "";
                document.getElementById("txtAddress4").value = "";
                document.getElementById("txtAddress5").value = "";
                document.getElementById("txtIECNo").value = "";
                document.getElementById("txtBranchNo").value = "";
                document.getElementById("hdn_ImporterType").value = "";
            }
        }
        // calling Importer

        // calling seller

        function CallSuccess_seller(res, destCtrl) {
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
                var after6 = s[6];

                document.getElementById("txtHighSeaSaleAddress").value = before;
                document.getElementById("txtHighSeaSaleAddress1").value = after1;
                document.getElementById("txtHighSeaSaleAddress2").value = after2;
                document.getElementById("txtHighSeaSaleAddress3").value = after3;
                document.getElementById("txtHighSeaSaleAddress4").value = after4;
                document.getElementById("txtHighSeaSaleIECNo").value = after5;
                document.getElementById("txtBranchSLNo").value = after6;



            }
            else {
                document.getElementById("txtHighSeaSaleAddress").value = "";
                document.getElementById("txtHighSeaSaleAddress1").value = "";
                document.getElementById("txtHighSeaSaleAddress2").value = "";
                document.getElementById("txtHighSeaSaleAddress3").value = "";
                document.getElementById("txtHighSeaSaleAddress4").value = "";
                document.getElementById("txtHighSeaSaleIECNo").value = "";
                document.getElementById("txtBranchSLNo").value = "";
            }
        }
        // calling seller
        // Importer Branch
         
        //Importer Branch
        // alert message on some failure
        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }
	</script>
    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
