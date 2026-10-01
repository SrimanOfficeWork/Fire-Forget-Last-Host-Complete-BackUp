<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bond_Details.aspx.cs" Inherits="Transaction_Bond_Details" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bond Details | Updation</title>
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
            <script type="text/javascript">
         
            </script>



            <div id="trans_IGM_bond_Main_Cont">

             
                <div id="pop_text_area_transac_popup_inn_container_IGM_Bond2">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_Bond">

                        <div id="tag_transac_lft_IGM_in1" style="width:350px">
                        
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Bond No
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtBondNo" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="1" ClientIDMode="Static"  onblur="Bond_aval_amt()" onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width:350px">
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Bond Location
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:TextBox ID="txtBondLocation" runat="server" onkeyup="ChangeCase(this);autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"
                                    MaxLength="50" TabIndex="2" ClientIDMode="Static" onblur="Bond_aval_amt()"></asp:TextBox>
                            </div>
                            <div id="magnify_area" runat="server">
                                <a href="#" class="magnfy" onclick="OpenPopupCustom_House('BOND_LOCATION'); return false"
                                    tabindex="6"></a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_IGMBOND_in1" style="width:350px">
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Bond Type
                            </div>
                            <div id="txtcon-m_transaction_list1_bondtype">
                                <asp:DropDownList ID="ddlBondType" runat="server" ClientIDMode="Static" CssClass="listtxt_transac_bondtype"
                                    TabIndex="3" onblur="Bond_aval_amt()">
                                    <%-- <asp:ListItem>F</asp:ListItem>
                                <asp:ListItem>L</asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
           <div  id="pop_text_area_transac_popup_inn_container_left_IGM_Bond" style="margin-left:350px; margin-top:-60px"  runat="server" visible="false">

                      <div id="tag_transac_lft_IGM_in1"  style="width:380px">
                      <div id="tag_label_transaction_popup_IGM_Container" style="width:150px">
                                Avilable Bond Amount
                            </div>

                      <div id="txtcon-m_transaction_code">
                                 <asp:TextBox ID="txt_avail" runat="server" ClientIDMode="Static" ReadOnly="true" style="width:100px" onkeyup="autotab(this)" CssClass="txtbox_none_Mid_transac_pop_gen_srcic" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                      
                      </div>
                      <div id="tag_transac_lft_IGM_in1"  style="width:350px">
                         <div id="tag_label_transaction_popup_IGM_Container" style="width:150px">
                                 Bond Amount
                            </div>

                      <div id="txtcon-m_transaction_code" >
                                 <asp:TextBox ID="txt_Amt" runat="server"  onkeyup="autotab(this)" style="width:100px"
                                    CssClass="txtbox_none_Mid_transac_pop_gen_srcic" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                      </div>

                      <%--  <div id="editbu">
                        <asp:Button ID="BOND_UPDATE" runat="server" Text="BOND_AMT_UPDATE" style="width:140px"
                            TabIndex="4" UseSubmitBehavior="false" OnClick="BOND_AMT_SELECT"  OnClientClick="return SetBondValuesBeforeUpdate();"   />
                    </div>
--%>
                      <div id="editbu">
    <asp:Button ID="BOND_UPDATE" runat="server" Text="CALCULATE BOND" style="width:140px" TabIndex="4" OnClick="BOND_AMT_SELECT" OnClientClick="return SetBondValuesBeforeUpdate();" />
</div>
              </div>


                </div>
                <div id="innerbox_transac_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hide')"
                            CausesValidation="false" UseSubmitBehavior="false" TabIndex="7" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="bond" CssClass="save" OnClick="btnSave_Click"
                            OnClientClick="return validate(event)" TabIndex="4" />
                    </div>

                     <div id="editbu">
                        <asp:Button ID="btn_save_new" Text="Save & New" CssClass="autowidupdatebut" TabIndex="30"
                            runat="server" OnClientClick="return validate(event)" OnClick="btn_save_new_Click" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" ValidationGroup="bond" CssClass="updates"
                            TabIndex="4" OnClick="btnUpdate_Click" OnClientClick="return validate(event)"
                            Visible="false" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="5" Visible="false" CssClass="dlete"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'BOND', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="5" OnClick="btnDelete_Click" OnClientClick="return validate();"
                            CssClass="dlete" Style="display: none;" />
                    </div>
                    <div id="editbu">
                     <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('IGM');return false;"
                        tabindex="6" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                     <%--   <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button();"
                            tabindex="6" id="btnCancel" />--%></div>
                </div>
                <div id="pop_text_area_transac_popup_inn_container_IGM_Bond2_grid" style="width:700px; overflow:auto; height:186px;">
                    <asp:GridView ID="gv_BOND" runat="server" DataKeyNames="BONDID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                        ShowHeaderWhenEmpty="True" PageSize="7" AllowPaging="True" OnRowDataBound="gv_BOND_RowDataBound"
                        OnPageIndexChanging="gv_BOND_PageIndexChanging" OnSelectedIndexChanged="gv_BOND_SelectedIndexChanged"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_BOND_RowCreated">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                   

                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="BOND_NO" HeaderText="Bond No" ControlStyle-Width="70px">
                                <ItemStyle CssClass="column_style_left" Width="70px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BOND_TYPE" HeaderText="Bond Type">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BOND_LOCATION" HeaderText="Bond Location">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="BOND_AMT" HeaderText="Bond AMT">
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
            <asp:HiddenField ID="hdn_update_Bond" runat="server" />
            <asp:HiddenField ID="hdfTransport_mode" runat="server" />
            <asp:HiddenField ID="hdn_Customhouse_chk" runat="server" ClientIDMode="Static" />
             <asp:HiddenField ID="hfBondNo"       runat="server" ClientIDMode="Static"  />
            <asp:HiddenField ID="hfBondLocation" runat="server" ClientIDMode="Static"  />
            <asp:HiddenField ID="hfBondType"     runat="server" ClientIDMode="Static"  />

        </ContentTemplate>
         <Triggers>
        <asp:PostBackTrigger ControlID="BOND_UPDATE" />
    </Triggers>
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
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_Bond.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
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

        
    <script type="text/javascript">

        function Bond_aval_amt() {
            var bond_no = document.getElementById("txtBondNo").value;
            var bond_location = document.getElementById("txtBondLocation").value;
            var bond_type = document.getElementById("ddlBondType").value;
            if (bond_no != "" && bond_location != "" && bond_type != "") {

                PageMethods.GET_BOND_AVAILE_AMT(bond_no, bond_location, bond_type,
                function (result) {
                    document.getElementById('<%= txt_avail.ClientID %>').value = result;
                },
            function (error) {
                alert("Error: " + error.get_message());
            });
            }

        }


        function SetBondValuesBeforeUpdate() {
            var bond_no = document.getElementById("txtBondNo").value.trim();
            var bond_location = document.getElementById("txtBondLocation").value.trim();
            var bond_type = document.getElementById("ddlBondType").value.trim();

            if (bond_no === "" || bond_location === "" || bond_type === "") {
                alert("Please enter Bond No, Bond Location and Bond Type!");
                return false;
            }


            document.getElementById("hfBondNo").value = bond_no;
            document.getElementById("hfBondLocation").value = bond_location;
            document.getElementById("hfBondType").value = bond_type;

            return true;
        }

    </script>


</body>
</html>
