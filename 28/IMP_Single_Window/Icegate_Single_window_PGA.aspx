<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Icegate_Single_window_PGA.aspx.cs" Inherits="Single_window_Notes" %>
 <%@ Register Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" tagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Single Window Available List</title>
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
           <%-- <div id="innerbox_MidMain" style="height:43px;">
             <div id="tag_transac_lft_trans_item_maindet_in1_" style="width:1000px; background-color:lightsalmon;">
            <div id="tag_label_transaction_export_Item_otherdet_new1"  style="width:330px; " ></div>
              <div id="tag_label_transaction_export_Item_otherdet_new1" style="width:330px; font-weight:bold; font-size:large; height="40px;">
                                Single Window Department List
                            </div>
                            </div>
            </div>--%>
            <div id="tag_srcinner1grid_innerpopup" style="height:330px; width:950px;">
                <asp:GridView runat="server" ID="gvdetails"  AutoGenerateColumns="false" 
                    BackColor="WhiteSmoke" EmptyDataText="NO RECORD FOUND" GridLines="Both" CssClass="grid-view"
                    Width="100%" ShowHeaderWhenEmpty="True"  AllowSorting="True"
                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                  >
                  <Columns>
                   <asp:BoundField DataField="PGA Code" HeaderText="PGA Code" HeaderStyle-VerticalAlign="Bottom" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Orange" HeaderStyle-Height="25px" HeaderStyle-Width="65px"  HeaderStyle-BorderWidth="1px">
                            <ItemStyle BackColor="lightskyblue" Height="25px" BorderColor="LightBlue" />
                        </asp:BoundField>
                       <asp:BoundField DataField="PGA Name" HeaderText="PGA Name" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Orange"  HeaderStyle-BorderWidth="1px">
                            <ItemStyle BackColor="lightskyblue" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INFO Code" HeaderText="INFO Code" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Orange"  HeaderStyle-BorderWidth="1px"  HeaderStyle-Width="65px" >
                            <ItemStyle BackColor="lightskyblue" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INFO Desc" HeaderText="INFO Desc" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Orange"  HeaderStyle-BorderWidth="1px">
                            <ItemStyle BackColor="lightskyblue" />
                        </asp:BoundField>
                        <asp:BoundField DataField="QFR Code" HeaderText="QFR Code" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Orange"  HeaderStyle-BorderWidth="1px"  HeaderStyle-Width="65px" >
                            <ItemStyle BackColor="lightskyblue" />
                        </asp:BoundField>
                         <asp:BoundField DataField="QFR Desc" HeaderText="QFR Desc" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Orange"  HeaderStyle-BorderWidth="1px">
                            <ItemStyle BackColor="lightskyblue" />
                        </asp:BoundField>
                         <asp:BoundField DataField="REQ" HeaderText="REQ" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Orange"  HeaderStyle-BorderWidth="1px">
                            <ItemStyle BackColor="lightskyblue" />
                        </asp:BoundField>
                         <asp:BoundField DataField="Man Opt" HeaderText="Man/Opt" HeaderStyle-Font-Bold="true" HeaderStyle-BackColor="Orange"  HeaderStyle-BorderWidth="1px">
                            <ItemStyle BackColor="lightskyblue" />
                        </asp:BoundField>
                        
                  </Columns>
                </asp:GridView>
            </div>
          <asp:HiddenField ID="hdn_Output" runat="server" />
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
