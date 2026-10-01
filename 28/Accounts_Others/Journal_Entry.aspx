<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Journal_Entry.aspx.cs"
    Inherits="Journal_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Journal </title>
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
    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>
    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 13.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 40em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
    <style type="text/css">
        .CalendarStyle
        {
            background-color: Crimson;
            color: White;
            border: solid 2px DarkRed;
        }
        .ajax__calendar_header
        {
            background-color: #FBB117;
            color: black;
        }
        .ajax__calendar_footer
        {
            background-color: #FBB117;
            color: black;
        }
    </style>
    <style type="text/css">
        .FixedHeader
        {
            position: absolute;
            font-weight: bold;
        }
        
        .hideGridColumn
        {
            display: none;
        }
        
        .hideGridColumn1
        {
            display: none;
        }
    </style>

    <style>
fieldset {
  background-color: #eeeeee;
}

legend {
  background-color:white;
  color: white;
  padding: 0px 0px;
}

input {
  margin: 5px;
}
</style>
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id*=txtExpDetails]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Billing_Charge_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id*=hfCustomerId]", $(e.target).closest("td")).val(i.item.val);
                },
                minLength: 1
            });

        });
    </script>
    <script type="text/javascript">
        function Char_Inv(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
                return false;
            return true;
        }
    </script>
    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 13.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 40em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
    
    <script src="../js/js_bootstrap/jquery.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap-multiselect.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $('[id*=ListBox1]').multiselect({

                includeSelectAllOption: true
            });
        });  
    </script>

    <style type="text/css">
    
    .mydatagrid
{
width: 80%;
border: solid 2px black;
min-width: 80%;
}
.header
{
background-color: #6a6a6a;
font-family: Arial;
color: White;
height: 20px;
text-align: center;
font-size: 12px;
}

.rows
{
background-color: #fff;
font-family: Arial;
font-size: 12px;
color: #000;
min-height: 13px;
text-align: left;
}
.rows:hover
{
background-color: #fadd7a;
color: #000;
}

.mydatagrid a /** FOR THE PAGING ICONS **/
{
background-color: Transparent;
padding: 5px 5px 5px 5px;
color: #fff;
text-decoration: none;
font-weight: bold;
}

.mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/
{
background-color: #fff;
color: #000;
}
.mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
{

padding: 5px 5px 5px 5px;
background-color: #000;
color: #fff;
}
.pager
{
background-color: #fadd7a;
font-family: Arial;
color: White;
height: 30px;
text-align: left;
}

.mydatagrid td
{
padding: 5px;
}
.mydatagrid th
{
padding: 5px;
}
    
    
    
    </style>

    <style type="text/css">
        .scrolling
        {
            position: absolute;
        }
        .gvWidthHight
        {
            overflow: scroll;
            height: 230px;
            width: 470px;
        }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Billing" style="height: 130px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                       Journal Entry
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                   
                        <div id="txtcon-m_Exchange" style="width: 220px; margin-top: 5px;">
                            <asp:RadioButtonList ID="Rd_Royal_Other" Font-Bold="true" ForeColor="Blue" runat="server"
                                RepeatDirection="Horizontal" TabIndex="10" >
                                <asp:ListItem Text="eRoyal Jobs" Value="R" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Other Jobs" Value="O"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div id="verslic"></div>
                    <div id="txtcon-m_Exchange" style="width: 100px; margin-top:5px;">
                    Company Lic
                    </div>
                        <div id="txtcon-m_Exchange" style="width: 100px;margin-top:5px; color:Red;">
                            <asp:Literal ID="lbl_Job_Company_Lic" runat="server"></asp:Literal>
                        </div>
                        <div id="verslic"></div>
                        <div id="txtcon-m_Exchange" style="width: 110px; margin-top:5px;">
                        Working Period
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 250px;margin-top:5px; color:Red;">
                        <asp:Literal ID="lbl_Job_Wrk_Period" runat="server"></asp:Literal>
                        </div>
                    </div>

                    <div id="popupwindow_closebut_right_new">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px; height: 70px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 20px;">
                        <div id="tag_transact_lft_in1" style="width: 1100px; height:20px;">
                            <div id="txt_container_Transact_Main_l" style="width: 60px;">
                                <div id="tag_label_transact_Src" style="width: 60px;">
                                    Trans No.
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_l" style="width: 170px;">
                                <asp:TextBox ID="txt_JV_No_F" runat="server" TabIndex="12" ReadOnly="true" BackColor="#e7e6e6"
                                    Width="35px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>

                                <asp:TextBox ID="txt_JV_No_M" runat="server" TabIndex="13" ReadOnly="true" BackColor="#e7e6e6"  style="text-align:right;"
                                    Width="60px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>

                                <asp:TextBox ID="txt_JV_No_L" runat="server" TabIndex="14" ReadOnly="true" BackColor="#e7e6e6"
                                    Width="60px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            </div>
                         <div id="txt_container_Transact_Main_l" style="width: 63px;">
                             <div id="tag_label_transact_Src" style="width: 60px;">
                                 Tr - Date
                             </div>
                         </div>
                         <div id="txt_container_Transact_Main_l" style="width: 95px;">
                             <asp:TextBox ID="txt_JV_Entry_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code" BackColor="#e7e6e6"
                                 TabIndex="17" Enabled="false" Height="20px"></asp:TextBox>
                             <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_JV_Entry_Date"
                                 Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                 CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                 CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                 Enabled="True">
                             </asp:MaskedEditExtender>
                             <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_JV_Entry_Date"
                                 Format="dd/MM/yyyy" Enabled="True">
                             </asp:CalendarExtender>
                         </div>
                         <div id="txt_container_Transact_Main_l" style="width: 67px;">
                             <div id="tag_label_transact_Src" style="width: 65px;">
                              <%--   Ref/Vou No--%>
                             </div>
                         </div>
                         <div id="txt_container_Transact_Main_l" style="width: 95px;">
                             <%--<asp:TextBox ID="txtRefVoucherNo" runat="server" Width="100px" MaxLength="30" Height="20px"
                                 CssClass="txtbox_none_Mid_transac_code" TabIndex="20"></asp:TextBox>--%>
                         </div>
                           
                            <div id="txt_container_Transact_Main_l" style="width: 102px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        Posting Date
                                    </div>
                                </div>
                     <div id="txt_container_Transact_Main_l" style="width: 155px;">
                                <asp:TextBox ID="txt_Posting_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code" 
                                 TabIndex="18"  Height="20px"></asp:TextBox>
                             <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_Posting_Date"
                                 Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                 CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                 CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                 Enabled="True">
                             </asp:MaskedEditExtender>
                             <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_Posting_Date"
                                 Format="dd/MM/yyyy" Enabled="True">
                             </asp:CalendarExtender>
                     </div>
                      
                        </div>
                    </div>
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 20px;">
                     <div id="tag_transact_lft_in1" style="width: 1100px; height:20px;">
                    
                     
                         <div id="txt_container_Transact_Main_l" style="width: 60px; display:none;">
                             <div id="tag_label_transact_Src" style="width: 60px;">
                                 Party
                             </div>
                         </div>
                         <div id="txt_container_Transact_Main_l" style="width: 490px; display:none;">
                             <asp:DropDownList ID="ddl_Party" runat="server" class="chosen-select-deselect" Style="width: 405px;" 
                               AutoPostBack="true"   data-placeholder="Choose a Party Name" TabIndex="21" 
                                 onselectedindexchanged="ddl_Party_SelectedIndexChanged">
                             </asp:DropDownList>
                             <asp:DropDownList ID="ddl_Party_Br" runat="server" class="chosen-select-deselect"
                                 Style="width: 70px;" data-placeholder="Br.No" TabIndex="23">
                             </asp:DropDownList>
                         </div>

                          <div id="txt_container_Transact_Main_l" style="width: 60px;">
                                <div id="tag_label_transact_Src" style="width: 40px;">
                                    Cur.
                                </div>
                            </div>
                         <div id="txt_container_Transact_Main_l" style="width: 110px;">
                             <div id="tag_label_transact_Src" style="width: 50px;">
                                 <asp:DropDownList ID="ddl_JV_Cur" runat="server"  CssClass="listtxt_transac_mode_new" width="50px"  TabIndex="25">
                                     <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                 </asp:DropDownList>
                             </div>
                         </div>
                         <div id="txt_container_Transact_Main_l" style="width: 60px;"> 
                             <div id="tag_label_transact_Src" style="width: 50px;">
                                 <asp:TextBox ID="txt_JV_Cur_Val" runat="server" Text="1.000" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                     Height="20px" Width="50px" MaxLength="17" TabIndex="26" onblur="extractNumber(this,2,false);"
                                     onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                             </div>
                         </div>

                          <div id="txt_container_Transact_Main_l" style="width: 65px;">
                                <div id="tag_label_transact_Src" style="width: 60px;">
                                    Amount
                                </div>
                            </div>
                         <div id="txt_container_Transact_Main_l" style="width: 105px;">
                             <asp:TextBox ID="txt_JV_Amount" runat="server" Width="90px" style="background-color:#93E9BE;" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code"
                                 Height="20px" MaxLength="17" TabIndex="24" onblur="extractNumber(this,2,false);"
                                 onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                         </div>

                     </div>
                    </div>

                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 20px;">
                     <div id="tag_transact_lft_in1" style="width: 1100px; height:20px;">
                    <div id="txt_container_Transact_Main_l" style="width: 60px;">
                            <div id="tag_label_transact_Src" style="width: 68px;">
                                 Ref. No.
                            </div>
                    </div>
                     <div id="txt_container_Transact_Main_l" style="width: 105px;">
                         <asp:TextBox ID="txt_JV_Reference" runat="server" Width="100px" TabIndex="27"
                                    CssClass="listtxt_transac_item_gen_notn" 
                                    Height="20px"></asp:TextBox>
                    </div>
                     
                      <div id="txt_container_Transact_Main_l" style="width: 70px;">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                     Ref. Date
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 105px;">
                                        <asp:TextBox ID="txt_JV_Ref_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code" 
                                             TabIndex="28"  Height="20px"></asp:TextBox>
                                         <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt_JV_Ref_Date"
                                             Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                             CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                             CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                             Enabled="True">
                                         </asp:MaskedEditExtender>
                                         <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_JV_Ref_Date"
                                             Format="dd/MM/yyyy" Enabled="True">
                                         </asp:CalendarExtender>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 70px;">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                     Narration
                                    </div>
                                </div>

                         <div id="txt_container_Transact_Main_l" style="width: 420px;">
                             <asp:TextBox ID="txt_JV_Remarks" runat="server" Width="400px" TabIndex="30" CssClass="listtxt_transac_item_gen_notn"
                                 Height="20px"></asp:TextBox>
                         </div>

                     <div id="txt_container_Transact_Main_l" style="width: 135px;">
                         <asp:Button ID="btnsup" runat="server" TabIndex="35" onclick="btnsup_Click"/> &nbsp;
                         <asp:Button ID="btn_JV_Delete" runat="server" Text="Delete" TabIndex="36" Visible="false" onclick="btn_JV_Delete_Click" />
                             
                     </div>
                     </div>
                    </div>

                    
                    <%------------%>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -30px;">
                <%---28 --%>
                <div id="innerbox_MidMain_Trans_new" style="height: 480px; width: 1150px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                            id="Page_A" runat="server"><span>Detail </span></a></li>
                        <li><a href="#page-7" runat="server">
                        </a></li>
                        <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                            id="Page_C" runat="server" visible="false"><span>Gen -3</span></a></li>
                        <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                            id="Page_D" runat="server" visible="false"><span>Gen -4 </span></a></li>
                    </ol>
                    <div class="content" id="page-6">
                    <div id="pop_text_area_transac_popup_inn_container_new" style="width:1130px">
                    <div id="pop_text_area_transac_popup_inn_container_left_new" style=" width:650px; height:360px;background-color:#DCDCDC;border-radius: 1%;">
                    
                        <div id="tag_transac_lft_in1" style="width:640px" >
                            <div id="tag_label_transaction_popup_gen" style="width:50px">
                                Sl. No</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:65px">
                           

                                 <asp:DropDownList ID="ddlslno" BackColor="White" CssClass="listtxt_transac_item_gen_notn" Width="50px" runat="server" TabIndex="40" >
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                </asp:DropDownList> 

                            </div>
                            <div id="tag_label_transaction_Src" style="width:60px;">
                                Charge
                                </div>
                            <div id="txtcon-m_transaction_code" style="width: 460px">
                             <asp:DropDownList ID="ddl_Imp_Exp" CssClass="listtxt_transac_item_gen_notn" Width="70px" runat="server" TabIndex="43" >
                                 <asp:ListItem Text="IMP" Value="I"></asp:ListItem>
                                 <asp:ListItem Text="EXP" Value="E"></asp:ListItem>
                             </asp:DropDownList> 

                                <asp:DropDownList ID="ddl_Expense_Charges" TabIndex="44" 
                                    class="chosen-select-deselect"  Width="380px" 
                                    data-placeholder="Choose a Expenses" runat="server"  AutoPostBack="true"
                                    onselectedindexchanged="ddl_Expense_Charges_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1" style="width:640px">
                         <div id="tag_label_transaction_Src" style="width:50px;">
                                Amount 
                                </div>
                            <div id="txtcon-m_transaction_code" style="width: 200px">
                                <asp:TextBox ID="txtTotSubExpAmt" runat="server" style="background-color:#93E9BE;" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_code" Height="20px" Width="120px"
                                MaxLength="17" TabIndex="45" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                  onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>

                                   <asp:DropDownList ID="ddl_Exp_Dr_Cr" CssClass="listtxt_transac_item_gen_notn" Width="70px" runat="server" TabIndex="47" >
                                    <asp:ListItem Text="DR" Value="DR"></asp:ListItem>
                                    <asp:ListItem Text="CR" Value="CR"></asp:ListItem>
                                   </asp:DropDownList> 
                            </div>

                            <div id="tag_label_transaction_popup_gen" style="width:50px">
                             Branch
                            </div>
                             <div id="txtcon-m_transaction_code" style="width: 200px">
                                   <asp:DropDownList ID="ddl_Exp_Branch" CssClass="listtxt_transac_item_gen_notn" Width="190px" runat="server" TabIndex="50" >
                                   </asp:DropDownList> 
                            </div>
                        </div>
                        <div id="tag_transac_lft_in1" style="width:640px">
                         <div id="tag_label_transaction_Src" style="width:50px;">
                                Tax
                                </div>
                            <div id="txtcon-m_transaction_code" style="width: 110px">
                                   <asp:DropDownList ID="ddl_Exp_Tax_Type" CssClass="listtxt_transac_item_gen_notn" Width="100px" runat="server" TabIndex="51" >
                                    <asp:ListItem Text="None" Value="O"></asp:ListItem>
                                    <asp:ListItem Text="Taxable" Value="T"></asp:ListItem>
                                    <asp:ListItem Text="Non-Taxable" Value="N"></asp:ListItem>
                                   </asp:DropDownList> 
                            </div>
                             <div id="txtcon-m_transaction_code" style="width: 110px">
                                <asp:DropDownList ID="ddl_Exp_Tax_Type_II" CssClass="listtxt_transac_item_gen_notn" Width="100px" runat="server" TabIndex="51" >
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                   </asp:DropDownList> 
                            </div>
                        </div>
                     
                      
                           <div id="tag_transac_lft_in1" style="width:640px">
                             <div id="tag_label_transaction_Src" style="width:55px;">
                             Narration
                             </div>
                             <div id="txtcon-m_transaction_code" style="width: 580px">
                              <asp:TextBox ID="txt_Exp_Remarks" runat="server" Width="575px" TabIndex="66" CssClass="listtxt_transac_item_gen_notn"
                                 Height="20px"></asp:TextBox>
                             </div>
                        </div>
                        <div id="tag_transac_lft_in1" style=" width:640px">
                            <div id="newbu">
                                <asp:Button ID="btnExpHead_New" runat="server" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                    CausesValidation="false" UseSubmitBehavior="false" TabIndex="70" OnClick="btnExpHead_New_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnExpHead_Save" runat="server" CssClass="save" OnClick="btnExpHead_Save_Click"
                                    OnClientClick="return validate_Export_License(event)" TabIndex="68" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnExpHead_Update" runat="server" CssClass="updates" OnClick="btnExpHead_Update_Click"
                                    OnClientClick="return validate_Export_License(event)" TabIndex="69" />
                            </div>
                            
                            <div id="editbu">
                                <asp:Button ID="btnExpHead_Delete" runat="server" TabIndex="75" CssClass="dlete"
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Journal', function(r) {
                                  var i = r + 'ok';
                                  if(i == 'trueok')
                                  {
                                      document.getElementById('btn1').click();
                                  }
                                  else {
                                  }
                                  });return false;" />
                                <asp:Button ID="btn1" runat="server" TabIndex="75" OnClick="btnExpHead_Delete_Click"
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />
                            </div>
                            <div id="editbu">
                                 <span style="color:Maroon; font-weight:bold;"> &nbsp;  <asp:Literal ID="if" Text="Balance Amt :" runat="server"></asp:Literal> </span> &nbsp;
                                <asp:Literal ID="lbl_Leg_Bal_Amt" runat="server"></asp:Literal>
                            </div>
                        </div>
                       
                      
                        <div id="tag_transac_lft_in1" style="width:640px">
                        
                            <asp:GridView ID="gv_ExpHead" runat="server" DataKeyNames="CH_ID"
                                EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" 
                                Width="100%" ShowHeaderWhenEmpty="True" PageSize="20" 
                                BackColor="WhiteSmoke" CssClass="grid-view" AllowPaging="True" 
                                OnRowCreated="gv_ExpHead_RowCreated" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                 
                                CellPadding="1" CellSpacing="1" OnPageIndexChanging="gv_ExpHead_PageIndexChanging"
                                 OnRowDataBound="gv_ExpHead_RowDataBound"
                                OnSelectedIndexChanged="gv_ExpHead_SelectedIndexChanged">

                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                  
                                   <asp:BoundField DataField="IMP_EXP" HeaderText="Imp/Exp" HeaderStyle-Width="30px">
                                        <ItemStyle CssClass="column_style_left" Width="30px"/>
                                    </asp:BoundField>

                                    <asp:BoundField DataField="CHARGE_NAME" HeaderText="Charge Name" HeaderStyle-Width="250px">
                                        <ItemStyle CssClass="column_style_left" Font-Size="11px" Width="250px" />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="AREA_NAME" HeaderText="Branch" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left" Font-Size="11px" Width="100px" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="AMOUNT" HeaderText="Exp. Amt" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left" Width="50px"/>
                                    </asp:BoundField>
                                     <asp:BoundField DataField="CR_DR" HeaderText="Cr / Dr" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left" Width="50px"/>
                                    </asp:BoundField>
                                 
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <%----R----%>
                    <div id="pop_text_area_transac_popup_inn_container_rght_new" style="float:left; width:480px;">
                    <div id="tag_transac_lft_in1" style="width:475px">
                    <div id="tag_label_transaction_popup_gen" style="width:470px; color:Maroon; font-weight:bold;">
                     Job Bifurcation :-
                      <span style="font-size:10px;color:Green;">  <asp:Literal ID="lblcharge" runat="server"></asp:Literal> </span>
                    </div>
                    </div>

                     <div id="tag_transac_lft_in1" style="width:475px" >
                     <div id="tag_label_transaction_popup_gen" style="width:80px">
                                Cost Center </div>
                           <div id="tag_label_transaction_popup_gen" style="width:90px"> <%--Enabled="false"--%>
                                  <asp:DropDownList ID="ddl_Job_Imp_Exp" CssClass="listtxt_transac_item_gen_notn" 
                                      Width="80px"  runat="server" TabIndex="80" AutoPostBack="true"
                                      onselectedindexchanged="ddl_Job_Imp_Exp_SelectedIndexChanged" >
                                    <asp:ListItem Text="CCL Imp" Value="I"></asp:ListItem>
                                    <asp:ListItem Text="CCL Exp" Value="E"></asp:ListItem>
                                    <asp:ListItem Text="Cash" Value="C"></asp:ListItem>
                                    <asp:ListItem Text="Bank" Value="B"></asp:ListItem>
                                    <asp:ListItem Text="Purchase" Value="P"></asp:ListItem>
                                    <asp:ListItem Text="Sales" Value="S"></asp:ListItem>
                                    </asp:DropDownList> 
                           </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:290px">
                                 <asp:DropDownList ID="ddl_Jobno" class="chosen-select-deselect" data-placeholder="Choose a Jobno"
                                  Width="140px" runat="server" TabIndex="81" onchange="Load_Jobno_CusName()" AutoPostBack="true"
                                     onselectedindexchanged="ddl_Jobno_SelectedIndexChanged" >
                                 </asp:DropDownList>

                                 <asp:TextBox ID="txt_Other_Jobno" runat="server" Width="140px" ForeColor="Blue" Height="20px" MaxLength="20" CssClass="txtbox_none_Mid_transac_item_maindet"
                                 ClientIDMode="Static" TabIndex="82" ></asp:TextBox>
                            </div>
                            
                        </div>
                     <%--<div id="tag_transac_lft_in1" style="width: 475px">
                            <div id="tag_label_transaction_popup_gen" style="width: 470px;">
                                <span style="font-size: 11px; color: Green;">
                                    <asp:Label ID="lbl_Cus_Name" runat="server"></asp:Label>
                                </span>
                            </div>
                        </div> --%>   

                        <div id="tag_transac_lft_in1" style="width:480px" >
                            <div id="tag_label_transact_Src" style="width:50px">
                                Amount </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:122px">
                                   <asp:TextBox ID="txt_Exp_Job_Amt" runat="server" Width="120px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="85" onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width: 300px;">
                                <span style="font-size: 11px; color: Green;">
                                    <asp:Label ID="lbl_Cus_Name" runat="server"></asp:Label>
                                </span>
                            </div>

                        </div>


                        <div id="tag_transac_lft_in1" style="width: 475px">
                            <div id="newbu">
                                <asp:Button ID="btnJob_New" runat="server" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                    CausesValidation="false" UseSubmitBehavior="false" TabIndex="99" 
                                    onclick="btnJob_New_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnJob_Save" runat="server" CssClass="save" OnClientClick="return validate_Export_License(event)"
                                    TabIndex="95" onclick="btnJob_Save_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnJob_Update" runat="server" CssClass="updates" OnClientClick="return validate_Export_License(event)"
                                    TabIndex="96" onclick="btnJob_Update_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnJob_Delete" runat="server" TabIndex="98" CssClass="dlete" CausesValidation="false"
                                    UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job Entry?', 'Journal Job Entry', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn3').click();
                                          }
                                          else {
                                          }
    
                                });return false;" />
                                <asp:Button ID="btn3" runat="server" TabIndex="98" OnClick="btnJob_Delete_Click"
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />  
                            </div>
                             <div id="editbu" style="margin-top:4px;"> &nbsp; &nbsp;
                                <asp:Button ID="btnJob_Delete_All" runat="server" TabIndex="100" Text="Delete All"  CausesValidation="false" Visible="false"
                                    UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete All Job(s) Entry?', 'Journal Job', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn4').click();
                                          }
                                          else {
                                          }
                                });return false;" />
                                <asp:Button ID="btn4" runat="server" TabIndex="100"  OnClick="btnJob_Delete_All_Click" 
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />  
                            </div>
                             <div id="editbu" style="width: 90px">
                                        &nbsp;
                                        <asp:Button ID="btngenexcel" runat="server" Width="82px" CausesValidation="false"
                                            UseSubmitBehavior="false" Visible="True" CssClass="autowidmovebut" Text="Excel Upload"
                                            style="width:85px;margin-left: -5px;"
                                            OnClientClick="jQuery('#form1').validationEngine('hide');open_Journal_Excel_Upload();return false;" />
                                    </div>
                                    <div id="editbu">
                                        &nbsp; <a href="../Accounts_Others/JOURNAL_ENTRY_EXCEL_UPLOAD.xlsx" target="_new">
                                            <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"
                                                Height="30px" Width="30px" runat="server" /></a>
                                    </div>

                            <div id="editbu">
                                <span style="color:Red;" > <asp:Label ID="lbl_Error_Msg" runat="server"  ></asp:Label></span>
                            </div>
                        </div>

                         <div id="tag_transac_lft_in1" style=" width:475px;">
                         <div id="tag_label_transact_Src" style="width:470px;margin-top:5px;">
                            <span style="color: Blue; font-weight:bold;" > &nbsp;&nbsp;Total Job Amt : &nbsp;</span>
                            <span style="color:Red;" > <asp:Label ID="lbljob_total_amt" runat="server"  ></asp:Label></span>
                         </div>
                          
                         </div>
                        <div id="tag_transac_lft_in1" style=" width:475px;">
                          
                                                <div id="tag_transac_export_rght1_license_Grid_area_new1" style="overflow: auto;
                                                    height: 300px; width:470px; background-color: White;">
                                                    
                                                    <div class="gvWidthHight">
                                                    <asp:GridView ID="gv" runat="server" DataKeyNames="J_ID,CH_ID,JV_ID,IMP_EXP,JOBNO,JOBNO_PS" EmptyDataText="NO RECORD FOUND"
                                                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                                        ShowHeaderWhenEmpty="True" PageSize="150" AllowPaging="True" 
                                                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                                        CellPadding="1" CellSpacing="1" HorizontalAlign="Left" OnRowCreated="gv_RowCreated"
                                                        ShowFooter="false" Style="overflow: auto;" 
                                                        onrowdatabound="gv_RowDataBound" 
                                                        onselectedindexchanged="gv_SelectedIndexChanged">  
                                                        
                                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                                           BorderWidth="1px" />
                                                           <HeaderStyle CssClass="scrolling" BackColor="#7961da" Font-Bold="True"  /> 
                                                        <Columns>
                                                        <asp:CommandField ShowSelectButton="True">
                                                                <HeaderStyle CssClass="hideGridColumn" />
                                                                <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:CommandField>
                                                            <asp:BoundField DataField="IMP_EXP" HeaderText="Imp/Exp" HeaderStyle-Width="30px">
                                                                <ItemStyle CssClass="column_style_left" Width="30px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="JOBNO_PS" HeaderText="Ref. No" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="column_style_left" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="J_AMOUNT" HeaderText="Amount" HeaderStyle-Width="30px">
                                                                <ItemStyle CssClass="column_style_left" Width="30px" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <PagerStyle CssClass="pager" />
                                                    </asp:GridView>
                                                    </div>
                        </div>
                    </div>
                    </div>
                        
                    </div>
                </div>
                <%-------------------------------------------------------------------------------%>
            </div>
            <%-- --------------------Test Start----------------------------%>
            
            <%-- --------------------Test End----------------------------%>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Ch_id" runat="server" />

            <asp:HiddenField ID="HDupdate_Group_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Imp_Exp" runat="server" />
           
            <asp:HiddenField ID="HDupdate_Job_Id" runat="server" />

            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdnVoucherNo" runat="server" />

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

        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/Accounts/Acc_iframepopupwin.js"></script>
    <%--<script src="../js/checkboxJScript.js" type="text/javascript"></script>--%>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <%--<script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>--%>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });
        function close_button() {
            document.getElementById("General").click();
        }


        function Load_Jobno_CusName() {
            var ddl = document.querySelector('#ddl_Jobno');
            var ddl_job = document.querySelector('#ddl_Jobno').value;
            var selectedText = ddl.options[ddl.selectedIndex].text;
            document.getElementById("txt_Other_Jobno").value = ddl_job;
            var Imp_Exp = document.querySelector('#ddl_Job_Imp_Exp').value;
            PageMethods.Getload_Job_Data(selectedText, Imp_Exp, ddl_job, CallSuccess_Jobno_CusName);
        }

        function CallSuccess_Jobno_CusName(res) {
            var cus = document.getElementById('<%= lbl_Cus_Name.ClientID %>');
            cus.innerHTML = res;
        }

        window.onload = function () {
            Load_Jobno_CusName();
        };
    </script>
  
</body>
</html>
