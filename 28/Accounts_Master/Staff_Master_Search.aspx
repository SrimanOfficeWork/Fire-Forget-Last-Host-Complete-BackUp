<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Staff_Master_Search.aspx.cs" Inherits="Staff_Master_Search" %>
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
    .selected_row<a href="Staff_Master_Search.aspx">Staff_Master_Search.aspx</a>
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

          function ChangeRowColor(rowID, Value) {
              document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
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
<div id="tag_srcinner1">
<div id="tag_srcinner1">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_Staff_Master_N('New'); return false" />
                </div>

                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:150px;">
                  Staff Master
                 </div>

            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Emp. Id
                            </div>
                            <div id="txtcon-m_src" style="width: 150px;">
                                <asp:TextBox ID="txtEmp_Id" runat="server" CssClass="txtbox_none_Mid_transac_src"
                                    ClientIDMode="Static" MaxLength="50" Width="140px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Staff Name
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlstaff_name" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                    Width="275px">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                             <div id="tag_label_transact_Src" style="width: 70px;">
                                Mobile No
                            </div>
                            <div id="txtcon-m_src" style="width: 150px;">
                                <asp:TextBox ID="txtMobile_No" runat="server" CssClass="txtbox_none_Mid_transac_src"  Onkeypress="return num1(event)"
                                    ClientIDMode="Static" MaxLength="50" Width="140px"></asp:TextBox>
                            </div>
                            
                        </div>

                        <div id="tag_transact_lft_in1" style="width: 885px;">
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
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%" GridLines="Horizontal"
                    DataKeyNames="STAFF_ID" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" 
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" Width="45px"  />
                        </asp:TemplateField>
                        <asp:BoundField DataField="STAFF_CODE" HeaderText="Staff Code"  HeaderStyle-Width="140px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="140px" Font-Size="11px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="Emp. Id"  HeaderStyle-Width="150px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="150px" Font-Size="11px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="STAFF_FULL_NAME" HeaderText="Staff Name"  HeaderStyle-Width="455px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="455px" Font-Size="11px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="DOJ" HeaderText="DOJ"  HeaderStyle-Width="100px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="100px" Font-Size="11px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="EMP_STATUS" HeaderText="Emp. Status"  HeaderStyle-Width="90px"  >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="90px" Font-Bold="true" Font-Size="11px" />
                        </asp:BoundField>

                    </Columns>
                </asp:GridView>
            </div>
         </div>

        <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
        <script src="../js/iframepopupwin.js" type="text/javascript"></script>


        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
       
    </style>
     <asp:HiddenField ID="hdrowindex" runat="server" />
     <asp:HiddenField ID="hdBill_invno" runat="server" />
     <asp:HiddenField ID="HDBranch" runat="server" />

     <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
     
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

