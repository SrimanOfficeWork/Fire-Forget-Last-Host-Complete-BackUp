<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Annexure_EOU_Report.aspx.cs" Inherits="Export_Annexure_EOU_Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Export Annexure</title>

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
//           alert('Print');
           return true;

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
 /*
* multi-line comment
*/
p{ line-height: 1em; }
h1, h2, h3, h4{
    color: orange;
	font-weight: normal;
	line-height: 1.1em;
	margin: 0 0 .5em 0;
}
h1{ font-size: 1.7em; }
h2{ font-size: 1.5em; }
a{
	color: black;
	text-decoration: none;
}
	a:hover,
	a:active{ text-decoration: underline; }

/* you can structure your code's white space so that it is as readable for when you come back in the future or for other people to read and edit quickly */

body{
    font-family: arial; font-size: 80%; line-height: 1.2em; width: 100%; margin: 0; background: #eee;
}
/* you can put your code all in one line like above */
#page{ margin: 20px; }

/* or on different lines like below */
#logo{
	width: 35%;
	margin-top: 5px;
	font-family: georgia;
	display: inline-block;
}
/* but try and be as concise as possible */
#nav{
	width: 100%;
	display: inline-block;
	text-align: left;
	float: right;
}
	#nav ul{}
		#nav ul li{
			display: inline-block;
			height: 62px;
		}
			#nav ul li a{
				padding: 20px;
				background: orange;
				color: white;
			}
			#nav ul li a:hover{
				background-color: #ffb424;
				box-shadow: 0px 1px 1px #666;
			}
			#nav ul li a:active{ background-color: #ff8f00; }

#content{
	margin: 30px 0;
	background: white;
	padding: 20px;
	clear: both;
}
#footer{
	border-bottom: 1px #ccc solid;
	margin-bottom: 10px;
}
	#footer p{
		text-align: right;
		text-transform: uppercase;
		font-size: 80%;
		color: grey;
	}

/* multiple styles seperated by a , */
#content,
ul li a{ box-shadow: 0px 1px 1px #999; }
 
 
 </style>



</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <!-- webpage content goes here in the body -->
    <div id="page">
        <div id="logo" style="width: 450px; margin-top: 5px;">
            <h1 style="color: Blue; text-align: center;">
                Export EOU Annexure-Report</h1>
        </div>
        <div id="nav">
            <b>JOBNO</b>
            <asp:DropDownList ID="ddl_Jobno" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Jobno_SelectedIndexChanged"
                Width="100px">
            </asp:DropDownList>
            <asp:Button ID="btn_print" runat="server" Text="Button" CssClass="print_btn" OnClientClick="Print_open();" />
            <br />
        </div>
        <div id="content">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="650" BackColor="#F2F5F2"
                AsyncRendering="False" SizeToReportContent="false" ExportContentDisposition="AlwaysAttachment"
                ProcessingMode="Local" ShowToolBar="true" ShowPageNavigationControls="true" ShowZoomControl="false"
                ShowFindControls="False" ShowBackButton="false" ShowExportControls="true" ShowParameterPrompts="false"
                ToolBarItemBorderStyle="Solid" ShowRefreshButton="true" ToolBarItemBorderColor="Black"
                EnableTheming="false" ShowReportBody="true" ShowDocumentMapButton="true" ShowPrintButton="false">
            </rsweb:ReportViewer>
        </div>
        <div id="footer">
        </div>
    </div>
    </form>
</body>
</html>
