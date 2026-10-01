<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RTS_EL_Mapping_Master.aspx.cs"
    Inherits="Admin_Mapping_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RTS-ELogix Mapping Master</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div style="height: 450px; width: 650px">
                <div id="innerbox_MidMain_top_adcode" style="width: 650px" >
                    RTS-ELogix Mapping Master
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style="width: 650px">
                    <div id="pop_text_area" style="margin-left: 10px; width: 650px" >
                        <div id="tag_label_adcode" style="width: 150px">
                            ERoyal License</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtERI_License" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="1" MaxLength="20"></asp:TextBox>
                        </div>
                   
                        <div id="tag_label_adcode" style="width: 150px">
                            E-Logix License</div>
                        <div id="txtcon-m_transaction_Supp_code" style="margin-left:-10px;">
                            <asp:TextBox ID="txtELogix_License" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="2" MaxLength="20"></asp:TextBox>
                        </div>
                    </div>
                    <div id="pop_text_area" style="margin-left: 10px; width: 650px">
                        <div id="tag_label_adcode" style="width: 150px">
                            ERoyal UserName</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtERoyalUserName" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="3" MaxLength="20"></asp:TextBox>
                        </div>
                  
                        <div id="tag_label_adcode" style="width: 150px">
                            E-Logix UserName</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtELogixUserName" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="4" MaxLength="20"></asp:TextBox>
                        </div>
                    </div>

                    <div id="pop_text_area" style="margin-left: 10px; width: 650px">
                        <div id="tag_label_adcode" style="width: 150px">
                            ERoyal Branch</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtERoyalBranch" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="5" MaxLength="20"></asp:TextBox>
                        </div>
                  
                        <div id="tag_label_adcode" style="width: 150px">
                            E-Logix Branch</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtELogixBranch" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="6" MaxLength="20"></asp:TextBox>
                        </div>
                    </div>

                      <div id="pop_text_area" style="margin-left: 10px; width: 650px">
                        <div id="tag_label_adcode" style="width: 150px">
                            ERoyal WorkingPeriod</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtERoyalWP" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="7" MaxLength="20"></asp:TextBox>
                        </div>
                    
                        <div id="tag_label_adcode" style="width: 150px" >
                            E-Logix WorkingPeriod</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtELogixWP" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="8" MaxLength="20"></asp:TextBox>
                        </div>
                    </div>
                     <div id="pop_text_area" style="margin-left: 10px; width: 650px">
                      <div id="tag_label_adcode" style="width: 150px">
                            IsActive</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:CheckBox ID="chkIsActive" runat="server" TabIndex="9"   Checked="true"/>
                        </div>
                         <div id="tag_label_adcode" style="width: 150px" >
                            Company Name</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCompanyName" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="10" MaxLength="20"></asp:TextBox>
                        </div>

                     </div>

                    <div id="innerbox_MidMain_top_adcode" style="margin-left: 10px; width: 650px ; margin-top:70px"  >
                        <div id="innerbox_adcode_bot_inn">
                        <div id="editbu" style="margin-left: 200px" >
                                <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="14" OnClick="btnNew_Click" />
                            </div>

                            <div id="editbu" >
                                <asp:Button ID="btnSave" runat="server" CssClass="save" TabIndex="11" OnClientClick="return ValidationPage();" OnClick="btnSave_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" TabIndex="12" OnClick="btnUpdate_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDelete" runat="server" CssClass="dlete" TabIndex="13" OnClick="btnDelete_Click" />
                            </div>
                            <div id="editbu">
                                <input type="submit" value="" class="scancel" onclick="win_hide();parent.adcodewindow.hide();return false;"
                                    tabindex="15" id="btnCancel" />
                                <asp:HiddenField ID="hdnMapID" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
               
            </div>
           
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
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

      

        } 

    </script>

     <script type="text/javascript">

         function ValidationPage() {
          
             var RTSLicense = document.getElementById("txtERI_License").value;
             if (RTSLicense.length <= 0) {
                 jAlert('Enter RTS License', 'Mapping Master', function (r) { document.getElementById("txtERI_License").focus(); });
                 return false;
             }

             var ELogixLicense = document.getElementById("txtELogix_License").value;
             if (ELogixLicense.length <= 0) {
                 jAlert('Enter Elogix License', 'Mapping Master', function (r) { document.getElementById("txtELogix_License").focus(); });
                 return false;
             }

             var RTSUserName = document.getElementById("txtERoyalUserName").value;
             if (RTSUserName.length <= 0) {
                 jAlert('Enter RTS UserName', 'Mapping Master', function (r) { document.getElementById("txtERoyalUserName").focus(); });
                 return false;
             }

             var ELogixUserName = document.getElementById("txtELogixUserName").value;
             if (ELogixLicense.length <= 0) {
                 jAlert('Enter ELogix UserName', 'Mapping Master', function (r) { document.getElementById("txtELogixUserName").focus(); });
                 return false;
             }



         }


    </script>


</body>
</html>
