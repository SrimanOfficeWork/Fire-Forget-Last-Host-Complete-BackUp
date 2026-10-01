<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_ETA_Bulk.aspx.cs" Inherits="Imp_ETA_Bulk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import ETA Bulk Entry </title>
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

        jQuery(document).ready(function () {
            var fromdt = document.getElementById("txtFrom_Date").value;
            var ddl_ETA = document.getElementById("ddl_ETA_Filter").value;
            $('#txtFrom_Date').change(function () {
                if (fromdt != '') {
                    document.getElementById("ddl_ETA_Filter").value = '';
                }
            });
        });
    </script>

    <style>
.grid-container {
    height: 400px;              /* Set your required height */
    overflow-y: auto;
    overflow-x: auto;
}

.gridview {
    width: 100%;
    border-collapse: collapse;
}

.gridview th {
    position: sticky;
    top: 0;
    background-color: #f2f2f2;
    z-index: 100;
}


//
.ChennaiScheduleGrid {
    width: 1400px !important;
    border-collapse: collapse !important;
    table-layout: auto !important;
    font-family: Arial, sans-serif;
    font-size: 12px;
}

.ChennaiScheduleGrid th {
    padding: 6px 8px !important;
    height: 30px !important;
    line-height: 18px !important;
    vertical-align: middle !important;
    white-space: nowrap !important;
    border: 1px solid #aaa !important;
}

.ChennaiScheduleGrid td {
    padding: 5px 8px !important;
    height: 30px !important;
    line-height: 18px !important;
    vertical-align: middle !important;
    white-space: nowrap !important;
    border: 1px solid #aaa !important;
}

/* Select */
.ChennaiScheduleGrid th:nth-child(1),
.ChennaiScheduleGrid td:nth-child(1) {
    width: 50px !important;
    min-width: 50px !important;
}

/* Source */
.ChennaiScheduleGrid th:nth-child(2),
.ChennaiScheduleGrid td:nth-child(2) {
    width: 100px !important;
    min-width: 100px !important;
}

/* Vessel */
.ChennaiScheduleGrid th:nth-child(3),
.ChennaiScheduleGrid td:nth-child(3) {
    width: 150px !important;
    min-width: 150px !important;
}

/* ETA */
.ChennaiScheduleGrid th:nth-child(4),
.ChennaiScheduleGrid td:nth-child(4) {
    width: 140px !important;
    min-width: 140px !important;
}

/* Revised ETA */
.ChennaiScheduleGrid th:nth-child(5),
.ChennaiScheduleGrid td:nth-child(5) {
    width: 220px !important;
    min-width: 220px !important;
}

/* LOA */
.ChennaiScheduleGrid th:nth-child(6),
.ChennaiScheduleGrid td:nth-child(6) {
    width: 70px !important;
    min-width: 70px !important;
    text-align: center;
}

/* Gate Open */
.ChennaiScheduleGrid th:nth-child(7),
.ChennaiScheduleGrid td:nth-child(7) {
    width: 150px !important;
    min-width: 150px !important;
}

/* Gate Cutoff */
.ChennaiScheduleGrid th:nth-child(8),
.ChennaiScheduleGrid td:nth-child(8) {
    width: 150px !important;
    min-width: 150px !important;
}

/* EGM */
.ChennaiScheduleGrid th:nth-child(9),
.ChennaiScheduleGrid td:nth-child(9) {
    width: 150px !important;
    min-width: 150px !important;
}

/* Branch */
.ChennaiScheduleGrid th:nth-child(10),
.ChennaiScheduleGrid td:nth-child(10) {
    width: 80px !important;
    min-width: 80px !important;
}

/* Created On */
.ChennaiScheduleGrid th:nth-child(11),
.ChennaiScheduleGrid td:nth-child(11) {
    width: 160px !important;
    min-width: 160px !important;
}
//
</style>

     
  
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
                        row.style.backgroundColor = "AquaBlue";
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
        function SingleSelect_VesselSchedule(obj) {
            var grid = obj.closest("table");
            if (!grid) return;

            var row = obj.closest("tr");
            if (!row) return;

            // Save the popup row index. This is more reliable than
            // depending on GridView checkbox ViewState after postback.
            var rows = grid.getElementsByTagName("tr");
            var rowIndex = -1;

            for (var i = 1; i < rows.length; i++) {
                if (rows[i] === row) {
                    rowIndex = i - 1;
                    break;
                }
            }

            var hidden = document.getElementById("hdn_SelectedScheduleIndex");
            if (hidden) {
                hidden.value = rowIndex;
            }

            var checkboxes = grid.querySelectorAll("input[type='checkbox']");

            for (var j = 0; j < checkboxes.length; j++) {
                if (checkboxes[j] !== obj) {
                    checkboxes[j].checked = false;
                }
            }
        }

    </script>


    <script type="text/javascript">
        function SelectChennaiRow(obj) {
            var row = obj.closest("tr");
            if (!row) return;

            var grid = obj.closest("table");
            if (!grid) return;

            var checkboxes = grid.querySelectorAll("input[type='checkbox']");
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] !== obj) {
                    checkboxes[i].checked = false;
                }
            }

            var cells = row.getElementsByTagName("td");

            document.getElementById("hdn_ChennaiVesselName").value =
                cells.length > 2 ? cells[2].innerText.trim() : "";

            document.getElementById("hdn_ChennaiETA").value =
                cells.length > 3 ? cells[3].innerText.trim() : "";

            document.getElementById("hdn_ChennaiRevisedETA").value =
                cells.length > 4 ? cells[4].innerText.trim() : "";

            var rows = grid.getElementsByTagName("tr");
            for (var r = 1; r < rows.length; r++) {
                if (rows[r] === row) {
                    document.getElementById("hdn_ChennaiSelectedIndex").value = r - 1;
                    break;
                }
            }
        }

        function SelectEnnoreRow(obj) {
            var row = obj.closest("tr");
            if (!row) return;

            var grid = obj.closest("table");
            if (!grid) return;

            var checkboxes = grid.querySelectorAll("input[type='checkbox']");
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] !== obj) {
                    checkboxes[i].checked = false;
                }
            }

            var cells = row.getElementsByTagName("td");

            var vesselName = cells.length > 2 ? cells[2].innerText.trim() : "";
            var etaDate = cells.length > 3 ? cells[3].innerText.trim() : "";
            var etaTime = cells.length > 5 ? cells[5].innerText.trim() : "";

            var eta = etaDate;
            if (etaTime !== "") {
                eta += " " + etaTime;
            }

            document.getElementById("hdn_EnnoreVesselName").value = vesselName;
            document.getElementById("hdn_EnnoreETA").value = eta;

            var rows = grid.getElementsByTagName("tr");
            for (var r = 1; r < rows.length; r++) {
                if (rows[r] === row) {
                    document.getElementById("hdn_EnnoreSelectedIndex").value = r - 1;
                    break;
                }
            }
        }

        function SelectKattupalliRow(obj) {
            var row = obj.closest("tr");
            if (!row) return;

            var grid = obj.closest("table");
            if (!grid) return;

            var checkboxes = grid.querySelectorAll("input[type='checkbox']");
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i] !== obj) {
                    checkboxes[i].checked = false;
                }
            }

            var cells = row.getElementsByTagName("td");

            var vesselName = cells.length > 2 ? cells[2].innerText.trim() : "";
            // var eta = cells.length > 4 ? cells[4].innerText.trim() : "";
            var ataEta = cells.length > 3 ? cells[3].innerText.trim() : "";

            document.getElementById("hdn_KattupalliVesselName").value = vesselName;
            document.getElementById("hdn_KattupalliETA").value = ataEta;

            var rows = grid.getElementsByTagName("tr");
            for (var r = 1; r < rows.length; r++) {
                if (rows[r] === row) {
                    document.getElementById("hdn_KattupalliSelectedIndex").value = r - 1;
                    break;
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
            <div id="innerbox_MidMain_Grid" style="height: 560px;">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1060px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px; font-size: 14px;">
                        Import ETA Bulk Entry</div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 100px;">
                        <div id="tag_label_transact_Src" style="width: 120px;">
                            <span style="color: Blue; font-size: 14px; font-weight: bold;">Jobno
                                <asp:Literal ID="lbljobno" runat="server"></asp:Literal>
                            </span>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 650px;">
                    </div>
                    <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                        <asp:Button ID="btn_Refresh" runat="server" Text="Refresh" TabIndex="100" Font-Bold="true"
                            Width="90px" Height="28px" ForeColor="Green" OnClick="btn_Refresh_Click" />
                    </div>
                </div>
                <div id="tag_srcinner1" style="margin-top: 25px; height: 80px;">
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1220px; height:30px;
                        margin-top: 10px;">
                        <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 95px;
                            color: Blue; font-size: 13px; font-weight: bold; ">
                            Action
                        </div>
                        <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 100px;">
                            <asp:DropDownList ID="ddl_flg" CssClass="listtxt_transac_item_gen_notn" Width="98px"
                                TabIndex="1" Font-Bold="true" Height="25px" Font-Size="12px" runat="server" AutoPostBack="true"
                                OnSelectedIndexChanged="ddl_flg_SelectedIndexChanged">
                                <asp:ListItem Text="View All" Value="V"></asp:ListItem>
                                <asp:ListItem Text="Save" Value="S"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 60px; ">
                            JobNo
                        </div>
                       
                        <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 100px;">
                            <asp:DropDownList ID="ddl_Jobno" runat="server" TabIndex="2" CssClass="listtxt_transac_mode_new"
                                AutoPostBack="true" Height="25px" Font-Bold="true" Width="100px" >
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 100px">
                          Filing Status
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 100px">
                             <asp:DropDownList ID="ddl_FilingStatus" CssClass="listtxt_transac_item_gen_notn" Width="98px"
                                TabIndex="3" Font-Bold="true" Height="25px" Font-Size="12px" runat="server">
                                <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Prior" Value="Prior"></asp:ListItem>
                                <asp:ListItem Text="Advanced" Value="Advanced"></asp:ListItem>
                                <asp:ListItem Text="Normal" Value="Normal"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                            Importer Name
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 260px;">
                            <asp:TextBox ID="txt_ImporterName" runat="server" MaxLength="50" Width="255px" TabIndex="4"
                                Height="25px"  Font-Bold="true" ClientIDMode="Static"
                                 CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </div>
                        
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                            <asp:Button ID="btn_Load_Data" runat="server" Text="Load Data" OnClick="btn_Load_Data_Click"
                                TabIndex="8" Font-Bold="true" Width="90px" Height="30px" ForeColor="Blue" />
                        </div>
                    </div>
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1100px;">
                        <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 95px;">
                            From Date
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 100px">
                            <asp:TextBox ID="txtFrom_Date" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                MaxLength="10" TabIndex="5" Width="100px" Height="25px"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtFrom_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFrom_Date"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 60px">
                            To Date
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 100px">
                            <asp:TextBox ID="txtTo_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new"
                                MaxLength="10" TabIndex="6" Width="100px" Height="25px"></asp:TextBox>
                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtTo_Date"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </asp:MaskedEditExtender>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTo_Date"
                                Format="dd/MM/yyyy">
                            </asp:CalendarExtender>
                        </div>
                          <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 100px">
                          ETA
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 100px">
                             <asp:DropDownList ID="ddl_ETA_Filter" CssClass="listtxt_transac_item_gen_notn" Width="98px"
                                TabIndex="7" Font-Bold="true" Height="25px" Font-Size="12px" runat="server">
                                 <asp:ListItem Text="" Value=""></asp:ListItem>
                                <asp:ListItem Text="Today" Value="1"></asp:ListItem>
                                <asp:ListItem Text="7 Days" Value="7"></asp:ListItem>
                                <asp:ListItem Text="15 Days" Value="15"></asp:ListItem>
                                <asp:ListItem Text="30 Days" Value="30"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                       
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 100px;">
                            Vessel Name
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 260px;">
                            <asp:TextBox ID="txtVesselName" runat="server" MaxLength="50" Width="255px" TabIndex="4"
                                Height="25px"  Font-Bold="true" ClientIDMode="Static"
                                 CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </div>
                         
                    </div>
                   
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1100px;">
                        <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 995px;">
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 80px; font-weight: bold;">
                            Row Count :
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 25px;">
                            <asp:Label ID="lbl_Cnt" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                        </div>
                    </div>
                  
                    <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1100px; ">
                     </div>
                </div>
               

                <%--<div id="tag_srcinner1" style="height: 30px;">
                </div>--%>
                <%-- -------------------------------------Tab--------------------------------------------------------%>
              

              
                <div id="tag_transac_export_lft_item_gen_Grid_comp" style="width: 1294px; height: 430px; margin-top:10px;">
                    <asp:GridView runat="server" ID="gvdetails" AutoGenerateColumns="false" DataKeyNames="CUSTOMS_HOUSE" OnRowDataBound="gvdetails_RowDataBound" OnRowCommand="gvdetails_RowCommand" 
                        Width="100%" ShowHeader="true" ShowFooter="false" BackColor="LightGray" ShowHeaderWhenEmpty="true" HeaderStyle-Height="30px" 
                        GridLines="None" BorderStyle="Groove" BorderWidth="1px" CellPadding="1" CellSpacing="1" HeaderStyle-BackColor="AliceBlue"
                        HeaderStyle-Font-Size="14px" CssClass="gridview" 
        HeaderStyle-CssClass="grid-header" >
                        <AlternatingRowStyle BackColor="LightGray" BorderColor="Black" BorderWidth="1px"  />
                        <HeaderStyle Font-Underline="false" ForeColor="Black"  />
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
                            
                            <asp:BoundField DataField="JOBID"   ControlStyle-Width="60px"  HeaderStyle-Width="60px" HeaderStyle-Height="50px"  SortExpression="JOBNO">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="JOBNO"  ControlStyle-Width="60px"  >
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="JOBNO_PS" HeaderText="JobNo" ControlStyle-Width="60px"  HeaderStyle-Width="60px"  SortExpression="JOBNO">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                              <asp:BoundField DataField="JOBDATE" HeaderText="Job Date" ControlStyle-Width="60px"  HeaderStyle-Width="60px"  SortExpression="JOBNO">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                              <asp:BoundField DataField="CUSTOMS_HOUSE" HeaderText="Port" ControlStyle-Width="70px"  HeaderStyle-Width="70px"  >
                                <ItemStyle CssClass="column_style_left6"   Width="70px"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="FILING_STATUS" HeaderText="F.Status" ControlStyle-Width="50px"  HeaderStyle-Width="60px" >
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                              <asp:BoundField DataField="IMPORTER_NAME" HeaderText="Importer Name" ControlStyle-Width="100px"  HeaderStyle-Width="230px" >
                                <ItemStyle CssClass="column_style_left6"   Width="230px"  />
                            </asp:BoundField>
                              <asp:BoundField DataField="BE_NO" HeaderText="BE No" ControlStyle-Width="50px"  HeaderStyle-Width="60px" >
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="ETA" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="DarkBlue"  HeaderStyle-Width="90px" >
                                <ItemTemplate>
                                     <asp:TextBox ID="txtETA" runat="server" onblur="ChangeCase(this);" MaxLength="10" TabIndex="16"  BackColor="PeachPuff" Font-Bold="true"
                                onkeypress="return AllowAlphabet(event)" Text='<%#Eval("ETA") %>'
                                Width="90px" Height="25px" CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                 <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" TargetControlID="txtETA"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True" >
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtETA"
                                PopupButtonID="txtJobDate" Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>
                            </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Remarks" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="DarkBlue" HeaderStyle-Width="290px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Remarks" runat="server" Text='<%#Eval("REMARKS") %>'
                                        MaxLength="2000" TabIndex="16" Width="290px" Height="25px"
                                        CssClass="autocomplete txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Vessel Name" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="DarkBlue" HeaderStyle-Width="150px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_VesselName" runat="server" Text='<%#Eval("VESSEL_NAME") %>'
                                        MaxLength="50" TabIndex="16" Width="150px" Height="25px"
                                        CssClass="autocomplete txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Voyage" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="DarkBlue" HeaderStyle-Width="80px">
                                <ItemTemplate>
                                    <asp:TextBox ID="txt_Voyage" runat="server" Text='<%#Eval("IGM_VOYAGE") %>'
                                        MaxLength="50" TabIndex="16" Width="80px" Height="25px"
                                        CssClass="autocomplete txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Berthing-Report" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="DarkBlue" HeaderStyle-Width="80px">
    <ItemTemplate>
        <asp:LinkButton ID="eta_link" runat="server" Text="View"  ForeColor="Blue"  CommandName="ViewVessel"
            CommandArgument='<%# Container.DataItemIndex %>'
            CssClass="txtbox_none_Mid_transac_Supp_Name">
        </asp:LinkButton>
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
                    <asp:Button ID="btnsave" runat="server" Text="Bulk Update" OnClick="btnsave_Click"
                        Font-Bold="true" TabIndex="9" Width="100px" Height="30px" ForeColor="Blue" />
                </div>
            </div>
            <%-----------------------------------END----------------------------------------------------------------%>
            <asp:HiddenField ID="HDBranch" runat="server" />
            <asp:HiddenField ID="hdn_ICEGATE_ID_List" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_YN" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdnjobno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="HiddenField2" runat="server" />
            <asp:HiddenField ID="confirm_value" runat="server" />
            <asp:ModalPopupExtender ID="MP_JOB" runat="server" TargetControlID="HDU_JOB" PopupControlID="MessageDivupdated_Job"
                BackgroundCssClass="modalBackground" DropShadow="false">
            </asp:ModalPopupExtender>
            <asp:HiddenField ID="HDU_JOB" runat="server" />
            <asp:Panel ID="MessageDivupdated_Job" runat="server" CssClass="modalPopup12" align="left"
                BorderColor="Transparent">
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 800px; height: 20px;
                    font-weight: bold; color: Blue;">
                    <div style="margin-left: 90px;">
                        <asp:Label ID="lbl_heading" runat="server"></asp:Label></div>
                </div>
              
                <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 800px; height: 30px;">
                    <div style="margin-left: 280px;">
                        <asp:Button ID="btnok" runat="server" Text="Ok" OnClick="btnok_Click" /></div>
                </div>
            </asp:Panel>

            <!-- ================= VESSEL SCHEDULE POPUPS ================= -->

            <!-- ================= CHENNAI : PSA + DP WORLD ================= -->

            <asp:ModalPopupExtender ID="MP_ChennaiSchedule" runat="server"
                TargetControlID="HDU_ChennaiSchedule"
                PopupControlID="Panel_ChennaiSchedule"
                BackgroundCssClass="modalBackground"
                DropShadow="true">
            </asp:ModalPopupExtender>

            <asp:HiddenField ID="HDU_ChennaiSchedule" runat="server" />

            <asp:HiddenField ID="hdn_ChennaiSelectedIndex" runat="server"
                ClientIDMode="Static" Value="-1" />

            <asp:HiddenField ID="hdn_ChennaiVesselName" runat="server"
                ClientIDMode="Static" />

            <asp:HiddenField ID="hdn_ChennaiETA" runat="server"
                ClientIDMode="Static" />

            <asp:HiddenField ID="hdn_ChennaiRevisedETA" runat="server"
                ClientIDMode="Static" />

            <%--<asp:Panel ID="Panel_ChennaiSchedule" runat="server"
                CssClass="modalPopup12"
                align="left"
                BorderColor="Transparent"
                Style="width:1250px; max-height:600px; overflow:auto; background-color:white;">

                <div style="width:1230px; padding:10px;">

                    <div style="font-size:18px; font-weight:bold; color:Blue;
                                padding:8px; border-bottom:1px solid #ccc;">
                        <asp:Label ID="lbl_ChennaiScheduleHeading"
                            runat="server"
                            Text="Chennai Vessel Schedule - PSA + DP World">
                        </asp:Label>
                    </div>

                    <div style="margin-top:10px;">

                        <asp:GridView ID="gvChennaiSchedule"
                            runat="server"
                            AutoGenerateColumns="false"
                            Width="100%"
                            GridLines="Both"
                            BorderWidth="1px"
                            CellPadding="5"
                            HeaderStyle-BackColor="AliceBlue"
                            HeaderStyle-ForeColor="Black"
                            HeaderStyle-Font-Bold="true"
                            ShowHeaderWhenEmpty="true">

                            <Columns>

                                <asp:TemplateField HeaderText="Select"
                                    HeaderStyle-Width="70px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelectChennai"
                                            runat="server"
                                            onclick="SelectChennaiRow(this);" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Source" HeaderText="Source" />
                                <asp:BoundField DataField="VESSEL_NAME" HeaderText="Vessel Name" />
                                <asp:BoundField DataField="ETA" HeaderText="ETA" />
                                <asp:BoundField DataField="REVISED_ETA" HeaderText="Revised ETA" />
                                <asp:BoundField DataField="LOA" HeaderText="LOA" />
                                <asp:BoundField DataField="GATE_OPEN" HeaderText="Gate Open" />
                                <asp:BoundField DataField="GATE_CUTOFF" HeaderText="Gate Cutoff" />
                                <asp:BoundField DataField="EGM_IGM_DATE" HeaderText="EGM/IGM Date" />
                                <asp:BoundField DataField="BRANCH" HeaderText="Branch" />
                                <asp:BoundField DataField="CREATED_ON" HeaderText="CREATED ON" />

                            </Columns>

                        </asp:GridView>

                    </div>

                    <div style="text-align:center; margin-top:15px; padding-bottom:10px;">

                        <asp:Button ID="btn_ChennaiScheduleUpdate"
                            runat="server"
                            Text="Update"
                            Width="100px"
                            Height="30px"
                            Font-Bold="true"
                            ForeColor="Blue"
                            OnClick="btn_ChennaiScheduleUpdate_Click" />

                        &nbsp;&nbsp;

                        <asp:Button ID="btn_ChennaiScheduleClose"
                            runat="server"
                            Text="Close"
                            Width="100px"
                            Height="30px"
                            OnClick="btn_ChennaiScheduleClose_Click" />

                    </div>

                </div>

            </asp:Panel>--%>

            <asp:Panel ID="Panel_ChennaiSchedule"
    runat="server"
    CssClass="modalPopup12"
    align="left"
    BorderColor="Transparent"
    Style="
        width:1450px;
        max-width:95vw;
        max-height:650px;
        overflow:auto;
        background-color:white;
        padding:10px;
        box-sizing:border-box;">

    <div style="
        width:1400px;
        padding:5px;
        box-sizing:border-box;">

        <div style="
            font-size:18px;
            font-weight:bold;
            color:Blue;
            padding:8px;
            border-bottom:1px solid #ccc;">

            <asp:Label ID="lbl_ChennaiScheduleHeading"
                runat="server"
                Text="Chennai Vessel Schedule - PSA + DP World">
            </asp:Label>

        </div>

        <div style="
            margin-top:10px;
            width:1400px;
            ">

            <asp:GridView ID="gvChennaiSchedule"
                runat="server"
                AutoGenerateColumns="false"
                Width="1400px"
                GridLines="Both"
                BorderWidth="1px"
                CellPadding="0"
                CellSpacing="0"
                HeaderStyle-BackColor="AliceBlue"
                HeaderStyle-ForeColor="Black"
                HeaderStyle-Font-Bold="true"
                ShowHeaderWhenEmpty="true"
                CssClass="ChennaiScheduleGrid">

                <Columns>

                    <asp:TemplateField HeaderText="Select"
                        HeaderStyle-Width="50px">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkSelectChennai"
                                runat="server"
                                onclick="SelectChennaiRow(this);" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField
                        DataField="Source"
                        HeaderText="Source" />

                    <asp:BoundField
                        DataField="VESSEL_NAME"
                        HeaderText="Vessel Name" />

                    <asp:BoundField
                        DataField="ETA"
                        HeaderText="ETA" />

                    <asp:BoundField
                        DataField="REVISED_ETA"
                        HeaderText="Revised ETA" />

                    <asp:BoundField
                        DataField="LOA"
                        HeaderText="LOA" />

                    <asp:BoundField
                        DataField="GATE_OPEN"
                        HeaderText="Gate Open" />

                    <asp:BoundField
                        DataField="GATE_CUTOFF"
                        HeaderText="Gate Cutoff" />

                    <asp:BoundField
                        DataField="EGM_IGM_DATE"
                        HeaderText="EGM/IGM Date" />

                    <asp:BoundField
                        DataField="BRANCH"
                        HeaderText="Branch" />

                    <asp:BoundField
                        DataField="CREATED_ON"
                        HeaderText="CREATED ON" />

                </Columns>

            </asp:GridView>

        </div>

        <div style="
            text-align:center;
            margin-top:15px;
            padding-bottom:10px;">

            <asp:Button ID="btn_ChennaiScheduleUpdate"
                runat="server"
                Text="Update"
                Width="100px"
                Height="30px"
                Font-Bold="true"
                ForeColor="Blue"
                OnClick="btn_ChennaiScheduleUpdate_Click" />

            &nbsp;&nbsp;

            <asp:Button ID="btn_ChennaiScheduleClose"
                runat="server"
                Text="Close"
                Width="100px"
                Height="30px"
                OnClick="btn_ChennaiScheduleClose_Click" />

        </div>

    </div>

</asp:Panel>


            <!-- ================= ENNORE : SEPARATE POPUP ================= -->

            <asp:ModalPopupExtender ID="MP_EnnoreSchedule" runat="server"
                TargetControlID="HDU_EnnoreSchedule"
                PopupControlID="Panel_EnnoreSchedule"
                BackgroundCssClass="modalBackground"
                DropShadow="true">
            </asp:ModalPopupExtender>

            <asp:HiddenField ID="HDU_EnnoreSchedule" runat="server" />

            <asp:HiddenField ID="hdn_EnnoreSelectedIndex" runat="server"
                ClientIDMode="Static" Value="-1" />

            <asp:HiddenField ID="hdn_EnnoreVesselName" runat="server"
                ClientIDMode="Static" />

            <asp:HiddenField ID="hdn_EnnoreETA" runat="server"
                ClientIDMode="Static" />

            <asp:Panel ID="Panel_EnnoreSchedule" runat="server"
    CssClass="modalPopup12"
    align="left"
    BorderColor="Transparent"
    Style="width:1450px; max-width:95vw; max-height:650px; overflow:auto; background-color:white; padding:10px; box-sizing:border-box;">

    <div style="width:1400px; padding:5px; box-sizing:border-box;">

                    <div style="font-size:18px; font-weight:bold; color:Blue;
             padding:8px; border-bottom:1px solid #ccc;">
                        <asp:Label ID="lbl_EnnoreScheduleHeading"
                            runat="server"
                            Text="Ennore Vessel Schedule - All Vessels">
                        </asp:Label>
                    </div>

                    <div style="margin-top:10px;">

                        <asp:GridView ID="gvEnnoreSchedule"
                            runat="server"
                            AutoGenerateColumns="false"
                            Width="1400px"
                            GridLines="Both"
                            BorderWidth="1px"
                            CellPadding="0"
                            CellSpacing="0"
                            HeaderStyle-BackColor="AliceBlue"
                            HeaderStyle-ForeColor="Black"
                            HeaderStyle-Font-Bold="true"
                            ShowHeaderWhenEmpty="true"
                            CssClass="ChennaiScheduleGrid">

                            <Columns>

                                <asp:TemplateField HeaderText="Select"
                                    HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelectEnnore"
                                            runat="server"
                                            onclick="SelectEnnoreRow(this);" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Source" HeaderText="Source" />
                                <asp:BoundField DataField="VESSEL_NAME" HeaderText="Vessel Name" />
                                <asp:BoundField DataField="AtaEtaDate" HeaderText="AtaEtaDate" />
                                <asp:BoundField DataField="AtaEtaDay" HeaderText="AtaEtaDay" />
                                <asp:BoundField DataField="AtaEtaTime" HeaderText="AtaEtaTime" />
                                <asp:BoundField DataField="Etb" HeaderText="Etb" />
                                <asp:BoundField DataField="FinalCutOff" HeaderText="Final CutOff" />
                                <asp:BoundField DataField="Branch" HeaderText="Branch" />
                                <asp:BoundField DataField="CREATED_ON" HeaderText="CREATED ON" />

                            </Columns>

                        </asp:GridView>

                    </div>

                    <div style="text-align:center; margin-top:15px; padding-bottom:10px;">

                        <asp:Button ID="btn_EnnoreScheduleUpdate"
                            runat="server"
                            Text="Update"
                            Width="100px"
                            Height="30px"
                            Font-Bold="true"
                            ForeColor="Blue"
                            OnClick="btn_EnnoreScheduleUpdate_Click" />

                        &nbsp;&nbsp;

                        <asp:Button ID="btn_EnnoreScheduleClose"
                            runat="server"
                            Text="Close"
                            Width="100px"
                            Height="30px"
                            OnClick="btn_EnnoreScheduleClose_Click" />

                    </div>

                </div>

            </asp:Panel>


            <!-- ================= KATTUPALLI : SEPARATE POPUP ================= -->

            <asp:ModalPopupExtender ID="MP_KattupalliSchedule" runat="server"
                TargetControlID="HDU_KattupalliSchedule"
                PopupControlID="Panel_KattupalliSchedule"
                BackgroundCssClass="modalBackground"
                DropShadow="true">
            </asp:ModalPopupExtender>

            <asp:HiddenField ID="HDU_KattupalliSchedule" runat="server" />

            <asp:HiddenField ID="hdn_KattupalliSelectedIndex" runat="server"
                ClientIDMode="Static" Value="-1" />

            <asp:HiddenField ID="hdn_KattupalliVesselName" runat="server"
                ClientIDMode="Static" />

            <asp:HiddenField ID="hdn_KattupalliETA" runat="server"
                ClientIDMode="Static" />

            <asp:Panel ID="Panel_KattupalliSchedule" runat="server"
    CssClass="modalPopup12"
    align="left"
    BorderColor="Transparent"
    Style="width:1450px; max-width:95vw; max-height:650px; overflow:auto; background-color:white; padding:10px; box-sizing:border-box;">

    <div style="width:1400px; padding:5px; box-sizing:border-box;">

                    <div style="font-size:18px; font-weight:bold; color:Blue;
                                padding:8px; border-bottom:1px solid #ccc;">
                        <asp:Label ID="lbl_KattupalliScheduleHeading"
                            runat="server"
                            Text="Kattupalli Vessel Schedule - All Vessels">
                        </asp:Label>
                    </div>

                    <div style="margin-top:10px;">

                        <asp:GridView ID="gvKattupalliSchedule"
                            runat="server"
                            AutoGenerateColumns="false"
                            Width="1400px"
                            GridLines="Both"
                            BorderWidth="1px"
                            CellPadding="0"
                            CellSpacing="0"
                            HeaderStyle-BackColor="AliceBlue"
                            HeaderStyle-ForeColor="Black"
                            HeaderStyle-Font-Bold="true"
                            ShowHeaderWhenEmpty="true"
                            CssClass="ChennaiScheduleGrid">

                            <Columns>

                                <asp:TemplateField HeaderText="Select"
                                    HeaderStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelectKattupalli"
                                            runat="server"
                                            onclick="SelectKattupalliRow(this);" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="Source" HeaderText="Source" />
                                <asp:BoundField DataField="VESSEL_NAME" HeaderText="Vessel Name" />
                                <asp:BoundField DataField="ATAETA" HeaderText="AtaEta" />
                                <asp:BoundField DataField="ETA" HeaderText="ETA" />
                                <asp:BoundField DataField="ETB" HeaderText="Etb" />
                                <asp:BoundField DataField="GATE_CUTOFF" HeaderText="GATE_CUTOFF" />
                                <asp:BoundField DataField="BRANCH" HeaderText="Branch" />
                                <asp:BoundField DataField="CREATED_ON" HeaderText="CREATED ON" />

                            </Columns>

                        </asp:GridView>

                    </div>

                    <div style="text-align:center; margin-top:15px; padding-bottom:10px;">

                        <asp:Button ID="btn_KattupalliScheduleUpdate"
                            runat="server"
                            Text="Update"
                            Width="100px"
                            Height="30px"
                            Font-Bold="true"
                            ForeColor="Blue"
                            OnClick="btn_KattupalliScheduleUpdate_Click" />

                        &nbsp;&nbsp;

                        <asp:Button ID="btn_KattupalliScheduleClose"
                            runat="server"
                            Text="Close"
                            Width="100px"
                            Height="30px"
                            OnClick="btn_KattupalliScheduleClose_Click" />

                    </div>

                </div>

            </asp:Panel>

            <!-- ================= END VESSEL SCHEDULE POPUPS ================= -->

        </ContentTemplate>
    </asp:UpdatePanel>
  </form>

    
<script type="text/javascript">

    $(function () {
        $("#txt_ImporterName").autocomplete({

            source: function (request, response) {
                var field = $(this.element).attr('id');
                call_url = '../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_List';
                $.ajax({

                    url: call_url,
                    data: "{ 'mail': '" + request.term + "' ,'IEC':'" + '' + "'}",

                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {

                        response(data.d);

                        if (field == 'txt_ImporterName') {
                            jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Importer Name', 'error', 'topRight', true);
                        }
                        else {
                            jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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



    $(function () {
        $("#txtVesselName").autocomplete({

            source: function (request, response) {

                $.ajax({
                    url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/IGM_Vessel_MASTER",
                    data: "{ 'mail': '" + request.term + "' }",
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    async: true,
                    success: function (data) {
                        response(data.d);
                        if (data.d == '') {
                            jQuery('#txtVesselName').validationEngine('showPrompt', 'Incorrect Airline Name', 'error', 'topRight', true);
                        }
                        else {
                            jQuery('#txtVesselName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //alert(textStatus);
                    }
                });
            },
            minLength: 1

        });
        return false;
        scroll: true;

    });


</script>

    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
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
