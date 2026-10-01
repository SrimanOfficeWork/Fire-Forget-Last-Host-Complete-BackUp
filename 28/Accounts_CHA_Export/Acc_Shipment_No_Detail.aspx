<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Shipment_No_Detail.aspx.cs"
    Inherits="Accounts_CHA_Export_Acc_Shipment_No_Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Trans_new" style="width: 700px; height: 330px;">
                <div id="innerbox_MidMain_top_ClientMaster_left2" style="width: 180px; height: 38px;">
                    Shipment Details
                </div>
                <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice" style="width: 700px;
                    height: 20px; margin-left: 10px;">
                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 80px">
                        Shipment No :
                    </div>
                    <div id="txtcon-m_transaction_Inv_No" style="width: 170px; margin-top: 1px; height: 30px;">
                        <asp:TextBox ID="txtShipment_pf" runat="server" CssClass="form-control" Style="width: 40px;
                            height: 20px;"></asp:TextBox>
                        <asp:TextBox ID="txtShipment_No" runat="server" CssClass="form-control" Style="width: 60px;
                            height: 20px;"></asp:TextBox>
                        <asp:TextBox ID="txtShipment_sf" runat="server" CssClass="form-control" Style="width: 40px;
                            height: 20px;"></asp:TextBox>
                    </div>
                    <div id="editbu" style="width: 95px;">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="19" OnClientClick="return validate();" />
                    </div>
                </div>
                <div id="tag_transac_lft_IGM_Invoice_Grid_area" style="width: 700px; height: 220px;
                    margin-top: 20px;">
                    <asp:GridView ID="gv_details" runat="server" DataKeyNames="JOBNO,JOBNO_PS" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                        ShowHeaderWhenEmpty="True" PageSize="200" AllowPaging="True" AllowSorting="True"
                        OnSorting="gvdetails_Sorting" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:TemplateField HeaderStyle-Width="44px" HeaderText="S.No">
                                <ItemTemplate>
                                    <asp:Label ID="lblitemslno" runat="server" Text="<%# Container.DataItemIndex + 1 %>"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="44px" />
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" CssClass="chkSelect" AutoPostBack="false"
                                        OnClientClick="return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="JOBNO" HeaderText="Job No" SortExpression="JOBNO">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="JOBNO_PS" HeaderText="JobNo Ps" SortExpression="JOBNO_PS">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div style="display: none;">
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="hfdport_code_origin" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hfdport_code_dest" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                <asp:HiddenField ID="hdn_Update_General" runat="server" />
                <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                <asp:HiddenField ID="hdnImportAirJobLinked" runat="server" />
                <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                <asp:HiddenField ID="hdn_bio_Id" runat="server" />
                <asp:HiddenField ID="hdn_update_Bond" runat="server" />
                <asp:HiddenField ID="hdn_Jobno" runat="server" />
                <asp:HiddenField ID="Hdn_CGHS" runat="server" />
                <asp:HiddenField ID="Hidden_value_Col" runat="server" />
                <asp:HiddenField ID="Hidden_value_Pre" runat="server" />
                <asp:HiddenField ID="HiddenField_index" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/Accounts/Imp_Exp_Invoice_Tab.js"></script>
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
    </form>
    <script type="text/javascript">
        window.onbeforeunload = function () {
            if (window.opener && !window.opener.closed) {
                window.opener.document.getElementById("Button1").click();
            }
        };
    </script>
</body>
</html>
