<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Charges_Master_N.aspx.cs" Inherits="Acc_Charges_Master_N" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Charge Master</title>
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

            <div id="innerbox_MidMain_Billing" style="height: 200px; width: 1050px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                        Charge Master
                    </div>
                    <div id="verslic" style="margin-top: 0px;">
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" style="margin-left: 0px;" class="clsicon_new"
                                onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                </div>
           
 

            <div id="innerbox_MidMain_Transact_popup_new_1" style="width: 1250px; height: 80px;
                margin-top: -20px;  margin-left: 8px;">
                <div id="tag_transac_lft_Trans_Invoice_Supp_in1" style="margin-top: 10px">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Code
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 180px;">
                        <asp:TextBox ID="txtcode" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);"
                            MaxLength="20" TabIndex="67"></asp:TextBox>
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 60px;">
                        Name
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:TextBox ID="txtName" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                            style="width:562px;" 
                            MaxLength="100" TabIndex="67"></asp:TextBox>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Apply For
                    </div>
                    <div id="txtcon-m_transaction_Supp_code">
                        <asp:HiddenField ID="hdApplicableFor" runat="server" ClientIDMode="Static" />
                        <div id="txtcon-m_Exchange" style="position: relative; display: inline-block;">
                            <input type="text" class="listtxt_transac_item_gen_notn" id="txtApplicableFor_Display"
                                readonly="readonly" style="width: 800px; height: 18px; margin-left: -2px; border: 1px solid #b0b0b0;
                                background: #ffffff; font-size: 11px; cursor: pointer; padding: 0 4px; color: green;"
                                onclick="toggleApplicableForDropdown()" value="Select..." />
                            <div id="divApplicableFor" style="display: none; position: absolute; z-index: 9999;
                                background: #ffffff; border: 1px solid #b0b0b0; width: 240px; max-height: 200px;
                                overflow-y: auto; top: 22px; left: 0px; padding: 4px 0;">
                                <asp:CheckBoxList ID="chkApplicableFor" runat="server" TabIndex="21" Style="font-size: 11px;
                                    font-family: Arial; color: green;" onclick="updateApplicableForDisplay()">
                                    <asp:ListItem Text="AIR EXPORT" Value="AIR_EXPORT"></asp:ListItem>
                                    <asp:ListItem Text="AIR IMPORT" Value="AIR_IMPORT"></asp:ListItem>
                                    <asp:ListItem Text="SEA EXPORT" Value="SEA_EXPORT"></asp:ListItem>
                                    <asp:ListItem Text="SEA IMPORT" Value="SEA_IMPORT"></asp:ListItem>
                                    <asp:ListItem Text="CUSTOM CLEARING IMPORT" Value="CUSTOM_CLEARING_IMPORT"></asp:ListItem>
                                    <asp:ListItem Text="CUSTOM CLEARING EXPORT" Value="CUSTOM_CLEARING_EXPORT"></asp:ListItem>
                                    <asp:ListItem Text="TRANSPORT" Value="TRANSPORT"></asp:ListItem>
                                    <asp:ListItem Text="GENERAL" Value="GENERAL"></asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                    </div>
                   
                </div>
                <div id="tag_transac_lft_Trans_Invoice_Supp_in1" style="margin-top: 10px">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Charge Category
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 510px;">
                        <asp:RadioButtonList ID="ddl_charge_category" style="margin-left:-10px;" runat="server" RepeatDirection="Horizontal"
                            TabIndex="10">
                            <asp:ListItem Text="Margin" Value="M" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Revenue" Value="R"></asp:ListItem>
                            <asp:ListItem Text="Cost" Value="C"></asp:ListItem>
                            <asp:ListItem Text="Reimbursement" Value="RI"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_Supp_in1" style="margin-top: 10px">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        Charge Type
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 510px;">
                        <asp:RadioButtonList ID="ddl_charge_type"  style="margin-left:-10px;" runat="server" RepeatDirection="Horizontal"
                            TabIndex="10">
                            <asp:ListItem Text="Freight Like/Surcharge" Value="FR" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Commission" Value="C"></asp:ListItem>
                            <asp:ListItem Text="Others" Value="O"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div id="tag_transac_lft_Trans_Invoice_Supp_in1" style="margin-top: 10px">
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                        IATA_code
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 510px;">
                        <asp:DropDownList ID="ddl_IATA_code" CssClass="listtxt_transac_item_gen_notn" Style="margin-left: -4px;"
                            Width="230px" TabIndex="21" ForeColor="Green" runat="server">
                            <asp:ListItem Text="" Value=""></asp:ListItem>
                            <asp:ListItem Text="AC-Animal Container" Value="AC"></asp:ListItem>
                            <asp:ListItem Text="AS-Assembly Service Fee" Value="AS"></asp:ListItem>
                            <asp:ListItem Text="AT-Attendant" Value="AT"></asp:ListItem>
                            <asp:ListItem Text="AW-Air Waybill Fee" Value="AW"></asp:ListItem>
                            <asp:ListItem Text="BA-Advances and/or guarantees" Value="BA"></asp:ListItem>
                            <asp:ListItem Text="BB-Appraisal Service" Value="BB"></asp:ListItem>
                            <asp:ListItem Text="BC-AWB Copy" Value="BC"></asp:ListItem>
                            <asp:ListItem Text="BE-Collection of funds" Value="BE"></asp:ListItem>
                            <asp:ListItem Text="BF-Copies of documents" Value="BF"></asp:ListItem>
                            <asp:ListItem Text="BH-Messenger service" Value="BH"></asp:ListItem>
                            <asp:ListItem Text="BI-Import/export documents processing" Value="BI"></asp:ListItem>
                            <asp:ListItem Text="BL-Blacklist Certificate" Value="BL"></asp:ListItem>
                            <asp:ListItem Text="BM-Withdrawal of shipment after clearance" Value="BM"></asp:ListItem>
                            <asp:ListItem Text="BR-Bank Release" Value="BR"></asp:ListItem>
                            <asp:ListItem Text="CA-Bonding" Value="CA"></asp:ListItem>
                            <asp:ListItem Text="CB-Completion/preparation of documents" Value="CB"></asp:ListItem>
                            <asp:ListItem Text="CC-Manual data entry for customs purposes" Value="CC"></asp:ListItem>
                            <asp:ListItem Text="CD-Clearance and Handling &#8212; Destination" Value="CD"></asp:ListItem>
                            <asp:ListItem Text="CE-Export/Import warrant" Value="CE"></asp:ListItem>
                            <asp:ListItem Text="CF-Inventory and/or inspection" Value="CF"></asp:ListItem>
                            <asp:ListItem Text="CG-Electronic processing or transmission of data for customs purposes"
                                Value="CG"></asp:ListItem>
                            <asp:ListItem Text="CH-Clearance and Handling &#8212; Origin" Value="CH"></asp:ListItem>
                            <asp:ListItem Text="CI-Overtime and Other Customs Imposed Charges" Value="CI"></asp:ListItem>
                            <asp:ListItem Text="CJ-Removal (carrier warehouse to warehouse)" Value="CJ"></asp:ListItem>
                            <asp:ListItem Text="DB-Disbursement Fee" Value="DB"></asp:ListItem>
                            <asp:ListItem Text="DC-Certificate of Origin" Value="DC"></asp:ListItem>
                            <asp:ListItem Text="DD-Preparation of Cargo manifest" Value="DD"></asp:ListItem>
                            <asp:ListItem Text="DF-Distribution Service Fee" Value="DF"></asp:ListItem>
                            <asp:ListItem Text="DG-AWB Cancellation" Value="DG"></asp:ListItem>
                            <asp:ListItem Text="DH-AWB Charges Correction Advice" Value="DH"></asp:ListItem>
                            <asp:ListItem Text="DI-AWB Re-waybilling" Value="DI"></asp:ListItem>
                            <asp:ListItem Text="DJ-Proof of delivery (documentation)" Value="DJ"></asp:ListItem>
                            <asp:ListItem Text="DK-Release order" Value="DK"></asp:ListItem>
                            <asp:ListItem Text="DV-Veterinary and/or Phytosanitary purposes" Value="DV"></asp:ListItem>
                            <asp:ListItem Text="EA-Handling (Express)" Value="EA"></asp:ListItem>
                            <asp:ListItem Text="FA-Airport arrival" Value="FA"></asp:ListItem>
                            <asp:ListItem Text="FB-Domestic shipments" Value="FB"></asp:ListItem>
                            <asp:ListItem Text="FC-Charges Collect Fee" Value="FC"></asp:ListItem>
                            <asp:ListItem Text="FD-Priority" Value="FD"></asp:ListItem>
                            <asp:ListItem Text="FE-General (Handling)" Value="FE"></asp:ListItem>
                            <asp:ListItem Text="FF-Loading/unloading" Value="FF"></asp:ListItem>
                            <asp:ListItem Text="FI-Weighing" Value="FI"></asp:ListItem>
                            <asp:ListItem Text="GA-Diplomatic consignment" Value="GA"></asp:ListItem>
                            <asp:ListItem Text="GT-Government Tax" Value="GT"></asp:ListItem>
                            <asp:ListItem Text="HB-Mortuary" Value="HB"></asp:ListItem>
                            <asp:ListItem Text="HR-Human Remains" Value="HR"></asp:ListItem>
                            <asp:ListItem Text="IA-Very important cargo (VIC)" Value="IA"></asp:ListItem>
                            <asp:ListItem Text="IN-Insurance Premium" Value="IN"></asp:ListItem>
                            <asp:ListItem Text="JA-Clearance, General" Value="JA"></asp:ListItem>
                            <asp:ListItem Text="KA-Handling (Heavy/Bulky cargo)" Value="KA"></asp:ListItem>
                            <asp:ListItem Text="KB-Loading/unloading equipment (forklift etc.)" Value="KB"></asp:ListItem>
                            <asp:ListItem Text="LA-Live Animals" Value="LA"></asp:ListItem>
                            <asp:ListItem Text="LC-Cleaning" Value="LC"></asp:ListItem>
                            <asp:ListItem Text="LE-Hotel" Value="LE"></asp:ListItem>
                            <asp:ListItem Text="LF-Quarantine" Value="LF"></asp:ListItem>
                            <asp:ListItem Text="LG-Veterinary inspection" Value="LG"></asp:ListItem>
                            <asp:ListItem Text="LH-Storage (Live animals)" Value="LH"></asp:ListItem>
                            <asp:ListItem Text="LI-Cleaning of stalls/pens" Value="LI"></asp:ListItem>
                            <asp:ListItem Text="LJ-Rental of Stalls/pens" Value="LJ"></asp:ListItem>
                            <asp:ListItem Text="MA-Miscellaneous &#8212; Due Agent" Value="MA"></asp:ListItem>
                            <asp:ListItem Text="MB-Miscellaneous &#8212; Unassigned" Value="MB"></asp:ListItem>
                            <asp:ListItem Text="MC-Miscellaneous &#8212; Due Carrier" Value="MC"></asp:ListItem>
                            <asp:ListItem Text="MD-Miscellaneous - Due Last Carrier" Value="MD"></asp:ListItem>
                            <asp:ListItem Text="MO-Miscellaneous - Due Issuing Carrier" Value="MO"></asp:ListItem>
                            <asp:ListItem Text="MY-Fuel Surcharge &#8212; Due Issuing Carrier" Value="MY"></asp:ListItem>
                            <asp:ListItem Text="MZ-Miscellaneous &#8212; Due Issuing Carrier" Value="MZ"></asp:ListItem>
                            <asp:ListItem Text="NS-Navigation Surcharge &#8212; Due Issuing Carrier" Value="NS"></asp:ListItem>
                            <asp:ListItem Text="PA-Handling (Perishables)" Value="PA"></asp:ListItem>
                            <asp:ListItem Text="PB-Cool/Cold room, freezer (Perishables)" Value="PB"></asp:ListItem>
                            <asp:ListItem Text="PK-Packing/Repacking" Value="PK"></asp:ListItem>
                            <asp:ListItem Text="PU-Pick-Up" Value="PU"></asp:ListItem>
                            <asp:ListItem Text="RA-Dangerous Goods Fee" Value="RA"></asp:ListItem>
                            <asp:ListItem Text="RB-Rejection" Value="RB"></asp:ListItem>
                            <asp:ListItem Text="RC-Referral of Charge" Value="RC"></asp:ListItem>
                            <asp:ListItem Text="RD-Radio-active room" Value="RD"></asp:ListItem>
                            <asp:ListItem Text="RF-Remit Following Collection Fee" Value="RF"></asp:ListItem>
                            <asp:ListItem Text="SA-Delivery" Value="SA"></asp:ListItem>
                            <asp:ListItem Text="SB-Delivery notification" Value="SB"></asp:ListItem>
                            <asp:ListItem Text="SC-Security Charge" Value="SC"></asp:ListItem>
                            <asp:ListItem Text="SD-Surface Charge &#8212; Destination" Value="SD"></asp:ListItem>
                            <asp:ListItem Text="SE-Proof of delivery (pickup and delivery)" Value="SE"></asp:ListItem>
                            <asp:ListItem Text="SF-Delivery Order" Value="SF"></asp:ListItem>
                            <asp:ListItem Text="SI-Stop in Transit" Value="SI"></asp:ListItem>
                            <asp:ListItem Text="SO-Storage &#8212; Origin" Value="SO"></asp:ListItem>
                            <asp:ListItem Text="SP-Separate Early Release" Value="SP"></asp:ListItem>
                            <asp:ListItem Text="SR-Storage &#8212; Destination" Value="SR"></asp:ListItem>
                            <asp:ListItem Text="SS-Signature Service" Value="SS"></asp:ListItem>
                            <asp:ListItem Text="ST-State Sales Tax" Value="ST"></asp:ListItem>
                            <asp:ListItem Text="SU-Surface Charge &#8212; Origin" Value="SU"></asp:ListItem>
                            <asp:ListItem Text="TA-Postal Tax" Value="TA"></asp:ListItem>
                            <asp:ListItem Text="TB-Sales Tax" Value="TB"></asp:ListItem>
                            <asp:ListItem Text="TC-Stamp Tax" Value="TC"></asp:ListItem>
                            <asp:ListItem Text="TD-State Tax" Value="TD"></asp:ListItem>
                            <asp:ListItem Text="TE-Statistical Tax" Value="TE"></asp:ListItem>
                            <asp:ListItem Text="TI-Value Added Tax (For Import only)" Value="TI"></asp:ListItem>
                            <asp:ListItem Text="TR-Transit" Value="TR"></asp:ListItem>
                            <asp:ListItem Text="TV-Value Added Tax (General or for Export)" Value="TV"></asp:ListItem>
                            <asp:ListItem Text="TX-General Taxes" Value="TX"></asp:ListItem>
                            <asp:ListItem Text="UB-Disassembly" Value="UB"></asp:ListItem>
                            <asp:ListItem Text="UC-Adjusting of improperly loaded ULD" Value="UC"></asp:ListItem>
                            <asp:ListItem Text="UD-Demurrage" Value="UD"></asp:ListItem>
                            <asp:ListItem Text="UE-Leasing" Value="UE"></asp:ListItem>
                            <asp:ListItem Text="UF-Recontouring" Value="UF"></asp:ListItem>
                            <asp:ListItem Text="UG-Unloading (Unit Load Device)" Value="UG"></asp:ListItem>
                            <asp:ListItem Text="UH-Handling (Unit Load Device)" Value="UH"></asp:ListItem>
                            <asp:ListItem Text="VA-Handling (Valuable Cargo)" Value="VA"></asp:ListItem>
                            <asp:ListItem Text="VB-Security (armed guard/escort) handling" Value="VB"></asp:ListItem>
                            <asp:ListItem Text="VC-Strongroom" Value="VC"></asp:ListItem>
                            <asp:ListItem Text="WA-Handling (Vulnerable cargo)" Value="WA"></asp:ListItem>
                            <asp:ListItem Text="XB-Security (Surcharge/premiums)" Value="XB"></asp:ListItem>
                            <asp:ListItem Text="XC-Time" Value="XC"></asp:ListItem>
                            <asp:ListItem Text="XD-War risk" Value="XD"></asp:ListItem>
                            <asp:ListItem Text="XE-Weight" Value="XE"></asp:ListItem>
                            <asp:ListItem Text="ZA-Re-warhousing" Value="ZA"></asp:ListItem>
                            <asp:ListItem Text="ZB-General(Storage)" Value="ZB"></asp:ListItem>
                            <asp:ListItem Text="ZC-Cool/Cold room freezer(Storage)" Value="ZC"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>


               </div> 
            <%-- -------------------------------------Tab--------------------------------------------------------%>


         <div class="content" id="page-1" style="margin-top:-28px;width:1194px;">
                        
          <div id="innerbox_MidMain_Trans_new" style="height:300px; width:1050px; margin-left:-16px; margin-top:-15px;">
                <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span>General </span></a></li>

                     <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" visible="false"
                        id="Page_C" runat="server" ><span>Other </span></a></li>

                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" visible="true" id="Page_B" runat="server">
                        <span>Accounts</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        <span> Gen -4 </span></a></li>

                        
                </ol>
                  <%----------------------------General---------------------------------------------------%>
                    <div   class="content" id="page-6" style="height:492px;" >

                    <%--------------------------------------------------------------------------------------------%>
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:508px;margin-top: -16px; margin-left:-18px; color:Red;width: 1185px;">
                        <div id="tag_transact_src_inner" style="width: 1185px;height:508px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1185px;height:508px;color:#333333;">
                  

                        
                      
           <div id="applicable_tax_wrapper" style="margin-top:10px;">
        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="float:left; width:100px;  font-size:12px;   margin-left:5px; padding-top:8px;">
            Applicable Tax
        </div>

        <div id="applicable_tax_table" style="float:left; width:920px;">

            <div id="applicable_tax_header_row" style="width:100%; overflow:hidden; background-color:#f5c97a; border:1px solid #b0b0b0;height:20px;">

                <div id="applicable_tax_hdr_tax" style="float:left; width:100px; text-align:center; font-size:12px; font-weight:bold; font-family:Arial; padding:6px 2px; border-right:1px solid #b0b0b0;">
                    Tax
                </div>
                <div id="applicable_tax_hdr_chk" style="float:left; width:25px; border-right:1px solid #b0b0b0; padding:4px 2px;">
                    &nbsp;
                </div>
                <div id="applicable_tax_hdr_cat" style="float:left; width:500px; text-align:center; font-size:12px; font-weight:bold; font-family:Arial; padding:6px 2px; border-right:1px solid #b0b0b0;">
                    Category
                </div>
                <div id="applicable_tax_hdr_taxable" style="float:left; width:100px; text-align:center; font-size:12px; font-weight:bold; font-family:Arial; padding:6px 2px; border-right:1px solid #b0b0b0;">
                    Taxable
                </div>
                <div id="applicable_tax_hdr_override" style="float:left; width:100px; text-align:center; font-size:12px; font-weight:bold; font-family:Arial; padding:4px 0;">
                    &nbsp;
                </div>

            </div>

            <div id="applicable_tax_row_1" style="width: 100%; overflow: hidden; background-color: #ffffff;
                border-left: 1px solid #b0b0b0; border-right: 1px solid #b0b0b0; border-bottom: 1px solid #b0b0b0;
                height: 30px;">
                <div id="applicable_tax_r1_tax" style="float: left; width: 100px; font-size: 12px;
                    font-family: Arial; padding: 9px 2px; min-height: 28px; border-right: 1px solid #b0b0b0;">
                    Service Tax
                </div>
                <div id="applicable_tax_r1_chk" style="float: left; width: 25px; text-align: center;
                    padding: 6px 2px; min-height: 33px; border-right: 1px solid #b0b0b0;">
                    <asp:CheckBox ID="chkServiceTax" runat="server" TabIndex="50" />
                </div>
                <div id="applicable_tax_r1_cat" style="float: left; width: 500px; padding: 7px 2px;
                    border-right: 1px solid #b0b0b0; min-height: 32px;">
                    <asp:DropDownList ID="ddl_ServiceTax_Category" runat="server" Width="420px" CssClass="listtxt_transac_item_gen_notn"
                        TabIndex="51" ForeColor="Green">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="applicable_tax_r1_taxable" style="float: left; width: 100px; padding: 6px 2px;
                    border-right: 1px solid #b0b0b0; min-height: 34px;">
                </div>
                <div id="applicable_tax_r1_override" style="float: left; width: 100px; padding: 4px 2px;">
                    &nbsp;
                </div>
            </div>

            <div id="applicable_tax_row_2" style="width:100%; overflow:hidden; background-color:#ffffff; border-left:1px solid #b0b0b0; border-right:1px solid #b0b0b0; border-bottom:1px solid #b0b0b0;height:30px; ">

                <div id="applicable_tax_r2_tax" style="float:left; width:100px; font-size:12px; font-family:Arial;padding:7px 2px; min-height:28px; border-right:1px solid #b0b0b0;">
                    Value Added Tax
                </div>
                <div id="applicable_tax_r2_chk" style="float:left; width:25px; text-align:center; padding:5px 2px; min-height:31px; border-right:1px solid #b0b0b0;">
                    <asp:CheckBox ID="chkVAT" runat="server" TabIndex="53" />
                </div>
                <div id="applicable_tax_r2_cat" style="float:left; width:500px; padding:5px 2px; border-right:1px solid #b0b0b0; min-height:31px;">
                    <asp:DropDownList ID="ddl_VAT_Category" runat="server" Width="420px"
                        CssClass="listtxt_transac_item_gen_notn" TabIndex="54" ForeColor="Green">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="applicable_tax_r2_taxable" style="float:left; width:100px; padding:5px 2px; border-right:1px solid #b0b0b0; min-height:31px; ">
                </div>
                <div id="applicable_tax_r2_override" style="float:left; width:100px; padding:4px 2px; ">
                    &nbsp;
                </div>

            </div>

            <div id="applicable_tax_row_3" style="width: 100%; overflow: hidden; background-color: #ffffff;
                border-left: 1px solid #b0b0b0; border-right: 1px solid #b0b0b0; border-bottom: 1px solid #b0b0b0;
                height: 30px;">
                <div id="applicable_tax_r3_tax" style="float: left; width: 100px; font-size: 12px;
                    font-family: Arial; min-height: 30px; padding: 4px 2px; border-right: 1px solid #b0b0b0;">
                    GST
                </div>
                <div id="applicable_tax_r3_chk" style="float: left; width: 25px; text-align: center;
                    min-height: 30px; padding: 4px 2px; border-right: 1px solid #b0b0b0;">
                    <asp:CheckBox ID="chkGST" runat="server" TabIndex="56" Checked="true" />
                </div>
                <div id="applicable_tax_r3_cat" style="float: left; width: 500px; padding: 5px 2px;
                    border-right: 1px solid #b0b0b0;">
                    <div id="txtcon-m_transaction_code" style="display: inline-block; vertical-align: middle;
                        width: 300px;">
                        <asp:DropDownList ID="ddl_GST_SacHsn" runat="server" Width="60px" CssClass="listtxt_transac_item_gen_notn"
                            TabIndex="57" ForeColor="Green" Style="display: inline-block; vertical-align: middle;">
                            <asp:ListItem Text="SAC" Value="SAC"></asp:ListItem>
                            <asp:ListItem Text="HSN" Value="HSN"></asp:ListItem>
                        </asp:DropDownList>

                
                           <asp:TextBox ID="txt_HSN_SAC_Code" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"
                            Width="70px" Style="text-transform: none;" ClientIDMode="Static" TabIndex="58"></asp:TextBox>

                      <asp:TextBox ID="txt_GST_Category" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_code"
                            Width="140px" Style="text-transform: none;" ClientIDMode="Static" TabIndex="58"></asp:TextBox>

                         

                    </div>
                    <div id="magnify_area">
                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');opennewHSNSACcode('GST_CATEGORY'); return false"
                            class="magnfy"></a>
                    </div>
                    <asp:DropDownList ID="ddl_GST_SubCategory" runat="server" Width="120px" CssClass="listtxt_transac_item_gen_notn"
                        TabIndex="60" ForeColor="Green">
                        <asp:ListItem Text="Taxable" Value="T"></asp:ListItem>
                        <asp:ListItem Text="Exempt" Value="E"></asp:ListItem>
                        <asp:ListItem Text="Pure Agent Always" Value="PAA"></asp:ListItem>
                        <asp:ListItem Text="Pure Agent Optional" Value="PAO"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div id="applicable_tax_r3_taxable" style="float: left; width: 100px; padding: 5px 2px;
                    border-right: 1px solid #b0b0b0;">
                    <asp:TextBox ID="txt_GST_Taxable" runat="server" MaxLength="14" CssClass="txtbox_none_Mid_transac_code"
                        Width="80px" Onkeypress="return numchar(event)" onkeyup="ChangeCase(this);" Text="100.00"
                        onfocus="ChangeCase(this);" onblur="ChangeCase(this);" ClientIDMode="Static"
                        TabIndex="12"></asp:TextBox>
                </div>
                <div id="applicable_tax_r3_override" style="float: left; width: 100px; padding: 4px 5px;">
                    <asp:CheckBox ID="chkGST_Override" runat="server" TabIndex="62" Text="Override" />
                </div>
            </div>


        </div>

        <div style="clear:both;"></div>

    </div>

                  <%--------------------------------------Row 5-----------------------------------------%>
                       

                        
                    </div>
                 
                        </div>
                        </div>
                    </div>
                     <div   class="content" id="page-8" style="height:492px;">
                     
                     </div>

              <div class="content" id="page-7" style="height: 492px; width: 1194px;">
                  <div id="accounts_tab_wrapper" style="width: 1000px; height: 184px; font-family: Arial,sans-serif;
                      font-size: 12px; border: 1px solid #b0b0b0; overflow: hidden;">
                      <div id="gl_links_topbar" style="width: 1150px; overflow: hidden; background-color: #ffffff;
                          border-bottom: 1px solid #b0b0b0;">
                          <div style="clear: both;">
                          </div>
                      </div>
                      <div id="gl_col_header" style="width: 1150px; overflow: hidden; background-color: #f5c97a;
                          border-bottom: 1px solid #b0b0b0; height: 20px;">
                          <div style="float: left; width: 160px; font-size: 12px; font-weight: bold; font-family: Arial;
                              color: #5a3a00; padding: 5px 4px; border-right: 1px solid #d4a030;">
                              Line Of Business
                          </div>
                          <div style="float: left; width: 320px; font-size: 12px; font-weight: bold; font-family: Arial;
                              color: #5a3a00; text-align: center; padding: 5px 4px; border-right: 1px solid #d4a030;">
                              Income
                          </div>
                          <div style="float: left; width: 320px; font-size: 12px; font-weight: bold; font-family: Arial;
                              color: #5a3a00; text-align: center; padding: 5px 4px; border-right: 1px solid #d4a030;">
                              Expense
                          </div>
                          <div style="float: left; width: 165px; font-size: 12px; font-weight: bold; font-family: Arial;
                              color: #5a3a00; text-align: center; padding: 5px 4px; border-right: 1px solid #d4a030;">
                              Cost Center
                          </div>
                          <div style="clear: both;">
                          </div>
                      </div>
                      <div id="gl_row_1" style="width: 1150px; overflow: hidden; background-color: #ffffff;
                          border-bottom: 1px solid #e0e0e0;">
                          <div style="float: left; width: 160px; font-size: 12px; font-family: Arial; color: #333333;
                              padding: 4px 4px; border-right: 1px solid #e0e0e0;">
                              Vehicle-VLE (GEN)
                          </div>
                          <div style="float: left; width: 320px; padding: 3px 4px; border-right: 1px solid #e0e0e0;">
                              <div id="txtbox_none_Mid_transac_Supp_Name" style="display: inline-block; vertical-align: middle;
                                  width: 290px;">
                                  <asp:TextBox ID="txt_R1_Income" ReadOnly="true" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                      Width="270px" Style="text-transform:none; background-color:#e9e9e9; color:#888888; cursor:not-allowed; border:1px solid #c8c8c8;" TabIndex="72"></asp:TextBox>
                              </div>
                              <div id="magnify_area_r1_inc" style="display: inline-block; vertical-align: middle;
                                  margin-left: -20px;">
                                  <a href="#" class="magnfy"  style="margin-left: 10px; opacity: 0.4; pointer-events: none; onclick="jQuery('#form1').validationEngine('hideAll');opennewGLLedger(); return false">
                                  </a>
                              </div>
                          </div>
                          <div style="float: left; width: 320px; padding: 3px 4px; border-right: 1px solid #e0e0e0;">
                              <div id="txtbox_none_Mid_transac_Supp_Name" style="display: inline-block; vertical-align: middle;
                                  width: 290px;">
                                  <asp:TextBox ID="txt_R1_Expense" ReadOnly="true" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                      Width="270px" Style="text-transform:none; background-color:#e9e9e9; color:#888888; cursor:not-allowed; border:1px solid #c8c8c8;" TabIndex="77"></asp:TextBox>
                              </div>
                              <div id="magnify_area_r1_inc" style="display: inline-block; vertical-align: middle;
                                  margin-left: -20px;">
                                  <a href="#" class="magnfy" style="margin-left: 10px; opacity: 0.4; pointer-events: none; cursor: not-allowed;" onclick="jQuery('#form1').validationEngine('hideAll');opennewGLLedger(); return false">
                                  </a>

                              </div>
                          </div>
                          <div style="float: left; width: 165px; padding: 5px 4px; border-right: 1px solid #e0e0e0;">
                              <asp:DropDownList ID="ddl_R1_CostCenter" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                  Width="155px" ForeColor="Green" TabIndex="75">
                                  <asp:ListItem Text="Admin Expenses" Value="ADM"></asp:ListItem>
                                  <asp:ListItem Text="Import" Value="IMP"></asp:ListItem>
                                  <asp:ListItem Text="Export" Value="EXP"></asp:ListItem>
                              </asp:DropDownList>
                          </div>
                      </div>
                      <div id="gl_row_2" style="width: 1150px; overflow: hidden; background-color: #f9f9f9;
                          border-bottom: 1px solid #e0e0e0;">
                          <div style="float: left; width: 160px; font-size: 12px; font-family: Arial; color: #333333;
                              padding: 4px 4px; border-right: 1px solid #e0e0e0;">
                              Custom Clearing Import
                          </div>
                          <div style="float: left; width: 320px; padding: 3px 4px; border-right: 1px solid #e0e0e0;">
                              <div id="txtbox_none_Mid_transac_Supp_Name" style="display: inline-block; vertical-align: middle;
                                  width: 290px;">
                                  <asp:TextBox ID="txt_R2_Income" runat="server" Style="text-transform: none;" CssClass="txtbox_none_Mid_transac_code"
                                      Width="270px" TabIndex="76"></asp:TextBox>
                              </div>
                              <div id="magnify_area_r2_inc" style="display: inline-block; vertical-align: middle;
                                  margin-left: -20px;">
                                  <a href="#" style="margin-left: 10px;" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');opennewGLLedger('txt_R2_Income'); return false">
                                  </a>
                              </div>
                          </div>
                          <div style="float: left; width: 320px; padding: 3px 4px; border-right: 1px solid #e0e0e0;">
                              <div id="txtbox_none_Mid_transac_Supp_Name" style="display: inline-block; vertical-align: middle;
                                  width: 290px;">
                                  <asp:TextBox ID="txt_R2_Expense" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                      Width="270px" Style="text-transform: none;" TabIndex="77"></asp:TextBox>
                              </div>
                              <div id="magnify_area_r1_inc" style="display: inline-block; vertical-align: middle;
                                  margin-left: -20px;">
                                  <a href="#" class="magnfy" style="margin-left: 10px;" onclick="jQuery('#form1').validationEngine('hideAll');opennewGLLedger('txt_R2_Expense'); return false">
                                  </a>
                              </div>
                          </div>
                          <div style="float: left; width: 165px; padding: 5px 4px; border-right: 1px solid #e0e0e0;">
                              <asp:DropDownList ID="ddl_R2_CostCenter" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                  Width="155px" ForeColor="Green" TabIndex="78">
                                  <asp:ListItem Text="Import" Value="IMP"></asp:ListItem>
                                  <asp:ListItem Text="Admin Expenses" Value="ADM"></asp:ListItem>
                                  <asp:ListItem Text="Export" Value="EXP"></asp:ListItem>
                              </asp:DropDownList>
                          </div>
                      </div>
                      <div id="gl_row_3" style="width: 1150px; overflow: hidden; background-color: #ffffff;
                          border-bottom: 1px solid #e0e0e0;">
                          <div style="float: left; width: 160px; font-size: 12px; font-family: Arial; color: #333333;
                              padding: 4px 4px; border-right: 1px solid #e0e0e0;">
                              Custom Clearing Export
                          </div>
                          <div style="float: left; width: 320px; padding: 3px 4px; border-right: 1px solid #e0e0e0;">
                              <div id="txtbox_none_Mid_transac_Supp_Name" style="display: inline-block; vertical-align: middle;
                                  width: 290px;">
                                  <asp:TextBox ID="txt_R3_Income" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                      Width="270px" Style="text-transform: none;" TabIndex="79"></asp:TextBox>
                              </div>
                            
                              <div id="magnify_area_r3_inc" style="display: inline-block; vertical-align: middle;
                                  margin-left: -20px;">
                                  <a href="#" style="margin-left: 10px;" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');opennewGLLedger('txt_R3_Income'); return false">
                                  </a>
                              </div>
                          </div>
                          <div style="float: left; width: 320px; padding: 3px 4px; border-right: 1px solid #e0e0e0;">
                              <div id="txtbox_none_Mid_transac_Supp_Name" style="display: inline-block; vertical-align: middle;
                                  width: 290px;">
                                  <asp:TextBox ID="txt_R3_Expense" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                      Width="270px" Style="text-transform: none;" TabIndex="80"></asp:TextBox>
                              </div>
                              
                              <div id="magnify_area_r3_inc" style="display: inline-block; vertical-align: middle;
                                  margin-left: -20px;">
                                  <a href="#" style="margin-left: 10px;" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');opennewGLLedger('txt_R3_Expense'); return false">
                                  </a>
                              </div>
                          </div>
                          <div style="float: left; width: 165px; padding: 5px 4px; border-right: 1px solid #e0e0e0;">
                              <asp:DropDownList ID="ddl_R3_CostCenter" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                  Width="155px" ForeColor="Green" TabIndex="81">
                                  <asp:ListItem Text="Export" Value="EXP"></asp:ListItem>
                                  <asp:ListItem Text="Admin Expenses" Value="ADM"></asp:ListItem>
                                  <asp:ListItem Text="Import" Value="IMP"></asp:ListItem>
                              </asp:DropDownList>
                          </div>
                      </div>
                      <div id="gl_row_4" style="width: 1150px; overflow: hidden; background-color: #f9f9f9;
                          border-bottom: 1px solid #e0e0e0;">
                          <div style="float: left; width: 160px; font-size: 12px; font-family: Arial; color: #333333;
                              padding: 4px 4px; border-right: 1px solid #e0e0e0;">
                              Transport
                          </div>
                          <div style="float: left; width: 320px; padding: 3px 4px; border-right: 1px solid #e0e0e0;">
                              <div id="txtbox_none_Mid_transac_Supp_Name" style="display: inline-block; vertical-align: middle;
                                  width: 290px;">
                                  <asp:TextBox ID="txt_R4_Income"  ReadOnly="true" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                      Width="270px" Style="text-transform:none; background-color:#e9e9e9; color:#888888; cursor:not-allowed; border:1px solid #c8c8c8;" TabIndex="82"></asp:TextBox>
                              </div>
                              <div id="magnify_area_r4_inc" style="display: inline-block; vertical-align: middle;
                                  margin-left: -20px;">
                                  <a href="#" style="margin-left: 10px; opacity: 0.4; pointer-events: none; cursor: not-allowed;" class="magnfy" onclientclick="open_Ledger('N');">
                                  </a>
                              </div>
                          </div>
                          <div style="float: left; width: 320px; padding: 3px 4px; border-right: 1px solid #e0e0e0;">
                              <div id="txtbox_none_Mid_transac_Supp_Name" style="display: inline-block; vertical-align: middle;
                                  width: 290px;">
                                  <asp:TextBox ID="txt_R4_Expense" ReadOnly="true" runat="server" Style="text-transform:none; background-color:#e9e9e9; color:#888888; cursor:not-allowed; border:1px solid #c8c8c8;" CssClass="txtbox_none_Mid_transac_code"
                                      Width="270px" TabIndex="83"></asp:TextBox>
                              </div>
                              <div id="magnify_area_r4_inc" style="display: inline-block; vertical-align: middle;
                                  margin-left: -20px;">
                                  <a href="#" style="margin-left: 10px; opacity: 0.4; pointer-events: none; cursor: not-allowed;" class="magnfy" onclientclick="open_Ledger('N');">
                                  </a>
                              </div>
                          </div>
                          <div style="float: left; width: 165px; padding: 5px 4px; border-right: 1px solid #e0e0e0;">
                              <asp:DropDownList ID="ddl_R4_CostCenter" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                  Width="155px" ForeColor="Green" TabIndex="84">
                                  <asp:ListItem Text="" Value=""></asp:ListItem>
                                  <asp:ListItem Text="Admin Expenses" Value="ADM"></asp:ListItem>
                                  <asp:ListItem Text="Import" Value="IMP"></asp:ListItem>
                                  <asp:ListItem Text="Export" Value="EXP"></asp:ListItem>
                              </asp:DropDownList>
                          </div>
                      </div>
                      <div id="gl_row_5" class="general-row" style="width: 1150px; overflow: hidden; background-color: #ffffff;
                          border-bottom: 1px solid #e0e0e0;">
                          <div style="float: left; width: 160px; font-size: 12px; font-family: Arial; color: #333333;
                              padding: 4px 4px; border-right: 1px solid #e0e0e0;">
                              General
                          </div>
                          <div style="float: left; width: 320px; padding: 3px 4px; border-right: 1px solid #e0e0e0;">
                              <div id="txtbox_none_Mid_transac_Supp_Name" style="display: inline-block; vertical-align: middle;
                                  width: 290px;">
                                  <asp:TextBox ID="txt_R5_Income"  runat="server" Style="text-transform:none; border:1px solid #c8c8c8;" CssClass="txtbox_none_Mid_transac_code"
                                      Width="270px" TabIndex="85"></asp:TextBox>
                              </div>
                              <div id="magnify_area_r5_inc" style="display: inline-block; vertical-align: middle;
                                  margin-left: -20px;">
                                  <a href="#" style="margin-left: 10px; opacity:1;" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');opennewGLLedger('txt_R5_Income'); return false">
                                  </a>
                              </div>
                          </div>
                          <div style="float: left; width: 320px; padding: 3px 4px; border-right: 1px solid #e0e0e0;">
                              <div id="txtbox_none_Mid_transac_Supp_Name" style="display: inline-block; vertical-align: middle;
                                  width: 290px;">
                                  <asp:TextBox ID="txt_R5_Expense"  runat="server" Style="text-transform:none; border:1px solid #c8c8c8;" CssClass="txtbox_none_Mid_transac_code"
                                      Width="270px" TabIndex="86"></asp:TextBox>
                              </div>
                              <div id="magnify_area_r5_exp" style="display: inline-block; vertical-align: middle;
                                  margin-left: -20px;">
                                  <a href="#" style="margin-left: 10px;" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');opennewGLLedger('txt_R5_Expense'); return false">
                                  </a>
                              </div>
                          </div>
                          <div style="float: left; width: 165px; padding: 5px 4px; border-right: 1px solid #e0e0e0;">
                              <asp:DropDownList ID="ddl_R5_CostCenter" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                  Width="155px" ForeColor="Green" TabIndex="88">
                                  <asp:ListItem Text="Admin Expenses" Value="ADM"></asp:ListItem>
                                  <asp:ListItem Text="Import" Value="IMP"></asp:ListItem>
                                  <asp:ListItem Text="Export" Value="EXP"></asp:ListItem>
                              </asp:DropDownList>
                          </div>
                      </div>
                  </div>
              </div>
                             </div>


                  <div id="innerbox_MidMain_bot_transact"
     runat="server"
     style="height:30px; margin-top:6px;">
    <div id="innerbox_transac_bot_inn" style="width:1050px;">

        <div id="newbu">
            <asp:Button ID="btnNew" runat="server"
                CssClass="new"
                CausesValidation="false"
                UseSubmitBehavior="false"
                TabIndex="82"
                OnClick="btnNew_Click1" />
        </div>

        <div id="editbu">
            <asp:Button ID="btnSave" runat="server"
                CssClass="save"
                OnClientClick="return validate();"
                TabIndex="80"
                OnClick="btnSave_Click"
                CommandName="s" />
        </div>

        <div id="editbu">
            <asp:Button ID="btnUpdate" runat="server"
                CssClass="updates"
                OnClick="btnUpdate_Click"
                OnClientClick="return validate();"
                TabIndex="81" />
        </div>

        <div id="editbu">
            <asp:Button ID="btnDelete" runat="server"
                TabIndex="81"
                CausesValidation="false"
                UseSubmitBehavior="false"
                CssClass="dlete"
                OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this record?', 'Charge Master', function(r) {
                    var i = r + 'ok';
                    if(i == 'trueok') {
                        document.getElementById('btn').click();
                    }
                });return false;" />
            <asp:Button ID="btn" runat="server"
                TabIndex="81"
                OnClick="btnDelete_Click"
                CausesValidation="false"
                UseSubmitBehavior="false"
                OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                CssClass="dlete"
                Style="display:none;" />
        </div>

        <div id="editbu">
            <input type="submit" value="Submit"
                class="scancel"
                onclick="RefreshParent();return false;"
                id="btnCancel" tabindex="85" />
        </div>

    </div>
</div>

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

             <asp:HiddenField ID="HDupdate_id" runat="server" />
             <asp:HiddenField ID="HD_Showcon" runat="server" />
             <asp:HiddenField ID="hdfTransport_mode" runat="server" />
             <asp:HiddenField ID="hdn_HSN_SAC_chk" runat="server" ClientIDMode="Static" />
             <asp:HiddenField ID="hdn_GL_Income_chk" runat="server" ClientIDMode="Static" />

              </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Accounts/Acc_listpopup.js" type="text/javascript"></script>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/Accounts/Acc_Charge_Mas_New.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>

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
         function toggleApplicableForDropdown() {
             var div = document.getElementById('divApplicableFor');
             if (div.style.display == 'none') {
                 div.style.display = 'block';
             } else {
                 div.style.display = 'none';
             }
         }

         document.addEventListener('click', function (e) {
             var display = document.getElementById('txtApplicableFor_Display');
             var dropdown = document.getElementById('divApplicableFor');
             if (dropdown && display) {
                 if (!dropdown.contains(e.target) && e.target !== display) {
                     dropdown.style.display = 'none';
                 }
             }
         });

         function updateApplicableForDisplay() {
             var checkboxes = document.querySelectorAll(
            "[id*='chkApplicableFor'] input[type='checkbox']"
        );
             var selected = [];
             var values = [];
             for (var i = 0; i < checkboxes.length; i++) {
                 if (checkboxes[i].checked) {
                     var lbl = document.querySelector(
                    "label[for='" + checkboxes[i].id + "']"
                );
                     if (lbl) selected.push(lbl.innerText.trim());
                     values.push(checkboxes[i].value);
                 }
             }
             var display = document.getElementById('txtApplicableFor_Display');
             display.value = selected.length > 0 ? selected.join(', ') : 'Select...';

             // Use Static ClientID
             var hd = document.getElementById('hdApplicableFor');
             if (hd) hd.value = values.join(',');

             //syncAccountsTabFromApplicableFor();
             ToggleGeneralRow();
         }

         window.addEventListener('load', function () {
             updateApplicableForDisplay();
         });
</script>

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


        function ToggleGeneralRow() {

            var isGeneralSelected = false;

            var checkboxes = document.querySelectorAll("[id*='chkApplicableFor'] input[type='checkbox']");

            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked && checkboxes[i].value == "GENERAL") {
                    isGeneralSelected = true;
                    break;
                }
            }

            var income = document.getElementById("<%= txt_R5_Income.ClientID %>");
            var expense = document.getElementById("<%= txt_R5_Expense.ClientID %>");
            var cost = document.getElementById("<%= ddl_R5_CostCenter.ClientID %>");
            var incomeMagnifier = document.querySelector('#magnify_area_r5_inc');
            var expenseMagnifier = document.querySelector('#magnify_area_r5_exp');

            income.readOnly = !isGeneralSelected;
            expense.readOnly = !isGeneralSelected;
            cost.disabled = !isGeneralSelected;

            income.style.backgroundColor = isGeneralSelected ? "#ffffff" : "#e9e9e9";
            expense.style.backgroundColor = isGeneralSelected ? "#ffffff" : "#e9e9e9";

            income.style.color = isGeneralSelected ? "#000000" : "#888888";
            expense.style.color = isGeneralSelected ? "#000000" : "#888888";

            income.style.cursor = isGeneralSelected ? "auto" : "not-allowed";
            expense.style.cursor = isGeneralSelected ? "auto" : "not-allowed";
            cost.style.cursor = isGeneralSelected ? "auto" : "not-allowed";

            incomeMagnifier.style.opacity = isGeneralSelected ? "1.5" : "0.8";
            incomeMagnifier.style.pointerEvents = isGeneralSelected ? "auto" : "none";
            incomeMagnifier.style.cursor = isGeneralSelected ? "pointer" : "not-allowed";

            expenseMagnifier.style.opacity = isGeneralSelected ? "1.5" : "0.8";
            expenseMagnifier.style.pointerEvents = isGeneralSelected ? "auto" : "none";
            expenseMagnifier.style.cursor = isGeneralSelected ? "pointer" : "not-allowed";

        }

    </script>


    

    
</body>
</html>
