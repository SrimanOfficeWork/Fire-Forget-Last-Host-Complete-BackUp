<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_SW_SEZ_Bulk.aspx.cs" Inherits="Imp_SW_SEZ_Bulk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import SW SEZ Bulk Entry </title>
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
    <%--<script src="../js/Export_Rpt/BL_Generation.js" type="text/javascript"></script>--%>
    <%--<script src="../js/EGM/EGM_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>
    <script type="text/javascript" src="../js/Export_Jscript/Export_General.js"></script>--%>

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

            var icegateid = document.getElementById("hdn_YN").value;
          
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
                     NewWindow1('../IMP_Single_Window/Imp_SW_SEZ_Bulk.aspx?JOBID=' + jobno + '', 'List', '1100', '1024', 'yes');
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
                         //                         row.style.backgroundColor = "#C2D69B";
                         row.style.backgroundColor = "LightGray";
                     }
                     else {
                         row.style.backgroundColor = "LightGray";
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

                <div id="innerbox_MidMain_Grid" style="height:560px;">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width:1060px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px; font-size: 14px;">
                       Import SW - SEZ Bulk Entry</div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 100px;">
                        <div id="tag_label_transact_Src" style="width: 120px;">
                            <span style="color: Blue; font-size: 14px; font-weight: bold;">Jobno
                                <asp:Literal ID="lbljobno" runat="server"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 650px;"></div>
                     <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                                <asp:Button ID="btn_Refresh" runat="server" Text="Refresh"  TabIndex="100" Font-Bold="true"
                                    Width="90px" Height="28px" ForeColor="Green" onclick="btn_Refresh_Click" />
                            </div>
                </div>

                    <div id="tag_srcinner1" style="margin-top: 25px;">
                        <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1220px;
                            margin-top: 10px;">
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 45px; 
                                color: Blue; font-size: 13px; font-weight: bold; margin-left:-10px;">
                                Action
                            </div>
                            <%--<div id="tag_label_transaction_popup_IGM2_empty">
                            </div>--%>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 80px;">
                                <asp:DropDownList ID="ddl_flg" CssClass="listtxt_transac_item_gen_notn" Width="78px" TabIndex="1" Font-Bold="true" Height="25px"
                                    Font-Size="12px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_flg_SelectedIndexChanged">
                                    <asp:ListItem Text="Save" Value="S"></asp:ListItem>
                                    <asp:ListItem Text="Update" Value="U"></asp:ListItem>
                                    <asp:ListItem Text="Delete" Value="D"></asp:ListItem>
                                    <asp:ListItem Text="View All" Value="V"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 60px;
                                color: Blue; font-size: 13px; font-weight: bold;">
                                Based on
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty" style="color: Red; width: 10px;">
                            </div>
                            <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 90px;">
                                <asp:DropDownList ID="ddl_SelectType1" runat="server" TabIndex="2" CssClass="listtxt_transac_mode_new" AutoPostBack="true"  Height="25px"
                                   Font-Bold="true"  Width="90px" OnSelectedIndexChanged="ddl_SelectType1_SelectedIndexChanged">
                                   <%-- <asp:ListItem Value="JOB">Job </asp:ListItem>--%>
                                    <asp:ListItem Value=""> </asp:ListItem>
                                    <asp:ListItem Value="INVOICE">Invoice </asp:ListItem>
                                    <asp:ListItem Value="ITEM">Item </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 50px;
                                color: Blue; font-size: 12px; font-weight: bold;">
                                Inv Slno
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 120px;">
                                <asp:ListBox ID="ListBox_INVSlno" SelectionMode="Multiple" Height="28px" Width="58px" Visible="false" ViewStateMode="Enabled" style="width:50px"
                                 Font-Bold="true"   runat="server"></asp:ListBox>
                                <asp:DropDownList ID="ddlinvno" CssClass="listtxt_transac_item_gen_notn" Width="98px"  Visible="false"
                                Font-Size="12px" runat="server" TabIndex="3" AutoPostBack="true" OnSelectedIndexChanged="ddlinvno_SelectedIndexChanged">
                            </asp:DropDownList>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 60px;
                                color: Blue; font-size: 12px; font-weight: bold;">
                                Item Slno
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 135px;">
                                <asp:DropDownList ID="ddl_ItemSlno" CssClass="listtxt_transac_item_gen_notn" Visible="false" TabIndex="4" Height="25px"
                                  Font-Bold="true"   Width="100px" Font-Size="12px" runat="server">
                                </asp:DropDownList>
                                <asp:ListBox ID="ListBox_ItemSlno" SelectionMode="Multiple" Height="28px" Width="100px" ViewStateMode="Enabled"
                                    runat="server"></asp:ListBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 79px;
                                color: Blue; font-size: 12px; font-weight: bold;">
                                Department
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 60px;">
                                <asp:TextBox ID="txt_Department" runat="server" MaxLength="16" Width="55px" TabIndex="5"  Height="25px" Text="SEZ" Enabled="false"
                                   Font-Bold="true"  ClientIDMode="Static" onkeypress="return num1(event)" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 55px;
                                color: Blue; font-size: 12px; font-weight: bold;">
                               Info Type
                            </div>
                            <div id="txtcon-m_transaction_item_maindet" style="width: 90px;">
                                <asp:TextBox ID="txt_InfoType" runat="server" Width="80px" TabIndex="6"   Text="DTY - SEZ" Enabled="false" Height="25px"
                                CssClass="txtbox_none_Mid_transac_Supp_Name" Font-Bold="true"  ></asp:TextBox>
                            </div>
                            <div id="tag_label_transaction_popup_IGM2_empty">
                            </div>
                            <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                                <asp:Button ID="btn_Load_Data" runat="server" Text="Load Data" OnClick="btn_Load_Data_Click" TabIndex="7"  Font-Bold="true"
                                    Width="90px" Height="30px" ForeColor="Blue" />
                            </div>
                        </div>
                    </div>
                 <div id="tag_srcinner1" style="height:30px;"></div>
               
            
           <%-- -------------------------------------Tab--------------------------------------------------------%>
                    <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
                    </div>
                    <div id="tag_transac_export_lft_item_gen_Grid_comp" style="width: 1104px; height: 450px;">
                        <asp:GridView runat="server" ID="gvdetails" AutoGenerateColumns="false" OnRowDataBound="gvdetails_RowDataBound"
                            Width="100%" ShowHeader="true" ShowFooter="true" 
                            BackColor="LightGray" ShowHeaderWhenEmpty="true" GridLines="None" BorderStyle="Groove"
                            BorderWidth="1px" CellPadding="1" CellSpacing="1" HeaderStyle-Font-Size="12px">
                            <AlternatingRowStyle BackColor="LightGray" BorderColor="Black" BorderWidth="1px" />
                            <HeaderStyle Font-Underline="false" ForeColor="Black" />
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox runat="server" ID="chkTotalAll" onclick="checkAll(this);" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox runat="server" ID="chk_All" onclick="Check_Click(this)" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-ForeColor="Green" HeaderStyle-Height="20px" HeaderStyle-Font-Bold="true">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_SW_INFO_TYPE_ID" runat="server" Text='<%#Eval("SW_INFO_TYPE_ID") %>' Width="30px"
                                            Visible="false"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="InvSlNo" HeaderStyle-Height="20px" HeaderStyle-Font-Bold="true"
                                    HeaderStyle-ForeColor="Maroon">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_InvSlno" runat="server" Text='<%#Eval("INVOICE_SLNO") %>' MaxLength="3" Enabled="false"
                                            TabIndex="16" Width="40px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ItemSlNo" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Maroon">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtItemSlNo" runat="server" Text='<%#Eval("ITEM_SLNO") %>' MaxLength="4"  Enabled="false"
                                            TabIndex="16" Width="40px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ADD - Info Code" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_ADD_InfoCode" runat="server" Text='<%#Eval("ADD_INFO_CODE") %>' Onkeypress="return char(event)" 
                                            MaxLength="70" TabIndex="16" Width="100px" Height="25px" CssClass="autocomplete txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ADD - INFO MSR" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_ADD_INFO_MSR" runat="server" Text='<%#Eval("ADD_INFO_MSR") %>'
                                            Width="160px" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="28" Height="25px" TabIndex="16" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CVD - Info Code" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="DarkBlue">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_CVD_InfoCode" runat="server" Text='<%#Eval("CVD_INFO_CODE") %>' Onkeypress="return char(event)" 
                                            MaxLength="70" TabIndex="16" Width="100px" Height="25px" CssClass="autocomplete txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CVD - INFO MSR" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="DarkBlue">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_CVD_INFO_MSR" runat="server" Text='<%#Eval("CVD_INFO_MSR") %>'
                                            Width="160px" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="28" Height="25px" TabIndex="16" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SGD - Info Code" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="DarkRed">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_SGD_InfoCode" runat="server" Text='<%#Eval("SGD_INFO_CODE") %>' Onkeypress="return char(event)" 
                                            MaxLength="70" TabIndex="16" Width="100px" Height="25px" CssClass="autocomplete txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="SGD - INFO MSR" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="DarkRed">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txt_SGD_INFO_MSR" runat="server" Text='<%#Eval("SGD_INFO_MSR") %>'
                                            Width="160px" onblur="extractNumber(this,6,false);" onkeyup="extractNumber(this,6,false);return Clear_Dot(this);"
                                    onkeypress="return blockNonNumbers(this, event, true, false);" MaxLength="28" Height="25px" TabIndex="16" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                            </Columns>
                        </asp:GridView>
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hdn_chked_cnt" runat="server" />
                <asp:HiddenField ID="hdn_jobno" runat="server" />

            </div>
          </div>
            <%----------------------------------Main Div-END----------------------------------------------------------------%>
            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1040px;">
                <div id="txtcon-m_transaction_Supp_code" style="width: 435px;">
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                    <asp:Button ID="btnsave" runat="server" Text="Bulk Save" OnClick="btnsave_Click"  Font-Bold="true"
                        TabIndex="18" Width="100px" Height="30px" ForeColor="Blue" />
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 20px;">
                    <asp:Button ID="btn_Update" runat="server" Text="Bulk Update" Visible="false" OnClick="btn_Update_Click"  Font-Bold="true"
                        TabIndex="18" Width="100px" Height="30px" ForeColor="Blue" />
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 20px;">
                    <asp:Button ID="btndelete" runat="server" Text="Bulk Delete" Visible="false" Width="100px"  Font-Bold="true"
                        TabIndex="18" Height="30px" ForeColor="Blue" OnClick="btndelete_Click" />
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 170px;">
                </div>
            </div>
            <%-----------------------------------END----------------------------------------------------------------%>
   
    <asp:HiddenField ID="HDBranch" runat="server" />
    <asp:HiddenField ID="hdn_ICEGATE_ID_List" runat="server"  ClientIDMode="Static"/>
    <asp:HiddenField ID="hdn_YN" runat="server"  ClientIDMode="Static"/>

    
    <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdnjobno" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:HiddenField ID="confirm_value" runat="server" />



             <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
         BackgroundCssClass="modalBackground" DropShadow="false">
        </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_JOB" runat="server" />
    <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
         <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 800px; height: 20px; font-weight:bold; color:Blue;">
           <div  style="margin-left:90px;"><asp:Label ID="lbl_heading" runat="server"></asp:Label></div>
        </div>
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 800px; height: 280px; overflow:auto;">
               <asp:GridView ID="gv_Inv_Item" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                                BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                OnRowCreated="gv_Inv_Item_RowCreated" >
                                <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                <SelectedRowStyle Font-Bold="true" />
                                <Columns>
                                     <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv. SlNo"  HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left5" Width="50" ForeColor="Red" Font-Bold="true" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item SlNo" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left5" Width="50" ForeColor="Red"  Font-Bold="true"/>
                                    </asp:BoundField>
                                     <asp:BoundField DataField="ADD_INFO_CODE" HeaderText="ADD Info Code" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left5" Width="50" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ADD_INFO_MSR" HeaderText="ADD Info MSR" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left5" Width="50"  />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="CVD_INFO_CODE" HeaderText="CVD Info Code" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left5" Width="50" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CVD_INFO_MSR" HeaderText="CVD Info MSR" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left5" Width="50"  />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="SGD_INFO_CODE" HeaderText="SGD Info Code" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left5" Width="50" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SGD_INFO_MSR" HeaderText="SGD Info MSR" HeaderStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left5" Width="50"  />
                                    </asp:BoundField>
                                   
                                </Columns>
                            </asp:GridView>
        </div>
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 800px; height: 30px;">
           <div style="margin-left:280px;" > <asp:Button ID="btnok" runat="server" Text="Ok" OnClick="btnok_Click" /></div>
        </div>
    </asp:Panel>



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
