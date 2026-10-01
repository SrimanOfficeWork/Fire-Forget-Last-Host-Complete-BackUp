<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="BL_Multiple_Search.aspx.cs" Inherits="BL_Multiple_Search" %>
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
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_BL_Con_Search_New('New'); return false" />
                    
                   
                    </div>

                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   Export :- Consolidated BL

                    
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
                                BL Ref Name
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
                                <asp:TextBox ID="txtjobno" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" ></asp:TextBox>
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
                            Type</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddltype" runat="server" CssClass="listtxt_transac_mode_new" Width="100px" TabIndex="5">
                                 <asp:ListItem Text="" Value=""></asp:ListItem>
                                 <asp:ListItem Text="Brokerage" Value="Brokerage"></asp:ListItem>
                                 <asp:ListItem Text="Refund" Value="Refund"></asp:ListItem>
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
            <%--<div id="txtcon-m_transaction_code" style="margin-top: 08px; width: 70px;">
                <asp:ImageButton ID="btnprint" runat="server" ImageUrl="~/images/print.jpg" Height="28px"
                    Width="28px" OnClientClick="PrintGridData()" />
                <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                    Width="28px" OnClientClick="PL_EXcel()" />
            </div>--%>
          <%--  <div id="txtcon-m_transaction_code" style="margin-top: 10px; width: 350px;">
                <asp:Button ID="btnSend" CssClass="send_btn" Text="Send" runat="server" OnClientClick="Mail_open();" /></div>--%>
        </div>
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;"> <%-- style="overflow: hidden;"--%> 

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="180%"
                    DataKeyNames="BL_ID" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
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

                         <asp:BoundField DataField="REPORT_TYPE" HeaderText="Type"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="DBN_NO" HeaderText="DBN No"  HeaderStyle-Width="150px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>


                        <asp:BoundField DataField="Ref_Id" HeaderText="Ref. Id"  HeaderStyle-Width="70px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="70px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Ref_name" HeaderText="Ref. Name"  HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="Job No"  HeaderStyle-Width="281px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="281px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Buyername" HeaderText="Buyer Name"  HeaderStyle-Width="281px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="281px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Consigneename" HeaderText="Consignee Name"  HeaderStyle-Width="320px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="320px" />
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
</script>

  <script type="text/javascript">
      var win = null;

      var Jobdate = $('#<%= txtJobDate.ClientID %>').val();
      var Imp_name = $('#<%= txtimpname.ClientID %>').val();
      var Tr_mode = $('#<%= ddltr_mode.ClientID %>').val();
      var jobno = $('#<%= txtJobNo.ClientID %>').val();
      var Todate = $('#<%= txttodate.ClientID %>').val();
      var Branch = $('#<%= txtbranch.ClientID %>').val();

      var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
      var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

      if (lastProductId != null) {

          if (lastProductId != 'NO RECORD FOUND') {
              function PL_EXcel() {
                  var Branch = $('#<%= txtbranch.ClientID %>').val();
                  if (Branch != "") {
                      var Type = 'excel';
                      win = window.open('../FlatFile/MIS_report_1.aspx?PL_stat=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&jobno=' + jobno + '&Todate=' + Todate + '&Type=' + Type + '&Branch=' + Branch + '', 'ndf');
                      Loading_HideImage();
                  }
                  else {
                      alert('Branch is Mandatory');
                  }
              }

              function Mail_open() {
                  var Type = 'excel';
                  var Branch = $('#<%= txtbranch.ClientID %>').val();
                  if (Branch != "") {
                      var w = '700';
                      var h = '800';
                      LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                      TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                      settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                      win = window.open('../Report/Mail_Send.aspx?IMP_Pl_Rpt_Excel=Yes&Jobdate=' + Jobdate + '&Imp_name=' + Imp_name + '&Tr_mode=' + Tr_mode + '&jobno=' + jobno + '&Todate=' + Todate + '&Type=' + Type + '&Branch=' + Branch + '', 'ndf', settings);
                      win.focus();
                      return false;
                  }
              }

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

</asp:Content>

