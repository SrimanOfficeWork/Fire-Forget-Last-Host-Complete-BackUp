<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Covering_Letter_Pegasus.aspx.cs" Inherits="Export_BL_Generation_Annexure"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Covering Letter</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
      <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
   
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
    <script src="../js/Billing/Covering_Letter.js" type="text/javascript"></script>

  <script language="javascript" type="text/javascript"
      src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js">
    </script>

    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>

    <script type="text/javascript">
        function open_anx() {
            
            if (document.getElementById('hdnfld_Jobno').value != '') {
                var f = document.getElementById('hdnfld_Jobno').value;
                var type = document.getElementById('ddl_Type').value;
                var report_type ='Pegasus_Report';
                NewWindow1('../Billing_Imp_Rpt/GST_Bill_Imp_Exp_Covering_Letter_Rpt.aspx?jobno=' + f + '&Type=' + type + '&report_type=' + report_type + '', 'List', '870', '1024', 'yes');
           }
        }   
    </script>

    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>

    <style>
        .print_btn
        {
            background: url('../images/print_Butt.png') no-repeat;
            width: 101px;
            height: 30px;
            text-indent: -9999px;
            overflow: hidden;
            text-transform: uppercase;
            border: none;
            cursor: pointer;
        }
        
        .print_btn:hover
        {
            background-position: left bottom;
        }
    </style>

</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server"  style="height:50px">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" LoadScriptsBeforeUI="false"
      EnablePageMethods="true" AsyncPostBackTimeout="0">
     </asp:ScriptManager>

     <asp:UpdatePanel ID="UpdatePanel1"  runat="server" UpdateMode="Conditional" Visible="true">
     <ContentTemplate>
       <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
     
     </ContentTemplate>
     </asp:UpdatePanel>

    <div id="innerbox_MidMain_Trans_IGM_Invoice" style="text-align:center; height:560px; width:772px;">

     <div id="mainmastop2container_rght_tag2_txt1" style="height:20px;font-weight:bold; font-size:large; width:700px;">
     <asp:Label ID="lbl_heading" runat="server" Width="50px" ></asp:Label>
                       Covering Letter
                    </div>
                     <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                     <%--<input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />--%>

        <fieldset style="border: Black; border-style: outset; background-color: #F5F5DC;
            width: 770px; visibility: visible;">
            <div id="tag_transac_exp_drawback" style="height: 30px; margin-top: 10px; width: 770px;">
                <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px">
                </div>
                <div id="tag_label_transact_Src" style="width: 60px">
                    Bill Type
                </div>
                <div id="txtcon-m_transaction_code" style="text-align: left">
                    <asp:DropDownList ID="ddl_Type" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Type_SelectedIndexChanged" TabIndex="1">
                        <asp:ListItem>Import</asp:ListItem>
                        <asp:ListItem>Export</asp:ListItem>
                    </asp:DropDownList>
                </div>
               <div id="tag_label_transact_Src" style="width: 80px">
                   Party Name
                </div>
                <div id="txtcon-m_transaction_code" style="text-align: left; width:300px;">
                    <asp:DropDownList ID="ddl_partyName" runat="server"  Width="300px"  AutoPostBack="true" TabIndex="2"  CssClass="validate[required]"
                        onselectedindexchanged="ddl_partyName_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
               
                <div id="tag_label_transaction_popup_IGM2_empty" style="width: 50px;">
                </div>
                <div id="small-butt-left">
                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                        onserverclick="btnSearch_Click" tabindex="5"></a>
                </div>
            </div>
            <div id="tag_transac_exp_drawback" style="height: 30px; margin-top: 1px; width: 770px;">
                <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px">
                </div>
                <div id="tag_label_transact_Src" style="width: 120px">
                    Bill Your RefNo
                </div>
                <div id="txtcon-m_transaction_code" style="text-align: left">
                    <asp:TextBox ID="txt_Bill_Your_RefNo" runat="server" ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_code_new" 
                        MaxLength="10" TabIndex="3"></asp:TextBox>
                   
                </div>

            </div>
        </fieldset>
                  
                    <div id="tag_transac_exp_drawback" style="height:40px; margin-top:10px;">
                    <div id="tag_label_transaction_popup_IGM2_empty" style="width:20px">
                            </div>

                        <div id="tag_label_transact_Src" style="width: 150px;">
                            Covering Letter No:
                        </div>
                        <div id="txtcon-m_transaction_code" style="text-align: left">
                            <asp:TextBox ID="txt_CoveringNo" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"  TabIndex="6" Font-Bold="true"
                                Width="145px"  ReadOnly="true"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 50px;">
                        </div>

                        <div id="tag_label_transact_Src" style="width: 110px;">
                            Dispatch Date
                        </div>
                        <div id="tag_label_transact_Src">
                            <asp:TextBox ID="txt_DispatchDate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code_new"
                                MaxLength="10" TabIndex="7"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_DispatchDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_DispatchDate"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 70px;">
                            TO :
                        </div>
                        <div id="txtcon-m_transaction_code" style="text-align: left; width: 320px;">
                            <asp:TextBox ID="txt_Add1" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="8"
                                Width="305px"></asp:TextBox>
                        </div>
                        <div id="txtcon-m_transaction_code" style="text-align: left; width: 310px;">
                            <asp:TextBox ID="txt_Add2" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="9"
                                Width="305px"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 70px;">
                        </div>
                        <div id="txtcon-m_transaction_code" style="text-align: left; width: 320px;">
                            <asp:TextBox ID="txt_Add3" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="10"
                                Width="305px"></asp:TextBox>
                        </div>
                        <div id="txtcon-m_transaction_code" style="text-align: left; width: 310px;">
                            <asp:TextBox ID="txt_Add4" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="11"
                                Width="305px"></asp:TextBox>
                        </div>
                    </div>


                     <div id="tag_transac_exp_drawback" style="height:70px";>
                     <div id="tag_label_transaction_popup_IGM2_empty" style="width:20px"></div>
                     <div id="tag_label_transact_Src" style="width: 70px;">
                     Subject
                     </div>
                     <div id="txtcon-m_46px_trans_export_marks">
                                            <asp:TextBox ID="txt_Subject" TextMode="MultiLine" TabIndex="12" runat="server" CssClass="txtbox_none_Mid_transac_export_Marks_nos_gen"
                                                MaxLength="300" onkeyDown="return checkTextAreaMaxLength(this,event,'300');"
                                                onpaste="return checkTextAreaMaxLength(this,event,'300');" Width="300px"></asp:TextBox>
                                        </div>
                      <div id="txtcon-m_transaction_code" style="text-align: left; width: 320px; height:25px;">
                      <div id="tag_label_transact_Src" style="width: 80px;">
                          Reference No</div>
                            <asp:TextBox ID="txt_RefNo" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="13"
                                Width="225px"></asp:TextBox>
                        </div>
                         <div id="txtcon-m_transaction_code" style="text-align: left; width: 320px;">
                      <div id="tag_label_transact_Src" style="width: 80px;">
                          Entered By</div>
                            <asp:TextBox ID="txt_EnteredBy" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="13"
                                Width="225px"></asp:TextBox>
                        </div>
                     </div>

                      <div id="tag_transac_exp_drawback" style="height:210px";>
                     <div id="tag_label_transaction_popup_IGM2_empty" style="width:20px"></div>
                     <div id="tag_label_transact_Src" style="width: 70px;">
                     Attachment
                     </div>
                     <div id="txtcon-m_46px_trans_export_marks" style="height:230px; width:600px; ">
                                            <asp:TextBox ID="txt_Attachement" TextMode="MultiLine" TabIndex="14" runat="server" 
                                                MaxLength="4000"  Height="220px"  Width="600px"></asp:TextBox>
                                                
                                        </div>
                      <%--<div id="txtcon-m_transaction_code" style="text-align: left; width: 320px;">--%>
                      <%-- </div>--%>
        <div id="innerbox_MidMain_bot_transact" style="width: 780px;">
            <asp:Button ID="ButtonSave" runat="server" Text="Save" CssClass="save" OnClick="ButtonSave_Click" />
            <asp:Button ID="btnUpdate" runat="server" Visible="False" CssClass="updates" TabIndex="15"
                OnClick="btnUpdate_Click" />

               
                    <asp:Button ID="btnDelete" runat="server" TabIndex="16" Visible="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Covering Letter', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="17" OnClick="btnDelete_Click" OnClientClick="return validate_Item();"
                        CssClass="dlete" Style="display: none;" />
               

            <asp:Button ID="Button1" runat="server" Text="Print" CssClass="generate" OnClientClick="return open_anx();" TabIndex="18"
             />
        </div>
    </div> 
                    <asp:HiddenField ID="hdn_Covering_No" runat="server" />
                    <asp:HiddenField ID="hdn_TYPE" runat="server" />
                    <asp:HiddenField ID="hdnfld_Jobno" runat="server" />
                   <asp:HiddenField ID="Hdn_get_type" runat="server" />
                   <asp:HiddenField ID="Hdn_Page_Value" runat="server" />

    </form>
  
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <%--<script src="../js/checkboxJScript.js" type="text/javascript"></script>--%>
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

</body>
</html>
