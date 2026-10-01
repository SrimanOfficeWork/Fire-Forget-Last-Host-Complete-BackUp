<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Purchase_Entry_Report.aspx.cs" Inherits="Report_Purchase_Entry" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="1050"
                BackColor="#F2F5F2" AsyncRendering="False" SizeToReportContent="true" ExportContentDisposition="AlwaysAttachment"
                ProcessingMode="Local" ShowToolBar="true" ShowPageNavigationControls="true" ShowZoomControl="false"
                ShowFindControls="False" ShowBackButton="false" ShowExportControls="true" ShowParameterPrompts="false"
                ToolBarItemBorderStyle="Solid" ShowRefreshButton="true" ToolBarItemBorderColor="Black"
                EnableTheming="false" ShowReportBody="true" ShowDocumentMapButton="true" ShowPrintButton="false"
                KeepSessionAlive="true">       
        <LocalReport ReportPath="Billing_Imp_Rpt\Purchase_Entry.rdlc"></LocalReport>
        </rsweb:ReportViewer>
        
    </div>
    </form>
    <style type="text/css">
    body:nth-of-type(1) img[src*="Blank.gif"]{
    display:none;
}
</style>
</body>
 <script src="../../js/Jquery_Print_Report.js" type="text/javascript"></script>

</html>
