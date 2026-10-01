<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_TDS_receivable.aspx.cs"
    Inherits="Acc_TDS_receivable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title></title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
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
        
        
        .radio-spacing input[type='radio']
        {
            margin-right: 10px;
        }
        .chosen-container
        {
            margin-left: 51px;
        }
        .cls_cls_center
        {
            line-height: 1.5em;
            border-left: #c8c8c8 solid thin;
            padding-left: 18px;
            text-align: center;
            padding-right: 18px;
        }
        .cls_cls_right
        {
            line-height: 1.5em;
            border-left: #c8c8c8 solid thin;
            padding-left: 18px;
            text-align: right;
            padding-right: 18px;
        }
        .grid-view th a
        {
            text-decoration: none;
            color: #000000;
            cursor: pointer;
        }
        .sort-icon
        {
            margin-left: 4px;
            font-size: 10px;
            font-weight: bold;
            vertical-align: middle;
            line-height: 1;
        }
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 1092px;
                height: 400px; background-color: #FFFFFF; margin-top: -2px;">
                <div id="tag_transac_lft_Inv_in1" style="height: 390px; width: 1092px;">
                    <div id="innerbox_MidMain" style="height: 105px; width: 1092px;">
                        <div id="tag_srcinner1">
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 190px;">
                                TDS Receivable
                            </div>
                            <div id="verslic">
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px;">
                                <a href="#" id="btnex" runat="server" style="display: block; width: 50px; height: 30px;
                                    margin-top: -6px; background-image: url('../images/xls.jpg'); background-repeat: no-repeat;"
                                    onserverclick="btnexcel_Click" tabindex="7"></a>
                            </div>
                            <div id="verslic">
                            </div>
                            <div id="tag_label_transact_Src" style="width: 65px; margin-top: 5px">
                                Branch
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 230px; margin-top: 4px; position: absolute;
                                margin-left: 345px;">
                                <asp:DropDownList ID="ddlgroup_Name" class="chosen-select-deselect" Style="width: 225px;"
                                    data-placeholder="Choose a Branch" runat="server" TabIndex="1">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transact_src_inner" style="width: 912px; height: 67px;">
                            <div id="tag_transact_lft_in1" style="width: 900px; height: 25px; margin-top: 2px;
                                margin-left: 9px">
                                <div id="Hide_Party" runat="server">
                                    <div id="tag_label_transact_Src" style="width: 150px; margin-left: 9px; margin-top: 5px">
                                        Organization Name
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 320px; position: absolute; margin-left: 73px;
                                        margin-top: 5px">
                                        <asp:DropDownList ID="ddlpartyname" runat="server" class="chosen-select-deselect"
                                            Style="width: 430px;" data-placeholder="Choose a Party Name" ClientIDMode="Static"
                                            TabIndex="2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div id="tag_transact_lft_in1" style="width: 712px; height: 25px; margin-top: 10px;
                                margin-left: 9px">
                                <div id="tag_label_Clientname" style="width: 37px; margin-left: 9px;">
                                    Type
                                </div>
                                <div id="txtcon-m_src" style="width: 100px">
                                    <asp:DropDownList ID="ddlType" CssClass="listtxt_transac_mode_new" Width="100px"
                                        TabIndex="3" runat="server">
                                        <asp:ListItem Value="Detail" Text="Detail" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="Summary" Text="Summary"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 76px; margin-top: 3px; margin-left: 10px;">
                                    From Date</div>
                                <div id="txtcon-m_transaction_code" style="width: 110px">
                                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="4"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transact_Src" style="width: 50px; margin-top: 3px">
                                    To Date
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px">
                                    <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="5"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 50px; margin-top: 3px">
                                    Month</div>
                                <div id="txtcon-m_transaction_code" style="width: 130px">
                                    <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none" Font-Size="12px"
                                        Width="130px" TabIndex="6">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="tag_transact_srcinner_rght" style="margin-top: 8px">
                                <div id="small-butt-left">
                                    <a href="#" class="srcbu" id="btnSearch" runat="server" onclick="return validdate();"
                                        onserverclick="btnSearch_Click" tabindex="7"></a>
                                </div>
                                <div id="small-butt-rght">
                                    <a href="#" onclick="window.close()" class="cancelButt" tabindex="8"></a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Grid" style="height: 460px; margin-top: -13px; width: 1092px;">
                        <div class="pagination" id="Div_Pagination" runat="server" style="margin-bottom: 8px;">
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Page No.</div>
                            <div id="txtcon-m_transaction_list1_fcl">
                                <asp:DropDownList ID="ddlSelectPageno" runat="server" AutoPostBack="true" CssClass="listtxt_transac_FCL"
                                    OnSelectedIndexChanged="ddlSelectPageno_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <span class="disabled">
                                <asp:LinkButton CommandName="First" ID="btnFirst" runat="server" OnCommand="ChangePage">« First</asp:LinkButton></span>
                            <span class="disabled">
                                <asp:LinkButton CommandName="Previous" ID="btnPrev" runat="server" OnCommand="ChangePage">« Previous</asp:LinkButton></span>
                            <span class="selected">Page
                                <asp:Label ID="lblTotalPages" runat="server" Visible="false"></asp:Label>-
                                <asp:Label ID="lblCurrentPage" runat="server"></asp:Label>
                            </span><span class="disabled">
                                <asp:LinkButton CommandName="Next" ID="btnNext" runat="server" OnCommand="ChangePage">Next</asp:LinkButton></span>
                            <span class="disabled">
                                <asp:LinkButton CommandName="Last" ID="btnLast" runat="server" OnCommand="ChangePage">Last</asp:LinkButton>
                            </span>
                        </div>
                        <div runat="server" id="div_pagination1" visible="false">
                            <br />
                            <br />
                        </div>
                        <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                            CssClass="grid-view" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gvdetails_RowCreated"
                            OnRowDataBound="gvdetails_RowDataBound" DataKeyNames="ID,IMP_EXP,BILL_NO" PageSize="20"
                            AllowSorting="true" ShowFooter="true" CellPadding="1" CellSpacing="1" OnSorting="gvdetails_Sorting">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                CssClass="column_style_left" BorderWidth="1px" />
                            <HeaderStyle Font-Underline="false" ForeColor="Black" />
                            <FooterStyle Font-Bold="true" BackColor="#66FF99" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle Width="45px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="OrganizationName" HeaderText="Organization Name" HeaderStyle-Width="210"
                                    SortExpression="OrganizationName">
                                    <HeaderStyle Width="210px" />
                                    <ItemStyle CssClass="column_style_left" Width="210" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Bill No">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkOrg" runat="server" Text='<%# Eval("BILL_NO") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle CssClass="column_style_left" Width="150px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="BILL_DATE" HeaderText="Bill Date" HeaderStyle-Width="100px"
                                    DataFormatString="{0:dd/MM/yyyy}">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle CssClass="cls_cls_center" Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TDS_AMT" HeaderText="TDS Amount" HeaderStyle-Width="100">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle CssClass="column_style_left" Width="100" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/Accounts/Imp_Exp_Invoice_Tab.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
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

        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function Open_Sales_entry(val1, val2, val3) {
            w = '1200';
            h = '585';
            LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            TopPosition = (screen.height) ? (screen.height - h) / 60 : 0;
            settings = 'width=' + w + ',height=' + h + ',top=' + TopPosition + ',left=' + LeftPosition + ',resize=0, scrolling=0';
            window.open('../Accounts_Sales/GST_Sales_Entry.aspx?Page=' + val1 + '&IMP_EXP=' + val2 + '&Billinvno=' + escape(val3) + '', '', settings)
        }
       
    </script>
</body>
</html>
