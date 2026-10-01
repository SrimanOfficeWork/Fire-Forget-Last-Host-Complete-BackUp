<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IMP_Flatfile_Validation.aspx.cs" Inherits="IMP_Flatfile_Validation" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Import Flatfile </title>

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

<%--
gv_Preview_1
gv_Preview_2
General_Details
IGM_Details
Invoice_Details
Invoice_Item
Item_Details
Item_Special_Charaters
Item_Details_Notification
Item_License
Re_Import
Single_Window
Single_Window_Entry
Single_Window_Entry_Cnt
Paramount
--%>

         <div  style="overflow: auto;">
    <span style="color:Blue;" > Import Jobno : <asp:Literal ID="lbl_jobno" runat="server"></asp:Literal> </span>
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Preview_1" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Preview_1" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
         <div  style="overflow: auto;">
         <span style="color:Green;" > <asp:Literal ID="lbl_gv_Preview_2" runat="server"></asp:Literal> </span>

        <asp:GridView ID="gv_Preview_2" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
     <span style="color:Green;" > <asp:Literal ID="lbl_gv_gen_Det" runat="server"></asp:Literal> </span>
       <asp:GridView ID="gv_gen_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
      </div>

            <div  style="overflow: auto;">
     <span style="color:Green;" > <asp:Literal ID="lbl_gv_gen_Det1" runat="server"></asp:Literal> </span>
       <asp:GridView ID="gv_gen_Det1" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
      </div>

         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_IGM_Det" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_IGM_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>

                <div style="overflow: auto;">
        <span style="color:Red;" > <asp:Literal ID="lbl_country_orgin" runat="server"></asp:Literal> </span>
        </div>
               <%--<div style="overflow: auto;">
        <span style="color:Red;" > <asp:Literal ID="Literal1" runat="server"></asp:Literal> </span>
        </div>--%>
         <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_uqc_validation" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Item_uqc_check" runat="server" AllowPaging="false" AutoGenerateColumns="true" 
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>

         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Con_Det" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Con_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>

         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Bond_Det" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Bond_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
        <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Cer_Det" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Cer_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
         <span style="color:Green;" > <asp:Literal ID="lbl_gv_Ex_Bond_Det" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Ex_Bond_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Inv_Det" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Inv_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
           <span style="color:Green;" > <asp:Literal ID="lbl_gv_Inv_Cur_Ex_Rate" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Inv_Inv_Cur_Ex_Rate" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>

        <div  style="overflow: auto;">
        <span style="color:Red;" > <asp:Literal ID="lbl_mbl_date" runat="server"></asp:Literal> </span>
        </div>

         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Inv_SVB_Det" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_INV_SVB_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>

         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Inv_Item" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Inv_Item" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto; height:auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Item" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Item" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;height:auto;">
       <span style="color:Green;" > <asp:Literal ID="lbl_gv_Item_Special_Char" runat="server"></asp:Literal> </span>
       
         <asp:GridView ID="gv_Item_Special_Char" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
       <span style="color:Green;" > <asp:Literal ID="lbl_gv_Item_Details_Notif" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Item_Details_Notif" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
       <span style="color:Green;" > <asp:Literal ID="lbl_gv_Item_License" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Item_License" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>

        </div>
         <%--<div  style="overflow: auto;">
       <span style="color:Green;" > <asp:Literal ID="lbl_gv_Certificate" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Certificate" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>--%>
         <div  style="overflow: auto;">


        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Re_Import" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Re_Import" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">

       <span style="color:Green;" > <asp:Literal ID="lbl_gv_SW_Entry_1" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_SW_Entry_1" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_SW_Entry_2" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_SW_Entry_2" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_SW_Entry_3" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_SW_Entry_3" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_SW_Entry_4" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_SW_Entry_4" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
            <span style="color:Green;" > <asp:Literal ID="lbl_gv_SW_Entry_5" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_SW_Entry_5" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>

        </div>
         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_SW_Entry_Cnt" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_SW_Entry_Cnt" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Paramount" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Paramount" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
         <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_Items_SW_Auto_Entry" runat="server"></asp:Literal> </span>
         <asp:GridView ID="GV_Items_SW_Auto_Entry" runat="server" AllowPaging="false" AutoGenerateColumns="true" 
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
         <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_IGM_Bond_Entry" runat="server"></asp:Literal> </span>
         <asp:GridView ID="GV_IGM_Bond_Entry" runat="server" AllowPaging="false" AutoGenerateColumns="true" 
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
       <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_SW_FTA" runat="server"></asp:Literal> </span>
         <asp:GridView ID="GV_SW_FTA" runat="server" AllowPaging="false" AutoGenerateColumns="true" 
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
        <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_SW_CCDC" runat="server"></asp:Literal> </span>
         <asp:GridView ID="GV_SW_CCDC" runat="server" AllowPaging="false" AutoGenerateColumns="true" 
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
        <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_SW_SEZ" runat="server"></asp:Literal> </span>
         <asp:GridView ID="GV_SW_SEZ" runat="server" AllowPaging="false" AutoGenerateColumns="true" 
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>

        <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_SW_HAND" runat="server"></asp:Literal> </span>
         <asp:GridView ID="GV_SW_HAND" runat="server" AllowPaging="false" AutoGenerateColumns="true" 
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
        <div  style="overflow: auto;">
     <span style="color:Green;" > <asp:Literal ID="lbl_gv_Cha_no_Det" runat="server"></asp:Literal> </span>
       <asp:GridView ID="gv_Cha_no_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
      </div>

            <asp:Label ID="lbl_SVB_Validation"
    runat="server"
    Visible="false"
    CssClass="shadowbox"
    Text="SVB Validation - Missing Details"
    ForeColor="Red"
    Width="980px">
</asp:Label>

<div id="div_SVB_Validation"
    runat="server"
    visible="false"
    style="overflow: auto;
           height: 175px;
           width: 980px;
           margin-top: 10px;
           margin-bottom: 25px;">

    <asp:GridView ID="GV_SVB_Validation"
        runat="server"
        EmptyDataText="NO RECORD FOUND"
        Width="100%"
        AutoGenerateColumns="False"
        CssClass="grid-view"
        ShowHeaderWhenEmpty="True"
        PageSize="5"
        AllowPaging="True"
        AllowSorting="True"
        BorderColor="#C8C8C8"
        BorderStyle="Solid"
        BorderWidth="1px"
        CellPadding="1"
        CellSpacing="1"
        GridLines="Both">

        <HeaderStyle
            BackColor="#F9C46B"
            ForeColor="#000000"
            Font-Bold="true"
            HorizontalAlign="Center"
            Height="25px" />

        <RowStyle
            BackColor="White"
            ForeColor="#000000"
            HorizontalAlign="Left"
            Height="25px" />

        <AlternatingRowStyle
            BackColor="#F7F7F7"
            ForeColor="#000000"
            Height="25px" />

        <SelectedRowStyle
            Font-Bold="true" />

        <Columns>

            <asp:BoundField
                DataField="JOBNO"
                HeaderText="Job No"
                HeaderStyle-Width="10%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="10%"
                    HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField
                DataField="IMPORTER_NAME"
                HeaderText="Importer"
                HeaderStyle-Width="25%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="25%"
                    HorizontalAlign="Left" />
            </asp:BoundField>

            <asp:BoundField
                DataField="INVOICE_SLNO"
                HeaderText="Inv SlNo"
                HeaderStyle-Width="10%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="10%"
                    HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField
                DataField="SUPPLIER_NAME"
                HeaderText="Supplier"
                HeaderStyle-Width="25%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="25%"
                    HorizontalAlign="Left" />
            </asp:BoundField>

            <asp:BoundField
                DataField="SVB_RELATION"
                HeaderText="SVB Relation"
                HeaderStyle-Width="10%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="10%"
                    HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField
                DataField="SVB_REF_NO"
                HeaderText="SVB Ref No"
                HeaderStyle-Width="20%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="20%"
                    HorizontalAlign="Left" />
            </asp:BoundField>

        </Columns>
       
    </asp:GridView>
   </div>
    <asp:Label ID="lbl_ReExportBond_Validation"
    runat="server"
    Visible="false"
    CssClass="shadowbox"
    Text="Re-Export Bond Validation"
    ForeColor="Red"
    Width="980px">
</asp:Label>

<div id="div_ReExportBond_Validation"
    runat="server"
    visible="false"
    style="overflow: auto;
           height: 175px;
           width: 980px;
           margin-top: 10px;
           margin-bottom: 25px;">

    <asp:GridView ID="GV_ReExportBond_Validation"
        runat="server"
        EmptyDataText="NO RECORD FOUND"
        Width="100%"
        AutoGenerateColumns="False"
        BackColor="WhiteSmoke"
        CssClass="grid-view"
        ShowHeaderWhenEmpty="True"
        PageSize="5"
        AllowPaging="True"
        AllowSorting="True"
        BorderColor="#C8C8C8"
        BorderStyle="Solid"
        BorderWidth="1px"
        CellPadding="1"
        CellSpacing="1"
        GridLines="Both">

        <HeaderStyle
            BackColor="#F9C46B"
            ForeColor="#000000"
            Font-Bold="true"
            HorizontalAlign="Center"
            Height="25px" />

        <RowStyle
            BackColor="White"
            ForeColor="#000000"
            Height="25px" />

        <AlternatingRowStyle
            BackColor="#F7F7F7"
            ForeColor="#000000"
            Height="25px" />

        <SelectedRowStyle Font-Bold="true" />

        <Columns>

            <asp:BoundField
                DataField="JOBNO"
                HeaderText="Job No"
                HeaderStyle-Width="10%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="10%"
                    HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField
                DataField="INVOICE_SLNO"
                HeaderText="Inv SlNo"
                HeaderStyle-Width="15%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="15%"
                    HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField
                DataField="ITEM_SLNO"
                HeaderText="Item SlNo"
                HeaderStyle-Width="15%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="15%"
                    HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField
                DataField="PRODUCT_BCD_NOTN"
                HeaderText="Notification"
                HeaderStyle-Width="30%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="30%"
                    HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField
                DataField="PRODUCT_BCD_SLNO"
                HeaderText="Notification SlNo"
                HeaderStyle-Width="30%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="30%"
                    HorizontalAlign="Center" />
            </asp:BoundField>

        </Columns>

    </asp:GridView>
    </div>
    <asp:Label ID="lbl_Certificate_Validation"
    runat="server"
    Visible="false"
    CssClass="shadowbox"
    Text="Certificate Validation - Missing Details"
    ForeColor="Red"
    Width="980px">
</asp:Label>

<div id="div_Certificate_Validation"
    runat="server"
    visible="false"
    style="overflow: auto;
           height: 175px;
           width: 980px;
           margin-top: 10px;
           margin-bottom: 25px;">

    <asp:GridView ID="GV_Certificate_Validation"
        runat="server"
        EmptyDataText="NO RECORD FOUND"
        Width="100%"
        AutoGenerateColumns="False"
        CssClass="grid-view"
        ShowHeaderWhenEmpty="True"
        PageSize="5"
        AllowPaging="True"
        AllowSorting="True"
        BorderColor="#C8C8C8"
        BorderStyle="Solid"
        BorderWidth="1px"
        CellPadding="1"
        CellSpacing="1"
        GridLines="Both">

        <HeaderStyle
            BackColor="#F9C46B"
            ForeColor="#000000"
            Font-Bold="true"
            HorizontalAlign="Center"
            Height="25px" />

        <RowStyle
            BackColor="White"
            ForeColor="#000000"
            HorizontalAlign="Left"
            Height="25px" />

        <AlternatingRowStyle
            BackColor="#F7F7F7"
            ForeColor="#000000"
            Height="25px" />

        <SelectedRowStyle
            Font-Bold="true" />

        <Columns>

            <asp:BoundField
                DataField="JOBNO"
                HeaderText="Job No"
                HeaderStyle-Width="10%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="10%"
                    HorizontalAlign="Center" />
            </asp:BoundField>

            <asp:BoundField
                DataField="INVOICE_SLNO"
                HeaderText="Inv SlNo"
                HeaderStyle-Width="15%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="15%"
                    HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField
                DataField="ITEM_SLNO"
                HeaderText="Item SlNo"
                HeaderStyle-Width="15%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="15%"
                    HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField
                DataField="INFO_TEXT"
                HeaderText="Certificate No"
                HeaderStyle-Width="45%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="45%"
                    HorizontalAlign="Left" />
            </asp:BoundField>

            <asp:BoundField
                DataField="CERTIFICATE_NO"
                HeaderText="Certificate Details"
                HeaderStyle-Width="30%"
                HeaderStyle-Font-Bold="true">
                <ItemStyle
                    CssClass="column_style_left5"
                    Width="30%"
                    HorizontalAlign="Left" />
            </asp:BoundField>

        </Columns>

    </asp:GridView>

</div>
</div>
       <%-- Gen_Det
        Exp_Annex_Air
        Exp_Annex_Sea
        Inv_Det
        AR_4
        Inv_Item
        Item
        Item_Special
        Cess_Det
        Lic
        Annex_C1_Det
        Lic_Dup
        Lic_Mandatory--%>
    </div>


    </form>
</body>
</html>
