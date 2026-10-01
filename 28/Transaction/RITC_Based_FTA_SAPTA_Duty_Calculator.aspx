<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RITC_Based_FTA_SAPTA_Duty_Calculator.aspx.cs"
    Inherits="RITC_Based_FTA_SAPTA_Duty_Calculator" %>

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
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        
        .shadowbox
        {
            width: 55em;
            height: 1em;
            border: 1px solid #9370DB;
            box-shadow: 2px 4px 5px #40E0D0;
            padding: 8px 12px;
            background-image: linear-gradient(180deg, #40E0D0, #ddd 40%, #ccc);
            text-align: center;
        }
        
        .shadowbox_list
        {
            width: 55em;
            height: 1em;
            border: 1px solid #9370DB;
            box-shadow: 2px 4px 5px #DDA0DD;
            padding: 8px 12px;
            background-image: linear-gradient(180deg, #DDA0DD, #ddd 40%, #ccc);
        }
    </style>
    <script type="text/javascript">

        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox


                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {

                    if (!inputList[i].checked) {

                        checked = false;
                        //row.style.backgroundColor = "White";
                        break;
                    }
                    else {

                        //row.style.backgroundColor = "LightGray";
                    }
                }
                else {

                    //row.style.backgroundColor = "LightGray";
                }
            }
            headerCheckBox.checked = checked;

        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            //alert(inputList);
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        // row.style.backgroundColor = "LightGray";
                        inputList[i].checked = true;
                    }
                    else {
                        /*
                        if (row.rowIndex % 2 == 0) {
                        row.style.backgroundColor = "#C2D69B";
                        //row.style.backgroundColor = "LightGray";
                        }
                        else {
                        row.style.backgroundColor = "LightGray";
                        }
                        */
                        inputList[i].checked = false;
                        //row.style.backgroundColor = "White";
                    }
                }
            }
        }

    </script>
   
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false">
    </asp:ScriptManager>
    <div class="loading" align="center" id="load" style="display: none;">
        <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
    </div>
    <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 750px;
        width: 1092px;">
        <div style="overflow: auto; margin-top: 10px; margin-bottom: 30px; height: 550px;">
            
            <div id="tag_transac_lft_in1" style="margin-left: 10px; width: 900px; margin-bottom: 20px;
                margin-top: 10px;">
                <div id="tag_label_transaction_popup_gen" style="width: 130px; font-weight: bold;
                    color: Blue;">
                    IMPORT JOBNO :
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:Label ID="lbl_jobno" runat="server" Font-Bold="true" ForeColor="Blue"></asp:Label>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_gen" style="width: 50px; font-weight: bold;
                    margin-left: 20px; color: Blue;">
                    CTH
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:DropDownList ID="ddl_CTH" runat="server" CssClass="listtxt_transac_src1" AutoPostBack="True"
                        Height="25px" BackColor="LightCyan" Width="150px" OnSelectedIndexChanged="ddl_CTH_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_gen" style="width: 50px; font-weight: bold;
                    margin-left: 20px; color: Blue;">
                    Country
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:DropDownList ID="ddl_Country" runat="server" 
                        CssClass="listtxt_transac_src1" AutoPostBack="True"
                        Height="25px" BackColor="LightCyan" Width="150px" 
                        onselectedindexchanged="ddl_Country_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
            </div>
          
            <div id="tag_transac_lft_in1" style="margin-left: 10px; width: 900px;">
                <div id="tag_label_transaction_popup_gen" style="width: 180px; font-weight: bold;">
                    CUSTOMS TARIFF HEAD
                </div>
                <div id="tag_label_transaction_popup_gen" style="width: 10px; font-weight: bold;">
                    :
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:Label ID="lbl_CTH" runat="server"></asp:Label>
                </div>
                <div id="tag_label_transaction_popup_gen" style="width: 70px; font-weight: bold;
                    margin-left: 300px;">
                    Country
                </div>
                <div id="tag_label_transaction_popup_gen" style="width: 10px; font-weight: bold;">
                    :
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:Label ID="lbl_Country" runat="server"></asp:Label>
                </div>
            </div>
            <div id="tag_transac_lft_in1" style="margin-left: 10px; width: 900px;">
                <div id="tag_label_transaction_popup_gen" style="width: 180px; font-weight: bold;">
                    FTA
                </div>
                <div id="tag_label_transaction_popup_gen" style="width: 10px; font-weight: bold;">
                    :
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:Label ID="lbl_FTA" runat="server" Width="500px"></asp:Label>
                </div>
            </div>
            <div id="tag_transac_lft_in1" style="margin-left: 10px; width: 1100px;">
                <div id="tag_label_transaction_popup_gen" style="width: 180px; font-weight: bold;">
                    DESCRIPTION
                </div>
                <div id="tag_label_transaction_popup_gen" style="width: 10px; font-weight: bold;">
                    :
                </div>
                <div id="myDiv_dynamic" runat="server" style="display: inline-block; padding: 5px;
                    max-width: 700px; word-wrap: break-word; margin-bottom: 10px;">
                    <asp:Label ID="lbl_Description" runat="server"></asp:Label>
                </div>
            </div>
            <%--<span id="spn_Preview1" runat="server" >--%>
            <asp:Panel ID="pnlGrid" runat="server">
                <asp:Label ID="lblempty" runat="server" Width="988px" Height="50px"></asp:Label>
                <asp:Label ID="lbl_heading_NOTN" runat="server" class="shadowbox" Text="FTA - Notification Details" Font-Bold="true"
                    ForeColor="Red" Width="980px"></asp:Label>
                <div id="tag_transac_lft_Item_maindet_Grid_area1" class="shadowbox" runat="server"
                    style="overflow: auto; height: 220px; width: 980px; margin-top: 8px; margin-bottom: 25px;">
                    <asp:GridView ID="gv_FTA_NOTN" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                        RowStyle-Height="25px" OnRowDataBound="gv_FTA_NOTN_RowDataBound" AllowSorting="True"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                        OnRowCreated="gv_FTA_NOTN_RowCreated">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <SelectedRowStyle Font-Bold="true" />
                        <Columns>
                            <asp:BoundField DataField="CTHNO" HeaderText="CTH" HeaderStyle-Width="15%" HeaderStyle-Font-Bold="true"
                                HeaderStyle-Font-Size="Small">
                                <ItemStyle CssClass="column_style_left5" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTNSLNO" HeaderText="FTA Notn/Slno" HeaderStyle-Width="10%" ItemStyle-Font-Bold="true"
                                HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
                                <ItemStyle CssClass="column_style_left5" Width="10%" />
                            </asp:BoundField>
                             
                            <asp:BoundField DataField="COUNTRY" HeaderText="COUNTRY NAME" HeaderStyle-Width="25%"
                                HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
                                <ItemStyle CssClass="column_style_left5" Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FTAPTA" HeaderText="FTA - PTA" HeaderStyle-Width="25%"
                                HeaderStyle-Font-Bold="true" HeaderStyle-Font-Size="Small">
                                <ItemStyle CssClass="column_style_left5" Width="25%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
               
                <asp:Label ID="lbl_heading_ADD_NOTN" runat="server" class="shadowbox" Text="Anti Dumping Duty - Details" Font-Bold="true"
                    ForeColor="Red" Width="980px"></asp:Label>
                <div id="tag_transac_lft_Item_maindet_Grid_area5" class="shadowbox" visible="false"
                    runat="server" style="overflow: auto; height: 220px; width: 980px; margin-top: 8px;
                    margin-bottom: 25px;">
                    <asp:GridView ID="gv_ADD_NOTN" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                        AllowSorting="True" BorderColor="#C8C8C8" OnRowDataBound="gv_ADD_NOTN_RowDataBound"
                        OnRowCreated="gv_ADD_NOTN_RowCreated" BorderStyle="Solid" BorderWidth="1px" CellPadding="1"
                        CellSpacing="1">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <SelectedRowStyle Font-Bold="true" />
                        <Columns>
                            <asp:BoundField DataField="NOTN_NO" HeaderText="Notn No" HeaderStyle-Width="10%"
                                HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NOTN_SLNO" HeaderText="Notn Slno" HeaderStyle-Width="10%"
                                HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item Slno" HeaderStyle-Width="10%"
                                HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="10%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ITEM_DESC" HeaderText="Description" HeaderStyle-Width="15%"
                                HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COUNTRY_ORG" HeaderText="Coutry Org" HeaderStyle-Width="15%"
                                HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SUPP_SLNO" HeaderText="Supp Slno" HeaderStyle-Width="15%"
                                HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PRODUCER_NAME" HeaderText="Producer Name" HeaderStyle-Width="15%"
                                HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EXPORTER_NAME" HeaderText="Exporter Name" HeaderStyle-Width="25%"
                                HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="25%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UQC" HeaderText="UQC" HeaderStyle-Width="15%" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ANTIDUMP_DUTY" HeaderText="Duty" HeaderStyle-Width="15%"
                                HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CURR" HeaderText="Currency" HeaderStyle-Width="15%"
                                HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left5" Width="15%" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:Label ID="lbl_heading_SWS" runat="server" class="shadowbox" Text="Single Window - PGA Codes" Font-Bold="true"
                    ForeColor="Red" Width="980px"></asp:Label>
                <div id="tag_transac_lft_Item_maindet_Grid_area3" class="shadowbox" runat="server"
                    style="overflow: auto; height: 230px; width: 980px; margin-top: 8px; margin-bottom: 25px;">
                    <asp:GridView runat="server" ID="gv_SW" AutoGenerateColumns="false" BackColor="WhiteSmoke"
                        EmptyDataText="NO RECORD FOUND" GridLines="Both" CssClass="grid-view" Width="100%"
                        ShowHeaderWhenEmpty="True" AllowSorting="True" OnRowDataBound="gv_SW_RowDataBound"
                        OnRowCreated="gv_SW_RowCreated" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1">
                        <Columns>
                            <asp:BoundField DataField="PGA Code" HeaderText="PGA Code" HeaderStyle-VerticalAlign="Bottom"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" HeaderStyle-Height="25px"
                                HeaderStyle-Width="65px" HeaderStyle-BorderWidth="1px">
                                <ItemStyle BackColor="WhiteSmoke" Height="25px" BorderColor="LightBlue" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PGA Name" HeaderText="PGA Name" HeaderStyle-Font-Bold="true"
                                HeaderStyle-BorderWidth="1px">
                                <ItemStyle BackColor="WhiteSmoke" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INFO Code" HeaderText="INFO Code" HeaderStyle-Font-Bold="true"
                                HeaderStyle-BorderWidth="1px" HeaderStyle-Width="65px">
                                <ItemStyle BackColor="WhiteSmoke" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INFO Desc" HeaderText="INFO Desc" HeaderStyle-Font-Bold="true"
                                HeaderStyle-BorderWidth="1px">
                                <ItemStyle BackColor="WhiteSmoke" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QFR Code" HeaderText="QFR Code" HeaderStyle-Font-Bold="true"
                                HeaderStyle-BorderWidth="1px" HeaderStyle-Width="65px">
                                <ItemStyle BackColor="WhiteSmoke" />
                            </asp:BoundField>
                            <asp:BoundField DataField="QFR Desc" HeaderText="QFR Desc" HeaderStyle-Font-Bold="true"
                                HeaderStyle-BorderWidth="1px">
                                <ItemStyle BackColor="WhiteSmoke" />
                            </asp:BoundField>
                            <asp:BoundField DataField="REQ" HeaderText="REQ" HeaderStyle-Font-Bold="true" HeaderStyle-BorderWidth="1px">
                                <ItemStyle BackColor="WhiteSmoke" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Man Opt" HeaderText="Man/Opt" HeaderStyle-Font-Bold="true"
                                HeaderStyle-BorderWidth="1px">
                                <ItemStyle BackColor="LightPink" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:Label ID="lbl_heading_Docs_Mandatory" runat="server" class="shadowbox" Text="Mandatory Documents List" Font-Bold="true"
                    ForeColor="Red" Width="980px"></asp:Label>
                <div id="tag_transac_lft_Item_maindet_Grid_area4" class="shadowbox" runat="server"
                    style="overflow: auto; height: 230px; width: 980px; margin-top: 8px; margin-bottom: 25px;">
                    <asp:GridView runat="server" ID="gv_MandatoryDocs" AutoGenerateColumns="false" BackColor="WhiteSmoke"
                        EmptyDataText="NO RECORD FOUND" GridLines="Both" CssClass="grid-view" Width="100%"
                        OnRowCreated="gv_MandatoryDocs_RowCreated" ShowHeaderWhenEmpty="True" AllowSorting="True"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1">
                        <Columns>
                            <asp:BoundField DataField="SLNO" HeaderText="SLNO" HeaderStyle-VerticalAlign="Bottom"
                                HeaderStyle-HorizontalAlign="Center" HeaderStyle-Font-Bold="true" HeaderStyle-Height="25px"
                                HeaderStyle-Width="65px" HeaderStyle-BorderWidth="1px">
                                <ItemStyle BackColor="WhiteSmoke" Height="25px" BorderColor="LightBlue" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STMT_CODE" HeaderText="STMT_CODE" HeaderStyle-Font-Bold="true"
                                HeaderStyle-BorderWidth="1px" HeaderStyle-Width="105px">
                                <ItemStyle BackColor="WhiteSmoke" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STMT_TEXT" HeaderText="STMT_TEXT" HeaderStyle-Font-Bold="true"
                                HeaderStyle-BorderWidth="1px" HeaderStyle-Width="365px">
                                <ItemStyle BackColor="WhiteSmoke" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:Label ID="lbl_CCR" runat="server" class="shadowbox" Text="Compulsory compliance Requirements (CCRs)" Font-Bold="true"
                    ForeColor="Red" Width="980px"></asp:Label>
                <div id="tag_transac_lft_in1" style="margin-left: 10px; margin-top: 10px; width: 900px;
                    margin-bottom: 30px;">
                    <asp:Label ID="lbl_CCR_Text" runat="server" Width="980px"></asp:Label>
                </div>
                <div id="tag_transac_lft_in1" style="margin-left: 10px; margin-top: 10px; width: 900px;
                    margin-bottom: 30px;">
                </div>
            </asp:Panel>
        </div>
        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1040px;
            margin-top: 25px; margin-bottom: 20px;">
            <div id="txtcon-m_transaction_Supp_code" style="width: 435px;">
            </div>
            <div id="tag_label_transaction_popup_IGM2_empty">
            </div>
            <%--<div id="txtcon-m_transaction_Supp_code" style="width: 20px;">
                <asp:Button ID="btndelete" runat="server" Text="Bulk Delete" Width="100px" TabIndex="18"
                    Height="30px" ForeColor="Blue" Font-Bold="true" OnClick="btndelete_Click" />
            </div>--%>
            <div id="tag_label_transaction_popup_IGM2_empty">
            </div>
            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
            </div>
            <div id="txtcon-m_transaction_Supp_code" style="width: 170px;">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
