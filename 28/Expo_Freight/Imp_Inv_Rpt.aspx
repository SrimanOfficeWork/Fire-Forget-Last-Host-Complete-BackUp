<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" AutoEventWireup="true" CodeFile="Imp_Inv_Rpt.aspx.cs" 
Inherits="Imp_Inv_Rpt" %>
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
    
    #innerbox_MidMainD {
    /* background-image: url("images/srcinn_bg.gif"); */
    background-repeat: repeat-x;
    border: thin solid #c8c8c8;
    height: 180px;
    margin: 2px 0 20px;
    min-width: 800px;
    overflow: hidden;
     }
    .pagerStyle span
         {
                         color:Red;
                        font-weight:bold;
                        font-size:14pt;

         }
    
</style>


 



<div id="innerbox_MidMainD">
 <div id="tag_srcinner1">
        

<div id="tag_srcinner1"  >
                <div id="mainmastop2container_rght_tag2_txt1" style="width:80px; font-size:12px;" >
                   Item Report
                 </div>
                  <div id="verslic"></div>
                  <%-- <div id="mainmastop2container_rght_tag2_txt1" style="width:250px;">
                                Charge Order by</div>--%>

                            <div id="tag_label_transact_Src" style="width: 70px; margin-top:7px;">
                                Imp. Name
                            </div>
                            <div id="txtcon-m_src" style="width: 350px;margin-top:7px;">
                                <asp:DropDownList ID="ddl_Imp_name" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="345px">
                                </asp:DropDownList>
                            </div>
                            <%-- <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>--%>
                            <div id="tag_label_transact_Src" style="width: 65px;margin-top:7px;">
                                From Date</div>
                            <div id="txtcon-m_transaction_code"  style="width: 103px;margin-top:7px;">
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
                             <div id="tag_label_transact_Src" style="width: 62px;margin-top:7px;">
                                To Date
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 103px;margin-top:7px;">
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
                            <div id="tag_label_transaction_Src_longlabel" style="width: 45px;margin-top:7px;">
                                Month</div>
                            <div id="txtcon-m_transaction_code" style="width: 130px;margin-top:7px;">
                                <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                    Width="130px" TabIndex="5">
                                </asp:DropDownList>
                            </div>
            </div>
             <%-- --------------------------------------------Start---------------------------%>
             <div id="tag_transact_src_inner" style="width: 1030px;">
                     <div id="tag_Exchange_inner_lft">
                        <div id="innerbox_transac_bot_inn" style="width: 1050px;">

                             
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            
                             <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                       
                            <div id="txtcon-m_src" style="width: 130px;margin-top:5px; ">
                               <asp:Button ID="btnload_jobno" runat="server" Text="Load Jobno's" 
                                     onclick="btnload_jobno_Click" />
                            </div>
                             <div id="tag_label_transaction_Src_longlabel" style="width: 120px;">
                                  <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                 tabindex="5"></a>
                                </div>
                            <div id="tag_label_transaction_Src_longlabel" style="width: 70px;">
                                <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="6"></a>
                            </div>

                        </div>
                          <div id="tag_transact_src_inner" style="width:1030px;">
                 
                            
                            <div id="innerbox_MidMain_Trans_new" style="width:1030px; height:25px; margin-left:-10px; border-bottom-style:solid;  ">
                             

                            <div id="tag_label_transaction_exp_jobb" >
                            <asp:CheckBox ID="cbAll" runat="server" ForeColor="White" Font-Bold="true" font-size= "14px" Text="Select All" onclick="CheckAll();" />
                        </div>
                        </div>

                         
                         <div id="tag_label_transaction_exp_jobb" style="width: 1030px; overflow:auto; height:72px;" >


                                <asp:CheckBoxList ID="cbList" runat="server" ValidationGroup="VGroup" onclick="UnCheckAll();"
                                 CssClass=" txtbox_none_Mid_transac_pop_gen" width= "1010px" Height="22px"
                                    RepeatColumns="9" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                         </div>
                    
        </div>
                        
                    </div>
                    
                </div>
                  <%-- --------------------------------------------End---------------------------%>
                     </div>

        </div>

    <div id="innerbox_MidMain_Grid" style="height: 580px;">
             <div id="tag_srcinner1grid">
             <div id="txtcon-m_transaction_code" style="margin-top:08px; width:40px;">
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px" OnClientClick="EXcel()"/>
              </div>

              <div id="txtcon-m_transaction_code" style="margin-top:10px; width:350px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="Mail_open();" />
               </div>

        <div id="tag_srcinner1grid_table_Container">
            <div id="Main_Grid_Container" runat="server" style="overflow:hidden;">  

                <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="true" AllowPaging="true" PageSize="22"
                    CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true" Width="400%"
                     OnRowDataBound="gvdetails_RowDataBound" CellPadding="1"
                    CellSpacing="1" OnRowCreated="gvdetails_RowCreated" onpageindexchanging="gvdetails_PageIndexChanging" >
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <PagerStyle  ForeColor="Black"  CssClass="pager" />
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
     <asp:HiddenField ID="HDBranch" runat="server" />
     <asp:HiddenField ID="DSR_monthly_jobo" runat="server" />
     <asp:HiddenField ID="BCD_notification" runat="server" />


<script type="text/javascript">

    function CheckAll() {
        var intIndex = 0;
        var rowCount = document.getElementById('<%=cbList.ClientID %>').getElementsByTagName("input").length;

        for (i = 0; i < rowCount; i++) {

            if (document.getElementById('<%=cbAll.ClientID %>').checked == true) {

                if (document.getElementById('<%=cbList.ClientID %>' + "_" + i)) {

                    if (document.getElementById('<%=cbList.ClientID %>' + "_" + i).disabled != true)

                        document.getElementById('<%=cbList.ClientID %>' + "_" + i).checked = true;
                }
            }
            else {

                if (document.getElementById('<%=cbList.ClientID %>' + "_" + i)) {

                    if (document.getElementById('<%=cbList.ClientID %>' + "_" + i).disabled != true)

                        document.getElementById('<%=cbList.ClientID %>' + "_" + i).checked = false;

                }

            }

        }

    }



    function UnCheckAll() {

        var intIndex = 0;

        var flag = 0;

        var rowCount = document.getElementById('<%=cbList.ClientID %>').getElementsByTagName("input").length;

        for (i = 0; i < rowCount; i++) {

            if (document.getElementById('<%=cbList.ClientID %>' + "_" + i)) {

                if (document.getElementById('<%=cbList.ClientID %>' + "_" + i).checked == true) {

                    flag = 1;

                }

                else {

                    flag = 0;

                    break;

                }

            }

        }

        if (flag == 0)

            document.getElementById('<%=cbAll.ClientID %>').checked = false;

        else

            document.getElementById('<%=cbAll.ClientID %>').checked = true;
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

              width: 1000,
              height: 520,
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

    var win = null;
    var txtfromdate = $('#<%= txtfromdate.ClientID %>').val();
    var txttodate = $('#<%= txttodate.ClientID %>').val();
    var ddlmonth = $('#<%= ddlmonth.ClientID %>').val();
    var Branch = $('#<%= HDBranch.ClientID %>').val();

    var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
    var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

    var DSR_monthly_jobo = $('#<%= DSR_monthly_jobo.ClientID %>').val();

    //string ddl_Imp_name_, string txtfromdate_, string txttodate_, string ddlmonth_, string Branch_, string ddljobno_)

    if (lastProductId != 'NO RECORD FOUND') {
        function EXcel() {
            if (DSR_monthly_jobo != '') {
                
                var Type = 'excel';
                win = window.open('../FlatFile/MIS_report_1.aspx?EXPO_FREIGHT_RPT_I=Yes&txtfromdate=' + txtfromdate + '&txttodate=' + txttodate + '&ddlmonth=' + ddlmonth + '&Branch=' + Branch + '&ddljobno=' + DSR_monthly_jobo + '', 'ndf');
                Loading_HideImage();
            }
            else {
                alert('Select a Jobno !');
                return false;
            }

        }

        function Mail_open() {

            if (DSR_monthly_jobo != '' ) {
                var Type = 'mail';
                var w = '700';
                var h = '800';
                LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;

                settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                win = window.open('../Report/Mail_Send.aspx?EXPO_FREIGHT_RPT_I=Yes&txtfromdate=' + txtfromdate + '&txttodate=' + txttodate + '&ddlmonth=' + ddlmonth + '&Branch=' + Branch + '&ddljobno=' + DSR_monthly_jobo + '', 'ndf', settings);
                win.focus();
                return false;
            }
            else {
                alert('Select a Jobno !');
                return false;

            }
        }

    }

  </script>
  </div>
</asp:Content>

