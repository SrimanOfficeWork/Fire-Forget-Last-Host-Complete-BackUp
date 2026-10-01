<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Import_License_Master_Search.aspx.cs" Inherits="Import_License_Master_Search" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/Import_License_Master.js" type="text/javascript"></script>

<style type="text/css">
       th a
       {
           text-decoration: none;
       }
         .space
       {
          padding-left:5%;
          height:15px;
          width:12px;
          vertical-align:middle;
       }
       
        .space_2
       {
          padding-left:5%;
          height:16px;
          width:14px;
          vertical-align:middle;
       }
   </style>
            <div>
                <div id="innerbox_MidMain">
                    <div id="tag_srcinner1">
                        <div id="newbu">
                            <input type="submit" value="Submit" class="new" onclick="opennew_Import_licensenew(); return false"
                                onkeypress="return stopRKey(event)" /></div>
                        <div id="verslic">
                        </div>
                        <%--<div id="editbu">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="edit"></a>
                        </div>--%>
                        <div id="editbu" style="width:150px;">
                            <asp:Button ID="btn_bulk_License" Text="License XL Upload" CssClass="autowidupdatebut"
                                Width="120px" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_Import_Bulk_License_Master_Excel_Upload();return false;" />
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                           IMPORT LICENSE MASTER</div>
                    </div>
                    <div id="tag_Exchange_inner" style="width:960px">
                        <div id="tag_Adminsrc_inner_lft">
                            <div id="tag_transact_lft_in1" style="width:750px">
                                <div id="txt_container_Transact_Main_l" style="width:260px">
                                    <div id="tag_label_transaction_popup_gen">
                                        &nbsp; License Regn No.</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txt_License_No" runat="server" CssClass="txtbox_none_Mid_transac_src"
                                           ClientIDMode="Static"  Onkeypress="return numchar(event)" MaxLength="15" TabIndex="1"></asp:TextBox>

                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 200px">
                                    <div id="tag_label_transact_Src">
                                        License Type
                                    </div>
                                    <div id="txtcon-m_transaction_list1">
                                        <asp:DropDownList ID="ddl_Lic_Type" runat="server" CssClass="listtxt_transac_src1"
                                            TabIndex="6">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 200px">
                                    <div id="tag_label_transact_Src">
                                        Party Name
                                    </div>
                                    <div id="txtcon-m_transaction_list1">
                                    <asp:TextBox ID="txt_PartyName" runat="server" CssClass="txtbox_none_Mid_transac_src"
                                           ClientIDMode="Static"  Onkeypress="return numchar(event)" TabIndex="3"></asp:TextBox>
                                        
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tag_srcinner_rght_Single_line">
                            <div id="small-butt-left">
                                <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="page_Loading();" onserverclick="btnSearch_Click"
                                    tabindex="10"></a>
                                   
                                <br />
                                <br />
                            </div>
                            <div id="small-butt-rght">
                                <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" tabindex="11" target="_top">
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Grid">
                    <%--<div id="tag_srcinner1grid" style="display:none;">
                        <div id="allbu">
                            <input type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click" /></div>
                        <div id="verslic">
                        </div>
                        
                    </div>--%>
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
                       <%-- <br />
                        <br />--%>
                    </div>
                    <div id="tag_srcinner1grid_table_Container">
                        <div id="Main_Grid_Container">
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="LICENSE_ID" AutoGenerateColumns="False"
                                BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                                Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true" PageSize="23" AllowPaging="True"
                                OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True" BorderColor="#C8C8C8"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                                onsorting="gvdetails_Sorting">
                                
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                     <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                                    <asp:BoundField DataField="REGISTRATION_NO" HeaderText="Reg.No.">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REGISTRATION_DATE" HeaderText="Reg.date" SortExpression="REGISTRATION_DATE">
                                       <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_NO" HeaderText="License No" SortExpression="LICENSE_NO">
                                        <ItemStyle CssClass="hideGridColumn"/>
                                        <HeaderStyle CssClass="hideGridColumn"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_DATE" HeaderText="License Date" SortExpression="LICENSE_DATE" >
                                        <ItemStyle CssClass="hideGridColumn" />
                                        <HeaderStyle CssClass="hideGridColumn"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EXCEMPTION" HeaderText="Excmptn" SortExpression="EXCEMPTION">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_TYPE" HeaderText="Type" SortExpression="LICENSE_TYPE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="LICENSE_ITEM_NO" HeaderText="Lic ItemNo">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOTAL_DEBIT_AMT" HeaderText="Total Debit Amt">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="REMAINING_AMT" HeaderText="Remaining Amt">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="TOTAL_DEBIT_QTY" HeaderText="Total Debit Qty">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UNIT_QTY" HeaderText="Unit">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PARTY_NAME" HeaderText="Party Name">
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

    
    <script language='javascript'>
      
       
        window.onload = happycode;
        function happycode() {

            document.getElementById("Master_Id").click();
            document.getElementById("License_Id").className = 'smenuactive';
            
        }

        function happycode1() {

           
        }

        function Get_A_to_Z_Value_Master(val) {

            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=btnSearch.ClientID %>").click();
        }
    </script>
      <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>
</asp:Content>
