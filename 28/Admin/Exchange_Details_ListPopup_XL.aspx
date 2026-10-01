<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exchange_Details_ListPopup_XL.aspx.cs"
    Inherits="Exchange_Details_ListPopup_XL" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Exchange Master Listpopup</title>
    <link href="../mainpopup.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <script src="../js/Validation.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        .print_btn:hover
        {
            background-position: left bottom;
        }
    </style>
    <script language="javascript" type="text/javascript">

        function GetRowValue(val, val1) {

            window.opener.document.getElementById("txtInvoiceCurrency").value = val;
            window.opener.document.getElementById("txtExRate").value = val1;
            window.close();

        }
        function GetRowValue_Misc(val, val1) {


            window.opener.document.getElementById("txtMiscellaneous_Currency").value = val;
            window.opener.document.getElementById("txtMiscellaneous_Exch_Rate").value = val1;


            window.close();

        }
        function GetRowValue_Agency(val, val1) {


            window.opener.document.getElementById("txtAgency_Currency").value = val;
            window.opener.document.getElementById("txtAgency_Exch_Rate").value = val1;


            window.close();

        }
        function GetRowValue_Discount(val, val1) {


            window.opener.document.getElementById("txtDiscount_Currency").value = val;
            window.opener.document.getElementById("txtDiscount_Exch_Rate").value = val1;


            window.close();

        }
        function GetRowValue_Loading(val, val1) {


            window.opener.document.getElementById("txtLoading_Currency").value = val;
            window.opener.document.getElementById("txtLoading_ExchRate").value = val1;


            window.close();

        }

        function GetRowValue_Freight(val, val1) {


            window.opener.document.getElementById("txtFreight_Currency").value = val;
            window.opener.document.getElementById("txtFreight_Exch_Rate").value = val1;
            window.opener.document.getElementById("txtFreight_Currency").focus();
            window.opener.document.getElementById("txtFreight_Exch_Rate").focus();
            window.close();

        }
        function GetRowValue_Insurance(val, val1) {


            window.opener.document.getElementById("txtInsurance_Currency").value = val;
            window.opener.document.getElementById("txtInsurance_Exch_Rate").value = val1;
            window.opener.document.getElementById("txtInsurance_Currency").focus();
            window.opener.document.getElementById("txtInsurance_Exch_Rate").focus();

            window.close();

        }
        function GetRowValue_HighSeaSale(val, val1) {


            window.opener.document.getElementById("txtHighSeaSale_Currency").value = val;
            window.opener.document.getElementById("txtHighSeaSale_Exch_Rate").value = val1;
            window.opener.document.getElementById("txtHighSeaSale_Currency").focus();
            window.opener.document.getElementById("txtHighSeaSale_Exch_Rate").focus();

            window.close();

        }
        function GetRowValue_ITEM_UNITCODE(val) {


            window.opener.document.getElementById("txtItem_UnitPriceCode").value = val;
            window.close();


        }
        function GetRowValue_ITEM_AMOUNTCODE(val) {


            window.opener.document.getElementById("txtItem_AmountCode").value = val;
            window.close();


        }

        function GetRowValue_Export(val, val1) {


            window.opener.document.getElementById("txtInvoiceCurrency").value = val;
            window.opener.document.getElementById("txtExchangeRate").value = val1;
            window.close();

        }

        function GetRowValue_Export_Commission(val) {


            window.opener.document.getElementById("txtCommission_Currency").value = val;
            //            window.opener.document.getElementById("txtExchangeRate").value = val1;
            window.close();

        }


        function GetRowValue_Export_FOBDisc(val) {

            window.opener.document.getElementById("txtFOBDisc_Currency").value = val;
            //            window.opener.document.getElementById("txtExchangeRate").value = val1;
            window.close();

        }
        function GetRowValue_Export_PackMisc(val) {

            window.opener.document.getElementById("txtPackMisc_Currency").value = val;
            //            window.opener.document.getElementById("txtExchangeRate").value = val1;
            window.close();

        }
        function GetRowValue_Export_OtherDeductions(val) {

            window.opener.document.getElementById("txtOtherDeductions_Currency").value = val;
            //            window.opener.document.getElementById("txtExchangeRate").value = val1;
            window.close();

        }
        function GetRowValue_Export_Freight(val) {

            window.opener.document.getElementById("txtFreight_Currency").value = val;
            //            window.opener.document.getElementById("txtExchangeRate").value = val1;
            window.close();

        }
        function GetRowValue_Export_Insurance(val) {

            window.opener.document.getElementById("txtInsurance_Currency").value = val;
            //            window.opener.document.getElementById("txtExchangeRate").value = val1;
            window.close();

        }
        function GetRowValue_Tariff_Amount_Unit(val) {

            window.opener.document.getElementById("txtTariff_Amount_unitCode").value = val;
            //            window.opener.document.getElementById("txtExchangeRate").value = val1;
            window.close();

        }

        function GetRowValue_QuoteCurrency(val, val1) {

            window.opener.document.getElementById("txtCurrency").value = val;
            window.opener.document.getElementById("txtExRate").value = val1;
            window.close();

        }

        function GetRowValue_BL_Generation_Unit(val) {

            window.opener.document.getElementById("txt_Currency").value = val;
            //            window.opener.document.getElementById("txtExchangeRate").value = val1;
            window.close();

        }

        function GetRowValue_LicenseCurrency(val, val1) {
            debugger;
            window.opener.document.getElementById("txt_LicenseCurrency").value = val;
            window.opener.document.getElementById("txt_Exrate").value = val1;
            window.close();

        }
                
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
             <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>  
            <div id="innerbox_MidMain_popup_currency" >
            
                <div id="innerbox_MidMain_top_currency" runat="server">
                    Exchange Master
                    
                                   
                </div>
                <div id="innerbox_MidMain_Mid_country_pop" runat="server">
                    <div id="innerbox_MidMain_popup_country_master" >
                        <div id="tag_label_country_pop" runat="server">
                            Select Excel File
                        </div>
                        <div id="txtcon-l_src_popup">
                        </div>
                        <div id="txtcon_mid_size_popup"style="width:65px";>
                                

                                 <asp:FileUpload ID="fileuploadExcel" runat="server"  onchange="document.getElementById('btnupload').click();"/>
                                         <asp:Button ID="btnupload" runat="server" OnClick="btnupload_Click" Style="display: none;" />

                        </div>
                        <div id="txtcon-r_src_popup">
                        </div>
                         
                      
                    </div>
                    <div id="tag_srcinner_rght2_country">
                        <div id="small-butt-left">
                         
                                 
                        </div>
                        <div id="small-butt-rght">
                          <%--<a href="#" class="cancelButt" onclick="window.close();"></a>--%>
                        </div>
                    </div>
                    <asp:Button ID="btnSave" runat="server" Height="21px" onclick="btnSave_Click" 
                        style="bottom: -55px; margin-left: 0px;" Text="Save" Width="75px" />
                </div>
                <div id="innerbox_MidMain_Grid_currency_pop">
                    <div id="tag_srcinner1grid_innerpopup" runat="server" style="height:500px"  >

                         <asp:GridView ID="gvdetails" runat="server" AllowPaging="false" overflow="hidden"
                             AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                             BorderColor="#C8C8C8" BorderStyle="none" BorderWidth="100px" CellPadding="1" 
                             CellSpacing="1" CssClass="grid-view" DataKeyNames="CODE" 
                             EmptyDataText="No Record Found" Height="500px" PageSize="30"
                             HorizontalAlign="Left" OnRowCreated="gvdetails_RowCreated" 
                             OnRowDataBound="gvDetails_RowDataBound" ShowFooter="True" ShowHeader="True" 
                             ShowHeaderWhenEmpty="True" Width="100%">
                             <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" 
                                 BorderStyle="Solid" BorderWidth="7px" />
                             <HeaderStyle Font-Underline="false" ForeColor="Black" />
                             <Columns>
                                 <%-- <asp:TemplateField HeaderStyle-Width="30px" HeaderText="Allow">
                                 <ItemTemplate  >
                                     <asp:CheckBox ID="chk" runat="server" Checked="true" />
                                 </ItemTemplate>
                                 <ItemStyle  Width="30px" />
                                </asp:TemplateField>--%>
                                 <asp:BoundField DataField="SNO" HeaderStyle-Width="30px" HeaderText="Sno">
                                 <ItemStyle CssClass="column_style_right_new" Width="30px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="CURRENCY_NAME" HeaderStyle-Width="150px" 
                                     HeaderText="Cur. Name">
                                 <ItemStyle CssClass="column_style_left" Width="150px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="CODE" HeaderStyle-Width="50px" HeaderText="Code">
                                 <ItemStyle CssClass="column_style_left" Width="50px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="IMPORT_EX_RATE" HeaderStyle-Width="100px" 
                                     HeaderText="Imp. Ex-Rate">
                                 <ItemStyle CssClass="column_style_left" Width="100px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="EXPORT_EX_RATE" HeaderStyle-Width="100px" 
                                     HeaderText="Exp. Ex-Rate">
                                 <ItemStyle CssClass="column_style_left" Width="100px" />
                                 </asp:BoundField>
                             </Columns>
                         </asp:GridView>

  
                    </div>
                    
                </div>
            </div>
           </div> 
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
