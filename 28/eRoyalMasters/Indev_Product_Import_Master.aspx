<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Indev_Product_Import_Master.aspx.cs"
    Inherits="Indev_Product_Import_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Product Master | Updation</title>
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
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        EnablePageMethods="true" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>

        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>--%>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_Product">
                <div id="innerbox_MidMain_top_Product">
                    INDEV
                    PRODUCT MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="RefreshParent();return false;" />
                    </div>
                </div>
                <div id="pop_tabs_area1_prod_master">
                    <div id="pop_max_text_area_prod_master_New">
                        <div id="pop_max_text_area_prod_master">
                            <div id="tag_label_product_new">
                                Product</div>
                            <div id="txtcon-Mid_Maxtxt">
                                <%--<asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" MaxLength="120"
                                    onpaste="return checkTextAreaMaxLength(this,event,'120');" onkeyDown="return checkTextAreaMaxLength(this,event,'120');"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                    TabIndex="1" AutoPostBack="True" OnTextChanged="txtDescription_TextChanged" onkeyup="ChangeCase(this);autotab(this);"
                                    onfocus="ChangeCase(this);" onblur="ChangeCase(this);"></asp:TextBox>--%>

                                    <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" MaxLength="120"
                                    onpaste="return checkTextAreaMaxLength(this,event,'120');" onkeyDown="return checkTextAreaMaxLength(this,event,'120');"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                    TabIndex="1" AutoPostBack="True" OnTextChanged="txtDescription_TextChanged" onkeyup="ChangeCase(this);autotab(this);"
                                    onfocus="ChangeCase(this);" onblur="ChangeCase(this);" Onkeypress="return numcharspl1(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area_prod_master_lft">
                            <div id="tag_label_adcode">
                                Material Code
                            </div>
                            <div id="txtcon-m_Date">
                                <asp:TextBox ID="txtMaterialCode" runat="server" onkeypress="return numchar(event)"
                                    MaxLength="15" CssClass="txtbox_none_Date" TabIndex="2"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                

            <div id="pop_tabs_menu_prod_master" style="height: 352px;">
                <ol id="toc_new">
                    <li><a href="#page1" onclick="tab1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab1_Basic"><span>Basic Custom Duty</span></a> </li>
                    <li><a href="#page2" onclick="tab_CETH('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab2_CETH"><span>Central Excise Duties</span></a></li>
                    <li><a href="#page3" onclick="tab_General('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab3_Genearal"><span>Generic Description</span></a></li>
                </ol>
                <div class="content" id="page1">
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            CTH No
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtCTHNO" runat="server" MaxLength="8" ClientIDMode="Static" onkeypress="return num5(event)"
                                CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Promas1"
                                TabIndex="3"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCTH('CTH'); return false"
                                class="magnfy" tabindex="4"></a>
                        </div>
                        <div id="tag_label_Promasnew2">
                            RITC No
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtRITCNO" runat="server" CssClass="txtbox_none_Promas1 validate[required,custom[integer],minSize[8]]"
                                MaxLength="8" onkeypress="return num5(event)" ClientIDMode="Static" Height="16px"
                                TabIndex="5"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCTH(); return false"
                                class="magnfy" tabindex="6"></a>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label2">
                                 <asp:Label ID="lblCTH_Rate" runat="server" Text=""></asp:Label>%
                            </div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            Basic Duty / Notn
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtBasicNotn" CssClass="txtbox_none_Promas1" runat="server" MaxLength="8"
                                ClientIDMode="Static" TabIndex="7" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtBasicSLNO" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                                ClientIDMode="Static" TabIndex="8" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('BasicSLNO'); return false"
                                class="magnfy" tabindex="9"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtBasicRate" CssClass="txtbox_none_Promas3" runat="server" MaxLength="10"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="10"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_s_label">
                            %</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtBasicSPL" CssClass="txtbox_none_Promas2" runat="server" 
                                onkeyup="return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                MaxLength="10" TabIndex="11"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtBasicUnit" CssClass="txtbox_none_Promas3" onblur="ChangeCase(this);"
                                runat="server" MaxLength="3" onkeypress="return cha(event)" ClientIDMode="Static"
                                TabIndex="12"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('BasicUnit'); return false"
                                class="magnfy" tabindex="13"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-m_transaction_item_gen_notn_list1">
                            <asp:DropDownList ID="ddlBasicSPLTYPE" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                TabIndex="14">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            Addl Duty
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtAddlDuty_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                MaxLength="8" TabIndex="15" onkeypress="return notn(event)" Text="019/2006"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtAddlDuty_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                                MaxLength="10" TabIndex="16" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Proudct_Addl_duty'); return false"
                                class="magnfy" tabindex="17"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            Education Cess
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtEdu_Cess_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                MaxLength="8" TabIndex="18" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtEdu_Cess_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                                MaxLength="10" TabIndex="19" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Edu_cess'); return falsee"
                                class="magnfy" tabindex="20"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtEdu_Cess_Rate" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                TabIndex="21"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_s_label">
                            %</div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            Sec &amp; Higher Edu. Cess
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtSec_Edu_Cess_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                MaxLength="8" TabIndex="22" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtSec_Edu_Cess_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                                MaxLength="10" TabIndex="23" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Sec_Edu_cess'); return false"
                                class="magnfy" tabindex="24"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtSec_Edu_Cess_Rate" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                TabIndex="25" Height="16px"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_s_label">
                            %</div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            NCD</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtNCD_NOTN" CssClass="txtbox_none_Promas1" runat="server" MaxLength="8"
                                TabIndex="26" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtNCD_SLNO" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                                TabIndex="27" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('NCD'); return false"
                                class="magnfy" tabindex="28"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtNCD_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);"
                                onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                MaxLength="10" TabIndex="29"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_s_label">
                            %</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtNCD_SPL" CssClass="txtbox_none_Promas2" runat="server" onblur="extractNumber(this,6,false);"
                                onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                MaxLength="10" TabIndex="30"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtNCD_UNIT" CssClass="txtbox_none_Promas3" runat="server" MaxLength="3"
                                onblur="ChangeCase(this);" onkeypress="return cha(event)" ClientIDMode="Static"
                                TabIndex="31"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('NCD_UNIT'); return false"
                                class="magnfy" tabindex="32"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_transaction_item_gen_notn_list1">
                            <asp:DropDownList ID="ddlNCD_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                TabIndex="33">
                            </asp:DropDownList>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            Aggregate Duty
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtAggregate_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                MaxLength="8" TabIndex="34" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtAggregate_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                                MaxLength="10" TabIndex="35" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Aggregate_Duty'); return false"
                                class="magnfy" tabindex="36"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtAggregate_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                TabIndex="37"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_s_label">
                            %</div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            Safeguard Duty
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtSafeguard_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                MaxLength="8" TabIndex="38" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtSafeguard_SL" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                                TabIndex="39" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('SafeGuard_Duty'); return false"
                                class="magnfy" tabindex="40"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtSafeguard_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                TabIndex="41"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_s_label">
                            %</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtSafeguard_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                TabIndex="42"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtSafeguard_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="ChangeCase(this);" onkeypress="return cha(event)" MaxLength="3" ClientIDMode="Static"
                                TabIndex="43"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Safeguard_UNIT'); return false"
                                class="magnfy" tabindex="44"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_transaction_item_gen_notn_list1">
                            <asp:DropDownList ID="ddlSafeguard_SPL_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                TabIndex="45">
                            </asp:DropDownList>
                        </div>
                        <asp:HiddenField ID="hdn_Update_Product" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <div id="txtcon-r_src">
                        </div>
                    </div>
<div id="pop_text_area_Size2_Promaster">
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width:150px;">
                                SAPTA Notn
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtSAPTA_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="58"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSAPTA_NOTN_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="59"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Prouduct_Aggregate_Duty'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSAPTA_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="60"></asp:TextBox>
                            </div>
                        </div>

<div id="pop_text_area_Size2_Promaster">
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width:150px;">
                                Tariff Value
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtTariff_NOTN" runat="server" MaxLength="10" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="61"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtTariff_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="62"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label_tariff">
                                Qty
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtTariff_Qty" runat="server" MaxLength="17" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="63"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label_tariff">
                                Amt
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtTariff_Amount" runat="server" MaxLength="9" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" ClientIDMode="Static"
                                    TabIndex="64"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtTariff_Amount_unitCode" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    MaxLength="3" onkeyup="ChangeCase(this);autotab(this);" TabIndex="65"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Tariff_Amount_Code'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>

                </div>

                <div class="content" id="page2" style="display: none;">
                    <div id="pop_text_area_transac_popup_inn_container_left_trans_item_ceth">
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                CETH No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtCETH_No" runat="server" MaxLength="8" CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Promas1_Mediam"
                                    TabIndex="3" onkeypress="return num5(event)"></asp:TextBox>
                            </div>
                            <div id="txtcon_Promas1_empty">
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCETH('CETH_NO'); return false"
                                    class="magnfy" tabindex="4"></a>
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                  <asp:Label ID="lblCETH_Rate" runat="server" Text=""></asp:Label>%
                            
                            </div>
                        </div>
                        <%--<div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                MRP Duty
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                                <asp:CheckBox ID="chkMRP_Duty" runat="server" Checked="false" TabIndex="5" />
                                <%--<input name="" type="checkbox" value="">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label3">
                                Sr. No. List
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMRP_SL_NO" runat="server" Enabled="False" MaxLength="10" onkeypress="return numchar(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_maindet" TabIndex="6"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label5">
                                MRP Rs/Unit
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMRP_AMOUNT" runat="server" Enabled="False" MaxLength="15" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="7" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label4">
                                Abt @ %
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMRP_ABT_RATE" runat="server" Enabled="False" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="10" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="8"></asp:TextBox>
                            </div>
                        </div>--%>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                CVD</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CVD_NOTN" CssClass="txtbox_none_Promas1" runat="server" onkeypress="return notn(event)"
                                    MaxLength="8" TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CVD_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="10" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('CVD'); return false"
                                    class="magnfy" tabindex="11"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CVD_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="10" TabIndex="12"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CVD_SPL" CssClass="txtbox_none_Promas2" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    runat="server" MaxLength="10" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CVD_UNIT" CssClass="txtbox_none_Promas3" runat="server" MaxLength="3"
                                    ClientIDMode="Static" TabIndex="14" onblur="ChangeCase(this);" onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('CVD_UNIT'); return false"
                                    class="magnfy" tabindex="15"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddlCVD_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                    TabIndex="16">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth" style="display:none;">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Education Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CVD_Education_CESS_Rate" CssClass="validate[required,custom[number]] txtbox_none_Promas2"
                                    runat="server" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="17"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label6">
                                Sec&amp;Hig.Edu Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CVD_Sec_Edu_CESS_Rate" CssClass="validate[required,custom[number]] txtbox_none_Promas2"
                                    runat="server" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="18"></asp:TextBox>
                            </div>
                        </div>

                         <%-- //--------------------Updation START --%>

                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                            CVD Education Cess</div>
                            <div id="txtcon-m_transaction_item_maindet">

                              <asp:TextBox ID="txt_CVD_Edu_Cess_NOTN" CssClass="txtbox_none_Promas1" runat="server" TabIndex="19"
                                MaxLength="8" onkeypress="return notn(event)"></asp:TextBox>


                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">

                              <asp:TextBox ID="txt_CVD_Edu_Cess_NOTN_SL" CssClass="txtbox_none_Mid_transac_item_CTH_small" runat="server" TabIndex="20"
                                MaxLength="10"  onkeypress="return NOTNSLNO(event)"></asp:TextBox>

                            </div>
                            <div id="magnify_area">

                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('PM_Edu_cess'); return falsee"
                               TabIndex="21"  class="magnfy" ></a>

                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">

                                <asp:TextBox ID="txt_CETH_Edu_Cess_Rate" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                  TabIndex="22" ></asp:TextBox>


                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                              %</div>
                        </div>
                       <%-- //---------------------------------------------------------------------------------------------%>


                          <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Sec&amp;Hig.Edu Cess</div>
                            <div id="txtcon-m_transaction_item_maindet">

                              <asp:TextBox ID="txt_CVD_Sec_Edu_Cess_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                TabIndex="23" MaxLength="8" onkeypress="return notn(event)"></asp:TextBox>

                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                            
                            <asp:TextBox ID="txt_CVD_Sec_Edu_Cess_NOTN_SL" CssClass="txtbox_none_Mid_transac_item_CTH_small" runat="server"
                                TabIndex="24" MaxLength="10" onkeypress="return NOTNSLNO(event)"></asp:TextBox>

                            
                            </div>
                            <div id="magnify_area">

                                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('PM_Sec_Edu_cess'); return false"
                                 TabIndex="25" class="magnfy" ></a>

                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                               <asp:TextBox ID="txt_CETH_Sec_Edu_Cess_Rate" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                 TabIndex="26" Height="16px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                             %</div>
                        </div>


                          <%-- //--------------------Updation END --%>


                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Addl. Duty (Sub-Section)</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl5_SIA_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="27" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl5_SIA_NOTN_SL" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    ClientIDMode="Static" onkeypress="return  NOTNSLNO(event)" TabIndex="28"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Duty'); return false"
                                    class="magnfy" tabindex="29"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl5_SIA_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="30"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Addl Duty of Exice(GSI)
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_GSI_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="31" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_SL" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="32" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Duty_GSI'); return false"
                                    class="magnfy" tabindex="33"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="34"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_GSI_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="35"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="36" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_GSI_UNIT');return false"
                                    class="magnfy" tabindex="37"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_GSI_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="38">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Spl. Exice Duty (Sched-11)
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_SHE11_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="39" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="40" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_She11_Notn'); return false"
                                    tabindex="41" class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="42"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_SHE11_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="43"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="44" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_SHE11_UNIT'); return false"
                                    class="magnfy" tabindex="45"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_SHE11_Type" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="46">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Addl Duty of Excise (TTA)</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_TTA_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="47" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="48" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_TTA_Notn'); return false"
                                    class="magnfy" tabindex="49"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="50"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_TTA_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="51"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="52" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_TTA_UNIT'); return false"
                                    class="magnfy" tabindex="53"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_TTA_Type" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                    TabIndex="54">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Health Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_Health_CESS_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="55" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="56" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Health_Cess'); return false"
                                    tabindex="57" class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="58"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_Health_CESS_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="59"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="60" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_Health_CESS_UNIT'); return false"
                                    tabindex="61" class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_Health_CESS_Type" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="62">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Cess &amp; Notification
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CESS_NOTN" CssClass="txtbox_none_Promas1" runat="server" MaxLength="8"
                                    TabIndex="63" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="64" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Cess_Notn'); return false"
                                    tabindex="65" class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="10" TabIndex="66"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CESS_SPL" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="67"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_UNIT" CssClass="txtbox_none_Promas3" runat="server" MaxLength="3"
                                    ClientIDMode="Static" TabIndex="68" onblur="ChangeCase(this);" onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('CESS_UNIT'); return false"
                                    class="magnfy" tabindex="69"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_CESS_Type" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                    TabIndex="70">
                                </asp:DropDownList>
                            </div>
                        </div>
<div id="pop_text_area_Size2_Promaster">
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width:150px;">
                                MRP Duty
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                                <asp:CheckBox ID="chkMRP_Duty" runat="server"  />
                                <%--<input name="" type="checkbox" value="">--%>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label3">
                                Sr. No. List
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMRP_SL_NO" runat="server" Enabled="False" MaxLength="10" onkeypress="return numchar(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_maindet" TabIndex="98"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label5">
                                MRP Rs/Unit
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMRP_AMOUNT" runat="server" Enabled="False" MaxLength="17" onblur="extractNumber(this,2,false);"
                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="99"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label4">
                                Abt @ %
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMRP_ABT_RATE" runat="server" Enabled="False" MaxLength="17" onblur="extractNumber(this,2,false);"
                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="100"></asp:TextBox>
                            </div>
                        </div>

 <div id="pop_text_area_Size2_Promaster">
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width:150px;">
                               RSP Notn No
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtRSP_Notn_No" runat="server" onkeypress="return notn(event)" CssClass="txtbox_none_Promas1"
                                    TabIndex="101" MaxLength="8" Enabled="False"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                             <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_otherduty_longlabel">
                               RSP Notn SL.No
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtRSP_Notn_Slno" onkeypress="return num1(event)" runat="server" Enabled="False"
                                    CssClass="validate[custom[integer]] txtbox_none_Promas3" TabIndex="102"
                                    MaxLength="3"></asp:TextBox>
                            </div>
                             <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                             <div id="tag_label_transaction_popup_trans_cth_label4">
                               PART No
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_PartNo"  runat="server" 
                                    CssClass="txtbox_none_Promas1" TabIndex="102"
                                    MaxLength="15"></asp:TextBox>
                            </div>
                        </div>


                    </div>
                </div>

                <div class="content" id="page3" style="display: none;">
                    <div id="pop_text_area_Size2_Promaster_maxtxt">
                        <div id="tag_label_Promasnew4">
                            Generic Desc
                        </div>
                        <div id="max_txtarea">
                            <div id="txtcon-t_Maxtxt">
                            </div>
                            <div id="txtcon-Mid_promast_genrtxt">
                                <asp:TextBox ID="txtGenericDesc" runat="server" CssClass="validate[required] txtbox_none_promast_maxtxt"
                                    TextMode="MultiLine" MaxLength="60" onkeyDown="return checkTextAreaMaxLength(this,event,'60');"
                                    onpaste="return checkTextAreaMaxLength(this,event,'60');" TabIndex="3"></asp:TextBox>
                            </div>
                            <div id="txtcon-b_Maxtxt">
                            </div>
                        </div>
                        <div id="lblMsg5" style="display: none;">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew4">
                            Manufacturer</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtManufacturer" runat="server" MaxLength="50" onkeypress="return desc2(event)"
                                CssClass="validate[required] txtbox_none_Promas1_Mediam" TabIndex="4"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew4">
                            Brand</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtBrand" runat="server" onkeypress="return desc2(event)" MaxLength="20"
                                CssClass="validate[required] txtbox_none_Promas1_Mediam" TabIndex="5"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew4">
                            Model</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtModel" runat="server" onkeypress="return desc2(event)" MaxLength="20"
                                CssClass="validate[required] txtbox_none_Promas1_Mediam" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew4">
                            End Use
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtEndUse" runat="server" onkeypress="return desc2(event)" MaxLength="20"
                                CssClass="validate[required] txtbox_none_Promas1_Mediam" TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_Promasnew4">
                            Country Of Origin
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtCountryName" runat="server" MaxLength="20" ClientIDMode="Static"
                                CssClass="validate[required,custom[onlyLetterSp]] txtbox_none_Promas1_Mediam"
                                onkeypress="return char(event)" onblur="ChangeCase(this);" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry(); return false"
                                class="magnfy" tabindex="9"></a>
                        </div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew4">
                            Accessories</div>
                        <div id="tag_label_Promasnewremarks">
                            Remarks</div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster_maxtxt2">
                        <div id="max_txtarea">
                            <div id="txtcon-t_Maxtxt">
                            </div>
                            <div id="txtcon-Mid_promast_genrtxt">
                                <asp:TextBox ID="txtAccessories" runat="server" CssClass="txtbox_none_promast_maxtxt"
                                    MaxLength="120" TextMode="MultiLine" onpaste="return checkTextAreaMaxLength(this,event,'120');"
                                    onkeyDown="return checkTextAreaMaxLength(this,event,'120');" TabIndex="10"></asp:TextBox>
                            </div>
                            <div id="txtcon-b_Maxtxt">
                            </div>
                        </div>
                        <div id="lblMsg3" style="display: none;">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="max_txtarea">
                            <div id="txtcon-t_Maxtxt">
                            </div>
                            <div id="txtcon-Mid_promast_genrtxt">
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="txtbox_none_promast_maxtxt"
                                    MaxLength="120" TextMode="MultiLine" onpaste="return checkTextAreaMaxLength(this,event,'120');"
                                    onkeyDown="return checkTextAreaMaxLength(this,event,'120');" TabIndex="11"></asp:TextBox>
                            </div>
                            <div id="txtcon-b_Maxtxt">
                            </div>
                        </div>
                        <div id="lblMsg4" style="display: none;">
                        </div>
                    </div>
                </div>

            </div>

         

            <div id="innerbox_MidMain_bot_Product">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            Visible="False" CssClass="new" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide')"
                            TabIndex="66" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" Visible="False" CssClass="save" OnClick="btnSave_Click"
                            OnClientClick="return validate_Product();" TabIndex="63" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Visible="False" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate_Product();" TabIndex="63" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" Visible="False" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'PRODUCT MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" TabIndex="64" />
                        <asp:Button ID="btn" runat="server" TabIndex="15" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                        <asp:HiddenField ID="txtCountryCode" runat="server" />
                    </div>
                    <div id="editbu">

                      <asp:Button ID="btnCancel" runat="server" class="scancel" onClientClick="RefreshParent();return false;"
                        tabindex="65" CausesValidation="false"
                        UseSubmitBehavior="false"/>

                   <%-- <asp:Button ID="btnCancel" runat="server" class="scancel" onclick="RefreshParent();return false;"
                        tabindex="65" CausesValidation="false"
                        UseSubmitBehavior="false"/>--%>
                       
                        <%--<input type="submit" value="Submit" class="scancel" onclick="parent.productMasterwindow.hide()"
                            tabindex="65" id="btnCancel" /></div>--%>
                </div>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static"/>

                <asp:HiddenField ID="HiddenField2" runat="server" Value="1" />
            </div>
            </div>
          <%-- </div>--%>
           
             
             
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/product_JScript.js" type="text/javascript"></script>
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
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page1', 'page2', 'page3']);
    </script>
  
</body>
</html>
