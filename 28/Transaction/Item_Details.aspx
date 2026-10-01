<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Item_Details.aspx.cs" Inherits="Transaction_Item_Details" MaintainScrollPositionOnPostback="true" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Item | Transaction</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />


    <script type="text/javascript">
        function checkTextAreaMaxLength_CompanyWise(textBox, e) {

            var aa = document.getElementById("hdn_companyID").value;
            //            alert(aa);
            if (aa == '223') {
                length = '500';
            }
            else if (aa == '268') {
                length = '500';
            }
            else if (aa == '441') {
                length = '500';
            }
            else if (aa == '477') {
                length = '500';
            }
            else if (aa == '495') {
                length = '500';
            }
            else if (aa == '539') {
                length = '500';
            }
            else if (aa == '747') {
                length = '500';
            }
            else if (aa == '2145') {
                length = '500';
            }
            else {
                length = '120';
            } 

            var paste = (event.clipboardData || window.clipboardData).getData('text');
            var regex = /^[\x00-\x7F]+$/;
            if (!regex.test(paste)) {
                event.preventDefault();
                alert('Check the Spl Character');
            }

            var mLen = textBox["MaxLength"];
            if (null == mLen)
                mLen = length;

            var maxLength = parseInt(mLen);
            if (!checkSpecialKeys(e)) {
                if (textBox.value.length > maxLength - 1) {
                    if (window.event)//IE
                    {
                        e.returnValue = false;
                        return false;
                    }
                    else//Firefox
                        e.preventDefault();
                }
            }
        }
    </script>

     <script type="text/javascript">

         function HideModalPopup() {
             $find("MPEU").hide();
             return false;
         }

         function License() {

             document.getElementById("page-1").style.display = 'none';
             document.getElementById("page-2").style.display = 'none';
             document.getElementById("page-3").style.display = 'none';
             document.getElementById("page-4").style.display = 'none';
             document.getElementById("page-5").style.display = 'none';
             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'Block';
             //document.getElementById("page-8").style.display = 'none';

             document.getElementById("page-9").style.display = 'none';
             document.getElementById("page-10").style.display = 'none';
             document.getElementById("page-11").style.display = 'none';
             document.getElementById("page-12").style.display = 'none';

             document.getElementById("innerbox_MidMain_bot_transact_invoice").style.display = 'none';
             document.getElementById("Trans_product_licence_iframe").src = "../Transaction/License_Details.aspx";

             document.getElementById("ItemMain").className = 'inactive';
             document.getElementById("LICENCE").className = ' active';
         }

       </script>



    <style type="text/css">
        
         .modalBackground
    {
        background-color: Black;
        filter: alpha(opacity=90);
        opacity: 0.8;
    }
    .modalPopup
    {
        background-color: #FFFFFF;
        border-width: 3px;
        border-style: solid;
        border-color: black;
        padding-top: 10px;
        padding-left: 10px;
        width: 300px;
        height: 140px;
    }
        .hideGridColumn
        {
            display: none;
        }
        
        .hideGridColumn1
        {
            display: none;
        }
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        
      .grid-view tr.header
            {
                border: solid 1px Black;               
             }
             .grid-view header th
            {
                border: solid 1px Black;
                
             }
              .grid-view header td
            {
                 border-left: #9C9C9C solid thin;               
            }
            
            .txtbox_none_Mid_transac_export_Marks_nos_gen_CCR{
border:none;
color:#2b2b2b;
font-family:Arial,Helvetica,sans-serif;
font-size:14px;
margin-top:1px;
width:520px;
max-width:530px;
height:134px;
max-height:144px;
border: #c8c8c8 solid thin;
 -moz-border-radius-topleft: 5px;
 -moz-border-radius-topright: 5px;
 -moz-border-radius-bottomleft: 5px;
 -moz-border-radius-bottomright: 5px;
  -webkit-border-top-left-radius: 5px;
 -webkit-border-top-right-radius: 5px;
 -webkit-border-bottom-left-radius: 5px;
 -webkit-border-bottom-right-radius: 5px;
	border-top-left-radius: 5px;
	border-top-right-radius: 5px;
	border-bottom-left-radius: 5px;
	border-bottom-right-radius: 5px;
	overflow:auto;

}
          
    </style>
     
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_Item.js" type="text/javascript"></script>

     <script src="../js/Import_Jscript/Import_Item_GST.js" type="text/javascript"></script>

  <script type="text/javascript">
      function DisableSpecialKeyEvents() {

          var nav = window.Event ? true : false;

          document.onkeydown = Keypress_Event;

          function Keypress_Event() {

              if (event.keyCode == 13)
              { return false; }
          }
      }      
  </script>

  <script type="text/javascript">

      function HideModalPopup() {
          $find("MPEU").hide();
          return false;
      }

      function HideModalPopup_U() {
          $('#txtItem_UnitPrice').focus();
          $find("MP_U").hide();
          return false;
      }
</script>
<script type="text/javascript">

    function pageLoad(sender, eventargs) {
        $('#btnYes').focus();
        return false;
    }
</script>

<script type="text/javascript">

    function HideModalPopup_Job() {

        $find("MP_JOB").hide();
        return false;
    }
</script>

    <script type="text/javascript">
        $(document).ready(function () {
            BindControls();
            BindControls_SIA();
            BindControls_TTA();
            BindControls_CusFlag();
            //        BindControls_RSP_Notn();
        });

        function BindControls() {
            var Notn = ['009/2006'];

            $('#txt_Addl_SHE11_NOTN').autocomplete({
                source: Notn,
                minLength: 0,
                scroll: true
            }).focus(function () {
                $(this).autocomplete("search", "");
            });
        }

        function BindControls_SIA() {
            var Notn_SIA = ['011/2006'];

            $('#txt_Addl_GSI_NOTN').autocomplete({
                source: Notn_SIA,
                minLength: 0,
                scroll: true
            }).focus(function () {
                $(this).autocomplete("search", "");
            });
        }

        function BindControls_TTA() {
            var Notn_TTA = ['031/2004'];


            $('#txt_Addl_TTA_NOTN').autocomplete({
                source: Notn_TTA,
                minLength: 0,
                scroll: true
            }).focus(function () {
                $(this).autocomplete("search", "");
            });
        }

        function BindControls_CusFlag() {
            var Notn = ['C'];

            $('#txt_Cus_not_exe_Cen_flag').autocomplete({
                source: Notn,
                minLength: 0,
                scroll: true
            }).focus(function () {
                $(this).autocomplete("search", "");
            });
        }

        function BindControls_RSP_Notn() {
            var aa = document.getElementById("txtCETH_No").value;
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
    <script type="text/javascript">
        function CheckCharCounter(textBox, maxLength) {
            var charCount = maxLength - textBox.value.length;
            $('#lblcnt').val(textBox.value.length);
            if (charCount >= 0) {
                document.getElementById("txtDescription").style.color = "black";
                $('#lblcnt').attr('style', 'width:20px;border-style: none;background-color:white;color:black');
            }
            else {
                document.getElementById("txtDescription").style.color = "red";
                $('#lblcnt').attr('style', 'width:20px;border-style: none;background-color:white;color:red');
            }
        }
</script>

</head>
<body bgcolor="#FFFFFF">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
                 <div id="open_item" runat="server">
            <div id="innerbox_MidMain_Trans_Item_Main" style="height:365px; margin-top:0px;">
                <ol id="toc" style="width:745px">
               <li  style=" height:15px;" ><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page1('0');gridviewScroll();"
                        id="ItemMain"><span>Item Main</span></a></li>
                    <li  style=" height:15px;"><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page22('0');"
                        id="General"><span>General</span></a></li>
                    <li  style=" height:15px;"><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page3('0');"
                        id="CTH"><span>CTH</span></a></li>
                    <li  style=" height:15px;"><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page4('0');"
                        id="CETH"><span>CETH</span></a></li>
                         <li  style=" height:15px;"><a href="#page-11" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page11('0');"
                        id="IGST"><span>IGST</span></a></li>

                    <li  style=" height:15px;"><a href="#page-5" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page5('0');"
                        id="Other_Duty"><span>ADD</span></a></li>

                    <li  style=" height:15px;"><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll'); tab_page8('0');"
                        id="SVB_details" ><span>Item SVB</span></a></li>

                    <li  style=" height:15px;"><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll'); tab_Reimport('0');"
                        id="RE_IMPORT" runat="server" visible="false"><span>Re-Import</span></a></li>
                    <li  style=" height:15px;"><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll'); tab_License('0');"
                        id="LICENCE" runat="server" visible="false"><span>Licence</span></a></li>

                   <li style=" height:15px;"><a href="#page-10" onclick="jQuery('#form1').validationEngine('hideAll'); tab_Declaration('0');"
                        id="Declaration" runat="server" ><span> Decl.</span></a></li>
                   <li style=" height:15px;"><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SINGLE_WINDOW('0');"
                        id="SINGLE_WINDOW" runat="server" ><span> S/W</span></a></li>
                   <li style=" height:15px;"><a href="#page-12" onclick="jQuery('#form1').validationEngine('hideAll'); tab_SUPPORTING_DOCS('0');"
                        id="SUP_DOCS" runat="server" ><span> Sup Doc
                        </span></a></li>
                   
                </ol>
                <div class="content" id="page-1" style="height:360px;">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Item">
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_Item" style="width:730px"; >

                            <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1" style="width:605px";> <%--style="width:730px";--%>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width:35px";>
                                    Item
                                    </div>
                                           
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width:55px";>
                                      <asp:Label ID="lbl_Item_Slno_Dis" runat="server" ForeColor="Brown"></asp:Label>  
                                      <asp:TextBox ID="txt_ItemSlno" runat="server" CssClass="validate[required,custom[number] txtbox_none_Mid_transac_Supp_Name" Width="50px" TabIndex="1"></asp:TextBox> 
                                      </div> 
                                      <%--<div id="tag_label_transaction_popup_IGM_invoice_det2" style="width:20px";>
                                       
                                            </div>--%>
                                <div id="tag_label_transaction_export_Item_otherdet_new2">
                                    <%--<asp:TextBox ID="txtDescription" runat="server" MaxLength="120" onblur="updateTextbox()" onkeypress="DisableSpecialKeyEvents(); checkTextAreaMaxLength(this,event,'120');"
                                        onchange="updateTextbox()" onkeyup="updateTextbox" TextMode="MultiLine" onkeyDown="return (event.keyCode!=13);" 
                                        onpaste="return checkTextAreaMaxLength(this,event,'120');" CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                        TabIndex="1" ClientIDMode="Static"></asp:TextBox> onkeyup="updateTextbox"--%>
                                       
                                         <asp:TextBox ID="txtDescription" runat="server"  TextMode="MultiLine" TabIndex="1" ClientIDMode="Static"  CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                         onkeyup="CheckCharCounter(this, 120)"
                                         onblur="updateTextbox();CheckCharCounter(this, 120);" 
                                         onkeypress="DisableSpecialKeyEvents(); checkTextAreaMaxLength_CompanyWise(this,event);CheckCharCounter(this, 120);"
                                         onchange="updateTextbox();CheckCharCounter(this, 120);"  
                                         onkeyDown="return (event.keyCode!=13);CheckCharCounter(this, 120);" 
                                         onpaste="return checkTextAreaMaxLength_CompanyWise(this,event);CheckCharCounter(this, 120);" 
                                          oninput="this.value = this.value.toUpperCase();"
                                         ></asp:TextBox>

                                </div>
                            </div>
                           
                          
                          <div id="magnify_area">
                          <a href="#" onClick="jQuery('#form1').validationEngine('hideAll');OpenPopupProduct_Imp_Exp_Master('IMP_ITEM'); return false"  class="magnfy"></a>
                          </div>
                           
                         <span runat="server" id="Fairmax_125" visible="false">   <div id="magnify_area" >
                           <a href="#" onClick="jQuery('#form1').validationEngine('hideAll');OpenPopupProduct_Imp_Exp_Master_Fairmax('IMP_ITEM'); return false"  class="magnfy"></a>
                           </div>
                          </span>

                           <div id="magnify_area" style="width:118px;">
                           <%--<a href="#" onClick="jQuery('#form1').validationEngine('hideAll');OpenPopupProduct_Imp_Desc_Search_PartyWise('IMP_ITEM'); return false"  class="magnfy"></a>--%>
                           <%--<span id="Span1" title="IGM Tracking"  runat="server"  onClick="jQuery('#form1').validationEngine('hideAll');OpenPopupProduct_Imp_Desc_Search_PartyWise('IMP_ITEM'); return false"
                                        style="color:Blue;text-decoration:underline;cursor:hand; font-size:smaller;">Item Search </span>--%>

                            <asp:TextBox ID="lblcnt" BorderStyle="None" BackColor="White" Width="15px" Enabled="false" runat="server"></asp:TextBox>
                            <asp:Button ID="btn_ItemSearch" Text="Item Search" CssClass="autowidupdatebut" runat="server" UseSubmitBehavior="false" 
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');OpenPopupProduct_Imp_Desc_Search_PartyWise('IMP_ITEM'); return false"/>
                      
                           </div>                       
                                                    
                           
                        </div>
                        <div id="tag_transac_lft_trans_item_maindet_in1_" style="width:740px">
                            <div id="tag_label_transaction_export_Item_otherdet_new1" style="width:90px";>
                                Item Qty
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width:90px";>
                                <asp:TextBox ID="txtItemQty" MaxLength="17" runat="server" onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtItemQty');return Clear_Dot(this);copy_ItemQTy_Textbox();"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);copy_ItemQTy_Textbox();"
                                    onkeypress="return blockNonNumbers(this, event, true, false);copy_ItemQTy_Textbox();"
                                    CssClass="validate[required,custom[number] txtbox_none_Mid_transac_Supp_Name" autocomplete="off"
                                    onchange="copy_ItemQTy_Textbox()" onfocus="copy_ItemQTy_Textbox();" Width="85px" TabIndex="2"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:95px";>
                                <asp:TextBox ID="txtQtyCode" MaxLength="3" Onkeypress="return char1(event)" runat="server"
                                    CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_item_maindet"
                                    onkeyup="return ChangeCase(this);" ClientIDMode="Static" Width="90px" TabIndex="3"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_Exchange">
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('ITEM_QTY'); return false"
                                    class="magnfy"></a>
                            </div>
                           
                            <div id="tag_label_transaction_popup_Item_maindet" style="width:90px";>
                                 Unit Price
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width:70px";>
                                <asp:TextBox ID="txtItem_UnitPrice" runat="server" MaxLength="17" CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_Supp_Name"
                                   onblur="extractNumber(this,6,false);remove_zero_after_decimal_point(this.value,'txtItem_UnitPrice');return Clear_Dot(this);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" autocomplete="off" Width="60px"
                                     TabIndex="4"></asp:TextBox> 
                            </div>
                           <%-- <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>--%>
                            <div id="txtcon-m_transaction_item_CTH_small" style="width:80px";>
                                <asp:TextBox ID="txtItem_UnitPriceCode" runat="server" MaxLength="3" ReadOnly="true"
                                    ClientIDMode="Static" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_item_CTH_small"
                                    Onkeypress="return char1(event)" TabIndex="5" onkeyup="return ChangeCase(this);" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_Item_maindet" style="width:60px";>
                                 FOC Item
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:DropDownList ID="ddlFocItem" runat="server" ClientIDMode="Static" CssClass="listtxt_transac_mode_new"
                                    TabIndex="6" Width="70px">
                                    <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="magnify_area">
                                <%--<a href="#" onClick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('ITEM_UNITCODE'); return false"  class="magnfy"></a>--%></div>
                        </div>
                        <div id="tag_transac_lft_trans_item_maindet_in1_" style="width:700px">
                            <div id="tag_label_transaction_export_Item_otherdet_new1" style="width:90px";>
                                Item Amount
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtItem_Amount" MaxLength="15" runat="server" CssClass="validate[required,custom[number] txtbox_none_Mid_transac_item_maindet"
                                    onblur="extractNumber(this,6,false);return Clear_Dot(this);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" autocomplete="off"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="7"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtItem_AmountCode" MaxLength="3" runat="server" ReadOnly="true"
                                    Onkeypress="return char1(event)" CssClass="validate[required,minSize[3],custom[onlyLetterSp]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="8" onkeyup="return ChangeCase(this);"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <%--<a href="#" onClick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('ITEM_AMOUNTCODE'); return falsee"  class="magnfy"></a>--%>
                                </div>
                            <div id="tag_label_transaction_popup_Item_maindet">
                                RITC No
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtCTH_No" runat="server" MaxLength="8"
                                    ClientIDMode="Static" class="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_item_maindet"
                                    Onkeypress="return num1(event)" TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCTH('ItemCTHNO'); return false"
                                    class="magnfy"></a>
                            </div>
                           <div id="magnify_area">
                                 <asp:ImageButton ID="btn_Customs" Height="26px" Width="30px" ToolTip="FTA & ADD Notn Details" ImageUrl="~/images/fta6.jpg" runat="server"
                   OnClientClick="Imp_RITC_FTA_SAPTA_DutyCalc();return false;"  />
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty"></div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:180px">
                            <asp:Label ID="lbl_RITC_SW_Code" runat="server" ></asp:Label>
                            </div>

                        </div>
                          <div id="tag_transac_lft_trans_item_maindet_in1_" style="width:700px; height:21px;">

                             <div id="tag_label_transaction_export_Item_otherdet_new1" style="width: 90px;">
                                 Info MSR
                             </div>
                             <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 85px;">
                                     <asp:TextBox ID="txt_Info_Msr" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                    TabIndex="10" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="28"  Width="70px"></asp:TextBox>
                             </div>
                             <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 75px;">
                                 Info UQC
                             </div>
                             <div id="txtcon-m_transaction_item_maindet">
                                 <asp:TextBox ID="txt_Info_Uqc" runat="server" CssClass="validate[minSize[3],custom[onlyLetterSp] txtbox_none_Mid_transac_item_maindet"
                                     ClientIDMode="Static" Onkeypress="return char1(event)" onkeyup="return ChangeCase(this);" Enabled="false"
                                     TabIndex="11" MaxLength="3"></asp:TextBox>
                             </div>
                             <div id="tag_label_transaction_popup_IGM2_empty"></div>
                             <div id="txtcon-m_transaction_item_CTH_small"  style="width: 155px;">
                             <asp:Label ID="lbl_Restricted" runat="server"></asp:Label>
                            </div>
                            <div id="div_AmendmentType"  Visible="false" runat="server"  style="margin-top:5px">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 85px; font-weight: bold;">
                                Amend Type
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
                            <div id="editbu" style="margin-top:-5px;">
                                            <asp:Button ID="btn_Amend_FF" Text="Flatfile" CssClass="autowidmovebut" runat="server"
                                                OnClientClick="Open_Amend_Flatfile(); return false" Width="60px" />
                                        </div>
                            </div>
                         </div>
                      
                        <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow:hidden; height:204px;" >

                          <asp:GridView ID="gv_ItemDetails" runat="server"  AllowSorting="True" EmptyDataText="No Record Found"                   
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8"  BorderStyle="none"
                                BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" DataKeyNames="ITEM_ID,ITEM_SLNO"
                                 AllowPaging="false" HorizontalAlign="Left" 
                                OnRowCommand="gv_ItemDetails_RowDataCommand"  OnPageIndexChanging="gv_ItemDetails_PageIndexChanging"
                                OnRowCreated="gv_ItemDetails_RowCreated" OnRowDataBound="gv_ItemDetails_RowDataBound"
                                OnSelectedIndexChanged="gv_ItemDetails_SelectedIndexChanged" ShowHeaderWhenEmpty="True" 
                                Width="100%"   >

                                
                                <AlternatingRowStyle   BorderColor="#5E5E5E" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                    <SelectedRowStyle Font-Bold="true"  />
                              <Columns>
                                  <asp:CommandField ShowSelectButton="True">
                                      <HeaderStyle CssClass="hideGridColumn" />
                                      <ItemStyle CssClass="hideGridColumn" />
                                  </asp:CommandField>
                                  <asp:TemplateField HeaderText="S.No" HeaderStyle-Width="44px">
                                      <ItemTemplate>
                                          <asp:Label ID="lblitemslno" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle HorizontalAlign="Center" Width="44px" />
                                  </asp:TemplateField>
                                  <asp:BoundField DataField="ITEM_ID" HeaderText="S.No">
                                      <HeaderStyle CssClass="hideGridColumn" />
                                      <ItemStyle CssClass="hideGridColumn" />
                                  </asp:BoundField>
                                   <asp:BoundField DataField="ITEM_SLNO" HeaderText="ItemSl" HeaderStyle-Width="41px">
                                    <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="41px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="Description" HeaderStyle-Width="281px">
                                      <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="281px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="ITEM_QTY" HeaderText="Quantity" HeaderStyle-Width="85px">
                                      <ItemStyle CssClass="column_style_left1_new" Width="85px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="ITEM_QTY_CODE" HeaderText="Unit" HeaderStyle-Width="27px">
                                      <ItemStyle CssClass="column_style_left_border_3_new" Width="27px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="ITEM_UNIT_PRICE" HeaderText="Unit Price" HeaderStyle-Width="83px">
                                      <ItemStyle CssClass="column_style_left1_new" Width="83px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="ITEM_TOTAL_AMOUNT" HeaderText="Amount" HeaderStyle-Width="62px">
                                      <ItemStyle CssClass="column_style_left1_new" HorizontalAlign="Left" Width="62px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="CTH_NO" HeaderText="CTHNo" HeaderStyle-Width="60px">
                                      <ItemStyle CssClass="column_style_right_new" Width="60px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="SUB_SCHEME_CODE" HeaderText="Scheme" HeaderStyle-Width="50px">
                                      <ItemStyle CssClass="column_style_left_border_4_new" HorizontalAlign="Left" Width="50px" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="ITEM_DESCRIPTION">
                                      <HeaderStyle CssClass="hideGridColumn" />
                                      <ItemStyle CssClass="hideGridColumn" />
                                  </asp:BoundField>
                                  <asp:BoundField DataField="SCHEME_CODE">
                                      <HeaderStyle CssClass="hideGridColumn" />
                                      <ItemStyle CssClass="hideGridColumn" />
                                  </asp:BoundField>
                                    <asp:BoundField DataField="FOC_ITEM" HeaderText="Foc" HeaderStyle-Width="50px">
                                      <ItemStyle CssClass="column_style_left_border_4_new" HorizontalAlign="Left" Width="50px" />
                                  </asp:BoundField>
                                  <%--<asp:TemplateField HeaderText="Foc" HeaderStyle-Width="40px">
                                      <ItemTemplate>
                                          <asp:Label ID="lblFoc" runat="server"></asp:Label>
                                      </ItemTemplate>
                                      <ItemStyle CssClass="column_style_left1_new" HorizontalAlign="Center" Width="40px" />
                                  </asp:TemplateField>--%>

                                 <%-- <asp:TemplateField HeaderText="Up " HeaderStyle-Width="28px" Visible="false">
                                      <ItemTemplate>
                                          <asp:Button ID="btnUp" CommandName="Up" ToolTip="UP" Text="&uArr;" CssClass="tag_Item_Move_trans"
                                              runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" UseSubmitBehavior="false"
                                              OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                                      </ItemTemplate>
                                      <ItemStyle CssClass="column_style_left1" Width="28px" />
                                  </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Down" HeaderStyle-Width="38px" Visible="false">
                                      <ItemTemplate>
                                          <asp:Button ID="btnDown" CommandName="Down" ToolTip="Down" Text="&dArr;" CssClass="tag_Item_Move_trans"
                                              runat="server" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" UseSubmitBehavior="false"
                                              OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                                      </ItemTemplate>
                                      <ItemStyle CssClass="column_style_left1" Width="28px" />
                                  </asp:TemplateField>--%>

                              </Columns>
                           <%-- <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                     <PagerStyle CssClass="pager" />--%>

                                <%--<PagerSettings Visible="False" />--%>

                            </asp:GridView>
                            
                            </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice_Supplier">
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_export_Item_otherdet_new1_Cth_Qty1">
                                CTH Qty1
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtCTH_Qty1" runat="server" MaxLength="17" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" TabIndex="9"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtCTH_Qty1_Code" runat="server" MaxLength="3" onkeyup="ChangeCase(this);"
                                    Onkeypress="return char1(event)" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="10"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('ITEM_CTH_QTY1_CODE'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                                CTH Qty2
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtCTH_Qty2" runat="server" MaxLength="12" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" 
                                    TabIndex="11"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtCTH_Qty2_Code" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    onkeyup="ChangeCase(this);" Onkeypress="return char1(event)" ClientIDMode="Static"
                                    TabIndex="12"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('ITEM_CTH_QTY2_CODE'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others">
                            <div id="tag_transac_item_gen_desc">
                                <div id="tag_label_transaction_export_Item_otherdet_new1">
                                    Generic Description</div>
                                <div id="txtcon_l_90px">
                                </div>
                                <div id="txtcon-m_90px_trans_item_desc">
                                    <asp:TextBox ID="txtGeneralDesc" runat="server" MaxLength="60" TextMode="MultiLine" ClientIDMode="Static"
                                        onkeyDown="return checkTextAreaMaxLength(this,event,'60');" onpaste="return checkTextAreaMaxLength(this,event,'60');"
                                        CssClass="validate[required] txtbox_none_Mid_transac_item_gen_decs_EXP"
                                        TabIndex="14"></asp:TextBox>
                                </div>
                                <div id="txtcon-r_90px">
                                </div>
                            </div>
                            <div id="lblMsg5" style="display: none;">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                                Manufacturer</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtManufacturer" MaxLength="50" runat="server" Text="N.A" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"  onpaste="return validatePaste(event);"
                                     TabIndex="15" ClientIDMode="Static" onkeypress="return numcharspl1(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_item_gen_rght">
                                Brand</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtBrand" runat="server" ClientIDMode="Static" MaxLength="20" Text="N.A" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"  onpaste="return validatePaste(event);"
                                    TabIndex="16"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                                Model</div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtModel" runat="server" ClientIDMode="Static" MaxLength="20" Text="N.A" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"  onpaste="return validatePaste(event);"
                                    TabIndex="17"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_item_gen_rght">
                                End Use
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtEndUse" runat="server" MaxLength="20" ClientIDMode="Static" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                    TabIndex="18" onkeypress="return numcharspl1(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_End_Use_Of_Itemd('End_Use'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="pop_text_area_Size2_Promaster">
                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                                Country Origin
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtCountryOrigin" runat="server" MaxLength="50" ClientIDMode="Static"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" TabIndex="19"
                                    onkeypress="return char1(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry('Item_Country'); return false"
                                    class="magnfy"></a>
                            </div>

                            <div id="editbu" style="height:8px;" >
                    <asp:Button ID="btnUpdate_Fairmacs" runat="server" Text="Update" Height="20px" Visible="false"
                        CssClass="autowidmovebut" onclick="btnUpdate_Fairmacs_Click" /></div>

                         <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>

                         <div id="tag_label_transaction_export_Item_otherdet_new1" style="width:105px;">
                                Part No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtpartno" runat="server" MaxLength="50" ClientIDMode="Static" Width="150px"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" TabIndex="19" ></asp:TextBox>
                                   
                            </div>

                        </div>
                        <div id="pop_text_area_Size2_Promaster_maxtxt">
                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                                Accessories</div>
                            <div id="txtcon-m_90px_item_gen_assec">
                                <asp:TextBox ID="txtAccessories" runat="server" MaxLength="120" onkeyDown="return checkTextAreaMaxLength(this,event,'120');"
                                    onpaste="return checkTextAreaMaxLength(this,event,'120');" TextMode="MultiLine" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_item_other_rmarks_new3" TabIndex="20"></asp:TextBox>
                            </div>
                            <div id="lblMsg6" style="display: none;">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                                Previous Be No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtPrevious_Be_No" runat="server" MaxLength="7" CssClass="validate[custom[integer],minSize[7]] txtbox_none_Mid_transac_Supp_Name"
                                    TabIndex="21" onkeypress="return num1(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_item_gen_rght">
                                Previous Be Date
                            </div>
                            <div id="txtcon-m_transaction_code">
                                <asp:TextBox ID="txtPrevious_Be_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="22"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtPrevious_Be_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPrevious_Be_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red"
                                    runat="server" ControlToValidate="txtPrevious_Be_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                    ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                                Unit Price
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtUnitValue" runat="server" MaxLength="17" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="23" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty1">
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtunitcode" runat="server" MaxLength="3" ClientIDMode="Static"
                                    onkeyup="return ChangeCase(this);autotab(this);" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="24" onkeypress="return char1(event)"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExchange('Imp_Item_General_Unit'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty1">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_item_gen_rght">
                                Customs House
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty1">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtCustomsHouse" runat="server" MaxLength="50" CssClass="txtbox_none_Mid_transac_code" ClientIDMode="Static"
                                    TabIndex="25"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="content" id="page-3">
                    <div id="pop_text_area_transac_popup_inn_container_left_trans_item_cth">
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Scheme Code
                            </div>
                            <div id="txtcon-m_transaction_Item_Schemecode">
                                <asp:DropDownList ID="ddlSchemeCode" runat="server" CssClass="listtxt_transac_Item_Schemecode"
                                    TabIndex="9" onselectedindexchanged="ddlSchemeCode_SelectedIndexChanged" AutoPostBack="true" >
                                </asp:DropDownList>

                              <%--  <asp:CascadingDropDown ID="CountryCascading" runat="server" Category="SCHEME_IMPORT_CODE"
                                    TargetControlID="ddlScheme_NOTN" ParentControlID="ddlSchemeCode" LoadingText="Loading ..."
                                    ServiceMethod="BindStatedropdown" ServicePath="~/Scheme_Notn_Dropdown_pages/DropdownWebService.asmx">
                                </asp:CascadingDropDown>--%>
                               
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp">
                                Scheme NOTN
                            </div>
                            <div id="txtcon-m_transaction_Item_Schemecode">
                                
                           <asp:DropDownList ID="ddlScheme_NOTN" runat="server"  OnSelectedIndexChanged="ddlScheme_NOTN_SelectedIndexChanged" AutoPostBack="true"
                               CssClass="listtxt_transac_Item_Schemecode" TabIndex="10" >
                           </asp:DropDownList>

                           <%-- <asp:CascadingDropDown ID="StateCascading" runat="server" 
                            Category="SCHEME_NOTN"  TargetControlID="ddlScheme_NOTN_SL" ParentControlID="ddlScheme_NOTN" 
                            LoadingText="Loading ..."  ServiceMethod="BindRegiondropdown" ServicePath="~/Scheme_Notn_Dropdown_pages/DropdownWebService.asmx">
                            </asp:CascadingDropDown>--%>
                              
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_gen_top">
                                Scheme NOTN SL
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <%-- <asp:DropDownList ID="ddlScheme_NOTN_SL" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                   TabIndex="3">
                               </asp:DropDownList>--%>
                                                    <%--  <asp:CascadingDropDown ID="RegionCascading" runat="server" Category="Region" TargetControlID="ddlScheme_NOTN_SL" ParentControlID="ddlScheme_NOTN" LoadingText="Loading Cities..." PromptText="select" ServiceMethod="BindRegiondropdown" ServicePath="~/Scheme_Notn_Dropdown_pages/DropdownWebService.asmx">
                            </asp:CascadingDropDown>--%>
                                <asp:DropDownList ID="ddlScheme_NOTN_SL" runat="server" CssClass="listtxt_transac_item_gen_notn" 
                                    TabIndex="11" >
                                    
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                CTH No
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtCTHNO" runat="server" MaxLength="8" onkeyup="autotab(this);"
                                    onkeypress="return num5(event)" ClientIDMode="Static" CssClass="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="26"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCTH('CTH'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label2">
                                RITC No
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtRITCNO" runat="server" MaxLength="8" onkeypress="return num5(event)"
                                    ClientIDMode="Static" CssClass="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="27"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCTH(); return false"
                                    class="magnfy"></a>
                            </div>

                             <div id="tag_label_transaction_popup_trans_cth_label2">
                                 <asp:Label ID="lblCTH_Rate" runat="server" Text=""></asp:Label>%
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label2"></div>
                            <%--<div id="txtcon_m_transaction_IGM_Wght_small" style="width:145px; text-align:right; font-weight:bold;" >
                                         <span id="lblTrk_IGM" title="Duty Calculator"  runat="server"  OnClick="Duty_Cal();return false;"
                                        style="color:Blue;text-decoration:underline;cursor:hand; font-size:smaller;">Go Duty Calculator </span>
                           </div>--%>
                            <div id="txtcon_m_transaction_IGM_Wght_small" style="width:145px; text-align:right; font-weight:bold;">
                            <a id="lblTrk_IGM" title="Duty Calculator" runat="server" ClientIDMode="Static" href="#"
                               onclick="return openDutyCalculator()"
                               style="color:Blue;text-decoration:underline;cursor:pointer; font-size:smaller;">
                                Go Duty Calculator
                            </a>
                     </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Basic Duty/Notn
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtBasicNotn" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_maindet" TabIndex="28"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtBasicSLNO" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" TabIndex="29"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('BasicSLNO'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtBasicRate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="30"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtBasicSPL" runat="server" MaxLength="10" 
                                    onkeyup="return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="31"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtBasicUnit" runat="server" MaxLength="3" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    onkeyup="ChangeCase(this);" onkeypress="return cha(event)" ClientIDMode="Static"
                                    TabIndex="32"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('BasicUnit'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddlBasicSPLTYPE" class="listtxt_transac_item_gen_notn" runat="server"
                                    TabIndex="33">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <%--<div id="tag_transac_lft_Trans_item_Cth12" runat="server" visible="false" style="height:25px">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Addl Duty
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtAddlDuty_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    Text="019/2006" CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="34"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtAddlDuty_NOTN_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                     CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="35"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Addl_duty'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtAddlDuty_Rate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="36"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                        </div>--%>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Education Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtEdu_Cess_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event);" Enabled="false"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"  onblur="Edu_Cess_NOTN()"  Onkeyup="Edu_Cess_NOTN()"
                                    TabIndex="37"   ReadOnly="true"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtEdu_Cess_NOTN_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)" onblur="Edu_Cess_NOTN()" Onkeyup="Edu_Cess_NOTN()"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="38"  ReadOnly="true" Enabled="false"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Edu_cess'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtEdu_Cess_Rate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false); Edu_Cess_NOTN()" 
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this); Edu_Cess_NOTN()" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" Enabled="false"
                                    TabIndex="39"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                        </div>

                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Sec&amp;Higher Ed. Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtSec_Edu_Cess_NOTN" runat="server" MaxLength="8"  ReadOnly="true"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" Enabled="false"
                                    TabIndex="40" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSec_Edu_Cess_NOTN_SL" runat="server" MaxLength="10" 
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" Enabled="false"
                                    TabIndex="41" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Sec_Edu_cess'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSec_Edu_Cess_Rate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" ReadOnly="True" Enabled="false"
                                    TabIndex="42"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                        </div>


                         <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Social Welfare
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Social_Welfare_NOTN" runat="server" MaxLength="8"  onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="40" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Social_Welfare_NOTN_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" 
                                    TabIndex="41" ></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Social_Welfare'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Social_Welfare_Rate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="42"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                        </div>



                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                NCD</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtNCD_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)" Enabled="false"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="43"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtNCD_SLNO" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)" Enabled="false"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="44"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('NCD');ReadOnly return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtNCD_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"  Enabled="false"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="45"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtNCD_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);" Enabled="false"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="46"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtNCD_UNIT" runat="server" MaxLength="3" ClientIDMode="Static" Enabled="false"
                                    onkeypress="return cha(event)" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    onkeyup="ChangeCase(this);autotab(this);" TabIndex="47"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('NCD_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddlNCD_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                    TabIndex="48">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Aggregate Duty
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtAggregate_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="49"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtAggregate_NOTN_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="50"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Aggregate_Duty'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtAggregate_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="51"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Safeguard Duty
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtSafeguard_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="52"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSafeguard_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="53"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('SafeGuard_Duty'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSafeguard_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="54"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtSafeguard_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="55"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSafeguard_UNIT" runat="server" MaxLength="3" onkeypress="return cha(event)"
                                    CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    onkeyup="ChangeCase(this);autotab(this);" ClientIDMode="Static" TabIndex="56"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Safeguard_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddlSafeguard_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="57">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                SAPTA Notn
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtSAPTA_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="58"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSAPTA_NOTN_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="59"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('SAPTA'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtSAPTA_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="60"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Tariff Value
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtTariff_NOTN" runat="server" MaxLength="10" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="61"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtTariff_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="62"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label_tariff">
                                Qty
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtTariff_Qty" runat="server" MaxLength="17" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="63"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label_tariff">
                                Amt
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtTariff_Amount" runat="server" MaxLength="9" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" ClientIDMode="Static"
                                    TabIndex="64"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtTariff_Amount_unitCode" runat="server" CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                  Onkeypress="return char1(event)" MaxLength="3" onkeyup="ChangeCase(this);autotab(this);" TabIndex="65"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Tariff_Amount_Code'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>

                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                AID Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_AIDC_NOTN" runat="server" MaxLength="8"  onkeypress="return notn(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="66" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_AIDC_NOTN_SLNO" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="validate[required] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" 
                                    TabIndex="67" ></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupAIDC('AIDC',document.getElementById('txtCountryOrigin').value); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_AIDC_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[required,custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="68"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                        </div>
                    </div>
                </div>
              <%--  //--------------------------------------Start-------------------------------%>
                <div class="content" id="page-4">
                    <div id="pop_text_area_transac_popup_inn_container_left_trans_item_ceth">
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                CETH No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtCETH_No" runat="server" MaxLength="8" onkeypress="return num5(event)"
                                    CssClass="validate[required,minSize[8],custom[integer]] txtbox_none_Mid_transac_Supp_Name"
                                    onkeyup="autotab(this);" ClientIDMode="Static" TabIndex="57"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCETH('CETH_NO'); return false"
                                    class="magnfy"></a>
                            </div>
                              <div id="tag_label_transaction_popup_trans_cth_label" style="width:100px">
                                  <asp:Label ID="lblCETH_Rate" runat="server" Text=""></asp:Label>%
                            
                            </div>

                               <div id="tag_label_transaction_popup_trans_cth_label">
                                  <asp:Label ID="lbl_MRP_Rate" runat="server" Text="" ForeColor="Red"></asp:Label>
                            
                            </div>

                        </div>
                        
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                CVD</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CVD_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="58"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CVD_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" 
                                    TabIndex="59"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('CVD'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CVD_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="60"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CVD_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="61"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CVD_UNIT" runat="server" MaxLength="3" ClientIDMode="Static"
                                    onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="62"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('CVD_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddlCVD_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                    TabIndex="63">
                                </asp:DropDownList>
                            </div>
                        </div>

                       <%-- //-----------------------------Start--%>

                        <div id="tag_transac_lft_Trans_item_Cth" style="display:none">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                              CVD  Education Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">

                                      <asp:TextBox ID="txt_CVD_Education_CESS_Rate" runat="server" MaxLength="8" onkeypress="return notn(event);"  Text="013/2012"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"    TabIndex="64"
                                      ></asp:TextBox>

                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                               
                                    <asp:TextBox ID="txt_CVD_Education_CESS_SL" runat="server" MaxLength="10"  onkeypress="return NOTNSLNO(event)"  Text="1"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="65" ></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('CETH_Edu_cess'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                            

                                     <asp:TextBox ID="txtCVD_Edu_Cess_Rate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"  Text="0.00"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this); " onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="66"
                                    ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi" style="display:none">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Sec&amp;Higher Ed. Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                               
                                   

                                    <asp:TextBox ID="txt_CVD_Sec_Edu_CESS_Rate" runat="server" MaxLength="8"  TabIndex="67"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"  ></asp:TextBox>
                                    
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                              
                                     <asp:TextBox ID="txtCETH_Sec_Edu_Cess_NOTN_SL" runat="server" MaxLength="10" TabIndex="68"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" 
                                   ></asp:TextBox>

                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('CETH_Sec_Edu_cess'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                               
                                       <asp:TextBox ID="txtCETH_Sec_Edu_Cess_Rate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" TabIndex="69"
                                    ></asp:TextBox>
                                 
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                        </div>



                      <%--  //------------------------------END--%>


                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi" style="display:none;">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Addl. Duty (Sub-Section)</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl5_SIA_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="70"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl5_SIA_NOTN_SL" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" 
                                    TabIndex="71"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Duty'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl5_SIA_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="72"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Addl Duty of Excise(SIA)
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_GSI_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="73"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_SL" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"  Enabled="false"
                                    TabIndex="74"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Duty_GSI'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="75"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_GSI_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="76"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_GSI_UNIT" runat="server" MaxLength="3" ClientIDMode="Static"
                                    onkeyup="ChangeCase(this);autotab(this);" onkeypress="return cha(event)" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="77"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_GSI_UNIT');return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_GSI_SPL_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                    TabIndex="78">
                                </asp:DropDownList>
                            </div>
                        </div>
                        
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Spl. Excise Duty (Sched-11)
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_SHE11_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="79"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)" Enabled="false"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="80"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_She11_Notn'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="81"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_SHE11_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="82"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_SHE11_UNIT" runat="server" MaxLength="3" onkeypress="return cha(event)"
                                    onkeyup="ChangeCase(this);autotab(this);" ClientIDMode="Static" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="83"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_SHE11_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_SHE11_Type" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                    TabIndex="84">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth_Sec_hi">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Addl Duty of Excise (TTA)</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_TTA_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="85"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)" Enabled="false"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="86"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_TTA_Notn'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="87"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_TTA_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="88"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_TTA_UNIT" runat="server" MaxLength="3" onkeypress="return cha(event)"
                                    onkeyup="ChangeCase(this);autotab(this);" ClientIDMode="Static" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="89"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_TTA_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_TTA_Type" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                    TabIndex="90">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Health Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_Health_CESS_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="91"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="92"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Addl_Health_Cess'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_RATE" runat="server" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    MaxLength="10" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small"
                                    ClientIDMode="Static" TabIndex="93"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Addl_Health_CESS_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="94"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Addl_Health_CESS_UNIT" runat="server" MaxLength="3" onkeypress="return cha(event)"
                                    onkeyup="ChangeCase(this);autotab(this);" ClientIDMode="Static" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="95"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('Addl_Health_CESS_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_Addl_Health_CESS_Type" CssClass="listtxt_transac_item_gen_notn"
                                    runat="server" TabIndex="96">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Cess &amp; Notification
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CESS_NOTN" runat="server" onkeypress="return notn(event)" MaxLength="8"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="97"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="98"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Cess_Notn'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="99"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_CESS_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);" ClientIDMode="Static"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" TabIndex="100"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_CESS_UNIT" runat="server" MaxLength="3" onkeyup="ChangeCase(this);autotab(this);"
                                    onkeypress="return cha(event)" ClientIDMode="Static" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="101"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('CESS_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddl_CESS_Type" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                    TabIndex="102">
                                </asp:DropDownList>
                            </div>
                        </div> 

                         

                           <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Other Duty
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtOther_Duty_Notn" runat="server" onkeypress="return notn(event)" MaxLength="8"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="103"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtOther_Duty_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="104"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                             
                               <%--<a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Cess_Notn'); return false"
                                    class="magnfy"></a>--%>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtOther_Duty_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="105"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtOther_Duty_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);" ClientIDMode="Static"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" TabIndex="106"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtOther_Duty_UNIT" runat="server" MaxLength="3" onkeyup="ChangeCase(this);autotab(this);"
                                    onkeypress="return cha(event)" ClientIDMode="Static" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="107"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('OTHER_DUTY_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                                <asp:DropDownList ID="ddlOther_Duty_Type" runat="server" CssClass="listtxt_transac_item_gen_notn"
                                    TabIndex="108">
                                </asp:DropDownList>
                            </div>
                        </div> 

                        <div id="tag_transac_lft_Trans_item_Cth12" runat="server" visible="false" style="height: 25px">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Addl Duty
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtAddlDuty_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    Text="019/2006" CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="108"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtAddlDuty_NOTN_SL" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="108"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupNotn('Addl_duty'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtAddlDuty_Rate" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="108"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                            </div>
                        </div>

                         <div id="tag_transac_lft_Trans_item_Cth_ExcAidc" runat="server" visible="false" style="height:25px">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                              Exc.AID Cess
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Exc_AIDC_NOTN" runat="server" MaxLength="8"  onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="108" ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Exc_AIDC_NOTN_SLNO" runat="server" MaxLength="10" onkeypress="return NOTNSLNO(event)"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" 
                                    TabIndex="108" ></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupAIDC('AIDC',document.getElementById('txtCountryOrigin').value); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Exc_AIDC_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="108"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                                <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_Exc_AIDC_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="108"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_Exc_AIDC_SPL_UNIT" runat="server" MaxLength="3" ClientIDMode="Static"
                                    onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="108"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Infra Cess          
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtinfra_cess_Notn" runat="server" onkeypress="return notn(event)" MaxLength="8" Enabled="false"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="108"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtinfra_cess_Notn_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)" Enabled="false"
                                    CssClass="txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static" TabIndex="108"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('Infra_Notn');ReadOnly return false"
                                    class="magnfy"></a>

                             
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtinfra_cess_Notn_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"  Enabled="false"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="108"></asp:TextBox>
                            </div>
                           
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtinfra_cess_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="108"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txtinfra_cess_SPL_UNIT" runat="server" MaxLength="3" ClientIDMode="Static"
                                    onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="108"></asp:TextBox>
                            </div>

                        </div>

                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                MRP Duty
                            </div>
                            <div id="tag_label_transaction_MIS_empty1">
                                <asp:CheckBox ID="chkMRP_Duty" runat="server" />
                                <%--<input name="" type="checkbox" value="">--%>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label3">
                                Sr. No. List
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMRP_SL_NO" runat="server" Enabled="False" MaxLength="10" onkeypress="return numchar(event)"
                                    ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_item_maindet" TabIndex="109"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label5">
                                MRP Rs/Unit
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMRP_AMOUNT" runat="server" Enabled="False" MaxLength="17" onblur="extractNumber(this,2,false);"
                                    ClientIDMode="Static" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="110"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_otherduty_longlabel">
                                RSP Applicability
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width: 50px;">
                                <asp:DropDownList ID="ddl_RSP_Applicable" TabIndex="111" Enabled="False" runat="server"
                                    CssClass="listtxt_transac_item_gen_notn">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div id="tag_transac_lft_Trans_item_Cth" >
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                RSP Notn No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width:100px;">
                                <asp:TextBox ID="txtRSP_Notn_No" runat="server" ClientIDMode="Static" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_Supp_Name" Width="100px" TabIndex="112" MaxLength="8" Enabled="False"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_otherduty_longlabel" >
                                RSP Notn SL.No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" style="width:100px;">
                                <asp:TextBox ID="txtRSP_Notn_Slno" runat="server" Enabled="False" ClientIDMode="Static"
                                    CssClass="txtbox_none_Mid_transac_Supp_Name" Width="100px"  TabIndex="113" MaxLength="6"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                              <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_RSP(); return false"
                                    class="magnfy"></a>
                            </div>
                              <div id="tag_label_transaction_popup_trans_cth_label4">
                                Abt @ %
                            </div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txtMRP_ABT_RATE" runat="server" Enabled="False" MaxLength="17" onblur="extractNumber(this,2,false);" ClientIDMode="Static"
                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet"
                                    TabIndex="114"></asp:TextBox>
                            </div>
                        </div>
                                               

                    </div>
                </div>
             <%--   //---------------------------------------------END--%>
             <%---------IGSTs-------------------------%>

               <div class="content" id="page-11">
                    <div id="pop_text_area_transac_popup_inn_container_left_trans_item_ceth">
                      <div id="tag_transac_lft_Trans_item_Cth">
                         <div id="tag_label_transaction_popup_trans_cth_label"></div>
                            <div id="tag_label_transaction_popup_trans_cth_label">
                            <asp:Label ID="lbl_IGST_Default" runat="server" ForeColor="Blue"></asp:Label>
                            </div>
                        </div>

                    <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                LEVY NOTN No</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="160"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" 
                                    TabIndex="161"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise_IGST('LEVY_NOTN_IGST_V2',document.getElementById('txtCTH_No').value); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="162"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                               <%-- <asp:TextBox ID="txt_IGST_LEVY_SPL_Amt" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="163"></asp:TextBox>--%>

                                    <asp:TextBox ID="txt_IGST_LEVY_SPL_Amt" runat="server" MaxLength="10" 
                                    onkeyup="return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="163"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_UNIT" runat="server" MaxLength="3" ClientIDMode="Static"
                                    onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="164"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('IGST_LEVY_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1" style="display:none;">
                                <asp:DropDownList ID="ddl_IGST_LEVY_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server" >
                                </asp:DropDownList>
                            </div>
                        </div>
                       <%-- --R2-----%>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                               EXCEMPTION NOTN No</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="165"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" 
                                    TabIndex="166"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise_CTH('LEVY_EXC_NOTN_V2',document.getElementById('txtCTH_No').value); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="167"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">

                             <asp:DropDownList ID="ddl_LEVY_EXCEMPTION_NOTN_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn" Width="110px">
                                    <asp:ListItem Value="G" Text="GSTN Notn"></asp:ListItem>
                                    <asp:ListItem  Value="C" Text="Customs Notn"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                              <%--  <asp:TextBox ID="txt_LEVY_NOTN_Unit" runat="server" MaxLength="3" ClientIDMode="Static"
                                    onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="62"></asp:TextBox>--%>
                           </div>
                            <div id="magnify_area">
                               <%-- <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('CVD_UNIT'); return false"
                                    class="magnfy"></a>--%>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1" style="display:none;">
                                <asp:DropDownList ID="ddl_LEVY_Exception_NOTN_NO_Type" CssClass="listtxt_transac_item_gen_notn" runat="server" >
                                </asp:DropDownList>
                            </div>
                        </div>
                         <%-- --R3-----%>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                LEVY C.P. CESS NOTN No</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="168"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" 
                                    TabIndex="169"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise_IGST('LEVY_CP_CESS_NOTN_IGST',document.getElementById('txtCTH_No').value); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="170"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <%--<asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_SPL" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="171"></asp:TextBox>--%>

                                    <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_SPL" runat="server" MaxLength="10" 
                                    onkeyup="return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static"
                                    TabIndex="171"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_COMPENSATION_CESS_UNIT" runat="server" MaxLength="3" ClientIDMode="Static"
                                    onkeypress="return cha(event)" onkeyup="ChangeCase(this);autotab(this);" CssClass="validate[custom[onlyLetterSp],minSize[3]] txtbox_none_Mid_transac_item_CTH_small"
                                    TabIndex="172"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupUnit('IGST_LEVY_COMPENSATION_CESS_UNIT'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1" style="display:none;">
                                <asp:DropDownList ID="ddl_IGST_LEVY_COMPENSATION_CESS_SPL_TYPE" CssClass="listtxt_transac_item_gen_notn" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                         <%-- --R4-----%>
                        <div id="tag_transac_lft_Trans_item_Cth">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                               EXCEMPTION C.P. NOTN No</div>
                            <div id="txtcon-m_transaction_item_maindet">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_NOTN" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" 
                                    TabIndex="173"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_SLNO" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_CTH_small" 
                                    TabIndex="174"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                                <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Notification_Excise('LEVY_EXC_CP_CESS_NOTN'); return false"
                                    class="magnfy"></a>
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                                <asp:TextBox ID="txt_IGST_LEVY_EXCEPTION_CC_RATE" runat="server" MaxLength="10" onblur="extractNumber(this,6,false);"
                                    onkeyup="extractNumber(this,6,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_item_CTH_small" ClientIDMode="Static"
                                    TabIndex="175"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_percent">
                                %</div>
                            <div id="txtcon-m_transaction_item_maindet">
                              <asp:DropDownList ID="ddl_LEVY_EXCEPTION_CC_NOTN_TYPE" runat="server" CssClass="listtxt_transac_item_gen_notn" Width="110px">
                                     <asp:ListItem Value="G" Text="GSTN Notn"></asp:ListItem>
                                    <asp:ListItem  Value="C" Text="Customs Notn"></asp:ListItem>
                                </asp:DropDownList>
                             </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="txtcon-m_transaction_item_CTH_small">
                               </div>
                            <div id="magnify_area">
                             </div>
                            <div id="txtcon-m_transaction_item_gen_notn_list1">
                              
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_item_Cth"></div>
                         <div id="tag_transac_lft_Trans_item_Cth" style="margin-top:10px; height:150px;">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Compulsory compliance Requirements (CCRs) </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:520px; height:130px;">
                                    <asp:TextBox ID="txt_CCR" runat="server" TextMode="MultiLine"  CssClass="txtbox_none_Mid_transac_export_Marks_nos_gen_CCR" 
                                     TabIndex="20"></asp:TextBox>
                            </div>
                            </div>

                         </div>
                </div>
             <%---------IGSTe-------------------------%>

                <div class="content" id="page-5">
                   <%-- <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_tag1">
                    </div>--%>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" >
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Anti Dumping Notn /
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <%--<asp:DropDownList ID="ddlAntiDumping_Notn" runat="server" CssClass="listtxt_transac_Item_Schemecode"
                                TabIndex="114"  AutoPostBack="true" onselectedindexchanged="ddlAntiDumping_Notn_SelectedIndexChanged">
                            </asp:DropDownList>--%>

                            <%--<asp:DropDownList ID="ddlAntiDumping_Notn" runat="server" CssClass="listtxt_transac_Item_Schemecode" TabIndex="114" >
                            </asp:DropDownList>--%>

                            <asp:TextBox ID="txt_AntiDumping_Notn" runat="server" MaxLength="8" onkeypress="return notn(event)"
                                    CssClass="txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static" 
                                    TabIndex="114"></asp:TextBox>

                            <%--<asp:CascadingDropDown ID="CascadingDropDown1" runat="server" Category="SCHEME_IMPORT_CODE"
                                TargetControlID="ddlAntiDumping_Notn_SL" ParentControlID="ddlAntiDumping_Notn"
                                LoadingText="Loading..." ServiceMethod="BindAntidropdown" ServicePath="~/Scheme_Notn_Dropdown_pages/DropdownWebService.asmx">
                            </asp:CascadingDropDown>--%>
                        </div>
                        <%--<div id="tag_label_transaction_popup_IGM2_empty">
                        </div>--%>
                          <div id="magnify_area">
                          <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_AntiDumping_Notification('ADD_NOTN_SEARCH_ITEM'); return false"
                                    class="magnfy"></a>
                          </div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Anti Dumping Notn Sl
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <%--<asp:DropDownList ID="ddlAntiDumping_Notn_SL" runat="server" CssClass="listtxt_transac_Item_Schemecode"
                                TabIndex="115">
                            </asp:DropDownList>--%>
                            <asp:TextBox ID="txt_AntiDumping_Notn_SL" runat="server" MaxLength="10" onkeypress="return  NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_Supp_Name" 
                                    TabIndex="115"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            CTH Sl No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCTH_SL_No" runat="server" onkeyup="autotab(this);" ClientIDMode="Static"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="116"
                                MaxLength="8"></asp:TextBox>
                        </div>
                       <%-- <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>--%>
                        <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            CTH Supplier SL
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCTH_Supplier_SL" onkeypress="return num1(event)" onkeyup="autotab(this);"
                                ClientIDMode="Static" runat="server" CssClass="validate[custom[integer]] txtbox_none_Mid_transac_Supp_Name"
                                TabIndex="117" MaxLength="8"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            CTH Qty
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCTH_Qty" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" runat="server"
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="118"
                                MaxLength="12"></asp:TextBox>
                        </div>
                        <div id="magnify_area"></div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                           ADD Exchange Rate
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txt_ADD_ExRate" onblur="extractNumber(this,4,false);" onkeyup="extractNumber(this,4,false);return Clear_Dot(this);"
                                onkeypress="return blockNonNumbers(this, event, true, false);" runat="server"
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name" TabIndex="118"
                                MaxLength="12"></asp:TextBox>
                        </div>
                    </div>

                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="display: none;">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                            RSP DUTY[Y/N]
                        </div>
                        <div id="txtcon-m_transaction_item_gen_notn_list1">
                            <asp:DropDownList ID="ddlRSP_Duty_yn" CssClass="listtxt_transac_item_gen_notn" runat="server"
                                >
                                <asp:ListItem>N</asp:ListItem>
                                <asp:ListItem>Y</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="RSP_DETAILS" runat="server" style="display: none;">
                        <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others">
                            <div id="tag_transac_item_gen_desc">
                                <div id="tag_label_transaction_export_Item_otherdet_new1">
                                    Description</div>
                                <div id="txtcon_l_90px">
                                </div>
                                <div id="txtcon-m_90px_trans_item_desc">
                                    <asp:TextBox ID="txtRSP_Description" runat="server" MaxLength="50" TextMode="MultiLine"
                                        onkeyDown="return checkTextAreaMaxLength(this,event,'50');" onpaste="return checkTextAreaMaxLength(this,event,'50');"
                                        CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                        ></asp:TextBox>
                                </div>
                                <div id="txtcon-r_90px">
                                </div>
                            </div>
                            <div id="txtcon-r_90px" style="display: none;">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                Serial No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtRSP_Slno" runat="server" onkeypress="return num1(event)" CssClass="validate[custom[integer]] txtbox_none_Mid_transac_Supp_Name"
                                     MaxLength="3"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                Qty
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtRSP_Qty" runat="server" onkeypress="return num1(event)" CssClass="validate[custom[integer]] txtbox_none_Mid_transac_Supp_Name"
                                     MaxLength="6"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_otherduty_longlabel">
                                Amount
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtRSP_Amount" onkeypress="return num1(event)" runat="server" CssClass="validate[custom[integer]] txtbox_none_Mid_transac_Supp_Name"
                                     MaxLength="12"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="display: none;">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                Notn No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtRSP_Notn_No1" runat="server" onkeypress="return num1(event)"
                                    CssClass="validate[custom[integer]] txtbox_none_Mid_transac_Supp_Name" 
                                    MaxLength="8"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_trans_otherduty_longlabel">
                                Notn SL.No
                            </div>
                            <div id="txtcon-m_transaction_Supp_code" >
                                <asp:TextBox ID="txtRSP_Notn_Slno1" onkeypress="return num1(event)" runat="server"
                                    CssClass="validate[custom[integer]] txtbox_none_Mid_transac_Supp_Name" 
                                    MaxLength="3"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others">
                                ABT Rate
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txtRSP_Abt_Rate" onkeypress="return numdot1(event)" runat="server"
                                    CssClass="validate[custom[number]] txtbox_none_Mid_transac_Supp_Name"
                                    MaxLength="6"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                     <style type="text/css">
                    fieldset
                    {
                      max-width:720px;
                      padding:15px;	
                      margin-left:0px;
                    }
                    .legend1
                    {
                      margin-bottom:0px;
                      margin-left:10px;
                    }
                </style>
                    <fieldset style="border: Black; border-style: double; margin-left: 0px; width: 690px">
                        <legend style="border: Black; border-collapse: collapse; width: 300px; font-weight: bold;">
                            Manufacturer / Producer / Grower Details </legend>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width: 23px;">
                                <asp:CheckBox ID="chk_manufacturer" runat="server" />
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label" style="width: 483px; color: Blue;">
                                Whether Manufacturer Address same as from Supplier
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="height: 40px; width: 683px;">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Cus. Notn exempting Cen. excise flag
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Cus_not_exe_Cen_flag" runat="server" onkeyup="autotab(this);"
                                    MaxLength="1" TabIndex="119" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </div>
                            <%-- <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>--%>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Manufacturer/Producer
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Manufacturer_producer" onkeyup="autotab(this);" MaxLength="1"
                                    TabIndex="120" Enabled="false" ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Code
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Manu_produ_grower_code" runat="server" onkeyup="autotab(this);"
                                    TabIndex="121" Enabled="false" CssClass="txtbox_none_Mid_transac_Supp_Name" MaxLength="17"></asp:TextBox>
                            </div>
                            <%--  <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>--%>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Address 1
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Manufacturer_Add1" onkeyup="autotab(this);" ClientIDMode="Static"
                                    runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" onpaste="return validatePaste(event);" MaxLength="70" TabIndex="122"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Address 2
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Manufacturer_Add2" runat="server" onkeyup="autotab(this);" MaxLength="50"
                                    TabIndex="123" CssClass="txtbox_none_Mid_transac_Supp_Name" onpaste="return validatePaste(event);"></asp:TextBox>
                            </div>
                            <%--<div id="tag_label_transaction_popup_IGM2_empty">
                        </div>--%>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                City
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Manufacturer_City" onkeyup="autotab(this);" MaxLength="35" TabIndex="124"
                                    ClientIDMode="Static" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name" onpaste="return validatePaste(event);"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Country Subdivision
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Manu_Country_Subdiv" runat="server" onkeyup="autotab(this);"
                                    MaxLength="35" TabIndex="125" CssClass="txtbox_none_Mid_transac_Supp_Name" onpaste="return validatePaste(event);"></asp:TextBox>
                            </div>
                            <%--  <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>--%>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Pincode
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Manufacturer_pincode" onkeyup="autotab(this);" MaxLength="10"
                                    Onkeypress="return num1(event)" TabIndex="126" ClientIDMode="Static" runat="server"
                                    CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Country
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Manufacturer_Country" runat="server" MaxLength="20" TabIndex="127"
                                    CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </div>
                            <%--<div id="tag_label_transaction_popup_IGM2_empty">
                        </div>--%>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Source Country
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Manu_Source_Country" MaxLength="20" TabIndex="128" ClientIDMode="Static"
                                    runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </div>
                        </div>
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 683px;">
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Transit Country
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_manu_Transit_Country" runat="server" MaxLength="20" TabIndex="129"
                                    CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </div>
                            <%--  <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>--%>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_popup_trans_cth_label">
                                Accessory Status (0 / 1 / 2)
                            </div>
                            <div id="txtcon-m_transaction_Supp_code">
                                <asp:TextBox ID="txt_Accessory_status" onkeyup="autotab(this);" MaxLength="1" TabIndex="130"
                                    ClientIDMode="Static" runat="server" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                    onkeypress="return pin(event);"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                </div>

                <div class="content" id="page-8">
                  
                     <div id="tag_transac_lft_Trans_Invoice_Supp_in1_chkbox_frame">
                        <div id="tag_label_transaction_MIS_empty1">
                            <asp:CheckBox ID="chkSVB_Relation" runat="server" TabIndex="58"></asp:CheckBox></div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="pop_text_area_transac_MIS_InnTitle1_chkbox">
                            SVB Relation
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            SVB Ref No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtSVB_RefNo" runat="server" MaxLength="20" onkeyup="autotab(this);"
                                CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name" Enabled="false"
                                TabIndex="59"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Date</div>
                        <div id="txtcon-m_transaction_SVB_Date">
                            
                            <asp:TextBox ID="txtSVBDate" runat="server" Width="95px" TabIndex="60" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Enabled="False"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtSVBDate"
                                Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtSVBDate"
                                Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                            </asp:CalendarExtender>
                           
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            SVB Custom House
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtCustomsHouse_2" runat="server" TabIndex="61" CssClass="txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static" ></asp:TextBox>
                        </div>
                        <div id="magnify_area">

                        <a href="#" class="magnfy" onclick="OpenPopupCustom_House_Details('Item_SVB'); return false"></a>
                           
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Loading On
                        </div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlLoadingOn" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="62">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Assessable" Value="Assessable"></asp:ListItem>
                                <asp:ListItem Text="Duty" Value="Duty"></asp:ListItem>
                                <asp:ListItem Text="Both" Value="Both"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Assessable Rate
                        </div>
                        <div id="txtcon-m_transaction_SVB_Rate">
                            <asp:TextBox ID="txtAssesable_Rate" runat="server" onkeypress="return numdot1(event)"
                                onkeyup="autotab(this);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_SVB_Rate"
                                Enabled="false" MaxLength="6" TabIndex="63"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_SVB_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Status</div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlAssesable_Status" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="64">
                                  <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Provisional" Value="P"></asp:ListItem>
                                <asp:ListItem Text="Final" Value="F"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_Supp_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Duty Rate
                        </div>
                        <div id="txtcon-m_transaction_SVB_Rate">
                            <asp:TextBox ID="txtDuty_Rate" runat="server" onkeypress="return numdot1(event)"
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_SVB_Rate" Enabled="false"
                                MaxLength="6" TabIndex="65"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_SVB_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Status</div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlDuty_Status" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="66">
                                   <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Provisional" Value="P"></asp:ListItem>
                                <asp:ListItem Text="Final" Value="F"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="content" id="page-6" style="display: none;">
                    <iframe  name="" scrolling="no" id="Trans_product_reimport_iframe" style="width:800px; height:320px;"><%--trans_item_reimport--%>
                    </iframe>
                </div>
                <div class="content" id="page-7" style="display: none;">
                    <iframe  name="trans_item_licence" scrolling="no" id="Trans_product_licence_iframe" >
                    </iframe>
                </div>
                <div class="content" id="page-10" style="display: none;">
                    <iframe name="" scrolling="no" id="Trans_product_Declaration_iframe" style="width:800px; height:300px;" >
                    </iframe>
                </div>
                <div class="content" id="page-9" style="display: none;">
                    <iframe name="trans_item_licence" scrolling="no" id="Trans_product_Singlewindow_iframe">
                    </iframe>
                </div>
                <div class="content" id="page-12" style="display: none;">
                    <iframe name="trans_item_licence" scrolling="no" id="Trans_Supporting_Documents_iframe" style="width:800px; height:340px;">
                    </iframe>
                </div>
            </div>

            <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_det_Inv_S_No" style="height:60px">
                <div id="innerbox_MidMain_Trans_Item_Main_top">
                    <div id="tag_transac_lft_in1_item_top">
                        <div id="tag_label_transaction_popup_gen3">
                            Invoice Sr.No
                        </div>
                        <div id="txtcon-m_transaction_list1">
                            <asp:DropDownList ID="ddlInvoice_SlNo" runat="server" CssClass="listtxt_transac_src1"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlInvoice_SlNo_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_in1_item_top">
                        <div id="tag_label_transaction_popup_gen3">
                            Item Sr.No
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_det2">
                            <asp:DropDownList ID="ddl_ItemSlno" runat="server" CssClass="listtxt_transac_src1"
                                AutoPostBack="True" OnSelectedIndexChanged="ddl_ItemSlno_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div id="tag_transac_lft_in1_item_top">
                        <div id="tag_label_transaction_popup_gen3" style="width:120px";>
                            Current Item SlNo
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_det2" style="width:60px";>
                         
                        <asp:Label ID="lbl_Item_Slno" runat="server"></asp:Label>           
                   
                        </div>
                    </div>
                </div>
            </div>


                     <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_Imp" style="height:260px;">
                         <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_Topcap">
                             Current Invoice Details</div>
                         <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                             <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                                 Inv No.
                             </div>
                             <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                 <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
                             </div>
                         </div>
                         <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                             <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                                 Inv Value
                             </div>
                             <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                 <asp:Label ID="lblInvoiceValue" runat="server"></asp:Label>
                             </div>
                         </div>
                         <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                             <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                                 Prod Val
                             </div>
                             <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                 <asp:Label ID="lblProductValue" runat="server"></asp:Label>
                             </div>
                         </div>
                         <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                             <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                                 Tot Items
                             </div>
                             <div id="tag_label_transaction_popup_IGM_invoice_det2">
                                 <asp:Label ID="lblTotal_No_Of_Items" runat="server"></asp:Label>
                             </div>
                         </div>
                         <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                             <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                             </div>
                             <div id="tag_label_transaction_popup_IGM_invoice_det2">
                             </div>
                         </div>
                          <%--    <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                             <div id="tag_label_transaction_popup_IGM_invoice_det1_new">
                             </div>
                             <div id="tag_label_transaction_popup_IGM_invoice_det2">
                             </div>
                         </div>--%>
                         <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                             <div id="tag_label_transaction_popup_IGM_invoice_det1_new" style="width: 100px">
                                 <a href="#" onclick="jQuery('#form1').validationEngine('hide');open_Single_Window_Notes('N'); return false;">
                                     S/W Notes </a>
                                 <div id="tag_label_transaction_popup_IGM_invoice_det1_new" style="width: 100px">
                                     <a href="#" onclick="jQuery('#form1').validationEngine('hide');open_license_Invoice_Itemwise_details_update_bulk('N'); return false;">
                                         LICENSE VIEW </a>
                                 </div>
                             </div>
                             <%--  <div id="tag_label_transaction_popup_IGM_invoice_det2">
                             </div>--%>
                         </div>

                     </div>

         <div id="innerbox_MidMain_bot_transact_invoice" style="width:970px;">
                <div id="newbu">
                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="133" CausesValidation="false" 
                        UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                        OnClick="btnNew_Click" /></div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate_Item(); Call_CTH_Rate_SplAmount(document.getElementById('txtCTH_No').value);"
                        CssClass="save" TabIndex="131" /></div>

                        <div id="editbu">
                        <asp:Button ID="btn_save_new" Text="Save & New" CssClass="autowidupdatebut" TabIndex="131"
                            runat="server" OnClientClick="return validate_Item(); Call_CTH_Rate_SplAmount(document.getElementById('txtCTH_No').value);" OnClick="btn_save_new_Click" />
                    </div>

                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" Visible="False" OnClick="btnUpdate_Click"
                        CssClass="updates" OnClientClick="return validate_Item();" TabIndex="131" /></div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="132" Visible="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'PRODUCT', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="132" OnClick="btnDelete_Click" 
                        CssClass="dlete" Style="display: none;" />

                        <%--OnClientClick="return validate_Item();"--%>
                </div>
                <div id="editbu">
                  <%--<asp:Button ID="btnCancel" runat="server" class="scancel" OnClientClick="Parent_close_button1();"
                        tabindex="132" CausesValidation="false"
                        UseSubmitBehavior="false"
                       />--%>
                       <input type="submit" value="Submit" class="scancel" onclick="Child_Parent_close_button1_Trigger_AnotherPage('General',document.getElementById('hdn_source').value);return false;"
                        id="btnCancel" tabindex="132">
                </div>

                 <%--<div id="editbu" style="width: 47px;">
                 <asp:Button ID="btnMoveup" Text="Move" CssClass="autowidupdatebut" Width="45px" runat="server"
                     UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_IMP_Prouduct_Item_Move('New'); return false;" />
             </div>
             <div id="editbu" style="width: 47px;">
                 <asp:Button ID="btnUp" Text="Up" CssClass="autowidmovebut" Width="45px" runat="server"
                     UseSubmitBehavior="false" OnClick="btnUp_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
             </div>
             <div id="editbu" style="width: 47px;">
                 <asp:Button ID="btnDown" Text="Down" CssClass="autowidmovebut" Width="45px" runat="server"
                     UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                     OnClick="btnDown_Click" />
             </div>--%>

           
             <div id="editbu" runat="server" style="width: 125px;">
                 <asp:Button ID="btnMoveup" Text="Move" CssClass="autowidupdatebut" Width="40px" runat="server"
                     UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_IMP_Prouduct_Item_Move('New'); return false;" />
                 <asp:Button ID="btnUp" Text="Up" CssClass="autowidmovebut" Width="32px" runat="server"
                     UseSubmitBehavior="false" OnClick="btnUp_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                 <asp:Button ID="btnDown" Text="Down" CssClass="autowidmovebut" Width="42px" runat="server"
                     UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                     OnClick="btnDown_Click" />
             </div>

             <div id="editbu" style="width: 92px;">
                 <asp:Button ID="btnupdateProduct" Text="Update Master" CssClass="autowidupdatebut"
                     Width="90px" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                     OnClick="btnupdateProduct_Click" />
             </div>
             <div id="editbu" style="width: 58px;">
                 <asp:Button ID="btnitemCopy" Text="Go Copy" CssClass="autowidupdatebut" Width="60px"
                     runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_Item_Copy(document.getElementById('hdinvslno').value); return false;" />
             </div>
             <div id="editbu" style="width: 98px;">
                 <asp:Button ID="btn_Single_Window_Copy" Text="Bulk S/W" CssClass="autowidupdatebut"
                     Width="60px" runat="server" UseSubmitBehavior="false"
                      OnClientClick="jQuery('#form1').validationEngine('hide');open_IMP_Single_Window_Copy(document.getElementById('hdinvslno').value); return false;" />
            
             <asp:Button ID="btnFTA" Text="FTA" CssClass="autowidmovebut" runat="server" 
                        OnClientClick="IMP_FTA(); return false" Width="30px" />  
            
           
             </div>
             <div id="editbu" style="width: 55px;">
                 <asp:Button ID="btn_lic_Copy" Text="Lic.Copy" CssClass="autowidupdatebut" Width="54px"
                     runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_Imp_Item_Lic_Copy(document.getElementById('hdinvslno').value); return false;" />
             </div>
              <div id="editbu" style="width: 52px;">
               <asp:Button ID="btn_Bulk_Lic" Text="Bulk Lic" CssClass="autowidupdatebut"
                     Width="52px" runat="server" UseSubmitBehavior="false"
                      OnClientClick="jQuery('#form1').validationEngine('hide');open_Import_Bulk_License_Excel_Upload(); return false;" />
                      </div>
             <div id="editbu" style="width: 90px;">
                 <asp:Button ID="btn_WH_Sup_doc" Text="Copy SupDoc" CssClass="autowidupdatebut"
                     Width="89px" runat="server" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide');open_IMP_Supporting_doc_Copy(document.getElementById('hdinvslno').value); return false;" />
             </div>


             </div>
            </div>
             <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
           
            <div id="Is_Inv" runat="server" style="display:none;color:Black;"> * Product Not Avaiabale,Add Invocie First.</div>

<%--   <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="btnMoveup"
    CancelControlID="btnClose" BackgroundCssClass="modalBackground">
</asp:ModalPopupExtender>
<asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" style = "display:none" BorderColor="Transparent">
   
    <asp:Button ID="btnClose" runat="server" style = "display:none"/>
                <div id="innerbox_MidMain_popup_adcode_ItemMove">
                <div id="innerbox_MidMain_top_adcode_Itemmove">
                    Item Move Details
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="$find('mp1').hide();" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode_Itemmove">
                   
                    <div id="pop_text_area_ItemMove">
                        <div id="tag_label_adcode">
                            From</div>
                        <div id="txtcon-m_src_ItemMove">
                           <asp:DropDownList ID="ddlItemFrom" runat="server" CssClass="listtxt_transac_mode_new"
                                >
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="pop_text_area_ItemMove">
                        <div id="tag_label_adcode">
                            To
                        </div>
                        <div id="txtcon-m_src_ItemMove">
                            <asp:DropDownList ID="ddlItemTo" runat="server" CssClass="listtxt_transac_mode_new">
                            </asp:DropDownList>
                        </div>
                    </div>
                 
                </div>
            </div>
            <div id="innerbox_MidMain_top_adcode_Itemmove">
                <div id="innerbox_adcode_bot_inn_ItemMove">
                  
                    <div id="editbu">
                    
                      
                     <asp:Button ID="btnMove_Item" runat="server" OnClick="btnMove_Item_Click" 
                     CssClass="autowidnewbut" Text="Ok" TabIndex="115" UseSubmitBehavior="false"/></div>
                       
                   
                   
                    
                     </div>
                </div>
           
            </asp:Panel>--%>
            <asp:HiddenField ID="hdn_tab_count" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_Invoice_No" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_Item_Edit" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_ITEM_AOUNT" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_Invoice_Value" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_Grid_RowCount" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_Grid_Count" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_Update_Item" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_UnitPrice" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_txtEndUse" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_RSP_ABT_RATE" runat="server" ClientIDMode="Static"/>
             <asp:HiddenField ID="HDsaveid" runat="server" />
             <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static"/>
             <asp:HiddenField ID="hdn_Company_IDD" runat="server" ClientIDMode="Static"/>
             <asp:HiddenField ID="hdn_Manufacture_Name" runat="server" />
             <asp:HiddenField ID="hdn_Exbond_Val" runat="server" />
             <asp:HiddenField ID="hdn_chk_country" runat="server" ClientIDMode="Static"/>
             <asp:HiddenField ID="hdn_Item_Total" runat="server" />
             <asp:HiddenField ID="hdn_Inv_Total" runat="server" />    
             <asp:HiddenField ID="hdn_Direct_Exbond_YN" runat="server" />    
             <asp:HiddenField ID="hdn_source" runat="server" />   
             <asp:HiddenField ID="hdn_SW_codes" runat="server" />                     
             <asp:HiddenField ID="hdn_ADD_SLNO" runat="server" />
             <asp:HiddenField ID="hdn_FTA_Transit_chk" runat="server" ClientIDMode="Static"/>
             <asp:HiddenField ID="hdn_chk_Transit_country" runat="server" ClientIDMode="Static"/>
             <asp:HiddenField ID="hdn_chk_Source_country" runat="server" ClientIDMode="Static"/>
             <asp:HiddenField ID="hdn_chk_Manu_country" runat="server" ClientIDMode="Static"/>
             <asp:HiddenField ID="hdn_Inner_tab_Menu" runat="server"  ClientIDMode="Static"/>     
             <asp:HiddenField ID="hdn_Jobno" runat="server" />  
             <asp:HiddenField ID="hdn_Info_UQC" runat="server" ClientIDMode="Static"/>    

             

             <asp:HiddenField ID="hdn_GeneralDescSame" runat="server" ClientIDMode="Static"/>

             <asp:HiddenField ID="hdn_CTH_IGST_Notn" runat="server" ClientIDMode="Static"/>

               

             
            <script type="text/javascript">

                jQuery(document).ready(function () {

                    jQuery("#form1").validationEngine();
                });


                function checkHELLO(field, rules, i, options) {
                    if (field.val() != "HELLO") {

                        return options.allrules.validate2fields.alertText;
                    }
                }
                $(function () {
                    $(document).keyup(function (e) {
                        var key = (e.keyCode ? e.keyCode : e.charCode);
                        if (key == 112) {

                            document.getElementById('item_magnify').style.display = 'block';
                        }
                        if (key == 113) {

                            document.getElementById('item_magnify').style.display = 'none';
                        }
                    });
                });
            </script>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9', 'page-10', 'page-11', 'page-12']);
            </script>
        </ContentTemplate>
       
    </asp:UpdatePanel>


     <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>
      <asp:modalpopupextender ID="MPEU" runat="server" TargetControlID="HDF"
        PopupControlID="MessageDivupdated"  
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDF" runat="server" />

    <asp:Panel ID="MessageDivupdated" runat="server" CssClass="modalPopup" align="center" style="padding-left:0px;width: 280px; height:205px;display: none;" BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:310px;height:205px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="Label2" runat="server" Text="Saved Successfully."></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td align="center">
                     <asp:Label ID="Label1" runat="server" Text="Add Next Item. Yes / No"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td style="padding-left: 100px; padding-top: 10px;">
                     <asp:Button ID="btnYes" runat="server" Text="Yes" OnClick="btnYes_Click" CausesValidation="false" />&nbsp;&nbsp;
                     <asp:Button ID="btnNo" runat="server" Text="No" OnClientClick="return HideModalPopup()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
             <tr>
             <td>
             ---------------------------------------------------
             </td>
             </tr>
              </table>
         <table>
             <tr>
                 <td>
                     Total Invoice Amount:
                 </td>
                 <td>
                    <b>:</b> 
                 </td>
                 <td>
                     <asp:TextBox ID="ltInv_amt" Width="70px" ReadOnly="true" runat="server" ForeColor="Black" BackColor="#F2F2F2" style="text-align: right;border-bottom: 1px solid white; border-left:0px solid white; border-right:0px solid white; border-top:0px solid white;"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     Total Item Amount:
                 </td>
                 <td>
                    <b>:</b> 
                 </td>
                 <td>
                     <asp:TextBox ID="txtitem_amt" Width="70px"  ReadOnly="true" runat="server" ForeColor="Black" BackColor="#F2F2F2" style="text-align: right;border-bottom: 1px solid black; border-left:0px solid white; border-right:0px solid white; border-top:0px solid white;"></asp:TextBox>
                 </td>
             </tr>
             <tr>
                 <td>
                     Balance Invoice Amount:
                 </td>
                 <td>
                    <b>:</b> 
                 </td>
                 <td>
                     <asp:TextBox ID="txtbal" Width="70px"  runat="server" ReadOnly="true" ForeColor="Black" BackColor="#F2F2F2" style="text-align: right;border-bottom: 1px solid black; border-left:0px solid white; border-right:0px solid white; border-top:0px solid white;"></asp:TextBox>
                 </td>
             </tr>
             
         </table>
     </div>
    
    </asp:Panel>

  <%-- ---------------------------------------------------------ModelpopUp---2------------------------------------------------------------------------------%>



   <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />
     <asp:HiddenField ID="hdn_companyID" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup" align="center" style="padding-left:0px;width: 280px; height:105px;display: none;" BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:310px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="Label3" runat="server" Text="Item Not Saved."></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td align="center">
                     <asp:Label ID="Label4" runat="server" Text="Product is Higher than Invoice Value."></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td style="padding-left: 130px; padding-top:10px;">
                     <asp:Button ID="Button2" runat="server" Text="Ok" OnClientClick="return HideModalPopup_U()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>


        <%-- ---------------------------------------------------------ModelpopUp---1------------------------------------------------------------------------------%>

       <asp:modalpopupextender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB"
        PopupControlID="MessageDivupdated_Job" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU_JOB" runat="server" />

    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text=""></asp:Label>
                 </td>
             </tr>
             
             <tr>
                 <td style="padding-left: 125px; padding-top:10px;">
                     <asp:Button ID="Button1" runat="server" Text="Ok" OnClientClick="return HideModalPopup_Job()"
                         CausesValidation="false" UseSubmitBehavior="false" />
                 </td>
             </tr>
         </table>
     </div>
    
    </asp:Panel>
     <%-- ---------------------------------------------------------End ModelpopUp---1------------------------------------------------------------------------------%>


    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/jquery.textchange.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Autotab.js" type="text/javascript"></script>
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

        function validateLimit(obj, divID, maxchar) {

            objDiv = get_object(divID);

            if (this.id) obj = this;

            var remaningChar = maxchar - trimEnter(obj.value).length;

            if (objDiv.id) {
                objDiv.innerHTML = remaningChar + "";
            }
            if (remaningChar <= 0) {
                obj.value = obj.value.substring(maxchar, 0);
                if (objDiv.id) {
                    objDiv.innerHTML = "0 ";
                }
                return false;
            }
            else
            { return true; }
        }
        function get_object(id) {
            var object = null;
            if (document.layers) {
                object = document.layers[id];
            } else if (document.all) {
                object = document.all[id];
            } else if (document.getElementById) {
                object = document.getElementById(id);
            }
            return object;
        }

        function trimEnter(dataStr) {
            return dataStr.replace(/(\r\n|\r|\n)/g, "");
        }
        
    </script>
    
     <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
    <script src="../js/Import_Jscript/IMP_Single_Window.js" type="text/javascript"></script>
   
    <script type="text/javascript">
        $(document).ready(function () {
            /* gridviewScroll();*/

            var totalRows = $("#<%=gv_ItemDetails.ClientID %> tr").length;
            var lastProductId = $("#<%=gv_ItemDetails.ClientID %> tr:last").children("td:first").html();


            if (totalRows > 2) {

                gridviewScroll();

            }
            else {

                if (lastProductId > 0) {
                    gridviewScroll();
                }
                else {
                    if (lastProductId > 0) {
                        gridviewScroll();
                    }
                    else {

                        document.getElementById('<%=gv_ItemDetails.ClientID %>').style.width = "100%";
                        document.getElementById('<%=gv_ItemDetails.ClientID %>').style.overflow = "100%";
                    }

                }
            }
        });

        function gridviewScroll() {
            gridView1 = $('#<%=gv_ItemDetails.ClientID %>').gridviewScroll({

                width: 720,
                height: 182,
                railcolor: "#F0F0F0",
                barcolor: "#CDCDCD",
                barhovercolor: "#606060",
                bgcolor: "#F0F0F0",
                freezesize: 1,
                arrowsize: 30,
                varrowtopimg: "../GridScroll_Images/arrowvt.png",
                varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                harrowleftimg: "../GridScroll_Images/arrowhl.png",
                harrowrightimg: "../GridScroll_Images/arrowhr.png",
                headerrowcount: 1,
                railsize: 16,
                barsize: 15

            });
        }

	</script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtEndUse').focus(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtEndUse').change(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtEndUse').keyup(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtEndUse').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });

        function Item_desc(val) {

            var data = val;

            if (data == '') {
                $('#txtEndUse').val('');
            }
            if (data.indexOf("-") != -1) {

                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtEndUse').val(before);
                $('#hdn_txtEndUse').val(after);

            }
            else {

            }
        }
  </script>
  <script type="text/javascript">
      function Duty_Cal() {

          var myWindow;
          var RITC = document.getElementById("txtCTH_No").value;
         // window.open("https://www.old.icegate.gov.in/Webappl/cdc_duty_details.jsp?cth_duty_nw=72011000&cntrycd=CN", "", "_self");
          var link = "https://www.old.icegate.gov.in/Webappl/cdc_duty_details.jsp?cth_duty_nw=" + RITC + "&cntrycd=";
          window.open(link, "", "_self");
      }
     </script>

     <script type="text/javascript">
         $(document).ready(function () {
             $('#txtCTH_No').focus(function () {
                 //------------------15-feb-2015-------------------------------------------------------
                 PageMethods.Get_CTH_Info_Uqc(document.getElementById("txtCTH_No").value, OnSuccess_Info_Uqc);
                 function OnSuccess_Info_Uqc(response, userContext, methodName) {

                     $('#txt_Info_Uqc').val(response);
                     $('#hdn_Info_UQC').val(response);

                     if (document.getElementById("txtQtyCode").value == document.getElementById("txt_Info_Uqc").value) {
                         $('#txt_Info_Msr').val(document.getElementById("txtItemQty").value);
                     }
                     else {
                        //$('#txt_Info_Msr').val('');
                     }
                 }
                 //---------------------------------------------------------------------------
             });
             $('#txtCTH_No').change(function () {
                 //------------------15-feb-2015-------------------------------------------------------
                 PageMethods.Get_CTH_Info_Uqc(document.getElementById("txtCTH_No").value, OnSuccess_Info_Uqc);
                 function OnSuccess_Info_Uqc(response, userContext, methodName) {

                     $('#txt_Info_Uqc').val(response);
                     $('#hdn_Info_UQC').val(response);

                     if (document.getElementById("txtQtyCode").value == document.getElementById("txt_Info_Uqc").value) {
                         $('#txt_Info_Msr').val(document.getElementById("txtItemQty").value);
                     }
                     else {
                          //$('#txt_Info_Msr').val('');
                     }
                 }
                 //---------------------------------------------------------------------------
             });
             $('#txtCTH_No').keyup(function () {

                 //------------------15-feb-2015-------------------------------------------------------
                 PageMethods.Get_CTH_Info_Uqc(document.getElementById("txtCTH_No").value, OnSuccess_Info_Uqc);
                 function OnSuccess_Info_Uqc(response, userContext, methodName) {

                     $('#txt_Info_Uqc').val(response);
                     $('#hdn_Info_UQC').val(response);

                     if (document.getElementById("txtQtyCode").value == document.getElementById("txt_Info_Uqc").value) {
                         $('#txt_Info_Msr').val(document.getElementById("txtItemQty").value);
                     }
                     else {
                          //$('#txt_Info_Msr').val('');
                     }
                 }
                 //---------------------------------------------------------------------------
             });
             $('#txtCTH_No').keydown(function () {

                 //------------------15-feb-2015-------------------------------------------------------
                 PageMethods.Get_CTH_Info_Uqc(document.getElementById("txtCTH_No").value, OnSuccess_Info_Uqc);
                 function OnSuccess_Info_Uqc(response, userContext, methodName) {

                     $('#txt_Info_Uqc').val(response);
                     $('#hdn_Info_UQC').val(response);

                     if (document.getElementById("txtQtyCode").value == document.getElementById("txt_Info_Uqc").value) {
                         $('#txt_Info_Msr').val(document.getElementById("txtItemQty").value);
                     }
                     else {
                          //$('#txt_Info_Msr').val('');
                     }
                 }
                 //---------------------------------------------------------------------------

             });

             //-----------------------------------------------------------

         });

       </script>



     <script type="text/javascript">
         $(document).ready(function () {

             $('#txt_Addl_GSI_NOTN').focus(function () {

                 var data1 = $(this).val();
                 if (data1 == '011/2006') {

                     $('#txt_Addl_GSI_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_GSI_RATE').val('');
                 }

             });
             $('#txt_Addl_GSI_NOTN').change(function () {

                 var data1 = $(this).val();
                 if (data1 == '011/2006') {

                     $('#txt_Addl_GSI_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_GSI_RATE').val('');
                 }
             });
             $('#txt_Addl_GSI_NOTN').keyup(function () {

                 var data1 = $(this).val();
                 if (data1 == '011/2006') {

                     $('#txt_Addl_GSI_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_GSI_RATE').val('');
                 }


             });
             $('#txt_Addl_GSI_NOTN').keydown(function () {

                 var data1 = $(this).val();
                 if (data1 == '011/2006') {

                     $('#txt_Addl_GSI_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_GSI_RATE').val('');
                 }

             });
             //---------------------------------------------------------------------------
             $('#txt_Addl_SHE11_NOTN').focus(function () {

                 var data1 = $(this).val();
                 if (data1 == '009/2006') {

                     $('#txt_Addl_SHE11_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_SHE11_RATE').val('');
                 }

             });
             $('#txt_Addl_SHE11_NOTN').change(function () {

                 var data1 = $(this).val();
                 if (data1 == '009/2006') {

                     $('#txt_Addl_SHE11_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_SHE11_RATE').val('');
                 }
             });
             $('#txt_Addl_SHE11_NOTN').keyup(function () {

                 var data1 = $(this).val();
                 if (data1 == '009/2006') {

                     $('#txt_Addl_SHE11_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_SHE11_RATE').val('');
                 }


             });
             $('#txt_Addl_SHE11_NOTN').keydown(function () {

                 var data1 = $(this).val();
                 if (data1 == '009/2006') {

                     $('#txt_Addl_SHE11_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_SHE11_RATE').val('');
                 }

             });
             //---------------------------------------------------------------------------
             $('#txt_Addl_TTA_NOTN').focus(function () {

                 var data1 = $(this).val();
                 if (data1 == '031/2004') {

                     $('#txt_Addl_TTA_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_TTA_RATE').val('');
                 }

             });
             $('#txt_Addl_TTA_NOTN').change(function () {

                 var data1 = $(this).val();
                 if (data1 == '031/2004') {

                     $('#txt_Addl_TTA_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_TTA_RATE').val('');
                 }
             });
             $('#txt_Addl_TTA_NOTN').keyup(function () {

                 var data1 = $(this).val();
                 if (data1 == '031/2004') {

                     $('#txt_Addl_TTA_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_TTA_RATE').val('');
                 }


             });
             $('#txt_Addl_TTA_NOTN').keydown(function () {

                 var data1 = $(this).val();
                 if (data1 == '031/2004') {

                     $('#txt_Addl_TTA_RATE').val('0.00');
                 }
                 else {
                     $('#txt_Addl_TTA_RATE').val('');
                 }

             });
             //---------------------------------------------------------------------------

             $('#txtCTH_No').focus(function () {
                 PageMethods.Get_SW_CTH_CODE_MASTER(document.getElementById("txtCTH_No").value, OnSuccess);
             });
             $('#txtCTH_No').keyup(function () {
                 PageMethods.Get_SW_CTH_CODE_MASTER(document.getElementById("txtCTH_No").value, OnSuccess);
             });

             PageMethods.Get_SW_CTH_CODE_MASTER(document.getElementById("txtCTH_No").value, OnSuccess);
             PageMethods.Get_CTH_Rate(document.getElementById("txtCTHNO").value, OnSuccesstxtCTHNO);
             PageMethods.Get_RSP_Rate(document.getElementById("txtCETH_No").value, OnSuccesstxtCETH_No);

             PageMethods.Get_CETH_Rate(document.getElementById("txtCETH_No").value, OnSuccesstxtCETH_No_Rate);

             // $('#txtCETH_No').keyup(function () {
             // PageMethods.Get_CETH_Rate(document.getElementById("txtCETH_No").value, OnSuccesstxtCETH_No_Rate);

             //  }



             //---------------------------------------------------------------------------

             function OnSuccess(response, userContext, methodName) {
                 $('#lbl_RITC_SW_Code').text(response);
                 $('#hdn_SW_codes').val(response);
             }
             function OnSuccesstxtCTHNO(response, userContext, methodName) {
                 if (response != '') {
                     $('#lblCTH_Rate').text(response);
                 }
                 else {
                     $('#lblCTH_Rate').text('0.00');
                 }
             }

             var BE_Type = document.getElementById("hdn_Exbond_Val").value;
             function OnSuccesstxtCETH_No(response, userContext, methodName) {

                 if (response != '') {
                     if (BE_Type == 'Ex-Bond') {
                         $('#lbl_MRP_Rate').text('MRP Applicable ' + response + '%');
                     }

                 }
                 else {
                     $('#lbl_MRP_Rate').text('');
                 }
             }

             function OnSuccesstxtCETH_No_Rate(response, userContext, methodName) {
                 if (response != '') {
                     //  alert(response);
                     if (response.indexOf("~~") != -1 && response.indexOf("~~") != '') {

                         var s = response.split('~~');

                         var CETH = s[0];
                         var CETH_Rate = s[1];
                         var spl_amt = s[2];
                         var spl_unit = s[3];
                         var SIA_Rate = s[4];
                         var CETH_Cess_Amts = s[5];
                         var CETH_Cess_unit = s[6];
                         var CETH_Flag = s[7];

                         $('#lblCETH_Rate').html(CETH_Rate);

                         var comp_id = document.getElementById("hdn_Company_IDD");
                         // alert(CETH);

                         if (comp_id.value == '1' || comp_id.value == '10' || comp_id.value == '2038') {

                             if (CETH == '27101949' || CETH == '27101930') {
                                 if (document.getElementById("txt_Exc_AIDC_RATE").value == '') {
                                     document.getElementById("txt_Exc_AIDC_SPL").value = '4.00';
                                     document.getElementById("txt_Exc_AIDC_SPL_UNIT").value = spl_unit;
                                 }

                                 if (document.getElementById("txt_CVD_NOTN").value == '') {
                                     document.getElementById("txt_CVD_SPL").value = spl_amt;
                                     document.getElementById("txt_CVD_UNIT").value = spl_unit;
                                 }

                                 if (document.getElementById("txtinfra_cess_Notn").value == '') {
                                     document.getElementById("txtinfra_cess_SPL").value = CETH_Cess_Amts;
                                     document.getElementById("txtinfra_cess_SPL_UNIT").value = spl_unit;
                                 }

                                 // $('#lbl_infra_SplAmt').html('  Rs.' + CETH_Cess_Amts + ' per ltr.');

                                 if (SIA_Rate != '-1.00') {
                                     document.getElementById("txt_Addl_GSI_SPL").value = SIA_Rate;
                                     document.getElementById("txt_Addl_GSI_UNIT").value = CETH_Cess_unit;
                                 }
                                 else {
                                     document.getElementById("txt_Addl_GSI_SPL").value = '';
                                     document.getElementById("txt_Addl_GSI_UNIT").value = '';
                                 }
                             }
                             else {
                                 if (document.getElementById("txt_Exc_AIDC_NOTN").value == '') {
                                     document.getElementById("txt_Exc_AIDC_RATE").value = '';
                                 }
                             }
                         }

                     }
                     else {
                         //                         alert('x');
                         $('#lblCETH_Rate').html(res);

                         if (document.getElementById("txt_Exc_AIDC_NOTN").value == '') {
                             document.getElementById("txt_Exc_AIDC_RATE").value = '';
                         }
                         if (document.getElementById("txtinfra_cess_Notn").value == '') {
                             document.getElementById("txtinfra_cess_SPL").value = '';
                             document.getElementById("txtinfra_cess_SPL_UNIT").value = '';
                         }

                     }
                 }
                 else {
                     //                     alert('z');
                     $('#lblCETH_Rate').text('0.00');

                     if (document.getElementById("txt_Exc_AIDC_NOTN").value == '') {
                         document.getElementById("txt_Exc_AIDC_RATE").value = '';
                     }
                     if (document.getElementById("txtinfra_cess_Notn").value == '') {
                         document.getElementById("txtinfra_cess_SPL").value = '';
                         document.getElementById("txtinfra_cess_SPL_UNIT").value = '';
                     }

                 }

             }
             // }


         });
  </script>

    <script type="text/javascript" language="jscript">
        $(document).ready(function () {
            $('#txt_IGST_LEVY_NOTN').focusout(function () {
                if ($('#txt_IGST_LEVY_NOTN').val() != '') {
                    $('#txt_IGST_LEVY_COMPENSATION_CESS_NOTN').val('001/2017');
                    $('#txt_IGST_LEVY_COMPENSATION_CESS_SLNO').val('56');
                    $('#txt_IGST_LEVY_COMPENSATION_CESS_RATE').val('0.00');
                    $('txt_IGST_LEVY_COMPENSATION_CESS_SPL').val('-1.000000');
                }
                else {
                    $('#txt_IGST_LEVY_COMPENSATION_CESS_NOTN').val('');
                    $('#txt_IGST_LEVY_COMPENSATION_CESS_SLNO').val('');
                    $('#txt_IGST_LEVY_COMPENSATION_CESS_RATE').val('');
                    $('#txt_IGST_LEVY_COMPENSATION_CESS_SPL').val('');
                }
            });
        });

    </script>

<%--    ------------------------------------------------------------%>
<script type="text/javascript">
    $(document).ready(function () {

        //-------------Qty----------------------
        $('#txtItemQty').keyup(function () {

            var e;
            var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInvoice_SlNo, HiddenField1, txtItem_UnitPrice;

            hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
            txtItem_Amount = document.getElementById("txtItem_Amount").value;
            hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
            e = document.getElementById("ddlInvoice_SlNo");
            ddlInvoice_SlNo = e.options[e.selectedIndex].text;
            HiddenField1 = document.getElementById("HiddenField1").value;
            txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;
            var txtItemQty = document.getElementById("txtItemQty").value;
            var BEType_Exbond = document.getElementById("hdn_Exbond_Val").value;

            if (hdn_Item_Edit != "") {
                if (hdn_ITEM_AOUNT == "") {
                    TOTAL = 0;
                }
                else {
                    TOTAL = parseFloat(hdn_ITEM_AOUNT);
                }
            }
            else {
                if (txtItem_Amount == "") {
                    TOTAL = 0;
                }
                else {
                    TOTAL = parseFloat(txtItem_Amount);
                }
            }


            var Sum_Inv_Amt = 0, Sum_Item_Amt = 0, Unit_Price = 0, Amount = 0, PMV_Amount = 0;

            Sum_Inv_Amt = document.getElementById("hdn_Inv_Total").value;
            Sum_Item_Amt = document.getElementById("hdn_Item_Total").value;

            //----------------New Val------05-----------------
            var regex = /(?:\d*\.\d{1,2}|\d+)$/;
            if (regex.test(txtItemQty)) {
                if (parseFloat(txtItemQty) > 0) {
                    //Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                }
                else {
                    txtItemQty = '0';
                }
            } else {
                txtItemQty = '0';
            }
            //------------------------------------------

            if (hdn_Item_Edit == 'U') {


                if (txtItemQty == '' || txtItemQty == '0') {
                    Unit_Price = '0';
                }
                else {
                    Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(6);
                }

                //Amount = (parseFloat(txtItemQty) * parseFloat(Unit_Price)).toFixed(6);
                Amount = (parseFloat(txtItemQty) * parseFloat(Unit_Price)).toFixed(2);

                if (txtItemQty != '0') {
                    document.getElementById("txtItem_Amount").value = Amount;
                    document.getElementById("txtItem_UnitPrice").value = Unit_Price;
                }
                //----------------New Val------05-----------------
                else {
                    document.getElementById("txtItem_Amount").value = '';
                    document.getElementById("txtItem_UnitPrice").value = '';
                    document.getElementById("txtItemQty").focus();
                }

                if (txtItemQty == '') {
                    document.getElementById("txtItem_Amount").value = '';
                    document.getElementById("txtItem_UnitPrice").value = '';
                    document.getElementById("txtItemQty").focus();
                }

            } //-----------
            else {


                if (txtItemQty == '' || txtItemQty == '0') {
                    Unit_Price = '0';
                }
                else {
                    Unit_Price = ((parseFloat(Sum_Inv_Amt) - parseFloat(Sum_Item_Amt)) / parseFloat(txtItemQty)).toFixed(6);
                }

                //Amount = (parseFloat(txtItemQty) * parseFloat(Unit_Price)).toFixed(6);
                Amount = (parseFloat(txtItemQty) * parseFloat(Unit_Price)).toFixed(2);

                if (txtItemQty != '0') {
                    document.getElementById("txtItem_Amount").value = Amount;
                    document.getElementById("txtItem_UnitPrice").value = Unit_Price;
                }
                //----------------New Val------05-----------------
                else {
                    document.getElementById("txtItem_Amount").value = '';
                    document.getElementById("txtItem_UnitPrice").value = '';
                    document.getElementById("txtItemQty").focus();
                }
                if (txtItemQty == '') {
                    document.getElementById("txtItem_Amount").value = '';
                    document.getElementById("txtItem_UnitPrice").value = '';
                    document.getElementById("txtItemQty").focus();
                }

            } //-----------else--E
            if (BEType_Exbond == 'Ex-Bond') {
                if (document.getElementById("hdn_Direct_Exbond_YN").value == '') {
                    document.getElementById("txtItem_UnitPrice").disabled = true;
                    document.getElementById("txtItem_Amount").disabled = true;
                }
            }
            else {


            }

        });
        //-----------------------------------

        //-----------Qty------------------------
        $('#txtItem_UnitPrice').keyup(function () {
            var e;
            // call server side method
            var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInvoice_SlNo, HiddenField1, txtItemQty;

            hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
            txtItem_Amount = document.getElementById("txtItem_Amount").value;
            hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
            e = document.getElementById("ddlInvoice_SlNo");
            ddlInvoice_SlNo = e.options[e.selectedIndex].text;

            HiddenField1 = document.getElementById("HiddenField1").value;
            txtItemQty = document.getElementById("txtItemQty").value;



            var txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;

            var Item_Amt = 0;

            //----------------New Val------05-----------------
            var regex = /(?:\d*\.\d{1,2}|\d+)$/;
            if (regex.test(txtItemQty)) {
                if (parseFloat(txtItemQty) > 0) {
                    //Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                }
                else {
                    txtItemQty = '0';
                }
            } else {
                txtItemQty = '0';
            }

            //------------------------------------------
            if (regex.test(txtItem_UnitPrice)) {
                if (parseFloat(txtItem_UnitPrice) > 0) {
                    //Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                }
                else {
                    txtItem_UnitPrice = '0';
                }
            } else {
                txtItem_UnitPrice = '0';
            }
            //------------------------------------------


            if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".") {
                //Item_Amt = (parseFloat(txtItemQty) * parseFloat(txtItem_UnitPrice)).toFixed(6);
                Item_Amt = (parseFloat(txtItemQty) * parseFloat(txtItem_UnitPrice)).toFixed(2);
            }
            document.getElementById("txtItem_Amount").value = Item_Amt;

        });



        //-----------txtunit price_2------------------------

        $('#txtItem_UnitPrice').change(function () {
            var e;
            // call server side method
            var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInvoice_SlNo, HiddenField1, txtItemQty;

            hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
            txtItem_Amount = document.getElementById("txtItem_Amount").value;
            hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
            e = document.getElementById("ddlInvoice_SlNo");
            ddlInvoice_SlNo = e.options[e.selectedIndex].text;

            HiddenField1 = document.getElementById("HiddenField1").value;
            txtItemQty = document.getElementById("txtItemQty").value;

            // var txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;

            var b = document.getElementById("txtItem_UnitPrice").value;
            if (b.charAt(b.length - 1) == '.') {
                document.getElementById("txtItem_UnitPrice").value = Number.parseFloat(document.getElementById("txtItem_UnitPrice").value).toFixed(2);
            }

            var txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;

            var Item_Amt = 0;

            //----------------New Val------05-----------------
            var regex = /(?:\d*\.\d{1,2}|\d+)$/;
            if (regex.test(txtItemQty)) {
                if (parseFloat(txtItemQty) > 0) {
                    //Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                }
                else {
                    txtItemQty = '0';
                }
            } else {
                txtItemQty = '0';
            }

            //------------------------------------------
            if (regex.test(txtItem_UnitPrice)) {
                if (parseFloat(txtItem_UnitPrice) > 0) {
                    //Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                }
                else {
                    txtItem_UnitPrice = '0';
                }
            } else {
                txtItem_UnitPrice = '0';
            }
            //------------------------------------------


            if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".") {
                //Item_Amt = (parseFloat(txtItemQty) * parseFloat(txtItem_UnitPrice)).toFixed(6);
                Item_Amt = (parseFloat(txtItemQty) * parseFloat(txtItem_UnitPrice)).toFixed(2);
            }
            document.getElementById("txtItem_Amount").value = Item_Amt;

        });



        //-----------txtItem_Amount------------------------

        $('#txtItem_Amount').keyup(function () {

            var e;
            var hdn_Item_Edit, txtItem_Amount, hdn_ITEM_AOUNT, ddlInvoice_SlNo, HiddenField1, txtItemQty;
            hdn_Item_Edit = document.getElementById("hdn_Item_Edit").value;
            txtItem_Amount = document.getElementById("txtItem_Amount").value;
            hdn_ITEM_AOUNT = document.getElementById("hdn_ITEM_AOUNT").value;
            e = document.getElementById("ddlInvoice_SlNo");
            ddlInvoice_SlNo = e.options[e.selectedIndex].text;
            HiddenField1 = document.getElementById("HiddenField1").value;
            txtItemQty = document.getElementById("txtItemQty").value;
            var txtItem_UnitPrice = document.getElementById("txtItem_UnitPrice").value;
            var Amt = 0;


            if (txtItemQty != "" && txtItem_Amount != "" && txtItemQty != "." && txtItem_Amount != ".") {
                //-----------------*****----------------------------------------------------------------------------
                if (txtItem_UnitPrice != "" && txtItem_UnitPrice != ".") {

                    //------------------------------------------------------------------
                    var regex = /(?:\d*\.\d{1,2}|\d+)$/;
                    if (regex.test(txtItemQty)) {
                        if (parseFloat(txtItemQty) > 0) {
                            //Unit_Price = ((parseFloat(Sum_Inv_Amt) - (parseFloat(Sum_Item_Amt) - parseFloat(TOTAL))) / parseFloat(txtItemQty)).toFixed(5);
                        }
                        else {
                            txtItemQty = '0';
                        }
                    } else {
                        txtItemQty = '0';
                    }
                    //------------------------------------------------------------------

                    if (txtItemQty == '' || txtItemQty == '0') {
                        Amt = '0';
                    }
                    else {
                        Amt = (txtItem_Amount / txtItemQty).toFixed(6);
                    }
                }

            } //-----------------*****----------------------------------------------------------------------------

            document.getElementById("txtItem_Amount").value = txtItem_Amount;
            document.getElementById("txtItem_UnitPrice").value = Amt;

        });
        //-----------------------------------

        //-----------------------------------


    });
  </script>


  <script type="text/javascript">
      $(document).ready(function () {
          var ddl, Inv_no;
          ddl = document.getElementById("ddlInvoice_SlNo");
          Inv_no = ddl.options[ddl.selectedIndex].text;
          Load_Inv_Item_Val(Inv_no, '1');
      });

      //-------------------------------------------------------------------
      function Load_Inv_Item_Val(Inv_no, dest) {
          PageMethods.Get_Inv_Item_Tot_Val(Inv_no, CallSuccess_Inv_Item_Tot, CallFailed, dest);
      }

      function CallSuccess_Inv_Item_Tot(res, destCtrl) {
          var data = res;
          if (data.indexOf("~~") != -1) {

              var s = data.split('~~');
              var before = s[0];
              var after1 = s[1];

              if (before != '') {
                  document.getElementById("hdn_Inv_Total").value = before;
              }
              if (after1 != '') {
                  document.getElementById("hdn_Item_Total").value = after1;
              }
          }
          else {

              document.getElementById("hdn_Inv_Total").value = '';
              document.getElementById("hdn_Item_Total").value = '';
          }
      }
  </script>

  
    <%--  
<script type="text/javascript">
    $(document).ready(function () {

        // document.onkeydown = clickRadio;
        document.onkeypress = click_TABS;
        document.onkeyup = click_TABS;

        function click_TABS(e) {
            //if (window.event);
            if (window.event.ctrlKey)
                var keyCode = window.event.keyCode;       // IE
            else
                var keyCode = e.which;

            if (e.ctrlKey) {
                if (keyCode == 39) {
                    document.getElementById("hdn_source").value = 'Tab_Item';
                    document.getElementById('btnCancel').click();
                }

                if (keyCode == 37) {
                    document.getElementById("hdn_source").value = 'Tab_Item_Prev';
                    document.getElementById('btnCancel').click();
                }
            }
        }
    });
</script>--%>



    <script type="text/javascript">
        $(document).ready(function () {
            // document.onkeydown = clickRadio;
            document.onkeypress = click_TABS;
            document.onkeyup = click_TABS;

            function click_TABS(e) {
                //if (window.event);
                if (window.event.ctrlKey)
                    var keyCode = window.event.keyCode;       // IE

                else
                    var keyCode = e.which;
                var cnt = 0;

                //alert(e.ctrlKey);
                if (e.ctrlKey) {
                    if (keyCode == 39) {
                        //document.getElementById("hdn_source").value = 'Tab_Invoice';
                       
                        if (document.getElementById("hdn_Inner_tab_Menu").value == '') {
                            document.getElementById("hdn_Inner_tab_Menu").value = 'ItemMain';
                            cnt = cnt + 1;
                        }
                        else {
                            cnt = cnt + 1;
                        }

                        //alert(cnt + 'CNT');
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'ItemMain') {
                            if (cnt == 1) {
                                document.getElementById('General').click();
                                cnt = cnt + 1;
                                //alert(cnt + 'IMD');
                            }
                        }
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'General') {
                            if (cnt == 1) {
                                document.getElementById('CTH').click();
                                cnt = cnt + 1;
                            }
                        }
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'CTH') {
                            if (cnt == 1) {
                                document.getElementById('CETH').click();
                                cnt = cnt + 1;
                            }
                        }
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'CETH') {
                            if (cnt == 1) {
                                document.getElementById('IGST').click();
                                cnt = cnt + 1;
                            }
                        }
                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'IGST') {
                            if (cnt == 1) {
                                document.getElementById('Other_Duty').click();
                                cnt = cnt + 1;
                            }
                        }
                    }

                    if (keyCode == 37) {

                        cnt = cnt + 1;

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'ItemMain') {
                            if (cnt == 1) {
                                document.getElementById("hdn_source").value = 'Tab_Item_Prev';
                                document.getElementById('btnCancel').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'Other_Duty') {
                            if (cnt == 1) {
                                document.getElementById('IGST').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'IGST') {
                            if (cnt == 1) {
                                document.getElementById('CETH').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'CETH') {
                            if (cnt == 1) {
                                document.getElementById('CTH').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'CTH') {
                            if (cnt == 1) {
                                document.getElementById('General').click();
                                cnt = cnt + 1;
                            }
                        }

                        if (document.getElementById("hdn_Inner_tab_Menu").value == 'General') {
                            if (cnt == 1) {
                                document.getElementById('ItemMain').click();
                                cnt = cnt + 1;
                            }
                        }
                    }
                }
            }
        });
    </script>




<script type="text/javascript">
    $(document).ready(function () {
        $('#chk_manufacturer').click(function () {
            if ($("input[type=checkbox]").is(":checked")) {
                PageMethods.Get_SupplierDetails(CallSuccess_supplier, CallFailed);
            }
            else {
                document.getElementById("txt_Manufacturer_Add1").value = '';
                document.getElementById("txt_Manufacturer_Add2").value = '';
                document.getElementById("txt_Manufacturer_City").value = '';
                document.getElementById("txt_Manu_Country_Subdiv").value = '';
                document.getElementById("txt_Manufacturer_pincode").value = '';
                document.getElementById("txt_Cus_not_exe_Cen_flag").value = '';
            }
        });
    });

    //-------------------------------------------------------------------

    function CallSuccess_supplier(res, destCtrl) {
        var data = res;
        if (data.indexOf("~~") != -1) {

            var s = data.split('~~');
            var before = s[0];
            var after1 = s[1];
            var after2 = s[2];
            var after3 = s[3];
            var after4 = s[4];

            document.getElementById("txt_Manufacturer_Add1").value = before;
            document.getElementById("txt_Manufacturer_Add2").value = after1;
            document.getElementById("txt_Manufacturer_City").value = after2;
            document.getElementById("txt_Manu_Country_Subdiv").value = after3;
            document.getElementById("txt_Manufacturer_pincode").value = after4;
            document.getElementById("txt_Cus_not_exe_Cen_flag").value = 'C';
        }
    }
  </script>


  <script type="text/javascript">
      $(document).ready(function () {
          $('#ddlAntiDumping_Notn').change(function () {
              var ddlAntiDumping_Notn = $('#ddlAntiDumping_Notn').val();
              alert(ddlAntiDumping_Notn);
              PageMethods.Get_AntiDumping_NOTN_Slno(ddlAntiDumping_Notn, CallSuccess_AntiDumping_NOTN, CallFailed);
          });
      });

      function CallSuccess_AntiDumping_NOTN(res) {
          var data = res;

          var y = res;
          // var x = y.split(/\s+/);
          var x = y.split(',');
          var select = document.getElementById('ddlAntiDumping_Notn_SL');
          $("#ddlAntiDumping_Notn_SL option").remove();


          for (var i = 0; i < x.length - 1; i++) {
              var opt = new Option(x[i], x[i]);
              if (x[i] != '') {
                  select.appendChild(opt);
              }
          }
          document.getElementById('hdn_ADD_SLNO').value = x[0];
      }
    </script>

    <script type="text/javascript">
        function IMP_FTA() {
            NewWindow1('../IMP_Single_Window/Imp_FTA_Bulk.aspx', 'List', '1100', '1024', 'yes');
        }
        function Hide_Excel_Upload() {

            tab_SUPPORTING_DOCS('0');
            return false;
        }

        function Hide_SW_Excel_Upload() {

            tab_SINGLE_WINDOW('0');
            return false;
        }


        function Open_Amend_Flatfile() {
            var amd_type = document.getElementById("ddl_AmendmentType").value;
            var amd_page = 'ITEM';
            var amd_Jobno = document.getElementById("hdn_Jobno").value;
            var amd_Invslno = document.getElementById("ddlInvoice_SlNo").value;
           // alert(amd_Invslno);

            NewWindow1('../Amendment/Import_Amendment.aspx?amd_type=' + amd_type + '&amd_page=' + amd_page + '&amd_Jobno=' + amd_Jobno + '&amd_Invslno=' + amd_Invslno, 'List', '950', '515', 'yes');
        }

        $('#txtItemQty, #txtQtyCode, #txt_Info_Uqc').bind('keyup change focus', function () {
            var _itemQty = document.getElementById('txtItemQty').value;
            var _qtyCode = document.getElementById('txtQtyCode').value;
            var _infoUqc = document.getElementById('txt_Info_Uqc').value;

            if (_itemQty == null || _itemQty == '' || _itemQty == undefined) {
                document.getElementById('txt_Info_Msr').value = '';
                return false;
            }

            if (_qtyCode == 'KGS' && _infoUqc == 'MTS') {
                var result = _itemQty / 1000;
                document.getElementById('txt_Info_Msr').value = result;
                return false;
            }

            if (_qtyCode == 'MTS' && _infoUqc == 'KGS') {
                var result = _itemQty * 1000;
                document.getElementById('txt_Info_Msr').value = result;
                return false;
            }
        })

    </script>
    <script type="text/javascript">
        window.onload = function () {
            $("#txtDescription").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Item_Desc_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtDescription').validationEngine('showPrompt', 'Incorrect Description', 'error', 'topRight', true);
                            } else {
                                jQuery('#txtDescription').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert("Error: " + textStatus);
                        }
                    });
                },
                minLength: 1,
                scroll: true
            });
        };
</script>

<script type="text/javascript">
    function openDutyCalculator() {

        var ritcBox = document.getElementById('txtCTH_No');

        if (!ritcBox || ritcBox.value.trim() === "") {
            alert("Please enter / select a RITC No before opening the Duty Calculator.");
            return false;
        }

        var code = ritcBox.value.replace(/\D/g, '');

        var w = 1100;
        var h = 750;
        var left = (screen.width - w) / 2;
        var top = (screen.height - h) / 8;

        var dutyCalculatorUrl = "https://impexservice.eroyalimpex.co.in/api/DutyCalculator/";

        window.open(
            dutyCalculatorUrl + encodeURIComponent(code),
            "DutyCalWin",
            "width=" + w +
            ",height=" + h +
            ",left=" + left +
            ",top=" + top +
            ",scrollbars=yes,resizable=yes"
        );

        return false;
    }
</script>



    <script type="text/javascript">
        function Imp_RITC_FTA_SAPTA_DutyCalc() {

            var CTH = document.getElementById("txtCTH_No").value;
            var Jobno = document.getElementById("hdn_Jobno").value;
            var Country = document.getElementById("txtCountryOrigin").value;
            var Basic_Notn = document.getElementById("txtBasicNotn").value;

            if (CTH != '') {
                NewWindow1('../Transaction/RITC_Based_FTA_SAPTA_Duty_Calculator.aspx?CTH=' + CTH + '&Jobno=' + Jobno + '&Country=' + Country + '&Basic_Notn=' + Basic_Notn + '', 'List', '1100', '1024', 'yes');
            }
        }
    </script> 

</body>
</html>
