<%@ Page Title="" Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Export_PDF_Settings_Search.aspx.cs" Inherits="Export_PDF_Settings_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
       th a
       {
           text-decoration: none;
       }
         .space
       {
          padding-left:8%;
          height:15px;
          width:12px;
          vertical-align:middle;
       }
       
        .space_2
       {
          padding-left:8%;
          height:16px;
          width:14px;
          vertical-align:middle;
       }
   </style>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div>
                <div id="innerbox_MidMain">
                    <div id="tag_srcinner1">
                        <div id="newbu">
                            <input type="submit" value="Submit" class="new" onclick="open_exp_pdf_master_new(); return false" /></div>
                        <div id="verslic">
                        </div>
                         <div id="editbu" style="width:160px;">
                            <asp:Button ID="btn_bulk_License" Text="Product Bulk XL Upload" CssClass="autowidupdatebut"
                                Width="140px" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_Export_Bulk_Product_Setting_Master_Excel_Upload();return false;" />
                        </div>
                        <div id="verslic">
                        </div>
                        <div id="editbu">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                            EXPORT PDF SETTINGS MASTER</div>
                    </div>
                    <div id="tag_Exchange_inner"  style="width: 1096px;">
                        <div id="tag_Exchange_inner_lft" style="width: 796px; margin-right:0px;"">
                            <div id="tag_Exchange_lft_in1" style="width: 796px;">
                                <div id="txt-container_Exchange_l" style="width: 306px;">
                                    <div id="tag_label_Exchange_Src"  style="width: 106px;">
                                        Exporter Name</div>
                                    <asp:DropDownList ID="ddl_ExporterName" runat="server" TabIndex="1" Width="200px"
                                        Height="25px">
                                    </asp:DropDownList>
                                </div>
                                <div id="txt-container_Exchange_l" style="width: 336px;">
                                    <div id="tag_label_Exchange_Src">
                                        Product</div>
                                    <asp:TextBox ID="txtProduct" runat="server" CssClass="txtbox_none_Mid" onkeypress="return numchar(event)"
                                      ClientIDMode="Static"  MaxLength="120" TabIndex="1" Width="250px"></asp:TextBox>
                                </div>
                                <div id="txt-container_Exchange_l" style="width: 146px;">
                                    <div id="txtcon-m_transaction_item_maindet">
                                        RITC No
                                    </div>
                                    <asp:TextBox ID="txtRITCNo" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet" onkeyup="autotab(this);"
                                       ClientIDMode="Static" MaxLength="8" TabIndex="2"></asp:TextBox>
                                </div>
                            </div>
                         
                             </div>
                        
                            <div id="editbu">
                                <a href="#" class="srcbu" tabindex="5" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                    onclick="page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                                </a>
                            </div>
                            <div id="editbu">
                                <a href="#" class="cancelButt" tabindex="6"></a>
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
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="ID" ShowHeader="true"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                                Width="107%" ShowHeaderWhenEmpty="True" PageSize="23" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" onsorting="gvdetails_Sorting">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                      <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                                <asp:BoundField DataField="EXPORTER_NAME" HeaderText="EXPORTER_NAME" ControlStyle-Width="170px" HeaderStyle-Width="170px">
                                        <ItemStyle CssClass="column_style_left" Width="70px" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEM_DESC" HeaderText="PRODUCT" SortExpression="ITEM_DESC">
                                        <ItemStyle CssClass="column_style_left" Width="70px" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RITC_NO" HeaderText="CTH NO">
                                        <ItemStyle CssClass="column_style_left" Width="70px" Font-Size="12px" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="SCHEME_CODE" HeaderText="SCHEME_CODE" ControlStyle-Width="170px" HeaderStyle-Width="170px" >
                                        <ItemStyle CssClass="column_style_left" Width="70px" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DBK_SL_NO" HeaderText="DBK_SL_NO">
                                        <ItemStyle CssClass="column_style_left" Width="70px" Font-Size="12px" />
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

        </ContentTemplate>
    </asp:UpdatePanel>
     <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = happycode;
        function happycode() {
            document.getElementById("Product_Id").className = 'smenuactive';
            document.getElementById("Master_Id").click();

        }
        function Get_A_to_Z_Value_Master(val, val2) {

            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=btnSearch.ClientID %>").click();
            document.getElementById("<%=Hdn_GetValue.ClientID %>").value = val2;
        }


        $(function () {
            $("#txtRITCNo").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXPORT_PDF_MASTER_RITC_SEARCH",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtRITCNo').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                            }

                            else {
                                jQuery('#txtRITCNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


        $(function () {
            $("#txtProduct").autocomplete({

                source: function (request, response) {

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXPORT_PDF_MASTER_ITEM_DESC_SEARCH",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtProduct').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                            }

                            else {
                                jQuery('#txtProduct').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

    
</asp:Content>
