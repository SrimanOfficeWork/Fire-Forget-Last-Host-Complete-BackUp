<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IRN_Autiomation_General.aspx.cs"
    Inherits="IRN_Autiomation_General" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title></title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <style type="text/css">
        /* Make chosen textbox single-line with horizontal scroll */.chosen-container-multi .chosen-choices
        {
            white-space: nowrap;
            overflow-x: auto;
            overflow-y: hidden;
            height: 34px; /* keep it single line */
        }
        /* Keep selected items inline */.chosen-container-multi .chosen-choices li
        {
            display: inline-block;
            float: none;
        }
        /* Prevent wrapping inside items */.chosen-container-multi .chosen-choices li span
        {
            white-space: nowrap;
        }
        
        
        .hideGridColumn
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        
        
        #overlay
        {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(0, 0, 0, 0.5); /* Dark semi-transparent background */
            z-index: 9999; /* Ensure it's on top */
            display: flex;
            justify-content: center;
            align-items: center;
            display: none;
        }
        
        /* Loading Message Container */
        .loading-message
        {
            text-align: center;
            color: white;
        }
        .chosen-container .chosen-results
        {
            max-height: 120px;
            overflow-y: auto;
        }
        
        /* Blurring Effect for the Entire Page */
        .blurred
        {
            filter: blur(5px); /* Apply blur effect */
            pointer-events: none; /* Disable interaction */
        }
    </style>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden">
    <form id="Form1" runat="server" enctype="multipart/form-data">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 1145px;
                height: 220px; background-color: #FFFFFF; margin-top: -2px;">
                <div id="tag_transac_lft_Inv_in1" style="height: 550px; width: 1146px;">
                    <div id="innerbox_MidMain" style="height: 320px;">
                        <div id="tag_srcinner1">
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                                IRN Automation
                            </div>
                            <div id="verslic">
                            </div>
                            <div id="popupwindow_closebut_right">
                                <input type="button" value="Submit" class="clsicon" onclick="
    var isSaved = document.getElementById('hdn_saved').value;
    var isGrid = document.getElementById('hdn_Grid').value;
    var jobno = document.getElementById('txt_Jobno') ? document.getElementById('txt_Jobno').value : '';
   if (isSaved === 'N') {
        var btnDelete = document.getElementById('<%= btndelefileclose.ClientID %>');
        if (btnDelete) {
            btnDelete.click();
        }
    }
    if (parent && parent.document.getElementById('btnSearch')) {
        parent.document.getElementById('btnSearch').click();
    }

    parent.adcodewindow.hide();
    return false;
" />
                            </div>
                        </div>
                        <div id="tag_transact_src_inner" style="width: 1130px; height: 184px;">
                            <div id="tag_Exchange_inner_lft" style="width: 1155px; height: 30px;">
                                <div id="tag_label_transact_Src" style="width: 110px; margin-top: 3px;">
                                    Icegate user Id
                                </div>
                                <div id="txtcon-m_transaction_Inv_No" style="width: 185px;">
                                    <asp:DropDownList ID="ddlIcegateId" runat="server" MaxLength="50" Width="175px" Height="22px"
                                        TabIndex="1" Font-Size="12px" onchange="onIcegateChange();">
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 70px; margin-top: 3px;">
                                    Mail Type
                                </div>
                                <div id="txtcon-m_transaction_Inv_No" style="width: 100px;">
                                    <asp:DropDownList ID="ddlmailtype" runat="server" MaxLength="50" Width="90px" Height="22px"
                                        TabIndex="2" Font-Size="12px" onchange="onMailTypeChange();">
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 85px; margin-top: 3px;">
                                    Mail user id
                                </div>
                                <div id="txtcon-m_transaction_Inv_No" style="width: 300px;">
                                    <asp:DropDownList ID="ddlmailid" runat="server" MaxLength="50" Width="290px" Height="22px"
                                        onchange="onMailIdChange();" TabIndex="3" Font-Size="12px">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtmailhost" runat="server" TabIndex="2" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                        MaxLength="17" Width="280px" Height="22px" Style="display: none"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 100px; margin-top: 3px;">
                                    Mobile number
                                </div>
                                <div id="txtcon-m_transaction_Inv_No" style="width: 190px;">
                                    <asp:TextBox ID="txtmobilno" runat="server" TabIndex="4" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                        MaxLength="17" Width="170px" Height="22px"></asp:TextBox>
                                    <asp:TextBox ID="txtmailport" runat="server" TabIndex="4" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                        MaxLength="12" Width="27px" Height="22px" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="txtmailssl" runat="server" TabIndex="3" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                        MaxLength="100" Width="35px" Height="22px" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="txtmailpass" runat="server" TabIndex="2" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                        MaxLength="100" Width="92px" Height="22px" Style="display: none"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_Exchange_inner_lft" style="margin-top: 1px; margin-right: 100px; width: 1130px">
                                <div id="tag_label_transact_Src" style="width: 550px; margin-top: 3px;">
                                    Doc Name split by
                                </div>
                                <div id="txtcon-m_transaction_Inv_No" style="width: 440px; position: absolute; margin-left: 110px;">
                                    <asp:ListBox ID="ListBox_doc_name" runat="server" SelectionMode="Multiple" CssClass="chosen-select"
                                        TabIndex="5" Width="435px">
                                        <asp:ListItem Value="Job_No">Job_No</asp:ListItem>
                                        <asp:ListItem Value="Job_Type">Job_Type</asp:ListItem>
                                        <asp:ListItem Value="Invoice_sl">Invoice_sl</asp:ListItem>
                                        <asp:ListItem Value="Item_sl">Item_sl</asp:ListItem>
                                        <asp:ListItem Value="Doc_code">Doc_code</asp:ListItem>
                                    </asp:ListBox>
                                </div>
                                <div id="tag_Exchange_inner_lft" style="width: 230px">
                                    <input type="file" id="fileInput" name="fileInput" multiple="multiple" />
                                </div>
                                <div id="tag_Exchange_inner_lft" style="width: 80px">
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click"
                                        Style="margin-top: 0px; margin-left: 15px;" />
                                </div>
                                <asp:TextBox ID="txttransid" runat="server" TabIndex="2" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    MaxLength="17" Width="260px" Height="22px" Style="display: none"></asp:TextBox>
                            </div>
                            <fieldset style="border: Black; border-style: double; margin-left: 0px; margin-top: 10px;
                                width: 1133px; height: 190px; margin-left: -8px;">
                                <legend style="border: Black; boont-weight: bold; background-color: Scrollbar; color: Teal;">
                                    Individual Field to Update Multiple Rows </legend>
                                <div id="tag_Exchange_inner_lft" style="height: 24px; width: 1110px; margin-left: 25px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 115px; font-weight: bold;">
                                        Jobno
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 40px; font-weight: bold;">
                                        J.Typ
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 41px; font-weight: bold;">
                                        Inv.Sl
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 40px; font-weight: bold;">
                                        Itm.Sl
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; margin-left: 3px;
                                        font-weight: bold;">
                                        Doc.Code
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                                        Doc Level
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 147px; font-weight: bold;">
                                        Doc. No
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 100px; font-weight: bold;">
                                        Issue Date
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 130px; font-weight: bold;">
                                        Place of Issue
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 165px; font-weight: bold;">
                                        Iss.Party Name
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 114px; font-weight: bold;">
                                        Iss.Party Add1
                                    </div>
                                </div>
                                <div id="tag_Exchange_inner_lft" style="height: 27px; width: 1134px; margin-left: 1px;
                                    margin-top: 1px;">
                                    <div id="editbu" style="width: 21px; margin-top: 4px;">
                                        <asp:ImageButton ID="btnclr" runat="server" Height="19px" Width="18px" ToolTip="Clear Text"
                                            OnClientClick="return btnclr_Click();" ImageUrl="~/images/icons/delete-sign.png" />
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 115px;">
                                        <asp:TextBox ID="txtJobnoall" runat="server" onkeyup="autotab(this);" onchange="loadjoball();"
                                            TabIndex="6" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px"
                                            Width="100px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 40px;">
                                        <asp:TextBox ID="txtjobtypeall" runat="server" onkeyup="autotab(this);" TabIndex="7"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px" Width="29px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 41px;">
                                        <asp:TextBox ID="txtinvslall" runat="server" onkeyup="autotab(this);" TabIndex="8"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px" Width="29px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 41px;">
                                        <asp:TextBox ID="txtitmslall" runat="server" onkeyup="autotab(this);" TabIndex="9"
                                            onchange="loadImp_Exp_all();" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17"
                                            Height="21px" Width="29px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                                        <asp:TextBox ID="txt_DocTypeCode_all" runat="server" onkeyup="autotab(this);" onchange="loaddoccodeall(this)"
                                            TabIndex="10" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="16" Height="21px"
                                            Width="75px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px;">
                                        <asp:TextBox ID="txtdoclevall" runat="server" onkeyup="autotab(this);" TabIndex="11"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px" Width="75px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 148px;">
                                        <asp:TextBox ID="txt_DocNo_all" runat="server" onkeyup="autotab(this);" Width="134px"
                                            TabIndex="12" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 98px;">
                                        <asp:TextBox ID="txt_IssueDate_all" runat="server" onkeyup="autotab(this);" Width="85px"
                                            TabIndex="13" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_IssueDate_all"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_IssueDate_all"
                                            PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 130px;">
                                        <asp:TextBox ID="txt_PlaceIssue_all" runat="server" onkeyup="autotab(this);" TabIndex="14"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px" Width="115px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 165px;">
                                        <asp:TextBox ID="txt_IssParty_all" runat="server" onkeyup="autotab(this);" TabIndex="15"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Width="150px" Height="21px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 150px;">
                                        <asp:TextBox ID="txt_IssParty_add1_all" runat="server" onkeyup="autotab(this);" TabIndex="16"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px" Width="146px"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_Exchange_inner_lft" style="height: 24px; width: 1110px; margin-left: 25px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 133px; font-weight: bold;">
                                        Iss.Add2
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 140px; font-weight: bold;">
                                        Iss.Add3
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 104px; margin-left: 3px;
                                        font-weight: bold;">
                                        Iss.Add4
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 160px; font-weight: bold;">
                                        Ben.Party Name
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 160px; font-weight: bold;">
                                        Ben.Add1
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 160px; font-weight: bold;">
                                        Ben.Add2
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 160px; font-weight: bold;">
                                        Ben.Add3
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 90px; font-weight: bold;">
                                        Ben.Add4
                                    </div>
                                </div>
                                <div id="tag_Exchange_inner_lft" style="height: 27px; width: 1128px; margin-left: 8px;
                                    margin-top: 1px;">
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 145px;">
                                        <asp:TextBox ID="txt_IssParty_add2_all" runat="server" onkeyup="autotab(this);" TabIndex="17"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px" Width="130px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 145px;">
                                        <asp:TextBox ID="txt_IssParty_add3_all" runat="server" onkeyup="autotab(this);" TabIndex="18"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px" Width="130px"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 100px;">
                                        <asp:TextBox ID="txt_IssParty_add4_all" runat="server" onkeyup="autotab(this);" TabIndex="19"
                                            CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17" Height="21px" Width="87px"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 161px;">
                                        <asp:TextBox ID="txt_BenParty_all" runat="server" onkeyup="autotab(this);" Width="150px"
                                            TabIndex="20" CssClass="txtbox_none_Mid_transac_code" MaxLength="17" Height="21px"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 161px;">
                                        <asp:TextBox ID="txt_BenParty_add1_all" runat="server" onkeyup="autotab(this);" Width="146px"
                                            TabIndex="21" CssClass="txtbox_none_Mid_transac_code" MaxLength="17" Height="21px"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 161px;">
                                        <asp:TextBox ID="txt_BenParty_add2_all" runat="server" onkeyup="autotab(this);" Width="146px"
                                            TabIndex="22" CssClass="txtbox_none_Mid_transac_code" MaxLength="17" Height="21px"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 158px;">
                                        <asp:TextBox ID="txt_BenParty_add3_all" runat="server" onkeyup="autotab(this);" Width="146px"
                                            TabIndex="23" CssClass="txtbox_none_Mid_transac_code" MaxLength="17" Height="21px"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 94px;">
                                        <asp:TextBox ID="txt_BenParty_add4_all" runat="server" onkeyup="autotab(this);" Width="87px"
                                            TabIndex="24" CssClass="txtbox_none_Mid_transac_code" MaxLength="17" Height="21px"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_Exchange_inner_lft" style="height: 30px; width: 1116px; margin-left: 20px;
                                    margin-top: 21px">
                                    <div id="txtcon-m_transaction_Supp_code" style="width: 95px; font-weight: bold;">
                                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                                            <asp:Button ID="btn_bulk_Update_All" runat="server" CssClass="autowidmovebut" OnClientClick="return applyallclick();"
                                                CausesValidation="false" UseSubmitBehavior="false" Text="Apply to All" TabIndex="26"
                                                Width="90px" Height="30px" Style="margin-top: -4px" />
                                        </div>
                                    </div>
                                    <div id="innerbox_MidMain_bot_transact_invoice" style="width: 1000px; height: 32px;
                                        margin-top: -5px;">
                                        <div id="newbu" style="display: none">
                                            <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="26" OnClick="btnNew_Click"
                                                CausesValidation="false" UseSubmitBehavior="false" />
                                        </div>
                                        <div id="editbu">
                                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                                OnClick="btnSave_Click" TabIndex="27" Style="display: none" />
                                        </div>
                                        <div id="editbu">
                                            <asp:Button ID="btndelefileclose" runat="server" CssClass="save" OnClientClick="return validate();"
                                                OnClick="btndeletefileclose_Click" TabIndex="28" Style="display: none" />
                                        </div>
                                        <div id="editbu">
                                            <asp:Button ID="btnDelete" runat="server" TabIndex="29" CausesValidation="false"
                                                Visible="false" UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job?', 'IRN Details', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                            <asp:Button ID="btn" runat="server" TabIndex="30" CausesValidation="false" UseSubmitBehavior="false"
                                                CssClass="dlete" Style="display: none;" OnClick="btnDelete_Click" />
                                        </div>
                                        <div id="editbu">
                                            <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                                                tabindex="30" id="btn_cancel" />
                                        </div>
                                        <div id="editbu" style="width: 104px;">
                                            <asp:Button ID="btnbulksave" runat="server" CssClass="autowidmovebut" CausesValidation="false"
                                                UseSubmitBehavior="false" Text="Bulk Save" Style="width: 100px" TabIndex="31"
                                                OnClick="btnbulksave_Click" />
                                        </div>
                                        <div id="editbu">
                                            <asp:Button ID="btnGenIRN" runat="server" CssClass="autowidmovebut" CausesValidation="false"
                                                UseSubmitBehavior="false" Text="Generate IRN" Style="width: 100px" TabIndex="31"
                                                OnClick="btnGenIRN_Click" />
                                        </div>
                                        <asp:TextBox ID="txttenetid" runat="server" TabIndex="2" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            MaxLength="50" Width="180px" Height="22px" Style="display: none"></asp:TextBox>
                                        <asp:TextBox ID="txtclientid" runat="server" TabIndex="2" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            MaxLength="50" Width="180px" Height="22px" Style="display: none"></asp:TextBox>
                                        <asp:TextBox ID="txtscreenid" runat="server" TabIndex="2" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            MaxLength="50" Width="180px" Height="22px" Style="display: none"></asp:TextBox>
                                    </div>
                                </div>
                            </fieldset>
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Grid" style="height: 346px; margin-top: -13px; width: 1144px;">
                        <asp:GridView ID="gv_Details" runat="server" AllowSorting="false" EmptyDataText="No Record Found"
                            PageSize="2" AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8"
                            BorderStyle="none" ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                            CssClass="grid-view" AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True"
                            OnRowDataBound="gv_Details_RowDataBound" ShowHeader="true" OnRowCreated="gv_Details_RowCreated"
                            Style="height: 342px; width: 1144px; overflow: scroll; display: block;">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkSelectAll" runat="server" onclick="CheckAll(this)" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="44px" HeaderText="S.No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblitemslno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="44px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status" HeaderStyle-Font-Bold="true" HeaderStyle-Width="180px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtstatus" runat="server" Text='<%# Bind("IRN_STATUS") %>' Style="width: 80px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="210px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="250px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtJobno" runat="server" CssClass="jobno-autocomplete" Text='<%# Bind("Jobno") %>'
                                            onblur="loadjob(this);" onchange="loadjob(this)" Style="width: 150px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="280px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Typ" HeaderStyle-Font-Bold="true" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtJobType" runat="server" Text='<%# Bind("JobType") %>' Style="width: 18px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="50px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="In.sl" HeaderStyle-Font-Bold="true" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_InvSlno" runat="server" Text='<%# Bind("INV_SL") %>' Style="width: 18px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="50px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="It.Sl" HeaderStyle-Font-Bold="true" HeaderStyle-Width="25px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtItemSlNo" runat="server" Text='<%# Bind("ITEM_SL") %>' Style="width: 18px;"
                                            onblur="loadImp_Exp(this);" onchange="loadImp_Exp(this);"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="50px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Documents" HeaderStyle-Font-Bold="true" HeaderStyle-Width="250px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtFileName" runat="server" Text='<%# Bind("DOC_FILE_NAME") %>'
                                            Style="width: 200px;" ReadOnly="true"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="280px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Doc Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtDoc_Code" runat="server" Text='<%# Bind("DOC_TYPE") %>' CssClass="doctype-autocomplete"
                                            onblur="loaddoccode(this);" onchange="loaddoccode(this)" Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Level" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtlevel" runat="server" Text='<%# Bind("DOC_LEVEL") %>' Style="width: 60px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="120px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Doc. No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="220px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_Doc_No" runat="server" Text='<%# Bind("DRN") %>' Style="width: 120px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="250px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="IRN No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="220px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIRNno" runat="server" Text='<%# Bind("IRN") %>' Style="width: 120px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="250px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Iss.Party Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIss_PartyName" runat="server" Text='<%# Bind("DOC_ISSUING_PARTY_NAME") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Iss.Party Add" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIss_PartyNameadd1" runat="server" Text='<%# Bind("EXPORTER_ADDRESS1") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Iss.Party Add2" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIss_PartyNameadd2" runat="server" Text='<%# Bind("EXPORTER_ADDRESS2") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Iss.Party Add3" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIss_PartyNameadd3" runat="server" Text='<%# Bind("EXPORTER_ADDRESS3") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Iss.Party Add4" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIss_PartyNameadd4" runat="server" Text='<%# Bind("EXPORTER_ADDRESS5") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Place of Issue" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPlace_Of_Issue" runat="server" Text='<%# Bind("PLACE_OF_ISSUE") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Issue Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtIssue_Date" runat="server" onkeypress="return AllowAlphabet(event)"
                                            onblur="ChangeCase(this);" Text='<%# Bind("DOC_ISSUE_DATE") %>' Style="width: 80px;"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtIssue_Date"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIssue_Date"
                                            PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ben.Party Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtBenPartyName" runat="server" Text='<%# Bind("BENEFICIARY_PARTY_NAME") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ben.Party Add" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtBenPartyNameadd1" runat="server" Text='<%# Bind("CONSIGNEE_ADD1") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ben.Party Add2" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtBenPartyNameadd2" runat="server" Text='<%# Bind("CONSIGNEE_ADD2") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ben.Party Add3" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtBenPartyNameadd3" runat="server" Text='<%# Bind("CONSIGNEE_ADD3") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ben.Party Add4" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtBenPartyNameadd4" runat="server" Text='<%# Bind("CONSIGNEE_ADD5") %>'
                                            Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtUser" runat="server" Text='<%# Bind("User") %>' Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" CssClass="hideGridColumn" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" CssClass="hideGridColumn" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Guidid" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGuidid" runat="server" Text='<%# Bind("Guidid") %>' Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" CssClass="hideGridColumn" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" CssClass="hideGridColumn" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SLID" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtslid" runat="server" Text='<%# Bind("SL_NO") %>' Style="width: 200px;"></asp:TextBox>
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="True" Width="120px" CssClass="hideGridColumn" />
                                    <ItemStyle Width="330px" HorizontalAlign="center" Font-Size="12px" CssClass="hideGridColumn" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            </div>
            <%-- </div>--%>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
            <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
                BackgroundCssClass="modalBackground" DropShadow="false">
            </asp:ModalPopupExtender>
            <asp:HiddenField ID="HDU_JOB" runat="server" />
            <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
                BorderColor="Transparent">
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 600px; height: 180px;
                    overflow: auto;">
                    <asp:GridView ID="gv_Inv_Item" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                        OnRowCreated="gv_RITC_RowCreated">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <SelectedRowStyle Font-Bold="true" />
                        <Columns>
                            <asp:BoundField DataField="Error" HeaderText="Error" HeaderStyle-Width="0%">
                                <ItemStyle CssClass="column_style_left5" Width="20%" ForeColor="Red" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Jobno" HeaderText="Jobno" HeaderStyle-Width="0%">
                                <ItemStyle CssClass="column_style_left5" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="JobType" HeaderText="JobType" HeaderStyle-Width="0%">
                                <ItemStyle CssClass="column_style_left5" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INV_SLNO" HeaderText="Inv. SlNo" HeaderStyle-Width="6%">
                                <ItemStyle CssClass="column_style_left5" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ITM_SLNO" HeaderText="Item SlNo" HeaderStyle-Width="6%">
                                <ItemStyle CssClass="column_style_left5" Width="10%" ForeColor="Red" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IRN" HeaderText="IRN" HeaderStyle-Width="22%">
                                <ItemStyle CssClass="column_style_left5" Width="15%" ForeColor="Red" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Doc_Code" HeaderText="Doc Code" HeaderStyle-Width="52%">
                                <ItemStyle CssClass="column_style_left5" Width="52%" ForeColor="Red" Font-Bold="true" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 600px; height: 30px;">
                    <div style="margin-left: 280px;">
                        <asp:Button ID="btnok" runat="server" Text="Ok" OnClick="btnok_Click" /></div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    <div style="display: none;">
        <asp:HiddenField ID="HiddenField_index" runat="server" />
        <asp:HiddenField ID="hfDdlClientValue" runat="server" />
        <asp:HiddenField ID="hfJobnoValue" runat="server" />
        <asp:HiddenField ID="hdn_saved" runat="server" />
        <asp:HiddenField ID="hdn_Grid" runat="server" />
        <asp:HiddenField ID="hfAlertMsg" runat="server" />
        <asp:HiddenField ID="hdn_path_check" runat="server" />
        <asp:HiddenField ID="hdn_mailtype" runat="server" />
        <asp:HiddenField ID="hdn_mailid" runat="server" />
        <asp:HiddenField ID="hdn_icegate_user" runat="server" />
        <asp:HiddenField ID="hdn_icegate_pass" runat="server" />
    </div>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/Accounts/Imp_Exp_Invoice_Tab.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
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
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });
        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {
                return options.allrules.validate2fields.alertText;
            }
        }
    </script>
    <script type="text/javascript">
        
       $(document).ready(function () {
    $('.chosen-select').chosen({
        width: "425px",
        placeholder_text_multiple: "Select fields"
    });
});
 

        $(function () {
            $(".doctype-autocomplete").autocomplete({

                source: function (request, response) {

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Supporting_Docs",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                //                                jQuery('#txtRITCNo').validationEngine('showPrompt', 'Invalid RITC', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_Doc_Type_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });

        $(function () {
            $(".jobno-autocomplete").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Jobno_Imp_Exp_List",
                        data: "{ 'Jobno': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtJobno').validationEngine('showPrompt', 'Incorrect Jobno', 'error', 'topRight', true);

                            }
                            else {
                                jQuery('#txtJobno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });



             $("#<%= txtJobnoall.ClientID %>").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Jobno_Imp_Exp_List",
            data: "{ 'Jobno': '" + request.term + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                response(data.d);
            }
        });
    },
    minLength: 1,
    select: function (event, ui) {
        $(this).val(ui.item.value);
        loadjoball();
        return false;
    }
});


 $("#<%= txt_DocTypeCode_all.ClientID %>").autocomplete({
    source: function (request, response) {
        $.ajax({
            url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Supporting_Docs",
            data: "{ 'mail': '" + request.term + "' }",
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                response(data.d);
            }
        });
    },
    minLength: 1,
    select: function (event, ui) {
        $(this).val(ui.item.value);
        loaddoccodeall();
        return false;
    }
});



        function CheckAll(headerCheckBox) {
            var grid = document.getElementById('<%= gv_Details.ClientID %>');
            var inputs = grid.getElementsByTagName("input");

            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox" && inputs[i].id.indexOf("chkSelect") >= 0) {
                    inputs[i].checked = headerCheckBox.checked;
                }
            }
        }
        function loadjob(txtJob) {
            var row = txtJob.closest("tr");
            var jobNo = row.querySelector("[id*='txtJobno']").value;
            if (!jobNo || jobNo.indexOf('-') === -1) {
                return; 
            }
            var parts = jobNo.split('-');
            row.querySelector("[id*='txtJobno']").value = parts[0].trim();
            var jobTypeBox = row.querySelector("[id*='txtJobType']");
            if (parts[1].trim().toLowerCase() === "import") {
                jobTypeBox.value = "I";
            } else {
                jobTypeBox.value = "E";
            }
        }


        function loadjoball(txtJob) {

    var jobNoInput = document.getElementById("<%= txtJobnoall.ClientID %>");
   

    var jobNo = jobNoInput ? jobNoInput.value.trim() : "";
    if (!jobNo || jobNo.indexOf('-') === -1) {
        return;
    }

    var parts = jobNo.split('-');
    jobNoInput.value =parts[0];
    var jobTypeBox = document.getElementById("<%= txtjobtypeall.ClientID %>");
    if (!jobTypeBox) return;
    if (parts[1].trim().toLowerCase() === "import") {
        jobTypeBox.value = "I";
    } else {
        jobTypeBox.value = "E";
    }
}



function loadImp_Exp_all() {

    var jobNoInput = document.getElementById("<%= txtJobnoall.ClientID %>");
    var invslBox   = document.getElementById("<%= txtinvslall.ClientID %>");
    var itmslBox   = document.getElementById("<%= txtitmslall.ClientID %>");
    var jobtype  = document.getElementById("<%= txtjobtypeall.ClientID %>");


    var imp = document.getElementById("txt_IssParty_all");
    var imp_add1 = document.getElementById("txt_IssParty_add1_all");
    var imp_add2 = document.getElementById("txt_IssParty_add2_all");
    var imp_add3 = document.getElementById("txt_IssParty_add3_all");
     var imp_add4 = document.getElementById("txt_IssParty_add4_all");

     var exp = document.getElementById("txt_BenParty_all");
    var exp_add1 = document.getElementById("txt_BenParty_add1_all");
    var exp_add2 = document.getElementById("txt_BenParty_add2_all");
    var exp_add3 = document.getElementById("txt_BenParty_add3_all");
     var exp_add4 = document.getElementById("txt_BenParty_add4_all");

    var poi = document.getElementById("txt_PlaceIssue_all");
    var doi = document.getElementById("txt_IssueDate_all");






    var jobNo = jobNoInput ? jobNoInput.value.trim() : "";
    var invsl = invslBox ? invslBox.value.trim() : "";
    var itmsl = itmslBox ? itmslBox.value.trim() : "";
    var jobtyp = jobtype ? jobtype.value.trim() : "";
 

    if (!jobNo) return;


    PageMethods.Get_imp_exp(jobNo, invsl, itmsl,jobtyp,
        function (res) {
            if (!res) return;

            var result = res.split('~');

            imp.value = result[0] || "";

            imp_add1.value = (result[1] || "").substring(0, 70);
            imp_add2.value = (result[2] || "").substring(0, 70);
            imp_add3.value = (result[3] || "").substring(0, 35);

             imp_add4.value = (result[4] || "").substring(0, 10);
            exp.value = result[5] || "";
            exp_add1.value = (result[6] || "").substring(0, 70);
            exp_add2.value = (result[7] || "").substring(0, 70);


             exp_add3.value = (result[8] || "").substring(0, 35);
            exp_add4.value = (result[9] || "").substring(0, 10);
            poi.value = result[10] || "";
            doi.value = result[11] || "";



        },
        function (err) {
            console.log("Error:", err.get_message());
        }
    );
}



     function loadImp_Exp(ctrl) {

    if (!ctrl) return;

    var row = ctrl.closest("tr");
    if (!row) return;

    var jobBox  = row.querySelector("[id*='txtJobno']");
    var itmBox  = row.querySelector("[id*='txtItemSlNo']");
    var invBox  = row.querySelector("[id*='txt_InvSlno']");
     var jotyp  = row.querySelector("[id*='txtJobType']");
  

    var partyRow = row.querySelector("[id*='txtIss_PartyName']");
    var partyRow1   = row.querySelector("[id*='txtIss_PartyNameadd1']");
    var partyRow2 = row.querySelector("[id*='txtIss_PartyNameadd2']");
      var partyRow3  = row.querySelector("[id*='txtIss_PartyNameadd3']");


      var partyRow4 = row.querySelector("[id*='txtIss_PartyNameadd4']");
    var benRow   = row.querySelector("[id*='txtBenPartyName']");
    var benRow1 = row.querySelector("[id*='txtBenPartyNameadd1']");
      var benRow2  = row.querySelector("[id*='txtBenPartyNameadd2']");


      var benRow3 = row.querySelector("[id*='txtBenPartyNameadd3']");
    var benRow4   = row.querySelector("[id*='txtBenPartyNameadd4']");
    var placeRow = row.querySelector("[id*='txtPlace_Of_Issue']");
      var doiRow  = row.querySelector("[id*='txtIssue_Date']");



    var jobNo  = jobBox ? jobBox.value.trim() : "";
    var invrow = invBox ? invBox.value.trim() : "";
    var itmrow = itmBox ? itmBox.value.trim() : "";
     var jobtype = jotyp ? jotyp.value.trim() : "";


    if (!jobNo) return;

    PageMethods.Get_imp_exp(jobNo, invrow, itmrow,jobtype,
        function (res) {
            if (!res) return;
            var result = res.split('~');

            if (partyRow) partyRow.value = result[0] || "";
            if (partyRow1)   partyRow1.value   =  (result[1] || "").substring(0, 70);
            if (partyRow2) partyRow2.value = (result[2] || "").substring(0, 70);
             if (partyRow3) partyRow3.value = (result[3] || "").substring(0, 35);

             if (partyRow4) partyRow4.value = (result[4] || "").substring(0, 10);
            if (benRow)   benRow.value   = result[5] || "";
            if (benRow1) benRow1.value = (result[6] || "").substring(0, 70);
             if (benRow2) benRow2.value = (result[7] || "").substring(0, 70);


             if (benRow3) benRow3.value = (result[8] || "").substring(0, 35);
            if (benRow4)   benRow4.value   = (result[9] || "").substring(0, 10);
            if (placeRow) placeRow.value = result[10] || "";
             if (doiRow) doiRow.value = result[11] || "";


        },
        function (err) {
            console.log(err.get_message());
        }
    );
}


        function loaddoccode(txtdoccode) {

            var row = txtdoccode.closest("tr");
            if (!row) return;

            var doccodeBox = row.querySelector("[id*='txtDoc_Code']");
            var levelBox = row.querySelector("[id*='txtlevel']");

            if (!doccodeBox || !levelBox) return;

            var doccode = doccodeBox.value;
            if (!doccode || doccode.trim() === "") return; 

            doccode = doccode.trim();
            if (doccode.indexOf('_') !== -1) {
                var parts = doccode.split('_');
                doccode = parts[1].trim();
                doccodeBox.value = doccode;
            }
            PageMethods.Get_Doc_type_level(doccode, function (res) {
                levelBox.value = res;
            });
        }
         

        function loaddoccodeall(txtdoccode) {

    var doccodeBox = document.getElementById("txt_DocTypeCode_all");
    var levelBox = document.getElementById("txtdoclevall");

    if (!doccodeBox || !levelBox) return;

    var doccode = doccodeBox.value.trim();

    if (!doccode || doccode.indexOf('_') === -1) {
        return;
    }

    var parts = doccode.split('_');
    var finalDocCode = parts[1].trim();

    doccodeBox.value = finalDocCode;

    PageMethods.Get_Doc_type_level(finalDocCode, function (res) {
        levelBox.value = res;
    });
}


function applyallclick() {

    // Read header values ONCE
    var jobnoVal = document.getElementById("<%= txtJobnoall.ClientID %>")?.value.trim() || "";
    var doccodeVal = document.getElementById("<%= txt_DocTypeCode_all.ClientID %>")?.value.trim() || "";
    var docnoVal = document.getElementById("<%= txt_DocNo_all.ClientID %>")?.value.trim() || "";
    var partyVal = document.getElementById("<%= txt_IssParty_all.ClientID %>")?.value.trim() || "";
    var partyVal1 = document.getElementById("<%= txt_IssParty_add1_all.ClientID %>")?.value.trim() || "";
    var partyVal2 = document.getElementById("<%= txt_IssParty_add2_all.ClientID %>")?.value.trim() || "";
    var partyVal3 = document.getElementById("<%= txt_IssParty_add3_all.ClientID %>")?.value.trim() || "";
    var partyVal4 = document.getElementById("<%= txt_IssParty_add4_all.ClientID %>")?.value.trim() || "";
    var placeVal = document.getElementById("<%= txt_PlaceIssue_all.ClientID %>")?.value.trim() || "";
    var benPartyVal = document.getElementById("<%= txt_BenParty_all.ClientID %>")?.value.trim() || "";
    var benPartyVal1 = document.getElementById("<%= txt_BenParty_add1_all.ClientID %>")?.value.trim() || "";
    var benPartyVal2 = document.getElementById("<%= txt_BenParty_add2_all.ClientID %>")?.value.trim() || "";
    var benPartyVal3 = document.getElementById("<%= txt_BenParty_add3_all.ClientID %>")?.value.trim() || "";
    var benPartyVal4 = document.getElementById("<%= txt_BenParty_add4_all.ClientID %>")?.value.trim() || "";
    var issueDateVal = document.getElementById("<%= txt_IssueDate_all.ClientID %>")?.value.trim() || "";
     var jobtypeVal = document.getElementById("<%= txtjobtypeall.ClientID %>")?.value.trim() || "";
      var invslVal = document.getElementById("<%= txtinvslall.ClientID %>")?.value.trim() || "";
       var itmslVal = document.getElementById("<%= txtitmslall.ClientID %>")?.value.trim() || "";
        var doclvlVal = document.getElementById("<%= txtdoclevall.ClientID %>")?.value.trim() || "";

    var grid = document.getElementById("<%= gv_Details.ClientID %>");
    if (!grid) return false;

    var checkboxes = grid.querySelectorAll("input[type='checkbox'][id*='chkSelect']");
    var anyChecked = false;
    for (var i = 0; i < checkboxes.length; i++) {

        if (!checkboxes[i].checked) continue;

        anyChecked = true;
        var row = checkboxes[i].closest("tr");
        var jobnoRow  = row.querySelector("[id*='txtJobno']");
        var doccodeRow= row.querySelector("[id*='txtDoc_Code']");
        var docnoRow  = row.querySelector("[id*='txt_Doc_No']");
        var partyRow  = row.querySelector("[id*='txtIss_PartyName']");
          var partyRow1  = row.querySelector("[id*='txtIss_PartyNameadd1']");
            var partyRow2  = row.querySelector("[id*='txtIss_PartyNameadd2']");
              var partyRow3  = row.querySelector("[id*='txtIss_PartyNameadd3']");
                var partyRow4  = row.querySelector("[id*='txtIss_PartyNameadd4']");
        var placeRow  = row.querySelector("[id*='txtPlace_Of_Issue']");
        var benRow    = row.querySelector("[id*='txtBenPartyName']");
        var benRow1    = row.querySelector("[id*='txtBenPartyNameadd1']");
        var benRow2    = row.querySelector("[id*='txtBenPartyNameadd2']");
        var benRow3    = row.querySelector("[id*='txtBenPartyNameadd3']");
        var benRow4    = row.querySelector("[id*='txtBenPartyNameadd4']");
        var issueRow  = row.querySelector("[id*='txtIssue_Date']");

         var jbtypRow  = row.querySelector("[id*='txtJobType']");
          var invslRow  = row.querySelector("[id*='txt_InvSlno']");
           var itmslRow  = row.querySelector("[id*='txtItemSlNo']");
            var doclevelRow  = row.querySelector("[id*='txtlevel']");




        if (jobnoVal && jobnoRow) {
            jobnoRow.value = jobnoVal;
            //loadjob(jobnoRow);
        }
        if (jobtypeVal && jbtypRow) {
            jbtypRow.value = jobtypeVal;
        }

      if (invslVal && invslRow) {
            invslRow.value = invslVal;
        }

       if (itmslVal  && itmslRow) {
            itmslRow.value = itmslVal;
        }

        if (doclvlVal   && doclevelRow) {
            doclevelRow.value = doclvlVal;
        }

        if (doccodeVal && doccodeRow) {
            doccodeRow.value = doccodeVal;
            //loaddoccode(doccodeRow);
        }

        if (docnoVal && docnoRow) {
            docnoRow.value = docnoVal;
        }

        if (partyVal1 && partyRow1) {
            partyRow1.value = partyVal1;
        }

         if (partyVal2 && partyRow2) {
            partyRow2.value = partyVal2;
        }

         if (partyVal3 && partyRow3) {
            partyRow3.value = partyVal3;
        }

         if (partyVal4 && partyRow4) {
            partyRow4.value = partyVal4;
        }

         if (partyVal && partyRow) {
            partyRow.value = partyVal;
        }


        if (placeVal && placeRow) {
            placeRow.value = placeVal;
        }

        if (benPartyVal && benRow) {
            benRow.value = benPartyVal;
        }

         if (benPartyVal1 && benRow1) {
            benRow1.value = benPartyVal1;
        }

         if (benPartyVal2 && benRow2) {
            benRow2.value = benPartyVal2;
        }

         if (benPartyVal3 && benRow3) {
            benRow3.value = benPartyVal3;
        }

         if (benPartyVal4 && benRow4) {
            benRow4.value = benPartyVal4;
        }

        if (issueDateVal && issueRow) {
            issueRow.value = issueDateVal;
        }
    }

    if (!anyChecked) {
        alert("Please select at least one row");
        return false;
    }

    return true;
}
function btnclr_Click() {

    document.getElementById('<%= txtJobnoall.ClientID %>').value = '';
    document.getElementById('<%= txtinvslall.ClientID %>').value = '';
    document.getElementById('<%= txtitmslall.ClientID %>').value = '';
    document.getElementById('<%= txt_DocTypeCode_all.ClientID %>').value = '';
    document.getElementById('<%= txt_DocNo_all.ClientID %>').value = '';
    document.getElementById('<%= txt_IssParty_all.ClientID %>').value = '';
    document.getElementById('<%= txt_PlaceIssue_all.ClientID %>').value = '';
    document.getElementById('<%= txt_BenParty_all.ClientID %>').value = '';
    document.getElementById('<%= txt_IssueDate_all.ClientID %>').value = '';
    document.getElementById('<%= txtjobtypeall.ClientID %>').value = '';
    document.getElementById('<%= txtdoclevall.ClientID %>').value = '';

     document.getElementById('<%= txt_IssParty_add1_all.ClientID %>').value = '';
      document.getElementById('<%= txt_IssParty_add2_all.ClientID %>').value = '';
       document.getElementById('<%= txt_IssParty_add3_all.ClientID %>').value = '';
        document.getElementById('<%= txt_IssParty_add4_all.ClientID %>').value = '';
         document.getElementById('<%= txt_BenParty_add1_all.ClientID %>').value = '';
          document.getElementById('<%= txt_BenParty_add2_all.ClientID %>').value = '';
           document.getElementById('<%= txt_BenParty_add3_all.ClientID %>').value = '';
           document.getElementById('<%= txt_BenParty_add4_all.ClientID %>').value = '';

    return false; // prevents postback if used on button
}

  function onIcegateChange() {

    var ddlIcegate    = document.getElementById('<%= ddlIcegateId.ClientID %>');
    var selectedValue = ddlIcegate.value;
    var selectedText  = ddlIcegate.options[ddlIcegate.selectedIndex].text;

    // Store in hidden fields for server
    document.getElementById('<%= hdn_icegate_pass.ClientID %>').value = selectedValue;
    document.getElementById('<%= hdn_icegate_user.ClientID %>').value = selectedText;

    // Clear all mail detail text fields
    document.getElementById('<%= txtmailpass.ClientID %>').value = '';
    document.getElementById('<%= txtmailhost.ClientID %>').value = '';
    document.getElementById('<%= txtmailssl.ClientID %>').value  = '';
    document.getElementById('<%= txtmailport.ClientID %>').value = '';
    document.getElementById('<%= txtmobilno.ClientID %>').value  = '';
    document.getElementById('<%= txttenetid.ClientID %>').value  = '';
    document.getElementById('<%= txtclientid.ClientID %>').value = '';
    document.getElementById('<%= txtscreenid.ClientID %>').value = '';

    // Reset mail hidden fields
    document.getElementById('<%= hdn_mailtype.ClientID %>').value = '';
    document.getElementById('<%= hdn_mailid.ClientID %>').value   = '';

    // Reset mail dropdowns to blank
    var ddlMailType = document.getElementById('<%= ddlmailtype.ClientID %>');
    ddlMailType.innerHTML = '<option value=""></option>';

    var ddlMailId = document.getElementById('<%= ddlmailid.ClientID %>');
    ddlMailId.innerHTML = '<option value=""></option>';

    if (!selectedValue || selectedValue === '') return;

    // Load mail types
    PageMethods.Get_Mail_Type(selectedText, selectedValue, function (res) {
        if (!res || res === '') return;
        try {
            var items = JSON.parse(res);
            for (var i = 0; i < items.length; i++) {
                var opt   = document.createElement('option');
                opt.value = items[i].value;
                opt.text  = items[i].text;
                ddlMailType.appendChild(opt);
            }
        } catch (e) {
            console.log('Error parsing mail types:', e);
        }
    }, function (err) {
        console.log('Get_Mail_Type error:', err.get_message ? err.get_message() : err);
    });
}


function onMailTypeChange() {

    var mailType = document.getElementById('<%= ddlmailtype.ClientID %>').value;

    // Store in hidden field for server
    document.getElementById('<%= hdn_mailtype.ClientID %>').value = mailType;
    document.getElementById('<%= hdn_mailid.ClientID %>').value   = '';

    // Clear all mail detail text fields
    document.getElementById('<%= txtmailpass.ClientID %>').value = '';
    document.getElementById('<%= txtmailhost.ClientID %>').value = '';
    document.getElementById('<%= txtmailssl.ClientID %>').value  = '';
    document.getElementById('<%= txtmailport.ClientID %>').value = '';
    document.getElementById('<%= txtmobilno.ClientID %>').value  = '';
    document.getElementById('<%= txttenetid.ClientID %>').value  = '';
    document.getElementById('<%= txtclientid.ClientID %>').value = '';
    document.getElementById('<%= txtscreenid.ClientID %>').value = '';

    // Reset mail id dropdown to blank
    var ddlMailId = document.getElementById('<%= ddlmailid.ClientID %>');
    ddlMailId.innerHTML = '<option value=""></option>';

    if (!mailType || mailType === '') return;

    // Load mail IDs
    PageMethods.Get_Mail_Ids(mailType, function (res) {
        if (!res || res === '') return;
        try {
            var items = JSON.parse(res);
            for (var i = 0; i < items.length; i++) {
                var opt   = document.createElement('option');
                opt.value = items[i].value;
                opt.text  = items[i].text;
                ddlMailId.appendChild(opt);
            }
        } catch (e) {
            console.log('Error parsing mail ids:', e);
        }
    }, function (err) {
        console.log('Get_Mail_Ids error:', err.get_message ? err.get_message() : err);
    });
}

function onMailIdChange() {

    var mailType = document.getElementById('<%= ddlmailtype.ClientID %>').value;
    var mailId   = document.getElementById('<%= ddlmailid.ClientID %>').value;

    // Store in hidden field for server
    document.getElementById('<%= hdn_mailid.ClientID %>').value = mailId;

    // Clear all mail detail text fields
    document.getElementById('<%= txtmailpass.ClientID %>').value = '';
    document.getElementById('<%= txtmailhost.ClientID %>').value = '';
    document.getElementById('<%= txtmailssl.ClientID %>').value  = '';
    document.getElementById('<%= txtmailport.ClientID %>').value = '';
    document.getElementById('<%= txtmobilno.ClientID %>').value  = '';
    document.getElementById('<%= txttenetid.ClientID %>').value  = '';
    document.getElementById('<%= txtclientid.ClientID %>').value = '';
    document.getElementById('<%= txtscreenid.ClientID %>').value = '';

    if (!mailId || mailId === '') return;

    // Load mail detail text fields
    PageMethods.Get_mail_data(mailType, mailId, function (res) {
        if (!res || res === '') return;
        try {
            var parts = res.split('~');
            document.getElementById('<%= txtmailpass.ClientID %>').value = parts[0] || '';
            document.getElementById('<%= txtmailhost.ClientID %>').value = parts[1] || '';
            var ssl = (parts[2] || '').toLowerCase();
            document.getElementById('<%= txtmailssl.ClientID %>').value  = (ssl === 'true') ? 'true' : 'false';
            document.getElementById('<%= txtmailport.ClientID %>').value = parts[3] || '';
            document.getElementById('<%= txtmobilno.ClientID %>').value  = parts[4] || '';
            document.getElementById('<%= txttenetid.ClientID %>').value  = parts[5] || '';
            document.getElementById('<%= txtclientid.ClientID %>').value = parts[6] || '';
            document.getElementById('<%= txtscreenid.ClientID %>').value = parts[7] || '';
        } catch (e) {
            console.log('Error parsing mail data:', e);
        }
    }, function (err) {
        console.log('Get_mail_data error:', err.get_message ? err.get_message() : err);
    });
}

    </script>
</body>
</html>
