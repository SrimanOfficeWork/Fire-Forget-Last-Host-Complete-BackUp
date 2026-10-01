<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Branch_Master.aspx.cs" Inherits="User_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
    

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
    <script type="text/javascript">
        function tab_page1() {

            document.getElementById('page-1').style.display = 'Block';
            document.getElementById('page-2').style.display = 'none';
            document.getElementById('page-3').style.display = 'none';



        }
        function tab_page2() {



            document.getElementById('page-1').style.display = 'none';
            document.getElementById('page-2').style.display = 'Block';
            document.getElementById('page-3').style.display = 'none';



        }
        function tab_page3() {



            document.getElementById('page-1').style.display = 'none';
            document.getElementById('page-2').style.display = 'none';
            document.getElementById('page-3').style.display = 'Block';



        }
      
    </script>
    <script type="text/javascript">
          
          function Check_Click(objRef) {
              //Get the Row based on checkbox
              var row = objRef.parentNode.parentNode;

              //Get the reference of GridView
              var GridView = row.parentNode;

              //Get all input elements in Gridview
              var inputList = GridView.getElementsByTagName("input");

              for (var i = 0; i < inputList.length; i++) {
                  //The First element is the Header Checkbox
                  var headerCheckBox = inputList[0];

                  //Based on all or none checkboxes
                  //are checked check/uncheck Header Checkbox
                  var checked = true;
                  if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                      if (!inputList[i].checked) {
                          checked = false;
                          break;
                      }
                  }
              }
              headerCheckBox.checked = checked;

          }
          function checkAll(objRef) {
              var GridView = objRef.parentNode.parentNode.parentNode;
              var inputList = GridView.getElementsByTagName("input");
              for (var i = 0; i < inputList.length; i++) {
                  var row = inputList[i].parentNode.parentNode;
                  if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                      if (objRef.checked) {
                          inputList[i].checked = true;
                      }
                      else {
                          if (row.rowIndex % 2 == 0) {
                              row.style.backgroundColor = "#C2D69B";
                          }
                          else {
                              row.style.backgroundColor = "white";
                          }
                          inputList[i].checked = false;
                      }
                  }
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
<body style="overflow:hidden;" >

    <form id="form1" runat="server">
      

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" EnablePageMethods="true">
    </asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
    
 
    
        
            <%--<div class="content" id="page-1">--%>
                <div id="tag_transac_export_lft_item_gen_Grid_comp"  style= "width:700px; height:300px;" >
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="COMPANY_ID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                        OnRowCreated="gvdetails_RowCreated" Width="99%" ShowHeaderWhenEmpty="True"
                        AllowPaging="false" AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowDataBound="gvdetails_RowDataBound">

                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="chkTotalAll" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk_All" onclick="Check_Click(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BRANCH" HeaderText="Branch">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PORT_OF_FILING" HeaderText="Port of Filling">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
           <%-- </div>--%>
     

                 
 <div id="innerbox_MidMain_bot_transact_invoice">
    <div id="newbu">
      <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="19" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"/>
      
    </div>
<div id="editbu">
 <asp:Button ID="btnSave" runat="server" CssClass="save"  OnClick="btnSave_Click" TabIndex="17" OnClientClick="return validate_Company();"/>

</div>
<div id="editbu">
 <asp:Button ID="btnUpdate" runat="server" CssClass="updates" TabIndex="17" OnClientClick="return validate_Company();"
        onclick="btnUpdate_Click"/>

</div>
<div id="editbu">
 <asp:Button ID="btnDelete" runat="server" TabIndex="18" Visible="false" CssClass="dlete"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'COMPANY MASTER', function(r) {
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
                        tabindex="19" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
<%--<input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()" />--%></div>
 
          </div>
     
              
               
             
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2','page-3']);
    </script>
 
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
 
</body>
</html>
