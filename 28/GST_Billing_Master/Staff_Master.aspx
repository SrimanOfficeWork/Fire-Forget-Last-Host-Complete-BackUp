<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Staff_Master.aspx.cs" Inherits="Staff_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff Master | Updation</title>
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
 <script type="text/javascript">
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
           
            <div id="innerbox_MidMain_popup_adcode"  style="height:330px;width:780px;">
                <div id="innerbox_MidMain_top_adcode" style="width:780px;">
                    STAFF MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <%--<div id="innerbox_MidMain_Mid_adcode">--%>
                <div id="innerbox_MidMain_Mid_ClientMaster" style="height: 300px; width: 780px; margin-left: 10px;">
                    <div id="innerbox_MidMain_Mid_ClientMaster_l" style="width: 350px; height: 350px">
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 111px">
                                &nbsp; Staff Code
                            </div>
                             <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">*
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtStaffcode" runat="server" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="1" MaxLength="50"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 111px">
                                &nbsp; Staff Full Name</div>
                                <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">*
                            </div>
                            <div id="txtcon_mid_size">
                                <%--<asp:TextBox ID="txtstafullName" runat="server" CssClass="validate[required] txtbox_none"
                                    onkeypress="return charnum2(event)" TabIndex="2" MaxLength="30"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtstafullName" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="2" onkeypress="return charnum2(event)" Width="220px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 119px">
                                &nbsp; Staff Short Name
                            </div>
                            <div id="txtcon_mid_size">
                                <%--<asp:TextBox ID="txt_staffname" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="3" MaxLength="50"></asp:TextBox>--%>
                                     <asp:TextBox ID="txt_staffname" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="3" onkeypress="return charnum2(event)" Width="223px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 119px">
                                &nbsp; Employee Id
                            </div>
                            <div id="txtcon-m_src">
                               <%-- <asp:TextBox ID="txt_empid" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="4" MaxLength="16"></asp:TextBox>--%>
                                     <asp:TextBox ID="txt_empid" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="4" onkeypress="return charnum2(event)" Width="223px"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 109px">
                                &nbsp; Aadhar Id</div>
                                 <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">*
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtAdno" MaxLength="12" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,3,false);remove_zero_after_decimal_point(this.value,'txtAdd1');"
                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    TabIndex="5" Width="223px"></asp:TextBox></div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 111px">
                                &nbsp; PAN Id</div>
                                 <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">*
                            </div>
                            <div id="txtcon-m_src">
                                <%--<asp:TextBox ID="txtpanid"  MaxLength="10" runat="server" CssClass="txtbox_none" TabIndex="6"></asp:TextBox>--%>
                                <asp:TextBox ID="txtpanid" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="6" onkeypress="return charnum2(event)" Width="222px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 119px">
                                &nbsp; Driving License No
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtlicno" runat="server" CssClass="txtbox_none" TabIndex="7" Onkeypress="return numchar(event)"
                                    MaxLength="30" Width="223px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 119px">
                                &nbsp; Passport
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtpass" runat="server" CssClass="txtbox_none" MaxLength="40"
                                    Onkeypress="return numchar(event)" TabIndex="8" Width="223px"></asp:TextBox>
                            </div>
                        </div>
                          <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 119px">
                                &nbsp; Other Id Type</div>
                            <div id="txtcon-m_src">
                                <asp:DropDownList runat="server" ID="ddlotheridType" Width="150px" TabIndex="9">
                                </asp:DropDownList>
                            </div>
                        </div>
                           <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 119px">
                                &nbsp; Other Id No
                            </div>
                            <div id="txtcon-m_src">
                                <%--<asp:TextBox ID="txtADCode" runat="server" CssClass="txtbox_none"
                                     MaxLength="12"   TabIndex="13"
                                    onkeypress="return numchar(event);"></asp:TextBox>--%>
                                <asp:TextBox ID="txtothidno" runat="server" Onkeypress="return numchar(event)" TabIndex="10"
                                      CssClass="txtbox_none_Mid_transac_code" MaxLength="20" Width="150px"></asp:TextBox></div>
                        </div>
                       <%-- <div id="txtcon-m_src">
                        </div>
                     --%>
                            <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 110px">
                                &nbsp; Entry Date
                            </div>
                             <div id="txtcon-m_src" style="color:Red; width:10px;">*
                    </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtentDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" Width="100px" TabIndex="11"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="maskededitextender5" runat="server" TargetControlID="txtentDate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="calendarextender1" runat="server" TargetControlID="txtentDate"
                                    PopupButtonID="txtentDate" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                        </div>
                                 <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 110px">
                                &nbsp; Date of joining
                            </div>
                             <div id="txtcon-m_src" style="color:Red; width:10px;">*
                    </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_doj" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" Width="150px" TabIndex="12"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_doj"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_doj"
                                    PopupButtonID="txt_doj" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                           
                        </div>
                      
                       <%-- <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                &nbsp; Pin Code</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtPinCode" runat="server" CssClass="txtbox_none" TabIndex="11"
                                    Onkeypress="return pin(event)" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>--%>
                        <div id="lblMsg2" style="display: none;">
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Mid_ClientMaster_l" style="width: 430px; height: 300px ; align:left">
                      <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 105px">
                                &nbsp; Bank Name
                            </div>
                            <div id="txtcon-m_src">
                                <%--<asp:TextBox ID="txt_staffname" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="3" MaxLength="50"></asp:TextBox>--%>
                                     <asp:TextBox ID="txt_bank_name" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="13" onkeypress="return charnum2(event)" Width="223px"></asp:TextBox>
                            </div>
                        </div>
                      
                           <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 105px">
                                &nbsp; Bank UserName
                            </div>
                            <div id="txtcon-m_src">
                                <%--<asp:TextBox ID="txt_staffname" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="3" MaxLength="50"></asp:TextBox>--%>
                                     <asp:TextBox ID="txt_bankuser_name" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="14" onkeypress="return charnum2(event)" Width="223px"></asp:TextBox>
                            </div>
                        </div>
                           <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 105px">
                                 &nbsp;&nbsp;Account No
                            </div>
                            <div id="txtcon-m_src">
                                <%--<asp:TextBox ID="txt_staffname" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="3" MaxLength="50"></asp:TextBox>--%>
                                     <asp:TextBox ID="txt_acc_no" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="15" onkeypress="return charnum2(event)" Width="223px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 105px">
                                &nbsp;&nbsp;Bank Branch
                            </div>
                            <div id="txtcon-m_src">
                                <%--<asp:TextBox ID="txt_staffname" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="3" MaxLength="50"></asp:TextBox>--%>
                                     <asp:TextBox ID="txt_bank_branch" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="16" onkeypress="return charnum2(event)" Width="223px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 105px">
                                &nbsp;&nbsp;IFSC Code
                            </div>
                            <div id="txtcon-m_src">
                                <%--<asp:TextBox ID="txt_staffname" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="3" MaxLength="50"></asp:TextBox>--%>
                                     <asp:TextBox ID="txt_ifsc" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="17" onkeypress="return charnum2(event)" Width="223px"></asp:TextBox>
                            </div>
                        </div>
                           <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 105px">
                                &nbsp;&nbsp;Swift Code
                            </div>
                            <div id="txtcon-m_src">
                                <%--<asp:TextBox ID="txt_staffname" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="3" MaxLength="50"></asp:TextBox>--%>
                                     <asp:TextBox ID="txt_swift_code" runat="server" MaxLength="30" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="18" onkeypress="return charnum2(event)" Width="223px"></asp:TextBox>
                            </div>
                        </div>
                          
                        <%-- <div id="pop_text_area">
                            <div id="tag_label_adcode">
                               Swift Code
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtSwiftCode" runat="server" CssClass="txtbox_none"
                                    TabIndex="12" MaxLength="20"  
                                    onkeypress="return numchar(event);"></asp:TextBox></div>
                        </div>
                        <div id="txtcon-r_src">
                        </div>
                     
                        <div id="txtcon-r_src">
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Currency
                            </div>
                            <div id="txtcon-m_src">
                                

                                    <asp:DropDownList runat="server" ID="ddlCurrency" Width="100px"  TabIndex="14"></asp:DropDownList>
                                    
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>--%>
                      
                       <%-- <div id="pop_text_area"style="height: 20px">
                            <div id="tag_label_adcode"style="width: 115px">
                                &nbsp; Bank Details
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtbandet" runat="server" CssClass="txtbox_none" MaxLength="30"
                                    TextMode="MultiLine" TabIndex="12" Onkeypress="return numchar(event);" Width="150px"
                                    Height="20px"></asp:TextBox>
                            </div>
                        </div>--%>
               
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 103px">
                                &nbsp; Emp Status
                            </div>
                             <div id="tag_label_transaction_popup_mode_empty" style="color:Red; width:10px;">*
                    </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                               <asp:DropDownList ID="ddlStatus" runat="server" CssClass="listtxt_transac_src1" Width="150px"
                                                TabIndex="19">
                                                <asp:ListItem>Active</asp:ListItem>
                                                <asp:ListItem>InActive</asp:ListItem>
                                            </asp:DropDownList>
                                    
                                </div>
                                </div>
                                <div id="pop_text_area">
                                <div id="tag_label_adcode"style="width: 105px">
                               &nbsp; Reason
                            </div>
                            <div id="txtcon-m_src">
                               <%-- <asp:TextBox ID="txtreason" runat="server" TabIndex="15" Width="150px"></asp:TextBox>--%>
                               <asp:TextBox ID="txtreason" runat="server" CssClass="listtxt_transac_src1"
                                     Width="223px" TabIndex="20"></asp:TextBox>
                                </div>
                                </div>

                        
                        <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 105px">
                                &nbsp; Remarks
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                                <asp:TextBox ID="txtremarks" runat="server" CssClass="txtbox_none" TabIndex="21"
                                   Width="223px"></asp:TextBox></div>
                        </div>
                         
                            <div id="pop_text_area_transac_popup_inn_container_IGM_tag2" runat="server" style=" width: 360px; height: 135px; margin: 15px; border-color:Navy">
                           <div id="pop_text_area">
                            <div id="tag_label_adcode" style="text-align:centre; font-size:14px" >
                               &nbsp;<b>Summary:</b>
                            </div>
                            
                        </div>
                          <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 115px">
                                &nbsp; Total Suspense Dr</div>
                                
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="TextBox1" MaxLength="12" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,3,false);remove_zero_after_decimal_point(this.value,'txtAdd1');"
                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    TabIndex="22"  style="width: 223px; text-align: right;" Enabled="false"></asp:TextBox></div>
                        </div>
                          <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 115px">
                                &nbsp; Total Return Cr</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="TextBox2" MaxLength="12" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,3,false);remove_zero_after_decimal_point(this.value,'txtAdd1');"
                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    TabIndex="23" style="width: 223px; text-align: right;" Enabled="false"></asp:TextBox></div>
                        </div>
                            <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 115px">
                                &nbsp; Total Write-off</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="TextBox4" MaxLength="12" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,3,false);remove_zero_after_decimal_point(this.value,'txtAdd1');"
                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    TabIndex="23" style="width: 223px; text-align: right;" Enabled="false"></asp:TextBox></div>
                        </div>
                          <div id="pop_text_area">
                            <div id="tag_label_adcode"style="width: 115px">
                                &nbsp; Balance</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="TextBox3" MaxLength="12" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    onblur="extractNumber(this,3,false);remove_zero_after_decimal_point(this.value,'txtAdd1');"
                                    onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    TabIndex="24" style="width: 223px; text-align: right;" Enabled="false"></asp:TextBox></div>
                        </div>
                          </div>  
                        <%--  <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Suffix
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                                <asp:TextBox ID="txtSuffix" runat="server" CssClass="txtbox_none"
                                    TabIndex="18" MaxLength="30"  
                                   ></asp:TextBox></div>
                            
                          
                        </div>--%>
                    </div>
                </div>
            </div>
            </div> </div>
            <div id="innerbox_MidMain_top_adcode"style="height:100px; width:0px; margin-inline-start: 20px">
                <div id="innerbox_adcode_bot_inn" style="height:0px; width:350px">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="28" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick="return validate_STAFF();"
                            TabIndex="25" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            OnClientClick="return validate_STAFF();" TabIndex="25" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="26" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'STAFF MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click(); 
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="26" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                            <%--<asp:Button ID="btnAuto_StaffCode" runat="server" TabIndex="51" OnClick="btnAuto_StaffCode_Click"
                                            CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />--%>
                    </div>
                    <div id="editbu" style="display: none">
                        <asp:Button ID="btnSaveNew" Text="Save  & New" TabIndex="27" CssClass="autowidupdatebut"
                            OnClientClick="return validate();" runat="server" OnClick="btnSaveNew_Click" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                            tabindex="29" id="btnCancel" />
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
