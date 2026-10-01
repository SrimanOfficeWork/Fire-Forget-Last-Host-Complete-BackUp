<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IMP_Flatfile_Validation_Spl_Char.aspx.cs" Inherits="IMP_Flatfile_Validation_Spl_Char" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Export Flatfile </title>

     <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />

    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />

    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <div class="loading" align="center" id="load" style="display: none;">
        <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
    </div>

    <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height:650px; width: 1092px;">


    <span style="color:Blue;" > Import_Jobno : <asp:Literal ID="lbl_jobno" runat="server"></asp:Literal> </span>
   
        <div  style="overflow: auto;">
         <span style="color:Green;" > <asp:Literal ID="lbl_gv_Gen_Det" runat="server"></asp:Literal> </span>

        <asp:GridView ID="gv_Gen_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
        <div  style="overflow: auto;">
     <span style="color:Green;" > <asp:Literal ID="lbl_gv_Igm" runat="server"></asp:Literal> </span>
       <asp:GridView ID="gv_Igm" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
        <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Inv" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Inv" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Item" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Item" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
        <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Lic" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Lic" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
          <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Cer" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Cer" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
        <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Re_Imp" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Re_Imp" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
          </div>

        <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Info_Type" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Info_Type" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
          </div>

           <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_CONST" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_CONST" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
          </div>
        <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Prod" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Prod" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
          </div>

          <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Control" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Control" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
          </div>

          <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Stmt" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Stmt" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
          </div>

          <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Sup_Doc" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Sup_Doc" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
          </div>

          

    </div>
    </form>
</body>
</html>
