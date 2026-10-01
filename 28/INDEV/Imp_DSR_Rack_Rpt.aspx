<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_DSR_Rack_Rpt.aspx.cs" 
Inherits="Imp_DSR_Rack_Rpt" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>
    <style type="text/css">
    
    
    #innerbox_MidMainD {
    /* background-image: url("images/srcinn_bg.gif"); */
    background-repeat: repeat-x;
    border: thin solid #c8c8c8;
    height: 180px;
    margin: 2px 0 20px;
    min-width: 800px;
    overflow: hidden;
     }
    .pagerStyle span
         {
                       color:Red;
                        font-weight:bold;
                        font-size:14pt;

         }
    
</style>


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
                   Import DSR Rack Report :- 
                 </div>
                  <div id="verslic"></div>
                  <%-- <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                                Charge Order by</div>--%>
            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 1050px;">
                            <div id="tag_label_transact_Src" style="width: 170px;">
                                Completed Job No
                            </div>
                            <div id="txtcon-m_src" >
                                <asp:DropDownList ID="ddljobno" runat="server" CssClass="txtbox_none"
                                    Font-Size="12px" Width="150px" >
                                </asp:DropDownList>
                            </div>
                            <%--<div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                              <div id="tag_label_transact_Src" style="width: 70px;">
                               Type
                            </div>
                            <div id="txtcon-m_src" style="width: 350px;">
                                <asp:DropDownList ID="ddljobtype" runat="server" CssClass="txtbox_none"
                                    Font-Size="12px" Width="150px" >
                                    <asp:ListItem Text="CLEARED " Value="C"></asp:ListItem>
                                    <asp:ListItem Text="UNDER CLEARANCE" Value="UC"></asp:ListItem>
                                </asp:DropDownList>
                            </div>--%>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" style="width: 165px;">
                                 Completed Job From Date</div>
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
                            <div id="tag_label_transact_Src" style="width: 162px;">
                                 Completed Job To Date
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
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                            <div id="tag_label_transaction_Src_longlabel" style="width: 145px;">
                                Completed Job Month</div>
                            <div id="txtcon-m_transaction_code" style="width: 130px;">
                                <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                    Width="130px" TabIndex="5">
                                </asp:DropDownList>
                            </div>
                            
                            <div id="tag_label_transaction_popup_no_empty">
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
             <div id="txtcon-m_transaction_code" style="margin-top:08px; width:40px;">
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
              </div>

              <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="Mail_open();"  />
               </div>

        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">  

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="true" AllowPaging="true" PageSize="22"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="200%" onpageindexchanging="gvdetails_PageIndexChanging"
                     OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    
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
                  document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "200%";
                  document.getElementById('<%=gvdetails.ClientID %>').style.width = "200%";
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
         var Jobno = $('#<%= ddljobno.ClientID %>').val();
         var txtfromdate = $('#<%= txtfromdate.ClientID %>').val();
         var txttodate = $('#<%= txttodate.ClientID %>').val();
         var ddlmonth = $('#<%= ddlmonth.ClientID %>').val();
         var Branch = $('#<%= HDBranch.ClientID %>').val();
         var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
         var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

         if (lastProductId != 'NO RECORD FOUND') {
             function EXcel() {
                 
                 var Type = 'excel';
                 win = window.open('../FlatFile/MIS_report_1.aspx?INDEV_NIS_IMP_DSR_Rack_Rpt=Yes&Jobno=' + Jobno + '&txtfromdate=' + txtfromdate + '&txttodate=' + txttodate + '&ddlmonth=' + ddlmonth + '&Branch=' + Branch + '', 'ndf');
                 Loading_HideImage();
             }

             function Mail_open() {
                 
                 var Type = 'excel';
                 var w = '700';
                 var h = '800';
                 LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                 TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                 settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                 win = window.open('../Report/Mail_Send.aspx?INDEV_NIS_IMP_DSR_Rack_Rpt=Yes&Jobno=' + Jobno + '&txtfromdate=' + txtfromdate + '&txttodate=' + txttodate + '&ddlmonth=' + ddlmonth + '&Branch=' + Branch + '', 'ndf', settings);
                 win.focus();

                 return false;
             }

         }

  </script>

    </div>
</asp:Content>

