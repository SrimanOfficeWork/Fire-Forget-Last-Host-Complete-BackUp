<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WareHouse_Master_UserWise.aspx.cs"
    Inherits="Port_Master_UserWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UserWise-Port Master</title>
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
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_Exchange">
                <div id="innerbox_MidMain_top_adcode">
                    WAREHOUSE MASTER - USER WISE
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_Exchange" style="height:185px">

                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Consigneename">
                            WareHouse Code
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_SmallCode">
                            <asp:TextBox ID="txt_Warehouse_Code" runat="server" MaxLength="8" CssClass="validate[required] txtbox_none_SmallCode"
                                TabIndex="3" onkeypress="return numchar(event)" onkeyup="ChangeCase(this);autotab(this);"
                                onfocus="ChangeCase(this);" onblur="ChangeCase(this);" ></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2">
                        <div id="tag_label_Consigneename">
                            WareHouse Name
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_Warehouse_Name" runat="server" MaxLength="50" onkeyup="ChangeCase(this);"
                                onfocus="ChangeCase(this);" onblur="ChangeCase(this);" CssClass="validate[required] txtbox_none_mid_size"
                                TabIndex="4" onkeypress="return numchar(event)"></asp:TextBox>                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>

                      <div id="pop_text_area_Size2">
                        <div id="tag_label_Consigneename">
                            WareHouse Addr
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txt_Warehouse_Address" runat="server" MaxLength="100" onkeyup="ChangeCase(this);"
                                onfocus="ChangeCase(this);" onblur="ChangeCase(this);" CssClass="validate[required] txtbox_none_mid_size"
                                TabIndex="4" onkeypress="return numchar(event)"></asp:TextBox>                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>

                     <div id="pop_text_area_Size2">
                        <div id="tag_label_Consigneename">
                            Remarks</div>
                        <div id="max_txtarea">
                            <div id="txtcon-t_Maxtxt">
                            </div>
                            <div id="txtcon-Mid_Maxtxt">
                                <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200" onkeyDown="return checkTextAreaMaxLength(this,event,'200');"
                                    onpaste="return checkTextAreaMaxLength(this,event,'200');" CssClass="txtbox_none_Maxtxt_Supplier"
                                    TextMode="MultiLine" TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="txtcon-b_Maxtxt">
                            </div>
                        </div>
                        <div id="lblMsg2" style="display: none;">
                        </div>
                    </div>

                </div>
                <div id="innerbox_MidMain_bot_Exchange">
                    <div id="innerbox_adcode_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                CssClass="new" OnClick="btnNew_Click" TabIndex="12" 
                                OnClientClick="jQuery('#form1').validationEngine('hide')" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate_NON_CURRENCY_MASTER();"
                                OnClick="btnSave_Click" TabIndex="10" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClientClick="return validate_NON_CURRENCY_MASTER()"
                                OnClick="btnUpdate_Click" TabIndex="10" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" OnClientClick="jConfirm('Delete this Entry?', 'USER WISE-PORT MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" CssClass="dlete" TabIndex="11" />
                            <asp:Button ID="btn" runat="server" TabIndex="11" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                tabindex="13" id="btnCancel" /></div>
                    </div>
                </div>
              
            </div>
                <asp:HiddenField ID="hdn_Update_Exchange" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
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
    </script>
</body>
</html>
