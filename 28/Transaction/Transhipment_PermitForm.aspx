<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Transhipment_PermitForm.aspx.cs"
    Inherits="Transhipment_PermitForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Transhipment Permit</title>
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

    <style >
 .print_btn{
	background:url('../images/print_Butt.png') no-repeat;
	width:101px;
	height: 30px;
	text-indent:-9999px;
	overflow:hidden;
	text-transform:uppercase;
	border:none;
	cursor:pointer;
 }
.print_btn:hover{
	background-position:left bottom;
}
 </style>
  
 <style>
 	 .directmanual_btn{
	background:url('../images/manuprint_Butt.png') no-repeat;
	width:119px;
	height: 30px;
	text-indent:-9999px;
	overflow:hidden;
	text-transform:uppercase;
	border:none;
	cursor:pointer;
}
 </style>

  <style>
 	 .directprint_btn{
	background:url('../images/directprint_Butt .png') no-repeat;
	width:120px;
	height: 30px;
	text-indent:-9999px;
	overflow:hidden;
	text-transform:uppercase;
	border:none;
	cursor:pointer;
}
 </style>

   <script type="text/javascript">
       function Check_BtnClick() {
//           alert('hi');
            var aa = document.getElementsByID("btn_manualprint");
//            document.getElementById("demo").innerHTML = aa;
//            alert(aa);
        }
    </script>

    <script type="text/javascript">

        $("btn_directprint").click(function () {

            var aa = 'btn_directprint';
            alert(aa); // or alert($(this).attr('id'));
        });
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
            <div id="innerbox_MidMain_Transact_popup_new" style="height: 85px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                       Transhipment Permit
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
                                OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>

                        <div id="tag_label_transaction_popup_gen_export">
                          
                        </div>

                         <asp:Button ID="btn_manualprint" runat="server" Text="Button"
                CssClass="directmanual_btn"  OnClientClick="open_jobno();" 
                />

                <%-- <asp:Button ID="btn_directprint" runat="server" Text="Button"  
                CssClass="directprint_btn"  OnClientClick="open_jobno2();"  
                />--%>

                 <asp:Button ID="btn_directprint" runat="server" Text="Button"  
                CssClass="directprint_btn"  OnClientClick="open_jobno2();" 
                />

                  <asp:Button ID="btn_excel" runat="server" Text="Excel"  OnClientClick="Excel_Print_open();" />

                 <%-- <asp:Button ID="btn_directprint" runat="server" Text="Button"  
                CssClass="directprint_btn" onclick="btn_directprint_Click"
                />--%>
                      
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new" style="background-image: none; height: 470px;">
                <div class="content" id="page-1" style="height: 460px; width: 960px;">

                    <div id="pop_text_area_transac_popup_inn_container_export1" style="height: 430px;"
                        runat="server">
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                 Importer
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtExporter" runat="server" MaxLength="35"  onblur="ChangeCase(this);" ClientIDMode="Static" Onkeypress="return numcharspl1(event)"
                                    TabIndex="2" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                               Commissioner Of Customs
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtCommissioner_Customs" runat="server" MaxLength="35" ClientIDMode="Static" TabIndex="17"
                                    CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtEx_Address1" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="3" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            Transhipped from
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_TranshipFrom" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="18" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtEx_Address2" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="4" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            TP BOND No & Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_BOOND_No" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="19" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox> </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="txtcon-m_transaction_code">
                                    <%--<asp:TextBox ID="txt_BOOND_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox>--%>
                                    
                                     <asp:TextBox ID="txt_BOOND_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="30" TabIndex="20"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender1"
                                        runat="server" TargetControlID="txt_BOOND_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_BOOND_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <%--<asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_BOOND_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                                    
                                    
                                    
                                    </div>
                           
                        </div>

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtEx_Address3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="5"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            Vessel/Flight No & Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtVessel_Flight_No" runat="server" ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                    MaxLength="35" TabIndex="21"></asp:TextBox>
                            </div>
                              <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="txtcon-m_transaction_code">
                                    <%--<asp:TextBox ID="txtVessel_Flight_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox>--%>
                                    
                                    <asp:TextBox ID="txtVessel_Flight_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="30" TabIndex="22"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender2"
                                        runat="server" TargetControlID="txtVessel_Flight_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtVessel_Flight_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                    </div>
                        </div>

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtEx_Address4" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="6"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                           IGM No & Date
                            </div>
                              <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_IGM_No" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="23" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox> </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="txtcon-m_transaction_code">
                                    <%--<asp:TextBox ID="txt_IGM_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox>--%>
                                    
                                     <asp:TextBox ID="txt_IGM_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="30" TabIndex="24"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender3"
                                        runat="server" TargetControlID="txt_IGM_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_IGM_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                    
                                    </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtEx_Address5" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="7"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                          Invoice No & Date
                            </div>
                               <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_InvoiceNo" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="25" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox> </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="txtcon-m_transaction_code">
                                    <%--<asp:TextBox ID="txt_InvoiceDate" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox>--%>
                                    
                                     <asp:TextBox ID="txt_InvoiceDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="30" TabIndex="26"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender4"
                                        runat="server" TargetControlID="txt_InvoiceDate" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_InvoiceDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                    
                                    </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Consignee
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="8"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                <asp:Label ID="lblRotation" runat="server" Text="MAWB NO & Date"></asp:Label>
                            </div>
                             <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_MAWBNo" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="27" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox> </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="txtcon-m_transaction_code">
                                    <%--<asp:TextBox ID="txt_MAWB_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox>--%>
                                    
                                     <asp:TextBox ID="txt_MAWB_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="30" TabIndex="28"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender5"
                                        runat="server" TargetControlID="txt_MAWB_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_MAWB_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>

                                    </div>                          
                        </div>


                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add1" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                          HAWB No & Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_HAWB_No" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="29" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox> </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="txtcon-m_transaction_code">
                                    <%--<asp:TextBox ID="txt_HAWB_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox>--%>
                                    
                                    <asp:TextBox ID="txt_HAWB_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="30" TabIndex="30"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender6"
                                        runat="server" TargetControlID="txt_HAWB_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_HAWB_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                    
                                    </div>
                          
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="width: 110%; height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add2" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="10"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            Number & Kind of Packages
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_No_Of_Pkgs" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="31" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox> </div>

                                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_No_Of_Pkgs_Unit" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="32" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox></div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="11"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            <asp:Label ID="lbl_Place_Of_precarrier" runat="server" Text="Weight Or Quantity"></asp:Label>
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_Weight" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="33" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox> </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_Weight_Unit" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="34" CssClass=" txtbox_none_Mid_transac_code"></asp:TextBox></div>
                        </div>

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; ">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add4" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="12"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                           <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                           ExRate
                            </div>
                            <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txt_Exrate" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Width="90px"
                                    MaxLength="35" TabIndex="35"></asp:TextBox></div>
                               <div id="tag_label_transaction_Src_new">
                               Currency
                            </div>
                            <div id="txtcon_m_transaction_IGM_Wght_small">
                            <asp:TextBox ID="txt_Currency" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_IGM_wght_small" Width="50px"
                                    MaxLength="35" TabIndex="36"></asp:TextBox></div>
                            <%--<div id="magnify_area">
                            </div>--%>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add5" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            <asp:Label ID="lbl_Pre_CarriageBy" runat="server" Text="Invoice Value"></asp:Label>
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txtInvoiceValue" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="37" CssClass="txtbox_none_Mid"></asp:TextBox>
                            </div>
                        </div>

                    

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Port of loading
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtPort_Of_Loading" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="14"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                CIF Value
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_CIFValue" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid"
                                    MaxLength="35" TabIndex="38"></asp:TextBox>
                            </div>                            
                        </div>                      
                   <%-- </div>--%>

                    <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Port of Discharge
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_PortDischarge" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="15"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Landing Charges(1%)
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_LandingCharges" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid"
                                    MaxLength="35" TabIndex="39"></asp:TextBox>
                            </div>                            
                        </div>         


                     <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                               Item Description
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_ItemDescription" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen" TextMode="MultiLine"
                                    Height="50px" MaxLength="35" TabIndex="16"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Assesable Value
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_AssesableValue" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid"
                                    MaxLength="35" TabIndex="40"></asp:TextBox>
                            </div>                            
                        </div>   


                         <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                               
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <%--<asp:TextBox ID="TextBox20" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>--%>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Bond Value
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_BondValue" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid"
                                    MaxLength="35" TabIndex="41"></asp:TextBox>
                            </div>                            
                        </div>   
                        

                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                               
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                               <%-- <asp:TextBox ID="TextBox22" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>--%>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Duty Value
                            </div>
                            <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_DutyValue" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid"
                                    MaxLength="35" TabIndex="42"></asp:TextBox>
                            </div>                            
                       <%-- </div>   --%>
                        
                                           
                   <%-- </div>--%>


                    <!-- Buttons Place Here -->
                    <div id="innerbox_MidMain_bot_transact_invoice" style="margin-top: 5px;">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide');"
                                TabIndex="46" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate_Invoice();"
                                TabIndex="43" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                Visible="false" OnClientClick="return validate_Invoice();" TabIndex="44" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="45" CausesValidation="false"
                                Visible="false" UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Manual SB', function(r) {
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
                                TabIndex="38" CausesValidation="false" UseSubmitBehavior="false" />
                            <%--<input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()"
                            tabindex="38" id="btnCancel" />--%></div>
                        <div id="editbu">
                            <%--<asp:Button ID="btn_next" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                CssClass="autowidmovebut" Text=">>" OnClientClick="jQuery('#form1').validationEngine('hide');btn_move_next();return false;" />--%>
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
                    <asp:HiddenField ID="HiddenField2" runat="server" ClientIDMode="Static" />
  
                    <asp:HiddenField ID="hdn_val" runat="server" />
                 
                </div>
            </div>
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

                    var Type = 'Manual';

                    NewWindow1('../Report/TransShip_Permit_Rpt_viewer.aspx?jobno=' + f + '&Transship=' + Type + '', 'List', '870', '1024', 'yes');

                    //opennew_Import_report(f);
                    return false
                    //alert(f);
                }
            }

        }

        function open_jobno2() {

            if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                document.getElementById("<%=HiddenField2.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                if (document.getElementById("<%=HiddenField2.ClientID %>").value != '') {

                    var f = document.getElementById("<%=HiddenField2.ClientID %>").value;

                    var Type = 'Direct';
                    NewWindow1('../Report/TransShip_Permit_Rpt_viewer.aspx?jobno=' + f + '&Transship=' + Type + '', 'List', '870', '1024', 'yes');

                    //opennew_Import_report(f);
                    return false
                    //alert(f);
                }
            }

        }

        function Excel_Print_open() {

            var jobno = $('#<%= ddlJobNo.ClientID %>').val(); //  document.getElementById('ddlJobNo').value;
            var WorkingPeriod = document.getElementById("hdn_val").value;
            //                    alert(WorkingPeriod);
            win = window.open('../FlatFile/Open_FileDownload.aspx?TP2_Excel_report=Yes&JOB_NO=' + jobno + '', 'ndf');
            Loading_HideImage();

        }


    </script>
</body>
</html>
