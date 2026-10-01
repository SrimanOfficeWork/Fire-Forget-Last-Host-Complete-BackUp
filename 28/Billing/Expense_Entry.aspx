<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Expense_Entry.aspx.cs" Inherits="Expense_Entry_PathTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Expense Entry</title>
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
    <script src="../js/Export_Jscript/Export_Cess.js" type="text/javascript"></script>
    <script src="../js/Billing/Quote.js" type="text/javascript"></script>
    <script src="../js/Billing/ExpenseEntry.js" type="text/javascript"></script>

    <script>
        function Show_FileName() {
            var name = document.getElementById('btn_upload').click(); ;
            alert(name);
        }
    
    </script>

     <script type="text/javascript">
         function CallingServerSideFunction() {
             PageMethods.DeleteFile();
         }
    </script>

         <script type="text/javascript">
             function CallingServerSideFunction_Dwnld() {
                 PageMethods.GetData_DwnLoad();
             }
    </script>

    <script type="text/javascript">
        function getid(val) {
            
            var value = val;
            hdn_Function.value = value;
            
        }
    </script>

    <script type="text/javascript">
        function Num_Dot_Spl(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 32 && (charCode < 65 || charCode > 91) && (charCode < 97 || charCode > 122) && (charCode < 48 || charCode > 57) && (charCode < 40 || charCode > 41) && (charCode < 93 || charCode > 93) && (charCode < 46 || charCode > 46))
                return false;
            return true;
        }
    </script>

    <style type="text/css">
        .hideGridColumn
        {
            display: none;
        }
    </style>

    <style type="text/css">
    .search{
    background:url(../imagesdwnld.jpg);
    background-repeat: no-repeat;
    width:15px;
    height:15px;
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
                        Expense Entry Test
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                    
                </div>
                <div id="tag_transact_src_inner" style="width: 1000px">
                    <div id="tag_Exchange_inner_lft">
                        <div id="tag_transact_lft_in1">
                            <div id="Div1" style="width: 1000px; margin-top: 10px;">
                                <div id="tag_label_transaction_Src_new">
                                    Select Type
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:DropDownList ID="ddlSelect_Type" runat="server" CssClass="listtxt_transac_src1"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddlSelect_Type_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src">
                                    Select Branch
                                </div>
                                <div id="txtcon-m_transaction_list1_bondtype">
                                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="listtxt_transac_bondtype"
                                        AutoPostBack="True" 
                                        onselectedindexchanged="ddlBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2">
                                    Job No
                                </div>
                                <div id="txtcon-m_transaction_code">
                                    <asp:DropDownList ID="ddlJobNo" runat="server" CssClass="listtxt_transac_src1"   AutoPostBack="True" 
                                        onselectedindexchanged="ddlJobNo_SelectedIndexChanged">
                                    </asp:DropDownList>

                                    
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div id="innerbox_MidMain_Trans_new" style="background-image:none">
                
                <div class="content" id="page-1" style="overflow:scroll;height:520px;width:960px;">
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height:165px; width:680px;">
                         <div id="tag_transac_exp_drawback" style="width:680px">
                        <div id="tag_label_transaction_exp_jobb">
                            Exp No
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1" style="width:200px">
                         <asp:TextBox ID="txtExp_No" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="1" CssClass=" validate[required] txtbox_none_Mid_transac_code"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                            Exp Date
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtExp_Date" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="2" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>

                                                 <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtExp_Date"
                                    Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                    CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                    CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                    Enabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtExp_Date"
                                    Format="dd/MM/yyyy" Enabled="True">
                                </asp:CalendarExtender>


                        </div>    
                        
                    </div>

                     <div id="tag_transac_exp_drawback" style="width:680px">
                        <div id="tag_label_transaction_exp_jobb">
                            Exp Name
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1" style="width:200px">
                         <asp:TextBox ID="txtExp_Name" runat="server" MaxLength="35"  Width="200px"
                                          TabIndex="3" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </div>
                       <div id="magnify_area">
                         <a href="#" class="magnfy"  onclick="jQuery('#form1').validationEngine('hideAll');opennew_chargemaster('Expense'); return false">
                                 </a>
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                        Cash Mode
                        </div>
                    <div id="txtcon-m_transaction_pop_gen1">
                          <asp:DropDownList ID="ddlCash_Mode" runat="server" CssClass="listtxt_transac_src1"  TabIndex="4" >                                           
                                        </asp:DropDownList>
                        </div>
                    </div>


                    <div id="tag_transac_exp_drawback" style="width:680px">
                    <div id="tag_label_transaction_exp_jobb">
                            Cash Amount
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1" style="width:200px">
                          <asp:TextBox ID="txtCash_Amount" runat="server" MaxLength="35" ClientIDMode="Static"
                                                TabIndex="5" CssClass="txtbox_none_Mid_transac_code"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                       <div id="tag_label_transaction_exp_jobb">
                            Receivable Person
                        </div>
                           <div id="txtcon-m_transaction_pop_gen1">
                         <asp:TextBox ID="txtReceivable_Person" runat="server" MaxLength="35" ClientIDMode="Static" Width="180px"
                                                TabIndex="6" CssClass=" txtbox_none_Mid_transac_pop_gen"></asp:TextBox>
                        </div>                    
                    </div>
                   
                <div id="tag_transac_exp_drawback" style="width:680px">
                        <div id="tag_label_transaction_exp_jobb">
                           Amt Transfer To
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1" style="width:200px">
                            <asp:TextBox ID="txtAmt_TransferTo" runat="server" ClientIDMode="Static"  Width="200px"
                                CssClass="txtbox_none_Mid_transac_pop_gen" MaxLength="35" TabIndex="7"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                        <div id="tag_label_transaction_exp_jobb">
                           File Upload
                        </div>
                       <div id="txtcon-m_transaction_pop_gen1" style="width:200px;">
                        <%--<asp:FileUpload ID="FileUpload1" runat="server"  onchange="Show_FileName();"/>--%>
                         <asp:FileUpload ID="FileUpload1" runat="server" Width="180px" onchange="document.getElementById('btn_upload').click();"/>
                        </div>

                         <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click"  Text="Upload" Style="display: none;"/>
                             

                          <%--<asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" 
                             Style="display: none;" />--%>

                             <%--<asp:Image ID="Image1" runat="server" Visible="false"  onmouseover="Big(this);" onmouseout="Small(this);"/>--%>

                        
                    </div>
                    

                    <div id="tag_transac_exports_item_margs_nos_others_new1" style="width:640px; height:49px;">
                        <div id="tag_label_transaction_exp_jobb">
                           Remarks
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1">
                            <asp:TextBox ID="txtRemarks" runat="server" ClientIDMode="Static"  TextMode="MultiLine"
                                CssClass="txtbox_none_Mid_transac_item_gen_decs_EXP" MaxLength="35" TabIndex="8"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                        </div>
                       
                    </div>            
                 </div> 
                        
                                   <div id="tag_transac_exp_drawback"  style="height:160px; width:260px;"> 
                                     <div id="tag_label_transaction_exp_jobb">
                                       
                                     </div>
                                     
                                     <div id="txtcon-m_transaction_pop_gen1" style="height:50px; width:255px;">

                                        <asp:GridView ID="GV_FILES" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded"
                                         BackColor="WhiteSmoke" CssClass="grid-view" DataKeyNames="FILES"
                                         onrowcreated="GV_FILES_RowCreated" 
                                             onrowdatabound="GV_FILES_RowDataBound" 
                                             onselectedindexchanged="GV_FILES_SelectedIndexChanged" >
                                                <Columns>
                                                                                                      
                                                         <asp:BoundField DataField="FILES" HeaderText="Files" ControlStyle-Width="180px" ControlStyle-Font-Bold="true">
                                                         <ItemStyle CssClass="column_style_left5" Width="200px"  />
                                                        </asp:BoundField> 

                                                       
                                                    
                                                    <asp:TemplateField ControlStyle-Width="40px">
                                                        <ItemTemplate>
                                                          
                                                            <%--<a href="#" id="dwnld" runat="server" onclick="getid('DownLoad');" class="search">DownLoad</a>--%>
                                                             <%--<input id="btn_dwnld" type="button" runat="server" class="search" onclick="getid('DownLoad');"  />--%>
                                                           <input id="btn_Dlete" type="button" runat="server" class="clsicon_new" onclick="getid('Delete');"  />

                                                       
                                                        <%--<a href="#" id="dlt" runat="server" onclick="CallingServerSideFunction();getid('Delete');">Delete</a>--%>

                                                        <%--<asp:Button ID="delete" runat="server" OnClick="DeleteFile" Text="Delete" />--%>

                                                        <%--<asp:LinkButton ID ="lnkDelete" Text="Delete"  runat = "server" OnClick="DeleteFile"  />--%>
                                                            <%--<asp:LinkButton ID ="lnkDelete"  CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                       
                                                    
                                                </Columns>
                                                
                                            </asp:GridView>
                                         </div>
                                   </div>
                                                  
                       <div id="tag_transac_exp_drawback_1" runat="server" style="overflow:scroll; width:930px; height:220px;">

                             <asp:GridView ID="gv_Expense" runat="server" DataKeyNames="EXPENSE_ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                    ShowHeaderWhenEmpty="True" PageSize="5" AllowPaging="True" 
                                    OnRowDataBound="gv_Expense_RowDataBound"
                                    OnPageIndexChanging="gv_Expense_PageIndexChanging" OnSelectedIndexChanged="gv_Expense_SelectedIndexChanged"
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="1" CellSpacing="1" OnRowCreated="gv_Expense_RowCreated">
                                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        BorderWidth="1px" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>
                                        <asp:TemplateField HeaderText="S.No" ControlStyle-Width="50px">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                  
                                         <asp:BoundField DataField="EXP_NO" HeaderText="Exp No" ControlStyle-Width="100px">
                                         <ItemStyle CssClass="column_style_left5" Width="100px" />
                                        </asp:BoundField>                             

                                        <asp:BoundField DataField="EXP_NAME" HeaderText="Exp Name" ControlStyle-Width="250px">
                                            <ItemStyle CssClass="column_style_left5" Width="250px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EXP_DATE" HeaderText="Exp Date" ControlStyle-Width="80px">
                                            <ItemStyle CssClass="column_style_left5"  Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CASH_MODE" HeaderText="Cash Mode" ControlStyle-Width="75px">
                                            <ItemStyle CssClass="column_style_left5"  Width="75px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="CASH_AMT" HeaderText="Cash Amount" ControlStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left"  Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="RECEIVABLE_PERSON" HeaderText="Receivable Person" ControlStyle-Width="175px">
                                            <ItemStyle CssClass="column_style_left"  Width="175px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AMT_TRANSFER_TO" HeaderText="Amt Transfer To" ControlStyle-Width="175px">
                                            <ItemStyle CssClass="column_style_left5" Width="175px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="REMARKS">
                                             <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>


                                      <%--  <asp:BoundField DataField="FILE" HeaderText="File">
                                            <ItemStyle CssClass="column_style_left" />
                                        </asp:BoundField>--%>
                                       
                                    </Columns>
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                     <PagerStyle CssClass="pager" />
                                    <EmptyDataTemplate>
                                        NO RECORD FOUND
                                    </EmptyDataTemplate>
                                </asp:GridView>
                        </div>

                         <div id="tag_transac_exp_drawback"></div>
                        <div id="tag_transac_exp_drawback">

                         </div>
                  
             
                <!-- Buttons Place Here -->

                </div></div></div>


                    <div id="innerbox_MidMain_bot_transact_invoice">
               <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" TabIndex="9" CausesValidation="false"
                                        UseSubmitBehavior="false"  
                                        OnClientClick="jQuery('#form1').validationEngine('hide');" 
                                        onclick="btnNew_Click" />
                                </div>
                
                <div id="editbu">
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return validate_Item();"
                        CssClass="save" TabIndex="115" /></div>
                <div id="editbu">
                    <asp:Button ID="btnUpdate" runat="server" Visible="False" 
                        CssClass="updates" OnClientClick="return validate_Item();" TabIndex="115" 
                        onclick="btnUpdate_Click" /></div>
                <div id="editbu">
                    <asp:Button ID="btnDelete" runat="server" TabIndex="116" Visible="false" CssClass="dlete"
                        OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Entry?', 'PRODUCT', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                    <asp:Button ID="btn" runat="server" TabIndex="116" OnClick="btnDelete_Click" OnClientClick="return validate_Item();"
                        CssClass="dlete" Style="display: none;" />
                </div>
                <div id="editbu">
                <%--  <asp:Button ID="btnCancel" runat="server" class="scancel" onclick="parent.parent.adcodewindow.hide()"
                        tabindex="117" />--%>
                       </div>

              
                <div style="display: none;">
                    <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" ClientIDMode="Static" />
                   

                    <asp:HiddenField ID="hdn_filename" runat="server" />
                    <asp:HiddenField ID="Hdn_Path" runat="server" />
                    <asp:HiddenField ID="hdn_save_update" runat="server" />
                    <asp:HiddenField ID="hdn_Function" runat="server" />

                    
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
