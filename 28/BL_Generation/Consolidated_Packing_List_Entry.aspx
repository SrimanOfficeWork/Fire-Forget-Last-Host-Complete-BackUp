<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consolidated_Packing_List_Entry.aspx.cs" 
    Inherits="Consolidated_Packing_List_Entry"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export Consolidate Packing List</title>
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
    <script src="../js/Export_Rpt/BL_Generation.js" type="text/javascript"></script>


    <script language="javascript">

        function CheckAll() {

            var intIndex = 0;

            var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;

            for (i = 0; i < rowCount; i++) {

                if (document.getElementById('cbAll').checked == true) {

                    if (document.getElementById("cbList" + "_" + i)) {

                        if (document.getElementById("cbList" + "_" + i).disabled != true)

                            document.getElementById("cbList" + "_" + i).checked = true;

                    }
                }
                else {

                    if (document.getElementById("cbList" + "_" + i)) {

                        if (document.getElementById("cbList" + "_" + i).disabled != true)

                            document.getElementById("cbList" + "_" + i).checked = false;

                    }

                }

            }
        }
        function UnCheckAll() {
            var intIndex = 0;
            var flag = 0;
            var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;
            for (i = 0; i < rowCount; i++) {
                if (document.getElementById("cbList" + "_" + i)) {
                    if (document.getElementById("cbList" + "_" + i).checked == true) {
                        flag = 1;
                    }
                    else {
                        flag = 0;
                        break;
                    }
                }
            }

            if (flag == 0)
                document.getElementById('cbAll').checked = false;
            else
                document.getElementById('cbAll').checked = true;
        }

    </script>

     
    <style type="text/css">
        .myGridStyle
        {
            border-collapse: collapse;
        }
        
        .myGridStyle tr th
        {
            color: black;
            border: 0.5px solid black;
            font-size: 13px;
        }
        .myGridStyle tr:nth-child(even)
        {
            background-color: #D1D0CE;
            font-size: 13px;
        }
        
        .myGridStyle tr:nth-child(odd)
        {
            background-color: #D1D0CE;
            font-size: 13px;
        }
        
        .myGridStyle td
        {
            border: 0.5px solid black;
        }
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
            <div id="innerbox_MidMain_Transact_popup_new" style="height:540px; background-image: none; background-color:White;" ">
                <div id="tag_srcinner1_new" >
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:110px;">
                       
                         Exporter Name
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:310px;">
                         <asp:DropDownList ID="ddlExp_name" runat="server" AutoPostBack="true"
                             CssClass="listtxt_transac_src1" Width="300px" 
                             onselectedindexchanged="ddlExp_name_SelectedIndexChanged" TabIndex="5">
                         </asp:DropDownList>
                    </div>

                     <div id="mainmastop2container_rght_tag2_txt1" style="width:80px;">
                         Ref.Name
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:190px;">

                     <asp:TextBox ID="txtId" runat="server" TabIndex="6" MaxLength="35" Width="40px" BackColor="#F0F0F0"
                             CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>

                        <asp:TextBox ID="txtrefname" runat="server" MaxLength="35" ClientIDMode="Static" Width="137px"
                            TabIndex="7" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                    </div>

                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px; margin-top: -1px;">
                    </div>

                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>
       
                <div id="area_transac_container_genral"  style="width:990px;" >
                <%-- ----------------A-----------------------%>
                    <div id="pop_text_area_transac_popup_inn_container_left_new" style="width: 320px;">
                        <div id="Div_listbox" runat="server" >
                            <div id="tag_transact_src_inner" style="width: 300px;">
                                <div id="innerbox_MidMain_Trans_new" style="height: 25px; width: 300px; margin-left: -10px;
                                    border-bottom-style: solid;">
                                    <div id="tag_label_transaction_exp_jobb">
                                        <asp:CheckBox ID="cbAll" runat="server" ForeColor="White" white="300px" Font-Bold="true" TabIndex="10"
                                            Font-Size="14px" Text="Select All" onclick="CheckAll();" />
                                    </div>
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="overflow: auto; overflow-x: hidden; background-color: White; 
                                    width: 300px; height: 470px;" >
                                    <asp:CheckBoxList ID="cbList" runat="server" ValidationGroup="VGroup" onclick="UnCheckAll();" BorderStyle="None"
                                     TabIndex="11"   CssClass=" txtbox_none_Mid_transac_pop_gen" Width="300px" Height="470px" RepeatColumns="2"
                                        RepeatDirection="Vertical">
                                    </asp:CheckBoxList>
                                </div>
                            </div>
                        </div>
                    </div>

                <div id="pop_text_area_transac_popup_inn_container_rght_new" style="width: 660px; height:500px;" >
                    
                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width:700px;">
                        <asp:Button ID="btn_load_data" runat="server" Text="Load SB Data"  TabIndex="12" CausesValidation="false" UseSubmitBehavior="false"
                            CssClass="autowidupdatebut" onclick="btn_load_data_Click" />
                    </div>
                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width:700px;">

                            <div id="tag_label_transaction_export_Item_otherdet_new1" style="width:387px;">
                            
                            </div>
                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                            Packing Date
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                 <asp:TextBox ID="txtDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                        TabIndex="15"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                            </div>
                        </div>
                    <%-- ----------------R1-----------------------%>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_Item">
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="width: 610px;">
                            <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 100px;">
                                In. No / Date
                            </div>
                            <div id="tag_label_transaction_export_Item_otherdet_new2">
                                <asp:TextBox ID="txt_Inv_no_date" runat="server" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new3"
                                    Font-Size="12px" TabIndex="16" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                     <%-- ----------------R2-----------------------%>
                     <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_Item">
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="width: 610px;">
                            <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 100px;">
                               Desc 1
                            </div>
                            <div id="tag_label_transaction_export_Item_otherdet_new2">
                                <asp:TextBox ID="txt_desc_1" runat="server" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new3"
                                    Font-Size="12px" TabIndex="17" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                      <%-- ----------------R3-----------------------%>
                       <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_Item">
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="width: 610px;">
                            <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 100px;">
                               Desc 2
                            </div>
                            <div id="tag_label_transaction_export_Item_otherdet_new2">
                                <asp:TextBox ID="txt_desc_2" runat="server" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new3"
                                    Font-Size="12px" TabIndex="20" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                       <%-- ----------------R4-----------------------%>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_Item">
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="width: 610px;">
                            <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 100px;">
                               Desc 3
                            </div>
                            <div id="tag_label_transaction_export_Item_otherdet_new2">
                                <asp:TextBox ID="txt_desc_3" runat="server" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new3" Font-Size="12px"
                                 TabIndex="21" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    
                      <%-- ----------------R5-----------------------%>
                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 700px">
                        <div id="tag_label_transaction_export_Item_otherdet_new1" style="width: 100px;">
                            Total Net Wgt
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Net_wgt" MaxLength="23" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="23"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                         <div id="tag_label_transaction_export_Item_otherdet_new1" style="width: 100px;">
                            Total Gross Wgt
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                             <asp:TextBox ID="txt_Gross_wgt" MaxLength="17" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="24"></asp:TextBox>
                        </div>
                    </div>
                  
                  <%-- ----------------R6----------------------%>

                    <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow-x: hidden; overflow-y: auto;
                        height: 180px; width: 652px; margin-top: 5px;">
                        <asp:GridView ID="gv_Chg_Details" runat="server" EmptyDataText="No Record Found"
                            Width="100%" AutoGenerateColumns="False" GridLines="None" CssClass="myGridStyle">
                            <RowStyle BorderWidth="0.1em" BorderColor="black" />
                            <HeaderStyle CssClass="grid-header" />
                            <Columns>
                                <asp:BoundField DataField="Slno" HeaderText="S.No" HeaderStyle-Font-Bold="true" ItemStyle-Width="15px"
                                    HeaderStyle-Width="15px" ItemStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderText="Container No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="205px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_Container_No" Text='<%# Bind("Con_No") %>' runat="server" Height="15px"
                                            Width="205px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="205px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bags" HeaderStyle-Font-Bold="true" HeaderStyle-Width="125px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_bags" Text='<%# Bind("Bags") %>' Font-Size="12px" runat="server"
                                            Height="15px" Width="125px"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="125px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Net Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="125px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_Net_Wgt" Text='<%# Bind("Net_Wgt") %>' Font-Size="12px" Height="15px"
                                            Width="125px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="125px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gross Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="125px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_Gross_Wgt" Text='<%# Bind("Gross_Wgt") %>' Font-Size="12px"
                                            Height="15px" Width="125px" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="125px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>

                    <%-- ----------------A0-----------------------%>
                     <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_Item">
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="width: 610px;">
                            <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 100px;">
                               Desc 4
                            </div>
                            <div id="tag_label_transaction_export_Item_otherdet_new2">
                                <asp:TextBox ID="txt_desc_4" runat="server" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new3" Font-Size="12px"
                                 Height="37px" TabIndex="25" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                     <%-- ----------------A0-----------------------%>
                </div>
                 <%-- ----------------A-----------------------%>
                </div>
                   <%-- ----------------end-----------------------%>
         </div>


          <%--  ---------------------------S------------------------------------------%>
            <div id="innerbox_MidMain_bot_transact_invoice" style="width:800px;">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="120" CausesValidation="false"
                        UseSubmitBehavior="false" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                </div>
                
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate_Item();"
                        CssClass="save" TabIndex="115" /></div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" Visible="False" OnClick="btnUpdate_Click"
                        CssClass="updates" OnClientClick="return validate_Item();" TabIndex="115" /></div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="116" Visible="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'PRODUCT', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="116" OnClick="btnDelete_Click" OnClientClick="return validate_Item();"
                        CssClass="dlete" Style="display: none;" />
                </div>
                <div id="editbu">

                        <input type="submit" value="Submit" class="scancel" onclick="parent.parent.adcodewindow.hide()"
                                        tabindex="121" id="btnCancel" />
                 </div>

                <div id="editbu" style="margin-left: 30px; margin-top: 8px;">
                    <asp:Button ID="btnrpt" runat="server" TabIndex="125" Text="Get Bill" OnClientClick="return open_Consolidated_Packing_List_Rpt('B');" />
                </div>

                <div id="editbu" style="margin-left: 30px; margin-top: 8px;">
                </div>

                  
                 
             </div>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
             <asp:HiddenField ID="HD_Showcon" runat="server" />
             <asp:HiddenField ID="HDR_ID" runat="server" />

             <asp:HiddenField ID="hdBranch" runat="server" />

              <asp:HiddenField ID="hdn_CLIENT_TYPE" runat="server" />
              <asp:HiddenField ID="hd_Brslno" runat="server" />
              <asp:HiddenField ID="hdfTransport_mode1" runat="server" />


          <%--  ---------------------------E------------------------------------------%>
         
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    

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
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        
    </script>


    <script src="../js/Grid_header_script/gridviewScroll.min.js" type="text/javascript"></script>

</body>
</html>
