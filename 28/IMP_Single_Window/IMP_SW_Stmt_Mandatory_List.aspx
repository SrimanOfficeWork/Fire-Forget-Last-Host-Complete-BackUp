<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IMP_SW_Stmt_Mandatory_List.aspx.cs" Inherits="IMP_SW_Stmt_Mandatory_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Supporting Douments Bulk Entry </title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />  
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!
    -- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
  
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });
    </script>

    <script type="text/javascript">

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>

    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            height: 5em;
            line-height: 0em;
            text-align: left;
           max-width:50px;
            
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            height: 5em;
            line-height: 0em;
            text-align: left;
            max-width:50px;
            
        }
    </style>
    <style type="text/css">
        .multiselect-container
        {
            max-height: 200px;
            overflow-y: auto;
            height: 250px;
        }
    </style>
    <style type="text/css">
        .txtbox_none_Mid_transac_item_other_rmarks_new1_LC
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            margin-top: 2px;
            width: 385px;
            max-width: 385px;
            height: 350px;
            max-height: 350px;
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
            overflow: auto;
        }
        
        
    </style>
   
   

    <script type="text/javascript">

        $(document).ready(function () {

            var icegateid = document.getElementById("hdn_ICEGATE_ID_List").value;

            var Notn = icegateid.split(', ').map(String);

            if (icegateid != '') {
                $(".autocomplete").autocomplete({
                    source: Notn,
                    minLength: 0,
                    scroll: true
                }).focus(function () {
                    $(this).autocomplete("search", "");
                });
            }

        });

    </script>


     <script type="text/javascript">
         $(document).ready(function () {

             $('#btn_Refresh').click(function () {
                 var jobno = document.getElementById("hdn_jobno").value;

                 window.close();

                 if (jobno != '') {
                     NewWindow1('../IMP_Single_Window/Imp_SupDocs_Bulk.aspx?JOBID=' + jobno + '', 'List', '1100', '1024', 'yes');
                 }
                 else {
                     alert('Select a Job');
                 }
             });

         });
</script>


    <style>
        .btnhide
        {
            visibility: hidden;
        }
    </style>

    
    
     <script src="../js/js_bootstrap/jquery.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap-multiselect.js" type="text/javascript"></script>


    <script type="text/javascript">

        $(function () {
            $('[id*=ListBox_INVSlno]').multiselect({

                includeSelectAllOption: true
                
            });
        });

        $(function () {
            $('[id*=ListBox_ItemSlno]').multiselect({

                includeSelectAllOption: true
            });
        });  
</script> 

 <script type = "text/javascript">

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
                         row.style.backgroundColor = "#C2D69B";
                     }
                     else {
                         row.style.backgroundColor = "white";
                     }
                     inputList[i].checked = false;
                 }
             }
         }
     }

</script>


    
    <script type="text/javascript">
        $(function () {
            $(document).on('click', '#btnsave', function () {
                var trs = $('[id*=gvdetails]').closest('tr:not(":has(th)")');
                $(trs).each(function () {
                    if ($(this).find('[id*=chkRow]')[0].checked) {
                        var Image_RefNo = $(this).find("[id*=txtImage_RefNo]").val().trim();
                        alert(Image_RefNo);
                        //                        var customerName = $(this).find("[id*=txtCustomerName]").val().trim();
                        //                        var custMobile = $(this).find("[id*=txtCustMobile]").val().trim();
                        //                        var civilId = $(this).find("[id*=txtCivilId]").val().trim();
                        //                        var deposit = $(this).find("[id*=txtDeposit]").val().trim();
                        //                        if (plate == "" || customerName == "" || custMobile == "" || civilId == "" || deposit == "") {
                        if (Image_RefNo == "") {
                            alert("Required");
                            return false;
                        }
                    }
                });
            });
        });
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

                <div id="innerbox_MidMain_Grid" style="height:280px; width:360px;">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:320px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 400px; font-size: 14px; text-align:center; ">
                       Import SW - Documents Mandatory List</div>
                    
                </div>

                    <div id="tag_srcinner1" style="margin-top: 25px;">
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 520px; 
                            margin-top: 10px;">
                           
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 24px; 
                                color: Blue; font-size: 12px; font-weight: bold;">
                                RITC
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 140px;">
                                <asp:DropDownList ID="ddl_CTH_NO" runat="server" TabIndex="2"  Height="28px" BackColor="LightGray"
                                    CssClass="listtxt_transac_mode_new" AutoPostBack="true"
                                    Width="130px" onselectedindexchanged="ddl_CTH_NO_SelectedIndexChanged" >
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                         
                           
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                          
                        </div>
                    </div>
                 <div id="tag_srcinner1" style="height:10px;"></div>
                   
                     <div id="tag_transac_export_lft_item_gen_Grid_area_Exbond" style="width: 700px; height:170px;">
                                    <asp:GridView ID="gvAll" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                                        BackColor="WhiteSmoke" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                        CellPadding="1" CellSpacing="1" CssClass="grid-view"  EmptyDataText="NO RECORD FOUND"
                                        PageSize="5000" ShowHeaderWhenEmpty="True" Width="100%"
                                        OnRowDataBound="gvAll_RowDataBound" OnRowCreated="gvAll_RowCreated" OnDataBound="gvAll_DataBound">
                                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                            BorderWidth="1px" />
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this);" AutoPostBack="true"
                                                        OnCheckedChanged="CheckBox_CheckChanged" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chk" runat="server" onclick="Check_Click(this)" AutoPostBack="true"
                                                        OnCheckedChanged="CheckBox_CheckChanged" />
                                                </ItemTemplate>
                                                <ItemStyle Width="44px" />
                                            </asp:TemplateField>
                                              <asp:BoundField DataField="SLNO" HeaderText="SLNO" HeaderStyle-Width="30px"
                                                HtmlEncode="false">
                                                   <HeaderStyle CssClass="hideGridColumn" />
                                                   <ItemStyle CssClass="hideGridColumn" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STMT_CODE" HeaderText="STMT_CODE" HeaderStyle-Width="50px"
                                                HtmlEncode="false">
                                                <ItemStyle CssClass="column_style_left5" Width="50px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="STMT_TEXT" HeaderText="STMT_TEXT" HtmlEncode="false"
                                                HeaderStyle-Width="200px">
                                                <ItemStyle CssClass="column_style_left5" Width="200px" />
                                            </asp:BoundField>
                                           
                                        </Columns>
                                    </asp:GridView>
                                </div>

            
           <%-- -------------------------------------Tab--------------------------------------------------------%>

              <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hdn_chked_cnt" runat="server" />
                <asp:HiddenField ID="hdn_jobno" runat="server" />
          
          </div>
            <%----------------------------------Main Div-END----------------------------------------------------------------%>
            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 500px;">
                <div id="txtcon-m_transaction_Supp_code" style="width: 105px;">
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                    <asp:Button ID="btnsave" runat="server" Text="Save" OnClick="btnsave_Click" ToolTip="Current Item"
                        TabIndex="18" Width="100px" Height="30px" ForeColor="Blue" />
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty" style="width: 100px;">
                </div>
                 <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                    <asp:Button ID="btn_Bulksave" runat="server" Text="Bulk Save"   ToolTip="All Items of Same RITC"
                        TabIndex="18" Width="100px" Height="30px" ForeColor="Blue" 
                         onclick="btn_Bulksave_Click" />
                </div>
               
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                </div>
            </div>
            <%-----------------------------------END----------------------------------------------------------------%>
   
    
    <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdnjobno" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:HiddenField ID="confirm_value" runat="server" />



        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    
     

    
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <%--<script src="../js/checkboxJScript.js" type="text/javascript"></script>--%>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>

  <%--  <script src="../js/Import_Jscript/IMP_Single_Window.js" type="text/javascript"></script>--%>


</body>
</html>
