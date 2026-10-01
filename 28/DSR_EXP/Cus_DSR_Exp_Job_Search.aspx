<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Cus_DSR_Exp_Job_Search.aspx.cs" Inherits="Cus_DSR_Exp_Job_Search" %>
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


<div id="tag_srcinner1">
               
                <div id="newbu">
              <span  id="btn_New_Entry" runat="server">
                  <input type="submit" value="Submit" class="new" onclick="DSR_Cus_Exp_Job_New('New'); return false" />
               </span>
               </div>
                <div id="newbu" style="Width:135px;">
               <asp:Button ID="btn_Wrapper" Text="Screen Creation" CssClass="autowidupdatebut" Width="120px"
                runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');DSR_Exp_Cover('New'); return false;"  />
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                 Exp. CUS DSR Search
                 </div>
</div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Exp. Name
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlCus_name" runat="server"  AutoPostBack="true"  TabIndex="1"
                                CssClass="txtbox_none" Font-Size="12px" Width="275px" onselectedindexchanged="ddlImp_name_SelectedIndexChanged" >
                                </asp:DropDownList>
                                  
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                              <div id="tag_label_transact_Src" style="width: 70px;">
                               Jobno
                            </div>
                            <div id="txtcon-m_src" style="width: 180px;">
                                <asp:DropDownList ID="ddl_Jobno" runat="server" CssClass="txtbox_none" Font-Size="12px" TabIndex="2" Width="150px">
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
                                Font-Size="12px" Width="125px" TabIndex="5" >
                            </asp:DropDownList>
                        </div>

                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                      <%-- -------------------------------------------------------------------------------%>
                        </div>

                        <%------------------------------------------------------%>
                    </div>
                                               
                        
                    </div>
                    <div id="tag_transact_srcinner_rght">
                        <div id="small-butt-left">
                            <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();" onserverclick="btnSearch_Click"
                                tabindex="6"></a>
                        </div>
                        <div id="small-butt-rght">
                            <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="7"></a>
                        </div>
                    </div>
                </div>
                  <%-- --------------------------------------------End---------------------------%>
<%-- </div>--%>
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

    <div id="innerbox_MidMain_Grid" style="height: 580px;margin-top:-13px;">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">  
                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                    DataKeyNames="ID,JOBNO" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
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

                        <asp:BoundField DataField="JOBNO_PS" HeaderText="Job No"  HeaderStyle-Width="150px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="150px" Font-Size="11px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="File. Refno"  HeaderStyle-Width="150px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="150px" Font-Size="11px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="EXPORTER_NAME" HeaderText="Customer Name"  HeaderStyle-Width="600px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="600px" Font-Size="11px" />
                        </asp:BoundField>

                    </Columns>
                </asp:GridView>
            </div>
         </div>


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
              freezesize: 0,
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

