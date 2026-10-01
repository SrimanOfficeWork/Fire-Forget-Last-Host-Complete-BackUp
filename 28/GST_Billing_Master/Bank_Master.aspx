<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bank_Master.aspx.cs" Inherits="Bank_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bank Master | Updation</title>
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
           
            <div id="innerbox_MidMain_popup_adcode"  style="height:320px;width:750px;">
                <div id="innerbox_MidMain_top_adcode" style="width:750px;">
                    BANK MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <%--<div id="innerbox_MidMain_Mid_adcode">--%>
                <div id="innerbox_MidMain_Mid_ClientMaster" style="height: 290px;width:750px; margin-left:10px;">
                    <div id="innerbox_MidMain_Mid_ClientMaster_l" style="width:350px">
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                               &nbsp; Bank Name
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtBankName" runat="server" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="1" MaxLength="50"></asp:TextBox>
                               

                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                       
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                              &nbsp; Branch Name</div>
                            <div id="txtcon_mid_size">
                                <asp:TextBox ID="txtBranchName" runat="server" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="2" MaxLength="30"></asp:TextBox>
                               
                            
                            </div>
                        </div>

                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                              &nbsp;  Account Holder </div>
                            <div id="txtcon_mid_size">
                             <asp:TextBox ID="txt_AcHolder" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="3" MaxLength="50"></asp:TextBox>
                            </div>                           
                        </div>

                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                              &nbsp;  Account No </div>
                            <div id="txtcon-m_src">
                             <asp:TextBox ID="txt_AcNo" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="4" MaxLength="16"></asp:TextBox>
                            </div>
                           
                        </div>
                        
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                             &nbsp;   Account Type</div>
                            
                               <div id="txtcon-m_src">
                               
                            
                                    <asp:DropDownList runat="server" ID="ddlAcType" Width="150px" TabIndex="5"></asp:DropDownList>
                            </div>
                           
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                &nbsp; IFSC Code</div>
                            <div id="txtcon-m_src">
                               
                                <asp:TextBox ID="txtISCFCode" runat="server" CssClass="validate[required] txtbox_none"
                                    Onkeypress="return numchar(event)" TabIndex="6" MaxLength="20" 
                                    ></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                               &nbsp; Address1</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtAdd1" runat="server" CssClass="validate[required] txtbox_none"
                                    TabIndex="7" MaxLength="50" ></asp:TextBox></div>
                        </div>
                        <div id="pop_text_area">
                        <div id="tag_label_adcode">
                              &nbsp;  Address2</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtAdd2" runat="server" 
                                    CssClass="txtbox_none" MaxLength="50" 
                                     TabIndex="8"></asp:TextBox>
                            </div>
                           
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                              &nbsp;  City
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtCity" runat="server" CssClass="txtbox_none" TabIndex="9"
                                    Onkeypress="return numchar(event)" MaxLength="30"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                           <div id="tag_label_adcode">
                              &nbsp;  State
                            </div>
                            <div id="txtcon-m_src">
                                
                                
                                <asp:TextBox ID="txtStateName" runat="server" CssClass="txtbox_none" 
                                    MaxLength="40" Onkeypress="return numchar(event)" TabIndex="10"></asp:TextBox>
                             
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                              &nbsp;  Pin Code</div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtPinCode" runat="server" CssClass="txtbox_none" TabIndex="11"
                                    Onkeypress="return pin(event)" MaxLength="10"></asp:TextBox>
                            </div>
                        </div>
                        <div id="lblMsg2" style="display: none;">
                        </div>
                    </div>
                    <div id="innerbox_MidMain_Mid_ClientMaster_l" style="width:400px;">
                        <div id="pop_text_area">
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
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                ADCode
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtADCode" runat="server" CssClass="txtbox_none"
                                     MaxLength="12"   TabIndex="13"
                                    onkeypress="return numchar(event);"></asp:TextBox></div>
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
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Opening Balance
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtOpenBalance" runat="server"  CssClass="txtbox_none"
                                      onblur="extractNumber(this,2,false);return Clear_Dot(this);" 
              onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"  TabIndex="15"
                                     MaxLength="17" ></asp:TextBox>
                            </div>
                           
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Contact Person
                            </div>
                            <div id="txtcon-m_src" >
                                <asp:TextBox ID="txtContactPerson" runat="server" CssClass="txtbox_none" MaxLength="30" TabIndex="16" Onkeypress="return numchar(event);"
                           ></asp:TextBox> </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Contact Number
                            </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtContact_No" runat="server" CssClass="txtbox_none"
                                     MaxLength="10"  TabIndex="17"
                                    onkeypress="return pin(event);"></asp:TextBox></div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Email ID
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                                <asp:TextBox ID="txtEmailID" runat="server" CssClass="txtbox_none"
                                    TabIndex="18" MaxLength="30"  
                                   ></asp:TextBox></div>
                            
                          
                        </div>
                         <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Prefix
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                                <asp:TextBox ID="txtPrefix" runat="server" CssClass="txtbox_none"
                                    TabIndex="18" MaxLength="30"  
                                   ></asp:TextBox></div>
                            
                          
                        </div>
                         <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Suffix
                            </div>
                            <div id="txtcon-m_src" style="width: 100px;">
                                <asp:TextBox ID="txtSuffix" runat="server" CssClass="txtbox_none"
                                    TabIndex="18" MaxLength="30"  
                                   ></asp:TextBox></div>
                            
                          
                        </div>
                      
                    </div>
                </div>
                   </div>
                </div>
            </div>
            <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="19" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick="return validate_BANK();"
                            TabIndex="20" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            OnClientClick="return validate_BANK();" TabIndex="20" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="21" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'BANK MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click(); 
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="21" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu" style="display:none">
                        <asp:Button ID="btnSaveNew" Text="Save  & New" TabIndex="22" CssClass="autowidupdatebut"
                            OnClientClick="return validate();" runat="server" 
                            onclick="btnSaveNew_Click" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                            tabindex="23" id="btnCancel" />
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
