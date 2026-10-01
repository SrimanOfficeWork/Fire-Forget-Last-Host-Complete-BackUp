<%@ Page Title="" Language="C#"  AutoEventWireup="true"  MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="Error_Code_Master.aspx.cs" Inherits="Error_Code_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >
    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />
<script language='javascript'>
    window.onload = happycode;
    function happycode() {
        document.getElementById("Port_Tab").className = 'smenuactive';
        document.getElementById("ADMIN_ID").click();
    }
      
</script>

    <script type="text/javascript">
        function ChangeCase(elem) {
            elem.value = elem.value.toUpperCase();
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
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - Error Code Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:105px">
                <div id="tag_admin_catagory_lft_in1" style="Width:1000px">
                    <div id="txt_container_admin_catagory_Main_l" style="Width:1000px">
                        <div id="tag_label_transact_Src" style="Width:105px">
                            Message ID
                        </div>
                       
                        <div id="txtcon-m_transaction_item_maindet" style="width:120px">
                            
                             <asp:TextBox ID="txtMessageID" runat="server"  Text="CACHI01" Enabled="false"
                                 CssClass="txtbox_none_Mid_transac_code_new" 
                                 TabIndex="1" onblur="return ChangeCase(this);"  ></asp:TextBox>
                         </div>

                          <div id="tag_label_transact_Src"  style="Width:120px">
                              Error Code
                        </div>
                        
                        <div id="txtcon_m_Admin_name" style="width:120px">
                           
                             <asp:TextBox ID="txtErrorCode" runat="server"   
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="2" onblur="return ChangeCase(this);"  ></asp:TextBox>
                            </div>
                            <div id="tag_label_transact_Src" style="Width:125px">
                            Error Description</div>
                       
                        <div id="txtcon_m_Admin_name" style="width:120px">
                            
                             <asp:TextBox ID="txtErrorDesc" runat="server"  
                                   
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="3" 
                     ></asp:TextBox>                     
            
                            
                            </div>
                            <div id="tag_label_transact_Src" style="Width:50px">
                            Error</div>
                       
                        <div id="txtcon_m_Admin_remarks">
                            
                             <asp:TextBox ID="txtError" runat="server" 
                                   
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="4" 
                     ></asp:TextBox>                     
            
                            
                            </div>
                      
                    </div>
                   

                </div>
                <div id="tag_admin_catagory_lft_in1" style="width:1000px">
                    <div id="txt_container_admin_catagory_Main_l" style="width:800px">
                        <div id="tag_label_transact_Src" style="width:105px">
                          Message Type
                        </div>
                        
                        <div id="txtcon_m_Admin_name" style="width:120px">
                            <asp:DropDownList ID="ddlModuleIdMsgTy" runat="server" Width="50px" >
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>BE</asp:ListItem>
                            <%--<asp:ListItem>E</asp:ListItem>--%>
                            </asp:DropDownList>
                           
                            
                            </div>
                            <div id="tag_label_transact_Src" style="Width:120px">
                            Flag</div>
                       
                        <div id="txtcon_m_Admin_remarks">
                            
                            <asp:DropDownList ID="ddlFlag" runat="server">
                            <asp:ListItem> </asp:ListItem>
                            <asp:ListItem>F</asp:ListItem>
                            </asp:DropDownList>
            
                            
                            </div>
                        
                    </div>
                </div>
                
                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="8"   CssClass="new" 
                            CausesValidation="false" UseSubmitBehavior="false" onclick="btnNew_Click" />
                 </div>
             <div id="editbu">
                 <asp:Button ID="btnSave" runat="server"   
                     CssClass="save" TabIndex="5" OnClientClick="return validate()" onclick="btnSave_Click"/>

                 </div>
             <div id="editbu" >
                 <asp:Button ID="btnUpdate" runat="server" OnClientClick=" return validate()"  CssClass="updates" TabIndex="5" 
                     onclick="btnUpdate_Click" />

                 </div>
             <div id="editbu">
                 <asp:Button ID="btnDelete" runat="server"   CssClass="dlete" TabIndex="6" 
                     onclick="btnDelete_Click" />

                 </div>
                    <div id="editbu">
                    <asp:Button ID="btnCancel" runat="server"   CssClass="scancel" TabIndex="7"
                   CausesValidation="true" UseSubmitBehavior="false" onclick="btnCancel_Click"     />
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()" />--%></div>
                </div>
            </div>
            <div id="tag_admin_src_border">
            </div>
            <div id="tag_transact_src_inner">
                <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l" style="width:208px">
                            <div id="tag_label_transact_Src" style="Width:108px">
                                Error Code </div>
                            
                            <div id="txtcon-m_transaction_item_maindet">
                                
                                 <asp:TextBox ID="txtErrorCodeSearach" runat="server"
                    CssClass="txtbox_none_Mid_transac_code_new" TabIndex="9"  
                                     Width="93px"></asp:TextBox>
                                </div>
                           
                        </div>
                        
                    </div>
                </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="11"></a>
                    </div>
                    <div id="small-butt-rght" style="float:left">
                        <a href="#" class="cancelButt" id="btnCance" runat="server" onserverclick="btnCance_Click"  tabindex="12"></a>
                    </div>
                </div>
            </div>
        </div>
        <div id="innerbox_MidMain_Grid_Admin_catagory">
           
            <%--<div id="tag_Admin_srcinner1grid_table_Container">--%>
                <div id="Admin_Main_Grid_Container" style="height:470px">
                 <asp:GridView runat="server" ID="gvdetails" ShowHeader="true" DataKeyNames="ERR_CD"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" 
                            GridLines="Both" CssClass="grid-view"  OnRowCreated="gvdetails_RowCreated" onselectedindexchanged="gvdetails_SelectedIndexChanged"
                            OnRowDataBound="gvdetails_RowDataBound"
                                    Width="100%" ShowHeaderWhenEmpty="True"
                                   
                           
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


  <asp:BoundField DataField="MESG_ID" HeaderText="MESSAGE ID" />
                          
                        <asp:BoundField DataField="ERR_CD" HeaderText="ERROR CODE" />
                        <asp:BoundField DataField="ERR_DESC" HeaderText="ERROR DESCRIPTION"  />

</Columns>
                                    
                               <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            
        </div>
        
    </div>
      <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />

      <asp:HiddenField ID="Hdn_GetValue" runat="server" />
      <script type="text/javascript">
             
           </script>
           <script type="text/javascript">
          
    </script>
    
     </ContentTemplate>
    </asp:UpdatePanel>   

    </asp:Content>
