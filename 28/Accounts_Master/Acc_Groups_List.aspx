<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Groups_List.aspx.cs" Inherits="Acc_Groups_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Group Category | Updation</title>
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
           
            <div id="innerbox_MidMain_popup_adcode" style="width:500px;">
                <div id="innerbox_MidMain_top_adcode" style="width:490px;">
                    Category Master
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style=" height:100px;">
                    
                      <div id="pop_text_area" style="width:470px;">
                        <div id="tag_label_adcode">
                             Group List Code </div>
                        <div id="txtcon-m_src" style="width:350px;">
                                <asp:TextBox ID="txt_Group_List_Code" runat="server"  ClientIDMode="Static" MaxLength="100" Width="340px"
                                 TabIndex="2" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                        </div>
                    </div>

                    <div id="pop_text_area" style="width:470px;">
                        <div id="tag_label_adcode">
                              Group List Name </div>
                        <div id="txtcon-m_src" style="width:350px;"> 
                                <asp:TextBox ID="txt_Group_List_Name" runat="server"  ClientIDMode="Static"   MaxLength="200" Width="340px"
                                 TabIndex="5" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                        </div>
                    </div>

                     <div id="pop_text_area" style="width:470px;">
                        <div id="tag_label_adcode">
                             Remarks
                        </div>
                        <div id="txtcon-m_transaction_mode"  style="width:350px;">
                            <asp:TextBox ID="txt_Remarks" runat="server"  ClientIDMode="Static"  Width="340px"
                                 TabIndex="6" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                        </div>
                    </div>

                       
            </div>
            <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="20" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" TabIndex="17" />
                            
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"  TabIndex="17" />
                           
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="18" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'CHARGE MASTER', function(r) {
                          var i = r + 'ok';
                          if(i == 'trueok')
                          {
                              document.getElementById('btn').click();
                          }
                          else {
                          }
                         });return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="18" OnClick="btnDelete_Click" CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"  tabindex="19" id="btnCancel" />
                        <asp:HiddenField ID="HDupdate_id" runat="server" />
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
    
    
</body>
</html>

