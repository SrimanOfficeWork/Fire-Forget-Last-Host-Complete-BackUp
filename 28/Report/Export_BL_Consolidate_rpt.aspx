<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_BL_Consolidate_rpt.aspx.cs" Inherits="Report_Export_BL_Consolidate_rpt" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Multiple BL Generation</title>

   <script type="text/javascript">
       var win = null;
       function Print_open() {
           var w = '810';
           var h = '1024';
           LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
           TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
           settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
           win = window.open('../Print.aspx', 'ndf', settings);
           win.focus();

           return false;
       }
    </script>

     <script type="text/javascript">
         var win = null;

         function Mail_open() {
             var w = '700';
             var h = '800';
             LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
             TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
             settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
             win = window.open('Mail_Send.aspx', 'ndf', settings);
             win.focus();

             return false;
             //window.open('../Default.aspx', 'ndf')

         }
    </script>

 <style >
 .print_btn{
	background:url('../images/print_Butt.png') no-repeat;
	width:101px;
	height: 30px;
	text-indent:-9999px;
	overflow:hidden;
	text-transform:uppercase;
	border:none;
	cursor:pointer;
}

.print_btn:hover{
	background-position:left bottom;
}
 </style>
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
    <div class="loading" align="center" id="load" style="display:none;">
   
    <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
     
</div>
   <div style="margin:0px 10px 5px 10px; ">
       <br>
       
       <div ID="mainmastop2container_rght_tag2_txt1" style="width:500px;">
          Show Report Name  &nbsp;  &nbsp; &nbsp;
             <asp:TextBox ID="txtrptname" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                                    Width="180px" ></asp:TextBox>
       </div>
     
                            
      
       <asp:Button ID="btnMBL" runat="server" onclick="btnMBL_Click" 
           Text="Multiple BL" />
            <asp:Button ID="btnaddanx" runat="server" onclick="btnaddanx_Click" 
           Text="Annexure" />


       <asp:Button ID="btn_print" runat="server" CssClass="print_btn"  Visible="false"
           OnClientClick="Print_open();" Text="Button" />
       <asp:Button ID="btnSend" runat="server" CssClass="send_btn" 
           OnClientClick="Mail_open();" Text="Send" Visible="false" />
       <div ID="popupwindow_closebut_right_new" style="margin-top:-12px;">
           <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
       </div>
       <div ID="innerbox_MidMain_Trans_IGM_Invoice" style="width:937px; height:600px;">
           <rsweb:ReportViewer ID="ReportViewer1" runat="server" AsyncRendering="False" 
               BackColor="#F2F5F2" EnableTheming="false" 
               ExportContentDisposition="AlwaysAttachment" Height="590" ProcessingMode="Local" 
               ShowBackButton="false" ShowDocumentMapButton="true" ShowExportControls="true" 
               ShowFindControls="False" ShowPageNavigationControls="true" 
               ShowParameterPrompts="false" ShowPrintButton="false" ShowRefreshButton="true" 
               ShowReportBody="true" ShowToolBar="true" ShowZoomControl="false" 
               SizeToReportContent="false" ToolBarItemBorderColor="Black" 
               ToolBarItemBorderStyle="Solid" Width="100%">
              
           </rsweb:ReportViewer>
       </div>
       
    

           </div>
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
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        
    </script>
</body>

</html>

