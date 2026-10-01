<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Annexure_C_Sea.aspx.cs" Inherits="Export_Annexure_C_Sea" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Master</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
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
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>


        <script type="text/javascript">
            $(document).ready(function () {
                $('#btnUpdate,#btnSave').click(function () {

                    var Gross_Weight = document.getElementById("txtGross_Weight").value;
                    var Net_Weight = document.getElementById("txtNet_Weight").value;

                    if (parseFloat(Net_Weight) > parseFloat(Gross_Weight)) {
                        alert("Net Weight is Greater than Gross Weight...");
                        return false;
                    }

                });
            });
</script>

<script type="text/javascript">
    $(document).ready(function () {

    //-----------------Onload------------------------------------
        var stuff = $('#ddlFactory_Stuffed').val();      
        if (stuff == 'Y') {
            $('#txtFactoryAddress').attr("disabled", false);   
        }
        else {
            $('#txtFactoryAddress').attr("disabled", true);   
        }

        //---------------Onchange-----------------------------
        $('#ddlFactory_Stuffed').change(function () {
            var stuffs = $('#ddlFactory_Stuffed').val();
            if (stuffs == 'Y') {
                $('#txtFactoryAddress').attr("disabled", false);
                $('#ddlSeal_Type').val('Self');
            }
            else {
                $('#txtFactoryAddress').attr("disabled", true);
                $('#ddlSeal_Type').val('Warehouse');

            }
        });
        //-----------------------------------------------
    });
</script>

    <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>

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
            <div id="innerbox_MidMain_annx_CSea">
                <ol id="toc">
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1();" id="Annexure_Sea_Id">
                        <span>Annexure_C_Sea</span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                        style="display: none;" runat="server" id="Container_Id"><span>Container</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');tab_page3();"
                        style="display: none;" runat="server" id="Package_Id"><span>Package</span></a></li>
                    <div id="popupwindow_closebut_right_opt1">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
                    </div>
                </ol>
                <div class="content" id="page-1">
                    <div id="area_transac_container_genral">
                        <div id="popup_inn_container_Annuex_C_Sea" style="height:260px">
                            <div id="anne_c_sea_outer_lft">
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Factory Stuffed (Y/N)
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <%-- <asp:TextBox ID="txtFactory_Stuffed" runat="server" MaxLength="1" CssClass="validate[required] txtbox_annuxrec_air1"  TabIndex="1" onblur="ChangeCase(this);" onkeypress="return char1(event)"></asp:TextBox>--%>
                                        <asp:DropDownList ID="ddlFactory_Stuffed" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                            MaxLength="1" TabIndex="1">
                                            <asp:ListItem>Y</asp:ListItem>
                                            <asp:ListItem>N</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Nature of Cargo
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:DropDownList ID="ddlNatureOfCargo" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                            MaxLength="2" TabIndex="2">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Total No of Packages
                                    </div>
                                    <div id="txtcon_m_anncair" style="width:93px">
                                        <asp:TextBox ID="txtTotal_No_Packages" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="8" TabIndex="3"  Width="85px"
                                             onkeypress="return num1(event);"></asp:TextBox>
                                    </div>
                                    <div id="annexure_c_txt_area_2"  style="width:55px">
                                        <asp:TextBox ID="txtUnit_Code" runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_annuxrec_air2"
                                            ClientIDMode="Static" MaxLength="3" TabIndex="4" onkeypress="return char1(event)"  Width="50px"
                                            onblur="ChangeCase(this);"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="OpenPopupUnit('ANNEX_C_AIR_PKG'); return false" class="magnfy">
                                        </a>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        No of Containers
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtNo_Of_Containers" runat="server" CssClass="txtbox_annuxrec_air1"
                                            MaxLength="2" TabIndex="4" onkeypress="return num1(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Net Weight
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtNet_Weight" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="14" TabIndex="5" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Rotation No
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtRotationNo" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="8"
                                            TabIndex="6" onkeypress="return num1(event)"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        FOB Value
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtFOBValue" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="15"
                                            TabIndex="7" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                        Vessel No
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtVesselNo" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="30"
                                            TabIndex="7" ></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_lft">
                                    <div id="tag_label_transaction_popup_gen_export">
                                    Voyage No
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtVoyageNo" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="30"
                                            TabIndex="7" ></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div id="anne_c_sea_container_rght">
                                <div id="anne_c_sea_inner_rht">
                                    <div id="anne_c_sea_txt_area">
                                        Sample Accompanied (Y/N)</div>
                                    <div id="txtcon_m_anncair">
                                        <%--     <asp:TextBox ID="txtSample_Accompanied" runat="server" CssClass="txtbox_annuxrec_air1" MaxLength="1" TabIndex="8" onblur="ChangeCase(this);" onkeypress="return char1(event)"></asp:TextBox>
                                        --%>
                                        <asp:DropDownList ID="ddlSample_Accompanied" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                            MaxLength="1" TabIndex="8">
                                            <asp:ListItem>N</asp:ListItem>
                                            <asp:ListItem>Y</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_rht">
                                    <div id="anne_c_sea_txt_area">
                                        Marks_Numbers</div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtMarks_Numbers" runat="server" CssClass="txtbox_annuxrec_air1"
                                            MaxLength="200" TabIndex="9"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_rht">
                                    <div id="anne_c_sea_txt_area">
                                        No of Loose Packets
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtNo_Of_Loose_Packets" runat="server" CssClass="txtbox_annuxrec_air1"
                                            MaxLength="8" TabIndex="10" onkeypress="return num1(event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_rht">
                                    <div id="anne_c_sea_txt_area">
                                        Gross Weight
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtGross_Weight" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                            MaxLength="14" TabIndex="11" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_rht">
                                    <div id="anne_c_sea_txt_area">
                                        Unit of Measurement
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtUnit_Of_Measurement" runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_annuxrec_air1"
                                            ClientIDMode="Static" MaxLength="3" TabIndex="12" onkeypress="return char1(event)"
                                            onblur="ChangeCase(this);"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="OpenPopupUnit('ANNEX_C_SEA'); return false" class="magnfy">
                                        </a>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_rht">
                                    <div id="anne_c_sea_txt_area">
                                        Rotation Date
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtRotationDate" runat="server" CssClass="txtbox_annuxrec_air1"
                                            MaxLength="10" TabIndex="13"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtRotationDate"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtRotationDate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_rht">
                                    <div id="anne_c_sea_txt_area">
                                        Seal Type
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:DropDownList ID="ddlSeal_Type" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                            TabIndex="13">
                                            <asp:ListItem></asp:ListItem>
                                            <asp:ListItem>Agency</asp:ListItem>
                                            <asp:ListItem>Self</asp:ListItem>
                                            <asp:ListItem>Warehouse</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div id="anne_c_sea_inner_rht">
                                    <div id="anne_c_sea_txt_area">
                                        Vessel Date
                                    </div>
                                    <div id="txtcon_m_anncair">
                                        <asp:TextBox ID="txtVesselDate" runat="server" CssClass="txtbox_annuxrec_air1"
                                            MaxLength="15" TabIndex="13"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtVesselDate"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtVesselDate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>
                                </div>
                                 <div id="anne_c_sea_inner_rht"  style="height:60px">
                                    <div id="anne_c_sea_txt_area"  style="width:120px">
                                        Factory Address
                                    </div>
                                    <div id="txtcon-m_46px_trans_export_marks" style="width:270px; height:60px">
                                        <asp:TextBox ID="txtFactoryAddress" runat="server" CssClass="txtbox_annuxrec_air1"
                                            TextMode="MultiLine" MaxLength="500" TabIndex="13" Width="270px" Height="60px"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact">
                            <div id="innerbox_transac_bot_inn">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="14" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');"
                                        OnClick="btnNew_Click" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="15"
                                        OnClientClick="return validate_Export_AnnexureC1_Sea_Details();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                        TabIndex="16" OnClientClick="return validate_Export_AnnexureC1_Sea_Details();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="17" Visible="false" CssClass="dlete"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'ANNEXURE_C_SEA', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="17" OnClick="btnDelete_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                        CssClass="dlete" Style="display: none;" />
                                </div>
                                <div id="editbu">
                                    <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                                        tabindex="18" id="btnCancel" /></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <iframe  name="trans_igm" scrolling="no" id="annexureCSea_Iframe"></iframe>
                </div>
                <div class="content" id="page-3">
                    <iframe name="trans_igm" scrolling="no" id="annexureCSea_Package_Iframe">
                    </iframe>
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>

        <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

       <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
             
             <tr>
                 <td style="padding-left: 125px; padding-top:10px;">
                     <asp:Button ID="Button3" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>



    </form>
    <script src="../js/Export_Jscript/Export_Annexure_C_Sea.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
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
    </script>
</body>
</html>
