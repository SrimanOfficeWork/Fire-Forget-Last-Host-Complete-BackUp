<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Staff_Suspense_entry.aspx.cs" Inherits="Staff_Suspense_entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Suspense entry | Updation</title>
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
    <script src="../js/eRoyalmaster_Jscript/Import_License_Master.js" type="text/javascript"></script>
  

    
        

  

</head>
 <%--<script type="text/javascript">
     $(document).ready(function () {
         var aa = $('#ddlStatus').val();
        // var xx = $('#Get_STR').val();
         if (aa == 'InActive') {
             $("#txtreason").attr("disabled", false);
            // $("#txtreason").val(xx);
         }
         else {
             $("#txtreason").attr("disabled", true);
         }
     });
</script>

    <script type="text/javascript">

        $(document).ready(function Calljs() {
            $('#ddlStatus').change(function () {
                var aa = $('#ddlStatus').val();
               // var xx = $('#Get_STR').val();
                if (aa == 'InActive') {
                    $("#txtreason").attr("disabled", false);
                    //$("#str_lcd").show();
                    $("#txtreason").val(xx);

                }
                else {
                    $("#txtreason").attr("disabled", true);
                    $("#txtreason").val('');
                   // $("#str_lcd").hide();

                }

            });
        });
      
    </script>--%>
<%-- <script type="text/javascript">
     function balance() 
     {
         if (txt_stf_cr_dt.Text == "null" || txt_stf_cr_dt.Text == "" && txtWriteoff.Text == "null" || txtWriteoff.Text == "") {

             txt_stf_cr_dt.Text = '0';
//            alert(txt_stf_cr_dt.Text);
             txtWriteoff.Text ='0';
         }
         else {
           //alert('a');
                var Cr = document.getElementById("txt_stf_cr_dt").value;
                var Dr = document.getElementById("txt_stf_prev_dt").value;
                var Wrof = document.getElementById("txtWriteoff").value;

                document.getElementById("txtBalance").value = parseFloat(Dr - Cr - Wrof);
                document.getElementById("txtBalance").value = res;
            }
        }
         // alert("ff");
//         var cr = parseFloat(document.getElementById("txt_stf_cr_dt").value);
//         var dr = parseFloat(document.getElementById("txt_stf_prev_dt").value);
//         var wrof = parseFloat(document.getElementById("txtWriteoff").value);
//         var res = parseFloat(dr) - parseFloat(cr) - parseFloat(wrof);
//         document.getElementById("txtBalance").value = res;
//         return balance();
//     }
</script>--%>


 <script type="text/javascript">
     function Staff_desc(val) {
         var val = document.getElementById("ddlStaffName").value;
       
 var data = val;
 if (data != '') {
             var s = data.split('-');
             var before = s[0];
          
             var after = s[1];
           
           
            // document.getElementById("txtStaffcode").value = after;
         }
         else {
         }
     }

        </script>

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
           
            <div id="innerbox_MidMain_popup_adcode"  style="height:300px;width:700px;">
                <div id="innerbox_MidMain_top_adcode" style="width:700px;">
                    STAFF SUSPENSE ENTRY
                
                    <div id="popupwindow_closebut_right"style="width:290px;">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                       
                <%--<div id="innerbox_MidMain_Mid_adcode">--%>
                <div id="innerbox_MidMain_Mid_ClientMaster" style="height: 300px; width: 550px;">
                    <div id="innerbox_MidMain_Mid_ClientMaster_l">
                       <div id="tag_transac_lft_in2">
                        <span runat="server" id="WK" visible="True">
                            <div id="tag_label_transaction_popup_gen" style="width: 139px;" >
                                &nbsp; Working Period</div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic" style="height: 25px;" >
                                <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlWorkingPeriod_SelectedIndexChanged" Width="185px">
                                </asp:DropDownList>
                            </div>
                        </span>
                    </div>
                       <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 138px">
                                &nbsp; Suspense Id
                            </div>
                            <div id="txtcon_mid_size" style="height: 25px;">
                                     <asp:TextBox ID="txtSusp_id" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="1" width = "182px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 139px">
                                &nbsp; Staff Name
                            </div>
                             <%--<div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">*
                            </div>--%>
                            <div id="txtcon-m_src" style="height: 25px;">
                              <%--  <asp:TextBox ID="txt_staffname" runat="server" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="1" MaxLength="50" Width="225px"></asp:TextBox>--%>
                                             <asp:DropDownList ID="ddlStaffName" CssClass="listtxt_transac_item_gen_notn" Width="185px"
                                            runat="server" TabIndex="0" onchange="Staff_desc();" >
                                        </asp:DropDownList>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
            
                     
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 135px">
                                &nbsp;Suspense Description
                            </div>
                            <div id="txtcon-m_src" style="height: 25px;">
                                <asp:TextBox ID="txt_Desc" runat="server" MaxLength="20" TabIndex="2" CssClass="txtbox_none_Mid_transac_code"
                                    Style="width: 182px;"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 139px">
                                &nbsp; Suspense Amount</div>
                                 <%--<div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">*
                            </div>--%>
                            <div id="txtcon-m_src" style="height: 25px; ">
                  
                                <asp:TextBox ID="txt_amount" Width="150px" runat="server" MaxLength="20" TabIndex="3"  
                                    CssClass="txtbox_none_Mid_transac_code"  text-align="right" 
                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this); " onkeypress="return blockNonNumbers(this, event, true, false);"
                                    style="width: 182px; text-align: right;"></asp:TextBox>
                                    </div>
                        </div>
                   
                          <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 139px">
                                &nbsp;  Suspense Given Date
                            </div>
                            
                            <div id="txtcon-m_src" style="height: 25px;">
                                <asp:TextBox ID="txtgivDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" Width="182px" TabIndex="4"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="maskededitextender5" runat="server" TargetControlID="txtgivDate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="calendarextender1" runat="server" TargetControlID="txtgivDate"
                                    PopupButtonID="txtentDate" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                            
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 139px">
                                &nbsp; Remarks
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                                <asp:TextBox ID="txtremarks" runat="server" CssClass="txtbox_none" TabIndex="5"
                                   Width="183px"></asp:TextBox></div>
                        </div>
                        
                    </div>
                </div>
            </div>
            </div> </div>
            <div id="innerbox_MidMain_top_adcode"style="height:100px; width:0px; margin-inline-start: 200px;">
                <div id="innerbox_adcode_bot_inn"style="height:50px; width:350px">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="9" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick="return validate_STAFF();"
                            TabIndex="6" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            OnClientClick="return validate_STAFF();" TabIndex="6" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="7" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'STAFF MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click(); 
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="7" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                            <%--<asp:Button ID="btnAuto_StaffCode" runat="server" TabIndex="51" OnClick="btnAuto_StaffCode_Click"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />--%>
                    </div>
                    <div id="editbu" style="display: none">
                        <asp:Button ID="btnSaveNew" Text="Save  & New" TabIndex="10" CssClass="autowidupdatebut"
                            OnClientClick="return validate();" runat="server" OnClick="btnSaveNew_Click" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                            tabindex="13" id="btnCancel" />
                        <asp:HiddenField ID="hdn_Update_Adcode" runat="server" />
                        <asp:HiddenField ID="hdn_check_adcode" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Import_Jscript/Import_License.js" type="text/javascript"></script>
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
    <script src="../js/iframepopupwin.js" type="text/javascript"></script>
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

    </script>

     
</body>
</html>
