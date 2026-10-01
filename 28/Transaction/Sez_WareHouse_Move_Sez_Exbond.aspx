<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sez_WareHouse_Move_Sez_Exbond.aspx.cs" 
    Inherits="Export_Annexure_C_Sea_Package" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Annexure C1 | Transaction</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />

    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <%--<link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />--%>
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .hideGridColumn
        {
            display: none;
        }
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

      <script type = "text/javascript">
//<!--
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
                          break;
                      }
                  }
              }
              headerCheckBox.checked = checked;

          }
          function checkAll(objRef) {
              var GridView = objRef.parentNode.parentNode.parentNode;
              var inputList = GridView.getElementsByTagName("input");
              for (var i = 0; i < inputList.length; i++) {
                  var row = inputList[i].parentNode.parentNode;
                  if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                      if (objRef.checked) {
                          inputList[i].checked = true;
                      }
                      else {
                          if (row.rowIndex % 2 == 0) {
//                              row.style.backgroundColor = "#C2D69B";
                          }
                          else {
//                              row.style.backgroundColor = "white";
                          }
                          inputList[i].checked = false;
                      }
                  }
              }
          }
          //-->

          function win_close1() {
              window.parent.document.getElementById('interVeil').style.display = 'none';
              window.parent.adcodewindow.hide();
          }
</script>

</head>
<body id="bg2popup" style="overflow: hidden">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_annx_CSea_Exbond">


                <ol id="toc">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();" runat="server" id="Warehouse_Id" >
                        <span>SEZ Z  WareHouse - SEZ T  Ex-Bond </span></a></li>    <%--sez Z WareHouse - sez T Ex-Bond --%>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                         runat="server" id="Exbond_Id"><span>Ex-Bond</span></a></li>
                   
                    <div id="popupwindow_closebut_right_opt1">
                    <asp:Button ID="btn_warehose" runat="server" CssClass="clsicon" OnClientClick="win_close1();parent.parent.adcodewindow.hide();return false;"/>
                    <asp:Button ID="btn_exbond" runat="server" CssClass="clsicon" OnClientClick="win_close();parent.adcodewindow.hide();return false;"/>
                    </div>
                </ol>



                <div class="content" id="page-1">
                    <div id="annexure_c_main">
                        <div id="annexure_c_Container_main_Exbond">
                            <div id="tag_annexure_sea_cont_Exbond">
                                <div id="tag_label_transaction_annuxeairC" style="width: 200px;">
                                 SEZ Z WareHouse BE No:

                                    <asp:DropDownList ID="ddlbe_No" runat="server" TabIndex="1" 
                                     class="chosen-select-deselect" Style="width: 150px; font-family:Arial,Helvetica,sans-serif; "  
                                     data-placeholder="Choose BE No"  AutoPostBack="true" 
                                        onselectedindexchanged="ddlbe_No_SelectedIndexChanged" >
                                     </asp:DropDownList>


                                   <br />
                                   <br />
                                    SEZ Z WareHouse JobNo
                                    <asp:DropDownList ID="ddlWarehouse_JobNo" runat="server" Font-Size="12px" CssClass="txtbox_none"  Width="200px"
                                        OnSelectedIndexChanged="ddlWarehouse_JobNo_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                    <br />
                                    <br />
                                    Transfer To Branch
                                    <br />
                                    <asp:DropDownList ID="ddltoBranch" runat="server" Width="180px" AutoPostBack="true"
                                        CssClass="txtbox_none" 
                                        onselectedindexchanged="ddltoBranch_SelectedIndexChanged"  >
                                     </asp:DropDownList>

                                </div>
                                <div id="tag_transac_export_lft_item_gen_Grid_area_Exbond" style="width: 690px;">
                                    <asp:GridView ID="gvAll" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                        BackColor="WhiteSmoke" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="1" CellSpacing="1" CssClass="grid-view" DataKeyNames="ITEM_ID" EmptyDataText="NO RECORD FOUND"
                                        PageSize="5000" OnPageIndexChanging="OnPaging" ShowHeaderWhenEmpty="True" Width="180%"
                                        OnRowDataBound="gvAll_RowDataBound" OnRowCreated="gvAll_RowCreated" OnDataBound="gvAll_DataBound">
                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            BorderWidth="1px" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" AutoPostBack="true"
                                                        OnCheckedChanged="CheckBox_CheckChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" AutoPostBack="true"
                                                        OnCheckedChanged="CheckBox_CheckChanged" />
                                                </ItemTemplate>
                                                <ItemStyle Width="44px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ITEM_ID" HeaderText="Item ID" HtmlEncode="false">
                                                <HeaderStyle CssClass="hideGridColumn" />
                                                <ItemStyle CssClass="hideGridColumn" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="INVOICE_NO" HeaderText="Inv.No" HeaderStyle-Width="150px" HtmlEncode="false">
                                                <ItemStyle CssClass="column_style_left5" Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv. Sl.No" HeaderStyle-Width="150px"
                                                HtmlEncode="false">
                                                <ItemStyle CssClass="column_style_left5" Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item Sl.No" HtmlEncode="false"
                                                HeaderStyle-Width="200px">
                                                <ItemStyle CssClass="column_style_left5" Width="200px" />
                                            </asp:BoundField>
                                           
                                            <asp:BoundField DataField="ITEM_QTY" HeaderText="Qty" HtmlEncode="false" HeaderStyle-Width="160px">
                                                <ItemStyle CssClass="column_style_left5" Width="160px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="REMAINING_QTY" HeaderText="Remaining Qty" HtmlEncode="false"
                                                HeaderStyle-Width="200px">
                                                <ItemStyle CssClass="column_style_left5" Width="200px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="SEZ T Ex-Bond Qty" HeaderStyle-Width="200px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtItem_Qty" runat="server" AutoPostBack="false" HtmlEncode="false"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="200px" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ITEM_QTY_CODE" HeaderText="Qty Code" HtmlEncode="false"
                                                HeaderStyle-Width="170px">
                                                <ItemStyle CssClass="column_style_left5" Width="170px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Description" HtmlEncode="false"
                                                HeaderStyle-Width="1640px">
                                                <ItemStyle CssClass="column_style_left5" Width="1640px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div id="tag_annexure_sea_cont_Exbond">
                                <div id="tag_label_transaction_annuxeairC" style="width: 200px;">
                                    SEZ T Ex-Bond JobNo
                                     <br />

                                  <asp:TextBox ID="txtjob_Prefix" Font-Size="12px" runat="server" MaxLength="40" ReadOnly="true" Width="60px" placeholder = "Prefix" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>

                                  <asp:TextBox ID="txtExbond_JobNo" Font-Size="12px" runat="server"  Width="60px" ClientIDMode="Static"
                                        onkeypress="return num1(event)" ReadOnly="True" MaxLength="10"  CssClass="txtbox_none_Mid_transac_code_new_Exbond"></asp:TextBox>

                                  <asp:TextBox ID="txtjob_Suffix" Font-Size="12px" runat="server" MaxLength="40"  ReadOnly="true" Width="58px" placeholder = "Suffix" ClientIDMode="Static"
                                        CssClass="txtbox_none_CheckList"></asp:TextBox>

                                    <span id="lblport" runat="server">
                                        <br />
                                        <br />
                                        Port of Orgin
                                          <asp:TextBox ID="txtPortOrigin" runat="server" MaxLength="50" onkeypress="return char(event),TextBoxes(this);"
                                                onblur="ChangeCase(this);updateTextbox2();" onkeyup="ChangeCase(this);" onfocus="updateTextbox2();"
                                                onkeydown="var data = val;Port_origin(this);" onchange="updateTextbox2();" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"
                                                ClientIDMode="Static" TabIndex="20"></asp:TextBox>
                                        <br />
                                        <br />
                                        Port of Shipment
                                          <asp:TextBox ID="txtPortShipment" runat="server" MaxLength="50" onkeypress="return char(event)"
                                                onblur="ChangeCase(this);" onkeyup="ChangeCase(this);" onkeydown="ChangeCase(this);var data = val;Port_origin(this);"
                                                CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                                TabIndex="21"></asp:TextBox>
                                    </span>
                                </div>
                                <div id="tag_transac_export_lft_item_gen_Grid_area_Exbond" style="width: 690px;">
                                    <asp:GridView ID="gvSelected" runat="server" AllowPaging="True" AllowSorting="True"
                                        AutoGenerateColumns="False" BackColor="WhiteSmoke" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" EmptyDataText="NO RECORD FOUND"
                                        ShowHeaderWhenEmpty="True" Width="150%" PageSize="5000" OnRowCreated="gvAll_RowCreated" 
                                        OnRowDataBound="gvSelected_RowDataBound">
                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            BorderWidth="1px" />
                                        <Columns>
                                            <asp:BoundField DataField="ITEM_ID" HeaderText="Item ID">
                                                <HeaderStyle CssClass="hideGridColumn" />
                                                <ItemStyle CssClass="hideGridColumn" />
                                            </asp:BoundField>
                                             <asp:BoundField DataField="INVOICE_NO" HeaderText="Inv.No" HeaderStyle-Width="200px">
                                                <ItemStyle CssClass="column_style_left5" Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv. Sl.No" HeaderStyle-Width="150px">
                                                <ItemStyle CssClass="column_style_left5" Width="150px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item Sl.No" HeaderStyle-Width="200px">
                                                <ItemStyle CssClass="column_style_left5" Width="200px" />
                                            </asp:BoundField>
                                           
                                            <asp:BoundField DataField="REMAINING_QTY" HeaderText="Qty" HeaderStyle-Width="200px">
                                                <ItemStyle CssClass="column_style_left5" Width="200px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ITEM_QTY_CODE" HeaderText="Qty Code" HeaderStyle-Width="180px">
                                                <ItemStyle CssClass="column_style_left5" Width="180px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Description" HeaderStyle-Width="1600px">
                                                <ItemStyle CssClass="column_style_left5" Width="1600px" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                                    <asp:HiddenField ID="hdCus_House" runat="server" />
                                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                                    <asp:HiddenField ID="hdjobmode" runat="server" />
                                </div>
                            </div>
                            <div id="innerbox_MidMain_bot_transact_invoice_newExbond">
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="6"
                                        OnClientClick="return validate_Export_AnnexureC1_Sea_Package();" />
                                </div>
                                <div id="editbu">
                                    <input type="submit" value="Submit" class="scancel" onclick="win_close1();parent.parent.adcodewindow.hide()"
                                        tabindex="8" id="btnCancel_warehouse" runat="server" />
                                    <input type="submit" value="Submit" class="scancel" onclick="win_close();parent.adcodewindow.hide()"
                                        tabindex="8" id="btnCancel_exbond" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
                 <div class="content" id="page-2">
                    <iframe  name="trans_igm" scrolling="no" id="annexureCSea_EXbond_Iframe" runat="server"></iframe>
                </div>
            </div>
           
          
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
   <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2']);
    </script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>

     <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>

    <script src="../js/Import_Jscript/Warehouse_To_Exbond.js" type="text/javascript"></script>

    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        
        function tab_page1() {

            document.getElementById('page-1').style.display = 'Block';
            document.getElementById('page-2').style.display = 'none';



        }
        function tab_page2() {

            document.getElementById('page-1').style.display = 'none';
            document.getElementById('page-2').style.display = 'Block';

            document.getElementById("annexureCSea_EXbond_Iframe").src = "../Transaction/Ex-Bond_Details.aspx";



        }
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
    </script>
  
   <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    
    <script type="text/javascript">
            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': { allow_single_deselect: true },
                '.chosen-select-no-single': { disable_search_threshold: 10 },
                '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select-width': { width: "95%" }
                 
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }

        </script
</body>
</html>
