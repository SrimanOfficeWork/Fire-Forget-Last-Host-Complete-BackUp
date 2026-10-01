<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="DO_Entry_Search.aspx.cs" Inherits="DO_Entry_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .ad
        {
            width: 50px;
        }
    </style>

       <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .padding
        {
           padding-left:10px;
           padding-top:3px;
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

        function ChangeRowColor(rowID, Value, Bill_invno) {
            document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
            document.getElementById("<%=hdBill_invno.ClientID %>").value = Bill_invno;
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


<div id="innerbox_MidMain"  style="height:125px;" >

            <div id="tag_srcinner1" ">
        

<div id="tag_srcinner1"  >
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="DO_Entry_Search('New'); return false" />
                </div>
              
                <div id="mainmastop2container_rght_tag2_txt1" style="width:100px;">
                   DO Entry
                 </div>

                 <div id="mainmastop2container_rght_tag2_txt1" style="width:200px;">
                    <a href="#" onclick="win_hide();Open_CFS_CLEARNCE_TRANSPORTER_LINER(); return false">
                                             CFS/Clearnce/Trans/Liner </a>
                </div>

                  <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
                 </div>


                    <%-- <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btncopy" runat="server"  ToolTip="Inv. No Edit" OnClientClick="open_GST_Imp_Inv_no_Edit(); return false" ImageUrl="~/images/icons/INV_No_Edit.png"  Height="28px" Width="28px" />
                </div>
                   <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px; width:35px;">
                    <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Invoice Report"  ImageUrl="~/images/icons/Bill_pending.jpg" runat="server" OnClientClick="Inv_Bill();return false;"  />
                </div>
                  <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;display:none;">
                      <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
                </div>
                   <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btntally" runat="server"  ToolTip="Tally Data"  ImageUrl="~/images/icons/Tally.png"  Height="28px" Width="28px" OnClientClick="Tally()"  />
                </div>
              
                  <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:8px;">
                      <span id="lblTrkBENo" title="Pending Bill"  runat="server"  OnClick="open_GST_Bill_Pending_Import('Import');return false;"
                               style="color:Blue;cursor:hand; font-size:smaller;">Yet to Bill 
                               (<span style="color:Red; font-weight:bold;"> <asp:Literal ID="lblcnt" runat="server"></asp:Literal></span>)
                                ?</span>
                  </div>--%>

            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                         <%--   <div id="tag_label_transaction_popup_IGM2_empty" style="margin-left: -20px">
                                <asp:CheckBox ID="chkqs" onclick="MutExChkList(this);" runat="server" />
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                                <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                    Width="95px">
                                    <asp:ListItem Text=" " Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Inv. no" Value="Inv_no"></asp:ListItem>
                                    <asp:ListItem Text="File.Ref.no" Value="F_no"></asp:ListItem>
                                    <asp:ListItem Text="Imp.Name" Value="Imp_Name"></asp:ListItem>
                                    <asp:ListItem Text="Your.Ref.no" Value="Y_no"></asp:ListItem>
                                    <asp:ListItem Text="BE No" Value="BE_NO"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 170px;">
                                <asp:TextBox ID="txtsearch" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>--%>

                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Imp. Name
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlCus_name" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                     Font-Size="12px" Width="275px" onselectedindexchanged="ddlImp_name_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                              <div id="tag_label_transact_Src" style="width: 70px;">
                               Jobno
                            </div>
                            <div id="txtcon-m_src" style="width: 180px;">
                                <asp:DropDownList ID="ddl_Jobno" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="150px" onselectedindexchanged="ddl_Jobno_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                        </div>


                        <div id="tag_transact_lft_in1" style="width: 885px;">
                            <div id="tag_label_transact_Src" style="width: 65px;">
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
                            <div id="tag_label_transact_Src"  style="width: 62px;">
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




                            <div  id="tag_label_transaction_popup_no_empty">
                            </div>
                              <div id="tag_label_transaction_Src_longlabel" style="width: 45px;"> Month</div>
                            
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="100px" TabIndex="5" >
                            </asp:DropDownList>
                        </div>

                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                      <%-- -------------------------------------------------------------------------------%>
                          <div id="txt_container_Transact_Main_2">
                                            
                                             <div id="tag_label_transaction_Src_longlabel" style="width: 80px;"> Mode Type</div>
                                            <div id="txtcon-m_Exchange">
                                                <%--<asp:TextBox ID="txt_Imp_Ref_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                            ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                            CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="22"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddl_Mode_Type" runat="server" CssClass="txtbox_none" TabIndex="10"
                                                    Font-Size="12px" Width="95px">
                                                     <asp:ListItem Text="" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="LCL" Value="LCL"></asp:ListItem>
                                                    <asp:ListItem Text="FCL" Value="FCL"></asp:ListItem>
                                                    <asp:ListItem Text="Air" Value="Air"></asp:ListItem>
                                                </asp:DropDownList>                         
                                            </div>
                                            </div>



                        </div>

                        <%------------------------------------------------------%>
                    </div>
                                               
                        
                    </div>
                    <div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();" onserverclick="btnSearch_Click"
                                tabindex="5"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                        </div>
                    </div>
                </div>
                  <%-- --------------------------------------------End---------------------------%>
                     </div>
        </div>


           <div id="innerbox_MidMain" style="height: 28px; margin-top:-13px; display:none;">
     <div id="tag_srcinner1grid" style="height: 28px;  ">
             <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:08px; width:100px;">
                 <asp:Literal ID="ltl" Text="Inv Count:"   runat="server"></asp:Literal>
                 <span style="color:Red;" > <asp:Literal ID="lbljobcnt"   runat="server"></asp:Literal> </span>
             </div>
              <div id="verslic"></div>
               <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:08px; width:150px;">
                 <asp:Literal ID="ltl1" Text="Pending Count:"   runat="server"></asp:Literal>
                 <span style="color:Red;" > <asp:Literal ID="lblpending_cnt"   runat="server"></asp:Literal> </span>
             </div>
              <div id="verslic"></div>

                <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:08px; width:170px;">
                 <asp:Literal ID="ltl2" Text="Completed  Count:"   runat="server"></asp:Literal>
                 <span style="color:Red;" > <asp:Literal ID="lblCompleted_cnt"   runat="server"></asp:Literal> </span>
             </div>
              <div id="verslic"></div>
              <div id="mainmastop2container_rght_tag2_txt1" style="margin-top:08px; width:170px;">
                 <asp:Literal ID="ltl3" Text="Cancelled Count:"   runat="server"></asp:Literal>
                 <span style="color:Red;" > <asp:Literal ID="lblCancelled_cnt"   runat="server"></asp:Literal> </span>
             </div>
              <div id="verslic"></div>
        </div>
   </div>

  <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:auto;"> <%-- style="overflow: hidden;"--%> 

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                    OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" DataKeyNames="DO_ID,JOBNO"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="40px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right"  />
                        </asp:TemplateField>
                        <asp:BoundField DataField="CUSTOMER_NAME" HeaderText=" Cus.Name"  HeaderStyle-Width="100px">
                            <ItemStyle  CssClass="column_style_left" />
                        </asp:BoundField>

                         <asp:BoundField DataField="JOBNO" HeaderText="Job no"  HeaderStyle-Width="150px">
                            <ItemStyle  CssClass="column_style_left"/>
                        </asp:BoundField>

                    </Columns>
                </asp:GridView>

            </div>
        </div>



         <script type="text/javascript">
             var win = null;

             var Imp_name = $('#<%= ddlCus_name.ClientID %>').val();
             var ddl_Jobno = $('#<%= ddl_Jobno.ClientID %>').val();
             var Tr_Mode = $('#<%= ddl_Mode_Type.ClientID %>').val();
             

             var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
             var Todate = $('#<%= txttodate.ClientID %>').val();
             var Month = $('#<%= ddlmonth.ClientID %>').val();

             var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
             var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

             if (lastProductId != 'NO RECORD FOUND') {
                 function EXcel() {
                     var Type = 'Tally';
                     win = window.open('../FlatFile/MIS_report_1.aspx?DO_DATA=Yes&Imp_name=' + Imp_name + '&ddl_Jobno=' + ddl_Jobno + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Month=' + Month + '&Tr_Mode=' + Tr_Mode + '', 'ndf');
                     Loading_HideImage();
                 }
             }

  </script>

     <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
     <script src="../js/iframepopupwin.js" type="text/javascript"></script>
        
     <asp:HiddenField ID="hdrowindex" runat="server" />
     <asp:HiddenField ID="hdBill_invno" runat="server" />
     <asp:HiddenField ID="HDBranch" runat="server" />

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

