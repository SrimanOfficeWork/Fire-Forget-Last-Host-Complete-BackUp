<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_GSP_Front_Details.aspx.cs" Inherits="Export_Export_GSP_Front_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export - GSP</title>
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

     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>
    
   <script src="../js/Export_Rpt/BL_Generation.js" type="text/javascript"></script>
    <script src="../js/MaxLength.min.js" type="text/javascript"></script>

    <script type="text/javascript" language="Javascript" src="http://ajax.aspnetcdn.com/ajax/jquery/jquery-1.4.1.min.js"></script>
    
    <script src="../js/Export_Rpt/BL_Generation.js" type="text/javascript"></script>
    <style type="text/css">
    .txtbox_none_Mid_transac_item_other_rmarks_new1_LC{
color:#2b2b2b;
font-family:Arial,Helvetica,sans-serif;
font-size:14px;

margin-top:2px;
width:385px;
max-width:385px;
height:270px;
max-height:2705px;
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
    
    <%--validation for Origin Criteria--%>
  <%--  <script type="text/javascript">
        $(document).ready(function () {

            var maxlength = 1300;
            $('#txtMarks_Packages').keyup(function () {

                var text = $(this).val();
                var textlength = text.length;

                if (textlength > maxlength) {
                    $(this).val(text.substring(0, (maxlength)));
                    alert(maxlength + ' Characters Only Allowed in Marks & Nos');
                }
            });
        });
    
    </script>

    <script type="text/javascript">

        $(document).ready(function () {
            var text = $('#txtMarks_Packages').val();
            var textlength = text.length;
            var maxlength = 1300;


            if (textlength > 0) {
                if (textlength > maxlength) {
                    
                    var setvalue = text.substring(0, (maxlength));
                    $('#txtMarks_Packages').val(setvalue);
                    alert( maxlength + ' Characters Only Allowed in Marks & Nos');

                }
                else {                   
                }
            }
        });
    </script>--%>

    <%--Validation for Goods Description--%>

     <%--<script type="text/javascript">
         $(document).ready(function () {

             var maxlength = 1300;
             $('#txtNo_Kind_Of_Packages_Desc').keyup(function () {

                 var text = $(this).val();
                 var textlength = text.length;

                 if (textlength > maxlength) {
                     $(this).val(text.substring(0, (maxlength)));
                     alert(maxlength + ' Characters Only Allowed in Goods Description');
                 }

             });
         });
    
    </script>

    <script type="text/javascript">

        $(document).ready(function () {
            var text = $('#txtNo_Kind_Of_Packages_Desc').val();
            var textlength = text.length;
            var maxlength = 1300;


            if (textlength > 0) {
                if (textlength > maxlength) {
                    
                    var setvalue = text.substring(0, (maxlength));
                    $('#txtNo_Kind_Of_Packages_Desc').val(setvalue);

                    alert(maxlength + ' Characters Only Allowed in Goods Description');
                }
                else {
                }
            }
        });
    </script>--%>

      <script type="text/javascript">
          function checking() {
              if (document.getElementById("CheckBox1_Settings").checked == true) {

                  document.getElementById("txt_Marks_Val").style.display = 'block';
                  document.getElementById("txt_Desc_Val").style.display = 'block';
                  document.getElementById("lbl_marks").style.display = 'block';
                  document.getElementById("lblDescription").style.display = 'block';   

              }
              else {
                  document.getElementById("txt_Marks_Val").style.display = 'none';
                  document.getElementById("txt_Desc_Val").style.display = 'none';
                  document.getElementById("lbl_marks").style.display = 'none';
                  document.getElementById("lblDescription").style.display = 'none';   

              }
          }     
    </script>

    <script type="text/jscript">

        $(document).ready(function () {
            document.getElementById("txt_Marks_Val").style.display = 'none';
            document.getElementById("txt_Desc_Val").style.display = 'none';
            document.getElementById("lbl_marks").style.display = 'none';
            document.getElementById("lblDescription").style.display = 'none';  
        });
    
    </script>

    <script type="text/javascript">
        function pin(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 27 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }

        function Num_Dot_Spl(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 32 && (charCode < 65 || charCode > 91) && (charCode < 97 || charCode > 122) && (charCode < 48 || charCode > 57) && (charCode < 40 || charCode > 41) && (charCode < 93 || charCode > 93) && (charCode < 46 || charCode > 46))
                return false;
            return true;
        }

        function check_char(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if ((charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122))
                return false;
            return true;
        }

         </script>



    <script type="text/javascript">

        function validate_Invoice_GSP() {

//            if (document.getElementById("txtCountry").value <= 0) {
//                jAlert('Country cannot be blank', 'GSP', function (r) {
//                    document.getElementById("INVOICE_ID").click();
//                    document.getElementById("txtCountry").focus();
//                });
//                return false;
//            }

//            var Invoicevalue = document.getElementById("txtTransport_Route").value;
//            if (Invoicevalue.length <= 0) {
//                jAlert('Means of transport cannot be blank', 'GSP', function (r) {
//                    document.getElementById("INVOICE_ID").click();
//                    document.getElementById("txtTransport_Route").focus();
//                });

//                return false;
//            }
        }
    </script>

     <script type="text/javascript">

         $(document).ready(function () {
             $('#txtExporter').keyup(function () {
                 document.getElementById("hdn_CLIENT_TYPE").value = '';
                 var aa = 'Exporter';
                 document.getElementById("hdn_CLIENT_TYPE").value = aa;
                 //                alert(aa);
             });

             $('#txtConsignee').keyup(function () {
                 document.getElementById("hdn_CLIENT_TYPE").value = '';
                 var aa = 'Consignee';
                 document.getElementById("hdn_CLIENT_TYPE").value = aa;
                 //                alert(aa);
             });

             $('#txtNotify').keyup(function () {
                 document.getElementById("hdn_CLIENT_TYPE").value = '';
                 var aa = 'Notify';
                 document.getElementById("hdn_CLIENT_TYPE").value = aa;
                 //                alert(aa);
             });

         });
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
            <div id="innerbox_MidMain_Transact_popup_new">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Export - GSP
                    </div>
                    <div id="popupwindow_closebut_right_new">
                       <%-- <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.inboxwindow.hide();return false;" />--%>
<%--
                         <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.inboxwindow.hide();RefreshParent_1();return false;" 
                          />--%>
                          <asp:Button ID="btnClose" runat="server"  CssClass="clsicon_new" OnClientClick="RefreshParent();return false;"
                                CausesValidation="false"    UseSubmitBehavior="false" />
                    </div>
                    
                </div>
                <div id="tag_transaction_inner_new" >
                    <div id="tag_Exchange_lft_in1_new1" >
                      <div id="tag_label_transaction_Src_new">
                       Exporter
                      </div>
                      <div id="txtcon-m_transaction_code" style="width: 255px;">
                        <asp:DropDownList ID="ddl_ExporterName" runat="server" 
                                CssClass="listtxt_transac_src1"  Width="250px"  TabIndex="5"  AutoPostBack="True"
                                onselectedindexchanged="ddl_ExporterName_SelectedIndexChanged">
                            </asp:DropDownList>

                            <asp:TextBox ID="txt_ExporterName" runat="server" MaxLength="35"  Width="250px" ReadOnly="true" Visible="false"
                                                 CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                      </div>

                        <div id="tag_label_transaction_Src_new">
                            File Ref No
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1" 
                                 AutoPostBack="True" 
                                onselectedindexchanged="ddlJobNo_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:TextBox ID="txt_File_RefNo" runat="server" CssClass=" txtbox_trans_exp_drawback" Visible="false"  Width="90px" ReadOnly="true" ></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                       

                        <div id="tag_label_transaction_popup_trans_cth_label2">
                        Job No
                        </div>

                        <div id="txtcon-m_transaction_code">
                           <asp:TextBox ID="txt_JobNo" runat="server" CssClass=" txtbox_trans_exp_drawback"  Width="90px" ReadOnly="true" ></asp:TextBox>
                        </div>

                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>

                        <%--<div id="tag_label_transaction_Src_new">
                            Print Type
                        </div>--%>

                        <div id="tag_label_transaction_popup_IGM2_empty_gen"></div>

                        <div id="tag_label_transaction_Src_new">
                            Print Type
                        </div>

                        <div id="tag_label_transaction_popup_IGM2_empty" style="width:365px">

                        <asp:DropDownList ID="ddl_type" runat="server" CssClass="listtxt_transac_src1" 
                         Width="355px"  AutoPostBack="True" 
                                onselectedindexchanged="ddl_type_SelectedIndexChanged">
                         
                         <asp:ListItem Value="1">ASEAN-INDIA FREE TRADE AREA PREFERENTIAL TARIFF</asp:ListItem>
                         <asp:ListItem Value="2">INDIA AND JAPAN AGREEMENT</asp:ListItem>
                         <asp:ListItem Value="3">GENERALIZED SYSTEM OF PREFERENCES (GSP)</asp:ListItem>
                         <asp:ListItem Value="4">SAPTA</asp:ListItem>
                         <asp:ListItem Value="5">GLOBAL SYSTEM OF TRADE PREFERENCES</asp:ListItem>
                         <asp:ListItem Value="6">INDIA-MALAYSIA COMPREHENSIVE ECONOMIC COOPERATION AGREEMENT</asp:ListItem>
                         <asp:ListItem Value="7">ASIA-PACIFIC TRADE AGREEMENT</asp:ListItem>
                         <asp:ListItem Value="8">INDIA-SRI LANKA FREE TRADE AGREEMENT</asp:ListItem>
                         <asp:ListItem Value="9">RAIGAD CHAMBER OF COMMERCE AND INDUSTRY</asp:ListItem>
                          
                        <%-- <asp:ListItem Value="4">GENERAL AGREEMENT</asp:ListItem>--%>
                         <%--<asp:ListItem Value="4">ADVANCE CARGO DECLARATION</asp:ListItem>--%>
                            </asp:DropDownList>
                    </div>

                       <%-- <div id="txtcon-m_transaction_code">

                       <asp:Button ID="Rpt_Set" runat="server" Text="Report Settings" Visible="false" />
                        <asp:Button ID="btnSearch" CssClass="generate" runat="server" Visible="false"  OnClientClick="open_jobno(); return false"/>
            
                        </div>--%>
                                           
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    
                        <%--<div id="tag_label_transaction_popup_no_empty_new">
                        </div>--%>                    
                      
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new" style="height:420px;">
                <ol id="toc_new">

                 <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();return false;"
                        id="General"><span>Front Page</span></a></li>

                        <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();return false;"
                        id="A2"><span>Details</span></a></li>

                        <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3();return false;"
                        id="A1"><span>Back Page</span></a></li>

                   <%-- <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');btn_move_prev();return false;"
                        id="General"><span>Front Page</span></a></li>

                        <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');btn_move_details();return false;"
                        id="A2"><span>Details</span></a></li>

                        <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');btn_move_next();return false;"
                        id="A1"><span>Back Page</span></a></li>--%>
                 
                                  </ol>

                <div class="content" id="page-1" style="height:420px;width:960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export"  style="height:300px";>
                         <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            Goods Consigned From
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1" style="width:196px;">
                         <asp:TextBox ID="txtExporter" runat="server" MaxLength="35" ClientIDMode="Static" Width="195px"
                                                TabIndex="1" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                           <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Exporter'); return false">
                                            </a>
                        </div>
                        <div id="magnify_area" style="width:40px;">
                           <asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server"  
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_client_Masternew('Exporter'); return false" />

                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Means of transport and route
                        </div>
                       <%-- <div id="txt_trans_exp_drawback_multitxt">
                                <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200" onkeyDown="return checkTextAreaMaxLength(this,event,'200');"
                                    onpaste="return checkTextAreaMaxLength(this,event,'200');" CssClass="txtbox_none_Maxtxt_Supplier"
                                    TextMode="MultiLine" TabIndex="9"></asp:TextBox>
                            </div>--%>
                        <div id="txt_trans_exp_drawback_multitxt" >
                        <asp:TextBox ID="txtTransport_Route" runat="server" TextMode="MultiLine" CssClass="txtbox_trans_exp_drawback_multiline" style="height:110px;width: 460px;"
                                MaxLength="300" ClientIDMode="Static"  
                                 TabIndex="13"></asp:TextBox>

                            <%--<asp:TextBox ID="txtTransport_Route" runat="server" TextMode="MultiLine" CssClass="validate[required] txtbox_trans_exp_drawback_multiline" style="height:110px;width: 480px;"
                                MaxLength="300" ClientIDMode="Static" onkeyDown="return checkTextAreaMaxLength(this,event,'300');"
                                onpaste="return checkTextAreaMaxLength(this,event,'300');" TabIndex="13"></asp:TextBox>--%>
                        </div>
                      
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="2" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_exp_jobb">                           
                        </div>
                                                  
                       
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress2" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="3"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="magnify_area">
                        </div>
                      
                    </div>
<div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="4"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="magnify_area">
                        </div>
                       
                    </div>
<div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="5"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <br />
                        </div>
                        
                        
                    </div>

                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        
                    </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                           Goods Consigned To
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1"  style="width:196px;">
                            <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static"  Width="195px"
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="magnify_area">

                           <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupReportClient_Master('Consignee'); return false">
                                            </a>
                        </div>
                        <div id="magnify_area" style="width:40px;">
                           <asp:Button ID="Button1" CssClass="autowidnewbut" Text="New" runat="server"  
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Report_client_Masternew('Consignee'); return false" />

                        </div>
                        
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <%--<div id="txt_trans_exp_drawback">
                           
                        </div>--%>
                        <div id="magnify_area">
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="line-height: 1px;width: 290px;line-height: 1px;margin-top: 0;float: right;">
                               MEAN OF TRANSPORT (ASEAN-INDIA)
                            </div>
                       
                    </div>
   <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0; width:110%">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add1" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Country
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtCountry" runat="server" CssClass="txtbox_trans_exp_drawback"
                                  TabIndex="14"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Departure Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtDepature_Date" runat="server" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="18"></asp:TextBox>

                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDepature_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDepature_Date"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>

                        </div>
                    </div>
<div  id="innerbox_MidMain_bot_transact" style="width:110%;height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add2" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="9"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Importing Country
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtImporting_Country" runat="server" CssClass="txtbox_trans_exp_drawback"
                                 TabIndex="15"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>

                        <div id="tag_label_transaction_exp_jobb">
                           Port of Discharge
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtPort_Of_Discharge" runat="server" CssClass="txtbox_trans_exp_drawback"
                                 TabIndex="20"></asp:TextBox>
                        </div>

                        <%--<div id="tag_label_transaction_exp_jobb">
                           Vessel's name /Aircraft etc..
                        </div>
                        
                                  <div id="txtcon-m_46px" style="text-align:left;">

                                     <asp:TextBox ID="txtVesselName_Aircraft" runat="server" CssClass="txtbox_none_Mid_transac_Marks_nos"
                                            TextMode="MultiLine"  Width="179px" 
                                             MaxLength="300" TabIndex="19" ></asp:TextBox>


                                    </div>--%>
                    </div>
     <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0; width:110%;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="10"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Place & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtPlace_Date" runat="server" CssClass="txtbox_trans_exp_drawback"
                                 TabIndex="16"></asp:TextBox>
                        </div>
                         <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           Entered by
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtEntered_By" runat="server" CssClass="txtbox_trans_exp_drawback"
                                 TabIndex="17"></asp:TextBox>
                        </div>
                    </div>
               <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:30px;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="11"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <%--<div id="tag_label_transaction_exp_jobb">
                           Entered by
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtEntered_By" runat="server" CssClass="txtbox_trans_exp_drawback"
                                 TabIndex="17"></asp:TextBox>
                        </div>--%>
                        <div id="magnify_area">
                        </div>

                        <div id="tag_label_transaction_exp_jobb">
                           Vessel's name /Aircraft etc..
                        </div>
                        
                                  <div id="txtcon-m_46px" style="text-align:left;">

                                     <asp:TextBox ID="txtVesselName_Aircraft" runat="server" CssClass="txtbox_none_Mid_transac_Marks_nos"
                                            TextMode="MultiLine"  Width="179px" 
                                             MaxLength="300" TabIndex="19" ></asp:TextBox>


                                    </div>

                         <%--<div id="tag_label_transaction_exp_jobb">
                           Port of Discharge
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtPort_Of_Discharge" runat="server" CssClass="txtbox_trans_exp_drawback"
                                 TabIndex="20"></asp:TextBox>
                        </div>--%>
                    </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:35px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="12"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>   
                        <%--<div id="tag_label_transaction_exp_jobb" style="height:25px;font-weight:bold;margin-top: 0;width:120px;">
                         Settings

                          <input type="checkbox" id="CheckBox1_Settings" runat="server" onclick="return checking();"/>  
                        </div>   
                      
                          
                        <div id="txtcon-m_transaction_pop_gen1"  style="width:150px">
                           <div id="tag_label_transaction_exp_jobb" style="width:70px">
                          <asp:Label ID="lbl_marks" runat="server" Text=" Marks&Nos"></asp:Label>
                           </div>
                           <asp:TextBox ID="txt_Marks_Val" runat="server" ClientIDMode="Static"  Width="50px" Text="13" onkeypress="return blockNonNumbers(this, event, true, false);"
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="12"></asp:TextBox>
                         </div>

                         <div id="magnify_area" style="width:25px"></div>
                         
                            <div id="tag_label_transaction_exp_jobb" style="width:100px">
                            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                            
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1  style="width:60px; text-align:left";>
                            <asp:TextBox ID="txt_Desc_Val" runat="server" ClientIDMode="Static"  Width="50px" Text="25" onkeypress="return blockNonNumbers(this, event, true, false);"
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="12"></asp:TextBox>
                            </div>--%>
                         
                                
                            </div>

                        <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:30px;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            
                        </div>
                        <div id="magnify_area">
                        </div>
                         <div id="magnify_area">
                        </div>

                        <div id="tag_label_transaction_exp_jobb" style="height:25px;font-weight:bold;margin-top: 0;width:120px;">
                         Settings

                          <input type="checkbox" id="CheckBox1_Settings" runat="server" onclick="return checking();"/>  
                        </div>   
                      
                          
                        <div id="txtcon-m_transaction_pop_gen1"  style="width:150px">
                           <div id="tag_label_transaction_exp_jobb" style="width:70px">
                          <asp:Label ID="lbl_marks" runat="server" Text=" Marks&Nos"></asp:Label>
                           </div>
                           <asp:TextBox ID="txt_Marks_Val" runat="server" ClientIDMode="Static"  Width="50px" Text="13" onkeypress="return blockNonNumbers(this, event, true, false);"
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="12"></asp:TextBox>
                         </div>

                         <div id="magnify_area" style="width:25px"></div>
                         
                            <div id="tag_label_transaction_exp_jobb" style="width:100px">
                            <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
                            
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1  style="width:60px; text-align:left";>
                            <asp:TextBox ID="txt_Desc_Val" runat="server" ClientIDMode="Static"  Width="50px" Text="25" onkeypress="return blockNonNumbers(this, event, true, false);"
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="12"></asp:TextBox>
                            </div>

                        </div>

                        </div>      
                        </div>
                  <%--  </div>
--%>

                   <%-- *********************** TAB 2 ************************* --%>

<div class="content" id="page-2" style="height:420px;width:960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export"  style="height:400px";>
                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:30px;">
                    </div>
                      
                      <div id="kkh" style="height:350px;border:0px;padding-left: 5px;" >
                        <div id="tag_label_transaction_exp_jobb" style="width: 50px; height:18px; font-weight:bold;" claSS="grid-view">
                            Item no
                              <asp:TextBox ID="txtItemNo" runat="server" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                                 MaxLength="10" TabIndex="21" Width="45px" Height="265px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width: 180px; text-align:center;height:18px; font-weight:bold;" class="grid-view">
                           Marks & No of pkgs
                            <asp:TextBox ID="txtMarks_Packages" runat="server" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                                 TabIndex="22" Width="172px" Height="265px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width: 275px; text-align:center;height:18px; font-weight:bold;" class="grid-view">
                            No & kind of pkgs, Good Desc
                             <asp:TextBox ID="txtNo_Kind_Of_Packages_Desc" runat="server" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                                 TabIndex="23" Width="270px" Height="265px" TextMode="MultiLine" ></asp:TextBox>
                        </div>

                        
                        <div id="tag_label_transaction_exp_jobb" style="width: 105px;height:18px; font-weight:bold;" class="grid-view">
                        <div id="counter"></div>
                            Origin criterion
                             <asp:TextBox ID="txtOrigin_Criteria" runat="server" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                                  TabIndex="24" Width="100" Height="265px" TextMode="MultiLine"></asp:TextBox>
                        </div>

                       
                        <div id="tag_label_transaction_exp_jobb" style="width: 150px;height:18px; font-weight:bold;" class="grid-view">
                           Gross weight
                            <asp:TextBox ID="txtGross_Weight" runat="server" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                                  TabIndex="25" Width="145px" Height="265px" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width: 150px;height:18px; font-weight:bold;" class="grid-view">
                          Invoice No & Date
                           <asp:TextBox ID="txtInvoiceNo_Date" runat="server" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                                  TabIndex="26" Width="150px" Height="265px" TextMode="MultiLine"></asp:TextBox>
                        </div>                         
                           </div>                     
                    </div>
                    </div>


                    <%--====================TAB 3========================--%>

                    <div class="content" id="page-3" style="height:420px;width:960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export"  style="height:160px" >
                    <div id="tag_transac_lft_trans_export_in1_Inv" style="width:950px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Declares line 1
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtDeclare_Line1" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="27" ClientIDMode="Static"></asp:TextBox>
                            </div>
                          <div id="magnify_area">
                        </div>
                           <div id="tag_label_transaction_popup_IGM_invoice">
                                
                            </div>
                            <div id="innerbox_MidMain_bot_transact" style="line-height: 1px;width: 401px;line-height: 1px;margin-top: 0;float: right;">
                               REQUESTS the issue of a certificate of origin for these Goods
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width:950px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                2
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtDeclare_Line2" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="28" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                        </div>
                          <div id="tag_label_transaction_popup_IGM_invoice">
                                1
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtRequest1" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="37" ClientIDMode="Static"></asp:TextBox>
                            </div>                         
                        </div>
                       
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width:950px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                3
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtDeclare_Line3" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="29" ClientIDMode="Static"></asp:TextBox>
                            </div>
                          <div id="magnify_area">
                        </div>
                          <div id="tag_label_transaction_popup_IGM_invoice">
                                2
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtRequest2" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="38" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width:950px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                               
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                             
                            </div>
                            <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_popup_IGM_invoice">
                                3
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_larg">
                                <asp:TextBox ID="txtRequest3" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="39" ClientIDMode="Static"></asp:TextBox>
                            </div>
                          
                        </div>
  <div id="tag_transac_lft_trans_export_in1_Inv" style="width:950px;">
  <div id="tag_label_transaction_popup_IGM_invoice" >
                                Specifies Line 1
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtSpecifies_Line1" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="30" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                        </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" >
                               4
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtRequest4" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="40" ClientIDMode="Static"></asp:TextBox>
                            </div>
                          </div>
                          
                      
                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width:950px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                               
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtSpecifies_Line2" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="31" ClientIDMode="Static"></asp:TextBox>
                            </div>

                            <div id="magnify_area">
                            </div>

                             <div id="tag_label_transaction_popup_IGM_invoice" >
                               5
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtRequest5" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="40" ClientIDMode="Static"></asp:TextBox>
                            </div>                                                  
                        </div>

                        <div id="tag_transac_lft_trans_export_in1_Inv" style="width:950px;">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                               
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtSpecifies_Line3" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="32" ClientIDMode="Static"></asp:TextBox>
                            </div>
                          
                          <div id="magnify_area">
                            </div>

                             <div id="tag_label_transaction_popup_IGM_invoice" >
                               6
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtRequest6" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="40" ClientIDMode="Static"></asp:TextBox>
                            </div>
                          
                        </div>


                         <div id="tag_transac_lft_trans_export_in1_Inv">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtSpecifies_Line4" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="33" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>

                          <div id="tag_transac_lft_trans_export_in1_Inv">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtSpecifies_Line5" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="33" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>

                        <div id="tag_transac_lft_trans_export_in1_Inv">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                               
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                              
                            </div>
                          
                          
                        </div>
            <div id="tag_transac_lft_trans_export_in1_Inv">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                Submit line 1
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtSubmit_Line1" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="33" ClientIDMode="Static"></asp:TextBox>
                            </div>
                          
                          
                        </div>
                        <div id="tag_transac_lft_trans_export_in1_Inv">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                               2
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtSubmit_Line2" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="34" ClientIDMode="Static"></asp:TextBox>
                            </div>
                          
                          
                        </div>
                        <div id="tag_transac_lft_trans_export_in1_Inv">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                               3
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtSubmit_Line3" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="35" ClientIDMode="Static"></asp:TextBox>
                            </div>
                          
                          
                        </div>

                        <div id="tag_transac_lft_trans_export_in1_Inv">
                            <div id="tag_label_transaction_popup_IGM_invoice">
                                4
                            </div>
                            <div id="txtcon-m_transaction_pop_expo_invoice_large">
                                <asp:TextBox ID="txtSubmit_Line4" runat="server" CssClass="txtbox_none_Mid_transac_pop_exp_invoice"
                                    MaxLength="300" TabIndex="36" ClientIDMode="Static"></asp:TextBox>
                            </div>                          
                        </div>                      

                    </div>
                    </div>
                </div>
                                 <!--****************** Buttons Place Here *************************-->

                <div id="innerbox_MidMain_bot_transact_invoice" style="margin-top: 21px;">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hide');" TabIndex="42"  OnClick="btnNew_Click"/>
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save"  OnClientClick="return validate_Invoice_GSP();"
                            TabIndex="41" OnClick="btnSave_Click"/>
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" 
                            OnClientClick="return validate_Invoice_GSP();" TabIndex="43" OnClick="btnUpdate_Click"/>
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="44" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'GSP', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            RefreshParent();
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="45" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" 
                            CssClass="dlete" Style="display: none;" OnClick="btnDelete_Click"/>
                    </div>
                    <div id="editbu">
                       <%--<asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="win_hide();parent.inboxwindow.hide();return false;"
                        tabindex="46" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />--%>
                        <%--<input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()"
                            tabindex="38" id="btnCancel" />--%></div>
                    <div id="editbu">
                        <%--<asp:Button ID="btn_next" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            CssClass="autowidmovebut" Text=">>" OnClientClick="jQuery('#form1').validationEngine('hide');btn_move_next();return false;" />--%>
                      <%--<asp:Button ID="btnSearch" CssClass="generate" runat="server"  OnClientClick="open_jobno(); return false"/>--%>
                      <asp:Button ID="btn_next" CssClass="generate" runat="server" Text="First"  OnClientClick="open_jobno(); return false"/>

                    </div>
                    <div id="editbu">
                        <%--<asp:Button ID="btn_prev" runat="server" CausesValidation="false" UseSubmitBehavior="false" style="display:none;"
                            CssClass="autowidmovebut" Text="<<" OnClientClick="jQuery('#form1').validationEngine('hide');btn_move_prev();return false;" />--%>

                            <asp:Button ID="btn_prev" CssClass="generate" runat="server"  Text="Second"  OnClientClick="Open_SecondPage(); return false"/>
                    </div>
                </div>
                <!-- Buttons Place Here -->

                </div>
                <div class="content" id="page-2" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_export_invoice_Iframe">
                    </iframe>
                </div>
                <div class="content" id="page-3" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_export_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-4" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_igm_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-5" style="display:none;">
                  
                </div>
                <div class="content" id="page-6" style="display:none;">
                   
                </div>
                <div class="content" id="page-7" style="display:none;">
                   
                </div>
                <div class="content" id="page-8" style="display:none;">
                    
                </div>
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                     <asp:HiddenField ID="HiddenField_Printtype" runat="server" />
                     <asp:HiddenField ID="hdfTransport_mode1" runat="server" />
                       <asp:HiddenField ID="HdnFld_CheckJobNo" runat="server" />
                       <asp:HiddenField ID="hdn_fileRef_Jobno" runat="server" />
                       <asp:HiddenField ID="hdn_CLIENT_TYPE" runat="server" />
                </div>
            </div>
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


        function tab_page1() {

            document.getElementById("page-1").style.display = 'Block';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("btn_next").style.display = 'block';
            document.getElementById("btn_prev").style.display = 'none';
        }
        function tab_page2() {

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'Block';
            document.getElementById("page-3").style.display = 'none';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("btn_next").style.display = 'block';
            document.getElementById("btn_prev").style.display = 'none';
        }
        function tab_page3() {

            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'none';
            document.getElementById("page-3").style.display = 'Block';
            document.getElementById("page-4").style.display = 'none';
            document.getElementById("btn_next").style.display = 'none';
            document.getElementById("btn_prev").style.display = 'block';
        }


//        function btn_move_next() {

//            document.getElementById("page-1").style.display = 'block';
////            document.getElementById("pop_text_area_transac_popup_inn_container_export").style.display = 'none';
//            document.getElementById("btn_next").style.display = 'none';
//            document.getElementById("btn_prev").style.display = 'none';

//        }
//        function btn_move_prev() {

//            document.getElementById("page-2").style.display = 'block';
////            document.getElementById("pop_text_area_transac_popup_inn_container_export").style.display = 'none';
//            document.getElementById("btn_next").style.display = 'none';
//            document.getElementById("btn_prev").style.display = 'none';

//        }
//        function btn_move_details() {

//            document.getElementById("tab2").style.display = 'block';
////            document.getElementById("pop_text_area_transac_popup_inn_container_export").style.display = 'block';
//            document.getElementById("btn_next").style.display = 'none';
//            document.getElementById("btn_prev").style.display = 'none';

//        }
    </script>


     <script type="text/javascript">

         function open_jobno() {

             if (document.getElementById("<%=hdn_Jobno.ClientID %>").value != '') {

                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=hdn_Jobno.ClientID %>").value;
                 document.getElementById("<%=HiddenField_Printtype.ClientID %>").value = document.getElementById("<%=ddl_type.ClientID %>").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                     var type = document.getElementById("<%=HiddenField_Printtype.ClientID %>").value;
                     //                     alert(type);
                     NewWindow1('../Report/Export_GSP_Front_Rpt_viewer.aspx?jobno=' + f + '&Type=' + type + '', 'List', '870', '1024', 'yes');
                     return false
                     //alert(f);
                 }
             }
         }


         function Open_SecondPage() {
             if (document.getElementById("<%=hdn_Jobno.ClientID %>").value != '') {

                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=hdn_Jobno.ClientID %>").value;
                 document.getElementById("<%=HiddenField_Printtype.ClientID %>").value = document.getElementById("<%=ddl_type.ClientID %>").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                     var type = 'SecondPage';
                     var Pg_Type = document.getElementById("<%=HiddenField_Printtype.ClientID %>").value

                     //                     alert(Pg_Type);

                     NewWindow1('../Report/Export_GSP_Front_Rpt_viewer.aspx?jobno=' + f + '&Type=' + type + '&Page_Name=' + Pg_Type + '', 'List', '870', '1024', 'yes');

                     //                     NewWindow1('../Report/Export_GSP_Front_Rpt_viewer.aspx?jobno=' + f + '&Type=' + type + '', 'List', '870', '1024', 'yes');
                     return false
                 }
             }
         }
     </script>

</body>
</html>
