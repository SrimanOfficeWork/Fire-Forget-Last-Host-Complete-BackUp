<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bank_Reconciliation_Entry.aspx.cs"
    Inherits="Bank_Reconciliation_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
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
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
        .hideGridColumn
        {
            display: none;
        }
        #tag_transac_lft_in2
        {
            height: 25px;
            margin: auto;
            width: 370px;
            margin-left: 10px;
        }
    </style>
    <style type="text/css">
        .myGridStyle
        {
            border-collapse: collapse;
        }
        
        .myGridStyle tr th
        {
            /*color: black;*/
            border: 0.5px solid black;
            font-size: 13px;
        }
        .myGridStyle tr:nth-child(even)
        {
            background-color: white;
            font-size: 12px;
        }
        
        .myGridStyle tr:nth-child(odd)
        {
            background-color: white;
            font-size: 12px;
        }
        
        .myGridStyle td
        {
            border: 0.5px solid black;
        }
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Job_Duplicate/Imp_Job_duplicate.js" type="text/javascript"></script>
    <style type="text/css">
        /*Calendar Control CSS*/
        .cal_Theme1 .ajax__calendar_container
        {
            background-color: #DEF1F4;
            border: solid 1px #77D5F7;
        }
        
        .cal_Theme1 .ajax__calendar_header
        {
            background-color: #ffffff;
            margin-bottom: 4px;
        }
        
        .cal_Theme1 .ajax__calendar_title, .cal_Theme1 .ajax__calendar_next, .cal_Theme1 .ajax__calendar_prev
        {
            color: #004080;
            padding-top: 3px;
        }
        
        .cal_Theme1 .ajax__calendar_body
        {
            background-color: #ffffff;
            border: solid 1px #77D5F7;
        }
        
        .cal_Theme1 .ajax__calendar_dayname
        {
            text-align: center;
            font-weight: bold;
            margin-bottom: 4px;
            margin-top: 2px;
            color: #004080;
        }
        
        .cal_Theme1 .ajax__calendar_day
        {
            color: #004080;
            text-align: center;
        }
        
        .cal_Theme1 .ajax__calendar_hover .ajax__calendar_day, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_month, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_year, .cal_Theme1 .ajax__calendar_active
        {
            color: #004080;
            font-weight: bold;
            background-color: #DEF1F4;
        }
        
        
        .cal_Theme1 .ajax__calendar_today
        {
            font-weight: bold;
        }
        
        .cal_Theme1 .ajax__calendar_other, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_today, .cal_Theme1 .ajax__calendar_hover .ajax__calendar_title
        {
            color: #bbbbbb;
        }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">--%>
    <contenttemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>


           <div id="innerbox_MidMain_Trans_new" style="margin-left:0px;height:580px; margin-top:0%;width:1154px;">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="tab_page1();" id="Admin_Master"><span> Bank Reconciliation </span></a></li>
                    <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');tab_page2();"
                         runat="server" id="Exbond_Id"><span>Notes</span></a></li>

                   <div id="popupwindow_closebut_right_new">
                   <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /> 
                    </div>
                </ol>
                  
          <div class="content active" id="page-1" style="padding-top:0px;">
                   
                <div id="pop_text_area_transac_popup_inn_container_new" style="width:1070px; height:176px; margin-left:-15px;margin-top: -23px;">

                                <div id="pop_text_area_transac_popup_inn_container_left_new" style="width:530px;  height:220px;">
                                <div id="tag_transac_lft_in2" style="height:10px;" >
                                          <div id="tag_label_transaction_popup_gen">
                                          </div>
                                          <div id="txtcon-m_transaction_pop_gen1_srcic">
                                          </div>
                                </div>
                                  
                                   <div id="tag_transac_lft_in2">
                                          <div id="tag_label_transaction_popup_gen">
                                          </div>
                                          <div id="txtcon-m_transaction_pop_gen1_srcic">
                                              <span style="font-weight:bold;"><asp:Literal ID="lblfromMsg"  runat="server"></asp:Literal></span>
                                          </div>
                                </div>
                                   
                                    <div id="tag_transac_lft_in2" style="width:520px;">
                                        <div id="tag_label_transaction_popup_gen" style="width:80px;">
                                            Bank Name</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width:430px;">
                                            <asp:DropDownList ID="ddl_Bank_Name" runat="server" CssClass="txtbox_none" Width="430px" AutoPostBack="true"
                                                TabIndex="1" onselectedindexchanged="ddl_Bank_Name_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </div>
                                     
                                    </div>    
                                    <div id="tag_transac_lft_in2" style="width:520px;">
                                        <div id="tag_label_transaction_popup_gen" style="width:80px;">
                                            Fiscal Year</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width:220px;">
                                            <asp:DropDownList ID="ddlWorkingPeriod" runat="server" CssClass="txtbox_none"  TabIndex="1"  Width="210px" >
                                                <asp:ListItem Text="01-Apr-2025 - 31-Mar-2026" Value="01-Apr-2025 - 31-Mar-2026"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                        <div id="tag_label_transaction_popup_gen" style="width:60px;">
                                             Location
                                        </div>
                                          <asp:DropDownList ID="ddl_Location" runat="server" CssClass="txtbox_none" 
                                             Width="150px" TabIndex="3"  >
                                          </asp:DropDownList>
                                     
                                    </div>
                                     <%--<div id="tag_transac_lft_in2" style="width:520px;">
                                        <div id="tag_label_transaction_popup_gen" style="width:80px;">
                                            Reco From</div>
                                         <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 220px;">
                                             <asp:TextBox ID="txt_Reco_fromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                                 MaxLength="10" TabIndex="3"></asp:TextBox>
                                             <cc1:maskededitextender id="MaskedEditExtender4" runat="server" targetcontrolid="txt_Reco_fromdate"
                                                 mask="99/99/9999" messagevalidatortip="true" oninvalidcssclass="MaskedEditError"
                                                 masktype="Date" displaymoney="Left" acceptnegative="Left" errortooltipenabled="True">
                                            </cc1:maskededitextender>
                                             <cc1:calendarextender id="CalendarExtender5" runat="server" targetcontrolid="txt_Reco_fromdate"
                                                 format="dd/MM/yyyy">
                                            </cc1:calendarextender>
                                         </div>

                                        <div id="tag_label_transaction_popup_gen" style="width:60px;">
                                             Reco To
                                        </div>
                                          <asp:TextBox ID="txt_Reco_ToDate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                            MaxLength="10" TabIndex="4"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender6" runat="server" TargetControlID="txt_Reco_ToDate"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txt_Reco_ToDate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                     
                                    </div>--%>
                                     
                                    <div id="tag_transac_lft_in2" style="width:520px;">
                                        <div id="tag_label_transaction_popup_gen" style="width:80px;color:Green;">
                                            Trans. From</div>
                                         <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 90px;">
                                             <asp:TextBox ID="txt_trans_fromdate" runat="server" CssClass="txtbox_none_Mid_transac_code" Width="80px"
                                                 MaxLength="10" TabIndex="3"></asp:TextBox>
                                             <cc1:maskededitextender id="MaskedEditExtender2" runat="server" targetcontrolid="txt_trans_fromdate"
                                                 mask="99/99/9999" messagevalidatortip="true" oninvalidcssclass="MaskedEditError"
                                                 masktype="Date" displaymoney="Left" acceptnegative="Left" errortooltipenabled="True">
                                            </cc1:maskededitextender>
                                             <cc1:calendarextender id="CalendarExtender3" runat="server" targetcontrolid="txt_trans_fromdate"
                                                 format="dd/MM/yyyy">
                                            </cc1:calendarextender>
                                         </div>

                                        <div id="tag_label_transaction_popup_gen" style="width:60px; color:Green;">
                                             Trans To.
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 90px;">
                                          <asp:TextBox ID="txt_trans_todate" runat="server" CssClass="txtbox_none_Mid_transac_code" Width="80px"
                                            MaxLength="10" TabIndex="4"></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_trans_todate"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_trans_todate"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                     </div>

                                     <%--<div id="tag_label_transaction_popup_gen" style="width:55px; color:Green;">
                                             Month
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width: 90px;">
                                        <asp:DropDownList ID="ddlmonth" runat="server" CssClass="txtbox_none"  
                                            Font-Size="12px" Width="135px" TabIndex="5" >
                                        </asp:DropDownList>
                                        </div>--%>
                                    </div>
                                   
                                     
                                    <div id="tag_transac_lft_in2" style="width:520px;">
                                        <div id="tag_label_transaction_popup_gen" style="width:80px;">
                                            Status</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width:200px;">
                                            <%--<asp:DropDownList ID="ddl_Status" runat="server" CssClass="txtbox_none"  TabIndex="1" Width="150px" >
                                                <asp:ListItem Text="All" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Non Reconciliation" Value="NR"></asp:ListItem>
                                                <asp:ListItem Text="Reconciliation" Value="R"></asp:ListItem>
                                            </asp:DropDownList>--%>
                                            <span style="font-weight:bold; color:Red;"> <asp:Literal ID="Literal1" Text="Non Reconciliation"  runat="server"></asp:Literal></span>
                                        </div>

                                        <div id="tag_label_transaction_popup_gen" style="width:80px;">
                                             Trans. Type
                                        </div>
                                          <asp:DropDownList ID="ddl_Trans_Type" runat="server" CssClass="txtbox_none" 
                                             Width="90px" TabIndex="3"  >
                                             <asp:ListItem Text="Both" Value=""></asp:ListItem>
                                                <asp:ListItem Text="Payment" Value="P"></asp:ListItem>
                                                <asp:ListItem Text="Receipt" Value="R"></asp:ListItem>
                                            </asp:DropDownList>
                                    </div>
                                <div id="tag_transac_lft_in2" style="width:520px;">
                                        <div id="tag_label_transaction_popup_gen" style="width:200px;">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width:200px;">
                                            <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                                            tabindex="5"></a>
                                        </div>

                                        <div id="tag_label_transaction_popup_gen" style="width:80px;">
                                             
                                        </div>
                                     
                                    </div>
                                    
                                
                                <div id="tag_transac_lft_in2" style="width:520px;">
                                        <div id="tag_label_transaction_popup_gen" style="width:200px;margin-top: -23px;">
                                        <asp:Button ID="btn_Recon" runat="server" Text="Convert Reconciliation" onclick="btn_Recon_Click" 
                                        style="height: 25px;background: #408840;color: white;border-radius: 5px;" />
                                            </div>
                                        
                                    </div>
                                </div>
                   
                                <div id="pop_text_area_transac_popup_inn_container_rght_new"  style="width:530px; height:220px;">
                                     <div id="tag_transac_lft_in2" style="height:10px;">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                        <span style="font-weight:bold;"><asp:Literal ID="bltoMsg"  runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                    
                                    <div id="tag_transac_lft_in2">
                                        <div id="tag_label_transaction_popup_gen">
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                       <span style="font-weight:bold;"><asp:Literal ID="lbltoMsg"  runat="server"></asp:Literal></span>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_in2" style="width:520px;">
                                        <div id="tag_label_transaction_popup_gen" style="width:220px; text-align:right;">
                                            Balance as Per Book(INR): &nbsp;
                                        </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                                          <span style="font-weight:bold; color:Green;"> <asp:Literal ID="lbl_Bal_Per_Book_Amt"   runat="server"></asp:Literal></span>
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_in2" style="width:520px;">
                                        <div id="tag_label_transaction_popup_gen" style="width:220px;text-align:right;">
                                            Non Reconciliation(INR): &nbsp;
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" style="width:250px;">
                                         <span style="font-weight:bold; color:Red;"> <asp:Literal ID="lbl_Non_Recon_Amt"   runat="server"></asp:Literal></span>
                                        </div>
                                    </div>

                                    <div id="tag_transac_lft_in2" style="width:520px; display: none;">
                                        <div id="tag_label_transaction_popup_gen" style="width:220px;text-align:right;">
                                            Instruments Not in System(INR):&nbsp;
                                            
                                            </div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                         <span style="font-weight:bold; color:Maroon;"> <asp:Literal ID="lbl_Ins_not_Sys_Amt"   runat="server"></asp:Literal></span>
                                        </div>
                                         
                                    </div>
                                    <div id="tag_transac_lft_in2" style="width:520px; display: none;">
                                        <div id="tag_label_transaction_popup_gen" style="width:220px;text-align:right;">
                                            Balacne as Per Bank(INR): &nbsp;</div>
                                        <div id="txtcon-m_transaction_pop_gen1_srcic" >
                                         <span style="font-weight:bold; color:Orange;"> <asp:Literal ID="lbl_Bal_Per_Bank" runat="server"></asp:Literal></span>
                                        </div>
                                         
                                    </div>

                                    
                                </div>
                </div>
               
                <div id="tag_transac_lft_Item_maindet_Grid_area"    style="overflow:auto; height:375px; width:1140px;margin-top:-10px;margin-left:-10px; ">

                    <asp:GridView ID="gvAll" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                        BackColor="WhiteSmoke" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" OnRowCreated="gvAll_RowCreated"
                        CellPadding="1" CellSpacing="1" CssClass="myGridStyle" DataKeyNames="TRANS_ID,TRANS_NO,P_Type,TRANS_TBL" EmptyDataText="NO RECORD FOUND"
                        PageSize="5000" ShowHeaderWhenEmpty="True" Width="150%"
                        OnRowDataBound="gvAll_RowDataBound"  OnDataBound="gvAll_DataBound">

                              <RowStyle BorderWidth="0.1em" BorderColor="black" />
                              <HeaderStyle CssClass="header" BackColor="#808080" Font-Bold="True" ForeColor="White" />  
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" />
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderStyle-Font-Bold="true" HeaderStyle-Width="90px">
    <HeaderTemplate>
        Rec. Date
        <br />
        <asp:TextBox ID="txt_Header_Rec_Date" runat="server" ClientIDMode="Static"
            CssClass="txtbox_none_Mid_transac_code" Width="70px" MaxLength="10"></asp:TextBox>
        <cc1:MaskedEditExtender ID="MaskedEditExtenderHdr" runat="server" TargetControlID="txt_Header_Rec_Date"
            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
        </cc1:MaskedEditExtender>
        <cc1:CalendarExtender ID="CalendarExtenderHdr" runat="server" TargetControlID="txt_Header_Rec_Date"
            CssClass="cal_Theme1" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
        <br />
        <input type="button" value="Apply All" onclick="ApplyAllRecDate(); return false;" 
       style="background-color: #2568e1;color: white;width: 83px;font-family: inherit;border-radius: 14px;" />
    </HeaderTemplate>
    <ItemTemplate>
        <asp:TextBox ID="txt_Rec_Date" Text='<%# Bind("R_DATE") %>' runat="server" CssClass="txtbox_none_Mid_transac_code"
            Width="80px" MaxLength="10" TabIndex="4"></asp:TextBox>
        <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_Rec_Date"
            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
        </cc1:MaskedEditExtender>
        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_Rec_Date" CssClass="cal_Theme1"
            Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
    </ItemTemplate>
    <ItemStyle Width="80px" HorizontalAlign="Center" />
</asp:TemplateField>
                            <asp:TemplateField HeaderText="Trans. No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                <ItemTemplate >
                                    <asp:Literal ID="txt_trans_no" Text='<%# Bind("TRANS_NO") %>' runat="server"></asp:Literal>
                                </ItemTemplate>
                                <ItemStyle Width="80px" HorizontalAlign="Left" ForeColor="Blue"/>
                            </asp:TemplateField>

                            
                            <asp:TemplateField HeaderText="Posting Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <asp:Literal ID="txt_Posting_Date" Text='<%# Bind("POSTING_DATE") %>' runat="server"></asp:Literal>
                                </ItemTemplate>
                                <ItemStyle Width="70px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:Literal ID="txt_RP_Type" Text='<%# Bind("REC_PAY_TYPE") %>' runat="server"></asp:Literal>
                                </ItemTemplate>
                                <ItemStyle Width="50px" HorizontalAlign="Center"  ForeColor="black" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Bank Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Literal ID="txt_Bank_Name" Text='<%# Bind("BANK_NAME") %>' runat="server"></asp:Literal>
                                </ItemTemplate>
                                <ItemStyle Width="100px" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="60px">
                                <ItemTemplate>
                                    <asp:Literal ID="txt_Amt" Text='<%# Bind("AMT_INR") %>' runat="server"></asp:Literal>
                                </ItemTemplate>
                                <ItemStyle Width="60px" HorizontalAlign="Right" BackColor="#71C93F" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cus. Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                <ItemTemplate>
                                    <asp:Literal ID="txt_Cus_Name" Text='<%# Bind("CUSTOMER_NAME") %>' runat="server"></asp:Literal>
                                </ItemTemplate>
                                <ItemStyle Width="300px" HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Narration" HeaderStyle-Font-Bold="true" HeaderStyle-Width="500px">
                                <ItemTemplate>
                                    <asp:Literal ID="txt_Narration" Text='<%# Bind("NARRATION") %>' runat="server"></asp:Literal>
                                </ItemTemplate>
                                <ItemStyle Width="500px" HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                 
                 </div>
              <%--<asp:Button ID="btn_Exbond" runat="server" Text="Ex-Bond" onclick="btn_Exbond_Click" />--%>
                
               </div>
         
         <div class="content active" id="page-2" >
         <iframe  name="trans_igm" scrolling="no" id="annexureCSea_EXbond_Iframe" runat="server"></iframe>
         </div>
                </div>
               
                
                   
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
               
       
  
    <asp:HiddenField runat="server" ID="hd_error" />
    <asp:HiddenField runat="server" ID="HD_DB_Name" />
    <asp:HiddenField runat="server" ID="HD_Tr_mode" />
    <asp:HiddenField ID="hdn_button_click" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hdfTransport_mode" runat="server" ClientIDMode="Static" />
    
    </div>
    </contenttemplate>
    <%--</asp:UpdatePanel>--%>
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <%--<script type="text/javascript" src="../js/iframepopupwin.js"></script>--%>
    <script src="../js/Accounts/Acc_iframepopupwin.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../js/MaskedEditFix.js" type="text/javascript"></script>
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
        //<!--
        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;



            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");


            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }
        function checkAll(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
                            //                              row.style.backgroundColor = "#C2D69B";
                        }
                        else {
                            //                              row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
        //-->

        function win_close1() {
            window.parent.document.getElementById('interVeil').style.display = 'none';
            window.parent.adcodewindow.hide();
        }
    </script>
    <script type="text/javascript">
        function tab_page1() {
            document.getElementById('page-1').style.display = 'Block';
            document.getElementById('page-2').style.display = 'none';
        }
        function tab_page2() {

            document.getElementById('page-1').style.display = 'none';
            document.getElementById('page-2').style.display = 'Block';

            //document.getElementById("annexureCSea_EXbond_Iframe").src = "../Transaction/Ex-Bond_Details.aspx";
        }


        function ApplyAllRecDate() {
            var headerDate = document.getElementById("txt_Header_Rec_Date").value;

            if (headerDate == "") {
                alert("Please enter a date in the header box first.");
                return;
            }

            var grid = document.getElementById("<%= gvAll.ClientID %>");
            if (!grid) return;

            var rows = grid.getElementsByTagName("tr");

            for (var r = 0; r < rows.length; r++) {
                var chk = null;
                var dateBox = null;
                var inputs = rows[r].getElementsByTagName("input");

                for (var i = 0; i < inputs.length; i++) {
                    if (inputs[i].type == "checkbox" && inputs[i].id.indexOf("chk") != -1) {
                        chk = inputs[i];
                    }
                    if (inputs[i].id.indexOf("txt_Rec_Date") != -1) {
                        dateBox = inputs[i];
                    }
                }

                if (chk && chk.checked && dateBox) {
                    dateBox.value = headerDate;
                }
            }
        }
    </script>
</body>
</html>
