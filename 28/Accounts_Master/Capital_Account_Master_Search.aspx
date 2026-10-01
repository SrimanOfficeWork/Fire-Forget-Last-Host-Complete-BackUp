
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Capital_Account_Master_Search.aspx.cs" Inherits="Billing_Charge_Master_Search" %>

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
                            <input type="submit" value="Submit" class="new" onclick="open_Capital_Acc_Master_N(); return false"
                                onkeypress="return stopRKey(event)" /></div>
                        <div id="verslic">
                        </div>
                        <div id="editbu">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                           Capital Account Master</div> 
                    </div>
                    <div id="tag_Exchange_inner">
                        <div id="tag_Adminsrc_inner_lft">
                            <div id="tag_transact_lft_in1">
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src">
                                        Ledger Name</div>
                                    <div id="txtcon-m_Exchange">
                                              <asp:TextBox ID="txtLedger_name" runat="server" CssClass="txtbox_none_Mid_transac_src"
                                            ClientIDMode="Static" Onkeypress="return numchar(event)" MaxLength="50"></asp:TextBox>
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
                   
                    <div id="tag_srcinner1grid_table_Container">
                        <div id="Main_Grid_Container">
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="C_ID" AutoGenerateColumns="False"
                                BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                                Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true" PageSize="23" AllowPaging="True"
                                OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True" BorderColor="#C8C8C8"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" >
                                
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                     <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                                 <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="right" Width="45px"  />
                                 </asp:TemplateField>
                                    <asp:BoundField DataField="LEDGER" HeaderText="Ledger Name" >
                                        <ItemStyle CssClass="column_style_left5" Width="250px"  Font-Size="12px" />
                                    </asp:BoundField>
                                  
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </div>
                    
                </div>
            </div>
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
    
    <script language='javascript'>

        $(function () {
            $("#txtLedger_name").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Charge_Master",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);

                            if (data.d == '') {
                                jQuery('#txtCharge_name').validationEngine('showPrompt', 'Incorrect Charge Name', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txtCharge_name').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
           
<script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
</asp:Content>

