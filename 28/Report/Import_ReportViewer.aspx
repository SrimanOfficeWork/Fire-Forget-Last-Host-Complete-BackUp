<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_ReportViewer.aspx.cs" Inherits="Transaction_Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Import Check List</title>
    <script>
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
    <script>
        var win = null;
        function Mail_open(val) {
            var w = '700';
            var h = '800';
            LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
            TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
            settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
            win = window.open('Mail_Send.aspx?IMP_EXP_Checklist=' + val + '', 'ndf', settings);
            win.focus();
            return false;
        }
    </script>
    <style type="text/css">
         
        .myGridStyle
        {
            border-collapse:collapse;
             
        }
         
        .myGridStyle tr th
        {
            /*color: black;*/
            border: 0.5px solid black;
            font-size:13px;
        }
       .myGridStyle tr:nth-child(even)
        {
            background-color: white;
            font-size:12px;
        } 
         
         .myGridStyle tr:nth-child(odd)
        {
            background-color: white;
            font-size:12px;
        } 
         
        .myGridStyle td
        {
            border:0.5px solid black;
        }
         
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <asp:Button ID="btn_print" runat="server" Text="Button" CssClass="print_btn" OnClientClick="Print_open();" />
            &nbsp;
            <asp:Button ID="btnpdf" runat="server" Text="PDF" OnClick="btnpdf_Click" />
            &nbsp;
            <asp:Button ID="btnSend" CssClass="send_btn" Text="Mail" runat="server" OnClientClick="Mail_open('I');" />
            &nbsp;&nbsp;&nbsp; Job No &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlJob_No" runat="server" CssClass="txtbox_none" AutoPostBack="true"
                OnSelectedIndexChanged="ddlJob_No_SelectedIndexChanged">
                <asp:ListItem>Select</asp:ListItem>
            </asp:DropDownList>

              &nbsp;
               <asp:Button ID="btn_checklist_Value_Update" runat="server"  Visible="false"
                Text="Click Here Checklist Value Update" 
                onclick="btn_checklist_Value_Update_Click" />

           <span style="color:Green; font-weight:bold;"> <asp:Literal ID="lblmsg" runat="server"></asp:Literal></span>


            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="650" BackColor="#F2F5F2"
                AsyncRendering="False" SizeToReportContent="true" ExportContentDisposition="AlwaysAttachment"
                ProcessingMode="Local" ShowToolBar="true" ShowPageNavigationControls="true" ShowZoomControl="false"
                ShowFindControls="False" ShowBackButton="false" ShowExportControls="true" ShowParameterPrompts="false"
                ToolBarItemBorderStyle="Solid" ShowRefreshButton="true" ToolBarItemBorderColor="Black"
                EnableTheming="false" ShowReportBody="true" ShowDocumentMapButton="true" ShowPrintButton="false"
                KeepSessionAlive="true">
                <LocalReport ReportPath="Report/Report_Import.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:GridView ID="GV"  CssClass="myGridStyle" BackColor="WhiteSmoke" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" runat="server">
            </asp:GridView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
<script src="../../js/Jquery_Print_Report.js" type="text/javascript"></script>
</html>
