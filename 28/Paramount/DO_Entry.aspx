<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DO_Entry.aspx.cs" Inherits="Do_entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>DO ENTRY</title>
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
    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
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
        .CalendarStyle
        {
            background-color: Crimson;
            color: White;
            border: solid 2px DarkRed;
        }
        .ajax__calendar_header
        {
            background-color: #FBB117;
            color: black;
        }
        .ajax__calendar_footer
        {
            background-color: #FBB117;
            color: black;
        }
    </style>
    <style type="text/css">
        #txt_container_Transact_Main_2
        {
            float: left;
            width: 273px;
            height: 25px;
            margin-top: 5px;
        }
        #tag_label_transact_Src_1
        {
            float: left;
            width: 103px;
            height: 15px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            line-height: 20px;
            text-align: left;
            color: #232323;
        }
        #tag_transact_lft_in_2
        {
            width: 1092px;
            height: 25px;
            float: left;
        }
    </style>
    <script language="javascript">
        function B_G_tab_page2() {

            document.getElementById('page-1').style.display = 'Block';
            document.getElementById('page-2').style.display = 'none';
            document.getElementById('page-3').style.display = 'none';
            document.getElementById('page-4').style.display = 'none';

            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'block';
            document.getElementById("page-8").style.display = 'none';
            document.getElementById("page-9").style.display = 'none';

            document.getElementById("Page_A").className = 'inactive';
            document.getElementById("Page_B").className = 'active';
            document.getElementById("Page_C").className = 'inactive';
            document.getElementById("Page_D").className = 'inactive';

            document.getElementById("txtfocus").focus();
        }
    </script>
    <script language="javascript">
        function B_G_tab_page3() {

            document.getElementById('page-1').style.display = 'Block';
            document.getElementById('page-2').style.display = 'none';
            document.getElementById('page-3').style.display = 'none';
            document.getElementById('page-4').style.display = 'none';

            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'none';
            document.getElementById("page-8").style.display = 'block';
            document.getElementById("page-9").style.display = 'none';

            document.getElementById("Page_A").className = 'inactive';
            document.getElementById("Page_B").className = 'inactive';
            document.getElementById("Page_C").className = 'active';
            document.getElementById("Page_D").className = 'inactive';

            document.getElementById("txtfocus").focus();
        }
    </script>
    <script type="text/javascript">
        function Char_Inv(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
                return false;
            return true;
        }
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
            <div id="innerbox_MidMain" style="height: 30px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                        DO Entry
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 490px;">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            Importer Name</div>
                        <div id="txtcon-m_Exchange">
                            <asp:DropDownList ID="ddlCus_name" CssClass="validate[required]  listtxt_transac_item_gen_notn"
                                Width="370px" runat="server" AutoPostBack="True" TabIndex="1" OnSelectedIndexChanged="ddlCus_name_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 160px;">
                        <div id="tag_label_transact_Src" style="width: 50px;">
                            Job No
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 105px;">
                            <asp:DropDownList ID="ddljobno" CssClass="listtxt_transac_item_gen_notn" Width="100px"
                                AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddljobno_SelectedIndexChanged"
                                TabIndex="2">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 210px;">
                        <div id="tag_label_transact_Src" style="width: 100px;">
                            Manual Job No
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 105px;">
                            <asp:TextBox ID="txt_Manual_Jobno" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="3"></asp:TextBox>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -28px; height: 550px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 500px; width: 1094px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                            id="Page_A" runat="server"><span>General </span></a></li>
                        <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');"
                            id="Page_B" runat="server" visible="false"><span>CFS</span></a></li>
                        <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                            id="Page_C" runat="server" visible="false"><span>AAI</span></a></li>
                        <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                            id="Page_D" runat="server" visible="false"><span>Gen -4 </span></a></li>
                        <div id="tag_label_transact_Src_1" style="margin-top: 5px; width: 70px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ref-Id
                        </div>
                        <div id="tag_label_transact_Src_1" style="margin-top: 5px;">
                            <asp:TextBox ID="txt_Ref_Id" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                Width="100px" ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="4"></asp:TextBox>
                        </div>
                        <div id="tag_label_transact_Src_1" style="margin-top: 5px; width: 100px;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Entry Type
                        </div>
                       <%-- <div id="tag_label_transact_Src_1" style="margin-top: 5px;">
                            <asp:DropDownList ID="ddl_entry_type" CssClass="validate[required]  listtxt_transac_item_gen_notn"
                                Width="120px" runat="server" AutoPostBack="True" TabIndex="5">
                                  <asp:ListItem Text ="" Value=""></asp:ListItem>
                             <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                <asp:ListItem Text="DO" Value="DO"></asp:ListItem>
                                <asp:ListItem Text="CFS" Value="CFS"></asp:ListItem>
                                <asp:ListItem Text="AAI" Value="AAI"></asp:ListItem>
                            </asp:DropDownList>
                        </div>--%>
                    </ol>
                    <div class="content" id="page-6" style="height: 500px;">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px;
                            margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1092px; height: 500px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1092px; height: 500px;">
                                    <%--------------------------------------Row 1-----------------------------------------%>
                                    <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_name" runat="server" Text="Consignee Name"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_Consigee_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="6"></asp:TextBox>
                                                <asp:TextBox ID="txt_CHA_Ref_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="6" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txt_Cha_Ref_Num" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                                    TabIndex="6" Width="150px" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_mbl" runat="server" Text=" MBL No"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_MBL_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="7"></asp:TextBox>
                                                <asp:TextBox ID="txt_twenty_cont" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="7" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txt_no_pkgs" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="7" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_hbl" runat="server" Text="HBL No"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <%--   <asp:TextBox ID="txt_CHA_Ref_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="20"></asp:TextBox>--%>
                                                <%--<asp:TextBox ID="txt_MBL_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="27"></asp:TextBox>--%>
                                                <asp:TextBox ID="txt_HBL_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="8"></asp:TextBox>
                                                <asp:TextBox ID="txt_forty_Cont" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="8" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txt_gros_wght" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="8" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_pkg" runat="server" Text="Packages"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_Pkg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="9"></asp:TextBox>
                                                <asp:TextBox ID="txt_LCL" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="9" Visible="false"></asp:TextBox>
                                                <asp:TextBox ID="txt_Chrg_wght" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="8" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%--------------------------------------Row 2-----------------------------------------%>
                                    <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_type" runat="server" Text=" Mode Type"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <%--<asp:TextBox ID="txt_Imp_Ref_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="22"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddl_Mode_Type" runat="server" CssClass="txtbox_none" TabIndex="10"
                                                    Font-Size="12px" Width="95px">
                                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="LCL" Value="LCL"></asp:ListItem>
                                                    <asp:ListItem Text="FCL" Value="FCL"></asp:ListItem>
                                                    <asp:ListItem Text="Air" Value="Air"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:TextBox ID="txt_FCL" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="10" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_cnt1" runat="server" Text=" 20'F"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_20_F" runat="server" MaxLength="10" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="11"></asp:TextBox>
                                                <asp:TextBox ID="txt_Gross_wght" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="11" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_cnt" runat="server" Text="40'F"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_40_F" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="12"></asp:TextBox>
                                                <asp:TextBox ID="txt_BB" runat="server" MaxLength="17" onkeyup="autotab(this);" ClientIDMode="Static"
                                                    onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)" CssClass="txtbox_none_Mid_transac_Inv_No"
                                                    TabIndex="12" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_grwght" runat="server" Text="Gross Weight"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_Gross_Wgt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="13"></asp:TextBox>
                                               <%-- <asp:TextBox ID="txt_CFS_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="13" Visible="false"></asp:TextBox>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <%--------------------------------------Row 4-----------------------------------------%>
                                    <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_netwght" runat="server" Text="Net Wgt"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <%--<asp:TextBox ID="txt_Pkg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="32"></asp:TextBox>--%>
                                                <asp:TextBox ID="txt_Net_Wgt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="14"></asp:TextBox>
                                               <%-- <asp:TextBox ID="txt_Staff_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="14" Visible="false"></asp:TextBox>--%>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_rem" runat="server" Text="Remarks"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <%--<asp:TextBox ID="txt_Pkg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="32"></asp:TextBox>--%>
                                                <asp:TextBox ID="Txt_remarks" runat="server" onkeyup="autotab(this);" ClientIDMode="Static"
                                                    onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)" CssClass="txtbox_none_Mid_transac_Inv_No"
                                                    TabIndex="15"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_ETA" runat="server" Text="ETA"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <%--<asp:TextBox ID="txt_Pkg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="32"></asp:TextBox>--%>
                                                <asp:TextBox ID="Txt_ETA" runat="server" MaxLength="17"   onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="14"></asp:TextBox>
                                               <%-- <asp:TextBox ID="txt_Staff_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="14" Visible="false"></asp:TextBox>--%>
                                            </div>
                                        </div>
                                        <%--<div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Tax Invoice No
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_tax_inv_no" runat="server" onblur="return ChangeCase(this);"
                                        onkeypress="return Char_Inv(event)" CssClass="txtbox_none_Mid_transac_Inv_No"
                                        TabIndex="33"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Line Charge
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Line_Chg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="35"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Console Charge
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Console_chg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="36"></asp:TextBox>
                                </div>--%>
                                    </div>
                                    <%--</div>--%>
                                    <%--            ------------------------------------Row 5--------------------------------------- 
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Port Storage Amt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_port_Str_amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="37"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Detention Amt
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Detent_Amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="39"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Damage Charges
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txt_dam_chg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="40"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Remarks
                                </div>
                                <div id="txtcon-m_Exchange">
                                     <asp:DropDownList ID="ddl_Mode_Type" runat="server" CssClass="txtbox_none" TabIndex="41" Font-Size="12px"  Width="95px"  >
                                       <asp:ListItem Text="" Value="" ></asp:ListItem>
                                       <asp:ListItem Text="LCL" Value="LCL" ></asp:ListItem>
                                       <asp:ListItem Text="FCL" Value="FCL" ></asp:ListItem>
                                       </asp:DropDownList>
                                       <asp:TextBox ID="Txt_remarks" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="40"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>
                                    <%--  ------------------------------------Row 17---------------------------------------
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1" >
                                  UTR NO
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_H_Over_To_Tr_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="108"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender22" runat="server" TargetControlID="txt_H_Over_To_Tr_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender22" runat="server" TargetControlID="txt_H_Over_To_Tr_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <asp:TextBox ID="txt_UTR_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="110"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   UTR Date
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_PD_Bond_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="110"></asp:TextBox>
                                        <asp:TextBox ID="txt_UTR_date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="108" style="width: 150px;"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender22" runat="server" TargetControlID="txt_UTR_date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender22" runat="server" TargetControlID="txt_UTR_date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 UTR Amount
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_PD_Bond_Debit_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="111"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender23" runat="server" TargetControlID="txt_PD_Bond_Debit_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender23" runat="server" TargetControlID="txt_PD_Bond_Debit_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <asp:TextBox ID="txt_UTR_Amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="110"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    PD Bond Amt
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_PD_Bond_Amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="112"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>
                                    <%-- ------------------------------------Row 18---------------------------------------
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Holding Chq No
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Hold_chq" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="113"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                     Holding Chq Date
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Hold_chq_date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="115" style="width: 150px;"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender24" runat="server" TargetControlID="txt_Hold_chq_date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender24" runat="server" TargetControlID="txt_Hold_chq_date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                              <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Holding Amt
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Hold_amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="113"></asp:TextBox>
                                </div>
                            </div>
                              <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Late Do Fee
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_do_fee" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="113"></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>--%>
                                    <%--------------------------------------Row 20-----------------------------------------%>
                                    <%--          <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Port D/O Revalid
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_port_revalidation" runat="server" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="90"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Deten D/O Revalid
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_detention_revalidation" runat="server" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="92"></asp:TextBox>
                                </div>
                            </div>
                     
                        </div>--%>
                                    <%--------------------------------------Row End-----------------------------------------%>
                                    <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height: 190px; width: 1090px;
                                        overflow: auto;">
                                        <asp:GridView ID="gvAll" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" OnRowCreated="gvAll_RowCreated"
                                            OnRowDataBound="gvAll_RowDataBound" OnRowDeleting="gvAll_RowDeleting" OnRowEditing="gvAll_RowEditing"
                                            PageSize="12" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%">
                                            <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                                            <Columns>
                                                <asp:BoundField DataField="RowNumber" HeaderText="S.No" />
                                                <asp:TemplateField HeaderText="Liner Name">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Line_Name" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                             Text='<%# Bind("Liner_name") %>' Width="100px"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Consol Name" >
                                                    <ItemTemplate>
                                                    <%--<asp:Label ID="l1" runat="server"></asp:Label>--%>
                                                        <asp:TextBox ID="txt_Console_Name" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            Text='<%# Bind("Consol_Name") %>' Width="150px"></asp:TextBox>
                                                        <%--<asp:DropDownList ID="ddl_ContainerNo" runat="server" Width="150px"  TabIndex="21">
                                        </asp:DropDownList>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Consol Charge">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Console_chg" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            Text='<%# Bind("Consol_charges") %>' Width="150px" ></asp:TextBox>
                                                        <%--<asp:DropDownList ID="ddl_ContainerNo" runat="server" Width="150px"  TabIndex="21">
                                        </asp:DropDownList>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Liner Charge">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Line_Chg" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                             Text='<%# Bind("Line_Charge") %>' ></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="DO Free Days">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_do_free_days" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            onkeypress="return blockNonNumbers(this, event, true, false);" 
                                                            Text='<%# Bind("DO_Free_days") %>' Width="150px" ></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Port Storage Amt">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_port_Str_amt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            Text='<%# Bind("Port_Storage_Amt") %>' Width="150px" ></asp:TextBox>
                                                        <%--<asp:DropDownList ID="ddl_ContainerNo" runat="server" Width="150px"  TabIndex="21">
                                        </asp:DropDownList>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Port D/O Revalid">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_port_revalidation" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            onkeypress="return blockNonNumbers(this, event, true, false);" 
                                                            Text='<%# Bind("Port_do_Revalidition") %>' Width="150px" ></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Detention Amt">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Detent_Amt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            Text='<%# Bind("Detention_Amt") %>' Width="150px" ></asp:TextBox>
                                                        <%--<asp:DropDownList ID="ddl_ContainerNo" runat="server" Width="150px"  TabIndex="21">
                                        </asp:DropDownList>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Deten D/O Revalid">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_detention_revalidation" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            onkeypress="return blockNonNumbers(this, event, true, false);" 
                                                            Text='<%# Bind("Detention_do_Revalidition") %>' Width="150px" ></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Damage Charges">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_dam_chg" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            Text='<%# Bind("Damage_Charges") %>' Width="150px"></asp:TextBox>
                                                        <%--<asp:DropDownList ID="ddl_ContainerNo" runat="server" Width="150px"  TabIndex="21">
                                        </asp:DropDownList>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Late Do Fee">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_do_fee" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            onkeypress="return blockNonNumbers(this, event, true, false);" 
                                                            Text='<%# Bind("Late_do_fee") %>' Width="150px" ></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax Invoice No">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_tax_inv_no" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                             Text='<%# Bind("Tax_Invoice_No") %>' Width="250px"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax Invoice Date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Tax_Inv_date" runat="server" CssClass="txtbox_trans_exp_drawback"
                                                            MaxLength="11" Text='<%# Bind("Tax_Invoice_Date") %>' Width="150px" ></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender26" runat="server" TargetControlID="txt_Tax_Inv_date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender26" runat="server" TargetControlID="txt_Tax_Inv_date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Tax Invoice Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_tax_inv_amt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            onkeypress="return blockNonNumbers(this, event, true, false);" 
                                                            Text='<%# Bind("Tax_Invoice_Amount") %>' Width="150px" ></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText=" Holding Chq No">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Hold_chq" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                             Text='<%# Bind("Holding_chq_No") %>' Width="150px" ></asp:TextBox>
                                                        <%--<asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>40</asp:ListItem>
                                            <asp:ListItem>45</asp:ListItem>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Holding Chq Date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Hold_chq_date" runat="server" CssClass="txtbox_trans_exp_drawback"
                                                            MaxLength="11" Text='<%# Bind("Holding_Chq_date") %>' Width="150px" ></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender24" runat="server" TargetControlID="txt_Hold_chq_date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender24" runat="server" TargetControlID="txt_Hold_chq_date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Holding Amt">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Hold_amt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                             Text='<%# Bind("Holding_Amt") %>' Width="150px"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UTR NO">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_UTR_No" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                             Text='<%# Bind("UTR_No") %>' Width="150px" ></asp:TextBox>
                                                        <%--<asp:DropDownList ID="ddl_ContainerNo" runat="server" Width="150px"  TabIndex="21">
                                        </asp:DropDownList>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UTR Date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_UTR_date" runat="server" CssClass="txtbox_trans_exp_drawback"
                                                            MaxLength="11" Text='<%# Bind("UTR_Date") %>' Width="150px" ></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender22" runat="server" TargetControlID="txt_UTR_date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender22" runat="server" TargetControlID="txt_UTR_date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                        <%--<asp:DropDownList ID="ddl_ContainerNo" runat="server" Width="150px"  TabIndex="21">
                                        </asp:DropDownList>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="UTR Amount">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_UTR_Amt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                             Text='<%# Bind("UTR_Amt") %>' Width="150px" ></asp:TextBox>
                                                        <%--<asp:DropDownList ID="ddl_ContainerNo" runat="server" Width="150px"  TabIndex="21">
                                        </asp:DropDownList>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Holding Return Date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Hold_chq_return_date" runat="server" CssClass="txtbox_trans_exp_drawback"
                                                            MaxLength="11" Text='<%# Bind("Holding_chq_return_date") %>' Width="150px" ></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender25" runat="server" TargetControlID="txt_Hold_chq_return_date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender25" runat="server" TargetControlID="txt_Hold_chq_return_date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Holding Received Date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_hold_rec_date" runat="server" CssClass="txtbox_trans_exp_drawback"
                                                            MaxLength="11" Text='<%# Bind("Holding_Received_Date") %>' Width="150px" ></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender27" runat="server" TargetControlID="txt_hold_rec_date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender27" runat="server" TargetControlID="txt_hold_rec_date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                    </ItemTemplate>
                                                    <%--  </asp:TemplateField>--%>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <FooterTemplate>
                                                        <asp:Button ID="ButtonAdd" runat="server" Text="Add New" OnClick="ButtonAdd_Click"
                                                             />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Do_Applied_date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Do_Applied_date" runat="server" CssClass="txtbox_trans_exp_drawback"
                                                            MaxLength="11" Text='<%# Bind("Do_Applied_date") %>' Width="150px" ></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender28" runat="server" TargetControlID="txt_Do_Applied_date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender28" runat="server" TargetControlID="txt_Do_Applied_date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Do_Received_date">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txt_Do_Received_date" runat="server" CssClass="txtbox_trans_exp_drawback"
                                                            MaxLength="11" Text='<%# Bind("Do_Received_date") %>' Width="150px" ></asp:TextBox>
                                                        <cc1:MaskedEditExtender ID="MaskedEditExtender29" runat="server" TargetControlID="txt_Do_Received_date"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender29" runat="server" TargetControlID="txt_Do_Received_date"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowDeleteButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- -----------------------------------------------------------------------------%>
                </div>
                <%-- --------------------Test Start----------------------------%>
                <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="41" OnClick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="39" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="39" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="40" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Invoice?', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="36" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="38">
                        </div>
                        <div id="editbu" style="width: 10px;">
                        </div>
                        <%--<div id="editbu" style="padding-top:5px;">
                            <asp:Button ID="btnrpt" runat="server" tabindex="186" Text="Get Bill" OnClientClick="return GST_Import_Billing_Job_Rpt('B');"  />
                        </div>--%>
                    </div>
                </div>
                <%-- --------------------Test End----------------------------%>
            </div>
            <div class="content" id="page-2">
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                    page-2
                </div>
            </div>
            <div class="content" id="page-3">
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 350px;
                    width: 980px; overflow: hidden;">
                    page-3
                </div>
            </div>
            <div class="content" id="page-4">
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                    page-4
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HD_Showcon" runat="server" />
            <asp:HiddenField ID="hdn_update_Bond" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
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



        $(function () {

            $("[id*=txt_Line_Name]").autocomplete({
                source: function (request, response) {

                    $.ajax({

                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/liner_name",

                        data: "{ 'mail': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txt_Line_Name') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Currency', 'error', 'topRight', true);

                                }

                            }
                            else {

                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);

                                var result = data.d;

                                var stringsearch = "-", str = result;

                                for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                                if (i == 1) {
                                    if (field == 'txt_Line_Name') {
                                        $('#txt_Line_Name').val(result);
                                    }


                                }
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
</body>
</html>
