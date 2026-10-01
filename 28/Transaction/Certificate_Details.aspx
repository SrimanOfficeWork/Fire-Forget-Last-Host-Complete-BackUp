<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Certificate_Details.aspx.cs"
    Inherits="Transaction_Certificate_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Certificate Details</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
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
<body >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="trans_IGM_bond_Main_Cont">
                <div id="pop_text_area_transac_popup_inn_container_IGM_Container2">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_Container">
                        <div id="tag_transac_lft_IGM_in1">
                            <div id="tag_label_transaction_popup_IGM_Certificate">
                                Certificate No
                            </div>
                            <div id="txtcon-m_transaction_code">
                                 <asp:TextBox ID="txtCertificateNo" runat="server" MaxLength="30" TabIndex="1" CssClass="txtbox_none_Mid_transac_code"  style="text-transform:uppercase;"></asp:TextBox>
                            </div> 
                        </div>
                        <div id="tag_transac_lft_IGM_in1">
                            <div id="tag_label_transaction_popup_IGM_Certificate">
                                Certificate Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtCertificateDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="30" TabIndex="2"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender4"
                                        runat="server" TargetControlID="txtCertificateDate" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtCertificateDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                <%-- <asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txtCertificateDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>--%>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1">
                            <div id="tag_label_transaction_popup_IGM_Certificate">
                                Certificate Type
                            </div>
                            <div id="txtcon-m_transaction_list1_bondtype">
                                <asp:DropDownList ID="ddlCertificateType" runat="server" CssClass="listtxt_transac_bondtype"
                                    TabIndex="3">
                                    <%-- <asp:ListItem>F</asp:ListItem>
                                <asp:ListItem>L</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide')"
                            CausesValidation="false" UseSubmitBehavior="false" TabIndex="7" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="certificate" CssClass="save"
                            OnClick="btnSave_Click" TabIndex="4" OnClientClick="return validate();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" ValidationGroup="certificate" CssClass="updates"
                            OnClick="btnUpdate_Click" Visible="false" TabIndex="4" OnClientClick="return validate();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="5" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'CERTIFICATE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="5" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                            CssClass="dlete" Style="display: none;" />
                    </div>

                      <div id="editbu">
                        <asp:Button ID="btnSaveNew" Text="Save  & New" TabIndex="6" CssClass="autowidupdatebut"
                            OnClientClick="return validate();" runat="server" OnClick="btnSaveNew_Click" />
                    </div>

                    <div id="editbu">
                     <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('IGM');return false;"
                        tabindex="6" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                      </div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_IGM_Container2_grid" style=" width:600px; overflow:auto;">
               
                    <asp:GridView ID="gv_Certificate" runat="server" DataKeyNames="CERTIFICATEID" EmptyDataText="NO RECORD FOUND" 
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                        ShowHeaderWhenEmpty="True" PageSize="7" AllowPaging="True" OnRowDataBound="gv_Certificate_RowDataBound"
                        OnPageIndexChanging="gv_Certificate_PageIndexChanging" OnSelectedIndexChanged="gv_Certificate_SelectedIndexChanged"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_Certificate_RowCreated">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="CERTIFICATE_NO"  HeaderText="Certificate No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CERTIFICATE_DATE"  HeaderText="Date">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CERTIFICATE_TYPE"  HeaderText="Type">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                     <PagerStyle CssClass="pager" />
                                    <EmptyDataTemplate>
                                        NO RECORD FOUND
                                    </EmptyDataTemplate>

                    </asp:GridView>
                   
                </div>
            </div>
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdn_update_Certificate" runat="server" />
            <asp:HiddenField ID="hdn_CompanyID" runat="server" />
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
    <script src="../js/Import_Jscript/Import_Certificate.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/Autotab.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery-1.js" type="text/javascript">
    </script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
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
    <!-- VALIDATION SCRIPT -->
</body>
</html>
