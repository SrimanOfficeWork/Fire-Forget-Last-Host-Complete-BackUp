<%@ Page Language="C#" AutoEventWireup="true" CodeFile="General_Search.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Transaction_Default2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  
     <iframe id="a" runat="server"  width="1000px" height="750px" scrolling="no"></iframe>
    <script type="text/javascript">


        window.onload = happycode;
        window.onload = happycode1;
        function happycode() {

            document.getElementById("Transaction_Id").click();

        }

       
    </script>

    </asp:Content>