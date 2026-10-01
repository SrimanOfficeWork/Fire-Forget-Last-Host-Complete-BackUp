<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Charge_Master.aspx.cs" Inherits="Billing_Charge_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Charge Master | Updation</title>
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
            if (document.getElementById("ddlTax_NonTax").value == "T" || document.getElementById("ddlTax_NonTax").value == "R") {

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
                    INCOME CHARGE MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style=" height:410px;">
                    
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Charge Name</div>
                        <div id="txtcon-m_src">
                            <asp:DropDownList ID="ddl_Charge_Name" runat="server" class="chosen-select-deselect"
                                Style="width: 400px;" data-placeholder="Choose a Ledger Name" TabIndex="2">
                            </asp:DropDownList>
                        </div>
                    </div>

                     <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Group Name
                        </div>
                        <div id="txtcon-m_transaction_mode">
                         <%--  <asp:DropDownList ID="ddl_Group_Name" runat="server" Width="227px" onChange="changetextbox();" 
                         CssClass="validate[required] listtxt_transac_mode_new" TabIndex="3">
                           </asp:DropDownList>--%>

                              <asp:DropDownList ID="ddl_Group_Name" runat="server" class="validate[required] chosen-select-deselect"
                                Style="width: 400px;" data-placeholder="Choose a Group Name" TabIndex="3">
                            </asp:DropDownList>

                        </div>
                    </div>

                       <div id="pop_text_area" style="height:60px;">
                        <div id="tag_label_adcode">
                            Description</div>
                        <div id="txtcon-m_src">
                              <asp:TextBox ID="txtDescription" runat="server" CssClass="listtxt_transac_mode_new"  height="58px"  Width="220px" TextMode="MultiLine"
                                 TabIndex="5" MaxLength="1000"></asp:TextBox>
                                
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Tax / Non-Tax (T/N)
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:DropDownList ID="ddlTax_NonTax" runat="server" Width="227px" onChange="changetextbox();" CssClass="listtxt_transac_mode_new" TabIndex="6">
                           <asp:ListItem  Text="Taxable" Value="T"></asp:ListItem>
                           <asp:ListItem  Text="Non-Taxable" Value="N"></asp:ListItem>
                           <asp:ListItem  Text="Exemption" Value="E"></asp:ListItem>
                           <asp:ListItem  Text="Reimbursement" Value="R"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Nature of Trans.
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlSales_Trans" runat="server" Width="227px" onChange="changetextbox();"
                                CssClass="listtxt_transac_mode_new" TabIndex="7">
                                <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                <asp:ListItem Text="Sales Taxable" Value="Sales Taxable"></asp:ListItem>
                                <asp:ListItem Text="Sales Exempt" Value="Sales Exempt"></asp:ListItem>
                                <asp:ListItem Text="Sales Nil Rate" Value="Sales Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Interstate Sales Taxable" Value="Interstate Sales Taxable"></asp:ListItem>
                                <asp:ListItem Text="Interstate Sales Exempt " Value="Interstate Sales Exempt"></asp:ListItem>
                                <asp:ListItem Text="Interstate Sales Nil Rate" Value="Interstate Sales Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Intrastate Deemed Export Taxable" Value="Intrastate Deemed Export Taxable"></asp:ListItem>
                                <asp:ListItem Text="Intrastate Deemed Export Exempt" Value="Intrastate Deemed Export Exempt"></asp:ListItem>
                                <asp:ListItem Text="Intrastate Deemed Export Nil Rate" Value="Intrastate Deemed Export Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Sales to Consumer - Taxable" Value="Sales to Consumer - Taxable"></asp:ListItem>
                                <asp:ListItem Text="Sales to Consumer- Exempt" Value="Sales to Consumer- Exempt"></asp:ListItem>
                                <asp:ListItem Text="Sales to Consumer - Nil Rate" Value="Sales to Consumer - Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Sales to SEZ - Taxable" Value="Sales to SEZ - Taxable"></asp:ListItem>
                                <asp:ListItem Text="Sales to SEZ -Exempt" Value="Sales to SEZ -Exempt"></asp:ListItem>
                                <asp:ListItem Text="Sales to SEZ -Nil Rate" Value="Sales to SEZ -Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Sales to SEZ - LUT/BOND" Value="Sales to SEZ - LUT/BOND"></asp:ListItem>
                                <asp:ListItem Text="Interstate sales to Embassy / Un Body Taxable" Value="Interstate sales to Embassy / Un Body Taxable"></asp:ListItem>
                                <asp:ListItem Text="Interstate sales to Embassy / Un Body Exempt" Value="Interstate sales to Embassy / Un Body Exempt"></asp:ListItem>
                                <asp:ListItem Text="Interstate sales to Embassy / Un Body Nil Rate" Value="Interstate sales to Embassy / Un Body Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Export Taxable" Value="Export Taxable"></asp:ListItem>
                                <asp:ListItem Text="Export Exempt" Value="Export Exempt"></asp:ListItem>
                                <asp:ListItem Text="Export Nil Rate" Value="Export Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Export  LUT/BOND" Value="Export  LUT/BOND"></asp:ListItem>
                                <asp:ListItem Text="Deemed Export Taxable" Value="Deemed Export Taxable"></asp:ListItem>
                                <asp:ListItem Text="Deemed Export Exempt" Value="Deemed Export Exempt"></asp:ListItem>
                                <asp:ListItem Text="Deemed Export Nil Rate" Value="Deemed Export Nil Rate"></asp:ListItem>
                                <asp:ListItem Text="Branch Transfer OutWard" Value="Branch Transfer OutWard"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            HSN Code
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:TextBox ID="txt_HSN_Code" runat="server" CssClass="txtbox_none" TabIndex="8"></asp:TextBox>
                        </div>
                    </div>
                      <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            SA Code
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:TextBox ID="txt_SA_Code" runat="server" CssClass="txtbox_none" TabIndex="9"></asp:TextBox>
                                 
                        </div>
                    </div>

                    
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                           CGST Rate
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_CGST_Rate" runat="server" CssClass="txtbox_none" Width="60px"
                          onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                 TabIndex="10"></asp:TextBox>

                        </div>
                    </div>

                      <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            SGST Rate
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_SGST_Rate" runat="server" CssClass="txtbox_none" Width="60px" 
                           onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                 TabIndex="11"></asp:TextBox>
                        </div>
                    </div>

                       <div id="pop_text_area">
                        <div id="tag_label_adcode">
                             IGST Rate
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_IGST_Rate" runat="server" CssClass="txtbox_none"  Width="60px"
                           onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                 TabIndex="12"></asp:TextBox>
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
                     <div id="pop_text_area" >
                        <div id="tag_label_adcode">
                            Active / In Active
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:CheckBox ID="chk_Status" runat="server"  TabIndex="15" />
                        </div>
                    </div>
                      <div id="pop_text_area">
                        <div id="tag_label_adcode">
                           Allow Quotation
                        </div>
                        <div id="txtcon-m_transaction_mode">
                         <asp:CheckBox ID="chkQuotation" runat="server"  TabIndex="16" />
                        </div>

                    </div>
                    <div id="pop_text_area"></div>
            </div>
            <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="20" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" 
                            TabIndex="17" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            TabIndex="17" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="18" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'CHARGE MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="18" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                            tabindex="19" id="btnCancel" />

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

