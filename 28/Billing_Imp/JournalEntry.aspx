<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JournalEntry.aspx.cs" Inherits="PaymentEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Payments </title>
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
    <style type="text/css">
        input.underlined
        {
            border: solid 1px #000;
        }
    </style>

     <script language="javascript">
         function B_G_tab_page2() {

             document.getElementById('page-1').style.display = 'Block';
           
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'block';
             
         }
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
          $(function () {
              $("[id*=gv_Chg_Details] td").bind("click", function () {
                  var row = $(this).parent();
                  $("[id*=gv_Chg_Details] tr").each(function () {
                      if ($(this)[0] != row[0]) {
                          $("td", this).removeClass("selected_row");
                      }
                  });
                  $("td", row).each(function () {
                      if (!$(this).hasClass("selected_row")) {
                          $(this).addClass("selected_row");
                      } else {
                          $(this).removeClass("selected_row");
                      }
                  });
              });
          });


        
    </script>

   
    <script >
        $(function () {
            $("[id*=gv_Chg_Details]").find("[id*=txtCR_DR]").focusout(function () {
                var row = $(this).closest("tr");
                var value = $(this).val();
                if (value == "DR") {
                    row.find("[id*=txtCredit]").val('');
                    row.find("[id*=txtCredit]").attr("disabled", "true");
                    row.find("[id*=txtDebit]").removeAttr("disabled");
                }
                else if (value == "CR") {
                    row.find("[id*=txtDebit]").val('');

                    row.find("[id*=txtDebit]").attr("disabled", "true");
                    row.find("[id*=txtCredit]").removeAttr("disabled");

                }
            });

            $("[id*=gv_Chg_Details]").find("[id*=txtCR_DR]").change(function () {
                var row = $(this).closest("tr");
                var value = $(this).val();
                if (value == "DR") {
                    row.find("[id*=txtCredit]").val('');

                    row.find("[id*=txtCredit]").attr("disabled", "true");
                    row.find("[id*=txtDebit]").removeAttr("disabled");
                }
                else if (value == "CR") {
                    row.find("[id*=txtDebit]").val('');

                    row.find("[id*=txtDebit]").attr("disabled", "true");
                    row.find("[id*=txtCredit]").removeAttr("disabled");

                }
            });

            $("[id*=gv_Chg_Details]").find("[id*=txtCurrency]").focusout(function () {
                var row = $(this).closest("tr");
                var value = $(this).val();
                if (value == "INR") {
                    row.find("[id*=txtBillAmount]").val('');
                    row.find("[id*=txtBillAmount]").attr("disabled", "true");

                }
                else {

                    row.find("[id*=txtBillAmount]").removeAttr("disabled");
                }
            });

            $("[id*=gv_Chg_Details]").find("[id*=txtCurrency]").change(function () {
                var row = $(this).closest("tr");
                var value = $(this).val();
                if (value == "INR") {
                    row.find("[id*=txtBillAmount]").val('');
                    row.find("[id*=txtBillAmount]").attr("disabled", "true");

                }
                else {

                    row.find("[id*=txtBillAmount]").removeAttr("disabled");
                }
            });
        });

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
            <div id="innerbox_MidMain" style="height: 95px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                        Journal-Entry
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;display:none">
                        <div id="txtcon-m_Exchange" style="width: 180px;">
                            <asp:RadioButtonList ID="Rd_Job_Type" runat="server" RepeatDirection="Horizontal">
                                
                                <asp:ListItem Text="Imp" Value="Imp" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Exp" Value="Exp"></asp:ListItem>
                                <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                  
                    <div id="tag_transac_lft_in2" style="display:none">
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
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1100px">
                    <div id="tag_Exchange_inner_lft" style="width: 1100px">
                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div style="width: 1100px; height: 150px;">
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Voucher Type
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 85px">
                                       <asp:TextBox ID="txtVoucherType" runat="server"  MaxLength="50" CssClass="txtbox_none_Mid_transac_Inv_No"
                                     onblur="ChangeCase(this);"  Text="JV"     TabIndex="4"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Voucher No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 85px">
                                         <asp:TextBox ID="txtVoucherNo" runat="server"  MaxLength="50" CssClass="txtbox_none_Mid_transac_Inv_No"
                                      onblur="ChangeCase(this);"      TabIndex="4"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Voucher Date
                                    </div>
                                    <div id="txtcon-m_Exchange">
                                        <asp:TextBox ID="txtVoucherDate" runat="server" MaxLength="10" TabIndex="3" CssClass="txtbox_none_Mid_transac_Inv_No"></asp:TextBox>

                                          <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtVoucherDate"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtVoucherDate"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                              
                                <div id="txt_container_Transact_Main_l">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Narration
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 85px">
                                      
                                                <asp:TextBox ID="txtCommNarration" runat="server" MaxLength="1000" TextMode="MultiLine" onblur="ChangeCase(this);"
                                                Style="width: 411px; height: 30px" TabIndex="18"></asp:TextBox>
                                    </div>
                                </div>
                             
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="content" id="page-1" style="margin-top: -28px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 450px; width: 1290px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"  id="Page_A" runat="server">
                        <span>General </span></a></li>
                       <%-- <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');"
                            id="Page_B" runat="server"   ><span>Journal History</span></a></li>--%>
                       <%-- <li ><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server" visible="false">
                        <span>Gen -3</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        <span> Gen -4 </span></a></li>--%>
                    </ol>
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 380px;
                            margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1150px; height: 200px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1000px">
                                    
                                  
                                
                             
                                <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 428px;
                                    width: 1290px; margin-top: -10px; margin-left: -18px;">
                                    <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                        AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" 
                                        ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                                        AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                        OnRowDataBound="gv_Chg_Details_RowDataBound" OnRowDeleting="gv_Chg_Details_RowDeleting"
                                        Style="overflow-x: hidden; overflow-y: auto;" OnRowCreated="gvAll_RowCreated" OnRowCommand="gv_Chg_Details_RowCommand" >
                                        <RowStyle BorderWidth="0.1em" BorderColor="black" Height="50px" />
                                        <Columns>
                                        
                                            <asp:TemplateField HeaderText="" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk_inv" runat="server" HeaderText="chkSelect" Width="30px" />
                                                    
                                                </ItemTemplate>
                                                <ItemStyle Width="30px" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="CR/DR" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCR_DR" CssClass=" ddlType" placeholder="Enter CR/DR" MaxLength="2"
                                             onblur="ChangeCase(this);"           runat="server" Height="20px" Width="50px" Font-Size="12px" ReadOnly="false" Text='<%# Bind("DR_CR") %>' ></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="70px" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Head" HeaderStyle-Font-Bold="true" HeaderStyle-Width="230px">
                                                <ItemTemplate>                                                                                                
                                             

                                                    <asp:TextBox ID="txtchargehead" CssClass=" Search" placeholder="Enter Charges"  
                                             onblur="ChangeCase(this);Calculation(this);"       runat="server" Height="20px" Width="230px" Font-Size="12px" Text='<%# Bind("CHARGE_NAME") %>' ClientIDMode="Static" 
                                                    AutoPostBack="false"   ></asp:TextBox>



                                                </ItemTemplate>
                                                <ItemStyle Width="250px" />
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Bill No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                                <ItemTemplate>                                                                                                
                                              
                                                    <asp:TextBox ID="txtBill_inv_No" CssClass="billinv" placeholder="Enter Bill No"  
                                              onblur="ChangeCase(this);"      runat="server" Height="20px" Width="140px" Font-Size="12px" Text='<%# Bind("BILL_NO") %>' ClientIDMode="Static" AutoPostBack="false"  onfocusout="Bill_Details_Finder(this)" ></asp:TextBox>



                                                </ItemTemplate>
                                                <ItemStyle Width="170px" />
                                            </asp:TemplateField>


                                            
                                            <asp:TemplateField HeaderText="Bill Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBill_inv_date" CssClass="test" placeholder="" runat="server" ReadOnly="false"
                                                        Text='<%# Bind("BILL_DATE") %>' Height="20px" Width="70px" Font-Size="12px" ></asp:TextBox>

                                                         <asp:MaskedEditExtender ID="MaskedEditExtender41" runat="server" TargetControlID="txtBill_inv_date"
                                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                        Enabled="True" >
                                                    </asp:MaskedEditExtender>
                                                    <asp:CalendarExtender ID="CalendarExtender42" runat="server" TargetControlID="txtBill_inv_date"
                                                        Format="dd/MM/yyyy" Enabled="True">
                                                    </asp:CalendarExtender>

                                                </ItemTemplate>
                                                <ItemStyle Width="90px" />
                                            </asp:TemplateField>                                             
                                            <asp:TemplateField HeaderText="File Ref No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="140px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtFilerefno" CssClass=" Fileref" placeholder="" runat="server" ReadOnly="false"
                                               onblur="ChangeCase(this);"      Text='<%# Bind("FILE_REF_NO") %>'   onfocusout="cusname(this)"                                                 
                                                        Height="20px" Width="140px" Font-Size="12px" style="text-align:right;"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="170px" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="View" HeaderStyle-Font-Bold="true" HeaderStyle-Width="140px">
                                                <ItemTemplate>
                                                   <asp:Button runat="server" ID="btnview"  Width="50px"  Font-Size="Small" 
                                                        CssClass="coma4" Visible="true" Text="View" CommandName="View" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>


                                                </ItemTemplate>
                                                <ItemStyle Width="170px" />
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtAmount"  placeholder="" runat="server" ReadOnly="false"
                                                     Text='<%# Bind("AMOUNT") %>'                      CssClass="validate[custom[number]] "
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtAmount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"                                
                                                        Height="20px" Width="70px" Font-Size="12px" style="text-align:right;"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="90px" />
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Currency" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCurrency" CssClass=" Currency" placeholder="" runat="server" ReadOnly="false"
                                             onblur="ChangeCase(this);"        Text='<%# Bind("CURRENCY") %>'   MaxLength="3"                                                 
                                                        Height="20px" Width="70px" Font-Size="12px" style="text-align:right;"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="90px" />
                                            </asp:TemplateField>

                                                          <asp:TemplateField HeaderText="Ex.Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtExRate" placeholder="" runat="server" ReadOnly="false"
                                                     Text='<%# Bind("EX_RATE") %>'                            CssClass="validate[custom[number]] "
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtExRate');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"                          
                                                        Height="20px" Width="70px" Font-Size="12px" style="text-align:right;"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="90px" />
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Bill Amount(FC)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="170px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtBillAmount"  placeholder="" runat="server" ReadOnly="false"
                                                     Text='<%# Bind("BILL_AMOUNT") %>'   CssClass="validate[custom[number]] "
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtBillAmount');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"                                                  
                                                        Height="20px" Width="170px" Font-Size="12px" style="text-align:right;"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="190px" />
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Debit" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDebit"  placeholder="" runat="server" ReadOnly="false"
                                                     Text='<%# Bind("DEBIT") %>'         CssClass="validate[custom[number]] "
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtDebit');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"                                            
                                                        Height="20px" Width="70px" Font-Size="12px" style="text-align:right;"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="90px" />
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Credit" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCredit"  placeholder="" runat="server" ReadOnly="false"
                                                     Text='<%# Bind("CREDIT") %>'             CssClass="validate[custom[number]] "
                                        onblur="extractNumber(this,5,false);remove_zero_after_decimal_point(this.value,'txtCredit');"
                                        onkeyup="extractNumber(this,5,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"                                        
                                                        Height="20px" Width="70px" Font-Size="12px" style="text-align:right;"></asp:TextBox>
                                                </ItemTemplate>
                                                <ItemStyle Width="90px" />
                                            </asp:TemplateField>
                <%--//////////////////////////////////////////////////////////////////////////////--%>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgRemove" runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                              CommandName="DeleteRow"    ImageUrl="../images/icons/delete-sign.png" Width="20px" />
                                                    <%--<img src="../js/delete-sign.png" />
                                                                <asp:LinkButton ID="Lkbremove" runat="server" Font-Size="Small" OnClientClick="return RemoveRow(this)">Remove</asp:LinkButton>--%>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Button ID="Button2" runat="server" Width="40px" CommandName="add" Font-Size="Small"
                                                        CssClass="coma" Visible="true" Text="Add" OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField DeleteImageUrl="../js/delete-sign.png" />
                <%--//////////////////////////////////////////////////////////////////////////////--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <%--------------------------------------Row End-----------------------------------------%>
                            </div>
                        </div>
                    </div>

                         <div  class="content"  id="page-7"  style="display:none;height:440px;" >
                        
                            <style type="text/css">
                                      input.underlined
                                        {
                                           border:solid 1px #000;
                                        }
                                        </style>
                             <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 305px;display:none;
                                 width: 1094px; margin-top: 10px; margin-left: -18px;">
                                 <asp:GridView runat="server" ID="gvPaymentdetails" EmptyDataText="NO RECORD FOUND"
                                     AutoGenerateColumns="true" CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="false"
                                     Width="100%"   OnRowDataBound="gvPaymentdetails_RowDataBound"
                                     CellPadding="1" CellSpacing="1" OnRowCreated="gvAll_RowCreated">
                                     <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                         CssClass="column_style_left" BorderWidth="1px" />
                                     <HeaderStyle Font-Underline="false" ForeColor="Black" />
                                     <Columns>
                                         <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="45px">
                                             <ItemTemplate>
                                                 <%#Container.DataItemIndex+1 %>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                 </asp:GridView>



                             <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White" BorderStyle="None"
                                ForeColor="White" ></asp:TextBox>
                                 
                                  <p id="pTotal" style="color:Red; font-size:large;">
                            </div>
 
     <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 290px;">
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                    Total Bill Amt Received:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                   <asp:TextBox ID="txtTotBillAmt" runat="server"   BackColor="#F5F5F5" Width="120px" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="100" ReadOnly="true" ></asp:TextBox>
                                </div>
                            </div>
                           <div id="txt_container_Transact_Main_l"   style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 135px">
                                  Total TDS:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px">
                                    <asp:TextBox ID="txtTotTDSAmt" runat="server" BackColor="#F5F5F5" Width="100px" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No"   ReadOnly="true" ></asp:TextBox>
                                </div>
                            </div>
                              <div id="txt_container_Transact_Main_l" style="width: 280px">
                                <div id="tag_label_transact_Src" style="width: 155px">
                                 Total Received:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                    <asp:TextBox ID="txtFinalReceivedAmt" Width="100px"  runat="server"  ReadOnly="true"  
                                    CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                                     
                                </div>
                            </div>
                             <div id="txt_container_Transact_Main_l" style="width: 280px">
                                <div id="tag_label_transact_Src" style="width: 155px">
                                 Total WriteOff:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                    <asp:TextBox ID="txtTotWriteOff" Width="100px"  runat="server"   CssClass="txtbox_none_Mid_transac_Inv_No"  ReadOnly="true" ></asp:TextBox>
                                     
                                </div>
                            </div>
                        
                        </div>
                    </div>

                </div>
            </div>
            <%-- --------------------Test Start----------------------------%>
            <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            TabIndex="22" OnClick="btnNew_Click1"  />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate_JournalEntry();"
                            TabIndex="20" OnClick="btnSave_Click" CommandName="s" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate_JournalEntry();" TabIndex="21" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="23" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Payment?', 'Payments', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="123" OnClick="btnDelete_Click" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                            id="btnCancel" tabindex="20">
                    </div>
                    <div id="editbu" style="width: 10px;">
                    </div>
                    <div id="editbu" style="padding-top: 5px;">
                        <asp:Button ID="btnrpt" runat="server" TabIndex="125" Text="Get Bill" OnClientClick="return GST_Import_Billing_Job_Rpt('B');" />
                        <%--OnClientClick="return Import_Billing_Job_Rpt('B');"--%>
                    </div>
                </div>
            </div>
            <%-- --------------------Test End----------------------------%>
            </div>

             <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px; overflow: hidden;">
                         
                    </div>
                </div>
                <div class="content" id="page-3">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 350px;
                        width: 980px; overflow: hidden;">
                         page-3
                    </div>
                </div>
                <div class="content" id="page-4">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                       page-4
                    </div>
                </div>

            <script src="../activatables.js" type="text/javascript"></script>
                <script type="text/javascript">
                    activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="Hd_Other_Branch_no" runat="server" />
            <asp:HiddenField ID="Hd_row_id" runat="server" />
              <asp:Button ID="btnShowPopup" runat="server" style="display:none" />
                                                 
              <cc1:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="btnShowPopup" PopupControlID="MessageDivupdated_Job"
        BackgroundCssClass="modalBackground" DropShadow="false" CancelControlID="btnCloses">
    </cc1:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
       
                 <div id="innerbox_MidMain_Trans_new" style="height: 325px; width:790px;margin-top:-230px;margin-left:-10px"> 

                  <div id="popupwindow_closebut_right_new">
                                <asp:Button ID="btnCloses" runat="server"  CssClass="clsicon_new" 
                                CausesValidation="false"    UseSubmitBehavior="false" />
                                
                    </div>
                <div id="tag_srcinner1grid_table_Container" style="width: 770px;height:301px;">
                <div id="Main_Grid_Container" style="overflow:hidden;height:301px;" runat="server" >
                    <asp:GridView runat="server" ID="gvdetails" DataKeyNames="JOBNO,BRANCHCODE,WORKINGPERIOD" EmptyDataText="NO RECORD FOUND" 
                        AutoGenerateColumns="False" Width="100%" CssClass="grid-view" ShowHeader="true" 
                        ShowHeaderWhenEmpty="true" AllowPaging="True" OnRowDataBound="gvdetails_RowDataBound"
                        AllowSorting="True" CellPadding="1" CellSpacing="1" OnRowCreated="gvdetails_RowCreated" 
                        PageSize="23"  >
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                        <Columns>
                        <asp:CommandField ShowSelectButton="True">
                                       <HeaderStyle CssClass="hideGridColumn" />
                                       <ItemStyle CssClass="hideGridColumn" />
                                   </asp:CommandField>
                             
                            <asp:BoundField DataField="TRANSPORT_MODE" HeaderText="MODE"     ControlStyle-Width="120px" HeaderStyle-Width="120px" >
                                <ItemStyle CssClass="column_style_left5"  Width="120px" Font-Size="12px" /> <%--column_style_left6--%>
                            </asp:BoundField>

                            <asp:BoundField DataField="TYPE" HeaderText="TYPE"   HeaderStyle-Width="120px" ControlStyle-Width="120px"  >
                                    <ItemStyle CssClass="column_style_left5" Width="120px" Font-Size="12px" />
                            </asp:BoundField>

                             <asp:BoundField DataField="JOBNO" HeaderText="JOB NO"   HeaderStyle-Width="130px" ControlStyle-Width="130px" >
                                <ItemStyle CssClass="column_style_left5" Width="130px" Font-Size="12px" />
                            </asp:BoundField>

                           

                            <asp:BoundField DataField="BRANCHCODE"   HeaderText="BRANCH" ControlStyle-Width="98px" HeaderStyle-Width="80px" >
                                <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px"  />
                            </asp:BoundField>

                             

                            <asp:BoundField DataField="WORKINGPERIOD"   HeaderText="FY.YEAR" ControlStyle-Width="98px" HeaderStyle-Width="80px" >
                                <ItemStyle CssClass="column_style_left5" Width="70px" Font-Size="12px"  />
                            </asp:BoundField>



                       
                        </Columns>
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
          
               </div>
              
               </div>
                   
        </asp:Panel>
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

    
<script  type="text/javascript">
    function Bill_Details_Finder(lnk) 
    {
        //                alert('hi');
        var grid = document.getElementById("<%= gv_Chg_Details.ClientID%>");
        var funtxtBill_inv_no = $(".billinv")
        var row = lnk.parentNode.parentNode;
        var rowIndex = row.rowIndex - 1;
        var a = funtxtBill_inv_no[rowIndex].value;
                        //alert(a);   // BILL NO DISPLAY
        var b = '1';
        $('#Hd_row_id').val(rowIndex);
        //Cha_cus(a, b);
        
        Bill_Start(a, b);
    }  
  
   


    function BillFaileda(res, destCtrl) 
    {
    }

</script>
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

            $(".Currency").autocomplete({
                source: function (request, response) {
                    //                     var field = $(this.element).attr('id');

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Exchage_Master_List",

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

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Vendor_Branch_List",
                        data: "{ 'mail': '" + request.term + "' }",
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
   
     <script type="text/javascript">
         function Excel_download() {
             var txtvoucherno = $("[id*=txtVoucherno]")
             var Type = 'excel';
             win = window.open('../FlatFile/MIS_report_1.aspx?Excel_Download_XLs=Yes&voucherno=' + txtvoucherno + '', 'ndf');
             Loading_HideImage();
         }
         function Calculation(lnk) {
             //            $(function () {
             //             $("[id*=gv_Chg_Details]").find("[id*=txtgCharHead]").blur(function () {

             //            //Reference the GridView Row.
             //            var row = $(this).closest("tr");
             // 
             //            var a= row.find("td").eq(6).html();

             var grid = document.getElementById("<%= gv_Chg_Details.ClientID%>");
             var txtAmountReceive = $(".Search")
             //             var txtAmountReceive = $("[id*=txtgCharHead]")
             //             alert(txtAmountReceive);
             //             var txtAmountReceive_2 = $("[id*=ddl_tax_nontax]")
             var row = lnk.parentNode.parentNode;

             var rowIndex = row.rowIndex - 1;
             //             var a = "AAI EXPENSES";
             //             alert(rowIndex);
             //             var a = "gv_Chg_Details_" + "txtgCharHead_" + rowIndex.value;
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
                    var tds = s[3];
                    var saccode = s[4];   //line 6.1
                    //                    var tempSGST_RATE = s[4];     //line 6.2
                    //                    var tempIGST_RATE = s[5];     //line 6.3
                    //                    alert(before
                    //                    $(".cgst").val(before);

                    //                    alert(txttds[document.getElementById("Hd_row_id").value]);
                    txtsaccode[document.getElementById("Hd_row_id").value].value = saccode;
                    txtTaxrate[document.getElementById("Hd_row_id").value].value = parseFloat(cgst) + parseFloat(sgst) + parseFloat(igst);
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
            function gst(lnk) {

                var txtAmountReceive = $(".debitgst")
                var row = lnk.parentNode.parentNode;
                var rowIndex = row.rowIndex - 1;
                var a = txtAmountReceive[rowIndex].value;
                //                alert(a);
                var cgst = a * (document.getElementById("Hdncgst").value / 100)
                var sgst = a * (document.getElementById("Hdnsgst").value / 100)
                var igst = a * (document.getElementById("Hdnigst").value / 100)
                //                alert(document.getElementById("hdntds").value);
                var tds = document.getElementById("hdntds").value;
                var tdsamt = a * (document.getElementById("hdntds").value / 100);
                //                var txtcgst = $("[id*=");
                //                var txtcgst = $("[id*=");
                //                var txtigst = $("[id*=");
                //                var txtcgst = $("[id*=");

                var txtCgst = $("[id*=txtgCgst]")
                var txtSgst = $("[id*=txtgScgst]")
                var txtIgst = $("[id*=txtgIgst]")
                var txttds = $("[id*=txtgTds]")
                var txtdtsamt = $("[id*=txtgdtsamt]")
                txtCgst[document.getElementById("Hd_row_id").value].value = cgst;
                txtSgst[document.getElementById("Hd_row_id").value].value = sgst
                txtIgst[document.getElementById("Hd_row_id").value].value = igst
                txttds[document.getElementById("Hd_row_id").value].value = tds;
                txtdtsamt[document.getElementById("Hd_row_id").value].value = tdsamt;
                calculate()


                //                var totalcredit = $("[id*=txtcredittotal")
                var totaldebit = $("[id*=txtdebittotal]").val()
                var totalcgst = $("[id*=txtcgsttotal]").val()
                var totalsgst = $("[id*=txtsgsttotal]").val()
                var totaligst = $("[id*=txtigsttotal]").val()
                var totaltds = $("[id*=txttdstotal]").val()
                var grandtotal = parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) + parseFloat(totaltds)
                //                alert(totaldebit)
                $("#txtGrandtotal").val(grandtotal)
                var Nettotal = parseFloat(totaldebit) + parseFloat(totalcgst) + parseFloat(totalsgst) + parseFloat(totaligst) - parseFloat(totaltds)
                $("#txtNetamt").val(Nettotal)


                //                
            }
            function tap() {

                $("[id*=drpImpexp]").focus();
            }

            function cusname(lnk) {
                //                alert('hi');
                var grid = document.getElementById("<%= gv_Chg_Details.ClientID%>");
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
                //                var txtdebit=$("[id*=txtgDebit]")
                //                var txtcredit=$("[id*=txtgCredit]")
                //                alert(a)
                if (a == 'CR') {
                    $("[id*=txtgDebit]")[rowIndex].attr('disabled', 'disabled');
                    $("[id*=txtgCredit]")[rowIndex].removeAttr('disabled');
                }
                else if (a == 'DR') {
                    $("[id*=txtgCredit]")[rowIndex].attr('disabled', 'disabled');
                    $("[id*=txtgDebit]")[rowIndex].removeAttr('disabled');
                }

            }
    </script>
    <script  type="text/javascript">
        function calculate() {
            var txtTotal = 0.00, txttdstot = 0.00, txtigtot = 0.00, txtsgtot = 0.00, txtcgtot = 0.00
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
            $("[id*=txtdebittotal]").val(txtTotal)
            $("[id*=txtcgsttotal]").val(txtcgtot)
            $("[id*=txtsgsttotal]").val(txtsgtot)
            $("[id*=txtigsttotal]").val(txtigtot)
            $("[id*=txttdstotal]").val(txttdstot)
        }
        function MathRound(number) {
            var result = Math.round(number * 100) / 100;
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
            if (validformat.test(txt) == false && txt != "") {
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
            PageMethods.Get_Vendordetail(txtVendorname, '', '', CallSuccess_vendordetail, CallFailed_vendordetail, dest);

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
                    ////                alert(state);
                    $("#txtVendorstate").val(state);
                    $("#txtGstn").val(Gstn);
                    $("#txtGstntype").val(GstnType);
                    $("#txtCountry").val(country);
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

        $(document).ready(function () {

            Bind_CR_DR();

        });

        function Bind_CR_DR() {
            var Notn = ['CR', 'DR'];

            $('.ddlType').autocomplete({
                source: Notn,
                minLength: 0,
                scroll: true
            }).focus(function () {
                $(this).autocomplete("search", "");
            });
        }
      
    </script>
     
</body>
</html>
