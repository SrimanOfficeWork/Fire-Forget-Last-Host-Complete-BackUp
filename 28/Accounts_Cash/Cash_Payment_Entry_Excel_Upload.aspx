<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cash_Payment_Entry_Excel_Upload.aspx.cs"
    Inherits="Accounts_Cash_Cash_Payment_Entry_Excel_Upload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Cash Payment Excel Upload</title>
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
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 190px;">
                        Cash Payment Excel Upload
                    </div>
                    <div id="verslic" style="margin-top: -8px; height: 40px;">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 763px;">
                        <div id="tag_label_transact_Src" style="width: 50px">
                            CP No.
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 190px;">
                            <asp:TextBox ID="txt_Cp_No_F" runat="server" TabIndex="12" ReadOnly="true" BackColor="#e7e6e6"
                                Width="35px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            <asp:TextBox ID="txt_Cp_No_M" runat="server" TabIndex="13" ReadOnly="true" BackColor="#e7e6e6"
                                Style="text-align: right;" Width="60px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            <asp:TextBox ID="txt_Cp_No_L" runat="server" TabIndex="14" ReadOnly="true" BackColor="#e7e6e6"
                                Width="60px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                        </div>
                        <div id="verslic" style="margin-top: -8px; height: 35px;">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 100px">
                            Expense Charge
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 225px;">
                            <asp:DropDownList ID="ddl_Expense_Charge" runat="server" Style="width: 220px;" TabIndex="2"
                                onchange="Load_Exp_Amt()">
                            </asp:DropDownList>
                        </div>
                        <div id="verslic" style="margin-top: -8px; height: 37px;">
                        </div>
                        <div id="tag_label_transact_Src" style="width: 100px;">
                            Expense Amt :
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 80px; margin-left: -13px;">
                            <asp:Label ID="Lbl_Exp_Amt" runat="server" Text="Label" ForeColor="Red"></asp:Label>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <%--<input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();" />--%>
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
                    <div id="editbu" style="margin-top: 10px">
                        Total Amt :
                        <asp:Label ID="lbl_Amt" runat="server" ForeColor="Green"></asp:Label>
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
                                        <asp:BoundField DataField="SI_NO" HeaderText="SI.NO" HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left" Width="50" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="IMP_EXP" HeaderText="Imp/Exp" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left" Width="120" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="JOBNO" HeaderText="JobNo" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left" Width="150" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="JOBNO_PS" HeaderText="JobNo ps" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left" Width="150" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AMOUNT" HeaderText="Amt" HeaderStyle-Width="150px">
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
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" ForeColor="Red" Text="Do you want to delete your previous entry and upload Excel?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 100px; padding-top: 10px;">
                        <asp:Button ID="btnyes" runat="server" Text="Yes" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnyes_Click" />
                        <asp:Button ID="btnNo" runat="server" Text="No" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="return HideModalPopup_U()" />
                    </td>
                </tr>
            </table>
        </div>
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
    </script>
    <script type="text/javascript">
       function RefreshParent() {
        window.parent.document.getElementById("btnExpHead_New").click();
}


      
        function Load_Exp_Amt() {

            var CP_NO = document.getElementById("txt_Cp_No_F").value;
            var CP_M = document.getElementById("txt_Cp_No_M").value;
            var CP_L = document.getElementById("txt_Cp_No_L").value;
            var dd_Exp = document.querySelector('#ddl_Expense_Charge').value;
            PageMethods.GetCharge(CP_NO, CP_M, CP_L, dd_Exp, CallSuccess_Exp);
        }

        function CallSuccess_Exp(res) {
            document.getElementById('<%= Lbl_Exp_Amt.ClientID %>').innerHTML = res;
            document.getElementById('<%= hdnLbl.ClientID %>').value = res;
        }
    </script>
</body>
</html>
