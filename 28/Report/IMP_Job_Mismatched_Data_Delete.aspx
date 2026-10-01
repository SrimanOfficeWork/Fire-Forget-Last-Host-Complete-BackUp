<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IMP_Job_Mismatched_Data_Delete.aspx.cs" Inherits="IMP_Flatfile_Validation" %>
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
        
      .shadowbox {
          width: 55em;
          height: 1em;
          border: 1px solid #9370DB;
          box-shadow: 2px 4px 5px #40E0D0;
          padding: 8px 12px;
          background-image: linear-gradient(180deg, #40E0D0, #ddd 40%, #ccc);
          text-align :center;
        }
        
          .shadowbox_list {
          width: 55em;
          height: 1em;
          border: 1px solid #9370DB;
          box-shadow: 2px 4px 5px #DDA0DD;
          padding: 8px 12px;
          background-image: linear-gradient(180deg, #DDA0DD, #ddd 40%, #ccc);
        }

    </style>
    
 <script type = "text/javascript">

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

    <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 650px;
        width: 1092px;">
        <div style="overflow: auto; margin-top:10px; margin-bottom:30px;">
            <span class="shadowbox" style="color: Blue; font-size:larger; font-weight:bold;">Import Job No :
                <asp:Literal ID="lbl_jobno" runat="server"></asp:Literal>
            </span><span id="spn_heading1" class="shadowbox" runat="server" style="color: Blue; margin-left: 150px; font-size:larger; font-weight:bold;">Job Mismatched Records List
            </span>


            <asp:Label ID="lblempty" runat="server" Width="988px" Height="50px"></asp:Label>

           <%-- <div id="tag_transac_lft_Item_maindet_Grid_area1_j1" runat="server" style="overflow: auto;
                height: 145px; width: 980px; margin-top: 20px;">--%>

                <span id="spn_Preview1" runat="server" visible="false">
             
                  <asp:Label ID="lbl_SW_INFO_TYPE" runat="server"  class="shadowbox" Text="SW Info Type Details" ForeColor="Red" Width="1020px" ></asp:Label>
                <asp:GridView ID="gv_Preview_1" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                    CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                    Width="100%" OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkTotalAll" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chk_All" onclick="Check_Click(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="SW_INFO_TYPE_ID" HeaderText="ID">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Invoice SlNo">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item SlNo">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INFO_TYPE" HeaderText="Info Type">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INFO_QUALIFIER" HeaderText="Info Qualifier">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INFO_CODE" HeaderText="Info Code">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INFO_MSR" HeaderText="Info MSR">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INFO_UQC" HeaderText="Info UQC">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
              
                <asp:Label ID="lbl_SW_SUP_DOCS" runat="server"  class="shadowbox" Text="SW Supporting Documents" ForeColor="Red" Width="1020px"></asp:Label>
                <asp:GridView ID="gv_Preview_2" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                    CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                    Width="100%" OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkTotalAll" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chk_All" onclick="Check_Click(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="JOBNO" HeaderText="Job No">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SW_ID" HeaderText="SW_ID">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Invoice SlNo">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item SlNo">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SELECT_TYPE" HeaderText="Level">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="IMAGE_REF_NUMBER" HeaderText="Image Ref. no">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DOC_TYPE_CODE" HeaderText="Doc.Type Code">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>

               
                <asp:Label ID="lbl_Statement" runat="server"  class="shadowbox" Text="SW Statement" ForeColor="Red" Width="1020px"></asp:Label>
                <asp:GridView ID="gv_Preview_3" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                    CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                    Width="100%" OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkTotalAll" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chk_All" onclick="Check_Click(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="JOBNO" HeaderText="Job No">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SW_ID" HeaderText="SW_ID">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Invoice SlNo">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item SlNo">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STMT_TYPE" HeaderText="Stmt Type">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="STMT_CODE" HeaderText="Stmt Code">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>


                 <asp:Label ID="lbl_License" runat="server"  class="shadowbox" Text="License Details" ForeColor="Red" Width="1020px" ></asp:Label>
                <asp:GridView ID="gv_Preview_4" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                    CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                    Width="100%" OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkTotalAll" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chk_All" onclick="Check_Click(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="JOBNO" HeaderText="Job No">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LICENSE_ID" HeaderText="LICENSE_ID">
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Invoice SlNo">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item SlNo">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="REGISTRATION_NO" HeaderText="Registration No">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="LICENSE_SLNO" HeaderText="License SlNo">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SCHEME_CODE" HeaderText="Scheme Code">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>

                <asp:Label ID="lbl_Container" runat="server"  class="shadowbox" Text="Container Details" ForeColor="Red" Width="980px"></asp:Label>
                <asp:GridView ID="gv_Preview_5" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                    BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                    CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
                    Width="100%" OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        CssClass="column_style_right" BorderWidth="1px" />
                    <HeaderStyle Font-Underline="false" ForeColor="Black" />
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox runat="server" ID="chkTotalAll" onclick="checkAll(this);" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chk_All" onclick="Check_Click(this)" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="JOBNO" HeaderText="Job No" HeaderStyle-Width="10%" >
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONTAINERID" HeaderText="CONTAINERID" HeaderStyle-Width="10%" >
                            <HeaderStyle CssClass="hideGridColumn" />
                            <ItemStyle CssClass="hideGridColumn" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONTAINER_IGM_SLNO" HeaderText="IGM SlNo" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONTAINER_IGM_NO" HeaderText="IGM No" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CONTAINER_NO" HeaderText="Container No" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SEAL_NO" HeaderText="Seal No" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FCL_OR_LCL" HeaderText="FCL_OR_LCL" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>

           <%-- </div>--%>
           </span>
            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1040px;
                margin-top: 25px; margin-bottom:20px;">
                <div id="txtcon-m_transaction_Supp_code" style="width: 435px;">
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 20px;">
                    <asp:Button ID="btndelete" runat="server" Text="Bulk Delete" Width="100px" TabIndex="18"
                        Height="30px" ForeColor="Blue" Font-Bold="true" OnClick="btndelete_Click" />
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 170px;">
                </div>
            </div>
        </div>

         <asp:Label ID="lbl_heading_NOTN" runat="server"  class="shadowbox" Text="Check - Data Validation" ForeColor="Red" Width="980px"></asp:Label>
        <div id="tag_transac_lft_Item_maindet_Grid_area1"  class="shadowbox" visible="false" runat="server" style="overflow: auto;  
            height: 245px; width: 980px; margin-top: 8px; margin-bottom:25px;" > 
           
            <asp:GridView ID="gv_NOTN" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                OnRowDataBound="gv_NOTN_RowDataBound" AllowSorting="True"
                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                OnRowCreated="gv_NOTN_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    BorderWidth="1px" />
                <SelectedRowStyle Font-Bold="true" />
                <Columns>
                    <asp:BoundField DataField="NOTN_TYPE" HeaderText="Field Type" HeaderStyle-Width="15%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PRODUCT_CTH" HeaderText="CTH / CETH" HeaderStyle-Width="25%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="25%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOTN_NO" HeaderText="Notn No" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NOTN_SLNO" HeaderText="Notn SlNo" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="INV_SLNO" HeaderText="Inv SlNo" HeaderStyle-Width="25%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="25%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item Slno" HeaderStyle-Width="100%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="100%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>


        <asp:Label ID="lbl_heading_NOTN2" runat="server"  class="shadowbox" Text="Check - Page Validation" ForeColor="Red" Width="980px"></asp:Label>
         <div id="tag_transac_lft_Item_maindet_Grid_area2"  class="shadowbox" runat="server" style="overflow: auto;
            height: 245px; width: 980px; margin-top: 8px; margin-bottom:25px;" >
            
            <asp:GridView ID="gv_All_Vaidation" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                OnRowDataBound="gv_All_Vaidation_RowDataBound"  OnRowCreated="gv_All_Vaidation_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    BorderWidth="1px" />
                <SelectedRowStyle Font-Bold="true" />
                <Columns>
                    <asp:BoundField DataField="SLNO" HeaderText="SlNo" HeaderStyle-Width="5%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Invoice SlNo" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item SlNo" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="PAGE_NAME" HeaderText="Page Name" HeaderStyle-Width="25%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="25%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ERROR_DESCRIPTION" HeaderText="Error Description" HeaderStyle-Width="40%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="COLUMN_NAME" HeaderText="Column Name" HeaderStyle-Width="40%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="40%" />
                    </asp:BoundField>
                     <asp:BoundField DataField="DATA" HeaderText="Data" HeaderStyle-Width="100%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="100%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>

          <asp:Label ID="lbl_heading5" runat="server" class="shadowbox" Text="Mismatched Invoice Value & Product Value"
            ForeColor="Red" Width="980px"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="" Width="1070px"></asp:Label>
        <div id="pop_text_area_transac_popup_inn_container_IGM_Bond2_grid2" runat="server"  class="shadowbox" 
            style="overflow: auto; height: 215px; width: 980px; margin-top: 10px; margin-bottom: 25px;">
            <asp:GridView ID="gv_Inv_Item" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                OnRowCreated="gv_INVOICENO_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    BorderWidth="1px" />
                <SelectedRowStyle Font-Bold="true" />
                <Columns>
                    <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv. SlNo" HeaderStyle-Width="15%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="INVOICE_VALUE" HeaderText="Inv. Value" HeaderStyle-Width="32%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="32%" ForeColor="Red" Font-Bold="true" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Product_Value" HeaderText="Product Value" HeaderStyle-Width="32%" HeaderStyle-Font-Bold="true">
                        <ItemStyle ForeColor="Red" CssClass="column_style_left5" Width="32%" Font-Bold="true" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
        </div>

         <asp:Label ID="lbl_heading1" runat="server"  class="shadowbox" Text="Duplicate Invoice No" ForeColor="Red" Width="980px"></asp:Label>
         <asp:Label ID="Label1" runat="server"  Text="" Width="1070px"></asp:Label>

        <div id="pop_text_area_transac_popup_inn_container_IGM_Bond2_grid" runat="server"  class="shadowbox" 
            style="overflow: auto; height: 215px; width: 980px; margin-top: 10px;margin-bottom:25px;">
           
            <asp:GridView ID="gv_INVOICENO" runat="server" EmptyDataText="NO RECORD FOUND" Width="140%"
                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                OnRowCreated="gv_INVOICENO_RowCreated" OnPageIndexChanging="gv_INVOICENO_PageIndexChanging">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    BorderWidth="1px" />
                <SelectedRowStyle Font-Bold="true" />
                <Columns>
                    <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv SlNo" HeaderStyle-Width="15%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="INVOICE_NO" HeaderText="Invoice No" HeaderStyle-Width="20%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="JOBNO_LIST" HeaderText="JobNo List" HeaderStyle-Width="65%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="65%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>

         <asp:Label ID="lbl_IGST_NOTN_SLNO" runat="server"  Visible="false"  class="shadowbox" Text="Check IGST Notn" ForeColor="Red" Width="980px"></asp:Label>
        <div id="tag_transac_lft_IGM_Invoice_Grid_area" runat="server" visible="false" style="overflow: auto;
            height: 175px; width: 980px; margin-top: 10px;margin-bottom:25px;">
            <asp:GridView ID="GV_IGST_NOTN" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                PageSize="5" AllowPaging="True" OnRowDataBound="GV_IGST_NOTN_RowDataBound" AllowSorting="True"
                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                OnRowCreated="GV_IGST_NOTN_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    BorderWidth="1px" />
                <SelectedRowStyle Font-Bold="true" />
                <Columns>
                    <asp:BoundField DataField="CTH_NO" HeaderText="CTH_NO" HeaderStyle-Width="15%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Invslno" HeaderText="Inv SlNo" HeaderStyle-Width="15%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="15%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ItemSlNo" HeaderText="Item Slno" HeaderStyle-Width="25%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="25%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IGST_Notn" HeaderText="IGST_Notn" HeaderStyle-Width="15%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IGST_NotnSLno" HeaderText="IGST Slno" HeaderStyle-Width="35%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="35%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>

         <asp:Label ID="lbl_FTA_Validation" runat="server"  Visible="false"  class="shadowbox" Text="FTA -Country Validation" ForeColor="Red" Width="980px"></asp:Label>
        <div id="tag_transac_lft_IGM_Invoice_Grid_area4" runat="server" visible="false" style="overflow: auto;
            height: 175px; width: 980px; margin-top: 10px;margin-bottom:25px;">
            <asp:GridView ID="GV_FTA_Country" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                PageSize="5" AllowPaging="True" OnRowDataBound="GV_IGST_NOTN_RowDataBound" AllowSorting="True"
                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                OnRowCreated="GV_IGST_NOTN_RowCreated">
                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                    BorderWidth="1px" />
                <SelectedRowStyle Font-Bold="true" />
                <Columns>
                    <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv SlNo" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item Slno" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TRANSIT_COUNTRY" HeaderText="Item Transit Country" HeaderStyle-Width="20%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="INFO_CODE" HeaderText="SW Info Code" HeaderStyle-Width="10%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="10%" />
                    </asp:BoundField>
                     <asp:BoundField DataField="FTA_COO_Status" HeaderText="FTA_COO_Status" HeaderStyle-Width="60%" HeaderStyle-Font-Bold="true">
                        <ItemStyle CssClass="column_style_left5" Width="60%" />
                    </asp:BoundField>
                </Columns>
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
  <div  style="overflow: auto;">
          <span style="color:Red;" > <asp:Literal ID="lbl_SW_FTA" runat="server"></asp:Literal> </span>
         <asp:GridView ID="GV_SW_FTA" runat="server" AllowPaging="false" AutoGenerateColumns="true" 
            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" ShowHeaderWhenEmpty="True"
            OnRowCreated="gv_Details_RowCreated" OnRowDataBound="gv_Details_RowDataBound">
            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"  CssClass="column_style_right" BorderWidth="1px" />
        </asp:GridView>
       </div>

</div>
        <asp:Label ID="lbl_CommonValidation" runat="server"   class="shadowbox" Text="Check Mandatory Validation" ForeColor="Red" Visible="false" Width="980px" ></asp:Label>
        <div id="tag_transac_lft_IGM_Invoice_Grid_area2" runat="server" style="overflow: auto;
            height: 15px; width: 980px; margin-top: 10px;"></div>

       
            <asp:Label ID="lbl_Validation_All" runat="server" ForeColor="Red" Width="980px"></asp:Label>
                   <asp:Label ID="Label2" runat="server" ForeColor="Red" Width="980px"></asp:Label>
            

 <div id="tag_transac_lft_IGM_Invoice_Grid_area3" runat="server" style="overflow: auto;
            height: 175px; width: 980px; margin-top: 10px;margin-bottom:20px;">
    </div>

            
    </form>
</body>
</html>
