<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Journal_Entry_Details.aspx.cs" Inherits="Acc_Journal_Entry_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Journal Entry Details</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style type="text/css">
        .grid-view
        {
            border-collapse: collapse;
            width: 100%;
            font-size: 12px;
        }
        
        .grid-view th
        {
            background: #F7BC70;
            color: White;
            border: 1px solid #C8C8C8;
            padding: 5px;
            text-align: center;
        }
        .grid-view td
        {
            border: 1px solid #C8C8C8;
            padding: 4px;
            vertical-align: middle;
        }
        
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
        div.fileinputs
        {
            position: relative;
        }
        div.fakefile
        {
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 1;
        }
        input.file
        {
            position: relative;
            text-align: right;
            -moz-opacity: 0;
            filter: alpha(opacity:0);
            opacity: 0;
            z-index: 2;
        }
        .chosen-upward + .chosen-container .chosen-drop
        {
            top: auto !important;
            bottom: 100% !important;
            display: flex;
            flex-direction: column-reverse;
        }
        .chosen-upward + .chosen-container .chosen-search
        {
            margin-top: 5px;
            margin-bottom: 0;
        }
        
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        .btn-add-circle
        {
            display: inline-block;
            color: #28A745; /* Green */
            font-size: 22px;
            font-weight: bold;
            cursor: pointer;
            border: none;
            padding: 0;
            text-decoration: none;
            background: none;
            vertical-align: middle;
        }
        .btn-add-circle:hover
        {
            color: #1E7E34;
            text-decoration: none;
            background: none;
        }
        .btn-del-circle
        {
            display: inline-block;
            color: #DC3545;
            font-size: 22px;
            font-weight: bold;
            cursor: pointer;
            border: none;
            padding: 0;
            text-decoration: none;
            background: none;
            vertical-align: middle;
        }
        .btn-del-circle:hover
        {
            color: #C82333;
            text-decoration: none;
            background: none;
        }
        
        .grid-view thead th, .grid-view tr:first-child th
        {
            position: sticky;
            top: 0;
            z-index: 5;
            background: #F7BC70;
        }
        
        .chosen-container
        {
            overflow: visible !important;
            position: relative !important;
        }
        .chosen-container .chosen-drop
        {
            position: absolute !important;
            z-index: 999999 !important;
        }
        input[readonly]
        {
            background-color: #f0f0f0;
            color: #555;
            cursor: not-allowed;
        }
        #form1
        {
            display: flex;
            flex-direction: column;
            flex: 1;
            min-height: 0;
        }
    </style>
</head>
<body style="height: 100vh; overflow: hidden; display: flex; flex-direction: column;
    margin: 0;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="loading" align="center" id="load" style="display: none;">
        <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
    </div>
    <div id="innerbox_MidMain_Billing" style="height: 229px; margin: 0 9px;">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                Detail Entry
            </div>
            <div id="tag_label_transact_Src" style="width: 90px; margin-top: 5px;">
                Trans. No
            </div>
            <div id="txtcon-m_Exchange" style="width: 600px; margin-top: 5px;">
                <asp:TextBox ID="txt_JV_No_F" runat="server" ReadOnly="true" BackColor="#e7e6e6"
                    Width="35px" Height="19px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                <asp:TextBox ID="txt_JV_No_M" runat="server" ReadOnly="true" BackColor="#e7e6e6"
                    Style="text-align: right;" Width="60px" Height="19px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                <asp:TextBox ID="txt_JV_No_L" runat="server" ReadOnly="true" BackColor="#e7e6e6"
                    Width="60px" Height="19px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
            </div>
            <div id="popupwindow_closebut_right_new">
            </div>
        </div>
        <div id="tag_transact_src_inner" style="width: 1200px; position: relative;">
            <div style="width: 1200px; height: 27px">
                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 25px; margin-left: -5px;">
                    <div id="tag_label_transact_Src" style="width: 90px;">
                        Charge / GL
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 600px;">
                        <asp:DropDownList ID="ddlImp_Exp" runat="server" class="chosen-select-deselect" Style="width: 130px;"
                            AutoPostBack="true" OnSelectedIndexChanged="ddlImp_Exp_SelectedIndexChanged"
                            data-placeholder="charge GL Type" TabIndex="1">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="G/L" Value="GL"></asp:ListItem>
                            <asp:ListItem Text="CCL IMP" Value="CI"></asp:ListItem>
                            <asp:ListItem Text="CCL EXP" Value="CE"></asp:ListItem>
                            <asp:ListItem Text="GEN" Value="GE"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddl_Charge_GL" runat="server" class="chosen-select-deselect"
                            Style="width: 425px;" AutoPostBack="true" OnSelectedIndexChanged="ddl_Charge_GL_SelectedIndexChanged"
                            data-placeholder="Choose a Charge Name" TabIndex="2">
                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 25px; margin-left: -5px;">
                    <div id="tag_label_transact_Src" style="width: 90px;">
                        Amount
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 600px;">
                        <asp:TextBox ID="txt_GL_Amount" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                            Style="text-align: right; border-radius: 1px;" onkeypress="return isNumberKey(event)"
                            Width="390px" TabIndex="3" runat="server"></asp:TextBox>
                        <asp:DropDownList ID="ddl_Cr_Dr" runat="server" class="chosen-select-deselect" Style="width: 160px;
                            border-radius: 2px;" TabIndex="4" OnSelectedIndexChanged="ddl_Cr_Dr_SelectedIndexChanged"
                            AutoPostBack="true" data-placeholder="Select DEBIT/CREDIT">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="DR" Value="D"></asp:ListItem>
                            <asp:ListItem Text="CR" Value="C"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 25px; margin-left: -5px;">
                    <div id="tag_label_transact_Src" style="width: 90px;">
                        Linked GL
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 600px;">
                        <asp:DropDownList ID="ddl_linked_GL" runat="server" class="chosen-select-deselect"
                            Style="width: 560px;" data-placeholder="Choose a GL Name" TabIndex="5">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 25px; margin-left: -5px;">
                    <div id="tag_label_transact_Src" style="width: 90px;">
                        Cost Center
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 600px;">
                        <asp:DropDownList ID="ddl_Cost_Center" runat="server" class="chosen-select-deselect"
                            AutoPostBack="true" OnSelectedIndexChanged="ddl_Cost_Center_SelectedIndexChanged"
                            Style="width: 560px;" data-placeholder="Choose a Cost Center Name" TabIndex="6">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                            <asp:ListItem Text="Import" Value="I"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 25px; margin-left: -5px;">
                    <div id="tag_label_transact_Src" style="width: 90px;">
                        Acc.Branch
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 600px;">
                        <asp:DropDownList ID="ddl_branch" runat="server" class="chosen-select-deselect" Style="width: 560px;"
                            data-placeholder="Choose a Acc Branch Name" TabIndex="7">                            
                            <asp:ListItem Text="Chennai" Value="Chennai"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 25px; margin-left: -5px;">
                    <div id="tag_label_transact_Src" style="width: 90px;">
                        Tax
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 600px;">
                        <asp:DropDownList ID="ddl_tax" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_tax_SelectedIndexChanged"
                            CssClass="chosen-select-deselect" Style="width: 390px;" TabIndex="8">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="Taxable" Value="T"></asp:ListItem>
                            <asp:ListItem Text="Exempt" Value="NT"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddl_tax_type" runat="server" CssClass="chosen-select-deselect"
                            Style="width: 165px;" TabIndex="9">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="position: absolute; left: 700px; top: 99px; width: 420px;">
                    <div style="font-weight: bold; font-size: 12px; color: #333; margin-bottom: 5px;">
                        Narration
                    </div>
                    <asp:TextBox ID="txtNarration" runat="server" TextMode="MultiLine" Width="370px"
                        TabIndex="10" Height="49px" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                        Style="font-family: Arial, Helvetica, sans-serif; border: 1px solid #c8c8c8;
                        border-radius: 3px; background-color: #fafafa;">
                    </asp:TextBox>
                </div>
            </div>
        </div>
    </div>
    <%-- -------------------------------------Tab--------------------------------------------------------%>
    <div class="content" id="page-1" style="flex: 1; min-height: 0; display: flex; flex-direction: column;
        margin-left: -5px;">
        <div id="pop_text_area_transac_popup_inn_container_new" style="flex: 1; min-height: 0; display: flex; flex-direction: column; width: 1250px;">
            <div style="width: 100%; height: 33px; background: #F7BC70; display: flex; align-items: center; justify-content: space-between; padding: 0 10px; box-sizing: border-box;">
                <div style="color: Black; font-weight: bold; font-size: 17px;">
                    JOB Bifurcation
                </div>
                <div id="innerbox_MidMain_bot_transact" runat="server" style="width: auto;">
                    <div id="innerbox_transac_bot_inn" style="width: auto;">
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                OnClick="btnSave_Click" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" Visible="false" OnClick="btnUpdate_Click"
                                OnClientClick="return validation();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" CssClass="dlete" Visible="false" />
                        </div>
                    </div>
                </div>
                <div style="display: flex; align-items: center; gap: 15px;">
                    <div style="color: Black; font-size: 17px; font-weight: bold; white-space: nowrap;">
                        Total Invoice Amount :
                        <asp:Label ID="lblTotal" runat="server" Text="0.00" Visible="false"></asp:Label>
                        &#8377;
                        <asp:TextBox ID="txtTotal" runat="server" ReadOnly="true" Text="0.00" Style="width: 90px;
                            border: none; background: transparent; color: blue; font-size: 17px; font-weight: bold;
                            text-align: right;">
                        </asp:TextBox>
                    </div>
                </div>
            </div>
            <%--<div style="width: 100%; height: 300px; overflow-x: auto; overflow-y: visible; margin-top: 3px; border: 1px solid #C8C8C8; position: relative;">--%>
            <div style="flex: 1; min-height: 0; overflow-x: auto; overflow-y: auto; margin-top: 3px;
                border: 1px solid #C8C8C8; position: relative;">
                <asp:GridView ID="gv_details" runat="server" AutoGenerateColumns="False" Width="100%"
                    ShowFooter="True" GridLines="Both" BorderWidth="1px" BorderStyle="Solid" BorderColor="#C8C8C8"
                    ShowHeaderWhenEmpty="true" CellPadding="4" CellSpacing="0" ShowHeader="True"
                    CssClass="grid-view" DataKeyNames="JOB_NO" OnRowDataBound="gv_details_RowDataBound"
                    OnRowCommand="gv_details_RowCommand">
                    <AlternatingRowStyle BackColor="#F7F7F7" />
                    <Columns>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="30px">
                            <HeaderTemplate>
                                <asp:LinkButton ID="lnkAddHeaderRow" runat="server" Text="+" CssClass="btn-add-circle"
                                    CommandName="AddRow" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDelete" runat="server" Text="&#8722;" CssClass="btn-del-circle"
                                    CommandName="DeleteRow" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:LinkButton ID="lnkAddFooterRow" runat="server" Text="+" CssClass="btn-add-circle"
                                    CommandName="AddRow" />
                            </FooterTemplate>
                            <ItemStyle Width="30px" HorizontalAlign="Center" />
                            <FooterStyle Width="30px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="" HeaderStyle-Width="90px">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_Job_Imp_Exp" runat="server" Width="90px" AutoPostBack="true"
                                    SelectedValue='<%# Bind("CHARGE_GL") %>' OnSelectedIndexChanged="ddl_Job_Imp_Exp_SelectedIndexChanged">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="CCL IMP" Value="CI"></asp:ListItem>
                                    <asp:ListItem Text="CCL EXP" Value="CE"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ref. No" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Black"
                            HeaderStyle-Width="210px">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_Jobno" MaxLength="20" runat="server" onblur="Calculation_Rate(this)"                               
                                    Width="207px" Height="20px" Font-Size="12px" CssClass="txtbox_trans_exp_drawback">
                                </asp:DropDownList>
                                <asp:HiddenField ID="hfCustomerId" runat="server" />
                            </ItemTemplate>
                            <ItemStyle Width="210px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Estimated" HeaderStyle-ForeColor="Black" HeaderStyle-Width="100px">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlEstimated" runat="server" Width="100px" CssClass="chosen-select-deselect">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="95px"
                            HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:TextBox ID="txtInvoiceAmount" CssClass="underlined" Text='<%# Bind("INVOICE_AMOUNT") %>'
                                    onblur="extractNumber(this,3,false);"
                                    onkeyup="extractNumber(this,3,false); return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"

                                    Height="20px" Width="95px" runat="server" Style="text-align: right"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="95px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount(INR)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="95px"
                            HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:TextBox ID="txtAmount" CssClass="underlined" Text='<%# Bind("AMOUNT") %>' 
                                    onblur="extractNumber(this,3,false); validateAndCalc(this);"
                                    onkeyup="extractNumber(this,3,false); validateAndCalc(this); return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false); validateAndCalc(this);"
                                    Height="20px" Width="95px" runat="server" Style="text-align: right"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="95px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Dr/Cr" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px"
                            HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:DropDownList ID="txtDrCr" CssClass="underlined" Text='<%# Bind("DR_CR") %>'
                                    Height="20px" Width="50px" Font-Size="12px" runat="server" Style="text-align: right">
                                    <asp:ListItem Text="DR" Value="D"></asp:ListItem>
                                    <asp:ListItem Text="CR" Value="C"></asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Apportion Method" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px"
                            HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                <asp:TextBox ID="txtApportionmethod" CssClass="underlined" Text='<%# Bind("APPORTION_METHOD") %>'
                                    Height="20px" Width="100px" Font-Size="12px" runat="server" Style="text-align: right"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Cost Center" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px"
                            HeaderStyle-ForeColor="Black">
                            <ItemTemplate>
                                    <asp:DropDownList ID="ddl_Cost_center"  CssClass="underlined" Text='<%# Bind("COST_CENTER") %>' Height="20px" Width="100px" 
                                            Font-Size="12px" runat="server" Style="text-align: right">                                                                        
                                    <asp:ListItem Text="None" Value="N"></asp:ListItem>
                                    <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                                    <asp:ListItem Text="Import" Value="I"></asp:ListItem>
                                    
                                </asp:DropDownList>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div style="display: none;">
        <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
        <asp:HiddenField ID="HiddenGstn" runat="server" />
        <asp:HiddenField ID="hdntotal" runat="server" />
        <asp:HiddenField ID="HiddenField_index" runat="server" />
        <asp:HiddenField ID="HiddenField_ImportJobNo" runat="server" />
        <asp:HiddenField ID="Hdn_amt_inr" runat="server" />
        <asp:HiddenField ID="hdn_TaxValue" runat="server" />
        <asp:HiddenField ID="Hdn_id" runat="server" />
        <asp:HiddenField ID="HDupdate_id" runat="server" />
        <asp:HiddenField ID="Hd_row_id" runat="server" />
    </div>
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onbeforeunload = function () {
            if (window.opener && !window.opener.closed) {
                window.opener.document.getElementById("btnLedgerDetails").click();
            }
        };
    </script>
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

        function isNumberKey(evt) {
            var charCode = evt.which ? evt.which : evt.keyCode;
            if (charCode == 46) // decimal point
                return true;

            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }

        function formatDecimal(el) {
            var val = el.value.trim();
            if (val === '') return;
            var num = parseFloat(val);
            if (!isNaN(num)) {
                el.value = num.toFixed(3);
            }
        }

        //window.onload = function () {        };

        function validateAndCalc(src) {
            var amountInputs = document.querySelectorAll("input[id*='txtAmount']");
            var invoiceInputs = document.querySelectorAll("input[id*='txtInvoiceAmount']");

            var rowIndex = Array.prototype.indexOf.call(amountInputs, src);

            if (rowIndex >= 0) {
                var amtVal = parseFloat(src.value) || 0;
                var invVal = parseFloat(invoiceInputs[rowIndex] ? invoiceInputs[rowIndex].value : 0) || 0;

                if (invVal > 0 && amtVal > invVal) {
                    jAlert("Row " + (rowIndex + 1) + ": Amount(INR) cannot be greater than Invoice Amount (" + invVal.toFixed(2) + ")");
                    src.value = "";
                    src.focus();
                    return;
                }
            }
            calcTotal();
        }

        function calcTotal() {
            var amountInputs = document.querySelectorAll("input[id*='txtAmount']");
            var invoiceInputs = document.querySelectorAll("input[id*='txtInvoiceAmount']");
            var total = 0.00;
            for (var i = 0; i < amountInputs.length; i++) {
                var amtVal = parseFloat(amountInputs[i].value) || 0;
                var invVal = parseFloat(invoiceInputs[i] ? invoiceInputs[i].value : 0) || 0;

                if (amtVal > invVal) {
                    jAlert("Amount(INR) cannot be greater than Invoice Amount in row " + (i + 1));
                    amountInputs[i].value = invVal.toFixed(2); // reset to invoice amount
                    amountInputs[i].focus();
                    return;
                }
                total += amtVal;
            }
            var lbl = document.querySelector("span[id*='lblTotal']");
            if (lbl) lbl.innerHTML = total.toFixed(2);
            var txt = document.querySelector("input[id*='txtTotal']");
            if (txt) txt.value = total.toFixed(2);
            var hdn = document.getElementById('hdntotal');
            if (hdn) hdn.value = total.toFixed(2);
        }

        window.addEventListener('load', function () {
            calcTotal();
        });
    </script>
    <script type="text/javascript">
        function JobImpExpChanged(ctrl) {

            var value = document.getElementById('<%= ddlImp_Exp.ClientID %>').value;

            if (value === "GL") {
                var row = lnk.parentNode.parentNode;
                var ddl_imp_exp_type = row.querySelector("[id*=ddl_Job_Imp_Exp]");
                var rowIndex = row.rowIndex;

                $('#Hd_row_id').val(rowIndex);
                PageMethods.getCha_JobNumbers(ddl_imp_exp_type.value, CallSuccess_Rate, CallFailed, dest);
            }

            function CallSuccess_Rate(res, destCtrl) {
            }

            function CallFailed(res, destCtrl) {
            }


            var selectedValue = ctrl.value;
            var selectedText = ctrl.options[ctrl.selectedIndex].text;

            alert("Value : " + selectedValue);

            PageMethods.SaveJobImpExp(selectedValue, function (result) { alert(result); },
        function (err) {
            alert(err.get_message());
        });
        }
    </script>
     <script type="text/javascript">
    function getJVNo() {
    var jvNo =
        document.getElementById('<%= txt_JV_No_F.ClientID %>').value + 
        document.getElementById('<%= txt_JV_No_M.ClientID %>').value + 
        document.getElementById('<%= txt_JV_No_L.ClientID %>').value;

    return jvNo;
}
  </script>

    <script type="text/javascript">
        function Calculation_Rate(lnk) {
            var row = lnk.parentNode.parentNode;
            var ddl_imp_exp = row.querySelector("[id*=ddl_Job_Imp_Exp]");
            var ddl = row.querySelector("[id*=ddl_Jobno]");
            
            var dctype = row.querySelector("[id*=txtDrCr]");
            var dctypeVal = dctype.value;
            var selectedValue = ddl.value;                             // JOBNO
            var selectedText = ddl.options[ddl.selectedIndex].text;   // JOBNO_PS
             
            var rowIndex = row.rowIndex;
            $('#Hd_row_id').val(rowIndex);

            var fullJVNo = getJVNo();

            var ddlChargeGL = document.getElementById('<%= ddl_Charge_GL.ClientID %>');
            var chargeCode = ddlChargeGL.value;
            var chargeName = ddlChargeGL.options[ddlChargeGL.selectedIndex].text;
            
            if (ddl) {
                Cha_Sales_InvAmt(selectedValue, selectedText, ddl_imp_exp.value, chargeName, chargeCode, dctypeVal, fullJVNo);
            }
        }  
    </script>
    <script type="text/javascript"> 
        function Cha_Sales_InvAmt(src, dest, impExp, chargeName, chargeCode, dctypeVal, fullJVNo)
        {
            console.log(5);
            //PageMethods.Get_Cha_Sales_InvAmt(src, dest, impExp, chargeName, chargeCode, dctypeVal, fullJVNo, CallSuccess_Rate, CallFailed, dest)

            console.log(src, dest, impExp, chargeName, chargeCode, dctypeVal, fullJVNo);

            PageMethods.Get_Cha_Sales_InvAmt(src, dest, impExp,chargeName, chargeCode, dctypeVal, fullJVNo, CallSuccess_Rate,  CallFailed );
        }

        function CallSuccess_Rate(res, destCtrl) {

            var ID = parseInt($('#Hd_row_id').val());
            var txtInvoiceAmount = document.querySelectorAll("input[id*='txtInvoiceAmount']");
            var txtAmount = document.querySelectorAll("input[id*='txtAmount']");
                        
            var impExp = document.getElementById('<%= ddlImp_Exp.ClientID %>').value;      // to check if its GL or NOT
            var data = res;
            if (data.indexOf("~") != -1) {

                var s = data.split('~');
                txtInvoiceAmount[ID - 1].value = s[0];
                txtAmount[ID - 1].value = s[1];

                if (impExp === "GL") {                    
                    txtInvoiceAmount[ID - 1].disabled = false;
                    txtInvoiceAmount[ID - 1].readOnly = false;
                    txtInvoiceAmount[ID - 1].removeAttribute("readonly");
                }
                else {                    
                    txtInvoiceAmount[ID - 1].readOnly = true;
                }
            }
            calcTotal();
        }
        function CallFailed(res, destCtrl) {
        }
    </script>
    <script type="text/javascript">
        function validate() {
            var ddlChargeGL = document.getElementById('<%= ddl_Charge_GL.ClientID %>');
            var txtAmount = document.getElementById('<%= txt_GL_Amount.ClientID %>');
            var ddlCrDr = document.getElementById('<%= ddl_Cr_Dr.ClientID %>');
            var ddlBranch = document.getElementById('<%= ddl_branch.ClientID %>');
            var ddlTax = document.getElementById('<%= ddl_tax.ClientID %>');
            var ddlTaxType = document.getElementById('<%= ddl_tax_type.ClientID %>');
            
            if (ddlChargeGL.value == "") {
                jAlert("Please Select Charge / GL Type");
                ddlChargeGL.focus();
                return false;
            }

            if (txtAmount.value.trim() == "") {
                jAlert("Please Enter Amount");
                txtAmount.focus();
                return false;
            }

            if (parseFloat(txtAmount.value) <= 0) {
                jAlert("Amount must be greater than zero");
                txtAmount.focus();
                return false;
            }

            if (ddlCrDr.value == "") {
                jAlert("Please select DR / CR");
                ddlCrDr.focus();
                return false;
            }

            if (ddlBranch.value == "") {
                jAlert("Please select Branch");
                ddlBranch.focus();
                return false;
            }

            if (ddlTax.value == "") {
                jAlert("Please select Tax Type");
                ddlTax.focus();
                return false;
            }

            if (ddlTaxType.value == "") {
                jAlert("Please select Tax Value");
                ddlTaxType.focus();
                return false;
            }

            var jobs = document.querySelectorAll("[id*='ddl_Jobno']");
            var hasData = false;

            for (var i = 0; i < jobs.length; i++) {
                if (jobs[i].value != "") {
                    hasData = true;
                    break;
                }
            }
            if (!hasData) {
                jAlert("Please add at least one detail record.");
                return false;
            }

            return true;
        }
    </script>
</body>
</html>
