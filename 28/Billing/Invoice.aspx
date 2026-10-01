<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoice.aspx.cs"   Inherits="Invoice"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export-BL Generation</title>
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


    <%--<script language="jscript" type="text/javascript">

        function tab_page1() {

            document.getElementById("page-1").style.display = 'Block';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';

        }
        function tab_page2() {

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'Block';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
        }
        function tab_page3() {

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'Block';
            document.getElementById("page-4").style.display = 'none';
        }
        function tab_page4() {

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'Block';
        }
    </script>--%>




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
            <div id="innerbox_MidMain">
                <div id="tag_srcinner1">
                    <div id="newbu">
                        <input type="submit" value="Submit" class="new" onclick="openGeneral_Search_New('New'); return false" /></div>
                    <div id="verslic">
                    </div>
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                        Invoice details</div>
                    <div id="verslic">
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
           
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px">
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Generate Type:
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddltype" CssClass="listtxt_transac_item_gen_notn" Width="105px"
                                        runat="server">
                                        <asp:ListItem Text="Job Wise" Value="Job Wise"></asp:ListItem>
                                        <asp:ListItem Text="BL Wise" Value="BL Wise"></asp:ListItem>
                                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 220px">
                                <div id="tag_label_transact_Src">
                                    Type
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                    <asp:DropDownList ID="ddlImp_Exp" CssClass="listtxt_transac_item_gen_notn" Width="105px"
                                        runat="server">
                                         <asp:ListItem Text="Export" Value="Export"></asp:ListItem>
                                        <asp:ListItem Text="Import" Value="Import"></asp:ListItem>
                                       
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    Branch
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddlbranch" CssClass="listtxt_transac_item_gen_notn" Width="155px"
                                        runat="server">
                                        <asp:ListItem Text="Acc, chennai" Value="Acc, chennai"></asp:ListItem>
                                        <asp:ListItem Text="CusHouse, Chennai" Value="CusHouse, Chennai"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    Mode
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddlmode" CssClass="listtxt_transac_item_gen_notn" Width="65px"
                                        runat="server">
                                        <asp:ListItem Text="Air" Value="Air"></asp:ListItem>
                                        <asp:ListItem Text="Sea" Value="Sea"></asp:ListItem>
                                        <asp:ListItem Text="Land" Value="Land"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Exporter Name</div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddlImp_Name" CssClass="listtxt_transac_item_gen_notn" Width="370px"
                                        runat="server">
                                        <asp:ListItem Text="sriram" Value="sriram"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    Job No
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddljobno" CssClass="listtxt_transac_item_gen_notn" Width="100px"
                                        runat="server">
                                        <asp:ListItem Text="101" Value="101"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                        onclick="page_Loading();document.getElementById('hdn_A_to_Z_Search').value='';">
                                    </a>
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <a href="../LoginPage/E_royal_Impex_Home.aspx" class="cancelButt"></a>
                                </div>
                            </div>
                        </div>
                    </div>
                 
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1094px; height: 467px; margin-top: -12px;">
                <ol id="toc_new">
                    <li><a href="#page-1"  class="active" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_1('0');"  id="Gen"><span>Invoice Job </span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_2('0');"
                        id="MD"><span>Local Sales</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_3('0');"
                        id="SD"><span>Other Details</span></a></li>
                   <%-- <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_4('0');"
                        id="Anx"><span>Annexure </span></a></li>--%>
                </ol>

                <div class="content" id="page-1">
                <div id="open_item" runat="server">
                        
            <div id="innerbox_MidMain_Trans_Item_Main" style="height:380px; width:1079px; margin-left:-9px; margin-top:-5px;">
                <ol id="toc">
             <%--    <div id="innerbox_MidMain_Trans_Item_Main" style="height:357px;">
                <ol id="toc_new">--%>

                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="page_A" runat="server">
                        <span>General </span></a></li>
                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span>Charge details</span></a></li>
                    <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server">
                        <span>Gen -3</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server">
                        <span> Gen -4 </span></a></li>
                    
                </ol>
                
                    <div   class="content" id="page-6"   >

                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:329px;margin-top: -16px;">
                        <div id="tag_transact_src_inner" style="width: 1150px">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px">
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Invoice No:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 265px">
                                <div id="tag_label_transact_Src">
                                    Invoice Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                      <asp:TextBox ID="txtDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="2"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    SB Number:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtsbno" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    SB Date:
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txtsbdate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="2"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtsbdate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtsbdate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                         <%--------------------------------------Row 2-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l" >
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    MAWB NO:</div>
                                <div id="txtcon-m_Exchange">
                                  
                                      <asp:TextBox ID="txtmawbno" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 266px;">
                                <div id="tag_label_transact_Src">
                                    HAWB NO:
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txthawbno" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>

                                 <div id="txt_container_Transact_Main_l"  style="width: 180px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    No. of Pkgs:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                      <asp:TextBox ID="txtpkg" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="80px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>

                                 <div id="txt_container_Transact_Main_l" style="width: 180px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                   Gross Wgt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                      <asp:TextBox ID="txtwgt" runat="server" MaxLength="17" onkeyup="autotab(this);"  Width="80px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 125px;">
                                <div id="tag_label_transact_Src" style="width: 60px;">
                                   Net Wgt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 65px;">
                                      <asp:TextBox ID="txtnetwgt" runat="server" MaxLength="17" onkeyup="autotab(this);"  Width="65px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                         <%--------------------------------------Row 3-----------------------------------------%>
                          <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Job Inv No:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtjob_invno" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 265px">
                                <div id="tag_label_transact_Src">
                                    Job Inv. Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                      <asp:TextBox ID="txtJob_inv_Date" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="2"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtJob_inv_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtJob_inv_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    Volume:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtvolume" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l"  style="width: 285px">
                                <div id="tag_label_transact_Src">
                                   Vessel:
                                </div>
                                <div id="txtcon-m_Exchange">
                                     <asp:TextBox ID="txtvessel" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="100px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <%--------------------------------------Row new-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Destination:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtdestination" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 265px">
                                <div id="tag_label_transact_Src">
                                    Container No:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                       <asp:TextBox ID="txtconatiner_no" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    Commodity:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtcommodity" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l"  style="width: 285px">
                                <div id="tag_label_transact_Src">
                                   Freight Status:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:DropDownList ID="DropDownList1" CssClass="listtxt_transac_item_gen_notn" Width="65px"
                                        runat="server">
                                        <asp:ListItem Text="CC" Value="CC"></asp:ListItem>
                                          <asp:ListItem Text="PP" Value="PP"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <%--------------------------------------Row 4-----------------------------------------%>
                       
                         <%--<div id="tag_transact_lft_in1" style="width: 1150px">
                              
                         </div>--%>

                         <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   A/C Behalf
                                </div>
                                <div id="txtcon-m_Exchange">
                                   
                                    <asp:CheckBox ID="ch_Behalf" runat="server" />
                                </div>
                            </div>
                       
                        </div>
                         <%--------------------------------------Row 6-----------------------------------------%>
                     <%--    <div id="innerbox_MidMain_Trans" style="width: 1080px;height:0.1px; margin-left:-20px;">
                          </div>--%>
                           <%--------------------------------------AddRow 1-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Shipper Name:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 330px;">
                                   <asp:TextBox ID="txtshippername" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="330px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false">
                                            </a>
                                        </div>
                            </div>
                            
                               <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                   Consignee Name:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 310px;">
                                   <asp:TextBox ID="txtconsigneename" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="310px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false">
                                            </a>
                                        </div>
                            </div>

                            
                        </div>
                           <%--------------------------------------AddRow 2-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1150px;height:70px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Address :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 373px;">
                                   <asp:TextBox ID="txtShip_Add1" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  Height="60px" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            
                               <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                  Address :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 210px;">
                                   <asp:TextBox ID="txtCon_Add1" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="1" Height="60px" ></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                      
                           <%--------------------------------------AddRow 6-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1150px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Notify Party 1:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 380px;">
                                   <asp:TextBox ID="txt_notify_party_1" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="350px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                            
                               <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                 Notify Party 2:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 330px;">
                                   <asp:TextBox ID="txt_notify_party_2" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="330px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                           <%--------------------------------------AddRow 7-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1150px; height:70px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px; height:150px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  Address
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 210px;height:150px;">
                                   <asp:TextBox ID="txt_notify_party_1_add" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="1"  Height="60px" ></asp:TextBox>
                                </div>
                            </div>
                            
                               <div id="txt_container_Transact_Main_l" style="width: 500px;height:100px;">
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                   Address 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 210px;height:150px;">
                                   <asp:TextBox ID="txt_notify_party_2_add" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  Height="60px" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                         
                           <%--------------------------------------AddRow 11-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1150px; height:70px;">
                          <div id="txt_container_Transact_Main_l" style="width: 950px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Remarks:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 810px;">
                                   <asp:TextBox ID="txt_Remarks" runat="server" MaxLength="500" onkeyup="autotab(this);" width= "800px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                           
                           <%--------------------------------------AddRow 12-----------------------------------------%>
                             <%--<div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 950px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Description:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 810px;">
                                   <asp:TextBox ID="txt_tax_desc" runat="server" MaxLength="500" onkeyup="autotab(this);" width= "800px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>
                            
                         

                         <%--------------------------------------Row End-----------------------------------------%>
                    </div>
                 
                </div>
                        </div>
                    </div>

                    <div  class="content"  id="page-7"  style="display:none;" >
                        <div id="pop_text_area_transac_popup_inn_container_export" style=" height:180px;">
                            <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow:hidden; height:180px; width:1050px;margin-top:-10px; ">
                                <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" 
                                    
                                    ShowHeaderWhenEmpty="True"
                                    Width="100%" onrowcreated="gv_Chg_Details_RowCreated" 
                                    onrowdatabound="gv_Chg_Details_RowDataBound">
                                    <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle Font-Bold="true" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="44px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="right" Width="44px" />
                                        </asp:TemplateField>
                                        
                                        <asp:BoundField DataField="Client_Name" HeaderText="Client Name" HeaderStyle-Width="200px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Charege_Name" HeaderText="Charge Name" HeaderStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left1_new" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Shipment_Type" HeaderText="Shipment Type" HeaderStyle-Width="120px">
                                            <ItemStyle CssClass="column_style_left_border_3_new" Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Exch_Rate" HeaderText="Exch-Rate" HeaderStyle-Width="80px">
                                            <ItemStyle CssClass="column_style_left1_new" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Qty" HeaderText="Qty" HeaderStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left1_new" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Unit_Rate" HeaderText="Unit Rate" HeaderStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_right_new" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Amount" HeaderText="Amount" HeaderStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left_border_4_new" HorizontalAlign="Left" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PP_CC" HeaderText="PP/CC" HeaderStyle-Width="80px">
                                            <ItemStyle CssClass="column_style_left_border_4_new" HorizontalAlign="Left" Width="80px" />
                                        </asp:BoundField>
                                          <asp:BoundField DataField="Tax_NonTax" HeaderText="Tax/NonTax" HeaderStyle-Width="120px">
                                            <ItemStyle CssClass="column_style_left_border_4_new" HorizontalAlign="Left" Width="120px" />
                                        </asp:BoundField>


                                    </Columns>
                                </asp:GridView>
                            
                            </div>
                     </div>

                       <div id="tag_transact_src_inner" style="width: 1150px; height:150px; margin-top: -5px;">
                       <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    NonTaxable Amt:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtincome_amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                           <div id="txt_container_Transact_Main_l" style="width: 295px">
                                <div id="tag_label_transact_Src" style="width: 155px">
                                  Taxable Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                    <asp:TextBox ID="txtexpense_amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                        
                        </div>

                         <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Tax Ledger 1:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_leg_1" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="232px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                               <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false">
                                            </a>
                                        </div>
                             <div id="txt_container_Transact_Main_l" style="width: 235px">
                                 <div id="tag_label_transact_Src" style="width: 53px">
                                     Tax %:
                                 </div>
                                 <div id="txtcon-m_Exchange" style="width: 100px">
                                     <asp:TextBox ID="txt_leg_Per_1" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                         CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1"></asp:TextBox>
                                 </div>
                             </div>
                              <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                    Tax Amount:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_amt_1" runat="server" MaxLength="17" onkeyup="autotab(this);" 
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                        
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Tax Ledger 2:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_leg_2" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="232px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                               <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false">
                                            </a>
                                        </div>
                           <div id="txt_container_Transact_Main_l" style="width: 235px">
                                <div id="tag_label_transact_Src" style="width: 53px">
                                  Tax %:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                    <asp:TextBox ID="txt_leg_Per_2" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                                 
                            </div>

                        <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                    Tax Amount:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_amt_2" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Tax Ledger 3:
                                </div>
                                <div id="txtcon-m_Exchange"  style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_leg_3" runat="server" MaxLength="17" onkeyup="autotab(this);"  Width="232px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>

                              <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false">
                                            </a>
                                        </div>

                           <div id="txt_container_Transact_Main_l" style="width: 235px">
                                <div id="tag_label_transact_Src" style="width: 53px">
                                  Tax %:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                    <asp:TextBox ID="txt_leg_Per_3" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>


                               <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                    Tax Amount:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_amt_3" runat="server" MaxLength="17" onkeyup="autotab(this);" 
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                        
                        </div>
                       

                       <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Total Tax Amount:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_tota_tax_amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                           <div id="txt_container_Transact_Main_l" style="width: 295px">
                                <div id="tag_label_transact_Src" style="width: 155px">
                                  Total Amount with Tax:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                    <asp:TextBox ID="txt_tota_amt_With_tax" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                        
                        </div>

                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 950px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Description:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 810px;">
                                   <asp:TextBox ID="txt_tax_desc" runat="server" MaxLength="500" onkeyup="autotab(this);" width= "800px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                        </div>


                       </div>

                    </div>

                    <div  class="content"  id="page-8"  >
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:225px;">
                          3
                        </div>
                    </div>

                    <div  class="content" id="page-9"  >
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:225px;">
                          4
                        </div>
                    </div>
                  <%-------------------------------------------------------------------------------%>

                           
                     <%-- --------------------Test Start----------------------------%>
                <%--<div id="innerbox_MidMain_bot_transact" runat="server">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                TabIndex="50" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="47" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="48" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="49" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job?', 'GENERAL', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="51" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="55">
                        </div>
                    </div>
                </div>--%>

                     <%-- --------------------Test End----------------------------%>

                </div>
                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                TabIndex="50" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="47" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="48" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="49" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job?', 'GENERAL', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="51" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="55">
                        </div>
                    </div>
                </div>
                   <%-- --------------------Test End----------------------------%>

                   </div>
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
                <%-----------------------------------END----------------------------------------------------------------%>
            </div>
            <%--  ---------------------------S------------------------------------------%>
            
            <%--  ---------------------------E------------------------------------------%>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>

             <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />

        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  

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
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        
    </script>
       
</body>
</html>
