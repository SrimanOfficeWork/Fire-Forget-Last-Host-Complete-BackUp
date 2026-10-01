<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Export_TALLY_Excel_Format_PARA.aspx.cs" Inherits="Export_TALLY_Excel_Format_PARA" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div id="innerbox_MidMain">
            <div id="tag_srcinner1">
                <div id="editbu">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1">
                    EXPORT TALLY EXCEL FORMAT</div>
            </div>
            
            <div id="tag_Adminsrc_inner_lft" style="width: 700px">
                <div id="txt_container_Transact_Main_l" style="width: 700px">
                    <div id="tag_label_transaction_popup_gen">
                        Exporter Name</div>
                    <div id="txtcon-m_transaction_code" style="width: 140px">
                        <asp:TextBox ID="txt_ImporterName" runat="server" CssClass="txtbox_none_Mid_transac_src"
                            ClientIDMode="Static" Onkeypress="return numchar(event)" MaxLength="15" TabIndex="1"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_Invoice_Date">
                        From Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txtJobDate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_Invoice_Date">
                        To Date
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="4"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>
                </div>
            </div>
            <%--  </div>--%>
            <div id="tag_srcinner_rght_Single_line" style="width: 200px">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="page_Loading();"
                        onserverclick="btnSearch_Click" tabindex="10"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" tabindex="11" target="_top">
                    </a>
                </div>
            </div>
        </div>
        <div id="innerbox_MidMain_Grid">
            <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
                <asp:Label ID="lk" runat="server" Width="130px" Text="Download Excel"></asp:Label>
                <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                    Width="28px" OnClientClick="EXcel()" />
           
            <asp:GridView ID="gvdetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                CssClass="grid-view" BorderWidth="1px" AllowPaging="false" EmptyDataText="NO RECORD FOUND"
                HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="287%" PageSize="23"
                Style="overflow: auto;" OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gvdetails_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="JOBNO" HeaderText="JOBNO" HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left" Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JOBNO_PS" HeaderText="JOBNO_Pre_Suffix" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="EXPORTER_NAME" HeaderText="EXPORTER_NAME" HeaderStyle-Width="250px">
                        <ItemStyle CssClass="column_style_left" Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ADDRESS1" HeaderText="ADDRESS1" HeaderStyle-Width="250px">
                        <ItemStyle CssClass="column_style_left" Width="250px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ADDRESS2" HeaderText="ADDRESS2" HeaderStyle-Width="230px">
                        <ItemStyle CssClass="column_style_left" Width="230px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ADDRESS3" HeaderText="ADDRESS3" HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ADDRESS4" HeaderText="ADDRESS4" HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ADDRESS5" HeaderText="ADDRESS5" HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="STATENAME" HeaderText="STATENAME" HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FILE_REF_NO" HeaderText="FILE_REF_NO" HeaderStyle-Width="130px">
                        <ItemStyle CssClass="column_style_left" Width="130px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="COMMODITY" HeaderText="COMMODITY" HeaderStyle-Width="400px">
                        <ItemStyle CssClass="column_style_left" Width="500px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MBL_no" HeaderText="MBL_no" HeaderStyle-Width="150px">
                        <ItemStyle CssClass="column_style_left" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="HBL_no" HeaderText="HBL_no" HeaderStyle-Width="150px">
                        <ItemStyle CssClass="column_style_left" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SB_no" HeaderText="SB_no" HeaderStyle-Width="80px">
                        <ItemStyle CssClass="column_style_left" Width="80px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="FOB_VALUE" HeaderText="FOB_VALUE" HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NO_OF_PKGS" HeaderText="NO_OF_PKGS" HeaderStyle-Width="60px">
                        <ItemStyle CssClass="column_style_left" Width="60px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="GROSS_WGT" HeaderText="GROSS_WGT" HeaderStyle-Width="90px">
                        <ItemStyle CssClass="column_style_left" Width="90px" />
                    </asp:BoundField>
                </Columns>
                <PagerSettings Visible="False" />
            </asp:GridView>
        </div>
    </div>
     </div>
    <asp:HiddenField ID="hdnBranch" runat="server" />
    

      <script type="text/javascript">

          $(function () {

              $("#txt_ImporterName").autocomplete({

                  source: function (request, response) {
                      var field = $(this.element).attr('id');
                     
                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/EXP_Name",
                          data: "{ 'mail': '" + request.term + "'}",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {

                              response(data.d);

                              if (data.d == '') {
                                  if (field == 'txt_ImporterName') {
                                      jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Importer Name', 'error', 'topRight', true);

                                      //jAlert('Importer Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                                      //return false;
                                  }

                              }
                              else {
                                  jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                              }
                          },
                          error: function (XMLHttpRequest, textStatus, errorThrown) {
                              ////alert(textStatus);
                          }
                      });
                  },
                  minLength: 1

              });
              return false;
              scroll: true;

          });
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

                  width: "99.9%",
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
         var win = null;



         var Jobno = $('#<%= txt_ImporterName.ClientID %>').val();
         var Branch_Common = $('#<%= hdnBranch.ClientID %>').val();

         var fromdate = $('#<%= txtJobDate.ClientID %>').val();
         var Todate = $('#<%= txttodate.ClientID %>').val();


         var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
         var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

         if (lastProductId != 'NO RECORD FOUND' && lastProductId != null) {

             function EXcel() {
                 var Type = 'excel';
                 win = window.open('../FlatFile/MIS_report_1.aspx?EXP_TALLY_EXCEL_BILLING_OTHERS=Yes&Imp_name=' + Jobno + '&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '&fromdate=' + fromdate + '&Todate=' + Todate + '', 'ndf');
                 Loading_HideImage();
             }
         }

  </script>

</asp:Content>
