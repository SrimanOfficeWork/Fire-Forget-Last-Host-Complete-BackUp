<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copy of Party_Master.aspx.cs" Inherits="Party_Master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Party Master</title>
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

            <div id="innerbox_MidMain_Billing" style="height: 35px;width: 1194px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                        Party Master
                           </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                     <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 80px;">
                            Client Name
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 380px;">
                            <asp:DropDownList ID="ddlClient_name" runat="server" class="chosen-select-deselect"
                             Style="width: 370px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                            TabIndex="8" OnSelectedIndexChanged="ddlClient_name_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                             <asp:Button ID="btnaddnew" runat="server" Text="Add Client" OnClientClick="return HideModalPopup()" Visible="false"
                                        CausesValidation="false" UseSubmitBehavior="false" />
                        </div>

                        <div id="txt_container_Transact_Main_l"  style="width: 260px;">
                                <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;margin-top: -5px;">
                                    Client Br. No
                                </div>
                                <div id="txtcon-m_Exchange" style="margin-top: -5px;" >
                                     <asp:DropDownList ID="ddl_Client_branch_No" runat="server" class="chosen-select-deselect"
                                        Style="width: 162px;" data-placeholder="Choose a Branch No" TabIndex="10" AutoPostBack="true"
                                         onselectedindexchanged="ddl_Client_branch_No_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>

                        <div id="txt_container_Transact_Main_l"  style="width: 200px;">
                        <div id="tag_label_transact_Src" style="width: 100px; color:Gray;font-weight:bold;margin-top: -5px;">
                        Same as Party
                        </div>
                            <div id="txtcon-m_Exchange" style="width: 50px; margin-top: -5px;">
                            <asp:CheckBox ID="Ch_Same_as_Party" runat="server" AutoPostBack="true" Checked="true"  oncheckedchanged="Ch_Same_as_Party_CheckedChanged" />
                            </div>
                        </div>

                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                </div>
                
              </div> 
              
            <%-- -------------------------------------Tab--------------------------------------------------------%>


         <div class="content" id="page-1" style="margin-top:-28px;width:1194px;">
                        
          <div id="innerbox_MidMain_Trans_new" style="height:535px; width:1194px; margin-left:-16px; margin-top:-15px;">
                <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span>General </span></a></li>

                     <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" visible="false"
                        id="Page_C" runat="server" ><span>Other </span></a></li>

                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" visible="false" id="Page_B" runat="server">
                        <span>Charge details</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        <span> Gen -4 </span></a></li>

                        
                </ol>
                  <%----------------------------General---------------------------------------------------%>
                    <div   class="content" id="page-6" style="height:492px;" >

                    <%--------------------------------------------------------------------------------------------%>
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:508px;margin-top: -16px; margin-left:-18px; color:Red;width: 1185px;">
                        <div id="tag_transact_src_inner" style="width: 1185px;height:508px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1185px;height:508px;">
                    <%---------------------------------------Row 1-----------------------------------------%>
                    
                    <%---------------------------------------Row 2-----------------------------------------%>
                    <div id="tag_transact_lft_in1" style="width: 1185px; height:35px;">
                            <div id="txt_container_Transact_Main_l"  style="width: 520px;">
                                <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;">
                                   Party Name
                                </div>
                                <div id="txtcon-m_Exchange" Style="width: 434px;" >
                                     <asp:DropDownList ID="ddlPartyName" runat="server" class="chosen-select-deselect"
                                            Style="width: 330px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                            TabIndex="12" OnSelectedIndexChanged="ddlPartyName_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp;&nbsp;
                                         <asp:Button ID="btnaddnewParty" runat="server" Text="Add Party" OnClientClick="return HideModalPopup()"
                                            CausesValidation="false" UseSubmitBehavior="false" Visible="false" Width="1px" />
                              <input type="submit" value="Submit" class="new" onclick="open_Billing_Party_Master_PN('New'); return false" />
                                </div>
                            </div>
                            
                            
                            <div id="txt_container_Transact_Main_l" style="width: 320px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                   Branch No
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 220px">
                                      <asp:DropDownList ID="ddlPartybranch_Name" runat="server" class="chosen-select-deselect"
                                            Style="width: 210px;" data-placeholder="Choose a Branch No" 
                                          TabIndex="15" AutoPostBack="true" 
                                          onselectedindexchanged="ddlPartybranch_Name_SelectedIndexChanged">
                                        </asp:DropDownList>
                                </div>
                            </div>
                             
                        </div>
                    <%---------------------------------------Row 4-----------------------------------------%>
                        <%--<div id="tag_transact_lft_in1" style="width: 1185px;height:35px;">
                            <div id="txt_container_Transact_Main_l" style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    Party Add. 1 
                                </div>
                                
                                <div id="txtcon-m_Exchange" > 
                                  <asp:TextBox ID="txtParty_Add_1" runat="server" MaxLength="17" onkeyup="autotab(this);" ClientIDMode="Static" onblur="return ChangeCase(this);"
                                   onkeypress="return Char_Inv(event)"  
                                   CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="16" ></asp:TextBox>
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  Party Add. 2 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txtParty_Add_2" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="18"></asp:TextBox>
                                </div>
                            </div>
                            
                              <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  Party Add. 3 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txtParty_Add_3" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="20"></asp:TextBox>
                                </div>
                            </div>
                             <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  Party Add. 4 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txtParty_Add_4" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="21"></asp:TextBox>
                                </div>
                            </div>
                            
                              <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                 Pin Code 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                <asp:TextBox ID="txtParty_Add_5" runat="server" MaxLength="6" Width="100px" CssClass="validate[required,minSize[6],custom[phone]] txtbox_none"
                                    TabIndex="24" onkeypress="return pin(event)"></asp:TextBox>
                                </div>
                            </div>

                        </div>--%>
                        <%---------------------------------------Row 4-----------------------------------------%>
                        <%--<div id="tag_transact_lft_in1" style="width: 1185px; height: 35px;">
                            <div id="txt_container_Transact_Main_l" style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;">
                                    GST Number
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Gst_Number" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                        Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="32"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 230px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                   Tan No.
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 140px">
                                        <asp:TextBox ID="txt_Pan_Tan_No" runat="server" Width="130px" MaxLength="100" onkeyup="autotab(this);"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="28"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 230px">
                                <div id="tag_label_transact_Src" style="width: 100px">
                                    TDS Deducted
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 110px">
                                     <asp:RadioButtonList ID="Rd_TDS_Y_N" runat="server" RepeatDirection="Horizontal" TabIndex="16" ForeColor="Purple" >
                                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 230px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                    TDS Sec.
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 140px">
                                   <asp:DropDownList ID="ddlTDS_Section" TabIndex="20" runat="server" class="chosen-select-deselect"
                                    Style="width: 135px;" data-placeholder="Choose a Tds Sec" >
                                            <asp:ListItem Text="" Value=""></asp:ListItem>
                                            <asp:ListItem Text="192B" Value="192B"></asp:ListItem>
                                            <asp:ListItem Text="194A" Value="194A"></asp:ListItem>
                                            <asp:ListItem Text="194B" Value="194B"></asp:ListItem>
                                            <asp:ListItem Text="194C" Value="194C"></asp:ListItem>
                                            <asp:ListItem Text="194D" Value="194D"></asp:ListItem>
                                            <asp:ListItem Text="194H" Value="194H"></asp:ListItem>
                                            <asp:ListItem Text="194I" Value="194I"></asp:ListItem>
                                            <asp:ListItem Text="194Ia" Value="194Ia"></asp:ListItem>
                                            <asp:ListItem Text="194Ib" Value="194Ib"></asp:ListItem>
                                            <asp:ListItem Text="194J" Value="194J"></asp:ListItem>
                                     </asp:DropDownList>
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_l" style="width: 200px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                   TDS Rate
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 110px">
                                        <asp:TextBox ID="txt_Tds_Rate" runat="server" Width="100px" MaxLength="100" onkeyup="autotab(this);"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="28"></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>
                        <%---------------------------------------Row 4--II---------------------------------------%>
                        <%--<div id="tag_transact_lft_in1" style="width: 1185px; height:35px;">
                            <div id="txt_container_Transact_Main_l"  style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;">
                                   Under
                                </div>
                                <div id="txtcon-m_Exchange" >
                                     <asp:DropDownList ID="ddlUnder" runat="server" class="chosen-select-deselect"
                                        Style="width: 155px;" data-placeholder="Choose a Customer Name" 
                                        TabIndex="25">
                                        
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                            
                            <div id="txt_container_Transact_Main_l" style="width: 230px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                   Bank Details 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 140px">
                                        <asp:DropDownList ID="ddlBank_details" runat="server" class="chosen-select-deselect"
                                        Style="width: 138px;" data-placeholder="Choose a Payment Type"  TabIndex="26">
                                       
                                        <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                        <asp:ListItem Text="Account Transfer" Value="Account Transfer"></asp:ListItem>
                                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 310px">
                                <div id="tag_label_transact_Src" style="width: 120px">
                                   Pan number / Tan
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 190px">
                                     
                                </div>
                            </div>
                             <div id="txt_container_Transact_Main_l" style="width: 365px">
                                <div id="tag_label_transact_Src" style="width: 150px">
                                   Gst Rgesitration Type  
                                   </div>
                                <div id="txtcon-m_Exchange" style="width: 140px">
                                        <asp:DropDownList ID="ddlGst_Reg_Type" runat="server" class="chosen-select-deselect"
                                        Style="width: 138px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                        TabIndex="30">
                                        <asp:ListItem Text="Regular" Value="R"></asp:ListItem>
                                        <asp:ListItem Text="Govt" Value="G"></asp:ListItem>
                                        <asp:ListItem Text="Unregistered" Value="U"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                            </div>
                        </div>--%>
                        <%--------------------------------------Row 5-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1185px; height:35px;">
                            <div id="txt_container_Transact_Main_l"  style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;">
                                   State Code
                                </div>
                                <div id="txtcon-m_Exchange" >
                                    <asp:DropDownList ID="ddl_state_name" CssClass="listtxt_transac_item_gen_notn" Width="160px" TabIndex="31" ForeColor="Green" runat="server" >
                                     <asp:ListItem Text="" Value=""></asp:ListItem>

                                    <asp:ListItem Text="01--JAMMU & KASHMIR" Value="01"></asp:ListItem>
                                    <asp:ListItem Text="02--HIMACHAL PRADESH" Value="02"></asp:ListItem>
                                    <asp:ListItem Text="03--PUNJAB" Value="03"></asp:ListItem>
                                    <asp:ListItem Text="04--CHANDIGARH" Value="04"></asp:ListItem>
                                    <asp:ListItem Text="05--UTTARAKHAND" Value="05"></asp:ListItem>
                                    <asp:ListItem Text="06--HARYANA" Value="06"></asp:ListItem>
                                    <asp:ListItem Text="07--DELHI" Value="07"></asp:ListItem>
                                    <asp:ListItem Text="08--RAJASTHAN" Value="08"></asp:ListItem>
                                    <asp:ListItem Text="09--UTTAR PRADESH" Value="09"></asp:ListItem>
                                    <asp:ListItem Text="10--BIHAR" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11--SIKKIM" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12--ARUNACHAL PRADESH" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13--NAGALAND" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14--MANIPUR" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15--MIZORAM" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16--TRIPURA" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17--MEGHALAYA" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18--ASSAM" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19--WEST BENGAL" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20--JHARKHAND" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21--ORISSA" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22--CHATTISGARH" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23--MADHYA PRADESH" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24--GUJARAT" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="25--DAMAN & DIU" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="26--DADRA & NAGAR HAVELI" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="27--MAHARASHTRA" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="29--KARNATAKA" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="30--GOA" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="31--LAKSHADWEEP" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="32--KERALA" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="33--TAMILNADU" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="33--TAMIL NADU" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="34--PONDICHERRY" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="35--ANDAMAN & NICOBAR" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="36--TELANGANA" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="37--ANDHRA PRADESH" Value="37"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                            
                            <div id="txt_container_Transact_Main_l" style="width: 230px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                   GST Number 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 140px">
                                         <%--<asp:TextBox ID="txt_Gst_Number" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="32"></asp:TextBox>--%>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  Credit Limit 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txt_Credit_Amt" runat="server" BackColor="#C0C0C0" MaxLength="50" onkeyup="autotab(this);" Enabled="false"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="33"></asp:TextBox>
                                </div>
                            </div>
                             <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  Debit Limit 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txt_Debit_Amt" runat="server"  BackColor="#C0C0C0" MaxLength="50" onkeyup="autotab(this);"  Enabled="false"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="34"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 4-----------------------------------------%>
                        <%--<div id="tag_transact_lft_in1" style="width: 1185px; height:35px;">
                            <div id="txt_container_Transact_Main_l"  style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;">
                                   TDS
                                </div>
                                <div id="txtcon-m_Exchange" >
                                    <asp:DropDownList ID="ddl_TDS_YN" CssClass="listtxt_transac_item_gen_notn" Width="160px" TabIndex="70" ForeColor="Green" runat="server" >
                                     <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                     <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            
                            
                            <div id="txt_container_Transact_Main_l" style="width: 230px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                   TDS Section
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 140px">
                                    <asp:DropDownList ID="ddl_TDS_Section" CssClass="listtxt_transac_item_gen_notn" Width="135px" TabIndex="70" ForeColor="Green" runat="server" >
                                     <asp:ListItem Text="SectionA" Value="A"></asp:ListItem>
                                     <asp:ListItem Text="SectionB" Value="B"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  TDS Rate
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txt_TDS_Rate" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="27"></asp:TextBox>
                                </div>
                            </div>
                             
                        </div>--%>
                        <%--------------------------------------Row 5-----------------------------------------%>
                        <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px;">
                 <div id="innerbox_transac_bot_inn" style="width: 1050px">
                     <div id="newbu">
                         <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                             TabIndex="82" OnClick="btnNew_Click1" />
                     </div>
                     <div id="editbu">
                         <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                             TabIndex="80" OnClick="btnSave_Click" CommandName="s" />
                     </div>
                     <div id="editbu">
                         <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                             OnClientClick="return validate();" TabIndex="81" />
                     </div>
                     <div id="editbu">
                         <asp:Button ID="btnDelete" runat="server" TabIndex="81" CausesValidation="false"
                             UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Invoice?', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                         <asp:Button ID="btn" runat="server" TabIndex="81" OnClick="btnDelete_Click" CausesValidation="false"
                             UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                             CssClass="dlete" Style="display: none;" />
                     </div>
                     <div id="editbu">
                         <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                             id="btnCancel" tabindex="85">
                     </div>
                 </div>
             </div>
                        <%------------------------------grid---------------------------- ------------------------------------%>
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="margin-top:15px;height:320px; width:1175px;">
                                <asp:GridView ID="gv" runat="server" DataKeyNames="PARTY_ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                    ShowHeaderWhenEmpty="True" PageSize="100" AllowPaging="True" OnRowDataBound="gv_RowDataBound"
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


                                        <asp:BoundField DataField="PARTY_NAME" HeaderText="Party Name" ControlStyle-Width="500px">
                                            <ItemStyle CssClass="column_style_left5" Width="500px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="PARTY_BRANCH_NO" HeaderText="Branch No" ControlStyle-Width="200px">
                                            <ItemStyle CssClass="column_style_left5" Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="STATE_NAME" HeaderText="State Name" ControlStyle-Width="200px">
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
                     
                     </div>
                      <%----------------------------Charge Details---------------------------------------------------%>

                    <div  class="content"  id="page-7"  style="display:none;height:492px; width:1194px;" >
                       

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
        <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panl1" TargetControlID="btnaddnew"
                CancelControlID="Button2" BackgroundCssClass="Background">
            </cc1:ModalPopupExtender> 
            <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
                <iframe style="width: 420px; height: 180px;" id="irm1" src="NewClient.aspx" runat="server">
                </iframe>
                <br />
                <asp:Button ID="Button2" runat="server" Text="Close" Width="0px" Style="display: none" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Close" onclick="Button2_Click"/>
            </asp:Panel>  
            <%-- ---------------------------------------------------------ModelpopUp---16--S----------------------------------------------------------------------------%>
             <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panl2" TargetControlID="btnaddnewParty"
                CancelControlID="Button3" BackgroundCssClass="Background">
            </cc1:ModalPopupExtender> 
            <asp:Panel ID="Panl2" runat="server" CssClass="Popup_2" align="center" Style="display: none">
                <iframe style="width: 500px; height: 250px;" id="irm2" src="NewParty.aspx" runat="server">
                </iframe>
                <br />
                <asp:Button ID="Button3" runat="server" Text="Close" Width="0px" Style="display: none" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button4" runat="server" Text="Close" onclick="Button4_Click" />
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

    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>

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
