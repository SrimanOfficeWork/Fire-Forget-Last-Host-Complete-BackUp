<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SEZ_General_Search.aspx.cs" Inherits="SEZ_General_Search" 
MasterPageFile="../Import_MasterPage/eRoyalMasters.master"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script src="../js/Billing/Charge.js" type="text/javascript"></script>--%>
    <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .space
        {
            padding-left: 20%;
            height: 15px;
            width: 12px;
            vertical-align: middle;
        }
        
        .space_2
        {
            padding-left: 20%;
            height: 16px;
            width: 14px;
            vertical-align: middle;
        }
        .statusColumn
        {
            border-right: 1px solid #ccc !important;
            border-left: 1px solid #ccc !important;
        }
        .gridHover td
        {
            background-color: #FFF4C2 !important; /* light yellow highlight */
            font-weight: bold;
        }
    </style>
    <div>
        <div id="innerbox_MidMain_Grid" style="height: 100px;">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 240px;">
                    SEZ Z : ITEM AVAILABLE STATUS</div>
                
            </div>
            </div>
            <div id="tag_Exchange_inner" style="width: 1038px; height: 104px; margin-top: -72px;">
                <div id="tag_Adminsrc_inner_lft">
                    <div id="tag_transact_lft_in1" style="width: 1260px">
                        <div id="tag_transact_lft_in1" style="width: 787px">
                    <div id="txt_container_Transact_Main_l" style="width:604px">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            <asp:DropDownList ID="ddlTerms" CssClass="listtxt_transac_item_gen_notn" Width="105px"
                                runat="server">
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 450px;">
                            <asp:TextBox ID="txtsearch" runat="server" CssClass="txtbox_none_Mid" autocomplete="OFF"
                                Width="437px" ClientIDMode="Static" MaxLength="40" TabIndex="2" onkeypress="return numcharspl1(event)"></asp:TextBox>
                        </div>
                    </div>

                    
                 <div id="tag_transact_srcinner_rght  style="margin-top:0px;">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                        onclick="page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                    </a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                </div>
                
            </div>
                   
            
             <div id="editbu" style="padding-top:3px;margin-top:-33px;margin-left:801px;">
                      <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="Excel()"/>
                </div>

                </div>
                <div id="tag_transact_lft_in1" style="width: 950px">
                    <div id="txt_container_Transact_Main_l" style="width: 900px;display:none">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            Importer Name
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 450px;display:none">
                            <asp:TextBox ID="txtImporterName" runat="server" CssClass="txtbox_none_Mid" MaxLength="50" Width="437px"
                                TabIndex="2" onkeypress="return numcharspl1(event)"></asp:TextBox>
                        </div>
                    </div>
                        
                        
                        <%--<div id="tag_transact_lft_in1" style="width: 400px; height: 25px; margin-top: 4px;
                            margin-left: 9px">
                            <div id="tag_label_transact_Src" style="width: 70px; margin-top: 3px">
                                From Date</div>
                            <div id="txtcon-m_transaction_code" style="width: 110px">
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
                            <div id="tag_label_transact_Src" style="width: 60px; margin-top: 3px">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px">
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
                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
        
            <div id="tag_transact_lft_in1" style="margin-top: 12px; width: 1265px; height:500px; margin-left: 6px;">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="JOBNO" AutoGenerateColumns="False"
                    BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                    style="width: 1250px; height:500px" ShowHeader="true" ShowHeaderWhenEmpty="true" PageSize="23" AllowPaging="True"
                    OnRowDataBound="gvdetails_RowDataBound" AllowSorting="True" BorderColor="#C8C8C8"
                    BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                     <asp:BoundField DataField="SLNO" HeaderText="SL No">
                            <ItemStyle CssClass="statusColumn" Width="90px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JOBNO" HeaderText="Job No">
                            <ItemStyle CssClass="statusColumn" Width="90px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMPORTER_NAME" HeaderText="IMPORTER NAME">
                            <ItemStyle CssClass="column_style_left5" Width="150px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_NO" HeaderText="BE NO">
                            <ItemStyle CssClass="statusColumn" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BE_DATE" HeaderText="BE DATE">
                            <ItemStyle CssClass="statusColumn" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_SLNO" HeaderText="INV SLNO">
                            <ItemStyle CssClass="statusColumn" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_SLNO" HeaderText="ITEM SLNO">
                            <ItemStyle CssClass="statusColumn" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="ITEM DESCRIPTION">
                            <ItemStyle CssClass="statusColumn" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_QTY" HeaderText="ITEM QTY">
                            <ItemStyle CssClass="statusColumn" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BALANCE_QTY" HeaderText="BALANCE QTY">
                            <ItemStyle CssClass="statusColumn" Width="100px" Font-Size="12px" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
            </div>
           </div>
    
     <asp:HiddenField ID="HDBranch" runat="server" />
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }

        }
    </script>
      <script type="text/javascript">
          $(function () {
              $("#txtsearch").autocomplete({
                  source: function (request, response) {
                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_EXP_GENERAL_SEARCH",
                          data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "' ,'Aflags': '" + document.getElementById("<%=ddlTerms.ClientID %>").value + "','IMP_EXP': 'Import'}",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {
                                  jQuery('#txtsearch').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                              }
                              else {
                                  jQuery('#txtsearch').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

          function Excel() {
              var ddlTerms = $('#<%= ddlTerms.ClientID %>').val();
              var txtsearch = $('#<%= txtsearch.ClientID %>').val();
              win = window.open('../FlatFile/MIS_report_1.aspx?SEZ_Z_Item_Status=Yes&ddlTerms=' + ddlTerms + '&txtsearch=' + txtsearch + '', 'ndf');
              Loading_HideImage();
          }

    </script>

</asp:Content>
