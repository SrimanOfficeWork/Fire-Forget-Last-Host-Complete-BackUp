<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_ManualBE.aspx.cs" Inherits="Transaction_Import_ManualBE" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import - ManualBE</title>
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


    <style type="text/css" >
 .print_btn{
	background:url('../images/print_Butt.png') no-repeat;
	width:101px;
	height: 30px;
	text-indent:-9999px;
	overflow:hidden;
	text-transform:uppercase;
	border:none;
	cursor:pointer;
}

.print_btn:hover{
	background-position:left bottom;
}
 </style>

 <style>
 .send_btn{
	
	background:url('images/but_mid.png') repeat-x;
	/*min-width:80px;*/
	width:80px;
	height: 28px;
	text-indent:inherit;
	overflow:hidden;
	border: #999999 solid thin;
 -moz-border-radius-topleft: 6px;
 -moz-border-radius-topright: 6px;
 -moz-border-radius-bottomleft: 6px;
 -moz-border-radius-bottomright: 6px;
  -webkit-border-top-left-radius: 6px;
 -webkit-border-top-right-radius: 6px;
 -webkit-border-bottom-left-radius: 6px;
 -webkit-border-bottom-right-radius: 6px;
	border-top-left-radius: 6px;
	border-top-right-radius: 6px;
	border-bottom-left-radius: 6px;
	border-bottom-right-radius: 6px;
	cursor:pointer;
	font-family:Arial, Helvetica, sans-serif;
	font-size:12px;
	font-weight:bold;
	color:#000000;
	text-shadow:2px 2px #ffffff;
	margin-top:2px
}

.send_btn:hover{
	background-position:left bottom;
	
	.generatelcd{
	
	width:101px;
	height: 30px;
	text-indent:-9999px;
	overflow:hidden;
	text-transform:uppercase;
	border:none;
	cursor:pointer;
}
}
 </style>
   <style type="text/css">
         .left_rht_bot_top
        {
            font-family:Arial,Helvetica,sans-serif;
font-size:14px;
margin-top:1px;
margin-left:2px;
border: #c8c8c8 solid thin;
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
        }
        .lbl_text_newcss
        {
            color: #232323;
   
    font-family: Arial,Helvetica,sans-serif;
    font-size: 13px;
    height: 15px;
    line-height: 20px;
            border-style:none;
            border:0px;
        }

    </style>


  
 
     <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>



    
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

            <div id="innerbox_MidMain_Transact_popup_new" style="height:95px;">
                <div id="tag_srcinner1_new">
                    <div id="Div1">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                        Import-Manual BE
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>
                <div id="tag_transact_src_inner" style="width:960px">
                <div id="tag_Exchange_inner_lft">
                    <div id="tag_transact_lft_in1">
                        <div id="Div1" style="width:700px;margin-top:10px;">
                            <div id="tag_label_transact_Src">
                                Job No
                            </div>
                            
                            <div id="txtcon-m_transaction_Supp_code">
                                
                                  <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="validate[required] list_annuxrec_air2"
                                            AutoPostBack="True" 
                                            onselectedindexchanged="ddlJobNo_SelectedIndexChanged" 
                                            >
                                        </asp:DropDownList> </div>
                            <div id="tag_label_transact_Src">
                               Date
                            </div>
                            
                            <div id="tag_label_transact_Src">
                                     <asp:TextBox ID="txt_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new" Width="100px"
                                MaxLength="10" TabIndex="3" ClientIDMode="Static"></asp:TextBox>
                           <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txt_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_Date"
                                 Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                            </div>
  

                              <div id="tag_label_transact_Src">
                              
                            </div>
                           
                            <div id="txtcon-m_src">
                                

                            </div>
                            
                        </div>
                    </div>
                   
                </div>
                  


                <div id="tag_transact_srcinner_rght" runat="server" style="margin-right:90px;margin-top: 25px;
    width: 280px;">

  

                  <div id="editbu">
               
                                 <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click1" TabIndex="13"
                                    OnClientClick="return validate();" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" Visible="false"
                                    TabIndex="13" OnClientClick="return validate();" />
                            </div>
                    <div id="editbu">
                    
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="11" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'NFORM MASTER', function(r) {
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

                                 <asp:Button ID="btnprint" runat="server" TabIndex="11" OnClientClick="open_jobno(); return false" CssClass="print_btn" />

                    </div>
                              
                    </div>
                  
                </div>
            </div>
                  
                    
            <div id="innerbox_MidMain_Trans_new" style="background-image:none;">
                
                <div class="content" id="page-1" style="height:430px;width:960px;overflow:auto;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:425px; ">
                         <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            Importer
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtImporter" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            IncomeTaxNo
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtIncometax" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>  
                    </div>

                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAddress1" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                        PriorEntryStamp
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtPriorStamp" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                    </div>


                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                          <asp:TextBox ID="txtAddress2" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="12" CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_exp_jobb">
                         VesselName
                        </div>
                           <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtVesselname" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                    </div>


                        <div id="tag_transac_exp_drawback">
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtAddress3" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Line No
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtLineNo" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                        </div>

                        <div id="tag_transac_exp_drawback">
                            <div id="tag_label_transaction_exp_jobb">
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtAddress4" runat="server" ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_pop_gen"
                                    MaxLength="35" TabIndex="13"></asp:TextBox>
                            </div>
                            <div id="magnify_area">
                            </div>
                            <div id="tag_label_transaction_exp_jobb">
                                Port Of Shipment
                            </div>
                            <div id="txtcon-m_transaction_pop_gen1">
                                <asp:TextBox ID="txtPortofShipment" runat="server" MaxLength="35" ClientIDMode="Static"
                                    TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                            </div>
                        </div>

<div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtAddress5" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           Import Dept SlNo
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtImportDeptSlno" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                    </div>

                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0; width:94%;">
                        <div id="tag_label_transaction_exp_jobb">
                            Supplier
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="txtcon_transac_checkbox">
                                            <asp:CheckBox ID="chkSupplier" runat="server" Checked="false" onclick="chkchange()"/>                                              
                                        </div>
                     
                        <div id="tag_label_transaction_exp_jobb" style="padding-left:5px;">
                         RotationNo & Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                                                      <asp:TextBox ID="txtRotationNo" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback" MaxLength="35" TabIndex="13"></asp:TextBox>
                       
                        </div>
                        <div id="magnify_area" style="width:10px" >
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:80px;" >
                            AWBL No
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtAWBLNo" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_trans_exp_drawback"  MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>

                       
                    </div>
<div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0; width:94%;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add1" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Country Consignment
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtCountry" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                Onkeypress="return num1(event)" MaxLength="10" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area" style="width:10px">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:80px;">
                            AWBL Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtAWBLDate" runat="server" CssClass="validate[required] txtbox_trans_exp_drawback"
                                Onkeypress="return num1(event)" MaxLength="10" TabIndex="6"></asp:TextBox>
                        </div>
                    </div>
            <div  id="innerbox_MidMain_bot_transact" style="width:110%;height:25px;font-weight:normal;margin-top: 0; width:94%;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add2" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtPort_Of_Discharge" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                MaxLength="10" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area" style="width:10px">
                        </div>
                        
                        <div id="tag_label_transaction_exp_jobb" style="width:80px;">
                          HAWB No
                        </div>
                        
                                    <div id="txt_trans_exp_drawback" >
                                        <asp:TextBox ID="txtHAWBNo" runat="server" CssClass="txtbox_trans_exp_drawback"
                                         MaxLength="300" TabIndex="22" ></asp:TextBox>
                                    </div>
                    </div>
<div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0; width:94%;">
                        <div id="tag_label_transaction_exp_jobb">
                           
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtConsignee_Add3" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           Country Origin & code
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtCountryOrigin" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="10" TabIndex="6"></asp:TextBox>
                        </div>
                        <div id="magnify_area" style="width:10px">
                        </div>
                        <div id="tag_label_transaction_exp_jobb" style="width:80px;">
                            HAWB Date
                        </div>
                        <div id="txt_trans_exp_drawback">
                            <asp:TextBox ID="txtHAWBDate" runat="server" CssClass=" txtbox_trans_exp_drawback"
                                 MaxLength="10" TabIndex="6"></asp:TextBox>
                        </div>                        
                    </div>


                    <div id="innerbox_MidMain_bot_transact" style="height:25px;font-weight:normal;margin-top: 0;height:40px;  width:94%;">
                        <div id="tag_label_transaction_exp_jobb">
                           Duty Forgone
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtDutyforgone" runat="server" ClientIDMode="Static" 
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="txtcon_transac_checkbox">
                                            <asp:CheckBox ID="chkduty" runat="server" Checked="false" onclick="chkduty1()"/>                                              
                                        </div>
                        <br />                      
                    </div>

                  

                        <div id="tag_transac_exp_drawback_1" runat="server" style="overflow:hidden; width:930px; height:250px;">

                        <asp:GridView runat="server" ID="GV_Details" EmptyDataText="NO RECORD FOUND"  
                        AutoGenerateColumns="false"  CssClass="grid-view" ShowHeader="true" OnPageIndexChanging="GV_Details_PageIndexChanging"
                        ShowHeaderWhenEmpty="true" Width="250%"   OnRowDataBound="GV_Details_RowDataBound1"  BorderStyle="Solid" BorderWidth="1px"
                         CellPadding="1" CellSpacing="1" OnRowCreated="GV_Details_RowCreated" HorizontalAlign="Left" AllowSorting="true" DataKeyNames="Sl_No" >
                        
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" CssClass="column_style_right" 
                            BorderWidth="1px" />
                             <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>

                                    <asp:TemplateField HeaderText="No & Description" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNumbers_Desc"  runat="server" Text='<%# Bind("Numbers_Desc") %>' OnTextChanged="TextBox_TextChanged"
                                               ></asp:TextBox>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Sl_No") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Marks&Numbers" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMarks_Numbers"  runat="server" Text='<%# Bind("Marks_Numbers") %>' OnTextChanged="TextBox_TextChanged"
                                               ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="SerialNo" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtItem_Slno" runat="server" Text='<%# Bind("Item_Slno") %>' OnTextChanged="TextBox_TextChanged"
                                                ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Unit Code" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtUnit_Code" runat="server" Text='<%# Bind("Unit_Code") %>' OnTextChanged="TextBox_TextChanged"
                                                ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Weight" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtWeight" runat="server" Text='<%# Bind("Weight") %>' OnTextChanged="TextBox_TextChanged"
                                                ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Goods Description" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGoods_Description" runat="server" Text='<%# Bind("Goods_Description") %>' OnTextChanged="TextBox_TextChanged"
                                               ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="CTH No&Notn No" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCTH_No_Notn_no" runat="server" Text='<%# Bind("CTH_No_Notn_no") %>' OnTextChanged="TextBox_TextChanged"
                                               ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Duty Code" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtDuty_Code" runat="server" Text='<%# Bind("Duty_Code") %>' OnTextChanged="TextBox_TextChanged"
                                               ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Assablevalue" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtAssablevalue" runat="server" Text='<%# Bind("Assablevalue") %>' OnTextChanged="TextBox_TextChanged"
                                              ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="CTH Rate" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCTH_Rate" runat="server" Text='<%# Bind("CTH_Rate") %>' OnTextChanged="TextBox_TextChanged"
                                               ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="CTH AMT" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCTH_AMT" runat="server" Text='<%# Bind("CTH_AMT") %>' OnTextChanged="TextBox_TextChanged"
                                               ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="CETH_Notn" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCETH_Not" runat="server" Text='<%# Bind("CETH_Not") %>' OnTextChanged="TextBox_TextChanged"
                                               ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Col9 + 11" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCol9_and_11" runat="server" Text='<%# Bind("Col9_and_11") %>' OnTextChanged="TextBox_TextChanged"
                                                ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField HeaderText="CETH_Rate" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCETH_Rate" runat="server" Text='<%# Bind("CETH_Rate") %>' OnTextChanged="TextBox_TextChanged"
                                               ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="CETH Amt" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtCETH_Amt" runat="server" Text='<%# Bind("CETH_Amt") %>' OnTextChanged="TextBox_TextChanged"
                                                ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Total Duty" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTotal_Duty"   runat="server" Text='<%# Bind("Total_Duty") %>' OnTextChanged="TextBox_TextChanged"
                                                ></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                              
                              </Columns>
                        </asp:GridView>
                        </div>

                        <div id="tag_transac_exp_drawback"></div>


                        <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            GrossWeight
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtGrossWeight" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        
                                        <div id="tag_label_transaction_popup_trans_cth_label">
                                           Total No of Pkgs in Words
                                        </div>
                       
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtTotalPkgs" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>                                         
                    </div>

                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                            AgencyCommission
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAgencyCommission" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Miscellaneous Charges
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtMiscellaneousCharges" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>                                          
                    </div>
                     <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                           Misc Currency
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtMiscCurrency" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Invoice Terms FOB/CF/CI/CIF
                        </div>
                    <div id="m_transaction_pop_gen1">
                         <asp:TextBox ID="txtInvoiceTerms" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>                                          
                    </div>


                            <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                          Total Value
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtTotalValue" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label">
                            Landing Charges
                        </div>
                    <div id="m_transaction_pop_gen1">
                         <asp:TextBox ID="txtLandingCharges" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>                                                            
                    </div>

                    <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                          Duty Value
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtDutyValue" runat="server" MaxLength="35" ClientIDMode="Static" onChange="numinwrdDuty();" onClick="numinwrdDuty()"
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>
                        </div>

                         <div id="tag_transac_exp_drawback">
                        <div id="tag_label_transaction_exp_jobb">
                          Assable Value
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtAssableValue" runat="server" MaxLength="35" ClientIDMode="Static" onChange="numinwrd();"  onClick="numinwrd()" 
                                                TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                    <%--   <asp:TextBox ID="txtAssableValue" runat="server" MaxLength="35" ClientIDMode="Static" 
                                 TabIndex="11" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>--%>
                        </div>                                            
                    </div>

                    <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1">
                                            <div id="tag_label_transaction_export_Item_otherdet_new1">
                                                I.T.C.License
                                            </div>
                                            <div id="txtcon-m_46px_trans_export_marks">
                                                <asp:TextBox ID="txtITCLicense" TextMode="MultiLine" TabIndex="22" runat="server" CssClass="txtbox_none_Mid_transac_export_Marks_nos_gen"
                                                    MaxLength="200" ></asp:TextBox>
                                                   
                                            </div>
                                        </div>
                                        
                       
                    <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1">
                                <div id="tag_label_transaction_export_Item_otherdet_new1">
                                    Invoice No & Date</div>
                                <div id="tag_label_transaction_export_Item_otherdet_new2">
                                    
                            <%--        <asp:ListBox ID="txtInvoiceNoDate" runat="server" Width="250px" Height="50px" SelectionMode="Multiple">
                                    <asp:ListItem></asp:ListItem>
                                    </asp:ListBox>--%>
                                    <asp:TextBox ID="txtInvoiceNoDate" runat="server" MaxLength="80" 
                                        TextMode="MultiLine"  CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                        TabIndex="1" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                     <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1">
                                <div id="tag_label_transaction_export_Item_otherdet_new1">
                                    Duty Value in Words</div>
                                <div id="tag_label_transaction_export_Item_otherdet_new2">
                                    <asp:TextBox ID="txtDutyValueWords" runat="server" MaxLength="80" 
                                        TextMode="MultiLine"  CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                        TabIndex="1" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                             <div id="tag_transac_lft_trans_item_maindet_otherdet_remarks_new1">
                                <div id="tag_label_transaction_export_Item_otherdet_new1">
                                    Assable Value in Words</div>
                                <div id="tag_label_transaction_export_Item_otherdet_new2">
                                    <asp:TextBox ID="txtAssableValueinWords" runat="server" MaxLength="80" 
                                        TextMode="MultiLine"  CssClass="validate[required] txtbox_none_Mid_transac_item_other_rmarks_new3"
                                        TabIndex="1" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                      

              </div>
               

                </div>
                <div class="content" id="page-2" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_export_invoice_Iframe">
                    </iframe>
                </div>
                <div class="content" id="page-3" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_export_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-4" style="display:none;">
                    <iframe src="#" name="trans_igm" scrolling="no" id="Trans_igm_item_Iframe"></iframe>
                </div>
                <div class="content" id="page-5" style="display:none;">
                  
                </div>
                <div class="content" id="page-6" style="display:none;">
                   
                </div>
                <div class="content" id="page-7" style="display:none;">
                   
                </div>
                <div class="content" id="page-8" style="display:none;">
                    
                </div>
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                    <asp:HiddenField ID="hdnSup1" runat="server" />
                    <asp:HiddenField ID="hdnSup2" runat="server" />
                    <asp:HiddenField ID="hdnSup3" runat="server" />
                    <asp:HiddenField ID="hdnSup4" runat="server" />
                    <asp:HiddenField ID="HdnDutyforgone" runat="server" />

                    
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
   


        <script type="text/javascript">
            function chkchange() {
//                var hdnsup1 = "";
                var hdnsup2 = document.getElementById('<%=hdnSup2.ClientID%>');
//                var hdnsup3 = "";
//                var hdnsup4 = document.getElementById('<%=hdnSup4.ClientID%>');

                 hdnsup1 = document.getElementById('<%=hdnSup1.ClientID%>');
                 hdnsup2 = document.getElementById('<%=hdnSup2.ClientID%>');
                 hdnsup3 = document.getElementById('<%=hdnSup3.ClientID%>');
                 hdnsup4 = document.getElementById('<%=hdnSup4.ClientID%>');

                var txtsup1 = document.getElementById('<%=txtConsignee.ClientID%>');
                var txtsup2 = document.getElementById('<%=txtConsignee_Add1.ClientID%>');
                var txtsup3 = document.getElementById('<%=txtConsignee_Add2.ClientID%>');
                var txtsup4 = document.getElementById('<%=txtConsignee_Add3.ClientID%>');

               
                 if (document.getElementById('<%=chkSupplier.ClientID%>').checked) {
                     txtsup1.value = hdnsup1.value;
                     txtsup2.value = hdnsup2.value;
                     txtsup3.value = hdnsup3.value;
                     txtsup4.value = hdnsup4.value;
                 }
                 else {
                     txtsup1.value = '';
                     txtsup2.value = '';
                     txtsup3.value = '';
                     txtsup4.value = '';
                }
            }
    </script>

<script type="text/javascript">

    function chkduty1() {
        
        var d1 = document.getElementById('<%=HdnDutyforgone.ClientID%>');
        var txtduty = document.getElementById('<%=txtDutyforgone.ClientID%>');

        if (document.getElementById('<%=chkduty.ClientID%>').checked) {
            txtduty.value = d1.value;
        }
        else {
            txtduty.value = '';
        }
    }

    </script>

    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
//        jQuery(document).ready(function () {

//            jQuery("#form1").validationEngine();
//        });


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

             if (document.getElementById("<%=ddlJobNo.ClientID %>").value != 'Select') 
             {
                 var f = document.getElementById("<%=ddlJobNo.ClientID %>").value;
                     NewWindow1('../Report/ManualBE_ReportViewer.aspx?jobno=' + f + '', 'List', '870', '1024', 'yes');
                     return false
             }

         }
     </script>

    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
   
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>


    <script type="text/javascript" src="../js/Grid_header_script/gridviewScroll.min.js"></script>
     <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8"> </script>

     <script type="text/javascript">
         $(document).ready(function () {
             /* gridviewScroll();*/

             var totalRows = $("#<%=GV_Details.ClientID %> tr").length;
             var lastProductId = $("#<%=GV_Details.ClientID %> tr:last").children("td:first").html();


             if (totalRows > 2) {

                 gridviewScroll();

             }
             else {

                 if (lastProductId > 0) {
                     gridviewScroll();
                 }
                 else {
                     document.getElementById('<%=tag_transac_exp_drawback_1.ClientID %>').style.width = "940px";
                     document.getElementById('<%=tag_transac_exp_drawback_1.ClientID %>').style.height = "59px";
                     document.getElementById('<%=tag_transac_exp_drawback_1.ClientID %>').style.overflow = "Auto";

//                     document.getElementById('<%=GV_Details.ClientID %>').style.overflow = "Auto";
//                     document.getElementById('<%=GV_Details.ClientID %>').style.width = "100%";
                   
                 }
             }
         });

         function gridviewScroll() {
             gridView1 = $('#<%=GV_Details.ClientID %>').gridviewScroll({

                 width: 920,
                 height: 200,
                 railcolor: "#F0F0F0",
                 barcolor: "#CDCDCD",
                 barhovercolor: "#606060",
                 bgcolor: "#F0F0F0",
                 freezesize: 1,
                 arrowsize: 30,
                 varrowtopimg: "../GridScroll_Images/arrowvt.png",
                 varrowbottomimg: "../GridScroll_Images/arrowvb.png",
                 harrowleftimg: "../GridScroll_Images/arrowhl.png",
                 harrowrightimg: "../GridScroll_Images/arrowhr.png",
                 headerrowcount: 1,
                 railsize: 16,
                 barsize: 15,
                 IsInUpdatePanel: true
             });
         }

	</script>
      

</body>
</html>
