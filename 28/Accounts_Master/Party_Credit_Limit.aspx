<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Party_Credit_Limit.aspx.cs" Inherits="Party_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Party Credit Limit</title>
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
        .Background  
        {  
            background-color: Green;  
            filter: alpha(opacity=90);  
            opacity: 0.8;  
        }  
        .Popup  
        {  
            background-color: #FFE4C4;  
            border-width: 3px;  
            border-style: solid;  
            border-color: #BC8F8F;  
            padding-top: 10px;  
            padding-left: 10px;  
            width: 400px;  
            height: 200px;  
        }
        .Popup_2  
        {  
            background-color: #FFE4C4;  
            border-width: 3px;  
            border-style: solid;  
            border-color: #BC8F8F;  
            padding-top: 10px;  
            padding-left: 10px;  
            width: 500px;  
            height: 280px;  
        }  
        .lbl  
        {  
            font-size:16px;  
            font-style:italic;  
            font-weight:bold;  
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
         }
         function B_G_tab_page3() {

             document.getElementById('page-1').style.display = 'Block';
             document.getElementById('page-2').style.display = 'none';
             document.getElementById('page-3').style.display = 'none';
             document.getElementById('page-4').style.display = 'none';

             document.getElementById("page-6").style.display = 'none';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'block';
             document.getElementById("page-9").style.display = 'none';

             document.getElementById("Page_A").className = 'inactive';
             document.getElementById("Page_B").className = 'inactive';
             document.getElementById("Page_C").className = 'active';
             document.getElementById("Page_D").className = 'inactive';
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

            <div id="innerbox_MidMain_Billing" style="height: 35px;width: 1194px;">
                
                 <div id="mainmastop2container_rght_tag2_txt1" style="width: 120px;">
                        Party Credit Limit
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 80px;">
                            Party Name
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 410px;">
                           <asp:DropDownList ID="ddlPartyName" runat="server" class="chosen-select-deselect"
                                 Style="width: 300px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                 TabIndex="5" OnSelectedIndexChanged="ddlPartyName_SelectedIndexChanged">
                             </asp:DropDownList>
                             &nbsp;
                             <asp:Button ID="btnaddnewParty" runat="server" TabIndex="6" Text="Add Party" OnClientClick="return HideModalPopup()"
                                 CausesValidation="false" UseSubmitBehavior="false" />
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">

                    <div id="tag_label_transact_Src" style="width: 38px;">
                    TDS :
                    </div>
                        <div id="txtcon-m_Exchange" style="width: 95px;margin-top: 0px; color:Blue; font-weight:bold;">
                                <asp:RadioButtonList ID="Rd_TDS_YN" runat="server" TabIndex="7" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                </asp:RadioButtonList>
                        </div>
                        <div id="verslic" style="margin-top: -5px;"></div>
                        <div id="txtcon-m_Exchange" style="width: 60px;">
                        Section
                        </div>
                            <div id="txtcon-m_Exchange" style="width: 110px;">
                                <asp:DropDownList ID="ddl_TDS_Section" runat="server" class="chosen-select-deselect"
                                 Style="width: 108px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                 TabIndex="8" >
                                 <asp:ListItem Text="" Value=""></asp:ListItem>
                                 <asp:ListItem Text="Section A" Value="A"></asp:ListItem>
                                <asp:ListItem Text="Section B" Value="B"></asp:ListItem>
                             </asp:DropDownList>
                            </div>
                             <div id="verslic" style="margin-top: -5px;"></div>
                             <div id="txtcon-m_Exchange" style="width: 40px;">
                             Rate
                             </div>
                             <div id="tag_label_transact_Src" style="width: 50px;">
                             <asp:TextBox ID="txt_TDS_Rate" runat="server" MaxLength="17" Width="48px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="9" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" BackColor="#FFFFC2"></asp:TextBox>
                             </div>
                    </div>
                   <div id="popupwindow_closebut_right_new">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    </div>
              </div> 
              
            <%-- -------------------------------------Tab--------------------------------------------------------%>


         <div class="content" id="page-1" style="margin-top:-28px;width:1194px;">
                        
          <div id="innerbox_MidMain_Trans_new" style="height:535px; width:1194px; margin-left:-16px; margin-top:-15px;">
                <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span>General </span></a></li>

                     <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                        id="Page_C" runat="server" ><span>Validity </span></a></li>

                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server"  visible="false">
                        <span>Charge details</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        <span> Gen -4 </span></a></li>

                        <span style="color:black;font-size:12px;"> &nbsp; 
                            <asp:Literal ID="lbl_Created_Modified" runat="server"></asp:Literal>
                         </span>
                </ol>
                  <%----------------------------General---------------------------------------------------%>
                    <div   class="content" id="page-6" style="height:492px;" >

                    <%--------------------------------------------------------------------------------------------%>
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:508px;margin-top: -16px; margin-left:-18px; color:Red;width: 1185px;">
                        <div id="tag_transact_src_inner" style="width: 1185px;height:508px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1185px;height:508px;">
                    <%---------------------------------------Row 1-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1185px;height:35px;">
                            <div id="txt_container_Transact_Main_l" style="width: 200px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                 Credit Date 
                                </div>
                                
                                <div id="txtcon-m_Exchange" style="width: 100px;"> 
                                   <asp:TextBox ID="txtEntry_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="15"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txtEntry_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txtEntry_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 430px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  Particulars
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 330px;">
                                   <asp:TextBox ID="txt_Particulars" runat="server" MaxLength="50" onkeyup="autotab(this);" TabIndex="16"
                                                   Width="320px" CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                                </div>
                            </div>
                            
                              
                             <div id="txt_container_Transact_Main_l" style="width: 210px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                  Credit Amount
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 110px;">
                                   <asp:TextBox ID="txt_Credit_Amount" runat="server" MaxLength="17" Width="100px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="17" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" BackColor="#FFFFC2"></asp:TextBox>
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 210px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                  Debit Amount
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 110px;">
                                    <asp:TextBox ID="txt_Debit_Amount" runat="server" MaxLength="17" Width="100px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="18" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" BackColor="#FFFFC2"></asp:TextBox>

                                            
                                </div>
                            </div>

                        </div>
                        <%---------------------------------------Row 4-----------------------------------------%>
                       
                        <%--------------------------------------Row 5-----------------------------------------%>
                        <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                 <div id="innerbox_transac_bot_inn" style="width: 1050px">
                     <div id="newbu">
                         <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                             TabIndex="122" OnClick="btnNew_Click1" />
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

                    <div id="editbu"> &nbsp;&nbsp;</div>
                     <div id="txt_container_Transact_Main_l" style="width: 200px;">
                                <div id="tag_label_transact_Src" style="width: 100px;">
                                  Total Amount :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 90px; margin-top:5px;text-align:left;">
                                   <span id="lb" style=" color:Green; font-weight:bold; text-align:left;" runat="server"> <asp:Literal ID="lbl_Total_amt" runat="server"></asp:Literal></span>
                                </div>
                            </div>


                 </div>
             </div>
                        <%------------------------------grid---------------------------- ------------------------------------%>
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="margin-top:15px;height:420px; width:1175px;">
                                <asp:GridView ID="gv" runat="server" DataKeyNames="ID,PARTY_ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                    ShowHeaderWhenEmpty="True" PageSize="12" AllowPaging="True" OnRowDataBound="gv_RowDataBound"
                                    OnPageIndexChanging="gv_PageIndexChanging" OnSelectedIndexChanged="gv_SelectedIndexChanged" 
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="1" CellSpacing="1" OnRowCreated="gv_RowCreated">
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        BorderWidth="1px" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="S.No">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="AMT_DATE" HeaderText="Date" ControlStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left5" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PARTICULARS" HeaderText="Particulars" ControlStyle-Width="600px">
                                            <ItemStyle CssClass="column_style_left5" Width="600px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CREDIT_AMT" HeaderText="Credit Amt" ControlStyle-Width="200px">
                                            <ItemStyle CssClass="column_style_left5" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="DEBIT_AMT" HeaderText="Debit Amt" ControlStyle-Width="200px">
                                            <ItemStyle CssClass="column_style_left5" Width="200px" />
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
                         <%--------------------------------------Row End-----------------------------------------%>
                    </div>
                 
                        </div>
                        </div>
                    </div>

                      <%----------------------------Other---------------------------------------------------%>
                     <div   class="content" id="page-8" style="height:492px;">
                    
                      <div id="pop_text_area_transac_popup_inn_container_export" style="height:508px;margin-top: -16px; margin-left:-18px; color:Red;width: 1185px;">
                        <div id="tag_transact_src_inner" style="width: 1185px;height:508px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1185px;height:508px;">
                                <%---------------------------------------Row 1-----------------------------------------%>
                    <div id="tag_transact_lft_in1" style="width: 1185px;height:35px;">
                            <div id="txt_container_Transact_Main_l" style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                 Credit Start Date 
                                </div>
                                
                                <div id="txtcon-m_Exchange" style="width: 100px;"> 
                                   <asp:TextBox ID="txt_Cr_St_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="15"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_Cr_St_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Cr_St_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 190px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  No of Day(s)
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px;">
                                   <asp:DropDownList ID="ddl_Noof_Days" Width="80px" runat="server" CssClass="listtxt_transac_mode_new"
                                        TabIndex="3" AutoPostBack="true" 
                                        onselectedindexchanged="ddl_Noof_Days_SelectedIndexChanged" >
                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="240" Value="240"></asp:ListItem>
                                    <asp:ListItem Text="239" Value="239"></asp:ListItem>
                                    <asp:ListItem Text="238" Value="238"></asp:ListItem>
                                    <asp:ListItem Text="237" Value="237"></asp:ListItem>
                                    <asp:ListItem Text="236" Value="236"></asp:ListItem>
                                    <asp:ListItem Text="235" Value="235"></asp:ListItem>
                                    <asp:ListItem Text="234" Value="234"></asp:ListItem>
                                    <asp:ListItem Text="233" Value="233"></asp:ListItem>
                                    <asp:ListItem Text="232" Value="232"></asp:ListItem>
                                    <asp:ListItem Text="231" Value="231"></asp:ListItem>
                                    <asp:ListItem Text="230" Value="230"></asp:ListItem>
                                    <asp:ListItem Text="229" Value="229"></asp:ListItem>
                                    <asp:ListItem Text="228" Value="228"></asp:ListItem>
                                    <asp:ListItem Text="227" Value="227"></asp:ListItem>
                                    <asp:ListItem Text="226" Value="226"></asp:ListItem>
                                    <asp:ListItem Text="225" Value="225"></asp:ListItem>
                                    <asp:ListItem Text="224" Value="224"></asp:ListItem>
                                    <asp:ListItem Text="223" Value="223"></asp:ListItem>
                                    <asp:ListItem Text="222" Value="222"></asp:ListItem>
                                    <asp:ListItem Text="221" Value="221"></asp:ListItem>
                                    <asp:ListItem Text="220" Value="220"></asp:ListItem>
                                    <asp:ListItem Text="219" Value="219"></asp:ListItem>
                                    <asp:ListItem Text="218" Value="218"></asp:ListItem>
                                    <asp:ListItem Text="217" Value="217"></asp:ListItem>
                                    <asp:ListItem Text="216" Value="216"></asp:ListItem>
                                    <asp:ListItem Text="215" Value="215"></asp:ListItem>
                                    <asp:ListItem Text="214" Value="214"></asp:ListItem>
                                    <asp:ListItem Text="213" Value="213"></asp:ListItem>
                                    <asp:ListItem Text="212" Value="212"></asp:ListItem>
                                    <asp:ListItem Text="211" Value="211"></asp:ListItem>
                                    <asp:ListItem Text="210" Value="210"></asp:ListItem>
                                    <asp:ListItem Text="209" Value="209"></asp:ListItem>
                                    <asp:ListItem Text="208" Value="208"></asp:ListItem>
                                    <asp:ListItem Text="207" Value="207"></asp:ListItem>
                                    <asp:ListItem Text="206" Value="206"></asp:ListItem>
                                    <asp:ListItem Text="205" Value="205"></asp:ListItem>
                                    <asp:ListItem Text="204" Value="204"></asp:ListItem>
                                    <asp:ListItem Text="203" Value="203"></asp:ListItem>
                                    <asp:ListItem Text="202" Value="202"></asp:ListItem>
                                    <asp:ListItem Text="201" Value="201"></asp:ListItem>
                                    <asp:ListItem Text="200" Value="200"></asp:ListItem>
                                    <asp:ListItem Text="199" Value="199"></asp:ListItem>
                                    <asp:ListItem Text="198" Value="198"></asp:ListItem>
                                    <asp:ListItem Text="197" Value="197"></asp:ListItem>
                                    <asp:ListItem Text="196" Value="196"></asp:ListItem>
                                    <asp:ListItem Text="195" Value="195"></asp:ListItem>
                                    <asp:ListItem Text="194" Value="194"></asp:ListItem>
                                    <asp:ListItem Text="193" Value="193"></asp:ListItem>
                                    <asp:ListItem Text="192" Value="192"></asp:ListItem>
                                    <asp:ListItem Text="191" Value="191"></asp:ListItem>
                                    <asp:ListItem Text="190" Value="190"></asp:ListItem>
                                    <asp:ListItem Text="189" Value="189"></asp:ListItem>
                                    <asp:ListItem Text="188" Value="188"></asp:ListItem>
                                    <asp:ListItem Text="187" Value="187"></asp:ListItem>
                                    <asp:ListItem Text="186" Value="186"></asp:ListItem>
                                    <asp:ListItem Text="185" Value="185"></asp:ListItem>
                                    <asp:ListItem Text="184" Value="184"></asp:ListItem>
                                    <asp:ListItem Text="183" Value="183"></asp:ListItem>
                                    <asp:ListItem Text="182" Value="182"></asp:ListItem>
                                    <asp:ListItem Text="181" Value="181"></asp:ListItem>
                                    <asp:ListItem Text="180" Value="180"></asp:ListItem>
                                    <asp:ListItem Text="179" Value="179"></asp:ListItem>
                                    <asp:ListItem Text="178" Value="178"></asp:ListItem>
                                    <asp:ListItem Text="177" Value="177"></asp:ListItem>
                                    <asp:ListItem Text="176" Value="176"></asp:ListItem>
                                    <asp:ListItem Text="175" Value="175"></asp:ListItem>
                                    <asp:ListItem Text="174" Value="174"></asp:ListItem>
                                    <asp:ListItem Text="173" Value="173"></asp:ListItem>
                                    <asp:ListItem Text="172" Value="172"></asp:ListItem>
                                    <asp:ListItem Text="171" Value="171"></asp:ListItem>
                                    <asp:ListItem Text="170" Value="170"></asp:ListItem>
                                    <asp:ListItem Text="169" Value="169"></asp:ListItem>
                                    <asp:ListItem Text="168" Value="168"></asp:ListItem>
                                    <asp:ListItem Text="167" Value="167"></asp:ListItem>
                                    <asp:ListItem Text="166" Value="166"></asp:ListItem>
                                    <asp:ListItem Text="165" Value="165"></asp:ListItem>
                                    <asp:ListItem Text="164" Value="164"></asp:ListItem>
                                    <asp:ListItem Text="163" Value="163"></asp:ListItem>
                                    <asp:ListItem Text="162" Value="162"></asp:ListItem>
                                    <asp:ListItem Text="161" Value="161"></asp:ListItem>
                                    <asp:ListItem Text="160" Value="160"></asp:ListItem>
                                    <asp:ListItem Text="159" Value="159"></asp:ListItem>
                                    <asp:ListItem Text="158" Value="158"></asp:ListItem>
                                    <asp:ListItem Text="157" Value="157"></asp:ListItem>
                                    <asp:ListItem Text="156" Value="156"></asp:ListItem>
                                    <asp:ListItem Text="155" Value="155"></asp:ListItem>
                                    <asp:ListItem Text="154" Value="154"></asp:ListItem>
                                    <asp:ListItem Text="153" Value="153"></asp:ListItem>
                                    <asp:ListItem Text="152" Value="152"></asp:ListItem>
                                    <asp:ListItem Text="151" Value="151"></asp:ListItem>
                                    <asp:ListItem Text="150" Value="150"></asp:ListItem>
                                    <asp:ListItem Text="149" Value="149"></asp:ListItem>
                                    <asp:ListItem Text="148" Value="148"></asp:ListItem>
                                    <asp:ListItem Text="147" Value="147"></asp:ListItem>
                                    <asp:ListItem Text="146" Value="146"></asp:ListItem>
                                    <asp:ListItem Text="145" Value="145"></asp:ListItem>
                                    <asp:ListItem Text="144" Value="144"></asp:ListItem>
                                    <asp:ListItem Text="143" Value="143"></asp:ListItem>
                                    <asp:ListItem Text="142" Value="142"></asp:ListItem>
                                    <asp:ListItem Text="141" Value="141"></asp:ListItem>
                                    <asp:ListItem Text="140" Value="140"></asp:ListItem>
                                    <asp:ListItem Text="139" Value="139"></asp:ListItem>
                                    <asp:ListItem Text="138" Value="138"></asp:ListItem>
                                    <asp:ListItem Text="137" Value="137"></asp:ListItem>
                                    <asp:ListItem Text="136" Value="136"></asp:ListItem>
                                    <asp:ListItem Text="135" Value="135"></asp:ListItem>
                                    <asp:ListItem Text="134" Value="134"></asp:ListItem>
                                    <asp:ListItem Text="133" Value="133"></asp:ListItem>
                                    <asp:ListItem Text="132" Value="132"></asp:ListItem>
                                    <asp:ListItem Text="131" Value="131"></asp:ListItem>
                                    <asp:ListItem Text="130" Value="130"></asp:ListItem>
                                    <asp:ListItem Text="129" Value="129"></asp:ListItem>
                                    <asp:ListItem Text="128" Value="128"></asp:ListItem>
                                    <asp:ListItem Text="127" Value="127"></asp:ListItem>
                                    <asp:ListItem Text="126" Value="126"></asp:ListItem>
                                    <asp:ListItem Text="125" Value="125"></asp:ListItem>
                                    <asp:ListItem Text="124" Value="124"></asp:ListItem>
                                    <asp:ListItem Text="123" Value="123"></asp:ListItem>
                                    <asp:ListItem Text="122" Value="122"></asp:ListItem>
                                    <asp:ListItem Text="121" Value="121"></asp:ListItem>
                                    <asp:ListItem Text="120" Value="120"></asp:ListItem>
                                    <asp:ListItem Text="119" Value="119"></asp:ListItem>
                                    <asp:ListItem Text="118" Value="118"></asp:ListItem>
                                    <asp:ListItem Text="117" Value="117"></asp:ListItem>
                                    <asp:ListItem Text="116" Value="116"></asp:ListItem>
                                    <asp:ListItem Text="115" Value="115"></asp:ListItem>
                                    <asp:ListItem Text="114" Value="114"></asp:ListItem>
                                    <asp:ListItem Text="113" Value="113"></asp:ListItem>
                                    <asp:ListItem Text="112" Value="112"></asp:ListItem>
                                    <asp:ListItem Text="111" Value="111"></asp:ListItem>
                                    <asp:ListItem Text="110" Value="110"></asp:ListItem>
                                    <asp:ListItem Text="109" Value="109"></asp:ListItem>
                                    <asp:ListItem Text="108" Value="108"></asp:ListItem>
                                    <asp:ListItem Text="107" Value="107"></asp:ListItem>
                                    <asp:ListItem Text="106" Value="106"></asp:ListItem>
                                    <asp:ListItem Text="105" Value="105"></asp:ListItem>
                                    <asp:ListItem Text="104" Value="104"></asp:ListItem>
                                    <asp:ListItem Text="103" Value="103"></asp:ListItem>
                                    <asp:ListItem Text="102" Value="102"></asp:ListItem>
                                    <asp:ListItem Text="101" Value="101"></asp:ListItem>
                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                    <asp:ListItem Text="99" Value="99"></asp:ListItem>
                                    <asp:ListItem Text="98" Value="98"></asp:ListItem>
                                    <asp:ListItem Text="97" Value="97"></asp:ListItem>
                                    <asp:ListItem Text="96" Value="96"></asp:ListItem>
                                    <asp:ListItem Text="95" Value="95"></asp:ListItem>
                                    <asp:ListItem Text="94" Value="94"></asp:ListItem>
                                    <asp:ListItem Text="93" Value="93"></asp:ListItem>
                                    <asp:ListItem Text="92" Value="92"></asp:ListItem>
                                    <asp:ListItem Text="91" Value="91"></asp:ListItem>
                                    <asp:ListItem Text="90" Value="90"></asp:ListItem>
                                    <asp:ListItem Text="89" Value="89"></asp:ListItem>
                                    <asp:ListItem Text="88" Value="88"></asp:ListItem>
                                    <asp:ListItem Text="87" Value="87"></asp:ListItem>
                                    <asp:ListItem Text="86" Value="86"></asp:ListItem>
                                    <asp:ListItem Text="85" Value="85"></asp:ListItem>
                                    <asp:ListItem Text="84" Value="84"></asp:ListItem>
                                    <asp:ListItem Text="83" Value="83"></asp:ListItem>
                                    <asp:ListItem Text="82" Value="82"></asp:ListItem>
                                    <asp:ListItem Text="81" Value="81"></asp:ListItem>
                                    <asp:ListItem Text="80" Value="80"></asp:ListItem>
                                    <asp:ListItem Text="79" Value="79"></asp:ListItem>
                                    <asp:ListItem Text="78" Value="78"></asp:ListItem>
                                    <asp:ListItem Text="77" Value="77"></asp:ListItem>
                                    <asp:ListItem Text="76" Value="76"></asp:ListItem>
                                    <asp:ListItem Text="75" Value="75"></asp:ListItem>
                                    <asp:ListItem Text="74" Value="74"></asp:ListItem>
                                    <asp:ListItem Text="73" Value="73"></asp:ListItem>
                                    <asp:ListItem Text="72" Value="72"></asp:ListItem>
                                    <asp:ListItem Text="71" Value="71"></asp:ListItem>
                                    <asp:ListItem Text="70" Value="70"></asp:ListItem>
                                    <asp:ListItem Text="69" Value="69"></asp:ListItem>
                                    <asp:ListItem Text="68" Value="68"></asp:ListItem>
                                    <asp:ListItem Text="67" Value="67"></asp:ListItem>
                                    <asp:ListItem Text="66" Value="66"></asp:ListItem>
                                    <asp:ListItem Text="65" Value="65"></asp:ListItem>
                                    <asp:ListItem Text="64" Value="64"></asp:ListItem>
                                    <asp:ListItem Text="63" Value="63"></asp:ListItem>
                                    <asp:ListItem Text="62" Value="62"></asp:ListItem>
                                    <asp:ListItem Text="61" Value="61"></asp:ListItem>
                                    <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                    <asp:ListItem Text="59" Value="59"></asp:ListItem>
                                    <asp:ListItem Text="58" Value="58"></asp:ListItem>
                                    <asp:ListItem Text="57" Value="57"></asp:ListItem>
                                    <asp:ListItem Text="56" Value="56"></asp:ListItem>
                                    <asp:ListItem Text="55" Value="55"></asp:ListItem>
                                    <asp:ListItem Text="54" Value="54"></asp:ListItem>
                                    <asp:ListItem Text="53" Value="53"></asp:ListItem>
                                    <asp:ListItem Text="52" Value="52"></asp:ListItem>
                                    <asp:ListItem Text="51" Value="51"></asp:ListItem>
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="49" Value="49"></asp:ListItem>
                                    <asp:ListItem Text="48" Value="48"></asp:ListItem>
                                    <asp:ListItem Text="47" Value="47"></asp:ListItem>
                                    <asp:ListItem Text="46" Value="46"></asp:ListItem>
                                    <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                    <asp:ListItem Text="44" Value="44"></asp:ListItem>
                                    <asp:ListItem Text="43" Value="43"></asp:ListItem>
                                    <asp:ListItem Text="42" Value="42"></asp:ListItem>
                                    <asp:ListItem Text="41" Value="41"></asp:ListItem>
                                    <asp:ListItem Text="40" Value="40"></asp:ListItem>
                                    <asp:ListItem Text="39" Value="39"></asp:ListItem>
                                    <asp:ListItem Text="38" Value="38"></asp:ListItem>
                                    <asp:ListItem Text="37" Value="37"></asp:ListItem>
                                    <asp:ListItem Text="36" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="35" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="34" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="33" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="32" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                    <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                    
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                              
                             <div id="txt_container_Transact_Main_l" style="width: 240px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                  Credit End Date 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 110px;">
                                   <asp:TextBox ID="txt_Cr_End_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="15"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Cr_End_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_Cr_End_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                </div>
                            </div>
                            <%--
                             <div id="txt_container_Transact_Main_l" style="width: 210px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                  Debit Amount
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 110px;">
                                    <asp:TextBox ID="txt_Debit_Amount" runat="server" MaxLength="17" Width="100px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                            TabIndex="18" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" BackColor="#FFFFC2"></asp:TextBox>

                                            
                                </div>
                            </div>--%>

                        </div>
                     <%---------------------------------------Row 5-----------------------------------------%>
                     <div id="innerbox_MidMain_bot_transact"  style="height: 20px;">
                 <div id="innerbox_transac_bot_inn" style="width: 1050px">
                     <div id="newbu">
                         <asp:Button ID="btnNew_V" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                             TabIndex="122" OnClick="btnNew_ClickV" />
                     </div>
                     <div id="editbu">
                         <asp:Button ID="btnSave_V" runat="server" CssClass="save" OnClientClick="return validate();"
                             TabIndex="120" OnClick="btnSave_V_Click" CommandName="s" />
                     </div>
                     <div id="editbu">
                         <asp:Button ID="btnUpdate_V" runat="server" CssClass="updates" OnClick="btnUpdate_V_Click"
                             OnClientClick="return validate();" TabIndex="121" />
                     </div>
                     <div id="editbu">
                         <asp:Button ID="btnDelete_V" runat="server" TabIndex="121" CausesValidation="false"
                             UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Invoice?', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn_V').click();
            
          }
          else {
          }
    
});return false;" />
                         <asp:Button ID="btn_V" runat="server" TabIndex="123" OnClick="btnDelete_Click" CausesValidation="false"
                             UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                             CssClass="dlete" Style="display: none;" />
                     </div>
                     <div id="editbu">
                         <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                             id="btnCancel_V" tabindex="123">
                     </div>
                         <div id="editbu"> &nbsp;&nbsp;</div>
                     <div id="txt_container_Transact_Main_l" style="width: 200px;">
                                <div id="tag_label_transact_Src" style="width: 100px;">
                                  Validity day(s) :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 90px; margin-top:5px;text-align:left;">
                                   <span id="lbb" style="font-weight:bold; text-align:left;" runat="server"> <asp:Literal ID="lbl_balance_days" runat="server"></asp:Literal></span>
                                </div>
                            </div>

                 </div>
             </div>

             <%--------------------------------------------------------------------------------------------------------------%>

             <div id="tag_transac_lft_Item_maindet_Grid_area" style="margin-top:15px;height:420px; width:1175px;">
                 
                 <asp:GridView ID="gv_Date" runat="server" DataKeyNames="ID,PARTY_ID" EmptyDataText="NO RECORD FOUND"
                     AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                     ShowHeaderWhenEmpty="True" PageSize="12" AllowPaging="True" OnRowDataBound="gv_Date_RowDataBound"
                     OnPageIndexChanging="gv_Date_PageIndexChanging" OnSelectedIndexChanged="gv_Date_SelectedIndexChanged"
                     AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                     CellPadding="1" CellSpacing="1" OnRowCreated="gv_RowCreated">
                     <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                         BorderWidth="1px" />
                     <Columns>
                         <asp:CommandField ShowSelectButton="True">
                             <HeaderStyle CssClass="hideGridColumn" />
                             <ItemStyle CssClass="hideGridColumn" />
                         </asp:CommandField>
                         <asp:TemplateField HeaderText="S.No">
                             <ItemTemplate>
                                 <%# Container.DataItemIndex + 1 %>
                             </ItemTemplate>
                         </asp:TemplateField>
                         <asp:BoundField DataField="V_START_DATE" HeaderText="Start Date" ControlStyle-Width="400px">
                             <ItemStyle CssClass="column_style_left5" Width="400px" />
                         </asp:BoundField>
                         <asp:BoundField DataField="V_END_DATE" HeaderText="End Date" ControlStyle-Width="400px">
                             <ItemStyle CssClass="column_style_left5" Width="400px" />
                         </asp:BoundField>
                         <asp:BoundField DataField="VALIDITY_DAYS" HeaderText="No Of Day(s)" ControlStyle-Width="200px">
                             <ItemStyle CssClass="column_style_left5" Width="200px" />
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




                    <%--------------------------------------Row 5-----------------------------------------%>
                         </div>
                        </div>
                        </div>
                    </div>
                      <%----------------------------Charge Details---------------------------------------------------%>

                    <div  class="content"  id="page-7"  style="display:none;height:492px; width:1194px;" >
                           <%--<div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 30px;
                                width: 1194px; margin-top: -10px;margin-left:-18px;">
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
                                        <asp:BoundField DataField="d" HeaderText="" HeaderStyle-Width="75px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="75px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="d" HeaderText="Ex." HeaderStyle-Width="80px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="80px" />
                                        </asp:BoundField>
                                      
                                        <asp:BoundField DataField="e" HeaderText="" HeaderStyle-Width="30px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="f" HeaderText="Discnt." HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="f" HeaderText="" HeaderStyle-Width="70px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="70px" />
                                        </asp:BoundField>
                                       
                                        <asp:BoundField DataField="g" HeaderText="CGST" HeaderStyle-Width="30px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="CGST" HeaderStyle-Width="50px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="SGST" HeaderStyle-Width="30px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="SGST" HeaderStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="IGST" HeaderStyle-Width="30px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="IGST" HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderStyle-Width="0px" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="0px" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>--%>

                           <%--<div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 30px;
                                width: 1194px; margin-top: -10px;margin-left:-18px;">
                                <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                    CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" Style="overflow: auto;">
                                    <Columns>
                                        <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="S. No" HeaderStyle-Width="180px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="180px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="a" HeaderText="Charge Name" HeaderStyle-Width="625px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="625px" />
                                        </asp:BoundField>

                                        <asp:BoundField  HeaderText="Description" HeaderStyle-Width="390px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="390px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="c" HeaderText="Type" HeaderStyle-Width="85px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="85px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="a" HeaderText="HSN" HeaderStyle-Width="125px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="125px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="a" HeaderText="SA" HeaderStyle-Width="150px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="Qty" HeaderStyle-Width="73px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Center" Width="73px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="d" HeaderText="Cur." HeaderStyle-Width="125px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="125px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="d" HeaderText="Rate" HeaderStyle-Width="62px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="62px" />
                                        </asp:BoundField>
                                       
                                        <asp:BoundField DataField="e" HeaderText="Unit Rate" HeaderStyle-Width="170px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="170px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="d" HeaderText="%" HeaderStyle-Width="65px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="65px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="f" HeaderText="Amt" HeaderStyle-Width="220px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="220px" />
                                        </asp:BoundField>
                                       
                                        <asp:BoundField DataField="g" HeaderText="%" HeaderStyle-Width="65px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="65px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Amt" HeaderStyle-Width="155px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="155px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText=" % " HeaderStyle-Width="65px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="65px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Amt" HeaderStyle-Width="155px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="155px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText=" % " HeaderStyle-Width="65px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="65px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Amt" HeaderStyle-Width="140px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="140px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderStyle-Width="0px" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>--%>
                            
                    </div>
                    
                  <%-------------------------------------------------------------------------------%>
                </div>
                  <%-- --------------------Test Start----------------------------%>
             
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


                <%-- ---------------------------------------------------------ModelpopUp---1S------------------------------------------------------------------------------%>
      
            <%-- ---------------------------------------------------------ModelpopUp---16--S----------------------------------------------------------------------------%>
             <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panl2" TargetControlID="btnaddnewParty"
                CancelControlID="Button3" BackgroundCssClass="Background">
            </cc1:ModalPopupExtender> 
            <asp:Panel ID="Panl2" runat="server" CssClass="Popup_2" align="center" Style="display: none">
                <iframe style="width: 500px; height: 250px;" id="irm2" src="NewParty.aspx" runat="server">
                </iframe>
                <br />
                <asp:Button ID="Button3" runat="server" Text="Close" />
            </asp:Panel> 
            <%-- ---------------------------------------------------------ModelpopUp---16--E----------------------------------------------------------------------------%>
    <script type="text/javascript">
        function HideModalPopup() {
            $find("MPEU").hide();
            return false;
        }
        function HideModalPopup_Show() {
            $find("MPEU").Show();
            return false;
        }
    </script>

          
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>

              <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />
             <asp:HiddenField ID="HDupdate_id" runat="server" />

             <asp:HiddenField ID="HD_Showcon" runat="server" />
             <asp:HiddenField ID="HD_Bill_Jobno" runat="server" />

             <asp:HiddenField ID="Hdjobno" runat="server" />
             <asp:HiddenField ID="hd_ch_type" runat="server" />
             <asp:HiddenField ID="Hd_row_id" runat="server" />

              <asp:HiddenField ID="Hd_Tr_mode" runat="server" />
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
