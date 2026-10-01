<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Docket_General_Search.aspx.cs"
    Inherits="Docket_Entry_Docket_General_Search" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .padding
        {
            padding-left: 10px;
            padding-top: 3px;
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
            font-weight: bold; /*color:#5E4C4C;*/
            color: #3C3535;
        }
    </style>
    <script language="javascript" type="text/javascript">

        document.body.style.cursor = 'pointer';
        var oldColor = '';
        var jobno;

        function ChangeRowColor(rowID, Value) {
            document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
        }

    </script>
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
            <div id="newbu">
                <input type="submit" value="Submit" class="new" onclick="Docket_General_New('New'); return false" /></div>
            <div id="verslic">
            </div>
            <div id="editbu">
                <a href="#" class="edit"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                Docket Entry</div>
            <div id="verslic">
            </div>
            <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>

             
        </div>
        <div id="tag_transact_src_inner">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_transact_lft_in1" style="width: 950px">
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                             From Date
                        </div>
                        <div id="txtcon-m_Exchange">
                             <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtfromdate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src">
                            To Date
                        </div>
                        <div id="txtcon-m_Exchange">
                               <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txttodate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                        </div>
                    </div>
                </div>
                <div id="tag_transact_lft_in1">
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            Importer&nbsp; Name</div>
                        <div id="txtcon-m_Exchange">
                           <asp:DropDownList ID="ddlImp_name" runat="server" CssClass="txtbox_none"  Font-Size="12px"
                                   Width="280px">
                               </asp:DropDownList> 
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l">
                        <div id="tag_label_transact_Src">
                           
                        </div>
                        <div id="txtcon-m_Exchange">
                            
                        </div>
                    </div>
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                        onclick="page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                    </a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                </div>
            </div>
        </div>
    </div>
    <div id="innerbox_MidMain_Grid">
            <div id="tag_srcinner1grid">
            <div id="allbu">
                <input id="Submit1" type="submit" value="Submit" class="allgrid" runat="server" onserverclick="btnSearchAll_Click"
                    onclick="document.getElementById('hdn_A_to_Z_Search').value='';page_Loading();" /></div>
            <div id="Div1">
            </div>
            <div id="mainmastop2container_rght_tag3">
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt">#</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('A')">A</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('B')">B</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('C')">C</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('D')">D</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('E')">E</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('F')">F</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('G')">G</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('H')">H</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('I')">I</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('J')">J</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('K')">K</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('L')">L</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('M')">M</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('N')">N</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('O')">O</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('P')">P</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Q')">Q</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('R')">R</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('S')">S</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('T')">T</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('U')">U</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('V')">V</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('W')">W</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('X')">X</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Y')">Y</a></div>
                <div id="small-alph-icon-tag">
                    <a href="#" class="small-alph-iconButt" onclick="Get_A_to_Z_Value('Z')">Z</a></div>
            </div>
        </div>
        
        <div runat="server" id="div_pagination1" visible="false">
            <br />
            <br />
        </div>
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" style="overflow: hidden;" runat="server">
                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="350%"
                    DataKeyNames="FILE_REFNO" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
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

                         
                          <asp:BoundField DataField="JOB_NO" HeaderText="JobNo" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left6" HorizontalAlign="Left" />
                        </asp:BoundField>
                    

                         <asp:BoundField DataField="CONTAINER_SIZE_20" HeaderText="Cont Size 20'" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" />
                        </asp:BoundField>

                         <asp:BoundField DataField="CONTAINER_SIZE_40" HeaderText=" Cont Size 40'" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" />
                        </asp:BoundField>


                         <asp:BoundField DataField="FCL_LCL" HeaderText="FCL/LCL" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left"  />
                        </asp:BoundField>


                         <asp:BoundField DataField="NO_OF_PACKAGES" HeaderText="No of Packages" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" />
                        </asp:BoundField>


                          <asp:BoundField DataField="GROSS_WEIGHT" HeaderText="Gross Weight" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" />
                        </asp:BoundField>

                      <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Description" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left"  />
                        </asp:BoundField>

                          <asp:BoundField DataField="SUPPLIER" HeaderText="Suppliers" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left"  />
                        </asp:BoundField>


                         <asp:BoundField DataField="HOUSE_AGENTNAME" HeaderText="House Agent Name" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left"/>
                        </asp:BoundField>

                         <asp:BoundField DataField="MASTER_AGENTNAME" HeaderText="Master Agent Name" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="ARRIVAL_DATE" HeaderText="Arrival Date " HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center"  />
                        </asp:BoundField>
                        <asp:BoundField DataField="DUTY_UPDATED_DATE" HeaderText="Duty updated Date" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="OOC_DATE" HeaderText="OOC Date" HeaderStyle-HorizontalAlign="Center" >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CLEARED_DATE" HeaderText="Cleared Date" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center"/>
                        </asp:BoundField>
                        
                        <asp:BoundField DataField="CLEARANCE_DELIVERY" HeaderText="Clearance Delivery" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center"/>
                        </asp:BoundField>

                         <asp:BoundField DataField="TOT_CLEARANCE_PERIOD" HeaderText="Totl Clearance Period" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center"/>
                        </asp:BoundField>

                         <asp:BoundField DataField="SERVICE_TASK_BWC" HeaderText="Service Task BWC" HeaderStyle-HorizontalAlign="Center">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Right"/>
                        </asp:BoundField>


                       

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
  

   <asp:HiddenField ID="HDBranch" runat="server" />
    <asp:HiddenField ID="hdn_A_to_Z_Search" runat="server" />
    <asp:HiddenField ID="hdrowindex" runat="server" />
    <asp:HiddenField ID="hdn" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

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
                    /*alert (lastProductId);*/
                }
            }
        });

        function gridviewScroll() {
            gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

                width: 1050,
                height: 500,
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

          var ddlImp_name = $('#<%= ddlImp_name.ClientID %>').val();
         
          var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
          var Todate = $('#<%= txttodate.ClientID %>').val();
       

          var Branch = $('#<%= HDBranch.ClientID %>').val();



          var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();


          if (lastProductId != 'NO RECORD FOUND') {
              function EXcel() {
                  var Type = 'excel';
                  win = window.open('../FlatFile/MIS_report_1.aspx?Docket_Entry_Rpt=Yes&ddlImp_name=' + ddlImp_name + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf');
                  Loading_HideImage();
              }


          }

  </script>


    <script type="text/javascript">
        window.onload = happycode;
        function happycode() {

            document.getElementById("MASTER_ID").click();


        }
        function Get_A_to_Z_Value(val) {

            document.getElementById("<%=hdn_A_to_Z_Search.ClientID %>").value = val;
      
        }

    </script>

     <%-- <asp:BoundField DataField="EROYAL_JOBNO" HeaderText="JobNo" HeaderStyle-Width="60px">
                            <ItemStyle CssClass="column_style_left6" HorizontalAlign="Left" Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FILE_REFNO" HeaderText="FileRef NO" HeaderStyle-Width="60px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Right" Width="60px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PORT_NAME" HeaderText="Port Name" HeaderStyle-Width="160px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="160px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TRANSPORT_NAME" HeaderText="Transport Name" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TRUCK_NUMBER" HeaderText="Truck Number" HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CFS_NAME" HeaderText="CFS Name" HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HOUSE_AGENTNAME" HeaderText="House Agent Name" HeaderStyle-Width="160px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="160px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TIN_NO" HeaderText="Tin No" HeaderStyle-Width="70px">
                            <ItemStyle CssClass="column_style_left5" Width="70px" HorizontalAlign="Left"/>
                        </asp:BoundField>--%>
    </span></span></span>
</asp:Content>
