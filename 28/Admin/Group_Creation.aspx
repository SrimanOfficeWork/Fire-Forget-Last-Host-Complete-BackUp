<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Group_Creation.aspx.cs" Inherits="Group_Creation" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>CHA Branch Details</title>
   <script src="../js/listpopup.js" type="text/javascript"></script>
     <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection"  />
      <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
     <script src="../js/checkboxJScript.js" type="text/javascript"></script>
     <script src="../js/listpopup.js" type="text/javascript"></script>
     <script src="../js/Import_Jscript/Import_Bond.js" type="text/javascript"></script>
     <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    
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
    </script>            
    <style type="text/css">
        .mydatagrid
        {
            width: 80%;
            border: solid 2px black;
            min-width: 80%;
        }
        .header
        {
            background-color: #646464;
            font-family: Arial;
            color: White;
            border: none 0px transparent;
            height: 20px;
            text-align: center;
            font-size: 13px;
        }
        .rows
        {
            background-color: #fff;
            font-family: Arial;
            font-size: 12px;
            color: #000;
            min-height: 15px;
            text-align: left;
            border: none 0px transparent;
        }
        .rows:hover
        {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            text-align: left;
        }
        .selectedrow
        {
            background-color: #ff8000;
            font-family: Arial;
            color: #fff;
            font-weight: bold;
            text-align: left;
        }
        .mydatagrid a /** FOR THE PAGING ICONS **/
        {
            background-color: Transparent;
            padding: 3px 3px 3px 3px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }
        
        .mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/
        {
            background-color: #000;
            color: #fff;
        }
        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
        {
            background-color: #c9c9c9;
            color: #000;
            padding: 3px 3px 3px 3px;
        }
        .pager
        {
            background-color: #646464;
            font-family: Arial;
            color: White;
            height: 15px;
            text-align: left;
        }
        
        .mydatagrid td
        {
            padding: 3px;
        }
        .mydatagrid th
        {
            padding: 3px;
        }
    </style>  

</head>

<body >
    <form id="form1" runat="server">           

      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" EnablePageMethods="true">
    </asp:ScriptManager>
   
  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate> 
            </asp:UpdateProgress>

           <div class="content" id="page-1">

   <div id="pop_area_company_master1_det" style="width:950px;">
  <div id="tag_transac_lft_comp_mas_in1">
  <div id="tag_label_comp_master1">Group Name</div>
  <div id="txtcon-m_transaction_Supp_code">
      <asp:TextBox ID="txt_Groupname" runat="server" AutoCompleteType="Disabled"  Width="250px"
      CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" TabIndex="3" MaxLength="100"></asp:TextBox>
  </div>
  <div id="magnify_area"></div>
  </div>
 <div id="innerbox_MidMain_bot_transact_invoice">
<div id="newbu">
  <asp:Button ID="btnBranch_New" runat="server" CssClass="new" TabIndex="17"  CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
        onclick="btnBranch_New_Click" />
</div>
<div id="editbu">
 <asp:Button ID="btnBranch_Save" runat="server" CssClass="save" TabIndex="14" 
        onclick="btnBranch_Save_Click" OnClientClick="return validate_Branch();"/>

</div>
<div id="editbu">
 <asp:Button ID="btnBranch_Update" runat="server" CssClass="updates" TabIndex="14" Visible="false"
        onclick="btnBranch_Update_Click" OnClientClick="return validate_Branch();" />

</div>
<div id="editbu">

          <asp:Button ID="btnBranch_Delete" runat="server" TabIndex="15" Visible="false" CssClass="dlete"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'BRANCH PORT ', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="15" OnClick="btnBranch_Delete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                        CssClass="dlete" Style="display: none;" />
</div>
<div id="editbu">
<asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('Database_ID');return false;"
                        tabindex="16" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />

</div>
<div id="editbu">
 <span style="color:Red; font-weight:bold;" > Group Count :<asp:Literal ID="lblcnt" runat="server"></asp:Literal></span>
</div>

</div>

<div id="tag_transac_lft_comp_mas_in1_gridarea2" style="width:910px; height:265px;">

<asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                 AllowPaging="false" HorizontalAlign="Left" 
                                DataKeyNames="GROUP_ID,GROUP_NAME" AllowSorting="True" 
                                HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                 ShowHeaderWhenEmpty="true"
                                Width="100%" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gv_RowCreated"
                                OnRowDataBound="gv_RowDataBound" OnSelectedIndexChanged="gv_SelectedIndexChanged">
                               <%-- <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />--%>


                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>

                                   <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="right" Width="45px"  />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="GROUP_NAME" HeaderText="Group Name"  HeaderStyle-Width="90px">
                                    <ItemStyle  CssClass="column_style_left" HorizontalAlign="Left" Width="90px"/>
                                    </asp:BoundField>

                                </Columns>
                            </asp:GridView>


</div>


   </div>
 
 </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:HiddenField ID="HDupdate_id" runat="server" />
 
     </ContentTemplate>
    </asp:UpdatePanel>
  
    </form>
    <script>
        function validate_Branch() {
            var ddlPort_Filling;
            ddlPort_Filling = document.getElementById("ddlPort_Filling").value;

            if (ddlPort_Filling.length <= 0) {

                jAlert('Port of Filling cannot be blank', 'BARNCH & PORT', function (r) { document.getElementById("ddlPort_Filling").focus(); });

                return false;
            }


            var txtICEGate_ID;
            txtICEGate_ID = document.getElementById("txtICEGate_ID").value;

            if (txtICEGate_IDlength <= 0) {
                jAlert('ICEGate ID cannot be blank', 'BARNCH & PORT', function (r) { document.getElementById("txtICEGate_ID").focus(); });

                return false; ;
            }

            var txtCHA_No;
            txtCHA_No = document.getElementById("txtCHA_No").value;

            if (txtCHA_No.length <= 0) {

                jAlert('CHA No cannot be blank', 'BARNCH & PORT', function (r) { document.getElementById("txtCHA_No").focus(); });

                return false;
            }

            var txtCHA_Name;
            txtCHA_Name = document.getElementById("txtCHA_Name").value;

            if (txtCHA_Name.length <= 0) {

                jAlert('CHA Name cannot be blank', 'BARNCH & PORT', function (r) { document.getElementById("txtCHA_Name").focus(); });

                return false;
            }
            var txtAddress1;
            txtAddress1 = document.getElementById("txtAddress1").value;

            if (txtAddress1.length <= 0) {

                jAlert('CHA Address cannot be blank', 'BARNCH & PORT', function (r) { document.getElementById("txtAddress1").focus(); });

                return false;
            }
            
          
        }
        //-----------------------------------  END ADCODE MASTER PAGE VALIDATION--------------------------------------//
    </script>
</body>
</html>
