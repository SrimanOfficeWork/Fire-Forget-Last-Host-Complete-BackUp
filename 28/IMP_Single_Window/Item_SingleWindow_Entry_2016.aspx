<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Item_SingleWindow_Entry_2016.aspx.cs" Inherits="Item_SingleWindow_Entry_2016" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Item Single Window Entry 2016</title>
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
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>


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
            <div id="popupwindow_closebut_right_new" runat="server" visible="false">
                       <%--<input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />--%>
                        <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" />
                    </div>
            
              <div id="open_item" runat="server">
            <div id="innerbox_MidMain_Trans_Item_Main" style="height:357px;">
                <ol id="toc">
                    <li  style=" height:15px;" ><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page1('0');"
                        id="ItemMain"><span> SW info. Type  </span></a></li>
                    
                    <li  style=" height:15px;"><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SWConstituent('0');"
                        id="RE_IMPORT" runat="server" ><span> SW Constituent </span></a></li>

                        <li  style=" height:15px;"><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SWProduction('0');"
                        id="A1" runat="server" ><span>SW Production</span></a></li>

                       <li  style=" height:15px;"><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SW_Control('0');"
                        id="A2" runat="server" ><span>SW Control</span></a></li>

                        <li  style=" height:15px;"><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SW_Statement('0');"
                        id="A3" runat="server" ><span>Statement </span></a></li>

                       <%-- <li  style=" height:15px;"><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SW_Sup_Doc('0');"
                        id="A4" runat="server" ><span>Sup. Doc </span></a></li>--%>
                   
                </ol>
                <div class="content" id="page-1" style="height: 600px;">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier">
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 710px;">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 80px;">
                                Aval. Dept.
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                                <asp:DropDownList ID="ddldept" Width="80px" CssClass="listtxt_transac_item_gen_notn" 
                                    runat="server">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 60px;">
                                <span style="color: Blue; font-weight: bold;">RITC No. </span>
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 100px;">
                                <asp:TextBox ID="txt_RITCNO" runat="server" Enabled="false" Font-Bold="true" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    Width="90px"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                           <%-- <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 80px;">
                                <span style="color: Blue; font-weight: bold;">Aval. Dept. </span>
                            </div>--%>
                             <%--<div id="txtcon-m_transaction_Supp_code_Re_Import" style="font-size: small; width: 290px; visibility:hidden;
                                font-weight: bold; margin-top: 3px;">
                                <asp:Literal ID="lbl_avl_det" runat="server"></asp:Literal>
                            </div>--%>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import" style="font-size: small; width: 290px;
                                font-weight: bold; margin-top: 3px;">
                                   <asp:LinkButton ID="Lnk_Avail_Dept" runat="server" Text="Avail SW PGA Dept"   OnClientClick="Open_Icegate_Single_window_PGA(); return false" ></asp:LinkButton>
                                     <asp:Literal ID="lbl_avl_det" runat="server" Visible="false"></asp:Literal>
                            </div>
                           
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 660px;">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 80px;">
                                Info Type
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import">
                                <asp:DropDownList ID="ddl_info_type" runat="server" TabIndex="1" class="chosen-select-deselect"
                                    Style="width: 215px; font-family: Arial,Helvetica,sans-serif;" data-placeholder="Choose a Info. Type"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddl_info_type_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                Info Qualifier
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:DropDownList ID="ddl_Info_Qualifier" runat="server" TabIndex="2" class="chosen-select-deselect"
                                    Style="width: 215px; font-family: Arial,Helvetica,sans-serif;" data-placeholder="Choose a Info. Qualifier"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddl_Info_Qualifier_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 660px;">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 80px;">
                                Info code</div>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import">
                                <asp:DropDownList ID="ddl_Info_Code" runat="server" TabIndex="3" class="chosen-select-deselect"
                                    Style="width: 580px; font-family: Arial,Helvetica,sans-serif;" 
                                    data-placeholder="Choose a Info. Code" 
                                   AutoPostBack="true"  onselectedindexchanged="ddl_Info_Code_SelectedIndexChanged1">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 660px;">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 80px;">
                                Info Text
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import">
                                <asp:TextBox ID="txt_Info_Text" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    Width="220px" TabIndex="4" MaxLength="2000" onblur="validateDate()"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 65px;">
                                <asp:Label ID="lbl_info_MSR"  runat="server" ></asp:Label>
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 85px;">
                                <asp:TextBox ID="txt_Info_Msr" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    TabIndex="5" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="28"
                                    Width="80px"></asp:TextBox>
                                <asp:TextBox ID="txt_RegDate" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" Enabled="false"
                                    Width="90px" TabIndex="5" MaxLength="28"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_RegDate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_RegDate" Enabled="false"
                                    PopupButtonID="txt_RegDate" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 75px;">
                               <asp:Label ID="lbl_info_UQC"  runat="server"  ></asp:Label>  
                               <asp:Label ID="lbl_info_UQC_FTA"  runat="server"  ></asp:Label>  
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <%--      <asp:TextBox ID="txt_Info_Uqc" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp] txtbox_none_Mid_transac_item_maindet"
                         ClientIDMode="Static" Onkeypress="return char1(event)" onkeyup="return ChangeCase(this);"
                            TabIndex="6" MaxLength="3"></asp:TextBox>--%>
                                <asp:DropDownList ID="txt_Info_Uqc" runat="server" CssClass="listtxt_transac_mode_new" 
                                    TabIndex="6">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="KGS" Value="KGS"></asp:ListItem>
                                    <asp:ListItem Text="NOS" Value="NOS"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="txt_Info_Uqc_FTA" Visible="false" runat="server" CssClass="listtxt_transac_mode_new" 
                                    TabIndex="6">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="CC" Value="CC"></asp:ListItem>
                                    <asp:ListItem Text="CTH" Value="CTH"></asp:ListItem>
                                    <asp:ListItem Text="CTS" Value="CTS"></asp:ListItem>
                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                </asp:DropDownList>

                                <asp:DropDownList ID="ddl_validity" runat="server" CssClass="listtxt_transac_mode_new" 
                                     TabIndex="6">
                                   
                                    <asp:ListItem Text="75" Value="74"></asp:ListItem>
                                    <asp:ListItem Text="74" Value="73"></asp:ListItem>
                                    <asp:ListItem Text="73" Value="72"></asp:ListItem>
                                    <asp:ListItem Text="72" Value="71"></asp:ListItem>
                                    <asp:ListItem Text="71" Value="70"></asp:ListItem>
                                    <asp:ListItem Text="70" Value="69"></asp:ListItem>
                                    <asp:ListItem Text="69" Value="68"></asp:ListItem>
                                    <asp:ListItem Text="68" Value="67"></asp:ListItem>
                                    <asp:ListItem Text="67" Value="66"></asp:ListItem>
                                    <asp:ListItem Text="66" Value="65"></asp:ListItem>
                                    <asp:ListItem Text="65" Value="64"></asp:ListItem>
                                    <asp:ListItem Text="64" Value="63"></asp:ListItem>
                                    <asp:ListItem Text="63" Value="62"></asp:ListItem>
                                    <asp:ListItem Text="62" Value="61"></asp:ListItem>
                                    <asp:ListItem Text="61" Value="60"></asp:ListItem>
                                    <asp:ListItem Text="60" Value="59"></asp:ListItem>
                                    <asp:ListItem Text="59" Value="58"></asp:ListItem>
                                    <asp:ListItem Text="58" Value="57"></asp:ListItem>
                                    <asp:ListItem Text="57" Value="56"></asp:ListItem>
                                    <asp:ListItem Text="56" Value="55"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="54"></asp:ListItem>
                                    <asp:ListItem Text="54" Value="53"></asp:ListItem>
                                    <asp:ListItem Text="53" Value="52"></asp:ListItem>
                                    <asp:ListItem Text="52" Value="51"></asp:ListItem>
                                    <asp:ListItem Text="51" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="49"></asp:ListItem>
                                    <asp:ListItem Text="49" Value="48"></asp:ListItem>
                                    <asp:ListItem Text="48" Value="47"></asp:ListItem>
                                    <asp:ListItem Text="47" Value="46"></asp:ListItem>
                                    <asp:ListItem Text="46" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="44"></asp:ListItem>
                                    <asp:ListItem Text="44" Value="43"></asp:ListItem>
                                    <asp:ListItem Text="43" Value="42"></asp:ListItem>
                                    <asp:ListItem Text="42" Value="41"></asp:ListItem>
                                    <asp:ListItem Text="41" Value="40"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="39"></asp:ListItem>
                                    <asp:ListItem Text="39" Value="38"></asp:ListItem>
                                    <asp:ListItem Text="38" Value="37"></asp:ListItem>
                                    <asp:ListItem Text="37" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="36" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="34" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="33" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="32" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="31" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="29" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="28" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="27" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="26" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="1" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty_Re_import">
                            <div id="editbu">
                                <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false" TabIndex="9"
                                    OnClientClick="jQuery('#form1').validationEngine('hide');" OnClick="btnNew_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="12"
                                    OnClientClick=" return validate_Import_Reimport()" />
                            </div>
                             <div id="editbu">
                                <asp:Button ID="btn_save_new" Text="Save & New" CssClass="autowidupdatebut" TabIndex="8"
                                    runat="server" OnClick="btn_save_new_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="updates" OnClick="btnUpdate_Click"
                                    TabIndex="12" OnClientClick=" return validate_Import_Reimport()" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDelete" runat="server" TabIndex="13" Visible="false" CssClass="dlete"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'SW Info Type', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
          }
          else {
          }
    
});return false;" />
                                <asp:Button ID="btn" runat="server" TabIndex="13" OnClick="btnDelete_Click" OnClientClick="return validate();"
                                    CssClass="dlete" Style="display: none;" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Child_Parent_close_button1('ItemMain');return false;"
                                    TabIndex="14" CausesValidation="false" UseSubmitBehavior="false" />
                            </div>

                           <%-- <div id="editbu" style="width: 120px;">
                           
                            </div>--%>
                            <div id="div_AmendmentType" visible="false" runat="server" style="margin-top: 5px">
                                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 55px;
                                    font-weight: bold;">
                                    Amend
                                </div>
                                <div id="txtcon-m_transaction_code_BE_TYPE" style="width: 40px;">
                                    <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                        Width="40px">
                                        <asp:ListItem Value=""></asp:ListItem>
                                        <asp:ListItem Value="A">A</asp:ListItem>
                                        <asp:ListItem Value="S">S</asp:ListItem>
                                        <asp:ListItem Value="D">D</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="editbu" style="margin-top: -2px;">
                                    <asp:Button ID="btn_Amend_FF" Text="Flatfile" CssClass="autowidmovebut" runat="server"
                                        OnClientClick="Open_Amend_Flatfile(); return false" Width="60px" />
                                </div>
                            </div>

                            <div id="editbu" style="width: 70px;">
                                <asp:Button ID="btn_ExcelUpload" Text="XL Upload" CssClass="autowidupdatebut" CausesValidation="false"
                                    Width="70px" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');Open_SW_Bulk_Excel_Upload1();return false;" />
                            </div>
                            <div id="editbu" style="width: 75px;">
                            <asp:Button ID="btnSW" Text="SW Delete" CssClass="autowidmovebut" runat="server"  TabIndex="15"
                                OnClientClick="SW_Delete(); return false" Width="70px" />
                            </div>

                             <div id="editbu" style="width: 70px;">
                                <asp:Button ID="btn_Bulksw_Upload" Text="BulkSw Entry" CssClass="autowidupdatebut" CausesValidation="false"
                                    Width="90px" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');Single_Windows('New'); return false"/>
                            </div>
                            
                            <div id="editbu" style="width: 92px;">
                            <asp:Button ID="btn_item_delete" runat="server" Text="Item Info. Del." TabIndex="15" UseSubmitBehavior="false"  Width="91px" CssClass="autowidupdatebut" ToolTip="Info Type Delete"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'SW Info Type', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn_del').click();
          }
          else {
          }
    
});return false;" />

                        <asp:Button ID="btn_del" runat="server" TabIndex="13" OnClick="btn_item_delete_Click" 
                    CssClass="dlete" Style="display: none;" />
                    </div>
                        </div>
                        <div id="tag_transac_lft_Item_reimport_Grid_area" style="overflow: auto; height: 179px;">
                            <asp:GridView ID="gv_ReImport" runat="server" DataKeyNames="SW_INFO_TYPE_ID" EmptyDataText="NO RECORD FOUND"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                ShowHeaderWhenEmpty="True" OnRowDataBound="gv_ReImport_RowDataBound" OnSelectedIndexChanged="gv_ReImport_SelectedIndexChanged"
                                AllowPaging="false" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" OnRowCreated="gv_ReImport_RowCreated">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="26px">
                                        <ItemTemplate>
                                            <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="26px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DEPARTMENT" HeaderText="Dept." ControlStyle-Width="30px">
                                        <ItemStyle CssClass="column_style_left5" Width="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INFO_TYPE" HeaderText=" Type" ControlStyle-Width="35px">
                                        <ItemStyle CssClass="column_style_left5" Width="35px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INFO_QUALIFIER" HeaderText="Qualifier" ControlStyle-Width="60px">
                                        <ItemStyle CssClass="column_style_left5" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INFO_CODE" HeaderText="Code" ControlStyle-Width="60px">
                                        <ItemStyle CssClass="column_style_left5" Width="60px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INFO_TEXT" HeaderText="Text" ControlStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left5" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INFO_MSR" HeaderText="MSR" ControlStyle-Width="20px">
                                        <ItemStyle CssClass="column_style_left5" Width="20px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INFO_UQC" HeaderText="UQC" ControlStyle-Width="45px" >
                                        <ItemStyle CssClass="column_style_left5" Width="45px" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="REGN_DATE" HeaderText="Regn_Date" ControlStyle-Width="20px" >
                                        <ItemStyle CssClass="column_style_left5" Width="20px" />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="REGN_VALIDITY" HeaderText="Validity" ControlStyle-Width="45px" >
                                       <ItemStyle CssClass="column_style_left5" Width="20px" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="AMENDMENT_TYPE" HeaderText="AmendType" ControlStyle-Width="45px" >
                                       <ItemStyle CssClass="column_style_left5" Width="20px" />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="REGN_VALIDITY" HeaderText="Validity" ControlStyle-Width="45px" >
                                       <HeaderStyle CssClass="hideGridColumn" />
                                      <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>--%>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <asp:HiddenField ID="hdn_update_Reimport" runat="server" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
                    <asp:HiddenField ID="hdn_dept_code" runat="server" />
                      <asp:HiddenField ID="hdn_Jobno" runat="server" /> 
                       <asp:HiddenField ID="hdn_Invslno" runat="server" ClientIDMode="Static"/>
                </div>
                <div class="content" id="page-2" style="display: none;">
                    <iframe  name="trans_item_reimport" scrolling="no" id="Trans_product_SWConstituent_iframe">
                    </iframe>
                </div>
                <div class="content" id="page-3" style="display: none;">
                    <iframe  name="trans_item_licence" scrolling="no" id="Trans_product_SWProduction_iframe">
                    </iframe>
                </div>

                 <div class="content" id="page-4" style="display: none;">
                    <iframe  name="trans_item_licence" scrolling="no" id="Trans_product_SWControl_iframe">
                    </iframe>
                </div>
                 <div class="content" id="page-5" style="display: none;">
                    <iframe  name="trans_item_licence" scrolling="no" id="Trans_product_Statement_iframe">
                    </iframe>
                 </div>

                 </div>
                 </div>
              

                 
              
            
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
     <asp:HiddenField ID="hdn_Normal_Bulk" runat="server" />
    </form>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
     
    <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9' ,'page-15']);
            </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                var dataSrc = ["IDT", "CHR", "CTG", "PNM", "PEC", "ORC"];

                $("#txt_info_type").autocomplete({
                    source: dataSrc
                });
            });
        });
    </script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('#ddl_Info_Code').change(function () {
                var type = $('#ddl_Info_Code').val();

                if (type == 'SIUNAPL') {
                    
                    $('#lbl_info_MSR').css('display', 'block');
                    $('#lbl_info_UQC').css('display', 'block');

                    $('#txt_RegDate').css('display', 'block');
                    $('#ddl_validity').css('display', 'block');
                    
                    var val = $("#txt_Info_Text").val();
                    if (val != '') {
                        if (val.length >= 7 && val.substring(0, 7) == 'MOSSIMS') {
                        }
                        else {
                            $("#txt_Info_Text").val('');
                            $("#txt_Info_Text").attr("placeholder", "<MOSSIMS><DDMMYY><CertNo>");
                        }
                    }
                    else {
                        $("#txt_Info_Text").val('');
                        $("#txt_Info_Text").attr("placeholder", "<MOSSIMS><DDMMYY><CertNo>");
                    }
                   
                }
                else if (type == 'SIUNAF') {
                    $("#txt_Info_Text").val('SIUN000');
                    $('#txt_RegDate').css('display', 'none');
                    $('#lbl_info_MSR').css('display', 'none');
                    $('#lbl_info_UQC').css('display', 'none');
                    $('#ddl_validity').css('display', 'none');
                }
                else if (type == 'SIUNRR') {
                    $("#txt_Info_Text").val('SIUN000');
                    $('#txt_RegDate').css('display', 'none');
                    $('#lbl_info_MSR').css('display', 'none');
                    $('#lbl_info_UQC').css('display', 'none');
                    $('#ddl_validity').css('display', 'none');
                }
				else if (type != '') {
                        var infoType = $('#ddl_info_type').val();
                        var infoQualifier = $('#ddl_Info_Qualifier').val();

                        if (infoType == 'CHR' && infoQualifier == 'SGD') {
                            $("#txt_Info_Text").attr("placeholder", "");
                            var declarationText = 'We declare that imported items are exempted from safeguard duty under infocode ' + type;
                            $("#txt_Info_Text").val(declarationText);
                        }
                        else {
                            $("#txt_Info_Text").val('');
                            $("#txt_Info_Text").attr("placeholder", "");
                        }
                    }
				else{
                    }					
                				 
            });
        });
    
    </script>

    

    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnUpdate,#btnSave').click(function () {
                var infocode = $('#ddl_Info_Code').val();
                var dept = $("#ddldept").val();
                var Qufr_type = $('#ddl_Info_Qualifier').val();

                //------------------------------------------  SIMS --------------------------------------------------------------------
                if (infocode == 'SIUNAPL') {

                    if ($('#txt_Info_Text').val() == '') {
                        jAlert('Info Text - Mandatory ', 'SIMS', function (r) { document.getElementById("txt_Info_Text").focus(); });
                        return false;
                    }
                    if ($('#txt_RegDate').val() == '') {
                        jAlert('Regn Date - Mandatory ', 'SIMS', function (r) { document.getElementById("txt_RegDate").focus(); });
                        return false;
                    }
                }

                //------------------------------------------- PQIS --------------------------------------------------------------------

                if (dept == 'PQIS' && Qufr_type == 'PLC') {
                    if ($('#txt_Info_Msr').val() == '') {
                        jAlert('Info MSR - Mandatory ', 'SW InfoType', function (r) { document.getElementById("txt_Info_Msr").focus(); });
                        return false;
                    }
                    if ($('#txt_Info_Uqc').val() == '') {
                        jAlert('Info UQC - Mandatory ', 'SW InfoType', function (r) { document.getElementById("txt_Info_Uqc").focus(); });
                        return false;
                    }
                }

                //------------------------------------------------------------------------------------------------------------------------
            });
        });
</script>

<script type="text/javascript">
    $(document).ready(function () {

        var dept = $("#ddldept").val();
        var INFOtype = $('#ddl_info_type').val();
        var SIMStype = $('#ddl_Info_Code').val();

        if (dept == 'PQIS') {

            document.getElementById('lbl_info_MSR').innerHTML = 'Info MSR';
            document.getElementById('lbl_info_UQC').innerHTML = 'Info UQC';

            $('#lbl_info_MSR').css('display', 'block');
            $('#txt_Info_Msr').css('display', 'block');
            $('#lbl_info_UQC').css('display', 'block');
            $('#txt_Info_Uqc').css('display', 'block');
            $('#txt_RegDate').css('display', 'none');
            $('#ddl_validity').css('display', 'none');
        }
        else if (dept == 'SIMS') {

            document.getElementById('lbl_info_MSR').innerHTML = 'Regn.Date';
            document.getElementById('lbl_info_UQC').innerHTML = 'ValidityDays';

            if (SIMStype != 'SIUNAPL') {
                $('#lbl_info_MSR').css('display', 'none');
                $('#txt_RegDate').css('display', 'none');
                $('#lbl_info_UQC').css('display', 'none');
                $('#ddl_validity').css('display', 'none');
            }
            else {
                $('#lbl_info_MSR').css('display', 'block');
                $('#lbl_info_UQC').css('display', 'block');
                $('#txt_RegDate').css('display', 'block');
                $('#ddl_validity').css('display', 'block');
            }
            $('#txt_Info_Msr').css('display', 'none');
            $('#txt_Info_Uqc').css('display', 'none');
        }
        else if (dept == 'FTA') {
            /*
            $('#lbl_info_UQC').css('display', 'block');
            $('#txt_Info_Uqc').css('display', 'block');
            document.getElementById('lbl_info_UQC').innerHTML = 'Info. UQC';
            */
        }
        else if (dept_change == 'SEZ') {
            if (INFOtype == 'DTY') {
               
                $('#lbl_info_MSR').css('display', 'block');
                $('#txt_Info_Msr').css('display', 'block');
                $('#lbl_info_UQC').css('display', 'none');
                $('#txt_Info_Uqc').css('display', 'none');
                document.getElementById('lbl_info_MSR').innerHTML = 'Info MSR';
            }
        }
        else {
            $('#lbl_info_MSR').css('display', 'none');
            $('#txt_Info_Msr').css('display', 'none');
            $('#lbl_info_UQC').css('display', 'none');
            $('#txt_Info_Uqc').css('display', 'none');
            $('#txt_RegDate').css('display', 'none');
            $('#ddl_validity').css('display', 'none');
        }

        $('#ddldept').change(function () {
            var dept_change = $('#ddldept').val();

            if (dept_change == 'PQIS') {

                document.getElementById('lbl_info_MSR').innerHTML = 'Info MSR';
                document.getElementById('lbl_info_UQC').innerHTML = 'Info UQC';

                $('#lbl_info_MSR').css('display', 'block');
                $('#txt_Info_Msr').css('display', 'block');
                $('#lbl_info_UQC').css('display', 'block');
                $('#txt_Info_Uqc').css('display', 'block');
                $('#txt_RegDate').css('display', 'none');
                $('#ddl_validity').css('display', 'none');
            }
            else if (dept_change == 'SIMS') {

                document.getElementById('lbl_info_MSR').innerHTML = 'Regn.Date';
                document.getElementById('lbl_info_UQC').innerHTML = 'ValidityDays';

                $('#lbl_info_MSR').css('display', 'block');
                $('#lbl_info_UQC').css('display', 'block');
                $('#txt_RegDate').css('display', 'block');
                $('#ddl_validity').css('display', 'block');

                $('#txt_Info_Msr').css('display', 'none');
                $('#txt_Info_Uqc').css('display', 'none');
            }
            else if (dept_change == 'FTA') {
                //-------------------------
                /*
                $('#lbl_info_UQC').css('display', 'block');
                $('#txt_Info_Uqc').css('display', 'block');
                document.getElementById('lbl_info_UQC').innerHTML = 'Info. UQC';
                */
            }
            else if (dept_change == 'SEZ') {
                if (INFOtype == 'DTY') {
                    $('#lbl_info_MSR').css('display', 'block');
                    $('#txt_Info_Msr').css('display', 'block');
                    $('#txt_Info_Uqc').css('display', 'none');
                }
            }
            else {
                $('#lbl_info_MSR').css('display', 'none');
                $('#txt_Info_Msr').css('display', 'none');
                $('#lbl_info_UQC').css('display', 'none');
                $('#txt_Info_Uqc').css('display', 'none');
                $('#txt_RegDate').css('display', 'none');
                $('#ddl_validity').css('display', 'none');
            }
        });
    });
    
    </script>
    <script src="../js/Import_Jscript/IMP_Single_Window.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/IMP_Single_Window_Tab.js" type="text/javascript"></script>



    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>




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

        function Open_SW_Bulk_Excel_Upload1() {
            window.parent.Open_SW_Bulk_Excel_Upload();
            return false;

        }
    </script>
     
    <script type="text/javascript">
            var config = {
                '.chosen-select': {},
                '.chosen-select-deselect': { allow_single_deselect: true },
                '.chosen-select-no-single': { disable_search_threshold: 10 },
                '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
                '.chosen-select-width': { width: "95%" }
                 
            }
            for (var selector in config) {
                $(selector).chosen(config[selector]);
            }

        </script>
       <%-- <script type="text/javascript">

            $(document).ready(function () {
                Auto_complete_Search();
            });

            function Auto_complete_Search() {
                var Notn = ['KGS', 'NOS'];

                $('#txt_Info_Uqc').autocomplete({
                    source: Notn,
                    minLength: 0,
                    scroll: true
                }).focus(function () {
                    $(this).autocomplete("search", "");
                });
            }

  </script>--%>
  <script type="text/javascript">
      function SW_Delete() {
          NewWindow1('../IMP_Single_Window/SW_Delete.aspx', 'List', '1100', '1024', 'yes');
      }

      function Open_Amend_Flatfile() {
          var amd_type = document.getElementById("ddl_AmendmentType").value;
          var amd_page = 'BE_ITEM_SW_INFO_TYPE';
          var amd_Jobno = document.getElementById("hdn_Jobno").value;
           var amd_Invslno = document.getElementById("hdn_Invslno").value;

          NewWindow1('../Amendment/Import_Amendment.aspx?amd_type=' + amd_type + '&amd_page=' + amd_page + '&amd_Jobno=' + amd_Jobno + '&amd_Invslno=' + amd_Invslno, 'List', '950', '515', 'yes');
      }

      function Open_Icegate_Single_window_PGA() {
          var _RITCNO = document.getElementById("txt_RITCNO").value;
          NewWindow1('../IMP_Single_Window/Icegate_Single_window_PGA.aspx?RITCNO=' + _RITCNO, 'List', '950', '350', 'yes');

      }

      function Single_Windows() {

              NewWindow1('../IMP_Single_Window/Imp_SW_Bulk.aspx', 'List', '1100', '1024', 'yes');
      }
      
    </script>
    <!-- VALIDATION SCRIPT -->
     <script type="text/javascript">
         function validateDate() {
             var aval_dept = document.getElementById("ddldept").value;
             var info_type = document.getElementById("ddl_info_type").value;
             var info_qualifier = document.getElementById("ddl_Info_Qualifier").value;
             var info_text = document.getElementById("txt_Info_Text").value;


             if (aval_dept === "FTA" && info_type === "ORC" && info_qualifier === "COO") {
                 if (info_text == "")
                     return;

                 var parts = info_text.split("|");

                 if (parts.length != 2) {
                     alert("Invalid format. Date not found.");
                     return false;
                 }

                 var dateString = parts[1];

                 if (dateString.length != 8) {
                     alert("Invalid date format.");
                     return false;
                 }

                 var day = dateString.substring(0, 2);
                 var month = dateString.substring(2, 4);
                 var year = dateString.substring(4, 8);

                 var enteredDate = new Date(year, month - 1, day);

                 var today = new Date();
                 today.setHours(0, 0, 0, 0);

                 if (enteredDate > today) {
                     alert("Info Text Date should not be greater than Current Date.");
                 }
             }
         }
</script>
</body>
</html>
