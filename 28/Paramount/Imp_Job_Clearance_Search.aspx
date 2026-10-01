<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_Job_Clearance_Search.aspx.cs" Inherits="Imp_Job_Clearance_Search" %>
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
        font-weight:bold;
        /*color:#5E4C4C;*/
         color:#3C3535;
    }
    
    
</style>



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
            <div id="tag_srcinner1">
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_Imp_Job_Clearnce_Search_New('New'); return false" />
                </div>
                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 350px;">
                    Import Job Clearnce History
                </div>
            </div>
            <div id="tag_transact_src_inner" style="width: 1030px;">
                <div id="innerbox_transac_bot_inn" style="width: 950px;">
                    <div id="tag_label_transaction_popup_IGM2_empty" style="margin-left: -20px">
                    </div>
                    <div id="tag_label_transact_Src" style="width: 70px;">
                        Imp. Name
                    </div>
                    <div id="txtcon-m_src" style="width: 360px;">
                        <asp:DropDownList ID="ddlImp_name" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="350px">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src" style="width: 65px;">
                        Jobno
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 170px;">
                        <asp:TextBox ID="txtjobno" runat="server" ClientIDMode="Static" Width="150px" Font-Size="12px"
                            CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                </div>
                <div id="tag_Exchange_inner_lft">
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
                        <div id="tag_label_transact_Src" style="width: 62px;">
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
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 45px;">
                            Month</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                Width="100px" TabIndex="5">
                            </asp:DropDownList>
                        </div>

                         <div id="tag_label_transaction_popup_no_empty">
                         </div>

                        <div id="tag_label_transaction_Src_longlabel" style="width: 100px; margin-top:-5px;">
                             <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                              onserverclick="btnSearch_Click" tabindex="5"></a>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty"></div>
                         <div id="tag_label_transaction_Src_longlabel" style="width: 45px; margin-top:-5px;">
                             <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                        </div>


                    </div>
                </div>
                
            </div>
        </div>
    </div>

       


           <div id="innerbox_MidMain" style="height: 28px; margin-top:-13px;">
     <div id="tag_srcinner1grid" style="height: 28px; ">
              <div id="txtcon-m_transaction_code" >
                  <asp:ImageButton ID="btnexcel" runat="server"  Visible="false"  ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel(); return false;"/>
                  <asp:ImageButton ID="btnpdf" runat="server"  Visible="false" ImageUrl="~/images/pdf.jpg" Height="28px" Width="28px" OnClientClick="PDF(); return false;"/>
                  <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Import Job Status"  ImageUrl="~/images/icons/Invoice_icon.jpg" runat="server" OnClientClick="Get_Job_Rpt();return false;"  />
              </div>
             
        </div>
   </div>

    <div id="innerbox_MidMain_Grid" style="height: 580px;margin-top:-13px;"">
  
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">  

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                    DataKeyNames="Jobno" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
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

                        <asp:BoundField DataField="Jobno" HeaderText="Job No"  HeaderStyle-Width="103px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="103px" />
                        </asp:BoundField>
                         
                        <asp:BoundField DataField="Importer_Name" HeaderText="Imp. Name"  HeaderStyle-Width="900px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="900px"/>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>

            </div>
     
         </div>


        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
       
    </style>
     <asp:HiddenField ID="hd_Jobno" runat="server"  />
      <asp:HiddenField ID="HDBranch" runat="server" />


      <script language="javascript">
          var Branch = $('#<%= HDBranch.ClientID %>').val();
        
          function Get_Row_ID(val) {
              document.getElementById("<%=hd_Jobno.ClientID %>").value = val;
             
          }
          function Get_Job_Rpt() {
              var jobno;
              jobno = document.getElementById("<%=hd_Jobno.ClientID %>").value;
              if (jobno != '') {
                  NewWindow1('../ParaMount/Imp_Job_Clearance_rpt.aspx?Jobno=' + jobno + '', 'List', '870', '1024', 'yes');
              }
              else {
                  jAlert('Select a Grid Job', 'Export Job Status', function (r) { document.getElementById("txtjobno").focus(); });
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

              width: "100%",
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

