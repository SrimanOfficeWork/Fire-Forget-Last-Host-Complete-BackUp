<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EXP_BL_Job_Status.aspx.cs" Inherits="Export_EXP_BL_Job_Status" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export - GSP</title>

    <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />

     <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        
         </style>
    
    <style type="text/css">

.GridviewScrollHeader TH, .GridviewScrollHeader TD 
{ 
    padding: 5px; 
    font-weight: bold; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #EFEFEF; 
    text-align: left; 
    vertical-align: bottom; 
} 
.GridviewScrollItem TD 
{ 
    padding: 5px; 
    white-space: nowrap; 
    border-right: 1px solid #AAAAAA; 
    border-bottom: 1px solid #AAAAAA; 
    background-color: #FFFFFF; 
} 
.GridviewScrollPager  
{ 
    border-top: 1px solid #AAAAAA; 
    background-color: #FFFFFF; 
} 
.GridviewScrollPager TD 
{ 
    padding-top: 3px; 
    font-size: 14px; 
    padding-left: 5px; 
    padding-right: 5px; 
} 
.GridviewScrollPager A 
{ 
    color: #666666; 
}

.GridviewScrollPager SPAN

{
    font-size: 16px;
    font-weight: bold;
}


    
    </style>



    
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
     <link rel="stylesheet" type="text/css" href="../css/jquerycssmenu.css" />



     <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
     <script src="../js/cssverticalmenu.js" type="text/javascript"></script>
    <link href="../AutoComplete_CSS/MIS_jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../css/cssverticalmenu.css" rel="stylesheet" type="text/css" />

    <link rel="shortcut icon" type="image/x-icon" href="../images/favicon.ico" />
    
  
   
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
   

   <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
     <script src="../js/Import_Jscript/Imp_MIS.js" type="text/javascript"></script>

     <style type="text/css">
    html, body { overflow: hidden; height: 100% }
    body { margin:0; padding:0; }
</style>
     
</head>

<body style="overflow:hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
  <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>--%>

        
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Transact_popup_new" style="height:95px; margin:0px 0px 0px 0px; width:952px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                       Bill Of Lading Pending Jobs
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>


                

                <div id="tag_transact_src_inner" style=" width:900px;">
                    <div id="tag_Exchange_inner_lft">

                        <div id="innerbox_transac_bot_inn" style="margin-top:4px; width:890px;">
                            <div id="tag_label_transact_Src">
                                Shipper Name
                            </div>
                            <div id="tag_label_transact_Src" style="width: 311px;">
                                <asp:TextBox ID="txt_BL_Expname" runat="server" MaxLength="40" onblur="ChangeCase(this);"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Width="311px"
                                    Onkeypress="return numcharspl1(event)" TabIndex="1"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 70px;">
                                File Ref. No
                            </div>
                            <div id="tag_label_transact_Src" style="width: 120px;">
                                <asp:TextBox ID="txtJobNo" Width="120px" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                    TabIndex="2"></asp:TextBox>
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 100px;">
                                Sort File Ref. No
                            </div>

                            <div id="tag_label_transact_Src" style="width: 120px;">
                                 <asp:DropDownList ID="ddlorederby" runat="server" Width="98px" CssClass="listtxt_transac_Item_Schemecode">
                                <asp:ListItem Text="Ascending" Value="A"></asp:ListItem>
                                <asp:ListItem Text="Descending" Value="D" ></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                          

                        </div>


                        <%-- <div id="tag_transact_lft_in1" style="width: 605px;">--%>
                        <div id="tag_transact_lft_in1" style="width: 825px;">
                            <div id="tag_label_transact_Src">
                                From Date</div>
                            <div id="tag_label_transact_Src">
                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
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
                            <div id="tag_label_transact_Src">
                                To Date
                            </div>
                            <div id="tag_label_transact_Src">
                                <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                    MaxLength="10" TabIndex="4"></asp:TextBox>
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
                                    TabIndex="5">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                            <div id="tag_label_transaction_Src_longlabel" style="margin-top: -5px;">
                                <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                                    tabindex="6" onserverclick="btnSearch_Click"></a>
                            </div>
                            <div id="tag_label_transaction_popup_no_empty">
                            </div>
                            <div id="tag_label_transaction_Src_longlabel" style="margin-top: -5px;">

                                 <a href="#" class="cancelButt" id="A1" runat="server" onclick="win_hide();parent.adcodewindow.hide();return false;"
                                    tabindex="7" ></a>

                            </div>
                        </div>
                    </div>
                </div>


                </div>

                   

            <div id="innerbox_MidMain_Grid" style="height: 410px;">
                <div id="tag_srcinner1grid">
                    <div id="txtcon-m_transaction_code" style="margin-top: 08px; width: 40px;">
                        <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                            Width="28px" OnClientClick="EXcel()" />
                    </div>
                    <div id="txtcon-m_transaction_code" style="margin-top: 10px; width: 75px;">
                        <asp:Button ID="btnSend" CssClass="send_btn" Text="Send" runat="server" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="Mail_open();" />
                    </div>
                    <div id="verslic">
                        &nbsp;</div>
                    <div id="txtcon-m_transaction_code" style="margin-top: 10px; width: 620px;">
                        <div id="mainmastop2container_rght_tag2_txt1">
                            <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div id="verslic">
                        &nbsp;</div>
                    <div id="txtcon-m_transaction_code" style="margin-top: 10px; width: 180px;">
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Total Job count :
                            <asp:Literal ID="lblcnt" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>



                <div id="tag_srcinner1grid_table_Container" style="height: 100px; ">
                    <div id="Main_Grid_Container" style="height: 350px;overflow: hidden;"><%--overflow: hidden; --%>


                        <asp:GridView ID="gvdetails" runat="server" Width="140%" CssClass="grid-view"  AutoGenerateColumns="false"  
                            GridLines="None"  OnRowDataBound="gvdetails_RowDataBound">
                            <Columns>

                             <asp:TemplateField HeaderStyle-BackColor="#EFEFEF" ItemStyle-BackColor="#EFEFEF"  >
                                <HeaderTemplate> 
                                    <input type="checkbox" id="cbSelecteds1" /> 
                                </HeaderTemplate> 
                                <ItemTemplate> 
                                    <asp:CheckBox ID="cbSelected1" runat="server" /> 
                                </ItemTemplate> 
                            </asp:TemplateField> 
                            <asp:BoundField HeaderText="File Ref. No" DataField="F_Ref_No"  HeaderStyle-BackColor="#D6D6D6" />
                            <asp:BoundField HeaderText="Job Date" DataField="Job Date" HeaderStyle-BackColor="#D6D6D6" />

                            <asp:BoundField HeaderText="Job No" DataField="Job No"  HeaderStyle-BackColor="#D6D6D6" />

                              <%--  <asp:TemplateField>
                                    <HeaderTemplate>
                                        <input type="checkbox" id="cbSelecteds2" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbSelected2" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>


                                <%--<asp:BoundField HeaderText="Job No" DataField="Job No" />--%>
                              <%--  <asp:BoundField HeaderText="Job Date" DataField="Job Date" />--%>
                                <asp:BoundField HeaderText="Shipper Name" DataField="Shipper Name" HeaderStyle-BackColor="#D6D6D6" />
                                <asp:BoundField HeaderText="Invoice Details" DataField="Invoice Details" HeaderStyle-BackColor="#D6D6D6" />
                                <asp:BoundField HeaderText="No of Pkg" DataField="No of Pkg"  HeaderStyle-BackColor="#D6D6D6"/>
                                <asp:BoundField HeaderText="Port of Discharge" DataField="Port of Discharge" HeaderStyle-BackColor="#D6D6D6" />
                                <asp:BoundField HeaderText="Consignee Name" DataField="Consignee Name" HeaderStyle-BackColor="#D6D6D6" />
                            
                            </Columns>
                            <HeaderStyle CssClass="GridviewScrollHeader" />
                            <RowStyle CssClass="GridviewScrollItem" />
                            <PagerStyle CssClass="GridviewScrollPager" />
                        </asp:GridView> 


                    </div>
                </div>
            </div>
           
           
            <asp:HiddenField ID="hdBranch" runat="server" />
     <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
     
     
    </form>
    <script type="text/javascript">
        var win = null;

        var Exp_name = $('#<%= txt_BL_Expname.ClientID %>').val();

        var Fromdate = $('#<%= txtfromdate.ClientID %>').val();
        var Todate = $('#<%= txttodate.ClientID %>').val();
        var Jobno = $('#<%= txtJobNo.ClientID %>').val();

        var Tr_mode = $('#<%= ddltr_mode.ClientID %>').val();
        var Orderby = $('#<%= ddlorederby.ClientID %>').val();
        

        var Branch = $('#<%= hdBranch.ClientID %>').val();

        var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

        if (lastProductId != 'NO RECORD FOUND') {
            function EXcel() {


                var str = '';
                var value = '1';
           
                    var gv = document.getElementById("gvdetails");
                    for (var i = 0; i < gv.getElementsByTagName("input").length; i++) {
                        var node = gv.getElementsByTagName("input")[i];
                        if (node != null && node.type == "checkbox" && node.checked) {

                            var Grid_Table = document.getElementById('<%= gvdetails.ClientID %>');

                            if (Grid_Table.rows[i].cells[1].textContent == 'File Ref. No') {

                            }
                            else {

                                if (value == '1') {
                                    str = str + Grid_Table.rows[i].cells[1].textContent;
                                    value = "2";
                                }
                                else {
                                    str = str + ',' + Grid_Table.rows[i].cells[1].textContent;
                                    str = str;
                                }
                            
                            }

                          
                       
                        }
                    }
                    if (str != '') {

                        var Type = 'excel';
                        win = window.open('../FlatFile/MIS_report_1.aspx?BL_Pending_Job=Yes&EXP_name=' + Exp_name + '&Jobno=' + Jobno + ' &Fromdate=' + Fromdate + ' &Todate=' + Todate + '   &Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Type=' + Type + '&Excel_jobno=' + str + '&Orderby=' + Orderby + '', 'ndf'); 
                        Loading_HideImage();
                    }


            }

            function Mail_open() {

                var str = '';
                var value = '1';

                var gv = document.getElementById("gvdetails");
                for (var i = 0; i < gv.getElementsByTagName("input").length; i++) {
                    var node = gv.getElementsByTagName("input")[i];
                    if (node != null && node.type == "checkbox" && node.checked) {

                        var Grid_Table = document.getElementById('<%= gvdetails.ClientID %>');

                        if (Grid_Table.rows[i].cells[1].textContent == 'File Ref. No') {

                        }
                        else {

                            if (value == '1') {
                                str = str + Grid_Table.rows[i].cells[1].textContent;
                                value = "2";
                            }
                            else {
                                str = str + ',' + Grid_Table.rows[i].cells[1].textContent;
                                str = str;
                            }

                        }



                    }
                }
                if (str != '') {

                    var Type = 'excel';
                    var w = '700';
                    var h = '800';
                    LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                    TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                    settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                    win = window.open('../Report/Mail_Send.aspx?BL_Pending_Job=Yes&EXP_name=' + Exp_name + '&Jobno=' + Jobno + ' &Fromdate=' + Fromdate + ' &Todate=' + Todate + '   &Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Type=' + Type + '&Excel_jobno=' + str + '&Orderby=' + Orderby + '', 'ndf', settings);
                    win.focus();
                    return false;
                }

            /*
                var Type = 'excel';
                var w = '700';
                var h = '800';
                LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                win = window.open('../Report/Mail_Send.aspx?BL_Pending_Job=Yes&EXP_name=' + Exp_name + '&Jobno=' + Jobno + ' &Fromdate=' + Fromdate + ' &Todate=' + Todate + '   &Tr_mode=' + Tr_mode + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf', settings);
                win.focus();
                return false;
                */

            }

        }

  </script>
      
    <script src="../js/query.js" type="text/javascript"></script>
     <script src="../js/Validation.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
   
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
     <script src="../js/Autotab.js" type="text/javascript"></script>
  
 
<%--<script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
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
                width: 931,
                height: 350,
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

    
   
    <script src="../js/Validation.js" type="text/javascript"></script>
    

    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            document.getElementById("General").click();
        }
        
    </script>
  --%>

  


    <script src="../js/Export_Jscript/EXP_BL_Gird_read.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/EXP_BL_Gird_read_2.js" type="text/javascript"></script>

<script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        gridviewScroll();
    });

    function gridviewScroll() {
        $('#<%=gvdetails.ClientID%>').gridviewScroll({
            width: 931,
            height: 350,
            freezesize: 4
        });

        var cbSelecteds1 = "cbSelecteds1_freezeheader";
        var cbSelected1 = "<%=gvdetails.ClientID%>_cbSelected1";

        CheckBoxCheckAll(cbSelecteds1, cbSelected1);

        var cbSelecteds2 = "cbSelecteds2_Copy";
        var cbSelected2 = "<%=gvdetails.ClientID%>_cbSelected2";

        CheckBoxCheckAll(cbSelecteds2, cbSelected2);
    }

    function CheckBoxCheckAll(checkboxs, checkbox) {
       
        $('#' + checkboxs).change(function () {
            var checked = $(this).is(':checked');
            $('input[id*="' + checkbox + '"]').attr('checked', checked);
        });

        $('input[id*="' + checkbox + '"]').change(function () {
            var checked = $(this).is(':checked');
            if (!checked) {
                $('#' + checkboxs).attr('checked', false);
            }
            else {
                var allchecked = true;
                $('input[id*="' + checkbox + '"]').each(function () {
                    var checked = $(this).is(':checked');
                    if (!checked) {
                        allchecked = false;
                    }
                });
                $('#' + checkboxs).attr('checked', allchecked);
            }
        });
    } 
</script>


   
</body>
</html>
