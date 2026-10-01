<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Supportingdoc.aspx.cs" Inherits="Supportingdoc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item | Transaction</title>
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
        <script src="../js/Export_Jscript/EXP_Single_Window_Tab.js" type="text/javascript"></script>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
     <script type="text/javascript">

         function HideModalPopup_U() {

             $find("MP_U").hide();
             return false;
         }
</script>


<script type="text/javascript">
    $(document).ready(function () {
        $("#txt_Doc_Type_Code").bind('change', function (e) {
            var doc_type = document.getElementById("txt_Doc_Type_Code").value;
            var invno = document.getElementById("hdn_invno").value;
            var invdate = document.getElementById("hdn_invdate").value;

            var COMAPNYID = document.getElementById("hdn_COMAPNYID").value;

            var Iss_Party_Ref_No = document.getElementById('hdn_txt_Doc_Iss_Party_Ref_No');
            var Iss_Date = document.getElementById('hdn_txt_Doc_Iss_Date');

            if (COMAPNYID == '5' || COMAPNYID == '747') {

                if (typeof Iss_Party_Ref_No == "undefined" || typeof Iss_Party_Ref_No == null || Iss_Party_Ref_No.value == '') {
                    alert(typeof Iss_Party_Ref_No);
                }
                else {
                    invno = Iss_Party_Ref_No.value;
                }
                if (typeof Iss_Date == "undefined" || typeof Iss_Date == null || Iss_Date.value == '') {

                }
                else {
                    Iss_Date = Iss_Date.value;
                }
            }

            if (doc_type == 'Customs invoice _ 935000' || doc_type == 'Commercial invoice which includes a packing list _ 331000' || doc_type == 'Commercial Invoice _ 380000' || doc_type == 'Product specification report _ 006000') {
                document.getElementById("txt_Doc_Iss_Party_Ref_No").value = invno;
                document.getElementById("txt_Doc_Iss_Date").value = invdate;
            }
            else if (doc_type == 'Packing list _ 271000') {
                if (COMAPNYID == '517' || COMAPNYID == '1159' || COMAPNYID == '1160' || COMAPNYID == '747' || COMAPNYID == '480' || COMAPNYID == '1011' || COMAPNYID == '1019' || COMAPNYID == '1192') {
                    document.getElementById("txt_Doc_Iss_Party_Ref_No").value = invno;
                    document.getElementById("txt_Doc_Iss_Date").value = invdate;
                }
            }
            else {
                document.getElementById("txt_Doc_Iss_Party_Ref_No").value = '';
                document.getElementById("txt_Doc_Iss_Date").value = '';
            }
        });
    });
</script>

         <script type="text/javascript">
            $(document).ready(function () {

                var icegateid = document.getElementById("hdn_ICEGATE_ID_List").value;
                var Notn = icegateid.split(',').map(String);

                var sezIcegateId = document.getElementById("hdn_SEZ_ICEGATE_ID").value;
                if (sezIcegateId != '' && Notn.indexOf(sezIcegateId) === -1) {
                    Notn.unshift(sezIcegateId);  // put it first in the list
                }

                if (icegateid != '' || sezIcegateId != '') {
                    $('#txt_IcegateID').autocomplete({
                        source: Notn,
                        minLength: 0,
                        scroll: true,
                    }).focus(function () {
                        $(this).autocomplete("search", "");
                    });
                }
            });
        </script>


<%--
<script type="text/javascript">

    $(document).ready(function () {

        if ($('#hdn_COMAPNYID').val() == '747') {
            Bind_icegateID();
        }

        if ($('#hdn_COMAPNYID').val() == '952') {
            Bind_icegateID_ShaansCargo_Export();
        }

        if ($('#hdn_COMAPNYID').val() == '1339') {
            Bind_icegateID_CN_Mehta();
        }

        if ($('#hdn_COMAPNYID').val() == '1572') {
            Bind_icegateID_RingoCargo();
        }
    });

    function Bind_icegateID() {
        var Notn = ['COECCSBD', 'GILBESBD', 'BOMCCSBD', 'DELCCSBD', 'AGLGILNSDEL', 'AGLGILRCDEL', 'AGLPSMAA', 'AGLRSMAA', 'ALPLSMMUMBAI', 'AGLGILKNBLR', 'AGLGILHRMUN'];
       
        $('#txt_IcegateID').autocomplete({
            source: Notn,
            minLength: 0,
            scroll: true
        }).focus(function () {
            $(this).autocomplete("search", "");
        });
    }


    function Bind_icegateID_ShaansCargo_Export() {
        var Notn = ['SHAANSMUM', 'SCPLSURAT'];
       
        $('#txt_IcegateID').autocomplete({
            source: Notn,
            minLength: 0,
            scroll: true
        }).focus(function () {
            $(this).autocomplete("search", "");
        });
    }


    function Bind_icegateID_CN_Mehta() {
        var Notn = ['NLANJ_CNMEHTA', 'CNMEHTA1'];

        $('#txt_IcegateID').autocomplete({
            source: Notn,
            minLength: 0,
            scroll: true
        }).focus(function () {
            $(this).autocomplete("search", "");
        });
    }


    function Bind_icegateID_RingoCargo() {
        var Notn = ['RINGOTUT', 'TUTRINGO', 'JUSTUSTUT', 'AMAZERTRANS'];

        $('#txt_IcegateID').autocomplete({
            source: Notn,
            minLength: 0,
            scroll: true
        }).focus(function () {
            $(this).autocomplete("search", "");
        });
    }

  </script>
--%>

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
            <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier" >
                
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 710px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 95px;">
                        Select Level     
                    </div>
                    <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                     </div>
                       
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Sr_No" runat="server" CssClass="validate[custom[integer]] txtbox_none_Mid_transac_item_maindet" ReadOnly="true" Enabled="false"
                            Width="110px" TabIndex="1" MaxLength="4" Visible="false"></asp:TextBox>
                            <asp:DropDownList ID="ddl_SelectType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                            Width="110px">
                            <asp:ListItem Value="JOB">Job Level</asp:ListItem>
                            <asp:ListItem Value="INVOICE">Invoice Level</asp:ListItem>
                            <asp:ListItem Value="ITEM">Item Level</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                        IRN No
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Uniq_Doc_No" runat="server" MaxLength="16" Width="110px" TabIndex="2" onkeypress="return num1(event)"
                            CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                     <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Spporting_Docs('E'); return false"
                            class="magnfy"></a>
                    </div>
                    <%--<div id="tag_label_transaction_popup_IGM2_empty">
                    </div>--%>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Doc. Type Code
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                        <asp:TextBox ID="txt_Doc_Type_Code" runat="server"  Width="100px" TabIndex="3"  CssClass="txtbox_none_Mid_transac_Supp_Name" 
                             ></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_SpportingDocs('SUPDOC','Export'); return false"
                                    class="magnfy"></a>
                            </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 670px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 95px;">
                        Iss. Party Code
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Code" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                            Width="110px" TabIndex="6" MaxLength="35"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                        Iss.Party Name
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Name" runat="server" MaxLength="70" Width="110px"
                            TabIndex="7" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Iss. Party Add.
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Add" runat="server" MaxLength="70" Width="110px"
                            TabIndex="8" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 670px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 95px;">
                        Iss. Party Add2
                    </div>
                   <%--  <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                     *</div>--%>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Add2" runat="server" MaxLength="70" Width="110px"
                            TabIndex="10" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                        Iss. Party City
                    </div>
                   <%--  <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                     *</div>--%>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_City" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            Width="110px" TabIndex="11" MaxLength="35"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Iss. Party Pin
                    </div>
                    <%-- <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                     *</div>--%>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Pin" runat="server" MaxLength="10" Width="110px"
                            TabIndex="12" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 670px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 95px;">
                     <%--   DRN No--%>
                        Doc. No
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Ref_No" runat="server" MaxLength="17" Width="110px"
                            TabIndex="13" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                        Place of Issue
                    </div>
                    <%-- <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                     *</div>--%>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Place_of_Issue" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            Width="110px" TabIndex="14" MaxLength="35"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Issue Date
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Date" runat="server" MaxLength="20" Width="110px" TabIndex="16"
                            CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_Doc_Iss_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_Doc_Iss_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 670px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 95px;">
                        Expiry Date
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                     </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Expiry_Date" runat="server" MaxLength="20" Width="110px"
                            TabIndex="17" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Doc_Expiry_Date"
                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                            Enabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Doc_Expiry_Date"
                            Format="dd/MM/yyyy" Enabled="True">
                        </asp:CalendarExtender>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                        Ben.PartyCode
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                     </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_party_Code" runat="server" Width="110px" CssClass="txtbox_none_Mid_transac_item_maindet"
                            TabIndex="18" MaxLength="35"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Ben.Party Name
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Ben_Party_Name" runat="server" MaxLength="70" Width="110px"
                            TabIndex="19" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 670px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 95px;">
                        Ben.Party Add
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_party_Add1" runat="server" MaxLength="70" Width="110px"
                            TabIndex="20" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                        Ben.PartyAdd2
                    </div>
                   <%--  <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                     *</div>--%>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_party_Add2" runat="server" MaxLength="70" Width="110px"
                            TabIndex="21" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Ben. Party City
                    </div>
                 <%--    <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>--%>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_Party_City" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            Width="110px" TabIndex="22" MaxLength="35"></asp:TextBox>
                    </div>
                </div>

                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 670px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 95px;">
                        Ben.Party Pin
                    </div>
                   <%--  <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>--%>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_Party_Pin" runat="server" MaxLength="10" Width="110px" TabIndex="23"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                        File Type
                    </div>
                     <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_File_type" runat="server" MaxLength="5" Width="110px" TabIndex="24"
                            CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px; font-weight:bold;">
                        Icegate ID
                    </div>
                    <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">
                    * </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                         <asp:TextBox ID="txt_IcegateID" runat="server" MaxLength="25" Width="140px" TabIndex="25"  Font-Bold="true"
                            onkeyup="return ChangeCase(this);"  CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                    </div>
                </div>

                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 670px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 105px;">
                       Icegate FileName
                    </div>
                     
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 230px;">
                        <asp:TextBox ID="txt_IcegateFilename" runat="server" MaxLength="200" Width="230px" TabIndex="26"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="div_AmendmentType" visible="false"  runat="server">
                                <div id="tag_label_transaction_popup_gen" style="width: 135px; font-weight: bold;">
                                    Amendment Type
                                </div>
                                <div id="txtcon-m_transaction_item_maindet" style="width: 120px">
                                    <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                        Width="120px">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="A">AMENDMENT</asp:ListItem>
                                        <asp:ListItem Value="S">SUPPLEMENT</asp:ListItem>
                                        <asp:ListItem Value="D">DELETE</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                    </div>
               
            
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty_Re_import">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" TabIndex="27" 
                            OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="25"
                            OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btn_save_new" Text="Save & New" runat="server" CssClass="autowidupdatebut" OnClick="btn_save_new_Click" TabIndex="25"/>
                    </div>      


                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="25" OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="26" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'SW Supportingdocs', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="26" OnClick="btnDelete_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                      <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('ItemMain');return false;"
                        tabindex="27" CausesValidation="false" UseSubmitBehavior="false" />
                       <%-- <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button();"
                            tabindex="14" id="btnCancel" />--%>
                    </div>
                    <div id="editbu" style="width: 150px;">
                        <asp:Button ID="btn_Sup_Doc_XL_Upload" Text="Sup Doc XL Upload" CssClass="autowidupdatebut"
                            CausesValidation="false" Width="120px" runat="server" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hide');Open_Exp_Sup_Doc_XL_Upload();return false;" />
                    </div>
                   <%-- <div id="editbu">
                        <asp:Button ID="btnItem_move" Text="Move" CssClass="autowidupdatebut" Width="50px"
                            runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_Exp_Sup_doc_Del('New'); return false;" />
                    </div>--%>

                     <div id="editbu" style="width: 80px;">
                       
                        <asp:Button ID="btn_Sup_Doc_del" Text="Delete All" CssClass="autowidupdatebut"
                            CausesValidation="false" Width="70px" runat="server" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hide');Open_Imp_Sup_Doc_XL_Upload();return false;" />
                    </div>


                </div>
                <div id="tag_transac_lft_Item_reimport_Grid_area" style=" overflow:auto; height:90px; width:700px;">
                    <asp:GridView ID="gv_ReImport" runat="server" DataKeyNames="SW_ID  ,JOBNO" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%" 
                        ShowHeaderWhenEmpty="True" OnRowDataBound="gv_ReImport_RowDataBound"
                        OnSelectedIndexChanged="gv_ReImport_SelectedIndexChanged" PageSize="6" AllowPaging="False"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_ReImport_RowCreated">
                        <Columns>
                         <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="26px">
                                        <ItemTemplate>
                                        <asp:Label ID="lblitemslno"   runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  HorizontalAlign="Center"  Width="26px"  />
                           </asp:TemplateField>

                            <asp:BoundField DataField="SLNO" HeaderText="Sr. No" ControlStyle-Width="20px">
                                <HeaderStyle CssClass="hideGridColumn" />
                                   <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UNIQUE_DOC_NUMBER" HeaderText="IRN No" ControlStyle-Width="40px">
                                <ItemStyle CssClass="column_style_left5" Width="70px"/>
                            </asp:BoundField>
                              <asp:BoundField DataField="DOC_TYPE_CODE" HeaderText="Doc.Type.Code" ControlStyle-Width="70px">
                                <ItemStyle CssClass="column_style_left5" Width="70px"/>
                            </asp:BoundField>
                          
                           <asp:BoundField DataField="DOC_ISSUING_PARTY_CODE" HeaderText="Iss.Party Name" ControlStyle-Width="45px">
                                 <HeaderStyle CssClass="hideGridColumn" />
                                   <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>

                             <asp:BoundField DataField="DOC_ISSUING_PARTY_NAME_ADD1">
                                  <HeaderStyle CssClass="hideGridColumn" />
                                   <ItemStyle CssClass="hideGridColumn" />
                             </asp:BoundField>
                             <asp:BoundField DataField="DOC_ISSUING_PARTY_NAME_ADD2">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                              <asp:BoundField DataField="DOC_ISSUING_PARTY_CITY">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="DOC_ISSUING_PARTY_PIN">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="DOC_REF_NUMBER"  HeaderText="DRN No" ControlStyle-Width="40px">
                              <ItemStyle CssClass="column_style_left5" Width="70px"/>
                              </asp:BoundField>
                               <asp:BoundField DataField="PLACE_OF_ISSUE">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="DOC_ISSUE_DATE">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="DOC_EXPIRY_DATE">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="BENEFICIARY_PARTY_CODE">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="BENEFICIARY_PARTY_ADDRESS1">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="BENEFICIARY_PARTY_ADDRESS2">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="BENEFICIARY_PARTY_CITY">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="BENEFICIARY_PARTY_PIN">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="FILE_TYPE">
                               <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>

                            <asp:BoundField DataField="DOC_ISSUING_PARTY_NAME">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BENEFICIARY_PARTY_NAME">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>

                            <asp:BoundField DataField="ICEGATE_ID">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="ICEGATE_DOC_FILE_NAME">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AMENDMENT_TYPE">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                             <asp:BoundField DataField="SELECT_TYPE"  HeaderText="Level" ControlStyle-Width="40px">
                              <ItemStyle CssClass="column_style_left5" Width="70px"/>
                              </asp:BoundField>

                        </Columns>

                      

                    </asp:GridView>
                </div>
            </div>

                <asp:HiddenField ID="hdn_update_STMT" runat="server" />
                <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                <asp:HiddenField ID="hdn_Normal_Bulk" runat="server" />

                <asp:HiddenField ID="hdn_invno" runat="server" />
                <asp:HiddenField ID="hdn_invdate" runat="server" />
                <asp:HiddenField ID="hdn_COMAPNYID" runat="server" />

                <asp:HiddenField ID="hdn_txt_Place_of_Issue" runat="server"  ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_txt_Doc_Iss_Party_Ref_No" runat="server"  ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_txt_Doc_Iss_Date" runat="server"  ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_ICEGATE_ID_List" runat="server"  ClientIDMode="Static"/>
                <asp:HiddenField ID="hdn_SEZ_ICEGATE_ID" runat="server"   ClientIDMode="Static"/>
           
           
        </ContentTemplate>
    </asp:UpdatePanel>


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

     <script src="../js/iframepopupwin.js" type="text/javascript"></script>
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
        function Open_Imp_Sup_Doc_XL_Upload() {
            window.parent.open_Exp_Sup_doc_Del();
            return false;

        }

    </script>

    
     <script type="text/javascript">

         $(function () {
             $("#txt_Doc_Type_Code").autocomplete({

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

    </script>




    <script src="../js/Import_Jscript/IMP_Single_Window.js" type="text/javascript"></script>

      <script type="text/javascript">

          function CallServerside_Doc_Type_Code(src, dest) {
              var ctrl = document.getElementById(src);
              PageMethods.Doc_Type_Code(ctrl.value, CallSuccess_Doc_Type_Code, CallFailed, dest);
          }
          function CallSuccess_Doc_Type_Code(res, destCtrl) {

              if (res.indexOf("~~") != -1 && res.indexOf("~~") != '') {

                  var s = res.split('~~');

                  var code = s[0];
                  var type = s[1];

                  if (code == "True") {
                      document.getElementById('txt_Doc_Type_Code').style.border = "1px solid #c8c8c8";
                      document.getElementById('ddl_SelectType').value = type;
                      document.getElementById("txtErr_Desc").value = '';
                  }
                  else if (code == "False") {

                      document.getElementById('txt_Doc_Type_Code').style.border = "1px solid Red";
                      document.getElementById("txtErr_Desc").value = 'Error : Invalid Doc. Type Code !';
                  }
              }
              else {

                  document.getElementById('txt_Doc_Type_Code').style.border = "1px solid Red";
                  document.getElementById("txtErr_Desc").value = 'Error : Invalid Doc. Type Code !';
              }
          }

          //-------------------------------------------------------------------------------------------------------------------------
          function CallFailed(res, destCtrl) {

          }

    </script>

</body>
</html>
