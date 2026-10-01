<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EXP_Air_WayBill.aspx.cs" Inherits="EXP_Air_WayBill" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>AWB Bill Invoice</title>
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


    
       
       <style type="text/css">  
        .CalendarStyle   
        {  
            background-color:Crimson;  
            color:White;  
            border:solid 1px DarkRed;  
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
             #tag_label_transaction_popup_gen_IE
        {
        color: #232323;
        float: left;
        font-size: 13px;
        height: 15px;
        line-height: 20px;
        text-align: left;
        width: 155px;
        Color: Black;
        font-family: sans-serif;
        }
         
        #tag_transac_lft_in2
        {
        height: 25px;
        width: 470px;
        }   
        table td  {
            border: 0.5px solid black;
        }
        
        #grid-header a 
        { 
          color: Red; 
          font-weight: bold;
        }

       </style>  


       <style type="text/css">
         
        .myGridStyle
        {
            border-collapse:collapse;
             
        }
         
        .myGridStyle tr th
        {
            color: black;
            border: 0.5px solid black;
            font-size:12px;
        }
       .myGridStyle tr:nth-child(even)
        {
            background-color: #D1D0CE;
            font-size:12px;
        } 
         
         .myGridStyle tr:nth-child(odd)
        {
            background-color: #D1D0CE;
            font-size:12px;
        } 
         
        .myGridStyle td
        {
            border:0.5px solid black;
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
        <div id="innerbox_MidMain_Grid">
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>

            <div id="innerbox_MidMain" style="height:75px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                        Export Air WayBill</div>
                    <div id="verslic">
                    </div>
                                   <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Exporter Name</div>
                                <div id="txtcon-m_Exchange">

                                     <asp:DropDownList ID="ddlExp_name" CssClass="listtxt_transac_item_gen_notn" Width="370px"
                                     runat="server" AutoPostBack="True" TabIndex="1" 
                                         onselectedindexchanged="ddlExp_name_SelectedIndexChanged"> </asp:DropDownList>

                                </div>
                            </div>

                    <div id="txt_container_Transact_Main_l" style="width: 160px;">
                        <div id="div_type" runat="server">
                            <div id="tag_label_transact_Src" style="width: 50px;">
                                Job No
                            </div>
                            <div id="txtcon-m_Exchange" style="width: 105px;">
                                <asp:DropDownList ID="ddljobno" CssClass="listtxt_transac_item_gen_notn" Width="100px"
                                    AutoPostBack="true" runat="server" TabIndex="5" 
                                    onselectedindexchanged="ddljobno_SelectedIndexChanged">
                                </asp:DropDownList>
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

                <div id="tag_Exchange_inner_lft" style="width: 1150px">
                           <div id="tag_transact_lft_in1" style="width: 1150px">
                               <div id="txt_container_Transact_Main_l" style="width: 170px;">
                                   <div id="tag_label_transact_Src" style="width: 80px;">
                                       AWB Type
                                   </div>
                                   <div id="txtcon-m_Exchange" style="width: 80px">
                                       <asp:DropDownList ID="ddlAWB_Type" CssClass="listtxt_transac_FCL" runat="server"
                                           Width="75px" TabIndex="6">
                                           <asp:ListItem Text="Master" Value="M"></asp:ListItem>
                                           <asp:ListItem Text="House" Value="H"></asp:ListItem>
                                       </asp:DropDownList>
                                   </div>
                               </div>
                               <div id="txt_container_Transact_Main_l" style="width: 310px">
                                   <div id="tag_label_transact_Src" style="width: 120px">
                                       Master AWB No
                                   </div>
                                   <div id="txtcon-m_Exchange" style="width: 190px">
                                       <asp:TextBox ID="txtMaster_Awb_no_1" runat="server" MaxLength="50" Width="35px" 
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" TabIndex="7"></asp:TextBox>
                                       <asp:TextBox ID="txtMaster_Awb_no_2" runat="server" MaxLength="50" Width="120px"
                                            CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" TabIndex="8"></asp:TextBox>
                                            
                                   </div>
                               </div>
                               <div id="txt_container_Transact_Main_l" style="width: 230px">
                                   <div id="tag_label_transact_Src">
                                       House AWB No
                                   </div>
                                   <div id="txtcon-m_Exchange" style="width: 130px">
                                       <asp:TextBox ID="txtHouse_Awb_no" runat="server" MaxLength="50" Width="120px" 
                                        CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" TabIndex="9"></asp:TextBox>
                                   </div>
                               </div>
                               <div id="txt_container_Transact_Main_l" style="width: 190px">
                                   <div id="tag_label_transact_Src" style="width: 80px">
                                       AWB Date
                                   </div>
                                   <div id="txtcon-m_Exchange" style="width: 110px">
                                       <asp:TextBox ID="txtAWBDate" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                           TabIndex="10"></asp:TextBox>
                                       <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtAWBDate"
                                           Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                           CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                           CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                           Enabled="True">
                                       </asp:MaskedEditExtender>
                                       <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtAWBDate"
                                           Format="dd/MM/yyyy" Enabled="True">
                                       </asp:CalendarExtender>
                                   </div>
                               </div>
                               <div id="txt_container_Transact_Main_l" style="width: 190px">
                                   <div id="tag_label_transact_Src" style="width: 80px">
                                       DSR Date
                                   </div>
                                   <div id="txtcon-m_Exchange" style="width: 110px">
                                       <asp:TextBox ID="txtDSRDate" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                           TabIndex="11"></asp:TextBox>
                                       <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtDSRDate"
                                           Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                           CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                           CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                           Enabled="True">
                                       </asp:MaskedEditExtender>
                                       <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDSRDate"
                                           Format="dd/MM/yyyy" Enabled="True">
                                       </asp:CalendarExtender>
                                   </div>
                               </div>
                           </div>
                       </div>
            </div>
             
             
                 <div id="pop_text_area_transac_popup_inn_container_new" style="margin-top:-23px; height:455px;">

<div id="innerbox_MidMain_Trans_new" style="width:1092px;margin-left:0px;height:450px;">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="tab_page1();" id="Admin_Master"><span> Destination </span></a></li>
                    <li><a href="#page-2" onclick="tab_page2();" id="Master"><span>Invoice</span></a></li>
                   <%-- <li><a href="#page-3" onclick="tab_page3();" id="A1"><span>Other</span></a></li>--%>
                </ol>
                 
                <div class="content" id="page-1" style=" height:430px;" >
               
                   <div id="pop_text_area_transac_popup_inn_container_new" style="height:447px; width:1090px;margin-left:-15px;;margin-top:-10px;"  >

                       <div id="pop_text_area_transac_popup_inn_container_left_new" style="width: 545px; height:397px;"> 
                           <div id="tag_transac_lft_in1" style="height: 3px;">
                           </div>
                           
                           <div id="tag_transac_lft_in2" style="height: 176px;margin-left: 0px; width: 544px;">
                               <fieldset id="fld" >
                                <legend style="border:Black;border-collapse: collapse; width:100px; text-align:center;" > Shipper's </legend>

                                <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            A/c No.</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Shipper_Accno" runat="server" MaxLength="30"
                                             CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" TabIndex="12"></asp:TextBox>
                                            
                                        </div>
                                    </div>
                                     <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Name</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Shipper_Name" runat="server" MaxLength="220"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="13"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Address</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Shipper_Add1" runat="server" MaxLength="180"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="14"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Shipper_Add2" runat="server" MaxLength="150"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="15"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1" style="width:470px;">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width:300px;" >
                                            <asp:TextBox ID="txt_Shipper_Add3" runat="server" MaxLength="100"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" Width="160px" TabIndex="16"></asp:TextBox>
                                                <asp:TextBox ID="txt_Shipper_Add4" Width="120px"  runat="server" MaxLength="80"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="17"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                     
                               </fieldset>

                               <div id="tag_transac_lft_in1" style="height:5px;"></div>
                               <fieldset id="fld" >
                                <legend style="border:Black;border-collapse: collapse; width:100px; text-align:center;" > Agent </legend>
                                     <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Name</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Agent_Name" runat="server" MaxLength="220" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="30"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            City</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Agent_City" runat="server" MaxLength="180" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="31"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                        IATA Code
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Agent_IATA_Code" runat="server" Width="108px" MaxLength="100" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="32"></asp:TextBox>
                                                A/c No. 
                                                <asp:TextBox ID="txt_Agent_Acc_No" runat="server" MaxLength="30" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Width="107px"
                                                Onkeypress="return numcharspl1(event)" TabIndex="33"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                          A/c Info.
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <%--<asp:TextBox ID="txt_Agent_Acc_info" runat="server" MaxLength="250" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="34"></asp:TextBox>--%>

                                                <asp:TextBox ID="txt_Agent_Acc_info" runat="server" MaxLength="250"  Font-Size="12px"
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" TextMode="MultiLine" Height="60px"
                                                TabIndex="34"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div id="tag_transac_lft_in1">
                                     </div>
                                     <div id="tag_transac_lft_in1"></div>
                               </fieldset>
                               <div id="tag_transac_lft_in1" style="height:5px;"></div>
                                   <div id="tag_transac_lft_in1" >
                                        <div id="tag_label_transaction_popup_gen" style="width:150px;">
                                            Routing and Destination </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width:320px; font-size:12px;">
                                        To
                                            <asp:TextBox ID="txt_to_1" runat="server" Width="28px" MaxLength="5" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="36"></asp:TextBox>
                                                By
                                                 <asp:TextBox ID="txt_by_1" runat="server" Width="28px" MaxLength="5" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="37"></asp:TextBox>
                                                  To
                                            <asp:TextBox ID="txt_to_2" runat="server" Width="28px" MaxLength="5"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="38"></asp:TextBox>
                                                By
                                                 <asp:TextBox ID="txt_by_2" runat="server" Width="28px" MaxLength="5" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="39"></asp:TextBox>
                                                To
                                            <asp:TextBox ID="txt_to_3" runat="server" Width="28px" MaxLength="5" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="40"></asp:TextBox>
                                                By
                                                 <asp:TextBox ID="txt_by_3" runat="server" Width="28px" MaxLength="5"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="41"></asp:TextBox>
                                        </div>
                                    </div>
                                   <div id="tag_transac_lft_in1" style="height:5px;"></div>
                                 <div id="tag_transac_lft_in1" >
                                        <div id="tag_label_transaction_popup_gen" >
                                            Currency</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width:320px; font-size:12px;">
                                            <asp:TextBox ID="txt_Currency" runat="server" Width="40px" MaxLength="3" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="42"></asp:TextBox>
                                                CHGS Code
                                            <asp:DropDownList ID="ddlCHGS_Code" onchange="GetSelectedTextValue(this)" onblur="GetSelectedTextValue(this)" CssClass="listtxt_transac_FCL" TabIndex="43" runat="server" Width="40px">
                                                <asp:ListItem Text="PP" Value="P"></asp:ListItem>
                                                <asp:ListItem Text="CC" Value="C"></asp:ListItem>
                                            </asp:DropDownList>
                                                  WT/VAL
                                            <asp:TextBox ID="txt_WT_VAL" runat="server" Width="28px" MaxLength="5"  
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="44"></asp:TextBox>
                                                Other
                                                 <asp:TextBox ID="txt_WT_VAL_Other" runat="server" Width="28px" MaxLength="5" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="45"></asp:TextBox>
                                        </div>
                                    </div>
                           </div>
                       </div>
                       <div id="pop_text_area_transac_popup_inn_container_rght_new" style="width: 542px; height:397px;">
                           <div id="tag_transac_lft_in1" style="height: 3px;">
                           </div>

                           <fieldset id="fld" >
                                <legend style="border:Black;border-collapse: collapse; width:100px; text-align:center;" > Consignee's </legend>

                                <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            A/c No.</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Consignee_Accno" runat="server" MaxLength="30" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Width="111px"
                                                Onkeypress="return numcharspl1(event)" TabIndex="20"></asp:TextBox>
                                                LC No.
                                                   <asp:TextBox ID="txt_Consignee_LC_No" runat="server" MaxLength="30" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Width="110px"
                                                Onkeypress="return numcharspl1(event)" TabIndex="21"></asp:TextBox>

                                        </div>
                                    </div>
                                     <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Name</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Consignee_Name" runat="server" MaxLength="220" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="22"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Address</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Consignee_Add1" runat="server" MaxLength="180" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="23"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Consignee_Add2" runat="server" MaxLength="150"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="24"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_in1" style="width:470px;">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" style="width:300px;" >
                                             <asp:TextBox ID="txt_Consignee_Add3" runat="server" MaxLength="100" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" Width="160px" TabIndex="25"></asp:TextBox>
                                                 <asp:TextBox ID="txt_Consignee_Add4" runat="server" MaxLength="80"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)"  Width="120px" TabIndex="26"></asp:TextBox>
                                        </div>
                                    </div>
                                     
                               </fieldset>
                        
                        <div id="tag_transac_lft_in1" style="height:5px;"></div>
             <%--                  <fieldset id="fld" >
                                <legend style="border:Black;border-collapse: collapse; width:100px; text-align:center;" > Airport </legend>--%>
                              <div id="tag_transac_lft_in1" style="height:60px;" >
                                        <div id="tag_label_transaction_popup_gen">
                                         Airport  Departure and Requested Routing </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Airport_Departure" runat="server" MaxLength="200"
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" TextMode="MultiLine" Height="40px"
                                                TabIndex="50"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Airport Destination</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Airport_Destination" runat="server" MaxLength="120" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="51"></asp:TextBox>
                                        </div>
                                    </div>
                                  <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Flight No </div>
                                      <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                          <asp:TextBox ID="txt_flight_No" runat="server" Width="135px" MaxLength="40" Font-Size="12px"
                                               ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                              Onkeypress="return numcharspl1(event)" TabIndex="52"></asp:TextBox>
                                          Date
                                          <asp:TextBox ID="txtflight_date" runat="server" MaxLength="10" CssClass="txtbox_none_Mid_transac_code"
                                              TabIndex="53"></asp:TextBox>
                                          <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtflight_date"
                                              Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                              CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                              CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                              Enabled="True">
                                          </asp:MaskedEditExtender>
                                          <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtflight_date"
                                              Format="dd/MM/yyyy" Enabled="True">
                                          </asp:CalendarExtender>
                                      </div>
                                    </div>

                           <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            Amt of Insurance </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_Amt_of_Insurance" runat="server" MaxLength="30" 
                                                 CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" TabIndex="54"></asp:TextBox>
                                        </div>
                                    </div>
                                      <div id="tag_transac_lft_in1">
                                        <div id="tag_label_transaction_popup_gen">
                                            DV for Carriage </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                            <asp:TextBox ID="txt_DV_for_Carriage" runat="server" MaxLength="30" Width="80px" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" Font-Size="12px"
                                                Onkeypress="return numcharspl1(event)" TabIndex="55"></asp:TextBox>
                                                DV for Customs
                                                 <asp:TextBox ID="txt_DV_for_Customs" Width="80px"  runat="server" MaxLength="30" 
                                                ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="56"></asp:TextBox>
                                        </div>
                                    </div>
                           
                              <div id="tag_transac_lft_in1" >
                                        <div id="tag_label_transaction_popup_gen" >
                                            Handling Info.</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" >
                                                <asp:TextBox ID="txt_Handling_info" runat="server" MaxLength="400"  
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"
                                                Onkeypress="return numcharspl1(event)" TabIndex="57"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div id="tag_transac_lft_in1" >
                                        <div id="tag_label_transaction_popup_gen" >
                                            Issued by </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic_new" >
                                                <asp:TextBox ID="txt_Issued_by" runat="server" MaxLength="180" 
                                                CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new" TabIndex="58"></asp:TextBox>
                                        </div>
                                    </div>
                       </div>
                         </div>

                   </div>


                   <div class="content" id="page-2" style="padding-top:0px;">
                 <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow-x: hidden;overflow-y: auto; height:203px; width:1055px;margin-top:15px; height:212px;">
                     <asp:GridView ID="gv_Chg_Details" runat="server" EmptyDataText="No Record Found"
                         OnRowCreated="gv_Chg_Details_RowCreated" Width="100%" AutoGenerateColumns="False"
                         GridLines="None" CssClass="myGridStyle" >
                         
                         <RowStyle BorderWidth="0.1em" BorderColor="black" />
                         <HeaderStyle CssClass="grid-header" />

                         <Columns>
                             <asp:BoundField DataField="RowNumber"  HeaderText="S.No" HeaderStyle-Font-Bold="true"
                                 ItemStyle-Width="15px" HeaderStyle-Width="15px" ItemStyle-HorizontalAlign="Center" />
                               <%--  <asp:TemplateField HeaderText="S.No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="44px">
                                        <ItemTemplate>
                                        <asp:Label ID="lblitemslno"   runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle  HorizontalAlign="Center"  Width="44px"  />
                                    </asp:TemplateField>--%>
                             <asp:TemplateField HeaderText="No. of Pieces RCP" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_No_of_Pieces_RCB" Text='<%# Bind("No_of_Pieces_RCB") %>' runat="server"  Height="20px" Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                                 <ItemStyle Width="50px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Gross Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_Gross_Wgt" Text='<%# Bind("Gross_Wgt") %>' runat="server" Height="20px"
                                         Width="50px"></asp:TextBox>
                                 </ItemTemplate>
                                 <ItemStyle Width="50px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Kg Lb" HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_Kg_Lb" Text='<%# Bind("Kg_Lb") %>' Height="20px" Width="40px"
                                         runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 <ItemStyle Width="40px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Rate/Class" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_Rate_Class" Text='<%# Bind("Rate_Class") %>' Height="20px" Width="70px"
                                         runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 <ItemStyle Width="70px" />
                             </asp:TemplateField>
                            
                             <asp:TemplateField HeaderText="Commodity Item No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="130px">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_Commodity_item_No" Text='<%# Bind("Commodity_item_No") %>' Height="20px" 
                                         
                                         Width="130px" runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 <ItemStyle Width="130px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Chargeable Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="130px">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_Charge_wgt" Text='<%# Bind("Charge_wgt") %>' Height="20px"
                                         Width="130px" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                         onkeypress="return blockNonNumbers(this, event, true, false);" runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 <ItemStyle Width="130px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Rate/Charge" HeaderStyle-Font-Bold="true" HeaderStyle-Width="125px">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_Rate_Charge" Text='<%# Bind("Rate_Charge") %>' onblur="extractNumber(this,3,false);"
                                         onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                         Height="20px" Width="125px" runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 <ItemStyle Width="125px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Total" HeaderStyle-Font-Bold="true" HeaderStyle-Width="125px">
                                 <ItemTemplate>
                                      <asp:TextBox ID="txt_Total" Text='<%# Bind("Total") %>' onblur="extractNumber(this,3,false);"
                                         onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                         Height="20px" Width="125px" runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 <ItemStyle Width="125px" />
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Nature and Qty. of Good (Incl. Dimension or Voluem)"
                                 HeaderStyle-Font-Bold="true" HeaderStyle-Width="240px">
                                 <ItemTemplate>
                                     <asp:TextBox ID="txt_Nature_and_Qty" Text='<%# Bind("Nature_and_Qty") %>'
                                         Height="20px" Width="240px" runat="server"></asp:TextBox>
                                 </ItemTemplate>
                                 <ItemStyle Width="240px" />
                             </asp:TemplateField>
                         </Columns>
                     </asp:GridView>
                            </div>
                 <div id="pop_text_area_transac_popup_inn_container_new" style="height:250px; width:1055px;">
                 <div id="pop_text_area_transac_popup_inn_container_left_new" style="width: 545px;border: 1.5px solid; height:193px;">

                 <div id="tag_transac_lft_in1" style="background-color:#D1D0CE; margin-left:0px;width: 545px;" >
                 <div id="tag_label_transaction_popup_gen" style="width: 26px;"></div>
                                        <div id="tag_label_transaction_popup_gen" >
                                             <asp:TextBox ID="txt_total_No_of_Pieces_RCP" runat="server" Width="50px" MaxLength="30" 
                                                 TabIndex="60"></asp:TextBox>
                                                 <asp:TextBox ID="txt_total_Gross_Wgt" runat="server" Width="50px" MaxLength="25" 
                                                 TabIndex="65"></asp:TextBox>
                                            </div>
                                    </div>

                     <table style="background-color:#D1D0CE;" >
                         <tr>
                             <td>
                             </td>
                             <td align="center">
                                 Prepaid
                             </td>
                             <td align="center">
                                 Collect
                             </td>
                         </tr>
                          <tr>
                             <td>
                             Weight Charge
                             </td>
                             <td>
                                 <asp:TextBox ID="txt_wgt_ch_PP" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="67"></asp:TextBox>
                             </td>
                             <td>
                                 <asp:TextBox ID="txt_wgt_ch_CC" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="68"></asp:TextBox>
                             </td>
                         </tr>

                         <tr>
                             <td>
                             Valuation Charge
                             </td>
                             <td>
                                 <asp:TextBox ID="txt_valuation_Ch_PP" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="69"></asp:TextBox>
                             </td>
                             <td>
                                <asp:TextBox ID="txt_valuation_Ch_CC" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="70"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                             Tax
                             </td>
                             <td>
                                 <asp:TextBox ID="txt_Tax_PP" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="71"></asp:TextBox>
                             </td>
                             <td>
                                <asp:TextBox ID="txt_Tax_CC" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="72"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                             Total Other charge Due Agent
                             </td>
                             <td>
                                <asp:TextBox ID="txt_tot_oth_Ch_due_agent_PP" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="73"></asp:TextBox>
                             </td>
                             <td>
                               <asp:TextBox ID="txt_tot_oth_Ch_due_agent_CC" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="74"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                             Total Other Charges Due Carrier
                             </td>
                             <td>
                                <asp:TextBox ID="txt_tot_oth_Ch_due_Carrier_PP" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="75"></asp:TextBox>
                             </td>
                             <td>
                                <asp:TextBox ID="txt_tot_oth_Ch_due_Carrier_CC" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="76"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                             Total
                             </td>
                             <td>
                                <asp:TextBox ID="txt_total_PP" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="77"></asp:TextBox>
                             </td>
                             <td>
                                 <asp:TextBox ID="txt_total_CC" runat="server" MaxLength="25" Width="162px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="78"></asp:TextBox>
                             </td>
                         </tr>
                     </table>
                 </div>

                    <div id="pop_text_area_transac_popup_inn_container_rght_new" style="width: 505px; height:193px;
                           border: solid; border: 1.5px solid; border-left-style: none;">
                        <div id="tag_transac_lft_in1" style="background-color: #D1D0CE; margin-left: 0px;
                            width: 505px;">
                            <div id="tag_label_transaction_popup_gen" style="width: 126px;">
                            </div>
                            <div id="tag_label_transaction_popup_gen">
                                <asp:TextBox ID="txt_grid_total" runat="server" Width="130px" MaxLength="50" TabIndex="66"></asp:TextBox>
                            </div>
                        </div>
                           <table style="background-color:#D1D0CE; width:100%;">
                         
                         <tr>
                             <td>
                            Notify
                             </td>
                             <td>
                                 <asp:TextBox ID="txt_Notify" runat="server" MaxLength="400" Width="342px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="79"></asp:TextBox>
                             </td>
                             
                         </tr>
                          <tr>
                             <td>
                               Other Charges
                             </td>
                             <td>
                                  <asp:TextBox ID="txt_other_Ch" runat="server" MaxLength="250" Width="342px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="80"></asp:TextBox>
                             </td>
                             
                         </tr>

                         
                         <tr>
                             <td>
                             Sign. of Shipper
                             </td>
                             <td>
                                 <asp:TextBox ID="txt_Shipper_or_Agent" runat="server" MaxLength="250" Width="342px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="81"></asp:TextBox>
                             </td>
                             
                         </tr>
                         <tr>
                             <td>
                             Executed On
                             </td>
                             <td>
                                <asp:TextBox ID="txt_Exec_on" runat="server" MaxLength="50" Width="342px"
                                           CssClass="txtbox_none_Mid_transac_Inv_No"  TabIndex="82"></asp:TextBox>
                                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txt_Exec_on"
                                              Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                              CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                              CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                              Enabled="True">
                                          </asp:MaskedEditExtender>
                                          <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_Exec_on"
                                              Format="dd/MM/yyyy" Enabled="True">
                                          </asp:CalendarExtender>
                             </td>
                             
                         </tr>
                         <tr>
                             <td>
                             Place at
                             </td>
                             <td>
                                 <asp:TextBox ID="txt_place_At" runat="server" MaxLength="250" Width="342px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="83"></asp:TextBox>
                             </td>
                             
                         </tr>
                         <tr>
                             <td>
                             Sign of Iss. Carrier or its
                             </td>
                             <td>
                                 <asp:TextBox ID="txt_sign_iss_carrier" runat="server" MaxLength="250" Width="342px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="84"></asp:TextBox>
                             </td>
                             
                         </tr>
                         <tr>
                             <td>
                              Total Collect Charges
                             </td>
                             <td>
                                 <asp:TextBox ID="txt_tot_Collect_Charges" runat="server" MaxLength="100" Width="342px"
                                           CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"  TabIndex="85"></asp:TextBox>
                             </td>
                             
                         </tr>
                     </table>
                     </div>
                 </div>
                 
                   </div>
                </div>
</div>
         <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px;">
                    <div id="innerbox_transac_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="93" onclick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="90" CommandName="s"   OnClick="btnSave_Click"/>
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" 
                                OnClientClick="return validate();" TabIndex="91" OnClick="btnUpdate_Click"/>
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="92" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Invoice?', 'AWB', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="92" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;"  OnClick="btnDelete_Click" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="94">
                        </div>
                          <div id="editbu" style="padding-top:5px;">
                             <asp:Button ID="btnrpt" runat="server" tabindex="64" Text="AWB Rpt" OnClientClick="return open_jobno();" />
                        </div>
                    </div>
                </div>

</div>
 <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3']);
            </script>
                
              </ContentTemplate>
    </asp:UpdatePanel>
     <asp:HiddenField ID="HDupdate_id" runat="server" />
    </form>

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
   
 <script language='javascript'>
       window.onload = happycode;
       function happycode() {

           document.getElementById("Admin_Master").click();
       }
       </script>
      <script type="text/javascript">
          function GetSelectedTextValue(ddlFruits) {
              var selectedText = ddlFruits.options[ddlFruits.selectedIndex].innerHTML;
              var selectedValue = ddlFruits.value;
              
              document.getElementById('txt_WT_VAL').value = selectedText;
              document.getElementById('txt_WT_VAL_Other').value = selectedText;
          }
</script>



     <script type="text/javascript">
         function open_jobno() {
             if (document.getElementById("ddljobno").value != '') {
                 if (document.getElementById("<%=ddljobno.ClientID %>").value != '') {
                     var f = document.getElementById("ddljobno").value;
                     NewWindow1('../Air_WayBill/AirWarBL_Report.aspx?jobno=' + f + '', 'List', '870', '1024', 'yes');
                     return false;
                 }
             }
         }
 </script>
    
</body>
</html>
