<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exp_MIS_Rpt2.aspx.cs" Inherits="Exp_MIS_Rpt2" 
 MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"%>
 <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
   
    <div id="innerbox_MidMain">
        <div id="mainmastop2container_rght_tag2_txt1">
            Export-MIS Report
        </div>
        <div id="tag_transact_src_inner" style="width: 805px;padding-top: 6px;">
            <div id="tag_Exchange_inner_lft">
                <div id="innerbox_transac_bot_inn">
                    <div id="tag_label_transact_Src">
                        Job No
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txtJobNo" runat="server" CssClass="txtbox_none_Mid_transac_code_new"></asp:TextBox>
                    </div>
                    
                    <div id="tag_label_transact_Src" style="padding-left:30px;">
                        Client Name
                    </div>
                    <div id="txtcon-m_src">
                        <asp:DropDownList ID="ddlCutomerName" runat="server" CssClass="txtbox_none" Width="200px"
                            Font-Names="TimesNewRomen">
                            <asp:ListItem>All</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transact_lft_in1" style="width: 700px;">
                    <div id="tag_label_transact_Src">
                        From Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txtFrom_Date" runat="server" Width="100px" CssClass="validate[required] txtbox_none_Mid_transac_code"
                            MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom_Date"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFrom_Date"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        To Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txtTo_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            Width="100px" MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtTo_Date"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo_Date"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:Label runat="server" ID="lbl_branch">Select Branch</asp:Label>
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:DropDownList ID="ddlSelect_Branch" runat="server" CssClass="listtxt_transac_src1"
                            ClientIDMode="Static">
                            <asp:ListItem>All</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" onserverclick="btnSearch_Click" runat="server"
                        tabindex="10"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                </div>
            </div>
        </div>
    </div>
         <div id="innerbox_MidMain_Grid">
          
             <div id="tag_srcinner1grid">
                 <div id="txtcon-m_transaction_code" style="margin-top: 08px;width:70px;">
                     <asp:ImageButton ID="btnprint" runat="server" ImageUrl="~/images/print.jpg" Height="28px"
                         Width="28px" OnClientClick="PrintGridData()" />
                     <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                         Width="28px" OnClientClick="EXcel()" />
                     <%--  <asp:ImageButton ID="btnpdf" runat="server"  ImageUrl="~/images/pdf.jpg" Height="28px" Width="28px" OnClientClick="Pdf()"/>--%>
                 </div>
                 <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" OnClientClick="Mail_open();"  />
               </div>
            </div>

             


             <div id="tag_srcinner1grid_table_Container">
                 <div id="Main_Grid_Container" style="overflow: hidden;" runat="server">
                     <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                         CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="500%"
                         OnRowDataBound="gvdetails_RowDataBound" OnPageIndexChanging="gvdetails_PageIndexChanging"
                         CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                         <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                             CssClass="column_style_right" BorderWidth="1px" />
                         <HeaderStyle Font-Underline="false" ForeColor="Black" />
                         <Columns>
                             <asp:BoundField DataField="JobNo" HeaderText="JobNo" HeaderStyle-Width="1%" ControlStyle-Width="1%"
                                 HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true">
                                 <ItemStyle HorizontalAlign="Left" Width="2%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="JobDate" HeaderText="Job Date" HeaderStyle-Width="2%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle Width="2%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="ExporterName" HeaderText="ExporterName" HeaderStyle-Width="10%"
                                 ControlStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" ItemStyle-Font-Bold="true">
                                 <ItemStyle CssClass="column_style_left_border" Width="6%" HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="BranchSlNo" HeaderText="BranchSlNo" HeaderStyle-Width="3%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="2%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Address1" HeaderText="Address1" HeaderStyle-Width="10%"
                                 ControlStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" HorizontalAlign="Left" Width="10%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="AdCode" HeaderText="AdCode" HeaderStyle-Width="2%" ControlStyle-Width="2%"
                                 HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="2%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="TransportMode" HeaderText="Transport Mode" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="3%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Port_Discharge" HeaderText="Port of Discharge" HeaderStyle-Width="5%"
                                 ControlStyle-Width="5%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="4%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Country_of_Discharge" HeaderText="Coun_Dischage" HeaderStyle-Width="4%"
                                 ControlStyle-Width="4%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" HorizontalAlign="Left" Width="4%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Country_Final_Dest" HeaderText="Country_Final_Dest" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="4%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="SbNo" HeaderText="SB No" HeaderStyle-Width="3%" ControlStyle-Width="3%"
                                 HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="3%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="SbDate" HeaderText="SB Date" HeaderStyle-Width="3%" ControlStyle-Width="3%"
                                 HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="3%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Term_of_Shipment" HeaderText="Term_of_Shipment" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" HorizontalAlign="Left" Width="3%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="InvoiceSlNo" HeaderText="InvoiceSlNo" HeaderStyle-Width="2%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" HorizontalAlign="Left" Width="2%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="InvoiceNo" HeaderText="InvoiceNo" HeaderStyle-Width="4%"
                                 ControlStyle-Width="4%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="4%" HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="INV_Date" HeaderText="INV_Date" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="3%" HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Invoice_Currency" HeaderText="Invoice_Currency" HeaderStyle-Width="3%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="2%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Exc_Rate" HeaderText="Exc_Rate" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" HorizontalAlign="Right" Width="3%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="InvoiceValue" HeaderText="InvoiceValue" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" HorizontalAlign="Right" Width="3%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Freight_Cherges" HeaderText="Freight_Cherges" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="3%" HorizontalAlign="Right" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Freight_Currency" HeaderText="Freight Cur" HeaderStyle-Width="2%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="2%" HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Freight_Rate" HeaderText="Freight_Rate" HeaderStyle-Width="3%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="3%" HorizontalAlign="Right" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Insurance_Charges" HeaderText="Insurance_Charges" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" HorizontalAlign="Right" Width="3%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Insurance_Currency" HeaderText="Ins Currency" HeaderStyle-Width="2%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="2%" HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Insurance_Rate" HeaderText="Insurance_Rate" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" HorizontalAlign="Right" Width="3%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Item_Sl_No" HeaderText="Item_Sl_No" HeaderStyle-Width="2%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="2%" HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Product_Description" HeaderText="Product_Description"
                                 HeaderStyle-Width="10%" ControlStyle-Width="10%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="6%" HorizontalAlign="Left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="RITC_no" HeaderText="RITC_No" HeaderStyle-Width="3%" ControlStyle-Width="3%"
                                 HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="2%" HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Quantity" HeaderText="Quantity" HeaderStyle-Width="2%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" HorizontalAlign="Left" Width="2%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="Qty_Code" HeaderText="Qty_Code" HeaderStyle-Width="2%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="2%" HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" HeaderStyle-Width="3%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" HorizontalAlign="Right" Width="2%" />
                             </asp:BoundField>
                             <asp:BoundField DataField="SchemeCode" HeaderText="SchemeCode" HeaderStyle-Width="2%"
                                 ControlStyle-Width="2%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="6%" HorizontalAlign="Center" />
                             </asp:BoundField>
                             <asp:BoundField DataField="PMV_Value" HeaderText="PMV_Value" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="3%" HorizontalAlign="left" />
                             </asp:BoundField>
                             <asp:BoundField DataField="FOB_value" HeaderText="FOB_value" HeaderStyle-Width="3%"
                                 ControlStyle-Width="3%" HeaderStyle-HorizontalAlign="Center">
                                 <ItemStyle CssClass="column_style_left_border" Width="3%" HorizontalAlign="left" />
                             </asp:BoundField>
                         </Columns>
                     </asp:GridView>
                 </div>
             </div>
                        <asp:HiddenField ID="Select_BranchCode" runat="server" />
                         <asp:HiddenField ID="Select_Ename" runat="server" />


      <script type="text/javascript">
          function PrintGridData() {
              var prtGrid = document.getElementById('<%=gvdetails.ClientID %>');
              var lastProductId = $("#<%=gvdetails.ClientID %> ").html;
              alert(lastProductId);
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

      var JobNo = $('#<%=txtJobNo.ClientID %>').val();

      var Jobdate = $('#<%= txtFrom_Date.ClientID %>').val();
      var Exp_name = $('#<%= ddlCutomerName.ClientID %>').val();

      var To_date = $('#<%= txtTo_Date.ClientID %>').val();
      var Branch = $('#<%= Select_BranchCode.ClientID %>').val();

      var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
      var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

      if (lastProductId != 'NO RECORD FOUND') {
          function EXcel() {
              var Type = 'excel';
              win = window.open('../FlatFile/MIS_report_1.aspx?Export_MIS_2=Yes&JobNo=' + JobNo + '&Jobdate=' + Jobdate + '&Exp_name=' + Exp_name + '&To_date=' + To_date + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf');
              Loading_HideImage();
          }

          function Mail_open() {
              var Type = 'excel';
              var w = '700';
              var h = '800';
              LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
              TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
              settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
              win = window.open('../Report/Mail_Send.aspx?EXP_MIS_Rpt=Yes&JobNo=' + JobNo + '&Jobdate=' + Jobdate + '&Exp_name=' + Exp_name + '&To_date=' + To_date + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf', settings);
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
                        if (lastProductId == null) {
                            //                alert('NO RECORD FOUND');
                        }

                        if (totalRows > 2) {

                            gridviewScroll();
                        }
                        else {

                            if (lastProductId > 0) {
                                gridviewScroll();
                            }
                            else {
                                document.getElementById('<%=Main_Grid_Container.ClientID %>').style.width = "100%";
                                document.getElementById('<%=Main_Grid_Container.ClientID %>').style.overflow = "Auto";
                                document.getElementById('<%=gvdetails.ClientID %>').style.width = "400%";
                                document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "200%";
                                
                            }
                        }
                    });

                    function gridviewScroll() {
                        gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

                            width: 950,
                            height: 420,
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
    
    <script type="text/javascript">
        function isValidDate(d) {
            if (Object.prototype.toString.call(d) !== "[object Date]")
                return false;
            return !isNaN(d.getTime());
        }
    </script>      
        
        </div>
</asp:Content>