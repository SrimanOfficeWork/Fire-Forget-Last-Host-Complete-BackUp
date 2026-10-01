<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Imp_Sims_Rpt.aspx.cs" Inherits="Imp_Sims_Rpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                        
                        
                        <div id="mainmastop2container_rght_tag2_txt1">
                           IMPORT SIMS REPORT</div>
                    </div>
                   
                   <div id="tag_srcinner1">
                        <div id="tag_Adminsrc_inner_lft">
                            <div id="tag_transact_lft_in1" style="width:870px; margin-top:16px">
                                <div id="txt_container_Transact_Main_l" style="width:200px">
                                    <div id="tag_label_transaction_popup_gen" style="width:90px">
                                         STL Regn No.</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtStl_No" runat="server" CssClass="txtbox_none_Mid_transac_code"   
                                           ClientIDMode="Static"  Onkeypress="return numchar(event)" 
                                            TabIndex="1" ></asp:TextBox>

                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width:165px">
                                    <div id="tag_label_transaction_popup_gen" style="width:60px">
                                        &nbsp; Job No.</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtJobno" runat="server" CssClass="txtbox_none_Mid_transac_code"   
                                           ClientIDMode="Static"  Onkeypress="return numchar(event)" 
                                            TabIndex="2" ></asp:TextBox>

                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width:175px">
                                    <div id="tag_label_transaction_Src_longlabel"  style="width:75px;">
                                        &nbsp; Regn Date</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtRegndate" CssClass="txtbox_none_Mid_transac_code" Width="90px" runat="server" TabIndex="5"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtRegndate"  Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True"> </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtRegndate" PopupButtonID="txtRegndate" Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width:173px">
                                    <div id="tag_label_transaction_date" style="width:73px">
                                        &nbsp; From Date</div>
                                    <div id="txtcon-m_src" style="width:100px;">
                                        <asp:TextBox ID="txtFrmdate" CssClass="txtbox_none_Mid_transac_code" Width="90px" runat="server" TabIndex="3"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFrmdate" Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                         MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">  </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFrmdate" PopupButtonID="txtFrmdate" Format="dd/MM/yyyy">  </cc1:CalendarExtender>
                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="width:130px">
                                    <div id="tag_label_transaction_date"  style="width:60px;">
                                        &nbsp; To Date</div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:TextBox ID="txtTodate" CssClass="txtbox_none_Mid_transac_code" Width="90px" runat="server" TabIndex="4"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtende2" runat="server" TargetControlID="txtTodate" Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                         MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True"> </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate" PopupButtonID="txtTodate" Format="dd/MM/yyyy">
                           </cc1:CalendarExtender>
                                    </div>
                                </div>

                                

                                
                                 
                            </div>
                          
                        </div>
                        <div id="tag_srcinner_rght_Single_line" style="width:180px">
                     
                         
                            <div id="small-butt-left">
                               <%-- <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="page_Loading();" onserverclick="btnSearch_Click"
                                    tabindex="10"></a>--%>
                                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();" onserverclick="btnSearch_Click" 
                                    tabindex="6"></a>
                                <%--<asp:Button ID="btnSearch"  runat="server" OnClick="btnSearch_Click" CssClass="search-site" />--%>
                            </div>
                            <div id="small-butt-rght">
                                <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" tabindex="7" target="_top">
                                </a>
                            </div>
                               <%-- <div id="small-butt-left" style="width:100px">
                        <asp:Button ID="btn_rpt" CssClass="generate" runat="server" OnClientClick="open_jobno(); return false" Visible="false"/>                      
                        </div>--%>
                        </div>
                    </div>
                    
                </div>
                <div id="innerbox_MidMain_Grid">
                
                      <div id="tag_label_transaction_popup_IGM_Container"  style="width:900px; text-align:left">
                      <asp:Label ID="lk" runat="server" Width="100px" Text="Download Excel"></asp:Label>
                           <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
                            </div>
                         <asp:Label ID="lbl_tot_Dbt_Amt" runat="server" Font-Bold="true"  ></asp:Label>
                   
                    <div id="tag_srcinner1grid_table_Container">
                        <div id="Main_Grid_Container">
                            <asp:GridView runat="server" ID="gvdetails"  AutoGenerateColumns="False" EmptyDataText="No Records Found"
                                BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                                Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true"  AllowPaging="True" PageSize="1500"
                                OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True" BorderColor="#C8C8C8"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                             >
                                
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                     <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                                <asp:BoundField DataField="INFO_TEXT" HeaderText="STL_NUMBER"  >
                                        <ItemStyle CssClass="column_style_left" Width="180px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REGN_DATE" HeaderText="REGN_DATE" >
                                        <ItemStyle CssClass="column_style_left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JOBNO" HeaderText="JOBNO" >
                                        <ItemStyle CssClass="column_style_left" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_SLNO" HeaderText="INVOICE NO"  >
                                        <ItemStyle CssClass="column_style_left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEM_SLNO" HeaderText="ITEM NO"  >
                                        <ItemStyle CssClass="column_style_left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REGN_VALIDITY" HeaderText="REGN_VALIDITY" >
                                        <ItemStyle CssClass="column_style_left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INFO_TYPE" HeaderText="INFO_TYPE" >
                                        <ItemStyle CssClass="column_style_left" Width="50px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INFO_CODE" HeaderText="INFO_CODE" >
                                        <ItemStyle CssClass="column_style_left" Width="50px"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INFO_QUALIFIER" HeaderText="INFO_QUALIFIER" >
                                        <ItemStyle CssClass="column_style_left" Width="50px"/>
                                    </asp:BoundField>                                    
                                    <%--<asp:BoundField DataField="DATE_TIME" HeaderText="DATE" >
                                        <ItemStyle CssClass="column_style_left" Width="50px"/>
                                    </asp:BoundField>--%>                              
                                                                 

                                                                      
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                        </div>
                    </div>           
                </div>
            </div>
            <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" /> 
            <asp:HiddenField ID="HD_tbl_sort" runat="server" /> 
            <asp:HiddenField ID="hdnBranch" runat="server" />

    
    <script language='javascript'>
      
       


        function Get_A_to_Z_Value_Master(val) {

            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
            document.getElementById("<%=btnSearch.ClientID %>").click();
        }
    </script>
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hdn_Jobno" runat="server" />

   

      <script type="text/javascript">
          $(function () {
              $("#txtStl_No").autocomplete({

                  source: function (request, response) {

                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/STL_NO",
                          data: "{ 'mail': '" + request.term + "' }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {
                                  jQuery('#txtStl_No').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                              }

                              else {
                                  jQuery('#txtStl_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                              }
                          },
                          error: function (XMLHttpRequest, textStatus, errorThrown) {
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

           var stlno = $('#<%= txtStl_No.ClientID %>').val();
           var frmdate = $('#<%= txtFrmdate.ClientID %>').val();
           var todate = $('#<%= txtTodate.ClientID %>').val();
           var Branch_Common = $('#<%= hdnBranch.ClientID %>').val();
           var regndate = $('#<%= txtRegndate.ClientID %>').val();
           var jobno = $('#<%= txtJobno.ClientID%>').val();


           var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
           var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

           if (lastProductId != 'NO RECORD FOUND' && lastProductId != null) {

               function EXcel() {
                   var Type = 'excel';
                   win = window.open('../FlatFile/MIS_report_1.aspx?IMP_SIMS_RPT=Yes&stlno=' + stlno + '&regndate=' + regndate + '&frmdate=' + frmdate + '&todate=' + todate + '&Branch_Common=' + Branch_Common + '&jobno='+ jobno+'', 'ndf');
                   Loading_HideImage();
               }
           }

  </script>
</asp:Content>
