<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Single_window_Notes.aspx.cs" Inherits="Single_window_Notes" %>
 <%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Bill Invoice</title>
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
  
     <style type="text/css">
         .datagrid table { border-collapse: collapse; text-align: left; width: 100%; } .datagrid {font: normal 12px/150% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden; border: 1px solid #8C8C8C; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; }.datagrid table td, .datagrid table th { padding: 3px 10px; }.datagrid table thead th {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; color:#FFFFFF; font-size: 15px; font-weight: bold; border-left: 1px solid gray; } .datagrid table thead th:first-child { border: none; }.datagrid table tbody td { /*color: #7D7D7D;*/ border-left: 1px solid #DBDBDB;font-size: 12px;font-weight: normal; }.datagrid table tbody .alt td { background: #EBEBEB; color: #7D7D7D; }.datagrid table tbody td:first-child { border-left: none; }.datagrid table tbody tr:last-child td { border-bottom: none; }.datagrid table tfoot td div { border-top: 1px solid #8C8C8C;background: #EBEBEB;} .datagrid table tfoot td { padding: 0; font-size: 12px } .datagrid table tfoot td div{ padding: 2px; }.datagrid table tfoot td ul { margin: 0; padding:0; list-style: none; text-align: right; }.datagrid table tfoot  li { display: inline; }.datagrid table tfoot li a { text-decoration: none; display: inline-block;  padding: 2px 8px; margin: 1px;color: #F5F5F5;border: 1px solid #8C8C8C;-webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; }.datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover { text-decoration: none;border-color: #7D7D7D; color: #F5F5F5; background: none; background-color:#8C8C8C;}div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }
    
     /*td:nth-of-type(1) {display: none;}*/
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
            <div id="innerbox_MidMain" style="height:33px;">
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                     Single Window Notes
                      </div>
                    
                    <div id="popupwindow_closebut_right_new">
                       <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                        
                    </div>
           
                </div>
                
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>

                
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 300px; width:890px; margin-top: -16px; overflow:hidden;">
                 <%--       <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow-x: hidden;overflow-y: auto; height:300px; width:888px; ">--%>

                        <%-----------------------Test--------------------------------------------------------%>
                            <ajax:TabContainer ID="TabContainer1" runat="server">
                                <ajax:TabPanel ID="tbpnluser" runat="server">
                                    <HeaderTemplate>
                                      <span style="color:Red; font-size:12px; font-weight:bold;" >  AQCS </span>
                                    
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel ID="UserReg" runat="server">
                                            <table align="center"  width="100%" > 
                                                <tr>
                                                    <td  colspan ="6" align="center" >
                                                        <b>AQCS  ( Animal Quarantine Inspn. Service ) </b>
                                                    </td>
                                                </tr>

                                                <tr >
                                                    <td>
                                                    </td>
                                                    <td style="font-weight:bold;color:Blue" >
                                                        Info Cd
                                                    </td>
                                                    <td style="font-weight:bold;color:Blue">
                                                       Info Desc
                                                    </td>
                                                      <td style="font-weight:bold;color:Blue">
                                                        QFR Cd
                                                    </td>
                                                    <td style="font-weight:bold;color:Blue">
                                                        QFR Desc
                                                    </td>
                                                     <td style="font-weight:bold;color:Blue">
                                                        REQ
                                                    </td>
                                                    <td style="font-weight:bold;color:Blue">
                                                        Man Opt
                                                    </td>
                                                </tr>

                                                <tr >
                                                    <td>
                                                    </td>
                                                    <td >
                                                        PNM
                                                    </td>
                                                    <td >
                                                       Product Name
                                                    </td>
                                                      <td >
                                                        COM
                                                    </td>
                                                    <td >
                                                       Common Name
                                                    </td>
                                                     <td >
                                                        Text
                                                    </td>
                                                    <td  style="font-weight:bold;color:Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CHR
                                                    </td>
                                                    <td>
                                                        Item Characteristics
                                                    </td>
                                                    <td>
                                                        BRD
                                                    </td>
                                                    <td>
                                                        Breed
                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CHR
                                                    </td>
                                                    <td>
                                                        Item Characteristics
                                                    </td>
                                                    <td>
                                                        CLR
                                                    </td>
                                                    <td>
                                                        Colour
                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CHR
                                                    </td>
                                                    <td>
                                                        Item Characteristics
                                                    </td>
                                                    <td>
                                                        SEX
                                                    </td>
                                                    <td>
                                                        Sex
                                                    </td>
                                                    <td>
                                                        Code
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CTG
                                                    </td>
                                                    <td>
                                                        Item Category

                                                    </td>
                                                    <td>
                                                        GRA
                                                    </td>
                                                    <td>
                                                        Grade of the Product
                                                    </td>
                                                    <td>
                                                        Code
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        IDT

                                                    </td>
                                                    <td>
                                                        Item Identification
                                                    </td>
                                                    <td>
                                                        MIC
                                                    </td>
                                                    <td>
                                                        Microchips numbers inserted into animals for identifification purposes
                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        IDT

                                                    </td>
                                                    <td>
                                                        Item Identification
                                                    </td>
                                                    <td>
                                                        PAS

                                                    </td>
                                                    <td>
                                                        Animal Passport Number
                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        PNM
                                                    </td>
                                                    <td>
                                                        Product Name
                                                    </td>
                                                    <td>
                                                        PET
                                                    </td>
                                                    <td>
                                                       Pet Name
                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        PNM
                                                    </td>
                                                    <td>
                                                        Product Name
                                                    </td>
                                                    <td>
                                                        SCI
                                                    </td>
                                                    <td>
                                                        Scientific Name
                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                  <%--<tr >
                                                    <td>
                                                    </td>
                                                    <td >
                                                        Info Cd
                                                    </td>
                                                    <td >
                                                       Info Desc
                                                    </td>
                                                      <td >
                                                        QFR Cd
                                                    </td>
                                                    <td >
                                                        QFR Desc
                                                    </td>
                                                     <td >
                                                        REQ
                                                    </td>
                                                    <td >
                                                        Man Opt
                                                    </td>
                                                </tr>--%>
                                               
                                               

                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </ajax:TabPanel>

                                <ajax:TabPanel ID="tbpnlusrdetails" runat="server">
                                    <HeaderTemplate>
                                     <span style="color:Red; font-size:12px; font-weight:bold;" >  FSSAI </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel1" runat="server">
                                            <table align="center"  width="100%" > 
                                                <tr>
                                                    <td  colspan ="6" align="center" >
                                                        <b>FSSAI  ( Foods Safety & Standards Authority ) </b>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="font-weight:bold;color:Blue" >
                                                        Info Cd
                                                    </td>
                                                    <td style="font-weight:bold;color:Blue">
                                                       Info Desc
                                                    </td>
                                                      <td style="font-weight:bold;color:Blue">
                                                        QFR Cd
                                                    </td>
                                                    <td style="font-weight:bold;color:Blue">
                                                        QFR Desc
                                                    </td>
                                                     <td style="font-weight:bold;color:Blue">
                                                        REQ
                                                    </td>
                                                    <td style="font-weight:bold;color:Blue">
                                                        Man Opt
                                                    </td>
                                                </tr>

                                                <tr >
                                                    <td>
                                                    </td>
                                                    <td >
                                                        CHR
                                                    </td>
                                                    <td >
                                                       Item Characteristics

                                                    </td>
                                                      <td >
                                                        STC

                                                    </td>
                                                    <td >
                                                       Storage Condition

                                                    </td>
                                                     <td >
                                                       Code
                                                    </td>
                                                    <td  style="font-weight:bold;color:Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                 

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CTG

                                                    </td>
                                                    <td>
                                                        Item Category
                                                    </td>
                                                    <td>
                                                        FSP
                                                    </td>
                                                    <td>
                                                        Foods & Supplement Proprietry Status
                                                    </td>
                                                    <td>
                                                        Code

                                                    </td>
                                                    <td style="font-weight:bold;color:Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                <tr >
                                                    <td>
                                                    </td>
                                                    <td >
                                                        IDT
                                                    </td>
                                                    <td >
                                                       Item Identification

                                                    </td>
                                                      <td >
                                                        RFA

                                                    </td>
                                                    <td >
                                                       Retail Pre-pack Food Article

                                                    </td>
                                                     <td >
                                                       Code
                                                    </td>
                                                    <td  style="font-weight:bold;color:Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CHR
                                                    </td>
                                                    <td>
                                                        Item Characteristics
                                                    </td>
                                                    <td>
                                                        STT

                                                    </td>
                                                    <td>
                                                        Storage Temperature

                                                    </td>
                                                    <td>
                                                        UQC

                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CTG

                                                    </td>
                                                    <td>
                                                       Item Category

                                                    </td>
                                                    <td>
                                                        GRA

                                                    </td>
                                                    <td>
                                                        Grade of the Product

                                                    </td>
                                                    <td>
                                                        Code
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CTG

                                                    </td>
                                                    <td>
                                                        Item Category

                                                    </td>
                                                    <td>
                                                        IFC

                                                    </td>
                                                    <td>
                                                       Indian Food Code
                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        IDT


                                                    </td>
                                                    <td>
                                                        Item Identification

                                                    </td>
                                                    <td>
                                                       GTI

                                                    </td>
                                                    <td>
                                                        Global Trade Item Number

                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td>
                                                        Optional
                                                    </td>
                                                </tr>


                                                
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </ajax:TabPanel>
                                <ajax:TabPanel ID="tbpnljobdetails" runat="server">
                                    <HeaderTemplate>
                                       <span style="color:Red; font-size:12px; font-weight:bold;" >  PQIS </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel2" runat="server">
                                            <table align="center" width="100%">
                                                <tr>
                                                    <td colspan="6" align="center">
                                                        <b>PQIS  ( Plant Protection and Quarantine ) </b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        REQ
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Man Opt
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CHR
                                                    </td>
                                                    <td>
                                                        Item Characteristics
                                                    </td>
                                                    <td>
                                                        PLV
                                                    </td>
                                                    <td>
                                                        Plant Variety
                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CTG
                                                    </td>
                                                    <td>
                                                        Item Category
                                                    </td>
                                                    <td>
                                                        PLC
                                                    </td>
                                                    <td>
                                                        plant Category
                                                    </td>
                                                    <td>
                                                        Code(MSR)
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CTG
                                                    </td>
                                                    <td>
                                                        Item Category
                                                    </td>
                                                    <td>
                                                        PLP
                                                    </td>
                                                    <td>
                                                        Plant Parts
                                                    </td>
                                                    <td>
                                                        Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        PNM
                                                    </td>
                                                    <td>
                                                        Product Name
                                                    </td>
                                                    <td>
                                                        PCN
                                                    </td>
                                                    <td>
                                                        Plant Commodity Name
                                                    </td>
                                                    <td>
                                                        Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        PNM
                                                    </td>
                                                    <td>
                                                        Product Name
                                                    </td>
                                                    <td>
                                                        SCI
                                                    </td>
                                                    <td>
                                                        Scientific Name
                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                            </table>




                                            <table align="center" width="100%">
                                                <tr>
                                                    <td colspan="6" align="center">
                                                        <b>SW Control</b>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                       Type Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Location
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Result Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Start Date
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        End Date
                                                    </td>

                                                     <td style="font-weight: bold; color: Blue">
                                                         Man Opt 
                                                    </td>
                                                   
                                                </tr>



                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td >
                                                       004W01
                                                    </td>
                                                    <td >
                                                        Your Location
                                                    </td>
                                                    <td >
                                                        004W0101
                                                    </td>
                                                    <td >
                                                       Your Date
                                                    </td>
                                                    <td >
                                                        Your Date
                                                    </td>

                                                     <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                                <%--<tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CHR
                                                    </td>
                                                    <td>
                                                        Item Characteristics
                                                    </td>
                                                    <td>
                                                        PLV
                                                    </td>
                                                    <td>
                                                        Plant Variety
                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>--%>
                                               
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </ajax:TabPanel>
                                <ajax:TabPanel ID="TabPanel1" runat="server">
                                    <HeaderTemplate>
                                       
                                       <span style="color:Red; font-size:12px; font-weight:bold;" >  WCCB </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel3" runat="server">
                                           <table align="center" width="100%">
                                                <tr>
                                                    <td colspan="6" align="center">
                                                        <b>WCCB ( Wildlife Crime Control Bureau ) </b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        REQ
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Man Opt
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        PNM

                                                    </td>
                                                    <td>
                                                        Product Name

                                                    </td>
                                                    <td>
                                                        COM

                                                    </td>
                                                    <td>
                                                        Common Name

                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        PNM

                                                    </td>
                                                    <td>
                                                        Product Name

                                                    </td>
                                                    <td>
                                                        SCI

                                                    </td>
                                                    <td>
                                                        Scientific Name

                                                    </td>
                                                    <td>
                                                        Text

                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CHR

                                                    </td>
                                                    <td>
                                                        Item Characteristics

                                                    </td>
                                                    <td>
                                                        CLR

                                                    </td>
                                                    <td>
                                                        Colour

                                                    </td>
                                                    <td>
                                                        Text

                                                    </td>
                                                    <td >
                                                        Optional

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CHR

                                                    </td>
                                                    <td>
                                                       Item Characteristics

                                                    </td>
                                                    <td>
                                                       SEX

                                                    </td>
                                                    <td>
                                                        Sex

                                                    </td>
                                                    <td>
                                                        Code
                                                    </td>
                                                    <td >
                                                        Optional

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        PNM

                                                    </td>
                                                    <td>
                                                        Product Name
                                                    </td>
                                                    <td>
                                                        CON

                                                    </td>
                                                    <td>
                                                        Trade or Commercial Name

                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td >
                                                        Optional

                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        PNM

                                                    </td>
                                                    <td>
                                                        Product Name
                                                    </td>
                                                    <td>
                                                        PET


                                                    </td>
                                                    <td>
                                                       Pet Name


                                                    </td>
                                                    <td>
                                                        Text
                                                    </td>
                                                    <td >
                                                        Optional

                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </ajax:TabPanel>
                                <ajax:TabPanel ID="TabPanel2" runat="server">
                                    <HeaderTemplate>
                                       
                                       <span style="color:Red; font-size:12px; font-weight:bold;" >  CDRUG </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel4" runat="server">
                                             <table align="center" width="100%">
                                                <tr>
                                                    <td colspan="6" align="center">
                                                        <b>CDRUG ( Central Drugs Standard Control Org. ) </b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        REQ
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Man Opt
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CTG

                                                    </td>
                                                    <td>
                                                        Item Category

                                                    </td>
                                                    <td>
                                                        DRC

                                                    </td>
                                                    <td>
                                                        Drug Related Category

                                                    </td>
                                                    <td>
                                                        Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </ajax:TabPanel>


                                 <ajax:TabPanel ID="TabPanel3" runat="server">
                                    <HeaderTemplate>
                                       
                                       <span style="color:Red; font-size:12px; font-weight:bold;" >  SIMS </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel5" runat="server">
                                           <table align="center" width="100%">
                                                <tr>
                                                    <td colspan="6" align="center">
                                                        <b>SIMS ( Steel Import Monitoring System ) </b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        REQ
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Man Opt
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        PNM

                                                    </td>
                                                    <td>
                                                        Product Name

                                                    </td>
                                                    <td>
                                                        SIU

                                                    </td>
                                                    <td>
                                                       Steel Import 

                                                    </td>
                                                    <td>
                                                     Code & Text
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                               
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </ajax:TabPanel>

                                 <ajax:TabPanel ID="TabPanel_FTA" runat="server">
                                    <HeaderTemplate>
                                       
                                       <span style="color:Red; font-size:12px; font-weight:bold;" >  FTA </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel6" runat="server">
                                           <table align="center" width="100%">
                                                <tr>
                                                    <td colspan="6" align="center">
                                                        <b>FTA ( Foreign Trade Agreement ) </b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        REQ
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Man Opt
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        ORC

                                                    </td>
                                                    <td>
                                                        Origin Criteria

                                                    </td>
                                                    <td>
                                                        COO

                                                    </td>
                                                    <td>
                                                       Certificate of Origin Particulars

                                                    </td>
                                                    <td>
                                                     Code & Text
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                
                                                
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        ORC

                                                    </td>
                                                    <td>
                                                        Origin Criteria

                                                    </td>
                                                    <td>
                                                         COWO/

                                                    </td>
                                                    <td>
                                                       Wholly Obtained

                                                    </td>
                                                    <td>
                                                       
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                                 <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        

                                                    </td>
                                                    <td>
                                                      
                                                    </td>
                                                    <td>
                                                        CONWO(COOG/COOP)
                                                    </td>
                                                    <td>
                                                       Others (General Rule)

                                                    </td>
                                                    <td>
                                                     Code & Text(NUM/NA) & UQC
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        

                                                    </td>
                                                    <td>
                                                       
                                                    </td>
                                                    <td>
                                                      
                                                    </td>
                                                    <td>
                                                        Others (Product Specific Rule)
                                                    </td>
                                                    <td>
                                                     Code & Text(NUM/NA) & UQC
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                                 <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        ORC

                                                    </td>
                                                    <td>
                                                        Origin Criteria

                                                    </td>
                                                    <td>
                                                        ACM

                                                    </td>
                                                    <td>
                                                      Accumulation/Cumulation - Yes

                                                    </td>
                                                    <td>
                                                     Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        

                                                    </td>
                                                    <td>
                                                       
                                                    </td>
                                                    <td>
                                                        

                                                    </td>
                                                    <td>
                                                      Accumulation/Cumulation - No

                                                    </td>
                                                    <td>
                                                     Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        ORC

                                                    </td>
                                                    <td>
                                                        Origin Criteria

                                                    </td>
                                                    <td>
                                                       RIS

                                                    </td>
                                                    <td>
                                                      Restroactive Issuance - Yes

                                                    </td>
                                                    <td>
                                                     Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        

                                                    </td>
                                                    <td>
                                                       
                                                    </td>
                                                    <td>
                                                        

                                                    </td>
                                                    <td>
                                                      Restroactive Issuance - No

                                                    </td>
                                                    <td>
                                                     Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                                  <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        ORC

                                                    </td>
                                                    <td>
                                                        Origin Criteria

                                                    </td>
                                                    <td>
                                                        DC

                                                    </td>
                                                    <td>
                                                      Direct Consignment - Yes

                                                    </td>
                                                    <td>
                                                     Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        

                                                    </td>
                                                    <td>
                                                       
                                                    </td>
                                                    <td>
                                                        

                                                    </td>
                                                    <td>
                                                     Direct Consignment - No

                                                    </td>
                                                    <td>
                                                     Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                                                                               
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </ajax:TabPanel>

                                <ajax:TabPanel ID="TabPanel_8517" runat="server">
                                    <HeaderTemplate>
                                       
                                       <span style="color:Red; font-size:12px; font-weight:bold;" >  PID </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel7" runat="server">
                                           <table align="center" width="100%">
                                                <tr>
                                                    <td colspan="6" align="center">
                                                        <b>PID ( Product Identifier ) </b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        REQ
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Man Opt
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        PNM

                                                    </td>
                                                    <td>
                                                        Product Name

                                                    </td>
                                                    <td>
                                                        PID

                                                    </td>
                                                    <td>
                                                       Product Identifier 

                                                    </td>
                                                    <td>
                                                     Code 
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>
                                               
                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </ajax:TabPanel>

                                 <ajax:TabPanel ID="TabPanel_DCPC" runat="server">
                                    <HeaderTemplate>
                                       
                                       <span style="color:Red; font-size:12px; font-weight:bold;" >  DCPC </span>
                                    </HeaderTemplate>
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel18" runat="server">
                                             <table align="center" width="100%">
                                                <tr>
                                                    <td colspan="6" align="center">
                                                        <b>DCPC ( Department of Checmicals and PetroChemicals(DCPC) AIMS ) </b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Info Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Cd
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        QFR Desc
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        REQ
                                                    </td>
                                                    <td style="font-weight: bold; color: Blue">
                                                        Man Opt
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        CTG

                                                    </td>
                                                    <td>
                                                        Item Category

                                                    </td>
                                                    <td>
                                                        CPC

                                                    </td>
                                                    <td>
                                                        Chemical Products

                                                    </td>
                                                    <td>
                                                        Code
                                                    </td>
                                                    <td style="font-weight: bold; color: Red;">
                                                        Mandatory
                                                    </td>
                                                </tr>

                                            </table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </ajax:TabPanel>

                            </ajax:TabContainer>
                            <%-----------------------Test-E-------------------------------------------------------%>
                        </div>
                        <%-----------------------Test--------------------------------------------------------%>
                    </div>
               
                <%-----------------------------------END----------------------------------------------------------------%>
            
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
            document.getElementById("General").click();
        }
        
    </script>
   
    
</body>
</html>
