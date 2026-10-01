<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurchaseEntry.aspx.cs"    Inherits="Billing_Imp_PurchaseEntry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Purchase Entry</title>
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
    <script type="text/javascript">
//        $(function () {
//            $("[id*=gvdetails]").find("[id*=drpDrcr]").focusout(function () {
//                var row = $(this).closest("tr");
//                var value = $(this).val();
//                if (value == "DR") {
//                    row.find("[id*=txtgCredit]").attr("Disabled", "true");
//                    row.find("[id*=txtgDebit]").attr("Enabled", "true");
//                }
//                else if (value == "CR") {

//                    row.find("[id*=txtgCredit]").attr("Enabled", "true");
//                   
//                    row.find("[id*=txtgDebit]").attr("Disabled", "true");
//                }
//            });
//        });
//        $(function () {
//            $("[id*=gvdetails]").find("[id*=drpDrcr]").change(function () {
//                var row = $(this).closest("tr");
//                var value = $(this).val();
//                if (value == "CR") {
//                    row.find("[id*=txtgDebit]").attr("Disabled", "true");
//                }
//            });
//        });
</script>
<script type="text/javascript" language="javascript">
    function EnableTextbox(ddl, txtD, txtC) {
        var ddl_PaymentMethod = document.getElementById(ddl);
        var txt_Debit = document.getElementById(txtD);
        var txt_Credit = document.getElementById(txtC);
        var ddl_Value = ddl_PaymentMethod.value;
        if (ddl_Value == "CR") {
            txt_Debit.disabled = true;
            txt_Credit.disabled = false;
        }
        else if (ddl_Value == "DR") {
            txt_Debit.disabled = false;
            txt_Credit.disabled = true;
        } 
    }
//$("[id*=gvdetails]").find("[id*=drpDrcr]").mousedown(function () {
//                var row = $(this).closest("tr");
//                var value = $(this).val();
//                if (value == "DR") {
//                    row.find("[id*=txtgCredit]").attr("Disabled", "true");
//                    row.find("[id*=txtgDebit]").attr("Enabled", "true");
//                }
//                else if (value == "CR") {
//                    row.find("[id*=txtgDebit]").attr("Disabled", "true");
//                    row.find("[id*=txtgCredit]").attr("Enabled", "true");

//                        }

//    }
    $(document).ready(function () {
        var today = new Date();
        $('.datepicker').datepicker({
            format: 'dd-mm-yyyy',
            autoclose: true,
            endDate: "today",
            maxDate: today
        }).on('changeDate', function (ev) {
            $(this).datepicker('hide');
        });


        $('.datepicker').keyup(function () {
            if (this.value.match(/[^0-9]/g)) {
                this.value = this.value.replace(/[^0-9^-]/g, '');
            }
        });
    });
//    function calculate() {
//        var amt = document.getElementById('txtbillamount').value;
//        var exrate = document.getElementById('txtExrate').value;
//        var total = amt * exrate;
//        var txttoal = document.getElementById('txtTotalamtininr');
//        txttoal.value = total;
//    }
//    function conv() {
//        var billamt = document.getElementById('txtbillamount').value;
//       billamt.value= parseFloat(billamt); }
////    $("#txtExrate").change(function () {
////        calculate();
//    //    }); 
//    $(document).ready(function () {
//        if ($('#txtExrate').val().length > 0) {
//            calculate();
//        }
    //    });


    </script>
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
    <style>
        div.fileinputs {
            position: relative;
        }

        div.fakefile {
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 1;
        }

        input.file {
            position: relative;
            text-align: right;
            -moz-opacity: 0;
            filter: alpha(opacity: 0);
            opacity: 0;
            z-index: 2;
        }
 </style>

</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>--%>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain" style="height: 150px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                        Purchase Entry
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 80px;">
                            Generate Bill:
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 200px;">
                            <asp:RadioButtonList ID="Rd_Bill_Type" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="true" >
                                <asp:ListItem Text="Local State" Value="L" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Other State" Value="O"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <%--<div id="tag_label_transact_Src" style="width: 110px;">
                                   Type of Invoice:
                                </div>--%>
                        
                    </div>
                    <%--<div id="verslic">
                    </div>--%>
                    <%--<div id="tag_transac_lft_in2">
                        <span runat="server" id="WK" visible="false">
                            <div id="tag_label_transaction_popup_gen">
                                Working Period</div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlWorkingPeriod_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </span>
                    </div>--%>
                    <%-- <div id="popupwindow_closebut_right_new">
                      <span id="F" runat="server"><input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 
                      <span id="T" runat="server">  <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span> 
                    </div>--%>
                    <%--<div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>--%>
                      <div id="popupwindow_closebut_right_new">
                  <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                  </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px;height:120px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px;height:120px;">
                        <div id="tag_transact_lft_in1" style="width: 1100px; height:120px;">                            
                            <div style="width: 1400px; height: 40px">
                                <div id="txt_container_Transact_Main_l" style="width:210px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Voucher No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:105px;" >
                                        <asp:TextBox ID="txtVoucherno" CssClass="txtbox_none_Mid_transac_code" Enabled="false" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width:1100px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                           Voucher Date
                                    </div>
                                     <div id="txtcon-m_Exchange" style="width:150px;">
                                         <asp:TextBox ID="txtVoucherdate" CssClass="txtbox_none_Mid_transac_code" Width="140px" runat="server"></asp:TextBox>
                                         <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtVoucherdate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtVoucherdate"
                                PopupButtonID="txtJobDate" Enabled="true" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                     </div>
                                     <div id="tag_label_transact_Src" style="width: 85px;">
                                        Vendor Name 
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:290px;" >
                                        <asp:TextBox ID="txtVendorname" CssClass=" txtbox_none_Mid_transac_code Vendorname"  Width="280px" TabIndex="2" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 120px;">
                                        Vendor Branch 
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px">
                                        <asp:TextBox ID="txtVendorbranch" onfocusout="vendordetail()" CssClass="validate[required] txtbox_none_Mid_transac_code " AutoPostBack="false" OnTextChanged="txtVendorbranch_TextChanged" Width="160px" TabIndex="3" runat="server"></asp:TextBox>
                                    </div>
                                    
                                </div>
                                
                                <div  id="txt_container_Transact_Main_l"  style="width: 1450px" >
                                    
                                <%--</div>
                                <div id="txt_container_Transact_Main_l" style="width:1620px;">--%>
                                    
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                       Vendor State 
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px">
                                        <asp:TextBox ID="txtVendorstate" CssClass="txtbox_none_Mid_transac_code" Enabled="false" TabIndex="4" runat="server"></asp:TextBox>
                                    </div>
                                    
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                       GSTN 
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px">
                                        <asp:TextBox ID="txtGstn" CssClass="txtbox_none_Mid_transac_code" Enabled="false" Width="140px" TabIndex="5" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 85px;">
                                       GSTN Type
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px">
                                        <asp:TextBox ID="txtGstntype" CssClass="txtbox_none_Mid_transac_code" Enabled="false"  TabIndex="6" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                       Country 
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px">
                                        <asp:TextBox ID="txtCountry" CssClass="txtbox_none_Mid_transac_code" Enabled="false" TabIndex="7" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                       Narration 
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 200px">
                                        <asp:TextBox ID="txtNarration" CssClass=" txtbox_none_Mid_transac_code" Width="307px" Height="20px" TabIndex="8" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                 
                           
                           <div style="width: 1400px; height: 30px">                             
                                <%--<div id="txt_container_Transact_Main_l" style="width: 220px;">--%>                           
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Vendor Bill No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txtVendorbillno" CssClass="validate[required] txtbox_none_Mid_transac_code" TabIndex="9" runat="server"></asp:TextBox>
                                    </div>
                                <%--</div>
                                <div id="txt_container_Transact_Main_l" style="width: 220px;"> --%>          
                                <div id="tag_label_transact_Src" style="width: 100px;">
                                         Bill Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtBilldate" CssClass="validate[required] txtbox_none_Mid_transac_code" Width="140px" onfocusout="isDate()" TabIndex="10" runat="server"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtBilldate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBilldate"
                                PopupButtonID="txtJobDate" Enabled="true" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                    </div>                
                                    <div id="tag_label_transact_Src" style="width: 85px;">
                                    Bill Amount
 
                                    </div>
                                    <div id="txtcon-m_Exchange"  style="width: 110px; ">
                                        <asp:TextBox ID="txtbillamount"  runat="server" style="text-align:right;"  
                                        CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"
                                        TabIndex="11" MaxLength="50"  ></asp:TextBox>
                                        
                                    </div>
                                <%--</div>                                                                                      
                             
                             
                                <div id="txt_container_Transact_Main_l" style="width: 300px;display: none;"  >--%> 
                                                          
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Currency
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txtInvoiceCurrency"  runat="server" ClientIDMode="Static"  TabIndex="12"   onkeypress="return char1(event)"  MaxLength="3" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_code" ></asp:TextBox>
                                    </div>
                                <%--</div>
                                <div id="txt_container_Transact_Main_l" style="width: 330px;display: none;"> --%>                          
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                       Ex Rate
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txtExrate"  runat="server" Enabled="true" onfocusout="tap()"  TabIndex="13"
                                         MaxLength="50" CssClass="validate[required] txtbox_none_Mid_transac_code" ></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 120px;">
                                       Total Amount In INR
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtTotalamtininr" Enabled="true"  runat="server" 
                                        style="text-align:right;"  
                                        CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"
                                          MaxLength="50"  ></asp:TextBox>
                                    </div>
                                </div>                             
                           <%--</div>--%>
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
            
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -30px;">
                <%---28 --%>
                <div id="innerbox_MidMain_Trans_new" style="height: 340px; width: 1300px; margin-left: -16px; overflow-y:scroll; overflow-x:scroll;
                    margin-top: -5px;">
                    
                                    
                                    <%--<div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 530px;
                                        width: 1094px; margin-top: -10px; margin-left: -18px;">--%>

                                        <asp:GridView ID="gvdetails" runat="server" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false" 
                                            BackColor="WhiteSmoke" CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True" 
                                             AllowSorting="True" OnRowCommand="gvdetails_RowCommand"  OnRowDataBound="OnRowDataBound"
                                               
                                             BorderColor="#C8C8C8" BorderStyle="Solid" 
                                            HorizontalAlign="Left"    ShowFooter="true" Style="overflow: auto;">
                                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            BorderWidth="1px" />
                                            <Columns>
                                          
                                            <asp:TemplateField HeaderText="SNo" HeaderStyle-Width="30px" >
                        <ItemTemplate>
                            <asp:TextBox ID="txtgSLNo" runat="server" Text='<%# Eval("SNo") %>'  Width="30px"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="30px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Imp_Exp">
                        <ItemTemplate>
                            <%--<asp:TextBox ID="txtgImpExp" runat="server" Text='<%#Eval("Imp/Exp") %>' Width="60px"></asp:TextBox>--%>
                            <asp:DropDownList ID="drpImpexp" Width="45px" SelectedValue='<%# Eval("Imp_Exp") %>' AppendDataBoundItems="true"  runat="server" >
                            <asp:ListItem>---</asp:ListItem>
                            <asp:ListItem >Imp</asp:ListItem>
                            <asp:ListItem >Exp</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="File_Ref_No" HeaderStyle-Width="90px">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgFileRefNo" runat="server"    AutoPostBack="false"  onfocusout="cusname(this)" Text='<%# Eval("File_Ref_No") %>'   Width="120px" CssClass=" Fileref"></asp:TextBox>
                            
                         <asp:HiddenField ID="hdngFileRefNo" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="90px" />
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgDate" Enabled="true" runat="server" Text='<%# Eval("Date") %>'  Width="80px"></asp:TextBox>
                             <%--<cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtgDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>--%>
                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtgDate"
                                PopupButtonID="txtgDate" Enabled="true" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DR_CR">
                        <ItemTemplate>
                            <%--<asp:TextBox ID="txtgDRCR" runat="server" Text='<%#Eval("DR/CR") %>' Width="60px"></asp:TextBox>--%>
                            <asp:DropDownList ID="drpDrcr" DataValueField="DRCR" Width="40px" onchange="drcr(this)"  Name="drpDrcr" 
                                SelectedValue='<%# Eval("DR_CR") %>' AppendDataBoundItems="true"  runat="server" >
                                <%--<asp:ListItem>---</asp:ListItem>--%>
                            <asp:ListItem Value="DR">DR</asp:ListItem>
                            <asp:ListItem Value="CR">CR</asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Customer_Name">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgCusName" runat="server" Enabled="true" Text='<%# Eval("Customer_Name") %>' Width="120px"  ></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="90px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Charge_Head">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgCharHead" Width="120px" runat="server"   AutoPostBack="false"  onblur="Calculation(this)"
                             Text='<%# Eval("Charge_Name") %>' CssClass=" Search" ></asp:TextBox>
                            <%--<asp:TextBox ID="txtgCharHead"  Text='<%# Bind("Charge_Head") %>' runat="server" onblur="Calculation(this)" CssClass="Search"                                      
                                            Height="20px" Width="152px" Font-Size="12px"  ></asp:TextBox>--%>
                            <asp:HiddenField ID="hfCustomerId" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gst_Type">
                        <ItemTemplate>
                            <%--<asp:TextBox ID="txtgSaccode" runat="server" Enabled="true" Text='<%# Eval("SAC_Code") %>' TabIndex="21" Width="60px"></asp:TextBox>--%>
                            <asp:DropDownList ID="ddl_Gst_type" runat="server" SelectedValue='<%# Eval("GST_TYPE") %>'  Width="90px">
                            <asp:ListItem Value="GST_TYPE_01">Imports exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_02">Imports  Nil rated</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_03">Imports taxable</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_04">interstate purchase exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_05">Interstate purchase from unregistered dealer - taxable</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_06">Interstate purchase from unregistered dealer - exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_07">Interstate purchase from unregistered dealer - Nil rated</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_08">Interstate purchase from unregistered dealer - services</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_09">Interstate purchase taxable</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_10">Interstate purchase Nil rated</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_11">Intrastate PURCHASE deemed exports - Exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_12"> Intrastate PURCHASE deemed exports - taxable</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_13">Intrastate PURCHASE deemed exports - Nil rated</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_14">PURCHASE deemed exports - exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_15">PURCHASE deemed exports - taxable</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_16">PURCHASE deemed exports - Nil rated</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_17">purchase exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_18">purchase From composition dealer</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_19">PURCHASE from Sez - exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_20">PURCHASE from Sez - LUT/BOND</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_21">PURCHASE from Sez - NIL RATED</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_22">PURCHASE from Sez - TAXABLE</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_23">PURCHASE from Sez (Without bill of entry) -exempt</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_24">PURCHASE from Sez (Without bill of entry) -NIL RATED</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_25">PURCHASE from Sez (Without bill of entry)- TAXABLE</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_26">PURCHASE FROM UNREGISTERED DEALER -EXEMPT</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_27">PURCHASE FROM UNREGISTERED DEALER - NIL RATED</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_28">PURCHASE FROM UNREGISTERED DEALER - TAXABLE</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_29"> PURCHASE NIL RATED</asp:ListItem>
                            <asp:ListItem Value="GST_TYPE_30">PURCHASE TAXBLE </asp:ListItem>
                            </asp:DropDownList>
                        </ItemTemplate>
                        <ItemStyle Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tax_Rate">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgTaxrate" Enabled="true" runat="server"
                             style="text-align:right;" 
                                        CssClass="validate[custom[number]] "
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"
                                         Text='<%# Eval("Tax_Rate","{0:0.00}") %>'  Width="60px"></asp:TextBox>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Credit">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgCredit" runat="server"  
                            style="text-align:right;"  
                                        CssClass="validate[custom[number]] creditgst" onfocusout="gst(this)"
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%# Eval("Credit","{0:0.00}") %>' Width="85px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="60px" />
                         <FooterTemplate>
                             <asp:TextBox ID="txtcredittotal" runat="server" Enabled="false"  Width="85px"></asp:TextBox>
                         </FooterTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="Debit">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgDebit" runat="server"  style="text-align:right;"  onfocusout="gst(this)"
                                        CssClass="validate[custom[number]] debitgst" 
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%#Eval("Debit","{0:0.00}") %>' Width="85px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="60px" />
                         <FooterTemplate>
                             <asp:TextBox ID="txtdebittotal" runat="server" Enabled="false" Width="85px"></asp:TextBox>
                         </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CGST">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgCgst" runat="server" Enabled="true"  style="text-align:right;"    
                                        CssClass="validate[custom[number]] cgst"
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%#Eval("CGST","{0:0.00}") %>' Width="60px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="60px" />
                         <FooterTemplate>
                             <asp:TextBox ID="txtcgsttotal" runat="server" Width="60px"  Enabled="false"></asp:TextBox>
                         </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SGST">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgScgst" runat="server" Enabled="true"  style="text-align:right;"  
                                        CssClass="validate[custom[number]] sgst"
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%#Eval("SCGST","{0:0.00}") %>' Width="60px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="60px" />
                         <FooterTemplate>
                             <asp:TextBox ID="txtsgsttotal" runat="server" Width="60px"  Enabled="false"></asp:TextBox>
                         </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IGST">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgIgst" runat="server" Enabled="true"
                            style="text-align:right;"  
                                        CssClass="validate[custom[number]] igst"
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%#Eval("IGST","{0:0.00}") %>' Width="60px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="60px" />
                         <FooterTemplate>
                             <asp:TextBox ID="txtigsttotal" runat="server" Width="60px"  Enabled="false"></asp:TextBox>
                         </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TDS">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgTds" runat="server" Enabled="true" onfocusout="Calculationtds(this)" style="text-align:right;"  
                                        CssClass="validate[custom[number]] "
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%#Eval("TDS","{0:0.00}") %>' Width="60px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="60px" />
                         <FooterTemplate>
                             <asp:TextBox ID="TextBox1" runat="server" Width="60px" Enabled="false"></asp:TextBox>
                         </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TDS_Amount">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgdtsamt" runat="server" Enabled="true"  style="text-align:right;"  
                                        CssClass="validate[custom[number]] tdsamt" 
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%#Eval("TDS_Amount","{0:0.00}") %>' Width="85px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="60px" />
                         <FooterTemplate>
                             <asp:TextBox ID="txttdstotal" runat="server" Width="85px" Enabled="false"></asp:TextBox>
                              <asp:Button ID="Button2" runat="server" Width="40px"  CommandName="add"  Font-Size="Small"
                               CssClass="coma" Visible="true" Text="Add"  OnClientClick="jQuery('#form1').validationEngine('hideAll');"  /> 
                         </FooterTemplate>
                        
                    </asp:TemplateField>
                    
                    <asp:TemplateField  HeaderText="FileUp">
                     <ItemTemplate>
                         <asp:FileUpload ID="FileUpload1"  runat="server" />
                         <asp:HiddenField ID="hfFileByte" runat="server" />
                         <asp:LinkButton ID="LinkButton1" OnClick="DownloadFile" CommandArgument='<%# Eval("SNo") %>' runat="server">Download</asp:LinkButton>
                        <%--<img id="imgFileUpload" alt="Select File" onclick="$('#FileUpload1').trigger('click');" title="Select File" src="../images/icons/3423633.png" style="cursor: pointer" />--%>
                        <%--<button id="OpenImgUpload" onclick="$('#imgupload').trigger('click');">Image Upload</button>--%>
<%--<input type="file" id="imgupload" style="display:none"/> 
                        <input type="button" class="button" id="btnUpload" onclick='$("#imgupload").click()' value="Upload"/>--%>
                         <%--<input style="display:none" type="file" id="fileupload1" />
<input type="button" class="button" id="btnUpload" onclick='$("#fileupload1").click()' value="Upload"/>
<span id="spnName"></span>--%>

                 <%--<img src="../images/icons/3423633.png" class="fakefile" />--%>
            
                                                <%--<asp:ImageButton ID="Imgupload" runat="server"  CausesValidation="false" OnClientClick="open_file(); return false"   ImageUrl="../images/plus.gif" Width="15px"  />--%>
                                                <%--<asp:ImageButton ID="imgRemove" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"  OnCommand="gvdetails_RowDeleting"  ImageUrl="../images/icons/delete-sign.png" Width="20px"  />--%>                                                                                               
                                            </ItemTemplate>                                   
                                            
                                            <FooterTemplate>
                            
                                <%--<asp:Button ID="Button2" runat="server" Width="40px"  CommandName="add"  Font-Size="Small"
                               CssClass="coma" Visible="true" Text="Add"  OnClientClick="jQuery('#form1').validationEngine('hideAll');"  />--%>   
                               <%--<asp:Button ID="btnAdd" runat="server" Visible="true" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"   UseSubmitBehavior="true"
                             Text="Add"  />--%>
                                                            

         
      
                        </FooterTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                         <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                                                <%--<asp:ImageButton ID="Imgupload" runat="server"  CausesValidation="false"    ImageUrl="../images/plus.gif" Width="20px"  />--%>
                                                <asp:ImageButton ID="imgRemove" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CausesValidation="false"  OnCommand="gvdetails_RowDeleting"  ImageUrl="../images/icons/delete-sign.png" Width="15px"  />
                                               
                                                
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField DeleteImageUrl="../js/delete-sign.png" />
                                        
                                        </Columns>
                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                                NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                        <PagerStyle CssClass="pager" />
                                    <EmptyDataTemplate>
                                        NO RECORD FOUND
                                    </EmptyDataTemplate>
                                        </asp:GridView>
                    <%--<asp:GridView ID="gvbind" AutoGenerateColumns="false" runat="server" >
                    <Columns>
                   
                                        <asp:BoundField DataField="IMP_EXP" HeaderText="IMP_EXP" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FILE_REF_NO" HeaderText="FILE_REF_NO" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField><asp:BoundField DataField="DATE" HeaderText="DATE" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField><asp:BoundField DataField="DR_CR" HeaderText="DR_CR" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField><asp:BoundField DataField="CUSTOMER_NAME" HeaderText="CUSTOMER_NAME" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10" />
                                        </asp:BoundField><asp:BoundField DataField="CHARGE_NAME" HeaderText="CHARGE_NAME" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField><asp:BoundField DataField="SAC_CODE" HeaderText="SAC_CODE" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField><asp:BoundField DataField="TAX_RATE" HeaderText="TAX_RATE" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField><asp:BoundField DataField="CREDIT" HeaderText="CREDIT" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField><asp:BoundField DataField="DEBIT" HeaderText="DEBIT" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField><asp:BoundField DataField="CGST" HeaderText="CGST" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="SCGST" HeaderText="SCGST" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                         </asp:BoundField>
                                         <asp:BoundField DataField="IGST" HeaderText="IGST" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                         </asp:BoundField><asp:BoundField DataField="TDS" HeaderText="TDS" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                            </asp:BoundField>
                                         <asp:BoundField DataField="TDS_AMOUNT" HeaderText="TDS_AMOUNT" HeaderStyle-Width="10px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="10px" />
                                        </asp:BoundField>
                    
                    </Columns>
                    </asp:GridView>--%>
                                    <%--</div>--%>
                                    <style type="text/css">
                                        input.underlined
                                        {
                                            border: solid 1px #000;
                                        }
                                    </style>
                                    
                                    <%--------------------------------------Row End-----------------------------------------%>
                                </div>
                            </div>

                         <div style="width: 1400px; height: 30px">
<div id="tag_label_transact_Src" style="width: 90px;">
                                       Grand Total
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txtGrandtotal"  runat="server" Enabled="true"   TabIndex="13"
                                         MaxLength="50" CssClass=" txtbox_none_Mid_transac_code" ></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                       Net Amount
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txtNetamt"  runat="server" Enabled="true"   TabIndex="13"
                                         MaxLength="50" CssClass=" txtbox_none_Mid_transac_code" ></asp:TextBox>
                                    </div>
                                    </div>
                <%-------------------------------------------------------------------------------%>
            
            <%-- --------------------Test Start----------------------------%>
            <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                <div id="innerbox_transac_bot_inn" >
                    <div id="newbu">
                        <%--<asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                             TabIndex="31" Visible="false" />--%>
                              <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates" 
                             TabIndex="33" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save"  OnClick="btnSave_Click" OnClientClick="return validate_Exp_V2();"
                            TabIndex="32"  CommandName="s" />
                    </div>
                    <div id="editbu">
                        <%--<asp:Button ID="btnUpdate" runat="server"  CssClass="updates" 
                            OnClientClick="return validate_Exp_V2();" TabIndex="33" />--%>
                                                           <asp:Button ID="btnprint" runat="server" Height="30px" Text="Export" TabIndex="34" OnClientClick="open_jobno(); return false"  />

                    </div>
                    <%--<div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="34" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this expenses?', 'Expenses', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="35" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            CssClass="dlete" Style="display: none;" />
                    </div>--%>
                    <%--<div id="editbu">
                        <asp:Button ID="btndownload" runat="server"  CssClass="autowidmovebut" UseSubmitBehavior="false" Text="Download" 
                            OnClientClick="Excel_download(); TabIndex="33" />
                    </div>--%>
                    <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                            id="btnCancel" tabindex="33" Style="display: none;">
                    </div>
                    <%--<div id="editbu">
                               <asp:Button ID="btnprint" runat="server" TabIndex="34" OnClientClick="open_jobno(); return false"  />

                    
                    </div>--%>

                    <div id="editbu" style="width: 10px;">
                    </div>

                    <%--<div id="editbu" style="padding-top: 5px;">
                        <asp:Button ID="btnrpt" runat="server" TabIndex="35" Text="Get Bill" OnClientClick="return GST_Import_Billing_Job_Rpt('B');" />
                        <%--OnClientClick="return Import_Billing_Job_Rpt('B');"--%
                    </div>--%>
                </div>
            </div>
            <%-- --------------------Test End----------------------------%>
            
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="Hdnfileref" runat="server" />
    <asp:HiddenField ID="Hdncgst" runat="server" />
    <asp:HiddenField ID="Hdnsgst" runat="server" />
    <asp:HiddenField ID="Hdnigst" runat="server" />
    <asp:HiddenField ID="hdntds" runat="server" />
    <asp:HiddenField ID="Hd_row_id" runat="server" />
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
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
    <script src="../js/Export_Jscript/Export_Invoice.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <%--<script type="text/javascript" src="../js/Billing/jquery.min.js"></script>--%>
    <%--<script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>

    <script type="text/javascript">

        function open_jobno() {

            if (document.getElementById("<%=txtVoucherno.ClientID %>").value != '') {
                var f = document.getElementById("<%=txtVoucherno.ClientID %>").value;
                NewWindow1('../Billing_Imp_Rpt/Purchase_Entry_Report.aspx?voucherno=' + f + '', 'List', '870', '1024', 'yes');
                return false
            }

        } 
        function open_file() {

//            if (document.getElementById("<%=txtVoucherno.ClientID %>").value != '') {
//                var f = document.getElementById("<%=txtVoucherno.ClientID %>").value;
            NewWindow1('../Billing_Imp/FileUpload.aspx', 'List', '570', '100', 'yes');
//                return false
//            }

        }
     </script>
     <%--<script type="text/javascript">
         $(function () {
             var fileupload = $("#FileUpload1");
//             var filePath = $("#spnFilePath");
             var image = $("#imgFileUpload");
             image.click(function () {
                 fileupload.click();
             });
             //        fileupload.change(function () {
             //            var fileName = $(this).val().split('\\')[$(this).val().split('\\').length - 1];
             //            filePath.html("<b>Selected File: </b>" + fileName);
             //        });
         });
</script>--%>
 <script type="text/javascript">
     $(function () {
         $("#fileupload1").change(function () {
             $("#spnName").html($("#fileupload1").val().substring($("#fileupload1").val().lastIndexOf('\\') + 1));
         });
     });
</script>
     <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();

            $("#txtbillamount, #txtInvoiceCurrency").change(function () {
                $("#txtTotalamtininr").val('');
                var $input = $(this);
                if ($input.is('#txtInvoiceCurrency')) {
                    setTimeout(
                      function () {
                          var amt = $("#txtbillamount").val();
                          var exrate = $("#txtExrate").val();
                          if (amt != '' && amt != 'undefined' && exrate != '' && exrate != 'undefined') {
                              $("#txtTotalamtininr").val(amt * exrate);
                          }
                      }, 1000);
                }
                else {
                    var amt = $("#txtbillamount").val();
                    var exrate = $("#txtExrate").val();
                    if (amt != '' && amt != 'undefined' && exrate != '' && exrate != 'undefined') {
                        $("#txtTotalamtininr").val(amt * exrate);
                    }
                }
            });
        });


        function close_button() {
            document.getElementById("General").click();
        }
    </script>
    

    <script>
        $(function () {
            $('#txtCurrency').autocomplete({
                source: function (request, response) {
                    //                    var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exchage_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                                                jQuery('#txtCurrency').validationEngine('showPrompt', 'Incorrect Currency', 'error', 'topRight', true);
//                                $('#txtCurrency').val('');

                                //jAlert('Invoice Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                //return false;


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

        $(function () {
            $('#txtVendorname').autocomplete({
                source: function (request, response) {
                    //                    var field = $(this.element).attr('id');
                    

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Vendor_Name_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,

                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                //                                jQuery('#txtVendorname').validationEngine('showPrompt', 'Incorrect Vendor Name', 'error', 'topRight', true);

                                $('#txtVendorname').val('');

                                //jAlert('Invoice Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                //return false;


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

        $(function () {
            $('#txtVendorbranch').autocomplete({
                source: function (request, response) {
                    //                    var field = $(this.element).attr('id');
                    var venname = document.getElementById("txtVendorname");
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Vendor_Branch_List",
                        data: "{ 'mail': '" + request.term + "' ,'code':'"+venname.value+"'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                jQuery('#txtVendorbranch').validationEngine('showPrompt', 'Incorrect Branch', 'error', 'topRight', true);
                                $('#txtVendorbranch').val('');
                                //jAlert('Invoice Currency is Incorrect', 'INVOICE', function (r) { document.getElementById(field).focus(); });
                                //return false;


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

        $(function () {

            $(".Search").autocomplete({
                source: function (request, response) {
                    //                     var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Charge_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item,
                                    val: item
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
                minLength: 1

            });
            return false;
            scroll: true;

        });
        $(function () {

            $(".Fileref").autocomplete({
                source: function (request, response) {
                    //                     var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Job_No",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item,
                                    val: item
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
                minLength: 1
            });
            return false;
            scroll: true;

        });

       

//        $(function () {
//            var availableTags = [
//      "Royal Tech Systems",

//    ];
//            var availableTagsfile = [
//      "FILE/2020/12",

//    ];
//            var availableTagsbr = [
//      "Chennai",

//    ];
//            $("#txtVendorname").autocomplete({
//                source: availableTags
//            });
//            $(".Fileref").autocomplete({
//                source: availableTagsfile
//            });
//            $("#txtVendorbranch").autocomplete({
//                source: availableTagsbr
//            });
//        });


    </script>
   
     <script type="text/javascript">
         function Excel_download() {
             var txtvoucherno = $("[id*=txtVoucherno]")
             var Type = 'excel';
             win = window.open('../FlatFile/MIS_report_1.aspx?Excel_Download_XLs=Yes&voucherno=' + txtvoucherno +  '', 'ndf');
             Loading_HideImage();
         }
         function Calculation(lnk) {
//            $(function () {
//             $("[id*=gvdetails]").find("[id*=txtgCharHead]").blur(function () {
             
//            //Reference the GridView Row.
//            var row = $(this).closest("tr");
// 
//            var a= row.find("td").eq(6).html();

             var grid = document.getElementById("<%= gvdetails.ClientID%>");
             var txtAmountReceive = $(".Search")
//             var txtAmountReceive = $("[id*=txtgCharHead]")
//             alert(txtAmountReceive);
//             var txtAmountReceive_2 = $("[id*=ddl_tax_nontax]")
             var row = lnk.parentNode.parentNode;
             
             var rowIndex = row.rowIndex-1;
             //             var a = "AAI EXPENSES";
//             alert(rowIndex);
//             var a = "gvdetails_" + "txtgCharHead_" + rowIndex.value;
             var a = txtAmountReceive[rowIndex].value;
//             alert(a);
             var b = '1';

             $('#Hd_row_id').val(rowIndex);

             Cha_Type(a, b);
//             Tax_Cal();
         }  
          </script>
    <script type="text/javascript">

        function Cha_Type(src, dest) {
            PageMethods.Get_Cha_rate(src, '', '', CallSuccess_Cha_Type, CallFailed, dest);
        }
        function CallSuccess_Cha_Type(res, destCtrl) {

            var data = res;

            if (res != '') {
//                var selectedindex = $('#Hd_row_id').val;
//                alert(selectedindex);
//                var chargetype = $("[id*=ddl_tax_nontax]")
//                var txt_HSN_Code = $("[id*=txt_HSN_Code]")
//                var txt_SA_Code = $("[id*=txt_SA_Code]") //****New Implementation by Elaiyaa on 26Jun2019*********//

                //                var selected = $('input:radio[name=Rd_Bill_Type]:checked').val();
//                alert('hi');
//                var txtCGST = $("[id*=Hdncgst]")
                var txtTaxrate = $("[id*=txtgTaxrate]")
//                var txtSGST = $("[id*=Hdnsgst]")

//                var txtIGST = $("[id*=Hdnigst]")
                var txtsaccode = $("[id*=ddl_Gst_type]")
//                $(".cgst").val(before);

//                alert(document.getElementById("Hd_row_id").value);

//                var Hd_Company_Id = document.getElementById("Hd_Company_Id").value;

                if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

                    var s = data.split('~~');
                    var cgst = s[0];
                    var sgst = s[1];
                    var igst = s[2]; //****New Implementation by Elaiyaa on 26Jun2019*********//
                    var tds = s[3];
                    var saccode = s[4];   //line 6.1
//                    var tempSGST_RATE = s[4];     //line 6.2
                    //                    var tempIGST_RATE = s[5];     //line 6.3
                    //                    alert(before
                    //                    $(".cgst").val(before);

//                    alert(txttds[document.getElementById("Hd_row_id").value]);
                    txtsaccode[document.getElementById("Hd_row_id").value].value = saccode;
                    var state = $('input[name="Rd_Bill_Type"]:checked').val();
                    if (state == 'L') {
                        txtTaxrate[document.getElementById("Hd_row_id").value].value = parseFloat(cgst) + parseFloat(sgst);
                    }
                    else {
                        txtTaxrate[document.getElementById("Hd_row_id").value].value =  parseFloat(igst);
                    }
                    $("[id*=txtgTaxrate]").attr('readonly', 'readonly');
                    
//                    txtSGST[document.getElementById("Hd_row_id").value].value = sgst;
//                    txtIGST[document.getElementById("Hd_row_id").value].value = igst;
                    //                    txttds[document.getElementById("Hd_row_id").value].value = tds;
                    $("[id*=Hdncgst]").val(cgst);
                    $("[id*=Hdnsgst]").val(sgst);
                    $("[id*=Hdnigst]").val(igst);
                    $("[id*=hdntds]").val(tds);

                    
                   
                }
                
            }
            else {
                chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;
            }
        }

        function CallFailed(res, destCtrl) {
        }
    </script>
        <script type="text/javascript">
            function Calculationtds(lnk) {
                if ($(".debitgst").val() != null && $(".debitgst").val() != '') {
                    var txtAmountReceive = $(".debitgst")
                }
                else if ($(".creditgst").val() != null && $(".creditgst").val() != '') {
                    var txtAmountReceive = $(".creditgst")
                }

                var row = lnk.parentNode.parentNode;
                var rowIndex = row.rowIndex - 1;
                var a = txtAmountReceive[rowIndex].value;
                var txttds = $("[id*=txtgTds]");
                var tds = txttds[rowIndex].value;
                var tdsamt = MathRound(a * (tds / 100));
              
                var txtdtsamt = $("[id*=txtgdtsamt]")
                txtdtsamt[rowIndex].value = tdsamt;
                calculate()
                var totalcredit = $("[id*=txtcredittotal").val()
                var totaldebit = $("[id*=txtdebittotal]").val()
                var totalcgst = $("[id*=txtcgsttotal]").val()
                var totalsgst = $("[id*=txtsgsttotal]").val()
                var totaligst = $("[id*=txtigsttotal]").val()
                var totaltds = $("[id*=txttdstotal]").val()
                var grandtotal, Nettotal
                if (totalcredit != null && totaldebit != null && totalcredit != '' && totaldebit != '') {
                    grandtotal = Math.round(parseFloat(totalcredit) + parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst))
                    Nettotal = Math.round(parseFloat(totalcredit) + parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) - parseFloat(totaltds))

                }
                else if (totalcredit != null && totalcredit != '') {
                    grandtotal = Math.round(parseFloat(totalcredit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst))
                    Nettotal = Math.round(parseFloat(totalcredit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) - parseFloat(totaltds))

                }
                else if (totaldebit != null && totaldebit != '') {
                    grandtotal = Math.round(parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst))
                    Nettotal = Math.round(parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) - parseFloat(totaltds))

                }
                //                alert(totaldebit)
                $("#txtGrandtotal").val(grandtotal)
                //                    var Nettotal = parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) - parseFloat(totaltds)
                $("#txtNetamt").val(Nettotal)

            }
            function gst(lnk) {
                if ($(".debitgst").val() != null && $(".debitgst").val() != '') {
                    var txtAmountReceive = $(".debitgst")
                }
                else if ($(".creditgst").val() != null && $(".creditgst").val() != '') {
                    var txtAmountReceive = $(".creditgst")
                }
                
                var row = lnk.parentNode.parentNode;
                var rowIndex = row.rowIndex - 1;
                var a = txtAmountReceive[rowIndex].value;
                //                alert(a);
                if (a != null && a != '') {
                    var cgst = MathRound(a * (document.getElementById("Hdncgst").value / 100))
                    var sgst = MathRound(a * (document.getElementById("Hdnsgst").value / 100))
                    var igst = MathRound(a * (document.getElementById("Hdnigst").value / 100))
                    //                alert(document.getElementById("hdntds").value);
                    var tds = document.getElementById("hdntds").value;
                    var tdsamt = MathRound(a * (document.getElementById("hdntds").value / 100));
                    //                var txtcgst = $("[id*=");
                    //                var txtcgst = $("[id*=");
                    //                var txtigst = $("[id*=");
                    //                var txtcgst = $("[id*=");

                    var txtCgst = $("[id*=txtgCgst]")
                    var txtSgst = $("[id*=txtgScgst]")
                    var txtIgst = $("[id*=txtgIgst]")
                    var txttds = $("[id*=txtgTds]")
                    var txtdtsamt = $("[id*=txtgdtsamt]")
                    var state = $('input[name="Rd_Bill_Type"]:checked').val();
                    if (state == 'L') {
                        txtCgst[document.getElementById("Hd_row_id").value].value = cgst;
                        txtSgst[document.getElementById("Hd_row_id").value].value = sgst
                        txtIgst[document.getElementById("Hd_row_id").value].value = 0

                    }
                    else {
                        txtCgst[document.getElementById("Hd_row_id").value].value = 0;
                        txtSgst[document.getElementById("Hd_row_id").value].value = 0
                        txtIgst[document.getElementById("Hd_row_id").value].value = igst
                    }
                    txttds[document.getElementById("Hd_row_id").value].value = tds;
                    txtdtsamt[document.getElementById("Hd_row_id").value].value = tdsamt;
                    calculate()


                                    var totalcredit = $("[id*=txtcredittotal").val()
                    var totaldebit = $("[id*=txtdebittotal]").val()
                    var totalcgst = $("[id*=txtcgsttotal]").val()
                    var totalsgst = $("[id*=txtsgsttotal]").val()
                    var totaligst = $("[id*=txtigsttotal]").val()
                    var totaltds = $("[id*=txttdstotal]").val()
                    var grandtotal, Nettotal
                    if (totalcredit != null && totaldebit != null && totalcredit != '' && totaldebit != '') {
                        grandtotal = Math.round(parseFloat(totalcredit) + parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) )
                        Nettotal = Math.round(parseFloat(totalcredit) + parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) - parseFloat(totaltds))

                    }
                    else if (totalcredit != null && totalcredit != '') {
                        grandtotal = Math.round(parseFloat(totalcredit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst))
                        Nettotal = Math.round(parseFloat(totalcredit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) - parseFloat(totaltds))

                    }
                    else if (totaldebit != null && totaldebit != '') {
                        grandtotal = Math.round(parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst))
                        Nettotal = Math.round(parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) - parseFloat(totaltds))

                    }
                    //                alert(totaldebit)
                    $("#txtGrandtotal").val(grandtotal)
//                    var Nettotal = parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) - parseFloat(totaltds)
                    $("#txtNetamt").val(Nettotal)
                    $("[id*=txtgCgst]").attr('readonly', 'readonly');
                    $("[id*=txtgScgst]").attr('readonly', 'readonly');
                    $("[id*=txtgIgst]").attr('readonly', 'readonly');
//                    $("[id*=txtgTds]").attr('readonly', 'readonly');
                    $("[id*=txtgdtsamt]").attr('readonly', 'readonly');
                }
//                
            }
            function tap() {
                
                $("[id*=drpImpexp]").focus();
            }

            function cusname(lnk) {
//                alert('hi');
                var grid = document.getElementById("<%= gvdetails.ClientID%>");
                var txtAmountReceive = $(".Fileref")
                var row = lnk.parentNode.parentNode;
                var rowIndex = row.rowIndex - 1;
                var a = txtAmountReceive[rowIndex].value;
//                alert(a);
                var b = '1';
                $('#Hd_row_id').val(rowIndex);
                Cha_cus(a, b);
            }
            function Cha_cus(src, dest) {
//                alert('hi');
                PageMethods.Cust_Name(src, '', '', CallSuccess_Cusname, CallFaileda, dest);
            }
            function CallSuccess_Cusname(res, destCtrl) {

                var data = res;
//                                alert(data);
                var txtC = $("[id*=txtgCusName]")
                var txtD = $("[id*=txtgDate]")
                if (res != '') {
                    if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {
                        var s = data.split('~~');
                        var name = s[0];
                        var date = s[1];
                        txtC[document.getElementById("Hd_row_id").value].value = name;
                        txtD[document.getElementById("Hd_row_id").value].value = date;

                    }
                    
                    //                    var cusname = data;
                    
                }
                else {
                    txtC[document.getElementById("Hd_row_id").value].selectedIndex = 1;
                }
            }

            function CallFaileda(res, destCtrl) {
            }
            function drcr(lnk) {

                var txtAmountReceive = $("[id*=drpDrcr]")
                var row = lnk.parentNode.parentNode;
                var rowIndex = row.rowIndex - 1;
                var a = txtAmountReceive[rowIndex].value;
//                alert(a)
//                var txtdebit=$("[id*=txtgDebit]")
//                var txtcredit=$("[id*=txtgCredit]")
                //                alert(a)
                if (a == 'CR') {
                    $("[id*=txtgDebit]").attr('readonly', 'readonly');
                    $("[id*=txtgCredit]").removeAttr('readonly');
                }
                else if (a == 'DR') {
                    $("[id*=txtgCredit]").attr('readonly', 'readonly');
                    $("[id*=txtgDebit]").removeAttr('readonly');
                }

            }
    </script>
    <script  type="text/javascript">
            function calculate() {
                var txtTotal = 0.00, txttdstot = 0.00, txtigtot = 0.00, txtsgtot = 0.00, txtcgtot = 0.00, txtcredittotal = 0.00
                $(".creditgst").each(function (index, value) {
                    var valcre = value.value;
                    val = valcre.replace(",", ".");
                    txtcredittotal = MathRound(parseFloat(txtcredittotal) + parseFloat(valcre));
                    //                    alert(txtTotal)
                });
            $(".debitgst").each(function (index, value) {
                    var val = value.value;
                    val = val.replace(",", ".");
                    txtTotal = MathRound(parseFloat(txtTotal) + parseFloat(val));
//                    alert(txtTotal)
                });
                $(".cgst").each(function (index1, value1) {
                    var valcg = value1.value;
                    valcg = valcg.replace(",", ".");
                    txtcgtot = MathRound(parseFloat(txtcgtot) + parseFloat(valcg));
//                    alert(txtcgtot)
                });
                $(".sgst").each(function (index2, value2) {
                    var valsg = value2.value;
                    valsg = valsg.replace(",", ".");
                    txtsgtot = MathRound(parseFloat(txtsgtot) + parseFloat(valsg));
//                    alert(txtsgtot)
                });
                $(".igst").each(function (index3, value3) {
                    var valig = value3.value;
                    valig = valig.replace(",", ".");
                    txtigtot = MathRound(parseFloat(txtigtot) + parseFloat(valig));
                });
                $(".tdsamt").each(function (index4, value4) {
                    var valtds = value4.value;
                    valtds = valtds.replace(",", ".");
                    txttdstot = MathRound(parseFloat(txttdstot) + parseFloat(valtds));
                    
                });
                //                alert(txtTotal)
                if (!isNaN(txtcredittotal)) {
                    $("[id*=txtcredittotal]").val(txtcredittotal)
                }
                if (!isNaN(txtTotal)) {
                    $("[id*=txtdebittotal]").val(txtTotal)
                }
                $("[id*=txtcgsttotal]").val(txtcgtot)
                $("[id*=txtsgsttotal]").val(txtsgtot)
                $("[id*=txtigsttotal]").val(txtigtot)
                $("[id*=txttdstotal]").val(txttdstot)
            }
            function MathRound(number) {
                var result = Math.round((number + Number.EPSILON) * 100) / 100;
                return result;
            }
            </script>

    <script type="text/javascript">
        function isDate() {

            var txt = document.getElementById("txtBilldate").value;
            var validformat = /^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$/
//            var validformat = /^(0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])[\/\-]\d{4}$/;
////            var validformat = /^(?=\d)(?:(?:31(?!.(?:0?[2469]|11))|(?:30|29)(?!.0?2)|29(?=.0?2.(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(?:\x20|$))|(?:2[0-8]|1\d|0?[1-9]))([-.\/])(?:1[012]|0?[1-9])\1(?:1[6-9]|[2-9]\d)?\d\d(?:(?=\x20\d)\x20|$))?(((0?[1-9]|1[012])(:[0-5]\d){0,2}(\x20[AP]M))|([01]\d|2[0-3])(:[0-5]\d){1,2})?$/;
////            var validformat = /^\d{2}\/\d{2}\/\d{4}$/ //Basic check for format validity
            ////            alert(!validformat.test(txt))
            if (validformat.test(txt)==false && txt!="") {
                alert("Invalid Date")
            }
           
        }
        function vendordetail() {
            var txtVendorname = $("#txtVendorname").val();
            var txtVendorbr = $("#txtVendorbranch").val();
//        var a = txtVendorname.value;
//        alert('hello');
//        alert(txtVendorname);
        //        Vend(txtVendorname, txtVendorbr);
        PageMethods.Get_Vendordetail(txtVendorname, txtVendorbr, '', CallSuccess_vendordetail, CallFailed_vendordetail);

       
//        PageMethods.Get_Vendordetail(txtVendorname, txtVendorbr, '', CallSuccess_vendordetail, CallFailed_vendordetail);
//        alert('hi');
    }
    function Vend(src, dest) {
//        alert('vendhi');
        PageMethods.Get_Vendordetail(txtVendorname, '', '', CallSuccess_vendordetail, CallFailed_vendordetail,dest);
        
    }
    function CallSuccess_vendordetail(res, destCtrl) {
//        alert('success');
        var data = res;
        //                                alert(data);
//        var txtstate = $("[id*=txtgCusName]").val(
//        var txtGstn = $("[id*=txtgDate]")
//        var txtGstntype = $("[id*=txtgDate]")
        //        var txtCountry = $("[id*=txtgDate]")
//        alert(data);
        if (res != '') {
            if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {
                var s = data.split('~~');
                var state = s[0];
                var Gstn = s[1];
                var GstnType = s[2];
                var country = s[3];
                var gsttype = s[4];
////                alert(state);
                $("#txtVendorstate").val(state);
                $("#txtGstn").val(Gstn);
                $("#txtGstntype").val(GstnType);
                $("#txtCountry").val(country);
                $("#txtGstntype").val(gsttype);
//                $("#txtVendorstate").value = state;
////                txtC[document.getElementById("Hd_row_id").value].value = name;
////                txtD[document.getElementById("Hd_row_id").value].value = date;

            }

            //                    var cusname = data;

        }
        else {
//            txtC[document.getElementById("Hd_row_id").value].selectedIndex = 1;
        }
    }

    function CallFailed_vendordetail(res, destCtrl) {
////    alert('fail');
    }

    </script>
    
</body>
</html>
