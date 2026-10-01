<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Billing_Party.aspx.cs"
    Inherits="Billing_Party" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Billing Party Entry </title>
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
        
        .rbl input[type="radio"]
            {
               margin-left: 12px;
               margin-right: 1px;
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
    
    <script type="text/javascript">
        function Char_Inv(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
                return false;
            return true;
        }
    </script>
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
    
    <script src="../js/js_bootstrap/jquery.min.js" type="text/javascript"></script>
       <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>

    

    <style type="text/css">
        .mydatagrid
        {
            width: 80%;
            border: solid 2px black;
            min-width: 80%;
        }
        .header
        {
            background-color: #6a6a6a;
            font-family: Arial;
            color: White;
            height: 20px;
            text-align: center;
            font-size: 12px;
        }
        .rows
        {
            background-color: #fff;
            font-family: Arial;
            font-size: 12px;
            color: #000;
            min-height: 13px;
            text-align: left;
        }
        .rows:hover
        {
            background-color: #fadd7a;
            color: #000;
        }
        
        .mydatagrid a /** FOR THE PAGING ICONS **/
        {
            background-color: Transparent;
            padding: 5px 5px 5px 5px;
            color: #fff;
            text-decoration: none;
            font-weight: bold;
        }
        
        .mydatagrid a:hover /** FOR THE PAGING ICONS HOVER STYLES**/
        {
            background-color: #fff;
            color: #000;
        }
        .mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
        {
            padding: 5px 5px 5px 5px;
            background-color: #000;
            color: #fff;
        }
        .pager
        {
            background-color: #fadd7a;
            font-family: Arial;
            color: White;
            height: 30px;
            text-align: left;
        }
        
        .mydatagrid td
        {
            padding: 5px;
        }
        .mydatagrid th
        {
            padding: 5px;
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
            <div id="innerbox_MidMain_Billing" style="height: 30px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                        Bill Party
                    </div>
                     <div id="verslic">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 0px;">
                        
                        <div id="txtcon-m_Exchange" style="width: 100px; margin-top: 5px;">
                           Party Name
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 400px; margin-top: 5px; color: Red;">
                               <asp:TextBox ID="txt_Partyname" CssClass=" txtbox_none_Mid_transac_src" Width="380px"
                                    TabIndex="4" runat="server"></asp:TextBox>
                        </div>
                         <div id="txtcon-m_Exchange" style="width: 80px; margin-top: 5px;">
                         IEC No.
                         </div>
                        
                        <div id="txtcon-m_Exchange" style="width: 130px; margin-top: 5px; color: Red;">
                          <asp:TextBox ID="txt_IEC_No" CssClass=" txtbox_none_Mid_transac_code" Width="130px"
                                    TabIndex="5" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
                
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div class="content" id="page-1" style="margin-top: -40px;">
                <%---28 --%>
                <div id="innerbox_MidMain_Trans_new" style="height: 480px; width: 1150px; margin-left: -16px;
                    margin-top: -5px;">
                    <ol id="toc_new">
                        <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page1('0');"
                            id="Page_A" runat="server"><span>General </span></a></li>
                        <li><a href="#page-7" runat="server">
                        </a></li>
                        <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page3('0');"
                            id="Page_C" runat="server" visible="false"><span>Gen -3</span></a></li>
                        <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');B_G_tab_page4('0');"
                            id="Page_D" runat="server" visible="false"><span>Gen -4 </span></a></li>
                    </ol>
                    <div class="content" id="page-6">
                    <div id="pop_text_area_transac_popup_inn_container_new" style="width:1130px">
                    <div id="pop_text_area_transac_popup_inn_container_left_new" style=" width:1125px;border-radius: 1%;">
                    
                     <%---------------------------------------Row 2-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1185px; height: 35px;">
                            <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                    Branch No
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_Branch" CssClass="txtbox_none_Mid_transac_Inv_No" Width="100px"
                                        TabIndex="6" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                         <%---------------------------------------Row 2-----------------------------------------%>
                         <div id="tag_transact_lft_in1" style="width: 1185px;height:35px;">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                   Address 1 
                                </div>
                                
                                <div id="txtcon-m_Exchange" style="width: 260px;"> 
                                  <asp:TextBox ID="txt_Add_1" runat="server" Width="255px" MaxLength="250" onkeyup="autotab(this);" ClientIDMode="Static" onblur="return ChangeCase(this);"
                                   onkeypress="return Char_Inv(event)"  
                                   CssClass="txtbox_none_Mid_transac_exp_invoice_addr" TabIndex="10" ></asp:TextBox>
                                </div>
                            </div>

                             <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                  Address 2 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 180px;">
                                   <asp:TextBox ID="txt_Add_2" runat="server" MaxLength="200" onkeyup="autotab(this);"
                                    Width="175px" CssClass="txtbox_none_Mid_transac_exp_invoice_addr" TabIndex="12"></asp:TextBox>
                                </div>
                            </div>
                            
                              <div id="txt_container_Transact_Main_l" style="width: 210px;">
                                <div id="tag_label_transact_Src" style="width: 50px;">
                                  City 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 140px;">
                                   <asp:TextBox ID="txt_City" runat="server" MaxLength="150" onkeyup="autotab(this);"
                                                   Width="130px" CssClass="txtbox_none_Mid_transac_exp_invoice_addr" TabIndex="13"></asp:TextBox>
                                </div>
                            </div>
                             <div id="txt_container_Transact_Main_l" style="width: 220px;">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                 Pin Code
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 135px;">
                                   <asp:TextBox ID="txt_Pin_code" runat="server" MaxLength="50"  onkeyup="autotab(this);"
                                      Width="130px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="14"></asp:TextBox>
                                </div>
                            </div>
                            
                             

                        </div>
                        <%---------------------------------------Row 2-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1185px; height: 35px;">
                            <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                <div id="tag_label_transact_Src" style="width: 80px; font-size: 12px;">
                                    State Name
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 260px;">
                                 <asp:XmlDataSource ID="XmlState_Name_Code" runat="server"  DataFile="~/Accounts_XML_Data/State_Name_Code.xml" 
                                  XPath="ListItems/ListItem"></asp:XmlDataSource>

                                    <asp:DropDownList ID="ddl_state_name" class="chosen-select-deselect" runat="server"
                                        DataSourceID="XmlState_Name_Code" DataTextField="text" DataValueField="value"
                                        Style="width: 258px;" data-placeholder="Choose a State Name" TabIndex="15" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 280px;">
                                <div id="tag_label_transact_Src" style="width: 90px; font-size: 12px;">
                                    GST Number
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 180px;">
                                    <asp:TextBox ID="txt_Gst_Number" runat="server" MaxLength="50" onkeyup="autotab(this);"
                                        Width="175px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="16"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 250px">
                                <div id="tag_label_transact_Src" style="width: 100px">
                                    Pan / Tan No.
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 150px">
                                    <asp:TextBox ID="txt_Pan_Tan_No" runat="server" Width="130px" MaxLength="100" onkeyup="autotab(this);"
                                        CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="17"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 260px">
                                <div id="txtcon-m_Exchange" style="width: 170px">
                                    <asp:RadioButtonList ID="Rd_Active_Inactive" runat="server" TabIndex="18" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="Active" Value="A" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="In-Active" Value="IA"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>

                        <%---------------------------------------Row 2-----------------------------------------%>

                        <%---------------------------------------Row 2-----------------------------------------%>
                        <div id="tag_transac_lft_in1" style="width: 460px">
                            <div id="newbu">
                                <asp:Button ID="btnNew" runat="server" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                    CausesValidation="false" UseSubmitBehavior="false" TabIndex="40" OnClick="btnNew_Click" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"
                                    OnClientClick="return validate_Export_License(event)" TabIndex="38" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                    OnClientClick="return validate_Export_License(event)" TabIndex="39" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDelete" runat="server" TabIndex="41" CssClass="dlete"
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'Party Entry', function(r) {
                                  var i = r + 'ok';
                                  if(i == 'trueok')
                                  {
                                      document.getElementById('btn1').click();
                                  }
                                  else {
                                  }
                                });return false;" />
                                <asp:Button ID="btn1" runat="server" TabIndex="43" OnClick="btnDelete_Click"
                                    CausesValidation="false" UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                    CssClass="dlete" Style="display: none;" />
                            </div>
                        </div>
                       
                        <div id="tag_transac_lft_in1" style="width:1120px">

                            <asp:GridView ID="gv_Party" runat="server" DataKeyNames="C_ID,IEC_NO" EmptyDataText="NO RECORD FOUND"
                                AutoGenerateColumns="False" Width="100%" ShowHeaderWhenEmpty="True" PageSize="7"
                                BackColor="WhiteSmoke" CssClass="grid-view" AllowPaging="false" OnRowCreated="gv_Party_RowCreated"
                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                OnRowDataBound="gv_Party_RowDataBound" OnSelectedIndexChanged="gv_Party_SelectedIndexChanged">
                                
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" />
                                    
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                    </asp:CommandField>
                                  
                                    <asp:BoundField DataField="BR_SLNO" HeaderText="Br. No" HeaderStyle-Width="100px">
                                <ItemStyle CssClass="column_style_left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ADD_I" HeaderText="Address1" HeaderStyle-Width="400px">
                                <ItemStyle CssClass="column_style_left" Width="400px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CITY" HeaderText="City" HeaderStyle-Width="300px">
                                <ItemStyle CssClass="column_style_left" Width="300px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="STATE_CODE" HeaderText="State Code" HeaderStyle-Width="200px">
                                <ItemStyle CssClass="column_style_left" Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GSTN_ID" HeaderText="GSTN. Id" HeaderStyle-Width="150px">
                                <ItemStyle CssClass="column_style_left" Width="150px"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="INACTIVE_ACTIVE" HeaderText="Active / Inactive" HeaderStyle-Width="100px">
                                <ItemStyle CssClass="column_style_left" Width="100px"/>
                            </asp:BoundField>

                             <asp:BoundField DataField="CLIENT_NAME">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="ADD_I">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="ADD_II">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="PIN_CODE">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>
                               <asp:BoundField DataField="TAN_PAN_NO">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                              </asp:BoundField>

                                    
                                </Columns>
                               
                            </asp:GridView>


                        </div>
                    </div>
                   
                    
                        
                    </div>
                </div>
                <%-------------------------------------------------------------------------------%>
            </div>
            <%-- --------------------Test Start----------------------------%>
            
            <%-- --------------------Test End----------------------------%>
            </div>
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8']);
            </script>
            <asp:HiddenField ID="HDupdate_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Ch_id" runat="server" />
            <asp:HiddenField ID="HDupdate_Imp_Exp" runat="server" />
            <asp:HiddenField ID="HDupdate_Tr_Mode" runat="server" />
            <asp:HiddenField ID="HDupdate_Line_Id" runat="server" />
            <asp:HiddenField ID="HDupdate_Job_Id" runat="server" />

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
