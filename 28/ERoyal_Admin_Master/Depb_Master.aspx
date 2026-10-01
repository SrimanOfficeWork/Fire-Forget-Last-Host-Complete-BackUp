<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="Depb_Master.aspx.cs" Inherits="ERoyal_Admin_Master_Depb_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />

<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("Depb_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();

    }    
</script>

    <script type="text/javascript">

        function ConfirmUser() {

            var i = confirm("Do you want to Delete the User?");
            if (i == 0) {
                return false;
            }
            else {


                document.getElementById('btnNew').click();
                return true;
            }
        }
</script>

<script type="text/javascript">

    function num1(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 27 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }

    function numdot1(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 46 || charCode > 46))
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

    function numchar2(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 27 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
            return false;
        return true;
    }

    function numcharspl2(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 32 && (charCode < 44 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
            return false;
        return true;
    }


    function numchar3(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 32 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
            return false;
        return true;
    }
           
    </script>
    <script language="JavaScript" type="text/javascript">


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
            else {
                return true;
            }
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
        function validate() {
            var txtDepbGroupCode = document.getElementById("<%=txtDepbGroupCode.ClientID%>").value;
            if (txtDepbGroupCode.length <= 0) {
                alert("Depb Code cannot be blank");
                document.getElementById("<%=txtDepbGroupCode.ClientID%>").focus();
                return false;
            }
            if (txtDepbGroupCode.length < 2) {
                alert("Depb Code should be 2 digit numbers ");
                document.getElementById("<%=txtDepbGroupCode.ClientID%>").focus();
                return false;
            }
            var txtDepbItemCode = document.getElementById("<%=txtDepbItemCode.ClientID%>").value;
            if (txtDepbItemCode.length <= 0) {
                alert("Item Code cannot be blank");
                document.getElementById("<%=txtDepbItemCode.ClientID%>").focus();
                return false;
            }
            var txtDepbEffectDate = document.getElementById("<%=txtDepbEffectDate.ClientID%>").value;
            if (txtDepbEffectDate.length <= 0) {
                alert("EffectDate cannot be blank");
                document.getElementById("<%=txtDepbEffectDate.ClientID%>").focus();
                return false;
            }
            if (isDate(txtDepbEffectDate)) {

            }
            else {
                alert('EffectDate is Invalid Date');
                document.getElementById("<%=txtDepbEffectDate.ClientID%>").focus();
                return false;
            }
            var txtDepbPBNo = document.getElementById("<%=txtDepbPBNo.ClientID%>").value;
            if (txtDepbPBNo.length <= 0) {
                alert("PBNo cannot be blank");
                document.getElementById("<%=txtDepbPBNo.ClientID%>").focus();
                return false;
            } 
            var txtDepbRate = document.getElementById("<%=txtDepbRate.ClientID%>").value;
            if (txtDepbRate.length <= 0) {
                alert("Rate cannot be blank");
                document.getElementById("<%=txtDepbRate.ClientID%>").focus();
                return false;
            } 
            var txtDescription = document.getElementById("<%=txtDescription.ClientID%>").value;
            if (txtDescription.length <= 0) {
                alert("Description cannot be blank");
                document.getElementById("<%=txtDescription.ClientID%>").focus();
                return false;
            } 
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
                    Admin - DEPB Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:240px">
                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_cess_Main_l">
                        <div id="tag_label_transact_Src">
                            DEPB Code
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtDepbGroupCode" runat="server" MaxLength="2"   
                                 CssClass="validate[required,custom[integer],minSize[2]] txtbox_none_Mid_transac_src" 
                                 TabIndex="1" onkeypress="return num1(event)" 
                   ></asp:TextBox>
                

                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtDepbGroupCode"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                        </div>
                      
                    </div>
                </div>
                <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px">
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                             Item Code<br />
                        </div>
                      
                        <div id="txtcon-m_transaction_src">
                         
                              <asp:TextBox ID="txtDepbItemCode" runat="server" MaxLength="10"   
                                  CssClass="validate[required] txtbox_none_Mid_transac_src" TabIndex="2" onkeypress="return numchar2(event)"
                   ></asp:TextBox>
             
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtDepbItemCode"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                        </div>
                       
                    </div>
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src">
                             Effect Date
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                         <asp:TextBox ID="txtDepbEffectDate" runat="server" 
                                CssClass="validate[required] txtbox_none_Mid_transac_src" MaxLength="10" TabIndex="3"></asp:TextBox>
                 <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDepbEffectDate"
                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                </asp:MaskedEditExtender>
                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDepbEffectDate" 
                    Format="dd/MM/yyyy">
                </asp:CalendarExtender>
                <%--  <asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator1" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"  ValidationGroup="draw" Display="None"
                    runat="server" ControlToValidate="txtDepbEffectDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                    ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
               --%>         </div>
                      
                    </div>
                </div>
                <div id="tag_admin_catagory_lft_in1" style="height:25px; width:800px">
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                             PB No
                        </div>
                        
                        <div id="txtcon-m_transaction_src">
                           
                            <asp:TextBox ID="txtDepbPBNo" runat="server" MaxLength="15"  
                                CssClass="validate[required] txtbox_none_Mid_transac_src" TabIndex="4" onkeypress="return numcharspl2(event)"
                   ></asp:TextBox>
               
                <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtDepbPBNo"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                        </div>
                       
                    </div>
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src">
                             Claim Type
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                            
                            <asp:TextBox ID="txtDepbClaimType" runat="server" MaxLength="15" 
                       CssClass="txtbox_none_Mid_transac_src" TabIndex="5" onkeypress="return numchar3(event)"
                    ></asp:TextBox>
                        </div>
                        
                    </div>
                </div>
                <div id="tag_admin_catagory_lft_in1"  style="height:25px; width:800px">
                    <div id="txt_container_Transact_Main_l" style="width:250px">
                        <div id="tag_label_transact_Src">
                             Rate
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                            
                            <asp:TextBox ID="txtDepbRate" runat="server" MaxLength="15"  
                                CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_src" TabIndex="6" onkeypress="return numdot1(event)"
                    ></asp:TextBox>
                     
              <%--  <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtDepbRate"
                    FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                
                        </div>
                       
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width:260px">
                        <div id="tag_label_transact_Src">
                             Spl Rate
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                          
                               <asp:TextBox ID="txtDepbSplRate" runat="server" MaxLength="15"  
                                   CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="7" onkeypress="return numdot1(event)"  ></asp:TextBox>
                  
                    
             
                        </div>
                        </div>

                        <div id="txt_container_Transact_Main_l" style="width:200px">
                         <div id="tag_label_transact_Src" style="width:50px">
                             Unit
                        </div>
                        
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtDepbUnit" runat="server" MaxLength="15"  
                                 CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_src" TabIndex="8" onkeypress="return char1(event)" onblur="return ChangeCase(this);"
                    ></asp:TextBox>
                    
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtDepbUnit"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                
                        </div>
                        
                    </div>
                </div>
               
                <div id="tag_admin_catagory_lft_in1" style="height:55px; width:800px">
                    <div id="txt_container_Transact_Main_l" style="width:650px">
                        <div id="tag_label_transact_Src">
                            Description</div>
                        
                       <div id="txtcon-m_transaction_src">
                          
                             <asp:TextBox ID="txtDescription" runat="server" MaxLength="300" onkeyDown="return checkTextAreaMaxLength(this,event,'300');" 
                   onpaste="return checkTextAreaMaxLength(this,event,'300');"    CssClass="validate[required] txtbox_none_Mid_admin_remarks"  TabIndex="9" 
                    Width="400px" Height="40px" TextMode="MultiLine" ></asp:TextBox>
                     
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtDescription"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                       
                       </div> 
                    </div>
                    <div id="lblMsg2" style="display:none;">
                              </div>
                </div>
                <div id="tag_admin_catagory_lft_in1" style="height:40px">
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src">
                            Remarks</div>

                             <div id="txtcon-m_transaction_src">
                             <asp:TextBox ID="txtRemarks" runat="server" MaxLength="300"  
                                 CssClass="txtbox_none_Mid_admin_remarks" TabIndex="10" onkeyup="return validateLimit(this, 'lblMsg3', 300)" ></asp:TextBox>
                 
                     
                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtRemarks"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                             <br />
                       
                       </div>
                    </div>
                      <div id="lblMsg3" style="display:none;">
                              </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                       <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="14"  OnClick="btnNew_Click" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" OnClientClick="return validate();"
                     CssClass="save" TabIndex="11"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" TabIndex="11" OnClientClick="return validate();"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" TabIndex="12" CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');"/>

                 </div>
                    <div id="editbu">
                     <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="13"
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>

                      <%--  <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner">
                <div id="tag_Adminsrc_inner_lft" style="width:800px">
                    <div id="tag_transact_lft_in1" style="width:540px">
                        <div id="txt_container_Transact_Main_l" style="width:250px">
                            <div id="tag_label_transact_Src" style="width:120px">
                                DEPB Group Code
                            </div>
                           
                            <div id="txtcon-m_transaction_src" style="width:120px">
                              
                                <asp:TextBox ID="txtDepbGroupCodeSearch" runat="server" MaxLength="2"  onfocus="jQuery('#form1').validationEngine('hide');"
                                    CssClass="txtbox_none_Mid_transac_src" TabIndex="15" Width="95px"></asp:TextBox>
                            </div>
                            
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src" style="width:120px">
                                DEPB Item Code
                            </div>
                           
                            <div id="txtcon-m_transaction_src">
                               
                                 <asp:TextBox ID="txtDepbItemCodeSearch" runat="server" MaxLength="10" onfocus="jQuery('#form1').validationEngine('hide');"
                                     CssClass="txtbox_none_Mid_transac_src" TabIndex="16" onkeypress="return numchar2(event)"></asp:TextBox>
                            </div>
                           
                        </div>
                    </div>
               
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" 
                            onserverclick="btnSearch_Click" tabindex="17"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../E_royal_Impex_Main.aspx" class="cancelButt" target="_top" TabIndex="18"></a>
                    </div>
                </div>
                 </div>
            </div>
        </div>
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
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="DEPB_ID" ShowHeader="true"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" 
                            GridLines="Both" CssClass="grid-view"
                                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True"
                                    PageSize="15" AllowPaging="True" onselectedindexchanged="gvdetails_SelectedIndexChanged"
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


 
                     <asp:BoundField DataField="DEPB_GROUP_CODE" HeaderText="GROUP CODE" />
<asp:BoundField DataField="DEPB_ITEM_CODE" HeaderText="ITEM CODE" />
<asp:BoundField DataField="DEPB_EFFECT_DATE" HeaderText="EFFECT DATE" />
<asp:BoundField DataField="DEPB_PB_NO" HeaderText="PB NO" />
<asp:BoundField DataField="DEPB_RATE" HeaderText="RATE" />
<asp:BoundField DataField="DEPB_DESCRIPTION" HeaderText="DESCRIPTION" />

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
     </ContentTemplate>
    </asp:UpdatePanel>
  
  </asp:Content>