<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Voucher_Creation.aspx.cs"  Inherits="Exp_Voucher"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Voucher Creation</title>
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
    <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>

       
    <style type="text/css">
    
    .ListControl input[type=radio] + label  
{
   display      :table-cell;
    width            : 7.5em;
    height           : 5em;
    line-height      : 0em;  
    text-align:left;   
}

    .ListControlWidth input[type=radio] + label  
{
   display      :table-cell;
    width            : 10em;
    height           : 5em;
    line-height      : 0em;  
    text-align:left;   
}

    </style>

    <style type="text/css">
    .txtbox_none_Mid_transac_item_other_rmarks_new1_LC{
color:#2b2b2b;
font-family:Arial,Helvetica,sans-serif;
font-size:14px;

margin-top:2px;
width:885px;
max-width:885px;
height:350px;
max-height:350px;
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
	overflow:auto;
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
            <div id="innerbox_MidMain_Transact_popup_new" style="height:100px">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                     Voucher Creation
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 965px">
                    <div id="tag_Exchange_inner_lft" style="width: 665px">
                        <div id="tag_transact_lft_in1">
                            <div id="Div1" style="width: 950px; margin-top: 10px;">
                               <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 90px">
                                   Voucher No
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_voucherno" runat="server" MaxLength="17" onkeyup="autotab(this);" Width="100px"
                            ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                            CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="1"></asp:TextBox>
                                    <%--<asp:Label ID="lbl_DCNo" runat="server" Visible="false"></asp:Label>--%>
                                </div>

                                  <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_exp_jobb" style="width: 70px;">
                                    Customer
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 200px;">
                                  <asp:DropDownList ID="ddlCustomer_name" runat="server" CssClass="listtxt_transac_src1" 
                                        AutoPostBack="True" Width="200px"  OnSelectedIndexChanged=" ddlCustomer_name_SelectedIndexChanged" 
                                    Font-Size="12px"      
                                        TabIndex="2">
                                    </asp:DropDownList>                              
                                </div>
                               
                                <%--<div id="tag_label_transaction_popup_IGM2_empty">
                                </div>--%>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 90px">
                                   Department
                                </div>
                                <div id="txtcon-m_transaction_code">
                                   <%-- <asp:TextBox ID="txt_department" runat="server" MaxLength="50" CssClass="txtbox_trans_exp_drawback"
                                        Width="100px" TabIndex="2" ></asp:TextBox>--%>
                                    <asp:DropDownList ID="ddl_Department" runat="server" CssClass="listtxt_transac_src1"
                                        Width="100px" Font-Size="12px" TabIndex="3">
                                        <asp:ListItem Text ="" Value=""></asp:ListItem>
                                    <asp:ListItem Text ="SFD" Value="SFD"></asp:ListItem>
                                    <asp:ListItem Text ="AFD" Value="AFD"></asp:ListItem>
                                    <asp:ListItem Text ="BLR" Value="BLR"></asp:ListItem>
                                    <asp:ListItem Text ="HOSUR" Value="HOSUR"></asp:ListItem>
                                    <asp:ListItem Text ="CBE" Value="CBE"></asp:ListItem>
                                    </asp:DropDownList>
                                    <%--<asp:Label ID="lbl_DCNo" runat="server" Visible="false"></asp:Label>--%>
                                </div>

                                  <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                    <div id="tag_label_transaction_exp_jobb" style="width:70px;">
                                  Staff Name
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 200px;">
                                    <asp:DropDownList ID="ddlStaff_name" runat="server" CssClass="listtxt_transac_src1" AutoPostBack="True"
                                        Width="100px" Font-Size="12px" TabIndex="4" OnSelectedIndexChanged="ddlStaff_name_SelectedIndexChanged" >
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="S.BASKAR" Value="S.BASKAR"></asp:ListItem>
                                        <asp:ListItem Text="A.BALAMURUGAN" Value="A.BALAMURUGAN"></asp:ListItem>
                                        <asp:ListItem Text="M.DEVENDRAN" Value="M.DEVENDRAN"></asp:ListItem>
                                        <asp:ListItem Text="GOPALAKRISHNAND" Value="GOPALAKRISHNAND"></asp:ListItem>
                                        <asp:ListItem Text="D.KARTHICK" Value="D.KARTHICK"></asp:ListItem>
                                        <asp:ListItem Text="N.GOKULAKRISHNAN" Value="N.GOKULAKRISHNAN"></asp:ListItem>
                                        <asp:ListItem Text="MY.LAKSHATHI PRABHU" Value="MY.LAKSHATHI PRABHU"></asp:ListItem>
                                        <asp:ListItem Text="A.B.MANIVANNAN" Value="A.B.MANIVANNAN"></asp:ListItem>
                                        <asp:ListItem Text="S.SHARMIL KUMAR" Value="S.SHARMIL KUMAR"></asp:ListItem>
                                        <asp:ListItem Text="S.SEENUVASAN" Value="S.SEENUVASAN"></asp:ListItem>
                                        <asp:ListItem Text="M.BABU" Value="M.BABU"></asp:ListItem>
                                        <asp:ListItem Text="N.RAGHU PRASAD(KMPT)" Value="N.RAGHU PRASAD(KMPT)"></asp:ListItem>
                                        <asp:ListItem Text="R.MURUGESA PANIDIAN(KMPT)" Value="R.MURUGESA PANIDIAN(KMPT)"></asp:ListItem>
                                        <asp:ListItem Text="N.PARGUNAN" Value="N.PARGUNAN"></asp:ListItem>
                                        <asp:ListItem Text="Murugesapandian" Value="Murugesapandian"></asp:ListItem>
                                        <asp:ListItem Text="Ravi" Value="Ravi"></asp:ListItem>
                                        <asp:ListItem Text="Shirish" Value="Shirish"></asp:ListItem>
                                       
                                    </asp:DropDownList>
                                </div>
                          <%--  <div id="tag_label_transaction_exp_jobb" style="width: 60px" >
                            DC Date
                            </div>
                            
                            <div id="txt_trans_exp_drawback" style="width:100px">
                                <asp:TextBox ID="txt_Date" runat="server" ClientIDMode="Static" 
                                    CssClass="validate[required] txtbox_trans_exp_drawback" Width="90px"
                                    MaxLength="35" TabIndex="3"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Date"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </div>--%>

                             <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 90px">
                                    Date
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_Date" runat="server" ClientIDMode="Static" 
                                    CssClass="validate[required] txtbox_trans_exp_drawback" Width="90px"
                                    MaxLength="35" TabIndex="5"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txt_Date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_Date"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                </div>
                            
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           <%-- -------------------------------------N--------------------------------------------------------%>
          
            <div id="innerbox_MidMain_Trans_new" style="height:450px;">
            <ol id="toc_new">
                             
                <%--    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');return false;" id="IMD"></li>--%>
                       <%-- <span> </span></a>--%>
                      
                  
                </ol>
                <div class="content" id="page-1" style="height: 430px; width: 960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 435px;">
                         <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height: 190px;width: 920px;">
                        
                        <asp:GridView ID="gv" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" OnRowCreated="gv_RowCreated" DataKeyNames="Job_no"
                            OnRowDataBound="gv_RowDataBound" OnRowDeleting="gv_RowDeleting" OnRowEditing="gv_RowEditing"
                            PageSize="12" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="107%" style="margin-left:0px;" >
                            <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                          <%--  <RowStyle BorderWidth="0.1em" BorderColor="black" Height="8px" /> --%>
                            <Columns>
                                <%--<asp:BoundField DataField="RowNumber" HeaderText="S.No" />--%>
                          <%--       <asp:BoundField  HeaderText="S. No" HeaderStyle-Width="180px">
                                            <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="180px" />
                                        </asp:BoundField>--%>
                                  <%--      <asp:TemplateField HeaderText="ch_inv" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                       <ItemTemplate>
                                           
                                           <asp:CheckBox ID="chk_inv" runat="server" HeaderText="SI.No" Width="20px" />
                                                  
                                       </ItemTemplate>
                                         <ItemStyle Width="20px" />
                                   </asp:TemplateField>--%>   

                                 <%--  <asp:TemplateField  HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                       <ItemTemplate>
                                           <asp:CheckBox ID="chk_inv" runat="server"  Width="20px" Checked="true"/>      
                                           <asp:CheckBox ID="chk_inv" runat="server" HeaderText="ch_inv"   Width="20px" 
                                         Checked='<%#bool.Parse(Eval("Voucher_check").ToString())%>' />
                                            
                                       </ItemTemplate>
                                         <ItemStyle Width="20px" />
                                   </asp:TemplateField>--%>
                                   <asp:TemplateField  HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                       <ItemTemplate>
                                           
                                        <asp:CheckBox ID="chk_inv" runat="server"   Width="20px" 
                                         Checked='<%#bool.Parse(Eval("Voucher_check").ToString())%>' TabIndex="6" />
                                                  
                                       </ItemTemplate>
                                         <ItemStyle Width="20px" />
                                   </asp:TemplateField>

                                   <asp:BoundField DataField="RowNumber" HeaderText="S.No" HeaderStyle-Font-Bold="true" ItemStyle-Width="20px" HeaderStyle-Width="20px" />
                                <asp:TemplateField HeaderText="Jobno">
                                    <ItemTemplate>
                                         <asp:TextBox ID="txtjobno" CssClass="txtbox_none_Mid_transac_Inv_No"  
                                                    runat="server" Height="20px" Width="140px" Font-Size="12px" Text='<%# Bind("Job_no") %>' ClientIDMode="Static" AutoPostBack="false" ></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ChargeName">
                                    <ItemTemplate>
                                      <asp:TextBox ID="txtch_name"  CssClass="underlined"   Text='<%# Bind("Charge_Name") %>' runat="server"                                       
                                            Height="20px" Width="212px" Font-Size="12px"  TabIndex="8"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Particular">
                                    <ItemTemplate>
                                      <%--  <asp:TextBox ID="txt_part" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="20"
                                            MaxLength="100" Text='<%# Bind("HSN_CODE") %>' Width="100px"></asp:TextBox>--%>
                                              <asp:TextBox ID="txt_part" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="9"
                                            MaxLength="150" Text='<%# Bind("Particular") %>' Width="110px"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               <%-- <asp:TemplateField HeaderText="Amount">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtAmount" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                            MaxLength="11" Width="150px"></asp:TextBox>
                                             <asp:DropDownList ID="ddl_ContainerNo" runat="server" Width="150px"  TabIndex="21">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New"  TabIndex="27"/>
                                    </FooterTemplate>
                                </asp:TemplateField>--%>
                                  <asp:TemplateField HeaderText="Amount">
                                        <ItemTemplate>
                                        <%-- <asp:TextBox ID="txtAmount" runat="server" CssClass=" txtbox_trans_exp_drawback" onchange="calculate_PC();"
                                            MaxLength="11" Width="150px" TabIndex="6"></asp:TextBox>--%>
                                            <asp:TextBox ID="txtAmount" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                                onchange="Tax_Cal();" MaxLength="11" Width="150px" TabIndex="10" onblur="extractNumber(this,3,false);"
                                                onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                Style="text-align: right"></asp:TextBox>
                                        </ItemTemplate>
                                      <%--  <HeaderStyle Font-Bold="True" Width="30px" />
                                        <ItemStyle Width="70px" HorizontalAlign="center" Font-Size="12px" />--%>
                                          <FooterTemplate>
                             <%--<asp:TextBox ID="txtTotal" runat="server" Width="80px" style="text-align: right" TabIndex="7"></asp:TextBox>--%>
                              <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New"  TabIndex="11"/>
                         </FooterTemplate>
                                    </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                             <div id="tag_transact_lft_in1" style="width: 400px; height:50px">
                            <div id="tag_label_transaction_exp_jobb"    style="font-size:medium">
                                 <asp:Label ID="Lb_Incurred" runat="server" Text="Incurred"></asp:Label>
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                 <asp:RadioButtonList ID="Rd_incurred" runat="server"  RepeatDirection="Horizontal" Font-Size="Medium">
                                <asp:ListItem ID="Rd_approve" runat="server" Text="Approval" />
                                <asp:ListItem ID="Rd_unapprove" runat="server" Text="Unapproval" />
                                </asp:RadioButtonList>
                               
                            </div>
                           <div id="tag_label_transaction_exp_jobb"  style="font-size:medium"  >
                               <asp:Label ID="Lb_Certified" runat="server" Text="Certified"></asp:Label>
                                
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:RadioButtonList ID="Rd_Ceritified" runat="server" RepeatDirection="Horizontal" Font-Size="Medium">
                                <asp:ListItem ID="Rd_appp" runat="server" Text="Approval" />
                                <asp:ListItem ID="Rd_unappp" runat="server" Text="Unapproval" />
                                </asp:RadioButtonList>
                                
                               
                            </div>
                             <div id="tag_label_transaction_exp_jobb"  style="font-size:medium">
                              <asp:Label ID="Lb_Approved" runat="server" Text="Approved"></asp:Label>
                                
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                 <asp:RadioButtonList ID="Rd_Approved" runat="server" RepeatDirection="Horizontal" Font-Size="Medium">
                                <asp:ListItem ID="Rd_app" runat="server" Text="Approval" />
                                <asp:ListItem ID="Rd_unapp" runat="server" Text="Unapproval" />
                                </asp:RadioButtonList>
                               
                            </div>
                            <div id="tag_label_transaction_exp_jobb"  style="font-size:medium">
                                <asp:Label ID="Lb_Verified" runat="server" Text="Verified"></asp:Label> 
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                 <asp:RadioButtonList ID="Rd_Verified" runat="server" RepeatDirection="Horizontal" Font-Size="Medium">
                                <asp:ListItem ID="Rd_approval" runat="server" Text="Approval" />
                                <asp:ListItem ID="Rd_unapproval" runat="server" Text="Unapproval" />
                                </asp:RadioButtonList>
                               
                            </div>
                          
                        </div>
                   

             
              
                <div style="display: none;">
                      <asp:HiddenField ID="HD_Update_id" runat="server" />
                      <asp:HiddenField ID="hdn_job_id" runat="server" />
                      <asp:HiddenField ID="Hdn_SUB_ID" runat="server" />
                       <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
 
             </div>
             <div id="tag_transact_srcinner_rght">
               <div id="tag_transact_rght_in1">
                            <div id="txt_container_Transact_Main_l" style="width: 250px;">
                               <div id="tag_label_transact_Src" style="width: 90px; font-weight: bold; color: Green;">
                                   Grand Total
                               </div>
                               <div id="txtcon-m_Exchange" style="width: 120px">
                                   <asp:TextBox ID="txt_grand_total" runat="server" Font-Bold="true" MaxLength="17"
                                       Width="110px" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);"
                                       onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="txtbox_none_Mid_transac_Inv_No"
                                       TabIndex="12"></asp:TextBox>
                               </div>
                           </div>
                        </div>
                  </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_bot_transact" style="height:55px;font-weight:normal;margin-top: 10;width:98%;">
             <div id="magnify_area">
                        </div>
             <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="15" onclick="btnNew_Click1" />
                        </div>
             <div id="editbu">
                                 <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="13"
                                    OnClientClick="return validate();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" 
                                    TabIndex="14"  />
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty" >
                                </div>
                             <div id="editbu" style="margin-top: 7px;">
                                
                                
                            </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="16" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Delivery Challan', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
           
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="17" OnClick="btnDelete_Click" CssClass="dlete" Style="display: none;" />
                </div>

                    <%--<div id="editbu">
                    <asp:Button ID="btnrpt" Visible="false" CssClass="generate" runat="server"  OnClientClick="open_jobno_DeliveryChallan(); return false"  TabIndex="30"/>
                    </div>--%>
                       <div id="editbu">
                        <asp:Button ID="btn_DocsUpload" runat="server" Text="Upload Doc" Height="30px" Width="88px"
                            Visible="false" OnClick="btn_DocsUpload_Click" />
                    </div>
                  </div>
            </div>
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
            </script>
            </a>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>

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
    <script src="../js/Import_Jscript/Import_Item.js" type="text/javascript"></script>

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
<%--      <script type="text/javascript">
          function calculate_PC() 
     {
           alert('a');
            var totalRowCount = 0;
            var rowCount = 0;
            var totalAmount = 0.00, total=0.00;
            var gridView = document.getElementById("<%=gvAll.ClientID %>");
            var rows = gridView.getElementsByTagName("tr")
         
            for (var i = 0; i < rows.length; i++) {
               $("#<%=gvAll.ClientID%> input[id*='chk_inv']:checkbox").each(function (index) 
               {
             if ($(this).is(':checked')) 
             {
                totalAmount = $("input[id*=txtAmount]")[i].value;
                total = (parseFloat(total) + parseFloat(totalAmount));
                if (!isNaN(total)) {
                    $("[id*=txt_grand_total]").val(total);
                }
                }
      }
           
           }
</script>--%>

  <script type="text/javascript">

      function Tax_Cal() {
//          alert('a');
          var txtamt = $("[id*=txtAmount]")
          var Tot_L_O = 0;
          var counter = 0;
          var Tot_Amt = 0;

          $("#<%=gv.ClientID%> input[id*='chk_inv']:checkbox").each(function (index) {
              //alert("Entered");
              if ($(this).is(':checked')) {
                 // alert("T");
                  //-----------------------------------------------------------------------------------------

                  if (txtamt[index].value != '') {

                      Tot_Amt += parseFloat(txtamt[index].value);

                  }
                  //-----------------------------------------------------------------------------------------

                  counter++;
              }
          });

//          $('#txt_total_amt').val(Tot_Amt.toFixed(2));
//          //$('#txtnon_tax_amt').val(sum_N.toFixed(2));
//          $('#txttax_amt').val(Tot_L_O.toFixed(2));
          document.getElementById("txt_grand_total").value = Math.round((parseFloat(Tot_Amt.toFixed(2))).toFixed(2));

          }

     </script>
 <script type="text/javascript">
          $(document).ready(function () {
            $('[id*=chk_inv]').focus(function () {
             Tax_Cal();
             //calculate_PC();

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
          $('[id*=txtAmount]').focus(function () {

             Tax_Cal();
          });
          $('[id*=txtAmount]').change(function () {
              Tax_Cal();
          });
          $('[id*=txtAmount]').keyup(function () {

            Tax_Cal();
          });
          $('[id*=txtAmount]').keydown(function () {

           Tax_Cal();

          });
   });
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
   


    window.addEventListener("load", function staffnameload() {

        var a = document.getElementById("ddlStaff_name");
       

        var val = '<%= Session["COMPANY_ID"].ToString() %>';

        //console.log(val);
        if (val == 480) {

            
            a.options[1].style.display = "block";
            a.options[2].style.display = "block";
            a.options[3].style.display = "block";
            a.options[4].style.display = "block";
            a.options[5].style.display = "block";
            a.options[6].style.display = "block";
            a.options[7].style.display = "block";
            a.options[8].style.display = "block";
            a.options[9].style.display = "block";
            a.options[10].style.display = "block";
            a.options[11].style.display = "block";
            a.options[12].style.display = "block";
            a.options[13].style.display = "block";
            a.options[14].style.display = "block";
            a.options[15].style.display = "none";
            a.options[16].style.display = "none";
            a.options[17].style.display = "none";
        }
        else {

            a.options[1].style.display = "none";
            a.options[2].style.display = "none";
            a.options[3].style.display = "none";
            a.options[4].style.display = "none";
            a.options[5].style.display = "none";
            a.options[6].style.display = "none";
            a.options[7].style.display = "none";
            a.options[8].style.display = "none";
            a.options[9].style.display = "none";
            a.options[10].style.display = "none";
            a.options[11].style.display = "none";
            a.options[12].style.display = "none";
            a.options[13].style.display = "none";
            a.options[14].style.display = "none";
            a.options[15].style.display = "block";
            a.options[16].style.display = "block";
            a.options[17].style.display = "block";
        }
    }, false);


</script>
 
<script type="text/javascript">

    $(function () {
        $("[id*=txtjobno]").autocomplete({
            source: function (request, response) {
                var field = $(this.element).attr('id');
                var TempddlCustomer = document.getElementById("<%=ddlCustomer_name.ClientID %>").value;
                
                $.ajax({
                    url: "../Export_Report/Voucher_Creation.aspx/LoadJob",
                    data: "{ 'mail': '" + request.term + "','TempddlCustomer': '" + TempddlCustomer + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            if (field == 'txtjobno') {
                                jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Jobno', 'error', 'topRight', true);

                            }

                        }
                        else {

                            jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);

                            var result = data.d;

                            var stringsearch = "-", str = result;

                            for (var i = count = 0; i < str.length; count += +(stringsearch === str[i++]));

                            if (i == 1) {
                                if (field == 'txtjobno') {
                                    $('#txtjobno').val(result);
                                }


                            }
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        ////alert(textStatus);
                    }
                });
            },
            minLength: 1

        });
        return false;
        scroll: true;
    });


             

           

</script>  
</body>
</html>
