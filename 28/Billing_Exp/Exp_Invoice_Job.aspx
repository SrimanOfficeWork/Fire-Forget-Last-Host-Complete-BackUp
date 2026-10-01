<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exp_Invoice_Job.aspx.cs"   Inherits="Exp_Invoice_Job"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export-BL Generation</title>
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
                       url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Billing_Charge_Master_List",
                       data: "{ 'mail': '" + request.term + "','Branch': '" + document.getElementById("Hd_branch").value + "' }",
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
            <div id="innerbox_MidMain">
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                       Export Billing </div>
                    <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2">
                         <span runat="server" id="WK" visible="false">
                                        <div id="tag_label_transaction_popup_gen">
                                            Working Period</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                            <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none" 
                                              AutoPostBack="True" onselectedindexchanged="ddlWorkingPeriod_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </div>
                            </span>
                                     
                      </div>
                    <div id="popupwindow_closebut_right_new">

                     <span id="F" runat="server"><input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 
                      <span id="T" runat="server">  <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span> 

                    </div>
           
                </div>

                <div id="tag_transact_src_inner" style="width: 1150px">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px">


                        <div id="tag_transact_lft_in1" style="width: 1150px">


                            <div id="txt_container_Transact_Main_l" style="width: 215px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Type of Invoice:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 90px;">
                                    <asp:DropDownList ID="ddltype" CssClass="listtxt_transac_item_gen_notn" Width="85px"
                                        runat="server" AutoPostBack="True" TabIndex="1" 
                                        onselectedindexchanged="ddltype_SelectedIndexChanged">
                                       <%-- <asp:ListItem Text="Job" Value="Job"></asp:ListItem>
                                         <asp:ListItem Text="BL" Value="BL"></asp:ListItem>
                                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>--%>
                                    </asp:DropDownList>
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_l" style="width: 288px; display:none;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Branch:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 150px;">
                                    <asp:DropDownList ID="ddlbranch" CssClass="listtxt_transac_item_gen_notn" Width="155px"
                                        runat="server"  TabIndex="2">
                                    </asp:DropDownList>

                                  <%-- AutoPostBack="True"  onselectedindexchanged="ddlbranch_SelectedIndexChanged" --%>
                                </div>
                            </div>


                            <div id="txt_container_Transact_Main_l" style="width: 157px">
                                <div id="tag_label_transact_Src" style="width: 47px">
                                    Mode
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                       <asp:DropDownList ID="ddlmode" CssClass="listtxt_transac_item_gen_notn" Width="65px"
                                        AutoPostBack="True" onselectedindexchanged="ddlmode_SelectedIndexChanged"
                                        runat="server"  TabIndex="3">
                                       </asp:DropDownList>
                                       <%--AutoPostBack="True" onselectedindexchanged="ddlmode_SelectedIndexChanged"--%>

                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_l" style="width: 218px">
                                <div id="tag_label_transact_Src" style="width:60px;">
                                    Sh. Type
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                       <asp:DropDownList ID="ddlShipment_type" 
                                           CssClass="listtxt_transac_item_gen_notn" Width="100px"
                                        runat="server" AutoPostBack="True" TabIndex="3" 
                                           onselectedindexchanged="ddlShipment_type_SelectedIndexChanged">
                                       </asp:DropDownList>
                                </div>
                            </div>
                           
                            <div id="txt_container_Transact_Main_l" style="width: 150px">
                            <div id="div_From_Quot" runat="server">
                                <div id="tag_label_transact_Src">
                                    From Quotation
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 20px">
                                    <asp:CheckBox ID="From_Quotation" runat="server" Checked="true" 
                                        AutoPostBack="True" oncheckedchanged="From_Quotation_CheckedChanged" />
                                </div>
                            </div>
                            </div>
                        </div>



                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Exporter Name</div>
                                <div id="txtcon-m_Exchange">

                                     <asp:DropDownList ID="ddlExp_name" CssClass="listtxt_transac_item_gen_notn" Width="370px"
                                        runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlExp_name_SelectedIndexChanged" TabIndex="4">
                                    </asp:DropDownList>

                                     <asp:TextBox ID="txtexporterName" runat="server" MaxLength="50" 
                                        onkeyup="autotab(this);" Width="370px" AutoPostBack="true"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="6" 
                                         ontextchanged="txtexporterName_TextChanged" ></asp:TextBox>


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width:160px;">
                            <div id="div_type" runat="server">
                                <div id="tag_label_transact_Src" style="width:50px;">
                                    Job No
                                </div>
                                <div id="txtcon-m_Exchange" style="width:105px;">
                                    <asp:DropDownList ID="ddljobno" CssClass="listtxt_transac_item_gen_notn" 
                                        Width="100px" AutoPostBack="true"
                                        runat="server" onselectedindexchanged="ddljobno_SelectedIndexChanged1" 
                                        TabIndex="5"   >
                                    </asp:DropDownList>
                                </div>

                                </div>
                            </div>


                             <div id="txt_container_Transact_Main_l" style="width:218px;">
                                <div id="div_loc" runat="server">
                                    <div id="tag_label_transact_Src" style="width:60px;">
                                        Location
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:150px;">
                                        <asp:DropDownList ID="ddl_loc" CssClass="listtxt_transac_item_gen_notn" 
                                            Width="150px" runat="server" TabIndex="5" AutoPostBack="true" onselectedindexchanged="ddl_loc_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                               <div id="txt_container_Transact_Main_l" style="width:221px;">
                                    <div id="tag_label_transact_Src" style="width:80px;">
                                        Bill Status
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:105px;">
                                        <asp:DropDownList ID="ddl_Bill_status" CssClass="listtxt_transac_item_gen_notn" Width="100px"  runat="server" TabIndex="5">
                                        <asp:ListItem Text="Pending" Value="P"></asp:ListItem>
                                        <asp:ListItem Text="Completed" Value="D"></asp:ListItem>
                                        <asp:ListItem Text="Cancelled" Value="C"></asp:ListItem>
                                           
                                        </asp:DropDownList>
                                    </div>
                                
                            </div>
                        </div>
                    </div>
                 
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
                <div class="content" id="page-1"  style="margin-top:-28px;">
                        
            <div id="innerbox_MidMain_Trans_new" style="height:440px; width:1079px; margin-left:-9px; margin-top:-5px;">
                <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span>General </span></a></li>
                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span>Charge details</span></a></li>
                    <li ><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server" visible="false">
                        <span>Gen -3</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        </a></li>
                    
                </ol>
                
                    <div   class="content" id="page-6"   >

                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:329px;margin-top: -16px; margin-left:-18px;">
                        <div id="tag_transact_src_inner" style="width: 1150px">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px">
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Invoice No:
                                </div>
                                <%--  <div id="txtcon-m_Exchange" >
                                        <asp:TextBox ID="txtmode" runat="server" MaxLength="17" onkeyup="autotab(this);" width="60px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                    <b>/</b>

                                   <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="17" onkeyup="autotab(this);"  width="75px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                               
                                </div>--%>

                                <div id="txtcon-m_Exchange" > 
                                  <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="17" onkeyup="autotab(this);"  
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="12" ></asp:TextBox>
                                </div>

                               

                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 265px">
                                <div id="tag_label_transact_Src">
                                    Invoice Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                      <asp:TextBox ID="txtDate" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                    TabIndex="13"></asp:TextBox>
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
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    SB Number:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtsbno" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="14" 
                                        onkeypress="return num1(event)" ></asp:TextBox>

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    SB Date:
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txtsbdate" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="15"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtsbdate"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtsbdate"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                </div>
                            </div>
                        </div>
                         <%--------------------------------------Row 2-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l" >
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  <%--  MAWB NO:--%>
                                    <asp:Literal ID="lblA_S_1" runat="server"></asp:Literal>
                                    </div>
                                <div id="txtcon-m_Exchange">
                                  
                                      <asp:TextBox ID="txtmawbno" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="16" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 266px;">
                                <div id="tag_label_transact_Src">
                                   <%-- HAWB NO:--%>
                                      <asp:Literal ID="lblA_S_2" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange">
                                      <asp:TextBox ID="txthawbno" runat="server" MaxLength="100" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="17" ></asp:TextBox>
                                </div>
                            </div>

                                 <div id="txt_container_Transact_Main_l"  style="width: 180px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    No. of Pkgs:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                      <asp:TextBox ID="txtno_of_pkg" runat="server" MaxLength="17" 
                                          onkeyup="autotab(this);" Width="80px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="18" ></asp:TextBox>
                                </div>
                            </div>

                                 <div id="txt_container_Transact_Main_l" style="width: 180px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                   Gross Wgt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                      <asp:TextBox ID="txtgross_wgt" runat="server" MaxLength="17" 
                                          onkeyup="autotab(this);"  Width="80px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="19" ></asp:TextBox>
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 125px;">
                                <div id="tag_label_transact_Src" style="width: 60px;">
                                   Net Wgt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 65px;">
                                      <asp:TextBox ID="txtnetwgt" runat="server" MaxLength="17" 
                                          onkeyup="autotab(this);"  Width="65px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="20" ></asp:TextBox>
                                </div>
                            </div>
                            
                        </div>
                         <%--------------------------------------Row 3-----------------------------------------%>
                          <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 548px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Job Inv No & Date:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtjob_invno" runat="server" MaxLength="200" onkeyup="autotab(this);" Width="415px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="21" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 265px; display:none;" >
                                <div id="tag_label_transact_Src">
                                    Job Inv. Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                      <asp:TextBox ID="txtJob_inv_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="22"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txtJob_inv_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txtJob_inv_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    Volume:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtvolume" runat="server" MaxLength="17" 
                                        onkeyup="autotab(this);" 
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="23" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l"  style="width: 285px">
                                <div id="tag_label_transact_Src">
                                   Vessel:
                                </div>
                                <div id="txtcon-m_Exchange">
                                     <asp:TextBox ID="txtvessel" runat="server" MaxLength="100" 
                                         onkeyup="autotab(this);" Width="100px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="24" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <%--------------------------------------Row new-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Destination:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtdestination" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="25" ></asp:TextBox>
                                </div>
                            </div>

                            <%-- <div id="divcon"  runat="server" style="display:none;">--%>
                            <div id="txt_container_Transact_Main_l" style="width: 265px">
                                <div id="tag_label_transact_Src">
                                    Container No:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                       <asp:TextBox ID="txtconatiner_no" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="26" ></asp:TextBox>
                                </div>
                            </div>
                           <%-- </div>--%>


                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src">
                                    Commodity:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtcommodity" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="27" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l"  style="width: 285px">
                                <div id="tag_label_transact_Src">
                                   Freight Status:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:DropDownList ID="ddl_freight_status" 
                                        CssClass="listtxt_transac_item_gen_notn" Width="65px"
                                        runat="server" TabIndex="28">
                                        <asp:ListItem Text="CC" Value="CC"></asp:ListItem>
                                          <asp:ListItem Text="PP" Value="PP"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                         <%--------------------------------------Row 4-----------------------------------------%>
                       
                         <%--<div id="tag_transact_lft_in1" style="width: 1150px">
                              
                         </div>--%>

                         <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   A/C Behalf
                                </div>
                                <div id="txtcon-m_Exchange">
                                   
                                    <asp:CheckBox ID="ch_Behalf" runat="server" TabIndex="29" />
                                </div>
                            </div>

                            <div id="divCh" runat="server" style="display:none;">
                             <div id="txt_container_Transact_Main_l" style="width: 290px"> <%--style="width: 265px"--%>
                                <div id="tag_label_transact_Src">
                                    Charge Wgt:
                                </div>
                                  <div id="txtcon-m_transaction_code">
                                        <asp:TextBox ID="txtchargeWeight" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="12" TabIndex="30" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM2_empty">
                                    </div>
                                        <div id="txtcon_m_transaction_IGM_Wght_small">
                                        <asp:TextBox ID="txtchargeWeightType" runat="server" CssClass="txtbox_none_Mid_transac_IGM_wght_small"
                                            ClientIDMode="Static" MaxLength="3" TabIndex="31" onkeypress="return char1(event)"
                                            onblur="ChangeCase(this);"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area">
                                        <a href="#" onclick="OpenPopupUnit('Export_Billing_Charge_wgt'); return false" class="magnfy">
                                        </a>
                                    </div>
                            </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 265px;">
                                <div id="tag_label_transact_Src" style="width: 70px">
                                    Job Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                      <asp:TextBox ID="txtJob_Date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                    TabIndex="19"></asp:TextBox>
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
                       
                        <div id="txt_container_Transact_Main_l" style="width: 280px">
                                 <div id="tag_label_transact_Src">
                                     FOB. Value
                                 </div>
                                 <div id="txtcon-m_Exchange">
                                     <asp:TextBox ID="txt_FOB_Value" runat="server" CssClass="txtbox_none_Mid_transac_Inv_No"
                                         Width="100px" MaxLength="20" TabIndex="25" onblur="extractNumber(this,3,false);"
                                         onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"></asp:TextBox>
                                 </div>
                             </div>


                        </div>
                         <%--------------------------------------Row 6-----------------------------------------%>
                     <%--    <div id="innerbox_MidMain_Trans" style="width: 1080px;height:0.1px; margin-left:-20px;">
                          </div>--%>
                           <%--------------------------------------AddRow 1-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Shipper Name:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 330px;">
                                   <asp:TextBox ID="txtshippername" runat="server" MaxLength="50" 
                                        onkeyup="autotab(this);" Width="330px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="32" ></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                          <%--  <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false">
                                            </a>--%>
                                             <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('Bill_Exp_name'); return false">
                                            </a>
                                        </div>
                            </div>
                            
                               <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                   Consignee Name:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 310px;">
                                   <asp:TextBox ID="txtconsigneename" runat="server" MaxLength="50" 
                                        onkeyup="autotab(this);" Width="310px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="34" ></asp:TextBox>
                                </div>
                                <div id="magnify_area">
                                          <%--  <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false">
                                            </a>--%>
                                               <a class="magnfy" href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupConsignee('Bill_Con_name'); return false">
                                            </a>
                                        </div>
                            </div>

                            
                        </div>
                           <%--------------------------------------AddRow 2-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1150px;height:70px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Address :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 373px;">
                                   <asp:TextBox ID="txtShip_Add1" runat="server" MaxLength="500" 
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  Height="60px" TabIndex="33" ></asp:TextBox>
                                </div>
                            </div>
                            
                               <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                  Address :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 210px;">
                                   <asp:TextBox ID="txtCon_Add1" runat="server" MaxLength="500" 
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="35" Height="60px" ></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                      
                           <%--------------------------------------AddRow 6-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1150px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Notify Party 1:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 380px;">
                                   <asp:TextBox ID="txt_notify_party_1" runat="server" MaxLength="50" 
                                        onkeyup="autotab(this);" Width="350px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="36" ></asp:TextBox>
                                </div>
                            </div>
                            
                               <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                 Notify Party 2:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 330px;">
                                   <asp:TextBox ID="txt_notify_party_2" runat="server" MaxLength="50" 
                                        onkeyup="autotab(this);" Width="330px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="38" ></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                           <%--------------------------------------AddRow 7-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1150px; height:70px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px; height:150px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  Address
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 210px;height:150px;">
                                   <asp:TextBox ID="txt_notify_party_1_add" runat="server" MaxLength="17" 
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="37"  Height="60px" ></asp:TextBox>
                                </div>
                            </div>
                            
                               <div id="txt_container_Transact_Main_l" style="width: 500px;height:100px;">
                                <div id="tag_label_transact_Src" style="width: 150px;">
                                   Address 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 210px;height:150px;">
                                   <asp:TextBox ID="txt_notify_party_2_add" runat="server" MaxLength="17" 
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  Height="60px" TabIndex="39" ></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                         
                           <%--------------------------------------AddRow 11-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1150px; height:70px;">
                          <div id="txt_container_Transact_Main_l" style="width: 950px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Remarks:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 810px;">
                                   <asp:TextBox ID="txt_Remarks" runat="server" MaxLength="500" onkeyup="autotab(this);" width= "800px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>

                            
                        </div>
                           
                           <%--------------------------------------AddRow 12-----------------------------------------%>
                             <%--<div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 950px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Description:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 810px;">
                                   <asp:TextBox ID="txt_tax_desc" runat="server" MaxLength="500" onkeyup="autotab(this);" width= "800px"
                                    CssClass="validate[required] txtbox_none_Mid_transac_Inv_No" TabIndex="1" ></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>
                            
                         

                         <%--------------------------------------Row End-----------------------------------------%>
                    </div>
                 
                </div>
                        </div>
                    </div>

                    <div  class="content"  id="page-7"  style="display:none;height:440px;"  >
                        <div id="pop_text_area_transac_popup_inn_container_export" style=" height:220px;margin-left:-17px; ">

                        <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow:auto; height:30px; width:1079px;margin-top:-10px; ">

                             <asp:GridView ID="GV" runat="server" AllowSorting="True" 
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" 
                                    BorderStyle="none" ShowFooter="false"  CssClass="grid-view"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1"  AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" 
                                    style=" overflow:auto;" >
                                     
                                     <Columns>

                                       <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="S. No"  HeaderStyle-Width="62px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Right"  Width="62px" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="a" HeaderText="Charge Name"  HeaderStyle-Width="300px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left" Width="30px"  />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="b" HeaderText="Charge Details" HeaderStyle-Width="190px"   >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left"   Width="190px"  />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="c" HeaderText="Sh. Type"  HeaderStyle-Width="72px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left" Width="72px" />
                                    </asp:BoundField>

                                      <asp:BoundField DataField="d" HeaderText="Qty" HeaderStyle-Width="50px"  >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left"  Width="50px" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="e" HeaderText="Unit Rate" HeaderStyle-Width="95px"  >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left"  Width="95px"  />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="f" HeaderText="Amount"  HeaderStyle-Width="110px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left"  Width="110px"  />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="g" HeaderText="Special %"  HeaderStyle-Width="70px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left" Width="70px" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="g" HeaderText="Type" HeaderStyle-Width="50px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left" Width="50px"   />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="g" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"  >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  HorizontalAlign="Left"  />
                                    </asp:BoundField>
                                   
                                     </Columns>
                                    </asp:GridView>
                        </div>

                            <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow:auto; height:203px; width:1084px;margin-top:-10px;">
                             <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" 
                                    BorderStyle="none" ShowFooter="True" 
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1"  AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_Chg_Details_RowCreated"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" 
                                    onrowdeleting="gv_Chg_Details_RowDeleting"
                                    
                                    ShowHeader = "false" 
                                    style=" overflow-x: hidden;overflow-y: auto;" >
                                    
                                    <RowStyle BorderWidth="0.1em" BorderColor="black" /> 
                               <Columns>

                                   <asp:TemplateField HeaderText="ch_inv" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                       <ItemTemplate>
                                           
                                        <asp:CheckBox ID="chk_inv" runat="server" HeaderText="ch_inv"   Width="30px" 
                                                Checked='<%#bool.Parse(Eval("INV_CHECK").ToString())%>' 
                                                 oncheckedchanged="chk_inv_CheckedChanged"  />
                                       </ItemTemplate>
                                         <ItemStyle Width="30px" />
                                   </asp:TemplateField>


                                   <asp:BoundField DataField="RowNumber" HeaderText="S.No" HeaderStyle-Font-Bold="true" ItemStyle-Width="32px" HeaderStyle-Width="32px" />

                                   <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtch_name" Text='<%# Bind("CHARGE_NAME") %>' runat="server"  onblur="Calculation(this)"                                       
                                            Height="20px" Width="300px"   ></asp:TextBox>
                                            <asp:HiddenField ID="hfCustomerId" runat="server" />
                                       </ItemTemplate>
                                         <ItemStyle Width="300px" />
                                   </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Charge details" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtch_det" Text='<%# Bind("CHARGE_DETAILS") %>' runat="server" 
                                         
                                            Height="20px" Width="200px"  ></asp:TextBox>
                                       </ItemTemplate>
                                         <ItemStyle Width="200px" />
                                   </asp:TemplateField>

                                     
                                   <asp:TemplateField HeaderText="Shipment Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="72px">
                                       <ItemTemplate> 
                                            <asp:TextBox ID="txtshiptype"  Text='<%# Bind("SHIPMENT_TYPE") %>' Height="20px"
                                                Width="71px" runat="server"></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="72px"  />
                                   </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Exch-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="15px">
                                          <ItemTemplate> 
                                           <asp:TextBox ID="txtEx_rate"    Text='<%# Bind("EX_RATE") %>' Height="20px" Width="15px"  runat="server" ></asp:TextBox>
                                          </ItemTemplate>
                                          <ItemStyle Width="15px"  CssClass="hideGridColumn"/>
                                           <HeaderStyle CssClass="hideGridColumn" />
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Qty" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtqty"   Text='<%# Bind("Qty") %>' Height="20px"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Width="40px"  runat="server" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="40px" />
                                      </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Unit Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="85px">
                                       <ItemTemplate> 
                                           <asp:TextBox ID="txtunit_price"    Text='<%# Bind("DEFAULT_UNIT_RATE") %>' Height="20px" Width="85px"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                             runat="server" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="85px" />
                                     </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="110px">
                                       <ItemTemplate > 
                                           <asp:TextBox ID="txtamt"    Text='<%# Bind("MIN_AMOUNT") %>'
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="110px"  runat="server"  ontextchanged="txtamt_TextChanged" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="110px" />
                                     </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                       <ItemTemplate > 
                                           <asp:TextBox ID="txt_spltaxRate"  Text='<%# Bind("SPL_CHARGE_RATE") %>'
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="20px" Width="70px"  runat="server" ></asp:TextBox>
                                       </ItemTemplate>
                                       <ItemStyle Width="70px" />
                                     </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="50px">
                                       <ItemTemplate>

                                           <asp:DropDownList ID="txtpp_CC" Text='<%# Bind("Type") %>' MaxLength="20" runat="server" 
                                                 onselectedindexchanged="txtpp_CC_SelectedIndexChanged"
                                               Width="49px" Height="22px" CssClass=" txtbox_trans_exp_drawback">
                                               <asp:ListItem>N</asp:ListItem>
                                               <asp:ListItem>T</asp:ListItem>
                                               
                                           </asp:DropDownList>

                                       </ItemTemplate>
                                       <ItemStyle Width="80px" />
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
                    
                    <%----------gridend------------%>
                     </div>

                       <div id="tag_transact_src_inner" style="width: 1150px; height:150px;">
                       <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    NonTaxable Amt:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txtnon_tax_amt" runat="server" MaxLength="17"  BackColor="#F5F5F5"
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="45" ></asp:TextBox>
                                </div>
                            </div>
                           <div id="txt_container_Transact_Main_l" style="width: 335px">
                                <div id="tag_label_transact_Src" style="width: 155px">
                                  Taxable Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px"> 
                                    <asp:TextBox ID="txttax_amt" runat="server" MaxLength="17"  BackColor="#F5F5F5"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="46" ></asp:TextBox>
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 295px"></div>                           
                            <div id="txt_container_Transact_Main_l" style="width: 175px;display:none;"">
                                <div id="tag_label_transact_Src" style="width: 105px">
                                  Charge Zoom
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 60px">
                                    <asp:ImageButton ID="Button1" runat="server" ImageUrl="~/images/icons/Zoom_Icon.png" />
                                </div>
                            </div>



                        
                        </div>

                         <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Tax Ledger 1:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_leg_1" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="232px"  BackColor="#F5F5F5"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="47" ></asp:TextBox>
                                </div>
                            </div>
                               <div id="magnify_area">
                                         
                                        </div>
                             <div id="txt_container_Transact_Main_l" style="width: 155px">
                                 <div id="tag_label_transact_Src" style="width: 53px">
                                     Tax %:
                                 </div>
                                 <div id="txtcon-m_Exchange" style="width: 75px">
                                     <asp:TextBox ID="txt_leg_Per_1" Font-Bold="true"  width="75px" runat="server" MaxLength="17" 
                                     onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                         CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="48"></asp:TextBox>
                                 </div>
                             </div>
                              <div id="txt_container_Transact_Main_l" style="width: 155px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                   <asp:TextBox ID="txt_tax_amt_1" runat="server" MaxLength="17" width="80px"
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="49" ></asp:TextBox>
                                </div>
                            </div>

                              <div id="magnify_area">
                                         
                               </div>
                                <div id="txt_container_Transact_Main_l" style="width: 135px;">
                                <div id="tag_label_transact_Src" style="width: 140px;">
                                     <asp:TextBox ID="txt_tax_leg_3" runat="server" width="120px" MaxLength="17" onkeyup="autotab(this);"  Enabled="false" BackColor="#F5F5F5"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="53" ></asp:TextBox>
                                </div>
                                </div>
                                 <div id="magnify_area">
                                         
                               </div>
                            <div id="txt_container_Transact_Main_l" style="width: 145px;">
                                <div id="txtcon-m_Exchange" style="width: 55px;">
                                       <asp:TextBox ID="txt_leg_Per_3" runat="server" width="50px" MaxLength="17"   Enabled="false" BackColor="#F5F5F5"
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" Font-Bold="true" TabIndex="54" ></asp:TextBox>
                                </div>
                                 <div id="magnify_area"></div>
                                <div id="txtcon-m_Exchange" style="width: 55px;">
                                    <asp:TextBox ID="txt_tax_amt_3" runat="server" MaxLength="17" width="50px"  Enabled="false" BackColor="#F5F5F5"
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="55" ></asp:TextBox>
                                </div>
                            </div>
                        
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Tax Ledger 2:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_leg_2" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="232px" BackColor="#F5F5F5"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="50" ></asp:TextBox>
                                </div>
                            </div>
                               <div id="magnify_area">
                                           <%-- <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false">
                                            </a>--%>
                                        </div>
                           <div id="txt_container_Transact_Main_l" style="width: 155px">
                                <div id="tag_label_transact_Src" style="width: 53px">
                                  Tax %:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 75px">
                                    <asp:TextBox ID="txt_leg_Per_2" runat="server" Font-Bold="true" MaxLength="17" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  width="75px" TabIndex="51" ></asp:TextBox>
                                </div>
                                 
                            </div>

                        <div id="txt_container_Transact_Main_l" style="width: 165px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                   <asp:TextBox ID="txt_tax_amt_2" runat="server" width="80px" MaxLength="17"
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="52" ></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Tax Ledger 3:
                                </div>
                                <div id="txtcon-m_Exchange"  style="width: 185px;">
                                   <asp:TextBox ID="txt_tax_leg_4" runat="server" MaxLength="17" onkeyup="autotab(this);"  Width="232px" BackColor="#F5F5F5"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="53" ></asp:TextBox>
                                </div>
                            </div>

                              <div id="magnify_area">
                                            <%--<a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Country_origin'); return false">
                                            </a>--%>
                                        </div>

                           <div id="txt_container_Transact_Main_l" style="width: 155px">
                                <div id="tag_label_transact_Src" style="width: 53px">
                                  Tax %:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 75px">
                                    <asp:TextBox ID="txt_leg_Per_4" runat="server" width="75px" MaxLength="17" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" Font-Bold="true" TabIndex="54" ></asp:TextBox>
                                </div>
                            </div>


                               <div id="txt_container_Transact_Main_l" style="width: 165px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                   <asp:TextBox ID="txt_tax_amt_4" runat="server" MaxLength="17" width="80px" 
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="55" ></asp:TextBox>
                                </div>
                            </div>
                        
                         <div id="txt_container_Transact_Main_l" style="width: 185px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                    Advance Amt:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 80px;">
                                   <asp:TextBox ID="txt_Adv_amt" runat="server" width="80px" MaxLength="17" 
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="55" ></asp:TextBox>
                                </div>
                            </div>
                        </div>
                       

                       <div id="tag_transact_lft_in1" style="width: 1150px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;font-weight:bold;">
                                    Total Tax Amt:
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_total_tax_amt" runat="server" MaxLength="17" 
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="56" ></asp:TextBox>
                                </div>
                            </div>
                           <div id="txt_container_Transact_Main_l" style="width: 336px">
                                <div id="tag_label_transact_Src" style="width: 155px;font-weight:bold;">
                                  Total Amt with Tax:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                    <asp:TextBox ID="txt_total_amt_With_tax" runat="server" MaxLength="17" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="57" ></asp:TextBox>
                                </div>
                            </div>
                        
                         <div id="txt_container_Transact_Main_l" style="width: 435px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                    Description:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 340px;">
                                   <asp:TextBox ID="txt_tax_desc" runat="server" MaxLength="17"  onkeyup="autotab(this);"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  width= "340px" ></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        


                       </div>

                    </div>

                    <div  class="content"  id="page-8"  >
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:225px;">
                          
                        </div>
                    </div>

                    <div  class="content" id="page-9"  >
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:225px;">
                         
                        </div>
                    </div>
                  <%-------------------------------------------------------------------------------%>
                    

                </div>
                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="61" onclick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="59" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="60" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="62" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Invoice?', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="51" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="63">
                        </div>

                       <%-- <div id="editbu" style="padding-top:5px;">
                            <asp:Button ID="btnrpt" runat="server" tabindex="64" Text="Report" OnClientClick="return Export_Billing_Job_Rpt();" />
                        </div>--%>

                             <div id="editbu" style="width:10px;"></div>
                        <div id="editbu" style="padding-top:5px;">
                            <asp:Button ID="btnrpt" runat="server" tabindex="64" Text="Tax & Non-Tax Bill" OnClientClick="return Export_Billing_Job_Rpt('B');" />
                        </div>
                        <div id="editbu" style="width:10px;"></div>
                         <div id="editbu" style="padding-top:5px;">
                            <asp:Button ID="btn_T_rpt" runat="server" tabindex="64" Text="Tax Bill" OnClientClick="return Export_Billing_Job_Rpt('T');" />
                        </div>
                        <div id="editbu" style="width:10px;"></div>
                         <div id="editbu" style="padding-top:5px;">
                            <asp:Button ID="btn_T_N_rpt" runat="server" tabindex="64" Text="Non-Tax Bill" OnClientClick="return Export_Billing_Job_Rpt('N');" />
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
                <%-----------------------------------END----------------------------------------------------------------%>
            
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>

             <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />
             <asp:HiddenField ID="HDupdate_id" runat="server" />

             <asp:HiddenField ID="HD_Showcon" runat="server" />

             <asp:HiddenField ID="HD_Bill_Jobno" runat="server" />
             <asp:HiddenField ID="Hd_branch" runat="server" />
             
              <asp:HiddenField ID="HDinv_date" runat="server" />

              <asp:HiddenField ID="hd_hss_exp" runat="server" />
              <asp:HiddenField ID="hd_EXP_br_sl_no" runat="server" />

              <asp:HiddenField ID="hdemp" runat="server" />
              <asp:HiddenField ID="hd_EXP_Brslno" runat="server" />

               <asp:HiddenField ID="hd_ch_type" runat="server" />
              <asp:HiddenField ID="Hd_row_id" runat="server" />
       
     <asp:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="Button1"
                CancelControlID="btnClose" BackgroundCssClass="modalBackground">
            </asp:ModalPopupExtender>
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none;
                width: 1052px; height: 533px;" BorderColor="Transparent">
                <script type="text/javascript">
                    function Calculation_2(lnk) {
                        var grid = document.getElementById("<%= gv_Chg_Details_2.ClientID%>");
                        var txtAmountReceive = $("[id*=txtch_name]")
                        var txtAmountReceive_2 = $("[id*=txtpp_CC]")
                        var row = lnk.parentNode.parentNode;
                        var rowIndex = row.rowIndex;
                        var a = txtAmountReceive[rowIndex].value;
                        var b = '1';

                        $('#Hd_row_id').val(rowIndex);
                        Cha_Type(a, b);
                    }  
                </script>
                <asp:Button ID="btnClose" runat="server" Style="display: none" />
                <div id="innerbox_MidMain_Trans_IGM_Invoice" style="text-align: left; height: 533px;
                    width: 1052px;">
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Import Charge Details
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon" onclick="$find('mp1').hide();" />
                    </div>
                    <div id="innerbox_MidMain_bot_transact" style="height: 10px;">
                    </div>
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 410px;">
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 30px;
                            width: 1050px; margin-top: -10px;">
                            <asp:GridView ID="GV_2" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                                Style="overflow: auto;">
                                <Columns>
                                    <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="S. No" HeaderStyle-Width="65px">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="65px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="a" HeaderText="Charge Name" HeaderStyle-Width="300px">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="b" HeaderText="Charge Details">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="c" HeaderText="Sh. Type">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="d" HeaderText="Qty">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="e" HeaderText="Unit Rate">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="f" HeaderText="Amount">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="g" HeaderText="Type">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="g" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">
                                        <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 430px;
                            width: 1050px; margin-top: -10px;">
                            <asp:GridView ID="gv_Chg_Details_2" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                                AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                OnRowCreated="gv_Chg_Details_RowCreated" OnRowDataBound="gv_Chg_Details_RowDataBound"
                                 ShowHeader="false" Style="overflow-x: hidden;
                                overflow-y: auto;"> <%--OnRowDeleting="gv_Chg_Details_2_RowDeleting"--%>
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="ch_inv" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_inv" runat="server" HeaderText="ch_inv" Width="30px" Checked='<%#bool.Parse(Eval("INV_CHECK").ToString())%>'
                                                OnCheckedChanged="chk_inv_CheckedChanged" />
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RowNumber" HeaderText="S.No" HeaderStyle-Font-Bold="true"
                                        ItemStyle-Width="32px" HeaderStyle-Width="32px" />
                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtch_name" Text='<%# Bind("CHARGE_NAME") %>' runat="server" onblur="Calculation_2(this)"
                                                Height="20px" Width="300px" TextMode="MultiLine"></asp:TextBox>
                                            <asp:HiddenField ID="hfCustomerId" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle Width="300px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Charge details" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtch_det" Text='<%# Bind("CHARGE_DETAILS") %>' runat="server" Height="20px"
                                                Width="200px" TextMode="MultiLine"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shipment Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="82px">
                                        <ItemTemplate>
                                               <asp:TextBox ID="txtshiptype"  Text='<%# Bind("SHIPMENT_TYPE") %>' Height="20px"
                                                Width="80px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="82px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Exch-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="15px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtEx_rate" TextMode="MultiLine" Text='<%# Bind("EX_RATE") %>' Height="20px"
                                                Width="15px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="15px" CssClass="hideGridColumn" />
                                        <HeaderStyle CssClass="hideGridColumn" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtqty" TextMode="MultiLine" Text='<%# Bind("Qty") %>' Height="20px"
                                            onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                                Width="70px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Unit Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="75px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtunit_price" TextMode="MultiLine" Text='<%# Bind("DEFAULT_UNIT_RATE") %>'
                                            onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"  onkeypress="return blockNonNumbers(this, event, true, false);"
                                                Height="20px" Width="75px" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="75px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="110px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtamt" TextMode="MultiLine" Text='<%# Bind("MIN_AMOUNT") %>' onblur="extractNumber(this,3,false);"
                                                onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                Height="20px" Width="110px" runat="server" OnTextChanged="txtamt_TextChanged"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="110px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="txtpp_CC" Text='<%# Bind("Type") %>' MaxLength="20" runat="server"
                                                OnSelectedIndexChanged="txtpp_CC_SelectedIndexChanged" Width="49px" Height="22px"
                                                CssClass=" txtbox_trans_exp_drawback">
                                                <asp:ListItem>N</asp:ListItem>
                                                <asp:ListItem>T</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="80px" />
                                        <FooterStyle HorizontalAlign="left" />
                                        <FooterTemplate>
                                            <asp:Button ID="ButtonAdd_2" runat="server" Text="Add Row"  /><%-- OnClick="ButtonAdd_2_Click"--%>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" />
                                </Columns>
                            </asp:GridView>
                            <asp:TextBox ID="txtfocus_2" Width="1px" MaxLength="1" runat="server" BorderColor="White"
                                BorderStyle="None" ForeColor="White"></asp:TextBox>
                            <p id="pTotal" style="color: Red; font-size: large;">
                        </div>
                        <span style="padding-left: 47%">
                            <asp:Button ID="btnsaveclose" runat="server" Text="Save & Close" /> <%-- OnClick="btnsaveclose_Click" --%>
                        </span>
                    </div>
                </div>
            </asp:Panel>

               </ContentTemplate>
    </asp:UpdatePanel>


    </form>
   
    <script  src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>
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
            //document.getElementById("btn_cancel").click();
            document.getElementById("General").click();
        }
        
    </script>
   
   
   <script type="text/javascript">
       $(document).ready(function () {
           $('#txtshippername').focus(function () {

               var data = $(this).val();
               Item_desc(data);

           });
           $('#txtshippername').change(function () {

               var data = $(this).val();
               Item_desc(data);

           });
           $('#txtshippername').keyup(function () {

               var data = $(this).val();
               Item_desc(data);

           });
           $('#txtshippername').keydown(function () {

               var data = $(this).val();
               Item_desc(data);

           });
       });

       function Item_desc(val) {

           var data = val;
           if (data == '') {
               $('#txtshippername').val('');
           }
           if (data.indexOf("--") != -1) {

               var s = data.split('--');

               var before = s[0];
               var after = s[1];

               $('#txtshippername').val(after);

               $('#hdemp').val(after);
               $('#hd_EXP_Brslno').val(before);

           }
           else {

           }
       }
  </script>
  <script type="text/javascript">
      $(document).ready(function () {
          $('#txt_notify_party_1').focus(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txt_notify_party_1').change(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txt_notify_party_1').keyup(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txt_notify_party_1').keydown(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
      });

      function Item_desc1(val) {

          var data1 = val;
          if (data1 == '') {
              $('#txt_notify_party_1').val('');
          }
          if (data1.indexOf("--") != -1) {

              var s = data1.split('--');

              var before = s[0];
              var after = s[1];

              $('#txt_notify_party_1').val(after);

              $('#hd_hss_exp').val(after);
              $('#hd_EXP_br_sl_no').val(before);

          }
          else {

          }
      }
  </script>

  <script type="text/javascript">
      function Calculation(lnk) {

          var grid = document.getElementById("<%= gv_Chg_Details.ClientID%>");
          var txtAmountReceive = $("[id*=txtch_name]")
          var txtAmountReceive_2 = $("[id*=txtpp_CC]")
          var row = lnk.parentNode.parentNode;
          var rowIndex = row.rowIndex;

          var a = txtAmountReceive[rowIndex].value;
          var b = '1';

          $('#Hd_row_id').val(rowIndex);

          Cha_Type(a, b);
          Tax_Cal();
          Tax_Cal();

        

      }  
          </script>
  <script type="text/javascript">

      function Cha_Type(src, dest) {
          PageMethods.Get_Cha_Type(src, $("#ddlExp_name option:selected").text(), $("#ddlmode option:selected").text(), CallSuccess_Cha_Type, CallFailed, dest);
      }
      function CallSuccess_Cha_Type(res, destCtrl) {

          if (res != '') {
              var chargetype = $("[id*=txtpp_CC]")
              if (res == 'N') {
                  chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 0;
              }
              else if (res == 'T') {
                  chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;
              }

          }
          else {
              chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;
          }
      }

      function CallFailed(res, destCtrl) {
          //alert(res.get_message());
      }

    </script>
  <script type="text/javascript">
      $(document).ready(function () {

          $('[id*=txtpp_CC]').focus(function () {

              Tax_Cal();

          });
          $('[id*=txtpp_CC]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtpp_CC]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtpp_CC]').keydown(function () {

              Tax_Cal();

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
          //------------------------------------------------------------

          $('[id*=txtch_det]').focus(function () {

              Tax_Cal();

          });
          $('[id*=txtch_det]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtch_det]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtch_det]').keydown(function () {

              Tax_Cal();

          });
          //-----------------------------------------------------------

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

          //-----------------------------------------------------------
          $('[id*=txt_spltaxRate]').focus(function () {

              Tax_Cal();

          });
          $('[id*=txt_spltaxRate]').change(function () {

              Tax_Cal();

          });
          $('[id*=txt_spltaxRate]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txt_spltaxRate]').keydown(function () {

              Tax_Cal();

          });

          //-----------------------------------------------------------
      });

       </script>
  <script type="text/javascript">

      function Tax_Cal() {
          
          var txtamt = $("[id*=txtamt]")
          var tax_type = $("[id*=txtpp_CC]")
          var txtqty = $("[id*=txtqty]")
          var txtunit_price = $("[id*=txtunit_price]")
          var txt_spltaxRate = $("[id*=txt_spltaxRate]")

          var sum_T = 0;
          var sum_N = 0;

          var sum_T_amt = 0;
          var sum_T_amt_2 = 0;
          var sum_T_amt_Krishi = 0;

          var Spl_amt = 0;
          
          var counter = 0;
          $("#<%=gv_Chg_Details.ClientID%> input[id*='chk_inv']:checkbox").each(function (index) {
              if ($(this).is(':checked')) {

                  if (!isNaN(txtamt[index].value) && txtamt[index].value.length != 0) {

                      if (tax_type[index].value == 'T') {

                          txtamt[index].value = txtqty[index].value * txtunit_price[index].value;
                          if (txt_spltaxRate[index].value != '' && txt_spltaxRate[index].value != '0') {

                              sum_T += (parseFloat(txtamt[index].value) * txt_spltaxRate[index].value / 100.00)
                          }
                          else {
                              sum_T += parseFloat(txtamt[index].value)
                          }
                        
                      }
                      else if (tax_type[index].value == 'N') {
                          txtamt[index].value = txtqty[index].value * txtunit_price[index].value;
                          sum_N += parseFloat(txtamt[index].value)
                      }
                  }
                  counter++;
              }
          });

          $('#txtnon_tax_amt').val(sum_N);
          $('#txttax_amt').val(sum_T);

          sum_T_amt = (parseFloat($('#txt_leg_Per_1').val()) / 100.00) * sum_T;
          sum_T_amt_2 = (parseFloat($('#txt_leg_Per_2').val()) / 100.00) * sum_T;
          sum_T_amt_Krishi = (parseFloat($('#txt_leg_Per_4').val()) / 100.00) * sum_T;
          

          document.getElementById("txt_tax_amt_1").value = (sum_T_amt).toFixed(2);
          document.getElementById("txt_tax_amt_2").value = (sum_T_amt_2).toFixed(2);
          document.getElementById("txt_tax_amt_4").value = (sum_T_amt_Krishi).toFixed(2);
          /*
          document.getElementById("txt_total_tax_amt").value = (sum_T_amt).toFixed(2);
          document.getElementById("txt_total_amt_With_tax").value = (parseFloat(sum_T_amt) + parseFloat($('#txttax_amt').val())).toFixed(2);
          */


          document.getElementById("txt_total_tax_amt").value = (parseFloat(sum_T_amt) + parseFloat(sum_T_amt_2) + parseFloat(sum_T_amt_Krishi)).toFixed(2);
          document.getElementById("txt_total_amt_With_tax").value = (parseFloat(sum_T_amt) + parseFloat(sum_T_amt_2) + parseFloat(sum_T_amt_Krishi) + parseFloat($('#txttax_amt').val())).toFixed(2);

      }
     </script>


</body>
</html>
