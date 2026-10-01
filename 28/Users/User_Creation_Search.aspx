<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" CodeFile="User_Creation_Search.aspx.cs" Inherits="Users_User_Creation_Search" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  
        <div id="innerbox_MidMain">
            <div id="tag_srcinner1">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="User_Details_New('New'); return false" /></div>
                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    User Creation </div>
            </div>
            <div id="tag_transact_src_inner">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Name
                            </div>
                            
                            <div id="txtcon-m_Exchange">
                                
                                
                            
                            <asp:TextBox ID="txtName" runat="server" CssClass="txtbox_none_Mid" 
                                    TabIndex="1" ></asp:TextBox>
                            </div>
                           
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                User Name</div>
                           
                            <div id="txtcon-m_Exchange">
                                
                           
                           <asp:TextBox ID="txtUser_Name" runat="server" CssClass="txtbox_none_Mid" 
                                     TabIndex="2" onkeypress="return numcharspl1(event)"></asp:TextBox>
                            </div>
                            
                        </div>
                    </div>
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Employee ID</div>
                           
                            <div id="txtcon-m_Exchange">
                                
                            <asp:TextBox ID="txtEmployee_ID" runat="server" CssClass="txtbox_none_Mid" 
                                    TabIndex="3"  onkeypress="return char1(event)"></asp:TextBox>
                            </div>
                            
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Mobile No
                            </div>
                            
                            <div id="txtcon-m_Exchange">
                                
                            <asp:TextBox ID="txtMobile_No" runat="server" CssClass="txtbox_none_Mid" 
                                    TabIndex="4" onkeypress="return numcharcomma(event)"></asp:TextBox>
                            </div>
                           
                        </div>
                    </div>
                </div>
                <div id="tag_transact_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server"  onserverclick="btnSearch_Click">
                        </a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                    </div>
                </div>
            </div>
        </div>

        <div id="innerbox_MidMain_Grid">
            <div id="tag_srcinner1grid">
                <div id="allbu">
                    <input id="Submit1" type="submit" value="Submit" class="allgrid" runat="server"  onclick="document.getElementById('hdn_A_to_Z_Search').value='';"/></div>
                <div id="verslic">
                </div>
                <div id="mainmastop2container_rght_tag3">
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt">#</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('A')" >A</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('B')" >B</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('C')" >C</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('D')" >D</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('E')" >E</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('F')" >F</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('G')" >G</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('H')" >H</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('I')" >I</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('J')" >J</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('K')" >K</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('L')" >L</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('M')" >M</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('N')" >N</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('O')" >O</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('P')" >P</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Q')" >Q</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('R')" >R</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('S')" >S</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('T')" >T</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('U')" >U</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('V')" >V</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('W')" >W</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('X')" >X</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Y')" >Y</a></div>
                    <div id="small-alph-icon-tag">
                        <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Z')" >Z</a></div>
                        
                </div>
                
            </div>
            <div class="pagination" id="Div_Pagination" runat="server">
           
  <div id="tag_label_transaction_popup_IGM_Container">Page No.</div>
 
              <div id="txtcon-m_transaction_list1_fcl">
   <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="false" 
                      CssClass="listtxt_transac_FCL" 
                      >
                 </asp:DropDownList>
                         
 
</div>

              
       <span class="disabled"><asp:LinkButton CommandName="First"  ID="btnFirst" runat="server" >« First</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server"  >« Previous</asp:LinkButton></span>
      
       <span class="selected"> Page <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
        <asp:Label ID="lblCurrentPage" runat="server" ></asp:Label> </span>
       
              <%-- <span class="selected"> [Record <%= gvdetails.PageIndex * gvdetails.PageSize%> - <%= gvdetails.PageIndex * gvdetails.PageSize + gvdetails.PageSize - 1%>]</span>
--%>
      <span class="disabled"><asp:LinkButton CommandName="Next" ID="btnNext" runat="server"  >Next</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Last"  ID="btnLast" runat="server" >Last</asp:LinkButton>   </span>      
        
      </div> 
      <div runat="server" id="div_pagination1" visible="false">
      <br />
<br /></div>
                <div id="tag_srcinner1grid_table_Container">
            
                <div id="Main_Grid_Container">
                     
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="USER_CREATION_ID,COMPANY_ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False"
                         CssClass="grid-view" ShowHeader="true"
                                    Width="100%" ShowHeaderWhenEmpty="True" AllowPaging="True" 
                       
                                    AllowSorting="True"  
                                    CellPadding="1" CellSpacing="1" 
                       PageSize="100"  OnRowDataBound="gvdetails_RowDataBound"  onrowcreated="gvdetails_RowCreated"
                        >
                                      <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                        
                        <Columns>
                            <asp:BoundField DataField="CLIENT_NAME" HeaderText="NAME" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>
                            
                            <asp:BoundField DataField="USER_NAME" HeaderText="User Name" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>

                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="Employee ID" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>                                                                   

                            <asp:BoundField DataField="MOBILE_NO" HeaderText="MOBILE NO" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>

                        </Columns>  
                                     
                       <%-- <PagerTemplate>
  <div class="pagination">
       <span class="disabled"><asp:LinkButton CommandName="First"  ID="lbFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage" >« Previous</asp:LinkButton></span>

    <span class="selected"> [Record <%= gvdetails.PageIndex * gvdetails.PageSize%> - <%= gvdetails.PageIndex * gvdetails.PageSize + gvdetails.PageSize - 1%>]</span>

      <span class="disabled"><asp:LinkButton CommandName="Next" ID="lbNext" runat="server" OnCommand="ChangePage" >Next</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Last"  ID="lbLast" runat="server" OnCommand="ChangePage" >Last</asp:LinkButton>   </span>       
      </div>
</PagerTemplate>--%>
                                      <PagerSettings Visible="False" />
                                      
                    </asp:GridView>
                </div>
            </div>
             
            <%--<div class="pagination">
                <span class="disabled">« First</span> <span class="disabled">« Previous</span> <span
                    class="selected">0</span> <a href="AttributeofgodPage1.html">1</a> <a href="AttributeofgodPage2.html">
                        2</a> <a href="AttributeofgodPage3.html">3</a> <a href="AttributeofgodPage4.html">4</a>
                <a href="AttributeofgodPage5.html">5</a> <a href="AttributeofgodPage1.html">Next »</a>
                <a href="AttributeofgodPage10.html">Last »</a>
            </div>--%>
        </div>
     
          <%--  <asp:Button ID="btn_A_TO_Z_Search" runat="server" OnClick="btn_A_TO_Z_Search_Click" />--%>
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
            
            <script>

                window.onload = happycode;
                function happycode() {
                    document.getElementById("client_tab").className = 'smenuactive';
                    document.getElementById("MASTER_ID").click();

                }
                function Get_A_to_Z_Value_Master(val) {

                    document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
                    document.getElementById("<%=btnSearch.ClientID %>").click();
                }
                window.onload = happycode;
                function happycode() {

                    document.getElementById("MASTER_ID").click();

                }


    </script>
       </asp:Content>
   
