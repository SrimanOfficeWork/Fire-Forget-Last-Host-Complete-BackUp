<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Covering_Letter_Search.aspx.cs" 
Inherits="BL_Generation_Annexure_Search" %>
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

      <script type="text/javascript">
          $(function () {
              $("#txt_CoveringNo").autocomplete({

                  source: function (request, response) {
                      //                      alert(document.getElementById("hdn_TYPE").value);
//                      var aa = document.getElementById("hdn_TYPE").value;
//                      alert(aa);
//                      alert('X');

                      var errorField = $(this.element).attr('id');
                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Covering_No_List",
//                          data: "{ 'mail': '" + request.term + "' }",
                          data: "{ 'mail': '" + request.term + "','Type': '" + document.getElementById("hdn_TYPE").value + "' }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return  data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {

                                  jQuery('#txt_CoveringNo').validationEngine('showPrompt', 'Incorrect Covering No', 'error', 'topRight', true);
                                  //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtStateName').focus(); });
                                  //return false;
                              }
                              else {
                                  jQuery('#txt_CoveringNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


          $(function () {
              $("#txt_Jobno").autocomplete({

                  source: function (request, response) {
                      //                      alert(document.getElementById("hdn_TYPE").value);
                      //                      var aa = document.getElementById("hdn_TYPE").value;
                      //                      alert(aa);
                      //                      alert('X');

                      var errorField = $(this.element).attr('id');
                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Covering_YOUR_REFNO_List",
                          //                          data: "{ 'mail': '" + request.term + "' }",
                          data: "{ 'mail': '" + request.term + "','Type': '" + document.getElementById("hdn_TYPE").value + "' }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {

                                  jQuery('#txt_Jobno').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);
                                  //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtStateName').focus(); });
                                  //return false;
                              }
                              else {
                                  jQuery('#txt_Jobno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

 
    <div id="innerbox_MidMain">
        <div id="tag_srcinner1">
            <div id="tag_srcinner1">
                <div id="newbu">
                    <%--<asp:Button ID="BtnNew" runat="server" Text="Save" CssClass="new" OnClick="BtnNew_Click" />--%>
                    <input type="submit" value="Submit" class="new" onclick="open_CoveringLetter_Search_New('New'); return false" />
                </div>
                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                    Covering Letter
                </div>
                <div id="verslic">
                </div>
            </div>
            <%-- --------------------------------------------Start---------------------------%>
            <div id="tag_transact_src_inner" style="width: 935px;">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 900px; height: 30px;">
                        <div id="tag_label_transact_Src">
                            Bill Type
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 105px;">
                            <asp:DropDownList ID="ddl_Type" runat="server" Width="100px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged">
                                <asp:ListItem>Import</asp:ListItem>
                                <asp:ListItem>Export</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transact_Src"  style="width: 70px">
                            Type
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 105px;">
                            <asp:DropDownList ID="ddl_PrintType" runat="server" Width="100px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>BMW</asp:ListItem>
                                <asp:ListItem>CFS</asp:ListItem>
                                <asp:ListItem>GENERAL</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transact_Src" style="width: 70px;">
                            Covering No
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 160px;">
                            <asp:TextBox ID="txt_CoveringNo" runat="server" CssClass="txtbox_none_Mid_transac_code" ClientIDMode="Static"
                                Width="150px" MaxLength="10"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 50px;">
                            Job No
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txt_Jobno" runat="server" CssClass="txtbox_none_Mid_transac_code"  ClientIDMode="Static"
                                MaxLength="10"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                    </div>
                    <div id="tag_transact_lft_in1" style="width: 845px;">
                        <div id="tag_label_transact_Src" style="width: 92px">
                            From Date</div>
                        <div id="txtcon-m_transaction_code" style="width: 105px;">
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
                        <div id="tag_label_transact_Src" style="width: 70px">
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
                        <div id="tag_label_transact_Src" style="width: 70px;">
                            Party Name
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 180px;">
                            <asp:DropDownList ID="ddl_PartyName" runat="server" Width="150px" >
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                                onserverclick="btnSearch_Click" tabindex="5"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hdn_TYPE" runat="server"  ClientIDMode="Static"/>
            <asp:HiddenField ID="HiddenField_Type" runat="server" />
           
            <%-- --------------------------------------------End---------------------------%>
        </div>
    </div>
       

    <div id="innerbox_MidMain_Grid" style="height: 580px;">
       
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%" 
                     OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" DataKeyNames="ID"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated" >

                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                      <%--  <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="20px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" Width="20px"  />
                        </asp:TemplateField>--%>

                        <asp:BoundField DataField="COVERING_NO" HeaderText="Covering No"  HeaderStyle-Width="100px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="PARTY_NAME" HeaderText="Party Name"  HeaderStyle-Width="350px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="350px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="DISPATCH_DATE" HeaderText="Dispatch Date"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="TYPE" HeaderText="Type"  HeaderStyle-Width="60px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="60px" />
                        </asp:BoundField>

                       <%-- <asp:BoundField DataField="FROM_DATE" HeaderText="From Date"  HeaderStyle-Width="60px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="60px" />
                        </asp:BoundField>

                          <asp:BoundField DataField="TO_DATE" HeaderText="To Date"  HeaderStyle-Width="60px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="60px" />
                        </asp:BoundField>--%>

                          <asp:BoundField DataField="PRINT_TYPE" HeaderText="Print Type"  HeaderStyle-Width="150px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="150px" />
                        </asp:BoundField>
                       
                    </Columns>
                </asp:GridView>

            </div>
        </div>
    </div>
   
     

    <%--<script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>--%>

    <!-- VALIDATION SCRIPT -->


        <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
       
    </style>

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

