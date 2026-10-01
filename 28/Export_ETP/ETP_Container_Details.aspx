<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ETP_Container_Details.aspx.cs" Inherits="ETP_Container_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> ETP Container | Updation</title>
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
            <div id="trans_IGM_Container_Main_Cont">
                <div id="pop_text_area_transac_popup_inn_container_IGM_Container2" style="width:910px;">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_Container" style="width:900px;">

                    <div id="tag_transac_lft_IGM_in1"  style="width:895px"></div>

                        <div id="tag_transac_lft_IGM_in1"  style="width:895px">
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Job No <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" Style="width: 130px">
                                <asp:DropDownList ID="ddl_Jobno" runat="server" Width="120px" CssClass="listtxt_transac_FCL" TabIndex="5">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Container"  Style="width: 110px">
                                Job Date <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" Style="width: 110px">
                                <asp:TextBox ID="txtJobDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="6"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Container">
                                SB No <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" Style="width: 110px">
                               <asp:TextBox ID="txt_SbNo" Width="100px" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_exp_invoice_addr"
                                    TabIndex="7" MaxLength="17" Enabled="true"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Container">
                                SB Date <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" Style="width: 110px">
                                <asp:TextBox ID="txt_SbDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="8" Enabled="true"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_SbDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_SbDate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                            </div>
                            
                        </div>
                        <div id="tag_transac_lft_IGM_in1"  style="width:895px">
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Containe No <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" Style="width: 130px">
                                <asp:TextBox ID="txt_Con_no" runat="server" CssClass="txtbox_none_Mid_transac_code" onkeypress="return charnum2(event)"
                                    MaxLength="11" TabIndex="9" Style="width: 115px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Container" Style="width: 110px">
                               Containe Size <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" Style="width: 110px">
                                 <asp:TextBox ID="txt_Con_Size" runat="server" CssClass="txtbox_none_Mid_transac_code" onkeypress="return charnum2(event)"
                                    MaxLength="11" TabIndex="10" Style="width: 100px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_Container">
                                FCL/LCL <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" Style="width: 110px">
                              <asp:RadioButtonList ID="Rd_Lcl_Fcl" runat="server" RepeatDirection="Horizontal" TabIndex="11" ForeColor="Purple"> 
                                <asp:ListItem Text="LCL" Value="L" ></asp:ListItem>
                                <asp:ListItem Text="FCL" Value="F"></asp:ListItem>
                            </asp:RadioButtonList>

                            </div>
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Site ID <span style="color:Red;" >* </span>
                            </div>
                            <div id="txtcon-m_transaction_code" Style="width: 110px">
                                <asp:TextBox ID="txt_Site_Id" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_code" onkeypress="return charnum2(event)"
                                    MaxLength="11" TabIndex="12" Style="width: 100px"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div id="tag_transac_lft_IGM_in1" style="width: 510px">
                            
                        </div>
                        
                    </div>
                </div>
                <div id="innerbox_transac_bot_inn" style="width:460px">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="21" OnClick="btnNew_Click"
                            OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                            UseSubmitBehavior="false" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="draw" CssClass="save" OnClick="btnSave_Click"
                            TabIndex="20" OnClientClick="return validate();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" ValidationGroup="draw" CssClass="updates"
                            OnClick="btnUpdate_Click" Visible="false" TabIndex="20" 
                            OnClientClick="return validate();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="22" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'CONTAINER', function(r) {
                          var i = r + 'ok';
                          if(i == 'trueok')
                          {
                              document.getElementById('btn').click();
                          }
                          else {
                          }
                         });return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="22" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                   <%-- <div id="editbu">
                        <asp:Button ID="btnSaveNew" Text="Save  & New" TabIndex="6" CssClass="autowidupdatebut"
                            OnClientClick="return validate();" runat="server" 
                            onclick="btnSaveNew_Click" />
                    </div>--%>
                    <div id="editbu">
                     <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('IGM');return false;"
                        tabindex="25" CausesValidation="false"  UseSubmitBehavior="false"/>
                        </div>

                    <div id="editbu" style="width:30px;"></div>
                    <div id="editbu">
                        <asp:Button ID="btnDel_All" runat="server" CssClass="autowidupdatebut" Text="Delete All" TabIndex="26" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete All Containers ?', 'CONTAINER', function(r) {
                              var i = r + 'ok';
                              if(i == 'trueok')
                              {
                                  document.getElementById('btn_DeleteAll').click();
                              }
                              else {
                              }
    
                            });return false;" />
                        <asp:Button ID="btn_DeleteAll" runat="server" TabIndex="5" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btn_DeleteAll_Click"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                </div>

                <div id="pop_text_area_transac_popup_inn_container_IGM_Container2_grid"  style="width:910px;">
                    <asp:GridView ID="gv_Container" runat="server" DataKeyNames="C_ID,JOBNO" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                        ShowHeaderWhenEmpty="True" PageSize="12" AllowPaging="True" OnRowDataBound="gv_Container_RowDataBound"
                        OnPageIndexChanging="gv_Container_PageIndexChanging" OnSelectedIndexChanged="gv_Container_SelectedIndexChanged"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_Container_RowCreated">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="44px">
                                <ItemTemplate>
                                    <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="44px" />
                            </asp:TemplateField>
                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="JOBNO_PS" HeaderText="JobNo">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="JOBDATE" HeaderText="JobDate">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SB_NO" HeaderText="SB No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SB_DATE" HeaderText="SB Date">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CON_NO" HeaderText="Container No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CON_SIZE" HeaderText="Con. Size">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LCL_FCL" HeaderText="LCL / FCL">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SITE_ID" HeaderText="Site ID">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
               
               <asp:HiddenField ID="HDupdate_id" runat="server" />
               <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
               
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>

    </form>
    <script src="../js/Import_Jscript/Import_Container.js" type="text/javascript"></script>
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
