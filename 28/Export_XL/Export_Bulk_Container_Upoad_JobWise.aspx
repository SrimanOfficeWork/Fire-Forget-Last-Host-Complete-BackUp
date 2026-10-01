<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Bulk_Container_Upoad_JobWise.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Export_Bulk_Container_Upoad_JobWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

     

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
<link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
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

     <style type="text/css">
         #innerbox_MidMain_Grid
         {
             height: 474px !important;
             margin-top: -6px !important;
         }
         #tag_admin_src_border
         {
             width: 100%;
             height: 20px;
             background-image: url(images/admin_src_top.gif);
             background-repeat: repeat-x;
             background-position: top;
             float: left;
         }
         #Heading
         {
             height: 25px;
             color: red;
             font-weight: 600;
             font-size: 10pt;
             padding-left: 7px;
         }
         .Error_Grid
         {
             width: 98%;
             background: #e8dede69;
             padding-left: 4px;
             padding-top: 3px;
             border: 1px solid #bbb8b845;
             height: 310px;
             overflow: auto;
         }
         #ContentPlaceHolder1_gv_Preview
         {
             width: 99%;
             margin: 3px;
             border: 1px solid #aeaaaa;
         }
         #ContentPlaceHolder1_gv_Preview
         {
             margin-top: -28px;
             margin-left: -4px;
         }
     </style>
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Bulk Container Upload
            </div>
        </div>
        <div id="tag_srcinner2" style="width: 1000px; display: flex;">
            <div id="tag_srcinner_lft1" style="width: 32%; margin-top: 4px;">
                <div id="tag_label_transaction_popup_no_empty">
                </div>
                <div id="tag_label_transaction_popup_gen" style="width: 104px">
                    Select Excel File</div>
                <div id="txtcon-m_src" style="width: 92px;">
                    <asp:FileUpload ID="fileuploadExcel" runat="server" Width="196px" />
                </div>
            </div>
            <div id="editbu" style="width: 79px;">
                <asp:Label ID="space" runat="server" Width="20px"></asp:Label>
                <asp:Button ID="btn_Export_BulkUpload" runat="server" CssClass="autowidmovebut" Text="Upload"
                    TabIndex="115" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                    OnClick="btn_Export_BulkUpload_Click" />
                <asp:Button ID="btn1" runat="server" Visible="false" />
            </div>
            <div id="tag_srcinner2" style="width: 200px; margin-left: 9px;">
                <a href="../Submission/Export_Excel_Format/EXPORT_BULK_CONTAINER.xlsx" target="_new">
                    Download Excel File Format </a>
            </div>
        </div>
        <div id="tag_srcinner1" style="width: 1070px; display: flex; border: 1px solid #cac0c0;
            margin: 1px; height: 2px;">
        </div>
        <div id="tag_srcinner1" style="margin: 6px;">
            <div id="Heading">
                <asp:Label ID="Label12" runat="server"></asp:Label>
            </div>
            <div id="Preview">
                <div id="Error_Grid_Header">
                    <asp:GridView ID="gv_Preview_Header" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                        CssClass="grid-view"  ShowHeaderWhenEmpty="True"
                        OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gv_Details_RowDataBound"
                        Width="98%">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            CssClass="column_style_right" BorderWidth="1px" />
                    </asp:GridView>
                </div>
                <div class="Error_Grid">
                    <asp:GridView ID="gv_Preview" runat="server" AllowPaging="false" AutoGenerateColumns="true"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                        CssClass="grid-view" EmptyDataText="No Error Records" ShowHeaderWhenEmpty="True"
                        OnRowCreated="gvdetails_RowCreated" OnRowDataBound="gv_Details_RowDataBound" 
                        Width="100%">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            CssClass="column_style_right" BorderWidth="1px" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
