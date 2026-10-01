<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="Drawback.aspx.cs" Inherits="ERoyal_Admin_Master_Drawback" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />

<style type="text/css">
    #Validation123
        {
            top: 35% !important;
            left: 55% !important;
            width: 100%;
            max-width: 62% !important;
            background-color: #fbdbdb !important;
            border: 3px solid #cc6b4d;
            height: 36% !important;
        }

</style>

<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("Drawback_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();

    }
      
</script>
    <script type ="text/javascript" >
        function validateLimit(obj, divID, maxchar) {

            objDiv = get_object(divID);

            if (this.id) obj = this;

            var remaningChar = maxchar - trimEnter(obj.value).length;

            if (objDiv.id) {
                objDiv.innerHTML = remaningChar + "";
            }
            if (remaningChar <= 0) {
                obj.value = obj.value.substring(maxchar, 0);
                if (objDiv.id) {
                    objDiv.innerHTML = "0 ";
                }
                return false;
            }
            else
            { return true; }
        }
        function get_object(id) {
            var object = null;
            if (document.layers) {
                object = document.layers[id];
            } else if (document.all) {
                object = document.all[id];
            } else if (document.getElementById) {
                object = document.getElementById(id);
            }
            return object;
        }

        function trimEnter(dataStr) {
            return dataStr.replace(/(\r\n|\r|\n)/g, "");
        }

</script>

<script type="text/javascript">


    function num1(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 27 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }

//    function numdot1(evt) {
//        var charCode = (evt.which) ? evt.which : event.keyCode
//        if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 46 || charCode > 46))
//            return false;
//        return true;
//    }

    function notn(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 47 || charCode > 47))
            return false;
        return true;
    }

    function char1(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
            return false;
        return true;
    }

    function ChangeCase(elem) {
        elem.value = elem.value.toUpperCase();
    }

    function numcharDOT(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 46 || charCode > 46))
            return false;
        return true;
    }


    function numdot1(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 46 || charCode > 46))
            return false;
        return true;
    }
    
    </script>

   <script type="text/javascript">
       function validate() {
           var txtDrawbackNo = document.getElementById("<%=txtDrawbackNo.ClientID%>").value;
           if (txtDrawbackNo.length <= 0) {
               alert("DrawbackNo cannot be blank");
               document.getElementById("<%=txtDrawbackNo.ClientID%>").focus();
               return false;
           }
           var txtNotnNo;
           txtNotnNo = document.getElementById("<%=txtNotnNo.ClientID%>").value;

           if (txtNotnNo.length <= 0) {


               alert("NotnNo cannot be blank");
               document.getElementById("<%=txtNotnNo.ClientID%>").focus();
               return false;
           }

           var txtNotnDate;
           txtNotnDate = document.getElementById("<%=txtNotnDate.ClientID%>").value;

           if (txtNotnDate.length <= 0) {


               alert("Notn Date cannot be blank");
               document.getElementById("<%=txtNotnDate.ClientID%>").focus();
               return false;

           }
           if (isDate(txtNotnDate)) {

           }
           else {
               alert('NotnDate is Invalid Date');
               document.getElementById("<%=txtNotnDate.ClientID%>").focus();
               return false;
           }
           var txtDBKRate;
           txtDBKRate = document.getElementById("<%=txtDBKRate.ClientID%>").value;

           if (txtDBKRate.length <= 0) {


               alert("Rate cannot be blank");
               document.getElementById("<%=txtDBKRate.ClientID%>").focus();
               return false;

           }


           var txtDescription;
           txtDescription = document.getElementById("<%=txtDescription.ClientID%>").value;

           if (txtDescription.length <= 0) {


               alert("Description cannot be blank");
               document.getElementById("<%=txtDescription.ClientID%>").focus();
               return false;
           }


       }


       function ValidateFile() {
           jQuery('#form1').validationEngine('detach');

           var UpdatePriorities = $("#ContentPlaceHolder1_ddl_Priority").val();
           var FileValues = $('#ContentPlaceHolder1_fileuploadExcel').val();
           var CTH_CODE = $('#ContentPlaceHolder1_txtCth_Code_Search').val();
           var Count = 1;
           var Msg = "";
           if (FileValues == "" || FileValues == null) {
               Msg += Count + "." + "Please Upload file \n";
               Count++;
           }
           if (UpdatePriorities == "0") {
               Msg += Count + "." + "Select Update Priority \n";
               Count++;
           }
           else {
               if (UpdatePriorities == '1') {
                   var response = confirm('Are You Sure want to Delete Old Records');

               }
           }
           if (Msg != "") {
               alert(Msg);
               return false;
           }
           else {
               return true;
           }
       }


       function Excel_File_Validation() {
           $('#Validation123').css("display", "block");
       }

       function ClosePop_up() {
           $('#Validation123').css("display", "none");
       }
        </script>
    
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
    <div >
        
         <div id="innerbox_MidMain_admin_catagory" style="height:360px">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - Drawback Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:240px">
                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_cess_Main_l">
                        <div id="tag_label_transact_Src">
                            Drawback No
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                           
                              <asp:TextBox ID="txtDrawbackNo" runat="server" MaxLength="15"  
                                  CssClass="validate[required] txtbox_none_Mid_transac_src" ONKEYPRESS="return numcharDOT(event)" TabIndex="1"></asp:TextBox>
           
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtDrawbackNo"
                                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                        </div>                     
                    </div>
                </div>
                <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px">
                    <div id="txt_container_Transact_Main_l"  style="width:250px">
                        <div id="tag_label_transact_Src">
                            NOTN No
                            <br />
                        </div>
                    
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtNotnNo" runat="server" MaxLength="15"  
                                 CssClass="validate[required] txtbox_none_Mid_transac_src" TabIndex="2" onkeypress="return notn(event)"
                   ></asp:TextBox>
              
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtNotnNo"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                        </div>
                       
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            NOTN Date
                        </div>
                      
                        <div id="txtcon-m_transaction_item_maindet">
                            
                             <asp:TextBox ID="txtNotnDate" runat="server"  Width="100px"
                                 CssClass="validate[required] txtbox_none_Mid_transac_item_maindet" MaxLength="10" TabIndex="3"></asp:TextBox>
                 <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtNotnDate"
                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                </asp:MaskedEditExtender>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtNotnDate"
                    Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                  <%--<asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator1" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"  ValidationGroup="draw" Display="None"
                    runat="server" ControlToValidate="txtNotnDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                    ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                        </div>
                        
                    </div>

                    <div id="txt_container_Transact_Main_l"  style="width:250px">
                        <div id="tag_label_transact_Src">
                            DBK Rate
                        </div>
                       
                        <div id="txtcon-m_transaction_item_maindet">
                           
                              <asp:TextBox ID="txtDBKRate" runat="server" MaxLength="15" 
                                  CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_src" TabIndex="4" onkeypress="return numdot1(event)" 
                  ></asp:TextBox>
               
            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtDBKRate"
                    FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                        </div>
                        
                    </div>
                </div>
                <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px">
                    
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            Value CAP
                        </div>
                       
                        <div id="txtcon-m_transaction_item_maindet">
                        
                            <asp:TextBox ID="txtDBKValueCAP" runat="server" MaxLength="15"  
                                CssClass="txtbox_none_Mid_transac_item_maindet" TabIndex="5"
                   ></asp:TextBox>
                
                        </div>
                       
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            Unit
                        </div>
                       
                        <div id="txtcon_m_admin_small_small_src">
                        
                             <asp:TextBox ID="txtUnit" runat="server" MaxLength="3"  onkeyup="autotab(this);"
                                 CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_src" TabIndex="6" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                    ></asp:TextBox>
                        </div>
                        
                    </div>


                      <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src">
                          No Of Unit
                        </div>
                       
                        <div id="txtcon_m_admin_small_small_src">
                        
                             <asp:TextBox ID="txtNo_Of_Units" runat="server" MaxLength="3"  onkeyup="autotab(this);"
                                 CssClass="txtbox_none_Mid_transac_src" TabIndex="7" ></asp:TextBox>
                        </div>
                        
                    </div>

                </div>

                    <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px">
                    <div id="txt_container_Transact_Main_l"  style="width:250px">
                        <div id="tag_label_transact_Src">
                            Customs
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                          
                               <asp:TextBox ID="txtCustoms" runat="server" MaxLength="15" 
                                   CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="9" onkeypress="return numdot1(event)"  ></asp:TextBox>
                
                    
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtCustoms" 
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                        </div>
                        
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                            Excise
                        </div>
                        
                        <div id="txtcon-m_transaction_src">
                        
                              <asp:TextBox ID="txtExcise" runat="server" MaxLength="15"  
                                  CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="10" onkeypress="return numdot1(event)" ></asp:TextBox>
                
                    
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="txtExcise"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                
                        </div>
                        
                    </div>
                </div>


                <div id="tag_admin_catagory_lft_in1" style="height:55px; width:800px">
                    <div id="txt_container_Transact_Main_l" style="width:650px">
                        <div id="tag_label_transact_Src">
                            Description</div>
                       
                        <div id="txtcon-m_transaction_src">
                           
                              <asp:TextBox ID="txtDescription" runat="server" MaxLength="300"   onkeyDown="return checkTextAreaMaxLength(this,event,'200');"  
                        onpaste="return checkTextAreaMaxLength(this,event,'200');"          CssClass="validate[required] txtbox_none_Mid_admin_remarks"  Width="400px" Height="40px" TextMode="MultiLine" TabIndex="8"
                  ></asp:TextBox>
                    
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtDescription"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                        </div>
                        
                    </div>
                    <div id="lblMsg4" style="display:none;">
                </div>
                </div>
            
                <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px;height:40px;">
                    <div id="txt_container_Transact_Main_l" >
                        <div id="tag_label_transact_Src">
                            Remarks</div>
                       
                        <div id="txtcon-m_transaction_src">
                         
                               <asp:TextBox ID="txtRemarks" runat="server" MaxLength="300" onkeyDown="return checkTextAreaMaxLength(this,event,'300');"
                                  onpaste="return checkTextAreaMaxLength(this,event,'300');"
                                   CssClass="txtbox_none_Mid_admin_remarks" TabIndex="11"
                 ></asp:TextBox>
                     
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtRemarks"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
           
                        </div>
                        
                    </div>
                    
               <div id="lblMsg2" style="display:none;">
                </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                   <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="16"  OnClick="btnNew_Click" CssClass="new"  CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"/>
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" OnClientClick="return validate();"
                     CssClass="save" TabIndex="12"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" TabIndex="13" OnClientClick="return validate();"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" TabIndex="14" CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');"/>

                 </div>
                    <div id="editbu">
                     <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="15"
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>
                      <%--  <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner">
                <div id="tag_Adminsrc_inner_lft" style="width:1050px">
                    <div id="tag_transact_lft_in1" style="width:350px">
                        <div id="txt_container_Transact_Main_l" style="width:170px">
                            <div id="tag_label_transact_Src" style="width:90px">
                                Drawback No
                            </div>
                           
                            <div id="txtcon-m_transaction_src" style="width:70px">
                             
                                <asp:TextBox ID="txtDrawbacknoSearch" runat="server" onkeypress="return numcharDOT(event)" onfocus="jQuery('#form1').validationEngine('hide');"
                                    CssClass="txtbox_none_Mid_transac_src"  style="width:70px" TabIndex="15"></asp:TextBox>
                            </div>
                            
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width:180px">
                            <div id="tag_label_transact_Src" style="width:70px">
                                Description
                            </div>
                            
                            <div id="txtcon-m_transaction_src" style="width:100px">
                             
                                      <asp:TextBox ID="txtDescriptionSearch" runat="server"  onfocus="jQuery('#form1').validationEngine('hide');" Width="200PX"
                                          CssClass="txtbox_none_Mid_transac_src" style="width:100px" MaxLength="100" TabIndex="16"></asp:TextBox>
                            </div>
                            
                        </div>
                    </div>
              
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="17"></a>
                    </div>
                    <div id="small-butt-left">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" target="_top" tabindex="18"></a>
                    </div>
                </div>

                <div id="editbu" style="width: 8%;margin-top: -7px; margin-left:5px">
                                       
                           <asp:Panel ID="GridDownloadTemplate" runat="server">
                                <asp:LinkButton ID="lnkExport" runat="server" OnClick="lnkExport_Click"  style="text-decoration: none; color: inherit;">
                            <span style="vertical-align: middle;">
                                <asp:Image ID="ImageExport" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Excel" />
                       
                             <span >Download</span>
                            </span>
                        </asp:LinkButton>
                        </asp:Panel>

                       <span id="NewDrawbackTemplate" runat="server">
                           <a href="../Submission/Export_Excel_Format/DRAWBACK_MASTER_TEMPLATE.xlsx" style="text-decoration: none; color: inherit;">
           
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px" Height="28px" ToolTip="Download Template" />
                               <br />         
                            <span>New</span>               
                           </a>
                       </span>

                    </div>

                     <div id="editbu" style="margin-top: 20px; margin-left: -1%; width:180px"  >
                              <asp:FileUpload ID="fileuploadExcel" runat="server" style="Width:200px" onchange="document.getElementById('btn_upload').click();"
                                  TabIndex="14" />
                              <asp:Button ID="btn_upload" runat="server" Style="display: none;" />
                          </div>

                           <div id="editbu" style="width: 110px; margin-top: 18px;">
                              <div id="editbu" style="width: 98px; margin-top: -33px; margin-bottom: 10px;">
                                  Update Priority</div>
                              <div id="editbu">
                                  <asp:DropDownList ID="ddl_Priority" AutoPostBack="false" runat="server" Width="90px"
                                      TabIndex="13">
                                      <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="Insert New" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="Delete & New Insert" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Update & Insert" Value="2"></asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                          </div>

                           <div id="editbu" style="margin-top: 15px;">
                              <asp:Button ID="btnUpload" runat="server" Width="100px" Height="25px" Text="Upload"
                                   OnClientClick="return ValidateFile();" OnClick="btn_upload_Click"  CssClass="autowidmovebut"
                                  TabIndex="16" />
                          </div>

            </div>
        </div>
          </div>
          <div id="Main_GridView" runat="server">
        <div id="innerbox_MidMain_Grid_Admin_catagory">
            <div id="tag_srcinner1grid">
                <div id="allbu">
                    <input type="submit" value="Submit" class="allgrid" /></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">#</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">Z</a></div>
                </div>
            </div>
            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container">
                 <asp:GridView runat="server" ID="gvdetails" DataKeyNames="DRAWBACK_ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" 
                            GridLines="Both" CssClass="grid-view"
                                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True"
                                    PageSize="10" AllowPaging="True" onselectedindexchanged="gvdetails_SelectedIndexChanged"
                            OnRowDataBound="gvdetails_RowDataBound" 
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" 
                                    CellPadding="1" CellSpacing="1">
                                   <%-- <FooterStyle BackColor="#D59200" ForeColor="White" Font-Bold="True" />
                                    <PagerStyle BackColor="#D59200" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"
                                        PageButtonCount="10" Mode="NextPreviousFirstLast" />--%>
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                        
                                    <Columns>
                     <asp:CommandField ShowSelectButton="True">
    
<HeaderStyle CssClass="hideGridColumn" />

    

<ItemStyle CssClass="hideGridColumn" />
    
</asp:CommandField>

                                        
<asp:BoundField DataField="DRAWBACK_SLNO" HeaderText="DRAWBACK NO" />
<asp:BoundField DataField="DRAWBACK_DESCRIPTION" HeaderText="DESCRIPTION" />
<asp:BoundField DataField="DRAWBACK_RATE" HeaderText="RATE" />
<asp:BoundField DataField="DRAWBACK_VALUE_CAP" HeaderText="CAP VALUE" />
<asp:BoundField DataField="DRAWBACK_UNIT" HeaderText="UNIT" />
<asp:BoundField DataField="DRAWBACK_NOOFUNITS" HeaderText="NO OF UNIT" />


</Columns>
                                    
                               <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
            <div class="pagination" id="Div_Pagination" runat="server">
           
  <div id="tag_label_transaction_popup_IGM_Container">Page No.</div>
  
              <div id="txtcon-m_transaction_list1_fcl">
   <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" 
                      CssClass="listtxt_transac_FCL" 
                      onselectedindexchanged="ddlSelectPageno_SelectedIndexChanged">
                 </asp:DropDownList>
                         
 

 </div>

              
       <span class="disabled"><asp:LinkButton CommandName="First"  ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage" >« Previous</asp:LinkButton></span>
      
       <span class="selected"> Record 
        <asp:Label ID="lblCurrentPage" runat="server" ></asp:Label> - <asp:Label ID="lblTotalPages" runat="server" ></asp:Label></span>
       
  
      <span class="disabled"><asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage" >Next</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Last"  ID="btnLast" runat="server" OnCommand="ChangePage" >Last</asp:LinkButton>   </span>  
           
      </div>
        </div>

        </div>
    </div>

    <div id="Validation123" style="display: none;">
                  <div id="popupwindow_closebut_right_new" style="margin-top: -12px; margin-right: 4px;">
                      <input type="close" value="Submit" class="clsicon_new" onclick="ClosePop_up()" style="width: 23px;
                          height: 27px;">
                  </div>
                  <asp:Label ID="Label12" runat="server"></asp:Label>
                  <div style="height: 362px;overflow: auto;">
                      <div style="margin-top: 13px;">
                          <asp:GridView ID="gv_Preview" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                              BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                              CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                              OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                              Width="100%">
                              <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                  CssClass="column_style_right" BorderWidth="1px" />
                          </asp:GridView>
                      </div> 
                  </div>
              </div>
     </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Content>