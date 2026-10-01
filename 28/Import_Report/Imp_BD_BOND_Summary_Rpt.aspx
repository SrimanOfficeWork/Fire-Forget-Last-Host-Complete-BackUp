<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="../Import_MasterPage/eRoyalMasters.master"
    CodeFile="Imp_BD_BOND_Summary_Rpt.aspx.cs" Inherits="Imp_BD_BOND_Summary_Rpt" %>

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
                       
                        <div id="editbu">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1" style="width:200px">
                           BOND SUMMARY REPORT</div>
                         <div id="verslic">
                        </div>
                       
                    </div>
                 
                   <div id="tag_srcinner1">
                        <div id="tag_Adminsrc_inner_lft">
                            <div id="tag_transact_lft_in1" style="width:815px">
                                <div id="txt_container_Transact_Main_l" style="width:200px">
                                    <div id="tag_label_transaction_popup_gen" style="width:65px;">
                                        Bond No</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txt_BondNo" runat="server" 
                                            CssClass="txtbox_none_Mid_transac_code"  
                                           ClientIDMode="Static"  Onkeypress="return numchar(event)" MaxLength="15" 
                                            TabIndex="1" ontextchanged="txt_BondNo_TextChanged" ></asp:TextBox>

                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="width:300px">
                                    <div id="tag_label_transaction_popup_gen"  style="width:85px">
                                       Bond Type</div>
                                    <div id="txtcon-m_src" style="width:190px">
                                       <asp:DropDownList ID="ddl_BondType" runat="server" TabIndex="2"  CssClass="txtbox_none" Width="180px"  ></asp:DropDownList>
                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="width:250px">
                                    <div id="tag_label_transaction_popup_gen"  style="width:100px;">
                                        Bond Location</div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:DropDownList ID="ddl_BondLocation" runat="server" CssClass="listtxt_transac_src1" TabIndex="6" Width="150px" >
                                </asp:DropDownList>

                                    </div>
                                </div>

                                 <div id="txt_container_Transact_Main_l" style="width:200px">
                                    <div id="tag_label_transaction_Src_longlabel"  style="width:65px;">
                                      Job No</div>
                                    <div id="txtcon-m_transaction_item_maindet">
                                         <asp:TextBox ID="txt_Jobno" runat="server" 
                                            CssClass="txtbox_none_Mid_transac_code"
                                           ClientIDMode="Static"  Onkeypress="return numchar(event)" MaxLength="15" 
                                            TabIndex="1" ></asp:TextBox>

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
                     
                            <div id="small-butt-left">
                              
                                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                    tabindex="10"></a>
                              
                            </div>
                            <div id="small-butt-rght">
                                <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" tabindex="11" target="_top">
                                </a>
                            </div>
                              
                        </div>
                    </div>
                    
                </div>
                <div id="innerbox_MidMain_Grid" style="margin-top:-18px">
                
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
                                OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True" BorderColor="#C8C8C8" Visible="false"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                             >
                                
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                     <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                              
                                 <asp:BoundField DataField="SLNO" HeaderText="SlNo">
                                      <ItemStyle CssClass="column_style_right_gen_grid" />
                                    </asp:BoundField>
                                   <asp:BoundField DataField="JOBNO" HeaderText="JobNo" >
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                       <asp:BoundField DataField="FILE_REF_NO" HeaderText="File RefNo" >
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                <asp:BoundField DataField="INVOICE_NO" HeaderText="Invoice No">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                   
                                  <asp:BoundField DataField="BE_NO" HeaderText="BE No">
                                       <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="BE_DATE" HeaderText="BE Date">
                                       <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_NO" HeaderText="BOND No">
                                      <ItemStyle CssClass="column_style_right_gen_grid" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="BOND_DATE" HeaderText="BOND Date">
                                      <ItemStyle CssClass="column_style_right_gen_grid" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="BOND_AMT" HeaderText="BOND Amt">
                                      <ItemStyle CssClass="column_style_right_gen_grid" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="DEBIT_AMT" HeaderText="Debit Amt">
                                      <ItemStyle CssClass="column_style_right_gen_grid" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="BALANCE" HeaderText="Balance">
                                      <ItemStyle CssClass="column_style_right_gen_grid" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="EDD_RS" HeaderText="EDD_Rs">
                                      <ItemStyle CssClass="column_style_right_gen_grid" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PORT_CODE" HeaderText="PORT_CODE">
                                      <ItemStyle CssClass="column_style_right_gen_grid" />
                                    </asp:BoundField>
                                   
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>
                            <asp:GridView runat="server" ID="gvdetails_REBond" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                                BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_REBond_RowCreated"
                                Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true" AllowPaging="True"
                                PageSize="1500" OnRowDataBound="gvdetails_REBond_RowDataBound" AllowSorting="True"
                                BorderColor="#C8C8C8" Visible="false" BorderStyle="Solid" BorderWidth="1px" CellPadding="1"
                                CellSpacing="1">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="BOND_NO" HeaderText="BOND No">
                                        <ItemStyle CssClass="column_style_right_gen_grid" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JOBNO" HeaderText="JobNo">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FILE_REF_NO" HeaderText="File RefNo">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INVOICE_NO" HeaderText="Invoice No">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_NO" HeaderText="BE No">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_DATE" HeaderText="BE Date">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_NO" HeaderText="BOND No">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_AMT" HeaderText="BOND Amt" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DEBIT_AMT" HeaderText="Debit Amt">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BALANCE" HeaderText="Balance" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PORT_CODE" HeaderText="Port Code">
                                        <ItemStyle CssClass="column_style_left" Font-Size="Small" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>


                            <asp:GridView runat="server" ID="gvdetails_DEEC" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                                BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_DEEC_RowCreated"
                                Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true" AllowPaging="True"
                                PageSize="1500" OnRowDataBound="gvdetails_DEEC_RowDataBound" AllowSorting="True"
                                BorderColor="#C8C8C8" Visible="false" BorderStyle="Solid" BorderWidth="1px" CellPadding="1"
                                CellSpacing="1">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="JOBNO" HeaderText="JobNo">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FILE_REF_NO" HeaderText="File RefNo">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REGISTRATION_NO" HeaderText="Lic.Reg.No & Date">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_NO" HeaderText="BE No">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_DATE" HeaderText="BE Date">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_NO" HeaderText="BOND No">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="BOND_AMT" HeaderText="BOND Amt" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DEBIT_DUTY" HeaderText="Debit Amt">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="BALANCE" HeaderText="Balance" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                </Columns>
                                <PagerSettings Visible="False" />
                            </asp:GridView>

                            <asp:GridView runat="server" ID="gv_IGCR" AutoGenerateColumns="False" EmptyDataText="No Records Found"
                                BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_DEEC_RowCreated"
                                Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true" AllowPaging="True"
                                PageSize="1500" OnRowDataBound="gvdetails_DEEC_RowDataBound" AllowSorting="True"
                                BorderColor="#C8C8C8" Visible="false" BorderStyle="Solid" BorderWidth="1px" CellPadding="1"
                                CellSpacing="1">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="JOBNO" HeaderText="JobNo">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_NO" HeaderText="BOND No">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_NO" HeaderText="BE No">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_DATE" HeaderText="BE Date">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="IGM_MAWB_MBL" HeaderText="MAWB_MBL No">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="IGM_MAWB_MBLDATE" HeaderText="MAWB_MBL Date" >
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IGM_HAWB_HBLNO" HeaderText="HAWB_HBLDATE No">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="IGM_HAWB_HBLDATE" HeaderText="HAWB_HBL Date" >
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
            <asp:HiddenField ID="hdnBranch" runat="server" ClientIDMode="Static" />

    
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

             if (document.getElementById("txt_BondNo").value != '') {
                 var f = document.getElementById("txt_BondNo").value;
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
              $("#txt_BondNo").autocomplete({

                  source: function (request, response) {
//                      var number = document.getElementById('hdnBranch').value;
//                      alert(number);
                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/BOND_NO_from_JOB",
                          data: "{ 'mail': '" + request.term + "','Type': '" + document.getElementById('hdnBranch').value + "' }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {
                                  jQuery('#txt_BondNo').validationEngine('showPrompt', 'Invalid Bond Number', 'error', 'topRight', true);
                              }

                              else {
                                  jQuery('#txt_BondNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

          $(function () {
              $("#txt_Jobno").autocomplete({

                  source: function (request, response) {
                   
                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/BOND_NO_from_JOB_No_load",
                          data: "{ 'mail': '" + request.term + "' ,'Type': '" + document.getElementById('hdnBranch').value + "','Bond': '" + document.getElementById('txt_BondNo').value + "'  }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {
                                  jQuery('#txt_Jobno').validationEngine('showPrompt', 'Invalid Job Number', 'error', 'topRight', true);
                              }

                              else {
                                  jQuery('#txt_Jobno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

           var BondType = $('#<%= ddl_BondType.ClientID %>').val();
           var BondNo = $('#<%= txt_BondNo.ClientID %>').val();
           var BondLocation = $('#<%= ddl_BondLocation.ClientID %>').val();
         
           var Branch_Common = $('#<%= hdnBranch.ClientID %>').val();


           var Jobno = $('#<%= txt_Jobno.ClientID %>').val();

           if (BondType == 'PD, Provisional duty bond') {
               var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
               var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
               ReportType = "PD";
           }
           /*
           else if (BondType == 'RE, Re-export Bond') {
               var totalRows = $("#<%=gvdetails_REBond.ClientID %> tr").length;
               var lastProductId = $("#<%=gvdetails_REBond.ClientID %> tr:last").children("td:first").html();
               ReportType = "RE";
           }
           */
           else if (BondType.toUpperCase().startsWith('R')) {   // ← NEW CONDITION  Added by Ajith on 28/03/2026 for R bonds reports    
               var totalRows = $("#<%=gvdetails_REBond.ClientID %> tr").length;
               var lastProductId = $("#<%=gvdetails_REBond.ClientID %> tr:last").children("td:first").html();
               ReportType = "RE";
                  }
 
           else if (BondType == 'DE, DEEC Bond') {
               var totalRows = $("#<%=gvdetails_DEEC.ClientID %> tr").length;
               var lastProductId = $("#<%=gvdetails_DEEC.ClientID %> tr:last").children("td:first").html();
               ReportType = "DE";
           }
           else if (BondType == 'EC, EPCG Bond') {
               var totalRows = $("#<%=gvdetails_DEEC.ClientID %> tr").length;
               var lastProductId = $("#<%=gvdetails_DEEC.ClientID %> tr:last").children("td:first").html();
               ReportType = "EC";
           }
           else if (BondType == 'WH, Warehouse Bond') {
               var totalRows = $("#<%=gvdetails_DEEC.ClientID %> tr").length;
               var lastProductId = $("#<%=gvdetails_DEEC.ClientID %> tr:last").children("td:first").html();
               ReportType = "WH";
           }
           else if (BondType == 'NB,  National Bond') {
               var totalRows = $("#<%=gvdetails_DEEC.ClientID %> tr").length;
               var lastProductId = $("#<%=gvdetails_DEEC.ClientID %> tr:last").children("td:first").html();
               ReportType = "NB";
           }
//           else if (BondType == 'EI, IGCR') {
//               var totalRows = $("#<%=gv_IGCR.ClientID %> tr").length;
//               var lastProductId = $("#<%=gv_IGCR.ClientID %> tr:last").children("td:first").html();
//               ReportType = "EI";
//           }
//           else {
//               ReportType = "";
           //           }
           else if (BondType == 'EI, IGCR' || BondType == 'EU, End use Bond') { // Added by shanthini on 18-08-2026
               var totalRows = $("#<%=gv_IGCR.ClientID %> tr").length;
               var lastProductId = $("#<%=gv_IGCR.ClientID %> tr:last").children("td:first").html();
               ReportType = (BondType == 'EI, IGCR') ? "EI" : "EU";
           }
           else {
               ReportType = "";
               var lastProductId = null;
           }
          
           if (lastProductId != 'NO RECORD FOUND' && lastProductId != null) {

               function EXcel() {
                  
                   var Type = 'excel';
                   win = window.open('../FlatFile/MIS_report_1.aspx?BD_BOND_SUMMARY_REPORT=Yes&BondNo=' + BondNo + '&BondType=' + BondType + '&BondLocation=' + BondLocation + '&Branch_Common=' + Branch_Common + '&ReportType=' + ReportType + '&Jobno=' + Jobno + '', 'ndf');
                   Loading_HideImage();
               }
           }

  </script>
</asp:Content>
