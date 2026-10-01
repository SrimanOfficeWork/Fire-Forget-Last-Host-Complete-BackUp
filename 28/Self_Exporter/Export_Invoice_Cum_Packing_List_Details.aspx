<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Invoice_Cum_Packing_List_Details.aspx.cs"
    Inherits="Export_Invoice_Cum_Packing_List_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Invoice Cum Packing List</title>
    <%--I- GST Bill--%>
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
    <%-- Additional --%>
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <%-- Additional --%>
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
            document.getElementById('page-2').style.display = 'none';
            document.getElementById('page-3').style.display = 'none';
            document.getElementById('page-4').style.display = 'none';

            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'block';
            document.getElementById("page-8").style.display = 'none';
            document.getElementById("page-9").style.display = 'none';

            document.getElementById("Page_A").className = 'inactive';
            document.getElementById("Page_B").className = 'active';
            document.getElementById("Page_C").className = 'inactive';
            document.getElementById("Page_D").className = 'inactive';

            document.getElementById("txtfocus").focus();

        }
   </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id*=txtch_name]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Billing_Charge_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item,
                                    val: item
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id*=hfCustomerId]", $(e.target).closest("td")).val(i.item.val);
                },
                minLength: 1
            });

        });
    </script>
    <script type="text/javascript">
        function Char_Inv(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
                return false;
            return true;
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
            <div class="loading" align="center" id="Div1" style="display: none">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Billing" style="height: 95px; width: 1194px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 500px;">
                        <%--Self Exporter : Invoice Cum Packing List--%>
                        Invoice Cum Packing List : CHA with Job & Self Exporters without Job
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transaction_inner_new">
                    <div id="tag_Exchange_lft_in1_new1" style="margin-top: 10px;">
                        <div id="tag_label_transaction_Src_new" style="width: 45px;display:none;">
                            Job No
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 165px;">
                            <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1" TabIndex="5"
                                AutoPostBack="True" Visible="false" Height="20px">
                                <%-- OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged"  --%>
                            </asp:DropDownList>
                            <asp:Button ID="btnloadData" TabIndex="6" runat="server" Width="71px" Height="20px"
                                Visible="false" Text="Load Data" OnClick="btnloadData_Click" />
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width: 45px;">
                        </div>

                        <div id="tag_label_transaction_popup_gen_export">
                            Invoice No & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtInvoiceNo_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                TabIndex="7" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 85px">
                            <asp:TextBox ID="txtDate" runat="server" Width="82px" MaxLength="10" CssClass=" txtbox_none_Mid_transac_code"
                                TabIndex="8"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                Format="dd/MM/yyyy" Enabled="True">
                            </asp:CalendarExtender>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen2" style="width: 110px;">
                            Exporter's Ref.
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtExporters_Ref" runat="server" MaxLength="35" ClientIDMode="Static"
                                TabIndex="9" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <%-- <div id="txtcon-m_transaction_code">
                            <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClientClick="open_jobno(); return false" />
                        </div>--%>
                        <div id="txtcon-m_transaction_code">
                            <a href="#" class="generate" id="btn_Report" runat="server" style="display: block;"
                                onclick="open_jobno();return false;" visible="false"></a>
                        </div>
                    </div>
                    <%-- ------------------------%>
                    <div id="tag_Exchange_lft_in1_new1" style="margin-top: 10px;width: 1190px;">
                        <div id="tag_label_transaction_Src_new">
                        </div>
                        <div id="txtcon-m_transaction_code">
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width: 45px;">
                        </div>
                        <div id="tag_label_transaction_popup_gen_export">
                            Buyer Order No & Date
                        </div>
                        <div id="txt_trans_exp_drawback" style="width: 245px;">
                            <asp:TextBox ID="txtBuyerOrderNo_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                TabIndex="10" CssClass=" txtbox_trans_exp_drawback" Width="240px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen2" style="width: 110px;">
                            Other References
                        </div>
                        <div id="txt_trans_exp_drawback" style="width: 165px;">
                            <asp:TextBox ID="txtOther_References" runat="server" MaxLength="35" ClientIDMode="Static"
                                TabIndex="11" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                        </div>
                        <div id="tag_label_transact_Src" style="width: 80px;">                                            
                         Invoice Name
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 175px;">
                             <asp:TextBox ID="txtInvoiceName" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                  Width="175px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="12"></asp:TextBox>
                        </div>                          
                    </div>
                </div>
            </div>
            <%--</div>--%>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -28px; width: 1194px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 480px; width: 1194px; margin-left: -16px;
                    margin-top: -5px;">
                   
                    <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span>General </span></a></li>

                     <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                        id="Page_C" runat="server" visible="false" ><span>Other </span></a></li>

                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span>Charge details</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        <span> Gen -4 </span></a></li>

                        <span style="color:black;font-size:12px;"> &nbsp; 
                            <asp:Literal ID="lbl_Created_Modified" runat="server"></asp:Literal>
                         </span>
                </ol>
                    <%----------------------------General---------------------------------------------------%>
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 440px;
                            margin-top: -16px; margin-left: -18px; color: Red;">
                           
                            <div id="tag_transact_src_inner" style="width: 1100px; height: 120px">
                              
                                <div id="tag_Exchange_inner_lft" style="width: 1100px; height: 120px">
                                    <div id="tag_transact_lft_in1" style="width: 1100px">
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Exporter
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtexporterName" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="330px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="13" ClientIDMode="Static" onchange="Collect_exporterAddress();" > </asp:TextBox>
                                            </div>
                                            <div id="magnify_area">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('GST_Bill_Exp_name'); return false">
                                                </a>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Buyer(if other than consignee)
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtBuyerName" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="330px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="17" ClientIDMode="Static" onchange="Collect_BuyerAddress();"> </asp:TextBox>
                                            </div>
                                            <div id="magnify_area">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('GST_Bill_Exp_name'); return false">
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                    <%-----General-Row-1-End------%>
                                    <%-----General-Row-2-Start------%>
                                    <div id="tag_transact_lft_in1" style="width: 1100px">
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 350px;">
                                                <asp:TextBox ID="txtexporter_Add1" runat="server" MaxLength="500" onkeyup="autotab(this);"
                                                    Width="350px" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_Inv_No"
                                                    Height="85px" TabIndex="14"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtBuyer_Add1" runat="server" MaxLength="500" onkeyup="autotab(this);"
                                                    Width="350px" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_Inv_No"
                                                    Height="85px" TabIndex="18"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%-----General-Row-2-End------%>
                                    <%-----General-Row 2     End-----%>
                                    <%-----General-Row 3 Started-----%>
                                    <div id="tag_transact_lft_in1" style="height: 75px; width: 1100px;">
                                    </div>
                                    <%-----General-Row 3     End-----%>
                                    <%-----General-Row 4 Started-----%>
                                    <%-----General-Row-4-Start------%>
                                    <div id="tag_transact_lft_in1" style="width: 1100px">
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Consignee
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtconsigneename" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="330px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="15" ClientIDMode="Static" onchange="Collect_consigneeAddress();" > </asp:TextBox>
                                            </div>
                                            <div id="magnify_area">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('GST_Bill_Exp_name'); return false">
                                                </a>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Notify
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;"> <%--txtNotify--%>
                                                <asp:TextBox ID="txtImportername" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="330px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="19" ClientIDMode="Static" onchange="Collect_NotifyAddress();"> </asp:TextBox>
                                            </div>
                                            <div id="magnify_area">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('GST_Bill_Exp_name'); return false">
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                    <%-----General-Row-4-End------%>
                                    <%-----General-Row-5-Start------%>
                                    <div id="tag_transact_lft_in1" style="width: 1100px">
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 350px;">
                                                <asp:TextBox ID="txtConsignee_Add1" runat="server" MaxLength="500" onkeyup="autotab(this);"
                                                    Width="350px" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_Inv_No"
                                                    Height="85px" TabIndex="16"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtNotify_Add1" runat="server" MaxLength="500" onkeyup="autotab(this);"
                                                    Width="350px" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_Inv_No"
                                                    Height="85px" TabIndex="20"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%-----General-Row-5-End------%>
                                    <%-----General-Row 6 Started-----%>
                                    <div id="tag_transact_lft_in1" style="height: 75px; width: 1100px;">
                                    </div>
                                    <%-----General-Row 6     End-----%>
                                    <%-----General-Row 7 Started-----%>
                                    <div id="tag_transact_lft_in1" style="width: 1100px">
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Pre Carriage by
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtPre_Carriageby" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="350px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="21"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Place of receipt by pre-carrier
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtPlace_ReceiptBy_PreCarrier" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="350px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="22"> </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%-----General-Row 7     End-----%>
                                    <%-----General-Row 8 Started-----%>
                                    <div id="tag_transact_lft_in1" style="width: 1100px">
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Vessel/Flight No
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtVessel_Flight_No" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="350px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="23"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Port of loading
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtPort_Of_Loading" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="350px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="24"> </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%-----General-Row 8     End-----%>
                                    <%-----General-Row 9 Started-----%>
                                    <div id="tag_transact_lft_in1" style="width: 1100px">
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Port of Discharge
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtPort_Of_Discharge" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="350px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="25"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Final Destination
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtFinal_Destination" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="350px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="26"> </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%-----General-Row 9     End-----%>
                                    <%-----General-Row 10 Started-----%>
                                    <div id="tag_transact_lft_in1" style="width: 1100px">
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Country Of Origin Of Goods
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtCountry_Origin_Goods" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="350px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="27"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Country Final Destination
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 330px;">
                                                <asp:TextBox ID="txtCountry_Final_Destination" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                    Width="350px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="28"> </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <%-----General-Row 10     End-----%>
                                    <%-----General-Row 11 Started-----%>
                                    <div id="tag_transact_lft_in1" style="width: 1100px">
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 180px;">
                                                Terms Of Delivery and Payment
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 350px;">
                                                <asp:TextBox ID="txtTerms_Delivery_Payment" runat="server" MaxLength="500" onkeyup="autotab(this);"
                                                    Width="350px" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_Inv_No"
                                                    Height="85px" TabIndex="29"></asp:TextBox>
                                                <%--old height 85--%>
                                            </div>
                                        </div>
                                    </div>
                                    <%-----General-Row 11     End-----%>
                                </div>
                            </div>
                        </div>
                       
                    </div>
                   
                    <%----------------------------Other---------------------------------------------------%>
                    <div class="content" id="page-8" >
                        
                    </div>


                    <div class="content" id="page-7" style="display: none; height: 440px; width: 1194px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 440px;
                            margin-top: 0px; color: Red;">

                            <div id="tag_transact_lft_in1" style="width: 1100px; height:23px;">
                                <div id="txt_container_Transact_Main_l" style="width: 200px;height:20px;">
                                    <div id="tag_label_transact_Src" style="width: 60px;height:20px;">
                                        Currency
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 140px;height:20px;"> 
                                        <asp:TextBox ID="txtInvoiceCurrency" runat="server" ClientIDMode="Static" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code" 
                                        onkeypress="return char1(event)" onblur="return ChangeCase(this);" MaxLength="3" onchange="Collect_Exchange_Rate();"
                                        onkeyup="remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);autotab(this);"
                                              TabIndex="30" ></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 200px;height:20px;">
                                    <div id="tag_label_transact_Src" style="width: 60px;height:20px;">
                                        Cur. Value
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 140px;height:20px;">
                                        <asp:TextBox ID="txtExchangeRate" runat="server" ClientIDMode="Static" MaxLength="15" 
                                            onblur="extractNumber(this,2,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"                                            
                                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" Width="120px" 
                                            CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="31" onchange="INVPACK_CALCULATION(this);" 
                                            Style="text-align: right;"></asp:TextBox> 
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 230px;height:20px;">
                                    <div id="tag_label_transact_Src" style="width: 180px;height:20px;">
                                        <%--Common Commission %--%> Net wt Common Additional %
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 50px;height:20px;">
                                        <asp:TextBox ID="txtCommonCommissionPercent" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                            onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);INVPACK_CALCULATION(this);"
                                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            onchange="INVPACK_CALCULATION(this);" MaxLength="15" TabIndex="32" Width="130px"
                                            Style="text-align: right;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_transact_lft_in1" style="height: 15px; width: 1100px;">
                            </div>
               
                             <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 30px;
                            width: 1194px; margin-top: -10px; margin-left: -18px;" >
                            <asp:GridView ID="GV1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                                 Style="overflow: auto;" Visible="true"> 
                                <Columns>
                                    <asp:BoundField  HeaderText="Marks & Nos" HeaderStyle-Width="100px"> 
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField  HeaderText="NO & KIND OF PKGS" HeaderStyle-Width="150px"> 
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField  HeaderText="Description of Goods" HeaderStyle-Width="250px">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="250px" />
                                    </asp:BoundField>
                                    <asp:BoundField  HeaderText="Quantity" HeaderStyle-Width="400px">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="400px" />
                                    </asp:BoundField>
                                    <asp:BoundField  HeaderText="Rate" HeaderStyle-Width="80px"> 
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField  HeaderStyle-Width="80px" HeaderText="Total">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField  HeaderStyle-Width="120px" HeaderText="">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="120px" />
                                    </asp:BoundField>

                                </Columns>
                            </asp:GridView>
                        </div>                            
                             <div id="tag_transact_lft_in1" style="height: 4px; width: 1190px;">
                             </div>
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 25px;
                            width: 1194px; margin-top: -10px; margin-left: -18px;" >
                            <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                                Style="overflow: auto;" > 
                                <Columns>
                                        <asp:BoundField  HeaderText="" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="40px" >                                           
                                               <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="40px" />   
                                        </asp:BoundField>
                                        <asp:BoundField  HeaderText="SNo" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="30px" >                                           
                                               <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />   
                                        </asp:BoundField>
                                       <asp:BoundField HeaderText="PKGS" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                             <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />                                             
                                        </asp:BoundField>                                        
                                        <asp:BoundField  HeaderText="Unit" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px" >                                           
                                               <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />   
                                        </asp:BoundField>
                                       <asp:BoundField HeaderText="Description" HeaderStyle-Font-Bold="true" HeaderStyle-Width="350px">
                                             <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="350px" />                                             
                                        </asp:BoundField>                                        
                                        <asp:BoundField  HeaderText="Qty" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="40px" >                                           
                                               <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="40px" />   
                                        </asp:BoundField>
                                        <asp:BoundField  HeaderText="Unit" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="60px" >                                           
                                               <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />   
                                        </asp:BoundField>
                                      <asp:BoundField HeaderText="Box" HeaderStyle-Font-Bold="true" HeaderStyle-Width="60px">
                                             <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />                                             
                                        </asp:BoundField>                                        
                                        <asp:BoundField  HeaderText="Unit" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="40px" >                                           
                                               <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="40px" />   
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="NT.wt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                             <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="100px" />                                             
                                        </asp:BoundField>                                        
                                        <asp:BoundField  HeaderText="Spl. Additional" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="90px" >   <%--HeaderText="Spl. Com. %"--%>                                          
                                               <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="90px" />   
                                        </asp:BoundField>
                                       <asp:BoundField HeaderText="GR.wt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                             <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="100px" />                                             
                                        </asp:BoundField>
                                       <asp:BoundField HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" HeaderStyle-Font-Bold="true" HeaderStyle-Width="10px">
                                             <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="10px" />                                             
                                        </asp:BoundField>                                        
                                        <asp:BoundField  HeaderText="Rate Per KG" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="100px" >                                           
                                               <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="100px" />   
                                        </asp:BoundField>
                                        <asp:BoundField  HeaderText="CIF" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="80px" >                                           
                                               <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="80px" />   
                                        </asp:BoundField>
                                        <asp:BoundField  HeaderText="" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="120px" >                                           
                                               <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="120px" />   
                                        </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>                          
                       <div id="tag_transact_lft_in1" style="height: 5px; width: 1190px;">
                       </div>

                             <div id="tag_transac_lft_Item_maindet_Grid_area"    style="overflow:auto; height:205px; width:1194px;margin-top:-10px;margin-left:-18px; ">
                             <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" 
                                    BorderStyle="none" ShowFooter="True" 
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" onrowdeleting="gv_Chg_Details_RowDeleting" ShowHeader = "false" 
                                    style=" overflow-x: hidden;overflow-y: auto;" > 
                                    
                                    <RowStyle BorderWidth="0.1em" BorderColor="black" Height="8px" /> 
                               <Columns>

                                   <asp:TemplateField HeaderText="ch_inv" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                       <ItemTemplate>
                                           
                                        <asp:CheckBox ID="chk_inv" runat="server" HeaderText="ch_inv"   Width="20px"  Checked='<%#bool.Parse(Eval("INV_CHECK").ToString())%>' />
                                         
                                       </ItemTemplate>
                                         <ItemStyle Width="20px" />
                                   </asp:TemplateField>

                                   <asp:BoundField DataField="RowNumber" HeaderText="S.No" HeaderStyle-Font-Bold="true" ItemStyle-Width="20px" HeaderStyle-Width="20px" />
                                    <asp:TemplateField HeaderText="SNo" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtOrder_by"    CssClass="underlined" Text='<%# Bind("ORDERBY") %>' Height="20px" Width="20px" onkeypress="return pin(event)" runat="server" style="text-align:center"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="PKGS" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPkgs" CssClass="underlined" placeholder="" onblur="ChangeCase(this);INVPACK_CALCULATION(this);"
                                                    runat="server" Height="20px" Width="40px" Font-Size="12px" Text='<%# Bind("PKGS") %>'
                                                    onkeypress="return pin(event);INVPACK_CALCULATION(this);" onchange="INVPACK_CALCULATION(this);" Style="text-align: center"> </asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="40px" HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Unit" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddlPKGS_UNIT"  Text='<%# Bind("PKGS_UNIT") %>' MaxLength="20" runat="server"
                                               Width="49px" Height="22px" Font-Size="12px"  CssClass=" txtbox_trans_exp_drawback">
                                               <asp:ListItem>PKG</asp:ListItem>                                               
                                               <asp:ListItem></asp:ListItem>
                                            <%--   <asp:ListItem>USD</asp:ListItem>
                                               <asp:ListItem>EUR</asp:ListItem>
                                               <asp:ListItem>GBP</asp:ListItem>
                                               <asp:ListItem>AUD</asp:ListItem>                                               
                                               <asp:ListItem>JPY</asp:ListItem>
                                               <asp:ListItem>SGD</asp:ListItem>--%>
                                           </asp:DropDownList>
                                       </ItemTemplate>
                                         <ItemStyle Width="50px" />
                                   </asp:TemplateField>                                        

                                   <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtch_name"  CssClass="underlined"   Text='<%# Bind("CHARGE_NAME") %>' runat="server"   onblur="ChangeCase(this);"                                    
                                            Height="20px" Width="300px" Font-Size="12px"  ></asp:TextBox>
                                            <asp:HiddenField ID="hfCustomerId" runat="server" /> <%--onblur="Calculation(this)"--%>
                                       </ItemTemplate>
                                         <ItemStyle Width="300px" />
                                   </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Qty" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQty" CssClass="underlined" placeholder="" onblur="ChangeCase(this);INVPACK_CALCULATION(this);"
                                                    runat="server" Height="20px" Width="40px" Font-Size="12px" Text='<%# Bind("QTY") %>'
                                                    onkeypress="return pin(event);INVPACK_CALCULATION(this);" onchange="INVPACK_CALCULATION(this);" Style="text-align: center"> </asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="40px" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                     
                                    <asp:TemplateField HeaderText="Unit" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddlQty_Unit"  Text='<%# Bind("QTY_UNIT") %>' MaxLength="20" runat="server"
                                               Width="49px" Height="22px" Font-Size="12px"  CssClass=" txtbox_trans_exp_drawback">
                                               <asp:ListItem>KG</asp:ListItem>
                                               <asp:ListItem>NOS</asp:ListItem>
                                               <asp:ListItem></asp:ListItem>
                                           </asp:DropDownList>
                                       </ItemTemplate>
                                         <ItemStyle Width="50px" />
                                   </asp:TemplateField>

                                    <asp:TemplateField HeaderText="BOX" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtBox" CssClass="underlined" placeholder="" onblur="ChangeCase(this);INVPACK_CALCULATION(this);"
                                                    runat="server" Height="20px" Width="40px" Font-Size="12px" Text='<%# Bind("BOX") %>'
                                                    onkeypress="return pin(event);INVPACK_CALCULATION(this);" onchange="INVPACK_CALCULATION(this);" Style="text-align: center"> </asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="40px" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                     
                                    <asp:TemplateField HeaderText="Unit" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddlBox_Unit"  Text='<%# Bind("BOX_UNIT") %>' MaxLength="20" runat="server"
                                               Width="49px" Height="22px" Font-Size="12px"  CssClass=" txtbox_trans_exp_drawback">
                                               <asp:ListItem>BOX</asp:ListItem>
                                               <asp:ListItem>BAG</asp:ListItem>                                               
                                               <asp:ListItem>BUNCH</asp:ListItem>
                                               <asp:ListItem>TRAY</asp:ListItem>                                               
                                               <asp:ListItem>PALLET</asp:ListItem>
                                               <asp:ListItem></asp:ListItem>
                                           </asp:DropDownList>
                                       </ItemTemplate>
                                         <ItemStyle Width="50px" />
                                   </asp:TemplateField>



                                    <asp:TemplateField HeaderText="NT.wt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtNetwt" CssClass="underlined" Text='<%# Bind("NET_WT") %>' runat="server"  
                                           onblur="extractNumber(this,2,false);remove_zero_after_decimal_point(this.value,'txt_Ex_Rate');return Clear_Dot(this);INVPACK_CALCULATION(this);" 
                                         onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" autocomplete="off"   onchange="INVPACK_CALCULATION(this);"                                   
                                            Height="20px" Width="80px" Font-Size="12px" Font-Bold="true" style="text-align:right"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="80px" />
                                   </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Spl. Com. %" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtSpecialCommissionPercent" CssClass="underlined" Text='<%# Bind("SPL_PERCENTAGE") %>' runat="server"  
                                           onblur="extractNumber(this,2,false);remove_zero_after_decimal_point(this.value,'txt_Ex_Rate');return Clear_Dot(this);INVPACK_CALCULATION(this);" 
                                         onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);INVPACK_CALCULATION(this);" autocomplete="off" onchange="INVPACK_CALCULATION(this);"
                                            Height="20px" Width="80px" Font-Size="12px" style="text-align:right"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="80px" />
                                   </asp:TemplateField>

                                    <asp:TemplateField HeaderText="GR.wt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtGrwt" CssClass="underlined" Text='<%# Bind("GR_WT") %>' runat="server"  
                                           onblur="extractNumber(this,2,false);remove_zero_after_decimal_point(this.value,'txt_Ex_Rate');return Clear_Dot(this);INVPACK_CALCULATION(this);" 
                                         onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" autocomplete="off"    onchange="INVPACK_CALCULATION(this);"                                  
                                            Height="20px" Width="80px" Font-Size="12px" style="text-align:right"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="80px" />
                                   </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Rate Per KG" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtRate" class="validate[required,custom[number]] txtbox_none_Mid_transac_code" Text='<%# Bind("RATE") %>' runat="server"  
                                           onblur="extractNumber(this,3,false);INVPACK_CALCULATION(this);" 
                                         onkeyup="extractNumber(this,3,false);INVPACK_CALCULATION(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);INVPACK_CALCULATION(this);" autocomplete="off"   onchange="INVPACK_CALCULATION(this);"                                   
                                            Height="20px" Width="80px" Font-Size="12px" Font-Bold="true" style="text-align:right"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="80px" />
                                   </asp:TemplateField>

                                      <asp:TemplateField HeaderText="CIF" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtCIF" CssClass="underlined" Text='<%# Bind("CIF_AMOUNT") %>' runat="server"  
                                           onblur="extractNumber(this,2,false);remove_zero_after_decimal_point(this.value,'txt_Ex_Rate');return Clear_Dot(this);INVPACK_CALCULATION(this);" 
                                         onkeyup="extractNumber(this,2,false);return Clear_Dot(this);INVPACK_CALCULATION(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);INVPACK_CALCULATION(this);" autocomplete="off"  onchange="INVPACK_CALCULATION(this);"                                    
                                            Height="20px" Width="80px" Font-Size="12px" Font-Bold="true" style="text-align:right"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="80px" />
                                            <FooterStyle HorizontalAlign="right" />
                                            <FooterTemplate>
                                                <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New" />
                                            </FooterTemplate>
                                   </asp:TemplateField>   
                                                         
                                   <%---------------------------------%>


                                   <%--<asp:TemplateField HeaderText="I-Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="69px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtIGST_AMT" CssClass="underlined" Text='<%# Bind("IGST_AMT") %>'     BackColor="#C0C0C0"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="69px" Font-Size="12px"  runat="server"   style="text-align:right"  ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="69px" />

                                      <FooterStyle HorizontalAlign="left"  />
                                       <FooterTemplate>
                                           <asp:Button ID="ButtonAdd" runat="server" Text="Add Row" OnClick="ButtonAdd_Click" />
                                       </FooterTemplate>
                                     </asp:TemplateField>--%>

                                   <asp:CommandField ShowDeleteButton="True" DeleteText="Del  "  ControlStyle-Font-Size ="Small" ControlStyle-Font-Bold ="true"  />

                               </Columns>
                           </asp:GridView>
                             <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White" BorderStyle="None"
                                ForeColor="White" ></asp:TextBox>
                                 
                                  <p id="pTotal" style="color:Red; font-size:large;">
                            </div>







                            <div id="innerbox_MidMain_bot_transact" style="height: 20px; font-weight: normal;
                                margin-top: 20px; width: 1100px;">
                                <div id="tag_label_transaction_exp_jobb" style="width: 100px;">
                                    Total Pkgs
                                </div>
                                <div id="txt_trans_exp_drawback">
                                    <asp:TextBox ID="txtTotalPkgs" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                        Style="text-align: right;" onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"
                                        onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        MaxLength="15" TabIndex="54"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 100px;">
                                    Total Net wt
                                </div>
                                <div id="txt_trans_exp_drawback">
                                    <asp:TextBox ID="txtTotalNetwt" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                        Style="text-align: right;" onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"
                                        onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        MaxLength="15" TabIndex="55"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 100px;">
                                    Total Gross wt
                                </div>
                                <div id="txt_trans_exp_drawback">
                                    <asp:TextBox ID="txtTotalGrwt" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                        Style="text-align: right;" onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"
                                        onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        MaxLength="15" TabIndex="56"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 100px;">
                                    Total CIF
                                </div>
                                <div id="txt_trans_exp_drawback">
                                    <asp:TextBox ID="txtTotalCIF" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                        Style="text-align: right;" onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"
                                        onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        MaxLength="15" TabIndex="57"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transact_lft_in1" style="width: 1100px">
                                <div id="txt_container_Transact_Main_l" style="width: 565px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Words
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 430px;">
                                        <asp:TextBox ID="txtWords" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                            Width="430px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="58"> </asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        CIF
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtCIF_FOREIGN" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                            Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="91" Style="text-align: right;"> </asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 250px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Rs.
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtCIF_LOCAL" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                            Style="text-align: right;" Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="91"> </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_transact_lft_in1" style="width: 1100px">
                                <div id="txt_container_Transact_Main_l" style="width: 565px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Package Range
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 430px;">
                                        <asp:TextBox ID="txtPackage_Range" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                            Width="430px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="59"> </asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        FRT
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtFRT_FOREIGN" runat="server" MaxLength="200" Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="91" onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);INVPACK_CALCULATION(this);"
                                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);autotab(this);" onchange="INVPACK_CALCULATION(this);"
                                            Style="text-align: right;"> </asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 250px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Rs.
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtFRT_LOCAL" runat="server" MaxLength="200" onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);INVPACK_CALCULATION(this);"
                                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);autotab(this);" onchange="INVPACK_CALCULATION(this);"
                                            Style="text-align: right;" Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="91"> </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_transact_lft_in1" style="width: 1100px">
                                <div id="txt_container_Transact_Main_l" style="width: 565px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Remarks
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 430px;">
                                        <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                            Width="430px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="60"> </asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        INS
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtINS_FOREIGN" runat="server" MaxLength="200" onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);INVPACK_CALCULATION(this);"
                                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);autotab(this);" onchange="INVPACK_CALCULATION(this);"
                                            Style="text-align: right;" Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="91"> </asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 250px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Rs.
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtINS_LOCAL" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                            Style="text-align: right;" Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="91"> </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_transact_lft_in1" style="width: 1100px">
                                <div id="txt_container_Transact_Main_l" style="width: 565px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 430px;">
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        FOB
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtFOB_FOREIGN" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                            Style="text-align: right;" Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="91"> </asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 250px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Rs.
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtFOB_LOCAL" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                            Style="text-align: right;" Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="91"> </asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                       
                    </div>
                    <%-------------------------------------------------------------------------------%>
                </div>
                <%-- --------------------Test Start----------------------------%>
                <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                    <div id="innerbox_transac_bot_inn" style="width: 1050px">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="122" OnClick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="120" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="121" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="121" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Invoice?', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="123" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="123">
                        </div>
                        <div id="editbu" style="width: 10px;">
                        </div>
                        <div id="editbu" style="padding-top: 5px;">
                            <asp:Button ID="btnrpt" runat="server" TabIndex="125" Text="Get Bill" OnClientClick="return open_Export_Invoice_Cum_Packing_List_Rpt('B');" />
                            <%--OnClientClick="return Import_Billing_Job_Rpt('B');"--%>
                        </div>
                        <div id="editbu" style="padding-top: 10px;">
                            <span style="color: Green;">&nbsp;
                                <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                            </span>
                        </div>
                        <div id="editbu" style="width: 10px;">
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 380px;display:none;">
                            <asp:TextBox ID="txtIRN" runat="server" Style="text-align: left;" Width="380px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                Enabled="false" Font-Bold="True" ForeColor="Blue"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <%-- --------------------Test End----------------------------%>
            </div>
            <div class="content" id="page-2">
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                    page-2
                </div>
            </div>
            <div class="content" id="page-3">
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 350px;
                    width: 980px; overflow: hidden;">
                    page-3
                </div>
            </div>
            <div class="content" id="page-4">
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                    page-4
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HD_Showcon" runat="server" />
            <asp:HiddenField ID="HD_Bill_Jobno" runat="server" />
            <asp:HiddenField ID="Hdjobno" runat="server" />
            <asp:HiddenField ID="HDinv_date" runat="server" />
            <asp:HiddenField ID="hdimp" runat="server" />
            <asp:HiddenField ID="hd_Brslno" runat="server" />
            <asp:HiddenField ID="hd_hss_imp" runat="server" />
            <asp:HiddenField ID="hd_hss_br_sl_no" runat="server" />
            <asp:HiddenField ID="hd_ch_type" runat="server" />
            <asp:HiddenField ID="Hd_row_id" runat="server" />
            <asp:HiddenField ID="Hd_Tr_mode" runat="server" />
            <asp:HiddenField ID="Hd_Other_Branch_no" runat="server" />
            <asp:HiddenField ID="HdtxtInvoiceNo_id" runat="server" />
            <asp:HiddenField ID="Hd_Company_Id" runat="server" />

            <asp:HiddenField ID="hdexp" runat="server" />
            <asp:HiddenField ID="hdexp_Brslno" runat="server" />
            <asp:HiddenField ID="hdconsignee" runat="server" />
            <asp:HiddenField ID="hdconsignee_Brslno" runat="server" />


            <asp:HiddenField ID="hdBuyer" runat="server" />
            <asp:HiddenField ID="hdBuyer_Brslno" runat="server" />
            <asp:HiddenField ID="hdNotify" runat="server" />
            <asp:HiddenField ID="hdNotify_Brslno" runat="server" />

            <asp:HiddenField ID="hdtxtTotalPkgsUnit" runat="server" />

            <asp:HiddenField ID="hd_BILL_INV_NO" runat="server" />


            <div style="display: none;">
                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                <asp:HiddenField ID="hdn_Update_General" runat="server" />
                <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                <asp:HiddenField ID="hdn_invgrid_itemId" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_isvalue" runat="server" />
                <asp:HiddenField ID="hdn_val" runat="server" />
                <%--<asp:Button ID="btn_Add1" runat="server" Text="Add" OnClick="btn_Add_Click" CausesValidation="false"
                        UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');btn_move_next();"
                        Style="display: none;" />
                    <asp:Button ID="btn_Remove1" runat="server" Text="Add" OnClick="btn_Remove_Click"
                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');btn_move_next();"
                        Style="display: none;" />
                    <asp:Button ID="btnGridUpdate" runat="server" Text="Add" OnClick="btnGridUpdate_Click"
                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');btn_move_next();"
                        Style="display: none;" />--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        function Go_Refresh() {
            PageMethods.Inv_Refresh('Inv', OnSuccess);
        }
        function OnSuccess(response, userContext, methodName) {

            $('#txtInvoiceNo').val(response);
        }
    </script>
    
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>

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
        function close_button() {
            document.getElementById("General").click();
        }

    </script>
<%-------------------------------------------------------------------------------%>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#txtImportername').focus(function () {

                var data = $(this).val();
                Item_desc(data);
            });
            $('#txtImportername').change(function () {

                var data = $(this).val();
                Item_desc(data);
            });
            $('#txtImportername').keyup(function () {

                var data = $(this).val();
                Item_desc(data);
            });
            $('#txtImportername').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });

        function Item_desc(val) {

            var data = val;
            if (data == '') {
                $('#txtImportername').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txtImportername').val(after);

                $('#hdimp').val(after);
                $('#hd_Brslno').val(before);

            }
            else {

            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtimportername_Other').focus(function () {

                var data = $(this).val();
                Item_desc_other(data);

            });
            $('#txtimportername_Other').change(function () {

                var data = $(this).val();
                Item_desc_other(data);

            });
            $('#txtimportername_Other').keyup(function () {

                var data = $(this).val();
                Item_desc_other(data);

            });
            $('#txtimportername_Other').keydown(function () {

                var data = $(this).val();
                Item_desc_other(data);
            });
        });

        function Item_desc_other(val) {

            var data = val;
            if (data == '') {
                $('#txtimportername_Other').val('');
                $('#txt_branch_No').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txtimportername_Other').val(after);
                $('#Hd_Other_Branch_no').val(before);
                $('#txt_branch_No').val(before);
            }
            else {
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txt_IMP_notify_party_1').focus(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txt_IMP_notify_party_1').change(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txt_IMP_notify_party_1').keyup(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txt_IMP_notify_party_1').keydown(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
        });

        function Item_desc1(val) {

            var data1 = val;
            if (data1 == '') {
                $('#txt_IMP_notify_party_1').val('');
            }
            if (data1.indexOf("--") != -1) {

                var s = data1.split('--');

                var before = s[0];
                var after = s[1];

                $('#txt_IMP_notify_party_1').val(after);

                $('#hd_hss_imp').val(after);
                $('#hd_hss_br_sl_no').val(before);

            }
            else {

            }
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

<%------------- 03.05.2024   ------------------------%>
<%-- exporter start  --%>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#txtexporterName').focus(function () {

                var data = $(this).val();
                Item_desc_exporter(data);
            });
            $('#txtexporterName').change(function () {

                var data = $(this).val();
                Item_desc_exporter(data);
            });
            $('#txtexporterName').keyup(function () {

                var data = $(this).val();
                Item_desc_exporter(data);
            });
            $('#txtexporterName').keydown(function () {

                var data = $(this).val();
                Item_desc_exporter(data);

            });
        });

        function Item_desc_exporter(val) {

            var data = val;
            if (data == '') {
                $('#txtexporterName').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txtexporterName').val(after);

                $('#hdexp').val(after);
                $('#hdexp_Brslno').val(before);
                
            }
            else {

            }
        }
    </script>
    <script type="text/javascript">
        function Collect_exporterAddress() {
            var tname = document.getElementById("txtexporterName").value;
            var tjob = "";
            var tbranch = document.getElementById("hdexp_Brslno").value;
            //alert("Am in Collect_exporterAddress part");            
            //PageMethods.Get_Importer(tname, tjob, tbranch, Bind_exporterAddress); //3 PARAMETERS ONLY FOR Get_Importer, Last parameter is used to call the new method and the old pageMethod result will pass to this new method as input.            

            PageMethods.Get_Exporter(tname, tjob, tbranch, Bind_exporterAddress); //3 PARAMETERS ONLY FOR Get_Importer, Last parameter is used to call the new method and the old pageMethod result will pass to this new method as input.            
        }
        function Bind_exporterAddress(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data.indexOf("~~") != -1) {
                var s = data.split('~~');
                var after1 = s[0];
                var after2 = s[1];
                var after3 = s[2];
                //alert("Am in Bind_exporterAddress part");
                document.getElementById("txtexporter_Add1").value = after1;                
            }
            else {                
                document.getElementById("txtexporter_Add1").value = "";
                
            }
        }
    </script>
<%-- exporter end  --%>
<%-- consignee start  --%>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#txtconsigneename').focus(function () {

                var data = $(this).val();
                Item_desc_consignee(data);
            });
            $('#txtconsigneename').change(function () {

                var data = $(this).val();
                Item_desc_consignee(data);
            });
            $('#txtconsigneename').keyup(function () {

                var data = $(this).val();
                Item_desc_consignee(data);
            });
            $('#txtconsigneename').keydown(function () {

                var data = $(this).val();
                Item_desc_consignee(data);

            });
        });

        function Item_desc_consignee(val) {

            var data = val;
            if (data == '') {
                $('#txtconsigneename').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txtconsigneename').val(after);

                $('#hdconsignee').val(after);
                $('#hdconsignee_Brslno').val(before);

            }
            else {

            }
        }
    </script>
    <script type="text/javascript">             
    function Collect_consigneeAddress() {
        var tname = document.getElementById("txtconsigneename").value;
        var tjob = "";
        var tbranch = document.getElementById("hdconsignee_Brslno").value;
        //alert("Am in Collect_consigneeAddress part");        
        PageMethods.Get_ConsigneeName(tname, tjob, tbranch, Bind_consigneeAddress); //3 PARAMETERS ONLY FOR Get_Importer, Last parameter is used to call the new method and the old pageMethod result will pass to this new method as input.            
    }
    function Bind_consigneeAddress(res, destCtrl) {
        var dest = document.getElementById(destCtrl);
        var data = res;
        document.getElementById("txtConsignee_Add1").value = data;
        if (document.getElementById("txtBuyerName").value == "") {
            document.getElementById("txtBuyerName").value = "SAME AS CONSIGNEE"
        }
    }
    </script>
<%-- consignee end  --%>
<%-- Buyer start  --%>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#txtBuyerName').focus(function () {

                var data = $(this).val();
                Item_desc_Buyer(data);
            });
            $('#txtBuyerName').change(function () {

                var data = $(this).val();
                Item_desc_Buyer(data);
            });
            $('#txtBuyerName').keyup(function () {

                var data = $(this).val();
                Item_desc_Buyer(data);
            });
            $('#txtBuyerName').keydown(function () {

                var data = $(this).val();
                Item_desc_Buyer(data);

            });
        });

        function Item_desc_Buyer(val) {

            var data = val;
            if (data == '') {
                $('#txtBuyerName').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txtBuyerName').val(after);

                $('#hdBuyer').val(after);
                $('#hdBuyer_Brslno').val(before);

            }
            else {

            }
        }
    </script>
    <script type="text/javascript">
        function Collect_BuyerAddress() {
            var tname = document.getElementById("txtBuyerName").value;
            var tjob = "";
            var tbranch = document.getElementById("hdBuyer_Brslno").value;
            //alert("Am in Collect_BuyerAddress part");        
            PageMethods.Get_Buyer(tname, tjob, tbranch, Bind_BuyerAddress); //3 PARAMETERS ONLY FOR Get_Importer, Last parameter is used to call the new method and the old pageMethod result will pass to this new method as input.            
        }
        function Bind_BuyerAddress(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data.indexOf("~~") != -1) {
                var s = data.split('~~');
                var after1 = s[0];
                var after2 = s[1];
                var after3 = s[2];
                //alert("Am in Bind_BuyerAddress part");
                document.getElementById("txtBuyer_Add1").value = after1;
            }
            else {
                document.getElementById("txtBuyer_Add1").value = "";

            }
        }
    </script>
<%-- Buyer end  --%>
<%-- Notify start  --%>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#txtImportername').focus(function () {

                var data = $(this).val();
                Item_desc_Notify(data);
            });
            $('#txtImportername').change(function () {

                var data = $(this).val();
                Item_desc_Notify(data);
            });
            $('#txtImportername').keyup(function () {

                var data = $(this).val();
                Item_desc_Notify(data);
            });
            $('#txtImportername').keydown(function () {

                var data = $(this).val();
                Item_desc_Notify(data);

            });
        });

        function Item_desc_Notify(val) {

            var data = val;
            if (data == '') {
                $('#txtImportername').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txtImportername').val(after);

                $('#hdNotify').val(after);
                $('#hdNotify_Brslno').val(before);

            }
            else {

            }
        }
    </script>
    <script type="text/javascript">
        function Collect_NotifyAddress() {
            var tname = document.getElementById("txtImportername").value;
            var tjob = "";
            var tbranch = document.getElementById("hdNotify_Brslno").value;
            //alert("Am in Collect_NotifyAddress part");        
            PageMethods.Get_Importer(tname, tjob, tbranch, Bind_NotifyAddress); //3 PARAMETERS ONLY FOR Get_Importer, Last parameter is used to call the new method and the old pageMethod result will pass to this new method as input.            
        }
        function Bind_NotifyAddress(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data.indexOf("~~") != -1) {
                var s = data.split('~~');
                var after1 = s[0];
                var after2 = s[1];
                var after3 = s[2];
                //alert("Am in Bind_NotifyAddress part");
                document.getElementById("txtNotify_Add1").value = after1;
            }
            else {
                document.getElementById("txtNotify_Add1").value = "";

            }
        }
    </script>
<%-- Notify end  --%>
<script type="text/javascript">
    function Collect_Exchange_Rate() {
        var TCur = document.getElementById("<%= txtInvoiceCurrency.ClientID%>").value;
        var TW = "";
        var TTemp = "";
        PageMethods.txtInvoiceCurrency_TextChanged(TCur, TW, TTemp, bind_exrate);
        
    }
    function bind_exrate(res, destCtrl) {        
        var data = res;
        document.getElementById("txtExchangeRate").value = data;
        document.getElementById("txtExchangeRate").value = parseFloat(document.getElementById("txtExchangeRate").value).toFixed(2);
        
    }
</script>

<%-- INVPACK_CALCULATION Start ON 08/05/2024 --%>   

<script type="text/javascript">
    function INVPACK_CALCULATION(lnk) {
        //alert('1');
        var TCur = "", TCurVal = "", TCommonPer = "", TTotalCIF = "";

        TCur = document.getElementById("<%= txtInvoiceCurrency.ClientID%>").value;
        TCurVal = document.getElementById("<%= txtExchangeRate.ClientID%>").value;
        TCommonPer = document.getElementById("<%= txtCommonCommissionPercent.ClientID%>").value;

        if (TCur == "") { alert('Please enter Currency'); document.getElementById("<%= txtInvoiceCurrency.ClientID%>").focus(); return; }
        if (TCurVal == "") { alert('Please enter Currency Value'); document.getElementById("<%= txtExchangeRate.ClientID%>").focus(); return; }
        //if (TCommonPer == "") { alert('Please enter Common Percentage'); document.getElementById("<%= txtCommonCommissionPercent.ClientID%>").focus(); return; }
        if (TCommonPer == "") { document.getElementById("<%= txtCommonCommissionPercent.ClientID%>").focus(); return; }


        //alert('2');
        document.getElementById("<%= txtTotalPkgs.ClientID%>").value = 0.00;
        document.getElementById("<%= txtTotalPkgs.ClientID%>").value = parseFloat((document.getElementById("<%= txtTotalPkgs.ClientID%>").value)).toFixed(2);
        document.getElementById("<%= txtTotalNetwt.ClientID%>").value = 0.00;
        document.getElementById("<%= txtTotalNetwt.ClientID%>").value = parseFloat((document.getElementById("<%= txtTotalNetwt.ClientID%>").value)).toFixed(2);
        document.getElementById("<%= txtTotalGrwt.ClientID%>").value = 0.00;
        document.getElementById("<%= txtTotalGrwt.ClientID%>").value = parseFloat((document.getElementById("<%= txtTotalGrwt.ClientID%>").value)).toFixed(2);
        document.getElementById("<%= txtTotalCIF.ClientID%>").value = 0.00;        
        document.getElementById("<%= txtTotalCIF.ClientID%>").value = parseFloat((document.getElementById("<%= txtTotalCIF.ClientID%>").value)).toFixed(2);
        //alert('Checking 3');

        var RPkgs = 0.00, RQty = 0.00, RBox = 0.00, RNetwt = 0.00, RSpl = 0.00, RAdditional = 0.00, RGrwt = 0.00, RRate = 0.000, RCIF = 0.00 ;
        var SumRPkgs = 0.00, SumRNetwt = 0.00, SumRGrwt = 0.00, SumRCIF = 0.00 ;
        var chk_inv = "";           
        var grid = document.getElementById("<%= gv_Chg_Details.ClientID%>");
        var gridTotalRows = grid.rows.length - 1;
        var txtPackage_Range="";

        for (var i = 0; i <= gridTotalRows - 1; i++) {            
                
                RPkgs = $("#gv_Chg_Details input[name*='txtPkgs']")[i].value;
                RQty = $("#gv_Chg_Details input[name*='txtQty']")[i].value;
                RBox = $("#gv_Chg_Details input[name*='txtBox']")[i].value;
                RNetwt = parseFloat(RQty) * parseFloat(RBox);
                $("#gv_Chg_Details input[name*='txtNetwt']")[i].value = RNetwt.toFixed(2);

                RSpl = $("#gv_Chg_Details input[name*='txtSpecialCommissionPercent']")[i].value; 
                if (RSpl != "") { RAdditional = parseFloat(RSpl); }
                else {
                    RAdditional = (parseFloat(RNetwt) * parseFloat(TCommonPer)) / 100;
                }
                RAdditional = RAdditional.toFixed(2);                                
                RGrwt = parseFloat(RNetwt) + parseFloat(RAdditional);
                $("#gv_Chg_Details input[name*='txtGrwt']")[i].value = RGrwt.toFixed(2);

                RRate = $("#gv_Chg_Details input[name*='txtRate']")[i].value;
                
                RCIF = parseFloat(RNetwt) * parseFloat(RRate);
                $("#gv_Chg_Details input[name*='txtCIF']")[i].value = RCIF.toFixed(2);

                chk_inv = $("#gv_Chg_Details input[name*='chk_inv']")[i].checked;
                if (chk_inv == true) {
                           
                SumRNetwt = parseFloat(SumRNetwt) + parseFloat(RNetwt);
                SumRGrwt = parseFloat(SumRGrwt) + parseFloat(RGrwt);
                SumRCIF = parseFloat(SumRCIF) + parseFloat(RCIF);


                if (SumRPkgs == "0.00") {

                    if (RPkgs == 1) {                        
                        txtPackage_Range = txtPackage_Range + "01";                        
                    }
                    else if (RPkgs > 1) {                        
                        txtPackage_Range = txtPackage_Range + "01-" + RPkgs;                        
                    }
                }
                else {
                    if (RPkgs == 1) {
                        txtPackage_Range = txtPackage_Range + " " + (parseFloat(SumRPkgs)+1);                        
                    }
                    else if (RPkgs > 1) {
                        txtPackage_Range = txtPackage_Range + " " + (parseFloat(SumRPkgs) + 1) + "-" + (parseFloat(SumRPkgs) + parseFloat(RPkgs));                        
                    }
                }

                SumRPkgs = parseFloat(SumRPkgs) + parseFloat(RPkgs);               
            }
        }
        SumRPkgs = SumRPkgs.toFixed(2);
        document.getElementById("<%= txtTotalPkgs.ClientID%>").value = SumRPkgs;

        SumRNetwt = SumRNetwt.toFixed(2);
        document.getElementById("<%= txtTotalNetwt.ClientID%>").value = SumRNetwt;

        SumRGrwt = SumRGrwt.toFixed(2);
        document.getElementById("<%= txtTotalGrwt.ClientID%>").value = SumRGrwt;

        SumRCIF = SumRCIF.toFixed(2);
        document.getElementById("<%= txtTotalCIF.ClientID%>").value = SumRCIF;

        document.getElementById("<%= txtPackage_Range.ClientID%>").value = txtPackage_Range;



        //alert('INSIDE_CALC start');
        //INSIDE_CALC();

        //INVPACK_FINAL_CALCULATION(TCurVal, TTTotalCIF);
        document.getElementById("<%= txtCIF_FOREIGN.ClientID%>").value = document.getElementById("<%= txtTotalCIF.ClientID%>").value;
        if (document.getElementById("<%= txtCIF_FOREIGN.ClientID%>").value == "" || document.getElementById("<%= txtCIF_FOREIGN.ClientID%>").value == "NAN") { document.getElementById("<%= txtCIF_FOREIGN.ClientID%>").value = "0.00"; }
        document.getElementById("<%= txtCIF_FOREIGN.ClientID%>").value = parseFloat((document.getElementById("<%= txtCIF_FOREIGN.ClientID%>").value)).toFixed(2);
        document.getElementById("<%= txtCIF_LOCAL.ClientID%>").value = parseFloat(document.getElementById("<%= txtCIF_FOREIGN.ClientID%>").value) * parseFloat(document.getElementById("<%= txtExchangeRate.ClientID%>").value);
        document.getElementById("<%= txtCIF_LOCAL.ClientID%>").value = parseFloat((document.getElementById("<%= txtCIF_LOCAL.ClientID%>").value)).toFixed(2);


        if (document.getElementById("<%= txtFRT_FOREIGN.ClientID%>").value == "" || document.getElementById("<%= txtFRT_FOREIGN.ClientID%>").value == "NAN") { document.getElementById("<%= txtFRT_FOREIGN.ClientID%>").value = "0.00"; }
        document.getElementById("<%= txtFRT_FOREIGN.ClientID%>").value = parseFloat((document.getElementById("<%= txtFRT_FOREIGN.ClientID%>").value)).toFixed(2);
        document.getElementById("<%= txtFRT_LOCAL.ClientID%>").value = parseFloat(document.getElementById("<%= txtFRT_FOREIGN.ClientID%>").value) * parseFloat(document.getElementById("<%= txtExchangeRate.ClientID%>").value);
        document.getElementById("<%= txtFRT_LOCAL.ClientID%>").value = parseFloat((document.getElementById("<%= txtFRT_LOCAL.ClientID%>").value)).toFixed(2);


        if (document.getElementById("<%= txtINS_FOREIGN.ClientID%>").value == "" || document.getElementById("<%= txtINS_FOREIGN.ClientID%>").value == "NAN") { document.getElementById("<%= txtINS_FOREIGN.ClientID%>").value = "0.00"; }
        document.getElementById("<%= txtINS_FOREIGN.ClientID%>").value = parseFloat((document.getElementById("<%= txtINS_FOREIGN.ClientID%>").value)).toFixed(2);
        document.getElementById("<%= txtINS_LOCAL.ClientID%>").value = parseFloat(document.getElementById("<%= txtINS_FOREIGN.ClientID%>").value) * parseFloat(document.getElementById("<%= txtExchangeRate.ClientID%>").value);
        document.getElementById("<%= txtINS_LOCAL.ClientID%>").value = parseFloat((document.getElementById("<%= txtINS_LOCAL.ClientID%>").value)).toFixed(2);

        document.getElementById("<%= txtFOB_FOREIGN.ClientID%>").value = parseFloat(document.getElementById("<%= txtCIF_FOREIGN.ClientID%>").value) - parseFloat(document.getElementById("<%= txtFRT_FOREIGN.ClientID%>").value) - parseFloat(document.getElementById("<%= txtINS_FOREIGN.ClientID%>").value);
        if (document.getElementById("<%= txtFOB_FOREIGN.ClientID%>").value == "" || document.getElementById("<%= txtFOB_FOREIGN.ClientID%>").value == "NAN") { document.getElementById("<%= txtFOB_FOREIGN.ClientID%>").value = "0.00"; }
        document.getElementById("<%= txtFOB_FOREIGN.ClientID%>").value = parseFloat((document.getElementById("<%= txtFOB_FOREIGN.ClientID%>").value)).toFixed(2);
        document.getElementById("<%= txtFOB_LOCAL.ClientID%>").value = parseFloat(document.getElementById("<%= txtFOB_FOREIGN.ClientID%>").value) * parseFloat(document.getElementById("<%= txtExchangeRate.ClientID%>").value);
        document.getElementById("<%= txtFOB_LOCAL.ClientID%>").value = parseFloat((document.getElementById("<%= txtFOB_LOCAL.ClientID%>").value)).toFixed(2);
    }




</script>

</body>
</html>
