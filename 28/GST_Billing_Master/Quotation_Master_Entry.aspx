<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Quotation_Master_Entry.aspx.cs" Inherits="Quotation_Master_Entry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Quotation Entry</title>
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
         .datagrid table { border-collapse: collapse; text-align: left; width: 100%; } .datagrid {font: normal 12px/150% Arial, Helvetica, sans-serif; background: #fff; overflow: hidden; border: 1px solid #8C8C8C; -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; }.datagrid table td, .datagrid table th { padding: 3px 10px; }.datagrid table thead th {background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; color:#FFFFFF; font-size: 15px; font-weight: bold; border-left: 1px solid gray; } .datagrid table thead th:first-child { border: none; }.datagrid table tbody td { /*color: #7D7D7D;*/ border-left: 1px solid #DBDBDB;font-size: 12px;font-weight: normal; }.datagrid table tbody .alt td { background: #EBEBEB; color: #7D7D7D; }.datagrid table tbody td:first-child { border-left: none; }.datagrid table tbody tr:last-child td { border-bottom: none; }.datagrid table tfoot td div { border-top: 1px solid #8C8C8C;background: #EBEBEB;} .datagrid table tfoot td { padding: 0; font-size: 12px } .datagrid table tfoot td div{ padding: 2px; }.datagrid table tfoot td ul { margin: 0; padding:0; list-style: none; text-align: right; }.datagrid table tfoot  li { display: inline; }.datagrid table tfoot li a { text-decoration: none; display: inline-block;  padding: 2px 8px; margin: 1px;color: #F5F5F5;border: 1px solid #8C8C8C;-webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');background-color:#8C8C8C; }.datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover { text-decoration: none;border-color: #7D7D7D; color: #F5F5F5; background: none; background-color:#8C8C8C;}div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }
    
     /*td:nth-of-type(1) {display: none;}*/
     </style>
     <script language="javascript">

         function CheckAll() {

             var intIndex = 0;

             var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;

             for (i = 0; i < rowCount; i++) {

                 if (document.getElementById('cbAll').checked == true) {

                     if (document.getElementById("cbList" + "_" + i)) {

                         if (document.getElementById("cbList" + "_" + i).disabled != true)

                             document.getElementById("cbList" + "_" + i).checked = true;
                     }

                 }

                 else {

                     if (document.getElementById("cbList" + "_" + i)) {

                         if (document.getElementById("cbList" + "_" + i).disabled != true)

                             document.getElementById("cbList" + "_" + i).checked = false;

                     }

                 }

             }

         }



         function UnCheckAll() {

             var intIndex = 0;

             var flag = 0;

             var rowCount = document.getElementById('cbList').getElementsByTagName("input").length;

             for (i = 0; i < rowCount; i++) {

                 if (document.getElementById("cbList" + "_" + i)) {

                     if (document.getElementById("cbList" + "_" + i).checked == true) {

                         flag = 1;

                     }

                     else {

                         flag = 0;

                         break;

                     }

                 }

             }

             if (flag == 0)

                 document.getElementById('cbAll').checked = false;

             else

                 document.getElementById('cbAll').checked = true;
         }

    </script>
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
            <div id="innerbox_MidMain" style="height:170px; background:White;">
                <div id="tag_srcinner1"  style="margin-left:0px; height:41px;" >
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 55px;">
                      Q. Entry 
                       
                      </div>
                    <div id="verslic">
                    </div>
                   
                    <div id="txt_container_Transact_Main_l" style="width: 380px;">
                                <div id="tag_label_transact_Src" style="width: 70px;color:Blue;font-weight:bold; ">
                                    Customer : <br />
                                    Bill To :
                                    </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddl_Client_Name" CssClass="validate[required] listtxt_transac_item_gen_notn" 
                                        Width="300px"  Font-Size="12px"  runat="server"  TabIndex="2"   CausesValidation="True"
                                         AutoPostBack="true" onselectedindexchanged="ddl_Client_Name_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                    <br />
                                     <asp:DropDownList ID="ddl_Client_Name_To" CssClass="listtxt_transac_item_gen_notn" 
                                        Width="300px"  Font-Size="12px"  runat="server"  TabIndex="8"   CausesValidation="True"
                                         AutoPostBack="true" 
                                        onselectedindexchanged="ddl_Client_Name_To_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                   
                                </div>
                            </div>
                            <div id="verslic">
                             </div>

                    <div id="txt_container_Transact_Main_l" style="width: 102px; margin-top:2px;">
                                <div id="tag_label_transact_Src" style="width: 100px; color:Blue;font-weight:bold;">
                                  <asp:RadioButtonList ID="ddlType" runat="server" RepeatDirection="Horizontal" 
                                        onselectedindexchanged="ddlType_SelectedIndexChanged"  AutoPostBack="true" 
                                        TabIndex="4" >
                                    <asp:ListItem Text="Imp" Value="I" Selected="True" ></asp:ListItem>
                                    <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                                    </asp:RadioButtonList>                              
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                  Branch :

                            </div>
                    </div>

                     <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 130px;">
                                <div id="tag_label_transact_Src" style="width: 75px;color:Blue;font-weight:bold; ">
                                   Ship Type 1
                                        <asp:DropDownList ID="ddl_branch_To" CssClass="listtxt_transac_item_gen_notn" 
                                            Width="150px"  Font-Size="12px" runat="server"  TabIndex="10" > </asp:DropDownList>
                                             
                                   
                                   </div>
                                <div id="txtcon-m_Exchange" style="width: 50px;">
                                    <asp:DropDownList ID="ddlmode" CssClass="listtxt_transac_item_gen_notn" 
                                        Width="50px"  Font-Size="12px" runat="server"  TabIndex="5" 
                                        onselectedindexchanged="ddlmode_SelectedIndexChanged"   
                                        AutoPostBack="true" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                             <div id="verslic">
                             </div>
                                  <div id="txt_container_Transact_Main_l" style="width: 175px;">
                                <div id="tag_label_transact_Src" style="width: 80px;color:Blue; font-weight:bold;">
                                  Ship Type 2</div>
                                <div id="txtcon-m_Exchange" style="width: 90px;">
                                     <asp:DropDownList ID="ddlshipment_type" CssClass="listtxt_transac_item_gen_notn" 
                                        Width="85px"  Font-Size="12px" runat="server"  AutoPostBack="true" 
                                        CausesValidation="True" 
                                         onselectedindexchanged="ddlshipment_type_SelectedIndexChanged" 
                                         TabIndex="7">
                                          <asp:ListItem Text="" Value=""></asp:ListItem>
                                           <asp:ListItem Text="FCL" Value="FCL"></asp:ListItem>
                                            <asp:ListItem Text="LCL" Value="LCL"></asp:ListItem>
                                            <asp:ListItem Text="Ex-bond" Value="Exbond"></asp:ListItem>
                                             <asp:ListItem Text="20 Feet" Value="20"></asp:ListItem>
                                              <asp:ListItem Text="40 Feet" Value="40"></asp:ListItem>
                                              <asp:ListItem Text="20-40 Feet" Value="20-40"></asp:ListItem>
                                              <asp:ListItem Text="Home" Value="Home"></asp:ListItem>
                                              <asp:ListItem Text="Bond" Value="Bond"></asp:ListItem>
                                              <asp:ListItem Text="Br bulk" Value="Brbulk"></asp:ListItem>
                                    </asp:DropDownList>
                                   
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 85px;">
                                <div id="tag_label_transact_Src" style="width: 30px; ">
                                   R.Id</div>
                                <div id="txtcon-m_Exchange" style="width: 50px;">
                                      <asp:TextBox ID="txt_RefId" runat="server" MaxLength="35" Width="40px" BackColor="#F0F0F0"
                                      CssClass="txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                                </div>
                            </div>
                              <div id="txt_container_Transact_Main_l" style="width: 40px; display:none;">
                                <div id="tag_label_transact_Src" style="width: 30px; ">
                                    <asp:Button ID="btn_load_services" runat="server" Text="Load Loc.." 
                                        onclick="btn_load_services_Click" />
                                </div>
                            </div>


                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
           
                </div>
                

                  <div id="Div_listbox" runat="server">
                <div id="tag_transact_src_inner" style="width:1080px;height:120px;">
                 
                            
                       <div id="innerbox_MidMain_Trans_new" style="width:1080px; height:20px; margin-left:-10px; border-bottom-style:solid;  ">
                             

                        <div id="tag_label_transaction_exp_jobb" >
                            <asp:CheckBox ID="cbAll" runat="server" TabIndex="12" ForeColor="White" Font-Bold="true" font-size= "14px" Text="Select All" onclick="CheckAll();" />
                        </div>
                          <div id="tag_label_transaction_exp_jobb" >
                             <span style="color:White;" > <asp:Literal ID="lbl_Loc" runat="server"></asp:Literal> </span>
                        </div>
                        </div>

                         
                         <div id="tag_label_transaction_exp_jobb" style="width: 1080px; overflow:auto; height:125px;" >
                                <asp:CheckBoxList ID="cbList" runat="server" ValidationGroup="VGroup" onclick="UnCheckAll();" TabIndex="13" BorderStyle="none" CssClass=" txtbox_none_Mid_transac_pop_gen" width= "1070px" Height="22px"
                                   Font-Size="11px"  RepeatColumns="6" RepeatDirection="Horizontal">
                                    </asp:CheckBoxList>
                         </div>
                    
        </div>
                    </div>

            </div>
             <asp:HiddenField ID="HiddenField2" runat="server" />
                      <asp:HiddenField ID="hdn_isvalue" runat="server" />
            <%-- -------------------------------------Tab--------------------------------------------------------%>

                <div class="content" id="page-1" style="margin-left:-30px; margin-top:-35px; width:1110px;">
                <div id="open_item" runat="server">
                        
           <%-- <div id="innerbox_MidMain_Trans_Item_Main" style="height:445px; width:1092px; margin-left:-16px; margin-top:-5px;">--%>
                
                <div class="content" id="page-6" >
                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 42px; width:1092px; margin-top: -16px;overflow:hidden;">
                
                <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow: hidden; width:1090px;">

                                <asp:GridView ID="GV" runat="server" AllowSorting="True" 
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" 
                                    BorderStyle="none" ShowFooter="false"  CssClass="grid-view"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1"  AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_Chg_Details_RowCreated"
                                    OnRowDataBound="gv_Chg_Details_RowDataBound" 
                                    style=" overflow:auto;" >
                                     
                                     <Columns>
                                      <asp:BoundField DataField="d" HeaderText="Allow"  HeaderStyle-Width="30px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"    Width="30px"/>
                                    </asp:BoundField>

                                       <asp:BoundField DataField="d" HeaderText="S. No"  HeaderStyle-Width="35px" HeaderStyle-Font-Size="12px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Font-Size="12px" Width="35px"/>
                                    </asp:BoundField>
                                      <asp:BoundField DataField="a" HeaderText="Services"  HeaderStyle-Width="480px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"   Width="480px"  />
                                    </asp:BoundField>

                                     <asp:BoundField DataField="b" HeaderText="Type"   HeaderStyle-Width="40px">
                                        <ItemStyle CssClass="column_style_left_border_2_new"   Width="40px"  />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="f" HeaderText="Unit Price" HeaderStyle-Width="100px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="100px"  />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="f" HeaderText="CGST Rt" HeaderStyle-Width="85px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="85px"  />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="f" HeaderText="SGST Rt" HeaderStyle-Width="85px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="85px"  />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="f" HeaderText="IGST Rt" HeaderStyle-Width="85px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="85px"  />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="f" HeaderText="Type" HeaderStyle-Width="45px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="45px"  />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="f" HeaderText="Per Value" HeaderStyle-Width="85px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="85px"  />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="f" HeaderText="Min Amt" HeaderStyle-Width="85px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="85px"  />
                                    </asp:BoundField>

                                       <asp:BoundField DataField="f" HeaderText="Max Amt" HeaderStyle-Width="85px" >
                                        <ItemStyle CssClass="column_style_left_border_2_new"  Width="85px"  />
                                      </asp:BoundField>
                                     </Columns>
                                    </asp:GridView>



                </div>
                </div>
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 348px; width:1092px; margin-top: -16px; overflow:hidden;">
                        <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow-x: hidden;overflow-y: auto; height:345px; width:1090px; ">
                       
                            <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found" DataKeyNames="ID"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                                AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                OnRowCreated="gv_Chg_Details_RowCreated" OnRowDataBound="gv_Chg_Details_RowDataBound"
                                 ShowHeader="false">
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <Columns>
                                   
                                   <asp:TemplateField HeaderText="ch_inv" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Q_CHECK" runat="server" HeaderText="ch_inv" Width="30px" Checked='<%#bool.Parse(Eval("Q_CHECK").ToString())%>'/>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Row_Num"  Text='<%# Bind("ROWNUMBER") %>' Height="20px" Width="30px" onkeypress="return pin(event)" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="30px" HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                          <span style="font-size:10px;" >   <asp:Literal ID="txtch_name" Text='<%# Bind("CHARGE_NAME")  %>'  runat="server" ></asp:Literal> </span>
                                        </ItemTemplate>
                                        <ItemStyle Width="400px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                          <span style="font-size:10px;" > <asp:Literal ID="txttax_mode" Text='<%# Bind("TAX_MODE")  %>'  runat="server" ></asp:Literal> </span>
                                        </ItemTemplate>
                                        <ItemStyle Width="25px" HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:TemplateField>

                                  <%--------------------------------------%>
                                  <asp:TemplateField HeaderText="EA_1_Air" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Unit_Price"  Text='<%# Bind("UNIT_PRICE") %>' Height="20px" Width="90px"  runat="server"
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"  Font-Size="12px" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="90px"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="EA_1_Air" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_CGST_Rate"  Text='<%# Bind("CGST_RATE") %>' Height="20px" Width="60px" BackColor="#F9B7FF"  runat="server"
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"  Font-Size="12px"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="EA_2" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_SGST_Rate"  Text='<%# Bind("SGST_RATE") %>' Height="20px" Width="60px" runat="server" BackColor="#F9B7FF"
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"  Font-Size="12px" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EA_3" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_IGST_Rate"  Text='<%# Bind("IGST_RATE") %>' Height="20px" Width="60px" runat="server" BackColor="#FFCBA4"
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"  Font-Size="12px" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="ES_3" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddl_ASS_CIF" Text='<%# Bind("ASS_CIF_TYPE") %>' MaxLength="20" runat="server"
                                                 Height="22px" Width="40px"  Font-Size="11px" >
                                                <asp:ListItem></asp:ListItem>
                                                 <asp:ListItem>AV</asp:ListItem>
                                                <asp:ListItem>CI</asp:ListItem>
                                                <asp:ListItem>TON</asp:ListItem>
                                            </asp:DropDownList>

                                        </ItemTemplate>
                                        <ItemStyle Width="40px"  />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="EA_1_Air" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Ass_Rate"  Text='<%# Bind("ASS_RATE") %>' Height="20px" Width="60px"  runat="server"
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                         onkeypress="return blockNonNumbers(this, event, true, false);"  Font-Size="12px" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="60px"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="EA_1_Air" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Min_Amt"  Text='<%# Bind("MIN_AMT") %>' Height="20px" Width="70px"  runat="server" BackColor="#98FF98"
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                         onkeypress="return blockNonNumbers(this, event, true, false);"  Font-Size="12px" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="EA_1_Air" HeaderStyle-Font-Bold="true" >
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Max_Amt"  Text='<%# Bind("MAX_AMT") %>' Height="20px" Width="70px"  runat="server"  BackColor="#F9966B" 
                                            onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                         onkeypress="return blockNonNumbers(this, event, true, false);"  Font-Size="12px" ></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle Width="70px"/>
                                    </asp:TemplateField>

                                    <%-- #F4A460--%>
                                </Columns>
                            </asp:GridView>
                           
                        </div>
                        <%-----------------------Test--------------------------------------------------------%>
                    </div>
                </div>
                  <%-------------------------------------------------------------------------------%>
              <%--  </div>--%>

                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px; margin-left:20px; margin-top:-14px;">
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
                            <asp:Button ID="btnDelete" runat="server" TabIndex="61" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Quotation?', 'QUOTATION MASTER', function(r) {
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
                      
                    </div>
                </div>
                   <%-- --------------------Test End----------------------------%>

                   </div>
                 </div>
              
                <%-----------------------------------END----------------------------------------------------------------%>
          
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>

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
            document.getElementById("General").click();
        }
        
    </script>
   
    
</body>
</html>
