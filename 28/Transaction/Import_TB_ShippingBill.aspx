<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_TB_ShippingBill.aspx.cs"
    Inherits="Import_TB_ShippingBill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import - TB ShippingBill</title>
   <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
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


     <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#DeferredCredit").attr('checked', true);
//            alert('enter');
//            jQuery("#form1").validationEngine();
        });
        </Script>

    <script language="jscript" type="text/javascript">
        $(document).ready(function () {
            $('#RadioButton_Exporters input:radio').change(function () {
                var selectedVal = $("#RadioButton_Exporters input:radio:checked").val();
                
                if (selectedVal == 'Others') {

                    txt_exp_others.disabled = false;
                }
                else {
                    txt_exp_others.disabled = true;
                }
             
            });
        });

//        $(document).ready(function () {
//            $('input[type=radio]').live('change', function () { alert('wtf'); });
//        });

    </script>

        <script language="jscript" type="text/javascript">
            $(document).ready(function () {
                $('#RadioButton_Nature input:radio').change(function () {
                    var selectedVal = $("#RadioButton_Nature input:radio:checked").val();
                    if (selectedVal == 'Others') {
                        //                    alert(selectedVal);
                        txt_NatureOfOthers.disabled = false;
                    }
                    else {
                        txt_NatureOfOthers.disabled = true;
                    }
                });
            });
    </script>

            <script language="jscript" type="text/javascript">
                $(document).ready(function () {
                    $('#RadioButton_Ship input:radio').change(function () {
                        var selectedVal = $("#RadioButton_Ship input:radio:checked").val();
                        if (selectedVal == 'Others') {
                            //                    alert(selectedVal);
                            txt_Ship_Others.disabled = false;
                        }
                        else {
                            txt_Ship_Others.disabled = true;
                        }
                    });
                });
    </script>

    <script type="text/javascript">

        function AddNewRecord() {
            var grd = document.getElementById('GV_Details');
            var tbod = grd.rows[0].parentNode;
            var newRow = grd.rows[grd.rows.length - 1].cloneNode(true);
            tbod.appendChild(newRow);
            return false;

        }
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
            <div id="innerbox_MidMain_Transact_popup_new" style="height: 105px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                       Import - TB ShippingBill
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transaction_inner_new">
                    <div id="tag_Exchange_lft_in1_new1" style="margin-top: 10px;">
                        <div id="tag_label_transaction_Src_new">
                            Job No
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1" TabIndex="1"
                                OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged" AutoPostBack="True" >
                            </asp:DropDownList>
                        </div>
                        <%--<div id="tag_label_transaction_popup_IGM2_empty">
                        </div>--%>
                       <%-- <div id="tag_label_transaction_popup_gen_export">
                            Select Type
                        </div>
                        <div id="txt_trans_exp_drawback">
                             <asp:DropDownList ID="ddlType" runat="server" CssClass="listtxt_transac_src1" TabIndex="2"
                                 AutoPostBack="true" onselectedindexchanged="ddlType_SelectedIndexChanged" >
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>DutyFree</asp:ListItem>
                                <asp:ListItem>Drawback</asp:ListItem>
                                 <asp:ListItem>Bill Of Export</asp:ListItem>

                                </asp:DropDownList>
                        </div>--%>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen_export">
                            InvoiceNo & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_InvoiceNo_Date" runat="server" MaxLength="15" ClientIDMode="Static"
                                TabIndex="3" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width:100px"></div>
                        <%--<div id="tag_label_transaction_popup_IGM2_empty">
                        </div>--%>
                       
                        <div id="txtcon-m_transaction_code">
                           <%-- <a href="#" class="generate" id="btn_Report" runat="server" style="display: block;"
                                onclick="open_jobno();return false;"></a>--%>
                        </div>

                        <div id="tag_label_transaction_popup_gen2"></div>
                    </div>
                    <%-- ------------------------%>
                    <div id="tag_Exchange_lft_in1_new1" style="margin-top: 10px;">
                        <div id="tag_label_transaction_Src_new">
                        </div>
                        <div id="txtcon-m_transaction_code">
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen_export">
                           ShippingBill No & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_ShippingBillNo_Date" runat="server" MaxLength="25" ClientIDMode="Static"
                                TabIndex="4" CssClass="txtbox_trans_exp_drawback"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen2">
                            Exporter's Ref
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtExporters_References" runat="server" MaxLength="25" ClientIDMode="Static"
                                TabIndex="5" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                         <div id="txtcon-m_transaction_code">
                            <a href="#" class="generate" id="btn_Report" runat="server" style="display: block;"
                                onclick="open_jobno();return false;"></a>
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new" style="background-image: none">
                <div class="content" id="page-1" style="overflow: scroll; height: 430px; width: 960px;">

                    <div id="pop_text_area_transac_popup_inn_container_export1" style="height: 380px;"
                        runat="server">
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Exporter,Whether Govt or Private
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtExporter" runat="server" MaxLength="40" ClientIDMode="Static"
                                    TabIndex="6" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                AR4 No & AR Date
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txtAR_No_Date" runat="server" MaxLength="15" ClientIDMode="Static" TabIndex="19" Width="141px"
                                    CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                            </div>

                                         <div id="txtcon-m_transaction_code">
                            
                                    <asp:TextBox ID="txtAR_No_Date2" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="15" TabIndex="20"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender1"
                                        runat="server" TargetControlID="txtAR_No_Date2" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtAR_No_Date2"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txtAR_No_Date2" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                         

                            </div>  

                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtEx_Address1" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="7" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            Q.Cert No & Date
                            </div>
                           <%-- <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_QCertNo_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>--%>

                             <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_QCertNo_Date" runat="server" MaxLength="15" ClientIDMode="Static" TabIndex="21" Width="141px"
                                    CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                            </div>

                                         <div id="txtcon-m_transaction_code">
                            
                                    <asp:TextBox ID="txt_QCertNo_Date2" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="15" TabIndex="22"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender2"
                                        runat="server" TargetControlID="txt_QCertNo_Date2" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_QCertNo_Date2"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_QCertNo_Date2" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                         

                            </div>  

                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtEx_Address2" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="8" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                             TB No & Date
                            </div>
                             <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_TBNo" runat="server" MaxLength="15" ClientIDMode="Static" TabIndex="23" Width="141px"
                                    CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                                     </div>
                                     <div id="txtcon-m_transaction_code">
                            
                                    <asp:TextBox ID="txt_TB_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="15" TabIndex="24"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender3"
                                        runat="server" TargetControlID="txt_TB_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_TB_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_TB_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>                       
                            </div>  

                            </div>
                       <%-- </div>--%>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtEx_Address3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                             IGM No
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txtIGMNo" runat="server" MaxLength="15" ClientIDMode="Static" TabIndex="25" Width="141px"
                                    CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                            </div>
                             <div id="txtcon-m_transaction_code">
                            
                                    <asp:TextBox ID="txt_IGM_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="15" TabIndex="26"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender5"
                                        runat="server" TargetControlID="txt_IGM_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_IGM_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_IGM_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>                       
                            </div>  
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtEx_Address4" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="10"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            Export Trade Control
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                               <asp:TextBox ID="txt_Export_Trade" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="27" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtEx_Address5" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="11"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                         <asp:Label ID="lblVesselFlight" runat="server" text="Vessel/Flight No"></asp:Label>
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                              <asp:TextBox ID="txtVessel_Flight_No" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="28"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Consignee
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="40" TabIndex="12"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                             Import-Export Code No & BIN
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                               <asp:TextBox ID="txt_Import_Export_BIN" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="29" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add1" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                           State of Origin Goods
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                           <asp:TextBox ID="txt_RBICodeNo" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="15" TabIndex="30"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                          
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="width: 110%; height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add2" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="14"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            <asp:Label ID="lblRotation" runat="server" Text="Rotation No"></asp:Label>
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                            
                                   <asp:TextBox ID="txt_Rotation_No" runat="server" MaxLength="35" ClientIDMode="Static" TabIndex="31"
                                    CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="15"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                          Custom House Agent
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                              <asp:TextBox ID="txt_CustomHouseAgent" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="32"></asp:TextBox>
                            </div>
                        </div>

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; ">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add4" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="16"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                           LIC No
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                               <asp:TextBox ID="txt_LIC_No" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="33"></asp:TextBox>
                            </div>
                        </div>

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; height: 40px;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add5" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="17"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            <asp:Label ID="lbl_Place_Of_precarrier" runat="server" Text="Place of Receipt Precarrier"></asp:Label>                                   
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtPlace_ReceiptBy_PreCarrier" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="34" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>

                    

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Port of loading
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtPort_Of_Loading" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="17"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">                            
                               Country Final Destination
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                               <asp:TextBox ID="txtCountry_Final_Destination" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="35" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>                            
                        </div>   
                        
                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; height: 40px;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            Port Of Discharge
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_PortDischarge" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="18"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                         <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                           <asp:Label ID="Label2" runat="server" Text="Pre-CarriageBy"></asp:Label>
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_PrecarriageBy" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="36" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                                           
                  </div>

                
                  

                    <div id="tab2" runat="server">
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb">
                            If Exporter's Under
                            </div>

                            <div id="magnify_area">                              
                               
                            </div>

                            <div id="txtcon-m_transaction_pop_gen1" style="width:500px">

                             <asp:RadioButtonList ID="RadioButton_Exporters" runat="server"     
                                        RepeatDirection="Horizontal"  TabIndex="17">
                                     
                                        <asp:ListItem id="DeferredCredit" Text="Deferred Credit" Value="DeferredCredit" class="ListControl" name="q22" ></asp:ListItem>
                                        <asp:ListItem id="JointVentures" Text="Joint Ventures" Value="JointVentures" class="ListControl"></asp:ListItem>
                                        <asp:ListItem Text="Rupees Credit" Value="RupeesCredit" class="ListControl" ></asp:ListItem>
                                        <asp:ListItem Text="Others" Value="Others" class="ListControl" ></asp:ListItem>

                                    </asp:RadioButtonList>
                            </div>
                              <div id="txt_trans_exp_drawback">
                             <asp:TextBox ID="txt_exp_others" runat="server"  CssClass="txtbox_trans_exp_drawback" MaxLength="30" TabIndex="37"></asp:TextBox>
                            </div>

                        </div>

                    
                  
                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb">
                                Nature Of Contract
                            </div>

                             <div id="magnify_area">                             
                             </div>

                            <div id="txtcon-m_transaction_pop_gen1" style="width:500px">

                             <asp:RadioButtonList ID="RadioButton_Nature" runat="server"     
                                        RepeatDirection="Horizontal"  TabIndex="17">
                                     
                                        <asp:ListItem Text="CIF" Value="CIF" class="ListControl" ></asp:ListItem>
                                        <asp:ListItem Text="CFR" Value="CFR" class="ListControl"></asp:ListItem>
                                        <asp:ListItem Text="FOB" Value="FOB" class="ListControl" ></asp:ListItem>
                                        <asp:ListItem Text="Others" Value="Others" class="ListControl" ></asp:ListItem>

                                    </asp:RadioButtonList>
                            </div>
                              <div id="txt_trans_exp_drawback">
                             <asp:TextBox ID="txt_NatureOfOthers" runat="server"  CssClass="txtbox_trans_exp_drawback" MaxLength="30" TabIndex="38"></asp:TextBox>
                            </div>
                        </div>

                    

                                <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb">
                                Type of Shipment
                            </div>

                            <div id="magnify_area"></div>


                             <div id="txtcon-m_transaction_pop_gen1" style="width:500px">

                             <asp:RadioButtonList ID="RadioButton_Ship" runat="server"     
                                        RepeatDirection="Horizontal"  TabIndex="17">
                                     
                                        <asp:ListItem Text="OutRight Sales" Value="OutRightSales" class="ListControl" ></asp:ListItem>
                                        <asp:ListItem Text="Consignment Export" Value="ConsignmentExport" class="ListControlWidth"></asp:ListItem>
                                        <asp:ListItem Text="Others" Value="Others" class="ListControl" ></asp:ListItem>

                                    </asp:RadioButtonList>
                            </div>
                              <div id="txt_trans_exp_drawback">
                             <asp:TextBox ID="txt_Ship_Others" runat="server"  CssClass="txtbox_trans_exp_drawback" MaxLength="30" TabIndex="39"></asp:TextBox>
                            </div>

                          
                        </div>

                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;"></div>

                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 180px;">
                               ExchangeRate U/S 14 of CA
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_Ex_Rate_US" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="40"></asp:TextBox>
                            </div>

                            <div id="magnify_area"></div>
                           
                            <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                                Currency Of Invoice
                            </div>
                            <div id="txt_trans_exp_drawback">

                            <div id="txtcon-m_transaction_item_maindet"  style="width: 255px;">
                             <asp:TextBox ID="txt_InvoiceCurrency" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" MaxLength="35" TabIndex="41"></asp:TextBox>
                          
                            <asp:TextBox ID="txt_InvoiceAmount1" runat="server" ClientIDMode="Static" Width="100px"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="42"></asp:TextBox>
                            </div>
                            </div>
                            
                        </div>

                          <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 180px;">
                               RBI's Approval/cir No & Date
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txt_RBIApprovalNo" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="43"></asp:TextBox>
                            </div>
                            </div>
                           
                        <%--<div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            </div>--%>

                               <%-- <div id="tag_transac_exp_drawback_1" runat="server" style="overflow:scroll; width:930px; height:250px;">--%>

                                 <div id="tag_transac_export_lft_item_gen_Grid_area_Exbond" style="height: 175px;
                            margin-bottom: 0px; width: 950px">

                            <asp:GridView runat="server" ID="GV_Details" EmptyDataText="No Records Found"  
                        AutoGenerateColumns="false"  CssClass="grid-view" ShowHeader="true" OnPageIndexChanging="GV_Details_PageIndexChanging"
                        ShowHeaderWhenEmpty="true" Width="100%"   OnRowDataBound="GV_Details_RowDataBound1"  BorderStyle="Solid" BorderWidth="1px"
                         CellPadding="1" CellSpacing="1" OnRowCreated="GV_Details_RowCreated" HorizontalAlign="Left" AllowSorting="true"   OnSelectedIndexChanged="GV_Details_SelectedIndexChanged">
                        
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" 
                            BorderWidth="1px" />
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>

                                <asp:TemplateField HeaderText="SlNo" >
                                       <%-- <ItemTemplate>
                                                <asp:TextBox ID="txt_ItemSlNo"  runat="server" Text='<%# Bind("id") %>' OnTextChanged="TextBox_TextChanged"
                                               Width="50px" ></asp:TextBox>
                                        </ItemTemplate>--%>

                                        <ItemTemplate>
                                               
                                           <asp:TextBox ID="txt_ItemSlNo"  runat="server" Text='<%# Container.DataItemIndex + 1 %>' OnTextChanged="TextBox_TextChanged"
                                               Width="20px" ></asp:TextBox>
                                            </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Marks & No">
                                        <ItemTemplate>
                                      <%--  <asp:Label ID="LblMarks" runat="server" Text="Mawbno" ></asp:Label>--%>
                                                <asp:TextBox ID="txt_MARKS_NO"  runat="server" Text='<%# Bind("MARKS_NO") %>' OnTextChanged="TextBox_TextChanged"
                                               Width="200px" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Statistical Code and Description of Goods and EXIM Scheme" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_ITEM_DESCRIPTION"  runat="server" Text='<%# Bind("ITEM_DESCRIPTION") %>' OnTextChanged="TextBox_TextChanged"
                                              Width="375px"  ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Quantity" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_ITEM_QTY"  runat="server" Text='<%# Bind("ITEM_QTY") %>'  OnTextChanged="TextBox_TextChanged"
                                              Width="105px"  ></asp:TextBox>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <%-- <asp:TemplateField HeaderText="QtyCode" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_ITEM_QTY_CODE"  runat="server" Text='<%# Bind("ITEM_QTY_CODE") %>' OnTextChanged="TextBox_TextChanged"
                                              Width="100px"  ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                     <asp:TemplateField HeaderText="FOB    PMV Where applicable" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_FOB_VALUE"  runat="server" Text='<%# Bind("FOB_VALUE") %>' OnTextChanged="TextBox_TextChanged"
                                              Width="200px"  ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                        </asp:GridView>
                        </div>
              


                        <div id="innerbox_MidMain_bot_transact" style="height: 8px; font-weight: normal;
                            margin-top: 0;">
                            </div>

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 95px;">
                              NetWeight
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_NetWeight" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="25" TabIndex="44"></asp:TextBox>
                            </div>

                            <div id="magnify_area"></div>
                           
                            <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                                GrossWeight
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_GrossWeight" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_code" MaxLength="25" TabIndex="45"></asp:TextBox>
                            </div>                           
                        </div>


                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 95px;">
                               FOB in Words
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width: 100px; height:10px">

                            <asp:TextBox ID="txtFOB_In_Words" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="100" TabIndex="46" Width="580px"></asp:TextBox>
                           
                              </div>
                        </div>

                         
                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                             
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                               Currrency
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 155px;">
                             Amount
                            </div>

                            <div id="magnify_area"></div>
                           
                                                    
                        </div>


                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                             CIF/CF/CI/FOB
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                             <asp:TextBox ID="txt_CIF_FOB_Currency" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" MaxLength="35" TabIndex="47"></asp:TextBox>
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 155px;">
                            <asp:TextBox ID="txt_CIF_FOB_Amount" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="48"></asp:TextBox>
                            </div>

                            <div id="magnify_area"></div>
                           
                            <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                                BillOfEntry No
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_BillOfEntryNo" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_code" MaxLength="35" TabIndex="61" ></asp:TextBox>
                            </div>   

                             <div id="magnify_area"></div>
                           
                            <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                              <%--  <asp:Label ID="lbl_Tarrif" runat="server" Text="BillOfEntry Date"></asp:Label>--%>
                              BillOfEntry Date
                                
                            </div>
                            <div id="txtcon-m_transaction_code">
                              
                                    <asp:TextBox ID="txt_BillOfEntryDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="15" TabIndex="62"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender6"
                                        runat="server" TargetControlID="txt_BillOfEntryDate" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_BillOfEntryDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_BillOfEntryDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>                       
                            </div>  
                            </div>                      
                      

                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                             FOB Value
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                             <asp:TextBox ID="txtFOBValue_Currency" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" MaxLength="35" TabIndex="49"></asp:TextBox>
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 155px;">
                            <asp:TextBox ID="txtFOBValue_Amount" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="50"></asp:TextBox>
                            </div>

                            <div id="magnify_area"></div>
                           
                            <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                                Bond No
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_BondNo" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_code" MaxLength="35" TabIndex="63"></asp:TextBox>
                            </div>  
                            
                            <div id="magnify_area"></div>
                           
                            <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                                <asp:Label ID="lbl_Assesable_Value" runat="server" Text="Bond Date"></asp:Label>

                                
                            </div>
                            <div id="txtcon-m_transaction_code">
                               
                                      <asp:TextBox ID="txt_BondDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="15" TabIndex="64"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender7"
                                        runat="server" TargetControlID="txt_BondDate" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_BondDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_BondDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>  
                            </div>
                                                     
                        </div>


                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                             Freight
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                             <asp:TextBox ID="txtFreight_Currency" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" MaxLength="35" TabIndex="51"></asp:TextBox>
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 155px;">
                            <asp:TextBox ID="txtFreight_Amount" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="52"></asp:TextBox>
                            </div>

                            <div id="magnify_area"></div>
                           
                            <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                                GR No
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_GR_No" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_code" MaxLength="15" TabIndex="65"></asp:TextBox>
                            </div> 
                            <div id="magnify_area"></div>
                             <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                                <asp:Label ID="lbl_GI_BondNo" runat="server" Text="No Of Pkgs"></asp:Label>

                                
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_NoOfPkgs" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_code" MaxLength="25" TabIndex="66" ></asp:TextBox>
                            </div>
                                                     
                        </div>


                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                             Insurance
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                             <asp:TextBox ID="txtInsurance_Currency" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" MaxLength="35" TabIndex="53"></asp:TextBox>
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 155px;">
                            <asp:TextBox ID="txtInsurance_Amount" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="54"></asp:TextBox>
                            </div>

                            <div id="magnify_area"></div>
                           
                            <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                                VesselName
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_VesselName" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_code" MaxLength="35" TabIndex="67"></asp:TextBox>
                            </div>  
                            
                            <div id="magnify_area"></div>
                             <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                                <asp:Label ID="lbl_Duty_Perc" runat="server" Text="RotationNo"></asp:Label>
                                
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_RotationNo" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_code" MaxLength="35" TabIndex="68" ></asp:TextBox>
                            </div>
                                                     
                        </div>


                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                             Commission
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                             <asp:TextBox ID="txtCommission_Currency" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" MaxLength="35" TabIndex="55"></asp:TextBox>
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 155px;">
                            <asp:TextBox ID="txtCommission_Amount" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="56"></asp:TextBox>
                            </div>

                            <div id="magnify_area"></div>
                           
                            <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                             
                            </div>
                            <div id="txtcon-m_transaction_code">
                                
                            </div>     
                            
                            <div id="magnify_area"></div>
                           
                          
                                                  
                        </div>


                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                             Discount
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                             <asp:TextBox ID="txtDiscount_Currency" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" MaxLength="35" TabIndex="57"></asp:TextBox>
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 155px;">
                            <asp:TextBox ID="txtDiscount_Amount" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="58"></asp:TextBox>
                            </div>

                            <div id="magnify_area"></div>
                           
                            <div id="tag_label_transaction_popup_IGM" style="width: 200px;">
                            <asp:Label ID="lbl_PublicNoticeno" runat="server" Text=" Name of the Bonded WareHouse"></asp:Label>
                                
                            </div>
                        
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_WareHouseName" runat="server" ClientIDMode="Static" Width="200Px"
                                    CssClass="txtbox_none_Mid_transac_code" MaxLength="35" TabIndex="69" ></asp:TextBox>
                            </div>
                                                  
                        </div>
                       

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                             Other Deduction
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                             <asp:TextBox ID="txt_Otherdeduction_Currency" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" MaxLength="35" TabIndex="59"></asp:TextBox>
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 155px;">
                            <asp:TextBox ID="txt_Otherdeduction_Amount" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="60"></asp:TextBox>
                            </div>

                            <div id="magnify_area"></div>

                             <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                            <asp:Label ID="Label1" runat="server" Text="Bond No" Visible="false"></asp:Label>
                                
                            </div>
                             <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="TextBox1" runat="server" ClientIDMode="Static" Visible="false"
                                    CssClass="txtbox_none_Mid_transac_code" MaxLength="35" TabIndex="64"></asp:TextBox>
                            </div>     
                           <div id="magnify_area"></div>
                            <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                              
                            </div>
                            <div id="txtcon-m_transaction_code">
                             
                                    <asp:TextBox ID="txt_public_Date" runat="server" CssClass="txtbox_none_Mid_transac_code" Visible="false"
                                    MaxLength="30" TabIndex="66"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender4"
                                        runat="server" TargetControlID="txt_public_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_public_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_public_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                         

                            </div>                           
                        </div>

                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others">
                         <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="height: 15px; font-weight: normal;
                            margin-top: 0;">
                        
                        </div>
                        </div>

                    </div>
                    <!-- Buttons Place Here -->
                    <div id="innerbox_MidMain_bot_transact_invoice" style="margin-top: 5px;">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide');"
                                TabIndex="35" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate_Invoice();"
                                TabIndex="70" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                Visible="false" OnClientClick="return validate_Invoice();" TabIndex="71" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="72" CausesValidation="false"
                                Visible="false" UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'TB ShippingBill', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="37" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="win_hide();parent.adcodewindow.hide();return false;"
                                TabIndex="72" CausesValidation="false" UseSubmitBehavior="false" />
                            <%--<input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()"
                            tabindex="38" id="btnCancel" />--%></div>
                        <div id="editbu">
                            <asp:Button ID="btn_next" runat="server" CausesValidation="false" UseSubmitBehavior="false" 
                                CssClass="autowidmovebut" Text=">>" OnClientClick="jQuery('#form1').validationEngine('hide');btn_move_next();return false;" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btn_prev" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                Style="display: none;" CssClass="autowidmovebut" Text="<<" OnClientClick="jQuery('#form1').validationEngine('hide');btn_move_prev();return false;" />
                        </div>
                    </div>
                    <!-- Buttons Place Here -->
                     <asp:Button ID="btngrid_delete" runat="server" Style="display: none;"
                        OnClientClick="jConfirm('Delete this Entry?', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('Button2').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="Button2" runat="server" TabIndex="116"  CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="dlete" Style="display: none;"  />
                </div>
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                    <asp:HiddenField ID="hdn_invgrid_itemId" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdn_isvalue" runat="server" />
                    <asp:HiddenField ID="hdn_val" runat="server" />
                   
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
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
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        // Select/Deselect checkboxes based on header checkbox
        function SelectheaderCheckboxes(headerchk, gv, button) {
            debugger
            var gvcheck = document.getElementById(gv);
            var i;
            //Condition to check header checkbox selected or not if that is true checked all checkboxes
            if (headerchk.checked) {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;
                }
                document.getElementById(button).click();

            }
            //if condition fails uncheck all checkboxes in gridview
            else {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
        //function to check header checkbox based on child checkboxes condition
        function Selectchildcheckboxes(header, gv, button) {
            var ck = header;
            var count = 0;
            var gvcheck = document.getElementById(gv);
            var headerchk = document.getElementById(header);
            var rowcount = gvcheck.rows.length;
            //By using this for loop we will count how many checkboxes has checked
            for (i = 1; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                if (inputs[0].checked) {
                    document.getElementById(button).click();
                    count++;
                }
            }
            //Condition to check all the checkboxes selected or not
            if (count == rowcount - 1) {
                headerchk.checked = true;

            }
            else {
                headerchk.checked = false;
            }
        }
</script>
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
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        function call_delete_button() {
            //document.getElementById("btngrid_elete").click();
            jConfirm('Delete this Entry?', 'INVOICE', function (r) {
                var i = r + 'ok';
                if (i == 'trueok') {

                    return true;

                }
                else {
                    return false;
                }

            }); 
        }
        function ConfirmationBox() {


            var result = confirm('Are you sure you want to delete  Details?');
            if (result) {

                return true;
            }
            else {
                return false;
            }
        }

        
        
    </script>
    <script type="text/javascript">

        function open_jobno() {

            if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {


                    var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                    NewWindow1('../Report/Import_TB_ShippingBill_Report_viewer.aspx?jobno=' + f + '', 'List', '870', '1024', 'yes');

//                    NewWindow1('../Report/Export_ManualSB_Report_viewer.aspx?jobno=' + f + '&Type=' + LCD + '', 'List', '870', '1024', 'yes');


                    //opennew_Import_report(f);
                    return false
                    //alert(f);
                }
            }

        }

        function btn_move_next() {

            document.getElementById("tab2").style.display = 'block';
            document.getElementById("pop_text_area_transac_popup_inn_container_export1").style.display = 'none';
            document.getElementById("btn_next").style.display = 'none';
            document.getElementById("btn_prev").style.display = 'block';

        }
        function btn_move_prev() {

            document.getElementById("tab2").style.display = 'none';
            document.getElementById("pop_text_area_transac_popup_inn_container_export1").style.display = 'block';
            document.getElementById("btn_next").style.display = 'block';
            document.getElementById("btn_prev").style.display = 'none';

        }
        function EnterEvent(e) {
            if (e.keyCode == 13) {

                document.getElementById('btn_Add1').click();

            }

        }
        function EnterEvent1(e) {
            if (e.keyCode == 13) {

                document.getElementById('btn_Remove1').click();

            }

        }
        function EnterEvent3(e, e1) {
            if (e.keyCode == 13) {

                document.getElementById('hdn_invgrid_itemId').value = e1;
                document.getElementById('btnGridUpdate').click();
            }

        }
        function EnterEvent03(e, e1) {
            if (e.keyCode == 13) {

                document.getElementById('hdn_invgrid_itemId').value = 'b';
                document.getElementById('btnGridUpdate').click();
            }

        }
    </script>
</body>
</html>
