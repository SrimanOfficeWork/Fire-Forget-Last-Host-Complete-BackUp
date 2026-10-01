<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Acc_Charges_Master_N_Search.aspx.cs" Inherits="Acc_Charges_Master_N_Search" %>
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
    <div id="innerbox_MidMain" style="height: 125px; width: 1194px;">
        <div id="tag_srcinner1">
            <div id="newbu">
                <input type="submit" value="Submit" class="new" onclick="open_Charge_Master_N('New'); return false" />
            </div>
            <div id="verslic">
            </div>
            <div id="editbu">
                <a href="#" class="edit"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                Charge Master
            </div>
            <div id="tag_transact_src_inner" style="width: 1185px;">
                <div id="tag_Exchange_inner_lft" style="width: 1185px;">
                    <div id="tag_transact_lft_in1_row1" style="width: 1185px; height: 30px; overflow: hidden;
                        margin-bottom: 4px;">
                        <div id="tag_label_transact_Src_name" style="float: left; width: 60px; font-size: 12px;
                            font-family: Arial; padding-top: 3px; margin-left: 20px;">
                            Name
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="float: left;">
                            <asp:TextBox ID="txtFilterName" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                MaxLength="100" TabIndex="1">
                            </asp:TextBox>
                        </div>
                        <div id="tag_label_transact_Src_active" style="float: left; width: 55px; font-size: 12px;
                            font-family: Arial; padding-top: 3px; margin-left: 205px;">
                            Active
                        </div>
                        <div id="txtcon-m_src_active" style="float: left; width: 130px;">
                            <asp:DropDownList ID="ddlFilterActive" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="125px" TabIndex="2">
                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                <asp:ListItem Text="All" Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div style="float: left; padding-top: 3px; margin-left: 6px;">
                            <asp:LinkButton ID="lnkClear" runat="server" Style="font-size: 12px; font-family: Arial;
                                color: #0066cc; text-decoration: none;" OnClientClick="clearFilters(); return false;"
                                TabIndex="3">Clear</asp:LinkButton>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                    <div id="tag_transact_lft_in1_row2" style="width: 1185px; height: 30px; overflow: hidden;
                        margin-bottom: 4px; margin-top: -10px">
                        <div id="tag_label_transact_Src_chargetype" style="float: left; width: 80px; font-size: 12px;
                            font-family: Arial; padding-top: 3px;">
                            Charge type
                        </div>
                        <div id="txtcon-m_src_chargetype" style="float: left; width: 280px;">
                            <asp:DropDownList ID="ddlFilterChargeType" runat="server" CssClass="txtbox_none"
                                Font-Size="12px" Width="275px" TabIndex="4">
                                <asp:ListItem Text="(All)" Value=""></asp:ListItem>
                                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                                <asp:ListItem Text="Freight Like/Surcharge" Value="Freight Like/Surcharge"></asp:ListItem>
                                <asp:ListItem Text="Commission" Value="Commission"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transact_Src_chargecat" style="float: left; width: 110px; font-size: 12px;
                            font-family: Arial; padding-top: 3px; margin-left: 20px;">
                            Charge Category
                        </div>
                        <div id="txtcon-m_src_chargecat" style="float: left; width: 130px;">
                            <asp:DropDownList ID="ddlFilterChargeCategory" runat="server" CssClass="txtbox_none"
                                Font-Size="12px" Width="125px" TabIndex="5">
                                <asp:ListItem Text="All" Value=""></asp:ListItem>
                                <asp:ListItem Text="Margin" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Revenue" Value="R"></asp:ListItem>
                                <asp:ListItem Text="Cost" Value="C"></asp:ListItem>
                                <asp:ListItem Text="Reimbursement" Value="RI"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="small-butt-left" style="float: left; margin-left: 70px;">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                                onserverclick="btnSearch_Click" tabindex="6"></a>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                    <div id="tag_transact_lft_in1_row3" style="width: 1185px; height: 30px; margin-top: -5px;
                        overflow: hidden;">
                        <div id="tag_label_transact_Src_appfor" style="float: left; width: 80px; font-size: 12px;
                            font-family: Arial; padding-top: 3px;">
                            Applicable For
                        </div>
                        <div id="txtcon-m_src_appfor" style="float: left; width: 280px;">
                            <asp:DropDownList ID="ddlFilterApplicableFor" runat="server" CssClass="txtbox_none"
                                Font-Size="12px" Width="275px" TabIndex="7">
                                <asp:ListItem Text="All" Value=""></asp:ListItem>
                                <asp:ListItem Text="AIR EXPORT" Value="AIR_EXPORT"></asp:ListItem>
                                <asp:ListItem Text="AIR IMPORT" Value="AIR_IMPORT"></asp:ListItem>
                                <asp:ListItem Text="SEA EXPORT" Value="SEA_EXPORT"></asp:ListItem>
                                <asp:ListItem Text="SEA IMPORT" Value="SEA_IMPORT"></asp:ListItem>
                                <asp:ListItem Text="CUSTOM CLEARING IMPORT" Value="CUSTOM_CLEARING_IMPORT"></asp:ListItem>
                                <asp:ListItem Text="CUSTOM CLEARING EXPORT" Value="CUSTOM_CLEARING_EXPORT"></asp:ListItem>
                                <asp:ListItem Text="TRANSPORT" Value="TRANSPORT"></asp:ListItem>
                                <asp:ListItem Text="GENERAL" Value="GENERAL"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div style="clear: both;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="1190px"
                GridLines="Horizontal" DataKeyNames="CHRG_ID" OnRowDataBound="gvdetails_RowDataBound"
                CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_right" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="40px">
                        <ItemTemplate>
                            <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'>
                            </asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="right" Width="40px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" HeaderStyle-Width="150px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Code" HeaderText="Code" HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Charge Type" HeaderText="Charge Type" HeaderStyle-Width="120px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="120px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Applicable For" HeaderText="Applicable For" HeaderStyle-Width="400px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="400px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Charge Category" HeaderText="Charge Category" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Global Charge" HeaderText="Global Charge" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IATA Code" HeaderText="IATA Code" HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px" Font-Size="11px" />
                    </asp:BoundField>
                </Columns>
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
          <script type="text/javascript">
             function clearFilters() {
                 document.getElementById('<%=ddlFilterActive.ClientID %>').value = 'Y';
                 document.getElementById('<%=ddlFilterChargeType.ClientID %>').value = '';
                 document.getElementById('<%=ddlFilterChargeCategory.ClientID %>').value = '';
                 document.getElementById('<%=ddlFilterApplicableFor.ClientID %>').value = '';
                 document.getElementById('<%=txtFilterName.ClientID %>').value = '';
             }
         </script>

</asp:Content>






