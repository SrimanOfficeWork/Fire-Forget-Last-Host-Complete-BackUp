<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Client_Master_New.aspx.cs"
    Inherits="Client_Master_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Client Master | Updation</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Accounts/Acc_listpopup.js" type="text/javascript"></script>
    <style type="text/css">
        fieldset
        {
            font-family: sans-serif;
            padding: 10px;
        }
        ol#toc_inner
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: bold;
            color: #2b2b2b;
            height: 0.9em;
            list-style: none;
            margin: 0;
            padding: 0;
            padding-left: 10px;
            padding-top: 4px;
            border-top: solid #c0c0c0 thin;
            border-left: solid #c0c0c0 thin;
            border-right: solid #c0c0c0 thin;
            -moz-border-radius-topleft: 6px;
            -moz-border-radius-topright: 6px;
            -webkit-border-top-left-radius: 6px;
            -webkit-border-top-right-radius: 6px;
            border-top-left-radius: 6px;
            border-top-right-radius: 6px; /* orange bottom border like main tabs */ /*   border-bottom: 2px solid #f0a500;*/
            background-color: #f5f5f5;
            overflow: hidden;
            height: auto;
            padding-bottom: 0; /*margin-top: 2px;*/
        }
        
        ol#toc_inner li
        {
            float: left;
            margin: 0 1px 0 0;
            height: 28px;
        }
        
        ol#toc_inner li a
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: bold;
            color: #2b2b2b; /*background-image: url(../images/tabs_bot_bg_grey_inner.gif);
            background-repeat: repeat-x;
            background-position: top;*/
            display: block;
            float: left;
            height: 1.9em;
            padding-left: 10px;
            text-decoration: none;
            border-top: solid #c0c0c0 thin;
            border-left: solid #c0c0c0 thin;
            border-right: solid #c0c0c0 thin;
            border-bottom: none;
            -moz-border-radius-topleft: 6px;
            -moz-border-radius-topright: 6px;
            -webkit-border-top-left-radius: 6px;
            -webkit-border-top-right-radius: 6px;
            border-top-left-radius: 6px;
            border-top-right-radius: 6px;
            margin-top: 4px;
        }
        
        ol#toc_inner li a span
        {
            display: block;
            line-height: 1.9em;
            padding-right: 10px;
        }
        
        ol#toc_inner li a.active
        {
            /*background-image: url(../images/tabs_bot_bg_grey_Active.gif);
            background-repeat: repeat-x;
            background-position: top;*/
            background-color: #ffffff;
            color: #2b2b2b;
            border-top: solid #f0a500 2px;
            border-left: solid #f0a500 thin;
            border-right: solid #f0a500 thin;
            border-bottom: none;
        }
        
        ol#toc_inner li a:hover
        {
            /*background-image: url(../images/tabs_bot_bg_grey_Active.gif);*/
            background-color: #ffffff;
            color: #2b2b2b;
        }
        
        
        ol#toc_deep
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: bold;
            list-style: none;
            margin: 0px 0 0 0;
            padding: 0;
            padding-left: 8px;
            padding-top: 3px;
            background-color: #fafafa;
            overflow: hidden;
        }
        
        ol#toc_deep li
        {
            float: left;
            margin: 0 2px 0 0;
            height: 24px;
        }
        
        ol#toc_deep li a
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: bold;
            color: #555;
            display: block;
            float: left;
            height: 1.7em;
            padding-left: 10px;
            text-decoration: none;
            background-color: #e8e8e8;
            border-top: solid #ccc thin;
            border-left: solid #ccc thin;
            border-right: solid #ccc thin;
            border-bottom: none;
            -moz-border-radius-topleft: 5px;
            -moz-border-radius-topright: 5px;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            margin-top: 2px;
        }
        
        ol#toc_deep li a span
        {
            display: block;
            line-height: 1.7em;
            padding-right: 10px;
        }
        
        ol#toc_deep li a.active
        {
            background-color: #fff;
            color: #c07000;
            border-top: solid #c8a050 2px;
            border-left: solid #c8a050 thin;
            border-right: solid #c8a050 thin;
            border-bottom: none;
        }
        
        ol#toc_deep li a:hover
        {
            background-color: #fff;
            color: #c07000;
        }
        
        
        /* &#9472;&#9472; Inner content panels &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; */
        /* Remove old CSS classes &#8212; we use style.display now */
        .inner_content
        {
            display: none;
            padding: 8px 6px;
            min-height: 280px;
            border-left: 1px solid #ddd;
            border-right: 1px solid #ddd;
            border-bottom: 1px solid #ddd;
            background: #fff;
        }
        
        /* &#9472;&#9472; Deep content panels &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472; */
        .deep_content
        {
            display: none;
            padding: 8px 10px;
            min-height: 220px;
            border-left: 1px solid #e8e8e8;
            border-right: 1px solid #e8e8e8;
            border-bottom: 1px solid #e8e8e8;
            background: #fff;
        }
        .deep_content.active
        {
            display: block;
        }
        #deep-Customer, #deep-Vendor
        {
            width: 100%;
            clear: both;
            display: block; /*  margin-top: 5px;*/
            background-color: #f2f2f2;
        }
        
        #bank-Payable, #bank-Receivable
        {
            height: auto;
            display: none;
            background-color: #f2f2f2;
        }
        #bank-Payable.active-bank, #bank-Receivable.active-bank
        {
            display: flex !important;
            flex-direction: column !important;
            height: auto !important;
        }
        #toc_deep
        {
            width: 100%;
            clear: both;
        }
        #toc_bank
        {
            width: 100%;
            clear: both;
            list-style: none;
            margin: 0;
            padding: 0;
            padding-left: 8px; /* padding-top: 3px;*/
            background-color: #fafafa;
            overflow: hidden;
        }
        
        
        #toc_bank li
        {
            float: left;
            margin: 0 2px 0 0;
            height: 24px;
        }
        #toc_bank li a
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            font-weight: bold;
            color: #555;
            display: block;
            float: left;
            height: 1.7em;
            padding-left: 10px;
            text-decoration: none;
            background-color: #e8e8e8;
            border-top: solid #ccc thin;
            border-left: solid #ccc thin;
            border-right: solid #ccc thin;
            border-bottom: none;
            border-radius: 5px 5px 0 0;
            margin-top: 2px;
        }
        #toc_bank li a span
        {
            display: block;
            line-height: 1.7em;
            padding-right: 10px;
        }
        #toc_bank li a.active
        {
            background-color: #fff;
            color: #c07000;
            border-top: solid #c8a050 2px;
            border-left: solid #c8a050 thin;
            border-right: solid #c8a050 thin;
        }
        #toc_bank li a:hover
        {
            background-color: #fff;
            color: #c07000;
        }
        #tag_label_Clientname1
        {
            /* float: left;*/
            width: 144px;
            height: 15px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            line-height: 20px;
            text-align: left;
            color: #232323;
        }
        
        
        /* section wrapper */
        #innerbox_AccInfo_main
        {
            width: 975px;
            min-height: 380px;
            border: 1px solid #ccc;
            background: #fff;
        }
        
        /* bottom button bar &#8212; same id/class as Client_Master_N */
        #innerbox_ClientMaster_bot_inn
        {
            clear: both;
            padding: 6px 4px;
            border-top: 1px solid #ddd;
            background: #f9f9f9;
        }
        #newbu, #editbu
        {
            float: left;
            margin-right: 4px;
        }
        
        .clear
        {
            clear: both;
        }
        
        /* title bar */
        #innerbox_MidMain_Transact_popup_new
        {
            height: 30px;
            width: 100%;
            margin-left: -2px;
        }
        #tag_srcinner1_new
        {
            float: left;
            width: 100%;
        }
        #mainmastop2container_rght_tag2_txt1
        {
            float: left;
            font-size: 13px;
            font-family: Arial, sans-serif;
            font-weight: bold;
            color: #fff;
            padding: 6px 10px;
        }
        #popupwindow_closebut_right_new
        {
            float: right;
            padding: 3px 6px;
        }
        
        .loading
        {
            position: absolute;
            top: 40%;
            left: 50%;
        }
        
        /* notification email copy link style */
        .copy-link
        {
            font-size: 11px;
            font-family: Arial, sans-serif;
            color: #0066cc;
            text-decoration: underline;
            cursor: pointer;
        }
        .grid-view
        {
            border: 1px solid #ccc;
            border-radius: 8px;
            overflow: hidden; /* Important */
        }
        #gv_Branch, [id$="gv_Branch"]
        {
            width: auto !important;
            min-width: 100%;
            table-layout: auto;
            white-space: nowrap;
        }
        .lnk-footer-new
        {
            color: #006600;
            font-size: 11px;
            font-weight: bold;
            text-decoration: none;
        }
        .lnk-footer-new:hover
        {
            text-decoration: underline;
            color: #009900;
        }
        
        .grid-view th, .grid-view tr.header-row th, .grid-view tr.header-row td
        {
            position: sticky;
            top: 0;
            z-index: 2;
            background-color: WhiteSmoke;
        }
        
        .selected-row, .selected-row td
        {
            background-color: #cfe8ff !important;
        }
        .btn-add-circle
        {
            display: inline-block;
            color: #28A745; /* Green */
            font-size: 36px;
            font-weight: bold;
            cursor: pointer;
            border: none;
            padding: 0;
            text-decoration: none;
            background: none;
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtGSTN_ID').keyup(function () {

                var a = $('#txtGSTN_ID').val();
                var Update_Val = document.getElementById("hdn_checkVal").value;

                if (Update_Val == 'New') {
                    var a = $('#txtGSTN_ID').val();
                    $('#txtCommercial_RegistrationNo').val(a);
                }
                else {

                }
            });
        });
     
    </script>
</head>
<body style="background-color: white; overflow: hidden;" onload="window.parent.parent.scrollTo(0,0);">
    <form id="form1" runat="server">
    <div class="custom-theme-scope">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
            LoadScriptsBeforeUI="false" EnablePageMethods="true">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
            <ContentTemplate>
                <div class="loading" align="center" id="load" style="display: none;">
                    <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
                </div>
                <div id="innerbox_MidMain_Transact_popup_new" style="height: 30px; width: 100%; margin-left: -2px;">
                    <div id="tag_srcinner1_new">
                        <div id="editbu">
                            <a href="#" class="edit"></a>
                        </div>
                        <div id="mainmastop2container_rght_tag2_txt1" style="margin-left: -12px; width: 89px;
                            margin-top: 1px;">
                            Client Master
                        </div>
                        <div id="verslic">
                        </div>
                        <div style="display: flex; align-items: center; gap: 6px; flex: 0 0 auto; margin-top: 8px;">
                            <label style="font-size: 14px; font-weight: bold; white-space: nowrap; width: 50px;">
                                IEC No:</label>
                            <asp:Label ID="lblIECNO" runat="server" ForeColor="red" Text="" Style="width: 90px;
                                display: inline-block;"></asp:Label>
                            <label style="font-size: 14px; font-weight: bold; white-space: nowrap; width: 40px;">
                                Name:</label>
                            <asp:Label ID="lblName" runat="server" ForeColor="red" Text="" Style="white-space: nowrap;
                                overflow: hidden; text-overflow: ellipsis; width: 573px; display: inline-block;"></asp:Label>
                            <label style="font-size: 14px; font-weight: bold; white-space: nowrap;">
                                Branch SL No:</label>
                            <asp:Label ID="lbl_BrSlNo" ForeColor="red" runat="server" Text=""></asp:Label>
                        </div>
                        <div id="popupwindow_closebut_right_new">
                            <%--<asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" />--%>
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                        </div>
                    </div>
                </div>
                <div id="branchGridScrollContainer" style="width: 1280; overflow: hidden; margin-top: 4px">
                    <div id="ed">
                        <span>Note: </span><span style="color: Green">S- Standard </span><span>|</span><span
                            style="color: Brown"> NS- Non-Standard </span>
                    </div>
                    <div id="branchGridScrollableDiv" style="float: left; width: 272px; height: 507px;
                        overflow-x: auto; overflow-y: auto; position: relative">
                        <asp:GridView ID="gv_Branch" runat="server" DataKeyNames="IMP_EXP_ID,IMP_EXP_BRSLNO,STANDARD_TYPE,IMP_EXP_NAME,IMP_EXP_IECNO"
                            EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                            CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True" OnRowDataBound="gv_Branch_RowDataBound"
                            OnSelectedIndexChanged="gv_Branch_SelectedIndexChanged" AllowSorting="True" BorderColor="#C8C8C8"
                            BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1" OnRowCreated="gv_Branch_RowCreated"
                            ShowFooter="true" OnRowCommand="gv_Branch_RowCommand" ClientIDMode="Static">
                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                BorderWidth="1px" />
                            <HeaderStyle Font-Underline="false" ForeColor="Black" CssClass="header-row" />
                            <FooterStyle CssClass="footer-row" />
                            <%-- NEW: this makes the <tr> itself carry the class --%>
                            <Columns>
                                <asp:TemplateField HeaderText="" HeaderStyle-Width="30px">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="lnkNewBranch" runat="server" CommandName="NewBranch" Text="+"
                                            ToolTip="Add New Branch" CssClass="btn-add-circle" />
                                    </HeaderTemplate>
                                    <HeaderStyle Width="30px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="IMP_EXP_BRSLNO" HeaderText="Br.No" HeaderStyle-Width="15px"
                                    HeaderStyle-ForeColor="Black">
                                    <HeaderStyle ForeColor="Black" Width="15px" />
                                    <ItemStyle Width="20px" CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="STANDARD_TYPE" HeaderText="S/NS" HeaderStyle-Width="40px"
                                    HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="Black">
                                    <HeaderStyle Font-Size="12px" ForeColor="Black" Width="40px" />
                                    <ItemStyle Width="20px" CssClass="column_style_left" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Client Name" HeaderStyle-HorizontalAlign="Center"
                                    HeaderStyle-Width="200px">
                                    <ItemTemplate>
                                        <span style="white-space: nowrap;">
                                            <%# Eval("IMP_EXP_NAME")%></span>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle CssClass="column_style_left" Font-Size="9px" Wrap="false" />
                                    <FooterStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="IMP_EXP_ADD3" HeaderText="City" HeaderStyle-Width="160px"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <HeaderStyle HorizontalAlign="Center" Width="160px" />
                                    <ItemStyle Width="160px" CssClass="column_style_left" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                NO RECORD FOUND
                            </EmptyDataTemplate>
                            <%--   <SelectedRowStyle BackColor="#99FFCC" />--%>
                        </asp:GridView>
                    </div>
                    <div style="float: right; width: 963px">
                        <div id="innerbox_MidMain_Trans_IGM" style="width: 989px; height: auto; min-height: 505px;
                            margin-left: -16px; margin-top: -19px;">
                            <ol id="toc">
                                <li style="height: 20px"><a href="#page-1" onclick="tab_page1('0'); document.getElementById('hdn_ActiveMainTab').value='page-1'; 
                             jQuery('#form1').validationEngine('hideAll'); return false;" id="IGM"><span>Client</span>
                                </a></li>
                                <li style="height: 20px"><a href="#page-2" onclick="tab_page2('0'); jQuery('#form1').validationEngine('hideAll'); return false;"
                                    id="CONTAINER" runat="server" visible="false"><span>Billing Party</span> </a>
                                </li>
                                <li style="height: 20px"><a href="#page-3" onclick="cm_tab_AccInfo(); document.getElementById('hdn_ActiveMainTab').value='page-3'; 
                             jQuery('#form1').validationEngine('hideAll'); return false;" id="ACCINFO" runat="server">
                                    <span>Account Info</span> </a></li>
                            </ol>
                            <div class="content" id="page-1">
                                <div id="innerbox_MidMain_popup_ClientMaster" style="height: 300px; width: 992px;
                                    margin-left: -15px; margin-top: -11px;">
                                    <div id="innerbox_MidMain_Mid_ClientMaster" style="height: 298px; width: 992px;">
                                        <div id="innerbox_MidMain_Mid_ClientMaster_l" style="height: 298px;">
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname" style="color: blue">
                                                    Select Type
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:RadioButtonList ID="RadioButtonList_TYPE" runat="server" Font-Names="Arial"
                                                        ForeColor="Blue" Font-Size="Small" RepeatDirection="Horizontal" TabIndex="1">
                                                        <asp:ListItem Text="Standard" Value="" Selected="True"></asp:ListItem>
                                                        <asp:ListItem Text="Non-Standard" Value="Non_STD"></asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    IEC No <span style="color: red">*</span>
                                                </div>
                                                <div id="txtcon-m_src" style="width: 110px">
                                                    <asp:TextBox ID="txtIECNO" runat="server" MaxLength="10" CssClass="validate[required,minSize[10]] txtbox_none"
                                                        TabIndex="3" Onkeypress="return numcharspl1(event)" Width="100px" onpaste="return validatePaste(event);"></asp:TextBox>
                                                    <%-- AutoPostBack="true" OnTextChanged="txtIECNO_TextChanged"--%>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                                <asp:Button ID="btnAdcode" CssClass="autowidnewbut" Text="New Adcode" Visible="false"
                                                    Style="width: 110px" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenAdCode(); return false" />
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Address 1
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtAdd1" runat="server" MaxLength="50" TabIndex="5" CssClass="validate[required] txtbox_none"
                                                        Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    <%--Address 2--%>
                                                    State
                                                </div>
                                                <div id="txtcon_mid_size">
                                                    <%-- <asp:TextBox ID="txtAdd2" runat="server" MaxLength="50" TabIndex="6" CssClass="txtbox_none"></asp:TextBox>--%>
                                                    <%-- <asp:TextBox ID="txtStateName" runat="server" CssClass="txtbox_none_mid_size" TabIndex="8"
                                                    ClientIDMode="Static" MaxLength="25" Onkeypress="return char(event)" onpaste="return validatePaste(event);"></asp:TextBox>


                                                <asp:HiddenField ID="hdn_Txt_Statecode" runat="server" />--%>
                                                    <asp:DropDownList ID="ddlStateName" Style="margin-top: 3px;" TabIndex="8" runat="server"
                                                        CssClass="listtxt_transac_mode_new" Width="225px" DataSourceID="XmlDataSource3"
                                                        DataTextField="text" DataValueField="value">
                                                    </asp:DropDownList>
                                                    <asp:XmlDataSource ID="XmlDataSource3" runat="server" DataFile="~/eRoyalMasters/CHA_State_Name_Code.xml"
                                                        XPath="ListItems/ListItem"></asp:XmlDataSource>
                                                </div>
                                                <%--  <div id="txtcon-r_src">
                                            </div>
                                            <div id="magnify_area">
                                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');opennew_District_Statecode('Client_State_District'); return false"
                                                    class="magnfy"></a>
                                            </div>--%>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    <%--City--%>
                                                    PAN No
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtPAN_No" runat="server" MaxLength="20" TabIndex="11" CssClass="txtbox_none"
                                                        onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Fax
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtFax" runat="server" MaxLength="20" TabIndex="16" CssClass="txtbox_none"
                                                        onkeypress="return phone(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Bin No
                                                </div>
                                                <div id="txtcon-m_src" style="width: 90px">
                                                    <asp:TextBox ID="txtBinNO" runat="server" Width="80px" MaxLength="50" TabIndex="19"
                                                        CssClass="txtbox_none" onkeypress="return numchar(event)"></asp:TextBox>
                                                </div>
                                                <div id="tag_label_Clientname" style="width: 50px">
                                                    TIN No
                                                </div>
                                                <div id="txtcon-m_src" style="width: 85px">
                                                    <asp:TextBox ID="txt_TIN_No" runat="server" Width="80px" MaxLength="20" TabIndex="23"
                                                        CssClass="txtbox_none"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    EXP GSTN Type</div>
                                                <div id="txtcon-m_src">
                                                    <asp:DropDownList ID="ddlGSTN_Type" runat="server" TabIndex="25" CssClass="listtxt-s_inner">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem Text="G/GSN -GSTIN of Normal Persons Individual IEC" Value="GSN"></asp:ListItem>
                                                        <asp:ListItem Text="O/GSG GSTIN of Govt.Entities" Value="GSG"></asp:ListItem>
                                                        <asp:ListItem Text="D/GSD - GSTIN of Diplomats" Value="GSD"></asp:ListItem>
                                                        <asp:ListItem Text="I/PAN PAN Number (AAAPL1234C)" Value="PAN"></asp:ListItem>
                                                        <asp:ListItem Text="T/TAN TAN Number (AAAP12345C)" Value="TAN"></asp:ListItem>
                                                        <asp:ListItem Text="P/PSP -Passport Number( Max 9 Characters-AN)" Value="PSP"></asp:ListItem>
                                                        <asp:ListItem Text="A/ADH Aadhaar Number( 12 Numeric)" Value="ADH"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    IMP GSTN Type</div>
                                                <div id="txtcon-m_src">
                                                    <asp:DropDownList ID="ddl_EXP_GSTN_Type" runat="server" TabIndex="28" CssClass="listtxt-s_inner">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem Text="G-GSTIN-NORMAL" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="O-GSTIN-GOVERNMENT" Value="O"></asp:ListItem>
                                                        <asp:ListItem Text="D-GSTIN-DIPLOMAT" Value="D"></asp:ListItem>
                                                        <asp:ListItem Text="A-AADHAAR" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="P-PASSPORT" Value="P"></asp:ListItem>
                                                        <asp:ListItem Text="T-TIN" Value="T"></asp:ListItem>
                                                        <asp:ListItem Text="I-PAN" Value="I"></asp:ListItem>
                                                        <asp:ListItem Text="V-VAT" Value="V"></asp:ListItem>
                                                        <asp:ListItem Text="C-CST" Value="C"></asp:ListItem>
                                                        <asp:ListItem Text="S-ST" Value="S"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    SEZ Icegate ID
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txt_SEZ_IcegateID" runat="server" MaxLength="30" onkeypress="return charnum2(event)"
                                                        TabIndex="31" CssClass="txtbox_none" ClientIDMode="Static" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    SEZ AP ID
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txt_SEZ_AP_ID" runat="server" MaxLength="100" onkeypress="return charnum2(event)"
                                                        TabIndex="35" CssClass="txtbox_none" ClientIDMode="Static" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Nature of Trans</div>
                                                <div id="txtcon-m_src">
                                                    <asp:DropDownList ID="ddlNatureOfTrans" CssClass="txtbox_none_Mid_transac_others_Name"
                                                        runat="server" Height="20px" TabIndex="38" Style="width: 220px;">
                                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="S Sale" Value="S Sale"></asp:ListItem>
                                                        <asp:ListItem Text="F Free Of Cost" Value="F Free Of Cost"></asp:ListItem>
                                                        <asp:ListItem Text="C Consignment" Value="C Consignment"></asp:ListItem>
                                                        <asp:ListItem Text="G Gift" Value="G Gift"></asp:ListItem>
                                                        <asp:ListItem Text="H Hire" Value="H Hire"></asp:ListItem>
                                                        <asp:ListItem Text="M Sample" Value="M Sample"></asp:ListItem>
                                                        <asp:ListItem Text="O Others" Value="O Others"></asp:ListItem>
                                                        <asp:ListItem Text="P Replacement" Value="P Replacement"> </asp:ListItem>
                                                        <asp:ListItem Text="R Rent" Value="R Rent"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                        </div>
                                        <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height: 298px">
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Type
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:DropDownList ID="ddlType" runat="server" TabIndex="2" CssClass="listtxt-s_inner">
                                                        <asp:ListItem Text="PRIVATE" Value="PRIVATE"></asp:ListItem>
                                                        <asp:ListItem Text="OTHERS" Value="OTHERS"></asp:ListItem>
                                                        <asp:ListItem Text="JOBBING" Value="JOBBING"></asp:ListItem>
                                                        <asp:ListItem Text="REPAIR & RETURN" Value="REPAIR & RETURN"></asp:ListItem>
                                                        <asp:ListItem Text="EXHIBITION" Value="EXHIBITION"></asp:ListItem>
                                                        <asp:ListItem Text="DESTRUCTION" Value="DESTRUCTION"></asp:ListItem>
                                                        <asp:ListItem Text="MOVEMENT OF GOODS" Value="MOVEMENT OF GOODS"></asp:ListItem>
                                                        <asp:ListItem Text="VESSELS" Value="VESSELS"></asp:ListItem>
                                                        <asp:ListItem Text="SAMPLE TESTING" Value="SAMPLE TESTING"></asp:ListItem>
                                                        <asp:ListItem Text="SHIP STORES" Value="SHIP STORES"></asp:ListItem>
                                                        <asp:ListItem Text="NEW AIRCRAFT" Value="NEW AIRCRAFT"></asp:ListItem>
                                                        <asp:ListItem Text="HAND CARRIAGE" Value="HAND CARRIAGE"></asp:ListItem>
                                                        <asp:ListItem Text="GOVERNMENT DEPARTMENTS" Value="GOVERNMENT DEPARTMENTS"></asp:ListItem>
                                                        <asp:ListItem Text="GOVERNMENT UNDERTAKINGS" Value="GOVERNMENT UNDERTAKINGS"></asp:ListItem>
                                                        <asp:ListItem Text="UNCLAIMED CARGO" Value="UNCLAIMED CARGO"></asp:ListItem>
                                                        <asp:ListItem Text="TRADING" Value="TRADING"></asp:ListItem>
                                                        <asp:ListItem Text="MANUFATURED GOODS" Value="MANUFATURED GOODS"></asp:ListItem>
                                                        <asp:ListItem Text="CBW" Value="CBW"></asp:ListItem>
                                                        <asp:ListItem Text="SEZ-T TO SEZ" Value="SEZ-T TO SEZ"></asp:ListItem>
                                                        <asp:ListItem Text="SEZ-M TO SEZ" Value="SEZ-M TO SEZ"></asp:ListItem>

                                                    </asp:DropDownList>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname" style="width: 44px">
                                                    Name <span style="color: red">*</span>
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="validate[required] txtbox_none"
                                                        ClientIDMode="Static" Width="275px" TabIndex="3" Onkeypress="return numcharspl1(event)"
                                                        onpaste="return validatePaste(event);"></asp:TextBox>
                                                    <%--   AutoPostBack="true" OnTextChanged="txtName_TextChanged"--%>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Address 2
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtAdd2" runat="server" MaxLength="50" TabIndex="6" CssClass="txtbox_none"
                                                        Onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    District
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtDistrict" Width="220px" Height="18px" runat="server" CssClass="txtbox_none_mid_size"
                                                        TabIndex="8" MaxLength="25" Onkeypress="return char(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                                                    <asp:HiddenField ID="hdn_Txt_District" runat="server" />
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Contact Person
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtContactPerson" runat="server" MaxLength="50" TabIndex="12" CssClass="txtbox_none"
                                                        onkeypress="return char(event)"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    E-Mail
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" TabIndex="17" CssClass="txtbox_none"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    <%--State Name--%>
                                                    WarehouseCode
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <%--<asp:TextBox ID="txtCommercial_StateName" runat="server" MaxLength="40" onkeypress="return char(event)"
                                                    onpaste="return validatePaste(event);" TabIndex="24" CssClass="txtbox_none" ClientIDMode="Static"></asp:TextBox>--%>
                                                    <asp:TextBox ID="txtWarehouseCode" Width="220px" Height="18px" runat="server" CssClass="txtbox_none"
                                                        TabIndex="24" MaxLength="200" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    GSTN ID
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtGSTN_ID" runat="server" MaxLength="20" TabIndex="26" CssClass="txtbox_none"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    GSTN ID</div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtCommercial_RegistrationNo" runat="server" MaxLength="20" onkeypress="return charnum2(event)"
                                                        onpaste="return validatePaste(event);" TabIndex="29" onblur="ChangeCase(this);"
                                                        onkeyup="ChangeCase(this);" onkeydown="ChangeCase(this);" ClientIDMode="Static"
                                                        CssClass="txtbox_none"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    SEZ PAN No</div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txt_SEZ_PANNo" runat="server" MaxLength="20" onkeypress="return charnum2(event)"
                                                        onpaste="return validatePaste(event);" TabIndex="32" ClientIDMode="Static" CssClass="txtbox_none"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    SEZ AP Name
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txt_SEZ_AP_Name" runat="server" MaxLength="100" onkeypress="return charnum2(event)"
                                                        onpaste="return validatePaste(event);" TabIndex="36" CssClass="txtbox_none" ClientIDMode="Static"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname" style="display: flex; align-items: center; gap: 10px;
                                                white-space: nowrap;">
                                                <div id="tag_label_Clientname">
                                                    Nature of Payment</div>
                                                <div id="txtcon-m_src">
                                                    <asp:DropDownList ID="ddlNatureOfPayment" CssClass="txtbox_none_Mid_transac_InvNew"
                                                        runat="server" Height="20px" TabIndex="39" Style="width: 220px;">
                                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OTH Others" Value="OTH Others"></asp:ListItem>
                                                        <asp:ListItem Text="DP Document Presentation" Value="DP Document Presentation"></asp:ListItem>
                                                        <asp:ListItem Text="FC Free Of Charge" Value="FC Free Of Charge"></asp:ListItem>
                                                        <asp:ListItem Text="LC Letter Of Credit" Value="LC Letter Of Credit"></asp:ListItem>
                                                        <asp:ListItem Text="SD Site Draft" Value="SD Site Draft"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                        </div>
                                        <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height: 298px; width: 300px;">
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                </div>
                                                <div id="txtcon-m_src">
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Branch No <span style="color: red">*</span>
                                                </div>
                                                <div id="txtcon-m_src">
                                                    <asp:TextBox ID="txtBranchNO" runat="server" MaxLength="3" TabIndex="4" CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small"
                                                        onfocus="EnableActionButtons(true);" Onkeypress="return num1(event)"></asp:TextBox>
                                                    <%--  onblur="Check_DuplicateOnBranchLeave()"   AutoPostBack="true" OnTextChanged="txtBranchNO_TextChanged"--%>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    City<span style="color: Red"> *</span>
                                                </div>
                                                <div id="txtcon-m_src" style="width: 180px;">
                                                    <asp:TextBox ID="txtcity" runat="server" MaxLength="35" CssClass="validate[required] txtbox_none"
                                                        TabIndex="7" Width="180px" onkeypress="return city1(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    PIN Code
                                                </div>
                                                <div id="txtcon-m_src" style="width: 180px;">
                                                    <asp:TextBox ID="txtPincode" runat="server" MaxLength="6" CssClass="validate[minSize[6],custom[phone]] txtbox_none"
                                                        Width="180px" TabIndex="9" onkeypress="return pin(event)"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Phone No
                                                </div>
                                                <div id="txtcon-m_src" style="width: 180px;">
                                                    <asp:TextBox ID="txtPhoneNO" runat="server" MaxLength="20" TabIndex="15" CssClass="txtbox_none"
                                                        Width="180px" onkeypress="return phone(event)"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Remarks
                                                </div>
                                                <div id="txtcon-m_src" style="width: 180px;">
                                                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtbox_none" TabIndex="18"
                                                        Width="180px" MaxLength="200" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                          
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    State Name <span style="color: red">*</span>
                                                </div>
                                                <div id="txtcon-m_src" style="width: 180px;">
                                                    <asp:DropDownList ID="ddlCommercial_StateName" Style="margin-top: 3px;" TabIndex="27"
                                                        runat="server" CssClass="validate[required] txtbox_none" Width="185px" DataSourceID="XmlDataSource4"
                                                        DataTextField="text" DataValueField="value" onchange="ChangeStateCode()">
                                                    </asp:DropDownList>
                                                    <asp:XmlDataSource ID="XmlDataSource4" runat="server" DataFile="~/eRoyalMasters/CHA_State_Name_Code.xml"
                                                        XPath="ListItems/ListItem"></asp:XmlDataSource>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    State Code
                                                </div>
                                                <div id="txtcon-m_src" style="width: 70px;">
                                                    <asp:TextBox ID="txtCommercial_StateCode" runat="server" MaxLength="40" ClientIDMode="Static"
                                                        onkeypress="return num1(event)" TabIndex="30" CssClass="txtbox_none_Mid_transac_item_CTH_small"></asp:TextBox>
                                                </div>
                                                <%--<div id="txtcon-r_src">
                                                <div runat="server" id="ST_Code">
                                                    <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');opennewStatecode('IMPORT_STATECODE'); return false">
                                                    </a>
                                                </div>
                                            </div>--%>
                                            </div>
                                            <%--<div id="pop_text_area_Clientname">
                                            <div id="tag_label_Clientname">
                                                WarehouseCode
                                            </div>
                                            <div id="txtcon-m_src" style="width: 180px;">
                                                <asp:TextBox ID="txtWarehouseCode" runat="server" CssClass="txtbox_none" TabIndex="35"
                                                    Width="180px" MaxLength="200" onpaste="return validatePaste(event);"></asp:TextBox>
                                            </div>
                                            <div id="txtcon-r_src">
                                            </div>
                                        </div>--%>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Payment Method
                                                </div>
                                                <div id="txtcon-m_src" style="width: 180px;">
                                                    <asp:DropDownList ID="ddl_Payment_Method" runat="server" CssClass="txtbox_none" TabIndex="33"
                                                        Width="180px" MaxLength="200" onpaste="return validatePaste(event);" onkeypress="return char(event)">
                                                        <asp:ListItem Text="T-TRANSACTIONAL" Value="T"></asp:ListItem>
                                                        <asp:ListItem Text="D-DIFFERED" Value="D"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                    Item End Use
                                                </div>
                                                <div id="txtcon-m_src" style="width: 80px;">
                                                    <asp:TextBox ID="txtEndUse" runat="server" MaxLength="35" CssClass="txtbox_none"
                                                        onkeypress="return desc2(event)" TabIndex="37" Width="80px" oninput="this.value = this.value.toUpperCase();"></asp:TextBox>
                                                </div>
                                                <div id="txtcon-r_src">
                                                    <div id="magnify_area">
                                                        <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_End_Use_Of_Itemd('End_Use'); return false">
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="pop_text_area_Clientname" style="display: flex; align-items: center; gap: 6px;
                                                white-space: nowrap;">
                                                <div id="tag_label_Clientname">
                                                    IGST Paymt Sts</div>
                                                <div id="txtcon-m_src">
                                                    <asp:DropDownList ID="ddl_IGST_Payment" runat="server" Height="20px" TabIndex="40"
                                                        CssClass="listtxt-s_inner" Style="width: 180px;">
                                                        <asp:ListItem>NA</asp:ListItem>
                                                         <asp:ListItem>LUT</asp:ListItem>
                                                         <asp:ListItem>P</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                              <%--<div id="pop_text_area_Clientname">
                                                <div id="tag_label_Clientname">
                                                </div>
                                                <div id="txtcon-m_src">
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>--%>
                                            <div id="pop_text_area_Clientname" style="display: flex; align-items: center; gap: 6px;
                                                white-space: nowrap;">
                                                <div id="tag_label_Clientname">
                                                    Valuation Method</div>
                                                <div id="txtcon-m_src">
                                                    <asp:DropDownList ID="ddlValuationMethod" runat="server" Height="20px" TabIndex="40"
                                                        CssClass="listtxt-s_inner" Style="width: 180px;">
                                                        <asp:ListItem></asp:ListItem>
                                                        <asp:ListItem>Rule 4 - Transaction Value </asp:ListItem>
                                                        <asp:ListItem>Rule 5 - Identical Goods</asp:ListItem>
                                                        <asp:ListItem>Rule 6 - Similar Goods</asp:ListItem>
                                                        <asp:ListItem>Rule 7 - Deductive Value</asp:ListItem>
                                                        <asp:ListItem>Rule 8 - Computed Value</asp:ListItem>
                                                        <asp:ListItem>Rule 9 - Residual Method</asp:ListItem>
                                                        <asp:ListItem>Rule 10 - Cost and Services</asp:ListItem>
                                                        <asp:ListItem>Rule 11 - Declaration by Importer</asp:ListItem>
                                                        <asp:ListItem>Rule 12 - Rejection of Declared Value</asp:ListItem>
                                                        <asp:ListItem>OTHERS - Others</asp:ListItem>
                                                        <asp:ListItem>Rule 3-Determination Method of Valuation</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div id="txtcon-r_src">
                                                </div>
                                            </div>
                                        </div>
                                        <div id="frame2_export_item_otherdet_new1" style="width: 685px; height: 150px;">
                                            <div id="tag_label_transaction_export_Item_otherdet_frmlabel_new1" style="margin-left: -5px;">
                                                Export Details
                                            </div>
                                            <div style="margin-left: 10px;">
                                                <div id="tag_transac_lft_trans_item_maindet_in1_">
                                                    <div id="tag_label_transaction_export_Item_otherdet_new1">
                                                        Type of Exp.
                                                    </div>
                                                    <div id="txtcon-m_transaction_item_maindet">
                                                        <asp:DropDownList ID="ddlType_Exp" runat="server" CssClass="listtxt_transac_src1"
                                                            TabIndex="41" Width="150px">
                                                            <asp:ListItem Text="Manufacturer - ( F )" Value="F"></asp:ListItem>
                                                            <asp:ListItem Text="Merchant - ( R )" Value="R"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div id="tag_label_transaction_popup_IGM2_empty" style="width: 120px">
                                                    </div>
                                                    <div id="tag_label_transaction_export_Item_otherdet_new1">
                                                        DBK A/C No
                                                    </div>
                                                    <div id="txtcon-m_transaction_item_maindet">
                                                        <asp:TextBox ID="txtDrawback_AC_No" runat="server" MaxLength="50" TabIndex="42" CssClass="txtbox_none"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div id="tag_transac_lft_trans_item_maindet_in1_">
                                                    <div id="tag_label_transaction_export_Item_otherdet_new1">
                                                        Item STR Allow
                                                    </div>
                                                    <div id="txtcon-m_transaction_item_maindet" style="width: 150px">
                                                        <asp:RadioButtonList ID="Rdstr" runat="server" RepeatDirection="Horizontal" TabIndex="43">
                                                            <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </div>
                                                    <div id="div_dbk_decl" runat="server">
                                                        <div id="tag_label_transaction_export_Item_otherdet_new1" style="width: 80px">
                                                            Declaration
                                                        </div>
                                                        <div id="txtcon-m_transaction_item_maindet" style="width: 200px">
                                                            <asp:CheckBox ID="chk_DB001" runat="server" Text="DB001" TabIndex="44" />
                                                            <asp:CheckBox ID="chk_DB002" runat="server" Text="DB002" TabIndex="47" />
                                                            <asp:CheckBox ID="chk_DB003" runat="server" Text="DB003" TabIndex="50" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 940px">
                                                    <div id="tag_label_transaction_export_Item_otherdet_new1">
                                                        Marks & Nos
                                                    </div>
                                                    <div id="txtcon-m_transaction_item_maindet" style="width: 800px; height: 15px;">
                                                        <asp:TextBox ID="txt_Marksnos" TextMode="MultiLine" TabIndex="51" runat="server"
                                                            Width="600px" CssClass="txtbox_none_Mid_transac_item_gen_decs_EXP" MaxLength="300"
                                                            onkeyDown="return checkTextAreaMaxLength(this,event,'300');" onpaste="return checkTextAreaMaxLength(this,event,'300');"
                                                            Onkeypress="return numcharspl1(event)"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div id="tag_transac_lft_trans_item_maindet_in1_">
                                                    <div id="tag_label_transaction_export_Item_otherdet_new1">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div id="frame2_export_item_otherdet_new1" style="width: 265px; height: 150px;">
                                            <div id="tag_label_transaction_export_Item_otherdet_frmlabel_new1" style="height: 10px;">
                                                Other Details
                                            </div>
                                            <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 350px;">
                                                <div id="tag_label_Clientname">
                                                    Insurance Rate
                                                </div>
                                                <div id="txtcon-m_src" style="width: 210px">
                                                    <asp:TextBox ID="txtInsuranceRate" runat="server" MaxLength="8" TabIndex="52" onblur="extractNumber(this,4,false);"
                                                        onkeyup="extractNumber(this,4,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                        CssClass="validate[custom[number]] txtbox_none" Width="100px" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 350px;">
                                                <div id="tag_label_Clientname">
                                                    TAN Number
                                                </div>
                                                <div id="txtcon-m_src" style="width: 110px">
                                                    <asp:TextBox ID="txt_TAN_Number" runat="server" MaxLength="10" CssClass="txtbox_none"
                                                        TabIndex="53" Width="100px" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 350px;">
                                                <div id="tag_label_Clientname">
                                                    TDS Code
                                                </div>
                                                <div id="txtcon-m_src" style="width: 110px">
                                                    <asp:TextBox ID="txt_TDS_Code" runat="server" MaxLength="10" CssClass="txtbox_none"
                                                        TabIndex="54" Width="100px" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 350px;">
                                                <div id="tag_label_Clientname">
                                                    TDS Rate
                                                </div>
                                                <div id="txtcon-m_src" style="width: 110px">
                                                    <asp:TextBox ID="txt_TDS_Rate" runat="server" MaxLength="4" TabIndex="55" onblur="extractNumber(this,4,false);"
                                                        onkeyup="extractNumber(this,4,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                        CssClass="validate[custom[number]] txtbox_none" Width="100px" onpaste="return validatePaste(event);"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="content" id="page-2" style="display: none;">
                                <iframe src="" name="trans_igm_container" style="width: 910px; height: 400px;" scrolling="no"
                                    id="trans_ETP_Container_iframe"></iframe>
                            </div>
                            <div class="content" id="page-3" style="display: none; padding: 0; min-height: 340px;
                                height: auto">
                                <ol id="toc_inner">
                                    <li><a href="#" id="inner_General" onclick="cm_showInnerTab('inner-General'); 
                                document.getElementById('hdn_ActiveInnerTab').value='inner-General';
                                return false;"><span>General</span></a> </li>
                                    <li><a href="#" id="inner_TDS" onclick="cm_showInnerTab('inner-TDS'); 
                                document.getElementById('hdn_ActiveInnerTab').value='inner-TDS'; 
                                return false;"><span>TDS Details</span></a> </li>
                                    <li><a href="#" id="inner_Bank" onclick="cm_showInnerTab('inner-Bank');
                                document.getElementById('hdn_ActiveInnerTab').value='inner-Bank';
                                 return false;"><span>Bank Details</span></a> </li>
                                </ol>
                                <div id="inner-General" style="display: block; padding: 8px 6px; margin-top: -5px;">
                                    <ol id="toc_deep">
                                        <li><a href="#" id="deep_Customer" onclick="cm_showDeepTab('deep-Customer');
                                     document.getElementById('hdn_ActiveDeepTab').value='deep-Customer';
                                     return false;"><span>Customer</span> </a></li>
                                        <li><a href="#" id="deep_Vendor" onclick="cm_showDeepTab('deep-Vendor'); 
                                    document.getElementById('hdn_ActiveDeepTab').value='deep-Vendor';
                                    return false;"><span>Vendor</span> </a></li>
                                    </ol>
                                    <div id="deep-Customer" style="display: block; padding: 8px 10px; border-radius: 10px">
                                        <div id="Div1" style="display: flex; gap: 8px;">
                                            <div id="tag_label_Clientname1">
                                                Credit Limit
                                            </div>
                                            <div id="Div3" style="width: 100px;">
                                                <asp:TextBox ID="txtCust_CreditLimit" runat="server" Style="width: 131px; margin-left: 15px;"
                                                    CssClass="txtbox_none" MaxLength="15" TabIndex="101" Width="90px" onkeypress="return blockNonNumbers(this,event,true,false);"
                                                    onpaste="return validatePaste(event);">
                                                </asp:TextBox>
                                            </div>
                                            <div>
                                                <asp:DropDownList ID="ddlCust_cur" TabIndex="102" Style="height: 20px; width: 69px;
                                                    margin-left: 55px;" CssClass="listtxt-s_inner" runat="server">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem>USD</asp:ListItem>
                                                    <asp:ListItem>INR</asp:ListItem>
                                                    <asp:ListItem>EUR</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="Div5" style="width: 80px; padding-top: 2px;">
                                                <asp:CheckBox ID="chkCust_Unlimited" runat="server" TabIndex="103" />
                                                <span style="font-size: 11px; font-family: Arial;">Unlimited</span>
                                            </div>
                                            <div id="Div6" style="width: 120px; padding-top: 2px;">
                                                <asp:CheckBox ID="chkCust_CashOnDelivery" runat="server" TabIndex="104" />
                                                <span style="font-size: 11px; font-family: Arial;">Cash On Delivery</span>
                                            </div>
                                            <div id="Div7">
                                            </div>
                                        </div>
                                        <%-- ROW 2: Inv. Overdue Restriction --%>
                                        <div id="Div8" style="display: flex; gap: 15px; margin-top: 15px">
                                            <div id="tag_label_Clientname1">
                                                Inv. Overdue Restriction
                                            </div>
                                            <div id="Div10" style="width: 20px; padding-top: 2px">
                                                <asp:CheckBox ID="chkCust_InvOverdue" runat="server" Style="margin-top: 15px; margin-left: 5px;"
                                                    TabIndex="105" />
                                            </div>
                                            <div id="Div11">
                                                <asp:DropDownList ID="ddlCust_InvOverdue" Style="height: 20px" runat="server" CssClass="listtxt-s_inner"
                                                    TabIndex="106">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="Include WIP Shipment" Value="WIP"></asp:ListItem>
                                                    <asp:ListItem Text="Exclude WIP Shipment" Value="XWIP"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="Div12">
                                            </div>
                                        </div>
                                        <%-- ROW 3: Credit On Hold --%>
                                        <div id="Div13" style="display: flex; gap: 10px; margin-top: 13px;">
                                            <div id="tag_label_Clientname1">
                                                Credit On Hold
                                            </div>
                                            <div id="Div15" style="width: 20px; padding-top: 2px; margin-left: 10px; margin-bottom: 10px;">
                                                <asp:CheckBox ID="chkCust_CreditOnHold" runat="server" TabIndex="107" />
                                            </div>
                                            <div id="Div16">
                                                <asp:TextBox ID="txtCust_CreditOnHold_Remarks" runat="server" CssClass="txtbox_none"
                                                    MaxLength="100" TabIndex="108" onpaste="return validatePaste(event);">
                                                </asp:TextBox>
                                            </div>
                                            <div id="Div17">
                                            </div>
                                        </div>
                                        <%-- ROW 4: Receivable Credit Period --%>
                                        <div id="Div18" style="display: flex; justify-content: flex-start; gap: 20px; margin-bottom: 12px;">
                                            <div id="tag_label_Clientname1">
                                                Receivable Credit Period
                                            </div>
                                            <div id="Div20">
                                                <asp:DropDownList ID="ddlCust_CreditPeriod" Height="20px" runat="server" CssClass="listtxt-s_inner"
                                                    TabIndex="109">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="No Of Days" Value="DAYS"></asp:ListItem>
                                                    <asp:ListItem Text="End Of Month" Value="EOM"></asp:ListItem>
                                                    <asp:ListItem Text="Fixed Date" Value="FD"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="Div21" style="width: 60px;">
                                                <asp:TextBox ID="txtCust_CreditDays" runat="server" CssClass="txtbox_none" MaxLength="5"
                                                    TabIndex="110" Width="50px" Text="0" onkeypress="return blockNonNumbers(this,event,false,false);">
                                                </asp:TextBox>
                                            </div>
                                            <div id="Div22">
                                            </div>
                                        </div>
                                        <%-- ROW 5: Customer G/L --%>
                                        <div id="Div23" style="display: flex; flex-direction: row; justify-content: flex-start;
                                            gap: 10px;">
                                            <div id="tag_label_Clientname1">
                                                Customer G/L
                                            </div>
                                            <div id="Div25">
                                                <asp:TextBox ID="txtCust_GL" TabIndex="111" CssClass="txtbox_none" Style="margin-left: 9px;"
                                                    runat="server"></asp:TextBox>
                                            </div>
                                            <div id="Div26">
                                                <div id="Div27">
                                                    <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');opennewCustomerGL('ASSETS'); return false;">
                                                    </a>
                                                </div>
                                            </div>
                                            <a href="#" style="margin-top: 3px;" onclick="jQuery('#form1').validationEngine('hideAll');
                                                openAccountGL('ASSETS','<%=txtCust_GL.ClientID %>');return false;">Create &amp;
                                                Link GL</a>
                                        </div>
                                        <%-- ROW 6: Notification Emails --%>
                                        <div id="Div28" style="display: flex; gap: 5px; margin-top: 12px;">
                                            <div id="tag_label_Clientname1">
                                                Notification Emails
                                            </div>
                                            <div id="Div30" style="display: grid; margin-left: 15px; gap: 7px;">
                                                <asp:TextBox ID="txtCust_NotifEmail" runat="server" CssClass="txtbox_none" MaxLength="200"
                                                    TabIndex="112" ClientIDMode="Static" onpaste="return validatePaste(event);">
                                                </asp:TextBox>
                                             
                                            </div>
                                        </div>
                                        <%-- ROW 7: Optional Criteria --%>
                                        <div id="Div32" style="display: flex; margin-top: 12px; margin-left: -21px;">
                                            <div id="Div33">
                                                &nbsp;
                                            </div>
                                            <div id="Div34" style="width: 27px; padding: 2px; margin-left: 10px;">
                                                <asp:CheckBox ID="chkCust_OptionalCriteria" runat="server" TabIndex="113" />
                                            </div>
                                            <div id="Div35" style="width: 310px; padding-top: 2px;">
                                                <span style="font-size: 11px; font-family: Arial; font-weight: bold; color: #333;">Optional
                                                    Criteria for credit period applicable to Forwarding </span>
                                            </div>
                                            <div id="Div36">
                                            </div>
                                        </div>
                                        <%-- ROW 8: Receivable --%>
                                        <div id="Div37" style="display: flex; gap: 16px; margin-top: 10px">
                                            <div id="tag_label_Clientname1">
                                                Receivable
                                            </div>
                                            <div id="Div39">
                                                <asp:DropDownList ID="ddlCust_Receivable" Height="20px" Style="margin-left: 6px;"
                                                    runat="server" CssClass="listtxt-s_inner" TabIndex="114">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="ATA / ATD" Value="ATA_ATD"></asp:ListItem>
                                                    <asp:ListItem Text="ETD" Value="ETD"></asp:ListItem>
                                                    <asp:ListItem Text="ETA" Value="ETA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="Div40">
                                                <asp:DropDownList ID="ddlCust_ReceivablePeriod" Height="20px" runat="server" CssClass="listtxt-s_inner"
                                                    TabIndex="115">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="No Of Days" Value="DAYS"></asp:ListItem>
                                                    <asp:ListItem Text="End Of Month" Value="EOM"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="Div41" style="width: 60px;">
                                                <asp:TextBox ID="txtCust_ReceivableDays" runat="server" CssClass="txtbox_none" MaxLength="5"
                                                    TabIndex="116" Width="50px" Text="0" onkeypress="return blockNonNumbers(this,event,false,false);">
                                                </asp:TextBox>
                                            </div>
                                            <div id="Div42">
                                            </div>
                                        </div>
                                        <%-- ROW 9: Currency --%>
                                        <div id="Div43" style="display: flex; margin-top: 10px;">
                                            <div id="tag_label_Clientname1">
                                                Currency
                                            </div>
                                            <div id="Div45">
                                                <asp:DropDownList ID="ddlCust_Currency" Height="20px" Style="margin-left: 22px;"
                                                    runat="server" CssClass="listtxt-s_inner" TabIndex="117">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                                    <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                                                    <asp:ListItem Text="EUR" Value="EUR"></asp:ListItem>
                                                    <asp:ListItem Text="GBP" Value="GBP"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="Div46">
                                            </div>
                                        </div>
                                    </div>
                                    <div id="deep-Vendor" style="display: none; padding: 8px 10px; min-height: 220px;
                                        height: 330px; border-radius: 10px">
                                        <div id="VenderCreditLimit" style="display: flex; gap: 8px;">
                                            <div id="tag_label_Clientname1">
                                                Credit Limit
                                            </div>
                                            <div id="Div50" style="width: 80px; padding-top: 2px;">
                                                <asp:CheckBox ID="chk_vendor_crt_limit" runat="server" TabIndex="118" />
                                                <span style="font-size: 11px; font-family: Arial;">Unlimited</span>
                                            </div>
                                            <div id="Div49" style="width: 35px; margin-left: 3px; margin-top: 3px;">
                                                <asp:TextBox ID="txtCreditLimit" runat="server" CssClass="txtbox_none" MaxLength="20"
                                                    TabIndex="117" Width="50px" Text="INR">
                                                </asp:TextBox>
                                            </div>
                                            <div id="div_vendorCurrency">
                                                <asp:DropDownList ID="ddl_vendor_currency" Style="height: 20px; width: 65px; margin-left: 23px;
                                                    margin-top: 5px;" CssClass="listtxt-s_inner" TabIndex="119" runat="server">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem>USD</asp:ListItem>
                                                    <asp:ListItem>INR</asp:ListItem>
                                                    <asp:ListItem>EUR</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div id="Vendor_PayableCreditCard" style="display: flex; gap: 5px; margin-top: 10px;">
                                            <div id="tag_label_Clientname1">
                                                Payable Credit Period
                                            </div>
                                            <div id="payableddl">
                                                <asp:DropDownList ID="ddlPayableCreditCard" Height="20px" TabIndex="120" CssClass="listtxt-s_inner"
                                                    runat="server">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="No Of Days" Value="No Of Days"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="Div51">
                                                <asp:TextBox ID="txtPayableCreditNumbers" runat="server" CssClass="txtbox_none" MaxLength="5"
                                                    TabIndex="121" Width="50px" Text="0" onkeypress="return blockNonNumbers(this,event,false,false);">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="DuedateCalculate" style="display: flex; margin-top: 8px; gap: 5px;">
                                            <div id="tag_label_Clientname1">
                                                Due Date Calculated
                                            </div>
                                            <div id="div_DueDateddl">
                                                <asp:DropDownList ID="ddlDuedateCalculate" Height="20px" TabIndex="122" CssClass="listtxt-s_inner"
                                                    runat="server">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="TransactionDate" Value="Transaction Date"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div id="div_Currency" style="display: flex; margin-top: 8px; gap: 5px;">
                                            <div id="tag_label_Clientname1">
                                                Currency
                                            </div>
                                            <div id="divcurrency">
                                                <asp:DropDownList ID="ddlVendorCurrency2" TabIndex="123" Height="20px" CssClass="listtxt-s_inner"
                                                    runat="server">
                                                    <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                                                    <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div id="div_vendorGL" style="display: flex; gap: 5px; margin-top: 8px">
                                            <div id="tag_label_Clientname1">
                                                Vendor G/L
                                            </div>
                                            <div id="Div9">
                                                <%--<asp:DropDownList ID="ddlvendorGL" TabIndex="124" CssClass="listtxt-s_inner" AppendDataBoundItems="true"
                                                    runat="server">
                                                    <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                                                </asp:DropDownList>--%>
                                                <asp:TextBox ID="txtVendorGL" TabIndex="124" CssClass="txtbox_none" runat="server"></asp:TextBox>
                                            </div>
                                            <div id="divImgSearch">
                                                <div id="Div52">
                                                    <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');opennewCustomerGL('LIABILITIES'); return false;">
                                                    </a>
                                                </div>
                                            </div>
                                            <a href="#" style="margin-top: 3px;" onclick="jQuery('#form1').validationEngine('hideAll');openAccountGL('LIABILITIES','<%=txtVendorGL.ClientID %>'); return false;">
                                                Create &amp; Link GL</a>
                                        </div>
                                        <div id="div_noticationMail" style="display: flex; gap: 5px; margin-top: 8px;">
                                            <div id="tag_label_Clientname1">
                                                Notification Emails
                                            </div>
                                            <div id="div_txtNotification" style="display: grid; margin-left: 2px; gap: 7px;">
                                                <asp:TextBox ID="txt_Notification" runat="server" CssClass="txtbox_none" MaxLength="200"
                                                    TabIndex="125" ClientIDMode="Static" onpaste="return validatePaste(event);">
                                                </asp:TextBox>
                                                <%--   <span><a href="#" style="font-size: 11px; font-family: Arial; color: #0066cc; text-decoration: underline;
                                                cursor: pointer;" onclick="CopyEmailToVendor(); return false;">Copy to Customer
                                            </a></span>--%>
                                            </div>
                                        </div>
                                        <div id="div_paymentOnHold" style="display: flex; margin-top: 8px">
                                            <div id="tag_label_Clientname1">
                                                Payment On Hold</div>
                                            <div id="div_chkpaymenthold">
                                                <asp:CheckBox ID="chkpaymentHold" runat="server" TabIndex="126" /></div>
                                            <div id="divtxtpaymentHold">
                                                <asp:TextBox ID="txtPaymentonHold" runat="server" CssClass="txtbox_none" MaxLength="200"
                                                    TabIndex="127" ClientIDMode="Static" Style="margin-left: 8px;" onpaste="return validatePaste(event);">
                                                </asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%-- /inner-General --%>
                                <%-- &#9552;&#9552; INNER: TDS DETAILS &#8212; empty for now &#9552;&#9552; --%>
                                <div id="inner-TDS" style="display: none; padding: 8px 10px; height: 380px; background-color: #f2f2f2;">
                                    <div id="div_FiscalYear" style="display: flex;">
                                        <div id="tag_label_Clientname1">
                                            Fiscal Year
                                        </div>
                                        <div id="div_ddlFinyear">
                                            <asp:DropDownList ID="ddlFinyear" TabIndex="128" Height="20px" Style="margin-left: 67px;"
                                                CssClass="listtxt-s_inner" runat="server">
                                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Apr/26 - Mar/27" Value="Apr/26 - Mar/27"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div id="div_OrgaizationType" style="display: flex; margin-top: 9px;">
                                        <div id="tag_label_Clientname1">
                                            Organization Type
                                        </div>
                                        <div id="div_ddlOrgaizationList">
                                            <asp:DropDownList ID="ddlOrganizationList" TabIndex="129" Height="20px" Style="margin-left: 67px;"
                                                CssClass="listtxt-s_inner" runat="server">
                                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Company" Value="Company"></asp:ListItem>
                                                <asp:ListItem Text="Company1" Value="Company1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div id="div_chkSpecifiedPersonChk" style="display: flex; margin-top: 9px;">
                                        <div id="tag_label_Clientname1" style="width: 211px">
                                            Specified person as per u/s 206 AB
                                        </div>
                                        <div id="Div_chk_specifiedperson">
                                            <asp:CheckBox ID="chk_specifiedperson" TabIndex="130" runat="server" />
                                        </div>
                                    </div>
                                    <div id="div_TdsReceivable" style="display: flex; margin-top: 9px; margin-bottom: 12px;">
                                        <div id="tag_label_Clientname1">
                                            TDS Receivable
                                        </div>
                                        <div id="div_TdsReceivable">
                                            <asp:DropDownList ID="ddlTds" Height="20px" TabIndex="131" Style="margin-left: 67px;"
                                                CssClass="listtxt-s_inner" runat="server">
                                                <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Value 1" Value="Value1"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div id="div_gv_TDS_Detail" style="margin-left: -7px;">
                                        <asp:GridView ID="gv_TDS_Detail" runat="server" DataKeyNames="" EmptyDataText="NO RECORD FOUND"
                                            AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                            ShowHeaderWhenEmpty="True" PageSize="5" AllowPaging="True" OnPageIndexChanging="gv_TDS_Detail_PageIndexChanging"
                                            AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                            CellPadding="1" CellSpacing="1" OnRowCreated="gv_TDS_Detail_RowCreated">
                                            <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                                BorderWidth="1px" />
                                            <Columns>
                                                <asp:BoundField DataField="A_T_FISCALYEAR" HeaderText="Fiscal year">
                                                    <%--  HeaderStyle-Width="15px"--%>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="A_T_ORG_TYPE" HeaderText="Organization Type" HeaderStyle-HorizontalAlign="Center">
                                                    <%--   HeaderStyle-Width="200px"--%>
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="A_T_SPC_PERSON" HeaderText="Person" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="A_T_TDS_RECEIVABLE" HeaderText="TDS Receivable" HeaderStyle-HorizontalAlign="Center">
                                                    <ItemStyle HorizontalAlign="Center" />
                                                </asp:BoundField>
                                            </Columns>
                                            <EmptyDataTemplate>
                                                NO RECORD FOUND
                                            </EmptyDataTemplate>
                                        </asp:GridView>
                                    </div>
                                </div>
                                <div id="inner-Bank" style="display: none; padding: 8px 10px; margin-top: -5px; height: auto">
                                    <ol id="toc_bank">
                                        <li><a href="#" id="bank_Payable" onclick="cm_showBankTab('bank-Payable'); 
                                     document.getElementById('hdn_ActiveBankTab').value='bank-Payable'; 
                                    return false;"><span>Payable Details</span></a></li>
                                        <li><a href="#" id="bank_Receivable" onclick="cm_showBankTab('bank-Receivable');
                                    document.getElementById('hdn_ActiveBankTab').value='bank-Receivable';
                                     return false;"><span>Receivable Details</span></a> </li>
                                    </ol>
                                    <div id="bank-Payable" style="display: none; padding: 8px 10px; border-radius: 10px;
                                        height: auto;">
                                        <div style="display: flex; flex-direction: row; gap: 20px; margin-bottom: 15px;">
                                            <div id="firstSection" style="width: 370px; float: left;">
                                                <div id="div_organization" style="display: flex">
                                                    <div id="tag_label_Clientname1">
                                                        Payable Org Name
                                                    </div>
                                                    <div style="">
                                                        <asp:TextBox ID="txtOrgainzationName" TabIndex="132" CssClass="txtbox_none" ClientIDMode="Static"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div id="divBankName" style="display: flex; margin-top: 7px">
                                                    <div id="tag_label_Clientname1">
                                                        Bank Name
                                                    </div>
                                                    <div>
                                                        <asp:DropDownList ID="ddlbankName" Style="margin-left: 2px" TabIndex="133" Height="20px"
                                                            CssClass="listtxt-s_inner" runat="server">
                                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                            <asp:ListItem Text="Allahbad Bank" Value="Allahbad Bank"></asp:ListItem>
                                                            <asp:ListItem Text="Axis Bank" Value="Axis Bank"></asp:ListItem>
                                                            <asp:ListItem Text="Bank of India" Value="Bank of India"></asp:ListItem>
                                                            <asp:ListItem Text="canara Bank" Value="canara Bank"></asp:ListItem>
                                                            <asp:ListItem Text="CSB Bank" Value="CSB Bank"></asp:ListItem>
                                                            <asp:ListItem Text="HDFC Bank" Value="HDFC Bank"></asp:ListItem>
                                                            <asp:ListItem Text="ICICI Bank" Value="ICICI Bank"></asp:ListItem>
                                                            <asp:ListItem Text="IOB Bank" Value="IOB Bank"></asp:ListItem>
                                                            <asp:ListItem Text="Induslnd Bank" Value="Induslnd Bank"></asp:ListItem>
                                                            <asp:ListItem Text="Indian Bank" Value="Indian bank"></asp:ListItem>
                                                            <asp:ListItem Text="IDBI Bank" Value="IDBI Bank"></asp:ListItem>
                                                            <asp:ListItem Text="Union Bank of India" Value="Union Bank of India"></asp:ListItem>
                                                            <asp:ListItem Text="UCO Bank" Value="UCO Bank"> </asp:ListItem>
                                                            <asp:ListItem Text="Syndcate Bank" Value="Syndcate Bank"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px;">
                                                    <div id="tag_label_Clientname1">
                                                        Branch
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="txtBranch" ClientIDMode="Static" TabIndex="134" CssClass="txtbox_none"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px;">
                                                    <div id="tag_label_Clientname1">
                                                        A/C No
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="txtAcNo" ClientIDMode="Static" TabIndex="135" CssClass="txtbox_none"
                                                            onkeypress="return blockNonNumbers(this,event,false,false);" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px">
                                                    <div id="tag_label_Clientname1">
                                                        IFSC Code
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="txtIFSC_code" TabIndex="136" CssClass="txtbox_none" ClientIDMode="Static"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="Second">
                                                <div style="display: flex;">
                                                    <div id="tag_label_Clientname1" style="margin-left: 21px;">
                                                        Address1
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="txtAddess1" Style="margin-left: -21px;" TabIndex="137" CssClass="txtbox_none"
                                                            ClientIDMode="Static" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px">
                                                    <div id="tag_label_Clientname1" style="margin-left: 20px;">
                                                        Address2</div>
                                                    <div>
                                                        <asp:TextBox ID="txtAdddress2" Style="margin-left: -21px" TabIndex="138" CssClass="txtbox_none"
                                                            ClientIDMode="Static" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px">
                                                    <div id="tag_label_Clientname1" style="margin-left: 20px;">
                                                        District
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="t_district" Style="margin-left: -21px" ClientIDMode="Static" TabIndex="139"
                                                            CssClass="txtbox_none" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px">
                                                    <div id="tag_label_Clientname1" style="margin-left: 20px;">
                                                        State
                                                    </div>
                                                    <asp:DropDownList ID="ddl_state" Style="margin-left: -20px;" TabIndex="140" runat="server"
                                                        CssClass="listtxt_transac_mode_new" Width="225px" DataSourceID="XmlDataSource1"
                                                        DataTextField="text" DataValueField="value">
                                                    </asp:DropDownList>
                                                    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/eRoyalMasters/CHA_State_Name_Code.xml"
                                                        XPath="ListItems/ListItem"></asp:XmlDataSource>
                                                </div>
                                                <div style="display: flex; margin-top: 7px;">
                                                    <div id="tag_label_Clientname1" style="margin-left: 20px;">
                                                        Pincode
                                                    </div>
                                                    <asp:TextBox ID="txt_Pincode" TabIndex="141" runat="server" Style="margin-left: -20px;"
                                                        CssClass="txtbox_none"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="margin-bottom: 14px; margin-left: 247px;">
                                            <div id="newbu">
                                                <asp:Button ID="btn_newPayable" runat="server" CssClass="new" OnClick="btn_newPayable_Click"
                                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                                    TabIndex="142" />
                                            </div>
                                            <div id="editbu">
                                                <asp:Button ID="btnSavePayableDetail" runat="server" CssClass="save" OnClick="btnSavePayableDetail_Click"
                                                    OnClientClick="return validateBankPayableDetail();" TabIndex="143" />
                                            </div>
                                            <div id="editbu">
                                                <asp:Button ID="btnPayableUpdate" runat="server" CssClass="updates" OnClick="btnPayableUpdate_Click"
                                                    OnClientClick="return validateBankPayableDetail();" TabIndex="144" />
                                            </div>
                                            <div id="editbu">
                                                <asp:Button ID="btn_PayableDelete" runat="server" TabIndex="145" OnClientClick="jConfirm('Delete this Entry?', 'Payable Details', function(r) {
                                                             var i = r + 'ok';
                                                             if(i == 'trueok')
                                                             {
                                                                 document.getElementById('btnPayable').click();
                                                               
                                                             }
                                                             else {
                                                             }
                                                       
                                                   });return false;" CssClass="dlete" />
                                                <asp:Button ID="btnPayable" runat="server" TabIndex="145" OnClick="btn_PayableDelete_Click"
                                                    CssClass="dlete" Style="display: none;" />
                                            </div>
                                            <div id="editbu">
                                                <input type="submit" value="" causesvalidation="false" class="scancel" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                                            </div>
                                        </div>
                                        <div style="margin-left: -7px">
                                            <asp:GridView ID="grd_PayableDetails" runat="server" DataKeyNames="ACC_IECNO,ACC_BRSLNO,PAYABLE_ID"
                                                EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                                                CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True" PageSize="5" AllowPaging="True"
                                                OnRowDataBound="grd_PayableDetails_RowDataBound" OnSelectedIndexChanged="grd_PayableDetails_SelectedIndexChanged"
                                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                                CellPadding="1" CellSpacing="1" OnRowCreated="grd_PayableDetails_RowCreated">
                                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                                    BorderWidth="1px" />
                                                <Columns>
                                                    <asp:BoundField DataField="ACC_ORG_NAME" HeaderText="Payable Org Name" HeaderStyle-Width="80px">
                                                        <ItemStyle Width="80px" CssClass="column_style_left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ACC_BANKNAME" HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Width="80px">
                                                        <ItemStyle Width="80px" CssClass="column_style_left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ACC_BRANCH" HeaderText="Branch" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Width="80px">
                                                        <ItemStyle Width="80px" CssClass="column_style_left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ACC_AC_NO" HeaderText="A/C No" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Width="100px">
                                                        <ItemStyle Width="100px" CssClass="column_style_left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ACC_IFSC_CODE" HeaderText="IFSC Code" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Width="50px">
                                                        <ItemStyle Width="50px" CssClass="column_style_left" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    NO RECORD FOUND
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                    <div id="bank-Receivable" style="display: none; padding: 8px 10px; border-radius: 10px;
                                        height: auto;">
                                        <div style="display: flex; flex-direction: row; gap: 20px; margin-bottom: 15px;">
                                            <div id="Recev_firstSection" style="width: 370px; float: left;">
                                                <div id="div_Recev_organization" style="display: flex">
                                                    <div id="tag_label_Clientname1">
                                                        Receivable Org Name
                                                    </div>
                                                    <div style="">
                                                        <asp:TextBox ID="txt_Rec_OrgainzationName" TabIndex="146" CssClass="txtbox_none"
                                                            ClientIDMode="Static" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div id="div_recev_BankName" style="display: flex; margin-top: 7px">
                                                    <div id="tag_label_Clientname1">
                                                        Bank Name
                                                    </div>
                                                    <div>
                                                        <asp:DropDownList ID="ddl_RecevbankName" Style="margin-left: 2px" TabIndex="147"
                                                            Height="20px" CssClass="listtxt-s_inner" runat="server">
                                                            <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                                            <asp:ListItem Text="Allahbad Bank" Value="Allahbad Bank"></asp:ListItem>
                                                            <asp:ListItem Text="Axis Bank" Value="Axis Bank"></asp:ListItem>
                                                            <asp:ListItem Text="Bank of India" Value="Bank of India"></asp:ListItem>
                                                            <asp:ListItem Text="canara Bank" Value="canara Bank"></asp:ListItem>
                                                            <asp:ListItem Text="CSB Bank" Value="CSB Bank"></asp:ListItem>
                                                            <asp:ListItem Text="HDFC Bank" Value="HDFC Bank"></asp:ListItem>
                                                            <asp:ListItem Text="ICICI Bank" Value="ICICI Bank"></asp:ListItem>
                                                            <asp:ListItem Text="IOB Bank" Value="IOB Bank"></asp:ListItem>
                                                            <asp:ListItem Text="Induslnd Bank" Value="Induslnd Bank"></asp:ListItem>
                                                            <asp:ListItem Text="Indian Bank" Value="Indian bank"></asp:ListItem>
                                                            <asp:ListItem Text="IDBI Bank" Value="IDBI Bank"></asp:ListItem>
                                                            <asp:ListItem Text="Union Bank of India" Value="Union Bank of India"></asp:ListItem>
                                                            <asp:ListItem Text="UCO Bank" Value="UCO Bank"> </asp:ListItem>
                                                            <asp:ListItem Text="Syndcate Bank" Value="Syndcate Bank"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px;">
                                                    <div id="tag_label_Clientname1">
                                                        Branch
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="txt_Recev_Branch" ClientIDMode="Static" TabIndex="148" CssClass="txtbox_none"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px;">
                                                    <div id="tag_label_Clientname1">
                                                        A/C No
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="txt_RecevAcNo" ClientIDMode="Static" TabIndex="149" CssClass="txtbox_none"
                                                            onkeypress="return blockNonNumbers(this,event,false,false);" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px">
                                                    <div id="tag_label_Clientname1">
                                                        IFSC Code
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="txt_RecevIFSC_code" TabIndex="150" CssClass="txtbox_none" ClientIDMode="Static"
                                                            runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div id="Recev_Second">
                                                <div style="display: flex;">
                                                    <div id="tag_label_Clientname1" style="margin-left: 21px;">
                                                        Address1
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="txt_RecevAddess1" Style="margin-left: -21px;" TabIndex="151" CssClass="txtbox_none"
                                                            ClientIDMode="Static" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px">
                                                    <div id="tag_label_Clientname1" style="margin-left: 20px;">
                                                        Address2</div>
                                                    <div>
                                                        <asp:TextBox ID="txt_RecevAdddress2" Style="margin-left: -21px" TabIndex="152" CssClass="txtbox_none"
                                                            ClientIDMode="Static" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px">
                                                    <div id="tag_label_Clientname1" style="margin-left: 20px;">
                                                        District
                                                    </div>
                                                    <div>
                                                        <asp:TextBox ID="t_Recevdistrict" Style="margin-left: -21px" ClientIDMode="Static"
                                                            TabIndex="153" CssClass="txtbox_none" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div style="display: flex; margin-top: 7px">
                                                    <div id="tag_label_Clientname1" style="margin-left: 20px;">
                                                        State
                                                    </div>
                                                    <asp:DropDownList ID="ddl_Recev_state" Style="margin-left: -20px;" TabIndex="154"
                                                        runat="server" CssClass="listtxt_transac_mode_new" Width="225px" DataSourceID="XmlDataSource1"
                                                        DataTextField="text" DataValueField="value">
                                                    </asp:DropDownList>
                                                    <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/eRoyalMasters/CHA_State_Name_Code.xml"
                                                        XPath="ListItems/ListItem"></asp:XmlDataSource>
                                                </div>
                                                <div style="display: flex; margin-top: 7px;">
                                                    <div id="tag_label_Clientname1" style="margin-left: 20px;">
                                                        Pincode
                                                    </div>
                                                    <asp:TextBox ID="txt_Recev_Pincode" TabIndex="155" runat="server" Style="margin-left: -20px;"
                                                        CssClass="txtbox_none"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div style="margin-bottom: 14px; margin-left: 247px;">
                                            <div id="newbu">
                                                <asp:Button ID="btn_newReceivable" runat="server" CssClass="new" OnClick="btn_newReceivable_Click"
                                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                                    TabIndex="156" />
                                            </div>
                                            <div id="editbu">
                                                <asp:Button ID="btnSaveReceivable" runat="server" CssClass="save" OnClick="btnSaveReceivable_Click"
                                                    OnClientClick="return BankReceivable_Validation();" TabIndex="157" />
                                            </div>
                                            <div id="editbu">
                                                <asp:Button ID="btnReceivableUpdate" runat="server" CssClass="updates" OnClick="btnReceivableUpdate_Click"
                                                    OnClientClick="return BankReceivable_Validation();" TabIndex="158" />
                                            </div>
                                            <div id="editbu">
                                                <asp:Button ID="btn_ReceivableDelete" runat="server" TabIndex="159" OnClientClick="jConfirm('Delete this Entry?', 'Receivable Details', function(r) {
                                                             var i = r + 'ok';
                                                             if(i == 'trueok')
                                                             {
                                                                 document.getElementById('btnReceivable').click();
                                                               
                                                             }
                                                             else {
                                                             }
                                                       
                                                   });return false;" CssClass="dlete" />
                                                <asp:Button ID="btnReceivable" runat="server" TabIndex="159" OnClick="btn_ReceivableDelete_Click"
                                                    CssClass="dlete" Style="display: none;" />
                                            </div>
                                            <div id="editbu">
                                                <input type="submit" value="" causesvalidation="false" class="scancel" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                                            </div>
                                        </div>
                                        <div style="margin-left: -7px">
                                            <asp:GridView ID="grd_ReceivableDetails" runat="server" DataKeyNames="RECEIVABLEID,ACC_REC_IECNO,ACC_REC_BRSLNO"
                                                EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                                                CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True" PageSize="5" AllowPaging="True"
                                                OnRowDataBound="grd_ReceivableDetails_RowDataBound" OnSelectedIndexChanged="grd_ReceivableDetails_SelectedIndexChanged"
                                                OnPageIndexChanging="grd_ReceivableDetails_PageIndexChanging" AllowSorting="True"
                                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                                OnRowCreated="grd_ReceivableDetails_RowCreated">
                                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                                    BorderWidth="1px" />
                                                <Columns>
                                                    <asp:BoundField DataField="ACC_REC_ORG_NAME" HeaderText="Receivable Org Name" HeaderStyle-Width="80px">
                                                        <ItemStyle Width="80px" CssClass="column_style_left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ACC_REC_BANKNAME" HeaderText="Bank Name" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Width="80px">
                                                        <ItemStyle Width="80px" CssClass="column_style_left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ACC_REC_BRANCH" HeaderText="Branch" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Width="80px">
                                                        <ItemStyle Width="80px" CssClass="column_style_left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ACC_REC_AC_NO" HeaderText="A/C No" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Width="100px">
                                                        <ItemStyle Width="100px" CssClass="column_style_left" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ACC_REC_IFSC_CODE" HeaderText="IFSC Code" HeaderStyle-HorizontalAlign="Center"
                                                        HeaderStyle-Width="50px">
                                                        <ItemStyle Width="50px" CssClass="column_style_left" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    NO RECORD FOUND
                                                </EmptyDataTemplate>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <%-- /page-3 --%>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_ClientMaster" style="margin-left: auto; margin-top: -31px;">
                    <div id="innerbox_ClientMaster_bot_inn" style="width: 900px; margin-top: 21px;">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                TabIndex="55" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate_Client();"
                                TabIndex="56" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate_Client();" TabIndex="57" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="52" OnClientClick="confirmDelete()"
                                CssClass="dlete" />
                            <asp:Button ID="btn" runat="server" TabIndex="58" OnClick="btnDelete_Click" Text="TestDelete"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="" causesvalidation="false" class="scancel" onclick="win_hide();parent.adcodewindow.hide();retfurn
            false;" />
                            <asp:HiddenField ID="hdn_id" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="hdn_checkVal" runat="server" />
                            <asp:HiddenField ID="hdn_StateName_chk" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hdn_StateName" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hdn_Commercial_StateName" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hdn_Commercial_StateName_chk" runat="server" ClientIDMode="Static" />
                            <asp:HiddenField ID="hdn_ddlCommercial_Tax_yn" runat="server" />
                            <asp:HiddenField ID="hdn_ClientName" runat="server" />
                            <asp:HiddenField ID="hdn_IEC_NO" runat="server" />
                            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                            <asp:HiddenField ID="hdn_brslno" runat="server" />
                            <asp:HiddenField ID="hdn_updatedId" runat="server" />
                            <asp:HiddenField ID="Hdn_StandardType" runat="server" />
                            <asp:HiddenField ID="hdn_PayableId" runat="server" />
                            <asp:HiddenField ID="hdn_ReceivableId" runat="server" />
                            <asp:HiddenField ID="hdn_ActiveMainTab" runat="server" ClientIDMode="Static" Value="page-1" />
                            <asp:HiddenField ID="hdn_ActiveInnerTab" runat="server" ClientIDMode="Static" Value="inner-General" />
                            <asp:HiddenField ID="hdn_ActiveBankTab" runat="server" ClientIDMode="Static" Value="bank-Payable" />
                            <asp:HiddenField ID="hdn_ActiveDeepTab" runat="server" ClientIDMode="Static" Value="deep-Customer" />
                            <asp:HiddenField ID="hdnAC_Code" runat="server" />
                            <asp:HiddenField ID="HdnAV_Code" runat="server" />
                        </div>
                        <asp:TextBox ID="txtStateCode" runat="server" BorderColor="White" ForeColor="White"
                            CssClass="txtbox_none_mid_size" Width="1px"></asp:TextBox>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        //activatables('page', ['page-1', 'page-2']);

        activatables('page', ['page-1', 'page-2', 'page-3']);
    </script>
    <script src="../js/Export_Jscript/Export_ETP.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
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


        $(function () {

            $("#txtDistrict").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/District_Names_StateName_Wise_List",
                        data: "{ 'mail': '" + request.term + "','StateName': '" + document.getElementById("ddlStateName").options[document.getElementById("ddlStateName").selectedIndex].text + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                jQuery('#txtDistrict').validationEngine('showPrompt', 'Incorrect District Name', 'error', 'topRight', true);
                            }
                            else {
                                var value = data.d;
                                if (value.indexOf("-") != -1) {
                                    var arr = value.split('-');
                                    alert(value);
                                    jQuery('#txtDistrict').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                }
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });

        function KeepSessionAlive(val) {
            $.post("../KeepSessionAlive.aspx?ses_id=" + val + "", null, function () {

            });
        }

        function CallServerside_IECNO(src, dest) {
            var ctrl = document.getElementById(src);
            PageMethods.Get_IECNO_Details(ctrl.value, CallSuccess_IECNO, CallFailed, dest);
        }

        function CallSuccess_IECNO(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data.indexOf("~~") != -1) {

                var s = data.split('~~');
                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];

                if (before == '1') {

                    var ddlType = document.getElementById("ddlType");
                    addOption(document.getElementById("ddlType"), after2, after2);
                    var txtName = $('#txtName');
                    txtName.attr('disabled', true);
                    jAlert('IE Code is already exists!', 'GENERAL', function (r) { document.getElementById("txtBranchNO").focus(); });

                    document.getElementById("txtName").value = after1;


                }
                if (before == '2') {

                    document.getElementById("txtName").value = '';
                    var txtName1 = $('#txtName');
                    txtName1.attr('disabled', false);
                }
            }
            else {

                document.getElementById("txtName").value = "";
                document.getElementById("type").value = "";
            }
            document.getElementById("txtBranchNO").focus();
        }
        function CallServerside_ClientName(src, dest) {
            var ctrl = document.getElementById(src);
            // call server side method
            PageMethods.Get_ClientName_Details(ctrl.value, CallSuccess_ClientName, CallFailed, dest);
        }
        function CallSuccess_ClientName(res, destCtrl) {

            var dest = document.getElementById(destCtrl);
            //dest.value = res;
            var data = res;
            if (data.indexOf("~~") != -1) {

                var s = data.split('~~');
                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];

                if (before == '1') {
                    document.getElementById("ddlType").value = after2;

                    var ddlType = document.getElementById("ddlType");
                    addOption(document.getElementById("ddlType"), after2, after2);

                    var txtName = $('#txtName');


                    jAlert('Party Already Exists!', 'GENERAL', function (r) { document.getElementById("txtName").focus(); });

                    // document.getElementById("txtName").value = after1;


                }
                if (before == '2') {
                    document.getElementById("txtName").value = '';


                    document.getElementById("txtName").focus();
                }
            }
            else {

                document.getElementById("txtName").value = "";
                document.getElementById("type").value = "";

            }

            document.getElementById("txtName").focus();

        }
        function CallServerside_Branch(src, dest) {
            var ctrl = document.getElementById(src);
            var ctrl1 = document.getElementById('txtIECNO');
            var ctrl2 = document.getElementById('txtName');

            // call server side method

            PageMethods.Get_Branch_Details(ctrl1.value, ctrl2.value, ctrl.value, CallSuccess_Branch, CallFailed, dest);

        }
        function CallSuccess_Branch(res, destCtrl) {

            var dest = document.getElementById(destCtrl);

            var data = res;
            if (data.indexOf("~~") != -1) {


                var s = data.split('~~');

                var before = s[0];
                var after1 = s[1];
                if (after1 == 'UPDATE') {

                    document.getElementById("txtBranchNO").focus();
                }
                if (before == '1') {

                    jAlert('Branch Already Exists!', 'GENERAL', function (r) { document.getElementById("txtBranchNO").focus(); });

                }
                else {
                    document.getElementById("txtName").focus();

                }
            }
        }
        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }

        function addOption(selectbox, text, value) {

            selectbox.options.length = 0;
            var optn = document.createElement("OPTION");
            if (text == 'OTHERS' && value == 'OTHERS') {

                optn.text = text;
                optn.value = value;
                selectbox.options.add(optn);
                selectbox.options.add(new Option("GOVERNMENT", "GOVERNMENT"));

            }
            else if (text == 'GOVERNMENT' && value == 'GOVERNMENT') {

                optn.text = text;
                optn.value = value;
                selectbox.options.add(optn);
                selectbox.options.add(new Option("OTHERS", "OTHERS"));

            }
        }

    </script>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            $('#txtStateName').focus(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtStateName').change(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtStateName').keyup(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtStateName').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });

        function Item_desc(val) {

            var data = val;

            if (data == '') {
                $('#txtStateName').val('');
            }
            if (data.indexOf("-") != -1) {

                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtStateName').val(before);
                $('#hdn_Txt_Statecode').val(after);
            }
            else {

            }
        }
    </script>--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtDistrict').focus(function () {

                var data = $(this).val();
                Item_District(data);

            });
            $('#txtDistrict').change(function () {

                var data = $(this).val();
                Item_District(data);

            });
            $('#txtDistrict').keyup(function () {

                var data = $(this).val();
                Item_District(data);

            });
            $('#txtDistrict').keydown(function () {

                var data = $(this).val();
                Item_District(data);

            });
        });

        function Item_District(val) {

            var data = val;

            if (data == '') {
                $('#txtDistrict').val('');
            }
            if (data.indexOf("-") != -1) {

                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtDistrict').val(after);
                //$('#hdn_Txt_District').val(after);
            }
            else {

            }
        }
    </script>
    <%--<script type="text/javascript">
        $(document).ready(function () {

            if ($("#ddlCommercial_Tax_yn option:selected").text() == 'Y') {

                $("#txtCommercial_StateName").removeAttr("disabled");
                $("#txtCommercial_StateCode").removeAttr("disabled");
                $("#txtCommercial_Taxtype").removeAttr("disabled");
                $("#txtCommercial_RegistrationNo").removeAttr("disabled");

                document.getElementById('ST_Code').style.visibility = 'visible';
            }

            if ($("#ddlCommercial_Tax_yn option:selected").text() == 'N') {

                $("#txtCommercial_StateName").val('');
                $("#txtCommercial_StateCode").val('');
                $("#txtCommercial_Taxtype").val('');
                $("#txtCommercial_RegistrationNo").val('');

                $("#txtCommercial_StateName").attr("disabled", "disabled");
                $("#txtCommercial_StateCode").attr("disabled", "disabled");
                $("#txtCommercial_Taxtype").attr("disabled", "disabled");
                $("#txtCommercial_RegistrationNo").attr("disabled", "disabled");

                document.getElementById('ST_Code').style.visibility = 'hidden';

            }

            $('#ddlCommercial_Tax_yn').change(function () {

                if ($("#ddlCommercial_Tax_yn option:selected").text() == 'Y') {

                    $("#txtCommercial_StateName").removeAttr("disabled");
                    $("#txtCommercial_StateCode").removeAttr("disabled");
                    $("#txtCommercial_Taxtype").removeAttr("disabled");
                    $("#txtCommercial_RegistrationNo").removeAttr("disabled");

                    document.getElementById('ST_Code').style.visibility = 'visible';
                }
                else {

                    $("#txtCommercial_StateName").val('');
                    $("#txtCommercial_StateCode").val('');
                    $("#txtCommercial_Taxtype").val('');
                    $("#txtCommercial_RegistrationNo").val('');

                    $("#txtCommercial_StateName").attr("disabled", "disabled");
                    $("#txtCommercial_StateCode").attr("disabled", "disabled");
                    $("#txtCommercial_Taxtype").attr("disabled", "disabled");
                    $("#txtCommercial_RegistrationNo").attr("disabled", "disabled");

                    document.getElementById('ST_Code').style.visibility = 'hidden';
                }

            });
        });
    </script>--%>
    <%--<script type="text/javascript">
        $(function () {

            $('#txtCommercial_StateName').bind('focus keyup keypress change keydown', function () {

                var data = $(this).val();
                commercial_state(data);

            });
        });

        function commercial_state(val) {

            var data = val;
            if (data == '') {
                $('#txtCommercial_StateCode').val('');
            }
            //$('#hdn_Autosearch').val(data);


            if (data.indexOf("-") != -1) {

                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtCommercial_StateCode').val(after);
                $('#txtCommercial_StateName').val(before);

            }
            else {

            }
        }
    </script>--%>
    <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/ClientMastertab.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/eRoyalmaster_Jscript/Client_Master.js"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/product_JScript.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Iec_Track() {
            var C = document.getElementById("txtIECNO").value;
            var NN = document.getElementById("txtName").value;
            var N = NN.substring(0, 3);
            Iec_Status(C, N);
        }

    </script>
    <script type="text/javascript">
        function RefreshParent() {
            window.parent.location.reload();
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $('#txtWarehouseCode').focus(function () {

                var data = $(this).val();
                WH_Code(data);

            });
            $('#txtWarehouseCode').change(function () {

                var data = $(this).val();
                WH_Code(data);

            });
            $('#txtWarehouseCode').keyup(function () {

                var data = $(this).val();
                WH_Code(data);

            });
            $('#txtWarehouseCode').keydown(function () {

                var data = $(this).val();
                WH_Code(data);

            });

        });

        function WH_Code(val) {

            var data = val;
            if (data == '') {
                $('#txtWarehouseCode').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');
                var before = s[0];
                var after = s[1];
                $('#txtWarehouseCode').val(before);
            }
            else {

            }
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtEndUse').focus(function () {

                var data_1 = $(this).val();
                Item_desc_1(data_1);

            });
            $('#txtEndUse').change(function () {

                var data_1 = $(this).val();
                Item_desc_1(data_1);

            });
            $('#txtEndUse').keyup(function () {

                var data_1 = $(this).val();
                Item_desc_1(data_1);

            });
            $('#txtEndUse').keydown(function () {

                var data_1 = $(this).val();
                Item_desc_1(data_1);

            });
        });

        function Item_desc_1(val) {

            var data_1 = val;

            if (data_1 == '') {
                $('#txtEndUse').val('');
            }
            if (data_1.indexOf("-") != -1) {

                var s = data_1.split('-');

                var before_1 = s[0];
                var after_1 = s[1];

                $('#txtEndUse').val(before_1);
                $('#hdn_txtEndUse').val(after_1);

            }
            else {

            }
        }

        function validate_AccInfo() {
            /* Add your validation logic here */
            return true;
        }     

    </script>
    <script type="text/javascript">


        function cm_showBankTab(tabId) {
            var bankPanels = ['bank-Payable', 'bank-Receivable'];
            for (var i = 0; i < bankPanels.length; i++) {
                var el = document.getElementById(bankPanels[i]);
                if (el) {
                    el.classList.remove('active-bank');
                    el.style.display = 'none';
                }
            }
            var active = document.getElementById(tabId);
            if (active) {
                active.style.display = 'flex';
                active.classList.add('active-bank');
            }

            var bankLinks = document.querySelectorAll('#toc_bank li a');
            for (var j = 0; j < bankLinks.length; j++) {
                bankLinks[j].className = bankLinks[j].className.replace(/\s*\bactive\b/g, '').trim();
            }
            var linkId = tabId.replace(/-/, '_');
            var link = document.getElementById(linkId);
            if (link) link.className = (link.className + ' active').trim();
        }


        window.addEventListener('load', function () {
            var savedMain = document.getElementById('hdn_ActiveMainTab').value || 'page-1';
            var savedInner = document.getElementById('hdn_ActiveInnerTab').value || 'inner-General';
            var savedBank = document.getElementById('hdn_ActiveBankTab').value || 'bank-Payable';
            var savedDeep = document.getElementById('hdn_ActiveDeepTab').value || 'deep-Customer';

            var allPages = ['page-1', 'page-2', 'page-3'];
            for (var i = 0; i < allPages.length; i++) {
                var p = document.getElementById(allPages[i]);
                if (p) p.style.display = 'none';
            }

            // Show saved main tab
            var activePage = document.getElementById(savedMain);
            if (activePage) activePage.style.display = 'block';

            // Highlight correct main tab link
            var mainLinks = document.querySelectorAll('#toc li a');
            for (var i = 0; i < mainLinks.length; i++) {
                mainLinks[i].classList.remove('active');
            }
            // Map page id to link id
            var mainLinkMap = { 'page-1': 'IGM', 'page-2': 'CONTAINER', 'page-3': 'ACCINFO' };
            var activeMainLink = document.getElementById(mainLinkMap[savedMain]);
            if (activeMainLink) activeMainLink.classList.add('active');

            // &#9472;&#9472; 2. Restore INNER tab (General / TDS / Bank) &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;
            var innerPanels = ['inner-General', 'inner-TDS', 'inner-Bank'];
            for (var i = 0; i < innerPanels.length; i++) {
                var ip = document.getElementById(innerPanels[i]);
                if (ip) ip.style.display = 'none';
            }
            var activeInner = document.getElementById(savedInner);
            if (activeInner) activeInner.style.display = 'block';

            // Highlight inner tab link
            var innerLinks = document.querySelectorAll('#toc_inner li a');
            for (var i = 0; i < innerLinks.length; i++) {
                innerLinks[i].classList.remove('active');
            }
            var innerLinkMap = {
                'inner-General': 'inner_General',
                'inner-TDS': 'inner_TDS',
                'inner-Bank': 'inner_Bank'
            };
            var activeInnerLink = document.getElementById(innerLinkMap[savedInner]);
            if (activeInnerLink) activeInnerLink.classList.add('active');

            // &#9472;&#9472; 3. Restore BANK tab (Payable / Receivable) &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;
            var bankPanels = ['bank-Payable', 'bank-Receivable'];
            for (var i = 0; i < bankPanels.length; i++) {
                var bp = document.getElementById(bankPanels[i]);
                if (bp) {
                    bp.classList.remove('active-bank');
                    bp.style.setProperty('display', 'none', 'important');
                }
            }
            var activeBank = document.getElementById(savedBank);
            if (activeBank) {
                activeBank.style.removeProperty('display');
                activeBank.style.display = "flex";
                activeBank.classList.add('active-bank');
            }

            // Highlight bank tab link
            var bankLinks = document.querySelectorAll('#toc_bank li a');
            for (var i = 0; i < bankLinks.length; i++) {
                bankLinks[i].classList.remove('active');
            }
            var bankLinkMap = {
                'bank-Payable': 'bank_Payable',
                'bank-Receivable': 'bank_Receivable'
            };
            var activeBankLink = document.getElementById(bankLinkMap[savedBank]);
            if (activeBankLink) activeBankLink.classList.add('active');

            // &#9472;&#9472; 4.Restore DEEP tab (Customer / Vendor) &#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;&#9472;
            var deepPanels = ['deep-Customer', 'deep-Vendor'];
            for (var i = 0; i < deepPanels.length; i++) {
                var dp = document.getElementById(deepPanels[i]);
                if (dp) dp.style.display = 'none';
            }
            var activeDeep = document.getElementById(savedDeep);
            if (activeDeep) activeDeep.style.display = 'block';

            var deepLinks = document.querySelectorAll('#toc_deep li a');
            for (var i = 0; i < deepLinks.length; i++) {
                deepLinks[i].classList.remove('active');
            }
            var deepLinkMap = {
                'deep-Customer': 'deep_Customer',
                'deep-Vendor': 'deep_Vendor'
            };
            var activeDeepLink = document.getElementById(deepLinkMap[savedDeep]);
            if (activeDeepLink) activeDeepLink.classList.add('active');
        });


        // Add this AFTER your window.addEventListener('load',...) block
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                // Re-run bank tab restoration after every postback
                var savedBank = document.getElementById('hdn_ActiveBankTab').value || 'bank-Payable';

                // Force hide ALL bank panels first
                var bankPanels = ['bank-Payable', 'bank-Receivable'];
                for (var i = 0; i < bankPanels.length; i++) {
                    var bp = document.getElementById(bankPanels[i]);
                    if (bp) {
                        bp.classList.remove('active-bank');
                        bp.style.setProperty('display', 'none', 'important');
                    }
                }

                // Show only the active one
                var activeBank = document.getElementById(savedBank);
                if (activeBank) {
                    activeBank.style.removeProperty('display');
                    activeBank.style.display = 'flex';
                    activeBank.classList.add('active-bank');
                }

                // Restore bank tab link highlight
                var bankLinks = document.querySelectorAll('#toc_bank li a');
                for (var i = 0; i < bankLinks.length; i++) {
                    bankLinks[i].classList.remove('active');
                }
                var bankLinkMap = {
                    'bank-Payable': 'bank_Payable',
                    'bank-Receivable': 'bank_Receivable'
                };
                var activeBankLink = document.getElementById(bankLinkMap[savedBank]);
                if (activeBankLink) activeBankLink.classList.add('active');
            }
        }

        function confirmDelete() {
            event.preventDefault();
            event.stopPropagation();
            jConfirm('Delete this Entry?', 'CLIENT MASTER', function (r) {
                if (r === true) {
                    var hiddenBtn = document.getElementById('<%= btn.ClientID %>');
                    if (hiddenBtn) {
                        __doPostBack('<%= btn.UniqueID %>', '');
                    }
                }
            });
            return false;
        }


        function ChangeStateCode() {
            var ddl = document.getElementById('<%= ddlCommercial_StateName.ClientID %>');
            var stateCode = ddl.options[ddl.selectedIndex].value;
            document.getElementById('<%= txtCommercial_StateCode.ClientID %>').value = stateCode;

        }

        function Check_DuplicateOnBranchLeave() {
            var iecNo = document.getElementById('<%= txtIECNO.ClientID %>').value.trim();
            var clientName = document.getElementById('<%= txtName.ClientID %>').value.trim();
            var brSlno = document.getElementById('<%= txtBranchNO.ClientID %>').value.trim();
            var impExpId = document.getElementById('<%= hdn_updatedId.ClientID %>').value || "0";
            var saveBtn = document.getElementById('<%= btnSave.ClientID %>');
            var updateBtn = document.getElementById('<%= btnUpdate.ClientID %>');

            var standardType = '';
            var rbl = document.getElementById('<%= RadioButtonList_TYPE.ClientID %>');
            if (rbl) {
                var radios = rbl.getElementsByTagName('input');
                for (var i = 0; i < radios.length; i++) {
                    if (radios[i].checked) {
                        standardType = radios[i].value;
                        break;
                    }
                }
            }

            /*
            if (saveBtn && saveBtn.style.display !== "none" && !saveBtn.disabled) {
            flag = "Save";
            }
            else if (updateBtn && updateBtn.style.display !== "none" && !updateBtn.disabled) {
            flag = "Update";
            }
            */

            if (!iecNo || !clientName || !brSlno) {
                return;
            }

            $.ajax({
                type: "POST",
                url: "Client_Master_New.aspx/Check_ClientName_IECNo_BrSlno",
                data: JSON.stringify({
                    IECNO: iecNo,
                    ClientName: clientName,
                    BrSlno: parseInt(brSlno),
                    IMP_EXP_ID: impExpId,

                    StandardType: standardType
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {

                    var result = response.d;

                    if (result.Status === 0) {
                        return;
                    }

                    switch (result.Status) {

                        case 1:
                            jAlert(result.Message, "CLIENT MASTER", function () {
                                //                                document.getElementById('<%= txtBranchNO.ClientID %>').value = "";
                                //                                document.getElementById('<%= txtBranchNO.ClientID %>').focus();
                            });
                            break;

                        case 2:
                            jAlert(result.Message, "CLIENT MASTER", function () {
                                document.getElementById('<%= txtIECNO.ClientID %>').value = "Test";
                                document.getElementById('<%= txtIECNO.ClientID %>').focus();
                            });
                            break;

                        case 3:
                            jAlert(result.Message, "CLIENT MASTER", function () {


                            });
                            break;

                        case 4:
                            jAlert(result.Message, "CLIENT MASTER", function () {
                                //                                document.getElementById('<%= txtBranchNO.ClientID %>').value = "";
                                //                                document.getElementById('<%= txtBranchNO.ClientID %>').focus();
                            });
                            break;

                        default:
                            jAlert("Validation error. Please try again.", "CLIENT MASTER");
                            break;
                    }
                },
                error: function (xhr, status, err) {
                    console.error("CheckDuplicate failed:", err);
                    jAlert("Server error during validation. Please try again.", "CLIENT MASTER");
                }
            });
        }

        window.onload = function () {
            var rbl = document.getElementById('<%= RadioButtonList_TYPE.ClientID %>');
            if (rbl) {
                var radios = rbl.getElementsByTagName('input');
                for (var i = 0; i < radios.length; i++) {
                    radios[i].onchange = function () {
                        if (!this.disabled) {
                            ClearClientMasterControl();
                        }
                    };
                }
            }
        };
        function ClearClientMasterControl() {
            // document.getElementById('<%=txtIECNO.ClientID %>').value = '';
            // document.getElementById('<%=txtName.ClientID %>').value = '';
            document.getElementById('<%=ddlType.ClientID %>').value = 'PRIVATE';
            document.getElementById('<%=txtBranchNO.ClientID %>').value = '';
            document.getElementById('<%=txtAdd1.ClientID %>').value = '';
            document.getElementById('<%=txtAdd2.ClientID %>').value = '';
            document.getElementById('<%=txtcity.ClientID %>').value = '';
            document.getElementById('<%=ddlStateName.ClientID %>').value = 0;
            document.getElementById('<%=txtDistrict.ClientID %>').value = '';
            document.getElementById('<%=txtPincode.ClientID %>').value = '';
            document.getElementById('<%=txtPAN_No.ClientID %>').value = '';
            document.getElementById('<%=txtContactPerson.ClientID %>').value = '';
            document.getElementById('<%=txtPhoneNO.ClientID %>').value = '';
            document.getElementById('<%=txtFax.ClientID %>').value = '';
            document.getElementById('<%=txtEmail.ClientID %>').value = '';
            document.getElementById('<%=txtRemarks.ClientID %>').value = '';
            document.getElementById('<%=txtBinNO.ClientID %>').value = '';
            document.getElementById('<%=txtWarehouseCode.ClientID %>').value = '';
            document.getElementById('<%=ddlGSTN_Type.ClientID %>').value = '';
            document.getElementById('<%=txtGSTN_ID.ClientID %>').value = '';
            document.getElementById('<%=ddlCommercial_StateName.ClientID %>').value = 0;
            document.getElementById('<%=ddl_EXP_GSTN_Type.ClientID %>').value = 0;
            document.getElementById('<%=txtCommercial_RegistrationNo.ClientID %>').value = '';
            document.getElementById('<%=txt_SEZ_IcegateID.ClientID %>').value = '';
            document.getElementById('<%=txt_SEZ_PANNo.ClientID %>').value = '';
            document.getElementById('<%=ddl_Payment_Method.ClientID %>').value = 'T';
            document.getElementById('<%=txt_SEZ_AP_ID.ClientID %>').value = '';
            document.getElementById('<%=txt_SEZ_AP_Name.ClientID %>').value = '';
            document.getElementById('<%=txtEndUse.ClientID %>').value = '';
            document.getElementById('<%=ddlNatureOfTrans.ClientID %>').value = 0;
            document.getElementById('<%=ddlNatureOfPayment.ClientID %>').value = 0;
            document.getElementById('<%=ddlValuationMethod.ClientID %>').value = 0;
            document.getElementById('<%=ddlType_Exp.ClientID %>').value = 'F';
            document.getElementById('<%=txtDrawback_AC_No.ClientID %>').value = '';
            document.getElementById('<%=Rdstr.ClientID %>').value = 'N';
            document.getElementById('<%=chk_DB001.ClientID %>').checked = false;
            document.getElementById('<%=chk_DB002.ClientID %>').checked = false;
            document.getElementById('<%=chk_DB003.ClientID %>').checked = false;
            document.getElementById('<%=txt_Marksnos.ClientID %>').value = '';
            document.getElementById('<%=txtInsuranceRate.ClientID %>').value = '';
            document.getElementById('<%=txt_TAN_Number.ClientID %>').value = '';
            document.getElementById('<%=txt_TDS_Code.ClientID %>').value = '';
            document.getElementById('<%=txt_TDS_Rate.ClientID %>').value = '';
            document.getElementById('<%=txt_TIN_No.ClientID %>').value = '';
            document.getElementById('<%=txtCommercial_StateCode.ClientID %>').value = '';

        }

        var branchGridScrollPos = 0;
        function saveBranchGridScroll() {
            var container = document.getElementById('branchGridScrollableDiv');
            if (container) {
                branchGridScrollPos = container.scrollTop;
            }
        }

        function restoreBranchGridScroll() {
            var container = document.getElementById('branchGridScrollableDiv');
            if (container) {
                container.scrollTop = branchGridScrollPos;
            }
        }

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(saveBranchGridScroll);
        prm.add_endRequest(restoreBranchGridScroll);

        function openAccountGL(primaryGroup) {
            var ClientName = document.getElementById('<%=txtName.ClientID %>').value;
          
            var width = 650;
            var height = 450;
       
            var left = window.screenX + (window.outerWidth - width) / 2;
            var top = window.screenY + (window.outerHeight - height) / 2;

            var url = '../Accounts_Master/Acc_Customer_Vendor_GL_creation.aspx?PrimaryGroup=' + encodeURIComponent(primaryGroup) +'&ClientName=' + encodeURIComponent(ClientName);
            window.open(url, 'Account GL', 'width='+width+
            ',height=' + height +
            ',left=' + left +
            ',top='+top+
            ',scrollbars=yes,resizable=yes,status=no,toolbar=no,menubar=no,location=no');
            return false;
        }
    </script>
</body>
</html>
