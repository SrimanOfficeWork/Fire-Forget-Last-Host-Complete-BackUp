<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_PackingList.aspx.cs"
    Inherits="Export_PackingList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export - Packing List</title>
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
            <div id="innerbox_MidMain_Transact_popup_new">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 130px;">
                        Packing List
                    </div>
                     <div id="verslic" style="margin-top: -5px;"></div>
                      <div id="txt_container_Transact_Main_l" style="width: 490px;">
                        <div id="tag_label_transact_Src" style="width: 110px;">
                            Exporter Name</div>
                        <div id="txtcon-m_Exchange">
                            <asp:DropDownList ID="ddlExp_name" runat="server" CssClass="listtxt_transac_src1"
                                Style="width: 370px;" TabIndex="8"  AutoPostBack="true"
                                onselectedindexchanged="ddlExp_name_SelectedIndexChanged" >
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>
       

                <div id="tag_transact_src_inner" style="width: 950px">


                    <div id="tag_Exchange_inner_lft">
                        <div id="tag_transact_lft_in1">
                            <div id="Div1" style="width: 700px; margin-top: 10px;">
                                <div id="tag_label_transact_Src">
                                    Job No
                                </div>
                                <div id="txtcon-m_transaction_Supp_code">
                                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1" AutoPostBack="True"
                                        OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src">
                                </div>
                                <div id="txtcon-m_src">
                                    <asp:Button ID="btnrpt" Text="Report" runat="server" OnClientClick="return open_jobno();" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="tag_transact_srcinner_rght" style="margin-right: 90px; margin-top: 25px;
                        width: 280px;">
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="35"
                                OnClientClick="return validate();" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                Visible="false" TabIndex="36" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="37" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'Packing List', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="11" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                            <div id="small-butt-rght">
                            </div>
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                        </div>
                    </div>
                </div>

            </div>
            <div id="innerbox_MidMain_Trans_new" style="background-image:none">
                
                <div class="content" id="page-1" style="overflow:scroll;height:430px;width:960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:425px;">
                         <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            Exporter
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtExporter" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="1" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Buyer(if Other than Consignee)
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="12" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>      
                    </div>

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="2" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                        
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                    </div>


                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="3" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                           <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="14" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       
                       
                    </div>
                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="4"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                     <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtNotify_Add3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="15"></asp:TextBox>
                        </div>
                    </div>
                <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="5"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                       <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtNotify_Add4" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="16" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                    </div>
                <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtNotify_Add5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="17"></asp:TextBox>
                        </div>
                    </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                            Consignee
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                          Pre Carriage by
                        </div>
                        <div id="txt_trans_exp_drawback">
                                                      <asp:TextBox ID="txtPre_Carriageby" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="18"></asp:TextBox>
                       
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Place of receipt by pre-carrier
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtPlace_Precarier" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="19"></asp:TextBox>
                        </div>

                       
                    </div>
               <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add1" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txt_trans_exp_drawback">
                          
                        </div>
                        <div id="magnify_area">
                        </div>
                 
                    </div>
                  <div  id="innerbox_MidMain_bot_transact" style="width:110%;height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add2" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="9"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Vessel flight No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtVessel_Flight" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="20" TabIndex="20"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        
                        <div id="tag_label_transaction_exp_jobb">
                           Port of Discharge
                        </div>
                        
                                    <div id="txt_trans_exp_drawback">
                                        <asp:TextBox ID="txtPort_Of_Discharge" runat="server" CssClass="txtbox_trans_exp_drawback"
                                         MaxLength="35" TabIndex="21" ></asp:TextBox>
                                    </div>
                    </div>
                <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="10"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           Port of loading
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtPort_Of_Loading" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="35" TabIndex="22"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Port of Destiantion
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtFinal_Destination" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="35" TabIndex="23"></asp:TextBox>
                        </div>
                        
                    </div>
                <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:40px;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add4" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="11"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                          Country Of Origin
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtCountry_Origin" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="24"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                          Final Destination
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtCountry_Destination" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="35" TabIndex="25"></asp:TextBox>
                        </div>
                    </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:40px;">
                        <div id="tag_label_transaction_exp_jobb">
                           Other Reference(s)
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txt_Other_Ref" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="100" TabIndex="26"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                             Invoice No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txt_InvoiceNo" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="30" TabIndex="27"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                             Invoice Date 
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <%--<asp:TextBox ID="txt_InvoiceDate" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="10" TabIndex="28"></asp:TextBox>--%>

                              
                                <asp:TextBox ID="txt_InvoiceDate" runat="server" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="30" TabIndex="28"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender4"
                                        runat="server" TargetControlID="txt_InvoiceDate" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txt_InvoiceDate"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="g" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txt_InvoiceDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                            </div>

                        <%--</div>--%>
                       
                      </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:40px;">
                        <div id="tag_label_transaction_exp_jobb">
                           Exporter's Ref
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txt_ExporterRef" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="100" TabIndex="29"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>

                         <div id="tag_label_transaction_exp_jobb">
                            Buyers Order No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtBuyerOrderNo" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="30" TabIndex="30"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                         <div id="tag_label_transaction_exp_jobb">
                             Order Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <%--<asp:TextBox ID="txtBuyerOrder_Date" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="10" TabIndex="31"></asp:TextBox>--%>

                                 <asp:TextBox ID="txtBuyerOrder_Date" runat="server" CssClass="txtbox_trans_exp_drawback"
                                    MaxLength="30" TabIndex="31"></asp:TextBox><asp:MaskedEditExtender ID="MaskedEditExtender1"
                                        runat="server" TargetControlID="txtBuyerOrder_Date" Mask="99/99/9999" MaskType="Date"
                                        ErrorTooltipEnabled="True" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder=""
                                        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                                        CultureTimePlaceholder="" Enabled="True">
                                    </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtBuyerOrder_Date"
                                    Format="dd/MM/yyyy" Enabled="True" OnClientShown="CheckToday">
                                </asp:CalendarExtender>
                                 <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" Display="None"
                                runat="server" ControlToValidate="txtBuyerOrder_Date" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                                ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                            </div>

                        </div>

                        </div>

                        <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:40px;">
                                   <div id="tag_label_transaction_exp_jobb">
                           Notify
                          
                        </div>
                        <div id="tag_label_transaction_iten_new1_nos_othres">
                            <asp:TextBox ID="txt_Notify2" runat="server" CssClass=" txtbox_none_Mid_transac_item_gen_decs" MaxLength="100"
                                 TabIndex="32"></asp:TextBox>
                        </div>
                        </div>
                        <div id="magnify_area">
                        </div>

                           <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:40px;">
                                   <div id="tag_label_transaction_exp_jobb">
                           Terms of Delivery & payment
                          
                        </div>
                        <div id="tag_label_transaction_iten_new1_nos_othres">
                            <asp:TextBox ID="txt_Delivery_Terms" runat="server" CssClass=" txtbox_none_Mid_transac_item_gen_decs" MaxLength="100"
                                 TabIndex="33"></asp:TextBox>
                        </div>
                        </div>

                        <div id="magnify_area"></div>

                             <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:40px;">
                                   <div id="tag_label_transaction_exp_jobb">
                           Remarks
                          
                        </div>
                        <div id="tag_label_transaction_iten_new1_nos_othres">
                            <asp:TextBox ID="txt_Remarks" runat="server" CssClass=" txtbox_none_Mid_transac_item_gen_decs" MaxLength="100"
                                 TabIndex="34"></asp:TextBox>
                        </div>
                                                  
                       <div id="tag_transac_exp_drawback_1" runat="server" style="overflow:scroll; width:930px; height:250px;">

                             <asp:GridView runat="server" ID="GV_Details" EmptyDataText="NO RECORD FOUND"  
                        AutoGenerateColumns="false"  CssClass="grid-view" ShowHeader="true" 
                        ShowHeaderWhenEmpty="true" Width="99%"   OnRowDataBound="GV_Details_RowDataBound1"  BorderStyle="Solid" BorderWidth="1px"
                         CellPadding="1" CellSpacing="1" OnRowCreated="GV_Details_RowCreated" HorizontalAlign="Left" >
                        
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" 
                            BorderWidth="1px" />
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>

                                    <asp:TemplateField HeaderText="ItemSlNo">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_ItemSlNo" runat="server" Text='<%# Bind("ITEM_SLNO") %>'
                                               Width="40px"></asp:TextBox>


                                                <%--Text='<%# Container.DataItemIndex + 1 %>'--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Marks & No" >
                                        <ItemTemplate>
                                                <asp:TextBox ID="txt_MarksNos"  runat="server" Text='<%# Bind("MARKSNOS") %>' 
                                               Width="200px" ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Goods Description" >
                                        <ItemTemplate  >
                                            <asp:TextBox ID="txt_ITEM_DESCRIPTION"  runat="server" Text='<%# Bind("ITEM_DESCRIPTION") %>' 
                                           align="left"  Width="400px"   ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Quantity" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_QUANTITY"  runat="server" Text='<%# Bind("QUANTITY") %>' 
                                              Width="50px"  ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Gross Wt" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_GROSS_WEIGHT"  runat="server" Text='<%# Bind("GROSS_WEIGHT") %>' 
                                              Width="70px"  ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="No Of Pkgs" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_NO_OF_PKGS"  runat="server" Text='<%# Bind("NO_OF_PKGS") %>' 
                                              Width="80px"  ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                        </asp:GridView>
                        </div>

                         <div id="tag_transac_exp_drawback"></div>
                        <div id="tag_transac_exp_drawback">

                         </div>
                  
                </div>
                <!-- Buttons Place Here -->

                </div></div></div>
              
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="hdn_Update_General" runat="server" />
                    <asp:HiddenField ID="hdn_Edit_TransportMode" runat="server" />
                    <asp:HiddenField ID="hdn_Jobno" runat="server" />
                    
                    <asp:HiddenField ID="HDupdate_id" runat="server" />
                    <asp:HiddenField ID="HD_Showcon" runat="server" />

                     
                    
                </div>
            </div>
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        body
        {
            font-size: 62.5%;
        }
    </style>
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

         function open_jobno() {

             if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') {

                 document.getElementById("<%=HiddenField1.ClientID %>").value = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                 if (document.getElementById("<%=HiddenField1.ClientID %>").value != '') {

                     var f = document.getElementById("<%=HiddenField1.ClientID %>").value;
                     NewWindow1('../Report/Export_PackingList_Rpt_Viewer.aspx?jobno=' + f + '', 'List', '870', '1024', 'yes');

                     //opennew_Import_report(f);
                     return false
                     //alert(f);
                 }
             }

         }
     </script>

      

</body>
</html>
