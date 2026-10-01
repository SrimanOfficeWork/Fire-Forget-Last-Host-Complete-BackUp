<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_CaterPillar_Master.aspx.cs"
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
    <div class="loading" align="center" id="load" style="display: none;">
        <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
    </div>
    <div id="innerbox_MidMain_popup_Product" style="height:170px; margin-left:-0px ">
        <div id="innerbox_MidMain_top_Product" style="width: 756px;">
            IMPORT CATERPILLAR - MASTER
            <div id="popupwindow_closebut_right">
                <input type="close" value="Submit" class="clsicon" onclick="RefreshParent();return false;" />
            </div>
        </div>
        <div id="pop_tabs_area1_prod_master">
                    <div id="pop_max_text_area_prod_master_New">
                        <div id="pop_text_area_prod_master_lft" style="width: 650px;">
                            <div id="tag_label_adcode">
                        Importer Name
                    </div>
                    <div id="txtcon-Promas1" style="width: 210px;">
                               <asp:TextBox ID="txtImporterName" runat="server" MaxLength="50" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"
                                             Font-Bold="true" ClientIDMode="Static" TabIndex="1" Width="200px"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                              <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporterDetails_New('PDFSETTINGMASTER'); return false">
                                                </a>            
                            </div>               
                                      
                      
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="tag_label_adcode" style="width: 20px;">
                                Br.
                            </div>
                            <div id="txtcon-m_Date" style="width: 70px;">
                           
                                <asp:TextBox ID="txtBranchNo" runat="server"  MaxLength="3" 
                                    CssClass="txtbox_none_Promas3" TabIndex="2"></asp:TextBox>
                            </div>
                            <div id="tag_label_adcode" style="width: 50px;">
                                IEC No
                            </div>
                            <div id="txtcon-m_Date" style="width: 20px;">
                                <asp:TextBox ID="txtIECNo" runat="server" CssClass="txtbox_none_Date" onkeypress="return numchar(event)" MaxLength="15" TabIndex="3"></asp:TextBox>
                            </div>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                         <div id="pop_text_area_prod_master_lft" style="width: 650px; margin-top: 5px; margin-bottom:15px;">
                            <div id="tag_label_adcode">
                                Part NO
                            </div>
                            <div id="txtcon-m_Date"  style="width: 80px;">
                                <asp:TextBox ID="txtCommon_Part_No" runat="server" CssClass="txtbox_none_Date"
                                MaxLength="20" onkeypress="return numchar(event)" ClientIDMode="Static" Height="16px"
                                TabIndex="4"></asp:TextBox>
                            </div>
                            <div id="txtcon_Promas1_empty">
                        </div>                       
                       <div id="txtcon_Promas1_empty"></div>

                            <div id="tag_label_adcode" style="width: 60px;margin-left: 35px;"> 
                                AD Code
                            </div>
                            <div id="txtcon-m_Date">
                                <asp:TextBox ID="txt_ADCode" runat="server" onkeypress="return numchar(event)" MaxLength="15"
                                    CssClass="txtbox_none_Date" TabIndex="5"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>                            
                           
                        </div>
                        <div id="Div13">
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="pop_max_text_area_prod_master">
                            <div id="tag_label_product_new" style="margin-left:-10px">
                                Product</div>
                            <div id="txtcon-Mid_Maxtxt">
                                <asp:TextBox ID="txtDescription" runat="server" onblur="updateTextbox()" onkeypress="DisableSpecialKeyEvents(); checkTextAreaMaxLength_CompanyWise(this,event);"
                                    onchange="updateTextbox()" onkeyup="updateTextbox" TextMode="MultiLine" onkeyDown="return (event.keyCode!=13);"
                                    onpaste="return checkTextAreaMaxLength_CompanyWise(this,event);" CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                    TabIndex="7" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>

 

    <div id="pop_tabs_menu_prod_master" style="height: 400px; width: 98%">
        <ol id="toc_new">                  
                
                  <li><a href="#page1" onclick="tab_page1();" id="Basic Custom Duty"><span>Basic Custom Duty</span></a></li>
                    <li><a href="#page2" onclick="tab_page2();" id="Central Excise Duties"><span>Central Excise Duties</span></a></li>
                    <li><a href="#page3" onclick="tab_page3();" id="ADD & Generic Description"><span>ADD & Generic Description</span></a></li>
                    <li><a href="#page-4" onclick="tab_page4();" id="IGST & Manufacturer"><span>IGST & Manufacturer</span></a></li>  
                    <li><a href="#page5" onclick="tab_page5();" id="Other Details"><span>Other Details</span></a></li>          
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
                        TabIndex="8"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="magnify_area">
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCTH('CTH'); return false"
                        class="magnfy"></a>
                </div>
                <div id="tag_label_Promasnew2">
                    RITC No
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas1">
                    <asp:TextBox ID="txtRITCNO" runat="server" CssClass="txtbox_none_Promas1 validate[required,custom[integer],minSize[8]]"
                        MaxLength="8" onkeypress="return num5(event)" ClientIDMode="Static" Height="16px"
                        TabIndex="9"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="magnify_area">
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCTH(); return false"
                        class="magnfy"></a>
                </div>
                <div id="tag_label_transaction_popup_trans_cth_label2">
                    <asp:Label ID="lblCTH_Rate" runat="server" Text=""></asp:Label> %
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
                        class="magnfy"></a>
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
                    <asp:TextBox ID="txtBasicSPL" CssClass="txtbox_none_Promas2" runat="server" onkeyup="return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                        TabIndex="13"></asp:TextBox>
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
                        class="magnfy"></a>
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
                    <asp:TextBox ID="txtAddlDuty_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                        Enabled="false" MaxLength="8" TabIndex="16" onkeypress="return notn(event)" Text="019/2006"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas2">
                    <asp:TextBox ID="txtAddlDuty_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                        Enabled="false" MaxLength="10" TabIndex="17" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="magnify_area">
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Proudct_Addl_duty'); return false"
                        class="magnfy"></a>
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas3">
                    <asp:TextBox ID="txtAddlDuty_Rate" CssClass="txtbox_none_Promas3" runat="server"
                        Enabled="false" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                        TabIndex="18"></asp:TextBox>
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
                        MaxLength="8" TabIndex="19" onkeypress="return notn(event)" Enabled="false"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas2">
                    <asp:TextBox ID="txtEdu_Cess_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                        MaxLength="10" TabIndex="20" onkeypress="return NOTNSLNO(event)" Enabled="false"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas3">
                    <asp:TextBox ID="txtEdu_Cess_Rate" CssClass="txtbox_none_Promas3" runat="server"
                        onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                        TabIndex="21" Enabled="false"></asp:TextBox>
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
                        MaxLength="8" TabIndex="22" onkeypress="return notn(event)" Enabled="false"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas2">
                    <asp:TextBox ID="txtSec_Edu_Cess_NOTN_SL" CssClass="txtbox_none_Promas2" runat="server"
                        MaxLength="10" TabIndex="23" onkeypress="return NOTNSLNO(event)" Enabled="false"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
               
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas3">
                    <asp:TextBox ID="txtSec_Edu_Cess_Rate" CssClass="txtbox_none_Promas3" runat="server"
                        onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                        TabIndex="24" Height="16px" Enabled="false"></asp:TextBox>
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
                    <asp:TextBox ID="txtNCD_NOTN" CssClass="txtbox_none_Promas1" runat="server" MaxLength="8"
                        Enabled="true" TabIndex="28" onkeypress="return notn(event)"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas2">
                    <asp:TextBox ID="txtNCD_SLNO" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                        Enabled="true" TabIndex="29" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
               
                <div id="magnify_area">
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('NCD'); return false"
                        class="magnfy"></a>
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas3">
                    <asp:TextBox ID="txtNCD_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);"
                        Enabled="true" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                        TabIndex="30"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_s_label">
                    %</div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas2">
                    <asp:TextBox ID="txtNCD_SPL" CssClass="txtbox_none_Promas2" runat="server" onblur="extractNumber(this,6,false);"
                        Enabled="true" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                        TabIndex="31"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas3">
                    <asp:TextBox ID="txtNCD_UNIT" CssClass="txtbox_none_Promas3" runat="server" MaxLength="3"
                        Enabled="true" onblur="ChangeCase(this);" onkeypress="return cha(event)" ClientIDMode="Static"
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
                    <asp:DropDownList ID="ddlNCD_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server"
                        Enabled="true" TabIndex="33">
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
                        class="magnfy"></a>
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas3">
                    <asp:TextBox ID="txtAggregate_RATE" CssClass="txtbox_none_Promas3" runat="server"
                        onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                        TabIndex="36"></asp:TextBox>
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
                        MaxLength="8" TabIndex="37" onkeypress="return notn(event)"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas2">
                    <asp:TextBox ID="txtSafeguard_SL" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                        TabIndex="38" onkeypress="return NOTNSLNO(event)"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="magnify_area">
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('SafeGuard_Duty'); return false"
                        class="magnfy"></a>
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas3">
                    <asp:TextBox ID="txtSafeguard_RATE" CssClass="txtbox_none_Promas3" runat="server"
                        onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                        TabIndex="39"></asp:TextBox>
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
                        TabIndex="40"></asp:TextBox>
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
                        TabIndex="41"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="magnify_area">
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Safeguard_UNIT'); return false"
                        class="magnfy"></a>
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-m_transaction_item_gen_notn_list1">
                    <asp:DropDownList ID="ddlSafeguard_SPL_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn"
                        TabIndex="42">
                    </asp:DropDownList>
                </div>
                <asp:HiddenField ID="hdn_Update_Product" runat="server" />
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <div id="txtcon-r_src">
                </div>
            </div>
            <div id="pop_text_area_Size2_Promaster">
                <div id="tag_label_transaction_popup_trans_cth_label" style="width: 150px;">
                    SAPTA Notn
                </div>
                <div id="txtcon-m_transaction_item_maindet">
                    <asp:TextBox ID="txtSAPTA_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                        CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="43"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="txtcon-m_transaction_item_CTH_small">
                    <asp:TextBox ID="txtSAPTA_NOTN_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                        CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="44"></asp:TextBox>
                </div>
                <div id="magnify_area">
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Prouduct_Aggregate_Duty'); return false"
                        class="magnfy"></a>
                </div>
                <div id="txtcon-m_transaction_item_CTH_small">
                    <asp:TextBox ID="txtSAPTA_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                        onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                        CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                        TabIndex="45"></asp:TextBox>
                </div>
            </div>
            <div id="pop_text_area_Size2_Promaster">
                <div id="tag_label_transaction_popup_trans_cth_label" style="width: 150px;">
                    Tariff Value
                </div>
                <div id="txtcon-m_transaction_item_maindet">
                    <asp:TextBox ID="txtTariff_NOTN" runat="server" MaxLength="10" onkeypress="return notn(event)"
                        CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="46"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="txtcon-m_transaction_item_CTH_small">
                    <asp:TextBox ID="txtTariff_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                        CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="47"></asp:TextBox>
                </div>
                <div id="magnify_area">
                </div>
                <div id="tag_label_transaction_popup_trans_cth_label_tariff">
                    Qty
                </div>
                <div id="txtcon-m_transaction_item_maindet">
                    <asp:TextBox ID="txtTariff_Qty" runat="server" MaxLength="17" onblur="extractNumber(this,6,false);"
                        onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                        CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="48"></asp:TextBox>
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
                        TabIndex="49"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="txtcon-m_transaction_item_CTH_small">
                    <asp:TextBox ID="txtTariff_Amount_unitCode" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                        MaxLength="3" onkeyup="ChangeCase(this);autotab(this);" TabIndex="50"></asp:TextBox>
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
                <div id="txtcon-m_transaction_item_maindet">
                    <asp:TextBox ID="txt_AIDC_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                        CssClass="validate[required] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                        TabIndex="51"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas2">
                    <%--<asp:TextBox ID="txt_AIDC_NOTN_SLNO" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                        CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                        TabIndex="52"></asp:TextBox>--%>
                      
                                <asp:TextBox ID="txt_AIDC_NOTN_SLNO" runat="server" MaxLength="10"  onchange="aa();" onkeypress="return NOTNSLNO(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="52" ></asp:TextBox>
                         
                </div>
                <div id="txtcon-r_src">
                </div>
              
                 <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupAIDC('AIDC',document.getElementById('txtCountryOrigin').value); return false"
                                    class="magnfy"></a>
                            </div>
                            
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas3">
                    <asp:TextBox ID="txt_AIDC_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);a();"
                        onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);a();"
                        CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_CTH_small"
                        ClientIDMode="Static" TabIndex="53"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_s_label">
                    % </div>
            </div>
  
        </div>
        <div class="content" id="page2" >
            <div id="pop_text_area_transac_popup_inn_container_left_trans_item_ceth">
                <div id="tag_transac_lft_Trans_item_Cth">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        CETH No
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtCETH_No" runat="server" MaxLength="8" CssClass="validate[required,custom[integer],minSize[8]] txtbox_none_Promas1_Mediam"
                            TabIndex="54" onkeypress="return num5(event)"></asp:TextBox>
                    </div>
                    <div id="txtcon_Promas1_empty">
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCETH('CETH_NO'); return false"
                            class="magnfy" tabindex="55"></a>
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
                            MaxLength="8" TabIndex="56"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_CVD_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                            runat="server" MaxLength="10" TabIndex="57" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('CVD'); return false"
                            class="magnfy" tabindex="58"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_CVD_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);"
                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            MaxLength="10" TabIndex="59"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_CVD_SPL" CssClass="txtbox_none_Promas2" onblur="extractNumber(this,6,false);"
                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            runat="server" MaxLength="10" TabIndex="60"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_CVD_UNIT" CssClass="txtbox_none_Promas3" runat="server" MaxLength="3"
                            ClientIDMode="Static" TabIndex="61" onblur="ChangeCase(this);" onkeypress="return cha(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('CVD_UNIT'); return false"
                            class="magnfy" tabindex="62"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_gen_notn_list1">
                        <asp:DropDownList ID="ddlCVD_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            TabIndex="63">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_item_Cth" style="display: none;">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Education Cess
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_CVD_Education_CESS_Rate" CssClass="validate[required,custom[number]] txtbox_none_Promas2"
                            runat="server" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                            TabIndex="64"></asp:TextBox>
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
                            TabIndex="65"></asp:TextBox>
                    </div>
                </div>
          
                <div id="tag_transac_lft_Trans_item_Cth_Sec_hi" style="margin-top: 15px">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Addl. Duty (Sub-Section)</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Addl5_SIA_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                            MaxLength="8" TabIndex="66" onkeypress="return notn(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl5_SIA_NOTN_SL" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                            ClientIDMode="Static" onkeypress="return  NOTNSLNO(event)" TabIndex="67"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Duty'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl5_SIA_RATE" CssClass="txtbox_none_Promas3" runat="server"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                            TabIndex="68"></asp:TextBox>
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
                            MaxLength="8" TabIndex="69" onkeypress="return notn(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_GSI_SL" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                            runat="server" MaxLength="70" TabIndex="70" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Duty_GSI'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_GSI_RATE" CssClass="txtbox_none_Promas3" runat="server"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                            TabIndex="71"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Addl_GSI_SPL" CssClass="txtbox_none_Promas2" runat="server"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                            TabIndex="72"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_GSI_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                            MaxLength="3" ClientIDMode="Static" TabIndex="73" onblur="ChangeCase(this);"
                            onkeypress="return cha(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_GSI_UNIT');return false"
                            class="magnfy"  TabIndex="74"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_gen_notn_list1">
                        <asp:DropDownList ID="ddl_Addl_GSI_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn"
                            runat="server" TabIndex="75">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Spl. Exice Duty (Sched-11)
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Addl_SHE11_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                            MaxLength="8" TabIndex="76" onkeypress="return notn(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_SHE11_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                            runat="server" MaxLength="10" TabIndex="77" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_She11_Notn'); return false"
                            class="magnfy" TabIndex="78"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_SHE11_RATE" CssClass="txtbox_none_Promas3" runat="server"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                            TabIndex="79"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Addl_SHE11_SPL" CssClass="txtbox_none_Promas2" runat="server"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                            TabIndex="80"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_SHE11_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                            MaxLength="3" ClientIDMode="Static" TabIndex="81" onblur="ChangeCase(this);"
                            onkeypress="return cha(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_SHE11_UNIT'); return false"
                            class="magnfy" TabIndex="82" ></a>
                    </div>
                    <div id="txtcon-m_transaction_item_gen_notn_list1">
                        <asp:DropDownList ID="ddl_Addl_SHE11_Type" CssClass="listtxt_transac_item_gen_notn"
                            runat="server" TabIndex="83">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Addl Duty of Excise (TTA)</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Addl_TTA_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                            MaxLength="8" TabIndex="84" onkeypress="return notn(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_TTA_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                            runat="server" MaxLength="10" TabIndex="85" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_TTA_Notn'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_TTA_RATE" CssClass="txtbox_none_Promas3" runat="server"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                            TabIndex="86"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Addl_TTA_SPL" CssClass="txtbox_none_Promas2" runat="server"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                            TabIndex="87"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_TTA_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                            MaxLength="3" ClientIDMode="Static" TabIndex="88" onblur="ChangeCase(this);"
                            onkeypress="return cha(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_TTA_UNIT'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_gen_notn_list1">
                        <asp:DropDownList ID="ddl_Addl_TTA_Type" runat="server" CssClass="listtxt_transac_item_gen_notn"
                            TabIndex="89">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_item_Cth">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Health Cess
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Addl_Health_CESS_NOTN" CssClass="txtbox_none_Promas1" runat="server"
                            MaxLength="8" TabIndex="90" onkeypress="return notn(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_Health_CESS_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                            runat="server" MaxLength="10" TabIndex="91" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Health_Cess'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_Health_CESS_RATE" CssClass="txtbox_none_Promas3" runat="server"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                            TabIndex="92"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_Addl_Health_CESS_SPL" CssClass="txtbox_none_Promas2" runat="server"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="10"
                            TabIndex="93"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_Addl_Health_CESS_UNIT" CssClass="txtbox_none_Promas3" runat="server"
                            MaxLength="3" ClientIDMode="Static" TabIndex="94" onblur="ChangeCase(this);"
                            onkeypress="return cha(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_Health_CESS_UNIT'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_gen_notn_list1">
                        <asp:DropDownList ID="ddl_Addl_Health_CESS_Type" CssClass="listtxt_transac_item_gen_notn"
                            runat="server" TabIndex="95">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_item_Cth">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Cess &amp; Notification
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_CESS_NOTN" CssClass="txtbox_none_Promas1" runat="server" MaxLength="8"
                            TabIndex="96" onkeypress="return notn(event)"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_CESS_SLNO" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                            runat="server" MaxLength="10" TabIndex="97" onkeypress="return  NOTNSLNO(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Cess_Notn'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_CESS_RATE" CssClass="txtbox_none_Promas3" runat="server" onblur="extractNumber(this,6,false);"
                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            MaxLength="10" TabIndex="98"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_CESS_SPL" CssClass="txtbox_none_Promas2" runat="server" MaxLength="10"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="99"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_CESS_UNIT" CssClass="txtbox_none_Promas3" runat="server" MaxLength="3"
                            ClientIDMode="Static" TabIndex="100" onblur="ChangeCase(this);" onkeypress="return cha(event)"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('CESS_UNIT'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_gen_notn_list1">
                        <asp:DropDownList ID="ddl_CESS_Type" CssClass="listtxt_transac_item_gen_notn" runat="server"
                            TabIndex="101">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_item_Cth">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Other Duty
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txtOther_Duty_Notn" runat="server" onkeypress="return notn(event)"
                            MaxLength="8" CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                            TabIndex="102"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txtOther_Duty_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                            CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="103"></asp:TextBox>
                    </div>
                    
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txtOther_Duty_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                            TabIndex="104"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txtOther_Duty_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                            ClientIDMode="Static" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                            TabIndex="105"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txtOther_Duty_UNIT" runat="server" MaxLength="3" onkeyup="ChangeCase(this);autotab(this);"
                            onkeypress="return cha(event)" ClientIDMode="Static" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                            TabIndex="106"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('OTHER_DUTY_UNIT'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_gen_notn_list1">
                        <asp:DropDownList ID="ddlOther_Duty_Type" runat="server" CssClass="listtxt_transac_item_gen_notn"
                            TabIndex="107">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_item_Cth">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Infra Cess
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txtinfra_cess_Notn" runat="server" onkeypress="return notn(event)"
                            MaxLength="8" Enabled="True" CssClass="txtbox_none_Promas1" ClientIDMode="Static"
                            TabIndex="108"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txtinfra_cess_Notn_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                            Enabled="True" CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                            TabIndex="109"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Infra_Notn');ReadOnly return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txtinfra_cess_Notn_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                            Enabled="True" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small"
                            ClientIDMode="Static" TabIndex="110"></asp:TextBox>
                    </div>
                </div>
            
                <div id="pop_text_area_Size2_Promaster" style="display: none">
                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 150px;">
                        MRP Duty
                    </div>
                    <div id="tag_label_transaction_MIS_empty1">
                        <asp:CheckBox ID="chkMRP_Duty" runat="server" />

                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label3">
                        Sr. No. List
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txtMRP_SL_NO" runat="server" Enabled="True" MaxLength="10" onkeypress="return numchar(event)"
                            CssClass="validate[required] txtbox_none_Mid_transac_item_maindet" TabIndex="112"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label5">
                        MRP Rs/Unit
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txtMRP_AMOUNT" runat="server" Enabled="True" MaxLength="17" onblur="extractNumber(this,2,false);"
                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                            TabIndex="113"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label4">
                        Abt @ %
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txtMRP_ABT_RATE" runat="server" Enabled="True" MaxLength="17" onblur="extractNumber(this,2,false);"
                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_maindet"
                            TabIndex="114"></asp:TextBox>
                    </div>
                </div>
                <div id="pop_text_area_Size2_Promaster" style="display: none">
                    <div id="tag_label_transaction_popup_trans_cth_label" style="width: 150px;">
                        RSP Notn No
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txtRSP_Notn_No" runat="server" onkeypress="return notn(event)" CssClass="txtbox_none_Promas1"
                            TabIndex="115" MaxLength="8" Enabled="True"></asp:TextBox>
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
                            Enabled="True" CssClass="validate[custom[integer]] txtbox_none_Promas3" TabIndex="116"
                            MaxLength="3"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label4">
                        PART No
                    </div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_PartNo1" runat="server" CssClass="txtbox_none_Promas1" TabIndex="117"  onkeypress="return notn(event)"
                                    MaxLength="15"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
     
 <div class="content" id="page3" >
            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                <div id="tag_label_transaction_popup_trans_cth_label" style="width: 120px;">
                    Anti Dumping Notn
                </div>
                <div id="txtcon-m_transaction_Supp_code">
                    <asp:TextBox ID="txt_AntiDumping_Notn" runat="server" MaxLength="8" onkeypress="return notn(event)"
                        CssClass="txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static" TabIndex="118"></asp:TextBox>
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
                        ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="119"></asp:TextBox>
                </div>
            </div>
            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                <div id="tag_label_transaction_popup_trans_cth_label" style="width: 120px;">
                    CTH Sl No
                </div>
                <div id="txtcon-m_transaction_Supp_code">
                    <asp:TextBox ID="txtCTH_SL_No" runat="server" onkeyup="autotab(this);" ClientIDMode="Static"
                        CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="120" MaxLength="8"></asp:TextBox>
                </div>
                <div id="magnify_area">
                </div>
                <div id="tag_label_transaction_popup_trans_cth_label">
                    CTH Supplier SL
                </div>
                <div id="txtcon-m_transaction_Supp_code">
                    <asp:TextBox ID="txtCTH_Supplier_SL" onkeypress="return num1(event)" onkeyup="autotab(this);"
                        ClientIDMode="Static" runat="server" CssClass="validate[custom[integer]] txtbox_none_Mid_transac_Supp_Name"
                        TabIndex="121" MaxLength="8"></asp:TextBox>
                </div>
            </div>
            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                <div id="tag_label_transaction_popup_trans_cth_label" style="width: 120px;">
                    CTH Qty
                </div>
                <div id="txtcon-m_transaction_Supp_code">
                    <asp:TextBox ID="txtCTH_Qty" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                        onkeypress="return blockNonNumbers(this, event, true, false);" runat="server"
                        CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="122"
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
                            onpaste="return checkTextAreaMaxLength(this,event,'60');" TabIndex="123"></asp:TextBox>
                    </div>
                    <div id="txtcon-b_Maxtxt">
                    </div>
                </div>
                <div id="lblMsg5" style="display: none;">
                </div>
            </div>
            <div id="pop_text_area_Size2_Promaster" style="width: 750px;">
                <div id="tag_label_Promasnew4">
                    Manufacturer</div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas1_Mediam">
                    <asp:TextBox ID="txtManufacturer" runat="server" MaxLength="50" onkeypress="return numcharspl1(event)"
                        CssClass="txtbox_none_Promas1_Mediam" TabIndex="124"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="tag_label_Promasnew4" style="width: 70px;">
                    Brand</div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas1_Mediam">
                    <asp:TextBox ID="txtBrand" runat="server" onkeypress="return desc2(event)" MaxLength="20"
                        CssClass="txtbox_none_Promas1_Mediam" TabIndex="125"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <%--</div>--%>
            </div>
            <div id="pop_text_area_Size2_Promaster" style="width: 750px;">
                <div id="tag_label_Promasnew4">
                    Model</div>
                <div id="txtcon-l_src">
                </div>
                <div id="txtcon-Promas1_Mediam">
                    <asp:TextBox ID="txtModel" runat="server" onkeypress="return desc2(event)" MaxLength="20"
                        CssClass="txtbox_none_Promas1_Mediam" TabIndex="126"></asp:TextBox>
                </div>
                <div id="txtcon-r_src">
                </div>
                <div id="txtcon_Promas1_empty">
                </div>
                <div id="tag_label_Promasnew4" style="width: 70px;">
                    End Use
                </div>
                <div id="txtcon-Promas1_Mediam">
                    <asp:TextBox ID="txtEndUse" runat="server" onkeypress="return desc2(event)" MaxLength="20"
                        CssClass="txtbox_none_Promas1_Mediam" TabIndex="127"></asp:TextBox>
                </div>
                <div id="magnify_area">
                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_End_Use_Of_Itemd('End_Use'); return false"
                        class="magnfy"></a>
                </div>
            </div>
            <div id="pop_text_area_Size2_Promaster" style="width: 750px;">
                <div id="tag_label_Promasnew4">
                    Country Of Origin
                </div>
                <div id="txtcon-Promas1_Mediam">
                    <asp:TextBox ID="txtCountryName" runat="server" MaxLength="20" ClientIDMode="Static"
                        CssClass="validate[custom[onlyLetterSp]] txtbox_none_Promas1_Mediam" onkeypress="return char(event)"
                        onblur="ChangeCase(this);" TabIndex="128"></asp:TextBox>
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
                            onkeyDown="return checkTextAreaMaxLength(this,event,'120');" TabIndex="129"></asp:TextBox>
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
                            onkeyDown="return checkTextAreaMaxLength(this,event,'120');" TabIndex="130"></asp:TextBox>
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
            <div id="pop_text_area_Size2_Promaster_maxtxt" style="height: 100px">
                <div id="tag_transac_lft_Trans_item_Cth">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        LEVY NOTN No</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_IGST_LEVY_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                            CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="131"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_IGST_LEVY_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                            ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" TabIndex="132"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise_IGST('LEVY_NOTN_IGST',document.getElementById('txtCTHNO').value); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_IGST_LEVY_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                            TabIndex="133"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_IGST_LEVY_SPL_Amt" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                            TabIndex="134"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_IGST_LEVY_UNIT" runat="server" MaxLength="3" ClientIDMode="Static"
                            onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                            TabIndex="135"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('IGST_LEVY_UNIT'); return false"
                            class="magnfy"></a>
                    </div>
                    
                </div>
                <div id="tag_transac_lft_Trans_item_Cth">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        EXCEMPTION NOTN No</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                            CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="136"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                            ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" TabIndex="137"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('LEVY_EXC_NOTN'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                            TabIndex="138"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:DropDownList ID="ddl_LEVY_EXCEMPTION_NOTN_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn"
                            Width="110px" TabIndex="139">
                            <asp:ListItem Value="G" Text="GSTN Notn"></asp:ListItem>
                            <asp:ListItem Value="C" Text="Customs Notn"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_item_Cth">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        LEVY C.P. CESS NOTN No</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_NOTN" runat="server" MaxLength="8"
                            onkeypress="return notn(event)" CssClass="txtbox_none_Mid_transac_item_maindet"
                            ClientIDMode="Static" TabIndex="140"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_SLNO" runat="server" MaxLength="10"
                            onkeypress="return  NOTNSLNO(event)" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                            TabIndex="141"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise_IGST('LEVY_CP_CESS_NOTN_IGST',document.getElementById('txtCTHNO').value); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_RATE" runat="server" MaxLength="10"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small"
                            ClientIDMode="Static" TabIndex="142"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_SPL" runat="server" MaxLength="10"
                            onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                            onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                            ClientIDMode="Static" TabIndex="143"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_UNIT" runat="server" MaxLength="3"
                            ClientIDMode="Static" onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);"
                            CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                            TabIndex="144"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('IGST_LEVY_COMPENSATION_CESS_UNIT'); return false"
                            class="magnfy"></a>
                    </div>
                    
                </div>
                <div id="tag_transac_lft_Trans_item_Cth" style="margin-bottom: 15px;">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        EXCEMPTION C.P. NOTN No</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                            CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="145"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                            ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" TabIndex="146"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('LEVY_EXC_CP_CESS_NOTN'); return false"
                            class="magnfy"></a>
                    </div>
                    <div id="txtcon-m_transaction_item_CTH_small">
                        <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                            onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                            CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                            TabIndex="147"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                        %</div>
                    <div id="txtcon-m_transaction_item_maindet">
                        <asp:DropDownList ID="ddl_LEVY_EXCEPTION_CC_NOTN_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn"
                            Width="110px" TabIndex="148">
                            <asp:ListItem Value="G" Text="GSTN Notn"></asp:ListItem>
                            <asp:ListItem Value="C" Text="Customs Notn"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <fieldset style="border: gray; border-style: hidden; width: 100px; margin-bottom: 10px;">
                <legend style="border: Black; border-collapse: collapse; width: 165px; font-weight: bold;">
                    S/W Manufacture Details </legend>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="height: 40px; width: 653px;
                    margin-top: 5px;">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Cus. Notn exempting Cen. excise flag
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Cus_not_exe_Cen_flag" runat="server" onkeyup="autotab(this);"
                            MaxLength="1" TabIndex="149" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_transaction_popup_gen">
                        Manufctr/Producer
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Manufacturer_producer" onkeyup="autotab(this);" MaxLength="1"
                            TabIndex="150" Enabled="false" ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="height: 40px; width: 683px;">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Manufacturer/Producer/Grower code
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Manu_produ_grower_code" runat="server" onkeyup="autotab(this);"
                            TabIndex="151" Enabled="false" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_transaction_popup_gen">
                        Address 1
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Manufacturer_Add1" onkeyup="autotab(this);" ClientIDMode="Static"
                            runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="70" TabIndex="152"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Address 2
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Manufacturer_Add2" runat="server" onkeyup="autotab(this);" MaxLength="50"
                            TabIndex="153" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_transaction_popup_gen">
                        City
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Manufacturer_City" onkeyup="autotab(this);" MaxLength="35" TabIndex="154"
                            ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Country Subdivision
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Manu_Country_Subdiv" runat="server" onkeyup="autotab(this);"
                            MaxLength="35" TabIndex="155" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_transaction_popup_gen">
                        Pincode
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Manufacturer_pincode" onkeyup="autotab(this);" MaxLength="10"
                            Onkeypress="return num1(event)" TabIndex="156" ClientIDMode="Static" runat="server"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Country
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Manufacturer_Country" runat="server" MaxLength="20" TabIndex="157"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_transaction_popup_gen">
                        Source Country
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_Manu_Source_Country" MaxLength="20" TabIndex="158" ClientIDMode="Static"
                            runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                    <div id="tag_label_transaction_popup_trans_cth_label">
                        Transit Country
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txt_manu_Transit_Country" runat="server" MaxLength="20" TabIndex="159"
                            CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                    </div>
                    <div id="magnify_area">
                    </div>
                    <div id="tag_label_transaction_popup_gen">
                        Accessory Status
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        
                        <asp:DropDownList ID="ddl_Accesory_status" runat="server" TabIndex="160">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </fieldset>
        </div>
        <div class="content" id="page5">
        <div id="PartNo" runat="server" visible="false">
        <div id="pop_text_area_Size2_Promaster">
                <div id="tag_label_Promasnew">
                    Part No
                </div>
                <div id="txtcon-Promas1" style="width: 156px;">
                    <asp:TextBox ID="txt_PartNo" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" MaxLength="20" onkeypress="return numchar(event)" TabIndex="161"></asp:TextBox>
                </div>
            </div>
            </div>
             <div id="PartName" runat="server" visible="false">
            <div id="pop_text_area_Size2_Promaster">
                <div id="tag_label_Promasnew">
                    Part Name
                </div>
                <div id="txtcon-Promas1" style="width: 156px;">                   
                  <asp:TextBox ID="txt_PartName" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" onkeypress="return numchar(event)"
                                            ClientIDMode="Static" MaxLength="35" TabIndex="162"></asp:TextBox>

                </div>
            </div>
            </div>
            <div id="TaxBenifitYN" runat="server" visible="false">
            <div id="pop_text_area_Size2_Promaster">
                <div id="tag_label_Promasnew">
                    Tax Benifit Y/N
                </div>
                <div id="txtcon-m_transaction_list1_yn">
                    <asp:DropDownList ID="ddl_Tax_Benifit_YN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                        TabIndex="163">
                        <asp:ListItem>YES</asp:ListItem>
                        <asp:ListItem>NO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            </div>
            <div id="TaxBenifitPerc" runat="server" visible="false">
            <div id="pop_text_area_Size2_Promaster">
                <div id="tag_label_Promasnew">
                    Tax Benifit %
                </div>
                <div id="txtcon-Promas1" style="width: 156px;">                    
                        <asp:TextBox ID="txt_Tax_Benifit_Perc" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                        ClientIDMode="Static" MaxLength="20" onkeypress="return numchar(event)" TabIndex="164"></asp:TextBox>
                </div>
            </div>
            </div>
            <div id="EPANotifi" runat="server" visible="false">
            <div id="pop_text_area_Size2_Promaster" style="width: 700px;">
                <div id="tag_label_Promasnew">
                    EPA Notification
                </div>
                <div id="txtcon-Promas1">                    
                        <asp:TextBox ID="txt_EPA_Notifi" onkeyup="autotab(this);" ClientIDMode="Static"
                                        runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"  TabIndex="165"></asp:TextBox>
                </div>
            </div>
            </div>
            <div id="SIMAYN" runat="server" visible="false">
            <div id="pop_text_area_Size2_Promaster" style="width: 700px;">
                <div id="tag_label_Promasnew">
                    SIMS YES/No
                </div>
                <div id="txtcon-m_transaction_list1_yn">
                    <asp:DropDownList ID="ddl_SIMS_YN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                        TabIndex="166">
                        <asp:ListItem>YES</asp:ListItem>
                        <asp:ListItem>NO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            </div>
            <div id="FTAYN" runat="server" visible="false">
            <div id="pop_text_area_Size2_Promaster" style="width: 700px;">
                <div id="tag_label_Promasnew">
                    FTA YES/No
                </div>
                <div id="tag_label_Promasnew">
                    <asp:DropDownList ID="ddl_FTA_YN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                        TabIndex="167">
                        <asp:ListItem>YES</asp:ListItem>
                        <asp:ListItem>NO</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            </div>
            <div id="CEFAImplDate" runat="server" visible="false">
          <div id="pop_text_area_Size2_Promaster" style="width: 700px;" >
                <div id="tag_label_Promasnew">
                   CEPA Impl date
                </div>
               <div id="tag_label_Promasnew">
                         
                            <asp:TextBox ID="txt_DT_CEPA" runat="server" MaxLength="2" Onkeypress="return char2(event);"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="173"></asp:TextBox>                        
                                  <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_DT_CEPA"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_DT_CEPA"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>
                                </div>
            </div>
            </div>
        </div>
        </div>
       
    </div>
    </div>
 
    <div id="innerbox_MidMain_bot_Product">
        <div id="innerbox_adcode_bot_inn">
            <div id="newbu">
                <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                    Visible="False" CssClass="new" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide')"
                    TabIndex="178" />
            </div>
            <div id="editbu">
                <asp:Button ID="btnSave" runat="server" Visible="False" CssClass="save" OnClick="btnSave_Click"
                    OnClientClick="return validate_Product();" TabIndex="179" />
            </div>
            <div id="editbu">
                <asp:Button ID="btnUpdate" runat="server" Visible="False" CssClass="updates" OnClick="btnUpdate_Click"
                    OnClientClick="return validate_Product();" TabIndex="180" />
            </div>
            <div id="editbu">
                <asp:Button ID="btnDelete" runat="server" Visible="False" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'PRODUCT SETTING MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" TabIndex="181" />
                <asp:Button ID="btn" runat="server" TabIndex="181" OnClick="btnDelete_Click" CssClass="dlete"
                    Style="display: none;" />
                <asp:HiddenField ID="txtCountryCode" runat="server" />
            </div>
            <div id="editbu">
                <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="RefreshParent();return false;"
                    TabIndex="182" CausesValidation="false" UseSubmitBehavior="false" />
            </div>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="HiddenField2" runat="server" Value="1" />
            <asp:HiddenField ID="hdn_companyID" runat="server" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
        </div>
    </div>
    
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
    <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page1', 'page2', 'page3', 'page-4', 'page5']);
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

             $('#txt_Addl_GSI_NOTN').focus(function () {

                 var data1 = $(this).val();
                 if (data1 == '011/2006') {

                     $('#txt_Addl_GSI_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_GSI_RATE').val('');
                 }

             });
             $('#txt_Addl_GSI_NOTN').change(function () {

                 var data1 = $(this).val();
                 if (data1 == '011/2006') {

                     $('#txt_Addl_GSI_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_GSI_RATE').val('');
                 }
             });
             $('#txt_Addl_GSI_NOTN').keyup(function () {

                 var data1 = $(this).val();
                 if (data1 == '011/2006') {

                     $('#txt_Addl_GSI_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_GSI_RATE').val('');
                 }


             });
             $('#txt_Addl_GSI_NOTN').keydown(function () {

                 var data1 = $(this).val();
                 if (data1 == '011/2006') {

                     $('#txt_Addl_GSI_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_GSI_RATE').val('');
                 }

             });
             //---------------------------------------------------------------------------
             $('#txt_Addl_SHE11_NOTN').focus(function () {

                 var data1 = $(this).val();
                 if (data1 == '009/2006') {

                     $('#txt_Addl_SHE11_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_SHE11_RATE').val('');
                 }

             });
             $('#txt_Addl_SHE11_NOTN').change(function () {

                 var data1 = $(this).val();
                 if (data1 == '009/2006') {

                     $('#txt_Addl_SHE11_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_SHE11_RATE').val('');
                 }
             });
             $('#txt_Addl_SHE11_NOTN').keyup(function () {

                 var data1 = $(this).val();
                 if (data1 == '009/2006') {

                     $('#txt_Addl_SHE11_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_SHE11_RATE').val('');
                 }


             });
             $('#txt_Addl_SHE11_NOTN').keydown(function () {

                 var data1 = $(this).val();
                 if (data1 == '009/2006') {

                     $('#txt_Addl_SHE11_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_SHE11_RATE').val('');
                 }

             });
             //---------------------------------------------------------------------------
             $('#txt_Addl_TTA_NOTN').focus(function () {

                 var data1 = $(this).val();
                 if (data1 == '031/2004') {

                     $('#txt_Addl_TTA_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_TTA_RATE').val('');
                 }

             });
             $('#txt_Addl_TTA_NOTN').change(function () {

                 var data1 = $(this).val();
                 if (data1 == '031/2004') {

                     $('#txt_Addl_TTA_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_TTA_RATE').val('');
                 }
             });
             $('#txt_Addl_TTA_NOTN').keyup(function () {

                 var data1 = $(this).val();
                 if (data1 == '031/2004') {

                     $('#txt_Addl_TTA_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_TTA_RATE').val('');
                 }
             });
             $('#txt_Addl_TTA_NOTN').keydown(function () {

                 var data1 = $(this).val();
                 if (data1 == '031/2004') {

                     $('#txt_Addl_TTA_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_TTA_RATE').val('');
                 }
             });
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
               function aa() {
                   var notnSlnoValue = document.getElementById("txt_AIDC_NOTN_SLNO").value;

                   if (notnSlnoValue !== "") {
                       document.getElementById("txt_AIDC_RATE").value = "0.00";
                   }
               }



    </script>
 
      <script type="text/javascript">

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
          $(function () {
              $("#txt_AIDC_NOTN_SLNO").autocomplete({
                  source: function (request, response) {
                      var field = $(this.element).attr('id');
                      var RITC = document.getElementById("txtCTHNO").value;
                      var Flag = 'AIDC_NOTN_SLNO';
                      var Row_N = 'AIDC_NOTN_SLNO';
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
                                  if (field == 'txt_AIDC_NOTN_SLNO') {
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
       $(document).ready(function () {
           $('#txtImporterName').focus(function () {

               var data = $(this).val();
               Item_exp_name(data);

           });
           $('#txtImporterName').change(function () {

               var data = $(this).val();
               Item_exp_name(data);

           });
           $('#txtImporterName').keyup(function () {

               var data = $(this).val();
               Item_exp_name(data);

           });
           $('#txtImporterName').keydown(function () {

               var data = $(this).val();
               Item_exp_name(data);

           });
           $('#txtImporterName').focusout(function () {

               var data = $(this).val();
               Item_exp_name(data);

           });
       });

       function Item_exp_name(val) {

           var data = val;
           if (data == '') {
               $('#txtImporterName').val('');
           }
           if (data.indexOf("--") != -1) {

               var s = data.split('--');

               var before = s[0];
               var after = s[1];

               $('#txtImporterName').val(after);
               $('#txtBranchNo').val(before);
           }
           else {

           }
       }
       $(function () {
           $("#txtImporterName").autocomplete({

               source: function (request, response) {
                   $.ajax({
                       url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD",
                       data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "'}",
                       dataType: "json",
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       dataFilter: function (data) { return data; },
                       async: true,
                       success: function (data) {

                           response(data.d);
                           if (data.d == '') {
                               jQuery('#txtImporterName').validationEngine('showPrompt', 'Incorrect ImporterName', 'error', 'topRight', true);
                           }
                           else {
                               jQuery('#txtImporterName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


       function CallServerside_Importer_STD(src) {
              var ctrl = document.getElementById(src);        
              // call server side method
              PageMethods.GetImporter_2(ctrl.value, 'Importer', CallSuccess_Importer_ChkBind, CallFailed);

          }
       // calling Importer

       // set the destination textbox value with the ContactName
       function CallSuccess_Importer(res, destCtrl, code) {

           var dest = document.getElementById(destCtrl);
           //dest.value = res;
           var data = res;
           if (data.indexOf("~~") != -1) {

               var s = data.split('~~');

               var before = s[0];
               var after1 = s[1];
               var after2 = s[2];


               document.getElementById("txt_IECNo").value = before;
               //document.getElementById("txtBranchNo").value = after1;
               document.getElementById("txt_ADCode").value = after2;

           }
           else {
               document.getElementById("txt_IECNo").value = "";
               //document.getElementById("txtBranchNo").value = "";
               document.getElementById("txt_ADCode").value = "";
           }
       }
    </script>
</body>
</html>
