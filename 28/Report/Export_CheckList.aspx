<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_CheckList.aspx.cs"
    MasterPageFile="~/Import_MasterPage/eRoyalMasters.master" Inherits="Transaction_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<script src="../js/Validation.js" type="text/javascript"></script>--%>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <script type="text/javascript">
        function open_jobno() {
            if (document.getElementById("<%= ddlJobNo.ClientID %>").value != 'Select') {
                document.getElementById("<%= HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;

                if (document.getElementById("<%= HiddenField1.ClientID %>").value != '') {
                    var f = document.getElementById("<%= HiddenField1.ClientID %>").value;
                    var f1 = document.getElementById("<%=hdn_Annexure_Mode.ClientID %>").value;
                    var f2 = document.getElementById("<%=hdn_STR_Code.ClientID %>").value;
                    var Igst_Calc_T_F = document.getElementById("<%=hdn_IGST_Calc.ClientID %>").value;

                    var chk = "True";
                    if (document.getElementById("<%=chk_Stmt.ClientID%>").checked == true) {
                        var chk = "True";
                    }
                    else {
                        var chk = "False";
                    }

                    var IGST_selectvalue = '';
                    if (Igst_Calc_T_F == 'T') {
                        var inputs = document.getElementById('<%=rdl_IGST.ClientID %>').getElementsByTagName("input");
                        for (var i = 0; i < inputs.length; i++) {
                            if (inputs[i].checked) {
                                IGST_selectvalue = inputs[i].value;
                            }
                        }
                    }



                    var selected_invFC = document.querySelector('input[name="<%= rdl_Invoice_FC.UniqueID %>"]:checked');
                    var rdl_Invoice_FC_selected = selected_invFC.value;

                    var selected_inv_INR = document.querySelector('input[name="<%= rdl_Invoice_INR.UniqueID %>"]:checked');
                    var rdl_Invoice_INR_selected = selected_inv_INR.value;

                    var selected_FOB_FC = document.querySelector('input[name="<%= rdl_FOB_FC.UniqueID %>"]:checked');
                    var rdl_FOB_FC_selected = selected_FOB_FC.value;

                    var selected_FOB_INR = document.querySelector('input[name="<%= rdl_FOB_INR.UniqueID %>"]:checked');
                    var rdl_FOB_INR_selected = selected_FOB_INR.value;


                    var ddlReport = document.getElementById("<%=ddlJobNo.ClientID%>");
                    //NewWindow1('../Report/Export_ReportViewer.aspx?jobno=' + f + '&Annexure_Mode=' + f1 + '&STR_CODE=' + f2 + '&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '&IGST_Calc=' + IGST_selectvalue + '', 'List', '810', '1024', 'yes');
                    NewWindow1('../Report/Export_ReportViewer.aspx?jobno=' + f + '&Annexure_Mode=' + f1 + '&STR_CODE=' + f2 + '&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '&IGST_Calc=' + IGST_selectvalue + '&rdl_Invoice_FC=' + rdl_Invoice_FC_selected + '&rdl_Invoice_INR=' + rdl_Invoice_INR_selected + '&rdl_FOB_FC=' + rdl_FOB_FC_selected + '&rdl_FOB_INR=' + rdl_FOB_INR_selected + '', 'List', '810', '1024', 'yes');

                    return false;
                }
            }
        }

        function open_jobnoNew() {

            if (document.getElementById("<%= ddlJobNo.ClientID %>").value != 'Select') {
                document.getElementById("<%= HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;

                if (document.getElementById("<%= HiddenField1.ClientID %>").value != '') {

                    var f = document.getElementById("<%= HiddenField1.ClientID %>").value;
                    var f1 = document.getElementById("<%=hdn_Annexure_Mode.ClientID %>").value;
                    var f2 = document.getElementById("<%=hdn_STR_Code.ClientID %>").value;
                    var Igst_Calc_T_F = document.getElementById("<%=hdn_IGST_Calc.ClientID %>").value;

                    var chk = "True";
                    if (document.getElementById("<%=chk_Stmt.ClientID%>").checked == true) {
                        var chk = "True";
                    }
                    else {
                        var chk = "False";
                    }

                    var IGST_selectvalue = '';
                    if (Igst_Calc_T_F == 'T') {
                        var inputs = document.getElementById('<%=rdl_IGST.ClientID %>').getElementsByTagName("input");
                        for (var i = 0; i < inputs.length; i++) {
                            if (inputs[i].checked) {
                                IGST_selectvalue = inputs[i].value;
                            }
                        }
                    }


                    var selected_invFC = document.querySelector('input[name="<%= rdl_Invoice_FC.UniqueID %>"]:checked');
                    var rdl_Invoice_FC_selected = selected_invFC.value;

                    var selected_inv_INR = document.querySelector('input[name="<%= rdl_Invoice_INR.UniqueID %>"]:checked');
                    var rdl_Invoice_INR_selected = selected_inv_INR.value;

                    var selected_FOB_FC = document.querySelector('input[name="<%= rdl_FOB_FC.UniqueID %>"]:checked');
                    var rdl_FOB_FC_selected = selected_FOB_FC.value;

                    var selected_FOB_INR = document.querySelector('input[name="<%= rdl_FOB_INR.UniqueID %>"]:checked');
                    var rdl_FOB_INR_selected = selected_FOB_INR.value;


                    var ddlReport = document.getElementById("<%=ddlJobNo.ClientID%>");
                    //NewWindow1('../Report/Export_ReportViewerNew.aspx?jobno=' + f + '&IsBulk=N&&IsHdrRepeat=N&Annexure_Mode=' + f1 + '&STR_CODE=' + f2 + '&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '&IGST_Calc=' + IGST_selectvalue + '', 'List', '810', '1024', 'yes');
                    NewWindow1('../Report/Export_ReportViewerNew.aspx?jobno=' + f + '&IsBulk=N&&IsHdrRepeat=N&Annexure_Mode=' + f1 + '&STR_CODE=' + f2 + '&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '&IGST_Calc=' + IGST_selectvalue + '&rdl_Invoice_FC=' + rdl_Invoice_FC_selected + '&rdl_Invoice_INR=' + rdl_Invoice_INR_selected + '&rdl_FOB_FC=' + rdl_FOB_FC_selected + '&rdl_FOB_INR=' + rdl_FOB_INR_selected + '', 'List', '810', '1024', 'yes');
                    return false;
                }
            }
        }


        function open_jobnoNewHdrRepeat() {
            if (document.getElementById("<%= ddlJobNo.ClientID %>").value != 'Select') {
                document.getElementById("<%= HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;

                if (document.getElementById("<%= HiddenField1.ClientID %>").value != '') {
                    var f = document.getElementById("<%= HiddenField1.ClientID %>").value;
                    var f1 = document.getElementById("<%=hdn_Annexure_Mode.ClientID %>").value;
                    var f2 = document.getElementById("<%=hdn_STR_Code.ClientID %>").value;

                    var ddlReport = document.getElementById("<%=ddlJobNo.ClientID%>");
                    NewWindow1('../Report/Export_ReportViewerNew.aspx?jobno=' + f + '&IsBulk=N&IsHdrRepeat=Y&Annexure_Mode=' + f1 + '&STR_CODE=' + f2 + '&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '', 'List', '810', '1024', 'yes');
                    return false
                }
            }
        }

        function open_jobno_Annexure_C() {
            if (document.getElementById("<%= ddlJobNo.ClientID %>").value != 'Select') {
                document.getElementById("<%= HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                if (document.getElementById("<%= HiddenField1.ClientID %>").value != '') {
                    var f = document.getElementById("<%= HiddenField1.ClientID %>").value;
                    var f1 = window.parent.document.getElementById('ddlTransportMode').value;
                    var f2 = document.getElementById("<%=hdn_STR_Code.ClientID %>").value;
                    NewWindow1('../Export_Annexure_C/Export_Annexure_Report.aspx?jobno=' + f + '&Annexure_Mode=' + f1 + '&STR_CODE=' + f2 + '', 'List', '810', '1024', 'yes');
                    return false
                }
            }
        }

    </script>
    <script type="text/javascript">

        function showTooltip(el, evt) {
            var target = evt.target;

            // find the actual radio input under the cursor
            var td = target.closest('td');
            var radioInput = td ? td.querySelector('input[type=radio]') : null;

            if (!radioInput) return;

            var tooltip = document.getElementById('customTooltip');
            var itemText = '';

            // try label[for] match first
            var label = document.querySelector("label[for='" + radioInput.id + "']");
            if (label) {
                itemText = label.textContent.trim();
            } else if (radioInput.nextSibling && radioInput.nextSibling.nodeType === 3) {
                itemText = radioInput.nextSibling.textContent.trim();
            } else {
                itemText = radioInput.parentElement.textContent.trim();
            }

            var item_val = '';
            if (itemText == 'Default') {
                item_val = '1000.24';
            }
            else if (itemText == 'Cutoff (2)') {
                item_val = '1000.23';
            }
            else if (itemText == 'Roundoff (0)') {
                item_val = '1000';
            }
            else {
                item_val = '1000.23574';
            }

            tooltip.innerText = item_val;
            tooltip.style.display = 'block';
            positionTooltip(evt);
        }

        function moveTooltip(evt) {
            var tooltip = document.getElementById('customTooltip');
            if (tooltip.style.display === 'block') positionTooltip(evt);
        }

        function hideTooltip() {
            document.getElementById('customTooltip').style.display = 'none';
        }

        function positionTooltip(evt) {
            var tooltip = document.getElementById('customTooltip');
            tooltip.style.left = (evt.clientX + 14) + 'px';
            tooltip.style.top = (evt.clientY + 14) + 'px';
        }

    </script>
    <style type="text/css">
        .radioList label
        {
            display: inline-block;
            width: 75px;
        }
        
        .cvc-tip
        {
            visibility: hidden;
            opacity: 0;
            position: absolute;
            z-index: 20;
            bottom: calc(100% + 8px);
            left: 50%;
            transform: translateX(-50%);
            white-space: nowrap;
            background: #152A4A;
            color: #F4EFE3;
            font-family: 'Consolas' , 'Courier New' ,monospace;
            font-size: 12px;
            font-weight: 600;
            padding: 5px 10px;
            border-radius: 5px;
            transition: opacity .12s ease;
        }
        .cvc-tip::after
        {
            content: "";
            position: absolute;
            top: 100%;
            left: 50%;
            transform: translateX(-50%);
            border: 5px solid transparent;
            border-top-color: #152A4A;
        }
        .cvc-opt:hover .cvc-tip
        {
            visibility: visible;
            opacity: 1;
        }
    </style>
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Export - CheckList</div>
            <span id="Div_Elogix" runat="server" visible="false">
                <div id="mainmastop2container_rght_tag2_txt1">
                    Job No
                    <asp:TextBox ID="txt_Eogix_Job" runat="server" Width="100px" MaxLength="40" ClientIDMode="Static"
                        CssClass="txtbox_none_CheckList"></asp:TextBox>
                    <asp:Button ID="btn_Elogix" runat="server" OnClick="btn_Elogix_Click" />
                    <asp:Literal ID="lbl_Msg" runat="server"></asp:Literal>
                </div>
            </span><span id="Div_ICode" runat="server" visible="false">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 85px;">
                    <asp:Button ID="btn_ICode" Text="Data Move" runat="server" OnClick="btn_ICode_Click" />
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 110px;">
                    <asp:Button ID="btnSendApi" runat="server" Text="Send to Checklist" OnClick="btnSendApi_Click" />
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 85px;">
                    <asp:Button ID="btnSendjson" runat="server" Text="Send JSON" OnClick="btnSendjson_Click" />
                </div>
            </span>
        </div>
        <div id="tag_srcinner2" style="width: 1000px; margin-top: -5px;">
            <div id="tag_srcinner_lft1">
                <div id="tag_label_transaction_popup_no_empty">
                </div>
                <div id="tag_label_transaction_popup_gen" style="margin-left: -5px;">
                    Job No</div>
                <div id="txtcon-m_src">
                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div id="tag_srcinner_rght_Single_line" style="width: 600px;">
                <div id="small-butt-left" style="width: 86px;">
                    <asp:Button ID="btnNewChkList" Text="CheckList" CssClass="autowidmovebut" runat="server"
                        OnClientClick="open_jobnoNew(); return false" Width="80px" />
                </div>
                <div id="small-butt-left" style="width: 100px;">
                    <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClientClick="open_jobno(); return false" />
                </div>
                <div id="small-butt-left" style="width: 120px;">
                    <asp:Button ID="btnAnnexure_C" Text=" Annexure  C Rpt " CssClass="autowidmovebut"
                        runat="server" OnClientClick="open_jobno_Annexure_C(); return false" Width="110px" />
                </div>
               <%-- <div id="small-butt-left" style="width: 86px;">
                    <asp:Button ID="btnNewChkListHdrRepeat" Text="Header" CssClass="autowidmovebut" runat="server"
                        Visible="false" OnClientClick="open_jobnoNewHdrRepeat(); return false" Width="80px" />
                </div>--%>
               
                <div id="small-butt-left" style="width: 96px;">
                    <asp:Button ID="btnXmlChecklist" Text="XML-Checklist" Visible="false" CssClass="autowidmovebut"
                        runat="server" OnClick="open_xmlchecklist" Width="90px" />
                </div>
                 <div id="small-butt-left">
                    <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1_Trigger_AnotherPage1('General',document.getElementById('hdn_source').value);return false;"
                        id="btnCancel" tabindex="55">
                </div>
            </div>
            <div id="tag_srcinner_rght_Single_line" style="width: 600px; margin-top: 0px; margin-left: -90px;">
                <div id="tag_transac_lft_Checklist" style="width: 365px;">
                    <div id="tag_label_transaction_popup_gen" style="font-weight: bold">
                        With Declaration</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:CheckBox ID="chk_Stmt" runat="server" />
                    </div>
                </div>
            </div>
            <div id="Export_CSV" runat="server" visible="false" style="margin-left: 20px; display: inline-block;">
                <asp:LinkButton ID="GroupA_Tally_CSV" runat="server" OnClick="GroupA_Tally_CSV_Click"
                    Style="text-decoration: none; color: inherit;">
                    <asp:Image ID="ImageImport" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px"
                        Height="28px" ToolTip="Download Excel" />
                </asp:LinkButton>
                <span style="font-size: 12px;">CSV</span>
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_Checklist">
                <div id="IGST_FOB_VALUE_Y_N" runat="server" visible="false" style="height: 30px;">
                    <div id="tag_transac_lft_Checklist">
                        <div id="tag_transac_lft_Checklist">
                            <div id="tag_label_transaction_popup_gen" style="font-weight: bold; width: 335px;
                                color: Blue;">
                                <asp:RadioButtonList ID="rdl_IGST" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="FOB">IGST Based on FOB</asp:ListItem>
                                    <asp:ListItem Value="VALUE">IGST Based on VALUE</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="display: none;">
                    <div id="tag_label_transaction_popup_gen">
                        Filing Location</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtCustomHouse" runat="server" MaxLength="40" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen">
                        Exporter</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtExporterName" runat="server" MaxLength="50" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen">
                        Consignee</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtConsignee" runat="server" MaxLength="50" CssClass="txtbox_none_CheckList"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen">
                        No of Invoices</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtNoofInvoices" runat="server" MaxLength="35" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen">
                        No of Items</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtNoofItems" runat="server" MaxLength="35" ClientIDMode="Static"
                            CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="display: none;">
                    <div id="tag_label_transaction_popup_gen">
                        Scheme</div>
                    <div id="txtcon_m_src_new_Checklist">
                        <asp:TextBox ID="txtScheme" runat="server" MaxLength="35" CssClass="txtbox_none_CheckList"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="height: 10px;">
                </div>
                <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen" style="width: 300px; font-weight: bold;
                        background-color: LightSkyBlue; height: 20px;">
                        Checklist Value Customization
                    </div>
                    <div id="tag_label_transaction_popup_gen" style="width: 150px; font-weight: bold;
                        background-color: PeachPuff; height: 20px;">
                        ex. Val = 1000.23574</div>
                </div>
                <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen" style="width: 100px; font-weight: bold;
                        background-color: Gray; color: White; height: 20px;">
                        Filed
                    </div>
                    <div id="tag_label_transaction_popup_gen" style="width: 80px; font-weight: bold;
                        background-color: Gray; color: White; height: 20px;">
                        Opt 1
                    </div>
                    <div id="tag_label_transaction_popup_gen" style="width: 100px; font-weight: bold;
                        background-color: Gray; color: White; height: 20px;">
                        Opt 2
                    </div>
                    <div id="tag_label_transaction_popup_gen" style="width: 100px; font-weight: bold;
                        background-color: Gray; color: White; height: 20px;">
                        Opt 3
                    </div>
                    <div id="tag_label_transaction_popup_gen" style="width: 60px; font-weight: bold;
                        background-color: Gray; color: White; height: 20px;">
                        Opt 4
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen" style="width: 70px;">
                        Invoice FC
                    </div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 400px; margin-top: -3px;">
                        <asp:RadioButtonList ID="rdl_Invoice_FC" runat="server" RepeatDirection="Horizontal"
                            CssClass="radioList" Font-Size="Small" Width="400px" onmouseover="showTooltip(this, event)"
                            onmousemove="moveTooltip(event)" onmouseout="hideTooltip()">
                            <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
                            <asp:ListItem Value="Digit2Cutoff">Cutoff (2)</asp:ListItem>
                            <asp:ListItem Value="Digit0Roundoff">Roundoff (0)</asp:ListItem>
                            <asp:ListItem Value="Actual">Actual</asp:ListItem>
                        </asp:RadioButtonList>
                        <div id="customTooltip" style="display: none; position: absolute; background: #333;
                            color: #fff; padding: 6px 10px; border-radius: 4px; font-size: 12px; z-index: 1000;">
                        </div>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen" style="width: 70px;">
                        Invoice INR
                    </div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 400px; margin-top: -3px;">
                        <asp:RadioButtonList ID="rdl_Invoice_INR" runat="server" RepeatDirection="Horizontal"
                            Font-Size="Small" CssClass="radioList" Width="400px" onmouseover="showTooltip(this, event)"
                            onmousemove="moveTooltip(event)" onmouseout="hideTooltip()">
                            <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
                            <asp:ListItem Value="Digit2Cutoff">Cutoff (2)</asp:ListItem>
                            <asp:ListItem Value="Digit0Roundoff">Roundoff (0)</asp:ListItem>
                            <asp:ListItem Value="Actual">Actual</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen" style="width: 70px;">
                        FOB FC
                    </div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 400px; margin-top: -3px;">
                        <asp:RadioButtonList ID="rdl_FOB_FC" runat="server" RepeatDirection="Horizontal"
                            Font-Size="Small" CssClass="radioList" Width="400px" onmouseover="showTooltip(this, event)"
                            onmousemove="moveTooltip(event)" onmouseout="hideTooltip()">
                            <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
                            <asp:ListItem Value="Digit2Cutoff">Cutoff (2)</asp:ListItem>
                            <asp:ListItem Value="Digit0Roundoff">Roundoff (0)</asp:ListItem>
                            <asp:ListItem Value="Actual">Actual</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist">
                    <div id="tag_label_transaction_popup_gen" style="width: 70px;">
                        FOB INR
                    </div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 400px; margin-top: -3px;">
                        <asp:RadioButtonList ID="rdl_FOB_INR" runat="server" RepeatDirection="Horizontal"
                            Font-Size="Small" CssClass="radioList" Width="400px" onmouseover="showTooltip(this, event)"
                            onmousemove="moveTooltip(event)" onmouseout="hideTooltip()">
                            <asp:ListItem Value="Default" Selected="True">Default</asp:ListItem>
                            <asp:ListItem Value="Digit2Cutoff">Cutoff (2)</asp:ListItem>
                            <asp:ListItem Value="Digit0Roundoff">Roundoff (0)</asp:ListItem>
                            <asp:ListItem Value="Actual">Actual</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
            </div>
            <div id="tag_transac_lft_Item_maindet_Grid_area" runat="server" style="overflow: auto;
                height: 235px; width: 320px; margin-top: 60px;">
                <asp:Label ID="lbl_heading" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                <asp:GridView ID="gv_RITC" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                    Visible="true" AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view"
                    ShowHeaderWhenEmpty="True" PageSize="8" AllowPaging="True" OnRowDataBound="gv_RITC_RowDataBound"
                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="1" CellSpacing="1" OnRowCreated="gv_RITC_RowCreated" OnPageIndexChanging="gv_RITC_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <SelectedRowStyle Font-Bold="true" />
                    <Columns>
                        <asp:BoundField DataField="RITCNO" HeaderStyle-Width="7%">
                            <ItemStyle CssClass="column_style_left5" Width="7%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv SlNo" HeaderStyle-Width="6%">
                            <ItemStyle CssClass="column_style_left5" Width="6%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item Slno" HeaderStyle-Width="25%">
                            <ItemStyle CssClass="column_style_left5" Width="25%" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 20px;">
            <div style="margin-left: 90px;">
                Mismatched Invoice</div>
        </div>
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 120px;
            overflow: auto;">
            <asp:GridView ID="gv_Inv_Item" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                OnRowCreated="gv_RITC_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    BorderWidth="1px" />
                <SelectedRowStyle Font-Bold="true" />
                <Columns>
                    <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv. SlNo" HeaderStyle-Width="15%">
                        <ItemStyle CssClass="column_style_left5" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="INVOICE_VALUE" HeaderText="Inv. Value" HeaderStyle-Width="32%">
                        <ItemStyle CssClass="column_style_left5" Width="32%" ForeColor="Red" Font-Bold="true" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Product_Value" HeaderText="Product Value" HeaderStyle-Width="32%">
                        <ItemStyle ForeColor="Red" CssClass="column_style_left5" Width="32%" Font-Bold="true" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 20px;">
            <div style="margin-left: 130px;">
                <asp:Button ID="btnok" runat="server" Text="Ok" OnClick="btnok_Click" /></div>
        </div>
    </asp:Panel>
    <asp:HiddenField ID="hdn_Annexure_Mode" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_STR_Code" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hdn_currentPage" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_source" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdn_IGST_Calc" runat="server" ClientIDMode="Static" />
    <script type="text/javascript">


        window.onload = happycode;
        window.onload = happycode1;
        function happycode() {

            document.getElementById("Transaction_Id").click();
        }
        function happycode1() {
            var qs = query.get('jobno');
            if (qs.length >= 0) {
                $('#<%= HiddenField1.ClientID %>').val(qs);
                CallServerside_Importer1(qs, $('#<%= txtCustomHouse.ClientID %>').val());
            }
        }
        function openurl(url) {
            var a = $('#<%= HiddenField1.ClientID %>').val();

            if (a.length == 0) {
                window.location.href = url;
            }
            else {
                Child_Parent_close_button1('General'); return false;
            }
        }
        function CallServerside_Importer1(src, dest) {
            Loading_ShowImage();
            PageMethods.Get_Import_Details(src, CallSuccess_Importer, CallFailed, dest);
        }
        $(function () {

            var dropDownList1 = $('#<%= ddlJobNo.ClientID %>');
            dropDownList1.change(function (e) {
                var selectedValue = $(this).val();
                if (selectedValue != '') {
                    document.getElementById('HiddenField1').value = selectedValue;
                }
            });
        });


        function CallServerside_Importer(src, dest) {
            Loading_ShowImage();
            var ctrl = document.getElementById(src);
            PageMethods.Get_Import_Details(ctrl.value, CallSuccess_Importer, CallFailed, dest);
        }
        function CallSuccess_Importer(res, destCtrl) {
            Loading_HideImage();
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data.indexOf("~~") != -1) {
                var s = data.split('~~');
                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];
                var after3 = s[3];
                var after4 = s[4];
                var after5 = s[5];
                var after6 = s[6];
                var after7 = s[7];

                document.getElementById("txtCustomHouse").value = before;
                document.getElementById("txtExporterName").value = after1;
                document.getElementById("txtScheme").value = after2;
                document.getElementById("txtConsignee").value = after3;
                document.getElementById("txtNoofItems").value = after4;
                document.getElementById("txtNoofInvoices").value = after5;
                document.getElementById("hdn_Annexure_Mode").value = after6;
                document.getElementById("hdn_STR_Code").value = after7;
            }
            else {

                document.getElementById("txtCustomHouse").value = "";
                document.getElementById("txtExporterName").value = "";
                document.getElementById("txtScheme").value = "";
                document.getElementById("txtConsignee").value = "";
                document.getElementById("txtNoofItems").value = "";
                document.getElementById("txtNoofInvoices").value = "";
                document.getElementById("hdn_Annexure_Mode").value = "";
                document.getElementById("hdn_STR_Code").value = "";
            }
        }
        function CallFailed(res, destCtrl) {
        }
    </script>
    <script type="text/javascript">
        function Child_Parent_close_button1_Trigger_AnotherPage1(val, pagename) {
            window.parent.close_button_Trigger_AnotherPage(val, pagename);
        }

        function close_button_Trigger_AnotherPage(val, pagename) {
            document.getElementById("hdn_source").value = pagename;
            document.getElementById(val).click();
        }
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
                        document.getElementById("hdn_source").value = 'Tab_Checklist';
                        document.getElementById('btnCancel').click();
                    }
                    if (keyCode == 37) {
                        document.getElementById("hdn_source").value = 'Tab_Checklist_Prev';
                        document.getElementById('btnCancel').click();
                    }
                }
            }
        });
    </script>
</asp:Content>
