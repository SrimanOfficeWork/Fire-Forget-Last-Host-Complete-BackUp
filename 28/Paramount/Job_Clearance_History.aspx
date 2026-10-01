<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Job_Clearance_History.aspx.cs" 
    Inherits="Job_Clearance_History"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export Job Clearance</title>
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
    <script src="../js/Export_Rpt/BL_Generation.js" type="text/javascript"></script>


    <script language="javascript">

        function CheckAll() {

            var intIndex = 0;

            var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;

            for (i = 0; i < rowCount; i++) {

                if (document.getElementById('cbAll').checked == true) {

                    if (document.getElementById("cbList" + "_" + i)) {

                        if (document.getElementById("cbList" + "_" + i).disabled != true)

                            document.getElementById("cbList" + "_" + i).checked = true;

                    }

                }

                else {

                    if (document.getElementById("cbList" + "_" + i)) {

                        if (document.getElementById("cbList" + "_" + i).disabled != true)

                            document.getElementById("cbList" + "_" + i).checked = false;

                    }

                }

            }

        }



        function UnCheckAll() {

            var intIndex = 0;

            var flag = 0;

            var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;

            for (i = 0; i < rowCount; i++) {

                if (document.getElementById("cbList" + "_" + i)) {

                    if (document.getElementById("cbList" + "_" + i).checked == true) {

                        flag = 1;

                    }

                    else {

                        flag = 0;

                        break;

                    }

                }

            }

            if (flag == 0)

                document.getElementById('cbAll').checked = false;

            else

                document.getElementById('cbAll').checked = true;
        }

    </script>
    
     <script language="jscript" type="text/javascript">

         function tab_page1() {

             document.getElementById("page-1").style.display = 'Block';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';
         }
         function tab_page2() {

             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'Block';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';
         }
         function tab_page3() {
             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'Block';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';
         }
         function tab_page4() {
             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'Block';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';
         }
         function tab_page5() {
             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'Block';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';
         }
         function tab_page6() {
             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'Block';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';
         }
         function tab_page7() {
             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'Block';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';
         }
         function tab_page8() {
             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'Block';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';
         }
         function tab_page9() {
             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'Block';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';
         }
         function tab_page10() {
             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'Block';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';
         }
         function tab_page11() {
             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'Block';
             document.getElementById("page-12").style.display = 'none';
         }
     function tab_page12() {
             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'Block';
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
        .txtbox_none_invoice_no {
            border: thin solid #c8c8c8;
            border-radius: 5px;
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 100px;
            margin-top: 2px;
            max-height: 100px;
            max-width: 590px;
            overflow: hidden;
            width: 585px;
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
            <div id="innerbox_MidMain_Transact_popup_new" style="height:129px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:110px;">
                       
                         Exporter Name
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:310px;">
                         <asp:DropDownList ID="ddlExp_name" runat="server" AutoPostBack="true"
                             CssClass="listtxt_transac_src1" Width="300px" 
                             onselectedindexchanged="ddlExp_name_SelectedIndexChanged" TabIndex="1">
                         </asp:DropDownList>
                    </div>
                        <div id="mainmastop2container_rght_tag2_txt1" style="width:35px;">
                         Mode
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:60px;">
                     <asp:DropDownList ID="ddltr_mode" runat="server" AutoPostBack="true"
                             CssClass="listtxt_transac_src1" Width="58px" 
                            onselectedindexchanged="ddltr_mode_SelectedIndexChanged"  >
                             
                         </asp:DropDownList>
                    </div>

                     <div id="mainmastop2container_rght_tag2_txt1" style="width:80px;">
                         Ref.Name
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:190px;">

                     <asp:TextBox ID="txtId" runat="server" MaxLength="35" Width="40px" BackColor="#F0F0F0"
                             CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>

                        <asp:TextBox ID="txtrefname" runat="server" MaxLength="35" ClientIDMode="Static" Width="137px"
                            TabIndex="2" CssClass=" txtbox_none_Mid_transac_pop_gen" ></asp:TextBox>
                            
                    </div>

                    <div id="mainmastop2container_rght_tag2_txt1"   style="width:50px; margin-top:-1px;"">
                    
                      <asp:Button ID="btngenerate" CssClass="generate" runat="server" OnClick="btngenerate_Click"/>
                   
                    </div>

                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>
       
                   <div id="Div_listbox" runat="server">
                <div id="tag_transact_src_inner" style="width:960px;">
                 
                            
                            <div id="innerbox_MidMain_Trans_new" style="width:980px; height:25px; margin-left:-10px; border-bottom-style:solid;  ">
                             

                            <div id="tag_label_transaction_exp_jobb" >
                            <asp:CheckBox ID="cbAll" runat="server" ForeColor="White" Font-Bold="true" font-size= "14px" Text="Select All" onclick="CheckAll();" />
                        </div>
                        </div>

                         
                         <div id="tag_label_transaction_exp_jobb" style="width: 970px; overflow:auto; height:72px;" >
                                <asp:CheckBoxList ID="cbList" runat="server" ValidationGroup="VGroup" onclick="UnCheckAll();" 
                                CssClass=" txtbox_none_Mid_transac_pop_gen" width= "951px" Height="22px" Font-Size="12px"
                                    RepeatColumns="8" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                         </div>
                    
        </div>
                    </div>
         </div>

                    <asp:HiddenField ID="HiddenField2" runat="server" />
                      <asp:HiddenField ID="hdn_isvalue" runat="server" />
                      
                      

           <%-- -------------------------------------Tab--------------------------------------------------------%>

           
           <div id="innerbox_MidMain_Trans_new" style="width:990px; height:380px;" >
                <ol id="toc_new">
                   
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');" id="INV">
                        <span>Invoice </span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2('0');" id="Book">
                        <span>[ Booking / Empty Plot / Vehicle / Container / Factory ] </span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3('0');" id="SB">
                         <span> [ SB / Tentative / Customs / Confirmed Vessel ] </span></a></li>
                    <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4('0');" id="PS">
                        <span>[ Post Shipment / BL /  TPT ]</span></a></li>

                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:425px;width: 1000px;">
                    <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                            Shipper Name
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1" >
                         <asp:TextBox ID="txt_Shipper_Name" runat="server" MaxLength="150" ClientIDMode="Static" Font-Size="12px"
                                                TabIndex="5" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                     
                         <%--<div id="magnify_area">
                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Exporter'); return false">
                                            </a>
                        </div>
                         <div id="magnify_area" style="width:45px;">
                         <asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server"  
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_client_Masternew('Exporter'); return false" />
                        </div>--%>

                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Consignee Name
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1" >
                         <asp:TextBox ID="txt_Consignee_Name" runat="server" MaxLength="165" ClientIDMode="Static" TabIndex="6" 
                          Font-Size="12px" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div> 

                      <%--  <div id="magnify_area" style="width:30px">
                         <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Notify'); return false">
                                            </a>
                        </div>  

                         <div id="tag_label_transaction_exp_jobb" style="width:40px">
                         <asp:Button ID="Button2" CssClass="autowidnewbut" Text="New" runat="server"  
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_client_Masternew('Notify'); return false" />
                        </div>--%>
                           <div id="magnify_area">

                             
                                  
                        </div>
                    </div>
                    <%-------------Row 2--------------------------------------%>

                    <div id="tag_transac_exp_drawback" style="width:950px;height:120px;">
                        <div id="tag_label_transaction_exp_jobb">
                            Invoice Number
                        </div>
                         <div id="txtcon-m_transaction_pop_gen1" style="width: 585px ;height:100px; ">
                                <asp:TextBox ID="txt_Invoice_no" runat="server" CssClass="txtbox_none_invoice_no"
                                   MaxLength="500" Height="100px" TextMode="MultiLine"  
                                    TabIndex="7"></asp:TextBox>
                            </div>
                    </div>
                     <%-------------Row 3--------------------------------------%>
                     <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                            Port Name
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="txt_port_name" runat="server" MaxLength="135" ClientIDMode="Static"
                                                TabIndex="8" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_exp_jobb">
                             Gross Weight
                        </div>
                           <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txt_gross_wgt" runat="server" MaxLength="70" ClientIDMode="Static"
                                                TabIndex="10" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       
                        <div id="magnify_area" style="width:15px">
                        </div>
                          <div id="txtcon-m_transaction_pop_gen1" style="width:15px">
                        </div> 
                        
                    </div>
                      <%-------------Row 4--------------------------------------%>
                      <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                           Net Weight
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txt_net_wgt" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="70" TabIndex="11"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                     <div id="tag_label_transaction_exp_jobb">
                           Copy
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txt_Copy" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="50" TabIndex="12"></asp:TextBox>
                        </div>

                         <div id="magnify_area" style="width:15px">
                        </div> 

                        <div id="txtcon-m_transaction_pop_gen1" style="width:15px">
                        </div> 
                    </div>
                     <%-------------Row 5--------------------------------------%>
                     <div id="tag_transac_exp_drawback" style="width:950px">
                        <div id="tag_label_transaction_exp_jobb">
                           ORI
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txt_Ori" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="50" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        
                    </div>
                     
                    </div>
                </div>



                <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:425px;">
                  
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                               Booking On
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_booking_on_date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="20"></asp:TextBox>
                            </div>
                         
                            <div id="tag_label_transaction_exp_jobb">
                                Liner Name
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width:440px;">
                                <asp:TextBox ID="txt_liner_name" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" Width="440px" TabIndex="21"></asp:TextBox>
                            </div>
                        </div>
                     <%-- ----------------Row 2-------------------------%>
                      <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                               Booking Number
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_booking_no" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="22"></asp:TextBox>
                            </div>
                         
                            <div id="tag_label_transaction_exp_jobb">
                                Fowarder Name
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width:440px;">
                                <asp:TextBox ID="txt_Fowarder_name" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" Width="440px" TabIndex="23"></asp:TextBox>
                            </div>
                        </div>
                       
                   
                       
                        <div id="tag_transac_exp_drawback" style="width: 950px; font-weight:bold;">
                              
                                <asp:TextBox ID="txtplot_det" runat="server" BorderColor="black" Enabled="false" BackColor="#EEEEFF" Font-Bold="true"  Width="140px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                   text="   Empty Plot" ></asp:TextBox>
                              ----------------------------------------------------------------------------------------------------------------------
                        </div>

                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                              IN Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_Empty_Plot_In_date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="30" TabIndex="30"></asp:TextBox>
                            </div>
                         
                            <div id="tag_label_transaction_exp_jobb">
                               OUT Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_Empty_Plot_Out_date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="30" TabIndex="31"></asp:TextBox>
                            </div>
                        </div>
                     
                        <div id="tag_transac_exp_drawback" style="width: 950px; font-weight:bold;">
                                <asp:TextBox ID="txtveh_det" runat="server" BorderColor="black" Enabled="false" BackColor="#EEEEFF" Font-Bold="true"  Width="140px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                   text="  Vehicle Details" ></asp:TextBox>
                              ----------------------------------------------------------------------------------------------------------------------
                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                         <div id="tag_label_transaction_exp_jobb">
                                Factory to cfs
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width:440px;">
                                <asp:TextBox ID="txt_Vehicle_Factory_to_cfs" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="70" Width="440px" TabIndex="32"></asp:TextBox>
                            </div>
                             <div id="magnify_area">
                             </div>
                            <div id="tag_label_transaction_exp_jobb">
                              Vehicle Number
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_Vehicle_Number" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="33"></asp:TextBox>
                            </div>
                         
                           
                        </div>

                          

                         <div id="tag_transac_exp_drawback" style="width: 950px">
                         <div id="tag_label_transaction_exp_jobb">
                                Cfs to Port
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width:440px;">
                                <asp:TextBox ID="txt_Vehicle_Cfs_to_Port" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="70" Width="440px" TabIndex="34"></asp:TextBox>
                            </div>
                             <div id="magnify_area">
                             </div>
                            <div id="tag_label_transaction_exp_jobb">
                              Vehicle Number
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_Vehicle_Number_2" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="35"></asp:TextBox>
                            </div>
                         
                           
                        </div>
                     

                             <div id="tag_transac_exp_drawback" style="width: 950px; font-weight:bold;">
                             <asp:TextBox ID="txtcon_det" runat="server" BorderColor="black" Enabled="false" BackColor="#EEEEFF" Font-Bold="true"  Width="140px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                   text="  Container Details" ></asp:TextBox>
                             ----------------------------------------------------------------------------------------------------------------------
                        </div>

                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             Con. Size
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 75px; font-size:12px;">
                                <asp:TextBox ID="txt_Container_size" runat="server" Width="75px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="100" TabIndex="40"></asp:TextBox>
                            </div>
                         <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb">
                               CNTR Number
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size:12px;">
                                <asp:TextBox ID="txt_Con_CNTR_No" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="500" TabIndex="41"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                              <div id="tag_label_transaction_exp_jobb" style="width: 80px;">
                             S. Number

                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 100px; font-size:12px;">
                                <asp:TextBox ID="txt_Container_S_no" runat="server" Width="100px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="100" TabIndex="42"></asp:TextBox>
                            </div>
                            <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 35px;">
                               F/L/A
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 85px; font-size:12px;">
                                <asp:TextBox ID="txt_Con_F_L_A" runat="server" Width="85px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="43"></asp:TextBox>
                            </div>

                        </div>


                       <div id="tag_transac_exp_drawback" style="width: 950px; font-weight:bold;">
                                <asp:TextBox ID="txtFact_det" runat="server" BorderColor="black" Enabled="false" BackColor="#EEEEFF" Font-Bold="true"  Width="140px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                   text="   Factory Details" ></asp:TextBox>
                                ----------------------------------------------------------------------------------------------------------------------
                        </div>

                          <div id="tag_transac_exp_drawback" style="width: 950px">

                           <div id="tag_label_transaction_exp_jobb">
                              IN Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_Factory_In_date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="30" TabIndex="44"></asp:TextBox>
                            </div>
                         
                            <div id="tag_label_transaction_exp_jobb">
                               OUT Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_Factory_Out_date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="30" TabIndex="45"></asp:TextBox>
                            </div>
                            </div>
                             <div id="tag_transac_exp_drawback" style="width: 950px">
                               <div id="tag_label_transaction_exp_jobb">
                             Halt From
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_Factory_halt_From" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="46"></asp:TextBox>
                            </div>
                         
                            <div id="tag_label_transaction_exp_jobb">
                              Halt To 
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 175px; font-size:12px;">
                                <asp:TextBox ID="txt_Factory_halt_To" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="47"></asp:TextBox>
                            </div>

                           
                        </div>
                         <div id="tag_transac_exp_drawback" style="width: 950px">
                               <div id="tag_label_transaction_exp_jobb">
                            Remarks
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 735px; font-size:12px;">
                                <asp:TextBox ID="txt_Factory_Remarks" runat="server"  Width="735px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="500" TabIndex="48"></asp:TextBox>
                            </div>
                        </div>

                         
                       <%-- -------------------------------------------------%>

                    </div>
                </div>
                <div class="content" id="page-3" >
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:350px; width:980px; overflow:hidden;">
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                               <div id="tag_label_transaction_exp_jobb">
                            SB Number
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 735px; font-size:12px;">
                                <asp:TextBox ID="txt_SB_No" runat="server"  Width="735px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="500" TabIndex="52"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             SB Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 2225x; font-size:12px;">
                                <asp:TextBox ID="txt_SB_Date" runat="server" Width="225px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="53"></asp:TextBox>
                            </div>
                         <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb">
                               
                               DBK Amount
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size:12px;">
                                <asp:TextBox ID="txt_DBK_amt" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="54"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                              <div id="tag_label_transaction_exp_jobb" style="width: 80px;">
                             Type of SB

                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 100px; font-size:12px;">
                                <asp:TextBox ID="txt_Type_of_SB" runat="server" Width="100px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="200" TabIndex="55"></asp:TextBox>
                            </div>

                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                               <div id="tag_label_transaction_exp_jobb">
                            Remarks
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 735px; font-size:12px;">
                                <asp:TextBox ID="txt_SB_Remarks" runat="server"  Width="735px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="500" TabIndex="56"></asp:TextBox>
                            </div>
                        </div>


                       <%--<div id="innerbox_MidMain_Trans_new" style="width: 130px; height: 20px; margin-left: 0px;
                            border-bottom-style: solid;">
                            <div id="tag_label_transaction_exp_jobb" style="color: black; font-weight: bold;margin-left: 5px;">
                                Tentatiave vessel 
                            </div>
                        </div>--%>
                        <div id="tag_transac_exp_drawback" style="width: 950px; font-weight:bold;">
                                <asp:TextBox ID="txtTet_det" runat="server" BorderColor="black" Enabled="false" BackColor="#EEEEFF" Font-Bold="true"  Width="140px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                   text=" Tentatiave vessel" ></asp:TextBox>
                               ----------------------------------------------------------------------------------------------------------------------
                        </div>
                         <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             Vessel Planned
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 225px; font-size:12px;">
                                <asp:TextBox ID="txt_vessel_Planned" runat="server" Width="225px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="60"></asp:TextBox>
                            </div>
                         <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb">
                               
                               Voyage
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size:12px;">
                                <asp:TextBox ID="txt_tentative_voyage" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="61"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                              <div id="tag_label_transaction_exp_jobb" style="width: 80px;">
                            ETD

                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 100px; font-size:12px;">
                                <asp:TextBox ID="txt_tentative_ETD_date" runat="server" Width="100px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="30" TabIndex="62"></asp:TextBox>
                            </div>

                        </div>
                            
                         
                        <div id="tag_transac_exp_drawback" style="width: 950px; font-weight:bold;">
                              
                                <asp:TextBox ID="txtCus_det" runat="server" BorderColor="black" Enabled="false" BackColor="#EEEEFF" Font-Bold="true"  Width="140px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                   text=" Customs - Exam." ></asp:TextBox>
                                ----------------------------------------------------------------------------------------------------------------------
                        </div>
                         <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             CFS Name / Port
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size:12px;">
                                <asp:TextBox ID="txt_CFS_name_port" runat="server" Width="155px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="63"></asp:TextBox>
                            </div>
                         <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 90px;">
                              CFS IN / Port 
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 75px; font-size:12px;">
                                <asp:TextBox ID="txt_CFS_IN_port" Width="75px" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="65"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                              <div id="tag_label_transaction_exp_jobb" style="width: 80px;">
                                Off - Loaded
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 75px; font-size:12px;">
                                <asp:TextBox ID="txt_Off_loaded" runat="server" Width="75px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="66"></asp:TextBox>
                            </div>
                            <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 75px;">
                               Cus. Exam
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 85px; font-size:12px;">
                                <asp:TextBox ID="txt_Cus_Exam" runat="server" Width="85px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="67"></asp:TextBox>
                            </div>

                        </div>
                        
                          <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             Halting
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size:12px;">
                                <asp:TextBox ID="txt_Cus_Exam_Halting" runat="server" Width="155px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="68"></asp:TextBox>
                            </div>
                         <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 90px;">
                              Remarks
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 455px; font-size:12px;">
                                <asp:TextBox ID="txt_Cus_Exam_Remarks" Width="455px" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="500" TabIndex="69"></asp:TextBox>
                            </div>

                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             CFS Out
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 225px; font-size:12px;">
                                <asp:TextBox ID="txt_Cus_Exam_CFS_Out" runat="server" Width="225px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="70"></asp:TextBox>
                            </div>
                         <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb">
                               
                                Port IN Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size:12px;">
                                <asp:TextBox ID="txt_Cus_Exam_port_In_Date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="30" TabIndex="72"></asp:TextBox>
                            </div>
                           

                        </div>
                         <%--<div id="innerbox_MidMain_Trans_new" style="width: 130px; height: 20px; margin-left: 0px;
                            border-bottom-style: solid;">
                            <div id="tag_label_transaction_exp_jobb" style="color: black; font-weight: bold;margin-left: 5px;">
                                Confirmed Vessel Planning 
                            </div>
                        </div>--%>

                        <div id="tag_transac_exp_drawback" style="width: 950px; font-weight:bold;">
                             
                                <asp:TextBox ID="txtCVP_det" runat="server" BorderColor="black" Enabled="false" BackColor="#EEEEFF" Font-Bold="true"  Width="140px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                   text=" Confirmed Vessel" ></asp:TextBox>
                               ----------------------------------------------------------------------------------------------------------------------
                        </div>


                         <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             Halting
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 225px; font-size:12px;">
                                <asp:TextBox ID="txt_Confirmed_Vessel_Halting" runat="server" Width="225px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="73"></asp:TextBox>
                            </div>
                         <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb">
                               Vessel Name
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size:12px;">
                                <asp:TextBox ID="txt_Confirmed_Vessel_Name" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="74"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                              <div id="tag_label_transaction_exp_jobb" style="width: 80px;">
                            Voyage

                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 100px; font-size:12px;">
                                <asp:TextBox ID="txt_Confirmed_Vessel_Voyage" runat="server" Width="100px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="150" TabIndex="75"></asp:TextBox>
                            </div>

                        </div>
                         <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             Rotation No & Date 
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 225px; font-size:12px;">
                                <asp:TextBox ID="txt_Confirmed_Vessel_Rotation_No" runat="server" Width="225px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="235" TabIndex="76"></asp:TextBox>
                            </div>
                         <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb">
                               Gate Opening
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size:12px;">
                                <asp:TextBox ID="txt_Confirmed_Vessel_Gate_Opening" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="135" TabIndex="77"></asp:TextBox>
                            </div>
                           

                        </div>

                        </div>
                  
                </div>


                   <div class="content" id="page-4">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:425px;">
                     
                         <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                            Cut Of Time
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 225px; font-size:12px;">
                                <asp:TextBox ID="txt_Post_Shipment_Cut_of_time" runat="server" Width="225px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="45" TabIndex="80"></asp:TextBox>
                            </div>
                         <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb">
                               Form 13
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size:12px;">
                                <asp:TextBox ID="txt_Post_Shipment_Form_13" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="100" TabIndex="81"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                              <div id="tag_label_transaction_exp_jobb" style="width: 80px;">
                               ETA-MAA
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 100px; font-size:12px;">
                                <asp:TextBox ID="txt_Post_Shipment_ETA_MAA" runat="server" Width="100px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="100" TabIndex="82"></asp:TextBox>
                            </div>

                        </div>
                         <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                             ETD-MAA
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 225px; font-size:12px;">
                                <asp:TextBox ID="txt_Post_Shipment_ETD_MAA" runat="server" Width="225px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="100" TabIndex="83"></asp:TextBox>
                            </div>
                         <div id="magnify_area"></div>
                            <div id="tag_label_transaction_exp_jobb">
                              SI Sent Liner
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size:12px;">
                                <asp:TextBox ID="txt_Post_Shipment_SI_Sent_liner" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="200" TabIndex="84"></asp:TextBox>
                            </div>
                           

                        </div>
                        <%--<div id="innerbox_MidMain_Trans_new" style="width: 100px; height: 20px; margin-left: 0px;
                            border-bottom-style: solid;">
                            <div id="tag_label_transaction_exp_jobb" style="color: black; font-weight: bold;
                                margin-left: 5px;">
                                BL
                            </div>
                        </div>--%>
                           <div id="tag_transac_exp_drawback" style="width: 950px; font-weight:bold;">
                              
                                <asp:TextBox ID="txtBL_det" runat="server" BorderColor="black" Enabled="false" BackColor="#EEEEFF" Font-Bold="true"  Width="140px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                   text=" BL" ></asp:TextBox>
                                ----------------------------------------------------------------------------------------------------------------------
                           </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                                B/L Draft
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 225px; font-size: 12px;">
                                <asp:TextBox ID="txt_BL_Draft" runat="server" Width="225px" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="500" TabIndex="86"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Approve
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size: 12px;">
                                <asp:TextBox ID="txt_BL_Approve" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="100" TabIndex="88"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 80px;">
                                BL Number
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 100px; font-size: 12px;">
                                <asp:TextBox ID="txt_BL_Number" runat="server" Width="100px" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="100" TabIndex="89"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                                BL Date
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 225px; font-size: 12px;">
                                <asp:TextBox ID="txt_BL_Date" runat="server" Width="225px" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="90"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Release
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size: 12px;">
                                <asp:TextBox ID="txt_BL_Release" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="50" TabIndex="91"></asp:TextBox>
                            </div>
                        </div>

                        <%--<div id="innerbox_MidMain_Trans_new" style="width: 100px; height: 20px; margin-left: 0px;
                            border-bottom-style: solid;">
                            <div id="tag_label_transaction_exp_jobb" style="color: black; font-weight: bold;
                                margin-left: 5px;">
                                TPT Name Bill
                            </div>
                        </div>--%>

                            <div id="tag_transac_exp_drawback" style="width: 950px; font-weight:bold;">
                             
                                <asp:TextBox ID="txtTPT_det" runat="server" BorderColor="black" Enabled="false" BackColor="#EEEEFF" Font-Bold="true"  Width="140px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                   text=" TPT Name Bill" ></asp:TextBox>
                                ----------------------------------------------------------------------------------------------------------------------
                           </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                               Doc. Sent Shipper
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 225px; font-size: 12px;">
                                <asp:TextBox ID="txt_TPT_Doc_Sent_Shipper" runat="server" Width="225px" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="80" TabIndex="92"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                               Factory to Cfs
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size: 12px;">
                                <asp:TextBox ID="txt_TPT_Factory_to_Cfs" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="100" TabIndex="95"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 80px;">
                              Bill No & Dt.
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 100px; font-size: 12px;">
                                <asp:TextBox ID="txt_TPT_Bill_no_Date" runat="server" Width="100px" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="70" TabIndex="96"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 950px">
                            <div id="tag_label_transaction_exp_jobb">
                               Cfs to Port
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 225px; font-size: 12px;">
                                <asp:TextBox ID="txt_TPT_Cfs_to_Port" runat="server" Width="225px" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="80" TabIndex="97"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                               Bill No & Dt.
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 155px; font-size: 12px;">
                                <asp:TextBox ID="txt_TPT_Bill_no_Date_2" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="80" TabIndex="98"></asp:TextBox>
                            </div>

                              <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 80px;">
                              A/C
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 100px; font-size: 12px;">
                                <asp:TextBox ID="txt_TPT_A_C" runat="server" Width="100px" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="70" TabIndex="99"></asp:TextBox>
                            </div>
                        </div>

                        <div id="tag_transac_exp_drawback" style="width: 950px">
                               <div id="tag_label_transaction_exp_jobb">
                            Remarks
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 735px; font-size:12px;">
                                <asp:TextBox ID="txt_TPT_Remarks" runat="server"  Width="735px" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="500" TabIndex="100"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    </div>
               
                    
          <%-- <div class="content" id="page-6">
                   <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">

                    </div>
               </div>--%>

          

             <%-- ---------------------------------END----------------------------------------------------------------%>
            </div>
          <%--  ---------------------------S------------------------------------------%>
            <div id="innerbox_MidMain_bot_transact_invoice" style="width:800px;">
               <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="120" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                                </div>
                
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate_Item();"
                        CssClass="save" TabIndex="115" /></div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" Visible="False" OnClick="btnUpdate_Click"
                        CssClass="updates" OnClientClick="return validate_Item();" TabIndex="115" /></div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="116" Visible="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'PRODUCT', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="116" OnClick="btnDelete_Click" OnClientClick="return validate_Item();"
                        CssClass="dlete" Style="display: none;" />
                </div>
                <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="parent.parent.adcodewindow.hide()"
                                        tabindex="121" id="btnCancel" />
                 </div>
                 
             </div>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
             <asp:HiddenField ID="HD_Showcon" runat="server" />

             <asp:HiddenField ID="HDEXP_Name" runat="server" />
             <asp:HiddenField ID="HDR_ID" runat="server" />

             <asp:HiddenField ID="hdBranch" runat="server" />

              <asp:HiddenField ID="hdn_CLIENT_TYPE" runat="server" />
              <asp:HiddenField ID="hd_Brslno" runat="server" />
              <asp:HiddenField ID="hdfTransport_mode1" runat="server" />


          <%--  ---------------------------E------------------------------------------%>
         
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9', 'page-10', 'page-11', 'page-12']);
            </script>
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


    <script src="../js/Grid_header_script/gridviewScroll.min.js" type="text/javascript"></script>



</body>
</html>
