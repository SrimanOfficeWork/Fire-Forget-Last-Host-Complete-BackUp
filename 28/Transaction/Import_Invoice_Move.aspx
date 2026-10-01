<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_Invoice_Move.aspx.cs" Inherits="Import_Invoice_Move" %> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Invoice Move</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />

    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain" style="height: 32px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                        Import Invoice Move
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 390px;">
                        <div id="tag_label_transact_Src" style="width: 56px;">
                            
                            </div>
                        <div id="txtcon-m_Exchange" style="width: 120px;">
                         
                        </div>
                    </div>
                    <div id="popupwindow_closebut_left_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
            </div>
           <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
             </div>
            <div class="content" id="page-1" style="margin-top: -15px; width: 1110px;">
                <div id="pop_text_area_transac_popup_inn_container_export" style="width: 595px;">

                    <div id="pop_text_area_transac_popup_inn_container_left_export" style="border-style: solid;
                        width: 280px; border-right: thick double #ff0000;">

                        <div id="tag_transac_lft_in1_export" style="width: 130px;">
                            <div id="tag_label_transaction_popup_gen_export" style="width: 120px; font-weight: bold;
                                margin-left: -17px;">
                                InterChange Data:-
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1_export" style="width: 270px;">
                            <div id="tag_label_transaction_popup_gen_export" style="width: 100px;">
                                From Inv. No.
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 170px;">
                                <asp:DropDownList ID="ddlInvFrom" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new" Width="160px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1_export" style="width: 270px;">
                            <div id="tag_label_transaction_popup_gen_export" style="width: 100px;">
                                To Inv. No.
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 170px;">
                                <asp:DropDownList ID="ddlInvTo" runat="server" TabIndex="2" CssClass="listtxt_transac_mode_new" Width="160px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1_export" style="width: 270px;">
                            <div id="tag_label_transaction_popup_gen_export" style="width: 10px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 80px;">
                                <asp:Button ID="btnMove_Item" runat="server" Width="80px" CssClass="autowidnewbut"
                                    OnClick="btnMove_Item_Click" Text="Interchange" TabIndex="3" UseSubmitBehavior="false" />
                            </div>
                        </div>
                    </div>
                    <%-----------------------------------END----------------------------------------------------------------%>
                    <div id="pop_text_area_transac_popup_inn_container_rght_new_export" style="border-style: solid;  
                        width: 310px;">
                        <div id="tag_transac_lft_in1_export" style="width: 130px; ">
                            <div id="tag_label_transaction_popup_gen_export" style="width: 110px; font-weight: bold; ">
                                Arrange Data :-
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1_export" style="width: 270px;">
                            <div id="tag_label_transaction_popup_gen_export" style="width: 100px;">
                                Select Inv. No
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 170px;">
                                <asp:DropDownList ID="A_ddlInvFrom" runat="server" Width="170px" TabIndex="5" CssClass="listtxt_transac_mode_new">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1_export" style="width: 270px;">
                            <div id="tag_label_transaction_popup_gen_export" style="width: 100px;">
                                Go Inv Position
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 170px;">
                                <asp:DropDownList ID="A_ddlInvTo" runat="server" Width="170px" TabIndex="6" CssClass="listtxt_transac_mode_new">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1_export" style="width: 270px;">
                            <div id="tag_label_transaction_popup_gen_export" style="width: 10px;">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 80px;">
                                <asp:Button ID="btnarrange" runat="server" Width="80px" TabIndex="7" CssClass="autowidnewbut"
                                     Text="Arrange" UseSubmitBehavior="false" OnClick="btnarrange_Item_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
              
                <%-----------------------------------END----------------------------------------------------------------%>
          
           
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
        function close_button() {
            document.getElementById("General").click();
        }
        
    </script>

    
</body>
</html>
