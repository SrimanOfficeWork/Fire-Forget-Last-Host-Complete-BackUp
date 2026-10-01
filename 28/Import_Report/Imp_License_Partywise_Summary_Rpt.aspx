<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Imp_License_Partywise_Summary_Rpt.aspx.cs" Inherits="Imp_License_Partywise_Summary_Rpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
                        <div id="newbu" style="visibility:hidden">
                            <input type="submit" value="Submit" class="new" onclick="opennew_Import_licensenew(); return false" 
                                onkeypress="return stopRKey(event)" /></div>
                        <div id="verslic">
                        </div>
                        <div id="editbu">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                           IMPORT LICENSE REPORT</div>
                    </div>
                   <%-- <div id="tag_Exchange_inner" style="width:900px">--%>
                   <div id="tag_srcinner1">
                        <div id="tag_Adminsrc_inner_lft">
                            <div id="tag_transact_lft_in1" style="width:815px">
                                <div id="txt_container_Transact_Main_l" style="width:200px">
                                    <div id="tag_label_transaction_popup_gen" style="width:90px">
                                        Lic. Regn No.</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtLicense_No" runat="server" CssClass="txtbox_none_Mid_transac_code"   AutoPostBack="true"
                                           ClientIDMode="Static"  Onkeypress="return numchar(event)" MaxLength="15" 
                                            TabIndex="1" ontextchanged="txtLicense_No_TextChanged"></asp:TextBox>

                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="width:220px">
                                    <div id="tag_label_transaction_date" style="width:70px">
                                         Party Name</div>
                                    <div id="txtcon-m_src" style="width:100px">
                                       <asp:DropDownList ID="ddl_Partyname" runat="server" TabIndex="2"  CssClass="txtbox_none" Width="150px" ></asp:DropDownList>
                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="width:100px">
                                    <div id="tag_label_transaction_date" style="width:50px">
                                        &nbsp;Br Slno</div>
                                    <div id="txtcon-m_src" style="width:50px">
                                       <asp:DropDownList ID="ddl_Partybrslno" runat="server" TabIndex="2"  CssClass="txtbox_none" Width="50px" ></asp:DropDownList>
                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="width:150px">
                                    <div id="tag_label_transaction_date"  style="width:60px;">
                                        &nbsp; Scheme</div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:DropDownList ID="ddl_SchemeCode" runat="server" CssClass="listtxt_transac_src1" TabIndex="6">
                                </asp:DropDownList>

                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="width:140px">
                                    <div id="tag_label_transaction_Src_longlabel"  style="width:40px;">
                                        &nbsp; Port</div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:DropDownList ID="ddl_Port_License" runat="server" CssClass="listtxt_transac_src1" TabIndex="6">
                                </asp:DropDownList>

                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l"  style="visibility:hidden">
                                    <div id="tag_label_transact_Src">
                                         License Type
                                    </div>
                                    <div id="txtcon-m_transaction_list1">
                            <asp:DropDownList ID="ddl_Lic_Type" runat="server" CssClass="listtxt_transac_src1"
                                TabIndex="6">
                                </asp:DropDownList>
                        </div>    
                         
                                </div>
                                 
                            </div>
                          
                        </div>
                        <div id="tag_srcinner_rght_Single_line" style="width:190px">
                      <%--  <div id="small-butt-left" style="width:100px">
                        <asp:Button ID="btn_rpt" CssClass="generate" runat="server" OnClientClick="open_jobno(); return false"/>                      
                        </div>--%>
                         
                            <div id="small-butt-left">
                               <%-- <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="page_Loading();" onserverclick="btnSearch_Click"
                                    tabindex="10"></a>--%>
                                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                    tabindex="10"></a>
                                <%--<asp:Button ID="btnSearch"  runat="server" OnClick="btnSearch_Click" CssClass="search-site" />--%>
                            </div>
                            <div id="small-butt-rght">
                                <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" tabindex="11" target="_top">
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
                                Width="200%" ShowHeader="true" ShowHeaderWhenEmpty="true"  AllowPaging="True" PageSize="1500"
                                OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True" BorderColor="#C8C8C8"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                             >
                                
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                     <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                                <%-- <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="44px" >
                                        <ItemTemplate  >
                                        <asp:Label ID="lblitemslno"  runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  HorizontalAlign="Center"   Width="44px"  />
                                    </asp:TemplateField>--%>
                               <asp:BoundField DataField="License_RegNo" HeaderText="Lic.Regn No">
                                      <ItemStyle CssClass="column_style_right_gen_grid" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="License_No" HeaderText="License No">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>--%>
                                     <asp:BoundField DataField="Scheme" HeaderText="Scheme" >
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="Jobno" HeaderText="Jobno" SortExpression="REGISTRATION_DATE">
                                       <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="ImporterName" HeaderText="ImporterName" SortExpression="REGISTRATION_DATE">
                                       <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Br_slno" HeaderText="Br slno" SortExpression="REGISTRATION_DATE">
                                       <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                   
                                     <asp:BoundField DataField="Lic_ItemNo" HeaderText="Lic ItemNo">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="License_Value" HeaderText="License Value">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                <%-- <asp:BoundField DataField="Debit_amt" HeaderText="Debit_Amt">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>--%>
                                     <asp:BoundField DataField="Debit_Duty" HeaderText="Debit Duty">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                   
                                     <asp:BoundField DataField="Balance" HeaderText="Balance"  HeaderStyle-Font-Bold="true">
                                       <ItemStyle CssClass="column_style_left" Font-Bold="true" Font-Size="Small" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="License_FC" HeaderText="License FC">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Debit_FC" HeaderText="Debit FC">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Remaining_FC" HeaderText="Remaining FC" HeaderStyle-Font-Bold="true">
                                       <ItemStyle CssClass="column_style_left" Font-Bold="true" Font-Size="Small" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="TOTAL_CIF" HeaderText="TOTAL CIF">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Debit_CIF" HeaderText="Debit CIF">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Remaining_CIF" HeaderText="Remaining CIF"  HeaderStyle-Font-Bold="true">
                                       <ItemStyle CssClass="column_style_left" Font-Bold="true" Font-Size="Small" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="Total_Qty" HeaderText="TOTAL QTY">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Debit_Qty" HeaderText="Debit QTY">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Remaining_Qty" HeaderText="Remaining QTY"  HeaderStyle-Font-Bold="true">
                                       <ItemStyle CssClass="column_style_left" Font-Bold="true" Font-Size="Small" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="File_Ref_no" HeaderText="FileRefNo" SortExpression="LICENSE_NO">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="BE_NO" HeaderText="BE_No" SortExpression="LICENSE_DATE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_Date" HeaderText="BE_Date" SortExpression="EXCEMPTION">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="PORT" HeaderText="PORT" SortExpression="EXCEMPTION">
                                        <ItemStyle CssClass="column_style_left" />
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
            <asp:HiddenField ID="hdnBranch" runat="server" />

    
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

     <script type="text/javascript">

         function open_jobno() {

             if (document.getElementById("txtLicense_No").value != '') {
                 var f = document.getElementById("txtLicense_No").value;
                 NewWindow1('../BAS_Shipping/Import_License_Report_Rpt_viewer.aspx?jobno=' + f + '', 'List', '870', '1024', 'yes');
                 return false;
             }
             else {
                 alert('Enter the License Number');
             }
         }
         </script>
      <%--<script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>--%>

      <script type="text/javascript">
          $(function () {
              $("#txtLicense_No").autocomplete({

                  source: function (request, response) {

                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/LICENSE_NO_from_JOB",
                          data: "{ 'mail': '" + request.term + "' }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {
                                  jQuery('#txtLicense_No').validationEngine('showPrompt', 'Invalid Importer Name', 'error', 'topRight', true);
                              }

                              else {
                                  jQuery('#txtLicense_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

            //  var Imp_name = $('#<%= ddl_Partyname.ClientID %>').val();
            // var Br_slno = $('#<%= ddl_Partybrslno.ClientID %>').val();
            //var Jobno = $('#<%= txtLicense_No.ClientID %>').val();
            //var Mode = $('#<%= ddl_Port_License.ClientID %>').val();
            //var Branch_Common = $('#<%= hdnBranch.ClientID %>').val();
           // var SchemeCode = $('#<%= ddl_SchemeCode.ClientID %>').val();

           var Imp_name = encodeURIComponent($('#<%= ddl_Partyname.ClientID %>').val());
           var Br_slno = encodeURIComponent($('#<%= ddl_Partybrslno.ClientID %>').val());
           var Jobno = encodeURIComponent($('#<%= txtLicense_No.ClientID %>').val());
           var Mode = encodeURIComponent($('#<%= ddl_Port_License.ClientID %>').val());
           var Branch_Common = encodeURIComponent($('#<%= hdnBranch.ClientID %>').val());
           var SchemeCode = encodeURIComponent($('#<%= ddl_SchemeCode.ClientID %>').val());


           var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
           var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

           if (lastProductId != 'NO RECORD FOUND' && lastProductId != null) {

               function EXcel() {
                   var Type = 'excel';
                   //win = window.open('../FlatFile/MIS_report_1.aspx?IMP_LICENSE_SUMMARY_RPT_PARTYWISE=Yes&Imp_name=' + Imp_name + '&Br_slno=' + Br_slno + '&Jobno=' + Jobno + '&Mode=' + Mode + '&Branch_Common=' + Branch_Common + '&SchemaCode=' + SchemeCode + '', 'ndf');
                   win = window.open('../FlatFile/MIS_report_1.aspx?IMP_LICENSE_SUMMARY_RPT_PARTYWISE=Yes'
                    + '&Imp_name=' + Imp_name
                    + '&Br_slno=' + Br_slno
                    + '&Jobno=' + Jobno
                    + '&Mode=' + Mode
                    + '&Branch_Common=' + Branch_Common
                    + '&SchemaCode=' + SchemeCode, 'ndf');
               }
           }

  </script>
</asp:Content>
