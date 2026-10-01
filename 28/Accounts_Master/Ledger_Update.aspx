<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ledger_Update.aspx.cs" Inherits="Ledger_Update" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Group Master | Updation</title>
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

    <script type="text/javascript">
        
        function HideModalPopup_Job() {

            $find("MP_JOB").hide();
            return false;
        }
        
        function ShowModalPopup_Job() {

            $find("MP_JOB").show();
            return false;
        }
        
</script>

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
           
            <div id="innerbox_MidMain_popup_adcode">
                <div id="innerbox_MidMain_top_adcode">
                    GROUP MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style="height:410px;">

                    <div id="pop_text_area" style=" width:450px;">
                        <div id="tag_label_adcode">
                            Ledger
                        </div>
                        <div id="txtcon-m_transaction_mode" style="width:320px;">
                           <asp:DropDownList ID="ddlLedger" runat="server" Width="315px" CssClass="listtxt_transac_mode_new" TabIndex="2" >                                                      
                            </asp:DropDownList> 
                        </div>
                    </div>
                    <div id="pop_text_area" style=" width:450px;">
                            <div id="tag_label_adcode" style="color:Blue">
                                New Ledger
                            </div>
                            <div id="txtcon-m_transaction_mode" style="width:320px;">
                                <asp:TextBox ID="Txt_Ledger_N" runat="server" Width="310px" MaxLength="200" CssClass="txtbox_none"  ClientIDMode="Static" TabIndex="3" ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                  
                    <div id="pop_text_area" style="width: 450px;">
                        <div id="tag_label_adcode">
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:Button ID="btn_Leg_Update" Text="Update" CssClass="autowidmovebut" runat="server" TabIndex="4"
                                Width="60px" onclick="btn_Leg_Update_Click" />
                        </div>
                    </div>
                      <div id="pop_text_area" style="width: 450px;">
                        <div id="tag_label_adcode">
                        </div>
                        <div id="txtcon-m_transaction_mode">
                        </div>
                    </div>
                    <div id="pop_text_area"  style=" width:450px;">
                        <div id="tag_label_adcode">
                            Sub Group
                        </div>
                        <div id="txtcon-m_transaction_mode" style="width:320px;">
                           <asp:DropDownList ID="ddlSubGroup" runat="server" Width="315px" CssClass="listtxt_transac_mode_new" TabIndex="5" >                               
                            </asp:DropDownList>
                        </div>
                    </div>
                     
                      <div id="pop_text_area" style=" width:450px;">
                            <div id="tag_label_adcode" style="color:Blue">
                                New Sub Group
                            </div>
                            <div id="txtcon-m_transaction_mode" style="width:320px;">
                                <asp:TextBox ID="Txt_Sub_Group_N" runat="server" Width="310px" MaxLength="200" CssClass="txtbox_none"  ClientIDMode="Static" TabIndex="6" ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area" style="width: 450px;">
                        <div id="tag_label_adcode">
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:Button ID="btn_SG_Update" Text="Update" CssClass="autowidmovebut" runat="server" TabIndex="7"
                                Width="60px" onclick="btn_SG_Update_Click" />
                        </div>
                    </div>
                      <div id="pop_text_area" style="width: 450px;">
                        <div id="tag_label_adcode">
                        </div>
                        <div id="txtcon-m_transaction_mode">
                        </div>
                    </div>
                     <div id="pop_text_area" style=" width:450px;">
                        <div id="tag_label_adcode">
                            Group name
                        </div>
                        <div id="txtcon-m_transaction_mode" style="width:320px;">
                           <asp:DropDownList ID="ddlGroup" runat="server" Width="315px" CssClass="listtxt_transac_mode_new" TabIndex="8" >
                                                              
                            </asp:DropDownList>
                        </div>
                    </div>
                      <div id="pop_text_area" style=" width:450px;">
                            <div id="tag_label_adcode" style="color:Blue">
                                New Group
                            </div>
                            <div id="txtcon-m_transaction_mode" style="width:320px;">
                                <asp:TextBox ID="Txt_Group_N" runat="server" Width="310px"  MaxLength="200" CssClass="txtbox_none"  ClientIDMode="Static" TabIndex="9" ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                   <div id="pop_text_area" style="width: 450px;">
                        <div id="tag_label_adcode">
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:Button ID="btn_G_Update" Text="Update" CssClass="autowidmovebut" runat="server" TabIndex="10"
                                Width="60px" onclick="btn_G_Update_Click" />
                        </div>
                    </div>
                      <div id="pop_text_area" style="width: 450px;">
                        <div id="tag_label_adcode">
                        </div>
                        <div id="txtcon-m_transaction_mode">
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