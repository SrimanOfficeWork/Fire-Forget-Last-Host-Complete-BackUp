<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Despatch.aspx.cs" 
    Inherits="Export_Despatch"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export_Despatch</title>
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

   
<script type="text/javascript">
    function openContainernew() {
        adcodewindow = dhtmlmodal.open('ADcode', 'iframe', '../eRoyalMasters/Adcode_Master.aspx', '', NewWindow('457', '393'))
    }
</script>

  <style type="text/css">
    .txtbox_none_Mid_transac_item_other_rmarks_new1_LC{
color:#2b2b2b;
font-family:Arial,Helvetica,sans-serif;
font-size:14px;

margin-top:2px;
width:960px;
max-width:960px;
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
                            TabIndex="2" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                    </div>

                    <div id="mainmastop2container_rght_tag2_txt1"   style="width:50px; margin-top:-1px;"">
                    
                      <asp:Button ID="btngenerate" CssClass="generate" runat="server" OnClick="btngenerate_Click"/>
                   
                    </div>

                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                    
                </div>
                <div id="Div_listbox" runat="server">
                    <div id="tag_transact_src_inner" style="width: 960px;">
                        <div id="innerbox_MidMain_Trans_new" style="width: 980px; height: 25px; margin-left: -10px;
                            border-bottom-style: solid;">
                            <div id="tag_label_transaction_exp_jobb">
                                <asp:CheckBox ID="cbAll" runat="server" ForeColor="White" Font-Bold="true" Font-Size="14px"
                                    Text="Select All" onclick="CheckAll();" />
                            </div>
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width: 970px; overflow: auto; height: 72px;">
                            <asp:CheckBoxList ID="cbList" runat="server" ValidationGroup="VGroup" onclick="UnCheckAll();"
                                CssClass=" txtbox_none_Mid_transac_pop_gen" Width="951px" Height="22px" RepeatColumns="8"
                                RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
         </div>

                    <asp:HiddenField ID="HiddenField2" runat="server" />
                      <asp:HiddenField ID="hdn_isvalue" runat="server" />                

           <%-- -------------------------------------Tab--------------------------------------------------------%>

           
           <div id="innerbox_MidMain_Trans_new" style="width:990px; height:410px;" >
                <ol id="toc_new">
                   
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');" id="IMD">
                        <span>General </span></a></li>                
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:425px;width: 1000px;">
                    <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height:130px; width:360px;">
                        <div id="pop_text_area_Clientname">
                            <div id="tag_label_transaction_exp_jobb">
                                TO Address
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_TO" runat="server" MaxLength="150" ClientIDMode="Static"
                                    TabIndex="3" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname">
                            <div id="tag_label_transaction_exp_jobb">
                                
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_TO1" runat="server" MaxLength="150" ClientIDMode="Static"
                                    TabIndex="3" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                         <div id="pop_text_area_Clientname">
                            <div id="tag_label_transaction_exp_jobb">
                                Exporter Name
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_ExporterName" runat="server" MaxLength="150" ClientIDMode="Static"
                                    TabIndex="3" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                         <%-- <div id="pop_text_area_Clientname">
                            <div id="tag_label_transaction_exp_jobb">
                                
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_TO2" runat="server" MaxLength="150" ClientIDMode="Static"
                                    TabIndex="3" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>--%>
                        
                          <div id="pop_text_area_Clientname">
                            <div id="tag_label_transaction_exp_jobb">
                                Courier WayBillNo
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_WaybillNo" runat="server" MaxLength="150" ClientIDMode="Static"
                                    TabIndex="3" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                          <div id="pop_text_area_Clientname">
                            <div id="tag_label_transaction_exp_jobb">
                                Courier Name
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_CourierName" runat="server" MaxLength="150" ClientIDMode="Static"
                                    TabIndex="3" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                         
                    </div>


                    <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height:130px; width:560px;">

                     <div id="tag_transac_exp_drawback" style="width: 590px">
                            <div id="tag_label_transaction_exp_jobb">
                              Port of Discharge
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 460px">
                                <asp:TextBox ID="txt_PortDischarge" runat="server" 
                                    CssClass="txtbox_none_Mid_transac_item_gen_decs_EXP" TextMode="MultiLine"
                                   MaxLength="300"  Width="440px" TabIndex="39"></asp:TextBox>
                            </div>
                          </div>

                          <div id="tag_transac_exp_drawback"></div>

                           <div id="tag_transac_exp_drawback" style="width: 590px">
                            <div id="tag_label_transaction_exp_jobb" >
                                Packages
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1" style="width: 40px">
                                  <asp:TextBox ID="txt_Packages" runat="server" CssClass=" txtbox_none_Mid_transac_item_gen_decs_EXP" Width="440px" TextMode="MultiLine"
                                MaxLength="35" TabIndex="40"></asp:TextBox>
                            </div>
                        </div>
                   
                    </div>

                     <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height:310px; width:960px;">

                      <div id="txtcon-m_transaction_pop_gen1" style="height:280px; width:960px; text-align:center; overflow:inherit; ">
                             <asp:TextBox ID="txt_Description" runat="server"  TextMode="MultiLine" Height="230px" Width="960px" Font-Names="Verdana" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1_LC"
                              Font-Size="Small"   TabIndex="61" ></asp:TextBox>

                          </div>
                     </div>

                    </div>
                </div>

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

                 <%--  <div id="editbu" style="margin-left:30px; margin-top:8px;">
                      <asp:Button ID="btnrpt" runat="server"  Text="Report" OnClientClick="Export_Multiple_BL_rpt('New'); return false" Visible="false" />
                  </div>--%>

                  <div id="editbu" style="margin-left:30px; margin-top:8px;">
                      <asp:Button ID="btnrpt" runat="server"  Text="Report" OnClientClick="open_jobno_Rpt(); return false"  />
                        <asp:Button ID="btnpdf" runat="server"  Visible="false" Text="Add Annexure PDF" OnClientClick="Pdf(); return false;" />
                  </div>

                     <%--  <div id="editbu" style="margin-left:30px; margin-top:8px;">
                      <asp:Button ID="btnrpt" runat="server"  Text="Report" OnClientClick="Export_Multiple_BL_rpt('New'); return false" Visible="false" />
                  </div>--%>
                  <%-- <div id="editbu" style="margin-left:30px; margin-top:8px;">
                      <asp:Button ID="btnNew_Win" runat="server"  Text="Report" OnClientClick="return Export_Multiple_BL_rpt_NewWindow();" />
                  </div>
                   <div id="editbu" style="margin-left:30px; margin-top:8px;">
                      <asp:Button ID="btnBr_Rpt" runat="server"  Text="Brokerage Rpt" OnClientClick="open_jobno_Brokerage(); return false" />
                  </div>--%>
                 
             </div>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
             <asp:HiddenField ID="HD_Showcon" runat="server" />

             <asp:HiddenField ID="HDEXP_Name" runat="server" />
             <asp:HiddenField ID="HDR_ID" runat="server" />

             <asp:HiddenField ID="hdBranch" runat="server" />

              <asp:HiddenField ID="hdn_CLIENT_TYPE" runat="server" />
              <asp:HiddenField ID="hd_Brslno" runat="server" />
              <asp:HiddenField ID="hdfTransport_mode1" runat="server" />
                <asp:HiddenField ID="hdn_JobID" runat="server" />
                 <asp:HiddenField ID="hdn_MODE" runat="server" />
                <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />

          <%--  ---------------------------E------------------------------------------%>
         
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
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
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        
    </script>

         <script type="text/javascript">

             function open_jobno_Rpt() {
                 if (document.getElementById("hdn_JobID").value != 'Select') {
                     document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("hdn_JobID").value;
                     if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                         var f = document.getElementById("hdn_JobID").value;
                         var MODE = document.getElementById("hdn_MODE").value;
//                         alert(f);
//                         alert(MODE);
                         NewWindow1('../Despatch/Export_Despatch_Info_Rpt.aspx?jobno=' + f + '&Mode=' + MODE + '', 'List', '870', '1024', 'yes');
                         return false
                     }
                 }
             }

         </script>
</body>
</html>
