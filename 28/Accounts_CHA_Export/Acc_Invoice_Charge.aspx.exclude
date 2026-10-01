<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Invoice_Charge.aspx.cs"
    Inherits="Export_Acc_Invoice_Charge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
        
        .ui-dialog-buttonpane {
    padding: 10px; /* Adjust padding as needed */
    font-size: 12px; /* Decrease font size */
    /* You can also set a specific width or height */
    width: 100%; /* Adjust width */
    /* Add other styles to customize appearance */
}
        
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnUpdate,#btnSave').click(function () {

                var Gross_Weight = document.getElementById("txtGross_Weight").value;
                var Net_Weight = document.getElementById("txtNet_Weight").value;

                if (parseFloat(Net_Weight) > parseFloat(Gross_Weight)) {
                    alert("Net Weight is Greater than Gross Weight...");
                    return false;
                }

            });
        });
    </script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
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
            <div id="pop_text_area_transac_popup_inn_container_left_export_new2" style="width: 990px;
                height: 390px; background-color: #FFFFFF; margin-top: -5px;">
                <div id="tag_transac_lft_Inv_in1" style="height: 110px; width: 1000px;">
                    <div id="pop_text_area_transac_popup_inn_container_new" style="height: 115px; width: 990px;">
                        <div id="tag_transac_lft_Inv_in1" style="width: 990px; height: 35px; margin-top: 45px;">
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 55px">
                                Inv Nos :
                            </div>
                            <div id="txtcon-m_transaction_Inv_No" style="width: 170px">
                                <asp:Label ID="LBL_InvoiceNo" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            <div id="txtcon-m_transaction_Inv_No" style="width: 150px; display: none;">
                                <asp:TextBox ID="txtInvoiceNo" runat="server" Font-Bold="true" MaxLength="17" Width="90px"
                                    onblur="extractNumber(this,2,false);" CssClass="txtbox_none_Mid_transac_Inv_No"
                                    TabIndex="108"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 130px; margin-left: -6px;">
                                <asp:RadioButtonList ID="Rdb_reg_cess" runat="server" RepeatDirection="Horizontal"
                                    TabIndex="2">
                                    <asp:ListItem Text="Reg" Value="R" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Sez" Value="S"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                Transport Bill
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice" style="width: 110px; margin-left: -6px;">
                                <asp:RadioButtonList ID="Rdb_Transport_Bill" runat="server" RepeatDirection="Horizontal"
                                    TabIndex="3">
                                    <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width: 10px">
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date" style="width: 80px;">
                                Grand Total :
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 130px">
                                <asp:Label ID="txtgrand_tot" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 180px;">
                                <asp:RadioButtonList ID="Rd_Job_Status" runat="server" RepeatDirection="Horizontal"
                                    TabIndex="93">
                                    <asp:ListItem Text="Pending" Value="P" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Completed" Value="C"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Inv_in1" style="width: 990px; height: 46px;">
                            <span id="Bill_Admin" runat="server" visible="false">
                                <div id="tag_label_transact_Src" style="width: 40px">
                                    Invoice
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 230px;">
                                    <asp:RadioButtonList ID="Rd_Inv_Status" runat="server" TabIndex="94" RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="Rd_Inv_Status_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Text="Unapproval" Value="UA" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Approved" Value="A"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </span>
                        </div>
                    </div>
                </div>
                <div id="tag_transac_lft_Inv_in1" style="width: 460px; height: 45px;">
                    <div id="editbu" style="margin-top: 5px">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            TabIndex="20" OnClientClick="return validate_Export_AnnexureC1_Air_Details();" />
                    </div>
                    <div id="editbu" style="padding-top: 5px; width: 80px;">
                        <asp:Button ID="btnrpt" runat="server" TabIndex="125" Text="Get Bill" OnClientClick="return GST_Billing_Job_Rpt('B');"
                            Height="30px" Width="70px" />
                    </div>
                    <div id="editbu" style="padding-top: 5px; width: 170px; ">
                        <asp:Button ID="btn_EInvoice" runat="server" OnClick="btn_EInvoice_Click" 
                            Height="30px" Text="Generate E-Invoice" />
                    </div>
                     <div id="editbu" style="padding-top: 5px; width: 170px; display: none;">
                        <asp:Button ID="Btn_Generate_Inv" runat="server" OnClick="btn_Generate_EInvoice_Click" 
                           />
                    </div>
                    <div id="editbu" style="padding-top: 5px; width: 170px;">
                        <asp:Label ID="lbl_Inv_Status" runat="server" ForeColor="Green"></asp:Label>
                    </div>
                </div>
                <div id="tag_transac_lft_IGM_Invoice_Grid_area" style="width: 975px; height: 242px;
                    margin-top: -9px;">
                    <asp:GridView ID="gv_details" runat="server" DataKeyNames="JOBNO,INV_NO,ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                        ShowHeaderWhenEmpty="True" PageSize="15" AllowPaging="True" AllowSorting="True"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                        OnRowCreated="gv_details_RowCreated" OnRowDataBound="gv_details_RowDataBound"
                        OnSelectedIndexChanged="gv_details_SelectedIndexChanged">
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
                            <asp:BoundField DataField="INV_NO" HeaderText="Charge id">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INV_NO" HeaderText="Invoice No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="REG_CESS" HeaderText="Reg/Cess">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TRANSPORT_BILL" HeaderText="Transport Bill">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GRAND_TOTAL" HeaderText="Grand ToTal">
                                <ItemStyle CssClass="column_style_left" />
                                <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INV_STATUS" HeaderText="E-Invoice Status">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="JOB_STATUS" HeaderText="Job Status">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UNAPPROVAL_APPROVED" HeaderText="Grand ToTal">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ID" HeaderText="ID">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div style="display: none;">
        <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
        <asp:HiddenField ID="HiddenGstn" runat="server" />
        <asp:HiddenField ID="hdntotal" runat="server" />
        <asp:HiddenField ID="HiddenField_index" runat="server" />
        <asp:HiddenField ID="HiddenField_ExportJobNo" runat="server" />
        <asp:HiddenField ID="HDupdate_IMP_EXP_id" runat="server" />
        <asp:HiddenField ID="HDupdate_id" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="Hdn_Inv" runat="server" ClientIDMode="Static" />
    </div>
    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/Accounts/Acc_iframepopupwin.js"></script>
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
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }



    
    </script>
</body>
</html>
