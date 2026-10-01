<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_ClearanceRpt_ICC.aspx.cs"  Inherits="Imp_ClearanceRpt_ICC"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import - Clearance Report</title>
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
    <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
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
width:885px;
max-width:885px;
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
                <div id="tag_srcinner1_new" style="width: 780px;">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                       Import Clearance Report 
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 965px">
                    <div id="tag_Exchange_inner_lft" style="width: 665px">
                        <div id="tag_transact_lft_in1">
                            <div id="Div1" style="width: 850px; margin-top: 10px;">
                                <div id="tag_label_transaction_popup_trans_cth_label2">
                                  JobNo 
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 160px;">
                                  <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1" 
                                        AutoPostBack="True" Width="150px"
                                    Font-Size="12px"     OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged" 
                                        TabIndex="1">
                                    </asp:DropDownList> 
                                    <asp:TextBox ID="txt_JobNo" runat="server" MaxLength="50" CssClass="txtbox_trans_exp_drawback"
                                        ClientIDMode="Static" ReadOnly="true" Width="135px" TabIndex="2" Visible="false"></asp:TextBox>                             
                                </div>
                               
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_exp_jobb">
                                    Party Ref No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width:145px">
                                    <asp:TextBox ID="txt_PartyRefNo" runat="server" MaxLength="50" CssClass="txtbox_trans_exp_drawback"
                                        ClientIDMode="Static"  Width="135px" TabIndex="2"></asp:TextBox>
                                </div>

                                  <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                            <div id="tag_label_transaction_exp_jobb" style="width:30px">
                            Date
                            </div>
                            
                            <div id="txt_trans_exp_drawback" style="width:100px">
                                <asp:TextBox ID="txt_Date" runat="server" ClientIDMode="Static" 
                                    CssClass="txtbox_trans_exp_drawback" Width="90px"
                                    MaxLength="35" TabIndex="3"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Date"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>

                            
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           <%-- -------------------------------------N--------------------------------------------------------%>
          
            <div id="innerbox_MidMain_Trans_new" style="height:350px;">
            <ol id="toc_new">
                             
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');return false;" id="IMD">
                        <span> </span></a></li>
                  
                </ol>
                <div class="content" id="page-1" style="height: 330px; width: 860px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 335px;">
                        <div id="innerbox_MidMain_bot_transact" style="height: 200px; width: 820px; font-weight: normal">
                            <div id="tag_transact_lft_in1" style="width: 400px">
                                <div id="tag_label_transaction_exp_jobb" style="font-style: normal">
                                    BL Number
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1">
                                    <asp:TextBox ID="txt_BLNumber" runat="server" MaxLength="300" ClientIDMode="Static"
                                        TabIndex="4" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 400px">
                                <div id="tag_label_transaction_exp_jobb" style="width: 150px">
                                    N/N Docs Recd Date
                                </div>
                                <div id="txt_trans_exp_drawback" style="width: 100px">
                                    <asp:TextBox ID="txt_Normaldate" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                        Width="90px" MaxLength="35" TabIndex="10"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Normaldate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Normaldate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 400px">
                                <div id="tag_label_transaction_exp_jobb">
                                    Supplier
                                </div>
                                <div id="txt_trans_exp_drawback">
                                    <asp:TextBox ID="txt_Supplier" runat="server" MaxLength="200" ClientIDMode="Static"
                                        TabIndex="6" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 400px">
                                <div id="tag_label_transaction_exp_jobb" style="width: 150px">
                                    Original Docs Recd Date
                                </div>
                                <div id="txt_trans_exp_drawback" style="width: 100px">
                                    <asp:TextBox ID="txt_Originaldate" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                        Width="90px" MaxLength="35" TabIndex="10"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt_Originaldate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_Originaldate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 400px">
                                <div id="tag_label_transaction_exp_jobb">
                                    Vessel
                                </div>
                                <div id="txt_trans_exp_drawback">
                                    <asp:TextBox ID="txt_Vessel" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                        MaxLength="100" TabIndex="9"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                               
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 400px">
                                <div id="tag_label_transaction_exp_jobb" style="width: 150px">
                                    Final Arrival Date
                                </div>
                                <div id="txt_trans_exp_drawback" style="width: 100px">
                                    <asp:TextBox ID="txt_Finaldate" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                        Width="90px" MaxLength="35" TabIndex="17"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Finaldate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_Finaldate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 400px; height: 50px;">
                                <div id="tag_label_transaction_exp_jobb">
                                    Description
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1">
                                    <asp:TextBox ID="txt_Description" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1"
                                        TextMode="MultiLine" MaxLength="60" TabIndex="21" Width="250px"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 400px">
                                <div id="tag_label_transaction_exp_jobb" style="width: 150px">
                                    Container Arrival Date
                                </div>
                                <div id="txt_trans_exp_drawback" style="width: 100px">
                                    <asp:TextBox ID="txt_Containerdate" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                        Width="90px" MaxLength="35" TabIndex="17"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txt_Containerdate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_Containerdate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 400px; height:30px"">
                                <div id="tag_label_transaction_exp_jobb" style="width: 150px">
                                </div>
                                <div id="txt_trans_exp_drawback" style="width: 100px">
                                </div>
                            </div>
                            <div id="tag_transac_exp_drawback" style="width: 400px; height: 50px;">
                                <div id="tag_label_transaction_exp_jobb">
                                    Remarks
                                </div>
                                <div id="txtcon-m_transaction_pop_gen1">
                                    <asp:TextBox ID="txt_Remarks" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1"
                                        TextMode="MultiLine" MaxLength="60" TabIndex="21" Width="250px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

             
              
                <div style="display: none;">
                      <asp:HiddenField ID="HD_Update_id" runat="server" />
                      
                </div>
 
             </div>
            <div id="innerbox_MidMain_bot_transact" style="height: 55px; font-weight: normal;
                margin-top: 10; width: 98%;">
                <div id="magnify_area">
                </div>
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                        TabIndex="28" OnClick="btnNew_Click1" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="23"
                        OnClientClick="return validate();" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                        TabIndex="23" />
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="editbu" style="margin-top: 7px;">
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="24" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Despatch Information', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
           
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="24" OnClick="btnDelete_Click" CssClass="dlete"
                        Style="display: none;" />
                </div>
                <div id="editbu">
                    <%--<asp:Button ID="btnrpt" Visible="false" CssClass="generate" runat="server" OnClientClick="open_jobno_Dispatch(); return false" />--%>
                </div>
            </div>
            </div>
           
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
    <script src="../js/Import_Jscript/Import_Item.js" type="text/javascript"></script>

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

     <script type="text/javascript">
         function open_jobno_Dispatch() {
             if (document.getElementById("txt_JobNo").value != '') {
                 NewWindow1('../Despatch/Import_Despatch_Info_Rpt.aspx?jobno=' + document.getElementById("txt_JobNo").value + '', 'List', '870', '1024', 'yes');
                 return false
              }
         }
     </script>

</body>
</html>
