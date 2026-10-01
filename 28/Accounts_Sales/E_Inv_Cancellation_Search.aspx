<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="E_Inv_Cancellation_Search.aspx.cs" Inherits="E_Inv_Cancellation_Search" %>
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

    function ChangeRowColor(rowID, Value, Bill_invno, IMP_EXP) {
        document.getElementById("<%=hdrowindex.ClientID %>").value = Value;
        document.getElementById("<%=hdBill_invno.ClientID %>").value = Bill_invno;
        document.getElementById("<%=hd_Imp_Exp.ClientID %>").value = IMP_EXP;
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
                    url: "../Accounts_Auto_Search/Accounts_Auto_Search.asmx/Bank_Reconciliation",
                    data: "{ 'mail': '" + request.term + "','Branch': '" + '' + "','Aflags': '" + document.getElementById("<%=ddltype.ClientID %>").value + "','Chk': '" + document.getElementById("<%=chkqs.ClientID %>").checked + "' }",
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
<div id="tag_srcinner1">
<div id="tag_srcinner1" >
                <div id="newbu">
                    <input type="submit" value="Submit" class="new" onclick="Open_E_Inv_Cancellation_Entry_N('New'); return false" />
                </div>

                <div id="verslic">
                </div>
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                    E Inv. Cancellation
                 </div>
                     <div id="verslic"> </div>
                     <div id="editbu" style="padding-top:3px;">
                      <asp:ImageButton ID="btncopy" runat="server"  Visible="false" ToolTip="Reconciliation Edit" OnClientClick="open_GST_Sales_Inv_Edit(); return false" ImageUrl="~/images/icons/INV_No_Edit.png"  Height="28px" Width="28px" />
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
                               </asp:DropDownList>
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 170px;">
                                
                                   <asp:TextBox ID="txtsearch" runat="server"  ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                                
                            </div>
                              <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                            
                             <div id="tag_label_transact_Src" style="width: 100px;">
                              Customer Name
                            </div>
                            <div id="txtcon-m_src" style="width: 320px;">
                                <asp:DropDownList ID="ddlCus_name" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="315px"  >
                                </asp:DropDownList>
                            </div>
                            
                        </div>


                        <div id="tag_transact_lft_in1" style="width: 885px;">
                        

                            <div id="tag_label_transact_Src" style="width: 100px;">
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
                            <div id="tag_label_transact_Src"  style="width: 85px;">
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
                            
                        <div id="txtcon-m_transaction_code" style="width: 140px;">
                            <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                Font-Size="12px" Width="135px" TabIndex="5" >
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
     
   </div>

    <div id="innerbox_MidMain_Grid" style="height: 580px;margin-top:-13px;"> 

            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">  
                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="150%"
                     OnRowDataBound="gvdetails_RowDataBound" CellPadding="1" DataKeyNames="ID,IMP_EXP,BILL_INV_NO"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated">

                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                            <ItemTemplate>
                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="right" Width="45px"  />
                        </asp:TemplateField>

                         <asp:BoundField DataField="BILL_INV_NO" HeaderText="Invoice No"  HeaderStyle-Width="108px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="100px" Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMP_EXP" HeaderText="Imp/Exp"  HeaderStyle-Width="72px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="60px" Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INV_S_M" HeaderText="Job Cnt."  HeaderStyle-Width="72px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="60px" Font-Size="11px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="LOCAL_OTHER" HeaderText="Inv. Type"  HeaderStyle-Width="72px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="Left" Width="60px" Font-Size="11px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="BILL_INV_DATE" HeaderText="Invoice Date"  HeaderStyle-Width="80px">
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="80px" Font-Size="12px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUS_NAME" HeaderText="Customer Name"  HeaderStyle-Width="388px">
                            <ItemStyle  CssClass="column_style_left5" HorizontalAlign="left" Width="378px" Font-Size="11px"/>
                        </asp:BoundField>
                         
                        <asp:BoundField DataField="GRAND_TOTAL" HeaderText="Grand Total"  HeaderStyle-Width="90px"  >
                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="90px" Font-Bold="true"  Font-Size="11px" />
                        </asp:BoundField>
                         
                        
                    </Columns>
                </asp:GridView>

            </div>
         </div>

        <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
        <style type="text/css">
            .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
       
    </style>
     <asp:HiddenField ID="hdrowindex" runat="server" />
     <asp:HiddenField ID="hdBill_invno" runat="server" />
     <asp:HiddenField ID="hd_Imp_Exp" runat="server" />

      <asp:HiddenField ID="HDBranch" runat="server" />

      <script language="javascript">
    function Inv_Bill() {
        var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
        var Bill_Invo = document.getElementById("<%=hdBill_invno.ClientID %>").value;
        var Imp_Exp = document.getElementById("<%=hd_Imp_Exp.ClientID %>").value;

        if (jobno != '') {
            NewWindow1('../Accounts_Sales_Inv_Rpt/GST_Imp_Exp_rpt.aspx?Job_Id=' + jobno + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Invo + '', 'List', '870', '1024', 'yes');
        }
        else {
            jAlert('Select a Grid Job', 'Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
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
              freezesize: 3,
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

    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>

</asp:Content>

