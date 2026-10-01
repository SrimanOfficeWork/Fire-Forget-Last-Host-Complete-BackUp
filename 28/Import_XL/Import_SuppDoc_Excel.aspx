<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_SuppDoc_Excel.aspx.cs"
    Inherits="Import_SuppDoc_Excel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Bill Invoice</title>
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
            <div id="innerbox_MidMain" style="height: 32px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                        Excel Upload
                    </div>
                    <div id="verslic">
                    </div>
                    <%--  <div id="tag_label_transaction_exp_jobb" style="width: 80px;">
                            Invoice Sr.No
                        </div>
                        <div id="txtcon-m_transaction_list1" >
                             <asp:DropDownList ID="ddlInvoice_SlNo" runat="server" CssClass="listtxt_transac_src1" Width="60px"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlInvoice_SlNo_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      <div id="MC_ID" runat="server" >
                        <div id="tag_label_transaction_exp_jobb" style="width: 70px; margin-left: 2px">
                            Item Sr.No
                        </div>
                        <div id="txtcon-m_transaction_list1" >
                           <asp:DropDownList ID="ddl_ItemSlno" runat="server" CssClass="listtxt_transac_src1" Width="60px"
                                AutoPostBack="false"  >
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        </div>--%>
                    <%--  <div id="verslic">
                    </div>--%>
                    <div id="tag_label_transact_Src" style="width: 100px;">
                        Select a Excel</div>
                    <div id="txtcon-m_Exchange" style="width: 550px;">
                        <asp:FileUpload ID="fileuploadExcel" runat="server" onchange="return fileValidation();"
                            EnableViewState="True" ViewStateMode="Enabled" Width="80px" Style="color: transparent;" />
                        <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" ViewStateMode="Enabled"
                            Style="display: none;" />
                        <asp:Label runat="server" ID="Label1" Font-Size="Medium"></asp:Label>
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btn_Exp_Sup_Doc_Upload" runat="server" CssClass="autowidmovebut"
                            Text="Upload" Visible="false" TabIndex="0" UseSubmitBehavior="false" CausesValidation="false"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btn_Exp_Sup_Doc_Xl_Upload" />
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
            </div>
            <div class="content" id="page-1" style="margin-left: -30px; margin-top: -15px; width: 1110px;">
                <div id="open_item" runat="server">
                    <div class="content" id="page-6">
                        <div id="mainmastop2container_rght_tag2_txt1" runat="server" style="height: 30px;
                            width: 926px; margin-top: -16px; overflow: hidden; color: Green">
                            Preview Data
                        </div>
                        <%--  <div id="pop_text_area_transac_popup_inn_container_export" style="height: 280px; width:auto; margin-top: 0px; overflow:hidden;">
                        <div id="tag_transac_lft_Item_maindet_Grid_area"   style="height:328px; width:auto;overflow:scroll;">
                        --%>
                        <div id="tag_transac_export_lft_item_gen_Grid_area_new" style="overflow: auto; height: 250px;
                            width: 850px; margin-left: 25px">
                            <%--<asp:GridView ID="gv_Preview" runat="server"  EmptyDataText="No Record Found" Visible="false"
                                AutoGenerateColumns="false" BackColor="White"
                                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                 HorizontalAlign="Center" ShowHeaderWhenEmpty="True" style="table-layout:fixed;" Width="100%"
                                  OnRowCreated="gv_Preview_RowCreated" OnRowDataBound="gv_Preview_RowDataBound">
                                
                                <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                        <SelectedRowStyle Font-Bold="true" />
                          <Columns>
                        <asp:BoundField DataField="INVOICE_SLNO"   HeaderText="INVOICE_SLNO" HeaderStyle-Width="100px">  <ItemStyle CssClass="column_style_left5" Width="100px" /></asp:BoundField>
                        <asp:BoundField DataField="ITEM_SLNO"   HeaderText="ITEM_SLNO" HeaderStyle-Width="80px"  >  <ItemStyle CssClass="column_style_left5" Width="80px"/></asp:BoundField>
                        <asp:BoundField DataField="DECLARATION_TYPE"   HeaderText="DECLARATION_TYPE" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="IMAGE_REF_NUMBER"   HeaderText="IMAGE_REF_NUMBER" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="DOC_TYPE_CODE"   HeaderText="DOC_TYPE_CODE" HeaderStyle-Width="150px"  >  <ItemStyle CssClass="column_style_left5" Width="150px"/></asp:BoundField>
                        <asp:BoundField DataField="DOC_ISSUING_PARTY_CODE"   HeaderText="DOC_ISSUING_PARTY_CODE" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="DOC_ISSUING_PARTY_NAME"   HeaderText="DOC_ISSUING_PARTY_NAME" HeaderStyle-Width="200px"  >  <ItemStyle CssClass="column_style_left5" Width="200px"/></asp:BoundField>
                        <asp:BoundField DataField="DOC_ISSUING_PARTY_NAME_ADD1"   HeaderText="DOC_ISSUING_PARTY_NAME_ADD1" HeaderStyle-Width="220px"  >  <ItemStyle CssClass="column_style_left5" Width="220px"/></asp:BoundField>
                        <asp:BoundField DataField="DOC_ISSUING_PARTY_NAME_ADD2"   HeaderText="DOC_ISSUING_PARTY_NAME_ADD2" HeaderStyle-Width="220px"  >  <ItemStyle CssClass="column_style_left5" Width="220px"/></asp:BoundField>
                        <asp:BoundField DataField="DOC_ISSUING_PARTY_CITY"   HeaderText="DOC_ISSUING_PARTY_CITY" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="DOC_ISSUING_PARTY_PIN"   HeaderText="DOC_ISSUING_PARTY_PIN" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="DOC_REF_NUMBER"   HeaderText="DOC_REF_NUMBER" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="PLACE_OF_ISSUE"   HeaderText="PLACE_OF_ISSUE" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="DOC_ISSUE_DATE"   HeaderText="DOC_ISSUE_DATE" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="DOC_EXPIRY_DATE"   HeaderText="DOC_EXPIRY_DATE" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="BENEFICIARY_PARTY_CODE"   HeaderText="BENEFICIARY_PARTY_CODE" HeaderStyle-Width="220px"  >  <ItemStyle CssClass="column_style_left5" Width="220px"/></asp:BoundField>
                        <asp:BoundField DataField="BENEFICIARY_PARTY_NAME"   HeaderText="BENEFICIARY_PARTY_NAME" HeaderStyle-Width="220px"  >  <ItemStyle CssClass="column_style_left5" Width="220px"/></asp:BoundField>
                        <asp:BoundField DataField="BENEFICIARY_PARTY_ADDRESS1"   HeaderText="BENEFICIARY_PARTY_ADDRESS1" HeaderStyle-Width="220px"  >  <ItemStyle CssClass="column_style_left5" Width="220px"/></asp:BoundField>
                        <asp:BoundField DataField="BENEFICIARY_PARTY_ADDRESS2"   HeaderText="BENEFICIARY_PARTY_ADDRESS2" HeaderStyle-Width="220px"  >  <ItemStyle CssClass="column_style_left5" Width="220px"/></asp:BoundField>
                        <asp:BoundField DataField="BENEFICIARY_PARTY_CITY"   HeaderText="BENEFICIARY_PARTY_CITY" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="BENEFICIARY_PARTY_PIN"   HeaderText="BENEFICIARY_PARTY_PIN" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>
                        <asp:BoundField DataField="FILE_TYPE"   HeaderText="FILE_TYPE" HeaderStyle-Width="130px"  >  <ItemStyle CssClass="column_style_left5" Width="130px"/></asp:BoundField>
                        <asp:BoundField DataField="SELECT_TYPE"   HeaderText="SELECT_TYPE" HeaderStyle-Width="130px"  >  <ItemStyle CssClass="column_style_left5" Width="130px"/></asp:BoundField>
                        <asp:BoundField DataField="ICEGATE_ID"   HeaderText="ICEGATE_ID" HeaderStyle-Width="130px"  >  <ItemStyle CssClass="column_style_left5" Width="130px"/></asp:BoundField>
                        <asp:BoundField DataField="ICEGATE_DOC_FILE_NAME"   HeaderText="ICEGATE_DOC_FILE_NAME" HeaderStyle-Width="180px"  >  <ItemStyle CssClass="column_style_left5" Width="180px"/></asp:BoundField>


                          </Columns>
                                  <PagerStyle CssClass="pager" />
                                 
                            </asp:GridView>--%>
                            <asp:GridView ID="gv_Error" runat="server" EmptyDataText="No Record Found" Visible="false"
                                AutoGenerateColumns="true" BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_Error_RowCreated">
                                <PagerStyle CssClass="pager" />
                            </asp:GridView>
                        </div>
                        <%-----------------------Test--------------------------------------------------------%>
                    </div>
                </div>
            </div>
            <%-----------------------------------END----------------------------------------------------------------%>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>
            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ModalPopupExtender ID="MP_U1" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" ForeColor="Red" Text="Delete Ur Previous Support Documents for this Job ?"></asp:Label>
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

            $find("MP_U1").hide();
            return false;
        }
    </script>
    <script type="text/javascript">
        function RefreshParent() {
            win_hide();
            parent.adcodewindow.hide();
            //window.parent.location.reload();
            window.parent.Hide_Excel_Upload();
        }

        function CheckIsFile() {
            var FileHas = $('#Label1').text();

            if (FileHas == '') {

                jAlert('Please Upload File', 'Excel', function (r) { });
                return false;
            }
        }

        function fileValidation() {

            var fileInput =
                document.getElementById('fileuploadExcel');

            var filePath = fileInput.value;

            // Allowing file type 
//            var allowedExtensions =
//                    /(\.xls|\.xlsx)$/i;

            var allowedExtensions = /(\.xls|\.xlsx|\.xlsm)$/i;

            if (!allowedExtensions.exec(filePath)) {
                //alert('Invalid file type');
                jAlert('Please Upload Excel File Format only', 'Excel', function (r) { });
                fileInput.value = '';

                return false;
            }
            else {
                //return true;
                document.getElementById('btn_upload').click();
            }
        } 

    </script>
</body>
</html>
