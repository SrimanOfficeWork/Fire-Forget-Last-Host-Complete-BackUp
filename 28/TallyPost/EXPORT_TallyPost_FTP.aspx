<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="EXPORT_TallyPost_FTP.aspx.cs" Inherits="GST_Imp_Invoice_Job_Search" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

  <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

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

         //Enable Disable all TextBoxes when Header Row CheckBox is checked.
         $("[id*=chkAll]").bind("click", function () {
             var chkHeader = $(this);

             //Find and reference the GridView.
             var grid = $(this).closest("table");

             //Loop through the CheckBoxes in each Row.
             $("td", grid).find("input[type=checkbox]").each(function () {

                 //If Header CheckBox is checked.
                 //Then check all CheckBoxes and enable the TextBoxes.
                 if (chkHeader.is(":checked")) {
                     $(this).attr("checked", "checked");
                     var td = $("td", $(this).closest("tr"));
                     td.css({ "background-color": "#D8EBF2" });
                     $("input[type=text]", td).removeAttr("disabled");
                 } else {
                     $(this).removeAttr("checked");
                     var td = $("td", $(this).closest("tr"));
                     td.css({ "background-color": "#FFF" });
                     $("input[type=text]", td).attr("disabled", "disabled");
                 }
             });
         });
     });
    </script>

    <script type = "text/javascript">
        $(function () {
            //Enable Disable TextBoxes in a Row when the Row CheckBox is checked.
            $("[id*=chk]").bind("click", function () {

                //Find and reference the GridView.
                var grid = $(this).closest("table");

                //Find and reference the Header CheckBox.
                var chkHeader = $("[id*=chkAll]", grid);

                //If the CheckBox is Checked then enable the TextBoxes in thr Row.
                if (!$(this).is(":checked")) {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#FFF" });
                    $("input[type=text]", td).attr("disabled", "disabled");
                } else {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#D8EBF2" });
                    $("input[type=text]", td).removeAttr("disabled");
                }

                //Enable Header Row CheckBox if all the Row CheckBoxes are checked and vice versa.
                if ($("[id*=chk]", grid).length == $("[id*=chk]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                } else {
                    chkHeader.removeAttr("checked");
                }
            });
        });
    </script>


    <style type="text/css">
       th a
       {
           text-decoration: none;
       }
         .space
       {
          padding-left:5%;
          height:15px;
          width:12px;
          vertical-align:middle;
       }
       
        .space_2
       {
          padding-left:5%;
          height:16px;
          width:14px;
          vertical-align:middle;
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

<script type="text/javascript">
    $(function () {
        $("#txt_Bill_Inv_No").autocomplete({
            source: function (request, response) {
              
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Bill_Inv_No_TALLY_EXPORT",
                    data: "{ 'mail': '" + request.term + "','Status': '" + document.getElementById("<%=ddl_Status.ClientID %>").value + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            jQuery('#txt_Bill_Inv_No').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                        }
                        else {
                            jQuery('#txt_Bill_Inv_No').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

<div id="innerbox_MidMain"  style="height:85px;" >


            <div id="tag_srcinner1" ">
        

                <div id="tag_srcinner1">
                    
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 400px;">
                        EXPORT TALLY POST
                    </div>
                    <asp:Button ID="btnPostToTally" runat="server"  Text="Tally Post" Height="30px" Width="100px" ForeColor="Blue" Font-Bold="true"
                        onclick="btnPostToTally_Click"   />
                     <asp:Button ID="btn_Refresh" runat="server" Text="Refresh" Height="30px" Width="70px" ForeColor="Green" Font-Bold="true"
                        onclick="btn_Refresh_Click" />
                </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px; height:70px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1030px; height:70px;>

                        <div id="tag_Exchange_inner_lft" style="width: 1030px;">
                            <div id="innerbox_transac_bot_inn" style="width: 800px;">
                                <div id="tag_label_transaction_popup_gen" style="width: 100px; text-align: center;">
                                    Bill Invoice No</div>
                                <div id="txtcon-m_transaction_code" style="width: 140px">
                                    <asp:TextBox ID="txt_Bill_Inv_No" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        AutoPostBack="true" ClientIDMode="Static"  MaxLength="15" Width="130px" TabIndex="1"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_Invoice_Date">
                                    From Date</div>
                                <div id="tag_label_transact_Src">
                                    <asp:TextBox ID="txtJobDate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                        MaxLength="10" TabIndex="3"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_Invoice_Date" style="text-align: center; width:60px;">
                                    To Date
                                </div>
                                <div id="tag_label_transact_Src">
                                    <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                        MaxLength="10" TabIndex="4"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </div>
                                <div id="tag_label_transaction_popup_Invoice_Date" style="text-align: center; width:60px;">
                                    Status
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 90px">
                                    <asp:DropDownList ID="ddl_Status" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                        Width="90px">
                                        <asp:ListItem>Posted</asp:ListItem>
                                        <asp:ListItem>Not Posted</asp:ListItem>
                                        <asp:ListItem>Waiting List</asp:ListItem>
                                        <asp:ListItem>Error List</asp:ListItem>
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="tag_srcinner_rght_Single_line" style="width: 180px; height:5px; margin-top:0px;">
                                <div id="small-butt-left">
                                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="page_Loading();"
                                        onserverclick="btnSearch_Click" tabindex="10"></a>
                                </div>
                                <div id="small-butt-rght">
                                    <a href="../LoginPage/E_royal_Impex_Main.aspx" class="cancelButt" tabindex="11" target="_top">
                                    </a>
                                </div>
                            </div>
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
    <div id="innerbox_MidMain_Grid" style="height: 580px; margin-top: -13px;">
        <div id="Main_Grid_Container" runat="server" style="overflow: auto;">
            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="100%"
                DataKeyNames="ERROR_STATUS" OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    CssClass="column_style_right" BorderWidth="1px" />
                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                <Columns>
                    <asp:TemplateField HeaderStyle-Width="10px" HeaderStyle-Height="30PX">
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAll" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chk" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="BILL_INV_NO" HeaderText="BILL_INV_NO">
                        <ItemStyle CssClass="column_style_left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CLIENT_NAME" HeaderText="CLIENT_NAME">
                        <ItemStyle CssClass="column_style_left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JOBNO" HeaderText="JOBNO">
                        <ItemStyle CssClass="column_style_left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JOBDATE" HeaderText="BILL DATE">
                        <ItemStyle CssClass="column_style_left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NETAMOUNT" HeaderText="NETAMOUNT">
                        <ItemStyle CssClass="column_style_left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TALLY_STATUS" HeaderText="Status" HeaderStyle-Width="100px">
                        <ItemStyle CssClass="column_style_left"  Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CLIENT_NAME" HeaderText="Error">
                        <ItemStyle CssClass="hideGridColumn" />
                        <HeaderStyle CssClass="hideGridColumn" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NETAMOUNT" HeaderText="NETAMOUNT">
                        <ItemStyle CssClass="hideGridColumn" />
                        <HeaderStyle CssClass="hideGridColumn" />
                    </asp:BoundField>
                </Columns>
                <PagerSettings Visible="False" />
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

