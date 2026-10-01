<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_CheckList_JOB.aspx.cs"
    Inherits="Import_CheckList_JOB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Import Checklist</title>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <%--
    <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />
    --%>
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
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
        /* Autocomplete Textbox Search Loading Image*/
        
        .valueBox
        {
            padding: 4px;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-weight: bold;
            transition: 0.2s ease-in-out;
        }
        
        .smallMessage
        {
            display: inline-block;
            font-size: 11px;
            font-weight: bold;
            white-space: nowrap;
            vertical-align: middle;
            margin-left: 6px;
        }
        
        .msgClose
        {
            margin-left: 6px;
            cursor: pointer;
            font-weight: bold;
        }
        
        .greenShadow
        {
            border: 2px solid #28a745 !important;
            box-shadow: 0 0 6px rgba(40, 167, 69, 0.7);
        }
        
        .redShadow
        {
            border: 2px solid #dc3545 !important;
            box-shadow: 0 0 6px rgba(220, 53, 69, 0.7);
        }
        #gvChecklistDetails th
        {
            position: sticky;
            top: 0;
            z-index: 2;
            background-color: #4a7c3f;
            color: white;
        }
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
        function HideModalPopup_Job() {

            $('#MessageDivupdated_Job').hide();
        }  
    </script>
    <script type="text/javascript">

        function MPEU_hide() {
            //            $('#MPEU').hide();           
            $find('details_chklist').hide();
        }

        function MPEU2_hide() {
            //            $('#MPEU').hide();           
            $find('details_search_chklist').hide();
        }    
    </script>
    <script type="text/javascript">
        function windowOpen() {

            if (document.getElementById("ddlJobNo").value != 'Select') {

                NewWindow1('../Transaction/GATT_form.aspx?jobno=' + document.getElementById("ddlJobNo").value + '', 'List', '810', '1024', 'yes');
                return false;
            }
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
    <script type="text/javascript">
        $(document).ready(function () {

            var hdn_BE_Y_N = $('#hdn_BE_Y_N').val();
            var hdn_Amend_Y_N = $('#hdn_Amend_Y_N').val();

            if (hdn_BE_Y_N == 'Yes') {
                if (hdn_Amend_Y_N == 'No' || hdn_Amend_Y_N == '') {
                    document.getElementById("tag_transac_lft_Checklist_Amend_T_F").style.display = "none";
                    document.getElementById("small_butt_left_ckk1").style.display = "block"; //btnNewChkList
                    document.getElementById("small_butt_left_ckk2").style.display = "none"; //btnNewChkList_UpdateRates

                    document.getElementById("small_butt_left_ckk3").style.display = "block"; //btnSearch
                    document.getElementById("small_butt_left_ckk4").style.display = "none"; //btnSearch_UpdateRates
                }
                else {
                    document.getElementById("tag_transac_lft_Checklist_Amend_T_F").style.display = "block";
                    document.getElementById("small_butt_left_ckk1").style.display = "block"; //btnNewChkList
                    document.getElementById("small_butt_left_ckk2").style.display = "none"; //btnNewChkList_UpdateRates

                    document.getElementById("small_butt_left_ckk3").style.display = "block"; //btnSearch
                    document.getElementById("small_butt_left_ckk4").style.display = "none"; //btnSearch_UpdateRates
                }
            }
            else {
                document.getElementById("tag_transac_lft_Checklist_Amend_T_F").style.display = "none";
                document.getElementById("small_butt_left_ckk1").style.display = "none"; //btnNewChkList
                document.getElementById("small_butt_left_ckk2").style.display = "block"; //btnNewChkList_UpdateRates

                document.getElementById("small_butt_left_ckk3").style.display = "none"; //btnSearch
                document.getElementById("small_butt_left_ckk4").style.display = "block"; //btnSearch_UpdateRates
            }
        });
    </script>
    <script type="text/javascript">
        function chk_Amend_T_F(chk) {
            if (chk.checked) {
                document.getElementById("small_butt_left_ckk1").style.display = "none"; //btnNewChkList
                document.getElementById("small_butt_left_ckk2").style.display = "block"; //btnNewChkList_UpdateRates

                document.getElementById("small_butt_left_ckk3").style.display = "none"; //btnSearch
                document.getElementById("small_butt_left_ckk4").style.display = "block"; //btnSearch_UpdateRates
            }
            else {
                document.getElementById("small_butt_left_ckk1").style.display = "block"; //btnNewChkList
                document.getElementById("small_butt_left_ckk2").style.display = "none"; //btnNewChkList_UpdateRates

                document.getElementById("small_butt_left_ckk3").style.display = "block"; //btnSearch
                document.getElementById("small_butt_left_ckk4").style.display = "none"; //btnSearch_UpdateRates
            }
        }
    </script>
    <script type="text/javascript">
        function get_button_id(e) {
            document.getElementById("hdn_Button_id").value = e.replace('ContentPlaceHolder1_', '');
            //        alert(document.getElementById("hdn_Button_id").value);
        }
   
    </script>
    <style type="text/css">
        #tag_transac_lft_Checklist_Amend_T_F
        {
            width: 470px;
            height: 25px;
            margin: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <div class="loading" align="center" id="load" style="display: none;">
        <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
    </div>
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 240px">
                Import - CheckList
            </div>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                <%--<asp:Button ID="btn_chklist_Validation" Text="Validate Checklist" BackColor="AntiqueWhite"
                    CssClass="autowidmovebut" runat="server" Width="120px" OnClick="btn_chklist_Validation_Click" />--%>
                <%-- <asp:Button ID="btn_chklist_Validation" Text="Validate Checklist" BackColor="AntiqueWhite"  OnClick="Job_Mismatched_Data_Delete();return false;"
                    CssClass="autowidmovebut" runat="server" Width="120px"  />--%>
                <asp:Button ID="btn_chklist_Validation" Text="Validate Checklist" BackColor="AntiqueWhite"
                    CssClass="autowidmovebut" runat="server" Width="120px" OnClientClick="Job_Mismatched_Data_Delete();return false;" />
            </div>
            <span id="Div_Elogix" runat="server" visible="false" style="width: 100px;">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 400px; margin-top: 5px;">
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
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 90px;">
                    <asp:Button ID="btnSendApi" runat="server" Text="Send Checklist" CssClass="btn btn-success"
                        OnClick="btnSendApi_Click" />
                </div>
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 85px;">
                    <asp:Button ID="btnSendjson" runat="server" Text="Send JSON" CssClass="btn btn-success"
                        OnClick="btnSendjson_Click" />
                </div>
            </span>
        </div>
        <div id="tag_srcinner2" style="width: 930px">
            <div id="tag_srcinner_lft1" style="width: 320px">
                <div id="tag_label_transaction_popup_no_empty">
                </div>
                <div id="tag_label_transaction_popup_gen">
                    Job No</div>
                <div id="txtcon-m_src" style="width: 180px;">
                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                        Width="180px">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div id="tag_srcinner_rght_Single_line" style="width: 610px;">
                <div id="small-butt-left" style="height: 25px;">
                    <div id="small_butt_left_ckk1" style="width: 70px;">
                        <asp:Button ID="btnNewChkList" Text="CheckList" CssClass="autowidmovebut" runat="server"
                            OnClientClick="get_button_id(this.id);open_jobnoNew(); return false" Width="80px" />
                    </div>
                    <div id="small_butt_left_ckk2" style="width: 70px;">
                        <asp:Button ID="btnNewChkList_UpdateRates" Text="CheckList" OnClientClick="get_button_id(this.id); return false"
                            CssClass="autowidmovebut" runat="server" Width="80px" />
                    </div>
                    <span id="lbl_Chk_Error" title="Pending Bill" runat="server" onclick="open_GST_Checklist_error('Import');return false;"
                        visible="false" style="color: Red; cursor: hand; font-size: 13px;">Check Error (<span
                            style="color: Red; font-weight: bold;">
                            <asp:Literal ID="lblcnt" runat="server"></asp:Literal></span>) </span>
                </div>
                <div id="small-butt-left" style="width: 90px;">
                    <div id="small_butt_left_ckk3" style="width: 90px;">
                        <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClientClick="get_button_id(this.id);open_jobno(); return false" />
                    </div>
                    <div id="small_butt_left_ckk4" style="width: 90px;">
                        <asp:Button ID="btnSearch_UpdateRates" CssClass="generate" runat="server" OnClientClick="get_button_id(this.id); return false" />
                    </div>
                </div>
                <div id="small-butt-left">
                    <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1_Trigger_AnotherPage1('General',document.getElementById('hdn_source').value);return false;"
                        id="btnCancel" tabindex="55">
                </div>
                <span id="SDF_Type" runat="server" visible="false" style="width: 100px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 285px; margin-top: 1px;">
                        SDF Type
                        <asp:DropDownList ID="ddlsdftype" runat="server" CssClass="txtbox_none" Style="width: 73px;
                            margin-left: 10px; height: 27px;">
                            <asp:ListItem>BOE</asp:ListItem>
                            <asp:ListItem>CLR1</asp:ListItem>
                            <asp:ListItem>CLR2</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnSDFformat" Text="SDF" CssClass="autowidmovebut" Visible="false"
                            runat="server" Width="90px" OnClick="btnSDFformat_Click" />
                    </div>
                </span>
            </div>
            <div id="tag_srcinner_rght_Single_line" style="width: 320px; margin-top: 0px;">
                <div id="tag_transac_lft_Checklist" style="width: 320px;">
                    <div id="tag_label_transaction_popup_gen" style="font-weight: bold">
                        With Declaration</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:CheckBox ID="chk_Stmt" runat="server" Checked="true" />
                    </div>
                </div>
            </div>
            <div id="tag_srcinner_rght_Single_line" style="width: 610px; margin-top: 0px;">
                <asp:Button ID="btn_WorkSheet" runat="server" Text="Work Sheet" OnClientClick="Duty_Worksheet(); return false" />
                <asp:Button ID="btn_worksheet_All" Visible="false" runat="server" Text="Work Sheet"
                    OnClientClick="Duty_Worksheet1(); return false" />
                <asp:Button ID="btnexcel" Text="BMW" CssClass="autowidmovebut" runat="server" Width="50px"
                    OnClientClick="EXcel()" Visible="false" />
                <asp:Button ID="btnClick" Text="GATT" CssClass="autowidmovebut" runat="server" OnClientClick="return windowOpen()"
                    Width="60px" />
                <asp:Button ID="btnChklistFontBased" Text="Chk-Reliance" Visible="false" CssClass="autowidmovebut"
                    runat="server" OnClientClick="open_jobnoFontBased(); return false" Width="90px" />
                <asp:Button ID="btnXmlChecklist" Text="XML-Checklist" CssClass="autowidmovebut" Visible="false"
                    runat="server" OnClientClick="open_xmlchecklist(); return false" Width="90px" />
                <asp:Button ID="btnOutlook" runat="server" Text="Outlook" CssClass="autowidmovebut"
                    UseSubmitBehavior="false" OnClick="btnOutlook_Click" />
                <%--<asp:Button ID="btnCsvChecklist" Text="CSV-Checklist" CssClass="autowidmovebut" 
                    runat="server"  Width="90px" /> lnkExport --%>
                <%-- <asp:LinkButton ID="GroupA_Tally_CSV" runat="server" OnClick="GroupA_Tally_CSV_Click"  style="text-decoration: none; color: inherit;">
                            <span style="vertical-align: middle;">
                                <asp:Image ID="ImageImport" runat="server" ImageUrl="~/images/icons/xl.png"  Width="34px" Height="28px" ToolTip="Download Excel" />
                            </span>
                        </asp:LinkButton>    --%>
                <div id="import_CSV" runat="server" visible="false" style="height: 30px; margin-left: 298px;
                    margin-top: -28px">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="GroupA_Tally_CSV_Click"
                        Style="text-decoration: none; height: 45px; color: inherit;">
                        <span style="vertical-align: middle;">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/icons/xl.png" Width="34px"
                                Height="28px" ToolTip="Download Excel" />
                        </span>
                    </asp:LinkButton>
                    <div>
                        <span style="font-size: 12px;">CSV</span>
                    </div>
                </div>
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_Checklist" style="width: 398px;">
                <div id="tag_transac_lft_Checklist_Amend_T_F" style="width: 398px; height: 35px;
                    margin-left: 15px;">
                    <div id="tag_label_transaction_popup_gen" style="font-weight: bold; width: 200px;">
                        Item Amend for RITC change</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 180px;">
                        <asp:CheckBox ID="chk_Amend" runat="server" Checked="false" onclick="chk_Amend_T_F(this);" />
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        Filing Location</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtCustomHouse" runat="server" MaxLength="40" ClientIDMode="Static"
                            ReadOnly="true" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        Importer</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtImporterName" runat="server" MaxLength="50" ClientIDMode="Static"
                            ReadOnly="true" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        Supplier</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtSupplier" runat="server" MaxLength="50" CssClass="txtbox_none_CheckList"
                            ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        No of Invoices</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtNoofInvoices" runat="server" MaxLength="35" ClientIDMode="Static"
                            ReadOnly="true" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        No of Items</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtNoofItems" runat="server" MaxLength="35" ClientIDMode="Static"
                            ReadOnly="true" CssClass="txtbox_none_CheckList"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Checklist" style="width: 398px;">
                    <div id="tag_label_transaction_popup_gen">
                        B.E Type</div>
                    <div id="txtcon_m_src_new_Checklist" style="width: 198px;">
                        <asp:TextBox ID="txtBE_Type" runat="server" MaxLength="35" CssClass="txtbox_none_CheckList"
                            ReadOnly="true" ClientIDMode="Static"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div id="AssableDutySetion" runat="server">
                <div id="pop_text_area_transac_popup_inn_container_left_Checklist" style="width: 480px;
                    margin-top: 10px;">
                    <!-- 2x2 Grid Layout for Value Fields -->
                    <table style="width: 100%; border-collapse: separate; border-spacing: 10px 0px;">
                        <tr>
                            <!-- LEFT: IceGate Ass Value -->
                            <td style="width: 50%; vertical-align: top;">
                                <div id="TotalAssValueBlock" runat="server" style="display: none;">
                                    <div style="font-size: 12px; color: #333; margin-bottom: 4px; font-weight: 600;">
                                        Job Ass Value
                                    </div>
                                    <asp:TextBox ID="txtTotalAssValue" runat="server" MaxLength="40" ClientIDMode="Static"
                                        ReadOnly="true" CssClass="valueBox" Style="width: 100%; padding: 6px 8px; border: 2px solid #e74c3c;
                                        border-radius: 4px; font-size: 13px; font-weight: bold; color: #333; background: #fff;
                                        box-sizing: border-box;">
                                    </asp:TextBox>
                                    <span id="lblAssessvalue1" runat="server" style="display: none; margin-left: 5px;"
                                        class="smallMessage">
                                        <asp:Label ID="lblAssessmessage2" runat="server"></asp:Label>
                                        <span class="msgClose"></span></span>
                                </div>
                            </td>
                            <td style="width: 50%; vertical-align: top;">
                                <div id="IcegateAssBlock" runat="server" style="display: none;">
                                    <div style="font-size: 12px; color: #333; margin-bottom: 4px; font-weight: 600;">
                                        IceGate Ass Value
                                    </div>
                                    <asp:TextBox ID="txtIcegateAssvalue" runat="server" MaxLength="40" ClientIDMode="Static"
                                        ReadOnly="true" CssClass="valueBox" Style="width: 100%; padding: 6px 8px; border: 2px solid #e74c3c;
                                        border-radius: 4px; font-size: 13px; font-weight: bold; color: #333; background: #fff;
                                        box-sizing: border-box;">
                                    </asp:TextBox>
                                    <span id="msgWrapper" runat="server" style="display: none; margin-left: 5px;" class="smallMessage">
                                        <asp:Label ID="lblAssessMessage" runat="server"></asp:Label>
                                        <span class="msgClose"></span></span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; vertical-align: top;">
                                <div id="TotalDutyValueBlock" runat="server" style="display: none;">
                                    <div style="font-size: 12px; color: #333; margin-bottom: 4px; font-weight: 600;">
                                        Total Duty Value
                                    </div>
                                    <asp:TextBox ID="txtTotalDutyValue" runat="server" MaxLength="40" ClientIDMode="Static"
                                        ReadOnly="true" CssClass="valueBox" Style="width: 100%; padding: 6px 8px; border: 2px solid #e74c3c;
                                        border-radius: 4px; font-size: 13px; font-weight: bold; color: #333; background: #fff;
                                        box-sizing: border-box;">
                                    </asp:TextBox>
                                    <span id="Span3" runat="server" style="display: none; margin-left: 5px;" class="smallMessage">
                                        <asp:Label ID="lblDutyMessage2" runat="server"></asp:Label>
                                        <span class="msgClose"></span></span>
                                </div>
                            </td>
                            <td style="width: 50%; vertical-align: top;">
                                <div id="IcegateDutyBlock" runat="server" style="display: none;">
                                    <div style="font-size: 12px; color: #333; margin-bottom: 4px; font-weight: 600;">
                                        IceGate Duty Value
                                    </div>
                                    <asp:TextBox ID="txtIcegateDutyValue" runat="server" MaxLength="40" ClientIDMode="Static"
                                        ReadOnly="true" CssClass="valueBox" Style="width: 100%; padding: 6px 8px; border: 2px solid #e74c3c;
                                        border-radius: 4px; font-size: 13px; font-weight: bold; color: #333; background: #fff;
                                        box-sizing: border-box;">
                                    </asp:TextBox>
                                    <span id="lblDutyValue1" runat="server" style="display: none; margin-left: 5px;"
                                        class="smallMessage">
                                        <asp:Label ID="lblDutyMessage1" runat="server"></asp:Label>
                                        <span class="msgClose"></span></span>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div id="gvChecklistDetails_grid" runat="server" style="width: 414px; max-height: 200px;
                        overflow-y: scroll; border: 1px solid #ccc; border-radius: 4px; height: 120px;
                        margin-left: 10px;">
                        <asp:GridView ID="gvChecklistDetails" runat="server" AutoGenerateColumns="False"
                            Width="100%" CellPadding="4" CellSpacing="0" GridLines="Both" EmptyDataText="No Records Found"
                            Font-Size="11px" Style="border-collapse: collapse; min-width: 300px;" OnRowCreated="gvChecklistDetails_RowCreated">
                            <HeaderStyle BackColor="#4a7c3f" ForeColor="White" Font-Bold="true" Height="28px" />
                            <RowStyle BackColor="#f9f9f9" ForeColor="#333" Height="24px" />
                            <AlternatingRowStyle BackColor="#ffffff" />
                            <EmptyDataRowStyle ForeColor="Gray" Font-Italic="true" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="BOND_NO" HeaderText="Bond No" ControlStyle-Width="40px"
                                    HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                    <ItemStyle Width="40px" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BOND_AMT" HeaderText="Job Bond Amount" ControlStyle-Width="40px"
                                    HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="center">
                                    <ItemStyle Width="40px" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ICEGATE_BOND_AMT" HeaderText="Icegate Bond Amount" ControlStyle-Width="40px"
                                    HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="center">
                                    <ItemStyle Width="40px" Font-Size="14px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="hdn_div" runat="server" />
            <asp:HiddenField ID="hdn_Branch" runat="server" />
            <asp:HiddenField ID="hdn_source" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_BE_Y_N" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Amend_Y_N" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Button_id" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />
            <asp:ModalPopupExtender ID="MPEU" runat="server" TargetControlID="btnNewChkList_UpdateRates"
                PopupControlID="MessageDivupdated" BehaviorID="details_chklist" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:HiddenField ID="HDF" runat="server" />
            <asp:Panel ID="MessageDivupdated" runat="server" CssClass="modalPopup" align="center"
                Style="width: 280px; height: 180px; display: none; padding-left: -60px; padding-top: -100px;"
                BorderColor="Transparent">
                <div id="innerbox_MidMain_Trans_new" style="width: 500px; height: 30px; padding-top: -100px;
                    margin-left: -130px; margin-top: -50px;">
                    <div id="tag_label_transaction_Src" style="text-align: center; font-weight: bold;
                        color: White; width: 450px;">
                        Alert !!!
                    </div>
                    <div id="popupwindow_closebut_right" style="margin-top: -49px; margin-right: -89px">
                        <input type="close" value="Submit" class="clsicon" onclick="MPEU_hide();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 500px; height: 130px;
                    border-color: transparent; margin-left: -130px;">
                    <table width="100%" style="padding-left: 60px; margin-left: -50px;">
                        <tr>
                            <td style="height: 20px; text-align: center;">
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px; text-align: center;">
                                <asp:Label ID="Label1" runat="server" Text="Do You want to View , Re-Generate / Previous Saved Checklist?"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnYes" runat="server" CssClass="autowidmovebut" OnClientClick="func_Update_CurrentRate('Update_CurrectRate',document.getElementById('hdn_Button_id').value); return false"
                                    Text="Re-Generate Checklist" Width="200px" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btnNo" runat="server" CssClass="autowidmovebut" OnClientClick="func_Update_CurrentRate('Saved_Chklist',document.getElementById('hdn_Button_id').value); return false"
                                    Text="View Saved Checklist" Width="200px" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
            <asp:ModalPopupExtender ID="MPEU2" runat="server" TargetControlID="btnSearch_UpdateRates"
                PopupControlID="MessageDivupdated2" BehaviorID="details_search_chklist" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:Panel ID="MessageDivupdated2" runat="server" CssClass="modalPopup" align="center"
                Style="width: 280px; height: 180px; display: none; padding-left: -60px; padding-top: -100px;"
                BorderColor="Transparent">
                <div id="innerbox_MidMain_Trans_new" style="width: 500px; height: 30px; padding-top: -100px;
                    margin-left: -130px; margin-top: -50px;">
                    <div id="tag_label_transaction_Src" style="text-align: center; font-weight: bold;
                        color: White; width: 450px;">
                        Alert !!!
                    </div>
                    <div id="popupwindow_closebut_right" style="margin-top: -49px; margin-right: -89px">
                        <input type="close" value="Submit" class="clsicon" onclick="MPEU2_hide();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 500px; height: 130px;
                    border-color: transparent; margin-left: -130px;">
                    <table width="100%" style="padding-left: 60px; margin-left: -50px;">
                        <tr>
                            <td style="height: 20px; text-align: center;">
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 40px; text-align: center;">
                                <asp:Label ID="Label2" runat="server" Text="Do You want to View , Re-Generate / Previous Saved Checklist?"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button2" runat="server" CssClass="autowidmovebut" OnClientClick="func_Update_CurrentRate('Update_CurrectRate',document.getElementById('hdn_Button_id').value); return false"
                                    Text="Re-Generate Checklist" Width="200px" />
                                &nbsp;&nbsp;
                                <asp:Button ID="Button3" runat="server" CssClass="autowidmovebut" OnClientClick="func_Update_CurrentRate('Saved_Chklist',document.getElementById('hdn_Button_id').value); return false"
                                    Text="View Saved Checklist" Width="200px" />
                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>


 

            <script type="text/javascript">
                var win = null;

                var Jobno = $('#<%= ddlJobNo.ClientID %>').val();
                var Branch_Common = $('#<%= hdn_Branch.ClientID %>').val();

                function EXcel() {
                    var Type = 'excel';
                    win = window.open('../FlatFile/MIS_report_1.aspx?IMP_BMW_EXCEL_SANCO=Yes&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '', 'ndf');
                    Loading_HideImage();
                }

            </script>
            <script type="text/javascript">
                var win = null;

                var Jobno = $('#<%= ddlJobNo.ClientID %>').val();
                var Branch_Common = $('#<%= hdn_Branch.ClientID %>').val();

                function Duty_Worksheet() {
                    var Type = 'excel';
                    win = window.open('../FlatFile/MIS_report_1.aspx?Open_Import_DUTY_WORKSHEET_XLs=Yes&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '', 'ndf');
                    Loading_HideImage();
                }

                function Duty_Worksheet1() {
                    var Type = 'excel';
                    var jobno = $('#<%= ddlJobNo.ClientID%>').val();
                    if (jobno == '') {
                        alert('Please Select JobNo');
                        return false;
                    }
                    win = window.open('../FlatFile/MIS_report_1.aspx?Open_Import_DUTY_WORKSHEET_ALL_XLs=Yes&Jobno=' + Jobno + '&Branch_Common=' + Branch_Common + '', 'ndf');
                    Loading_HideImage();
                }

            </script>
            <script type="text/javascript">

                function open_WorkSheet() {
                    if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                        document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                        if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                            var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                            NewWindow1('../BAS_Shipping/Import_DutyWorkSheet_Rpt_viewer.aspx?jobno=' + f + '', 'List', '810', '1024', 'yes');
                            return false
                        }
                    }
                }
            </script>
            <script type="text/javascript">

                function open_jobnoNew() {
                    if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                        document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;

                        if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {
                            var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                            var ddlReport = document.getElementById("<%=ddlJobNo.ClientID%>");

                            var chk = "True";
                            if (document.getElementById("<%=chk_Stmt.ClientID%>").checked == true) {
                                var chk = "True";
                            }
                            else {
                                var chk = "False";
                            }

                            NewWindow1('../Report/Import_ReportViewerNew.aspx?jobno=' + f + '&IsHdrRepeat=N&OPFormat=HTML&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                            return false
                        }
                    }
                }

                function open_jobnoFontBased() {
                    if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                        document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                        if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {
                            var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                            var ddlReport = document.getElementById("<%=ddlJobNo.ClientID%>");

                            var chk = "True";
                            if (document.getElementById("<%=chk_Stmt.ClientID%>").checked == true) {
                                var chk = "True";
                            }
                            else {
                                var chk = "False";
                            }
                            NewWindow1('../Report/Import_ReportViewerNew.aspx?jobno=' + f + '&IsHdrRepeat=Y&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                            return false
                        }
                    }
                }

                function open_xmlchecklist() {
                    if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                        document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                        if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {
                            var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                            var ddlReport = document.getElementById("<%=ddlJobNo.ClientID%>");

                            var chk = "True";
                            if (document.getElementById("<%=chk_Stmt.ClientID%>").checked == true) {
                                var chk = "True";
                            }
                            else {
                                var chk = "False";
                            }
                            NewWindow1('../Report/Import_ReportViewerNew.aspx?jobno=' + f + '&IsHdrRepeat=N&OPFormat=XML&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                            // NewWindow1('../Report/Import_ReportViewerNewFont.aspx?jobno=' + f + '&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                            return false
                        }
                    }
                }

            </script>
            <script type="text/javascript">

                function open_jobno() {
                    if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                        document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                        if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {
                            var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                            var ddlReport = document.getElementById("<%=ddlJobNo.ClientID%>");

                            var chk = "True";
                            if (document.getElementById("<%=chk_Stmt.ClientID%>").checked == true) {
                                var chk = "True";
                            }
                            else {
                                var chk = "False";
                            }
                            NewWindow1('../Report/Import_ReportViewer.aspx?jobno=' + f + '&jobnops=' + ddlReport.options[ddlReport.selectedIndex].text + '&chk_Stmt=' + chk + '', 'List', '810', '1024', 'yes');
                            return false
                        }
                    }
                }
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
                $(function () {
                    var dropDownList1 = $('#<%= ddlJobNo.ClientID %>');
                    dropDownList1.change(function (e) {
                        var selectedValue = $(this).val();
                        if (selectedValue != '') {
                            document.getElementById('HiddenField1').value = selectedValue;
                        }
                    });
                });

                //----------------------------- Re-generate Checklist- func - here ---------------------------------------------

                function func_Update_CurrentRate(val, btn_id) {

                    if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                        document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;

                        if (document.getElementById("<%=chk_Amend.ClientID%>").checked == true) {
                            var chk_Amend = "True";
                        }
                        else {
                            var chk_Amend = "False";
                        }

                        var f = document.getElementById("<%=HiddenField1.ClientID %>").value;

                        if (val == 'Update_CurrectRate') {
                            if (btn_id == 'btnNewChkList_UpdateRates') {
                                PageMethods.btn_Update_newRates_Checklist(f, open_jobnoNew, CallFailed);
                                MPEU_hide();
                            }
                            else {
                                PageMethods.btn_Update_newRates_Checklist(f, open_jobno, CallFailed);
                                MPEU2_hide();
                            }

                            // $find('details_chklist').hide();
                        }
                        else {
                            MPEU_hide();
                            if (btn_id == 'btnNewChkList_UpdateRates') {
                                MPEU_hide();
                                open_jobnoNew();
                            }
                            else {
                                MPEU2_hide();
                                open_jobno();
                            }
                        }
                    }
                }
                //--------------------------------------------------------------------------------------------------------------

                function CallFailed(res, destCtrl) {
                }
            </script>
            <script type="text/javascript">
                function Job_Mismatched_Data_Delete() {
                    var jobno = document.getElementById("<%=hdn_Jobno.ClientID %>").value;
                    if (jobno != '') {
                        NewWindow1('../Report/IMP_Job_Mismatched_Data_Delete.aspx?Jobno=' + encodeURIComponent(jobno) + '', 'List', '1100', '1024', 'yes');
                    }
                }
            </script>
    </form>
</body>
</html>
