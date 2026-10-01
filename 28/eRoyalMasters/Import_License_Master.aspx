<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_License_Master.aspx.cs" Inherits="Import_License_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>License Master | Updation</title>
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
        
           .hideGridColumn
        {
            display: none;
        }
    </style>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/Import_License_Master.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_Bond.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/Import_Jscript/Import_Bond.js"></script>
  <%--  <script type="text/javascript">
        $(document).ready(function () {
            $('#txtQty').keyup(function () {
                var TD = $('#txtQty').val();
                var RD = $('#txt_Remaining_Qty').val();

                if (Number(TD) >= Number(RD)) {
//                    alert('a');
                }
                else {
                    alert('Todal Debit Qty is lesser than Remaining Qty');
                }
            });
        });
    </script>

        <script type="text/javascript">
            $(document).ready(function () {
                $('#txt_Debit_Amt').keyup(function () {
                    var TD = $('#txt_Debit_Amt').val();
                    var RD = $('#txt_Remaining_Amt').val();

                    if (Number(TD) >= Number(RD)) {
//                        alert('a');
                    }
                    else {
                        alert('Todal Debit Amt is lesser than Remaining Amt');
                    }
                });
            });
    </script>--%>


    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtReg_No').focusout(function () {
                var RegNo = $('#txtReg_No').val();
                var Schemecode = $('#ddl_Lic_Type').val();
                var chk_SingleDuty = $('#ddl_Lic_Type').val();


                if (Schemecode == '36-MEIS') {
                    var result = PageMethods.Get_Single_DutyValue(RegNo, Schemecode, onSuccess, onError)
                }
            });
            function onSuccess(data) {

                var aa = data.split('~');
                if (aa[0] > 0) {
                    $('#txt_Debit_Amt').val(aa[0]);
                    $('#txtQty').val(aa[1]);
                }

            }

            function onError(errorMessage) {
                //                alert(errorMessage);
            }
        });
    </script>

    <script type="text/javascript">

        function validateDecimalTwoPlaces(el, evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;

            // BLOCK letters, spaces, minus, etc.
            if ((charCode >= 65 && charCode <= 90) ||
        (charCode >= 97 && charCode <= 122) ||
        charCode == 32) {
                return false;
            }

            // Allow only numbers and dot
            if (charCode != 46 && (charCode < 48 || charCode > 57))
                return false;

            // Only one dot allowed
            if (charCode == 46 && el.value.indexOf('.') !== -1)
                return false;

            // Limit to 2 digits after decimal
            var value = el.value;
            if (value.indexOf('.') !== -1) {
                var decimalPart = value.split('.')[1];
                if (decimalPart.length >= 2)
                    return false;
            }

            return true;
        }

    
    </script>

</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" style="height:323px" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
           
            <div id="innerbox_MidMain_popup_adcode"  style="height:380px;width:750px; margin-left: 10px">
                <div id="innerbox_MidMain_top_adcode" style="width:1184px;">
                    LICENSE MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <%--<div id="innerbox_MidMain_Mid_adcode">--%>
                <div id="innerbox_MidMain_Mid_ClientMaster" style="height: 390px;width:750px; margin-left:10px;">
                    <div id="innerbox_MidMain_Mid_ClientMaster_l" style="width:350px">
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Party Name
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_PartyName" runat="server" CssClass="txtbox_none" Onkeypress="return numchar(event)"
                                    TabIndex="1" MaxLength="50"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                       
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Licence Regn. No</div>
                            <div id="txtcon_mid_size">
                                <asp:TextBox ID="txtReg_No" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="2" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Licence Regn Date</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtReg_date" runat="server" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="3" MaxLength="40"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtLicense_date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtLicense_date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Excemption</div>
                            <div id="txtcon-m_transaction_mode">
                                <asp:DropDownList ID="ddl_Excemption" runat="server" CssClass="listtxt_transac_mode_new"
                                    TabIndex="4">
                                    <asp:ListItem>Y</asp:ListItem>
                                    <asp:ListItem>N</asp:ListItem>
                                    <asp:ListItem>E</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_Src_longlabel" style="width: 65px; text-align: center">
                                Type</div>
                            <div id="txtcon-m_transaction_list1">
                                <asp:DropDownList ID="ddl_Lic_Type" runat="server" CssClass="listtxt_transac_src1"
                                    TabIndex="5">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Single Duty Value
                            </div>
                            <div id="txtcon_mid_size">
                                <asp:CheckBox ID="chk_single_Duty" runat="server" TabIndex="6" />
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                License ItemNo</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_License_ItemNo" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="7" MaxLength="4" Onkeypress="return pin(event)"></asp:TextBox></div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Port Of License</div>
                            <div id="txtcon_mid_size">
                                <asp:TextBox ID="txtPort_Of_Licenses" runat="server" CssClass="validate[minSize[6]] txtbox_none_mid_size"
                                    TabIndex="8" MaxLength="8" Onkeypress="return numchar(event)"></asp:TextBox></div>
                            <div id="magnify_area">
                                <a href="#" shape="poly" onclick="OpenPopupCustom_House_Details(); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Licence No
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtLicense_no" runat="server" CssClass="txtbox_none" TabIndex="9"
                                    Onkeypress="return pin(event)" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Licence Date</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtLicense_Date" runat="server" CssClass="txtbox_none" TabIndex="10"
                                    Onkeypress="return numchar(event)" MaxLength="40"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtReg_date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtReg_date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Licence Desc</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtLic_Desc" runat="server" CssClass="txtbox_none" TabIndex="11"
                                    Height="25px" TextMode="MultiLine" Onkeypress="return numchar(event)" MaxLength="40"></asp:TextBox>
                            </div>
                        </div>
                        <div id="lblMsg2" style="display: none;">
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Mid_ClientMaster_l" style="width:400px;">
                        <div id="pop_text_area_Clientname" style="width:350px; margin-left:35px">
                            <div id="tag_label_Clientname">
                                Total CIF Value
                            </div>
                            <div id="txtcon-m_src" style="margin-left:18px;">
                                <asp:TextBox ID="txt_CIFValue" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="12" MaxLength="18" Width="130px" onkeypress="return validateDecimalTwoPlaces(this, event);"></asp:TextBox></div>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:350px; margin-left:35px">
                            <div id="tag_label_Clientname">
                                Remaining CIF
                            </div>
                            <div id="txtcon-m_src" style="margin-left:18px">
                                <asp:TextBox ID="txt_Remaining_CIF" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                     MaxLength="12" ReadOnly="true" Width="130px" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox></div>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:350px; margin-left:35px">
                            <div id="tag_label_Clientname" >
                                Total Debit Duty
                            </div>
                            <div id="txtcon-m_src" style="margin-left:18px" >
                                <asp:TextBox ID="txt_Debit_Amt" runat="server" onkeyup="autotab(this);" CssClass="txtbox_none"
                                    onkeypress="return validateDecimalTwoPlaces(this, event);" TabIndex="13" MaxLength="17"
                                    Width="130px"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname" style="width:350px; margin-left:35px">
                            <div id="tag_label_Clientname">
                                Remaining Duty
                            </div>
                            <div id="txtcon-m_src" style="margin-left:18px;">
                                <asp:TextBox ID="txt_Remaining_Amt" runat="server" onkeyup="autotab(this);" CssClass="txtbox_none"
                                    ReadOnly="true" onkeypress="return blockNonNumbers(this, event, true, false);"
                                     MaxLength="17" Width="130px"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname" style="width:420px; margin-left:35px">
                            <div id="tag_label_Clientname">
                                Total Debit Qty
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;margin-left:18px">
                                <asp:TextBox ID="txtQty" runat="server" CssClass="txtbox_none_Mid_transac_code" TabIndex="14" 
                                    MaxLength="10" onkeypress="return validateDecimalTwoPlaces(this, event);"></asp:TextBox></div>
                            <div id="tag_label_transaction_Src_longlabel" style="width: 35px; text-align: center">
                                Unit</div>
                            <div id="txtcon-m_src" style="width: 50px;">
                                <asp:TextBox ID="txtUnit" runat="server" CssClass="validate[minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="14" Width="50px" MaxLength="3" Onkeypress="return char(event)"></asp:TextBox></div>
                            <div id="magnify_area">
                                <a href="#" shape="poly" onclick="OpenPopupUnit('LICENSE_MASTER'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname" style="width:350px; margin-left:35px">
                            <div id="tag_label_Clientname">
                                Remaining Qty
                            </div>
                            <div id="txtcon-m_src"  style="margin-left:18px">
                                <asp:TextBox ID="txt_Remaining_Qty" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                     MaxLength="12" ReadOnly="true" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox></div>
                        </div>
                        <div id="pop_text_area_Clientname" style="width:420px;margin-left:35px">
                            <div id="tag_label_Clientname">
                                Total FC Value
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;margin-left:18px">
                                <asp:TextBox ID="txt_FCValue" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="15" MaxLength="18"  onkeypress="return validateDecimalTwoPlaces(this, event);"></asp:TextBox></div>
                            <div id="tag_label_transaction_Src_longlabel" style="width: 35px; text-align: center">
                                Curr</div>
                            <div id="txtcon-m_src" style="width: 50px;">
                            <asp:TextBox ID="txt_LicenseCurrency" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" TabIndex="16" onkeypress="return char1(event)" onblur="return ChangeCase(this);" Width="50px"
                                    onkeyup="return ChangeCase(this);autotab(this);" MaxLength="3"></asp:TextBox>
                                </div>
                           <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('LicenseCurrency'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname" style="width:420px;margin-left:35px">
                            <div id="tag_label_Clientname">
                                Remaining FC
                            </div>
                            <div id="txtcon-m_src" style="width: 105px;margin-left:18px">
                                <asp:TextBox ID="txt_Remaining_FC" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                     MaxLength="12" ReadOnly="true"  onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox></div>
                             <div id="tag_label_transaction_Src_longlabel" style="width: 35px; text-align: center">
                                Ex.Rt</div>
                            <div id="txtcon-m_src" style="width: 40px;">
                                <asp:TextBox ID="txt_Exrate" runat="server" CssClass="validate[minSize[3]] txtbox_none_Mid_transac_item_maindet" MaxLength="14"
                                 onkeyup="extractNumber(this,4,false);"  onkeypress="return blockNonNumbers(this, event, true, false);"   TabIndex="17" Width="50px"></asp:TextBox></div>
                        </div>
                         <div id="pop_text_area_Clientname" >
                        <div id="tag_label_Clientname" style="width: 100px">
                            Bond No</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src" style="width: 130px; margin-left:17px">
                            <asp:TextBox ID="txtBondNo" runat="server" MaxLength="50" CssClass="txtbox_none"
                                Width="130px" TabIndex="18" onkeypress="return pin(event)" AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>

                     <div id="pop_text_area_Clientname">
                        <div id="tag_label_Clientname" style="width: 100px">
                            Bond Date</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src" style="width: 105px;  margin-left:17px"">
                            <asp:TextBox ID="txtBond_date" runat="server" CssClass="txtbox_none" Width="130px"
                                    Onkeypress="return numchar(event)" TabIndex="19" MaxLength="40"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtBond_date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtBond_date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                        </div>
                    </div>
                      <div id="pop_text_area_Clientname" >
                        <div id="tag_label_Clientname" style="width: 100px">
                            Bond Type
                        </div>
                        <div id="txtcon-m_transaction_list1_bondtype" style="margin-left:20px; width:130px">
                            <asp:DropDownList ID="ddlBondType" style="width:135px" runat="server" CssClass="txtbox_none"
                                TabIndex="20">
                            </asp:DropDownList>
                        </div>
                    </div>
                    </div>

                     <div id="innerbox_MidMain_Mid_ClientMaster" style="width:250px;margin-left:700px">
                        <div id="innerbox_MidMain_Mid_ClientMaster_l" style="width:200px;">
                         <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Lic.Broker Name
                            </div>
                            <div id="txtcon-m_src" style="margin-left:5px">
                                <asp:TextBox ID="txt_BrokerName" runat="server" CssClass="txtbox_none" Onkeypress="return numchar(event)"
                                    TabIndex="21" MaxLength="70"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>

                         <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Lic.Transfered TO
                            </div>
                            <div id="txtcon-m_src" style="margin-left:5px">
                                <asp:TextBox ID="txtTransferedTO" runat="server" CssClass="txtbox_none" TabIndex="22"
                                    Onkeypress="return numchar(event)" MaxLength="70"></asp:TextBox>
                            </div>
                        </div>

                         <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Lic.Received Date</div>
                            <div id="txtcon-m_src" style="margin-left:5px">
                                <asp:TextBox ID="txtReceived_Date" runat="server" CssClass="txtbox_none" TabIndex="23"
                                    Onkeypress="return numchar(event)" MaxLength="40"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtReceived_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtReceived_Date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                        </div>

                         <div id="pop_text_area_Clientname">
                        <div id="tag_label_Clientname" style="width: 130px">
                            License Expiry Date</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src" style="width: 105px; margin-left:-12px"">
                            <asp:TextBox ID="txtLic_Exp_date" runat="server" CssClass="txtbox_none" Width="130px"
                                    Onkeypress="return numchar(event)" TabIndex="24" MaxLength="40"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtLic_Exp_date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtLic_Exp_date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                        </div>
                    </div>

                     <div id="pop_text_area_Clientname">
                        <div id="tag_label_Clientname" style="width: 130px">
                            Date Of Surrender</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src" style="width: 105px;margin-left:-12px">
                            <asp:TextBox ID="txtsur_date" runat="server" CssClass="txtbox_none" Width="130px"
                                    Onkeypress="return numchar(event)" TabIndex="25" MaxLength="40"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txtsur_date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtsur_date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                        </div>
                       
                    </div>

                      <div id="pop_text_area_Clientname">
                            <div id="tag_label_Clientname" style="width: 130px">
                               Part No
                            </div>
                          
                            <div id="txtcon-m_transaction_list1_bondtype" style="margin-left:-10px; width:130px">
                                <asp:TextBox ID="txt_PartNo" runat="server" style="width:130px" CssClass="txtbox_none_Promas1" TabIndex="26"
                                    MaxLength="15"></asp:TextBox>
                            </div>
                        </div>

                         <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Bond Location
                        </div>
                        <div id="tag_label_adcode" style="margin-left:5px">
                            <asp:TextBox ID="txtBondLocation" runat="server" onkeyup="autotab(this);" CssClass="txtbox_none"
                             Width="130px"   MaxLength="50" TabIndex="27" ClientIDMode="Static"></asp:TextBox>
                        </div>    
                    </div>

                        </div>
                        </div>
                </div>
                   </div>
                </div>
            </div>
            <div id="innerbox_MidMain_top_adcode" style="margin-left:10px; margin-top:-10px">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="28" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick="return validate_License();"
                            TabIndex="29" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            OnClientClick="return validate_License();" TabIndex="30" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="31" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'IMPORT LICENSE MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click(); 
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="32" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSaveNew" Text="Save  & New" TabIndex="33" CssClass="autowidupdatebut"
                            OnClientClick="return validate();" runat="server" 
                            onclick="btnSaveNew_Click" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                            tabindex="34" id="btnCancel" />
                        <asp:HiddenField ID="hdn_Update_Adcode" runat="server" />
                        <asp:HiddenField ID="hdn_check_adcode" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                         <asp:HiddenField ID="HD_tbl_sort" runat="server" /> 
                         <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                    </div>
                </div>
            </div>

            <div id="innerbox_MidMain_Grid">
                   
                    <%--<div runat="server" id="div_pagination1" visible="false">
                    </div>--%>
                    <%--<div id="tag_srcinner1grid_table_Container">--%>
                        <div id="Main_Grid_Container" style="height:200px">
                            <asp:GridView runat="server" ID="gvdetails" DataKeyNames="LICENSE_ID" AutoGenerateColumns="False"
                                BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                                Width="100%" ShowHeader="true" ShowHeaderWhenEmpty="true" 
                                OnRowDataBound="gvdetails_RowDataBound" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged" AllowSorting="True" BorderColor="#C8C8C8"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1">
                                
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                     <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                                    <asp:BoundField DataField="REGISTRATION_NO" HeaderText="Reg.No.">
                                      <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REGISTRATION_DATE" HeaderText="Reg.date" SortExpression="REGISTRATION_DATE">
                                       <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_NO" HeaderText="License No" SortExpression="LICENSE_NO">
                                        <ItemStyle CssClass="hideGridColumn"/>
                                        <HeaderStyle CssClass="hideGridColumn"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_DATE" HeaderText="License Date" SortExpression="LICENSE_DATE" >
                                        <ItemStyle CssClass="hideGridColumn" />
                                        <HeaderStyle CssClass="hideGridColumn"/>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EXCEMPTION" HeaderText="Excmptn" SortExpression="EXCEMPTION">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_TYPE" HeaderText="Type" SortExpression="LICENSE_TYPE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="LICENSE_ITEM_NO" HeaderText="Lic ItemNo">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOTAL_DEBIT_AMT" HeaderText="Total Debit Amt">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="REMAINING_AMT" HeaderText="Remaining Amt">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="TOTAL_DEBIT_QTY" HeaderText="Total Debit Qty">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UNIT_QTY" HeaderText="Unit">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PARTY_NAME" HeaderText="Party Name">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="PORT_OF_LICENSE" HeaderText="PORT OF LICENSE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                      <asp:BoundField DataField="LICENSE_DESC">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SINGLE_DUTY_Y_N">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                     <asp:BoundField DataField="TOTAL_FC_VALUE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                      <asp:BoundField DataField="REMAINING_FC">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EX_RATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TOTAL_CIF_VALUE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                      <asp:BoundField DataField="REMAINING_CIF">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                     <asp:BoundField DataField="LICENSE_CURRENCY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                      <asp:BoundField DataField="LICENSE_BROKER_NAME">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                     <asp:BoundField DataField="LICENSE_TRANSFERED_TO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                     <asp:BoundField DataField="LICENSE_RECEIVED_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                  <%--  <asp:BoundField DataField="LICENSE_RECEIVED_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="BOND_NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                     <asp:BoundField DataField="BOND_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                     <asp:BoundField DataField="BOND_TYPE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DATE_OF_SURRENDER">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                     <asp:BoundField DataField="PART_NO">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LICENSE_EXPIRY_DATE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_LOCATION">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" /> 
                                    </asp:BoundField>

                                </Columns>
                                <PagerStyle CssClass="pager" />
                                    <EmptyDataTemplate>
                                        NO RECORD FOUND
                                    </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                   <%-- </div>--%>           
                </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Import_Jscript/Import_License.js" type="text/javascript"></script>
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

    </script>

    <script type="text/javascript">

        function OpenPopupCustom_House(val) {

            if (document.getElementById('hdfTransport_mode').value != '') {
                var s = document.getElementById('hdfTransport_mode').value;
                OpenPopupCustom_House_Details_Port(s, val);

                return false
            }
        }



        $(function () {
            $("#txtBondLocation").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List_NEW",
                        data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + '' + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtBondLocation').validationEngine('showPrompt', 'Incorrect Bond Location', 'error', 'topRight', true);

                                //jAlert('Bond Location is Incorrect', 'BOND', function (r) { document.getElementById("txtBondLocation").focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtBondLocation').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            //alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });
    </script>
</body>
</html>
