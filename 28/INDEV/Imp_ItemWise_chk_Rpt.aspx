<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_ItemWise_chk_Rpt.aspx.cs" 
Inherits="Imp_ItemWise_chk_Rpt" %>
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



<div id="innerbox_MidMain">


 <div id="tag_srcinner1">
        

<div id="tag_srcinner1"  >
               <%-- <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_Quotation_New('New'); return false" />
                </div>

                <div id="verslic">
                </div>--%>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   Item Wise Report :- 
                 </div>
                  <div id="verslic"></div>
                  <%-- <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                                Charge Order by</div>--%>
            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                   

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        
                              <div id="tag_label_transact_Src" style="width: 70px;">
                                Imp. Name
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                  <asp:DropDownList ID="ddlImp_name" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                     Font-Size="12px" Width="275px" onselectedindexchanged="ddlImp_name_SelectedIndexChanged" >
                                </asp:DropDownList>

                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           <div id="tag_label_transaction_Src_longlabel" style="width: 40px;">
                                Jobno</div>
                            <div id="txtcon-m_transaction_mode" style="width: 100px;">
                                <asp:DropDownList ID="ddljobno" runat="server" Width="90px" CssClass="listtxt_transac_mode_new"
                                    Font-Size="12px" TabIndex="5"  AutoPostBack="true" 
                                    onselectedindexchanged="ddljobno_SelectedIndexChanged">
                                    
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                              <div id="tag_label_transact_Src" style="width: 65px;">
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
                            <div id="tag_label_transact_Src"  style="width: 62px;">
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

                        </div>

                         <div id="innerbox_transac_bot_inn" style="width: 950px;">
                            <div id="tag_label_transact_Src"  style="width: 70px;">
                                Month
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 150px;">
                             <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="130px" TabIndex="5" >
                            </asp:DropDownList>
                            </div>
                         </div>


                        <%------------------------------------------------------%>
                   
                        
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
             <div id="txtcon-m_transaction_code" style="margin-top:08px; width:40px;">
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
              </div>

              <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="Mail_open();"  />
               </div>

        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">  

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                     OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" Width="45px"  />
                        </asp:TemplateField>

                        <asp:BoundField DataField="JOBNO" HeaderText="Job No"  HeaderStyle-Width="100px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Party Invoice No" HeaderText="Invoice No"  HeaderStyle-Width="165px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="165px"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="Invoice Date" HeaderText="Invoice Date"  HeaderStyle-Width="150px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="150px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Item Number of Purchasing Document" HeaderText="Item Slno"  HeaderStyle-Width="90px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="90px"/>
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
     <asp:HiddenField ID="HDBranch" runat="server" />
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
        var win = null;
        
        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        var Jobno = $('#<%= ddljobno.ClientID %>').val();
        var ddlImp_name = $('#<%= ddlImp_name.ClientID %>').val();
        var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
        var Todate = $('#<%= txttodate.ClientID %>').val();
        var Month = $('#<%= ddlmonth.ClientID %>').val();


        if (lastProductId != 'NO RECORD FOUND') {
            function EXcel() {
                var Type = 'excel';
                win = window.open('../FlatFile/MIS_report_1.aspx?NIN=Yes&Jobno=' + Jobno + '&ddlImp_name=' + ddlImp_name + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '', 'ndf');
                Loading_HideImage();
            }

            function Mail_open() {
                var Type = 'excel';
                var w = '700';
                var h = '800';
                LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                win = window.open('../Report/Mail_Send.aspx?NIN_IMP_Item_new=Yes&Jobno=' + Jobno + '&ddlImp_name=' + ddlImp_name + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '', 'ndf', settings);
                win.focus();

                return false;
            }

        }

  </script>

    </div>
</asp:Content>

