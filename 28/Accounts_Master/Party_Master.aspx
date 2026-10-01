<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Party_Master.aspx.cs" Inherits="Party_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Party Master</title>
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
        .Background
        {
            background-color: Green;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFE4C4;
            border-width: 3px;
            border-style: solid;
            border-color: #BC8F8F;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 200px;
        }
        .Popup_2
        {
            background-color: #FFE4C4;
            border-width: 3px;
            border-style: solid;
            border-color: #BC8F8F;
            padding-top: 10px;
            padding-left: 10px;
            width: 500px;
            height: 280px;
        }
        .lbl
        {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
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
    <script language="javascript">
        function B_G_tab_page2() {

            document.getElementById('page-1').style.display = 'Block';
            document.getElementById('page-2').style.display = 'none';
            document.getElementById('page-3').style.display = 'none';
            document.getElementById('page-4').style.display = 'none';

            document.getElementById("page-6").style.display = 'none';
            document.getElementById("page-7").style.display = 'block';
            document.getElementById("page-8").style.display = 'none';
            document.getElementById("page-9").style.display = 'none';

            document.getElementById("Page_A").className = 'inactive';
            document.getElementById("Page_B").className = 'active';
            document.getElementById("Page_C").className = 'inactive';
            document.getElementById("Page_D").className = 'inactive';

            document.getElementById("txtfocus").focus();
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id*=txtch_name]").autocomplete({
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
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="Div1" style="display: none">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Billing" style="height: 210px; width: 1194px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                        Party Master
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 80px;">
                            Party Name
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 380px;">
                            <asp:DropDownList ID="ddlClient_name" runat="server" class="chosen-select-deselect"
                                Style="width: 370px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                TabIndex="1" OnSelectedIndexChanged="ddlClient_name_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnaddnew" runat="server" Text="Add Client" OnClientClick="return HideModalPopup()"
                                Visible="false" CausesValidation="false" UseSubmitBehavior="false" />
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width: 260px;">
                            <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px; margin-top: -5px;">
                                Client Br. No
                            </div>
                            <div id="txtcon-m_Exchange" style="margin-top: -5px;">
                                <asp:DropDownList ID="ddl_Client_branch_No" runat="server" class="chosen-select-deselect"
                                    Style="width: 162px;" data-placeholder="Choose a Branch No" TabIndex="2" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddl_Client_branch_No_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="txt_container_Transact_Main_l" style="width: 200px; display: none;">
                            <div id="tag_label_transact_Src" style="width: 100px; color: Gray; font-weight: bold;
                                margin-top: -5px;">
                                Same as Party
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 50px; margin-top: -5px;">
                                <asp:CheckBox ID="Ch_Same_as_Party" runat="server" AutoPostBack="true" Checked="False"
                                    OnCheckedChanged="Ch_Same_as_Party_CheckedChanged" />
                            </div>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                </div>
                <%--------------R1-----------------%>
                <div id="tag_transact_lft_in1" style="width: 1185px;">
                    <div id="txt_container_Transact_Main_l" style="width: 590px;">
                        <div id="tag_label_transact_Src" style="width: 80px;">
                            Address 1
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 500px;">
                            <asp:TextBox ID="txtParty_Add_1" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="490px"
                                ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="3"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 590px;">
                        <div id="tag_label_transact_Src" style="width: 80px;">
                           Address 2
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 500px;">
                            <asp:TextBox ID="txtParty_Add_2" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                Width="490px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="4"></asp:TextBox>
                        </div>
                    </div>
                   
                </div>
                  <%--------------R1.1-----------------%>
                <div id="tag_transact_lft_in1" style="width: 1185px;">
                    
                    <div id="txt_container_Transact_Main_l" style="width: 590px;">
                        <div id="tag_label_transact_Src" style="width: 80px;">
                           Address 3
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 500px;">
                            <asp:TextBox ID="txtParty_Add_3" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                Width="490px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="5"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 360px;">
                        <div id="tag_label_transact_Src" style="width: 80px;">
                           Address 4
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 250px;">
                            <asp:TextBox ID="txtParty_Add_4" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                Width="240px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="6"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 230px;">
                        <div id="tag_label_transact_Src" style="width: 80px;">
                            Pin Code
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 140px;">
                            <asp:TextBox ID="txtParty_Add_5" runat="server" MaxLength="6" Width="130px" CssClass="validate[required,minSize[6],custom[phone]] txtbox_none"
                                TabIndex="7" onkeypress="return pin(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <%--------------R2-----------------%>
                <div id="tag_transact_lft_in1" style="width: 1185px;">
                    <div id="txt_container_Transact_Main_l" style="width: 250px;">
                        <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;">
                            State Code
                        </div>
                        <div id="txtcon-m_Exchange">
                        <asp:XmlDataSource ID="XmlState_Name_Code" runat="server"  DataFile="~/Accounts_XML_Data/State_Name_Code.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>
                          <asp:DropDownList ID="ddl_state_name" CssClass="listtxt_transac_item_gen_notn" Width="160px"
                           DataSourceID="XmlState_Name_Code"  DataTextField="text" DataValueField="value" TabIndex="8"  ForeColor="Green" runat="server" BackColor="AntiqueWhite"  >
                            </asp:DropDownList>

                            
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 230px">
                        <div id="tag_label_transact_Src" style="width: 80px">
                            GST No
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 140px">
                            <asp:TextBox ID="txt_Gst_Number" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="9"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 200px">
                        <div id="tag_label_transact_Src" style="width: 80px">
                            Tan No.
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px">
                            <asp:TextBox ID="txt_Pan_Tan_No" runat="server" Width="100px" MaxLength="100" onkeyup="autotab(this);"
                                CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="10"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 200px">
                        <div id="tag_label_transact_Src" style="width: 90px">
                            TDS Deducted
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px">
                            <asp:RadioButtonList ID="Rd_TDS_Y_N" runat="server" RepeatDirection="Horizontal"
                                TabIndex="11" ForeColor="Purple" onclick="toggleTdsFields(this)">
                                <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 160px">
                        <div id="tag_label_transact_Src" style="width: 70px">
                            TDS Sec.
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 90px">
                            <asp:DropDownList ID="ddlTDS_Section" Font-Size="12px" TabIndex="12" runat="server"
                                class="chosen-select-deselect" Style="width: 80px;" 
                                data-placeholder=" TDS Sec">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="192B" Value="192B"></asp:ListItem>
                                <asp:ListItem Text="194A" Value="194A"></asp:ListItem>
                                <asp:ListItem Text="194B" Value="194B"></asp:ListItem>
                                <asp:ListItem Text="194C" Value="194C"></asp:ListItem>
                                <asp:ListItem Text="194D" Value="194D"></asp:ListItem>
                                <asp:ListItem Text="194H" Value="194H"></asp:ListItem>
                                <asp:ListItem Text="194I" Value="194I"></asp:ListItem>
                                <asp:ListItem Text="194Ia" Value="194Ia"></asp:ListItem>
                                <asp:ListItem Text="194Ib" Value="194Ib"></asp:ListItem>
                                <asp:ListItem Text="194J" Value="194J"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 120px">
                        <div id="tag_label_transact_Src" style="width: 80px">
                            TDS Rate %
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 40px">
                            <asp:TextBox ID="txt_Tds_Rate" runat="server" Width="40px" MaxLength="100" onkeyup="autotab(this);"
                                CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="13"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <%--------------R3-----------------%>
                <div id="tag_transact_lft_in1" style="width: 1185px; height:30px;">
                    <div id="txt_container_Transact_Main_l" style="width: 250px;">
                        <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;">
                            Ledger Group
                        </div>
                        <div id="txtcon-m_Exchange">
                            <asp:DropDownList ID="ddlUnder" runat="server" class="chosen-select-deselect" Style="width: 155px;"
                                data-placeholder="Choose a Ledger Group" TabIndex="14">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 230px">
                        <div id="tag_label_transact_Src" style="width: 80px">
                            Bank Details
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 140px">
                            <asp:DropDownList ID="ddlBank_details" runat="server" class="chosen-select-deselect"
                                Style="width: 138px;" data-placeholder="Choose a Payment Type" 
                                TabIndex="15">
                                <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                <asp:ListItem Text="Account Transfer" Value="Account Transfer"></asp:ListItem>
                                <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 230px">
                        <div id="tag_label_transact_Src" style="width: 100px">
                            Gst Reg. Type
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 120px">
                            <asp:DropDownList ID="ddlGst_Reg_Type" runat="server" class="chosen-select-deselect"
                                Style="width: 110px;" data-placeholder="Choose a Customer Name" 
                                TabIndex="16">
                                <asp:ListItem Text="Regular" Value="R"></asp:ListItem>
                                <asp:ListItem Text="Govt" Value="G"></asp:ListItem>
                                <asp:ListItem Text="Unregistered" Value="U"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                   <%-- <div id="txt_container_Transact_Main_l" style="width: 230px">
                        <div id="tag_label_transact_Src" style="width: 80px">
                            Credit Days
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 140px">
                            <asp:DropDownList ID="ddl_Cr_Days" TabIndex="17" runat="server" class="chosen-select-deselect"
                                Style="width: 135px;" data-placeholder="Choose a Cr. Day(s)">
                                <asp:ListItem Text="0 - Day" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1 - Day" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2 - days" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3 - days" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4 - days" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5 - days" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6 - days" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7 - days" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8 - days" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9 - days" Value="9"></asp:ListItem>
                                <asp:ListItem Text="10 - days" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11 - days" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12 - days" Value="12"></asp:ListItem>
                                <asp:ListItem Text="13 - days" Value="13"></asp:ListItem>
                                <asp:ListItem Text="14 - days" Value="14"></asp:ListItem>
                                <asp:ListItem Text="15 - days" Selected="True" Value="15"></asp:ListItem>
                                <asp:ListItem Text="16 - days" Value="16"></asp:ListItem>
                                <asp:ListItem Text="17 - days" Value="17"></asp:ListItem>
                                <asp:ListItem Text="18 - days" Value="18"></asp:ListItem>
                                <asp:ListItem Text="19 - days" Value="19"></asp:ListItem>
                                <asp:ListItem Text="20 - days" Value="20"></asp:ListItem>
                                <asp:ListItem Text="21 - days" Value="21"></asp:ListItem>
                                <asp:ListItem Text="22 - days" Value="22"></asp:ListItem>
                                <asp:ListItem Text="23 - days" Value="23"></asp:ListItem>
                                <asp:ListItem Text="24 - days" Value="24"></asp:ListItem>
                                <asp:ListItem Text="25 - days" Value="25"></asp:ListItem>
                                <asp:ListItem Text="26 - days" Value="26"></asp:ListItem>
                                <asp:ListItem Text="27 - days" Value="27"></asp:ListItem>
                                <asp:ListItem Text="28 - days" Value="28"></asp:ListItem>
                                <asp:ListItem Text="29 - days" Value="29"></asp:ListItem>
                                <asp:ListItem Text="30 - days" Value="30"></asp:ListItem>
                                <asp:ListItem Text="31 - days" Value="31"></asp:ListItem>
                                <asp:ListItem Text="32 - days" Value="32"></asp:ListItem>
                                <asp:ListItem Text="33 - days" Value="33"></asp:ListItem>
                                <asp:ListItem Text="34 - days" Value="34"></asp:ListItem>
                                <asp:ListItem Text="35 - days" Value="35"></asp:ListItem>
                                <asp:ListItem Text="36 - days" Value="36"></asp:ListItem>
                                <asp:ListItem Text="37 - days" Value="37"></asp:ListItem>
                                <asp:ListItem Text="38 - days" Value="38"></asp:ListItem>
                                <asp:ListItem Text="39 - days" Value="39"></asp:ListItem>
                                <asp:ListItem Text="40 - days" Value="40"></asp:ListItem>
                                <asp:ListItem Text="41 - days" Value="41"></asp:ListItem>
                                <asp:ListItem Text="42 - days" Value="42"></asp:ListItem>
                                <asp:ListItem Text="43 - days" Value="43"></asp:ListItem>
                                <asp:ListItem Text="44 - days" Value="44"></asp:ListItem>
                                <asp:ListItem Text="45 - days" Value="45"></asp:ListItem>
                                <asp:ListItem Text="46 - days" Value="46"></asp:ListItem>
                                <asp:ListItem Text="47 - days" Value="47"></asp:ListItem>
                                <asp:ListItem Text="48 - days" Value="48"></asp:ListItem>
                                <asp:ListItem Text="49 - days" Value="49"></asp:ListItem>
                                <asp:ListItem Text="50 - days" Value="50"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>
                    <div id="txt_container_Transact_Main_l" style="width: 200px">
                        <div id="tag_label_transact_Src" style="width: 80px">
                            <%-- TDS Rate--%>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 110px">
                            <%--  <asp:TextBox ID="txt_Tds_Rate" runat="server" Width="100px" MaxLength="100" onkeyup="autotab(this);"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="28"></asp:TextBox>--%>
                        </div>
                    </div>
                </div>
                <%--------------R4-----------------%>
                <div id="tag_transact_lft_in1" style="width: 1185px;">
                    <div id="txt_container_Transact_Main_l" style="width: 250px;">
                        <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;">
                            O/P Balance
                        </div>
                        <div id="txtcon-m_Exchange">
                            <asp:TextBox ID="txt_Opening_bal" runat="server" MaxLength="50" onkeyup="autotab(this);" BorderColor="Black" BackColor="#CDED98"
                                Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="17"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 230px">
                        <div id="tag_label_transact_Src" style="width: 80px">
                             Credit Days
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 140px">
                           <asp:DropDownList ID="ddl_Cr_Days" TabIndex="18" runat="server" class="chosen-select-deselect"
                                Style="width: 135px;" data-placeholder="Choose a Cr. Day(s)">
                                <asp:ListItem Text="0 - Day" Value="0"></asp:ListItem>
                                <asp:ListItem Text="1 - Day" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2 - days" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3 - days" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4 - days" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5 - days" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6 - days" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7 - days" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8 - days" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9 - days" Value="9"></asp:ListItem>
                                <asp:ListItem Text="10 - days" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11 - days" Value="11"></asp:ListItem>
                                <asp:ListItem Text="12 - days" Value="12"></asp:ListItem>
                                <asp:ListItem Text="13 - days" Value="13"></asp:ListItem>
                                <asp:ListItem Text="14 - days" Value="14"></asp:ListItem>
                                <asp:ListItem Text="15 - days" Selected="True" Value="15"></asp:ListItem>
                                <asp:ListItem Text="16 - days" Value="16"></asp:ListItem>
                                <asp:ListItem Text="17 - days" Value="17"></asp:ListItem>
                                <asp:ListItem Text="18 - days" Value="18"></asp:ListItem>
                                <asp:ListItem Text="19 - days" Value="19"></asp:ListItem>
                                <asp:ListItem Text="20 - days" Value="20"></asp:ListItem>
                                <asp:ListItem Text="21 - days" Value="21"></asp:ListItem>
                                <asp:ListItem Text="22 - days" Value="22"></asp:ListItem>
                                <asp:ListItem Text="23 - days" Value="23"></asp:ListItem>
                                <asp:ListItem Text="24 - days" Value="24"></asp:ListItem>
                                <asp:ListItem Text="25 - days" Value="25"></asp:ListItem>
                                <asp:ListItem Text="26 - days" Value="26"></asp:ListItem>
                                <asp:ListItem Text="27 - days" Value="27"></asp:ListItem>
                                <asp:ListItem Text="28 - days" Value="28"></asp:ListItem>
                                <asp:ListItem Text="29 - days" Value="29"></asp:ListItem>
                                <asp:ListItem Text="30 - days" Value="30"></asp:ListItem>
                                <asp:ListItem Text="31 - days" Value="31"></asp:ListItem>
                                <asp:ListItem Text="32 - days" Value="32"></asp:ListItem>
                                <asp:ListItem Text="33 - days" Value="33"></asp:ListItem>
                                <asp:ListItem Text="34 - days" Value="34"></asp:ListItem>
                                <asp:ListItem Text="35 - days" Value="35"></asp:ListItem>
                                <asp:ListItem Text="36 - days" Value="36"></asp:ListItem>
                                <asp:ListItem Text="37 - days" Value="37"></asp:ListItem>
                                <asp:ListItem Text="38 - days" Value="38"></asp:ListItem>
                                <asp:ListItem Text="39 - days" Value="39"></asp:ListItem>
                                <asp:ListItem Text="40 - days" Value="40"></asp:ListItem>
                                <asp:ListItem Text="41 - days" Value="41"></asp:ListItem>
                                <asp:ListItem Text="42 - days" Value="42"></asp:ListItem>
                                <asp:ListItem Text="43 - days" Value="43"></asp:ListItem>
                                <asp:ListItem Text="44 - days" Value="44"></asp:ListItem>
                                <asp:ListItem Text="45 - days" Value="45"></asp:ListItem>
                                <asp:ListItem Text="46 - days" Value="46"></asp:ListItem>
                                <asp:ListItem Text="47 - days" Value="47"></asp:ListItem>
                                <asp:ListItem Text="48 - days" Value="48"></asp:ListItem>
                                <asp:ListItem Text="49 - days" Value="49"></asp:ListItem>
                                <asp:ListItem Text="50 - days" Value="50"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 230px">
                        <div id="tag_label_transact_Src" style="width: 80px">
                            Credit Limit
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 140px">
                            <asp:TextBox ID="txt_Credit_Amt" runat="server" BackColor="#C0C0C0" MaxLength="50"
                                onkeyup="autotab(this);" Enabled="false" Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                TabIndex="19"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 310px">
                        <div id="tag_label_transact_Src" style="width: 120px">
                            Debit Limit
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 190px">
                            <asp:TextBox ID="txt_Debit_Amt" runat="server" BackColor="#C0C0C0" MaxLength="50"
                                onkeyup="autotab(this);" Enabled="false" Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                TabIndex="20"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 365px">
                        <div id="tag_label_transact_Src" style="width: 150px">
                            <%-- Gst Rgesitration Type  --%>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 140px">
                            <%--  <asp:DropDownList ID="ddlGst_Reg_Type" runat="server" class="chosen-select-deselect"
                                        Style="width: 138px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                        TabIndex="30">
                                        <asp:ListItem Text="Regular" Value="R"></asp:ListItem>
                                        <asp:ListItem Text="Govt" Value="G"></asp:ListItem>
                                        <asp:ListItem Text="Unregistered" Value="U"></asp:ListItem>
                                        </asp:DropDownList>--%>
                        </div>
                    </div>
                </div>
                <%--------------R4-----------------%>
                <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                    <div id="innerbox_transac_bot_inn" style="width: 1050px">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" Visible="false"
                                TabIndex="82" OnClick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save"   OnClientClick="return runAllValidations();"
                                TabIndex="21" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                               OnClientClick="return runAllValidations();" TabIndex="22" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="23" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Party Master?', 'Party Master', function(r) {
                                  var i = r + 'ok';
                                  if(i == 'trueok')
                                  {
                                      document.getElementById('btn').click();
                                  }
                                  else {
                                  }
    
                                 });return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="81" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="24">
                        </div>
                    </div>
                </div>
                <%--------------RE-----------------%>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -28px; width: 1194px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 535px; width: 1194px; margin-left: -16px;
                    margin-top: -15px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                            id="Page_A" runat="server"><span>General </span></a></li>
                        <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                            visible="false" id="Page_C" runat="server"><span>Other </span></a></li>
                        <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');"
                            visible="false" id="Page_B" runat="server"><span>Charge details</span></a></li>
                        <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                            id="Page_D" runat="server" visible="false"><span>Gen -4 </span></a></li>
                    </ol>
                    <%----------------------------General---------------------------------------------------%>
                    <div class="content" id="page-6" style="height: 492px;">
                        <%--------------------------------------------------------------------------------------------%>
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 508px;
                            margin-top: -16px; margin-left: -18px; color: Red; width: 1185px;">
                            <div id="tag_transact_src_inner" style="width: 1185px; height: 508px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1185px; height: 508px;">
                                    <%---------------------------------------Row 1-----------------------------------------%>
                                    <%---------------------------------------Row 2-----------------------------------------%>
                                    <div id="tag_transact_lft_in1" style="width: 1185px; height: 35px;">
                                        <div id="txt_container_Transact_Main_l" style="width: 550px;">
                                            <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;">
                                                Client Name
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 460px;">
                                                <asp:DropDownList ID="ddlPartyName" runat="server" class="chosen-select-deselect"
                                                    Style="width: 330px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                                    TabIndex="25" OnSelectedIndexChanged="ddlPartyName_SelectedIndexChanged">
                                                </asp:DropDownList>&nbsp;&nbsp;
                                               <asp:Button ID="btnaddnewParty" runat="server" Text="Add New Client" OnClientClick="return open_Billing_Party_Master_PN('New')"
                                                    CausesValidation="false" UseSubmitBehavior="false" 
                                                    Width="105px" TabIndex="26" />

                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l" style="width: 320px">
                                            <div id="tag_label_transact_Src" style="width: 80px">
                                                Branch No
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 220px">
                                                <asp:DropDownList ID="ddlPartybranch_Name" runat="server" class="chosen-select-deselect"
                                                    Style="width: 210px;" data-placeholder="Choose a Branch No" TabIndex="27" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlPartybranch_Name_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--------------------------------------Row 5-----------------------------------------%>
                                        <div id="innerbox_MidMain_bot_transact1" runat="server" style="height: 20px;">
                                            <div id="innerbox_transac_bot_inn" style="width: 240px">
                                                <div id="newbu">
                                                    <asp:Button ID="Button1" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                                        TabIndex="28" OnClick="btnNew_Click2" />
                                                </div>
                                                <div id="editbu">
                                                    <asp:Button ID="btnSave1" runat="server" TabIndex="28" CssClass="autowidupdatebut"
                                            OnClick="btn_Save_Update_Click_II" style="height:29px;width:64px;" />
                                                </div>
                                                <div id="editbu">
                                               
                                                </div>
                                                <div id="editbu">
                                                    <asp:Button ID="btnDelete1" runat="server" TabIndex="29" CausesValidation="false"
                                                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Party Master', function(r) { var i = r + 'ok';
                                                       if(i == 'trueok'){document.getElementById('btn1').click();} else { }});return false;" />
                                                    <asp:Button ID="btn1" runat="server" TabIndex="81" OnClick="btnDelete_Click_II" CausesValidation="false"
                                                        UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                                        CssClass="dlete" Style="display: none;" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <%------------------------------grid---------------------------- ------------------------------------%>
                                    <div id="tag_transac_lft_Item_maindet_Grid_area" style="margin-top: 15px; height: 270px;
                                        width: 1175px;">
                                        <asp:GridView ID="gv" runat="server" DataKeyNames="CLIENT_ID,PARTY_ID" EmptyDataText="NO RECORD FOUND"
                                            AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                            ShowHeaderWhenEmpty="True" PageSize="300" AllowPaging="True" OnRowDataBound="gv_RowDataBound"
                                            OnPageIndexChanging="gv_PageIndexChanging" OnSelectedIndexChanged="gv_SelectedIndexChanged"
                                            AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="1" CellSpacing="1" OnRowCreated="gv_RowCreated">
                                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                                BorderWidth="1px" />
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True">
                                                    <HeaderStyle CssClass="hideGridColumn" />
                                                    <ItemStyle CssClass="hideGridColumn" />
                                                </asp:CommandField>
                                                <asp:TemplateField HeaderText="S.No">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="CLIENT_NAME" HeaderText="Client Name" ControlStyle-Width="500px">
                                                    <ItemStyle CssClass="column_style_left5" Width="800px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="CLIENT_BRANCH_NO" HeaderText="Branch No" ControlStyle-Width="200px">
                                                    <ItemStyle CssClass="column_style_left5" Width="200px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="STATE_NAME" HeaderText="State Name" ControlStyle-Width="200px"  Visible="False" >
                                                    <ItemStyle CssClass="column_style_left5" Width="200px"  />
                                                </asp:BoundField>
                                            </Columns>
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                            <PagerStyle CssClass="pager" />
                                            <EmptyDataTemplate>
                                                NO RECORD FOUND
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                    <%--------------------------------------Row End-----------------------------------------%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%----------------------------Other---------------------------------------------------%>
                    <div class="content" id="page-8" style="height: 492px;">
                    </div>
                    <%----------------------------Charge Details---------------------------------------------------%>
                    <div class="content" id="page-7" style="display: none; height: 492px; width: 1194px;">
                    </div>
                    <%-------------------------------------------------------------------------------%>
                </div>
                <%-- --------------------Test Start----------------------------%>
                <%-- --------------------Test End----------------------------%>
            </div>
            <div class="content" id="page-2">
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                    page-2
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
            <%-- ---------------------------------------------------------ModelpopUp---1S------------------------------------------------------------------------------%>
            
            <%-- ---------------------------------------------------------ModelpopUp---16--S----------------------------------------------------------------------------%>
            
            <%-- ---------------------------------------------------------ModelpopUp---16--E----------------------------------------------------------------------------%>
            
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HDupdate_id_II" runat="server" />
            <asp:HiddenField ID="HD_Showcon" runat="server" />
            <asp:HiddenField ID="HD_Bill_Jobno" runat="server" />
            <asp:HiddenField ID="Hdjobno" runat="server" />
            <asp:HiddenField ID="hd_ch_type" runat="server" />
            <asp:HiddenField ID="Hd_row_id" runat="server" />
            <asp:HiddenField ID="Hd_Tr_mode" runat="server" />
            <asp:HiddenField ID="Hd_Company_Id" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript">
        function Go_Refresh() {
            PageMethods.Inv_Refresh('Inv', OnSuccess);
        }
        function OnSuccess(response, userContext, methodName) {

            $('#txtInvoiceNo').val(response);
        }
    </script>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
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
       function toggleTdsFields(radioList) {
    var selected = radioList.querySelector("input:checked");
    if (!selected) return;
    var selectedValue = selected.value;

    var ddl = document.getElementById("<%= ddlTDS_Section.ClientID %>");
    var txt = document.getElementById("<%= txt_Tds_Rate.ClientID %>");

    if (!ddl || !txt) return;

    if (selectedValue === "Y") {
        ddl.disabled = false;
        txt.disabled = false;
    } else {
        ddl.selectedIndex = 0;  
        txt.value = "";
        ddl.disabled = true;
        txt.disabled = true;

        $(".chosen-select-deselect").trigger("chosen:updated");
    }

    $(".chosen-select-deselect").trigger("chosen:updated");
}


       
        window.onload = function () {
            var radioList = document.getElementById("<%= Rd_TDS_Y_N.ClientID %>");
            if (radioList) toggleTdsFields(radioList);
        };

       function runAllValidations() {
    if (typeof validate === "function") {
        var ok = validate();
        if (ok === false) return false; 
    }

    return validateBeforeSave(); 
}

function validateBeforeSave() {
    var radioList = document.getElementById("<%= Rd_TDS_Y_N.ClientID %>");
    var selectedValue = radioList.querySelector("input:checked")?.value || "";
    var ddl = document.getElementById("<%= ddlTDS_Section.ClientID %>");
    var txt = document.getElementById("<%= txt_Tds_Rate.ClientID %>");

    if (selectedValue === "Y") {
        if (ddl.value.trim() === "" || txt.value.trim() === "") {
       
         jAlert('Please enter TDS Section and Rate.', 'Part Master');
            return false; 
        }
    }
    return true; 
}
</script>

</body>
</html>
