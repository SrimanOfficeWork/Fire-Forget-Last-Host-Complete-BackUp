<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExpensesPaymentEntry.aspx.cs"
    Inherits="ExpensesPaymentEntry" %>

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

<script type="text/javascript">
    function GetFileSize(fileid) {
        try {
            var fileSize = 0;
            //for IE
            if ($.browser.msie) {
                //before making an object of ActiveXObject,
                //please make sure ActiveX is enabled in your IE browser
                var objFSO = new ActiveXObject("Scripting.FileSystemObject"); var filePath = $("#" + fileid)[0].value;
                var objFile = objFSO.getFile(filePath);
                var fileSize = objFile.size; //size in kb

                //fileSize = fileSize / 1048576; //size in mb
            }
            //for FF, Safari, Opeara and Others
            else {
                fileSize = $("#" + fileid)[0].files[0].size //size in kb

                //fileSize = fileSize / 1048576; //size in mb
            }

            if (fileSize < 1048576) {

            }
            else {
                jAlert('File size exceeds maximum limit 1 MB.', 'Expense Entry', function (r) { document.getElementById("btn_Upload").focus(); });

                //jAlert('File size exceeds maximum limit 500 KB.', 'Expense Entry', function (r) { document.getElementById("btn_Upload").focus(); });

                //alert("File size exceeds maximum limit 1 MB.");
                return false;
            }

        }
        catch (e) {
            alert("Error is :" + e);
        }
    }
 </script>

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
            <div id="innerbox_MidMain" style="height: 110px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                        Exp-Entry
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <%--<div id="tag_label_transact_Src" style="width: 110px;">
                                   Type of Invoice:
                                </div>--%>
                        <div id="txtcon-m_Exchange" style="width: 150px;">
                            <asp:RadioButtonList ID="Rd_Job_Type" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="true" OnSelectedIndexChanged="Rd_Job_Type_SelectedIndexChanged">
                                <asp:ListItem Text="Imp" Value="Imp" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Exp" Value="Exp"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2">
                        <span runat="server" id="WK" visible="false">
                            <div id="tag_label_transaction_popup_gen">
                                Working Period</div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlWorkingPeriod_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </span>
                    </div>
                    <%-- <div id="popupwindow_closebut_right_new">
                      <span id="F" runat="server"><input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 
                      <span id="T" runat="server">  <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span> 
                    </div>--%>
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                    <%--  <div id="popupwindow_closebut_right_new">
                  <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                  </div>--%>
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px;height:120px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px;height:120px;">
                        <div id="tag_transact_lft_in1" style="width: 1100px; height:120px;">                            
                            <div style="width: 1100px; height: 30px">
                                <div id="txt_container_Transact_Main_l" style="width:220px;">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Branch:
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:150px;" >
                                        <asp:DropDownList ID="ddlbranch_No" CssClass="listtxt_transac_item_gen_notn" Width="150px"
                                            runat="server" TabIndex="0" AutoPostBack="true" OnSelectedIndexChanged="ddlbranch_No_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width:420px;">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                         &nbsp Based On
                                    </div>
                                     <div id="txtcon-m_Exchange">
                                        <asp:DropDownList ID="ddltype" runat="server" TabIndex="1" 
                                             CssClass="txtbox_none" Font-Size="12px"  Width="150px" AutoPostBack="true"
                                             onselectedindexchanged="ddltype_SelectedIndexChanged"  >
                                            <asp:ListItem Text=" " Value="0" ></asp:ListItem>
                                            <asp:ListItem Text="File.Ref.no" Value="FRN" ></asp:ListItem>
                                            <asp:ListItem Text="Job No" Value="JOB_NO" ></asp:ListItem>  <%--Value="Imp_Name"--%>                                      
                                            <asp:ListItem Text="Staff Name" Value="STAFF_NAME"  Enabled="false"></asp:ListItem>  
                                            <asp:ListItem Text="Expense Head" Value="EXPENSE_HEAD" Enabled="false" ></asp:ListItem>
                                            <asp:ListItem Text="Inv No" Value="BILL_INV_NO" Enabled="false" ></asp:ListItem>
                                            <asp:ListItem Text="General" Value="GENERAL" Enabled="false" ></asp:ListItem>
                                        </asp:DropDownList>
                                     </div>
                                    <div id="txtcon-m_Exchange" >
                                        <asp:DropDownList ID="ddlSearch" CssClass="listtxt_transac_item_gen_notn" Width="175px"
                                            runat="server" TabIndex="2" AutoPostBack="true" OnSelectedIndexChanged="ddlSearch_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:CheckBox ID="chkIncludeAllSearch" runat="server" ToolTip="Include All" AutoPostBack="true"
                                            OnCheckedChanged="chkIncludeJob_OnCheckedChanged" Visible="false" TabIndex="3"/>
                                    </div>
                                </div>

                                <div id="txt_container_Transact_Main_l" style="display: none;" >
                                    <div id="tag_label_transact_Src" style="width: 50px;">
                                        Job No:
                                    </div>
                                    <div id="txtcon-m_Exchange" style="display: none;" >
                                        <asp:DropDownList ID="ddljobno" CssClass="listtxt_transac_item_gen_notn" Width="120px"
                                            runat="server" TabIndex="4" AutoPostBack="true" OnSelectedIndexChanged="ddljobno_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:CheckBox ID="chkIncludeJob" runat="server" ToolTip="Include All Job" AutoPostBack="true"
                                            OnCheckedChanged="chkIncludeJob_OnCheckedChanged" TabIndex="5" />
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width:420px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Customer Name:
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px">
                                        <asp:TextBox ID="txtCustName" runat="server" Width="150px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            ReadOnly="true" TabIndex="6"></asp:TextBox>
                                    </div>

                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                       &nbsp &nbsp Br_Sl_No:
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 70px">
                                        <asp:TextBox ID="txtBranchSlNo" runat="server" Width="80px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            ReadOnly="true" TabIndex="7"></asp:TextBox>
                                    </div>
                                </div>
                           </div>
                           <div style="width: 1100px; height: 30px">                             
                                <div id="txt_container_Transact_Main_l" style="width: 220px;">                           
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        File.Ref.no
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtFileRefNo" runat="server" TabIndex="8" Width="147px" MaxLength="50" CssClass="txtbox_none_Mid_transac_code" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 220px;">                           
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                       &nbsp Job No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtjobno" runat="server" TabIndex="9" Width="147px" MaxLength="50" CssClass="txtbox_none_Mid_transac_code" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>                                                                                      
                             
                             
                                <div id="txt_container_Transact_Main_l" style="width: 300px;display: none;"  >                           
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        &nbsp Exp Details
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 220px;">
                                        <asp:TextBox ID="txtExpenseHead" runat="server" TabIndex="10" Width="220px" MaxLength="50" CssClass="txtbox_none_Mid_transac_code" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 330px;display: none;">                           
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                       &nbsp Staff Name
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 250px;">
                                        <asp:TextBox ID="txtStaffName" runat="server" TabIndex="11" Width="250px" MaxLength="50" CssClass="txtbox_none_Mid_transac_code" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div> 
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                       &nbsp Job Info
                                    </div>
                                    <div id="txtcon-m_Exchange">
                                        <asp:TextBox ID="txtJobInfo" runat="server" MaxLength="1000" TextMode="MultiLine"
                                            Style="width: 560px; height: 27px" ReadOnly="true" TabIndex="12" ></asp:TextBox>
                                    </div>
                                </div>                             
                           </div>
                           <%--<div style="width: 1100px; height: 30px">
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Job Info
                                    </div>
                                    <div id="txtcon-m_Exchange">
                                        <asp:TextBox ID="txtJobInfo" runat="server" MaxLength="1000" TextMode="MultiLine"
                                            Style="width: 1000px; height: 30px" ReadOnly="true" TabIndex="12" ></asp:TextBox>
                                    </div>
                                </div>                             
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -30px;">
                <%---28 --%>
                <div id="innerbox_MidMain_Trans_new" style="height: 480px; width: 1094px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                            id="Page_A" runat="server"><span>General </span></a></li>
                        <li><a href="#page-7" runat="server">
                            <%--onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B"--%>
                        </a></li>
                        <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                            id="Page_C" runat="server" visible="false"><span>Gen -3</span></a></li>
                        <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                            id="Page_D" runat="server" visible="false"><span>Gen -4 </span></a></li>
                    </ol>
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 550px;
                            margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1150px; height: 150px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1150px">
                                    <div style="width: 1100px; height: 30px">
                                        <div id="txt_container_Transact_Main_l" style="width:272px">
                                            <div id="tag_label_transact_Src" style="width: 90px;">
                                                Exp-Voucher# :
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width:180px">
                                                <asp:TextBox ID="txtExpVoucherNo" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                                    ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="13" Width="180px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width:272px">
                                            <div id="tag_label_transact_Src" style="width: 110px;">
                                               &nbsp Expenses Date:
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 130px">
                                                <asp:TextBox ID="txtDate" runat="server" Width="130px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                    TabIndex="14"></asp:TextBox>
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
                                        <div id="txt_container_Transact_Main_l" style="width: 185px;">
                                            <div id="tag_label_transact_Src" style="width: 90px;">
                                                Total Amount:
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 85px">
                                                <asp:TextBox ID="txtTotalExpAmt" runat="server" Width="82px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                    ReadOnly="true" style="text-align:right" TabIndex="15"></asp:TextBox>                                                    
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 260px;">
                                            <div id="tag_label_transact_Src" style="width: 80px;">
                                                Narration :
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width:85px;">
                                                <asp:TextBox ID="txtCommNarration" runat="server" MaxLength="1000" CssClass="txtbox_none_Mid_transac_code"
                                                    Width="180px" TabIndex="16"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="width: 1100px; height: 30px">
                                        <div id="txt_container_Transact_Main_l" style="width:272px;">
                                            <div id="tag_label_transact_Src" style="width: 90px;">
                                                Exp Details  :
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 180px;">
                                           

                                                        <asp:TextBox ID="txtExpDetailsRow" CssClass="listtxt_transac_item_gen_notn" 
                                                            Text='<%# Bind("Exp_details") %>' runat="server" Height="15px" Width="180px"
                                                            MaxLength="100" Font-Size="12px" TabIndex="17"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 272px;">
                                            <div id="tag_label_transact_Src" style="width: 110px;">
                                                &nbsp Ref/Vou No
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 130px;">
                                                <asp:TextBox ID="txtRefVoucherNoRow" runat="server" Width="130px" MaxLength="30" CssClass="txtbox_none_Mid_transac_code" TabIndex="18"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div id="txt_container_Transact_Main_l" style="width: 195px;">
                                            <div id="tag_label_transact_Src" style="width: 50px;">
                                                Amount
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 135px;">
                                                <asp:TextBox ID="txtExpAmountRow" runat="server" Width="135px" MaxLength="30" CssClass="txtbox_none_Mid_transac_code" TabIndex="19" style="text-align:right" ></asp:TextBox>
                                            </div>
                                        </div>

                                        <div id="txt_container_Transact_Main_l" style="width: 180px;">
                                            <div id="tag_label_transact_Src" style="width: 80px;">
                                                &nbsp Payment
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 100px;">
                                                        <asp:DropDownList ID="ddlPaymentRow" MaxLength="20" runat="server" Width="100px" Height="22px"  
                                                            Font-Size="12px" CssClass=" txtbox_trans_exp_drawback" TabIndex="20" >
                                                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                                            <asp:ListItem Value="RTGS">RTGS</asp:ListItem>
                                                            <asp:ListItem Value="NEFT">NEFT</asp:ListItem>
                                                            <%--<asp:ListItem Value="Others">Others</asp:ListItem>--%>
                                                            <asp:ListItem Value="Not Paid">Not Paid</asp:ListItem>
                                                        </asp:DropDownList>
                                            </div>
                                        </div>

                                        <div id="txt_container_Transact_Main_l" style="width: 180px;">
                                            <div id="tag_label_transact_Src" style="width: 75px;">
                                                &nbsp Paid On
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 85px;">
                                                <asp:TextBox ID="txtPaidOnRow" runat="server" Width="85px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                    TabIndex="21"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtPaidOnRow"
                                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                    Enabled="True">
                                                </asp:MaskedEditExtender>
                                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPaidOnRow"
                                                    Format="dd/MM/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                            </div>
                                        </div>
                                    </div>
                                    <div style="width: 1100px; height: 30px">
                                        <div id="txt_container_Transact_Main_l" style="width: 272px;">
                                            <div id="tag_label_transact_Src" style="width: 90px;">
                                                Staff Name
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 180px;">

                                                    <asp:TextBox ID="txtStaffNameRow" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="180px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="22"></asp:TextBox>
                                                                                          
                                             </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 272px;">
                                            <div id="tag_label_transact_Src" style="width: 110px;">
                                               &nbsp  Given By
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 130px;">

                                                    <asp:TextBox ID="txtGivenByRow" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="130px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="23"></asp:TextBox>                                                                                           
                                             </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 197px;">
                                            <div id="tag_label_transact_Src" style="width: 50px;">
                                                Vendor
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 135px;">

                                                    <asp:TextBox ID="txtAssigneeRow" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="135px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="24"></asp:TextBox>                                                
                                                                                           
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 180px;">
                                            <div id="tag_label_transact_Src" style="width: 75px;">
                                                &nbsp Branch
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 100px;">

                                                    <asp:TextBox ID="txtVendorBranch" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="100px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="25"></asp:TextBox>                                                
                                                                                           
                                            </div>
                                        </div>
                                       
                                        <div id="txt_container_Transact_Main_l" style="width: 160px;">
                                            <div id="tag_label_transact_Src" style="width: 75px;">
                                               &nbsp  GSTIN
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 85px;">
                                                <asp:TextBox ID="txtVendorGSTIN" runat="server" Width="85px" MaxLength="30" CssClass="txtbox_none_Mid_transac_code" TabIndex="26" style="text-align:left"></asp:TextBox>
                                            </div>
                                        </div>
                                         </div>
                                        <div style="width: 1100px; height: 30px">
		                               <div id="txt_container_Transact_Main_l" style="width: 272px;">
<div id="tag_label_transact_Src" style="width: 90px;">
                                                  Remarks
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 180px;">
                                                <asp:TextBox ID="txtRemarksRow" runat="server" Width="180px" MaxLength="30" CssClass="txtbox_none_Mid_transac_code" TabIndex="27" style="text-align:left"></asp:TextBox>
                                            </div>
                                            </div>
                                             <div id="txt_container_Transact_Main_l" style="width: 272px;">
                                            <div id="tag_label_transact_Src" style="width: 110px;">
                                               &nbsp Classify Type
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 130px;">

                                                    <asp:DropDownList ID="ddlClassType" CssClass="listtxt_transac_item_gen_notn" Width="130px"
                                                    runat="server"  AutoPostBack="false"   TabIndex="28">
                                                   
                                                    
                                                </asp:DropDownList>  
                                             </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 205px;">
                                            <div id="tag_label_transact_Src" style="width: 110px;">
                                                 Taxable Amount
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 75px;">

                                                    <asp:TextBox ID="txtTaxAmount" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="75px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="29" style="text-align:right;" ></asp:TextBox>                                                                                           
                                             </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 152px;">
                                            <div id="tag_label_transact_Src" style="width: 70px;">
                                                CGST %
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 70px;">

                                                    <asp:TextBox ID="txtCgstpercentage" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="70px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="30"    onchange="javascript:Simple_Calculation_CGST();" ></asp:TextBox>                                                
                                                                                          
                                            </div>
                                        </div>
                                         <div id="txt_container_Transact_Main_l" style="width: 175px;">
                                            <div id="tag_label_transact_Src" style="width: 100px;">
                                               &nbsp CGST Amount 
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 70px;">

                                                    <asp:TextBox ID="txtCgstAmount" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="70px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="31" style="text-align:right;"></asp:TextBox>                                                
                                                                                           
                                            </div>
                                        </div>

                                    </div>
                                    
                                    <div style="width: 1100px; height: 30px;">
                                    

                                        
                                        <div id="txt_container_Transact_Main_l" style="width: 150px;">
                                            <div id="tag_label_transact_Src" style="width: 90px;">
                                               Cr/Dr
                                            </div>
                                            
                                       
                                  
                                 

<div id="txtcon-m_Exchange" style="width: 60px;">
                                                <asp:DropDownList ID="ddlCrDr" CssClass="listtxt_transac_item_gen_notn" Width="60px"
                                                    runat="server"  AutoPostBack="false"   TabIndex="32">
                                                  
                                                </asp:DropDownList>  
                                                                        
                                             </div>
                                         </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 180px;">
                                            <div id="tag_label_transact_Src" style="width: 80px;">
                                               &nbsp  Currency
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 80px;">
 
                                                    <asp:TextBox ID="txtCurrency" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="80px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="33"></asp:TextBox>                                                                                           
                                             </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 215px;">
                                            <div id="tag_label_transact_Src" style="width: 50px;">
                                                Ex-Rate
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 130px;">
                                                    
                                                    <asp:TextBox ID="txtExrate" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="130px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="34" onchange="javascript:calc_Foreignamt();"></asp:TextBox>                                                
                                                                                           
                                            </div>
                                        </div>
                                        
                                        
                                        <div id="txt_container_Transact_Main_l" style="width: 205px;">
                                            <div id="tag_label_transact_Src" style="width: 110px;">
                                                Foreign Amount
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 75px;">

                                                    <asp:TextBox ID="txtForeignamt" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="75px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="35" style="text-align:right;"></asp:TextBox>                                                
                                                                                           
                                            </div>
                                        </div>
                                         <div id="txt_container_Transact_Main_l" style="width: 152px;">
                                            <div id="tag_label_transact_Src" style="width: 70px;">
                                                SGST %
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 70px;">

                                                    <asp:TextBox ID="txtSGSTPercentage" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="70px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="36" onchange="javascript:Simple_Calculation_SGST();" ></asp:TextBox>                                                
                                                                                           
                                            </div>
                                        </div>

                                        <div id="txt_container_Transact_Main_l" style="width: 175px;">
                                            <div id="tag_label_transact_Src" style="width: 100px;">
                                                &nbsp SGST Amount
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 70px;">

                                                    <asp:TextBox ID="txtSGSTAmount" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="70px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="37" style="text-align:right;"></asp:TextBox>                                                
                                                                                           
                                            </div>
                                        </div>
		   
                                    
                                        
                                        </div>
                                        
                                         
                                         <div style="width: 1100px; height: 90px">

                                        <div id="txt_container_Transact_Main_l" style="width: 272px;">
                                            <div id="tag_label_transact_Src" style="width: 90px;">
                                                
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 180px;">
                                            
                                                    
                                             </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 272px;">
                                            <div id="tag_label_transact_Src" style="width: 110px;">
                                               
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 130px;">

                                                                                                                                    
                                             </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 205px;">
                                            <div id="tag_label_transact_Src" style="width: 55px;">
                                                
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 135px;">

                                                                                          
                                                                                           
                                            </div>
                                        </div>
                                        
                                         <div id="txt_container_Transact_Main_l" style="width: 152px;">
                                            <div id="tag_label_transact_Src" style="width: 70px;">
                                                IGST %
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 70px;">

                                                    <asp:TextBox ID="txtIGSTPercentage" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="70px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="38" onchange="javascript:Simple_Calculation_IGST();"></asp:TextBox>                                                
                                                                                           
                                            </div>
                                        </div>

                                        <div id="txt_container_Transact_Main_l" style="width: 175px;">
                                            <div id="tag_label_transact_Src" style="width: 100px;">
                                               &nbsp IGST Amount
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 70px;">

                                                    <asp:TextBox ID="txtIGSTAmount" CssClass="listtxt_transac_item_gen_notn" 
                                                             runat="server" Height="15px" Width="70px"
                                                            MaxLength="50" Font-Size="12px" TabIndex="39" style="text-align:right;"></asp:TextBox>                                                
                                                                                           
                                            </div>
                                        </div>
                                        

                                                  <div id="txt_container_Transact_Main_l" style="width: 130px;">
                                           <div id="txtcon-m_Exchange" style="width: 5px;">
                                           </div>
                                           <div id="tag_label_transact_Src" style="width: 125px;"> 
                                                <asp:FileUpload ID="FileUpload1" runat="server" TabIndex ="26" Visible="true" />
                                                <asp:Button ID="btnUploadRow" runat="server" Text="Upload" OnClick="btnUploadRow_Click" OnClientClick="return GetFileSize('FileUpload1');" Visible="true"/>
                                           </div>
                                        </div>   
                                                                         
<%--                                    </div>
                                    <div style="width: 1100px; height: 30px">--%>
                                        <div id="txt_container_Transact_Main_l" style="width: 225px; " >
                                            <div id="txtcon-m_Exchange" style="width: 10px;">
                                            <asp:CheckBox ID="chkImageFileRow" runat="server" TabIndex="27" Visible="true" OnClick ="jConfirm('Delete this File?', 'Expense Entry', function(r) 
                                            {
                                                var i = r + 'ok';
                                                if(i == 'trueok')
                                                {
                                                          
                                                document.getElementById('btnSingleFileDelete').click();            
                                                }
                                                else
                                                {
                                                }
        
                                             });return false;" />

                                        <asp:Button ID="btnSingleFileDelete" runat="server"  OnClick="btnSingleFileDelete_Click" CausesValidation="false"
                                            UseSubmitBehavior="false" 
                                            CssClass="dlete" Style="display: none;" />



                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 10px;">
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width:300px;">
                                                <asp:LinkButton ID="lbtnImageFileRow" runat="server" Text="View File" TabIndex="28" Visible="false" OnClick="lbtnImageFileRow_Download_Click">
	                                            </asp:LinkButton>
                                            </div>

<%--                     <asp:Button ID="btn_File_Delete" runat="server"  CausesValidation="false" style="display:none;"
                                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jConfirm('Delete this File?', 'Expense Entry', function(r) 
                                            {
                                                var i = r + 'ok';
                                                if(i == 'trueok')
                                                {
          
                                                document.getElementById('btn1').click();            
                                                }
                                                else
                                                {
                                                }
        
                                             });return false;" />--%>

<%--                                        <asp:Button ID="btn1" runat="server"  OnClick="btnDelete_Click" CausesValidation="false"
                                            UseSubmitBehavior="false" 
                                            CssClass="dlete" Style="display: none;" />
--%>




                                            <asp:HiddenField ID="hdn_FILE_PATH" runat="server" />
                                            <asp:HiddenField ID="hdn_ATTACHMENT_FILE" runat="server" />
                                            <asp:HiddenField ID="hdn_FILE_REF_NO" runat="server" />
                                            <asp:HiddenField ID="hdn_BROWSE_UPLOADED" runat="server" />
                                                                                                                                 
                                            <asp:HiddenField ID="hdn_FILE_IMAGE_NAME" runat="server" />


                                            <asp:HiddenField ID="hdn_Exp_SubID" runat="server"/>
                                            <asp:HiddenField ID="hdn_Exp_ID" runat="server" />

                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 500px;">
<%--                                            <div id="txtcon-m_Exchange" style="width:100px;">
                                                <asp:Button ID="btnSaveRow" runat="server" Text="Add Expense" OnClick="btnSaveRow_Click" OnClientClick="return GetFileSize('FileUpload1');"/>
                                            </div>--%>
                                            <div id="editbu">
                                                <asp:Button ID="btnNewRow"  runat="server" TabIndex="40" CssClass="new" OnClick="btnNewRow_Click"
                                                OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                                                UseSubmitBehavior="false" />
                                            </div>
                                            <div id="editbu">
                                                <asp:Button ID="btnSaveRow" runat="server" CssClass="save" OnClick="btnSaveRow_Click" ValidationGroup="dt"
                                                OnClientClick="return validation();" TabIndex="41" />
                                            </div>
                                            <div id="editbu">
                                                <asp:Button ID="btnUpdateRow" runat="server" CssClass="updates" ValidationGroup="dt"
                                                OnClick="btnUpdateRow_Click" Visible="true" TabIndex="41" OnClientClick="return validation();" />
                                            </div>
                                            <div id="editbu">
                                                <asp:Button ID="btnDeleteRow" runat="server" Visible="true" TabIndex="42" CausesValidation="false"
                                                   UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Particular Entry?', 'Particular Expense Head', function(r) {
                                                var i = r + 'ok';
                                                if(i == 'trueok')
                                                {
                                                document.getElementById('btnRow').click();
            
                                                }
                                                else {
                                                }
    
                                                });return false;" />
                                                <asp:Button ID="btnRow" runat="server" TabIndex="42" CausesValidation="false" UseSubmitBehavior="false"
                                                OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDeleteRow_Click"
                                                CssClass="dlete" Style="display: none;"  />
                                            </div>
                                        </div>
                                         

                                        </div>

                                 







                                    <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 205px;
                                        width: 1094px; margin-top: -10px; margin-left: -18px;">
                                        <asp:GridView ID="gv" runat="server" DataKeyNames="EXP_SUBID" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" 
                                            BackColor="WhiteSmoke" CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True" PageSize="10" AllowPaging="False"
                                             AllowSorting="True" OnRowDataBound="gv_RowDataBound" OnPageIndexChanging="gv_PageIndexChanging" 
                                             OnSelectedIndexChanged="gv_SelectedIndexChanged" 
                                             BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                                            HorizontalAlign="Left"   OnRowCreated="gv_RowCreated" ShowFooter="false" Style="overflow: auto;">
                                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            BorderWidth="1px" />
                                            <Columns>
                                            

                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>

                                        

                                        <asp:TemplateField HeaderText="SNo" ControlStyle-Width="2px">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="RowNumber" HeaderText="S.No"  >
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CR_DR" HeaderText="Cr/Dr" ControlStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left5" Width="10px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Exp_Details" HeaderText="Expenses Details" ControlStyle-Width="215px">
                                            <ItemStyle CssClass="column_style_left5" Width="215px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Ref_VoucherNo" HeaderText="Ref / Voucher #" ControlStyle-Width="75px">
                                            <ItemStyle CssClass="column_style_left5"  Width="75px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Exp_Amount" HeaderText="Amount" ControlStyle-Width="45px">
                                            <ItemStyle CssClass="column_style_left5"  Width="45px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="PaymentMode" HeaderText="Payment" ControlStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5"  Width="50px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="PAID_ON" HeaderText="Paid On" ControlStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left5"  Width="50px" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField DataField="STAFF_NAME" HeaderText="Staff Name" ControlStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left5"  Width="60px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="GivenBy" HeaderText="Given by" ControlStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left5"  Width="60px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Assignee" HeaderText="Assignee" ControlStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left5"  Width="60px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Remarks" HeaderText="Remarks" ControlStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left5"  Width="60px" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField DataField="FILE_IMAGE_NAME" HeaderText="File" ControlStyle-Width="115px">
                                            <ItemStyle CssClass="column_style_left5"  Width="115px" />
                                        </asp:BoundField>


                                        <asp:BoundField DataField="FILE_PATH" HeaderText="FILE_PATH"  >
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ATTACHMENT_FILE" HeaderText="ATTACHMENT_FILE"  >
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="FILE_REF_NO"  >
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>



                                        <asp:BoundField DataField="EXP_SUBID" HeaderText="EXP_SUBID" >   
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXP_ID" HeaderText="EXP_ID"  >
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>


                                        				
<asp:BoundField DataField="VENDOR_BRANCH" HeaderText="VENDOR_BRANCH"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="VENDOR_GSTIN" HeaderText="VENDOR_GSTIN"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="CR_DR" HeaderText="CR_DR"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="EX_RATE" HeaderText="EX_RATE"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="CURRENCY" HeaderText="CURRENCY"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="FOREIGN_AMOUNT" HeaderText="FOREIGN_AMOUNT"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="CLASSIFY_TYPE" HeaderText="CLASSIFY_TYPE"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="TAXABLE_AMOUNT" HeaderText="TAXABLE_AMOUNT"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="CGST_PERCENTAGE" HeaderText="CGST_PERCENTAGE"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="CGST_AMOUNT" HeaderText="CGST_AMOUNT"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="SGST_PERCENTAGE" HeaderText="SGST_PERCENTAGE"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="SGST_AMOUNT" HeaderText="SGST_AMOUNT"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="IGST_PERCENTAGE" HeaderText="IGST_PERCENTAGE"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>
<asp:BoundField DataField="IGST_AMOUNT" HeaderText="IGST_AMOUNT"><HeaderStyle CssClass="hideGridColumn" /><ItemStyle CssClass="hideGridColumn" /></asp:BoundField>





<%--                                            <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="SNo" HeaderStyle-Width="30px" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Center" Width="30px" />
                                                </asp:BoundField>



                                                <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="Expenses Details" HeaderStyle-HorizontalAlign="Center"
                                                    HeaderStyle-Width="135px">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Center" Width="135px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="c" HeaderText="Ref / Voucher #" HeaderStyle-HorizontalAlign="Left"
                                                    HeaderStyle-Width="75px">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="75px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="a" HeaderText="Amount" HeaderStyle-Width="45px" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="45px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="a" HeaderText="Payment" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="a" HeaderText="Paid On" HeaderStyle-Width="50px" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                                </asp:BoundField>
                                                
                                                <asp:BoundField DataField="a" HeaderText="Staff Name" HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />
                                                </asp:BoundField>
                                                
                                                
                                                

                                                <asp:BoundField DataField="d" HeaderText="Given by" HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="d" HeaderText="Assignee" HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="d" HeaderText="Remarks" HeaderStyle-Width="60px" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="d" HeaderText="File" HeaderStyle-Width="115px" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="115px" />
                                                </asp:BoundField>--%>

                                                <%--<asp:BoundField DataField="g" HeaderStyle-Width="90px" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                        </asp:BoundField>--%>
                                        </Columns>
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                                NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                        <PagerStyle CssClass="pager" />
                                    <EmptyDataTemplate>
                                        NO RECORD FOUND
                                    </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                    <style type="text/css">
                                        input.underlined
                                        {
                                            border: solid 1px #000;
                                        }
                                    </style>
                                    
                                    <%--------------------------------------Row End-----------------------------------------%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-------------------------------------------------------------------------------%>
            </div>
            <%-- --------------------Test Start----------------------------%>
            <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;margin-top:-15px">
                <div id="innerbox_transac_bot_inn" >
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click1" TabIndex="361" Visible="false" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate_Exp_V2();"
                            TabIndex="32" OnClick="btnSave_Click" CommandName="s" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate_Exp_V2();" TabIndex="32" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="33" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this expenses?', 'Expenses', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="33" OnClick="btnDelete_Click" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                            id="btnCancel" tabindex="34" Style="display: none;">
                    </div>
                    <div id="editbu" style="width: 10px;">
                    </div>
                    <div id="editbu" style="padding-top: 5px;">
                        <asp:Button ID="btnrpt" runat="server" TabIndex="35" Text="Get Bill" OnClientClick="return GST_Import_Billing_Job_Rpt('B');" />
                        <%--OnClientClick="return Import_Billing_Job_Rpt('B');"--%>
                    </div>
                </div>
            </div>
            <%-- --------------------Test End----------------------------%>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
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
    
     <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });


        function close_button() {
            document.getElementById("General").click();
        }
        

    </script>

<script type="text/javascript">
    function calc_Foreignamt() {
            
        var TExrate = document.getElementById("txtExrate").value;
        var TExpAmount = document.getElementById("txtExpAmountRow").value;
        var TForeignamt;
                   
         TForeignamt = TExpAmount / TExrate;
         //TForeignamt = Math.round(TForeignamt);
         TForeignamt = TForeignamt.toFixed(2);

         document.getElementById("txtForeignamt").value = TForeignamt;

    }  
</script>
    <script type="text/javascript">
        function Simple_Calculation_CGST() 
        {
            var Taxamt = document.getElementById("txtTaxAmount").value;
            var Percentage = document.getElementById("txtCgstpercentage").value;
            var FinalAmount = (Taxamt * Percentage) / 100;
            FinalAmount = Math.round(FinalAmount);
            FinalAmount = FinalAmount.toFixed(2);
            //alert('FinalAmount ' + FinalAmount);
            document.getElementById("txtCgstAmount").value = FinalAmount;


            document.getElementById("txtSGSTPercentage").value = Percentage;
            document.getElementById("txtSGSTAmount").value = FinalAmount;

            document.getElementById("txtIGSTPercentage").value = '0.00';
            document.getElementById("txtIGSTAmount").value = '0.00';

            var TCurrency = document.getElementById("txtCurrency").value;
            var TExrate = document.getElementById("txtExrate").value;
            var TExpAmount = document.getElementById("txtExpAmountRow").value;
            var TForeignamt;
            if (TCurrency == "" && TExrate == "") 
            {
                document.getElementById("txtCurrency").value = "INR";
                document.getElementById("txtExrate").value = "1.00";
            }
            calc_Foreignamt();
        }  
     </script>
     <script type="text/javascript">
         function Simple_Calculation_SGST() {


             var Taxamt = document.getElementById("txtTaxAmount").value;
             var Percentage = document.getElementById("txtSGSTPercentage").value;
             var FinalAmount = (Taxamt * Percentage) / 100;
             FinalAmount = Math.round(FinalAmount);
             FinalAmount = FinalAmount.toFixed(2);
             //alert('FinalAmount ' + FinalAmount);
             document.getElementById("txtSGSTAmount").value = FinalAmount;


             document.getElementById("txtCgstpercentage").value = Percentage;
             document.getElementById("txtCgstAmount").value = FinalAmount;

             document.getElementById("txtIGSTPercentage").value = '0.00';
             document.getElementById("txtIGSTAmount").value = '0.00';

             var TCurrency = document.getElementById("txtCurrency").value;
             var TExrate = document.getElementById("txtExrate").value;
             var TExpAmount = document.getElementById("txtExpAmountRow").value;
             var TForeignamt;
             if (TCurrency == "" && TExrate == "") {
                 document.getElementById("txtCurrency").value = "INR";
                 document.getElementById("txtExrate").value = "1.00";
             }
             calc_Foreignamt();

         }  
     </script>
     <script type="text/javascript">
         function Simple_Calculation_IGST() {


             var Taxamt = document.getElementById("txtTaxAmount").value;
             var Percentage = document.getElementById("txtIGSTPercentage").value;
             var FinalAmount = (Taxamt * Percentage) / 100;
             FinalAmount = Math.round(FinalAmount);
             FinalAmount = FinalAmount.toFixed(2);
             //alert('FinalAmount ' + FinalAmount);
             document.getElementById("txtIGSTAmount").value = FinalAmount;


             document.getElementById("txtCgstpercentage").value = '0.00';
             document.getElementById("txtCgstAmount").value = '0.00';

             document.getElementById("txtSGSTPercentage").value = '0.00';
             document.getElementById("txtSGSTAmount").value = '0.00';

             var TCurrency = document.getElementById("txtCurrency").value;
             var TExrate = document.getElementById("txtExrate").value;
             var TExpAmount = document.getElementById("txtExpAmountRow").value;
             var TForeignamt;
             if (TCurrency == "" && TExrate == "") {
                 document.getElementById("txtCurrency").value = "INR";
                 document.getElementById("txtExrate").value = "1.00";
             }
             calc_Foreignamt();

         }  
     </script>

    <%--<script type="text/javascript">
        $(document).ready(function () {


            $('#txtImportername').focus(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtImportername').change(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtImportername').keyup(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtImportername').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });

        function Item_desc(val) {

            var data = val;
            if (data == '') {
                $('#txtImportername').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txtImportername').val(after);

                $('#hdimp').val(after);
                $('#hd_Brslno').val(before);

            }
            else {

            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtimportername_Other').focus(function () {

                var data = $(this).val();
                Item_desc_other(data);

            });
            $('#txtimportername_Other').change(function () {

                var data = $(this).val();
                Item_desc_other(data);

            });
            $('#txtimportername_Other').keyup(function () {

                var data = $(this).val();
                Item_desc_other(data);

            });
            $('#txtimportername_Other').keydown(function () {

                var data = $(this).val();
                Item_desc_other(data);

            });
        });

        function Item_desc_other(val) {

            var data = val;
            if (data == '') {
                $('#txtimportername_Other').val('');
                $('#txt_branch_No').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txtimportername_Other').val(after);
                $('#Hd_Other_Branch_no').val(before);
                $('#txt_branch_No').val(before);
            }
            else {
            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            Tax_Cal();
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('[id*=ddl_tax_nontax]').focus(function () {

                Tax_Cal();
            });
            $('[id*=ddl_tax_nontax]').change(function () {
                Tax_Cal();
            });
            $('[id*=ddl_tax_nontax]').keyup(function () {

                Tax_Cal();
            });
            $('[id*=ddl_tax_nontax]').keydown(function () {

                Tax_Cal();

            });
            //----------------------GST--s------------------------------------------
            $('[id*=ddl_CUR]').focus(function () {

                Tax_Cal();

            });
            $('[id*=ddl_CUR]').change(function () {
                Tax_Cal();
            });
            $('[id*=ddl_CUR]').keyup(function () {

                Tax_Cal();
            });
            $('[id*=ddl_CUR]').keydown(function () {

                Tax_Cal();

            });
            //--------------------------------------------------
            $('[id*=txt_Ex_Rate]').focus(function () {

                Tax_Cal();

            });
            $('[id*=txt_Ex_Rate]').change(function () {
                Tax_Cal();
            });
            $('[id*=txt_Ex_Rate]').keyup(function () {

                Tax_Cal();
            });
            $('[id*=txt_Ex_Rate]').keydown(function () {

                Tax_Cal();

            });

            //----------------------GST--e------------------------------------------

            //-----------------------------------------------------------
            $('[id*=chk_inv]').focus(function () {

                Tax_Cal();

            });
            $('[id*=chk_inv]').change(function () {

                Tax_Cal();
            });
            $('[id*=chk_inv]').keyup(function () {

                Tax_Cal();

            });
            $('[id*=chk_inv]').keydown(function () {

                Tax_Cal();

            });

            //------------------------------------------------------------

            $('[id*=txtamt]').focus(function () {

                Tax_Cal();
            });
            $('[id*=txtamt]').change(function () {

                Tax_Cal();

            });
            $('[id*=txtamt]').keyup(function () {

                Tax_Cal();

            });
            $('[id*=txtamt]').keydown(function () {

                Tax_Cal();

            });
            //------------------------------------------------------------

            $('[id*=txtch_name]').focus(function () {

                Tax_Cal();

            });
            $('[id*=txtch_name]').change(function () {

                Tax_Cal();

            });
            $('[id*=txtch_name]').keyup(function () {

                Tax_Cal();

            });
            $('[id*=txtch_name]').keydown(function () {

                Tax_Cal();

            });

            //-----------------------------------------------------------------------------

            $('[id*=txtqty]').focus(function () {

                Tax_Cal();

            });
            $('[id*=txtqty]').change(function () {

                Tax_Cal();

            });
            $('[id*=txtqty]').keyup(function () {

                Tax_Cal();

            });
            $('[id*=txtqty]').keydown(function () {

                Tax_Cal();
            });
            //------------------------------------------------------------------------

            $('[id*=txtunit_price]').focus(function () {

                Tax_Cal();

            });
            $('[id*=txtunit_price]').change(function () {

                Tax_Cal();

            });
            $('[id*=txtunit_price]').keyup(function () {

                Tax_Cal();

            });
            $('[id*=txtunit_price]').keydown(function () {

                Tax_Cal();

            });

            //--------------------CGST---------------------------------------
            $('[id*=txtCGST_RATE]').focus(function () {

                if (selected.val() == 'L') {
                    Tax_Cal();
                }

            });
            $('[id*=txtCGST_RATE]').change(function () {

                Tax_Cal();

            });
            $('[id*=txtCGST_RATE]').keyup(function () {

                Tax_Cal();

            });
            $('[id*=txtCGST_RATE]').keydown(function () {

                Tax_Cal();

            });

            //-----------------2--------------------------------------------------
            $('[id*=txtSGST_RATE]').focus(function () {

                if (selected.val() == 'L') {
                    Tax_Cal();
                }

            });
            $('[id*=txtSGST_RATE]').change(function () {

                Tax_Cal();

            });
            $('[id*=txtSGST_RATE]').keyup(function () {

                Tax_Cal();

            });
            $('[id*=txtSGST_RATE]').keydown(function () {

                //if (selected.val() == 'L') {
                // Tax_Cal();
                // }
                Tax_Cal();

            });

            //------------------------I-----------------------------------
            $('[id*=txtIGST_RATE]').focus(function () {

                if (selected.val() == 'L') {
                    Tax_Cal();
                }

            });
            $('[id*=txtIGST_RATE]').change(function () {

                Tax_Cal();

            });
            $('[id*=txtIGST_RATE]').keyup(function () {

                Tax_Cal();

            });
            $('[id*=txtIGST_RATE]').keydown(function () {

                Tax_Cal();

            });

            //-------------------2--------------------------
            $('[id*=txtIGST_AMT]').focus(function () {

                if (selected.val() == 'L') {
                    Tax_Cal();
                }

            });
            $('[id*=txtIGST_AMT]').change(function () {

                Tax_Cal();

            });
            $('[id*=txtIGST_AMT]').keyup(function () {

                Tax_Cal();

            });
            $('[id*=txtIGST_AMT]').keydown(function () {

                Tax_Cal();

            });


            //-----------------------------------------------------------

        });

    </script>
    <script type="text/javascript">

        function Tax_Cal() {

            var txtexpamt = $("[id*=txt_Ex_Rate]")

            var sum_expAmt = 0;

            var sum_N = 0;
            var sum_R = 0;

            var Tot_L_O = 0;
            var counter = 0;



            $("#<%=gv_Chg_Details.ClientID%>").each(function (index) {
                if ($(this).is(':checked')) {



                    if (!isNaN(txtamt[index].value) && txtamt[index].value.length != 0) {
                        if (tax_type[index].value == 'T') {

                            if (ddl_CUR[index].value != 'INR') {
                                txtamt[index].value = txtqty[index].value * txtunit_price[index].value * txt_Ex_Rate[index].value;
                            }
                            else {
                                txt_Ex_Rate[index].value = "1"
                                txtamt[index].value = txtqty[index].value * txtunit_price[index].value;
                            }

                            if (GST_State.val() == 'L') {

                                CGST_AMT[index].value = (parseFloat(txtamt[index].value) * CGST_Rate[index].value / 100.00).toFixed(2);
                                SGST_AMT[index].value = (parseFloat(txtamt[index].value) * SGST_Rate[index].value / 100.00).toFixed(2);

                                var aa = '0';
                                aa = parseFloat(CGST_AMT[index].value) + parseFloat(SGST_AMT[index].value);

                                IGST_AMT[index].value = '0';
                                IGST_RATE[index].value = '0';

                                Tot_L_O += parseFloat(aa)

                            }
                            else {

                                CGST_AMT[index].value = '0';
                                SGST_AMT[index].value = '0';
                                CGST_Rate[index].value = '0';
                                SGST_Rate[index].value = '0';

                                IGST_AMT[index].value = (parseFloat(txtamt[index].value) * IGST_RATE[index].value / 100.00).toFixed(2)

                                Tot_L_O += parseFloat(IGST_AMT[index].value)
                            }

                            sum_T += parseFloat(txtamt[index].value)
                        }
                        else if (tax_type[index].value == 'N' || tax_type[index].value == 'E') {

                            if (ddl_CUR[index].value != 'INR') {
                                txtamt[index].value = (txtqty[index].value * txtunit_price[index].value * txt_Ex_Rate[index].value).toFixed(2);
                            }
                            else {
                                txt_Ex_Rate[index].value = "1"
                                txtamt[index].value = (txtqty[index].value * txtunit_price[index].value).toFixed(2);
                            }

                            sum_N += parseFloat(txtamt[index].value)

                            CGST_AMT[index].value = '0';
                            SGST_AMT[index].value = '0';
                            CGST_Rate[index].value = '0';
                            SGST_Rate[index].value = '0';
                            IGST_AMT[index].value = '0';
                            IGST_RATE[index].value = '0';

                        }
                        else if (tax_type[index].value == 'P') {

                            if (ddl_CUR[index].value != 'INR') {
                                txtamt[index].value = (txtqty[index].value * txtunit_price[index].value * txt_Ex_Rate[index].value).toFixed(2);
                            }
                            else {
                                txt_Ex_Rate[index].value = "1"
                                txtamt[index].value = txtqty[index].value * txtunit_price[index].value;
                            }

                            CGST_AMT[index].value = (parseFloat(txtamt[index].value) * CGST_Rate[index].value / 100.00).toFixed(2);
                            SGST_AMT[index].value = (parseFloat(txtamt[index].value) * SGST_Rate[index].value / 100.00).toFixed(2);

                            //------------------

                            IGST_AMT[index].value = (parseFloat(txtamt[index].value) * IGST_RATE[index].value / 100.00).toFixed(2)

                            var aa = '0';
                            aa = parseFloat(CGST_AMT[index].value) + parseFloat(SGST_AMT[index].value) + parseFloat(IGST_AMT[index].value);

                            Tot_L_O += parseFloat(aa)

                            sum_T += parseFloat(txtamt[index].value)
                        }
                        else if (tax_type[index].value == 'R') {

                            if (ddl_CUR[index].value != 'INR') {
                                txtamt[index].value = (txtqty[index].value * txtunit_price[index].value * txt_Ex_Rate[index].value).toFixed(2);
                            }
                            else {
                                txt_Ex_Rate[index].value = "1"
                                txtamt[index].value = (txtqty[index].value * txtunit_price[index].value).toFixed(2);
                            }

                            if (GST_State.val() == 'L') {

                                var aa = '0';
                                var M = '0';
                                var N = '0';

                                M = (parseFloat(txtamt[index].value) * CGST_Rate[index].value / 100.00).toFixed(2);
                                N = (parseFloat(txtamt[index].value) * SGST_Rate[index].value / 100.00).toFixed(2);

                                aa = parseFloat(M) + parseFloat(N);

                                CGST_AMT[index].value = '0';
                                SGST_AMT[index].value = '0';
                                IGST_AMT[index].value = '0';
                                IGST_RATE[index].value = '0';

                                sum_R += parseFloat(aa)

                            }
                            else {

                                var X = '0';

                                CGST_AMT[index].value = '0';
                                SGST_AMT[index].value = '0';
                                CGST_Rate[index].value = '0';
                                SGST_Rate[index].value = '0';
                                IGST_AMT[index].value = '0';

                                //IGST_AMT[index].value = (parseFloat(txtamt[index].value) * IGST_RATE[index].value / 100.00)
                                X = (parseFloat(txtamt[index].value) * IGST_RATE[index].value / 100.00).toFixed(2);

                                sum_R += parseFloat(X);
                            }

                            sum_T += parseFloat(txtamt[index].value)
                        }

                        //------------------------------------------------------------
                    }
                    counter++;
                }
            });

            $('#txtnon_tax_amt').val(sum_N.toFixed(2));
            $('#txttax_amt').val(sum_T.toFixed(2));
            $('#txt_tot_Rev_Amt').val(sum_R.toFixed(2));

            $('#txt_total_tax_amt').val(Tot_L_O.toFixed(2));
            document.getElementById("txt_total_amt_With_tax").value = (parseFloat(sum_T) + parseFloat(Tot_L_O)).toFixed(2);
            document.getElementById("txt_grand_total").value = Math.round((parseFloat(sum_T) + parseFloat(Tot_L_O) + parseFloat(sum_N.toFixed(2))).toFixed(2));

        }

    </script>--%>
</body>
</html>
