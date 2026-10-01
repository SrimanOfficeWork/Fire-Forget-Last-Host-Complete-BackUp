<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GST_Bill_Import_Job_rpt_Credit_Note.aspx.cs" Inherits="GST_Bill_Import_Job_rpt_Credit_Note" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Import Invoice</title>

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
       
       <div ID="mainmastop2container_rght_tag2_txt1" style="width:100%;">
                 <span style="font-weight:bold;">   Invoice No  &nbsp;  &nbsp; &nbsp; </span>
           <asp:DropDownList ID="ddlJob_No" runat="server" CssClass="txtbox_none" 
                     onselectedindexchanged="ddlJob_No_SelectedIndexChanged" AutoPostBack="true">
               <asp:ListItem>Select</asp:ListItem>
           </asp:DropDownList>
            <asp:Label ID="LabBillModel" runat="server" Text="Model" Visible="false" ></asp:Label>
           <asp:DropDownList ID="ddlBillModel" runat="server" CssClass="txtbox_none" 
                       AutoPostBack="true" Visible="false" onselectedindexchanged="ddlBillModel_SelectedIndexChanged" 
                     >
               
               <asp:ListItem Text="Taxable Invoice" Value="Taxable Invoice"></asp:ListItem>
               <asp:ListItem Text="Non-Taxable Invoice" Value="Non-Taxable Invoice"></asp:ListItem>
               <%--<asp:ListItem Text="Invoice" Value="Invoice"></asp:ListItem>--%>
           </asp:DropDownList>


           <span style="font-weight:bold; margin-left:180px;">  
               <asp:Literal ID="lblmsg" runat="server"></asp:Literal>  &nbsp;  &nbsp; &nbsp; </span>

               &nbsp; &nbsp; <asp:Button ID="btnpdf" runat="server" Text="PDF" onclick="btnpdf_Click" />

       </div>


       <asp:Button ID="btn_print" runat="server" CssClass="print_btn"  Visible="false"
           OnClientClick="Print_open();" Text="Button" />
       <asp:Button ID="btnSend" runat="server" CssClass="send_btn" 
           OnClientClick="Mail_open();" Text="Send" Visible="false" />
   
       <div ID="innerbox_MidMain_Trans_IGM_Invoice" style=" width:100%; height:600px;"> <%--width:820px;--%>
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
           
</body>

</html>