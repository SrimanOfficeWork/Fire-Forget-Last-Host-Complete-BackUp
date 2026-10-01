
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login_Details.aspx.cs" Inherits="Admin_Login_Details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <title>Database Details</title>
   <script src="../js/listpopup.js" type="text/javascript"></script>
     <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection"  />
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
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-6').style.display = 'none';
        document.getElementById('page-7').style.display = 'none';
        document.getElementById("LoginId").className = 'inactive';
    }
    function tab_page2() {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'Block';
        document.getElementById('page-3').style.display = 'none';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-6').style.display = 'none';
        document.getElementById('page-7').style.display = 'none';
    }
    function tab_page3() {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'Block';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-6').style.display = 'none';
        document.getElementById('page-7').style.display = 'none';
        document.getElementById("Trans_Comp_Iframe").src = "../Admin/Branch_Port_Details.aspx";
    }
    function tab_page4() {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'Block';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-6').style.display = 'none';
        document.getElementById('page-7').style.display = 'none';
        document.getElementById("Trans_Comp_Iframe").src = "../Admin/User_Branch_Master.aspx";
    }
    function tab_page5() {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'Block';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-6').style.display = 'none';
        document.getElementById('page-7').style.display = 'none';
        document.getElementById("Trans_Comp_Iframe").src = "../Admin/User_Permission_Master.aspx";
    }
    function tab_page6() {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'Block';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-6').style.display = 'none';
        document.getElementById('page-7').style.display = 'none';
        document.getElementById("Trans_Comp_Iframe").src = "../Admin/Group_Creation.aspx";
    }
    function tab_page7() {
        document.getElementById('page-1').style.display = 'none';
        document.getElementById('page-2').style.display = 'none';
        document.getElementById('page-3').style.display = 'Block';
        document.getElementById('page-4').style.display = 'none';
        document.getElementById('page-5').style.display = 'none';
        document.getElementById('page-6').style.display = 'none';
        document.getElementById('page-7').style.display = 'none';
        document.getElementById("Trans_Comp_Iframe").src = "../Admin/Area_Branch_Mapping_Details.aspx";
    }
        </script>            
            

</head>

<body style="background-color:#ffffff;">
    <form id="form1" runat="server">           

      <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" EnablePageMethods="true">
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
                        id="Database_ID"><span>DataBase Details</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                        id="LoginId" runat="server" style="display: none;"><span>User Login</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3();"
                        id="Branch_DETAILS_ID" runat="server" style="display: none;"><span>CHA Branch Details</span></a></li>
                    <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4();"
                        id="User_Branch" runat="server" style="display: none;"><span>User Branch Details</span></a></li>
                    <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5();"
                        id="User_Permission" runat="server" style="display: none;"><span>User Permission Details</span></a></li>
                    
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');tab_page6();"
                        id="GroupCreation" runat="server" style="display: none;"><span>Group Creation</span></a></li>

                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');tab_page7();"
                        id="Group_Modify" runat="server" style="display: none;"><span>Group Modification</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_area_company_master1_det">
                        <div id="tag_transac_lft_comp_mas_in1">
                            <div id="tag_label_comp_master1">
                                Server Name</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtServerName" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    MaxLength="50" TabIndex="7"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_comp_master1">
                                DataBase Name</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtDatabaseName" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    MaxLength="50" TabIndex="8"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_comp_mas_in1">
                            <div id="tag_label_comp_master1">
                                Login Name</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtLogin_Name" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    MaxLength="50" TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_comp_master1">
                                Password</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtLogin_Pwd" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    MaxLength="50" TabIndex="10"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_comp_mas_in1">
                            <div id="tag_label_comp_master1">
                                Working Period</div>
                            <div id="txtcon-m_com_mas_new">
                                <asp:DropDownList ID="ddl_Workingperiod" runat="server" TabIndex="11" CssClass="listtxt_comp_mas_new">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_comp_master1">
                                Select Job</div>
                            <div id="txtcon-m_com_mas_new">
                                <asp:DropDownList ID="ddlSelect_Job" runat="server" TabIndex="12" CssClass="listtxt_comp_mas_new">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact_invoice">
                            <div id="newbu">
                                <asp:Button ID="btnDatabase_New" runat="server" CssClass="new" OnClick="btnDatabase_New_Click"
                                    TabIndex="17" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDatabase_Save" runat="server" CssClass="save" OnClick="btnDatabase_Save_Click "
                                    TabIndex="15" OnClientClick="return validate_Database();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDatabase_Update" runat="server" CssClass="updates" OnClick="btnDatabase_Update_Click"
                                    TabIndex="15" OnClientClick="return validate_Database();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDatabase_Delete" runat="server" TabIndex="16" Visible="false"
                                    CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'LOGIN & DATABASE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('Button1').click();
            
          }
          else {
          }
    
});return false;" />
                                <asp:Button ID="Button1" runat="server" TabIndex="16" OnClick="btnDatabase_Delete_Click"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');" CssClass="dlete"
                                    Style="display: none;" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('Company_Page');return false;"
                                    TabIndex="18" CausesValidation="false" UseSubmitBehavior="false" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_comp_mas_in1_gridarea2" style="width: 930px; height: 200px;">
                            <asp:GridView ID="gvdetails" runat="server" DataKeyNames="DATABASE_ID" EmptyDataText="NO RECORD FOUND"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                ShowHeaderWhenEmpty="True" PageSize="12" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                                OnPageIndexChanging="gvdetails_PageIndexChanging" OnSelectedIndexChanged="gvdetails_SelectedIndexChanged"
                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="COMPANY_LICENSE" HeaderText="Com. Lic">
                                        <ItemStyle CssClass="column_style_left5" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SERVER_NAME" HeaderText="Server Name">
                                        <ItemStyle CssClass="column_style_left5" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DATABASE_NAME" HeaderText="Database Name">
                                        <ItemStyle CssClass="column_style_left5" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LOGIN_NAME" HeaderText="Login Name">
                                        <ItemStyle CssClass="column_style_left5" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PWD" HeaderText="PWD">
                                        <ItemStyle CssClass="column_style_left5" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="WORKING_PERIOD" HeaderText="Working period">
                                        <ItemStyle CssClass="column_style_left5" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SELECT_JOB" HeaderText="SELECT_JOB">
                                        <ItemStyle CssClass="column_style_left5" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <%--</div>--%>
                    </div>
                </div>
                <div class="content" id="page-2" style="display: none;">
                    <div id="Login_page" runat="server" style="display: none;">
                        <div id="tag_transac_lft_comp_mas_in1">
                            <div id="tag_label_comp_master1">
                                User Name</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    MaxLength="50" TabIndex="1"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_comp_master1">
                                Password</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtPwd" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    MaxLength="50" TabIndex="2"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_label_comp_master1">
                        </div>
                        <div id="innerbox_MidMain_bot_transact_invoice">
                            <div id="newbu">
                                <asp:Button ID="btnLogin_New" runat="server" CssClass="new" OnClick="btnLogin_New_Click"
                                    TabIndex="5" CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnLogin_Save" runat="server" CssClass="save" OnClick="btnLogin_Save_Click"
                                    TabIndex="3" OnClientClick="return validate_Login();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnLogin_Update" runat="server" CssClass="updates" OnClick="btnLogin_Update_Click"
                                    TabIndex="3" OnClientClick="return validate_Login();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnLogin_Delete" runat="server" TabIndex="4" Visible="false" CssClass="dlete"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'LOGIN & DATABASE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn1').click();
            
          }
          else {
          }
    
});return false;" />
                                <asp:Button ID="btn1" runat="server" TabIndex="4" OnClick="btnLogin_Delete_Click"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');" CssClass="dlete"
                                    Style="display: none;" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="Button2" runat="server" class="scancel" OnClientClick="activatables('page', ['page-1']);tab_page1('');return false;"
                                    TabIndex="6" CausesValidation="false" UseSubmitBehavior="false" />
                                <%--<input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()" tabindex="6" />--%>
                            </div>
                        </div>
                        <div id="tag_transac_lft_comp_mas_in1">
                            <div id="tag_label_comp_master1">
                            </div>
                            <div id="magnify_area">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-3" style="display: none; padding-top: 0px;">
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
                </div>
                <asp:HiddenField ID="hdn_Company_ID" runat="server" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hdn_update_Database" runat="server" />
                <asp:HiddenField ID="hdn_User_Status" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
  
    </form>
     <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7']);
            </script>
    <script type="text/javascript">
       
        function validate_Login() {
            var txtUserName;
            txtUserName = document.getElementById("txtUserName").value;

            if (txtUserName.length <= 0) {

                jAlert('User Name cannot be blank', 'LOGIN & DATABASE', function (r) { document.getElementById("txtUserName").focus(); });
                return false;
            }


            var txtPwd;
            txtPwd = document.getElementById("txtPwd").value;

            if (txtPwd <= 0) {
                jAlert('Pwd cannot be blank', 'LOGIN & DATABASE', function (r) { document.getElementById("txtPwd").focus(); });

                return false; ;
            }
        }
        function validate_Database() {
            var txtServerName;
            txtServerName = document.getElementById("txtServerName").value;

            if (txtServerName.length <= 0) {

                jAlert('Server Name cannot be blank', 'LOGIN & DATABASE', function (r) { document.getElementById("txtServerName").focus(); });

                return false;
            }


            var txtDatabaseName;
            txtDatabaseName = document.getElementById("txtDatabaseName").value;

            if (txtDatabaseName <= 0) {
                jAlert('Database Name cannot be blank', 'LOGIN & DATABASE', function (r) { document.getElementById("txtDatabaseName").focus(); });

                return false; ;
            }

            var txtLogin_Name;
            txtLogin_Name = document.getElementById("txtLogin_Name").value;

            if (txtLogin_Name.length <= 0) {

                jAlert('Login Name cannot be blank', 'LOGIN & DATABASE', function (r) { document.getElementById("txtLogin_Name").focus(); });

                return false;
            }

            var txtLogin_Pwd;
            txtLogin_Pwd = document.getElementById("txtLogin_Pwd").value;

            if (txtLogin_Pwd.length <= 0) {

                jAlert('Login Pwd cannot be blank', 'LOGIN & DATABASE', function (r) { document.getElementById("txtLogin_Pwd").focus(); });

                return false;
            }
        }
       
    </script>
</body>
</html>
