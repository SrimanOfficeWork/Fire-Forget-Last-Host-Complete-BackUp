<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Creditnote.aspx.cs"    Inherits="Billing_Imp_Creditnote" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>CreditNote Entry</title>
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
//    function EnableTextbox(ddl, txtD, txtC) {
//        var ddl_PaymentMethod = document.getElementById(ddl);
//        var txt_Debit = document.getElementById(txtD);
//        var txt_Credit = document.getElementById(txtC);
//        var ddl_Value = ddl_PaymentMethod.value;
//        if (ddl_Value == "CR") {
//            txt_Debit.disabled = true;
//            txt_Credit.disabled = false;
//        }
//        else if (ddl_Value == "DR") {
//            txt_Debit.disabled = false;
//            txt_Credit.disabled = true;
//        } 
//    }
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
//    $(document).ready(function () {
//        var today = new Date();
//        $('.datepicker').datepicker({
//            format: 'dd-mm-yyyy',
//            autoclose: true,
//            endDate: "today",
//            maxDate: today
//        }).on('changeDate', function (ev) {
//            $(this).datepicker('hide');
//        });


//        $('.datepicker').keyup(function () {
//            if (this.value.match(/[^0-9]/g)) {
//                this.value = this.value.replace(/[^0-9^-]/g, '');
//            }
//        });
//    });
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
            <div id="innerbox_MidMain" style="height: 150px;width:980px;">
                <div id="tag_srcinner1" style="width:980px">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                       Credit Note
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
                <div id="tag_transact_src_inner" style="width: 980px;height:120px;">
                    <div id="tag_Exchange_inner_lft" style="width: 980px;height:120px;">
                        <div id="tag_transact_lft_in1" style="width: 980px; height:120px;">                            
                            <div style="width: 1400px; height: 40px">
                                <div id="txt_container_Transact_Main_l" style="width:210px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Credit Note No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:105px;" >
                                        <asp:TextBox ID="txtCreditNoteno" CssClass="txtbox_none_Mid_transac_code"  runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width:1100px;">
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                          Date
                                    </div>
                                     <div id="txtcon-m_Exchange" style="width:120px;">
                                         <asp:TextBox ID="txtdate" CssClass="txtbox_none_Mid_transac_code"  runat="server"></asp:TextBox>
                                         <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtdate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdate"
                                PopupButtonID="txtJobDate" Enabled="true" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                                     </div>
                                     <div id="tag_label_transact_Src" style="width: 85px;">
                                        Party Name 
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:290px;" >
                                        <asp:TextBox ID="txtPartyname" CssClass=" txtbox_none_Mid_transac_code Vendorname"  Width="280px" runat="server"></asp:TextBox>
                                    </div>                                   
                                    
                                </div>                            
                                <div style="width: 1400px; height: 30px">                             
                                <%--<div id="txt_container_Transact_Main_l" style="width: 220px;">--%>                           
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Invoice No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txtInvoiceno" CssClass="validate[required] txtbox_none_Mid_transac_code" runat="server"></asp:TextBox>
                                    </div>
                                 </div>

                                                           
                                                        
                          
                           </div>
                           </div>
                        
                        </div>
                    </div>
                </div>
            
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -30px;width:980px;">
                <%---28 --%>
                <div id="innerbox_MidMain_Trans_new" style="height: 340px; width: 980px; margin-left: -16px; overflow-y:scroll; overflow-x:scroll;
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
                    
                    
                    <asp:TemplateField HeaderText="Charge_Head">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgCharHead" Width="300px" runat="server"   AutoPostBack="false"  onblur="Calculation(this)"
                             Text='<%# Eval("INCOME_CHARGE_NAME") %>' CssClass="Search" ></asp:TextBox>
                            <%--<asp:TextBox ID="txtgCharHead"  Text='<%# Bind("Charge_Head") %>' runat="server" onblur="Calculation(this)" CssClass="Search"                                      
                                            Height="20px" Width="152px" Font-Size="12px"  ></asp:TextBox>--%>
                            <asp:HiddenField ID="hfCustomerId" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SAC_Code">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgSaccode" runat="server" Enabled="true" Text='<%# Eval("SAC_Code") %>'  Width="100px"></asp:TextBox>
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
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgAmount" runat="server"  
                            style="text-align:right;"  
                                        CssClass="validate[custom[number]] amountgst" onfocusout="gst(this)"
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%# Eval("Amount","{0:0.00}") %>' Width="105px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="60px" />
                         <FooterTemplate>
                             <asp:TextBox ID="txtamounttotal" runat="server" Enabled="false"  Width="105px"></asp:TextBox>
                         </FooterTemplate>
                    </asp:TemplateField>
                   
                    <%--<asp:TemplateField HeaderText="Debit">
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
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="CGST">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgCgst" runat="server" Enabled="true"  style="text-align:right;"    
                                        CssClass="validate[custom[number]] cgst"
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%#Eval("CGST_AMT","{0:0.00}") %>' Width="100px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="100px" />
                         <FooterTemplate>
                             <asp:TextBox ID="txtcgsttotal" runat="server" Width="100px"  Enabled="false"></asp:TextBox>
                         </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SGST">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgScgst" runat="server" Enabled="true"  style="text-align:right;"  
                                        CssClass="validate[custom[number]] sgst"
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%#Eval("SGST_AMT","{0:0.00}") %>' Width="100px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="100px" />
                         <FooterTemplate>
                             <asp:TextBox ID="txtsgsttotal" runat="server" Width="100px"  Enabled="false"></asp:TextBox>
                         </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IGST">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgIgst" runat="server" Enabled="true"
                            style="text-align:right;"  
                                        CssClass="validate[custom[number]] igst"
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%#Eval("IGST_AMT","{0:0.00}") %>' Width="100px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="100px" />
                         <FooterTemplate>
                             <asp:TextBox ID="txtigsttotal" runat="server" Width="100px"  Enabled="false"></asp:TextBox>
                             <asp:Button ID="Button2" runat="server" Width="40px"  CommandName="add"  Font-Size="Small"
                               CssClass="coma" Visible="true" Text="Add"  OnClientClick="jQuery('#form1').validationEngine('hideAll');"  /> 
                         </FooterTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="TDS">
                        <ItemTemplate>
                            <asp:TextBox ID="txtgTds" runat="server" Enabled="true"  style="text-align:right;"  
                                        CssClass="validate[custom[number]] "
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtbillamount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Text='<%#Eval("TDS","{0:0.00}") %>' Width="60px"></asp:TextBox>
                        </ItemTemplate>
                         <ItemStyle Width="60px" />
                         <FooterTemplate>
                             <asp:TextBox ID="TextBox1" runat="server" Width="60px" Enabled="false"></asp:TextBox>
                         </FooterTemplate>
                    </asp:TemplateField>--%>
                    <%--<asp:TemplateField HeaderText="TDS_Amount">
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
                        
                    </asp:TemplateField>--%>
                    
                    
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
                                        <asp:TextBox ID="txtGrandtotal"  runat="server" Enabled="true"  
                                         MaxLength="50" CssClass=" txtbox_none_Mid_transac_code" ></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                       Net Amount
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:TextBox ID="txtNetamt"  runat="server" Enabled="true" 
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
                              />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save"  OnClick="btnSave_Click" OnClientClick="return validate_Exp_V2();"
                              CommandName="s" />
                    </div>
                    <div id="editbu">
                        <%--<asp:Button ID="btnUpdate" runat="server"  CssClass="updates" 
                            OnClientClick="return validate_Exp_V2();" TabIndex="33" />--%>
                                                           <asp:Button ID="btnprint" runat="server" Height="30px" Text="Export"  OnClientClick="open_jobno(); return false"  />

                    </div>
                    
                   
                    <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                            id="btnCancel"  Style="display: none;">
                    </div>
                    

                    <div id="editbu" style="width: 10px;">
                    </div>

                   
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

         
            function gst(lnk) {

                    var txtAmountReceive = $(".amountgst")
//               
                
                var row = lnk.parentNode.parentNode;
                var rowIndex = row.rowIndex - 1;
                var a = txtAmountReceive[rowIndex].value;
//                                alert(a);
                if (a != null && a != '') {
                    var cgst = MathRound(a * (document.getElementById("Hdncgst").value / 100))
                    var sgst = MathRound(a * (document.getElementById("Hdnsgst").value / 100))
                    var igst = MathRound(a * (document.getElementById("Hdnigst").value / 100))
                    //                alert(document.getElementById("hdntds").value);
                   
                    //                var txtcgst = $("[id*=");
                    //                var txtcgst = $("[id*=");
                    //                var txtigst = $("[id*=");
                    //                var txtcgst = $("[id*=");

                    var txtCgst = $("[id*=txtgCgst]")
                    var txtSgst = $("[id*=txtgScgst]")
                    var txtIgst = $("[id*=txtgIgst]")

                    var state = $('input[name="Rd_Bill_Type"]:checked').val();
//                    alert(state)
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
                   
                    calculate()


                    var totalamount = $("[id*=txtamounttotal").val()
//                   
                    var totalcgst = $("[id*=txtcgsttotal]").val()
                    var totalsgst = $("[id*=txtsgsttotal]").val()
                    var totaligst = $("[id*=txtigsttotal]").val()
//                   alert(totalcgst)
                    var grandtotal, Nettotal
                    
                    grandtotal = MathRound(parseFloat(totalamount) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst))
                    Nettotal = MathRound(parseFloat(totalamount) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst))



                    $("#txtGrandtotal").val(grandtotal)
                                 

                    $("#txtNetamt").val(Nettotal)
                    $("[id*=txtgCgst]").attr('readonly', 'readonly');
                    $("[id*=txtgScgst]").attr('readonly', 'readonly');
                    $("[id*=txtgIgst]").attr('readonly', 'readonly');
                  
                }
//                
            }
            function MathRound(number) {
                var result = Math.round((number + Number.EPSILON) * 100) / 100;
                return result;
                alert('a')
            }

        $(function () {

            $(".Search").autocomplete({
                source: function (request, response) {
                    //                     var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Billing_Charge_Master_List",
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
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/File_Ref_No",
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
    <script  type="text/javascript">
        function calculate() {
            var txtTotal = 0.00, txtigtot = 0.00, txtsgtot = 0.00, txtcgtot = 0.00
         
            $(".amountgst").each(function (index, value) {
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
            
            //                alert(txtTotal)
           
                $("[id*=txtamounttotal]").val(txtTotal)
           
            $("[id*=txtcgsttotal]").val(txtcgtot)
            $("[id*=txtsgsttotal]").val(txtsgtot)
            $("[id*=txtigsttotal]").val(txtigtot)
           
        }
       
            </script>
     <script type="text/javascript">
        
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
                var txtsaccode = $("[id*=txtgSaccode]")
                //                $(".cgst").val(before);

                //                alert(document.getElementById("Hd_row_id").value);

                //                var Hd_Company_Id = document.getElementById("Hd_Company_Id").value;

                if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

                    var s = data.split('~~');
                    var cgst = s[0];
                    var sgst = s[1];
                    var igst = s[2]; //****New Implementation by Elaiyaa on 26Jun2019*********//
//                    var tds = s[3];
                    var saccode = s[3];   //line 6.1
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
                        txtTaxrate[document.getElementById("Hd_row_id").value].value = parseFloat(igst);
                    }
                    $("[id*=txtgTaxrate]").attr('readonly', 'readonly');
                    $("[id*=txtgSaccode]").attr('readonly', 'readonly');
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
       
    </script>
    
</body>
</html>
