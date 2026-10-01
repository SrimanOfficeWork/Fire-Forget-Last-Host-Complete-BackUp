<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_Exp_Invoice_Job_Count.aspx.cs" Inherits="Imp_Exp_Invoice_Job_Count" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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

<div id="tag_srcinner1" >
              
                <div id="editbu">
                    <a href="#" class="edit"></a>
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width:100px;">
                   Job Count
                 </div>
                     
                  <%--<div id="editbu" style="padding-top:3px;display:none;">
                      <asp:ImageButton ID="btncopy" runat="server"  ToolTip="Inv. No Edit" OnClientClick="open_GST_Imp_Inv_no_Edit(); return false" ImageUrl="~/images/icons/INV_No_Edit.png"  Height="28px" Width="28px" />
                    </div>--%>

                  <%-- <div id="editbu" style="padding-top:3px; width:35px;">
                    <asp:ImageButton ID="ImageButton1" Height="26px" Width="30px" ToolTip="Invoice Report"  ImageUrl="~/images/icons/Bill_pending.jpg" runat="server" OnClientClick="Inv_Bill();return false;"  />
                   </div>--%>
              
              <%--  <div id="editbu" style="padding-top: 3px; display: none;">
                    <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                        Width="28px" OnClientClick="EXcel()" />
                </div>--%>
               

            </div>
             <%-- --------------------------------------------Start---------------------------%>
    <div id="tag_transact_src_inner" style="width: 1030px;">
        <div id="tag_Exchange_inner_lft">
            <div id="tag_Exchange_inner_lft">
                <div id="innerbox_transac_bot_inn" style="width: 1050px;">
                    <div id="tag_label_transact_Src" style="width: 66px;">
                        Category
                    </div>
                    <div id="txtcon-m_transaction_code" style="width: 105px;">
                        <asp:DropDownList ID="ddltype" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                            Font-Size="12px" Width="105px" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                            <asp:ListItem Text=" " Value=""></asp:ListItem>
                            <asp:ListItem Text="Import" Value="I"></asp:ListItem>
                            <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src" style="width: 100px;">
                        Customer Name
                    </div>
                    <div id="txtcon-m_src" style="width: 320px;">
                        <asp:DropDownList ID="ddlCus_name" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="315px">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src" style="width: 80px;">
                        Tr. Mode
                    </div>
                    <div id="txtcon-m_src" style="width: 100px;">
                        <asp:DropDownList ID="ddl_Tr_mode" runat="server" CssClass="txtbox_none" 
                            Font-Size="12px" Width="100px">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="Air" Value="A"></asp:ListItem>
                            <asp:ListItem Text="Sea" Value="S"></asp:ListItem>
                            <asp:ListItem Text="Land" Value="L"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transact_Src" style="width: 60px;">
                        Filter
                    </div>
                    <div id="txtcon-m_src" style="width: 100px;">
                        <asp:DropDownList ID="ddl_Filter" runat="server" CssClass="txtbox_none" Font-Size="12px"
                            Width="100px">
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
                    <div id="txtcon-m_transaction_code" style="width: 140px;">
                        <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                            Width="135px" TabIndex="5">
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
                <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                    onserverclick="btnSearch_Click" tabindex="5"></a>
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

        <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1grid">
        </div>
        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" style="overflow: hidden; height: 545px;">
                <iframe scrolling="yes" id="iframe1" runat="server" width="1000px" height="1000px" ></iframe>
                    
            </div>
        </div>
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
     <asp:HiddenField ID="hd_Imp_Exp" runat="server" />

      <asp:HiddenField ID="HDBranch" runat="server" />

      <script language="javascript">
    function Inv_Bill() {
        var jobno = document.getElementById("<%=hdrowindex.ClientID %>").value;
        var Bill_Invo = document.getElementById("<%=hdBill_invno.ClientID %>").value;
        var Imp_Exp = document.getElementById("<%=hd_Imp_Exp.ClientID %>").value;

        if (jobno != '') {
            NewWindow1('../Billing_Paramount/GST_Imp_Exp_rpt.aspx?Job_Id=' + jobno + '&Imp_Exp=' + Imp_Exp + '&Bill_Inv_No=' + Bill_Invo + '', 'List', '870', '1024', 'yes');
        }
        else {
            jAlert('Select a Grid Job', 'Bill Invoice', function (r) { document.getElementById("ddlCus_name").focus(); });
        }
        
    }
    </script>
     
      

  

</asp:Content>

