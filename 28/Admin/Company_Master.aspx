<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Company_Master.aspx.cs" Inherits="Admin_Company_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
      <%-- <script src="../Validation Files/jquery-1.js" type="text/javascript">
        </script>--%>
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
       function tab_page1() {
               document.getElementById('page-1').style.display = 'Block';
               document.getElementById('page-2').style.display = 'none';
               document.getElementById('page-4').style.display = 'none';
               document.getElementById('page-5').style.display = 'none';
           }
       function tab_page2() {
               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'block';
               document.getElementById('page-4').style.display = 'none';
               document.getElementById('page-5').style.display = 'none';
               document.getElementById("Trans_Comp_Iframe1").src = "../Admin/Login_Details.aspx";
           }
           /*
       function tab_page3() {
               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'Block';
               document.getElementById("Trans_export_invoice_Iframe").src = "../Admin/Branch_Port_Details.aspx";
           }
           */
        function tab_page4() {
               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'none';
               document.getElementById('page-4').style.display = 'block';
               document.getElementById('page-5').style.display = 'none';
               document.getElementById("Trans_Comp_User_Creation").src = "../Admin/User_Creation_Details.aspx";
           }
           function tab_page5() {
               document.getElementById('page-1').style.display = 'none';
               document.getElementById('page-2').style.display = 'none';
               document.getElementById('page-4').style.display = 'none';
               document.getElementById('page-5').style.display = 'block';
               document.getElementById("Trans_Premium_Services").src = "../Admin/Import_Premium_Services.aspx";
           }
    </script>

 
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
            <div id="innerbox_MidMain_Transact_popup_new">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Company Master
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="parent.adcodewindow.hide();return false;" />
                    </div>
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
                        <div id="tag_label_comp_master1">
                            Client Name
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width:250px;">
                            <asp:TextBox ID="txtClient_Name" runat="server" MaxLength="80" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"
                                TabIndex="2"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_comp_master1">
                            Date of Installation</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtDate_Installation" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="3"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtDate_Installation"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate_Installation"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                       <%--  <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_comp_master1">
                            DB Create Mode
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width:250px; color:Red;">
                            <asp:RadioButtonList ID="Rd_DB_Create_Mode" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Manual" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Automate" Value="A"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>--%>
                    </div>
                </div>
            </div>

    <div id="innerbox_MidMain_Trans_new">
        <ol id="toc_new">
            <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();" id="Company_Page" ><span>Company Details</span></a></li>

              <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();" id="Login_Page" runat="server" style="display:none;"><span>Login Details</span></a></li>
         <%--   <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();" id="Branch_Page" runat="server" style="display:none;"><span>Branch & Port Details</span></a></li>
        --%>
           <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4();" id="User_Creation" runat="server" style="display:none;">
           <span>User Creation</span></a></li>

          <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5();" id="Premium_Services" runat="server" style="display:none;">
           <span>Premium Services</span></a></li>

        </ol>
        <div class="content" id="page-1">
            <div id="pop_area_company_master1_det" style="width:900px">
                <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                        Mobile No.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                        <asp:TextBox ID="txtMobileNo" Width="250px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            MaxLength="15" TabIndex="4" Onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1">
                        Alternate No.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtAlternate_No" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            MaxLength="15" TabIndex="13" Onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                        Client Address</div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                        <asp:TextBox ID="txtClient_Address" Width="250px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            MaxLength="200" TabIndex="5"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1">
                        Method of Purchase</div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:DropDownList ID="ddlMethod_Purchase" runat="server" CssClass="listtxt_comp_master"
                            TabIndex="14">
                            <asp:ListItem>W</asp:ListItem>
                            <asp:ListItem>R</asp:ListItem>
                            <asp:ListItem>D</asp:ListItem>
                            <asp:ListItem>M</asp:ListItem>
                            <asp:ListItem>WI</asp:ListItem>
                            <asp:ListItem>MI</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                        Phone No.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                        <asp:TextBox ID="txtPhoneNo" Width="250px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            MaxLength="15" TabIndex="6" Onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1">
                        No. of Users</div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtNo_Users" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="15" Onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                        Fax
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                        <asp:TextBox ID="txtFax" Width="250px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="7" Onkeypress="return num1(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1" style="color:Green; font-weight:bold;">
                      Import
                        </div>
                    <div id="txtcon-m_transaction_Supp_code">
                      <asp:CheckBox ID="Chk_Imp" runat="server"  TabIndex="16"/>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                        EMail - ID</div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                        <asp:TextBox ID="txtEMailID" Width="250px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="8" MaxLength="50"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1" style="color:Green; font-weight:bold;">
                       Export
                        
                        </div>
                    <div id="txtcon-m_transaction_Supp_code">
                      <asp:CheckBox ID="Chk_Exp" runat="server" TabIndex="17" />
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                        Contact Person</div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                        <asp:TextBox ID="txtContact_Person" Width="250px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="9"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1" style="color:Green; font-weight:bold;">
                      Billing
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                     <asp:CheckBox ID="Chk_Billing" runat="server" TabIndex="18"/>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                         Default Date
                        </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                      <asp:RadioButtonList ID="rdoDefault_Date" runat="server" RepeatDirection="Horizontal"
                            TabIndex="10">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1" style="color:Green; font-weight:bold;">
                        Accounts
                        </div>
                    <div id="txtcon-m_transaction_Supp_code">
                       <asp:CheckBox ID="Chk_Acc" runat="server" TabIndex="19"/>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                       User Job Lock
                        </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                         <asp:RadioButtonList ID="rdoUserwise_Job_Lock" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            RepeatDirection="Horizontal" TabIndex="11">
                            <asp:ListItem>Yes</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1"  style="color:Green; font-weight:bold;">
                        Imp SEZ
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:CheckBox ID="Chk_Imp_Sez" runat="server" TabIndex="20"/>
                    </div>
                </div>


                <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                     Network IP
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                     <asp:TextBox ID="txtNetwork_IP" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="12"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1"  style="color:Green; font-weight:bold;">
                        Exp SEZ
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                      <asp:CheckBox ID="Chk_Exp_Sez" runat="server" TabIndex="21"/>
                    </div>
                </div>

                 <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                    Select
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                       <asp:RadioButtonList ID="rdoSelect" Enabled="false" CssClass="txtbox_none_Mid_transac_Supp_Name" Width="250px"
                            runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem>Import</asp:ListItem>
                            <asp:ListItem>Export</asp:ListItem>
                            <asp:ListItem>Both</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1">
                        Next Renewel Date
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                         <asp:TextBox ID="txtNext_Renewel_Date" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="20" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtNext_Renewel_Date"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtNext_Renewel_Date"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>
                    </div>
                </div>

                 <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                    <div id="tag_label_comp_master1">
                      <%--  Next Renewel Date--%>
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width:260px">
                       <%-- <asp:TextBox ID="txtNext_Renewel_Date" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                            TabIndex="16" MaxLength="10"></asp:TextBox>
                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtNext_Renewel_Date"
                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                        </asp:MaskedEditExtender>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtNext_Renewel_Date"
                            Format="dd/MM/yyyy">
                        </asp:CalendarExtender>--%>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_comp_master1">
                       Company License
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                         <asp:RadioButtonList ID="rdoStatusNew" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            RepeatDirection="Horizontal" TabIndex="21">
                            <asp:ListItem Text="Active"></asp:ListItem>
                            <asp:ListItem Text="InActive"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>




                <div id="tag_transac_lft_comp_mas_in1" style="width:900px">
                </div>
                <div id="innerbox_MidMain_bot_transact_invoice">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="28"
                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="25"
                            OnClientClick="return validate_Company();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" TabIndex="26" OnClientClick="return validate_Company();"
                            OnClick="btnUpdate_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="27" Visible="false" CssClass="dlete"
                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'COMPANY MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            TabIndex="27" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                            tabindex="29" />
                    </div>
                    <div id="editbu" style="width: 150px;">
                        <asp:Button ID="btn_Db_Creation" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            CssClass="autowidmovebut" Text="Auto DB Creation" Width="150px" OnClientClick="jQuery('#form1').validationEngine('hide');open_Auto_Q(); return false;" />
                    </div>
                </div>
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="hdn_Company_ID" runat="server" ClientIDMode="Static" />
                </div>
            </div>
        </div>
        <div class="content" id="page-2">
            <iframe name="trans_igm" scrolling="no" id="Trans_Comp_Iframe1" runat="server" >
            </iframe>
        </div>
      <%-- <div class="content" id="page-3" style="display: none;">
                    <iframe src="#" name="maineroyal2" scrolling="no" id="Trans_igm_item_Iframe"></iframe>
            </div>--%>
     <div class="content" id="page-4">
            <iframe  name="trans_igm" scrolling="no" id="Trans_Comp_User_Creation" width="960px" height="410px" runat="server" >
            </iframe>
        </div>

         <div class="content" id="page-5">
            <iframe  name="trans_igm" scrolling="no" id="Trans_Premium_Services" width="960px" height="410px" runat="server" >
            </iframe>
        </div>

        
                           
                   
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2', 'page-4', 'page-5']);
    </script>
 
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script>
        function validate_Company() {
            var txtCompany_License;
            txtCompany_License = document.getElementById("txtCompany_License").value;

            if (txtCompany_License.length <= 0) {

                jAlert('Company License cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtCompany_License").focus(); });

                return false;
            }


            var txtClient_Name;
            txtClient_Name = document.getElementById("txtClient_Name").value;

            if (txtClient_Name.length <= 0) {
                jAlert('Client Name cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtClient_Name").focus(); });

                return false; ;
            }

            if (document.getElementById("txtDate_Installation").value == "") {
                jAlert('Date of Installation cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtDate_Installation").focus(); });

                return false;
            }
            if (isDate(document.getElementById("txtDate_Installation").value)) {

            }
            else {
                jAlert('Date of Installation is Invalid Date', 'COMPANY MASTER', function (r) { document.getElementById("txtDate_Installation").focus(); });

                return false;
            }
            var txtMobileNo;
            txtMobileNo = document.getElementById("txtMobileNo").value;

            if (txtMobileNo.length <= 0) {

                jAlert('Mobile No cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtMobileNo").focus(); });

                return false;
            }
            if (txtMobileNo.length < 10) {

                jAlert('Mobile No should be 10 digit numbers', 'COMPANY MASTER', function (r) { document.getElementById("txtMobileNo").focus(); });

                return false;
            }
            var txtClient_Address;
            txtClient_Address = document.getElementById("txtClient_Address").value;

            if (txtClient_Address.length <= 0) {

                jAlert('Client Address cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtClient_Address").focus(); });

                return false;
            }
            var txtPhoneNo;
            txtPhoneNo = document.getElementById("txtPhoneNo").value;

            if (txtPhoneNo.length <= 0) {

                jAlert('Phone No cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtPhoneNo").focus(); });

                return false;
            }
            var txtFax;
            txtFax = document.getElementById("txtFax").value;

            if (txtFax.length <= 0) {

                jAlert('Fax No cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtFax").focus(); });

                return false;
            }
//            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
//            var emailid = document.getElementById("txtEMailID").value;
//            var matchArray = emailid.match(emailPat);
//            if (document.getElementById("txtEMailID").value != "") {
//                if (matchArray == null) {

//                    jAlert('Email id not valid', 'COMPANY MASTER', function (r) { document.getElementById("txtEMailID").focus(); });


//                    return false;
//                }
//            }
            var txtContact_Person;
            txtContact_Person = document.getElementById("txtContact_Person").value;

            if (txtContact_Person.length <= 0) {

                jAlert('Contact Person cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtContact_Person").focus(); });

                return false;
            }
            var txtAlternate_No;
            txtAlternate_No = document.getElementById("txtAlternate_No").value;

            if (txtAlternate_No.length <= 0) {

                jAlert('Alternate No cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtAlternate_No").focus(); });

                return false;
            }
            var txtNo_Users;
            txtNo_Users = document.getElementById("txtNo_Users").value;

            if (txtNo_Users.length <= 0) {

                jAlert('No of Users cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtNo_Users").focus(); });

                return false;
            }
            if (document.getElementById("txtNext_Renewel_Date").value == "") {
                jAlert('Next Renewel Date cannot be blank', 'COMPANY MASTER', function (r) { document.getElementById("txtNext_Renewel_Date").focus(); });

                return false;
            }
            if (isDate(document.getElementById("txtNext_Renewel_Date").value)) {

            }
            else {
                jAlert('Next Renewel Date is Invalid Date', 'COMPANY MASTER', function (r) { document.getElementById("txtNext_Renewel_Date").focus(); });

                return false;
            }
        }
        //-----------------------------------  END ADCODE MASTER PAGE VALIDATION--------------------------------------//
    </script>
</body>
</html>
