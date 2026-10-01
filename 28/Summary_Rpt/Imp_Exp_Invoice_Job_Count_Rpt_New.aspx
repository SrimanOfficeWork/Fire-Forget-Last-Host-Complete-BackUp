<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Exp_Invoice_Job_Count_Rpt_New.aspx.cs" Inherits="Imp_Exp_Invoice_Job_Count_Rpt_New" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>

    <table>
        <tr>
            <td align="left">
                <div id="lblerror" runat="server" style="margin: 0px 50px 0px 50px; text-align: center">
                <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                         Width="28px" onclick="btnexcel_Click"  /><%-- OnClientClick="EXcel()"--%>
                </div>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="930px" Height="525px"
                    OnPreRender="ReportViewer1_PreRender" ShowWaitControlCancelLink="true">
                </rsweb:ReportViewer>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
