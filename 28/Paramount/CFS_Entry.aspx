<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CFS_Entry.aspx.cs" Inherits="CFS_entry" %>

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
                        CFS Entry
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
            <div class="content" id="page-1" style="margin-top: -28px; height: 450px;">
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
                       
                    </ol>
                    <div class="content" id="page-6" style="height: 500px;">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px;
                            margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1092px; height: 500px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1092px; height: 100px;">
                                    <%--------------------------------------Row 1-----------------------------------------%>
                                    <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_name" runat="server" Text="Importer Ref"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_CHA_Ref_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="6" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_mbl" runat="server" Text=" 20'"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_twenty_cont" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="7"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_hbl" runat="server" Text="40'"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <%--   <asp:TextBox ID="txt_CHA_Ref_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="20"></asp:TextBox>--%>
                                                <%--<asp:TextBox ID="txt_MBL_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="27"></asp:TextBox>--%>
                                                <asp:TextBox ID="txt_forty_Cont" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="8" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_pkg" runat="server" Text="LCL"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_LCL" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="9" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%--------------------------------------Row 2-----------------------------------------%>
                                    <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_type" runat="server" Text=" FCL"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <%--<asp:TextBox ID="txt_Imp_Ref_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="22"></asp:TextBox>--%>
                                                <asp:TextBox ID="txt_FCL" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="10" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_cnt1" runat="server" Text="Gross Weight"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_Gross_wght" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="11" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_cnt" runat="server" Text="BB"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_BB" runat="server" MaxLength="17" onkeyup="autotab(this);" ClientIDMode="Static"
                                                    onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)" CssClass="txtbox_none_Mid_transac_Inv_No"
                                                    TabIndex="12" ></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%--<div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_grwght" runat="server" Text="Gross Weight"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_Gross_Wgt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="13"></asp:TextBox>
                                                <asp:TextBox ID="txt_CFS_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="13" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    ------------------------------------Row 4---------------------------------------
                                    <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_netwght" runat="server" Text="Net Wgt"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_Pkg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="32"></asp:TextBox>
                                                <asp:TextBox ID="txt_Net_Wgt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="14"></asp:TextBox>
                                                <asp:TextBox ID="txt_Staff_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="14" Visible="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                <asp:Label ID="Lb_rem" runat="server" Text="Remarks"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txt_Pkg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="32"></asp:TextBox>
                                                <asp:TextBox ID="Txt_remarks" runat="server" onkeyup="autotab(this);" ClientIDMode="Static"
                                                    onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)" CssClass="txtbox_none_Mid_transac_Inv_No"
                                                    TabIndex="15"></asp:TextBox>
                                            </div>
                                        </div>--%>
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
                                            <asp:TemplateField HeaderText="CFS Name">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_Cfs_name" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                        Text='<%# Bind("CFS_NAME") %>' Width="150px" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Inv No">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="l1" runat="server"></asp:Label>--%>
                                                    <asp:TextBox ID="txt_txn_inv_no" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                        Text='<%# Bind("TAX_INVOICE_NO") %>' Width="150px"  ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Inv Date">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_inv_dt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                        Text='<%# Bind("TAX_INVOICE_DATE") %>' Width="100px" ></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender30" runat="server" TargetControlID="txt_inv_dt"
                                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                    </cc1:MaskedEditExtender>
                                                    <cc1:CalendarExtender ID="CalendarExtender30" runat="server" TargetControlID="txt_inv_dt"
                                                        Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Inv Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_txv_inv_amt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%# Bind("TAX_INVOICE_AMOUNT") %>'
                                                        Width="150px" ></asp:TextBox>
                                                  
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Storage">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_strg" runat="server" CssClass=" txtbox_trans_exp_drawback" Text='<%# Bind("STORAGE") %>'
                                                        Width="150px"  ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="OOC Date">
                                                <ItemTemplate>
                                                     <asp:TextBox ID="txt_ooc_dt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                            onkeypress="return blockNonNumbers(this, event, true, false);" 
                                                            Text='<%# Bind("OOC_DATE") %>' Width="150px"  ></asp:TextBox>
                                                            <cc1:MaskedEditExtender ID="MaskedEditExtender28" runat="server" TargetControlID="txt_ooc_dt"
                                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                        </cc1:MaskedEditExtender>
                                                        <cc1:CalendarExtender ID="CalendarExtender28" runat="server" TargetControlID="txt_ooc_dt"
                                                            Format="dd/MM/yyyy">
                                                        </cc1:CalendarExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Clearance date">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_clr_dt" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                        Text='<%# Bind("CLEARANCE_DATE") %>' Width="150px" ></asp:TextBox>
                                                    <cc1:MaskedEditExtender ID="MaskedEditExtender31" runat="server" TargetControlID="txt_clr_dt"
                                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                    </cc1:MaskedEditExtender>
                                                    <cc1:CalendarExtender ID="CalendarExtender31" runat="server" TargetControlID="txt_clr_dt"
                                                        Format="dd/MM/yyyy">
                                                    </cc1:CalendarExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="CBM">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_cbm" runat="server" CssClass=" txtbox_trans_exp_drawback" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                        Text='<%# Bind("CBM") %>' Width="150px" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Clearance staff">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_Clear_name" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                        Text='<%# Bind("CLEARANCE_STAFF_NAME") %>' Width="150px"  ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Transporter Name">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_trans_name" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%# Bind("TRANSPORTER_NAME") %>'
                                                        Width="150px"  ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vehicle Type">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_veh_type" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%# Bind("VEHICLE_TYPE") %>'
                                                        Width="150px"  ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Vehicle No">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_veh_no" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                        Text='<%# Bind("VEHICLE_NO") %>' Width="200px" ></asp:TextBox>
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Container No">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txt_Con_no" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                       Text='<%# Bind("CONTAINER_NO") %>' Width="200px" ></asp:TextBox>
                                                </ItemTemplate>
                                                <FooterStyle HorizontalAlign="Right" />
                                                <FooterTemplate>
                                                    <asp:Button ID="ButtonAdd" runat="server" Text="Add New" OnClick="ButtonAdd_Click"
                                                        />
                                                </FooterTemplate>
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
                            TabIndex="32" OnClick="btnNew_Click1" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                            TabIndex="30" OnClick="btnSave_Click" CommandName="s" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate();" TabIndex="30" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="31" CausesValidation="false"
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
                            id="btnCancel" tabindex="33">
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
           <%-- <div class="content" id="page-2">
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;"width: 980px; overflow: hidden;">
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
            </div>--%>
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
        

    </script>
</body>
</html>
