<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Adcode_Master.aspx.cs" Inherits="eRoyalMasters_Adcode_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADcode Master | Updation</title>
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


      <%-- <script type="text/javascript">
           $(document).ready(function () {
               $('#txtAdcode').keyup(function () {
                   var aa = $('#txtAdcode').val();
                   var bb = $('#txtImportAdcode').val();
                   var New_Update = document.getElementById("hdn_new_update").value;
                   var Update_Val = document.getElementById("hdn_Update_Val").value;

                   if (New_Update == "New") {
                       var aa = $('#txtAdcode').val();
                       $('#txtImportAdcode').val(aa);
                   }
//                   else {-- hide by Chithra for Agility-Import ADCode change while edit Export ADCode- 05-05-2020
//                       if (Update_Val == 'Equal') {
//                           var aa = $('#txtAdcode').val();
//                           $('#txtImportAdcode').val(aa);
//                       }
//                       else {

//                       }
//                   }
               });
           });
    </script>--%>

</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
           
            <div id="innerbox_MidMain_popup_adcode" style="height:415px">
                <div id="innerbox_MidMain_top_adcode">
                    ADCODE MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="win_close();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" >
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            IEC Number</div>
                        <div id="txtcon_mid_size">
                            <asp:TextBox ID="txtIec_Code" runat="server" onkeyup="autotab(this);" CssClass="validate[required,minSize[10]] txtbox_none_mid_size"
                                  OnTextChanged="txtIec_Code_TextChanged" AutoPostBack="True" TabIndex="1" MaxLength="10"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" shape="poly" onclick="opennewieccode(); return false" class="magnfy"
                                tabindex="2"></a>
                        </div>
                    </div>
                     <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Branch SlNo</div>
                        <div id="txtcon_mid_size">
                            <asp:TextBox ID="txt_BranchSlNo" runat="server" onkeyup="autotab(this);" CssClass="txtbox_none_mid_size"
                                 TabIndex="1" MaxLength="10"></asp:TextBox>
                        </div>
                       <%-- <div id="magnify_area">
                            <a href="#" shape="poly" onclick="opennewieccode(); return false" class="magnfy"
                                tabindex="2"></a>
                        </div>--%>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Client</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtIec_Name" runat="server" CssClass="validate[required] txtbox_none"
                                Onkeypress="return numchar(event)" TabIndex="3" MaxLength="40" 
                                Width="215px"></asp:TextBox>
                        </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                           Export ADCode
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtAdcode" runat="server" CssClass="txtbox_none" onkeyup="ChangeCase(this);"
                                onfocus="ChangeCase(this);" onblur="ChangeCase(this);" TabIndex="4" Onkeypress="return numchar(event)"
                                MaxLength="14" AutoPostBack="True" OnTextChanged="txtAdcode_TextChanged" Width="215px"></asp:TextBox>                   
                        </div>
                    </div>

                     <div id="pop_text_area">
                        <div id="tag_label_adcode">
                         Import ADCode
                        </div>
                         <div id="txtcon-m_src">
                             <asp:TextBox ID="txtImportAdcode" runat="server" CssClass="txtbox_none" onkeyup="ChangeCase(this);"
                                 onfocus="ChangeCase(this);" onblur="ChangeCase(this);" TabIndex="4" Onkeypress="return numchar(event)"
                                 MaxLength="14" AutoPostBack="True" OnTextChanged="txtImportAdcode_TextChanged"
                                 Width="215px"></asp:TextBox>
                         </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Bank Name</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtBankName" runat="server" CssClass="txtbox_none" TabIndex="5"
                                Onkeypress="return numchar(event)" MaxLength="40" Width="215px"></asp:TextBox>
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            IFSC Code</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtIfsccode" runat="server" CssClass="txtbox_none_mid_size"
                                 TabIndex="6" Onkeypress="return numchar(event)" 
                                MaxLength="20" Width="215px"></asp:TextBox></div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Bank Account No</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtBankAccountNo" runat="server" CssClass="txtbox_none" TabIndex="7"
                                Onkeypress="return numchar(event)" MaxLength="20"></asp:TextBox></div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Address</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="txtbox_none" TabIndex="8"
                                MaxLength="40" Width="215px"></asp:TextBox></div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                        </div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="txtbox_none" TabIndex="9"
                                MaxLength="40" Width="215px"></asp:TextBox></div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            City</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtCity" runat="server" CssClass="txtbox_none" TabIndex="10" MaxLength="25"
                                Onkeypress="return char(event)" Width="215px"></asp:TextBox></div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            State</div>
                        <div id="txtcon_mid_size">
                            <asp:TextBox ID="txtStateName" runat="server" CssClass="txtbox_none_mid_size" TabIndex="11"
                                MaxLength="25" Onkeypress="return char(event)"></asp:TextBox></div>
                        <div id="magnify_area">
                            <a href="#" shape="poly" onclick="opennewStatecode(); return false" class="magnfy"
                                tabindex="12"></a>
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            PIN Code</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtPincode" runat="server" CssClass="validate[minSize[6],custom[onlyNumberSp]] txtbox_none"
                                onkeyup="autotab(this);" TabIndex="13" Onkeypress="return pin(event)" 
                                MaxLength="6" Width="215px"></asp:TextBox></div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Remarks</div>
                        <div id="txtcon-m_Maxtxt">
                            <asp:TextBox ID="txtRemarks" runat="server" MaxLength="200" TextMode="MultiLine"
                                CssClass="txtbox_none_Maxtxt_Client" onkeyDown="return checkTextAreaMaxLength(this,event,'200');"
                                onpaste="return checkTextAreaMaxLength(this,event,'200');" TabIndex="14"></asp:TextBox>
                        </div>
                    </div>

                  

                    <div id="lblMsg2" style="display: none;">
                    </div>
                 
                </div>
            </div>
            <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="17" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick=" return validate_Adcode();"
                            TabIndex="14" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            OnClientClick="return validate_Adcode();" TabIndex="14" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="15" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'ADCODE MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="15" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="win_close();return false;"
                            tabindex="16" id="btnCancel" />
                        <br />
                        &nbsp;<asp:HiddenField ID="hdn_Update_Adcode" runat="server" />
                        <asp:HiddenField ID="hdn_check_adcode" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="hdn_new_update" runat="server" />
                        <asp:HiddenField ID="hdn_Update_Val" runat="server" />
                        <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" />

                    </div>
                </div>
                &nbsp;</div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
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
//        $(window).bind("load", function () {
//            $('#load').hide(); ;
//        });
      
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
                    var errorField = $(this.element).attr('id');
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_List",
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
                                //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtStateName').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

            $("#txtIec_Code").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_IECCode_NAME_List",
                        //                        data: "{ 'mail': '" + request.term + "' ,'IEC':''}",
                        data: "{ 'mail': '" + request.term + "' ,'IEC':'','Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                        
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);

                            if (data.d == '') {
                                jQuery('#txtIec_Code').validationEngine('showPrompt', 'Incorrect IEC Code', 'error', 'topRight', true);
                                //jAlert('IEC Code is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtIec_Code').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtIec_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function btnCancel_onclick() {

}

    </script>

    
  <script type="text/javascript">
      $(document).ready(function () {

          $('#txtIec_Code').focus(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txtIec_Code').change(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txtIec_Code').keyup(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txtIec_Code').keydown(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
      });

      function Item_desc1(val) {

          var data1 = val;
          if (data1 == '') {
              $('#txtIec_Code').val('');
          }
          if (data1.indexOf(" -") != -1) {

              var s = data1.split(' -');

              var before = s[0];
              var after = s[1];

              $('#txtIec_Code').val(before);
              $('#txtIec_Name').val(after);
          }
          else {

          }
      }
  </script>
</body>
</html>
