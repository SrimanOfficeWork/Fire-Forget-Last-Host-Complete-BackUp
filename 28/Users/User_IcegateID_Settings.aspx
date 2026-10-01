<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_IcegateID_Settings.aspx.cs"
    Inherits="User_IcegateID_Settings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>User Permission Master</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
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
    </script>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        
        .grid-view
        {
            table-layout: fixed;
            width: 100%;
            border-collapse: collapse;
            background-color: #fff;
        }
        
        .grid-view th
        {
            font-weight: bold;
            padding: 1px;
            border: 1px solid #999;
            text-align: center;
            white-space: nowrap;
        }
        
        .grid-view th:first-child, .grid-view td:first-child
        {
            position: sticky;
            left: 0;
            z-index: 9;
            box-shadow: 2px 0 4px rgba(0, 0, 0, 0.1);
            width: 40px;
            min-width: 40px;
            max-width: 40px;
            padding: 1px;
            text-align: center;
        }
        
        .grid-view th:first-child
        {
            z-index: 11;
        }
        .grid-view th:last-child, .grid-view td:last-child
        {
            text-align: left;
        }
        .grid-view td
        {
            padding: 4px;
        }
        .grid-view input[type="text"]
        {
            width: 100%;
            color: #2b2b2b;
            padding: 5px;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 20px;
            margin-top: 2px;
            width: 100%;
            max-width: 100%;
            box-sizing: border-box;
            border: #c8c8c8 solid thin;
            border-radius: 5px;
            overflow: hidden;
        }
        
        .grid-view button
        {
            padding: 3px 8px;
            font-size: 11px;
        }
        .grid-view a
        {
            color: #0066cc;
            text-decoration: none;
            text-align: left;
        }
        
        .grid-container
        {
            width: 100%;
            overflow-x: auto;
            overflow-y: visible;
            height: 160px;
            border: 1px solid #ccc;
            margin-bottom: 4px;
            background-color: #f9f9f9;
        }
        .duplicate-row td, .duplicate-row td input, .duplicate-row td span
        {
            background-color: #ffcccc !important;
        }
        
        .duplicate-row
        {
            outline: 2px solid red !important;
        }
        @media (max-width: 1024px)
        {
            .grid-view
            {
                min-width: 1600px;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="content" id="page-1" style="height: 329px; overflow-y: scroll;">
                <div id="tag_transac_lft_comp_mas_in1" style="width: 100%; margin-top: -14px">
                    <div id="tag_label_comp_master1">
                        Select Branch
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:DropDownList ID="ddlGroupname" runat="server" CssClass="listtxt-s" AutoPostBack="true"
                            TabIndex="4" ClientIDMode="Static" Width="100px" OnSelectedIndexChanged="ddlGroupname_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:DropDownList ID="ddlLoad_Branch" runat="server" CssClass="listtxt-s" TabIndex="5"
                            ClientIDMode="Static" Width="125px" OnSelectedIndexChanged="ddlLoad_Branch_SelectedIndexChanged1">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="divimport" class="grid-container" runat="server">
                    <asp:GridView ID="gvAll" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CssClass="grid-view" EmptyDataText="NO RECORD FOUND" OnRowCreated="gvAll_RowCreated"
                        OnRowDataBound="gvAll_RowDataBound" OnRowDeleting="gvAll_RowDeleting" OnRowEditing="gvAll_RowEditing"
                        PageSize="20" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%">
                        <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="S.No" />
                            <asp:TemplateField HeaderText="Import Icegate ID" ItemStyle-Width="200px" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Imp_icegateId" runat="server" MaxLength="30" Text='<%# Bind("ICEGATE_ID") %>'></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                                <FooterTemplate>
                                    <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Import CHA NO" ItemStyle-Width="150px" HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Imp_CHA_NO" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_NO") %>' MaxLength="25" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Import CHA NAME" ItemStyle-Width="180px" HeaderStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Imp_CHA_NAME" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_NAME") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS" ItemStyle-Width="200px" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Imp_CHA_ADDRESS" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_ADDRESS") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS1" ItemStyle-Width="180px" HeaderStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Imp_CHA_ADDRESS1" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_ADDRESS1") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS2" ItemStyle-Width="180px" HeaderStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Imp_CHA_ADDRESS2" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_ADDRESS2") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS3" ItemStyle-Width="180px" HeaderStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Imp_CHA_ADDRESS3" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_ADDRESS3") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS4" ItemStyle-Width="180px" HeaderStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Imp_CHA_ADDRESS4" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_ADDRESS4") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AEO Reg No" ItemStyle-Width="250px" HeaderStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Imp_AEO_REGISTRATION_NUMBER" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("AEO_REGISTRATION_NUMBER") %>' MaxLength="20" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AEO Reg role" ItemStyle-Width="140" HeaderStyle-Width="140">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Imp_AEO_REGISTER_ROLE" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("AEO_REGISTER_ROLE") %>' MaxLength="20" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="divExport" class="grid-container" runat="server">
                    <asp:GridView ID="gvExport" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                        CssClass="grid-view" EmptyDataText="NO RECORD FOUND" OnRowCreated="gvExport_RowCreated"
                        OnRowDataBound="gvExport_RowDataBound" OnRowDeleting="gvExport_RowDeleting" OnRowEditing="gvExport_RowEditing"
                        PageSize="20" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="100%">
                        <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                        <Columns>
                            <asp:BoundField DataField="RowNumber" HeaderText="S.No" />
                            <asp:TemplateField HeaderText="Export Icegate ID" ItemStyle-Width="200px" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Exp_icegateId" runat="server" MaxLength="30" Text='<%# Bind("ICEGATE_ID") %>'></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                                <FooterTemplate>
                                    <asp:Button ID="ButtonAdd_Exp" runat="server" OnClick="ButtonAdd_Exp_Click" Text="Add New" />
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Export CHANO" ItemStyle-Width="150px" HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Exp_CHA_NO" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_NO") %>' MaxLength="25" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Export CHA NAME" ItemStyle-Width="180px" HeaderStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Exp_CHA_NAME" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_NAME") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS" ItemStyle-Width="200px" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Exp_CHA_ADDRESS" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_ADDRESS") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS1" ItemStyle-Width="200px" HeaderStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Exp_CHA_ADDRESS1" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_ADDRESS1") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS2" ItemStyle-Width="180px" HeaderStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Exp_CHA_ADDRESS2" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_ADDRESS2") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS3" ItemStyle-Width="180px" HeaderStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Exp_CHA_ADDRESS3" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_ADDRESS3") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ADDRESS4" ItemStyle-Width="180px" HeaderStyle-Width="180px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Exp_CHA_ADDRESS4" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("CHA_ADDRESS4") %>' MaxLength="50" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AEO Reg No" ItemStyle-Width="250px" HeaderStyle-Width="250px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Exp_AEO_REGISTRATION_NUMBER" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("AEO_REGISTRATION_NUMBER") %>' MaxLength="20" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="AEO Reg role" ItemStyle-Width="150px" HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Exp_AEO_REGISTER_ROLE" runat="server" CssClass="txtbox_trans_exp_drawback"
                                        Text='<%# Bind("AEO_REGISTER_ROLE") %>' MaxLength="20" ClientIDMode="Static"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div id="innerbox_MidMain_bot_transact_invoice">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="19"
                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="17"
                        OnClientClick="return validate_Company();" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" TabIndex="17" OnClientClick="return validate_Company();"
                        OnClick="btnUpdate_Click" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="18" Visible="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'USER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="18" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                        CssClass="dlete" Style="display: none;" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('Company_Page');return false;"
                        TabIndex="19" CausesValidation="false" UseSubmitBehavior="false" />
                    <%--<input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()" />--%></div>
            </div>
            <asp:HiddenField ID="hdn_Company_ID" runat="server" />
            <asp:HiddenField ID="hdn_User_Creation_Id" runat="server" />
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
