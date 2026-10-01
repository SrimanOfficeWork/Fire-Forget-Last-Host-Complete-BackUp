<%@ Page Language="C#" AutoEventWireup="true" CodeFile="INV_XL_upload.aspx.cs" Inherits="INV_XL_upload" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>XL upload </title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />

    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />

    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
  
     <style type="text/css">
         .datagrid table { border-collapse: collapse; text-align: left; width: 100%; } .datagrid {font: normal 12px/150% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden; border: 1px solid #8C8C8C; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; }.datagrid table td, .datagrid table th { padding: 3px 10px; }.datagrid table thead th {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; color:#FFFFFF; font-size: 15px; font-weight: bold; border-left: 1px solid gray; } .datagrid table thead th:first-child { border: none; }.datagrid table tbody td { /*color: #7D7D7D;*/ border-left: 1px solid #DBDBDB;font-size: 12px;font-weight: normal; }.datagrid table tbody .alt td { background: #EBEBEB; color: #7D7D7D; }.datagrid table tbody td:first-child { border-left: none; }.datagrid table tbody tr:last-child td { border-bottom: none; }.datagrid table tfoot td div { border-top: 1px solid #8C8C8C;background: #EBEBEB;} .datagrid table tfoot td { padding: 0; font-size: 12px } .datagrid table tfoot td div{ padding: 2px; }.datagrid table tfoot td ul { margin: 0; padding:0; list-style: none; text-align: right; }.datagrid table tfoot  li { display: inline; }.datagrid table tfoot li a { text-decoration: none; display: inline-block;  padding: 2px 8px; margin: 1px;color: #F5F5F5;border: 1px solid #8C8C8C;-webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; }.datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover { text-decoration: none;border-color: #7D7D7D; color: #F5F5F5; background: none; background-color:#8C8C8C;}div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }
    
     /*td:nth-of-type(1) {display: none;}*/
     </style>

<script type="text/javascript">

    function chk_Show_details() {
        if (document.getElementById("chk_Notn_46").checked == true) {
            $("#chk_Notn_85").attr('checked', false);
          
        }
//        else {
//            $("#chk_Notn_85").attr('checked', false);
//            $("#chk_Notn_46").attr('checked', false);
//          
//        }
    }
</script>

<script type="text/javascript">

    function chk_Show_details_85() {

        if (document.getElementById("chk_Notn_85").checked == true) {
            $("#chk_Notn_46").attr('checked', false);
            
        }
//        else {
//            $("#chk_Notn_85").attr('checked', false);
//            $("#chk_Notn_46").attr('checked', false);
//            
//        }
    }
</script>
    
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


       
            <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 500px;">
                    <div id="innerbox_MidMain_top_adcode_Itemmove" style="width: 500px;">
                       Nissan Excel Upload 
                        <div id="popupwindow_closebut_right">
                            <%--<input type="close" value="Submit" class="clsicon" onclick="$find('mp_Nissan_Excel').hide();" />--%>
                            <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                        </div>
                    </div>
                <div id="innerbox_MidMain_Mid_adcode_Itemmove1" style="height: 250px;">

                    <div id="pop_text_area_ItemMove" style="width: 400px">
                        <div id="tag_label_adcode">
                            Select Type</div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:DropDownList ID="ddlInv_Upload" CssClass="txtbox_none_Mid_transac_others_Name"
                                AutoPostBack="true" Font-Size="12px" runat="server" TabIndex="3">
                                <asp:ListItem Text="China PARTS" Value="China PARTS" ></asp:ListItem>
                                <asp:ListItem Text="China Rack" Value="China Rack" > </asp:ListItem>
                                <asp:ListItem Text="Thailand Parts" Value="Thailand Parts"  ></asp:ListItem>
                                <asp:ListItem Text="Thailand Rack" Value="Thailand Rack" ></asp:ListItem>
                                <asp:ListItem Text="France Parts" Value="France Parts">  </asp:ListItem>
                            </asp:DropDownList  >
                        </div>
                        <div id="magnify_area" style="width: 30px">
                        </div>
                        <div id="txtcon_transac_checkbox">
                        <input type="checkbox" id="chk_Notn_46" runat="server" onclick="chk_Show_details();"/>
                            <%--<asp:CheckBox ID="chk_Notn_46" runat="server" Checked="false" TabIndex="28" />--%>
                        </div>
                        <div id="tag_label_adcode" style="width: 70px">
                        <asp:Label ID="lbl_46" runat="server" Text="046/2011"></asp:Label>
                           
                        </div>
                    </div>

                    <div id="pop_text_area_ItemMove" style="width: 398px">
                        <div id="tag_label_adcode">
                            Select Excel File</div>
                        <div id="txtcon-m_src_ItemMove">
                            <asp:FileUpload ID="fileuploadExcel" runat="server" />
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="txtcon_transac_checkbox">
                          <input type="checkbox" id="chk_Notn_85" runat="server" onclick="chk_Show_details_85();"/>
                            <%--<asp:CheckBox ID="chk_Notn_85" runat="server" Checked="false" TabIndex="28" />--%>
                        </div>
                        <div id="tag_label_adcode" style="width: 70px">
                        <asp:Label ID="lbl_85" runat="server" Text="085/2004"></asp:Label>
                            
                        </div>
                    </div>

                </div>
                </div>
                  <div id="innerbox_MidMain_top_adcode_Itemmove" style="width: 500px; height: 40px;">
                    <div id="innerbox_adcode_bot_inn_ItemMove" style="padding-right: 225px;">
                        <div id="editbu">

                                   <asp:Button ID="btnImportInvUpload" runat="server" CssClass="autowidmovebut" Text="Upload"
                                TabIndex="115" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                OnClick="btnImportInvUpload_Click" />
                                <asp:Button ID="btn1" runat="server" Visible="false" />

                                
                        </div>
                    </div>
                </div>
              
              <asp:TextBox ID="errorlist" runat="server" TextMode="MultiLine" Width="480px" Height="60px"></asp:TextBox>
                <%-----------------------------------END----------------------------------------------------------------%>
          
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>

           
           </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  
   <script  src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>

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
