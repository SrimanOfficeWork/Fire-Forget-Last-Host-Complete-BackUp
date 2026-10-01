<%@ Page Language="C#" AutoEventWireup="true" CodeFile="eRoyal_UploadAds.aspx.cs" Inherits="eRoyal_UploadAds" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Upload</title>
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
<style>
    .hiddenColumn
    {
        display: none;
    }
</style>
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
            <div id="innerbox_MidMain" style="height: 500px; width: 605px; min-width: 613px;">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 190px;">
                    Advertisement Upload
                </div>
                <div id="verslic" style="margin-top: -8px; height: 40px;">
                </div>
                <div id="popupwindow_closebut_right_new" style="width: 20px">
                    <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                </div>
                <div id="tag_Exchange_inner_lft" style="width: 605px; height: 45px;">
                    <div id="tag_transact_lft_in1" style="width: 605px; height: 30px;">
                        <label for="FileUpload1" class="form-label">
                            Select files</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" AllowMultiple="true" />
                        <asp:Button ID="btn_Upload" runat="server" Text="Upload" OnClick="btn_Upload_Click"
                            Style="width: 65px; height: 28px; font-size: small; font-weight: bold;" />
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                            OnClick="btnUpdate_Click" TabIndex="28" 
                        OnClientClick="document.getElementById('hfActionFlag').value = 'UPLOAD_FILE'; return validation();" />
                        <asp:Button ID="btnDelete" runat="server" TabIndex="19" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Upload', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
            document.getElementById('hfActionFlag').value = 'DELETE_UPLOAD_FILE';
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="19" OnClick="btnUpdate_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                </div>
                <div class="content" id="page-1" style="margin-left: -14px; width: 605px; margin-top: -200px;
                    padding-top: 0px;">
                    <div id="tag_transac_lft_in1" style="margin-left: 1px; width: 705px; height: 280px;">
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="height: 220px; width: 605px;
                            overflow: scroll;">
                            <asp:GridView ID="gvdetails" runat="server" ShowHeader="true" Width="605px" AllowPaging="True"
                                AllowSorting="True" AutoGenerateColumns="false" OnRowCreated="gvdetails_RowCreated"
                                DataKeyNames="ATTACHMENT_FILE,FILE_PATH,DISPLAY_ORDER" BorderColor="#C8C8C8"
                                BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" EmptyDataText="NO RECORD FOUND"
                                PageSize="10" ShowHeaderWhenEmpty="True" CssClass="grid-view" OnRowDataBound="gvdetails_RowDataBound"
                                OnPageIndexChanging="gvdetails_PageIndexChanging">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ischk" Checked='<%# Eval("ACTIVE") != DBNull.Value && !string.IsNullOrEmpty(Eval("ACTIVE").ToString()) ? bool.Parse(Eval("ACTIVE").ToString()) : true %>'
                                                runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="44px" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order By" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Order" Width="50px" Text='<%# Bind("DISPLAY_ORDER") %>' runat="server"
                                                onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" TabIndex="29" ForeColor="Black"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="File">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="txtfilename" runat="server" Text='<%#Eval("ATTACHMENT_FILE")%>'
                                                OnClick="lnkDownload_Click">
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="350px" CssClass="column_style_left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="FilePath">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtpath" runat="server" Text='<%#Eval("FILE_PATH")%>'>
                                            </asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <script src="../activatables.js" type="text/javascript"></script>
                <script type="text/javascript"> activatables('page', ['page-1', 'page-2', 'page-3'); </script>
                <asp:HiddenField ID="hdnLbl" runat="server" ClientIDMode="Static" />
                  <asp:HiddenField ID="hfActionFlag" runat="server" ClientIDMode="Static" />
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
    </script>
</body>
</html>
