<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product_Import_Master.aspx.cs"
    Inherits="eRoyalMasters_Product_Import_Master" %>

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

     <script type="text/javascript">
         function checkTextAreaMaxLength_CompanyWise(textBox, e) {

             var aa = document.getElementById("hdn_companyID").value;
             //            alert(aa);
             if (aa == '223') {
                 length = '500';
             }
             else {
                 length = '120';
             }

             var mLen = textBox["MaxLength"];
             if (null == mLen)
                 mLen = length;

             var maxLength = parseInt(mLen);
             if (!checkSpecialKeys(e)) {
                 if (textBox.value.length > maxLength - 1) {
                     if (window.event)//IE
                     {
                         e.returnValue = false;
                         return false;
                     }
                     else//Firefox
                         e.preventDefault();
                 }
             }
         }
        
    </script>

    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
     <script src="../js/Import_Jscript/Import_Item_GST.js" type="text/javascript"></script>
     <script src="../js/Import_Jscript/Import_Item.js" type="text/javascript"></script>
      <script src="../js/Import_Jscript/Import_Item_GST.js" type="text/javascript"></script>
      <script src="../js/Import_Jscript/IMP_Single_Window.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/IMP_Single_Window_Master.js" type="text/javascript"></script>
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
                            <div id="txtcon-Mid_Maxtxt" style="height:30px;" >
                                <%--<asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" MaxLength="120"
                                    onpaste="return checkTextAreaMaxLength(this,event,'120');" onkeyDown="return checkTextAreaMaxLength(this,event,'120');"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                    TabIndex="1" AutoPostBack="True" OnTextChanged="txtDescription_TextChanged" onkeyup="ChangeCase(this);autotab(this);"
                                    onfocus="ChangeCase(this);" onblur="ChangeCase(this);"></asp:TextBox>--%>

                                   <%-- <asp:TextBox ID="txtDescription"  onchange="updateTextbox()" TextMode="MultiLine" runat="server" MaxLength="120"
                                    onpaste="return checkTextAreaMaxLength(this,event,'120');" onkeyDown="return checkTextAreaMaxLength(this,event,'120');"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                    TabIndex="1" AutoPostBack="True" OnTextChanged="txtDescription_TextChanged" onkeyup="ChangeCase(this);autotab(this);"
                                    onfocus="ChangeCase(this);" onblur="ChangeCase(this);updateTextbox()" Onkeypress="return numcharspl1(event)"></asp:TextBox>--%>

                                    <asp:TextBox ID="txtDescription" runat="server" style="height:18px"  onblur="updateTextbox()" onkeypress="DisableSpecialKeyEvents(); checkTextAreaMaxLength_CompanyWise(this,event);"
                                         onchange="updateTextbox()" onkeyup="updateTextbox" TextMode="MultiLine" onkeyDown="return (event.keyCode!=13);" 
                                         onpaste="return checkTextAreaMaxLength_CompanyWise(this,event);"  CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                        TabIndex="1" ClientIDMode="Static"></asp:TextBox>

                            </div>
                            <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width:117px";>
                               PART NO
                            </div>
                            <div id="txtcon-m_transaction_item_maindet " style="width: 650px;">
                                <asp:TextBox ID="txt_PartNo" runat="server"  CssClass="txtbox_none_Promas1" TabIndex="2" MaxLength="15"  placeholder="Part No (Mandatory S/W)" style="width: 200px;">
                                    </asp:TextBox>
                            </div>
                        </div>
                        </div>
                        <div id="pop_text_area_prod_master_lft" style="width:650px; margin-top:5px;">
                            <div id="tag_label_adcode">
                                Material Code
                            </div>
                            <div id="txtcon-m_Date">
                                <asp:TextBox ID="txtMaterialCode" runat="server" onkeypress="return numchar(event)"
                                    MaxLength="15" CssClass="txtbox_none_Date" TabIndex="2"></asp:TextBox>
                            </div>
                            <div id="txtcon_Promas1_empty"></div>
                             <div id="tag_label_adcode">
                                Importer Name
                            </div>
                            <div id="txtcon-m_Date"  style="width:250px;">
                                <asp:TextBox ID="txtImporter_Name" runat="server" ClientIDMode="Static" Width="250px"
                                    MaxLength="15" CssClass="txtbox_none_Date" TabIndex="2"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                

            <div id="pop_tabs_menu_prod_master" style="height: 382px;">
                <ol id="toc_new">
                    <li><a href="#page1" onclick="tab_p1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab1_Basic"><span>Basic Custom Duty</span></a> </li>

                    <li><a href="#page2" onclick="tab_p2('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab2_CETH"><span>Central Excise Duties</span></a></li>  

                    <li style=" height:15px;"><a href="#page3" onclick="tab_p3('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab3_Genearal"><span>ADD & Generic Description</span></a></li>

                    <li><a href="#page-4" onclick=" tab_p4('0');jQuery('#form1').validationEngine('hideAll');"
                        id="IGST"><span>IGST & Manufacturer</span></a></li>
                   
                   <%-- <li style=" height:15px;"><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SINGLE_WINDOW('0');"
                        id="SINGLE_WINDOW" runat="server" ><span> S/W</span></a></li>--%>

                     <li style=" height:15px;"><a href="#page-5" onclick="tab_p5('0');jQuery('#form1').validationEngine('hideAll');"
                        id="SINGLE_WINDOW"><span>S/W</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            CTH No
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtCTH_No" runat="server" MaxLength="8" ClientIDMode="Static" onkeypress="return num5(event)"
                                CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Promas1"
                                TabIndex="3"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCTH('CTH'); return false"
                                class="magnfy" ></a>
                        </div>
                        <div id="tag_label_Promasnew2">
                            RITC No
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtRITCNO" runat="server" CssClass="txtbox_none_Promas1 validate[required,custom[integer],minSize[8]]"
                                MaxLength="8" onkeypress="return num5(event)" ClientIDMode="Static" Height="16px"
                                TabIndex="4"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCTH(); return false"
                                class="magnfy" ></a>
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
                                ClientIDMode="Static" TabIndex="5" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtBasicSLNO" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                                ClientIDMode="Static" TabIndex="6" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('BasicSLNO'); return false"
                                class="magnfy" ></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtBasicRate" CssClass="txtbox_none_Promas3" runat="server" MaxLength="10"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="7"></asp:TextBox>
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
                                MaxLength="10" TabIndex="8"></asp:TextBox>
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
                                TabIndex="9"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('BasicUnit'); return false"
                                class="magnfy" ></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-m_transaction_item_gen_notn_list1">
                            <asp:DropDownList ID="ddlBasicSPLTYPE" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                TabIndex="10">
                            </asp:DropDownList>
                        </div>
                    </div>
                   <div id="pop_text_area_Size2_Promaster" style="display: none;">
                        <div id="tag_label_Promasnew">
                            Addl Duty
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtAddlDuty_NOTN" CssClass="txtbox_none_Promas1" runat="server" Enabled="false"
                                MaxLength="8" TabIndex="11" onkeypress="return notn(event)" Text="019/2006"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtAddlDuty_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server" Enabled="false"
                                MaxLength="10" TabIndex="12" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Proudct_Addl_duty'); return false"
                                class="magnfy" ></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>

                         <div id="txtcon-l_src"></div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtAddlDuty_Rate" CssClass="txtbox_none_Promas3" runat="server" Enabled="false"
                               onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                               MaxLength="10" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_s_label">
                            %</div>

                    </div>
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            Education Cess
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtEdu_Cess_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                MaxLength="8" TabIndex="14" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtEdu_Cess_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                                MaxLength="10" TabIndex="15" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Edu_cess'); return falsee"
                                class="magnfy"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtEdu_Cess_Rate" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                TabIndex="16"></asp:TextBox>
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
                                MaxLength="8" TabIndex="17" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtSec_Edu_Cess_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                                MaxLength="10" TabIndex="18" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Sec_Edu_cess'); return false"
                                class="magnfy"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtSec_Edu_Cess_Rate" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                TabIndex="19" Height="16px"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_s_label">
                            %</div>
                    </div>

                     <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                             Social Welfare
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txt_Social_Welfare_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                MaxLength="8" TabIndex="19" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txt_Social_Welfare_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                                MaxLength="10" TabIndex="19" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Social_Welfare'); return false"
                                class="magnfy"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txt_Social_Welfare_Rate" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                TabIndex="19" Height="16px"></asp:TextBox>
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
                            <asp:TextBox ID="txtNCD_NOTN" CssClass="txtbox_none_Promas1" runat="server" MaxLength="8" Enabled="false"
                                TabIndex="20" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtNCD_SLNO" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10" Enabled="false"
                                TabIndex="21" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('NCD');ReadOnly return false"
                                class="magnfy" tabindex="22"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtNCD_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);" Enabled="false"
                                onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                MaxLength="10" TabIndex="23"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_s_label">
                            %</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtNCD_SPL" CssClass="txtbox_none_Promas2" runat="server" onblur="extractNumber(this,6,false);" Enabled="false"
                                onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                MaxLength="10" TabIndex="24"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtNCD_UNIT" CssClass="txtbox_none_Promas3" runat="server" MaxLength="3" Enabled="false"
                                onblur="ChangeCase(this);" onkeypress="return cha(event)" ClientIDMode="Static"
                                TabIndex="25"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('NCD_UNIT');ReadOnly return false"
                                class="magnfy"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_transaction_item_gen_notn_list1">
                            <asp:DropDownList ID="ddlNCD_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server" Enabled="false"
                                TabIndex="26">
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
                                MaxLength="8" TabIndex="27" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtAggregate_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                                MaxLength="10" TabIndex="28" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Aggregate_Duty'); return false"
                                class="magnfy" ></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtAggregate_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                TabIndex="29"></asp:TextBox>
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
                                MaxLength="8" TabIndex="30" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtSafeguard_SL" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                                TabIndex="31" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('SafeGuard_Duty'); return false"
                                class="magnfy" ></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtSafeguard_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                TabIndex="32"></asp:TextBox>
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
                                TabIndex="33"></asp:TextBox>
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
                                TabIndex="34"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Safeguard_UNIT'); return false"
                                class="magnfy" ></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_transaction_item_gen_notn_list1">
                            <asp:DropDownList ID="ddlSafeguard_SPL_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                TabIndex="35">
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
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="36"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSAPTA_NOTN_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="37"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Prouduct_Aggregate_Duty'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSAPTA_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="38"></asp:TextBox>
                            </div>
                        </div>

<div id="pop_text_area_Size2_Promaster">
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width:150px;">
                                Tariff Value
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtTariff_NOTN" runat="server" MaxLength="10" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="39"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtTariff_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="40"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label_tariff">
                                Qty
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtTariff_Qty" runat="server" MaxLength="17" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="41"></asp:TextBox>
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
                                    TabIndex="42"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtTariff_Amount_unitCode" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    MaxLength="3" onkeyup="ChangeCase(this);autotab(this);" TabIndex="43"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Tariff_Amount_Code'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>


                        <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            AID Cess
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txt_AIDC_NOTN" runat="server" MaxLength="8"  onkeypress="return notn(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="66" ></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txt_AIDC_NOTN_SLNO" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" 
                                    TabIndex="67" ></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                             <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupAIDC('AIDC'); return false"
                                    class="magnfy"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                             <asp:TextBox ID="txt_AIDC_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="68"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_s_label">
                            %</div>
                    </div>
                        
                        <%--<div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                AID Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_AIDC_NOTN" runat="server" MaxLength="8"  onkeypress="return notn(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="66" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_AIDC_NOTN_SLNO" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" 
                                    TabIndex="67" ></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                               
                                     <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupAIDC('AIDC'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_AIDC_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="68"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                        </div>--%>

                </div>

                <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_left_trans_item_ceth">
                        <div id="tag_transac_lft_Trans_item_Cth" >
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
                       
                        <div id="tag_transac_lft_Trans_item_Cth" style="display: none;">
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

                        <%--<div id="tag_transac_lft_Trans_item_Cth_Sec_hi" style="visibility:hidden">
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
                        </div>--%>
                       <%-- //---------------------------------------------------------------------------------------------%>


                          <%--<div id="tag_transac_lft_Trans_item_Cth_Sec_hi" style="visibility:hidden">
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
                        </div>--%>


                          <%-- //--------------------Updation END --%>


                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi" style="margin-top:15px">
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
                                    class="magnfy" ></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl5_SIA_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="29"></asp:TextBox>
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
                                    MaxLength="8" TabIndex="30" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_SL" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="31" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Duty_GSI'); return false"
                                    class="magnfy" ></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="32"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_GSI_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="33"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="34" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_GSI_UNIT');return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_GSI_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="35">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Spl. Exice Duty (Sched-11)
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_SHE11_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="36" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="37" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_She11_Notn'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="38"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_SHE11_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="39"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="40" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_SHE11_UNIT'); return false"
                                    class="magnfy" ></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_SHE11_Type" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="41">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Addl Duty of Excise (TTA)</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_TTA_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="42" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="43" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_TTA_Notn'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="44"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_TTA_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="45"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="46" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_TTA_UNIT'); return false"
                                    class="magnfy" ></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_TTA_Type" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                    TabIndex="47">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Health Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_Health_CESS_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="48" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="49" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Health_Cess'); return false"
                                  class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="50"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_Health_CESS_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="51"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="52" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_Health_CESS_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_Health_CESS_Type" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="52">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Cess &amp; Notification
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CESS_NOTN" CssClass="txtbox_none_Promas1" runat="server" MaxLength="8"
                                    TabIndex="53" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="54" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Cess_Notn'); return false"
                                  class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="10" TabIndex="55"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CESS_SPL" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="56"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_UNIT" CssClass="txtbox_none_Promas3" runat="server" MaxLength="3"
                                    ClientIDMode="Static" TabIndex="57" onblur="ChangeCase(this);" onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('CESS_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_CESS_Type" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                    TabIndex="58">
                                </asp:DropDownList>
                            </div>
                        </div>


                           <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Infra Cess          
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtinfra_cess_Notn" runat="server" onkeypress="return notn(event)" MaxLength="8" Enabled="false"
                                    CssClass="txtbox_none_Promas1" ClientIDMode="Static" TabIndex="59"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtinfra_cess_Notn_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)" Enabled="false"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="60"></asp:TextBox>
                            </div>
                               <div id="magnify_area">
                                   <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Infra_Notn');ReadOnly return false"
                                       class="magnfy"></a>
                               </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtinfra_cess_Notn_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);" Enabled="false"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="61"></asp:TextBox>
                            </div>
                       
                        </div>
                      <%--  <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                               PART NO
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_PartNo" runat="server" CssClass="txtbox_none_Promas1" TabIndex="62"
                                    MaxLength="15"></asp:TextBox>
                            </div>
                        </div>--%>

<div id="pop_text_area_Size2_Promaster" style="display:none">
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

                        <div id="pop_text_area_Size2_Promaster" style="display: none">
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width: 150px;">
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
                                <asp:TextBox ID="txtRSP_Notn_Slno" onkeypress="return num1(event)" runat="server"
                                    Enabled="False" CssClass="validate[custom[integer]] txtbox_none_Promas3" TabIndex="102"
                                    MaxLength="3"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label4">
                                PART No
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <%--<asp:TextBox ID="txt_PartNo" runat="server" CssClass="txtbox_none_Promas1" TabIndex="102"
                                    MaxLength="15"></asp:TextBox>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-3" >
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width:120px;">
                            Anti Dumping Notn
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_AntiDumping_Notn" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static" TabIndex="114"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_AntiDumping_Notification('ADD_NOTN_SEARCH_ITEM'); return false"
                                class="magnfy"></a>
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Anti Dumping Notn Sl
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_AntiDumping_Notn_SL" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="115"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                        <div id="tag_label_transaction_popup_trans_cth_label"  style="width:120px;">
                            CTH Sl No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCTH_SL_No" runat="server" onkeyup="autotab(this);" ClientIDMode="Static"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="116"
                                MaxLength="8"></asp:TextBox>
                        </div>
                      
                        <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            CTH Supplier SL
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCTH_Supplier_SL" onkeypress="return num1(event)" onkeyup="autotab(this);"
                                ClientIDMode="Static" runat="server" CssClass="validate[custom[integer]] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="117" MaxLength="8"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                        <div id="tag_label_transaction_popup_trans_cth_label"  style="width:120px;">
                            CTH Qty
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCTH_Qty" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" runat="server"
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="118"
                                MaxLength="12"></asp:TextBox>
                        </div>
                    </div>

                    <div id="pop_text_area_Size2_Promaster_maxtxt">
                        <div id="tag_label_Promasnew4">
                            Generic Desc
                        </div>
                        <div id="max_txtarea">
                            <div id="txtcon-t_Maxtxt">
                            </div>
                            <div id="txtcon-Mid_promast_genrtxt">
                                <asp:TextBox ID="txtGenericDesc" runat="server" CssClass="txtbox_none_promast_maxtxt"
                                    TextMode="MultiLine" MaxLength="60" onkeyDown="return checkTextAreaMaxLength(this,event,'60');"
                                    onpaste="return checkTextAreaMaxLength(this,event,'60');" TabIndex="3"></asp:TextBox>
                            </div>
                            <div id="txtcon-b_Maxtxt">
                            </div>
                        </div>
                        <div id="lblMsg5" style="display: none;">
                        </div>
                    </div>
                    <div id="pop_text_area_Size2_Promaster" style="width:750px;">
                        <div id="tag_label_Promasnew4">
                            Manufacturer</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtManufacturer" runat="server" MaxLength="50" onkeypress="return numcharspl1(event)"
                                CssClass="txtbox_none_Promas1_Mediam" TabIndex="4"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty"></div>
                  
                        <div id="tag_label_Promasnew4" style="width:70px;">
                            Brand</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtBrand" runat="server" onkeypress="return desc2(event)" MaxLength="20"
                                CssClass="txtbox_none_Promas1_Mediam" TabIndex="5"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    <%--</div>--%>
                    </div>
                    <div id="pop_text_area_Size2_Promaster" style="width:750px;">
                        <div id="tag_label_Promasnew4">
                            Model</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtModel" runat="server" onkeypress="return desc2(event)" MaxLength="20"
                                CssClass="txtbox_none_Promas1_Mediam" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    <div id="txtcon_Promas1_empty"></div>
                        <div id="tag_label_Promasnew4" style="width:70px;">
                            End Use
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtEndUse" runat="server" onkeypress="return desc2(event)" MaxLength="20"
                                CssClass="txtbox_none_Promas1_Mediam" TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                           <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_End_Use_Of_Itemd('End_Use'); return false"
                                    class="magnfy"></a>
                        </div>
                        </div>
                        <div id="pop_text_area_Size2_Promaster" style="width:750px;">
                        <div id="tag_label_Promasnew4">
                            Country Of Origin
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtCountryName" runat="server" MaxLength="20" ClientIDMode="Static"
                                CssClass="validate[custom[onlyLetterSp]] txtbox_none_Promas1_Mediam"
                                onkeypress="return char(event)" onblur="ChangeCase(this);" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry(); return false"
                                class="magnfy"></a>
                        </div>
                        </div>
                    <%--</div>--%>
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
                                    onkeyDown="return checkTextAreaMaxLength(this,event,'120');" TabIndex="9"></asp:TextBox>
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
                                    onkeyDown="return checkTextAreaMaxLength(this,event,'120');" TabIndex="10"></asp:TextBox>
                            </div>
                            <div id="txtcon-b_Maxtxt">
                            </div>
                        </div>
                        <div id="lblMsg4" style="display: none;">
                        </div>
                    </div>
                    </div>
               

                <div class="content" id="page-4">
                    <div id="pop_text_area_Size2_Promaster_maxtxt" style="height:90px">

                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                LEVY NOTN No</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="160"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" TabIndex="161"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise_IGST('LEVY_NOTN_IGST',document.getElementById('txtCTHNO').value); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="162"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_SPL_Amt" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="163"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_UNIT" runat="server" MaxLength="3" ClientIDMode="Static"
                                    onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="164"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('IGST_LEVY_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <%-- <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddlCVD_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                    TabIndex="16">
                                </asp:DropDownList>
                            </div>--%>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                EXCEMPTION NOTN No</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="165"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" TabIndex="166"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('LEVY_EXC_NOTN'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="167"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:DropDownList ID="ddl_LEVY_EXCEMPTION_NOTN_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn" Width="110px"  TabIndex="167">
                                    <asp:ListItem Value="G" Text="GSTN Notn"></asp:ListItem>
                                    <asp:ListItem  Value="C" Text="Customs Notn"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                LEVY C.P. CESS NOTN No</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_NOTN" runat="server" MaxLength="8"
                                    onkeypress="return notn(event)" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="168"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_SLNO" runat="server" MaxLength="10"
                                    onkeypress="return  NOTNSLNO(event)" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="169"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise_IGST('LEVY_CP_CESS_NOTN_IGST',document.getElementById('txtCTHNO').value); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_RATE" runat="server" MaxLength="10"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small"
                                    ClientIDMode="Static" TabIndex="170"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_SPL" runat="server" MaxLength="10"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="171"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_UNIT" runat="server" MaxLength="3"
                                    ClientIDMode="Static" onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);"
                                    CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="172"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('IGST_LEVY_COMPENSATION_CESS_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <%--  <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_IGST_LEVY_COMPENSATION_CESS_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server">
                                </asp:DropDownList>
                            </div>--%>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth" style="margin-bottom:15px;">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                EXCEMPTION C.P. NOTN No</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="173"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" TabIndex="174"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('LEVY_EXC_CP_CESS_NOTN'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="175"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                                   <div id="txtcon-m_transaction_item_maindet">
                                <asp:DropDownList ID="ddl_LEVY_EXCEPTION_CC_NOTN_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn" Width="110px"  TabIndex="175">
                                     <asp:ListItem Value="G" Text="GSTN Notn"></asp:ListItem>
                                    <asp:ListItem  Value="C" Text="Customs Notn"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    
                        <fieldset style="border:gray;border-style:hidden; width:100px;  margin-bottom:10px;">
                <legend style="border:Black;border-collapse: collapse; width:165px; font-weight:bold;" > S/W Manufacture Details </legend>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="height:40px; width:653px;margin-top:5px; ">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Cus. Notn exempting Cen. excise flag
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Cus_not_exe_Cen_flag" runat="server" 
                                onkeyup="autotab(this);"  MaxLength="1"  TabIndex="176"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                        </div>
                      
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                            Manufctr/Producer
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_producer"  onkeyup="autotab(this);" 
                                MaxLength="1"  TabIndex="177" Enabled="false"
                                ClientIDMode="Static" runat="server" 
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="height:40px; width:683px;">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                             Manufacturer/Producer/Grower code
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manu_produ_grower_code" runat="server" onkeyup="autotab(this);"   TabIndex="178"
                              Enabled="false"  CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17"></asp:TextBox>
                        </div>
                     
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                           Address 1
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_Add1"  onkeyup="autotab(this);"
                                ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="70"  TabIndex="179" ></asp:TextBox>
                                
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:683px;" >
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Address 2
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_Add2" runat="server" onkeyup="autotab(this);" MaxLength="50"  TabIndex="180"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                        </div>
                        
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                            City                             
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_City"  onkeyup="autotab(this);" MaxLength="35"  TabIndex="181"
                                ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:683px;">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Country Subdivision 
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manu_Country_Subdiv" runat="server" onkeyup="autotab(this);" MaxLength="35"  TabIndex="182"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                        </div>
                      
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                            Pincode
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_pincode"  onkeyup="autotab(this);" MaxLength="10" Onkeypress="return num1(event)"
                                TabIndex="183" ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:683px;">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Country
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_Country" runat="server"  MaxLength="20"  TabIndex="184"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                        </div>
                      
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                            Source Country
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manu_Source_Country"  MaxLength="20"  TabIndex="185"
                                ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:683px;">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Transit Country
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_manu_Transit_Country" runat="server"  MaxLength="20"  TabIndex="186"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                        </div>
                      
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                            Accessory Status 
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                           <%-- <asp:TextBox ID="txt_Accessory_status"  onkeyup="autotab(this);" MaxLength="1"  TabIndex="130"
                                ClientIDMode="Static" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" onkeypress="return pin(event);" ></asp:TextBox>
                                --%>

                                <asp:DropDownList ID="ddl_Accesory_status" runat="server" TabIndex="187">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>

                                </asp:DropDownList>
                        </div>
                    </div>

                     </fieldset>


                </div>
                <%-- <div class="content" id="page-9" style="display: none;">
                    <iframe name="trans_item_licence" scrolling="no" id="Trans_product_Singlewindow_iframe">
                    </iframe>
                </div>--%>
                <div class="content" id="page-5">
                    <iframe name="trans_item_licence" scrolling="no" id="Trans_product_Singlewindow_iframe" style ="width:745px; height:400px; margin-left: -15px; margin-top: -42px;">
                    </iframe>
                </div>


            </div>

            <div id="innerbox_MidMain_bot_Product">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            Visible="False" CssClass="new" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide')"
                            TabIndex="190" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" Visible="False" CssClass="save" OnClick="btnSave_Click"
                            OnClientClick="return validate_Product();" TabIndex="188" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Visible="False" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate_Product();" TabIndex="188" />
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
    
});return false;" TabIndex="189" />
                        <asp:Button ID="btn" runat="server" TabIndex="189" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                        <asp:HiddenField ID="txtCountryCode" runat="server" />
                    </div>
                    <div id="editbu">

                      <asp:Button ID="btnCancel" runat="server" class="scancel" onClientClick="RefreshParent();return false;"
                        TabIndex="189" CausesValidation="false"
                        UseSubmitBehavior="false"/>

                </div>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static"/>

                <asp:HiddenField ID="HiddenField2" runat="server" Value="1" />
                 <asp:HiddenField ID="hdn_companyID" runat="server" />
                 <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
                  <asp:HiddenField ID="hdn_Inner_tab_Menu" runat="server"  ClientIDMode="Static"/>
            </div>
            </div>

         <%--   <div id="innerbox_MidMain_bot_Product">
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

                </div>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static"/>

                <asp:HiddenField ID="HiddenField2" runat="server" Value="1" />
            </div>
            </div>--%>

          <%-- </div>--%>
           
             
             
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
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
        activatables('page', ['page1', 'page2', 'page3','page-4','page-5']);
    </script>

    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtEndUse').focus(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtEndUse').change(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtEndUse').keyup(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtEndUse').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });

        function Item_desc(val) {

            var data = val;

            if (data == '') {
                $('#txtEndUse').val('');
            }
            if (data.indexOf("-") != -1) {

                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtEndUse').val(before);
                $('#hdn_txtEndUse').val(after);

            }
            else {

            }
        }
  </script>

   <script type="text/javascript">
       $(document).ready(function () {
           $('#txt_Manufacturer_Country').focus(function () {

               var data = $(this).val();
               country(data);

           });
           $('#txt_Manufacturer_Country').change(function () {

               var data = $(this).val();
               country(data);

           });
           $('#txt_Manufacturer_Country').keyup(function () {

               var data = $(this).val();
               country(data);

           });
           $('#txt_Manufacturer_Country').keydown(function () {

               var data = $(this).val();
               country(data);

           });
       });

       function country(val) {

           var data = val;

           if (data == '') {
               $('#txt_Manufacturer_Country').val('');
           }
           if (data.indexOf("-") != -1) {

               var s = data.split('-');

               var before = s[0];
               var after = s[1];

               $('#txt_Manufacturer_Country').val(after);
//               $('#hdn_txtEndUse').val(after);

           }
           else {

           }
       }
    </script>
     <script type="text/javascript">
         $(document).ready(function () {
             // document.onkeydown = clickRadio;
             document.onkeypress = click_TABS;
             document.onkeyup = click_TABS;

             function click_TABS(e) {
                 //if (window.event);
                 if (window.event.ctrlKey)
                     var keyCode = window.event.keyCode;       // IE

                 else
                     var keyCode = e.which;
                 var cnt = 0;

                 //alert(e.ctrlKey);
                 if (e.ctrlKey) {
                     if (keyCode == 39) {
                         //document.getElementById("hdn_source").value = 'Tab_Invoice';

                         if (document.getElementById("hdn_Inner_tab_Menu").value == '') {
                             document.getElementById("hdn_Inner_tab_Menu").value = 'ItemMain';
                             cnt = cnt + 1;
                         }
                         else {
                             cnt = cnt + 1;
                         }

                         //alert(cnt + 'CNT');
                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'ItemMain') {
                             if (cnt == 1) {
                                 document.getElementById('General').click();
                                 cnt = cnt + 1;
                                 //alert(cnt + 'IMD');
                             }
                         }
                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'General') {
                             if (cnt == 1) {
                                 document.getElementById('CTH').click();
                                 cnt = cnt + 1;
                             }
                         }
                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'CTH') {
                             if (cnt == 1) {
                                 document.getElementById('CETH').click();
                                 cnt = cnt + 1;
                             }
                         }
                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'CETH') {
                             if (cnt == 1) {
                                 document.getElementById('IGST').click();
                                 cnt = cnt + 1;
                             }
                         }
                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'IGST') {
                             if (cnt == 1) {
                                 document.getElementById('Other_Duty').click();
                                 cnt = cnt + 1;
                             }
                         }
                     }

                     if (keyCode == 37) {

                         cnt = cnt + 1;

                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'ItemMain') {
                             if (cnt == 1) {
                                 document.getElementById("hdn_source").value = 'Tab_Item_Prev';
                                 document.getElementById('btnCancel').click();
                                 cnt = cnt + 1;
                             }
                         }

                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'Other_Duty') {
                             if (cnt == 1) {
                                 document.getElementById('IGST').click();
                                 cnt = cnt + 1;
                             }
                         }

                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'IGST') {
                             if (cnt == 1) {
                                 document.getElementById('CETH').click();
                                 cnt = cnt + 1;
                             }
                         }

                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'CETH') {
                             if (cnt == 1) {
                                 document.getElementById('CTH').click();
                                 cnt = cnt + 1;
                             }
                         }

                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'CTH') {
                             if (cnt == 1) {
                                 document.getElementById('General').click();
                                 cnt = cnt + 1;
                             }
                         }

                         if (document.getElementById("hdn_Inner_tab_Menu").value == 'General') {
                             if (cnt == 1) {
                                 document.getElementById('ItemMain').click();
                                 cnt = cnt + 1;
                             }
                         }
                     }
                 }
             }
         });
    </script>
  <script type="text/javascript">
      function tab_p1(val) {
          document.getElementById("page-1").style.display = 'Block';
          document.getElementById("page-2").style.display = 'none';
          document.getElementById("page-3").style.display = 'none';
          document.getElementById("page-4").style.display = 'none';
          document.getElementById("page-5").style.display = 'none';

          document.getElementById("Tab1_Basic").className = 'active';
          document.getElementById("Tab2_CETH").className = 'inactive';
          document.getElementById("Tab3_Genearal").className = 'inactive';
          document.getElementById("IGST").className = 'inactive';
          document.getElementById("SINGLE_WINDOW").className = 'inactive';

          var buttons = document.querySelectorAll('#innerbox_adcode_bot_inn #editbu');
          buttons.forEach(function (div) {
              div.style.display = 'block';
          });
          document.getElementById("newbu").style.display = 'block';
    
      }

      function tab_p2(val) {
          document.getElementById("page-1").style.display = 'none';
          document.getElementById("page-2").style.display = 'Block';
          document.getElementById("page-3").style.display = 'none';
          document.getElementById("page-4").style.display = 'none';
          document.getElementById("page-5").style.display = 'none';

          document.getElementById("Tab1_Basic").className = 'inactive';
          document.getElementById("Tab2_CETH").className = 'active';
          document.getElementById("Tab3_Genearal").className = 'inactive';
          document.getElementById("IGST").className = 'inactive';
          document.getElementById("SINGLE_WINDOW").className = 'inactive';

          var buttons = document.querySelectorAll('#innerbox_adcode_bot_inn #editbu');
          buttons.forEach(function (div) {
              div.style.display = 'block';
          });
          document.getElementById("newbu").style.display = 'block';
      }
      function tab_p3(val) {
          document.getElementById("page-1").style.display = 'none';
          document.getElementById("page-2").style.display = 'none';
          document.getElementById("page-3").style.display = 'Block';
          document.getElementById("page-4").style.display = 'none';
          document.getElementById("page-5").style.display = 'none';

          document.getElementById("Tab1_Basic").className = 'inactive';
          document.getElementById("Tab2_CETH").className = 'inactive';
          document.getElementById("Tab3_Genearal").className = 'active';
          document.getElementById("IGST").className = 'inactive';
          document.getElementById("SINGLE_WINDOW").className = 'inactive';

          var buttons = document.querySelectorAll('#innerbox_adcode_bot_inn #editbu');
          buttons.forEach(function (div) {
              div.style.display = 'block';
          });
          document.getElementById("newbu").style.display = 'block';
      }

      function tab_p4(val) {
          document.getElementById("page-1").style.display = 'none';
          document.getElementById("page-2").style.display = 'none';
          document.getElementById("page-3").style.display = 'none';
          document.getElementById("page-4").style.display = 'Block';
          document.getElementById("page-5").style.display = 'none';

          document.getElementById("Tab1_Basic").className = 'inactive';
          document.getElementById("Tab2_CETH").className = 'inactive';
          document.getElementById("Tab3_Genearal").className = 'inactive';
          document.getElementById("IGST").className = 'active';
          document.getElementById("SINGLE_WINDOW").className = 'inactive';

          var buttons = document.querySelectorAll('#innerbox_adcode_bot_inn #editbu');
          buttons.forEach(function (div) {
              div.style.display = 'block';
          });
          document.getElementById("newbu").style.display = 'block';
      }

      function tab_p5(val) {
          document.getElementById("page-1").style.display = 'none';
          document.getElementById("page-2").style.display = 'none';
          document.getElementById("page-3").style.display = 'none';
          document.getElementById("page-4").style.display = 'none';
          document.getElementById("page-5").style.display = 'Block';
          document.getElementById('hdn_Inner_tab_Menu').value = 'SINGLE_WINDOW';

          document.getElementById("Tab1_Basic").className = 'inactive';
          document.getElementById("Tab2_CETH").className = 'inactive';
          document.getElementById("Tab3_Genearal").className = 'inactive';
          document.getElementById("IGST").className = 'inactive';
          document.getElementById("SINGLE_WINDOW").className = 'active';

          document.getElementById("Trans_product_Singlewindow_iframe").src = "../eRoyalMasters/Item_SingleWindow_Master.aspx";

          var buttons = document.querySelectorAll('#innerbox_adcode_bot_inn #editbu');
          buttons.forEach(function (div) {
              div.style.display = 'none';
          });

           document.getElementById("newbu").style.display = 'none';
      }

 </script>


<script type="text/javascript">

    $(function () {

        $("#txtImporter_Name").autocomplete({

            source: function (request, response) {
                var field = $(this.element).attr('id');
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List",
                    data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            if (field == 'txtImporter_Name') {
                                jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Client Name', 'error', 'topRight', true);
                            }
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

</script>



  
</body>
</html>
