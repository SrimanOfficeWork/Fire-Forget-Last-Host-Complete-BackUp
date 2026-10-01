<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Rights_Details.aspx.cs" Inherits="User_Rights_Details" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="RR" %>
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
</head>

<body >
    <form id="form1" runat="server">           

      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" EnablePageMethods="true">
    </asp:ScriptManager>
  
           <div class="content" id="page-1">
               <div id="pop_area_company_master1_det" style="width: 950px; height:360px;">
                   <div id="tag_transac_lft_comp_mas_in1" style="width: 940px;">
                       <div id="tag_label_comp_master1" style="width: 190px;">
                          Created Emp. Id Menu Rights 
                       </div>
                       <div id="txtcon-m_transaction_list1_bondtype" style="width: 150px">
                           <asp:DropDownList ID="ddl_Emp_Id" runat="server" CssClass="listtxt_comp_mas" TabIndex="1" Width="100px"
                               AutoPostBack="True" OnSelectedIndexChanged="ddl_Emp_Id_SelectedIndexChanged">
                           </asp:DropDownList>
                       </div>
                        <div id="tag_label_comp_master1" style="width: 350px; color:Red;">
                         Note:-  All Emp. Id  (Import & Export) Default Rights given.
                       </div>
                       
                   </div>
                   
                   <div id="tag_transac_lft_comp_mas_in1_gridarea2" style="width: 925px; height: 270px; margin-left:-12px;">
                        <asp:GridView ID="gvdetails" runat="server"  EmptyDataText="No Record Found"
                             AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                             ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                             AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                             OnRowDataBound="gvdetails_RowDataBound"  OnRowCreated="gvdetails_RowCreated"
                             ShowHeader="True" Style="overflow-x: hidden; overflow-y: auto;" DataKeyNames="U_ID">
                             <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                             <Columns>
                                 <asp:TemplateField HeaderText="Chk" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                     <ItemTemplate>
                                         <asp:CheckBox ID="chk_inv" runat="server" HeaderText="Active" Width="20px" Checked='<%#bool.Parse(Eval("EMP_CHECK").ToString())%>' />
                                     </ItemTemplate>
                                     <ItemStyle Width="20px" />
                                 </asp:TemplateField>

                                 <asp:BoundField DataField="MENU_STATUS" HeaderText="Active/InActive" HeaderStyle-Width="130px">
                                    <HeaderStyle CssClass="column_style_left" />
                                     <ItemStyle CssClass="column_style_left" />
                                  </asp:BoundField>
                                 <asp:BoundField DataField="USER_ROLE" HeaderText="User Role" HeaderStyle-Width="80px">
                                    <HeaderStyle CssClass="column_style_left" />
                                     <ItemStyle CssClass="column_style_left" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="USERID" HeaderText="Emp. Id" HeaderStyle-Width="80px">
                                    <HeaderStyle CssClass="column_style_left" />
                                     <ItemStyle CssClass="column_style_left"  ForeColor="Blue" Font-Bold="true" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="MENU_NAME" HeaderText="Menu" HeaderStyle-Width="130px">
                                    <HeaderStyle CssClass="column_style_left" />
                                     <ItemStyle CssClass="column_style_left" />
                                  </asp:BoundField>

                                 <asp:TemplateField HeaderText="Active On" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Active_On" BorderColor="Green" runat="server" MaxLength="10" Text='<%# Bind("ACTIVEON") %>'
                                             CssClass="txtbox_none_Mid_transac_Supp_Name" Width="80px" TabIndex="11"></asp:TextBox>
                                         
                                         <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Active_On"
                                             Format="dd/MM/yyyy">
                                         </asp:CalendarExtender>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="InActive On" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_In_Active_On" BorderColor="Red" runat="server" MaxLength="10" Text='<%# Bind("INACTIVEON") %>'
                                             CssClass="txtbox_none_Mid_transac_Supp_Name" Width="80px" TabIndex="11"></asp:TextBox>
                                            <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_In_Active_On"
                                                Format="dd/MM/yyyy" Enabled="True"></asp:CalendarExtender>

                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Remarks" HeaderStyle-Font-Bold="true" HeaderStyle-Width="320px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Remarks" TabIndex="11" BorderColor="Red" CssClass="txtbox_none_Mid_transac_Supp_Name" Text='<%# Bind("REMARKS") %>' Height="20px"
                                           MaxLength="1000"  Width="350px" Font-Size="12px" runat="server" ></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="320px" />
                                 </asp:TemplateField>

                                  <asp:BoundField DataField="U_ID">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MENU_ID">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                 
                             </Columns>
                         </asp:GridView>
                         
                   </div>
                   <div id="innerbox_MidMain_bot_transact_invoice">
                       <div id="newbu">
                           <asp:Button ID="btn_New" runat="server" CssClass="new" TabIndex="17" CausesValidation="false"
                               UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                               OnClick="btn_New_Click" />
                       </div>
                       <div id="editbu">
                           <asp:Button ID="btn_Save" runat="server" CssClass="save" TabIndex="14" OnClick="btn_Save_Click"
                               OnClientClick="return validate_Branch();" />
                       </div>
                       <div id="editbu">
                           <asp:Button ID="btn_Update" runat="server" CssClass="updates" TabIndex="14"
                               Visible="false" OnClick="btn_Update_Click" OnClientClick="return validate_Branch();" />
                       </div>
                       <div id="editbu">
                           <asp:Button ID="btn_Delete" runat="server" TabIndex="15" Visible="false" CssClass="dlete"
                               OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'User Rights', function(r) {
                               var i = r + 'ok';
                               if(i == 'trueok')
                               {
                                  document.getElementById('btn').click();
                               }
                               else {
                               }
                                });return false;" />
                           <asp:Button ID="btn" runat="server" TabIndex="15" OnClick="btn_Delete_Click"
                               OnClientClick="jQuery('#form1').validationEngine('hideAll');" CssClass="dlete"
                               Style="display: none;" />
                       </div>
                       <div id="editbu">
                           <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('Database_ID');return false;"
                               TabIndex="16" CausesValidation="false" UseSubmitBehavior="false" />
                       </div>
                   </div>
               </div>
 
 </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
 
    </form>
</body>
</html>
