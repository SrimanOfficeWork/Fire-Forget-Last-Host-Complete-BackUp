<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GST_Imp_Exp_Invoice_Job.aspx.cs" Inherits="GST_Imp_Exp_Invoice_Job" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> I- GST Bill</title>
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

    <script src="../js/Billing/Invoice_Paramount.js" type="text/javascript"></script>
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
             document.getElementById("page-10").style.display = 'none';

             document.getElementById("Page_A").className = 'inactive';
             document.getElementById("Page_B").className = 'active';
             document.getElementById("Page_C").className = 'inactive';
             document.getElementById("Page_D").className = 'inactive';
             document.getElementById("Page_E").className = 'inactive';
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
            <div id="innerbox_MidMain_Billing" style="height: 95px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                        I GST Bill Entry
                    </div>
                      <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="txtcon-m_Exchange" style="width: 120px;">
                            <asp:RadioButtonList ID="Rd_Imp_Exp" runat="server" RepeatDirection="Horizontal" TabIndex="91" ForeColor="Purple">
                                <asp:ListItem Text="Imp" Value="I" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 50px;margin-top:5px;">
                            Bill To
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 130px;">
                            <asp:RadioButtonList ID="Rd_Bill_Type" runat="server" RepeatDirection="Horizontal" ForeColor="Blue"
                                AutoPostBack="true" TabIndex="6" OnSelectedIndexChanged="Rd_Bill_Type_SelectedIndexChanged">
                                <asp:ListItem Text="Local" Value="L" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                  
                    <div id="verslic" style="margin-top: -5px;">
                    </div>

                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="txtcon-m_Exchange" style="width: 270px;">
                            <asp:RadioButtonList ID="Rd_Tax_NonTax" runat="server" RepeatDirection="Horizontal" ForeColor="Red" Visible="false" >
                                <asp:ListItem Text="Tax" Value="T"></asp:ListItem>
                                <asp:ListItem Text="Non-Tax" Value="N"></asp:ListItem>
                                <asp:ListItem Text="Re-Imbursement" Value="R"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                   
                   <%-- <div id="verslic" style="margin-top: -5px;">
                    </div>
                    
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="txtcon-m_Exchange" style="width: 250px;">
                            Tr. Mode &nbsp;&nbsp;
                            <asp:DropDownList ID="ddl_tr_mode" CssClass="listtxt_transac_item_gen_notn" Font-Size="12px"
                                Width="80px" TabIndex="15" runat="server">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Air" Value="Air"></asp:ListItem>
                                <asp:ListItem Text="Sea" Value="Sea"></asp:ListItem>
                                <asp:ListItem Text="Land" Value="Land"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>--%>
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
                                    Customer Name</div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddlCus_name" runat="server" class="chosen-select-deselect"
                                        Style="width: 370px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                        TabIndex="8" onselectedindexchanged="ddlCus_name_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 580px;">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Branch No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 170px;">
                                        <asp:DropDownList ID="ddlbranch_No" runat="server" class="chosen-select-deselect"
                                            Style="width: 162px;" data-placeholder="Choose a Branch No" TabIndex="10"  >
                                        </asp:DropDownList>
                                    </div>
                                 

                                     <div id="tag_label_transact_Src" style="width: 50px; color:Green; font-weight:bold;">
                                       Job No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 150px;">
                                        <asp:TextBox ID="txt_Jobno" runat="server" CssClass="txtbox_none_Mid_transac_Inv_No" ClientIDMode="Static" Width="140px" MaxLength="20" TabIndex="21">
                                        </asp:TextBox>
                                    </div>
                                     <div id="txtcon-m_Exchange" style="width: 80px;">
                                           <asp:Button ID="btn_Addjobno" TabIndex="22" runat="server" Width="80px"  CausesValidation="false" UseSubmitBehavior="false"
                                           Height="20px" Text="Add Jobno" onclick="btn_Addjobno_Click" />
                                    </div>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l" style="width: 1080px;">


                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Ship Type 1
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px;">
                                 <asp:DropDownList ID="ddl_tr_mode" CssClass="listtxt_transac_item_gen_notn" Font-Size="12px"
                                Width="80px" TabIndex="15" runat="server">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Air" Value="Air"></asp:ListItem>
                                <asp:ListItem Text="Sea" Value="Sea"></asp:ListItem>
                                <asp:ListItem Text="Land" Value="Land"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                  <div id="tag_label_transact_Src" style="width: 110px;">
                                   Ship Type 2
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px;">
                                <asp:DropDownList ID="ddlshipment_type" CssClass="listtxt_transac_item_gen_notn"
                                        Font-Size="12px" Width="110px" TabIndex="16" runat="server">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                         <asp:ListItem Text="LCL" Value="LCL"></asp:ListItem>
                                         <asp:ListItem Text="FCL" Value="FCL"></asp:ListItem>
                                         <asp:ListItem Text="Ex-bond" Value="Exbond"></asp:ListItem>
                                         <asp:ListItem Text="20 Feet" Value="20"></asp:ListItem>
                                         <asp:ListItem Text="40 Feet" Value="40"></asp:ListItem>
                                         <asp:ListItem Text="20-40 Feet" Value="20-40"></asp:ListItem>
                                         <asp:ListItem Text="Bond" Value="Bond"></asp:ListItem>
                                         <asp:ListItem Text="Dry Bulk" Value="DB"></asp:ListItem>
                                         <asp:ListItem Text="Capital Goods" Value="CG"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                   From Quotation
                                </div>

                                 <div id="tag_label_transact_Src" style="width: 60px;">
                                <asp:CheckBox ID="From_Quotation" runat="server" TabIndex="11" Checked="true" />
                                 </div>
                                 <div id="tag_label_transact_Src" style="width: 143px;">
                                    <asp:Button ID="btnloadData" TabIndex="22" runat="server" Width="100px" 
                                        Height="20px" Text="Load Data" onclick="btnloadData_Click" />
                                </div>

                                <div id="tag_label_transact_Src" style="width: 70px;">
                                   Bill Cur.
                                </div>

                                 <div id="tag_label_transact_Src" style="width: 70px;">
                                <asp:DropDownList ID="ddl_cur" CssClass="listtxt_transac_item_gen_notn"
                                        Font-Size="12px" Width="60px" TabIndex="23" runat="server">
                                        <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                         <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                                    </asp:DropDownList>
                                 </div>
                                  <div id="tag_label_transact_Src" style="width: 90px;">
                                   Ex - Rate
                                </div>

                                 <div id="tag_label_transact_Src" style="width: 60px;">
                                
                                     <asp:TextBox ID="txtEx_Rate"  CssClass="txtbox_none_Mid_transac_Inv_No"  TabIndex="24" Text="1"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" 
                                            onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="15px" Width="65px" Font-Size="12px"  runat="server" style="text-align:right"></asp:TextBox>
                                    

                                 </div>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>


         <div class="content" id="page-1" style="margin-top:-28px;">
                        
          <div id="innerbox_MidMain_Trans_new" style="height:440px; width:1194px; margin-left:-16px; margin-top:-5px;">
                <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span>General </span></a></li>

                     <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server" >
                        <span>Item I </span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" >
                        <span> Item II </span></a></li>

                    <li><a href="#page-10" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page5('0');" id="Page_E" visible="false" runat="server">
                        <span>Annexure</span></a></li>

                   <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span>Charge details</span></a></li>

                        <span style="color:black;font-size:12px;"> &nbsp; 
                            <asp:Literal ID="lbl_Created_Modified" runat="server"></asp:Literal>
                         </span>
                </ol>
                  <%----------------------------General---------------------------------------------------%>
                    <div   class="content" id="page-6"  >
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:490px;margin-top: -16px; margin-left:-18px; color:Red;">
                            <div id="Div_listbox" runat="server">
                                <div id="tag_transact_src_inner" style="width: 1080px; height: 250px;">
                                    <div id="innerbox_MidMain_Trans_new" style="width: 1080px; height: 20px; margin-left: -10px;
                                        border-bottom-style: solid;">
                                        <div id="tag_label_transaction_exp_jobb">
                                            <asp:CheckBox ID="cbAll" runat="server" ForeColor="White" Font-Bold="true" Font-Size="14px"
                                                Text="Select All" onclick="CheckAll();" /> &nbsp;&nbsp;&nbsp;
                                        </div>
                                         <div id="tag_label_transaction_exp_jobb">
                                           <asp:Button ID="btn_Remove" TabIndex="22" runat="server" Width="100px"  
                                             CausesValidation="false" UseSubmitBehavior="false"
                                               Height="20px" Text="Remove Jobno" onclick="btn_Remove_Click" />
                                         </div>
                                        <div id="tag_label_transaction_exp_jobb">
                                            <span style="color: White;">
                                                <asp:Literal ID="lbl_Loc" runat="server"></asp:Literal>
                                            </span>
                                        </div>
                                    </div>
                                    <div id="tag_label_transaction_exp_jobb" style="width: 1080px; overflow: auto; height: 200px;">
                                        <asp:CheckBoxList ID="cbList" runat="server" ValidationGroup="VGroup" onclick="UnCheckAll();"
                                            BorderStyle="none" CssClass=" txtbox_none_Mid_transac_pop_gen" Width="1070px"
                                            Height="22px" Font-Size="11px" RepeatColumns="6" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                            </div>
                        <div id="tag_transact_src_inner" style="width: 1085px">
                    <div id="tag_Exchange_inner_lft" style="width: 1085px">
                        <div id="tag_transact_lft_in1" style="width: 1085px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Invoice No:
                                    </div>
                                
                                <div id="txtcon-m_Exchange" > 
                                  <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="17" onkeyup="autotab(this);" ClientIDMode="Static" onblur="return ChangeCase(this);"
                                   onkeypress="return Char_Inv(event)"  
                                   CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="25" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 220px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                   Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                    <asp:TextBox ID="txtDate" runat="server" Width="82px" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                        TabIndex="26"></asp:TextBox>
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
                              <%--<div id="txt_container_Transact_Main_l" style="width: 300px">
                                <div id="txtcon-m_Exchange" style="width: 290px;">
                                     <asp:RadioButtonList ID="Rd_Tax_NonTax" runat="server" RepeatDirection="Horizontal" CssClass="validate[required]"  >
                                    <asp:ListItem Text="Tax" Value="T"></asp:ListItem>
                                    <asp:ListItem Text="Non-Tax" Value="N"></asp:ListItem>
                                    <asp:ListItem Text="Re-Imbursement" Value="R" ></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>--%>
                              <div id="txt_container_Transact_Main_l" style="width: 480px">
                              <div id="tag_label_transact_Src" style="width: 80px">
                                   PO No:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 240px;">
                                    <asp:TextBox ID="txtPONumber" CssClass="txtbox_none_Mid_transac_code" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%---------------------------------------Row 4-----------------------------------------%>
                        <%--------------------------------------AddRow 1-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1085px">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Customer Name:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 330px;">
                                   <asp:TextBox ID="txt_Cus_name" runat="server" MaxLength="200" onkeyup="autotab(this);" Width="330px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="68" ></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                             <a href="#"  class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('GST_Bill_Cus_name'); return false">
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

                             <%-- <div id="txt_container_Transact_Main_l" style="width: 480px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                    Bank Name
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 400px">
                                     <asp:DropDownList ID="ddlbank_name" CssClass="listtxt_transac_item_gen_notn" Width="400px" TabIndex="70" ForeColor="Green" runat="server" >
                                     <asp:ListItem Text="Beneficiary Name : Denken Global Supply Chain Pvt Ltd, Bank Name : State Bank of India, Branch Name : Meenambakkam,Bank A/c No.: #33029146658, IFSC Code No. : SBIN0005789,MICR No. : 600002068" Value="State Bank of India (Kalaimagal Nager)"></asp:ListItem>
                                    <asp:ListItem Text="Axis Bank" Value="Axis Bank"></asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                            </div>--%>
                              <div id="txt_container_Transact_Main_l" style="width: 480px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                   Acc. Head
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 400px">
                                    <asp:TextBox ID="txtAccHead" CssClass="txtbox_none_Mid_transac_code" runat="server"></asp:TextBox>
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
                                   <asp:TextBox ID="txt_Party_Add" runat="server" MaxLength="500" 
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  Height="50px" TabIndex="74" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                      <%--------------------------------------AddRow 6-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1085px;height:60px;">
                            <div id="txt_container_Transact_Main_l" style="width: 1080px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  Bank Name
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 970px;">
                                   <asp:DropDownList ID="ddlbank_name" CssClass="listtxt_transac_item_gen_notn" Width="970px" TabIndex="70" ForeColor="Green" runat="server" >
                                   
                                   <%--<asp:ListItem Text="BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD, BANK NAME : IDBI BANK LTD,BRANCH NAME : PARRYS, CURRENT A/C NO : #907102000039127,IFS CODE NO. : IBKL0000907,SWIFT CODE : IBKLINBB005,MICR NO. : 600259007" 
                                    Value="BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD,BANK NAME        : IDBI BANK LTD,BRANCH NAME      : PARRYS,CURRENT A/C NO   : #907102000039127,IFS CODE NO.     : IBKL0000907,SWIFT CODE       : IBKLINBB005,MICR NO.         : 600259007" ></asp:ListItem>
                                    <asp:ListItem Text="BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD,BANK NAME : AXIS BANK LTD,BRANCH NAME: GEORGE TOWN, CHENNAI,CURRENT A/C NO: #424010200003926,IFS CODE NO.: UTIB0000424,SWIFT CODE: AXISINBB424,MICR NO. : 600211016" 
                                    Value="BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD,BANK NAME        : AXIS BANK LTD,BRANCH NAME      : GEORGE TOWN CHENNAI,CURRENT A/C NO   : #424010200003926,IFS CODE NO.     : UTIB0000424,SWIFT CODE       : AXISINBB424,MICR NO.         : 600211016"></asp:ListItem>
                                    <asp:ListItem Text="BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD,BANK NAME: AXIS BANK LTD,BRANCH NAME: CBB, CHENNAI,CURRENT A/C NO : #006010300017471,IFS CODE NO. : UTIB0001165,SWIFT CODE : AXISINBBA01,MICR NO. : 600211036" 
                                    Value="BENEFICIARY NAME : PARAMOUNT SHIPPING SERVICES PVT LTD,BANK NAME        : AXIS BANK LTD,BRANCH NAME      : CBB CHENNAI,CURRENT A/C NO   : #006010300017471,IFS CODE NO.     : UTIB0001165,SWIFT CODE       : AXISINBBA01,MICR NO.         : 600211036"
                                    ></asp:ListItem>--%>
                                     </asp:DropDownList>
                                </div>
                            </div>
                            
                               
                        </div>
                         <%--------------------------------------Row End-----------------------------------------%>
                    </div>
                 
                </div>
                        </div>
                    </div>

                      <%----------------------------Other---------------------------------------------------%>
              <div class="content" id="page-8">
                      <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px;
                      width: 1194px; margin-top: -10px; margin-left: -18px;">
                      <asp:GridView ID="gv_Gen_Item_I" runat="server"  EmptyDataText="No Record Found"  ShowHeader="True"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"  
                                ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                              CssClass="grid-view" AllowPaging="false"
                                 HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                OnRowCreated="GV_Gen_head_RowCreated" 
                              onrowdatabound="gv_Gen_Item_I_RowDataBound" >
                              
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <PagerStyle  ForeColor="Black"  CssClass="pager" />
                                <Columns>
                                   
                                   <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px"  >
                                        <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_I" Text='<%# Bind("JOBNO") %>'  Width="70px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mode" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px"  >
                                        <ItemTemplate>
                                        <asp:TextBox ID="txt_tr_mode" Text='<%# Bind("TR_MODE") %>'  Width="30px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>
                                   
                                     <asp:TemplateField HeaderText="File.Refno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_file_Refno" Text='<%# Bind("FILE_REF_NO") %>'  Width="80px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Party.Refno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Party_Refno" Text='<%# Bind("PARTY_REF_NO") %>'  Width="80px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px"/>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Pkg" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_no_of_pkg"  Text='<%# Bind("NO_OF_PKGS") %>'  Width="50px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px"/>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_no_of_pkg_type"   Text='<%# Bind("PKGS_TYPE") %>'  Width="30px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px"/>
                                    </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Flt/Vsl No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_flt_vessel_no"   Text='<%# Bind("FLT_VSL_NO") %>'  Width="80px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px"/>
                                    </asp:TemplateField>
                                     
                                      <asp:TemplateField HeaderText="MAWB/MBL" HeaderStyle-Font-Bold="true" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_MAWB_MBL"   Text='<%# Bind("MAWB_MBL_NO") %>'  Width="120px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="120px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_MAWB_MBL_Date"   Text='<%# Bind("MAWB_MBL_DATE") %>'  Width="70px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="HAWB/HBLNO" HeaderStyle-Font-Bold="true" HeaderStyle-Width="120px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_HAWB_HBLNO"  Text='<%# Bind("HAWB_HBL_NO") %>'  Width="120px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="120px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_HAWB_HBLDATE"   Text='<%# Bind("HAWB_HBL_DATE") %>'  Width="70px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Gross Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Gross_Wgt"   Text='<%# Bind("GROSS_WGT") %>'  Width="70px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Gross_Wgt_Type"   Text='<%# Bind("GROSS_WGT_TYPE") %>'  Width="30px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Net Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_net_Wgt"   Text='<%# Bind("NET_WGT") %>'  Width="70px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_net_Wgt_Type"   Text='<%# Bind("NET_WGT_TYPE") %>'  Width="30px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px"/>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                  </div>
              </div>
               <div class="content" id="page-9">
               
               <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px; width: 1194px; margin-top: -10px; margin-left: -18px;">

                      <asp:GridView ID="gv_Gen_Item_II" runat="server"  
                          EmptyDataText="No Record Found"  ShowHeader="True"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"  
                                ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                          CssClass="grid-view" AllowPaging="false"
                                 HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                OnRowCreated="GV_Gen_head_RowCreated" 
                          onrowdatabound="gv_Gen_Item_II_RowDataBound" >
                              
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <PagerStyle  ForeColor="Black"  CssClass="pager" />
                                <Columns>
                                   
                                   <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px"  >
                                        <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_II" Text='<%# Bind("JOBNO") %>'  Width="70px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Inv. No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px"  >
                                        <ItemTemplate>
                                        <asp:TextBox ID="txt_Inv_No" Text='<%# Bind("INV_NO") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>
                                   
                                     <asp:TemplateField HeaderText="Inv. Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Inv_Date" Text='<%# Bind("INV_DATE") %>'  Width="80px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Item Desc." HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Item_Dec" Text='<%# Bind("ITEM_DESC") %>'  Width="300px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="300px"/>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Ass / PMV Value" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ass_Value"  Text='<%# Bind("ASS_VALUE") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Duty / FOB Value" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Duty_Value"   Text='<%# Bind("DUTY_VALUE") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>

                                   <asp:TemplateField HeaderText="CIF / DBK Value" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CIF_Value"   Text='<%# Bind("CIF_VALUE") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>
                                     
                                      <asp:TemplateField HeaderText="BE / SB No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_BE_SB_NO"   Text='<%# Bind("BE_SB_NO") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="BE / SB Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_BE_SB_DATE"   Text='<%# Bind("BE_SB_DATE") %>'  Width="80px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px"/>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                  </div>
               </div>
                 <%----------------------------Charge Details---------------------------------------------------%>

                    <div  class="content"  id="page-7"  style="display:none;height:440px;" >
                          

                           <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 30px;
                                width: 1194px; margin-top: -10px;margin-left:-18px;">
                                <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                    CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" Style="overflow: auto;">
                                    <Columns>
                                        <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="S. No" HeaderStyle-Width="122px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="62px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="a" HeaderText="Charge Name" HeaderStyle-Width="970px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                        </asp:BoundField>

                                        <asp:BoundField  HeaderText="Description" HeaderStyle-Width="320px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="d" HeaderText=" Qty" HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="5px" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField DataField="e" HeaderText="Unit Price" HeaderStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="f" HeaderText="Amt" HeaderStyle-Width="140px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="140px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText=" % " HeaderStyle-Width="50px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="CGST Amt" HeaderStyle-Width="110px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="110px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText=" % " HeaderStyle-Width="40px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="40px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="SGST Amt" HeaderStyle-Width="120px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText=" % " HeaderStyle-Width="50px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="IGST Amt" HeaderStyle-Width="105px">
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

                            <div id="tag_transac_lft_Item_maindet_Grid_area"    style="overflow:auto; height:305px; width:1194px;margin-top:-10px;margin-left:-18px; ">
                             <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" 
                                    BorderStyle="none" ShowFooter="True" 
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" onrowdeleting="gv_Chg_Details_RowDeleting" ShowHeader = "false" 
                                    style=" overflow-x: hidden;overflow-y: auto;" DataKeyNames="CHARGE_VALUE" > 
                                    
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


                                   <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="620px">
                                       <ItemTemplate>
                                           <%--<asp:TextBox ID="txtch_name"  CssClass="underlined"   Text='<%# Bind("CHARGE_NAME") %>' runat="server" onblur="Calculation(this)"                                       
                                            Height="20px" Width="157px" Font-Size="12px"  ></asp:TextBox>
                                            <asp:HiddenField ID="hfCustomerId" runat="server" />--%>

                                            <asp:DropDownList ID="txtch_name"  MaxLength="20" runat="server" onblur="Calculation_Rate(this)" 
                                               Width="450px" Height="22px" Font-Size="12px"  CssClass="txtbox_trans_exp_drawback">
                                           </asp:DropDownList>
                                           <asp:HiddenField ID="hfCustomerId" runat="server" />
                                           
                                          <asp:TextBox ID="txt_charge_desc"  CssClass="underlined"  Text='<%# Bind("CHARGE_DESC") %>' runat="server" onblur="Calculation(this)"                                       
                                            Height="20px" Width="157px" Font-Size="12px"  ></asp:TextBox>

                                       </ItemTemplate>
                                         <ItemStyle Width="620px" />
                                   </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Qty" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtqty"  CssClass="underlined"  Text='<%# Bind("Qty") %>' Height="20px" Width="28px" Font-Size="12px" 
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  
                                           onkeypress="return blockNonNumbers(this, event, true, false);"
                                            runat="server" style="text-align:center" ></asp:TextBox>
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
                                    Total Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                 <asp:TextBox ID="txt_total_amt" runat="server" MaxLength="17" onkeyup="autotab(this);" BackColor="#F5F5F5" Width="100px" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="101" ></asp:TextBox>
                                </div>
                            </div>
                           <div id="txt_container_Transact_Main_l"   style="width: 400px;">
                                <div id="tag_label_transact_Src" style="width: 235px">
                                Taxable Amt (CGST + SGST + IGST) :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px">
                                <asp:TextBox ID="txttax_amt" runat="server" MaxLength="17" onkeyup="autotab(this);" BackColor="#F5F5F5" Width="100px" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="101" ></asp:TextBox>
                                </div>
                            </div>
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
                             
                        
                        </div>

                       <div id="tag_transact_lft_in1" style="width: 1085px">
                            <%--<div id="txt_container_Transact_Main_l"  style="width: 250px;">
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
                            </div>--%>
                        
                         <%-------------------------------------------------------------------------------%>
                              <div id="txt_container_Transact_Main_l" style="width: 250px">
                                <div id="tag_label_transact_Src" style="width: 110px">
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

                                        <a id="Link_Container" runat="server" href="javascript:open_Imp_Exp_Expense_Amt_New('I')">
                                         <span style="font-size: 12px; font-weight: bold;">View</span> </a>
                               </div>

                           </div>

                        </div>
                       <%-------------------------------------------------------------------------------%>
                        <%-------------------------------------------------------------------------------%>

                       </div>

                    </div>
                    
                  <%-------------------------------------------------------------------------------%>

                   <%------------------------------page---10----------------------------------------------%>
                   <div class="content" id="page-10">
                   <div style="overflow:auto; margin-left:-13px; margin-top:-5px;">
                   <asp:GridView ID="gv_Gen_Annexure" runat="server"  EmptyDataText="No Record Found"  ShowHeader="False"
                                AutoGenerateColumns="False" BackColor="White" BorderStyle="none"  
                                ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1" 
                           CssClass="grid-view" AllowPaging="false"
                                 HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="140%"
                                  OnRowCreated="GV_RowCreated"
                           onrowdatabound="gv_Gen_Annexure_RowDataBound" >
                              
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <PagerStyle  ForeColor="Black"  CssClass="pager" />
                                <Columns>
                                   
                                   <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px"  >
                                        <ItemTemplate>
                                         <asp:TextBox ID="txt_Anx_Jobno" Text='<%# Bind("JOBNO") %>'  Width="70px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Inv. No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px"  >
                                        <ItemTemplate>
                                        <asp:TextBox ID="txt_Ch_Amt_A" Text='<%# Bind("CH_AMT_A") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>
                                   
                                     <asp:TemplateField HeaderText="Inv. Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_B" Text='<%# Bind("CH_AMT_B") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Item Desc." HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_C" Text='<%# Bind("CH_AMT_C") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Ass. Value" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_D"  Text='<%# Bind("CH_AMT_D") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Duty Value" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_E"   Text='<%# Bind("CH_AMT_E") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>

                                   <asp:TemplateField HeaderText="CIF Value" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_F"   Text='<%# Bind("CH_AMT_F") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>
                                     
                                      <asp:TemplateField HeaderText="BE/SB No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_G"   Text='<%# Bind("CH_AMT_G") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="BE/SB Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_H"   Text='<%# Bind("CH_AMT_H") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="BE/SB Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_I"   Text='<%# Bind("CH_AMT_I") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BE/SB Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_J"   Text='<%# Bind("CH_AMT_J") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BE/SB Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_K"   Text='<%# Bind("CH_AMT_K") %>'  Width="60px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px"/>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="BE/SB Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_L"   Text='<%# Bind("CH_AMT_L") %>'  Width="60px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px"/>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BE/SB Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_M"   Text='<%# Bind("CH_AMT_M") %>'  Width="60px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px"/>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="BE/SB Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_N"   Text='<%# Bind("CH_AMT_N") %>'  Width="60px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px"/>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="BE/SB Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="60px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ch_Amt_O"   Text='<%# Bind("CH_AMT_O") %>'  Width="60px"  runat="server" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px"/>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                  </div>
                   </div>
                   <%---------------------------------10E---------------------------------------------------%>


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
                            <%--<asp:Button ID="btnrpt" runat="server" tabindex="125" Text="Get Bill" OnClientClick="return GST_Billing_Job_Rpt('B');"  />--%> <%--OnClientClick="return Import_Billing_Job_Rpt('B');"--%> 
                            <asp:Button ID="btnrpt" runat="server" tabindex="125" Text="Get Bill" OnClientClick="return GST_Billing_Combined_Job_Rpt('B');"  /> <%--OnClientClick="return Import_Billing_Job_Rpt('B');"--%> 
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
                activatables('page', ['page-6', 'page-7', 'page-8', 'page-9', 'page-10']);
            </script>

             <asp:HiddenField ID="HDupdate_id" runat="server"  ClientIDMode="Static" />
             <asp:HiddenField ID="HDupdate_IMP_EXP_id" runat="server"  ClientIDMode="Static" />


             <asp:HiddenField ID="hdimp" runat="server" />
             <asp:HiddenField ID="hd_Brslno" runat="server" />
             <asp:HiddenField ID="Hd_row_id" runat="server" />
             <asp:HiddenField ID="HD_Showcon" runat="server" />

             <asp:HiddenField ID="hd_Selected_Jobs" runat="server" ClientIDMode="Static" />
             <asp:HiddenField ID="hd_Jobs" runat="server" ClientIDMode="Static"  />
             <asp:HiddenField ID="hd_Imp_Exp" runat="server" ClientIDMode="Static"  />

             <asp:HiddenField ID="Hdjobno" runat="server" ClientIDMode="Static"  />
             <asp:HiddenField ID="Hd_I_E" runat="server" ClientIDMode="Static"  />
             
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
        $(function () {
            $("#txt_Jobno").autocomplete({
                source: function (request, response) {
                    var ddlCus_name = $('#<%= ddlCus_name.ClientID %>').val();
                    var ddlbranch_No = $('#<%= ddlbranch_No.ClientID %>').val();
                    var txt_Jobno_list = $('#<%= hd_Selected_Jobs.ClientID %>').val();
                    var Rd_Imp_Exp = $('input:radio[name=Rd_Imp_Exp]:checked').val();
                    var ddl_tr_mode = $('#<%= ddl_tr_mode.ClientID %>').val();

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Exp_Billing_Paramount_Search",
                        data: "{ 'mail': '" + request.term + "','Imp_Exp': '" + Rd_Imp_Exp + "','Cus_name': '" + ddlCus_name + "' ,'Branch_No': '" + ddlbranch_No + "','Jobno_list': '" + txt_Jobno_list + "','ddl_tr_mode': '" + ddl_tr_mode + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txt_Jobno').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_Jobno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
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
    function Calculation_Rate(lnk) {
        var row_r = lnk.parentNode.parentNode;
        var rowIndex_r = row_r.rowIndex;
        $('#Hd_row_id').val(rowIndex_r);
        var ddlval = $("[id*=txtch_name]")
        var ddlchas = ddlval[rowIndex_r].value;
        var State = $("#Rd_Bill_Type input[type='radio']:checked");
        Cha_Type_Rate(ddlchas, State.val());
    }  
</script>
<script type="text/javascript">
        function Cha_Type_Rate(src, dest) {
            PageMethods.Get_Cha_Type_Rate(src, dest, '', CallSuccess_Rate, CallFailed, dest);
        }

        function CallSuccess_Rate(res, destCtrl) {
            var data = res;
            if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

                var s = data.split('~~');
                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];

                var txtCGST_Rate = $("[id*=txtCGST_RATE]");
                var txtSGST_Rate = $("[id*=txtSGST_RATE]");
                var txtIGST_Rate = $("[id*=txtIGST_RATE]");

                txtCGST_Rate[document.getElementById("Hd_row_id").value].value = before;
                txtSGST_Rate[document.getElementById("Hd_row_id").value].value = after1;
                txtIGST_Rate[document.getElementById("Hd_row_id").value].value = after2;

            }
            else {
                //document.getElementById("txtNCD_RATE").value = '';
                //document.getElementById("txtNCD_SPL").value = '';
                //document.getElementById("txtNCD_UNIT").value = '';
            }

        }

        function Cha_Type(src, dest) {
            PageMethods.Get_Cha_Type(src, '', '', CallSuccess_Cha_Type, CallFailed, dest);
        }


        function CallSuccess_Cha_Type(res, destCtrl) {

            var data = res;

            if (res != '') {

                var chargetype = $("[id*=ddl_tax_nontax]")
                var selected = $('input:radio[name=Rd_Bill_Type]:checked').val();
                var txtCGST_RATE_OP = $("[id*=txtCGST_RATE]")
                var txtCGST_AMT_OP = $("[id*=txtCGST_AMT]")
                var txtSGST_RATE_OP = $("[id*=txtSGST_RATE]")
                var txtSGST_AMT_OP = $("[id*=txtSGST_AMT]")
                var txtIGST_RATE_OP = $("[id*=txtIGST_RATE]")
                var txtIGST_AMT_OP = $("[id*=txtIGST_AMT]")

               

                if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

                    var s = data.split('~~');
                    var before = s[0];
                    var after1 = s[1];
                    var after2 = s[2]; 
                    var tempCGST_RATE = s[3];    
                    var tempSGST_RATE = s[4];     
                    var tempIGST_RATE = s[5];     

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

                           
                            if (txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0')
                            {

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

                       // txt_HSN_Code[document.getElementById("Hd_row_id").value].value = after1;
                    }
                    else {
                        //txt_HSN_Code[document.getElementById("Hd_row_id").value].value = '';
                    }
                    //txt_SA_Code[document.getElementById("Hd_row_id").value].value = after2.toString(); 
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
          Tax_Cal();
       });
</script>
  
  <script type="text/javascript">
      $(document).ready(function () {
          
          //----------------------------------------------------------
          /*
          var ddlcha = $('[id*=txtch_name]').val();
          $('[id*=txtch_name]').focus(function () {
              Cha_Type_Rate(ddlcha, '2');
          });
          $('[id*=txtch_name]').change(function () {
              // Cha_Type_Rate(ddlch.value, '2');
              alert('2');
          });
          */
          $('[id*=txtch_name]').focus(function () {
              
          });
          $('[id*=txtch_name]').change(function () {
              // Cha_Type_Rate(ddlch.value, '2');
             
          });
          $('[id*=txtch_name]').keyup(function () {
             
              //Cha_Type_Rate(ddlch.value, '2');
          });
          $('[id*=txtch_name]').keydown(function () {
             
              //Cha_Type_Rate(ddlch.value, '2');
          });
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
          var txtqty = $("[id*=txtqty]")
          var txtunit_price = $("[id*=txtunit_price]")

          var CGST_Rate = $("[id*=txtCGST_RATE]")
          var SGST_Rate = $("[id*=txtSGST_RATE]")

          var CGST_AMT = $("[id*=txtCGST_AMT]")
          var SGST_AMT = $("[id*=txtSGST_AMT]")

          var IGST_RATE = $("[id*=txtIGST_RATE]")
          var IGST_AMT = $("[id*=txtIGST_AMT]")

          var sum_T = 0;
          var sum_N = 0;
          var sum_R = 0;

          var Tot_L_O = 0;
          var counter = 0;
          var Tot_Amt = 0;

          $("#<%=gv_Chg_Details.ClientID%> input[id*='chk_inv']:checkbox").each(function (index) {
              if ($(this).is(':checked')) {
                  //-----------------------------------------------------------------------------------------

                  if (txtunit_price[index].value != '') {

                      txtamt[index].value = (txtqty[index].value * txtunit_price[index].value).toFixed(2);
                      CGST_AMT[index].value = (parseFloat(txtamt[index].value) * CGST_Rate[index].value / 100.00).toFixed(2);
                      SGST_AMT[index].value = (parseFloat(txtamt[index].value) * SGST_Rate[index].value / 100.00).toFixed(2);
                      IGST_AMT[index].value = (parseFloat(txtamt[index].value) * IGST_RATE[index].value / 100.00).toFixed(2);

                      var aa = '0';
                      aa = parseFloat(CGST_AMT[index].value) + parseFloat(SGST_AMT[index].value) + parseFloat(IGST_AMT[index].value);

                      Tot_L_O += parseFloat(aa);
                      Tot_Amt += parseFloat(txtamt[index].value);

                  }
                  //-----------------------------------------------------------------------------------------

                  counter++;
              }
          });

          $('#txt_total_amt').val(Tot_Amt.toFixed(2));
          //$('#txtnon_tax_amt').val(sum_N.toFixed(2));
          $('#txttax_amt').val(Tot_L_O.toFixed(2));
          document.getElementById("txt_grand_total").value = Math.round((parseFloat(Tot_L_O.toFixed(2)) + parseFloat(Tot_Amt.toFixed(2))).toFixed(2));

          //$('#txt_total_tax_amt').val(Tot_L_O.toFixed(2));
          //document.getElementById("txt_total_amt_With_tax").value = (parseFloat(sum_T) + parseFloat(Tot_L_O)).toFixed(2);
          //document.getElementById("txt_grand_total").value = Math.round((parseFloat(sum_T) + parseFloat(Tot_L_O) + parseFloat(sum_N.toFixed(2))).toFixed(2));
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
    <script language="javascript">

        function CheckAll() {
            var intIndex = 0;
            var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;
            for (i = 0; i < rowCount; i++) {
                if (document.getElementById('cbAll').checked == true) {
                    if (document.getElementById("cbList" + "_" + i)) {
                        if (document.getElementById("cbList" + "_" + i).disabled != true)
                            document.getElementById("cbList" + "_" + i).checked = true;
                    }
                }
                else {

                    if (document.getElementById("cbList" + "_" + i)) {
                        if (document.getElementById("cbList" + "_" + i).disabled != true)
                            document.getElementById("cbList" + "_" + i).checked = false;
                    }
                }
            }
        }

        function UnCheckAll() {
            var intIndex = 0;
            var flag = 0;
            var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;
            for (i = 0; i < rowCount; i++) {
                if (document.getElementById("cbList" + "_" + i)) {
                    if (document.getElementById("cbList" + "_" + i).checked == true) {
                        flag = 1;
                    }
                    else {
                        flag = 0;
                        break;
                    }
                }
            }

            if (flag == 0)
                document.getElementById('cbAll').checked = false;
            else
                document.getElementById('cbAll').checked = true;
        }

    </script>

    <script type="text/javascript">
        $(document).ready(function () {

            $('#txt_Cus_name').focus(function () {

                var data = $(this).val();
                Item_desc(data);
            });
            $('#txt_Cus_name').change(function () {

                var data = $(this).val();
                Item_desc(data);
            });
            $('#txt_Cus_name').keyup(function () {

                var data = $(this).val();
                Item_desc(data);
            });
            $('#txt_Cus_name').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });

        function Item_desc(val) {

            var data = val;
            if (data == '') {
                $('#txt_Cus_name').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txt_Cus_name').val(after);

                $('#hdimp').val(after);
                $('#hd_Brslno').val(before);

            }
            else {

            }
        }
  </script>
    
</body>
</html>
