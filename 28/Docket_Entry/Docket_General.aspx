<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Docket_General.aspx.cs" Inherits="Docket_Entry_Docket_General" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
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
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>



    <script type="text/javascript">
        function ShowModalPopup() {
            $('#txtid').val('');
            $find("MP_JOB").show();
            return false;
        }
        function HideModalPopup() {
            $('#txtid').val('');
            $find("MP_JOB").hide();
            return false;
        }

    </script>
<%--    <script type="text/javascript">
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "Docket_General.aspx/BindDatatoDropdown",
                data: "{}",
                dataType: "json",
                success: function (data) {
                    $.each(data.d, function (key, value) {
                        $("#ddlfilerefno").append($("<option></option>").val(value.FILE_REF_NO).html(value.FILE_REF_NO));
                    });
                },
                error: function (result) {
                    alert("Error");
                }
            });
        });
    </script>--%>


    <style type="text/css">
        .modalPopup12 {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>

    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
                <div id="innerbox_MidMain_Transact_popup_new">
                    <div id="tag_srcinner1_new">
                        <div id="editbu">
                            <a href="#" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1">
                            Transaction - Import 
                        </div>
                        <div id="popupwindow_closebut_right_new">
                            <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();return false;"
                                CausesValidation="false" UseSubmitBehavior="false" />
                        </div>

                    </div>
                    <div id="tag_transaction_inner_new" style="margin-left: 20px">
                        <div id="tag_Exchange_lft_in1_new1">
                        
                        </div>
                        <%--<div id="tag_label_transaction_popup_IGM2_empty_gen">
                           <div id="tag_label_transaction_Src_new">
                                File Ref No
                            </div>\
                            <div id="txtcon-m_transaction_code">
                                 <asp:DropDownList ID="ddlfilerefno" runat="server" CssClass="listtxt_transac_src1">
                            </asp:DropDownList>
                            </div>

                        </div>--%>
                        <div id="Div1">
                        <div id="tag_label_transaction_Src_new">
                            File Ref No</div>
                        <div id="txtcon-m_transaction_code_BE_TYPE" style="width:150px">
                            <asp:DropDownList ID="ddlfilerefno" runat="server" TabIndex="1" 
                                CssClass="listtxt_transac_src1" AutoPostBack="true" Visible="false" Width="150px"
                                onselectedindexchanged="ddlfilerefno_SelectedIndexChanged">
                            </asp:DropDownList>

                            <asp:TextBox ID="txt_FileRefNo" runat="server" CssClass="txtbox_none_Mid_transac_code" Visible="false" Width="150px"
                             ReadOnly="true"></asp:TextBox>
                        </div>

                        <div id="tag_label_transaction_popup_no_empty">
                            
                        </div>

                        <div id="tag_label_transaction_Src_new">

                            JobNo</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txteroyal_jobno" runat="server" CssClass="txtbox_none_Mid_transac_code" ReadOnly="true"
                                  TabIndex="2"></asp:TextBox>                         
                        </div>  

                        <div id="tag_label_transaction_popup_no_empty">                          
                        </div>
                        
                         <div id="tag_label_transaction_date">
                             Importer Name</div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                     <asp:TextBox ID="txt_ImporterName" runat="server"  ClientIDMode="Static" ReadOnly="true"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                                                TabIndex="3"></asp:TextBox>              
                        </div>                       
                    </div>

                    </div>
                </div>
                <div id="innerbox_MidMain_Trans_new" style="height:500px"; >
                    <ol id="toc_new">               

                    </ol>
                    <div class="content" id="page-1" >
                        <div id="area_transac_container_genral" runat="server">

                         <div id="pop_text_area_transac_popup_inn_container_export"  style="height:400px";>
                         
                            <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_popup_gen" style="width:140px;">
                           OOC Date
                        </div>
                        <div id="txt_trans_exp_drawback">


                                 <asp:TextBox ID="txtooc_date" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="3"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtooc_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtooc_date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>

                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            DO Collected Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                         <asp:TextBox ID="txtdocollected_date" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="4"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtdocollected_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtdocollected_date_CalendarExtender" runat="server" TargetControlID="txtdocollected_date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                             Detention Free Days
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtdetention_free_days" runat="server" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="5"></asp:TextBox>
                        </div>
                    </div>
                              <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                           Port Name
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtport_name" runat="server" ClientIDMode="Static" 
                                class="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="6"></asp:TextBox>
                        </div>
                    <div id="magnify_area">
                        </div>
                        
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            Container Landed Time
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtcontainer_landedtime" runat="server" CssClass="txtbox_trans_exp_drawback" MaxLength="10"
                                  TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            Container Landed Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                          <asp:TextBox ID="txtcontainer_landeddate" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="8"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtcontainer_landeddate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtcontainer_landeddate_CalendarExtender" runat="server" TargetControlID="txtcontainer_landeddate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                        </div>
                    </div>
                          <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                           Container Out Time
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtcontainer_outtime" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="9"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            Container out Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                          <asp:TextBox ID="txtcontainer_outdate" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="10"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtcontainer_outdate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtcontainer_outdate_CalendarExtender" runat="server" TargetControlID="txtcontainer_outdate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            Transport Name
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txttransport_name" runat="server" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="11"></asp:TextBox>

                                

                        </div>
                    </div>   
                        <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                          Truck Number
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txttruck_number" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="12"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                             TPT Net Amount
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txttptnet_amount" runat="server" CssClass="txtbox_trans_exp_drawback"
                                  TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            Halting Days
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txthalting_days" runat="server" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="14"></asp:TextBox>

                                

                        </div>
                    </div>
                             <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                           Halt Net
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txthalt_net" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="15"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            DO Valid Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                          <asp:TextBox ID="txtdovalid_date" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="16"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtdovalid_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtdovalid_date_CalendarExtender" runat="server" TargetControlID="txtdovalid_date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                           DO Extenstion
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtdo_extenstion" runat="server" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="17"></asp:TextBox>

                                

                        </div>
                    </div>
                             <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                          Vessel Name
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtvessel_name" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="18"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                           Vessel Voyage
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtvessel_voyage" runat="server" CssClass="txtbox_trans_exp_drawback"
                                  TabIndex="19"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            Arrival Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                          <asp:TextBox ID="txtarrival_date" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="20"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtarrival_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtarrival_date_CalendarExtender" runat="server" TargetControlID="txtarrival_date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>

                        </div>
                    </div>
                        <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                          Duty Paid Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                          <asp:TextBox ID="txtdutypaid_date" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="21"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtdutypaid_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtdutypaid_date_CalendarExtender" runat="server" TargetControlID="txtdutypaid_date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                        
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                          Duty Paid By
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtdutypaid_by" runat="server" CssClass="txtbox_trans_exp_drawback"
                                  TabIndex="22"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                           Adv. Received Amount
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtadvancerec_amount" runat="server" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="23"></asp:TextBox>

                                

                        </div>
                    </div>
                           <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                         Advance RecDate
                        </div>
                        <div id="txt_trans_exp_drawback">
                        <asp:TextBox ID="txtadvance_recdate" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="24"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txtadvance_recdate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtadvance_recdate_CalendarExtender" runat="server" TargetControlID="txtadvance_recdate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                         Advance Paid By
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtadvance_paidby" runat="server" CssClass="txtbox_trans_exp_drawback"
                                  TabIndex="25"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                          TIN No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txttin_no" runat="server" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="26"></asp:TextBox>
                        </div>
                    </div>
                     <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                          Checklist Sent Date
                        </div>
                      <div id="txt_trans_exp_drawback">
                        <asp:TextBox ID="txtchecklist_sentdate" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="27"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txtchecklist_sentdate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtchecklist_sentdate_CalendarExtender" runat="server" TargetControlID="txtchecklist_sentdate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                             Conformation RecDate
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtconfor_recdate" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="28"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtconfor_recdate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtconfor_recdate_CalendarExtender" runat="server" TargetControlID="txtconfor_recdate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            CFS Name
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtCFS_name" runat="server" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="29"></asp:TextBox>

                                

                        </div>
                    </div>
                     <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                          Freight CertRec Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtfreight_certrecdate" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="30"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender11" runat="server" TargetControlID="txtfreight_certrecdate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtfreight_certrecdate_CalendarExtender" runat="server" TargetControlID="txtfreight_certrecdate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            Original DocRecDate
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtoriginal_docrecdate" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="31"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txtoriginal_docrecdate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtoriginal_docrecdate_CalendarExtender" runat="server" TargetControlID="txtoriginal_docrecdate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                             House Agent Name
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txthous_agentname" runat="server" ClientIDMode="Static"
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="32"></asp:TextBox>
                        </div>
                    </div>
                     <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                          Master Agent Name
                        </div>
                        <div id="txt_trans_exp_drawback">
                             <asp:TextBox ID="txtmaster_agentname" runat="server" CssClass="txtbox_trans_exp_drawback"
                                  TabIndex="33"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                              RMS or Group
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtrms_orgroup" runat="server" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="34"></asp:TextBox>

                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                           Cleared Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                           
                              <asp:TextBox ID="txtcleared_date" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="35"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txtcleared_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="txtcleared_date_CalendarExtender" runat="server" TargetControlID="txtcleared_date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>  

                        </div>
                    </div>
                     <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                          Cleared InsPerName
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtcleared_inspername" runat="server" CssClass="txtbox_trans_exp_drawback"
                                  TabIndex="36"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                              Clr DelPersion Name
                        </div>
                        <div id="txt_trans_exp_drawback">
                              <asp:TextBox ID="txtcleared_delpername" runat="server" CssClass="txtbox_trans_exp_drawback"
                                TabIndex="37"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            Mother Vessel Name
                        </div>
                        <div id="txt_trans_exp_drawback">
       
                            <asp:TextBox ID="txtmother_vessname" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="38"></asp:TextBox>
                        </div>
                    </div>
                     <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                            Mother Vessel Voyage
                        </div>
                        <div id="txt_trans_exp_drawback">
                             <asp:TextBox ID="txtmother_voyname" runat="server" CssClass="txtbox_trans_exp_drawback"
                                  TabIndex="39"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                             Gross Weight
                        </div>
                        <div id="txt_trans_exp_drawback">
                           <asp:TextBox ID="txt_GrossWeight" runat="server" CssClass="txtbox_trans_exp_drawback"
                                  TabIndex="40"></asp:TextBox>
                        </div>
                        <div id="magnify_area"></div>

                         <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                             Net Weight
                        </div>
                        <div id="txt_trans_exp_drawback">
                           <asp:TextBox ID="txt_NetWeight" runat="server" CssClass="txtbox_trans_exp_drawback"
                                  TabIndex="41"></asp:TextBox>
                        </div>
                        
                    </div>
                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                         <div id="tag_label_transaction_popup_IGM_Container">
                                Cont.Size 20'
                            </div>
                        </div>
                        
                            
                      

                        
                        <div id="tag_label_transaction_exp_jobb" style="width:150px;">
                    <asp:TextBox ID="txtcontsize20" runat="server" CssClass="txtbox_trans_exp_drawback"   MaxLength="3" onkeypress="return pin(event)"
                                  TabIndex="42"></asp:TextBox>
                        </div>
                        
                         <div id="magnify_area">
                        </div>

                        <div id="tag_label_transaction_popup_IGM_Container" style="width:140px;">
                                 Cont.Size 40'
                            </div>
                            <div id="txtcon-m_transaction_list1_fcl" style="width:150px;">
                               <asp:TextBox ID="txtContsize40" runat="server" CssClass="txtbox_trans_exp_drawback"   MaxLength="3"  onkeypress="return pin(event)"
                                  TabIndex="43"></asp:TextBox>


                            </div>

                             <div id="magnify_area">
                        </div>
                             
                              <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                             No of Packages
                        </div>

                        <div id="txt_trans_exp_drawback">
                           <asp:TextBox ID="txtnoofpckges" runat="server" CssClass="txtbox_trans_exp_drawback"  MaxLength="11"
                                  TabIndex="44"></asp:TextBox>
                        </div>

                            

                         

                     <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                        Supplier
                        </div>
                        <div id="txt_trans_exp_drawback">
                                 <asp:TextBox ID="txtsupplier" runat="server" CssClass="txtbox_trans_exp_drawback"  MaxLength="120"
                                  TabIndex="45"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:140px;">
                             Description
                        </div>
                        <div id="txt_trans_exp_drawback">
                           
                            <asp:TextBox ID="txtdesc" runat="server" ClientIDMode="Static"
                                CssClass="txtbox_trans_exp_drawback" MaxLength="120" TabIndex="46" ></asp:TextBox>
                        </div>
                         <div id="magnify_area">
                        </div>
                        
                              <div id="tag_label_transaction_popup_IGM_Container" style="width:140px;">
                                LCL
                            </div>


                                <div id="txtcon-m_transaction_list1_fcl">
                              <asp:TextBox ID="txtLCL" runat="server" CssClass="txtbox_trans_exp_drawback"  onkeypress="return pin(event)"
                                  TabIndex="47"></asp:TextBox>
                            </div>

                    </div> 
                    
                    <div id="innerbox_MidMain_bot_transact" style="height:23px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb"  style="width:137px;">
                        Clearance Delivery
                        </div>
                        <div id="txt_trans_exp_drawback" style="width:80px;">
                            <asp:TextBox ID="txtclrdelivery" runat="server" CssClass="txtbox_trans_exp_drawback"  onkeypress="return pin(event)"  MaxLength="5"
                                TabIndex="48" style="width:70px;"></asp:TextBox>
                        </div>
                      
                        <div id="tag_label_transaction_exp_jobb" style="width:130px;">
                           Totl Clearance Period
                        </div>
                        <div id="txt_trans_exp_drawback" style="width:80px;">
                            <asp:TextBox ID="txtclrperiod" runat="server" CssClass="txtbox_trans_exp_drawback"  onkeypress="return pin(event)" MaxLength="5"
                                TabIndex="49" style="width:70px;" ></asp:TextBox>
                        </div>

                        <div id="tag_label_transaction_exp_jobb" style="width:110px;">
                           Service Task BWC
                        </div>
                <div id="txt_trans_exp_drawback" style="width:93px;">
                            <asp:TextBox ID="txtsrvtask" runat="server" CssClass="txtbox_trans_exp_drawback"  onkeypress="return pin(event)" MaxLength="5"
                                TabIndex="50" style="width:70px;"></asp:TextBox>
                        </div>

                         <div id="magnify_area" style="width:11px;">
                        </div>
                 <div id="tag_label_transaction_exp_jobb" style="width:138px;">
                            Duty Updated Date
                        </div>

                        <div id="txt_trans_exp_drawback" style="width:80px;">
                          <asp:TextBox ID="txtupdationdate" runat="server" MaxLength="10" CssClass="txtbox_trans_exp_drawback"
                                    TabIndex="51"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txtupdationdate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtupdationdate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>

                        </div>
                        
                    </div> 
                    
                            <div id="innerbox_MidMain_bot_transact" runat="server">
                           <div id="innerbox_transac_bot_inn">
                                        <div id="newbu">
                                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                                OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                                TabIndex="52" />
                                        </div>
                                        <div id="editbu">
                                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                                TabIndex="53" OnClick="btnSave_Click" CommandName="s" />
                                        </div>
                                        <div id="editbu">
                                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                                OnClientClick="return validate();" TabIndex="54" />
                                        </div>
                                        <div id="editbu">
                                            <asp:Button ID="btnDelete" runat="server" TabIndex="55" CausesValidation="false"
                                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job?', 'DOCKET ENTRY', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" OnClick="btnDelete_Click1" />
                                            <asp:Button ID="btn" runat="server" TabIndex="55" CausesValidation="false" OnClick="btnDelete_Click"
                                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                                CssClass="dlete" Style="display: none;" />
                                            <asp:Button ID="btnAuto_Jobno" runat="server" TabIndex="55" CausesValidation="false"
                                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                                CssClass="dlete" Style="display: none;" />

                                        </div>
                                        <div id="editbu">
                                          
                                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                            id="btnCancel" TabIndex="56" ></div>
                                    </div>
                                  </div>
                 
                           
                                </div>
                            <asp:HiddenField ID="HDupdate_id" runat="server" />
                            <asp:HiddenField ID="hdn_Jobno" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />

                        

                         </div>
                    <div class="content" id="page-2" style="display: none;">
                        <iframe src="#" name="maineroyal" scrolling="no" id="Trans_igm_Iframe"></iframe>
                    </div>
                    <div class="content" id="page-3" style="display: none;">
                        <iframe src="#" name="maineroyal1" scrolling="no" id="Trans_igm_Invoice_Iframe"></iframe>
                    </div>
                    <div class="content" id="page-4" style="display: none;">
                        <iframe src="#" name="maineroyal2" scrolling="no" id="Trans_igm_item_Iframe"></iframe>
                    </div>
                    <div class="content" id="page-5" style="display: none;">
                    </div>
                    <div class="content" id="page-6" style="display: none;">
                    </div>
                    <div class="content" id="page-7" style="display: none;">
                    </div>

               
                </div>
                <script src="../activatables.js" type="text/javascript"></script>
                <script type="text/javascript">
                    activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
                </script>
                <div style="display: none;">

                    

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
    <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
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
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>
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
            //document.getElementById("btnCancel").click();
            document.getElementById("General").click();
        }
    </script>



    <script language="javascript">

        function calculateTotal(thisCheckbox) {

            var TextBox1 = document.getElementById("txt_Branch").value;
            var TextBox2 = document.getElementById("txt_jobno").value;
            var TextBox3 = document.getElementById("txtyear").value;

            if (document.getElementById("Chbranch").checked == true && document.getElementById("chyear").checked == true) {

                if (TextBox1.trim() != '' && TextBox2.trim() != '' && TextBox3.trim() != '') {

                    var TextBox1 = document.getElementById("txt_Branch").value + '/';
                    var TextBox2 = document.getElementById("txt_jobno").value + '/';
                    var TextBox3 = document.getElementById("txtyear").value;

                    var res = TextBox1.concat(TextBox2, TextBox3);
                    document.getElementById("txtpreview").value = res;
                }
                else if (TextBox1.trim() != '' && TextBox2.trim() != '' && TextBox3.trim() == '') {

                    var TextBox1 = document.getElementById("txt_Branch").value + '/';
                    var TextBox2 = document.getElementById("txt_jobno").value;

                    var res1 = TextBox1.concat(TextBox2);
                    document.getElementById("txtpreview").value = res1;
                }
                else if (TextBox1.trim() == '' && TextBox2.trim() != '' && TextBox3.trim() != '') {

                    var TextBox2 = document.getElementById("txt_jobno").value + '/';
                    var TextBox3 = document.getElementById("txtyear").value;

                    var res2 = TextBox2.concat(TextBox3);
                    document.getElementById("txtpreview").value = res2;

                }
                else if (TextBox1.trim() != '' && TextBox2.trim() == '' && TextBox3.trim() != '') {
                    document.getElementById("txtpreview").value = '';

                }
            }
                //----------------------------------------------------------------------------------------------------------
            else if (document.getElementById("Chbranch").checked == true && document.getElementById("chyear").checked == false) {

                if (TextBox1.trim() != '' && TextBox2.trim() != '') {
                    var TextBox1 = document.getElementById("txt_Branch").value + '/';
                    var TextBox2 = document.getElementById("txt_jobno").value;

                    var res3 = TextBox1.concat(TextBox2);
                    document.getElementById("txtpreview").value = res3;

                }
                else {
                    document.getElementById("txtpreview").value = document.getElementById("txt_jobno").value;
                }

            }
                //-------------------------------------------------------------------------------------------------------------------------------------
            else if (document.getElementById("Chbranch").checked == false && document.getElementById("chyear").checked == true) {

                if (TextBox2.trim() != '') {
                    var TextBox2 = document.getElementById("txt_jobno").value + '/';
                    var TextBox3 = document.getElementById("txtyear").value;

                    var res4 = TextBox2.concat(TextBox3);
                    document.getElementById("txtpreview").value = res4;
                }
                else {

                    document.getElementById("txtpreview").value = '';
                }

            }
            else if (document.getElementById("Chbranch").checked == false && document.getElementById("chyear").checked == false) {

                document.getElementById("txtpreview").value = document.getElementById("txt_jobno").value;
            }
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtImporterName').focus(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtImporterName').change(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtImporterName').keyup(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtImporterName').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });

        function Item_desc(val) {

            var data = val;
            if (data == '') {
                $('#txtImporterName').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txtImporterName').val(after);

                $('#hdimp').val(after);
                $('#hd_Brslno').val(before);

            }
            else {

            }
        }
        function btnCancel_onclick() {

        }

    </script>



    <script src="../js/Import_Jscript/Import_Jobedit.js" type="text/javascript"></script>




</body>
</html>



