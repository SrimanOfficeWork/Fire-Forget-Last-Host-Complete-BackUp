<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="IMP_Pl_Report_1.aspx.cs" Inherits="Import_MasterPage_IMP_Pl_Report_1" %>
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
</style>

<div id="innerbox_MidMain" style=" height:128px;">
            <div id="tag_srcinner1">
              <div id="mainmastop2container_rght_tag2_txt1">
                Import PL 1 (Personal Ledger Account 1) :- 
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
                             <asp:TextBox ID="txtJobDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="10" TabIndex="2"></asp:TextBox>
                           <cc1:maskededitextender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" 
                                ErrorTooltipEnabled="True" >
                            </cc1:maskededitextender>
                            <cc1:calendarextender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                                PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                            </cc1:calendarextender>

                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                            <div id="tag_label_transaction_Src_new">
                        
                            To Date
                        </div>
                        
                        <div id="txtcon-m_transaction_code">
                        
                                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="10" TabIndex="3"></asp:TextBox>
                           <cc1:maskededitextender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" 
                                ErrorTooltipEnabled="True" >
                            </cc1:maskededitextender>
                            <cc1:calendarextender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                PopupButtonID="txttodate" Format="dd/MM/yyyy">
                            </cc1:calendarextender>
                          

                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                         
                    
                        <div id="tag_label_transaction_date">
                        Importer_Name
                        </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtimpname" runat="server" MaxLength="40" onblur="ChangeCase(this);"
                                                ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="5"></asp:TextBox>

                          
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
            <%--  <asp:Button ID="btnSend" CssClass="send_btn" Text="Send" runat="server" OnClientClick="Mail_open();"  />--%>
              </div>
          
           <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" OnClientClick="Mail_open();"  /></div>
            </div>
           
           
                <div id="tag_srcinner1grid_table_Container" >
            
                 <div id="Main_Grid_Container" style="overflow:hidden;" runat="server">

                        <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND"  
                        AutoGenerateColumns="false"  CssClass="grid-view" ShowHeader="true" 
                        ShowHeaderWhenEmpty="true" Width="600%"  OnRowDataBound="gvdetails_RowDataBound"
                         CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" >
                        
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" 
                            BorderWidth="1px" />
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                              
                                <Columns>
                               <asp:BoundField DataField="Job Number" HeaderText="Job Number"  HeaderStyle-Width="80px" ControlStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  HorizontalAlign="Left" Width="80px"    />
                               </asp:BoundField>
                                
                               <asp:BoundField DataField="Job Date" HeaderText="Job Date" HeaderStyle-Width="120px"  ControlStyle-Width="120px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   Width="120px"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="Consignor" HeaderText="Consignor"  HeaderStyle-Width="400px"  ControlStyle-Width="400px" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle   CssClass="column_style_left_border" Width="400px" HorizontalAlign="Left" />
                               </asp:BoundField>



                                <asp:BoundField DataField="Consignors Country" HeaderText="Consignors Country"  HeaderStyle-Width="250px"  ControlStyle-Width="250px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle CssClass="column_style_left_border"  Width="250px" HorizontalAlign="Left"/>
                               </asp:BoundField>

                                 <asp:BoundField DataField="country_Orgin" HeaderText="Country Orgin"    HeaderStyle-HorizontalAlign="Center"  >
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Left" />
                               </asp:BoundField>

                               
                                 <asp:BoundField DataField="Importer" HeaderText="Importer"    HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  HorizontalAlign="Left" CssClass="column_style_left_border"   />
                               </asp:BoundField>

                               <asp:BoundField DataField="House BL/House Awb No" HeaderText="House BL/House Awb No"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Left" CssClass="column_style_left_border"  />
                               </asp:BoundField>

                               <asp:BoundField DataField="House BL/House Awb Date" HeaderText="House BL/House Awb Date"  HeaderStyle-Width="150px"  ControlStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" Width="150px" />
                               </asp:BoundField>
                              

                         <asp:BoundField DataField="BE Number" HeaderText="BE Number"   HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Left"  CssClass="column_style_left_border"  />
                               </asp:BoundField>

                              <asp:BoundField DataField="BE Date" HeaderText="BE Date"    HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"  />
                               </asp:BoundField>

                                  <asp:BoundField DataField="Invoice Currencys Exchange Rate" HeaderText="Inv Cur Ex-Rate"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   CssClass="column_style_left_border" HorizontalAlign="Right"   />
                               </asp:BoundField> 

                                  <asp:BoundField DataField="Invoice no" HeaderText="Invoice no" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" />
                               </asp:BoundField>

                                <asp:BoundField DataField="Invoice date" HeaderText="Invoice date"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   CssClass="column_style_left_border" HorizontalAlign="Center" />
                               </asp:BoundField>

                               <asp:BoundField DataField="Product Description" HeaderText="Product Description" HeaderStyle-Width="800px"  ControlStyle-Width="800px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Left" CssClass="column_style_left_border" Width="800px"/>
                               </asp:BoundField>

                               <asp:BoundField DataField="Product Quantity" HeaderText="Product Quantity"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"    />
                               </asp:BoundField>

                                <asp:BoundField DataField="Custom Tariff Heading" HeaderText="Custom Tariff Heading"   HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"   />
                               </asp:BoundField>

                               <asp:BoundField DataField="Unit Price" HeaderText="Unit Price"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border_pa" HorizontalAlign="Right" />
                               </asp:BoundField>

                               <asp:BoundField DataField="Product Amount" HeaderText="Product Amount"   HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right"   />
                                </asp:BoundField>

                               <asp:BoundField DataField="Invoice Currency" HeaderText="Invoice Currency" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"    />
                                </asp:BoundField>

                              <asp:BoundField DataField="Product CIF Value" HeaderText="Product CIF Value"   HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right"  />
                                </asp:BoundField>

                                <asp:BoundField DataField="Total CIF" HeaderText="Total CIF" HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border_pa" HorizontalAlign="Right" />
                                </asp:BoundField>

                                <asp:BoundField DataField="PRODUCT AV" HeaderText="PRODUCT AV"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle HorizontalAlign="Right"  CssClass="column_style_left_border"    />
                                </asp:BoundField>

                                <asp:BoundField DataField="TOTAL AV" HeaderText="TOTAL AV"  HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  HorizontalAlign="Right" CssClass="column_style_left_border"  />
                                </asp:BoundField>

                                <asp:BoundField DataField="Basic Duty" HeaderText="Basic Duty"    HeaderStyle-HorizontalAlign="Center" >
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right"  />
                                </asp:BoundField>

                                <asp:BoundField DataField="PRODUCT_EDU_CESS_RATE" HeaderText="Education Cess "  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right"  />
                                </asp:BoundField>

                                <asp:BoundField DataField="PRODUCT_SEC_EDU_CESS_RATE" HeaderText="Sec.high Edu Cess Rate"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"    HorizontalAlign="Right"/>
                                </asp:BoundField>

                                <asp:BoundField DataField="Marks & Nos" HeaderText="Marks & Nos"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   CssClass="column_style_left_border"  HorizontalAlign="Left" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Basic Notn" HeaderText="Basic Notn"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Basic Notn SNo" HeaderText="Basic Notn SNo"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border" HorizontalAlign="Right"  />
                                </asp:BoundField>

                                <asp:BoundField DataField="AddlDuty Notn" HeaderText="AddlDuty Notn"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle  CssClass="column_style_left_border"   />
                                </asp:BoundField>

                                <asp:BoundField DataField="AddlDuty SNo" HeaderText="AddlDuty SNo"  HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle   CssClass="column_style_left_border" HorizontalAlign="Right"  />
                                </asp:BoundField>

                                </Columns>
                                 <PagerSettings Visible="False" />
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

      var Imp_name = $('#<%= txtimpname.ClientID %>').val();
      var Branch = $('#<%= txtbranch.ClientID %>').val();
      

      var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
      var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

      if (lastProductId != 'NO RECORD FOUND') {
          function EXcel() {
              var Type = 'excel';
              win = window.open('../FlatFile/MIS_report_1.aspx?Pl_Rpt_1=Yes&Jobdate=' + Jobdate + '&Todate=' + Todate + '&Imp_name=' + Imp_name + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf');
              Loading_HideImage();
          }

           function Mail_open() {
               var Type = 'excel';

                        var w = '700';
                        var h = '800';
                 LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                 TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                 settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                 win = window.open('../Report/Mail_Send.aspx?IMP_Pl_Rpt_1_Excel=Yes&Jobdate=' + Jobdate + '&Todate=' + Todate + '&Imp_name=' + Imp_name + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf', settings);
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
                  document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "400%";
                  document.getElementById('<%=gvdetails.ClientID %>').style.width = "500%";
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

