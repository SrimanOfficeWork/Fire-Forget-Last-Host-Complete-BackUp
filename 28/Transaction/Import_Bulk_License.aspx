<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_Bulk_License.aspx.cs" Inherits="Import_Bulk_License" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Bulk License upload </title>
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
       
        #Validation123
        {
            top: 31% !important;
            left: 56% !important;
            max-width: 95% !important;
            background-color: #fbdbdb !important;
            border: 3px solid #cc6b4d;
        }
        .pagination span.disabled
        {
            margin: 0 -9px 0 1px;
        } 
        #ContentPlaceHolder1_UpdatePanel1
        {
            margin: -6px !important;
        } 
        #ContentPlaceHolder1_Label12
        {
            font-weight: 600;
        }
        #ContentPlaceHolder1_gv_Preview .header
        {
            background: #e16565;
            color: white;
            font-weight: bold;
            border: 1px solid red;
        } 
        #ContentPlaceHolder1_gv_Preview td
        {
            padding: 3px;
        } 
    </style>
  
     <style type="text/css">
         .datagrid table { border-collapse: collapse; text-align: left; width: 100%; } .datagrid {font: normal 12px/150% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden; border: 1px solid #8C8C8C; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; }.datagrid table td, .datagrid table th { padding: 3px 10px; }.datagrid table thead th {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; color:#FFFFFF; font-size: 15px; font-weight: bold; border-left: 1px solid gray; } .datagrid table thead th:first-child { border: none; }.datagrid table tbody td { /*color: #7D7D7D;*/ border-left: 1px solid #DBDBDB;font-size: 12px;font-weight: normal; }.datagrid table tbody .alt td { background: #EBEBEB; color: #7D7D7D; }.datagrid table tbody td:first-child { border-left: none; }.datagrid table tbody tr:last-child td { border-bottom: none; }.datagrid table tfoot td div { border-top: 1px solid #8C8C8C;background: #EBEBEB;} .datagrid table tfoot td { padding: 0; font-size: 12px } .datagrid table tfoot td div{ padding: 2px; }.datagrid table tfoot td ul { margin: 0; padding:0; list-style: none; text-align: right; }.datagrid table tfoot  li { display: inline; }.datagrid table tfoot li a { text-decoration: none; display: inline-block;  padding: 2px 8px; margin: 1px;color: #F5F5F5;border: 1px solid #8C8C8C;-webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; }.datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover { text-decoration: none;border-color: #7D7D7D; color: #F5F5F5; background: none; background-color:#8C8C8C;}div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }
    
     /*td:nth-of-type(1) {display: none;}*/
     </style>

       <script type="text/javascript">
           function Avail_InvoiceNo_Alert_Msg() {
               var invno = document.getElementById("hdinvno").value;
               alert(invno);
           }

           function ClosePop_up() {
               $('#Validation123').css("display", "none");
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
                        Import Bulk License XL Upload 
                        <div id="popupwindow_closebut_right">
                            <%--<input type="close" value="Submit" class="clsicon" onclick="$find('mp_Nissan_Excel').hide();" />--%>
                            <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Mid_adcode_Itemmove1" style="height: 250px;">
                     
                        <div id="pop_text_area_ItemMove">
                            <div id="tag_label_adcode">
                                Select Excel File</div>
                            <div id="txtcon-m_src_ItemMove">
                                <asp:FileUpload ID="fileuploadExcel" runat="server" />
                                
                            </div>
                        </div>
                    </div>
                </div>
                  <div id="innerbox_MidMain_top_adcode_Itemmove" style="width: 500px; height: 40px;">
                    <div id="innerbox_adcode_bot_inn_ItemMove" style="padding-right: 455px;">

                        <div id="editbu" style="width: 400px">
                            <a href="../Submission/Import_Excel_Format/IMPORT_BULK_LICENSE.xlsx" target="_new">Download Excel
                                File Format </a>
                            <%--<a href="../Submission/Import_Excel_Format/IMPORT.XLSX"  target="_new">
                    <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"  Height="30px"  Width="30px" runat="server" /></a>--%>
                            <asp:Label ID="space" runat="server" Width="20px"></asp:Label>
                            <asp:Button ID="btn_Import_BulkUpload" runat="server" CssClass="autowidmovebut" Text="Upload"
                                TabIndex="115" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                OnClick="btn_Import_BulkUpload_Click" />
                            <asp:Button ID="btn1" runat="server" Visible="false" />
                        </div>

                    </div>
                </div>
              
                <%-----------------------------------END----------------------------------------------------------------%>
          <asp:HiddenField ID="hdinvno" runat="server" />
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>
            <div id = "Main_Grid" runat="server" Visible="false">
             <div id="Validation123">
                            <div id="popupwindow_closebut_right_new" style="margin-top: -12px; margin-right: 4px;">
                                <input type="close" value="Submit" class="clsicon_new" onclick="ClosePop_up()" style="width: 23px;
                                    height: 27px;">
                            </div>
                            <asp:Label ID="Label12" runat="server"></asp:Label>
                            <div style="overflow: auto !important; height: 185px; width:470px">
                                <div style="margin-top: 13px;">
                                    <asp:GridView ID="gv_Preview" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                        CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                                        OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                                        Width="500px">
                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            CssClass="column_style_right" BorderWidth="1px" />
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        </div>

           
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
