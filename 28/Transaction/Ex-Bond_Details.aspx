<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Ex-Bond_Details.aspx.cs"
    Inherits="Import_Ex_Bond" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Annexure C Air</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
      <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
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

 <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>

</head>
<body style="overflow: hidden">
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
         


            <div id="tag_srcinner1_annexurec_air_main_cont2">
                <div id="annexure_c_main">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice">
                        <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                            <div id="tag_label_transaction_Exbond">
                                IN-Bond-BE-No
                            </div>
                            <div id="txtcon_m_anncair">
                                <asp:TextBox ID="txtExbond_BENo" runat="server" CssClass="txtbox_annuxrec_air1"
                                    MaxLength="7" TabIndex="1" onkeypress="return num1(event)" onblur="checkBEChange()"></asp:TextBox>
                            </div>
                            <div id="annuxreair_emptyarea">
                            </div>
                            <div id="tag_label_transaction_Exbond">
                                IN-Bond-BE Date
                            </div>
                            <div id="txtcon_m_anncair">
                                <asp:TextBox ID="txtExbond_BEDate" runat="server" CssClass="txtbox_annuxrec_air1" onblur="checkBEChange()"
                                    MaxLength="10" TabIndex="2"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender15" runat="server" TargetControlID="txtExbond_BEDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" Enabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtExbond_BEDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                            <div id="tag_label_transaction_Exbond">
                                Bond Number
                            </div>
                            <div id="txtcon_m_anncair">
                                <asp:TextBox ID="txtExbond_BondNo" runat="server" CssClass="txtbox_annuxrec_air1"
                                    MaxLength="20" TabIndex="3" onkeypress="return charnum2(event)" onblur="ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="annuxreair_emptyarea">
                            </div>
                            <div id="tag_label_transaction_Exbond">
                                Bond Date
                            </div>
                            <div id="txtcon_m_anncair">
                                <asp:TextBox ID="txtExbond_BondDate" runat="server" CssClass="txtbox_annuxrec_air1"
                                    MaxLength="10" TabIndex="4"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtExbond_BondDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" Enabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtExbond_BondDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                            <div id="tag_label_transaction_Exbond">
                                WareHouse Customs</div>
                            <div id="txtcon_m_anncair">
                                <asp:TextBox ID="txtExbond_Warehouse_Customs" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                    MaxLength="6" TabIndex="5"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="annexure_c_txt_area_2">
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="ann_c_empty_1">
                            </div>
                            <div id="tag_label_transaction_Exbond">
                                Code
                            </div>
                            <div id="txtcon_m_anncair">
                                <asp:TextBox ID="txtExbond_Warehouse_Code" runat="server" CssClass="txtbox_annuxrec_air1" ClientIDMode="Static"
                                    MaxLength="8" TabIndex="6" onkeypress="return charnum2(event)" onblur="ChangeCase(this);"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                            <div id="tag_label_transaction_Exbond">
                                No of Pkgs Released
                            </div>
                            <div id="txtcon_m_anncair">
                                <asp:TextBox ID="txtExbond_NoofPackages" runat="server" CssClass="txtbox_annuxrec_air1"
                                    MaxLength="7" TabIndex="7" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                    onkeypress="return num1(event)"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="annexure_c_txt_area_2">
                                <asp:TextBox ID="txtExbond_NoofPackages_Code" runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_annuxrec_air2"
                                    ClientIDMode="Static" MaxLength="3" TabIndex="8" onkeypress="return char1(event)"
                                    onblur="ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="OpenPopupUnit('Package_Code'); return false" class="magnfy">
                                </a>
                            </div>
                            <div id="ann_c_empty_1">
                            </div>
                            <div id="tag_label_transaction_Exbond">
                                Gross Weight
                            </div>
                            <div id="txtcon_m_anncair">
                                <asp:TextBox ID="txtExbond_Gross_Weight" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                    MaxLength="10" TabIndex="9" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="annexure_c_txt_area_2">
                                <asp:TextBox ID="txtExbond_Gross_Weight_Code" runat="server" CssClass="validate[required,custom[onlyLetterSp],minSize[3]] txtbox_annuxrec_air2"
                                    ClientIDMode="Static" MaxLength="3" TabIndex="10" onkeypress="return char1(event)"
                                    onblur="ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="OpenPopupUnit('Gross_Wgt_Code'); return false" class="magnfy">
                                </a>
                            </div>
                        </div>
                         <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                            <div id="tag_label_transaction_Exbond">
                                Addl. Loading HSS %
                            </div>
                            <div id="txtcon_m_anncair">
                                   <asp:TextBox ID="txtAddl_Load_HSS" runat="server" CssClass="txtbox_annuxrec_air1"
                                    MaxLength="9" TabIndex="11" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                              <div id="annuxreair_emptyarea">
                            </div>
                               <div id="tag_label_transaction_Exbond">
                                Misc. Loading Rate %
                            </div>

                             <div id="txtcon_m_anncair">
                                <asp:TextBox ID="txtMisc_Load_Rate" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                    MaxLength="9" TabIndex="12" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>

                        </div>
                        <div id="tag_transac_lft_Transexport_annexure_Supp_in1">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Direct Ex-Bonding
                            </div>
                            <div id="txtcon_transac_checkbox">
                                <asp:CheckBox ID="chkDirect_Exbonding" runat="server" Checked="false" TabIndex="13" />
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact">
                            <div id="newbu">
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnSave" runat="server" CssClass="save" TabIndex="14" OnClientClick="return validate_Exbond('save');" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClientClick="return validate_Exbond('update'); "
                                    TabIndex="14" OnClick="btnUpdate_Click" />
                            </div>
                            
                            <div id="editbu">
                                        <asp:Button ID="btnDelete" runat="server" TabIndex="54" CausesValidation="false" 
                                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Exbond Details?', 'EX-BOND', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;"   />
                                        <asp:Button ID="btn" runat="server" TabIndex="54" OnClick="btnDelete_Click" CausesValidation="false" 
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                            
                                    </div>
                                    <div id="editbu">
                                <asp:Button ID="btn_warehose" runat="server" CssClass="scancel" OnClientClick="parent.parent.adcodewindow.hide();return false;"
                                    TabIndex="15" />
                                <asp:Button ID="btn_exbond" runat="server" CssClass="scancel" OnClientClick="parent.adcodewindow.hide();return false;"
                                    TabIndex="15" />
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="width:820px;">
                         <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 120px">
                                Working Period
                            </div>
                            <div id="txt_trans_exp_drawback" style="width: 220px">
                                 <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none"  AutoPostBack="True"  
                                  TabIndex="16" onselectedindexchanged="ddlWorkingPeriod_SelectedIndexChanged" >
                                 <asp:ListItem Text="01-Apr-2020 - 31-Mar-2021" Value="01-Apr-2020 - 31-Mar-2021"></asp:ListItem>
                                 </asp:DropDownList>
                            
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                            <div id="tag_label_transaction_popup_trans_cth_label2">
                                JobNo
                            </div>
                            <div id="txt_trans_exp_drawback" style="width: 100px">
                                <asp:TextBox ID="txt_Jobno" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                    Width="100px" MaxLength="10" TabIndex="16" onblur="extractNumber(this,3,false);"
                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label2">
                                BE No
                            </div>
                            <div id="txt_trans_exp_drawback" style="width: 100px">
                                <asp:TextBox ID="txt_Beno" runat="server" CssClass="validate[required] txtbox_annuxrec_air1"
                                    Width="100px" MaxLength="10" TabIndex="17" onblur="extractNumber(this,3,false);"
                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="small-butt-left">
                                <%--<a href="#" id="btnSearch" runat="server" onserverclick="btnSearch_Click" class="srcbu"
                                    tabindex="17" onclick="page_Loading();"></a>--%>
                                    <asp:Button ID="btnSearch" runat="server" CssClass="srcbu" OnClientClick="return page_Loading();" Text="Search"
                                    TabIndex="17" OnClick="btnSearch_Click" />
                            </div>
                        </div>
                        <div id="tag_transac_lft_Item_reimport_Grid_area" style="height: 200px; width: 800px">
                            <asp:GridView ID="gv_Details" runat="server" EmptyDataText="NO RECORD FOUND" DataKeyNames="BE_ID"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="130%"
                                ShowHeaderWhenEmpty="True" OnRowDataBound="gv_Details_RowDataBound" OnPageIndexChanging="gv_Details_PageIndexChanging"
                                OnSelectedIndexChanged="gv_Details_SelectedIndexChanged" PageSize="12" AllowPaging="True"
                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" OnRowCreated="gv_Details_RowCreated">
                                <Columns>
                                   <asp:BoundField DataField="BE_JOBNO" HeaderText="BE JOBNO" >
                                     <ItemStyle CssClass="column_style_left" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_NO" HeaderText="BE NO">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_DATE" HeaderText="BE DATE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_INBOND_NO" HeaderText="INBOND NO">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_INBOND_DATE" HeaderText="INBOND DATE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_WAREHOUSE_CUSTOMS" HeaderText="WAREHOUSE CUSTOMS">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BE_WAREHOUSE_CUSTOMS_CODE" HeaderText="CUSTOMS CODE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                                                         
                                  
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
            
            
            <asp:HiddenField ID="hdn_Direct_Exbonding" runat="server" />
            <asp:HiddenField ID="hdn_EXBND_JOBID" runat="server" />
            <asp:HiddenField ID="hdn_find_exists_jobno" runat="server" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
             <asp:HiddenField ID="HDBranch" runat="server" />
             <asp:HiddenField ID="Hdn_No_pkgs" runat="server" />
             <asp:HiddenField ID="Hdn_BE_TYPE" runat="server" />
             <asp:HiddenField ID="hdn_BE_No" runat="server" />
             <asp:HiddenField ID="hdn_BE_Date" runat="server" />


            
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
                     <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>


    </form>
     <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2']);
    </script>
    <script src="../js/Import_Jscript/Import_ExBond.js" type="text/javascript"></script>
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
    <script src="../js/Autotab.js" type="text/javascript"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        function tab_page1() {
            document.getElementById('page-1').style.display = 'none';
            document.getElementById('page-2').style.display = 'Block';

            document.getElementById("annexureCSea_EXbond_Iframe").src = "../Transaction/WareHouse_Move_Exbond.aspx";

           

        }
        function tab_page2() {


            document.getElementById('page-1').style.display = 'Block';
            document.getElementById('page-2').style.display = 'none';

         

        }
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
        $(function () {
            $("#txt_Jobno").autocomplete({
                source: function (request, response) {
                   
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_EXP_GENERAL_SEARCH",
                        data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "' ,'Aflags': '" + "Select_JobNo_Exbond" + "','IMP_EXP': 'Import'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txt_Jobno').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_Jobno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
      $(function () {
          $("#txt_Beno").autocomplete({
              source: function (request, response) {
                 
                  $.ajax({
                      url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IMP_EXP_GENERAL_SEARCH",
                      data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("<%=HDBranch.ClientID %>").value + "' ,'Aflags': '" + "Select_BENO_Exbond" + "','IMP_EXP': 'Import'}",
                      dataType: "json",
                      type: "POST",
                      contentType: "application/json; charset=utf-8",
                      dataFilter: function (data) { return data; },
                      async: true,
                      success: function (data) {
                          response(data.d);
                          if (data.d == '') {
                              jQuery('#txt_Beno').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                          }
                          else {
                              jQuery('#txt_Beno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
         $('#txtExbond_Warehouse_Code').focus(function () {

             var data = $(this).val();
             WH_Code(data);

         });
         $('#txtExbond_Warehouse_Code').change(function () {

             var data = $(this).val();
             WH_Code(data);

         });
         $('#txtExbond_Warehouse_Code').keyup(function () {

             var data = $(this).val();
             WH_Code(data);

         });
         $('#txtExbond_Warehouse_Code').keydown(function () {

             var data = $(this).val();
             WH_Code(data);

         });

     });

     function WH_Code(val) {

         var data = val;
         if (data == '') {
             $('#txtExbond_Warehouse_Code').val('');
         }
         if (data.indexOf("--") != -1) {

             var s = data.split('--');
             var before = s[0];
             var after = s[1];
             $('#txtExbond_Warehouse_Code').val(before);
         }
         else {

         }
     }
  </script>
  <script type="text/javascript">
      function checkBEChange() {
          var orgNo = document.getElementById('<%= hdn_BE_No.ClientID %>').value;
          var orgDate = document.getElementById('<%= hdn_BE_Date.ClientID %>').value;
          var betype = document.getElementById('<%= Hdn_BE_TYPE.ClientID %>').value;
          var curNo = document.getElementById('<%= txtExbond_BENo.ClientID %>').value;
          var curDate = document.getElementById('<%= txtExbond_BEDate.ClientID %>').value;

          if (betype == 'Ex - Bond' && (orgNo !== curNo || orgDate !== curDate)) {
              alert("BE No or BE Date has not matched with warehouse BENo&Date");
          }
      }
</script>


</body>
</html>
