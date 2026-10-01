<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_DutyWorkSheet_Rpt_viewer.aspx.cs" Inherits="Import_DutyWorkSheet_Rpt_viewer" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Work Sheet Report</title>
 
 
   
  <script>

     // window.onload =
//function () {

    //$(window.frames[0].window.frames['report'].document.getElementById('oReportDiv')).attr('style', 'overflow: none;');

      //}
    
  </script>
   <script type="text/javascript" >
       var win = null;


       function Print_open() {
           var w = '810';
                      var h = '1024';
           LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
           TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
//                      LeftPosition = (screen.width) ? (screen.width - w) /4: 0;
//                      TopPosition = (screen.height) ? (screen.height - h) / 4 : 0;
           
           settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
           win = window.open('../Print.aspx', 'ndf', settings);
           //           win = window.open('../LandscapePrint.aspx', 'ndf', settings);
           win.focus();

           return false;
           //window.open('../Default.aspx', 'ndf')

       }

//       function Print_open() {
//           var w = '810';
//           var h = '1024';
//           LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
//           TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
//           settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
//                      win = window.open('../Print.aspx', 'ndf', settings);
////           win = window.open('../LandscapePrint.aspx', 'ndf', settings);
//           win.focus();

//           return false;
//           //window.open('../Default.aspx', 'ndf')

//       }
    </script>

      <script >
          var win = null;

          function Mail_open() {
              var w = '700';
              var h = '800';
              LeftPosition = (screen.width) ? (screen.width - w) / 2 : 0;
              TopPosition = (screen.height) ? (screen.height - h) / 2 : 0;
              settings = 'height=' + h + ',width=' + w + ',top=' + TopPosition + ',left=' + LeftPosition + ',scrollbars=' + scroll + ',resizable';
              win = window.open('../Report/Mail_Send.aspx', 'ndf', settings);
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

  <style>
 .send_btn{
	
	background:url('images/but_mid.png') repeat-x;
	/*min-width:80px;*/
	width:80px;
	height: 28px;
	text-indent:inherit;
	overflow:hidden;
	border: #999999 solid thin;
 -moz-border-radius-topleft: 6px;
 -moz-border-radius-topright: 6px;
 -moz-border-radius-bottomleft: 6px;
 -moz-border-radius-bottomright: 6px;
  -webkit-border-top-left-radius: 6px;
 -webkit-border-top-right-radius: 6px;
 -webkit-border-bottom-left-radius: 6px;
 -webkit-border-bottom-right-radius: 6px;
	border-top-left-radius: 6px;
	border-top-right-radius: 6px;
	border-bottom-left-radius: 6px;
	border-bottom-right-radius: 6px;
	cursor:pointer;
	font-family:Arial, Helvetica, sans-serif;
	font-size:12px;
	font-weight:bold;
	color:#000000;
	text-shadow:2px 2px #ffffff;
	margin-top:2px
}

.send_btn:hover{
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
    <%--  <input name="b_print" type="button" onclick="printdiv();" value=" Print Report" />
      --%>
            
            
            <asp:Button ID="btn_print" runat="server" Text="Button"  CssClass="print_btn" 
                OnClientClick="Print_open();" />
               
            <asp:Button ID="btnSend" CssClass="send_btn" Text="Send"  runat="server"  OnClientClick="Mail_open();"    />
              
          
<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="1050"  BackColor="#F2F5F2" AsyncRendering="False" SizeToReportContent="true"
ExportContentDisposition="AlwaysAttachment"  ProcessingMode="Local" ShowToolBar="true" ShowPageNavigationControls="true" 
ShowZoomControl="false"  ShowFindControls="False" ShowBackButton="false" 

ShowExportControls="true"  ShowParameterPrompts="false" 
ToolBarItemBorderStyle="Solid" ShowRefreshButton="true" 
ToolBarItemBorderColor="Black" EnableTheming="false" ShowReportBody="true" ShowDocumentMapButton="true" ShowPrintButton="false" KeepSessionAlive="true">

<LocalReport ReportPath="BAS_Shipping/Import_DutyWorkSheet_Report.rdlc">


            </LocalReport>
           </rsweb:ReportViewer>
          
           </div>
             </ContentTemplate>
    </asp:UpdatePanel>
  
    </form>
    
</body>
 <script src="../../js/Jquery_Print_Report.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
  
    function printdiv() {
        var headstr = "<html><head><title></title></head><body>";
        var footstr = "</body>";
        var newstr = $("#ReportViewer1_ctl10").html()
        var popupWin = window.open('', '_blank');
        popupWin.document.write(headstr + newstr + footstr);
        popupWin.print();
        return false;
    }
</script>

</html>
