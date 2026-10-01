<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exp_Sup_Doc_delete.aspx.cs" Inherits="Exp_Sup_Doc_delete" %> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export Sup.Docs Delete</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />

    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />

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
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain" style="height:32px;">
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 120px;">
                      Sup.Docs Delete</div>
                
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 210px;">
                                <div id="tag_label_transact_Src" style="width: 50px;">
                                  </div>
                                <div id="txtcon-m_Exchange" style="width: 160px;">
                                 <%--   <asp:DropDownList ID="ddlinvno" CssClass="listtxt_transac_item_gen_notn" Width="150px"  Font-Size="12px" runat="server"  TabIndex="3" >
                                    </asp:DropDownList>--%>
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

                <div class="content" id="page-1" style="margin-left:-30px; margin-top:-15px; width:1110px;">
                 <div id="pop_text_area_transac_popup_inn_container_export" style="width:405px;">
               
               <div id="pop_text_area_transac_popup_inn_container_left_export" style="width:390px;">

                   <div id="tag_transac_lft_in1_export" style="width:300px;">
                       <div id="tag_label_transaction_popup_gen_export" style="width:70px;">
                           Inv. No
                       </div>
                       <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width:200px;">
                             <asp:DropDownList ID="ddlinvno" CssClass="listtxt_transac_item_gen_notn" Width="190px"  Font-Size="12px" runat="server"  TabIndex="3" >
                              </asp:DropDownList>
                       </div>
                   </div>
                    <div id="tag_transac_lft_in1_export" style="width:90px;">
                    <div id="tag_label_transaction_popup_gen_export" style="width:10px;">
                            &nbsp;
                    </div>
                    </div>


                   <div id="tag_transac_lft_in1_export" style="width:90px;">
                       <div id="tag_label_transaction_popup_gen_export" style="width:10px;">
                       </div>
                       <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width:80px;">
                          <asp:Button ID="btnDelete" runat="server" Width="80px"  CssClass="autowidnewbut" OnClick="btnDelete_Click"
                                     Text="Delete" TabIndex="3" UseSubmitBehavior="false" />
                       </div>
                   </div>

               </div>

               </div>

                 </div>
              
                <%-----------------------------------END----------------------------------------------------------------%>
          
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>

            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static"/>
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


   <%-- <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>--%>
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
