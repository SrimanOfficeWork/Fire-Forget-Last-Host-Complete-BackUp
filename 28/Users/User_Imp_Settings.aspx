<%@ Page Language="C#" AutoEventWireup="true" CodeFile="User_Imp_Settings.aspx.cs" Inherits="User_Imp_Settings" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

   <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>User Permission Master</title>
    

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
            <div class="content" id="page-1" style="height:280px;">
                <div id="tag_transac_lft_comp_mas_in1" style="width: 820px">
                    <div id="tag_label_comp_master1">
                        Select Branch
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <%--<asp:DropDownList ID="ddlLoad_Branch" runat="server" AutoPostBack="true" CssClass="listtxt_comp_mas"
                            TabIndex="12" OnSelectedIndexChanged="ddlLoad_Branch_SelectedIndexChanged">
                        </asp:DropDownList>--%>

                        <asp:DropDownList ID="ddlGroupname" runat="server" CssClass="listtxt-s"  AutoPostBack="true"
                                            TabIndex="4" ClientIDMode="Static"  Width="100px" onselectedindexchanged="ddlGroupname_SelectedIndexChanged"    >  
                                        </asp:DropDownList>
                    </div>

                    <div id="txtcon-m_transaction_Supp_code">
                    <asp:DropDownList ID="ddlLoad_Branch" runat="server" CssClass="listtxt-s" TabIndex="5"
                                            ClientIDMode="Static" Width="125px">
                                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_export_lft_item_gen_Grid_comp" style="width: 700px; height: 270px;">  
                <div id="tag_transac_lft_comp_mas_in1"></div>
                <div id="tag_transac_lft_comp_mas_in1" style="width:820px">
                 <div id="tag_label_comp_master1"  style="width:120px;font-weight:bold; padding-left:5px">
                     Page Name
                    </div>
                    <div id="tag_label_comp_master1"  style="width:220px;font-weight:bold">
                        Action Name
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="font-weight:bold">
                        Action Settings
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width: 820px">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        GENERAL
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                        Job Edit
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_Job_edit" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                
                <%--<div id="tag_transac_lft_comp_mas_in1" style="width: 820px">
                    <div id="tag_label_comp_master1" style="width: 120px">
                        INVOICE
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                        Buyer Address Edit
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_Buyer_Add" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>--%>
                <div id="tag_transac_lft_comp_mas_in1" style="width: 820px">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        ITEM
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                        Addl Duty Imports Entry field
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_AddlDutyImports" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width: 820px">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        ITEM
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                      Default IGST EXCEMPTION Notn
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_Default_IGST_Excepn_Notn" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                   <div id="tag_transac_lft_comp_mas_in1" style="width: 820px;height: 40px;">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        ITEM
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                      GENERAL DESCRIPTION SAME AS ITEM DESCRIPTION
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_General_Det" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                  <div id="tag_transac_lft_comp_mas_in1" style="width: 820px;height: 40px;">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        LICENSE
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                      IGST Exemption notification same as License scheme Notn
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_License_Det" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>





                <div id="tag_transac_lft_comp_mas_in1" style="width: 820px">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        CHECKLIST
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                        General Details Show
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_GeneralDetails" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width: 820px">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        CHECKLIST
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                        Manufacturer Details Show
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_ManufacturerDetails" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width: 820px">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        CHECKLIST
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                        Seller Details Show
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_SellerDetails" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width: 820px">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        FLATFILE
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                        Declaration - STMT TEXT Move
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_FF_STMTTEXT" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="tag_transac_lft_comp_mas_in1" style="width: 820px">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        FLATFILE
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                        SW_INFO_TYPE - FTA details should move for Exbond
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_FF_FTA_Exbond" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>


                    <div id="tag_transac_lft_comp_mas_in1" style="width: 820px;margin-top:18px;">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        FLATFILE
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                           Allow Without RE Bond For Notn-045/2025-I414
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_FF_Allow_RE_Bond_Notn" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E">Enable</asp:ListItem>
                            <asp:ListItem Value="D" Selected="True">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                   </div>


                        <div id="tag_transac_lft_comp_mas_in1" style="width: 820px;margin-top:18px;">
                    <div id="tag_label_comp_master1" style="width: 120px; padding-left:5px">
                        GENERAL
                    </div>
                    <div id="tag_label_comp_master1" style="width: 220px">
                           User-Role Wise Milesstone.
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:RadioButtonList ID="rdl_General_Role_Wise_Milesstone" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="E" Selected="True">Enable</asp:ListItem>
                            <asp:ListItem Value="D">Disable</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                   </div>



                </div>   
            </div>
            <div id="innerbox_MidMain_bot_transact_invoice" style="margin-top:19px">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" TabIndex="19"
                        CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="17"
                        OnClientClick="return validate_Company();" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" TabIndex="17" OnClientClick="return validate_Company();"
                        OnClick="btnUpdate_Click" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="18" Visible="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'USER', function(r) {
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
                        TabIndex="19" CausesValidation="false" UseSubmitBehavior="false" />
                    <%--<input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()" />--%></div>
            </div>

             <asp:HiddenField ID="hdn_Company_ID" runat="server" />
                        <asp:HiddenField ID="hdn_User_Creation_Id" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
            
                <script src="../activatables.js" type="text/javascript"></script>
                <script type="text/javascript">
                    activatables('page', ['page-1', 'page-2', 'page-3', 'page-4']);
                </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>

</body>
</html>
