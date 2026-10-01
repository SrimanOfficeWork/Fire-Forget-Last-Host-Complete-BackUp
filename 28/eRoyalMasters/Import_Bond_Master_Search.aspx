<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Import_Bond_Master_Search.aspx.cs" Inherits="Import_Bond_Master_Search" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            </asp:UpdateProgress>
            <div>
                <div id="innerbox_MidMain">
                    <div id="tag_srcinner1">
                        <div id="newbu">
                            <input type="submit" value="Submit" class="new" onclick="open_Imp_BondMaster_new(); return false" /></div>
                        <div id="verslic">
                        </div>
                        <div id="editbu">
                            <a href="#" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                            IMPORT BOND MASTER</div>
                    </div>
                    <div id="tag_srcinner" style="width:950px;">
                        <div id="tag_srcinner_lft"  style="width:580px;">
                            <div id="tag_srcinner_lft_in1" style="width:650px;">
                                <div id="txt-container_src_l" style="width:250px;">
                                    <div id="tag_label_src">
                                        Bond No
                                    </div>
                                    <%--<asp:TextBox ID="txt_BondNo" runat="server" CssClass="txtbox_none" onkeypress="return numchar(event)"
                                        Width="150px" ClientIDMode="Static" MaxLength="35" TabIndex="1"></asp:TextBox>--%>
                                        <asp:TextBox ID="txt_BondNo" runat="server" 
                                            CssClass="txtbox_none_Mid_transac_code"  
                                           ClientIDMode="Static"  Onkeypress="return numchar(event)" MaxLength="15" 
                                            TabIndex="1" ></asp:TextBox>
                                </div>
                                <div id="txt-container_src_l" style="width:350px;">
                                    <div id="tag_label_src">
                                        Bond Type
                                    </div>
                                     <asp:DropDownList ID="ddlBondType" runat="server" CssClass="txtbox_none" TabIndex="3"  ClientIDMode="Static">
                                        </asp:DropDownList>
                                </div>
                               
                            </div>
                        </div>
                        <div id="tag_srcinner_rght_Single_line">
                            <div id="small-butt-left">
                                <a href="#" id="btnSearch" runat="server" onserverclick="btnSearch_Click" class="srcbu"
                                    tabindex="2" onclick="page_Loading();"></a>
                            </div>
                            <div id="small-butt-rght">
                                <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="3"></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1grid">
                        <div id="allbu">
                            <input id="submit" type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click" /></div>
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
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="ID" ShowHeader="true"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                                OnRowCreated="gvdetails_RowCreated" Width="100%" 
                                ShowHeaderWhenEmpty="True" PageSize="23"
                                AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True"
                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="1" CellSpacing="1" onsorting="gvdetails_Sorting">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                    <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                                    <asp:BoundField DataField="BOND_NO" HeaderText="BOND NO" SortExpression="BOND_NO" HeaderStyle-Width="200px">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_DATE" HeaderText="BOND DATE" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="BOND_TYPE" HeaderText="BOND TYPE" HeaderStyle-Width="200px">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_LOCATION" HeaderText="BOND LOCATION" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_AMT" HeaderText="BOND AMT" HeaderStyle-Width="150px">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REMAINING_AMT" HeaderText="REMAINING AMT" HeaderStyle-Width="150px">
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
            <asp:HiddenField ID="hdnBranch" runat="server"  ClientIDMode="Static"/>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>

    <script type="text/javascript">
        window.onload = happycode;
        function happycode() {
            document.getElementById("Buyer_Id").className = 'smenuactive';
            document.getElementById("Master_Id").click();

        }

        function Get_A_to_Z_Value_Master(val, val2) {

            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=btnSearch.ClientID %>").click();
            document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
        }
    </script>

  <script type="text/javascript">
      $(function () {
          $("#txt_BondNo").autocomplete({

              source: function (request, response) {
//                                    alert(document.getElementById('ddlBondType').value);
                  $.ajax({
                      url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/BOND_NO_from_MASTER",
                      data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById('hdnBranch').value + "','Type': '" + document.getElementById('ddlBondType').value + "' }",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      async: true,
                      success: function (data) {
                          response(data.d);
                          if (data.d == '') {
                              jQuery('#txt_BondNo').validationEngine('showPrompt', 'Invalid Bond Number', 'error', 'topRight', true);
                          }

                          else {
                              jQuery('#txt_BondNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                          }
                      },
                      error: function (XMLHttpRequest, textStatus, errorThrown) {
                      }
                  });
              },
              minLength: 1

          });
          return false;
          scroll: true;

      });
     </script>
     <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>
</asp:Content>
