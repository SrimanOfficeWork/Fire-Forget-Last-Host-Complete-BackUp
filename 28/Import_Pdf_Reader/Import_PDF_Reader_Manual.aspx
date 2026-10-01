<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_PDF_Reader_Manual.aspx.cs" Inherits="Import_PDF_Reader" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Bill Invoice</title>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
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

     <script  language="jscript" type="text/javascript">
         $(document).ready(function () {
             $('#btnPrevData').click(function () {
                 document.getElementById("lbl_loading").innerHTML = "File Loading...";
             });
         });
   
    </script>
    
  <style>
        /* Resetting margin and padding */
        body, html {
            margin: 0;
            padding: 0;
        }
        
        /* Container for the entire form */
        .form-container {
            max-width: 920px;
            margin: 20px auto;
            padding: 20px;
            border: 1px solid #ccc;
            background-color: #f9f9f9;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-left: 10px;
            margin-top: 10px;
            height:120px;
        }
        
        /* Row container */
        .form-row {
            display: flex;
            flex-wrap: wrap;
            margin-bottom: 10px;
        }
        
        /* Column styles */
        .form-column {
            flex: 1 1 calc(33.33% - 10px); /* Adjust width and subtract margin */
            margin-right: 10px;
        }
        
        /* Label styles */
        .form-label {
            /*display: block;*/
            font-weight: bold;
            margin-bottom: 5px;
        }
        
        /* Input field styles */
        .form-control {
            width: 55%;
            padding: 8px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />

                </div>
            <div id="innerbox_MidMain_Billing" style="height: 35px; width: 980px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                        Import - PDF Manual Upload
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="txtcon-m_Exchange" style="width: 50px;">
                            <asp:ImageButton ID="btn_Refresh" UseSubmitBehavior="false" runat="server" ImageUrl="~/images/icons/Refresh.png"
                                ToolTip="Refresh" Height="25px" Width="35px" OnClick="btn_Refresh_Click" />
                        </div>
                    </div>
                     <div id="txt_container_Transact_Main_l" style="width: 416px;">
                    <div id="tag_label_transaction_Src" style="width: 106px;">
                       Importer Name
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 223px;">
                        <asp:DropDownList ID="ddl_ImporterName" runat="server" TabIndex="1" Width="300px" Height="25px">
                        </asp:DropDownList>
                    </div>
                
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 200px; margin-left: 30px; font-weight: bold;
                        color: Blue;">
                        Job No
                        <asp:TextBox ID="txtjobPS" runat="server" Font-Bold="true" MaxLength="10" Font-Size="12px"
                            CssClass="txtbox_none_Mid_transac_code" Width="130px" ReadOnly="True" TabIndex="1"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <div id="popupwindow_closebut_right_new">
                        <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                </div>
            </div>

          <div class="form-container">
            <!-- Row 1 -->
            <div class="form-row">
                <div class="form-column">
                    <asp:Label ID="Label1" runat="server" class="form-label">Supplier Name</asp:Label>
                    <asp:TextBox ID="txtSupplier" CssClass="form-control" runat="server" style="Margin-left:26px"></asp:TextBox>
                </div>
                <div class="form-column">
                    <span class="form-label">Invoice No</span>
                    <asp:TextBox ID="txtInvNo" CssClass="form-control" runat="server" style="Margin-left:52px"></asp:TextBox>
                </div>
                <div class="form-column">
                    <span class="form-label">Invoice Date</span>
                    <asp:TextBox ID="txtInvDate" CssClass="form-control" runat="server" style="Margin-left:8px"></asp:TextBox>
                </div>
            </div>
            
            <!-- Row 2 -->
            <div class="form-row">
                <div class="form-column">
                    <span class="form-label">Country Of Origin</span>
                    <asp:TextBox ID="txtCountryOfOrigin" CssClass="form-control" runat="server" style="Margin-left:0px"></asp:TextBox>
                </div>
                <div class="form-column">
                    <span class="form-label">Port Of Discharge</span>
                    <asp:TextBox ID="txtPortOfOrigin" CssClass="form-control" runat="server" style="Margin-left:1px"></asp:TextBox>
                </div>
                <div class="form-column">
                    <span class="form-label">Qty Code</span>
                    <asp:TextBox ID="txtQTYCode" CssClass="form-control" runat="server" style="Margin-left:27px"></asp:TextBox>
                </div>
            </div>
            
            <!-- Row 3 -->
            <div class="form-row">
                <div class="form-column">
                    <span class="form-label">Currency</span>
                    <asp:TextBox ID="txtCurrency" CssClass="form-control" runat="server" style="Margin-left:64px"></asp:TextBox>
                </div>
                <div class="form-column">
                    <span class="form-label">Terms</span>
                    <asp:TextBox ID="txtTerms" CssClass="form-control" runat="server" style="Margin-left:82px"></asp:TextBox>
                </div>
                <div class="form-column">
                    <span class="form-label">Invoice Value</span>
                    <asp:TextBox ID="txtInvValue" CssClass="form-control" runat="server" style="Margin-left:0px"></asp:TextBox>
                </div>
            </div>
            </div>
            <div id="tag_srcinne1" style="height: 16px;margin-top: -20px;">
                <div id="txt_container_Transact_Main_l" style="width: 326px;margin-left: 11px">
                 <asp:FileUpload ID="FilePDF" runat="server"  ForeColor="Blue" TabIndex="2"/>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 450px;">
                   <asp:Button ID="btnPrevData" Style="margin-top: -3px; margin-left: 50px" 
                                Text="Upload" TabIndex="2"
                                CssClass="autowidbut" runat="server" onclick="btnPrevData_Click"/>
                                <asp:Label ID="lbl_loading" runat="server" ForeColor="Blue"></asp:Label>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 186px;">
                    <div id="tag_label_transaction_Src" style="width: 106px;" class="form-label">
                       Item Count</div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 55px;">
                        <asp:Label ID="lblCount" Width="75px" Font-Size="15px" runat="server" Font-Bold="true" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                            ClientIDMode="Static" TabIndex="1" Height="21px" style="text-align: center;"></asp:Label>
                    </div>
                </div>
            </div>           
                   

            <div class="content" id="page-1" style="margin-left: -22px; margin-bottom:0px;">
                <div id="open_item" runat="server">
                    <div class="content" id="page-6" >

                      
                       <div id="pop_text_area_transac_popup_inn_container_export" style="height: 255px;
                            width: 966px; margin-top: -16px;">
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 255px;
                                width: 960px;">
                                   <asp:GridView ID="gv_ItemPDF" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" OnRowCreated="gv_ItemPDF_RowCreated" OnRowDataBound="gv_ItemPDF_RowDataBound"
                                    ShowHeaderWhenEmpty="True">
                                    <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle Font-Bold="true" />                              

                                     <Columns>
                                      
                                        <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item Slno" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ITEM_DESC" HeaderText="Item Description" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="450px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="450px" Font-Size="11px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="ITEM_QTY" HeaderText="Item Qty" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>                                      
                                         <asp:BoundField DataField="ITEM_UNITPRICE" HeaderText="Item Unit Price" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                     
                                        <asp:BoundField DataField="ITEM_AMOUNT" HeaderText="Item Amt" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                            <asp:BoundField DataField="HSN_CODE" HeaderText="HSN Code" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                    
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="innerbox_MidMain_Trans" style="width: 1051px; height: 5px;  margin-top:-20px;
                        margin-left: -40px;">
                    </div>
            <div id="tag_transac_lft_in2" style="margin-top: 10px;">
                <div id="txtcon-m_Exchange" style="width: 400px;">
                </div>
                <div id="txtcon-m_Exchange" style="width: 100px;">
                     <asp:Button ID="btnupload" runat="server" Width="100px"  Height="30px" Text="Save" Visible="false" CssClass="autowidmovebut" TabIndex="4"
                            OnClick="btnupload_Click" />
                </div>
                <div id="txtcon-m_Exchange" style="width: 200px;">
                    <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                </div>
            </div>

            <%-----------------------------------END----------------------------------------------------------------%>
            
            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_alert" runat="server" />
            <asp:HiddenField ID="hdprefix" runat="server" />
                    <asp:HiddenField ID="hdsuffix" runat="server" />
                    <asp:HiddenField ID="hdn_JOBNO" runat="server" />
                    <asp:HiddenField ID="hdn_JOBNO_PS" runat="server" />
                    <asp:HiddenField ID="hdn_missed_Desc" runat="server" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" />
                    <asp:HiddenField ID="hdn_JOBNO_digit" runat="server" />
                    <asp:HiddenField ID="hd_Brslno" runat="server" />
                    <asp:HiddenField ID="hd_Supplier" runat="server" />
                    <asp:HiddenField ID="hd_InvNo" runat="server" />
                    <asp:HiddenField ID="hd_InvDate" runat="server" />
                    <asp:HiddenField ID="hd_Currency" runat="server" />
                    <asp:HiddenField ID="hd_Terms" runat="server" />
                    <asp:HiddenField ID="hd_InvValue" runat="server" />
                    <asp:HiddenField ID="hd_ItemSlNo" runat="server" />
                    <asp:HiddenField ID="hd_ItemDesc" runat="server" />
                    <asp:HiddenField ID="hd_Quantity" runat="server" />
                    <asp:HiddenField ID="hd_Rate" runat="server" />
                    <asp:HiddenField ID="hd_Amount" runat="server" />
                    <asp:HiddenField ID="hd_IPartNo" runat="server" />
                    <asp:HiddenField ID="hd_PONumber" runat="server" />
                    <asp:HiddenField ID="hd_NetWeight" runat="server" />
                    <asp:HiddenField ID="hd_HSCode" runat="server" />
                    <asp:HiddenField ID="hd_CustomsHouse" runat="server" />
                    <asp:HiddenField ID="hd_ImporterName" runat="server" />
                    <asp:HiddenField ID="hd_ImporterAdd1" runat="server" />
                    <asp:HiddenField ID="hd_ImporterAdd2" runat="server" />
                    <asp:HiddenField ID="hd_ImporterAdd3" runat="server" />
                    <asp:HiddenField ID="hd_ImporterAdd4" runat="server" />

           
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text="Delete Ur Previous Invoice for this Job ?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 100px; padding-top: 10px;">
                        <asp:Button ID="btnyes" runat="server" Text="Yes" CausesValidation="false" UseSubmitBehavior="false" />
                        <asp:Button ID="btnNo" runat="server" Text="No" CausesValidation="false" UseSubmitBehavior="false"
                            />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    </form>
   
     <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>

         <script type="text/javascript">
             function RefreshParent() {
                 window.parent.location.reload();
             }      
    </script>
    

</body>
</html>
