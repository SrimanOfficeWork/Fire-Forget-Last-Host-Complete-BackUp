<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cus_DSR_Imp_Job.aspx.cs" Inherits="Cus_DSR_Imp_Job" %>
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

<script src="../js/CUS_DSR.js" type="text/javascript"></script>
     <style type="text/css">
        .modalPopup12
        {
            background-color: transparent;
            width: 940px;
            height: 180px;
        }
        
     .td-input {
    border-right: none !important;
    border-radius: 4px 0 0 4px !important;
}

.date-field-active {
    border: 1.5px solid #2196F3 !important;
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
        #txt_container_Transact_Main_2
        {
            float: left;
            width: 273px;
            height: 25px;
            margin-top: 5px;
        }
        #tag_label_transact_Src_1
        {
            float: left;
            width: 137px;
            height: 15px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 13px;
            line-height: 20px;
            text-align: left;
            color: #232323;
        }
        #tag_label_transact_Src_2
        {
            float: left;
            width: 137px;
            height: 15px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 11px;
            line-height: 20px;
            text-align: left;
            color: #232323;
        }
        #tag_transact_lft_in_2
        {
            width: 1092px;
            height: 25px;
            float: left;
        }
        #txtcon-m_Exchange_2
        {
            width: 115px;
            height: 15px;
            float: left;
        }
        .txtbox_none_Mid_transac_CUS
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            height: 15px;
            margin-top: 1px;
            width: 150px;
            text-transform: none;
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
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"  LoadScriptsBeforeUI="false" EnablePageMethods="true">
  </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="tag_transact_src_inner" style="width: 1086px; height: 30px;"
                <%--<div id="innerbox_MidMain" style="height: 30px;">--%>
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 108px;">
                        Imp. DSR Entry
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 400px;">
                        <div id="tag_label_transact_Src" style="width: 70px;">
                            Cus.Name</div>
                        <div id="txtcon-m_Exchange">
                            <asp:DropDownList ID="ddlCus_name"  class=" validate[required] chosen-select-deselect"
                            Style="width: 330px;" data-placeholder="Choose a Customer Name"
                                Width="330px" runat="server" AutoPostBack="True" TabIndex="8" OnSelectedIndexChanged="ddlCus_name_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 190px;">
                        <div id="tag_label_transact_Src" style="width: 50px;">
                            Job No
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 115px;">
                            <asp:DropDownList ID="ddljobno" class="chosen-select-deselect" Style="width: 130px;" data-placeholder="0"  Width="130px" runat="server" TabIndex="10">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 190px;">
                        <div id="tag_label_transact_Src" style="width: 100px;">
                            Manual Job No
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 85px;">
                            <asp:TextBox ID="txt_Manual_Jobno" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="80px"
                                ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="11"></asp:TextBox>
                        </div>
                    </div>
                     <div id="tag_label_transact_Src" style="width: 100px; margin-top:5px;">
                                     <asp:Button ID="btnloadData" TabIndex="12" runat="server" Text="Load Data" OnClick="btnloadData_Click" />
                                     <asp:Button ID="btnRefreshData" TabIndex="12" runat="server"  Visible="false" Text="Refresh CHA Data" onclick="btnRefreshData_Click" />
                                         
                     </div>
                    <div id="popupwindow_closebut_right_new">
                          <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>


         <div class="content" id="page-1" style="margin-top:-28px;height:550px;">
                        
          <div id="innerbox_MidMain_Trans_new" style="height:500px; width:1094px; margin-left:-16px; margin-top:-5px;">
                <ol id="toc_new">
                      <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span> Page 1 </span></a></li>
                        <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span> Page 2</span></a></li>

                         <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server" >
                        <span  > Job & Shipment Details </span></a></li>

                         <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server">
                        <span >  Documentation Dept</span></a></li>

                        <li><a href="#page-10" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page5('0');" id="Page_E" runat="server">
                        <span  > D/O Team </span></a></li>

                          <li><a href="#page-11" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page6('0');" id="Page_F" runat="server">
                        <span  >  Operation Dept.</span></a></li>

                          <li><a href="#page-12" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page7('0');" id="Page_G" runat="server">
                        <span  >  Accounts Dept. </span></a></li>

                          <li><a href="#page-13" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page8('0');" id="Page_H" runat="server">
                        <span  > Management Control </span></a></li>





                </ol>
                
                    <div   class="content" id="page-6" style="height:500px;" >

                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:500px;margin-top: -16px; margin-left:-18px; color:Red;">
                        <div id="tag_transact_src_inner" style="width: 1092px;height:500px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1092px;height:500px;">
                         <%------------------------------------Row--1-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 File. Ref no  
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_File_Ref_no" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="15"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Job Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Job_date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="16"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                Tr. Mode
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Tr_Mode" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="17"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 BE Type
                                 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_BE_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="18"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%------------------------------------Row--2-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Customs House
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Cus_House" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="19"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Branch No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Branch_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="20"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    IEC No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   <asp:TextBox ID="txt_IEC_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="21"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   AD Code 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_AD_Code" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="22"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                        <%------------------------------------Row--3-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Country Origin 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Country_Of_Orgin" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="23"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                Country of Shipment
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Country_of_Shipment" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="24"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Port of Origin 
                                  
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Port_of_Orgin" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="25"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Port of Shipment
                                 
                                </div>
                                <div id="txtcon-m_Exchange_2"> 
                                    <asp:TextBox ID="txt_port_of_Shipment" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="26"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <%------------------------------------Row--4-------------------------------------------%>
                            <div id="tag_transact_lft_in_2">
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                     State Code
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                        <asp:TextBox ID="txt_State_Code" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="27"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                        Registration No
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                        <asp:TextBox ID="txt_Reg_no" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="28"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                        High Sea Seller Name
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                         <asp:TextBox ID="txt_High_Sea_Seller_name" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="29"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                       Part Ref. No
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                           <asp:TextBox ID="txt_Party_Ref_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="30"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                       <%------------------------------------Row--5-------------------------------------------%>
                            <div id="tag_transact_lft_in_2">
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                     Warehouse Name
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                        <asp:TextBox ID="txt_Warehouse_name" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="31"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                         Warehouse Code
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                        <asp:TextBox ID="txt_Warehouse_code" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="32"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                        Green Channel
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                         <asp:TextBox ID="txt_Green_Channel" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="33"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                      Section 48
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                           <asp:TextBox ID="txt_Section_48" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="34"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                       <%------------------------------------Row--6-------------------------------------------%>
                            <div id="tag_transact_lft_in_2">
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                    Filing Status
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                        <asp:TextBox ID="txt_Filling_Status" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="35"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                         First Check 
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                        <asp:TextBox ID="txt_First_Check" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="36"></asp:TextBox>
                                        
                                    </div>
                                </div>
                                <%--<div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                        Green Channel
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                         <asp:TextBox ID="txt_Green_Channel" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="31"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_2">
                                    <div id="tag_label_transact_Src_1">
                                      Section 48
                                    </div>
                                    <div id="txtcon-m_Exchange_2">
                                           <asp:TextBox ID="txt_Section_48" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                            Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="31"></asp:TextBox>
                                    </div>
                                </div>--%>
                            </div>
                          <%------------------------------------Row--17-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   IGM
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--4-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Airline Name
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Airline_Name" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="37"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                       Airline Code
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Airline_Code" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="38"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  IGM No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                      <asp:TextBox ID="txt_IGM_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="39"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   IGM Date 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                       <asp:TextBox ID="txt_IGM_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="40"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--5-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  IGM Packages
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                     <asp:TextBox ID="txt_IGM_Pkg" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="55px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="41"></asp:TextBox>
                                        
                                        <asp:TextBox ID="txt_IGM_Pkg_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="45px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="42"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    IGM Gross Wgt
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                     <asp:TextBox ID="txt_IGM_Gross_Wgt" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="55px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="43"></asp:TextBox>
                                        
                                     <asp:TextBox ID="txt_IGM_Gross_Wgt_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="45px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="44"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                     MAWB/ MBL No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_MAWB_MBL_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="45"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 MAWB/ MBL Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_MAWB_MBL_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="46"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--6-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">

                               HAWB/ HBL No 
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_HAWB_HBL_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="47"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">

                                 HAWB/ HBL Date
                                  
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_HAWB_HBL_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="48"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                
                                 Flight No/ Vessel No 
                                    
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Flight_Vessel_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="49"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                Flight/ Inward Date 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Flight_Inward_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="50"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--7-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                Line Number
                                </div>
                                <div id="txtcon-m_Exchange_2"> 
                                    <asp:TextBox ID="txt_Line_Number" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"    CssClass="txtbox_none_Mid_transac_CUS" TabIndex="51"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Shipping Line 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Shipping_Line_No" runat="server" MaxLength="145" onkeyup="autotab(this);"  
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="52"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                               Voyage
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Voyage" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="53"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Gateway-IGM No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Gateway_IGM_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="54"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--8-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Gateway-IGM Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Gateway_IGM_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="55"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Gateway-Port Code
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Gateway_Port_Code" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="56"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Container No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Container_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="57"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                 Truck No 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Truck_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="58"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                        <%------------------------------------Row--9-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                     Seal No 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Seal_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="60"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Seal Type
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Seal_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="61"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  LCL/FCL 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_LCL_FCL" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="62"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Bond No 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Bond_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="63"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--10-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Bond Location 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Bond_Location" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="64"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Bond Type
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Bond_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="65"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Certificate No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Certificate_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="66"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Certificate Date 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Certificate_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="67"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--11-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Certificate Type 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Certificate_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="68"></asp:TextBox>
                                        
                                </div>
                            </div>
                          <%--  <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Bond Location
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Bond_Location" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="61"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Certificate No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Certificate_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="62"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Certificate Date 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Certificate_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="63"></asp:TextBox>
                                        
                                </div>
                            </div>--%>
                        </div>
                          <%------------------------------------Row--17-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    Invoice
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                  
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--10-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Invoice No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Inv_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="69"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Invoice Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Inv_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="70"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Terms
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Terms" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="71"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Currency
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Inv_Currency" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="72"></asp:TextBox>
                                       
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--11-------------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Invoice Value
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Inv_Value" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="73"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Ex. Rate 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Ex_Rate" runat="server" MaxLength="145" onkeyup="autotab(this);"  
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="74"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Supplier Name
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Supplier_Name" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="75"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Nature of Trans
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Nature_of_Trans" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="76"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                         <%------------------------------------Row--12-------------------------------------------%>
                        <%--------------------------------------Row End-----------------------------------------%>
                    </div>
                </div>
                        </div>
                    </div>

                    <div  class="content"  id="page-7"  style="display:none;height:440px;" >

                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:500px;margin-top: -16px; margin-left:-18px; color:Red;">
                        <div id="tag_transact_src_inner" style="width: 1092px;height:500px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1092px;height:500px;">

                    <%--------------------------------------Row 1-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Other Purchase Order
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Other_Purchase_Order" runat="server" MaxLength="145"  onkeyup="autotab(this);" 
                                        Width="115px"   
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="77"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Other Pur. Order Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Other_Purchase_Date" runat="server" MaxLength="145"  onkeyup="autotab(this);"  
                                        Width="115px"  
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="78"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Other Contract No.
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_other_Contract_No" runat="server" MaxLength="145"  onkeyup="autotab(this);" 
                                        Width="115px"   
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="79"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Other Contract Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_other_Contract_date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="80"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 2-----------------------------------------%>

                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Other Loc. No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Other_Loc_No" runat="server" MaxLength="145"  onkeyup="autotab(this);"
                                        Width="115px"   onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="81"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Other Loc. Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Other_Loc_Date" runat="server" MaxLength="145"  onkeyup="autotab(this);"  
                                        Width="115px"   
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="82"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Terms of Payment
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Terms_of_Payment" runat="server" MaxLength="145"  onkeyup="autotab(this);"
                                        Width="115px"  
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="83"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Invoice + MISC
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Inv_MISC" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"   onkeypress="return Char_Inv(event)"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="84"></asp:TextBox>
                                </div>
                            </div>
                        </div>




                    <%--------------------------------------Row 1-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   Item
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 2-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Item Desc.
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Item_Desc" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="100"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Item Qty 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Item_Qty" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="55px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="101"></asp:TextBox>
                                        
                                     <asp:TextBox ID="txt_Item_Qty_Code" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="45px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="102"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Unit Price
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                   <asp:TextBox ID="txt_Unit_Price" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="55px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="103"></asp:TextBox>
                                        
                                     <asp:TextBox ID="txt_Unit_Price_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="45px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="110"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Item Amount
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Item_Amt" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="55px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="111"></asp:TextBox>
                                       
                                     <asp:TextBox ID="txt_Item_Amt_Type" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="45px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="112"></asp:TextBox>
                                       
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 3-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  RITC No 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Ritc_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="120"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Manufacture
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Manufacture" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="122"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                  Brand
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Brand" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="123"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   Model
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Model" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="125"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 4-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   End Use
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_End_Use_Item" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="126"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Scheme Code 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Scheme_Code" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="127"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Scheme NOTN
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Scheme_Notn" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"    CssClass="txtbox_none_Mid_transac_CUS" TabIndex="128"></asp:TextBox>
                                       
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Scheme NOTN SL 
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Scheme_Notn_Sl_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                        Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="129"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                     <%-------------------------------------Row 5-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Basic Duty/Notn
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Basic_Notn_NO" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                         Width="115px" CssClass="txtbox_none_Mid_transac_CUS"  TabIndex="131"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Basic Duty/Notn slno
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Basic_Notn_Slno" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="132"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Levy Notn no
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Levy_Notn_No" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="135"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Levy Notn slno
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Levy_Notn_Slno" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                         Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="136"></asp:TextBox>
                                        
                                </div>
                            </div>
                        </div>
                     <%-------------------------------------Row 6------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                Levy Notn Rate
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_Levy_Notn_Rate" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                                    Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="137"></asp:TextBox>
                                                    
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                Excemption Notn no
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_Excemption_Notn_no" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                                     Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="138"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                Excemption Notn.slno
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_Excemption_Notn_Slno" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                                 Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="140"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                Excemption Notn Rate
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_Excemption_Notn_Rate" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                                     Width="115px" CssClass="txtbox_none_Mid_transac_CUS"  TabIndex="141"></asp:TextBox>
                                                   
                                            </div>
                                        </div>
                                    </div>

                    <%-------------------------------------Row 7-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Total Ass. Value
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_total_Ass_Value" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="142"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Total Duty Value
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_total_Duty_Value" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="143"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                   License Type
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_License_Type" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="144"></asp:TextBox>
                                </div>
                            </div>
                           <%-- <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Re-Imp Export Freight
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Re_Imp_Export_Freight" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                        Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="111"></asp:TextBox>
                                </div>
                            </div>--%>
                        </div>


                     <%-------------------------------------Row 7-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    Re - Import
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                        </div>
                     <%-------------------------------------Row 8-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Re-Imp SB.No
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Re_Imp_SB_No" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                    Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="146"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Re-Imp SB Date
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Re_Imp_SB_Date" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                    Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="147"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Re-Imp Inv.Slno
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Re_Imp_Inv_Slno" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                    Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="148"></asp:TextBox>
                                        
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                    Re-Imp Item.Slno
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_Re_Imp_Item_Slno" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                         Width="115px"  CssClass="txtbox_none_Mid_transac_CUS"  TabIndex="149"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                     <%-------------------------------------Row 9-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                               Re-Imp Port Export
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_Re_Imp_Port_Of_Export" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                                    Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="150"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                Re-Imp Nontn No 
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_Re_Imp_Notfication_No" runat="server" MaxLength="145" onkeyup="autotab(this);"
                                                    Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="151"></asp:TextBox>   
                                                    
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                Re-Imp Nontn.slno 
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_Re_Imp_Notfication_Slno" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                                    Width="115px"  CssClass="txtbox_none_Mid_transac_CUS" TabIndex="152"></asp:TextBox>
                                                    
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                               Re-Imp Export Freight 
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_Re_Imp_Export_Freight" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                                    Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="153"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                      <%------------------------------------Ex-Bond-------------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    Ex-Bond
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                        </div>
                     <%------------------------------------EX-Bond_1-------------------------------------------%>
                       <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                            Bond No
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_Ex_Bond_No" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                                    Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="154"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                Bond Date 
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                               <asp:TextBox ID="txt_Ex_Bond_Date" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                                    Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="155"></asp:TextBox>
                                            </div>
                                        </div>
                                        
                                    </div>
                    
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    Supporting Doc.
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                        </div>
                      <%-------------------------------------Row 10-------------------------------------------%>
                      <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                              Unique Doc. No.
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_unique_Doc_no" runat="server" MaxLength="145" onkeyup="autotab(this);" 
                                                 Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="158"></asp:TextBox>    
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                               Doc. Type Code
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_unique_Doc_Type_Code" runat="server" MaxLength="145" onkeyup="autotab(this);"  
                                                 Width="115px" CssClass="txtbox_none_Mid_transac_CUS" TabIndex="159"></asp:TextBox>   
                                            </div>
                                        </div>
                                        
                                    </div>
                     <%-------------------------------------Row 11-------------------------------------------%>
                     <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    BE Entry
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_1">
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                </div>
                            </div>
                        </div>
                        
                                 
                                 <%------------------------------------Row--7-------------------------------------------%>
                                 <div id="tag_transact_lft_in_2">
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                              BE No
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_BE_No" runat="server" MaxLength="145" onkeyup="autotab(this);"  
                                                    Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="160"></asp:TextBox>
                                                   
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                               BE Date
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                                <asp:TextBox ID="txt_BE_Date" runat="server" MaxLength="145" onkeyup="autotab(this);"  
                                                    Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="161"></asp:TextBox>
                                                    
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                BE Ass. Value
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                               <asp:TextBox ID="txt_BE_Ass_Value" runat="server" MaxLength="145" onkeyup="autotab(this);"  
                                                    Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="162"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div id="txt_container_Transact_Main_2">
                                            <div id="tag_label_transact_Src_1">
                                                BE Duty Value
                                            </div>
                                            <div id="txtcon-m_Exchange_2">
                                               <asp:TextBox ID="txt_BE_Duty_Value" runat="server" MaxLength="145" onkeyup="autotab(this);"  
                                                    Width="115px"   CssClass="txtbox_none_Mid_transac_CUS" TabIndex="163"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                 <%------------------------------------Row--8-------------------------------------------%>
                                 <%------------------------------------Row--9-------------------------------------------%>
                                 <%------------------------------------Row--10-------------------------------------------%>
                                 <%------------------------------------Row--11-------------------------------------------%>
                                 <%------------------------------------Row--12-------------------------------------------%>
                                 <%------------------------------------Row--13-------------------------------------------%>
                                 <%------------------------------------Row--14-------------------------------------------%>
                                 <%------------------------------------Row--15-------------------------------------------%>
                                 <%------------------------------------Row--16-------------------------------------------%>
                                 <%------------------------------------Row--17-------------------------------------------%>
                                 <%------------------------------------Row--18-------------------------------------------%>
                    <%--------------------------------------Row 13-----------------------------------------%>

                     </div>
                      </div>
                       </div>

                       <%--------------------------------lable-----------------------------------------------%>
                    </div>
                    <div  class="content"  id="page-8"  style="display:none;height:440px;">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px;    margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1092px; height: 500px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1092px; height: 500px;">
                       

                       <%--------------------------------------Row 1-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_1" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_1" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="16"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_1" runat="server"  Width="120px" Height="20px"  Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                         TabIndex="16">
                                         </asp:DropDownList>


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2"> 
                                        <asp:Literal ID="txt_lbl_2" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_2" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="115"></asp:TextBox>

                                        <asp:DropDownList ID="ddl_txt_2" runat="server"  Width="120px" Height="20px"  Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                       TabIndex="115">
                                       </asp:DropDownList>


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_3" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2"> 
                                    <asp:TextBox ID="txt_txt_3" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="116"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_3" runat="server"  Width="120px" Height="20px"  Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                       TabIndex="116">
                                      </asp:DropDownList>


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_4" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_4" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="117"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_4" runat="server"  Width="120px" Height="20px"  Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                       TabIndex="117">
                                      </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 2-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_5" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_5" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="118"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_5" runat="server"  Width="120px" Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                       TabIndex="118">
                                      </asp:DropDownList>

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_6" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_6" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="119"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_6" runat="server"  Width="120px" Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                       TabIndex="119">
                                      </asp:DropDownList>

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_7" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_7" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="120"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_7" runat="server"  Width="120px" Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                       TabIndex="120">
                                      </asp:DropDownList>


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_8" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                     <asp:TextBox ID="txt_txt_8" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="121"></asp:TextBox>

                                       <asp:DropDownList ID="ddl_txt_8" runat="server"  Width="120px" Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                       TabIndex="121">
                                      </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 3-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                         
                                <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_9" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_9" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="122"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_9" runat="server"  Width="120px" Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                         TabIndex="122">
                                         </asp:DropDownList>


                                </div>
                            </div>



                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_10" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_10" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="125"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_10" runat="server"  Width="120px" Height="20px"  Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                         TabIndex="125">
                                         </asp:DropDownList>

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                  <asp:Literal ID="txt_lbl_11" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_11" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="126"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_11" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                         TabIndex="125">
                                         </asp:DropDownList>

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_12" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_12" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="127"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_12" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                         TabIndex="127">
                                         </asp:DropDownList>

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 4-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_13" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">

                                    <asp:TextBox ID="txt_txt_13" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="128"></asp:TextBox>


                                            <asp:DropDownList ID="ddl_txt_13" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                         TabIndex="128">
                                         </asp:DropDownList>


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_14" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_14" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="130"></asp:TextBox>

                                    <asp:DropDownList ID="ddl_txt_14" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="130">
                                   </asp:DropDownList>


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_15" runat="server"></asp:Literal>
                                </div>

                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_15" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="131"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_15" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="131">
                                   </asp:DropDownList>
                                </div>



                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_16" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_16" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="132"></asp:TextBox>

                                      <asp:DropDownList ID="ddl_txt_16" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="132">
                                   </asp:DropDownList>

                              </div>


                                </div>



                            </div>
                        </div>
                        <%--------------------------------------Row 5-----------------------------------------%> 
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_17" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_17" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="135"></asp:TextBox>

                                     
                                     <asp:DropDownList ID="ddl_txt_17" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="132">
                                   </asp:DropDownList>    

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_18" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_18" runat="server" MaxLength="500" onkeyup="autotab(this);"
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="136"></asp:TextBox>

                                 <asp:DropDownList ID="ddl_txt_18" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="136">
                                   </asp:DropDownList>    


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_19" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_19" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="137"></asp:TextBox>

                                        <asp:DropDownList ID="ddl_txt_19" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="137">
                                   </asp:DropDownList>    


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_20" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2"> 
                                    <asp:TextBox ID="txt_txt_20" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="140"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_20" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="140">
                                   </asp:DropDownList>    

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 6-----------------------------------------%>
                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_21" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_21" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="141"></asp:TextBox>

                                      <asp:DropDownList ID="ddl_txt_21" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="141">
                                   </asp:DropDownList>    



                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_22" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_22" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="143"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_22" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="143">
                                   </asp:DropDownList>    


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_23" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_23" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="144"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_23" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="144">
                                   </asp:DropDownList>    


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_24" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_24" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="145"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_24" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="145">
                                   </asp:DropDownList>    

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 7-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_25" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_25" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="146"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_25" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="146">
                                   </asp:DropDownList>    

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_26" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_26" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="150"></asp:TextBox>
                                </div>

                                        <asp:DropDownList ID="ddl_txt_26" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="150">
                                   </asp:DropDownList>    

                               
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                  <asp:Literal ID="txt_lbl_27" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_27" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="151"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_27" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="151">
                                   </asp:DropDownList>    


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_28" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_28" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="152"></asp:TextBox>


                                             <asp:DropDownList ID="ddl_txt_28" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="152">
                                   </asp:DropDownList>    


                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 8-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                  <asp:Literal ID="txt_lbl_29" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_29" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="155"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_29" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="155">
                                   </asp:DropDownList>    




                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_30" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_30" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="156"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_30" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="156">
                                   </asp:DropDownList>    

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_31" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_31" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="157"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_31" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="157">
                                   </asp:DropDownList>    

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_32" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_32" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="158"></asp:TextBox>


                                          <asp:DropDownList ID="ddl_txt_32" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="158">
                                   </asp:DropDownList>    

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 9-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_33" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_33" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="159"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_33" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="159">
                                   </asp:DropDownList>    

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_34" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_34" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="160"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_34" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="160">
                                   </asp:DropDownList>   
                                    
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_35" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_35" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="162"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_35" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="160">
                                   </asp:DropDownList>   

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_36" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_36" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="163"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_36" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="163">
                                   </asp:DropDownList>   


                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 10-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_37" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_37" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="164"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_37" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="164">
                                   </asp:DropDownList>   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_38" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_38" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="165"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_38" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="165">
                                   </asp:DropDownList>   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                  <asp:Literal ID="txt_lbl_39" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_39" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="166"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_39" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="166">
                                   </asp:DropDownList>   

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_40" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_40" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="167"></asp:TextBox>

                                       <asp:DropDownList ID="ddl_txt_40" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="167">
                                   </asp:DropDownList>   

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 11-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_41" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_41" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="168"></asp:TextBox>

                                      <asp:DropDownList ID="ddl_txt_41" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="168">
                                   </asp:DropDownList>   

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_42" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_42" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="169"></asp:TextBox>

                                             <asp:DropDownList ID="ddl_txt_42" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="169">
                                   </asp:DropDownList>   


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_43" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_43" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="170"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_43" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="170">
                                   </asp:DropDownList>   

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_44" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_44" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="172"></asp:TextBox>

                                        <asp:DropDownList ID="ddl_txt_44" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="172">
                                   </asp:DropDownList>   

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 12-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_45" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_45" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="173"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_45" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="173">
                                   </asp:DropDownList>   

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_46" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_46" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="174"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_46" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="174">
                                   </asp:DropDownList>   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_47" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_47" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="175"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_47" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="175">
                                   </asp:DropDownList>   
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_48" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_48" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="176"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_48" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="176">
                                   </asp:DropDownList>   

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 13-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_49" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_49" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="180"></asp:TextBox>

                                              <asp:DropDownList ID="ddl_txt_49" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="180">
                                   </asp:DropDownList>   

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_50" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_50" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="181"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_50" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="181">
                                   </asp:DropDownList> 
                                     
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_51" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_51" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="182"></asp:TextBox>

                                              <asp:DropDownList ID="ddl_txt_51" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="182">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_52" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_52" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="183"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_52" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="183">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 14-----------------------------------------%>
                        <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_53" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_53" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="185"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_53" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="185">
                                   </asp:DropDownList> 



                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_54" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_54" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="186"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_54" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="186">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                  <asp:Literal ID="txt_lbl_55" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_55" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="187"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_55" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="187">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                    <asp:Literal ID="txt_lbl_56" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_56" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="190"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_56" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="190">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                        </div>
                        <%--------------------------------------Row 15-----------------------------------------%>
                        <%--<div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_57" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_57" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="191"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_57" runat="server"  Width="115px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="191">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_58" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_58" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="192"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_58" runat="server"  Width="115px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="192">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_59" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_59" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="195"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_59" runat="server"  Width="115px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="195">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                       <asp:Literal ID="txt_lbl_60" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2"> 
                                    <asp:TextBox ID="txt_txt_60" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="196"></asp:TextBox>

                                        <asp:DropDownList ID="ddl_txt_60" runat="server"  Width="115px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="196">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                        </div>--%>
                        <%--------------------------------------Row 16-----------------------------------------%>
        
                        <%--------------------------------------Row 17-----------------------------------------%>
                   
                         <%--------------------------------------Row 18-----------------------------------------%>
                    

                        
                         <%------------------------------------Row--E-------------------------------------------%>
                      
                                </div>
                            </div>
                       </div>
          
                  <%-----------------------------------page9--------------------------------------------%>
                  <div  class="content"  id="page-9"  style="display:none;height:440px;">
                  
                      <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px;    margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1092px; height: 500px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1092px; height: 500px;">
                                <%--------------------------------------Row Start-----------------------------------------%>

                                  <%--------------------------------------1-----------------------------------------%>

                                  <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_57" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_57" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="191"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_57" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="191">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_58" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_58" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="192"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_58" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="192">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_59" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_59" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="195"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_59" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="195">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                       <asp:Literal ID="txt_lbl_60" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2"> 
                                    <asp:TextBox ID="txt_txt_60" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="196"></asp:TextBox>

                                        <asp:DropDownList ID="ddl_txt_60" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="196">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                        </div>

                               <%--------------------------------------2-----------------------------------------%>

                           <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_61" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_61" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="197"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_61" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="197">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                       <asp:Literal ID="txt_lbl_62" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_62" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="200"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_62" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="200">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_63" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_63" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="201"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_63" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="201">
                                   </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                         <asp:Literal ID="txt_lbl_64" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_64" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="202"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_64" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="202">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                        </div>


                                  <%--------------------------------------3-----------------------------------------%>


                                  <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                         <asp:Literal ID="txt_lbl_65" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_65" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="203"></asp:TextBox>

                                      <asp:DropDownList ID="ddl_txt_65" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="203">
                                   </asp:DropDownList> 



                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_66" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_66" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="204"></asp:TextBox>

                                             <asp:DropDownList ID="ddl_txt_66" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="204">
                                   </asp:DropDownList> 



                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                       <asp:Literal ID="txt_lbl_67" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_67" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="205"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_67" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="205">
                                   </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_68" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_68" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="206"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_68" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="206">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                        </div>


                                 <%--------------------------------------4-----------------------------------------%>


                                <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_69" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_69" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="210"></asp:TextBox>

                                   <asp:DropDownList ID="ddl_txt_69" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="210">
                                   </asp:DropDownList> 




                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_70" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_70" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="211"></asp:TextBox>

                                    <asp:DropDownList ID="ddl_txt_70" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="211">
                                   </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_71" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_71" runat="server" MaxLength="500" onkeyup="autotab(this);"
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="212"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_71" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="212">
                                   </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                         <asp:Literal ID="txt_lbl_72" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_72" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="213"></asp:TextBox>

                                        
                                      <asp:DropDownList ID="ddl_txt_72" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="213">
                                   </asp:DropDownList> 



                                </div>
                            </div>
                        </div>

                                <%--------------------------------------Row 5-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                       <asp:Literal ID="txt_lbl_73" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_73" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"    Visible="false" 
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="215"></asp:TextBox>

                               <asp:DropDownList ID="ddl_txt_73" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="215">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_74" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_74" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="216"></asp:TextBox>

                                        
                                   <asp:DropDownList ID="ddl_txt_74" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="216">
                                          </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_75" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_75" runat="server" MaxLength="500" onkeyup="autotab(this);"
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="220"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_75" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="220">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_76" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_76" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="221"></asp:TextBox>

                                                <asp:DropDownList ID="ddl_txt_76" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="221">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 6-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_77" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_77" runat="server" MaxLength="500" onkeyup="autotab(this);"
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="222"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_77" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="222">
                                          </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_78" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_78" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"    Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="223"></asp:TextBox>

                                             <asp:DropDownList ID="ddl_txt_78" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="223">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                          <asp:Literal ID="txt_lbl_79" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_79" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="225"></asp:TextBox>

                                             <asp:DropDownList ID="ddl_txt_79" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="225">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_80" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_80" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="226"></asp:TextBox>

                                               <asp:DropDownList ID="ddl_txt_80" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="226">
                                          </asp:DropDownList> 

                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 7-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_81" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_81" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="227"></asp:TextBox>

                                              <asp:DropDownList ID="ddl_txt_81" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="227">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_82" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_82" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="230"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_82" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="227">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                         <asp:Literal ID="txt_lbl_83" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_83" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="232"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_83" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="232">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                         <asp:Literal ID="txt_lbl_84" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_84" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="234"></asp:TextBox>

                                             <asp:DropDownList ID="ddl_txt_84" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="234">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 8-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                       <asp:Literal ID="txt_lbl_85" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_85" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="236"></asp:TextBox>


                                          <asp:DropDownList ID="ddl_txt_85" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="236">
                                          </asp:DropDownList> 



                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                       <asp:Literal ID="txt_lbl_86" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_86" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="238"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_86" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                    TabIndex="238">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                         <asp:Literal ID="txt_lbl_87" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_87" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="241"></asp:TextBox>

                                             <asp:DropDownList ID="ddl_txt_87" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                          TabIndex="241">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_88" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_88" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="243"></asp:TextBox>

                                      <asp:DropDownList ID="ddl_txt_88" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                          TabIndex="243">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 9-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_89" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_89" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="246"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_89" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                          TabIndex="246">
                                          </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                       <asp:Literal ID="txt_lbl_90" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_90" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="250"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_90" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                          TabIndex="250">
                                          </asp:DropDownList> 



                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                         <asp:Literal ID="txt_lbl_91" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_91" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="252"></asp:TextBox>

                                        <asp:DropDownList ID="ddl_txt_91" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                          TabIndex="252">
                                        </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_92" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_92" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="254"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_92" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                          TabIndex="254">
                                        </asp:DropDownList>   


                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 10-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_93" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_93" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="256"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_93" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                          TabIndex="256">
                                        </asp:DropDownList>   


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_94" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_94" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="260"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_94" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                          TabIndex="260">
                                        </asp:DropDownList>   

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                          <asp:Literal ID="txt_lbl_95" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_95" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="263"></asp:TextBox>

                                    <asp:DropDownList ID="ddl_txt_95" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="263">
                                    </asp:DropDownList>   

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_96" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_96" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="265"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_96" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="265">
                                    </asp:DropDownList>   

                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 11-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_97" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_97" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="267"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_97" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="267">
                                    </asp:DropDownList>   

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                          <asp:Literal ID="txt_lbl_98" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_98" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="269"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_98" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="269">
                                    </asp:DropDownList>  

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                         <asp:Literal ID="txt_lbl_99" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_99" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="273"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_99" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="273">
                                    </asp:DropDownList>  


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_100" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_100" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="276"></asp:TextBox>

                                       <asp:DropDownList ID="ddl_txt_100" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="276">
                                    </asp:DropDownList>  

                                </div>
                            </div>
                        </div>
                    <%--------------------------------------Row 12-----------------------------------------%>
                    <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                     <asp:Literal ID="txt_lbl_101" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_101" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="278"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_101" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="278">
                                    </asp:DropDownList>  

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                         <asp:Literal ID="txt_lbl_102" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_102" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="280"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_102" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="280">
                                    </asp:DropDownList>  

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                         <asp:Literal ID="txt_lbl_103" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_103" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="282"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_103" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="282">
                                    </asp:DropDownList>  

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                       <asp:Literal ID="txt_lbl_104" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_104" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="284"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_104" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="284">
                                    </asp:DropDownList>  



                                </div>
                            </div>
                        </div>
                  
                    
                     <%--------------------------------------Row End-----------------------------------------%>
                        </div>
                        </div>
                        </div>

                  </div>



                    <%-------------------------------------------------------------------------------%>

                       <%-----------------------------------page10--------------------------------------------%>
                  <div  class="content"  id="page-10"  style="display:none;height:440px;">
                      <div id="pop_text_area_transac_popup_inn_container_export" style="height: 500px;    margin-top: -16px; margin-left: -18px; color: Red;">
                            <div id="tag_transact_src_inner" style="width: 1092px; height: 500px;">
                                <div id="tag_Exchange_inner_lft" style="width: 1092px; height: 500px;">
                                <%--------------------------------------1-----------------------------------------%>

                                      <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_105" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_105" runat="server" MaxLength="500" onkeyup="autotab(this);"
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="287"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_105" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="287">
                                    </asp:DropDownList>  
 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_106" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_106" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="291"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_106" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="291">
                                    </asp:DropDownList>  

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_107" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_107" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="292"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_107" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="292">
                                    </asp:DropDownList>  


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_108" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_108" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="294"></asp:TextBox>

                                       <asp:DropDownList ID="ddl_txt_108" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="294">
                                    </asp:DropDownList>  

                                </div>
                            </div>
                        </div>


                            <%--------------------------------------2-----------------------------------------%>

                                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_109" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_109" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px" Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="296"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_109" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="296">
                                    </asp:DropDownList>  


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_110" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_110" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="298"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_110" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="298">
                                    </asp:DropDownList>  


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_111" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_111" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="300"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_111" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="300">
                                    </asp:DropDownList>  


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_112" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_112" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="302"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_112" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="302">
                                    </asp:DropDownList>  


                                </div>
                            </div>
                        </div>

                                           <%--------------------------------------3-----------------------------------------%>

                                     <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_113" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_113" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="305"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_113" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="305">
                                    </asp:DropDownList>  


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_114" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_114" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="306"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_114" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="306">
                                    </asp:DropDownList>  

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_115" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_115" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="307"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_115" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="307">
                                    </asp:DropDownList>  

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_116" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_116" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="116px" Visible="false"
                                      CssClass="txtbox_none_Mid_transac_CUS" TabIndex="308"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_116" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="308">
                                    </asp:DropDownList>  

                                </div>
                            </div>
                        </div>



                            <%--------------------------------------4-----------------------------------------%>

                               <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_117" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_117" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="309"></asp:TextBox>

                                    <asp:DropDownList ID="ddl_txt_117" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="309">
                                    </asp:DropDownList>  


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_118" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_118" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="310"></asp:TextBox>

                                   <asp:DropDownList ID="ddl_txt_118" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="310">
                                    </asp:DropDownList>  


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_119" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_119" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="311"></asp:TextBox>

                                              <asp:DropDownList ID="ddl_txt_119" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="311">
                                    </asp:DropDownList>  


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_120" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_120" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="116px"  Visible="false"
                                      CssClass="txtbox_none_Mid_transac_CUS" TabIndex="312"></asp:TextBox>

                                        <asp:DropDownList ID="ddl_txt_120" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="312">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                        </div>


                                         <%--------------------------------------5-----------------------------------------%>

                                         <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_121" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_121" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="315"></asp:TextBox>

                                              <asp:DropDownList ID="ddl_txt_121" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="315">
                                    </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_122" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_122" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="316"></asp:TextBox>

                                         <asp:DropDownList ID="ddl_txt_122" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="316">
                                    </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_123" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_123" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="318"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_123" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="318">
                                    </asp:DropDownList> 



                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_124" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_124" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="116px"  Visible="false"
                                      CssClass="txtbox_none_Mid_transac_CUS" TabIndex="319"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_124" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="319">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                        </div>




                                          <%--------------------------------------6-----------------------------------------%>

                                   <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_125" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_125" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="320"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_125" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="320">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_126" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_126" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="325"></asp:TextBox>

                                             <asp:DropDownList ID="ddl_txt_126" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="325">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_127" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_127" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="326"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_127" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="326">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_128" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_128" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="116px"  Visible="false"
                                      CssClass="txtbox_none_Mid_transac_CUS" TabIndex="327"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_128" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="327">
                                    </asp:DropDownList> 

                                </div>
                            </div>
                        </div> 

                                 <%--------------------------------------7-----------------------------------------%>

                                  <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_129" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_129" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="328"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_129" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="328">
                                    </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_130" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_130" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="329"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_130" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="329">
                                    </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_131" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_131" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="330"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_131" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="330">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_132" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_132" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="116px"  Visible="false"
                                      CssClass="txtbox_none_Mid_transac_CUS" TabIndex="331"></asp:TextBox>

                                              <asp:DropDownList ID="ddl_txt_132" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="331">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                        </div>

                                 <%--------------------------------------8-----------------------------------------%>
                                <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_133" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_133" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="333"></asp:TextBox>

                                                  <asp:DropDownList ID="ddl_txt_133" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="333">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_134" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_134" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="334"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_134" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="334">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_135" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_135" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="335"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_135" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="335">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_136" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_136" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="116px"  Visible="false"
                                      CssClass="txtbox_none_Mid_transac_CUS" TabIndex="338"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_136" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="338">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                        </div>




                                 <%--------------------------------------9-----------------------------------------%>

                                       <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_137" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_137" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="339"></asp:TextBox>


                                           <asp:DropDownList ID="ddl_txt_137" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="339">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_138" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_138" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="340"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_138" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="340">
                                    </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_139" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_139" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="341"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_139" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="341">
                                    </asp:DropDownList> 

                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_140" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">

                                    <asp:TextBox ID="txt_txt_140" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="116px"  Visible="false"
                                      CssClass="txtbox_none_Mid_transac_CUS" TabIndex="342"></asp:TextBox>

                                          <asp:DropDownList ID="ddl_txt_140" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="342">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                        </div>



                                      <%--------------------------------------10-----------------------------------------%>


                                       <div id="tag_transact_lft_in_2">
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                      <asp:Literal ID="txt_lbl_141" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_141" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="343"></asp:TextBox>
                                </div>

                                      <asp:DropDownList ID="ddl_txt_141" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="343">
                                    </asp:DropDownList> 


                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                   <asp:Literal ID="txt_lbl_142" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_142" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"   Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="345"></asp:TextBox>

                                           <asp:DropDownList ID="ddl_txt_142" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="345">
                                    </asp:DropDownList> 




                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_143" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_143" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="115px"  Visible="false"
                                        CssClass="txtbox_none_Mid_transac_CUS" TabIndex="346"></asp:TextBox>

                                            <asp:DropDownList ID="ddl_txt_143" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="346">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_2">
                                <div id="tag_label_transact_Src_2">
                                        <asp:Literal ID="txt_lbl_144" runat="server"></asp:Literal>
                                </div>
                                <div id="txtcon-m_Exchange_2">
                                    <asp:TextBox ID="txt_txt_144" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                        Width="116px"  Visible="false"
                                      CssClass="txtbox_none_Mid_transac_CUS" TabIndex="347"></asp:TextBox>

                                                <asp:DropDownList ID="ddl_txt_144" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                     TabIndex="347">
                                    </asp:DropDownList> 


                                </div>
                            </div>
                        </div>





                                     <%--------------------------------------Row 11-----------------------------------------%>
                                         <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_145" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_145" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="350"></asp:TextBox>


                                                  <asp:DropDownList ID="ddl_txt_145" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                  TabIndex="347">
                                                 </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_146" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_146" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="351"></asp:TextBox>


                                                   <asp:DropDownList ID="ddl_txt_146" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                  TabIndex="351">
                                                 </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_147" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_147" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="352"></asp:TextBox>
                                                    </div>

                                                         <asp:DropDownList ID="ddl_txt_147" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                  TabIndex="352">
                                                 </asp:DropDownList> 


                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_148" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_148" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"  Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="353"></asp:TextBox>

                                                              <asp:DropDownList ID="ddl_txt_148" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                  TabIndex="353">
                                                 </asp:DropDownList> 

                                                    </div>
                                                </div>
                                            </div>
                                        <%--------------------------------------Row 12-----------------------------------------%>
                                         <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_149" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_149" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="354"></asp:TextBox>

                                                             <asp:DropDownList ID="ddl_txt_149" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                  TabIndex="354">
                                                 </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_150" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_150" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="355"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_150" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                  TabIndex="355">
                                                 </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_151" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_151" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="360"></asp:TextBox>

                                                                  <asp:DropDownList ID="ddl_txt_151" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                  TabIndex="360">
                                                 </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_152" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_152" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"  Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="361"></asp:TextBox>


                                                  <asp:DropDownList ID="ddl_txt_152" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                  TabIndex="361">
                                                 </asp:DropDownList> 

                                                    </div>
                                                </div>
                                            </div>
                                      
                                <%--------------------------------------Row End-----------------------------------------%>
                        </div>
                        </div>
                        </div>
                        <%--------------------------------------Row End-----------------------------------------%>
                  </div>

                                      

                                   <div  class="content"  id="page-11"  style="display:none;height:440px;">
                                                    
                                                           <%--------------------------------------1-----------------------------------------%>

                                                        <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_153" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_153" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="362"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_153" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                  TabIndex="362">
                                                 </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_154" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_154" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="363"></asp:TextBox>

                                                                 <asp:DropDownList ID="ddl_txt_154" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                                TabIndex="363">
                                                              </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_155" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_155" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="364"></asp:TextBox>

                                                             <asp:DropDownList ID="ddl_txt_155" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                                TabIndex="364">
                                                              </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_156" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_156" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"  Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="365"></asp:TextBox>

                                                        <asp:DropDownList ID="ddl_txt_156" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="365">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                            </div>



                                                     <%--------------------------------------2-----------------------------------------%>
                                                            <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_157" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_157" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="366"></asp:TextBox>

                                                              <asp:DropDownList ID="ddl_txt_157" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="366">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_158" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_158" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="367"></asp:TextBox>

                                                                  <asp:DropDownList ID="ddl_txt_158" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="367">
                                                         </asp:DropDownList> 
                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_159" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_159" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="368"></asp:TextBox>

                                                                  <asp:DropDownList ID="ddl_txt_159" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="368">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_160" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_160" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px" Visible="false" 
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="369"></asp:TextBox>

                                                             <asp:DropDownList ID="ddl_txt_160" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="369">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                            </div>


                                                           <%--------------------------------------3-----------------------------------------%>
                                                      <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_161" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_161" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="370"></asp:TextBox>

                                                                <asp:DropDownList ID="ddl_txt_161" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="370">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_162" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_162" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="371"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_162" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="371">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_163" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_163" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="372"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_163" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="372">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_164" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_164" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"  Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="373"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_164" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="373">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                            </div>


                                                        <%--------------------------------------4-----------------------------------------%>
                                                     <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_165" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_165" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="375"></asp:TextBox>

                                                         <asp:DropDownList ID="ddl_txt_165" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="375">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_166" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_166" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="376"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_166" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="376">
                                                         </asp:DropDownList> 



                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_167" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_167" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="377"></asp:TextBox>

                                                                <asp:DropDownList ID="ddl_txt_167" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="377">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_168" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_168" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px" Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="380"></asp:TextBox>

                                                          <asp:DropDownList ID="ddl_txt_168" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="380">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                            </div>


                                               <%--------------------------------------5-----------------------------------------%>
                                               <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_169" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_169" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="381"></asp:TextBox>

                                                                <asp:DropDownList ID="ddl_txt_169" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="381">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_170" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_170" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="382"></asp:TextBox>


                                                         <asp:DropDownList ID="ddl_txt_170" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="382">
                                                         </asp:DropDownList> 

                                                    </div>


                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_171" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_171" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="383"></asp:TextBox>

                                                                  <asp:DropDownList ID="ddl_txt_171" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="383">
                                                         </asp:DropDownList> 



                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_172" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_172" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"  Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="384"></asp:TextBox>


                                                               <asp:DropDownList ID="ddl_txt_172" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="384">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                            </div>

                                              <%--------------------------------------6-----------------------------------------%>
                                         <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_173" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_173" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="385"></asp:TextBox>

                                                              <asp:DropDownList ID="ddl_txt_173" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="384">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_174" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_174" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="386"></asp:TextBox>

                                                              <asp:DropDownList ID="ddl_txt_174" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="386">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_175" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_175" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="387"></asp:TextBox>

                                                              <asp:DropDownList ID="ddl_txt_175" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="387">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_176" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_176" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"  Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="388"></asp:TextBox>

                                                             <asp:DropDownList ID="ddl_txt_176" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="388">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                            </div>


                                     </div>

                                       
                                   <div  class="content"  id="page-12"  style="display:none;height:440px;">

                                                <%--------------------------------------1-----------------------------------------%>
                                               <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_177" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_177" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="400"></asp:TextBox>

                                                              <asp:DropDownList ID="ddl_txt_177" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="400">
                                                         </asp:DropDownList> 
                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_178" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_178" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="401"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_178" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="401">
                                                         </asp:DropDownList> 



                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_179" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_179" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="401"></asp:TextBox>

                                                                 <asp:DropDownList ID="ddl_txt_179" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="401">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_180" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_180" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"  Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="402"></asp:TextBox>

                                                             <asp:DropDownList ID="ddl_txt_180" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="402">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                            </div>


                                             <%--------------------------------------2-----------------------------------------%>

                                                      <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_181" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_181" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="403"></asp:TextBox>

                                                                <asp:DropDownList ID="ddl_txt_181" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="403">
                                                         </asp:DropDownList> 
                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_182" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_182" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="404"></asp:TextBox>

                                                            <asp:DropDownList ID="ddl_txt_182" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="404">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_183" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_183" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="405"></asp:TextBox>

                                                             <asp:DropDownList ID="ddl_txt_183" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="405">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_184" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_184" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"  Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="406"></asp:TextBox>

                                                             <asp:DropDownList ID="ddl_txt_184" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="406">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                            </div>
                                                  
                                    
                                                 <%--------------------------------------3-----------------------------------------%>

                                             <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_185" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_185" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="407"></asp:TextBox>

                                                          <asp:DropDownList ID="ddl_txt_185" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="407">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_186" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_186" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="408"></asp:TextBox>

                                                                <asp:DropDownList ID="ddl_txt_186" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="408">
                                                         </asp:DropDownList> 
                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_187" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_187" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="409"></asp:TextBox>

                                                                <asp:DropDownList ID="ddl_txt_187" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="409">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_188" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_188" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px" Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="410"></asp:TextBox>

                                                              <asp:DropDownList ID="ddl_txt_188" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="410">
                                                         </asp:DropDownList> 




                                                    </div>
                                                </div>
                                            </div>
                                             <%--------------------------------------4-----------------------------------------%>
                                             <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_189" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_189" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="411"></asp:TextBox>

                                                                   <asp:DropDownList ID="ddl_txt_189" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="411">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_190" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_190" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="412"></asp:TextBox>

                                                         <asp:DropDownList ID="ddl_txt_190" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="412">
                                                         </asp:DropDownList> 



                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_191" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">

                                                        <asp:TextBox ID="txt_txt_191" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="413"></asp:TextBox>

                                                                <asp:DropDownList ID="ddl_txt_191" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="413">
                                                         </asp:DropDownList> 



                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_192" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_192" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"   Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="414"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_192" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="414">
                                                         </asp:DropDownList> 




                                                    </div>
                                                </div>
                                            </div>
                                               <%--------------------------------------5-----------------------------------------%>

                                        <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_193" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_193" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="415"></asp:TextBox>

                                                                 <asp:DropDownList ID="ddl_txt_193" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="415">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_194" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_194" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="416"></asp:TextBox>

                                                              <asp:DropDownList ID="ddl_txt_194" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="416">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_195" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_195" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="417"></asp:TextBox>

                                                                    <asp:DropDownList ID="ddl_txt_195" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="417">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_196" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_196" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px" Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="418"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_196" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="418">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                            </div>




                                          <%--------------------------------------6-----------------------------------------%>
                                            <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_197" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_197" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="419"></asp:TextBox>

                                                                   <asp:DropDownList ID="ddl_txt_197" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="419">
                                                         </asp:DropDownList> 



                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_198" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_198" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="420"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_198" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="420">
                                                         </asp:DropDownList> 



                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_199" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_199" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="421"></asp:TextBox>

                                                                    <asp:DropDownList ID="ddl_txt_199" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="420">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_200" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_200" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px" Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="422"></asp:TextBox>

                                                            <asp:DropDownList ID="ddl_txt_200" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="420">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                            </div>

                                     </div>
                                              
                                   <div  class="content"  id="page-13"  style="display:none;height:440px;">

                                               <%--------------------------------------1-----------------------------------------%>
                                                <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_201" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_201" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="423"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_201" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="423">
                                                         </asp:DropDownList> 




                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_202" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_202" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="424"></asp:TextBox>

                                                               <asp:DropDownList ID="ddl_txt_202" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="424">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_203" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_203" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="425"></asp:TextBox>

                                                        <asp:DropDownList ID="ddl_txt_203" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="425">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_204" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">

                                                        <asp:TextBox ID="txt_txt_204" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"  Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="426"></asp:TextBox>

                                                                <asp:DropDownList ID="ddl_txt_204" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="426">
                                                         </asp:DropDownList> 



                                                    </div>
                                                </div>
                                            </div>


                                       <%--------------------------------------2-----------------------------------------%>
                                             <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_205" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_205" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="427"></asp:TextBox>

                                                             <asp:DropDownList ID="ddl_txt_205" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="427">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_206" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_206" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="428"></asp:TextBox>

                                                         <asp:DropDownList ID="ddl_txt_206" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="428">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_207" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_207" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="429"></asp:TextBox>

                                                           <asp:DropDownList ID="ddl_txt_207" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="429">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                            <asp:Literal ID="txt_lbl_208" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_208" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="116px"  Visible="false"
                                                          CssClass="txtbox_none_Mid_transac_CUS" TabIndex="430"></asp:TextBox>

                                                          <asp:DropDownList ID="ddl_txt_208" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="430">
                                                         </asp:DropDownList> 



                                                    </div>
                                                </div>
                                            </div>

                                                   <%--------------------------------------3-----------------------------------------%>
                                            <div id="tag_transact_lft_in_2">
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                          <asp:Literal ID="txt_lbl_209" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_209" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"  Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="431"></asp:TextBox>

                                                                <asp:DropDownList ID="ddl_txt_209" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="431">
                                                         </asp:DropDownList> 


                                                    </div>
                                                </div>
                                                <div id="txt_container_Transact_Main_2">
                                                    <div id="tag_label_transact_Src_2">
                                                       <asp:Literal ID="txt_lbl_210" runat="server"></asp:Literal>
                                                    </div>
                                                    <div id="txtcon-m_Exchange_2">
                                                        <asp:TextBox ID="txt_txt_210" runat="server" MaxLength="500" onkeyup="autotab(this);" 
                                                            Width="115px"   Visible="false"
                                                            CssClass="txtbox_none_Mid_transac_CUS" TabIndex="432"></asp:TextBox>

                                                             <asp:DropDownList ID="ddl_txt_210" runat="server"  Width="120px"  Height="20px" Visible="false" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_CUS"
                                                         TabIndex="431">
                                                         </asp:DropDownList> 

                                                    </div>
                                                </div>
                                     
                                            </div>


                                     </div>

                                     </div>



                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="413" onclick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="412" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="414" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="415" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this DSR?', 'Imp DSR', function(r) {
                                              var i = r + 'ok';
                                      if(i == 'trueok')
                                      {
          
                                          document.getElementById('btn').click();
            
                                      }
                                      else {
                                      }
    
                            });return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="416" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="417">
                        </div>
                       <div id="editbu" style="width:10px;"></div>
                    
                    </div>
                </div>

                   </div>
                   <%-- --------------------Test End----------------------------%>

                 
              
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
                activatables('page', ['page-6', 'page-7', 'page-8', 'page-9', 'page-10', 'page-11', 'page-12', 'page-13']);
            </script>

           
             <asp:HiddenField ID="HDupdate_id" runat="server" />
             <asp:HiddenField ID="Hdjobno" runat="server" />
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
