<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_FTA_Bulk.aspx.cs" Inherits="Imp_FTA_Bulk" %> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Bill Invoice</title>
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
          <%--  <div id="innerbox_MidMain" style="height: 32px;">
                <div id="tag_srcinner1">--%>
                <div id="innerbox_MidMain" style="height: auto; min-height: 32px;">
                    <div id="tag_srcinner1" style="display: flex; flex-wrap: wrap; align-items: center; row-gap: 4px;"
                     <div id="mainmastop2container_rght_tag2_txt1" style="width: 120px; font-size: 12px;">
                        IMP FTA Bulk Entry</div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 100px;">
                        <div id="tag_label_transact_Src" style="width: 100px;">
                            <span style="color: Blue; font-size: 12px; font-weight: bold;">Jobno
                                <asp:Literal ID="lbljobno" runat="server"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 180px;">
                        <div id="tag_label_transact_Src" style="width: 56px;">
                            <span style="color: Blue; font-size: 12px; font-weight: bold;">Flag </span>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 120px;">
                            <asp:DropDownList ID="ddl_flg" Style="width: 120px;" CssClass="listtxt_transac_item_gen_notn"
                                Width="120px" Font-Size="12px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_flg_SelectedIndexChanged">
                                <asp:ListItem Text="Save" Value="S"></asp:ListItem>
                                <asp:ListItem Text="Delete" Value="D"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 220px;">
                        <div id="tag_label_transact_Src" style="width: 56px;">
                            Inv. No</div>
                        <div id="txtcon-m_Exchange" style="width: 160px;">
                            <asp:DropDownList ID="ddlinvno" CssClass="listtxt_transac_item_gen_notn" Width="158px"
                                Font-Size="12px" runat="server" TabIndex="3" AutoPostBack="true" OnSelectedIndexChanged="ddlinvno_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 180px;">
                        <div id="tag_label_transact_Src" style="width: 56px;">
                            <span style="color: Blue; font-size: 12px; font-weight: bold;">Notn. </span>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 120px;">
                            <asp:DropDownList ID="ddl_INV_Notn" Style="width: 120px;" CssClass="listtxt_transac_item_gen_notn"
                                AutoPostBack="true" Width="120px" Font-Size="12px" runat="server" OnSelectedIndexChanged="ddl_INV_Notn_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 220px;">
                        <div id="tag_label_transact_Src" style="width: 56px;">
                            <span style="color: Blue; font-size: 12px; font-weight: bold;">Country </span>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 120px;">
                            <asp:DropDownList ID="ddl_Country" Style="width: 150px;" CssClass="listtxt_transac_item_gen_notn"
                                AutoPostBack="true" Width="120px" Font-Size="12px" runat="server" OnSelectedIndexChanged="ddl_Country_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 160px;">
                        <div id="tag_label_transact_Src" style="width: 56px;">
                            <span style="color: Blue; font-size: 12px; font-weight: bold;">Part No </span>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 100px;">
                              <asp:DropDownList ID="ddl_PartNo" Style="width: 110px;" CssClass="listtxt_transac_item_gen_notn"
                                AutoPostBack="true" Width="120px" Font-Size="12px" runat="server" OnSelectedIndexChanged="ddl_PartNo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
            </div>
            
           <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
             </div>
            <div id="tag_transac_export_lft_item_gen_Grid_comp" style="width: 1104px; height: 290px;">
                <asp:GridView runat="server" ID="gvdetails" DataKeyNames="ITEM_SLNO" EmptyDataText="NO RECORD FOUND"
                    AutoGenerateColumns="False" BackColor="WhiteSmoke" GridLines="Both" CssClass="grid-view"
                    OnRowCreated="gvdetails_RowCreated" Width="100%" ShowHeaderWhenEmpty="True" AllowPaging="false"
                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                    CellPadding="1" CellSpacing="1">
                    <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                        BorderWidth="1px" />
                    <Columns>
                        <asp:CommandField ShowSelectButton="False">
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
                        <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv. Slno">
                            <HeaderStyle CssClass="column_style_left" />
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item Slno">
                            <HeaderStyle CssClass="column_style_left" />
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ITEM_DESCRIPTION" HeaderText="Item desc.">
                            <HeaderStyle CssClass="column_style_left" />
                            <ItemStyle CssClass="column_style_left" />
                        </asp:BoundField>
                    </Columns>
                    <PagerSettings Visible="False" />
                </asp:GridView>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </div>
                
                <span id="SD" runat="server">
                
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1060px;">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 25px;">
                            <asp:CheckBox ID="Ch_1" Width="20px" Checked="true" runat="server" />
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 65px;">
                            Info Type
                        </div>
                        <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 80px;">
                            <asp:DropDownList ID="ddl_info_type" runat="server" TabIndex="1" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 80px;">
                                <asp:ListItem Text="ORC" Value="ORC"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                            Info Qualifier
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 235px;">
                            <asp:DropDownList ID="ddl_Info_Qualifier" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 230px;" data-placeholder="Choose a Info. Qualifier">
                                <asp:ListItem Text="COO-Certificate of Origin Particulars" Value="COO"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                            Country
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 220px;">
                            <asp:DropDownList ID="ddlCountry" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 220px;">
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                            Info. Text
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 170px;">
                            <asp:TextBox ID="txt_Info_Text_1" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Width="170px" TabIndex="4" MaxLength="100" onblur="validateDate()"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1060px;">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 25px;">
                            <asp:CheckBox ID="Ch_3" Width="20px" Checked="true" runat="server" />
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 65px;">
                            Info Type
                        </div>
                        <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 80px;">
                            <asp:DropDownList ID="ddl_info_type_3" runat="server" TabIndex="1" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 80px;">
                                <asp:ListItem Text="ORC" Value="ORC"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                            Info Qualifier
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 235px;">
                            <asp:DropDownList ID="ddl_Info_Qualifier_3" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 230px;" data-placeholder="Choose a Info. Qualifier">
                                <asp:ListItem Text="ACM-Accumulation/Cumulation" Value="ACM"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                            Info. Code
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 220px;">
                            <asp:DropDownList ID="ddlinfo_code_3" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 220px;">
                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                            Info. Text
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 170px;">
                            <asp:TextBox ID="txt_Info_Text_3" Enabled="false" runat="server" style="background-color:#737CA1;" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Width="170px" TabIndex="4" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1060px;">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 25px;">
                            <asp:CheckBox ID="Ch_4" Width="20px" Checked="true" runat="server" />
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 65px;">
                            Info Type
                        </div>
                        <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 80px;">
                            <asp:DropDownList ID="ddl_info_type_4" runat="server" TabIndex="1" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 80px;">
                                <asp:ListItem Text="ORC" Value="ORC"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                            Info Qualifier
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 235px;">
                            <asp:DropDownList ID="ddl_Info_Qualifier_4" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 230px;" data-placeholder="Choose a Info. Qualifier">
                                <asp:ListItem Text="RIS-Retroactive Issuance" Value="RIS"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                            Info. Code
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 220px;">
                            <asp:DropDownList ID="ddlinfo_code_4" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 220px;">
                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                            Info. Text
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 170px;">
                            <asp:TextBox ID="txt_Info_Text_4" Enabled="false" runat="server" style="background-color:#737CA1;" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Width="170px" TabIndex="4" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1060px;">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 25px;">
                            <asp:CheckBox ID="Ch_5" Width="20px" Checked="true" runat="server" />
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 65px;">
                            Info Type
                        </div>
                        <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 80px;">
                            <asp:DropDownList ID="ddl_info_type_5" runat="server" TabIndex="1" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 80px;">
                                <asp:ListItem Text="ORC" Value="ORC"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                            Info Qualifier
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 235px;">
                            <asp:DropDownList ID="ddl_Info_Qualifier_5" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 230px;" data-placeholder="Choose a Info. Qualifier">
                                <asp:ListItem Text="DC-Direct Consignment" Value="DC"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                            Info. Code
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 220px;">
                            <asp:DropDownList ID="ddlinfo_code_5" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 220px;">
                                <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                            Info. Text
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 170px;">
                            <asp:TextBox ID="txt_Info_Text_5" Enabled="false" style="background-color:#737CA1;" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Width="170px" TabIndex="4" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                    
            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1090px;">
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 25px;">
                            <asp:CheckBox ID="Ch_6" Width="20px" Checked="true" runat="server" />
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 65px;">
                            Info Type
                        </div>
                        <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 80px;">
                            <asp:DropDownList ID="ddl_info_type_6" runat="server" TabIndex="1" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 80px;">
                                <asp:ListItem Text="ORC" Value="ORC"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                            Info Qualifier
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 235px;">
                            <asp:DropDownList ID="ddl_Info_Qualifier_6" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 230px;" data-placeholder="Choose a Info. Qualifier" AutoPostBack="true" 
                                onselectedindexchanged="ddl_Info_Qualifier_6_SelectedIndexChanged">
                                <asp:ListItem Text="COWO-Wholly Obtained" Value="COWO"></asp:ListItem>
                                <asp:ListItem Text="CONWO-Not Wholly Obtained" Value="CONWO"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                            Info. Code
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 220px;">
                            <asp:DropDownList ID="ddlinfo_code_6" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn"
                                Style="width: 220px;">
                                
                            </asp:DropDownList>
                        </div>
                       <div id="tag_label_transaction_popup_IGM2_empty"></div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 60px;">
                            Info.Text
                        </div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 200px;">
                            <asp:TextBox ID="txt_Info_Text_6" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Width="100px" TabIndex="4" MaxLength="100"></asp:TextBox>
                              <span style="font-size:12px;">UQC </span> 
                               <asp:DropDownList ID="ddl_Info_UQC_6" runat="server" TabIndex="2" CssClass="listtxt_transac_item_gen_notn" Style="width: 50px;">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="CC" Value="CC"></asp:ListItem>
                                <asp:ListItem Text="CTH" Value="CTH"></asp:ListItem>
                                <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                </asp:DropDownList>
                        </div>
                    </div>
            </span>
            <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1040px;"></div>
              <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1040px;">
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 65px;">
                   
                </div>
                <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 80px;">
                   
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                    
                </div>
                <div id="txtcon-m_transaction_Supp_code" style="width: 235px;">
                    
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                    <asp:Button ID="btnsave" runat="server" Text="Save" onclick="btnsave_Click" />
                </div>
                <div id="txtcon-m_transaction_Supp_code" Style="width: 220px;">
                        <asp:Button ID="btndelete" runat="server" Text="Delete"  Visible="false" 
                            onclick="btndelete_Click" />
                </div>

                 <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;">
                   
                </div>
                <div id="txtcon-m_transaction_Supp_code" Style="width: 170px;">
                   
                </div>
            </div>
                <%-----------------------------------END----------------------------------------------------------------%>

            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdnjobno" runat="server" ClientIDMode="Static"/>
           </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  

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
          function Single_Window_link(lnk) {
              var str = '';
              var value = '1';

              var gv = document.getElementById("gv_Item_Details");
              for (var i = 0; i < gv.getElementsByTagName("input").length; i++) {
                  var node = gv.getElementsByTagName("input")[i];
                  if (node != null && node.type == "checkbox" && node.checked) {

                      var Grid_Table = document.getElementById("gv_Item_Details");

                      if (Grid_Table.rows[i].cells[1].textContent == 'Inv.Slno') { 

                      }
                      else {

                          if (value == '1') {

                              str = str + Grid_Table.rows[i].cells[1].textContent + '-' + Grid_Table.rows[i].cells[2].textContent;
                              value = "2";
                          }
                          else {
                              str = str + ',' + Grid_Table.rows[i].cells[1].textContent + '-' + Grid_Table.rows[i].cells[2].textContent;
                              str = str;
                          }

                      }
                  }
              }
              if (str != '') {
                  document.getElementById("hdinvslno").value = str;

                  PageMethods.Save_Product(document.getElementById("hdnjobno").value, str, OnSuccess);


                 // open_IMP_Single_Window_Bulk_Entry(document.getElementById('hdinvslno').value, $('#ddlinvno').val(), $('#ddl_INV_Rict_no').val() );
              }
              else {
                   alert('Select a Item');
                   document.getElementById("hdinvslno").value = '';
               }
               function OnSuccess(response, userContext, methodName) {

                   if (response == 'T') {
                       open_IMP_Single_Window_Bulk_Entry(document.getElementById('hdinvslno').value, $('#ddlinvno').val(), $('#ddl_INV_Rict_no').val());
                   }
                   else {
                       jAlert(response, 'Job Copy', function (r) { });
                   }
               }
          }  
          </script>

         <script type="text/javascript">
             function validateDate() {
                 var info_type = document.getElementById("ddl_info_type").value;
                 var info_qualifier = document.getElementById("ddl_Info_Qualifier").value;
                 var info_text = document.getElementById("txt_Info_Text_1").value;


                 if (info_type === "ORC" && info_qualifier === "COO") {
                     if (info_text == "")
                         return;

                     var parts = info_text.split("|");

//                     if (parts.length != 2) {
//                         alert("Invalid format. Date not found.");
//                         return false;
//                     }

                     var dateString = parts[1];

                     if (dateString.length != 8) {
                         alert("Invalid date format.");
                         return false;
                     }

                     var day = dateString.substring(0, 2);
                     var month = dateString.substring(2, 4);
                     var year = dateString.substring(4, 8);

                     if (day < 1 || day > 31 || month < 1 || month > 12) {
                         alert("Invalid Date! Please enter valid DDMMYYYY date.");
                         return false;
                     }

                     var enteredDate = new Date(year, month - 1, day);

                     var today = new Date();
                     today.setHours(0, 0, 0, 0);

                     if (enteredDate > today) {
                         alert("Info Text Date should not be greater than Current Date.");
                     }
                 }
             }
</script>

</body>
</html>
