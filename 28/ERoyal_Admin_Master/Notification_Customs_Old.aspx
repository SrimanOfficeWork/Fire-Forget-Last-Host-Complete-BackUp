
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="Notification_Customs_Old.aspx.cs" Inherits="ERoyal_Admin_Master_Notification_Customs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<link href="../Admin_main.css" rel="stylesheet" media="screen, projection" type="text/css" />
<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("NotnCustom_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();
    }
      
</script>
<script type="text/javascript">
    function validate() {
        var txtNotification_Customs_NOTN = document.getElementById("<%=txtNotification_Customs_NOTN.ClientID%>").value;
        if (txtNotification_Customs_NOTN.length <= 0) {
            alert("Customs NOTN cannot be blank");
            document.getElementById("<%=txtNotification_Customs_NOTN.ClientID%>").focus();
            return false;
        }

        var txtNotification_Customs_NOTN_SL = document.getElementById("<%=txtNotification_Customs_NOTN_SL.ClientID%>").value;
        if (txtNotification_Customs_NOTN_SL.length <= 0) {
            alert("Customs_NOTN_SL cannot be blank");
            document.getElementById("<%=txtNotification_Customs_NOTN_SL.ClientID%>").focus();
            return false;
        }
        var txtNotification_Customs_CTH = document.getElementById("<%=txtNotification_Customs_CTH.ClientID%>").value;
        if (txtNotification_Customs_CTH.length <= 0) {
            alert("Notification_Customs_CTH cannot be blank");
            document.getElementById("<%=txtNotification_Customs_CTH.ClientID%>").focus();
            return false;
        }
        if (txtNotification_Customs_CTH.length < 8) {
            alert("Notification_Customs_CTH should be 8 Characters");
            document.getElementById("<%=txtNotification_Customs_CTH.ClientID%>").focus();
            return false;
        }
        var txtNotification_Customs_Applicable = document.getElementById("<%=txtNotification_Customs_Applicable.ClientID%>").value;
        if (txtNotification_Customs_Applicable.length <= 0) {
            alert("Notification_Customs_Applicable cannot be blank");
            document.getElementById("<%=txtNotification_Customs_Applicable.ClientID%>").focus();
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
        
        <div id="innerbox_MidMain_admin_noticust">
            <div id="tag_srcinner1">
             <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - Notification Custom Master
                </div>
            </div>
            <div id="tag_admin_ceth_src_inner">
                <div id="tag_admin_ceth_lft_in1">
                    <div id="txt_container_admin_ceth_Main_l">
                        <div id="tag_label_admin_ceth_Src">
                             Customs NOTN
                        </div>
                       
                        <%--<div id="txtcon-m_transaction_src">                           --%>
                             <asp:TextBox ID="txtNotification_Customs_NOTN" runat="server" MaxLength="8"  
                                 CssClass="validate[required]  txtbox_none_Mid_transac_src" TabIndex="1" onkeypress="return notn(event)" ></asp:TextBox>
                       <%-- </div>--%>
                      
                    </div>
                </div>


                <div id="tag_admin_cess_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                              NOTN SL
                        </div>
                       
                        <div id="txtcon_m_Admin_name">
                           
                             <asp:TextBox ID="txtNotification_Customs_NOTN_SL" runat="server" onkeypress="return NOTNSLNO(event)" 
                                 MaxLength="10"  CssClass="validate[required] txtbox_none_Mid_transac_src" TabIndex="2" ></asp:TextBox>          
                
                        </div>
                       
<%--                   </div>
                    <div id="txt_container_admin_catagory_Main_l">--%>
                        <div id="tag_label_transact_Src">
                             CTH
                        </div>
                       
                        <div id="txtcon_m_Admin_name">
                         
                              <asp:TextBox ID="txtNotification_Customs_CTH" runat="server" MaxLength="8" 
                                  CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Mid_transac_src" TabIndex="3" onkeypress="return pin(event)"
                           ></asp:TextBox>
 
                        </div>
                       
                    </div>
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                              BCD Rate
                        </div>
                        
                        <div id="txtcon_m_Admin_name">
                           
                             <asp:TextBox ID="txtNotification_Customs_BCD_Rate" runat="server" MaxLength="10" 
                   CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="4" 
                                 onkeypress="return numdot1(event)"  ></asp:TextBox>

                        </div>                     
                    </div>
                </div>


                <%--<div id="tag_admin_ceth_lft_in1">
                    <div id="txt_container_admin_ceth_Main_l">
                        <div id="tag_label_admin_ceth_Src">
                              NOTN SL
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtNotification_Customs_NOTN_SL" runat="server" onkeypress="return NOTNSLNO(event)" 
                                 MaxLength="10"  CssClass="validate[required] txtbox_none_Mid_transac_src" TabIndex="2" ></asp:TextBox>          
                
                        </div>
                       
                   </div>
                    <div id="txt_container_admin_ceth_Main_l">
                        <div id="tag_label_admin_ceth_Src">
                             CTH
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                         
                              <asp:TextBox ID="txtNotification_Customs_CTH" runat="server" MaxLength="8" 
                                  CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Mid_transac_src" TabIndex="3" onkeypress="return pin(event)"
                           ></asp:TextBox>
 
                        </div>
                       
                    </div>
                    <div id="txt_container_admin_cth_Main_l">
                        <div id="tag_label_admin_cth_Src">
                              BCD Rate
                        </div>
                        
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtNotification_Customs_BCD_Rate" runat="server" MaxLength="10" 
                   CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" TabIndex="4" 
                                 onkeypress="return numdot1(event)"  ></asp:TextBox>

                        </div>
                       
                    </div>
                </div>--%>
               <%-- <div id="tag_admin_noticus_lft_in1">--%>
                    <div id="txt_container_admin_ceth_Main_l">
                        <div id="tag_label_admin_ceth_Src">
                              BCD SPL
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                          
                            <asp:TextBox ID="txtNotification_Customs_BCD_SPL" runat="server" MaxLength="10" onkeypress="return numdot1(event)"
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" 
                                TabIndex="5" 
               ></asp:TextBox>
              
                <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtNotification_Customs_BCD_SPL"
                    FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                        </div>
                       
                    </div>
                    <div id="txt_container_admin_ceth_Main_l">
                        <div id="tag_label_admin_ceth_Src">
                             BCD Unit</div>
                        
                        <div id="txtcon-m_transaction_src">
                          
                             <asp:TextBox ID="txtNotification_Customs_BCD_Unit" runat="server" MaxLength="3" 
                                 CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_src" 
                                 TabIndex="6"  onkeypress="return cha(event)" onblur="return ChangeCase(this);" 
                 ></asp:TextBox>
                       <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="txtNotification_Customs_BCD_Unit"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
             
                        </div>
                       
                    </div>
                    <div id="txt_container_admin_cth_Main_l">
                        <div id="tag_label_admin_cth_Src">
                             BCD SPL Type
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                           
                            <asp:TextBox ID="txtNotification_Customs_BCD_SPL_Type" runat="server" MaxLength="10" 
                             CssClass="txtbox_none_Mid_transac_src" TabIndex="7" ></asp:TextBox>

                        </div>
                    </div>
               <%-- </div>--%>
                <%--<div id="tag_admin_noticus_lft_in1">--%>
                    <div id="txt_container_admin_ceth_Main_l">
                        <div id="tag_label_admin_ceth_Src">
                              CVD Rate
                        </div>
                        
                        <div id="txtcon-m_transaction_src">
                           
                             <asp:TextBox ID="txtNotification_Customs_CVD_Rate" runat="server" 
                                 MaxLength="10"  
                                 CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" onkeypress="return numdot1(event)"
                                 TabIndex="8" 
                  ></asp:TextBox>
                 <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtNotification_Customs_CVD_Rate"
                    FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                        </div>
                       
                    </div>
                    <div id="txt_container_admin_ceth_Main_l">
                        <div id="tag_label_admin_ceth_Src">
                              CVD SPL
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                          
                             <asp:TextBox ID="txtNotification_Customs_CVD_SPL" runat="server" MaxLength="10" 
                                 CssClass="validate[custom[number]] txtbox_none_Mid_transac_src" 
                                 TabIndex="9" onkeypress="return numdot1(event)"
                 ></asp:TextBox>
                 <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="txtNotification_Customs_CVD_SPL"
                    FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
     
                        </div>
                       
                    </div>
                    <div id="txt_container_admin_cth_Main_l">
                        <div id="tag_label_admin_cth_Src">
                              CVD Unit</div>
                       
                        <div id="txtcon-m_transaction_src">
                         
                            <asp:TextBox ID="txtNotification_Customs_CVD_Unit" runat="server" 
                                MaxLength="3"  CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_src" TabIndex="10" onkeypress="return cha(event)" onblur="return ChangeCase(this);"
                  ></asp:TextBox>
                <%-- <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="txtNotification_Customs_CVD_Unit"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
     
                        </div>
                       
                    </div>
               <%-- </div>--%>
             <%--   <div id="tag_admin_noticus_lft_in1">--%>
                    <div id="txt_container_admin_ceth_Main_l">
                        <div id="tag_label_admin_ceth_Src">
                              CVD Type
                        </div>
                       
                        <div id="txtcon-m_transaction_src">
                         
                             <asp:TextBox ID="txtNotification_Customs_CVD_SPL_Type" runat="server" 
                                 MaxLength="10"  CssClass="txtbox_none_Mid_transac_src" TabIndex="11" ></asp:TextBox>
                  
                 <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="txtNotification_Customs_CVD_SPL_Type"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>
                        </div>
                        
                    </div>
                    <div id="txt_container_admin_ceth_Main_l">
                        <div id="tag_label_admin_ceth_Src">
                             Customs Applicable
                        </div>
                      
                        <div id="txtcon-m_transaction_src">
                        
                             <asp:TextBox ID="txtNotification_Customs_Applicable" runat="server" onkeypress="return cha(event)"
                                 MaxLength="1" 
                                 CssClass="validate[required,custom[onlyLetterSp]] txtbox_none_Mid_transac_src" 
                                 TabIndex="12"  ></asp:TextBox>
                        </div>
                        
                    </div>
              <%--  </div>--%>
                <div id="tag_admin_depb_max_lft_in1">
                    <div id="txt_container_admin_depb_desc_Main_l">
                        <div id="tag_label_admin_Src">
                            Remarks</div>
                       
                        <div id="txtcon_m_admin_Maxtxt">
                            
                             <asp:TextBox ID="txtRemarks" runat="server"  MaxLength="200" 
                               onkeyDown="return checkTextAreaMaxLength(this,event,'200');" onpaste="return checkTextAreaMaxLength(this,event,'200');"
                                 CssClass="txtbox_none_admin_DEPB_Maxtxt" TextMode="MultiLine" TabIndex="13"
                 ></asp:TextBox>
                     
                <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="txtRemarks"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                        </div>
                       
                    </div>

                    
<div id="lblMsg2" style="display:none;">
                </div>

                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="17"   OnClick="btnNew_Click" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"/>
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" OnClientClick="return validate();"
                     CssClass="save" TabIndex="14"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" TabIndex="14" OnClientClick="return validate();"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server" TabIndex="15"   OnClick="btnDelete_Click" CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');"/>

                 </div>
                    <div id="editbu">
                       <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="16" 
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_admin_ceth_src_inner2">
                <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_admin_ceth_src_lft_in1">
                        <div id="txt_container_admin_ceth_src_small">
                            <div id="tag_label_transact_Src">
                                 Customs NOTN
                            </div>
                           
                            <div id="txtcon-m_transaction_src">
                             
                                 <asp:TextBox ID="txtNotification_Customs_NOTN_Search" runat="server" onfocus="jQuery('#form1').validationEngine('hide');"
                                     MaxLength="8"  CssClass="txtbox_none_Mid_transac_src" TabIndex="18"></asp:TextBox>
                            </div>
                            
                        </div>
                        <div id="txt_container_admin_ceth_src_long1">
                            <div id="tag_label_admin_ceth_long_Src">
                                 Customs NOTN SL
                            </div>
                            
                            <div id="txtcon-m_Exchange">
                             
                                  <asp:TextBox ID="txtNotification_Customs_NOTN_SL_Search" runat="server" onfocus="jQuery('#form1').validationEngine('hide');"
                                      MaxLength="10" CssClass="txtbox_none_Mid" TabIndex="19"></asp:TextBox>
                                </div>
                           
                        </div>
                    </div>
                </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="20"></a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../E_royal_Impex_Main.aspx" class="cancelButt" target="_top" tabindex="21"></a>
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
                <div id="Admin_Main_Grid_Container" style="height:250px">
                 <asp:GridView runat="server" ID="gvdetails" DataKeyNames="NOTIFICATION_CUSTOMS_ID" ShowHeader="true"
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


<asp:BoundField DataField="NOTIFICATION_CUSTOMS_NOTN" HeaderText="CUSTOMS NOTN" />
<asp:BoundField DataField="NOTIFICATION_CUSTOMS_NOTN_SL" HeaderText="CUSTOMS NOTN_SL" />
<asp:BoundField DataField="NOTIFICATION_CUSTOMS_CTH" HeaderText="CUSTOMS CTH" />
<asp:BoundField DataField="NOTIFICATION_CUSTOMS_BCD_RATE" HeaderText="CUSTOMS BCD_RATE" />
<asp:BoundField DataField="NOTIFICATION_CUSTOMS_APPLICABLE" HeaderText="CUSTOMS APPLICABLE" />

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