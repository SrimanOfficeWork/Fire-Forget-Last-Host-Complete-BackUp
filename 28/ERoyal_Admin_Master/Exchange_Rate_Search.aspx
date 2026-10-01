<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Exchange_Rate_Search.aspx.cs" 
Inherits="Exchange_Rate_Search" %>
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

 
<div id="innerbox_MidMain"  >


            <div id="tag_srcinner1" ">
             <%--<div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="openGeneral_Search_New('New'); return false" /></div>

                <div id="verslic">
                </div>
                      <div id="mainmastop2container_rght_tag2_txt1">                     
                          Export Consolidated Bl Generation
                             </div>--%>

<div id="tag_srcinner1"  >
               

                
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   Exchange Rate Search
                                       
                    </div>
                   <div id="verslic"> </div>

            </div>
           <%-- --------------------------------------------Start---------------------------%>

                <div id="tag_transact_src_inner" style="width: 935px;">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 900px; height:30px;">
                            <div id="tag_label_transact_Src">
                                Effective From
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 255px;">
                                <asp:DropDownList ID="ddlEffect_From" runat="server" CssClass="txtbox_none"  AutoPostBack="true" Font-Size="Small" 
                                    Width="250px" onselectedindexchanged="ddlEffect_From_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <%--<div id="tag_label_transact_Src" style="width: 110px;">
                                BL Ref Name
                            </div>
                            <div id="txtcon-m_src">
                                <asp:DropDownList ID="ddlreportname" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    Width="220px" onselectedindexchanged="ddlreportname_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>--%>
                            <div id="tag_label_transact_Src" style="width:70px;" >
                               Currency
                            </div>

                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtCurrency" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" ></asp:TextBox>
                            </div>
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 805px;">
                            <div id="tag_label_transact_Src" style="width:92px">
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
                            <div id="tag_label_transact_Src" style="width:55px">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code" >
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
                             <div id="tag_label_transact_Src" style="width:45px">
                               Month
                            </div>
                               <div id="tag_label_transact_Src" style="width:110px;">
                                <asp:DropDownList ID="ddl_Month" runat="server" CssClass="listtxt_transac_item_gen_notn"  AutoPostBack="true" Font-Size="Small"
                                 Width="105px" >
                                </asp:DropDownList>
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                             <div id="tag_label_transact_Src" style="width:45px">
                               Year
                            </div>
                               <div id="tag_label_transact_Src" style="width:110px;">
                                <asp:DropDownList ID="ddl_Year" runat="server" CssClass="listtxt_transac_item_gen_notn"  AutoPostBack="true" Font-Size="Small"
                                 Width="105px" >
                                </asp:DropDownList>
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty"></div>

                        
                            <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();" onserverclick="btnSearch_Click"
                                tabindex="5"></a>
                            </div>

                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                        </div>
                         
                        </div>

                </div>
                 </div>
           <%-- --------------------------------------------End---------------------------%>

            </div>
        </div>
       

    <div id="innerbox_MidMain_Grid" style="height: 580px;">
        <div id="tag_srcinner1grid" style="margin-top:5px";>
            <%--<div id="txtcon-m_transaction_code" style="margin-top: 08px; width: 70px;">
                <asp:ImageButton ID="btnprint" runat="server" ImageUrl="~/images/print.jpg" Height="28px"
                    Width="28px" OnClientClick="PrintGridData()" />
                <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                    Width="28px" OnClientClick="PL_EXcel()" />
            </div>--%>
          <%--  <div id="txtcon-m_transaction_code" style="margin-top: 10px; width: 350px;">
                <asp:Button ID="btnSend" CssClass="send_btn" Text="Send" runat="server" OnClientClick="Mail_open();" /></div>--%>
                 <asp:ImageButton ID="btnprint" runat="server"  ImageUrl="~/images/print.jpg" Height="28px" Width="28px" OnClientClick="PrintGridData()"/>
                <asp:ImageButton ID="btnpdf" runat="server"  ImageUrl="~/images/pdf.jpg" Height="28px" Width="28px" OnClientClick="Pdf()"/>
        </div>
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                     CellPadding="1" 
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="40px"  />
                        </asp:TemplateField>

                        <asp:BoundField DataField="Effect_Dt" HeaderText="Effect. From"  HeaderStyle-Width="101px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="101px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Notn_No" HeaderText="Notn No"  HeaderStyle-Width="71px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="71px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Currency" HeaderText="Curr.Code"  HeaderStyle-Width="71px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="71px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="Curr_Name" HeaderText="Exchange Name"  HeaderStyle-Width="110px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="110px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Per_Unit" HeaderText="Per Unit"  HeaderStyle-Width="51px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="51px"/>
                        </asp:BoundField>

                         <asp:BoundField DataField="Export" HeaderText="Export ExRate"  HeaderStyle-Width="81px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="81px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="Import" HeaderText="Import ExRate"  HeaderStyle-Width="81px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="81px"/>
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

      var ddlEffect_From = $('#<%= ddlEffect_From.ClientID %>').val();
      var txtCurrency = $('#<%= txtCurrency.ClientID %>').val();
      var txtfromdate = $('#<%= txtfromdate.ClientID %>').val();
      var txttodate = $('#<%= txttodate.ClientID %>').val();
      var ddl_Month = $('#<%= ddl_Month.ClientID %>').val();
      var ddl_Year = $('#<%= ddl_Year.ClientID %>').val();

      var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
      var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

      if (lastProductId != null) {

          if (lastProductId != 'NO RECORD FOUND') {
              function Pdf() {

                  win = window.open('../FlatFile/MIS_report_1.aspx?Exchange=Yes&ddlEffect_From=' + ddlEffect_From + '&txtCurrency=' + txtCurrency + '&txtfromdate=' + txtfromdate + '&txttodate=' + txttodate + '&ddl_Month=' + ddl_Month + '&ddl_Year=' + ddl_Year + '', 'ndf');
                  Loading_HideImage();
              }
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

              width: 940,
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

