<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_ReportViewer_Subbu.aspx.cs" Inherits="Report_Export_Export_ReportViewer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Export Check List</title>
     <script>

//         window.onload =
//function () {

//    $(window.frames[0].window.frames['report'].document.getElementById('oReportDiv')).attr('style', 'overflow: none;');

//}
  </script>
   <script >
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
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"></asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
    <div class="loading" align="center" id="load" style="display:none;">
   
    <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
     
</div>
   <div style="margin:0px 10px 5px 10px;">
     <asp:Button ID="btn_print" runat="server" Text="Button"  CssClass="print_btn" OnClientClick="Print_open();"/>
          

<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="650" BackColor="#F2F5F2" AsyncRendering="False" SizeToReportContent="false"
ExportContentDisposition="AlwaysAttachment" ProcessingMode="Local" ShowToolBar="true" ShowPageNavigationControls="true" 
ShowZoomControl="false"  ShowFindControls="False" ShowBackButton="false" 
ShowExportControls="true"  ShowParameterPrompts="false" 
ToolBarItemBorderStyle="Solid" ShowRefreshButton="true" 
ToolBarItemBorderColor="Black" EnableTheming="false" ShowReportBody="true" ShowDocumentMapButton="true" ShowPrintButton="false">
 <LocalReport ReportPath="Report/Report_Export.rdlc">
            </LocalReport>
           </rsweb:ReportViewer>

           </div>
             </ContentTemplate>
    </asp:UpdatePanel>
       
<%--    <div>
    
  
 <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" ShowFindControls="false" ShowReportBody="true" ShowDocumentMapButton="true" ShowPrintButton="true" 
            Height="100%" Width="100%" AsyncRendering="False" SizeToReportContent="True">
                <LocalReport ReportPath="Report/Export/ReportNew.rdlc">
            </LocalReport>
            
            </rsweb:ReportViewer>

              </div>--%>
    </form>
</body>
</html>
