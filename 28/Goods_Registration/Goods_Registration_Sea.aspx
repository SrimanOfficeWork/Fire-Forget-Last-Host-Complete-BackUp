<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Goods_Registration_Sea.aspx.cs"
    Inherits="Export_Annexure_C_Sea" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Master</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
        .annexureCSea_Iframenew1
        {      float:left;     
            width: 780px;
            height: 325px;
            background-color: #FFFFFF;
        }
    </style>

    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    

    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body id="bg2popup" style="overflow: hidden">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Trans_Goods_new">
                <ol id="toc">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();" id="Sea_Id">
                        <span>Sea</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                        runat="server" id="Container_Id"><span>Container</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3();"
                        runat="server" id="Package_Id"><span>Package</span></a></li>
                    <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');tab_page4();"
                        runat="server" id="Container_Package"><span>Container Package</span></a></li>
                    <li><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll');tab_page5();"
                        runat="server" id="Documents"><span>Documents</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="area_transac_container_genral" style="width:350px;">
                        <div id="popup_inn_container_Annuex_C_Sea" style="height:270px; width:800px;">
                            <div id="anne_c_sea_outer_lft">
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        SB No
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <%-- <asp:TextBox ID="txtFactory_Stuffed" runat="server" MaxLength="1" CssClass="validate[required] txtbox_annuxrec_air1"  TabIndex="1" onblur="ChangeCase(this);" onkeypress="return char1(event)"></asp:TextBox>--%>
                                        <asp:TextBox ID="txtSBNo" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="7"
                                            onkeypress="return num1(event)" TabIndex="1"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Seal Type
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:DropDownList ID="ddl_SealType" runat="server"  CssClass="validate[required] list_annuxrec_air2"
                                            MaxLength="1" TabIndex="2">
                                            <asp:ListItem Text="Agency" Value="Agency" ></asp:ListItem>
                                            <asp:ListItem Text="Self" Value="Self" ></asp:ListItem>
                                            <asp:ListItem Text="WareHouse" Value="WareHouse" ></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Marks_Numbers
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtMarks_Numbers" runat="server"  CssClass="txtbox_annuxrec_air1"
                                            MaxLength="300" TabIndex="3"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="package_p" runat="server">
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        No of Loose Packets
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtNo_Of_Loose_Packets" runat="server"  CssClass="txtbox_annuxrec_air1"
                                            MaxLength="8" onblur="extractNumber(this,2,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" TabIndex="4"></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Gross Weight
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtGross_Weight" runat="server"  CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="8" onblur="extractNumber(this,3,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" TabIndex="5"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Unit of Measurement</div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtUnit_Of_Measurement" runat="server" ClientIDMode="Static" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_code"
                                            MaxLength="3" onblur="ChangeCase(this);" onkeypress="return char1(event)" TabIndex="6"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="OpenPopupUnit_Goods_Reg('ANNEX_C_SEA'); return false" class="magnfy">
                                        </a>
                                    </div>
                                </div>
                                <%--<div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Rotation Date
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtRotationDate" runat="server" CssClass="txtbox_annuxrec_air1"
                                            MaxLength="10" TabIndex="7"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="txtRotationDate0_MaskedEditExtender" runat="server" AcceptNegative="Left"
                                            DisplayMoney="Left" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date"
                                            MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError" TargetControlID="txtRotationDate">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="txtRotationDate0_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            TargetControlID="txtRotationDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>--%>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                         Transhipper Code
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txt_TranshipperCode" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="10" TabIndex="7"></asp:TextBox>
                                    </div>
                                </div>
                                 <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Gateway Port
                                    </div>
                                    <div id="txtcon_m_anncair">
                                       <asp:TextBox ID="txt_GatewayPort" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="6" TabIndex="8"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                         WareHouse Code
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txt_WareHouseCode" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="10"  TabIndex="9"></asp:TextBox>
                                    </div>
                                </div>
                                
                            </div>
                            <div id="anne_c_sea_container_rght" >
                                <div id="anne_c_sea_inner_rht" style="width:500px;">
                                    <div id="anne_c_sea_txt_area">
                                        &nbsp;SB Date</div>
                                    <div id="txtcon_m_anncair">
                                        <%--     <asp:TextBox ID="txtSample_Accompanied" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="1" TabIndex="8" onblur="ChangeCase(this);" onkeypress="return char1(event)"></asp:TextBox>
                                        --%>
                                        <asp:TextBox ID="txtSBDate" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="10"
                                            TabIndex="10"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="txtRotationDate1_MaskedEditExtender" runat="server" AcceptNegative="Left"
                                            DisplayMoney="Left" ErrorTooltipEnabled="True" Mask="99/99/9999" MaskType="Date"
                                            MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError" TargetControlID="txtSBDate">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="txtRotationDate1_CalendarExtender" runat="server" Format="dd/MM/yyyy"
                                            TargetControlID="txtSBDate">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_rht" style="width:500px;">
                                    <div id="anne_c_sea_txt_area">
                                        Nature of Cargo</div>
                                    <div id="txtcon_m_anncair">
                                        <asp:DropDownList ID="ddlNatureOfCargo" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                            MaxLength="2" TabIndex="11">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="totalpackage_p" runat="server">
                                <div id="anne_c_sea_inner_rht" style="width:500px;">
                                    <div id="anne_c_sea_txt_area">
                                        Total No of Packages
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtTotal_No_Packages" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="8" onblur="extractNumber(this,2,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" TabIndex="12"></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                                <div id="container_c" runat="server">
                                <div id="anne_c_sea_inner_rht" style="width:500px;">
                                    <div id="anne_c_sea_txt_area">
                                        No of containers</div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtNo_Of_Containers" runat="server" CssClass="txtbox_annuxrec_air1"
                                            MaxLength="2" onkeypress="return num1(event)" TabIndex="13"></asp:TextBox>
                                    </div>
                                </div>
                                </div>
                                <div id="anne_c_sea_inner_rht" style="width:500px;">
                                    <div id="anne_c_sea_txt_area">
                                        Net Weight</div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtNet_Weight" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="8" onblur="extractNumber(this,3,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                            onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" TabIndex="14"></asp:TextBox>
                                    </div>
                                </div>

                                 <div id="anne_c_sea_inner_rht" style="width:500px;">
                                    <div id="anne_c_sea_txt_area">
                                        MAWB No/Date</div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtMawb_No" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="11" onkeypress="return charnum2(event)" TabIndex="15"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_mode_empty"></div>
                                     <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                         Dt:
                                     </div>
                                     <div id="txtcon-m_transaction_code">
                                         <asp:TextBox ID="txtMAWB_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                             MaxLength="10" Width="73px" TabIndex="16"></asp:TextBox>
                                         <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtMAWB_Date"
                                             Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                             MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                         </cc1:MaskedEditExtender>
                                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtMAWB_Date"
                                             PopupButtonID="txtMAWB_Date" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                                     </div>
                                </div>

                                 <div id="anne_c_sea_inner_rht" style="width:500px;">
                                    <div id="anne_c_sea_txt_area">
                                        HAWB No/Date</div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtHawb_No" runat="server" TabIndex="17" CssClass="validate[required] txtbox_annuxrec_air1"
                                                MaxLength="11" onkeypress="return charnum2(event)" ></asp:TextBox>
                                    </div>
                                     <div id="tag_label_transaction_popup_mode_empty">
                                     </div>
                                       <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                         Dt:
                                     </div>
                                     <div id="txtcon-m_transaction_code">
                                         <asp:TextBox ID="txtHAWB_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                             MaxLength="10" Width="73px" TabIndex="18"></asp:TextBox>
                                         <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtHAWB_Date"
                                             Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                             MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                         </cc1:MaskedEditExtender>
                                         <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtHAWB_Date"
                                             PopupButtonID="txtHAWB_Date" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                                     </div>
                                </div>
                                <div id="anne_c_sea_inner_rht" style="width:500px;">
                                    <div id="anne_c_sea_txt_area">
                                        Rotation No</div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtRotationNo" runat="server" TabIndex="19" CssClass="txtbox_annuxrec_air1" MaxLength="8"
                                            onkeypress="return num1(event)" ></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_mode_empty">
                                    </div>
                                      <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                                         Dt:
                                     </div>
                                    <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtRotationDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="10" Width="73px" TabIndex="20"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txtRotationDate"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtRotationDate"
                                            PopupButtonID="txtRotationDate" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_rht">
                                    <div id="anne_c_sea_txt_area">
                                    </div>
                                    <div id="txtcon_m_anncair">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact">
                            <div id="innerbox_transac_bot_inn">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="21" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide');" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="22"
                                        OnClientClick="return validate_Export_AnnexureC1_Sea_Details();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                        TabIndex="23" OnClientClick="return validate_Export_AnnexureC1_Sea_Details();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="24" Visible="false" CssClass="dlete"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'GOODS_REG_SEA', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="25" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                        CssClass="dlete" Style="display: none;" />
                                </div>
                                <div id="editbu">
                                    <input type="submit" value="Submit" class="scancel" onclick="parent.parent.adcodewindow.hide()"
                                        tabindex="26" id="btnCancel" /></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <iframe  name="trans_igm"  scrolling="no" id="annexureCSea_Container_Iframe" ></iframe>
                    <%--<iframe src="" name="trans_igm"  scrolling="no" id="annexureCSea_Iframe" ></iframe>--%>
                </div>
                <div class="content" id="page-3">
                    <iframe  name="trans_igm" scrolling="no" id="annexureCSea_Package_Iframe">
                    </iframe>
                </div>
                <div class="content" id="page-4">
                    <iframe  name="trans_igm" scrolling="no" id="annexureCSea_Container_Package_Iframe">
                    </iframe>
                </div>
                 <div class="content" id="page-5">
                    <iframe  name="trans_igm" scrolling="no" id="annexureCSea_Documents_Iframe">
                    </iframe>
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5']);
            </script>

             <asp:HiddenField ID="hdnTransport_mode" runat="server" />
            
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    
    <script src="../js/Export_Jscript/Export_Goods_Reg_Sea.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
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
  
    </script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('#txt_WareHouseCode').focus(function () {

                var data = $(this).val();
                WH_Code(data);

            });
            $('#txt_WareHouseCode').change(function () {

                var data = $(this).val();
                WH_Code(data);

            });
            $('#txt_WareHouseCode').keyup(function () {

                var data = $(this).val();
                WH_Code(data);

            });
            $('#txt_WareHouseCode').keydown(function () {

                var data = $(this).val();
                WH_Code(data);

            });

        });

        function WH_Code(val) {

            var data = val;
            if (data == '') {
                $('#txt_WareHouseCode').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');
                var before = s[0];
                var after = s[1];
                $('#txt_WareHouseCode').val(before);
            }
            else {

            }
        }
  </script>

    
</body>
</html>
