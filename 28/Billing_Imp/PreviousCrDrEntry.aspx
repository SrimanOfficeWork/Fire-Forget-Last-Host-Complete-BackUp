<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreviousCrDrEntry.aspx.cs"
    Inherits="PreviousCrDrEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Previous Cr Dr Entry </title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
    
    
    <script type="text/javascript">
        function balance() {
           // alert("ff");
            var cr = parseFloat(document.getElementById("txtCredit").value);
            var dr = parseFloat(document.getElementById("txtDebit").value);
            var res = parseFloat(dr) - parseFloat(cr);
            document.getElementById("txtBalance").value = res;
        }
</script>

    
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain" style="height: 115px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                        Prev Cr/Dr-Entry
                    </div>
                   
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2">
                        <span runat="server" id="WK" visible="false">
                            <div id="tag_label_transaction_popup_gen">
                                Working Period</div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlWorkingPeriod_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </span>
                    </div>
                   
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                    
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px;height:150px">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px;height:150px">
                        <div id="tag_transact_lft_in1" style="width: 1100px; height:150px">
                            <div style="width: 1100px; height: 30px">
                                <div id="txt_container_Transact_Main_l" style="width: 300px;">
                                    <div id="tag_label_transact_Src" style="width: 80px;">
                                        Customer:
                                    </div>
                                    <div id="txtcon-m_Exchange">
                                        <asp:DropDownList ID="ddlCustomerName" CssClass="listtxt_transac_item_gen_notn" Width="250px"
                                            runat="server" TabIndex="0"  >
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            
                             
                            </div>
                           
                        </div>
                    </div>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -30px;">
                <%---28 --%>
                <div id="innerbox_MidMain_Trans_new" style="height: 300px; width: 1000px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                            id="Page_A" runat="server"><span>General </span></a></li>
                        <li><a href="#page-7" runat="server">
                            <%--onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B"--%>
                        </a></li>
                        <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                            id="Page_C" runat="server" visible="false"><span>Gen -3</span></a></li>
                        <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                            id="Page_D" runat="server" visible="false"><span>Gen -4 </span></a></li>
                    </ol>
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 200px;
                            margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1150px; height: 150px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1150px">
                                    <div style="width: 1100px; height: 100px">
                                        <div id="txt_container_Transact_Main_l">
                                            <div id="tag_label_transact_Src" style="width: 90px;">
                                                Previous Debit :
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                

                                                    <asp:TextBox ID="txtDebit" runat="server" MaxLength="20" TabIndex="1"  CssClass="txtbox_none_Mid_transac_code" onblur="extractNumber(this,2,false);"
                                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);" onchange="balance()"></asp:TextBox>

                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l">
                                            <div id="tag_label_transact_Src" style="width: 90px;">
                                                Previous Credit :
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txtCredit" Width="150px" runat="server" MaxLength="20"  
                                                    TabIndex="2" CssClass="txtbox_none_Mid_transac_code" onblur="extractNumber(this,2,false);"
                                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this); " onkeypress="return blockNonNumbers(this, event, true, false);"  onchange="balance()" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_l">
                                            <div id="tag_label_transact_Src" style="width: 60px;">
                                                Balance :
                                            </div>
                                            <div id="txtcon-m_Exchange">
                                                <asp:TextBox ID="txtBalance" runat="server" MaxLength="20" TabIndex="3"  CssClass="txtbox_none_Mid_transac_code"  ></asp:TextBox>
                                            </div>
                                        </div>

                                      
                                        
                                        <div id="txt_container_Transact_Main_l">
                                         <div id="tag_label_transact_Src" style="width: 90px;">
                                                Entry Date:
                                            </div>
                                            <div id="txtcon-m_Exchange" style="width: 85px">
                                                <asp:TextBox ID="txtDate" runat="server" Width="82px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                    TabIndex="4"></asp:TextBox>
                                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                    Enabled="True">
                                                </asp:MaskedEditExtender>
                                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                                    Format="dd/MM/yyyy" Enabled="True">
                                                </asp:CalendarExtender>
                                            </div>                                          
                                        </div>


                                          <div id="txt_container_Transact_Main_l">
                                         <div id="tag_label_transact_Src" style="width: 90px;">
                                                Narration :
                                            </div>
                                              <div id="txtcon-m_Exchange" style="width: 85px">
                                                <asp:TextBox ID="txtCommNarration" runat="server" MaxLength="1000" TextMode="MultiLine"
                                                    Style="width: 615px; height: 30px" TabIndex="5"></asp:TextBox>
                                            </div>
                                            </div>

                                    </div>
                                  
                                    
                                 
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-------------------------------------------------------------------------------%>
            </div>
            <%-- --------------------Test Start----------------------------%>
            <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click1" TabIndex="7" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate_PrevCrDr();"
                            TabIndex="6" OnClick="btnSave_Click" CommandName="s" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" TabIndex="8"
                            OnClientClick="return validate_Exp();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="9" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Credit/Debit', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="123" OnClick="btnDelete_Click" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                            id="btnCancel" tabindex="16">
                    </div>
                    <div id="editbu" style="width: 10px;">
                    </div>
                    <div id="editbu" style="padding-top: 5px;">
                        <asp:Button ID="btnrpt" runat="server" TabIndex="125" Text="Get Bill" OnClientClick="return GST_Import_Billing_Job_Rpt('B');" />
                        
                    </div>
                </div>
            </div>
            <%-- --------------------Test End----------------------------%>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    
     <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });


        function close_button() {
            document.getElementById("General").click();
        }
        

    </script>
  
</body>
</html>
