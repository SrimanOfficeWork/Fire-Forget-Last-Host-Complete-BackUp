<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Branch_Port_Details.aspx.cs" Inherits="Transaction_IGMDetails_new" %>
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

       <div id="tag_transac_lft_comp_mas_in1" style="width:940px;">
           <div id="tag_label_comp_master1">
               Branch
           </div>
           <div id="txtcon-m_transaction_list1_bondtype" style="width: 210px">
               <asp:DropDownList ID="ddlBranch" runat="server" CssClass="listtxt_comp_mas" TabIndex="1"
                   AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
               </asp:DropDownList>
           </div>
           <div id="magnify_area" runat="server">
               <a href="#" class="magnfy" onclick="OpenPopupCustom_House_Details('ADMIN_BRANCH'); return false"
                   tabindex="6"></a>
           </div>
            <div id="tag_label_comp_master1"> &nbsp;&nbsp;&nbsp;Port of Filing </div>
            <div id="txtcon-m_transaction_Supp_code">
             <asp:TextBox ID="txt_PortFilling" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
               TabIndex="2" MaxLength="50"></asp:TextBox>
               </div>
       </div>

  <div id="tag_transac_lft_comp_mas_in1">
  <div id="tag_label_comp_master1">ICE Gate ID </div>
  <div id="txtcon-m_transaction_Supp_code">
      <asp:TextBox ID="txtICEGate_ID" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" TabIndex="3" MaxLength="50"></asp:TextBox>
   
  </div>
  <div id="magnify_area"></div>
    <div id="tag_label_comp_master1">ICE Gate Password </div>
    <div id="txtcon-m_transaction_Supp_code">
     <asp:TextBox ID="txtICEGate_Pwd" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" TabIndex="4" MaxLength="50"></asp:TextBox>
    
  </div>
  </div>

    <div id="tag_transac_lft_comp_mas_in1">
  <div id="tag_label_comp_master1">ICE Gate EMail ID </div>
  <div id="txtcon-m_transaction_Supp_code">
      <asp:TextBox ID="txtICEGate_EmailID" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" TabIndex="5" MaxLength="50"></asp:TextBox>
   
  </div>
  <div id="magnify_area"></div>
    <div id="tag_label_comp_master1">ICE Gate EMail Pwd </div>
    <div id="txtcon-m_transaction_Supp_code">
     <asp:TextBox ID="txtICEGate_EMailPwd" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" TabIndex="6" MaxLength="50"></asp:TextBox>
    
  </div>
  </div>
  
  <div id="tag_transac_lft_comp_mas_in1">
  <div id="tag_label_comp_master1">CHA No. </div>
  <div id="txtcon-m_transaction_Supp_code">
  <asp:TextBox ID="txtCHA_No" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" TabIndex="7" MaxLength="15"></asp:TextBox>
 
  </div>
  <div id="magnify_area"></div>
  <div id="tag_label_comp_master1">CHA Name </div>
    <div id="txtcon-m_transaction_Supp_code">
     <asp:TextBox ID="txtCHA_Name" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" TabIndex="8" MaxLength="100"></asp:TextBox>
    
  </div>
   </div>
   
   <div id="tag_transac_lft_comp_mas_in1" style="width:950px;">
  <div id="tag_label_comp_master1">CHA Address </div>
  <div id="txtcon-m_transaction_Supp_code">
   <asp:TextBox ID="txtAddress1" placeholder = "Add1" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" TabIndex="9" MaxLength="50"></asp:TextBox>
 
  </div>
  <div id="magnify_area"></div>
  <div id="tag_label_comp_master1">
    <asp:TextBox ID="txtAddress2" placeholder = "Add2"  runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" Width="120px" TabIndex="10" MaxLength="50"></asp:TextBox>

  </div>
    <div id="txtcon-m_transaction_Supp_code" style="width:450px;">
     <asp:TextBox ID="txtAddress3" runat="server" placeholder = "Add3"  CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="11" MaxLength="50"></asp:TextBox>
      <asp:TextBox ID="txtAddress4" runat="server" placeholder = "Add4" CssClass="txtbox_none_Mid_transac_Supp_Name" Width="120px"  TabIndex="12" MaxLength="50"></asp:TextBox>
     <asp:TextBox ID="txtAddress5" runat="server" placeholder = "Add5" CssClass="txtbox_none_Mid_transac_Supp_Name" Width="100px"  TabIndex="13" MaxLength="50"></asp:TextBox>
  </div>


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
<div id="editbu"><asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('Database_ID');return false;"
                        tabindex="16" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />

</div>
</div>

<div id="tag_transac_lft_comp_mas_in1_gridarea2" style="width:910px; height:150px;">

<asp:GridView ID="gv_License" runat="server" AutoGenerateColumns="False" EmptyDataText="No Record Found"
                                CssClass="grid-view" AllowPaging="false" HorizontalAlign="Left" 
                                DataKeyNames="CHA_LICENSE_ID" AllowSorting="True" BorderColor="#C8C8C8" ShowHeaderWhenEmpty="true"
                                Width="100%" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                OnRowCreated="gv_License_RowCreated"
                                OnRowDataBound="gv_License_RowDataBound" OnSelectedIndexChanged="gv_License_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>

                                   <asp:BoundField DataField="CHA_LICENSE_ID" HeaderText="S.NO" >
                                    <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>

                                    <asp:BoundField DataField="BRANCH" HeaderText="Branch" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>
                                    <asp:BoundField DataField="PORT_OF_FILING" HeaderText="Port Of Filing" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>
                                    <asp:BoundField DataField="ICEGATE_ID" HeaderText="ICE Gate ID" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>
                                        <asp:BoundField DataField="ICEGATE_PWD" HeaderText="ICE Gate PWD" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>
                                   
                                    <asp:BoundField DataField="CHA_NO" HeaderText="CHA No" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>
                                    <asp:BoundField DataField="CHA_NAME" HeaderText="CHA Name" >
                                        <ItemStyle CssClass="column_style_left" /></asp:BoundField>
                                    
                                    <asp:BoundField DataField="CHA_ADDRESS">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="CHA_ADDRESS1">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                 
                                    <asp:BoundField DataField="CHA_ADDRESS2">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CHA_ADDRESS3">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CHA_ADDRESS4">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                   
                                    <asp:BoundField DataField="ICEGATE_EMAIL_ID">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="ICEGATE_EMAIL_PWD">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>

                                </Columns>
                            </asp:GridView>


</div>


   </div>
 
 </div>
            <asp:HiddenField ID="HiddenField1" runat="server" />
 
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
