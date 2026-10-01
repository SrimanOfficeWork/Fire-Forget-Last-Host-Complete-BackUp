<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Company_Master_Search.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Admin_Company_Master_Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
        <div id="innerbox_MidMain">
            <div id="tag_srcinner1">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="Company_Details_New('New'); return false" /></div>
                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    List Of Clients </div>
            </div>
            <div id="tag_transact_src_inner">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Client Name
                            </div>
                            
                            <div id="txtcon-m_Exchange">
                                
                                
                            
                            <asp:TextBox ID="txtClient_Name" runat="server" CssClass="txtbox_none_Mid" 
                                    TabIndex="1" ></asp:TextBox>
                            </div>
                           
                        </div>
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                License No
                            </div>
                           
                            <div id="txtcon-m_Exchange">
                                
                           
                           <asp:TextBox ID="txtLicense_No" runat="server" CssClass="txtbox_none_Mid" 
                                     TabIndex="2" onkeypress="return numcharspl1(event)"></asp:TextBox>
                            </div>
                            
                        </div>
                    </div>
                    <div id="tag_transact_lft_in1">
                        <div id="txt_container_Transact_Main_l">
                            <div id="tag_label_transact_Src">
                                Contact Person</div>
                           
                            <div id="txtcon-m_Exchange">
                                
                            <asp:TextBox ID="txtContact_Person" runat="server" CssClass="txtbox_none_Mid" 
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
                        <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click" onclick="document.getElementById('hdn_A_to_Z_Search').value='';">
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
                    <input id="Submit1" type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearch_Click" onclick="document.getElementById('hdn_A_to_Z_Search').value='';"/></div>
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
      
       <span class="selected"> Page <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
        <asp:Label ID="lblCurrentPage" runat="server" ></asp:Label> </span>
       
              <%-- <span class="selected"> [Record <%= gvdetails.PageIndex * gvdetails.PageSize%> - <%= gvdetails.PageIndex * gvdetails.PageSize + gvdetails.PageSize - 1%>]</span>
--%>
      <span class="disabled"><asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage" >Next</asp:LinkButton></span>

      <span class="disabled"><asp:LinkButton CommandName="Last"  ID="btnLast" runat="server" OnCommand="ChangePage" >Last</asp:LinkButton>   </span>      
        
      </div> 
      <div runat="server" id="div_pagination1" visible="false">
      <br />
<br /></div>
                <div id="tag_srcinner1grid_table_Container">
            
                <div id="Main_Grid_Container">
                     
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="COMPANY_ID,COMPANY_LICENSE" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" 
                         CssClass="grid-view" ShowHeader="true"
                                    Width="100%" ShowHeaderWhenEmpty="True" AllowPaging="True" 
                        OnRowDataBound="gvdetails_RowDataBound" 
                                    AllowSorting="True"  
                                    CellPadding="1" CellSpacing="1" 
                        onrowcreated="gvdetails_RowCreated" PageSize="50" 
                        >
                                      <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                        BorderStyle="Solid" BorderWidth="1px" />
                                        
                        <Columns>
                            <asp:BoundField DataField="CLIENT_NAME" HeaderText="CLIENT NAME" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>
                            
                            <asp:BoundField DataField="COMPANY_LICENSE" HeaderText="LICENSE NO" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>

                            <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>

                            <asp:BoundField DataField="PHONE_NO" HeaderText="PHONE NO" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>

                             <asp:BoundField DataField="CONTACT_PERSON" HeaderText="CONTACT PERSON" >
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
            <asp:HiddenField ID="Hdn_GetValue" runat="server" />
            <script>

                window.onload = happycode;
                function happycode() {
                    document.getElementById("client_tab").className = 'smenuactive';
                    document.getElementById("MASTER_ID").click();

                }
                function Get_A_to_Z_Value_Master(val, val2) {

                    document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
                    document.getElementById("<%=btnSearch.ClientID %>").click();
                    document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
                }
                window.onload = happycode;
                function happycode() {

                    document.getElementById("MASTER_ID").click();

                }

    </script>
       </asp:Content>

  