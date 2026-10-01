<%@ Page Language="C#" AutoEventWireup="true" CodeFile="General.aspx.cs" Inherits="Transaction_General_New" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        
        
         .mand-tooltip {
    position: absolute;
    background: #2a7ab5;
    color: #fff;
    font-size: 11px;
    font-weight: 600;
    padding: 2px 7px;
    border-radius: 3px;
    z-index: 9999;
    white-space: nowrap;
    pointer-events: none;
    line-height: 16px;
    border: 2px solid #1a5a8a;
    outline: 1px solid #5aaee8; 
}
.mand-tooltip:after {
    content: '';
    position: absolute;
    top: 100%;
    right: 8px;
    left: auto;
    border-width: 4px 4px 0;
    border-style: solid;
    border-color: #1a5a8a transparent transparent; 
}
        
       
        /* Autocomplete Textbox Search Loading Image*/
    </style>
      <script type="text/javascript">

          function HideModalPopup_U() {

              $find("MP_U").hide();
              return false;
          }
</script>

<script type="text/javascript">
    function jsFunction(value) {
        if (value == 'Y') {

            var hdn_TIN_NO1 = document.getElementById("hdn_TIN_NO").value;
            var hdn_StateName1 = document.getElementById("hdn_StateName").value;
            var hdn_StateCode1 = document.getElementById("hdn_StateCode").value;
            var hdn_commercialType1 = document.getElementById("hdn_commercialType").value;
            alert(hdn_commercialType1);

            document.getElementById("txtCommercial_RegistrationNo").value = hdn_TIN_NO1;
            document.getElementById("txtCommercial_StateName").value = hdn_StateName1;
            document.getElementById("txtCommercial_StateCode").value = hdn_StateCode1;
            document.getElementById("txtCommercial_Taxtype").value = hdn_commercialType1;
        }
        else {

            document.getElementById("txtCommercial_RegistrationNo").value = "";
            document.getElementById("txtCommercial_StateName").value = "";
            document.getElementById("txtCommercial_StateCode").value = "";
            document.getElementById("txtCommercial_Taxtype").value = "";
        }
    }
</script>

<%--<script type="text/javascript">
    function handleDropdownChange() {
        var ddlBEType = document.getElementById('ddlBEType');
        var selectedText = ddlBEType.options[ddlBEType.selectedIndex].text;
        var lblImpExpType = document.getElementById('Lbl_Imp_Exp_Type');
        var ddlType = document.getElementById('ddlType');
        PageMethods.Get_Betype(selectedText);
        if (selectedText == "SEZ FTA-Z" || selectedText == "SEZ DTA-M" || selectedText == "SEZ DTA-T" || selectedText == "Stock Item") {
            lblImpExpType.style.display = "block";
            ddlType.style.display = "block";
        } else {
            lblImpExpType.style.display = "none";
            ddlType.style.display = "none";
        }
    }
</script>--%>

<script type="text/javascript">    // Added by pandiyan on 16-09-2025 sugg by niyas for Warehouse payment is T 
    function handleDropdownChange() {
        var ddlBEType = document.getElementById('ddlBEType');
        var selectedText = ddlBEType.options[ddlBEType.selectedIndex].text;

        var lblImpExpType = document.getElementById('Lbl_Imp_Exp_Type');
        var ddlType = document.getElementById('ddlType');

        // Call server-side PageMethod
        PageMethods.Get_Betype(selectedText);

        // Condition 1: Show/Hide based on specific BE Types
        if (selectedText == "SEZ FTA-Z" || selectedText == "SEZ DTA-M" || selectedText == "SEZ DTA-T" || selectedText == "Stock Item") {
            
            lblImpExpType.style.display = "block";
            ddlType.style.display = "block";
        } else {
            lblImpExpType.style.display = "none";
            ddlType.style.display = "none";
        }
    }

    function handlePaymentMethodAutocomplete() {
        var ddlBEType = document.getElementById('ddlBEType');
        var selectedText = ddlBEType.options[ddlBEType.selectedIndex].text;

        var Notn;
        if (selectedText == "Warehouse") {
            Notn = ['T'];   // only T
        } else {
            Notn = ['T', 'D'];  // both
        }

        // Destroy and re-bind autocomplete
        $("#txt_Payment_Method").autocomplete("destroy");
        $("#txt_Payment_Method").autocomplete({
            source: Notn,
            minLength: 0,
            scroll: true
        }).focus(function () {
            $(this).autocomplete("search", "");
        });
    }
</script>

<script type="text/javascript">
    function ShowModalPopup() {
        $('#txtid').val('');
        $find("MP_JOB").show();
        return false;
    }
    function HideModalPopup() {
        $('#txtid').val('');
        $find("MP_JOB").hide();
        return false;
    }
  
</script>

<script type="text/javascript">
    function Update_ddlCommercial_Type() {
        var ddl_type = document.getElementById('hdn_commercialType');
        document.getElementById('ddl_Commercial_Type').value = ddl_type.value;
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

    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden;" >
    <form id="form1" runat="server" >
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Transact_popup_new" style="height:110px">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        &nbsp;&nbsp;Transaction - Import
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 160px;">
                        <asp:Label ID="lbl_status_FAIRMACS" Text="Completed" runat="server" Font-Bold="true"
                            ForeColor="Green" Visible="false"></asp:Label>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 160px; padding-left: 150px;">
                        <span id="lblTrkBENo" title="BE Status" runat="server" onclick="BE_Track();return false;"
                            style="color: Blue; text-decoration: underline; cursor: hand; font-size: smaller;">
                            Check BE Status</span>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" visible="false" runat="server">
                            <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent_New(); return false;"
                                CausesValidation="false" UseSubmitBehavior="false" />
                        </span><span id="S" visible="false" runat="server">
                            <input type="close" value="Submit" causesvalidation="false" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                        </span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
                </div>
                
                <div id="tag_transaction_inner_new" style="margin-left:10px">
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new" style="width:220px; margin-left:20px">
                            Job No
                            <asp:TextBox ID="txtjobps" runat="server" Font-Bold="true" MaxLength="10" Font-Size="12px" CssClass="txtbox_none_Mid_transac_code"
                              Width="157px" ReadOnly="True" TabIndex="1" ClientIDMode="Static"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty" style="margin-top: 4px;">
                            <asp:ImageButton ID="btnedit" runat="server" Visible="false" ImageUrl="~/images/icons/icon_edit.jpg"
                                Height="15px" Width="15px" OnClientClick="return ShowModalPopup();" ImageAlign="Middle" />
                        </div>

                        <div id="tag_label_transaction_date" style="width:95px; text-align:center;">
                            Job Date
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtJobDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="10" Width="73px" TabIndex="2"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtJobDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtJobDate"
                                PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                          <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                       
                        <div id="tag_label_transaction_Src_longlabel" style="width:65px;">
                            Tr. Mode</div>
                        <div id="txtcon-m_transaction_mode" >
                            <asp:DropDownList ID="ddlTransportMode" runat="server" CssClass="listtxt_transac_mode_new"
                                TabIndex="3" AutoPostBack="true" onselectedindexchanged="ddlTransportMode_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </div>
                       
                        <div id="tag_label_transaction_popup_no_empty" style="width:37px; margin-left:2px; ">
                        
                          <%--<asp:ImageButton ID="btn_Tr_Mode_Change" ToolTip="Change Tr. Mode" Visible="false"
                                runat="server"  ImageUrl="~/images/icons/icon_edit.jpg"  Height="15px" Width="16px"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Change_Mode(document.getElementById('txtJobNo').value); return false" /> --%>
                              
                               <asp:ImageButton ID="btn_Tr_Mode_Change" ToolTip="Change Tr. Mode" Visible="false"
                                runat="server"  ImageUrl="~/images/icons/icon_edit.jpg"  Height="15px" Width="16px"
                                OnClientClick="jQuery('#form1').validationEngine('hideAll');open_Change_Mode('I'); return false" /> 

                        </div>
                        <div id="tag_label_transaction_Src" style="width:50px;" >
                            BE No
                        </div>
                        <div id="txtcon-m_transaction_code" >
                            <asp:TextBox ID="txtBE_No" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                ReadOnly="True" TabIndex="4" ClientIDMode="Static" Enabled="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="draw"
                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtJobNo"></asp:RequiredFieldValidator>
                           
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtJobNo"
                                FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_Src">
                            BE Date
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtBE_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"  Width="73px"
                                ReadOnly="True" TabIndex="5" ClientIDMode="Static" Enabled="false" Height="16px"   ></asp:TextBox>                                
                        </div>
                        
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new" style="width:55px; margin-left:20px">
                            BE Type</div>
                        <div id="txtcon-m_transaction_code_BE_TYPE" style="width:142px;">
                            <asp:DropDownList ID="ddlBEType" runat="server" CssClass="listtxt_transac_mode_new" Width="110px"
                               TabIndex="6" onchange="handleDropdownChange(); handlePaymentMethodAutocomplete();"> 
                             </asp:DropDownList>

                                 <asp:TextBox ID="txtJobNo" runat="server" MaxLength="10" Font-Size="12px" CssClass="txtbox_none_Mid_transac_code"
                                BorderColor="White" Width="0px" ReadOnly="True" TabIndex="1" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="draw"
                                ErrorMessage="*" ForeColor="Red" ControlToValidate="txtJobNo"></asp:RequiredFieldValidator>
                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtJobNo"
                                FilterMode="InvalidChars" InvalidChars="qwertyuiopasdfghjklzxcvbnm[{]}`~,.<>/?:;'!@#$%^&*()_+|\-=\">
                            </cc1:FilteredTextBoxExtender>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty_Exbond">
                            <a href="#" id="lnkbtn_Exbond" runat="server" style="display: none;" onclick="open_Exbond_Details(document.getElementById('txtJobNo').value);return false;">
                                Ex</a>
                           
                        </div>
                        <div id="tag_label_transaction_date">
                            Custom House</div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtCustomsHouse" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                MaxLength="6" TabIndex="7" ClientIDMode="Static"  Onchange="DropdownChange()" Onblur="DropdownChange()"></asp:TextBox>
                            <asp:HiddenField ID="hdn_CustomsHouse_Name" runat="server" ClientIDMode="Static" />
                        </div>
                        <div id="magnify_area" >
                            <a href="#" class="magnfy" onclick="OpenPopupCustom_House(); return false" style="display: none;"></a>
                        </div>
                      
                        <div id="tag_label_transaction_Src_longlabel" style="width:65px;"> 
                            Con. Type</div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddlContainer_Type" runat="server" CssClass="listtxt_transac_mode_new" TabIndex="7">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="LCL" Value="LCL"></asp:ListItem>
                            <asp:ListItem Text="FCL" Value="FCL"></asp:ListItem>
                            <asp:ListItem Text="Bulk" Value="Bulk"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_no_empty">
                        </div>
                        <div id="tag_label_transaction_Src">
                            File Ref.No
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:TextBox ID="txtFile_Ref_No" runat="server" MaxLength="25" CssClass="txtbox_none_Mid_transac_code"
                                TabIndex="7" ClientIDMode="Static" 
                               ></asp:TextBox>
                                     
                        </div>
                         <div id="tag_label_transaction_popup_no_empty">
                        </div>
                          
                    <div id="tag_label_transaction_Src">
                            Filing Status
                        </div>
                        <div id="txtcon-m_transaction_list1">
                            <asp:DropDownList ID="ddlFilingStatus" runat="server" CssClass="listtxt_transac_src1"
                             TabIndex="7">
                            </asp:DropDownList>
                        </div>
                         <div id="tag_label_transaction_popup_no_empty">
                        </div>
                         <div id="tag_label_transaction_Src" style="position:absolute; margin-top:22px; margin-left:21px" >
                            Freight Jobs
                        </div>
                         <div id="txtcon-m_Exchange" style="position:absolute; margin-top:22px; margin-left:94px">
                                    <asp:DropDownList ID="ddlFreightJobs" runat="server" class="chosen-select-deselect" 
                                        Style="width: 355px; position:absolute;" data-placeholder="Choose a Freight Job" AutoPostBack="true" onselectedindexchanged="ddlFreightJobs_SelectedIndexChanged"
                                         TabIndex="8"  >
                                    </asp:DropDownList>
                                </div>
                            <div id="tag_label_transaction_Src" style="position:absolute; margin-top:22px; margin-left:475px; width:120px;" >
                          <asp:Label ID="lbl_CHA_No" Text="IcegateID & CHA No" runat="server"></asp:Label>
                        </div>
                          <div id="txtcon-m_Exchange" style="position:absolute; margin-top:22px; margin-left:604px">
                                    <asp:DropDownList ID="ddl_Multiple_CHA_No" runat="server" class="chosen-select-deselect" 
                                        Style="width: 295px; position:absolute;" data-placeholder="Icegate ID & CHA PAN No"
                                         TabIndex="8"  >
                                    </asp:DropDownList>
                                </div>
                    </div>
                </div>

            </div>
            <div id="innerbox_MidMain_Trans_new">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="tab_page1();" id="General"><span>General</span></a></li>
                    <li><a href="#page-2" onclick="tab_page2();" id="IGM"><span>IGM</span></a></li>
                    <li><a href="#page-3" onclick="tab_page3();" id="INVOICE"><span>Invoice</span></a></li>
                    <li><a href="#page-4" onclick="tab_page4();" id="ITEM"><span>Product</span></a></li>
                    <%--<li><a href="#page-5" target="maineroyal" onclick="tab('0');"><span>Docket</span></a></li>--%>
                    <%--<li><a href="#page-6" target="maineroyal" onclick="tab('0');"><span>Tracking</span></a></li>--%>

                    <%--<li><a href="#page-5"  onclick="tab_page5('../Report/Import_CheckList.aspx?jobno=',document.getElementById('txtJobNo').value);" id="Checklist"><span>Checklist</span></a></li>--%>
                    <li><a href="#page-5" onclick="tab_page5_New();" id="CHECKLIST"><span>Checklist</span></a></li>
                    <li>
                    <a href="#page-6"  onclick="tab_page5('../FlatFile/Import_Flat_File_Generation.aspx?jobno=',document.getElementById('txtJobNo').value);" id="Submission" runat="server" >
                    <span>Submission 2.1</span></a>
                    </li>

                    <li><a href="#page-7"  onclick="tab_page6('../Job_History/Job_history.aspx?jobno=',document.getElementById('txtJobNo').value,' &jobdate=',document.getElementById('txtJobDate').value,' &type=IMP')" id="Jobhistry"><span>Job History</span></a>
                    </li>

                     <li>
                          <a href="#page-8" visible="false"  onclick="tab_page5('../FlatFile/E_Way_Bill_Generation.aspx?jobno=',document.getElementById('txtJobNo').value);" 
                           id="E_Way_Bill" runat="server" >
                          <span>e-Way Bill </span></a>
                     </li>
                     <div id="Imp_Billing_Others1" runat="server" visible="false">
                      <li><a href="#page-9" onclick="tab_page9();" id="Imp_Billing_Others"><span>Billing-Others</span></a></li>
                      </div>
                       <div id="Imp_Job_Logs_History" runat="server">
                      <li><a href="#page-10" onclick="tab_page10();" id="Imp_Job_Logs_History1"><span>Job Logs</span></a></li>
                      </div>

                    <%--<li><a href="#page-8" target="maineroyal" onclick="tab('0');"><span>Job History</span></a></li>--%>
                    <div id="job_release" runat="server" visible="false">
                        <li><span style="margin-left: 340px;">
                            <asp:Button ID="JobRelease" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                CausesValidation="false" Text="Job Release" OnClick="JobRelease_Click" />
                        </span>
                            <%--<a href="#page-8" style="text-align:right" id="JobRelease"><span style="text-align:right">Job Release</span></a></li>   --%>
                        </li>
                    </div>
                    <div id="Acc_Charge" runat="server" visible="false">
                        <li><a href="#page-11" onclick="jQuery('#form1').validationEngine('hideAll');ch_tab_Imp_page11();"
                            id="charge_acc_iMP"><span>Charges</span></a></li>
                    </div>
                    <div id="Acc_Financial" runat="server" visible="false">
                        <li><a href="#page-13" onclick="jQuery('#form1').validationEngine('hideAll');ch_tab_Fin_page13();"
                            id="charge_acc_fin"><span>Financials</span></a></li>
                    </div>

                    <div id="Imp_SDF_Others" runat="server" visible="false">
                        <li><a href="#page-12" onclick="tab_page12();" id="Imp_SDF_Other"><span>SDF-Others</span></a></li>
                    </div>

                    <div> 
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txt_FF_Jobno"   placeholder="Fr. Jobno"  Width="150px"  runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_exp_invoice_addr" TabIndex="8" ></asp:TextBox>
                    </div>


                </ol>
                <div class="content" id="page-1" >
                    <div id="area_transac_container_genral" runat="server">
                        <asp:Panel ID="Panel1" runat="server">
                            <div id="pop_text_area_transac_popup_inn_container_new">
                                <div id="pop_text_area_transac_popup_inn_container_left_new">
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Importer Name</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txtImporterName" runat="server" MaxLength="50" onblur="ChangeCase(this);" Font-Bold="true"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="10"></asp:TextBox>
                                                
                                        </div>
                                        <div id="magnify_area">
                                           <div id="ND" runat="server">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporter_Master('IMPORTER_DETAILS'); return false">
                                            </a>
                                            </div>
                                             <div id="WD" runat="server">
                                             <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Imp_Exp_Ryal_Job('IMPORTER_DETAILS'); return false">
                                            </a>
                                           </div>
                                        </div>
                                        <asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server"  OnClientClick="jQuery('#form1').validationEngine('hideAll');opennewclientupdate_N_JobSearch(document.getElementById('txtBranchNo').value,document.getElementById('txtImporterName').value,document.getElementById('txtIECNo').value,'Job'); return false" />
                                        <%--<asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server"  OnClientClick="jQuery('#form1').validationEngine('hideAll');opennewclientnew_N_JobSearch(); return false" />--%>
                                        <%--<asp:Button ID="btnnew1" CssClass="autowidnewbut" Text="New" runat="server"  OnClientClick="jQuery('#form1').validationEngine('hideAll');openclient_Masternew(); return false" />--%>
                                     <%--   <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');openclient_Masternew(); return false">
                                            New</a>--%>

                                            <asp:ImageButton ID="btn_Masedit" Height="26px" Width="30px" ToolTip="Client Edit" ImageUrl="~/images/icons/jobedit_master.png" runat="server"
                    OnClientClick="jQuery('#form1').validationEngine('hideAll');opennewclientupdate_N_JobSearch(document.getElementById('txtBranchNo').value,document.getElementById('txtImporterName').value,document.getElementById('txtIECNo').value,'Job'); return false"  />
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            IEC_No
                                        </div>
                                        <div id="txtcon-m_transaction_code">
                                            <asp:TextBox ID="txtIECNo" runat="server" MaxLength="10" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"
                                                TabIndex="11" onkeypress="return pin(event)"></asp:TextBox>
                                               
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="divparty_ref" runat="server">
                                            <div id="tag_label_transaction_Src" style="text-align: center">
                                                Party Ref.No</div>
                                            <div id="txtcon-m_transaction_code" style="width: 163px;">
                                                <asp:TextBox ID="txtParty_RefNo" runat="server" MaxLength="25" CssClass="txtbox_none_Mid_transac_code"
                                                    Width="163px" ClientIDMode="Static" TabIndex="12"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div id="I_Code_WD" visible="false" runat="server">
                                        <div id="magnify_area">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Imp_Exp_I_Code_Job('IMPORTER_DETAILS'); return false">
                                                </a>
                                                </div>
                                            </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Branch_SL_No</div>
                                        <div id="txtcon-m_transaction_item_maindet">
                                            <asp:TextBox ID="txtBranchNo" runat="server" MaxLength="3" CssClass="txtbox_none_Mid_transac_item_maindet"
                                                ClientIDMode="Static" TabIndex="12" onkeypress="return pin(event)"></asp:TextBox>
                                               
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporter_Master_BranchSlno('Import_Branch');">
                                            </a>
                                        </div>
                                        <div id="tag_label_transaction_Src" style="text-align:center">
                                           AD Code</div>
                                        <div id="txtcon-m_transaction_code" style="width:140px">
                                         <%--<asp:TextBox ID="txt_ADCode" runat="server" MaxLength="14" CssClass="validate[required] txtbox_none_Mid_transac_code" Width="130px" Onkeypress="return num1(event)"
                                               ClientIDMode="Static" TabIndex="12"></asp:TextBox>--%>
                                               <asp:TextBox ID="txt_ADCode" runat="server" MaxLength="14" CssClass="txtbox_none_Mid_transac_code" Width="130px" Onkeypress="return numchar(event)"
                                               onkeyup="ChangeCase(this);" onfocus="ChangeCase(this);" onblur="ChangeCase(this);"
                                               ClientIDMode="Static" TabIndex="12"></asp:TextBox>
                                        </div>      
                                        <div id="magnify_area">
                                           <a class="magnfy" href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupAdcode(document.getElementById('txtImporterName').value,document.getElementById('txtIECNo').value,'IMPORT'); return false">
                                            </a>
                                        </div>   
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Address</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                            <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big" 
                                                TabIndex="13"></asp:TextBox>
                                                
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                            <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big" TabIndex="14"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                            <asp:TextBox ID="txtAddress3" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                                                ClientIDMode="Static" TabIndex="15"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" >
                                            <asp:TextBox ID="txtAddress4" runat="server" MaxLength="35" ClientIDMode="Static" 
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic" TabIndex="16"></asp:TextBox>
                                                  Pin
                                              <asp:TextBox ID="txtAddress5" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                               ClientIDMode="Static" TabIndex="17" ></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1" style="display:none">
                                        <div id="tag_label_transaction_popup_gen">
                                          <div id="tag_label_transaction_popup_gen_export">
                                            GSTN Type
                                        </div>
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big" style="width:350px;">

                                          <asp:DropDownList ID="ddl_GSTN_Type" runat="server" CssClass="listtxt_transac_src1" ClientIDMode="Static"
                                                TabIndex="18" Width="190px" Font-Size="12px">
                                          <asp:ListItem Text="" Value=""></asp:ListItem>
                                          <asp:ListItem Text="G/GSN  -GSTIN of Normal Persons Individual IEC" Value="GSN"></asp:ListItem>
                                          <asp:ListItem Text="O/GSG GSTIN of Govt.Entities" Value="GSG"></asp:ListItem>
                                          <asp:ListItem Text="D/GSD - GSTIN of Diplomats" Value="GSD"></asp:ListItem>
                                          <asp:ListItem Text="I/PAN PAN Number (AAAPL1234C)" Value="PAN"></asp:ListItem>
                                          <asp:ListItem Text="T/TAN TAN Number (AAAP12345C)" Value="TAN"></asp:ListItem>
                                          <asp:ListItem Text="P/PSP -Passport Number( Max 9 Characters-AN)" Value="PSP"></asp:ListItem>
                                          <asp:ListItem Text="A/ADH Aadhaar Number( 12 Numeric)" Value="ADH"></asp:ListItem>
                                           </asp:DropDownList>
                                            ID 
                                            <asp:TextBox ID="txt_GSTN_ID" Width="127px" runat="server" MaxLength="20" ClientIDMode="Static"
                                                TabIndex="18" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Country Origin
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <%--<asp:TextBox ID="txtCountryName" runat="server" MaxLength="50" onkeyup="ChangeCase(this);"
                                                onblur="ChangeCase(this);updateTextbox();" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"
                                                ClientIDMode="Static" TabIndex="18" onkeypress="return char(event)" onchange="updateTextbox()"
                                                onfocus="updateTextbox();" onkeydown="updateTextbox();"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtCountryName" runat="server" MaxLength="50" onkeyup="ChangeCase(this);"
                                                onblur="ChangeCase(this);updateTextbox();" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                ClientIDMode="Static" TabIndex="18" onkeypress="return char(event)" onchange="updateTextbox()"
                                                onfocus="updateTextbox();" onkeydown="updateTextbox();"></asp:TextBox>
                                            <asp:HiddenField ID="txtCountryCode" runat="server" ClientIDMode="Static" />
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false">
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Country of Shipment
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <%--<asp:TextBox ID="txtCountryShipment" runat="server" MaxLength="50" onblur="ChangeCase(this);"
                                                CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                                TabIndex="19" onkeypress="return char(event)" onkeyup="ChangeCase(this);"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtCountryShipment" runat="server" MaxLength="50" onblur="ChangeCase(this);"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                                TabIndex="19" onkeypress="return char(event)" onkeyup="ChangeCase(this);"></asp:TextBox>
                                            <asp:HiddenField ID="txtCountryShipmentCode" runat="server" ClientIDMode="Static" />
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('ship'); return false">
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Port of Origin
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <%--<asp:TextBox ID="txtPortOrigin" runat="server" MaxLength="50" onkeypress="return char(event),TextBoxes(this);"
                                                onblur="ChangeCase(this);updateTextbox2();" onkeyup="ChangeCase(this);" onfocus="updateTextbox2();"
                                                onkeydown="var data = val;Port_origin(this);" onchange="updateTextbox2();" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic"
                                                ClientIDMode="Static" TabIndex="20"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtPortOrigin" runat="server" MaxLength="50" onkeypress="return char(event),TextBoxes(this);"
                                                onblur="ChangeCase(this);updateTextbox2();" onkeyup="ChangeCase(this);" onfocus="updateTextbox2();"
                                                onkeydown="var data = val;Port_origin(this);" onchange="updateTextbox2();" CssClass="txtbox_none_Mid_transac_pop_gen_srcic"
                                                ClientIDMode="Static" TabIndex="20"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_CountrySearch_Master(''); return false">
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Port of Shipment
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <%--<asp:TextBox ID="txtPortShipment" runat="server" MaxLength="50" onkeypress="return char(event)"
                                                onblur="ChangeCase(this);" onkeyup="ChangeCase(this);" onkeydown="ChangeCase(this);var data = val;Port_origin(this);"
                                                CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                                TabIndex="21"></asp:TextBox>--%>
                                                <asp:TextBox ID="txtPortShipment" runat="server" MaxLength="50" onkeypress="return char(event)"
                                                onblur="ChangeCase(this);" onkeyup="ChangeCase(this);" onkeydown="ChangeCase(this);var data = val;Port_origin(this);"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                                TabIndex="21"></asp:TextBox>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_CountrySearch_Master('Port_Ship'); return false">
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_trans_cth_label">
                                            Commercial Tax Details[Y/N]
                                        </div> 
                                        <div id="txtcon-m_transaction_item_gen_notn_list1" style="width:40px;">
                                            <asp:DropDownList ID="ddlCommercial_Tax_yn" CssClass="listtxt_transac_item_gen_notn" onchange="jsFunction(this.value);"
                                                TabIndex="22" runat="server" Width="40px">
                                             
                                            </asp:DropDownList>
                                        </div>  
                                         <div id="txtcon-r_src">
                                                 </div> 
                                         <div id="tag_label_transaction_popup_trans_cth_label" style="width:30px;">
                                         <asp:Label ID="Lbl_Imp_Exp_Type" runat="server" Text="Type" style="display:none;"></asp:Label>
                                           
                                        </div>                             
                                              
                                               <div id="txtcon-m_src" style="width:20px;">
                                              
                                                <asp:DropDownList ID="ddlType" runat="server" ClientIDMode="Static" TabIndex="2"
                                                    Width="220px" CssClass="listtxt_transac_item_gen_notn" style="display:none;">
                                                    <asp:ListItem Text ="" Value="" ></asp:ListItem>
                                                    <asp:ListItem Text ="OTHERS" Value="OTHERS"></asp:ListItem>
                                                    <asp:ListItem Text ="PRIVATE" Value="PRIVATE"></asp:ListItem>
                                                    <asp:ListItem Text ="JOBBING" Value="JOBBING"></asp:ListItem>
                                                    <asp:ListItem Text ="REPAIR & RETURN" Value="REPAIR & RETURN"></asp:ListItem>
                                                    <asp:ListItem Text ="EXHIBITION" Value="EXHIBITION"></asp:ListItem>
                                                    <asp:ListItem Text ="DESTRUCTION" Value="DESTRUCTION"></asp:ListItem>
                                                    <asp:ListItem Text ="MOVEMENT OF GOODS" Value="MOVEMENT OF GOODS"></asp:ListItem>
                                                    <asp:ListItem Text ="GOVERNMENT DEPARTMENTS" Value="GOVERNMENT DEPARTMENTS" ></asp:ListItem>
                                                    <asp:ListItem Text ="GOVERNMENT UNDERTAKINGS" Value="GOVERNMENT UNDERTAKINGS"></asp:ListItem>
                                                    <asp:ListItem Text ="UNCLAIMED CARGO" Value="UNCLAIMED CARGO" ></asp:ListItem>
                                                    <asp:ListItem Text ="TRADING" Value="TRADING"></asp:ListItem>
                                                    <asp:ListItem Text ="MANUFATURED GOODS" Value="MANUFATURED GOODS" ></asp:ListItem>
                                                    <asp:ListItem Text ="CBW" Value="CBW"></asp:ListItem>
                                                </asp:DropDownList>
                                                </div>
                                                <div id="txtcon-r_src">
                                                 </div>
                                    </div>
                                    <div id="div_CommercialTax"  runat="server"> <%--style="display: none;"--%>
                                        <div id="tag_transac_lft_in1">
                                            <div id="tag_label_transaction_popup_gen">
                                                State Name
                                            </div>
                                            
                                            <div id="txtcon-m_transaction_Inv_No">
                                                <asp:TextBox ID="txtCommercial_StateName" runat="server" MaxLength="40" onkeypress="return char(event)"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" ClientIDMode="Static"
                                                  
                                                    TabIndex="23"></asp:TextBox>
                                            </div>
                                          <%--  <div id="magnify_area">
                                                <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');opennewStatecode('IMPORT_STATECODE'); return false">
                                                </a>
                                            </div>--%>
                                             <div id="tag_label_transaction_popup_IGM2_empty">
                                             </div>
                                            <div id="tag_label_transaction_date" >
                                                State Code
                                            </div>
                                            <div id="txtcon-m_transaction_item_CTH_small">
                                                <asp:TextBox ID="txtCommercial_StateCode"  runat="server" MaxLength="40" onkeypress="return num1(event)"
                                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                                    TabIndex="24"></asp:TextBox>
                                               <%-- <asp:Label ID="div_Commercial_TaxTypecode" runat="server" CssClass="tag_label_transaction_General_commercialtax"></asp:Label>--%>
                                            </div>
                                             <div id="magnify_area">
                                                <a href="#" class="magnfy"  runat="server" id="ST_Code"
                                                onclick="jQuery('#form1').validationEngine('hideAll');opennewStatecode('IMPORT_STATECODE'); return false">
                                                </a>
                                            </div>
                                        </div>
                                        <div id="tag_transac_lft_in1">
                                            <div id="tag_label_transaction_popup_gen">
                                                Registration No
                                            </div>
                                            <div id="txtcon-m_transaction_Inv_No">
                                                <asp:TextBox ID="txtCommercial_RegistrationNo" runat="server" MaxLength="20" onkeypress="return charnum2(event)"
                                                    onblur="ChangeCase(this);" onkeyup="ChangeCase(this);" onkeydown="ChangeCase(this);"
                                                    CssClass="txtbox_none_Mid_transac_Inv_No" ClientIDMode="Static" TabIndex="25"></asp:TextBox>
                                            </div>
                                            <div id="tag_label_transaction_popup_IGM2_empty">
                                            </div>
                                            <div id="tag_label_transaction_date">
                                                GSTN Type
                                            </div>
                                            <div id="txtcon-m_transaction_item_CTH_small">
                                                <asp:DropDownList ID="ddl_Commercial_Type" runat="server" ClientIDMode="Static" TabIndex="26"
                                                    Width="55px" CssClass="listtxt_transac_src1" >
                                                    <asp:ListItem Text ="G" Value="G" ></asp:ListItem>
                                                    <asp:ListItem Text ="O" Value="O"></asp:ListItem>
                                                    <asp:ListItem Text ="D" Value="D"></asp:ListItem>
                                                    <asp:ListItem Text ="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text ="P" Value="P"></asp:ListItem>
                                                    <asp:ListItem Text ="T" Value="T"></asp:ListItem>
                                                    <asp:ListItem Text ="I" Value="I"></asp:ListItem>
                                                    <asp:ListItem Text ="V" Value="V"></asp:ListItem>
                                                    <asp:ListItem Text ="C" Value="C"></asp:ListItem>
                                                    <asp:ListItem Text ="S" Value="S"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div id="magnify_area">
                                                <asp:Label ID="div_Commercial_TaxTypecode" runat="server" CssClass="tag_label_transaction_General_commercialtax"></asp:Label>
                                            </div>
                                        </div>
                                          <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_trans_cth_label" style="margin-left:330px">
                                            <asp:TextBox ID="lbl_GSTN_Type" runat="server" BorderStyle="None" Style="text-align: center"></asp:TextBox>
                                        </div>
                                        </div>
                                    </div>
                                    <div id="tag" runat="server" style="display: none;">
                                        <div id="tag_label_transaction_popup_gen">

                                            Ware House Name
                                        </div>
                                        <div id="txtcon-m_transaction_gen_warehouse">
                                            <asp:TextBox ID="txtWarehouseName" runat="server" CssClass="txtbox_none_Mid_transac_gen_ware"
                                                MaxLength="50" TabIndex="25"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_IGM2_empty">
                                        </div>
                                        <div id="tag_label_transaction_popup_trans_gen_smal_label">
                                            Code</div>
                                        <div id="txtcon-m_transaction_item_maindet">
                                          <%--  <asp:TextBox ID="txtWarehouseCode" runat="server" CssClass="txtbox_none_Mid_transac_item_maindet"
                                                MaxLength="50" TabIndex="26"></asp:TextBox>--%>
                                        </div>
                                    </div>
                                </div>
                                <div id="pop_text_area_transac_popup_inn_container_rght_new">
                                   <%-- <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Filing Status
                                        </div>
                                        <div id="txtcon-m_transaction_list1">
                                            <asp:DropDownList ID="ddlFilingStatus" runat="server" CssClass="listtxt_transac_src1"
                                                TabIndex="27">
                                            </asp:DropDownList>
                                        </div>
                                    </div>--%>
                                        <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Warehouse Code</div>
                                        <div id="txtcon-m_transaction_Inv_No" >
                                         <asp:TextBox ID="txtWarehouseCode" Font-Size="12px" runat="server" MaxLength="8" CssClass="txtbox_none_Mid_transac_Inv_No" Enabled="false"
                                               ClientIDMode="Static" TabIndex="28"></asp:TextBox>
                                        </div>

                                           <div id="tag_label_transaction_Src_new" style="width: 45px; text-align: center;">
                                                <asp:Label ID="lbl_ETA" runat="server" Text="ETA"></asp:Label>
                                            </div>
                                            <div id="txtcon-m_transaction_code" style="width: 95px;">
                                                <asp:TextBox ID="txt_ETA_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                                    Width="80px" MaxLength="10" TabIndex="2"></asp:TextBox>
                                                <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_ETA_Date"
                                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                                </cc1:MaskedEditExtender>
                                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_ETA_Date"
                                                    PopupButtonID="txt_ETA_Date" Format="dd/MM/yyyy">
                                                </cc1:CalendarExtender>
                                            </div>
                                            <div id="editbu" class="padding">
                                                <asp:ImageButton ID="btn_ETA_Bulk" Height="26px" Width="25px" ToolTip="ETA Tracking"
                                                    ImageUrl="~/images/icons/ETA_Alert3.png" runat="server" OnClientClick="Bulk_ETA(); return false;" />
                                            </div>
                                    </div>



                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Section 46
                                        </div>
                                        <div id="txtcon_transac_checkbox">
                                            <asp:CheckBox ID="chkSection46" runat="server" Checked="false" TabIndex="28" />
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtSection46Desc" runat="server" MaxLength="50" Onkeypress="return numchar(event)"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic" Enabled="False" 
                                                TabIndex="29"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            First Check
                                        </div>
                                        <div id="txtcon_transac_checkbox">
                                            <asp:CheckBox ID="chkFirstCheck" runat="server" Checked="false" TabIndex="30" />
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtFirstCheckDesc" runat="server" MaxLength="2000" Onkeypress="return numchar(event)"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic" Enabled="False" 
                                                TabIndex="31"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Green Channel
                                        </div>
                                        <div id="txtcon_transac_checkbox">
                                            <asp:CheckBox ID="chkGreenChannel" runat="server" Checked="false" 
                                                TabIndex="32" />
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtGreenChannelDesc" runat="server" MaxLength="50" Onkeypress="return numchar(event)"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic" Enabled="False" 
                                                TabIndex="33"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Kachcha B/E
                                        </div>
                                        <div id="txtcon_transac_checkbox">
                                            <asp:CheckBox ID="chkKachha" runat="server" Checked="false" TabIndex="34" />
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtKachhaDesc" runat="server" Onkeypress="return numchar(event)"
                                                MaxLength="50" CssClass="txtbox_none_Mid_transac_pop_gen_srcic" Enabled="False"
                                                TabIndex="35"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Section 48
                                        </div>
                                        <div id="txtcon_transac_checkbox">
                                            <asp:CheckBox ID="chkSection48" runat="server" Checked="false" TabIndex="36" />
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtSection48Desc" runat="server" MaxLength="2000" Onkeypress="return numchar(event)"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic" Enabled="False" 
                                                TabIndex="37"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen2">
                                            Prov. Assessment.
                                        </div>
                                        <div id="txtcon_transac_checkbox">
                                            <asp:CheckBox ID="chkProvisional" runat="server" Checked="false" TabIndex="38" />
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:TextBox ID="txtProvisionalDesc" runat="server" MaxLength="2000" Onkeypress="return numchar(event)"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic" Enabled="False"
                                                TabIndex="38"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="txtcon_transac_checkbox"  style="margin-top:-5px;" >
                                            <asp:CheckBox ID="chkHighSeaSale" runat="server" Checked="false" onclick="jQuery('#form1').validationEngine('hideAll')"
                                                TabIndex="38" style="text-align:left"/>
                                        </div>
                                        <div id="tag_label_transaction_HighSeaSale_label" style="width:75px;">
                                            HSS 
                                        </div>

                                        <div id="tag_label_transaction_popup_gen"  style="width:75px;">
                                            Seller Name
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new"  style="width:231px;">
                                            <asp:TextBox ID="txtSellerName" runat="server" MaxLength="40" onblur="ChangeCase(this);"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" ClientIDMode="Static" Width="228px"
                                                Enabled="False" TabIndex="39" Onkeypress="return numcharspl1(event)"></asp:TextBox>
                                            <%--<asp:TextBox ID="txtMRP_SL_NO" runat="server" Enabled="False" MaxLength="10" onkeypress= "return numchar(event)"
                                                       CssClass="validate[required] txtbox_none_Promas2" TabIndex="4"></asp:TextBox>--%>
                                        </div>
                                        <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporter_Master('seller'); return false">
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen" style="width:55px;">
                                            IEC No
                                        </div>
                                        <div id="txtcon-m_transaction_code"  style="width:185px;">
                                            <asp:TextBox ID="txtHighSeaSaleIECNo" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                Enabled="False" ClientIDMode="Static" TabIndex="40"  Width="178px" 
                                                onkeypress="return pin(event)"></asp:TextBox>
                                        </div>
                                         <div id="tag_label_transaction_popup_gen" style="text-align:center; width:60px">
                                            Br.Sl.No
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet"  style="width:105px;">
                                        <asp:TextBox ID="txtBranchSLNo" runat="server" MaxLength="3" CssClass="txtbox_none_Mid_transac_item_maindet"
                                                Enabled="False" ClientIDMode="Static" TabIndex="41"  Width="102px"
                                                onkeypress="return pin(event)"></asp:TextBox>
                                        </div>
                                         <div id="magnify_area">
                                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporter_Master_HighSea_BranchSlno('Import_HighSea_Branch');return false">
                                            </a>
                                        </div>
                                    </div>
                                  
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen" style="width:55px;">
                                            Address
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen3"  style="width:185px;">
                                            <asp:TextBox ID="txtHighSeaSaleAddress" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                Enabled="False" ClientIDMode="Static" TabIndex="42" Width="178px"></asp:TextBox>
                                        </div>
                                        <div id="tag_label_transaction_popup_gen" style="text-align:center; width:60px;">
                                            Ad Code
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet"  style="width:105px;">
                                            <asp:TextBox ID="txtHSS_AdCode" runat="server" MaxLength="14" CssClass="txtbox_none_Mid_transac_item_maindet"
                                                ClientIDMode="Static" TabIndex="42" Width="102px" onkeypress="return pin(event)"></asp:TextBox>
                                        </div>
                                         <div id="magnify_area">
                                            <a class="magnfy" href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupAdcode(document.getElementById('txtSellerName').value,document.getElementById('txtHighSeaSaleIECNo').value,'IMPORT_HSS'); return false">
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                       
                                        <div id="tag_transac_lft_in1">
                                            <asp:TextBox ID="txtHighSeaSaleAddress1" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                Enabled="False" ClientIDMode="Static" TabIndex="43"></asp:TextBox>
                                             <asp:TextBox ID="txtHighSeaSaleAddress2" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                Enabled="False" ClientIDMode="Static" TabIndex="44"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div id="tag_transac_lft_in1">
                                      
                                            <asp:TextBox ID="txtHighSeaSaleAddress3" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                Enabled="False" ClientIDMode="Static" TabIndex="45"></asp:TextBox>
                                            <asp:TextBox ID="txtHighSeaSaleAddress4" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen3"
                                                Enabled="False" ClientIDMode="Static" TabIndex="46"></asp:TextBox>
                                       
                                    </div>
                                    <%-- SINGLE WINDOW OPERATION FIELDS --%>

                                     <div id="tag_transac_lft_in1">
                                      <div id="tag_label_transaction_popup_gen" style="width:155px">
                                           Preceding Level (0 OR 1)</div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width:45px">
                                           <asp:TextBox ID="txt_PrecedingLevel" runat="server" Enabled="False"  MaxLength="1" CssClass="txtbox_none_Mid_transac_item_maindet"
                                           ClientIDMode="Static" TabIndex="47"  Width="45px" Onkeypress="return num1(event)" ></asp:TextBox>
                                               
                                        </div>
                                        <div id="tag_label_transaction_popup_mode_empty"></div>
                                        <div id="tag_label_transaction_popup_gen">
                                            Payment Method</div>
                                        <div id="txtcon-m_transaction_item_maindet">
                                            <asp:TextBox ID="txt_Payment_Method" runat="server" MaxLength="1" CssClass="validate[required] txtbox_none_Mid_transac_item_maindet"
                                               Text="T"  ClientIDMode="Static" TabIndex="51" 
                                                onkeypress="return char(event)"  Width="45px" ></asp:TextBox>
                                        </div>

                                     </div>
                                    <div id="UCR" runat="server" visible="false">
                                        <div id="tag_transac_lft_in1">
                                            <div id="tag_label_transaction_popup_gen" style="width: 75px;">
                                                UCR Ref No.</div>
                                            <div id="txtcon-m_transaction_item_maindet" style="width: 45px;">
                                                <asp:TextBox ID="txt_UCR_Ref_No" runat="server" MaxLength="35" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                    Enabled="false" ClientIDMode="Static" TabIndex="49"></asp:TextBox>
                                            </div>
                                            <div id="tag_label_transaction_popup_mode_empty">
                                            </div>
                                            <div id="tag_label_transaction_popup_gen" style="width: 50px;">
                                                 UCR Type </div>
                                            <div id="txtcon-m_transaction_item_maindet" style="width: 45px;">
                                                  <asp:TextBox ID="txt_UCR_Type" runat="server" MaxLength="6" CssClass="txtbox_none_Mid_transac_code"
                                                    Enabled="false" ClientIDMode="Static" TabIndex="50"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                   
                                     <div id="ELogix_Chennai" visible="false" runat="server">
                                     <div id="tag_transac_lft_in1">
                                      <div id="tag_label_transaction_popup_gen" style="width:105px">
                                          Refered Location
                                          </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width:110px">
                                           <asp:TextBox ID="txt_Ref_Loc" runat="server"  Enabled="false"  CssClass="txtbox_none_Mid_transac_item_maindet"
                                           ClientIDMode="Static" TabIndex="50"  Width="100px" ></asp:TextBox>
                                               
                                        </div>
                                        
                                        <div id="tag_label_transaction_popup_gen">
                                           Refered Type</div>
                                        <div id="txtcon-m_transaction_item_maindet">
                                           <asp:DropDownList ID="ddl_Ref_Type" runat="server" Enabled="false" CssClass="listtxt_transac_mode_new" TabIndex="50">
                                               <asp:ListItem Text="S" Value="S" ></asp:ListItem> 
                                               <asp:ListItem Text="M" Value="M" ></asp:ListItem> 
                                            </asp:DropDownList>
                                        </div>
                                     </div>
                                    </div>


                                    <div id="div_AmendmentType"  Visible="false" runat="server"  style="margin-top:5px">
                                        <div id="tag_label_transaction_popup_gen" style="width: 105px; font-weight: bold;">
                                         Amend Type
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width: 110px">
                                            <asp:DropDownList ID="ddl_AmendmentType" runat="server" TabIndex="1" CssClass="listtxt_transac_mode_new"
                                                Width="100px" >
                                                <asp:ListItem Value=""></asp:ListItem>
                                                <asp:ListItem Value="A">AMENDMENT</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div id="editbu" style="margin-top:-5px;">
                                            <asp:Button ID="btn_Amend_FF" Text="Flatfile" CssClass="autowidmovebut" runat="server"
                                                OnClientClick="Open_Amend_Flatfile(); return false" Width="60px" />
                                        </div>
                                    </div>
                                        

                                         

                                </div>
                            </div>
                            <div id="pop_text_area_transac_popup_inn_container2" style="display: none;">
                                <div id="pop_text_area_Transact_remarks">
                                    <div id="tag_label_transaction_popup_gen">
                                        Remarks</div>
                                    <div id="txtcon-m_Maxtxt_trans_gen_remarks">
                                        <asp:TextBox ID="txtRemarks" CssClass="txtbox_none_transac_gen_remarks" onkeyDown="return checkTextAreaMaxLength(this,event,'120');"
                                            TextMode="MultiLine" runat="server" TabIndex="49" MaxLength="120" onpaste="return checkTextAreaMaxLength(this,event,'120');"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="lblMsg2" style="display: none;">
                                </div>
                            </div>
                            <div id="innerbox_MidMain_bot_transact" runat="server" style="width:900px;">
                                <div id="innerbox_transac_bot_inn"  style="width:890px;">
                                    <div id="newbu">
                                        <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                            TabIndex="55" />
                                    </div>
                                    <div id="editbu">
                                        <%--<asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate(document.getElementById('#hdn_CompanyID').value);"
                                            TabIndex="52" OnClick="btnSave_Click" CommandName="s"/>--%>
                                        <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                            TabIndex="52" OnClick="btnSave_Click" CommandName="s"/>
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"  
                                            OnClientClick="return validate();" TabIndex="53" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnDelete" runat="server" TabIndex="54" CausesValidation="false"
                                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job?', 'GENERAL', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;"   />
                                        <asp:Button ID="btn" runat="server" TabIndex="54" OnClick="btnDelete_Click" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />
                                             <asp:Button ID="btnAuto_Jobno" runat="server" TabIndex="51" OnClick="btnAuto_Jobno_Click" CausesValidation="false"
                                            UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                            CssClass="dlete" Style="display: none;" />

                                    </div>
                                     <div id="editbu">
                                        <asp:Button ID="btnsavenext" Text="Save  & Next" TabIndex="52" CssClass="autowidupdatebut" OnClientClick="return validate();" runat="server"  OnClick="btnsavenext_Click" />
                                              
                                    </div>

                                    <div id="editbu">
                                        <input type="submit" value="Submit" class="scancel" onclick="RefreshParent_New(); return false;"
                                            id="btnCancel" tabindex="55">
                                    </div>
                                    <div id="editbu">
                                    <asp:Button ID="btngenexcel" runat="server" Width="100px"  CausesValidation="false" UseSubmitBehavior="false" Visible="false"
                                    CssClass="autowidmovebut" Text="Excel Upload" OnClientClick="jQuery('#form1').validationEngine('hide');open_JobWise_Excel_Upload('New');return false;"  />
                                    </div>
                                     <div id="editbu">
                                    <asp:Button ID="btnSignedBE" runat="server" Visible="false" CausesValidation="false" UseSubmitBehavior="false"
                                    CssClass="autowidmovebut" Text="FF Reader" OnClientClick="jQuery('#form1').validationEngine('hide');open_IMPORT_SignedBE_Upload('New');return false;"  />
                                    </div>
                                    
                                    <div id="editbu">
                                        <asp:Button ID="btnDSR" Text="DSR" CssClass="autowidmovebut" runat="server" Visible="false"
                                            OnClientClick="IMP_DSR(); return false" Width="60px" />
                                    </div>

                                    <div id="editbu">
                                        <asp:Button ID="btnPDFUpload_New" runat="server" Width="80px" CausesValidation="false"
                                            Visible="false" UseSubmitBehavior="false" CssClass="autowidmovebut" Text="PDF New"
                                            OnClientClick="jQuery('#form1').validationEngine('hide');open_Imp_UPload_PDF('New');return false;" />
                                    </div>
                                    <div id="editbu">
                                        <asp:Button ID="btnPDFUpload_Manual" runat="server" Width="80px" CausesValidation="false"
                                            Visible="false" UseSubmitBehavior="false" CssClass="autowidmovebut" Text="PDF Upload"
                                            OnClientClick="jQuery('#form1').validationEngine('hide');open_Imp_Manual_UPload_PDF('New');return false;" />
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <div class="content" id="page-2" style="display: none;">
                    <iframe src="" name="maineroyal" scrolling="no" id="Trans_igm_Iframe" ></iframe>
                </div>
                <div class="content" id="page-3" style="display: none;">
                    <iframe src="" name="maineroyal1" scrolling="no" id="Trans_igm_Invoice_Iframe">
                    </iframe>
                </div>
                <div class="content" id="page-4" style="display: none;">
                    <iframe src="" name="maineroyal2" scrolling="no" id="Trans_igm_item_Iframe" ></iframe>
                </div>
                <div class="content" id="page-5" style="display: none;">
                   <iframe src="" name="maineroyal3" scrolling="no" style="width:958px" id="Trans_igm_CHKLIST_Iframe" ></iframe>
                </div>
                <div class="content" id="page-6"  style="display: none;">
                   
                </div>
                 <div class="content" id="page-9" style="display: none;">
                   
                </div>
                <div class="content" id="page-7" style="display: none;">
                   
                </div>

                <div class="content" id="page-8" style="display: none;">
                   <iframe src="" name="maineroyal2" scrolling="no" id="Iframe_E_Way_Bill" ></iframe>
                </div>

                 <div class="content" id="page-10" style="display: none;">
                   
                </div>
                <div class="content" id="page-11" 
                    style="display: none;  height: 390px; margin-left: -16px;">
                    <iframe src="" name="trans_Acc_charge"  width="1040px" height="390px" scrolling="no" id="Iframe1_Imp">
                    </iframe>
                </div>
                
                <div class="content" id="page-13" 
                    style="display: none;  height: 390px; margin-left: -16px;">
                    <iframe src="" name="trans_Acc_Financial"  width="1040px" height="390px" scrolling="no" id="Iframe1_Fin">
                    </iframe>
                </div>
                
                <div class="content" id="page-12" style="display: none;">
                    <iframe src="" name="Imp_SDF_OtherScrn" width="1040px" height="400px" style="margin-left: -5px;
                        margin-top: -10px" scrolling="no" id="Imp_SDF_OtherScrn"></iframe>
                </div>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9', 'page-10', 'page-11', 'page-12', 'page-13']);
            </script>
            <div style="display: none;">
                
                <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:HiddenField ID="chksec46" runat="server" Value="N" ClientIDMode="Static" />
                <asp:HiddenField ID="chkFirCheck" runat="server" Value="N" ClientIDMode="Static" />
                <asp:HiddenField ID="chkGrnChannel" runat="server" Value="N" ClientIDMode="Static" />
                <asp:HiddenField ID="chkKach" runat="server" Value="N" ClientIDMode="Static" />
                <asp:HiddenField ID="chkSec48" runat="server" Value="N" ClientIDMode="Static" />
                <asp:HiddenField ID="chkHghSeaSale" runat="server" Value="N" ClientIDMode="Static" />
                <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_val_updateid" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_ImporterType" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Update_General" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="Hdcountryoforgin_chk" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="Hdcountryofshipment_chk" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="Hdportoforgin_Chk" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="Hdportofshipment_chk" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hd_joblck" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CountryCD_PortOrigin_chk" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_CountryCD_PortofShipment_chk" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="chkProv" runat="server" Value="N" ClientIDMode="Static" />



                <asp:HiddenField ID="hdimp" runat="server" />
                <asp:HiddenField ID="hd_Brslno" runat="server" />

                <asp:HiddenField ID="hd_hss_imp" runat="server" />
                <asp:HiddenField ID="hd_hss_br_sl_no" runat="server" />

                <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" />
        
                <asp:HiddenField ID="hdn_TIN_NO" runat="server" />
                <asp:HiddenField ID="hdn_StateCode" runat="server" />
                <asp:HiddenField ID="hdn_StateName" runat="server" />
                <asp:HiddenField ID="hdn_commercialType" runat="server" />

                <asp:HiddenField ID="hdsaveandclose" runat="server" />
                <asp:HiddenField ID="hdprefix" runat="server" />
                <asp:HiddenField ID="hdsuffix" runat="server" />
                <asp:HiddenField ID="hdn_New_Update" runat="server" />

                <asp:HiddenField ID="hdn_currentPage" runat="server" />
                <asp:HiddenField ID="hdn_source" runat="server" />
                <asp:HiddenField ID="hdn_StateName_chk" runat="server" ClientIDMode="Static" />
                <asp:HiddenField ID="hdn_Customhouse_chk" runat="server" ClientIDMode="Static" />

               
                <asp:HiddenField ID="hdn_FRT_GroupID" runat="server" />
                <asp:HiddenField ID="hdn_FRT_Branch" runat="server" />
                  
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
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:500px; height:80px; ">
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

      <%-- ---------------------------------------------------------ModelpopUp---2------------------------------------------------------------------------------%>
    <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job" BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 450px; height: 129px;">
            <div id="innerbox_MidMain_Transact_popup_new" style="width: 449px; height: 129px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Job Edit
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <asp:Button ID="btnCl" runat="server" CssClass="clsicon_new" OnClientClick="return HideModalPopup()"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                </div>
                <div id="tag_transaction_inner_new" style="margin-left: 20px; margin-top: 10px; width: 500px;">
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_date" style="width: 75px; text-align: center;">
                            Edit Jobno
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 350px;">
                            <asp:TextBox ID="txt_M_jobps" placeholder="Prefix" Width="80px" runat="server" Onkeypress="return numcharspl1(event)"
                                MaxLength="30" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" autocomplete="off"></asp:TextBox>
                            <asp:TextBox ID="txt_jobno" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                autocomplete="off" onkeypress="return pin(event)"></asp:TextBox>
                            <asp:TextBox ID="txt_M_jobsf" runat="server" MaxLength="30" placeholder="Suffix"
                                Onkeypress="return numcharspl1(event)" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                Width="80px" autocomplete="off"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty" style="margin-left: 10px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txt_jobno"
                                ForeColor="Red" runat="server" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 30px;">
                            <%--  <asp:Label ID="lblalt" runat="server" ></asp:Label>--%>
                            <%-- <asp:TextBox ID="txtid" runat="server" ForeColor="Red" BorderStyle="none" ReadOnly="true"></asp:TextBox>--%>
                        </div>
                        <%--<div id="txtcon-m_transaction_mode" style="width:60px;" >
                        </div>--%>
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_label_transaction_popup_IGM2_empty_gen">
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="txtcon-m_transaction_code" style="width: 300px;">
                            <span style="color: Red;">
                                <asp:Literal ID="txtid" runat="server"></asp:Literal></span>
                        </div>
                    </div>
                    <div id="tag_Exchange_lft_in1_new1">
                        <div id="tag_label_transaction_Src_new" style="width: 30px;">
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 60px;">
                        </div>
                        <div id="tag_label_transaction_date" style="width: 75px; text-align: center;">
                            <asp:Button ID="btnok" runat="server" Text="Ok" UseSubmitBehavior="false" OnClick="btnok_Click" />
                        </div>
                        <div id="txtcon-m_transaction_code">
                            <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClientClick="return HideModalPopup()"
                                CausesValidation="false" UseSubmitBehavior="false" />
                        </div>
                        <div id="tag_label_transaction_popup_mode_empty">
                        </div>
                        <div id="tag_label_transaction_Src_longlabel" style="width: 30px;">
                        </div>
                        <div id="txtcon-m_transaction_mode" style="width: 60px;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>

     <%-- ---------------------------------------------------------End ModelpopUp---2------------------------------------------------------------------------------%>

     <asp:HiddenField ID="hdn_Regn_no" runat="server" />
     <asp:HiddenField ID="hdn_CompanyID" runat="server" ClientIDMode="Static" />
  

    </form>
    <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/General_Igm.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>
  <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            //document.getElementById("btnCancel").click();
            document.getElementById("General").click();
        }
    </script>



  <script language="javascript">

          function calculateTotal(thisCheckbox) {

              var TextBox1 = document.getElementById("txt_Branch").value;
              var TextBox2 = document.getElementById("txt_jobno").value;
              var TextBox3 = document.getElementById("txtyear").value;

              if (document.getElementById("Chbranch").checked == true && document.getElementById("chyear").checked == true) {

                  if (TextBox1.trim() != '' && TextBox2.trim() != '' && TextBox3.trim() != '') {

                      var TextBox1 = document.getElementById("txt_Branch").value + '/';
                      var TextBox2 = document.getElementById("txt_jobno").value + '/';
                      var TextBox3 = document.getElementById("txtyear").value;

                      var res = TextBox1.concat(TextBox2, TextBox3);
                      document.getElementById("txtpreview").value = res;
                  }
                  else if (TextBox1.trim() != '' && TextBox2.trim() != '' && TextBox3.trim() == '') {

                      var TextBox1 = document.getElementById("txt_Branch").value + '/';
                      var TextBox2 = document.getElementById("txt_jobno").value;

                      var res1 = TextBox1.concat(TextBox2);
                      document.getElementById("txtpreview").value = res1;
                  }
                  else if (TextBox1.trim() == '' && TextBox2.trim() != '' && TextBox3.trim() != '') {

                      var TextBox2 = document.getElementById("txt_jobno").value + '/';
                      var TextBox3 = document.getElementById("txtyear").value;

                      var res2 = TextBox2.concat(TextBox3);
                      document.getElementById("txtpreview").value = res2;

                  }
                  else if (TextBox1.trim() != '' && TextBox2.trim() == '' && TextBox3.trim() != '') {
                      document.getElementById("txtpreview").value = '';

                  }
              }
              //----------------------------------------------------------------------------------------------------------
              else if (document.getElementById("Chbranch").checked == true && document.getElementById("chyear").checked == false) {

                  if (TextBox1.trim() != '' && TextBox2.trim() != '') {
                      var TextBox1 = document.getElementById("txt_Branch").value + '/';
                      var TextBox2 = document.getElementById("txt_jobno").value;

                      var res3 = TextBox1.concat(TextBox2);
                      document.getElementById("txtpreview").value = res3;

                  }
                  else {
                      document.getElementById("txtpreview").value = document.getElementById("txt_jobno").value;
                  }

              }
              //-------------------------------------------------------------------------------------------------------------------------------------
              else if (document.getElementById("Chbranch").checked == false && document.getElementById("chyear").checked == true) {

                  if (TextBox2.trim() != '') {
                      var TextBox2 = document.getElementById("txt_jobno").value + '/';
                      var TextBox3 = document.getElementById("txtyear").value;

                      var res4 = TextBox2.concat(TextBox3);
                      document.getElementById("txtpreview").value = res4;
                  }
                  else {

                      document.getElementById("txtpreview").value = '';
                  }

              }
              else if (document.getElementById("Chbranch").checked == false && document.getElementById("chyear").checked == false) {

                  document.getElementById("txtpreview").value = document.getElementById("txt_jobno").value;
              }
          }
</script>

  <script type="text/javascript">
        $(document).ready(function () {

            $('#txtImporterName').focus(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtImporterName').change(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtImporterName').keyup(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtImporterName').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });

        });

        function Item_desc(val) {

            var data = val;
            if (data == '') {
                $('#txtImporterName').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');
                var compid = document.getElementById("hdn_CompanyID").value;
             
                var before = s[0];
                var after = '';

                if (compid == '1' || compid == '2145') {
                    after = s[2];
                }
                else {
                    after = s[1];
                }

                $('#txtImporterName').val(after);

                $('#hdimp').val(after);
                $('#hd_Brslno').val(before);

            }
            else {

            }
        }
  </script>

  <script type="text/javascript">
      $(document).ready(function () {

          $('#txtWarehouseCode').focus(function () {

              var data = $(this).val();
              WH_Code(data);

          });
          $('#txtWarehouseCode').change(function () {

              var data = $(this).val();
              WH_Code(data);

          });
          $('#txtWarehouseCode').keyup(function () {

              var data = $(this).val();
              WH_Code(data);

          });
          $('#txtWarehouseCode').keydown(function () {

              var data = $(this).val();
              WH_Code(data);

          });

      });

      function WH_Code(val) {

          var data = val;
          if (data == '') {
              $('#txtWarehouseCode').val('');
          }
          if (data.indexOf("--") != -1) {

              var s = data.split('--');
              var before = s[0];
              var after = s[1];
              $('#txtWarehouseCode').val(before);
          }
          else {

          }
      }
  </script>

  <script type="text/javascript">
      $(document).ready(function () {

          $('#txtSellerName').focus(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txtSellerName').change(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txtSellerName').keyup(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txtSellerName').keydown(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
      });

      function Item_desc1(val) {

          var data1 = val;
          if (data1 == '') {
              $('#txtSellerName').val('');
          }
          if (data1.indexOf("--") != -1) {

              var s = data1.split('--');

              var before = s[0];
              var after = s[1];

              $('#txtSellerName').val(after);

              $('#hd_hss_imp').val(after);
              $('#hd_hss_br_sl_no').val(before);

          }
          else {

          }
      }
  </script>

     <script src="../js/Import_Jscript/Import_Jobedit.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/BE_Status.js" type="text/javascript"></script>

  <script type="text/javascript">

         function BE_Track() {
             var BeNo = document.getElementById("txtBE_No").value;
             var Date = document.getElementById("txtBE_Date").value;
             var Port = document.getElementById("txtCustomsHouse").value;
             var ddl = document.getElementById('ddlTransportMode');
             var mode = ddl.options[ddl.selectedIndex].value;

             var values = Date.split('/');

             var dd = values[0];
             var mm = values[1];
             var yy = values[2];

             var Bedate = yy + '/' + mm + '/' + dd;
             if (mode == 'Air' || mode == 'Sea' || mode == 'Land') {
                 BE_Status(BeNo, Bedate, Port, mode);
             }
         }
 </script>

 <script type="text/javascript">
     $(document).ready(function () {

         if ($("#ddlTransportMode option:selected").text() == 'Air') {

             $("#ddlContainer_Type option[value='LCL']").remove();
             $("#ddlContainer_Type option[value='FCL']").remove();
             $("#ddlContainer_Type option[value='Bulk']").remove();

             $('#ddlContainer_Type').attr('disabled', 'disabled');
             //$('#dropdown').removeAttr('disabled');
         }
         else {
             $("#ddlContainer_Type option[value='']").remove();
         }

         $('#ddlTransportMode').change(function () {

             if ($("#ddlTransportMode option:selected").text() == 'Air') {

                 $("#ddlContainer_Type option[value='LCL']").remove();
                 $("#ddlContainer_Type option[value='FCL']").remove();
                 $("#ddlContainer_Type option[value='Bulk']").remove();

                 $('#ddlContainer_Type').attr('disabled', 'disabled');
             }
             else {
                 $("#ddlContainer_Type option[value='']").remove();

                 $("#ddlContainer_Type option[value='LCL']").remove();
                 $("#ddlContainer_Type option[value='FCL']").remove();
                 $("#ddlContainer_Type option[value='Bulk']").remove();

                 $("#ddlContainer_Type").append('<option value="LCL">LCL</option>');
                 $("#ddlContainer_Type").append('<option value="LCL">FCL</option>');
                 $("#ddlContainer_Type").append('<option value="LCL">Bulk</option>');

                 $('#ddlContainer_Type').removeAttr('disabled');
             }


         });
     });
</script>

<script type="text/javascript">
    $(document).ready(function () {
        $('#ddl_Commercial_Type').change(function () {
            var Type = $('#ddl_Commercial_Type').val();

            if (Type == 'G') {
                $('#lbl_GSTN_Type').val('GSTIN-NORMAL');
            }
            else if (Type == 'O') {
                $('#lbl_GSTN_Type').val('GSTIN-GOVERNMENT');
            }
            else if (Type == 'D') {
                $('#lbl_GSTN_Type').val('GSTIN-DIPLOMAT');
            }
            else if (Type == 'A') {
                $('#lbl_GSTN_Type').val('AADHAAR');
            }
            else if (Type == 'P') {
                $('#lbl_GSTN_Type').val('PASSPORT');
            }
            else if (Type == 'T') {
                $('#lbl_GSTN_Type').val('TIN');
            }
            else if (Type == 'I') {
                $('#lbl_GSTN_Type').val('PAN');
            }
            else if (Type == 'V') {
                $('#lbl_GSTN_Type').val('VAT');
            }
            else if (Type == 'C') {
                $('#lbl_GSTN_Type').val('CST');
            }
            else if (Type == 'S') {
                $('#lbl_GSTN_Type').val('ST');
            }
            else if (Type == '') {
                $('#lbl_GSTN_Type').val('');
            }
        });
    });

</script>


<script type="text/javascript">

    $(document).ready(function () {
        BindControls();
    });

    function BindControls() {
        var Notn = ['T', 'D'];

        $('#txt_Payment_Method').autocomplete({
            source: Notn,
            minLength: 0,
            scroll: true
        }).focus(function () {
            $(this).autocomplete("search", "");
        });
    }

  </script>


  
  <script type="text/javascript">
      $(document).ready(function () {
          // document.onkeydown = click_TABS;
          document.onkeypress = click_TABS;
          document.onkeyup = click_TABS;

          function click_TABS(e) {
              //if (window.event);
              if (window.event.ctrlKey)
                  var keyCode = window.event.keyCode;       // IE

              else
                  var keyCode = e.which;

              var ctrl_n = document.getElementById("hdn_currentPage").value;

              if (e.ctrlKey) {
                  if (keyCode == 39) {
                      if (ctrl_n == 'General') {
                          document.getElementById('IGM').click();
                      }
                  }
              }
          }
      });
 </script>

   <script>
       $(function () {

           $("#General").click(function () {
               //alert(document.getElementById("hdn_source").value);
               //------------------------------- Forward Pages - start ------------------------

               if (document.getElementById("hdn_source").value == 'Tab_IGM') {
                   document.getElementById('INVOICE').click();
               }

               if (document.getElementById("hdn_source").value == 'Tab_Invoice') {
                   document.getElementById('ITEM').click();
               }
               
               if (document.getElementById("hdn_source").value == 'Tab_Item') {
                   document.getElementById('Checklist').click();
               }

               if (document.getElementById("hdn_source").value == 'Tab_Checklist') {
                   document.getElementById('Submission').click();
               }
               if (document.getElementById("hdn_source").value == 'Tab_Submission') {
                   document.getElementById('Jobhistry').click();
               }

               //------------------------------- Backward Pages - start ------------------------

               if (document.getElementById("hdn_source").value == 'Tab_IGM_Prev') {
                   document.getElementById('General').click();
               }

               if (document.getElementById("hdn_source").value == 'Tab_Invoice_Prev') {
                   document.getElementById('IGM').click();
               }

               if (document.getElementById("hdn_source").value == 'Tab_Item_Prev') {
                   document.getElementById('INVOICE').click();
               }
              
               if (document.getElementById("hdn_source").value == 'Tab_Checklist_Prev') {
                   document.getElementById('ITEM').click();
               }
               if (document.getElementById("hdn_source").value == 'Tab_Submission_Prev') {
                   document.getElementById('Checklist').click();
               }

               //------------------------------- Backward Pages -end ------------------------
           });
       });
</script>

<script type="text/javascript">

    function RefreshParent_New() {
        window.parent.location.href = window.parent.location.origin + window.parent.location.pathname + '?ClosePop=true';
    }

    function IMP_DSR() {
        NewWindow1('../DSR/Cus_DSR_Imp_Job.aspx', 'List', '1100', '1000', 'yes');
    }

    function Open_Amend_Flatfile() {

        var amd_type = document.getElementById("ddl_AmendmentType").value; 
        var amd_page = 'GENERAL';
        var amd_Jobno = document.getElementById("txtJobNo").value;
      
        NewWindow1('../Amendment/Import_Amendment.aspx?amd_type=' + amd_type + '&amd_page=' + amd_page + '&amd_Jobno=' + amd_Jobno, 'List', '950', '515', 'yes');
    }


    function Bulk_ETA() {
        var jobno = document.getElementById("txtJobNo").value;

        if (jobno != '') {
            NewWindow1('../Import_Report/Imp_ETA_Bulk.aspx?JOBNO=' + jobno + '', 'List', '1250', '1024', 'yes');
        }
        else {
            alert('Select a Job');
        }
    }



</script>

 <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
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
    <script type="text/javascript">
        function DropdownChange() {

            var CusHouse = document.getElementById('txtCustomsHouse').value;
            var Jobno = document.getElementById('txtjobps').value;
            PageMethods.Transport_Mode(CusHouse, Jobno, Callsucces_Transp);
        }
        function Callsucces_Transp(selectedValue) {
            var splitValues = selectedValue.split("~");
            var ddlTransmode = document.querySelector('#ddlTransportMode');
            ddlTransportMode.value = splitValues[0];
            if (splitValues.length > 1 && splitValues[1] === "Yes") {

                if (confirm("Container Details available.Do you want to delete?")) {

                }
                else {

                    PageMethods.Transport_Mode_Customhouse(UpdateUIFromSession);
                }
            }
        }
        function UpdateUIFromSession(response) {
            var splitValues = response.split("~");
            document.getElementById('txtCustomsHouse').value = splitValues[0];
            document.getElementById('ddlTransportMode').value = splitValues[1];
            document.getElementById('txtPortShipment').value = splitValues[2];
            document.getElementById('txtPortOrigin').value = splitValues[3];
        }
    </script>
</body>
</html>



