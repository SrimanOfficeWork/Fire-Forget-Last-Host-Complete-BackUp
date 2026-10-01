<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Classic_DSR_Entry.aspx.cs" Inherits="Imp_Classic_DSR_Entry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Classic DSR</title>
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



          <div id="innerbox_MidMain_Billing" style="height:34px;">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                    ADC Entry
                </div>
                <div id="verslic">
                </div>
                <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                    <div id="tag_label_transact_Src" style="width: 80px;">
                        Customer
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 320px;">
                        <asp:DropDownList ID="ddl_Client_Name" runat="server" class="chosen-select-deselect"
                            Style="width: 320px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                            TabIndex="4" OnSelectedIndexChanged="ddl_Client_Name_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="verslic" style="margin-top: -5px;">
                </div>
                <div id="tag_transac_lft_in2">
                    <div id="tag_label_transaction_popup_gen" style="width: 50px;">
                        Jobno
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 120px;">
                        <asp:DropDownList ID="ddljobno" runat="server" class="chosen-select-deselect" Style="width: 120px;"
                            data-placeholder="0" AutoPostBack="true" TabIndex="8" 
                            onselectedindexchanged="ddljobno_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                     <div id="tag_label_transact_Src" style="width:10px;" >
                     </div>
                    <%--<div id="tag_label_transact_Src" style="width: 70px;">
                        <asp:Button ID="btnloadData" TabIndex="31" runat="server" Text="Load Data" OnClick="btnloadData_Click" />
                    </div>--%>
                </div>
                <div id="popupwindow_closebut_right_new" >
                   <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                </div>
            </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div class="content" id="page-1">
                 <div id="pop_text_area_transac_popup_inn_container_new">
                     <div id="pop_text_area_transac_popup_inn_container_left_new">
                         <div id="tag_transac_lft_in1">
                             <div id="tag_label_transaction_popup_gen">
                                 No of Containers
                                 </div>
                             <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                 <asp:TextBox ID="txt_No_of_Contaiers" runat="server" MaxLength="100" Font-Bold="true" ClientIDMode="Static" 
                                 CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" TabIndex="10"></asp:TextBox>
                                      
                             </div>
                         </div>

                         <div id="tag_transac_lft_in1">
                             <div id="tag_label_transaction_popup_gen">
                                 Original Rec. Date
                             </div>
                             <div id="txtcon-m_transaction_code">
                                 <asp:TextBox ID="txt_Original_Rec_date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                     Width="90px" MaxLength="35" TabIndex="12"></asp:TextBox>
                                 <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Original_Rec_date"
                                     Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                     MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                 </cc1:MaskedEditExtender>
                                 <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Original_Rec_date"
                                     Format="dd/MM/yyyy">
                                 </cc1:CalendarExtender>
                             </div>
                         </div>

                           <div id="tag_transac_lft_in1">
                             <div id="tag_label_transaction_popup_gen">
                                 Bond Cancel Date
                             </div>
                             <div id="txtcon-m_transaction_code">
                                 <asp:TextBox ID="txt_Bond_Cancel_date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                     Width="90px" MaxLength="35" TabIndex="14"></asp:TextBox>
                                 <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt_Bond_Cancel_date"
                                     Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                     MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                 </cc1:MaskedEditExtender>
                                 <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_Bond_Cancel_date"
                                     Format="dd/MM/yyyy">
                                 </cc1:CalendarExtender>
                             </div>
                         </div>

                         <div id="tag_transac_lft_in1" style="height: 50px;">
                             <div id="tag_label_transaction_popup_gen">
                                 Home consumption BOE No
                             </div>
                             <div id="txtcon-m_transaction_code">
                                 <asp:TextBox ID="txt_Home_Consumption_BOE_No" runat="server" ClientIDMode="Static"
                                     CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="16"></asp:TextBox>
                             </div>
                         </div>

                         
                          <div id="tag_transac_lft_in1" style="height: 50px;">
                             <div id="tag_label_transaction_popup_gen">
                                 e-Way Bill Rec. Date
                             </div>
                             <div id="txtcon-m_transaction_code">
                                 <asp:TextBox ID="txt_e_Way_Bill_Date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                     Width="90px" MaxLength="35" TabIndex="18"></asp:TextBox>
                                 <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txt_e_Way_Bill_Date"
                                     Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                     MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                 </cc1:MaskedEditExtender>
                                 <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_e_Way_Bill_Date"
                                     Format="dd/MM/yyyy">
                                 </cc1:CalendarExtender>
                             </div>
                         </div>

                          <div id="tag_transac_lft_in1" >
                             <div id="tag_label_transaction_popup_gen">
                                 Dispatch Date
                             </div>
                             <div id="txtcon-m_transaction_code">
                                 <asp:TextBox ID="txt_Dispatch_Date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                     Width="90px" MaxLength="35" TabIndex="20"></asp:TextBox>
                                 <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txt_Dispatch_Date"
                                     Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                     MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                 </cc1:MaskedEditExtender>
                                 <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_Dispatch_Date"
                                     Format="dd/MM/yyyy">
                                 </cc1:CalendarExtender>
                             </div>
                         </div>

                     </div>



                     <div id="pop_text_area_transac_popup_inn_container_rght_new">
                         <div id="tag_transac_lft_in1">
                             <div id="tag_label_transaction_popup_gen2">
                                 ETA Date
                             </div>
                             <div id="txtcon-m_transaction_pop_gen1_srcic">
                                   <asp:TextBox ID="txt_ETA_Date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                        Width="90px" MaxLength="35" TabIndex="11"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_ETA_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_ETA_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                             </div>
                         </div>
                            <div id="tag_transac_lft_in1">
                             <div id="tag_label_transaction_popup_gen2">
                                 Bond Issue Date
                             </div>
                             <div id="txtcon-m_transaction_pop_gen1_srcic">
                                   <asp:TextBox ID="txt_Bond_Iss_Date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                        Width="90px" MaxLength="35" TabIndex="13"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_Bond_Iss_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Bond_Iss_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                             </div>
                         </div>


                         <div id="tag_transac_lft_in1">
                             <div id="tag_label_transaction_popup_gen2">
                                 Doc. Rec Date
                             </div>
                             <div id="txtcon-m_transaction_pop_gen1_srcic">
                                   <asp:TextBox ID="txt_Doc_Rec_Date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                        Width="90px" MaxLength="35" TabIndex="15"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Doc_Rec_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_Doc_Rec_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                             </div>
                         </div>

                           <div id="tag_transac_lft_in1"  style="height:50px;">
                             <div id="tag_label_transaction_popup_gen2">
                                Home consumption BOE Date

                             </div>
                             <div id="txtcon-m_transaction_pop_gen1_srcic">
                                   <asp:TextBox ID="txt_Home_Consumption_BOE_Date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                        Width="90px" MaxLength="35" TabIndex="17"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_Home_Consumption_BOE_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_Home_Consumption_BOE_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                             </div>
                         </div>

                          <div id="tag_transac_lft_in1" style="height: 50px;">
                             <div id="tag_label_transaction_popup_gen2">
                               Destuffing Date
                             </div>
                             <div id="txtcon-m_transaction_pop_gen1_srcic">
                                   <asp:TextBox ID="txt_Destuffing_date" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                     Width="90px" MaxLength="35" TabIndex="19"></asp:TextBox>
                                 <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt_Destuffing_date"
                                     Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                     MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                 </cc1:MaskedEditExtender>
                                 <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_Destuffing_date"
                                     Format="dd/MM/yyyy">
                                 </cc1:CalendarExtender>
                                   
                             </div>
                         </div>

                         <div id="tag_transac_lft_in1" style="height: 50px;">
                             <div id="tag_label_transaction_popup_gen2">
                               Remarks
                             </div>
                             <div id="txtcon-m_transaction_pop_gen1_srcic">
                                   <asp:TextBox ID="txt_Remarks" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                      MaxLength="500" TabIndex="21"></asp:TextBox>
                             </div>
                         </div>

                     </div>

                 </div>
            </div>


              
            <%-------------------------------------------------------------------------------%>
            <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px; margin-left:20px; margin-top:-14px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="26" onclick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="23" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="25" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="27" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this DSR?', 'DSR Entry', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="28" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="30">
                        </div>
                      
                    </div>
                </div>
            <%-- --------------------Test End----------------------------%>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HDJobno" runat="server" />
           </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  
   <script  src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>

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
   
   <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>

     <script type="text/javascript">
         var config = {
             '.chosen-select': {},
             '.chosen-select-deselect': { allow_single_deselect: true },
             '.chosen-select-no-single': { disable_search_threshold: 10 },
             '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
             '.chosen-select-width': { width: "95%" }

         }
         for (var selector in config) {
             $(selector).chosen(config[selector]);
         }

        </script>
    
</body>
</html>
