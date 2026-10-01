<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Import_Summary_Two.aspx.cs" Inherits="Import_Summary_Two" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="innerbox_MidMain" style=" height:108px; overflow:hidden;">
            <div id="tag_srcinner1"  style=" height:40px;">
              <div id="mainmastop2container_rght_tag2_txt1" style="width:200px;">
                     
                     Import Summary Two
                    
                     </div>
                     <div id="verslic">
                     </div>
                      <div id="mainmastop2container_rght_tag2_txt1" style="width:70px;">
                      Category:
                      </div>

                    <div id="mainmastop2container_rght_tag2_txt1" style="width:420px; margin-top:5px;">
                    
                           <asp:DropDownList ID="ddlrptype" runat="server"  AutoPostBack="true"
                               CssClass="listtxt_transac_mode_new"  Width="115px" TabIndex="1" 
                               onselectedindexchanged="ddlrptype_SelectedIndexChanged">
                              <asp:ListItem Text="Importer Name" Value="Imp_Name"> </asp:ListItem>
                              <asp:ListItem Text="Port" Value="Port"> </asp:ListItem>
                              <asp:ListItem Text="Country" Value="Country"> </asp:ListItem>
                              <asp:ListItem Text="Monthly" Value="Monthly"> </asp:ListItem>
                              <asp:ListItem Text="Quarterly" Value="Quarterly"> </asp:ListItem>
                           </asp:DropDownList>

                    </div>
            </div>
            <div id="tag_transact_src_inner" style="width:805px;">
               <div id="tag_transaction_inner_new" style="margin-left:20px;height: 22px;">

                     <%-- -- Row-1  ----%>

                   <div id="tag_Exchange_lft_in1_new1">
                       <div id="tag_label_transaction_Src_new">
                           From Date
                       </div>
                       <div id="txtcon-m_transaction_code" >


                           <asp:TextBox ID="txtfromdate"  runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                          
                               MaxLength="10" TabIndex="2"></asp:TextBox>


                           <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                               Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                               MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                           </cc1:MaskedEditExtender>
                           <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                               PopupButtonID="txtfromdate" Format="dd/MM/yyyy">
                           </cc1:CalendarExtender>

                       </div>
                       <div id="tag_label_transaction_popup_IGM2_empty">
                       </div>
                       <div id="tag_label_transaction_Src_new">
                           To Date
                       </div>
                       <div id="txtcon-m_transaction_code">
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
                       <div id="tag_label_transaction_Src_new">
                           Mode
                       </div>
                       <div id="txtcon-m_transaction_code">
                           <asp:DropDownList ID="ddltr_mode" runat="server" CssClass="listtxt_transac_mode_new" AutoPostBack="true"
                               TabIndex="4" onselectedindexchanged="ddltr_mode_SelectedIndexChanged">
                             
                           
                           </asp:DropDownList>
                       </div>
                       <%----------------------Search 1-------------------------------%>
                       <div id="EXP_Name" runat="server">
                           <div id="tag_label_transaction_date">
                               Importer Name
                           </div>
                           <div id="txtcon-m_transaction_pop_gen1_srcic_new" style=" width:290px;">
                               <asp:DropDownList ID="ddlExp_name" runat="server" CssClass="txtbox_none"  Font-Size="12px"
                                   Width="280px" AutoPostBack="True" 
                                   onselectedindexchanged="ddlExp_name_SelectedIndexChanged">
                               </asp:DropDownList>
                           </div>
                       </div>
                       <%----------------------Search 2-------------------------------%>
                       <div id="Country" runat="server">
                           <div id="tag_label_transaction_date">
                               Country
                           </div>
                           <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                               <asp:DropDownList ID="ddlcountry" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                   Width="200px" AutoPostBack="True" 
                                   onselectedindexchanged="ddlcountry_SelectedIndexChanged">
                               </asp:DropDownList>
                           </div>
                       </div>
                      <%-- --------------------Search 3-------------------------------%>
                       <div id="Port" runat="server">
                           <div id="tag_label_transaction_date">
                               Port
                           </div>
                           <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                               <asp:DropDownList ID="ddlport" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                   Width="200px" AutoPostBack="True" 
                                   onselectedindexchanged="ddlport_SelectedIndexChanged">
                               </asp:DropDownList>
                           </div>
                       </div>
                       <%----------------------Search 4-------------------------------%>
                       <div id="Monthly" runat="server">
                           <div id="tag_label_transaction_date">
                               Month
                           </div>
                           <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                               <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                   Width="140px" AutoPostBack="True" 
                                   onselectedindexchanged="ddlmonth_SelectedIndexChanged">
                               </asp:DropDownList>
                           </div>
                       </div>
                      <%-- --------------------Search 5-------------------------------%>
                       <div id="Quaterly" runat="server">
                           <div id="tag_label_transaction_date" style="width:60px;">
                               Quarter
                           </div>
                           <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                               <asp:DropDownList ID="ddlquarter" runat="server" CssClass="txtbox_none" 
                                   Width="310px" AutoPostBack="True" 
                                   onselectedindexchanged="ddlquarter_SelectedIndexChanged">
                               </asp:DropDownList>
                           </div>
                       </div>
                       <%----------------------Search 6-------------------------------%>
                       <div id="tag_label_transaction_popup_no_empty">
                       </div>
                   </div>


                     <%----  ROW-4----%>
               
                        
                    </div>

                    <div id="tag_label_transaction_popup_mode_empty" style="padding-left:300px;">
                    </div>
                  <div id="tag_label_transaction_Src_longlabel" style="padding-top:10px;" >
                                           <div id="small-butt-left" >
                                <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                                   tabindex="10"> 
                                </a> 
                              </div>
                            </div>
                        <div id="txtcon-m_transaction_mode" style="padding-top:10px;" >
                        <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="11"></a>
                        </div>
                    
                </div> 
                
                
            </div>
            <div id="innerbox_MidMain_Grid" >
            <div id="tag_srcinner1grid">
        
                     <div id="txtcon-m_transaction_code" style="margin-top:08px;">
              <asp:ImageButton ID="btnprint" runat="server"  ImageUrl="~/images/print.jpg" Height="28px" Width="28px" OnClientClick="PrintGridData()"/>
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
              <asp:ImageButton ID="btnpdf" runat="server"  ImageUrl="~/images/pdf.jpg" Height="28px" Width="28px" OnClientClick="Pdf()"/>
              </div>

              <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="Mail_open();"  />
               </div>
          

            </div>
           
                <div id="tag_srcinner1grid_table_Container" style="width:800px;" >
            
                 <div id="Main_Grid_Container" style="overflow:hidden; width:1024px; height:531px;" >
                 
               <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND"  
                        AutoGenerateColumns="True" Width="100%" CssClass="grid-view" ShowHeader="true" 
                        ShowHeaderWhenEmpty="true"  OnRowDataBound="gvdetails_RowDataBound" 
                       BorderStyle="Groove"  GridLines="None"
                        BorderWidth="1px" 
                         CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" >


                        <AlternatingRowStyle BackColor="White"  BorderColor="Black"
                            BorderWidth="1px" /> 
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />

                        </asp:GridView> 
                </div> 
            </div>
        </div>
    <asp:HiddenField ID="Hd_Branch" runat="server" />
    <asp:HiddenField ID="Hd_Working_start" runat="server" />
    <asp:HiddenField ID="Hd_Working_End" runat="server" />

    <asp:HiddenField ID="Hd_Q_Start" runat="server" />
    <asp:HiddenField ID="Hd_Q_End" runat="server" />

    <asp:HiddenField ID="Hd_Select_Item" runat="server" />

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
                     /*alert (lastProductId);*/
                 }
             }
         });

         function gridviewScroll() {
             gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

                 width: 1024,
                 height: 531,
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
        <%--</div>--%>

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
     var TheMonth_Text = '';
     var TheQuarter_Text = '';

     var Category = $('#<%= ddlrptype.ClientID %>').val();
     var Fromdate = $('#<%= txtfromdate.ClientID %>').val();

     var Todate = $('#<%= txttodate.ClientID %>').val();
     var Tr_Mode = $('#<%= ddltr_mode.ClientID %>').val();
     var Exporter_name = $('#<%= ddlExp_name.ClientID %>').val();
     var Port = $('#<%= ddlport.ClientID %>').val();
     var Country = $('#<%= ddlcountry.ClientID %>').val();

     var TheMonth_Value = $('#<%= ddlmonth.ClientID %>').val();

     var TheQuarter_Start = $('#<%= Hd_Q_Start.ClientID %>').val();
     var TheQuarter_End = $('#<%= Hd_Q_End.ClientID %>').val();

     var W_Start_month = $('#<%= Hd_Working_start.ClientID %>').val();
     var W_End_month = $('#<%= Hd_Working_End.ClientID %>').val();


     var Branch = $('#<%= Hd_Branch.ClientID %>').val();

     if (Category == 'Monthly') {
         var TheMonth = document.getElementById("<%=ddlmonth.ClientID%>");
         TheMonth_Text = TheMonth.options[TheMonth.selectedIndex].text;
     }
     else {
         TheMonth_Text = '';
     }

     if (Category == 'Quarterly') {
         var TheQuarter = document.getElementById("<%=ddlquarter.ClientID%>");
         TheQuarter_Text = TheQuarter.options[TheQuarter.selectedIndex].text;
     }
     else {
         TheQuarter_Text = '';
     }


     var SelectItem = $('#<%= Hd_Select_Item.ClientID %>').val()

     var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
     var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

     if (lastProductId != 'NO RECORD FOUND') {

         function EXcel() {
             var Type = 'excel';
             win = window.open('../FlatFile/MIS_report_1.aspx?Imp_Summary_Two=Yes&Category=' + Category + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Tr_Mode=' + Tr_Mode + '&Select_Item=' + SelectItem + ' &TheQuarter_Start=' + TheQuarter_Start + ' &TheQuarter_End=' + TheQuarter_End + '  &W_Start_month=' + W_Start_month + ' &W_End_month=' + W_End_month + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf');
             Loading_HideImage();
         }

         function Pdf() {
             var Type = 'Pdf';
             win = window.open('../FlatFile/MIS_report_1.aspx?Imp_Summary_Two=Yes&Category=' + Category + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Tr_Mode=' + Tr_Mode + '&Select_Item=' + SelectItem + ' &TheQuarter_Start=' + TheQuarter_Start + ' &TheQuarter_End=' + TheQuarter_End + '  &W_Start_month=' + W_Start_month + ' &W_End_month=' + W_End_month + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf');
             Loading_HideImage();
         }

         function Mail_open() {
             var Type = 'Pdf';
             var w = '700';
             var h = '800';
             LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
             TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
             settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
             win = window.open('../Report/Mail_Send.aspx?Imp_Summary_Two=Yes&Category=' + Category + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Tr_Mode=' + Tr_Mode + '&Select_Item=' + SelectItem + ' &TheQuarter_Start=' + TheQuarter_Start + ' &TheQuarter_End=' + TheQuarter_End + '  &W_Start_month=' + W_Start_month + ' &W_End_month=' + W_End_month + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf', settings);
             win.focus();

             return false;
         }

     }

  </script>

</asp:Content>

