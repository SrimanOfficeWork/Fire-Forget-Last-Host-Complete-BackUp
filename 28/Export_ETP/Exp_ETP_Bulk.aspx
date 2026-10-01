<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Exp_ETP_Bulk.aspx.cs" Inherits="Imp_ETA_Bulk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Export ETP Bulk Entry </title>
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
     table-layout: auto;
}

.gridview th,
.gridview td {
    border: 1px solid #ccc;
    padding: 4px 6px;
    white-space: nowrap;
    font-size: 12px;
    min-width: 70px;          /* &#2962;&#2997;&#3021;&#2997;&#3018;&#2992;&#3009; column-&#2965;&#3021;&#2965;&#3009;&#2990;&#3021; minimum width */
}
.gridview th {
    position: sticky;
    top: 0;
    background-color: #f2f2f2;
    z-index: 100;
    overflow: visible;        /* ellipsis-&#2960; header-&#2994; remove &#2986;&#2979;&#3021;&#2979;&#3009;&#2969;&#3021;&#2965; */

}
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

    $(function () {
        $("#txt_Containe").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "Exp_ETP_Bulk.aspx/Get_ContainerNo_Search",
                    data: JSON.stringify({ Container_No: request.term }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);

                        if (data.d.length == 0) {
                            jQuery('#txt_Containe').validationEngine('showPrompt', 'Incorrect Container No', 'error', 'topRight', true);
                        } else {
                            jQuery('#txt_Containe').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        }
                    },
                    error: function (err) {
                        console.log(err.responseText);
                    }
                });
            },
            minLength: 1,
            select: function (event, ui) {
                jQuery('#txt_Containe').validationEngine('hidePrompt', '', 'error', 'topRight', true);
            }
        });
    });


    $(function () {
        $("#trasshipmnet_no").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "Exp_ETP_Bulk.aspx/Get_trasshipment_no_Search",
                    data: JSON.stringify({ trasshipment_no: request.term }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);

                        if (data.d.length == 0) {
                            jQuery('#trasshipmnet_no').validationEngine('showPrompt', 'Incorrect trasshipmnet No', 'error', 'topRight', true);
                        } else {
                            jQuery('#trasshipmnet_no').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        }
                    },
                    error: function (err) {
                        console.log(err.responseText);
                    }
                });
            },
            minLength: 1,
            select: function (event, ui) {
                jQuery('#trasshipmnet_no').validationEngine('hidePrompt', '', 'error', 'topRight', true);
            }
        });
    });



    $(function () {
        $("#Gate_port").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "Exp_ETP_Bulk.aspx/Gate_port_Search",
                    data: JSON.stringify({ Gate_port: request.term }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);

                        if (data.d.length == 0) {
                            jQuery('#Gate_port').validationEngine('showPrompt', 'Incorrect GateWay Port', 'error', 'topRight', true);
                        } else {
                            jQuery('#Gate_port').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        }
                    },
                    error: function (err) {
                        console.log(err.responseText);
                    }
                });
            },
            minLength: 1,
            select: function (event, ui) {
                jQuery('#Gate_port').validationEngine('hidePrompt', '', 'error', 'topRight', true);
            }
        });
    });


    $(function () {
        $("#carr_no").autocomplete({
            source: function (request, response) {
                $.ajax({
                    type: "POST",
                    url: "Exp_ETP_Bulk.aspx/carr_no_Search",
                    data: JSON.stringify({ carr_no: request.term }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        response(data.d);

                        if (data.d.length == 0) {
                            jQuery('#carr_no').validationEngine('showPrompt', 'Incorrect Carrier No', 'error', 'topRight', true);
                        } else {
                            jQuery('#carr_no').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                        }
                    },
                    error: function (err) {
                        console.log(err.responseText);
                    }
                });
            },
            minLength: 1,
            select: function (event, ui) {
                jQuery('#carr_no').validationEngine('hidePrompt', '', 'error', 'topRight', true);
            }
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
            <div id="innerbox_MidMain_Grid" style="height: 560px;">
                <div id="tag_transac_lft_Trans_Invoice_transac_other_duty" style="width: 1060px;">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px; font-size: 14px;">
                        Export ETP Master</div>
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
                   <%-- <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 30px;">
                        <asp:Button ID="btn_Refresh" runat="server" Text="Refresh" TabIndex="100" Font-Bold="true"
                            Width="90px" Height="28px" ForeColor="Green" OnClick="btn_Refresh_Click" />
                    </div>--%>
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
                               >
                                <asp:ListItem Text="Job Date" Value="JOBDATE"></asp:ListItem>
                                <asp:ListItem Text="Transshipment Date" Value="TRANSSHIPMENT_DATE"></asp:ListItem>
                                <asp:ListItem Text="Bond Date" Value="BOND_DATE"></asp:ListItem>
                                <asp:ListItem Text="SB Date" Value="SB_DATE"></asp:ListItem>
                               <%-- <asp:ListItem Text="" Value=""></asp:ListItem>--%>

                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 60px; ">
                            JobNo
                        </div>
                       
                        <div id="txtcon-m_transaction_Supp_code_Re_Import" style="width: 100px;">
                             <%--<asp:TextBox ID="job_no" runat="server" MaxLength="50" Width="100px" TabIndex="4"
                                Height="25px"  Font-Bold="true" ClientIDMode="Static"
                                 CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>--%>

                                 <asp:DropDownList ID="ddl_Jobno" runat="server" TabIndex="2" CssClass="listtxt_transac_mode_new"
                                AutoPostBack="true" Height="25px" Font-Bold="true" Width="100px" >
                            </asp:DropDownList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 130px">
                          Containe No
                        </div>
                        <div id="txtcon-m_transaction_code" style="width: 170px">
                             <asp:TextBox ID="txt_Containe" runat="server" MaxLength="50" Width="150px" TabIndex="4"
                                Height="25px"  Font-Bold="true" ClientIDMode="Static"
                                 CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 120px; margin-left:10px">
                            Transshipment No
                        </div>
                         <div id="txtcon-m_transaction_item_maindet" style="width: 110px;">
                            <asp:TextBox ID="trasshipmnet_no" runat="server" MaxLength="50" Width="100px" TabIndex="4"
                                Height="25px"  Font-Bold="true" ClientIDMode="Static"
                                 CssClass="txtbox_none_Mid_transac_Supp_Name"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 90px;">
                             Gateway Port
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                            <asp:TextBox ID="Gate_port" runat="server" MaxLength="50" Width="100px" TabIndex="4"
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
                        <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 130px;">
                             Mode of Transport
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 180px;">
                          <asp:DropDownList ID="ddl_Tr_mode" runat="server" Width="120px" Height="25px" CssClass="listtxt_transac_FCL"
                                    TabIndex="20">
                                      <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="T - Truck" Value="T"></asp:ListItem>
                                    <asp:ListItem Text="V - Vessel" Value="V"></asp:ListItem>
                                    <asp:ListItem Text="R - Railway" Value="R"></asp:ListItem>
                                </asp:DropDownList>
                        </div>

                         <div id="tag_label_transaction_popup_IGM_invoice_Supp_others" style="width: 120px;">                      
                              Carrier No
                        </div>
                        <div id="txtcon-m_transaction_item_maindet" style="width: 100px;">
                            <asp:TextBox ID="carr_no" runat="server" MaxLength="50" Width="100px" TabIndex="4"
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
                      <%--<div id="excel_label" runat="server" style="margin: 0px 50px 0px 50px; text-align: center" Visible="false"  >
                <asp:ImageButton ID="btnexcel" runat="server" ImageUrl="~/images/xls.jpg" Height="28px"
                         Width="28px" onclick="btnexcel_Click"  />
                </div>--%>
                <asp:Panel ID="excel_label" runat="server" Visible="false">
    <asp:ImageButton ID="btnexcel" runat="server"
        ImageUrl="~/images/xls.jpg"
        Height="28px"
        Width="28px"
        OnClick="btnexcel_Click" 
         OnClientClick="
        function hideOverlay() {
            var bg = document.getElementsByClassName('Background');
            for (var i = 0; i < bg.length; i++) { bg[i].style.display = 'none'; }
            var loadDiv = document.getElementById('load');
            if (loadDiv) { loadDiv.style.display = 'none'; }
        }
        setTimeout(hideOverlay, 0);
        setTimeout(hideOverlay, 100);
        setTimeout(hideOverlay, 500);
        setTimeout(hideOverlay, 1500);
         setTimeout(function() {
            hideOverlay();
            alert('Excel downloaded successfully.');
        }, 1800);
        return true;" 
        />
</asp:Panel>
                </div>
               

                <%--<div id="tag_srcinner1" style="height: 30px;">
                </div>--%>
                <%-- -------------------------------------Tab--------------------------------------------------------%>
              

              
                <div id="tag_transac_export_lft_item_gen_Grid_comp" style="width: 1294px; height: 430px; margin-top:10px;">
                    <asp:GridView runat="server" ID="gvdetails" AutoGenerateColumns="false" OnRowDataBound="gvdetails_RowDataBound" 
                        Width="100%" ShowHeader="true" ShowFooter="false" BackColor="LightGray" ShowHeaderWhenEmpty="true" HeaderStyle-Height="30px" 
                        GridLines="None" BorderStyle="Groove" BorderWidth="1px" CellPadding="1" CellSpacing="1" HeaderStyle-BackColor="AliceBlue"
                        HeaderStyle-Font-Size="14px" CssClass="gridview"
        HeaderStyle-CssClass="grid-header" >
                        <AlternatingRowStyle BackColor="LightGray" BorderColor="Black" BorderWidth="1px"  />
                        <HeaderStyle Font-Underline="false" ForeColor="Black" />
                        <Columns>
                             <asp:BoundField DataField="JOBNO_PS" HeaderText="JobNo" ControlStyle-Width="60px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true"  SortExpression="JOBNO">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                              <asp:BoundField DataField="JOBDATE" HeaderText="JOBDATE" ControlStyle-Width="60px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true" SortExpression="JOBNO">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                              <asp:BoundField DataField="SB_NO" HeaderText="SB_NO" ControlStyle-Width="70px"  HeaderStyle-Width="70px"  HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="70px"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="SB_DATE" HeaderText="SB_DATE" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                              <asp:BoundField DataField="TRANSSHIPMENT_DATE" HeaderText="TRANSSHIPMENT_DATE" ControlStyle-Width="100px"  HeaderStyle-Width="230px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="230px"  />
                            </asp:BoundField>
                              <asp:BoundField DataField="TRANSSHIPMENT_NO" HeaderText="TRANSSHIPMENT_NO" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="GATEWAY_PORT" HeaderText="GATEWAY_PORT" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="PORT_DISCHARGE" HeaderText="PORT_DISCHARGE" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="TR_MODE" HeaderText="TR_MODE" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="CARRIER_CODE" HeaderText="CARRIER_CODE" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                               <asp:BoundField DataField="CARRIER_NO" HeaderText="CARRIER_NO" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="GROSS_WGT" HeaderText="GROSS_WGT" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                                <asp:BoundField DataField="TOTAL_PKG" HeaderText="TOTAL_PKG" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="NATURE_OF_CARGO" HeaderText="NATURE_OF_CARGO" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="BOND_CODE" HeaderText="BOND_CODE" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="BOND_NO" HeaderText="BOND_NO" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="BOND_DATE" HeaderText="BOND_DATE" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="BOND_SITE" HeaderText="BOND_SITE" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                              <asp:BoundField DataField="SITE_ID" HeaderText="SITE_ID" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="AWB_NO" HeaderText="AWB_NO" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="STUFF_PORT" HeaderText="STUFF_PORT" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                           <%-- <asp:BoundField DataField="BRANCH_CODE" HeaderText="BRANCH_CODE" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="WORKINGPERIOD" HeaderText="WORKINGPERIOD" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>--%>
                             <asp:BoundField DataField="CON_NO" HeaderText="CON_NO" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                             <asp:BoundField DataField="CON_SIZE" HeaderText="CON_SIZE" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                            <asp:BoundField DataField="LCL_FCL" HeaderText="LCL_FCL" ControlStyle-Width="50px"  HeaderStyle-Width="60px" HeaderStyle-Font-Bold="true">
                                <ItemStyle CssClass="column_style_left6"   Width="60px"  />
                            </asp:BoundField>
                           
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
              
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
     <%--<iframe name="hiddenDownloadFrame" style="display:none; width:0; height:0; border:0;"></iframe>--%>
  </form>
 
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
