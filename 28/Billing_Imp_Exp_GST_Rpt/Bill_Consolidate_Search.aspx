<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Bill_Consolidate_Search.aspx.cs" Inherits="Bill_Consolidate_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

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
 
<div id="innerbox_MidMain">

<div id="tag_srcinner1">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_Bill_Con_Search_New('New'); return false" />
                   
                    </div>

                <div id="verslic"></div>
                  <div id="editbu" style="padding-top:3px; width:35px;">
                    <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Invoice Report"  ImageUrl="~/images/icons/Bill_pending.jpg" runat="server" OnClientClick="Inv_Bill('B');return false;"  />
                </div>

                 <div id="verslic"></div>
                  <div id="editbu" style="padding-top:3px; width:100px;">
                     <asp:Button ID="btnrpt_Anx" runat="server" ToolTip="Annex Report" Text="Get Annexure" OnClientClick="Inv_Bill('A');return false;"  />
                </div>
                
                
                <div id="mainmastop2container_rght_tag2_txt1" style="width:200px;">
                   Billing Consolidated
                    </div>
                   <div id="verslic"> </div>

                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 70px;">
                               Category
                              </div>
                 <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                             <asp:DropDownList ID="ddlcategory" runat="server" CssClass="txtbox_none"   
                                 Font-Size="12px" Width="80px" AutoPostBack="true" Font-Bold="true"
                                 onselectedindexchanged="ddlcategory_SelectedIndexChanged" >
                                <asp:ListItem Text="IMP" Value="I" ></asp:ListItem>
                                <asp:ListItem Text="EXP" Value="E" ></asp:ListItem>
                                </asp:DropDownList>
                            </div>
            </div>
<%-- --------------------------------------------Start---------------------------%>
<div id="tag_transact_src_inner" style="width: 1000px;">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 990px;">
                            
                              <div id="tag_label_transact_Src" style="width: 110px;" >
                                Customer Name
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 390px;">
                                <asp:DropDownList ID="ddlCus_name" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    Width="385px" OnSelectedIndexChanged="ddlCus_name_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>


                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Ref Name
                            </div>
                            <div id="txtcon-m_src">
                                <asp:DropDownList ID="ddlreportname" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    Width="220px" onselectedindexchanged="ddlreportname_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 50px;" >
                               Inv. No
                            </div>

                            <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlinv_no" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="150px" TabIndex="5" >
                            </asp:DropDownList>
                            </div>
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 605px;">
                            <div id="tag_label_transact_Src" style="width: 110px;">
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
                             <div id="tag_label_transaction_Src_longlabel" style="width: 50px;">
                            Month
                            
                            </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="130px" TabIndex="5" >
                            </asp:DropDownList>
                        </div>
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

    <div id="innerbox_MidMain_Grid" style="height: 580px;">
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;"> <%-- style="overflow: hidden;"--%> 

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="110%"
                    DataKeyNames="IMP_EXP_ID,TYPE" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
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
                        <asp:BoundField DataField="CUSTOMER_NAME" HeaderText="Customer Name"  HeaderStyle-Width="281px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="281px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="TYPE" HeaderText="Type"  HeaderStyle-Width="40px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="40px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="R_ID" HeaderText="Ref. Id"  HeaderStyle-Width="40px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="40px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Ref_name" HeaderText="Ref. Name"  HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="BILL_INV_NO" HeaderText="Inv. No"  HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="150px"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="INV_NO" HeaderText="Combine Inv. No"  HeaderStyle-Width="310px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="310px"/>
                        </asp:BoundField>

                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdrowindex" runat="server" />
     <asp:HiddenField ID="hdBill_invno" runat="server" />
   
<style type="text/css">
       .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
    <script language="javascript">
        function Inv_Bill(val) {
            var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
            var Bill_Invo = document.getElementById("<%=hdBill_invno.ClientID %>").value;

            if (jobno != '') {
                NewWindow1('../Billing_Imp_Exp_GST_Rpt/GST_Bill_Consolidate_rpt.aspx?Bill_Invo=' + jobno + '&TYPE_IMP_EXP=' + Bill_Invo + '&INV_ANX=' + val + '', 'List', '870', '1024', 'yes');
            }
            else {
                jAlert('Select a Grid Job', 'Bill Invoice', function (r) { document.getElementById("ddlcategory").focus(); });
            }

        }
    </script>

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

              width: 1024,
              height: 520,
              railcolor: "#F0F0F0",
              barcolor: "#CDCDCD",
              barhovercolor: "#606060",
              bgcolor: "#F0F0F0",
              freezesize: 1,
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

