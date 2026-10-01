<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Quotation_Master_Entry.aspx.cs"
    Inherits="Quotation_Master_Entry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Quotation Entry </title>
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
    <script type="text/javascript" src="../js/listpopup.js"></script>
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
            width: 13.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 40em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
    </style>
    <style type="text/css">
        .CalendarStyle
        {
            background-color: Crimson;
            color: White;
            border: solid 2px DarkRed;
        }
        .ajax__calendar_header
        {
            background-color: #FBB117;
            color: black;
        }
        .ajax__calendar_footer
        {
            background-color: #FBB117;
            color: black;
        }
    </style>
    <style type="text/css">
        .FixedHeader
        {
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

    
    <link href="../js/js_bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap-multiselect.js" type="text/javascript"></script>
    <script src="../js/js_bootstrap/jquery.min.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $('[id*=ListBox1]').multiselect({

                includeSelectAllOption: true
            });
        });  
    </script>

    

</head>

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
            <div id="innerbox_MidMain_Billing" style="height: 75px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 130px;">
                        Quotation Entry
                    </div>
                    <div id="verslic">
                    </div>
                     <div id="tag_label_transact_Src" style="width: 200px; color:Blue;font-weight:bold; margin-top:5px">
                                  <asp:RadioButtonList ID="Rd_Imp_Exp" runat="server" RepeatDirection="Horizontal" 
                                      TabIndex="4" AutoPostBack="true"  Width="130px"
                                      onselectedindexchanged="Rd_Imp_Exp_SelectedIndexChanged" >
                                    <asp:ListItem Text="Import" Value="I" Selected="True" ></asp:ListItem>
                                    <asp:ListItem Text="Export" Value="E"></asp:ListItem>
                                    </asp:RadioButtonList>                              
                            </div>
                    <div id="popupwindow_closebut_right_new">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1150px; height: 35px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1150px; height: 30px;">
                        <div id="tag_transact_lft_in1" style="width: 1100px; height:30px;">
                                
                                  <div id="txt_container_Transact_Main_l" style="width: 110px;">
                                    <div id="tag_label_transact_Src" style="width: 110px;">
                                        Party Name
                                    </div>
                                </div>
                                <div id="txt_container_Transact_Main_l" style="width: 505px;">
                                      <asp:DropDownList ID="ddlParty_Name" runat="server" class="chosen-select-deselect"
                                        Style="width: 500px; font-size:8pt;" data-placeholder="Choose a Party Name"  AutoPostBack="true"
                                        TabIndex="5" onselectedindexchanged="ddlParty_Name_SelectedIndexChanged">
                                        </asp:DropDownList>
                                </div>
                           
                            <div id="txt_container_Transact_Main_l" style="width: 72px;">
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Tr. Mode
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 80px;">
                                <asp:DropDownList ID="ddlmode" CssClass="listtxt_transac_item_gen_notn" Width="60px"
                                    Font-Size="12px" runat="server" TabIndex="6" AutoPostBack="true" OnSelectedIndexChanged="ddlmode_SelectedIndexChanged">
                                    <asp:ListItem Text="Air" Value="A"></asp:ListItem>
                                    <asp:ListItem Text="Sea" Value="S"></asp:ListItem>
                                    <asp:ListItem Text="Land" Value="L"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                               <div id="txt_container_Transact_Main_l" style="width: 110px;">
                                <div id="tag_label_transact_Src" style="width: 100px;">
                                   Shipment Type
                                </div>
                            </div>
                              <div id="txt_container_Transact_Main_l" style="width: 100px;">
                                <asp:DropDownList ID="ddl_Ship_type" CssClass="listtxt_transac_item_gen_notn" Width="95px"
                                    Font-Size="12px" runat="server" TabIndex="7" AutoPostBack="true" 
                                      onselectedindexchanged="ddl_Ship_type_SelectedIndexChanged" >
                                    <asp:ListItem Text="Home" Value="H"></asp:ListItem>
                                    <asp:ListItem Text="Warehouse" Value="W"></asp:ListItem>
                                    <asp:ListItem Text="Ex-Bond" Value="EB"></asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div id="editbu">
                                <asp:Button ID="btnExpHead_Delete" runat="server" TabIndex="41"  CssClass="dlete" CausesValidation="false" UseSubmitBehavior="false"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Quotation', function(r) {
                                    var i = r + 'ok';
                                      if(i == 'trueok')
                                      {
                                          document.getElementById('btn1').click();
                                      }
                                      else {
                                      }
                                     });return false;" />
                                <asp:Button ID="btn1" runat="server" TabIndex="43" 
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;"   OnClick="btnExpHead_Delete_Click" />
                            </div>
                     
                        </div>
                    </div>
                    
                    <%------------%>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -30px;">
                <div id="innerbox_MidMain_Trans_new" style="height: 500px; width: 1190px; margin-left: -10px;  margin-top: -5px;">
                   
                     <ol id="toc_new">
                    <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');" id="Page_A" runat="server">
                        <span>General </span></a></li>
                         
                     <li ><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');" id="Page_C" runat="server" visible="false" >
                        <span>Other</span></a></li>

                    <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page2('0');" id="Page_B" runat="server">
                        <span>Transport details</span></a></li>
                   

                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');" id="Page_D" runat="server" visible="false">
                        </a></li>
                    
                     <span style="color:black;font-size:12px;"> &nbsp; 
                            <asp:Literal ID="lbl_Created_Modified" runat="server"></asp:Literal>
                         </span>
                </ol>


                    <div class="content" id="page-6">
                    <div id="pop_text_area_transac_popup_inn_container_new" style="width:1175px;height:456px;">
                    <div id="pop_text_area_transac_popup_inn_container_left_new" style=" width:300px; height:456px; margin-left:-10px;background-color:#DCDCDC;border-radius: 1%;">
                    
                       <div id="innerbox_MidMain_Trans_new" style="width:300px; height:20px;border-bottom-style:solid;  ">

                        <div id="tag_label_transaction_exp_jobb"  >
                            <asp:CheckBox ID="cbAll" runat="server" TabIndex="12" ForeColor="White" Font-Bold="true" font-size= "14px" Text="Select All" onclick="CheckAll();" />
                        </div>
                          <div id="tag_label_transaction_exp_jobb" >
                             <span style="color:White;" > <asp:Literal ID="lbl_Loc" runat="server"></asp:Literal> </span>
                        </div>
                        </div>
                         
                         <div id="tag_label_transaction_exp_jobb" style="width: 300px;overflow:auto; height:350px;" >
                                <asp:CheckBoxList ID="cbList" runat="server" ValidationGroup="VGroup" onclick="UnCheckAll();" TabIndex="13"
                                 BorderStyle="none" CssClass=" txtbox_none_Mid_transac_pop_gen" width= "1070px" Height="22px"
                                   Font-Size="11px"  RepeatDirection="Vertical">
                                    </asp:CheckBoxList>
                         </div>
                        <div id="tag_transac_lft_in1" style=" width:300px">
                            
                            <div id="editbu">
                                    <asp:Button ID="btnsup" runat="server" TabIndex="27" onclick="btnsup_Click"/>
                            </div>
                            <div id="editbu">
                            </div>
                            
                            <%--<div id="editbu">
                                <asp:Button ID="btnExpHead_Delete" runat="server" TabIndex="41"  CssClass="dlete"
                                CausesValidation="false"
                                UseSubmitBehavior="false"
                                    OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Expenses', function(r) {
                                    var i = r + 'ok';
                                      if(i == 'trueok')
                                      {
                                          document.getElementById('btn1').click();
                                      }
                                      else {
                                      }
                                     });return false;" />
                                <asp:Button ID="btn1" runat="server" TabIndex="43" 
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />
                            </div>--%>
                            
                        </div>
                       
                        
                        
                    </div>
                    <%----R----%>
                    <div id="pop_text_area_transac_popup_inn_container_rght_new" style="float:left; width:880px; height:456px;">

                     <div id="tag_transac_lft_in1" style="width:875px" >
                            <div id="tag_label_transaction_popup_gen" style="width:60px;">
                                S.no </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:70px">
                                 <asp:DropDownList ID="ddl_Sno" class="chosen-select-deselect" data-placeholder="Choose a Sno"
                                  Width="60px" runat="server" TabIndex="48" >
                                     <asp:ListItem  Text="1" Value="1" ></asp:ListItem>
                                     <asp:ListItem  Text="2" Value="2" ></asp:ListItem>
                                     <asp:ListItem  Text="3" Value="3" ></asp:ListItem>
                                     <asp:ListItem  Text="4" Value="4" ></asp:ListItem>
                                     <asp:ListItem  Text="5" Value="5" ></asp:ListItem>
                                     <asp:ListItem  Text="6" Value="6" ></asp:ListItem>
                                     <asp:ListItem  Text="7" Value="7" ></asp:ListItem>
                                     <asp:ListItem  Text="8" Value="8" ></asp:ListItem>
                                     <asp:ListItem  Text="9" Value="9" ></asp:ListItem>
                                     <asp:ListItem  Text="10" Value="10" ></asp:ListItem>
                                     <asp:ListItem  Text="11" Value="11" ></asp:ListItem>
                                     <asp:ListItem  Text="12" Value="12" ></asp:ListItem>
                                     <asp:ListItem  Text="13" Value="13" ></asp:ListItem>
                                     <asp:ListItem  Text="14" Value="14" ></asp:ListItem>
                                     <asp:ListItem  Text="15" Value="15" ></asp:ListItem>
                                     <asp:ListItem  Text="16" Value="16" ></asp:ListItem>
                                     <asp:ListItem  Text="17" Value="17" ></asp:ListItem>
                                     <asp:ListItem  Text="18" Value="18" ></asp:ListItem>
                                     <asp:ListItem  Text="19" Value="19" ></asp:ListItem>
                                     <asp:ListItem  Text="20" Value="20" ></asp:ListItem>
                                     <asp:ListItem  Text="21" Value="21" ></asp:ListItem>
                                     <asp:ListItem  Text="22" Value="22" ></asp:ListItem>
                                     <asp:ListItem  Text="23" Value="23" ></asp:ListItem>
                                     <asp:ListItem  Text="24" Value="24" ></asp:ListItem>
                                     <asp:ListItem  Text="25" Value="25" ></asp:ListItem>
                                    </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width:60px">
                                Services
                                </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:390px">
                                 <asp:DropDownList ID="ddl_Charge_Name" class="chosen-select-deselect" data-placeholder="Choose a Service Name" Font-Size="8pt"
                                  Width="380px" runat="server" TabIndex="48" >
                                    </asp:DropDownList>
                                     </div>
                                     <div id="tag_label_transaction_popup_gen" style="width:60px">
                                         
                                      </div>
                          </div>

                        <div id="SL_Div" runat="server">
                        <div id="tag_transac_lft_in1" style="width:875px;margin-top:5px;" >
                            <div id="tag_label_transaction_popup_gen" style="width:60px">
                                LCL</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                 <asp:TextBox ID="txt_LCL" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>

                             <div id="tag_label_transaction_popup_gen" style="width:65px">
                                Based on</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:130px">
                                 <asp:DropDownList ID="ddl_LCL_Based_On" class="chosen-select-deselect" data-placeholder="Choose a Based on"
                                  Width="120px" runat="server" TabIndex="48" >
                                 
                                 </asp:DropDownList>  
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Per Value(%)</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_LCL_Percentage" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                    ></asp:TextBox> 

                            </div>
                            
                            <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Min Amount</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_LCL_Min_Amt" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                             <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Max Amount</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_LCL_Max_Amt" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                            
                        </div>
                        <div id="tag_transac_lft_in1" style="width:875px;margin-top:5px;" >
                            <div id="tag_label_transaction_popup_gen" style="width:60px">
                                FCL (20ft)</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                  <asp:TextBox ID="txt_Fcl_20ft" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>

                            
                             <div id="tag_label_transaction_popup_gen" style="width:65px">
                                Based on</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:130px">
                                 <asp:DropDownList ID="ddl_FCL_20_Based_On" class="chosen-select-deselect" data-placeholder="Choose a Based on"
                                  Width="120px" runat="server" TabIndex="48" >
                                 </asp:DropDownList>  
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Per Value(%)</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_FCL_20_Percentage" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                    ></asp:TextBox> 
                            </div>
                            
                            <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Min Amount</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_FCL_20_Min_Amt" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                             <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Max Amount</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_FCL_20_Max_Amt" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                        </div>

                        <div id="tag_transac_lft_in1" style="width:875px;margin-top:5px;" >
                            <div id="tag_label_transaction_popup_gen" style="width:60px">
                                FCL (40ft)</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                 <asp:TextBox ID="txt_Fcl_40ft" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                            
                             <div id="tag_label_transaction_popup_gen" style="width:65px">
                                Based on</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:130px">
                                 <asp:DropDownList ID="ddl_FCL_40_Based_On" class="chosen-select-deselect" data-placeholder="Choose a Based on"
                                  Width="120px" runat="server" TabIndex="48" >
                                  
                                 </asp:DropDownList>  
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Per Value(%)</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_FCL_40_Percentage" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                    ></asp:TextBox> 
                            </div>
                            
                            <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Min Amount</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_FCL_40_Min_Amt" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                             <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Max Amount</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_FCL_40_Max_Amt" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                            
                        </div>
                        <div id="tag_transac_lft_in1" style="width:875px;margin-top:5px;" >
                            <div id="tag_label_transaction_popup_gen" style="width:60px">
                                Bond</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                 <asp:TextBox ID="txt_Bond_Ex_bond_Bulk" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width:65px">
                                Based on</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:130px">
                                 <asp:DropDownList ID="ddl_Bond_Ex_bond_Bulk" class="chosen-select-deselect" data-placeholder="Choose a Based on"
                                  Width="120px" runat="server" TabIndex="48" >
                                 </asp:DropDownList>  
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Per Value(%)</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_Bond_Ex_bond_Bulk_Percentage" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" 
                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                    ></asp:TextBox> 
                            </div>
                            
                            <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Min Amount</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_Bond_Ex_bond_Bulk_Min_Amt" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                             <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Max Amount</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_Bond_Ex_bond_Bulk_Max_Amt" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                        </div>
                        </div>
                        <div id="Air_Div" runat="server">
                        <div id="tag_transac_lft_in1" style="width:875px;margin-top:5px;" >
                            <div id="tag_label_transaction_popup_gen" style="width:60px">
                                Air(Amt)</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_Amount" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox>
                            </div>
                            
                             <div id="tag_label_transaction_popup_gen" style="width:65px">
                                Based on</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:130px">
                                  <asp:DropDownList ID="ddl_Based_On" class="chosen-select-deselect" data-placeholder="Choose a Based on"
                                  Width="120px" runat="server" TabIndex="48" >
                                  </asp:DropDownList>
                                   
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Per Value(%)</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                  <asp:TextBox ID="txt_Percentage" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                  ClientIDMode="Static" TabIndex="50" 
                                   onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);"
                                  ></asp:TextBox>
                                     
                            </div>
                            
                            <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Min Amount</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                     <asp:TextBox ID="txt_Min_Amt" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox>
                                    
                            </div>
                             <div id="tag_label_transaction_popup_gen" style="width:85px">
                                Max Amount</div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:90px">
                                <asp:TextBox ID="txt_Max_Amt" runat="server" Width="80px" Height="20px" MaxLength="10" CssClass="txtbox_none_Mid_transac_item_maindet"
                                    ClientIDMode="Static" TabIndex="50" onkeypress="return pin(event)"></asp:TextBox> 
                            </div>
                            
                        </div>
                        </div>
                        <div id="tag_transac_lft_in1" style="width: 875px">
                            <div id="newbu">
                                <asp:Button ID="btn_Charge_New" runat="server" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                    CausesValidation="false" UseSubmitBehavior="false" TabIndex="60" 
                                    onclick="btn_Charge_New_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btn_Charge_Save" runat="server" CssClass="save" OnClientClick="return validate_Export_License(event)"
                                    TabIndex="54" onclick="btn_Charge_Save_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btn_Charge_Update" runat="server" CssClass="updates" OnClientClick="return validate_Export_License(event)"
                                    TabIndex="55" onclick="btn_Charge_Update_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btn_Charge_Delete" runat="server" TabIndex="57" CssClass="dlete" CausesValidation="false"
                                    UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Job Entry?', 'Job Expenses', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn3').click();
                                          }
                                          else {
                                          }
    
                                });return false;" />
                                <asp:Button ID="btn3" runat="server" TabIndex="59" OnClick="btn_Charge_Delete_Click"
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />  
                            </div>
                             <div id="editbu" style="margin-top:4px;"> &nbsp; &nbsp;
                                <asp:Button ID="btn_Charge_Delete_All" runat="server" TabIndex="61" Text="Delete All"  CausesValidation="false" Visible="false"
                                    UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete All Job(s) Entry?', 'Job Expenses', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn4').click();
                                          }
                                          else {
                                          }
                                });return false;" />
                                <asp:Button ID="btn4" runat="server" TabIndex="62"  OnClick="btnJob_Delete_All_Click" 
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />  
                            </div>

                            <div id="editbu">
                                <span style="color:Red;" > <asp:Label ID="lbl_Error_Msg" runat="server"  ></asp:Label></span>
                            </div>
                        </div>

                        <%----------------ss----------------------- --%>
                          
                        
                        <div id="tag_transac_lft_in1" style="width:875px;">
                          
                                                <div id="tag_transac_export_rght1_license_Grid_area_new1" style="overflow: auto;
                                                    height: 200px; width:875px; background-color: White;">
                                                    <asp:GridView ID="gv_Charge_Details" runat="server" DataKeyNames="QC_ID,Q_ID,CH_ID,IMP_EXP,TR_MODE" EmptyDataText="NO RECORD FOUND"
                                                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                                        ShowHeaderWhenEmpty="True" PageSize="100" AllowPaging="True" 
                                                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                                        CellPadding="1" CellSpacing="1" HorizontalAlign="Left" OnRowCreated="gv_RowCreated"
                                                        ShowFooter="false" Style="overflow: auto;" 
                                                        onrowdatabound="gv_RowDataBound" 
                                                        onselectedindexchanged="gv_Charge_Details_SelectedIndexChanged">  
                                                        
                                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                                           BorderWidth="1px" />
                                                        <Columns>
                                                        <asp:CommandField ShowSelectButton="True">
                                                                <HeaderStyle CssClass="hideGridColumn" />
                                                                <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:CommandField>
                                    
                                                            

                                                            <asp:BoundField DataField="ORDER_BY" HeaderText="Sl No" HeaderStyle-Width="30px">
                                                                <ItemStyle CssClass="column_style_left" Width="30px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="CHARGE_NAME" HeaderText="Service Name" HeaderStyle-Width="500px">
                                                                <ItemStyle CssClass="column_style_left" Width="500px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="TAX_TYPE" HeaderText="Tax Type" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="column_style_left" Width="100px" />
                                                            </asp:BoundField>
                                                            
                                                             <asp:BoundField DataField="LCL_AMT" HeaderText="LCL Amt" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="column_style_left" Width="100px" />
                                                            </asp:BoundField>
                                                            <%--<asp:BoundField DataField="LCL_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>--%>

                                                            <asp:BoundField DataField="LCL_BASED_ON">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="LCL_PER_VALUE">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                             <asp:BoundField DataField="LCL_MIN_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="LCL_MAX_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>

                                                            <%--<asp:BoundField DataField="FCL_TWENTY_FT_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>--%>
                                                            <asp:BoundField DataField="FCL_TWENTY_FT_AMT" HeaderText="FCL 20 Amt" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="column_style_left" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FCL_TWENTY_BASED_ON">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FCL_TWENTY_PER_VALUE">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FCL_TWENTY_MIN_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FCL_TWENTY_MAX_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>

                                                             <%--<asp:BoundField DataField="FCL_FORTY_FT_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>--%>

                                                             <asp:BoundField DataField="FCL_FORTY_FT_AMT" HeaderText="FCL 40 Amt" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="column_style_left" Width="100px" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="FCL_FORTY_BASED_ON">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FCL_FORTY_PER_VALUE">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FCL_FORTY_MIN_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="FCL_FORTY_MAX_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>

                                                             <asp:BoundField DataField="BOND_EX_BOND_BULK_AMT" HeaderText="Bond Amt" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="column_style_left" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BOND_EX_BOND_BULK_BASED_ON">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BOND_EX_BOND_BULK_PER_VALUE">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BOND_EX_BOND_BULK_MIN_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BOND_EX_BOND_BULK_MAX_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>

                                                            
                                                            <asp:BoundField DataField="AIR_AMT" HeaderText="Air Amt" HeaderStyle-Width="100px">
                                                                <ItemStyle CssClass="column_style_left" Width="100px" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AIR_BASED_ON">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AIR_PER_VALUE">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AIR_MIN_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AIR_MAX_AMT">
                                                              <HeaderStyle CssClass="hideGridColumn" />
                                                              <ItemStyle CssClass="hideGridColumn" />
                                                            </asp:BoundField>

                                                    </Columns>
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                                            NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                                        <PagerStyle CssClass="pager" />
                                                    </asp:GridView>
                        </div>
                    </div>
                    </div>
                        
                    </div>
                </div>
                <%-------------------------------------------------------------------------------%>
                <div  class="content"  id="page-7"  style="display:none;height:440px; width:1194px;">

                <div id="tag_transac_lft_in1" style="width:1150px" >
                            <div id="tag_label_transaction_popup_gen" style="width:60px;">
                                S.no </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:100px">
                                 <asp:DropDownList ID="ddl_Slno_Tr" Width="60px" runat="server" TabIndex="48" >
                                     <asp:ListItem  Text="1" Value="1" ></asp:ListItem>
                                     <asp:ListItem  Text="2" Value="2" ></asp:ListItem>
                                     <asp:ListItem  Text="3" Value="3" ></asp:ListItem>
                                     <asp:ListItem  Text="4" Value="4" ></asp:ListItem>
                                     <asp:ListItem  Text="5" Value="5" ></asp:ListItem>
                                     <asp:ListItem  Text="6" Value="6" ></asp:ListItem>
                                     <asp:ListItem  Text="7" Value="7" ></asp:ListItem>
                                     <asp:ListItem  Text="8" Value="8" ></asp:ListItem>
                                     <asp:ListItem  Text="9" Value="9" ></asp:ListItem>
                                     <asp:ListItem  Text="10" Value="10" ></asp:ListItem>
                                     <asp:ListItem  Text="11" Value="11" ></asp:ListItem>
                                     <asp:ListItem  Text="12" Value="12" ></asp:ListItem>
                                     <asp:ListItem  Text="13" Value="13" ></asp:ListItem>
                                     <asp:ListItem  Text="14" Value="14" ></asp:ListItem>
                                     <asp:ListItem  Text="15" Value="15" ></asp:ListItem>
                                     <asp:ListItem  Text="16" Value="16" ></asp:ListItem>
                                     <asp:ListItem  Text="17" Value="17" ></asp:ListItem>
                                     <asp:ListItem  Text="18" Value="18" ></asp:ListItem>
                                     <asp:ListItem  Text="19" Value="19" ></asp:ListItem>
                                     <asp:ListItem  Text="20" Value="20" ></asp:ListItem>
                                     <asp:ListItem  Text="21" Value="21" ></asp:ListItem>
                                     <asp:ListItem  Text="22" Value="22" ></asp:ListItem>
                                     <asp:ListItem  Text="23" Value="23" ></asp:ListItem>
                                     <asp:ListItem  Text="24" Value="24" ></asp:ListItem>
                                     <asp:ListItem  Text="25" Value="25" ></asp:ListItem>
                                    </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_gen" style="width:60px">
                                Services
                                </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width:390px">
                                 <asp:DropDownList ID="ddl_Tr_Charge_Name"  Font-Size="8pt" Width="380px" runat="server" TabIndex="48">
                                  <asp:ListItem Text="TRANSPORT CHARGES" Value="TRANSPORT CHARGES" ></asp:ListItem>
                                  </asp:DropDownList>
                                     </div>
                          </div>

                    <div id="tag_transac_lft_in1" style="width:1150px; margin-top: 5px;">
                        <div id="tag_label_transaction_popup_gen" style="width: 60px">
                         Type
                         </div>
                         <div id="txtcon-m_transaction_item_maindet" style="width:100px">
                                 <asp:DropDownList ID="ddl_Type_Tr" Width="90px" runat="server" TabIndex="48" >
                                     <asp:ListItem  Text="Air" Value="A" ></asp:ListItem>
                                     <asp:ListItem  Text="LCL" Value="LCL" ></asp:ListItem>
                                     <asp:ListItem  Text="FCL" Value="FCL" ></asp:ListItem>
                                    </asp:DropDownList>
                            </div>
                        <div id="tag_label_transaction_popup_gen" style="width: 65px">
                            Ton / Kgs
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 90px">
                            <asp:DropDownList ID="ddl_Ton_Kg" Width="80px" runat="server" TabIndex="48">
                                <asp:ListItem  Text="Ton" Value="T" ></asp:ListItem>
                                <asp:ListItem  Text="Kgs" Value="K" ></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_gen" style="width: 60px">
                         From
                         </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 90px">
                           <asp:TextBox ID="txt_From" runat="server" Width="80px" Height="20px" MaxLength="10"
                                CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="50"
                                onkeypress="return pin(event)"></asp:TextBox>
                        </div>

                         <div id="tag_label_transaction_popup_gen" style="width: 60px">
                         To
                         </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 90px">
                           <asp:TextBox ID="txt_To" runat="server" Width="80px" Height="20px" MaxLength="10"
                                CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="50"
                                onkeypress="return pin(event)"></asp:TextBox>
                        </div>

                        <div id="tag_label_transaction_popup_gen" style="width: 85px">
                            Amount</div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 90px">
                            <asp:TextBox ID="txt_Tr_Amt" runat="server" Width="80px" Height="20px" MaxLength="10"
                                CssClass="txtbox_none_Mid_transac_item_maindet" ClientIDMode="Static" TabIndex="50"
                                onkeypress="return pin(event)"></asp:TextBox>
                        </div>
                       
                    </div>

                          <%-------------------------------------------%>
                          <div id="tag_transac_lft_in1" style="width: 875px">
                            <div id="newbu">
                                <asp:Button ID="btn_Charge_New_Tr" runat="server" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                    CausesValidation="false" UseSubmitBehavior="false" TabIndex="60" 
                                    onclick="btn_Charge_New_Tr_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btn_Charge_Save_Tr" runat="server" CssClass="save" OnClientClick="return validate_Export_License(event)"
                                    TabIndex="54" onclick="btn_Charge_Save_Tr_Click"  /> 
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btn_Charge_Update_Tr" runat="server" CssClass="updates" OnClientClick="return validate_Export_License(event)"
                                    TabIndex="55"  onclick="btn_Tr_Charge_Update_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btn_Charge_Delete_Tr" runat="server" TabIndex="57" CssClass="dlete" CausesValidation="false"
                                    UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Transport Details?', 'Transport Details', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn6').click();
                                          }
                                          else {
                                          }
    
                                });return false;" />
                                <asp:Button ID="btn6" runat="server" TabIndex="59" OnClick="btn_Charge_Delete_Tr_Click"
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />  
                            </div>
                             <div id="editbu" style="margin-top:4px;"> &nbsp; &nbsp;
                                <asp:Button ID="btn_Charge_Delete_All_Tr" runat="server" TabIndex="61" Text="Delete All"  CausesValidation="false" Visible="false"
                                    UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete All Transport Details?', 'Transport Details', function(r) {
                                        var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn5').click();
                                          }
                                          else {
                                          }
                                });return false;" />
                                <asp:Button ID="btn5" runat="server" TabIndex="62"  OnClick="btnJob_Delete_All_Click" 
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />  
                            </div>

                            <div id="editbu">
                                <span style="color:Red;" > <asp:Label ID="lbl_Error_Msg_Tr" runat="server"  ></asp:Label></span>
                            </div>
                        </div>
                          <%----------------------------------%>

                    <div id="tag_transac_lft_in1" style="width: 1150px;">
                        <div id="tag_transac_export_rght1_license_Grid_area_new1" style="overflow: auto; height: 200px; width: 1100px; background-color: White;">
                            
                            <asp:GridView ID="gv_Trans" runat="server" DataKeyNames="TR_ID,Q_ID"
                                EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="False" BackColor="WhiteSmoke"
                                CssClass="grid-view" Width="100%" ShowHeaderWhenEmpty="True" PageSize="100" AllowPaging="True"
                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                HorizontalAlign="Left" OnRowCreated="gv_RowCreated" ShowFooter="false" Style="overflow: auto;"
                                OnRowDataBound="gv_Trans_RowDataBound" OnSelectedIndexChanged="gv_Trans_SelectedIndexChanged">
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                    <asp:BoundField DataField="ORDER_BY" HeaderText="Sl No" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left" Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CHARGE_NAME" HeaderText="Service Name" HeaderStyle-Width="400px">
                                        <ItemStyle CssClass="column_style_left" Width="400px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TAX_TYPE" HeaderText="Tax Type" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SHIPMENT_TYPE" HeaderText="Type" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="UNIT_TYPE" HeaderText="Ton / Kgs" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FROM_POINT" HeaderText="From" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TO_POINT" HeaderText="To" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left" Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AMOUNT" HeaderText="Amount" HeaderStyle-Width="100px">
                                        <ItemStyle CssClass="column_style_left" Width="100px" />
                                    </asp:BoundField>
                                   
                                </Columns>
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                <PagerStyle CssClass="pager" />
                            </asp:GridView>
                        </div>
                    </div>

                </div>
                <%-----------7e--------------------------------------------------------------------%>
            </div>
            </div>

            <%-- --------------------Test Start----------------------------%>
            <div class="content" id="page-2">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                         page-2
                    </div>
                </div>
                <div class="content" id="page-3">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 350px; width: 980px; overflow: hidden;">
                         page-3
                    </div>
                </div>
                <div class="content" id="page-4">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 425px;">
                       page-4
                    </div>
                </div>
            <%-- --------------------Test End----------------------------%>
            
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Ch_id" runat="server" />
            <asp:HiddenField ID="HDupdate_QC_ID" runat="server" />
            <asp:HiddenField ID="HDupdate_Imp_Exp" runat="server" />
            <asp:HiddenField ID="HDupdate_Tr_Mode" runat="server" />
            <asp:HiddenField ID="HDupdate_Tr_ID" runat="server" />
            
            <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdnVoucherNo" runat="server" />

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

        </ContentTemplate>
    </asp:UpdatePanel>
    </form>

    <script src="../js/Billing/Invoice.js" type="text/javascript"></script>
    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <%--<script src="../js/checkboxJScript.js" type="text/javascript"></script>--%>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <%--<script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>--%>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <script src="../js/Billing/BillingValid.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });


        function close_button() {
            document.getElementById("General").click();
        }
        

    </script>

    
  
</body>
</html>
NVOICE_SLNO"].ToString();
            INVOICE_VALUE = ds.Rows[C]["INVOICE_VALUE"].ToString();
            EXCHANGE_RATE = ds.Rows[C]["EXCHANGE_RATE"].ToString();
            FREIGHT_RATE = ds.Rows[C]["FREIGHT_RATE"].ToString();
            INSURANCE_RATE = ds.Rows[C]["INSURANCE_RATE"].ToString();
            TERMS = ds.Rows[C]["TERMS"].ToString();
            if (INVOICE_VALUE == "")
                INVOICE_VALUE = "0.00";
            if (EXCHANGE_RATE == "")
                EXCHA