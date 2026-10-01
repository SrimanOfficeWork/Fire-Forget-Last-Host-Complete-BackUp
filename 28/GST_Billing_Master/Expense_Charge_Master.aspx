<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Expense_Charge_Master.aspx.cs" Inherits="Expense_Charge_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> Expense Charge Master | Updation</title>
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
        function changetextbox() {
            if (document.getElementById("ddlTax_NonTax").value == "T" ||document.getElementById("ddlTax_NonTax").value == "P" || document.getElementById("ddlTax_NonTax").value == "R") {

                $("#txt_CGST_Rate").attr('disabled', false);
                $("#txt_SGST_Rate").attr('disabled', false);
                $("#txt_IGST_Rate").attr('disabled', false);

            } else {
                $("#txt_CGST_Rate").attr('disabled', true);
                $("#txt_SGST_Rate").attr('disabled', true);
                $("#txt_IGST_Rate").attr('disabled', true);

                $("#txt_CGST_Rate").val('');
                $("#txt_SGST_Rate").val('');
                $("#txt_IGST_Rate").val('');
            }
        }
        ///////

        function changetextbox_txt_CGST_Rate() {
            if (document.getElementById("txt_CGST_Rate").value != "")
             {

                var C, S, I;
                 C = document.getElementById("txt_CGST_Rate").value;
                 S = C;
                 I = C * 2;
                 //alert(C);
                                  
                 $("#txt_SGST_Rate").val(S);
                 $("#txt_IGST_Rate").val(I);

             }
             else 
            {                
                $("#txt_SGST_Rate").val('');
                $("#txt_IGST_Rate").val('');
            }
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
                    EXPENSE CHARGE MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style="height:390px;">
                    
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Charge Name</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtCharge_Name" runat="server" CssClass="validate[required] txtbox_none"
                                TabIndex="1" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                       <div id="pop_text_area" style="height:60px;display: none;">
                        <div id="tag_label_adcode">
                            Description</div>
                        <div id="txtcon-m_src">
                              <asp:TextBox ID="txtDescription" runat="server" CssClass="listtxt_transac_mode_new"  height="58px"  Width="220px" TextMode="MultiLine"
                                 TabIndex="5" MaxLength="1000"></asp:TextBox>
                                
                        </div>
                    </div>
                    <div id="pop_text_area" >     <%--   style="display:none;"           --%>
                        <div id="tag_label_adcode">
                            Tax / Non-Tax (T/N)
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:DropDownList ID="ddlTax_NonTax" runat="server" onChange="changetextbox();" CssClass="listtxt_transac_mode_new" TabIndex="2">
                           <asp:ListItem  Text="T" Value="T"></asp:ListItem>
                           <asp:ListItem  Text="N" Value="N"></asp:ListItem>
                           <asp:ListItem  Text="P" Value="P"></asp:ListItem>
                           <asp:ListItem  Text="E" Value="E"></asp:ListItem>
                           <asp:ListItem  Text="R" Value="R"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="pop_text_area" >
                        <div id="tag_label_adcode">
                            Group Name
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          
                         <asp:DropDownList ID="ddlGroup_Name" runat="server" Width="227px" CssClass="validate[required] listtxt_transac_mode_new" TabIndex="3">
                           <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                           <asp:ListItem  Text="Direct Incomes" Value="Direct Incomes"></asp:ListItem>
                           <asp:ListItem  Text="Indirect Incomes" Value="Indirect Incomes"></asp:ListItem>
                           <asp:ListItem  Text="Indirect Expenses" Value="Indirect Expenses"></asp:ListItem>
                           <asp:ListItem  Text="Purchase Accounts" Value="Purchase Accounts"></asp:ListItem>
                           <asp:ListItem  Text="Suspense A/c" Value="Suspense A/c"></asp:ListItem>
                           <asp:ListItem  Text="Bank Accounts" Value="Bank Accounts"></asp:ListItem>
                           <asp:ListItem  Text="Bank OD A/c" Value="Bank OD A/c"></asp:ListItem>
                           <asp:ListItem  Text="Cash-in-hand" Value="Cash-in-hand"></asp:ListItem>
                           <asp:ListItem  Text="Deposits (Asset)" Value="Deposits (Asset)"></asp:ListItem>
                           <asp:ListItem  Text="Duties & Taxes" Value="Duties & Taxes"></asp:ListItem>
                           <asp:ListItem  Text="Loans & Advances (Asset)" Value="Loans & Advances (Asset)"></asp:ListItem>
                           <asp:ListItem  Text="Provisions" Value="Provisions"></asp:ListItem>
                           <asp:ListItem  Text="Reserves & Surplus" Value="Reserves & Surplus"></asp:ListItem>
                           <asp:ListItem  Text="Secured Loans" Value="Secured Loans"></asp:ListItem>
                           <asp:ListItem  Text="Stock-in-hand" Value="Stock-in-hand"></asp:ListItem>
                           <asp:ListItem  Text="Sundry Creditors" Value="Sundry Creditors"></asp:ListItem>
                           <asp:ListItem  Text="Sundry Debtors" Value="Sundry Debtors"></asp:ListItem>
                           <asp:ListItem  Text="Unsecured Loans" Value="Unsecured Loans"></asp:ListItem>
                           <asp:ListItem  Text="Investments" Value="Investments"></asp:ListItem>
                           <asp:ListItem  Text="Loans (Liability)" Value="Loans (Liability)"></asp:ListItem>
                           <asp:ListItem  Text="Misc. Expenses (ASSET)" Value="Misc. Expenses (ASSET)"></asp:ListItem>
                           <asp:ListItem  Text="Fixed Assets" Value="Fixed Assets"></asp:ListItem>
                           <asp:ListItem  Text="Branch / Divisions" Value="Branch / Divisions"></asp:ListItem>
                           <asp:ListItem  Text="Capital Account" Value="Capital Account"></asp:ListItem>
                           <asp:ListItem  Text="Current Assets" Value="Current Assets"></asp:ListItem>
                           <asp:ListItem  Text="Current Liabilities" Value="Current Liabilities"></asp:ListItem>
                           <asp:ListItem  Text="Direct Expenses" Value="Direct Expenses"></asp:ListItem>
                           <asp:ListItem  Text="Sales Accounts" Value="Sales Accounts"></asp:ListItem>
                           </asp:DropDownList>
                        </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Nature of Trans.
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlSales_Trans" runat="server" Width="227px" onChange="changetextbox();"
                                CssClass="listtxt_transac_mode_new" TabIndex="4">
                                <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                               <asp:ListItem Text="Purchase Taxable" Value="Purchase Taxable"></asp:ListItem>
                                <asp:ListItem Text="Purchase Exempt" Value="Purchase Exempt"></asp:ListItem>
                                <asp:ListItem Text="Purchase Nil Rate" Value="Purchase Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Interstate Purchase Taxable" Value="Interstate Purchase Taxable"></asp:ListItem>
                                <asp:ListItem Text="Interstate Purchase Exempt" Value="Interstate Purchase Exempt"></asp:ListItem>
                                <asp:ListItem Text="Interstate Purchase Nil Rate" Value="Interstate Purchase Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Intrastate Purchase Deemed Export Taxable" Value="Intrastate Purchase Deemed Export Taxable"></asp:ListItem>
                                <asp:ListItem Text="Intrastate Purchase Deemed Export Exempt" Value="Intrastate Purchase Deemed Export Exempt"></asp:ListItem>
                                <asp:ListItem Text="Intrastate Purchase Deemed Export Nil Rate" Value="Intrastate Purchase Deemed Export Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Purchase From Unregistered Dealer- Taxable" Value="Purchase From Unregistered Dealer- Taxable"></asp:ListItem>
                                <asp:ListItem Text="Purchase From Unregistered Dealer- Exempt" Value="Purchase From Unregistered Dealer- Exempt"></asp:ListItem>
                                <asp:ListItem Text="Purchase From Unregistered Dealer- Nil Rate" Value="Purchase From Unregistered Dealer- Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Purchase From SEZ - Taxable" Value="Purchase From SEZ - Taxable"></asp:ListItem>
                                <asp:ListItem Text="Purchase From SEZ -Exempt" Value="Purchase From SEZ -Exempt"></asp:ListItem>
                                <asp:ListItem Text="Purchase From SEZ -Nil Rate" Value="Purchase From SEZ -Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Purchase From SEZ - LUT/BOND" Value="Purchase From SEZ - LUT/BOND"></asp:ListItem>
                                <asp:ListItem Text="Interstate Purchase From Unregistered Dealer - Taxable" Value="Interstate Purchase From Unregistered Dealer - Taxable"></asp:ListItem>
                                <asp:ListItem Text="Interstate Purchase From Unregistered Dealer - Exempt" Value="Interstate Purchase From Unregistered Dealer - Exempt"></asp:ListItem>
                                <asp:ListItem Text="Interstate Purchase From Unregistered Dealer - Nil Rate" Value="Interstate Purchase From Unregistered Dealer - Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Interstate Purchase From Unregistered Dealer - services" Value="Interstate Purchase From Unregistered Dealer - services"></asp:ListItem>
                                <asp:ListItem Text="Imports Taxable" Value="Imports Taxable"></asp:ListItem>
                                <asp:ListItem Text="Imports Exempt" Value="Imports Exempt"></asp:ListItem>
                                <asp:ListItem Text="Imports Nil Rate" Value="Imports Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Purchase Deemed Export Taxable" Value="Purchase Deemed Export Taxable"></asp:ListItem>
                                <asp:ListItem Text="Purchase Deemed Export Exempt" Value="Purchase Deemed Export Exempt"></asp:ListItem>
                                <asp:ListItem Text="Purchase Deemed Export Nil Rate" Value="Purchase Deemed Export Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Branch Transfer OutWard" Value="Branch Transfer OutWard"></asp:ListItem>
                                <asp:ListItem Text="Purchase From SEZ(Without Bill Of entry) - Taxable" Value="Purchase From SEZ(Without Bill Of entry) - Taxable"></asp:ListItem>
                                <asp:ListItem Text="Purchase From SEZ(Without Bill Of entry) -Exempt" Value="Purchase From SEZ(Without Bill Of entry) -Exempt"></asp:ListItem>
                                <asp:ListItem Text="Purchase From SEZ(Without Bill Of entry) -Nil Rate" Value="Purchase From SEZ(Without Bill Of entry) -Nil Rate"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="pop_text_area" style="display:none;">
                        <div id="tag_label_adcode">
                            HSN Code
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:TextBox ID="txt_HSN_Code" runat="server" CssClass="txtbox_none" 
                                 TabIndex="8"></asp:TextBox>
                        </div>
                    </div>
                      <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            SA Code
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:TextBox ID="txt_SA_Code" runat="server" CssClass="txtbox_none" 
                                 TabIndex="5"></asp:TextBox>
                        </div>
                    </div>

                    
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                           CGST Rate
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_CGST_Rate" runat="server" CssClass="txtbox_none" Width="80px"
                          onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                 TabIndex="6" onChange="changetextbox_txt_CGST_Rate();"></asp:TextBox>

                        </div>
                    </div>

                      <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            SGST Rate
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_SGST_Rate" runat="server" CssClass="txtbox_none" Width="80px" 
                           onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                 TabIndex="7"></asp:TextBox>
                        </div>
                    </div>

                       <div id="pop_text_area">
                        <div id="tag_label_adcode">
                             IGST Rate
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_IGST_Rate" runat="server" CssClass="txtbox_none"  Width="80px"
                           onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                 TabIndex="8"></asp:TextBox>
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                             Debit Amount
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_Debit_Amt" runat="server" CssClass="txtbox_none"  Width="100px"
                           onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                 TabIndex="13"></asp:TextBox>
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                             Credit Amount
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_Credit_Amt" runat="server" CssClass="txtbox_none"  Width="100px"
                           onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                 TabIndex="14"></asp:TextBox>
                        </div>
                    </div>
                     <div id="pop_text_area" style="display:none;">
                        <div id="tag_label_adcode">
                            Shipment Type
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlshipment_type"  Width="80px" TabIndex="15" runat="server">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                             <asp:ListItem Text="Bond" Value="Bond"></asp:ListItem>
                              <asp:ListItem Text="Ex-bond" Value="Exbond"></asp:ListItem>
                               <asp:ListItem Text="FCL" Value="FCL"></asp:ListItem>
                                <asp:ListItem Text="LCL" Value="LCL"></asp:ListItem>
                                 <asp:ListItem Text="20 Feet" Value="20"></asp:ListItem>
                                  <asp:ListItem Text="40 Feet" Value="40"></asp:ListItem>
                               </asp:DropDownList>
                        </div>
                    </div>


                      <div id="pop_text_area" style="display:none;">
                        <div id="tag_label_adcode">
                           Allow Quotation
                        </div>
                        <div id="txtcon-m_transaction_mode">
                         <asp:CheckBox ID="chkQuotation" runat="server"  TabIndex="16" />
                        </div>
                    </div>

                     <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            TDS Section
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlTDS_Section"  Width="80px" TabIndex="17" runat="server" CssClass="listtxt_transac_mode_new">
                                  <asp:ListItem Text="" Value=""></asp:ListItem>                                  
                                  <asp:ListItem Text="192B" Value="192B"></asp:ListItem>
                                  <asp:ListItem Text="194A" Value="194A"></asp:ListItem>
                                  <asp:ListItem Text="194B" Value="194B"></asp:ListItem>
                                  <asp:ListItem Text="194C" Value="194C"></asp:ListItem>
                                  <asp:ListItem Text="194D" Value="194D"></asp:ListItem>
                                  <asp:ListItem Text="194H" Value="194H"></asp:ListItem>
                                  <asp:ListItem Text="194I" Value="194I"></asp:ListItem>
                                  <asp:ListItem Text="194Ia" Value="194Ia"></asp:ListItem>
                                  <asp:ListItem Text="194Ib" Value="194Ib"></asp:ListItem>
                                  <asp:ListItem Text="194J" Value="194J"></asp:ListItem>
                               </asp:DropDownList>
                        </div>
                    </div>
                       <div id="pop_text_area">
                        <div id="tag_label_adcode">
                             TDS Rate
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_TDS_Rate" runat="server" CssClass="txtbox_none"  Width="80px"
                           onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                 TabIndex="18"></asp:TextBox>
                        </div>
                    </div>

                    <div id="pop_text_area" >
                        <div id="tag_label_adcode">
                            Active
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:DropDownList ID="ddlActive" runat="server" onChange="changetextbox();" CssClass="listtxt_transac_mode_new" TabIndex="19" Width="80px" >
                           <asp:ListItem  Text="YES" Value="YES"></asp:ListItem>
                           <asp:ListItem  Text="NO" Value="NO"></asp:ListItem>
                         </asp:DropDownList>
                        </div>
                    </div>

                       <div id="pop_text_area" style="height:60px;">
                        <div id="tag_label_adcode">
                            Narration</div>
                        <div id="txtcon-m_transaction_mode">
                              <asp:TextBox ID="txt_Narration" runat="server" CssClass="listtxt_transac_mode_new"  height="48px"  Width="220px" TextMode="MultiLine"
                                 TabIndex="20" MaxLength="1000"></asp:TextBox>
                                
                        </div>
                    </div>



                    
            </div>
            <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="25" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" 
                            TabIndex="22" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            TabIndex="22" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="15" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'EXPENSE CHARGE MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="23" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                            tabindex="24" id="btnCancel" />

                        <asp:HiddenField ID="HDupdate_id" runat="server" />
                    </div>
                </div>
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
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
    
    <script type="text/javascript">
        //        $(window).bind("load", function () {
        //            $('#load').hide(); ;
        //        });

        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }

        $(function () {
            $("#txtStateName").autocomplete({
                source: function (request, response) {
                    var errorField = $(this.element).attr('id');
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {


                                jQuery('#txtStateName').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);
                                //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtStateName').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
        $(function () {

            $("#txtIec_Code").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_IECCode_List",
                        data: "{ 'mail': '" + request.term + "' ,'IEC':''}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);

                            if (data.d == '') {
                                jQuery('#txtIec_Code').validationEngine('showPrompt', 'Incorrect IEC Code', 'error', 'topRight', true);
                                //jAlert('IEC Code is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtIec_Code').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtIec_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });


        function Call_Client_Name(src, dest) {
            var ctrl = document.getElementById(src);
            // call server side method
            //alert('l');
            var ieccode = document.getElementById("txtIec_Code").value;
            //if (ieccode.length == 10) {
            PageMethods.GetClient_Name(ctrl.value, CallSuccess, CallFailed, dest);

            //}

        }

        // set the destination textbox value with the ContactName
        function CallSuccess(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            dest.value = res;
        }
        // alert message on some failure
        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }
   

    </script>
</body>
</html>

