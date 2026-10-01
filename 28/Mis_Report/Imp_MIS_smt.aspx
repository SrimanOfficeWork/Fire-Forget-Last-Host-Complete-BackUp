<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_MIS_smt.aspx.cs" Inherits="Import_MasterPage_Imp_MIS_smt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<style type="text/css" media="print">
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
</style>
<style type="text/css">
 .ad
 {
   width:50px  
 }

</style>
 
<div id="innerbox_MidMain" >
            <div id="tag_srcinner1" ">
              <div id="mainmastop2container_rght_tag2_txt1">
                     Import-MIS - II
                     </div>
            </div>
            <div id="tag_transact_src_inner" style="width:805px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn">
                     
                            <div id="tag_label_transact_Src">
                                Job No
                            </div>
                           
                            <div id="tag_label_transact_Src">

                                <asp:TextBox ID="txtJobNo" runat="server" CssClass="txtbox_none_Mid_transac_code_new"></asp:TextBox>
                           
                         
         </div>
         <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
          <div id="tag_label_transact_Src">
                                Importer Name
                            </div>
        <div id="tag_label_transact_Src">
        <asp:TextBox ID="txtimpname" runat="server" MaxLength="40" onblur="ChangeCase(this);"
                                                ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="5"></asp:TextBox>
        </div>
   
                       
                        
                    </div>

               

                    <div id="tag_transact_lft_in1" style="width:605px;">
                      
                                
                            
                            <div id="tag_label_transact_Src">
                                From Date</div>
                           
                            <div id="tag_label_transact_Src">
                                
                          
                                     <asp:TextBox ID="txtJobDate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                MaxLength="10" TabIndex="3"></asp:TextBox>
                           <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                                 Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            </div>
                            
                       <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                To Date
                            </div>
                            
                            <div id="tag_label_transact_Src">
                                
                            <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new" 
                                    MaxLength="10" TabIndex="4" ></asp:TextBox>
                                      <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                 Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           <div  id="tag_label_transaction_popup_no_empty">
                        </div>

                             <div id="tag_label_transaction_Src_longlabel">
                            Transport Mode</div>

                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddltr_mode" runat="server" CssClass="listtxt_transac_mode_new"
                                TabIndex="5">
                              
                            </asp:DropDownList>
                        </div>
                      
                   </div>
                </div>
                <div id="tag_transact_srcinner_rght">
                    <div id="small-butt-left">
                        <a href="#" class="srcbu" id="btnSearch" runat="server"  onserverclick="btnSearch1_Click" onclick="return validdate();" tabindex="6">
                        </a>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="7"></a>
                    </div>
                </div>
            </div>
             
        </div>

        <div id="innerbox_MidMain_Grid"  style="height:580px; " >
            <div id="tag_srcinner1grid">
             <div id="txtcon-m_transaction_code" style="margin-top:08px; width:70px;">
              <asp:ImageButton ID="btnprint" runat="server"  ImageUrl="~/images/print.jpg" Height="28px" Width="28px" OnClientClick="PrintGridData()"/>
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
              <%--<asp:ImageButton ID="btnpdf" runat="server"  ImageUrl="~/images/pdf.jpg" Height="28px" Width="28px" OnClientClick="Pdf()"/>--%>
              </div>
          
                 <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" OnClientClick="Mail_open();"  />
               </div>

            </div>
           
                <div id="tag_srcinner1grid_table_Container" >
            
                 <div id="Main_Grid_Container" style="overflow:hidden;" runat="server">
                
                      

               <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND"  
                        AutoGenerateColumns="false"  CssClass="grid-view" ShowHeader="true" 
                        ShowHeaderWhenEmpty="true" Width="550%"  OnRowDataBound="gvdetails_RowDataBound"
                        BorderStyle="Solid" BorderWidth="1px"
                         CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" >
                        
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" 
                            BorderWidth="1px" />
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                              
                                <Columns>
                               <asp:BoundField DataField="Job Number" HeaderText="Job No"  HeaderStyle-Width="2%" ControlStyle-Width="1%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  HorizontalAlign="center" Width="1%"     />
                               </asp:BoundField>
                                
                               <asp:BoundField DataField="Job Date" HeaderText="Job Date" HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   Width="2%"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="Importer" HeaderText="Importer"  HeaderStyle-Width="6%"  ControlStyle-Width="6%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle   CssClass="column_style_left_border" Width="6%" HorizontalAlign="Left" />
                               </asp:BoundField>

                                <asp:BoundField DataField="Branch Si No" HeaderText="Branch Sl No"  HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle CssClass="column_style_left_border" Width="2%" />
                               </asp:BoundField>

                                 <asp:BoundField DataField="Importer Address" HeaderText="Importer Address"  HeaderStyle-Width="10%"  ControlStyle-Width="10%"  HeaderStyle-HorizontalAlign="Center"  >
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Left" Width="10%"/>
                               </asp:BoundField>


                                 <asp:BoundField DataField="Transport Mode" HeaderText="Transport Mode"   HeaderStyle-Width="2%"  ControlStyle-Width="2%"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" Width="2%"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="CountryOfOrigin" HeaderText="Country Of Origin" HeaderStyle-Width="4%"  ControlStyle-Width="4%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Left" Width="4%" />
                               </asp:BoundField>

                               <asp:BoundField DataField="CountryOfShipment" HeaderText="Country Of Shipment" HeaderStyle-Width="5%"  ControlStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Left" Width="4%"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="BENo" HeaderText="BENo"  HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   CssClass="column_style_left_border"  HorizontalAlign="Left" Width="3%"/>
                               </asp:BoundField>

                              <asp:BoundField DataField="BEDate" HeaderText="BEDate"  HeaderStyle-Width="3%"  ControlStyle-Width="3%"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" Width="2%"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="MAWB" HeaderText="MAWB" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   CssClass="column_style_left_border" HorizontalAlign="Left" Width="3%"  />
                               </asp:BoundField> 

                               <asp:BoundField DataField="MBL Date" HeaderText="MBL Date" HeaderStyle-Width="3%"  ControlStyle-Width="3%"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" Width="2%" />
                               </asp:BoundField>

                                <asp:BoundField DataField="HAWB" HeaderText="HAWB" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   CssClass="column_style_left_border" HorizontalAlign="Left" Width="3%"/>
                               </asp:BoundField>

                               <asp:BoundField DataField="HBL Date" HeaderText="HBL Date" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" Width="2%"/>
                               </asp:BoundField>

                               <asp:BoundField DataField="Term of Shipment" HeaderText="Terms" HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"  Width="2%"  />
                               </asp:BoundField>

                                <asp:BoundField DataField="Product Description" HeaderText="Product Description" HeaderStyle-Width="8%"  ControlStyle-Width="8%"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"  Width="8%" HorizontalAlign="Left" />
                               </asp:BoundField>

                               <asp:BoundField DataField="CTH no" HeaderText="CTH no" HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border_pa" HorizontalAlign="Left" Width="2%" />
                               </asp:BoundField>

                               <asp:BoundField DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="2%"  ControlStyle-Width="2%"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right" Width="2%"  />
                                </asp:BoundField>

                               <asp:BoundField DataField="Unit" HeaderText="Unit" HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"  Width="2%"  />
                                </asp:BoundField>

                              <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice"  HeaderStyle-Width="3%"  ControlStyle-Width="3%"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right" Width="3%"  />
                                </asp:BoundField>

                                <asp:BoundField DataField="InvoiceNo" HeaderText="InvoiceNo" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border_pa" HorizontalAlign="Right" Width="3%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="INV Date" HeaderText="INV Date" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"  Width="3%"  />
                                </asp:BoundField>

                                <asp:BoundField DataField="InvoiceCurrency" HeaderText="Inv Currency"  HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Right" >
                                <ItemStyle  CssClass="column_style_left_border" Width="2%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Exc.Rate" HeaderText="Exc.Rate"   HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Right" >
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Center" Width="2%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="InvoiceValue in INR" HeaderText="InvoiceValue in INR" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right" Width="3%"  />
                                </asp:BoundField>

                                <asp:BoundField DataField="Freight Currency" HeaderText="Freight Curr" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" Width="2%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Freight Percentage" HeaderText="Freight Percentage" HeaderStyle-Width="4%"  ControlStyle-Width="4%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle   CssClass="column_style_left_border"  HorizontalAlign="Right" Width="3%"/>
                                </asp:BoundField>

                                <asp:BoundField DataField="Freight Amount" HeaderText="Freight Amount" HeaderStyle-Width="4%"  ControlStyle-Width="4%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right" Width="3%"/>
                                </asp:BoundField>

                                <asp:BoundField DataField="Insurance Amount" HeaderText="Insurance Amount"  HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right" Width="3%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="MiscCurrency" HeaderText="Misc Currency" HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border"  Width="2%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Misc Charges" HeaderText="Misc Charges" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle   CssClass="column_style_left_border" HorizontalAlign="Right" Width="3%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="CIF Value" HeaderText="CIF Value"  HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right" Width="3%" />
                                </asp:BoundField> 

                                <asp:BoundField DataField="Total Assasable Value" HeaderText="Total Assasable Value" HeaderStyle-Width="3%"  HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle   CssClass="column_style_left_border"  HorizontalAlign="Right" Width="3%"  />
                                </asp:BoundField>

                                <asp:BoundField DataField="BASIC Notn" HeaderText="BASIC Notn" HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Center"  Width="2%" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="BCD" HeaderText="BCD" HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Center" Width="2%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="MRPSNo" HeaderText="MRPSNo" HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle   CssClass="column_style_left_border" Width="2%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="MRP" HeaderText="MRP"  HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" Width="2%" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="MRPUnit" HeaderText="MRPUnit" HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right" Width="2%" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="CVD" HeaderText="CVD"   HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right"  Width="3%"  />
                                </asp:BoundField>

                                 <asp:BoundField DataField="GROSS WT(kgs)" HeaderText="GROSS WT(kgs)" HeaderStyle-Width="4%"  ControlStyle-Width="4%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="Right"  Width="3%"/>
                                </asp:BoundField>

                                 <asp:BoundField DataField="PurchaseOrdNo" HeaderText="PO No"  HeaderStyle-Width="4%"  ControlStyle-Width="4%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border"  Width="4%"  HorizontalAlign="Left"/>
                                </asp:BoundField>

                                 <asp:BoundField DataField="PurchaseOrdDate" HeaderText="PO Date" HeaderStyle-Width="2%"  ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border" Width="2%" />
                                </asp:BoundField>

                                <asp:BoundField DataField="LicNo" HeaderText="LicNo" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="Left" Width="3%"/>
                                </asp:BoundField>

                                 <asp:BoundField DataField="LicDate" HeaderText="LicDate" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border" Width="2%" HorizontalAlign="Center" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="Debit Value" HeaderText="Debit Value" HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Right" >
                                <ItemStyle   CssClass="column_style_left_border"  HorizontalAlign="Right" Width="3%"/>
                                </asp:BoundField>

                                 <asp:BoundField DataField="Qty" HeaderText="Qty"  HeaderStyle-Width="3%"  ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"  HorizontalAlign="Center" Width="3%" />
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
        /* Autocomplete Textbox Search Loading Image*/
    </style>

  <script type="text/javascript">
      function PrintGridData() {
          var prtGrid = document.getElementById('<%=gvdetails.ClientID %>');
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
          if (lastProductId != 'NO RECORD FOUND') {
              prtGrid.border = 1;

              var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
              prtwin.moveTo(0, 0);
              prtwin.resizeTo(screen.width, screen.height - 100);
              prtwin.document.write(prtGrid.outerHTML);
              prtwin.document.close();
              prtwin.focus();
              prtwin.print();
              prtwin.close();


          }
      }
</script>
  <script type="text/javascript">
      var win = null;

      var Jobdate = $('#<%= txtJobDate.ClientID %>').val();
      var Imp_name = $('#<%= txtimpname.ClientID %>').val();
      var Tr_mode = $('#<%= ddltr_mode.ClientID %>').val();
      var jobno = $('#<%= txtJobNo.ClientID %>').val();
      var Todate = $('#<%= txttodate.ClientID %>').val();

      var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
      var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

      if (lastProductId != 'NO RECORD FOUND') {
          function EXcel() {
             
              var Type = 'excel';
//                win = window.open('../FlatFile/MIS_report_1.aspx?MIS_stat=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&jobno=' + jobno + '&Todate=' + Todate + '&Type=' + Type + '', 'ndf');
                win = window.open('../FlatFile/MIS_report_1.aspx?MIS_stat=Yes&Jobdate=' + Jobdate + '&Imp_name=' + encodeURIComponent(Imp_name) + '&Tr_mode=' + Tr_mode + '&jobno=' + jobno + '&Todate=' + Todate + '&Type=' + Type + '', 'ndf');

              Loading_HideImage();
          }

          function Mail_open() {
              var Type = 'excel';
              var w = '700';
              var h = '800';
              LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
              TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
              settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
              win = window.open('../Report/Mail_Send.aspx?IMP_MIS_Rpt_2=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&jobno=' + jobno + '&Todate=' + Todate + '&Type=' + Type + '', 'ndf', settings);
              win.focus();
              return false;
          }
        
      }

  </script>
  <script type="text/javascript">
      $(document).ready(function () {

          var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

          if (lastProductId != 'NO RECORD FOUND') {
          gridviewScroll();
          }
//          else {
//              $("#Main_Grid_Container").css("overflow", "auto"); : 
//          }

      });

      function gridviewScroll() {
          gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

              width: 930,
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

