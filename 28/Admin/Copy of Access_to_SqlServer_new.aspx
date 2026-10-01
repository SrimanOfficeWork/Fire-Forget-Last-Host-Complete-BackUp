<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copy of Access_to_SqlServer_new.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link href="../gridmain.css" rel="stylesheet" type="text/css" />
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
    </style>
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>

    <div>
    
           
         
                <div id="innerbox_MidMain_Grid">
                    <div id="tag_srcinner1">
                        <div id="mainmastop2container_rght_tag2_txt1" >
                            DATA CONVERSION ACCESS TO SQL</div>
                            <div style="padding-top:5px;">
                          
                                
            </div>
                    </div><br /><br />
                   
                    

               <div id="innerbox_MidMain_Trans_new" style="width:743px;margin-left:0px;height:553px;">
                <ol id="toc_new">
                    <li><a href="#page-1" onclick="tab_page1();" id="Admin_Master"><span>Admin Master</span></a></li>
                    <li><a href="#page-2" onclick="tab_page2();" id="Master"><span>Master</span></a></li>
                                   </ol>
                                   <br />
                                   <br />
 <%--<div id="tag_transac_lft_trans_item_new1_maintag1">
                     <div id="tag_label_transaction_popup_Item_maindet">
                                   
                                </div>
                                <div id="tag_label_transaction_popup_Item_maindet">
                                    Client Name
                                </div>
                                <div id="txtcon-m_transaction_export_itemnew_gen">
                                    <asp:DropDownList ID="ddl_Client_Database" runat="server" CssClass="txtbox_none_Mid_transac_exp_itemnew"
                                        
                                       >
                                    </asp:DropDownList>
                                </div>
                                
                            </div>--%>
                <div class="content" id="page-1" style="padding: 60px 200px 0px;">
                   
                  
                        <asp:GridView ID="gvdetails" runat="server" ShowHeader="true"  Width="235px" 
                      AutoGenerateColumns="false" OnRowCreated="gvdetails_RowCreated"
                          BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1"
                         EmptyDataText="NO RECORD FOUND" PageSize="10" ShowHeaderWhenEmpty="True"
                        CssClass="grid-view" OnRowDataBound="gvdetails_RowDataBound">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                     <asp:TemplateField>
                   
                                    <HeaderTemplate>
                                    <div style="width:10px;">
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="javascript:SelectheaderCheckboxes(this,'gvdetails')"   />
                                                                        
                                       
                                         </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                         
                                    </ItemTemplate>
                                      
                                </asp:TemplateField>
                          <asp:BoundField DataField="Master_Name" HeaderText="Name">
                           <ItemStyle   CssClass="column_style_left"/>
                                      </asp:BoundField>
                                      
                                   
                                </Columns>
                              
                        </asp:GridView>
                       
                      
                            <asp:Button ID="btnAdmin" runat="server" Text="Admin Upload" onclick="btnAdmin_Click" 
             />
                            
                </div>
                <div class="content" id="page-2" style="display: none;padding: 20px 100px 0px;">
                 <div id="tag_transac_lft_trans_item_new1_maintag1">
                    <%-- <div id="tag_label_transaction_popup_Item_maindet">
                                   
                                </div>--%>
                                <div id="tag_label_transaction_popup_Item_maindet">
                                    Client Name
                                </div>
                                <div id="txtcon-m_transaction_export_itemnew_gen">
                                    <asp:DropDownList ID="ddl_Client_Database" runat="server" CssClass="txtbox_none_Mid_transac_exp_itemnew"
                                        
                                       >
                                    </asp:DropDownList>
                                </div>
                                
                            </div>
                            <div id="tag_transac_lft_trans_item_new1_maintag1">
                  
                                <div id="tag_label_transaction_popup_Item_maindet">
                                    Working Period
                                </div>
                                <div id="txtcon-m_transaction_export_itemnew_gen">
                                    <asp:DropDownList ID="ddlworkingperiod" runat="server" CssClass="txtbox_none_Mid_transac_exp_itemnew"
                                        
                                       >
                                    </asp:DropDownList>
                                </div>
                                
                            </div>
                   <div id="Main_Grid_Container" style="overflow:auto;height:385px;width:520px;padding: 40px 100px 0px;border-style:none">
               
                        <asp:GridView ID="gv_Master" runat="server" ShowHeader="true"  Width="235px" 
                      AutoGenerateColumns="false" OnRowCreated="gv_Master_RowCreated"
                          BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1"
                         EmptyDataText="NO RECORD FOUND" PageSize="10" ShowHeaderWhenEmpty="True"
                        CssClass="grid-view" OnRowDataBound="gv_Master_RowDataBound">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                     <asp:TemplateField>
                   
                                    <HeaderTemplate>
                                    <div style="width:10px;">
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="javascript:SelectheaderCheckboxes(this,'gv_Master')"  />
                                                                        
                                       
                                         </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                         
                                    </ItemTemplate>
                                      
                                </asp:TemplateField>
                          <asp:BoundField DataField="Master_Name" HeaderText="Name">
                           <ItemStyle   CssClass="column_style_left"/>
                                      </asp:BoundField>
                                      
                                   
                                </Columns>
                              
                        </asp:GridView>
                       
                             <asp:Button ID="btnClient" runat="server" Text="Client Upload" onclick="btnClient_Click" OnClientClick="return valid();" />
           </div>
                </div>
                </div>
                 </div>
                    <div style="margin:-550px 0px 0px 780px;">
                     <asp:FileUpload ID="FileUpload1" runat="server" />
                     <asp:Button ID="btnUpload" runat="server" Text="Database Upload" onclick="btnUpload_Click" />
                    </div>
    <div id="innerbox_MidMain_Trans_IGM_Invoice_right_inv_Imp" style="margin:10px 0px 0px 780px;">
   
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_Topcap">
                    Upload Details</div>
                <div id="pop_text_area_transac_popup_inn_container_rght_IGM_invoice_inner">
                     <asp:Button ID="btn_File_Delete" runat="server"  CausesValidation="false" style="display:none;"
                                            UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jConfirm('Delete this File?', 'ACCESS TO SQL', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
          
              document.getElementById('btn1').click();
            
          }
          else {
          }
    
});return false;" />
                                        <asp:Button ID="btn1" runat="server"  OnClick="btn_File_Delete_Click" CausesValidation="false"
                                            UseSubmitBehavior="false" 
                                            CssClass="dlete" Style="display: none;" />
                                            <div style="width:180px;height:150px;overflow:auto;">
                    <asp:GridView ID="GridView1" runat="server" ShowHeader="true"  Width="170px" AllowPaging="True" AllowSorting="True"
                      AutoGenerateColumns="false" OnRowCreated="gvdetails_RowCreated"
                          BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1"
                         EmptyDataText="NO RECORD FOUND" PageSize="10" ShowHeaderWhenEmpty="True"
                        CssClass="grid-view" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                     <asp:TemplateField>
                   
                                    <HeaderTemplate>
                                    <div style="width:10px;">
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="javascript:SelectheaderCheckboxes_file(this,'GridView1','btn_File_Delete')"  />
                                                                        
                                       
                                         </div>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" runat="server" />
                                         
                                    </ItemTemplate>
                                      
                                </asp:TemplateField>
                         
                                      
                                      <asp:TemplateField HeaderText="File">
                                        <ItemTemplate>
                                         <%--<asp:Label ID="txtdate" runat="server" CssClass="column_style_left" Text='<%#Eval("ATTACHMENT_FILE")%>'></asp:Label>--%>
                                          <asp:LinkButton ID="txtdate" runat="server" Text='<%#Eval("filename") %>' OnClick="lnkDownload_Click">
                                        </asp:LinkButton>
                                        </ItemTemplate>
                                       <ItemStyle  Width="350px" CssClass="column_style_left"/>
                                    </asp:TemplateField>

                               <asp:BoundField DataField="filename" >
                                       <HeaderStyle CssClass="hideGridColumn"/>
                                <ItemStyle CssClass="hideGridColumn" /></asp:BoundField>

                                </Columns>
                                  <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                        </asp:GridView>
         </div>
            
                    <div id="tag_label_transaction_popup_IGM_invoice_det2" style="width:185px;height:auto;display:none;" >
                        <asp:Label ID="lblmsg" runat="server"></asp:Label>
                    </div>
                </div>
            
         
                
            </div>
            
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2']);
            </script>
               
       
  
    <asp:HiddenField runat="server" ID="hdn_Server" />
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
     <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
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
            //document.getElementById("btnCancel").click();
            document.getElementById("General").click();
        }


        function tab_page1() {
            document.getElementById("page-1").style.display = 'block';
            document.getElementById("page-2").style.display = 'none';
        }
        function tab_page2() {
            document.getElementById("page-1").style.display = 'none';
            document.getElementById("page-2").style.display = 'block';
        }
        
        function valid() {
            if (document.getElementById("ddl_Client_Database").value != '') {
                if (document.getElementById("ddl_Client_Database").value == 'Select') {
                    jAlert('Please select Client name', 'ACCESS TO SQL', function (r) { document.getElementById("<%=ddl_Client_Database.ClientID %>").focus(); });

                    return false;
                }
            }
            if (document.getElementById("ddlworkingperiod").value != '') {
                if (document.getElementById("ddlworkingperiod").value == 'Select') {
                    jAlert('Please select working period', 'ACCESS TO SQL', function (r) { document.getElementById("<%=ddlworkingperiod.ClientID %>").focus(); });

                    return false;
                }
            }
        }
    </script>
    <script type="text/javascript">
        // Select/Deselect checkboxes based on header checkbox
        function SelectheaderCheckboxes(headerchk, gv) {

            var gvcheck = document.getElementById(gv);


            var i;
            //Condition to check header checkbox selected or not if that is true checked all checkboxes
            if (headerchk.checked) {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = true;

                }


            }
            //if condition fails uncheck all checkboxes in gridview
            else {
                for (i = 0; i < gvcheck.rows.length; i++) {
                    var inputs = gvcheck.rows[i].getElementsByTagName('input');
                    inputs[0].checked = false;
                }
            }
        }
        //function to check header checkbox based on child checkboxes condition
        function Selectchildcheckboxes(header, gv) {

            var ck = header;
            var count = 0;
            var gvcheck = document.getElementById(gv);
            var headerchk = document.getElementById(header);
            var rowcount = gvcheck.rows.length;
            //By using this for loop we will count how many checkboxes has checked
            for (i = 1; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                if (inputs[0].checked) {

                    count++;
                }
            }
            //Condition to check all the checkboxes selected or not
            if (count == rowcount - 1) {
                headerchk.checked = true;

            }
            else {
                headerchk.checked = false;
            }
        }
</script>
<script type="text/javascript">
    // Select/Deselect checkboxes based on header checkbox
    function SelectheaderCheckboxes_file(headerchk, gv, button) {
        debugger
        var gvcheck = document.getElementById(gv);
        var i;
        //Condition to check header checkbox selected or not if that is true checked all checkboxes
        if (headerchk.checked) {
            for (i = 0; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                inputs[0].checked = true;
            }
            document.getElementById(button).click();

        }
        //if condition fails uncheck all checkboxes in gridview
        else {
            for (i = 0; i < gvcheck.rows.length; i++) {
                var inputs = gvcheck.rows[i].getElementsByTagName('input');
                inputs[0].checked = false;
            }
        }
    }
    //function to check header checkbox based on child checkboxes condition
    function Selectchildcheckboxes_file(header, gv, button) {
        var ck = header;
        var count = 0;
        var gvcheck = document.getElementById(gv);
        var headerchk = document.getElementById(header);
        var rowcount = gvcheck.rows.length;
        //By using this for loop we will count how many checkboxes has checked
        for (i = 1; i < gvcheck.rows.length; i++) {
            var inputs = gvcheck.rows[i].getElementsByTagName('input');
            if (inputs[0].checked) {
                document.getElementById(button).click();
                count++;
            }
        }
        //Condition to check all the checkboxes selected or not
        if (count == rowcount - 1) {
            headerchk.checked = true;

        }
        else {
            headerchk.checked = false;
        }
    }
</script>
</body>

</html>
