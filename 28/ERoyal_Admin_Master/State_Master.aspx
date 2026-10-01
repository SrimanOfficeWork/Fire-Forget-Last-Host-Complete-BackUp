<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="State_Master.aspx.cs" Inherits="ERoyal_Admin_Master_State_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

  <%--<link href="../Admin_main.css" rel="stylesheet" media="screen, projection" type="text/css" />--%>

    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />

<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("State_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();

    }
      
</script>
     <script type="text/javascript">
         function pin(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 27 && (charCode < 48 || charCode > 57))
                 return false;
             return true;
         }

         function cha1(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                 return false;
             return true;
         }
         </script>

         <script type="text/javascript">
             function ChangeCase(elem) {
                 elem.value = elem.value.toUpperCase();
             }
  </script>
  <script type="text/javascript">
      function validate() {
          var txtStateCode = document.getElementById("<%=txtStateCode.ClientID%>").value;
          if (txtStateCode.length <= 0) {
              alert("State Code cannot be blank");
              document.getElementById("<%=txtStateCode.ClientID%>").focus();
              return false;
          }
          if (txtStateCode.length < 2) {
              alert("State Code should be 2 digit numbers");
              document.getElementById("<%=txtStateCode.ClientID%>").focus();
              return false;
          }
          var txtStateName = document.getElementById("<%=txtStateName.ClientID%>").value;
          if (txtStateName.length <= 0) {
              alert("State Name cannot be blank");
              document.getElementById("<%=txtStateName.ClientID%>").focus();
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
        
         <div id="innerbox_MidMain_admin_catagory" style="height:230px">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - State Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:110px">
                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            State Code
                        </div>
                       
                        <div id="txtcon-m_transaction_item_maindet" style="width:100px">
                       
                              <asp:TextBox ID="txtStateCode" runat="server" MaxLength="2" onkeypress="return pin(event)" 
                                  CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet" TabIndex="1" ></asp:TextBox>
                 
                         </div>

                           <div id="tag_label_transact_Src">
                            State Name
                        </div>
                      
                        <div id="txtcon_m_Admin_name">
                            
                              <asp:TextBox ID="txtStateName" runat="server" MaxLength="50" Height="15px" onkeypress="return cha1(event)" onblur="return ChangeCase(this);"
                                  CssClass="validate[required,custom[onlyLetterSp]] txtbox_none_Mid_admin_name" TabIndex="2"  Width="205px"></asp:TextBox>
                            </div>                     
                    </div>
                </div>


                <%--<div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            State Name
                        </div>
                      
                        <div id="txtcon_m_Admin_name">
                            
                              <asp:TextBox ID="txtStateName" runat="server" MaxLength="50" Height="15px" onkeypress="return cha1(event)" onblur="return ChangeCase(this);"
                                  CssClass="validate[required,custom[onlyLetterSp]] txtbox_none_Mid_admin_name" TabIndex="2"></asp:TextBox>
                            </div>
                        
                    </div>
                </div>--%>

                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            Remarks</div>
                       
                        <div id="txtcon_m_Admin_remarks">
                           
                             <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200"   
                                 CssClass="txtbox_none_Mid_admin_remarks" TabIndex="3"
           ></asp:TextBox>
         <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtRemarks" FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
        </asp:FilteredTextBoxExtender>--%>
                            </div>
                        
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                   <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="7"  OnClick="btnNew_Click" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" CssClass="new" />
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" OnClientClick="return validate();"
                     CssClass="save" TabIndex="4"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" TabIndex="4" OnClientClick="return validate();"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" CssClass="dlete" TabIndex="5" OnClientClick="return confirm('Are you sure want to delete?');"/>

                 </div>
                    <div id="editbu">
                     <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="6"
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>
                      <%--  <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner">
                <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l" style="width:220px">
                            <div id="tag_label_transact_Src">
                                State Code.</div>
                           
                            <div id="txtcon-m_transaction_item_maindets">
                            
                                 <asp:TextBox ID="txtStateCodeSearch" MaxLength="2" runat="server"  onfocus="jQuery('#form1').validationEngine('hide');"
                                     CssClass="txtbox_none_Mid_transac_item_maindet" TabIndex="8" onkeypress="return pin(event)" ></asp:TextBox>
                 
                <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtStateCodeSearch"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                                </div>
                           
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                State Name
                            </div>
                            
                            <div id="txtcon-m_Exchange">
                              
            <asp:TextBox ID="txtStateNameSearch" runat="server"  CssClass="txtbox_none_Mid" TabIndex="9" onkeypress="return cha1(event)" onfocus="jQuery('#form1').validationEngine('hide');"></asp:TextBox>
                                
                                
                                </div>
                            
                        </div>
                    </div>
                </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                                              <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="10" ></a>

                    </div>
                    <div id="small-butt-rght">
                        <a href="../E_royal_Impex_Main.aspx" class="cancelButt" target="_top" tabindex="11"></a>
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
                <div id="Admin_Main_Grid_Container" >
                   <asp:GridView runat="server" ID="gvdetails" DataKeyNames="STATE_ID" ShowHeader="true" 
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" 
                            GridLines="Both" CssClass="grid-view"
                                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True"
                                    PageSize="15" AllowPaging="True" onselectedindexchanged="gvdetails_SelectedIndexChanged"
                            OnRowDataBound="gvdetails_RowDataBound" 
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" 
                                    CellPadding="1" CellSpacing="1">
                                 
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                        
                                    <Columns>
                     <asp:CommandField ShowSelectButton="True">
    
<HeaderStyle CssClass="hideGridColumn" />

    

<ItemStyle CssClass="hideGridColumn" />
    
</asp:CommandField>

 
<asp:BoundField DataField="STATE_CODE" HeaderText="STATE CODE" />
<asp:BoundField DataField="STATE_NAME" HeaderText="STATE NAME" />
<asp:BoundField DataField="STATE_REMARKS" HeaderText="REMARKS" />

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
