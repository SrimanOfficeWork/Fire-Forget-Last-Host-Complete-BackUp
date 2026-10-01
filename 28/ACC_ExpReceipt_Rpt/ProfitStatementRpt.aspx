<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="ProfitStatementRpt.aspx.cs" 
Inherits="ProfitStatementRpt"  EnableEventValidation="false"  %>
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
 

<div id="innerbox_MidMain"  style="height:125px;" >


          
        

<div id="tag_srcinner1"  >
           
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                  <asp:RadioButtonList ID="Rd_Job_Type" runat="server" RepeatDirection="Horizontal"  TabIndex="5"  >
                                    <asp:ListItem Text="Imp" Value="Imp" Selected="True" ></asp:ListItem>
                                    <asp:ListItem Text="Exp" Value="Exp"></asp:ListItem>
                                     <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                                    </asp:RadioButtonList>
                 </div>
                  
 
                  <div id="verslic"> </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:50px;">
                     
                      <a href="#"  id="btnex" runat="server"   style="display: block;	width: 50px;margin-top:-6px;	height: 30px;	background-image:url('../images/xls.jpg');	background-repeat:no-repeat;"
                                   onserverclick="btnexcel_Click"
                                tabindex="7"></a>
                </div>

                <div id="mainmastop2container_rght_tag2_txt1" style="width:50px;">
                     
                       <a href="#"  id="btnRdlc" runat="server"   style="display: block;	width: 50px;margin-top:-6px;	height: 30px;	background-image:url('../images/pdf.jpg');	background-repeat:no-repeat;"
                                   onserverclick="btnRdlc_Click"
                                tabindex="7"></a>
                </div>


                 <div  id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                Profit- Report
                </div>

                  
            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                      <div id="tag_label_transact_Src" style="width: 110px;">
                              Report Type:
                            </div>
                          <div id="txtcon-m_src" style="width: 100px;">
                               <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none" Font-Size="12px" AutoPostBack="true"  Width="95px" onselectedindexchanged="ddltype_SelectedIndexChanged"  >
                               <asp:ListItem Text="--Select--" Value="--Select--" ></asp:ListItem>
                                <asp:ListItem Text="Job Wise" Value="JobWise" ></asp:ListItem>
                               <%--<asp:ListItem Text="Customer Wise" Value="CustomerWise" ></asp:ListItem>--%> <%--Need to change in SP:Load_ddl flag :Select-CustomerWiseProfit--%>
                              <%--  <asp:ListItem Text="Bill/Invoice" Value="BillInvWise" ></asp:ListItem>--%>
                               <asp:ListItem Text="All" Value="All" ></asp:ListItem>           
                                                             
                               </asp:DropDownList>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 170px;">
                                
                                   <asp:TextBox ID="txtsearch" runat="server"  ClientIDMode="Static"  Visible="false"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                                
                            </div>

                            
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           
                            <div id="tag_label_transact_Src" style="width: 110px;">
                              <asp:Label ID="lblsearch" runat="server"></asp:Label>
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlSearchValue" runat="server" CssClass="txtbox_none"  Visible="false"
                                     Font-Size="12px" Width="275px" >
                                </asp:DropDownList>
                            
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                            <div id="DivJob" runat="server" visible="false">
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Job No
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" 
                                     Font-Size="12px" Width="275px"  >
                                </asp:DropDownList>
                            </div>
                            </div>

                             <div id="DivBillInv" runat="server" visible="false">
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Bill / Invoice No
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlBillInvNo" runat="server" CssClass="txtbox_none" 
                                     Font-Size="12px" Width="275px"  >
                                </asp:DropDownList>
                            </div>
                            </div>

                            
                        </div>

                    </div>
                                               
                        
                    </div>
                 
                     <div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" OnClientClick="return validate_Report();"  onserverclick="btnSearch_Click"
                                tabindex="5"></a>
                        </div>
                        <div id="small-butt-rght">
                                                   <a href="#"  id="btnCancel" runat="server" class="cancelButt"  onserverclick="btnCancel_Click"
                                tabindex="6"></a>

                        </div>
                    </div>

                </div>
                  <%-- --------------------------------------------End---------------------------%>
                 

        </div>

         
    <div id="innerbox_MidMain_Grid" style="height: 580px;margin-top:-13px;">
        <div id="Main_Grid_Container" runat="server">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="true"
                CssClass="grid-view" ShowHeader="true" ShowFooter="true" ShowHeaderWhenEmpty="true"
                Width="100%" DataKeyNames="jobno,CustomerName" OnRowDataBound="gvdetails_RowDataBound"
                CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_left" BorderWidth="1px" HorizontalAlign="Left" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
       
    </div>
    <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
        <script src="../js/iframepopupwin.js" type="text/javascript"></script>
 <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>

      
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

