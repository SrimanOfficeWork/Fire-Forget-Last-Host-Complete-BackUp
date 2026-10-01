<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Client_Master_N.aspx.cs" Inherits="Client_Master_N" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
     
    <style type="text/css">
        fieldset
        {
            font-family: sans-serif;
            padding: 10px;
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>

            <div id="innerbox_MidMain_Transact_popup_new" style="height:30px;width:975px; margin-left:-2px;">
            <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                       Master
                    </div>
                    <%--<div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" CausesValidation="false" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>--%>
                    <div id="popupwindow_closebut_right_new">
                    <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" />
                            </div>
                </div>
            </div>

            <div id="innerbox_MidMain_Trans_IGM" style="width:975px; height:348px;">
                <ol id="toc">
                    <li style="height: 20px"><a href="#page-1" onclick="tab_page1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="IGM"><span>Client </span></a></li>
                  <li style="height: 20px"><a href="#page-2" onclick="tab_page2('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="CONTAINER" runat="server" visible="false"><span> Billing Party</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="innerbox_MidMain_popup_ClientMaster" style="height: 300px;width: 992px; margin-left:-15px;">
                        <div id="innerbox_MidMain_Mid_ClientMaster" style="height: 298px; width: 992px;">
                            <div id="innerbox_MidMain_Mid_ClientMaster_l" style="height: 298px;">
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        Select Type
                                    </div>
                                    <div id="txtcon-m_src">
                                        <asp:RadioButtonList ID="RadioButtonList_TYPE" runat="server" Font-Names="Arial"
                                            Font-Size="Small" AutoPostBack="true" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList_TYPE_SelectedIndexChanged">
                                            <asp:ListItem Text="Standard" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Non-Standard" Value="Non_STD"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        IEC No
                                    </div>
                                    <div id="txtcon-m_src" style="width: 110px">
                                        <asp:TextBox ID="txtIECNO" runat="server" MaxLength="10" CssClass="validate[required,minSize[10]] txtbox_none"
                                            TabIndex="1" Onkeypress="return numcharspl1(event)" AutoPostBack="true" OnTextChanged="txtIECNO_TextChanged"
                                            Width="100px" onpaste="return validatePaste(event);"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                    <asp:Button ID="btnAdcode" CssClass="autowidnewbut" Text="New Adcode" Visible="false"
                                        Style="width: 110px" runat="server" OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenAdCode(); return false" />
                                </div>
                                <%--<div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        Name
                                    </div>
                                    <div id="txtcon-m_src">
                                        <asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="validate[required] txtbox_none"
                                            ClientIDMode="Static" TabIndex="3" Onkeypress="return numcharspl1(event)" AutoPostBack="true"
                                            OnTextChanged="txtName_TextChanged" onpaste="return validatePaste(event);"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>--%>
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
                                        <asp:TextBox ID="txtStateName" runat="server" CssClass="txtbox_none_mid_size" TabIndex="8"
                                            ClientIDMode="Static" MaxLength="25" Onkeypress="return char(event)" onpaste="return validatePaste(event);"></asp:TextBox>
                                        <asp:HiddenField ID="hdn_Txt_Statecode" runat="server" />
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');opennew_District_Statecode('Client_State_District'); return false"
                                            class="magnfy"></a>
                                    </div>
                                </div>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        <%--City--%>
                                        PAN No
                                    </div>
                                    <div id="txtcon-m_src">
                                        <%-- <asp:TextBox ID="txtcity" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="7"
                                            onkeypress="return city1(event)"></asp:TextBox>--%>
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
                                        <asp:DropDownList ID="ddlGSTN_Type" runat="server" TabIndex="27" CssClass="listtxt-s_inner">
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
                                        <asp:DropDownList ID="ddl_EXP_GSTN_Type" runat="server" TabIndex="29" CssClass="listtxt-s_inner">
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
                                        <asp:TextBox ID="txt_SEZ_IcegateID" runat="server" MaxLength="32" onkeypress="return charnum2(event)"
                                            TabIndex="32" CssClass="txtbox_none" ClientIDMode="Static" onpaste="return validatePaste(event);"></asp:TextBox>
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
                                            runat="server" Height="20px" TabIndex="38" style ="width:220px;">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>S Sale</asp:ListItem>
                                            <asp:ListItem>F Free Of Cost</asp:ListItem>
                                            <asp:ListItem>C Consignment</asp:ListItem>
                                            <asp:ListItem>G Gift</asp:ListItem>
                                            <asp:ListItem>H Hire</asp:ListItem>
                                            <asp:ListItem>M Sample</asp:ListItem>
                                            <asp:ListItem>O Others</asp:ListItem>
                                            <asp:ListItem>P Replacement</asp:ListItem>
                                            <asp:ListItem>R Rent</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>
                            </div>
                            <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height: 298px">
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        <asp:Label ID="Label_branch" runat="server" Text="Select Branch"></asp:Label>
                                    </div>
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddlBranches" runat="server" AutoPostBack="True" CssClass="listtxt-s_inner"
                                            Width="60px" OnSelectedIndexChanged="ddlBranches_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>
                                <%--<div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        Type</div>
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddlType" runat="server" TabIndex="2" CssClass="listtxt-s_inner" />
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>--%>
                                <%--<div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        Branch No
                                    </div>
                                    <div id="txtcon-m_src">
                                        <asp:TextBox ID="txtBranchNO" runat="server" MaxLength="3" TabIndex="4" CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small"
                                            Onkeypress="return num1(event)" AutoPostBack="true" OnTextChanged="txtBranchNO_TextChanged"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>--%>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        Name
                                    </div>
                                    <div id="txtcon-m_src">
                                        <asp:TextBox ID="txtName" runat="server" MaxLength="50" CssClass="validate[required] txtbox_none"
                                            ClientIDMode="Static" TabIndex="3" Onkeypress="return numcharspl1(event)" AutoPostBack="true"
                                            OnTextChanged="txtName_TextChanged" onpaste="return validatePaste(event);"></asp:TextBox>
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
                                        <asp:TextBox ID="txtDistrict" runat="server" CssClass="txtbox_none_mid_size" TabIndex="8"
                                            MaxLength="25" Onkeypress="return char(event)" onpaste="return validatePaste(event);"></asp:TextBox>
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
                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="50" TabIndex="17" onkeypress="return char(event)"
                                            onpaste="return validatePaste(event);" CssClass="txtbox_none"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        State Name
                                    </div>
                                    <div id="txtcon-m_src">
                                        <asp:TextBox ID="txtCommercial_StateName" runat="server" MaxLength="40" onkeypress="return char(event)"
                                            onpaste="return validatePaste(event);" TabIndex="24" CssClass="txtbox_none" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        GSTN ID
                                    </div>
                                    <div id="txtcon-m_src">
                                        <asp:TextBox ID="txtGSTN_ID" runat="server" MaxLength="20" TabIndex="28" CssClass="txtbox_none"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        GSTN ID</div>
                                    <div id="txtcon-m_src">
                                        <asp:TextBox ID="txtCommercial_RegistrationNo" runat="server" MaxLength="20" onkeypress="return charnum2(event)"
                                            onpaste="return validatePaste(event);" TabIndex="30" onblur="ChangeCase(this);"
                                            onkeyup="ChangeCase(this);" onkeydown="ChangeCase(this);" ClientIDMode="Static"
                                            CssClass="txtbox_none"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        SEZ PAN No</div>
                                    <div id="txtcon-m_src">
                                        <asp:TextBox ID="txt_SEZ_PANNo" runat="server" MaxLength="20" onkeypress="return charnum2(event)"
                                            onpaste="return validatePaste(event);" TabIndex="33" ClientIDMode="Static" CssClass="txtbox_none"></asp:TextBox>
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
                                <div id="pop_text_area_Clientname" style="display:flex; align-items:center; gap:10px; white-space:nowrap;">
                                    <div id="tag_label_Clientname">Nature of Payment</div>
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddlNatureOfPayment" CssClass="txtbox_none_Mid_transac_InvNew"
                                            runat="server" Height="20px" TabIndex="39" style ="width:220px;">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>OTH Others</asp:ListItem>
                                            <asp:ListItem>DP Document Presentation</asp:ListItem>
                                            <asp:ListItem>FC Free Of Charge</asp:ListItem>
                                            <asp:ListItem>LC Letter Of Credit</asp:ListItem>
                                            <asp:ListItem>SD Site Draft</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>
                            </div>
                            <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height: 298px; width: 300px;">
                                <div id="pop_text_area_Clientname">
                                    <%--<div id="tag_label_Clientname">
                                    </div>--%>
                                     <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        Type</div>
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddlType" runat="server"  CssClass="listtxt-s_inner" style="width:170px;" />
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>
                                 <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        Branch No
                                    </div>
                                    <div id="txtcon-m_src">
                                        <asp:TextBox ID="txtBranchNO" runat="server" MaxLength="3" TabIndex="4" CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small"
                                            Onkeypress="return num1(event)" AutoPostBack="true" OnTextChanged="txtBranchNO_TextChanged"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>

                                    <div id="txtcon-m_src">
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>
                               <%-- <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                    </div>--%>
                                    <%--<div id="txtcon-m_src">
                                    </div>--%>
                                    <%--<div id="txtcon-r_src">
                                    </div>--%>
                            <%--    </div>--%>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                    </div>
                                    <%--<div id="txtcon-m_src">
                                    </div>--%>
                                    <%--<div id="txtcon-r_src">
                                    </div>--%>
                                </div>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname"style="margin-top:-10px;">
                                        City
                                    </div>
                                    <div id="txtcon-m_src" style="width: 180px;margin-top:-10px;">
                                        <asp:TextBox ID="txtcity" runat="server" MaxLength="35" CssClass="txtbox_none" TabIndex="7"
                                            Width="180px" onkeypress="return city1(event)" onpaste="return validatePaste(event);"></asp:TextBox>
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
                                        State Code
                                    </div>
                                    <div id="txtcon-m_src" style="width: 70px;">
                                        <asp:TextBox ID="txtCommercial_StateCode" runat="server" MaxLength="40" onkeypress="return num1(event)"
                                            TabIndex="26" CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-r_src">
                                        <div runat="server" id="ST_Code">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');opennewStatecode('IMPORT_STATECODE'); return false">
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                    <div id="txtcon-m_src">
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                 <div id="pop_text_area_Clientname">
                                     <div id="tag_label_Clientname">
                                    </div>
                                </div>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        WarehouseCode
                                    </div>
                                    <div id="txtcon-m_src" style="width: 180px;">
                                        <asp:TextBox ID="txtWarehouseCode" runat="server" CssClass="txtbox_none" TabIndex="31"
                                            Width="180px" MaxLength="200" onpaste="return validatePaste(event);"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-r_src">
                                    </div>
                                </div>
                                <div id="pop_text_area_Clientname">
                                    <div id="tag_label_Clientname">
                                        Payment Method
                                    </div>
                                    <div id="txtcon-m_src" style="width: 180px;">
                                        <asp:DropDownList ID="ddl_Payment_Method" runat="server" CssClass="txtbox_none" TabIndex="34"
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
                                <div id="pop_text_area_Clientname" style="display:flex; align-items:center; gap:6px; white-space:nowrap;">
                                    <div id="tag_label_Clientname">Valuation Method</div>
                                    <div id="txtcon-m_src">
                                        <asp:DropDownList ID="ddlValuationMethod" runat="server" Height="20px" TabIndex="40" CssClass="listtxt-s_inner" style ="width:180px;">
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
                                <div id="tag_label_transaction_export_Item_otherdet_frmlabel_new1" style="margin-left:-5px;">
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
                                            <div id="div_dbk_decl" runat="server" visible="false">
                                                <div id="tag_label_transaction_export_Item_otherdet_new1" style="width: 80px">
                                                    Declaration
                                                </div>
                                                <div id="txtcon-m_transaction_item_maindet" style="width: 200px">
                                                    <asp:CheckBox ID="chk_DB001" runat="server" Text="DB001" TabIndex="44" />
                                                    <asp:CheckBox ID="chk_DB002" runat="server" Text="DB002" TabIndex="45" />
                                                    <asp:CheckBox ID="chk_DB003" runat="server" Text="DB003" TabIndex="46" />
                                                </div>
                                            </div>
                                        </div>
                                        <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 940px">
                                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                                                Marks & Nos
                                            </div>
                                            <div id="txtcon-m_transaction_item_maindet" style="width: 800px; height: 15px;">
                                                <asp:TextBox ID="txt_Marksnos" TextMode="MultiLine" TabIndex="47" runat="server"
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
                                            <asp:TextBox ID="txtInsuranceRate" runat="server" MaxLength="8"  TabIndex="48"
                                                onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none"   Width="100px" onpaste="return validatePaste(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 350px;">
                                        <div id="tag_label_Clientname">
                                            TAN Number
                                        </div>
                                        <div id="txtcon-m_src" style="width: 110px">
                                            <asp:TextBox ID="txt_TAN_Number" runat="server" MaxLength="10" CssClass="txtbox_none" TabIndex="49"
                                                Width="100px" onpaste="return validatePaste(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 350px;">
                                        <div id="tag_label_Clientname">
                                            TDS Code
                                        </div>
                                        <div id="txtcon-m_src" style="width: 110px">
                                            <asp:TextBox ID="txt_TDS_Code" runat="server" MaxLength="10" CssClass="txtbox_none" TabIndex="50"
                                                Width="100px" onpaste="return validatePaste(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 350px;">
                                        <div id="tag_label_Clientname">
                                            TDS Rate
                                        </div>
                                        <div id="txtcon-m_src" style="width: 110px">
                                            <asp:TextBox ID="txt_TDS_Rate" runat="server" MaxLength="4"  TabIndex="51"
                                                onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none"   Width="100px" onpaste="return validatePaste(event);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                         
                        </div>
                        <div id="innerbox_MidMain_Mid_ClientMaster">
                            <div id="innerbox_ClientMaster_bot_inn">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                        TabIndex="52" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate_Client();"
                                        TabIndex="53" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                        OnClientClick="return validate_Client();" TabIndex="53" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="54" OnClientClick="jConfirm('Delete this Entry?', 'CLIENT MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" CssClass="dlete" />
                                    <asp:Button ID="btn" runat="server" TabIndex="54" OnClick="btnDelete_Click" CssClass="dlete"
                                        Style="display: none;" />
                                </div>
                                <div id="editbu">
                                   <%-- <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                                        tabindex="53" id="btnCancel" />--%>
                                         <input type="submit" value="" CausesValidation="false" class="scancel" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                                    <asp:HiddenField ID="hdn_id" runat="server" />
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <asp:HiddenField ID="hdn_checkVal" runat="server" />
                                    <asp:HiddenField ID="hdn_StateName_chk" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="hdn_StateName" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="hdn_Commercial_StateName" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="hdn_Commercial_StateName_chk" runat="server" ClientIDMode="Static" />
                                    <asp:HiddenField ID="hdn_ddlCommercial_Tax_yn" runat="server" />
                                </div>
                                <asp:TextBox ID="txtStateCode" runat="server" BorderColor="White" ForeColor="White"
                                    CssClass="txtbox_none_mid_size" Width="1px"></asp:TextBox>
                            </div>
                            </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <iframe src="" name="trans_igm_container" style="width:910px; height:400px;" scrolling="no" id="trans_ETP_Container_iframe">
                    </iframe>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

     <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2']);
    </script>

    </form>
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
            $("#txtStateName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_Name_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                jQuery('#txtStateName').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);
                            }
                            else {
                                var value = data.d;
                                if (value.indexOf("-") != -1) {
                                    var arr = value.split('-');
                                    alert(value);
                                    jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

        $(function () {
            $("#txtDistrict").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/District_Names_StateName_Wise_List",
                        //                        data: "{ 'mail': '" + request.term + "' }",
                        data: "{ 'mail': '" + request.term + "','StateName': '" + document.getElementById("txtStateName").value + "' }",
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


        $(function () {
            $("#txtCommercial_StateName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_Name_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtCommercial_StateName').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);

                                //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtCommercial_StateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
    <script type="text/javascript">
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
    </script>

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

    <script type="text/javascript">
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
    </script>

     <script type="text/javascript">
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
 </script>
     <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
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
  </script>
</body>
</html>
