<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Inv_Item_Pdf_Reader.aspx.cs" Inherits="Imp_Inv_Pdf_Reader" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Bill Invoice</title>
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
           <div id="innerbox_MidMain" style="height: 85px;">
          <div id="tag_srcinner1">
            <%--<div id="newbu">
                <input type="submit" value="Submit" class="new" onclick="open_ExpensesPaymentEntrySearch('New'); return false" />
            </div>
            <div id="verslic">
            </div>--%>
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                Invoice Details Update
            </div>
            <%--<div id="verslic">
            </div>--%>

             <div id="txt_container_Transact_Main_l" style="width: 220px;">
                        <div id="tag_label_transact_Src" style="width: 60px;">
                            Supplier
                            </div>

                             <div id="tag_label_transact_Src_1" style="margin-top: 1px;">
                            <asp:DropDownList ID="ddl_Sup_type" CssClass="validate[required]  listtxt_transac_item_gen_notn"
                                Width="120px" runat="server" AutoPostBack="True" TabIndex="5">
                              <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                <asp:ListItem Text="SUZUKI MOTOR CORPORATION" Value="SUZUKI MOTOR CORPORATION"></asp:ListItem>
                                <asp:ListItem Text="VESTAS WIND TECHNOLOGY INDIA P.LTD" Value="VESTAS WIND TECHNOLOGY INDIA P.LTD"></asp:ListItem>
                                <%--<asp:ListItem Text="Inv & Item" Value="Inv & Item Read "></asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                        <%--<div id="txtcon-m_transaction_Supp_code" style="width: 165px; margin-left:48px;margin-top:-15px;">
                            <asp:TextBox ID="txt_SupplierName_Gen" Width="160px" Font-Size="12px" runat="server"
                                CssClass="validate txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static"
                                TabIndex="1"></asp:TextBox>
                       </div>--%>
                      
                        <%--<div id="magnify_area" style="margin-left:215px;margin-top:-15px;">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('GSupplier'); return false"
                                class="magnfy"></a>
                        </div>--%>
                    </div>
                     <div id="txt_container_Transact_Main_l" style="width: 200px;">
                      <div id="tag_label_transact_Src" style="width: 80px;">
                         PDF Options
                        </div>
                        <div id="tag_label_transact_Src_1" style="margin-top: 1px;">
                            <asp:DropDownList ID="ddl_pdf_reader_type" CssClass="validate[required]  listtxt_transac_item_gen_notn"
                                Width="80px" runat="server" AutoPostBack="True" TabIndex="5">
                              <asp:ListItem Text="--Select--" Value="--Select--"></asp:ListItem>
                                <asp:ListItem Text="Inv Only" Value="Inv Read"></asp:ListItem>
                                <asp:ListItem Text="Item Only" Value="Item Read"></asp:ListItem>
                                <asp:ListItem Text="Inv & Item" Value="Inv & Item Read"></asp:ListItem>
                            </asp:DropDownList>
                       </div>
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width: 200px;">
                        <div id="tag_label_transact_Src" style="width: 70px;">
                        Inv.Sl No :
                    </div>
                    <div id="tag_label_transact_Src_1">
                       <asp:DropDownList ID="ddlInv_SL_No" runat="server" CssClass="listtxt_transac_src1" style="width: 50px;">
                       </asp:DropDownList>
                      </div>
                     </div>

        </div> 
        <div id="tag_transact_src_inner" style="width: 900px; height: 75px">
            <div id="tag_Exchange_inner_lft">
                <div id="tag_Exchange_inner_lft">
                    <div id="innerbox_transac_bot_inn" style="width: 950px;">
                       

                        <div id="tag_label_transact_Src" style="width: 100px;">
                                   PDF File Select:
                                    </div>

                        <div id="txtcon-m_src" style="width: 120px;">
                            <asp:FileUpload ID="FilePDF" runat="server" />
                        </div>
                        

                        <div id="txtcon-m_src">
                        

                         <asp:Button ID="btnSearch"  style=" margin-top: -3px; margin-left: 50px"  Text="Show Content" CssClass="autowidupdatebut"
                                 runat="server" UseSubmitBehavior="false" OnClick="btnSearch_Click" />

                        </div>

                          <%--<div id="txtcon-m_src"  >

                         <asp:Button ID="btnSearch_Old"  style=" margin-top: -3px; width:120px;  margin-left: -50px" Text="Show-Content-Old" CssClass="autowidupdatebut"
                                 runat="server" UseSubmitBehavior="false" OnClick="btnSearch_Old_Click" />

                        </div>--%>

                           <div id="txtcon-m_src"  >

                            <asp:Button ID="btnCancel"  style=" margin-top: -3px;  margin-left: 50px" Text="Cancel" CssClass="autowidupdatebut"
                                 runat="server" UseSubmitBehavior="false" OnClick="btnCancel_Click" />

                         
                        </div>

                        
                         <div id="editbu"  >
                        <asp:Button ID="btnUpdate" style=" margin-top: -5px;  margin-left: 50px" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate_Exp();" />
                              </div>

                               <%--<div id="tag_label_transact_Src" style="width: 80px; margin-left: -197px; ">
                                        Notification #:
                                    </div>--%>

                              <%--<div  id="txtcon-m_src">
                              <asp:TextBox ID="txtNotificNo" runat="server" style="margin-top: -17px;  margin-left: 725px; "  Width="80px"  ></asp:TextBox>
                              </div>--%>

                              <%--<div id="tag_label_transact_Src" style="margin-top: -17px;width: 80px; margin-left: 600px; ">
                                                Eff.Dt:
                                            </div>--%>
                                            <%--<div id="txtcon-m_Exchange" style="width: 85px  ; margin-top: -30px; margin-left: 870px; ">
                                                <asp:TextBox ID="txtDate" runat="server" Width="82px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                    TabIndex="3"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                    Enabled="True">
                                                </asp:MaskedEditExtender>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                    Format="dd/MM/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                            </div>--%>

                        <%--<div  id="txtcon-m_src">
                            <asp:TextBox ID="txtCommNarration" runat="server" Visible="false" style="margin-top: -17px; "  Width="200px" Height="30px" TextMode="MultiLine"></asp:TextBox>
                        </div>--%> 
                </div>
            </div>
            
        </div>
    </div>

    </div>
                                 <div id="innerbox_MidMain_Grid" style="height: 450px; margin-top: -13px;">
                                 <div id="Main_Grid_Container" runat="server" style="overflow: auto; height:300px">
                                <asp:GridView ID="gv_InvPDF" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" OnRowCreated="gv_InvPDF_RowCreated" OnRowDataBound="gv_InvPDF_RowDataBound"
                                    ShowHeaderWhenEmpty="True" Width="70%">
                                    <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle Font-Bold="true" />
                                    <Columns>
                                        <asp:BoundField DataField="Sno" HeaderText="SNo" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="30px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="50px" Font-Size="12px" />
                                        </asp:BoundField>                                      

                                        <asp:TemplateField HeaderText="InvNo" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtInvNo" CssClass="underlined" Width="150px" Text='<%# Bind("InvNo") %>'
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="InvDate" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtInvDate" CssClass="underlined" Width="150px" Text='<%# Bind("InvDate") %>'
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Terms" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtTerms" CssClass="underlined" Text='<%# Bind("Terms") %>' Width="70px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Currency" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCurrency" CssClass="underlined" Text='<%# Bind("InvCurr") %>' Width="70px"
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Inv Value" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtInvValue" CssClass="underlined" Text='<%# Bind("InvValue") %>' Width="100px"
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
       
                                  <asp:GridView ID="gv_ItemPDF" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" OnRowCreated="gv_ItemPDF_RowCreated" OnRowDataBound="gv_ItemPDF_RowDataBound"
                                    ShowHeaderWhenEmpty="True" Width="930px" style="overflow: auto;" Height="155px">
                                         
                                    <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle Font-Bold="true" />
                                    <Columns>
                                        <asp:BoundField DataField="Sno" HeaderText="S No" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="30px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="30px" Font-Size="12px" />
                                        </asp:BoundField>
                                      <%--  <asp:BoundField DataField="PartNo" HeaderText="Part No" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="50px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Qty" HeaderText="Item Qty" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnitPrice" HeaderText="Item Unit Price" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="50px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Amt" HeaderText="Item Amt" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px" Font-Size="11px" />
                                        </asp:BoundField>--%>

                                         <%--<asp:TemplateField HeaderText="Sno" HeaderStyle-Width="55px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPartNo" CssClass="underlined" Width="100px" Text='<%# Bind("PartNo") %>'
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="Part No" HeaderStyle-Width="55px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPartNo" CssClass="underlined" Width="200px" Text='<%# Bind("PartNo") %>'
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <%--<ItemStyle HorizontalAlign="Left" Width="250px" />--%>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="55px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtDescription" CssClass="underlined" Width="350px" Text='<%# Bind("Description") %>'
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <%--<ItemStyle HorizontalAlign="Left" Width="250px" />--%>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQty" CssClass="underlined" Text='<%# Bind("Qty") %>' Width="50px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="QtyCode" HeaderStyle-Width="35px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQtyCode" CssClass="underlined" Text='<%# Bind("QtyCode") %>' Width="35px"
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Unit Price" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtUnitPrice" CssClass="underlined" Text='<%# Bind("UnitPrice") %>' Width="50px"
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="UnitCode" HeaderStyle-Width="35px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtUnitCode" CssClass="underlined" Text='<%# Bind("UnitCode") %>' Width="35px"
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Amt" HeaderStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtAmt" CssClass="underlined" Text='<%# Bind("Amt") %>' runat="server" Width="70px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                  <asp:GridView ID="gv_Vestas_ItemPDF" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" OnRowCreated="gv_Vestas_ItemPDF_RowCreated" OnRowDataBound="gv_Vestas_ItemPDF_RowDataBound"
                                    ShowHeaderWhenEmpty="True" Width="930px" style="overflow: auto;" Height="155px">
                                         
                                    <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle Font-Bold="true" />
                                    <Columns>
                                        <asp:BoundField DataField="Sno" HeaderText="SNo" HeaderStyle-HorizontalAlign="Center"
                                            HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Center" Width="10px" Font-Size="12px" />
                                        </asp:BoundField>
                                      <%--  <asp:BoundField DataField="PartNo" HeaderText="Part No" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Description" HeaderText="Description" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="50px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Qty" HeaderText="Item Qty" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="UnitPrice" HeaderText="Item Unit Price" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="50px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Amt" HeaderText="Item Amt" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="150px" Font-Size="11px" />
                                        </asp:BoundField>--%>

                                         <%--<asp:TemplateField HeaderText="Sno" HeaderStyle-Width="55px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPartNo" CssClass="underlined" Width="100px" Text='<%# Bind("PartNo") %>'
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="MaterialCode" HeaderStyle-Width="30px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtMaterialCode" CssClass="underlined" Width="100px" Text='<%# Bind("MaterialCode") %>'
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <%--<ItemStyle HorizontalAlign="Left" Width="250px" />--%>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtDescription" CssClass="underlined" Width="300px" Text='<%# Bind("Description") %>'
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <%--<ItemStyle HorizontalAlign="Left" Width="250px" />--%>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ItemQty" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtQty" CssClass="underlined" Text='<%# Bind("ItemQty") %>' Width="50px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Info Qty" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtInfo_Qty" CssClass="underlined" Text='<%# Bind("InfoQty") %>' Width="50px"
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Info Uqc" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtUnit_Code" CssClass="underlined" Text='<%# Bind("InfoUqc") %>' Width="50px"
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UnitPrice" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtUnitPrice" CssClass="underlined" Text='<%# Bind("UnitPrice") %>' Width="50px"
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="UnitCode" HeaderStyle-Width="35px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtUnitCode" CssClass="underlined" Text='<%# Bind("UnitCode") %>' Width="35px"
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtAmount" CssClass="underlined" Text='<%# Bind("Amount") %>' runat="server" Width="60px"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CountryofOrigin" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtCountry" CssClass="underlined" Text='<%# Bind("CountryofOrigin") %>' Width="90px"
                                                    runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Left" Width="45px" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
        </div>
    </div>
          

            <%-----------------------------------END----------------------------------------------------------------%>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>
            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_alert" runat="server" />
           
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
                            OnClientClick="return HideModalPopup_U()" />
                        <%--OnClick="btnyes_Click"--%>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    </form>
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
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();

        });

        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            document.getElementById("General").click();
        }
        
    </script>
    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <script type="text/javascript">
        function RefreshParent() {
            window.parent.location.reload();
        }
        
    </script>
    <script type="text/javascript">

        $(function () {
            $("#txt_SupplierName_Gen").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Supplier_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                if (field == 'txt_SupplierName_Gen') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Supplier Name', 'error', 'topRight', true);
                                }

                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });
    </script>
    <%--<script type="text/javascript">
        function Go_IMP_EXCEL() {
            PageMethods.IMP_Excel_Upload(document.getElementById("<%=txt_SupplierName_Gen.ClientID%>").value, OnSuccess);
        }
        function OnSuccess(response, userContext, methodName) {
            jAlert(response, 'Invoice', function (r) { });
        }
    </script>--%>
</body>
</html>
