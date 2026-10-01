<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product_PDF_Reader_Import_Master.aspx.cs"
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
                    PRODUCT MASTER PDF READER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="RefreshParent();return false;" />
                    </div>
                </div>
                <div id="pop_tabs_area1_prod_master">
                    <div id="pop_max_text_area_prod_master_New">
                    <div id="pop_text_area_prod_master_lft" style="width: 600px; height: 25px;">
                            <div id="tag_label_adcode">
                                Importer Name
                            </div>
                            <div id="txtcon-m_Date" style="width: 210px;">
                                 <asp:TextBox ID="txtImporterName" runat="server" MaxLength="50" onblur="C_Importer_2();ChangeCase(this);" Font-Bold="true"
                                                ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="1" Width="200px"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                              <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('Importer'); return false">
                                                </a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="tag_label_adcode" style="width: 20px;">
                                Br.
                            </div>
                            <div id="txtcon-m_Date" style="width: 70px;">
                           
                                <asp:TextBox ID="txtBranchNo1" runat="server" ClientIDMode="Static" onkeypress="return pin(event)" MaxLength="3"
                                    CssClass="txtbox_none_Promas3" TabIndex="2"></asp:TextBox>


                                    
                            </div>
                            <div id="tag_label_adcode" style="width: 50px;">
                                IEC No
                            </div>
                            <div id="txtcon-m_Date" style="width: 20px;">
                                <asp:TextBox ID="txtIECNo1" runat="server" ClientIDMode="Static" onkeypress="return pin(event)" MaxLength="10"
                                    CssClass="txtbox_none_Date" TabIndex="3"></asp:TextBox>
                            </div>
                        </div>

                        <div id="pop_max_text_area_prod_master">
                            <div id="tag_label_product_new">
                                Product</div>
                            <div id="txtcon-Mid_Maxtxt">
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

                                    <asp:TextBox ID="txtDescription" runat="server"  onblur="updateTextbox()" onkeypress="DisableSpecialKeyEvents(); checkTextAreaMaxLength_CompanyWise(this,event);"
                                         onchange="updateTextbox()" onkeyup="updateTextbox" TextMode="MultiLine" onkeyDown="return (event.keyCode!=13);" 
                                         onpaste="return checkTextAreaMaxLength_CompanyWise(this,event);"  CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                        TabIndex="4" ClientIDMode="Static"></asp:TextBox>

                            </div>
                        </div>
                        <div id="pop_text_area_prod_master_lft" style="width:650px; margin-top:5px; height: 25px;">
                            <div id="tag_label_adcode">
                                Material Code
                            </div>
                            <div id="txtcon-m_Date">
                                <asp:TextBox ID="txtMaterialCode" runat="server" onkeypress="return numchar(event)"
                                    MaxLength="15" CssClass="txtbox_none_Date" TabIndex="5"></asp:TextBox>
                            </div>
                            <div id="txtcon_Promas1_empty"></div>
                             <%--<div id="tag_label_adcode">
                                Importer Name
                            </div>
                            <div id="txtcon-m_Date"  style="width:250px;">
                                <asp:TextBox ID="txtImporter_Name" runat="server" ClientIDMode="Static" Width="250px"
                                    MaxLength="15" CssClass="txtbox_none_Date" TabIndex="2"></asp:TextBox>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
                

            <div id="pop_tabs_menu_prod_master" style="height: 382px;">
                <ol id="toc_new">
                    <li><a href="#page1" onclick="tab1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab1_Basic"><span>Basic Custom Duty</span></a> </li>
                    <li><a href="#page2" onclick="tab_CETH('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab2_CETH"><span>Central Excise Duties</span></a></li>  
                    <li><a href="#page3" onclick="tab_General('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab3_Genearal"><span>ADD & Generic Description</span></a></li>
                         <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll'); tab_IGST('0');"
                        id="IGST"><span>IGST & Manufacturer</span></a></li>
                </ol>
                <div class="content" id="page1">
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            CTH No
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                            <asp:TextBox ID="txtCTH_No" runat="server" MaxLength="8" ClientIDMode="Static" onkeypress="return num5(event)"
                                CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Promas1"
                                TabIndex="6"></asp:TextBox>
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
                                TabIndex="7"></asp:TextBox>
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

                               <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 75px;">
                                 Qty code
                             </div>
                           <%--  <div id="txtcon-m_transaction_item_maindet">
                                 <asp:TextBox ID="txt_Info_Uqc" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp] txtbox_none_Mid_transac_item_maindet"
                                     ClientIDMode="Static" Onkeypress="return char1(event)" onkeyup="return ChangeCase(this);"
                                     TabIndex="10" MaxLength="3"></asp:TextBox>
                             </div>--%>
                             <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtQtyCode" MaxLength="3" Onkeypress="return char1(event)" runat="server"
                                    CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_item_maindet"
                                    onkeyup="return ChangeCase(this);" ClientIDMode="Static" TabIndex="9"></asp:TextBox>
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
                                ClientIDMode="Static" TabIndex="10" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtBasicSLNO" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                                ClientIDMode="Static" TabIndex="11" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
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
                                onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="12"></asp:TextBox>
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
                                MaxLength="10" TabIndex="13"></asp:TextBox>
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
                                TabIndex="14"></asp:TextBox>
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
                                TabIndex="15">
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
                                MaxLength="8" TabIndex="16" onkeypress="return notn(event)" Text="019/2006"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtAddlDuty_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server" Enabled="false"
                                MaxLength="10" TabIndex="17" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
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
                               MaxLength="10" TabIndex="18"></asp:TextBox>
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
                                MaxLength="8" TabIndex="19" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtEdu_Cess_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                                MaxLength="10" TabIndex="20" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
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
                                TabIndex="24" Height="16px"></asp:TextBox>
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
                                MaxLength="8" TabIndex="25" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txt_Social_Welfare_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                                MaxLength="10" TabIndex="26" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
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
                                TabIndex="27" Height="16px"></asp:TextBox>
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
                                TabIndex="28" onkeypress="return notn(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas2">
                            <asp:TextBox ID="txtNCD_SLNO" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10" Enabled="false"
                                TabIndex="29" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('NCD');ReadOnly return false"
                                class="magnfy" tabindex="25"></a>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas3">
                            <asp:TextBox ID="txtNCD_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);" Enabled="false"
                                onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                MaxLength="10" TabIndex="30"></asp:TextBox>
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
                                MaxLength="10" TabIndex="31"></asp:TextBox>
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
                                TabIndex="32"></asp:TextBox>
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
                                TabIndex="40"></asp:TextBox>
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
                                TabIndex="41"></asp:TextBox>
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
                                TabIndex="42"></asp:TextBox>
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
                                TabIndex="43">
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
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="44"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSAPTA_NOTN_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="45"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Prouduct_Aggregate_Duty'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSAPTA_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="46"></asp:TextBox>
                            </div>
                        </div>

                       <div id="pop_text_area_Size2_Promaster">
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width:150px;">
                                Tariff Value
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtTariff_NOTN" runat="server" MaxLength="10" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="47"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtTariff_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="48"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label_tariff">
                                Qty
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtTariff_Qty" runat="server" MaxLength="17" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="49"></asp:TextBox>
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
                                    TabIndex="50"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtTariff_Amount_unitCode" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    MaxLength="3" onkeyup="ChangeCase(this);autotab(this);" TabIndex="51"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Tariff_Amount_Code'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>


                        <div id="pop_text_area_Size2_Promaster" style="height:25px">
                        <div id="tag_label_Promasnew">
                            AID Cess
                        </div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-Promas1">
                             <asp:TextBox ID="txt_AIDC_NOTN" runat="server" MaxLength="8"  onkeypress="return notn(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="52" ></asp:TextBox>
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
                                    TabIndex="53" ></asp:TextBox>
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
                                    TabIndex="54"></asp:TextBox>
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



                          <div id="tag_transac_lft_trans_item_maindet_in1_" >

                             <div id="tag_label_transaction_export_Item_otherdet_new1" style="width:148px;">
                                 Info MSR
                             </div>
                             <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 85px;">
                                 <asp:TextBox ID="txt_Info_Msr" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                 onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);"
                                     Width="70px" TabIndex="55" MaxLength="28"></asp:TextBox>
                             </div>
                             <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 75px;">
                                 Info UQC
                             </div>
                             <div id="txtcon-m_transaction_item_maindet">
                                 <asp:TextBox ID="txt_Info_Uqc" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp] txtbox_none_Mid_transac_item_maindet"
                                     ClientIDMode="Static" Onkeypress="return char1(event)" onkeyup="return ChangeCase(this);"
                                     TabIndex="56" MaxLength="3"></asp:TextBox>
                             </div>
                         </div>

                </div>

                <div class="content" id="page2" style="display: none;">
                    <div id="pop_text_area_transac_popup_inn_container_left_trans_item_ceth">
                        <div id="tag_transac_lft_Trans_item_Cth" >
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                CETH No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtCETH_No" runat="server" MaxLength="8" CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Promas1_Mediam"
                                    TabIndex="51" onkeypress="return num5(event)"></asp:TextBox>
                            </div>
                            <div id="txtcon_Promas1_empty">
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCETH('CETH_NO'); return false"
                                    class="magnfy" tabindex="52"></a>
                                    
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
                                    MaxLength="8" TabIndex="53"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CVD_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="54" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('CVD'); return false"
                                    class="magnfy" tabindex="55"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CVD_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="10" TabIndex="56"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CVD_SPL" CssClass="txtbox_none_Promas2" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    runat="server" MaxLength="10" TabIndex="57"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CVD_UNIT" CssClass="txtbox_none_Promas3" runat="server" MaxLength="3"
                                    ClientIDMode="Static" TabIndex="58" onblur="ChangeCase(this);" onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('CVD_UNIT'); return false"
                                    class="magnfy" tabindex="15"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddlCVD_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                    TabIndex="59">
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
                                    TabIndex="60"></asp:TextBox>
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
                                    TabIndex="61"></asp:TextBox>
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
                                    MaxLength="8" TabIndex="62" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl5_SIA_NOTN_SL" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    ClientIDMode="Static" onkeypress="return  NOTNSLNO(event)" TabIndex="63"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Duty'); return false"
                                    class="magnfy" ></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl5_SIA_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="64"></asp:TextBox>
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
                                    MaxLength="8" TabIndex="65" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_SL" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="66" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Duty_GSI'); return false"
                                    class="magnfy" ></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="67"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_GSI_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="68"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="69" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_GSI_UNIT');return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_GSI_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="70">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Spl. Exice Duty (Sched-11)
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_SHE11_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="71" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="72" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_She11_Notn'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="73"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_SHE11_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="74"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="75" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_SHE11_UNIT'); return false"
                                    class="magnfy" ></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_SHE11_Type" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="76">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Addl Duty of Excise (TTA)</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_TTA_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="77" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="78" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_TTA_Notn'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="79"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_TTA_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="80"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="81" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_TTA_UNIT'); return false"
                                    class="magnfy" ></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_TTA_Type" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                    TabIndex="82">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Health Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_Health_CESS_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                                    MaxLength="8" TabIndex="83" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="84" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Health_Cess'); return false"
                                  class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_RATE" CssClass="txtbox_none_Promas3" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="85"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_Health_CESS_SPL" CssClass="txtbox_none_Promas2" runat="server"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                                    TabIndex="86"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                                    MaxLength="3" ClientIDMode="Static" TabIndex="87" onblur="ChangeCase(this);"
                                    onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_Health_CESS_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_Health_CESS_Type" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="88">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Cess &amp; Notification
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CESS_NOTN" CssClass="txtbox_none_Promas1" runat="server" MaxLength="8"
                                    TabIndex="84" onkeypress="return notn(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    runat="server" MaxLength="10" TabIndex="85" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Cess_Notn'); return false"
                                  class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="10" TabIndex="86"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CESS_SPL" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="87"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_UNIT" CssClass="txtbox_none_Promas3" runat="server" MaxLength="3"
                                    ClientIDMode="Static" TabIndex="88" onblur="ChangeCase(this);" onkeypress="return cha(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('CESS_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_CESS_Type" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                    TabIndex="89">
                                </asp:DropDownList>
                            </div>
                        </div>


                          <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Other Duty
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtOther_Duty_Notn" runat="server" onkeypress="return notn(event)" MaxLength="8"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="90" style="Width:79px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width: 20px;">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtOther_Duty_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="91"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                             
                               <%--<a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Cess_Notn'); return false"
                                    class="magnfy"></a>--%>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtOther_Duty_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="92"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtOther_Duty_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);" ClientIDMode="Static"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" TabIndex="93" style="width: 60px;"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtOther_Duty_UNIT" runat="server" MaxLength="3" onkeyup="ChangeCase(this);autotab(this);"
                                    onkeypress="return cha(event)" ClientIDMode="Static" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="94"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('OTHER_DUTY_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddlOther_Duty_Type" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                    TabIndex="95">
                                </asp:DropDownList>
                            </div>
                        </div> 

                           <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Infra Cess          
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtinfra_cess_Notn" runat="server" onkeypress="return notn(event)" MaxLength="8" Enabled="false"
                                    CssClass="txtbox_none_Promas1" ClientIDMode="Static" TabIndex="96"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtinfra_cess_Notn_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)" Enabled="false"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="97"></asp:TextBox>
                            </div>
                               <div id="magnify_area">
                                   <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Infra_Notn');ReadOnly return false"
                                       class="magnfy"></a>
                               </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtinfra_cess_Notn_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);" Enabled="false"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="98"></asp:TextBox>
                            </div>
                       
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                               PART NO
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_PartNo" runat="server" CssClass="txtbox_none_Promas1" TabIndex="99"
                                    MaxLength="15"></asp:TextBox>
                            </div>
                        </div>

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
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_maindet" TabIndex="100"></asp:TextBox>
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
                                    TabIndex="101"></asp:TextBox>
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
                                    TabIndex="101"></asp:TextBox>
                            </div>
                        </div>

                        <div id="pop_text_area_Size2_Promaster" style="display: none">
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width: 150px;">
                                RSP Notn No
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtRSP_Notn_No" runat="server" onkeypress="return notn(event)" CssClass="txtbox_none_Promas1"
                                    TabIndex="102" MaxLength="8" Enabled="False"></asp:TextBox>
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
                                    Enabled="False" CssClass="validate[custom[integer]] txtbox_none_Promas3" TabIndex="103"
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
                <%--<div id="pop_text_area_Size2_Promaster">
                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 150px;">
                        RSP Notn No
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_PartNo" runat="server" CssClass="txtbox_none_Promas1" TabIndex="102"
                            MaxLength="15"></asp:TextBox>
                    </div>
                </div>--%>



                <%--   <div class="content" id="page3">
                   
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" >
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Anti Dumping Notn /
                        </div>
                        <div id="txtcon-m_Date">
                            <asp:DropDownList ID="ddlAntiDumping_Notn" runat="server" CssClass="listtxt_transac_Item_Schemecode"
                                TabIndex="114">
                            </asp:DropDownList>
                            <asp:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="SCHEME_IMPORT_CODE"
                                TargetControlID="ddlAntiDumping_Notn_SL" ParentControlID="ddlAntiDumping_Notn"
                                LoadingText="Loading..." ServiceMethod="BindAntidropdown" ServicePath="~/Scheme_Notn_Dropdown_pages/DropdownWebService.asmx">
                            </asp:CascadingDropDown>
                        </div>
                        
                          <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Anti Dumping Notn Sl
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:DropDownList ID="ddlAntiDumping_Notn_SL" runat="server" CssClass="listtxt_transac_Item_Schemecode"
                                TabIndex="115">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            CTH Sl No
                        </div>
                        <div id="txtcon-m_Date">
                            <asp:TextBox ID="txtCTH_SL_No" runat="server" onkeyup="autotab(this);" ClientIDMode="Static"
                                CssClass="validate[custom[integer]] txtbox_none_Date" TabIndex="116"
                                MaxLength="8"></asp:TextBox>
                        </div>
                      
                        <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            CTH Supplier SL
                        </div>
                        <div id="txtcon-m_Date">
                            <asp:TextBox ID="txtCTH_Supplier_SL" onkeypress="return num1(event)" onkeyup="autotab(this);"
                                ClientIDMode="Static" runat="server" CssClass="validate[custom[integer]] txtbox_none_Date"
                                TabIndex="117" MaxLength="8"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            CTH Qty
                        </div>
                        <div id="txtcon-m_Date">
                            <asp:TextBox ID="txtCTH_Qty" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" runat="server"
                                CssClass="validate[custom[number]] txtbox_none_Date" TabIndex="118"
                                MaxLength="12"></asp:TextBox>
                        </div>
                    </div>
                </div>--%>

                <div class="content" id="page3" style="display: none;">

                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                        <div id="tag_label_transaction_popup_trans_cth_label" style="width:120px;">
                            Anti Dumping Notn
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_AntiDumping_Notn" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static" TabIndex="104"></asp:TextBox>
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
                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="105"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                        <div id="tag_label_transaction_popup_trans_cth_label"  style="width:120px;">
                            CTH Sl No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCTH_SL_No" runat="server" onkeyup="autotab(this);" ClientIDMode="Static"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="106"
                                MaxLength="8"></asp:TextBox>
                        </div>
                      
                        <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            CTH Supplier SL
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCTH_Supplier_SL" onkeypress="return num1(event)" onkeyup="autotab(this);"
                                ClientIDMode="Static" runat="server" CssClass="validate[custom[integer]] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="107" MaxLength="8"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                        <div id="tag_label_transaction_popup_trans_cth_label"  style="width:120px;">
                            CTH Qty
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCTH_Qty" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" runat="server"
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="108"
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
                                    onpaste="return checkTextAreaMaxLength(this,event,'60');" TabIndex="109"></asp:TextBox>
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
                                CssClass="txtbox_none_Promas1_Mediam" TabIndex="110"></asp:TextBox>
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
                                CssClass="txtbox_none_Promas1_Mediam" TabIndex="111"></asp:TextBox>
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
                                CssClass="txtbox_none_Promas1_Mediam" TabIndex="112"></asp:TextBox>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                    <div id="txtcon_Promas1_empty"></div>
                        <div id="tag_label_Promasnew4" style="width:70px;">
                            End Use
                        </div>
                        <div id="txtcon-Promas1_Mediam">
                            <asp:TextBox ID="txtEndUse" runat="server" onkeypress="return desc2(event)" MaxLength="20"
                                CssClass="txtbox_none_Promas1_Mediam" TabIndex="113"></asp:TextBox>
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
                                onkeypress="return char(event)" onblur="ChangeCase(this);" TabIndex="114"></asp:TextBox>
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
                                    onkeyDown="return checkTextAreaMaxLength(this,event,'120');" TabIndex="115"></asp:TextBox>
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
                                    onkeyDown="return checkTextAreaMaxLength(this,event,'120');" TabIndex="116"></asp:TextBox>
                            </div>
                            <div id="txtcon-b_Maxtxt">
                            </div>
                        </div>
                        <div id="lblMsg4" style="display: none;">
                        </div>
                    </div>
                    </div>
                <%--</div>--%>

                <div class="content" id="page-4">
                    <div id="pop_text_area_Size2_Promaster_maxtxt" style="height:100px">

                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                LEVY NOTN No</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="117"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" TabIndex="118"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise_IGST('LEVY_NOTN_IGST',document.getElementById('txtCTHNO').value); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="119"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_SPL_Amt" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="120"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_UNIT" runat="server" MaxLength="3" ClientIDMode="Static"
                                    onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="121"></asp:TextBox>
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
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="122"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" TabIndex="123"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('LEVY_EXC_NOTN'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="124"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:DropDownList ID="ddl_LEVY_EXCEMPTION_NOTN_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn" Width="110px"  TabIndex="125">
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
                                    ClientIDMode="Static" TabIndex="126"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_SLNO" runat="server" MaxLength="10"
                                    onkeypress="return  NOTNSLNO(event)" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="127"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise_IGST('LEVY_CP_CESS_NOTN_IGST',document.getElementById('txtCTHNO').value); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_RATE" runat="server" MaxLength="10"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small"
                                    ClientIDMode="Static" TabIndex="128"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_SPL" runat="server" MaxLength="10"
                                    onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="129"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_UNIT" runat="server" MaxLength="3"
                                    ClientIDMode="Static" onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);"
                                    CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="130"></asp:TextBox>
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
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="131"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" TabIndex="132"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('LEVY_EXC_CP_CESS_NOTN'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="133"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                                   <div id="txtcon-m_transaction_item_maindet">
                                <asp:DropDownList ID="ddl_LEVY_EXCEPTION_CC_NOTN_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn" Width="134px"  TabIndex="175">
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
                                onkeyup="autotab(this);"  MaxLength="1"  TabIndex="135"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                        </div>
                      
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                            Manufctr/Producer
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_producer"  onkeyup="autotab(this);" 
                                MaxLength="1"  TabIndex="136" Enabled="false"
                                ClientIDMode="Static" runat="server" 
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="height:40px; width:683px;">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                             Manufacturer/Producer/Grower code
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manu_produ_grower_code" runat="server" onkeyup="autotab(this);"   TabIndex="137"
                              Enabled="false"  CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17"></asp:TextBox>
                        </div>
                     
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                           Address 1
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_Add1"  onkeyup="autotab(this);"
                                ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="70"  TabIndex="138" ></asp:TextBox>
                                
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:683px;" >
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Address 2
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_Add2" runat="server" onkeyup="autotab(this);" MaxLength="50"  TabIndex="139"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                        </div>
                        
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                            City                             
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_City"  onkeyup="autotab(this);" MaxLength="35"  TabIndex="140"
                                ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:683px;">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Country Subdivision 
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manu_Country_Subdiv" runat="server" onkeyup="autotab(this);" MaxLength="35"  TabIndex="141"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                        </div>
                      
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                            Pincode
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_pincode"  onkeyup="autotab(this);" MaxLength="10" Onkeypress="return num1(event)"
                                TabIndex="142" ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:683px;">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Country
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manufacturer_Country" runat="server"  MaxLength="20"  TabIndex="143"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                        </div>
                      
                         <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_gen">
                            Source Country
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_Manu_Source_Country"  MaxLength="20"  TabIndex="144"
                                ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" ></asp:TextBox>
                                
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:683px;">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Transit Country
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_manu_Transit_Country" runat="server"  MaxLength="20"  TabIndex="145"
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

                                <asp:DropDownList ID="ddl_Accesory_status" runat="server" TabIndex="146">
                                <asp:ListItem>0</asp:ListItem>
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>

                                </asp:DropDownList>
                        </div>
                    </div>

                     </fieldset>


                </div>

            </div>

            <div id="innerbox_MidMain_bot_Product">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            Visible="False" CssClass="new" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide')"
                            TabIndex="149" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" Visible="False" CssClass="save" OnClick="btnSave_Click"
                            OnClientClick="return validate_Product();" TabIndex="147" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Visible="False" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate_Product();" TabIndex="147" />
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
    
});return false;" TabIndex="148" />
                        <asp:Button ID="btn" runat="server" TabIndex="148" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                        <asp:HiddenField ID="txtCountryCode" runat="server" />
                    </div>
                    <div id="editbu">

                      <asp:Button ID="btnCancel" runat="server" class="scancel" onClientClick="RefreshParent();return false;"
                        TabIndex="150" CausesValidation="false"
                        UseSubmitBehavior="false"/>

                </div>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static"/>

                <asp:HiddenField ID="HiddenField2" runat="server" Value="1" />
                 <asp:HiddenField ID="hdn_companyID" runat="server" />
                 <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
                 <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" ClientIDMode="Static" />
                   <asp:HiddenField ID="hdimp" runat="server" />
                <asp:HiddenField ID="hd_Brslno" runat="server" />
                <asp:HiddenField ID="hdn_New_Update" runat="server" />
                <asp:HiddenField ID="hdn_New_Update1" runat="server" />
                
                
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
    <%-- <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>--%>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/product_JScript.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_Item.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page1', 'page2', 'page3','page-4']);
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

  <script type="text/javascript">
      $(document).ready(function () {
          $('#txtCTH_No').focus(function () {
              //------------------15-feb-2015-------------------------------------------------------
              PageMethods.Get_CTH_Info_Uqc(document.getElementById("txtCTH_No").value, OnSuccess_Info_Uqc);
              function OnSuccess_Info_Uqc(response, userContext, methodName) {

                  $('#txt_Info_Uqc').val(response);

                  if (document.getElementById("txtQtyCode").value == document.getElementById("txt_Info_Uqc").value) {
                      $('#txt_Info_Msr').val(document.getElementById("txtItemQty").value);
                  }
                  else {
                      //$('#txt_Info_Msr').val('');
                  }
              }
              //---------------------------------------------------------------------------
          });
          $('#txtCTH_No').change(function () {
              //------------------15-feb-2015-------------------------------------------------------
              PageMethods.Get_CTH_Info_Uqc(document.getElementById("txtCTH_No").value, OnSuccess_Info_Uqc);
              function OnSuccess_Info_Uqc(response, userContext, methodName) {

                  $('#txt_Info_Uqc').val(response);
                  if (document.getElementById("txtQtyCode").value == document.getElementById("txt_Info_Uqc").value) {
                      $('#txt_Info_Msr').val(document.getElementById("txtItemQty").value);
                  }
                  else {
                      //$('#txt_Info_Msr').val('');
                  }
              }
              //---------------------------------------------------------------------------
          });
          $('#txtCTH_No').keyup(function () {

              //------------------15-feb-2015-------------------------------------------------------
              PageMethods.Get_CTH_Info_Uqc(document.getElementById("txtCTH_No").value, OnSuccess_Info_Uqc);
              function OnSuccess_Info_Uqc(response, userContext, methodName) {

                  $('#txt_Info_Uqc').val(response);

                  if (document.getElementById("txtQtyCode").value == document.getElementById("txt_Info_Uqc").value) {
                      $('#txt_Info_Msr').val(document.getElementById("txtItemQty").value);
                  }
                  else {
                      //$('#txt_Info_Msr').val('');
                  }
              }
              //---------------------------------------------------------------------------
          });
          $('#txtCTH_No').keydown(function () {

              //------------------15-feb-2015-------------------------------------------------------
              PageMethods.Get_CTH_Info_Uqc(document.getElementById("txtCTH_No").value, OnSuccess_Info_Uqc);
              function OnSuccess_Info_Uqc(response, userContext, methodName) {

                  $('#txt_Info_Uqc').val(response);

                  if (document.getElementById("txtQtyCode").value == document.getElementById("txt_Info_Uqc").value) {
                      $('#txt_Info_Msr').val(document.getElementById("txtItemQty").value);
                  }
                  else {
                      //$('#txt_Info_Msr').val('');
                  }
              }
              //---------------------------------------------------------------------------

          });

          //-----------------------------------------------------------

      });

       </script> 


       
<script type="text/javascript">    $(function () {
        $("#txtImporterName").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD",
                    //                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById("hdfTransport_mode").value + "'}",
                    data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            jQuery('#txtImporterName').validationEngine('showPrompt', 'Incorrect ImporterName', 'error', 'topRight', true);
                            //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                            //return false;
                        }
                        else {
                            jQuery('#txtImporterName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
  <script type="text/javascript">
      $(document).ready(function () {

          $('#txtImporterName').focus(function () {
              //alert('a');
              var data = $(this).val();
              Item_desc_name(data);

          });
          $('#txtImporterName').change(function () {

              var data = $(this).val();
              Item_desc_name(data);

          });
          $('#txtImporterName').keyup(function () {

              var data = $(this).val();
              Item_desc_name(data);

          });
          $('#txtImporterName').keydown(function () {

              var data = $(this).val();
              Item_desc_name(data);

          });

      });

      function Item_desc_name(val) {

          var data = val;
          console.log(val);
          if (data == '') {
              $('#txtImporterName').val('');
          }
          if (data.indexOf("--") != -1) {

              var s = data.split('--');

              var before = s[0];
              var after = s[1];

              $('#txtImporterName').val(after);

              $('#hdimp').val(after);
              
              $('#hd_Brslno').val(before);

          }
          else {

          }
      }



     function C_Importer_2() {
  
    var ctrl = document.getElementById("txtImporterName");
    var ctrl_2 = document.getElementById("hd_Brslno");
    
     var Adcode="";
    var Jobno="";
    var dest=ctrl;
    PageMethods.GetImporter_2(ctrl.value, ctrl_2.value, Adcode, Jobno, CallSuccess_Importer_2, CallFailed, dest);
    
    

}
function CallSuccess_Importer_2(res, destCtrl) {


    var dest = document.getElementById(destCtrl);
    //dest.value = res;
    var data = res;
    if (data.indexOf("~~") != -1) {

        var s = data.split('~~');
     
        var before = s[0];
        var after1 = s[1];
        var after2 = s[2];
        var after3 = s[3];
        var after4 = s[4];
        var after5 = s[5];

        var after6 = s[6];
        var after7 = s[7];
        var after8 = s[8];
        var after9 = s[9];
        var commercialYN = s[10];
        var Imp_ADCode = s[11];

        var after12 = s[12];
        var after13 = s[13];
        var after14 = s[14];
        var after15 = s[15];
        var after16 = s[16];
        var after17 = s[17];
        var after18 = s[18];
       
       
        document.getElementById("txtIECNo1").value = after5;
        
        document.getElementById("txtBranchNo1").value = after6;
        
    }
}
  </script>
  <%--<script type="text/javascript">
      $(function () {
          $("#txt_AIDC_NOTN").autocomplete({
              source: function (request, response) {
                  var field = $(this.element).attr('id');
                  var RITC = document.getElementById("txtCTHNO").value;
                  var Flag = 'AIDC_NOTN_NO';
                  var Row_N = 'AIDC_NOTN_NO';
                  var val_A = '';
                  var val_B = '';
                  $.ajax({
                      url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AIDC_Cess_Master",
                      data: "{ 'mail': '" + request.term + "' ,'RITC':'" + RITC + "' ,'Flag':'" + Flag + "','Row_N':'" + Row_N + "','val_A':'" + val_A + "','val_B':'" + val_B + "'}",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      async: true,
                      success: function (data) {
                          response(data.d);
                          if (data.d == '') {
                              if (field == 'txt_AIDC_NOTN') {
                                  jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AIDC CessNotn', 'error', 'topRight', true);
                              }
                          }
                          else {

                              jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
  </script>
  <script type="text/javascript">
      $(function () {
          $("#txt_AIDC_NOTN_SLNO").autocomplete({
              source: function (request, response) {
                  var field = $(this.element).attr('id');
                  var RITC = document.getElementById("txtCTHNO").value;
                  var Flag = 'AIDC_NOTN_SLNO';
                  var Row_N = 'AIDC_NOTN_SLNO';
                  var val_A = document.getElementById("txt_AIDC_NOTN").value;
                  var val_B = '';

                  alert(a);
                  $.ajax({
                      url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AIDC_Cess_Master",
                      data: "{ 'mail': '" + request.term + "' ,'RITC':'" + RITC + "' ,'Flag':'" + Flag + "','Row_N':'" + Row_N + "','val_A':'" + val_A + "','val_B':'" + val_B + "'}",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      async: true,
                      success: function (data) {
                          response(data.d);
                          if (data.d == '') {
                              if (field == 'txt_AIDC_NOTN_SLNO') {
                                  jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AIDC CessNotn Slno', 'error', 'topRight', true);
                              }
                          }
                          else {

                              jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
</script>
<script type="text/javascript">
$(function () {
    $("#txt_AIDC_RATE").autocomplete({
        source: function (request, response) {
            var field = $(this.element).attr('id');
            var RITC = document.getElementById("txtCTHNO").value;
            var Flag = 'AIDC_NOTN_RATE';
            var Row_N = 'AIDC_NOTN_RATE';
            var val_A = document.getElementById("txt_AIDC_NOTN").value;
            var val_B = document.getElementById("txt_AIDC_NOTN_SLNO").value;
            $.ajax({
                url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/AIDC_Cess_Master",
                data: "{ 'mail': '" + request.term + "' ,'RITC':'" + RITC + "' ,'Flag':'" + Flag + "','Row_N':'" + Row_N + "','val_A':'" + val_A + "','val_B':'" + val_B + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataFilter: function (data) { return data; },
                async: true,
                success: function (data) {
                    response(data.d);
                    if (data.d == '') {
                        if (field == 'txt_AIDC_RATE') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect AIDC CessNotn Slno', 'error', 'topRight', true);
                        }
                    }
                    else {

                        jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
   
</script>
<script>

 function Call_AIDC_Master(src) {

        var ctrl = document.getElementById(src);
        if (ctrl.length = 8) {
            PageMethods.Get_AIDC_Notn(ctrl.value, CallSucces_AIDC, CallFailed);
        }
    }
    function CallSucces_AIDC(res, destCtrl) {
        var dest = document.getElementById(destCtrl);
        var data = res;
        if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

            var s = data.split('~~');
            var before = s[0];
            var after1 = s[1];
            var after2 = s[2];

            document.getElementById("txt_AIDC_NOTN").value = before;
            document.getElementById("txt_AIDC_NOTN_SLNO").value = after1;
            document.getElementById("txt_AIDC_RATE").value = after2;
        }
        else {
            document.getElementById("txt_AIDC_NOTN").value = '';
            document.getElementById("txt_AIDC_NOTN_SLNO").value = '';
            document.getElementById("txt_AIDC_RATE").value = '';
        }
    }

});
</script>--%>
</body>
</html>
'W\è„9s%”ï°µ—]õ*}R2„-È
Í
PÜr"ñ×Î‡¢Ñ•Ý
pòË¥$(Â„bU^–`$ŸK×U­!×6	éŒ
¹w@"¶^ì$å¡‰Ú eŠl2±ä[hÃÆcãœÁ µŽÆgg6í'ÎW”Óå]i·"Š3¸³XM â	qaûõªŸÖ]ˆ‚}k,Áµåyæp­—µ#*í6’­Ê£¦œT²J¨0sèNk^ ÎƒqdÏ¯øÎ­°ß›­
#a@úOn,¥nHRæ;Vnég¤PQXºRèÙSÙL?&uw°_×ýSHR¨
r¦ëÊå×Ã:] ?z}x‚bó] 7"JR¬UìÂ~î‰êv—é3±¶”–rvÁ•ÖòïNíâý&„Æ
@!a¹Þœ¥.EU¾r«^_CˆL
”ò+|éÍ¹#ª‘FKÆ†ÅÚ
;ˆ¤ÑŽš´•Jöé|]Ô	ýz!ÑTd]‹ëÙY¥`)“¾¨Û‹iú^5íUÒH¡”3¶›œN\ÃKWcÞk	&Þá-Ò˜iîÐJÎfŒ.‡UÓd¶ê:Š`ÄB„|áÕù4·