<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Quotation_Master_Search.aspx.cs" Inherits="Quotation_Master_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>

       <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .padding
        {
           padding-left:10px;
           padding-top:3px;
        }
        
    </style>

    <style type="text/css">
   
    td
    {
        cursor: pointer;
    }
    .selected_row
    {
        background-color: white;
        font-weight:bold;
        /*color:#5E4C4C;*/
         color:#3C3535;
    }
    
    
</style>


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



<div id="innerbox_MidMain">


 <div id="tag_srcinner1">
        

<div id="tag_srcinner1"  >
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_GST_Quotation_New('New'); return false" />
                </div>

                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   Quotation_Master :- 
                 </div>
                  <div id="verslic"></div>
                     <div id="newbu">
                       <div id="mainmastop2container_rght_tag2_txt1" style="width:250px; margin-top:-5px;">
                     </div> 
                </div>
            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        
                            <div id="tag_label_transaction_Src_longlabel" style="width: 40px;">
                                Mode</div>
                            <div id="txtcon-m_transaction_mode" style="width: 100px;">
                                <asp:DropDownList ID="ddlmode" runat="server" Width="90px" CssClass="listtxt_transac_mode_new"
                                    Font-Size="12px" TabIndex="5" >
                                   <%-- <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Air Imp" Value="AI"></asp:ListItem>
                                    <asp:ListItem Text="Sea Imp" Value="SI"></asp:ListItem>
                                    <asp:ListItem Text="Land Exp" Value="LE"></asp:ListItem>

                                    <asp:ListItem Text="Air Exp" Value="AE"></asp:ListItem>
                                    <asp:ListItem Text="Sea Exp" Value="SE"></asp:ListItem>
                                    <asp:ListItem Text="Land Imp" Value="LI"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" > 
                                Client Name
                            </div>
                       
                             <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 310px;"> 
                             <asp:DropDownList ID="ddlClient_Name" runat="server"  Width="300px" CssClass="listtxt_transac_mode_new"  Font-Size="12px"   TabIndex="5">
                            </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" >
                                From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="3"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src"  style="width: 72px;">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="4"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>

                            <div  id="tag_label_transaction_popup_no_empty">
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

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                    DataKeyNames="CLIENT_NAME,MODULE,BRANCH_NO,R_ID,SHIPMENT_TYPE" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" Width="40px"  />
                        </asp:TemplateField>
                        <asp:BoundField DataField="MODULE" HeaderText="Mode"  HeaderStyle-Width="50px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="50px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name"  HeaderStyle-Width="400px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Font-Size="12px" Width="400px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="R_ID" HeaderText="Ref.Id"  HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Font-Size="12px" Width="50px"/>
                        </asp:BoundField>
                          <asp:BoundField DataField="SHIPMENT_TYPE" HeaderText="Ship.Type"  HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Font-Size="12px" Width="50px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="BRANCH_NO" HeaderText="Branch Slno"  HeaderStyle-Width="200px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Font-Size="12px" Width="200px" />
                        </asp:BoundField>

                    </Columns>
                </asp:GridView>

            </div>
         </div>
        
        <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
       
    </style>
     <asp:HiddenField ID="hdrowindex" runat="server" />
     <asp:HiddenField ID="hdBill_invno" runat="server" />
     <asp:HiddenField ID="HDBranch" runat="server" />
      

  <script type="text/javascript">
      $(document).ready(function () {

          var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

          if (totalRows > 2) {
              gridviewScroll();
          }
          else {

              if (lastProductId > 0) {
                  gridviewScroll();
              }
              else {
                  document.getElementById('<%=Main_Grid_Container.ClientID %>').style.overflow = "Auto";
                  document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "100%";
                  document.getElementById('<%=gvdetails.ClientID %>').style.width = "100%";
                  /*alert (lastProductId);*/
              }
          }

      });

      function gridviewScroll() {
          gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

              width: "99.9%",
              height: 520,
              railcolor: "#F0F0F0",
              barcolor: "#CDCDCD",
              barhovercolor: "#606060",
              bgcolor: "#F0F0F0",
              freezesize: 2,
              arrowsize: 30,
              varrowtopimg: "../GridScroll_Images/arrowvt.png",
              varrowbottomimg: "../GridScroll_Images/arrowvb.png",
              harrowleftimg: "../GridScroll_Images/arrowhl.png",
              harrowrightimg: "../GridScroll_Images/arrowhr.png",
              headerrowcount: 1,
              railsize: 16,
              barsize: 15,
              IsInUpdatePanel: true
          });
      }

	</script>

</asp:Content>

