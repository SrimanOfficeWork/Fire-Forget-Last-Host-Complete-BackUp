<%@ Page Title="" Language="C#" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    AutoEventWireup="true" CodeFile="Imp_Job_Status.aspx.cs" Inherits="Import_MasterPage_Imp_Job_Status" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        th a
        {
            text-decoration: none;
        }
        .space
        {
            padding-left: 20%;
            height: 15px;
            width: 12px;
            vertical-align: middle;
        }
        
        .space_2
        {
            padding-left: 20%;
            height: 16px;
            width: 14px;
            vertical-align: middle;
        }
    </style>

    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        .hideGridColumn1
        {
            display: none;
        }
                
        .grid-view tr.header
            {
                border: solid 1px Black;
                
             }
    </style>
    <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <contenttemplate>
            <div>
                <div id="innerbox_MidMain" >
            <div id="tag_srcinner1" ">
              <div id="mainmastop2container_rght_tag2_txt1">
                     Import & Export Job Status
                     </div>
            </div>
    <%--<div id="tag_transact_src_inner" style="width: 805px;">--%>
     <div id="tag_transact_src_inner" style="width: 960px;">
      <%--  <div id="tag_Exchange_inner_lft">--%>

        <div id="tag_Exchange_inner_lft" style="width: 950px;">
           <%-- <div id="innerbox_transac_bot_inn">--%>
            <div id="innerbox_transac_bot_inn" style="width: 945px;">
                <div id="tag_label_transact_Src">
                    Type
                </div>
                <div id="tag_label_transact_Src">

                <asp:DropDownList ID="ddl_Imp_Exp" runat="server" CssClass="listtxt_transac_mode_new"
                        TabIndex="1" onselectedindexchanged="ddl_Imp_Exp_SelectedIndexChanged" 
                        AutoPostBack="true">
                        <asp:ListItem>Import</asp:ListItem>
                        <asp:ListItem>Export</asp:ListItem>
                    </asp:DropDownList>
                   <%-- <asp:TextBox ID="txtJobNo" runat="server" CssClass="txtbox_none_Mid_transac_code_new"></asp:TextBox>--%>

                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="DivIMP" runat="server">
                            <div id="tag_label_transact_Src" >
                                Importer Name
                            </div>
                
                            <div id="tag_label_transact_Src" style="width:292px;">
                                <asp:TextBox ID="txtimpname" runat="server" MaxLength="40" onblur="ChangeCase(this);"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                    Onkeypress="return numcharspl1(event)" TabIndex="2"></asp:TextBox>
                            </div>
                </div>
                 <div id="DivEXP" runat="server">
                 <div id="tag_label_transact_Src" >
                                Exporter Name
                            </div>
                
                            <div id="tag_label_transact_Src" style="width:292px;">
                                <asp:TextBox ID="txtExpname" runat="server" MaxLength="40" onblur="ChangeCase(this);"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                    Onkeypress="return numcharspl1(event)" TabIndex="2"></asp:TextBox>
                            </div> 
                 
                 </div>


                <div id="tag_label_transaction_popup_IGM2_empty" >
                </div>
              
                 <div id="tag_label_transact_Src" style=" width:70px;">
                     Job Status
                </div>
                <div id="txtcon-m_transaction_mode" style=" width:105px;" >
                 <asp:DropDownList ID="ddl_Filed_type" runat="server" 
                        CssClass="listtxt_transac_bondtype" Width="110px"
                        TabIndex="3" AutoPostBack="true" 
                        onselectedindexchanged="ddl_Filed_type_SelectedIndexChanged">
                        
                    </asp:DropDownList>
                    </div>

                    <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                   <div id="tag_label_transact_Src" style=" width:50px;">
                     Job No
                </div>
               <div id="tag_label_transact_Src"  style=" width:70px;">
                                <asp:TextBox ID="txtJobNo" Width="65px" runat="server" 
                                    CssClass="txtbox_none_Mid_transac_code_new" TabIndex="4"></asp:TextBox>
               </div>

            </div>

           <%-- <div id="tag_transact_lft_in1" style="width: 605px;">--%>
            <div id="tag_transact_lft_in1" style="width: 825px;">
                <div id="tag_label_transact_Src">
                    From Date</div>
                <div id="tag_label_transact_Src">
                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                        MaxLength="10" TabIndex="5"></asp:TextBox>
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
                <div id="tag_label_transact_Src">
                    To Date
                </div>
                <div id="tag_label_transact_Src">
                    <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                        MaxLength="10" TabIndex="6"></asp:TextBox>
                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                    </cc1:MaskedEditExtender>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                        Format="dd/MM/yyyy">
                    </cc1:CalendarExtender>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_no_empty">
                </div>
                <div id="tag_label_transaction_Src_longlabel">
                    Transport Mode</div>

                <div id="txtcon-m_transaction_mode">
                    

                    <asp:DropDownList ID="ddltr_mode" runat="server" CssClass="listtxt_transac_mode_new"
                        TabIndex="7" AutoPostBack="true" 
                        onselectedindexchanged="ddltr_mode_SelectedIndexChanged" >
                       
                    </asp:DropDownList>
                </div>

                   <div id="tag_label_transaction_popup_no_empty">
                </div>
                <div id="tag_label_transaction_popup_no_empty">
                </div>
                <div id="tag_label_transaction_Src_longlabel" style="margin-top:-5px;">
                                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                    onclick="return validdate();" tabindex="8"></a>
                    </div>
                    <div id="tag_label_transaction_popup_no_empty">
                </div>
                
                <div id="tag_label_transaction_Src_longlabel"  style="margin-top:-5px;">
                                   <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt" tabindex="7"></a>
                    </div>
            </div>
        </div>
   
    </div>
             
        </div>

        
<%--------------------------------------------------------------------------------------------------------------------------------%>
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1grid">
                       <%-- <div id="allbu">
                            </div>

                        <div id="verslic">
                            &nbsp;</div>--%>
                              <div id="txtcon-m_transaction_code" style="margin-top:08px;width:40px;">
              <asp:ImageButton ID="btnexcel" runat="server"   ImageUrl="~/images/xls.jpg"  Height="28px" Width="28px"  OnClientClick="EXcel()"/>
              
              </div>

              <div id="txtcon-m_transaction_code" style="margin-top:10px; width:75px;">
               <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="Mail_open();"  />
               </div>

               <div id="verslic">
                            &nbsp;</div>
                     <div id="txtcon-m_transaction_code" style="margin-top:10px; width:640px;">

                         <div id="mainmastop2container_rght_tag2_txt1">
                         
                         <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
                     </div>
                             
                         </div>
                          <div id="verslic">
                            &nbsp;</div>
                            <div id="txtcon-m_transaction_code" style="margin-top:10px; width:180px;">
                            <div id="mainmastop2container_rght_tag2_txt1">
                         Total Job count :
                         <asp:Literal ID="lblcnt" runat="server"></asp:Literal>
                     </div></div>
                    </div>
                    
                    
                    <div id="tag_srcinner1grid_table_Container">
                        <div id="Main_Grid_Container" style="overflow: hidden; height:530px;">

                            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND"  
                        AutoGenerateColumns="True" Width="130%" CssClass="grid-view" ShowHeader="true" 
                        ShowHeaderWhenEmpty="true"  OnRowDataBound="gvdetails_RowDataBound" DataKeyNames="JOBNO"
                        BorderStyle="Solid" BorderWidth="1px" 
                         CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" >
                        
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" 
                            BorderWidth="1px" />
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                             
                        </asp:GridView>

                        </div>
                    </div>
                    
                </div>
            </div> 
            
       
        </contenttemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hdBranch" runat="server" />

    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>

    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>


    <script type="text/javascript">
        var win = null;
        var IMP_EXP = $('#<%= ddl_Imp_Exp.ClientID %>').val();
        var Imp_name = $('#<%= txtimpname.ClientID %>').val();
        var Exp_name = $('#<%= txtExpname.ClientID %>').val();

        var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
        var Todate = $('#<%= txttodate.ClientID %>').val();
        var JobCat = $('#<%= ddl_Filed_type.ClientID %>').val();
        var Jobno = $('#<%= txtJobNo.ClientID %>').val();

        var Tr_mode = $('#<%= ddltr_mode.ClientID %>').val();
        var Branch = $('#<%= hdBranch.ClientID %>').val();

       
        var IMP_EXP_name = '';

        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND') {
            function EXcel() {

                if (IMP_EXP == 'Import') {
                    IMP_EXP_name = Imp_name;
                }
                else {
                    IMP_EXP_name = Exp_name;
                }
            
                var Type = 'excel';
                //                win = window.open('../FlatFile/MIS_report_1.aspx?Job_Filed_Status=Yes&IMP_EXP=' + IMP_EXP + '&IMP_EXP_name=' + IMP_EXP_name + '&Jobno=' + Jobno + ' &Fromdate=' + Fromdate + ' &Todate=' + Todate + '   &Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&JobCat=' + JobCat + '&Type=' + Type + '', 'ndf');
                win = window.open('../FlatFile/MIS_report_1.aspx?Job_Filed_Status=Yes&IMP_EXP=' + IMP_EXP + '&IMP_EXP_name=' + encodeURIComponent(IMP_EXP_name) + '&Jobno=' + Jobno + ' &Fromdate=' + Fromdate + ' &Todate=' + Todate + '   &Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&JobCat=' + JobCat + '&Type=' + Type + '', 'ndf');
                   
                Loading_HideImage();
            }

            function Mail_open() {
                var Type = 'excel';
                var w = '700';
                var h = '800';
                LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                win = window.open('../Report/Mail_Send.aspx?Job_Filed_Status=Yes&IMP_EXP=' + IMP_EXP + '&IMP_EXP_name=' + IMP_EXP_name + '&Jobno=' + Jobno + ' &Fromdate=' + Fromdate + ' &Todate=' + Todate + '   &Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&JobCat=' + JobCat + '&Type=' + Type + '', 'ndf', settings);
                win.focus();

                return false;
            }

        }

  </script>



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
                    if (lastProductId > 0) {
                        gridviewScroll();
                    }
                    else {

                        document.getElementById('<%=gvdetails.ClientID %>').style.width = "100%";
                        document.getElementById('<%=gvdetails.ClientID %>').style.overflow = "100%";
                    }

                }
            }
        });

        function gridviewScroll() {

            gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({
                width: 946,
                height: 522,
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
                barsize: 15
            });
        }
    </script>


</asp:Content>
