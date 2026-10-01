<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bill_Inv_Copy.aspx.cs" Inherits="Bill_Inv_Copy" %>
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
  
     <style type="text/css">
         .datagrid table { border-collapse: collapse; text-align: left; width: 100%; } .datagrid {font: normal 12px/150% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden; border: 1px solid #8C8C8C; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; }.datagrid table td, .datagrid table th { padding: 3px 10px; }.datagrid table thead th {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; color:#FFFFFF; font-size: 15px; font-weight: bold; border-left: 1px solid gray; } .datagrid table thead th:first-child { border: none; }.datagrid table tbody td { /*color: #7D7D7D;*/ border-left: 1px solid #DBDBDB;font-size: 12px;font-weight: normal; }.datagrid table tbody .alt td { background: #EBEBEB; color: #7D7D7D; }.datagrid table tbody td:first-child { border-left: none; }.datagrid table tbody tr:last-child td { border-bottom: none; }.datagrid table tfoot td div { border-top: 1px solid #8C8C8C;background: #EBEBEB;} .datagrid table tfoot td { padding: 0; font-size: 12px } .datagrid table tfoot td div{ padding: 2px; }.datagrid table tfoot td ul { margin: 0; padding:0; list-style: none; text-align: right; }.datagrid table tfoot  li { display: inline; }.datagrid table tfoot li a { text-decoration: none; display: inline-block;  padding: 2px 8px; margin: 1px;color: #F5F5F5;border: 1px solid #8C8C8C;-webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; }.datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover { text-decoration: none;border-color: #7D7D7D; color: #F5F5F5; background: none; background-color:#8C8C8C;}div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }
    
     /*td:nth-of-type(1) {display: none;}*/
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

          
            <div id="innerbox_MidMain_Trans" style="height: 440px; margin-left:-5px; margin-top:-5px;">
                <div id="tag_srcinner1"  style="width:440px;" >
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 125px; color:White;">
                      Exp. Bill Inv Copy</div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 245px;">
                                <div id="tag_label_transact_Src" style="width: 60px;">
                                  Inv. No</div>
                                <div id="txtcon-m_Exchange" style="width: 180px;">
                                    <asp:DropDownList ID="ddlinvno" CssClass="listtxt_transac_item_gen_notn" 
                                        Width="180px"  Font-Size="12px" runat="server"  TabIndex="3" AutoPostBack="true"
                                        onselectedindexchanged="ddlinvno_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="popupwindow_closebut_right_new">
                       <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>

                <div id="pop_text_area_transac_popup_inn_container_new">
            <div id="pop_text_area_transac_popup_inn_container_left_new">
            
                <div id="tag_transac_lft_in1">
                    <div id="tag_label_transaction_popup_gen">
                        Jobno</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                         <asp:TextBox ID="txtjobno" runat="server" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_in1">
                    <div id="tag_label_transaction_popup_gen">
                        File Ref.No</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                         <asp:TextBox ID="txtfile_Ref_No" runat="server"  Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                    </div>
                </div>


                <div id="tag_transac_lft_in1">
                    <div id="tag_label_transaction_popup_gen">
                        Inv. Date</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                        <asp:TextBox ID="txt_inv_date" runat="server" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_in1">
                    <div id="tag_label_transaction_popup_gen">
                        Importer Name</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                         <asp:TextBox ID="txt_Imp_Name" runat="server" Enabled="false" Font-Size="12px"  Width="230px" CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_in1">
                    <div id="tag_label_transaction_popup_gen">
                       Grand Total</div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                         <asp:TextBox ID="txt_Grand_Total" runat="server" Enabled="false" CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                    </div>
                </div>
                 <div id="tag_transac_lft_in1">
                    <div id="tag_label_transaction_popup_gen">
                     To Invoice No
                       </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                       <asp:TextBox ID="txtto_Inv_no" runat="server" MaxLength="17" BorderColor="Red"  Enabled="false" CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                    </div>
                </div>

                 <div id="tag_transac_lft_in1">
                    <div id="tag_label_transaction_popup_gen">
                      To  Invoice Date:
                       </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                          <asp:TextBox ID="txtDate" runat="server" BorderColor="Red" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="10"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>
                    </div>
                </div>
                    
                 <div id="tag_transac_lft_in1">
                    <div id="tag_label_transaction_popup_gen">
                       </div>
                    <div id="txtcon-m_transaction_pop_gen1_srcic_new">

                      <asp:Button ID="btnnew" runat="server" Text="New" onclick="btnnew_Click" />
                      &nbsp;&nbsp;&nbsp;
                      <asp:Button ID="btncopy" runat="server" Text="To Copy"  onclick="btncopy_Click" />
                    </div>
                </div>

            </div>
            </div>

                
            </div>
           
          
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
            document.getElementById("General").click();
        }
        
    </script>
   
    
</body>
</html>
