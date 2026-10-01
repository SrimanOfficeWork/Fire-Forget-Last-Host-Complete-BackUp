<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cus_DSR_Exp_Wrapper.aspx.cs" Inherits="Cus_DSR_Exp_Wrapper" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Exp. DSR</title>
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

<%--    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>--%>
    <script src="../js/EXP_CUS_DSR.js" type="text/javascript"></script>
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
            width: 137px;
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
        #txtcon-m_Exchange_2 {
            width: 115px;
            height: 15px;
            float: left;
        }
        
        
        .txtbox_none_Mid_transac_CUS{

            color:#2b2b2b;
            font-family:Arial,Helvetica,sans-serif;
            font-size:14px;
            height:15px;
            margin-top:1px;
            width:150px;

            text-transform: none;

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
	            overflow:hidden;
            }
    </style> 
    
     <style>
/* ================================================
   Wrapper.aspx — Complete Final CSS
   ================================================ */

/* Type selector wrap container */
.type-selector-wrap {
    display: inline-block;
    position: relative;
}

/* Main Choose type button */
.type-selector-btn {
    height: 22px;
    min-width: 110px;
    border: 1px solid #aaa;
    border-radius: 4px;
    background: #f0f0f0;
    font-size: 11px;
    font-weight: 600;
    color: #444;
    cursor: pointer !important;
    pointer-events: auto !important;
    padding: 0 8px;
    text-align: left;
    white-space: nowrap;
}

/* Button states */
.type-selector-btn.mode-T {
    background:   #f0f0f0;
    color:        #444;
    border-color: #aaa;
}
.type-selector-btn.mode-D {
    background:   #2196F3;
    color:        #fff;
    border-color: #2196F3;
}
.type-selector-btn.mode-DD {
    background:   #FF9800;
    color:        #fff;
    border-color: #FF9800;
}

/* Dropdown menu */
[id^="typemenu_"] {
    pointer-events: auto !important;
    cursor:         pointer !important;
    background:     #fff;
    border:         1px solid #ccc;
    border-radius:  4px;
    box-shadow:     0 2px 8px rgba(0,0,0,0.15);
    min-width:      120px;
    z-index:        999999;
}

/* Menu options T / D / DD */
.type-option {
    padding:       6px 14px;
    font-size:     12px;
    font-weight:   600;
    cursor:        pointer !important;
    color:         #333;
    border-bottom: 1px solid #f0f0f0;
    pointer-events: auto !important;
}
.type-option:last-child {
    border-bottom: none;
}
.type-option:hover {
    background: #f5f5f5;
}

/* DD values panel */
[id^="ddpanel_"] {
    background:    #fff;
    border:        1px solid #FF9800;
    border-radius: 4px;
    padding:       6px 8px;
    box-shadow:    0 2px 6px rgba(0,0,0,0.15);
    z-index:       999998;
}

/* DD values text input */
[id^="ddvalues_"] {
    width:         200px;
    height:        24px;
    font-size:     11px;
    border:        1px solid #FF9800;
    border-radius: 4px;
    padding:       0 6px;
}

/* Status message */
[id^="dmsg_"] {
    display:     none;
    margin-left: 6px;
    font-size:   11px;
    border-radius: 3px;
    padding:     2px 7px;
    white-space: nowrap;
}

/* Label input textbox */
.lbl-input {
    border-right:   none !important;
    border-radius:  4px 0 0 4px !important;
    transition:     border-color 0.2s;
}
.lbl-input.mode-D {
    border:       1.5px solid #2196F3 !important;
    border-right: none !important;
}
.lbl-input.mode-DD {
    border:       1.5px solid #FF9800 !important;
    border-right: none !important;
}

/* Job.aspx date field */
.date-field-active {
    border: 1.5px solid #2196F3 !important;
    color:  #185FA5;
}
</style>       

 <script type="text/javascript">
function Char_Inv(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
        return false;
    return true;
}
</script>

<script type="text/javascript">

    // Toggle type menu open/close
    function toggleTypeMenu(id) {
        var menu = document.getElementById('typemenu_' + id);
        var btn = document.getElementById('typebtn_' + id);
        if (!menu || !btn) return;

        document.querySelectorAll('[id^="typemenu_"]').forEach(function (m) {
            if (m.id !== 'typemenu_' + id) m.style.display = 'none';
        });

        if (menu.style.display === 'none' || menu.style.display === '') {
            var rect = btn.getBoundingClientRect();
            menu.style.position = 'fixed';
            menu.style.top = (rect.bottom + 2) + 'px';
            menu.style.left = rect.left + 'px';
            menu.style.zIndex = '999999';
            menu.style.display = 'block';
            menu.style.background = '#fff';
            menu.style.border = '1px solid #ccc';
            menu.style.borderRadius = '4px';
            menu.style.boxShadow = '0 2px 8px rgba(0,0,0,0.15)';
            menu.style.minWidth = '120px';
            menu.style.cursor = 'pointer';
            menu.style.pointerEvents = 'auto';
        } else {
            menu.style.display = 'none';
        }
    }

    function selectType(id, mode) {
        var menu = document.getElementById('typemenu_' + id);
        var btn = document.getElementById('typebtn_' + id);
        var hd = document.getElementById('hd_isdate_' + id);
        var hdDD = document.getElementById('hd_ddvalues_' + id);
        var panel = document.getElementById('ddpanel_' + id);
        var msg = document.getElementById('dmsg_' + id);
        var ddvals = document.getElementById('ddvalues_' + id);

        if (!btn || !hd) return;

        if (menu) menu.style.display = 'none';

        btn.classList.remove('mode-T', 'mode-D', 'mode-DD');
        if (msg) { msg.style.display = 'none'; msg.innerHTML = ''; }

        btn.setAttribute('data-mode', mode);

        if (mode === 'T') {
            hd.value = 'N';
            if (hdDD) hdDD.value = '';
            btn.innerHTML = 'T &nbsp;&#9660;';
            btn.classList.add('mode-T');
            if (panel) panel.style.display = 'none';
            if (ddvals) ddvals.value = '';

        } else if (mode === 'D') {
            hd.value = 'Y';
            if (hdDD) hdDD.value = '';
            btn.innerHTML = 'D &#8212; Date &nbsp;&#9660;';
            btn.classList.add('mode-D');
            if (panel) panel.style.display = 'none';
            if (msg) {
                msg.style.display = 'inline-block';
                msg.style.color = '#0C447C';
                msg.style.background = '#e3f0ff';
                msg.style.border = '1px solid #90caf9';
                msg.innerHTML = 'Date field enabled';
                setTimeout(function () { msg.style.display = 'none'; msg.innerHTML = ''; }, 2000);
            }

        } else if (mode === 'DD') {
            hd.value = 'D';
            if (hdDD) hdDD.value = ddvals ? ddvals.value : '';
            btn.innerHTML = 'DD &#8212; Dropdown &nbsp;&#9660;';
            btn.classList.add('mode-DD');
            if (panel) {
                var rect = btn.getBoundingClientRect();
                panel.style.position = 'fixed';
                panel.style.top = (rect.bottom + 2) + 'px';
                panel.style.left = rect.left + 'px';
                panel.style.zIndex = '999998';
                panel.style.display = 'block';
            }
            if (msg) {
                msg.style.display = 'inline-block';
                msg.style.color = '#7A4100';
                msg.style.background = '#FFF3E0';
                msg.style.border = '1px solid #FFCC80';
                msg.innerHTML = 'Dropdown field enabled';
                setTimeout(function () { msg.style.display = 'none'; msg.innerHTML = ''; }, 2000);
            }
            if (ddvals && hdDD) {
                ddvals.onkeyup = function () { hdDD.value = ddvals.value; };
                ddvals.oninput = function () { hdDD.value = ddvals.value; };
                ddvals.onchange = function () { hdDD.value = ddvals.value; };
            }
        }
    }

    function closeDDPanel(id) {
        var panel = document.getElementById('ddpanel_' + id);
        if (panel) panel.style.display = 'none';
    }

    // =============================================
    // saveBeforeSubmit — FIXED
    // Call this from your Save button's OnClientClick
    // e.g. OnClientClick="return saveBeforeSubmit();"
    // =============================================
   

    function saveBeforeSubmit() {
        for (var i = 1; i <= 190; i++) {

            var ddvals = document.getElementById('ddvalues_' + i);
            var hdDD = document.getElementById('hd_ddvalues_' + i);
            if (ddvals && hdDD) {
                hdDD.value = ddvals.value;
            }

            // ← REMOVE these 3 alert lines that were here

            var btn = document.getElementById('typebtn_' + i);
            var hd = document.getElementById('hd_isdate_' + i);
            if (btn && hd) {
                var mode = btn.getAttribute('data-mode') || 'T';
                if (mode === 'T') hd.value = 'N';
                if (mode === 'D') hd.value = 'Y';
                if (mode === 'DD') hd.value = 'D';
            }
        }
        return true;
    }
    // Close menus when clicking outside
    document.addEventListener('click', function (e) {
        var insideMenu = e.target.closest('[id^="typemenu_"]');
        var insideBtn = e.target.closest('[id^="typebtn_"]');
        var insideWrap = e.target.closest('.type-selector-wrap');
        if (!insideMenu && !insideBtn && !insideWrap) {
            document.querySelectorAll('[id^="typemenu_"]').forEach(function (m) {
                m.style.display = 'none';
            });
        }
    });

    // Close menus when scrolling
    window.addEventListener('scroll', function () {
        document.querySelectorAll('[id^="typemenu_"]').forEach(function (m) {
            m.style.display = 'none';
        });
    }, true);

</script>




</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"  LoadScriptsBeforeUI="false" EnablePageMethods="true">
  </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain" style=" height: 30px;">
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:190px;">
                      Exp. DSR Screen Creation
                    </div>

                    <div id="mainmastop2container_rght_tag2_txt1">
                      <span style="color:Red;">  <asp:Literal ID="lblmsg" runat="server"></asp:Literal> </span>
                    </div>

                    <div id="popupwindow_closebut_right_new" >
                      <span id="F" runat="server"><input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 
                      <span id="T" runat="server">  <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span> 
                    </div>
           
                </div>
               
                 
                </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>


         <div class="content" id="page-1" style="margin-top:-28px;height:550px;">
                        
          <div id="innerbox_MidMain_Trans_new" style="height:500px; width:1094px; margin-left:-16px; margin-top:-5px;">
           <%--  <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span  style="color: Blue;"> CHA Part I </span></a></li>
                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span style="color: Blue;"> CHA Part II</span></a></li>

                    <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server" >
                        <span >Screen Page I </span></a></li>
                    <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server">
                        <span> Screen Page  II </span></a></li>
                    <li><a href="#page-10" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page5('0');" id="Page_E" runat="server">
                        <span > Screen Page  III </span></a></li>
                </ol>--%>

                 <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span  > CHA Part I </span></a></li>
                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span > CHA Part II</span></a></li>

                          <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server" >
                        <span  > Job & Shipment Details </span></a></li>
                    <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server">
                        <span >  Documentation Dept</span></a></li>
                 <%--   <li><a href="#page-10" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page5('0');" id="Page_E" runat="server">
                        <span  > D/O Team </span></a></li>--%>

                          <li><a href="#page-10" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page5('0');" id="Page_E" runat="server">
                        <span  >  Operation Dept.</span></a></li>

                          <li><a href="#page-11" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page6('0');" id="Page_F" runat="server">
                        <span  >  Accounts Dept. </span></a></li>

                          <li><a href="#page-12" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page7('0');" id="Page_G" runat="server">
                        <span  > Management Control </span></a></li>
                         </ol>
                
                    <div class="content" id="page-6" style="height:500px;" >

                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:500px;margin-top: -16px; margin-left:-18px; color:Red;">
                        <div id="tag_transact_src_inner" style="width: 1092px;height:500px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1092px;height:500px;">
                         <%------------------------------------Row--1-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 File. Ref no  
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_File_Ref_no" runat="server" MaxLength="145" onkeyup="autotab(this);"  Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="15"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Job Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Job_date" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="16"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                Exp. Branch No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Exp_Branch_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="17"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Tr. Mode
                                 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Tr_Mode" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="18"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%------------------------------------Row--2-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   SB Type
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                      <asp:TextBox ID="txt_SB_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="19"></asp:TextBox> 
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Customs House
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Cus_House" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="20"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    AD Code
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_AD_Code" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="21"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Consignee Name
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                     <asp:TextBox ID="txt_Consignee_Name" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="22"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                        <%------------------------------------Row--3-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Consignee Branch No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                     <asp:TextBox ID="txt_Consignee_Branch_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="25"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Country Discharge
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                     <asp:TextBox ID="txt_Country_Discharge" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="26"></asp:TextBox> 
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Port Discharge
                                  
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Port_Discharge" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="27"></asp:TextBox> 
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                               Country Final Dest
                                 
                                </div>
                                <div id="txtcon-m_Exchange_2"> 
                                    <asp:TextBox ID="txt_Country_Final_Dest" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="28"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%------------------------------------Row--4-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                     Port Final Dest
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Port_Final_Dest" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="30"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                        State of Export
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                        <asp:TextBox ID="txt_State_of_Export" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="31"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                        Marks No
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                               <asp:TextBox ID="txt_Marks_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                            Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="32"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                         Type of Exporter
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                               <asp:TextBox ID="txt_Type_of_Exporter" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="34"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                         <%------------------------------------Row--5-------------------------------------------%>
                         <%------------------------------------Row--5-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                     GSTN Type
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                          <asp:TextBox ID="txt_GSTN_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="35"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                         GSTN Id
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                          <asp:TextBox ID="txt_GSTN_Id" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="36"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                        Party Ref No
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                         <asp:TextBox ID="txt_Party_Ref_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="38"></asp:TextBox>
                                    </div>
                                </div>
                              </div> 
                       <%------------------------------------Row--6-------------------------------------------%>
                   
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   Annex Air 
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--4-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Nature of Cargo
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Annex_Air_Nature_Of_Cargo" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="40"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                       Marks No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Annex_Air_Marks_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="42"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Total Pkg
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                      <asp:TextBox ID="txt_Annex_Air_Total_Pkg" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="43"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  
                                   Freight Amt
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                     
                                      <asp:TextBox ID="txt_Annex_Air_Freight_Amt" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="45"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--5-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Insurance Amt
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                     <asp:TextBox ID="txt_Air_Insurance_Amt" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="46"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Gross Weight
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Annex_Air_Gross_Weight" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="48"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Net Weight
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Annex_Air_Net_Wgt" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="50"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Unit Code
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Annex_Air_Gross_Unit_Code" runat="server" MaxLength="145" onkeyup="autotab(this);"  Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="51"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--6-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 MAWB NO
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                <asp:TextBox ID="txt_Annex_Air_MAWB_No" runat="server" MaxLength="145" onkeyup="autotab(this);"  Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="52"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 HAWB NO
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                        <asp:TextBox ID="txt_Annex_Air_HAWB_No" runat="server" MaxLength="145" onkeyup="autotab(this);"  Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="55"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                Rotation No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                <asp:TextBox ID="txt_Annex_Air_Rotation_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="56"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                               Rotation Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                     <asp:TextBox ID="txt_Air_Rotation_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"    CssClass="txtbox_none_Mid_transac_CUS" TabIndex="58"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--7-------------------------------------------%>
                         
                         <%------------------------------------Row--8-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    Annex Sea
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                  
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--10-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Nature of Cargo
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Annex_Sea_Nature_of_Cargo" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="69"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Marks No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Annex_Sea_Marks_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="70"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Total Pkg
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Annex_Sea_Total_Pkg" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="71"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Loose Packets
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Sea_Loose_Packets" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="72"></asp:TextBox>
                                       
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--11-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   No of Containers
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Sea_No_Of_Containers" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="73"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Gross Wgt
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Annex_Sea_Gross_Wgt" runat="server" MaxLength="145" onkeyup="autotab(this);"  Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="74"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Net Weight
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Sea_Net_Weight" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="75"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Unit Measurement
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Sea_Unit_Measurement" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="76"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--12-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Rotation No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Sea_Rotation_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="77"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Rotation Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Sea_Rotation_Date" runat="server" MaxLength="145" onkeyup="autotab(this);"  Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="78"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Seal Type
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Sea_Seal_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="80"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--13-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   Invoice
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--14-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Invoice No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Invoice_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="82"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Invoice Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Invoice_Date" runat="server" MaxLength="145" onkeyup="autotab(this);"  Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="83"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Payment Method
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Payment_Method" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="85"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Invoice Value
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Invoice_Value" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="87"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--15-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Invoice Currency
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Invoice_Currency" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="88"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Invoice Ex.Rate
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Invoice_Ex_Rate" runat="server" MaxLength="145" onkeyup="autotab(this);"  Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="90"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Contract No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Contract_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="91"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Terms
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Terms" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="92"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--16-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Buyer Name
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Buyer_Name" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="94"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Thirdparty Name
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Thirdparty_Name" runat="server" MaxLength="145" onkeyup="autotab(this);"  Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="96"></asp:TextBox>
                                       
                                </div>
                            </div>
                           
                        </div>
                        <%--------------------------------------Row End-----------------------------------------%>
                    </div>
                </div>
                        </div>
                    </div>

                    <div  class="content"  id="page-7"  style="display:none;height:440px;" >

                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:500px;margin-top: -16px; margin-left:-18px; color:Red;">
                        <div id="tag_transact_src_inner" style="width: 1092px;height:500px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1092px;height:500px;">

                    <%--------------------------------------Row -5-----------------------------------------%>
                                   <%--------------------------------------Row 1-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   Item
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 2-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Item Desc.
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Item_Desc" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="100"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  RITC No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_RITC_No" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="102"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Item Qty 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                      <asp:TextBox ID="txt_Item_Qty" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="55px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="103"></asp:TextBox>
                                        
                                     <asp:TextBox ID="txt_Item_Qty_Code" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="45px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="104"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Item Unit Price
                                </div>
                                <div id="txtcon-m_Exchange_2"> 
                                   <asp:TextBox ID="txt_Item_Unit_Price" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="105"></asp:TextBox>
                                       
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 3-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Item Per
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Item_Per" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="106"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Item Amt
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Item_Amt" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="107"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  PMV Value 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Item_PMV_Value" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="108"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Scheme Code
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Item_Scheme_Code" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="109"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 4-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   SB Entry
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                        </div>
       
                     <%-------------------------------------Row 8-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    SB No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_SB_NO" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                    Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="110"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    SB Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_SB_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" Enabled="false"
                                    Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="111"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                     <%-------------------------------------Row 9-------------------------------------------%>
                                 
                                 
                                
                                 <%------------------------------------Row--10-------------------------------------------%>
                                 <%------------------------------------Row--11-------------------------------------------%>
                                 <%------------------------------------Row--12-------------------------------------------%>
                                 <%------------------------------------Row--13-------------------------------------------%>
                                 <%------------------------------------Row--14-------------------------------------------%>
                                 <%------------------------------------Row--15-------------------------------------------%>
                                 <%------------------------------------Row--16-------------------------------------------%>
                                 <%------------------------------------Row--17-------------------------------------------%>
                                 <%------------------------------------Row--18-------------------------------------------%>
                    <%--------------------------------------Row 13-----------------------------------------%>

                     </div>
                      </div>
                       </div>

                       <%--------------------------------lable-----------------------------------------------%>
                    </div>
                    <div  class="content"  id="page-8"  style="display:none;height:440px;">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px;    margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1092px; height: 500px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1092px; height: 500px;">
                       

                       <%--------------------------------------Row 1-----------------------------------------%>
                                 <div id="tag_transact_lft_in_2">
                           <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_1" runat="server" MaxLength="20" onkeyup="autotab(this);" placeholder = "Creaete Ur Lable 1"
                                        Width="130px"   
                                      onblur="Value_Chk('1')"
                                        CssClass="validate[required]  txtbox_none_Mid_transac_CUS" TabIndex="15"></asp:TextBox>
                                </div>
                     <div id="txtcon-m_Exchange_2">
          <div class="type-selector-wrap" id="typewrap_1">
            <button type="button"
                class="type-selector-btn"
                id="typebtn_1"
                data-mode="T"
                onclick="toggleTypeMenu('1')"
                title="Choose type of textbox">
                Choose type &nbsp;&#9660;
            </button>
            <div id="typemenu_1" style="display:none; position:absolute;
                z-index:9999; background:#fff;
                border:1px solid #ccc; border-radius:4px;
                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                min-width:120px;">
                <div class="type-option" onclick="selectType('1','T')">
                    T &nbsp;<span style="color:#888;font-size:10px;">— Text</span>
                </div>
                <div class="type-option" onclick="selectType('1','D')">
                    D &nbsp;<span style="color:#888;font-size:10px;">— Date</span>
                </div>
                <div class="type-option" onclick="selectType('1','DD')">
                    DD &nbsp;<span style="color:#888;font-size:10px;">— Dropdown</span>
                </div>
            </div>
            <div id="ddpanel_1" style="display:none; position:absolute;
                z-index:9998; margin-top:2px; background:#fff;
                border:1px solid #FF9800; border-radius:4px;
                padding:6px 8px;
                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                <div style="display:flex; align-items:center;
                            justify-content:space-between;
                            margin-bottom:4px;">
                    <span style="font-size:11px; color:#888;">
                        Enter values (comma separated):
                    </span>
                    <button type="button"
                        onclick="closeDDPanel('1')"
                        style="background:none; border:none;
                               cursor:pointer; font-size:14px;
                               color:#999; font-weight:700;
                               line-height:1; padding:0 4px;"
                        title="Close">&#x2715;</button>
                </div>
                <input type="text"
                    id="ddvalues_1"
                    placeholder="e.g. Yes,No,Pending"
                    style="width:200px; height:24px; font-size:11px;
                           border:1px solid #FF9800; border-radius:4px;
                           padding:0 6px;" />
            </div>
            <span id="dmsg_1" style="display:none; margin-left:6px;
                font-size:11px; border-radius:3px; padding:2px 7px;
                white-space:nowrap;">
            </span>
            </div>
          <asp:HiddenField ID="hd_isdate_1"   runat="server"
            ClientIDMode="Static" Value="N" />
         <asp:HiddenField ID="hd_ddvalues_1" runat="server"
            ClientIDMode="Static" Value="" />
               </div>
               </div>

                          <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1"> 
                                    <asp:TextBox ID="txt_lbl_2" runat="server" MaxLength="20" onkeyup="autotab(this);" placeholder = "Creaete Ur Lable 2"
                                        Width="130px" 
                                       onblur="Value_Chk('2')"
                                      CssClass="txtbox_none_Mid_transac_CUS" TabIndex="17"></asp:TextBox>
                                </div>

                                   <div id="txtcon-m_Exchange_2">
          <div class="type-selector-wrap" id="typewrap_2">
            <button type="button"
                class="type-selector-btn"
                id="typebtn_2"
                data-mode="T"
                onclick="toggleTypeMenu('2')"
                title="Choose type of textbox">
                Choose type &nbsp;&#9660;
            </button>
            <div id="typemenu_2" style="display:none; position:absolute;
                z-index:9999; background:#fff;
                border:1px solid #ccc; border-radius:4px;
                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                min-width:120px;">
                <div class="type-option" onclick="selectType('2','T')">
                    T &nbsp;<span style="color:#888;font-size:10px;">— Text</span>
                </div>
                <div class="type-option" onclick="selectType('2','D')">
                    D &nbsp;<span style="color:#888;font-size:10px;">— Date</span>
                </div>
                <div class="type-option" onclick="selectType('2','DD')">
                    DD &nbsp;<span style="color:#888;font-size:10px;">— Dropdown</span>
                </div>
            </div>
            <div id="ddpanel_2" style="display:none; position:absolute;
                z-index:9998; margin-top:2px; background:#fff;
                border:1px solid #FF9800; border-radius:4px;
                padding:6px 8px;
                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                <div style="display:flex; align-items:center;
                            justify-content:space-between;
                            margin-bottom:4px;">
                    <span style="font-size:11px; color:#888;">
                        Enter values (comma separated):
                    </span>
                    <button type="button"
                        onclick="closeDDPanel('2')"
                        style="background:none; border:none;
                               cursor:pointer; font-size:14px;
                               color:#999; font-weight:700;
                               line-height:1; padding:0 4px;"
                        title="Close">&#x2715;</button>
                </div>
                <input type="text"
                    id="ddvalues_2"
                    placeholder="e.g. Yes,No,Pending"
                    style="width:200px; height:24px; font-size:11px;
                           border:1px solid #FF9800; border-radius:4px;
                           padding:0 6px;" />
            </div>
            <span id="dmsg_2" style="display:none; margin-left:6px;
                font-size:11px; border-radius:3px; padding:2px 7px;
                white-space:nowrap;">
            </span>
            </div>
          <asp:HiddenField ID="hd_isdate_2"   runat="server"
            ClientIDMode="Static" Value="N" />
         <asp:HiddenField ID="hd_ddvalues_2" runat="server"
            ClientIDMode="Static" Value="" />
               </div>   
                </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_3" runat="server" MaxLength="20" onkeyup="autotab(this);" placeholder = "Creaete Ur Lable 3"
                                        Width="130px"   
                                    onblur="Value_Chk('3')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="20"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
          <div class="type-selector-wrap" id="typewrap_3">
            <button type="button"
                class="type-selector-btn"
                id="typebtn_3"
                data-mode="T"
                onclick="toggleTypeMenu('3')"
                title="Choose type of textbox">
                Choose type &nbsp;&#9660;
            </button>
            <div id="typemenu_3" style="display:none; position:absolute;
                z-index:9999; background:#fff;
                border:1px solid #ccc; border-radius:4px;
                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                min-width:120px;">
                <div class="type-option" onclick="selectType('3','T')">
                    T &nbsp;<span style="color:#888;font-size:10px;">— Text</span>
                </div>
                <div class="type-option" onclick="selectType('3','D')">
                    D &nbsp;<span style="color:#888;font-size:10px;">— Date</span>
                </div>
                <div class="type-option" onclick="selectType('3','DD')">
                    DD &nbsp;<span style="color:#888;font-size:10px;">— Dropdown</span>
                </div>
            </div>
            <div id="ddpanel_3" style="display:none; position:absolute;
                z-index:9998; margin-top:2px; background:#fff;
                border:1px solid #FF9800; border-radius:4px;
                padding:6px 8px;
                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                <div style="display:flex; align-items:center;
                            justify-content:space-between;
                            margin-bottom:4px;">
                    <span style="font-size:11px; color:#888;">
                        Enter values (comma separated):
                    </span>
                    <button type="button"
                        onclick="closeDDPanel('3')"
                        style="background:none; border:none;
                               cursor:pointer; font-size:14px;
                               color:#999; font-weight:700;
                               line-height:1; padding:0 4px;"
                        title="Close">&#x2715;</button>
                </div>
                <input type="text"
                    id="ddvalues_3"
                    placeholder="e.g. Yes,No,Pending"
                    style="width:200px; height:24px; font-size:11px;
                           border:1px solid #FF9800; border-radius:4px;
                           padding:0 6px;" />
            </div>
            <span id="dmsg_3" style="display:none; margin-left:6px;
                font-size:11px; border-radius:3px; padding:2px 7px;
                white-space:nowrap;">
            </span>
            </div>
          <asp:HiddenField ID="hd_isdate_3"   runat="server"
            ClientIDMode="Static" Value="N" />
         <asp:HiddenField ID="hd_ddvalues_3" runat="server"
            ClientIDMode="Static" Value="" />
               </div>
              </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_4" runat="server" MaxLength="20" onkeyup="autotab(this);" placeholder = "Creaete Ur Lable 4"
                                        Width="130px"   onblur="Value_Chk('4')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="22"></asp:TextBox>
                                </div>


                                 <div id="txtcon-m_Exchange_2">
          <div class="type-selector-wrap" id="typewrap_4">
            <button type="button"
                class="type-selector-btn"
                id="typebtn_4"
                data-mode="T"
                onclick="toggleTypeMenu('4')"
                title="Choose type of textbox">
                Choose type &nbsp;&#9660;
            </button>
            <div id="typemenu_4" style="display:none; position:absolute;
                z-index:9999; background:#fff;
                border:1px solid #ccc; border-radius:4px;
                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                min-width:120px;">
                <div class="type-option" onclick="selectType('4','T')">
                    T &nbsp;<span style="color:#888;font-size:10px;">— Text</span>
                </div>
                <div class="type-option" onclick="selectType('4','D')">
                    D &nbsp;<span style="color:#888;font-size:10px;">— Date</span>
                </div>
                <div class="type-option" onclick="selectType('4','DD')">
                    DD &nbsp;<span style="color:#888;font-size:10px;">— Dropdown</span>
                </div>
            </div>
            <div id="ddpanel_4" style="display:none; position:absolute;
                z-index:9998; margin-top:2px; background:#fff;
                border:1px solid #FF9800; border-radius:4px;
                padding:6px 8px;
                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                <div style="display:flex; align-items:center;
                            justify-content:space-between;
                            margin-bottom:4px;">
                    <span style="font-size:11px; color:#888;">
                        Enter values (comma separated):
                    </span>
                    <button type="button"
                        onclick="closeDDPanel('4')"
                        style="background:none; border:none;
                               cursor:pointer; font-size:14px;
                               color:#999; font-weight:700;
                               line-height:1; padding:0 4px;"
                        title="Close">&#x2715;</button>
                </div>
                <input type="text"
                    id="ddvalues_4"
                    placeholder="e.g. Yes,No,Pending"
                    style="width:200px; height:24px; font-size:11px;
                           border:1px solid #FF9800; border-radius:4px;
                           padding:0 6px;" />
            </div>
            <span id="dmsg_4" style="display:none; margin-left:6px;
                font-size:11px; border-radius:3px; padding:2px 7px;
                white-space:nowrap;">
            </span>
            </div>
          <asp:HiddenField ID="hd_isdate_4"   runat="server"
            ClientIDMode="Static" Value="N" />
         <asp:HiddenField ID="hd_ddvalues_4" runat="server"
            ClientIDMode="Static" Value="" />
               </div>         
               </div>
                        </div>




                        <%--------------------------------------Row 2-----------------------------------------%>
                   
                           <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_5" runat="server" MaxLength="20" onkeyup="autotab(this);" 
                                        Width="130px"  onblur="Value_Chk('5')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="25"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
          <div class="type-selector-wrap" id="typewrap_5">
            <button type="button"
                class="type-selector-btn"
                id="typebtn_5"
                data-mode="T"
                onclick="toggleTypeMenu('5')"
                title="Choose type of textbox">
                Choose type &nbsp;&#9660;
            </button>
            <div id="typemenu_5" style="display:none; position:absolute;
                z-index:9999; background:#fff;
                border:1px solid #ccc; border-radius:4px;
                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                min-width:120px;">
                <div class="type-option" onclick="selectType('5','T')">
                    T &nbsp;<span style="color:#888;font-size:10px;">— Text</span>
                </div>
                <div class="type-option" onclick="selectType('5','D')">
                    D &nbsp;<span style="color:#888;font-size:10px;">— Date</span>
                </div>
                <div class="type-option" onclick="selectType('5','DD')">
                    DD &nbsp;<span style="color:#888;font-size:10px;">— Dropdown</span>
                </div>
            </div>
            <div id="ddpanel_5" style="display:none; position:absolute;
                z-index:9998; margin-top:2px; background:#fff;
                border:1px solid #FF9800; border-radius:4px;
                padding:6px 8px;
                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                <div style="display:flex; align-items:center;
                            justify-content:space-between;
                            margin-bottom:4px;">
                    <span style="font-size:11px; color:#888;">
                        Enter values (comma separated):
                    </span>
                    <button type="button"
                        onclick="closeDDPanel('5')"
                        style="background:none; border:none;
                               cursor:pointer; font-size:14px;
                               color:#999; font-weight:700;
                               line-height:1; padding:0 4px;"
                        title="Close">&#x2715;</button>
                </div>
                <input type="text"
                    id="ddvalues_5"
                    placeholder="e.g. Yes,No,Pending"
                    style="width:200px; height:24px; font-size:11px;
                           border:1px solid #FF9800; border-radius:4px;
                           padding:0 6px;" />
            </div>
            <span id="dmsg_5" style="display:none; margin-left:6px;
                font-size:11px; border-radius:3px; padding:2px 7px;
                white-space:nowrap;">
            </span>
            </div>
          <asp:HiddenField ID="hd_isdate_5"   runat="server"
            ClientIDMode="Static" Value="N" />
         <asp:HiddenField ID="hd_ddvalues_5" runat="server"
            ClientIDMode="Static" Value="" />
               </div>
                                


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_6" runat="server" MaxLength="20" onkeyup="autotab(this);" 
                                        Width="130px"  onblur="Value_Chk('6')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="27"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
          <div class="type-selector-wrap" id="typewrap_6">
            <button type="button"
                class="type-selector-btn"
                id="typebtn_6"
                data-mode="T"
                onclick="toggleTypeMenu('6')"
                title="Choose type of textbox">
                Choose type &nbsp;&#9660;
            </button>
            <div id="typemenu_6" style="display:none; position:absolute;
                z-index:9999; background:#fff;
                border:1px solid #ccc; border-radius:4px;
                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                min-width:120px;">
                <div class="type-option" onclick="selectType('6','T')">
                    T &nbsp;<span style="color:#888;font-size:10px;">— Text</span>
                </div>
                <div class="type-option" onclick="selectType('6','D')">
                    D &nbsp;<span style="color:#888;font-size:10px;">— Date</span>
                </div>
                <div class="type-option" onclick="selectType('6','DD')">
                    DD &nbsp;<span style="color:#888;font-size:10px;">— Dropdown</span>
                </div>
            </div>
            <div id="ddpanel_6" style="display:none; position:absolute;
                z-index:9998; margin-top:2px; background:#fff;
                border:1px solid #FF9800; border-radius:4px;
                padding:6px 8px;
                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                <div style="display:flex; align-items:center;
                            justify-content:space-between;
                            margin-bottom:4px;">
                    <span style="font-size:11px; color:#888;">
                        Enter values (comma separated):
                    </span>
                    <button type="button"
                        onclick="closeDDPanel('6')"
                        style="background:none; border:none;
                               cursor:pointer; font-size:14px;
                               color:#999; font-weight:700;
                               line-height:1; padding:0 4px;"
                        title="Close">&#x2715;</button>
                </div>
                <input type="text"
                    id="ddvalues_6"
                    placeholder="e.g. Yes,No,Pending"
                    style="width:200px; height:24px; font-size:11px;
                           border:1px solid #FF9800; border-radius:4px;
                           padding:0 6px;" />
            </div>
            <span id="dmsg_6" style="display:none; margin-left:6px;
                font-size:11px; border-radius:3px; padding:2px 7px;
                white-space:nowrap;">
            </span>
            </div>
          <asp:HiddenField ID="hd_isdate_6"   runat="server"
            ClientIDMode="Static" Value="N" />
         <asp:HiddenField ID="hd_ddvalues_6" runat="server"
            ClientIDMode="Static" Value="" />
               </div>
                 </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_7" runat="server" MaxLength="20" onkeyup="autotab(this);" 
                                        Width="130px"  onblur="Value_Chk('7')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="31"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
          <div class="type-selector-wrap" id="typewrap_7">
            <button type="button"
                class="type-selector-btn"
                id="typebtn_7"
                data-mode="T"
                onclick="toggleTypeMenu('7')"
                title="Choose type of textbox">
                Choose type &nbsp;&#9660;
            </button>
            <div id="typemenu_7" style="display:none; position:absolute;
                z-index:9999; background:#fff;
                border:1px solid #ccc; border-radius:4px;
                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                min-width:120px;">
                <div class="type-option" onclick="selectType('7','T')">
                    T &nbsp;<span style="color:#888;font-size:10px;">— Text</span>
                </div>
                <div class="type-option" onclick="selectType('7','D')">
                    D &nbsp;<span style="color:#888;font-size:10px;">— Date</span>
                </div>
                <div class="type-option" onclick="selectType('7','DD')">
                    DD &nbsp;<span style="color:#888;font-size:10px;">— Dropdown</span>
                </div>
            </div>
            <div id="ddpanel_7" style="display:none; position:absolute;
                z-index:9998; margin-top:2px; background:#fff;
                border:1px solid #FF9800; border-radius:4px;
                padding:6px 8px;
                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                <div style="display:flex; align-items:center;
                            justify-content:space-between;
                            margin-bottom:4px;">
                    <span style="font-size:11px; color:#888;">
                        Enter values (comma separated):
                    </span>
                    <button type="button"
                        onclick="closeDDPanel('7')"
                        style="background:none; border:none;
                               cursor:pointer; font-size:14px;
                               color:#999; font-weight:700;
                               line-height:1; padding:0 4px;"
                        title="Close">&#x2715;</button>
                </div>
                <input type="text"
                    id="ddvalues_7"
                    placeholder="e.g. Yes,No,Pending"
                    style="width:200px; height:24px; font-size:11px;
                           border:1px solid #FF9800; border-radius:4px;
                           padding:0 6px;" />
            </div>
            <span id="dmsg_7" style="display:none; margin-left:6px;
                font-size:11px; border-radius:3px; padding:2px 7px;
                white-space:nowrap;">
            </span>
            </div>
          <asp:HiddenField ID="hd_isdate_7"   runat="server"
            ClientIDMode="Static" Value="N" />
         <asp:HiddenField ID="hd_ddvalues_7" runat="server"
            ClientIDMode="Static" Value="" />
               </div>         
                 </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_8" runat="server" MaxLength="20" onkeyup="autotab(this);" 
                                        Width="130px"   onblur="Value_Chk('8')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="33"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
          <div class="type-selector-wrap" id="typewrap_8">
            <button type="button"
                class="type-selector-btn"
                id="typebtn_8"
                data-mode="T"
                onclick="toggleTypeMenu('8')"
                title="Choose type of textbox">
                Choose type &nbsp;&#9660;
            </button>
            <div id="typemenu_8" style="display:none; position:absolute;
                z-index:9999; background:#fff;
                border:1px solid #ccc; border-radius:4px;
                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                min-width:120px;">
                <div class="type-option" onclick="selectType('8','T')">
                    T &nbsp;<span style="color:#888;font-size:10px;">— Text</span>
                </div>
                <div class="type-option" onclick="selectType('8','D')">
                    D &nbsp;<span style="color:#888;font-size:10px;">— Date</span>
                </div>
                <div class="type-option" onclick="selectType('8','DD')">
                    DD &nbsp;<span style="color:#888;font-size:10px;">— Dropdown</span>
                </div>
            </div>
            <div id="ddpanel_8" style="display:none; position:absolute;
                z-index:9998; margin-top:2px; background:#fff;
                border:1px solid #FF9800; border-radius:4px;
                padding:6px 8px;
                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                <div style="display:flex; align-items:center;
                            justify-content:space-between;
                            margin-bottom:4px;">
                    <span style="font-size:11px; color:#888;">
                        Enter values (comma separated):
                    </span>
                    <button type="button"
                        onclick="closeDDPanel('8')"
                        style="background:none; border:none;
                               cursor:pointer; font-size:14px;
                               color:#999; font-weight:700;
                               line-height:1; padding:0 4px;"
                        title="Close">&#x2715;</button>
                </div>
                <input type="text"
                    id="ddvalues_8"
                    placeholder="e.g. Yes,No,Pending"
                    style="width:200px; height:24px; font-size:11px;
                           border:1px solid #FF9800; border-radius:4px;
                           padding:0 6px;" />
            </div>
            <span id="dmsg_8" style="display:none; margin-left:6px;
                font-size:11px; border-radius:3px; padding:2px 7px;
                white-space:nowrap;">
            </span>
            </div>
          <asp:HiddenField ID="hd_isdate_8"   runat="server"
            ClientIDMode="Static" Value="N" />
         <asp:HiddenField ID="hd_ddvalues_8" runat="server"
            ClientIDMode="Static" Value="" />
               </div>
                  </div>
                        </div>


                        <%--------------------------------------Row 3-----------------------------------------%>

                                <div id="tag_transact_lft_in_2">
                        <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_9" runat="server" MaxLength="20" onkeyup="autotab(this);" 
                                        Width="130px"    onblur="Value_Chk('9')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="36"></asp:TextBox>
                                </div>
                   <div id="txtcon-m_Exchange_2">
          <div class="type-selector-wrap" id="typewrap_9">
            <button type="button"
                class="type-selector-btn"
                id="typebtn_9"

                onclick="toggleTypeMenu('9')"
                title="Choose type of textbox">
                Choose type &nbsp;&#9660;
            </button>

            <div id="typemenu_9" style="display:none; position:absolute;
                z-index:9999; background:#fff;
                border:1px solid #ccc; border-radius:4px;
                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                min-width:120px;">
                <div class="type-option" onclick="selectType('9','T')">
                    T &nbsp;<span style="color:#888;font-size:10px;">— Text</span>
                </div>
                <div class="type-option" onclick="selectType('9','D')">
                    D &nbsp;<span style="color:#888;font-size:10px;">— Date</span>
                </div>
                <div class="type-option" onclick="selectType('9','DD')">
                    DD &nbsp;<span style="color:#888;font-size:10px;">— Dropdown</span>
                </div>
            </div>

            <div id="ddpanel_9" style="display:none; position:absolute;
                z-index:9998; margin-top:2px; background:#fff;
                border:1px solid #FF9800; border-radius:4px;
                padding:6px 8px;
                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                <div style="display:flex; align-items:center;
                            justify-content:space-between;
                            margin-bottom:4px;">
                    <span style="font-size:11px; color:#888;">
                        Enter values (comma separated):
                    </span>
                    <button type="button"
                        onclick="closeDDPanel('9')"
                        style="background:none; border:none;
                               cursor:pointer; font-size:14px;
                               color:#999; font-weight:700;
                               line-height:1; padding:0 4px;"
                        title="Close">&#x2715;</button>
                </div>
                <input type="text"
                    id="ddvalues_9"
                    placeholder="e.g. Yes,No,Pending"
                    style="width:200px; height:24px; font-size:11px;
                           border:1px solid #FF9800; border-radius:4px;
                           padding:0 6px;" />
            </div>

            <span id="dmsg_9" style="margin-left:6px;
                font-size:11px; border-radius:3px; padding:2px 7px;
                white-space:nowrap;">
            </span>
            </div>

          <asp:HiddenField ID="hd_isdate_9"   runat="server"
            ClientIDMode="Static" Value="N" />
         <asp:HiddenField ID="hd_ddvalues_9" runat="server"
            ClientIDMode="Static" Value="" />
               </div>
               </div>

           



                    <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_10" runat="server" MaxLength="20" onkeyup="autotab(this);" 
                                        Width="130px"   onblur="Value_Chk('10')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="39"></asp:TextBox>
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_10">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_10"
                                data-mode="T"
                                onclick="toggleTypeMenu('10')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_10" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('10','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('10','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('10','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_10" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('10')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_10"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_10" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_10"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_10" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_11" runat="server" MaxLength="20" onkeyup="autotab(this);" 
                                        Width="130px"    onblur="Value_Chk('11')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="41"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_11">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_11"
                                data-mode="T"
                                onclick="toggleTypeMenu('11')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_11" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('11','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('11','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('11','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_11" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('11')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_11"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_11" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_11"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_11" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                      


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_12" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('12')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="43"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_12">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_12"
                                data-mode="T"
                                onclick="toggleTypeMenu('12')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_12" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('12','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('12','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('12','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_12" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('12')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_12"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_12" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_12"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_12" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                              



                            </div>


                       
                        <%--------------------------------------Row 4-----------------------------------------%>

                              <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_13" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('13')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="46"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_13">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_13"
                                data-mode="T"
                                onclick="toggleTypeMenu('13')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_13" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('13','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('13','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('13','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_13" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('13')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_13"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_13" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_13"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_13" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_14" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('14')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="48"></asp:TextBox>
                                </div>
                         

                                   <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_14">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_14"
                                data-mode="T"
                                onclick="toggleTypeMenu('14')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_14" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('14','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('14','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('14','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_14" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('14')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_14"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_14" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_14"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_14" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                                </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_15" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('15')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="50"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_15">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_15"
                                data-mode="T"
                                onclick="toggleTypeMenu('15')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_15" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('15','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('15','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('15','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_15" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('15')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_15"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_15" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_15"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_15" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                               


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_16" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('16')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="55"></asp:TextBox>
                                </div>
                              
                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_16">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_16"
                                data-mode="T"
                                onclick="toggleTypeMenu('16')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_16" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('16','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('16','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('16','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_16" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('16')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_16"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_16" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_16"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_16" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            </div>

                        <%--------------------------------------Row 5-----------------------------------------%> 

                               <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_17" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('17')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="57"></asp:TextBox>
                                </div>


                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_17">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_17"
                                data-mode="T"
                                onclick="toggleTypeMenu('17')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_17" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('17','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('17','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('17','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_17" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('17')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_17"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_17" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_17"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_17" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_18" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('18')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="61"></asp:TextBox>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_18">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_18"
                                data-mode="T"
                                onclick="toggleTypeMenu('18')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_18" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('18','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('18','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('18','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_18" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('18')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_18"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_18" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_18"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_18" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_19" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('19')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="63"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_19">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_19"
                                data-mode="T"
                                onclick="toggleTypeMenu('19')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_19" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('19','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('19','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('19','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_19" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('19')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_19"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_19" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_19"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_19" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_20" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('20')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="65"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_20">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_20"
                                data-mode="T"
                                onclick="toggleTypeMenu('20')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_20" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('20','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('20','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('20','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_20" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('20')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_20"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_20" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_20"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_20" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>
                       
                        <%--------------------------------------Row 6-----------------------------------------%>

                          <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_21" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('21')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="67"></asp:TextBox>
                                </div>
                               
                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_21">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_21"
                                data-mode="T"
                                onclick="toggleTypeMenu('21')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_21" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('21','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('21','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('21','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_21" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('21')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_21"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_21" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_21"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_21" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_22" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('22')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="70"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_22">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_22"
                                data-mode="T"
                                onclick="toggleTypeMenu('22')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_22" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('22','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('22','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('22','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_22" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('22')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_22"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_22" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_22"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_22" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>



                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_23" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('23')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="72"></asp:TextBox>
                                </div>
                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_23">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_23"
                                data-mode="T"
                                onclick="toggleTypeMenu('23')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_23" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('23','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('23','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('23','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_23" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('23')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_23"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_23" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_23"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_23" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_24" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('24')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="74"></asp:TextBox>
                                </div>
                               
                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_24">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_24"
                                data-mode="T"
                                onclick="toggleTypeMenu('24')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_24" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('24','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('24','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('24','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_24" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('24')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_24"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_24" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_24"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_24" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>

                         
                        <%--------------------------------------Row 7-----------------------------------------%>
                             <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_25" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('25')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="78"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_25">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_25"
                                data-mode="T"
                                onclick="toggleTypeMenu('25')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_25" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('25','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('25','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('25','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_25" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('25')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_25"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_25" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_25"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_25" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                                
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_26" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('26')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="81"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_26">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_26"
                                data-mode="T"
                                onclick="toggleTypeMenu('26')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_26" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('26','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('26','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('26','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_26" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('26')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_26"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_26" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_26"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_26" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_27" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('27')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="88"></asp:TextBox>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_27">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_27"
                                data-mode="T"
                                onclick="toggleTypeMenu('27')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_27" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('27','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('27','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('27','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_27" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('27')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_27"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_27" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_27"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_27" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_28" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('28')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="90"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_28">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_28"
                                data-mode="T"
                                onclick="toggleTypeMenu('28')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_28" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('28','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('28','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('28','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_28" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('28')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_28"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_28" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_28"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_28" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>



                        <%--------------------------------------Row 8-----------------------------------------%>

                           <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_29" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('29')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="91"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_29">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_29"
                                data-mode="T"
                                onclick="toggleTypeMenu('29')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_29" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('29','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('29','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('29','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_29" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('29')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_29"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_29" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_29"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_29" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_30" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('30')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="93"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_30">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_30"
                                data-mode="T"
                                onclick="toggleTypeMenu('30')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_30" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('30','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('30','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('30','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_30" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('30')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_30"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_30" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_30"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_30" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                              

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_31" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('31')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="95"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_31">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_31"
                                data-mode="T"
                                onclick="toggleTypeMenu('31')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_31" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('31','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('31','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('31','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_31" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('31')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_31"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_31" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_31"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_31" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                              


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_32" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('32')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="97"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_32">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_32"
                                data-mode="T"
                                onclick="toggleTypeMenu('32')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_32" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('32','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('32','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('32','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_32" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('32')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_32"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_32" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_32"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_32" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                              
                            </div>
                        </div>


                        
                        <%--------------------------------------Row 9-----------------------------------------%>
                       

                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_33" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('33')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="101"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_33">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_33"
                                data-mode="T"
                                onclick="toggleTypeMenu('33')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_33" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('33','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('33','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('33','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_33" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('33')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_33"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_33" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_33"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_33" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_34" runat="server" MaxLength="20" onkeyup="autotab(this);" 
                                        Width="130px"  onblur="Value_Chk('34')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="104"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_34">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_34"
                                data-mode="T"
                                onclick="toggleTypeMenu('34')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_34" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('34','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('34','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('34','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_34" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('34')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_34"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_34" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_34"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_34" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_35" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('35')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="106"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_35">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_35"
                                data-mode="T"
                                onclick="toggleTypeMenu('35')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_35" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('35','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('35','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('35','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_35" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('35')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_35"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_35" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_35"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_35" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_36" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('36')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="108"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_36">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_36"
                                data-mode="T"
                                onclick="toggleTypeMenu('36')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_36" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('36','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('36','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('36','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_36" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('36')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_36"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_36" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_36"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_36" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                                



                            </div>
                        </div>



                        <%--------------------------------------Row 10-----------------------------------------%>
                      

                                 <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_37" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('37')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="111"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_37">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_37"
                                data-mode="T"
                                onclick="toggleTypeMenu('37')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_37" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('37','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('37','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('37','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_37" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('37')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_37"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_37" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_37"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_37" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                               
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_38" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('38')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="113"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_38">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_38"
                                data-mode="T"
                                onclick="toggleTypeMenu('38')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_38" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('38','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('38','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('38','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_38" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('38')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_38"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_38" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_38"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_38" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_39" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('39')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="115"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_39">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_39"
                                data-mode="T"
                                onclick="toggleTypeMenu('39')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_39" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('39','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('39','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('39','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_39" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('39')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_39"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_39" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_39"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_39" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_40" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('40')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="117"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_40">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_40"
                                data-mode="T"
                                onclick="toggleTypeMenu('40')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_40" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('40','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('40','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('40','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_40" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('40')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_40"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_40" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_40"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_40" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>

                        <%--------------------------------------Row 11-----------------------------------------%>
                        
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_41" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('41')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="120"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_41">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_41"
                                data-mode="T"
                                onclick="toggleTypeMenu('41')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_41" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('41','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('41','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('41','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_41" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('41')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_41"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_41" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_41"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_41" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                      
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_42" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('42')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="122"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_42">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_42"
                                data-mode="T"
                                onclick="toggleTypeMenu('42')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_42" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('42','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('42','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('42','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_42" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('42')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_42"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_42" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_42"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_42" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_43" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('43')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="126"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_43">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_43"
                                data-mode="T"
                                onclick="toggleTypeMenu('43')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_43" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('43','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('43','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('43','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_43" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('43')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_43"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_43" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_43"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_43" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_44" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('44')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="128"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_44">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_44"
                                data-mode="T"
                                onclick="toggleTypeMenu('44')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_44" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('44','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('44','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('44','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_44" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('44')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_44"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_44" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_44"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_44" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>

                        <%--------------------------------------Row 12-----------------------------------------%>
                        
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_45" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('45')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="131"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_45">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_45"
                                data-mode="T"
                                onclick="toggleTypeMenu('45')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_45" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('45','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('45','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('45','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_45" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('45')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_45"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_45" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_45"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_45" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_46" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('46')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="135"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_46">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_46"
                                data-mode="T"
                                onclick="toggleTypeMenu('46')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_46" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('46','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('46','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('46','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_46" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('46')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_46"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_46" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_46"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_46" runat="server"
                            ClientIDMode="Static" Value="" />
                             </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_47" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('47')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="137"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_47">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_47"
                                data-mode="T"
                                onclick="toggleTypeMenu('47')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_47" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('47','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('47','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('47','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_47" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('47')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_47"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_47" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_47"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_47" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                              
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_48" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('48')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="140"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_48">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_48"
                                data-mode="T"
                                onclick="toggleTypeMenu('48')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_48" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('48','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('48','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('48','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_48" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('48')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_48"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_48" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_48"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_48" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>




                        <%--------------------------------------Row 13-----------------------------------------%>

                          <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_49" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('49')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="142"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_49">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_49"
                                data-mode="T"
                                onclick="toggleTypeMenu('49')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_49" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('49','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('49','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('49','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_49" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('49')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_49"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_49" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_49"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_49" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_50" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('50')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="145"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_50">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_50"
                                data-mode="T"
                                onclick="toggleTypeMenu('50')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_50" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('50','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('50','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('50','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_50" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('50')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_50"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_50" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_50"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_50" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                                
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_51" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('51')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="150"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_51">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_51"
                                data-mode="T"
                                onclick="toggleTypeMenu('51')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_51" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('51','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('51','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('51','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_51" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('51')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_51"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_51" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_51"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_51" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_52" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('52')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="153"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_52">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_52"
                                data-mode="T"
                                onclick="toggleTypeMenu('52')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_52" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('52','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('52','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('52','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_52" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('52')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_52"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_52" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_52"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_52" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                               
                            </div>
                        </div>


                      
                        <%--------------------------------------Row 14-----------------------------------------%>
                     
                          <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_53" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('53')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="155"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_53">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_53"
                                data-mode="T"
                                onclick="toggleTypeMenu('53')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_53" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('53','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('53','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('53','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_53" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('53')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_53"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_53" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_53"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_53" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_54" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('54')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="157"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                                 <div class="type-selector-wrap" id="typewrap_54">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_54"
                                data-mode="T"
                                onclick="toggleTypeMenu('54')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_54" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('54','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('54','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('54','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_54" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('54')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_54"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_54" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_54"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_54" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_55" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('55')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="160"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_55">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_55"
                                data-mode="T"
                                onclick="toggleTypeMenu('55')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_55" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('55','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('55','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('55','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_55" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('55')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_55"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_55" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_55"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_55" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_56" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('56')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="162"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_56">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_56"
                                data-mode="T"
                                onclick="toggleTypeMenu('56')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_56" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('56','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('56','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('56','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_56" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('56')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_56"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_56" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_56"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_56" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>

                        <%--------------------------------------Row 15-----------------------------------------%>
                       
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_57" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('57')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="165"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_57">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_57"
                                data-mode="T"
                                onclick="toggleTypeMenu('57')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_57" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('57','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('57','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('57','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_57" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('57')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_57"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_57" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_57"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_57" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_58" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('58')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="167"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_58">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_58"
                                data-mode="T"
                                onclick="toggleTypeMenu('58')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_58" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('58','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('58','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('58','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_58" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('58')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_58"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_58" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_58"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_58" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">

                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_59" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('59')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="170"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_59">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_59"
                                data-mode="T"
                                onclick="toggleTypeMenu('59')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_59" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('59','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('59','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('59','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_59" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('59')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_59"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_59" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_59"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_59" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_60" runat="server" MaxLength="20" onkeyup="autotab(this);" 
                                        Width="130px"  onblur="Value_Chk('60')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="172"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_60">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_60"
                                data-mode="T"
                                onclick="toggleTypeMenu('60')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_60" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('60','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('60','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('60','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_60" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('60')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_60"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_60" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_60"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_60" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>


                        <%--------------------------------------Row 16-----------------------------------------%>
                      

                        <%--------------------------------------Row 17-----------------------------------------%>
                        
                        



                         <%--------------------------------------Row 18-----------------------------------------%>
                         
                       


                        
                         <%------------------------------------Row--E-------------------------------------------%>
                      
                                </div>
                            </div>
                       </div>
                    </div>
                  <%-----------------------------------page9--------------------------------------------%>
                  <div  class="content"  id="page-9"  style="display:none;height:440px;">
             <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px;    margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1092px; height: 500px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1092px; height: 500px;">
                                <%--------------------------------------Row Start-----------------------------------------%>

                                 <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_61" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('61')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="175"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_61">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_61"
                                data-mode="T"
                                onclick="toggleTypeMenu('61')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_61" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('61','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('61','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('61','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_61" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('61')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_61"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_61" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_61"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_61" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_62" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('62')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="177"></asp:TextBox>
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_62">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_62"
                                data-mode="T"
                                onclick="toggleTypeMenu('62')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_62" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('62','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('62','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('62','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_62" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('62')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_62"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_62" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_62"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_62" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_63" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('63')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="180"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_63">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_63"
                                data-mode="T"
                                onclick="toggleTypeMenu('63')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_63" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('63','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('63','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('63','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_63" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('63')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_63"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_63" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_63"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_63" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_64" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('64')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="182"></asp:TextBox>
                                </div>

                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_64">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_64"
                                data-mode="T"
                                onclick="toggleTypeMenu('64')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_64" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('64','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('64','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('64','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_64" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('64')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_64"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_64" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_64"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_64" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                             

                            </div>
                        </div>

                         <%--------------------------------------Row 1----------------------------------------%>

                                <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_65" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('65')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="186"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_65">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_65"
                                data-mode="T"
                                onclick="toggleTypeMenu('65')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_65" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('65','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('65','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('65','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_65" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('65')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_65"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_65" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_65"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_65" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_66" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('66')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="190"></asp:TextBox>
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_66">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_66"
                                data-mode="T"
                                onclick="toggleTypeMenu('66')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_66" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('66','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('66','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('66','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_66" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('66')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_66"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_66" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_66"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_66" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_67" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('67')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="192"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_67">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_67"
                                data-mode="T"
                                onclick="toggleTypeMenu('67')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_67" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('67','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('67','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('67','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_67" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('67')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_67"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_67" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_67"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_67" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_68" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('68')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="194"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_68">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_68"
                                data-mode="T"
                                onclick="toggleTypeMenu('68')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_68" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('68','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('68','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('68','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_68" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('68')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_68"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_68" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_68"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_68" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>



                                 <%--------------------------------------Row 2----------------------------------------%>
                                 <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_69" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('69')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="196"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_69">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_69"
                                data-mode="T"
                                onclick="toggleTypeMenu('69')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_69" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('69','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('69','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('69','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_69" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('69')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_69"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_69" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_69"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_69" runat="server"
                            ClientIDMode="Static" Value="" />
                            </div>

                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_70" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('70')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="198"></asp:TextBox>
                                </div>
                                 
                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_70">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_70"
                                data-mode="T"
                                onclick="toggleTypeMenu('70')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_70" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('70','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('70','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('70','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_70" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('70')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_70"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_70" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_70"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_70" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_71" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('71')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="201"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_71">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_71"
                                data-mode="T"
                                onclick="toggleTypeMenu('71')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_71" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('71','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('71','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('71','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_71" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('71')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_71"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_71" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_71"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_71" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_72" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('72')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="203"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_72">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_72"
                                data-mode="T"
                                onclick="toggleTypeMenu('72')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_72" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('72','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('72','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('72','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_72" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('72')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_72"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_72" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_72"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_72" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>

                       <%--------------------------------------Row 3-----------------------------------------%>
                
                                <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_73" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('73')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="205"></asp:TextBox>
                                </div>
                              <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_73">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_73"
                                data-mode="T"
                                onclick="toggleTypeMenu('73')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_73" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('73','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('73','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('73','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_73" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('73')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_73"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_73" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_73"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_73" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_74" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('74')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="208"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_74">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_74"
                                data-mode="T"
                                onclick="toggleTypeMenu('74')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_74" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('74','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('74','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('74','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_74" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('74')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_74"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_74" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_74"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_74" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_75" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('75')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="211"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_75">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_75"
                                data-mode="T"
                                onclick="toggleTypeMenu('75')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_75" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('75','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('75','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('75','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_75" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('75')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_75"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_75" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_75"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_75" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_76" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('76')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="215"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_76">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_76"
                                data-mode="T"
                                onclick="toggleTypeMenu('76')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_76" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('76','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('76','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('76','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_76" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('76')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_76"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_76" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_76"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_76" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                        </div>


                    <%--------------------------------------Row 4-----------------------------------------%>
                          <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_77" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('77')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="217"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_77">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_77"
                                data-mode="T"
                                onclick="toggleTypeMenu('77')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_77" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('77','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('77','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('77','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_77" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('77')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_77"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_77" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_77"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_77" runat="server"
                            ClientIDMode="Static" Value="" />
                            </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_78" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('78')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="219"></asp:TextBox>
                                </div>
                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_78">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_78"
                                data-mode="T"
                                onclick="toggleTypeMenu('78')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_78" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('78','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('78','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('78','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_78" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('78')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_78"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_78" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_78"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_78" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_79" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('79')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="222"></asp:TextBox>
                                </div>
                                 
                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_79">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_79"
                                data-mode="T"
                                onclick="toggleTypeMenu('79')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_79" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('79','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('79','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('79','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_79" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('79')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_79"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_79" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_79"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_79" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_80" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('80')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="224"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_80">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_80"
                                data-mode="T"
                                onclick="toggleTypeMenu('80')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_80" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('80','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('80','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('80','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_80" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('80')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_80"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_80" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_80"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_80" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>
                       


                    <%--------------------------------------Row 5-----------------------------------------%>
                      <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_81" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('81')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="226"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_81">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_81"
                                data-mode="T"
                                onclick="toggleTypeMenu('81')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_81" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('81','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('81','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('81','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_81" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('81')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_81"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_81" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_81"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_81" runat="server"
                            ClientIDMode="Static" Value="" />
                            </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_82" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('82')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="228"></asp:TextBox>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_82">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_82"
                                data-mode="T"
                                onclick="toggleTypeMenu('82')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_82" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('82','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('82','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('82','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_82" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('82')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_82"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_82" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_82"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_82" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_83" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('83')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="231"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_83">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_83"
                                data-mode="T"
                                onclick="toggleTypeMenu('83')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_83" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('83','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('83','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('83','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_83" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('83')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_83"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_83" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_83"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_83" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_84" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"     onblur="Value_Chk('84')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="233"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_84">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_84"
                                data-mode="T"
                                onclick="toggleTypeMenu('84')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_84" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('84','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('84','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('84','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_84" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('84')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_84"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_84" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_84"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_84" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>
                   
                    <%--------------------------------------Row 6-----------------------------------------%>
                       
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_85" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('85')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="235"></asp:TextBox>
                                </div>
                              <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_85">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_85"
                                data-mode="T"
                                onclick="toggleTypeMenu('85')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_85" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('85','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('85','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('85','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_85" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('85')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_85"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_85" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_85"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_85" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_86" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('86')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="237"></asp:TextBox>
                                </div>

                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_86">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_86"
                                data-mode="T"
                                onclick="toggleTypeMenu('86')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_86" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('86','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('86','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('86','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_86" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('86')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_86"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_86" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_86"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_86" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                               
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_87" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('87')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="240"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_87">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_87"
                                data-mode="T"
                                onclick="toggleTypeMenu('87')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_87" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('87','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('87','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('87','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_87" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('87')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_87"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_87" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_87"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_87" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_88" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('88')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="242"></asp:TextBox>
                                </div>
                                 
                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_88">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_88"
                                data-mode="T"
                                onclick="toggleTypeMenu('88')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_88" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('88','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('88','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('88','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_88" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('88')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_88"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_88" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_88"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_88" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>



                         
                    <%--------------------------------------Row 7-----------------------------------------%>
                            
                            <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_89" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('89')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="245"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_89">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_89"
                                data-mode="T"
                                onclick="toggleTypeMenu('89')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_89" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('89','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('89','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('89','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_89" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('89')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_89"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_89" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_89"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_89" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_90" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('90')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="248"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_90">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_90"
                                data-mode="T"
                                onclick="toggleTypeMenu('90')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_90" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('90','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('90','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('90','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_90" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('90')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_90"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_90" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_90"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_90" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_91" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('91')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="251"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_91">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_91"
                                data-mode="T"
                                onclick="toggleTypeMenu('91')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_91" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('91','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('91','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('91','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_91" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('91')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_91"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_91" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_91"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_91" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                              
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_92" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('92')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="253"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_92">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_92"
                                data-mode="T"
                                onclick="toggleTypeMenu('92')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_92" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('92','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('92','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('92','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_92" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('92')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_92"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_92" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_92"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_92" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>



                    <%--------------------------------------Row 8-----------------------------------------%>
                       <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_93" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('93')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="255"></asp:TextBox>
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_93">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_93"
                                data-mode="T"
                                onclick="toggleTypeMenu('93')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_93" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('93','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('93','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('93','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_93" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('93')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_93"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_93" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_93"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_93" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_94" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('94')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="258"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_94">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_94"
                                data-mode="T"
                                onclick="toggleTypeMenu('94')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_94" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('94','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('94','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('94','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_94" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('94')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_94"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_94" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_94"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_94" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_95" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('95')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="261"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_95">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_95"
                                data-mode="T"
                                onclick="toggleTypeMenu('95')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_95" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('95','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('95','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('95','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_95" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('95')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_95"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_95" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_95"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_95" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_96" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('96')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="264"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_96">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_96"
                                data-mode="T"
                                onclick="toggleTypeMenu('96')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_96" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('96','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('96','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('96','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_96" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('96')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_96"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_96" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_96"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_96" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>

                            

                    <%--------------------------------------Row 9-----------------------------------------%>
                                <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_97" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('97')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="266"></asp:TextBox>
                                </div>

                            
                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_97">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_97"
                                data-mode="T"
                                onclick="toggleTypeMenu('97')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_97" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('97','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('97','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('97','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_97" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('97')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_97"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_97" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_97"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_97" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_98" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('98')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="268"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_98">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_98"
                                data-mode="T"
                                onclick="toggleTypeMenu('98')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_98" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('98','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('98','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('98','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_98" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('98')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_98"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_98" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_98"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_98" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_99" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('99')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="270"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_99">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_99"
                                data-mode="T"
                                onclick="toggleTypeMenu('99')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_99" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('99','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('99','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('99','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_99" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('99')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_99"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_99" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_99"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_99" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_100" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('100')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="275"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_100">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_100"
                                data-mode="T"
                                onclick="toggleTypeMenu('100')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_100" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('100','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('100','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('100','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_100" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('100')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_100"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_100" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_100"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_100" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                             
                            </div>
                        </div>

                    <%--------------------------------------Row 10-----------------------------------------%>
                     <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_101" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('101')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="277"></asp:TextBox>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_101">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_101"
                                data-mode="T"
                                onclick="toggleTypeMenu('101')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_101" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('101','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('101','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('101','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_101" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('101')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_101"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_101" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_101"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_101" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_102" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('102')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="279"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_102">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_102"
                                data-mode="T"
                                onclick="toggleTypeMenu('102')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_102" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('102','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('102','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('102','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_102" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('102')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_102"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_102" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_102"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_102" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_103" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"    onblur="Value_Chk('103')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="281"></asp:TextBox>
                                </div>
                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_103">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_103"
                                data-mode="T"
                                onclick="toggleTypeMenu('103')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_103" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('103','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('103','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('103','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_103" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('103')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_103"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_103" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_103"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_103" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_104" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('104')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="283"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_104">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_104"
                                data-mode="T"
                                onclick="toggleTypeMenu('104')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_104" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('104','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('104','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('104','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_104" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('104')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_104"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_104" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_104"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_104" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                               
                            </div>

                            </div>

                 
                    
                   <%--------------------------------------Row End-----------------------------------------%>
                        </div>
                        </div>
                        </div>

                  </div>
                    <%-------------------------------------------------------------------------------%>
             
                             

                        <div  class="content"  id="page-10"  style="display:none;height:440px;">
                            <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px;    margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1092px; height: 500px;">
                          <div id="tag_Exchange_inner_lft" style="width: 1092px; height: 500px;">


                             <div id="tag_transact_lft_in_2">
                              <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_105" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('105')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="285"></asp:TextBox>
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_105">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_105"
                                data-mode="T"
                                onclick="toggleTypeMenu('105')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_105" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('105','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('105','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('105','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_105" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('105')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_105"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_105" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_105"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_105" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                          <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_106" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('106')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="290"></asp:TextBox>
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_106">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_106"
                                data-mode="T"
                                onclick="toggleTypeMenu('106')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_106" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('106','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('106','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('106','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_106" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('106')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_106"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_106" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_106"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_106" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                         <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_107" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('107')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="291"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_107">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_107"
                                data-mode="T"
                                onclick="toggleTypeMenu('107')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_107" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('107','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('107','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('107','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_107" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('107')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_107"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_107" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_107"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_107" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                             

                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_108" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('108')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="293"></asp:TextBox>
                                </div>

                           <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_108">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_108"
                                data-mode="T"
                                onclick="toggleTypeMenu('108')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_108" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('108','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('108','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('108','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_108" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('108')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_108"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_108" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_108"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_108" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                        </div>






                           <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_109" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('109')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="295"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_109">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_109"
                                data-mode="T"
                                onclick="toggleTypeMenu('109')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_109" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('109','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('109','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('109','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_109" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('109')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_109"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_109" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_109"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_109" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_110" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('110')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="297"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_110">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_110"
                                data-mode="T"
                                onclick="toggleTypeMenu('110')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_110" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('110','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('110','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('110','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_110" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('110')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_110"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_110" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_110"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_110" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_111" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('111')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="299"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_111">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_111"
                                data-mode="T"
                                onclick="toggleTypeMenu('111')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_111" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('111','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('111','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('111','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_111" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('111')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_111"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_111" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_111"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_111" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_112" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('112')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="301"></asp:TextBox>
                                </div>
                                 
                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_112">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_112"
                                data-mode="T"
                                onclick="toggleTypeMenu('112')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_112" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('112','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('112','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('112','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_112" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('112')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_112"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_112" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_112"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_112" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>

                               

                              <%--------------------------------------8-----------------------------------------%>
                              <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_113" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('113')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="303"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_113">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_113"
                                data-mode="T"
                                onclick="toggleTypeMenu('113')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_113" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('113','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('113','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('113','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_113" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('113')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_113"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_113" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_113"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_113" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_114" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('114')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="305"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_114">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_114"
                                data-mode="T"
                                onclick="toggleTypeMenu('114')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_114" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('114','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('114','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('114','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_114" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('114')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_114"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_114" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_114"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_114" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 <asp:TextBox ID="txt_lbl_115" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('115')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="307"></asp:TextBox>
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_115">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_115"
                                data-mode="T"
                                onclick="toggleTypeMenu('115')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_115" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('115','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('115','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('115','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_115" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('115')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_115"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_115" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_115"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_115" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_116" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('116')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="309"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_116">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_116"
                                data-mode="T"
                                onclick="toggleTypeMenu('116')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_116" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('116','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('116','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('116','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_116" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('116')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_116"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_116" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_116"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_116" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>



                                 <%--------------------------------------8-----------------------------------------%>
                            <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_117" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('117')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="311"></asp:TextBox>
                                </div>

                             <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_117">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_117"
                                data-mode="T"
                                onclick="toggleTypeMenu('117')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_117" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('117','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('117','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('117','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_117" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('117')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_117"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_117" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_117"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_117" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_118" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('118')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="312"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_118">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_118"
                                data-mode="T"
                                onclick="toggleTypeMenu('118')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_118" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('118','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('118','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('118','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_118" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('118')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_118"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_118" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_118"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_118" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_119" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('119')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="314"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_119">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_119"
                                data-mode="T"
                                onclick="toggleTypeMenu('119')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_119" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('119','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('119','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('119','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_119" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('119')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_119"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_119" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_119"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_119" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_120" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('120')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="316"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_120">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_120"
                                data-mode="T"
                                onclick="toggleTypeMenu('120')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_120" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('120','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('120','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('120','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_120" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('120')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_120"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_120" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_120"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_120" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                                
                            </div>
                        </div>





                          <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_121" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('121')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="318"></asp:TextBox>
                                </div>
                                  
                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_121">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_121"
                                data-mode="T"
                                onclick="toggleTypeMenu('121')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_121" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('121','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('121','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('121','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_121" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('121')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_121"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_121" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_121"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_121" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_122" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('122')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="320"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_122">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_122"
                                data-mode="T"
                                onclick="toggleTypeMenu('122')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_122" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('122','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('122','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('122','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_122" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('122')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_122"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_122" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_122"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_122" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_123" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('123')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="322"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_123">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_123"
                                data-mode="T"
                                onclick="toggleTypeMenu('123')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_123" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('123','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('123','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('123','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_123" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('123')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_123"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_123" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_123"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_123" runat="server"
                            ClientIDMode="Static" Value="" />
                            </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_124" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('124')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="324"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_124">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_124"
                                data-mode="T"
                                onclick="toggleTypeMenu('124')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_124" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('124','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('124','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('124','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_124" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('124')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_124"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_124" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_124"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_124" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                           
                            </div>
                        </div>

                    
                      <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_125" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('125')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="326"></asp:TextBox> 
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_125">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_125"
                                data-mode="T"
                                onclick="toggleTypeMenu('125')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_125" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('125','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('125','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('125','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_125" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('125')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_125"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_125" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_125"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_125" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_126" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('126')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="328"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_126">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_126"
                                data-mode="T"
                                onclick="toggleTypeMenu('126')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_126" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('126','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('126','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('126','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_126" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('126')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_126"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_126" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_126"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_126" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                              
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_127" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('127')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="330"></asp:TextBox>
                                </div>


                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_127">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_127"
                                data-mode="T"
                                onclick="toggleTypeMenu('127')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_127" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('127','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('127','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('127','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_127" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('127')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_127"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_127" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_127"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_127" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_128" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('128')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="332"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_128">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_128"
                                data-mode="T"
                                onclick="toggleTypeMenu('128')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_128" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('128','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('128','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('128','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_128" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('128')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_128"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_128" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_128"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_128" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>



                            </div>
                        </div>


           
                   
                            <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_129" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('129')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="334"></asp:TextBox>
                                        
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_129">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_129"
                                data-mode="T"
                                onclick="toggleTypeMenu('129')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_129" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('129','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('129','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('129','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_129" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('129')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_129"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_129" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_129"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_129" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                              
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_130" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('130')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="336"></asp:TextBox>
                                </div>
                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_130">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_130"
                                data-mode="T"
                                onclick="toggleTypeMenu('130')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_130" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('130','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('130','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('130','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_130" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('130')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_130"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_130" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_130"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_130" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_131" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('131')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="338"></asp:TextBox>

                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_131">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_131"
                                data-mode="T"
                                onclick="toggleTypeMenu('131')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_131" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('131','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('131','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('131','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_131" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('131')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_131"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_131" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_131"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_131" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_132" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('132')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="340"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_132">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_132"
                                data-mode="T"
                                onclick="toggleTypeMenu('132')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_132" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('132','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('132','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('132','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_132" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('132')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_132"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_132" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_132"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_132" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                        </div>
            
                    
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_133" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('133')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="342"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_133">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_133"
                                data-mode="T"
                                onclick="toggleTypeMenu('133')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_133" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('133','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('133','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('133','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_133" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('133')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_133"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_133" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_133"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_133" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_134" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('134')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="344"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_134">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_134"
                                data-mode="T"
                                onclick="toggleTypeMenu('134')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_134" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('134','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('134','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('134','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_134" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('134')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_134"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_134" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_134"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_134" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_135" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('135')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="346"></asp:TextBox>
                                        
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_135">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_135"
                                data-mode="T"
                                onclick="toggleTypeMenu('135')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_135" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('135','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('135','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('135','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_135" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('135')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_135"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_135" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_135"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_135" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                             
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_136" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('136')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="348"></asp:TextBox>
                                </div>

                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_136">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_136"
                                data-mode="T"
                                onclick="toggleTypeMenu('136')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_136" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('136','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('136','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('136','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_136" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('136')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_136"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_136" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_136"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_136" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                        </div>




                    
                    
                              <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_137" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('137')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="350"></asp:TextBox>   
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_137">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_137"
                                data-mode="T"
                                onclick="toggleTypeMenu('137')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_137" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('137','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('137','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('137','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_137" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('137')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_137"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_137" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_137"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_137" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_138" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('138')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="352"></asp:TextBox>
                                </div>

                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_138">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_138"
                                data-mode="T"
                                onclick="toggleTypeMenu('138')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_138" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('138','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('138','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('138','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_138" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('138')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_138"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_138" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_138"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_138" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_139" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('139')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="354"></asp:TextBox> 
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_139">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_139"
                                data-mode="T"
                                onclick="toggleTypeMenu('139')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_139" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('139','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('139','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('139','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_139" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('139')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_139"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_139" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_139"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_139" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_140" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('140')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="356"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_140">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_140"
                                data-mode="T"
                                onclick="toggleTypeMenu('140')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_140" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('140','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('140','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('140','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_140" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('140')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_140"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_140" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_140"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_140" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>


                               <%--------------------------------------1-----------------------------------------%>
                    
                       
                              <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_141" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('141')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="358"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_141">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_141"
                                data-mode="T"
                                onclick="toggleTypeMenu('141')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_141" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('141','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('141','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('141','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_141" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('141')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_141"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_141" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_141"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_141" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_142" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('142')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="360"></asp:TextBox>
                                </div>

                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_142">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_142"
                                data-mode="T"
                                onclick="toggleTypeMenu('142')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_142" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('142','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('142','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('142','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_142" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('142')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_142"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_142" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_142"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_142" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_143" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('143')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="362"></asp:TextBox>
                                        
                                </div>
                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_143">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_143"
                                data-mode="T"
                                onclick="toggleTypeMenu('143')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_143" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('143','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('143','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('143','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_143" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('143')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_143"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_143" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_143"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_143" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_144" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('144')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="364"></asp:TextBox>
                                </div>
                                    
                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_144">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_144"
                                data-mode="T"
                                onclick="toggleTypeMenu('144')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_144" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('144','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('144','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('144','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_144" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('144')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_144"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_144" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_144"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_144" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>


                           <%--------------------------------------1-----------------------------------------%>

                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_145" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('145')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="366"></asp:TextBox>  
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_145">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_145"
                                data-mode="T"
                                onclick="toggleTypeMenu('145')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_145" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('145','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('145','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('145','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_145" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('145')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_145"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_145" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_145"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_145" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_146" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('146')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="368"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_146">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_146"
                                data-mode="T"
                                onclick="toggleTypeMenu('146')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_146" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('146','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('146','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('146','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_146" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('146')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_146"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_146" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_146"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_146" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_147" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('147')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="370"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_147">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_147"
                                data-mode="T"
                                onclick="toggleTypeMenu('147')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_147" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('147','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('147','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('147','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_147" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('147')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_147"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_147" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_147"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_147" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_148" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('148')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="372"></asp:TextBox>
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_148">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_148"
                                data-mode="T"
                                onclick="toggleTypeMenu('148')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_148" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('148','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('148','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('148','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_148" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('148')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_148"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_148" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_148"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_148" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                        </div>


                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_149" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('149')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="374"></asp:TextBox>
                                </div>
                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_149">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_149"
                                data-mode="T"
                                onclick="toggleTypeMenu('149')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_149" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('149','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('149','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('149','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_149" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('149')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_149"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_149" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_149"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_149" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_150" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('150')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="376"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_150">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_150"
                                data-mode="T"
                                onclick="toggleTypeMenu('150')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_150" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('150','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('150','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('150','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_150" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('150')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_150"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_150" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_150"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_150" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_151" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('151')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="378"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_151">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_151"
                                data-mode="T"
                                onclick="toggleTypeMenu('151')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_151" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('151','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('151','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('151','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_151" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('151')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_151"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_151" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_151"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_151" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_152" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('152')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="380"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_152">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_152"
                                data-mode="T"
                                onclick="toggleTypeMenu('152')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_152" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('152','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('152','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('152','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_152" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('152')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_152"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_152" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_152"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_152" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>

                           <%-------------------------------------row-----------------------------------------%>
                     

                            <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_153" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('153')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="382"></asp:TextBox>
                                </div>
                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_153">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_153"
                                data-mode="T"
                                onclick="toggleTypeMenu('153')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_153" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('153','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('153','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('153','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_153" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('153')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_153"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_153" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_153"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_153" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_154" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('154')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="384"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_154">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_154"
                                data-mode="T"
                                onclick="toggleTypeMenu('154')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_154" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('154','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('154','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('154','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_154" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('154')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_154"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_154" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_154"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_154" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_155" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('155')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="386"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_155">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_155"
                                data-mode="T"
                                onclick="toggleTypeMenu('155')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_155" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('155','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('155','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('155','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_155" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('155')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_155"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_155" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_155"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_155" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                              
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_156" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('156')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="388"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_156">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_156"
                                data-mode="T"
                                onclick="toggleTypeMenu('156')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_156" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('156','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('156','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('156','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_156" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('156')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_156"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_156" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_156"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_156" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>

                           <%-------------------------------------row-----------------------------------------%>
              
                              <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_157" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('157')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="390"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_157">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_157"
                                data-mode="T"
                                onclick="toggleTypeMenu('157')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_157" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('157','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('157','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('157','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_157" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('157')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_157"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_157" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_157"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_157" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_158" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('158')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="392"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_158">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_158"
                                data-mode="T"
                                onclick="toggleTypeMenu('158')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_158" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('158','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('158','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('158','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_158" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('158')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_158"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_158" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_158"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_158" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_159" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('159')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="394"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_159">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_159"
                                data-mode="T"
                                onclick="toggleTypeMenu('159')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_159" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('159','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('159','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('159','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_159" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('159')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_159"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_159" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_159"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_159" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_160" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('160')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="396"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_160">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_160"
                                data-mode="T"
                                onclick="toggleTypeMenu('160')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_160" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('160','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('160','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('160','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_160" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('160')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_160"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_160" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_160"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_160" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>
                   
                      <%-------------------------------------row-----------------------------------------%>
       

                               <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_161" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('161')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="398"></asp:TextBox> 
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_161">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_161"
                                data-mode="T"
                                onclick="toggleTypeMenu('161')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_161" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('161','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('161','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('161','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_161" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('161')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_161"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_161" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_161"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_161" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_162" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('162')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="400"></asp:TextBox>
                                </div>


                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_162">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_162"
                                data-mode="T"
                                onclick="toggleTypeMenu('162')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_162" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('162','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('162','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('162','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_162" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('162')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_162"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_162" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_162"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_162" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_163" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('163')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="402"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_163">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_163"
                                data-mode="T"
                                onclick="toggleTypeMenu('163')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_163" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('163','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('163','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('163','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_163" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('163')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_163"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_163" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_163"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_163" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                             


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_164" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('164')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="404"></asp:TextBox>
                                </div>


                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_164">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_164"
                                data-mode="T"
                                onclick="toggleTypeMenu('164')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_164" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('164','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('164','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('164','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_164" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('164')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_164"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_164" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_164"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_164" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                        </div>

                             
                                <%-------------------------------------row-----------------------------------------%>

                            <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_165" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('165')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="406"></asp:TextBox>   
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_165">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_165"
                                data-mode="T"
                                onclick="toggleTypeMenu('165')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_165" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('165','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('165','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('165','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_165" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('165')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_165"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_165" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_165"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_165" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_166" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('166')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="408"></asp:TextBox>
                                </div>


                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_166">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_166"
                                data-mode="T"
                                onclick="toggleTypeMenu('166')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_166" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('166','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('166','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('166','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_166" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('166')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_166"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_166" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_166"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_166" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_167" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('168')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="410"></asp:TextBox>
                                </div>
                             
                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_167">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_167"
                                data-mode="T"
                                onclick="toggleTypeMenu('167')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_167" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('167','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('167','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('167','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_167" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('167')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_167"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_167" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_167"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_167" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_168" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('169')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="412"></asp:TextBox>
                                </div>

                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_168">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_168"
                                data-mode="T"
                                onclick="toggleTypeMenu('168')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_168" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('168','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('168','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('168','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_168" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('168')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_168"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_168" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_168"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_168" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>

                           <%-------------------------------------row-----------------------------------------%>
                      
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_169" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('170')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="414"></asp:TextBox>
                                        
                                </div>

                              <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_169">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_169"
                                data-mode="T"
                                onclick="toggleTypeMenu('169')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_169" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('169','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('169','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('169','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_169" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('169')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_169"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_169" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_169"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_169" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_170" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('171')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="416"></asp:TextBox>
                                </div>

                                    <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_170">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_170"
                                data-mode="T"
                                onclick="toggleTypeMenu('170')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_170" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('170','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('170','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('170','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_170" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('170')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_170"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_170" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_170"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_170" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_171" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('172')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="418"></asp:TextBox>
                                        
                                </div>

                                   <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_171">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_171"
                                data-mode="T"
                                onclick="toggleTypeMenu('171')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_171" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('171','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('171','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('171','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_171" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('171')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_171"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_171" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_171"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_171" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                             


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_172" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('173')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="420"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_172">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_172"
                                data-mode="T"
                                onclick="toggleTypeMenu('172')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_172" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('172','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('172','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('172','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_172" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('172')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_172"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_172" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_172"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_172" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>

         
                          </div>
                        </div>
                        </div>





                        </div>

                      



                         <div  class="content"  id="page-11"  style="display:none;height:440px;">

                          <%-------------------------------------153 to 172  resited in  that part before-----------------------------------------%>
                             
                      <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px;    margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1092px; height: 500px;">
                            
                            <div id="tag_Exchange_inner_lft" style="width: 1092px; height: 500px;">

                                <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_173" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('174')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="422"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_173">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_173"
                                data-mode="T"
                                onclick="toggleTypeMenu('173')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_173" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('173','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('173','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('173','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_173" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('173')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_173"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_173" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_173"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_173" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_174" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('175')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="424"></asp:TextBox>
                                </div>

                           
                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_174">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_174"
                                data-mode="T"
                                onclick="toggleTypeMenu('174')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_174" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('174','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('174','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('174','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_174" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('174')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_174"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_174" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_174"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_174" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_175" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('176')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="426"></asp:TextBox>
                                        
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_175">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_175"
                                data-mode="T"
                                onclick="toggleTypeMenu('175')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_175" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('175','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('175','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('175','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_175" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('175')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_175"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_175" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_175"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_175" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_176" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('177')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="428"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_176">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_176"
                                data-mode="T"
                                onclick="toggleTypeMenu('176')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_176" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('176','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('176','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('176','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_176" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('176')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_176"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_176" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_176"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_176" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                        </div>
                    


                             
                             <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_177" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('178')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="430"></asp:TextBox>
                                </div>
                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_177">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_177"
                                data-mode="T"
                                onclick="toggleTypeMenu('177')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_177" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('177','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('177','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('177','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_177" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('177')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_177"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_177" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_177"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_177" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
 

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_178" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('179')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="432"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_178">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_178"
                                data-mode="T"
                                onclick="toggleTypeMenu('178')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_178" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('178','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('178','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('178','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_178" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('178')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_178"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_178" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_178"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_178" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_179" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('180')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="434"></asp:TextBox>
                                        
                                </div>


                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_179">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_179"
                                data-mode="T"
                                onclick="toggleTypeMenu('179')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_179" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('179','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('179','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('179','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_179" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('179')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_179"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_179" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_179"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_179" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_180" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('181')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="436"></asp:TextBox>
                                </div>

                                  
                                   <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_180">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_180"
                                data-mode="T"
                                onclick="toggleTypeMenu('180')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_180" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('180','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('180','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('180','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_180" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('180')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_180"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_180" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_180"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_180" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                               
                            </div>
                        </div>



                            
                                               <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_181" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('182')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="438"></asp:TextBox>
                                        
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_181">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_181"
                                data-mode="T"
                                onclick="toggleTypeMenu('181')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_181" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('181','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('181','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('181','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_181" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('181')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_181"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_181" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_181"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_181" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_182" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('183')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="440"></asp:TextBox>
                                </div>


                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_182">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_182"
                                data-mode="T"
                                onclick="toggleTypeMenu('182')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_182" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('182','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('182','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('182','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_182" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('182')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_182"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_182" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_182"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_182" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                              

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_183" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('184')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="442"></asp:TextBox>
                                        
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_183">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_183"
                                data-mode="T"
                                onclick="toggleTypeMenu('183')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_183" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('183','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('183','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('183','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_183" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('183')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_183"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_183" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_183"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_183" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_184" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('185')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="444"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_184">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_184"
                                data-mode="T"
                                onclick="toggleTypeMenu('184')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_184" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('184','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('184','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('184','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_184" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('184')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_184"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_184" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_184"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_184" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>
                           

                               
                               <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_185" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('185')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="446"></asp:TextBox>
                                        
                                </div>

                             <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_185">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_185"
                                data-mode="T"
                                onclick="toggleTypeMenu('185')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_185" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('185','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('185','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('185','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_185" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('185')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_185"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_185" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_185"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_185" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_186" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('186')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="448"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_186">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_186"
                                data-mode="T"
                                onclick="toggleTypeMenu('186')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_186" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('186','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('186','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('186','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_186" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('186')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_186"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_186" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_186"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_186" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

         
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_187" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('187')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="450"></asp:TextBox>
                                        
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_187">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_187"
                                data-mode="T"
                                onclick="toggleTypeMenu('187')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_187" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('187','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('187','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('187','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_187" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('187')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_187"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_187" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_187"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_187" runat="server"
                            ClientIDMode="Static" Value="" />
                          
                            </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_188" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('188')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="452"></asp:TextBox>
                                </div>

                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_188">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_188"
                                data-mode="T"
                                onclick="toggleTypeMenu('188')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_188" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('188','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('188','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('188','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_188" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('188')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_188"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_188" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_188"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_188" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>

                            
                           
                            <div id="tag_transact_lft_in_2">
                           <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_189" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('189')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="454"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_189">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_189"
                                data-mode="T"
                                onclick="toggleTypeMenu('189')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_189" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('189','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('189','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('189','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_189" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('189')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_189"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_189" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_189"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_189" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>


                         <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_190" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('190')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="456"></asp:TextBox>
                                </div>

                               <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_190">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_190"
                                data-mode="T"
                                onclick="toggleTypeMenu('190')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_190" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('190','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('190','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('190','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_190" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('190')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_190"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_190" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_190"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_190" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_191" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('190')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="458"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_191">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_191"
                                data-mode="T"
                                onclick="toggleTypeMenu('191')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_191" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('191','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('191','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('191','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_191" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('191')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_191"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_191" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_191"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_191" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                               

                            </div>



                             <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_192" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('190')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="460"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_192">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_192"
                                data-mode="T"
                                onclick="toggleTypeMenu('192')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_192" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('192','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('192','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('192','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_192" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('192')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_192"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_192" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_192"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_192" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                                

                            </div>

                        </div>
                        </div>
                         </div>
                         </div>
                        </div>



                         <div  class="content"  id="page-12"  style="display:none;height:440px;">
                              <%-------------------------------------173 to 190 resited in  that part before-----------------------------------------%>
                                    
                   <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px;    margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1092px; height: 500px;">

                             <div id="tag_Exchange_inner_lft" style="width: 1092px; height: 500px;">
                              
                                  <%-------------------------------------193 to 200 resited in  that part before-----------------------------------------%>
                           <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_193" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('189')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="462"></asp:TextBox>
                                </div>
                                  
                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_193">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_193"
                                data-mode="T"
                                onclick="toggleTypeMenu('193')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_193" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('193','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('193','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('193','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_193" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('193')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_193"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_193" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_193"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_193" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_194" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('190')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="464"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_194">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_194"
                                data-mode="T"
                                onclick="toggleTypeMenu('194')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_194" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('194','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('194','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('194','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_194" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('194')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_194"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_194" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_194"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_194" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                             <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_195" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('190')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="466"></asp:TextBox>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_195">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_195"
                                data-mode="T"
                                onclick="toggleTypeMenu('195')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_195" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('195','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('195','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('195','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_195" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('195')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_195"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_195" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_195"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_195" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                             <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_196" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('190')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="468"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_196">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_196"
                                data-mode="T"
                                onclick="toggleTypeMenu('196')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_196" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('196','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('196','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('196','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_196" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('196')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_196"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_196" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_196"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_196" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                        </div>

                          <%-------------------------------------197 to 200 resited in  that part before-----------------------------------------%>

                       <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_197" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"   onblur="Value_Chk('189')" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="470"></asp:TextBox>
                                </div>
                                 
                                  <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_197">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_197"
                                data-mode="T"
                                onclick="toggleTypeMenu('197')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_197" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('197','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('197','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('197','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_197" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('197')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_197"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_197" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_197"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_197" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_198" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('190')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="472"></asp:TextBox>
                                </div>


                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_198">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_198"
                                data-mode="T"
                                onclick="toggleTypeMenu('198')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_198" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('198','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('198','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('198','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_198" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('198')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_198"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_198" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_198"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_198" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>

                            </div>
                             <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_199" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('190')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="474"></asp:TextBox>
                                </div>

                                   <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_199">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_199"
                                data-mode="T"
                                onclick="toggleTypeMenu('199')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_199" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('199','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('199','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('199','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_199" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('199')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_199"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_199" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_199"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_199" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    <asp:TextBox ID="txt_lbl_200" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                        Width="130px"  onblur="Value_Chk('190')"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="476"></asp:TextBox>
                                </div>

                                 <div id="txtcon-m_Exchange_2">
                          <div class="type-selector-wrap" id="typewrap_200">
                            <button type="button"
                                class="type-selector-btn"
                                id="typebtn_200"
                                data-mode="T"
                                onclick="toggleTypeMenu('200')"
                                title="Choose type of textbox">
                                Choose type &nbsp;&#9660;
                            </button>
                            <div id="typemenu_200" style="display:none; position:absolute;
                                z-index:9999; background:#fff;
                                border:1px solid #ccc; border-radius:4px;
                                box-shadow:0 2px 8px rgba(0,0,0,0.15);
                                min-width:120px;">
                                <div class="type-option" onclick="selectType('200','T')">
                                    T &nbsp;<span style="color:#888;font-size:10px;">&#8212; Text</span>
                                </div>
                                <div class="type-option" onclick="selectType('200','D')">
                                    D &nbsp;<span style="color:#888;font-size:10px;">&#8212; Date</span>
                                </div>
                                <div class="type-option" onclick="selectType('200','DD')">
                                    DD &nbsp;<span style="color:#888;font-size:10px;">&#8212; Dropdown</span>
                                </div>
                            </div>
                            <div id="ddpanel_200" style="display:none; position:absolute;
                                z-index:9998; margin-top:2px; background:#fff;
                                border:1px solid #FF9800; border-radius:4px;
                                padding:6px 8px;
                                box-shadow:0 2px 6px rgba(0,0,0,0.15);">
                                <div style="display:flex; align-items:center;
                                            justify-content:space-between;
                                            margin-bottom:4px;">
                                    <span style="font-size:11px; color:#888;">
                                        Enter values (comma separated):
                                    </span>
                                    <button type="button"
                                        onclick="closeDDPanel('200')"
                                        style="background:none; border:none;
                                               cursor:pointer; font-size:14px;
                                               color:#999; font-weight:700;
                                               line-height:1; padding:0 4px;"
                                        title="Close">&#x2715;</button>
                                </div>
                                <input type="text"
                                    id="ddvalues_200"
                                    placeholder="e.g. Yes,No,Pending"
                                    style="width:200px; height:24px; font-size:11px;
                                           border:1px solid #FF9800; border-radius:4px;
                                           padding:0 6px;" />
                            </div>
                            <span id="dmsg_200" style="display:none; margin-left:6px;
                                font-size:11px; border-radius:3px; padding:2px 7px;
                                white-space:nowrap;">
                            </span>
                          </div>
                          <asp:HiddenField ID="hd_isdate_200"   runat="server"
                            ClientIDMode="Static" Value="N" />
                          <asp:HiddenField ID="hd_ddvalues_200" runat="server"
                            ClientIDMode="Static" Value="" />
                                </div>
                            </div>
                        </div>



                              </div>
                         </div>
                          </div>

                        </div>




             <%---------------------------PE----------------------------------------------------%>
                </div>
                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="180" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="181" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="183">
                        </div>
                       <div id="editbu" style="width:10px;"></div>
               
                    
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
                activatables('page', ['page-6', 'page-7', 'page-8', 'page-9', 'page-10', 'page-11', 'page-12']);
            </script>

           
             <asp:HiddenField ID="HDupdate_id" runat="server" />
             <asp:HiddenField ID="HD_Showcon" runat="server" />


            
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
<%--    <script src="../js/Import_Jscript/Job_Duplicate/Imp_DSR_Cus.js" type="text/javascript"></script>--%>


</body>
</html>
