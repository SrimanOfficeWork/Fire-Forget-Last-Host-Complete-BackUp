<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Covering_Letter_Vaishnavi.aspx.cs" 
    Inherits="Covering_Letter_Vaishnavi"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Covering Letter</title>
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
    <%--<script src="../js/EGM/EGM_General.js" type="text/javascript"></script>--%>


    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>

     <script type="text/javascript">
         function open_report() {
             if (document.getElementById('hdnfld_Jobno').value != '') {
                 var f = document.getElementById('hdnfld_Jobno').value;
                 var type = document.getElementById('ddl_BillType').value;
                 var report_type = 'Vaishnavi_Report';
                 NewWindow1('../Billing_Imp_Rpt/GST_Bill_Imp_Exp_Covering_Letter_VAISHNAVI_Rpt.aspx?jobno=' + f + '&Type=' + type + '&report_type=' + report_type + '', 'List', '870', '1024', 'yes');
             }
         }   
    </script>

     

    <style type="text/css">
    
    .ListControl input[type=radio] + label  
{
   display      :table-cell;
    width            : 7.5em;
    height           : 5em;
    line-height      : 0em;  
    text-align:left;   
}

    .ListControlWidth input[type=radio] + label  
{
   display      :table-cell;
    width            : 10em;
    height           : 5em;
    line-height      : 0em;  
    text-align:left;   
}

    </style>

    <style type="text/css">
    .txtbox_none_Mid_transac_item_other_rmarks_new1_LC{
color:#2b2b2b;
font-family:Arial,Helvetica,sans-serif;
font-size:14px;

margin-top:2px;
width:385px;
max-width:385px;
height:350px;
max-height:350px;
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
	overflow:auto;
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
            <div id="innerbox_MidMain_Transact_popup_new" style="height:80px; width:1150px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:250px">
                       Covering Letter
                    </div>
                   
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 965px; height:40px; ">
                    <div id="tag_Exchange_inner_lft" ">
                        <div id="tag_transact_lft_in1">
                            <div id="tag_transac_exp_drawback" style="width: 965px; margin-top:10px;">

                            <div id="tag_label_transaction_popup_trans_cth_label2" style="width:80px";>
                                   Bill Type
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 120px;">
                                    <asp:DropDownList ID="ddl_BillType" runat="server" 
                                        CssClass="validate[required] listtxt_transac_src1" AutoPostBack="true"
                                      TabIndex="1"  Width="100px" 
                                        onselectedindexchanged="ddl_BillType_SelectedIndexChanged">
                                        <asp:ListItem>Import</asp:ListItem>
                                        <asp:ListItem>Export</asp:ListItem>
                                       
                                    </asp:DropDownList>
                                </div>

                                
                                <div id="tag_label_transaction_exp_jobb" style="width:50px";>
                                   Bill No
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 150px;">
                                     <%--<asp:TextBox ID="txt_BillNo" runat="server"  CssClass=" txtbox_trans_exp_drawback"
                                       TabIndex="4" Width="150px" ></asp:TextBox>--%>
                                       <asp:DropDownList ID="ddl_BillNo" runat="server"  Width="150px" TabIndex="2"  CssClass=" validate[required]txtbox_trans_exp_drawback"></asp:DropDownList>
                                </div>
                           

                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width:80px; text-align:center;" >
                                   Ref No.
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 150px">
                                         <asp:TextBox ID="txt_RefNo" runat="server"  CssClass=" validate[required]txtbox_trans_exp_drawback"
                                       TabIndex="3" Width="150px" ></asp:TextBox>
                                </div>
                       
                                  <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 90px; text-align:center;">
                                    Ref Date
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 50px">
                                    <asp:TextBox ID="txt_RefDate" runat="server" MaxLength="50" CssClass="validate[required] txtbox_trans_exp_drawback"
                                       TabIndex="4" ClientIDMode="Static"  Width="85px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_RefDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_RefDate"
                                PopupButtonID="txt_RefDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                               
                            </div>
                          
                            <%-- <div id="tag_transac_exp_drawback" style="width: 960px; ">
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width:80px";>
                                    Bill No
                                </div>
                                <div id="txtcon-m_transaction_code"  style="width: 150px">
                                        <asp:TextBox ID="txt_BillNo" runat="server"  CssClass=" txtbox_trans_exp_drawback"
                                       TabIndex="4" Width="150px" ></asp:TextBox>
                                </div>
              
         
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                     <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 90px">
                                    Bill Date
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 100px">
                                    <asp:TextBox ID="txt_BillDate" runat="server" MaxLength="50" CssClass="validate[required] txtbox_trans_exp_drawback"
                                       TabIndex="3" ClientIDMode="Static"  Width="85px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_BillDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_BillDate"
                                PopupButtonID="txt_BillDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                                  <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 90px">
                                   Bill Amount
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_Bill_Amount" runat="server" MaxLength="50" CssClass="validate[required] txtbox_trans_exp_drawback"
                                     TabIndex="6"   ClientIDMode="Static"  Width="85px"></asp:TextBox>
                                </div>

                              
                               
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>

         <asp:HiddenField ID="HiddenField2" runat="server" />
                      <asp:HiddenField ID="hdn_isvalue" runat="server" />

           <%-- -------------------------------------N--------------------------------------------------------%>
           <%-- <div id="innerbox_MidMain_Trans_new" style="background-image:none;overflow:hidden;">--%>

           <%-- <div id="innerbox_MidMain_Trans_IGM_Invoice" style="width:990px; height:460px;" >
           <ol id="toc">--%>
            <div id="innerbox_MidMain_Trans_new" style="height: 485px; width:1150px;">
                <ol id="toc_new" style="height:18px">
                   <%-- <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1x('0');return false;"
                        id="IMD"><span>General </span></a></li>--%>
                         <%--<li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../EGM_Report/EGM_CheckList.aspx?jobno=',document.getElementById('txt_RotationNo').value+'-c');" 
                        id="Checklist"><span>Checklist</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../EGM_Flatfile/EGM_FlatFile_Generation.aspx?jobno=',document.getElementById('txt_RotationNo').value+'-c');"
                        id="Submission"><span>Submission</span></a></li>--%>
                    <%-- <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../EGM_Report/EGM_CheckList.aspx?jobno=',document.getElementById('txt_EGM_Jobno').value+'-c');" 
                        id="Checklist"><span>Checklist</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../EGM_Flatfile/EGM_FlatFile_Generation.aspx?jobno=',document.getElementById('txt_EGM_Jobno').value+'-c');"
                        id="Submission"><span>Submission</span></a></li>--%>
                </ol>
                <div class="content" id="page-1" style="height: 485px; width: 1150px;"> 
                <%--<div id="innerbox_MidMain_Mid_ClientMaster_l" style="height: 320px;
                        width: 590px;">--%>
                    <div id="pop_text_area_transac_popup_inn_container_export" style="width: 400px;">
                       
                        <div id="innerbox_MidMain_Mid_ClientMaster_l" style="height: 250px; width: 400px;">
                            <div id="tag_transac_exp_drawback" style="width: 370px">
                                <div id="tag_label_transaction_exp_jobb">
                                 Client Name
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                    <asp:TextBox ID="txt_ClientName" runat="server" MaxLength="50" onblur="ChangeCase(this);"
                                        Font-Bold="true" Width="220px" ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"
                                        AutoPostBack="true" TabIndex="5" ></asp:TextBox>
                                </div>
                               <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporter_Master('IMPORTER_DETAILS'); return false">
                                            </a>
                                        </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 370px">
                                <div id="tag_label_transaction_exp_jobb">
                                    Address
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                    <asp:TextBox ID="txt_Add1" runat="server" MaxLength="7" ClientIDMode="Static" Width="220px" Font-Bold="true"
                                       AutoPostBack="true"  TabIndex="6" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 370px">
                                <div id="tag_label_transaction_exp_jobb">
                                   
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                    <asp:TextBox ID="txt_Add2" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="220px" TabIndex="7" CssClass="txtbox_none_Mid_transac_pop_gen" ></asp:TextBox>
                                </div>
                                
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 370px">
                                <div id="tag_label_transaction_exp_jobb">
                                  
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                    <asp:TextBox ID="txt_Add3" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="220px" TabIndex="8" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                            </div>
                             <div id="tag_transac_exp_drawback" style="width: 370px">
                                <div id="tag_label_transaction_exp_jobb">
                                  
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                    <asp:TextBox ID="txt_Add4" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="220px" TabIndex="9" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                            </div>
                             
                            <%--<div id="tag_transac_exp_drawback" style="width: 370px">
                                <div id="tag_label_transaction_exp_jobb">
                                   Bill No
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                     <asp:TextBox ID="txt_BillNo" runat="server"  CssClass=" txtbox_trans_exp_drawback"
                                       TabIndex="4" Width="150px" ></asp:TextBox>
                                </div>
                            </div>--%>
                            <div id="tag_transac_exp_drawback" style="width: 370px">
                                <div id="tag_label_transaction_exp_jobb">
                                   Bill Date
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                     <asp:TextBox ID="txt_BillDate" runat="server" MaxLength="50" CssClass="txtbox_trans_exp_drawback"
                                       TabIndex="10" ClientIDMode="Static"  Width="150px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_BillDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_BillDate"
                                PopupButtonID="txt_BillDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 370px">
                                <div id="tag_label_transaction_exp_jobb">
                                  Bill Amount
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                     <asp:TextBox ID="txt_Bill_Amount" runat="server" MaxLength="50" CssClass=" txtbox_trans_exp_drawback"
                                     TabIndex="11"   ClientIDMode="Static"  Width="150px"></asp:TextBox>
                                </div>
                            </div>

                            <div id="tag_transac_exp_drawback" style="width: 370px; height:70px;">
                                <div id="tag_label_transaction_exp_jobb">
                                   Subject
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                     <asp:TextBox ID="txt_Subject" runat="server"  CssClass="txtbox_trans_exp_drawback"
                                       TabIndex="12" Width="220px" Height="50px"  TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>

                             <div id="tag_transac_exp_drawback" style="width: 370px; height:50px;">
                                <div id="tag_label_transaction_exp_jobb">
                                   Any Other Docuements
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                     <asp:TextBox ID="txt_AnyotherDoc" runat="server"  CssClass="txtbox_trans_exp_drawback"
                                       TabIndex="12" Width="220px" Height="50px"  TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                    </div>

                     <div id="pop_text_area_transac_popup_inn_container_export" style="width: 730px; height: 485px;">
                        <div id="innerbox_MidMain_Mid_ClientMaster_l" style="height: 485px; width: 730px;">
                            <div id="tag_transac_exp_drawback" style="width: 670px">
                            <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            <asp:CheckBox ID="chk_Invoice" runat="server" />
                            </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                  Invoice
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 220px;">
                                    <%--<asp:TextBox ID="txt_Invoice" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="220px" TabIndex="13" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen"></asp:TextBox>--%>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 720px">
                            <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            <asp:CheckBox ID="chk_PList" runat="server" />
                            </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                  Packing List
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 290px;">
                                    <%--<asp:TextBox ID="txt_chk_PackingList" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="220px" TabIndex="13" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen"></asp:TextBox>--%>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 100px; text-align:center; font-weight:bold;">
                                 Duplicate
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 100px;text-align:center; font-weight:bold;">
                                  Triplicate
                                </div>
                            </div>
                             <div id="tag_transac_exp_drawback" style="width: 720px">
                            <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            <asp:CheckBox ID="chk_BOE" runat="server" />
                            </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                  Bill Of Entry
                                </div>
                                <div id="txtcon-m_transaction_code"  style="width: 180px;">
                                    <asp:TextBox ID="txt_BOE" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                  <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                  Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_BOE_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="14" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_BOE_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_BOE_Date"
                                PopupButtonID="txt_BOE_Date" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                                  
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                  <asp:DropDownList ID="ddl_BOE_Duplicate" runat="server" TabIndex="15">
                                  <asp:ListItem>Original</asp:ListItem>
                                  <asp:ListItem>Copy</asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                                 <div id="txtcon-m_transaction_code" style="width: 95px;">
                                  <asp:DropDownList ID="ddl_BOE_Triplicate" runat="server"  TabIndex="16">
                                  <asp:ListItem>Original</asp:ListItem>
                                  <asp:ListItem>Copy</asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                            </div>

                            <div id="tag_transac_exp_drawback" style="width: 720px">
                            <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            <asp:CheckBox ID="chk_SB" runat="server" />
                            </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                  Shipping Bill No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_SB" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="17" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                  <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                  Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_SB_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="18" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_SB_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_SB_Date"
                                PopupButtonID="txt_SB_Date" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                                 
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                  <asp:DropDownList ID="ddl_SB_Duplicate" runat="server" TabIndex="19">
                                  <asp:ListItem>Original</asp:ListItem>
                                  <asp:ListItem>Copy</asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                                 <div id="txtcon-m_transaction_code" style="width: 95px;">
                                  <asp:DropDownList ID="ddl_SB_Triplicate" runat="server"  TabIndex="20">
                                  <asp:ListItem>Original</asp:ListItem>
                                  <asp:ListItem>Copy</asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                            </div>

                            <div id="tag_transac_exp_drawback" style="width: 670px">
                            <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            <asp:CheckBox ID="chk_AWBNo" runat="server" />
                            </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                 Bill Of Lading/AWB No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_AWBNo" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="21" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                  <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                  Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_AWBNo_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="22" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt_AWBNo_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_AWBNo_Date"
                                PopupButtonID="txt_AWBNo_Date" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                               
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                  <asp:DropDownList ID="ddl_AWBNo" runat="server"  TabIndex="23">
                                  <asp:ListItem>Original</asp:ListItem>
                                  <asp:ListItem>Copy</asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                                
                            </div>

                            <div id="tag_transac_exp_drawback" style="width: 670px">
                            <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            <asp:CheckBox ID="chk_STPI" runat="server" />
                            </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                 STPI Import Apprl. No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_STPI" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="24" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                  <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                  Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_STPI_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="25" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_STPI_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_STPI_Date"
                                PopupButtonID="txt_STPI_Date" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                               
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                  <asp:DropDownList ID="ddl_STPI" runat="server" TabIndex="26">
                                  <asp:ListItem>Original</asp:ListItem>
                                  <asp:ListItem>Copy</asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                                
                            </div>

                          <div id="tag_transac_exp_drawback" style="width: 670px">
                            <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            <asp:CheckBox ID="chk_Procurement" runat="server" />
                            </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                 Procurement Certificate No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_Procurement" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="27" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                  <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                  Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_Procurement_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="28" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt_Procurement_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_Procurement_Date"
                                PopupButtonID="txt_Procurement_Date" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                                
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                  <asp:DropDownList ID="ddl_Procurement" runat="server" TabIndex="29">
                                  <asp:ListItem>Original</asp:ListItem>
                                  <asp:ListItem>Copy</asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                                
                            </div>

                            <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_Certificate" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                    Certificate Of Origin No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_Certificate" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="30" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_Certificate_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="31" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txt_Certificate_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_Certificate_Date"
                                        PopupButtonID="txt_Certificate_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_Certificate" runat="server" TabIndex="32">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                          <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_DutyPaid" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                    Duty Paid TR 6 Challan No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_DutyPaid" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="33" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_DutyPaid_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="34" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txt_DutyPaid_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_DutyPaid_Date"
                                        PopupButtonID="txt_DutyPaid_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_DutyPaid" runat="server" TabIndex="35">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                           <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_DO_receipt" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                   D.O. Receipt No.(Air/Sea)
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_DO_receipt" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="36" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_DO_receipt_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="37" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txt_DO_receipt_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txt_DO_receipt_Date"
                                        PopupButtonID="txt_DO_receipt_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_DO_receipt" runat="server" TabIndex="38">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                         <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_EDI" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                    EDI Coupon Receipt No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_EDI" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="39" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_EDI_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="40" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender11" runat="server" TargetControlID="txt_EDI_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txt_EDI_Date"
                                        PopupButtonID="txt_EDI_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_EDI" runat="server" TabIndex="41">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                          <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_CFS" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                    CFS Receipt No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_CFS" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="42" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_CFS_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="43" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txt_CFS_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txt_CFS_Date"
                                        PopupButtonID="txt_CFS_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_CFS" runat="server" TabIndex="44">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_IAAI" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                   IAAI / Harbour Due Recpt.No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_IAAI" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="45" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_IAAI_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="46" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txt_IAAI_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txt_IAAI_Date"
                                        PopupButtonID="txt_IAAI_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_IAAI" runat="server"  TabIndex="47">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                           <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_Escort" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                   Escort Conveyance Bill No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_Escort" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="48" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_Escort_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="49" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txt_Escort_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txt_Escort_Date"
                                        PopupButtonID="txt_Escort_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_Escort" runat="server"  TabIndex="50">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                           <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_Transport" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                    Transport Bill No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_Transport" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="51" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_Transport_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="52" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender15" runat="server" TargetControlID="txt_Transport_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txt_Transport_Date"
                                        PopupButtonID="txt_Transport_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_Transport" runat="server" TabIndex="53">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                           <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_VehiclePass" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                    Vehicle Pass No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_VehiclePass" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="54" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_VehiclePass_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="55" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender16" runat="server" TargetControlID="txt_VehiclePass_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender16" runat="server" TargetControlID="txt_VehiclePass_Date"
                                        PopupButtonID="txt_VehiclePass_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_VehiclePass" runat="server" TabIndex="56">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                          <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_Insurance" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                    Insurance Cert. No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_Insurance" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="57" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_Insurance_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="58" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender17" runat="server" TargetControlID="txt_Insurance_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender17" runat="server" TargetControlID="txt_Insurance_Date"
                                        PopupButtonID="txt_Insurance_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_Insurance" runat="server" TabIndex="59">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div id="tag_transac_exp_drawback" style="width: 670px">
                                <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                    <asp:CheckBox ID="chk_CE_Cert" runat="server" />
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 190px;">
                                   C.E. Certificate No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 180px;">
                                    <asp:TextBox ID="txt_CE_Cert" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="170px" TabIndex="60" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 20px;">
                                    Dt
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px;">
                                    <asp:TextBox ID="txt_CE_Cert_Date" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="61" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender18" runat="server" TargetControlID="txt_CE_Cert_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender18" runat="server" TargetControlID="txt_CE_Cert_Date"
                                        PopupButtonID="txt_CE_Cert_Date" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 95px;">
                                    <asp:DropDownList ID="ddl_CE_Cert" runat="server" TabIndex="62">
                                        <asp:ListItem>Original</asp:ListItem>
                                        <asp:ListItem>Copy</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                     </div>              
              </div>
               
            
                <div class="content" id="page-2">
                </div>
                <div class="content" id="page-3">
                </div>
                <div class="content" id="page-4">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_igm_item_Iframe"></iframe>
                </div>
            </div>
           
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />                 
                    <asp:HiddenField ID="HdnUpdate_id" runat="server" />
                    <asp:HiddenField ID="HD_Type" runat="server" />
                      <asp:HiddenField ID="HD_Update_id" runat="server" />
                      <asp:HiddenField ID="hd_Branch" runat="server" />
                      <asp:HiddenField ID="hdn_SB_SlNo" runat="server" />
                      <asp:HiddenField ID="hdnfld_Jobno" runat="server" />
                      
                </div>
           
             <%--</div>--%>
               
        <%--*****************************************BUTTONS PALCE HERE**************************************** --%>
            <div id="innerbox_MidMain_bot_transact" style="height: 55px; font-weight: normal;
                margin-top: 10; width: 98%;">
                <div id="magnify_area">
                </div>
                <div id="editbu">
                    <asp:Button ID="btnNew" runat="server" TabIndex="30" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                        CausesValidation="false" UseSubmitBehavior="false" />
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="29"
                        OnClientClick="return validate();" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                        TabIndex="29" />
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="editbu" style="margin-top: 7px;">
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" ToolTip="Select Checkbox" TabIndex="31"
                        CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'Covering Letter', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
           
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="31" OnClick="btnDelete_Click" CssClass="dlete"
                        Style="display: none;" />
                </div>
                <div id="editbu">
                   <%-- <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClientClick="open_report(); return false" />--%>
                   <asp:Button ID="btnSearch" runat="server" Text="Print" CssClass="generate" OnClientClick="return open_report();" TabIndex="18"
             />
                </div>
                <div id="editbu" style="width: 250px">
                </div>
            </div>
                  </div>
           
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <%--<script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>--%>
    <%--<script src="../js/Export_Jscript/Export_Goods_Reg_General.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
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
            document.getElementById("IMD").click();
        }
        
    </script>


</body>
</html>
