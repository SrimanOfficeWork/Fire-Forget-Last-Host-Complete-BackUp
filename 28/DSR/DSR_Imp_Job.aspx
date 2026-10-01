<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSR_Imp_Job.aspx.cs" Inherits="DSR_Imp_Job" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> DSR</title>
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
       #txt_container_Transact_Main_2{
        float:left;
        width:273px;
        height:25px;
        margin-top:5px;
        }
        #tag_label_transact_Src_1{
        float:left;
        width:103px;
        height:15px;
        font-family:Arial, Helvetica, sans-serif;
        font-size:13px;
        line-height:20px;
        text-align:left;
        color:#232323;
        }
        #tag_transact_lft_in_2{
        width:1092px;
        height:25px;
        float:left;
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
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain" style=" height: 30px;" >
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                      Imp. DSR Entry
                    </div>
                    <div id="verslic">
                    </div>
                     <div id="txt_container_Transact_Main_l" style="width: 490px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Importer Name</div>
                         <div id="txtcon-m_Exchange">
                             <asp:DropDownList ID="ddlCus_name" CssClass="validate[required]  listtxt_transac_item_gen_notn" Width="370px"
                                 runat="server" AutoPostBack="True" TabIndex="8" OnSelectedIndexChanged="ddlCus_name_SelectedIndexChanged">
                             </asp:DropDownList>
                         </div>

                            </div>
                    <div id="verslic" style="margin-top:-5px;"></div>

                    <div id="txt_container_Transact_Main_l" style="width: 160px;">
                        <div id="tag_label_transact_Src" style="width: 50px;">
                            Job No
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 105px;">
                            <asp:DropDownList ID="ddljobno" CssClass="listtxt_transac_item_gen_notn" Width="100px"
                                AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddljobno_SelectedIndexChanged"
                                TabIndex="10">
                            </asp:DropDownList>
                        </div>
                    </div>

                           <div id="txt_container_Transact_Main_l" style="width:210px;">
                               
                                    <div id="tag_label_transact_Src" style="width:100px;" >
                                       Manual Job No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:105px;">
                                      <asp:TextBox ID="txt_Manual_Jobno" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="11"></asp:TextBox>
                                    </div>
                               
                            </div>

                    <div id="popupwindow_closebut_right_new" >
                      <span id="F" runat="server"><input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 
                      <span id="T" runat="server">  <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span> 
                    </div>
           
                </div>
               
                 
                </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>


         <div class="content" id="page-1" style="margin-top:-28px;height:550px;">
                        
          <div id="innerbox_MidMain_Trans_new" style="height:500px; width:1094px; margin-left:-16px; margin-top:-5px;">
                <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span>General </span></a></li>
                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span>Accounts</span></a></li>
                    <li ><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server" visible="false">
                        <span>Gen -3</span></a></li>

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        <span> Gen -4 </span></a></li>
                       
                    <div id="tag_label_transact_Src_1" style="margin-top:5px; width:70px;">
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Ref-Id
                    </div>
                    <div id="tag_label_transact_Src_1" style="margin-top:5px;">
                        <asp:TextBox ID="txt_Ref_Id" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="100px"
                            ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                            CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="12"></asp:TextBox>
                    </div>
                </ol>

                 
                
                    <div   class="content" id="page-6" style="height:500px;" >

                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:500px;margin-top: -16px; margin-left:-18px; color:Red;">
                        <div id="tag_transact_src_inner" style="width: 1092px;height:500px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1092px;height:500px;">
                        <%--------------------------------------Row 1-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Business Unit
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Business_Unit" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="15"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Month & Year
                                </div>
                                <div id="txtcon-m_Exchange">

                                   <asp:DropDownList ID="ddl_Month" runat="server" CssClass="txtbox_none"  TabIndex="16" Font-Size="12px"  Width="75px"  >
                                   <asp:ListItem Text="" Value="" ></asp:ListItem>
                                   <asp:ListItem Text="Jan" Value="Jan" ></asp:ListItem>
                                   <asp:ListItem Text="Feb" Value="Feb" ></asp:ListItem>
                                   <asp:ListItem Text="Mar" Value="Mar" ></asp:ListItem>
                                   <asp:ListItem Text="Apr" Value="Apr" ></asp:ListItem>
                                   <asp:ListItem Text="May" Value="May" ></asp:ListItem>
                                   <asp:ListItem Text="June" Value="June" ></asp:ListItem>
                                   <asp:ListItem Text="July" Value="July" ></asp:ListItem>
                                   <asp:ListItem Text="Aug" Value="Aug" ></asp:ListItem>
                                   <asp:ListItem Text="Sep" Value="Sep" ></asp:ListItem>
                                   <asp:ListItem Text="Oct" Value="Oct" ></asp:ListItem>
                                   <asp:ListItem Text="Nov" Value="Nov" ></asp:ListItem>
                                   <asp:ListItem Text="Dec" Value="Dec" ></asp:ListItem>
                                   </asp:DropDownList>

                                <asp:DropDownList ID="ddl_Year" runat="server" CssClass="txtbox_none" TabIndex="17" Font-Size="12px"  Width="75px"  >
                                   <asp:ListItem Text="" Value="0" ></asp:ListItem>
                                   <asp:ListItem Text="2014" Value="May" ></asp:ListItem>
                                   <asp:ListItem Text="2015" Value="June" ></asp:ListItem>
                                   <asp:ListItem Text="2016" Value="July" ></asp:ListItem>
                                   <asp:ListItem Text="2017" Value="Aug" ></asp:ListItem>
                                   <asp:ListItem Text="2018" Value="Sep" ></asp:ListItem>
                                   <asp:ListItem Text="2019" Value="Oct" ></asp:ListItem>
                                   <asp:ListItem Text="2020" Value="Nov" ></asp:ListItem>
                               </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    CHA Ref. No
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_CHA_Ref_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="20"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Doc. Receipt Dt
                                </div>
                                <div id="txtcon-m_Exchange">

                            <asp:TextBox ID="txt_Doc_Receipt_date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="21"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Doc_Receipt_date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Doc_Receipt_date"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 2-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Imp. Ref.  No
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Imp_Ref_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="22"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Filing Scheme
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Filling_Scheme" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="23"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Br. Slno
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Br_Slno" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="24"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    BE Type
                                </div>
                                <div id="txtcon-m_Exchange">
                                       <asp:DropDownList ID="ddl_BE_Type" runat="server" CssClass="txtbox_none" TabIndex="25" Font-Size="12px"  Width="95px"  >
                                       <asp:ListItem Text="Home" Value="H" ></asp:ListItem>
                                       <asp:ListItem Text="Ware House" Value="WH" ></asp:ListItem>
                                       <asp:ListItem Text="Ex-Bond" Value="EB" ></asp:ListItem>
                                       </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 3-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    MBL No
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_MBL_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="27"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   MBL Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_MBL_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="28"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_MBL_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_MBL_Date"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    HBL No
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_HBL_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="30"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    HBL Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_HBL_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="31"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_HBL_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_HBL_Date"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 4-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Packages
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Pkg" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="32"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Gross Wgt
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Gross_Wgt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="33"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Net Wgt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Net_Wgt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="35"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Container No
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Container_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="36"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 5-----------------------------------------%> 
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    20 F
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_20_F" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="37"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   40 F
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_40_F" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="39"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    CBM / CHG Wgt
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txt_CBM_CHG_Wgt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="40"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Mode Type
                                </div>
                                <div id="txtcon-m_Exchange">
                                     <asp:DropDownList ID="ddl_Mode_Type" runat="server" CssClass="txtbox_none" TabIndex="41" Font-Size="12px"  Width="95px"  >
                                       <asp:ListItem Text="" Value="" ></asp:ListItem>
                                       <asp:ListItem Text="LCL" Value="LCL" ></asp:ListItem>
                                       <asp:ListItem Text="FCL" Value="FCL" ></asp:ListItem>
                                       </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 6-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Inco-Terms
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:DropDownList ID="ddl_Inco_Terms" runat="server" CssClass="txtbox_none" Font-Size="12px" TabIndex="45"  Width="95px"  >
                                       <asp:ListItem Text="FOB" Value="FOB" ></asp:ListItem>
                                       <asp:ListItem Text="CIF" Value="CIF" ></asp:ListItem>
                                       <asp:ListItem Text="CI" Value="CI" ></asp:ListItem>
                                       <asp:ListItem Text="CF" Value="CF" ></asp:ListItem>
                                       </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Supp. Name
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txt_Supplier_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="46"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Supp. Inv No
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Supplier_Inv_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="47"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Supp. Inv Dt
                                </div>
                                <div id="txtcon-m_Exchange">

                                  <asp:TextBox ID="txt_Supplier_Inv_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="48"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_Supplier_Inv_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_Supplier_Inv_Date"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>

                            
                                </div>
                            </div>
                        </div> 
                        <%--------------------------------------Row 7-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Supp. Inv. Value
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Supplier_Inv_Value" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="49"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Currency
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Currency" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="50"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Bond No
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Bond_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="52"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Bond Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Bond_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="53"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt_Bond_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_Bond_Date"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 8-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    WH details
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txt_WH_Details" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="55"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    License Type
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_License_Type" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="56"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Frt For. Name
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Freight_For_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="57"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Freight Inv.Rec.Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Freight_Inv_Rec_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="60"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_Freight_Inv_Rec_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_Freight_Inv_Rec_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 9-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Frt Rec.Dt(Li)
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Freight_Rec_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="61"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender7" runat="server" TargetControlID="txt_Freight_Rec_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txt_Freight_Rec_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   CFS Location
                                </div>
                                <div id="txtcon-m_Exchange">

                                       <asp:DropDownList ID="ddl_CFS_Location" runat="server"  TabIndex="62" CssClass="txtbox_none" Font-Size="12px"  Width="95px"  >
                                       <asp:ListItem Text="" Value="" ></asp:ListItem>
                                       <asp:ListItem Text="TRIWAY" Value="TRIWAY" ></asp:ListItem>
                                       <asp:ListItem Text="ALLCARGO" Value="ALLCARGO" ></asp:ListItem>
                                       <asp:ListItem Text="MAERSK" Value="MAERSK" ></asp:ListItem>
                                       <asp:ListItem Text="SANCO" Value="SANCO" ></asp:ListItem>

                                       <asp:ListItem Text="SICAL" Value="SICAL" ></asp:ListItem>
                                       <asp:ListItem Text="ECCT" Value="ECCT" ></asp:ListItem>
                                       <asp:ListItem Text="CCTL" Value="CCTL" ></asp:ListItem>
                                       <asp:ListItem Text="CITPL" Value="CITPL" ></asp:ListItem>
                                       <asp:ListItem Text="KICT" Value="KICT" ></asp:ListItem>
                                       <asp:ListItem Text="KAILAS" Value="KAILAS" ></asp:ListItem>
                                       <asp:ListItem Text="OYARD" Value="OYARD" ></asp:ListItem>
                                       <asp:ListItem Text="CONTINENTAL" Value="CONTINENTAL" ></asp:ListItem>
                                       <asp:ListItem Text="ACME" Value="ACME" ></asp:ListItem>
                                       <asp:ListItem Text="THIRURANI" Value="THIRURANI" ></asp:ListItem>
                                       </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    De-Stuffing Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txt_De_Stuffing_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="63"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txt_De_Stuffing_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_De_Stuffing_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  M. Vessel Name
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Mother_Vessel_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="65"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 10-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                      M. Vessel Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Mother_Vessel_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="66"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txt_Mother_Vessel_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txt_Mother_Vessel_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    F. Vessel Name
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Feeder_Vessel_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="67"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    F. Vessel Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Feeder_Vessel_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="68"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender10" runat="server" TargetControlID="txt_Feeder_Vessel_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txt_Feeder_Vessel_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    BOE Type
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:DropDownList ID="ddl_BOE_Type" runat="server" CssClass="txtbox_none" TabIndex="70" Font-Size="12px"  Width="95px"  >
                                   <asp:ListItem Text=" " Value="0" ></asp:ListItem>
                                   <asp:ListItem Text="RMS" Value="RMS" ></asp:ListItem>
                                   <asp:ListItem Text="OPEN" Value="OPEN" ></asp:ListItem>
                                   </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 11-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    ETA Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txt_ETA_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="71"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender11" runat="server" TargetControlID="txt_ETA_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender11" runat="server" TargetControlID="txt_ETA_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    ETD Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txt_ETD_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="72"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender12" runat="server" TargetControlID="txt_ETD_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender12" runat="server" TargetControlID="txt_ETD_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Ass. Value
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Ass_value" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="73"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Customs Duty
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Customs_Duty" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="75"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 12-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    BOE No
                                 </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_BOE_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="76"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   BOE Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_BOE_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="77"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txt_BOE_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txt_BOE_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    TR6 No
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_TR6_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="78"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    TR6 Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                     <asp:TextBox ID="txt_TR6_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="79"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txt_TR6_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txt_TR6_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 13-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Duty Req. Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Duty_Req_date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="80"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender15" runat="server" TargetControlID="txt_Duty_Req_date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txt_Duty_Req_date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    EDD Paid on
                                </div>
                                <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_EDD_Paid_On" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="82"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender16" runat="server" TargetControlID="txt_EDD_Paid_On"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender16" runat="server" TargetControlID="txt_EDD_Paid_On"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Duty Penalty
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Duty_Penalty" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="85"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Duty Interst
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Duty_Interst" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="87"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 14-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Examination Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Examination_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="88"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender17" runat="server" TargetControlID="txt_Examination_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender17" runat="server" TargetControlID="txt_Examination_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    OOC
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_OOC" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="90"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Ship.Ready Deli.
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Shipment_Ready_Delivery" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="92"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Ship.Cleared Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Shipment_Cleared_date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="94"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender18" runat="server" TargetControlID="txt_Shipment_Cleared_date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender18" runat="server" TargetControlID="txt_Shipment_Cleared_date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 15-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Ship.Rec. Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Shipment_Recd_date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="96"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender19" runat="server" TargetControlID="txt_Shipment_Recd_date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender19" runat="server" TargetControlID="txt_Shipment_Recd_date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Halting Days
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Halting_Days" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="97"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    BOEDespatch Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_BOE_Despatch_date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="100"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender20" runat="server" TargetControlID="txt_BOE_Despatch_date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender20" runat="server" TargetControlID="txt_BOE_Despatch_date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    BOE H.over Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_BOE_H_Over_date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="101"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender21" runat="server" TargetControlID="txt_BOE_H_Over_date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender21" runat="server" TargetControlID="txt_BOE_H_Over_date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 16-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    From CFS
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:DropDownList ID="ddl_From_CFS" runat="server" CssClass="txtbox_none" Font-Size="12px" TabIndex="102" Width="95px"  >
                               <asp:ListItem Text="" Value="" ></asp:ListItem>
                               <asp:ListItem Text="CFS" Value="CFS" ></asp:ListItem>
                               <asp:ListItem Text="PNR" Value="PNR" ></asp:ListItem>
                               <asp:ListItem Text="BE-Block" Value="BEB" ></asp:ListItem>
                               <asp:ListItem Text="PORT" Value="PORT" ></asp:ListItem>
                               </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    No Of Container
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_No_of_Container" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="105"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Daily Status(Re.)
                                </div>
                                <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_Daily_Status" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="106"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Detailed Status
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Detailed_Status" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="107"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 17-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1" >
                                   H.Over To Tr Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_H_Over_To_Tr_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="108"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender22" runat="server" TargetControlID="txt_H_Over_To_Tr_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender22" runat="server" TargetControlID="txt_H_Over_To_Tr_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    PD Bond No
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_PD_Bond_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="110"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    PD Bond Debit Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_PD_Bond_Debit_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="111"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender23" runat="server" TargetControlID="txt_PD_Bond_Debit_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender23" runat="server" TargetControlID="txt_PD_Bond_Debit_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    PD Bond Amt
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_PD_Bond_Amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="112"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <%--------------------------------------Row 18-----------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Original Doc. Rec
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Original_Doc_Rec" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="113"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                     Original Doc. Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Original_Doc_date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="115"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender24" runat="server" TargetControlID="txt_Original_Doc_date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender24" runat="server" TargetControlID="txt_Original_Doc_date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            
                        </div>
                          
                           <%--------------------------------------Row 20-----------------------------------------%>
                        <%--------------------------------------Row End-----------------------------------------%>
                    </div>
                 
                </div>
                        </div>
                    </div>

                    <div  class="content"  id="page-7"  style="display:none;height:440px;" >

                     <%--  <div id="tag_transact_src_inner" style="width: 1150px; height:150px;">
                       </div>--%>

                              <div id="pop_text_area_transac_popup_inn_container_export" style="height:500px;margin-top: -16px; margin-left:-18px; color:Red;">
                        <div id="tag_transact_src_inner" style="width: 1092px;height:500px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1092px;height:500px;">
                    <%--------------------------------------Row 1-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    CHA Inv. No
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_CHA_Inv_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="118"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Service Bill Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Service_Bill_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="119"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender25" runat="server" TargetControlID="txt_Service_Bill_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender25" runat="server" TargetControlID="txt_Service_Bill_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Liner Charges
                                </div>
                                <div id="txtcon-m_Exchange">
                                 <asp:TextBox ID="txt_Liner_Charge" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="120"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Demurr. Charges
                                </div>
                                <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_Memurrage_Charge" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="121"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 2-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Conta. Detention
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Container_Detention" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="122"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   CFS Charges
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_CFS_Charges" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="125"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   AAI Charges
                                </div>
                                <div id="txtcon-m_Exchange">
                               <asp:TextBox ID="txt_AAI_Charges" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="126"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    AAIDemurr Charg
                                </div>
                                <div id="txtcon-m_Exchange">
                           <asp:TextBox ID="txt_AAI_Demurrage_Charge" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="127"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 3-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    CHA Ser. Chrg
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_CHA_Service_Charge" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="130"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Misc
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_MISC" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="131"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Transport Chrg
                                </div>
                                <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_Transport_Charge" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="132"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   FSC
                                </div>
                                <div id="txtcon-m_Exchange">
                             <asp:TextBox ID="txt_FSC" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="135"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 4-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Halting Chrg
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Halting_Charge" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="137"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Service Tax Rs.
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Service_Tax" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="138"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Tot Clear. Chrg
                                </div>
                                <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_Total_Clearance_Charge" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="140"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Bills H.O Dt
                                </div>
                                <div id="txtcon-m_Exchange">

                                   <asp:TextBox ID="txt_Bills_Handover_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="143"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender26" runat="server" TargetControlID="txt_Bills_Handover_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender26" runat="server" TargetControlID="txt_Bills_Handover_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 5-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                         
                     </div>
                    <%--------------------------------------Row 6-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   LHA Name
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_LHA_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="144"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Branch Name
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Branch_name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="145"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Place
                                </div>
                                <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_Place" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="146"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Origin
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Origin" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="148"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 7-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  HS Code
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_HS_Code" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="149"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Description
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Description" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="150"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   CBM
                                </div>
                                <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_CBM" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="151"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Dimension
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_Dimension" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="153"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 8-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Port of Loading
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Port_of_Loading" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="155"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Port of Discharge
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Port_of_Discharge" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="157"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  ATD Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_ATD_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="158"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender27" runat="server" TargetControlID="txt_ATD_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender27" runat="server" TargetControlID="txt_ATD_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    ATA Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                   <asp:TextBox ID="txt_ATA_Date" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="160"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender28" runat="server" TargetControlID="txt_ATA_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender28" runat="server" TargetControlID="txt_ATA_Date"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 9-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Transit Time
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Transit_Time" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="162"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Port Name
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Port_Name" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="163"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Copy Doc. Rec.
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Copy_Doc_Recivied_Dt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="164"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender32" runat="server" TargetControlID="txt_Copy_Doc_Recivied_Dt"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender32" runat="server" TargetControlID="txt_Copy_Doc_Recivied_Dt"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Checklist Confim
                                </div>
                                <div id="txtcon-m_Exchange">

                                   <asp:TextBox ID="txt_Checklist_Confim" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="170"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender29" runat="server" TargetControlID="txt_Checklist_Confim"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender29" runat="server" TargetControlID="txt_Checklist_Confim"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 10-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  BE Assesed Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                     <asp:TextBox ID="txt_BE_Assesed_Dt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="171"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender30" runat="server" TargetControlID="txt_BE_Assesed_Dt"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender30" runat="server" TargetControlID="txt_BE_Assesed_Dt" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Duty Informed Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Duty_Informed_Dt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="172"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender33" runat="server" TargetControlID="txt_Duty_Informed_Dt"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender33" runat="server" TargetControlID="txt_Duty_Informed_Dt"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Duty Received Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                         <asp:TextBox ID="txt_Duty_Received" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="173"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender34" runat="server" TargetControlID="txt_Duty_Received"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender34" runat="server" TargetControlID="txt_Duty_Received"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Duty Paid Dt
                                </div>
                                <div id="txtcon-m_Exchange">

                                   <asp:TextBox ID="txt_Duty_Paid_Dt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="175"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender31" runat="server" TargetControlID="txt_Duty_Paid_Dt"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender31" runat="server" TargetControlID="txt_Duty_Paid_Dt"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>
                     <%--------------------------------------Row 11-----------------------------------------%>
                     <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Act. Proc. Time
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Actual_Proc_Time" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="176"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    RE Bond No
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_RE_Bond_No" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="177"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   RE Bond Amt
                                </div>
                                <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_RE_Bond_Amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="178"></asp:TextBox>
                                </div>
                            </div>
                            <%--<div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Duty Paid
                                </div>
                                <div id="txtcon-m_Exchange">

                                   <asp:TextBox ID="txt_Duty_Paid" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="3"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender31" runat="server" TargetControlID="txt_Duty_Paid"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender31" runat="server" TargetControlID="txt_Duty_Paid"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>--%>
                        </div>
                      <%--------------------------------------Row 12-----------------------------------------%>
                      <%--<div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  BE Assesed Dt
                                </div>
                                <div id="txtcon-m_Exchange">
                                     <asp:TextBox ID="txt_BE_Assesed_Dt" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="3"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender30" runat="server" TargetControlID="txt_BE_Assesed_Dt"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender30" runat="server" TargetControlID="txt_BE_Assesed_Dt" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Duty Informed
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:TextBox ID="txt_Duty_Informed" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="25"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Duty Received
                                </div>
                                <div id="txtcon-m_Exchange">
                                <asp:TextBox ID="txt_Duty_Received" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                        ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="25"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Duty Paid
                                </div>
                                <div id="txtcon-m_Exchange">

                                   <asp:TextBox ID="txt_Duty_Paid" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                        MaxLength="10" TabIndex="3"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender31" runat="server" TargetControlID="txt_Duty_Paid"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender31" runat="server" TargetControlID="txt_Duty_Paid"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </div>
                            </div>
                        </div>--%>
                       <%--------------------------------------Row 13-----------------------------------------%>

                     </div>
                      </div>
                       </div>

                       <%-------------------------------------------------------------------------------%>
                    </div>
                  <%-------------------------------------------------------------------------------%>
                </div>
                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="185" onclick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="180" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="181" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="181" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Invoice?', 'INVOICE', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="183" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="183">
                        </div>
                       <div id="editbu" style="width:10px;"></div>
                        <div id="editbu" style="padding-top:5px;">
                            <asp:Button ID="btnrpt" runat="server" tabindex="186" Text="Get Bill" OnClientClick="return GST_Import_Billing_Job_Rpt('B');"  /> <%--OnClientClick="return Import_Billing_Job_Rpt('B');"--%> 
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
    
</body>
</html>
