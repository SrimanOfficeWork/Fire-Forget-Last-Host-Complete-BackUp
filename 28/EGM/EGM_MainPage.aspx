<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EGM_MainPage.aspx.cs" 
    Inherits="Export_BL_Generation"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>EGM</title>
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


    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>

      <script language="jscript" type="text/javascript">

             function tab_page1x() {

                 document.getElementById("page-1").style.display = 'Block';
                 document.getElementById("page-2").style.display = 'none';
                 document.getElementById("page-3").style.display = 'none';
                 
             }
             function tab_page2x() {

                 document.getElementById("page-1").style.display = 'none';
                 document.getElementById("page-2").style.display = 'Block';
                 document.getElementById("page-3").style.display = 'none';
               
             }
             function tab_page3x() {

                 document.getElementById("page-1").style.display = 'none';
                 document.getElementById("page-2").style.display = 'none';
                 document.getElementById("page-3").style.display = 'Block';

             }

             function tab_page5(url, val) {

                 document.getElementById('page-1').style.display = 'none';
                 document.getElementById('page-2').style.display = 'Block';
                 document.getElementById('page-3').style.display = 'Block';
                 document.getElementById("Trans_igm_item_Iframe").src = url + val + '&jobnops=' + document.getElementById('txt_JobNo').value;
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
            <div id="innerbox_MidMain_Transact_popup_new" style="height:110px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Export General Manifest
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 965px; ">
                    <div id="tag_Exchange_inner_lft" ">
                        <div id="tag_transact_lft_in1">
                            <div id="tag_transac_exp_drawback" style="width: 965px; margin-top:10px;">
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width:80px";>
                                    JobNo
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 100px">
                                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1"
                                        Width="100px"  AutoPostBack="True" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txt_JobNo" runat="server" MaxLength="35" Width="90px" ReadOnly="true" TabIndex="1"
                                        Visible="false" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                </div>
                                <div id="magnify_area" style="width: 45px">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 80px;">
                                   Job Date
                                </div>
                               

                                <div id="txtcon-m_transaction_Supp_code" style="width: 100px">
                                    <asp:TextBox ID="txt_Job_Date" runat="server"  CssClass="validate[required] txtbox_trans_exp_drawback"
                                       TabIndex="2" Width="100px" ></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Job_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Job_Date"
                                PopupButtonID="txt_Job_Date" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                                <div id="magnify_area" style="width: 40px">
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 80px">
                                    Rotation No
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_RotationNo" runat="server" MaxLength="50" CssClass="validate[required] txtbox_trans_exp_drawback"
                                      TabIndex="3"  ClientIDMode="Static"  Width="85px"></asp:TextBox>
                                </div>
                                  <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 90px">
                                    Rotation Date
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 50px">
                                    <asp:TextBox ID="txt_RotationDate" runat="server" MaxLength="50" CssClass="validate[required] txtbox_trans_exp_drawback"
                                       TabIndex="4" ClientIDMode="Static"  Width="85px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_RotationDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_RotationDate"
                                PopupButtonID="txt_RotationDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                               
                            </div>
                          
                             <div id="tag_transac_exp_drawback" style="width: 850px; ">
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width:80px";>
                                    Liner Name
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 100px">
                                   <%-- <asp:DropDownList ID="ddl_LinerName" runat="server" CssClass="listtxt_transac_src1"
                                       TabIndex="5" Width="100px"  AutoPostBack="True" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                                        <asp:ListItem>LinerName</asp:ListItem>
                                    </asp:DropDownList>--%>
                                    <asp:TextBox ID="txt_LinerName" runat="server"  CssClass=" txtbox_trans_exp_drawback"
                                       TabIndex="6" Width="100px" ></asp:TextBox>
                                </div>
                                 <div id="magnify_area" style="width: 45px">
                                <asp:Button ID="btnnew1" CssClass="autowidnewbut" Width="40px" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_EGM_Liner_Vessel_Master('Liner'); return false" />
                            </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 80px;">
                                   Vessel Name
                                </div>
                               

                                <div id="txtcon-m_transaction_Supp_code" style="width: 100px">
                                    <asp:TextBox ID="txt_Vessel_Name" runat="server"  CssClass=" txtbox_trans_exp_drawback"
                                       TabIndex="6" Width="100px" ></asp:TextBox>
                                </div>
                                 <div id="magnify_area" style="width: 40px">
                                <asp:Button ID="btnnew12" CssClass="autowidnewbut" Width="40px" Text="New" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');open_EGM_Liner_Vessel_Master('Vessel'); return false" />
                            </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 80px">
                                    IMO No
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_IMO_No" runat="server" MaxLength="50" CssClass="txtbox_trans_exp_drawback"
                                      TabIndex="7"  ClientIDMode="Static" eadOnly="true" Width="85px"></asp:TextBox>
                                </div>
                                  <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 90px">
                                    Voyage No
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_Voyage_No" runat="server" MaxLength="50" CssClass="validate[required] txtbox_trans_exp_drawback"
                                     TabIndex="8"   ClientIDMode="Static"  Width="85px"></asp:TextBox>
                                </div>
                               
                            </div>
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
            <div id="innerbox_MidMain_Trans_new" style="height: 450px;">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1x('0');return false;"
                        id="IMD"><span>General </span></a></li>
                     <%--<li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2x('0');return false;" id="MD">
                        <span>Checklist</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3x('0');return false;" id="SD">
                        <span>Flatfile</span></a></li>--%>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../EGM_Report/EGM_CheckList.aspx?jobno=',document.getElementById('txt_JobNo').value);"
                        id="Checklist"><span>Checklist</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('../EGM_Flatfile/EGM_FlatFile_Generation.aspx?jobno=',document.getElementById('txt_JobNo').value);"
                        id="Submission"><span>Submission</span></a></li>
                </ol>
                <div class="content" id="page-1" style="height: 560px; width: 960px;"> 
                <%--<div id="innerbox_MidMain_Mid_ClientMaster_l" style="height: 320px;
                        width: 590px;">--%>
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 160px;
                        width: 590px;">
                        <div id="innerbox_MidMain_Mid_ClientMaster_l" style="height: 320px; width: 590px;">
                            <div id="tag_transac_exp_drawback" style="width: 580px">
                                <div id="tag_label_transaction_exp_jobb">
                                    SB No
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 120px;">
                                    <asp:TextBox ID="txt_SBNo" runat="server" MaxLength="7" ClientIDMode="Static" Width="100px"
                                        TabIndex="9" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen" ></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb">
                                    SB Date
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 100px;">
                                    <asp:TextBox ID="txt_SBDate" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="10" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen" ></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_SBDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_SBDate"
                                PopupButtonID="txt_SBDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 580px">
                                <div id="tag_label_transaction_exp_jobb">
                                    GateWay Port
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 120px;">
                                    <asp:TextBox ID="txt_GatewayPort" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="11" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen" ></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb">
                                    Nature of Cargo
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 100px;">
                                    <asp:DropDownList ID="ddl_Nature_of_Cargo" runat="server" CssClass="validate[required] listtxt_transac_src1"
                                      TabIndex="12"  Width="100px">
                                        <asp:ListItem Value="C">C Containerized</asp:ListItem>
                                        <asp:ListItem Value="P">P Packaged</asp:ListItem>
                                        <asp:ListItem Value="CP">CP Containerized</asp:ListItem>
                                        <asp:ListItem Value="LB">LB Liquid and Bulk</asp:ListItem>
                                        <asp:ListItem Value="DB">DB Dry Bulk</asp:ListItem>
                                        
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 580px">
                                <div id="tag_label_transaction_exp_jobb">
                                    Port of Origin
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 120px;">
                                    <asp:TextBox ID="txt_Port_of_Origin" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="13" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb">
                                    Destination Port
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 100px;">
                                    <asp:TextBox ID="txt_Destination_Port" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="14" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 580px">
                                <div id="tag_label_transaction_exp_jobb">
                                    Gross Weight
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 120px;">
                                    <asp:TextBox ID="txt_Quantity" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="15" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen" ></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb">
                                    Unit
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 100px;">
                                    <asp:TextBox ID="txt_Unit" runat="server" MaxLength="60" ClientIDMode="Static" Width="100px"
                                        TabIndex="16" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 580px">
                                <div id="tag_label_transaction_exp_jobb">
                                    No of Packages
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 120px;">
                                    <asp:TextBox ID="txt_No_of_Packages" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="17" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen" ></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="visibility:hidden">
                                    Loose Packets
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1" style="width: 100px; visibility:hidden">
                                    <asp:TextBox ID="txt_Loose_Packets" runat="server" MaxLength="60" ClientIDMode="Static"
                                        Width="100px" TabIndex="18" CssClass=" txtbox_none_Mid_transac_pop_gen" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 580px">
                            </div>
                            <div id="tag_transac_exp_drawback" style="height: 25px; font-weight: normal; margin-top: 0;
                                width: 98%;">
                            </div>
                            
                            <div id="tag_transac_exp_drawback" style="height: 25px; font-weight: normal; margin-top: 0;
                                width: 98%;">
                                <div id="tag_label_transaction_exp_jobb">
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                </div>
                                <div id="magnify_area">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height: 140px; width: 370px;
                        overflow: auto;">
                        <asp:GridView ID="gvAll" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" OnRowCreated="gvAll_RowCreated"
                            OnRowDataBound="gvAll_RowDataBound" OnRowDeleting="gvAll_RowDeleting" OnRowEditing="gvAll_RowEditing"
                            PageSize="12" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%">
                            <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="S.No" />
                                <asp:TemplateField HeaderText="ContainerNo">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtContainerNo" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                            MaxLength="11" Text='<%# Bind("CONTAINER_NO") %>' Width="150px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Size">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl_size" runat="server" Width="50px">
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>40</asp:ListItem>
                                            <asp:ListItem>45</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Type">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl_Type" runat="server" Width="50px">
                                            <asp:ListItem>F</asp:ListItem>
                                            <asp:ListItem>L</asp:ListItem>
                                           <%-- <asp:ListItem>FR</asp:ListItem>
                                            <asp:ListItem>GP</asp:ListItem>
                                            <asp:ListItem>HG</asp:ListItem>
                                            <asp:ListItem>HR</asp:ListItem>
                                            <asp:ListItem>OT</asp:ListItem>
                                            <asp:ListItem>RF</asp:ListItem>
                                            <asp:ListItem>HC</asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                   <%-- </div>--%>
                <%-- </div>--%>
                <%--<div id="innerbox_MidMain_Mid_ClientMaster_l" style="height: 80px; width: 990px;">--%>
                    <div id="tag_transac_exp_drawback" style="width: 990px">
                        <div id="tag_label_transaction_exp_jobb">
                            Exporter Name
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                            <asp:TextBox ID="txt_Exporter_Name" runat="server" MaxLength="60" ClientIDMode="Static"
                                TabIndex="19" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                        </div>
                        <div id="magnify_area" style="width:38px">
                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Consignee'); return false">
                            </a>
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Consignee
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen"
                                MaxLength="60" TabIndex="24"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Consignee'); return false">
                            </a>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback" style="width: 990px">
                        <div id="tag_label_transaction_exp_jobb">
                            Address
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width:299px">
                            <asp:TextBox ID="txt_ExporterAddress1" runat="server" MaxLength="60" ClientIDMode="Static" Width="140px"
                                TabIndex="20" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                                <asp:TextBox ID="txt_ExporterAddress2" runat="server" MaxLength="60" ClientIDMode="Static" Width="140px"
                                TabIndex="21" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Address
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1" style="width:300px">
                            <asp:TextBox ID="txtConsignee_Address1" runat="server" ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen"
                              Width="142px"  MaxLength="60" TabIndex="25"></asp:TextBox>
                                <asp:TextBox ID="txtConsignee_Address2" runat="server" MaxLength="60" ClientIDMode="Static" Width="142px"
                                TabIndex="26" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                        </div>
                       
                    </div>
                    <div id="tag_transac_exp_drawback" style="width: 990px">
                        <div id="tag_label_transaction_exp_jobb">
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new"  style="width:299px">
                            <asp:TextBox ID="txt_ExporterAddress3" runat="server" MaxLength="60" ClientIDMode="Static" Width="142px"
                                TabIndex="22" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                                <asp:TextBox ID="txt_ExporterAddress4" runat="server" MaxLength="60" ClientIDMode="Static" Width="142px"
                                TabIndex="23" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1" style="width:300px">
                            <asp:TextBox ID="txtConsignee_Address3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                              Width="142px"  MaxLength="60" TabIndex="27"></asp:TextBox>
                                <asp:TextBox ID="txtConsignee_Address4" runat="server" MaxLength="60" ClientIDMode="Static" Width="142px"
                                TabIndex="28" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                        </div>
                        
                    </div>
                     
                <%--</div>--%>
                <div id="tag_srcinner1grid_table_Container">
                    <div id="Main_Grid_Container" runat="server" style="overflow: hidden;">
                        <asp:GridView runat="server" ID="gv_ItemDetails" EmptyDataText="NO RECORD FOUND"
                            AutoGenerateColumns="false" CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true"
                            Width="100%" OnRowDataBound="gv_ItemDetails_RowDataBound" CellPadding="1" DataKeyNames="EGM_ID,SB_SLNO"
                            CellSpacing="1" OnRowCreated="gv_ItemDetails_RowCreated" OnSelectedIndexChanged="gv_ItemDetails_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                CssClass="column_style_right" BorderWidth="1px" />
                            <HeaderStyle Font-Underline="false" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="40px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="right" Width="40px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="JOBNO" HeaderText="Job No" HeaderStyle-Width="71px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="71px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="JOBDATE" HeaderText="Job Date" HeaderStyle-Width="71px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="71px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ROTATION_NO" HeaderText="Rotation No" HeaderStyle-Width="181px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="181px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SBNO" HeaderText="SB No" HeaderStyle-Width="81px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="81px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SB_DATE" HeaderText="SB Date" HeaderStyle-Width="80px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="LINER_NAME" HeaderText="Liner Name" HeaderStyle-Width="290px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="290px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VESSEL_NAME" HeaderText="Vessel Name" HeaderStyle-Width="181px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="181px" />
                                </asp:BoundField>
                                
                               <%-- <asp:BoundField DataField="EXPORTER_NAME" HeaderText="Exporter Name" HeaderStyle-Width="170px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="170px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CONSIGNEE_NAME" HeaderText="Consignee Name" HeaderStyle-Width="181px">
                                    <ItemStyle CssClass="column_style_left5" HorizontalAlign="left" Width="181px" />
                                </asp:BoundField>--%>
                            </Columns>
                        </asp:GridView>
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
                    <asp:HiddenField ID="hdn_CLIENT_TYPE" runat="server" />

                      <asp:HiddenField ID="HD_Update_id" runat="server" />
                      <asp:HiddenField ID="hdn_fileRef_Jobno" runat="server" />
                      <asp:HiddenField ID="Hdn_FILEREFNO" runat="server" />
                      <asp:HiddenField ID="hdexp" runat="server" />
                      <asp:HiddenField ID="hdConsignee" runat="server" />
                      <asp:HiddenField ID="hd_Brslno" runat="server" />
                      <asp:HiddenField ID="hdn_SB_SlNo" runat="server" />
                      <asp:HiddenField ID="Hdn_Working_Period" runat="server" />

                    
                </div>
           
             <%--</div>--%>
               
        <%--*****************************************BUTTONS PALCE HERE**************************************** --%>
                  

            <div id="innerbox_MidMain_bot_transact" style="height:55px;font-weight:normal;margin-top: 10;width:98%;">
             <div id="magnify_area">
                        </div>
            
             <div id="editbu">
             <asp:Button ID="btnNew" runat="server" TabIndex="30" CssClass="new" OnClick="btnNew_Click"
                                        OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                                        UseSubmitBehavior="false" />

                                 <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="29"
                                    OnClientClick="return validate();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" 
                                    TabIndex="29"  />
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty" >
                                </div>
                             <div id="editbu" style="margin-top: 7px;">
                                
                                
                            </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="31" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'BL Generation', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
           
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="31" OnClick="btnDelete_Click" CssClass="dlete" Style="display: none;" />
                </div>

                    <div id="editbu">
                    <asp:Button ID="btnSearch" Visible="false" CssClass="generate" runat="server"  OnClientClick="open_jobno_Brokerage(); return false"/>
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
            document.getElementById("General").click();
        }
        
    </script>


      <script type="text/javascript">
          $(document).ready(function () {
              $('#txtExporter').focus(function () {

                  var data = $(this).val();
                  Item_desc(data);

              });
              $('#txtExporter').change(function () {

                  var data = $(this).val();
                  Item_desc(data);

              });
              $('#txtExporter').keyup(function () {

                  var data = $(this).val();
                  Item_desc(data);

              });
              $('#txtExporter').keydown(function () {

                  var data = $(this).val();
                  Item_desc(data);

              });
          });

          function Item_desc(val) {

              var data = val;
              if (data == '') {
                  $('#txtExporter').val('');
              }
              if (data.indexOf("--") != -1) {

                  var s = data.split('--');

                  var before = s[0];
                  var after = s[1];

                  $('#txtExporter').val(after);

                  $('#hdexp').val(after);
                  $('#hd_Brslno').val(before);

              }
              else {

              }
          }
  </script>

  

</body>
</html>
