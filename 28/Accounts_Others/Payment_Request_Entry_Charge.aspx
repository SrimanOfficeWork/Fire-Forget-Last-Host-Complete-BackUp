<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment_Request_Entry_Charge.aspx.cs"
    Inherits="Accounts_Others_Payment_Request_Entry_Charge" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
        .hideGridColumn
        {
            display: none;
        }
    </style>
    <script language="javascript">


        function Getbtn_Charge() {
            var btn = window.opener.document.getElementById('Btn2');
            btn.click(); // Trigger the button click
        }
    </script>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Trans_new" style="width: 845px; height: 320px;">
                <div id="innerbox_MidMain_top_ClientMaster_left2" style="width: 180px; height: 38px;">
                    Payment Request Charge
                </div>
                <%--<div id="verslic">
                    </div>--%>
                <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice" style="width: 850px;
                    height: 30px; margin-left: 10px; margin-top: -1px;">
                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px;">
                        Reference No
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 200px;">
                        <asp:TextBox ID="txt_BP_R_No_F" runat="server" TabIndex="3" ReadOnly="true" BackColor="#e7e6e6"
                            Width="35px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                        <asp:TextBox ID="txt_BP_R_M" runat="server" TabIndex="3" ReadOnly="true" BackColor="#e7e6e6"
                            Style="text-align: right;" Width="60px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                        <asp:TextBox ID="txt_BP_R_L" runat="server" TabIndex="3" ReadOnly="true" BackColor="#e7e6e6"
                            Width="60px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                    </div>
                    <div id="tag_PartA" runat="server">
                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 40px">
                            LOB
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 120px">
                            <asp:DropDownList ID="ddl_lOB" runat="server" Width="100px" Height="22px" Font-Size="12px"
                                CssClass=" txtbox_trans_exp_drawback" TabIndex="8"  AutoPostBack="True" OnSelectedIndexChanged="ddl_lOB_SelectedIndexChanged">
                                <asp:ListItem Text="CCL IMP" Value="I"></asp:ListItem>
                                <asp:ListItem Text="CCL EXP" Value="E"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 80px">
                            Job No
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px">
                            <asp:DropDownList ID="ddl_Jobno" runat="server" Width="100px" class="chosen-select-deselect"  Height="22px" Font-Size="12px"
                               TabIndex="8" 
                                onchange="showSelectedText();">
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 200px">
                            <asp:Label ID="lblJobnoText" runat="server" Font-Size="14px" Font-Bold="True" 
                                ForeColor="Red" ></asp:Label>
                        </div>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice" style="width: 850px;
                    height: 30px; margin-left: 10px; margin-top: -1px;">
                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                        Charge Name
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 305px;">
                        <asp:DropDownList ID="ddlcharge" runat="server" class="chosen-select-deselect" Style="width: 300px;"
                            data-placeholder="Choose a Charge Name" TabIndex="1">
                        </asp:DropDownList>
                    </div>

                      <div id="tag_label_transaction_popup_IGM_invoice" style="width: 85px">
                        Amount(TC)
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 90px;">
                        <asp:TextBox ID="txtAmount_TC" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                            BackColor="#F5F5F5" Text="0.00" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" ClientIDMode="Static"
                            TabIndex="10" Width="80px"></asp:TextBox>
                    </div>

                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 30px">
                        Curr
                    </div>
                    <div id="txtcon-m_transaction_Inv_No" style="width: 55px">
                        <asp:DropDownList ID="ddl_Cur_Rev" runat="server" Width="50px" Height="22px" Font-Size="12px"
                            CssClass=" txtbox_trans_exp_drawback" TabIndex="8">
                            <asp:ListItem Value="INR"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                      <div id="tag_PartA1"  runat="server">
                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 75px">
                        Amount(HC)
                    </div>
                    <div id="txtcon-m_transaction_Inv_No" style="width: 80px;">
                        <asp:TextBox ID="txt_Amount_HC" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                            BackColor="#F5F5F5" Text="0.00" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" ClientIDMode="Static"
                            TabIndex="10" Width="80px"></asp:TextBox>
                    </div>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice" style="width: 850px;
                    height: 30px; margin-left: 10px;">
                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                        Cost Center
                    </div>
                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px; margin-top: 1px;">
                        <asp:DropDownList ID="ddl_Cost_Center" class="validate[required]  chosen-select-deselect"
                            Style="width: 140px;" data-placeholder="Choose a Cost Center" runat="server"
                            TabIndex="3">
                            <asp:ListItem Text="Admin" Value="AD"></asp:ListItem>
                            <asp:ListItem Text="Bank Charges" Value="BC"></asp:ListItem>
                            <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                            <asp:ListItem Text="Imp" Value="I"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 80px">
                        Payable To
                    </div>
                    <div id="txtcon-m_transaction_Inv_No" style="width: 440px; margin-top: 1px;">
                        <asp:TextBox ID="txtPayable_To" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                            Width="450px" TabIndex="4" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice" style="width: 850px;
                    height: 50px; margin-left: 10px;">
                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                        Remarks
                    </div>
                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px; margin-top: 1px;">
                        <asp:TextBox ID="txtRemarks" CssClass="txtbox_none_Mid_transac_pop_gen_srcic" Width="377px"
                            TabIndex="4" runat="server" Height="35px"></asp:TextBox>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn" style="width: 890px;">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" TabIndex="84" CssClass="new" OnClick="btnNew_Click"
                            OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                            UseSubmitBehavior="false" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" CommandName="s"
                            OnClientClick="return validate();" TabIndex="81" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                            OnClick="btnUpdate_Click" Visible="false" TabIndex="82" OnClientClick="return validation();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="83" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Payment Charge Entry', function(r) {
                  var i = r + 'ok';
                  if(i == 'trueok')
                  {
                      document.getElementById('btn').click();
            
                  }
                  else {
                  }
                    });return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="83" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                </div>
                .</div>
            <div style="display: none;">
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="hfdport_code_origin" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hfdport_code_dest" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                <asp:HiddenField ID="hdn_Update_General" runat="server" />
                <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                <asp:HiddenField ID="hdnImportAirJobLinked" runat="server" />
                <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                <asp:HiddenField ID="hdn_bio_Id" runat="server" />
                <asp:HiddenField ID="hdn_update_Bond" runat="server" />
                <asp:HiddenField ID="hdn_Jobno" runat="server" />
                <asp:HiddenField ID="Hdn_CGHS" runat="server" />
                <asp:HiddenField ID="Hidden_value_Col" runat="server" />
                <asp:HiddenField ID="Hidden_value_Pre" runat="server" />
                <asp:HiddenField ID="HiddenField_index" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/Accounts/Imp_Exp_Invoice_Tab.js"></script>
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
    </form>
</body>
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
<script type="text/javascript">
  
window.onload = function () {
   
   showSelectedText();
};

function showSelectedText() {
   
    document.getElementById('<%= lblJobnoText.ClientID %>').innerText = document.getElementById('ddl_Jobno').value;
}

window.onbeforeunload = function () {
    if (window.opener && !window.opener.closed) {
        window.opener.document.getElementById("Button1").click();
    }
};

</script>


</html>
