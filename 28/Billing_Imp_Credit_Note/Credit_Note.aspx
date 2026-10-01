<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Credit_Note.aspx.cs" Inherits="Credit_Note" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> I- Credit Note</title>
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
     <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
    </style>

    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 7.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 10em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
       
       <style type="text/css">  
        .CalendarStyle   
        {  
            background-color:Crimson;  
            color:White;  
            border:solid 2px DarkRed;  
            }  
        .ajax__calendar_header  
        {  
            background-color:#FBB117;  
            color:black;
            }                   
        .ajax__calendar_footer  
        {  
            background-color:#FBB117;  
            color:black;  
            }              
    </style>  
          

    <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }     
        
          .hideGridColumn
        {
            display: none;
        }
        
        .hideGridColumn1
        {
            display: none;
        }
    </style>   

     <script language="javascript">
         function B_G_tab_page2() {

             document.getElementById('page-1').style.display = 'Block';
             document.getElementById('page-2').style.display = 'none';
             document.getElementById('page-3').style.display = 'none';
             document.getElementById('page-4').style.display = 'none';

             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'block';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';

             document.getElementById("Page_A").className = 'inactive';
             document.getElementById("Page_B").className = 'active';
             document.getElementById("Page_C").className = 'inactive';
             document.getElementById("Page_D").className = 'inactive';

             document.getElementById("txtfocus").focus();
         }
   </script>

   <script type="text/javascript">
       $(document).ready(function () {
           $("[id*=txtch_name]").autocomplete({
               source: function (request, response) {
                   $.ajax({
                       url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Billing_Charge_Master_List",
                       data: "{ 'mail': '" + request.term + "' }",
                       dataType: "json",
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       success: function (data) {
                           response($.map(data.d, function (item) {
                               return {
                                   label: item,
                                   val: item
                               }
                           }))
                       },
                       error: function (response) {
                           alert(response.responseText);
                       },
                       failure: function (response) {
                           alert(response.responseText);
                       }
                   });
               },
               select: function (e, i) {
                   $("[id*=hfCustomerId]", $(e.target).closest("td")).val(i.item.val);
               },
               minLength: 1
           });

       });
</script>

 <script type="text/javascript">
function Char_Inv(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
        return false;
    return true;
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
            
            <div class="loading" align="center" id="Div1" style="display:none">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>

            <div id="innerbox_MidMain_Billing" style="height: 95px;width: 1140px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                        I Cr. Note Entry
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 80px;">
                            Generate Bill:
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 200px;">
                            <asp:RadioButtonList ID="Rd_Bill_Type" runat="server" RepeatDirection="Horizontal"
                                AutoPostBack="true" TabIndex="6" OnSelectedIndexChanged="Rd_Bill_Type_SelectedIndexChanged">
                                <asp:ListItem Text="Local State" Value="L" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Other State" Value="O"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="txtcon-m_Exchange" style="width: 200px;">
                            <asp:RadioButtonList ID="Rd_Reg_Sez" runat="server" RepeatDirection="Horizontal"
                                TabIndex="91" ForeColor="Purple">
                                <asp:ListItem Text="Regular Bill" Value="R" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Sez Bill" Value="S"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <div id="txtcon-m_Exchange" style="width: 50px;">
                            <asp:CheckBox ID="Chk_BWC_Tr" Visible="false" Text="Tr."  runat="server" />
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2">
                        <span runat="server" id="WK" visible="false">
                            <div id="tag_label_transaction_popup_gen">
                                Working Period</div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic">
                                <asp:DropDownList ID="ddlWorkingPeriod" runat="server" TabIndex="7" CssClass="txtbox_none"
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
                <div id="tag_transact_src_inner" style="width: 1086px; height: 55px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1085px">
                        <div id="tag_transact_lft_in1" style="width: 1085px; height: 30px;">
                            <div id="txt_container_Transact_Main_l" style="width: 490px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Importer Name</div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddlImp_name" runat="server" class="chosen-select-deselect"
                                        Style="width: 370px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                        TabIndex="8" OnSelectedIndexChanged="ddlImp_name_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:TextBox ID="txtimportername_Other" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                        ClientIDMode="Static" Width="370px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                        TabIndex="8"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 580px;">
                                <div id="div_type" runat="server">
                                    <div id="tag_label_transact_Src" style="width: 50px;">
                                        Inv. No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:DropDownList ID="ddljobno" runat="server" class="chosen-select-deselect" Style="width: 145px;"
                                            data-placeholder="0" AutoPostBack="true" TabIndex="9" OnSelectedIndexChanged="ddljobno_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Branch No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 165px;">
                                        <asp:DropDownList ID="ddlbranch_No" runat="server" class="chosen-select-deselect"
                                            Style="width: 162px;" data-placeholder="Choose a Branch No" TabIndex="10" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlbranch_No_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        From Quotation
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 35px;">
                                        <asp:CheckBox ID="From_Quotation" runat="server" TabIndex="11" Checked="true" />
                                    </div>
                                </div>
                                <div id="div_type_Other" runat="server">
                                    <div id="tag_label_transact_Src" style="width: 140px;">
                                        Branch No
                                        <asp:TextBox ID="txt_branch_No" runat="server" MaxLength="17" Font-Size="12px" onkeyup="autotab(this);"
                                            Width="50px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="13"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transact_Src" style="width: 100px;">
                                        From Quotation
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 50px;">
                                        <asp:CheckBox ID="Other_Quotation" runat="server" TabIndex="14" Checked="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l" style="width: 1080px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Ship Type 1</div>
                                <div id="txtcon-m_Exchange" style="width: 75px;">
                                    <asp:DropDownList ID="ddl_tr_mode" CssClass="validate[required] listtxt_transac_item_gen_notn"
                                        Font-Size="12px" Width="60px" TabIndex="15" runat="server">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Air" Value="Air"></asp:ListItem>
                                        <asp:ListItem Text="Sea" Value="Sea"></asp:ListItem>
                                        <asp:ListItem Text="Land" Value="Land"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 75px;">
                                    Ship Type 2
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                    <asp:DropDownList ID="ddlshipment_type" CssClass="listtxt_transac_item_gen_notn"
                                        Font-Size="12px" Width="80px" TabIndex="16" runat="server">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Bond" Value="Bond"></asp:ListItem>
                                        <asp:ListItem Text="Ex-bond" Value="Exbond"></asp:ListItem>
                                        <asp:ListItem Text="FCL" Value="FCL"></asp:ListItem>
                                        <asp:ListItem Text="LCL" Value="LCL"></asp:ListItem>
                                        <asp:ListItem Text="20 Feet" Value="20"></asp:ListItem>
                                        <asp:ListItem Text="40 Feet" Value="40"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    Your Ref. No
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px; color: #c63939;">
                                    <asp:TextBox ID="txt_ur_Ref_No" runat="server" MaxLength="30" Font-Size="12px" onkeyup="autotab(this);"
                                        Width="105px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="17"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Ass. Value
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 90px;">
                                    <asp:TextBox ID="txt_Ass_Value" runat="server" CssClass="txtbox_none_Mid_transac_Inv_No"
                                        Width="85px" MaxLength="20" TabIndex="20" onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 10px;">
                                </div>
                                <div id="tag_label_transact_Src" style="width: 60px;">
                                    CIF Value
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 95px;">
                                    <asp:TextBox ID="txt_CIF_Value" runat="server" CssClass="txtbox_none_Mid_transac_Inv_No"
                                        Width="85px" MaxLength="20" TabIndex="21" onblur="extractNumber(this,3,false);"
                                        onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>                                
<%--                                <div id="tag_label_transact_Src" style="width: 50px;display:none;">
                                    AC Type</div>
--%>                                
                                    <div id="txtcon-m_Exchange" style="width: 55px;">
                                    <asp:DropDownList ID="ddlAccounts_Type" CssClass="validate[required] listtxt_transac_item_gen_notn"
                                        Font-Size="12px" Width="55px" TabIndex="21" runat="server" Visible="false">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="CN" Value="CN" ></asp:ListItem>
                                        <asp:ListItem Text="DN" Value="DN" ></asp:ListItem>
                                    </asp:DropDownList>
                                </div>                                
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    <asp:Button ID="btnloadData" TabIndex="22" runat="server" Width="71px" Height="20px"
                                        Text="Load Data" OnClick="btnloadData_Click" />
                                </div>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>


            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>


         <div class="content" id="page-1" style="margin-top:-28px;width:1140px;">
                        
          <div id="innerbox_MidMain_Trans_new" style="height:440px; width:1140px; margin-left:-16px; margin-top:-5px;">
                <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span>General </span></a></li>

                     <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                        id="Page_C" runat="server" ><span>Other </span></a></li>

                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span>Charge details</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        <span> Gen -4 </span></a></li>

                        <span style="color:black;font-size:12px;"> &nbsp; 
                            <asp:Literal ID="lbl_Created_Modified" runat="server"></asp:Literal>
                         </span>
                </ol>
                  <%----------------------------General---------------------------------------------------%>
                    <div   class="content" id="page-6"  >

                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:380px;margin-top: -16px; margin-left:-18px; color:Red;">
                        
                        <div id="tag_transact_src_inner" style="width: 1085px">
                    <div id="tag_Exchange_inner_lft" style="width: 1085px">
                        <div id="tag_transact_lft_in1" style="width: 1085px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Invoice No: &nbsp;&nbsp;&nbsp;
                                    <asp:ImageButton ID="btn_Re_Inv_No" UseSubmitBehavior="false" Visible="false"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');Go_Refresh();return false;"
                                     runat="server" ImageUrl="~/images/icons/Refresh.png" Height="15px" Width="20px"/>

                                </div>
                                
                                <div id="txtcon-m_Exchange" > 
                                  <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="17" onkeyup="autotab(this);" ClientIDMode="Static" onblur="return ChangeCase(this);"
                                   onkeypress="return Char_Inv(event)"  
                                   CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="25" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 152px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                   Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                      <asp:TextBox ID="txtDate" runat="server" Width="82px" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="26"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 266px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                  BE No.
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txtBeno" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="27"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 152px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                    Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                   <asp:TextBox ID="txtBedate" runat="server" Width="80px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                                   TabIndex="28"></asp:TextBox>
                                               <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtBedate"
                                                   Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                                   CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                                   CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                                   Enabled="True">
                                               </asp:MaskedEditExtender>
                                               <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBedate"
                                                   Format="dd/MM/yyyy" Enabled="True">
                                               </asp:CalendarExtender>
                                </div>
                            </div>
                            
                             <div id="txt_container_Transact_Main_l" style="width: 165px;">
                                <div id="tag_label_transact_Src" style="width: 65px">
                                    Job Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 90px">
                                      <asp:TextBox ID="txtJob_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code" Width="82px"
                                    TabIndex="29"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txtJob_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtJob_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                </div>
                            </div>


                        


                        </div>
                        <%---------------------------------------Row 4-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1085px;">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px; font-size: 12px;">
                                    MAWB / MBL No
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txtMblno" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="30"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 152px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                    Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                    <asp:TextBox ID="txt_MAWB_MBL_date" runat="server" Width="82px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                        TabIndex="31"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_MAWB_MBL_date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_MAWB_MBL_date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 266px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                  Flight / Vessel No
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                    <asp:TextBox ID="txtvessel" runat="server" MaxLength="100"  Font-Size="12px"
                                         onkeyup="autotab(this);" Width="130px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="32" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 152px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                    Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                   <asp:TextBox ID="txt_flight_Ara_Date" runat="server" Width="82px" MaxLength="10"
                                        CssClass="txtbox_none_Mid_transac_code" TabIndex="33"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt_flight_Ara_Date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_flight_Ara_Date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 235px">
                                <div id="tag_label_transact_Src" style="width: 65px">
                                   Duty Value
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 170px">
                                        <asp:TextBox ID="txt_Duty_Value" runat="server" CssClass="txtbox_none_Mid_transac_Inv_No"
                                         Width="160px" MaxLength="20" TabIndex="34" onblur="extractNumber(this,3,false);"
                                         onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 4-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1085px;">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px; font-size: 12px;">
                                    HAWB / HBL No
                                </div>
                                <div id="txtcon-m_Exchange">
                                     <asp:TextBox ID="txtHblno" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="35"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 152px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                    Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                   <asp:TextBox ID="txt_HAWB_HBL_date" runat="server" Width="82px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                        TabIndex="36"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_HAWB_HBL_date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_HAWB_HBL_date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 266px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                   Bond No:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                    <asp:TextBox ID="txt_Bond_No" runat="server" MaxLength="100" Width="130px" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="37" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 152px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                    Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                    <asp:TextBox ID="txt_Bond_date" runat="server" Width="82px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="38"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt_Bond_date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                 <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_Bond_date"
                                    Format="dd/MM/yyyy" Enabled="True" >
                                </asp:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 235px">
                                <div id="tag_label_transact_Src" style="width: 65px">
                                   Volume
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 170px">
                                  <asp:TextBox ID="txtvolume" runat="server" MaxLength="17" Font-Size="12px" Width="160px"
                                         onkeyup="autotab(this);" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="39"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 5-----------------------------------------%>
                        <%--------------------------------------Row 5-----------------------------------------%>
                         <div id="tag_transact_lft_in1" style="width: 1085px">
                        <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Container No:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                   <asp:TextBox ID="txtconatiner_no" runat="server" MaxLength="200" Font-Size="12px" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="42" ></asp:TextBox>
                                </div>
                            </div>
                              <div id="txt_container_Transact_Main_l" style="width: 152px">
                                <div id="tag_label_transact_Src" style="width: 50px; font-size:12px;">
                                    Con.Size
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                   <asp:TextBox ID="txt_Con_Size" runat="server" MaxLength="100" Width="80px" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="43" ></asp:TextBox>
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_l" style="width: 266px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                  LCL / FCL
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                    <asp:DropDownList ID="ddl_LCL_FCL" CssClass="listtxt_transac_item_gen_notn" Font-Size="12px"  Width="80px" TabIndex="44" runat="server">
                                      <asp:ListItem Text="" Value=""></asp:ListItem>
                                      <asp:ListItem Text="LCL" Value="L"></asp:ListItem>
                                      <asp:ListItem Text="FCL" Value="F"></asp:ListItem>
                                     <asp:ListItem Text="Br.Bulk" Value="B"></asp:ListItem>
                                      <asp:ListItem Text="Ex-bond" Value="E"></asp:ListItem>
                                     </asp:DropDownList>

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 152px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                    20 Feet
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                   X

                                    <asp:DropDownList ID="ddl_20_feet_Cnt" class="chosen-select-deselect" data-placeholder="0" Font-Size="12px"  Style="width: 65px;" TabIndex="45" runat="server">
                                      <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                      <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                      <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                      <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                      <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                      <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                      <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                      <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                      <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                      <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                      <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                      <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                      <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                      <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                      <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                      <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                      <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                      <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                      <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                      <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                      <asp:ListItem Text="23" Value="23"></asp:ListItem>

                                      <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                      <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                      <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                      <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                      <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                      <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                      <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                      <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                      <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                      <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                      <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                      <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                      <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                      <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                      <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                      <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                      <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                      <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                      <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                      <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                      <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                      <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                      <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                      <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                      <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                      <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                      <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                      <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 235px">
                                <div id="tag_label_transact_Src" style="width: 65px">
                                    &nbsp;&nbsp;40 Feet 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 170px">
                               
                               X

                                 <asp:DropDownList ID="ddl_40_feet_Cnt" class="chosen-select-deselect" data-placeholder="0" Font-Size="12px"  Style="width: 65px;" TabIndex="46" runat="server">
                                      <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                      <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                      <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                      <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                      <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                      <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                      <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                      <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                      <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                      <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                      <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                      <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                      <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                      <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                      <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                      <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                      <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                      <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                      <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                      <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                      <asp:ListItem Text="23" Value="23"></asp:ListItem>

                                      <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                      <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                      <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                      <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                      <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                      <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                      <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                      <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                      <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                      <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                      <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                      <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                      <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                      <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                      <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                      <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                      <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                      <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                      <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                      <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                      <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                      <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                      <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                      <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                      <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                      <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                      <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                      <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 6s-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1085px">
                        
                            <div id="txt_container_Transact_Main_l" style="width: 432px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Job Inv No / Date:
                                </div>
                                  <div id="txtcon-m_Exchange" style="width: 307px;">
                                   <asp:TextBox ID="txtjob_invno" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                               Width="300px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="47"></asp:TextBox>
                                </div>

                            </div>

                                <div id="txt_container_Transact_Main_l" style="width: 650px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                   Item desc.
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 530px;">
                                 <asp:TextBox ID="txt_Item_Desc" runat="server" MaxLength="480" Width="525px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="48"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 6e-----------------------------------------%>

                        <%--------------------------------------Row 4-----------------------------------------%>

                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    No. of Pkgs:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px;">
                                    <asp:TextBox ID="txtno_of_pkg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        Width="90px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="51"></asp:TextBox>
                                </div>
                                <div id="txtcon_m_transaction_IGM_Wght_small">
                                    <asp:TextBox ID="txtPackageType" runat="server" TabIndex="52" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_IGM_wght_small"
                                        ClientIDMode="Static" MaxLength="3" onkeypress="return char1(event)" onblur="ChangeCase(this);"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    Gross Wgt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 90px;">
                                    <asp:TextBox ID="txtgross_wgt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        Width="80px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="53"></asp:TextBox>
                                </div>
                                <div id="txtcon_m_transaction_IGM_Wght_small">
                                    <asp:TextBox ID="txt_Gross_Wgt_Type" runat="server" CssClass="txtbox_none_Mid_transac_IGM_wght_small"
                                        ClientIDMode="Static" MaxLength="3" TabIndex="54" onkeypress="return char1(event)"
                                        onblur="ChangeCase(this);"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 200px;">
                                <div id="tag_label_transact_Src" style="width: 65px;">
                                    Net Wgt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 75px;">
                                    <asp:TextBox ID="txtnetwgt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        Width="65px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="55"></asp:TextBox>
                                </div>
                                <div id="txtcon_m_transaction_IGM_Wght_small">
                                    <asp:TextBox ID="txt_Net_Wgt_Type" runat="server" CssClass="txtbox_none_Mid_transac_IGM_wght_small"
                                        ClientIDMode="Static" MaxLength="3" TabIndex="56" onkeypress="return char1(event)"
                                        onblur="ChangeCase(this);"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 290px">
                                <div id="tag_label_transact_Src">
                                    Charge Wgt:
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txtchargeWeight" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="12" TabIndex="58" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="txtcon_m_transaction_IGM_Wght_small">
                                    <asp:TextBox ID="txtchargeWeightType" runat="server" CssClass="txtbox_none_Mid_transac_IGM_wght_small"
                                        ClientIDMode="Static" MaxLength="3" TabIndex="59" onkeypress="return char1(event)"
                                        onblur="ChangeCase(this);"></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                    <a href="#" tabindex="60" onclick="OpenPopupUnit('Export_Billing_Charge_wgt'); return false"
                                        class="magnfy"></a>
                                </div>
                            </div>
                        </div>

                         <%--------------------------------------Row 6-----------------------------------------%>
                         <%--------------------------------------Row 3-----------------------------------------%>
                         
                        <div id="tag_transact_lft_in1" style="width: 1085px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Destination:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtdestination" runat="server" MaxLength="30" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="63" ></asp:TextBox>
                                </div>
                            </div>
                          
                            <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                  <div id="tag_label_transact_Src" style="width: 80px;">
                                       Party Ref.
                                  </div>
                                  <div id="txtcon-m_Exchange" style="width: 140px;">
                                          <asp:TextBox ID="txt_Party_Ref" runat="server" MaxLength="49" TabIndex="64"  Width="140px" onkeyup="autotab(this);" Font-Size="12px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  ></asp:TextBox>
                                  </div>
                              </div>

                              <div id="txt_container_Transact_Main_l" style="width: 200px;">
                                <div id="tag_label_transact_Src" style="width: 65px;">
                                    Terms
                                </div>
                                 <div id="txtcon-m_Exchange" style="width: 90px">
                                  <asp:DropDownList ID="ddlTerms" runat="server" CssClass="listtxt_transac_FCL" Width="75px" TabIndex="65">
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="FOB" Value="FOB"></asp:ListItem>
                                    <asp:ListItem Text="CIF" Value="CIF"></asp:ListItem>
                                    <asp:ListItem Text="CI" Value="CI"></asp:ListItem>
                                    <asp:ListItem Text="CF" Value="CF"></asp:ListItem>
                                </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                           <%--------------------------------------AddRow 1-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1085px">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Importer Name:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 330px;">
                                   <asp:TextBox ID="txtImportername" runat="server" MaxLength="200" onkeyup="autotab(this);" Width="330px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="68" ></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                             <a href="#"  class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('GST_Bill_Imp_name'); return false">
                                            </a>
                                        </div>
                            </div>
                                 <div id="txt_container_Transact_Main_l" style="width: 120px">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                   A/C Behalf
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 30px;">
                                    <asp:CheckBox ID="ch_Behalf" runat="server" TabIndex="75" />
                                </div>
                            </div>
                          
                            <div id="txt_container_Transact_Main_l" style="width: 290px"> 
                                <div id="tag_label_transact_Src">
                                    Freight Status:
                                </div>
                                  <div id="txtcon-m_transaction_code">
                                        <asp:DropDownList ID="ddl_freight_status" CssClass="listtxt_transac_item_gen_notn"
                                        Width="65px" runat="server" TabIndex="76">
                                        <asp:ListItem Text="CC" Value="CC"></asp:ListItem>
                                        <asp:ListItem Text="PP" Value="PP"></asp:ListItem>
                                    </asp:DropDownList>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                               
                            </div>


                            
                        </div>
                           <%--------------------------------------AddRow 2-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1085px;">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  State Name
                                </div>
                                <div id="txtcon-m_Exchange">

                                    <asp:DropDownList ID="ddl_state_name" CssClass="listtxt_transac_item_gen_notn" Width="160px" TabIndex="70" ForeColor="Green" runat="server" >
                                     <asp:ListItem Text="" Value=""></asp:ListItem>

                                    <asp:ListItem Text="01--JAMMU & KASHMIR" Value="JAMMU & KASHMIR"></asp:ListItem>
                                    <asp:ListItem Text="02--HIMACHAL PRADESH" Value="HIMACHAL PRADESH"></asp:ListItem>
                                    <asp:ListItem Text="03--PUNJAB" Value="PUNJAB"></asp:ListItem>
                                    <asp:ListItem Text="04--CHANDIGARH" Value="CHANDIGARH"></asp:ListItem>
                                    <asp:ListItem Text="05--UTTARAKHAND" Value="UTTARAKHAND"></asp:ListItem>
                                    <asp:ListItem Text="06--HARYANA" Value="HARYANA"></asp:ListItem>
                                    <asp:ListItem Text="07--DELHI" Value="DELHI"></asp:ListItem>
                                    <asp:ListItem Text="08--RAJASTHAN" Value="RAJASTHAN"></asp:ListItem>
                                    <asp:ListItem Text="09--UTTAR PRADESH" Value="UTTAR PRADESH"></asp:ListItem>
                                    <asp:ListItem Text="10--BIHAR" Value="BIHAR"></asp:ListItem>
                                    <asp:ListItem Text="11--SIKKIM" Value="SIKKIM"></asp:ListItem>
                                    <asp:ListItem Text="12--ARUNACHAL PRADESH" Value="ARUNACHAL PRADESH"></asp:ListItem>
                                    <asp:ListItem Text="13--NAGALAND" Value="NAGALAND"></asp:ListItem>
                                    <asp:ListItem Text="14--MANIPUR" Value="MANIPUR"></asp:ListItem>
                                    <asp:ListItem Text="15--MIZORAM" Value="MIZORAM"></asp:ListItem>
                                    <asp:ListItem Text="16--TRIPURA" Value="TRIPURA"></asp:ListItem>
                                    <asp:ListItem Text="17--MEGHALAYA" Value="MEGHALAYA"></asp:ListItem>
                                    <asp:ListItem Text="18--ASSAM" Value="ASSAM"></asp:ListItem>
                                    <asp:ListItem Text="19--WEST BENGAL" Value="WEST BENGAL"></asp:ListItem>
                                    <asp:ListItem Text="20--JHARKHAND" Value="JHARKHAND"></asp:ListItem>
                                    <asp:ListItem Text="21--ORISSA" Value="ORISSA"></asp:ListItem>
                                    <asp:ListItem Text="22--CHATTISGARH" Value="CHATTISGARH"></asp:ListItem>
                                    <asp:ListItem Text="23--MADHYA PRADESH" Value="MADHYA PRADESH"></asp:ListItem>
                                    <asp:ListItem Text="24--GUJARAT" Value="GUJARAT"></asp:ListItem>
                                    <asp:ListItem Text="25--DAMAN & DIU" Value="DAMAN & DIU"></asp:ListItem>
                                    <asp:ListItem Text="26--DADRA & NAGAR HAVELI" Value="DADRA & NAGAR HAVELI"></asp:ListItem>
                                    <asp:ListItem Text="27--MAHARASHTRA" Value="MAHARASHTRA"></asp:ListItem>
                                    <asp:ListItem Text="29--KARNATAKA" Value="KARNATAKA"></asp:ListItem>
                                    <asp:ListItem Text="30--GOA" Value="GOA"></asp:ListItem>
                                    <asp:ListItem Text="31--LAKSHADWEEP" Value="LAKSHADWEEP"></asp:ListItem>
                                    <asp:ListItem Text="32--KERALA" Value="KERALA"></asp:ListItem>
                                    <asp:ListItem Text="33--TAMILNADU" Value="TAMILNADU"></asp:ListItem>
                                    <asp:ListItem Text="33--TAMIL NADU" Value="TAMIL NADU"></asp:ListItem>
                                    <asp:ListItem Text="34--PONDICHERRY" Value="PONDICHERRY"></asp:ListItem>
                                    <asp:ListItem Text="35--ANDAMAN & NICOBAR" Value="ANDAMAN & NICOBAR"></asp:ListItem>
                                    <asp:ListItem Text="36--TELANGANA" Value="TELANGANA"></asp:ListItem>
                                    <asp:ListItem Text="37--ANDHRA PRADESH" Value="ANDHRA PRADESH"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_l" style="width: 220px">
                                <div id="tag_label_transact_Src" style="width: 60px">
                                     GSTN ID
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 147px">
                                      <asp:TextBox ID="txt_GSTN_Id" runat="server" MaxLength="17" Width="140px" onkeyup="autotab(this);" Font-Size="12px" TabIndex="72"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  ></asp:TextBox>
                                </div>
                            </div>

                              <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                   Supplier Name:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 310px;">
                                   <asp:TextBox ID="txtsuppliername" runat="server" MaxLength="200" 
                                        onkeyup="autotab(this);" Width="310px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="77" ></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                               <a class="magnfy" href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('Bill_Supplier_name'); return false">
                                            </a>
                                        </div>
                            </div>

                            </div>

                        <%--------------------------------------AddRow 2end-----------------------------------------%>

                           <div id="tag_transact_lft_in1" style="width: 1085px;height:60px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Address :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 373px;">
                                   <asp:TextBox ID="txtShip_Add1" runat="server" MaxLength="500" 
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  Height="50px" TabIndex="74" ></asp:TextBox>
                                </div>
                            </div>
                            
                               <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                  Address :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 210px;">
                                   <asp:TextBox ID="txtCon_Add1" runat="server" MaxLength="500" 
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="83" Height="50px" ></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                      
                           <%--------------------------------------AddRow 6-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1085px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Notify Party 1:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 380px;">
                                   <asp:TextBox ID="txt_IMP_notify_party_1" runat="server" MaxLength="200" onkeyup="autotab(this);" Width="350px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="84" ></asp:TextBox>
                                </div>
                            </div>
                               <div id="txt_container_Transact_Main_l" style="width: 535px;">
                                       <div id="tag_label_transact_Src" style="width: 120px;">
                                           Commodity
                                       </div>
                                       <div id="txtcon-m_Exchange" style="width: 405px; ">
                                                <asp:TextBox ID="txtcommodity" runat="server" MaxLength="200" onkeyup="autotab(this);" Width="400px"
                                                CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="87" ></asp:TextBox>
                                       </div>
                                   </div>  
                        </div>
                           <%--------------------------------------AddRow 7-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1085px; height:75px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px; height:70px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  Address
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 210px;height:150px;">
                                   <asp:TextBox ID="txt_notify_party_1_add" runat="server" MaxLength="17" 
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="86"  Height="60px" ></asp:TextBox>
                                </div>
                            </div>
                            
                               <div id="txt_container_Transact_Main_l" style="width: 585px; height: 75px;">
                                   <div id="txt_container_Transact_Main_l" style="width: 585px;height: 40px;">
                                       <div id="txt_container_Transact_Main_l" style="width: 245px;">
                                           <div id="tag_label_transact_Src" style="width: 120px;">
                                               Vendor Code
                                           </div>
                                           <div id="txtcon-m_Exchange" style="width: 105px;">
                                               <asp:TextBox ID="txt_Vendor_Code" runat="server" MaxLength="45" onkeyup="autotab(this);"
                                        Width="100px" CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="90"></asp:TextBox>
                                           </div>
                                       </div>
                                       
                                           <div id="txt_container_Transact_Main_l" style="width: 255px;">
                                               <div id="txtcon-m_Exchange" style="width: 250px;">
                                              <%--    <asp:RadioButtonList ID="Rd_Reg_Sez" runat="server" RepeatDirection="Horizontal"
                                                  TabIndex="91" ForeColor="Purple" >
                                                  <asp:ListItem Text="Regular Bill" Value="R" Selected="True"></asp:ListItem>
                                                  <asp:ListItem Text="Sez Bill" Value="S" ></asp:ListItem>
                                              </asp:RadioButtonList>--%>


                                              <%-- <div id="txt_container_Transact_Main_l" style="width: 300px">
                                        <div id="tag_label_transact_Src" style="width: 60px; color:Blue;font-weight:bold;">
                                          Bill Type :
                                        </div>
                                        <div id="txtcon-m_Exchange" style="width: 220px;color:Blue; font-weight:bold;">
                                            <asp:RadioButtonList ID="Rd_Tax_NonTax" runat="server" RepeatDirection="Horizontal" >
                                            <asp:ListItem Text="Tax" Value="T"></asp:ListItem>
                                            <asp:ListItem Text="Non-Tax" Value="N"></asp:ListItem>
                                            <asp:ListItem Text="Both" Value="B" Selected="True"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>--%>

                                   <asp:RadioButtonList ID="Rd_Tax_NonTax" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Text="Tax" Value="T"></asp:ListItem>
                                    <asp:ListItem Text="Non-Tax" Value="N"></asp:ListItem>
                                    <asp:ListItem Text="Both" Value="B" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>


                                               </div>
                                           </div>
                                       
                                   </div>
                                 <%------------------------------%>
                                    <div id="tag_label_transact_Src" style="width: 67px;">
                                  Job Entry
                              </div>
                              <div id="txtcon-m_Exchange" style="width: 180px;">
                                  <asp:RadioButtonList ID="Rd_Job_Status" runat="server" RepeatDirection="Horizontal"
                                      TabIndex="93">
                                      <asp:ListItem Text="Pending" Value="P"></asp:ListItem>
                                      <asp:ListItem Text="Completed" Value="C" Selected="True"></asp:ListItem>
                                  </asp:RadioButtonList>
                              </div>
                              <span id="Bill_Admin" runat="server" visible="false">
                                  <div id="tag_label_transact_Src" style="width: 40px;">
                                      Invoice
                                  </div>
                                  <div id="txtcon-m_Exchange" style="width: 188px;">
                                      <asp:RadioButtonList ID="Rd_Inv_Status" runat="server" TabIndex="94" RepeatDirection="Horizontal"
                                          AutoPostBack="true" OnSelectedIndexChanged="Rd_Inv_Status_SelectedIndexChanged">
                                          <asp:ListItem Text="Unapproval" Value="UA" Selected="True"></asp:ListItem>
                                          <asp:ListItem Text="Approved" Value="A"></asp:ListItem>
                                      </asp:RadioButtonList>
                                  </div>
                              </span>



                               </div>

                            
                        </div>
                         
                           <%--------------------------------------AddRow 11-----------------------------------------%>

                         <%--------------------------------------Row End-----------------------------------------%>
                    </div>
                 
                </div>
                        </div>
                    </div>

                      <%----------------------------Other---------------------------------------------------%>
                     <div   class="content" id="page-8" >
                     <div id="pop_text_area_transac_popup_inn_container_export" style="height:380px; margin-top: 0px; color:Red;">
                     <div id="tag_transac_lft_Inv_in1" style="width:1150px;">
                         <div id="tag_label_transaction_popup_gen">
                            Country of Shipment
                         </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic">
                             <asp:TextBox ID="txtCountryShipment" runat="server" MaxLength="50" onblur="ChangeCase(this);"
                                 CssClass="txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                 TabIndex="96" onkeypress="return char(event)" onkeyup="ChangeCase(this);"></asp:TextBox>
                             <asp:HiddenField ID="txtCountryShipmentCode" runat="server" ClientIDMode="Static" />
                         </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                         </div>
                         <div id="tag_label_transaction_popup_gen">
                             Port of Shipment
                         </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic">
                             <asp:TextBox ID="txtPortShipment" runat="server" MaxLength="50" onkeypress="return char(event)"
                                 onblur="ChangeCase(this);" onkeyup="ChangeCase(this);" onkeydown="ChangeCase(this);var data = val;Port_origin(this);"
                                 CssClass="txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                 TabIndex="98"></asp:TextBox>
                         </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                         </div>
                          <div id="tag_label_transaction_popup_gen">
                             Tr. Details
                         </div>
                          <div id="txtcon-m_transaction_pop_gen1_srcic">
                             <asp:TextBox ID="txt_tr_details" runat="server" MaxLength="50" 
                                 onblur="ChangeCase(this);" onkeyup="ChangeCase(this);" 
                                 CssClass="txtbox_none_Mid_transac_pop_gen_srcic" ClientIDMode="Static"
                                 TabIndex="99"></asp:TextBox>
                         </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                         </div>
                     </div>
                     <%----------------------------Row2---------------------------------------------------%>
                     <div id="tag_transac_lft_Inv_in1" style="width:1150px;">
                         <div id="tag_label_transaction_popup_gen">
                            CFS Charge
                         </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic">
                             <asp:TextBox ID="txt_CFS_Charge" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_pop_gen_srcic" TabIndex="100"></asp:TextBox>
                         </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                         </div>
                         <div id="tag_label_transaction_popup_gen">
                            Attachment det.
                         </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic">
                             <asp:TextBox ID="txt_Attachment" runat="server" MaxLength="999" CssClass="txtbox_none_Mid_transac_pop_gen_srcic" TabIndex="101"></asp:TextBox>
                         </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                         </div>
                          <div id="tag_label_transaction_popup_gen">
                             PO No.
                         </div>
                          <div id="txtcon-m_transaction_pop_gen1_srcic">
                             <asp:TextBox ID="txt_PO_No" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_pop_gen_srcic" TabIndex="102"></asp:TextBox>
                         </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                         </div>
                     </div>
                     <%----------------------------Row3---------------------------------------------------%>
                     <div id="tag_transac_lft_Inv_in1" style="width:1150px;">
                         <div id="tag_label_transaction_popup_gen">
                           Notify Party 2:
                         </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic">
                          <asp:TextBox ID="txt_notify_party_2" runat="server" MaxLength="200" onkeyup="autotab(this);" Width="370px"
                          CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="103" ></asp:TextBox>
                         </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                         </div>
                        
                     </div>

                      <div id="tag_transac_lft_Inv_in1" style="width:1150px; height:70px;">
                         <div id="tag_label_transaction_popup_gen">
                         </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <asp:TextBox ID="txt_notify_party_2_add" runat="server" MaxLength="17" 
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  Height="60px" TabIndex="104" ></asp:TextBox>
                         </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                         </div>
                        
                     </div>
                     <div id="tag_transac_lft_Inv_in1" style="width:1150px;">
                         <div id="tag_label_transaction_popup_gen">
                          Remarks:
                         </div>
                         <div id="txtcon-m_transaction_pop_gen1_srcic">
                             <asp:TextBox ID="txt_Remarks" runat="server" MaxLength="750" onkeyup="autotab(this);"
                                         Width="370px" TextMode="MultiLine" CssClass="txtbox_none_Mid_transac_Inv_No"
                                         TabIndex="89" Height="42px"></asp:TextBox>
                         </div>
                         <div id="tag_label_transaction_popup_IGM2_empty">
                         </div>
                     </div>

                     </div>
                     </div>
                      <%----------------------------Charge Details---------------------------------------------------%>

                    <div  class="content"  id="page-7"  style="display:none;height:440px; width:1140px;" >
                           <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 30px;
                                width: 1140px; margin-top: -10px;margin-left:-18px;">
                                <asp:GridView ID="GV1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                    CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" Style="overflow: auto;">
                                    <Columns>
                                        <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="" HeaderStyle-Width="0px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="0px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="a" HeaderText="" HeaderStyle-Width="80px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="c" HeaderText="" HeaderStyle-Width="375px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="375px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="a" HeaderText="" HeaderStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                          <asp:BoundField DataField="a" HeaderText="" HeaderStyle-Width="35px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="35px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="" HeaderStyle-Width="55px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="55px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="" HeaderStyle-Width="0px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="0px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="" HeaderStyle-Width="135px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="135px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="e" HeaderText="" HeaderStyle-Width="20px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="20px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="f" HeaderText="" HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="CGST" HeaderStyle-Width="40px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="40px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="CGST" HeaderStyle-Width="50px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="SGST" HeaderStyle-Width="40px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="40px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="SGST" HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="IGST" HeaderStyle-Width="40px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="40px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="IGST" HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderStyle-Width="52px" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="52px" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                           <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 30px;
                                width: 1140px; margin-top: -10px;margin-left:-18px;">
                                <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                    CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" Style="overflow: auto;">
                                    <Columns>
                                        <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="S. No" HeaderStyle-Width="122px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="62px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="a" HeaderText="Charge Name" HeaderStyle-Width="330px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                        </asp:BoundField>

                                        <asp:BoundField  HeaderText="Description" HeaderStyle-Width="310px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="c" HeaderText="Type" HeaderStyle-Width="70px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="70px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="a" HeaderText="HSN Code" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="100px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="a" HeaderText="SA Code" HeaderStyle-Width="112px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="112px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="Qty" HeaderStyle-Width="5px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="5px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="Cur" HeaderStyle-Width="120px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="Ex-Rate" HeaderStyle-Width="70px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="70px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="e" HeaderText="Unit Rate" HeaderStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="f" HeaderText="Amt" HeaderStyle-Width="130px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="130px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="%" HeaderStyle-Width="60px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Amt" HeaderStyle-Width="110px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="110px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText=" % " HeaderStyle-Width="40px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="40px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Amt" HeaderStyle-Width="120px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText=" % " HeaderStyle-Width="50px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Amt" HeaderStyle-Width="105px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="105px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderStyle-Width="65px" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <style type="text/css">
                                      input.underlined
                                        {
                                           border:solid 1px #000;
                                        }
                                        </style>

                            <div id="tag_transac_lft_Item_maindet_Grid_area"    style="overflow:auto; height:305px; width:1140px;margin-top:-10px;margin-left:-18px; ">
                             <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" 
                                    BorderStyle="none" ShowFooter="True" 
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" onrowdeleting="gv_Chg_Details_RowDeleting" ShowHeader = "false" 
                                    style=" overflow-x: hidden;overflow-y: auto;" > 
                                    
                                    <RowStyle BorderWidth="0.1em" BorderColor="black" Height="8px" /> 
                               <Columns>

                                   <asp:TemplateField HeaderText="ch_inv" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                       <ItemTemplate>
                                           
                                        <asp:CheckBox ID="chk_inv" runat="server" HeaderText="ch_inv"   Width="20px" 
                                         Checked='<%#bool.Parse(Eval("INV_CHECK").ToString())%>' />
                                                  
                                       </ItemTemplate>
                                         <ItemStyle Width="20px" />
                                   </asp:TemplateField>

                                   <asp:BoundField DataField="RowNumber" HeaderText="S.No" HeaderStyle-Font-Bold="true" ItemStyle-Width="20px" HeaderStyle-Width="20px" />
                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtOrder_by"    CssClass="underlined" Text='<%# Bind("ORDERBY") %>' Height="20px" Width="20px" onkeypress="return pin(event)" runat="server" style="text-align:center" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="20px" HorizontalAlign="Left" />
                                    </asp:TemplateField>


                                   <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="325px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtch_name"  CssClass="underlined"   Text='<%# Bind("CHARGE_NAME") %>' runat="server" onblur="Calculation(this)"                                       
                                            Height="20px" Width="152px" Font-Size="12px"  ></asp:TextBox>
                                            <asp:HiddenField ID="hfCustomerId" runat="server" />
                                            
                                           
                                          <asp:TextBox ID="txt_charge_desc"  CssClass="underlined"  Text='<%# Bind("CHARGE_DESC") %>' runat="server" onblur="Calculation(this)"                                       
                                            Height="20px" Width="152px" Font-Size="12px"  ></asp:TextBox>

                                       </ItemTemplate>
                                         <ItemStyle Width="325px" />
                                   </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="40px">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddl_tax_nontax" Text='<%# Bind("TAX_NONTAX") %>' MaxLength="20" runat="server"
                                               Width="35px" Height="22px" Font-Size="12px"  CssClass="txtbox_trans_exp_drawback">
                                               <asp:ListItem>N</asp:ListItem>
                                               <asp:ListItem>T</asp:ListItem>
                                               <asp:ListItem>P</asp:ListItem>
                                                <asp:ListItem>E</asp:ListItem>
                                                <asp:ListItem>R</asp:ListItem>
                                           </asp:DropDownList>
                                       </ItemTemplate>
                                       <ItemStyle Width="40px" />
                                   </asp:TemplateField>

                                   <asp:TemplateField HeaderText="HSN_Code" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_HSN_Code" CssClass="underlined"  Text='<%# Bind("HSN_CODE") %>' runat="server"                                        
                                            Height="20px" Width="55px"  Font-Size="12px"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="55px" />
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SA_Code" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_SA_Code" CssClass="underlined"  Text='<%# Bind("SA_CODE") %>' runat="server"                                       
                                            Height="20px" Width="55px"  Font-Size="12px"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="55px" />
                                   </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Qty" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtqty"  CssClass="underlined"  Text='<%# Bind("Qty") %>' Height="20px" Width="28px" Font-Size="12px" 
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            runat="server" style="text-align:center" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="30px" />
                                      </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cur" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddl_CUR"  Text='<%# Bind("CUR") %>' MaxLength="20" runat="server"
                                               Width="49px" Height="22px" Font-Size="12px"  CssClass=" txtbox_trans_exp_drawback">
                                               <asp:ListItem>INR</asp:ListItem>
                                               <asp:ListItem>USD</asp:ListItem>
                                               <asp:ListItem>EUR</asp:ListItem>
                                               <asp:ListItem>GBP</asp:ListItem>

                                           </asp:DropDownList>
                                       </ItemTemplate>
                                         <ItemStyle Width="50px" />
                                   </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Ex_Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_Ex_Rate" CssClass="underlined" Text='<%# Bind("EX_RATE") %>' runat="server"                                        
                                            Height="20px" Width="30px" Font-Size="12px"  style="text-align:center"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="30px" />
                                   </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Unit Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="65px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtunit_price"  CssClass="underlined"   Text='<%# Bind("UNIT_RATE") %>'
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="65px" Font-Size="12px"  runat="server" style="text-align:right"></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="65px" />
                                     </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="75px">
                                       <ItemTemplate > 
                                           <asp:TextBox ID="txtamt"  CssClass="underlined" Text='<%# Bind("AMOUNT") %>'  BackColor="WhiteSmoke"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="75px" Font-Size="12px"  runat="server"  style="text-align:right" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="75px" />
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="C-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtCGST_RATE" CssClass="underlined" Text='<%# Bind("CGST_RATE") %>'   BackColor="#F9B7FF"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="20px" Font-Size="12px"  runat="server" style="text-align:center"></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="20px" />
                                     </asp:TemplateField>

                                      <asp:TemplateField HeaderText="C-Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="55px">
                                       <ItemTemplate > 
                                           <asp:TextBox ID="txtCGST_AMT" CssClass="underlined" Text='<%# Bind("CGST_AMT") %>'   BackColor="WhiteSmoke"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="55px"  Font-Size="12px"  runat="server"  style="text-align:right" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="55px" />
                                     </asp:TemplateField>

                                      <asp:TemplateField HeaderText="S-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtSGST_RATE"  CssClass="underlined"   Text='<%# Bind("SGST_RATE") %>'  BackColor="#F9B7FF"  
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="20px" Font-Size="12px"  runat="server" style="text-align:center"></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="20px" />
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="S-Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="55px">
                                       <ItemTemplate > 
                                           <asp:TextBox ID="txtSGST_AMT" CssClass="underlined"  Text='<%# Bind("SGST_AMT") %>'   BackColor="WhiteSmoke"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="55px" Font-Size="12px"  runat="server" style="text-align:right" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="55px" />
                                     </asp:TemplateField>
                                           <asp:TemplateField HeaderText="I-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtIGST_RATE" CssClass="underlined"    Text='<%# Bind("IGST_RATE") %>' BackColor="#FFCBA4"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="20px" Font-Size="12px"  runat="server" style="text-align:center"></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="20px" />
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="I-Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="69px">
                                       <ItemTemplate > 
                                           <asp:TextBox ID="txtIGST_AMT" CssClass="underlined" Text='<%# Bind("IGST_AMT") %>'     BackColor="WhiteSmoke"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="69px" Font-Size="12px"  runat="server"  style="text-align:right" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="69px" />

                                      <FooterStyle HorizontalAlign="left"  />
                                       <FooterTemplate>
                                           <asp:Button ID="ButtonAdd" runat="server" Text="Add Row" OnClick="ButtonAdd_Click" />
                                       </FooterTemplate>
                                     </asp:TemplateField>

                                   <asp:CommandField ShowDeleteButton="True" ControlStyle-Font-Bold="true"  DeleteText="Del  "  ControlStyle-Font-Size="Small"   />

                               </Columns>
                           </asp:GridView>
                             <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White" BorderStyle="None"
                                ForeColor="White" ></asp:TextBox>
                                 
                                  <p id="pTotal" style="color:Red; font-size:large;">
                            </div>

                       <div id="tag_transact_src_inner" style="width: 1085px; height:100px; margin-left:-10px;">
                        <%---------------------%>
                       <div id="tag_transact_lft_in1" style="width: 1085px">
                            <div id="txt_container_Transact_Main_l" style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    NonTaxable Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                   <asp:TextBox ID="txtnon_tax_amt" runat="server" MaxLength="17" onkeyup="autotab(this);"   BackColor="#F5F5F5" Width="120px" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="100" ></asp:TextBox>
                                </div>
                            </div>
                           <div id="txt_container_Transact_Main_l"   style="width: 255px;">
                                <div id="tag_label_transact_Src" style="width: 135px">
                                  Taxable Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px">
                                    <asp:TextBox ID="txttax_amt" runat="server" MaxLength="17" onkeyup="autotab(this);" BackColor="#F5F5F5" Width="100px" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="101" ></asp:TextBox>
                                </div>
                            </div>
                              <div id="txt_container_Transact_Main_l" style="width: 270px">
                                <div id="tag_label_transact_Src" style="width: 145px">
                                 Total Reverse Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                    <asp:TextBox ID="txt_tot_Rev_Amt" Width="100px"  runat="server" MaxLength="17" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="102"   onblur="extractNumber(this,2,false);"
                                     onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);" ></asp:TextBox>
                                     
                                </div>
                            </div>
                            <%-- <div id="txt_container_Transact_Main_l" style="width: 300px">
                                <div id="tag_label_transact_Src" style="width: 60px; color:Blue;font-weight:bold;">
                                  Bill Type :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 220px;color:Blue; font-weight:bold;">
                                    <asp:RadioButtonList ID="Rd_Tax_NonTax" runat="server" RepeatDirection="Horizontal" >
                                    <asp:ListItem Text="Tax" Value="T"></asp:ListItem>
                                    <asp:ListItem Text="Non-Tax" Value="N"></asp:ListItem>
                                    <asp:ListItem Text="Both" Value="B" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>--%>
                        
                        </div>

                       <div id="tag_transact_lft_in1" style="width: 1085px">
                            <div id="txt_container_Transact_Main_l"  style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 110px; font-weight:bold;">
                                    Total Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange"  style="width: 120px">
                                   <asp:TextBox ID="txt_total_tax_amt" runat="server" MaxLength="17"  Font-Bold="true" Width="120px" 
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="105" ></asp:TextBox>
                                </div>
                            </div>
                           <div id="txt_container_Transact_Main_l"  style="width: 255px;">
                                <div id="tag_label_transact_Src" style="width: 135px;  font-weight:bold;" >
                                  Total Amt with Tax:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 105px">
                                    <asp:TextBox ID="txt_total_amt_With_tax" runat="server" Font-Bold="true" MaxLength="17" Width="100px" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="108" ></asp:TextBox>
                                </div>
                            </div>
                        
                         <%-------------------------------------------------------------------------------%>
                           <div id="txt_container_Transact_Main_l" style="width: 220px;">
                               <div id="tag_label_transact_Src" style="width: 90px; font-weight: bold; color: Green;">
                                   Grand Total
                               </div>
                               <div id="txtcon-m_Exchange" style="width: 120px">
                                   <asp:TextBox ID="txt_grand_total" runat="server" Font-Bold="true" MaxLength="17"
                                       Width="110px" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);"
                                       onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="txtbox_none_Mid_transac_Inv_No"
                                       TabIndex="108"></asp:TextBox>
                               </div>
                           </div>

                              <div id="txt_container_Transact_Main_l" style="width: 170px">
                                <div id="tag_label_transact_Src" style="width: 90px">
                                  Advance Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 70px">
                                    <asp:TextBox ID="txt_Adv_amt" runat="server" MaxLength="17" Width="70px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="103"   onblur="extractNumber(this,2,false);"
                                     onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                      BackColor="#FFFFC2"  ></asp:TextBox>
                                </div>
                            </div>


                           <div id="txt_container_Transact_Main_l" style="width: 190px;">
                               <div id="tag_label_transact_Src" style="width: 70px;">
                                   Exp.Amt
                               </div>
                               <div id="txtcon-m_Exchange" style="width: 120px">
                                   <asp:TextBox ID="txt_Expense_Amt" runat="server" Font-Bold="true" MaxLength="17"
                                       Width="80px" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);"
                                       onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="txtbox_none_Mid_transac_Inv_No"
                                       TabIndex="108"></asp:TextBox>
                                        <a id="Link_Container" runat="server" href="javascript:open_Imp_Expense_Amt_New('I')">
                                   <span style="font-size: 12px; font-weight: bold;">View</span> </a>
                               </div>

                           </div>

                        </div>
                       <%-------------------------------------------------------------------------------%>
                        <%-------------------------------------------------------------------------------%>

                       </div>

                    </div>
                    
                  <%-------------------------------------------------------------------------------%>


                </div>
                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px;">
                    <div id="innerbox_transac_bot_inn" style="width:1050px">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="122" onclick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="120" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="121" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="121" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Invoice?', 'INVOICE', function(r) {
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
                                id="btnCancel" tabindex="123">
                        </div>
                       <div id="editbu" style="width:10px;"></div>
                        <div id="editbu" style="padding-top:5px;">
                            <asp:Button ID="btnrpt" runat="server" tabindex="125" Text="Get Bill" OnClientClick="return GST_Import_Billing_Job_Rpt_Credit_Note('B');"  /> <%--OnClientClick="return Import_Billing_Job_Rpt('B');"--%> 
                        </div>
                        <div id="editbu" style="padding-top:10px;">
                          <span style="color:Green;"> &nbsp; <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                          </span>
                        </div>
                    </div>
                </div>
                   <%-- --------------------Test End----------------------------%>

                 
                 </div>
                <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                         page-2
                    </div>
                </div>
                <div class="content" id="page-3">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 350px;
                        width: 980px; overflow: hidden;">
                         page-3
                    </div>
                </div>
                <div class="content" id="page-4">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                       page-4
                    </div>
                </div>
          
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>

              <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />
             <asp:HiddenField ID="HDupdate_id" runat="server" />

             <asp:HiddenField ID="HD_Showcon" runat="server" />
             <asp:HiddenField ID="HD_Bill_Jobno" runat="server" />

             <asp:HiddenField ID="Hdjobno" runat="server" />
             <asp:HiddenField ID="HDinv_date" runat="server" />
             <asp:HiddenField ID="hdimp" runat="server" />
             <asp:HiddenField ID="hd_Brslno" runat="server" />

             <asp:HiddenField ID="hd_hss_imp" runat="server" />
             <asp:HiddenField ID="hd_hss_br_sl_no" runat="server" />
             <asp:HiddenField ID="hd_ch_type" runat="server" />
             <asp:HiddenField ID="Hd_row_id" runat="server" />

              <asp:HiddenField ID="Hd_Tr_mode" runat="server" />
              <asp:HiddenField ID="Hd_Other_Branch_no" runat="server" />
              <asp:HiddenField ID="HdtxtInvoiceNo_id" runat="server" />

              <asp:HiddenField ID="Hd_Company_Id" runat="server" />

              </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  
  
  <script type="text/javascript">
      function Go_Refresh() {
          PageMethods.Inv_Refresh('Inv', OnSuccess);
      }
      function OnSuccess(response, userContext, methodName) {

          $('#txtInvoiceNo').val(response);
      }
    </script>

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
        function close_button() {
            document.getElementById("General").click();
        }

    </script>
   

   <script type="text/javascript">
       function Calculation(lnk) {

           var grid = document.getElementById("<%= gv_Chg_Details.ClientID%>");
           var txtAmountReceive = $("[id*=txtch_name]")
           var txtAmountReceive_2 = $("[id*=ddl_tax_nontax]")
           var row = lnk.parentNode.parentNode;
           var rowIndex = row.rowIndex;

           var a = txtAmountReceive[rowIndex].value;
           var b = '1';

           $('#Hd_row_id').val(rowIndex);

           Cha_Type(a, b);
           Tax_Cal();
       }  
          </script>
    <script type="text/javascript">

        function Cha_Type(src, dest) {
            PageMethods.Get_Cha_Type(src, '', '', CallSuccess_Cha_Type, CallFailed, dest);
        }
        function CallSuccess_Cha_Type(res, destCtrl) {

            var data = res;

            if (res != '') {

                var chargetype = $("[id*=ddl_tax_nontax]")
                var txt_HSN_Code = $("[id*=txt_HSN_Code]")
                var txt_SA_Code = $("[id*=txt_SA_Code]") //****New Implementation by Elaiyaa on 26Jun2019*********//

                var selected = $('input:radio[name=Rd_Bill_Type]:checked').val();

                var txtCGST_RATE_OP = $("[id*=txtCGST_RATE]")
                var txtCGST_AMT_OP = $("[id*=txtCGST_AMT]")

                var txtSGST_RATE_OP = $("[id*=txtSGST_RATE]")
                var txtSGST_AMT_OP = $("[id*=txtSGST_AMT]")

                var txtIGST_RATE_OP = $("[id*=txtIGST_RATE]")
                var txtIGST_AMT_OP = $("[id*=txtIGST_AMT]")

                var Hd_Company_Id = document.getElementById("Hd_Company_Id").value;

                if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

                    var s = data.split('~~');
                    var before = s[0];
                    var after1 = s[1];
                    var after2 = s[2]; //****New Implementation by Elaiyaa on 26Jun2019*********//
                    var tempCGST_RATE = s[3];     //line 6.1
                    var tempSGST_RATE = s[4];     //line 6.2
                    var tempIGST_RATE = s[5];     //line 6.3

                    if (selected == 'L') {

                        if (before == 'N') {

                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 0;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                        }
                        else if (before == 'T') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;

                            /*
                            if (Hd_Company_Id != '406' && Hd_Company_Id != '287' && Hd_Company_Id != '464') {
                                txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                                txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                            }*/

                            if(txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0')
                            {
                                //txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';                                                              
                                
                                if (tempCGST_RATE.toString() == '' || tempCGST_RATE.toString() == ' ') {
                                    txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                                }
                                else {
                                    txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = tempCGST_RATE.toString();
                                }
                            }
                            if(txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0')
                            {
                                //txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';

                                if (tempSGST_RATE.toString() == '' || tempSGST_RATE.toString() == ' ') {
                                    txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                                }
                                else {
                                    txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = tempSGST_RATE.toString();
                                }
                            }



                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';
                        }
                        else if (before == 'P') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 2;
                        }
                        else if (before == 'E') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 3;
                        }
                    }
                    else {
                           
                        if (before == 'N') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 0;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';
                        }
                        else if (before == 'T') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            /*
                            if (Hd_Company_Id != '406' && Hd_Company_Id != '287'  && Hd_Company_Id != '464') {
                                txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '18';
                            }
                            */
                            if (txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0')
                            {
                               // txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '18';

                                if (tempIGST_RATE.toString() == '' || tempIGST_RATE.toString() == ' ') {
                                    txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '18';
                                }
                                else {
                                    txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = tempIGST_RATE.toString();
                                }
                            }
                        }
                        else if (before == 'P') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 2;
                        }
                        else if (before == 'E') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 3;
                        }
                    }
                    if (after1 != '') {

                        txt_HSN_Code[document.getElementById("Hd_row_id").value].value = after1;
                    }
                    else {
                        txt_HSN_Code[document.getElementById("Hd_row_id").value].value = '';
                    }
                    txt_SA_Code[document.getElementById("Hd_row_id").value].value = after2.toString(); //****New Implementation by Elaiyaa on 26Jun2019*********//
                }
                else {
                    if (selected == 'L') {
                        if (res == 'N') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 0;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';
                        }
                        else if (res == 'T') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;
                            /*
                            if (Hd_Company_Id != '406' && Hd_Company_Id != '287'  && Hd_Company_Id != '464') {
                                txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                                txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                            }
                            */

                            if (txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0') {
                                txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                            }

                            if (txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0') {
                                txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                            }

                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';
                        }
                        else if (res == 'P') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 2;
                        }
                        else if (res == 'E') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 3;
                        }
                    }
                    else {
                        if (res == 'N') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 0;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';
                        }
                        else if (res == 'T') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';


                            /*
                            if (Hd_Company_Id != '406' && Hd_Company_Id != '287'  && Hd_Company_Id != '464') {
                                txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '18';
                            }
                            */
                            if (txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0') {
                                txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '18';
                            }

                        }
                        else if (res == 'P') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 2;
                        }
                        else if (res == 'E') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 3;
                        }
                    }
                }
            }
            else {
                chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;
            }
        }

        function CallFailed(res, destCtrl) {
        }
    </script>

  <script type="text/javascript">
      $(document).ready(function () {

          $('#txtImportername').focus(function () {

              var data = $(this).val();
              Item_desc(data);
          });
          $('#txtImportername').change(function () {

              var data = $(this).val();
              Item_desc(data);
          });
          $('#txtImportername').keyup(function () {

              var data = $(this).val();
              Item_desc(data);
          });
          $('#txtImportername').keydown(function () {

              var data = $(this).val();
              Item_desc(data);

          });
      });

           function Item_desc(val) {

               var data = val;
               if (data == '') {
                   $('#txtImportername').val('');
               }
               if (data.indexOf("--") != -1) {

                   var s = data.split('--');

                   var before = s[0];
                   var after = s[1];

                   $('#txtImportername').val(after);

                   $('#hdimp').val(after);
                   $('#hd_Brslno').val(before);

               }
               else {

               }
           }
  </script>

  <script type="text/javascript">
      $(document).ready(function () {
          $('#txtimportername_Other').focus(function () {

              var data = $(this).val();
              Item_desc_other(data);

          });
          $('#txtimportername_Other').change(function () {

              var data = $(this).val();
              Item_desc_other(data);

          });
          $('#txtimportername_Other').keyup(function () {

              var data = $(this).val();
              Item_desc_other(data);

          });
          $('#txtimportername_Other').keydown(function () {

              var data = $(this).val();
              Item_desc_other(data);
          });
      });

      function Item_desc_other(val) {

          var data = val;
          if (data == '') {
              $('#txtimportername_Other').val('');
              $('#txt_branch_No').val('');
          }
          if (data.indexOf("--") != -1) {

              var s = data.split('--');

              var before = s[0];
              var after = s[1];

              $('#txtimportername_Other').val(after);
              $('#Hd_Other_Branch_no').val(before);
              $('#txt_branch_No').val(before);
          }
          else {
          }
      }
  </script>


  <script type="text/javascript">
      $(document).ready(function () {
          $('#txt_IMP_notify_party_1').focus(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txt_IMP_notify_party_1').change(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txt_IMP_notify_party_1').keyup(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txt_IMP_notify_party_1').keydown(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
      });

      function Item_desc1(val) {

          var data1 = val;
          if (data1 == '') {
              $('#txt_IMP_notify_party_1').val('');
          }
          if (data1.indexOf("--") != -1) {

              var s = data1.split('--');

              var before = s[0];
              var after = s[1];

              $('#txt_IMP_notify_party_1').val(after);

              $('#hd_hss_imp').val(after);
              $('#hd_hss_br_sl_no').val(before);

          }
          else {

          }
      }
  </script>
  <script type="text/javascript">
      $(document).ready(function () {
          Tax_Cal();
       });
</script>
  
  <script type="text/javascript">
      $(document).ready(function () {
          $('[id*=ddl_tax_nontax]').focus(function () {

              Tax_Cal();
          });
          $('[id*=ddl_tax_nontax]').change(function () {
              Tax_Cal();
          });
          $('[id*=ddl_tax_nontax]').keyup(function () {

              Tax_Cal();
          });
          $('[id*=ddl_tax_nontax]').keydown(function () {

              Tax_Cal();

          });
          //----------------------GST--s------------------------------------------
          $('[id*=ddl_CUR]').focus(function () {

              Tax_Cal();

          });
          $('[id*=ddl_CUR]').change(function () {
              Tax_Cal();
          });
          $('[id*=ddl_CUR]').keyup(function () {

              Tax_Cal();
          });
          $('[id*=ddl_CUR]').keydown(function () {

              Tax_Cal();

          });
          //--------------------------------------------------
          $('[id*=txt_Ex_Rate]').focus(function () {

              Tax_Cal();

          });
          $('[id*=txt_Ex_Rate]').change(function () {
              Tax_Cal();
          });
          $('[id*=txt_Ex_Rate]').keyup(function () {

              Tax_Cal();
          });
          $('[id*=txt_Ex_Rate]').keydown(function () {

              Tax_Cal();

          });

          //----------------------GST--e------------------------------------------

          //-----------------------------------------------------------
          $('[id*=chk_inv]').focus(function () {

              Tax_Cal();

          });
          $('[id*=chk_inv]').change(function () {

              Tax_Cal();
          });
          $('[id*=chk_inv]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=chk_inv]').keydown(function () {

              Tax_Cal();

          });

          //------------------------------------------------------------

          $('[id*=txtamt]').focus(function () {

              Tax_Cal();
          });
          $('[id*=txtamt]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtamt]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtamt]').keydown(function () {

              Tax_Cal();

          });
          //------------------------------------------------------------

          $('[id*=txtch_name]').focus(function () {

              Tax_Cal();

          });
          $('[id*=txtch_name]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtch_name]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtch_name]').keydown(function () {

              Tax_Cal();

          });

          //-----------------------------------------------------------------------------

          $('[id*=txtqty]').focus(function () {

              Tax_Cal();

          });
          $('[id*=txtqty]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtqty]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtqty]').keydown(function () {

              Tax_Cal();
          });
          //------------------------------------------------------------------------

          $('[id*=txtunit_price]').focus(function () {

              Tax_Cal();

          });
          $('[id*=txtunit_price]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtunit_price]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtunit_price]').keydown(function () {

              Tax_Cal();

          });

          //--------------------CGST---------------------------------------
          $('[id*=txtCGST_RATE]').focus(function () {

              if (selected.val() == 'L') {
                  Tax_Cal();
              }

          });
          $('[id*=txtCGST_RATE]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtCGST_RATE]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtCGST_RATE]').keydown(function () {

              Tax_Cal();

          });

          //-----------------2--------------------------------------------------
          $('[id*=txtSGST_RATE]').focus(function () {

              if (selected.val() == 'L') {
                  Tax_Cal();
              }

          });
          $('[id*=txtSGST_RATE]').change(function () {
              Tax_Cal();
          });
          $('[id*=txtSGST_RATE]').keyup(function () {
              Tax_Cal();
          });
          $('[id*=txtSGST_RATE]').keydown(function () {
              Tax_Cal();
          });

          //------------------------I-----------------------------------
          $('[id*=txtIGST_RATE]').focus(function () {

              if (selected.val() == 'L') {
                  Tax_Cal();
              }

          });
          $('[id*=txtIGST_RATE]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtIGST_RATE]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtIGST_RATE]').keydown(function () {

              Tax_Cal();

          });

          //-------------------2--------------------------
          $('[id*=txtIGST_AMT]').focus(function () {

              if (selected.val() == 'L') {
                  Tax_Cal();
              }

          });
          $('[id*=txtIGST_AMT]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtIGST_AMT]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtIGST_AMT]').keydown(function () {

              Tax_Cal();

          });
          //-----------------------------------------------------------
      });

       </script>
  <script type="text/javascript">

      function Tax_Cal() {

          var GST_State = $("#Rd_Bill_Type input[type='radio']:checked");

          var txtamt = $("[id*=txtamt]")
          var tax_type = $("[id*=ddl_tax_nontax]")

          var txtqty = $("[id*=txtqty]")
          var txtunit_price = $("[id*=txtunit_price]")

          var CGST_Rate = $("[id*=txtCGST_RATE]")
          var SGST_Rate = $("[id*=txtSGST_RATE]")

          var CGST_AMT = $("[id*=txtCGST_AMT]")
          var SGST_AMT = $("[id*=txtSGST_AMT]")

          var IGST_RATE = $("[id*=txtIGST_RATE]")
          var IGST_AMT = $("[id*=txtIGST_AMT]")

          var ddl_CUR = $("[id*=ddl_CUR]")
          var txt_Ex_Rate = $("[id*=txt_Ex_Rate]")

          var sum_T = 0;
          var sum_N = 0;
          var sum_R = 0;

          var Tot_L_O = 0;
          var counter = 0;

            var Hd_Com_Id= document.getElementById("Hd_Company_Id").value;

            $("#<%=gv_Chg_Details.ClientID%> input[id*='chk_inv']:checkbox").each(function (index) {
                if ($(this).is(':checked')) {
                    //-----------------------------------------------------------------------------------------
                    // if (Hd_Com_Id != '406' && Hd_Com_Id != '287' && Hd_Com_Id != '464') {

                    if (GST_State.val() == 'L') {
                        if (tax_type[index].value == 'T') {

                            if (CGST_Rate[index].value == '' || CGST_Rate[index].value == '0') {
                                CGST_Rate[index].value = '9'
                            }
                            if (SGST_Rate[index].value == '' || SGST_Rate[index].value == '0') {

                                SGST_Rate[index].value = '9'
                            }
                            IGST_RATE[index].value = '0'
                        }
                        else if (tax_type[index].value == 'N') {
                            CGST_Rate[index].value = '0'
                            SGST_Rate[index].value = '0'
                            IGST_RATE[index].value = '0'
                        }
                    }
                    else {

                        if (tax_type[index].value == 'T') {

                            CGST_Rate[index].value = '0'
                            SGST_Rate[index].value = '0'
                            if (IGST_RATE[index].value == '' || IGST_RATE[index].value == '0') {
                                IGST_RATE[index].value = '18'
                            }
                        }
                        else if (tax_type[index].value == 'N') {

                            CGST_Rate[index].value = '0'
                            SGST_Rate[index].value = '0'
                            IGST_RATE[index].value = '0'
                        }
                    }

                    //}
                    //-----------------------------------------------------------------------------------------


                    if (!isNaN(txtamt[index].value) && txtamt[index].value.length != 0) {

                        if (tax_type[index].value == 'T') {

                            if (ddl_CUR[index].value != 'INR') {
                                txtamt[index].value = txtqty[index].value * txtunit_price[index].value * txt_Ex_Rate[index].value;
                            }
                            else {
                                txt_Ex_Rate[index].value = "1"
                                txtamt[index].value = txtqty[index].value * txtunit_price[index].value;
                            }

                            if (GST_State.val() == 'L') {


                                CGST_AMT[index].value = (parseFloat(txtamt[index].value) * CGST_Rate[index].value / 100.00).toFixed(2);
                                SGST_AMT[index].value = (parseFloat(txtamt[index].value) * SGST_Rate[index].value / 100.00).toFixed(2);

                                var aa = '0';
                                aa = parseFloat(CGST_AMT[index].value) + parseFloat(SGST_AMT[index].value);

                                IGST_AMT[index].value = '0';
                                IGST_RATE[index].value = '0';

                                Tot_L_O += parseFloat(aa)

                            }
                            else {

                                CGST_AMT[index].value = '0';
                                SGST_AMT[index].value = '0';
                                CGST_Rate[index].value = '0';
                                SGST_Rate[index].value = '0';

                                IGST_AMT[index].value = (parseFloat(txtamt[index].value) * IGST_RATE[index].value / 100.00).toFixed(2)
                                Tot_L_O += parseFloat(IGST_AMT[index].value);
                            }
                            sum_T += parseFloat(txtamt[index].value)
                        }
                        else if (tax_type[index].value == 'N' || tax_type[index].value == 'E') {

                            if (ddl_CUR[index].value != 'INR') {
                                txtamt[index].value = (txtqty[index].value * txtunit_price[index].value * txt_Ex_Rate[index].value).toFixed(2);
                            }
                            else {
                                txt_Ex_Rate[index].value = "1"
                                txtamt[index].value = (txtqty[index].value * txtunit_price[index].value).toFixed(2);
                            }

                            sum_N += parseFloat(txtamt[index].value)

                            CGST_AMT[index].value = '0';
                            SGST_AMT[index].value = '0';
                            CGST_Rate[index].value = '0';
                            SGST_Rate[index].value = '0';
                            IGST_AMT[index].value = '0';
                            IGST_RATE[index].value = '0';

                        }
                        else if (tax_type[index].value == 'P') {

                            if (ddl_CUR[index].value != 'INR') {
                                txtamt[index].value = (txtqty[index].value * txtunit_price[index].value * txt_Ex_Rate[index].value).toFixed(2);
                            }
                            else {
                                txt_Ex_Rate[index].value = "1"
                                txtamt[index].value = txtqty[index].value * txtunit_price[index].value;
                            }

                            CGST_AMT[index].value = (parseFloat(txtamt[index].value) * CGST_Rate[index].value / 100.00).toFixed(2);
                            SGST_AMT[index].value = (parseFloat(txtamt[index].value) * SGST_Rate[index].value / 100.00).toFixed(2);

                            //------------------

                            IGST_AMT[index].value = (parseFloat(txtamt[index].value) * IGST_RATE[index].value / 100.00).toFixed(2)

                            var aa = '0';
                            aa = parseFloat(CGST_AMT[index].value) + parseFloat(SGST_AMT[index].value) + parseFloat(IGST_AMT[index].value);

                            Tot_L_O += parseFloat(aa)

                            sum_T += parseFloat(txtamt[index].value)
                        }
                        else if (tax_type[index].value == 'R') {

                            if (ddl_CUR[index].value != 'INR') {
                                txtamt[index].value = (txtqty[index].value * txtunit_price[index].value * txt_Ex_Rate[index].value).toFixed(2);
                            }
                            else {
                                txt_Ex_Rate[index].value = "1"
                                txtamt[index].value = (txtqty[index].value * txtunit_price[index].value).toFixed(2);
                            }

                            if (GST_State.val() == 'L') {

                                var aa = '0';
                                var M = '0';
                                var N = '0';

                                M = (parseFloat(txtamt[index].value) * CGST_Rate[index].value / 100.00).toFixed(2);
                                N = (parseFloat(txtamt[index].value) * SGST_Rate[index].value / 100.00).toFixed(2);

                                aa = parseFloat(M) + parseFloat(N);

                                CGST_AMT[index].value = '0';
                                SGST_AMT[index].value = '0';
                                IGST_AMT[index].value = '0';
                                IGST_RATE[index].value = '0';

                                sum_R += parseFloat(aa)

                            }
                            else {

                                var X = '0';

                                CGST_AMT[index].value = '0';
                                SGST_AMT[index].value = '0';
                                CGST_Rate[index].value = '0';
                                SGST_Rate[index].value = '0';
                                IGST_AMT[index].value = '0';

                                //IGST_AMT[index].value = (parseFloat(txtamt[index].value) * IGST_RATE[index].value / 100.00)
                                X = (parseFloat(txtamt[index].value) * IGST_RATE[index].value / 100.00).toFixed(2);

                                sum_R += parseFloat(X);
                            }

                            sum_T += parseFloat(txtamt[index].value)
                        }

                        //------------------------------------------------------------
                    }
                    counter++;
                }
            });

          $('#txtnon_tax_amt').val(sum_N.toFixed(2));
          $('#txttax_amt').val(sum_T.toFixed(2));
          $('#txt_tot_Rev_Amt').val(sum_R.toFixed(2));

          $('#txt_total_tax_amt').val(Tot_L_O.toFixed(2));
          document.getElementById("txt_total_amt_With_tax").value = (parseFloat(sum_T) + parseFloat(Tot_L_O)).toFixed(2);
          document.getElementById("txt_grand_total").value = Math.round((parseFloat(sum_T) + parseFloat(Tot_L_O) + parseFloat(sum_N.toFixed(2))).toFixed(2));

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
    
</body>
</html>
