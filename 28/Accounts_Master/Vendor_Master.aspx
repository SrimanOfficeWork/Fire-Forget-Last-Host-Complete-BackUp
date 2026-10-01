<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Vendor_Master.aspx.cs" Inherits="Vendor_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Vendor</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 7.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 10em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
    <style type="text/css">
        .CalendarStyle
        {
            background-color: Crimson;
            color: White;
            border: solid 2px DarkRed;
        }
        .ajax__calendar_header
        {
            background-color: #FBB117;
            color: black;
        }
        .ajax__calendar_footer
        {
            background-color: #FBB117;
            color: black;
        }
    </style>
    <style type="text/css">
        .FixedHeader
        {
            position: absolute;
            font-weight: bold;
        }
        
        .hideGridColumn
        {
            display: none;
        }
        
        .hideGridColumn1
        {
            display: none;
        }
    </style>
    <script language="javascript">
        function B_G_tab_page2() {

            document.getElementById('page-1').style.display = 'Block';

            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'block';

        }
    </script>
    <script type="text/javascript">
        function Char_Inv(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
                return false;
            return true;
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $("[id*=gv_Chg_Details] td").bind("click", function () {
                var row = $(this).parent();
                $("[id*=gv_Chg_Details] tr").each(function () {
                    if ($(this)[0] != row[0]) {
                        $("td", this).removeClass("selected_row");
                    }
                });
                $("td", row).each(function () {
                    if (!$(this).hasClass("selected_row")) {
                        $(this).addClass("selected_row");
                    } else {
                        $(this).removeClass("selected_row");
                    }
                });
            });
        });
    </script>
<script type="text/javascript">
    function jsFunction(value) {
        alert(value);

    }

    function ddlValidation_ddlTDSYesNo(value)
     {

         if (value == 'NO') 
        {                                                  //ddlExemptionYesNo  = YES THEN 
            $("#ddlExemptionYesNo").attr('disabled', true);                   //ddlExemptionYesNo  = DISABLED
            $("#txtCertificateNo").attr('disabled', true);                   //ddlExemptionYesNo  = DISABLED
            $("#txt_Valid_From_date").attr('disabled', true);                   //ddlExemptionYesNo  = DISABLED
            $("#txt_Valid_To_date").attr('disabled', true);                   //ddlExemptionYesNo  = DISABLED
            $("#txtExemptionValue").attr('disabled', true);                   //ddlExemptionYesNo  = DISABLED
            $("#txt_TDS_Rate").attr('disabled', true);
            $("#ddlTDS_Section").attr('disabled', true);
            var TDS_Section =document.getElementById('ddlTDS_Section');
            TDS_Section.value = "";
            document.getElementById("txt_TDS_Rate").value = "";    
        }
        else 
        {
            $("#ddlExemptionYesNo").attr('disabled', false);                  //ddlExemptionYesNo  = ENABLED
            $("#txt_TDS_Rate").attr('disabled', false);
            $("#ddlTDS_Section").attr('disabled', false);  
//            $("#txtCertificateNo").attr('disabled', false);                   //ddlExemptionYesNo  = ENABLED
//            $("#txt_Valid_From_date").attr('disabled', false);                   //ddlExemptionYesNo  = ENABLED
//            $("#txt_Valid_To_date").attr('disabled', false);                   //ddlExemptionYesNo  = ENABLED
//            $("#txtExemptionValue").attr('disabled', false);                   //ddlExemptionYesNo  = ENABLED

        }
    }
    function ddlValidation_ddlExemptionYesNo(value) {
        if (value == 'NO') 
        {
            $("#txtCertificateNo").attr('disabled', true);                   //ddlExemptionYesNo  = DISABLED
            $("#txt_Valid_From_date").attr('disabled', true);                   //ddlExemptionYesNo  = DISABLED
            $("#txt_Valid_To_date").attr('disabled', true);                   //ddlExemptionYesNo  = DISABLED
            $("#txtExemptionValue").attr('disabled', true);                   //ddlExemptionYesNo  = DISABLE
        }
        else 
        {
            $("#txtCertificateNo").attr('disabled', false);                   //ddlExemptionYesNo  = ENABLED
            $("#txt_Valid_From_date").attr('disabled', false);                   //ddlExemptionYesNo  = ENABLED
            $("#txt_Valid_To_date").attr('disabled', false);                   //ddlExemptionYesNo  = ENABLED
            $("#txtExemptionValue").attr('disabled', false);                   //ddlExemptionYesNo  = ENABLED
        }
    }

    function ddlValidation_ddlForeignYesNo(value) {
        if (value == 'NO') {
            $("#txtCountryName").attr('disabled', true);                   //txtCountryName  = DISABLED            
            document.getElementById("txtCountryName").value = 'INDIA-IN';  //txtCountryName  = INDIA

        }
        else {
            $("#txtCountryName").attr('disabled', false);                   //txtCountryName  = ENABLED            
            document.getElementById("txtCountryName").value = '';           //txtCountryName  = NOT INDIA, SO ENTER NAME OF THE FOREIGN COUNTRY

        }
    }


    function changeDDL_ddlTDSYesNo() {
        alert('a');
    }

</script>
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
            <div id="innerbox_MidMain" style="height: 195px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 308px;">
                        Sundry Creditors / Vendor Master
                    </div>
                    
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="txtcon-m_Exchange" style="width: 180px;">
                            <asp:RadioButtonList ID="Rd_Job_Type" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="true" Visible="false">
                                <asp:ListItem Text="Imp" Value="Imp" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Exp" Value="Exp"></asp:ListItem>
                                <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    
                    <div id="tag_transac_lft_in2">
                        <span runat="server" id="WK" visible="false">
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none" AutoPostBack="True"
                                    Visible="false">
                                </asp:DropDownList>
                            </div>
                        </span>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <%--<input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;"  />--%>
                        </span>
                    </div>
                </div>
                <%--//start--%>
                <div id="tag_transact_src_inner" style="width: 1350px; height: 195px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1350px; height: 195px;">
                        <div id="tag_transact_lft_in1" style="width: 1300px; height: 195px;">
                            <div style="width: 1300px; height: 30px">
                                <div id="txt_container_Transact_Main_l" style="width: 225px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        Vendor Code
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 130px;">
                                        <asp:TextBox ID="txtVendorCode" runat="server" Width="120px" MaxLength="25" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="1" ></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                    <div id="tag_label_transact_Src" style="width: 85px;">
                                        Vendor Name
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 250px;">
                                        <asp:TextBox ID="txtVendorName" runat="server" Width="250px" MaxLength="100" CssClass="validate[required] txtbox_none"
                                            TabIndex="2"  AutoPostBack="false" onfocusout="Repeated_Finder(this)"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 305px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        Tax Type
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 220px">
                                        <asp:DropDownList ID="ddlTaxType" CssClass="listtxt_transac_item_gen_notn" Width="210px"
                                            runat="server" TabIndex="3" AutoPostBack="false">
                                            <asp:ListItem Text="B2B REGISTERED PURCHASE" Value="B2B REGISTERED PURCHASE"></asp:ListItem>
                                            <asp:ListItem Text="B2B UNREGISTERED PURCHASE" Value="B2B UNREGISTED PURCHASE"></asp:ListItem>
                                            <asp:ListItem Text="B2B SEZ PURCHASE" Value="B2B SEZ PURCHASE"></asp:ListItem>
                                            <asp:ListItem Text="B2B IMPORT" Value="B2B IMPORT"></asp:ListItem>
                                            <asp:ListItem Text="NON GST PURCHASE" Value="NON GST PURCHASE"></asp:ListItem>
                                            <asp:ListItem Text="B2B ZERO RATE PURCHASE" Value="B2B ZERO RATE PURCHASE"></asp:ListItem>
                                            <asp:ListItem Text="B2C PURCHASE WITH GST" Value="B2C PURCHASE WITH GST"></asp:ListItem>
                                            <asp:ListItem Text="B2C PURCHASE WITHOUT GST" Value="B2C PURCHASE WITHOUT GST"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 220px;">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        ITC/RCM
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px">
                                        <asp:DropDownList ID="ddlTaxTypeITC" CssClass="listtxt_transac_item_gen_notn" Width="150px"
                                            runat="server" TabIndex="4" AutoPostBack="false">
                                            <%--<asp:ListItem Text=" " Value="0" ></asp:ListItem>--%>
                                            <asp:ListItem Text="ITC" Value="ITC"></asp:ListItem>
                                            <asp:ListItem Text="RCM" Value="RCM"></asp:ListItem>
                                            <asp:ListItem Text="OTHERS" Value="OTHERS"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 1300px; height: 30px">
                                <div id="txt_container_Transact_Main_l" style="width: 225px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        TDS
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                        <asp:DropDownList ID="ddlTDSYesNo" CssClass="listtxt_transac_item_gen_notn" Width="80px"
                                            runat="server" TabIndex="5" AutoPostBack="false"  onchange="ddlValidation_ddlTDSYesNo(this.value);" >
                                            <%--<asp:ListItem Text=" " Value="0" ></asp:ListItem>--%>
                                            <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                            <asp:ListItem Text="NO" Value="NO" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="width: 170px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        TDS Section
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 90px;">
                                        <asp:DropDownList ID="ddlTDS_Section"  Width="80px" TabIndex="6" runat="server" CssClass="listtxt_transac_mode_new">
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

                                <div id="txt_container_Transact_Main_l" style="width: 180px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        TDS Rate
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                        <asp:TextBox ID="txt_TDS_Rate" runat="server" CssClass="txtbox_none"  Width="80px"
                           onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                 TabIndex="6"></asp:TextBox>
                                    </div>
                                </div>


                                <div id="txt_container_Transact_Main_l" style="width: 300px;">
                                    <div id="tag_label_transact_Src" style="width: 50px;">
                                        PAN No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 235px;">
                                        <asp:TextBox ID="txtPANNo" runat="server" TabIndex="6" Width="235px" MaxLength="10"
                                            CssClass="validate[minSize[10]] txtbox_none" onkeypress="return numcharspl1(event)"></asp:TextBox>
                                        <%--CssClass="txtbox_none_Mid_transac_code"--%>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 330px;">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        TAN No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 220px;">
                                        <asp:TextBox ID="txtTANNo" runat="server" TabIndex="7" Width="205px" MaxLength="10"
                                            CssClass="validate[minSize[10]] txtbox_none" onkeypress="return numcharspl1(event)"></asp:TextBox>
                                    </div>
                                </div>
                                    </div>
                                       <div style="width: 1300px; height: 30px">
                                <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        CIN No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtCINNo" runat="server" TabIndex="8" Width="140px" MaxLength="21"
                                            CssClass="validate[minSize[21]] txtbox_none" onkeypress="return numcharspl1(event)"></asp:TextBox>
                                    </div>
                                </div>
                        
                         
                                <div id="txt_container_Transact_Main_l" style="width: 165px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        Exemption
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 80px;">
                                        <asp:DropDownList ID="ddlExemptionYesNo" CssClass="listtxt_transac_item_gen_notn"
                                            Width="70px" runat="server" TabIndex="9" AutoPostBack="false"  onchange="ddlValidation_ddlExemptionYesNo(this.value);">
                                            <%-- <asp:ListItem Text=" " Value="0" ></asp:ListItem>--%>
                                            <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                            <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 315px;">
                                    <div id="tag_label_transact_Src" style="width: 85px;">
                                        Certificate No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 220px;">
                                        <asp:TextBox ID="txtCertificateNo" runat="server" TabIndex="10" Width="220px" MaxLength="50"
                                            CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 300px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        Valid From
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 85px">
                                        <asp:TextBox ID="txt_Valid_From_date" runat="server" Width="75px" MaxLength="10"
                                            CssClass="txtbox_none_Mid_transac_code" TabIndex="11"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt_Valid_From_date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Valid_From_date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 45px;">
                                        Valid To
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 85px">
                                        <asp:TextBox ID="txt_Valid_To_date" runat="server" Width="75px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="12"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Valid_To_date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_Valid_To_date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 220px;">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Exe.Value
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px">
                                        <asp:TextBox ID="txtExemptionValue" runat="server" TabIndex="13" Width="95px" MaxLength="15"
                                            CssClass="txtbox_none_Mid_transac_code" onblur="extractNumber(this,2,false);"
                                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 1100px; height: 30px">
                                <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        Credit Days
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 140px;">
                                        <asp:TextBox ID="txtCreditDays" runat="server" TabIndex="14" Width="140px" MaxLength="3"
                                            CssClass="txtbox_none_Mid_transac_code" onblur="extractNumber(this,2,false);"
                                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 200px;">
                                    <div id="tag_label_transact_Src" style="width: 85px;">
                                        Credit Limit
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                        <asp:TextBox ID="txtCreditLimits" runat="server" TabIndex="15" Width="100px" MaxLength="15"
                                            CssClass="txtbox_none_Mid_transac_code" onblur="extractNumber(this,2,false);"
                                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 225px;">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Opening Balance
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px">
                                        <asp:TextBox ID="txtOpeningBalance" runat="server" TabIndex="16" Width="100px" MaxLength="15"
                                            CssClass="txtbox_none_Mid_transac_code" onblur="extractNumber(this,2,false);"
                                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 170px">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Registered
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 80px">
                                        <asp:DropDownList ID="ddlRegisteredYesNo" CssClass="listtxt_transac_item_gen_notn"
                                            Width="75px" runat="server" TabIndex="17" AutoPostBack="false">
                                            <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                            <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 170px">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Foreign
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 80px">
                                       <asp:DropDownList ID="ddlForeignYesNo" CssClass="listtxt_transac_item_gen_notn" Width="75px"
                                            runat="server" TabIndex="18"   onchange="ddlValidation_ddlForeignYesNo(this.value);">
                                            <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                            <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                            
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div style="width: 1100px; height: 30px">
                                <div id="txt_container_Transact_Main_l" style="width: 270px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        Country
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 170px;">
                                         <asp:TextBox ID="txtCountryName" style="width: 160px;" runat="server" MaxLength="50" onblur="ChangeCase(this);"
                                         CssClass="txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                         TabIndex="19" onkeypress="return char(event)" onkeyup="ChangeCase(this);" Text="INDIA-IN" Enabled="false"></asp:TextBox>
                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="width: 390px;">
                                    <div id="tag_label_transact_Src" style="width: 60px;">
                                        Under
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 320px;">
                                        <asp:DropDownList ID="ddlUnder" CssClass="listtxt_transac_item_gen_notn" Width="320px"
                                            runat="server" TabIndex="20" >
                                          <%--  <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                            <asp:ListItem Text="NO" Value="NO"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 170px;">
                                    <div id="tag_label_transact_Src" style="width: 60px;">
                                        Active
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px">
                                        <asp:DropDownList ID="ddlActiveYesNo" CssClass="listtxt_transac_item_gen_notn" Width="80px"
                                            runat="server" TabIndex="20" >
                                            <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                            <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 220px">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Narration
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px">
                                        <asp:TextBox ID="txtNarration" runat="server" CssClass="listtxt_transac_mode_new"
                                            Width="150px" TextMode="MultiLine" TabIndex="21" MaxLength="1000"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%-------------------------BRANCH DETAILS HTML START----------------------------%>
            <div class="content" id="page-1" style="margin-top: -28px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 260px; width: 1180px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                            id="Page_A" runat="server" visible="false"><span>General</span></a></li>
                        <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                            id="Page_C" runat="server" visible="false"><span>Other </span></a></li>
                        <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');"
                            id="Page_B" runat="server"><span>Branch details</span></a></li>
                    </ol>
                    <%----------------------------General START---------------------------------------------------%>
                    <%--<div  class="content"  id="page-7"  style="display:none;height:440px;" >--%>
                    <asp:GridView ID="gvdetails" runat="server" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                        BackColor="WhiteSmoke" CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True"
                        AllowSorting="True" OnRowCommand="gvdetails_RowCommand" BorderColor="#C8C8C8"
                        BorderStyle="Solid" HorizontalAlign="Left" ShowFooter="true" Style="overflow: auto;">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:TemplateField HeaderText="SNo" HeaderStyle-Width="30px">
                                <ItemTemplate>
                                    
                                    <asp:Label ID="labgSLNo" runat="server" Text='<%#Eval("BR_SL_NO") %>' Width="30px"
                                        Enabled="false"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Branch_Loc" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBranchLoc" runat="server" Text='<%#Eval("BR_CODE_LOCATION") %>'
                                        Width="60px" CssClass="validate[required]"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address_1" HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAddress1" runat="server" Text='<%#Eval("BR_ADDRESS1") %>' Width="150px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Address_2" HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtAddress2" runat="server" Text='<%#Eval("BR_ADDRESS2") %>' Width="150px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="150px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCountryBranchName" runat="server" Text='<%#Eval("BR_COUNTRY_NAME") %>'
                                        Width="60px" MaxLength="50" onblur="ChangeCase(this);"
                                  ClientIDMode="Static"
                                  onkeypress="return char(event)" onkeyup="ChangeCase(this);"></asp:TextBox>

                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="GST_Number" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtGSTNumber" runat="server" Text='<%#Eval("BR_GSTIN_NO") %>' Width="60px" MaxLength ="15" CssClass="validate[minSize[15]]"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="State" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtState" runat="server" Text='<%#Eval("BR_STATE") %>' Width="60px" onkeypress="return char(event)"
                                                     ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Pin_Code" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPinCode" runat="server" Text='<%#Eval("BR_PIN_CODE") %>' Width="60px"
                                        MaxLength="6" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[minSize[6]]"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="60px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact_Name" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtContactName" runat="server" Text='<%#Eval("BR_CONTACT_PERSON_NAME") %>'
                                        Width="100px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile_No" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtMobileNo" runat="server" Text='<%#Eval("BR_MOBILE_NO") %>' Width="100px"
                                        MaxLength="11" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[minSize[11]]" ></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEmail" runat="server" Text='<%#Eval("BR_EMAIL_ID") %>' Width="100px"></asp:TextBox>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active_Y_N" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlBRActiveYesNo" Width="50px" Name="ddlBRActiveYesNo" SelectedValue='<%#Bind("ACTIVE_YES_NO") %>'
                                        AppendDataBoundItems="true" runat="server">
                                        <asp:ListItem Value="YES">YES</asp:ListItem>
                                        <asp:ListItem Value="NO">NO</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <ItemStyle Width="70px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgRemove" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                        OnCommand="gvdetails_RowDeleting" ImageUrl="../images/icons/delete-sign.png" Width="20px" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="Button2" runat="server" Width="40px" CommandName="add" Font-Size="Small"
                                        CssClass="coma" Visible="true" Text="Add" OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:CommandField DeleteImageUrl="../js/delete-sign.png" />
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                            NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                        <PagerStyle CssClass="pager" />
                        <EmptyDataTemplate>
                            NO RECORD FOUND
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <%--</div>--%>
                    <style type="text/css">
                        input.underlined
                        {
                            border: solid 1px #000;
                        }
                    </style>
                    <asp:HiddenField ID="HDN_VEN_SUBID" runat="server" />
                    <asp:HiddenField ID="HDN_VEN_ID" runat="server" />
                    <%--</div> --%><%------END DIV OF -------<div  class="content"  id="page-7"  style="display:none;height:440px;" >-------------%>
                    <%----------------------------Branch details END Like Charge Details----------------------------------------------%>
                </div>
            </div>
            <%-------------------------BRANCH DETAILS HTML END----------------------------%>
            <%-- --------------------Test Start----------------------------%>
            <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            TabIndex="22" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"  OnClientClick="return validate_Rec();"
                            TabIndex="20" CommandName="s" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="21" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="23" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Receipt?', 'Receipts', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="123" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu" style="display: none;">
                        <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                            id="btnCancel" tabindex="20">
                    </div>
                    <div id="editbu" style="width: 10px;">
                    </div>
                    <div id="editbu" style="padding-top: 5px; display: none;">
                        <asp:Button ID="btnrpt" runat="server" TabIndex="125" Text="Get Bill" OnClientClick="return GST_Import_Billing_Job_Rpt('B');" />
                    </div>
                </div>
            </div>
            <%-- --------------------Test End----------------------------%>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="Hd_Other_Branch_no" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script src="../js/Billing/VendorMaster.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
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
    <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });


        function close_button() {
            document.getElementById("General").click();
        }
        

    </script>
<script  type="text/javascript">
    function Repeated_Finder(lnk) 
    {
        var textboxValue;
        textboxValue = document.getElementById("txtVendorName").value
        var b = '1';
        Repeat_Start(textboxValue, b);   //Two value passed
    }
    function Repeat_Start(src, dest) {
        var bbb, ccc, ddd;
        bbb = "";
        ccc = "";
        ddd = "";        
        PageMethods.VendorName_RepeatStatus_webmethod(src, bbb, ccc, ddd, RepeatSuccess_Vendorname, RepeatFail_Vendorname, dest); // WEB METHOD  6 parameter must
    }
    function RepeatSuccess_Vendorname(res, destCtrl)
     {
         var data = res;
        if (res != '') 
        {
            alert(res);
            document.getElementById("txtVendorName").focus();
        }

    }

    function RepeatFail_Vendorname(res, destCtrl) {
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
