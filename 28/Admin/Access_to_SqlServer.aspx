<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Access_to_SqlServer.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Transaction_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

       <iframe id="a" runat="server" src="Access_to_SqlServer_new.aspx" width="1000px" height="750px" scrolling="no"></iframe>
    
    <script type="text/javascript">


        window.onload = happycode;
        window.onload = happycode1;
        function happycode() {

            document.getElementById("Transaction_Id").click();

        }

       
    </script>

    


       </asp:Content>
   