<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exbond_JobWiseBondStock.aspx.cs" Inherits="Exbond_Report_Exbond_JobWiseBondStock" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
  <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
<link href="../css/printstyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
<script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
     <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"></asp:ScriptManager>
    <div>
    <table>
    <tr>
    <td>
        <asp:Label ID="Label1" runat="server" Text="JobNo" Font-Bold="true"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="ddlWarehouse_JobNo" runat="server" Width="150px" >
        </asp:DropDownList>
    </td>
    <td>
        <asp:Button ID="BtnPrint" runat="server" Text="Print" 
            onclick="BtnPrint_Click" />
    </td> <td>
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" />
    </td>
    </tr>
    </table>
       <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server" >
        </rsweb:ReportViewer>--%>

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="650" BackColor="#F2F5F2" AsyncRendering="False" SizeToReportContent="false"
ExportContentDisposition="AlwaysAttachment" ProcessingMode="Local" ShowToolBar="true" ShowPageNavigationControls="true" 
ShowZoomControl="false"  ShowFindControls="False" ShowBackButton="false" 
ShowExportControls="true"  ShowParameterPrompts="false" 
ToolBarItemBorderStyle="Solid" ShowRefreshButton="true" 
ToolBarItemBorderColor="Black" EnableTheming="false" ShowReportBody="true" ShowDocumentMapButton="true" ShowPrintButton="false">
 <LocalReport ReportPath="Exbond_Report/JobWiseBondStock_Report.rdlc">
            </LocalReport>
           </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
