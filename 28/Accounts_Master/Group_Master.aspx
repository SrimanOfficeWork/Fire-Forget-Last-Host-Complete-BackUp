<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Group_Master.aspx.cs" Inherits="Accounts_Master_Group_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Group Master | Updation</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

    <script type="text/javascript">
        
        function HideModalPopup_Job() {

            $find("MP_JOB").hide();
            return false;
        }
        
        function ShowModalPopup_Job() {

            $find("MP_JOB").show();
            return false;
        }
        
</script>

</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
           
            <div id="innerbox_MidMain_popup_adcode">
                <div id="innerbox_MidMain_top_adcode">
                    GROUP MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style=" height:410px;">
                    <div id="pop_text_area" style=" width:450px;">
                            <div id="tag_label_adcode" style="color:Blue">
                                Opening Balance
                            </div>
                            <div id="txtcon-m_transaction_mode">
                                <asp:TextBox ID="txtOpeningBalance" runat="server" MaxLength="50" CssClass="validate[required] txtbox_none" 
                                    ClientIDMode="Static" TabIndex="1"   BackColor="LightGray"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                    <div id="pop_text_area" style=" width:450px;">
                        <div id="tag_label_adcode">
                            Ledger
                        </div>
                        <div id="txtcon-m_transaction_mode" style=" width:250px;">
                           <asp:DropDownList ID="ddlLedger" runat="server" Width="240px" CssClass="validate[required] listtxt_transac_mode_new" TabIndex="2" AutoPostBack="true" OnSelectedIndexChanged="ddlLedger_SelectedIndexChanged">                                                      
                            </asp:DropDownList> 
                           <%--  <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return ShowModalPopup_Job()" 
                            CausesValidation="false" UseSubmitBehavior="false" />--%>
                        </div>
                        <div id="txtcon-r_src">
                            <asp:Button ID="Button2" runat="server" Text="Add New" OnClientClick="return ShowModalPopup_Job()"  TabIndex="30"
                            CausesValidation="false" UseSubmitBehavior="false" />
                        </div>
                       
                    </div>
                    <div id="pop_text_area"  style=" width:450px;">
                        <div id="tag_label_adcode">
                            Sub Group
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:DropDownList ID="ddlSubGroup" runat="server" Width="227px" CssClass="validate[required] listtxt_transac_mode_new" TabIndex="3" AutoPostBack="true" OnSelectedIndexChanged="ddlSubGroup_SelectedIndexChanged">                               
                            </asp:DropDownList>
                        </div>
                    </div>
                     <div id="pop_text_area" style=" width:450px;">
                        <div id="tag_label_adcode">
                            Group name
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:DropDownList ID="ddlGroup" runat="server" Width="227px" CssClass="validate[required] listtxt_transac_mode_new" TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">                                   
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="pop_text_area"  style=" width:450px;">
                        <div id="tag_label_adcode">
                            Reporting
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:DropDownList ID="ddlReporting" runat="server" Width="227px" CssClass="validate[required] listtxt_transac_mode_new" TabIndex="5">                                                      
                            </asp:DropDownList>
                        </div>
                    </div>                   
                      
            </div>
            <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="12" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" 
                            TabIndex="7" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            TabIndex="8" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="9" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'GROUP MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="10" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                            tabindex="11" id="btnCancel" />

                        <asp:HiddenField ID="HDupdate_id" runat="server" />
                    </div>
                </div>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>



     <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 400px; height: 300px;">
            <table width="100%" style="padding-top: 10px;">


                <tr>
                    <td align="center">
                        
                    </td>
                    <td align="right">
                        <asp:Button ID="Button3" runat="server" Text="Close" OnClientClick="return HideModalPopup_Job()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                     </tr>
                      <tr>
                    <td align="center">
                        
                    </td>
                    <td align="right">
                         &nbsp;
                    </td>
                     </tr>
                <tr>
                    <td align="left">
                         &nbsp;Ledger
                    </td>
                    <td>
                        <asp:TextBox ID="txt_leg" runat="server" MaxLength="50" CssClass="txtbox_none" ClientIDMode="Static"
                            TabIndex="1"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="left">
                         &nbsp;Sub Group 
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlSubGroup_N" runat="server" Width="227px" CssClass="validate[required] listtxt_transac_mode_new" TabIndex="3" >
                                                             
                        <asp:ListItem Text="Bank Accounts" Value="Bank Accounts"></asp:ListItem>
                        <asp:ListItem Text="Clearing Charges" Value="Clearing Charges"></asp:ListItem>
                        <asp:ListItem Text="Clearing Expenses" Value="Clearing Expenses"></asp:ListItem>
                        <asp:ListItem Text="Duties & Taxes" Value="Duties & Taxes"></asp:ListItem>
                        <asp:ListItem Text="Freight Forwarding Expenses" Value="Freight Forwarding Expenses"></asp:ListItem>
                        <asp:ListItem Text="Import Refund" Value="Import Refund"></asp:ListItem>
                        <asp:ListItem Text="Income Tax" Value="Income Tax"></asp:ListItem>
                        <asp:ListItem Text="Indirect Expenses" Value="Indirect Expenses"></asp:ListItem>
                        <asp:ListItem Text="Loans & Advance" Value="Loans & Advance"></asp:ListItem>
                        <asp:ListItem Text="Loans & Advances (Asset)" Value="Loans & Advances (Asset)"></asp:ListItem>
                        <asp:ListItem Text="No Margin Expenses" Value="No Margin Expenses"></asp:ListItem>
                        <asp:ListItem Text="No Margin Income" Value="No Margin Income"></asp:ListItem>
                        <asp:ListItem Text="Party Name" Value="Party Name"></asp:ListItem>
                        <asp:ListItem Text="Prepaid Expenses" Value="Prepaid Expenses"></asp:ListItem>
                        <asp:ListItem Text="Provisions" Value="Provisions"></asp:ListItem>
                        <asp:ListItem Text="Pure Agent" Value="Pure Agent"></asp:ListItem>
                        <asp:ListItem Text="Pure Agent Expenses" Value="Pure Agent Expenses"></asp:ListItem>
                        <asp:ListItem Text="Sez LUT Income" Value="Sez LUT Income"></asp:ListItem>
                        <asp:ListItem Text="Sundry Creditor -Group" Value="Sundry Creditor -Group"></asp:ListItem>
                        <asp:ListItem Text="Sundry Creditor -Transporter" Value="Sundry Creditor -Transporter"></asp:ListItem>
                        <asp:ListItem Text="Sundry Debtors" Value="Sundry Debtors"></asp:ListItem>
                        <asp:ListItem Text="Taxable 12% Income" Value="Taxable 12% Income"></asp:ListItem>
                        <asp:ListItem Text="Taxable 18% Income" Value="Taxable 18% Income"></asp:ListItem>
                        <asp:ListItem Text="Taxable 5% Income" Value="Taxable 5% Income"></asp:ListItem>
                        <asp:ListItem Text="TDS Payable" Value="TDS Payable"></asp:ListItem>
                        <asp:ListItem Text="TDS Receivable" Value="TDS Receivable"></asp:ListItem>
                        <asp:ListItem Text="Transport Charges" Value="Transport Charges"></asp:ListItem>
                        
                        <asp:ListItem Text="Administrative Expenses" Value="Administrative Expenses"></asp:ListItem>
                        <asp:ListItem Text="BANK DEPOSITS" Value="BANK DEPOSITS"></asp:ListItem>
                        <asp:ListItem Text="Clearance Charges" Value="Clearance Charges"></asp:ListItem>
                        <asp:ListItem Text="Duties & Taxes" Value="Duties & Taxes"></asp:ListItem>
                        <asp:ListItem Text="Establishment Expenses" Value="Establishment Expenses"></asp:ListItem>
                        <asp:ListItem Text="Fixed Asset Reserved" Value="Fixed Asset Reserved"></asp:ListItem>
                        <asp:ListItem Text="Foreign Agents" Value="Foreign Agents"></asp:ListItem>
                        <asp:ListItem Text="Freight Forwarding Expenses" Value="Freight Forwarding Expenses"></asp:ListItem>
                        <asp:ListItem Text="GST" Value="GST"></asp:ListItem>
                        <asp:ListItem Text="GSTR3B" Value="GSTR3B"></asp:ListItem>
                        <asp:ListItem Text="Income Tax" Value="Income Tax"></asp:ListItem>
                        <asp:ListItem Text="Loans & Advance" Value="Loans & Advance"></asp:ListItem>
                        <asp:ListItem Text="Loans & Advances (Asset)" Value="Loans & Advances (Asset)"></asp:ListItem>
                        <asp:ListItem Text="Miscellaneious Expenses" Value="Miscellaneious Expenses"></asp:ListItem>
                        <asp:ListItem Text="MSME-CFS" Value="MSME-CFS"></asp:ListItem>
                        <asp:ListItem Text="MSME-For Expenses" Value="MSME-For Expenses"></asp:ListItem>
                        <asp:ListItem Text="MSME-Steamer" Value="MSME-Steamer"></asp:ListItem>
                        <asp:ListItem Text="MSME-Subagent" Value="MSME-Subagent"></asp:ListItem>
                        <asp:ListItem Text="MSME-TDS Transporter" Value="MSME-TDS Transporter"></asp:ListItem>
                        <asp:ListItem Text="MSME-Transporter" Value="MSME-Transporter"></asp:ListItem>
                        <asp:ListItem Text="No Margin Expenses- Exp" Value="No Margin Expenses- Exp"></asp:ListItem>
                        <asp:ListItem Text="No Margin Income" Value="No Margin Income"></asp:ListItem>
                        <asp:ListItem Text="NON-MSME-CFS" Value="NON-MSME-CFS"></asp:ListItem>
                        <asp:ListItem Text="NON-MSME-For Expenses" Value="NON-MSME-For Expenses"></asp:ListItem>
                        <asp:ListItem Text="NON-MSME-Steamer" Value="NON-MSME-Steamer"></asp:ListItem>
                        <asp:ListItem Text="NON-MSME-Subagent" Value="NON-MSME-Subagent"></asp:ListItem>
                        <asp:ListItem Text="NON-MSME-TDS Transporter" Value="NON-MSME-TDS Transporter"></asp:ListItem>
                        <asp:ListItem Text="NON-MSME-Transporter" Value="NON-MSME-Transporter"></asp:ListItem>
                        <asp:ListItem Text="Payable" Value="Payable"></asp:ListItem>
                        <asp:ListItem Text="Prepaid Expenses" Value="Prepaid Expenses"></asp:ListItem>
                        <asp:ListItem Text="Provisions" Value="Provisions"></asp:ListItem>
                        <asp:ListItem Text="Provison for Income Tax" Value="Provison for Income Tax"></asp:ListItem>
                        <asp:ListItem Text="Pure Agent Expenses" Value="Pure Agent Expenses"></asp:ListItem>
                        <asp:ListItem Text="Pure Agent" Value="Pure Agent"></asp:ListItem>
                        <asp:ListItem Text="Repairs & Maintenance" Value="Repairs & Maintenance"></asp:ListItem>
                        <asp:ListItem Text="Sales RCM" Value="Sales RCM"></asp:ListItem>
                        <asp:ListItem Text="Secured Loans" Value="Secured Loans"></asp:ListItem>
                        <asp:ListItem Text="Selling & Distribution Expenses" Value="Selling & Distribution Expenses"></asp:ListItem>
                        <asp:ListItem Text="Sez LUT Income" Value="Sez LUT Income"></asp:ListItem>
                        <asp:ListItem Text="SUB AGENT" Value="SUB AGENT"></asp:ListItem>
                        <asp:ListItem Text="Sundry Creditor - Deposit" Value="Sundry Creditor - Deposit"></asp:ListItem>
                        <asp:ListItem Text="Sundry Creditors - C F S" Value="Sundry Creditors - C F S"></asp:ListItem>
                        <asp:ListItem Text="Sundry Creditors - Expenses" Value="Sundry Creditors - Expenses"></asp:ListItem>
                        <asp:ListItem Text="Sundry Creditors for Expenses" Value="Sundry Creditors for Expenses"></asp:ListItem>
                        <asp:ListItem Text="Sundry Creditors" Value="Sundry Creditors"></asp:ListItem>
                        <asp:ListItem Text="Sundry Debtors" Value="Sundry Debtors"></asp:ListItem>
                        <asp:ListItem Text="Taxable 12% Income" Value="Taxable 12% Income"></asp:ListItem>
                        <asp:ListItem Text="Taxable 18% Income" Value="Taxable 18% Income"></asp:ListItem>
                        <asp:ListItem Text="Taxable 5% Income" Value="Taxable 5% Income"></asp:ListItem>
                        <asp:ListItem Text="Tds Receivable -20-21" Value="Tds Receivable -20-21"></asp:ListItem>
                        <asp:ListItem Text="Tds Receivable 18-19" Value="Tds Receivable 18-19"></asp:ListItem>
                        <asp:ListItem Text="Tds Receivable 19-20" Value="Tds Receivable 19-20"></asp:ListItem>
                        <asp:ListItem Text="TDS Receivable 21-22" Value="TDS Receivable 21-22"></asp:ListItem>
                        <asp:ListItem Text="TDS RECEIVABLE 22-23" Value="TDS RECEIVABLE 22-23"></asp:ListItem>
                        <asp:ListItem Text="TDS RECEIVABLE 23-24" Value="TDS RECEIVABLE 23-24"></asp:ListItem>
                        <asp:ListItem Text="TDS-Receivable" Value="TDS-Receivable"></asp:ListItem>
                        <asp:ListItem Text="Transport Charges" Value="Transport Charges"></asp:ListItem>
                        <asp:ListItem Text="Transporters" Value="Transporters"></asp:ListItem>
                        <asp:ListItem Text="Travelling & Conveyance" Value="Travelling & Conveyance"></asp:ListItem>
                        <asp:ListItem Text="Unsecured Loans" Value="Unsecured Loans"></asp:ListItem>
                         </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="left">
                        &nbsp;Group Name
                    </td>
                    <td>
                           <asp:DropDownList ID="ddlGroup_Name_N" runat="server" Width="227px" 
                               CssClass="validate[required] listtxt_transac_mode_new" TabIndex="4" >  
                               <asp:ListItem Text="Administrative Expenses" Value="Administrative Expenses"></asp:ListItem>
                                <asp:ListItem Text="Current Assets" Value="Current Assets"></asp:ListItem>
                                <asp:ListItem Text="Current Liabilities" Value="Current Liabilities"></asp:ListItem>
                                <asp:ListItem Text="Direct Expenses" Value="Direct Expenses"></asp:ListItem>
                                <asp:ListItem Text="Direct Incomes" Value="Direct Incomes"></asp:ListItem>
                                <asp:ListItem Text="Sundry Creditors" Value="Sundry Creditors"></asp:ListItem>

                                <asp:ListItem Text="Current Assets" Value="Current Assets"></asp:ListItem>
                                <asp:ListItem Text="Current Liabilities" Value="Current Liabilities"></asp:ListItem>
                                <asp:ListItem Text="Deposits (Asset)" Value="Deposits (Asset)"></asp:ListItem>
                                <asp:ListItem Text="Direct Expenses" Value="Direct Expenses"></asp:ListItem>
                                <asp:ListItem Text="Direct Income" Value="Direct Income"></asp:ListItem>
                                <asp:ListItem Text="Direct Incomes" Value="Direct Incomes"></asp:ListItem>
                                <asp:ListItem Text="Duties & Taxes" Value="Duties & Taxes"></asp:ListItem>
                                <asp:ListItem Text="Fixed Assets" Value="Fixed Assets"></asp:ListItem>
                                <asp:ListItem Text="Indirect Expenses" Value="Indirect Expenses"></asp:ListItem>
                                <asp:ListItem Text="Loans & Advances (Asset)" Value="Loans & Advances (Asset)"></asp:ListItem>
                                <asp:ListItem Text="Loans (Liability)" Value="Loans (Liability)"></asp:ListItem>
                                <asp:ListItem Text="Loans(Liability)" Value="Loans(Liability)"></asp:ListItem>
                                <asp:ListItem Text="Sundry Creditors" Value="Sundry Creditors"></asp:ListItem>
                           </asp:DropDownList>
                    </td>
                </tr>
                          <tr>
                    <td align="left">
                         &nbsp;Reporting
                    </td>
                    <td>
                         <asp:DropDownList ID="ddl_Rpt_N" runat="server" Width="227px" CssClass="validate[required] listtxt_transac_mode_new" TabIndex="5" >
                         <asp:ListItem Text="Balance Sheet" Value="Balance Sheet"></asp:ListItem>
                         <asp:ListItem Text="Profit and Loss" Value="Profit and Loss"></asp:ListItem>     
                         </asp:DropDownList>
                    </td>
                </tr>

                 <tr>
                    <td align="left">
                        
                    </td>
                    <td>
                         <span style="color:Red; font-weight:bold;"> <asp:Literal ID="lbl_Msg" runat="server"></asp:Literal></span>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="btn_Chsave" runat="server" Text="Save" CausesValidation="false"  TabIndex="7"
                            UseSubmitBehavior="false" onclick="btn_Chsave_Click"  />
                            
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    </form>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    
    
</body>
</html>