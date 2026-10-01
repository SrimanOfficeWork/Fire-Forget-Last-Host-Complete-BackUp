<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ADC_Entry.aspx.cs" Inherits="ADC_Entry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>ADC</title>
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
         .datagrid table { border-collapse: collapse; text-align: left; width: 100%; } .datagrid {font: normal 12px/150% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden; border: 1px solid #8C8C8C; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; }.datagrid table td, .datagrid table th { padding: 3px 10px; }.datagrid table thead th {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; color:#FFFFFF; font-size: 15px; font-weight: bold; border-left: 1px solid gray; } .datagrid table thead th:first-child { border: none; }.datagrid table tbody td { /*color: #7D7D7D;*/ border-left: 1px solid #DBDBDB;font-size: 12px;font-weight: normal; }.datagrid table tbody .alt td { background: #EBEBEB; color: #7D7D7D; }.datagrid table tbody td:first-child { border-left: none; }.datagrid table tbody tr:last-child td { border-bottom: none; }.datagrid table tfoot td div { border-top: 1px solid #8C8C8C;background: #EBEBEB;} .datagrid table tfoot td { padding: 0; font-size: 12px } .datagrid table tfoot td div{ padding: 2px; }.datagrid table tfoot td ul { margin: 0; padding:0; list-style: none; text-align: right; }.datagrid table tfoot  li { display: inline; }.datagrid table tfoot li a { text-decoration: none; display: inline-block;  padding: 2px 8px; margin: 1px;color: #F5F5F5;border: 1px solid #8C8C8C;-webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; }.datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover { text-decoration: none;border-color: #7D7D7D; color: #F5F5F5; background: none; background-color:#8C8C8C;}div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }
    
     /*td:nth-of-type(1) {display: none;}*/
     </style>
     
     <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 7.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 10em;
            height: 5em;
            line-height: 0em;
            text-align: left;
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

          <div id="innerbox_MidMain_Billing" style="height:34px;">
            <div id="tag_srcinner1">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                    ADC Entry
                </div>
                <div id="verslic">
                </div>
                <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                    <div id="tag_label_transact_Src" style="width: 80px;">
                        Customer
                    </div>
                    <div id="txtcon-m_Exchange" style="width: 320px;">
                        <asp:DropDownList ID="ddl_Client_Name" runat="server" class="chosen-select-deselect"
                            Style="width: 320px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                            TabIndex="4" OnSelectedIndexChanged="ddl_Client_Name_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="verslic" style="margin-top: -5px;">
                </div>
                <div id="tag_transac_lft_in2">
                    <div id="tag_label_transaction_popup_gen" style="width: 50px;">
                        Jobno
                    </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 120px;">
                        <asp:DropDownList ID="ddljobno" runat="server" class="chosen-select-deselect" Style="width: 120px;"
                            data-placeholder="0" AutoPostBack="true" TabIndex="9" 
                            onselectedindexchanged="ddljobno_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                     <div id="tag_label_transact_Src" style="width:10px;" >
                     </div>
                    <div id="tag_label_transact_Src" style="width: 70px;">
                        <asp:Button ID="btnloadData" TabIndex="31" runat="server" Text="Load Data" OnClick="btnloadData_Click" />
                    </div>
                </div>
                <div id="popupwindow_closebut_right_new" >
                   <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                </div>
            </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 42px; width:1092px; margin-top: -16px;overflow:hidden;">
                
                    <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: hidden; width: 1090px;">
                        <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                            CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                            HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_Chg_Details_RowCreated"
                            OnRowDataBound="gv_Chg_Details_RowDataBound" Style="overflow: auto;">
                            <Columns>
                                <asp:BoundField DataField="a" HeaderText="Inv. Slno" HeaderStyle-Width="40px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="40px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="b" HeaderText="Inv. No" HeaderStyle-Width="120px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="120px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="f" HeaderText="Slno" HeaderStyle-Width="80px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="f" HeaderText="Desc.." HeaderStyle-Width="450px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="450px" />
                                </asp:BoundField>

                                  <asp:BoundField DataField="f" HeaderText="Lot No" HeaderStyle-Width="150px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="150px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="f" HeaderText="M. Date" HeaderStyle-Width="150px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="f" HeaderText="E. Date" HeaderStyle-Width="150px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="150px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="f" HeaderText="L. Date" HeaderStyle-Width="150px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="150px" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="f" HeaderText="Form 10 Licence No / Sl. No" HeaderStyle-Width="250px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="250px" />
                                </asp:BoundField>

                                 <asp:BoundField DataField="f" HeaderText="Shelf Life" HeaderStyle-Width="320px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" Width="320px" />
                                </asp:BoundField>

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px; width:1092px; margin-top: -16px; overflow:hidden;">
                        <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow-x: hidden;overflow-y: auto; height:480px; width:1090px; ">
                       
                            <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                DataKeyNames="INVOICE_SLNO" AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8"
                                BorderStyle="none" ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                CssClass="grid-view" AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True"
                                Width="100%" OnRowCreated="gv_Chg_Details_RowCreated" OnRowDataBound="gv_Chg_Details_RowDataBound"
                                ShowHeader="false">
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <Columns>
                                  
                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <span style="font-size: 10px;">
                                                <asp:Literal ID="txt_Inv_slno" Text='<%# Bind("INVOICE_SLNO")  %>' runat="server"></asp:Literal>
                                            </span>
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <span style="font-size: 10px;">
                                                <asp:Literal ID="txt_Inv_no" Text='<%# Bind("INVOICE_NO")  %>' runat="server"></asp:Literal>
                                            </span>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <span style="font-size: 10px; border-style: solid; color:Blue; font-weight:bold;">
                                                <asp:Literal ID="txt_Item_slno" Text='<%# Bind("ITEM_SLNO")  %>'  runat="server"></asp:Literal>
                                            </span>
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <span style="font-size: 10px;">
                                                <asp:Literal ID="txt_Item_desc" Text='<%# Bind("ITEM_DESCRIPTION")  %>' runat="server"></asp:Literal>
                                            </span>
                                        </ItemTemplate>
                                        <ItemStyle Width="250px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                       <ItemTemplate>
                                           
                                          <asp:TextBox ID="txt_Lot_no" TabIndex="20"  CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  Text='<%# Bind("LOT_NO") %>' runat="server"                                    
                                            Height="20px" Width="80px" ForeColor="DodgerBlue" Font-Bold="true"   ></asp:TextBox>

                                       </ItemTemplate>
                                         <ItemStyle Width="80px" />
                                   </asp:TemplateField>

                                    <%--------------------------------------%>
                                    <asp:TemplateField HeaderText="EA_1_Air" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_M_Date" runat="server" Text='<%# Bind("MANUFACTURING_DATE") %>'
                                                MaxLength="10" CssClass="txtbox_none_Mid_transac_code" TabIndex="20" Width="80px"  ForeColor="Violet" Font-Bold="true" ></asp:TextBox>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_M_Date"
                                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True">
                                            </asp:MaskedEditExtender>
                                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_M_Date"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EA_1_Air" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_E_date" runat="server"  Text='<%# Bind("EXPIRY_DATE") %>' MaxLength="10" Width="80px" ForeColor="Orange" Font-Bold="true"
                                                CssClass="txtbox_none_Mid_transac_code" TabIndex="20"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_E_date"
                                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True">
                                            </asp:MaskedEditExtender>
                                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_E_date"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EA_2" HeaderStyle-Font-Bold="true">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_L_date" Text='<%# Bind("LANDING_DATE") %>' runat="server" MaxLength="10" Width="80px" ForeColor="Red" Font-Bold="true"
                                                CssClass="txtbox_none_Mid_transac_code" TabIndex="20"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_L_date"
                                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                Enabled="True">
                                            </asp:MaskedEditExtender>
                                            <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_L_date"
                                                Format="dd/MM/yyyy" Enabled="True">
                                            </asp:CalendarExtender>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                    </asp:TemplateField>
                                      <%--------------------------------------%>
                                       <asp:TemplateField HeaderText="Form 10 Licence No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="150px">
                                       <ItemTemplate>
                                          <asp:TextBox ID="txt_Form_10_Licence_No" ForeColor="Blue" TabIndex="20"  CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  Text='<%# Bind("FROM_LIC_NO_SLNO") %>' runat="server"                                    
                                            Height="20px" Width="150px" Font-Size="12px" Font-Bold="true" ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="150px" />
                                   </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Shelf Life" HeaderStyle-Font-Bold="true" HeaderStyle-Width="150px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Shelf_Life" ForeColor="Green" TabIndex="20" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Text='<%# Bind("SHELF_LIFE") %>'
                                                runat="server" Height="20px" Width="150px" Font-Size="12px" Font-Bold="true" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" />
                                    </asp:TemplateField>
                                     <%--------------------------------------%>
                                </Columns>
                            </asp:GridView>
                           
                        </div>
                        <%-----------------------Test--------------------------------------------------------%>
                    </div>
            <%-------------------------------------------------------------------------------%>
            <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px; margin-left:20px; margin-top:-14px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="61" onclick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="59" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="60" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="61" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this ADC?', 'ADC Entry', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="51" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="63">
                        </div>
                      
                    </div>
                </div>
            <%-- --------------------Test End----------------------------%>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
           </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  
   <script  src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>

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

        </script>
    
</body>
</html>
