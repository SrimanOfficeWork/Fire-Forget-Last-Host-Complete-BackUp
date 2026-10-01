<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WareHouse.aspx.cs" Inherits="WareHouse" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
         #tag_transac_lft_in2
        {
         height: 25px;
         margin: auto;
         width: 370px;
         margin-left:10px;
        }
    </style>

     <style type="text/css">
         
        .myGridStyle
        {
            border-collapse:collapse;
             
        }
         
        .myGridStyle tr th
        {
            /*color: black;*/
            border: 0.5px solid black;
            font-size:13px;
        }
       .myGridStyle tr:nth-child(even)
        {
            background-color: white;
            font-size:12px;
        } 
         
         .myGridStyle tr:nth-child(odd)
        {
            background-color: white;
            font-size:12px;
        } 
         
        .myGridStyle td
        {
            border:0.5px solid black;
        }
         
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>


    <script src="../js/Import_Jscript/Job_Duplicate/Imp_Job_duplicate.js" type="text/javascript"></script>
    
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>


           <div id="innerbox_MidMain_Trans_new" style="margin-left:0px;height:580px; margin-top:0%;width:1093px;">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="tab_page1();" id="Admin_Master"><span>WareHoue To Ex-Bond </span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                        runat="server" id="Exbond_Id" style="height: 27px"><span>Ex-Bond</span></a></li>
                    <%--<li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                         runat="server" id="Exbond_Id"><span>Ex-Bond</span></a></li>--%>

                   <div id="popupwindow_closebut_right_new">
                   <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /> 
                    </div>
                </ol>
                  
          <div class="content active" id="page-1" style="padding-top:0px;">
                   
                <div id="pop_text_area_transac_popup_inn_container_new" style="width:1070px; height:220px;">

                                <div id="pop_text_area_transac_popup_inn_container_left_new" style="width:530px;  height:220px;">
                                <div id="tag_transac_lft_in2" style="height:10px;" >
                                          <div id="tag_label_transaction_popup_gen">
                                          </div>
                                          <div id="txtcon-m_transaction_pop_gen1_srcic">
                                          </div>
                                </div>
                                  <fieldset id="fld" >
                                  <legend style="border:Black;border-collapse: collapse; width:70px; text-align:center;" > From Job </legend>
                                   <div id="tag_transac_lft_in2">
                                          <div id="tag_label_transaction_popup_gen">
                                          </div>
                                          <div id="txtcon-m_transaction_pop_gen1_srcic">
                                              <span style="font-weight:bold;"><asp:Literal ID="lblfromMsg"  runat="server"></asp:Literal></span>
                                          </div>
                                </div>
                                      <div id="tag_transac_lft_in2">
                                          <div id="tag_label_transaction_popup_gen">
                                              Working Period</div>
                                          <div id="txtcon-m_transaction_pop_gen1_srcic">
                                              <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none" AutoPostBack="True"
                                                  TabIndex="1" OnSelectedIndexChanged="ddlWorkingPeriod_SelectedIndexChanged">
                                                  <%--<asp:ListItem Text="01-Apr-2017 - 31-Mar-2018" Value="01-Apr-2017 - 31-Mar-2018"></asp:ListItem>--%>
                                                  <%-- <asp:ListItem Text="01-Apr-2018 - 31-Mar-2019" Value="01-Apr-2018 - 31-Mar-2019"></asp:ListItem>--%>
                                                  <%--<asp:ListItem Text="01-Apr-2019 - 31-Mar-2020" Value="01-Apr-2019 - 31-Mar-2020"></asp:ListItem>--%>
                                                  <%--<asp:ListItem Text="01-Apr-2020 - 31-Mar-2021" Value="01-Apr-2020 - 31-Mar-2021"></asp:ListItem>--%>
                                                  <%--<asp:ListItem Text="01-Apr-2021 - 31-Mar-2022" Value="01-Apr-2021 - 31-Mar-2022"></asp:ListItem>--%>
                                                  <%--<asp:ListItem Text="01-Apr-2022 - 31-Mar-2023" Value="01-Apr-2022 - 31-Mar-2023"></asp:ListItem>--%>
                                                  <%--<asp:ListItem Text="01-Apr-2023 - 31-Mar-2024" Value="01-Apr-2023 - 31-Mar-2024"></asp:ListItem>--%>
                                                 <%-- <asp:ListItem Text="01-Apr-2026 - 31-Mar-2027" Value="01-Apr-2026 - 31-Mar-2027"></asp:ListItem>
                                                  <asp:ListItem Text="01-Apr-2025 - 31-Mar-2026" Value="01-Apr-2025 - 31-Mar-2026"></asp:ListItem>
                                                  <asp:ListItem Text="01-Apr-2024 - 31-Mar-2025" Value="01-Apr-2024 - 31-Mar-2025"></asp:ListItem>--%>
                                                  
                                              </asp:DropDownList>
                                          </div>
                                      </div>
                                   
                                     <div id="tag_transac_lft_in2" style="width:510px;">
                                        <div id="tag_label_transaction_popup_gen">
                                            From Job No
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width:190px;">
                                           <asp:DropDownList ID="ddlJobNo" runat="server" 
                                            CssClass=" validate[required] txtbox_none" AutoPostBack="true" Width="180px"
                                            onselectedindexchanged="ddlJobNo_SelectedIndexChanged" TabIndex="3">
                                           </asp:DropDownList>
                                        </div>
                                         <div id="tag_label_transaction_popup_gen" style="width:50px;">
                                             BE NO
                                        </div>
                                          <asp:DropDownList ID="ddl_BE_NO" runat="server" CssClass="txtbox_none" 
                                             Width="150px" TabIndex="3"  AutoPostBack="true"
                                             onselectedindexchanged="ddl_BE_NO_SelectedIndexChanged">
                                          </asp:DropDownList>
                                    </div>
                                
                                     <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Importer Name
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic"  style="width:250px;">
                                            <asp:TextBox ID="txtImporterName" runat="server"  Width="220px" MaxLength="250" onblur="ChangeCase(this);"
                                                 CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Font-Size="12px" Enabled="false"
                                                Onkeypress="return numcharspl1(event)" TabIndex="10"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Port of Origin 
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic"  style="width:250px;">
                                            <asp:TextBox ID="txt_Oportorgin" runat="server"  Width="220px" MaxLength="250" onblur="ChangeCase(this);"
                                                 CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Font-Size="12px" Enabled="false"
                                                Onkeypress="return numcharspl1(event)" TabIndex="10"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                           Port of Shipment
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic"  style="width:250px;">
                                            <asp:TextBox ID="txt_OPortShipment" runat="server"  Width="220px" MaxLength="250" onblur="ChangeCase(this);"
                                                 CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Font-Size="12px" Enabled="false"
                                                Onkeypress="return numcharspl1(event)" TabIndex="10"></asp:TextBox>
                                        </div>
                                    </div>

                                    

                                  
                                      </fieldset>
                                </div>
                   
                                <div id="pop_text_area_transac_popup_inn_container_rght_new"  style="width:530px; height:220px;">
                                     <div id="tag_transac_lft_in2" style="height:10px;">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                        <span style="font-weight:bold;"><asp:Literal ID="bltoMsg"  runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                  <fieldset id="fld" >
                                  <legend style="border:Black;border-collapse: collapse; width:50px; text-align:center;" > To Job </legend>
                                   
                                    
                                      <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                       <span style="font-weight:bold;"><asp:Literal ID="lbltoMsg"  runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Working Period
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                           <asp:Literal ID="lblWk"  runat="server"></asp:Literal>
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Job No</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width:250px;">
                                        
                                         <asp:TextBox ID="txt_Prefix" placeholder = "Prefix" Font-Size="12px"  ReadOnly="true" runat="server" MaxLength="17" onkeyup="autotab(this);"   Width="65px"
                                           CssClass="txtbox_none_CheckList" TabIndex="9" Enabled="false" ></asp:TextBox> /

                                       <asp:TextBox ID="txtCurrent_Job" runat="server" Font-Size="12px" MaxLength="17" onkeyup="autotab(this);" Width="62px" Enabled="false"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="9" ></asp:TextBox>/
                                   

                                    <asp:TextBox ID="txt_Suffix" runat="server" ReadOnly="true" Font-Size="12px" MaxLength="17" onkeyup="autotab(this);"  Width="65px"
                                    CssClass="txtbox_none_CheckList" placeholder = "Suffix" Enabled="false" TabIndex="9" ></asp:TextBox>
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Port of Origin</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                        <asp:TextBox ID="txtPortOrigin" runat="server" MaxLength="50" onkeypress="return char(event),TextBoxes(this);"
                                                onblur="ChangeCase(this);updateTextbox2();" onkeyup="ChangeCase(this);" onfocus="updateTextbox2();"
                                                onkeydown="Port_origin(document.getElementById('txtPortOrigin').value);" Enabled="false"
                                                onchange="updateTextbox2();" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"
                                                ClientIDMode="Static" TabIndex="5"></asp:TextBox>
                                        </div>
                                         <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_Master(''); return false">
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            Port of Shipment</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                         <asp:TextBox ID="txtPortShipment" runat="server" MaxLength="50" onkeypress="return char(event)" Enabled="false"
                                                onblur="ChangeCase(this);" onkeyup="ChangeCase(this);" onkeydown="ChangeCase(this);var data = val;Port_origin(this);"
                                                CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                                TabIndex="6"></asp:TextBox>
                                        </div>
                                         <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_Master('Port_Ship'); return false">
                                            </a>
                                        </div>
                                    </div>


                                     <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                      
                                        </div>
                                    </div>

                                    </fieldset>
                                </div>
                                
                </div>

               
                <div id="tag_transac_lft_Item_maindet_Grid_area"    style="overflow:auto; height:305px; width:1094px;margin-top:-10px;margin-left:-18px; ">
                    <asp:GridView ID="gvAll" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        BackColor="WhiteSmoke" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" OnRowCreated="gvAll_RowCreated"
                        CellPadding="1" CellSpacing="1" CssClass="myGridStyle" DataKeyNames="INVOICE_SLNO,ITEM_SLNO" EmptyDataText="NO RECORD FOUND"
                        PageSize="5000" ShowHeaderWhenEmpty="True" Width="100%"
                        OnRowDataBound="gvAll_RowDataBound"  OnDataBound="gvAll_DataBound">

                              <RowStyle BorderWidth="0.1em" BorderColor="black" />
                              <HeaderStyle CssClass="header" BackColor="#808080" Font-Bold="True" ForeColor="White" />  
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" 
                                         />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" 
                                         />
                                </ItemTemplate>
                                <ItemStyle Width="44px" />
                            </asp:TemplateField>

                                <asp:TemplateField HeaderText="Inv. Sl.No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="105px" >
                                        <ItemTemplate>
                                            <asp:Literal ID="txt_Inv_Slno"  Text='<%# Bind("INVOICE_SLNO") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="85px" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Inv.No" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txt_Inv_no"  Text='<%# Bind("INVOICE_NO") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="85px" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Item. Sl.No" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txt_Item_Slno"  Text='<%# Bind("ITEM_SLNO") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="85px" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                            <asp:BoundField DataField="WH_Qty" HeaderText="WH Qty" HtmlEncode="false" HeaderStyle-Font-Bold="true" HeaderStyle-Width="160px">
                                <ItemStyle CssClass="column_style_left5"  HorizontalAlign="Right" Width="160px" />
                            </asp:BoundField>

                        

                             <asp:TemplateField HeaderText="Remaining Qty" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txt_Rem_Qty"  Text='<%# Bind("REMAINING_QTY") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px" HorizontalAlign="Right" />
                                    </asp:TemplateField>

                            <asp:TemplateField HeaderText="Ex-Bond Qty" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ex_Bond_Qty"  Height="20px" Width="70px"  style="background-color:#ffe6e6; color:black;"
                                            onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtItemQty');return Clear_Dot(this);copy_ItemQTy_Textbox();"
                                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);copy_ItemQTy_Textbox();"
                                            onkeypress="return blockNonNumbers(this, event, true, false);copy_ItemQTy_Textbox();"
                                            CssClass="txtbox_none_Mid_transac_item_maindet"
                                            onchange="copy_ItemQTy_Textbox()" onfocus="copy_ItemQTy_Textbox();" 
                                            runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="85px" HorizontalAlign="Left" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="Item_Qty_Code" HeaderText="Qty Code" HeaderStyle-Font-Bold="true" HtmlEncode="false" HeaderStyle-Width="170px">
                                <ItemStyle CssClass="column_style_left5" Width="170px"  HorizontalAlign="Left"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="Item_description" HeaderText="Description" HtmlEncode="false"  HeaderStyle-Font-Bold="true"  HeaderStyle-Width="1640px">
                                <ItemStyle CssClass="column_style_left5" Width="1640px" HorizontalAlign="Left"  Font-Size="12px"/>
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                 
                 
       <div style="position:absolute; bottom:10px; left:0; right:0; padding:0 15px;">
    <asp:Button ID="btn_Exbond" runat="server" Text="Ex-Bond" 
        onclick="btn_Exbond_Click"/>

    <asp:Button ID="btn_Ex_Report" runat="server" Text="Warehouse To Ex-Bond Report" 
       OnClientClick="open_jobno(); return false"
        style="background-color:#1a6fc4; color:white; border:none; padding:5px 20px; 
               border-radius:4px; cursor:pointer; font-size:13px; 
               position:absolute; left:50%; transform:translateX(-50%);" />
</div>
               </div>
          </div>
        
        <div class="content" id="page-2" style="display: none;">
<iframe name="trans_igm" scrolling="no" id="EXbond_Iframe" style="width: 1093px; height: 580px;"></iframe>
         </div>
               
               
                
                   
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
               
       
  
    <asp:HiddenField runat="server" ID="hd_error" />
    <asp:HiddenField runat="server" ID="HD_DB_Name" />
    <asp:HiddenField runat="server" ID="HD_Tr_mode" />
    <asp:HiddenField ID="hdn_button_click" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />  
      <asp:HiddenField ID="HiddenField1" runat="server" />  
   

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="650"  BackColor="#F2F5F2" AsyncRendering="False" SizeToReportContent="true"
ExportContentDisposition="AlwaysAttachment"  ProcessingMode="Local" ShowToolBar="true" ShowPageNavigationControls="true" 
ShowZoomControl="false"  ShowFindControls="False" ShowBackButton="false" 

ShowExportControls="true"  ShowParameterPrompts="false" 
ToolBarItemBorderStyle="Solid" ShowRefreshButton="true" 
ToolBarItemBorderColor="Black" EnableTheming="false" ShowReportBody="true" ShowDocumentMapButton="true" ShowPrintButton="false" KeepSessionAlive="true">
<%--<LocalReport ReportPath="Exbond_Report/Report.rdlc">

            </LocalReport>--%>
           </rsweb:ReportViewer>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>


    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>

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
<script type = "text/javascript">
    function tab_page1() {

        document.getElementById('page-1').style.display = 'Block';
        document.getElementById('page-2').style.display = 'none';



    }
function tab_page2() {

            document.getElementById('page-1').style.display = 'none';
            document.getElementById('page-2').style.display = 'Block';
            document.getElementById("EXbond_Iframe").src = "../Transaction/Ex-Bond_Details.aspx";
        }




 </script>
</body>
 <script src="../../js/Jquery_Print_Report.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">

    function printdiv() {
        var headstr = "<html><head><title></title></head><body>";
        var footstr = "</body>";
        var newstr = $("#ReportViewer1_ctl10").html()
        var popupWin = window.open('', '_blank');
        popupWin.document.write(headstr + newstr + footstr);
        popupWin.print();
        return false;
    }

</script>
<script type="text/javascript">

    function open_jobno() {
        var jobno = document.getElementById("<%=ddlJobNo.ClientID%>").value;
        var workingPeriod = document.getElementById("<%=ddlWorkingPeriod.ClientID%>").value;

        if (jobno != "Select" && jobno != "") {
            document.getElementById("<%=HiddenField1.ClientID%>").value = jobno;

            NewWindow1(
            '../WareHouse/Warehouse_ReportViewer.aspx?jobno='
            + encodeURIComponent(jobno)
            + '&workingperiod='
            + encodeURIComponent(workingPeriod),
            'List',
            '810',
            '1024',
            'yes'
        );

            return false;
        }
    }

</script>
</html>
