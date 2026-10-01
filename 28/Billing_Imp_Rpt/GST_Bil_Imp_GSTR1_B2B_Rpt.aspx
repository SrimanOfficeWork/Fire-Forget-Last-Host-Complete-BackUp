<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="GST_Bil_Imp_GSTR1_B2B_Rpt.aspx.cs" Inherits="Billing_Imp_Invoice_Job_Search" %>
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
<script type = "text/javascript">
    function MutExChkList(chk) {
        if (chk.checked == true) {
           
        }
        else {
           
           
           

        }
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
                 GST_BILL_IMP_GSTR1_B2B_RPT
                 </div>
                     
                     <div id="editbu" style="padding-top:3px;">
                      
                       <%--<input type="submit" value="Submit" class="new" onclick="openGeneral_Search_New('New'); return false" />--%>
                      
                </div>
                   
                     
                  <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
                </div>
                   
                     
              <%--   <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btncopy" runat="server"  ToolTip="Invoice Copy"  ImageUrl="~/images/icons/Copy.png"  Height="28px" Width="28px" OnClientClick="Tally()"  />
                </div>--%>
                

            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        

                          
                            

                          
                            
                            
                            
                            
                            
                          
                              
                           

                             
                        <div id="tag_label_transact_Src" style="width: 95px;">
                    Importer  Name
                </div>


                <div id="tag_label_transact_Src" style="width: 350px;">

                <asp:DropDownList ID="ddl_Imp_Exp" runat="server" CssClass="listtxt_transac_mode_new"
                        TabIndex="1" Width="300px"
                        AutoPostBack="true" 
                        onselectedindexchanged="ddl_Imp_Exp_SelectedIndexChanged">
                       
                    </asp:DropDownList>
              

                </div>
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 700px;">
                            <div id="tag_label_transact_Src" style="width: 65px;">
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
                            <div id="tag_label_transact_Src"  style="width: 62px;">
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
        <%--<div id="tag_srcinner1grid">
        </div>--%>
       <%-- <div id="tag_srcinner1grid_table_Container">--%>
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">  

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="120%"
                    DataKeyNames="Invoice_No" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
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

                        
                         <asp:BoundField DataField="GSTN_ID" HeaderText="GSTIN Recipient"  HeaderStyle-Width="125px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="125px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Invoice_No" HeaderText="Invoice No"  HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="80px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Invoice_Date" HeaderText="Invoice Date"  HeaderStyle-Width="70px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="70px"/>
                        </asp:BoundField>


                         <asp:BoundField DataField="Invoice_value" HeaderText="Invoice Value"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="80px"/>
                        </asp:BoundField>

                         <asp:BoundField DataField="Place_of_Supply" HeaderText="Place of Supply"  HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Left">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="90px"/>
                        </asp:BoundField>

                        
                         <asp:BoundField DataField="Reverse_Charge"  HeaderText="Reverse Charge" HeaderStyle-HorizontalAlign="Left"   HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="80px"/>
                        </asp:BoundField>

                         <asp:BoundField DataField="Invoice_Type"  HeaderText="Invoice Type" HeaderStyle-HorizontalAlign="Left"   HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="80px"/>
                        </asp:BoundField>
                        
                         <asp:BoundField DataField="E-Commerce GSTIN"  HeaderText="E-Commerce GSTIN" HeaderStyle-HorizontalAlign="Left"   HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="80px"/>
                        </asp:BoundField>
                        

                         <asp:BoundField DataField="Rate"   HeaderText="Rate" HeaderStyle-HorizontalAlign="Left"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="80px"/>
                        </asp:BoundField>

                        
                         <asp:BoundField DataField="Taxable_Value"  HeaderText="Taxable Value"  HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="80px"/>
                        </asp:BoundField>

                        
                         <asp:BoundField DataField="Cess_Amt"  HeaderText="Cess Amt" HeaderStyle-HorizontalAlign="Left"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="80px"/>
                        </asp:BoundField>


                        
                         <asp:BoundField DataField="Invoice_value" HeaderText="Invoice Value"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="80px"/>
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

      <asp:HiddenField ID="HDBranch" runat="server" />

       <asp:HiddenField ID="Hd_Select_Item" runat="server" />

      <script language="javascript">
    function Inv_Bill() {
        var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
        var Bill_Invo = document.getElementById("<%=hdBill_invno.ClientID %>").value;
        var Tax_Mode ='B';

        if (jobno != '') {
            NewWindow1('../Billing_Imp_Rpt/Bill_Import_Job_rpt.aspx?Jobno=' + encodeURIComponent(jobno) + '&Bill_Invo=' + Bill_Invo + '&Tax_Mode=' + Tax_Mode + '', 'List', '870', '1024', 'yes');
        }
        else {
            jAlert('Select a Grid Job', 'Bill Invoice', function (r) { document.getElementById("ddljobno").focus(); });
        }
        
    }
    </script>

      <script type="text/javascript">
          var win = null;

          var ddl_Imp_Exp = $('#<%= ddl_Imp_Exp.ClientID %>').val();
          var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
          var Todate = $('#<%= txttodate.ClientID %>').val();
         

          var Branch = $('#<%= HDBranch.ClientID %>').val();
     
       

          var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
    

          if (lastProductId != 'NO RECORD FOUND') {
              function EXcel() {
                  var Type = 'excel';
                  win = window.open('../FlatFile/MIS_report_1.aspx?GST_BILL_IMP_GSTR1_B2B_RPT=Yes&ddl_Imp_Exp=' + ddl_Imp_Exp +'&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf'); 
                  Loading_HideImage();
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

