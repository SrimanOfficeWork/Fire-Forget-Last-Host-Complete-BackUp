<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Acc_Charge_Master_Search.aspx.cs" Inherits="Acc_Charge_Master_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>

       

    


<script language ="javascript" type="text/javascript">

    document.body.style.cursor = 'pointer';
    var oldColor = '';
    var jobno;

    function ChangeRowColor(rowID, Value, Bill_invno) {
        document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
        document.getElementById("<%=hdBill_invno.ClientID %>").value = Bill_invno;
    }

</script>

 <script type="text/javascript">
     $(function () {
         $("[id*=gvdetails] td").bind("click", function () {
             var row = $(this).parent();
             $("[id*=gvdetails] tr").each(function () {
                 if ($(this)[0] != row[0]) {
                     $("td", this).removeClass("selected_row");
                 }
             });
             $("td", row).each(function () {
                 if (!$(this).hasClass("selected_row")) {
                     $(this).addClass("selected_row");
                 } else {
                     $(this).removeClass("selected_row");
                 }
             });
         });
     });
</script>

<div id="innerbox_MidMain"  style="height:125px;" >
<div id="tag_srcinner1" ">

<div id="tag_srcinner1">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="Open_ChargeMaster('New'); return false" />
                </div>

                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:100px;">
                   Charges
                 </div>
                     
                     <%--<div id="verslic"> </div>
                     <div id="editbu" style="padding-top:5px;">
                         <asp:Button ID="btnaddnew_party" runat="server" OnClientClick="open_GST_Add_New_Party_N(); return false" Text="New Party" />
                    </div>
                    <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:5px;">
                     
                    </div>--%>
                

            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 1000px;">
                            <div id="tag_label_transact_Src" style="width: 110px;">
                                Charge Name
                            </div>
                            <div id="txtcon-m_src" style="width: 400px;">
                                <asp:TextBox ID="txt_ChargeName" runat="server" ClientIDMode="Static"  Width="380px"
                                 TabIndex="5" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Active
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                                <asp:DropDownList ID="ddlActive" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="95px">
                                <asp:ListItem Text="All" Value=""></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="A"></asp:ListItem>
                                <asp:ListItem Text="No" Value="IA"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 885px;">

                            <div id="tag_label_transact_Src" style="width: 110px;">
                                Applicable For
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                                <asp:DropDownList ID="ddlApp" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="95px">
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                <asp:ListItem Text="Import" Value="I"></asp:ListItem>
                                <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                                <asp:ListItem Text="General" Value="G"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                            <div id="tag_label_transact_Src" style="width: 110px;">
                                Charge Category
                            </div>
                            <div id="txtcon-m_src" style="width: 170px;">
                                <asp:DropDownList ID="ddlCharge_Cat" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="165px">
                                <asp:ListItem Text="All" Value=""></asp:ListItem>
                                <asp:ListItem Text="Margin" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Revenue" Value="R"></asp:ListItem>
                                <asp:ListItem Text="Cost" Value="C"></asp:ListItem>
                                <asp:ListItem Text="Reimbursement" Value="RI"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                      <%-- -------------------------------------------------------------------------------%>
                        </div>

                        <%------------------------------------------------------%>
                    </div>
                                               
                        
                    </div>
                    <div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();" onserverclick="btnSearch_Click"
                                tabindex="5"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                        </div>
                    </div>
                </div>
                  <%-- --------------------------------------------End---------------------------%>
                     </div>

        </div>


    <div id="innerbox_MidMain_Grid" style="height: 580px;margin-top:-13px;">
        
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">  


                <asp:GridView ID="gvdetails" runat="server"  AutoGenerateColumns="False"  DataKeyNames="ID"
                ShowHeaderWhenEmpty="true" Width="100%" GridLines="Horizontal" 
                    CellSpacing="1"  OnRowCreated="gvdetails_RowCreated"
                AllowPaging="True"  PageSize="300"   CssClass="grid-view" 
                    onpageindexchanging="gvdetails_PageIndexChanging" 
                    onrowdatabound="gvdetails_RowDataBound"  >
                
                 <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" BorderWidth="1px" />
                 <HeaderStyle Font-Underline="false" ForeColor="Black" />

                    <Columns>
                        <asp:BoundField DataField="CHARGE_NAME" HeaderText="Name" 
                            ItemStyle-CssClass="column_style_left6" HeaderStyle-CssClass="column_style_left6" />
                           
                        <asp:BoundField DataField="Applicable_For" HeaderText="Applicable For" 
                            ItemStyle-CssClass="column_style_left6" HeaderStyle-CssClass="column_style_left6" />

                        <asp:BoundField DataField="CHARGE_CATEGORY" HeaderText="Charge Category" 
                            ItemStyle-CssClass="column_style_left6" HeaderStyle-CssClass="column_style_left6" />

                        <asp:BoundField DataField="TAX_MODE" HeaderText="Tax Category" 
                            ItemStyle-CssClass="column_style_left6" HeaderStyle-CssClass="column_style_left6" />
                    </Columns>
                <PagerSettings Mode="NextPrevious" FirstPageText="First" LastPageText="Last" />
                
            </asp:GridView>
            
                        


            </div>
         </div>

         <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
        <style type="text/css">
            .ui-autocomplete-loading
                {
                    background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
                }
       </style>
     <asp:HiddenField ID="hdrowindex" runat="server" />
     <asp:HiddenField ID="hdBill_invno" runat="server" />
     <asp:HiddenField ID="HDBranch" runat="server" />

  

</asp:Content>

