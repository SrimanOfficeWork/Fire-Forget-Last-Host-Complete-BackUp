<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Bulk_Supp_Doc_New.aspx.cs"
    Inherits="Imp_Bulk_Supp_Doc_New" %>

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
    <! -- VALIDATION SCRIPT -->
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
            max-width: 50px;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            height: 5em;
            line-height: 0em;
            text-align: left;
            max-width: 50px;
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
        $(function () {
            $('[id*=ListBox_Invoice_SlNo]').multiselect({

                includeSelectAllOption: true,
                buttonWidth: '80px'
            });
        });

        $(function () {
            $('[id*=ListBox1]').multiselect({

                includeSelectAllOption: true,
                buttonWidth: '100px'
            });
        });

        $(function () {
            $('[id*=List_Doc_Type]').multiselect({

                includeSelectAllOption: true,
                buttonWidth: '100px'
            });
        });


        $(function () {
            $('[id*=ListBox_ItemSlno]').multiselect({

                includeSelectAllOption: true,
                buttonWidth: '80px'
            });
        });


        $(function () {
            $('[id*=ListBox_Invoice_SlNo_CURR]').multiselect({

                includeSelectAllOption: true,
                buttonWidth: '80px'
            });
        });


        $(function () {
            $('[id*=ListBox_ItemSlno_CURR]').multiselect({

                includeSelectAllOption: true,
                buttonWidth: '80px'
            });
        });  
    </script>
   
    <script type="text/javascript">
         $(document).ready(function () {

             $('#btn_Refresh').click(function () {

                 window.close();
                 NewWindow1(
            '../Transaction/Imp_Bulk_Supp_Doc_New.aspx',
            'List',
            '1250',
            '1024',
            'yes'
        );
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

        $(function () {
            $('[id*=ListBox_Invoice_SlNo_CURR]').multiselect({

                includeSelectAllOption: true

            });
        });

        $(function () {
            $('[id*=ListBox_ItemSlno_CURR]').multiselect({

                includeSelectAllOption: true
            });
        });  
    </script>
    <script type="text/javascript">

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

     <style type="text/css">
    
    .fixedHeader thead tr { position: sticky; top: 0; background-color: #f1f1f1; /* Keeps header visible */ z-index: 10; }
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
            <div id="innerbox_MidMain_Grid" style="height: 560px;">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1060px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px; font-size: 14px;">
                        Import Sup Docs Bulk Copy</div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 100px;">
                        <div id="tag_label_transact_Src" style="width: 120px;">
                            <span style="color: Blue; font-size: 14px; font-weight: bold;">Jobno
                                <asp:Literal ID="lbljobno" runat="server"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 500px;">
                    </div>
                </div>
                <div id="tag_srcinner1" style="margin-top: 25px; height: 80px;">
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1220px;
                        margin-top: 10px; height: 30px;">
                      
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;
                            color: Maroon;">
                             IRN Copy From</div>
                        <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 70px;">
                            <asp:DropDownList ID="ddlJobNo" runat="server" Style="width: 70px;" CssClass="txtbox_none"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                                <asp:ListItem>Select</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen" style="width: 70px;  color: Maroon;">
                            Inv Sr.No
                            <asp:Label ID="lbl_Invoice_Slno" runat="server"></asp:Label>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_det2" style="width: 75px">
                            <asp:ListBox ID="ListBox_Invoice_SlNo" SelectionMode="Multiple" Height="28px" Width="80px"
                                runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListBox_Invoice_SlNo_SelectedIndexChanged">
                            </asp:ListBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width: 15px;">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;  color: Maroon;">
                            Item Sr.No
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_det2" style="width: 100px">
                            <asp:ListBox ID="ListBox_ItemSlno" SelectionMode="Multiple" Height="28px" Width="80px"
                                runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListBox_ItemSlno_SelectedIndexChanged">
                            </asp:ListBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen" style="width: 75px; margin-left: -10px;  color: Maroon;">
                            <asp:Label ID="Label1" runat="server" Text="Doc Ref. No"></asp:Label>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_det2" style="margin-left: 5px;">
                            <asp:ListBox ID="List_Doc_Type" SelectionMode="Multiple" OnSelectedIndexChanged="ListBox_DocRef_SelectedIndexChanged"
                                Height="28px" Width="100px" runat="server" AutoPostBack="true"></asp:ListBox>
                        </div>
                        <div id="tag_label_transaction_popup_gen" style="width: 80px; margin-left: 25px;  color: Maroon;">
                            <asp:Label ID="lbl_select_item" runat="server" Text="IRN Number"></asp:Label>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_det2">
                            <asp:ListBox ID="ListBox1" SelectionMode="Multiple" Height="28px" runat="server"
                                Width="100px"></asp:ListBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                       
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1220px;
                        margin-top: 10px;">
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                    
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px; font-weight:bold;
                            color: Fuchsia;">
                             IRN Copy To</div>
                        <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 70px;">
                           
                            <asp:TextBox ID="txt_CurrJobno" runat="server" Enabled="false" ForeColor="Blue" Width="70px"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_gen" style="width: 70px; color: Fuchsia;font-weight:bold;">
                            Inv Sr.No
                            <asp:Label ID="lbl_Invoice_Slno1" runat="server"></asp:Label>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_det2" style="width: 75px">
                            <asp:ListBox ID="ListBox_Invoice_SlNo_CURR" SelectionMode="Multiple" Height="28px"
                                Width="80px" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ListBox_Invoice_SlNo_CURR_SelectedIndexChanged">
                            </asp:ListBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty" style="width: 15px;">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 70px;font-weight:bold;
                            color: Fuchsia;">
                            Item Sr.No
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_det2" style="width: 100px">
                            <asp:ListBox ID="ListBox_ItemSlno_CURR" SelectionMode="Multiple" Height="28px" Width="80px"
                                runat="server"></asp:ListBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                     
                        <div id="tag_label_transaction_popup_IGM2_empty"  style="width: 40px;">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 110px;
                            margin-left: 30px; margin-top: 10px;">
                            <asp:Button ID="btn_Load_Data" runat="server" Text="Load Data" OnClick="btn_Load_Data_Click"
                                TabIndex="7" Width="100px" Height="30px" ForeColor="Blue" />
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1100px;">
                  <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 955px;"></div>
                        <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 80px; font-weight:bold;">
                           Row Count :
                        </div>
                         <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 25px;">
                           <asp:Label ID="lbl_Cnt" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                        </div>
                        </div>
                </div>
               
                 <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 955px;"></div>
                
                <div id="innerbox_MidMain_Trans" style="width: 1254px; height: 5px; margin-top: 35px;">
                </div>

                  
                <div id="tag_transac_export_lft_item_gen_Grid_comp" style="width: 1234px; height: 400px;">
                    <asp:GridView runat="server" ID="gvdetails" AutoGenerateColumns="false" OnRowDataBound="gvdetails_RowDataBound" CssClass="fixedHeader"
                        Width="100%" ShowHeader="true" BackColor="AliceBlue" ShowFooter="true"  ShowHeaderWhenEmpty="true" HeaderStyle-Height="30px" 
                        GridLines="None" BorderStyle="Groove" BorderWidth="1px" CellPadding="1" CellSpacing="1" HeaderStyle-BackColor="LightBlue"
                        HeaderStyle-Font-Size="14px">
                        <AlternatingRowStyle BackColor="AliceBlue" BorderColor="Black" BorderWidth="1px"  />
                        <HeaderStyle Font-Underline="false" ForeColor="Black" />
                        <Columns>
                         <asp:TemplateField  HeaderStyle-Width="20px"></asp:TemplateField>
                            <asp:TemplateField  HeaderStyle-Width="40px">
                                <HeaderTemplate>
                                    <asp:CheckBox runat="server" ID="chkTotalAll" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="chk_All" onclick="Check_Click(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
 <asp:TemplateField  HeaderStyle-Height="20px" HeaderStyle-Font-Bold="true">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_SW_ID" runat="server" Text='<%#Eval("SW_ID") %>' Width="30px"
                                        Visible="false"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="InvSl" HeaderStyle-Height="20px" HeaderStyle-Font-Bold="true"
                                HeaderStyle-ForeColor="Green">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_InvSlno" runat="server" Text='<%#Eval("INVOICE_SLNO") %>' MaxLength="3"
                                        TabIndex="16" Width="30px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ItemSl" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtItemSlNo" runat="server" Text='<%#Eval("ITEM_SLNO") %>' MaxLength="3"
                                        TabIndex="16" Width="30px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Image Ref.No" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtImage_RefNo" runat="server" Text='<%#Eval("IMAGE_REF_NUMBER") %>'
                                        TabIndex="16" MaxLength="16" Width="135px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Doc.TypeCode" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDoc_TypeCode" runat="server" Text='<%#Eval("DOC_TYPE_CODE") %>'
                                        ClientIDMode="Static" MaxLength="20" TabIndex="16" Width="85px" Height="25px"
                                        CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Iss.Party Name" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIss_PartyName" runat="server" Text='<%#Eval("DOC_ISSUING_PARTY_NAME") %>'
                                        MaxLength="70" TabIndex="16" Width="160px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Place of Issue" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPlace_Of_Issue" runat="server" Text='<%#Eval("PLACE_OF_ISSUE") %>'
                                        Width="150px" MaxLength="35" Height="25px" TabIndex="16" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Issue Date" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtIssue_Date" runat="server" onblur="ChangeCase(this);" MaxLength="10"
                                        TabIndex="16" onkeypress="return AllowAlphabet(event)" Text='<%#Eval("DOC_ISSUE_DATE") %>'
                                        Width="80px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                    <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtIssue_Date"
                                        Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                        MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                    </cc1:MaskedEditExtender>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtIssue_Date"
                                        PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ben.Party Name" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtBenPartyName" runat="server" Text='<%#Eval("BENEFICIARY_PARTY_NAME") %>'
                                        CssClass="txtbox_none_Mid_transac_Supp_Name" TabIndex="16" Height="25px" Width="160px"
                                        MaxLength="70"></asp:TextBox>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:Button ID="Button2" runat="server" Width="40px" CommandName="add" Font-Size="Small"
                                        CssClass="coma" Visible="true" OnClientClick="jQuery('#form1').validationEngine('hideAll');" />
                                </FooterTemplate>
                                <FooterStyle CssClass="btnhide" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Icegate ID" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_IcegateID" runat="server" Text='<%#Eval("ICEGATE_ID") %>' Width="140px"
                                        TabIndex="16" MaxLength="15" CssClass="autocomplete txtbox_none_Mid_transac_Supp_Name"
                                        ClientIDMode="Static" Height="25px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Level" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="Green">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtLevel" runat="server" Text='<%#Eval("SELECT_TYPE") %>' MaxLength="70"
                                        TabIndex="16" Width="60px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOC ISSUING PARTY CODE" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Doc_Iss_Party_Code" runat="server" Text='<%# Eval("DOC_ISSUING_PARTY_CODE") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOC ISSUING PARTY NAME ADD1" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Doc_Iss_Party_Add1" runat="server" Text='<%# Eval("DOC_ISSUING_PARTY_NAME_ADD1") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOC ISSUING PARTY NAME ADD2" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Doc_Iss_Party_Add2" runat="server" Text='<%# Eval("DOC_ISSUING_PARTY_NAME_ADD2") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOC ISSUING PARTY CITY" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Doc_Iss_Party_City" runat="server" Text='<%# Eval("DOC_ISSUING_PARTY_CITY") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOC ISSUING PARTY PIN" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Doc_Iss_Party_Pin" runat="server" Text='<%# Eval("DOC_ISSUING_PARTY_PIN") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOC REF NUMBER" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Doc_Iss_Party_Ref_No" runat="server" Text='<%# Eval("DOC_REF_NUMBER") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOC EXPIRY DATE" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Doc_Expiry_Date" runat="server" Text='<%# Eval("DOC_EXPIRY_DATE", "{0:dd/MM/yyyy}") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BENEFICIARY PARTY CODE" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ben_party_Code" runat="server" Text='<%# Eval("BENEFICIARY_PARTY_CODE") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BENEFICIARY_PARTY_NAME" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ben_party_Name" runat="server" Text='<%# Eval("BENEFICIARY_PARTY_NAME") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BENEFICIARY ADDRESS 1" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ben_party_Add1" runat="server" Text='<%# Eval("BENEFICIARY_PARTY_ADDRESS1") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BENEFICIARY ADDRESS 2" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ben_party_Add2" runat="server" Text='<%# Eval("BENEFICIARY_PARTY_ADDRESS2") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BENEFICIARY CITY" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ben_Party_City" runat="server" Text='<%# Eval("BENEFICIARY_PARTY_CITY") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="BENEFICIARY PIN" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Ben_Party_Pin" runat="server" Text='<%# Eval("BENEFICIARY_PARTY_PIN") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FILE TYPE" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_File_type" runat="server" Text='<%# Eval("FILE_TYPE") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ICEGATE DOC FILE NAME" Visible="false">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_IcegateFileName" runat="server" Text='<%# Eval("ICEGATE_DOC_FILE_NAME") %>' />
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
                <div id="txtcon-m_transaction_Supp_code" style="width: 585px;">
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;
                    margin-top: -7px;">
                    <asp:Button ID="btnsave" runat="server" Text="Bulk Copy" OnClick="btnsave_Click" Visible="false"
                        TabIndex="18" Width="100px" Height="30px" ForeColor="Blue" />
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
            <asp:HiddenField ID="hdn_ICEGATE_ID_List" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdnjobno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:HiddenField ID="confirm_value" runat="server" />
            <asp:HiddenField ID="hdn_BenPartyName" runat="server" />
            <asp:HiddenField ID="hdn_IssPartyName" runat="server" />
            <asp:HiddenField ID="hdn_PlaceOfIssue" runat="server" />



            <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
                BackgroundCssClass="modalBackground" DropShadow="false">
            </asp:ModalPopupExtender>
            <asp:HiddenField ID="HDU_JOB" runat="server" />
            <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
                BorderColor="Transparent">
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 400px; height: 20px;
                    font-weight: bold; color: Blue;">
                    <div style="margin-left: 90px;">
                        <asp:Label ID="lbl_heading" runat="server"></asp:Label></div>
                </div>
               
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 400px; height: 180px;
                    overflow: auto;">
                    <asp:GridView ID="gv_Inv_Item" runat="server" EmptyDataText="NO RECORD FOUND" Width="100%"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" ShowHeaderWhenEmpty="True"
                        BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                        OnRowCreated="gv_RITC_RowCreated">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <SelectedRowStyle Font-Bold="true" />
                        <Columns>
                            <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv. SlNo" HeaderStyle-Width="15%">
                                <ItemStyle CssClass="column_style_left5" Width="15%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item SlNo" HeaderStyle-Width="15%">
                                <ItemStyle CssClass="column_style_left5" Width="15%" ForeColor="Red" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="IMAGE_REF_NUMBER" HeaderText="IRN No" HeaderStyle-Width="42%">
                                <ItemStyle CssClass="column_style_left5" Width="42%" ForeColor="Red" Font-Bold="true" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DOC_TYPE_CODE" HeaderText="Doc Type Code" HeaderStyle-Width="52%">
                                <ItemStyle CssClass="column_style_left5" Width="52%" ForeColor="Red" Font-Bold="true" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 400px; height: 30px;">
                    <div style="margin-left: 180px;">
                        <asp:Button ID="btnok" runat="server" Text="Ok" OnClick="btnok_Click" /></div>
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
</body>
</html>
