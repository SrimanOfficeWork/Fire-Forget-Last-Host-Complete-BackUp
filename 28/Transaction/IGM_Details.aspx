<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IGM_Details.aspx.cs" Inherits="Transaction_IGMDetails_new" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ADCode Master | Updation</title>
<%--       <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />--%>

    <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />

    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
        
          .mand-tooltip {
    position: absolute;
    background: #2a7ab5;
    color: #fff;
    font-size: 11px;
    font-weight: 600;
    padding: 2px 7px;
    border-radius: 3px;
    z-index: 9999;
    white-space: nowrap;
    pointer-events: none;
    line-height: 16px;
    border: 2px solid #1a5a8a; /* ✅ slightly darker blue border */
    outline: 1px solid #5aaee8; /* ✅ light blue outer glow */
}
.mand-tooltip:after {
    content: '';
    position: absolute;
    top: 100%;
    right: 8px;
    left: auto;
    border-width: 4px 4px 0;
    border-style: solid;
    border-color: #1a5a8a transparent transparent; /* ✅ matches border color */
}
        
       
        
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
       
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }

</script>

  <script type="text/javascript">
      $(document).ready(function () {
          $('#chk_MBL').change(function () {
              if ($(this).is(":checked")) {
                  var hdn_Transport_Mode = document.getElementById("hdn_Transport_Mode").value;
                  var hdn_filling_status = document.getElementById("hdn_filling_status").value;

                  if (hdn_filling_status == 'Advanced' || hdn_filling_status === 'Prior') {
                      if (hdn_Transport_Mode == 'Air') {
                          $('#txtMAWBMBLNo').val('NOMAWB');
                      }
                      else {
                          $('#txtMAWBMBLNo').val('NOMBL');
                      }
                  }
              }
          });
      });
   

  </script>


<script type="text/javascript">
    $(document).ready(function () {

        // document.onkeydown = clickRadio;
        document.onkeypress = click_TABS;
        document.onkeyup = click_TABS;

        function click_TABS(e) {
            //if (window.event);
            if (window.event.ctrlKey)
                var keyCode = window.event.keyCode;       // IE

            else
                var keyCode = e.which;
            if (e.ctrlKey) {
                if (keyCode == 39) {
                    document.getElementById("hdn_source").value = 'Tab_IGM';
                    document.getElementById('btnCancel').click();
                }

                if (keyCode == 37) {
                    document.getElementById("hdn_source").value = 'Tab_IGM_Prev';
                    document.getElementById('btnCancel').click();
                }
            }
        }
    });
</script>

<style type="text/css">
    .modalPopup12
    {
        background-color: transparent;
        width: 940px;
        height: 180px;
    }
</style>

<script type="text/javascript">
    function SelectEtaScheduleRow(obj) {
        var grid = obj.closest("table");
        if (!grid) return;

        var checkboxes = grid.querySelectorAll("input[type='checkbox']");
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i] !== obj) {
                checkboxes[i].checked = false;
            }
        }
    }
</script>


<style type="text/css">
    /* =========================================================
       IGM ETA VESSEL SCHEDULE POPUPS
       Same compact style as the existing IGM grid
       ========================================================= */

    .etaSchedulePopup
    {
        position: fixed !important;
        left: 36% !important;
        top: 50% !important;
        transform: translate(-50%, -50%) !important;

        width: 850px !important;
        max-width: 92vw !important;
        max-height: 75vh !important;

        background-color: #ffffff !important;
        border: 1px solid #888888 !important;
        z-index: 999999 !important;

        padding: 0 !important;
        margin: 0 !important;
        overflow: hidden !important;
        box-sizing: border-box !important;
    }

    .etaScheduleTitle
    {
        height: 40px;
        line-height: 40px;
        padding-left: 10px;
        background-color: #ffffff;
        color: Blue;
        font-family: Arial, Helvetica, sans-serif;
        font-size: 16px;
        font-weight: bold;
        border-bottom: 1px solid #cccccc;
        white-space: nowrap;
        overflow: hidden;
        text-overflow: ellipsis;
    }

    .etaScheduleGridWrap
    {
        width: 100%;
        max-height: calc(75vh - 90px);
        overflow-x: auto;
        overflow-y: auto;
        padding: 8px;
        box-sizing: border-box;
        background-color: #ffffff;
    }

    .etaScheduleGrid
    {
        width: max-content !important;
        min-width: 100% !important;
        border-collapse: collapse !important;
        font-family: Arial, Helvetica, sans-serif !important;
        font-size: 12px !important;
        color: #000000 !important;
    }

    .etaScheduleGrid th
    {
        background-color: AliceBlue !important;
        color: #000000 !important;
        font-family: Arial, Helvetica, sans-serif !important;
        font-size: 12px !important;
        font-weight: bold !important;
        border: 1px solid #aaaaaa !important;
        padding: 5px 7px !important;
        white-space: nowrap !important;
        text-align: left !important;
    }

    .etaScheduleGrid td
    {
        background-color: #ffffff !important;
        color: #000000 !important;
        font-family: Arial, Helvetica, sans-serif !important;
        font-size: 12px !important;
        border: 1px solid #aaaaaa !important;
        padding: 4px 7px !important;
        white-space: nowrap !important;
        vertical-align: middle !important;
    }

    .etaScheduleGrid input[type="checkbox"]
    {
        width: 13px !important;
        height: 13px !important;
        margin: 0 !important;
        vertical-align: middle !important;
    }

    .etaScheduleButtons
    {
        height: 50px;
        width: 100%;
        text-align: center;
        padding-top: 9px;
        background-color: #ffffff;
        border-top: 1px solid #cccccc;
        box-sizing: border-box;
    }

    .etaScheduleButtons input
    {
        width: 80px !important;
        height: 27px !important;
        margin: 0 5px !important;
        font-family: Arial, Helvetica, sans-serif !important;
        font-size: 11px !important;
        cursor: pointer !important;
    }

    .etaScheduleModalBackground
    {
        background-color: #000000 !important;
        opacity: 0.35 !important;
        filter: alpha(opacity=35) !important;
        z-index: 999990 !important;
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
            <div id="innerbox_MidMain_Trans_IGM">
                <ol id="toc">
                    <li style="height:20px"><a href="#page-1" onclick="tab_page1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="IGM"><span>IGM Details </span></a></li>
                    <li style="height:20px"><a href="#page-2" onclick="tab_page2('0'); jQuery('#form1').validationEngine('hideAll')"
                        style="display: none;" id="CONTAINER" runat="server"><span>Container</span></a></li>
                    <li style="height:20px"><a href="#page-3" onclick="tab_page3('0'); jQuery('#form1').validationEngine('hideAll')" id="IGM_Bond">
                        <span>Bond</span></a></li>
                    <li style="height:20px"><a href="#page-4" onclick="tab_page4('0'); jQuery('#form1').validationEngine('hideAll')" id="IGM_certificate">
                        <span>Certificate</span></a></li>

                        
                </ol>
                <div class="content" id="page-1">
                    <%--<iframe src="IGM_Main.aspx" name="trans_igm_details" scrolling="no" id="trans_IGM_details_Main_Cont_iframe"></iframe>--%>
                    <div id="trans_IGM_details_Main_Cont1">
                        <div id="pop_text_area_transac_popup_inn_container_IGM" style="height:150px; margin-left:0px; width:930px;">
                            <div id="pop_text_area_transac_popup_inn_container_left_IGM" style="height:150px;width:500px;">
                                <div id="tag_transac_lft_IGM_in1">
                                    <div id="tag_label_transaction_popup_IGM">
                                        Airline</div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew">
                                        <asp:TextBox ID="txtAirlineName" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_IGM_Air_namenew"
                                            MaxLength="20" onkeypress="return charnum2(event)" TabIndex="7"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="txtcon-m_transaction_Aircode">
                                        <asp:TextBox ID="txtAirlineCode" runat="server" MaxLength="2" ClientIDMode="Static"
                                            CssClass="txtbox_none_Mid_Airline_code" TabIndex="6" onkeypress="return charnum1(event)"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="OpenPopup_Airline_Details_new();" class="magnfy"></a>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_IGM_in1" style="width:510px;">
                                    <div id="tag_label_transaction_popup_IGM">
                                        Flight No/ Vessel No
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtFlightVesselNo" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="20" TabIndex="8" onkeypress="return charnum2(event)"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label2_transaction_popup_IGM">
                                        Flight/ Inward Date
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width:80px;">
                                        <asp:TextBox ID="txtFlightVesselDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="10" TabIndex="9" Width="75px"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtFlightVesselDate"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFlightVesselDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                       
                                        <%--<asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/INDEV/Hrs.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>
                                         <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/INDEV/Mins.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>

                                        <asp:DropDownList ID="ddlhrs_Cleared_dat"   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Cleared_dat" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" ></asp:DropDownList>--%>
                                    </div>
                                    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/INDEV/Hrs.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>
                                         <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/INDEV/Mins.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>

                                        <asp:DropDownList ID="ddlhrs_FV_dat"   runat="server" CssClass="listtxt_transac_mode_new" Width="39px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                                          <asp:DropDownList ID="ddlMin_FV_dat" runat="server" CssClass="listtxt_transac_mode_new" Width="39px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" ></asp:DropDownList>
                                </div>
                                <div id="tag_transac_lft_IGM_in1">
                                    <div id="tag_label_transaction_popup_IGM">
                                        IGM No
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtIGMNo" runat="server" MaxLength="7" CssClass="validate[custom[integer]] txtbox_none_Mid_transac_code"
                                            onkeypress="return num1(event)" TabIndex="10"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label2_transaction_popup_IGM">
                                        IGM Date
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtIGMDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="10" TabIndex="11"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtIGMDate"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtIGMDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <%--    <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator2" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ForeColor="Red" Display="None" ValidationGroup="dt"
                                runat="server" ControlToValidate="txtIGMDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                        --%>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_IGM_in1">
                                    <div id="tag_label_transaction_popup_IGM" style="width: 125px;">
                                        <asp:Label ID="lbl_mbl" Text="MAWB/ MBL No" runat="server"></asp:Label>
                                        <asp:CheckBox ID="chk_MBL" runat="server" ToolTip="MBL/MAWB - Not Avail" />
                                    </div>
                                    
                                    <div id="txtcon-m_transaction_code">
                                        <%--<asp:TextBox ID="txtMAWBMBLNo" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="12" onkeypress="return charnum2(event)" onblur="MAWB_VALIDATION()"
                                            AutoPostBack="True"  ontextchanged="txtMAWBMBLNo_TextChanged"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtMAWBMBLNo" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="12" onkeypress="return charnum2(event)" onblur="MAWB_VALIDATION()"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label2_transaction_popup_IGM">
                                        MAWB/ MBL Date
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtMAWBMBLDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="10" TabIndex="13" onblur="validateDate(this,'MAWB')"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtMAWBMBLDate"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtMAWBMBLDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <%-- <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RegularExpressionValidator3" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ForeColor="Red" Display="None" ValidationGroup="dt"
                                runat="server" ControlToValidate="txtMAWBMBLDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                        --%>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_IGM_in1">
                                    <div id="tag_label_transaction_popup_IGM">
                                        HAWB/ HBL No
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtHAWBHBLNo" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="14" onkeypress="return charnum2(event)"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label2_transaction_popup_IGM">
                                        HAWB/ HBL Date
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtHAWBHBLDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="10" TabIndex="15" onblur="validateDate(this,'HAWB')"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtHAWBHBLDate"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtHAWBHBLDate"
                                            Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                        </asp:CalendarExtender>
                                        <%--<asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RegularExpressionValidator4" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ForeColor="Red" Display="None" ValidationGroup="dt"
                                runat="server" ControlToValidate="txtHAWBHBLDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                                        --%>
                                    </div>
                                </div>


                                <div id="tag_transac_lft_IGM_in1">
                                    <div id="tag_label_transaction_popup_IGM">
                                      Line Number
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txt_LineNumber" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="23" ></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label2_transaction_popup_IGM">
                                       Shipping Line
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txt_ShippingLine" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="30" TabIndex="23"></asp:TextBox>
                                       
                                        
                                    </div>
                                </div>

                            </div>


                            <div id="pop_text_area_transac_popup_inn_container_rght_IGM" style="height:150px; width:420px; margin-left:3px;">
                                <div id="tag_transac_rght_in1" style="width:420px;">
                                    <div id="tag_label_transaction_popup_IGM_Gen_Rght">
                                        Packages</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtPackages" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="8" TabIndex="16" onkeypress="return pin(event)"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="txtcon_m_transaction_IGM_Wght_small">
                                        <asp:TextBox ID="txtPackageType" runat="server" CssClass="txtbox_none_Mid_transac_IGM_wght_small"
                                            ClientIDMode="Static" MaxLength="3" TabIndex="17" onkeypress="return char1(event)"
                                            onblur="ChangeCase(this);"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="OpenPopup_Package_Details(); return false" class="magnfy"></a>
                                    </div>
                                    <%--<div id="txtcon_m_transaction_IGM_Wght_small" style="width:145px; text-align:right; font-weight:bold;" >
                                         <span id="lblTrk_IGM" title="IGM Tracking"  runat="server"  OnClick="IGM_Track();return false;"
                                        style="color:Blue;text-decoration:underline;cursor:hand; font-size:smaller;">IGM status </span>
                                    </div>--%>
                                      <div id="txtcon_m_transaction_IGM_Wght_small" style="width:145px; text-align:right; font-weight:bold;">
                                <span id="lblTrk_IGM" title="IGM Tracking" runat="server"
                                      onclick="IGM_Track(); return false;"
                                      style="color:Blue;text-decoration:underline;cursor:pointer; font-size:smaller;">
                                    IGM status
                                </span>
                                      </div>

                                </div>


                                <div id="tag_transac_rght_in1" style="width:420px;">
                                    <div id="tag_label_transaction_popup_IGM_Gen_Rght">
                                        Gross Weight
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtGrossWeight" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="12" TabIndex="18" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="txtcon_m_transaction_IGM_Wght_small">
                                        <asp:TextBox ID="txtGrossWeightType" runat="server" CssClass="txtbox_none_Mid_transac_IGM_wght_small"
                                            ClientIDMode="Static" MaxLength="3" TabIndex="19" onkeypress="return char1(event)"
                                            onblur="ChangeCase(this);"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="OpenPopupUnit('GrossWeight'); return false" class="magnfy">
                                        </a>
                                    </div>

                                    <div id="txtcon_m_transaction_IGM_Wght_small" style="width:145px; text-align:right; font-weight:bold;" >
                                         <span id="lbl_air_AwbStat" title="AwbStat"  runat="server"  OnClick="BE_AwbStat_ICDStat();return false;" visible="false"
                                        style="color:Blue;text-decoration:underline;cursor:hand; font-size:14px;">AWB status </span>

                                        <span id="lbl_Land_ICDStat" title="ICDStat"  runat="server"  OnClick="BE_AwbStat_ICDStat();return false;"
                                        style="color:Blue;text-decoration:underline;cursor:hand; font-size:14px;">ICD status </span>

                                        <%--<span id="lbl_air_status" title="AwbStat"  runat="server"  OnClick="BE_Track();return false;"
                                        style="color:Blue;text-decoration:underline;cursor:hand; font-size:14px;">AwbStat</span>--%>
                                          <div ID="txtcon_m_transaction_IGM_Wght_small" 
                                             style="width:145px; text-align:right; font-weight:bold">
                                             <asp:LinkButton ID="lnkETAUpdate" runat="server"
                                                 Text="ETA Update"
                                                 OnClick="ETA_Update_Click"
                                                 CausesValidation="false"
                                                 Style="color:Blue;text-decoration:underline;cursor:pointer;font-size:smaller;"
                                                 ToolTip="ETA Update" />
                                         </div>

                                    </div>
                                </div>
                                <div id="tag_transac_rght_in1" style="display: none;">
                                    <div id="tag_label_transaction_popup_IGM_Gen_Rght">
                                        Net Weight
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtNetWeight" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code"
                                            MaxLength="7" TabIndex="20" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="txtcon_m_transaction_IGM_Wght_small">
                                        <asp:TextBox ID="txtNetWeightType" runat="server" CssClass="validate[custom[onlyLetterSp,minSize[3]]] txtbox_none_Mid_transac_IGM_wght_small"
                                            ClientIDMode="Static" MaxLength="3" TabIndex="21" onkeypress="return char1(event)"
                                            onblur="ChangeCase(this);"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="OpenPopupUnit('Netweight'); return false" class="magnfy"></a>
                                    </div>
                                </div>

                                <div id="tag_transac_rght_in1">
                                    <div id="tag_label_transaction_popup_IGM_Gen_Rght">
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtChargable_Wgt" Visible="false" placeholder="Chr. Weight ...."
                                            runat="server" CssClass="txtbox_none_Mid_transac_code" MaxLength="12" TabIndex="20"
                                            onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>

                                <div id="tag_transac_rght_in1_margs_nos" style="margin-left:0px;">
                                    <div id="tag_label_transaction_popup_IGM_Gen_Rght_marks_nos">
                                        Marks &amp; Nos
                                    </div>
                                    <div id="txtcon_l_46px">
                                    </div>
                                    <div id="txtcon-m_46px" style="height:50px;">
                                        <asp:TextBox ID="txtMarksNos" runat="server" style="text-transform:uppercase" CssClass="txtbox_none_Mid_transac_Marks_nos" 
                                            TextMode="MultiLine" onkeyDown=" return (event.keyCode!=13); return checkTextAreaMaxLength(this,event,'300');"
                                            onpaste="return checkTextAreaMaxLength(this,event,'300');" MaxLength="300" TabIndex="22" Text="AS PER BL"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-r_46px">
                                    </div>
                                </div>
                                                                   

                                <div id="tag_transac_rght_in1">
                                    <div id="tag_label_transaction_popup_IGM_Gen_Rght">
                                       Voyage
                                    </div>
                                     <div id="txtcon_l_46px">
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                      <asp:TextBox ID="txt_Voyage" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="30" TabIndex="23"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                  
                                </div>

                                <div id="lblMsg2" style="display: none">
                                </div>
                            </div>






                            <div id="pop_text_area_transac_popup_inn_container_IGM_tag2" runat="server" visible="false" style="margin-top:0px;width:800px;">
                                <div id="tag_transac_IGM_gateway_main" style="margin-top:0px; width:800px;">
                                    <div id="tag_label_transaction_igm_gateway">
                                        <strong>Gateway-IGM No</strong>
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtGateway_Igm_No" runat="server" MaxLength="7" onkeyup="autotab(this);"
                                            CssClass="validate[custom[integer]] txtbox_none_Mid_transac_code" TabIndex="23"
                                            onkeypress="return num1(event)"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_igm_gateway">
                                        <strong>Gateway-IGM Date</strong></div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtGateway_Igm_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="24"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtGateway_Igm_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtGateway_Igm_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                        <%-- <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red" Display="None" ValidationGroup="dt"
                                runat="server" ControlToValidate="txtGateway_Igm_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_igm_gateway">
                                        <strong>Gateway-Port Code </strong>
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox runat="server" MaxLength="6" ONKEYPRESS="return numchar2(event)" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                            ID="txtGateway_Port_Code" ClientIDMode="Static" TabIndex="25"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="margin-top: 0px">
                            <div id="innerbox_transac_bot_inn" style="width: 500px;">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" TabIndex="29" CssClass="new" OnClick="btnNew_Click"
                                        OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                                        UseSubmitBehavior="false" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" ValidationGroup="dt"
                                        OnClientClick="return validation();" TabIndex="26" />
                                </div>
                                <div id="editbu">
                        <asp:Button ID="btn_save_new" Text="Save & New" CssClass="autowidupdatebut" TabIndex="30"
                            runat="server" OnClientClick="return validation();" OnClick="btn_save_new_Click" />
                              </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                                        OnClick="btnUpdate_Click" Visible="false" TabIndex="26" OnClientClick="return validation();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="27" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'IGM', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="27" CausesValidation="false" UseSubmitBehavior="false"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                                        CssClass="dlete" Style="display: none;" />
                                </div>
                                <div id="editbu">
                                    <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1_Trigger_AnotherPage('General',document.getElementById('hdn_source').value);return false;"
                                        id="btnCancel" tabindex="55">
                                </div>
                                <%--<div id="editbu">
                                 <span id="lblQuickview" title="All" runat="server" visible="false"  OnClick="IGM_Status_Chk();return false;" 
                                        style="color:Blue;text-decoration:underline;cursor:hand; font-size:smaller; ">Quick View</span>
                                </div>--%>
                                <div id="editbu"  runat="server">
                                    <asp:Button ID="Btn_xl_upload" runat="server" Visible="false" Text="Excel Upload" OnClientClick="jQuery('#form1').validationEngine('hide');open_IGM_ExcelNew();return false;"
                                         TabIndex="29"  CssClass="autowidupdatebut"/>
                                </div>
                                 
                            </div>
                            
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM" style="font-weight: normal; width: 89px;">
                                <asp:Label ID="lbl_RotationNo" runat="server" Text="Rotation No"></asp:Label>
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox runat="server" MaxLength="20" ONKEYPRESS="return numchar2(event)" CssClass="txtbox_none_Mid_transac_code"
                                    ID="txt_RotationNo" ClientIDMode="Static" TabIndex="25"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label2_transaction_popup_IGM" style="font-weight: normal; width: 40px;">
                                <asp:Label ID="lbl_Rotation_Date" runat="server" Text="Date"></asp:Label>
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Rotation_Date" runat="server" CssClass="txtbox_none_Mid_transac_code" Width="70px"
                                    MaxLength="10" TabIndex="25"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt_Rotation_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtende7" runat="server" TargetControlID="txt_Rotation_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="div_AmendmentType"  Visible="false" runat="server"  style="margin-top:5px">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 80px;
                                font-weight: bold;">
                                Amend Type
                            </div>
                            <div id="txtcon-m_transaction_code_BE_TYPE" style="width: 100px;">
                                <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                    Width="100px">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="A">AMENDMENT</asp:ListItem>
                                    <asp:ListItem Value="S">SUPPLEMENT</asp:ListItem>
                                    <asp:ListItem Value="D">DELETE</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="editbu" style="margin-top:-5px;">
                                            <asp:Button ID="btn_Amend_FF" Text="Flatfile" CssClass="autowidmovebut" runat="server"
                                                OnClientClick="Open_Amend_Flatfile(); return false" Width="60px" />
                                        </div>
                            </div>
                        </div>
                        <div id="pop_text_area_transac_popup_inn_container_IGM_gateway_grid">
                            <div id="pop_text_area_transac_popup_inn_container_IGM_Container2_grid_gateway" runat="server"  style=" overflow:auto; height:105px;margin-top:12px;">

                                <asp:GridView ID="gv_IGM" runat="server" DataKeyNames="IGM_ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="130%"
                                    ShowHeaderWhenEmpty="True" PageSize="5" AllowPaging="True" OnRowDataBound="gv_IGM_RowDataBound"
                                    OnPageIndexChanging="gv_IGM_PageIndexChanging" OnSelectedIndexChanged="gv_IGM_SelectedIndexChanged"
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="1" CellSpacing="1" OnRowCreated="gv_IGM_RowCreated">
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        BorderWidth="1px" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="IGM_SLNO" HeaderText="S.No">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="IGM_NO" HeaderText="IGM No" ControlStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_DATE" HeaderText="IGM Date" ControlStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left5"  Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_AIRLINENAME" HeaderText="Airline" ControlStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left5" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_FLIGHTNO_VESSELNO" HeaderText="Flight No">
                                            <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_FLIGHT_VESSELDATE" HeaderText="Flight / Inward Date">
                                            <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_MAWB_MBL" HeaderText="MAWB / MBL No" ControlStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left5" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_MAWB_MBLDATE" HeaderText="MAWB / MBL Date">
                                            <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_HAWB_HBLNO" HeaderText="HAWB / HBL No">
                                            <ItemStyle CssClass="column_style_left5" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_HAWB_HBLDATE" HeaderText="HAWB / HBL Date">
                                            <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_AIRLINECODE" HeaderText="Airline Code">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_NOOFPACKAGE" HeaderText=" No Of Package">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_PACKAGETYPE" HeaderText="Package Type">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_GROSSWEIGHT" HeaderText="Gross Weight">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_TYPEOFWEIGHT">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_NETWEIGHT">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_NETWEIGHTTYPE">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_MARKSNOS">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_GATEWAY_IGM_NO">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_GATEWAY_IGM_DATE">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_GATEWAY_PORT_CODE">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_ID" HeaderText="">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                          <asp:BoundField DataField="IGM_LINE_NUMBER">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_SHIPPING_LINE_NUMBER">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IGM_VOYAGE" HeaderText="">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="HRS" HeaderText="">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MINS" HeaderText="">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="IGM_CHARGEABLE_WGT" HeaderText="">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                         <asp:BoundField DataField="ROTATION_NO" HeaderText="">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                         <asp:BoundField DataField="ROTATION_DATE" HeaderText="">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                         <asp:BoundField DataField="AMENDMENT_TYPE" HeaderText="">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                    </Columns>
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                     <PagerStyle CssClass="pager" />
                                    <EmptyDataTemplate>
                                        NO RECORD FOUND
                                    </EmptyDataTemplate>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <iframe src="" name="trans_igm_container" scrolling="no" id="trans_IGM_Container_Main_Cont_iframe">
                    </iframe>
                </div>
                <div class="content" id="page-3">
                    <iframe src="" name="trans_igm_bond" scrolling="no" id="trans_IGM_bond_Main_Cont_iframe">
                    </iframe>
                </div>
                <div class="content" id="page-4">
                    <iframe src="" name="trans_igm_certificate" scrolling="no" id="trans_IGM_certificate_Main_Cont_iframe">
                    </iframe>
                </div>
            </div>
           
                <asp:HiddenField ID="hdn_Jobno" runat="server"  />
                <asp:HiddenField ID="hdn_Transport_Mode" runat="server"  />
                <asp:HiddenField ID="hdn_filling_status" runat="server" />
                <asp:HiddenField ID="hdn_update_IGM" runat="server" />
                <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                <asp:HiddenField ID="hd_CUSTOMHOUSE_CODE" runat="server" />
                <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_IgmNo" runat="server" />
                <asp:HiddenField ID="hdn_IgmDate" runat="server" />
                <asp:HiddenField ID="hdn_FlightDate" runat="server" />
                <asp:HiddenField ID="hdn_source" runat="server" />
                <asp:HiddenField ID="hdn_CompanyID" runat="server" />
                <asp:HiddenField ID="hdn_BEType" runat="server"  ClientIDMode="Static"/>   
                  
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2', 'page-3', 'page-4']);
    </script>


     <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

       <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
             
             <tr>
                 <td style="padding-left: 125px; padding-top:10px;">
                     <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>

         <!-- ============================================================
         ETA UPDATE VESSEL SCHEDULE POPUPS
         ============================================================ -->

    <!-- Chennai selected values -->
    <asp:HiddenField ID="hdn_ChennaiSelectedIndex" runat="server" Value="-1" />
    <asp:HiddenField ID="hdn_ChennaiVesselName" runat="server" />
    <asp:HiddenField ID="hdn_ChennaiETA" runat="server" />
    <asp:HiddenField ID="hdn_ChennaiRevisedETA" runat="server" />

    <!-- Ennore selected values -->
    <asp:HiddenField ID="hdn_EnnoreSelectedIndex" runat="server" Value="-1" />
    <asp:HiddenField ID="hdn_EnnoreVesselName" runat="server" />
    <asp:HiddenField ID="hdn_EnnoreETA" runat="server" />

    <!-- Kattupalli selected values -->
    <asp:HiddenField ID="hdn_KattupalliSelectedIndex" runat="server" Value="-1" />
    <asp:HiddenField ID="hdn_KattupalliVesselName" runat="server" />
    <asp:HiddenField ID="hdn_KattupalliETA" runat="server" />

    <!-- ============================================================
         CHENNAI
         ============================================================ -->

    <asp:HiddenField ID="HDU_ChennaiSchedule" runat="server" />

    <asp:ModalPopupExtender ID="MP_ChennaiSchedule" runat="server"
        TargetControlID="HDU_ChennaiSchedule"
        PopupControlID="Panel_ChennaiSchedule"
        BackgroundCssClass="etaScheduleModalBackground"
        DropShadow="false">
    </asp:ModalPopupExtender>

    <asp:Panel ID="Panel_ChennaiSchedule" runat="server"
        CssClass="etaSchedulePopup"
        Style="display:none;">

        <div class="etaScheduleTitle">
            <asp:Label ID="lbl_ChennaiScheduleHeading"
                runat="server"
                Text="Chennai Vessel Schedule">
            </asp:Label>
        </div>

        <div class="etaScheduleGridWrap">

            <asp:GridView ID="gvChennaiSchedule" runat="server"
                AutoGenerateColumns="false"
                CssClass="etaScheduleGrid"
                GridLines="Both"
                BorderWidth="1px"
                CellPadding="3"
                ShowHeaderWhenEmpty="true">

                <Columns>

                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelectChennai" runat="server"
                                onclick="SelectChennaiETA(this);" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="45px" />
                        <HeaderStyle HorizontalAlign="Center" Width="45px" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="Source" HeaderText="Source" />
                    <asp:BoundField DataField="VESSEL_NAME" HeaderText="Vessel Name" />
                    <asp:BoundField DataField="ETA" HeaderText="ETA" />
                    <asp:BoundField DataField="REVISED_ETA" HeaderText="Revised ETA" />
                    <asp:BoundField DataField="LOA" HeaderText="LOA" />
                    <asp:BoundField DataField="GATE_OPEN" HeaderText="Gate Open" />
                    <asp:BoundField DataField="GATE_CUTOFF" HeaderText="Gate Cutoff" />

                </Columns>
            </asp:GridView>

        </div>

        <div class="etaScheduleButtons">

            <asp:Button ID="btn_ChennaiScheduleUpdate" runat="server"
                Text="Update"
                OnClick="btn_ChennaiScheduleUpdate_Click" />

            <asp:Button ID="btn_ChennaiScheduleClose" runat="server"
                Text="Close"
                CausesValidation="false"
                OnClick="btn_ChennaiScheduleClose_Click" />

        </div>

    </asp:Panel>


    <!-- ============================================================
         ENNORE
         ============================================================ -->

    <asp:HiddenField ID="HDU_EnnoreSchedule" runat="server" />

    <asp:ModalPopupExtender ID="MP_EnnoreSchedule" runat="server"
        TargetControlID="HDU_EnnoreSchedule"
        PopupControlID="Panel_EnnoreSchedule"
        BackgroundCssClass="etaScheduleModalBackground"
        DropShadow="false">
    </asp:ModalPopupExtender>

    <asp:Panel ID="Panel_EnnoreSchedule" runat="server"
        CssClass="etaSchedulePopup"
        Style="display:none;">

        <div class="etaScheduleTitle">
            <asp:Label ID="lbl_EnnoreScheduleHeading"
                runat="server"
                Text="Ennore Vessel Schedule">
            </asp:Label>
        </div>

        <div class="etaScheduleGridWrap">

            <asp:GridView ID="gvEnnoreSchedule" runat="server"
                AutoGenerateColumns="false"
                CssClass="etaScheduleGrid"
                GridLines="Both"
                BorderWidth="1px"
                CellPadding="3"
                ShowHeaderWhenEmpty="true">

                <Columns>

                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelectEnnore" runat="server"
                                onclick="SelectEnnoreETA(this);" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="45px" />
                        <HeaderStyle HorizontalAlign="Center" Width="45px" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="Source" HeaderText="Source" />
                    <asp:BoundField DataField="VESSEL_NAME" HeaderText="Vessel Name" />
                    <asp:BoundField DataField="AtaEtaDate" HeaderText="ATA/ETA Date" />
                    <asp:BoundField DataField="AtaEtaDay" HeaderText="Day" />
                    <asp:BoundField DataField="AtaEtaTime" HeaderText="ETA Time" />
                    <asp:BoundField DataField="Etb" HeaderText="ETB" />
                    <asp:BoundField DataField="FinalCutOff" HeaderText="Final Cutoff" />

                </Columns>
            </asp:GridView>

        </div>

        <div class="etaScheduleButtons">

            <asp:Button ID="btn_EnnoreScheduleUpdate" runat="server"
                Text="Update"
                OnClick="btn_EnnoreScheduleUpdate_Click" />

            <asp:Button ID="btn_EnnoreScheduleClose" runat="server"
                Text="Close"
                CausesValidation="false"
                OnClick="btn_EnnoreScheduleClose_Click" />

        </div>

    </asp:Panel>


    <!-- ============================================================
         KATTUPALLI
         ============================================================ -->

    <asp:HiddenField ID="HDU_KattupalliSchedule" runat="server" />

    <asp:ModalPopupExtender ID="MP_KattupalliSchedule" runat="server"
        TargetControlID="HDU_KattupalliSchedule"
        PopupControlID="Panel_KattupalliSchedule"
        BackgroundCssClass="etaScheduleModalBackground"
        DropShadow="false">
    </asp:ModalPopupExtender>

    <asp:Panel ID="Panel_KattupalliSchedule" runat="server"
        CssClass="etaSchedulePopup"
        Style="display:none;">

        <div class="etaScheduleTitle">
            <asp:Label ID="lbl_KattupalliScheduleHeading"
                runat="server"
                Text="Kattupalli Vessel Schedule">
            </asp:Label>
        </div>

        <div class="etaScheduleGridWrap">

            <asp:GridView ID="gvKattupalliSchedule" runat="server"
                AutoGenerateColumns="false"
                CssClass="etaScheduleGrid"
                GridLines="Both"
                BorderWidth="1px"
                CellPadding="3"
                ShowHeaderWhenEmpty="true">

                <Columns>

                    <asp:TemplateField HeaderText="Select">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelectKattupalli" runat="server"
                                onclick="SelectKattupalliETA(this);" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="45px" />
                        <HeaderStyle HorizontalAlign="Center" Width="45px" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="Source" HeaderText="Source" />
                    <asp:BoundField DataField="VESSEL_NAME" HeaderText="Vessel Name" />
                    <asp:BoundField DataField="ATAETA" HeaderText="ATA/ETA" />
                    <asp:BoundField DataField="ETA" HeaderText="ETA" />
                    <asp:BoundField DataField="ETB" HeaderText="ETB" />
                    <asp:BoundField DataField="GATE_CUTOFF" HeaderText="Gate Cutoff" />

                </Columns>
            </asp:GridView>

        </div>

        <div class="etaScheduleButtons">

            <asp:Button ID="btn_KattupalliScheduleUpdate" runat="server"
                Text="Update"
                OnClick="btn_KattupalliScheduleUpdate_Click" />

            <asp:Button ID="btn_KattupalliScheduleClose" runat="server"
                Text="Close"
                CausesValidation="false"
                OnClick="btn_KattupalliScheduleClose_Click" />

        </div>

    </asp:Panel>

    <script type="text/javascript">
        function clearETAHiddenFields(prefix) {
            document.getElementById(prefix + "VesselName").value = "";
            document.getElementById(prefix + "ETA").value = "";
        }

        function uncheckOtherETA(grid, current) {
            var boxes = grid.querySelectorAll("input[type='checkbox']");
            for (var i = 0; i < boxes.length; i++) {
                if (boxes[i] !== current) {
                    boxes[i].checked = false;
                }
            }
        }

        function SelectChennaiETA(chk) {
            var grid = chk.closest("table");
            if (!grid) return;
            uncheckOtherETA(grid, chk);

            var row = chk.closest("tr");
            if (!row) return;

            var cells = row.getElementsByTagName("td");
            if (cells.length < 5) return;

            document.getElementById("<%= hdn_ChennaiSelectedIndex.ClientID %>").value = row.rowIndex - 1;
            document.getElementById("<%= hdn_ChennaiVesselName.ClientID %>").value = cells[2].innerText.trim();
            document.getElementById("<%= hdn_ChennaiETA.ClientID %>").value = cells[3].innerText.trim();
            document.getElementById("<%= hdn_ChennaiRevisedETA.ClientID %>").value = cells[4].innerText.trim();
        }

        function SelectEnnoreETA(chk) {
            var grid = chk.closest("table");
            if (!grid) return;
            uncheckOtherETA(grid, chk);

            var row = chk.closest("tr");
            if (!row) return;

            var cells = row.getElementsByTagName("td");
            if (cells.length < 6) return;

            document.getElementById("<%= hdn_EnnoreSelectedIndex.ClientID %>").value = row.rowIndex - 1;
            document.getElementById("<%= hdn_EnnoreVesselName.ClientID %>").value = cells[2].innerText.trim();

            var date = cells[3].innerText.trim();
            var time = cells[5].innerText.trim();

            document.getElementById("<%= hdn_EnnoreETA.ClientID %>").value =
                (date + " " + time).trim();
        }

        function SelectKattupalliETA(chk) {
            var grid = chk.closest("table");
            if (!grid) return;
            uncheckOtherETA(grid, chk);

            var row = chk.closest("tr");
            if (!row) return;

            var cells = row.getElementsByTagName("td");
            if (cells.length < 5) return;

            document.getElementById("<%= hdn_KattupalliSelectedIndex.ClientID %>").value = row.rowIndex - 1;
            document.getElementById("<%= hdn_KattupalliVesselName.ClientID %>").value = cells[2].innerText.trim();
            document.getElementById("<%= hdn_KattupalliETA.ClientID %>").value = cells[4].innerText.trim();
        }
    </script>


    </form>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
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
    <script src="../js/Autotab.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_IGM.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/General_Igm.js" type="text/javascript"></script>
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


        function validateLimit(obj, divID, maxchar) {

            objDiv = get_object(divID);

            if (this.id) obj = this;

            var remaningChar = maxchar - trimEnter(obj.value).length;

            if (objDiv.id) {
                objDiv.innerHTML = remaningChar + "";
            }
            if (remaningChar <= 0) {
                obj.value = obj.value.substring(maxchar, 0);
                if (objDiv.id) {
                    objDiv.innerHTML = "0 ";
                }
                return false;
            }
            else
            { return true; }
        }
        function get_object(id) {
            var object = null;
            if (document.layers) {
                object = document.layers[id];
            } else if (document.all) {
                object = document.all[id];
            } else if (document.getElementById) {
                object = document.getElementById(id);
            }
            return object;
        }

        function trimEnter(dataStr) {
            return dataStr.replace(/(\r\n|\r|\n)/g, "");
        }

    </script>

     <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            /*gridviewScroll();*/
        });

        function gridviewScroll() {
            gridView1 = $('#<%=gv_IGM.ClientID %>').gridviewScroll({
                width: 500,
                height: 150,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 1,
                arrowsize: 30,
                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",
                headerrowcount: 1,
                railsize: 16,
                barsize: 15,
                IsInUpdatePanel: true
            });
        }
	</script>

    <script src="../js/Import_Jscript/IMP_IGM_Status_Chk.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/IMP_IGM_Status_A_L_Chk.js" type="text/javascript"></script>
    
    <script type="text/javascript">

        function IGM_Track() {
          
            var IGM_MBLNO = document.getElementById("txtMAWBMBLNo").value;
            var mode = document.getElementById("hdn_Transport_Mode").value;
            var CUSTOMHOUSE_CODE = document.getElementById("hd_CUSTOMHOUSE_CODE").value;

            if (mode == 'Air' || mode == 'Sea') {
                IGM_Status(IGM_MBLNO, CUSTOMHOUSE_CODE,mode);
            }
        }

        function BE_AwbStat_ICDStat() {
           
            var IGM_MBLNO = document.getElementById("txtMAWBMBLNo").value;
            var mode = document.getElementById("hdn_Transport_Mode").value;
            var CUSTOMHOUSE_CODE = document.getElementById("hd_CUSTOMHOUSE_CODE").value;

            if (mode == 'Air' || mode == 'Land') {
                BE_AwbStat_ICDStat_link(IGM_MBLNO, CUSTOMHOUSE_CODE, mode);
            }
        }

 </script>

<script type="text/javascript">

    window.IGM_SaveTrackingData = function (trackingData, popupWindow) {

        if (!trackingData ||
            !trackingData.records ||
            trackingData.records.length === 0) {

            alert("Tracking Data Not Found");
            return;
        }


        var mode =
            document.getElementById("hdn_Transport_Mode").value;

        var currentMbl =
            (document.getElementById("txtMAWBMBLNo").value || "")
                .trim()
                .toUpperCase();

        var currentHbl =
            (document.getElementById("txtHAWBHBLNo").value || "")
                .trim()
                .toUpperCase();


        var matchedIndex = -1;


        // =====================================================
        // SEA
        // =====================================================
        if (mode === "Sea") {

            for (var i = 0;
                 i < trackingData.records.length;
                 i++) {

                var recBl =
                    (trackingData.records[i].BlNo || "")
                        .trim()
                        .toUpperCase();

                var recHbl =
                    (trackingData.records[i].HouseBlNo || "")
                        .trim()
                        .toUpperCase();

                var normalizedRecHbl =
                    normalizeHbl(recHbl);

                var normalizedCurrentHbl =
                    normalizeHbl(currentHbl);


                if (recBl === currentMbl &&
                    normalizedRecHbl === normalizedCurrentHbl) {

                    matchedIndex = i;
                    break;
                }
            }


            if (matchedIndex === -1) {

                alert(
                    "MBL No / HBL No, current IGM record Not Matched"
                );

                return;
            }
        }


        // =====================================================
        // AIR
        // =====================================================
        else if (mode === "Air") {

            for (var j = 0;
                 j < trackingData.records.length;
                 j++) {

                var recAwb =
                    (trackingData.records[j].AwbNo || "")
                        .trim()
                        .toUpperCase();


                if (recAwb === currentMbl) {

                    matchedIndex = j;
                    break;
                }
            }


            if (matchedIndex === -1) {

                alert("AWB No, current MBL Not Matched.");

                return;
            }
        }


        // =====================================================
        // INVALID MODE
        // =====================================================
        else {

            alert(
                "Only support Air or Sea Mode (" +
                mode +
                ")"
            );

            return;
        }


        // =====================================================
        // MATCHED RECORD
        // =====================================================
        var matchedRecord =
            trackingData.records[matchedIndex];

        var matchedView =
            (trackingData.viewDetails &&
             trackingData.viewDetails[matchedIndex])
                ? trackingData.viewDetails[matchedIndex]
                : null;


        var payload = {
            record: matchedRecord,
            viewDetail: matchedView
        };


        var trackingJson =
            JSON.stringify(payload);


        // =====================================================
        // FIRST SAVE
        // false = mismatch update permission இல்லை
        // =====================================================
        saveIGMTracking(
            mode,
            currentMbl,
            currentHbl,
            trackingJson,
            false,
            popupWindow
        );
    };


    // =========================================================
    // SAVE FUNCTION
    // =========================================================
    function saveIGMTracking(
        mode,
        currentMbl,
        currentHbl,
        trackingJson,
        allowMismatchUpdate,
        popupWindow) {


        PageMethods.Save_IGM_Tracking_Data(
            mode,
            currentMbl,
            currentHbl,
            trackingJson,
            allowMismatchUpdate,

        // =================================================
        // SUCCESS
        // =================================================
            function (result) {

                // ---------------------------------------------
                // MISMATCH - ASK USER
                // ---------------------------------------------
                if (result &&
                    result.indexOf("CONFIRM_UPDATE:") === 0) {

                    var message =
                        result.substring(
                            "CONFIRM_UPDATE:".length
                        );


                    var confirmUpdate =
                        confirm(
                            message +
                            "\n\nDo you want to update the existing record?"
                        );


                    // -----------------------------------------
                    // USER CLICKED OK
                    // -----------------------------------------
                    if (confirmUpdate) {

                        saveIGMTracking(
                            mode,
                            currentMbl,
                            currentHbl,
                            trackingJson,
                            true,
                            popupWindow
                        );
                    }


                    // -----------------------------------------
                    // USER CLICKED CANCEL
                    // -----------------------------------------
                    else {

                        return;
                    }

                    return;
                }


                // ---------------------------------------------
                // SUCCESS
                // ---------------------------------------------
                if (result &&
                    result.indexOf("SUCCESS") === 0) {

                    alert(
                        "IGM Tracking Saved Successfully"
                    );


                    if (popupWindow &&
                        !popupWindow.closed) {

                        popupWindow.close();
                    }

                    return;
                }


                // ---------------------------------------------
                // OLD MISMATCH RESPONSE
                // ---------------------------------------------
                else if (result &&
                         result.indexOf("MISMATCH:") === 0) {

                    alert(
                        result.replace("MISMATCH:", "")
                    );

                    return;
                }


                // ---------------------------------------------
                // OTHER RESPONSE
                // ---------------------------------------------
                else {

                    alert(result);
                }
            },


        // =================================================
        // ERROR
        // =================================================
            function (error) {

                alert(
                    "Server Error: " +
                    error.get_message()
                );
            }
        );
    }

</script>





 <script type="text/javascript">
     function IGM_Status_Chk() {
         var Tr_mode = document.getElementById("hdn_Transport_Mode").value;

         if (Tr_mode == 'Air') {
             NewWindow1('IGM_Tracking_A.aspx', 'List', '1100', '1024', 'yes');
         }
         else if (Tr_mode == 'Sea') {
             NewWindow1('IGM_Tracking_S.aspx', 'List', '1100', '1024', 'yes');
         }

     }

     function Open_Amend_Flatfile() {
         var amd_type = document.getElementById("ddl_AmendmentType").value;
         var amd_page = 'IGM';
         var amd_Jobno = document.getElementById("hdn_Jobno").value;
         
         NewWindow1('../Amendment/Import_Amendment.aspx?amd_type=' + amd_type + '&amd_page=' + amd_page + '&amd_Jobno=' + amd_Jobno, 'List', '950', '515', 'yes');
     }

     function normalizeHbl(value) {

         value = (value || "")
        .trim()
        .toUpperCase();

         if (
        value === "" ||
        value === "N.A." ||
        value === "N.A" ||
        value === "NA" ||
        value === "N/A" ||
        value === "-"
    ) {
             return "";
         }

         return value;
     }
    </script>

<%--     <script type="text/javascript"> // Hide by shanthini on 12-08-2026
         function validateDate(control, type) {

             var txt = control.value;

             if (txt == "")
                 return;

             var parts = txt.split("/");

             if (parts.length != 3)
                 return;

             var enteredDate = new Date(parts[2], parts[1] - 1, parts[0]);
             var today = new Date();
             // Remove time part
             today.setHours(0, 0, 0, 0);

             if (enteredDate > today) {
                 
                 if (type == "HAWB") {
                     jAlert("HAWB/ HBL Date should not be greater than Current Date.");
                    
                 }
                 else if (type == "MAWB") {
                     jAlert("MAWB/ MBL Date should not be greater than Current Date.");
                    
                 }
                 control.focus();
                 return false;
             }
             return true;
         }
</script--%>>
  <%--<script type="text/javascript">
      function ValidateInwardIGMDate() {

          var Tr_mode = document.getElementById("hdn_Transport_Mode").value;

          // If Air mode, skip this validation
          if (Tr_mode == 'Air') {
              validation();
              return true;
          }

          var inward = document.getElementById('<%= txtFlightVesselDate.ClientID %>').value;
          var igm = document.getElementById('<%= txtIGMDate.ClientID %>').value;

          if (inward !== "" && igm !== "") {

              // dd/MM/yyyy → Date
              var inwardParts = inward.split('/');
              var igmParts = igm.split('/');

              var inwardDate = new Date(inwardParts[2], inwardParts[1] - 1, inwardParts[0]);
              var igmDate = new Date(igmParts[2], igmParts[1] - 1, igmParts[0]);

              if (inwardDate < igmDate) {
                  alert("IGM DATE should be less than or equal to INWARD DATE");
                  document.getElementById('<%= txtFlightVesselDate.ClientID %>').focus();
                  return false;
              }
          }
          validation();
          return true;
      }
</script>--%>

<script type="text/javascript">
(function () {
    "use strict";

    // Global state
    var igmTrackInProgress = false;
    var currentAbortController = null;
    var FIELD_LABELS = {
        SerialNo: { label: "Sl No" },
        LineNo: { label: "Line No" },
        SubLineNo: { label: "Sub Line No" },
        BlNo: { label: "BL No", strong: true },
        BlDate: { label: "BL Date" },
        HouseBlNo: { label: "House BL No" },
        HouseBlDate: { label: "House BL Date" },
        CargoMovement: { label: "Cargo Movement", badge: true },
        GrossWeight: { label: "Gross Weight", unitKey: "UnitOfWeight" },
        TotalPackage: { label: "Total Package", unitKey: "PackageCode" },
        PortDest: { label: "Port Dest" },
        DescOfGoods: { label: "Description of Goods", cssClass: "igm-cell-desc" },

        // Air IGM main-grid-only fields
        AwbNo: { label: "AWB No", strong: true },
        PortOfShipment: { label: "Port of Shipment" },
        SegregationDateTime: { label: "Segregation Date/Time" },

        // Sea IGM "View" popup (INW / File level)
        IgmNo: { label: "IGM No", strong: true },
        IgmDate: { label: "IGM Date" },
        InwDate: { label: "INW Date" },
        FileName: { label: "File Name" },
        GatewayPort: { label: "Gateway Port" },
        VoyageNumber: { label: "Voyage Number" },
        ImoNo: { label: "IMO No" },
        VesselCode: { label: "Vessel Code" },

        // Sea IGM "Container Details" popup
        ContainerDetails: { label: "Container Details", strong: true },
        ContainerStatus: { label: "Container Status", badge: true },

        // Air IGM "View More" popup #1
        LocationCode: { label: "Location Code" },
        FlightNo: { label: "Flight No" },
        FlightDate: { label: "Flight Date" },
        SubmissionDate: { label: "Submission Date" },
        InwardDate: { label: "Inward Date" },
        BeNo: { label: "BE No", strong: true },

        // Air IGM "View More" popup #2
        BeDate: { label: "BE Date" }
    };

    // Keys that are merged into another column (via unitKey) and should
    // never appear as their own column.
    var MERGED_KEYS = { UnitOfWeight: true, PackageCode: true };

    var REQUEST_TIMEOUT_MS = 100000;

    window.IGM_Track = function () {

        if (igmTrackInProgress) {
            alert("A tracking request is already in progress. Please wait for it to complete.");
            return false;
        }

        var mblInput = document.getElementById("txtMAWBMBLNo");
        var locationInput = document.getElementById("hd_CUSTOMHOUSE_CODE");

        var mblNo = mblInput ? mblInput.value.trim() : "";
        var locationCode = locationInput ? locationInput.value.trim() : "";

        if (!mblNo) {
            alert("Please enter Master BL No before tracking IGM status.");
            return false;
        }
        if (!locationCode) {
            alert("Location/Customhouse code is missing.");
            return false;
        }

        igmTrackInProgress = true;

        var resultWindow = window.open("", "IgmResultWindow", "width=1100,height=650,scrollbars=yes,resizable=yes");
        if (!resultWindow) {
            alert("Popup blocked! Please allow popups for this site and try again.");
            igmTrackInProgress = false;
            return false;
        }

        resultWindow.document.write(getIgmPageShell(mblNo, locationCode));
        resultWindow.document.close();

        var trackBtn = document.getElementById("btnTrackIGM");
        if (trackBtn) trackBtn.disabled = true;

        currentAbortController = new AbortController();
        var timeoutId = setTimeout(function () {
            currentAbortController.abort();
        }, REQUEST_TIMEOUT_MS);

        fetch("https://impexservice.eroyalimpex.co.in/api/igm/track", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ locationCode: locationCode, masterBlNo: mblNo }),
            signal: currentAbortController.signal
        })
        .then(function (response) {
            if (!response.ok) {
                throw new Error("Server returned status " + response.status);
            }
            return response.json();
        })
        .then(function (data) {
            renderIgmResultInWindow(resultWindow, data);
        })
        .catch(function (err) {
            var message = err.name === "AbortError"
                ? "Request timed out. ICEGATE server may be slow — please try again."
                : err.message;

            if (resultWindow && !resultWindow.closed) {
                var body = resultWindow.document.getElementById("igmBody");
                if (body) body.innerHTML = getErrorBlock("Connection Error", message);
            } else {
                alert("API call failed: " + message);
            }
            console.error("API call failed:", err);
        })
        .finally(function () {
            clearTimeout(timeoutId);
            currentAbortController = null;
            igmTrackInProgress = false;
            if (trackBtn) trackBtn.disabled = false;
        });

        return false;
    };


function getIgmPageShell(mblNo, locationCode) {
    return "<!DOCTYPE html><html><head><title>IGM Tracking Result</title>" +
        "<meta charset='utf-8'>" +
        "<style>" + getIgmStyles() + "</style>" +
        "</head><body>" +
        "<div class='igm-header'>" +
        "  <div class='igm-header-title'>" +
        "    <span class='igm-logo'>&#128230;</span>" +
        "    <div>" +
        "      <h1>IGM Tracking Status</h1>" +
        "      <p class='igm-subtitle'>Master BL No: <strong>" + escapeHtml(mblNo) + "</strong> &nbsp;|&nbsp; Location: <strong>" + escapeHtml(locationCode) + "</strong></p>" +
        "    </div>" +
        "  </div>" +
        "  <button type='button' id='btnIgmSave' class='igm-save-btn' onclick='onIgmSaveClick()' disabled>SAVE</button>" +
        "</div>" +
        "<div id='igmBody' class='igm-container'>" + getLoadingBlock() + "</div>" +
        "<scr" + "ipt>" +
        "function onIgmSaveClick() {" +
        "  if (window.opener && !window.opener.closed && typeof window.opener.IGM_SaveTrackingData === 'function') {" +
        "    window.opener.IGM_SaveTrackingData(window.igmTrackingData, window);" +
        "  } else {" +
        "    alert('Parent Page NOT Found');" +
        "  }" +
        "}" +
        "<\/scr" + "ipt>" +
        "</body></html>";
}

    function getLoadingBlock() {
        return "<div class='igm-state'>" +
            "  <div class='igm-spinner'></div>" +
            "  <p class='igm-state-text'>Fetching IGM status from ICEGATE...</p>" +
            "  <p class='igm-state-subtext'>This may take up to 30-90 seconds. Please don't close this window.</p>" +
            "</div>";
    }

    function getErrorBlock(title, message) {
        return "<div class='igm-state'>" +
            "  <div class='igm-icon igm-icon-error'>&#10060;</div>" +
            "  <p class='igm-state-text'>" + escapeHtml(title) + "</p>" +
            "  <p class='igm-state-subtext'>" + escapeHtml(message) + "</p>" +
            "</div>";
    }

    function getEmptyBlock(message) {
        return "<div class='igm-state'>" +
            "  <div class='igm-icon igm-icon-warn'>&#9888;&#65039;</div>" +
            "  <p class='igm-state-text'>No Records Found</p>" +
            "  <p class='igm-state-subtext'>" + escapeHtml(message) + "</p>" +
            "</div>";
    }

    function renderIgmResultInWindow(resultWindow, data) {
        if (!resultWindow || resultWindow.closed) {
            alert(JSON.stringify(data));
            return;
        }

        var body = resultWindow.document.getElementById("igmBody");
        if (!body) return;

        if (!data.success) {
            body.innerHTML = getErrorBlock("Tracking Failed", data.resultText || "IGM tracking failed.");
            return;
        }

        if (!data.records || data.records.length === 0) {
            body.innerHTML = getEmptyBlock(data.resultText || "No records found for the given Master BL No.");
            return;
        }

        var parts = [];
        parts.push(buildResultTable(data.records));

        // View -> drill-down grids (Sea: View -> Container Details,
        // Air: View More -> View More)
        if (data.viewDetails && data.viewDetails.length > 0) {
            parts.push(buildViewDetailsSection(data.viewDetails));
        }

     body.innerHTML = parts.join("");

    // ---- Save Button Enable + Tracking Data Store ----
    resultWindow.igmTrackingData = data;
    var saveBtn = resultWindow.document.getElementById("btnIgmSave");
    if (saveBtn) {
        saveBtn.disabled = false;
    }
    }




    function getColumnsForRecords(records) {
        var seen = {};
        var extraKeys = [];

        for (var i = 0; i < records.length; i++) {
            var record = records[i];
            if (!record) continue;
            for (var key in record) {
                if (!Object.prototype.hasOwnProperty.call(record, key)) continue;
                if (MERGED_KEYS[key] || seen[key]) continue;
                seen[key] = true;
                if (!FIELD_LABELS[key]) extraKeys.push(key);
            }
        }

        var columns = [];
        for (var knownKey in FIELD_LABELS) {
            if (seen[knownKey]) {
                var def = FIELD_LABELS[knownKey];
                columns.push({
                    key: knownKey,
                    label: def.label,
                    strong: def.strong,
                    badge: def.badge,
                    unitKey: def.unitKey,
                    cssClass: def.cssClass
                });
            }
        }
        for (var e = 0; e < extraKeys.length; e++) {
            columns.push({ key: extraKeys[e], label: humanizeKey(extraKeys[e]) });
        }

        return columns;
    }

    function humanizeKey(key) {
        return String(key)
            .replace(/([a-z0-9])([A-Z])/g, "$1 $2")
            .replace(/^./, function (c) { return c.toUpperCase(); });
    }

    // Second drill-down level shows different data depending on flow:
    // Sea IGM -> container details, Air IGM -> BE/IGM details. Pick a
    // heading based on which columns actually turned up.
    function getLevel2Heading(columns) {
        for (var i = 0; i < columns.length; i++) {
            if (columns[i].key === "ContainerDetails" || columns[i].key === "ContainerStatus") {
                return "Container Details";
            }
        }
        for (var j = 0; j < columns.length; j++) {
            if (columns[j].key === "BeDate" || columns[j].key === "BeNo") {
                return "BE Details";
            }
        }
        return "Additional Details";
    }

    function buildResultTable(records) {
        var parts = [];
        var columns = getColumnsForRecords(records);

        parts.push("<div class='igm-summary'>");
        parts.push("<span class='igm-badge igm-badge-success'>&#10003; " + records.length + " Record(s) Found</span>");
        parts.push("</div>");

        parts.push("<div class='igm-table-wrap'><table class='igm-table'><thead><tr>");
        for (var c = 0; c < columns.length; c++) {
            parts.push("<th>" + columns[c].label + "</th>");
        }
        parts.push("</tr></thead><tbody>");

        for (var i = 0; i < records.length; i++) {
            parts.push(buildRow(records[i], columns));
        }

        parts.push("</tbody></table></div>");

        return parts.join("");
    }

    function buildViewDetailsSection(viewDetails) {
        var parts = [];

        var level1Columns = getColumnsForRecords(pluck(viewDetails, "inwInfo"));
        var level2Columns = getColumnsForRecords(flattenPluck(viewDetails, "containers"));
        var level2Heading = getLevel2Heading(level2Columns);

        for (var i = 0; i < viewDetails.length; i++) {
            var detail = viewDetails[i];

            parts.push("<div class='igm-detail-block'>");

            if (viewDetails.length > 1) {
                parts.push("<div class='igm-detail-heading'>Record " + (i + 1) + " of " + viewDetails.length + " Details</div>");
            }

            // Level 1 grid (Sea: INW/File level, Air: View More #1)
            parts.push("<div class='igm-table-wrap igm-table-wrap-spaced'><table class='igm-table'><thead><tr>");
            for (var c = 0; c < level1Columns.length; c++) {
                parts.push("<th>" + level1Columns[c].label + "</th>");
            }
            parts.push("</tr></thead><tbody>");

            if (detail.error) {
                parts.push("<tr><td colspan='" + Math.max(level1Columns.length, 1) + "' class='igm-empty-cell'>" +
                    escapeHtml(detail.error) + "</td></tr>");
            } else if (isEmptyRecord(detail.inwInfo)) {
                parts.push("<tr><td colspan='" + Math.max(level1Columns.length, 1) + "' class='igm-empty-cell'>No details found.</td></tr>");
            } else {
                parts.push(buildRow(detail.inwInfo || {}, level1Columns));
            }

            parts.push("</tbody></table></div>");

            // Level 2 grid (Sea: Container Details, Air: View More #2)
            var containers = detail.containers || [];
            parts.push("<div class='igm-table-wrap igm-table-wrap-spaced'>");
            parts.push("<div class='igm-detail-subheading'>" + escapeHtml(level2Heading) + "</div>");
            parts.push("<table class='igm-table'><thead><tr>");
            for (var cc = 0; cc < level2Columns.length; cc++) {
                parts.push("<th>" + level2Columns[cc].label + "</th>");
            }
            parts.push("</tr></thead><tbody>");

            if (detail.error) {
                parts.push("<tr><td colspan='" + Math.max(level2Columns.length, 1) + "' class='igm-empty-cell'>" +
                    escapeHtml(detail.error) + "</td></tr>");
            } else if (containers.length === 0) {
                parts.push("<tr><td colspan='" + Math.max(level2Columns.length, 1) + "' class='igm-empty-cell'>No details found.</td></tr>");
            } else {
                for (var ci = 0; ci < containers.length; ci++) {
                    parts.push(buildRow(containers[ci], level2Columns));
                }
            }

            parts.push("</tbody></table></div>");
            parts.push("</div>"); // .igm-detail-block
        }

        return parts.join("");
    }

    function pluck(list, prop) {
        var out = [];
        for (var i = 0; i < list.length; i++) {
            if (list[i] && list[i][prop]) out.push(list[i][prop]);
        }
        return out;
    }

    function flattenPluck(list, prop) {
        var out = [];
        for (var i = 0; i < list.length; i++) {
            var arr = list[i] && list[i][prop];
            if (!arr) continue;
            for (var j = 0; j < arr.length; j++) out.push(arr[j]);
        }
        return out;
    }

    function isEmptyRecord(record) {
        if (!record) return true;
        for (var k in record) {
            if (Object.prototype.hasOwnProperty.call(record, k)) return false;
        }
        return true;
    }

    function buildRow(record, columns) {
        var cells = [];

        for (var c = 0; c < columns.length; c++) {
            var col = columns[c];
            var value = record[col.key];
            var cellHtml;

            if (col.badge) {
                cellHtml = renderStatusBadge(value);
            } else {
                cellHtml = escapeHtml(value);
                if (col.unitKey && record[col.unitKey]) {
                    cellHtml += " " + escapeHtml(record[col.unitKey]);
                }
            }

            var cssClass = "";
            if (col.strong) cssClass = " class='igm-cell-strong'";
            else if (col.cssClass) cssClass = " class='" + col.cssClass + "'";

            cells.push("<td" + cssClass + ">" + cellHtml + "</td>");
        }

        return "<tr>" + cells.join("") + "</tr>";
    }

    function renderStatusBadge(value) {
        var v = (value || "").toUpperCase().trim();
        var cls = "igm-tag-default";
        if (v === "LC" || v === "LCL") cls = "igm-tag-blue";
        else if (v === "FC" || v === "FCL") cls = "igm-tag-green";
        return "<span class='igm-tag " + cls + "'>" + escapeHtml(value) + "</span>";
    }

    function getIgmStyles() {
        return "* { box-sizing: border-box; }" +
            "body { margin:0; font-family: 'Segoe UI', Arial, sans-serif; background:#f4f6f9; color:#1f2937; }" +

            ".igm-header { background: linear-gradient(135deg, #1e3a8a, #2563eb); color:#fff; padding: 20px 28px; display:flex; align-items:center; justify-content:space-between; }" +
".igm-save-btn { background:#22c55e; color:#fff; border:none; padding:10px 22px; border-radius:8px; font-size:13px; font-weight:700; cursor:pointer; box-shadow:0 2px 6px rgba(0,0,0,0.25); white-space:nowrap; }" +
".igm-save-btn:hover:not(:disabled) { background:#16a34a; }" +
".igm-save-btn:disabled { background:#9ca3af; cursor:not-allowed; opacity:0.7; }" +

            ".igm-header-title { display:flex; align-items:center; gap:14px; }" +
            ".igm-logo { font-size: 32px; }" +
            ".igm-header h1 { margin:0; font-size: 20px; font-weight:600; }" +
            ".igm-subtitle { margin:4px 0 0; font-size:13px; opacity:0.9; }" +
            ".igm-container { padding: 22px 28px; }" +
            ".igm-state { display:flex; flex-direction:column; align-items:center; justify-content:center; padding: 60px 20px; text-align:center; }" +
            ".igm-state-text { font-size:16px; font-weight:600; margin: 6px 0 4px; color:#111827; }" +
            ".igm-state-subtext { font-size:13px; color:#6b7280; margin:0; }" +
            ".igm-icon { font-size: 40px; margin-bottom: 8px; }" +
              ".igm-spinner { width:44px; height:44px; border:4px solid #dbeafe; border-top-color:#2563eb; border-radius:50%; animation: igm-spin 0.8s linear infinite; margin-bottom:16px; }" +
            "@keyframes igm-spin { to { transform: rotate(360deg); } }" +
            ".igm-summary { margin-bottom: 14px; }" +
            ".igm-badge { display:inline-block; padding:6px 14px; border-radius: 20px; font-size:13px; font-weight:600; }" +
            ".igm-badge-success { background:#dcfce7; color:#166534; }" +
            ".igm-table-wrap { background:#fff; border-radius:10px; overflow:hidden; box-shadow: 0 1px 4px rgba(0,0,0,0.08); border:1px solid #e5e7eb; }" +
            ".igm-table-wrap-spaced { margin-top: 16px; }" +
            ".igm-table { width:100%; border-collapse:collapse; font-size:13px; }" +
            ".igm-table thead th { background:#f8fafc; color:#374151; text-transform:uppercase; font-size:11px; letter-spacing:0.03em; padding:12px 10px; text-align:left; border-bottom:2px solid #e5e7eb; white-space:nowrap; }" +
            ".igm-table tbody td { padding:11px 10px; border-bottom:1px solid #f0f1f3; color:#1f2937; vertical-align:top; }" +
            ".igm-table tbody tr:hover { background:#f9fafb; }" +
            ".igm-table tbody tr:last-child td { border-bottom:none; }" +
            ".igm-cell-strong { font-weight:600; color:#111827; }" +
            ".igm-cell-desc { max-width: 260px; }" +
            ".igm-empty-cell { text-align:center; color:#9ca3af; padding:16px; font-style:italic; }" +
            ".igm-detail-block { margin-top: 26px; }" +
            ".igm-detail-heading { font-size:14px; font-weight:700; color:#1e3a8a; margin-bottom:8px; }" +
            ".igm-detail-subheading { font-size:12px; font-weight:700; color:#374151; margin-bottom:6px; }" +
            ".igm-tag { display:inline-block; padding:3px 10px; border-radius:12px; font-size:11px; font-weight:600; }" +
            ".igm-tag-default { background:#f3f4f6; color:#4b5563; }" +
            ".igm-tag-blue { background:#dbeafe; color:#1e40af; }" +
            ".igm-tag-green { background:#dcfce7; color:#166534; }";
    }

    function escapeHtml(value) {
        if (value === null || value === undefined) return "";
        return String(value)
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#039;");
    }

})();
</script>
</body>
</html>



