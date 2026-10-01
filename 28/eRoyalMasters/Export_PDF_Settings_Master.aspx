<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_PDF_Settings_Master.aspx.cs"
    Inherits="Export_PDF_Settings_Master" %>

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
            <div id="innerbox_MidMain_popup_Product" style="height:170px; ">
                <div id="innerbox_MidMain_top_Product">
                    EXPORT PDF SETTINGS - MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="RefreshParent();return false;" />
                    </div>
                </div>
                <div id="pop_tabs_area1_prod_master">
                    <div id="pop_max_text_area_prod_master_New">
                        <div id="pop_text_area_prod_master_lft" style="width: 650px;">
                            <div id="tag_label_adcode">
                                Exporter Name
                            </div>
                            <div id="txtcon-m_Date" style="width: 210px;">
                               <asp:TextBox ID="txt_IEC_ExporterName" runat="server" MaxLength="50" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Font-Bold="true" ClientIDMode="Static" TabIndex="1" Width="200px"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                              <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('Exporter'); return false">
                                                </a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="tag_label_adcode" style="width: 20px;">
                                Br.
                            </div>
                            <div id="txtcon-m_Date" style="width: 70px;">
                           
                                <asp:TextBox ID="txt_BranchNo" runat="server" onkeypress="return numchar(event)" MaxLength="3"
                                    CssClass="txtbox_none_Promas3" TabIndex="2"></asp:TextBox>
                            </div>
                            <div id="tag_label_adcode" style="width: 50px;">
                                IEC No
                            </div>
                            <div id="txtcon-m_Date" style="width: 20px;">
                                <asp:TextBox ID="txt_IECNo" runat="server" onkeypress="return numchar(event)" MaxLength="15"
                                    CssClass="txtbox_none_Date" TabIndex="2"></asp:TextBox>
                            </div>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="pop_text_area_prod_master_lft" style="width: 650px; margin-top: 5px; margin-bottom:15px;">
                            <div id="tag_label_adcode">
                                RITC No
                            </div>
                            <div id="txtcon-m_Date"  style="width: 80px;">
                                <asp:TextBox ID="txtRITCNo" runat="server" CssClass="txtbox_none_Promas1 validate[required,custom[integer],minSize[8]]"
                                MaxLength="8" onkeypress="return num5(event)" ClientIDMode="Static" Height="16px"
                                TabIndex="3"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Export_Ritc('Export_RITCNO'); return false"
                                        class="magnfy"></a>
                        </div>
                       <div id="tag_label_transaction_popup_IGM2_empty"></div>

                            <div id="tag_label_adcode" style="width: 60px;"> 
                                Part No
                            </div>
                            <div id="txtcon-m_Date">
                                <asp:TextBox ID="txt_PartNo" runat="server" onkeypress="return numchar(event)" MaxLength="15"
                                    CssClass="txtbox_none_Date" TabIndex="4"></asp:TextBox>
                            </div>
                            <div id="magnify_area"></div>

                            <div id="tag_label_adcode" style="width: 60px;"> 
                               AD Code
                            </div>
                            <div id="txtcon-m_Date">
                                <asp:TextBox ID="txt_ADCode" runat="server" onkeypress="return numchar(event)" MaxLength="15"
                                    CssClass="txtbox_none_Date" TabIndex="4"></asp:TextBox>
                            </div>
                        </div>
                        <div id="txtcon_Promas1_empty">
                        </div>
                        <div id="pop_max_text_area_prod_master">
                            <div id="tag_label_product_new" style="margin-left:-10px">
                                Item Description</div>
                            <div id="txtcon-Mid_Maxtxt">
                                <asp:TextBox ID="txtDescription" runat="server" onblur="updateTextbox()" onkeypress="DisableSpecialKeyEvents(); checkTextAreaMaxLength_CompanyWise(this,event);"
                                    onchange="updateTextbox()" onkeyup="updateTextbox" TextMode="MultiLine" onkeyDown="return (event.keyCode!=13);"
                                    onpaste="return checkTextAreaMaxLength_CompanyWise(this,event);" CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                    TabIndex="5" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        
                    </div>
                </div>
            </div>
                

            <div id="pop_tabs_menu_prod_master" style="height: 382px;">
                <ol id="toc_new">
                    <li><a href="#page1" onclick="tab1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab1_Basic"><span>Item Main Details</span></a> </li>
                    <li><a href="#page2" onclick="tab_CETH('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="Tab2_CETH"><span>Manufacturer Details</span></a></li>  
                   
                </ol>
                <div class="content" id="page1">
                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            Type of Exporter
                        </div>
                        <div id="txtcon-Promas1" style="width: 156px;">
                            <asp:DropDownList ID="ddlType_Exp" runat="server" CssClass="listtxt_transac_src1"
                                TabIndex="6" Width="150px">
                                <asp:ListItem Text="Manufacturer - ( F )" Value="F"></asp:ListItem>
                                <asp:ListItem Text="Merchant - ( R )" Value="R"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_Promasnew" style="width: 102px;">
                            Scheme Code
                        </div>
                        <div id="txtcon-Promas1" style="width: 162px;">
                            <asp:DropDownList ID="ddlSchemeCode" runat="server" CssClass="txtbox_none_Mid_transac_exp_itemnew"
                                Width="190px" TabIndex="7">
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div id="pop_text_area_Size2_Promaster" style="width:700px;">
                                <div id="tag_label_Promasnew">
                                    STR Y/N
                                </div>
                                <div id="txtcon-m_transaction_list1_yn">
                                    <asp:DropDownList ID="ddl_STR_YN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                        TabIndex="8">
                                        <asp:ListItem  Value="N">No</asp:ListItem>
                                <asp:ListItem  Value="Y">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                               
                                <div id="div_STR_YN" runat="server">
                                   <%-- <div id="tag_label_transaction_popup_Item_maindet" style="width:70px">
                                        STR Code
                                    </div>--%>
                                    <div id="txtcon-m_transaction_item_maindet">
                                        <asp:TextBox ID="txtSTRCode" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                            ClientIDMode="Static" MaxLength="4" onkeypress="return pin(event)" TabIndex="9"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');opennew_STR_DETAILS(); return false"
                                            class="magnfy"></a>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty" style="width:30px;">
                                    </div>
                                <div id="tag_label_transaction_export_Item_otherdet">
                                    Reward Points Y/N
                                </div>
                                
                                <div id="txtcon-m_transaction_list1_yn">
                                    <asp:DropDownList ID="ddlRewardPoints" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                        TabIndex="10">
                                        <asp:ListItem>Yes</asp:ListItem>
                                        <asp:ListItem>No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                
                            </div>

                    <%--<div id="pop_text_area_Size2_Promaster" style="width:660px;">
                        <div id="tag_label_Promasnew">
                            STR Y/N
                        </div>
                        <div id="div_STR_1" runat="server" style="display: block;">
                            <asp:DropDownList ID="ddl_STR_YN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                               Width="90px" TabIndex="8">
                                <asp:ListItem  Value="N">No</asp:ListItem>
                                <asp:ListItem  Value="Y">Yes</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="div_STR_YN" runat="server" style="display: none;">
                            <div id="tag_label_transaction_popup_Item_maindet" style="width: 70px">
                                STR Code
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtSTRCode" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" MaxLength="4" onkeypress="return pin(event)" TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');opennew_STR_DETAILS(); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                        <div id="tag_label_transaction_export_Item_otherdet">
                            Reward Points Y/N
                        </div>
                        <div id="txtcon-m_transaction_list1_yn">
                            <asp:DropDownList ID="ddlRewardPoints" runat="server" CssClass="listtxt_transac_exp_item_yn"
                               Width="150px"   TabIndex="10">
                                <asp:ListItem  Value="Y">Yes</asp:ListItem>
                                <asp:ListItem  Value="N">No</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>

                     <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            RODTEP(Y/N)
                        </div>
                        <div id="txtcon-Promas1" style="width: 202px;">
                            <asp:DropDownList ID="ddl_Rodtep_YN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                       Width="150px"   TabIndex="11">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                    </asp:DropDownList>
                        </div>
                        
                        <div id="tag_label_transaction_export_Item_otherdet">
                            Cess Details(Y/N)
                        </div>
                        <div id="txtcon-m_transaction_list1_yn">
                             <asp:DropDownList ID="ddl_Cess_YN" runat="server" CssClass="listtxt_transac_exp_item_yn"
                                      Width="150px"    TabIndex="12">
                                        <asp:ListItem Value="N">No</asp:ListItem>
                                        <asp:ListItem Value="Y">Yes</asp:ListItem>
                                    </asp:DropDownList>
                        </div>
                    </div>

                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            EndUse of Item
                        </div>
                        <div id="txtcon-Promas1" style="width: 106px;">
                            <asp:TextBox ID="txtEnduseItem" runat="server" MaxLength="20" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_End_Use_Of_Itemd('Exp_End_Use'); return false"
                                class="magnfy"></a>
                        </div>
                        <div id="magnify_area" style="width: 60px;">
                        </div>
                        <div id="tag_label_transaction_export_Item_otherdet">
                            Under PTA/FTA
                        </div>
                        <div id="txtcon-m_transaction_list1_yn" style="width: 145px;">
                            <asp:TextBox ID="txt_PTA_FTA" runat="server" MaxLength="200" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                ClientIDMode="Static" TabIndex="14"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');opennew_PTA_FTA_Agreement('Export_PTA_FTA'); return false"
                                class="magnfy"></a>
                        </div>
                    </div>

                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            IGST Payment Status
                        </div>
                        <div id="txtcon-Promas1" style="width: 106px;">
                            <asp:DropDownList ID="ddl_IGST_Payment" runat="server" CssClass="listtxt_transac_mode_new"
                               Width="150px"   TabIndex="15">
                                <asp:ListItem>NA</asp:ListItem>
                                <asp:ListItem Selected="True">LUT</asp:ListItem>
                                <asp:ListItem>P</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="magnify_area" style="width: 93px;">
                        </div>
                        <div id="tag_label_transaction_export_Item_otherdet" >
                            IGST Rate %
                        </div>
                        <div id="txtcon-m_transaction_list1_yn" style="width: 145px;">
                            <asp:TextBox ID="txt_IGST_Rate" runat="server" MaxLength="19" CssClass="txtbox_none_Mid_transac_code"
                                ClientIDMode="Static" TabIndex="16" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" Width="75px"></asp:TextBox>
                        </div>
                        
                    </div>


                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            Drawback Slno
                        </div>
                        <div id="txtcon-Promas1" style="width: 156px;">
                           <asp:TextBox ID="txtDrawback_SLNo" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                ClientIDMode="Static" onkeypress="return charnum2(event)" MaxLength="15" TabIndex="17"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupDrawback('EXPORT_DrawbackNo',document.getElementById('hdn_UnitCode').value); return false"
                                class="magnfy"></a>
                        </div>
                        <div id="magnify_area" style="width: 10px;">
                        </div>
                        <div id="tag_label_transaction_export_Item_otherdet" style="width: 60px;">
                            Dbk Unit
                        </div>
                        <div id="txtcon-m_transaction_list1_yn" style="width: 100px;">
                              <asp:TextBox ID="txt_DBK_Unit" runat="server" MaxLength="19" CssClass="txtbox_none_Mid_transac_code"
                                 TabIndex="18"  Width="75px"></asp:TextBox>
                        </div>
                        <div id="tag_label_Promasnew" style="width:40px;">
                           SQC
                        </div>
                           <div id="txtcon-m_transaction_list1_yn" style="width: 105px;">
                            <asp:TextBox ID="txt_UOM" runat="server" MaxLength="19" CssClass="txtbox_none_Mid_transac_code"
                              TabIndex="20"   Width="75px"></asp:TextBox>
                        </div>
                           
                    </div>

                    <div id="pop_text_area_Size2_Promaster">
                        <div id="tag_label_Promasnew">
                            Dbk Decl.
                        </div>
                        <div id="txtcon-m_transaction_list1_yn" style="width: 220px;">
                            <asp:CheckBox ID="chk_DB001" runat="server" Text="DB001" TabIndex="20" />
                            <asp:CheckBox ID="chk_DB002" runat="server" Text="DB002" TabIndex="20" />
                            <asp:CheckBox ID="chk_DB003" runat="server" Text="DB003" TabIndex="20" />
                        </div>
                          <div id="tag_label_transaction_export_Item_otherdet" style="width: 60px;">
                          <asp:Label ID="lblInfoMsr" runat="server" Text="Info MSR" Visible="false"></asp:Label>
                            <%--Info MSR--%>
                        </div>
                        <div id="txtcon-m_transaction_list1_yn" style="width: 90px;">
                          <asp:TextBox ID="txt_InfoMSR" runat="server" MaxLength="19" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                        ClientIDMode="Static" TabIndex="17" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                      onkeypress="return blockNonNumbers(this, event, true, false);"  Width="75px" Visible="false"></asp:TextBox>
                        </div>
                           <%--<div id="tag_label_transaction_export_Item_otherdet" style="width: 60px;">
                            Info UQC
                        </div>--%>
                        <div id="txtcon-m_transaction_list1_yn" style="width: 80px;">
                            <asp:TextBox ID="txt_InfoUQC" runat="server" MaxLength="19" CssClass="txtbox_none_Mid_transac_code"
                              TabIndex="20"   Width="75px" Visible="false"></asp:TextBox>
                        </div>
                      <%--  <div id="tag_label_transaction_export_Item_otherdet" style="width: 88px;">
                            SQC
                        </div>
                        <div id="txtcon-m_transaction_list1_yn" style="width: 105px;">
                            <asp:TextBox ID="txt_UOM" runat="server" MaxLength="19" CssClass="txtbox_none_Mid_transac_code"
                              TabIndex="20"   Width="75px"></asp:TextBox>
                        </div>--%>
                    </div>

                     <div id="frame2_export_item_otherdet_new1" style="width: 685px; height: 150px;">
                                <div id="tag_label_transaction_export_Item_otherdet_frmlabel_new1" style="text-align:left;">
                                    Third Party Details
                                </div>
                                

                                <div id="tag_transac_lft_trans_item_new1_maintag1">
                                <div id="tag_label_transaction_popup_Item_maindet">
                                        Exporter Name
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code" >
                                        <asp:TextBox ID="txtExporterName" runat="server" MaxLength="40" CssClass="txtbox_none_Mid_transac_Supp_Name" 
                                            ClientIDMode="Static" TabIndex="21"></asp:TextBox>
                                    </div>
                                     <div id="magnify_area">
                                        <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('Exporter_item'); return false">
                                        </a>
                                    </div>
                                    <div id="tag_label_transaction_popup_mode_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_Item_maindet" style="width:70px">
                                        IEC Code
                                    </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtIECCode" runat="server" CssClass="validate[minSize[10]] txtbox_none_Mid_transac_code"
                                            ClientIDMode="Static" MaxLength="10" onkeypress="return pin(event)" TabIndex="22"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_mode_empty">
                                    </div>
                                    <div id="tag_label_transaction_date" style="width: 80px">
                                        Branch SlNo
                                    </div>
                                    <div id="txtcon-m_transaction_code" style="width: 50px">
                                        <asp:TextBox ID="txtBranchSLNo" runat="server" CssClass="validate[custom[number]] txtbox_none_Mid_transac_code" Width="50px"
                                            ClientIDMode="Static" onkeypress="return pin(event)" MaxLength="3" TabIndex="23"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master_BranchSlno('Export_Item_Branch'); return false"
                                            class="magnfy"></a>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                </div>
                                <div id="tag_transac_lft_trans_item_new1_maintag1">
                                    <div id="tag_label_transaction_popup_Item_maindet">
                                        Address</div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            ClientIDMode="Static" MaxLength="35" TabIndex="24"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                     <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            ClientIDMode="Static" MaxLength="35" TabIndex="25"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            ClientIDMode="Static" MaxLength="35" TabIndex="26"></asp:TextBox>
                                    </div>
                                </div>
                               
                                <div id="tag_transac_lft_trans_item_new1_maintag1">
                                    <div id="tag_label_transaction_popup_Item_maindet">
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txtAddress3" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            ClientIDMode="Static" MaxLength="6" onkeypress="return pin(event)" TabIndex="27"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txtAddress4" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            ClientIDMode="Static" MaxLength="35" TabIndex="28"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                </div>
                                <div id="tag_transac_lft_trans_item_new1_maintag1">
                                    <div id="tag_label_transaction_popup_Item_maindet">
                                        GSTN Type
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:DropDownList ID="ddl_GSTN_Type" runat="server" CssClass="listtxt_transac_src1"
                                            ClientIDMode="Static" TabIndex="29" Width="150px">
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="G/GSN  -GSTIN of Normal Persons Individual IEC" Value="GSN"></asp:ListItem>
                                            <asp:ListItem Text="O/GSG GSTIN of Govt.Entities" Value="GSG"></asp:ListItem>
                                            <asp:ListItem Text="D/GSD - GSTIN of Diplomats" Value="GSD"></asp:ListItem>
                                            <asp:ListItem Text="I/PAN PAN Number (AAAPL1234C)" Value="PAN"></asp:ListItem>
                                            <asp:ListItem Text="T/TAN TAN Number (AAAP12345C)" Value="TAN"></asp:ListItem>
                                            <asp:ListItem Text="P/PSP -Passport Number( Max 9 Characters-AN)" Value="PSP"></asp:ListItem>
                                            <asp:ListItem Text="A/ADH Aadhaar Number( 12 Numeric)" Value="ADH"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transaction_popup_Item_maindet" style="text-align: center; width: 33px;">
                                        ID
                                    </div>
                                    <div id="txtcon-m_transaction_Supp_code">
                                        <asp:TextBox ID="txt_GSTN_ID" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                            ClientIDMode="Static" MaxLength="20" TabIndex="30"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                </div>
                            </div>
                
                </div>
                        
                        

                

                <div class="content" id="page2" style="display: none;">
                    <div id="pop_text_area_transac_popup_inn_container_left_trans_item_ceth">
                        <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="height:45px; width:800px; ">
                                <div id="tag_label_transaction_popup_Item_maindet">
                                    Accessory Desc</div>
                                     <div id="txtcon-m_transaction_Supp_code" style="width:400px; height:85px;">
                                <asp:TextBox ID="txtAccessoryDesc" runat="server" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1" Height="38px" Width="400px"
                                    MaxLength="500" TextMode="MultiLine" onkeyDown="return (event.keyCode!=13);return checkTextAreaMaxLength(this,event,'500');"
                                    onpaste="return checkTextAreaMaxLength(this,event,'500');" TabIndex="31"></asp:TextBox>
                                    </div>
                                    
                            </div>
                       
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="height: 40px; width: 683px;
                                margin-top: 20px;">
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    Item Manufacturer/Producer Code Type
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Manufacturer_producer" runat="server" onkeyup="autotab(this);"
                                        MaxLength="1" TabIndex="31" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </div>
                                <div id="txtcon_Promas1_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    Item Manufacturer/Producer/ Grower Code
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Manu_produ_grower_code" runat="server" onkeyup="autotab(this);"
                                        TabIndex="32" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17"></asp:TextBox>
                                </div>
                            </div>

                             <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    Address 1
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Manufacturer_Add1" onkeyup="autotab(this);" ClientIDMode="Static"
                                        runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="70" TabIndex="33"></asp:TextBox>
                                </div>
                                <div id="txtcon_Promas1_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    Address 2
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Manufacturer_Add2" runat="server" onkeyup="autotab(this);" MaxLength="50" Enabled="false"
                                        TabIndex="34" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    City
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Manufacturer_City" onkeyup="autotab(this);" MaxLength="35" TabIndex="35" Enabled="false"
                                        ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </div>
                                <div id="txtcon_Promas1_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    Country Subdivision
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Manu_Country_Subdiv" runat="server" onkeyup="autotab(this);"
                                        MaxLength="35" TabIndex="36" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    Pincode
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Manufacturer_pincode" onkeyup="autotab(this);" MaxLength="10"
                                        Onkeypress="return num1(event)" TabIndex="37" ClientIDMode="Static" runat="server"
                                        CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </div>
                                <div id="txtcon_Promas1_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                   Manufacturer Country
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Manufacturer_Country" runat="server" MaxLength="2" TabIndex="38" Onkeypress="return char1(event)" 
                                        CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    Source State
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Manu_Source_State" MaxLength="2" TabIndex="39" ClientIDMode="Static" Onkeypress="return char1(event)" 
                                        runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </div>
                                <div id="txtcon_Promas1_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    Transit Country
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_manu_Transit_Country" runat="server" MaxLength="2" TabIndex="40" Onkeypress="return char1(event)" 
                                        CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </div>
                            </div>
                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    Accessory Status (0 / 1 / 2)
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Accessory_status" onkeyup="autotab(this);" MaxLength="1" TabIndex="41"
                                        ClientIDMode="Static" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                        onkeypress="return pin(event);"></asp:TextBox>
                                </div>
                               
                            </div>

                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 583px;">
                                <div id="tag_label_transaction_popup_trans_cth_label" style="width: 580px; font-weight: bold;">
                                    (0-No Accessories,1-Accessories Along with this Item,2- Accessories as Separate Item)
                                </div>
                            </div>

                            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 583px;"></div>


                           <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                            <div id="tag_label_transaction_popup_trans_cth_label" >
                              HAWB_No
                            </div>
                             <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_HAWB_No" runat="server" MaxLength="15" TabIndex="42" 
                                        CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </div>
                                 <div id="txtcon_Promas1_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label">
                                    Total Package
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:TextBox ID="txt_Total_Pkgs" runat="server" MaxLength="8" TabIndex="43" onkeypress="return blockNonNumbers(this, event, true, false);"
                                        CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
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
                            TabIndex="47" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" Visible="False" CssClass="save" OnClick="btnSave_Click"
                            OnClientClick="return validate_Product();" TabIndex="44" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" Visible="False" CssClass="updates" OnClick="btnUpdate_Click"
                            OnClientClick="return validate_Product();" TabIndex="45" />
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
                        <asp:Button ID="btn" runat="server" TabIndex="46" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                        <asp:HiddenField ID="txtCountryCode" runat="server" />
                    </div>
                    <div id="editbu">

                      <asp:Button ID="btnCancel" runat="server" class="scancel" onClientClick="RefreshParent();return false;"
                        TabIndex="48" CausesValidation="false"
                        UseSubmitBehavior="false"/>
                        
                </div>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static"/>

                <asp:HiddenField ID="HiddenField1" runat="server" />
                
                <asp:HiddenField ID="HiddenField2" runat="server" Value="1" />
                 <asp:HiddenField ID="hdn_companyID" runat="server" />
                 <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
                 <asp:HiddenField ID="hdn_Update_Product" runat="server" ClientIDMode="Static" />
                 <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" ClientIDMode="Static" />
                 <asp:HiddenField ID="Hdn_RITC_4_digit" runat="server"  ClientIDMode="Static" />

            </div>
            </div>

             
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
        activatables('page', ['page1', 'page2']);
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
            $('#txt_IEC_ExporterName').focus(function () {

                var data = $(this).val();
                Item_exp_name(data);

            });
            $('#txt_IEC_ExporterName').change(function () {

                var data = $(this).val();
                Item_exp_name(data);

            });
            $('#txt_IEC_ExporterName').keyup(function () {

                var data = $(this).val();
                Item_exp_name(data);

            });
            $('#txt_IEC_ExporterName').keydown(function () {

                var data = $(this).val();
                Item_exp_name(data);

            });
            $('#txt_IEC_ExporterName').focusout(function () {

                var data = $(this).val();
                Item_exp_name(data);

            });
        });

        function Item_exp_name(val) {

            var data = val;
            if (data == '') {
                $('#txt_IEC_ExporterName').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];
              
                $('#txt_IEC_ExporterName').val(after);
                $('#txt_BranchNo').val(before);

//                $('#hdexp').val(after);
//                $('#hd_Brslno').val(before);

            }
            else {

            }
        }
    </script>

  
<script type="text/javascript">

    $(function () {
        $("#txt_IEC_ExporterName").autocomplete({

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
                            jQuery('#txt_IEC_ExporterName').validationEngine('showPrompt', 'Incorrect ExporterName', 'error', 'topRight', true);

                            //jAlert('ExporterName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtExporterName").focus(); });
                            //return false;
                        }
                        else {
                            jQuery('#txt_IEC_ExporterName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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



    function CallServerside_Importer_STD(src, dest, Adcode, JOBNO) {
        var ctrl = document.getElementById(src);
        var ctrl2 = document.getElementById(dest);
        // call server side method

        PageMethods.GetImporter_2(ctrl.value, ctrl2.value, CallSuccess_Importer, CallFailed, dest);
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


    $('#txtRITCNo').bind('keyup keypress change keydown ', function () {

        var t = document.getElementById("txtRITCNo").value;
        if (t.length == 8) {
            // document.getElementById("txtSTRCode").value = t.substring(0, 2);

            document.getElementById("Hdn_RITC_4_digit").value = t.substring(0, 4);
            PageMethods.Get_RITC_Info_Uqc(document.getElementById("txtRITCNo").value, OnSuccess_Info_Uqc);
        }
    });

    function OnSuccess_Info_Uqc(response, userContext, methodName) {

        //Ringo Cargo
        if (document.getElementById("hdn_companyID").value == "10" || document.getElementById("hdn_companyID").value == "1572") {
            if (document.getElementById("txtRITCNo").value.length == 8) {
                $('#txtQtyCode').val(response);
            }
        }

        $('#txt_UOM').val(response);
    }


    $('#ddl_STR_YN').bind('keyup keypress change keydown', function () {

        var t = document.getElementById("ddl_STR_YN").value;
        if (t == 'Y') {
            //            document.getElementById("div_STR_YN").style.display = 'Block';
            document.getElementById("txtSTRCode").disabled = false;           
        }
        else {
            //            document.getElementById("div_STR_YN").style.display = 'none';
            document.getElementById("txtSTRCode").disabled = true;
        }
    });



</script>


<script type="text/javascript">
    $(document).ready(function () {
        $('#txtEnduseItem').focus(function () {

            var data = $(this).val();
            Item_desc(data);

        });
        $('#txtEnduseItem').change(function () {

            var data = $(this).val();
            Item_desc(data);

        });
        $('#txtEnduseItem').keyup(function () {

            var data = $(this).val();
            Item_desc(data);

        });
        $('#txtEnduseItem').keydown(function () {

            var data = $(this).val();
            Item_desc(data);

        });
    });

    function Item_desc(val) {

        var data = val;

        if (data == '') {
            $('#txtEnduseItem').val('');
        }
        if (data.indexOf("-") != -1) {

            var s = data.split('-');

            var before = s[0];
            var after = s[1];

            $('#txtEnduseItem').val(before);
        }
        else {

        }
    }

    $(function () {
        $("#txtEnduseItem").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/End_Use_Of_Item_List",

                    data: "{ 'mail': '" + request.term + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            jQuery('#txtEnduseItem').validationEngine('showPrompt', 'Incorrect EndUse Code', 'error', 'topRight', true);

                        }
                        else {
                            jQuery('#txtEnduseItem').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //////alert(textStatus);
                    }
                });
            },
            minLength: 1

        });
        return false;
        scroll: true;
    });



    $(function () {
        $("#txt_PTA_FTA").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/PTA_FTA_Master_Name_List",
                    data: "{ 'mail': '" + request.term + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            jQuery('#txt_PTA_FTA').validationEngine('showPrompt', 'Incorrect Agreement Name', 'error', 'topRight', true);

                            //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                            //return false;
                        }
                        else {
                            jQuery('#txt_PTA_FTA').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
        $("#txtDrawback_SLNo").autocomplete({

            source: function (request, response) {
                var aa = document.getElementById("Hdn_RITC_4_digit").value;

                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/DrawBack_Master_List_RITCNO",
                    //                data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",                                                            
                    data: "{ 'mail': '" + request.term + "','RITC_NO': '" + aa + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            jQuery('#txtDrawback_SLNo').validationEngine('showPrompt', 'Incorrect Drawback SLNo', 'error', 'topRight', true);

                            //jAlert('Drawback SLNo is Incorrect', 'DRAWBACK', function (r) { document.getElementById("txtDrawback_SLNo').focus(); });
                            //return false;
                        }
                        else {
                            jQuery('#txtDrawback_SLNo').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //alert(textStatus);
                    }
                });
            },
            minLength: 1

        });
        return false;
        scroll: true;

    });

    $(function () {
        $("#txt_DBK_Unit").autocomplete({

            source: function (request, response) {
                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Unit_Master_List",
                    data: "{ 'mail': '" + request.term + "' ,'Trans_port':''}",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            jQuery('#txt_DBK_Unit').validationEngine('showPrompt', 'Incorrect Drawback Unit', 'error', 'topRight', true);

                        }
                        else {
                            jQuery('#txt_DBK_Unit').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //alert(textStatus);
                    }
                });
            },
            minLength: 1

        });
        return false;
        scroll: true;

    });


    function CallServerside_Drawback(src) {
        var ctrl = document.getElementById(src);
        PageMethods.Get_Drawback_Master(ctrl.value, CallSuccess_Drawback, CallFailed);
    }
    
    function CallSuccess_Drawback(res, destCtrl) {
        var dest = document.getElementById(destCtrl);
        var data = res;
        if (data.indexOf("~~") != -1) {

            var s = data.split('~~');

            var before = s[0];
            document.getElementById("txt_DBK_Unit").value = before;          
        }
        else {
            document.getElementById("txt_DBK_Unit").value = "";
        }
    }

  </script>

  
</body>
</html>
