<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="GST_Bill_Export_Summary_Report.aspx.cs" Inherits="GST_Bill_Export_Summary_Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

 <%--<script src="../js/checkboxJScript.js" type="text/javascript"></script>--%>

    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <script type="text/javascript">
        $(function () {
            //Enable Disable all TextBoxes when Header Row CheckBox is checked.
            $("[id*=chkAll]").bind("click", function () {
                var chkHeader = $(this);

                //Find and reference the GridView.
                var grid = $(this).closest("table");

                //Loop through the CheckBoxes in each Row.
                $("td", grid).find("input[type=checkbox]").each(function () {

                    //If Header CheckBox is checked.
                    //Then check all CheckBoxes and enable the TextBoxes.
                    if (chkHeader.is(":checked")) {
                        $(this).attr("checked", "checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#D8EBF2" });
                        $("input[type=text]", td).removeAttr("disabled");
                    } else {
                        $(this).removeAttr("checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#FFF" });
                        $("input[type=text]", td).attr("disabled", "disabled");
                    }
                });
            });
        });
    </script>

    <script type = "text/javascript">
        $(function () {
            //Enable Disable TextBoxes in a Row when the Row CheckBox is checked.
            $("[id*=chk]").bind("click", function () {

                //Find and reference the GridView.
                var grid = $(this).closest("table");

                //Find and reference the Header CheckBox.
                var chkHeader = $("[id*=chkAll]", grid);

                //If the CheckBox is Checked then enable the TextBoxes in thr Row.
                if (!$(this).is(":checked")) {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#FFF" });
                    $("input[type=text]", td).attr("disabled", "disabled");
                } else {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#D8EBF2" });
                    $("input[type=text]", td).removeAttr("disabled");
                }

                //Enable Header Row CheckBox if all the Row CheckBoxes are checked and vice versa.
                if ($("[id*=chk]", grid).length == $("[id*=chk]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                } else {
                    chkHeader.removeAttr("checked");
                }
            });
        });
    </script>


<style type="text/css">
       th a
       {
           text-decoration: none;
       }
         .space
       {
          padding-left:5%;
          height:15px;
          width:12px;
          vertical-align:middle;
       }
       
        .space_2
       {
          padding-left:5%;
          height:16px;
          width:14px;
          vertical-align:middle;
       }
   </style>
            <div>
                <div id="innerbox_MidMain">
                    <div id="tag_srcinner1">
                       <%-- <div id="newbu" style="visibility:hidden">
                            <input type="submit" value="Submit" class="new" onclick="opennew_Import_licensenew(); return false" 
                                onkeypress="return stopRKey(event)" /></div>
                        <div id="verslic">
                        </div>--%>
                        <div id="editbu">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                          GST EXPORT - TOTAL SALES STATEMENT SUMMARY</div>
                    </div>
                  <%--  <div id="tag_Exchange_inner" style="width: 700px">--%>
                    <div id="tag_Adminsrc_inner_lft" style="width: 680px">
                        <div id="txt_container_Transact_Main_l" style="width: 680px">
                            <div id="tag_label_transaction_popup_gen">
                                Exporter Name</div>
                            <div id="txtcon-m_transaction_code" style="width: 140px">
                                <asp:TextBox ID="txt_ExporterName" runat="server" CssClass="txtbox_none_Mid_transac_src"
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
                    <div id="tag_srcinner_rght_Single_line" style="width: 190px">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="page_Loading();"
                                onserverclick="btnSearch_Click" tabindex="10"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" tabindex="11" target="_top">
                            </a>
                        </div>
                       <%-- <div id="small-butt-left" style="width: 100px">
                           
                            <asp:Button ID="btn_rpt" CssClass="generate" runat="server" OnClick="btn_rpt_Click"  />
                        </div>--%>
                    </div>
                    
                </div>
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_label_transaction_popup_IGM_Container"  style="width:900px; text-align:left">
                      <asp:Label ID="lk" runat="server" Width="100px" Text="Download Excel"></asp:Label>
                           <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
                            </div>
                    <div id="tag_srcinner1grid_table_Container">
                     <asp:GridView ID="gvdetails" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                           CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                            HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" 
                                             Style="overflow: auto;" onrowcreated="gvdetails_RowCreated" 
                                            onrowdatabound="gvdetails_RowDataBound" 
                                           >
                        <%--<div id="Main_Grid_Container">
                            <asp:GridView runat="server" ID="gvdetails" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                                BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                                Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true" PageSize="23" AllowPaging="True"
                                OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True" BorderColor="#C8C8C8"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1">--%>
                               <%-- <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <HeaderStyle Font-Underline="false" ForeColor="Black" />--%>
                                <Columns>
                                
                                   <%-- <asp:TemplateField HeaderStyle-Width="10px" HeaderStyle-Height="30PX">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" />
                                    </asp:TemplateField>--%>
                                     <%--<asp:TemplateField HeaderText="S.No" HeaderStyle-Width="44px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="44px" />
                                    </asp:TemplateField>--%>
                                    <asp:BoundField DataField="NON_TAXABLE_AMT" HeaderText="NON_TAXABLE_AMT">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TAXABLE_AMT" HeaderText="TAXABLE_AMT">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOT_CGST_AMT" HeaderText="TOT_CGST_AMT" >
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOT_SGST_AMT" HeaderText="TOT_SGST_AMT">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOT_IGST_AMT" HeaderText="TOT_IGST_AMT" >
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOT_INVOICE_VALUE" HeaderText="TOT_INVOICE_VALUE"  ControlStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left"  Font-Bold="true"/>
                                    </asp:BoundField>
                                  
                                 
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" /> 
            <asp:HiddenField ID="HD_tbl_sort" runat="server" /> 
            <asp:HiddenField ID="hdsort" runat="server" />

    
    <script language='javascript'>
      
       
        window.onload = happycode;
        function happycode() {

            document.getElementById("Master_Id").click();
            document.getElementById("License_Id").className = 'smenuactive';
            
        }

        function happycode1() {
       
        }

        function Get_A_to_Z_Value_Master(val) {

            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=btnSearch.ClientID %>").click();
        }
    </script>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hdn_Jobno" runat="server" />
    <asp:HiddenField ID="hdnBranch" runat="server" />


     <script type="text/javascript">

         function open_jobno() {

             var fromdate = document.getElementById("txtJobDate").value;
             alert(fromdate);
             NewWindow1('../BAS_Shipping/Imp_License_Summary_rpt.aspx', 'List', '810', '1024', 'yes');
         }
         </script>
    
      <script type="text/javascript">

          $(function () {

              $("#txt_ExporterName").autocomplete({

                  source: function (request, response) {
                      var field = $(this.element).attr('id');
                     
                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Billing_Summary_Exporter_List",
                          data: "{ 'mail': '" + request.term + "'}",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {

                              response(data.d);

                              if (data.d == '') {
                                  if (field == 'txt_ExporterName') {
                                      jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Exporter Name', 'error', 'topRight', true);

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
           var win = null;

           var Exp_name = $('#<%= txt_ExporterName.ClientID %>').val();
           var fromdate = $('#<%= txtJobDate.ClientID %>').val();
           var Todate = $('#<%= txttodate.ClientID %>').val();
           var Branch_Common = $('#<%= hdnBranch.ClientID %>').val();

           var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
           var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
           
           if (lastProductId != 'NO RECORD FOUND' && lastProductId != null) {

               function EXcel() {
                   var Type = 'excel';

                   win = window.open('../FlatFile/MIS_report_1.aspx?EXP_BILLING_GST_SUMMARY_RPT=Yes&Exp_name=' + Exp_name + '&fromdate=' + fromdate + '&Todate=' + Todate + '&Branch_Common=' + Branch_Common + '', 'ndf');
                   Loading_HideImage();
               }
           }

  </script>

</asp:Content>
