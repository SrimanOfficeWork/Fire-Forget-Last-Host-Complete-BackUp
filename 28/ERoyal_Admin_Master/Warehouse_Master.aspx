<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master" CodeFile="Warehouse_Master.aspx.cs" Inherits="ERoyal_Admin_Master_Warehouse" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server" >

<%--<link href="../Admin_main.css" rel="stylesheet"  type="text/css" />--%>


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
    <script type="text/javascript">
        function cha(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                return false;
            return true;
        }

        function chaSPACE(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 32 && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                return false;
            return true;
        }
        </script>
     <script language="javascript" type="text/javascript">
         function MaxLength(field, maxLength) {
             if (field.value.length >= maxLength)
                 field.value = field.value.substring(0, maxLength - 1);
         }
         function convertSingle(field) {
             if (field.value.substring(MaxLength, 1) == "'")
                 field.value = field.value.substring(0, MaxLength - 1) & "`"
         }
    </script>

    <script type="text/javascript">
        function validate() {
            var txtWarehouseCode = document.getElementById("<%=txtWarehouseCode.ClientID%>").value;
            if (txtWarehouseCode.length <= 0) {
                alert("Port Code cannot be blank");
                document.getElementById("<%=txtWarehouseCode.ClientID%>").focus();
                return false;
            }


            var txtWarehouseName = document.getElementById("<%=txtWarehouseName.ClientID%>").value;
            if (txtWarehouseName.length <= 0) {
                alert("Port Name cannot be blank");
                document.getElementById("<%=txtWarehouseName.ClientID%>").focus();
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
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    Admin - Warehouse Master
                </div>
            </div>
            <div id="tag_admin_catagory_src_inner" style="height:105px">
                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src" style="Width:105px">
                            Warehouse Code
                        </div>
                       
                        <div id="txtcon-m_transaction_item_maindet" style="width:110px">
                            
                             <asp:TextBox ID="txtWarehouseCode" runat="server"  MaxLength="8" onblur="return ChangeCase(this);"
                                 CssClass="txtbox_none_Mid_transac_code_new" 
                                 TabIndex="1" onkeypress="return numchar(event)"  ></asp:TextBox>
                         </div>

                          <div id="tag_label_transact_Src"  style="Width:106px">
                              Warehouse Name
                        </div>
                        
                        <div id="txtcon_m_Admin_name">
                           
                             <asp:TextBox ID="txtWarehouseName" runat="server" MaxLength="50" onblur="return ChangeCase(this);"  onkeypress="return numchar(event)"  Width="205px"
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="2"  ></asp:TextBox>
                            </div>
                      
                    </div>
                   

                </div>
               <%-- <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src">
                            Port Name
                        </div>
                        
                        <div id="txtcon_m_Admin_name">
                           
                             <asp:TextBox ID="txtPortName" runat="server" MaxLength="50" onkeypress="return chaSPACE(event)"
                                 CssClass="validate[required] txtbox_none_Mid_admin_name" TabIndex="2"  ></asp:TextBox>
                            </div>
                        
                    </div>
                </div>--%>
                <div id="tag_admin_catagory_lft_in1">
                    <div id="txt_container_admin_catagory_Main_l">
                        <div id="tag_label_transact_Src" style="Width:105px">
                            Address</div>
                       
                        <div id="txtcon_m_Admin_remarks">
                            
                             <asp:TextBox ID="txtAddress" runat="server" MaxLength="260" onblur="return ChangeCase(this);" 
                                 onKeyDown="MaxLength(this,198);"  
                                 CssClass="txtbox_none_Mid_transac_code_new" TabIndex="3" Width="210px"
                     ></asp:TextBox>                     
            
                            
                            </div>
                       
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                 <asp:Button ID="btnNew" runat="server" TabIndex="7"  OnClick="btnNew_Click" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"/>
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
                                Warehouse Code </div>
                            
                            <div id="txtcon-m_transaction_item_maindet">
                                
                                 <asp:TextBox ID="txtWarehouse_CodeSearch" runat="server" MaxLength="8" onfocus="jQuery('#form1').validationEngine('hide');"
                    CssClass="txtbox_none_Mid_transac_code_new" TabIndex="8"  onkeypress="return numchar(event)"
                                     Width="93px"></asp:TextBox>
                                </div>
                           
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src"  style="Width:105px">
                                Warehouse Name 
                            </div>
                           
                            <div id="txtcon-m_Exchange">
                              
                                 <asp:TextBox ID="txtWarehouse_NameSearch" runat="server" 
                                     CssClass="txtbox_none_Mid_transac_code_new" onfocus="jQuery('#form1').validationEngine('hide');" 
                    MaxLength="50" TabIndex="9" onkeypress="return chaSPACE(event)" Width="200px" ></asp:TextBox>
                               
                                </div>
                            
                        </div>
                    </div>
                </div>
                <div id="tag_admin_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" tabindex="10"></a>
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
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('A','A_Z')">A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('B','A_Z')">B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('C','A_Z')">C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('D','A_Z')">D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('E','A_Z')">E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('F','A_Z')">F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('G','A_Z')">G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('H','A_Z')">H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('I','A_Z')">I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('J','A_Z')">J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('K','A_Z')">K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('L','A_Z')">L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('M','A_Z')">M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('N','A_Z')">N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('O','A_Z')">O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('P','A_Z')">P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Q','A_Z')">Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('R','A_Z')">R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('S','A_Z')">S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('T','A_Z')">T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('U','A_Z')">U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('V','A_Z')">V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('W','A_Z')">W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('X','A_Z')">X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Y','A_Z')">Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value_Master('Z','A_Z')">Z</a></div>
                </div>
            </div>
            <div id="tag_Admin_srcinner1grid_table_Container">
                <div id="Admin_Main_Grid_Container">
                 <asp:GridView runat="server" ID="gvdetails" DataKeyNames="WH_ID" ShowHeader="true"
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


  <asp:BoundField DataField="WAREHOUSE_CODE" HeaderText="Warehouse Code" />
                          
                        <asp:BoundField DataField="WAREHOUSE_NAME" HeaderText="Warehouse Name" />
                        <asp:BoundField DataField="WAREHOUSE_ADDRESS" HeaderText="Warehouse Address" />

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
      <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />

      <asp:HiddenField ID="Hdn_GetValue" runat="server" />
    
     </ContentTemplate>
    </asp:UpdatePanel>


     <script>
         function Get_A_to_Z_Value_Master(val, val2) {

             document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
             document.getElementById("<%=btnSearch.ClientID %>").click();
             document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
         }
     </script>
    
    </asp:Content>