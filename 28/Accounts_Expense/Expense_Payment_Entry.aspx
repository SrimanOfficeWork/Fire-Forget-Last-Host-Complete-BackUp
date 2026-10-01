<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Expense_Payment_Entry.aspx.cs"
    Inherits="Expense_Payment_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Expenses </title>
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
            <div id="innerbox_MidMain_Billing" style="height: 110px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 130px;">
                        Expenses Entry
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                        <div id="txtcon-m_Exchange" style="width: 220px; margin-top: 5px;">
                            <asp:RadioButtonList ID="Rd_Royal_Other" Font-Bold="true" ForeColor="Blue" runat="server"
                                RepeatDirection="Horizontal" TabIndex="10" AutoPostBack="true" OnSelectedIndexChanged="Rd_Royal_Other_SelectedIndexChanged">
                                <asp:ListItem Text="eRoyal Jobs" Value="R" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Other Jobs" Value="O"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div id="verslic">
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px; margin-top: 5px;">
                            Company Lic
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px; margin-top: 5px; color: Red;">
                            <asp:Literal ID="lbl_Job_Company_Lic" runat="server"></asp:Literal>
                        </div>
                        <div id="verslic">
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px; margin-top: 5px;">
                            Working Period
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 250px; margin-top: 5px; color: Red;">
                            <asp:Literal ID="lbl_Job_Wrk_Period" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px; height: 70px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 30px;">
                        <div id="tag_transact_lft_in1" style="width: 1100px; height: 30px;">
                            <%--<div id="txt_container_Transact_Main_l" style="width: 110px;">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Customer Name
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 305px;">
                                      <asp:DropDownList ID="ddlCustomer" runat="server" class="chosen-select-deselect"
                                        Style="width: 300px;" data-placeholder="Choose a Customer Name" 
                                        TabIndex="10" >
                                        </asp:DropDownList>
                                </div>--%>
                            <div id="txt_container_Transact_Main_l" style="width: 80px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Voucher No
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 130px;">
                                <asp:TextBox ID="txtExpVoucherNo" runat="server" TabIndex="15" ReadOnly="true" BackColor="#e7e6e6"
                                    Width="125px" Height="20px" MaxLength="100" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 75px;">
                                <div id="tag_label_transact_Src" style="width: 60px;">
                                    Exp-Date
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 95px;">
                                <asp:TextBox ID="txtDate" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="17" Height="20px"></asp:TextBox>
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
                            <div id="txt_container_Transact_Main_l" style="width: 75px;">
                                <div id="tag_label_transact_Src" style="width: 75px;">
                                    Ref/Vou No
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 105px;">
                                <asp:TextBox ID="txtRefVoucherNo" runat="server" Width="100px" MaxLength="30" Height="20px"
                                    CssClass="txtbox_none_Mid_transac_code" TabIndex="20"></asp:TextBox>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 72px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Staff Name
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 265px;">
                              <%--  <asp:TextBox ID="txtStaffName" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                    Width="153px" Height="20px" MaxLength="50" Font-Size="12px" TabIndex="21"></asp:TextBox>--%>

                                 <asp:DropDownList ID="ddlstaff_Name" runat="server" class="chosen-select-deselect"
                                    Style="width: 260px;font-size:12px;" data-placeholder="Choose a Staff Name" TabIndex="21">
                                </asp:DropDownList>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 62px;">
                                <div id="tag_label_transact_Src" style="width: 62px;">
                                    Given By
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 135px;">
                                <asp:TextBox ID="txtGivenBy" CssClass="listtxt_transac_item_gen_notn" Height="20px"
                                    runat="server" Width="130px" MaxLength="50" Font-Size="12px" TabIndex="22"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 30px;">
                        <div id="tag_transact_lft_in1" style="width: 1100px; height: 30px;">
                            
                            <div id="txt_container_Transact_Main_l" style="width: 110px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Customer Name
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 385px;">
                                <asp:DropDownList ID="ddlCustomer" runat="server" class="chosen-select-deselect"
                                    Style="width: 375px;font-size:12px;" data-placeholder="Choose a Customer Name" TabIndex="23">
                                </asp:DropDownList>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 70px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Total Amt
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 85px;">
                                <asp:TextBox ID="txtTotalExpAmt" BackColor="#e7e6e6" runat="server" Width="82px"
                                    TabIndex="24" CssClass="txtbox_none_Mid_transac_code" ReadOnly="true" Style="text-align: right"
                                    Height="20px"></asp:TextBox>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 80px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    Narration
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 184px;">
                                <asp:TextBox ID="txtRemarks" runat="server" Width="180px" MaxLength="30" TabIndex="25"
                                    CssClass="listtxt_transac_item_gen_notn" Height="20px" Style="text-align: left"></asp:TextBox>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 100px;">
                                <asp:Button ID="btnsup" runat="server" TabIndex="27" OnClick="btnsup_Click" />
                            </div>

                             <div id="editbu">
                                 <asp:Button ID="btnDelete" runat="server" TabIndex="27" CausesValidation="false"
                                     UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Expense?', 'Expense', function(r) {
                                      var i = r + 'ok';
                                      if(i == 'trueok')
                                      {
                                          document.getElementById('btn').click();
                                      }
                                      else {
                                      }
                                      });return false;" />
                                        <asp:Button ID="btn" runat="server" TabIndex="27" OnClick="btnDelete_Click" CausesValidation="false"
                                         UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                         CssClass="dlete" Style="display: none;" />
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
                            id="Page_A" runat="server"><span>General </span></a></li>
                        <li><a href="#page-7" runat="server"></a></li>
                        <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                            id="Page_C" runat="server" visible="false"><span>Gen -3</span></a></li>
                        <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                            id="Page_D" runat="server" visible="false"><span>Gen -4 </span></a></li>
                    </ol>
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_new" style="width: 1130px; margin-left: -10px;">
                            <div id="pop_text_area_transac_popup_inn_container_left_new" style="width: 600px;
                                background-color: #DCDCDC; border-radius: 1%;">
                                <div id="tag_transac_lft_in1" style="width: 560px">
                                    <div id="tag_label_transaction_popup_gen" style="width: 50px">
                                        Sl. No</div>
                                    <div id="txtcon-m_transaction_item_maindet" style="width: 65px">
                                        <asp:TextBox ID="txtRegn_Sl_No" runat="server" Width="60px" MaxLength="3" Height="20px"
                                            CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="30"
                                            onkeypress="return pin(event)"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_Src" style="text-align: center; width: 90px;">
                                        Date
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 250px">
                                        <asp:TextBox ID="txt_Exp_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="31" Height="20px"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Exp_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Exp_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1" style="width: 560px">
                                    <div id="tag_label_transaction_Src" style="text-align: center; width: 90px;">
                                        Expsenses For
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 350px">
                                        <asp:DropDownList ID="ddl_Expense_Charges" TabIndex="35" class="chosen-select-deselect"
                                            Width="340px" data-placeholder="Choose a Expenses" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1" style="width: 560px">
                                    <div id="txtcon-m_transaction_item_maindet" style="width: 125px">
                                        <asp:RadioButtonList ID="Rd_Imp_Exp" Font-Bold="true" ForeColor="Blue" runat="server"
                                            RepeatDirection="Horizontal" TabIndex="38">
                                            <asp:ListItem Text="Import" Value="I" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div id="tag_label_transaction_popup_gen" style="width: 50px">
                                        Tr.Mode
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet" style="width: 67px">
                                        <asp:DropDownList ID="ddlTr_Mode" CssClass="listtxt_transac_item_gen_notn" Width="60px"
                                            runat="server" TabIndex="39">
                                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                            <asp:ListItem Text="Air" Value="A"></asp:ListItem>
                                            <asp:ListItem Text="Sea" Value="S"></asp:ListItem>
                                            <asp:ListItem Text="Land" Value="L"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transaction_popup_gen" style="width: 70px">
                                        Exp. Amt</div>
                                    <div id="txtcon-m_transaction_item_maindet" style="width: 125px">
                                        <asp:TextBox ID="txtTotSubExpAmt" runat="server" Width="120px" Height="20px" MaxLength="10"
                                            CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="40"
                                            onkeypress="return pin(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1" style="width: 560px">
                                    <div id="newbu">
                                        <asp:Button ID="btnExpHead_New" runat="server" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                            CausesValidation="false" UseSubmitBehavior="false" TabIndex="44" OnClick="btnExpHead_New_Click" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnExpHead_Save" runat="server" CssClass="save" OnClick="btnExpHead_Save_Click"
                                            OnClientClick="return validate_Export_License(event)" TabIndex="42" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnExpHead_Update" runat="server" CssClass="updates" OnClick="btnExpHead_Update_Click"
                                            OnClientClick="return validate_Export_License(event)" TabIndex="43" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnExpHead_Delete" runat="server" TabIndex="45" CssClass="dlete"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Expenses', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn1').click();
            
          }
          else {
          }
    
});return false;" />
                                        <asp:Button ID="btn1" runat="server" TabIndex="45" OnClick="btnExpHead_Delete_Click"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnPrint" Text="Print" TabIndex="48" CssClass="autowidmovebut" runat="server"
                                            OnClientClick="open_jobnoNew(); return false" Width="80px" Visible="false" />
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1" style="width: 600px">
                                    <asp:GridView ID="gv_ExpHead" runat="server" DataKeyNames="CH_ID,EXP_ID" EmptyDataText="NO RECORD FOUND"
                                        AutoGenerateColumns="False" Width="100%" ShowHeaderWhenEmpty="True" PageSize="20"
                                        BackColor="WhiteSmoke" CssClass="grid-view" AllowPaging="True" OnRowCreated="gv_ExpHead_RowCreated"
                                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                        OnPageIndexChanging="gv_ExpHead_PageIndexChanging" OnRowDataBound="gv_ExpHead_RowDataBound"
                                        OnSelectedIndexChanged="gv_ExpHead_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            BorderWidth="1px" />
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True">
                                                <HeaderStyle CssClass="hideGridColumn" />
                                                <ItemStyle CssClass="hideGridColumn" />
                                            </asp:CommandField>
                                            <asp:BoundField DataField="LINE_NO" HeaderText="Sl No" HeaderStyle-Width="25px">
                                                <ItemStyle CssClass="column_style_left" Width="25px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IMP_EXP" HeaderText="Imp/Exp" HeaderStyle-Width="10px">
                                                <ItemStyle CssClass="column_style_left" Width="10px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TR_MODE" HeaderText="Tr. Mode" HeaderStyle-Width="50px">
                                                <ItemStyle CssClass="column_style_left" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="S_EXPENSE_FOR" HeaderText="Expenses For" HeaderStyle-Width="130px">
                                                <ItemStyle CssClass="column_style_left" Width="130px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EXP_AMT" HeaderText="Exp. Amt" HeaderStyle-Width="50px">
                                                <ItemStyle CssClass="column_style_left" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EXPAMT_JOB" HeaderText="Job. Amt" HeaderStyle-Width="50px">
                                                <ItemStyle CssClass="column_style_left" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EXPENSE_FOR">
                                                <HeaderStyle CssClass="hideGridColumn" />
                                                <ItemStyle CssClass="hideGridColumn" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="EXP_DATE">
                                                <HeaderStyle CssClass="hideGridColumn" />
                                                <ItemStyle CssClass="hideGridColumn" />
                                            </asp:BoundField>
                                        </Columns>
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                            NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                        <PagerStyle CssClass="pager" />
                                    </asp:GridView>
                                </div>
                            </div>
                            <%----R----%>
                            <div id="pop_text_area_transac_popup_inn_container_rght_new" style="float: left;
                                width: 480px;">
                                <div id="tag_transac_lft_in1" style="width: 475px">
                                    <div id="tag_label_transaction_popup_gen" style="width: 450px; color: Maroon; font-weight: bold;">
                                        Job Bifurcation :- <span style="font-size: 10px; color: Green;">
                                            <asp:Literal ID="lblcharge" runat="server"></asp:Literal>
                                        </span>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1" style="width: 475px">
                                    <div id="tag_label_transaction_popup_gen" style="width: 80px">
                                        <asp:DropDownList ID="ddl_Job_Imp_Exp" CssClass="listtxt_transac_item_gen_notn" Width="70px"
                                            Enabled="false" runat="server" TabIndex="80">
                                            <asp:ListItem Text="IMP" Value="I"></asp:ListItem>
                                            <asp:ListItem Text="EXP" Value="E"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transaction_popup_gen" style="width: 50px">
                                        Jobno
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet" style="width: 340px">
                                        <asp:DropDownList ID="ddl_Jobno" class="chosen-select-deselect" data-placeholder="Choose a Jobno"
                                            Width="160px" runat="server" TabIndex="81" onchange="Load_Jobno_CusName()">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_Other_Jobno" runat="server" Width="160px" ForeColor="Blue" Height="20px"
                                            MaxLength="20" CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                            TabIndex="82"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1" style="width: 475px">
                                    <div id="tag_label_transaction_popup_gen" style="width: 470px;">
                                        <span style="font-size: 12px; color: Green;">
                                            <asp:Label ID="lbl_Cus_Name" runat="server"></asp:Label>
                                        </span>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1" style="width: 480px">
                                    <div id="tag_label_transact_Src" style="width: 50px">
                                        Amount
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet" style="width: 122px">
                                        <asp:TextBox ID="txt_Exp_Job_Amt" runat="server" Width="120px" Height="20px" MaxLength="10"
                                            CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="85"
                                            onkeypress="return pin(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <%--<div id="tag_transac_lft_in1" style="width:655px" >
                          <div id="tag_label_transaction_Src" style="width:80px;">
                                File Ref.no :
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 160px">
                                <asp:TextBox ID="txt_Job_file_Refno" runat="server" Width="150px" Height="20px" MaxLength="20" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="55" ></asp:TextBox>

                            </div>
                           <div id="tag_label_transaction_Src" style="width:70px;">
                              Job Date :
                            </div>
                            <div id="txtcon-m_transaction_code" style="width: 100px">
                                 <asp:TextBox ID="txt_Job_Date" runat="server" Width="90px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                    TabIndex="58" Height="20px"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Job_Date"
                                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                    Enabled="True">
                                                </asp:MaskedEditExtender>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Job_Date"
                                                    Format="dd/MM/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width:50px">
                                Tr.Mode :</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:150px">
                               <span style="color:Blue;"> <asp:Literal ID="lbl_Tr_Mode" runat="server"></asp:Literal> </span> 
                               <asp:DropDownList ID="ddl_Job_tr_Mode" CssClass="listtxt_transac_item_gen_notn" Width="60px" runat="server" TabIndex="60" >
                                             <asp:ListItem Text="Air" Value="A"></asp:ListItem>
                                             <asp:ListItem Text="Sea" Value="S"></asp:ListItem>
                                             <asp:ListItem Text="Land" Value="L"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                           
                        </div>--%>
                                <%--<div id="tag_transac_lft_in1" style="width:655px" >
                            <div id="tag_label_transact_Src" style="width:50px">
                                Amount </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:122px">
                                   <asp:TextBox ID="txt_Exp_Job_Amt" runat="server" Width="120px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="61" onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_Src" style="text-align: center;width:90px;">
                             Remarks 
                             </div>
                            <div id="txtcon-m_transaction_code" style="width: 380px">
                                 <asp:TextBox ID="txt_Job_Remarks" runat="server" Width="380px" MaxLength="30" CssClass="listtxt_transac_item_gen_notn"
                                    Height="20px" TabIndex="62" Style="text-align: left"></asp:TextBox>
                            </div>
                        </div>--%>
                                <div id="tag_transac_lft_in1" style="width: 655px">
                                    <div id="newbu">
                                        <asp:Button ID="btnJob_New" runat="server" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                            CausesValidation="false" UseSubmitBehavior="false" TabIndex="70" OnClick="btnJob_New_Click" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnJob_Save" runat="server" CssClass="save" OnClientClick="return validate_Export_License(event)"
                                            TabIndex="65" OnClick="btnJob_Save_Click" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnJob_Update" runat="server" CssClass="updates" OnClientClick="return validate_Export_License(event)"
                                            TabIndex="66" OnClick="btnJob_Update_Click" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnJob_Delete" runat="server" TabIndex="68" CssClass="dlete" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job Entry?', 'Job Expenses', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn3').click();
                                          }
                                          else {
                                          }
    
                                });return false;" />
                                        <asp:Button ID="btn3" runat="server" TabIndex="68" OnClick="btnJob_Delete_Click"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                    </div>
                                    <div id="editbu" style="margin-top: 4px;">
                                        &nbsp; &nbsp;
                                        <asp:Button ID="btnJob_Delete_All" runat="server" TabIndex="61" Text="Delete All"
                                            CausesValidation="false" Visible="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete All Job(s) Entry?', 'Job Expenses', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn4').click();
                                          }
                                          else {
                                          }
                                });return false;" />
                                        <asp:Button ID="btn4" runat="server" TabIndex="77" OnClick="btnJob_Delete_All_Click"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                    </div>
                                    <div id="editbu">
                                        <span style="color: Red;">
                                            <asp:Label ID="lbl_Error_Msg" runat="server"></asp:Label></span>
                                    </div>
                                    <div id="editbu" style="width: 90px">
                                        &nbsp;
                                        <asp:Button ID="btngenexcel" runat="server" Width="82px" CausesValidation="false"
                                            UseSubmitBehavior="false" Visible="True" CssClass="autowidmovebut" Text="Excel Upload"
                                            Style="width: 85px; margin-left: -5px;" OnClientClick="jQuery('#form1').validationEngine('hide');open_Expense_Excel_Upload();return false;" />
                                    </div>
                                    <div id="editbu">
                                        &nbsp; <a href="../Accounts_Expense/EXPENSE_PAYMENT_ENTRY_EXCEL_UPLOAD.xlsx" target="_new">
                                            <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"
                                                Height="30px" Width="30px" runat="server" /></a>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1" style="width: 655px;">
                                    <div id="tag_label_transact_Src" style="width: 500px; margin-top: 5px;">
                                        <span style="color: Blue; font-weight: bold;">&nbsp;&nbsp; Exp. Amt : &nbsp;</span>
                                        <span style="color: Red;">
                                            <asp:Label ID="lbl_Exp_Amt" runat="server"></asp:Label></span> <span style="color: Blue;
                                                font-weight: bold;">&nbsp;&nbsp;Total Job Amt : &nbsp;</span> <span style="color: Red;">
                                                    <asp:Label ID="lbljob_total_amt" runat="server"></asp:Label></span>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_in1" style="width: 655px;">
                                    <div id="tag_transac_export_rght1_license_Grid_area_new1" style="overflow: auto;
                                        height: 300px; width: 650px; background-color: White;">
                                        <asp:GridView ID="gv" runat="server" DataKeyNames="J_ID,CH_ID,EXP_ID,JOBNO,JOBNO_PS"
                                            EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                                            CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True" PageSize="100" AllowPaging="True"
                                            BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                            HorizontalAlign="Left" OnRowCreated="gv_RowCreated" ShowFooter="false" Style="overflow: auto;"
                                            OnRowDataBound="gv_RowDataBound" OnSelectedIndexChanged="gv_SelectedIndexChanged">
                                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                                BorderWidth="1px" />
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True">
                                                    <HeaderStyle CssClass="hideGridColumn" />
                                                    <ItemStyle CssClass="hideGridColumn" />
                                                </asp:CommandField>
                                                <asp:BoundField DataField="IMP_EXP" HeaderText="Imp/Exp" HeaderStyle-Width="30px">
                                                    <ItemStyle CssClass="column_style_left" Width="30px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="JOBNO_PS" HeaderText="Jobno" HeaderStyle-Width="100px">
                                                    <ItemStyle CssClass="column_style_left" Width="100px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EXPAMT_JOB" HeaderText="Amount" HeaderStyle-Width="30px">
                                                    <ItemStyle CssClass="column_style_left" Width="30px" />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                            <PagerStyle CssClass="pager" />
                                        </asp:GridView>
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
            <asp:HiddenField ID="HDupdate_Imp_Exp" runat="server" />
            <asp:HiddenField ID="HDupdate_Tr_Mode" runat="server" />
            <asp:HiddenField ID="HDupdate_Line_Id" runat="server" />
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
