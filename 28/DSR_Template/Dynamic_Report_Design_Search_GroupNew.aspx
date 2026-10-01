<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Dynamic_Report_Design_Search_GroupNew.aspx.cs" Inherits="Import_MasterPage_Dynamic_Report_Design_Search_GroupNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
            <div>
                <div id="innerbox_MidMain">
                    <div id="tag_srcinner1">
                        <div id="newbu">
                            <input type="submit" value="Submit" class="new" onclick="open_Dynamic_Report_new_GroupNew(); return false" /></div>
                        <div id="verslic">
                        </div>
                        <div id="editbu">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Dynamic Report Design
                         </div>
                    </div>
                    <div id="tag_srcinner_svb">
                        <div id="tag_soppliersrc_lft"  style="width:210px;">
                            <div id="tag_soppliersrc_lft_in1" style="width:200px;">
                                <div id="txt-soppliersrc_src_l" style="width:190px;">
                                    <div id="tag_label_supplier" style="width:50px;">
                                        Type</div>

                                        <asp:DropDownList ID="ddltype" CssClass="listtxt_transac_item_gen_notn"  Width="105px" runat="server">
                                        <asp:ListItem Text="Import"></asp:ListItem>
                                        <asp:ListItem Text="Export"></asp:ListItem>
                                       </asp:DropDownList>
                                         
                                </div>
                            </div>
                        </div>


                         <div id="tag_soppliersrc_lft" style="width:210px;">
                            <div id="tag_soppliersrc_lft_in1" style="width:200px;">
                                <div id="txt-soppliersrc_src_l" style="width:190px;">
                                    <div id="tag_label_supplier" style="width:50px;">
                                        Mode</div>
                                
                                       <asp:DropDownList ID="ddlTr_Mode" CssClass="listtxt_transac_item_gen_notn"  Width="105px" runat="server">
                                       <%-- <asp:ListItem Text="Air"></asp:ListItem>
                                        <asp:ListItem Text="Sea"></asp:ListItem>--%>
                                       </asp:DropDownList>
                                </div>
                            </div>
                        </div>


                          <div id="tag_soppliersrc_lft" style="width:210px;">
                            <div id="tag_soppliersrc_lft_in1" style="width:200px;">
                                <div id="txt-soppliersrc_src_l" style="width:190px;">
                                    <div id="tag_label_supplier" style="width:50px;">
                                        Active</div>
                                
                                       <asp:DropDownList ID="ddlactive" CssClass="listtxt_transac_item_gen_notn"  Width="105px" runat="server">
                                        <asp:ListItem Text="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No"></asp:ListItem>
                                       </asp:DropDownList>
                                </div>
                            </div>
                        </div>



                        <div id="tag_srcinner_rght_Single_line">
                            <div id="small-butt-left">
                                <a href="#" id="btnSearch" runat="server"  class="srcbu" onserverclick="btnSearch_Click"
                                    onclick="page_Loading();"></a>
                            </div>
                            <div id="small-butt-rght">
                                <a href="#" class="cancelButt"></a>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1grid">
                        <div id="allbu">
                            <%--<input id="Submit1" type="submit" value="Submit" class="allgrid" runat="server"  />--%>
                            </div>
                        <div id="verslic">
                            &nbsp;</div>
                        
                    </div>
                    
                    
                    <div id="tag_srcinner1grid_table_Container">
                        <div id="Main_Grid_Container">



                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="T_ID" ShowHeader="true"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                                OnRowCreated="gvdetails_RowCreated" Width="100%" 
                                ShowHeaderWhenEmpty="True" 
                                AllowPaging="false"   EmptyDataText="NO RECORD FOUND"
                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" 
                                CellPadding="1" CellSpacing="1" onrowdatabound="gvdetails_RowDataBound" >
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                    <HeaderStyle  Font-Underline="false" ForeColor="Black"   />

                                <Columns>
                                    <asp:BoundField DataField="TEMPLATE_NAME" HeaderText="Template" HeaderStyle-Width="180px" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle CssClass="column_style_left" Width="180px" HorizontalAlign="Left"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TYPE" HeaderText="Type" HeaderStyle-Width="40px" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle CssClass="column_style_left" Width="40px" HorizontalAlign="Left"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TR_MODE" HeaderText="Mode"  HeaderStyle-Width="40px" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle CssClass="column_style_left" Width="40px" HorizontalAlign="Left"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ACTIVE" HeaderText="Active" HeaderStyle-Width="40px" HeaderStyle-HorizontalAlign="center" >
                                        <ItemStyle CssClass="column_style_left" Width="40px" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="" HeaderText="" HeaderStyle-Width="400px" HeaderStyle-HorizontalAlign="center">
                                        <ItemStyle CssClass="column_style_left" Width="400px" HorizontalAlign="Left"/>
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
        </ContentTemplate>
    </asp:UpdatePanel>

  
        
        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>


    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <%--<script language='javascript'>
        window.onload = happycode;
        function happycode() {
            document.getElementById("Supplier_Id").className = 'smenuactive';
            document.getElementById("Master_Id").click();

        }
        function Get_A_to_Z_Value_Master(val) {

            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=btnSearch.ClientID %>").click();
        }
      
    </script>--%>

     <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>



</asp:Content>

