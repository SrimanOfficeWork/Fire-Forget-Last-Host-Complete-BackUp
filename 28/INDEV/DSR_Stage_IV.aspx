<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DSR_Stage_IV.aspx.cs"   Inherits="DSR_Stage_IV"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import DSR Stage IV</title>
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

     <script language="javascript">

         function B_G_tab_page1() {

             document.getElementById('page-1').style.display = 'Block';
             document.getElementById('page-2').style.display = 'none';
             document.getElementById('page-3').style.display = 'none';
             document.getElementById('page-4').style.display = 'none';

             document.getElementById("page-6").style.display = 'block';
             document.getElementById("page-7").style.display = 'none';
             document.getElementById("page-8").style.display = 'none';
             document.getElementById("page-9").style.display = 'none';

             document.getElementById("Page_A").className = 'active';
             document.getElementById("Page_B").className = 'inactive';
             document.getElementById("Page_C").className = 'inactive';
             document.getElementById("Page_D").className = 'inactive';
         }

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
            <div id="innerbox_MidMain">
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                       DSR Stage IV</div>
                    <div id="verslic">
                    </div>
                    <div id="popupwindow_closebut_right_new">

                     <span id="F" runat="server"><input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span> 
                      <span id="T" runat="server">  <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span> 

                    </div>
           
                </div>

                <div id="tag_transact_src_inner" style="width: 1150px">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px">


                        <div id="tag_transact_lft_in1" style="width: 1150px">

                          <div id="txt_container_Transact_Main_l" style="width: 420px;">
                                <div id="tag_label_transact_Src" style="width: 68px;">
                                    Imp. Name</div>
                                <div id="txtcon-m_Exchange">

                                     <asp:DropDownList ID="ddlImp_name" CssClass="listtxt_transac_item_gen_notn" 
                                         Width="350px" runat="server"  AutoPostBack="true"
                                         onselectedindexchanged="ddlImp_name_SelectedIndexChanged" >
                                    </asp:DropDownList>

                                </div>
                            </div>
                         


                            <div id="txt_container_Transact_Main_l" style="width: 207px">
                                <div id="tag_label_transact_Src" style="width: 70px">
                                    BE Status
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                       <asp:DropDownList ID="ddlBE_status" CssClass="listtxt_transac_item_gen_notn" 
                                           Width="100px"  runat="server" AutoPostBack="true"
                                           onselectedindexchanged="ddlBE_status_SelectedIndexChanged">
                                       <asp:ListItem Text="" Value=""></asp:ListItem>
                                       <asp:ListItem Text="BE Filed" Value="W"></asp:ListItem>
                                       <asp:ListItem Text="BE Not Filed" Value="O" ></asp:ListItem>
                                       </asp:DropDownList>
                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_l" style="width: 200px">
                                <div id="tag_label_transact_Src" style="width:85px;">
                                   From Date
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 100px">
                                      <asp:TextBox ID="txtfromdate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="3"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtfromdate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfromdate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                </div>
                            </div>
                           
                            <div id="txt_container_Transact_Main_l" style="width: 270px">
                            
                                <div id="tag_label_transact_Src">
                                    To Date
                                </div>
                                <div id="txtcon-m_Exchange" >
                                     <asp:TextBox ID="txttodate" runat="server" CssClass="txtbox_none_Mid_transac_code"
                                    MaxLength="10" TabIndex="4"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txttodate"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txttodate"
                                    Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                                </div>
                           
                            </div>
                        </div>



                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            
                            <div id="txt_container_Transact_Main_l" style="width:280px;">
                           
                                <div id="tag_label_transact_Src" style="width:68px;">
                                    Job No
                                </div>
                                <div id="txtcon-m_Exchange" style="width:155px;">
                                    <asp:DropDownList ID="ddljobno" CssClass="listtxt_transac_item_gen_notn" 
                                        Width="100px" runat="server"  >
                                    </asp:DropDownList>
                                </div>

                                
                            </div>


                             <div id="txt_container_Transact_Main_l" style="width:218px;">
                                <div id="div_loc" runat="server">
                                    <div id="tag_label_transact_Src" style="width:60px;">
                                       
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:150px;">
                                        <asp:Button ID="btnapply" Text="Load Entry Page"  runat="server" UseSubmitBehavior="false" onclick="btnapply_Click"  />
                                    </div>
                                </div>
                            </div>
                               <div id="txt_container_Transact_Main_l" style="width:221px;">
                                    <div id="tag_label_transact_Src" style="width:80px;">
                                       
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width:105px;">
                                       <asp:Button ID="btnapply_2" Text="Load Update/Delete"  runat="server" 
                                            UseSubmitBehavior="false" onclick="btnapply_2_Click"   />
                                    </div>
                                
                            </div>
                        </div>
                    </div>
                 
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1094px; height: 467px;margin-top: -12px; "> 
                <ol id="toc_new">
                    <li><a href="#page-1"  class="active" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_1('0');"  id="Gen"><span>Stage I </span></a></li>
                   <%-- <li><a href="#page-2" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_2('0');"
                        id="MD"><span>Local Sales</span></a></li>
                    <li><a href="#page-3" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_3('0');"
                        id="SD"><span>Other Details</span></a></li>--%>
                   <%-- <li><a href="#page-4" onclick="jQuery('#form1').validationEngine('hideAll');G_tab_page_4('0');"
                        id="Anx"><span>Annexure </span></a></li>--%>
                </ol>

                <div class="content" id="page-1">
                    <div id="open_item" runat="server">
                        <div id="innerbox_MidMain_Trans_Item_Main" style="height: 409px; width: 1079px; margin-left: -9px; margin-top: -3px;">
                            <ol id="toc">
                                <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                                    id="Page_A" runat="server"><span>Entry page </span></a></li>
                                <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');"
                                    id="Page_B" runat="server"><span>Update/ Delete</span></a></li>
                                <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                                    id="Page_C" runat="server" visible="false"><span>Gen -3</span></a></li>
                                <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                                    id="Page_D" runat="server" visible="false"><span>Gen -4 </span></a></li>
                            </ol>
                            <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/INDEV/Hrs.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>
                <asp:XmlDataSource ID="XmlDataSource2" runat="server" DataFile="~/INDEV/Mins.xml"  XPath="ListItems/ListItem"></asp:XmlDataSource>
                            <div class="content" id="page-6">
                                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 329px;margin-top: -16px; margin-left:-15px; width:1100px">
                                    
                                    <div id="Main_Grid_Container" runat="server" style=" overflow:scroll; height: 358px;">

                                <asp:GridView ID="gv_Chg_Details" runat="server"  EmptyDataText="No Record Found" DataKeyNames="Jobno"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"  PageSize="12"
                                ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="true"
                                 HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="205%"
                                OnRowCreated="gv_Chg_Details_RowCreated" OnRowDataBound="gv_Chg_Details_RowDataBound" 
                                onpageindexchanging="gv_Chg_Details_PageIndexChanging" >
                                                  
                                
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <PagerStyle  ForeColor="Black"  CssClass="pager" />
                                <Columns>
                                   
                                   <asp:TemplateField HeaderText="Chk " HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                           <HeaderTemplate>
                                                <asp:CheckBox ID="chkAll" runat="server"  />
                                            </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="D_CHECK"  runat="server" HeaderText="ch_inv" Width="40px" />
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                            <asp:Literal ID="txtjobno" Text='<%# Bind("Jobno")  %>'   runat="server" ></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Imp Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                        <asp:Label ID="txtimp_name" runat="server" Text='<%# Bind("Imp_Name") %>' ToolTip ='<%# Bind("Imp_Name_tooltip") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Con. No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                            <asp:Literal ID="txtcon_no" Text='<%# Bind("CONTAINER_NO")  %>'  runat="server" ></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Contr Arval CCTL WIT TIMG (hh:mm)" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <%--<asp:TextBox ID="txt_Contr_Arval_CCTL_WIT_TIMG"  Enabled="false"  ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Contr_Arval_CCTL_WIT_TIMG") %>'  Width="150px"  runat="server" ></asp:TextBox>--%>
                                            <asp:TextBox ID="txt_Contr_Arval_CCTL_WIT_TIMG_Date" Enabled="false" ToolTip='<%# Bind("Jobno") %>'
                                                Text='<%# Bind("Contr_Arval_CCTL_WIT_TIMG") %>' Width="100px" runat="server"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender28" runat="server" TargetControlID="txt_Contr_Arval_CCTL_WIT_TIMG_Date"
                                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                            </cc1:MaskedEditExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender28" runat="server" TargetControlID="txt_Contr_Arval_CCTL_WIT_TIMG_Date"
                                                Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                            <asp:DropDownList ID="ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date" runat="server" CssClass="listtxt_transac_mode_new"
                                                Width="40px" DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date" runat="server" CssClass="listtxt_transac_mode_new"
                                                Width="40px" DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value">
                                            </asp:DropDownList>

                                        </ItemTemplate>
                                        <ItemStyle Width="150px"/>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText=" D O Validity Date (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px" >
                                        <ItemTemplate>
                                        <asp:TextBox ID="txt_D_O_Validity_Date" Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("D_O_Validity_Date") %>'
                                          Width="100px"  runat="server" ></asp:TextBox>
                                          <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txt_D_O_Validity_Date"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_D_O_Validity_Date"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                        <asp:DropDownList ID="ddlhrs_D_O_Validity_Date"   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_D_O_Validity_Date" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>

                                        </ItemTemplate>
                                        <ItemStyle Width="190px"/>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Last free Dt. CNTR Detention (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="210px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Last_free_Dt_CNTR_Deten" Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Last_free_date_CNTR_Detention") %>'  Width="100px"  runat="server" ></asp:TextBox>

                                        <cc1:MaskedEditExtender ID="MaskedEditExtender22" runat="server" TargetControlID="txt_Last_free_Dt_CNTR_Deten"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender22" runat="server" TargetControlID="txt_Last_free_Dt_CNTR_Deten"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                          <asp:DropDownList ID="ddlhrs_Last_free_Dt_CNTR_Deten"   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Last_free_Dt_CNTR_Deten" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                                        
                                        </ItemTemplate>
                                        <ItemStyle Width="210px"/>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Container Reached CFS (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px">
                                        <ItemTemplate>
                                            <%--<asp:TextBox ID="txt_Container_Reached_CFS"  Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Container_Reached_CFS") %>'  Width="130px"  runat="server" ></asp:TextBox>--%>
                                           
                                            <asp:TextBox ID="txt_Container_Reached_CFS_Date" Enabled="false" ToolTip='<%# Bind("Jobno") %>'
                                                Text='<%# Bind("Container_Reached_CFS") %>' Width="100px" runat="server"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender31" runat="server" TargetControlID="txt_Container_Reached_CFS_Date"
                                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                            </cc1:MaskedEditExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender31" runat="server" TargetControlID="txt_Container_Reached_CFS_Date"
                                                Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                            <asp:DropDownList ID="ddlhrs_txt_Container_Reached_CFS_Date" runat="server" CssClass="listtxt_transac_mode_new"
                                                Width="40px" DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlsec_txt_Container_Reached_CFS_Date" runat="server" CssClass="listtxt_transac_mode_new"
                                                Width="40px" DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value">
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="130px"/>
                                    </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Last Free Dt. Grnd Rent CFS (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="210px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Last_Free_Date_Grnd_Rent_CFS" Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Last_Free_Date_Grnd_Rent_CFS") %>'  Width="100px"  runat="server" ></asp:TextBox>

                                        <cc1:MaskedEditExtender ID="MaskedEditExtender20" runat="server" TargetControlID="txt_Last_Free_Date_Grnd_Rent_CFS"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender20" runat="server" TargetControlID="txt_Last_Free_Date_Grnd_Rent_CFS"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                          <asp:DropDownList ID="ddlhrs_Last_Free_Date_Grnd_Rent_CFS"   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Last_Free_Date_Grnd_Rent_CFS" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                                        
                                        </ItemTemplate>
                                        <ItemStyle Width="210px"/>
                                    </asp:TemplateField>

                                   
                                     <asp:TemplateField HeaderText="Delivery Dt. from CFS (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Delivery_Date_from_CFS"  Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Delivery_Date_from_CFS") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txt_Delivery_Date_from_CFS"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txt_Delivery_Date_from_CFS"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                         <asp:DropDownList ID="ddlhrs_Delivery_Date_from_CFS"   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Delivery_Date_from_CFS" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" ></asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px"/>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Reported Date to WH (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Reported_Date_to_WH"  Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Reported_Date_to_WH") %>' Width="100px"  runat="server" ></asp:TextBox>
                                        
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txt_Reported_Date_to_WH"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txt_Reported_Date_to_WH"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                        <asp:DropDownList ID="ddlhrs_Reported_Date_to_WH"   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Reported_Date_to_WH" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" ></asp:DropDownList>
                                        
                                        </ItemTemplate>
                                        <ItemStyle Width="200px"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Gate Out Date from WH (hh:mm)" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Gate_Out_Date_from_WH"  Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Gate_Out_Date_from_WH") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender23" runat="server" TargetControlID="txt_Gate_Out_Date_from_WH"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender23" runat="server" TargetControlID="txt_Gate_Out_Date_from_WH"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                       
                                       <asp:DropDownList ID="ddlhrs_Gate_Out_Date_from_WH"   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Gate_Out_Date_from_WH" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" ></asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Cleared Date (hh:mm)" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Empty_CNTR_Handed_Over_Date"  Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Empty_CNTR_Handed_Over_Date") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender25" runat="server" TargetControlID="txt_Empty_CNTR_Handed_Over_Date"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender25" runat="server" TargetControlID="txt_Empty_CNTR_Handed_Over_Date"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                       
                                       <asp:DropDownList ID="ddlhrs_Empty_CNTR_Handed_Over_Date"   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Empty_CNTR_Handed_Over_Date" runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" ></asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px"/>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                                   
                                   </div>
                                </div>
                                  <div style="width:50%; float:right;">
                                     <asp:Button ID="btnSave" Text="Save" OnClick="btnSave_Click" runat="server"/>
                                     </div>
                            </div>
                            <div class="content" id="page-7" style="display: none;">
                                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 329px;margin-top: -16px; margin-left:-15px; width:1100px">
                                    
                                    <div id="Main_Grid_Container"  style=" overflow:scroll; height: 358px;">

                                <asp:GridView ID="gv_Chg_Details_2" runat="server"  EmptyDataText="No Record Found" DataKeyNames="Jobno"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"  PageSize="12"
                                ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="true"
                                 HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="210%"
                                OnRowCreated="gv_Chg_Details_RowCreated" OnRowDataBound="gv_Chg_Details_RowDataBound" 
                                onpageindexchanging="gv_Chg_Details_2_PageIndexChanging" >
                                                  
                                
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <PagerStyle  ForeColor="Black"  CssClass="pager" />
                                <Columns>
                                   
                                        <asp:TemplateField HeaderText="Chk " HeaderStyle-Font-Bold="true" HeaderStyle-Width="40px">
                                           <HeaderTemplate>
                                                <asp:CheckBox ID="U_chkAll" runat="server"  />
                                            </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="U_D_CHECK"  runat="server" HeaderText="ch_inv" Width="40px" />
                                        </ItemTemplate>
                                        <ItemStyle Width="40px" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                            <asp:Literal ID="txtjobno" Text='<%# Bind("Jobno")  %>'   runat="server" ></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Con. No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                            <asp:Literal ID="txtcon_no" Text='<%# Bind("CONTAINER_NO")  %>'  runat="server" ></asp:Literal>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Imp Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px" >
                                        <ItemTemplate>
                                        <asp:Label ID="txtimp_name" runat="server" Text='<%# Bind("Imp_Name") %>' ToolTip ='<%# Bind("Imp_Name_tooltip") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" HorizontalAlign="Left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Contr Arval CCTL WIT TIMG (hh:mm)" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <%--<asp:TextBox ID="txt_Contr_Arval_CCTL_WIT_TIMG"  Enabled="false"  ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Contr_Arval_CCTL_WIT_TIMG") %>'  Width="150px"  runat="server" ></asp:TextBox>--%>
                                        

                                            <asp:TextBox ID="txt_Contr_Arval_CCTL_WIT_TIMG_Date" Enabled="false" ToolTip='<%# Bind("Jobno") %>'
                                                Text='<%# Bind("Contr_Arval_CCTL_WIT_TIMG") %>' Width="100px" runat="server"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender29" runat="server" TargetControlID="txt_Contr_Arval_CCTL_WIT_TIMG_Date"
                                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                            </cc1:MaskedEditExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender29" runat="server" TargetControlID="txt_Contr_Arval_CCTL_WIT_TIMG_Date"
                                                Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                            <asp:DropDownList ID="ddlhrs_txt_Contr_Arval_CCTL_WIT_TIMG_Date" Text='<%# Bind("Contr_Arval_CCTL_WIT_TIMG_hrs") %>'  runat="server" CssClass="listtxt_transac_mode_new"
                                                Width="40px" DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlsec_txt_Contr_Arval_CCTL_WIT_TIMG_Date" Text='<%# Bind("Contr_Arval_CCTL_WIT_TIMG_mins") %>'  runat="server" CssClass="listtxt_transac_mode_new"
                                                Width="40px" DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value">
                                            </asp:DropDownList>


                                        </ItemTemplate>
                                        <ItemStyle Width="150px"/>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText=" D O Validity Date (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px" >
                                        <ItemTemplate>
                                        <asp:TextBox ID="txt_D_O_Validity_Date" Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("D_O_Validity_Date") %>'
                                          Width="100px"  runat="server" ></asp:TextBox>
                                          <cc1:MaskedEditExtender ID="MaskedEditExtender8" runat="server" TargetControlID="txt_D_O_Validity_Date"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txt_D_O_Validity_Date"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                        <asp:DropDownList ID="ddlhrs_D_O_Validity_Date" Text='<%# Bind("D_O_Validity_Date_hrs") %>'   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_D_O_Validity_Date" Text='<%# Bind("D_O_Validity_Date_mins") %>'  runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>

                                        </ItemTemplate>
                                        <ItemStyle Width="190px"/>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Last free Dt CNTR Detention (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="210px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Last_free_Dt_CNTR_Deten" Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Last_free_date_CNTR_Detention") %>'  Width="100px"  runat="server" ></asp:TextBox>

                                        <cc1:MaskedEditExtender ID="MaskedEditExtender21" runat="server" TargetControlID="txt_Last_free_Dt_CNTR_Deten"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender21" runat="server" TargetControlID="txt_Last_free_Dt_CNTR_Deten"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                          <asp:DropDownList ID="ddlhrs_Last_free_Dt_CNTR_Deten"  Text='<%# Bind("Last_free_date_CNTR_Detention_hrs") %>'   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Last_free_Dt_CNTR_Deten"  Text='<%# Bind("Last_free_date_CNTR_Detention_mins") %>' runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                                        
                                        </ItemTemplate>
                                        <ItemStyle Width="210px"/>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Container Reached CFS (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="190px">
                                        <ItemTemplate>
                                            <%--<asp:TextBox ID="txt_Container_Reached_CFS"  Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Container_Reached_CFS") %>'  Width="130px"  runat="server" ></asp:TextBox>--%>

                                        <asp:TextBox ID="txt_Container_Reached_CFS_Date" Enabled="false" ToolTip='<%# Bind("Jobno") %>'
                                                Text='<%# Bind("Container_Reached_CFS") %>' Width="100px" runat="server"></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender30" runat="server" TargetControlID="txt_Container_Reached_CFS_Date"
                                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                            </cc1:MaskedEditExtender>
                                            <cc1:CalendarExtender ID="CalendarExtender30" runat="server" TargetControlID="txt_Container_Reached_CFS_Date"
                                                Format="dd/MM/yyyy">
                                            </cc1:CalendarExtender>
                                            <asp:DropDownList ID="ddlhrs_txt_Container_Reached_CFS_Date" Text='<%# Bind("Container_Reached_CFS_hrs") %>' runat="server" CssClass="listtxt_transac_mode_new"
                                                Width="40px" DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlsec_txt_Container_Reached_CFS_Date" Text='<%# Bind("Container_Reached_CFS_mins") %>' runat="server" CssClass="listtxt_transac_mode_new"
                                                Width="40px" DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value">
                                            </asp:DropDownList>

                                        </ItemTemplate>
                                        <ItemStyle Width="130px"/>
                                    </asp:TemplateField>


                                     <asp:TemplateField HeaderText="Last Free Date Grnd Rent CFS (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="210px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Last_Free_Date_Grnd_Rent_CFS" Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Last_Free_Date_Grnd_Rent_CFS") %>'  Width="100px"  runat="server" ></asp:TextBox>

                                        <cc1:MaskedEditExtender ID="MaskedEditExtender19" runat="server" TargetControlID="txt_Last_Free_Date_Grnd_Rent_CFS"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender19" runat="server" TargetControlID="txt_Last_Free_Date_Grnd_Rent_CFS"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                          <asp:DropDownList ID="ddlhrs_Last_Free_Date_Grnd_Rent_CFS"  Text='<%# Bind("Last_Free_Date_Grnd_Rent_CFS_hrs") %>' runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Last_Free_Date_Grnd_Rent_CFS" Text='<%# Bind("Last_Free_Date_Grnd_Rent_CFS_mins") %>' runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                                        
                                        </ItemTemplate>
                                        <ItemStyle Width="210px"/>
                                    </asp:TemplateField>

                                   
                                     <asp:TemplateField HeaderText="Delivery Date from CFS (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Delivery_Date_from_CFS"  Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Delivery_Date_from_CFS") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender13" runat="server" TargetControlID="txt_Delivery_Date_from_CFS"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender13" runat="server" TargetControlID="txt_Delivery_Date_from_CFS"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                         <asp:DropDownList ID="ddlhrs_Delivery_Date_from_CFS"  Text='<%# Bind("Delivery_Date_from_CFS_hrs") %>'   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Delivery_Date_from_CFS" runat="server" Text='<%# Bind("Delivery_Date_from_CFS_mins") %>'  CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" ></asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px"/>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Reported Date to WH (hh:mm)" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Reported_Date_to_WH"  Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Reported_Date_to_WH") %>' Width="100px"  runat="server" ></asp:TextBox>
                                        
                                        <cc1:MaskedEditExtender ID="MaskedEditExtender14" runat="server" TargetControlID="txt_Reported_Date_to_WH"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txt_Reported_Date_to_WH"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>

                                        <asp:DropDownList ID="ddlhrs_Reported_Date_to_WH"  Text='<%# Bind("Reported_Date_to_WH_hrs") %>' runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Reported_Date_to_WH" Text='<%# Bind("Reported_Date_to_WH_mins") %>' runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" ></asp:DropDownList>
                                        
                                        </ItemTemplate>
                                        <ItemStyle Width="200px"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Gate Out Date from WH (hh:mm)" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Gate_Out_Date_from_WH"  Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Gate_Out_Date_from_WH") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender265" runat="server" TargetControlID="txt_Gate_Out_Date_from_WH"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender26" runat="server" TargetControlID="txt_Gate_Out_Date_from_WH"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                       
                                       <asp:DropDownList ID="ddlhrs_Gate_Out_Date_from_WH" Text='<%# Bind("Gate_Out_Date_from_WH_hrs") %>'   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Gate_Out_Date_from_WH" Text='<%# Bind("Gate_Out_Date_from_WH_mins") %>'  runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" ></asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="200px"/>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Empty CNTR Handed Over Dt. (hh:mm)" HeaderStyle-Font-Bold="true"  HeaderStyle-Width="220px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Empty_CNTR_Handed_Over_Date"  Enabled="false" ToolTip ='<%# Bind("Jobno") %>' Text='<%# Bind("Empty_CNTR_Handed_Over_Date") %>'  Width="100px"  runat="server" ></asp:TextBox>
                                            <cc1:MaskedEditExtender ID="MaskedEditExtender27" runat="server" TargetControlID="txt_Empty_CNTR_Handed_Over_Date"
                                            Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                            MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                        </cc1:MaskedEditExtender>
                                        <cc1:CalendarExtender ID="CalendarExtender27" runat="server" TargetControlID="txt_Empty_CNTR_Handed_Over_Date"
                                            Format="dd/MM/yyyy">
                                        </cc1:CalendarExtender>
                                       
                                       <asp:DropDownList ID="ddlhrs_Empty_CNTR_Handed_Over_Date" Text='<%# Bind("Empty_CNTR_Handed_Over_Date_hrs") %>'   runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                             DataSourceID="XmlDataSource1" DataTextField="text" DataValueField="value" >
                                        </asp:DropDownList>
                            
                                        <asp:DropDownList ID="ddlsec_Empty_CNTR_Handed_Over_Date" Text='<%# Bind("Empty_CNTR_Handed_Over_Date_mins") %>' runat="server" CssClass="listtxt_transac_mode_new" Width="40px"
                                           DataSourceID="XmlDataSource2" DataTextField="text" DataValueField="value" ></asp:DropDownList>
                                        </ItemTemplate>
                                        <ItemStyle Width="220px"/>
                                    </asp:TemplateField>
                             </Columns>
                            </asp:GridView>
                           
                                        </div>
                                </div>
                                  <div style="width:50%; float:right;">
                                     <asp:Button ID="btnUpdate" Text="Update" OnClick="btnUpdate_Click" runat="server"/>
                                     &nbsp;&nbsp;&nbsp;&nbsp;
                                     <asp:Button ID="btndelete" Text="Delete" OnClick="btndelete_Click"  runat="server"/>
                                     </div>
                            </div>
                            <div class="content" id="page-8">
                                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 225px;">
                                </div>
                            </div>
                            <div class="content" id="page-9">
                                <div id="pop_text_area_transac_popup_inn_container_export" style="height: 225px;">
                                    4
                                </div>
                            </div>
                            
                        </div>
                     
                    </div>
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
                
            </div>
         
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>

             <asp:HiddenField ID="hdn_Jobno" runat="server" ClientIDMode="Static" />
             <asp:HiddenField ID="HDupdate_id" runat="server" />

             <asp:HiddenField ID="HD_Showcon" runat="server" />
             <asp:HiddenField ID="Hd_row_id" runat="server" />



    


            <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
                BackgroundCssClass="modalBackground" DropShadow="false">
            </asp:ModalPopupExtender>
            <asp:HiddenField ID="HDU_JOB" runat="server" />
            <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
                BorderColor="Transparent">
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 320px; height: 80px;">
                    <div id="innerbox_MidMain_Transact_popup_new" style="width: 319px; height: 80px;">
                        <div id="tag_srcinner1_new">
                            <div id="editbu">
                                <a href="#" class="edit"></a>
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1">
                                Selected Jobs Saved to Move Next ?
                            </div>
                            <div id="popupwindow_closebut_right_new">
                            </div>
                        </div>
                        <div id="tag_transaction_inner_new" style="margin-left: 10px; margin-top: 10px; width: 319px;">
                            <div id="tag_Exchange_lft_in1_new1">
                                <div id="tag_label_transaction_Src_new" style="width: 30px;">
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 60px;">
                                </div>
                                <div id="tag_label_transaction_date" style="width: 65px; text-align: center;">
                                    <asp:Button ID="btnok" runat="server" Text="Ok" OnClick="btnYes_Click" CausesValidation="false"
                                        UseSubmitBehavior="false" />
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" OnClick="btnNo_Click" CausesValidation="false"
                                        UseSubmitBehavior="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
           
             <asp:ModalPopupExtender ID="MP_JOB_2" runat="server" TargetControlID="HDU_JOB_2" PopupControlID="MessageDivupdated_Job_2"
                BackgroundCssClass="modalBackground" DropShadow="false">
            </asp:ModalPopupExtender>
            <asp:HiddenField ID="HDU_JOB_2" runat="server" />
            <asp:Panel ID="MessageDivupdated_Job_2" runat="server" CssClass="modalPopup12" align="left" BorderColor="Transparent">
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 320px; height: 80px;">
                    <div id="innerbox_MidMain_Transact_popup_new" style="width: 319px; height: 80px;">
                        <div id="tag_srcinner1_new">
                            <div id="editbu">
                                <a href="#" class="edit"></a>
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1">
                                Selected Jobs Choose to Move Next ?
                            </div>
                            <div id="popupwindow_closebut_right_new">
                            </div>
                        </div>
                        <div id="tag_transaction_inner_new" style="margin-left: 10px; margin-top: 10px; width: 319px;">
                            <div id="tag_Exchange_lft_in1_new1">
                                <div id="tag_label_transaction_Src_new" style="width: 30px;">
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 60px;">
                                </div>

                                <div id="tag_label_transaction_date" style="width: 65px; text-align: center;">
                                    <asp:Button ID="btnupdate_U" runat="server" Text="Update" OnClick="btnupdate_U_Click" CausesValidation="false" UseSubmitBehavior="false" />
                                </div>
                                <div id="tag_label_transaction_date" style="width: 65px; text-align: center;">
                                    <asp:Button ID="btndelete_U" runat="server" Text="Delete" OnClick="btndelete_U_Click"  CausesValidation="false" UseSubmitBehavior="false" />
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:Button ID="btncancel_2" runat="server" Text="Cancel" OnClick="btncancel_U_Click" CausesValidation="false" UseSubmitBehavior="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

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
        $(function () {
            $("[id*=chkAll]").bind("click", function () {
                var chkHeader = $(this);
                var grid = $(this).closest("table");
                $("td", grid).find("input[type=checkbox]").each(function () {

                    if (chkHeader.is(":checked")) {
                        $(this).attr("checked", "checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#FFFFFE" }); //white
                        $("input[type=text]", td).removeAttr("disabled");
                    } else {
                        $(this).removeAttr("checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#BEBEBE" }); //white
                        $("input[type=text]", td).attr("disabled", "disabled");
                    }
                });
            });
        });
    </script>
    <script type = "text/javascript">
        $(function () {
            $("[id*=D_CHECK]").bind("click", function () {
                var grid = $(this).closest("table");
                var chkHeader = $("[id*=chkAll]", grid);
                if (!$(this).is(":checked")) {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#BEBEBE" }); //uncheck
                    $("input[type=text]", td).attr("disabled", "disabled");
                } else {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#FFFFFE" });
                    $("input[type=text]", td).removeAttr("disabled");
                }
                if ($("[id*=D_CHECK]", grid).length == $("[id*=D_CHECK]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                } else {
                    chkHeader.removeAttr("checked");
                }
            });
        });
    </script>


    <script type="text/javascript">
        $(function () {
            $("[id*=U_chkAll]").bind("click", function () {
                var chkHeader = $(this);
                var grid = $(this).closest("table");
                $("td", grid).find("input[type=checkbox]").each(function () {

                    if (chkHeader.is(":checked")) {
                        $(this).attr("checked", "checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#FFFFFE" }); //white
                        $("input[type=text]", td).removeAttr("disabled");
                    } else {
                        $(this).removeAttr("checked");
                        var td = $("td", $(this).closest("tr"));
                        td.css({ "background-color": "#BEBEBE" }); //white
                        $("input[type=text]", td).attr("disabled", "disabled");
                    }
                });
            });
        });
    </script>
    <script type = "text/javascript">
        $(function () {
            $("[id*=U_D_CHECK]").bind("click", function () {
                var grid = $(this).closest("table");
                var chkHeader = $("[id*=U_chkAll]", grid);
                if (!$(this).is(":checked")) {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#BEBEBE" }); //uncheck
                    $("input[type=text]", td).attr("disabled", "disabled");
                } else {
                    var td = $("td", $(this).closest("tr"));
                    td.css({ "background-color": "#FFFFFE" });
                    $("input[type=text]", td).removeAttr("disabled");
                }
                if ($("[id*=U_D_CHECK]", grid).length == $("[id*=U_D_CHECK]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                } else {
                    chkHeader.removeAttr("checked");
                }
            });
        });
    </script>
   
</body>
</html>
