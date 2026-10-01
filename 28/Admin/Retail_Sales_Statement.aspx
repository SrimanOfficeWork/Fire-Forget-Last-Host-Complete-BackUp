<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Retail_Sales_Statement.aspx.cs" Inherits="Import_Retail_Sales_Statement_Retail_Sales_Statement"
MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"  %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   

    <div id="innerbox_MidMain">
            <div id="tag_srcinner1">
          Retail Sales Statement
            </div>
            <div id="tag_transact_src_inner" style="width:805px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn">
                     
                            <div id="tag_label_transact_Src">
                                Client Name
                            </div>
                            
                           
                            <div id="tag_label_transact_Src">

                                    <asp:DropDownList ID="ddlCutomerName" runat="server"  Width="150px" CssClass="listtxt_transac_src1"
                                        onselectedindexchanged="ddlCutomerName_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>

                                
                         
         </div>
         <div id="tag_label_transact_Src">
                               
                            </div>

              <div id="tag_label_transaction_popup_IGM2_empty">
                        
                            </div>
                   <div id="tag_label_transact_Src">
                              Job Type
                            </div>
                            <div id="tag_label_transact_Src">
         <asp:DropDownList ID="ddlSelect_JobType" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static">  
         <asp:ListItem>Import</asp:ListItem>    
         <asp:ListItem>Export</asp:ListItem>
       <%--  <asp:ListItem>Both</asp:ListItem>--%>
        </asp:DropDownList>
        </div>

         <div id="tag_label_transaction_Src_longlabel">
                            Transport Mode</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="listtxt_transac_mode_new"
                                TabIndex="5">
                                 <asp:ListItem>All</asp:ListItem>
                                 <asp:ListItem>Air</asp:ListItem>
                                <asp:ListItem>Sea</asp:ListItem>
                                <asp:ListItem>Land</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        
                    </div>
                    <div id="tag_transact_lft_in1" style="width:605px;">
                      <div id="tag_label_transact_Src">
                                From Date</div>
                                <div id="tag_label_transact_Src">
                                
                          
                                     <asp:TextBox ID="txtFrom_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                           <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFrom_Date"
                                 Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                To Date</div>
                           
                            <div id="tag_label_transact_Src">
                                
                          
                                     <asp:TextBox ID="txtTo_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                           <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtTo_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo_Date"
                                 Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                            </div>
                            
                       <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                Select Branch
                            </div>
                            
                            <div id="tag_label_transact_Src">
                                
                           <asp:DropDownList ID="ddlSelect_Branch" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static">      
                           <asp:ListItem>All</asp:ListItem>
        </asp:DropDownList>
                            </div>
                       
                      
                   </div>
                </div>
                <div id="tag_transact_srcinner_rght">
                    <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" onserverclick="btnSearch_Click" runat="server"   
                                                   tabindex="10">
                                </a>
                        <%--<a href="#" class="srcbu" id="btnSearch" runat="server"  OnClientClick="open_jobno2(); onclick="return validdate();">
                        </a>--%>
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                    </div>
                </div>
            </div>
        </div>

        <div id="innerbox_MidMain_Grid">
          
            <div id="tag_srcinner1grid">
             <div id="txtcon-m_transaction_code" style="margin-top:08px;">
              <asp:ImageButton ID="btnprint" runat="server"  ImageUrl="~/images/print.jpg" Height="28px" Width="28px"  OnClientClick="PrintGridData()"/>
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
              <asp:ImageButton ID="btnpdf" runat="server"  ImageUrl="~/images/pdf.jpg" Height="28px" Width="28px" OnClientClick="Pdf()"/>
              
             
              </div>
              
          <div id="tag_label_transact_Src">
              <asp:ImageButton ID="btnMail" runat="server"  
                  ImageUrl="~/images/mail.JPG" Height="31px" Width="29px"  
                  OnClientClick="Mail_open();"/>
                               
                            </div>
                             <div id="tag_label_transact_Src"> 
                              <%--<asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server"   OnClick="SendMail_Click" />--%>
             
                               <%--<asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server"  
           OnClientClick="Mail_open();"    />--%>
           
                                  </div>
                               <div id="tag_label_transact_Src"> </div>
                               <div id="tag_label_transact_Src"> </div>
                               <div id="tag_label_transact_Src">  </div>
                       <%--    <asp:Literal ID="lblClnt_Name" runat="server" Text="Total Jobs
                "></asp:Literal>--%>
                <asp:Label ID="lbltotaltext" runat="server" Text="Total Jobs"   Width="100px" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Font-Bold="true" BorderStyle="None" ></asp:Label>
                <%--<asp:Label ID="lblClnt_Name" runat="server" Text="Total Jobs"   Width="100px" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Font-Bold="true" BorderStyle="None" ></asp:Label>--%>
           <asp:Label ID="lblClient_Name" runat="server"  Width="50px" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Font-Bold="true"  BorderStyle="None"></asp:Label>
                
            </div>
           
                <div id="tag_srcinner1grid_table_Container" >
               
             
                          
            
                <div id="Main_Grid_Container" style="overflow:hidden; height:545px;">
                     
                        <asp:GridView ID="GridViewImport" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                CssClass="grid-view" AllowPaging="True"  OnPageIndexChanging="GridViewImport_PageIndexChanging"
                                HorizontalAlign="Left" onrowdatabound="GridViewImport_RowDataBound1" 
                                PageSize="50"  AllowSorting="True" BorderColor="#C8C8C8" 
                                ShowHeaderWhenEmpty="true" Width="120%" BorderStyle="Solid" BorderWidth="1px"  
                                CellPadding="1" CellSpacing="1" OnRowCreated="GridViewImport_RowCreated">

                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" 
                                    BorderWidth="1px" />

                                    
      
        <Columns>
  
  <asp:TemplateField    HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
        <ItemTemplate>
        <asp:Label ID="Label111" runat="server" Text='<%#Container.DataItemIndex+1 %>'>></asp:Label>

          </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField   HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("JOBNO") %>'></asp:Label>

          </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField   HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("JOBDATE") %>'></asp:Label>

          </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField   HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TRANSPORT_MODE") %>'></asp:Label>

          </ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField   HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("BRANCHCODE") %>'></asp:Label>

          </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField   HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("IMPORTER_NAME") %>'></asp:Label>

          </ItemTemplate>
        </asp:TemplateField>

            <asp:TemplateField   HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("SUPPLIER_NAME") %>'></asp:Label>

          </ItemTemplate>
        </asp:TemplateField>

            <asp:TemplateField   HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("INVOICE_NO") %>'></asp:Label>

          </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField   HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
        <ItemTemplate>
        <asp:Label ID="Label1" runat="server" Text='<%# Eval("INVOICE_DATE") %>'></asp:Label>

          </ItemTemplate>
        </asp:TemplateField>

        </Columns>
       <%-- <EmptyDataRowStyle Width = "450px"

   HorizontalAlign = "Center" BackColor = "#C2D69B"  />--%>
        </asp:GridView>
  
                </div>
            </div>
        </div>

 <script type="text/javascript">
     function PrintGridData() {
         var prtGrid = document.getElementById('<%=GridViewImport.ClientID %>');
         var lastProductId = $("#<%=GridViewImport.ClientID %> ").html;
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

      var Fromdate = $('#<%= txtFrom_Date.ClientID %>').val();
      var Imp_name = $('#<%= ddlCutomerName.ClientID %>').val();
      var Tr_mode = $('#<%= ddlTransportMode.ClientID %>').val();
      var Branch = $('#<%= ddlSelect_Branch.ClientID %>').val();

      var Job_type = $('#<%= ddlSelect_JobType.ClientID %>').val();
      var To_date = $('#<%= txtTo_Date.ClientID %>').val();



      var totalRows = $("#<%=GridViewImport.ClientID %> tr").length;
      var lastProductId = $("#<%=GridViewImport.ClientID %> tr:last").children("td:first").html();

      
      if (lastProductId != 'NO RECORD FOUND') {
          function EXcel() {
              var Type = 'excel';
              win = window.open('../FlatFile/Open_FileDownload.aspx?Retail_St=Yes&Fromdate=' + Fromdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Job_type=' + Job_type + '&To_date=' + To_date + '&Type=' + Type + '', 'ndf');
              Loading_HideImage();
              
          }

          function Pdf() {


              var Type = 'Pdf';
              win = window.open('../FlatFile/Open_FileDownload.aspx?Retail_St=Yes&Fromdate=' + Fromdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Job_type=' + Job_type + '&To_date=' + To_date + '&Type=' + Type + '', 'ndf'); 
              Loading_HideImage();
          }


         
      }

  </script>


         
          

    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

            var totalRows = $("#<%=GridViewImport.ClientID %> tr").length;
            var lastProductId = $("#<%=GridViewImport.ClientID %> tr:last").children("td:first").html();

            if (totalRows > 2) {

                gridviewScroll();
            }
            else {

                if (lastProductId > 0) {
                    gridviewScroll();
                }
                else {
                    /*alert (lastProductId);*/
                }
            }
        });

        function gridviewScroll() {
            gridView1 = $('#<%=GridViewImport.ClientID %>').gridviewScroll({

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

    <script>
        
         var win = null;

         function Mail_open() {
             var w = '700';
             var h = '800';
             LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
             TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
             settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
             win = window.open('../Report/Mail_Send.aspx', 'ndf', settings);
             win.focus();

             return false;
             //window.open('../Default.aspx', 'ndf')

         }
    </script>
    
     
    
       </div>
</asp:Content>
