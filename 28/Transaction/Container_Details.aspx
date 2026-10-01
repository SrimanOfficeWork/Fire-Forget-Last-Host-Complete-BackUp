<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Container_Details.aspx.cs"
    Inherits="Transaction_Container" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ADCode Master | Updation</title>
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
                <div id="pop_text_area_transac_popup_inn_container_IGM_Container2" style="width:700px;">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_Container" style="width:700px;">



                        <div id="tag_transac_lft_IGM_in1"  style="width:700px">
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Container No
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <%--<asp:TextBox ID="txtContainerNo" runat="server" CssClass="minSize[11]] txtbox_none_Mid_transac_code" onkeypress="return charnum2(event)"
                                    MaxLength="11" TabIndex="1" Style="width: 100px"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtContainerNo" runat="server" CssClass="minSize[11]] txtbox_none_Mid_transac_code"
                                    onkeypress="return containerKeyPress(event)" oninput="sanitizeContainerNo(this)"
                                    MaxLength="11" TabIndex="1" Style="width: 100px"></asp:TextBox>
                            </div>
                            <%--   -----------truck No -------S--%>
                            <div id="tag_label_transaction_popup_IGM_Container" style="padding-left: 20px;">
                                Truck No
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:TextBox ID="txttruckrNo" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen_srcic" MaxLength="20"
                                    TabIndex="5"></asp:TextBox>
                            </div>
                            <%-- ----------truck No -------E-----%>

                            
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>
                           
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 610px">
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Seal No
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtSealNo" runat="server" MaxLength="10" CssClass=" txtbox_none_Mid_transac_code"
                                    TabIndex="2"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="width:170px;"></div>
                            <div id="div_AmendmentType"  Visible="false" runat="server"  style="margin-top:-8px">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 80px;
                                font-weight: bold;">
                                Amend Type
                            </div>
                            <div id="txtcon-m_transaction_code_BE_TYPE" style="width: 100px;">
                                <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="5" CssClass="listtxt_transac_mode_new"
                                    Width="100px">
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="S">SUPPLIMENT</asp:ListItem>
                                    <asp:ListItem Value="D">DELETE</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             <div id="editbu" style="margin-top:-5px;">
                                            <asp:Button ID="btn_Amend_FF" Text="Flatfile" CssClass="autowidmovebut" runat="server"
                                                OnClientClick="Open_Amend_Flatfile(); return false" Width="60px" />
                                        </div>
                            </div>

                            <%--<div id="tag_label_transaction_popup_IGM_Container" style="padding-left: 20px;">
                                Truck No
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:TextBox ID="txttruckrNo" runat="server" CssClass="txtbox_none_Mid_transac_pop_gen_srcic" MaxLength="20"
                                    TabIndex="5"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width:700px">
                            <div id="tag_label_transaction_popup_IGM_Container">
                                FCL / LCL
                            </div>
                            <div id="txtcon-m_transaction_list1_fcl">
                                <asp:DropDownList ID="ddlFCL_LCL" runat="server" CssClass="listtxt_transac_FCL" TabIndex="3">
                                    <asp:ListItem>F</asp:ListItem>
                                    <asp:ListItem>L</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                              <div id="tag_label_transaction_popup_Invoice_Date"  style="width:220px">
                        </div>
                         <div id="tag_label_transaction_annuxeairC" style="width:140px">
                            Bulk Container Upload
                        </div>
                      
                         <a href="../Submission/Import_Excel_Format/Import Container Upload.xlsx" target="_new">Download Excel
                                 Format </a>

                        </div>
                        <div id="tag_transac_lft_IGM_in1" style="width: 700px">
                            <div id="tag_label_transaction_popup_IGM_Container">
                                Type
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="txtbox_none" TabIndex="4">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>40</asp:ListItem>
                                    <asp:ListItem>40HC</asp:ListItem>
                                    <asp:ListItem>20 Bulk</asp:ListItem>
                                    <asp:ListItem>20 Bulk-22B0</asp:ListItem>
                                    <asp:ListItem>20 Collapsible Flat Rack</asp:ListItem>
                                    <asp:ListItem>20 Collapsible Flat Rack-22P3</asp:ListItem>
                                    <asp:ListItem>20 Flat Rack</asp:ListItem>
                                    <asp:ListItem>20 Flat Rack-22P1</asp:ListItem>
                                    <asp:ListItem>20 Hard Top</asp:ListItem>
                                    <asp:ListItem>20 Hard Top-22UP</asp:ListItem>
                                    <asp:ListItem>20 Open Top</asp:ListItem>
                                    <asp:ListItem>20 Open Top-22U1</asp:ListItem>
                                    <asp:ListItem>20 Platform</asp:ListItem>
                                    <asp:ListItem>20 Platform-29P0</asp:ListItem>
                                    <asp:ListItem>20 Reefer</asp:ListItem>
                                    <asp:ListItem>20 Reefer-22R1</asp:ListItem>
                                    <asp:ListItem>20 Standard Dry</asp:ListItem>
                                    <asp:ListItem>20 Standard Dry-22G0</asp:ListItem>
                                    <asp:ListItem>20 Tank</asp:ListItem>
                                    <asp:ListItem>20 Tank-22T0</asp:ListItem>
                                    <asp:ListItem>40 Collapsible Flat Rack</asp:ListItem>
                                    <asp:ListItem>40 Collapsible Flat Rack-42P3</asp:ListItem>
                                    <asp:ListItem>40 Flat Rack</asp:ListItem>
                                    <asp:ListItem>40 Flat Rack-42P1</asp:ListItem>
                                    <asp:ListItem>40 Hard Top</asp:ListItem>
                                    <asp:ListItem>40 Hard Top-42UP</asp:ListItem>
                                    <asp:ListItem>40 High Cube</asp:ListItem>
                                    <asp:ListItem>40 High Cube-45G0</asp:ListItem>
                                    <asp:ListItem>40 Open Top</asp:ListItem>
                                    <asp:ListItem>40 Open Top-42U1</asp:ListItem>
                                    <asp:ListItem>40 Platform</asp:ListItem>
                                    <asp:ListItem>40 Platform-49P0</asp:ListItem>
                                    <asp:ListItem>40 Reefer</asp:ListItem>
                                    <asp:ListItem>40 Reefer-42R1</asp:ListItem>
                                    <asp:ListItem>40 Reefer High Cube</asp:ListItem>
                                    <asp:ListItem>40 Reefer High Cube-45R1</asp:ListItem>
                                    <asp:ListItem>40 Standard Dry</asp:ListItem>
                                    <asp:ListItem>40 Standard Dry-42G0</asp:ListItem>
                                    <asp:ListItem>40 Tank</asp:ListItem>
                                    <asp:ListItem>40 Tank-42T0</asp:ListItem>
                                    <asp:ListItem>40 Reefer</asp:ListItem>
                                    <asp:ListItem>45</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_Invoice_Date" style="width: 50px">
                            </div>
                            <div id="tag_label_transaction_annuxeairC" style="width: 120px">
                                Select Excel File
                            </div>
                            <div id="txtcon-m_src_ItemMove">
                                <asp:FileUpload ID="fileuploadExcel" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

              
                            <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_det_Inv_S_No" style="height: 29px; margin-top:-10px;width:170px;">
                                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                                    <div id="tag_label_transaction_popup_IGM_invoice_det1_new" style="font-weight:bold; width:70px;">
                                        IGM SlNo :
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                        <asp:DropDownList ID="ddlIGM_SL_No" runat="server" CssClass="listtxt_transac_src1"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlIGM_SL_No_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
               
                <div id="innerbox_transac_bot_inn" style="width:460px">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="7" OnClick="btnNew_Click"
                            OnClientClick="jQuery('#form1').validationEngine('hide')" CausesValidation="false"
                            UseSubmitBehavior="false" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="draw" CssClass="save" OnClick="btnSave_Click"
                            TabIndex="6" OnClientClick="return validate() && validateContainerNo();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" ValidationGroup="draw" CssClass="updates"
                            OnClick="btnUpdate_Click" Visible="false" TabIndex="6" 
                            OnClientClick="return validate() && validateContainerNo();" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="7" CausesValidation="false"
                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'CONTAINER', function(r) {
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
                            OnClientClick="return validate() && validateContainerNo();" runat="server" 
                            onclick="btnSaveNew_Click" />
                    </div>
                    <div id="editbu">
                     <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('IGM');return false;"
                        tabindex="8" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />
                        </div>

                    <div id="editbu" style="width:30px;"></div>
                    <div id="editbu">
                        <asp:Button ID="btnDel_All" runat="server" CssClass="autowidupdatebut" Text="Delete All" TabIndex="7" CausesValidation="false"
                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete All Containers for All IGM ?', 'CONTAINER', function(r) {
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


                 <div id="editbu">
                            <asp:Button ID="btn_BulkContainer_Upload" runat="server" 
                                CssClass="autowidmovebut" Text="Upload"
                                TabIndex="115"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');" onclick="btn_BulkContainer_Upload_Click"
                              style="margin-left:130px" />
                        </div>



                <div id="pop_text_area_transac_popup_inn_container_IGM_Container2_grid">
                    <asp:GridView ID="gv_Container" runat="server" DataKeyNames="CONTAINERID" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                        ShowHeaderWhenEmpty="True" PageSize="12" OnRowDataBound="gv_Container_RowDataBound" OnSelectedIndexChanged="gv_Container_SelectedIndexChanged"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_Container_RowCreated">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                         <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="44px" >
                                        <ItemTemplate  >
                                        <asp:Label ID="lblitemslno"  runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  HorizontalAlign="Center"   Width="44px"  />
                                    </asp:TemplateField>

                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="CONTAINER_NO" HeaderText="Container No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>

                            <asp:BoundField DataField="SEAL_NO" HeaderText="Seal No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FCL_OR_LCL" HeaderText="FCL / LCL">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTAINER_IGM_SLNO">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CONTAINER_IGM_NO">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                           
                            <asp:BoundField DataField="TYPE" HeaderText="TYPE">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>

                              <asp:BoundField DataField="TRUCK_NO" HeaderText="Truck No">
                                <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>

                            <asp:BoundField DataField="AMENDMENT_TYPE" HeaderText="AmendmentType">
                               <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>

                              <asp:BoundField DataField="CONTAINER_IGM_DATE" HeaderText="AmendmentType">
                               <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>

                        </Columns>
                    </asp:GridView>
                </div>
                <asp:HiddenField ID="hdn_update_Container" runat="server" />
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdn_TransportMode" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="Hdn_containertype" runat="server" />
             <asp:HiddenField ID="hdn_Jobno" runat="server"  />

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 125px; padding-top: 10px;">
                        <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>


    <asp:ModalPopupExtender ID="mp_yesorno" runat="server" PopupControlID="Panel2" TargetControlID="HDU2"
        CancelControlID="btnclose1" BackgroundCssClass="modalBackground"  >
    </asp:ModalPopupExtender>
     <asp:HiddenField ID="HDU2" runat="server" />
    <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" align="center" Style="display: none;
        width: 300px; height: 140px; margin-top: -70px;" BorderColor="Transparent">
        <asp:Button ID="btnclose1" runat="server" Style="display: none" />
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 130px;">
            <div id="innerbox_MidMain_top_adcode_Itemmove" style="width: 300px;">
                Container
                <div id="popupwindow_closebut_right">
                    <input type="close" value="Submit" class="clsicon" onclick="$find('mp_yesorno').hide();" />
                </div>
            </div>
            <div id="innerbox_MidMain_Mid_adcode_Itemmove1">
                <div id="pop_text_area_ItemMove">
                    <div id="tag_label_adcode">
                    </div>
                    <div id="txtcon-m_src_ItemMove" style="width: 300px;">
                        <asp:Label ID="lbl_Excel_msg" runat="server" Text="Container already exists!.. Delete all Containers in this current IGM SlNo ?"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div id="innerbox_MidMain_top_adcode_Itemmove" style="width: 300px; height: 40px;">
            <div id="innerbox_adcode_bot_inn_ItemMove" style="float: right; padding-right: 2px;
                width: 180px;">
                <div id="editbu">
                    <asp:Button ID="btn_Delete_All_Invoice_And_Upload" runat="server" CausesValidation="false"
                        OnClick="btn_Delete_All_Invoice_And_Upload_Click" UseSubmitBehavior="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                </div>
                <div id="editbu">
                    <asp:Button ID="Button5" runat="server" class="scancel" OnClientClick="$find('mp_yesorno').hide();return false;"
                        CausesValidation="false" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </asp:Panel>




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

        function Open_Amend_Flatfile() {
            var amd_type = document.getElementById("ddl_AmendmentType").value;
            var amd_page = 'CONTAINER';
            var amd_Jobno = document.getElementById("hdn_Jobno").value;

            NewWindow1('../Amendment/Import_Amendment.aspx?amd_type=' + amd_type + '&amd_page=' + amd_page + '&amd_Jobno=' + amd_Jobno, 'List', '950', '515', 'yes');
        }
        function isSeaMode() {
            var m = document.getElementById('hdn_TransportMode');
            return m && m.value === 'Sea';
        }

        
        function containerKeyPress(evt) {
            if (!isSeaMode()) return charnum2(evt);
            evt = evt || window.event;
            var code = evt.which || evt.keyCode;
            if (code === 0 || code < 32 || evt.ctrlKey || evt.metaKey) return true;  
            var txt = evt.target || evt.srcElement;
            var ch = String.fromCharCode(code);
            var ok = (txt.selectionStart < 4) ? /[A-Za-z]/.test(ch) : /[0-9]/.test(ch);
            if (!ok) { if (evt.preventDefault) evt.preventDefault(); return false; }
            return true;
        }
 
        function sanitizeContainerNo(txt) {
            if (!isSeaMode()) return;
            var v = txt.value.toUpperCase().replace(/[^A-Z0-9]/g, '');
            var out = '';
            for (var i = 0; i < v.length && out.length < 11; i++) {
                var c = v.charAt(i);
                if (out.length < 4) { if (/[A-Z]/.test(c)) out += c; }
                else if (/[0-9]/.test(c)) out += c;
            }
            if (txt.value !== out) {
                var pos = Math.min(txt.selectionStart, out.length);
                txt.value = out;
                txt.setSelectionRange(pos, pos);
            }
        }

        function validateContainerNo() {
            if (!isSeaMode()) return true;
            var txt = document.getElementById('txtContainerNo');
            var v = txt.value.toUpperCase();
            if (v !== '' && !/^[A-Z]{4}[0-9]{7}$/.test(v)) {
                jAlert('Container No must be 4 letters followed by 7 digits (e.g. FANU3387749)', 'CONTAINER', function () { txt.focus(); });
                return false;
            }
            return true;
        }

    </script>
    <!-- VALIDATION SCRIPT -->
</body>
</html>
