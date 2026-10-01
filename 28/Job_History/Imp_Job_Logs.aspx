<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Job_Logs.aspx.cs" Inherits="Imp_Job_Logs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Job History All</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
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

    </script>

      <script type="text/javascript">
          function tab1() {
              document.getElementById("page-1").style.display = 'Block';
              document.getElementById("page-2").style.display = 'none';

              document.getElementById("Joblogs").className = 'active';
              document.getElementById("Jobmodified").className = 'inactive';
          }

          function tab2() {
              document.getElementById("page-1").style.display = 'none';
              document.getElementById("page-2").style.display = 'Block';

              document.getElementById("Joblogs").className = 'inactive';
              document.getElementById("Jobmodified").className = 'active';
          }
    </script>

    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>

    <style>
.gvTable {
    border-collapse: collapse;
    width: 100%;
}

.gvHeader th {
    position: sticky;
    top: 0;
    background-color: #f1f1f1;
    z-index: 2;
}
</style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                <ProgressTemplate>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <ol id="toc">
                <li><a href="#page-1" onclick="tab1(); jQuery('#form1').validationEngine('hideAll')" runat="server"
                    id="Joblogs"><span>Job Log Details</span> </a></li>
                <li><a href="#page-2" onclick="tab2(); jQuery('#form1').validationEngine('hideAll')" runat="server"
                    id="Jobmodified" visible="false"><span>Modified Coloumn Details</span></a> </li>
            </ol>
            <div class="content" id="page-1">
                <div id="tag_srcinner1grid">
                    <div id="tag_label_comp_master1">
                        Select Page Name
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 330px; height: 35px;">
                        <asp:DropDownList ID="ddl_PageName" runat="server" AutoPostBack="true" CssClass="listtxt_comp_mas"  Height="30px" Font-Bold="true"
                            TabIndex="12" OnSelectedIndexChanged="ddl_PageName_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_transac_exp_drawback" style="width: 50px;">
                        <a href="#" id="btnex" runat="server" style="display: block; width: 50px; height: 30px; 
                            background-image: url('../images/xls.jpg'); background-repeat: no-repeat;" onserverclick="btnexcel_Click"
                            tabindex="7"></a>
                    </div>
                   
                    <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 150px; margin-top: 5px;">
                        <asp:Label ID="lbl_cols_count" runat="server" ForeColor="Blue"></asp:Label>
                    </div>
                </div>
                <div id="tag_transac_export_lft_item_gen_Grid_comp" style="width: 900px; height: 310px;">
                    <asp:GridView runat="server" ID="gvdetails" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                        BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view" OnRowCreated="gvdetails_RowCreated"
                        Width="100%" ShowHeaderWhenEmpty="True" AllowPaging="false" AllowSorting="True"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:BoundField DataField="JOBNO" HeaderText="Jobno" HeaderStyle-Font-Bold="true">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="INVOICE_SLNO" HeaderText="InvSlNo" HeaderStyle-Font-Bold="true">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ITEM_SLNO" HeaderText="ItemSlNo" HeaderStyle-Font-Bold="true">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="PAGE_NAME" HeaderText="Page Name" HeaderStyle-Font-Bold="true">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STATUS" HeaderText="Action Status" HeaderStyle-Font-Bold="true">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="USER_ID" HeaderText="User Name" HeaderStyle-Font-Bold="true">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DATE_TIME" HeaderText="Action Date & time" HeaderStyle-Font-Bold="true">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                    <asp:HiddenField ID="hdn_Company_ID" runat="server" />
                    <asp:HiddenField ID="hdn_User_Creation_Id" runat="server" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
            </div>
            <div class="content" id="page-2">
                <div id="tag_srcinner1grid">
                    <div id="tag_label_comp_master1">
                        Select Page Name
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 330px; height: 35px;">
                        <asp:DropDownList ID="ddl_PageName2" runat="server" AutoPostBack="true" CssClass="listtxt_comp_mas" Height="30px" Font-Bold="true"
                            TabIndex="12" OnSelectedIndexChanged="ddl_PageName2_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div id="tag_transac_exp_drawback" style="width: 300px;">
                        <a href="#" id="btnex2" runat="server" style="display: block; width: 50px; height: 30px;
                            background-image: url('../images/xls.jpg'); background-repeat: no-repeat;" onserverclick="btnexcel_Modified_Click"
                            tabindex="7"></a>
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 150px; margin-top: 5px;">
                        <asp:Label ID="lbl_cols_count2" runat="server" ForeColor="Blue"></asp:Label>
                    </div>
                </div>

                
                <div id="tag_transac_export_lft_item_gen_Grid_comp" style="width: 970px; height: 310px;">
                    <asp:GridView runat="server" ID="gvdetails2" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False"
                        BackColor="AliceBlue" GridLines="Both" CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True"
                        AllowPaging="false" AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                        HeaderStyle-CssClass="gvHeader"  HeaderStyle-Font-Size="14px" HeaderStyle-Height="30px"
                         onrowdatabound="gvdetails2_RowDataBound">
                       <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <PagerSettings Visible="False" />
                          <Columns>
                           <asp:BoundField DataField="PageName" HeaderText="Page Name" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="80px" HeaderStyle-BackColor="Aquamarine">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left"  Width="60px" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="InvSlno" HeaderText="InvSlNo" HeaderStyle-Font-Bold="true"   HeaderStyle-Width="20px"  HeaderStyle-BackColor="Aquamarine">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" Width="20px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ItemSlno" HeaderText="ItemSlNo" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="20px" HeaderStyle-BackColor="Aquamarine">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left"  Width="20px"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="ColumnName" HeaderText="Column Name" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="80px" HeaderStyle-BackColor="Aquamarine">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left"  Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OldValue" HeaderText="Old Value" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="90px" HeaderStyle-BackColor="Aquamarine">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" Width="90px" Font-Bold="true"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="NewValue" HeaderText="New Value" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="90px" HeaderStyle-BackColor="Aquamarine">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left"  Width="90px" Font-Bold="true"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="User" HeaderText="User Name" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="60px" HeaderStyle-BackColor="Aquamarine">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left" Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Modified_Time" HeaderText="Modified Date & time" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="170px" HeaderStyle-BackColor="Aquamarine">
                                <HeaderStyle CssClass="column_style_left" />
                                <ItemStyle CssClass="column_style_left"  Width="170px"/>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>

            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  
  
</body>
</html>
