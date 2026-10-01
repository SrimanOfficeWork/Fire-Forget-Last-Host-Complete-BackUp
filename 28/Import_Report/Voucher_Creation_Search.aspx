<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Voucher_Creation_Search.aspx.cs" Inherits="Exp_Voucher_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css" media="print">
        @page
        {
            size: auto; /* auto is the initial value */
            margin: 0mm; /* this affects the margin in the printer settings */
        }
        
        @media print
        {
            /*****   Styles for print   ******/
            h1, h2, h3
            {
                color: black;
            }
            #navigation
            {
                display: none;
            }
        }
        
        @media screen
        {
            /*****   Styles for screen  ******/
        }
    </style>
    <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>

 
<div id="innerbox_MidMain"  >


            <div id="tag_srcinner1">

     <div id="tag_srcinner1" >
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_Imp_Voucher_creation_Search_New('New'); return false" />
                    
                   
                    </div>

                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   Voucher Creation

                    
                    </div>
                   <div id="verslic"> </div>

            </div>
           <%-- --------------------------------------------Start---------------------------%>

                <div id="tag_transact_src_inner" style="width: 935px;">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 900px;">
                           
                    <%--        <div id="tag_label_transact_Src" style="width: 50px;">
                                 DC No.
                            </div>
                            <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_DC_No" runat="server" CssClass="txtbox_none_Mid_transac_code" Width="200px"
                                  ></asp:TextBox>
                                <asp:DropDownList ID="ddlfile_Refno" runat="server" CssClass="txtbox_none" AutoPostBack="true" Font-Size="12px"
                                    Width="220px" onselectedindexchanged="ddlfile_Refno_SelectedIndexChanged" >
                                    
                                </asp:DropDownList>
                            </div>--%>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 50px;" >
                               Job No
                            </div>

                            <div id="txtcon-m_transaction_code" style="width: 120px;">
                                <asp:TextBox ID="txtjobno" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    ></asp:TextBox>
                            </div>
                             <div id="tag_label_transact_Src"  style="width: 110px;">
                                Customer Name
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 200px;">
                                <asp:DropDownList ID="ddl_customer_name" runat="server" CssClass="txtbox_none"  Font-Size="12px"
                                    Width="200px" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 605px;">
                           <%-- <div id="tag_label_transact_Src">
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
                            <div id="tag_label_transact_Src">
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
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                             <div  id="tag_label_transaction_popup_no_empty">
                            </div>
                                <div id="tag_label_transaction_Src_longlabel" style="width: 45px;"> Month</div>
                            
                      <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="100px" TabIndex="5" >
                            </asp:DropDownList>
                        </div>
                --%>   
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

    <div id="innerbox_MidMain_Grid" style="height: 580px;">
        <div id="tag_srcinner1grid">
   
        </div>
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;"> <%-- style="overflow: hidden;"--%> 

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                    OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" DataKeyNames="Imp_Voucher_id"
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
                        <asp:BoundField DataField="Imp_Voucher_no" HeaderText="Voucherno"  HeaderStyle-Width="100px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="Imp_Customer_Name" HeaderText="customer name"  HeaderStyle-Width="170px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="170px" />
                        </asp:BoundField>

                          <asp:BoundField DataField="Total" HeaderText="Grand_total"  HeaderStyle-Width="160px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="160px"/>
                        </asp:BoundField>
                        
                         <asp:BoundField DataField="Imp_Incurred" HeaderText="Incurred"  HeaderStyle-Width="320px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="320px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Imp_Certified" HeaderText="Certified"  HeaderStyle-Width="160px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="160px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Imp_Approved" HeaderText="Approved"  HeaderStyle-Width="160px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="160px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Imp_Verified" HeaderText="Verified"  HeaderStyle-Width="160px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="160px"/>
                        </asp:BoundField>


                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
   
        


        <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
       
    </style>
 
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

              width: 980,
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

    </div>
</asp:Content>

