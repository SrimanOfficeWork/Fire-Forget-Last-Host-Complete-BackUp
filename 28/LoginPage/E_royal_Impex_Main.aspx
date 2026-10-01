<%@ Page Language="C#" AutoEventWireup="true" CodeFile="E_royal_Impex_Main.aspx.cs"
    Async="true" Inherits="LoginPage_Premium_E_royal_Impex_Main" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title runat="server" id="comp_ttl">eRoyal Impex</title>
    <link href="premium-theme.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/all.min.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" type="image/png" href="../images/eroyal_title_logo.png" />
    <link rel="icon" type="image/png" href="../images/eroyal_title_logo.png" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
</head>
<body topmargin="0" class="premium-body">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div class="pm-topbar">
                <div class="pm-brand">
                    <a href="E_royal_Impex_Main.aspx" target="_top" title="Home">
                        <img src="../images/logomain_master.png" alt="eRoyal Impex" class="pm-logo" />
                    </a>
                </div>
                <div class="pm-topbar-right">
                    <div id="divHomeIcon" onclick="window.top.location.href='E_royal_Impex_Main.aspx';" title="Home">
                        <span id="spanHomeIcon">
                            <svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 576 512"
                                height="17" width="17" xmlns="http://www.w3.org/2000/svg">
                                <path d="M575.8 255.5c0 18-15 32.1-32 32.1h-32l.7 160.2c0 2.7-.2 5.4-.5 8.1V472c0 22.1-17.9 40-40 40H456c-1.1 0-2.2 0-3.3-.1c-1.4.1-2.8.1-4.2.1H416 392c-22.1 0-40-17.9-40-40V448 384c0-17.7-14.3-32-32-32H256c-17.7 0-32 14.3-32 32v64 24c0 22.1-17.9 40-40 40H160 128.1c-1.5 0-3-.1-4.5-.2c-1.2.1-2.4.2-3.6.2H104c-22.1 0-40-17.9-40-40V360c0-.9 0-1.9 .1-2.8V287.6H32c-18 0-32-14-32-32.1c0-9 3-17 10-24L266.4 8c7-7 15-8 22-8s15 2 21 7L564.8 231.5c8 7 12 15 11 24z"></path>
                            </svg>
                        </span>
                    </div>
                    <div id="divBellIcon" onclick="OpenBellPopup()" title="Announcements">
                        <span id="spanBellIcon">
                            <svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 448 512"
                                height="17" width="17" xmlns="http://www.w3.org/2000/svg">
                                <path d="M224 512c35.32 0 63.97-28.65 63.97-64H160.03c0 35.35 28.65 64 63.97 64zm215.39-149.71c-19.32-20.76-55.47-51.99-55.47-154.29 0-77.7-54.48-139.9-127.94-155.16V32c0-17.67-14.32-32-31.98-32s-31.98 14.33-31.98 32v20.84C118.56 68.1 64.08 130.3 64.08 208c0 102.3-36.15 133.53-55.47 154.29-6 6.45-8.66 14.16-8.61 21.71.11 16.4 12.98 32 32.1 32h383.8c19.12 0 32-15.6 32.1-32 .05-7.55-2.61-15.27-8.61-21.71z"></path>
                            </svg>
                        </span>
                        <span id="spanBellDot">0</span>
                    </div>
                    <div id="divDscToolIcon" onclick="window.open('../FlatFile/MIS_report_1.aspx?DSC=1', '_self');" title="DSC Tool">
                        <span id="spanDscToolIcon">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="17" height="17"
                                fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z"></path>
                                <polyline points="9 12 11 14 15 10"></polyline>
                            </svg>
                        </span>
                        <span class="pm-topbar-icon-label">DSC Tool</span>
                    </div>
                    <div id="divEriSupportIcon" onclick="window.open('http://royalimpexchat.eroyalimpex.co.in:8051/', '_blank', 'noopener');" title="ERI Support">
                        <span id="spanEriSupportIcon">
                            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="17" height="17"
                                fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M21 11.5a8.38 8.38 0 0 1-.9 3.8 8.5 8.5 0 0 1-7.6 4.7 8.38 8.38 0 0 1-3.8-.9L3 21l1.9-5.7a8.38 8.38 0 0 1-.9-3.8 8.5 8.5 0 0 1 4.7-7.6 8.38 8.38 0 0 1 3.8-.9h.5a8.48 8.48 0 0 1 8 8v.5z"></path>
                            </svg>
                        </span>
                        <span class="pm-topbar-icon-label">ERI Support</span>
                    </div>
                    <div id="divCallUs" title="Call Us">
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="17" height="17"
                            fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72c.127.96.361 1.903.7 2.81a2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45c.907.339 1.85.573 2.81.7A2 2 0 0 1 22 16.92z"></path>
                        </svg>
                        <span class="pm-topbar-icon-label">Call Us: +91 98402 41678 / +91 93854 13685</span>
                    </div>
                    <div id="divLicNo" title="License No" runat="server" visible="false">
                        <span class="pm-topbar-icon-label">Lic. No <span id="spanLicNo" runat="server"></span></span>
                    </div>
                    <div id="mainmastopbranch">
                        <a href="#" class="branch" onclick="win_hide();open_Branch_Selection(); return false">
                            <svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 384 512"
                                height="16" width="16" xmlns="http://www.w3.org/2000/svg">
                                <path d="M172.268 501.67C26.97 291.031 0 269.413 0 192 0 85.961 85.961 0 192 0s192 85.961 192 192c0 77.413-26.97 99.031-172.268 309.67-9.535 13.774-29.93 13.773-39.464 0zM192 272c44.183 0 80-35.817 80-80s-35.817-80-80-80-80 35.817-80 80 35.817 80 80 80z"></path>
                            </svg>
                            <span class="pm-branch-meta">
                                <span class="pm-branch-name" id="mainmastopbranchtxt" runat="server">Branch</span>
                                <span class="pm-branch-period" id="pmWorkingPeriod" runat="server">Period</span>
                            </span>
                        </a>
                    </div>
                    <div class="pm-userchip" id="pmUserChip" onclick="togglePmUserMenu(event);">
                        <div class="pm-user-avatar-wrap">
                            <svg stroke="currentColor" fill="currentColor" stroke-width="0" viewBox="0 0 496 512"
                                class="pm-user-avatar-icon" height="18" width="18" xmlns="http://www.w3.org/2000/svg">
                                <path d="M248 8C111 8 0 119 0 256s111 248 248 248 248-111 248-248S385 8 248 8zm0 96c48.6 0 88 39.4 88 88s-39.4 88-88 88-88-39.4-88-88 39.4-88 88-88zm0 344c-58.7 0-111.3-26.6-146.5-68.2 18.8-35.4 55.6-59.8 98.5-59.8 2.4 0 4.8.4 7.1 1.1 13 4.2 26.6 6.9 40.9 6.9 14.3 0 28-2.7 40.9-6.9 2.3-.7 4.7-1.1 7.1-1.1 42.9 0 79.7 24.4 98.5 59.8C359.3 421.4 306.7 448 248 448z"></path>
                            </svg>
                            <span class="pm-user-status-dot"></span>
                        </div>
                        <div class="pm-user-meta">
                            <span class="pm-user-name" id="mainmastopusernametxt" runat="server">User</span>
                            <span class="pm-user-time" id="pmLoginTime" runat="server">--:--:-- --</span>
                        </div>
                        <div class="pm-user-dropdown" id="pmUserDropdown">
                            <div class="pm-user-dropdown-sub" id="pmSidebarLayoutSub">
                                <a class="pm-user-dropdown-neutral pm-sub-trigger" href="javascript:void(0);" onclick="togglePmSidebarLayoutSub(event); return false;">
                                    <span class="pm-signout-icon">&#9635;</span> Sidebar Layout
                                    <span class="pm-sub-arrow">&#10095;</span>
                                </a>
                                <div class="pm-user-dropdown-submenu" id="pmSidebarLayoutSubmenu">
                                    <a class="pm-layout-option on" href="javascript:void(0);" data-layout="horizontal" onclick="pmApplyMenuLayout('horizontal'); return false;">
                                        <span class="pm-layout-check">&#10003;</span> Horizontal
                                    </a>
                                    <a class="pm-layout-option" href="javascript:void(0);" data-layout="vertical" onclick="pmApplyMenuLayout('vertical'); return false;">
                                        <span class="pm-layout-check">&#10003;</span> Vertical
                                    </a>
                                </div>
                            </div>
                            <a class="pm-user-dropdown-neutral" href="javascript:void(0);" onclick="openChangePasswordPremium(); return false;">
                                <span class="pm-signout-icon">&#128272;</span> Change Password
                            </a>
                            <a href="javascript:void(0);" onclick="confirmSignOut(); return false;">
                                <span class="pm-signout-icon">&#9211;</span> Sign out
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div id="mypanel" class="ddpanel">
                <div id="mypanelcontent" class="ddpanelcontent">
                    <div id="mainmastop1container_topmenu">
                        <div id="myjquerymenu" class="jquerycssmenu">
                            <ul>
                                <%-- <li id="Imp_id" runat="server"><a href="javascript:void(0);win_hide();" onclick="openGeneral_Search_New('New'); return false">Import</a></li>
                      <li id="Exp_id" runat="server"><a href="javascript:void(0);win_hide();" onclick="Export_General__New('New'); return false">Export</a></li>
                      <li id="Imp_Exp_id" runat="server"><a href="javascript:void(0);win_hide();" onclick="openGeneral_Search_New('New'); return false">Exchange-Rate</a></li>
                                --%>
                                <li id="Imp_id" runat="server"><a href="../Transaction/General_Search.aspx" target="maineroyal"
                                    onclick="win_close();"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><path d="M12 3v10m0 0l-4-4m4 4l4-4"></path><path d="M3 15v4a2 2 0 002 2h14a2 2 0 002-2v-4"></path></svg></span>Import</a></li>
                                <li id="Exp_id" runat="server"><a href="../Export/Export_General_Search.aspx" target="maineroyal"
                                    onclick="win_close();"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><path d="M12 21V11m0 0l-4 4m4-4l4 4"></path><path d="M3 15v4a2 2 0 002 2h14a2 2 0 002-2v-4"></path></svg></span>Export</a></li>
                                <li id="Imp_Exp_Ex_rate" runat="server"><a href="javascript:void(0);" onclick="OpenPopupExchange('IMP_EXP_Currency'); return false"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><path d="M4 7h13l-3-3m3 3l-3 3"></path><path d="M20 17H7l3 3m-3-3l3-3"></path></svg></span>
                                    Exchange-Rate</a></li>
                                <li><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="5" width="18" height="14" rx="2"></rect><path d="M3 7l9 6 9-6"></path></svg></span>e-Royal Impex</a>
                                    <ul>
                                        <li id="Li11" runat="server"><a href="#" onclick="openGenericModal('../Internal_Mail/Inbox_search.aspx', 990, 545); return false">
                                            Inbox<span id="Inbox_Id" runat="server"></span></a></li>
                                        <%--<li id="Li3" runat="server"><a href="#" onclick="win_hide();openmailsetting(); return false">
                                            Mail Setting</a></li>--%>
                                        <li id="Li79" runat="server"><a href="../Read_Mail/Mail_Setting_search.aspx" target="maineroyal"
                                            onclick="win_close();">Mail Setting</a></li>
                                        <li id="Icegate" runat="server"><a href="../IRN_Automation/IRN_Ice_Gate_Login_Settings_Search.aspx"
                                            target="maineroyal" onclick="win_close();">IceGate Login Setting</a></li>
                                        <li id="IRN_Dash" runat="server"><a href="../IRN_Automation_New/IRN_Autiomation_Dashborad.aspx"
                                            target="maineroyal" onclick="win_close();">IRN Dashboard</a></li>
                                        <li id="Li24" runat="server"><a href="#" onclick="openGenericModal('../Users/Currency_Converter.aspx', 457, 200); return false">
                                            Currency Converter</a></li>
                                        <%-- <li id="Li19" runat="server"><a href="#" onclick="win_hide();open_defaultsettings(); return false">
                                   Default Settings</a></li>--%>
                                        <li><a href="#" target="maineroyal" onclick="hide();">Default Settings</a>
                                            <ul>
                                                <li id="Supp_Set" runat="server"><a href="#" onclick="openGenericModal('../Users/Default_Settings.aspx', 457, 200); return false">
                                                    Supplier Settings</a></li>
                                                <li id="Client_Set" runat="server"><a href="#" onclick="openGenericModal('../Users/Default_Client_Settings.aspx', 457, 200); return false">
                                                    Client Settings</a></li>
                                                <li id="License_Set" runat="server"><a href="#" onclick="openGenericModal('../Users/Imp_License_Settings.aspx', 457, 400); return false">
                                                    License Settings</a></li>
                                                <li id="PurchaseEntry_Set" runat="server"><a href="#" onclick="openGenericModal('../Users/Purchaseentrysetting.aspx', 457, 200); return false">
                                                    Purchase Entry Settings</a></li>
                                            </ul>
                                        </li>
                                        <li id="IMP_error_code" runat="server"><a href="#" onclick="win_hide();Error_Code(); return false">
                                            Import Error Code</a></li>
                                        <li id="Amendment_Err_Code" runat="server"><a href="#" onclick="win_hide();Amendment_Error_Code(); return false">
                                            Amendment Error Code</a></li>
                                        <li id="Li12"><a href="#">
                                            Ice Gate </a>
                                            <ul>
                                                <li id="Li16"><a href="#" onclick="window.open('http://www.icegate.gov.in'); return false">
                                                    Ice Gate</a></li>
                                                <li id="Li13"><a href="#" onclick="window.open('http://www.dgft.gov.in'); return false">
                                                    DGFT</a></li>
                                                <li id="Li14"><a href="#" onclick="window.open('https://www.cbic.gov.in/'); return false">
                                                    CBIC </a></li>
                                            </ul>
                                            <li id="Noti_Updates" runat="server"><a href="../Users/Notification_Updation_View.aspx"
                                                target="maineroyal" onclick="win_close();">Notification Updates</a></li>

                                                  <li id="Exstatus" runat="server"><a href="#" onclick="openGenericModal('../AI_Extraction_Queue/AI_Extraction_Queue_Status.aspx?Job_type=undefined', 1200, 700); return false">Extraction Status</a></li>
                                            <%--<li id="Li_Dashboard" runat="server"><a href="../Chart/Chart.aspx" target="maineroyal"
                                                onclick="win_close();">Dashboard</a></li>--%>
                                        </li>
                                    </ul>
                                </li>
                                <%-- Placeholder top-level menu - no items yet, href="#" so it's inert
                                     until there's something to put in it. --%>
                                <%--<li id="Global_Id" runat="server"><a href="../eRoyalMasters/Master_Hub.aspx" target="maineroyal" onclick="win_close();"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><circle cx="12" cy="12" r="9"></circle><path d="M3 12h18"></path><path d="M12 3a15 15 0 010 18a15 15 0 010-18"></path></svg></span>Masters</a></li>--%>
                                <li id="Master_Id" runat="server"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><ellipse cx="12" cy="5" rx="8" ry="3"></ellipse><path d="M4 5v6c0 1.66 3.58 3 8 3s8-1.34 8-3V5"></path><path d="M4 11v6c0 1.66 3.58 3 8 3s8-1.34 8-3v-6"></path></svg></span>Master</a>
                                    <ul>
                                        <li id="Li74" runat="server"><a href="#">Common</a>
                                            <ul>
                                                <%--<li id="Client_Id" runat="server"><a href="../eRoyalMasters/Client_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Client</a></li>--%>
                                                    <li id="Client_Id" runat="server"><a href="../eRoyalMasters/Client_Master_Search_New.aspx"
                                                    target="maineroyal" onclick="win_close();">Client</a></li>
                                                <li id="Adcode_Id" runat="server"><a href="../eRoyalMasters/Adcode_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">ADCode</a></li>
                                                <li id="Li_Sup_Doc_Master" runat="server"><a href="../eRoyalMasters/Sup_Doc_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Sup.Doc Master </a></li>
                                                <li id="Li15" runat="server"><a href="../ListPopup/Port_Details_ListPopup.aspx" target="maineroyal"
                                                    onclick="OpenPopupPortDetails_display('Port_Det'); return false">Port Master</a></li>
                                                <li id="Li23" runat="server"><a href="../eRoyalMasters/Non_standard_currecy_master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Non Standard Cur.</a></li>
                                                <li id="ExRate" runat="server"><a href="../ERoyal_Admin_Master/Exchange_Rate_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Ex.Rate History</a></li>
                                                <li id="Li_portUsrWise" runat="server"><a href="../eRoyalMasters/Port_Master_UserWise_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">User Port</a></li>
                                                <li id="Li_Warehouse_Userwise" runat="server"><a href="../eRoyalMasters/WareHouse_Master_UserWise_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">WareHouse Master</a></li>
                                                <li id="Transport_Id" runat="server"><a href="../eRoyalMasters/Transport_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Transport Master </a></li>
                                                <li id="PDF_Country" runat="server" visible="false"><a href="../eRoyalMasters/PDF_Country_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">PDF Country</a></li>
                                                <li id="PDF_Port" runat="server" visible="false"><a href="../eRoyalMasters/PDF_Port_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">PDF Port</a></li>
                                                <li id="Auto_Mail_Scheduler" runat="server" visible="false"><a href="../DSR_Auto_Mail_Scheduler/DSR_Mail_Scheduler_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Auto Mail Scheduler</a></li>
                                            </ul>
                                        </li>
                                        <li id="Li73" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li id="Supplier_Id" runat="server"><a href="../eRoyalMasters/Suppliermastersearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Supplier</a></li>
                                                <li id="Product_Id" runat="server"><a href="../eRoyalMasters/Product_Import_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Import Product</a></li>
                                                <li id="Imp_License" runat="server"><a href="../eRoyalMasters/Import_License_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Import License</a></li>
                                                <li id="Li25" runat="server"><a href="../eRoyalMasters/Svb_Relation_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">SVB Relation</a></li>
                                                <li id="Li_Imp_ThirtyParty" runat="server"><a href="../eRoyalMasters/Imp_Thirdpartymastersearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Imp Third Party</a></li>
                                                <li id="Li_Bond_Master" runat="server"><a href="../eRoyalMasters/Import_Bond_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Bond </a></li>
												<li id="Li_Sw_Master" runat="server"><a href="../eRoyalMasters/SingleWindow_UserWise.aspx"
                                                    target="maineroyal" onclick="win_close();">SW Master </a></li>
                                                <li id="Pdf_Product_Id" runat="server" visible="false"><a href="../eRoyalMasters/Product_PFD_Reader_Import_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">PDF Import Product</a></li>
                                                <li id="Import_CaterPillar" runat="server" visible="false"><a href="../eRoyalMasters/Import_CaterPillar_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Import CaterPillar</a></li>
                                                <li id="Indev_Product_Id" runat="server" visible="false"><a href="../eRoyalMasters/Indev_Product_Import_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Product Thailand</a></li>
                                                <li id="Import_PDF" runat="server" visible="true"><a href="../eRoyalMasters/Import_PDF_Settings_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Import PDF Settings</a></li>
                                                <li id="Imp_PDF_Mas" runat="server" visible="true"><a href="../OCR_Dashboard_Report/IMP_PDF_CLIENT_MASTER_SEARCH.aspx"
                                                    target="maineroyal" onclick="win_close();">Imp PDF Client Master</a></li>
                                            </ul>
                                        </li>
                                        <li id="Li82" runat="server"><a href="#">Export</a>
                                            <ul>
                                                <li id="Consignee_Id" runat="server"><a href="../eRoyalMasters/Consigneemastersearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Consignee</a></li>
                                                <li id="Buyer_Id" runat="server"><a href="../eRoyalMasters/Buyermastersearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Buyer</a></li>
                                                <li id="Exp_product_id" runat="server"><a href="../eRoyalMasters/Export_Product_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Export Product</a></li>
                                                <li id="License_Id" runat="server"><a href="../eRoyalMasters/License_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Export License</a></li>
                                                <li id="Li_Exp_ThirtyParty" runat="server"><a href="../eRoyalMasters/Exp_Thirdpartymastersearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Exp Third Party</a></li>
                                                <li id="Exp_PDF" runat="server" visible="true"><a href="../eRoyalMasters/Export_PDF_Settings_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Exp PDF Settings</a></li>
                                                <li id="Exp_PDF_Mas" runat="server" visible="true"><a href="../eRoyalMasters/Exp_PDF_Client_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Exp PDF Client Master</a></li>
                                                <li id="Exp_Annexure_Default" runat="server" visible="true"><a href="../eRoyalMasters/Annexure_Default_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">Exp Annex Master</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><path d="M17 3l4 4-4 4"></path><path d="M21 7H9a4 4 0 00-4 4v1"></path><path d="M7 21l-4-4 4-4"></path><path d="M3 17h12a4 4 0 004-4v-1"></path></svg></span>Transaction</a>
                                    <ul>
                                        <li id="AI_EXTRACTION" runat="server" visible="true"><a href="#" id="AiExtractionLink"
                                            onclick="openAiExtraction(); return false;" class="smenu"
                                            style="position: relative; display: inline-block; padding-right: 28px;">AI extraction
                                            <span style="position: absolute; top: 2px; right: 2px; background: linear-gradient(135deg,#4d7cff,#1744ff);
                                                color: #fff; font-size: 8px; font-weight: bold; padding: 1px 5px; border-radius: 10px;
                                                letter-spacing: 0.5px;">New </span></a></li>
                                        <li id="Import_Id" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li class="pm-menu-section-label">Job</li>
                                                <li id="Import_Job_Id" runat="server"><a href="../Transaction/General_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Import Job</a></li>
                                                <li><a href="../Report/Import_CheckList.aspx" target="maineroyal" onclick="win_close();">
                                                    CheckList</a></li>
                                                <%--<li><a href="../Duty_WSheet/Import_DutyWorksheet_Home.aspx" target="maineroyal" onclick="win_close();">
                                            Duty Worksheet</a></li>--%>
                                                <li id="Duty_Intimation" runat="server"><a href="#" onclick="openGenericModal('../Transaction/Duty_Intimation.aspx', 990, 545); return false;">
                                                    Duty Intimation</a></li>
                                                <li id="Duty_Cal" runat="server"><a href="#" onclick="openGenericModal('../Transaction/Import_DutyCalculator.aspx', 570, 460); return false;">
                                                    Duty Calculator</a></li>
                                                <li id="Import_Submission_Id" runat="server"><a href="../FlatFile/Import_Flat_File_Generation.aspx"
                                                    target="maineroyal" onclick="win_close();">Submission</a></li>
                                                <li id="Imp_Tracking" runat="server"><a href="../Read_Mail/General_Search.aspx?JOBTYPE=Import"
                                                    target="maineroyal" onclick="win_close();">Tracking</a></li>
                                                <li id="LiEsanchitImp" runat="server"><a href="../Read_Mail/General_Search.aspx?JOBTYPE=Import-Esanchit"
                                                    target="maineroyal" onclick="win_close();">Esanchit-Tracking</a></li>
                                                <li id="Imp_ADC_Sheet" runat="server" visible="false"><a href="../ADC/ADC_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">ADC Sheet</a></li>
                                                <li class="pm-menu-section-label">Statements</li>
                                                <li id="Li1" runat="server"><a href="../Import_Statement/Import_Job_Register.aspx"
                                                    target="maineroyal" onclick="win_close();">Statement</a></li>
                                                <li id="Li_St2" runat="server"><a href="../Import_Statement/Import_Statement2.aspx"
                                                    target="maineroyal" onclick="win_close();">Statement II</a></li>
                                                <li id="Import_Job_Duplicate_Id" runat="server"><a href="../Transaction/Duplicate_Job_Generation.aspx"
                                                    target="maineroyal" onclick="win_close();">Job Duplicate</a></li>
                                                <li class="pm-menu-section-label">BE &amp; Customs</li>
                                                <li id="Import_BE_Entry_Id" runat="server"><a href="../Transaction/BE_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">BE Entry</a></li>
                                                <li id="Li4" runat="server"><a href="#" onclick="openGenericModal('../Transaction/GATT_form.aspx', 1024, 800); return false;">
                                                    GATT</a></li>
                                                <%--<li id="Li8" runat="server"><a href="#" onclick="win_hide();open_Warehouse_Exbond_Details('warehouse');return false;">
                                                    WareHouse - ExBond</a></li>--%>
                                                <%--<li id="Li27" runat="server"><a href="#" onclick="win_hide();open_WareHouse('New');return false;">
                                                    WareHouse - FY</a></li>--%>
                                                    <li class="pm-menu-section-label">Warehouse &amp; SEZ</li>
                                                    <li id="WareHouseExBond_id" runat="server"><a href="#" onclick="openGenericModal('../WareHouse/WareHouse.aspx', 1100, 585); return false;">
                                                    WareHouse-ExBond</a></li>
                                                <li><a href="../Exbond_Report/WareHouse_Report_Details.aspx" target="maineroyal"
                                                    onclick="win_close();">Exbond Report</a></li>
                                                <li id="Li_SEZ_WAREHOUSE_to_SEZ_EXBOND_Details" runat="server"><a href="#" onclick="openGenericModal('../Transaction/Sez_WareHouse_Move_Sez_Exbond.aspx?EXBND_JOBID=warehouse', 920, 490); return false;">
                                                    SEZ Z - SEZ T Details</a></li>
                                                <li id="Li_SEZ_Z_to_T_Report" runat="server" visible="false"><a href="../Exbond_Report/SEZ_WareHouse_Exbond_Report_Details.aspx"
                                                    target="maineroyal" onclick="win_close();">SEZ Z - SEZ T Report</a></li>
                                                <li id="Li_SEZ_Z_to_T_Report_Item_Status" runat="server"><a href="../Exbond_Report/SEZ_General_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">SEZ Z Item Status</a></li>
                                                <%--   <li id="Li19" runat="server"><a href="../Transaction/Delivery_Chellan.aspx" onclick="hide();return false;" target="maineroyal">
                                            Delivery- Chellan</a></li>--%>
                                                <li class="pm-menu-section-label">Other</li>
                                                <li id="Li9" runat="server"><a href="../Transaction/Job_Initialization.aspx" target="maineroyal"
                                                    onclick="win_close();">Job Initialization</a></li>
                                                <li id="Imp_QueryReply" runat="server"><a href="../Query_Reply/Import_QueryReply.aspx" target="maineroyal"
                                                    onclick="win_close();">Query Reply</a></li>
                                                <li id="Under_Taking" runat="server"><a href="#" onclick="openGenericModal('../Transaction/Import_Undertaking_Form.aspx', 990, 545); return false;">
                                                    Undertaking Report</a></li>
                                                <%--  <li id="Dynamic_Rpt" runat="server"><a href="../DSR_Template/Dynamic_Report_Design_Search.aspx" target="maineroyal" onclick="win_close();">
                                           Report Creation</a></li>--%>
                                                <li id="Customized_DSR" runat="server"><a href="#">Customized DSR </a>
                                                    <ul>
                                                        <li id="Li30" runat="server"><a href="../DSR/Cus_DSR_Imp_Job_Search.aspx" target="maineroyal"
                                                            onclick="win_close();">CUS DSR </a></li>
                                                        <li id="Li44" runat="server"><a href="../DSR/Cus_DSR_Select_Search.aspx" target="maineroyal"
                                                            onclick="win_close();">CUS DSR Select </a></li>
                                                        <li id="Li45" runat="server"><a href="../DSR/Cus_Import_Dynamic_Report.aspx" target="maineroyal"
                                                            onclick="win_close();">CUS DSR Report </a></li>
                                                    </ul>
                                                </li>
                                                <li id="Job_Completed_Status_Entry" runat="server" visible="false"><a href="../INDEV/Imp_Job_CompletedStatus.aspx"
                                                    target="maineroyal" onclick="win_close();">Job Completed Status</a></li>
                                            </ul>
                                        </li>
                                        <li id="Export_Id" runat="server"><a href="#">Export</a>
                                            <ul>
                                                <li class="pm-menu-section-label">Job</li>
                                                <li id="Export_Job_Id" runat="server"><a href="../Export/Export_General_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Export Job</a></li>
                                                <li><a href="../Report/Export_CheckList.aspx" target="maineroyal" onclick="win_close();">
                                                    CheckList</a></li>
                                                <li id="Export_Bulk_Chk" runat="server" visible="false"><a href="../Report/ExportBulkCheckList.aspx"
                                                    target="maineroyal" onclick="win_close();">Bulk CheckList</a></li>
                                                <li id="Export_Submission_Id" runat="server"><a href="../FlatFile/Export_FlatFile_Generation_SingleWindow.aspx"
                                                    target="maineroyal" onclick="win_close();">Submission</a></li>
                                                <li id="Li6" runat="server"><a href="../Read_Mail/General_Search.aspx?JOBTYPE=Export"
                                                    target="maineroyal" onclick="win_close();">Tracking</a></li>
                                                <li id="LiEsanchitExp" runat="server"><a href="../Read_Mail/General_Search.aspx?JOBTYPE=Export-Esanchit"
                                                    target="maineroyal" onclick="win_close();">Esanchit-Tracking</a></li>
                                                <li class="pm-menu-section-label">Statements</li>
                                                <li id="Li2" runat="server"><a href="../Export_Statement/Export_Job_Register.aspx"
                                                    target="maineroyal" onclick="win_close();">Statement</a></li>
                                                <li id="Export_Job_Duplicate_Id" runat="server"><a href="../Export/Duplicate_Job_Generation.aspx"
                                                    target="maineroyal" onclick="win_close();">Job Duplicate</a></li>
                                                <li id="Export_SBEntry_Id" runat="server"><a href="../Export/Export_SB_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">SB Entry</a></li>
                                                <%--  <li id="Li15" runat="server"><a href="#" onclick="win_hide();open_GSP();return false;">
                                            GSP</a></li>--%>
                                                <li class="pm-menu-section-label">Other</li>
                                                <li id="Li10" runat="server"><a href="../Export/Export_Job_Initialization.aspx" target="maineroyal"
                                                    onclick="win_close();">Job Initialization</a></li>
                                                <li id="Li31" runat="server"><a href="../Query_Reply/Export_QueryReply.aspx" target="maineroyal"
                                                    onclick="win_close();">Query Reply</a></li>
                                                <li id="Li_Unified_Job" runat="server"><a href="../Export/Combined_Job.aspx" target="maineroyal" 
                                                    onclick="win_close();">Combined Job</a></li>
                                                <li id="Export_Bulk_Container_LIZMA" visible="false" runat="server"><a href="../Export_XL/Export_Bulk_Container_Upoad_JobWise.aspx"
                                                    target="maineroyal" onclick="win_close();">Container Upload</a></li>
                                                <li id="Export_Refrence_no_BulkUpload_LIZMA" visible="false" runat="server"><a href="../Export_XL/Export_Bulk_Refno_Upoad_JobWise.aspx"
                                                    target="maineroyal" onclick="win_close();">Ref No Upload</a></li>
                                                <li id="Customized_DSR_Exp" runat="server"><a href="#">Customized DSR </a>
                                                    <ul>
                                                        <li id="Li18" runat="server"><a href="../DSR_EXP/Cus_DSR_Exp_Job_Search.aspx" target="maineroyal"
                                                            onclick="win_close();">CUS DSR </a></li>
                                                        <li id="Li51" runat="server"><a href="../DSR_EXP/Cus_DSR_Exp_Select_Search.aspx"
                                                            target="maineroyal" onclick="win_close();">CUS DSR Select </a></li>
                                                        <li id="Li52" runat="server"><a href="../DSR_EXP/Cus_Export_Dynamic_Report.aspx"
                                                            target="maineroyal" onclick="win_close();">CUS DSR Report </a></li>
                                                    </ul>
                                                </li>
                                            </ul>
                                        </li>

                                        <li id="DSCFile_Id" runat="server"><a href="../DSCFileUpload/SignFiles.aspx"
                                                    target="maineroyal" onclick="win_close();">DSC File Upload</a></li>
                                        <li id="Export_Goods_Reg_Id" runat="server"><a href="#">Goods Registration</a>
                                            <ul>
                                                <li id="Export_Goods_Reg_Job_Id" runat="server"><a href="../Goods_Registration/Goods_General_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Goods Registration Job</a></li>
                                                <li><a href="../Report/Goods_CheckList.aspx" target="maineroyal" onclick="win_close();">
                                                    CheckList</a></li>
                                                <li id="Export_Goods_Reg_Submission_Id" runat="server"><a href="../FlatFile/Goods_Reg_FlatFile_Generation.aspx"
                                                    target="maineroyal" onclick="win_close();">Submission</a></li>
                                                <%--<li id="Export_Goods_Reg_Job_Duplicate_Id" runat="server"><a href="#" onclick="hide();">Job Duplicate</a></li>--%>
                                            </ul>
                                        </li>
                                        <%--<a href="../Amendment/Import_Amendment.aspx"   target="maineroyal" onclick="win_close();">Amendment FlatFile</a>--%>
                                        <li id="Li54" runat="server"><a href="#">Amendment Flatfile</a>
                                            <ul>
                                                <li id="Li55" runat="server"><a href="#" onclick="openGenericModal('../Amendment/Import_Amendment.aspx', 950, 515); return false;">
                                                    Import Amendment</a></li>
                                                <li id="Li28" runat="server"><a href="#" onclick="openGenericModal('../Amendment/Export_Amendment.aspx', 950, 515); return false;">
                                                    Export Amendment</a></li>
                                            </ul>
                                        </li>
                                        <li id="Export_EGM" runat="server" visible="false"><a href="#">EGM</a>
                                            <ul>
                                                <%--   <li id="Export_EGM_Job" runat="server"><a href="../EGM/EGM_Normal_Search.aspx" target="maineroyal"
                                            onclick="win_close();">EGM Job</a></li>--%>
                                                <li id="Export_EGM_consolidate" runat="server"><a href="../EGM/EGM_Consolidate_Normal_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">EGM Job</a></li>
                                            </ul>
                                        </li>
                                         <li id="Li5" runat="server"><a href="../DSR_Customized_Template/TemplateBuilder.aspx"
                                            target="maineroyal" onclick="win_close();">Customized DSR New</a></li>
                                        <li id="Rpt_Creation_GroupNew" runat="server"><a href="../DSR_Template/Dynamic_Report_Design_Search_GroupNew.aspx"
                                            target="maineroyal" onclick="win_close();">Customized Template</a></li>
                                        <li id="Rpt_Creation" runat="server"><a href="../DSR_Template/Dynamic_Report_Design_Search.aspx"
                                            target="maineroyal" onclick="win_close();">Report Creation</a></li>
                                        <li id="Job_Status" runat="server"><a href="../Transaction/Imp_Job_Status.aspx" target="maineroyal"
                                            onclick="win_close();">Job Status</a></li>
                                        <li id="Combined_Jobs" runat="server" visible="false"><a href="#">Combined Jobs</a>
                                            <ul>
                                                <li id="Combined_Jobs_Export" runat="server"><a href="../Combined_EXP_Jobs/EXP_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Export</a></li>
                                            </ul>
                                        </li>
                                        <li id="Docket_Entry" runat="server" visible="false"><a href="../Docket_Entry/Docket_General_Search.aspx"
                                            target="maineroyal" onclick="win_close();">Docket Entry</a></li>
                                        <%--  <li id="Job_duplicate_Branch" runat="server"><a href="../Job_Duplicate/Import_Job_Duplicate_M.aspx" target="maineroyal" onclick="win_close();">
                                           Job Transfer</a></li>--%>
                                        <%--   <li id="Letter_Temp" runat="server"><a href="#"  onclick="win_hide();open_Letter_Temp();return false;">Letter Template </a></li>--%>
                                        <li id="Letter_Temp" runat="server"><a href="#">Letter Template</a>
                                            <ul>
                                                <li id="Imp_Letter_Temp" runat="server"><a href="#" onclick="openGenericModal('../LetterTemplate/MyEditor.aspx', 990, 580); return false;">
                                                    Import</a></li>
                                                <li id="Exp_Letter_Temp" runat="server"><a href="#" onclick="openGenericModal('../LetterTemplate/EXP_MyEditor.aspx', 990, 580); return false;">
                                                    Export</a></li>
                                            </ul>
                                        </li>
                                        <li id="li_File_Update" runat="server"><a href="#" onclick="openGenericModal('../DeployFiles/DeployFiles.aspx', 1100, 585); return false">
                                            File Updation</a></li>
                                           <li id="Tally_Report" runat="server" visible="false"><a href="#">Tally Report</a>
                                            <ul>
                                                <li id="Imp_Tally_Report" runat="server"><a href="../Paramount/Import_TALLY_Excel_Format_PARA.aspx"
                                                    target="maineroyal" onclick="win_hide();">Import</a>
                                                    </li>
                                                <li id="Exp_Tally_Repor" runat="server"><a href="../Paramount/Export_TALLY_Excel_Format_PARA.aspx"
                                                    target="maineroyal" onclick="win_hide();">Export</a></li>
                                                    
                                            </ul>
                                        </li>

                                    </ul>
                                </li>
                                <%--  <li id="OCR_Module" runat="server" visible="false"><a href="#">OCR</a>
                                    <ul>
                                        <li id="OCR_Report" runat="server"><a href="#">Report</a>
                                            <ul>
                                                <li id="OCR_IMP_Report" runat="server" visible="true"><a href="../OCR_Dashboard_Report/PDF_Import_Report.aspx"
                                                    target="maineroyal" onclick="win_close();">Import</a></li>
                                                <li id="OCR_EXP_Report" runat="server" visible="true"><a href="../OCR_Dashboard_Report/PDF_Export_Report.aspx"
                                                    target="maineroyal" onclick="win_close();">Export</a></li>
                                            </ul>
                                        </li>
                                        <li id="OCR_Template_Creation" runat="server"><a href="#">Template Creation</a>
                                            <ul>
                                                <li id="Li88" runat="server" visible="true"><a href="../OCR_Dashboard_Report/Template_Creation.aspx?mode=import"
                                                    target="maineroyal" onclick="win_close();">Import</a></li>
                                                <li id="Li89" runat="server" visible="true"><a href="../OCR_Dashboard_Report/Template_Creation.aspx?mode=export"
                                                    target="maineroyal" onclick="win_close();">Export</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                --%>
                                <li id="OCR_Module" runat="server" visible="false"><a href="#" style="position: relative;
                                    display: inline-block; padding-right: 25px;"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><path d="M4 8V5a1 1 0 011-1h3"></path><path d="M20 8V5a1 1 0 00-1-1h-3"></path><path d="M4 16v3a1 1 0 001 1h3"></path><path d="M20 16v3a1 1 0 01-1 1h-3"></path><line x1="4" y1="12" x2="20" y2="12"></line></svg></span>OCR <span style="position: absolute;
                                        right: 4px; top: 1.5px; background: #ff3b30; color: #fff; font-size: 8px; font-weight: bold;
                                        padding: 1px 4px; border-radius: 8px; line-height: 10px;">AI </span></a>
                                    <ul>
                                        <li id="AI_DASHBOARD" runat="server" visible="true"><a href="#" onclick="openGenericModal('../OCR_Dashboard/Ocr_Ai_Dashboard.aspx?Job_type=undefined', 1300, 695); return false;"
                                            style="position: relative; display: inline-block; padding-right: 28px;">AI DASHBOARD
                                            <span style="position: absolute; top: 2px; right: 2px; background: linear-gradient(135deg,#ff4d4d,#ff1744);
                                                color: #fff; font-size: 8px; font-weight: bold; padding: 1px 5px; border-radius: 10px;
                                                letter-spacing: 0.5px;">New </span></a></li>
                                        <li id="OCR_IMPORT" runat="server" visible="false"><a href="#">Import</a>
                                            <ul>
                                                <%--<li id="OCR_IMP_Report" runat="server" visible="true"><a href="../OCR_Dashboard_Report/PDF_Import_Report.aspx"
                                                    target="maineroyal" onclick="win_close();">Report</a></li>--%>
                                                <li id="OCR_IMP_Report" runat="server" visible="true"><a href="#" onclick="openGenericModal('../OCR_Dashboard_Report/PDF_Import_Report.aspx', 1200, 700); return false;">
                                                    Report </a></li>
                                                <li id="OCR_IMP_Template_Creation" runat="server" visible="true"><a href="../OCR_Dashboard_Report/Template_Creation.aspx?mode=import"
                                                    target="maineroyal" onclick="win_close();">Template Creation</a></li>
                                            </ul>
                                        </li>
                                        <li id="OCR_EXPORT" runat="server" visible="false"><a href="#">Export</a>
                                            <ul>
                                                <li id="OCR_EXP_Report" runat="server" visible="true"><a href="#" onclick="openGenericModal('../OCR_Dashboard_Report/PDF_Export_Report.aspx', 1200, 700); return false;">
                                                    Report </a></li>
                                                <li id="OCR_EXP_Template_Creation" runat="server" visible="true"><a href="../OCR_Dashboard_Report/Template_Creation.aspx?mode=export"
                                                    target="maineroyal" onclick="win_close();">Template Creation</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><line x1="5" y1="20" x2="5" y2="11"></line><line x1="12" y1="20" x2="12" y2="6"></line><line x1="19" y1="20" x2="19" y2="14"></line></svg></span>Report</a>
                                    <ul>
                                        <li id="Rpt_Import" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li class="pm-menu-section-label">Documents</li>
                                                <li id="Import_Annexure_Id" runat="server"><a href="../Import_Annexure/General.aspx"
                                                    target="maineroyal" onclick="win_close();">Annexure</a></li>
                                                <%--<li id="Delivery_Chellan" runat="server"><a href="#" onclick="win_hide();open_delivery_chellan('warehouse');return false;">
                                                    Delivery- Chellan</a></li>--%>
                                                <li id="Delivery_Chellan" runat="server"><a href="#" onclick="openGenericModal('../Transaction/Delivery_Challen_Details.aspx', 990, 545); return false;">
                                                    Delivery- Challan</a></li>
                                                <li id="Delivery_Chellan_Vintage" runat="server" visible="false"><a href="#" onclick="openGenericModal('../Transaction/Delivery_Challen_Details_vintage.aspx', 990, 545); return false;">
                                                    Delivery-Challan</a></li>
                                                <li id="Delivery_Chellan_Carchit" runat="server"><a href="#" onclick="openGenericModal('../Transaction/Delivery_Challen_Details_CARCHIT.aspx', 990, 615); return false;">
                                                    Delivery- Challan Carchit</a></li>
                                                <li id="Delivery_Note" runat="server" visible="false"><a href="#" onclick="win_hide();open_delivery_note('warehouse');return false;">
                                                    Delivery- Note</a></li>
                                                <li id="Lidispatch" runat="server"><a href="../Despatch/Import_Despatch_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Despatch</a></li>
                                                <li class="pm-menu-section-label">Reports</li>
                                                <li id="Li_cust_Rpt_GroupNew_Import" runat="server"><a href="#" onclick="openGenericModal('../DSR_Template/Import_Dynamicreport.aspx', 1150, 615); return false;">
                                                    Customized Rpt New</a></li>
                                                <li id="CustomsDuty_Rpt" runat="server" visible="false"><a href="#" onclick="openGenericModal('../Import_Report/Import_CustomsDuty_Rpt_FAIRMACS.aspx', 1150, 615); return false;">
                                                    Customs Duty Rpt</a></li>
                                                <%--<li id="NForm" runat="server"><a href="#" onclick="win_hide();open_Import_Nform();return false;">
                                           N-Forms</a></li>--%>
                                                <li id="Li_NForm" runat="server"><a href="../Import_Report/Import_N_Form_Normal_Search.aspx"
                                                    target="maineroyal" onclick="win_hide();">N-Forms Report</a></li>
                                                <li id="Imp_Lic_Sum_Rpt" runat="server"><a href="../Import_Report/Imp_License_Partywise_Summary_Rpt.aspx"
                                                    target="maineroyal" onclick="win_close();">License Summary Rpt</a></li>
                                                <li id="Imp_Bond_Summary_Report" runat="server"><a href="../Import_Report/Imp_BD_BOND_Summary_Rpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Bond Summary Rpt</a></li>
                                                <li id="Import_CusRes" runat="server"><a href="#">Cusres Report</a>
                                                    <ul>
                                                        <li id="Import_CusRes_Id" runat="server"><a href="../Report/CusRes_Report.aspx" target="maineroyal"
                                                            onclick="win_close();">Report</a></li>
                                                        <li id="Import_CusRes_IdNew" runat="server"><a href="../Report/CusRes_Report_N.aspx"
                                                            target="maineroyal" onclick="win_close();">Report1 </a></li>
                                                    </ul>
                                                </li>
                                                <li id="Mis" runat="server"><a href="#">MIS Report</a>
                                                    <ul>
                                                        <li id="Mis_Report1" runat="server"><a href="../Mis_Report/Imp_MIS_Rpt.aspx" target="maineroyal"
                                                            onclick="win_close();">MIS Report1</a></li>
                                                        <li id="Mis_Report2" runat="server"><a href="../Mis_Report/Imp_MIS_smt.aspx" target="maineroyal"
                                                            onclick="win_close();">MIS Report2</a></li>
                                                        <li id="Mis_Report3" runat="server"><a href="../Mis_Report/Expeditors_Report.aspx"
                                                            target="maineroyal" onclick="win_close();">MIS Report3</a></li>
                                                        <li id="Mis_Report4" runat="server"><a href="../Mis_Report/Imp_MIS_Rpt4.aspx" target="maineroyal"
                                                            onclick="win_close();">MIS Report4</a></li>
                                                    </ul>
                                                </li>
                                                <%--  <li id="Mis_Report1" runat="server"><a href="../Mis_Report/Imp_MIS_Rpt.aspx" target="maineroyal" onclick="win_close();">
                                            MIS Report1</a></li>
                                        <li id="Mis_Report2" runat="server"><a href="../Mis_Report/Imp_MIS_smt.aspx" target="maineroyal" onclick="win_close();">
                                            MIS Report2</a></li>
                                        <li id="Mis_Report3" runat="server"><a href="../Mis_Report/Expeditors_Report.aspx" target="maineroyal" onclick="win_close();">
                                            MIS Report3</a></li>

                                             <li id="Mis_Report4" runat="server"><a href="../Mis_Report/Imp_MIS_Rpt4.aspx" target="maineroyal" onclick="win_close();">
                                            MIS Report4</a></li>--%>
                                                <li id="DSR" runat="server"><a href="../Mis_Report/Daily_Status_Report.aspx" target="maineroyal"
                                                    onclick="win_close();">DSR</a></li>
                                                <li id="Li56" runat="server"><a href="#">PL Report</a>
                                                    <ul>
                                                        <li id="PL_Report" runat="server"><a href="../Mis_Report/Imp_PL.aspx" target="maineroyal"
                                                            onclick="win_close();">Report</a></li>
                                                        <li id="PL_Report1" runat="server"><a href="../Mis_Report/IMP_Pl_Report_1.aspx" target="maineroyal"
                                                            onclick="win_close();">Report1</a></li>
                                                    </ul>
                                                </li>
                                                <li class="pm-menu-section-label">Forms &amp; Other Reports</li>
                                                <li id="KK_Form" runat="server"><a href="#" onclick="win_hide();Open_Import_KKForm();return false;">
                                                    KK Form</a></li>
                                                <li id="Imp_Dec" runat="server"><a href="#">Declaration</a>
                                                    <ul>
                                                        <li id="Imp_Dec1" runat="server"><a href="javascript:void(0);" onclick="OpenPopupDeclaration('I'); return false">
                                                            Declaration I</a></li>
                                                        <li id="Imp_Dec2" runat="server"><a href="javascript:void(0);" onclick="OpenPopupDeclaration('II'); return false">
                                                            Declaration II</a></li>
                                                        <li id="Imp_Dec3" runat="server"><a href="javascript:void(0);" onclick="OpenPopupDeclaration('III'); return false">
                                                            Declaration III</a></li>
                                                    </ul>
                                                </li>
                                                <%-- <li id="Li118" runat="server"><a href="javascript:void(0);"   onclick="OpenPopupDeclaration('I'); return false">Declaration I</a></li>
                                            <li id="Li191" runat="server"><a href="javascript:void(0);"   onclick="OpenPopupDeclaration('II'); return false">Declaration II</a></li>  --%>
                                                <%-- <li id="TR2" runat="server"><a href="javascript:void(0);"   onclick="OpenPopupTransshipPermit(); return false">TP2</a></li>--%>
                                                <%--<li><a href="../Transaction/Import_ManualBE.aspx" target="maineroyal" onclick="win_close();">
                                            Manual BE</a></li>--%>
                                                <li id="Customized_Rpt" runat="server"><a href="../DSR_Template/Import_Dynamic_Report.aspx"
                                                    target="maineroyal" onclick="win_close();">Customized Report</a></li>
                                                <%-- <li id="Li27" runat="server"><a href="javascript:void(0);"   onclick="OpenPopup_Countrywise_Summary('Import'); return false">Countrywise Summary</a></li>--%>
                                                <%-- <li id="IMP_Summary_RPT" runat="server"><a href="../Summary_Rpt/Import_Summary.aspx" target="maineroyal" onclick="win_close();">
                                            Summary Report</a></li>--%>
                                                <li id="IMP_Summary_RPT" runat="server"><a href="#">Summary Report</a>
                                                    <ul>
                                                        <li id="IMP_Summary_RPT1" runat="server"><a href="../Summary_Rpt/Import_Summary.aspx"
                                                            target="maineroyal" onclick="win_close();">Summary Report1</a></li>
                                                        <li id="IMP_Summary_RPT2" runat="server"><a href="../Summary_Rpt/Import_Summary_Two.aspx"
                                                            target="maineroyal" onclick="win_close();">Summary Report2</a></li>
                                                        <li id="IMP_Summary_RPT3" runat="server"><a href="../Summary_Rpt/Imp_Exp_Invoice_Job_Count.aspx"
                                                            target="maineroyal" onclick="win_close();">Summary Report3</a></li>
                                                        <li id="Li57" runat="server"><a href="#" onclick="openGenericModal('../Summary_Rpt/ImportSummary.aspx', 1150, 615); return false;">
                                                            Groupwise Report1</a> </li>
                                                        <li id="Li58" runat="server"><a href="#" onclick="openGenericModal('../Summary_Rpt/ImportSummaryTwo.aspx', 1150, 615); return false;">
                                                            Groupwise Report2</a> </li>
                                                    </ul>
                                                </li>
                                                <li id="TB_Ship" runat="server"><a href="#" onclick="openGenericModal('../Transaction/Import_TB_ShippingBill.aspx', 990, 545); return false;">
                                                    TB ShippingBill</a></li>
                                                <li id="Li53" runat="server"><a href="#">TP</a>
                                                    <ul>
                                                        <li id="TP1" runat="server"><a href="javascript:void(0);" onclick="OpenPopupCustomsDeclaration(); return false">
                                                            TP1</a></li>
                                                        <li id="TR2" runat="server"><a href="javascript:void(0);" onclick="OpenPopupTransshipPermit_New(); return false">
                                                            TP2</a></li>
                                                    </ul>
                                                </li>
                                                <li id="Li_LTR_Doc" runat="server"><a href="#" onclick="win_hide();Open_Import_LTR_Format();return false;">
                                                    LTR Format</a></li>
                                                <li id="Manual_BE" runat="server"><a href="#" onclick="openGenericModal('../Transaction/Import_ManualBE.aspx', 1000, 590); return false;">
                                                    Manual BE</a></li>
                                                <li id="IMP_SIMS_Rpt" runat="server"><a href="../Import_Report/Imp_Sims_Rpt.aspx"
                                                    target="maineroyal" onclick="win_close();">SIMS Report</a></li>
                                            </ul>
                                        </li>
                                        <li id="Rpt_Export" runat="server"><a href="#">Export</a>
                                            <ul>
                                                <li class="pm-menu-section-label">Documents</li>
                                                <li id="Exp_Inv_Cum_Packing_List_Search" runat="server"><a href="../Self_Exporter/Export_Invoice_Cum_Packing_List_Search.aspx"
                                                    target="maineroyal" onclick="win_hide();">Inv Cum Packing List</a></li>
                                                <%--Invoice Cum Packing List--%>
                                                <li id="Export_Annexure_Id" runat="server"><a href="../Export_Annexure/General.aspx"
                                                    target="maineroyal" onclick="win_close();">Annexure</a></li>
                                                <li id="Exp_Despatch" runat="server"><a href="../Despatch/Export_Despatch_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Despatch</a></li>
                                                <li class="pm-menu-section-label">Reports</li>
                                                <li id="Li_cust_Rpt_GroupNew_Export" runat="server"><a href="#" onclick="openGenericModal('../DSR_Template/Export_Dynamicreport.aspx', 1150, 615); return false;">
                                                    Customized Rpt New</a></li>
                                                <li id="Export_DSR_Rpt_Lizma" runat="server"><a href="../Mis_Report/Daily_Status_Report_Export_LIZMA.aspx"
                                                    target="maineroyal" onclick="win_close();">DSR</a></li>
                                                <li id="Export_DSR_Rpt_Common" runat="server"><a href="../Mis_Report/Daily_Status_Report_Export.aspx"
                                                    target="maineroyal" onclick="win_close();">DSR</a></li>
                                                <%--  <li id="Certi_Origin" runat="server"><a href="#" onclick="win_hide();open_Certificate_origin();return false;">
                                            Certificate Origin</a></li>--%>
                                                <li class="pm-menu-section-label">Certificates &amp; Compliance</li>
                                                <li id="Cert" runat="server"><a href="#">Certificate Origin</a>
                                                    <ul>
                                                        <li id="Li_COO_Search" runat="server"><a href="../Export/Export_GSP_certificateorigin_Search.aspx"
                                                            target="maineroyal" onclick="win_hide();">COO Normal</a></li>
                                                        <li id="Li_COO_Annex" runat="server"><a href="../BL_Generation/BL_Generation_Annexure_Search.aspx?Name=COO"
                                                            target="maineroyal" onclick="win_hide();">COO Annexure</a></li>
                                                    </ul>
                                                </li>
                                                <li id="GSP_Search" runat="server"><a href="../Export/Export_GSP_Front_Details_Search.aspx"
                                                    target="maineroyal" onclick="win_hide();">GSP</a></li>
                                                <%--
                                                <li id="GSP" runat="server"><a href="#" onclick="win_hide();open_GSP();return false;">
                                            GSP</a></li>--%>
                                                <%--<li id="Li21" runat="server"><a href="#" onclick="openGenericModal('../Export/Invoice_Details.aspx', 990, 600); return false;">
                                                    Invoice</a></li>--%>
                                                <li id="Li21" runat="server"><a href="#" onclick="openGenericModal('../Export/Export_Invoice_Report_Details.aspx', 990, 600); return false;">
                                                    Invoice</a></li>
                                                    <li>
                                                     <asp:LinkButton ID="REPORT" runat="server" OnClientClick="EXP_Bulk_ETP(); return false;"> <span>ETP</span> </asp:LinkButton>
                                                    </li>
                                                <li id="Li35" runat="server"><a href="#">SDF FORMAT</a>
                                                    <ul>
                                                        <li id="Li33" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix1.aspx', 1000, 590); return false;">
                                                            SDF Appendix I</a></li>
                                                        <li id="Li47" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix2.aspx', 1000, 590); return false;">
                                                            SDF Appendix II</a></li>
                                                        <li id="Li36" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix3.aspx', 1000, 590); return false;">
                                                            SDF Appendix III</a></li>
                                                        <li id="Li48" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix4.aspx', 1000, 590); return false;">
                                                            SDF Appendix IV</a></li>
                                                        <li id="Li37" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix5.aspx', 1000, 590); return false;">
                                                            SDF Appendix V</a></li>
                                                        <li id="Li46" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix6.aspx', 1000, 590); return false;">
                                                            SDF Appendix VI</a></li>
                                                        <li id="Li49" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix7.aspx', 1000, 590); return false;">
                                                            SDF Appendix VII</a></li>
                                                        <li id="Li50" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix8.aspx', 1000, 590); return false;">
                                                            SDF Appendix VIII</a></li>
                                                        <li id="Li38" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix9.aspx', 1000, 590); return false;">
                                                            SDF Appendix IX</a></li>
                                                        <li id="Li39" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix10.aspx', 1000, 590); return false;">
                                                            SDF Appendix X</a></li>
                                                        <li id="Li40" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix11.aspx', 1000, 590); return false;">
                                                            SDF Appendix XI</a></li>
                                                        <li id="Li41" runat="server"><a href="#" onclick="openGenericModal('../EXPORT_SDF/SDF_Appendix12.aspx', 1000, 590); return false;">
                                                            SDF Appendix XII</a></li>
                                                        <li id="Exp_SDF_DEC" runat="server"><a href="#" onclick="win_hide();Open_SDF_Export_Declaration();return false;">
                                                            Export Declaration</a></li>
                                                    </ul>
                                                </li>
                                                <li class="pm-menu-section-label">Export Docs &amp; Annexures</li>
                                                <li id="LiExpDoc" runat="server"><a href="#" onclick="openGenericModal('../Export_SDF/EDocket.aspx', 1000, 590); return false;">
                                                    Export-Docket</a></li>
                                                <li id="LiExpAnn_CVR" runat="server"><a href="#" onclick="openGenericModal('../Export_SDF/ExportAnnexure1.aspx', 1000, 590); return false;">
                                                    Export-Annex(CVR)</a></li>
                                                <li id="Annexure_C" runat="server"><a href="../Export_Annexure_C/General.aspx" target="maineroyal"
                                                    onclick="win_close();">Annexure C</a></li>
                                                <li id="Annexure_EOU" runat="server"><a href="#" target="maineroyal" onclick="Export_Annex_EOU_Open();return false;">
                                                    Annexure EOU</a></li>
                                                <li class="pm-menu-section-label">Reports &amp; BL</li>
                                                <li id="Exp_PL_Rpt" runat="server"><a href="#">PL Report</a>
                                                    <ul>
                                                        <li id="Exp_PL_Report" runat="server"><a href="../Mis_Report/EXP_Pl_Report.aspx"
                                                            target="maineroyal" onclick="win_close();">PL Report</a></li>
                                                        <li id="Exp_PL_Report2" runat="server"><a href="../Mis_Report/EXP_Pl_Report_1.aspx"
                                                            target="maineroyal" onclick="win_close();">PL Report1</a></li>
                                                    </ul>
                                                </li>
                                                <li id="MIS_Report" runat="server"><a href="#">MIS Report</a>
                                                    <ul>
                                                        <li id="Li88" runat="server"><a href="../Mis_Report/Exp_MIS_Rpt_GroupNew.aspx" target="maineroyal"
                                                            onclick="win_close();">MIS Report1</a></li>
                                                        <li id="Li86" runat="server"><a href="../Mis_Report/Exp_MIS_Rpt2.aspx" target="maineroyal"
                                                            onclick="win_close();">MIS Report2</a></li>
                                                    </ul>
                                                </li>
                                                <li id="Exp_Packing_List" runat="server"><a href="#">Packing List</a>
                                                    <ul>
                                                        <%-- <li id="Li18" runat="server"><a href="#" onclick="win_hide();Open_Export_PackingList();return false;">
                                                    Normal</a></li>--%>
                                                        <li id="Packing_list_Normal" runat="server"><a href="../Export/Export_PackingList_Search.aspx"
                                                            target="maineroyal">Normal</a></li>
                                                        <li id="Li42" runat="server"><a href="../BL_Generation/Consolidated_Packing_List_Search.aspx"
                                                            target="maineroyal" onclick="win_hide();">Consolidate</a></li>
                                                    </ul>
                                                </li>
                                                <li id="BL_Gen" runat="server"><a href="#">BL Generation</a>
                                                    <ul>
                                                        <li id="BL_Normal" runat="server"><a href="../BL_Generation/BL_Generation_Normal_Search.aspx"
                                                            target="maineroyal" onclick="win_hide();">BL Normal</a></li>
                                                        <%--  <li id="BL_Normal" runat="server"><a href="#" target="maineroyal"
                                                    onclick="win_hide();open_BL_Generation();return false;">BL Normal</a></li>--%>
                                                        <li id="BL_Consolidate" runat="server"><a href="../BL_Generation/BL_Multiple_Search.aspx"
                                                            target="maineroyal" onclick="win_close();">BL Consolidate</a></li>
                                                        <%-- <li id="BL_Annexure" runat="server"><a href="../BL_Generation/BL_Generation_Annexure_Search.aspx" target="maineroyal"
                                                    onclick="win_hide();">BL Annexure</a></li>--%>
                                                        <li id="BL_Annexure" runat="server"><a href="../BL_Generation/BL_Generation_Annexure_Search.aspx?Name=BL_Generation"
                                                            target="maineroyal" onclick="win_hide();">BL Annexure</a></li>
                                                        <li id="Pending_Normal" runat="server"><a href="javascript:void(0);" onclick="Export_BL_Job_Status_Menu('New'); return false">
                                                            Pending Normal</a></li>
                                                        <li id="Pending_Consolidate" runat="server"><a href="javascript:void(0);" onclick="Export_Multiple_BL_Job_Status_Menu('New'); return false">
                                                            Pending Consolidate</a></li>
                                                        <%--<li id="Pending_Jobs" runat="server"><a href="#">Pending Jobs</a>
                                                    <ul>
                                                        
                                                    </ul>
                                                </li>--%>
                                                        <li id="BL_ACD" runat="server"><a href="javascript:void(0);" onclick="OpenPopupBLGeneration_ACD(); return false">
                                                            ACD</a></li>
                                                    </ul>
                                                </li>
                                                <li id="Exp_CustRpt" runat="server"><a href="../DSR_Template/Export_Dynamic_Report.aspx"
                                                    target="maineroyal" onclick="win_close();">Customized Report</a></li>
                                                <li id="Exp_SummaryRpt" runat="server"><a href="../Summary_Rpt/Export_Summary.aspx"
                                                    target="maineroyal" onclick="win_close();">Summary Report</a></li>
                                                <li id="Exp_SummaryRpt_Groupwise" runat="server"><a href="#" onclick="openGenericModal('../Summary_Rpt/ExportSummary.aspx', 1150, 615); return false;">
                                                    Summary Rpt Groupwise</a> </li>
                                                <li id="Manual_SB" runat="server"><a href="#" onclick="openGenericModal('../Export/Export_ShippingBill_DBK_DutyFree.aspx', 990, 545); return false;">
                                                    Manual SB</a></li>
                                            </ul>
                                        </li>
                                        <li id="Nippon" runat="server" visible="false"><a href="#">Nippon Report</a>
                                            <ul>
                                                <li id="eSugam" runat="server"><a href="#" onclick="openGenericModal('../NIPPON/e_Sugam_Report.aspx', 990, 545); return false;">
                                                    e-Sugam Report</a></li>
                                                <li id="Li_DGFT_M" runat="server"><a href="#" onclick="win_hide();open_DGFT_Mnaufacturer_Report('DGFT_Manufacturer'); return false">
                                                    DGFT Manufacturer</a></li>
                                                <li id="Li_DGFT_T" runat="server"><a href="#" onclick="win_hide();open_DGFT_Mnaufacturer_Report('DGFT_Trading'); return false">
                                                    DGFT Trading</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li id="Indev" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="7" width="13" height="10" rx="1"></rect><path d="M16 10h3l2 3v4h-5"></path><circle cx="7" cy="19" r="1.5"></circle><circle cx="18" cy="19" r="1.5"></circle></svg></span>Indev</a>
                                    <ul>
                                        <li id="Import_DSR" runat="server"><a href="#">DSR</a>
                                            <ul>
                                                <li id="Li26" runat="server"><a href="../INDEV/Imp_DSR_Entry.aspx" target="maineroyal"
                                                    onclick="win_close();">DSR Entry</a></li>
                                                <li id="Imp_DSR_Stagewise" runat="server"><a href="../INDEV/INDEV_DSR_Stage_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">DSR Stagewise</a></li>
                                            </ul>
                                        </li>
                                        <li id="Import_Nissan" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li id="Job_Completed_Status" runat="server"><a href="../INDEV/Imp_Job_CompletedStatus.aspx"
                                                    target="maineroyal" onclick="win_close();">Job Completed Status</a></li>
                                                <li id="Itemwise_Rpt" runat="server"><a href="../INDEV/Imp_ItemWise_chk_Rpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Itemwise Rpt</a></li>
                                                <li id="Monthly_Rpt" runat="server"><a href="../INDEV/INDEV_NISSAN_Imp_MonthWise_chk_Rpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Monthly Rpt</a></li>
                                                <li id="FTA_Rpt" runat="server"><a href="../INDEV/INDEV_NISSAN_FTA_Rpt.aspx" target="maineroyal"
                                                    onclick="win_close();">FTA Rpt</a></li>
                                                <li id="DSR_Rpt" runat="server"><a href="../INDEV/Imp_DSR_Rpt.aspx" target="maineroyal"
                                                    onclick="win_close();">DSR Rpt</a></li>
                                                <li id="Rack_Rpt" runat="server"><a href="../INDEV/Imp_DSR_Rack_Rpt.aspx" target="maineroyal"
                                                    onclick="win_close();">Rack Rpt</a></li>
                                                <li id="Summary_Rpt" runat="server"><a href="../INDEV/Imp_DSR_Summary_Rpt.aspx" target="maineroyal"
                                                    onclick="win_close();">Summary Rpt</a></li>
                                            </ul>
                                        </li>
                                        <li id="Export_Nissan" runat="server"><a href="#">Export</a>
                                            <ul>
                                                <li id="Part_Level_Data" runat="server"><a href="../INDEV/INDEV_NISSAN_EXP_PART_LEVEL_DATA_Rpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Part Level Data</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li id="Expo_Freight" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="7" width="13" height="10" rx="1"></rect><path d="M16 10h3l2 3v4h-5"></path><circle cx="7" cy="19" r="1.5"></circle><circle cx="18" cy="19" r="1.5"></circle></svg></span>Expo</a>
                                    <ul>
                                        <li id="Expo_Imp" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li id="Li22" runat="server"><a href="../Expo_Freight/Imp_Inv_Rpt.aspx" target="maineroyal"
                                                    onclick="win_close();">Item Report</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li id="Sudharsan_Cargo" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="7" width="13" height="10" rx="1"></rect><path d="M16 10h3l2 3v4h-5"></path><circle cx="7" cy="19" r="1.5"></circle><circle cx="18" cy="19" r="1.5"></circle></svg></span>Sudharsan</a>
                                    <ul>
                                        <li id="Sudharsan_Import" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li id="Delivery_Chellan_Sudharsan" runat="server"><a href="#" onclick="openGenericModal('../Transaction/Delivery_Challen_Details_Sudharsan.aspx', 990, 545); return false;">
                                                    Delivery- Challan Sudharsan</a></li>
                                                <li id="Li_Imp_Rpt" runat="server"><a href="../Sudharsan_Rpt/Import_Report.aspx"
                                                    target="maineroyal" onclick="win_close();">MIS Report</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li id="Sanco" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="7" width="13" height="10" rx="1"></rect><path d="M16 10h3l2 3v4h-5"></path><circle cx="7" cy="19" r="1.5"></circle><circle cx="18" cy="19" r="1.5"></circle></svg></span>Sanco</a>
                                    <ul>
                                        <li id="Li32" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li id="Imp_Delivery_Chellan" runat="server"><a href="../Import_Report/Imp_DeliveryChallan_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Delivery Chellan</a></li>
                                                <li id="Li_BMW_Rpt" runat="server"><a href="#" onclick="openGenericModal('../Import_Report/Import_BMW_Rpt_SANCO.aspx', 1150, 615); return false;">
                                                    BMW Rpt</a></li>
                                                <li id="Li_imp_Voucher" runat="server"><a href="../Import_Report/Voucher_Creation_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Voucher Creation</a></li>
                                            </ul>
                                        </li>
                                        <li id="Li59" runat="server"><a href="#">Export</a>
                                            <ul>
                                                <li id="Li_Voucher_Creation" runat="server"><a href="../Export_Report/Voucher_Creation_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Voucher Creation</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li id="ICC_Cargo" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="7" width="13" height="10" rx="1"></rect><path d="M16 10h3l2 3v4h-5"></path><circle cx="7" cy="19" r="1.5"></circle><circle cx="18" cy="19" r="1.5"></circle></svg></span>ICC_Cargo</a>
                                    <ul>
                                        <li id="Li34" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li id="Li_Imp_Clearance_ICC" runat="server"><a href="../International_Cargo/Import_ClearanceRpt_ICC_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Import Clearance</a></li>
                                                <li id="Li_Classic_DSR" runat="server"><a href="../International_Cargo/Imp_Classic_DSR_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Classic DSR</a></li>
                                                <li id="Li_Imp_Clearance_His" runat="server"><a href="../Paramount/Imp_Job_Clearance_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Clearance History</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li id="Freight_Log" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="7" width="13" height="10" rx="1"></rect><path d="M16 10h3l2 3v4h-5"></path><circle cx="7" cy="19" r="1.5"></circle><circle cx="18" cy="19" r="1.5"></circle></svg></span>Freight_Log</a>
                                    <ul>
                                        <li id="Li43" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li id="Li_Imp_Clearance_His_Freight" runat="server"><a href="../Paramount/Imp_Job_Clearance_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Clearance History</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li id="Para_Mount" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="7" width="13" height="10" rx="1"></rect><path d="M16 10h3l2 3v4h-5"></path><circle cx="7" cy="19" r="1.5"></circle><circle cx="18" cy="19" r="1.5"></circle></svg></span>Para</a>
                                    <ul>
                                        <li id="Para_Exp" runat="server" visible="false"><a href="#">Export</a>
                                            <ul>
                                                <li id="Exp_Clearance_His" runat="server"><a href="../Paramount/Exp_Job_Clearance_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Clearance History</a></li>
                                                <li id="Exp_DSR_Rpt" runat="server"><a href="../Paramount/Job_Clearance_History_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">DSR Report</a></li>
                                                <li id="Li_exp_Tallyexcel" runat="server"><a href="../Paramount/Export_TALLY_Excel_Format_PARA.aspx"
                                                    target="maineroyal" onclick="win_hide();">Tally -Excel</a></li>
                                            </ul>
                                        </li>
                                        <li id="Para_Import" runat="server" visible="false"><a href="#">Import</a>
                                            <ul>
                                                <li id="Para_Imp_License_Rpt" runat="server"><a href="../BAS_Shipping/Import_License_Report.aspx"
                                                    target="maineroyal" onclick="win_close();">License Report</a></li>
                                                <li id="Para_Imp_Lic_Summ_Rpt" runat="server" visible="false"><a href="../BAS_Shipping/Import_License_Summary_Report.aspx"
                                                    target="maineroyal" onclick="win_hide();">License Summary Rpt</a></li>
                                                <li id="Imp_Clearance_His" runat="server"><a href="../Paramount/Imp_Job_Clearance_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Clearance History</a></li>
                                                <li id="liDSR_Entry" runat="server"><a href="../DSR/DSR_Imp_Job_Search.aspx" target="maineroyal"
                                                    onclick="win_close();">DSR Entry</a></li>
                                                <li id="LiDynamicTmp" runat="server"><a href="../DSR_Template/DSRDynamicTmpSearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Dynamic RPT Create</a></li>
                                                <li id="LiDSRDynamicReport" runat="server"><a href="../DSR_Template/DSRDynamicReport.aspx"
                                                    target="maineroyal" onclick="win_close();">Dynamic Report</a></li>
                                                <li id="Li_Tallyexcel" runat="server"><a href="../Paramount/Import_TALLY_Excel_Format_PARA.aspx"
                                                    target="maineroyal" onclick="win_hide();">Tally -Excel</a></li>
                                                <li id="Li_DO_Entry" runat="server"><a href="../Paramount/DO_Entry_Search.aspx" target="maineroyal"
                                                    onclick="win_close();">DO Entry</a></li>
                                                <li id="Li_CFS_Entry" runat="server"><a href="../Paramount/CFS_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">CFS Entry</a></li>
                                                <li id="Li_AAI_Entry" runat="server"><a href="../Paramount/AAI_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">AAI Entry</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li id="Bas_Ship" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="7" width="13" height="10" rx="1"></rect><path d="M16 10h3l2 3v4h-5"></path><circle cx="7" cy="19" r="1.5"></circle><circle cx="18" cy="19" r="1.5"></circle></svg></span>Bas</a>
                                    <ul>
                                        <li id="Bas_Exp" runat="server" visible="true"><a href="#">Export</a>
                                            <ul>
                                                <li id="Bas_exp_Tallyexcel" runat="server"><a href="../Paramount/Export_TALLY_Excel_Format_PARA.aspx"
                                                    target="maineroyal" onclick="win_hide();">Tally -Excel</a></li>
                                            </ul>
                                        </li>
                                        <li id="Bas_Import" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li id="Job_Completed_Status_Bas" runat="server"><a href="../INDEV/Imp_Job_CompletedStatus.aspx"
                                                    target="maineroyal" onclick="win_close();">Job Completed Status</a></li>
                                                <li id="Imp_License_Rpt" runat="server"><a href="../BAS_Shipping/Import_License_Report.aspx"
                                                    target="maineroyal" onclick="win_close();">License Report</a></li>
                                                <%-- <li id="Imp_Lic_Summ_Rpt" runat="server"><a href="../BAS_Shipping/Imp_License_Summary_rpt.aspx"
                                            target="maineroyal" onclick="win_hide(); OpenPopupLicenseSummaryReport();return false;">License Summary Rpt</a></li>--%>
                                                <li id="Imp_Lic_Summ_Rpt" runat="server"><a href="../BAS_Shipping/Import_License_Summary_Report.aspx"
                                                    target="maineroyal" onclick="win_hide();">License Summary Rpt</a></li>
                                                <li id="Imp_DutyWorkSht" runat="server"><a href="../BAS_Shipping/WSheet_General.aspx"
                                                    target="maineroyal" onclick="win_close();">Duty WorkSheet</a></li>
                                                <li id="Imp_Demurrage_Rpt" runat="server"><a href="../BAS_Shipping/IMP_Demurrage_rpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Demurrage Rpt</a></li>
                                                <li id="Bas_Imp_DSR" runat="server"><a href="../BAS_Shipping/Daily_Status_Report.aspx"
                                                    target="maineroyal" onclick="win_close();">DSR Rpt</a></li>
                                                <li id="Tally_Excel" runat="server"><a href="../BAS_Shipping/Import_TALLY_Excel_Format.aspx"
                                                    target="maineroyal" onclick="win_hide();">Tally -Excel</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li id="Front_Man" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="7" width="13" height="10" rx="1"></rect><path d="M16 10h3l2 3v4h-5"></path><circle cx="7" cy="19" r="1.5"></circle><circle cx="18" cy="19" r="1.5"></circle></svg></span>Front Man</a>
                                    <ul>
                                        <li id="Li_Tallyexcel_FrontMan" runat="server"><a href="../BAS_Shipping/Import_TALLY_Excel_Format.aspx"
                                            target="maineroyal" onclick="win_hide();">Tally - Import Excel</a></li>
                                        <li id="Li_TallyexcelExport_FrontMan" runat="server"><a href="../BAS_Shipping/Export_TALLY_Excel_Format.aspx"
                                            target="maineroyal" onclick="win_hide();">Tally - Export Excel</a></li>
                                    </ul>
                                </li>
                                <li id="Li_Atlantic" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="7" width="13" height="10" rx="1"></rect><path d="M16 10h3l2 3v4h-5"></path><circle cx="7" cy="19" r="1.5"></circle><circle cx="18" cy="19" r="1.5"></circle></svg></span>Atlantic</a>
                                    <ul>
                                        <li id="Li_DSR_Report" runat="server"><a href="../Paramount/Job_Clearance_History_Search.aspx"
                                            target="maineroyal" onclick="win_close();">DSR Report</a></li>
                                    </ul>
                                </li>
                                <li id="Billing" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><path d="M6 3h12v18l-3-2-3 2-3-2-3 2V3z"></path><line x1="9" y1="8" x2="15" y2="8"></line><line x1="9" y1="12" x2="15" y2="12"></line></svg></span>Sales Billing</a>
                                    <ul>
                                        <li id="Bill_Master" runat="server"><a href="#">Master</a>
                                            <ul>
                                                <li id="LiGST_BILLING_Bill_from_COMPANY_MASTER" runat="server"><a href="../GST_Billing_Master/Company_Info_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Company Master</a></li>
                                                <li id="Li_Party_Master" runat="server"><a href="../GST_Billing_Master/Party_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Party Master</a></li>
                                                <li id="Li_Credit_Limit" runat="server"><a href="../GST_Billing_Master/Party_Credit_Limit_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Credit Limit</a></li>
                                                <li id="Charge_Master" runat="server"><a href="../GST_Billing_Master/Charge_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Income Ledger</a></li>
                                                <li id="QuotationNew" runat="server"><a href="../GST_Billing_Master/Quotation_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Quotation Master</a></li>
                                                <li id="LiPreviousCrDr" runat="server"><a href="../Billing_Imp/PreviousCrDrEntrySearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Previous Dr Cr Entry</a></li>
                                                <li id="Expense_Charge_Master" runat="server" visible="false"><a href="../GST_Billing_Master/Expense_Charge_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Expense Ledger</a></li>
                                                <li id="LiVendor_Master" runat="server" visible="false"><a href="../GST_Billing_Master/Vendor_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Vendor Master</a></li>
                                                <li id="Staff_Master" runat="server" visible="false"><a href="../GST_Billing_Master/Staff_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Staff Master</a></li>
                                                <li id="Staff_Master_previouscrdt_debit" runat="server" visible="false"><a href="../GST_Billing_Master/Staff_Master_prvscr_debit_entrySearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Staff Prev Dr Cr entry</a></li>
                                                <li id="Staff_Suspense_entry" runat="server" visible="false"><a href="../GST_Billing_Master/Staff_Suspense_entrySearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Staff Suspense entry</a></li>
                                            </ul>
                                        </li>
                                        <li id="LiTransportBillEntry" runat="server" visible="false"><a href="../Billing_Transport/GST_Transport_Inv_Job_Search.aspx"
                                            target="maineroyal" onclick="win_close();">Transport Bill Entry</a></li>
                                        <li id="ExpPaymentEntry" runat="server"><a href="../Billing_Imp/ExpensesPaymentEntrySearch.aspx"
                                            target="maineroyal" onclick="win_close();">Job Expense Entry</a></li>
                                        <li id="Job_ExpenseEntry" runat="server" visible="false"><a href="../Billing_Imp/ExpPaymentEntrySearchCombined.aspx"
                                            target="maineroyal" onclick="win_close();">Expense Entry New</a></li>
                                        <li id="PurchaseEntry" runat="server" visible="false"><a href="../Billing_Imp/PurchaseEntrySearch.aspx"
                                            target="maineroyal" onclick="win_close();">Purchase Entry</a></li>
                                        <li id="Imp_Bill" runat="server"><a href="#">Billing Import</a>
                                            <ul>
                                                <li id="GST_Imp_Bill" runat="server"><a href="../Billing_Imp/GST_Imp_Invoice_Job_Search.aspx"
                                                    target="maineroyal">GST Bill</a></li>
                                                <li id="GST_Imp_Bill_CreditNote" runat="server" visible="false"><a href="../Billing_Imp_Credit_Note/Credit_Note_Search.aspx"
                                                    target="maineroyal">Credit Note</a></li>
                                                <li id="GST_Imp_Sum_Rpt" runat="server"><a href="../Billing_Imp_Rpt/GST_Bill_Import_Summary_Report.aspx"
                                                    target="maineroyal">GST Summary Report</a></li>
                                                <li id="GST_Imp_GSTR1_B2B" runat="server"><a href="../Billing_Imp_Rpt/GST_Bil_Imp_GSTR1_B2B_Rpt.aspx"
                                                    target="maineroyal">GSTR1 B2B Rpt</a></li>
                                                <%--   <li id="GST_Imp_Stmt_Rpt" runat="server"><a href="../Billing_Imp_Rpt/GST_Imp_Invoice_Head_Rpt.aspx"
                                            target="maineroyal">Stmt/Head Report</a></li>  --%>
                                                <%-- <li id="LiTally" runat="server" visible="false"><a href="../TallyPost/TallyPost.aspx"
                                            target="maineroyal" onclick="win_close();">Tally Link</a></li>--%>
                                                <li id="LiTally" runat="server"><a href="../TallyPost/TallyPost_FTP.aspx" target="maineroyal"
                                                    onclick="win_close();">Tally Link</a></li>
                                                <li id="Imp_Bill_Invoice" runat="server"><a href="../Billing_Imp/Imp_Invoice_Job_Search.aspx"
                                                    target="maineroyal">Invoice Bill</a></li>
                                                <li id="Imp_Service_Tax" runat="server"><a href="../Billing_Imp_Rpt/Imp_Servicetax_Rpt.aspx"
                                                    target="maineroyal">Service Tax Rpt</a></li>
                                                <li id="Imp_Exp_Service_Tax" runat="server"><a href="../Billing/Imp_Exp_Servicetax_Rpt.aspx"
                                                    target="maineroyal">Imp_Exp Service Tax Rpt</a></li>
                                            </ul>
                                        </li>
                                        <li id="Exp_Bill" runat="server"><a href="#">Billing Export</a>
                                            <ul>
                                                <li id="GST_Exp_Bill_Invoice" runat="server"><a href="../Billing_Exp/GST_Exp_Invoice_Job_Search.aspx"
                                                    target="maineroyal">GST Bill</a></li>
                                                <li id="GST_Exp_Bill_CreditNote" runat="server" visible="false"><a href="../Billing_Exp_Credit_Note/Exp_Credit_Note_Search.aspx"
                                                    target="maineroyal">Credit Note</a></li>
                                                <li id="GST_Exp_Sum_Rpt" runat="server"><a href="../Billing_Exp_Rpt/GST_Bill_Export_Summary_Report.aspx"
                                                    target="maineroyal">GST Summary Report</a></li>
                                                <li id="GST_Exp_GSTR1_B2B" runat="server"><a href="../Billing_Exp_Rpt/GST_Bil_Exp_GSTR1_B2B_Rpt.aspx"
                                                    target="maineroyal">GSTR1 B2B Rpt</a></li>
                                                <li id="Li_TallyExport" runat="server"><a href="../TallyPost/EXPORT_TallyPost_FTP.aspx"
                                                    target="maineroyal" onclick="win_close();">Tally Link</a></li>
                                                <%--  <li id="GST_Exp_Stmt_Rpt" runat="server"><a href="../Billing_Exp_Rpt/GST_Exp_Invoice_Head_Rpt.aspx"
                                            target="maineroyal">Stmt/Head Report</a></li>  --%>
                                                <li id="Exp_Bill_Invoice" runat="server"><a href="../Billing_Exp/Exp_Invoice_Job_Search.aspx"
                                                    target="maineroyal">Export Bill</a></li>
                                            </ul>
                                        </li>
                                        <%--<li id="ExpPaymentEntry" runat="server"><a href="../Billing_Imp/ExpensesPaymentEntrySearch.aspx"
                                    target="maineroyal" onclick="win_close();">Exp-Payment</a></li> --%>
                                        <li id="Li_Receipt_Entry" runat="server" visible="false"><a href="../Billing_Imp/ReceiptEntrySearch.aspx"
                                            target="maineroyal" onclick="win_close();">Receipt Entry</a></li>
                                        <li id="Li_Payment" runat="server" visible="false"><a href="../Billing_Imp/PaymentEntrySearch.aspx"
                                            target="maineroyal" onclick="win_close();">Payment Entry</a></li>
                                        <li id="Li_Journal" runat="server" visible="false"><a href="../Billing_Imp/JournalEntrySearch.aspx"
                                            target="maineroyal" onclick="win_close();">Journal Entry</a></li>
                                        <li id="Li_Contra" runat="server" visible="false"><a href="../Billing_Imp/ContraVoucherEntrySearch.aspx"
                                            target="maineroyal" onclick="win_close();">Contra Voucher</a></li>
                                        <li id="Li_Credit_Note" runat="server" visible="false"><a href="../Billing_Imp/CreditNoteSearch.aspx"
                                            target="maineroyal" onclick="win_close();">Credit Note</a></li>
                                        <li id="Li_Debit_Note" runat="server" visible="false"><a href="../Billing_Imp/DebitNoteSearch.aspx"
                                            target="maineroyal" onclick="win_close();">Debit Note</a></li>
                                        <%--
                                <li id="LiPreviousCrDr" runat="server"><a href="../Billing_Imp/PreviousCrDrEntrySearch.aspx"
                                    target="maineroyal" onclick="win_close();">PreviousCrDrEntrySearch</a></li> 
                                        --%>
                                        <li id="Covering_Letter" runat="server"><a href="../Billing/Covering_Letter_Search.aspx"
                                            target="maineroyal" onclick="win_close();">Covering Letter</a></li>
                                        <li id="Covering_Letter_Pegasus" runat="server"><a href="../Billing/Covering_Letter_Search_Pegasus.aspx"
                                            target="maineroyal" onclick="win_close();">Covering Letter</a></li>
                                        <li id="Covering_Letter_Vaishnavi" runat="server"><a href="../Billing/Covering_Letter_Search_Vaishnavi.aspx"
                                            target="maineroyal" onclick="win_close();">Covering Letter</a></li>
                                        <li id="GST_Bill_Rpt" runat="server"><a href="#">Report</a>
                                            <ul>
                                                <li id="GST_Stmt_Rpt" runat="server"><a href="../Billing_Imp_Exp_GST_Rpt/GST_Imp_Invoice_Head_Rpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Sales Headwise Rpt</a></li>
                                                <li id="LiSalesRpt" runat="server"><a href="../ACC_ExpReceipt_Rpt/SalesStatmentRpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Sales Statement</a></li>
                                                <li id="LiExpensesDetails" runat="server" visible="true"><a href="../ACC_ExpReceipt_Rpt/ExpensesEntryRpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Expenses Details</a></li>
                                                <li id="LiProfitgRpt" runat="server" visible="true"><a href="../ACC_ExpReceipt_Rpt/ProfitStatementRpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Profit Statement</a></li>
                                                <li id="LiReceiptDetails" runat="server"><a href="../ACC_ExpReceipt_Rpt/ReceiptEntryRpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Receipt Details</a></li>
                                                <li id="LiTDSRpt" runat="server"><a href="../ACC_ExpReceipt_Rpt/TDSRpt.aspx" target="maineroyal"
                                                    onclick="win_close();">TDS Report</a></li>
                                                <li id="LiConOSRpt" runat="server" visible="false"><a href="../ACC_ExpReceipt_Rpt/OutstandingCrDrRpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Combined Dr/Cr Stmt</a></li>
                                                <li id="LiOustandingRpt" runat="server"><a href="../ACC_ExpReceipt_Rpt/OutstandingStatmentRpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Billing Outstanding Stmt</a></li>
                                                <li id="LiOPayustandingRpt" runat="server" visible="false"><a href="../ACC_ExpReceipt_Rpt/PaymentOutstandingRpt.aspx"
                                                    target="maineroyal" onclick="win_close();">Payment Outstanding Report</a></li>
                                            </ul>
                                        </li>
                                        <li id="GST_Bill_Consolidate" runat="server"><a href="#">Consolidate Rpt</a>
                                            <ul>
                                                <li id="GST_Consolidate_Rpt" runat="server"><a href="../Billing_Imp_Exp_GST_Rpt/Bill_Consolidate_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Consolidate Rpt</a></li>
                                            </ul>
                                        </li>
                                        <li id="GST_Combined_Bill" runat="server" visible="false"><a href="#">Combined Bill</a>
                                            <ul>
                                                <li id="GST_Bill_Combined" runat="server"><a href="../Billing_Imp_Exp_GST_Rpt/GST_Imp_Exp_Invoice_Job_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Combined Bill</a></li>
                                            </ul>
                                        </li>
                                        <li id="GST_Combined_Bill_Para" runat="server" visible="false"><a href="#">Combined
                                            Bill</a>
                                            <ul>
                                                <li id="GST_Bill_Combined_Para" runat="server"><a href="../Billing_Paramount/GST_Imp_Exp_Invoice_Job_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Combined Bill</a></li>
                                                <li id="Combined_Bill_Rpt" runat="server"><a href="../Billing_Imp_Exp_GST_Rpt/GST_Bill_Imp_Exp_Data.aspx"
                                                    target="maineroyal" onclick="win_close();">Combined Bill Rpt</a></li>
                                            </ul>
                                        </li>
                                        <li id="Tally_Data_Pioneer" runat="server"><a href="../Billing_Imp_Exp_GST_Rpt/GST_Imp_Exp_Pioneer_Tally_Data.aspx"
                                            target="maineroyal" onclick="win_close();">Tally Data</a></li>
                                    </ul>
                                </li>
                                <li id="Accounts" visible="false" runat="server"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="3" y="6" width="18" height="13" rx="2"></rect><path d="M3 10h18"></path><circle cx="17" cy="14" r="1"></circle></svg></span>Accounts</a>
                                    <ul>
                                    <li id="Li19" runat="server"><a href="../Accounts_Report_Dashboard/Accounts_Dashboard.aspx"
                                                    target="maineroyal" onclick="win_close();">Accounts Dashboard</a></li>
                                        <li id="Li60" runat="server"><a href="#">Master</a>
                                            <ul>
                                            <li id="Li90" runat="server"><a href="../Accounts_Master/Acc_Chart_Of_Accounts.aspx"
                                                    target="maineroyal" onclick="win_close();">Chart of Accounts</a></li>
                                                <li id="Li_Compnay_Master" runat="server"><a href="../Accounts_Master/Acc_Company_Info_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Company Info Master</a></li>
                                                <li id="Li_Staff_Master" runat="server"><a href="../Accounts_Master/Staff_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Staff Master</a></li>
                                                <li id="Li64" runat="server"><a href="../Accounts_Master/Group_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Group Master</a></li>
                                                <li id="Li3" runat="server"><a href="../Accounts_Master/Bank_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Bank Master</a></li>
                                                <li id="Li80" runat="server"><a href="../Accounts_Master/Capital_Account_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Capital Account</a></li>
                                                <li id="Li87" runat="server"><a href="../Accounts_Master/Billing_Party_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Bill Party</a></li>
                                                <li id="Li65" runat="server"><a href="../Accounts_Master/Party_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Party Master</a></li>
                                                <li id="Li67" runat="server"><a href="../Accounts_Master/Charge_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Income Ledger</a></li>
                                                <li id="Li70" runat="server"><a href="../Accounts_Master/Expense_Charge_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Expense Ledger</a></li>
                                                <li id="Li71" runat="server"><a href="../Accounts_Master/Vendor_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Vendor Master</a></li>
                                                <li id="Li68" runat="server"><a href="../Accounts_Master/Quotation_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Quotation Master</a></li>
                                                <li id="LiBank_Master" runat="server" visible="false"><a href="../GST_Billing_Master/Bank_Master_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Bank Master</a></li>
                                                    <li id="Li91" runat="server"><a href="../Accounts_Master/Acc_Charges_Master_N_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Charge Mater </a></li>
                                            </ul>
                                        </li>
                                        <%-----------------------------------------%>
                                        <li id="Li_Cash" runat="server"><a href="#">Cash</a>
                                            <ul>
                                                <li id="Li83" runat="server"><a href="../Accounts_Cash/Cash_Payment_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Payment Entry</a></li>
                                                <li id="Li103" runat="server"><a href="../Accounts_Cash/Receipt_Payment_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Recepit Entry</a></li>
                                            </ul>
                                        </li>
                                        <%-----------------------------------------%>
                                        <li id="Li_Bank" runat="server"><a href="#">Bank</a>
                                            <ul>
                                            <li id="Li95" runat="server"><a href="../Accounts_Bank/ACC_ReceiptEntrySearch.aspx"
                                                   target="maineroyal" onclick="win_close();">Receipt Entry</a></li>
                                                <%--<li id="Li72" runat="server"><a href="../Accounts_Bank/ReceiptEntrySearch.aspx" target="maineroyal"
                                                    onclick="win_close();">Receipt Entry</a></li>--%>
                                                <%--<li id="Li78" runat="server"><a href="../Accounts_Bank/PaymentEntrySearch.aspx" target="maineroyal"
                                                    onclick="win_close();">Payment</a></li>--%>
                                                    <li id="Li72" runat="server"><a href="../Accounts_Bank/Acc_PaymentEntrySearch.aspx" target="maineroyal"
                                                    onclick="win_close();">Payment</a></li>
                                                <li id="Li62" runat="server"><a href="../Accounts_Bank/Bank_Reconciliation_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Reconciliation</a></li>
                                                    <li id="Li78" runat="server"><a href="../Accounts_Bank/Settlement_Search_Entry.aspx"
                                                    target="maineroyal" onclick="win_close();">Settlement Entry</a></li>
                                            </ul>
                                        </li>
                                        <%-----------------------------------------%>
                                        <li id="Li_Purchase" runat="server"><a href="#">Purchase</a>
                                            <ul>
                                                <li id="Li61" runat="server"><a href="../Accounts_Purchase/PurchaseEntrySearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Purchase</a></li>
                                                    <li id="Li92" runat="server"><a href="../Accounts_Purchase/Acc_PurchaseBillSearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Purchase New</a></li>
                                            </ul>
                                        </li>
                                        <%-----------------------------------------%>
                                        <%-- 
                                        <li id="Li_Billing" runat="server"><a href="#">Billing</a>
                                            <ul>
                                                 <li id="Li69" runat="server"><a href="../Accounts_Sales/GST_Sales_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Sales Entry</a></li>
                                                    <li id="Li63" runat="server"><a href="../Accounts_Sales/E_Inv_Cancellation_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">e Invoice Cancellation</a></li>
                                            </ul>
                                        </li>--%>
                                        <li id="Li_Billing" runat="server"><a href="#">Billing</a>
                                            <ul>
                                            <li id="Li7" runat="server"><a href="../Accounts_Sales_old/GST_Sales_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Sales Entry old</a></li>
                                                <li id="Li69" runat="server"><a href="../Accounts_Sales/GST_Sales_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Sales Entry New</a></li>
                                                <li id="Li84" runat="server"><a href="../Accounts_Others_Entry/Acc_Bill_To_Party_Others_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Other Jobs Entry</a></li>
                                                <li id="Li63" runat="server"><a href="../Accounts_Sales/E_Inv_Cancellation_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">e Invoice Cancellation</a></li>
                                                    <li id="Li89" runat="server"><a href="../Accounts_Others/Shipment_Details_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">ShipmentNo History</a></li>
                                                    <li id="Li93" runat="server"><a href="../Accounts_Sales/Accounts_Unbilled_Jobs_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Unbilled Jobs</a></li>
                                            </ul>
                                        </li>
                                        <%-----------------------------------------%>
                                        <li id="Li_Other" runat="server"><a href="#">Other</a>
                                            <ul>
                                                <li id="Li81" runat="server"><a href="../Accounts_Others/Journal_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Journal Entry</a></li>
                                                    <li id="Li8" runat="server"><a href="../Accounts_Others/Acc_Journal_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Journal Entry New</a></li>
                                                <li id="Li75" runat="server"><a href="../Accounts_Sales/GST_Credit_Note_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Credit Note</a></li>
                                                <li id="Li77" runat="server"><a href="../Accounts_Purchase/DebitNoteEntrySearch.aspx"
                                                    target="maineroyal" onclick="win_close();">Debit Note</a></li>
                                                <li id="Li85" runat="server"><a href="../Accounts_Others/Payment_Request_Search_Entry.aspx"
                                                    target="maineroyal" onclick="win_close();">Payment Request</a></li>
                                                <li id="Li66" runat="server"><a href="../Accounts_Others/Approval_Request_Search_Entry.aspx"
                                                    target="maineroyal" onclick="win_close();">Approval Request</a></li>
                                                <li id="Li76" runat="server"><a href="../Accounts_Expense/Expense_Payment_Entry_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">Expense Entry</a></li>
                                            </ul>
                                        </li>
                                        <li id="Li_Rep_Dash" runat="server"><a href="../Accounts_Report_Dashboard\Acc_Rpt_Dashboard.aspx"
                                            target="maineroyal" onclick="win_close();">Reports Dashboard</a></li>
                                    </ul>
                                </li>
                                <li id="AWB" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><rect x="4" y="4" width="16" height="16" rx="2"></rect><line x1="8" y1="9" x2="16" y2="9"></line><line x1="8" y1="13" x2="16" y2="13"></line><line x1="8" y1="17" x2="12" y2="17"></line></svg></span>AWB</a>
                                    <ul>
                                        <li id="Li20" runat="server"><a href="#">Export</a>
                                            <ul>
                                                <li id="Li17" runat="server"><a href="../Air_WayBill/EXP_Air_WayBill_Search.aspx"
                                                    target="maineroyal" onclick="win_close();">AWB Preparation</a></li>
                                            </ul>
                                        </li>
                                    </ul>
                                </li>
                                <li id="ODEX" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><circle cx="12" cy="12" r="9"></circle><line x1="3" y1="12" x2="21" y2="12"></line><path d="M12 3a14 14 0 010 18a14 14 0 010-18z"></path></svg></span>ODEX</a>
                                    <ul>
                                        <%--<li id="Li171" runat="server"><a href="../ODEX/e_VGM_Request_Job_Search.aspx" target="maineroyal"
                                            onclick="win_close();">e-VGM Request</a></li>--%>
                                            <li id="Li171" runat="server"><a href="../ODEX/e_VGM_List_Search.aspx" target="maineroyal"
                                            onclick="win_close();">e-VGM Request</a></li>
                                             <li id="Li94" runat="server"><a href="../ODEX/Form13_List_Search.aspx" target="maineroyal"
                                            onclick="win_close();">e-Form 13 Request</a></li>
                                    </ul>
                                </li>
                                <li id="FF_NewAge" runat="server" visible="false"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><path d="M12 3l1.8 5.2L19 10l-5.2 1.8L12 17l-1.8-5.2L5 10l5.2-1.8L12 3z"></path></svg></span>NewAge</a>
                                    <%--  <ul>
                                <li id="FF_Import" runat="server"><a href="../NewAge_XML/Import_Flat_File_Generation.aspx"
                                    target="maineroyal" onclick="win_close();">Import</a></li>
                                <li id="FF_Export" runat="server"><a href="../NewAge_XML/Export_FlatFile_Generation.aspx"
                                    target="maineroyal" onclick="win_close();">Export</a></li>
                            </ul>--%>
                                    <ul>
                                        <li id="FF_Import" runat="server"><a href="../NewAge_XML/FF_IMP_XML_FTPUPLOAD.aspx"
                                            target="maineroyal" onclick="win_close();">Import</a></li>
                                        <li id="FF_Export" runat="server"><a href="../NewAge_XML/FF_EXP_XML_FTPUPLOAD.aspx"
                                            target="maineroyal" onclick="win_close();">Export</a></li>
                                    </ul>
                                </li>
                                <li id="Royal_Admin_Id" runat="server"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><path d="M12 3l7 3v6c0 5-3.5 8-7 9-3.5-1-7-4-7-9V6l7-3z"></path></svg></span>Admin Master</a>
                                    <ul>
                                        <li id="Adm_Common" runat="server"><a href="#">Common</a>
                                            <ul>
                                                <li><a href="../ERoyal_Admin_Master/Exchange_Master_Search.aspx" target="maineroyal"
                                                    onclick="win_close();">Exchange Rate</a></li>
                                                <li id="LiExchangeRate" runat="server"><a href="../ERoyal_Admin_Master/ExchangeRateUpdate.aspx"
                                                    target="maineroyal" onclick="win_close();">Exchange Rate Update</a></li>
                                                <li><a href="../ERoyal_Admin_Master/Country_Master.aspx" target="maineroyal" onclick="win_close();">
                                                    Country Master </a></li>
                                                <li><a href="../ERoyal_Admin_Master/Customs_Master.aspx" target="maineroyal" onclick="win_close();">
                                                    Customs Master </a></li>
                                                <li><a href="../ERoyal_Admin_Master/CustomHouse_Master.aspx" target="maineroyal"
                                                    onclick="win_close();">Custom House Master </a></li>
                                                <%-- <li><a href="../ERoyal_Admin_Master/Location_Master.aspx" target="maineroyal" onclick="win_close();">
                                    Location Master </a></li>--%>
                                                <li><a href="../ERoyal_Admin_Master/Package_Master.aspx" target="maineroyal" onclick="win_close();">
                                                    Package Master </a></li>
                                                <li><a href="../ERoyal_Admin_Master/Port_Master.aspx" target="maineroyal" onclick="win_close();">
                                                    Port Master </a></li>
                                                <li><a href="../ERoyal_Admin_Master/State_Master.aspx" target="maineroyal" onclick="win_close();">
                                                    State Master </a></li>
                                                <li><a href="../ERoyal_Admin_Master/Unit_Master.aspx" target="maineroyal" onclick="win_close();">
                                                    Unit Master </a></li>
                                                <li><a href="../ERoyal_Admin_Master/Notification_Updation.aspx" target="maineroyal"
                                                    onclick="win_close();">Notification Updation</a></li>
                                                <li id="Sup_Doc_Master" runat="server"><a href="../ERoyal_Admin_Master/SupportingDocCode_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">Supporting Doc. Master</a></li>
                                                <li id="Error_Code_Master" runat="server"><a href="../ERoyal_Admin_Master/Error_Code_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">Error Code Master</a></li>
                                            </ul>
                                        </li>
                                        <li id="Adm_Import" runat="server"><a href="#">Import</a>
                                            <ul>
                                                <li id="Imp_Category_Master" runat="server"><a href="../ERoyal_Admin_Master/Category_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">Category Master </a></li>
                                                <li id="Imp_CETH_Master" runat="server"><a href="../ERoyal_Admin_Master/CETH_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">CETH Master </a></li>
                                                <li id="Imp_CTH_Master" runat="server"><a href="../ERoyal_Admin_Master/CTH_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">CTH Master </a></li>
                                                <li id="Imp_NOTI_CUSTOMS_Master" runat="server"><a href="../ERoyal_Admin_Master/Notification_Customs.aspx"
                                                    target="maineroyal" onclick="win_close();">Notification Custom </a></li>
                                                <li id="Imp_NOTI_EXCISE_Master" runat="server"><a href="../ERoyal_Admin_Master/Notification_Excise.aspx"
                                                    target="maineroyal" onclick="win_close();">Notification Excise </a></li>
                                                <li id="Imp_RSP_Master" runat="server"><a href="../ERoyal_Admin_Master/RSP_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">RSP Master </a></li>
                                                <li id="Imp_WareHouse_Master" runat="server"><a href="../ERoyal_Admin_Master/Warehouse_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">WareHouse Master </a></li>
                                                <li id="Imp_AntiDumping_Master" runat="server"><a href="../ERoyal_Admin_Master/AntiDumpting_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">Anti Dumping Master </a></li>
                                                <li id="Imp_SW_Info_Master" runat="server"><a href="../ERoyal_Admin_Master/SingleWindow_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">SW Info Master </a></li>
                                                <li id="Imp_IGST_Levy1_Master" runat="server"><a href="../ERoyal_Admin_Master/IGST_Levy1_Notification.aspx"
                                                    target="maineroyal" onclick="win_close();">IGST Levy1 Master</a></li>
                                                <li id="Imp_IGST_Levy2_Master" runat="server"><a href="../ERoyal_Admin_Master/IGST_Levy2_Notification.aspx"
                                                    target="maineroyal" onclick="win_close();">IGST Levy2 Master</a></li>
                                                <li id="Imp_CTH_CETH_24_27_Master" runat="server"><a href="../ERoyal_Admin_Master/CTH_CETH_Master_24_27.aspx"
                                                    target="maineroyal" onclick="win_close();">CTH CETH 24 27</a></li>
                                                <li id="Fta_Master" runat="server"><a href="../ERoyal_Admin_Master/FTA_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">FTA Master</a></li>
                                                <li id="Aidc_Master" runat="server"><a href="../ERoyal_Admin_Master/AIDC_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">AIDC Master</a></li>
                                                <li id="Imp_Restricted_CTH" runat="server"><a href="../ERoyal_Admin_Master/Imp_Restricted_RITC_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">Restricted_CTH Master </a></li>
                                                <li id="Import_Scheme" runat="server"><a href="../ERoyal_Admin_Master/Import_Scheme_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">Import Scheme </a></li>
                                            </ul>
                                        </li>
                                        <li id="Adm_Export" runat="server"><a href="#">Export</a>
                                            <ul>
                                                <li id="Exp_Cess_Master" runat="server"><a href="../ERoyal_Admin_Master/Cess_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">CESS Master </a></li>
                                                <li id="Exp_DEPB_Master" runat="server"><a href="../ERoyal_Admin_Master/Depb_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">DEPB Master </a></li>
                                                <li id="Exp_Drawback_Master" runat="server"><a href="../ERoyal_Admin_Master/Drawback.aspx"
                                                    target="maineroyal" onclick="win_close();">Drawback Master </a></li>
                                                <li id="Exp_RITC_Master" runat="server"><a href="../ERoyal_Admin_Master/Export_RITC_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">Export RITC Master </a></li>
                                                <li id="Exp_ROSL_Master" runat="server"><a href="../ERoyal_Admin_Master/ROSL_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">ROSL Master </a></li>
                                                <li id="Exp_RODTEP_Master" runat="server"><a href="../ERoyal_Admin_Master/RODTEP_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">RODTEP Master </a></li>
                                                <li id="Exp_RODTEP_4E_Master" runat="server"><a href="../ERoyal_Admin_Master/RODTEP_4E_Master.aspx"
                                                    target="maineroyal" onclick="win_close();">RODTEP 4E Master </a></li>
                                            </ul>
                                        </li>
                                         <!-- Update by Sriman 15-04-26 ERI Support-->
                                        <li id="Adm_ERI_Support" runat="server">
                                            <a href="http://royalimpexchat.eroyalimpex.co.in:8051/admin/login" target="_blank" rel="noopener noreferrer">ERI Support Admin</a>
                                        </li>
                                        <!-- End of script -->
                                    </ul>
                                </li>
                                <li id="User_Admin_Id" runat="server"><a href="#"><span class="pm-menu-icon"><svg viewBox="0 0 24 24"><circle cx="12" cy="12" r="3"></circle><path d="M12 2v3M12 19v3M4.2 4.2l2.1 2.1M17.7 17.7l2.1 2.1M2 12h3M19 12h3M4.2 19.8l2.1-2.1M17.7 6.3l2.1-2.1"></path></svg></span>Admin</a>
                                    <ul>
                                        <li id="Company_Master_Id" runat="server"  visible="false"><a href="../Admin/Company_Master_Search.aspx"
                                            target="maineroyal" onclick="win_close();">Company Master</a> </li>
                                        <li id="User_Creation_Id" runat="server"><a href="../Users/User_Creation_Search.aspx"
                                            target="maineroyal" onclick="win_close();">User Creation</a> </li>

                                              <li id="Col_Edit_Master_Id" runat="server"><a href="#"
                                            target="maineroyal" onclick="win_hide();ColumbEditMaster(); return false;">Mandatory Edit</a> </li>
                                        <%-- <li id="Li7" runat="server">  <a href="../Users/Job_Initialization.aspx" target="maineroyal" onclick="hide();">Job Initialization</a>
                                </li>--%>
                                        <li id="Li_ErrorLogs" runat="server"  visible="false"><a href="#" onclick="openGenericModal('../Admin/Application_ErrorLogs_Report.aspx', 1150, 615); return false;">
                                            Error Logs Report</a></li>
                                        <li id="Admin_access_sql_id" runat="server"  visible="false"><a href="../Admin/Access_to_SqlServer.aspx"
                                            target="maineroyal" onclick="win_close();">Access to sql Upload</a></li>
                                        <%--<li id="Li15" runat="server"><a href="../Admin/SQLQueryExecution.aspx"
                                    target="maineroyal" onclick="hide();">User Creation</a> </li>--%>
                                        <%--<li id="Userwise_Rpt" runat="server"><a href="../Users/User_wise_Report.aspx" target="maineroyal"
                                            onclick="win_close();">User-Wise Report </a></li>--%>
                                        <li id="Userwise_Rpt" runat="server"><a href="#" onclick="openGenericModal('../Users/User_Wise_Report_New.aspx', 1150, 615); return false;">
                                            User-Wise Report</a></li>
                                        <%-- <li id="Li22" runat="server"><a href="../Admin/Sales_Statement.aspx"
                                    target="maineroyal" onclick="win_close();">Sales Statement</a> </li>--%>
                                        <%-- <li id="Retail_Sales_Id" runat="server">  <a href="../Admin/Retail_Sales_Statement.aspx" target="maineroyal" onclick="hide();">Retail Sales Report</a>--%>
                                        <li id="Retail_Sales_Id" runat="server"><a href="../Admin/Imp_Exp_Job_Count_Status.aspx"
                                            target="maineroyal" onclick="hide();">Retail Sales Report</a> </li>
                                        <li id="Userwise_JobLock_Id" runat="server"><a href="../Users/JobLock.aspx" target="maineroyal"
                                            onclick="hide();">Userwise Job Lock</a> </li>
                                        <%--   <li id="Mapping_Master" runat="server"><a href="../Admin/Mapping_Master_Search.aspx"
                                    target="maineroyal" onclick="win_close();">Mapping Master</a> </li>--%>
                                        <li id="DB_BKP" runat="server" visible="false"><a href="#" onclick="win_hide();DBBackuandrestore(); return false">
                                            Database Backup</a></li>
                                        <li id="Client_DB_BKP" runat="server" visible="false"><a href="#" onclick="win_hide();DBBackup_Client(); return false">
                                            Client Database Bkp</a> </li>
                                        <li id="All_Client_DB_Bkp" runat="server" visible="false"><a href="#" onclick="openGenericModal('../Admin/All_Clients_DB_Backup.aspx', 990, 400); return false">
                                            Combined Client DB Bkp<span id="Span1" runat="server"></span></a></li>
                                        <li id="Live_UpdationNew" runat="server"  visible="false"><a href="../Admin/Live_Updation_Notification.aspx"
                                            target="maineroyal" onclick="win_close();">Live Updation</a></li>
                                        <li id="LiAdv" runat="server"  visible="false"><a href="#" onclick="win_hide();Advertisement(); return false">
                                            Advertisement</a> </li>
                                        <%-- .Bill_wise_Invoice_Report.aspx--%>
                                        <li id="Biling_ClientMaster" runat="server"><a href="#" target="maineroyal" onclick="openGenericModal('../Billing/Billing_Company_Master.aspx', 750, 480); return false;">
                                            Billing Company Info</a></li>
                                        <li id="Job_PrefixSufix" runat="server" visible="false"><a href="../Admin/Admin_IMP_EXP_Prefix_Suffix.aspx"
                                            target="maineroyal" onclick="win_close();">Job Prefix Sufix</a></li>
                                        <li id="Job_PrefixSufix_Areawise" runat="server" visible="true"><a href="../Admin/Admin_IMP_EXP_Prefix_Suffix_Areawise.aspx"
                                            target="maineroyal" onclick="win_close();">Job Prefix Sufix New</a></li>
                                        <li id="LiRTSELMap" runat="server" visible="false"><a href="../Admin/RTS_EL_Mapping_Master_Search.aspx"
                                            target="maineroyal" onclick="win_close();">RTS/EL-Mapping Master</a> </li>
                                        <li id="Li_JobDeletedHistory" runat="server" visible="false"><a href="../Users/IMP_EXP_Job_Deleted_History_Search.aspx"
                                            target="maineroyal" onclick="win_close();">Job Deleted History</a> </li>
                                        <%--  <li id="Li_RestoreDeletedJob" runat="server"><a href="../Transaction/ImportDelJobMove.aspx"
                                    target="maineroyal" onclick="win_close();">Restore Deleted Job</a> </li>--%>
                                        <li id="Li_RestoreDeletedJob" runat="server"><a href="#">Restore Deleted Job</a>
                                            <ul>
                                                <li id="Li_RestoreDeletedJob_Imp" runat="server"><a href="../Transaction/ImportDelJobMove.aspx"
                                                    target="maineroyal" onclick="win_close();">Import</a></li>
                                                <li id="Li_RestoreDeletedJob_Exp" runat="server"><a href="../Export/Export_Del_JobMove.aspx"
                                                    target="maineroyal" onclick="win_close();">Export</a></li>
                                            </ul>
                                        </li>
                                        <li id="li_Query_Update" runat="server" visible="false"><a href="#" onclick="openGenericModal('../Admin/Query_Updation.aspx', 1100, 585); return false">
                                            Query Updation</a></li>
                                        <li id="Li_Financialyear_Creation" runat="server" visible="false"><a href="../Admin/E_Royal_Wrk_Creation_Search.aspx"
                                            target="maineroyal" onclick="win_close();">Financial year Creation</a> </li>
                                        <li id="Copper_login" runat="server" visible="false"><a href="javascript:void(0);"
                                            onclick="CopperLoginPage();">Copper_Login</a> </li>
                                        <%-- <li id="SQL_Query_Exec" runat="server">

                               <a href="#" onclick="open_SQL_Query_Execution('New'); return false"> SQL Query Execution</a>
                              
                              </li>--%>
                                    </ul>
                                </li>
                                <%--<li><a href="#">Data Recovery</a> </li>--%>
                                <%-- Sidebar Layout switcher moved into the user-chip dropdown (see
                                     "Horizontal Layout"/"Vertical Layout" above Change Password), so it
                                     no longer lives here as a top-menu item. pmApplyMenuLayout() below
                                     still works the same regardless of where the .pm-layout-option
                                     links live in the DOM. --%>
                            </ul>
                            <br style="clear: left" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="pm-body-row" id="pmBodyRow">
                <div class="pm-sidebar" id="pmSidebarPanel"></div>
                <%-- Applies the saved Horizontal/Vertical preference (Page_Load, Session["MenuLayout"])
                     RIGHT HERE - synchronously, the instant #myjquerymenu/#pmSidebarPanel exist in the
                     DOM - instead of waiting for a DOMContentLoaded/load event later in the page. That
                     earlier attempt caused a visible flash: the page rendered Horizontal (the DOM's
                     unmoved default position) for however long window.load took (all images, the
                     dashboard iframe, etc.), then suddenly jumped to Vertical. Running inline here, this
                     far up the page, moves the menu before the browser has painted anything below it.
                     pmApplyMenuLayout() (defined once, reused by the Sidebar Layout dropdown's own
                     click too) is declared just below - a plain function declaration, so calling it
                     immediately after works fine regardless of where in the page it's later called from
                     again. skipSave=true: this is applying an already-saved value, not setting a new one. --%>
                <script type="text/javascript">

                    function openAiExtraction() {
                        var w = window.open('about:blank', 'aiExtractionTab');
                        PageMethods.GetAiExtractionLaunchUrl(
                        function (url) { w.location.href = url; },
                        function (error) {
                            w.close();
                            alert('Could not open AI extraction: ' + error.get_message());
                        }
                    );
                    }

                    function pmApplyMenuLayout(mode, skipSave) {
                        var menu = document.getElementById('myjquerymenu');
                        var topmenu = document.getElementById('mainmastop1container_topmenu');
                        var sidebar = document.getElementById('pmSidebarPanel');
                        if (!menu || !topmenu || !sidebar) return;

                        if (mode === 'vertical') {
                            sidebar.appendChild(menu);
                            document.body.classList.add('pm-vertical-menu');
                            // Mirrored onto <html> too (not just <body>) so premium-theme.css's
                            // html:not(.pm-vertical-menu){overflow-y:hidden} rule (outer-scrollbar
                            // fix) can target <html> directly - once <html> itself has a non-
                            // visible overflow-x (needed for the horizontal-scrollbar fix), the
                            // CSS spec stops propagating <body>'s overflow to the viewport at all,
                            // so <body>'s own overflow-y alone can no longer control it.
                            document.documentElement.classList.add('pm-vertical-menu');
                        } else {
                            topmenu.appendChild(menu);
                            document.body.classList.remove('pm-vertical-menu');
                            document.documentElement.classList.remove('pm-vertical-menu');
                        }

                        // Close whatever submenu might currently be open - its old fixed-position
                        // coordinates no longer make sense once the menu bar itself has moved.
                        // pmCloseAllMenus (jquerycssmenu-premium.js) also restores any flyout
                        // <ul> that vertical mode had reparented out to the menu's top level
                        // back into its own <li> - plain hide() alone left it stranded there,
                        // breaking that submenu's nesting-based CSS the next time it opened.
                        // jquerycssmenu-premium.js loads near the end of the page, so guard for
                        // it not being defined yet (e.g. this very first call, at page load).
                        if (window.pmCloseAllMenus) {
                            window.pmCloseAllMenus();
                        } else if (window.jQuery) {
                            jQuery('#myjquerymenu > ul').find('ul:visible').hide();
                            jQuery('#myjquerymenu li').removeClass('pm-menu-active');
                        }

                        var options = document.querySelectorAll('.pm-layout-option');
                        for (var i = 0; i < options.length; i++) {
                            options[i].classList.toggle('on', options[i].getAttribute('data-layout') === mode);
                        }

                        // Persist the choice so it's restored on this user's next login (any browser/
                        // device) - see SavePmMenuLayout in the code-behind. skipSave=true is passed
                        // when just applying an already-saved preference, so it doesn't uselessly
                        // write the same value straight back to the DB.
                        if (!skipSave && window.PageMethods && PageMethods.SavePmMenuLayout) {
                            PageMethods.SavePmMenuLayout(mode);
                        }
                    }
                    pmApplyMenuLayout('<%= (Session["MenuLayout"] != null && Session["MenuLayout"].ToString() == "Vertical") ? "vertical" : "horizontal" %>', true);
                </script>
                <button type="button" class="pm-sidebar-toggle" id="pmSidebarToggleBtn" onclick="togglePmSidebarCollapse();" title="Collapse sidebar">
                    <svg viewBox="0 0 24 24"><polyline points="15 18 9 12 15 6"></polyline></svg>
                </button>
                <div class="pm-stage">
                    <div class="pm-stage-frame">
                        <iframe src="E_royal_Impex_Home.aspx" name="maineroyal" scrolling="auto" id="mainiframecontainer"
                            runat="server"></iframe>
                    </div>
                </div>
            </div>

            <asp:HiddenField ID="hdnBellImagePath" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdnBellCount" runat="server" ClientIDMode="Static" Value="0" />
            <div id="divBellImagePopup" class="pm-bell-overlay" onclick="if(event.target===this) CloseBellPopup();">
                <div class="pm-bell-card">
                    <div class="pm-bell-tabs">
                        <button type="button" class="pm-bell-tab on" id="pmBellTabAnn">Announcements</button>
                        <div class="pm-bell-close" onclick="CloseBellPopup()" title="Close">&#10005;</div>
                    </div>
                    <div id="pmBellPaneAnn" class="pm-bell-pane">
                        <div class="pm-bell-media">
                            <img id="imgBellDisplay" src="" alt="Announcement" />
                        </div>
                        <div id="divBellLinksFooter" runat="server" class="pm-bell-links">
                            <span class="pm-bell-links-label">For more details</span>
                            <div class="pm-bell-links-row">
                                <asp:HyperLink ID="hlBellWhatsApp" runat="server" Target="_blank" CssClass="pm-bell-link pm-bell-link-whatsapp">
                                    &#128172; WhatsApp
                                </asp:HyperLink>
                                <asp:HyperLink ID="hlDrive" runat="server" Target="_blank" CssClass="pm-bell-link pm-bell-link-drive">
                                    &#128193; Drive
                                </asp:HyperLink>
                                <asp:HyperLink ID="hlBellYoutube" runat="server" Target="_blank" CssClass="pm-bell-link pm-bell-link-youtube">
                                    &#9654;&#65039; YouTube
                                </asp:HyperLink>
                                <asp:HyperLink ID="hlBellWebsite" runat="server" Target="_blank" CssClass="pm-bell-link pm-bell-link-website">
                                    &#127760; Website
                                </asp:HyperLink>
                            </div>
                        </div>
                        <div id="divBellNoImage" class="pm-bell-empty">
                            <div class="pm-bell-empty-icon">&#128276;</div>
                            <p>No active announcement found.</p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="pm-confirm-overlay" id="pmSignOutConfirm">
                <div class="pm-confirm-card">
                    <div class="pm-confirm-icon">&#9211;</div>
                    <h3>Sign out?</h3>
                    <p>You're about to end your current session. Any unsaved work in open screens may be lost.</p>
                    <div class="pm-confirm-actions">
                        <button type="button" class="pm-btn pm-btn-ghost" onclick="closeSignOutConfirm();">Cancel</button>
                        <button type="button" class="pm-btn pm-btn-danger" onclick="closeSignOutConfirm(); Session_Clear();">Sign out</button>
                    </div>
                </div>
            </div>

            <%-- Branch Selection: same fixed-overlay + flex-centered "modal-dialog-centered" feel
                 as the Sign-out / Bell / Robot popups above, instead of the old dhtmlmodal/iframe
                 window (which relied on JS-computed screen.width/height positioning). --%>
            <div class="pm-confirm-overlay" id="pmBranchOverlay" onclick="if(event.target===this) closeBranchSelection();">
                <div class="pm-branch-modal-card">
                    <div class="pm-robot-img-close" onclick="closeBranchSelection();" title="Close">&times;</div>
                    <iframe id="pmBranchFrame" class="pm-branch-modal-frame" src="" title="Branch Selection"></iframe>
                </div>
            </div>

            <%-- Mount point for Change_Branch.aspx's "Select Group"/"Select Branch" dropdown
                 panels. An iframe hard-clips its own content to its box in the parent page -
                 no CSS inside Change_Branch.aspx can make a dropdown escape that box - so when
                 one of those panels opens, the iframe reparents the live panel element in here
                 via window.parent.pmMountBranchDropdown(...), positioned to line up exactly
                 under its field. That lets it genuinely overlap past the small popup's edge
                 (even the dark overlay) instead of being clipped or needing to scroll inside
                 the popup. Cleared by closeBranchSelection() whenever the popup itself closes. --%>
            <div id="pmBranchDropdownHost" style="position:fixed;display:none;z-index:2100;"></div>

            <%-- Generic premium centered-modal shell, reused by ~40 menu items that used to
                 open via the old dhtmlmodal/dhtmlwindow popup (js/iframepopupwin.js). Only the
                 outer chrome changes here (centered, blurred, rounded) - each target page's own
                 internal content/design is untouched. Width/height are set per call by
                 openGenericModal(). A handful of menu items are deliberately NOT converted:
                 open_DGFT_Mnaufacturer_Report (uses a real native browser window, not an
                 iframe popup) and several that were already non-functional before this change
                 (their dhtmlmodal.open call was commented out in the source: GSP, Invoice,
                 Delivery Chellan/Note/Vintage, TB Shipping Bill, Manual SB, e-Sugam Report). --%>
            <div class="pm-confirm-overlay" id="pmGenericModalOverlay" onclick="if(event.target===this) closeGenericModal();">
                <div class="pm-branch-modal-card" id="pmGenericModalCard">
                    <div class="pm-robot-img-close" onclick="closeGenericModal();" title="Close">&times;</div>
                    <iframe id="pmGenericModalFrame" class="pm-branch-modal-frame" src="" title="Popup"></iframe>
                </div>
            </div>

            <%-- Branch changed successfully - shown after Change_Branch.aspx's postback succeeds
                 (replaces the old jAlert popup, which rendered cramped inside the small iframe). --%>
            <div class="pm-confirm-overlay" id="pmBranchSuccessOverlay">
                <div class="pm-confirm-card">
                    <div class="pm-confirm-icon pm-confirm-icon-success">&#10003;</div>
                    <h3>Branch Changed</h3>
                    <p>Your branch has been changed successfully.</p>
                    <div class="pm-confirm-actions">
                        <button type="button" class="pm-btn pm-btn-success" onclick="location.reload();">OK</button>
                    </div>
                </div>
            </div>

            <%-- Change Password: same treatment as Branch Selection above - fixed overlay +
                 flex-centered card hosting Change_Password.aspx in an iframe, instead of the
                 old dhtmlmodal/iframe window. openChangePasswordPremium() replaces the shared
                 openchangepassword() (js/iframepopupwin.js) call just for this page - that
                 shared function is still used as-is by the older non-premium master pages. --%>
            <div class="pm-confirm-overlay" id="pmChangePasswordOverlay" onclick="if(event.target===this) closeChangePassword();">
                <div class="pm-branch-modal-card">
                    <div class="pm-robot-img-close" onclick="closeChangePassword();" title="Close">&times;</div>
                    <iframe id="pmChangePasswordFrame" class="pm-branch-modal-frame" src="" title="Change Password"></iframe>
                </div>
            </div>

            <%-- Password changed successfully - shown after Change_Password.aspx's postback
                 succeeds (replaces the old jAlert popup, which rendered cramped inside the
                 small iframe). --%>
            <div class="pm-confirm-overlay" id="pmChangePasswordSuccessOverlay">
                <div class="pm-confirm-card">
                    <div class="pm-confirm-icon pm-confirm-icon-success">&#10003;</div>
                    <h3>Password Changed</h3>
                    <p>Your password has been changed successfully.</p>
                    <div class="pm-confirm-actions">
                        <button type="button" class="pm-btn pm-btn-success" onclick="closeChangePasswordSuccess();">OK</button>
                    </div>
                </div>
            </div>

            <%-- "View All Customers" (Dashboard card, inside #mainiframecontainer) opens this -
                 hosted here in the PARENT page (not the iframe) so it covers the whole screen,
                 header/topbar/footer included, the same way the bell/robot popups do. A
                 position:fixed overlay inside an iframe can only ever cover the iframe's own
                 box, never the parent document, so the iframe just hands over the title/rows
                 HTML via window.parent.openViewAllCustomersModal(...) and this renders it. --%>
            <div class="pm-confirm-overlay" id="viewAllCustomersOverlay" onclick="if(event.target===this) closeViewAllCustomersModal();">
                <div class="pm-viewall-card">
                    <span class="pm-robot-img-close" onclick="closeViewAllCustomersModal();">&times;</span>
                    <div class="pm-viewall-title" id="viewAllCustomersTitle"></div>
                    <div class="pm-viewall-body" id="viewAllCustomersBody"></div>
                </div>
            </div>

            <%-- Job Details popup (double-click a row in General_Search.aspx and similar
                 search grids) - hosted here in the PARENT page, not the iframe, so the dark
                 backdrop covers the whole screen (header/topbar included) same as the
                 robot/bell/"View All Customers" popups. The iframe just calls
                 window.parent.openJobDetailsModal(url); it never renders its own popup. --%>
            <div class="pm-confirm-overlay" id="jobDetailsOverlay" onclick="if(event.target===this) closeJobDetailsModal();">
                <div class="pm-jobdetails-card">
                    <span class="pm-robot-img-close" onclick="closeJobDetailsModal();">&times;</span>
                    <iframe id="jobDetailsFrame" class="pm-jobdetails-frame" src="about:blank"></iframe>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.min.js"></script>
    <script type="text/javascript" src="jquerycssmenu-premium.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script type="text/javascript">
        // NOTE: NewWindow(w, h) is defined by iframepopupwin.js (used by dhtmlmodal popups
        // like Branch Selection). Do NOT redefine it here - a same-name override previously
        // broke every dhtmlmodal-based popup on this page.

        // Closes any open mega-menu dropdown / drop panel. Called by menu items
        // themselves (onclick="hide();") and by the sidebar inside the iframe (parent.hide()).
        function hide() {
            $("#interVeil").css({ "display": "none" });
            return false;
        }
        function master_hide() {
            return false;
        }

        function Session_Clear() {
            Loading_ShowImage();
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Sign_out",
                data: "{ 'mail': 'a'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    Loading_HideImage();
                    if (data.d == '1') {
                        //window.open('../LoginPage/Default.aspx', '_top');
                        window.open('Default.aspx', '_top');
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    Loading_HideImage();
                }
            });
        }

        // User chip dropdown (click avatar/name to reveal "Sign out")
        function togglePmUserMenu(e) {
            e.stopPropagation();
            // jquerycssmenu-premium.js's own "click outside closes it" (any open
            // mega-menu/submenu) is bound on `document` too, so it needs this same
            // click to bubble there - stopPropagation just above stops that, the
            // same reason the mega-menu's own header clicks needed an explicit call
            // to close THIS dropdown instead of relying on bubbling. Call it
            // directly here so an open top menu always closes when the user chip
            // is clicked, regardless of propagation.
            if (window.pmCloseAllMenus) window.pmCloseAllMenus();
            var dd = document.getElementById('pmUserDropdown');
            var chip = document.getElementById('pmUserChip');
            if (dd) dd.classList.toggle('open');
            if (chip) chip.classList.toggle('open');
            closePmSidebarLayoutSub();
        }
        // Named (not anonymous) so the iframe-click wiring further down the page
        // can call this exact same function too - the main content area is a
        // same-origin but separate document (#mainiframecontainer), which this
        // top document's own click listener below can never see a click inside.
        function closePmUserMenu() {
            var dd = document.getElementById('pmUserDropdown');
            var chip = document.getElementById('pmUserChip');
            if (dd) dd.classList.remove('open');
            if (chip) chip.classList.remove('open');
            closePmSidebarLayoutSub();
        }
        document.addEventListener('click', closePmUserMenu);

        // "Sidebar Layout" row inside the user-chip dropdown - click-to-expand,
        // same idea as togglePmUserMenu but nested one level in. stopPropagation
        // keeps this click from also bubbling to the document handler above
        // (which would instantly close the whole pmUserDropdown) or to
        // pmUserChip's own onclick (which would re-toggle the outer dropdown).
        function togglePmSidebarLayoutSub(e) {
            e.stopPropagation();
            var sub = document.getElementById('pmSidebarLayoutSub');
            if (sub) sub.classList.toggle('open');
        }
        function closePmSidebarLayoutSub() {
            var sub = document.getElementById('pmSidebarLayoutSub');
            if (sub) sub.classList.remove('open');
        }

        // Sign-out now asks for confirmation first via a premium centered dialog
        // (not the native browser confirm()). Cancel = do nothing,
        // Sign out = same Session_Clear() process as before (AJAX logout + redirect).
        function confirmSignOut() {
            var dd = document.getElementById('pmUserDropdown');
            if (dd) dd.classList.remove('open');
            var overlay = document.getElementById('pmSignOutConfirm');
            if (overlay) overlay.classList.add('open');
        }
        function closeSignOutConfirm() {
            var overlay = document.getElementById('pmSignOutConfirm');
            if (overlay) overlay.classList.remove('open');
        }
        // Sign-out confirm only closes via its own Cancel/Sign-out buttons -
        // no click-outside or Escape shortcut, so a session end can't happen by accident.

        // "View All Customers" popup - called from inside #mainiframecontainer
        // (window.parent.openViewAllCustomersModal(...)) so the overlay renders in
        // THIS document and covers the whole screen instead of just the iframe's box.
        function openViewAllCustomersModal(title, bodyHtml) {
            var overlay = document.getElementById('viewAllCustomersOverlay');
            if (!overlay) return;
            document.getElementById('viewAllCustomersTitle').textContent = title;
            document.getElementById('viewAllCustomersBody').innerHTML = bodyHtml;
            overlay.classList.add('open');
        }
        function closeViewAllCustomersModal() {
            var overlay = document.getElementById('viewAllCustomersOverlay');
            if (overlay) overlay.classList.remove('open');
        }
        document.addEventListener('keydown', function (e) {
            if (e.key === 'Escape') closeViewAllCustomersModal();
        });

        // Job Details popup - called from inside #mainiframecontainer
        // (window.parent.openJobDetailsModal(url)) so the overlay renders in THIS
        // document and covers the whole screen instead of just the iframe's box.
        function openJobDetailsModal(url) {
            var overlay = document.getElementById('jobDetailsOverlay');
            var frame = document.getElementById('jobDetailsFrame');
            if (!overlay || !frame) return;
            frame.src = url;
            overlay.classList.add('open');
        }
        function closeJobDetailsModal() {
            var overlay = document.getElementById('jobDetailsOverlay');
            var frame = document.getElementById('jobDetailsFrame');
            if (overlay) overlay.classList.remove('open');
            if (frame) frame.src = 'about:blank';
        }
        document.addEventListener('keydown', function (e) {
            if (e.key === 'Escape') closeJobDetailsModal();
        });

        // Branch Selection popup - called by open_Branch_Selection() (js/iframepopupwin.js)
        // and by Change_Branch.aspx's own Cancel button (parent.closeBranchSelection()).
        function closeBranchSelection() {
            var overlay = document.getElementById('pmBranchOverlay');
            var frame = document.getElementById('pmBranchFrame');
            if (overlay) overlay.classList.remove('open');
            if (frame) frame.src = 'about:blank';
            // The iframe's own document (and everything in it, including the moved-out
            // dropdown panel node's original references) is about to be torn down by the
            // src='about:blank' above - purge whatever's parked in the host so it doesn't
            // linger as a dead, hidden node in THIS document.
            pmUnmountBranchDropdown(true);
        }
        document.addEventListener('keydown', function (e) {
            if (e.key === 'Escape') closeBranchSelection();
        });

        // Reparents a "Select Group"/"Select Branch" dropdown panel element (built and owned
        // by Change_Branch.aspx, which keeps all its click/keyboard logic) into THIS document
        // so it can render past the small Branch Selection popup's edge instead of being
        // clipped by the iframe's fixed-size box. rect is {left, top, width} in THIS page's
        // viewport coordinates - Change_Branch.aspx computes it from its own field's position
        // plus window.frameElement's position (the <iframe> as seen from inside itself).
        function pmMountBranchDropdown(panelEl, rect) {
            var host = document.getElementById('pmBranchDropdownHost');
            if (!host || !panelEl || !rect) return;
            if (panelEl.parentNode !== host) host.appendChild(panelEl);
            panelEl.style.position = 'fixed';
            panelEl.style.left = rect.left + 'px';
            panelEl.style.top = rect.top + 'px';
            panelEl.style.right = 'auto';
            panelEl.style.width = rect.width + 'px';
            host.style.display = 'block';
        }
        // Hides the host (called when the panel closes) - pass true to also drop the parked
        // node entirely, used when the whole Branch Selection popup is closing so nothing
        // referencing the soon-to-be-destroyed iframe document is left behind.
        function pmUnmountBranchDropdown(discard) {
            var host = document.getElementById('pmBranchDropdownHost');
            if (!host) return;
            host.style.display = 'none';
            if (discard) host.innerHTML = '';
        }
        // A click on the reparented panel itself is handled by Change_Branch.aspx's own
        // listeners (still attached directly to its option rows - those travel with the node).
        // But a click anywhere ELSE in THIS page (the dark overlay, the popup's own close X,
        // the rest of the app behind it) happens in THIS document, which the iframe's own
        // click listeners can never see across the frame boundary - so it has to be handled
        // here instead, both hiding the host and asking the iframe to reset its own trigger/
        // label state back to normal (via the function it exposes on its contentWindow).
        document.addEventListener('click', function (e) {
            var host = document.getElementById('pmBranchDropdownHost');
            if (!host || host.style.display === 'none' || host.contains(e.target)) return;
            var frame = document.getElementById('pmBranchFrame');
            if (frame && frame.contentWindow && typeof frame.contentWindow.pmbCloseAllOpenPanels === 'function') {
                frame.contentWindow.pmbCloseAllOpenPanels();
            }
            pmUnmountBranchDropdown();
        });

        // Generic premium popup - replaces the old dhtmlmodal/dhtmlwindow popup for ~40
        // menu items that just open a page in a small/medium window (see markup comment
        // above #pmGenericModalOverlay for the list of items deliberately left out).
        function openGenericModal(url, w, h) {
            var overlay = document.getElementById('pmGenericModalOverlay');
            var card = document.getElementById('pmGenericModalCard');
            var frame = document.getElementById('pmGenericModalFrame');
            if (!overlay || !card || !frame) return;
            card.style.width = (w || 460) + 'px';
            card.style.height = (h || 270) + 'px';
            frame.src = url;
            overlay.classList.add('open');
        }
        function closeGenericModal() {
            var overlay = document.getElementById('pmGenericModalOverlay');
            var frame = document.getElementById('pmGenericModalFrame');
            if (overlay) overlay.classList.remove('open');
            if (frame) frame.src = 'about:blank';
        }
        document.addEventListener('keydown', function (e) {
            if (e.key === 'Escape') closeGenericModal();
        });

        // Called by Change_Branch.aspx (btn_Change_Branch_Click) after a successful branch
        // change, replacing the old jAlert popup that rendered cramped inside the small
        // popup iframe. OK reloads this whole page, same effect as the old RefreshParent().
        function showBranchChangeSuccess() {
            closeBranchSelection();
            var overlay = document.getElementById('pmBranchSuccessOverlay');
            if (overlay) overlay.classList.add('open');
        }

        // Change Password popup - opened from the user-chip dropdown's "Change Password"
        // link (onclick="win_hide();openChangePasswordPremium();"). Only this page uses
        // this function; the shared openchangepassword() (js/iframepopupwin.js) is left
        // untouched since older non-premium master pages still call it directly.
        function openChangePasswordPremium() {
            var overlay = document.getElementById('pmChangePasswordOverlay');
            var frame = document.getElementById('pmChangePasswordFrame');
            if (!overlay || !frame) return;
            frame.src = '../Users/Change_Password.aspx';
            overlay.classList.add('open');
        }
        function closeChangePassword() {
            var overlay = document.getElementById('pmChangePasswordOverlay');
            var frame = document.getElementById('pmChangePasswordFrame');
            if (overlay) overlay.classList.remove('open');
            if (frame) frame.src = 'about:blank';
        }
        document.addEventListener('keydown', function (e) {
            if (e.key === 'Escape') closeChangePassword();
        });
        // Called by Change_Password.aspx (btnUpdate_Click) after a successful password
        // change, replacing the old jAlert popup that rendered cramped inside the small
        // popup iframe.
        function showChangePasswordSuccess() {
            closeChangePassword();
            var overlay = document.getElementById('pmChangePasswordSuccessOverlay');
            if (overlay) overlay.classList.add('open');
        }
        function closeChangePasswordSuccess() {
            var overlay = document.getElementById('pmChangePasswordSuccessOverlay');
            if (overlay) overlay.classList.remove('open');
        }

        // Called by Transaction/General.aspx's RefreshParent_New() (Close/Cancel
        // buttons) right before it closes the Job Details modal. Reloads the search
        // grid iframe with ?ClosePop=true still on the URL, so that page's existing
        // job-lock-release logic (Request["ClosePop"] in Page_Load) and data refresh
        // still run - same as the old flow, just without navigating this whole shell
        // away to its default view.
        function refreshMainIframeWithClosePop() {
            var frame = document.getElementById('mainiframecontainer');
            if (!frame || !frame.contentWindow) return;
            try {
                var base = frame.contentWindow.location.href.split('?')[0];
                frame.contentWindow.location.href = base + '?ClosePop=true';
            } catch (e) {
                // cross-origin or other failure - non-fatal, the modal still closes
            }
        }

        // Sidebar Layout switcher: a normal menu/submenu item (same pattern as "Master"
        // above), so jquerycssmenu.js's own click-to-open/close handles it - no extra
        // toggle code needed here. Horizontal (default) = the mega-menu stays where it
        // always was, above the content. Vertical = the SAME #myjquerymenu element is
        // relocated (not cloned) into #pmSidebarPanel and restyled as a left column via
        // the "pm-vertical-menu" body class (see premium-theme.css); jquerycssmenu.js
        // reads that same class to flip its flyout-positioning math (side vs. below).
        // The actual DOM-move/class-toggle/save logic lives in pmApplyMenuLayout(),
        // defined once near #pmSidebarPanel above (it needs to run inline, that early,
        // to avoid a Horizontal-then-Vertical flash on page load) and reused here.

        // Collapse/expand the vertical sidebar down to an icon-only rail. The toggle
        // button straddles the sidebar's right edge (see .pm-sidebar-toggle) and its
        // arrow flips direction to reflect what clicking it will do next.
        function togglePmSidebarCollapse() {
            var collapsed = document.body.classList.toggle('pm-sidebar-collapsed');
            var btn = document.getElementById('pmSidebarToggleBtn');
            if (btn) btn.title = collapsed ? 'Expand sidebar' : 'Collapse sidebar';
            // Every row just shifted width, so any open flyout's fixed-position
            // coordinates are stale - close it rather than leave it floating wrong.
            // pmCloseAllMenus (see pmApplyMenuLayout's identical comment above) also
            // restores any reparented flyout back into its own <li> instead of just
            // hiding it in place, so its nesting-based CSS stays correct next time.
            if (window.pmCloseAllMenus) {
                window.pmCloseAllMenus();
            } else if (window.jQuery) {
                jQuery('#myjquerymenu > ul').find('ul:visible').hide();
                jQuery('#myjquerymenu li').removeClass('pm-menu-active');
            }
        }

        // Announcement bell popup - badge always shows a count (0 = nothing active)
        document.addEventListener('DOMContentLoaded', function () {
            var countEl = document.getElementById('hdnBellCount');
            var count = countEl ? parseInt(countEl.value, 10) || 0 : 0;
            var dot = document.getElementById('spanBellDot');
            if (dot) {
                dot.textContent = count;
                dot.classList.toggle('is-zero', count === 0);
            }

            if (count > 0) {
                var bell = document.getElementById('spanBellIcon');
                if (bell) {
                    bell.style.animation = 'bellRing 1s infinite';
                }
            }
        });

        function OpenBellPopup() {
            var imgPath = document.getElementById('hdnBellImagePath').value;
            var div = document.getElementById('divBellImagePopup');
            var img = document.getElementById('imgBellDisplay');
            var noImg = document.getElementById('divBellNoImage');

            if (imgPath && imgPath !== '') {
                img.src = imgPath;
                img.style.display = 'block';
                noImg.style.display = 'none';
            }
            else {
                img.style.display = 'none';
                noImg.style.display = 'flex';
            }
            div.classList.add('open');
        }

        function CloseBellPopup() {
            var div = document.getElementById('divBellImagePopup');
            var img = document.getElementById('imgBellDisplay');
            if (div) div.classList.remove('open');
            if (img) img.src = '';
        }
        document.addEventListener('keydown', function (e) {
            if (e.key === 'Escape') CloseBellPopup();
        });

        // The mega-menu's "click outside closes it" listener (in jquerycssmenu.js)
        // and the user-chip dropdown's own (closePmUserMenu, bound above) are both
        // bound to THIS document, so neither can ever see a click inside
        // #mainiframecontainer - that's a separate document (same-origin, different
        // window). Re-wire a matching click listener onto the iframe's document every
        // time it navigates, so clicking anywhere in the main content also closes
        // any open dropdown, same as clicking outside used to via mouseleave.
        (function () {
            var frame = document.getElementById('mainiframecontainer');
            if (!frame) return;

            function closeOverlaysOnIframeClick() {
                // pmCloseAllMenus (jquerycssmenu-premium.js) also restores any flyout
                // that vertical mode had reparented to the menu's top level back into
                // its own <li>, so its nesting-based CSS stays correct next time it
                // opens - plain hide() alone left it stranded there. Scoped like
                // jquerycssmenu.js itself ($mainmenu.find("ul")): must start FROM the
                // root <ul> and only .find() its descendants, not select
                // "#myjquerymenu ul" directly - that also matches the root <ul> (the menu
                // bar itself, always visible) and would hide the whole top menu bar.
                if (window.pmCloseAllMenus) {
                    window.pmCloseAllMenus();
                } else if (window.jQuery) {
                    jQuery('#myjquerymenu > ul').find('ul:visible').hide();
                    jQuery('#myjquerymenu li').removeClass('pm-menu-active');
                }
                // Same reason the username/avatar dropdown wasn't closing on an
                // "outside" click that landed inside the main content iframe.
                closePmUserMenu();
            }

            function wireIframeClose() {
                try {
                    var frameDoc = frame.contentDocument || frame.contentWindow.document;
                    frameDoc.removeEventListener('click', closeOverlaysOnIframeClick);
                    frameDoc.addEventListener('click', closeOverlaysOnIframeClick);
                } catch (e) {
                    // cross-origin content (shouldn't happen on this app) - ignore
                }
            }

            frame.addEventListener('load', wireIframeClose);
            wireIframeClose();
        })();
    </script>
</body>
</html>
