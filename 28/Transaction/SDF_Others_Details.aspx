<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SDF_Others_Details.aspx.cs" Inherits="SDF_Others_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ADCode Master | Updation</title>
<%--       <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />--%>

    <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />

    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
     
       
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
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
       
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Trans_IGM">
                <div class="content" id="page-1">
                    <div id="trans_IGM_details_Main_Cont1" style="width:963px;margin-left: 1px;">
                        <div id="pop_text_area_transac_popup_inn_container_IGM" 
                            style="height: 300px; margin-left: 0px;width: 930px; margin-top: 7px;">

                            <div id="pop_text_area_transac_popup_inn_container_left_IGM" style="height: 200px;width: 920px;">
                               
                            <div id="tag_transac_lft_IGM_in1" 
                                    style="width:930px;; margin-top:20px; height: 300px; margin-left: 0px;">
                                    <div id="tag_label_transaction_popup_IGM" style="width: 90px">
                                        Cash No</div>
                                    <div id="txtcon_m_transaction_IGM_Airnamenew"  style="width: 200px;" >
                                    <asp:TextBox ID="txtcashno" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="17" Width="190px"></asp:TextBox>
                             
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM" style="width: 90px;">
                                        Cash Date
                                    </div>
                                    <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width:200px;">
                                           <asp:TextBox ID="txtcashdt" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="18" Width="190px"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtcashdt"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtcashdt" 
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                    </div>
                                   <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM" style="width: 90px;">
                                        Cash Amount
                                    </div>

                                   <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big"  style="width:200px;">
                                      
                                        <asp:TextBox ID="txtcashAmt" runat="server" Width="190px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="10"></asp:TextBox>
                                    </div>


                                </div>
                            </div>
                        </div>
                        <div id="innerbox_MidMain_bot_transact" style="margin-top: 10px">
                            <div id="innerbox_transac_bot_inn" style="width: 503px;">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" TabIndex="29" CssClass="new" OnClick="btnNew_Click"
                                        OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                                        UseSubmitBehavior="false" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" ValidationGroup="dt"
                                        OnClientClick="return validation();" TabIndex="26" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" ValidationGroup="dt"
                                        OnClick="btnUpdate_Click" Visible="false" TabIndex="26" OnClientClick="return validation();" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="27" CausesValidation="false"
                                        UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'BILLING - OTHERS', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                    <asp:Button ID="btn" runat="server" TabIndex="27" CausesValidation="false" UseSubmitBehavior="false"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                                        CssClass="dlete" Style="display: none;" />
                                </div>
                                <div id="editbu">
                                    <input type="submit" value="Submit" class="scancel" onclick="Parent_close_button()"
                                        tabindex="28" id="btnCancel" />
                                </div>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
           
           
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1']);
    </script>
    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
    <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" />
    <asp:HiddenField ID="hd_Brslno" runat="server" />
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
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>

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
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });

    </script>


    
      <script type="text/javascript">

          $(function () {
              $("#txt_Name").autocomplete({

                  source: function (request, response) {
                      var field = $(this.element).attr('id');

                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List_Branch_slno_STD",
                          //                                data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "'}",
                          data: "{ 'mail': '" + request.term + "' ,'IEC':'" + document.getElementById('hdfTransport_mode').value + "' ,'Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",

                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {

                              response(data.d);



                              if (data.d == '') {
                                  if (field == 'txt_Name') {
                                      jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Importer Name', 'error', 'topRight', true);

                                      //jAlert('Importer Name is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                                      //return false;
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

            $('#txt_Name').focus(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txt_Name').change(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txt_Name').keyup(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txt_Name').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });

        });

        function Item_desc(val) {

            var data = val;
            if (data == '') {
                $('#txt_Name').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txt_Name').val(after);
                $('#hd_Brslno').val(before);

            }
            else {

            }
        }
  </script>
 
</body>
</html>
