<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment_Request_Entry_Excel_Upload.aspx.cs"
    Inherits="Accounts_Others_Payment_Request_Entry_Excel_Upload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
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
            <div id="innerbox_MidMain" style="height: 500px; width: 1015px;">
                <div id="innerbox_MidMain_Billing" style="height: 100px; margin-top: -1px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 220px; margin-left: 1px;">
                        Payment Request Excel Upload
                    </div>
                    <div id="verslic" style="margin-top: -8px; height: 40px;">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 753px;">
                        <div id="tag_label_transact_Src" style="width: 50px">
                            Ref No.
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 185px;">
                            <asp:TextBox ID="txt_BP_R_No_F" runat="server" TabIndex="12" ReadOnly="true" BackColor="#e7e6e6"
                                Width="35px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            <asp:TextBox ID="txt_BP_R_M" runat="server" TabIndex="13" ReadOnly="true" BackColor="#e7e6e6"
                                Style="text-align: right;" Width="60px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            <asp:TextBox ID="txt_BP_R_L" runat="server" TabIndex="14" ReadOnly="true" BackColor="#e7e6e6"
                                Width="60px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                        </div>
                        <div id="verslic" style="margin-top: -8px; height: 35px;">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 70px;">
                            <asp:Label ID="Lbl_Payto" runat="server" Text="Label" ForeColor="Black"></asp:Label>
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 200px; margin-left: -13px;">
                            <asp:Label ID="Lbl_PayCusName" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                          <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                 
                    </div>
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 30px;">
                        <div id="tag_transact_lft_in1" style="width: 1100px; height: 30px;">
                            <div id="txt_container_Transact_Main_l" style="width: 100px; margin-left: 10px;">
                                Select a Excel</div>
                            <div id="txtcon-m_Exchange" style="width: 270px;">
                                <asp:FileUpload ID="fileuploadExcel" runat="server" onchange="document.getElementById('Button1').click();" />
                            </div>
                            <div id="editbu" style="width: 110px">
                                <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" Text="Upload"
                                    Style="width: 100px;" />
                            </div>
                            <div id="editbu" style="display: none">
                                <asp:Button ID="Button1" runat="server" OnClick="btn_Click" Text="Upload" Style="width: 100px;" />
                            </div>
                        </div>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="height: 30px; width: 720px;
                        overflow: hidden;">
                        <span style="font-weight: bold; width: 100px;">Preview Data </span>
                    </div>
                    <div class="content" id="page-1" style="margin-left: -14px; width: 1000px; margin-top: -200px;
                        padding-top: 0px;">
                        <div id="tag_transac_lft_in1" style="margin-left: 1px; width: 1020px; height: 280px;">
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="height: 270px; width: 770px;
                                overflow: hidden;">
                                <asp:GridView ID="gv_Details" runat="server" EmptyDataText="No Record Found" Font-Names="Verdana"
                                    AutoGenerateColumns="false" BackColor="LightGray" BorderColor="#C8C8C8" BorderStyle="none"
                                    ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                                    AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="770px"
                                    HeaderStyle-Font-Bold="true" OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
                                    <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                    <PagerStyle ForeColor="Black" CssClass="pager" />
                                    <Columns>
                                        <asp:BoundField DataField="JOBNO_PS" HeaderText="JobNo" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left" Width="120" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IMP_EXP" HeaderText="JobNo Type" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left" Width="150" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CHARGE_HEAD" HeaderText="Charge Head" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left" Width="150" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AMOUNT" HeaderText="Amount" HeaderStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left" Width="200" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PAY_REMARKS" HeaderText="Narration" HeaderStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left" Width="200" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="width: 240px; height: 270px;
                                overflow: hidden;">
                                <fieldset id="fld" style="margin-top: 10px; font-size: 15px; width: 230px; height: 250px;">
                                    <legend style="border: Black; border-collapse: collapse; height: 18px; width: 70px;">
                                        Errors </legend>
                                    <div id="tag_transac_lft_in2" style="width: 224px; height: 270px; overflow: hidden;
                                        word-wrap: break-word; white-space: normal;">
                                        <asp:Label ID="Lbl_alert_msg" runat="server" ForeColor="Red"></asp:Label>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <script src="../activatables.js" type="text/javascript"></script>
                <script type="text/javascript"> activatables('page', ['page-1', 'page-2', 'page-3'); </script>
                <asp:HiddenField ID="hdnLbl" runat="server" ClientIDMode="Static" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
    </asp:Panel>
    </form>
    <script src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>
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
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }



        window.onbeforeunload = function () {
            if (window.opener && !window.opener.closed) {
                window.opener.document.getElementById("Button3").click();
            }
        };
    </script>
</body>
</html>
