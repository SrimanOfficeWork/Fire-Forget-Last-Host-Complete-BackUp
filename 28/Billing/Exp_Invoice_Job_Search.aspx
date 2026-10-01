<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Exp_Invoice_Job_Search.aspx.cs" Inherits="Billing_Exp_Invoice_Job_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>

       <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .padding
        {
           padding-left:10px;
           padding-top:3px;
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

      <script language ="javascript" type="text/javascript">

          document.body.style.cursor = 'pointer';
          var oldColor = '';
          var jobno;

          function ChangeRowColor(rowID, Value, Bill_invno) {
              document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
              document.getElementById("<%=hdBill_invno.ClientID %>").value = Bill_invno;
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

 
<div id="innerbox_MidMain"  >


            <div id="tag_srcinner1" ">
        

<div id="tag_srcinner1"  >
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_Exp_Inv_Job_Search_New('New'); return false" />
                </div>

                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   Export Invoice :- 
                 </div>

                   <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px; width:35px;">
                    <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Invoice Report"  ImageUrl="~/images/icons/Invoice_icon.jpg" runat="server" OnClientClick="Inv_Bill();return false;"  />
                </div>
                  <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
                </div>
                

            </div>
           <%-- --------------------------------------------Start---------------------------%>

                <div id="tag_transact_src_inner" style="width: 935px;">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                            <div id="tag_label_transact_Src">
                                Branch: 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 200px;">
                                <asp:DropDownList ID="ddlbranch" runat="server" CssClass="txtbox_none"  AutoPostBack="true"
                                    Width="200px" onselectedindexchanged="ddlbranch_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 110px;">
                                Shipper Name
                            </div>
                            <div id="txtcon-m_src" style="width: 330px;">
                                <asp:DropDownList ID="ddlExp_name" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    Width="325px" onselectedindexchanged="ddlExp_name_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 60px;" >
                               Job No
                            </div>

                            <div id="txtcon-m_transaction_code">
                                <asp:DropDownList ID="ddljobno" runat="server" CssClass="txtbox_none"  AutoPostBack="true"
                                    Width="100px" onselectedindexchanged="ddljobno_SelectedIndexChanged">
                                </asp:DropDownList>
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
                             <div id="tag_label_transaction_Src_longlabel" style="width: 70px;">
                            Mode</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlmode" runat="server" CssClass="listtxt_transac_mode_new"
                                TabIndex="5">
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
            
       
        </div>
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;"> <%-- style="overflow: hidden;"--%> 

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                    DataKeyNames="Jobno,Invoice_No" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
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

                        <asp:BoundField DataField="Jobno" HeaderText="Jobno"  HeaderStyle-Width="50px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="50px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Invoice_No" HeaderText="Invoice No"  HeaderStyle-Width="120px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="120px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Invoice_Date" HeaderText="Invoice Date"  HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="80px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Exporter_Name" HeaderText="Exporter Name"  HeaderStyle-Width="370px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="370px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Mode" HeaderText="Mode"  HeaderStyle-Width="50px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="50px"/>
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
     <asp:HiddenField ID="hdrowindex" runat="server" />
     <asp:HiddenField ID="hdBill_invno" runat="server" />

      <asp:HiddenField ID="HDBranch" runat="server" />


     <script language="javascript">
    function Inv_Bill() {
        var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
        var Bill_Invo = document.getElementById("<%=hdBill_invno.ClientID %>").value;

        if (jobno != '') {
          //  NewWindow1('../Report/Import_ReportViewer.aspx?jobno=' + document.getElementById("<%=hdrowindex.ClientID %>").value + '&CH=L', 'List', '810', '1024', 'yes');

            NewWindow1('../Billing_Exp_Rpt/Bill_Export_Job_rpt.aspx?Jobno=' + jobno + '&Bill_Invo=' + Bill_Invo + '', 'List', '870', '1024', 'yes');
            Bill_invno
        }
        else {
            jAlert('Select a Grid Job', 'Bill Invoice', function (r) { document.getElementById("ddljobno").focus(); });
        }
        
    }
    </script>


  


  <script type="text/javascript">
      var win = null;
      /*
      ddlExp_name
      ddljobno
      txtfromdate
      txttodate
      ddlmode
      */

      var ddlAC_Branch = $('#<%= ddlbranch.ClientID %>').val();
      var Exp_name = $('#<%= ddlExp_name.ClientID %>').val();
      var Jobno = $('#<%= ddljobno.ClientID %>').val();
      var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
      var Todate = $('#<%= txttodate.ClientID %>').val();
      var Mode = $('#<%= ddlmode.ClientID %>').val();

      var Branch = $('#<%= HDBranch.ClientID %>').val();

      var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
      var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

      if (lastProductId != 'NO RECORD FOUND') {
          function EXcel() {
              var Type = 'excel';
              win = window.open('../FlatFile/MIS_report_1.aspx?Bill_Job_Inv_Rpt=Yes&ddlAC_Branch=' + ddlAC_Branch + '&Exp_name=' + Exp_name + '&Jobno=' + Jobno + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Mode=' + Mode + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf');
             // win = window.open('../FlatFile/MIS_report_1.aspx?Bill_Job_Inv_Rpt=Yes&ddlAC_Branch=' + ddlAC_Branch + '&Exp_name=' + Exp_name + '&Jobno=' + Jobno + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '', 'ndf');
              Loading_HideImage();
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

              width: 950,
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

