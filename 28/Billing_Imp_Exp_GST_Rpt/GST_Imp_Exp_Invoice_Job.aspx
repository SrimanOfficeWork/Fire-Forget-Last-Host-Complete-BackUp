<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GST_Imp_Exp_Invoice_Job.aspx.cs" Inherits="GST_Imp_Exp_Invoice_Job" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> GST Combine Bill</title>
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
        .txtbox_none_Mid_transac_Inv_No_2
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 140px;
            margin-top: 1px;
            width: 800px;
            
            border: #c0e4f2 solid thin;
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
            overflow: hidden;
        }
        
        .txtbox_none_Mid_transac_Inv_No_3
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 90px;
            margin-top: 1px;
            width: 500px;
            
            border: #c0e4f2 solid thin;
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
            overflow: hidden;
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
                                   label: item.split('-')[0],
                                   val: item.split('-')[1]
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
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
           
            <div id="innerbox_MidMain"  style="height:170px; background:White;" >
                <div id="tag_srcinner1" style="height:30px;">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                      GST Bill Entry
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top:5px;" >
                          <div id="tag_label_transact_Src" style="width: 70px;color:Blue; font-weight:bold;">
                                   Category :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 150px;">
                                    <asp:RadioButtonList ID="Rd_Inv_Type" runat="server" RepeatDirection="Horizontal"  AutoPostBack="true" TabIndex="5"
                                        onselectedindexchanged="Rd_Inv_Type_SelectedIndexChanged">
                                    <asp:ListItem Text="IMP" Value="I" Selected="True" ></asp:ListItem>
                                    <asp:ListItem Text="EXP" Value="E"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                     
                    </div>
                    
                    <div id="tag_transac_lft_in2" style="margin-top:5px;" >
                          <div id="tag_label_transact_Src" style="width: 60px; color:Blue; font-weight:bold;">
                                  Bill To : &nbsp; &nbsp;&nbsp;&nbsp;
                          </div>
                                <div id="txtcon-m_Exchange" style="width: 200px;">
                                    <asp:RadioButtonList ID="Rd_Bill_Type" runat="server"  
                                        RepeatDirection="Horizontal"  AutoPostBack="true"  TabIndex="6"
                                        onselectedindexchanged="Rd_Bill_Type_SelectedIndexChanged" >
                                    <asp:ListItem Text="Local State" Value="L" Selected="True" ></asp:ListItem>
                                    <asp:ListItem Text="Other State" Value="O"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                     
                    </div>
                    
                    
                    <div id="popupwindow_closebut_right_new" >
                      <span id="F" runat="server"><input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 
                      <span id="T" runat="server">  <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span> 
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px; height:30px; ">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px">

                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l" style="width: 490px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Customer Name</div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddlCustomer_name" CssClass="listtxt_transac_item_gen_notn" Width="370px"
                                        runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer_name_SelectedIndexChanged"
                                        TabIndex="8">
                                    </asp:DropDownList>
                                </div>
                            </div>
                              <div id="txt_container_Transact_Main_l" style="width:580px;">
                               
                                    <div id="tag_label_transact_Src" style="width:70px;" >
                                       Branch No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:165px;">
                                        <asp:DropDownList ID="ddlbranch_No" CssClass="listtxt_transac_item_gen_notn" 
                                            Width="162px" runat="server" TabIndex="9"  AutoPostBack="true"
                                            onselectedindexchanged="ddlbranch_No_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                    
                            </div>
                            </div>
                       
                        </div>

                        
                    </div>
                    <%-- -------------------------------------Job--------------------------------------------------------%>
                <div id="Div_listbox" runat="server">
                    <div id="tag_transact_src_inner" style="width: 1080px; height: 120px;">
                        <div id="innerbox_MidMain_Trans_new" style="width: 1080px; height: 20px; margin-left: -10px;
                            border-bottom-style: solid;">
                            <div id="tag_label_transaction_exp_jobb">
                                <asp:CheckBox ID="cbAll" runat="server" ForeColor="White" Font-Bold="true" Font-Size="14px"
                                    Text="Select All" onclick="CheckAll();" />
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                <span style="color: White;">
                                    <asp:Literal ID="lbl_Loc" runat="server"></asp:Literal>
                                </span>
                            </div>
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width: 1080px; overflow: auto; height: 125px;">
                            <asp:CheckBoxList ID="cbList" runat="server" ValidationGroup="VGroup" onclick="UnCheckAll();"
                                BorderStyle="none" CssClass=" txtbox_none_Mid_transac_pop_gen" Width="1070px"
                                Height="22px" Font-Size="11px" RepeatColumns="6" RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                        </div>
                    </div>
                </div>
                     <%-- -------------------------------------Job--------------------------------------------------------%>
            </div>
            
            <%-- -------------------------------------Tab--------------------------------------------------------%>


         <div class="content" id="page-1" style="margin-top:-28px;">
                        
          <div id="innerbox_MidMain_Trans_new" style="height:360px; width:1094px; margin-left:-16px; margin-top:-5px;">
                <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span>General </span></a></li>
                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span>Charge details</span></a></li>
                    <li ><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server" visible="false">
                        <span>Gen -3</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        <span> Gen -4 </span></a></li>
                          <div id="txtcon-m_Exchange" style="width: 205px;">
                                      <asp:Button ID="btnloadData" TabIndex="10" runat="server" Text="Click CHA Job Details" OnClick="btnloadData_Click" />
                              </div>
                </ol>
                
                    <div   class="content" id="page-6"  >

                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:300px;margin-top: -16px; margin-left:-18px; color:Red;">
                        <div id="tag_transact_src_inner" style="width: 1150px">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px">
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Invoice No:
                                </div>

                                <div id="txtcon-m_Exchange" > 
                                  <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="17" onkeyup="autotab(this);" ClientIDMode="Static" onblur="return ChangeCase(this);"
                                   onkeypress="return Char_Inv(event)" 
                                   CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="12" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 152px">
                                <div id="tag_label_transact_Src" style="width: 60px">
                                    Inv. Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                      <asp:TextBox ID="txtDate" runat="server" Width="82px" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="13"></asp:TextBox>
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
                            
                           <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Manual Job No 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 375px;">
                                   <asp:TextBox ID="txt_Manual_Jobno" runat="server" MaxLength="340" 
                                        onkeyup="autotab(this);" Width="370px" TabIndex="15"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" ></asp:TextBox>
                                </div>
                                
                            </div>


                        </div>
                        <%--------------------------------------Row 4-----------------------------------------%>
                         <div id="tag_transact_lft_in1" style="width: 1150px;height:150px;">
                             <div id="txt_container_Transact_Main_l" style="width: 1000px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   CHA Job Details
                                </div>
                                 <div id="txtcon-m_Exchange" style="width: 800px;height:150px;">
                                   <asp:TextBox ID="txt_Job_Details" runat="server"  TabIndex="16"
                                        onkeyup="autotab(this);" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No_2"  ></asp:TextBox>
                                </div>


                            </div>

                            </div>
                                <%--------------------------------------Row 4-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 1000px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Bill To
                                </div>

                                <div id="txtcon-m_Exchange" style="width: 340px;">
                                    <asp:TextBox ID="txt_To_Customer_name" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                        Width="330px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="18"></asp:TextBox>
                                </div>
                                <%--<div id="magnify_area">
                                             <a href="#"  class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('GST_Bill_Imp_name'); return false">
                                            </a>
                                        </div>--%>

                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  State Name
                                </div>
                                <div id="txtcon-m_Exchange">

                                    <asp:DropDownList ID="ddl_state_name" CssClass="listtxt_transac_item_gen_notn" Width="160px" TabIndex="20" ForeColor="Green" runat="server" >
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

                                 <div id="tag_label_transact_Src">
                                     GSTN ID
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 140px">
                                      <asp:TextBox ID="txt_GSTN_Id" runat="server" MaxLength="17" Width="135px" onkeyup="autotab(this);" Font-Size="12px" TabIndex="22"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  ></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1150px;height:70px;">
                        <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Address 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 373px;height:70px;">
                                   <asp:TextBox ID="txt_To_Add" runat="server" MaxLength="500" 
                                        onkeyup="autotab(this);" TextMode="MultiLine" TabIndex="24"
                                    CssClass="txtbox_none_Mid_transac_Inv_No_3"  ></asp:TextBox>
                                </div>
                            </div>
                      
                          </div>

                         <%--------------------------------------Row End-----------------------------------------%>
                    </div>
                 
                </div>
                        </div>
                    </div>

                    <div  class="content"  id="page-7"  style="display:none;height:300px;" >
                           <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 30px;
                                width: 1094px; margin-top: -10px;margin-left:-18px;">
                                <asp:GridView ID="GV1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                    CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" Style="overflow: auto;">
                                    <Columns>
                                        <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="" HeaderStyle-Width="62px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="62px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="a" HeaderText="" HeaderStyle-Width="400px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="285px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="c" HeaderText="" HeaderStyle-Width="90px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="85px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="a" HeaderText="HSN" HeaderStyle-Width="70px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                          <asp:BoundField DataField="a" HeaderText="SA" HeaderStyle-Width="70px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="" HeaderStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="" HeaderStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="65px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="Ex-" HeaderStyle-Width="95px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="55px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="e" HeaderText="Unit" HeaderStyle-Width="55px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="55px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="f" HeaderText="" HeaderStyle-Width="180px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="CGST" HeaderStyle-Width="45px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="65px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="CGST" HeaderStyle-Width="90px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="SGST" HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="55px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="SGST" HeaderStyle-Width="88px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="88px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="IGST" HeaderStyle-Width="55px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="55px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="IGST" HeaderStyle-Width="80px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderStyle-Width="80px" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                           <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 30px;
                                width: 1094px; margin-top: -10px;margin-left:-18px;">
                                <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                    CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" Style="overflow: auto;">
                                    <Columns>
                                        <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="S. No" HeaderStyle-Width="92px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="62px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="a" HeaderText="Charge Name" HeaderStyle-Width="430px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="c" HeaderText="Type" HeaderStyle-Width="65px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="70px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="a" HeaderText="Code" HeaderStyle-Width="70px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="a" HeaderText="Code" HeaderStyle-Width="65px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="Qty" HeaderStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="Cur" HeaderStyle-Width="50px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="d" HeaderText="Rate" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="e" HeaderText="Rate" HeaderStyle-Width="105px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="55px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="f" HeaderText="Amt" HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Rate" HeaderStyle-Width="90px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="65px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Amt" HeaderStyle-Width="80px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="90px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Rate" HeaderStyle-Width="80px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="55px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Amt" HeaderStyle-Width="80px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="88px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Rate" HeaderStyle-Width="80px" >
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="55px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderText="Amt" HeaderStyle-Width="90px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="g" HeaderStyle-Width="90px" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">
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

                            <div id="tag_transac_lft_Item_maindet_Grid_area"    style="overflow:auto; height:205px; width:1094px;margin-top:-10px;margin-left:-18px; ">
                             <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" 
                                    BorderStyle="none" ShowFooter="True" 
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" onrowdeleting="gv_Chg_Details_RowDeleting" ShowHeader = "false" 
                                    style=" overflow-x: hidden;overflow-y: auto;" > 
                                    
                                    <RowStyle BorderWidth="0.1em" BorderColor="black" Height="50px" /> 
                               <Columns>

                                   <asp:TemplateField HeaderText="ch_inv" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                       <ItemTemplate>
                                           
                                        <asp:CheckBox ID="chk_inv" runat="server" HeaderText="ch_inv"   Width="30px" 
                                         Checked='<%#bool.Parse(Eval("INV_CHECK").ToString())%>' />
                                                  
                                       </ItemTemplate>
                                         <ItemStyle Width="30px" />
                                   </asp:TemplateField>

                                   <asp:BoundField DataField="RowNumber" HeaderText="S.No" HeaderStyle-Font-Bold="true" ItemStyle-Width="32px" HeaderStyle-Width="32px" />
                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtOrder_by"    CssClass="underlined" Text='<%# Bind("ORDERBY") %>' Height="20px" Width="30px" onkeypress="return pin(event)" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="Left" />
                                    </asp:TemplateField>


                                   <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtch_name"  CssClass="underlined" placeholder = "Charge Name"  Text='<%# Bind("CHARGE_NAME") %>' runat="server" onblur="Calculation(this)"                                       
                                            Height="20px" Width="190px" Font-Size="12px"  ></asp:TextBox>
                                            <asp:HiddenField ID="hfCustomerId" runat="server" />
                                            <br>
                                           
                                          <asp:TextBox ID="txt_charge_desc"  CssClass="underlined" placeholder = "Description" Text='<%# Bind("CHARGE_DESC") %>' runat="server" onblur="Calculation(this)"                                       
                                            Height="20px" Width="190px" Font-Size="12px"  ></asp:TextBox>

                                       </ItemTemplate>
                                         <ItemStyle Width="190px" />
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
                                           <asp:TextBox ID="txt_HSN_Code" CssClass="underlined" placeholder = "HSN Code" Text='<%# Bind("HSN_CODE") %>' runat="server"                                        
                                            Height="20px" Width="50px"  Font-Size="12px"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="50px" />
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SA_Code" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_SA_Code" CssClass="underlined" placeholder = "SA Code" Text='<%# Bind("SA_CODE") %>' runat="server"                                       
                                            Height="20px" Width="50px"  Font-Size="12px"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="50px" />
                                   </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Qty" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtqty"  CssClass="underlined"  Text='<%# Bind("Qty") %>' Height="20px" Width="28px" Font-Size="12px" 
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            runat="server" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="30px" />
                                      </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cur" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddl_CUR"  Text='<%# Bind("CUR") %>' MaxLength="20" runat="server"
                                               Width="49px" Height="22px" Font-Size="12px"  CssClass=" txtbox_trans_exp_drawback">
                                               <asp:ListItem>INR</asp:ListItem>
                                               <asp:ListItem>USD</asp:ListItem>
                                           </asp:DropDownList>
                                       </ItemTemplate>
                                         <ItemStyle Width="50px" />
                                   </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Ex_Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txt_Ex_Rate" CssClass="underlined" Text='<%# Bind("EX_RATE") %>' runat="server"                                        
                                            Height="20px" Width="30px" Font-Size="12px"   ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="30px" />
                                   </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Unit Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="75px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtunit_price"  CssClass="underlined"   Text='<%# Bind("UNIT_RATE") %>'
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="75px" Font-Size="12px"  runat="server" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="75px" />
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="75px">
                                       <ItemTemplate > 
                                           <asp:TextBox ID="txtamt"  CssClass="underlined" Text='<%# Bind("AMOUNT") %>'  BackColor="WhiteSmoke"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="75px" Font-Size="12px"  runat="server"   ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="75px" />
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="C-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtCGST_RATE" CssClass="underlined" Text='<%# Bind("CGST_RATE") %>'   BackColor="#F9B7FF"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="30px" Font-Size="12px"  runat="server" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="30px" />
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="C-Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                       <ItemTemplate > 
                                           <asp:TextBox ID="txtCGST_AMT" CssClass="underlined" Text='<%# Bind("CGST_AMT") %>'   BackColor="WhiteSmoke"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="70px"  Font-Size="12px"  runat="server"   ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="70px" />
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="S-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtSGST_RATE"  CssClass="underlined"   Text='<%# Bind("SGST_RATE") %>'  BackColor="#F9B7FF"  
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="30px" Font-Size="12px"  runat="server" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="30px" />
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="S-Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                       <ItemTemplate > 
                                           <asp:TextBox ID="txtSGST_AMT" CssClass="underlined"  Text='<%# Bind("SGST_AMT") %>'   BackColor="WhiteSmoke"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="70px" Font-Size="12px"  runat="server"   ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="70px" />
                                     </asp:TemplateField>
                                           <asp:TemplateField HeaderText="I-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtIGST_RATE" CssClass="underlined"    Text='<%# Bind("IGST_RATE") %>' BackColor="#FFCBA4"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="30px" Font-Size="12px"  runat="server" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="30px" />
                                     </asp:TemplateField>
                                      <asp:TemplateField HeaderText="I-Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                       <ItemTemplate > 
                                           <asp:TextBox ID="txtIGST_AMT" CssClass="underlined" Text='<%# Bind("IGST_AMT") %>'     BackColor="WhiteSmoke"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="70px" Font-Size="12px"  runat="server"   ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="70px" />

                                      <FooterStyle HorizontalAlign="left"  />
                                       <FooterTemplate>
                                           <asp:Button ID="ButtonAdd" runat="server" Text="Add Row" OnClick="ButtonAdd_Click" />
                                       </FooterTemplate>
                                     </asp:TemplateField>

                                   <asp:CommandField ShowDeleteButton="True" />

                               </Columns>
                           </asp:GridView>
                             <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White" BorderStyle="None"
                                ForeColor="White" ></asp:TextBox>
                                 
                                  <p id="pTotal" style="color:Red; font-size:large;">
                            </div>

                       <div id="tag_transact_src_inner" style="width: 1150px; height:150px;">
                        <%---------------------%>
                       <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 250px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    NonTaxable Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                   <asp:TextBox ID="txtnon_tax_amt" runat="server" MaxLength="17" onkeyup="autotab(this);"   BackColor="#F5F5F5" Width="120px" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="100" ></asp:TextBox>
                                </div>
                            </div>
                           <div id="txt_container_Transact_Main_l"   style="width: 270px;">
                                <div id="tag_label_transact_Src" style="width: 135px">
                                  Taxable Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px">
                                    <asp:TextBox ID="txttax_amt" runat="server" MaxLength="17" onkeyup="autotab(this);" BackColor="#F5F5F5" Width="100px" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="101" ></asp:TextBox>
                                </div>
                            </div>
                              <div id="txt_container_Transact_Main_l" style="width: 300px">
                                <div id="tag_label_transact_Src" style="width: 175px">
                                 Total Reverse Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                    <asp:TextBox ID="txt_tot_Rev_Amt" Width="100px"  runat="server" MaxLength="17" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="102"   onblur="extractNumber(this,2,false);"
                                     onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);" ></asp:TextBox>
                                     
                                </div>
                            </div>
                             <div id="txt_container_Transact_Main_l" style="width: 145px">
                                <div id="tag_label_transact_Src" style="width: 90px">
                                  Advance Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 50px">
                                    <asp:TextBox ID="txt_Adv_amt" runat="server" MaxLength="17" Width="120px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="103"   onblur="extractNumber(this,2,false);"
                                     onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                      BackColor="#FFFFC2"  ></asp:TextBox>
                                </div>
                            </div>
                        
                        </div>

                       <div id="tag_transact_lft_in1" style="width: 1150px">
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
                           <div id="txt_container_Transact_Main_l"  style="width: 270px;">
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
                                   <div id="txt_container_Transact_Main_l"  style="width: 270px;">
                                <div id="tag_label_transact_Src" style="width: 90px;  font-weight:bold; color:Green;" >
                                  Grand Total
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px">
                                    <asp:TextBox ID="txt_grand_total" runat="server" Font-Bold="true" MaxLength="17" Width="110px" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="108" ></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <%-------------------------------------------------------------------------------%>
                       </div>
                    </div>
                  <%-------------------------------------------------------------------------------%>

                </div>
                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px;">
                    <div id="innerbox_transac_bot_inn">
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
                            <asp:Button ID="btnrpt" runat="server" tabindex="125" Text="Get Bill" OnClientClick="return GST_Imp_Exp_Billing_Job_Rpt('B');"  /> 
                        </div>

                        <div id="editbu" style="padding-top:10px;">
                         <span style="color:red;font-weight: bold; ">  Note :- </span> <span style="color:Green;"> T- Taxable, P- Pure Agent, E- Excemption, 
                            R- Reverse Charge </span>
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
            <%--</div>--%>
          
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>

             <asp:HiddenField ID="HDupdate_id" runat="server" />
             <asp:HiddenField ID="HD_I_E" runat="server" />

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


               <asp:HiddenField ID="HdtxtInvoiceNo_id" runat="server" />
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

          if (res != '') {
              var chargetype = $("[id*=ddl_tax_nontax]")
              if (res == 'N') {
                  chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 0;
              }
              else if (res == 'T') {
                  chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;
              }
              else if (res == 'P') {
                  chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 2;
              }
              else if (res == 'E') {
                  chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 3;
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

              //if (selected.val() == 'L') {
              // Tax_Cal();
              // }
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



          $("#<%=gv_Chg_Details.ClientID%> input[id*='chk_inv']:checkbox").each(function (index) {
              if ($(this).is(':checked')) {



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

                              Tot_L_O += parseFloat(IGST_AMT[index].value)
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
          document.getElementById("txt_grand_total").value = Math.round((parseFloat(sum_T) + parseFloat(Tot_L_O)+ parseFloat(sum_N.toFixed(2))).toFixed(2));
          
      }

     </script>
    
</body>
</html>
