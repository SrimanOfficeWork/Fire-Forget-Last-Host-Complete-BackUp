<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Payment_Request_Entry.aspx.cs"
    Inherits="Accounts_Cash_Payment_Request_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Payment Request Entry </title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //Enable/Disable all TextBoxes when Header Row CheckBox is checked
            $("[id*=chkAll]").bind("click", function () {
                var chkHeader = $(this);

                //Find and reference the GridView.
                var grid = $(this).closest("table");

                //Loop through the CheckBoxes in each Row.
                $("td", grid).find("input[type=checkbox]").each(function () {

                    //If Header CheckBox is checked.
                    if (chkHeader.is(":checked")) {
                        $(this).attr("checked", "checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#D8EBF2" });
                        $("input[type=text]", td).removeAttr("disabled");

                        // --- COPY HC &#8594; TC ---
                        var hc = $("input[id*=txtAmount_HC]", td).val();
                        $("input[id*=txt_Amount_TC]", td).val(hc);

                    } else {
                        $(this).removeAttr("checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#FFF" });
                        $("input[type=text]", td).attr("disabled", "disabled");

                        // Clear TC
                        $("input[id*=txt_Amount_TC]", td).val("");
                    }
                });
                updateFooterTotals();
            });
        });
    </script>
    <script type="text/javascript">
        $(function () {
            //Enable/Disable TextBoxes in a Row when the Row CheckBox is clicked
            $("[id*=chk]").bind("click", function () {

                var grid = $(this).closest("table");
                var chkHeader = $("[id*=chkAll]", grid);
                var td = $("td", $(this).closest("tr"));

                if (!$(this).is(":checked")) {
                    td.css({ "background-color": "#FFF" });
                    $("input[type=text]", td).attr("disabled", "disabled");

                    // Clear TC
                    $("input[id*=txt_Amount_TC]", td).val("");

                } else {
                    td.css({ "background-color": "#D8EBF2" });
                    $("input[type=text]", td).removeAttr("disabled");

                    // --- COPY HC &#8594; TC ---
                    var hc = $("input[id*=txtAmount_HC]", td).val();
                    $("input[id*=txt_Amount_TC]", td).val(hc);
                }

                // Enable Header Row CheckBox if all the Row CheckBoxes are checked
                if ($("[id*=chk]", grid).length == $("[id*=chk]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                } else {
                    chkHeader.removeAttr("checked");
                }
                updateFooterTotals();
            });
        });


        function updateFooterTotals() {
            var totalTC = 0;
            var totalHC = 0;

            $("#gv_JIE_Leg input[id*=txt_Amount_TC]").each(function () {
                if ($(this).closest("tr").find("input[id*=chk]").is(":checked")) {
                    var val = parseFloat($(this).val()) || 0;
                    totalTC += val;
                }
            });

            $("#gv_JIE_Leg input[id*=txtAmount_HC]").each(function () {
                if ($(this).closest("tr").find("input[id*=chk]").is(":checked")) {
                    var val = parseFloat($(this).val()) || 0;
                    totalHC += val;
                }
            });

            // Update footer labels
            $("#gv_JIE_Leg span[id*=lblTotalTC]").text(totalTC.toFixed(2));
            $("#gv_JIE_Leg span[id*=lblTotalHC]").text(totalHC.toFixed(2));
            $("#txt_Amount").val(totalTC.toFixed(2));

        }

</script>
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
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
            <div id="innerbox_MidMain_Billing" style="height: 150px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                        Payment Request
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                        <div id="txtcon-m_Exchange" style="width: 220px; margin-top: 5px;">
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
                <div id="tag_transact_src_inner" style="width: 1150px; height: 110px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 100px;">
                        <div id="tag_transact_lft_in1" style="width: 1150px; height: 90px;">
                            <div style="width: 1150px; height: 30px">
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Pay To
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:DropDownList ID="ddlpayto" class="validate[required]  chosen-select-deselect"
                                            Style="width: 110px;" data-placeholder="Choose a Pay To" runat="server" TabIndex="1"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlpayto_SelectedIndexChanged">
                                            <asp:ListItem Text="Vendor" Value="V"></asp:ListItem>
                                            <asp:ListItem Text="Employee" Value="E"></asp:ListItem>
                                            <asp:ListItem Text="Transporter" Value="T"></asp:ListItem>
                                            <asp:ListItem Text="Other Entity" Value="O"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 410px;">
                                        <asp:DropDownList ID="ddlpay_Cusname" class="validate[required]  chosen-select-deselect"
                                            Style="width: 390px;" runat="server" TabIndex="2" AutoPostBack="true" OnSelectedIndexChanged="ddlpay_Cusname_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Reference No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 210px;">
                                        <asp:TextBox ID="txt_BP_R_No_F" runat="server" TabIndex="3" ReadOnly="true" BackColor="#e7e6e6"
                                            Width="35px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                        <asp:TextBox ID="txt_BP_R_M" runat="server" TabIndex="3" ReadOnly="true" BackColor="#e7e6e6"
                                            Style="text-align: right;" Width="60px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                        <asp:TextBox ID="txt_BP_R_L" runat="server" TabIndex="3" ReadOnly="true" BackColor="#e7e6e6"
                                            Width="60px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 55px;">
                                        Date
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txtRefDate" runat="server" Width="130px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            BackColor="#e7e6e6" TabIndex="4"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtRefDate"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtRefDate"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Against
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:DropDownList ID="ddl_Against" Style="width: 140px;" runat="server" TabIndex="6"
                                            onchange="togglePurchaseDiv();">
                                            <asp:ListItem Text="Expense" Value="E"></asp:ListItem>
                                            <asp:ListItem Text="Advance" Value="A"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 370px;">
                                        <asp:RadioButtonList ID="Rd_Job_Non_Exp" TabIndex="7" runat="server" RepeatDirection="Horizontal"
                                            onchange="toggleGeneralMenu();">
                                            <asp:ListItem Text="Job Expenses" Value="J" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Non Job Expenses" Value="NJ"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Mode of Payment
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 110px;">
                                        <asp:DropDownList ID="ddl_Mode_of_Payment" Style="width: 100px;" runat="server" TabIndex="7">
                                            <asp:ListItem Text="Cash" Value="CA"></asp:ListItem>
                                            <asp:ListItem Text="Cheque No." Value="CN"></asp:ListItem>
                                            <asp:ListItem Text="NEFT" Value="NT"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Mark as Urgent
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 100px;">
                                        <asp:CheckBox ID="chk_Urgent" runat="server" TabIndex="8" />
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l_jO" runat="server" style="width: 940px;">
                                    <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 20px">
                                        <div id="tag_label_transact_Src" style="width: 90px;">
                                            Job No
                                        </div>
                                        <div id="txtcon-m_Exchange" style="width: 110px;">
                                            <asp:DropDownList ID="ddl_Imp_Exp" Style="width: 100px;" runat="server" TabIndex="9"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddl_Imp_Exp_SelectedIndexChanged">
                                                <asp:ListItem Text="Imp" Value="I"></asp:ListItem>
                                                <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div id="txtcon-m_Exchange" style="width: 410px;">
                                            <asp:DropDownList ID="ddlJobno" class="chosen-select-deselect" Style="width: 175px;"
                                                runat="server" TabIndex="10" onchange="setJobNo(this)" AutoPostBack="true" OnSelectedIndexChanged="ddlJobno_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtJobno_ps" Width="200px" CssClass="txtbox_none_Mid_transac_code"
                                                ReadOnly="true" TabIndex="11" runat="server"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transact_Src" style="width: 100px;">
                                            Amount
                                        </div>
                                        <div id="txtcon-m_Exchange" style="width: 230px;">
                                            <asp:TextBox ID="txt_Amount" Width="225px" CssClass="txtbox_none_Mid_transac_code"
                                                onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="12"
                                                runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 20px">
                                    <div id="tag_label_transact_Src" style="width: 90px;">
                                        Request To
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 200px;">
                                        <asp:DropDownList ID="ddlrequest" class="chosen-select-deselect" Style="width: 200px;"
                                            runat="server" TabIndex="13">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 320px; margin-top: -5px;">
                                        &nbsp; <a href="../Accounts_Others/PAYMENT_REQUEST_EXCEL_UPLOAD.xlsx" target="_new">
                                            <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"
                                                Height="30px" Width="30px" runat="server" /></a>
                                        <asp:Button ID="btngenexcel" runat="server" Width="82px" CausesValidation="false"
                                            UseSubmitBehavior="false" Visible="True" CssClass="autowidmovebut" Text="Excel Upload"
                                            Style="width: 85px; margin-left: -5px;" OnClientClick="jQuery('#form1').validationEngine('hide');open_PaymentRequest_Excel_Upload();return false;" />
                                        <asp:LinkButton ID="lnkOrg2" runat="server" Text="Payment Report" OnClientClick="return open_PR_RPT();">
                                        </asp:LinkButton>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        Narration
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 250px;">
                                        <asp:TextBox ID="txtNarration" Width="225px" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="14" runat="server"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 130px;">
                                        <asp:Button ID="btnsup" runat="server" TabIndex="15" OnClick="btn_Save_Update_Click" />
                                        &nbsp;
                                        <asp:Button ID="btn_PR_Delete" runat="server" TabIndex="16" Text="Delete" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job Entry?', 'Payment Request ', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn3').click();
                                          }
                                          else {
                                          }
    
                                });return false;" />
                                        <asp:Button ID="btn3" runat="server" TabIndex="17" OnClick="btn_PR_Delete_Click"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="Button3" runat="server" OnClick="Load_Excel_Click" Style="display: none" />
            <%--  <div class="content" id="page-1" style="margin-top: -28px;">--%>
            <div id="innerbox_MidMain_Trans_new" style="height: 400px; width: 1142px; margin-top: -19px;">
                <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page1(); return false;"
                        id="Page_A" runat="server"><span>General </span></a></li>
                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page2(); return false;"
                        id="Page_B" runat="server"><span>General</span> </a></li>
                </ol>
                <div class="content" id="page-6" style="height: 180px;">
                    <div id="innerbox_MidMain_Trans_new" style="height: 200px; width: 1142px; margin-left: -16px;
                        margin-top: -15px;">
                        <div id="tag_transact_lft_in1" style="width: 1138px; height: 200px; overflow: auto;">
                            <asp:GridView ID="gv_JIE_Leg" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" Font-Size="Small" BackColor="WhiteSmoke" BorderColor="#C8C8C8"
                                BorderStyle="Solid" BorderWidth="1px" OnRowCreated="gv_JIE_Leg_RowCreated" CellPadding="1"
                                CellSpacing="1" CssClass="myGridStyle" DataKeyNames="BILL_ID" EmptyDataText="NO RECORD FOUND"
                                PageSize="5000" ShowHeaderWhenEmpty="True" Width="120%" ShowFooter="True">
                                <RowStyle BorderWidth="0.1em" BorderColor="black" CssClass="myGridStyle" />
                                <HeaderStyle CssClass="header" BackColor="#808080" Font-Bold="True" ForeColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkAll" runat="server" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" Checked='<%# bool.Parse(Eval("Chk").ToString()) %>' runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="44px" BackColor="#CCCCCC" />
                                        <FooterStyle Width="44px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px"
                                        Visible="False">
                                        <ItemTemplate>
                                            <asp:Literal ID="txt_BILL" Text='<%# Bind("BILL_ID") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="190px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        <FooterStyle Width="190px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txt_ChargeName" Text='<%# Bind("Charge_Name") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            Total :
                                        </FooterTemplate>
                                        <ItemStyle Width="190px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                        <FooterStyle Width="580px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount(TC)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Amount_TC" Width="100px" Text='<%# Bind("Amount_TC") %>' Style="width: 100px;
                                                text-align: -moz-right;" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                                runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalTC" runat="server" Text="0" Style="display: inline-block;
                                                width: 100px; text-align: -moz-right;"></asp:Label>
                                        </FooterTemplate>
                                        <ItemStyle Width="190px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        <FooterStyle Width="190px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Curr" HeaderStyle-Font-Bold="true" HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txt_Cur" Text='<%# Bind("Curr") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="120px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        <FooterStyle Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount(HC)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAmount_HC" Text='<%# Bind("Amount_HC") %>' Width="100px" Style="background-color: #CCCCCC;
                                                borderwidth: 0px; border-width: thin; height: 18px; text-align: -moz-right;"
                                                runat="server" ReadOnly="true" />
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                                        <FooterTemplate>
                                            <asp:Label ID="lblTotalHC" runat="server" Text="0" Style="display: inline-block;
                                                width: 100px; text-align: -moz-right;"></asp:Label>
                                        </FooterTemplate>
                                        <FooterStyle Width="150px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Payable To" HeaderStyle-Font-Bold="true" HeaderStyle-Width="140px">
                                        <ItemTemplate>
                                            <asp:Literal ID="txt_Payable_To" Text='<%# Bind("Payable_To") %>' runat="server"></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="140px" HorizontalAlign="Left" BackColor="#CCCCCC" />
                                        <FooterStyle Width="580px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Remark" HeaderStyle-Font-Bold="true" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Remark" Width="300px" Text='<%# Bind("Remark") %>' runat="server"
                                                TabIndex="29" ForeColor="Black"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="300px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                        <FooterStyle Width="300px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-7" style="display: none; height: 180px;">
                    <div id="tag_transact_lft_in1" style="width: 1138px; height: 180px; overflow: auto;
                        margin-left: -13px;">
                        <asp:GridView ID="gv_details" runat="server" DataKeyNames="CHARGE_ID" EmptyDataText="NO RECORD FOUND"
                            AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                            ShowHeaderWhenEmpty="True" PageSize="15" AllowPaging="True" AllowSorting="True"
                            OnRowCreated="gv_details_RowCreated" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" CellPadding="1" CellSpacing="1">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <Columns>
                                <asp:TemplateField HeaderText="Edit/Update" HeaderStyle-Width="80px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkOrg" runat="server" Text="Edit" OnClientClick='<%# "return open_Acc_Payment_Charge_Entry_Upd(\"" + Eval("BP_R_ID") + "\", \"" + Eval("CHARGE_ID") + "\", \"I\");" %>'
                                            CommandName="SelectOrganization">
                                 </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle CssClass="column_style_left" Width="100px" Font-Size="12px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="BP_R_ID" HeaderText="Charge id">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CHARGE_ID" HeaderText="Charge id">
                                    <HeaderStyle CssClass="hideGridColumn" />
                                    <ItemStyle CssClass="hideGridColumn" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CHARGE_NAME" HeaderText="Charge Head">
                                    <ItemStyle CssClass="column_style_left" />
                                    <ItemStyle Width="520px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CUR" HeaderText="Curr">
                                    <ItemStyle CssClass="column_style_left" />
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PAY_AMOUNT" HeaderText="Amount TC">
                                    <ItemStyle CssClass="column_style_left" />
                                    <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="COST_CENTER" HeaderText="Cost Center">
                                    <ItemStyle CssClass="column_style_left" />
                                    <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PAYABLE_TO" HeaderText="Payable To">
                                    <ItemStyle CssClass="column_style_left" />
                                    <ItemStyle Width="350px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="REMARKS" HeaderText="Remarks">
                                    <ItemStyle CssClass="column_style_left" />
                                    <ItemStyle Width="300px" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div id="tag_transac_lft_IGM_Invoice_Grid_area" style="width: 975px; height: 25px;
                        border-style: none; overflow: hidden;">
                        <asp:LinkButton ID="linkCharge" runat="server" Text="New" OnClientClick="open_Acc_Payment_Charge_Entry();"
                            CommandName="SelectOrganization">
                        </asp:LinkButton>
                    </div>
                </div>
                <div id="tag_Purchase" runat="server">
                    <div id="tag_transact_lft_in1" style="width: 1138px; height: 275px; overflow: auto;">
                        <asp:GridView ID="gvAll_Pur" runat="server" AllowPaging="True" AllowSorting="True"
                            Font-Size="Small" AutoGenerateColumns="False" BackColor="WhiteSmoke" BorderColor="#C8C8C8"
                            BorderStyle="Solid" BorderWidth="1px" OnRowCreated="gv_JIE_Leg_RowCreated" CellPadding="1"
                            CellSpacing="1" CssClass="myGridStyle" DataKeyNames="BILL_ID" EmptyDataText="NO RECORD FOUND"
                            PageSize="5000" ShowHeaderWhenEmpty="True" Width="100%">
                            <RowStyle BorderWidth="0.1em" BorderColor="black" CssClass="myGridStyle" />
                            <HeaderStyle CssClass="header" BackColor="#808080" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="ischk" Checked='<%# bool.Parse(Eval("Chk").ToString()) %>' runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="44px" BackColor="#CCCCCC" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Purchase Bill No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px">
                                    <ItemTemplate>
                                        <asp:Literal ID="txt_Purchase_bill_No" Text='<%# Bind("Purchase_bill_No") %>' runat="server"></asp:Literal>
                                    </ItemTemplate>
                                    <ItemStyle Width="190px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px">
                                    <ItemTemplate>
                                        <asp:Literal ID="txt_Date" Text='<%# Bind("Date") %>' runat="server"></asp:Literal>
                                    </ItemTemplate>
                                    <ItemStyle Width="190px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Curr" HeaderStyle-Font-Bold="true" HeaderStyle-Width="140px">
                                    <ItemTemplate>
                                        <asp:Literal ID="txt_PayCurr" Text='<%# Bind("Curr") %>' runat="server"></asp:Literal>
                                    </ItemTemplate>
                                    <ItemStyle Width="120px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bill Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="150px">
                                    <ItemTemplate>
                                        <asp:Literal ID="txtAmount_HC" Text='<%# Bind("Bill_Amount") %>' runat="server"></asp:Literal>
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Outstanding Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="140px">
                                    <ItemTemplate>
                                        <asp:Literal ID="txt_Outstanding_Amount" Text='<%# Bind("Outstanding_Amount") %>'
                                            runat="server"></asp:Literal>
                                    </ItemTemplate>
                                    <ItemStyle Width="85px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount(TC)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_Amount_TC" Width="100px" Text='<%# Bind("Amount_TC") %>' runat="server"
                                            onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" Enabled="False"
                                            TabIndex="29" ForeColor="Black"></asp:TextBox>
                                    </ItemTemplate>
                                    <ItemStyle Width="120px" HorizontalAlign="Center" BackColor="#CCCCCC" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_bot_transact" style="margin-top: 0px; width: 500px;">
                <div id="innerbox_transac_bot_inn" style="width: 500px;">
                    <div id="newbu">
                        <asp:Button ID="btnNew1" runat="server" TabIndex="33" CssClass="new" OnClick="btnNew_Click"
                            OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                            Visible="false" UseSubmitBehavior="false" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave1" runat="server" CssClass="save" CommandName="s" OnClientClick="return validate();"
                            Visible="false" TabIndex="30" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate1" runat="server" CssClass="updates" ValidationGroup="dt"
                            Visible="false" TabIndex="31" OnClientClick="return validation();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete1" runat="server" Visible="false" TabIndex="32" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Payment', function(r) {
                  var i = r + 'ok';
                  if(i == 'trueok')
                  {
                      document.getElementById('btn').click();
            
                  }
                  else {
                  }
                    });return false;" />
                        <asp:Button ID="btn1" runat="server" TabIndex="53" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="Button1" runat="server" OnClick="Load_Click" Style="display: none" />
                    </div>
                </div>
            </div>
            <div id="tag_label_transact_Src" style="width: 300px">
                <asp:Label ID="lblTotalAdjustment" runat="server" Style="font-weight: bold; color: red;"></asp:Label>
            </div>
            </div> </div> </div>
            <%-- </div>--%>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HD_Ch_update_id" runat="server" />
            <asp:HiddenField ID="hf_Bal" runat="server" />
            <asp:HiddenField ID="Hd_row_id" runat="server" />
            <asp:HiddenField ID="Hidden_Auto" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/Accounts/Acc_iframepopupwin.js"></script>
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
    <script type="text/javascript">
        window.onload = function () {
            updateFooterTotals();
            togglePurchaseDiv();
            toggleGeneralMenu();
            var dropdown = document.getElementById('ddlJobno');
            if (dropdown) {
                setJobNo(dropdown);
            }
        }
        function setJobNo(dropdown) {
            var selectedValue = dropdown.value;
            document.getElementById('<%= txtJobno_ps.ClientID %>').value = selectedValue;
        }
</script>
    <script type="text/javascript">
        function tab_page2() {
            document.getElementById("page-7").style.display = 'Block';
            document.getElementById("page-6").style.display = 'none';
        }

        function tab_page1() {
            document.getElementById("page-7").style.display = 'none';
            document.getElementById("page-6").style.display = 'Block';

        }
</script>
    <script type="text/javascript">

        function open_Acc_Payment_Charge_Entry() {
            var noF = document.getElementById('<%= txt_BP_R_No_F.ClientID %>').value;
            var mid = document.getElementById('<%= txt_BP_R_M.ClientID %>').value;
            var last = document.getElementById('<%= txt_BP_R_L.ClientID %>').value;
            var Pay = document.getElementById('<%= ddlpay_Cusname.ClientID %>').value;
            var Payto = document.getElementById('<%= ddlpayto.ClientID %>').value;
            var ID = document.getElementById('<%= HDupdate_id.ClientID %>').value;
            if (ID != "") {
                var url = '../Accounts_Others/Payment_Request_Entry_Charge.aspx'
        + '?BP_R_No_F=' + encodeURIComponent(noF)
        + '&BP_R_M=' + encodeURIComponent(mid)
        + '&BP_R_L=' + encodeURIComponent(last)
        + '&Pay_Cusname=' + encodeURIComponent(Pay) + '&BP_R_ID=' + encodeURIComponent(ID) + '&Pay_to=' + encodeURIComponent(Payto);

                NewWindow1(url, '_blank', '850', '330', 'yes');
            } else {
                alert("Save Above Details First");

            }
        }

        function open_Acc_Payment_Charge_Entry_Upd(val1, val2) {
            var noF = document.getElementById('<%= txt_BP_R_No_F.ClientID %>').value;
            var mid = document.getElementById('<%= txt_BP_R_M.ClientID %>').value;
            var last = document.getElementById('<%= txt_BP_R_L.ClientID %>').value;
            var Pay = document.getElementById('<%= ddlpay_Cusname.ClientID %>').value;
            var Payto = document.getElementById('<%= ddlpayto.ClientID %>').value;

            var url = '../Accounts_Others/Payment_Request_Entry_Charge.aspx'
        + '?BP_R_No_F=' + encodeURIComponent(noF)
        + '&BP_R_M=' + encodeURIComponent(mid)
        + '&BP_R_L=' + encodeURIComponent(last)
        + '&Pay_Cusname=' + encodeURIComponent(Pay) + '&BP_R_ID=' + encodeURIComponent(val1)
        + '&CHARGE_ID=' + encodeURIComponent(val2) + '&Pay_to=' + encodeURIComponent(Payto);

            NewWindow1(url, '_blank', '1020', '400', 'yes');
        }

    </script>
    <script type="text/javascript">
        function toggleGeneralMenu() {
            // Get selected radio value
            var selectedValue = document.querySelector(
            "input[name$='Rd_Job_Non_Exp']:checked"
        ).value;

            if (selectedValue === "J") {
                // Job Expenses
                document.getElementById("<%= Page_A.ClientID %>").style.display = "block";
                document.getElementById("<%= Page_B.ClientID %>").style.display = "none";
                tab_page1(); // show page-6
            } else if (selectedValue === "NJ") {
                // Non Job Expenses
                document.getElementById("<%= Page_A.ClientID %>").style.display = "none";
                document.getElementById("<%= Page_B.ClientID %>").style.display = "block";
                tab_page2(); // show page-7
            }
        }

        function togglePurchaseDiv() {
            var ddl = document.getElementById('<%= ddl_Against.ClientID %>');
            var div = document.getElementById('tag_Purchase');

            if (ddl.value === 'A') {
                div.style.display = 'none';   // invisible
            } else {
                div.style.display = 'block';  // visible
            }
        }

        window.onbeforeunload = function () {
            if (window.opener && !window.opener.closed) {
                window.opener.document.getElementById("Button2").click();
            }
        };

        function open_PaymentRequest_Excel_Upload() {
            var noF = document.getElementById('<%= txt_BP_R_No_F.ClientID %>').value;
            var mid = document.getElementById('<%= txt_BP_R_M.ClientID %>').value;
            var last = document.getElementById('<%= txt_BP_R_L.ClientID %>').value;
            var Pay = document.getElementById('<%= ddlpay_Cusname.ClientID %>').value;
            var Payto = document.getElementById('<%= ddlpayto.ClientID %>').value;
            var ID = document.getElementById('<%= HDupdate_id.ClientID %>').value;
            if (ID != "") {
                var url = '../Accounts_Others/Payment_Request_Entry_Excel_Upload.aspx'
        + '?BP_R_No_F=' + encodeURIComponent(noF)
        + '&BP_R_M=' + encodeURIComponent(mid)
        + '&BP_R_L=' + encodeURIComponent(last)
        + '&Pay_Cusname=' + encodeURIComponent(Pay) + '&BP_R_ID=' + encodeURIComponent(ID) + '&Pay_to=' + encodeURIComponent(Payto);

                NewWindow1(url, '_blank', '1020', '400', 'yes');
            } else {
                jAlert('Please save the above details before uploading Excel.', 'Payment Request');
            }

        }

        function open_PR_RPT() {
            var jobNoPS='', JobNo='', IMP_EXP='';
            var rdJobNonExp = document.querySelector('input[name="<%= Rd_Job_Non_Exp.ClientID %>"]:checked');
            var selectedValue = rdJobNonExp.value;
            var Payto = document.getElementById('<%= ddlpayto.ClientID %>').value;

            if (selectedValue == 'J' && Payto!='E') {
                    jobNoPS = document.getElementById('<%= ddlJobno.ClientID %>').value;
                    JobNo = document.getElementById('<%= txtJobno_ps.ClientID %>').value;
                    IMP_EXP = document.getElementById('<%= ddl_Imp_Exp.ClientID %>').value;
                }

            var REF_NO =
        document.getElementById('<%= txt_BP_R_No_F.ClientID %>').value.trim() +
        document.getElementById('<%= txt_BP_R_M.ClientID %>').value.trim() +
        document.getElementById('<%= txt_BP_R_L.ClientID %>').value.trim();

            NewWindow1(
        '../Acc_Payment_Req_Rpt/Acc_Payment_Request.aspx' +
        '?JOBNO_PS=' + encodeURIComponent(jobNoPS) +
        '&JOBNO=' + encodeURIComponent(JobNo) +
        '&I_E=' + encodeURIComponent(IMP_EXP) +
        '&REF_NO=' + encodeURIComponent(REF_NO),
        '_blank',
        '870',
        '1024',
        'yes'
    );

            return false; // stop postback
        }


    </script>
</body>
</html>
