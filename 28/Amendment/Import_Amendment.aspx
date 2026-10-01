<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_Amendment.aspx.cs"
    Inherits="Import_Amendment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Amendment </title>
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
    <%--<script src="../js/Export_Rpt/BL_Generation.js" type="text/javascript"></script>--%>
    <script src="../js/EGM/EGM_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script type="text/javascript" src="../js/Export_Jscript/Export_General.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
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
        .multiselect-container
        {
            max-height: 250px;
            overflow-y: auto;
            height: 250px;
        }
    </style>
    <style type="text/css">
        .txtbox_none_Mid_transac_item_other_rmarks_new1_LC
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            margin-top: 2px;
            width: 385px;
            max-width: 385px;
            height: 350px;
            max-height: 350px;
            border: #c0e4f2 solid thin;
            -moz-border-radius-topleft: 5px;
            -moz-border-radius-topright: 5px;
            -moz-border-radius-bottomleft: 5px;
            -moz-border-radius-bottomright: 5px;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -webkit-border-bottom-right-radius: 5px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            overflow: auto;
        }
    </style>
    <script src="../js/js_bootstrap/jquery.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap-multiselect.js" type="text/javascript"></script>
    <script type="text/javascript">



        $(function () {
            $('[id*=ListBox_Invoice_SlNo]').multiselect({

                includeSelectAllOption: true,
                buttonWidth: '150px' 
            });
        });



        $(function () {
            $('[id*=ListBox1]').multiselect({

                includeSelectAllOption: true,
                buttonWidth: '150px' 
            });
        });

        $(function () {
            $('[id*=ListBox_ItemSlno]').multiselect({

                includeSelectAllOption: true,
                buttonWidth: '150px' 
            });
        });  
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            var icegateid = document.getElementById("hdn_ICEGATE_ID_List").value;
            var Notn = icegateid.split(', ').map(String);

            if (icegateid != '') {
                $('#txt_icegate_Id').autocomplete({
                    source: Notn,
                    minLength: 0,
                    scroll: true
                }).focus(function () {
                    $(this).autocomplete("search", "");
                });
            }
        });
    </script>
    <%-- <script type="text/javascript">

        $(document).ready(function () {
            if ($('#hdn_CompanyID').val() == '5' || $('#hdn_CompanyID').val() == '10' || $('#hdn_CompanyID').val() == '11' || $('#hdn_CompanyID').val() == '747') {
                Bind_icegateID();
            }
        });

        function Bind_icegateID() {
            var Notn = ['COECCSBD', 'BOMCCSBD', 'DELCCSBD'];

            $('#txt_icegate_Id').autocomplete({
                source: Notn,
                minLength: 0,
                scroll: true
            }).focus(function () {
                $(this).autocomplete("search", "");
            });
        }

  </script>--%>
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
            <div id="innerbox_MidMain_Grid">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Import - Amendment Flatfile Generation</div>
                    <asp:Label ID="lblmsg" runat="server" ClientIDMode="Static" ForeColor="Red" Style="float: right;
                        margin: 5px 25px 5px 0px;"></asp:Label>
                    <div id="popupwindow_closebut_right_new">
                        <input type="button" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="tag_srcinner2">
                    <div id="tag_srcinner_lft1">
                        <div id="innerbox_transac_bot_inn" style="width: 820px">
                            <div id="tag_label_transaction_popup_gen">
                                Amendment Type</div>
                            <div id="txtcon_m_src_new_Checklist" style="width: 160px">
                                <asp:DropDownList ID="ddl_AmendType" runat="server" CssClass="listtxt_transac_src1"
                                    Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddl_AmendType_SelectedIndexChanged">
                                    <asp:ListItem Value="A">Amendment</asp:ListItem>
                                    <asp:ListItem Value="S">Supplement</asp:ListItem>
                                    <asp:ListItem Value="D">Deletion</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_gen">
                                Amendment Page</div>
                            <div id="txtcon_m_src_new_Checklist" style="width: 130px">
                                <asp:DropDownList ID="ddl_AmendPage" runat="server" CssClass="listtxt_transac_src1"
                                    Width="120px" AutoPostBack="True" OnSelectedIndexChanged="ddl_AmendPage_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width: 130px;">
                                Amendment Jobno</div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_AmendmentJobno" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    Width="125px" MaxLength="7"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div id="tag_srcinner_lft1">
                        <div id="innerbox_transac_bot_inn" style="width: 820px">
                            <div id="tag_label_transaction_popup_gen">
                                Job No</div>
                            <div id="txtcon-m_transaction_Inv_No">
                                <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="txtbox_none" Width="150px"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                                    <asp:ListItem>Select</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:TextBox ID="txt_jobno_search" runat="server" CssClass="txtbox_none_Mid" Width="150px"
                                        ClientIDMode="Static" MaxLength="40" TabIndex="2" onkeypress="return pin(event)"></asp:TextBox>--%>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                Job Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtJobDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    Enabled="false" MaxLength="10"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtJobDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtJobDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width: 60px;">
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width: 130px;">
                                Customs House
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtCustomsHouse" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    Width="125px" Enabled="false" MaxLength="7" onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div id="tag_srcinner_lft1">
                        <div id="innerbox_transac_bot_inn" style="width: 820px">
                            <div id="tag_label_transaction_popup_gen">
                                <%--Invoice Sr.No--%>
                                <asp:Label ID="lbl_Invoice_Slno" runat="server"></asp:Label>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_det2" style="width: 150px">
                                <%--<asp:DropDownList ID="ddlInvoice_SlNo" runat="server" CssClass="listtxt_transac_src1"
                                    Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlInvoice_SlNo_SelectedIndexChanged">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>--%>

                                <asp:ListBox ID="ListBox_Invoice_SlNo"  SelectionMode="Multiple" Height="28px"
                                    Width="150px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListBox_Invoice_SlNo_SelectedIndexChanged">
                                </asp:ListBox>

                           
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                Item Sr.No
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_det2" style="width: 150px">
                                <%--<asp:DropDownList ID="ddl_ItemSlno" runat="server" CssClass="listtxt_transac_src1"
                            AutoPostBack="True" OnSelectedIndexChanged="ddl_ItemSlno_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>--%>
                                <asp:ListBox ID="ListBox_ItemSlno" Visible="false" SelectionMode="Multiple" Height="28px"
                                    Width="100px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListBox_ItemSlno_SelectedIndexChanged">
                                </asp:ListBox>
                                <asp:TextBox ID="Item_TextBox" CssClass="txtbox_none_Mid_transac_code" Enabled="false"
                                    runat="server"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width: 130px;">
                                <asp:Label ID="lbl_select_item" runat="server" Text="IRN Number"></asp:Label>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                <%--<asp:DropDownList ID="ddl_SelectItems"  runat="server" CssClass="listtxt_transac_src1"
                            Width="150px">
                        </asp:DropDownList>--%>
                                <asp:ListBox ID="ListBox1" Visible="false" SelectionMode="Multiple" Height="28px"
                                    runat="server" Width="155px"></asp:ListBox>
                                <asp:TextBox ID="TextBox1" CssClass="txtbox_none_Mid_transac_code" Enabled="false"
                                    runat="server"></asp:TextBox>
                                <%--<asp:ListBox ID="ListBox1"  SelectionMode="Multiple" runat="server" Width="180px">
                        </asp:ListBox>--%>
                            </div>
                        </div>
                    </div>
                    <%--<div id="pop_text_area_transac_popup_inn_container_left_Checklist">--%>
                    <div id="tag_srcinner_lft1">
                        <div id="innerbox_transac_bot_inn" style="width: 820px">
                            <div id="tag_label_transaction_popup_gen">
                                B.E No
                            </div>
                            <div id="txtcon-m_transaction_Inv_No">
                                <asp:TextBox ID="txtBENo" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    Enabled="false" MaxLength="7" onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                B.E Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtBEDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    Enabled="false" MaxLength="10"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtBEDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtBEDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width: 60px;">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 130px;">
                                Icegate ID
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txt_icegate_Id" runat="server" MaxLength="35" Width="155px" Font-Bold="true"
                                    ForeColor="Red" ClientIDMode="Static" CssClass="validate[required] txtbox_none_CheckList"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div id="tag_srcinner_lft1">
                        <div id="innerbox_transac_bot_inn">
                            <div id="tag_label_transaction_popup_gen">
                                Query No
                            </div>
                            <div id="txtcon-m_transaction_Inv_No">
                                <asp:TextBox ID="txtQueryNo" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    MaxLength="7" onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transact_Src">
                                Query Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtQueryDate" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    MaxLength="10"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtende5" runat="server" TargetControlID="txtQueryDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtQueryDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                            </div>
                        </div>
                    </div>
                    <div id="tag_srcinner_lft1" style="height: 80px;">
                        <div id="innerbox_transac_bot_inn" style="height: 80px;">
                            <div id="tag_label_transaction_popup_gen">
                                Amendment Reason</div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="height: 100px; width: 600px;">
                                <asp:TextBox ID="txtAmendmentReason" runat="server" MaxLength="2000" ClientIDMode="Static"
                                    Height="75px" Width="600px" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                                    TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div id="tag_srcinner_lft1">
                        <div id="IGM_Y_N" runat="server" visible="false">
                            <div id="tag_label_transaction_popup_gen" style="width: 750px">
                                <asp:RadioButtonList ID="rdl_IGM" runat="server" RepeatDirection="Horizontal" Width="450px"
                                    ForeColor="Blue" Font-Bold="true">
                                    <asp:ListItem Value="IGM_Reg" Selected="True">IGM Regularisation (Advance/ Prior BE)   </asp:ListItem>
                                    <asp:ListItem Value="IGM">IGM Details Amendment</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                    </div>
                  
                    <div id="tag_srcinner_lft1">
                        <div id="innerbox_transac_bot_inn" style="margin-top: 5px">
                            <div id="tag_srcinner_rght_Single_line" style="width: 270px">
                                <div id="small-butt-left">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                        TabIndex="27" />
                                </div>
                                <div id="small-butt-left">
                                    <asp:Button ID="btnSearch" CssClass="generate" runat="server" OnClick="btnSearch_Click" />
                                </div>
                                <div id="small-butt-rght">
                                    <a href="#" class="cancelButt" onclick="openurl('../LoginPage/E_royal_Impex_Home.aspx');">
                                    </a>
                                </div>
                            </div>
                            <%--<div id="innerbox_transac_bot_inn">--%>
                            <div id="tag_label_transaction_popup_gen">
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width: 50px">
                                <asp:ImageButton ID="imgbtnFlatFile" runat="server" ImageUrl="~/images/flatfile.jpeg"
                                    Width="27px" Height="30px" OnClientClick="Print_open('Imp_Query_Reply');Loading();"
                                    Visible="False" />
                            </div>
                            <div id="tag_label_transaction_popup_gen">
                                <div id="small-butt-left" style="width: 500px">
                                    <%-- <asp:Button ID="btnSubmission" CssClass="autosubmit_Butt" runat="server" OnClick="btnSubmission_Click"
                            Visible="false" />--%>
                                    <asp:Button ID="btnSendQueue" Style="margin-top: 10px" Text="Send Q" runat="server"
                                        OnClick="btnSendQueue_Click" Visible="false" />
                                    <span style="color: Red; width: 200px">
                                        <asp:Literal ID="lblsent_date" runat="server"></asp:Literal>
                                    </span>
                                    <asp:Button ID="btnSubmission" CssClass="autosubmit_Butt" runat="server" OnClick="btnSubmission_Click"
                                        Visible="false" />
                                </div>
                            </div>
                            <%--</div>--%>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HDBranch" runat="server" />
            <asp:HiddenField ID="hdn_ICEGATE_ID_List" runat="server" ClientIDMode="Static" />
            <script type="text/javascript">

                function open_jobno() {

                    if (document.getElementById('ddlJobNo').value != 'Select') {
                        document.getElementById('HiddenField1').value = document.getElementById('ddlJobNo').value;
                        if (document.getElementById('HiddenField1').value != '') {
                            var f = document.getElementById('HiddenField1').value;
                            opennew_Import_report(f);
                            return false
                            //alert(f);
                        }
                    }

                }

                window.onload = happycode;
                window.onload = happycode1;

                function happycode() {

                    document.getElementById("Import_Id").className = 'smenuactive';
                    document.getElementById("Transaction_Id").click();

                }
                function happycode1() {

                    var qs = query.get('jobno');

                    if (qs.length >= 0) {

                        $('#<%= HiddenField1.ClientID %>').val(qs);
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

                    // call server side method

                    PageMethods.Get_Import_Details(src, CallSuccess_Importer, CallFailed, dest);

                }

                function Loading() {
                    Loading_HideImage();

                }
            </script>
            <script type="text/javascript">
                var win = null;

                function Print_open(Imp_Query_Reply) {
                    win = window.open('../FlatFile/Open_FileDownload.aspx?Query=' + Imp_Query_Reply + '', 'ndf');
                    Loading_HideImage();
                }
                $(function () {

                    var dropDownList1 = $('#<%= ddlJobNo.ClientID %>');
                    var selectedValue = $(dropDownList1).val();

                    if (selectedValue != '') {
                        document.getElementById('HiddenField1').value = selectedValue;
                        //alert(document.getElementById('HiddenField1').value);

                    }
                });



                function CallServerside_Importer(src, dest) {

                    Loading_ShowImage();

                    var ctrl = document.getElementById(src);

                    // call server side method

                    PageMethods.Get_Import_Details(ctrl.value, CallSuccess_Importer, CallFailed, dest);

                }

                // call server side method

                // calling Importer

                // set the destination textbox value with the ContactName
                function CallSuccess_Importer(res, destCtrl) {
                    Loading_HideImage();

                    var dest = document.getElementById(destCtrl);
                    //dest.value = res;
                    var data = res;
                    if (data.indexOf("~~") != -1) {


                        var s = data.split('~~');

                        var before = s[0];
                        var after1 = s[1];
                        var after2 = s[2];
                        var after3 = s[3];
                        var after4 = s[4];
                        var after5 = s[5];


                        document.getElementById("txtCustomHouse").value = before;
                        document.getElementById("txtImporterName").value = after1;
                        document.getElementById("txtBE_Type").value = after2;
                        document.getElementById("txtSupplier").value = after3;
                        document.getElementById("txtNoofItems").value = after4;
                        document.getElementById("txtNoofInvoices").value = after5;
                        var a = "";
                        if (after5 == "")
                            a = 'add Invoice Details';
                        if (after4 == "") {
                            a = a + ' and Item Details';
                        }
                        if (a != "") {
                            document.getElementById("lblmsg").innerHTML = "Please " + a;
                        }
                        else
                            document.getElementById("lblmsg").innerHTML = "";
                    }
                    else {

                        document.getElementById("txtCustomHouse").value = "";
                        document.getElementById("txtImporterName").value = "";
                        document.getElementById("txtBE_Type").value = "";
                        document.getElementById("txtSupplier").value = "";
                        document.getElementById("txtNoofItems").value = "";
                        document.getElementById("txtNoofInvoices").value = "";
                        document.getElementById("lblmsg").innerHTML = "";
                    }
                }

                function CallFailed(res, destCtrl) {
                    //alert(res.get_message());
                }
     
          
    
            </script>
            <script type="text/javascript">
                $(function () {
                    $("#txt_jobno_search").autocomplete({
                        source: function (request, response) {
                            $.ajax({
                                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMPORT_BE_NO_FILLED_JOBNO_SEARCH",
                                data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "'}",
                                dataType: "json",
                                type: "POST",
                                contentType: "application/json; charset=utf-8",
                                dataFilter: function (data) { return data; },
                                async: true,
                                success: function (data) {
                                    response(data.d);
                                    if (data.d == '') {
                                        jQuery('#txt_jobno_search').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                                    }
                                    else {
                                        jQuery('#txt_jobno_search').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                    }
                                },
                                error: function (XMLHttpRequest, textStatus, errorThrown) {
                                    ////alert(textStatus);
                                }
                            });
                        },
                        minLength: 1

                    });
                    return false;
                    scroll: true;
                });
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <%--<script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>--%>
    <%--<script src="../js/Export_Jscript/Export_Goods_Reg_General.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <%--<script type="text/javascript" src="../js/iframepopupwin.js"></script>--%>
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
    <%--<script src="../js/checkboxJScript.js" type="text/javascript"></script>--%>
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
    <%--<script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>--%>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
</body>
</html>
