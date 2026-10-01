<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_Premium_Services.aspx.cs"
    Inherits="Import_Premium_Services" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Import Premium Services</title>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
    <style type="text/css">
        .hideGridColumn1
        {
            display: none;
        }
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Autotab.js" type="text/javascript"></script>
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

        function tab_page1() {
            document.getElementById('page-1').style.display = 'Block';
            document.getElementById('page-2').style.display = 'none';
            document.getElementById("LoginId").className = 'inactive';
        }
        function tab_page2() {
            document.getElementById('page-1').style.display = 'none';
            document.getElementById('page-2').style.display = 'Block';
            document.getElementById("User_Rights").src = "../Admin/Export_Premium_Services.aspx";
        }
    </script>
</head>
<body style="background-color: #ffffff;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div id="innerbox_MidMain_Trans_IGM">
                <ol id="toc">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();"
                        id="Database_ID"><span>Import</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                        id="LoginId" runat="server"><span>Export</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_area_company_master1_det" style="margin-top: -15px; width: 931px">
                        <div id="tag_transac_lft_comp_mas_in1" style="width: 920px">
                            <div id="tag_label_comp_master1" style="width: 80px">
                                Add to Plan :
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:DropDownList ID="ddlPurchase" runat="server" CssClass="listtxt_comp_master"
                                    Width="150px" TabIndex="1">
                                    <asp:ListItem Text="IRN_N" Value="IRN_N"></asp:ListItem>
                                    <asp:ListItem Text="IRN" Value="IRN"></asp:ListItem>
                                    <asp:ListItem Text="OCR" Value="OCR"></asp:ListItem>
                                    <asp:ListItem Text="Flatfile Reader" Value="FFR"></asp:ListItem>
                                    <asp:ListItem Text="Excel Reader" Value="ER"></asp:ListItem>
                                    <asp:ListItem Text="CheckList Upload" Value="CR"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_comp_master1" style="width: 70px">
                                Created on :
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width: 95px">
                                <asp:TextBox ID="txt_Createdon" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                    Width="80px" TabIndex="7"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Createdon"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Createdon"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_comp_master1" style="width: 69px">
                                Vendor</div>
                            <div id="txtcon-m_transaction_Supp_code" style="width: 151px">
                                <asp:DropDownList ID="ddlapi" runat="server" CssClass="listtxt_comp_master" Width="150px"
                                    TabIndex="1">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="Local" Value="Local"></asp:ListItem>
                                    <asp:ListItem Text="Docker_Vision" Value="Docker_Vision"></asp:ListItem>
                                    <asp:ListItem Text="PMDG" Value="PMDG"></asp:ListItem>
                                    <asp:ListItem Text="Royal" Value="Royal"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                            <div id="tag_label_comp_master1" style="width: 70px">
                                <span>PDF Count </span>
                            </div>
                            <div id="tag_label_comp_master1" style="width: 60px">
                                <asp:TextBox ID="txtupcount" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    Width="45px" MaxLength="1490" TabIndex="8"></asp:TextBox>
                            </div>
                           
                            <div id="tag_label_comp_master1" style="width: 53px">
                                <span>Lead by </span>
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width: 102px">
                                <asp:TextBox ID="txt_Lead_by" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    Width="92px" MaxLength="1490" TabIndex="9"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_comp_mas_in1" style="width: 925px">
                            <div id="tag_label_comp_master1" style="width: 80px">
                                User Status</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:RadioButtonList ID="Rd_Active_Inactive" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    RepeatDirection="Horizontal" TabIndex="9">
                                    <asp:ListItem Text="Active" Value="A" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="InActive" Value="IA"></asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_comp_master1" style="width: 70px">
                                Active on
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width: 95px">
                                <asp:TextBox ID="txt_Active_Date" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                    Width="80px" TabIndex="10"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Active_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Active_Date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_comp_master1" style="width: 70px">
                                <span style="color: Red;">InActive on </span>
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width: 150px">
                                <asp:TextBox ID="txt_InActive_Date" BorderColor="Red" runat="server" MaxLength="10"
                                    CssClass="txtbox_none_Mid_transac_Supp_Name" Width="80px" TabIndex="11"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_InActive_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_InActive_Date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_comp_master1" style="width: 70px">
                                <span>Remarks </span>
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width: 210px">
                                <asp:TextBox ID="txt_Remarks" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    Width="205px" MaxLength="1490" TabIndex="12"></asp:TextBox>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact_invoice">
                            <div id="newbu">
                                <asp:Button ID="btn_New" runat="server" CssClass="new" OnClick="btn_New_Click" TabIndex="17"
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btn_Save" runat="server" CssClass="save" OnClick="btn_Save_Click "
                                    TabIndex="15" OnClientClick="return validate_Database();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btn_Update" runat="server" CssClass="updates" OnClick="btn_Update_Click"
                                    TabIndex="15" OnClientClick="return validate_Database();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btn_Delete" runat="server" TabIndex="16" Visible="false" CssClass="dlete"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'LOGIN & DATABASE', function(r) {
                                    var i = r + 'ok';
                                  if(i == 'trueok')
                                  {
                                      document.getElementById('Button1').click();
                                  }
                                  else {
                                  }
                                  });return false;" />
                                <asp:Button ID="Button1" runat="server" TabIndex="16" OnClick="btn_Delete_Click"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');" CssClass="dlete"
                                    Style="display: none;" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('Company_Page');return false;"
                                    TabIndex="18" CausesValidation="false" UseSubmitBehavior="false" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_comp_mas_in1_gridarea2" style="width: 930px; height: 250px;">
                            <asp:GridView ID="gvdetails" runat="server" DataKeyNames="P_ID,F_STATUS" EmptyDataText="NO RECORD FOUND"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                ShowHeaderWhenEmpty="True" PageSize="12" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                                OnPageIndexChanging="gvdetails_PageIndexChanging" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged"
                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                OnRowCreated="gvdetails_RowCreated">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                    <asp:TemplateField HeaderText="Status" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" ImageUrl='<%# "~/images/icons/" + (Eval("F_STATUS").ToString() == "A" ? "P.png" : "A.png") %>'
                                                runat="server" Height="10px" Width="10px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IMP_EXP" HeaderText="Imp / Exp" HeaderStyle-Width="80px">
                                        <ItemStyle CssClass="column_style_left5" Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FEATURES" HeaderText="Add to Plan" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left5" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="F_STATUS_CODE" HeaderText="Active / InActive" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left5" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="USER_CREATEDON" HeaderText="Created on" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="column_style_left5" Width="140px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ACTIVEON" HeaderText="Active on" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="column_style_left5" Width="140px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INACTIVEON" HeaderText="InActive on" HeaderStyle-Width="140px">
                                        <ItemStyle CssClass="column_style_left5" Width="140px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REMARKS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LEAD_BY">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="F_STATUS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VENDOR">
                                         <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PDF_UPLOAD">
                                       <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <iframe name="trans_igm" width="940px" height="362px" style="margin-left: -10px;
                        margin-top: -30px;" scrolling="no" id="User_Rights" runat="server"></iframe>
                </div>
                <%--<div class="content" id="page-3" style="display: none; padding-top: 0px;">
                    <iframe name="trans_igm" scrolling="no" id="Trans_Comp_Iframe" runat="server">
                    </iframe>
                </div>
                <div class="content" id="page-4">
                </div>
                <div class="content" id="page-5">
                </div>
                <div class="content" id="page-6">
                </div>
                <div class="content" id="page-7">
                </div>--%>
                <asp:HiddenField ID="hdn_Company_ID" runat="server" />
                <asp:HiddenField ID="hdn_update_Id" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2']);
    </script>
</body>
</html>
