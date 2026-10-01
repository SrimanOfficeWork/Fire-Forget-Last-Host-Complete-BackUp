<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Import_N_Form_Normal_Search.aspx.cs" 
Inherits="Import_N_Form_Normal_Search" %>
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

 
<div id="innerbox_MidMain"  >


            <div id="tag_srcinner1" ">
                <div id="tag_srcinner1">
                    <div id="newbu">
                        <input type="submit" value="Submit" class="new" onclick="open_Import_Nform_New('New'); return false" />
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                        Import :- N - From Generation
                    </div>
                    <div id="verslic">
                    </div>
                </div>
           <%-- --------------------------------------------Start---------------------------%>

                <div id="tag_transact_src_inner" style="width: 935px;">
                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 900px; height: 30px;">
                            <div id="tag_label_transact_Src" style="width: 92px">
                                JobNo
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" Width="100px">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                Importer Name
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 255px;">
                                <asp:DropDownList ID="ddlExp_name" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                    Font-Size="Small" Width="250px" OnSelectedIndexChanged="ddlExp_name_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 805px;">
                            <div id="tag_label_transact_Src" style="width: 92px">
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
                            <div id="tag_label_transact_Src" style="width: 55px">
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
                            <div id="tag_label_transact_Src" style="visibility: hidden; width:240px;">
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
           <%-- --------------------------------------------End---------------------------%>

            </div>
        </div>
       

    <div id="innerbox_MidMain_Grid" style="height: 580px;">
        <div id="tag_srcinner1grid">
        </div>
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="140%"
                     OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" DataKeyNames="NFORM_ID"
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

                        <asp:BoundField DataField="JOBNO" HeaderText="Job No"  HeaderStyle-Width="51px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="51px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="CONSIGNEE" HeaderText="Consignee Name"  HeaderStyle-Width="241px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="241px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="NF_OCTRAI_NO" HeaderText="Octrai No"  HeaderStyle-Width="151px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="151px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="NF_OCTRAI_DATE" HeaderText="Octrai Date"  HeaderStyle-Width="80px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="IMPORTER" HeaderText="Importer Name"  HeaderStyle-Width="241px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="241px"/>
                        </asp:BoundField>

                         <asp:BoundField DataField="FROM1" HeaderText="From"  HeaderStyle-Width="161px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="161px" />
                        </asp:BoundField>

                         <asp:BoundField DataField="PLACE_EXPORT" HeaderText="Place Of Export"  HeaderStyle-Width="161px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="161px"/>
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

