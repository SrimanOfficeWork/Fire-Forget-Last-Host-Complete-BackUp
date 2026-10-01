<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SW_Supportingdoc.aspx.cs"
    Inherits="Supportingdoc" %>

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

    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txt_Doc_Type_Code").bind('focusout', function (e) {
                var doc_type = document.getElementById("txt_Doc_Type_Code").value;
                var invno = document.getElementById("hdn_invno").value;
                var invdate = document.getElementById("hdn_invdate").value;

                var mbl_no = document.getElementById("hdn_mbl_no").value;
                var mbldate = document.getElementById("hdn_mbldate").value;

                var hblno = document.getElementById("hdn_hblno").value;
                var hbldate = document.getElementById("hdn_hbldate").value;

                var COMAPNYID = document.getElementById("hdn_COMAPNYID").value;


                if (doc_type == 'Customs invoice _ 935000' || doc_type == 'Commercial invoice which includes a packing list _ 331000' || doc_type == 'Commercial Invoice _ 380000') {
                    document.getElementById("txt_Doc_Iss_Party_Ref_No").value = invno;
                    document.getElementById("txt_Doc_Iss_Date").value = invdate;
                }

                else if (doc_type == 'Bill of lading _ 705000' || doc_type == 'Air waybill _ 740000' || doc_type == 'Sea waybill _ 710000' || doc_type == 'Waybill _ 700000' || doc_type == 'Master air waybill _ 741000' || doc_type == 'Master bill of lading _ 704000') {
                    document.getElementById("txt_Doc_Iss_Party_Ref_No").value = mbl_no;
                    document.getElementById("txt_Doc_Iss_Date").value = mbldate;

                }
                else if (doc_type == 'House bill of lading _ 714000' || doc_type == 'House waybill _ 703000') {
                    document.getElementById("txt_Doc_Iss_Party_Ref_No").value = hblno;
                    document.getElementById("txt_Doc_Iss_Date").value = hbldate;

                }
                else if (doc_type == 'Packing list _ 271000') {
                    if (COMAPNYID == '1159' || COMAPNYID == '1160' || COMAPNYID == '747' || COMAPNYID == '5') {
                        document.getElementById("txt_Doc_Iss_Party_Ref_No").value = invno;
                        document.getElementById("txt_Doc_Iss_Date").value = invdate;
                    }
                }
                else {
                    if ($('#hdn_COMAPNYID').val() == '5' || $('#hdn_COMAPNYID').val() == '747') {
                        //document.getElementById("txt_Doc_Iss_Party_Ref_No").value = '';
                    }
                    else {
                        document.getElementById("txt_Doc_Iss_Party_Ref_No").value = '';
                    }

                    var d = new Date();
                    document.getElementById("txt_Doc_Iss_Date").value = [d.getDate(), d.getMonth() + 1, d.getFullYear()].join('/');
                }

            });
        });
    </script>

   <%-- <script type="text/javascript">

        $(document).ready(function () {
            if ($('#hdn_COMAPNYID').val() == '10') {
                Bind_icegateID();
            }

            if ($('#hdn_COMAPNYID').val() == '952') {
                Bind_icegateID_ShaansCargo_Import();
            }

            if ($('#hdn_COMAPNYID').val() == '1339') {
                Bind_icegateID_CN_Mehta();
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

        function Bind_icegateID_ShaansCargo_Import() {
            var Notn = ['SHAANSSUR', 'SCPLMUMBAI'];

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


    </script>--%>

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
 
</script>

    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
    <style type="text/css">
        .txtbox_Multi
        {
            border: thin solid #c8c8c8;
            border-radius: 5px;
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 200px;
            margin-top: 2px;
            max-height: 140px;
            max-width: 750px;
            overflow: auto;
            width: 235px;
            margin-left: -20px;
        }
    </style>
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .GridPager a, .GridPager span
        {
            display: block;
            height: 15px;
            width: 15px;
            font-weight: bold;
            text-align: center;
            text-decoration: none;
        }
        .GridPager a
        {
            background-color: #f5f5f5; /* color: #969696; */
            color: #c8c8c8;
            border: 1px solid #969696;
        }
        .GridPager span
        {
            /*background-color: #A1DCF2;*/
            background-color: #ff8000;
            color: #000;
            border: 1px solid #3AC0F2;
        }
        
        
        .icon-btn {
    border: none;
    background: none;
    cursor: pointer;
    font-size: 20px;
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
            <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier" style="height: 410px">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 720px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 94px;">
                        Select Level
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:DropDownList ID="ddl_SelectType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                            Width="110px">
                            <asp:ListItem Value="JOB">Job Level</asp:ListItem>
                            <asp:ListItem Value="INVOICE">Invoice Level</asp:ListItem>
                            <asp:ListItem Value="ITEM">Item Level</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Image Ref. no
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                        <asp:TextBox ID="txt_Image_RefNO" runat="server" MaxLength="16" Width="100px" TabIndex="2"
                            ClientIDMode="Static" onkeypress="return num1(event)" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Spporting_Docs('I'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Doc. Type Code
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Type_Code" runat="server" Width="110px" TabIndex="5" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_SpportingDocs('SUPDOC','Import'); return false"
                            class="magnfy"></a>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 720px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 94px;">
                        Iss. Party Code
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Code" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                            Width="110px" TabIndex="6" MaxLength="35"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Iss.Party Name
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Name" runat="server" MaxLength="70" Width="110px"
                            TabIndex="7" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Iss. Party Add1
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Add1" runat="server" MaxLength="70" Width="110px"
                            TabIndex="8" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>

                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 12px;">
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 30px;">
                         <asp:ImageButton ID="btn_SupDoc_New" Height="26px" Width="30px" ToolTip="Bulk SupDocs" ImageUrl="~/images/icons/supdocs_images.png" runat="server"
                     OnClientClick="Bulk_SupDocs_New(); return false;" /> 
                    </div>

                     </div> 


                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 690px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 94px;">
                        Iss. Party Add2
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Add2" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            Width="110px" TabIndex="9" MaxLength="70"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Iss. Party City
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_City" runat="server" MaxLength="35" Width="110px"
                            TabIndex="10" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Iss. Party Pin
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Pin" runat="server" MaxLength="10" Width="110px"
                            TabIndex="11" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 690px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 94px;">
                        Doc. No
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                        </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Party_Ref_No" runat="server" MaxLength="17" Width="110px"
                            TabIndex="12" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Place of Issue
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Place_of_Issue" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            Width="110px" TabIndex="13" MaxLength="35"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Issue Date
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Iss_Date" runat="server" MaxLength="20" Width="110px" TabIndex="15"
                            CssClass="validate[required]  txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
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
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 690px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 94px;">
                        Expiry Date
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Doc_Expiry_Date" runat="server" MaxLength="20" Width="110px"
                            TabIndex="16" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
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
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Ben. Party Code
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_party_Code" runat="server" MaxLength="35" Width="110px"
                            TabIndex="20" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Ben.Party Name
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_party_Name" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            Width="110px" TabIndex="21" MaxLength="70"></asp:TextBox>
                    </div>
                    <%-- <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>--%>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 690px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 94px;">
                        Ben.Party Add1
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_party_Add1" runat="server" MaxLength="70" Width="110px"
                            TabIndex="22" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Ben. Party Add2
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_party_Add2" runat="server" MaxLength="70" Width="110px"
                            TabIndex="23" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        Ben. Party City
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_Party_City" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            Width="110px" TabIndex="25" MaxLength="35"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 690px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 94px;">
                        Ben.Party Pin
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_Ben_Party_Pin" runat="server" MaxLength="10" Width="110px" TabIndex="27"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                        File Type
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                        *</div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                        <asp:TextBox ID="txt_File_type" runat="server" MaxLength="5" Width="110px" TabIndex="28"
                            CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;
                        font-weight: bold;">
                        Icegate ID
                    </div>
                    <div id="tag_label_transaction_popup_mode_empty" style="color: Red; width: 10px;">
                        *
                    </div>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 120px;">
                        <asp:TextBox ID="txt_IcegateID" runat="server" MaxLength="25" Width="120px" TabIndex="29"
                            Font-Bold="true" onkeyup="return ChangeCase(this);" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <%--<div id="div_AmendmentType"  Visible="false" runat="server"  style="margin-top:5px">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 80px; font-weight:bold;">
                        Amend Type
                    </div>
                     <div id="txtcon-m_transaction_code_BE_TYPE" style="width:100px;" >
                         <asp:DropDownList ID="ddl_AmendmentType" runat="server"  TabIndex="1"  CssClass="listtxt_transac_mode_new"  Width="100px">
                         <asp:ListItem Value=""></asp:ListItem>
                         <asp:ListItem Value="S">SUPPLEMENT</asp:ListItem>
                         <asp:ListItem Value="D">DELETE</asp:ListItem>
                         </asp:DropDownList>
                    </div>
                    </div>--%>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 780px;">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 104px;">
                        Icegate FileName
                    </div>
                    <%--  <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    </div>--%>
                    <div id="txtcon-m_transaction_item_maindet" style="width: 190px;">
                        <asp:TextBox ID="txt_IcegateFileName" runat="server" MaxLength="70" Width="189px"
                            TabIndex="30" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="editbu">
                        <asp:TextBox ID="txtErr_Desc" runat="server" MaxLength="70" Width="250px" ForeColor="Red"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="width: 60px;">
                        <asp:LinkButton ID="lnk_supp" Text="FTA Copy" ToolTip="Copy IRN to All items in this Invoice"
                            runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Do U Want to Copy - this IRN to all Items in this Invoice  ? ', 'SUP DOCS-BULK COPY', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {         
              document.getElementById('btn_Bulk_IRN_Copy').click();          
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn_Bulk_IRN_Copy" runat="server" TabIndex="11" CssClass="dlete"
                            Style="display: none;" OnClick="btn_Bulk_IRN_Copy_Click" />
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="width: 70px;">
                        <asp:LinkButton ID="lnk_Delte" Text="FTA Delete" ToolTip="Delete IRN to All items in this Invoice"
                            runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Do U Want to Delete - this IRN to all Items in this Invoice  ? ', 'SUP DOCS-BULK DELETE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {         
              document.getElementById('btn_Bulk_IRN_Delete').click();          
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn_Bulk_IRN_Delete" runat="server" TabIndex="11" CssClass="dlete"
                            Style="display: none;" OnClick="btn_Bulk_IRN_Delete_Click" />
                    </div>

                     <div id="magnify_area" style="margin-left:-5px">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_EsanchitTrack('Esanchit','Import'); return false"
                            class="magnfy"></a>

                            
                    </div>

                </div>


                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty_Re_import">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            TabIndex="34" OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" TabIndex="30" OnClick="btnSave_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btn_save_new" Text="Save & New" CssClass="autowidupdatebut" TabIndex="30"
                            runat="server" OnClick="btn_save_new_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="32" OnClientClick=" return validate_Import_Reimport()" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="33" Visible="false" CssClass="dlete"
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
                            TabIndex="35" CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                    <%-- <div id="editbu" >
                      <asp:TextBox ID="txtErr_Desc" runat="server" MaxLength="70" Width="350px" ForeColor="Red"  
                       CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                     </div>--%>
                    <div id="editbu" >
                        &nbsp; <a href="../Submission/Import_Excel_Format/IMP_SUPPORTING_DOC_XL_UPLOAD.xlsm"
                            target="_new">
                            <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"
                                Height="30px" Width="30px" runat="server" />
                        </a>
                    </div>
                    <div id="editbu" style="width: 80px;">
                        &nbsp;
                        <asp:Button ID="btn_Sup_Doc_XL_Upload" Text="XL Upload" CssClass="autowidupdatebut"
                            CausesValidation="false" Width="70px" runat="server" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hide');Open_Imp_Sup_Doc_XL_Upload();return false;" />
                    </div>
                    <div id="div_AmendmentType" visible="false" runat="server" style="margin-top: 5px;">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 80px;
                            font-weight: bold;">
                            Amend Type
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width: 10px;">
                        </div>
                        <div id="txtcon-m_transaction_code_BE_TYPE" style="width: 45px;">
                            <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="30" CssClass="listtxt_transac_mode_new"
                                Width="40px">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="S">S</asp:ListItem>
                                <asp:ListItem Value="D">D</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="editbu" style="margin-top:-5px;">
                                            <asp:Button ID="btn_Amend_FF" Text="Flatfile" CssClass="autowidmovebut" runat="server"
                                                OnClientClick="Open_Amend_Flatfile(); return false" Width="50px" />
                                        </div>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty" style="width: 40px;">
                        <asp:LinkButton ID="lnk_supp2" Text="Bulk Copy" ToolTip="Copy IRN to All items in this Invoice"
                            runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Do U Want to Copy - this IRN to all Items in this Invoice  ? ', 'SUP DOCS-BULK COPY', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {         
              document.getElementById('btn_Bulk_RITC_Copy').click();          
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn_Bulk_RITC_Copy" runat="server" TabIndex="11" CssClass="dlete"
                            Style="display: none;" OnClick="btn_Bulk_RITC_Copy_Click" />
                    </div>
                    <%--<div id="tag_label_transaction_popup_IGM2_empty"></div>--%>

                    <div id="tag_label_transaction_popup_IGM2_empty" style="width: 10px;">
                        <asp:LinkButton ID="lnk_Delte2" Text="Bulk Delete" ToolTip="Delete IRN to All items in this Invoice"
                            runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Do U Want to Delete - this IRN to all Items in this Invoice  ? ', 'SUP DOCS-BULK DELETE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {         
              document.getElementById('btn_Bulk_RITC_Delete').click();          
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn_Bulk_RITC_Delete" runat="server" TabIndex="11" CssClass="dlete"
                            Style="display: none;" OnClick="btn_Bulk_RITC_Delete_Click" />
                    </div>
                </div>
                <div id="tag_transac_lft_Item_reimport_Grid_area" style="overflow: auto; height: 105px;">
                    <asp:GridView ID="gv_ReImport" runat="server" DataKeyNames="SW_ID,JOBNO" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="150%"
                        ShowHeaderWhenEmpty="True" OnRowDataBound="gv_ReImport_RowDataBound" OnSelectedIndexChanged="gv_ReImport_SelectedIndexChanged"
                        PageSize="3" AllowPaging="true" AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gv_ReImport_RowCreated"
                        OnPageIndexChanging="gv_ReImport_PageIndexChanging">
                        <PagerStyle HorizontalAlign="left" CssClass="GridPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="26px">
                                <ItemTemplate>
                                    <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="26px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="DECLARATION_TYPE" HeaderText="Decl.Type" ControlStyle-Width="40px">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMAGE_REF_NUMBER" HeaderText="Img Ref No" ControlStyle-Width="40px">
                                <ItemStyle CssClass="column_style_left5" Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOC_TYPE_CODE" HeaderText="Doc.Type" ControlStyle-Width="20px">
                                <ItemStyle CssClass="column_style_left5" Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOC_ISSUING_PARTY_CODE">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOC_ISSUING_PARTY_NAME" HeaderText="Party Name" ControlStyle-Width="45px">
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
                            <asp:BoundField DataField="DOC_REF_NUMBER">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PLACE_OF_ISSUE"  HeaderText="Place of Issue" ControlStyle-Width="70px">
                                 <ItemStyle CssClass="column_style_left5" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOC_ISSUE_DATE"  HeaderText="Doc.Issue Dt" ControlStyle-Width="70px">
                                 <ItemStyle CssClass="column_style_left5" Width="40px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOC_EXPIRY_DATE">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BENEFICIARY_PARTY_CODE">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BENEFICIARY_PARTY_NAME">
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
                            <asp:BoundField DataField="SELECT_TYPE">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ICEGATE_ID" HeaderText="Icegate ID" ControlStyle-Width="75px">
                                <ItemStyle CssClass="column_style_left5" Width="75px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ICEGATE_DOC_FILE_NAME" HeaderText="Icegate FileName" ControlStyle-Width="75px">
                                <ItemStyle CssClass="column_style_left5" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="AMENDMENT_TYPE" HeaderText="AmendType" ControlStyle-Width="75px">
                                <ItemStyle CssClass="column_style_left5" Width="50px" />
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
            <asp:HiddenField ID="hdn_mbl_no" runat="server" />
            <asp:HiddenField ID="hdn_mbldate" runat="server" />
            <asp:HiddenField ID="hdn_hblno" runat="server" />
            <asp:HiddenField ID="hdn_hbldate" runat="server" />
            <asp:HiddenField ID="hdn_COMAPNYID" runat="server" />
            <asp:HiddenField ID="hdn_ICEGATE_ID_List" runat="server" />
            <asp:HiddenField ID="hdn_SEZ_ICEGATE_ID" runat="server"/>
            <asp:HiddenField ID="hdn_Jobno" runat="server" />
            <asp:HiddenField ID="hdn_InvSlno" runat="server" />
            <asp:HiddenField ID="hdn_ItemSlno" runat="server" />


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
            window.parent.OPEN_IMP_SUPPDOC_Excel_Upload();
            return false;

        }


        function Bulk_SupDocs_New() {
            NewWindow1(
            '../Transaction/Imp_Bulk_Supp_Doc_New.aspx',
            'List',
            '1250',
            '1024',
            'yes'
        );

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
    <%--hdn_update_STMT--%>
    <script type="text/javascript">

        function CallServerside_Image_RefNO(src, dest) {
            var ctrl = document.getElementById(src);
            var ss = document.getElementById('hdn_update_STMT').value;

            PageMethods.Image_RefNO(ctrl.value, ss, CallSuccess_Image_RefNO, CallFailed, dest);
        }
        function CallSuccess_Image_RefNO(res, destCtrl) {
            if (res == "0") {
                document.getElementById('txt_Image_RefNO').style.border = "1px solid #c8c8c8";
                document.getElementById("txtErr_Desc").value = '';

            }
            else {
                document.getElementById('txt_Image_RefNO').style.border = "1px solid Red";
                if (res == "1") {
                    document.getElementById("txtErr_Desc").value = 'Error : Image Ref.no should be ( 16 ) Digit!';
                }
                else if (res == "2") {
                    document.getElementById("txtErr_Desc").value = 'Error :  Image Ref. No Already available !';
                }
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------

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


        function Open_Amend_Flatfile() {
            var amd_type = document.getElementById("ddl_AmendmentType").value;
            var amd_page = 'SUPPORTING_DOCS';
            var amd_Jobno = document.getElementById("hdn_Jobno").value;
            var amd_Invslno = document.getElementById("hdn_InvSlno").value;
            var amd_Itemslno = document.getElementById("hdn_ItemSlno").value;

            NewWindow1('../Amendment/Import_Amendment.aspx?amd_type=' + amd_type + '&amd_page=' + amd_page + '&amd_Jobno=' + amd_Jobno + '&amd_Invslno=' + amd_Invslno, 'List', '950', '515', 'yes');
        }

    </script>
</body>
</html>
