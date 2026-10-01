<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SW_Control_Master.aspx.cs"
    Inherits="SW_Control_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item | Transaction</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css">
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
    </style>
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript">

        function HideModalPopup_U() {
            $find("MP_U").hide();
            return false;
        }
        function HideModalPopup_UE() {
            $find("MP_UE").hide();
            return false;
        }
        function HideModalPopup_Show() {
            $find("MP_UE").show();
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
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier" style="margin-top: 20px;">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 660px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Cont.Type Code
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:DropDownList ID="ddlCont_type_code" runat="server" TabIndex="1" class="chosen-select-deselect"
                            AutoPostBack="true" Style="width: 215px; font-family: Arial,Helvetica,sans-serif;"
                            data-placeholder="Choose Control Code" OnSelectedIndexChanged="ddlCont_type_code_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        <asp:Label ID="lbl_StartDate" runat="server" Text="Cont. Start Date"></asp:Label>
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Cont_Start_Date" runat="server" MaxLength="11" TabIndex="3"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Cont_Start_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_Cont_Start_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 660px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        <asp:Label ID="lbl_location" runat="server" Text="Cont. Location "></asp:Label>
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:TextBox ID="txt_Cont_Location" runat="server" MaxLength="17" TabIndex="2" Width="210px"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        <asp:Label ID="lbl_EndDate" runat="server" Text="Cont. End Date"></asp:Label>
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Cont_End_Date" runat="server" TabIndex="4" MaxLength="11" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_Cont_End_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_Cont_End_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 660px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        <asp:Label ID="lbl_ResultCode" runat="server" Text="Cont. Result Code"></asp:Label>
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import">
                        <asp:DropDownList ID="ddl_ResultCode" runat="server" TabIndex="1" class="chosen-select-deselect"
                            Style="width: 215px; font-family: Arial,Helvetica,sans-serif;" data-placeholder="Choose Result Code">
                        </asp:DropDownList>
                        <asp:TextBox ID="txt_Cont_ResultCode" MaxLength="16" runat="server" TabIndex="2"
                            CssClass="txtbox_none_Mid_transac_Supp_Name" Width="210px" Visible="false"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        <asp:Label ID="lbl_Result_Text" runat="server" Text="Cont. Result Text"></asp:Label>
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Cont_Result_Text" MaxLength="4000" runat="server" TabIndex="6"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 660px; margin-top: 5px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Cont. SLNO
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txt_Cont_SLNO" runat="server" MaxLength="3" TabIndex="7" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 75px;">
                        Cont. MSR
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Cont_MSR" runat="server" MaxLength="23" TabIndex="8" Width="110px"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 65px;">
                        Cont. UQC
                    </div>
                    <div id="txtcon-m_transaction_code">
                        <asp:TextBox ID="txt_Cont_UQC" runat="server" MaxLength="3" TabIndex="9" Width="70px"
                            CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty_Re_import">
                    <div id="editbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="12"
                            OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="12" OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="13" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'SW Constituent', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="13" OnClick="btnDelete_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('SW_info_type');return false;"
                            TabIndex="14" CausesValidation="false" UseSubmitBehavior="false" />
                        <asp:Button ID="btnaddnew" runat="server" Text="Bulk Insert SEC65" OnClientClick="return HideModalPopup_Show()"
                            Width="120px" Visible="false" CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                    <%--<div id="editbu">
                        <asp:Button ID="btnBulkexcel" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            CssClass="autowidmovebut" Text="XL Upload" OnClientClick="jQuery('#form1').validationEngine('hide');open_SW_Control_SEC65_XBE_Excel_Upload('New');return false;" />
                    </div>--%>
                    <div id="editbu">
                        <span style="color: Green;">
                            <asp:Label ID="lblSEC65" runat="server"></asp:Label>
                        </span>
                    </div>
                </div>
                <div id="tag_transac_lft_Item_reimport_Grid_area" style="overflow: auto; height: 130px;">
                    <asp:GridView ID="gv_ReImport" runat="server" DataKeyNames="SW_CONTROL_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="180%"
                        ShowHeaderWhenEmpty="True" OnRowDataBound="gv_ReImport_RowDataBound" OnPageIndexChanging="gv_ReImport_PageIndexChanging"
                        OnSelectedIndexChanged="gv_ReImport_SelectedIndexChanged" PageSize="5" AllowPaging="True"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_ReImport_RowCreated">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="CONTROL_TYPE_CODE" HeaderText="Control Type Code">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_LOCATION" HeaderText="Control Location">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_START_DATE" HeaderText="Control Start Date">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_END_DATE" HeaderText="Control End Date">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_RESULT_CODE" HeaderText="Control Result Code">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_RESULT_TEXT" HeaderText="Control Result Text ">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_MSR" HeaderText="Control End Date">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_UQC" HeaderText="Control Result Code">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTROL_SLNO" HeaderText="Control Result Text ">
                                <ItemStyle CssClass="column_style_left5" />
                            </asp:BoundField>
                           <%-- <asp:BoundField DataField="AMENDMENT_TYPE" HeaderText="Amend Type" ControlStyle-Width="70px">
                                <ItemStyle CssClass="column_style_left5" Width="70px"/>
                            </asp:BoundField>--%>
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                            NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                        <PagerStyle CssClass="pager" />
                    </asp:GridView>
                </div>
            </div>
            <asp:HiddenField ID="hdn_update_Reimport" runat="server" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdn_Normal_Bulk" runat="server" />
            <asp:HiddenField ID="hdn_Jobno" runat="server" />
            <asp:HiddenField ID="hdn_Invslno" runat="server" ClientIDMode="Static" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_UE" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_UE"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_E" runat="server" />
    <asp:Panel ID="MessageDivupdated_UE" runat="server" CssClass="modalPopup12" Style="margin-top: -33px;"
        align="left" BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 600px; height: 200px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="lblUser_Msg_2" runat="server" Text="Single window Control"></asp:Label>
                        &nbsp;&nbsp; <span style="color: Green; font-weight: bold;">
                            <asp:Label ID="Label1" runat="server" Text="Bulk Insert"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <span style="color: Red; font-weight: bold;">Invoice Sl.No:
                            <asp:Label ID="lblinvid" runat="server"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px;">
                        Cont. Type Code :
                    </td>
                    <td colspan="3">
                        <span style="color: Green; font-weight: bold;">
                            <asp:Label ID="lbl_Con_Type_Code" runat="server" Text="SEC65 - XBE"></asp:Label>
                        </span>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px;">
                        Warehouse Code :
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txt_Bulk_Warehouse_Code" runat="server" MaxLength="17" TabIndex="2"
                            Width="310px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px;">
                        Warehousing Date
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Bulk_Warehousing_Date" runat="server" MaxLength="11" TabIndex="3"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Bulk_Warehousing_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Bulk_Warehousing_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td style="width: 120px;">
                        GST Inv. No
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Bulk_GST_Inv_No" runat="server" MaxLength="17" TabIndex="4"
                            Width="210px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </td>
                    <td>
                        GST Inv. Date
                    </td>
                    <td>
                        <asp:TextBox ID="txt_Bulk_Inv_Date" runat="server" MaxLength="11" TabIndex="5" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Bulk_Inv_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Bulk_Inv_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <br />
                    </td>
                </tr>
               
                <%--<tr>
                 <td style="width:120px;">
                     <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_UE()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>--%>
            </table>
        </div>
    </asp:Panel>
    <%----------------------------------------------------------------------------%>
    </form>
    <script src="../js/Import_Jscript/Import_ReImport.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script>


        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {
                return options.allrules.validate2fields.alertText;
            }
        }
        function OpenPopupImport_Port_House(val) {
            if (document.getElementById('hdfTransport_mode').value != '') {
                var s = document.getElementById('hdfTransport_mode').value;
                OpenPopupCustom_House_Details_Port(s, val);
                return false
            }
        }

        function Open_Amend_Flatfile() {
            var amd_type = document.getElementById("ddl_AmendmentType").value;
            var amd_page = 'BE_ITEM_SW_CTRL';
            var amd_Jobno = document.getElementById("hdn_Jobno").value;
            var amd_Invslno = document.getElementById("hdn_Invslno").value;

            NewWindow1('../Amendment/Import_Amendment.aspx?amd_type=' + amd_type + '&amd_page=' + amd_page + '&amd_Jobno=' + amd_Jobno + '&amd_Invslno=' + amd_Invslno, 'List', '950', '515', 'yes');
        }
      
   
    </script>
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
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
    </script>
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
        $(function () {

            var ddl_code = document.getElementById('ddlCont_type_code').value;

            if (ddl_code.includes("SEC65")) {

                $("#txt_Cont_Location").autocomplete({
                    source: function (request, response) {
                        var field = $(this.element).attr('id');
                        $.ajax({

                            url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Warehouse_code_Master_List",
                            data: "{ 'mail': '" + request.term + "' }",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            async: true,
                            success: function (data) {
                                response(data.d);
                                if (data.d == '') {
                                    if (field == 'txt_Cont_Location') {
                                        jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Warehouse Code', 'error', 'topRight', true);
                                    }
                                }
                                else {
                                    jQuery('#txt_Cont_Location').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
            }
            else {
                $("#txt_Cont_Location").autocomplete({
                    source: function (request, response) {
                        $.ajax({
                            url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                            data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",
                            //                data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                            dataType: "json",
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            dataFilter: function (data) { return data; },
                            async: true,
                            success: function (data) {
                                response(data.d);
                                if (data.d == '') {
                                    jQuery('#txt_Cont_Location').validationEngine('showPrompt', 'Incorrect Location', 'error', 'topRight', true);

                                    //jAlert('Port Of License is Incorrect', 'LICENSE', function (r) { document.getElementById("txtPort_Of_Licenses").focus(); });
                                    // return false;
                                }
                                else {
                                    jQuery('#txt_Cont_Location').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                }
                            },
                            error: function (XMLHttpRequest, textStatus, errorThrown) {
                                //////alert(textStatus);
                            }
                        });
                    },
                    minLength: 1

                });
                return false;
                scroll: true;
            }
        });
    </script>
    <script type="text/javascript">
        $(function () {

            $("#txt_Bulk_Warehouse_Code").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    $.ajax({

                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Warehouse_code_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txt_Bulk_Warehouse_Code') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Warehouse Code', 'error', 'topRight', true);
                                }
                            }
                            else {
                                jQuery('#txt_Bulk_Warehouse_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#txt_Bulk_Warehouse_Code').focus(function () {

                var data = $(this).val();
                WH_Code_BK(data);

            });
            $('#txt_Bulk_Warehouse_Code').change(function () {

                var data = $(this).val();
                WH_Code_BK(data);

            });
            $('#txt_Bulk_Warehouse_Code').keyup(function () {

                var data = $(this).val();
                WH_Code_BK(data);

            });
            $('#txt_Bulk_Warehouse_Code').keydown(function () {

                var data = $(this).val();
                WH_Code_BK(data);

            });

        });

        function WH_Code_BK(val) {

            var data = val;
            if (data == '') {
                $('#txt_Bulk_Warehouse_Code').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');
                var before = s[0];
                var after = s[1];
                $('#txt_Bulk_Warehouse_Code').val(before);
            }
            else {

            }
        }


    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#txt_Cont_Location').focus(function () {

                var data = $(this).val();
                WH_Code(data);

            });
            $('#txt_Cont_Location').change(function () {

                var data = $(this).val();
                WH_Code(data);

            });
            $('#txt_Cont_Location').keyup(function () {

                var data = $(this).val();
                WH_Code(data);

            });
            $('#txt_Cont_Location').keydown(function () {

                var data = $(this).val();
                WH_Code(data);

            });

        });

        function WH_Code(val) {

            var data = val;
            if (data == '') {
                $('#txt_Cont_Location').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');
                var before = s[0];
                var after = s[1];
                $('#txt_Cont_Location').val(before);
            }
            else {

            }
        }



        $(function () {
            $("#txt_Cont_UQC").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');

                    $.ajax({

                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_List",
                        //                      url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_STD_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                if (field == 'txt_Cont_UQC') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Qty Code', 'error', 'topRight', true);

                                }
                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);

                                var result = data.d;

                                var stringsearch = "-", str = result;

                                for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                                if (i == 1) {
                                    if (field == 'txt_Cont_UQC') {
                                        $('#txt_Cont_UQC').val(result);
                                    }
                                }
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            //////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });


        $(document).ready(function () {
            $('#btnUpdate,#btnSave').click(function () {

                var ddl_code = document.getElementById('ddlCont_type_code').value;

                var Cont_Location = document.getElementById("txt_Cont_Location").value;
                if (Cont_Location.length == 0) {
                    jAlert('Control Location - Mandatory', 'SW - CONTROL', function (r) { document.getElementById("txt_Cont_Location").focus(); });
                    return false;
                }

                if (ddl_code.includes("SEC65")) {

                    var Cont_ResultCode = document.getElementById("txt_Cont_ResultCode").value;
                    if (Cont_ResultCode.length == 0) {
                        jAlert('Control ResultCode - Mandatory', 'SW - CONTROL', function (r) { document.getElementById("txt_Cont_ResultCode").focus(); });
                        return false;
                    }

                    var Cont_SLNO = document.getElementById("txt_Cont_SLNO").value;
                    if (Cont_SLNO.length == 0) {
                        jAlert('Control SLNO - Mandatory', 'SW - CONTROL', function (r) { document.getElementById("txt_Cont_SLNO").focus(); });
                        return false;
                    }

                    var Cont_MSR = document.getElementById("txt_Cont_MSR").value;
                    if (Cont_MSR.length == 0) {
                        jAlert('Control MSR - Mandatory', 'SW - CONTROL', function (r) { document.getElementById("txt_Cont_MSR").focus(); });
                        return false;
                    }

                    var Cont_UQC = document.getElementById("txt_Cont_UQC").value;
                    if (Cont_UQC.length == 0) {
                        jAlert('Control UQC - Mandatory', 'SW - CONTROL', function (r) { document.getElementById("txt_Cont_UQC").focus(); });
                        return false;
                    }

                }
            });
        });


    </script>
</body>
</html>
