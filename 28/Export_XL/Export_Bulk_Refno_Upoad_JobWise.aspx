<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Bulk_Refno_Upoad_JobWise.aspx.cs" MasterPageFile="~/Import_MasterPage/eRoyalMasters.master"
    Inherits="Export_Bulk_Refno_Upoad_JobWise" %>

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

           
    <div id="innerbox_MidMain_Grid">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1">
                Bulk Refno Upload
            </div>
        </div>
        <div id="tag_srcinner2" style="width: 1000px">
            <div id="tag_srcinner_lft1">
                <div id="tag_label_transaction_popup_no_empty">
                </div>
                <div id="tag_label_transaction_popup_gen">
                    Select Excel File</div>
                <div id="txtcon-m_src">
                    <asp:FileUpload ID="fileuploadExcel" runat="server" />
                </div>
            </div>
            <div id="editbu" style="width: 400px">
                <asp:Label ID="space" runat="server" Width="20px"></asp:Label>
                <asp:Button ID="btn_Export_Refno_Update" runat="server" CssClass="autowidmovebut" Text="Upload"
                    TabIndex="115" UseSubmitBehavior="false" CausesValidation="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                    OnClick="btn_Export_BulkUpload_Click" />
                <asp:Button ID="btn1" runat="server" Visible="false" />
            </div>
        </div>
        <div id="tag_srcinner2" style="width: 1000px; height: 50px;">
        </div>
        <div id="tag_srcinner2" style="width: 1000px;">
            <a href="../Submission/Export_Excel_Format/EXPORT_BULK_REF_NO_UPDATE.xlsx" target="_new">
                Download Excel File Format </a>
        </div>
    </div>
               


</asp:Content>
