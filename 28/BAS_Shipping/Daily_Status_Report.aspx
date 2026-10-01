<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Daily_Status_Report.aspx.cs" Inherits="Daily_Status_Report" 
MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="innerbox_MidMain">
        <div id="tag_srcinner1">
         <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                       Daily Statis Report </div>
                    <div id="verslic">
                    </div>
                   

        </div>
        <div id="tag_transact_src_inner" style="width: 955px;">
            <div id="tag_Exchange_inner_lft">
                <div id="innerbox_transac_bot_inn" style="width:900px;" >
                    <div id="tag_label_transact_Src">
                        Job No
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:DropDownList ID="ddljobno" runat="server" CssClass="listtxt_transac_src1" >
                        
                        </asp:DropDownList>
                    </div>

                       <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        Importer
                    </div>
                    <div id="tag_label_transact_Src" style="width:250px;">
                        <asp:DropDownList ID="ddl_Imp_name" runat="server" Font-Size="12px" CssClass="listtxt_transac_src1" Width="250px" >
                        </asp:DropDownList>
                    </div>

                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        Mode
                    </div>
                    <div id="tag_label_transact_Src">
                        <asp:DropDownList ID="ddlmode" runat="server" CssClass="listtxt_transac_src1" >
                        </asp:DropDownList>

                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                  
                </div>
                <div id="tag_transact_lft_in1" style="width: 755px;">
                    <div id="tag_label_transact_Src">
                        From Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtfromdate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtfromdate"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src">
                        To Date</div>
                    <div id="tag_label_transact_Src">
                        <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                            MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txttodate"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txttodate"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                      <div id="tag_label_transaction_popup_IGM2_empty">
                      </div>
                       <div id="tag_label_transact_Src">
                        Month</div>
                    <div id="tag_label_transact_Src">
                         <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="100px" TabIndex="5" >
                            </asp:DropDownList>
                    </div>
                          
                            
                </div>
            </div>
            <div id="tag_transact_srcinner_rght">
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                        onclick="return validdate();"></a>
                </div>
                <div id="small-butt-rght">
                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                </div>
            </div>
        </div>
    </div>
      <div id="innerbox_MidMain" style="height: 28px; margin-top:-13px;">
     <div id="tag_srcinner1grid" style="height: 28px; ">
             <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:0px; width:100px;">
                 
                      <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
               
             </div>
             <%-- <div id="verslic"></div>
               <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:08px; width:150px;">
                 <asp:Literal ID="ltl1" Text="Pending Count:"   runat="server"></asp:Literal>
                 <span style="color:Red;" > <asp:Literal ID="lblpending_cnt"   runat="server"></asp:Literal> </span>
             </div>--%>
          
        </div>
   </div>


     <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top:-13px;">
     <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">
     <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="175%"
                     OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
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

                        <asp:BoundField DataField="JOBNO_PS" HeaderText="BAS Ref"  HeaderStyle-Width="103px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="103px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Doc_Recd" HeaderText="Doc Recd"  HeaderStyle-Width="103px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="103px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="P.REF"  HeaderStyle-Width="153px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="153px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Agent" HeaderText="Agent"  HeaderStyle-Width="250px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="250px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Supplier" HeaderText="Supplier"  HeaderStyle-Width="250px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="250px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Country" HeaderText="Country"  HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="HAWB" HeaderText="HAWB"  HeaderStyle-Width="100px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Pkg_Wt" HeaderText="Pkg/ Wt"  HeaderStyle-Width="90px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Flight" HeaderText="Flight"  HeaderStyle-Width="90px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="FLT_ON" HeaderText="FLT ON"  HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px"/>
                        </asp:BoundField>
                         <asp:BoundField DataField="LAST_DT" HeaderText="LAST DT"  HeaderStyle-Width="150px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Ass_Value" HeaderText="Ass. Value"  HeaderStyle-Width="90px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="90px"/>
                        </asp:BoundField>
                        

                    </Columns>
                </asp:GridView>
           
        </div>
    </div>
    <asp:HiddenField ID="HDBranch" runat="server" />

    <script type="text/javascript">
        var win = null;

        var Imp_name = $('#<%= ddl_Imp_name.ClientID %>').val();
        var Jobno = $('#<%= ddljobno.ClientID %>').val();
        var Mode = $('#<%= ddlmode.ClientID %>').val();
        var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
        var Todate = $('#<%= txttodate.ClientID %>').val();
        var Branch_Common = $('#<%= HDBranch.ClientID %>').val();
        var Month = $('#<%= ddlmonth.ClientID %>').val();

        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND' && lastProductId != null) {

            function EXcel() {
                var Type = 'excel';
                win = window.open('../FlatFile/MIS_report_1.aspx?BAS_IMP_DSR_rpt=Yes&Imp_name=' + Imp_name + '&Jobno=' + Jobno + '&Mode=' + Mode + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Branch_Common=' + Branch_Common + '&Month=' + Month + '', 'ndf');
                Loading_HideImage();
            }
        }

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
       </asp:Content>
