<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Permission_Master.aspx.cs" Inherits="User_Master" %>

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
    </style>
    
</head>
<body style="overflow:hidden;">

    <form id="form1" runat="server">
      
      
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="content" id="page-1" >
                <div id="tag_transac_lft_comp_mas_in1">
                    <div id="tag_label_comp_master1">
                        Select Branch
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:DropDownList ID="ddlLoad_Branch" runat="server" AutoPostBack="true" CssClass="listtxt_comp_mas"
                            TabIndex="12" OnSelectedIndexChanged="ddlLoad_Branch_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                 <asp:Panel ID="div_Permission" runat="server" Visible="false">
                <div id="tag_transac_export_lft_item_gen_Grid_comp" style="width: 700px; height: 270px;">
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="SCREEN_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                        OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" AllowPaging="false"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowDataBound="gvdetails_RowDataBound">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="SCREEN_ID" HeaderText="Screen Id">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SCREEN_NAME" HeaderText="Screen Name">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="chkTotalAll" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk_All" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="All">
                                <ItemTemplate>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Read">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Read" runat="server" />
                                </ItemTemplate>
                                <ItemStyle CssClass="column_style_left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Write">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Write" runat="server" />
                                </ItemTemplate>
                                <ItemStyle CssClass="column_style_left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Modify">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Modify" runat="server" />
                                </ItemTemplate>
                                <ItemStyle CssClass="column_style_left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk_Delete" runat="server" />
                                </ItemTemplate>
                                <ItemStyle CssClass="column_style_left" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                    <asp:HiddenField ID="hdn_Company_ID" runat="server" />
                    <asp:HiddenField ID="hdn_User_Creation_Id" runat="server" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
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
                </asp:Panel>
                <script src="../activatables.js" type="text/javascript"></script>
                <script type="text/javascript">
        activatables('page', ['page-1', 'page-2','page-3']);
                </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
 <script language="javascript">

     $(function () {

         toggleSelectList = function (el, selectID, selectID1, selectID2, selectID3) {

             var selectElement = document.getElementById(selectID);

             var gv = document.getElementById("gvdetails");


             var inputList = gvdetails.getElementsByTagName("input");

             var headerCheckBox;
             for (var i = 0; i < inputList.length; i++) {
                 //The First element is the Header Checkbox
                 headerCheckBox = inputList[0];
                 var checked = true;
                 if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                     if (!inputList[i].checked) {
                         headerCheckBox.checked = false;

                     }
                     else {
                         headerCheckBox.checked = true;

                     }

                 }


             }

             if (selectElement) {
                 selectElement.disabled = el.checked;
                 selectElement.checked = false;

             }

             var selectElement1 = document.getElementById(selectID1);
             if (selectElement1) {
                 selectElement1.disabled = el.checked;
                 selectElement1.checked = false;

             }
             var selectElement2 = document.getElementById(selectID2);
             if (selectElement2) {
                 selectElement2.disabled = el.checked;
                 selectElement2.checked = false;

             }
             var selectElement3 = document.getElementById(selectID3);
             if (selectElement3) {
                 selectElement3.disabled = el.checked;
                 selectElement3.checked = false;

             }



         }
         toggleSelectList1 = function (el, selectID, selectID1, selectID2, selectID3) {

             var selectElement = document.getElementById(selectID);
             var selectElement1 = document.getElementById(selectID1);
             var selectElement2 = document.getElementById(selectID2);
             var selectElement3 = document.getElementById(selectID3);
             if (selectElement) {

                 if (selectElement1.checked == false) {

                     if (selectElement2.checked == false) {

                         if (selectElement3.checked == false) {
                             selectElement.disabled = el.checked;
                             selectElement.checked = false;
                         }

                     }
                 }



             }
         }


         $("#<%=gvdetails.ClientID%> input[id*='chkTotalAll']:checkbox").click(function () {

             if ($(this).is(':checked')) {
                 $("#<%=gvdetails.ClientID%> input[id*='chk_All']:checkbox").attr('disabled', false);

                 $("#<%=gvdetails.ClientID%> input[id*='chk_All']:checkbox").attr('checked', true);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Read']:checkbox").attr('disabled', true);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Write']:checkbox").attr('disabled', true);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Modify']:checkbox").attr('disabled', true);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Delete']:checkbox").attr('disabled', true);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Read']:checkbox").attr('checked', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Write']:checkbox").attr('checked', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Modify']:checkbox").attr('checked', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Delete']:checkbox").attr('checked', false);

             }
             else {

                 $("#<%=gvdetails.ClientID%> input[id*='chk_All']:checkbox").attr('checked', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Read']:checkbox").attr('disabled', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Write']:checkbox").attr('disabled', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Modify']:checkbox").attr('disabled', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Delete']:checkbox").attr('disabled', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Read']:checkbox").attr('checked', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Write']:checkbox").attr('checked', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Modify']:checkbox").attr('checked', false);
                 $("#<%=gvdetails.ClientID%> input[id*='chk_Delete']:checkbox").attr('checked', false);

             }
         });
     });

       
</script>
</body>
</html>
