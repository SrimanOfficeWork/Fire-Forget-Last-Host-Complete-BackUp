
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Exp_Job_Status.aspx.cs" Inherits="Imp_Job_Status" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Main Master</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection"
        type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>


</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            
            <div id="innerbox_MidMain_Transact_popup_new" style="height:300px;">
                <div id="tag_srcinner1_new">
                
                    <div id="mainmastop2container_rght_tag2_txt1">
                        <asp:Literal ID="lbl_Head" runat="server"></asp:Literal>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transaction_inner_new">
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new">
                            Job No 
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtJobNo" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="10" ReadOnly="True" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_date">
                            <asp:Literal ID="lbl_be_Sb" runat="server"></asp:Literal>
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txt_BE_SB" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                MaxLength="10" ReadOnly="True" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                       
                    </div>
                    <div id="tag_Exchange_lft_in1_new1"></div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new">
                            Tr. Mode 
                        </div>
                        <div id="txtcon-m_transaction_code" >
                            <span style="color: Green; font-weight: bold;">
                                <asp:Literal ID="lbl_tr_mode" runat="server"></asp:Literal></span>
                        </div>
                      <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_transaction_date">
                            Custom House 
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <span style="color: Green; font-weight: bold;">
                                <asp:Literal ID="lbl_Cus_House" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                     <div id="tag_Exchange_lft_in1_new1"></div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new">
                            Job Status 
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <span style="color: Green; font-weight: bold;">
                                <asp:Literal ID="lbl_Job_Status" runat="server"></asp:Literal></span>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                      <%--  <div id="tag_label_transaction_date">
                        </div>--%>
                        <div id="txtcon-m_transaction_code">
                            <asp:Button ID="btn_Cancel" runat="server" Text="Job Cancel" Visible="false" OnClick="btn_Cancel_Click" />
                            <asp:Button ID="btn_Re_Open" runat="server" Text="Re-Open" Visible="false" onclick="btn_Re_Open_Click" />
                        </div>
                         
                    </div>

                    <div id="tag_Exchange_lft_in1_new1"></div>
                     <div id="tag_Exchange_lft_in1_new1">
                    <div id="txtcon-m_transaction_code" style="width: 350px;">
                            <span style="color: Green; font-weight: bold;">
                                <asp:Literal ID="lbl_Cancel_msg" runat="server"></asp:Literal></span>
                        </div>
                       
                    </div>

                </div>
            </div>
            
              

            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>

    </form>
   
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    
</body>
</html>
