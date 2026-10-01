<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Company_Info.aspx.cs" Inherits="Acc_Company_Info" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Company Master</title>
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

   <%--<script type="text/javascript">
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
</script>--%>

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
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 150px;">
                        Company Master
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                     
                      <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                        
                        <div id="txtcon-m_Exchange" style="width: 100px; margin-top: 5px;">
                            Company Lic
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px; margin-top: 5px; color: Red;">
                            <asp:Literal ID="lbl_Job_Company_Lic" runat="server"></asp:Literal>
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
                            <div id="txt_container_Transact_Main_l"  style="width: 530px;">
                                <div id="tag_label_transact_Src" style="width: 110px; font-size: 12px;">
                                   Company Name
                                </div>
                                <div id="txtcon-m_Exchange" Style="width: 420px;" >
                                    <asp:TextBox ID="txt_Company_Name" CssClass=" txtbox_none_Mid_transac_code" Width="400px"
                                    TabIndex="10" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            
                            
                            <div id="txt_container_Transact_Main_l" style="width: 450px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                   Branch No
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 370px">
                                       <asp:TextBox ID="txt_Branch" CssClass=" txtbox_none_Mid_transac_code" Width="360px"
                                    TabIndex="11" runat="server"></asp:TextBox>
                                </div>
                            </div>
                             
                        </div>
                    <%---------------------------------------Row 4-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1185px;height:35px;">
                            <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Address 1 
                                </div>
                                
                                <div id="txtcon-m_Exchange" > 
                                  <asp:TextBox ID="txt_Add_1" runat="server" MaxLength="250" onkeyup="autotab(this);" ClientIDMode="Static" onblur="return ChangeCase(this);"
                                   onkeypress="return Char_Inv(event)"  
                                   CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="12" ></asp:TextBox>
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 100px;">
                                  Address 2 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txt_Add_2" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="13"></asp:TextBox>
                                </div>
                            </div>
                            
                              <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  Address 3 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txt_Add_3" runat="server" MaxLength="150" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="14"></asp:TextBox>
                                </div>
                            </div>
                             <div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  Address 4
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txt_Add_4" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="15"></asp:TextBox>
                                </div>
                            </div>
                            
                              <%--<div id="txt_container_Transact_Main_l" style="width: 230px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                  Party Add. 5 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;">
                                   <asp:TextBox ID="txtParty_Add_5" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="24"></asp:TextBox>
                                </div>
                            </div>--%>

                        </div>
                        <%---------------------------------------Row 4-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1185px; height:35px;">
                            <div id="txt_container_Transact_Main_l"  style="width: 280px;">
                                <div id="tag_label_transact_Src" style="width: 110px; font-size: 12px;">
                                  Address 5
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Add_5" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                        Width="150px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="16"></asp:TextBox>
                                </div>
                            </div>
                            
                            
                            <%--<div id="txt_container_Transact_Main_l" style="width: 230px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                   Bank Details 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 140px">
                                        <asp:DropDownList ID="ddlBank_details" runat="server" class="chosen-select-deselect"
                                        Style="width: 138px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                        TabIndex="26">
                                        <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                        <asp:ListItem Text="Account Transfer" Value="Account Transfer"></asp:ListItem>
                                        <asp:ListItem Text="Others" Value="Others"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                            </div>--%>
                            <div id="txt_container_Transact_Main_l" style="width: 250px">
                                <div id="tag_label_transact_Src" style="width: 100px">
                                   Pan / Tan No.
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 150px">
                                       <asp:TextBox ID="txt_Pan_Tan_No" runat="server" Width="130px" MaxLength="100" onkeyup="autotab(this);"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="17"></asp:TextBox>
                                </div>
                            </div>
                             <div id="txt_container_Transact_Main_l" style="width: 365px">
                                <div id="tag_label_transact_Src" style="width: 150px">
                                   Gst Rgesitration Type  
                                   </div>
                                <div id="txtcon-m_Exchange" style="width: 140px">
                                        <asp:DropDownList ID="ddlGst_Reg_Type" runat="server" class="chosen-select-deselect"
                                        Style="width: 138px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                        TabIndex="20">
                                        <asp:ListItem Text="Regular" Value="R"></asp:ListItem>
                                        <asp:ListItem Text="Govt" Value="G"></asp:ListItem>
                                        <asp:ListItem Text="Unregistered" Value="U"></asp:ListItem>
                                        </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 5-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1185px; height:35px;">
                            <div id="txt_container_Transact_Main_l"  style="width: 280px;">
                                <div id="tag_label_transact_Src" style="width: 110px; font-size: 12px;">
                                   State Code
                                </div>
                                <div id="txtcon-m_Exchange" >
                                    <asp:DropDownList ID="ddl_state_name" CssClass="listtxt_transac_item_gen_notn" Width="160px" TabIndex="21" ForeColor="Green" runat="server" >
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
                            
                            
                            <div id="txt_container_Transact_Main_l" style="width: 280px">
                                <div id="tag_label_transact_Src" style="width: 100px">
                                   GST Number 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 140px">
                                         <asp:TextBox ID="txt_Gst_Number" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="22"></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                        <%--------------------------------------Row 4-----------------------------------------%>
                        
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
                             UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Company info?', 'Company Info', function(r) {
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

          
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>

             <asp:HiddenField ID="HDupdate_id" runat="server" />
             <asp:HiddenField ID="HD_Showcon" runat="server" />
             

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
