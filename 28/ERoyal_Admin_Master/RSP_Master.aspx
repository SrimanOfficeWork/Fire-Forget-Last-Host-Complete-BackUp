<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="RSP_Master.aspx.cs" Inherits="ERoyal_Admin_Master_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<%--<link href="../Admin_main.css" rel="stylesheet" media="screen, projection" type="text/css" />--%>
    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />

<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("Rsp_Tab").className = 'smenuactive';
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


             function numdot1(evt) {
                 var charCode = (evt.which) ? evt.which : event.keyCode
                 if (charCode > 32 && (charCode < 48 || charCode > 57) && (charCode < 46 || charCode > 46))
                     return false;
                 return true;
             }

         </script>
         <script type="text/javascript">
             function validate() {
                 var txtRSPCTH_No = document.getElementById("<%=txtRSPCTH_No.ClientID%>").value;
                 if (txtRSPCTH_No.length <= 0) {
                     alert("CTH_No cannot be blank");
                     document.getElementById("<%=txtRSPCTH_No.ClientID%>").focus();
                     return false;
                 }
                 if (txtRSPCTH_No.length < 8) {
                     alert("CTH_No should be 8 digit numbers");
                     document.getElementById("<%=txtRSPCTH_No.ClientID%>").focus();
                     return false;
                 }
                 var txtRSPRate = document.getElementById("<%=txtRSPRate.ClientID%>").value;
                 if (txtRSPRate.length <= 0) {
                     alert("Rate cannot be blank");
                     document.getElementById("<%=txtRSPRate.ClientID%>").focus();
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
    
    <%--<div >--%>
        
          <div id="innerbox_MidMain_admin_catagory" style="height:255px">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - RSP Master
                </div>
            </div>

            <div id="tag_admin_catagory_src_inner" style="height:130px">
                <div id="tag_admin_catagory_lft_in1" style="height:30px">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            RSP CTH No.
                        </div>
                       
                        <div id="txtcon-m_Exchange" style="width: 110px">
                           
                              <asp:TextBox ID="txtRSPCTH_No" runat="server" MaxLength="8" onkeypress="return pin(event)" 
                                  CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Mid" TabIndex="1" Width="100px" ></asp:TextBox>
                  
                 
                <%--<asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtRSPCTH_No"
                    FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\"></asp:FilteredTextBoxExtender>--%>
                            </div>

                            <div id="tag_label_transact_Src">
                            RSP Notn
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 110px">
                            <asp:TextBox ID="txtRSP_NotnNo" runat="server" MaxLength="10" onkeypress="return numdot1(event)"
                                CssClass="txtbox_none_Mid_transac_item_maindet" Width="100px"
                                TabIndex="2"></asp:TextBox>
                        </div>

                        <div id="tag_label_transact_Src" style="width: 90px">
                            RSP Notn Slno
                        </div>
                        <div id="txtcon-m_transaction_item_maindet">
                            <asp:TextBox ID="txtRSP_NotnSlNo" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_transac_item_maindet"
                                TabIndex="3" ></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtRSPDescription"
                                FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                            </asp:FilteredTextBoxExtender>
                        </div>
                      
                    </div>
                </div>

                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            RSP Rate
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 110px">
                            <asp:TextBox ID="txtRSPRate" runat="server" MaxLength="4" onkeypress="return numdot1(event)"
                                CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                TabIndex="4"></asp:TextBox>
                        </div>
                        <div id="tag_label_transact_Src" style="width: 100px">
                            RSP Description
                        </div>
                        <div id="txtcon_m_Admin_name">
                            <asp:TextBox ID="txtRSPDescription" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_admin_name"
                                TabIndex="5" Width="205px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtRSPDescription"
                                FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                            </asp:FilteredTextBoxExtender>
                        </div>
                    </div>
                </div>
               
                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            Remarks</div>
                        <div id="txtcon_m_Admin_remarks" style="width: 600px">
                            <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_admin_remarks"
                                TabIndex="6" Width="400px"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="txtRemarks"
                                FilterMode="InvalidChars" InvalidChars="[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                            </asp:FilteredTextBoxExtender>
                        </div>
                    </div>
                </div>


                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="8"  OnClick="btnNew_Click" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"  OnClick="btnSave_Click" OnClientClick="return validate();"
                     CssClass="save" TabIndex="7"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server"  OnClick="btnUpdate_Click" CssClass="updates" TabIndex="8" OnClientClick="return validate();"/>

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"  OnClick="btnDelete_Click" TabIndex="9" CssClass="dlete" OnClientClick="return confirm('Are you sure want to delete?');"/>

                 </div>
                 <div id="editbu">
                  <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="9"
                   CausesValidation="true" UseSubmitBehavior="false"      onclick="btnCancel_Click"/>
                      <%--  <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
              <div id="tag_transact_src_inner">
                  <div id="tag_Adminsrc_inner_lft">
                      <div id="tag_transact_lft_in1">
                          <div id="txt_container_Transact_Main_l" style="width: 220px">
                              <div id="tag_label_transact_Src">
                                  RSP CTH No.</div>
                              <div id="txtcon-m_transaction_item_maindet">
                                  <asp:TextBox ID="txtRSPCTH_NoSearch" runat="server" onkeypress="return pin(event)"
                                      CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Mid" onfocus="jQuery('#form1').validationEngine('hide');"
                                      MaxLength="8" TabIndex="10" Width="100px"></asp:TextBox>
                              </div>
                          </div>
                          <div id="txt_container_Transact_Main_l" style="width: 350px">
                              <div id="tag_label_transact_Src" style="width: 70px">
                                  Notn No
                              </div>
                              <div id="txtcon-m_transaction_item_maindet">
                                  <asp:TextBox ID="txt_NotnSearch" runat="server" TabIndex="11" onfocus="jQuery('#form1').validationEngine('hide');"
                                      onkeypress="return notn(event)" CssClass="txtbox_none_Mid_transac_item_maindet"
                                      MaxLength="8"></asp:TextBox>
                              </div>
                              <div id="tag_label_transaction_popup_IGM2_empty">
                              </div>
                              <div id="tag_label_transact_Src" style="width: 70px">
                                  Notn SlNo
                              </div>
                              <div id="txtcon-m_transaction_item_maindet">
                                  <asp:TextBox ID="txt_NotnSlNoSearch" runat="server" TabIndex="12" onfocus="jQuery('#form1').validationEngine('hide');"
                                      onkeypress="return NOTNSLNO(event)" CssClass="txtbox_none_Mid_transac_item_maindet"
                                      MaxLength="6"></asp:TextBox>
                              </div>
                          </div>
                      </div>
                  </div>
                  <div id="tag_admin_srcinner_rght">
                      <div id="small-butt-left">
                          <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                              tabindex="13"></a>
                      </div>
                      <div id="small-butt-rght">
                          <a href="../E_royal_Impex_Main.aspx" class="cancelButt" target="_top" tabindex="14">
                          </a>
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
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="RSP_ID" ShowHeader="true"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                        OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" PageSize="15"
                        AllowPaging="True" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged" OnRowDataBound="gvdetails_RowDataBound"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1">
                        <%-- <FooterStyle BackColor="#D59200" ForeColor="White" Font-Bold="True" />
                                    <PagerStyle BackColor="#D59200" ForeColor="White" HorizontalAlign="Center" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"
                                        PageButtonCount="10" Mode="NextPreviousFirstLast" />--%>
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                          
                       <asp:BoundField DataField="RSP_CTHNO" HeaderText="RSP CTHNO" />
<asp:BoundField DataField="RSP_RATE" HeaderText="RSP RATE" />
<asp:BoundField DataField="RSP_NOTN" HeaderText="RSP_NOTN" />
<asp:BoundField DataField="RSP_NOTN_SLNO" HeaderText="RSP_NOTN_SLNO" />
<%--<asp:BoundField DataField="RSP_DESCRIPTION" HeaderText="DESCRIPTION" />
<asp:BoundField DataField="RSP_REMARKS" HeaderText="REMARKS" />--%>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </div>
            <div class="pagination" id="Div_Pagination" runat="server">
                <div id="tag_label_transaction_popup_IGM_Container">
                    Page No.</div>
               
                <div id="txtcon-m_transaction_list1_fcl">
                    <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                        OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
               
                <span class="disabled">
                    <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>
                <span class="disabled">
                    <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
                <span class="selected">Record
                    <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                    -
                    <asp:Label ID="lblTotalPages" runat="server"></asp:Label></span> <span class="disabled">
                        <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                <span class="disabled">
                    <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                </span>
            </div>
        </div>
        
   <%-- </div>--%>
     </ContentTemplate>
    </asp:UpdatePanel>
   </asp:Content>