
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_MIS_Rpt4.aspx.cs" Inherits="Mis_Report_Imp_MIS_Rpt4"
MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"  %>
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
   
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>

    <div id="innerbox_MidMain">
            <div id="tag_srcinner1">
         
          <div id="mainmastop2container_rght_tag2_txt1">
                 Import-MIS 4 Report
            </div>


            </div>
            <div id="tag_transact_src_inner" style="width:805px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn">
                     
                            <div id="tag_label_transact_Src">
                                Client Name
                            </div>
                            
                             <div id="txtcon-m_src">
                               
                                <asp:DropDownList ID="ddlCutomerName" runat="server" CssClass="txtbox_none" Width="200px" Font-Names="TimesNewRomen"
                                     onselectedindexchanged="ddlCutomerName_SelectedIndexChanged" 
                                    AutoPostBack="True">
                                    <asp:ListItem>All</asp:ListItem>
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
                    <div id="tag_transact_lft_in1" style="width:700px;">
                      <div id="tag_label_transact_Src">
                                From Date</div>
                                <div id="tag_label_transact_Src">
 
                                     <asp:TextBox ID="txtFrom_Date" runat="server"  Width="100px" CssClass="validate[required] txtbox_none_Mid_transac_code" 
                                MaxLength="10" TabIndex="3" ClientIDMode="Static" 
                                      ></asp:TextBox>
                           <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtFrom_Date" 
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFrom_Date"
                                 Format="dd/MM/yyyy">
                            </asp:CalendarExtender>


                            </div>
                            <%--<div id="tag_label_transaction_popup_IGM2_empty"></div> --%>                          
                            <div id="tag_label_transaction_popup_IGM2_empty"></div> 
                             <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            

                            <div id="tag_label_transact_Src">
                                To Date</div>
                           
                            <div id="tag_label_transact_Src">
                                     <asp:TextBox ID="txtTo_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new" Width="100px"
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
                            
                                          
                   </div>
                </div>
                <div id="tag_transact_srcinner_rght">
                    <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" onserverclick="btnSearch_Click" runat="server"   OnClientClick="return validate_Invoice();" 
                                             onclick="return test();"      tabindex="10">
                                </a>
                       
                    </div>
                    <div id="small-butt-rght">
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                    </div>
                </div>
            </div>
        </div>

        <div id="innerbox_MidMain_Grid">
          
            <div id="tag_srcinner1grid">
             <div id="txtcon-m_transaction_code" style="margin-top:08px; width:70px;">
              <asp:ImageButton ID="btnprint" runat="server"  ImageUrl="~/images/print.jpg" Height="28px" Width="28px"  OnClientClick="PrintGridData()"/>
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
              </div>
              
              <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" 
                    OnClientClick="Mail_open();" style="height: 26px; width: 46px"  />
               </div>
            </div>
           
                <div id="tag_srcinner1grid_table_Container" >
               
             
                          
            
                <div id="Main_Grid_Container" runat="server"  style="overflow:hidden; height:550px; "  >

                         <asp:GridView runat="server" ID="GV_Details" EmptyDataText="NO RECORD FOUND"  
                           BorderStyle="Solid" BorderWidth="1px" 
                        AutoGenerateColumns="false"  CssClass="grid-view" ShowHeader="true" OnPageIndexChanging="GV_Details_PageIndexChanging"
                        ShowHeaderWhenEmpty="true" Width="425%"   OnRowDataBound="GV_Details_RowDataBound1"  
                         CellPadding="1" CellSpacing="1" OnRowCreated="GV_Details_RowCreated" HorizontalAlign="Left" AllowSorting="true" >
                        
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" 
                            BorderWidth="1px" />
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />

                              <Columns>

                                 <asp:BoundField DataField="Jobno" HeaderText="Jobno"   HeaderStyle-Width="80px" >
                               <ItemStyle Width="80px"  />
                            </asp:BoundField>

                            <asp:BoundField DataField="CustomHouse" HeaderText="CustomHouse"   HeaderStyle-Width="100px" >
                                <ItemStyle   Width="100px" />
                            </asp:BoundField>

                             <asp:BoundField DataField="JobDate" HeaderText="JobDate"   HeaderStyle-Width="80px" >
                                <ItemStyle CssClass="column_style_left6"  Width="80px" />
                            </asp:BoundField>

                             

                             <asp:BoundField DataField="Imp_Name" HeaderText="Importer Name"   HeaderStyle-Width="350px" >
                                <ItemStyle CssClass="column_style_left6"  Width="350px" />
                            </asp:BoundField>

                             <asp:BoundField DataField="Port_Origin" HeaderText="Port Origin"   HeaderStyle-Width="200px" >
                                <ItemStyle CssClass="column_style_left6"  Width="200px" />
                            </asp:BoundField>

                             <asp:BoundField DataField="Mode" HeaderText="Mode"   HeaderStyle-Width="80px"  HeaderStyle-HorizontalAlign="Right" >
                                <ItemStyle CssClass="column_style_left_border"  Width="80px" HorizontalAlign="Center" />
                            </asp:BoundField>

                             <asp:BoundField DataField="BE_No" HeaderText="BE No"   HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" >
                                <ItemStyle CssClass="column_style_left6"  Width="80px" HorizontalAlign="Right" />
                            </asp:BoundField>

                            <asp:BoundField DataField="BE_DATE" HeaderText="BE Date"   HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Right" >
                                <ItemStyle CssClass="column_style_left6"  Width="80px" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="IGM_MAWB" HeaderText="IGM MAWB"   HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Center">
                                <ItemStyle CssClass="column_style_left_border"  Width="150px" HorizontalAlign="Center" />
                            </asp:BoundField>

                             <asp:BoundField DataField="IGM_HAWB" HeaderText="IGM HAWB"   HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="100px" HorizontalAlign="Center"/>
                            </asp:BoundField>

                               <asp:BoundField DataField="IGM_NOOFPACKAGE" HeaderText="Total Pkgs"   HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Right"  >
                                <ItemStyle CssClass="column_style_left_border"  Width="80px" HorizontalAlign="Right" />
                            </asp:BoundField>

                            <asp:BoundField DataField="IGMWeight" HeaderText="Gross Weight"   HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Right" >
                                <ItemStyle CssClass="column_style_left_border"  Width="100px" HorizontalAlign="Right" />
                            </asp:BoundField>

                             <asp:BoundField DataField="ContainerNo" HeaderText="Container No"   HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="150px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="ContainerType" HeaderText="Type"   HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="50px" HorizontalAlign="Center"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="Invoice_no" HeaderText="Invoice No"   HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="150px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="InvoiceDate" HeaderText="Invoice Date"   HeaderStyle-Width="80px"  HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="80px" HorizontalAlign="Center"/>
                            </asp:BoundField>

                            <asp:BoundField DataField="tot_InvoiceValue" HeaderText="Tot InvoiceValue"   HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="150px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="Inv_In_Cur" HeaderText="Inv In Currency"   HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="150px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="Inv_Exc" HeaderText="ExRate"   HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="80px" HorizontalAlign="Center"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="Tot_Freight" HeaderText="Tot Freight"   HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="100px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="Tot_Insurance" HeaderText="Tot Insurance"   HeaderStyle-Width="100px" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="100px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                            <asp:BoundField DataField="Total_Assasable_Value" HeaderText="Assasable Value"   HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Right" >
                                <ItemStyle CssClass="column_style_left_border"  Width="150px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="Total_ActualValue" HeaderText="Actual_Assbl Value"   HeaderStyle-Width="150px" HeaderStyle-HorizontalAlign="Right">
                                <ItemStyle CssClass="column_style_left_border"  Width="150px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="Total_Basic_Value" HeaderText="Basic Value"   HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left_border"  Width="150px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="Total_CVD_Value" HeaderText="CVD Value"   HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left_border"  Width="150px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                            <asp:BoundField DataField="Total_CEC_Value" HeaderText="CEC Value"   HeaderStyle-Width="100px" >
                                <ItemStyle CssClass="column_style_left_border"  Width="100px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="Total_ADD_DUTY_Value" HeaderText="SAD DUTY"   HeaderStyle-Width="100px" >
                                <ItemStyle CssClass="column_style_left_border"  Width="100px" HorizontalAlign="Right"/>
                            </asp:BoundField>

                            <asp:BoundField DataField="Total_DUTY_Value" HeaderText="DUTY Value"   HeaderStyle-Width="150px" >
                                <ItemStyle CssClass="column_style_left_border"  Width="150px" HorizontalAlign="Right" />
                            </asp:BoundField>

                                </Columns>
                        </asp:GridView>

  
                </div>
                    <asp:HiddenField ID="HiddenField1_JobType" runat="server" />
                    <asp:HiddenField ID="HiddenField1_BRANCH" runat="server" />

            </div>
        </div>

 <script type="text/javascript">
     function PrintGridData() {
         var prtGrid = document.getElementById('<%=GV_Details.ClientID %>');
         var lastProductId = $("#<%=GV_Details.ClientID %> ").html;
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
      var ClientName = $('#<%= ddlCutomerName.ClientID %>').val();
      var Tr_mode = $('#<%= ddlTransportMode.ClientID %>').val();
      var Branch = $('#<%= HiddenField1_BRANCH.ClientID %>').val();

      var Job_type = $('#<%= HiddenField1_JobType.ClientID %>').val();
      var To_date = $('#<%= txtTo_Date.ClientID %>').val();

      var totalRows = $("#<%=GV_Details.ClientID %> tr").length;
      var lastProductId = $("#<%=GV_Details.ClientID %> tr:last").children("td:first").html();


      if (lastProductId != 'NO RECORD FOUND') {
          function EXcel() {
              var Type = 'excel';
              win = window.open('../FlatFile/MIS_report_1.aspx?ExpeditorsRpt=Yes&Fromdate=' + Fromdate + '&ClientName=' + ClientName + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Job_type=' + Job_type + '&To_date=' + To_date + '&Type=' + Type + '', 'ndf');
              Loading_HideImage();                                  
          }
          function Mail_open() {
              var Type = 'excel';
              var w = '700';
              var h = '800';
              LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
              TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
              settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
              win = window.open('../Report/Mail_Send.aspx?IMP_MIS_Rpt_4=Yes&Fromdate=' + Fromdate + '&ClientName=' + ClientName + '&Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Job_type=' + Job_type + '&To_date=' + To_date + '&Type=' + Type + '', 'ndf', settings);
              win.focus();
              return false;
          }
         
      }

  </script>

    

    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

            var totalRows = $("#<%=GV_Details.ClientID %> tr").length;
            var lastProductId = $("#<%=GV_Details.ClientID %> tr:last").children("td:first").html();
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
                    /*alert (lastProductId);*/
                    document.getElementById('<%=Main_Grid_Container.ClientID %>').style.height = "59px";
                    document.getElementById('<%=Main_Grid_Container.ClientID %>').style.width = "100%";
                    document.getElementById('<%=Main_Grid_Container.ClientID %>').style.overflow = "Auto";
                    document.getElementById('<%=GV_Details.ClientID %>').style.width = "400%";
                    document.getElementById('<%=GV_Details.ClientID %>').style.overflow = "200%";
                }
            }
        });

        function gridviewScroll() {
            gridView1 = $('#<%=GV_Details.ClientID %>').gridviewScroll({

                width: 950,
                height: 416,
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