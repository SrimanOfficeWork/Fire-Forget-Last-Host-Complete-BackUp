<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GST_Credit_Note_Entry.aspx.cs" Inherits="GST_Credit_Note_Entry" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>GST Credit_Note Bill</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../main.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
    <link rel="stylesheet" href="../css/jquery-ui.css" />
    <link rel="stylesheet" type="text/css" href="../css/dddropdownpanel.css" />
    <link rel="stylesheet" href="../windowfiles/dhtmlwindow.css" type="text/css" />
    <link rel="stylesheet" href="../modalfiles/modal.css" type="text/css" />
    <!--<link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />-->

    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <!-- VALIDATION SCRIPT -->
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>

    <script src="../js/Billing/Invoice_Paramount.js" type="text/javascript"></script>
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

     

   <script type="text/javascript">
       $(document).ready(function () {
           $("[id*=txtch_name]").autocomplete({
               source: function (request, response) {
                   $.ajax({
                       url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/GST_Billing_Charge_Master_List",
                       data: "{ 'mail': '" + request.term + "' }",
                       dataType: "json",
                       type: "POST",
                       contentType: "application/json; charset=utf-8",
                       success: function (data) {
                           response($.map(data.d, function (item) {
                               return {
                                   label: item,
                                   val: item
                               }
                           }))
                       },
                       error: function (response) {
                           alert(response.responseText);
                       },
                       failure: function (response) {
                           alert(response.responseText);
                       }
                   });
               },
               select: function (e, i) {
                   $("[id*=hfCustomerId]", $(e.target).closest("td")).val(i.item.val);
               },
               minLength: 1
           });

       });
</script>

 <script type="text/javascript">
function Char_Inv(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
        return false;
    return true;
}
</script>
<script type = "text/javascript">

    function Check_Click(objRef) {
        var row = objRef.parentNode.parentNode;
        var GridView = row.parentNode;
        var inputList = GridView.getElementsByTagName("input");

        for (var i = 0; i < inputList.length; i++) {
            var headerCheckBox = inputList[0];
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

</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            
            <div class="loading" align="center" id="Div1" style="display:none">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Billing" style="height: 95px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 80px;">
                       Credit Note
                    </div>
                    <div id="verslic" style="margin-top: -5px;"></div>
                     <div id="txtcon-m_Exchange" style="width: 215px; margin-top: 5px;">
                            <asp:RadioButtonList ID="Rd_Royal_Other" Font-Bold="true" ForeColor="Blue" runat="server"
                                RepeatDirection="Horizontal" TabIndex="10" AutoPostBack="true"
                                onselectedindexchanged="Rd_Royal_Other_SelectedIndexChanged">
                                <asp:ListItem Text="eRoyal Jobs" Value="R" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Other Jobs" Value="O"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                      <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="txtcon-m_Exchange" style="width: 110px;">
                            <asp:RadioButtonList ID="Rd_Imp_Exp" runat="server" 
                                RepeatDirection="Horizontal" TabIndex="91" ForeColor="Purple" 
                                onselectedindexchanged="Rd_Imp_Exp_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Imp" Value="I" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Exp" Value="E"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <%--<div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 40px;margin-top:5px;">
                            Bill To
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 130px;">
                            <asp:RadioButtonList ID="Rd_Bill_Type" runat="server" RepeatDirection="Horizontal" ForeColor="Blue"
                                AutoPostBack="true" TabIndex="6" OnSelectedIndexChanged="Rd_Bill_Type_SelectedIndexChanged">
                                <asp:ListItem Text="Local" Value="L" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                  <div id="verslic" style="margin-top: -5px;"></div>--%>
                   <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="tag_label_transact_Src" style="width: 90px;margin-top:5px;">
                            Company Lic.
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px;color:Green;">
                         <asp:Literal ID="lbl_Com_Lic" runat="server"></asp:Literal>
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>

                    <%--<div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="txtcon-m_Exchange" style="width: 100px;">
                            <asp:RadioButtonList ID="Rd_Tax_NonTax" runat="server" RepeatDirection="Horizontal" ForeColor="Red" Visible="false" >
                                <asp:ListItem Text="Tax" Value="T"></asp:ListItem>
                                <asp:ListItem Text="Non-Tax" Value="N"></asp:ListItem>
                                <asp:ListItem Text="Re-Imbursement" Value="R"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                     <div id="verslic" style="margin-top: -5px;">
                   </div>
                    --%>
                   
                  
                   <div id="tag_label_transact_Src" style="width: 100px;">
                   Working Period
                   </div>
                    <div id="txtcon-m_Exchange" style="width: 210px;">
                        <asp:DropDownList ID="ddlWorkingPeriod" runat="server" AutoPostBack="true"
                            onselectedindexchanged="ddlWorkingPeriod_SelectedIndexChanged">
                              <asp:ListItem Text="01-Apr-2026 - 31-Mar-2027" Value="01-Apr-2026 - 31-Mar-2027"></asp:ListItem>

                           <%--<asp:ListItem Text="01-Apr-2015 - 31-Mar-2016" Value="01-Apr-2015 - 31-Mar-2016"></asp:ListItem>--%>
                        <%--   <asp:ListItem Text="01-Apr-2025 - 31-Mar-2026" Value="01-Apr-2025 - 31-Mar-2026"></asp:ListItem>
                          <asp:ListItem Text="01-Apr-2024 - 31-Mar-2025" Value="01-Apr-2024 - 31-Mar-2025"></asp:ListItem>
                          <asp:ListItem Text="01-Apr-2023 - 31-Mar-2024" Value="01-Apr-2023 - 31-Mar-2024"></asp:ListItem>--%>

                        </asp:DropDownList> 
                    
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <span id="F" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" /></span>
                        <span id="T" runat="server">
                            <input type="close" value="Submit" class="clsicon_new" onclick="RefreshParent();return false;" /></span>
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 1165px; height: 55px;">
                    <div id="tag_Exchange_inner_lft" style="width: 1165px">
                        <div id="tag_transact_lft_in1" style="width: 1165px; height: 30px;">
                            <div id="txt_container_Transact_Main_l" style="width: 490px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Customer Name</div>
                                <div id="txtcon-m_Exchange">
                                    <asp:DropDownList ID="ddlCus_name" runat="server" class="chosen-select-deselect"
                                        Style="width: 370px;" data-placeholder="Choose a Customer Name" AutoPostBack="true"
                                        TabIndex="8" onselectedindexchanged="ddlCus_name_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 660px;">
                                    <div id="tag_label_transact_Src" style="width: 70px;">
                                        Branch No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 170px;">
                                        <asp:DropDownList ID="ddlbranch_No" runat="server" class="chosen-select-deselect"
                                            Style="width: 162px;" data-placeholder="Choose a Branch No" TabIndex="10" AutoPostBack="true"
                                            onselectedindexchanged="ddlbranch_No_SelectedIndexChanged"  >
                                        </asp:DropDownList>
                                    </div>
                                 

                                     <div id="tag_label_transact_Src" style="width: 50px; color:Green; font-weight:bold;">
                                       Bill No
                                    </div>
                                    <div id="txtcon-m_Exchange" style="width: 290px;">
                                       <asp:DropDownList ID="ddl_Billno" class="chosen-select-deselect" data-placeholder="Choose a Jobno"
                                        Width="150px" runat="server" TabIndex="19" AutoPostBack="true" OnSelectedIndexChanged="ddl_Billno_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txt_S_Billno" runat="server" CssClass="txtbox_none_Mid_transac_Inv_No" ClientIDMode="Static" Width="120px" MaxLength="20" TabIndex="21"> </asp:TextBox>
                                    </div>
                                   <%--  <div id="txtcon-m_Exchange" style="width: 80px;">
                                           <asp:Button ID="btn_Addjobno" TabIndex="22" runat="server" Width="80px"  CausesValidation="false" UseSubmitBehavior="false"
                                           Height="20px" Text="Add Jobno" onclick="btn_Addjobno_Click" />
                                    </div>--%>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 1100px;">
                            <div id="txt_container_Transact_Main_l" style="width: 1080px;">

                             <span style="display: none;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Ship Type 1
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px;">
                                    <asp:DropDownList ID="ddl_tr_mode" CssClass="listtxt_transac_item_gen_notn" Font-Size="12px"
                                        Width="80px" TabIndex="15" runat="server">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Air" Value="A"></asp:ListItem>
                                        <asp:ListItem Text="Sea" Value="S"></asp:ListItem>
                                        <asp:ListItem Text="Land" Value="L"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Ship Type 2
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 120px;">
                                    <asp:DropDownList ID="ddlshipment_type" CssClass="listtxt_transac_item_gen_notn"
                                        Font-Size="12px" Width="110px" TabIndex="16" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 100px;">
                                    From Quotation
                                </div>
                                <div id="tag_label_transact_Src" style="width: 60px;">
                                    <asp:CheckBox ID="From_Quotation" runat="server" TabIndex="11" Checked="true" />
                                </div>
                                </span>

                                <%--<div id="tag_label_transact_Src" style="width: 143px;">
                                    <asp:Button ID="btnloadData" TabIndex="22" runat="server" Width="100px" Height="20px"
                                        Text="Load Data" OnClick="btnloadData_Click" />
                                </div>
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    Bill Cur.
                                </div>
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    <asp:DropDownList ID="ddl_cur" CssClass="listtxt_transac_item_gen_notn" Font-Size="12px"
                                        Width="60px" TabIndex="23" runat="server">
                                        <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                        <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                    Ex - Rate
                                </div>
                                <div id="tag_label_transact_Src" style="width: 60px;">
                                    <asp:TextBox ID="txtEx_Rate" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="24"
                                        Text="1" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                        onkeypress="return blockNonNumbers(this, event, true, false);" Height="15px"
                                        Width="65px" Font-Size="12px" runat="server" Style="text-align: right"></asp:TextBox>
                                </div>--%>
                                  <div id="tag_label_transact_Src" style ="width: 40px; color:Red; margin-top: -3px;">
                                    Bill To
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 130px;font-weight:bold;margin-top: -3px;" >
                                    <asp:RadioButtonList ID="Rd_Bill_Type" runat="server" RepeatDirection="Horizontal" Enabled="false"
                                        ForeColor="Blue" AutoPostBack="true" TabIndex="6" OnSelectedIndexChanged="Rd_Bill_Type_SelectedIndexChanged">
                                        <asp:ListItem Text="Local" Value="L" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Other" Value="O"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div id="verslic" style="margin-top: -3px;height:22px;"></div>
                                  <div id="tag_label_transact_Src" style="width: 120px; font-weight:bold;margin-top: -3px;">
                                    <asp:RadioButtonList ID="Rd_Reg_Sez" runat="server" RepeatDirection="Horizontal" TabIndex="16" ForeColor="Green" >
                                        <asp:ListItem Text="Reg" Value="R" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Sez" Value="S"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div id="verslic" style="margin-top: -3px;height:22px;"></div>
                                <div id="tag_label_transact_Src" style="width: 90px;">
                                   Trans / Frt Bill
                                </div>
                                <div id="tag_label_transact_Src" style="width: 120px; font-weight:bold;margin-top: -3px;">
                                    <asp:RadioButtonList ID="Rd_Tr_Y_N" runat="server" RepeatDirection="Horizontal" TabIndex="16" ForeColor="Purple" >
                                        <asp:ListItem Text="No" Value="N" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                <div id="tag_label_transact_Src" style="width: 55px;">
                                   Bill Cur.
                                </div>

                                 <div id="tag_label_transact_Src" style="width: 70px;">
                                <asp:DropDownList ID="ddl_cur" CssClass="listtxt_transac_item_gen_notn"
                                        Font-Size="12px" Width="60px" TabIndex="23" runat="server">
                                        <asp:ListItem Text="INR" Value="INR"></asp:ListItem>
                                         <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                                    </asp:DropDownList>
                                 </div>
                                  <div id="tag_label_transact_Src" style="width: 70px;">
                                   Ex - Rate
                                </div>

                                 <div id="tag_label_transact_Src" style="width: 105px;">
                                     <asp:TextBox ID="txtEx_Rate"  CssClass="txtbox_none_Mid_transac_Inv_No"  TabIndex="24" Text="1"
                                           onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);" 
                                            onkeypress="return blockNonNumbers(this, event, true, false);"
                                            Height="15px" Width="55px" Font-Size="12px"  runat="server" style="text-align:right"></asp:TextBox>
                                 </div>


                                 <div id="tag_label_transact_Src" style="width: 110px;">
                                    <asp:Button ID="btnloadData" TabIndex="22" runat="server" Width="100px" 
                                        Height="20px" Text="Load Data" onclick="btnloadData_Click" />
                                </div>
                            </div>
                        </div>
                       
                    </div>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>

         <div class="content" id="page-1" style="margin-top:-28px;">
                        
          <div id="innerbox_MidMain_Trans_new" style="height:442px; width:1194px; margin-left:-16px; margin-top:-5px;">
                    <ol id="toc_new">

                     <li><a href="#page-6" onclick="jQuery('#form1').validationEngine('hideAll');Cr_page1('0');"
                         id="Cr_Page_1" runat="server"><span>Home </span></a></li>

                     <li><a href="#page-8" onclick="jQuery('#form1').validationEngine('hideAll');Cr_page2('0');"
                         id="Cr_Page_2" runat="server"><span>General </span></a></li>

                     <li><a href="#page-12" onclick="jQuery('#form1').validationEngine('hideAll');Cr_page3('0');"
                         id="Cr_Page_3" runat="server"><span>IGM</span></a></li>
                     <li><a href="#page-9" onclick="jQuery('#form1').validationEngine('hideAll');Cr_page4('0');"
                         id="Cr_Page_4" runat="server"><span>Invoice </span></a></li>
                     <li><a href="#page-11" onclick="jQuery('#form1').validationEngine('hideAll');Cr_page5('0');"
                         id="Cr_Page_5" runat="server"><span>Product</span></a></li>

                      <li><a href="#page-13" onclick="jQuery('#form1').validationEngine('hideAll');Cr_page6('0');"
                         id="Cr_Page_6" runat="server"><span>BE/SB</span></a></li>

                     <li><a href="#page-7" onclick="jQuery('#form1').validationEngine('hideAll');Cr_page7('0');"
                         id="Cr_Page_7" runat="server"><span>Ledger details</span></a></li>
                     <li><a href="#page-10" onclick="jQuery('#form1').validationEngine('hideAll');Cr_page8(document.getElementById('txtInvoiceNo').value);"
                         id="Cr_Page_8" runat="server" ><span>Annexure</span></a></li>

                     <li><a href="#page-14" onclick="jQuery('#form1').validationEngine('hideAll');Cr_page9('0');"
                         id="Cr_Page_9" runat="server"><span>E- Invoice</span></a></li>
                         
                </ol>

                  <%----------------------------Home---------------------------------------------------%>
                    <div   class="content" id="page-6"  >
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height:490px;margin-top: -16px; margin-left:-18px; color:Red;">
                            <div id="Div_listbox" runat="server">
                                <div id="tag_transact_src_inner" style="width: 1080px; height: 250px;">
                                    <div id="innerbox_MidMain_Trans_new" style="width: 1080px; height: 20px; margin-left: -10px;
                                        border-bottom-style: solid;">
                                        <div id="tag_label_transaction_exp_jobb">
                                            
                                        </div>
                                         
                                        <div id="tag_label_transaction_exp_jobb">
                                         
                                            <asp:Button ID="btn_Remove_Job" TabIndex="22" runat="server" Width="100px"  
                                             CausesValidation="false" UseSubmitBehavior="false" Visible="false"
                                               Height="20px" Text="Remove Jobno"  />
                                        </div>
                                    </div>
                                    <div id="tag_label_transaction_exp_jobb" style="width: 600px; overflow: auto; height: 200px;">

                                        <asp:GridView runat="server" ID="gv_Jobno" DataKeyNames="JOBNO" EmptyDataText="NO RECORD FOUND"
                                         AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                                         OnRowCreated="gv_Jobno_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" AllowPaging="false"
                                         AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                         CellPadding="1" CellSpacing="1">
                                         <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                             BorderWidth="1px" />
                                         <Columns>
                                             <asp:CommandField ShowSelectButton="True">
                                                 <HeaderStyle CssClass="hideGridColumn" />
                                                 <ItemStyle CssClass="hideGridColumn" />
                                             </asp:CommandField>
                                             <asp:TemplateField>
                                                 <HeaderTemplate>
                                                     <asp:CheckBox runat="server" ID="chkTotalAll" onclick="checkAll(this);" />
                                                 </HeaderTemplate>
                                                 <ItemTemplate>
                                                     <asp:CheckBox runat="server" ID="chk_All" onclick="Check_Click(this)" />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                             <asp:BoundField DataField="JOBNO" HeaderText="Jobno">
                                                 <HeaderStyle CssClass="column_style_left" />
                                                 <ItemStyle CssClass="column_style_left" />
                                             </asp:BoundField>
                                             <asp:BoundField DataField="JOBNO_PS" HeaderText="Jobno PS">
                                                 <HeaderStyle CssClass="column_style_left" />
                                                 <ItemStyle CssClass="column_style_left" />
                                             </asp:BoundField>
                                             <asp:BoundField DataField="NON_TAX_AMT" HeaderText="Non. Tax Amt">
                                                 <HeaderStyle CssClass="column_style_left" />
                                                 <ItemStyle CssClass="column_style_left" />
                                             </asp:BoundField>
                                             <asp:BoundField DataField="TAX_AMT" HeaderText="Tax Amt">
                                                 <HeaderStyle CssClass="column_style_left" />
                                                 <ItemStyle CssClass="column_style_left" />
                                             </asp:BoundField>
                                             <asp:BoundField DataField="TAX_VALUE" HeaderText="Tax Value">
                                                 <HeaderStyle CssClass="column_style_left" />
                                                 <ItemStyle CssClass="column_style_left" />
                                             </asp:BoundField>
                                             <asp:BoundField DataField="GRAND_TOTAL" HeaderText="Grand Total">
                                                 <HeaderStyle CssClass="column_style_left" />
                                                 <ItemStyle CssClass="column_style_left" />
                                             </asp:BoundField>
                                         </Columns>
                                         <PagerSettings Visible="False" />
                                     </asp:GridView>
                           <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </div>
                                </div>
                            </div>
                        <div id="tag_transact_src_inner" style="width: 1120px">
                    <div id="tag_Exchange_inner_lft" style="width: 1120px">
                        <div id="tag_transact_lft_in1" style="width: 1120px">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                    Invoice No:
                                    </div>
                                
                                <div id="txtcon-m_Exchange" > 
                                  <asp:TextBox ID="txtInvoiceNo" runat="server" MaxLength="17" onkeyup="autotab(this);" ClientIDMode="Static" onblur="return ChangeCase(this);"
                                   onkeypress="return Char_Inv(event)"  
                                   CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="25" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 220px">
                                <div id="tag_label_transact_Src" style="width: 50px">
                                   Date:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 85px">
                                    <asp:TextBox ID="txtDate" runat="server" Width="82px" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                        TabIndex="26"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtDate"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>
                                </div>
                            </div>
                              
                              <div id="txt_container_Transact_Main_l" style="width: 550px">
                             
                                <div id="tag_label_transact_Src" style="width: 80px">
                                  Hss
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 110px;">
                                    <asp:TextBox ID="txt_Hss" CssClass="txtbox_none_Mid_transac_code" runat="server"></asp:TextBox>
                                </div>

                                <div id="tag_label_transact_Src" style="width: 80px">
                                 Parma Code
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 110px;">
                                    <asp:TextBox ID="txt_Parma_Code" CssClass="txtbox_none_Mid_transac_code" runat="server"></asp:TextBox>
                                </div>

                                 <div id="tag_label_transact_Src" style="width: 80px">
                                 Work Flow Id
                                </div>
                                <div id="txtcon-m_Exchange" style="width:90px;">
                                    <asp:TextBox ID="txt_Work_Id" width="90px" CssClass="txtbox_none_Mid_transac_code" runat="server"></asp:TextBox>
                                </div>

                            </div>
                        </div>
                        <%---------------------------------------Row 4-----------------------------------------%>
                        <%--------------------------------------AddRow 1-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1185px">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Customer Name:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 330px;">
                                   <asp:TextBox ID="txt_Cus_name" runat="server" MaxLength="200" onkeyup="autotab(this);" Width="330px" Enabled="false" BackColor="AntiqueWhite"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="68" ></asp:TextBox>
                                </div>
                                <div id="magnify_area" runat="server" visible="false">
                                             <a href="#"  class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupExporter_Master('GST_Bill_Cus_name'); return false">
                                            </a>
                                        </div>
                            </div>
                                 <div id="txt_container_Transact_Main_l" style="width: 640px">
                                <div id="tag_label_transact_Src" style="width: 80px;">
                                   A/C Behalf
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 30px;">
                                    <asp:CheckBox ID="ch_Behalf" runat="server" TabIndex="75" />
                                </div>

                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Shipper Name:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 330px;">
                                   <asp:TextBox ID="txt_Shipper_name" runat="server" MaxLength="200" onkeyup="autotab(this);" Width="330px"
                                    CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="68" ></asp:TextBox>
                                </div>
                            </div>
                          
                        </div>
                           <%--------------------------------------AddRow 2-----------------------------------------%>
                           <div id="tag_transact_lft_in1" style="width: 1085px;">
                            <div id="txt_container_Transact_Main_l">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  State Name
                                </div>
                                <div id="txtcon-m_Exchange">

                                    <asp:DropDownList ID="ddl_state_name" CssClass="listtxt_transac_item_gen_notn" Width="160px" TabIndex="70"
                                     Enabled="false" ForeColor="Green" runat="server" BackColor="AntiqueWhite" >
                                     <asp:ListItem Text="" Value=""></asp:ListItem>

                                    <asp:ListItem Text="01--JAMMU & KASHMIR" Value="01"></asp:ListItem>
                                    <asp:ListItem Text="02--HIMACHAL PRADESH" Value="02"></asp:ListItem>
                                    <asp:ListItem Text="03--PUNJAB" Value="03"></asp:ListItem>
                                    <asp:ListItem Text="04--CHANDIGARH" Value="04"></asp:ListItem>
                                    <asp:ListItem Text="05--UTTARAKHAND" Value="05"></asp:ListItem>
                                    <asp:ListItem Text="06--HARYANA" Value="06"></asp:ListItem>
                                    <asp:ListItem Text="07--DELHI" Value="07"></asp:ListItem>
                                    <asp:ListItem Text="08--RAJASTHAN" Value="08"></asp:ListItem>
                                    <asp:ListItem Text="09--UTTAR PRADESH" Value="09"></asp:ListItem>
                                    <asp:ListItem Text="10--BIHAR" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="11--SIKKIM" Value="11"></asp:ListItem>
                                    <asp:ListItem Text="12--ARUNACHAL PRADESH" Value="12"></asp:ListItem>
                                    <asp:ListItem Text="13--NAGALAND" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="14--MANIPUR" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="15--MIZORAM" Value="15"></asp:ListItem>
                                    <asp:ListItem Text="16--TRIPURA" Value="16"></asp:ListItem>
                                    <asp:ListItem Text="17--MEGHALAYA" Value="17"></asp:ListItem>
                                    <asp:ListItem Text="18--ASSAM" Value="18"></asp:ListItem>
                                    <asp:ListItem Text="19--WEST BENGAL" Value="19"></asp:ListItem>
                                    <asp:ListItem Text="20--JHARKHAND" Value="20"></asp:ListItem>
                                    <asp:ListItem Text="21--ORISSA" Value="21"></asp:ListItem>
                                    <asp:ListItem Text="22--CHATTISGARH" Value="22"></asp:ListItem>
                                    <asp:ListItem Text="23--MADHYA PRADESH" Value="23"></asp:ListItem>
                                    <asp:ListItem Text="24--GUJARAT" Value="24"></asp:ListItem>
                                    <asp:ListItem Text="25--DAMAN & DIU" Value="25"></asp:ListItem>
                                    <asp:ListItem Text="26--DADRA & NAGAR HAVELI" Value="26"></asp:ListItem>
                                    <asp:ListItem Text="27--MAHARASHTRA" Value="27"></asp:ListItem>
                                    <asp:ListItem Text="29--KARNATAKA" Value="29"></asp:ListItem>
                                    <asp:ListItem Text="30--GOA" Value="30"></asp:ListItem>
                                    <asp:ListItem Text="31--LAKSHADWEEP" Value="31"></asp:ListItem>
                                    <asp:ListItem Text="32--KERALA" Value="32"></asp:ListItem>
                                    <asp:ListItem Text="33--TAMILNADU" Value="33"></asp:ListItem>
                                    <asp:ListItem Text="34--PONDICHERRY" Value="34"></asp:ListItem>
                                    <asp:ListItem Text="35--ANDAMAN & NICOBAR" Value="35"></asp:ListItem>
                                    <asp:ListItem Text="36--TELANGANA" Value="36"></asp:ListItem>
                                    <asp:ListItem Text="37--ANDHRA PRADESH" Value="37"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div id="txt_container_Transact_Main_l" style="width: 220px">
                                <div id="tag_label_transact_Src" style="width: 60px">
                                     GSTN ID
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 147px">
                                      <asp:TextBox ID="txt_GSTN_Id" Enabled="false" BackColor="AntiqueWhite" runat="server" MaxLength="17" Width="140px" onkeyup="autotab(this);" Font-Size="12px" TabIndex="72"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  ></asp:TextBox>
                                </div>
                            </div>

                             
                              <div id="txt_container_Transact_Main_l" style="width: 480px">
                               <div id="tag_label_transact_Src" style="width: 80px">
                                   PO No:
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 110px;">
                                    <asp:TextBox ID="txtPONumber" CssClass="txtbox_none_Mid_transac_code" runat="server"></asp:TextBox>
                                </div>

                                <div id="tag_label_transact_Src" style="width: 80px">
                                   Acc. Head
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 150px">
                                    <asp:TextBox ID="txtAccHead" CssClass="txtbox_none_Mid_transac_code" Width="150px" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            </div>

                        <%--------------------------------------AddRow 2end-----------------------------------------%>

                           <%--<div id="tag_transact_lft_in1" style="width: 1085px;height:60px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Address :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 373px;">
                                   <asp:TextBox ID="txt_Party_Add" runat="server" MaxLength="500"  Enabled="false" BackColor="AntiqueWhite"
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  Height="50px" TabIndex="74" ></asp:TextBox>
                                </div>
                            </div>
                        </div>--%>
                        
                           <div id="tag_transact_lft_in1" style="width: 1150px;height:60px;">
                            <div id="txt_container_Transact_Main_l" style="width: 500px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                   Address :
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 373px;">
                                   <asp:TextBox ID="txt_Party_Add" runat="server" MaxLength="500"  Enabled="false" BackColor="AntiqueWhite"
                                        onkeyup="autotab(this);" Width="370px" TextMode="MultiLine"
                                    CssClass="txtbox_none_Mid_transac_Inv_No"  Height="50px" TabIndex="74" ></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 560px">
                                <div id="tag_label_transact_Src" style="width: 80px">
                                   Remarks
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 480px">
                                    <asp:TextBox ID="txt_Remarks" CssClass="txtbox_none_Mid_transac_code" Width="470px" runat="server"></asp:TextBox>
                                </div>
                                <br />
                                <div id="tag_label_transact_Src" style="width: 80px">
                                             Job Entry
                                         </div>
                                         <div id="txtcon-m_Exchange" style="width: 180px;">
                                             <asp:RadioButtonList ID="Rd_Job_Status" runat="server" RepeatDirection="Horizontal"
                                                 TabIndex="93">
                                                 <asp:ListItem Text="Pending" Value="P" Selected="True"></asp:ListItem>
                                                 <asp:ListItem Text="Completed" Value="C"></asp:ListItem>
                                             </asp:RadioButtonList>
                                         </div>
                                         <div id="tag_label_transaction_popup_no_empty"></div>
                                         <span id="Bill_Admin" runat="server" visible="false">
                                          <div id="tag_label_transact_Src" style="width: 40px">
                                             Invoice
                                         </div>
                                         <div id="txtcon-m_Exchange" style="width: 230px;">
                                               <asp:RadioButtonList ID="Rd_Inv_Status" runat="server" TabIndex="94" RepeatDirection="Horizontal"
                                                      AutoPostBack="true" OnSelectedIndexChanged="Rd_Inv_Status_SelectedIndexChanged">
                                                      <asp:ListItem Text="Unapproval" Value="UA" Selected="True"></asp:ListItem>
                                                      <asp:ListItem Text="Approved" Value="A"></asp:ListItem>
                                                  </asp:RadioButtonList>
                                         </div>
                                         </span>


                            </div>
                        </div>
                      <%--------------------------------------AddRow 6-----------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 1085px;height:60px;">
                            <div id="txt_container_Transact_Main_l" style="width: 1080px;">
                                <div id="tag_label_transact_Src" style="width: 110px;">
                                  Bank Name
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 970px;">
                                   <asp:DropDownList ID="ddlbank_name" CssClass="listtxt_transac_item_gen_notn" Width="970px" TabIndex="70" ForeColor="Green" runat="server" >
                                     </asp:DropDownList>
                                </div>
                            </div>
                            
                               
                        </div>
                         <%--------------------------------------Row End-----------------------------------------%>
                    </div>
                 
                </div>
                        </div>
                    </div>

                      <%----------------------------Gen---------------------------------------------------%>
              <div class="content" id="page-8">
                     <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px;
                         width: 1194px; margin-top: -10px; margin-left: -18px;">
                         <asp:GridView ID="gv_Gen" runat="server" EmptyDataText="No Record Found" ShowHeader="True"
                             AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                             ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                             AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="180%"
                             OnRowCreated="GV_Gen_head_RowCreated" OnRowDataBound="gv_Gen_RowDataBound">
                             <RowStyle BorderWidth="0.1em" BorderColor="black" />
                             <PagerStyle ForeColor="Black" CssClass="pager" />
                             <Columns>
                                 <asp:TemplateField HeaderText="Jobno Ps" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_PS_I" Text='<%# Bind("JOBNO_PS") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_I" Text='<%# Bind("JOBNO") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="File.Refno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_file_Refno" Text='<%# Bind("FILE_REF_NO") %>' Width="80px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="80px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Party.Refno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Party_Refno" Text='<%# Bind("PARTY_REF_NO") %>' Width="80px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="80px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Job Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Job_Date" Text='<%# Bind("JOB_DATE") %>' Width="70px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="70px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Mode" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_tr_mode" Text='<%# Bind("TR_MODE") %>' Width="30px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="30px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_type" Text='<%# Bind("BE_SB_TYPE") %>' Width="70px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="70px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Cus. House Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Cus_House_Name" Text='<%# Bind("CUSTOMS_HOUSE_NAME") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Cus. House Code" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Cus_House_Code" Text='<%# Bind("CUSTOMS_HOUSE_CODE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Imp./Exp. Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Imp_Exp_Name" Text='<%# Bind("IMP_EXP_NAME") %>' Width="200px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="200px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Country Origin/ Final Dest." HeaderStyle-Font-Bold="true"
                                     HeaderStyle-Width="150px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Cou_Org_final_dest" Text='<%# Bind("COUNTRY_ORIGIN_FINAL_DEST") %>'
                                             Width="150px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="150px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Port Orgin/Final Dest." HeaderStyle-Font-Bold="true"
                                     HeaderStyle-Width="150px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Port_Org_final_dest" Text='<%# Bind("PORT_ORIGIN_FINAL_DEST") %>'
                                             Width="150px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="150px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="High Sea Sale Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_High_Sea_Sale_name" Text='<%# Bind("HIGH_SEA_SALE_NAME") %>'
                                             Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Con. Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Con_Type" Text='<%# Bind("CONTAINER_TYPE") %>' Width="80px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="80px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Payment Method" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Payment_Method" Text='<%# Bind("PAYMENT_METHOD_CODE") %>' Width="80px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="80px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Consignee Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="150px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Consignee_Name" Text='<%# Bind("CONSIGNEE_NAME") %>' Width="150px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="150px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="ETA" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_ETA" Text='<%# Bind("ETA") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                             </Columns>
                         </asp:GridView>
                     </div>
                 </div>
                 <%-----------------------Igm-------page---12----------------------------------------------%>
                 <div class="content" id="page-12">
                     <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px;
                         width: 1194px; margin-top: -10px; margin-left: -18px;">
                         <asp:GridView ID="gv_IGM" runat="server" EmptyDataText="No Record Found" ShowHeader="True"
                             AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                             ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                             AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="380%"
                             OnRowCreated="GV_Gen_head_RowCreated" OnRowDataBound="gv_IGM_RowDataBound">
                             <RowStyle BorderWidth="0.1em" BorderColor="black" />
                             <PagerStyle ForeColor="Black" CssClass="pager" />
                             <Columns>
                                 <asp:TemplateField HeaderText="Jobno Ps" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_PS_I" Text='<%# Bind("JOBNO_PS") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_I" Text='<%# Bind("JOBNO") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 
                                 <asp:TemplateField HeaderText="Airline Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="150px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Air_lineName" Text='<%# Bind("IGM_AIRLINENAME") %>' Width="150px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="150px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Flight Vesselno" HeaderStyle-Font-Bold="true"
                                     HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Flight_Vesselno" Text='<%# Bind("IGM_FLIGHTNO_VESSELNO") %>'
                                             Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Flight Vessel Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="120px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Flight_Vessel_Date" Text='<%# Bind("IGM_FLIGHT_VESSELDATE") %>'
                                             Width="120px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="120px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="IGM No." HeaderStyle-Font-Bold="true" HeaderStyle-Width="120px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_IGM_No" Text='<%# Bind("IGM_NO") %>' Width="120px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="120px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="IGM Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_IGM_Date" Text='<%# Bind("IGM_DATE") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="MAWB/MBL" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_MAWB_MBL" Text='<%# Bind("IGM_MAWB_MBL") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="MAWB/MBLDATE" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_MAWB_MBL_Date" Text='<%# Bind("IGM_MAWB_MBLDATE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="HAWB/HBLNO" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_HAWB_HBLNO" Text='<%# Bind("IGM_HAWB_HBLNO") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="HAWB/HBLDATE" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_HAWB_HBLNO_Date" Text='<%# Bind("IGM_HAWB_HBLDATE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                   <asp:TemplateField HeaderText="IGM Gross Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Gross_Wgt" Text='<%# Bind("IGM_GROSSWEIGHT") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gross Wgt Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Type_of_Wgt" Text='<%# Bind("IGM_TYPEOFWEIGHT") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                  <asp:TemplateField HeaderText="IGM No of Pkg" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_IGM_No_of_pkg" Text='<%# Bind("IGM_NOOFPACKAGE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                  <asp:TemplateField HeaderText="IGM Pkg Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Pkg_Type" Text='<%# Bind("IGM_PACKAGETYPE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>


                                 <asp:TemplateField HeaderText="IGM Net Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Net_Wgt" Text='<%# Bind("IGM_NETWEIGHT") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>


                                 <asp:TemplateField HeaderText="Net Wgt Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Net_Wgt_Type" Text='<%# Bind("IGM_NETWEIGHTTYPE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Voyage" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Voyage" Text='<%# Bind("IGM_VOYAGE") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="IGM Charge Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Charge_Wgt" Text='<%# Bind("IGM_CHARGEABLE_WGT") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                  <asp:TemplateField HeaderText="IGM Con. NO" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Igm_Con_No" Text='<%# Bind("IGM_CONTAINER_NO") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                  <asp:TemplateField HeaderText="IGM No. of Con" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Igm_No_of_Con" Text='<%# Bind("IGM_NO_OF_CONTAINER") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>


                                  <asp:TemplateField HeaderText="Anx Sea Tot Pkg" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sea_Tot_PKg" Text='<%# Bind("ANNEX_SEA_TOTAL_PACKAGES") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Anx Sea Gross Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sea_Gross_Wgt" Text='<%# Bind("ANNEX_SEA_GROSS_WEIGHT") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Anx Sea Net Wgt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sea_Net_Wgt" Text='<%# Bind("ANNEX_SEA_NET_WEIGHT") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Anx Sea Unit" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sea_Uint" Text='<%# Bind("ANNEX_SEA_UNIT_MEASUREMENT") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                  <asp:TemplateField HeaderText="Anx Sea Voyage No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sea_Voyage_No" Text='<%# Bind("ANNEX_SEA_VOYAGENO") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                   <asp:TemplateField HeaderText="Anx Sea Vessel No." HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sea_Vessel_No" Text='<%# Bind("ANNEX_SEA_VESSELNO") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Anx Sea Vessel Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sea_Vessel_Date" Text='<%# Bind("ANNEX_SEA_VESSEL_DATE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                    
                                <asp:TemplateField HeaderText="Anx Sea Loose Packets" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sea_Loose_Packets" Text='<%# Bind("ANNEX_SEA_LOOSE_PACKETS") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                    
                                 <asp:TemplateField HeaderText="Anx Sea No Containers" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sea_No_Of_Containers" Text='<%# Bind("ANNEX_SEA_NO_CONTAINERS") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                <asp:TemplateField HeaderText="Anx Sea Nature of Cargo" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sea_Nature_of_Cargo" Text='<%# Bind("ANNEX_SEA_NATURE_OF_CARGO") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>

                             </Columns>
                         </asp:GridView>
                     </div>
                 </div>

                <%-----------------------Inv-------page---12----------------------------------------------%>
                 <div class="content" id="page-9">
                     <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px;
                         width: 1194px; margin-top: -10px; margin-left: -18px;">
                         <asp:GridView ID="gv_Inv" runat="server" EmptyDataText="No Record Found" ShowHeader="True"
                             AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                             ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                             AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                             OnRowCreated="GV_Gen_head_RowCreated" OnRowDataBound="gv_Inv_RowDataBound">
                             <RowStyle BorderWidth="0.1em" BorderColor="black" />
                             <PagerStyle ForeColor="Black" CssClass="pager" />
                             <Columns>
                                 <asp:TemplateField HeaderText="Jobno Ps" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_PS_II" Text='<%# Bind("JOBNO_PS") %>' Width="70px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="70px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_II" Text='<%# Bind("JOBNO") %>' Width="70px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="70px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Inv. No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Inv_No" Text='<%# Bind("INVOICE_NO") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Inv. Dt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Inv_Date" Text='<%# Bind("INVOICE_DATE") %>' Width="80px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="80px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Terms" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Terms" Text='<%# Bind("TERMS") %>' Width="100px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Inv. Value" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Inv_Value" Text='<%# Bind("INVOICE_VALUE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Inv. Cur" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Inv_Cur" Text='<%# Bind("INVOICE_CUR") %>' Width="50px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="50px" />
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="Supplier Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Sup_Name" Text='<%# Bind("SUPPLIER_NAME") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Purchase_Order" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Purchase_Order" Text='<%# Bind("OTHER_PURCHASE_ORDER") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Purchase Order Date" HeaderStyle-Font-Bold="true"
                                     HeaderStyle-Width="200px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Purchase_Order_Date" Text='<%# Bind("OTHER_PURCHASE_ORDER_DATE") %>'
                                             Width="200px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="200px" />
                                 </asp:TemplateField>
                             </Columns>
                         </asp:GridView>
                     </div>
                 </div>
                  <%---------------------Item---------page---11----------------------------------------------%>
                 <div class="content" id="page-11">
                     <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px;
                         width: 1194px; margin-top: -10px; margin-left: -18px;">
                         <asp:GridView ID="gv_Item" runat="server" EmptyDataText="No Record Found" ShowHeader="True"
                             AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                             ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                             AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                             OnRowCreated="GV_Gen_head_RowCreated" OnRowDataBound="gv_Item_RowDataBound">
                             <RowStyle BorderWidth="0.1em" BorderColor="black" />
                             <PagerStyle ForeColor="Black" CssClass="pager" />
                             <Columns>
                                 <asp:TemplateField HeaderText="Jobno ps" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_PS_I" Text='<%# Bind("JOBNO_PS") %>' Width="70px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="70px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="70px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_I" Text='<%# Bind("JOBNO") %>' Width="70px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="70px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Item Desc." HeaderStyle-Font-Bold="true" HeaderStyle-Width="300px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Item_Dec" Text='<%# Bind("ITEM_DESCRIPTION") %>' Width="300px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="300px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Manufacture" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Manufacture" Text='<%# Bind("MANUFACTURER") %>' Width="200px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="200px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Ass. / FOB Value" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Ass_FOB_Value" Text='<%# Bind("ASS_FOB_VALUE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Duty / DBK Value" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Duty_Dbk_Value" Text='<%# Bind("DUTY_DRAWBACK_VALUE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="CIF / PMV Value" HeaderStyle-Font-Bold="true" HeaderStyle-Width="100px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_CIF_PMV_Value" Text='<%# Bind("CIF_PMV_VALUE") %>' Width="100px"
                                             runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="100px" />
                                 </asp:TemplateField>
                             </Columns>
                         </asp:GridView>
                     </div>
                 </div>
                   <%------------------------------page---11---E-------------------------------------------%>
                 <div class="content" id="page-13">
                     <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 400px;
                         width: 1194px; margin-top: -10px; margin-left: -18px;">
                         <asp:GridView ID="gv_BE_SB" runat="server" EmptyDataText="No Record Found" ShowHeader="True"
                             AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                             ShowFooter="false" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                             AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                             OnRowCreated="GV_Gen_head_RowCreated" OnRowDataBound="gv_BE_SB_RowDataBound">
                             <RowStyle BorderWidth="0.1em" BorderColor="black" />
                             <PagerStyle ForeColor="Black" CssClass="pager" />
                             <Columns>
                                 <asp:TemplateField HeaderText="Jobno Ps" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_PS_I" Text='<%# Bind("JOBNO_PS") %>' Width="200px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="200px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Jobno" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Jobno_I" Text='<%# Bind("JOBNO") %>' Width="200px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="200px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>

                                 <asp:TemplateField HeaderText="BE No/SB No" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_BE_SB_No" Text='<%# Bind("BE_SB_NO") %>' Width="200px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="200px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>

                                   <asp:TemplateField HeaderText="BE/SB Date" HeaderStyle-Font-Bold="true" HeaderStyle-Width="200px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_BE_SB_Date" Text='<%# Bind("BE_SB_DATE") %>' Width="200px" runat="server"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="200px" HorizontalAlign="Left" Font-Size="12px" />
                                 </asp:TemplateField>
                                 
                             </Columns>
                         </asp:GridView>
                     </div>
                 </div>

                 <%----------------------------Charge Details---------------------------------------------------%>
                 <div class="content" id="page-7" style="height: 440px;">
                     <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 30px;
                         width: 1194px; margin-top: -10px; margin-left: -18px;">
                         <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                             BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                             CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                             HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="GV_RowCreated"
                             OnRowDataBound="gv_Chg_Details_RowDataBound" Style="overflow: auto;">
                             <Columns>
                                 <asp:BoundField DataField="SUB_ITEM_DESCRIPTION" HeaderText="S. No" HeaderStyle-Width="122px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Right" Width="62px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="a" HeaderText="Charge Name" HeaderStyle-Width="970px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                 </asp:BoundField>
                                 <asp:BoundField HeaderText="Description" HeaderStyle-Width="320px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="30px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="d" HeaderText=" Qty" HeaderStyle-Width="50px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="5px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="d" HeaderText=" Cur." HeaderStyle-Width="50px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="5px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="d" HeaderText="Ex. Rate" HeaderStyle-Width="100px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="5px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="e" HeaderText="Unit Price" HeaderStyle-Width="150px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="150px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="f" HeaderText="Amt" HeaderStyle-Width="140px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="140px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="g" HeaderText=" % " HeaderStyle-Width="50px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="g" HeaderText="CGST Amt" HeaderStyle-Width="110px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="110px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="g" HeaderText=" % " HeaderStyle-Width="40px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="40px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="g" HeaderText="SGST Amt" HeaderStyle-Width="120px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="120px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="g" HeaderText=" % " HeaderStyle-Width="50px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="50px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="g" HeaderText="IGST Amt" HeaderStyle-Width="105px">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" Width="105px" />
                                 </asp:BoundField>
                                 <asp:BoundField DataField="g" HeaderStyle-Width="65px" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;">
                                     <ItemStyle CssClass="column_style_left_border_2_new" HorizontalAlign="Left" />
                                 </asp:BoundField>
                             </Columns>
                         </asp:GridView>
                     </div>
                     <style type="text/css">
                         input.underlined
                         {
                             border: solid 1px #000;
                         }
                     </style>
                     <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 305px;
                         width: 1194px; margin-top: -10px; margin-left: -18px;">
                         <asp:GridView ID="gv_Chg_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                             AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                             ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view"
                             AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                             OnRowDataBound="gv_Chg_Details_RowDataBound" OnRowDeleting="gv_Chg_Details_RowDeleting"
                             ShowHeader="false" Style="overflow-x: hidden; overflow-y: auto;" DataKeyNames="CHARGE_VALUE">
                             <RowStyle BorderWidth="0.1em" BorderColor="black" Height="8px" />
                             <Columns>
                                 <asp:TemplateField HeaderText="ch_inv" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                     <ItemTemplate>
                                         <asp:CheckBox ID="chk_inv" runat="server" HeaderText="ch_inv" Width="20px" Checked='<%#bool.Parse(Eval("INV_CHECK").ToString())%>' />
                                     </ItemTemplate>
                                     <ItemStyle Width="20px" />
                                 </asp:TemplateField>
                                 <asp:BoundField DataField="RowNumber" HeaderText="S.No" HeaderStyle-Font-Bold="true"
                                     ItemStyle-Width="20px" HeaderStyle-Width="20px" />
                                 <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtOrder_by" CssClass="underlined" Text='<%# Bind("ORDERBY") %>'
                                             Height="20px" Width="20px" onkeypress="return pin(event)" runat="server" Style="text-align: center"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="20px" HorizontalAlign="Left" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Charge Name" HeaderStyle-Font-Bold="true" HeaderStyle-Width="570px">
                                     <ItemTemplate>
                                         <asp:DropDownList ID="txtch_name" MaxLength="20" runat="server" onblur="Calculation_Rate(this)"
                                             Width="390px" Height="22px" Font-Size="12px" CssClass="txtbox_trans_exp_drawback">
                                         </asp:DropDownList>
                                         <asp:HiddenField ID="hfCustomerId" runat="server" />
                                         <asp:TextBox ID="txt_charge_desc" CssClass="underlined" Text='<%# Bind("CHARGE_DESC") %>'
                                             runat="server" onblur="Calculation(this)" Height="20px" Width="157px" Font-Size="12px"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="570px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Qty" HeaderStyle-Font-Bold="true" HeaderStyle-Width="30px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtqty" CssClass="underlined" Text='<%# Bind("Qty") %>' Height="20px"
                                             Width="28px" Font-Size="12px" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                             onkeypress="return blockNonNumbers(this, event, true, false);" runat="server"
                                             Style="text-align: center"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="30px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Cur" HeaderStyle-Font-Bold="true" HeaderStyle-Width="50px">
                                     <ItemTemplate>
                                         <asp:DropDownList ID="dl_CUR" Text='<%# Bind("CUR") %>' MaxLength="20" runat="server"
                                             Width="49px" Height="22px" Font-Size="12px" CssClass=" txtbox_trans_exp_drawback">
                                             <asp:ListItem>INR</asp:ListItem>
                                             <asp:ListItem>USD</asp:ListItem>
                                             <asp:ListItem>EUR</asp:ListItem>
                                             <asp:ListItem>GBP</asp:ListItem>
                                             <asp:ListItem>AUD</asp:ListItem>
                                             <asp:ListItem>JPY</asp:ListItem>
                                             <asp:ListItem>SGD</asp:ListItem>
                                         </asp:DropDownList>
                                     </ItemTemplate>
                                     <ItemStyle Width="50px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Ex_Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="31px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txt_Ex_Rate" CssClass="underlined" Text='<%# Bind("EX_RATE") %>'
                                             runat="server" onblur="extractNumber(this,2,false);remove_zero_after_decimal_point(this.value,'txt_Ex_Rate');return Clear_Dot(this);"
                                             onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                             autocomplete="off" Height="20px" Width="31px" Font-Size="12px" Style="text-align: center"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="31px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Unit Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="65px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtunit_price" CssClass="underlined" Text='<%# Bind("UNIT_RATE") %>'
                                             onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                             onkeypress="return blockNonNumbers(this, event, true, false);" Height="20px"
                                             Width="65px" Font-Size="12px" runat="server" Style="text-align: right"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="65px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Amount" HeaderStyle-Font-Bold="true" HeaderStyle-Width="75px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtamt" CssClass="underlined" Text='<%# Bind("AMOUNT") %>' BackColor="Silver"
                                             onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                             onkeypress="return blockNonNumbers(this, event, true, false);" Height="20px"
                                             Width="75px" Font-Size="12px" runat="server" Style="text-align: right"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="75px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="C-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtCGST_RATE" CssClass="underlined" Text='<%# Bind("CGST_RATE") %>'
                                             BackColor="#81F7BE" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                             onkeypress="return blockNonNumbers(this, event, true, false);" Height="20px"
                                             Width="20px" Font-Size="12px" runat="server" Style="text-align: center"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="20px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="C-Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="55px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtCGST_AMT" CssClass="underlined" Text='<%# Bind("CGST_AMT") %>'
                                             BackColor="Silver" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                             onkeypress="return blockNonNumbers(this, event, true, false);" Height="20px"
                                             Width="55px" Font-Size="12px" runat="server" Style="text-align: right"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="55px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="S-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtSGST_RATE" CssClass="underlined" Text='<%# Bind("SGST_RATE") %>'
                                             BackColor="#81F7BE" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                             onkeypress="return blockNonNumbers(this, event, true, false);" Height="20px"
                                             Width="20px" Font-Size="12px" runat="server" Style="text-align: center"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="20px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="S-Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="55px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtSGST_AMT" CssClass="underlined" Text='<%# Bind("SGST_AMT") %>'
                                             BackColor="Silver" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                             onkeypress="return blockNonNumbers(this, event, true, false);" Height="20px"
                                             Width="55px" Font-Size="12px" runat="server" Style="text-align: right"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="55px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="I-Rate" HeaderStyle-Font-Bold="true" HeaderStyle-Width="20px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtIGST_RATE" CssClass="underlined" Text='<%# Bind("IGST_RATE") %>'
                                             BackColor="#FFCBA4" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                             onkeypress="return blockNonNumbers(this, event, true, false);" Height="20px"
                                             Width="20px" Font-Size="12px" runat="server" Style="text-align: center"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="20px" />
                                 </asp:TemplateField>
                                 <asp:TemplateField HeaderText="I-Amt" HeaderStyle-Font-Bold="true" HeaderStyle-Width="69px">
                                     <ItemTemplate>
                                         <asp:TextBox ID="txtIGST_AMT" CssClass="underlined" Text='<%# Bind("IGST_AMT") %>'
                                             BackColor="Silver" onblur="extractNumber(this,3,false);" onkeyup="extractNumber(this,3,false);return Clear_Dot(this);"
                                             onkeypress="return blockNonNumbers(this, event, true, false);" Height="20px"
                                             Width="69px" Font-Size="12px" runat="server" Style="text-align: right"></asp:TextBox>
                                     </ItemTemplate>
                                     <ItemStyle Width="69px" />
                                     <FooterStyle HorizontalAlign="left" />
                                     <FooterTemplate>
                                         <asp:Button ID="ButtonAdd" runat="server" Text="Add Row" OnClick="ButtonAdd_Click" />
                                     </FooterTemplate>
                                 </asp:TemplateField>
                                 <asp:CommandField ShowDeleteButton="True" ControlStyle-Font-Bold="true" DeleteText="Del  "
                                     ControlStyle-Font-Size="Small" />
                             </Columns>
                         </asp:GridView>
                         <asp:TextBox ID="txtfocus" Width="1px" MaxLength="1" runat="server" BorderColor="White"
                             BorderStyle="None" ForeColor="White"></asp:TextBox>
                         <p id="pTotal" style="color: Red; font-size: large;">
                     </div>
                     <div id="tag_transact_src_inner" style="width: 1170px; height: 100px; margin-left: -10px;">
                         <div id="tag_transact_lft_in1" style="width: 1170px">
                             <div id="txt_container_Transact_Main_l" style="width: 190px;">
                                 <div id="tag_label_transact_Src" style="width: 90px;">
                                     Tax Amt:
                                 </div>
                                 <div id="txtcon-m_Exchange" style="width: 100px">
                                     <asp:TextBox ID="txt_tax_Amt" runat="server" Font-Bold="true" MaxLength="17" Width="90px"
                                         onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);"
                                         onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="txtbox_none_Mid_transac_Inv_No"
                                         TabIndex="108"></asp:TextBox>
                                 </div>
                             </div>
                             <div id="txt_container_Transact_Main_l" style="width: 190px;">
                                 <div id="tag_label_transact_Src" style="width: 90px;">
                                     Non-tax Amt:
                                 </div>
                                 <div id="txtcon-m_Exchange" style="width: 90px">
                                     <asp:TextBox ID="txt_nontax_Amt" runat="server" Font-Bold="true" MaxLength="17" Width="80px"
                                         onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);"
                                         onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="txtbox_none_Mid_transac_Inv_No"
                                         TabIndex="108"></asp:TextBox>
                                 </div>
                             </div>
                             <div id="txt_container_Transact_Main_l" style="width: 200px;">
                                 <div id="tag_label_transact_Src" style="width: 70px;">
                                     Total Amt:
                                 </div>
                                 <div id="txtcon-m_Exchange" style="width: 90px">
                                     <asp:TextBox ID="txt_total_amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                         BackColor="#F5F5F5" Width="80px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="101"></asp:TextBox>
                                 </div>
                             </div>
                             <div id="txt_container_Transact_Main_l" style="width: 340px;">
                                 <div id="tag_label_transact_Src" style="width: 235px">
                                     Taxable Amt (CGST + SGST + IGST) :
                                 </div>
                                 <div id="txtcon-m_Exchange" style="width: 90px">
                                     <asp:TextBox ID="txttax_amt" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                         BackColor="#F5F5F5" Width="80px" CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="101"></asp:TextBox>
                                 </div>
                             </div>
                             

                             <div id="txt_container_Transact_Main_l" style="width: 130px;">
                                 <div id="txtcon-m_Exchange" style="width: 130px">
                                     <div id="Add_Anx" visible="false" runat="server">
                                         <a id="link_ch_Anx" runat="server" href="javascript:open_Charge_Annexure_Amt('I')"><span
                                             style="font-size: 18px; font-weight: bold; color: Maroon;">Add Job Ledger</span>
                                         </a>
                                     </div>
                                 </div>
                             </div>
                             
                             <div id="txt_container_Transact_Main_l" style="width: 120px;">
                                 <div id="txtcon-m_Exchange" style="width: 120px">
                                     <div id="Add_RptAnx" visible="false" runat="server">
                                         <a id="link_RptAnx" runat="server" href="javascript:open_Imp_Rpt_Annexure_Amt('I')"><span
                                             style="font-size: 18px; font-weight: bold; color:Green;">Rpt Annexure</span>
                                         </a>
                                     </div>
                                 </div>
                             </div>
                             
                         </div>
                         <div id="tag_transact_lft_in1" style="width: 1085px">
                             <div id="txt_container_Transact_Main_l" style="width: 190px">
                                 <div id="tag_label_transact_Src" style="width: 90px">
                                     Grand Total:
                                 </div>
                                 <div id="txtcon-m_Exchange" style="width: 90px">
                                     <asp:TextBox ID="txt_grand_total" runat="server" Font-Bold="true" MaxLength="17"
                                         Width="90px" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);"
                                         onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="txtbox_none_Mid_transac_Inv_No"
                                         TabIndex="108"></asp:TextBox>
                                 </div>
                             </div>
                             <div id="txt_container_Transact_Main_l" style="width: 190px">
                                 <div id="tag_label_transact_Src" style="width: 90px">
                                     Advance Amt:
                                 </div>
                                 <div id="txtcon-m_Exchange" style="width: 90px">
                                     <asp:TextBox ID="txt_Adv_amt" runat="server" MaxLength="17" Width="80px" CssClass="txtbox_none_Mid_transac_Inv_No"
                                         TabIndex="103" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                         onkeypress="return blockNonNumbers(this, event, true, false);" BackColor="#FFFFC2"></asp:TextBox>
                                 </div>
                             </div>
                             <div id="txt_container_Transact_Main_l" style="width: 350px;">
                                 <div id="tag_label_transact_Src" style="width: 70px;">
                                     Exp.Amt
                                 </div>
                                 <div id="txtcon-m_Exchange" style="width: 120px">
                                     <asp:TextBox ID="txt_Expense_Amt" runat="server" Font-Bold="true" MaxLength="17"
                                         Width="80px" onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,6,false);"
                                         onkeypress="return blockNonNumbers(this, event, true, false);" CssClass="txtbox_none_Mid_transac_Inv_No"
                                         TabIndex="108"></asp:TextBox>
                                     <a id="Link_Container" runat="server" href="javascript:open_Imp_Exp_Expense_Amt('I')">
                                         <span style="font-size: 12px; font-weight: bold;">View</span> </a>
                                 </div>
                             </div>
                         </div>
                     </div>
                 </div>
                    
                  <%-------------------------------------------------------------------------------%>
                   <%------------------------------page---10----------------------------------------------%>
                       <div class="content" id="page-10">
                      <iframe src="" name="cargo" scrolling="no" id="Billing_Acc_Annexure_Grid_Iframe" style=" width:1180px;height: 500px;" ></iframe>
                 </div>
                   <%---------------------------------10E---------------------------------------------------%>
                   <div class="content" id="page-14">
                     <div id="pop_text_area_transac_popup_inn_container_export" style="height: 490px;
                         margin-top: -16px; margin-left: -18px; color: Red;">
                          <div id="tag_transact_src_inner" style="width: 1120px">
                          <div id="tag_Exchange_inner_lft" style="width: 1120px">
                              <div id="tag_transact_lft_in1" style="width: 1120px">
                                  <div id="txt_container_Transact_Main_l"  style="width: 1000px">
                                      <div id="tag_label_transact_Src" style="width: 150px;">
                                          IRN No.
                                      </div>
                                      <div id="txtcon-m_Exchange" style="width: 800px;">
                                          <asp:TextBox ID="txt_IRN_No" runat="server" onkeyup="autotab(this);" ClientIDMode="Static" Width="750px" BackColor="#E0DEDE"
                                           Enabled="false"  CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big" TabIndex="25"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>
                              <div id="tag_transact_lft_in1" style="width: 1120px">
                                  <div id="txt_container_Transact_Main_l" style="width: 1000px">
                                      <div id="tag_label_transact_Src" style="width: 150px;">
                                         Acknowledgement No.
                                      </div>
                                      <div id="txtcon-m_Exchange" style="width: 800px;">
                                          <asp:TextBox ID="txt_Ack_No" runat="server" onkeyup="autotab(this);" ClientIDMode="Static"  Width="750px" BackColor="#E0DEDE"
                                           Enabled="false" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big" TabIndex="25"></asp:TextBox>
                                      </div>
                                  </div>
                              </div>
                              <div id="tag_transact_lft_in1" style="width: 1120px">
                                  <div id="txt_container_Transact_Main_l" style="width: 720px">
                                      <div id="tag_label_transact_Src" style="width: 150px;">
                                          Acknowledgement Date
                                      </div>
                                      <div id="txtcon-m_Exchange" style="width: 300px;">
                                           <asp:TextBox ID="txt_Ack_Date" runat="server" Width="280px" MaxLength="100" CssClass="txtbox_none_Mid_transac_code" BackColor="#E0DEDE"
                                            Enabled="false"  TabIndex="26"></asp:TextBox>
                                          
                                      </div>
                                  </div>
                                  
                              </div>

                              <div id="tag_transact_lft_in1" style="width: 1120px">
                                  <div id="txt_container_Transact_Main_l" style="width: 1000px">
                                      <div id="tag_label_transact_Src" style="width: 150px;">
                                          QR Code.
                                      </div>
                                      <div id="txtcon-m_Exchange" style="width: 500px;">
                                          <asp:Image ID="img_QR_Code" runat="server" Height="150px" Width="150px" />
                                      </div>
                                  </div>
                                  
                              </div>
                          
                          </div>
                          </div>
                     </div>
                 </div>

                </div>
                  <%-- --------------------Test Start----------------------------%>
                  <div id="innerbox_MidMain_bot_transact" runat="server" style="height:20px;">
                    <div id="innerbox_transac_bot_inn" style="width:1050px">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                TabIndex="122" onclick="btnNew_Click1" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClientClick="return validate();"
                                TabIndex="120" OnClick="btnSave_Click" CommandName="s" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate();" TabIndex="121" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="121" CausesValidation="false"
                                UseSubmitBehavior="false" CssClass="dlete" OnClientClick="jQuery('#form1').validationEngine('hideAll');jConfirm('Delete this Invoice?', 'INVOICE', function(r) {
                                var i = r + 'ok';
                                  if(i == 'trueok')
                                  {
                                   document.getElementById('btn').click();
                                  }
                                  else {
                                  }
                                  });return false;" />
                            <asp:Button ID="btn" runat="server" TabIndex="123" OnClick="btnDelete_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll');"
                                CssClass="dlete" Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="Submit" class="scancel" onclick="RefreshParent();return false;"
                                id="btnCancel" tabindex="123">
                        </div>
                       <div id="editbu" style="width:10px;"></div>
                        <div id="editbu" style="padding-top:5px;">
                            <asp:Button ID="btnrpt" runat="server" tabindex="125" Text="Get Bill" OnClientClick="return GST_Billing_Job_CR_Rpt();"  /> 
                        </div>
                        <div id="editbu" style="padding-top:10px;">
                          <span style="color:Green;"> &nbsp; <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                          </span>
                        </div>
                        <div id="verslic"></div>
                       
                         <div id="editbu" style="padding-top:5px;">
                          <asp:Button ID="btn_EInvoice" runat="server"  tabindex="125" Visible="false" onclick="btn_EInvoice_Click"/> 
                        </div>
                            
                             <div id="editbu" style="padding-top:8px;">
                            <span style="color:Red;"><asp:Literal ID="lbl_E_inv_msg" runat="server"></asp:Literal></span>
                        </div>    
                             
                    </div>

                   
                </div>
                   <%-- --------------------Test End-------OnSelectedIndexChanged="Rd_Inv_Status_SelectedIndexChanged"---------------------%>

                 
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
          <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-6', 'page-7', 'page-8', 'page-9', 'page-10', 'page-11', 'page-12', 'page-13', 'page-14']);
            </script>

             <asp:HiddenField ID="HDupdate_id" runat="server"  ClientIDMode="Static" />
             <asp:HiddenField ID="HDupdate_IMP_EXP_id" runat="server"  ClientIDMode="Static" />

             <asp:HiddenField ID="hdimp" runat="server" />
             <asp:HiddenField ID="hd_Brslno" runat="server" />
             <asp:HiddenField ID="Hd_row_id" runat="server" />
             <asp:HiddenField ID="HD_Showcon" runat="server" />

             <asp:HiddenField ID="hd_Selected_Jobs" runat="server" ClientIDMode="Static" />
             <asp:HiddenField ID="hd_Jobs" runat="server" ClientIDMode="Static"  />
             <asp:HiddenField ID="hd_Imp_Exp" runat="server" ClientIDMode="Static"  />

             <asp:HiddenField ID="Hdjobno" runat="server" ClientIDMode="Static"  />
             <asp:HiddenField ID="Hd_I_E" runat="server" ClientIDMode="Static"  />
             
              </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  

    <script src="../js/Billing/GST/Imp_auto_Search.js" type="text/javascript"></script>

    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    
    <script type="text/javascript" src="../js/Accounts/Acc_iframepopupwin.js"></script>

    <script src="../js/checkboxJScript.js" type="text/javascript"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <%--<script src="../js/Validation.js" type="text/javascript"></script>--%>


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
        $(function () {
            $("#txt_Jobno").autocomplete({
                source: function (request, response) {
                    var ddlCus_name = $('#<%= ddlCus_name.ClientID %>').val();
                    var ddlbranch_No = $('#<%= ddlbranch_No.ClientID %>').val();
                    var txt_Jobno_list = $('#<%= hd_Selected_Jobs.ClientID %>').val();
                    var Rd_Imp_Exp = $('input:radio[name=Rd_Imp_Exp]:checked').val();
                    var ddl_tr_mode = $('#<%= ddl_tr_mode.ClientID %>').val();
                    var Wrk = $('#<%= ddlWorkingPeriod.ClientID %>').val();
                    var Job_Lic = '';
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_Exp_Billing_Paramount_Search",
                        data: "{ 'mail': '" + request.term + "','Imp_Exp': '" + Rd_Imp_Exp + "','Cus_name': '" + ddlCus_name + "' ,'Branch_No': '" + ddlbranch_No + "','Jobno_list': '" + txt_Jobno_list + "','ddl_tr_mode': '" + ddl_tr_mode + "','Wrk': '" + Wrk + "' ,'Job_Lic': '" + Job_Lic + "'  }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txt_Jobno').validationEngine('showPrompt', 'Incorrect', 'error', 'topRight', true);
                            }
                            else {
                                jQuery('#txt_Jobno').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });
 </script>
   <script type="text/javascript">
       function Calculation(lnk) {
           var grid = document.getElementById("<%= gv_Chg_Details.ClientID%>");
           var txtAmountReceive = $("[id*=txtch_name]")
           var txtAmountReceive_2 = $("[id*=ddl_tax_nontax]")
           var row = lnk.parentNode.parentNode;
           var rowIndex = row.rowIndex;

           var a = txtAmountReceive[rowIndex].value;
           var b = '1';

           $('#Hd_row_id').val(rowIndex);

           Cha_Type(a, b);
           Tax_Cal();
       }  
          </script>
<script type="text/javascript">
    function Calculation_Rate(lnk) {
        var row_r = lnk.parentNode.parentNode;
        var rowIndex_r = row_r.rowIndex;
        $('#Hd_row_id').val(rowIndex_r);
        var ddlval = $("[id*=txtch_name]")
        var ddlchas = ddlval[rowIndex_r].value;
        var State = $("#Rd_Bill_Type input[type='radio']:checked");
        Cha_Type_Rate(ddlchas, State.val());
    }  
</script>
<script type="text/javascript">
        function Cha_Type_Rate(src, dest) {
            PageMethods.Get_Cha_Type_Rate(src, dest, '', CallSuccess_Rate, CallFailed, dest);
        }

        function CallSuccess_Rate(res, destCtrl) {
            var data = res;
            if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

                var s = data.split('~~');
                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];

                var txtCGST_Rate = $("[id*=txtCGST_RATE]");
                var txtSGST_Rate = $("[id*=txtSGST_RATE]");
                var txtIGST_Rate = $("[id*=txtIGST_RATE]");

                txtCGST_Rate[document.getElementById("Hd_row_id").value].value = before;
                txtSGST_Rate[document.getElementById("Hd_row_id").value].value = after1;
                txtIGST_Rate[document.getElementById("Hd_row_id").value].value = after2;

            }
            else {
               
            }

        }

        function Cha_Type(src, dest) {
            PageMethods.Get_Cha_Type(src, '', '', CallSuccess_Cha_Type, CallFailed, dest);
        }


        function CallSuccess_Cha_Type(res, destCtrl) {

            var data = res;

            if (res != '') {

                var chargetype = $("[id*=ddl_tax_nontax]")
                var selected = $('input:radio[name=Rd_Bill_Type]:checked').val();
                var txtCGST_RATE_OP = $("[id*=txtCGST_RATE]")
                var txtCGST_AMT_OP = $("[id*=txtCGST_AMT]")
                var txtSGST_RATE_OP = $("[id*=txtSGST_RATE]")
                var txtSGST_AMT_OP = $("[id*=txtSGST_AMT]")
                var txtIGST_RATE_OP = $("[id*=txtIGST_RATE]")
                var txtIGST_AMT_OP = $("[id*=txtIGST_AMT]")

               

                if (data.indexOf("~~") != -1 && data.indexOf("~~") != '') {

                    var s = data.split('~~');
                    var before = s[0];
                    var after1 = s[1];
                    var after2 = s[2]; 
                    var tempCGST_RATE = s[3];    
                    var tempSGST_RATE = s[4];     
                    var tempIGST_RATE = s[5];     

                    if (selected == 'L') {

                        if (before == 'N') {

                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 0;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                        }
                        else if (before == 'T') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;

                            

                            if(txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0')
                            {
                                //txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';                                                              
                                
                                if (tempCGST_RATE.toString() == '' || tempCGST_RATE.toString() == ' ') {
                                    txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                                }
                                else {
                                    txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = tempCGST_RATE.toString();
                                }
                            }
                            if(txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0')
                            {
                                //txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';

                                if (tempSGST_RATE.toString() == '' || tempSGST_RATE.toString() == ' ') {
                                    txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                                }
                                else {
                                    txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = tempSGST_RATE.toString();
                                }
                            }



                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';
                        }
                        else if (before == 'P') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 2;
                        }
                        else if (before == 'E') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 3;
                        }
                    }
                    else {
                           
                        if (before == 'N') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 0;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';
                        }
                        else if (before == 'T') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                           
                            if (txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0')
                            {

                                if (tempIGST_RATE.toString() == '' || tempIGST_RATE.toString() == ' ') {
                                    txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '18';
                                }
                                else {
                                    txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = tempIGST_RATE.toString();
                                }
                            }
                        }
                        else if (before == 'P') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 2;
                        }
                        else if (before == 'E') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 3;
                        }
                    }
                    if (after1 != '') {

                    }
                    else {
                    }
                }
                else {
                    if (selected == 'L') {
                        if (res == 'N') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 0;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';
                        }
                        else if (res == 'T') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;
                            

                            if (txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0') {
                                txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                            }

                            if (txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0') {
                                txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '9';
                            }

                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';
                        }
                        else if (res == 'P') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 2;
                        }
                        else if (res == 'E') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 3;
                        }
                    }
                    else {
                        if (res == 'N') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 0;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtIGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';
                        }
                        else if (res == 'T') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;

                            txtCGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtCGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';

                            txtSGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '0';
                            txtSGST_AMT_OP[document.getElementById("Hd_row_id").value].value = '0';


                           
                            if (txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '' || txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value == '0') {
                                txtIGST_RATE_OP[document.getElementById("Hd_row_id").value].value = '18';
                            }

                        }
                        else if (res == 'P') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 2;
                        }
                        else if (res == 'E') {
                            chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 3;
                        }
                    }
                }
            }
            else {
                chargetype[document.getElementById("Hd_row_id").value].selectedIndex = 1;
            }
        }

        function CallFailed(res, destCtrl) {
        }
    </script>

  <script type="text/javascript">
      $(document).ready(function () {
          Tax_Cal();
       });
</script>
  
  <script type="text/javascript">
      $(document).ready(function () {

          //----------------------------------------------------------
          /*
          var ddlcha = $('[id*=txtch_name]').val();
          $('[id*=txtch_name]').focus(function () {
          Cha_Type_Rate(ddlcha, '2');
          });
          $('[id*=txtch_name]').change(function () {
          // Cha_Type_Rate(ddlch.value, '2');
          alert('2');
          });
          */
          $('[id*=txtch_name]').focus(function () {

          });
          $('[id*=txtch_name]').change(function () {
              // Cha_Type_Rate(ddlch.value, '2');

          });
          $('[id*=txtch_name]').keyup(function () {

              //Cha_Type_Rate(ddlch.value, '2');
          });
          $('[id*=txtch_name]').keydown(function () {

              //Cha_Type_Rate(ddlch.value, '2');
          });
          //-----------------------------------------------------------
          $('[id*=chk_inv]').focus(function () {

              Tax_Cal();
          });
          $('[id*=chk_inv]').change(function () {

              Tax_Cal();
          });
          $('[id*=chk_inv]').keyup(function () {

              Tax_Cal();
          });
          $('[id*=chk_inv]').keydown(function () {

              Tax_Cal();
          });

          //------------------------------------------------------------

          $('[id*=txtamt]').focus(function () {

              Tax_Cal();
          });
          $('[id*=txtamt]').change(function () {

              Tax_Cal();
          });
          $('[id*=txtamt]').keyup(function () {

              Tax_Cal();
          });
          $('[id*=txtamt]').keydown(function () {

              Tax_Cal();
          });
          //------------------------------------------------------------

          $('[id*=txtch_name]').focus(function () {

              Tax_Cal();
          });
          $('[id*=txtch_name]').change(function () {

              Tax_Cal();
          });
          $('[id*=txtch_name]').keyup(function () {

              Tax_Cal();
          });
          $('[id*=txtch_name]').keydown(function () {

              Tax_Cal();

          });

          //-----------------------------------------------------------------------------

          $('[id*=txtqty]').focus(function () {

              Tax_Cal();

          });
          $('[id*=txtqty]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtqty]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtqty]').keydown(function () {

              Tax_Cal();
          });
          //------------------------------------------------------------------------

          $('[id*=txtunit_price]').focus(function () {

              Tax_Cal();

          });
          $('[id*=txtunit_price]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtunit_price]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtunit_price]').keydown(function () {

              Tax_Cal();

          });

          //--------------------CGST---------------------------------------
          $('[id*=txtCGST_RATE]').focus(function () {

              if (selected.val() == 'L') {
                  Tax_Cal();
              }

          });
          $('[id*=txtCGST_RATE]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtCGST_RATE]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtCGST_RATE]').keydown(function () {

              Tax_Cal();

          });

          //-----------------2--------------------------------------------------
          $('[id*=txtSGST_RATE]').focus(function () {

              if (selected.val() == 'L') {
                  Tax_Cal();
              }

          });
          $('[id*=txtSGST_RATE]').change(function () {
              Tax_Cal();
          });
          $('[id*=txtSGST_RATE]').keyup(function () {
              Tax_Cal();
          });
          $('[id*=txtSGST_RATE]').keydown(function () {
              Tax_Cal();
          });

          //------------------------I-----------------------------------
          $('[id*=txtIGST_RATE]').focus(function () {

              if (selected.val() == 'L') {
                  Tax_Cal();
              }

          });
          $('[id*=txtIGST_RATE]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtIGST_RATE]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtIGST_RATE]').keydown(function () {

              Tax_Cal();

          });

          //-------------------2--------------------------
          $('[id*=txtIGST_AMT]').focus(function () {

              if (selected.val() == 'L') {
                  Tax_Cal();
              }

          });
          $('[id*=txtIGST_AMT]').change(function () {

              Tax_Cal();

          });
          $('[id*=txtIGST_AMT]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txtIGST_AMT]').keydown(function () {

              Tax_Cal();

          });
          //-----------------------------------------------------------
          $('[id*=txt_Ex_Rate]').focus(function () {

              if (selected.val() == 'L') {
                  Tax_Cal();
              }

          });
          $('[id*=txt_Ex_Rate]').change(function () {

              Tax_Cal();

          });
          $('[id*=txt_Ex_Rate]').keyup(function () {

              Tax_Cal();

          });
          $('[id*=txt_Ex_Rate]').keydown(function () {

              Tax_Cal();

          });
          //-----------------------------------------------------------
      });

       </script>
  <script type="text/javascript">

      function Tax_Cal() {

          var GST_State = $("#Rd_Bill_Type input[type='radio']:checked");
          var txtamt = $("[id*=txtamt]")
          var txtqty = $("[id*=txtqty]")
          var txt_Ex_Rate = $("[id*=txt_Ex_Rate]")

          var txtunit_price = $("[id*=txtunit_price]")

          var CGST_Rate = $("[id*=txtCGST_RATE]")
          var SGST_Rate = $("[id*=txtSGST_RATE]")

          var CGST_AMT = $("[id*=txtCGST_AMT]")
          var SGST_AMT = $("[id*=txtSGST_AMT]")

          var IGST_RATE = $("[id*=txtIGST_RATE]")
          var IGST_AMT = $("[id*=txtIGST_AMT]")

          var sum_T = 0;
          var sum_N = 0;
          var sum_R = 0;

          var Tot_L_O = 0;
          var counter = 0;
          var Tot_Amt = 0;
          var Non_Tax_amt = 0;
          var Tot_tax_amt = 0;

          $("#<%=gv_Chg_Details.ClientID%> input[id*='chk_inv']:checkbox").each(function (index) {
              if ($(this).is(':checked')) {
                  //-----------------------------------------------------------------------------------------

                  if (txtunit_price[index].value != '') {

                      txtamt[index].value = (txt_Ex_Rate[index].value * txtqty[index].value * txtunit_price[index].value).toFixed(2);
                      CGST_AMT[index].value = (parseFloat(txtamt[index].value) * CGST_Rate[index].value / 100.00).toFixed(2);
                      SGST_AMT[index].value = (parseFloat(txtamt[index].value) * SGST_Rate[index].value / 100.00).toFixed(2);
                      IGST_AMT[index].value = (parseFloat(txtamt[index].value) * IGST_RATE[index].value / 100.00).toFixed(2);

                      var aa = '0';
                      var n_bb = '0';

                      aa = parseFloat(CGST_AMT[index].value) + parseFloat(SGST_AMT[index].value) + parseFloat(IGST_AMT[index].value);

                      if (CGST_Rate[index].value == '0' && SGST_Rate[index].value == '0' && IGST_RATE[index].value == '0') {
                          Non_Tax_amt += parseFloat(txtamt[index].value)
                      }
                      else {
                          Tot_tax_amt += parseFloat(txtamt[index].value)
                      }


                      Tot_L_O += parseFloat(aa);
                      Tot_Amt += parseFloat(txtamt[index].value);

                  }
                  //-----------------------------------------------------------------------------------------

                  counter++;
              }
          });

          $('#txt_total_amt').val(Tot_Amt.toFixed(2));
          $('#txttax_amt').val(Tot_L_O.toFixed(2));
          document.getElementById("txt_grand_total").value = Math.round((parseFloat(Tot_L_O.toFixed(2)) + parseFloat(Tot_Amt.toFixed(2))).toFixed(2));

          $('#txt_tax_Amt').val(Tot_tax_amt.toFixed(2));
          $('#txt_nontax_Amt').val(Non_Tax_amt.toFixed(2));
      }

     </script>

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
    

    <script type="text/javascript">
        $(document).ready(function () {

            $('#txt_Cus_name').focus(function () {

                var data = $(this).val();
                Item_desc(data);
            });
            $('#txt_Cus_name').change(function () {

                var data = $(this).val();
                Item_desc(data);
            });
            $('#txt_Cus_name').keyup(function () {

                var data = $(this).val();
                Item_desc(data);
            });
            $('#txt_Cus_name').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });

        function Item_desc(val) {

            var data = val;
            if (data == '') {
                $('#txt_Cus_name').val('');
            }
            if (data.indexOf("--") != -1) {

                var s = data.split('--');

                var before = s[0];
                var after = s[1];

                $('#txt_Cus_name').val(after);

                $('#hdimp').val(after);
                $('#hd_Brslno').val(before);

            }
            else {

            }
        }

        function win_hide() {

            window.parent.document.getElementById('interVeil').style.display = 'none';

        }
  </script>
    
</body>
</html>
