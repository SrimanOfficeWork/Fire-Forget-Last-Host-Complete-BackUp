<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Job_Clearance_History_Search.aspx.cs" 
Inherits="Job_Clearance_History_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css" media="print">
        @page
        {
            size: auto; /* auto is the initial value */
            margin: 0mm; /* this affects the margin in the printer settings */
        }
        
        @media print
        {
            /*****   Styles for print   ******/
            h1, h2, h3
            {
                color: black;
            }
            #navigation
            {
                display: none;
            }
        }
        
        @media screen
        {
            /*****   Styles for screen  ******/
        }
    </style>
    <style type="text/css">
        .ad
        {
            width: 50px;
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

 
<div id="innerbox_MidMain"  >


            <div id="tag_srcinner1" >

<div id="tag_srcinner1"  >
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_paramount_job_clearance_HistoryNew('New'); return false" />
                 </div>

                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   Export Job Clearance
                    </div>
                   <div id="verslic"> </div>

            </div>
           <%-- --------------------------------------------Start---------------------------%>

                <div id="tag_transact_src_inner" style="width: 935px;">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 900px;">
                            <div id="tag_label_transact_Src">
                                Shipper Name
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 200px;">
                                <asp:DropDownList ID="ddlExp_name" runat="server" CssClass="txtbox_none"  AutoPostBack="true"
                                    Width="200px" onselectedindexchanged="ddlExp_name_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 110px;">
                                Ref Name
                            </div>
                            <div id="txtcon-m_src">
                                <asp:DropDownList ID="ddlreportname" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    Width="220px" onselectedindexchanged="ddlreportname_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 70px;" >
                               Job No
                            </div>

                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtjobno" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen"  MaxLength="80" ></asp:TextBox>
                            </div>
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 605px;">
                            <div id="tag_label_transact_Src">
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
                            <div id="tag_label_transact_Src">
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
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                             <div  id="tag_label_transaction_popup_no_empty">
                        </div>
                             <div id="tag_label_transaction_Src_longlabel">
                            Month</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="100px" TabIndex="5" >
                            </asp:DropDownList>
                        </div>
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

    <div id="innerbox_MidMain_Grid" style="height: 580px;">
        <div id="tag_srcinner1grid">
               <div id="txtcon-m_transaction_code" style="margin-top: 10px; width:125px;"">
                 <asp:Button ID="btnSingle" runat="server" Text="Single Job Base" OnClientClick="Single_Job_XL(); return false;" />
                </div>
                   <div id="txtcon-m_transaction_code" style="margin-top: 10px;">
                <asp:Button ID="Button2" runat="server" Text="All Jobs" OnClientClick="Bulk_Job_XL(); return false;" />
                </div>
        </div>
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow: hidden;"> <%-- style="overflow: hidden;"  style="overflow:hidden;"--%> 

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                    DataKeyNames="SL_NO" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated" >
                    
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black"  />
                    
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" Width="40px"  />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ShipperName" HeaderText="Shipper Name"  HeaderStyle-Width="281px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="281px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Ref_Id" HeaderText="Ref. Id"  HeaderStyle-Width="70px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="70px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Ref_name" HeaderText="Ref. Name"  HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Jobno" HeaderText="Job No"  HeaderStyle-Width="281px">
                            <ItemStyle CssClass="column_style_left5" Font-Size="12px" HorizontalAlign="left" Width="281px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Consigneename" HeaderText="Consignee Name"  HeaderStyle-Width="320px">
                            <ItemStyle CssClass="column_style_left5" Font-Size="12px" HorizontalAlign="left" Width="320px" />
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
       
    </style>
    <asp:HiddenField ID="hd_Jobno" runat="server"  />
    <asp:HiddenField ID="HDBranch" runat="server" />

    <script type="text/javascript">
        function Get_Row_ID(val) {
              document.getElementById("<%=hd_Jobno.ClientID %>").value = val;
          }
          var Branch = $("#<%=HDBranch.ClientID %>").val();

          function Single_Job_XL() {
              var jobno = $("#<%=hd_Jobno.ClientID %>").val();
              if (jobno != '') {
                  var Type = 'Single_excel';
                  win = window.open('../FlatFile/MIS_report_1.aspx?EXP_Single_Job_Clearance=Yes&Jobno=' + jobno + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf');
                  Loading_HideImage();
              }
              else {
                  jAlert('Select a Grid Job', 'Job Clearance', function (r) { document.getElementById("ddljobno").focus(); });
              }
          }

          function Bulk_Job_XL() {

              var Exp_name = $('#<%= ddlExp_name.ClientID %>').val();
              var Rpt_name = $('#<%= ddlreportname.ClientID %>').val();
              var txtjobno = $("#<%=txtjobno.ClientID %>").val();
              var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
              var Todate = $('#<%= txttodate.ClientID %>').val();
              var Month = $('#<%= ddlmonth.ClientID %>').val();
              var Branch = $('#<%= HDBranch.ClientID %>').val();

              var prtGrid = document.getElementById('<%=gvdetails.ClientID %>');
              var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
              if (lastProductId != 'NO RECORD FOUND') {
                  var Type = 'Grid_excel';
                  win = window.open('../FlatFile/MIS_report_1.aspx?EXP_Grid_Job_Clearance=Yes&Exp_name=' + Exp_name + '&Rpt_name=' + Rpt_name + '&txtjobno=' + txtjobno + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf');
                  Loading_HideImage();
              }
          }

     </script>

  <%--<script type="text/javascript">
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
</script>--%>

  
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

              width: 980,
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

</asp:Content>

