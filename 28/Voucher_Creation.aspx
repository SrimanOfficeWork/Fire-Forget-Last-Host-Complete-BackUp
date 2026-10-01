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
            <div id="innerbox_MidMain_Transact_popup_new">
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
                                <div id="tag_label_transaction_exp_jobb" style="width: 70px;">
                                    Customer
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 250px;">
                                  <asp:DropDownList ID="ddlCustomer_name" runat="server" CssClass="listtxt_transac_src1" 
                                        AutoPostBack="True" Width="200px"  OnSelectedIndexChanged=" ddlCustomer_name_SelectedIndexChanged" 
                                    Font-Size="12px"      
                                        TabIndex="1">
                                    </asp:DropDownList>                              
                                </div>
                               
                               <%-- <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>--%>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 90px">
                                   Department
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:TextBox ID="txt_department" runat="server" MaxLength="50" CssClass="txtbox_trans_exp_drawback"
                                        Width="100px" TabIndex="2" ></asp:TextBox>
                                    <%--<asp:Label ID="lbl_DCNo" runat="server" Visible="false"></asp:Label>--%>
                                </div>

                                  <div id="tag_label_transaction_popup_IGM2_empty">
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
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 50px">
                                    Date
                                </div>
                                <div id="txtcon-m_transaction_code">
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
                                </div>
                            
                               
                            </div>
                        </div>
                    </div>
                </div>
            </div>

           <%-- -------------------------------------N--------------------------------------------------------%>
          
            <div id="innerbox_MidMain_Trans_new" style="height:450px;">
            <ol id="toc_new">
                             
                    <li><a href="#page-1" onclick="jQuery('#form1').validationEngine('hideAll');tab_page1('0');return false;" id="IMD">
                        <span> </span></a></li>
                  
                </ol>
                <div class="content" id="page-1" style="height: 430px; width: 960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 435px;">
                     <%--<div id="innerbox_MidMain_bot_transact" style="height:200px; width:920px;font-weight :normal">   
                        <div id="tag_transact_lft_in1" style="width: 400px">
                            <div id="tag_label_transaction_exp_jobb" style="font-style:normal">
                                Transporter Name
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txt_Trans_Name" runat="server" MaxLength="300" ClientIDMode="Static"
                                    TabIndex="4" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new" ></asp:TextBox>
                            </div>
                          
                        </div>
                        <div id="tag_transac_exp_drawback" style="width: 400px">
                            <div id="tag_label_transaction_exp_jobb">
                           Importer Name
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new">
                                <asp:TextBox ID="txtImporterName" runat="server" MaxLength="400" ClientIDMode="Static"
                                    TabIndex="13" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                            </div>
                          
                        </div>
                         <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                                 Trans. Address
                             </div>
                             <div id="txt_trans_exp_drawback">
                                 <asp:TextBox ID="txt_Trans_Add1" runat="server" MaxLength="200" ClientIDMode="Static"
                                     TabIndex="5" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                             </div>
                         </div>

                           <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                                 Imp. Address
                             </div>
                             <div id="txt_trans_exp_drawback">
                                 <asp:TextBox ID="txt_Imp_Add1" runat="server" MaxLength="200" ClientIDMode="Static"
                                     TabIndex="14" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                             </div>
                         </div>

                           <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                                
                             </div>
                             <div id="txt_trans_exp_drawback">
                                 <asp:TextBox ID="txt_Trans_Add2" runat="server" MaxLength="200" ClientIDMode="Static"
                                     TabIndex="6" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                             </div>
                         </div>

                           <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                                 
                             </div>
                             <div id="txt_trans_exp_drawback">
                                 <asp:TextBox ID="txt_Imp_Add2" runat="server" MaxLength="200" ClientIDMode="Static"
                                     TabIndex="15" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                             </div>
                         </div>

                          <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                                
                             </div>
                             <div id="txt_trans_exp_drawback">
                                 <asp:TextBox ID="txt_Trans_Add3" runat="server" MaxLength="200" ClientIDMode="Static"
                                     TabIndex="7" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                             </div>
                         </div>

                           <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                                 
                             </div>
                             <div id="txt_trans_exp_drawback">
                                 <asp:TextBox ID="txt_Imp_Add3" runat="server" MaxLength="200" ClientIDMode="Static"
                                     TabIndex="16" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                             </div>
                         </div>

                          <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                                GSTIN Number
                             </div>
                             <div id="txt_trans_exp_drawback">
                                 <asp:TextBox ID="txt_Trans_Add4" runat="server" MaxLength="200" ClientIDMode="Static"
                                     TabIndex="8" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                             </div>
                         </div>

                           <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                                 
                             </div>
                             <div id="txt_trans_exp_drawback">
                                 <asp:TextBox ID="txt_Imp_Add4" runat="server" MaxLength="200" ClientIDMode="Static"
                                     TabIndex="17" CssClass=" txtbox_none_Mid_transac_pop_gen_srcic_new"></asp:TextBox>
                             </div>
                         </div>
                       



                         <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                               BE No
                             </div>
                             <div id="txt_trans_exp_drawback" style="width: 120px">
                                 <asp:TextBox ID="txt_BENo" runat="server" ClientIDMode="Static" 
                                     CssClass="txtbox_trans_exp_drawback" Width="119px"
                                     MaxLength="60" TabIndex="9"></asp:TextBox>
                             </div>
                             <div id="tag_label_transaction_popup_IGM2_empty">
                             </div>
                             <div id="tag_label_transaction_exp_jobb" style="width: 60px">
                                BEDate
                             </div>
                             <div id="txt_trans_exp_drawback" style="width: 100px">
                                 <asp:TextBox ID="txt_BEdate" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                     Width="90px" MaxLength="35" TabIndex="10"></asp:TextBox>
                                 <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txt_BEdate"
                                     Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                     MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                 </cc1:MaskedEditExtender>
                                 <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txt_BEdate"
                                     Format="dd/MM/yyyy">
                                 </cc1:CalendarExtender>
                             </div>
                         </div>

                       

                           <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                                 Remarks
                             </div>
                             <div id="txtcon-m_transaction_pop_gen1">
                            
                               <asp:TextBox ID="txtRemarks" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1"
                                     TextMode="MultiLine" MaxLength="60" TabIndex="18"></asp:TextBox>
                             </div>
                         </div>

                         <div id="tag_transac_exp_drawback" style="width: 400px">
                             <div id="tag_label_transaction_exp_jobb">
                               Assesable value
                             </div>
                             <div id="txt_trans_exp_drawback" style="width: 120px">
                                 <asp:TextBox ID="txt_Ass_Value" runat="server" ClientIDMode="Static" 
                                     CssClass="txtbox_trans_exp_drawback" Width="119px"
                                     MaxLength="60" TabIndex="11"></asp:TextBox>
                             </div>
                             <div id="tag_label_transaction_popup_IGM2_empty">
                             </div>
                             <div id="tag_label_transaction_exp_jobb" style="width: 60px">
                                Cus. Duty
                             </div>
                             <div id="txt_trans_exp_drawback" style="width: 100px">
                                 <asp:TextBox ID="txt_Customs_Duty" runat="server" ClientIDMode="Static" CssClass="txtbox_trans_exp_drawback"
                                     Width="90px" MaxLength="35" TabIndex="12"></asp:TextBox>
                                
                             </div>
                         </div>
                           
                        </div>--%>

                         <div id="innerbox_MidMain_Mid_ClientMaster_R" style="height: 190px;width: 920px;">
                        <asp:GridView ID="gvAll" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                            CssClass="grid-view" EmptyDataText="NO RECORD FOUND" OnRowCreated="gvAll_RowCreated"
                            OnRowDataBound="gvAll_RowDataBound" OnRowDeleting="gvAll_RowDeleting" OnRowEditing="gvAll_RowEditing"
                            PageSize="12" ShowFooter="True" ShowHeaderWhenEmpty="True" Width="107%" style="margin-left:0px;">
                            <AlternatingRowStyle BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                            <Columns>
                                <asp:BoundField DataField="RowNumber" HeaderText="S.No" />
                                <asp:TemplateField HeaderText="Jobno">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddl_JobNo" runat="server" Width="110px"  TabIndex="4" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Particular">
                                    <ItemTemplate>
                                      <%--  <asp:TextBox ID="txt_part" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="20"
                                            MaxLength="100" Text='<%# Bind("HSN_CODE") %>' Width="100px"></asp:TextBox>--%>
                                              <asp:TextBox ID="txt_part" runat="server" CssClass=" txtbox_trans_exp_drawback" TabIndex="5"
                                            MaxLength="150" Text='<%# Bind("Particular") %>' Width="250px"></asp:TextBox>
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
                                         <asp:TextBox ID="txtAmount" runat="server" CssClass=" txtbox_trans_exp_drawback" onchange="calculate_PC();"
                                            MaxLength="11" Width="150px" TabIndex="6"></asp:TextBox>
                                        </ItemTemplate>
                                      <%--  <HeaderStyle Font-Bold="True" Width="30px" />
                                        <ItemStyle Width="70px" HorizontalAlign="center" Font-Size="12px" />--%>
                                          <FooterTemplate>
                             <asp:TextBox ID="txtTotal" runat="server" Width="80px" style="text-align: right" TabIndex="7"></asp:TextBox>
                              <asp:Button ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" Text="Add New"  TabIndex="8"/>
                         </FooterTemplate>
                                    </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                             <div id="tag_transact_lft_in1" style="width: 400px; height:50px">
                            <div id="tag_label_transaction_exp_jobb"   style="font-size:medium">
                                Incurred
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                 <asp:RadioButtonList ID="Rd_incurred" runat="server"  RepeatDirection="Horizontal" Font-Size="Medium">
                                <asp:ListItem ID="Rd_approve" runat="server" Text="Approval" />
                                <asp:ListItem ID="Rd_unapprove" runat="server" Text="Unapproval" />
                                </asp:RadioButtonList>
                               
                            </div>
                            <div id="tag_label_transaction_exp_jobb"  style="font-size:medium">
                                Certified
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:RadioButtonList ID="Rd_Ceritified" runat="server" RepeatDirection="Horizontal" Font-Size="Medium">
                                <asp:ListItem ID="Rd_appp" runat="server" Text="Approval" />
                                <asp:ListItem ID="Rd_unappp" runat="server" Text="Unapproval" />
                                </asp:RadioButtonList>
                                
                               
                            </div>
                             <div id="tag_label_transaction_exp_jobb"  style="font-size:medium">
                                Approved
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                 <asp:RadioButtonList ID="Rd_Approved" runat="server" RepeatDirection="Horizontal" Font-Size="Medium">
                                <asp:ListItem ID="Rd_app" runat="server" Text="Approval" />
                                <asp:ListItem ID="Rd_unapp" runat="server" Text="Unapproval" />
                                </asp:RadioButtonList>
                               
                            </div>
                            <div id="tag_label_transaction_exp_jobb"  style="font-size:medium" >
                                Verified
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                 <asp:RadioButtonList ID="Rd_Verified" runat="server" RepeatDirection="Horizontal" Font-Size="Medium">
                                <asp:ListItem ID="Rd_approval" runat="server" Text="Approval" />
                                <asp:ListItem ID="Rd_unapproval" runat="server" Text="Unapproval" />
                                </asp:RadioButtonList>
                               
                            </div>
                          
                        </div>
                    </div>


                </div>
                </div>

             
              
                <div style="display: none;">
                      <asp:HiddenField ID="HD_Update_id" runat="server" />
                      <asp:HiddenField ID="hdn_job_id" runat="server" />
                      
                </div>
 
             </div>
                  

            <div id="innerbox_MidMain_bot_transact" style="height:55px;font-weight:normal;margin-top: 10;width:98%;">
             <div id="magnify_area">
                        </div>
             <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="11" onclick="btnNew_Click1" />
                        </div>
             <div id="editbu">
                                 <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" TabIndex="9"
                                    OnClientClick="return validate();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" 
                                    TabIndex="10"  />
                            </div>

                            <div id="tag_label_transaction_popup_IGM2_empty" >
                                </div>
                             <div id="editbu" style="margin-top: 7px;">
                                
                                
                            </div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Delivery Challan', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
           
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="29" OnClick="btnDelete_Click" CssClass="dlete" Style="display: none;" />
                </div>

                    <%--<div id="editbu">
                    <asp:Button ID="btnrpt" Visible="false" CssClass="generate" runat="server"  OnClientClick="open_jobno_DeliveryChallan(); return false"  TabIndex="30"/>
                    </div>--%>

                  </div>
            </div>
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8']);
            </script>
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

     <script type="text/javascript">
         function open_jobno_DeliveryChallan() {
             if (document.getElementById("ddlJobNo").value != '') {
                
                 NewWindow1('../Import_Report/Imp_DeliveryChallan_Info_Rpt.aspx?jobno=' + document.getElementById("ddlJobNo").value + '&Job_id=' + document.getElementById("hdn_job_id").value + '', 'List', '870', '1024', 'yes');
                 return false
              }
         }
     </script>
      <script type="text/javascript">
          function calculate_PC() 
     {
           
            var totalRowCount = 0;
            var rowCount = 0;
            var totalAmount = 0.00, total=0.00;
            var gridView = document.getElementById("<%=gvAll.ClientID %>");
            var rows = gridView.getElementsByTagName("tr")
            for (var i = 0; i < rows.length; i++) 
            {
                totalAmount = $("input[id*=txtAmount]")[i].value;
                total = (parseFloat(total) + parseFloat(totalAmount));
                if (!isNaN(total)) {
                    $("[id*=txtTotal]").val(total);
                }
                }
      
           
            }
</script>


</body>
</html>
