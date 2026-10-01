<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Invoice_Report_Details.aspx.cs"
    Inherits="Export_Export_Invoice_Report_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export - Invoice</title>
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
                        Invoice
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
                            <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1" TabIndex="5"
                                OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen_export">
                            Invoice No & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtInvoiceNo_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                TabIndex="11" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen2">
                            Exporter's Ref.
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtExporters_Ref" runat="server" MaxLength="35" ClientIDMode="Static"
                                TabIndex="11" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <%-- <div id="txtcon-m_transaction_code">
                            <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClientClick="open_jobno(); return false" />
                        </div>--%>
                        <div id="txtcon-m_transaction_code">
                            <a href="#" class="generate" id="btn_Report" runat="server" style="display: block;"
                                onclick="open_jobno();return false;"></a>
                        </div>
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
                            Buyer Order No & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtBuyerOrderNo_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                TabIndex="11" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen2">
                            Other References
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtOther_References" runat="server" MaxLength="35" ClientIDMode="Static"
                                TabIndex="11" CssClass=" txtbox_trans_exp_drawback"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Trans_new" style="background-image: none;height: 482px; width: 960px;">
                <div class="content" id="page-1" >
                    <div id="pop_text_area_transac_popup_inn_container_export1" style="height: 425px;"
                        runat="server">
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Exporter
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtExporter" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Buyer(if other than consignee)
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtBuyer" runat="server" MaxLength="35" ClientIDMode="Static" TabIndex="11"
                                    CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtBuyer_Add1" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="12" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtBuyer_Add2" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtAddress3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtBuyer_Add3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtAddress4" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtBuyer_Add4" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtAddress5" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtBuyer_Add5" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Consignee
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Notify
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtNotify" runat="server" MaxLength="35" ClientIDMode="Static" TabIndex="11"
                                    CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <%--                        <div id="innerbox_MidMain_bot_transact" style="line-height: 1px;width: 290px;line-height: 1px;margin-top: 0;float: right;">
                               MEAN OF TRANSPORT (ASEAN-INDIA)
                            </div>--%>
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
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtNotify_Add1" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <%--<div id="tag_label_transaction_exp_jobb" style="width:180px;">
                            Port of loading
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                Onkeypress="return num1(event)" MaxLength="10" TabIndex="6"></asp:TextBox>
                        </div>--%>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="width: 110%; height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add2" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtNotify_Add2" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtNotify_Add3" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; height: 40px;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add4" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtNotify_Add4" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0; height: 40px;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtConsignee_Add5" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtNotify_Add5" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Pre Carriage by
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtPre_Carriageby" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Place of receipt by pre-carrier
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtPlace_ReceiptBy_PreCarrier" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <%--                        <div id="innerbox_MidMain_bot_transact" style="line-height: 1px;width: 290px;line-height: 1px;margin-top: 0;float: right;">
                               MEAN OF TRANSPORT (ASEAN-INDIA)
                            </div>--%>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Vessel/Flight No
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtVessel_Flight_No" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Port of Discharge
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtPort_Of_Discharge" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <%--                        <div id="innerbox_MidMain_bot_transact" style="line-height: 1px;width: 290px;line-height: 1px;margin-top: 0;float: right;">
                               MEAN OF TRANSPORT (ASEAN-INDIA)
                            </div>--%>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Port of loading
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtPort_Of_Loading" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Final Destination
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtFinal_Destination" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <%--                        <div id="innerbox_MidMain_bot_transact" style="line-height: 1px;width: 290px;line-height: 1px;margin-top: 0;float: right;">
                               MEAN OF TRANSPORT (ASEAN-INDIA)
                            </div>--%>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Country Of Origin Of Goods
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtCountry_Origin_Goods" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Country Final Destination
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtCountry_Final_Destination" runat="server" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <%--                        <div id="innerbox_MidMain_bot_transact" style="line-height: 1px;width: 290px;line-height: 1px;margin-top: 0;float: right;">
                               MEAN OF TRANSPORT (ASEAN-INDIA)
                            </div>--%>
                        </div>
                    </div>
                    <div id="tab2" runat="server">
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0;">
                            <div id="tag_label_transaction_popup_IGM_Others_Cond">
                                Terms Of Delivery and Payment
                            </div>
                            <div id="txtcon_l_90px">
                            </div>
                            <div id="txtcon-m_90px_trans_Inv_con">
                                <asp:TextBox ID="txtTerms_Delivery_Payment" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_Inv_con"
                                    onpaste="return checkTextAreaMaxLength(this,event,'1000');" runat="server" onkeyDown="return checkTextAreaMaxLength(this,event,'1000');"
                                    MaxLength="1000" TabIndex="75"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Others_Cond">
                                Remarks</div>
                            <div id="txtcon_l_90px">
                            </div>
                            <div id="txtcon-m_90px_trans_Inv_con">
                                <asp:TextBox ID="txtRemarks" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_Inv_con"
                                    onpaste="return checkTextAreaMaxLength(this,event,'1000');" runat="server" onkeyDown="return checkTextAreaMaxLength(this,event,'1000');"
                                    MaxLength="1000" TabIndex="75"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 70px;">
                            <div id="tag_label_transaction_exp_jobb">
                                Quantity
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txtQuality" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                    onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="15" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Rate per Unit
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txtRate" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                     onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="15" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Amount
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txtamount" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                     onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="15" TabIndex="13"></asp:TextBox>
                            </div>
                        </div>
                        <%--   <div id="innerbox_MidMain_bot_transact" style="font-weight:normal;padding-left: 125px;margin-top: 5px;height:30px">
                        <div id="tag_label_transaction_exp_jobb" style="width:180px;"  style="width:150px;"> Marks & Nos </div>
                      
                        <div id="tag_label_transaction_exp_jobb" style="width:180px;" style="width:200px;" >&nbsp; &nbsp;&nbsp;&nbsp; Goods Description</div>
                        <div id="tag_label_transaction_exp_jobb" style="width:180px;"  style="width:100px;"> Quantity</div>
                        <div id="tag_label_transaction_exp_jobb" style="width:180px;" style="width:100px;" > Rate</div>
                        <div id="tag_label_transaction_exp_jobb" style="width:180px;"  style="width:140px;"> Total</div>
                     
                         
                         </div>--%>

                         <div id="tag_transac_export_lft_item_gen_Grid_area_Exbond" style="height: 215px;
                            margin-bottom: 0px; width: 950px">
                        <asp:GridView ID="gvAll" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" OnRowCreated="gvAll_RowCreated"
                            OnRowDataBound="gvAll_RowDataBound"  OnRowDeleting="gvAll_RowDeleting"
                            PageSize="12" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%">
                            <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                            <Columns>
                                <%--<asp:BoundField DataField="RowNumber" HeaderText="S.No" />--%>
                                <asp:TemplateField HeaderText="Marks & Nos">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtftrItem_marks" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                            MaxLength="120" Text='<%# Bind("MARKS_NOS") %>' Width="150px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtftrItem_desc" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                            MaxLength="120" Text='<%# Bind("DESCRIPTION") %>' Width="430px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Qty">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtftrItem_Qty" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                            MaxLength="23" Text='<%# Bind("QTY") %>' Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rate">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtftrItem_rate" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                            MaxLength="23" Text='<%# Bind("RATE") %>' Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtftrItem_total" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                            MaxLength="23" Text='<%# Bind("TOTAL") %>' Width="100px"></asp:TextBox>
                                    </ItemTemplate>
                                
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>


                        <div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 20px;">
                            <div id="tag_label_transaction_exp_jobb">
                                Freight
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txtFreight" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="15" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb" style="width: 180px;">
                                Discount
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txtDiscount" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                     onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="15" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Total
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="txtTotal" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                     onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtFreight');return Clear_Dot(this);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="15" TabIndex="13"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_exports_item_margs_nos_others_new1">
                            <div id="tag_label_transaction_iten_new1_nos_othres">
                                Rupees
                            </div>
                            <asp:TextBox ID="txtRupees" runat="server" MaxLength="120" CssClass="txtbox_none_Mid_transac_item_gen_decs"
                                TabIndex="1" TextMode="MultiLine" onkeyDown="return checkTextAreaMaxLength(this,event,'120');"
                                onpaste="return checkTextAreaMaxLength(this,event,'120');"></asp:TextBox>
                        </div>
                        <%--<div id="innerbox_MidMain_bot_transact" style="height: 25px; font-weight: normal;
                            margin-top: 0px;">
                            <div id="tag_label_transaction_exp_jobb" style="width:180px;">
                               Country Of Origin
                            </div>
                            <div id="txt_trans_exp_drawback">
                                <asp:TextBox ID="TextBox7" runat="server" ClientIDMode="Static" CssClass=" txtbox_trans_exp_drawback"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            </div>--%>
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
                                TabIndex="36" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                Visible="false" OnClientClick="return validate_Invoice();" TabIndex="36" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="37" CausesValidation="false"
                                Visible="false" UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'INVOICE REPORT', function(r) {
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
                    <%--<asp:Button ID="Button2" runat="server" TabIndex="116"  CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="dlete" Style="display: none;" OnClick="btngrid_delete_Click" />--%>
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
                    NewWindow1('../Report/Export_Invoice_rpt_viewer.aspx?jobno=' + f + '', 'List', '870', '1024', 'yes');

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
