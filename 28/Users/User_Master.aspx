<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Master.aspx.cs" Inherits="User_Master" %>

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
       function close_button() {
           //document.getElementById("btnCancel").click();
           document.getElementById("Company_Page").click();
       }
       function validate_Login() {
           var txtName;
           txtName = document.getElementById("txtName").value;

           if (txtName.length <= 0) {

               jAlert('Name cannot be blank', 'USER LOGIN', function (r) { document.getElementById("txtName").focus(); });

               return false;
           }
           var txtEmployee_ID;
           txtEmployee_ID = document.getElementById("txtEmployee_ID").value;

           if (txtEmployee_ID <= 0) {
               jAlert('Employee Id cannot be blank', 'USER LOGIN', function (r) { document.getElementById("txtEmployee_ID").focus(); });

               return false; ;
           }
           var txtMobile_No;
           txtMobile_No = document.getElementById("txtMobile_No").value;

           if (txtMobile_No <= 0) {
               jAlert('Mobile No cannot be blank', 'USER LOGIN', function (r) { document.getElementById("txtMobile_No").focus(); });

               return false; ;
           }
           if (txtMobile_No.length < 10) {

               jAlert('Mobile No should be 10 digit numbers', 'COMPANY MASTER', function (r) { document.getElementById("txtMobile_No").focus(); });

               return false;
           }
           var txtUser_Name;
           txtUser_Name = document.getElementById("txtUser_Name").value;

           if (txtUser_Name.length <= 0) {

               jAlert('User Name cannot be blank', 'USER LOGIN', function (r) { document.getElementById("txtUser_Name").focus(); });

               return false;
           }


          
           var txtPassword;
           txtPassword = document.getElementById("txtPassword").value;

           if (txtPassword <= 0) {
               jAlert('Pwd cannot be blank', 'USER LOGIN', function (r) { document.getElementById("txtPassword").focus(); });

               return false; ;
           }
           var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
           var emailid = document.getElementById("txtEMail_ID").value;
           var matchArray = emailid.match(emailPat);
           if (document.getElementById("txtEMailID").value != "") {
               if (matchArray == null) {

                   jAlert('Email id not valid', 'USER LOGIN', function (r) { document.getElementById("txtEMail_ID").focus(); });


                   return false;
               }
           }
       
       
       }
       $(function () {


           $('#txtUser_Name').bind('keyup keypress change focus', function () {

               $('#lblUName').text($(this).val());
           });
           $('#txtName').bind('keyup keypress change focus', function () {

               $('#lblName').text($(this).val());
           });
           $('#txtEmployee_ID').bind('keyup keypress change focus', function () {

               $('#lblEmpid').text($(this).val());
           });
           
       });
       function tab_page1(val) {
          
               document.getElementById('page-1').style.display = 'Block';
               document.getElementById('page-2').style.display = 'none';
               document.getElementById('page-3').style.display = 'none';
               document.getElementById('page-4').style.display = 'none';
               document.getElementById('page-5').style.display = 'none';
               document.getElementById('page-6').style.display = 'none';
               document.getElementById('page-7').style.display = 'none';
               document.getElementById('page-8').style.display = 'none';
       }
       function tab_page2(val) {

               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'Block';
               document.getElementById('page-3').style.display = 'none';
               document.getElementById('page-4').style.display = 'none';
               document.getElementById('page-5').style.display = 'none';
               document.getElementById('page-6').style.display = 'none';
               document.getElementById('page-7').style.display = 'none';
               document.getElementById("Trans_Comp_Iframe_user").src = "../Users/User_Branch_Master.aspx";
               document.getElementById('page-8').style.display = 'none';
           }
           function tab_page3(val) {

               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'none';
               document.getElementById('page-3').style.display = 'Block';
               document.getElementById('page-4').style.display = 'none';
               document.getElementById('page-5').style.display = 'none';
               document.getElementById('page-6').style.display = 'none';
               document.getElementById('page-7').style.display = 'none';
               document.getElementById("Trans_Comp_Iframe_user_3").src = "../Users/User_Permission_Master.aspx";
               document.getElementById('page-8').style.display = 'none';
           }
           function tab_page4(val) {

               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'none';
               document.getElementById('page-3').style.display = 'none';
               document.getElementById('page-4').style.display = 'Block';
               document.getElementById('page-5').style.display = 'none';
               document.getElementById('page-6').style.display = 'none';
               document.getElementById('page-7').style.display = 'none';
               document.getElementById("Trans_Comp_Iframe_user_4").src = "../Users/User_Exp_Settings.aspx";
               document.getElementById('page-8').style.display = 'none';          
           }
           function tab_page5(val) {

               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'none';
               document.getElementById('page-3').style.display = 'none';
               document.getElementById('page-4').style.display = 'none';
               document.getElementById('page-5').style.display = 'Block';
               document.getElementById('page-6').style.display = 'none';
               document.getElementById('page-7').style.display = 'none';
               document.getElementById("Trans_Comp_Iframe_user_5").src = "../Users/User_IcegateID_Settings.aspx";
               document.getElementById('page-8').style.display = 'none';
           }
           function tab_page6(val) {
               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'none';
               document.getElementById('page-3').style.display = 'none';
               document.getElementById('page-4').style.display = 'none';
               document.getElementById('page-5').style.display = 'none';
               document.getElementById('page-6').style.display = 'Block';
               document.getElementById('page-7').style.display = 'none';
               document.getElementById("Trans_Comp_Iframe_user_6").src = "../Users/User_Imp_Settings.aspx";
               document.getElementById('page-8').style.display = 'none';
           }
           function tab_page7(val) {
               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'none';
               document.getElementById('page-3').style.display = 'none';
               document.getElementById('page-4').style.display = 'none';
               document.getElementById('page-5').style.display = 'none';
               document.getElementById('page-6').style.display = 'none';
               document.getElementById('page-7').style.display = 'Block';
               document.getElementById("Trans_Comp_Iframe_user_7").src = "../Users/Client_User_Rights_Details.aspx";
               document.getElementById('page-8').style.display = 'none';
           }

           function tab_page8(val) {

               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'none';
               document.getElementById('page-3').style.display = 'none';
               document.getElementById('page-4').style.display = 'none';
               document.getElementById('page-5').style.display = 'none';
               document.getElementById('page-6').style.display = 'none';
               document.getElementById('page-7').style.display = 'none';
               document.getElementById('page-8').style.display = 'Block';

               document.getElementById("Trans_Comp_Iframe_user_8").src = "../Users/User_Imp_IEC_Settings.aspx";
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
    
    <div id="innerbox_MidMain_Transact_popup_new" >
        <div id="tag_srcinner1_new">
            <div id="editbu">
                <a href="#" class="edit"></a>
            </div>
            <div id="mainmastop2container_rght_tag2_txt1">
               User Creation
                 
                </div>
                  <div id="popupwindow_closebut_right_new"><input type="close" value="Submit" class="clsicon_new"  onclick="parent.adcodewindow.hide();return false;" /> </div>
               
        </div>
        <div id="tag_transaction_inner_new">
            <div id="tag_Exchange_lft_in1_new1">
                <div id="tag_label_comp_master1">
                    Company Licence
                </div>
                <div id="txtcon-m_transaction_Supp_code">
                    <asp:TextBox ID="txtCompany_License" runat="server" MaxLength="20" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                        TabIndex="1"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_comp_master1" style="width:90px">
                    Client Name
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width:270px">
                    <asp:TextBox ID="txtClient_Name" runat="server" MaxLength="250" Width="250px" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" TabIndex="2"></asp:TextBox>
                </div>
                 <div id="tag_label_comp_master1">
                     No of Users
                </div>
                <div id="txtcon-m_transaction_Supp_code">
                      <asp:TextBox ID="txt_No_Of_Users" runat="server" MaxLength="20" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                        TabIndex="3"></asp:TextBox>
                </div>

            </div>
            <div id="tag_label_transaction_popup_IGM2_empty_gen">
            </div>
            <div id="tag_Exchange_lft_in1_new1">
                <div id="tag_label_comp_master1">
                   Licence
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width:40px;color:Green; font-weight:bold;">
                       Import
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                 <div id="tag_label_comp_master1" style="width:50px">
                   <asp:CheckBox ID="Chk_Imp_L" runat="server"  Enabled="false" TabIndex="13"/>
                </div>

                <div id="txtcon-m_transaction_Supp_code" style="width:40px;color:Green; font-weight:bold;">
                       Export
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                 <div id="tag_label_comp_master1" style="width:50px">
                   <asp:CheckBox ID="Chk_Exp_L" runat="server" Enabled="false" TabIndex="13"/>
                </div>

                 <div id="txtcon-m_transaction_Supp_code" style="width:40px;color:Green; font-weight:bold;">
                       Billing
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                 <div id="tag_label_comp_master1" style="width:50px">
                   <asp:CheckBox ID="Chk_Billing_L" runat="server" Enabled="false" TabIndex="13"/>
                </div>

                <div id="txtcon-m_transaction_Supp_code" style="width:50px;color:Green; font-weight:bold;">
                       Accounts
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                 <div id="tag_label_comp_master1" style="width:50px">
                   <asp:CheckBox ID="Chk_Acc_L" runat="server" Enabled="false"  TabIndex="13"/>
                </div>
                 
                  <div id="txtcon-m_transaction_Supp_code" style="width:60px;color:Green; font-weight:bold;">
                       Imp Sez
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                 <div id="tag_label_comp_master1" style="width:50px">
                   <asp:CheckBox ID="Chk_IZ_L" runat="server" Enabled="false"  TabIndex="13"/>
                </div>

                 <div id="txtcon-m_transaction_Supp_code" style="width:60px;color:Green; font-weight:bold;">
                       Exp Sez
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                 <div id="tag_label_comp_master1" style="width:50px">
                   <asp:CheckBox ID="Chk_EZ_L" runat="server" Enabled="false"  TabIndex="13"/>
                </div>

            </div>
        </div>
    </div>

    <div id="innerbox_MidMain_usercreation">
        <ol id="toc_new">
            <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');" id="Company_Page" ><span>User Details</span></a></li>
            <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');tab_page7('0');" id="CHA_Module_Page"  runat="server"><span> Menu Enable</span></a></li>
            <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2('0');" id="Branch_Page"  runat="server"><span> Branch</span></a></li>
            <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3('0');" id="Permission_Page"  runat="server"><span> Permission</span></a></li>
            <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');tab_page6('0');" id="Import"  runat="server"><span> Import_Settings</span></a></li>
            <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4('0');" id="Export"  runat="server"><span> Export_Settings</span></a></li>
            <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5('0');" id="IcegateID"  runat="server"><span> Icegate ID</span></a></li>
            <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');tab_page8('0');" id="IEC"  runat="server"><span>IEC</span></a></li>
        </ol>
        <div class="content" id="page-1">
            <div id="user_creation_maintag">
                <div id="tag_user_creation_row">
                    <div id="tag_label_user_creation">
                        Emp. Name
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtName" TabIndex="4" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_user_creation">
                      
                        Emp. Id
                        </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        
                        <asp:TextBox ID="txtEmployee_ID" runat="server" TabIndex="5" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_user_creation_row">
                    <div id="tag_label_user_creation">
                         Eri. User Name
                          </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtUser_Name" TabIndex="6" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_user_creation">
                        Eri. Password
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtPassword" TabIndex="7" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_user_creation_row">
                    <div id="tag_label_user_creation">
                        Mobile No.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtMobile_No" TabIndex="8" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_user_creation">
                        Email ID
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtEMail_ID" runat="server" TabIndex="9" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_user_creation_row">
                    <div id="tag_label_user_creation">
                         Subscribe
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                    <asp:RadioButtonList ID="rdoSubscribe" runat="server" RepeatDirection="Horizontal"
                            TabIndex="10">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                       
                    </div>
                    <div id="magnify_area">
                    </div>
                    <span id="I_Chk" visible="false"  runat="server">
                    <div id="tag_label_user_creation" style="color:Red; font-weight:bold;">
                        Import
                        </div>
                    <div id="txtcon-m_transaction_Supp_code">
                      <asp:CheckBox ID="Chk_Imp" runat="server"  TabIndex="13"/>
                    </div>
                    </span>
                </div>
                <div id="tag_user_creation_row">
                    <div id="tag_label_user_creation">
                    Within Network
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                          <asp:RadioButtonList ID="rdoWithin_Network" runat="server" RepeatDirection="Horizontal" TabIndex="11">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="magnify_area">
                    </div>
                     <span id="E_Chk" visible="false"  runat="server">
                    <div id="tag_label_user_creation" style="color:Red; font-weight:bold;">
                        Export 
                        </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:250px;">
                    <asp:CheckBox ID="Chk_Exp" runat="server" TabIndex="14" />
                    </div>
                    </span>
                </div>
                 <div id="tag_user_creation_row">
                    <div id="tag_label_user_creation">
                    Status
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                           <asp:RadioButtonList ID="rdoStatus" runat="server" RepeatDirection="Horizontal" TabIndex="12">
                            <asp:ListItem>Active</asp:ListItem>
                            <asp:ListItem>InActive</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <span id="B_Chk" visible="false"  runat="server">
                    <div id="tag_label_user_creation" style="color:Red; font-weight:bold;">
                       Billing
                        </div>
                    <div id="txtcon-m_transaction_Supp_code">
                         <asp:CheckBox ID="Chk_Billing" runat="server" TabIndex="15"/>
                    </div>
                    </span>
                </div>

                <div id="tag_user_creation_row">
                    <div id="tag_label_user_creation">
                   
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                          
                    </div>
                    <div id="magnify_area">
                    </div>
                    <span id="A_Chk" visible="false"  runat="server">
                    <div id="tag_label_user_creation" style="color:Red; font-weight:bold;">
                        Accounts</div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:CheckBox ID="Chk_Acc" runat="server" TabIndex="16"/>
                    </div>
                    </span>
                </div>
                 <div id="tag_user_creation_row">
                    <div id="tag_label_user_creation">
                   
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                          
                    </div>
                    <div id="magnify_area">
                    </div>
                    <span id="IZ_Chk" visible="false"  runat="server">
                    <div id="tag_label_user_creation" style="color:Red; font-weight:bold;">
                        Imp. Sez</div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:CheckBox ID="Chk_Imp_Sez" runat="server" TabIndex="16"/>
                    </div>
                    </span>
                </div>
                 <div id="tag_user_creation_row">
                    <div id="tag_label_user_creation">
                   
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                          
                    </div>
                    <div id="magnify_area">
                    </div>
                    <span id="EZ_Chk" visible="false"  runat="server">
                    <div id="tag_label_user_creation" style="color:Red; font-weight:bold;">
                        Exp. Sez</div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:CheckBox ID="Chk_Exp_Sez" runat="server" TabIndex="16"/>
                    </div>
                    </span>
                </div>
                <div id="tag_user_creation_row_branch">
                </div>

                <div id="innerbox_MidMain_bot_transact_invoice">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="19"
                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="17"
                            OnClientClick="return validate_Login();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" TabIndex="17" OnClientClick="return validate_Login();"
                            OnClick="btnUpdate_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="18" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'USER LOGIN', function(r) {
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
                        <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="parent.adcodewindow.hide();return false;"
                            TabIndex="19" CausesValidation="false" UseSubmitBehavior="false" />

                    </div>
                </div>
            </div>
        </div>
        <div class="content" id="page-7">
            <iframe name="trans_igm7" scrolling="yes" id="Trans_Comp_Iframe_user_7" runat="server" style="width:900px; height:650px; margin-left:-15px;">
            </iframe>
        </div>
        <div class="content" id="page-2">
            <iframe name="trans_igm" scrolling="no" id="Trans_Comp_Iframe_user" runat="server">
            </iframe>
        </div>
        <div class="content" id="page-3">
            <iframe name="trans_igm" scrolling="no" id="Trans_Comp_Iframe_user_3" runat="server" style="width:900px; height:520px;">
            </iframe>
        </div>
        <div class="content" id="page-4">
            <iframe name="trans_igm4" scrolling="yes" id="Trans_Comp_Iframe_user_4" runat="server" style="width:900px; height:650px;">
            </iframe>
        </div>
        <div class="content" id="page-5">
            <iframe name="trans_igm5" scrolling="yes" id="Trans_Comp_Iframe_user_5" runat="server" style="width:900px; height:650px;">
            </iframe>
        </div>
        <div class="content" id="page-6">
            <iframe name="trans_igm6" scrolling="yes" id="Trans_Comp_Iframe_user_6" runat="server" style="width:900px; height:650px;">
            </iframe>
        </div>
             <div class="content" id="page-8">
            <iframe name="trans_igm7" scrolling="yes" id="Trans_Comp_Iframe_user_8" runat="server" style="width:900px; height:650px;">
            </iframe>
        </div>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static"/>

          <asp:HiddenField ID="hdn_Company_ID" runat="server" />
<asp:HiddenField ID="hdn_User_Creation_Id" runat="server" />

<asp:HiddenField ID="HiddenField1" runat="server" />
 
  
 
  
 
  </div>
     

                 </div>
                 <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_Imp">
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_Topcap">
                    User Details</div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1">
                         Name
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                            <asp:Label ID="lblName" runat="server" ></asp:Label></div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1">
                        Employee Id
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblEmpid" runat="server" ></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1">
                        User Name
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lblUName" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                    <div id="tag_label_transaction_popup_IGM_invoice_det1">
                        Total Users
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                        <asp:Label ID="lbl_total_Users" runat="server" ></asp:Label>
                    </div>
                </div>
             </div>
             
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
    </script>
 
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
 
</body>
</html>
