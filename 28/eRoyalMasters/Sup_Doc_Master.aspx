<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sup_Doc_Master.aspx.cs" Inherits="eRoyalMasters_Client_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Supporting Document Master</title>
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
    </style>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style type="text/css">
        fieldset
        {
         font-family: sans-serif;
         padding: 10px;
        }
     </style>

     
<script type="text/javascript">
    function dateselect(ev) {
        var calendarBehavior1 = $find("Calendar1");
        var d = calendarBehavior1._selectedDate;
        var now = new Date();
        calendarBehavior1.get_element().value = d.format("dd/MM/yyyy") + " " + now.format("HH:mm:ss")
    }
    function dateselect_Date(ev) {
        var calendarBehavior1 = $find("CalExpiry_Date");
        var d = calendarBehavior1._selectedDate;
        var now = new Date();
        calendarBehavior1.get_element().value = d.format("dd/MM/yyyy")
    }
   
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            if ($('#hdn_COMAPNYID').val() == '5' || $('#hdn_COMAPNYID').val() == '747') {
                Load_icegateID();
            }
        });

        function Load_icegateID() {
            var Notn = ['COECCSBD', 'GILBESBD', 'BOMCCSBD', 'DELCCSBD'];

            $('#txt_Icegate_id').autocomplete({
                source: Notn,
                minLength: 0,
                scroll: true
            }).focus(function () {
                $(this).autocomplete("search", "");
            });
        }

  </script>
</head>
<body style=" background-color:white; overflow: hidden;" onload="window.parent.parent.scrollTo(0,0);">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_ClientMaster" style="width:850px;">
                <div id="innerbox_MidMain_top_ClientMaster" style="width:845px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:180px" >
                        Supporting Documents
                    </div>
                     <div id="verslic" >
                    </div>
                   
                        <div id="tag_transac_lft_in2" >
                        <div id="tag_label_Clientname" style="width: 150px; font-size:12px;">
                           <asp:RadioButtonList ID="Rd_Imp_Exp" runat="server"  Font-Size="Small" 
                                RepeatDirection="Horizontal" TabIndex="1" AutoPostBack="True" 
                                onselectedindexchanged="Rd_Imp_Exp_SelectedIndexChanged" >
                            <asp:ListItem Text="Import" Value="I" Selected="True" ></asp:ListItem>
                            <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                     <div id="verslic" >
                     </div>
                    <div id="tag_transac_lft_in2">
                        <div id="tag_label_Clientname" style="width: 80px;margin-top:5px;">
                            Icegate ID
                        </div>
                        <div id="tag_label_Clientname" style="width: 200px;margin-top:5px;">
                             <asp:DropDownList ID="ddl_Icegate_Id" runat="server"  CssClass="txtbox_none" AutoPostBack="true" 
                                 onselectedindexchanged="ddl_Icegate_Id_SelectedIndexChanged" TabIndex="2" >
                             </asp:DropDownList>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right">
                     <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_ClientMaster" style="height:320px;width:845px;">
                    <div id="innerbox_MidMain_Mid_ClientMaster_l" style="height: 330px;width:420px;">
                        <div id="pop_text_area_Clientname" style="width:420px;">
                            <div id="tag_label_Clientname" style="width:170px;">
                                Icegate ID
                            </div>
                             <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    *</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Icegate_id" runat="server" MaxLength="25" 
                                CssClass="validate[required] txtbox_none" TabIndex="3" ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:170px;">
                                Image Ref. No.(IRN)
                            </div>
                             <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    *</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Img_Ref_No" runat="server" MaxLength="16" CssClass="validate[required] txtbox_none"
                                    ClientIDMode="Static" TabIndex="5" ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                          <%--  <div id="tag_label_Clientname" style="width:170px;">
                                Doc. Type
                            </div>
                             <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    *</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Doc_Type_Code" runat="server" MaxLength="50" TabIndex="8" CssClass="validate[required] txtbox_none"></asp:TextBox>
                            </div>--%>
                          <%--  <div id="pop_text_area_Clientname"  style="width:420px;">--%>
                            <div id="tag_label_Clientname" style="width:170px;">
                                Doc.Type.Code
                            </div>
                             <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    *</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Doc_Type_Code" runat="server" MaxLength="50" TabIndex="8" CssClass="validate[required] txtbox_none"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                           <%-- <div id="txtcon-r_src">
                            </div>--%>
                        
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:170px;">
                                Icegate File Name
                            </div>
                             <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    *</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Icegate_File_Name" runat="server" MaxLength="50" TabIndex="10" CssClass="validate[required] txtbox_none"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:170px;">
                                Doc. Name</div>
                                 <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    *</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Doc_Name" runat="server" MaxLength="35" CssClass="validate[required] txtbox_none" TabIndex="13" ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                       <%-- <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:170px;">
                                Reference No.</div>
                                 <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    *</div>
                            <div id="txtcon-m_src">
                               <asp:TextBox ID="txt_Ref_No" runat="server" MaxLength="35" CssClass="validate[required] txtbox_none" TabIndex="16" ></asp:TextBox>
                            </div>
                        </div>--%>
                        <div id="pop_text_area_Clientname" style="width: 420px;">
                            <div id="tag_label_Clientname" style="width: 170px;">
                                Reference No(DRN)</div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                                *</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Ref_No" runat="server" MaxLength="35" CssClass="validate[required] txtbox_none"
                                    TabIndex="16"></asp:TextBox>
                            </div>
                        </div>


                       <%-- <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;color:Blue;">
                                Issuing Party Details :-
                                </div>
                            <div id="txtcon-m_src">
                             
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>--%>
                        <div id="pop_text_area_Clientname" style="width: 420px;">
                            <div id="tag_label_Clientname" style="width: 180px; color: Blue;">
                                <asp:Label ID="Issu_ben_party" runat="server"></asp:Label>
                            </div>
                            <div id="txtcon-m_src">
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>

                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:170px;">
                                Name </div>
                                 <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    *</div>
                            <div id="txtcon-m_src" style="width:190px;" >
                               <asp:TextBox ID="txt_Iss_Name" runat="server" Width="190px" CssClass="validate[required] txtbox_none" TabIndex="20" ></asp:TextBox>
                            </div>

                             <div id="magnify_area">
                                <%--<a href="#"  class="magnfy" tabindex="21" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Issuing_Party_Details('Supporting_Doc_Details'); return false">
                                </a>--%>
                                  <a href="#"  class="magnfy" tabindex="21" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Beneficiary_Partyls(); return false">
                                </a>
                             </div>
                        </div>

                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Code </div>
                            <div id="txtcon-m_src">
                               <asp:TextBox ID="txt_Iss_Code" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="23"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Address Line.1</div>
                            <div id="txtcon-m_src">
                               <asp:TextBox ID="txt_Iss_Add_1" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="24" ></asp:TextBox>
                            </div>
                        </div>

                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Address Line.2</div>
                            <div id="txtcon-m_src">
                               <asp:TextBox ID="txt_Iss_Add_2" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="25" ></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                City </div>
                            <div id="txtcon-m_src">
                               <asp:TextBox ID="txt_Iss_City" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="26" ></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Pin Code </div>
                            <div id="txtcon-m_src">
                               <asp:TextBox ID="txt_Iss_Pin_Code" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="27" ></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height: 320px;width:420px;">
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                 Doc. Applicable for
                                 </div>
                            <div id="txtcon-m_src">
                                <asp:DropDownList ID="ddl_Job_Type" runat="server" CssClass="txtbox_none">
                                <asp:ListItem Text="Multiple Jobs" Value="MJ" TabIndex="4"  ></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Doc. Upload Date Time
                            </div>
                            <div id="txtcon-m_src">

                                <%-- <asp:TextBox ID="txt_Doc_Upload_Date" runat="server" Width="2px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="26"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Doc_Upload_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>--%>

                               <asp:TextBox ID="txt_Doc_Upload_Date" runat="server" Width="150px"  TabIndex="6" ></asp:TextBox>
                            <asp:ImageButton ID="imgPopup" ImageUrl="~/images/icons/calender.png" ImageAlign="Bottom"  runat="server" />
                               
                            <asp:CalendarExtender ID="Calendar1" PopupButtonID="imgPopup" BehaviorID="Calendar1"
                                runat="server" TargetControlID="txt_Doc_Upload_Date" OnClientDateSelectionChanged="dateselect">
                            </asp:CalendarExtender>

                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                     
                          <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Level
                            </div>
                            <div id="txtcon-m_src"  style="width:90px;">
                                <asp:DropDownList ID="ddl_SelectType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                Width="80px">
                                <asp:ListItem Value="JOB">Job</asp:ListItem>
                                <asp:ListItem Value="INVOICE">Invoice</asp:ListItem>
                                <asp:ListItem Value="ITEM">Item</asp:ListItem>
                            </asp:DropDownList>
                           </div>
                            <div id="tag_label_Clientname" style="width:60px;">
                                File Type
                            </div>
                            <div id="txtcon-m_src" style="width:70px;">
                                <asp:TextBox ID="txt_File_Type" runat="server" MaxLength="20" TabIndex="9" CssClass="txtbox_none" Width="70px"></asp:TextBox>
                            </div>
                        </div>
                       
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:170px;">
                                Issued At
                            </div>
                             <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    *</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Issued_At" runat="server" MaxLength="50" TabIndex="12" CssClass="validate[required] txtbox_none"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:170px;">
                                Issued On</div>
                                 <div id="tag_label_transaction_popup_IGM2_empty" style="color:Red; width:10px;">
                    *</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Issued_On" runat="server" Width="82px" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code" TabIndex="15"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Issued_On"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Issued_On"  Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Expiry Date</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Expiry_Date" runat="server" Width="82px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code" TabIndex="16"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Expiry_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Expiry_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        
                       <%-- <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px; color:Blue;">
                               Beneficiary Party Details :-
                                </div>
                            <div id="txtcon-m_src">
                               
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>--%>
                        <div id="pop_text_area_Clientname" style="width: 420px;">
                            <div id="tag_label_Clientname" style="width: 180px; color: Blue;">
                                <asp:Label ID="Ben_issu_party" runat="server"></asp:Label>
                            </div>
                            <div id="txtcon-m_src">
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>

                     <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Name </div>
                            <div id="txtcon-m_src" style="width:190px;">
                                <asp:TextBox ID="txt_Ben_Name" runat="server" Width="190px"  TabIndex="30" CssClass="validate[required] txtbox_none" ></asp:TextBox>
                            </div>
                             <div id="magnify_area">
                               <%--<a href="#"  class="magnfy" TabIndex="31" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Beneficiary_Partyls(); return false">
                                </a>--%>
                                    <a href="#"  class="magnfy" tabindex="31" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Issuing_Party_Details('Supporting_Doc_Details'); return false">
                                </a>
                             </div>
                        </div>
                         <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Code </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Ben_Code" runat="server" MaxLength="20" TabIndex="32" CssClass="txtbox_none" ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                         <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Address Line 1 </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Ben_Add_1" runat="server" MaxLength="20" TabIndex="33" CssClass="txtbox_none" ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                         <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                 Address Line 2 </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Ben_Add_2" runat="server" MaxLength="20" TabIndex="34" CssClass="txtbox_none"  ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                City </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Ben_City" runat="server" MaxLength="20" TabIndex="35" CssClass="txtbox_none" ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area_Clientname"  style="width:420px;">
                            <div id="tag_label_Clientname" style="width:180px;">
                                Pin Code </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_Ben_Pin_Code" runat="server" MaxLength="20" TabIndex="36" CssClass="txtbox_none" ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                    
                </div>
                <div id="innerbox_MidMain_top_ClientMaster">
                    <div id="innerbox_ClientMaster_bot_inn" style="width:460px;">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                TabIndex="41" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate_Client();"
                                TabIndex="38" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate_Client();" TabIndex="40" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="42" OnClientClick="jConfirm('Delete this Entry?', 'CLIENT MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" CssClass="dlete" />
                            <asp:Button ID="btn" runat="server" TabIndex="42" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;" id="btnCancel" />
                            <asp:HiddenField ID="HDupdate_id" runat="server" />
                        </div>
                       
                    </div>
                    <div id="tag_label_transact_Src" style="width: 110px; font-weight:bold; color:Blue;">
                                Auto Save to Job</div>
                                <div id="tag_label_transact_Src" style="width: 65px;">
                                <asp:CheckBox ID="chk_autosave" runat="server" />
                                </div>
                </div>
            </div>
            </div> </div>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:HiddenField ID="hdn_COMAPNYID" runat="server" />
    </form>
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
  
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }

        $(function () {
            $("#txtStateName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_Name_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                jQuery('#txtStateName').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);
                            }
                            else {
                                var value = data.d;
                                if (value.indexOf("-") != -1) {
                                    var arr = value.split('-');
                                    alert(value);
                                    jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                }
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
        
            function KeepSessionAlive(val) {
                $.post("../KeepSessionAlive.aspx?ses_id=" + val + "", null, function () {

                });
            }
           
            function CallServerside_IECNO(src, dest) {
                var ctrl = document.getElementById(src);
                PageMethods.Get_IECNO_Details(ctrl.value, CallSuccess_IECNO, CallFailed, dest);
            }

            function CallSuccess_IECNO(res, destCtrl) {
                var dest = document.getElementById(destCtrl);
                var data = res;
                if (data.indexOf("~~") != -1) {

                    var s = data.split('~~');
                    var before = s[0];
                    var after1 = s[1];
                    var after2 = s[2];

                    if (before == '1') {
                        
                        var ddlType = document.getElementById("ddlType");
                        addOption(document.getElementById("ddlType"), after2, after2);                      
                        var txtName = $('#txtName');
                        txtName.attr('disabled', true);
                        jAlert('IE Code is already exists!', 'GENERAL', function (r) { document.getElementById("txtBranchNO").focus(); });
                        
                        document.getElementById("txtName").value = after1;

                                              
                    }
                    if (before == '2') {
                        
                        document.getElementById("txtName").value = '';
                        var txtName1 = $('#txtName');
                        txtName1.attr('disabled', false);
                    }
                }
                else {

                    document.getElementById("txtName").value = "";
                    document.getElementById("type").value = "";
                }
                document.getElementById("txtBranchNO").focus();
            }
            function CallServerside_ClientName(src, dest) {
                var ctrl = document.getElementById(src);
                // call server side method
                PageMethods.Get_ClientName_Details(ctrl.value, CallSuccess_ClientName, CallFailed, dest);
            }
            function CallSuccess_ClientName(res, destCtrl) {

                var dest = document.getElementById(destCtrl);
                //dest.value = res;
                var data = res;
                if (data.indexOf("~~") != -1) {

                    var s = data.split('~~');
                    var before = s[0];
                    var after1 = s[1];
                    var after2 = s[2];

                    if (before == '1') {
                        document.getElementById("ddlType").value = after2;

                        var ddlType = document.getElementById("ddlType");
                        addOption(document.getElementById("ddlType"), after2, after2);

                        var txtName = $('#txtName');

                        
                        jAlert('Party Already Exists!', 'GENERAL', function (r) { document.getElementById("txtName").focus(); });

                       // document.getElementById("txtName").value = after1;


                    }
                    if (before == '2') {
                        document.getElementById("txtName").value = '';

                       
                        document.getElementById("txtName").focus();
                    }
                }
                else {

                    document.getElementById("txtName").value = "";
                    document.getElementById("type").value = "";
                    
                }

                document.getElementById("txtName").focus();

            }
            function CallServerside_Branch(src, dest) {
                var ctrl = document.getElementById(src);
                var ctrl1 = document.getElementById('txtIECNO');
                var ctrl2 = document.getElementById('txtName');

                // call server side method

                PageMethods.Get_Branch_Details(ctrl1.value, ctrl2.value, ctrl.value, CallSuccess_Branch, CallFailed, dest);

            }
            function CallSuccess_Branch(res, destCtrl) {

                var dest = document.getElementById(destCtrl);
               
                var data = res;
                if (data.indexOf("~~") != -1) {


                    var s = data.split('~~');

                    var before = s[0];
                    var after1 = s[1];
                    if (after1 == 'UPDATE') {

                        document.getElementById("txtBranchNO").focus();
                    }
                    if (before == '1') {

                        jAlert('Branch Already Exists!', 'GENERAL', function (r) { document.getElementById("txtBranchNO").focus(); });

                    }
                   else {
                        document.getElementById("txtName").focus();

                    }
                }  
            }
            function CallFailed(res, destCtrl) {
                //alert(res.get_message());
            }

            function addOption(selectbox, text, value) {
                
                selectbox.options.length = 0;
                var optn = document.createElement("OPTION");
                if (text == 'OTHERS' && value == 'OTHERS') {
                   
                    optn.text = text;
                    optn.value = value;
                    selectbox.options.add(optn);
                    selectbox.options.add(new Option("GOVERNMENT", "GOVERNMENT"));
                  
                }
                else if (text == 'GOVERNMENT' && value == 'GOVERNMENT') {
                    
                    optn.text = text;
                    optn.value = value;
                    selectbox.options.add(optn);
                    selectbox.options.add(new Option("OTHERS", "OTHERS"));
                   
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
                        document.getElementById('ddl_SelectType').value = type;
                    }
                    else if (code == "False") {

                        document.getElementById('txt_Doc_Type_Code').style.border = "1px solid Red";
                    }
                }
                else {
                    document.getElementById('txt_Doc_Type_Code').style.border = "1px solid Red";
                }
            }

            //-------------------------------------------------------------------------------------------------------------------------
            function CallFailed(res, destCtrl) {

            }


    </script>


         <script type="text/javascript">
             $(document).ready(function () {
                 $('#txtStateName').focus(function () {

                     var data = $(this).val();
                     Item_desc(data);

                 });
                 $('#txtStateName').change(function () {

                     var data = $(this).val();
                     Item_desc(data);

                 });
                 $('#txtStateName').keyup(function () {

                     var data = $(this).val();
                     Item_desc(data);

                 });
                 $('#txtStateName').keydown(function () {

                     var data = $(this).val();
                     Item_desc(data);

                 });
             });

             function Item_desc(val) {

                 var data = val;
                
                 if (data == '') {
                     $('#txtStateName').val('');
                 }
                 if (data.indexOf("-") != -1) {

                     var s = data.split('-');

                     var before = s[0];
                     var after = s[1];

                     $('#txtStateName').val(before);
                     $('#hdn_Txt_Statecode').val(after);
                 }
                 else {

                 }
             }
  </script>

  <script type="text/javascript">
      $(document).ready(function () {

          if ($("#ddlCommercial_Tax_yn option:selected").text() == 'Y') {

              $("#txtCommercial_StateName").removeAttr("disabled");
              $("#txtCommercial_StateCode").removeAttr("disabled");
              $("#txtCommercial_Taxtype").removeAttr("disabled");
              $("#txtCommercial_RegistrationNo").removeAttr("disabled");

              document.getElementById('ST_Code').style.visibility = 'visible';
          }

          if ($("#ddlCommercial_Tax_yn option:selected").text() == 'N') {

              $("#txtCommercial_StateName").val('');
              $("#txtCommercial_StateCode").val('');
              $("#txtCommercial_Taxtype").val('');
              $("#txtCommercial_RegistrationNo").val('');

              $("#txtCommercial_StateName").attr("disabled", "disabled");
              $("#txtCommercial_StateCode").attr("disabled", "disabled");
              $("#txtCommercial_Taxtype").attr("disabled", "disabled");
              $("#txtCommercial_RegistrationNo").attr("disabled", "disabled");

              document.getElementById('ST_Code').style.visibility = 'hidden'; 

          }

          $('#ddlCommercial_Tax_yn').change(function () {

              if ($("#ddlCommercial_Tax_yn option:selected").text() == 'Y') {

                  $("#txtCommercial_StateName").removeAttr("disabled");
                  $("#txtCommercial_StateCode").removeAttr("disabled");
                  $("#txtCommercial_Taxtype").removeAttr("disabled");
                  $("#txtCommercial_RegistrationNo").removeAttr("disabled");

                  document.getElementById('ST_Code').style.visibility = 'visible';
              }
              else {
                  
                  $("#txtCommercial_StateName").val('');
                  $("#txtCommercial_StateCode").val('');
                  $("#txtCommercial_Taxtype").val('');
                  $("#txtCommercial_RegistrationNo").val('');

                  $("#txtCommercial_StateName").attr("disabled", "disabled");
                  $("#txtCommercial_StateCode").attr("disabled", "disabled");
                  $("#txtCommercial_Taxtype").attr("disabled", "disabled");
                  $("#txtCommercial_RegistrationNo").attr("disabled", "disabled");

                  document.getElementById('ST_Code').style.visibility = 'hidden'; 
              }

          });
      });
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
<script type="text/javascript" src="../js/eRoyalmaster_Jscript/Client_Master.js"></script>

</body>
</html>
