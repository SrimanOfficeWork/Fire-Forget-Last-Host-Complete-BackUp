<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="IMP_EXP_Job_Deleted_History_Search.aspx.cs" 
Inherits="IMP_EXP_Job_Deleted_History_Search" %>
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



<div id="innerbox_MidMain"  style="height:125px;" >


            <div id="tag_srcinner1" ">
        

<div id="tag_srcinner1"  >

                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   Deleted Job History
                 </div>

            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">

                         <div id="tag_label_transact_Src" style="width: 70px;">
                                Imp / Exp 
                            </div>
                            <div id="txtcon-m_src" style="width: 160px;">
                                <asp:DropDownList ID="ddl_Imp_Exp" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="150px" TabIndex="1" >
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Import" Value="I"></asp:ListItem>
                                <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                         
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Imp. Name
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlClient_Name" runat="server" CssClass="txtbox_none" 
                                    TabIndex="2" Font-Size="12px" Width="275px">
                                </asp:DropDownList>
                            </div>

                               <div id="tag_label_transact_Src" style="width: 70px;">
                                Jobno
                            </div>
                            <div id="txtcon-m_src" style="width: 160px;">
                                <asp:DropDownList ID="ddljobno" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                    Width="150px" TabIndex="3">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" style="width: 65px;">
                                From Date</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="4"></asp:TextBox>
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
                            <div id="tag_label_transact_Src"  style="width: 62px;">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="5"></asp:TextBox>
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
                              <div id="tag_label_transaction_Src_longlabel" style="width: 45px;"> Month</div>
                            
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="130px" TabIndex="6" >
                            </asp:DropDownList>
                        </div>


                      <%-- -------------------------------------------------------------------------------%>
                        </div>

                        <%------------------------------------------------------%>
                    </div>
                                               
                        
                    </div>
                    <div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();" onserverclick="btnSearch_Click"
                                tabindex="7"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="8"></a>
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
                    DataKeyNames="JOBNO" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" 
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

                        <asp:BoundField DataField="IMP_EXP" HeaderText="Imp/Exp"  HeaderStyle-Width="60px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="60px" Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JOBNO" HeaderText="Job No"  HeaderStyle-Width="70px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="70px" Font-Size="11px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name"  HeaderStyle-Width="300px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="300px" Font-Size="11px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="HISTORY" HeaderText="History"  HeaderStyle-Width="600px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="600px" Font-Size="12px" />
                        </asp:BoundField>
                       
                    </Columns>
                </asp:GridView>

            </div>
      <%--  </div>--%>
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

