<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Imp_Exp_Charges.aspx.cs"
    Inherits="Acc_Imp_Exp_Charges" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Charge Entry</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
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
        div.fileinputs
        {
            position: relative;
        }
        
        div.fakefile
        {
            position: absolute;
            top: 0px;
            left: 0px;
            z-index: 1;
        }
        
        input.file
        {
            position: relative;
            text-align: right;
            -moz-opacity: 0;
            filter: alpha(opacity: 0);
            opacity: 0;
            z-index: 2;
        }
        
        
        /* Only for upward dropdown */.chosen-upward + .chosen-container .chosen-drop
        {
            top: auto !important;
            bottom: 100% !important;
            display: flex;
            flex-direction: column-reverse; /* KEY LINE */
        }
        /* Fix search box spacing */.chosen-upward + .chosen-container .chosen-search
        {
            margin-top: 5px;
            margin-bottom: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <div class="loading" align="center" id="load" style="display: none;">
        <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
    </div>
    <div id="innerbox_MidMain_Billing" style="height: 125px;">
        <div id="tag_srcinner1">
            <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                Charge Entry
            </div>
            <div id="verslic" style="margin-top: -5px;">
            </div>
            <div id="tag_label_transact_Src" style="width: 90px; margin-top: 5px;">
                Jobno :
            </div>
            <div id="txtcon-m_Exchange" style="width: 100px; color: Green; margin-top: 5px;">
                <asp:Literal ID="txt_jobno" runat="server"></asp:Literal>
            </div>
            <div id="popupwindow_closebut_right_new">
                <%-- <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" />--%>
            </div>
        </div>
        <div id="tag_transact_src_inner" style="width: 1200px;">
            <div id="tag_Exchange_inner_lft" style="width: 1200px;">
                <div id="tag_transact_lft_in1" style="width: 1200px;">
                    <div style="width: 1200px; height: 30px">
                        <div id="txt_container_Transact_Main_l" style="width: 1150px; height: 25px; margin-left: -5px;">
                            <div id="tag_label_transact_Src" style="width: 90px;">
                                Charge Name
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 600px;">
                                <asp:DropDownList ID="ddlcharge" runat="server" class="chosen-select-deselect" Style="width: 590px;"
                                    data-placeholder="Choose a Charge Name" TabIndex="1" AutoPostBack="True" OnSelectedIndexChanged="ddlcharge_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 90px;">
                                Category
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 250px;">
                                <asp:DropDownList ID="ddlch_Cat" runat="server" class="chosen-select-deselect" Style="width: 240px;"
                                    data-placeholder="Choose a Charge Category" TabIndex="2">
                                    <asp:ListItem Text="Margin" Value="M"></asp:ListItem>
                                    <asp:ListItem Text="Revenue" Value="R"></asp:ListItem>
                                    <asp:ListItem Text="Cost" Value="C"></asp:ListItem>
                                    <asp:ListItem Text="Reimbursement" Value="RI"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width: 1200px; margin-left: -5px;">
                            <div id="tag_label_transact_Src" style="width: 90px;">
                                Cost Center
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 200px;">
                                <asp:DropDownList ID="ddl_Cost_Center" class="validate[required]  chosen-select-deselect"
                                    Style="width: 190px;" data-placeholder="Choose a Cost Center" runat="server"
                                    TabIndex="3">
                                    <%-- <asp:ListItem Text="Import" Value="I"></asp:ListItem>
                                       <asp:ListItem Text="Export" Value="E"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 65px;">
                                Narration
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 668px">
                                <asp:TextBox ID="txtNarration" CssClass="txtbox_none_Mid_transac_pop_gen_srcic" Width="660px"
                                    TabIndex="4" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- -------------------------------------Tab--------------------------------------------------------%>
    <div class="content" id="page-1" style="margin-top: -30px;">
        <%-- <div id="innerbox_MidMain_Trans_new" style="height: 417px; width: 1298px; margin-left: -16px; margin-top: -25px;">--%>
        <div id="pop_text_area_transac_popup_inn_container_new" style="height: 205px; width: 1160px;">
            <div id="pop_text_area_transac_popup_inn_container_left_new" style="width: 575px;
                height: 205px;">
                <fieldset id="fld" style="width: 280px; height: 204px">
                    <legend style="border: white; border-collapse: collapse; width: 50px; text-align: center;
                        height: 12px; margin-left: 60px;">Revenue</legend>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen" style="font-weight: bold; color: Green;">
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px;">
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            Charge Description
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px;">
                            <asp:TextBox ID="txt_Charge_Desc_Rev" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                Width="420px" TabIndex="5" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            <span style="color: Red;">Qty </span>/ <span style="color: #008000;">Unit Price
                            </span>
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 160px;">
                            <asp:TextBox ID="txtQty_Rev" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                Text="1" BackColor="#F4A460" BorderColor="Black" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" oninput="Rev_Amount();"
                                TabIndex="6" Width="45px" ClientIDMode="Static"></asp:TextBox>
                            &nbsp;
                            <asp:TextBox ID="txtUnitPrice_Rev" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                BackColor="#A0D6B4" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                BorderColor="Black" onkeypress="return blockNonNumbers(this, event, true, false);"
                                oninput="Rev_Amount();" TabIndex="7" ClientIDMode="Static" Width="70px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_gen" style="width: 50px;">
                            Rate
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 205px;">
                            <asp:DropDownList ID="ddl_Cur_Rev" runat="server" Width="50px" Height="22px" Font-Size="12px"
                                CssClass=" txtbox_trans_exp_drawback" TabIndex="8">
                                <asp:ListItem Value="INR"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:TextBox ID="txt_Cur_Rev" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                BackColor="#F5F5F5" Text="1.00" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="9" Width="40px"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            Amount(INR)
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px;">
                            <asp:TextBox ID="txt_Amount_Rev" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                BackColor="#F5F5F5" Text="0.00" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" ClientIDMode="Static"
                                TabIndex="10" Width="100px"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 525px;">
                            <div id="tag_label_transact_Src" style="width: 40px; font-size: 12px; color: Green;">
                                CGST
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 120px;">
                                <asp:TextBox ID="txtCgstRate_Rev" runat="server" Width="30px" ForeColor="Red" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    MaxLength="50" TabIndex="11"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="txt_CGST_Amt_Rev" runat="server" Width="60px" ForeColor="Red" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    MaxLength="50" TabIndex="12"></asp:TextBox>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 40px; font-size: 12px; color: Green;">
                                SGST
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 120px;">
                                <asp:TextBox ID="txtSgstRate_Rev" runat="server" Width="30px" ForeColor="Red" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    MaxLength="50" TabIndex="13"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="txt_SGST_Amt_Rev" runat="server" Width="60px" ForeColor="Red" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    MaxLength="50" TabIndex="14"></asp:TextBox>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 40px; font-size: 12px; color: Orange;">
                                IGST
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 120px;">
                                <asp:TextBox ID="txtGstRate_Rev" runat="server" Width="30px" ForeColor="Red" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    MaxLength="50" TabIndex="15"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="txt_IGST_Amt_Rev" runat="server" Width="60px" ForeColor="Red" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    MaxLength="50" TabIndex="16"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            Receivable Type
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px;">
                            <asp:DropDownList ID="ddl_Rev_Type_Rev" Style="width: 325px;" runat="server" TabIndex="17">
                                <asp:ListItem Text="Customer" Value="C"></asp:ListItem>
                                <asp:ListItem Text="Importer" Value="I"></asp:ListItem>
                                <asp:ListItem Text="Other Entity" Value="O"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            Receivable From
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px;">
                            <asp:DropDownList ID="ddl_Rev_From_Rev" class="chosen-select-deselect" Style="width: 325px;"
                                data-placeholder="Choose a  Receivable From" runat="server" TabIndex="18">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            <%--Employee--%>
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px;">
                            <%-- <asp:DropDownList ID="ddl_Employee_Cost" class="chosen-select-deselect" Style="width: 325px;"
                            data-placeholder="Choose a Employee Name" runat="server" TabIndex="59">
                        </asp:DropDownList>--%>
                        </div>
                    </div>
                </fieldset>
            </div>
            <%-- -------------------------------------Right--------------------------------------------------------%>
            <div id="pop_text_area_transac_popup_inn_container_rght_new" style="width: 575px;
                height: 205px;">
                <fieldset id="fld" style="width: 280px; height: 204px">
                    <legend style="border: white; border-collapse: collapse; width: 50px; text-align: center;
                        height: 12px; margin-left: 60px;">Cost </legend>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            Charge Description
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px;">
                            <asp:TextBox ID="txt_Charge_Desc_Cost" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                Width="420px" TabIndex="19" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            <span style="color: Red;">Qty </span>/ <span style="color: #008000;">Unit Price
                            </span>
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 160px;">
                            <asp:TextBox ID="txtQty_Cost" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                Text="1" BackColor="#F4A460" BorderColor="Black" onchange="Amount();" onblur="Amount();"
                                onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                oninput="Amount();" TabIndex="20" Width="45px" ClientIDMode="Static"></asp:TextBox>
                            &nbsp;
                            <asp:TextBox ID="txtUnitPrice_Cost" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                BackColor="#A0D6B4" onchange="Amount();" onblur="Amount();" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                BorderColor="Black" onkeypress="Amount(); return blockNonNumbers(this, event, true, false);"
                                oninput="Amount();" TabIndex="21" ClientIDMode="Static" Width="70px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_gen" style="width: 50px;">
                            Rate
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 205px;">
                            <asp:DropDownList ID="ddl_Cur_Cost" runat="server" Width="50px" Height="22px" Font-Size="12px"
                                CssClass=" txtbox_trans_exp_drawback" TabIndex="22">
                                <asp:ListItem Value="INR"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <asp:TextBox ID="txt_Cur_Cost" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                BackColor="#F5F5F5" Text="1.00" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="23"
                                Width="40px"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            Amount(INR)
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px;">
                            <asp:TextBox ID="txt_Amount_Cost" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                BackColor="#F5F5F5" Text="0.00" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                ClientIDMode="Static" onkeypress="return blockNonNumbers(this, event, true, false);"
                                TabIndex="24" Width="100px"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 525px;">
                            <div id="tag_label_transact_Src" style="width: 40px; font-size: 12px; color: Green;">
                                CGST
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 120px;">
                                <asp:TextBox ID="txtCgstRate_Cost" runat="server" Width="30px" ForeColor="Red" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    MaxLength="50" TabIndex="25"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="txt_CGST_Amt_Cost" runat="server" Width="60px" ForeColor="Red" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    MaxLength="50" TabIndex="26"></asp:TextBox>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 40px; font-size: 12px; color: Green;">
                                SGST
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 120px;">
                                <asp:TextBox ID="txtSgstRate_Cost" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                   BackColor="#F4A460" BorderColor="Black" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="27"
                                    Width="30px" ClientIDMode="Static"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="txt_SGST_Amt_Cost" runat="server" Width="60px" ForeColor="Red" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    MaxLength="50" TabIndex="28"></asp:TextBox>
                            </div>
                            <div id="tag_label_transact_Src" style="width: 40px; font-size: 12px; color: Orange;">
                                IGST
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 120px;">
                                <asp:TextBox ID="txtGstRate_Cost" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    ClientIDMode="Static" BackColor="#F4A460" BorderColor="Black" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" oninput=" Amount();"
                                    TabIndex="28" Width="30px"></asp:TextBox>
                                &nbsp;
                                <asp:TextBox ID="txt_IGST_Amt_Cost" runat="server" Width="60px" ForeColor="Red" Font-Bold="true"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code" Style="border: 0px none;"
                                    MaxLength="50" TabIndex="29"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            Payable Type
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px;">
                            <asp:DropDownList ID="ddl_Payable_Type_Cost" Style="width: 325px;" runat="server"
                                AutoPostBack="True" OnSelectedIndexChanged="ddl_Payable_Type_SelectedIndexChanged"
                                TabIndex="30">
                                <asp:ListItem Text="Vendor" Value="V"></asp:ListItem>
                                <asp:ListItem Text="Transporter" Value="T"></asp:ListItem>
                                <asp:ListItem Text="Other Entity" Value="O"></asp:ListItem>
                                    <asp:ListItem Text="Employee" Value="E"></asp:ListItem>
                          
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            Payable To
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px; position: absolute;
                            margin-left: 120px;">
                            <asp:DropDownList ID="ddl_Payable_To_Cost" CssClass="chosen-select-deselect chosen-upward" Style="width: 325px;"
                                data-placeholder="Choose a Payable To" runat="server" TabIndex="31">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_in1" style="width: 570px;">
                        <div id="tag_label_transaction_popup_gen">
                            Employee
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width: 425px; position: absolute;
                            margin-left: 120px;">
                            <asp:DropDownList ID="ddl_Employee_Cost" CssClass="chosen-select-deselect chosen-upward"
                                Style="width: 325px;" data-placeholder="Choose a Employee Name" runat="server"
                                TabIndex="32">
                            </asp:DropDownList>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <div id="innerbox_MidMain_bot_transact" runat="server" style="width: 900px;">
            <div id="innerbox_transac_bot_inn" style="width: 890px;">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" TabIndex="84" CssClass="new" OnClick="btnNew_Click"
                        OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                        UseSubmitBehavior="false" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" CommandName="s"
                        OnClientClick="return validate();" TabIndex="81" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                        OnClick="btnUpdate_Click" Visible="false" TabIndex="82" OnClientClick="return validation();" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="83" CausesValidation="false"
                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Charge Entry', function(r) {
                  var i = r + 'ok';
                  if(i == 'trueok')
                  {
                      document.getElementById('btn').click();
            
                  }
                  else {
                  }
                    });return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="83" CausesValidation="false" UseSubmitBehavior="false"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                        CssClass="dlete" Style="display: none;" />
                </div>
            </div>
        </div>
    </div>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-6', 'page-7', 'page-8']);
    </script>
    <div style="display: none;">
        <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
        <asp:HiddenField ID="HiddenGstn" runat="server" />
        <asp:HiddenField ID="hdntotal" runat="server" />
        <asp:HiddenField ID="HiddenField_index" runat="server" />
        <asp:HiddenField ID="HiddenField_ImportJobNo" runat="server" />
        <asp:HiddenField ID="Hdn_amt_inr" runat="server" />
        <asp:HiddenField ID="hdn_TaxValue" runat="server" />
        <asp:HiddenField ID="Hdn_id" runat="server" />
    </div>
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
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



        function Rev_Amount() {

            var qty_Rev = parseFloat(document.getElementById("txtQty_Rev").value) || 0;
            var Cur_Rev = parseFloat(document.getElementById("txt_Cur_Rev").value) || 0;
            var rate_Rev = parseFloat(document.getElementById("txtUnitPrice_Rev").value) || 0;

            document.getElementById('<%= txt_Amount_Rev.ClientID %>').value = (qty_Rev * rate_Rev * Cur_Rev).toFixed(2);
            document.getElementById("Hdn_amt_inr").value = qty_Rev * rate_Rev * Cur_Rev;
            var Amtinr_Rev = parseFloat(document.getElementById('<%= txt_Amount_Rev.ClientID %>').value) || 0;
            var Gst_Rev = parseFloat(document.getElementById("txtGstRate_Rev").value) || 0;
            var CGst_Rev = parseFloat(document.getElementById("txtCgstRate_Rev").value) || 0;
            var SGst_Rev = parseFloat(document.getElementById("txtSgstRate_Rev").value) || 0;
            var tax_Rev = document.getElementById("hdn_TaxValue").value;
            document.getElementById("txt_IGST_Amt_Rev").value = (Amtinr_Rev * Gst_Rev / 100).toFixed(2);

            document.getElementById("txt_CGST_Amt_Rev").value = (Amtinr_Rev * CGst_Rev / 100).toFixed(2);
            document.getElementById("txt_SGST_Amt_Rev").value = (Amtinr_Rev * SGst_Rev / 100).toFixed(2);


            if (tax === "N") {
                var Amt_nontax = parseFloat(document.getElementById('<%= txt_Amount_Rev.ClientID %>').value);
                document.getElementById("txt_IGST_Amt_Rev").value = "";
                document.getElementById("txt_CGST_Amt_Rev").value = "";
                document.getElementById("txt_SGST_Amt_Rev").value = "";
                document.getElementById("txtGstRate_Rev").value = "";
                document.getElementById("txtCgstRate_Rev").value = "";
                document.getElementById("txtSgstRate_Rev").value = "";
            }


        }
        function Amount() {

            var qty = parseFloat(document.getElementById("txtQty_Cost").value) || 0;
            var Cur = parseFloat(document.getElementById("txt_Cur_Cost").value) || 0;
            var rate = parseFloat(document.getElementById("txtUnitPrice_Cost").value) || 0;
            document.getElementById('<%= txt_Amount_Cost.ClientID %>').value = (qty * rate * Cur).toFixed(2);
            document.getElementById("Hdn_amt_inr").value = qty * rate * Cur;
            var Amtinr = parseFloat(document.getElementById('<%= txt_Amount_Cost.ClientID %>').value) || 0;
            var Gst = parseFloat(document.getElementById("txtGstRate_Cost").value) || 0;
            var CGst = parseFloat(document.getElementById("txtCgstRate_Cost").value) || 0;
            var SGst = parseFloat(document.getElementById("txtSgstRate_Cost").value) || 0;

            var tax = document.getElementById("hdn_TaxValue").value;
            document.getElementById("txt_IGST_Amt_Cost").value = (Amtinr * Gst / 100).toFixed(2);
            document.getElementById("txt_CGST_Amt_Cost").value = (Amtinr * CGst / 100).toFixed(2);
            document.getElementById("txt_SGST_Amt_Cost").value = (Amtinr * SGst / 100).toFixed(2);


            if (tax === "N") {
                var Amt_nontax = parseFloat(document.getElementById('<%= txt_Amount_Cost.ClientID %>').value);
                document.getElementById("txt_IGST_Amt_Cost").value = "";
                document.getElementById("txt_CGST_Amt_Cost").value = "";
                document.getElementById("txt_SGST_Amt_Cost").value = "";
                document.getElementById("txtGstRate_Cost").value = "";
                document.getElementById("txtCgstRate_Cost").value = "";
                document.getElementById("txtSgstRate_Cost").value = "";
            }


        }

        window.onload = function () {
            Amount();
            Rev_Amount();
        };

        window.onbeforeunload = function () {
            if (window.opener && !window.opener.closed) {
                window.opener.document.getElementById("Button1").click();
            }
        };
    </script>
</body>
</html>
