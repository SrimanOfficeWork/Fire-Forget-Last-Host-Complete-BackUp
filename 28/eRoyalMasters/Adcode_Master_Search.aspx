<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Adcode_Master_Search.aspx.cs" Inherits="eRoyalMasters_Adcode_Master_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
 <style type="text/css">
       th a
       {
           text-decoration: none;
       }
         .space
       {
          padding-left:20%;
          height:15px;
          width:12px;
          vertical-align:middle;
       }
       
        .space_2
       {
          padding-left:20%;
          height:16px;
          width:14px;
          vertical-align:middle;
       }
   </style>

            <div>
                <div id="innerbox_MidMain">
                    <div id="tag_srcinner1">
                        <div id="newbu">
                            <input type="submit" value="Submit" class="new" onclick="if(window.parent && window.parent !== window && window.parent.opennewadcodenew){ window.parent.opennewadcodenew(); } else { opennewadcodenew(); } return false"
                                onkeypress="return stopRKey(event)" /></div>
                        <div id="verslic">
                        </div>
                        <div id="editbu">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                            ADCODE MASTER</div>
                    </div>
                    <div id="tag_Exchange_inner" style="width: 980px">
                        <div id="tag_Adminsrc_inner_lft" style="width: 990px">
                            <div id="tag_transact_lft_in1" style="width: 720px; margin-top: 15px;">
                                <div id="txt_container_Transact_Main_l" style="width: 240px">
                                    <div id="tag_label_transact_Src">
                                        &nbsp; Client Name</div>
                                    <div id="txtcon-m_Exchange" style="width: 50px">
                                        <asp:TextBox ID="txtadCode_name" runat="server" CssClass="txtbox_none_Mid_transac_src"
                                            ClientIDMode="Static" Onkeypress="return numchar(event)" MaxLength="40"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 220px">
                                    <div id="tag_label_transact_Src" style="width: 80px">
                                       Exp. Adcode
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 70px">
                                        <asp:TextBox ID="txtAdcode" runat="server" CssClass="txtbox_none_Mid_transac_src"
                                            Onkeypress="return numchar(event)" MaxLength="14"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 240px">
                                    <div id="tag_label_transact_Src" style="text-align:center;">
                                        Imp. Adcode
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 50px">
                                        <asp:TextBox ID="txtImportAdcode" runat="server" CssClass="txtbox_none_Mid_transac_src"
                                            Onkeypress="return numchar(event)" MaxLength="14"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_srcinner_rght_Single_line">
                                <div id="small-butt-left">
                                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="page_Loading();"
                                        onserverclick="btnSearch_Click" tabindex="10"></a>
                                </div>
                                <div id="small-butt-rght">
                                    <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" tabindex="11" target="_top">
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1grid">
                        <div id="allbu">
                            <input type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click" /></div>
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
                        <span class="selected">Page
                            <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
                            <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                        </span>
                        <%-- <span class="selected"> [Record <%= gvdetails.PageIndex * gvdetails.PageSize%> - <%= gvdetails.PageIndex * gvdetails.PageSize + gvdetails.PageSize - 1%>]</span>
                        --%>
                        <span class="disabled">
                            <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                        <span class="disabled">
                            <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                        </span>
                    </div>
                    <div runat="server" id="div_pagination1" visible="false">
                        <br />
                        <br />
                    </div>
                    <div id="tag_srcinner1grid_table_Container">
                        <div id="Main_Grid_Container">
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="ADCODE_ID" AutoGenerateColumns="False"
                                BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                                Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true" PageSize="23" AllowPaging="True"
                                OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True" BorderColor="#C8C8C8"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                                onsorting="gvdetails_Sorting">
                              
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                     <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                                    <asp:BoundField DataField="ADCODE_IEC_CODE" HeaderText="IEC NUMBER" >
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ADCODE_IEC_NAME" HeaderText="CLIENT" SortExpression="ADCODE_IEC_NAME">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ADCODE_IEC_ADCODE" HeaderText="EXPORT ADCODE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="IMPORT_ADCODE" HeaderText="IMPORT ADCODE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ADCODE_BANK_NAME" HeaderText="BANK NAME" SortExpression="ADCODE_BANK_NAME">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ADCODE_BANK_ACCOUNT_NO" HeaderText="BANK A/C NO">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </div>
                    
                </div>
            </div>
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />        
             <asp:HiddenField ID="HD_tbl_sort" runat="server" />
             <asp:HiddenField ID="hdsort" runat="server" />
              <asp:HiddenField ID="Hdn_GetValue" runat="server" />
    
    <script language='javascript'>
      
       
        window.onload = happycode;
        function happycode() {

            document.getElementById("Master_Id").click();
            document.getElementById("Adcode_Id").className = 'smenuactive';
            
        }

        function happycode1() {

            //document.getElementById("btnSearch").onserverclick = "btnSearch_Click";
            //  $("[id$=gvdetails]").load(location.href + " #[id$=gvdetails]", "" + Math.random() + "");

            // alert('h');
        }

        function Get_A_to_Z_Value_Master(val, val2) {

            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=btnSearch.ClientID %>").click();
            document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
        }
    </script>

     <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>
</asp:Content>
