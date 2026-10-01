<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gst_Rpt_Annexure_Entry_Imp.aspx.cs" Inherits="Accounts_Sales_Gst_Rpt_Annexure_Entry_Imp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Sales Annexure</title>
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
            <div id="innerbox_MidMain" style="height:905px;" >
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                     Job Report Annexure </div>
                    <div id="verslic">
                    </div>
                      <div id="mainmastop2container_rght_tag2_txt1" style="width:100px;color:Gray;">
                       Invoice No : 
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:150px; color:Black;">
                        <asp:Literal ID="txtInvoiceNo" runat="server"></asp:Literal>
                    </div>
                      <div id="verslic">
                    </div>
                     <div id="mainmastop2container_rght_tag2_txt1"   style="width:250px;">
                       <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        Job Number
                                    </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="TxtJobNo" runat="server" MaxLength="50" TabIndex="1" CssClass=" txtbox_none"
                                            Width="140px"></asp:TextBox>
                                       
                                    </div>
                     </div>
                      <div id="verslic">
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1"   style="width:250px;">
                       <div id="tag_label_transaction_popup_IGM_invoice" style="width: 80px">
                                        Job Type
                                    </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="TxtJobtype" runat="server" MaxLength="50" TabIndex="2" CssClass=" txtbox_none"
                                            Width="140px"></asp:TextBox>
                                        
                                    </div>
                     </div>
                   

                    <div id="popupwindow_closebut_right_new">
                       
                        <span id="F" runat="server"><input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 
                     
                    </div>
           
                 
                </div>

                <div id="innerbox_MidMain_bot_transact" style="height: 375px; width: 1180px;">
                <div id="innerbox_MidMain_Trans_IGM_Invoice" style="background-image: none; height: 455px;
                    width: 1120px; margin-left: -10px; margin-top: -3px;">
                    <div class="content" id="page-1">
                        <asp:Panel ID="Panel1" runat="server">
                            <div id="pop_text_area_transac_popup_inn_container_left_IGM_invoice" style="width: 1130px; height:405px;">
                                <div id="tag_transac_lft_Inv_in1" style="width: 1100px; height: 30px; margin-bottom: 0px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        BE Number
                                    </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                                        <asp:TextBox ID="txtBe_No" runat="server" MaxLength="50" ClientIDMode="Static"
                                            CssClass="txtbox_none_Mid_transac_code" TabIndex="3" onkeypress="return numcharspl1(event)"
                                            Width="160px"></asp:TextBox>
                                     
                                     
                                    </div>
                                    <div id="magnify_area" style="width: 10px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 75px">
                                        Date</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="txtBeDate" runat="server" MaxLength="10" TabIndex="4" CssClass=" txtbox_none"
                                            Width="140px"></asp:TextBox>
                                       <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtBeDate"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" 
                                            ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBeDate"
                                            PopupButtonID="txtCreatedate" Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>
                                    <div id="magnify_area" style="width: 20px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px">
                                        Customer Ref.</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 170px">
                                        <asp:TextBox ID="txtCustomer" runat="server" MaxLength="50" 
                                            ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_code"
                                            TabIndex="5" onkeypress="return numcharspl1(event)" Width="160px"></asp:TextBox>
                                        
                                        
                                      
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Inv_in1" style="width: 1110px; height: 30px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        BE Type</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                                        <asp:TextBox ID="txtBe_type" runat="server" MaxLength="25" TabIndex="6" CssClass="txtbox_none"
                                            Width="160px"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area" style="width: 10px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 75px">
                                        Invoice No</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                       <asp:TextBox ID="txtInvoice_No" runat="server" MaxLength="25" TabIndex="7" CssClass="txtbox_none"
                                            Width="140px"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area" style="width: 20px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px">
                                        Date
                                    </div>

                                     <div id="txtcon-m_transaction_Inv_No" style="width: 170px">
                                        <asp:TextBox ID="txtInv_dt" runat="server" MaxLength="10" ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="8" onkeypress="return numcharspl1(event)" Width="160px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txtInv_dt"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" 
                                             ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txtInv_dt"
                                             Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                    </div>


                                   
                                </div>
                                <div id="tag_transac_lft_Inv_in1" style="width: 1110px; height: 30px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        MBL No
                                    </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                                        <asp:TextBox ID="txtMbl_No" runat="server" MaxLength="25" TabIndex="9" CssClass="txtbox_none"
                                            Width="160px"></asp:TextBox>
                                    </div>
                                    <div id="magnify_area" style="width: 10px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 75px">
                                        Date
                                    </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="txtMbldate" runat="server" MaxLength="10" ClientIDMode="Static"
                                            CssClass=" txtbox_none" TabIndex="10" onkeypress="return numcharspl1(event)"
                                            Width="140px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txtMbldate"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" 
                                            ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtMbldate"
                                             Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                        <div style="color: White; width: 5px; float: right;">
                                            *</div>
                                    </div>
                                    <div id="magnify_area" style="width: 20px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px">
                                        Terms oF Invoice</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 170px">
                                        <asp:TextBox ID="txtTerms" runat="server" MaxLength="50" TabIndex="11" CssClass="txtbox_none"
                                           Width="160px"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Inv_in1" style="width: 1110px; height: 30px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        HBL No</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                                        <asp:TextBox ID="TxtHbl" runat="server" MaxLength="50" TabIndex="12" CssClass=" txtbox_none"
                                            Width="160px"></asp:TextBox>
                                        <div style="color: White; width: 5px; float: right;">
                                            *</div>
                                    </div>
                                    <div id="magnify_area" style="width: 10px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 75px">
                                        Date
                                    </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="txtHbl_Date" runat="server" MaxLength="10" 
                                            ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="13" onkeypress="return numcharspl1(event)" Width="140px"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender9" runat="server" TargetControlID="txtHbl_Date"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" 
                                            ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender9" runat="server" TargetControlID="txtHbl_Date"
                                             Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                        <div style="color: White; width: 5px; float: right;">
                                            *</div>
                                    </div>
                                    <div id="magnify_area" style="width: 20px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px">
                                        Invoice Value</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 170px">
                                        <asp:TextBox ID="TxtInv_Value" runat="server" MaxLength="30" 
                                         onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"    ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="14"   Width="160px"></asp:TextBox>
                                        
                                       
                                    </div>
                                    <div id="magnify_area" style="width: 18px">
                                    </div>

                                         <div id="tag_label_transaction_popup_IGM_invoice" style="width: 70px">
                                        CIF Value</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="txtCif_Val" runat="server" MaxLength="30" 
                                        onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"     ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="15"   Width="140px"></asp:TextBox>
                                        
                                       
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Inv_in1" style="width: 1110px; height: 30px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        Consign. Type</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                                        <asp:TextBox ID="txtConsign_Type" runat="server" MaxLength="50" TabIndex="16" CssClass=" txtbox_none"
                                            Width="160px"></asp:TextBox>
                                       
                                    </div>
                                    <div id="magnify_area" style="width: 10px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 75px">
                                        Pkgs</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="txtPkgs" runat="server" MaxLength="30" ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="17" onkeypress="return numcharspl1(event)" Width="140px"></asp:TextBox>
                                      
                                    </div>
                                    <div id="magnify_area" style="width: 20px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px">
                                        Assese Value</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 170px">
                                        <asp:TextBox ID="txtAssese_Value" runat="server" MaxLength="30" 
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"  ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="18"  Width="160px"></asp:TextBox>
                                        
                                       
                                    </div>
                                    <div id="magnify_area" style="width: 18px">
                                    </div>

                                         <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                                        </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="TextBox12" runat="server" MaxLength="10" ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="19" onkeypress="return numcharspl1(event)" Width="140px" 
                                            Visible="False"></asp:TextBox>
                                        
                                       
                                    </div>
                                </div>

                                <div id="tag_transac_lft_Inv_in1" style="width: 1110px; height: 30px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        Gross weight</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                                        <asp:TextBox ID="txtGross_wt" runat="server" MaxLength="50" TabIndex="20" CssClass=" txtbox_none"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);"   Width="160px"></asp:TextBox>
                                       
                                    </div>
                                    <div id="magnify_area" style="width: 10px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 75px">
                                        Net wt</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="txtNet_wt" runat="server" MaxLength="30" ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="21"  onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" Width="140px"></asp:TextBox>
                                      
                                    </div>
                                    <div id="magnify_area" style="width: 20px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px">
                                        Total Duty</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 170px">
                                        <asp:TextBox ID="txtDuty" runat="server" MaxLength="30" 
                                            ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="22"   onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" Width="160px"></asp:TextBox>
                                        
                                       
                                    </div>
                                    <div id="magnify_area" style="width: 18px">
                                    </div>

                                         <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                                        </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="TextBox16" runat="server" MaxLength="10" ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="23" onkeypress="return numcharspl1(event)" Width="140px" 
                                            Visible="False"></asp:TextBox>
                                        
                                       
                                    </div>
                                </div>

                                <div id="tag_transac_lft_Inv_in1" style="width: 1110px; height: 30px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        Custom House</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                                        <asp:TextBox ID="txtCustom" runat="server" MaxLength="50" TabIndex="24" CssClass=" txtbox_none"
                                            Width="160px"></asp:TextBox>
                                       
                                    </div>
                                    <div id="magnify_area" style="width: 10px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 75px">
                                        Chrg.Wt</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="txtChrgwt" runat="server" MaxLength="30" ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="25"  onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                            onkeypress="return blockNonNumbers(this, event, true, false);" Width="140px" 
                                           ></asp:TextBox>
                                      
                                    </div>
                                    <div id="magnify_area" style="width: 20px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px">
                                        Shipper Name</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 170px">
                                        <asp:TextBox ID="txtShipper_Name" runat="server" MaxLength="250" 
                                            ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="26" onkeypress="return numcharspl1(event)" Width="160px"></asp:TextBox>
                                        
                                       
                                    </div>
                                    <div id="magnify_area" style="width: 18px">
                                    </div>

                                         <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                                        </div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="TextBox5" runat="server" MaxLength="10" ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="27" onkeypress="return numcharspl1(event)" Width="140px" 
                                            Visible="False"></asp:TextBox>
                                        
                                       
                                    </div>
                                </div>

                                <div id="tag_transac_lft_Inv_in1" style="width: 1110px; height: 30px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        Vessel</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                                        <asp:TextBox ID="txtVessel" runat="server" MaxLength="50" TabIndex="28" CssClass=" txtbox_none"
                                          Width="160px"></asp:TextBox>
                                       
                                    </div>
                                    <div id="magnify_area" style="width: 10px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 75px">
                                        Voyage</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="txtVoyage_No" runat="server" MaxLength="30" 
                                            ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="29" onkeypress="return numcharspl1(event)" Width="140px"></asp:TextBox>
                                      
                                    </div>
                                    <div id="magnify_area" style="width: 20px">
                                    </div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px">
                                        BE Heading</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 170px">
                                        <asp:TextBox ID="txtBe_Heading" runat="server" MaxLength="50" 
                                            ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="30" onkeypress="return numcharspl1(event)" Width="160px"></asp:TextBox>
                                        
                                       
                                    </div>
                                    <div id="magnify_area" style="width: 18px">
                                    </div>

                                         <div id="tag_label_transaction_popup_IGM_invoice" style="width: 90px">
                                        </div>
                                    <div id="txtcon-txtNo_of_container" style="width: 150px">
                                        <asp:TextBox ID="TextBox9" runat="server" MaxLength="10" ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="31" onkeypress="return numcharspl1(event)" Width="140px" 
                                            Visible="False"></asp:TextBox>
                                        
                                       
                                    </div>
                                </div>
                                <div id="tag_transac_lft_Inv_in1" style="width: 1110px; height: 30px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        Orgin Port</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                                        <asp:TextBox ID="txtOrgin" runat="server" MaxLength="150" TabIndex="32" CssClass=" txtbox_none"
                                            Width="160px"></asp:TextBox>
                                       
                                    </div>
                                    
                                    <div id="magnify_area" style="width: 10px"></div>
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px">
                                         No. of Containers</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 150px">
                                        <asp:TextBox ID="txtNo_of_container" runat="server" MaxLength="50" 
                                            ClientIDMode="Static" CssClass=" txtbox_none_Mid_transac_code"
                                            TabIndex="33" onkeypress="return numcharspl1(event)" Width="140px"></asp:TextBox>
                                        
                                       
                                    </div>
                                    
                                    
                                </div>
                                <div id="tag_transac_lft_Inv_in1" style="width: 1110px; height: 30px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        Importer Name</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 255px">
                                        <asp:TextBox ID="txtImport" runat="server" MaxLength="250" TabIndex="33" CssClass=" txtbox_none"
                                            Width="250px"></asp:TextBox>
                                      
                                    </div>
                                    <div id="magnify_area" style="width: 10px">
                                    </div>
                                </div>
                               <div id="tag_transac_lft_Inv_in1" style="width: 1110px; height: 30px;">
                                    <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px">
                                        Containers</div>
                                    <div id="txtcon-m_transaction_Inv_No" style="width: 255px">
                                        <asp:TextBox ID="txtcontainers" runat="server" MaxLength="50" TabIndex="34" CssClass=" txtbox_none"
                                            Width="250px"></asp:TextBox>
                                      
                                    </div>
                                    <div id="magnify_area" style="width: 10px">
                                    </div>
                                </div>

                        </asp:Panel>
                    </div>
               
            <div id="innerbox_MidMain_bot_transact_invoice" style="padding-left: 10px">
                <div id="newbu">
                 <%--   <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="21" OnClick="btnNew_Click"
                        CausesValidation="False" UseSubmitBehavior="false" />--%>
                </div>
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" CssClass="save"  OnClientClick="return validate();"
                        OnClick="btnSave_Click" TabIndex="35" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates"  OnClientClick="return validate();"
                      OnClick="btnUpdate_Click"  TabIndex="36"  Visible="false" />
                </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="37" CausesValidation="false"
                        Visible="false" UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Annexure?', 'Annexure Details', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="28" CausesValidation="false" UseSubmitBehavior="false"
                        CssClass="dlete" Style="display: none;" OnClick="btnDelete_Click" />
                </div>
                <div id="editbu">
                    <input type="submit" value="Submit" class="scancel" onclick="parent.adcodewindow.hide();return false;"
                        tabindex="38" id="btn_cancel" />
                </div>
            </div>
             </div>
            </div>

            </div>
                          <asp:HiddenField ID="HDupdate_id" runat="server" />    
                              
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
   
  <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
  
  <script type="text/javascript">
      $(document).ready(function () {


      });

   

	</script>

  
  

  

  
  
     
    
</body>
</html>
