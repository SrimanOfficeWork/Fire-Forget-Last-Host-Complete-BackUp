<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_GSP_certificateorigin.aspx.cs"
    Inherits="Export_Export_Drawback" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export - Certificate Origin</title>
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
    <script type="text/javascript">

        function Open_Annexure() {
            if (document.getElementById("hdn_Jobno").value != 'Select') {
                var jobno = document.getElementById("hdn_Jobno").value;
                var ReportType = "COO";
                if (document.getElementById("HdnFld_CheckJobNo").value == 2) {
                    adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../BL_Generation/Export_BL_Generation_Annexure.aspx?jobno=' + jobno + '&ReportType=' + ReportType + '', '', 'width=780px,height=590px,center=1,resize=0,scrolling=1')
                    //                adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../Export/Export_BL_Generation_Annexure.aspx?jobno=' + jobno + '', '', 'width=810px,height=520px,center=1,resize=0,scrolling=1')
                    return false;
                }
                else {
                    alert('Save a Certificate Of Origin, Then Add Annexure');
                }
            }
            else {

                alert('Select Valid JobNo');
            }
        }

</Script>

 <script language="jscript" type="text/javascript">

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
   
     </script>

      <script type="text/javascript">

          $(document).ready(function () {
              var aa = $('#txt_Marks_Nos').val().length;
              var bb = $('#txt_Description').val().length;

              $('#marks_count').text('Total Text count is ' + aa);
              $('#desc_count').text('Total Text count is ' + bb);

              $('#txt_Marks_Nos').keyup(function () {

                  var max = 7000;
                  var len = $(this).val().length;
                  if (len >= max) {
                      $('#marks_count').text('You Have Reached the Limit');
                  }
                  else {
                      var ch = max - len;
                      $('#marks_count').text(ch + ' Characters left');
                  }
              });

              $('#txt_Description').keyup(function () {

                  var max = 7000;
                  var len = $(this).val().length;
                  if (len >= max) {
                      $('#desc_count').text('You Have Reached the Limit');
                  }
                  else {
                      var ch = max - len;
                      $('#desc_count').text(ch + ' Characters left');
                  }
              });
          });

    </script>

     <script type="text/javascript">
         function open_anx() {

             if (document.getElementById('hdn_Jobno').value != '') {
                 var f = document.getElementById('hdn_Jobno').value;
                 var type = "Certificate of Origin";
//                                                                  alert(type);
                 NewWindow1('../Report/Export_BL_Generation_Annexure_Rpt.aspx?jobno=' + f + '&Type=' + type + '', 'List', '870', '1024', 'yes');
             }
         }   
    </script>

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
            <div id="innerbox_MidMain_Transact_popup_new">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Certificate Of Origin
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                    
                </div>
                <div id="tag_transaction_inner_new">
                    <div id="tag_Exchange_lft_in1_new1" style="margin-top: 10px;">
                        <div id="tag_label_transaction_Src_new">
                            Job No
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1" 
                                TabIndex="5" onselectedindexchanged="ddlJobNo_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:TextBox ID="txt_JobNo" runat="server" CssClass=" txtbox_trans_exp_drawback" Visible="false" Width="90px" ReadOnly="true" ></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                     
                        <div id="tag_label_transaction_Src_new" style="width:60px">
                            To order
                        </div>
                        <div id="txt_trans_exp_drawback">
                             <asp:TextBox ID="txtToOrder" runat="server" MaxLength="35" ClientIDMode="Static" Width="140px"
                                                TabIndex="11" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
             
                        </div>
                        <div id="tag_label_transaction_Src_new">
                            Print Model
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width:365px">

                        <asp:DropDownList ID="ddl_type" runat="server" CssClass="listtxt_transac_src1" TabIndex="5"
                         Width="355px"  AutoPostBack="True" 
                                onselectedindexchanged="ddl_type_SelectedIndexChanged">
                         <asp:ListItem Value="2">MCCI-MADRAS CHAMBER OF COMMERCE & INDUSTRY</asp:ListItem>
                         <asp:ListItem Value="1">ANDHRA CHAMBER OF COMMERCE</asp:ListItem>                       
                         <asp:ListItem Value="3">SOUTHERN INDIA CHAMBER OF COMMERCE & INDUSTRY</asp:ListItem>
                            </asp:DropDownList>
                    </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                        <div id="txtcon-m_transaction_code">
                         <asp:Button ID="btnSearch" CssClass="generate" runat="server"  OnClientClick="open_jobno(); return false"/>
             
                        </div>                                                             
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_IGM_Invoice" style="width:990px; height:460px;">

             <ol id="toc">
                   
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');" id="IMD">
                        <span>General </span></a></li>
                    
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2('0');" id="SD">
                        <span>Other Details</span></a></li>

                     <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3('0');" id="Anx">
                        <span> Annexure </span></a></li>
                    
                </ol>
                
                <div class="content" id="page-1" style="height:430px;width:960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:435px;">
                         <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            Exporter
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtExporter" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Notify
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                                            
                    </div>

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                        
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>                      
                    </div>


                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="12" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                           <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       
                       
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                     <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtNotify_Add3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                    </div>
<div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                       <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add4" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                    </div>
<div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtNotify_Add5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                    </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                            Consignee
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                          Pre Carriage by
                        </div>
                        <div id="txt_trans_exp_drawback">
                                                      <asp:TextBox ID="txtPre_Carriageby" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="50" TabIndex="13"></asp:TextBox>
                       
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Place of receipt by pre-carrier
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtPlace_Precarier" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="50" TabIndex="13"></asp:TextBox>
                        </div>
<%--                        <div id="innerbox_MidMain_bot_transact" style="line-height: 1px;width: 290px;line-height: 1px;margin-top: 0;float: right;">
                               MEAN OF TRANSPORT (ASEAN-INDIA)
                            </div>--%>
                       
                    </div>
<div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add1" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Vessel flight No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtVessel_Flight" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="50" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <%--<div id="tag_label_transaction_exp_jobb">
                            Port of loading
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                Onkeypress="return num1(event)" MaxLength="10" TabIndex="6"></asp:TextBox>
                        </div>--%>
                    </div>
<div  id="innerbox_MidMain_bot_transact" style="width:110%;height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add2" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Port of Discharge
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtPort_Of_Discharge" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="50" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        
                        <div id="tag_label_transaction_exp_jobb">
                           Port of loading
                        </div>
                        
                                    <div id="txt_trans_exp_drawback">
                                        <asp:TextBox ID="txtPort_Of_Loading" runat="server" CssClass="txtbox_trans_exp_drawback"
                                         MaxLength="50" TabIndex="22" ></asp:TextBox>
                                    </div>
                    </div>
<div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Importing country
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtImporting_Country" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="50" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Final Destination
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtFinal_Destination" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="50" TabIndex="6"></asp:TextBox>
                        </div>
                        
                    </div>
     <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:40px;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           Authorised signatory
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtAuthorised_Signatory" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="50" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                           Signature & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtSignature_Date" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="50" TabIndex="6"></asp:TextBox>
                        </div>
                    </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:40px;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <br />
                       
                        <div id="tag_label_transaction_exp_jobb">
                           Remarks
                          
                        </div>
                        <div id="tag_label_transaction_iten_new1_nos_othres" style="height:20px">
                            <asp:TextBox ID="txtRemarks" runat="server" CssClass=" txtbox_none_Mid_transac_item_gen_decs" MaxLength="200"
                                 TabIndex="6"></asp:TextBox>
                        </div>
                       
                       </div>
                       </div>
                      </div>
                     
                      <%-- ***********************TAB 3*********************************** --%>

                         <div class="content" id="page-2" style="height:437px;width:960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:435px;">

                        <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:bold;margin-top: 20px;height:30px">
                        <div id="tag_label_transaction_exp_jobb"  style="width:240px; font-weight:bold; text-align:center;"> Marks nos & Container No</div>
                        <div id="tag_label_transaction_exp_jobb" style="width:125px; font-weight:bold;" > No & kind of pkgs</div>
                        <div id="tag_label_transaction_exp_jobb" style="width:200px; font-weight:bold;" >&nbsp; &nbsp;&nbsp;&nbsp; Goods Desc</div>
                        <div id="tag_label_transaction_exp_jobb"  style="width:125px; font-weight:bold;"> Origin criterion</div>
                        <div id="tag_label_transaction_exp_jobb" style="width:120px; font-weight:bold;" > Gross Weight</div>
                        <%--<div id="tag_label_transaction_exp_jobb"  style="width:100px; font-weight:bold; visibility:hidden"> Measurement</div>--%>
                        <div id="tag_label_transaction_exp_jobb"  style="width:140px; font-weight:bold;"> Invoice No & Date</div>
                         
                         </div>
                        <div id="kkh" style="height:315px;border:0px;padding-left: 1px;width:950px" >
                        <div id="tag_label_transaction_exp_jobb" style="width: 230px;" >
                         
                            <asp:TextBox ID="txtMarksNos_Container" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="10" TabIndex="6" Width="225px" Height="280px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width: 145px;" >
                            
                             <asp:TextBox ID="txtNo_Kind_Pkgs" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="10" TabIndex="6" Width="140px" Height="280px" 
                                 TextMode="MultiLine"></asp:TextBox>
                        </div>
                          <div id="tag_label_transaction_exp_jobb" style="width: 200px;" >
                         
                             <asp:TextBox ID="txtGoods_Desc" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="10" TabIndex="6" Width="313px" Height="280px" 
                                  TextMode="MultiLine"></asp:TextBox>
                        </div>

                        <div id="tag_label_transaction_exp_jobb" style="width: 120px;" >
                            
                             <asp:TextBox ID="txtOrigin_Criterion" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="10" TabIndex="6" Width="80px" Height="280px"  Visible="false"
                                 TextMode="MultiLine"></asp:TextBox>
                                 
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width: 125px;" >
                        
                            <asp:TextBox ID="txtGross_weight" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="10" TabIndex="6" Width="120px" Height="280px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <%--<div id="tag_label_transaction_exp_jobb" style="width: 105px;" >
                         
                           <asp:TextBox ID="txtMeasurement" runat="server" CssClass=" txtbox_trans_exp_drawback" Visible="false"
                                 MaxLength="10" TabIndex="6" Width="100px" Height="220px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </div>--%>
                        <div id="tag_label_transaction_exp_jobb" style="width: 125px;" >
                         
                           <asp:TextBox ID="txtInvNo_Date" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="10" TabIndex="6" Width="125px" Height="280px" 
                                TextMode="MultiLine"></asp:TextBox>
                        </div>
                        
                       
                            </div>   
                                             
                    </div>
                    
                  </div>

                
                <%-- ***********************TAB 4*********************************** --%>

                     <div class="content" id="page-3" style="height:430px;width:960px;">
                     
                     <div id="innerbox_MidMain_bot_transact" style="height:450px; width:780px;">                   
                        <div id="tag_transac_exp_drawback">
                              <div id="tag_label_transaction_exp_jobb" style="width:300px; text-align:center;" >                         
                              Marks & Numbers
                              </div>
                        
                             <div id="tag_label_transaction_exp_jobb" style="width:400px; text-align:center;" >                         
                              Goods Description
                              </div>                        
                        </div> 

                  
                    <div id="tag_transac_exp_drawback_1" style="width:980px;">
                          <div id="txtcon-m_transaction_pop_gen1" style="height:360px; width:320px; text-align:center; overflow:inherit;">
                             <asp:TextBox ID="txt_Marks_Nos" runat="server"  Font-Names="Verdana" Font-Size="Small" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                                  TextMode="MultiLine" Height="350px" Width="320px"
                                MaxLength="35" TabIndex="25" ></asp:TextBox>    

                          </div>

                           <div id="txtcon-m_transaction_pop_gen1" style="height:370px; width:450px; text-align:center; overflow:inherit; ">
                             <asp:TextBox ID="txt_Description" runat="server"  TextMode="MultiLine" Height="350px" Width="450px" Font-Names="Verdana" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                              Font-Size="Small"  MaxLength="35" TabIndex="25" ></asp:TextBox>

                          </div>

                          
                            <div id="editbu" style="margin-top: 87px;">                               
                                <asp:Button ID="btnl_Annex" runat="server" Text="Generate" CssClass="generate"  
                                    OnClientClick="return open_anx();" onclick="btnl_Annex_Click" />
                            </div>
                      
                    </div>

                       <div id="tag_transac_exp_drawback">
                          <div id="tag_label_transaction_exp_jobb">
                            <div id="marks_count" style="width:300px; text-align:center; color:Red;" ></div>
                          </div>

                          
                            <div id="tag_label_transaction_exp_jobb"   ></div>
                             <div id="desc_count" style="width:700px; text-align:center; color:Red;"></div>
                       </div>                      
                    </div>
                   </div>

                   </div>
                  <!-- ********************** --!>


                  </div>
                    
 <!-- Buttons Place Here -->
                <div id="innerbox_MidMain_bot_transact_invoice" style="margin-top:20px" >
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"  OnClick="btnNew_Click"
                            OnClientClick="jQuery('#form1').validationEngine('hide');" TabIndex="35"  />
                    </div>
                    <div id="editbu">
                        <%--<asp:Button ID="btnSave" runat="server" CssClass="save"  OnClick="btnSave_Click" OnClientClick="return validate_Invoice();"
                            TabIndex="36" />--%>

                            <asp:Button ID="btnSave" runat="server" CssClass="save"  OnClick="btnSave_Click" 
                            TabIndex="36" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates"  OnClick="btnUpdate_Click"
                            OnClientClick="return validate_Invoice();" TabIndex="36" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server"  TabIndex="37" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Certificate Of Origin', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            RefreshParent();
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="37" CausesValidation="false" UseSubmitBehavior="false" OnClick="btnDelete_Click"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" 
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                       <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="win_hide();parent.adcodewindow.hide();return false;"
                        tabindex="38" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                        <%--<input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()"
                            tabindex="38" id="btnCancel" />--%></div>
                            <div id="editbu" style="width:200px"></div>
                            <div id="editbu" style="text-align:center">
                            <%--<asp:Button ID="BtnAddAnnex" runat="server" Text="Add Annexure" OnClientClick="return Open_Annexure();" OnClick="BtnAddAnnex_Click"  />--%>
                  <%-- <asp:Button ID="btn1" runat="server" Text="Add Annexure" />  </div>--%>
                </div>
                <!-- Buttons Place Here -->
                </div>
               
              
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                    <asp:HiddenField ID="HiddenField_Printtype" runat="server" />
                    <asp:HiddenField ID="HdnFld_CheckJobNo" runat="server" />
                     <asp:HiddenField ID="hdfTransport_mode1" runat="server" />
                    
                <%--</div>
            </div>--%>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
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

         function open_jobno() {

             if (document.getElementById("<%=hdn_Jobno.ClientID %>").value != 'Select') {

                 var aa = document.getElementById("hdn_Jobno").value;
                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("hdn_Jobno").value;
                 document.getElementById("<%=HiddenField_Printtype.ClientID %>").value = document.getElementById("<%=ddl_type.ClientID %>").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                     var type = document.getElementById("<%=HiddenField_Printtype.ClientID %>").value;

//                     alert(f);

                    
                     NewWindow1('../Report/Certificate_Of_Origin_Reportviewer.aspx?jobno=' + f + '&Type='+ type + '', 'List', '870', '1024', 'yes');

                     return false
                     //alert(f);
                 }
             }
         }
     </script>
</body>
</html>
