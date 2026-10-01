<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportSummaryTwo.aspx.cs" Inherits="Summary_Rpt_ImportSummaryTwo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Summary Two </title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <%--<script src="../js/Export_Rpt/BL_Generation.js" type="text/javascript"></script>--%>
    <script src="../js/EGM/EGM_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script type="text/javascript" src="../js/Export_Jscript/Export_General.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 7.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 10em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
    <style type="text/css">
        .txtbox_none_Mid_transac_item_other_rmarks_new1_LC
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            margin-top: 2px;
            width: 385px;
            max-width: 385px;
            height: 350px;
            max-height: 350px;
            border: #c0e4f2 solid thin;
            -moz-border-radius-topleft: 5px;
            -moz-border-radius-topright: 5px;
            -moz-border-radius-bottomleft: 5px;
            -moz-border-radius-bottomright: 5px;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -webkit-border-bottom-right-radius: 5px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            overflow: auto;
        }
    </style>
    

        <script src="../js/js_bootstrap/jquery.min.js" type="text/javascript"></script>
        <link href="../js/js_bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>
        <link href="../js/js_bootstrap/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
        <script src="../js/js_bootstrap/bootstrap-multiselect.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $('[id*=ListBox1]').multiselect({

                includeSelectAllOption: true
            });
        });  
    </script>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Transact_popup_new" style="height: 95px; overflow: visible;
                width: 1150px;">
                <div id="innerbox_MidMain" style="height: 108px; margin-bottom: 0px; overflow: visible;">
                    <div id="tag_srcinner1" style="height: 40px;">
                        <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                            Import Summary Two
                        </div>
                        <div id="verslic">
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                            Group Name
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1" style="width: 360px; margin-top: -1px;">
                            <asp:ListBox ID="ListBox1" SelectionMode="Multiple" Height="28px" runat="server">
                            </asp:ListBox>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1" style="width: 70px;">
                            Category:
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1" style="width: 120px; margin-top: 5px;">
                            <asp:DropDownList ID="ddlrptype" runat="server" AutoPostBack="true" CssClass="listtxt_transac_mode_new"
                                Width="115px" TabIndex="1" OnSelectedIndexChanged="ddlrptype_SelectedIndexChanged">
                                <asp:ListItem Text="Importer Name" Value="Imp_Name"> </asp:ListItem>
                                <asp:ListItem Text="Port" Value="Port"> </asp:ListItem>
                                <asp:ListItem Text="Country" Value="Country"> </asp:ListItem>
                                <asp:ListItem Text="Monthly" Value="Monthly"> </asp:ListItem>
                                <%--<asp:ListItem Text="Quarterly" Value="Quarterly"> </asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                        <div id="popupwindow_closebut_right_new">
                            <input type="button" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                        </div>
                    </div>
                    <div id="tag_transact_src_inner" style="width: 1130px;">
                        <div id="tag_transaction_inner_new" style="margin-left: 0px; width: 1130px; height: 22px;">
                            <div id="tag_Exchange_lft_in1_new1" style="width: 1130px;">
                                <div id="tag_label_transaction_Src_new">
                                    From Date
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 100px;">
                                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                        MaxLength="10" Height="20px" Width="90px" TabIndex="2"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                        PopupButtonID="txtfromdate" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_Src_new" style="width: 50px">
                                    To Date
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 100px;">
                                    <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                        MaxLength="10" Height="20px" Width="90px" TabIndex="3"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                        PopupButtonID="txttodate" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="tag_label_transaction_popup_mode_empty">
                                </div>
                                <div id="tag_label_transaction_Src_new" style="width: 40px;">
                                    Mode
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 80px;">
                                    <asp:DropDownList ID="ddltr_mode" runat="server" CssClass="listtxt_transac_mode_new" TabIndex="4" >
                                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                        <asp:ListItem Text="Air" Value="Air"></asp:ListItem>
                                        <asp:ListItem Text="Sea" Value="Sea"></asp:ListItem>
                                        <asp:ListItem Text="Land" Value="Land"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <%----------------------Search 1-------------------------------%>
                                <div id="EXP_Name" runat="server">
                                    <div id="tag_label_transaction_date">
                                        Importer Name
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 290px;">
                                        <asp:DropDownList ID="ddlImp_name" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                            Width="280px" >
                                        </asp:DropDownList>
                                    </div>
                                   
                                </div>
                                <%----------------------Search 2-------------------------------%>
                                <div id="Country" runat="server">
                                    <div id="tag_label_transaction_date">
                                        Country
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                        <asp:DropDownList ID="ddlcountry" runat="server" CssClass="txtbox_none" Font-Size="12px" Width="200px" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <%-- --------------------Search 3-------------------------------%>
                                <div id="Port" runat="server">
                                    <div id="tag_label_transaction_date">
                                        Port
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                        <asp:DropDownList ID="ddlport" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                            Width="200px">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <%----------------------Search 4-------------------------------%>
                                <div id="Monthly" runat="server">
                                    <div id="tag_label_transaction_date">
                                        Month
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                        <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                            Width="140px" >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <%-- --------------------Search 5-------------------------------%>
                                <div id="Quaterly" runat="server">
                                    <div id="tag_label_transaction_date" style="width: 60px;">
                                        Quarter
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                        <asp:DropDownList ID="ddlquarter" runat="server" CssClass="txtbox_none" Width="280px">
                                            
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <%----------------------Search 6-------------------------------%>
                                <div id="tag_label_transaction_popup_no_empty">
                                </div>

                                 <div id="tag_label_transaction_Src_longlabel" style="">
                                        <div id="small-butt-left">
                                            <a href="#" class="srcbu" id="btnSearch" runat="server" style="margin-top: -5px;"
                                                onserverclick="btnSearch_Click" tabindex="10"></a>
                                        </div>
                                    </div>
                                    <div id="txtcon-m_transaction_mode" style="width: 100px">
                                        <a href="#" style="margin-top: -5px;" class="cancelButt" onclick="win_hide();parent.adcodewindow.hide();return false;"
                                            tabindex="11"></a>
                                    </div>

                            </div>
                            <%----  ROW-4----%>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty" style="padding-left: 300px;">
                        </div>
                        <div id="txtcon-m_transaction_code" style="margin-top: 08px; margin-left: 600px;">
                            <asp:ImageButton ID="btnprint" runat="server" ImageUrl="~/images/print.jpg" Height="28px"
                                Width="28px" OnClientClick="PrintGridData()" />
                            <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                                Width="28px" OnClientClick="EXcel()" />
                            <asp:ImageButton ID="btnpdf" runat="server" ImageUrl="~/images/pdf.jpg" Height="28px"
                                Width="28px" OnClientClick="Pdf()" />
                        </div>
                        <div id="txtcon-m_transaction_code" style="margin-top: 10px; width: 10px;">
                            <asp:Button ID="btnSend" CssClass="send_btn" Text="Send" runat="server" Height="22px"
                                Width="52px" Font-Size="13px" CausesValidation="false" UseSubmitBehavior="false"
                                OnClientClick="Mail_open();" />
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Grid1" style="margin-top: 0px">
                    <div id="tag_srcinner1grid_table_Container" style="margin-top: 0px; width: 800px;">
                        <div id="Main_Grid_Container" style="overflow: scroll; width: 1100px; height: 470px;">
                            <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="True"
                                Width="100%" CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true"
                                OnRowDataBound="gvdetails_RowDataBound" GridLines="None" BorderStyle="Groove"
                                BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                                <AlternatingRowStyle BackColor="White" BorderColor="Black" BorderWidth="1px" />
                                <HeaderStyle Font-Underline="false" ForeColor="Black" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Trans_new" style="height: 450px; width: 1150px;">
                    <iframe scrolling="yes" id="iframe1" runat="server" width="1000px" height="1000px"
                        src="#"></iframe>
                </div>
                <asp:HiddenField ID="Hd_Branch" runat="server" />
                <asp:HiddenField ID="Hd_Working_start" runat="server" />
                <asp:HiddenField ID="Hd_Working_End" runat="server" />
                <asp:HiddenField ID="Hd_Q_Start" runat="server" />
                <asp:HiddenField ID="Hd_Q_End" runat="server" />
                <asp:HiddenField ID="Hd_Select_Item" runat="server" />
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
                                /*alert (lastProductId);*/
                            }
                        }
                    });

                    function gridviewScroll() {
                        gridView1 = $('#<%=gvdetails.ClientID %>').gridviewScroll({

                            width: 946,
                            height: 531,
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
                    function PrintGridData() {
                        var prtGrid = document.getElementById('<%=gvdetails.ClientID %>');
                        var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();
                        if (lastProductId != 'NO RECORD FOUND') {
                            prtGrid.border = 1;

                            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
                            prtwin.moveTo(0, 0);
                            prtwin.resizeTo(screen.width, screen.height - 100);
                            prtwin.document.write(prtGrid.outerHTML);
                            prtwin.document.close();
                            prtwin.focus();
                            prtwin.print();
                            prtwin.close();
                        }
                    }
                </script>
                <script type="text/javascript">

                    var win = null;
                    var TheMonth_Text = '';
                    var TheQuarter_Text = '';

                    var Category = $('#<%= ddlrptype.ClientID %>').val();
                    var Fromdate = $('#<%= txtfromdate.ClientID %>').val();

                    var Todate = $('#<%= txttodate.ClientID %>').val();
                    var Tr_Mode = $('#<%= ddltr_mode.ClientID %>').val();
                    var Exporter_name = $('#<%= ddlImp_name.ClientID %>').val();
                    var Port = $('#<%= ddlport.ClientID %>').val();
                    var Country = $('#<%= ddlcountry.ClientID %>').val();

                    var TheMonth_Value = $('#<%= ddlmonth.ClientID %>').val();

                    var TheQuarter_Start = $('#<%= Hd_Q_Start.ClientID %>').val();
                    var TheQuarter_End = $('#<%= Hd_Q_End.ClientID %>').val();

                    var W_Start_month = $('#<%= Hd_Working_start.ClientID %>').val();
                    var W_End_month = $('#<%= Hd_Working_End.ClientID %>').val();


                    var Branch = $('#<%= Hd_Branch.ClientID %>').val();

                    if (Category == 'Monthly') {
                        var TheMonth = document.getElementById("<%=ddlmonth.ClientID%>");
                        TheMonth_Text = TheMonth.options[TheMonth.selectedIndex].text;
                    }
                    else {
                        TheMonth_Text = '';
                    }

                    if (Category == 'Quarterly') {
                        var TheQuarter = document.getElementById("<%=ddlquarter.ClientID%>");
                        TheQuarter_Text = TheQuarter.options[TheQuarter.selectedIndex].text;
                    }
                    else {
                        TheQuarter_Text = '';
                    }


                    var SelectItem = $('#<%= Hd_Select_Item.ClientID %>').val()

                    var totalRows = $("#<%=gvdetails.ClientID %> tr").length;
                    var lastProductId = $("#<%=gvdetails.ClientID %> tr:last").children("td:first").html();

                    if (lastProductId != 'NO RECORD FOUND') {

                        function EXcel() {
                            var Type = 'excel';
                            win = window.open('../FlatFile/MIS_report_1.aspx?Imp_Summary=Yes&Category=' + Category + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Tr_Mode=' + Tr_Mode + '&Select_Item=' + SelectItem + ' &TheQuarter_Start=' + TheQuarter_Start + ' &TheQuarter_End=' + TheQuarter_End + '  &W_Start_month=' + W_Start_month + ' &W_End_month=' + W_End_month + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf');
                            Loading_HideImage();
                        }

                        function Pdf() {
                            var Type = 'Pdf';
                            win = window.open('../FlatFile/MIS_report_1.aspx?Imp_Summary=Yes&Category=' + Category + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Tr_Mode=' + Tr_Mode + '&Select_Item=' + SelectItem + ' &TheQuarter_Start=' + TheQuarter_Start + ' &TheQuarter_End=' + TheQuarter_End + '  &W_Start_month=' + W_Start_month + ' &W_End_month=' + W_End_month + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf');
                            Loading_HideImage();
                        }

                        function Mail_open() {
                            var Type = 'Pdf';
                            var w = '700';
                            var h = '800';
                            LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
                            TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
                            settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
                            win = window.open('../Report/Mail_Send.aspx?Imp_Summary=Yes&Category=' + Category + '&Fromdate=' + Fromdate + '&Todate=' + Todate + '&Tr_Mode=' + Tr_Mode + '&Select_Item=' + SelectItem + ' &TheQuarter_Start=' + TheQuarter_Start + ' &TheQuarter_End=' + TheQuarter_End + '  &W_Start_month=' + W_Start_month + ' &W_End_month=' + W_End_month + '&Branch=' + Branch + '&Type=' + Type + '', 'ndf', settings);
                            win.focus();

                            return false;
                        }

                    }

                </script>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        body
        {
            font-size: 62.5%;
        }
    </style>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
</body>
</html>
