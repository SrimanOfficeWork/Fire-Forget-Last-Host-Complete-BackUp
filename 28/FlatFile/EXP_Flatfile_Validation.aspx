<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EXP_Flatfile_Validation.aspx.cs" Inherits="EXP_Flatfile_Validation" %>


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


    <span style="color:Blue;" > Export_Jobno : <asp:Literal ID="lbl_jobno" runat="server"></asp:Literal> </span>
    <div  style="overflow: auto;">
       <span style="color:Green;" > <asp:Literal ID="lbl_gv_Preview" runat="server"></asp:Literal> </span>
       
         <asp:GridView ID="gv_Preview" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
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
     <span style="color:Green;" > <asp:Literal ID="lbl_gv_Exp_Annex_Air" runat="server"></asp:Literal> </span>
       <asp:GridView ID="gv_Exp_Annex_Air" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
              <div  style="overflow: auto;">
     <span style="color:Red;" > <asp:Literal ID="lbl_DrawBack_val" runat="server"></asp:Literal> </span>
       
       </div>

        <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Exp_Annex_Sea" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Exp_Annex_Sea" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>

        <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Exp_Annex_Sea_Container" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Exp_Annex_Sea_Container" runat="server" AllowPaging="false" AutoGenerateColumns="true"
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
         
         <span style="color:Green;" > <asp:Literal ID="lbl_gv_Inv_Inv_Cur_Ex_Rate" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Inv_Inv_Cur_Ex_Rate" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
        <div  style="overflow: auto;">


          <span style="color:Green;" > <asp:Literal ID="lbl_gv_AR_4" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_AR_4" runat="server" AllowPaging="false" AutoGenerateColumns="true"
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
       <span style="color:Green;" > <asp:Literal ID="lbl_gv_Item_Special" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Item_Special" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
        <div  style="overflow: auto;">
       <span style="color:Green;" > <asp:Literal ID="lbl_gv_Cess_Det" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Cess_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
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
       <span style="color:Green;" > <asp:Literal ID="lbl_gv_Annex_C1_Det" runat="server"></asp:Literal> </span>

         <asp:GridView ID="gv_Annex_C1_Det" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
        <div  style="overflow: auto;">
        <span style="color:Green;" > <asp:Literal ID="lbl_gv_Lic_Dup" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Lic_Dup" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
        <div  style="overflow: auto;">
         <span style="color:Green;" > <asp:Literal ID="lbl_gv_Lic_Mandatory" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Lic_Mandatory" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
        </div>
        <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Inv_no_len" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Inv_no_len" runat="server" AllowPaging="false" AutoGenerateColumns="true"
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
       <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Item_Ritc" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Item_Ritc" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
        <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Item_PMV" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Item_PMV" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
       <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Ins_Fre_Cur" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Ins_Fre_Cur" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>
       <div  style="overflow: auto;">
          <span style="color:Green;" > <asp:Literal ID="lbl_gv_Inv_no" runat="server"></asp:Literal> </span>
         <asp:GridView ID="gv_Inv_no" runat="server" AllowPaging="false" AutoGenerateColumns="true"
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
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
