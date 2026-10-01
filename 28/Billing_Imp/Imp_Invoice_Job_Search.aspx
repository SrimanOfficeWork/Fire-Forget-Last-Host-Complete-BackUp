<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_Invoice_Job_Search.aspx.cs" Inherits="Billing_Imp_Invoice_Job_Search" %>
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


<script language ="javascript" type="text/javascript">

    document.body.style.cursor = 'pointer';
    var oldColor = '';
    var jobno;

    function ChangeRowColor(rowID, Value, Bill_invno) {
        document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
        document.getElementById("<%=hdBill_invno.ClientID %>").value = Bill_invno;
    }

</script>
<script type = "text/javascript">
    function MutExChkList(chk) {
        if (chk.checked == true) {
            document.getElementById("<%=ddltype.ClientID %>").disabled = false;
            document.getElementById("<%=txtsearch.ClientID %>").disabled = false;
        }
        else {
            document.getElementById("<%=ddltype.ClientID %>").disabled = true;
            document.getElementById("<%=txtsearch.ClientID %>").disabled = true;
            document.getElementById("<%=txtsearch.ClientID %>").value = '';
            document.getElementById("<%=ddltype.ClientID %>").value = '0';

        }
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

<script type="text/javascript">
    $(function () {
        $("#txtsearch").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_IMPORTER_MASTER_SEARCH",
                    data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "' ,'Aflags': '" + document.getElementById("<%=ddltype.ClientID %>").value + "','Chk': '" + document.getElementById("<%=chkqs.ClientID %>").checked + "' }",
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
 </script>

<div id="innerbox_MidMain"  style="height:125px;" >


            <div id="tag_srcinner1" ">
        

<div id="tag_srcinner1"  >
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="open_Imp_Inv_Job_Search_New('New'); return false" />
                </div>

                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                   Import Invoice :- 
                 </div>
                     <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btncopy" runat="server"  ToolTip="Invoice Copy"  ImageUrl="~/images/icons/Copy.png"  Height="28px" Width="28px" 
                      OnClientClick="open_Billing_Inv_Copy('V'); return false" />
                       <%--<input type="submit" value="Submit" class="new" onclick="openGeneral_Search_New('New'); return false" />--%>
                      
                </div>
                   <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px; width:35px;">
                    <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Invoice Report"  ImageUrl="~/images/icons/Bill_pending.jpg" runat="server" OnClientClick="Inv_Bill();return false;"  />
                </div>
                  <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
                </div>
                   <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btntally" runat="server"  ToolTip="Tally Data"  ImageUrl="~/images/icons/Tally.png"  Height="28px" Width="28px" OnClientClick="Tally()"  />
                </div>
              <%--   <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btncopy" runat="server"  ToolTip="Invoice Copy"  ImageUrl="~/images/icons/Copy.png"  Height="28px" Width="28px" OnClientClick="Tally()"  />
                </div>--%>
                  <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:8px;">
                      <span id="lblTrkBENo" title="Pending Bill"  runat="server"  OnClick="open_Bill_Pending('Import');return false;"
                               style="color:Blue;cursor:hand; font-size:smaller;">Yet to Bill 
                               (<span style="color:Red; font-weight:bold;"> <asp:Literal ID="lblcnt" runat="server"></asp:Literal></span>)
                                ?</span>
                  </div>

            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                    <div id="tag_Exchange_inner_lft">

                    <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 950px;">
                        <div id="tag_label_transaction_popup_IGM2_empty" style="margin-left:-20px">
                        <asp:CheckBox ID="chkqs" onclick = "MutExChkList(this);" runat="server" />
                            </div>

                          <div id="txtcon-m_src" style="width: 100px;">
                               <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none" Font-Size="12px"  Width="95px"  >
                               <asp:ListItem Text=" " Value="0" ></asp:ListItem>
                               <asp:ListItem Text="Inv. no" Value="Inv_no" ></asp:ListItem>
                               <asp:ListItem Text="File.Ref.no" Value="F_no" ></asp:ListItem>
                               <asp:ListItem Text="Imp.Name" Value="Imp_Name" ></asp:ListItem>
                               </asp:DropDownList>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 170px;">
                                
                                   <asp:TextBox ID="txtsearch" runat="server"  ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                                
                            </div>

                            <div id="tag_label_transact_Src" style="width: 56px;">
                                Branch: 
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 130px;">
                                <asp:DropDownList ID="ddlbranch" runat="server" CssClass="txtbox_none"  AutoPostBack="true"  Font-Size="12px"
                                    Width="130px" onselectedindexchanged="ddlbranch_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                Imp. Name
                            </div>
                            <div id="txtcon-m_src" style="width: 280px;">
                                <asp:DropDownList ID="ddlImp_name" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                                     Font-Size="12px" Width="275px" onselectedindexchanged="ddlImp_name_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                          
                              <div id="tag_label_transaction_Src_longlabel" style="width: 40px;">
                            Mode</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlmode" runat="server" CssClass="listtxt_transac_mode_new"  Font-Size="12px"
                                TabIndex="5">
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

                            <div id="tag_label_transact_Src" style="width: 75px;" >
                               File Ref. No
                            </div>

                            <div id="txtcon-m_transaction_code">
                                <asp:DropDownList ID="ddljobno" runat="server" CssClass="txtbox_none"  AutoPostBack="true"
                                     Font-Size="12px" Width="100px" onselectedindexchanged="ddljobno_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                             <div  id="tag_label_transaction_popup_no_empty">
                        </div>
                              <div id="tag_label_transaction_Src_longlabel" style="width: 45px;">
                            Inv. No</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlinvno" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="100px" TabIndex="5" AutoPostBack="true"
                                onselectedindexchanged="ddlinvno_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                            
                      <%-- -------------------------------------------------------------------------------%>
                        </div>

                        <div id="tag_transact_lft_in1" style="width: 885px;">
                         <div id="tag_label_transact_Src" style="width: 65px;">
                          Bill Status
                          </div>

                            <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddl_Bill_status" runat="server" Width="100px" CssClass="listtxt_transac_mode_new"  Font-Size="12px" >
                             
                            </asp:DropDownList>
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


           <div id="innerbox_MidMain" style="height: 28px; margin-top:-13px;">
     <div id="tag_srcinner1grid" style="height: 28px; ">
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
        <%--<div id="tag_srcinner1grid">
        </div>--%>
       <%-- <div id="tag_srcinner1grid_table_Container">--%>
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">  

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                    DataKeyNames="FILE_REF_NO,Invoice_No" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
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

                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="File Ref. No"  HeaderStyle-Width="103px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="103px" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Invoice_No" HeaderText="Invoice No"  HeaderStyle-Width="125px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="125px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Invoice_Date" HeaderText="Invoice Date"  HeaderStyle-Width="90px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="90px"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="Importer_Name" HeaderText="Importer Name"  HeaderStyle-Width="480px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="480px"/>
                        </asp:BoundField>

                         <asp:BoundField DataField="BILL_STATUS" HeaderText="Status"  HeaderStyle-Width="35px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="35px"/>
                        </asp:BoundField>

                        <asp:BoundField DataField="Grand_tot" HeaderText="Grand Total"  HeaderStyle-Width="90px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="90px"/>
                        </asp:BoundField>

                       
                    </Columns>
                </asp:GridView>

            </div>
      <%--  </div>--%>
         </div>

        <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>
        <script src="../js/iframepopupwin.js" type="text/javascript"></script>


        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
       
    </style>
     <asp:HiddenField ID="hdrowindex" runat="server" />
     <asp:HiddenField ID="hdBill_invno" runat="server" />

      <asp:HiddenField ID="HDBranch" runat="server" />

      <script language="javascript">
    function Inv_Bill() {
        var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
        var Bill_Invo = document.getElementById("<%=hdBill_invno.ClientID %>").value;
        var Tax_Mode ='B';

        if (jobno != '') {
            NewWindow1('../Billing_Imp_Rpt/Bill_Import_Job_rpt.aspx?Jobno=' + encodeURIComponent(jobno) + '&Bill_Invo=' + Bill_Invo + '&Tax_Mode=' + Tax_Mode + '', 'List', '870', '1024', 'yes');
        }
        else {
            jAlert('Select a Grid Job', 'Bill Invoice', function (r) { document.getElementById("ddljobno").focus(); });
        }
        
    }
    </script>

      <script type="text/javascript">
          var win = null;

          var ddlAC_Branch = $('#<%= ddlbranch.ClientID %>').val();
          var Imp_name = $('#<%= ddlImp_name.ClientID %>').val();
          var Jobno = $('#<%= ddljobno.ClientID %>').val();
          var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
          var Todate = $('#<%= txttodate.ClientID %>').val();
          var Mode = $('#<%= ddlmode.ClientID %>').val();

          var Branch = $('#<%= HDBranch.ClientID %>').val();
          var Bill_No = $('#<%= ddlinvno.ClientID %>').val();
          var Month = $('#<%= ddlmonth.ClientID %>').val();

          var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
          var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
          var BILL_STATUS = $('#<%= ddl_Bill_status.ClientID %>').val();

          if (lastProductId != 'NO RECORD FOUND') {
              function EXcel() {
                  var Type = 'excel';
                  win = window.open('../FlatFile/MIS_report_1.aspx?Bill_Imp_Job_Inv_Rpt=Yes&ddlAC_Branch=' + ddlAC_Branch + '&Imp_name=' + Imp_name + '&Jobno=' + Jobno + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Mode=' + Mode + '&Branch=' + Branch + '&Type=' + Type + '&Bill_No=' + Bill_No + '&Month=' + Month + '&BILL_STATUS=' + BILL_STATUS + '', 'ndf'); 
                  Loading_HideImage();
              }
              function Tally() {
                  var Type = 'Tally';
                 win = window.open('../FlatFile/MIS_report_1.aspx?Bill_Imp_Job_Inv_Rpt_tally=Yes&ddlAC_Branch=' + ddlAC_Branch + '&Imp_name=' + Imp_name + '&Jobno=' + Jobno + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Mode=' + Mode + '&Branch=' + Branch + '&Type=' + Type + '&Bill_No=' + Bill_No + '&Month=' + Month + '&BILL_STATUS=' + BILL_STATUS + '', 'ndf');
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

