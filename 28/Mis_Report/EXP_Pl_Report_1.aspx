<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="EXP_Pl_Report_1.aspx.cs" Inherits="Import_MasterPage_EXP_Pl_Report_1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 &nbsp;<style type="text/css" media="print">
    @page 
    {
        size: auto;   /* auto is the initial value */
        margin: 0mm;  /* this affects the margin in the printer settings */
    }
    
    @media print 
    {
    /*****   Styles for print   ******/
      h1, h2, h3 {color:black;}
      #navigation {display:none}
    }
 
    @media screen {
      /*****   Styles for screen  ******/
    }
</style><div id="innerbox_MidMain" style=" height:128px;">
            <div id="tag_srcinner1" ">
              <div id="mainmastop2container_rght_tag2_txt1">
                    Export PL 1 (Personal Ledger Account 1) :- 
                     </div>
            </div>
            <div id="tag_transact_src_inner" style="width:805px;">
               <div id="tag_transaction_inner_new" style="margin-left:20px;">

                      <%-- Row-1  --%>
                   <div id="tag_Exchange_lft_in1_new1">
                       <div id="tag_label_transaction_Src_new">
                           From Date
                       </div>
                       <div id="txtcon-m_transaction_code">
                           <asp:TextBox ID="txtJobDate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                               MaxLength="10" TabIndex="2"></asp:TextBox>
                           <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                               Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                               MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                           </cc1:MaskedEditExtender>
                           <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                               PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                           </cc1:CalendarExtender>
                       </div>
                       <div id="tag_label_transaction_popup_IGM2_empty">
                       </div>
                       <div id="tag_label_transaction_Src_new">
                           To Date
                       </div>
                       <div id="tag_label_transact_Src">
                           <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                               MaxLength="10" TabIndex="3"></asp:TextBox>
                           <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                               Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                               MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                           </cc1:MaskedEditExtender>
                           <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                               PopupButtonID="txttodate" Format="dd/MM/yyyy">
                           </cc1:CalendarExtender>
                       </div>
                       <div id="tag_label_transaction_popup_mode_empty">
                       </div>
                       <div id="tag_label_transaction_date">
                           Exporter Name
                       </div>
                       <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                           <asp:TextBox ID="txtExpname" runat="server" MaxLength="40" onblur="ChangeCase(this);"
                               ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Onkeypress="return numcharspl1(event)"
                               TabIndex="5"></asp:TextBox>
                       </div>
                       <div id="tag_label_transaction_popup_no_empty">
                       </div>
                   </div>


                     <%-- Row-2  --%>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                  
                    <%-- Row-3  --%>
                    <div id="tag_Exchange_lft_in1_new1">
                    <div id="tag_label_transaction_Src">
                            Branch
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                        <asp:TextBox ID="txtbranch" runat="server" MaxLength="10" 
                            ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"
                                TabIndex="6" ></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                   
                        
                                           
                     <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                     <%--  ROW-4--%>
                    </div>


                    <div id="tag_label_transaction_popup_mode_empty" style="padding-left:300px;">
                    </div>
                  <div id="tag_label_transaction_Src_longlabel" style="padding-top:10px;" >
                                           <div id="small-butt-left" >
                                <a href="#" class="srcbu" id="btnSearch" runat="server"   onserverclick="btnSearch_Click" 
                                                   tabindex="10">
                                </a>
                              </div>
                            </div>
                        <div id="txtcon-m_transaction_mode" style="padding-top:10px;" >
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="11"></a>
                        </div>
                    
                </div> 
                
                
            </div>
        </div>


        <div id="innerbox_MidMain_Grid"  style="height:580px; ">
            <div id="tag_srcinner1grid">
             <div id="txtcon-m_transaction_code" style="margin-top:08px;width:70px;">
              <asp:ImageButton ID="btnprint" runat="server"  ImageUrl="~/images/print.jpg" Height="28px" Width="28px" OnClientClick="PrintGridData()"/>
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
              <%--<asp:ImageButton ID="btnpdf" runat="server"  ImageUrl="~/images/pdf.jpg" Height="28px" Width="28px" OnClientClick="Pdf()"/>--%>
               <%--<asp:Button ID="btnSend" CssClass="send_btn" Text="Send" runat="server" OnClientClick="Mail_open();" />--%>
              
              </div>
            <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" OnClientClick="Mail_open();"  /></div>
            </div>
           
                <div id="tag_srcinner1grid_table_Container" >
            
                 <div id="Main_Grid_Container" style="overflow:hidden;" runat="server">
                 
                 

                        <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND"  
                        AutoGenerateColumns="false"  CssClass="grid-view" ShowHeader="true" 
                        ShowHeaderWhenEmpty="true" Width="360%"  
                         CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" >
                        
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" 
                            BorderWidth="1px" />
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                              
                                <Columns>
                               <asp:BoundField DataField="Job Number" HeaderText="Job Number"  HeaderStyle-Width="80px" ControlStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  HorizontalAlign="Left" Width="80px"    />
                               </asp:BoundField>
                                
                               <asp:BoundField DataField="Job Date" HeaderText="Job Date" HeaderStyle-Width="70px"  ControlStyle-Width="70px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  HorizontalAlign="Center"  Width="70px"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="Buyer Name" HeaderText="Buyer Name"  HeaderStyle-Width="300px"  ControlStyle-Width="300px" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle   CssClass="column_style_left_border_3" Width="280px" HorizontalAlign="Left" />
                               </asp:BoundField>

                                <asp:BoundField DataField="Country Discharge" HeaderText="Country Discharge"  HeaderStyle-Width="200px"   HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle CssClass="column_style_left_border_3" HorizontalAlign="Left" Width="200px" />
                               </asp:BoundField>

                               
                                 <asp:BoundField DataField="Exporter" HeaderText="Exporter Name"    HeaderStyle-Width="310px"  ControlStyle-Width="310px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  HorizontalAlign="Left" CssClass="column_style_left_border_3"    Width="310px" />
                               </asp:BoundField>

                               
                               <asp:BoundField DataField="SB Number" HeaderText="SB Number"  HeaderStyle-Width="100px"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Left"  CssClass="column_style_left_border" Width="100px"  />
                               </asp:BoundField>

                              <asp:BoundField DataField="SB Date" HeaderText="SB Date"  HeaderStyle-Width="100px"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" Width="100px" />
                               </asp:BoundField>

                                  <asp:BoundField DataField="Invoice_Exchange_Rate" HeaderText="Inv Cur Ex-Rate"  HeaderStyle-Width="120px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   CssClass="column_style_left_border" HorizontalAlign="Center" Width="120px"   />
                               </asp:BoundField> 

                                  <asp:BoundField DataField="Invoice no" HeaderText="Invoice no"  HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border_3" Width="150px" />
                               </asp:BoundField>

                                <asp:BoundField DataField="Invoice date" HeaderText="Invoice date" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   CssClass="column_style_left_border" HorizontalAlign="Center" Width="100px" />
                               </asp:BoundField>

                               <asp:BoundField DataField="Product Description" HeaderText="Product Description"   HeaderStyle-Width="650px"  ControlStyle-Width="650px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Left"  Width="650px" CssClass="column_style_left_border" />
                               </asp:BoundField>

                               <asp:BoundField DataField="Product Quantity" HeaderText="Product Qty" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right" Width="100px"  />
                               </asp:BoundField>

                                <asp:BoundField DataField="RITC No" HeaderText="RITC No"  HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"  Width="100px" HorizontalAlign="Center"/>
                               </asp:BoundField>

                               <asp:BoundField DataField="Unit Price" HeaderText="Unit Price" HeaderStyle-Width="90px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border_pa"  Width="90px" HorizontalAlign="Right" />
                               </asp:BoundField>

                               <asp:BoundField DataField="Product Amount" HeaderText="Product Amt" HeaderStyle-Width="100px"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right" Width="100px"  />
                                </asp:BoundField>

                               <asp:BoundField DataField="Invoice Currency" HeaderText="Invoice Currency" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Center"  Width="100px" />
                                </asp:BoundField>
                                  <asp:BoundField DataField="Total_Packages" HeaderText="Total Packages" HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_right_new" HorizontalAlign="Right"  Width="100px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Gross_Weight(Kgs)" HeaderText="Gross Weight(Kgs)" HeaderStyle-Width="120px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_right_new" HorizontalAlign="Right"  Width="120px" />
                                </asp:BoundField>

                                  <asp:BoundField DataField="Net_Weight(Kgs)" HeaderText="Net Weight(Kgs)" HeaderStyle-Width="120px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_right_new" HorizontalAlign="Right"  Width="120px" />
                                </asp:BoundField>

                                
                             
                                </Columns>
                                 <PagerSettings Visible="False" />
                        </asp:GridView>
                     <asp:HiddenField ID="Hd_Job_Type" runat="server" />
                </div>
            </div>
             
         
             
        </div>
        <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
        
        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>

  <script type="text/javascript">
      function PrintGridData() {
          var prtGrid = document.getElementById('<%=gvdetails.ClientID %>');
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
          if (lastProductId != 'NO RECORD FOUND') {
              prtGrid.border = 1;

              var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
              prtwin.document.write(prtGrid.outerHTML);
              prtwin.document.close();
              prtwin.focus();
              prtwin.print();


          }
      }
</script>
 

  <script type="text/javascript">
      var win = null;
      var Jobdate = $('#<%= txtJobDate.ClientID %>').val();
      var Todate = $('#<%= txttodate.ClientID %>').val();

      var Imp_name = $('#<%= txtExpname.ClientID %>').val();
      var Branch = $('#<%= txtbranch.ClientID %>').val();

      var Job_Type = $('#<%= Hd_Job_Type.ClientID %>').val();
       

      var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
      var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

      if (lastProductId != 'NO RECORD FOUND') {
          function EXcel() {

              var Type = 'excel';
              win = window.open('../FlatFile/MIS_report_1.aspx?EXP_Pl_Rpt_1=Yes&Jobdate=' + Jobdate + '&Todate=' + Todate + '&Imp_name=' + Imp_name + '&Branch=' + Branch + '&Type=' + Type + '&Job_Type=' + Job_Type + '&PL=EX_PL1', 'ndf');
              Loading_HideImage();
          }

          function Pdf() {
              var Type = 'Pdf';
              win = window.open('../FlatFile/MIS_report_1.aspx?EXP_Pl_Rpt_1=Yes&Jobdate=' + Jobdate + '&Todate=' + Todate + '&Imp_name=' + Imp_name + '&Branch=' + Branch + '&Type=' + Type + '&Job_Type=' + Job_Type + '&PL=EX_PL1', 'ndf');
              Loading_HideImage();
          }
          function Mail_open() {
              var Type = 'excel';
              var w = '700';
              var h = '800';
              LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
              TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
              settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
              win = window.open('../Report/Mail_Send.aspx?EXP_Pl_Rpt_1_Excel=Yes&Jobdate=' + Jobdate + '&Todate=' + Todate + '&Imp_name=' + Imp_name + '&Branch=' + Branch + '&Type=' + Type + '&Job_Type=' + Job_Type + '&PL=EX_PL1', 'ndf', settings);
              win.focus();

              return false;
          }

      }

  </script>


   


   
  <script type="text/javascript">
      $(document).ready(function () {
          /* gridviewScroll();*/

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
                  document.getElementById('<%=gvdetails.ClientID %>').style.width = "200%";
                  /*alert (lastProductId);*/
              }
          }
      });

      function gridviewScroll() {
          gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

              width: 950,
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

