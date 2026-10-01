<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Item_Lic_Copy.aspx.cs" Inherits="Imp_Item_Lic_Copy" %>
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
    <script  src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>
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
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8"> </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8"> </script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <style type="text/css">
        .datagrid table
        {
            border-collapse: collapse;
            text-align: left;
            width: 100%;
        }
        .datagrid
        {
            font: normal 12px/150% Arial, Helvetica, sans-serif;
            background: #fff;
            overflow: hidden;
            border: 1px solid #8C8C8C;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
        }
        .datagrid table td, .datagrid table th
        {
            padding: 3px 10px;
        }
        .datagrid table thead th
        {
            background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );
            background: -moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');
            background-color: #8C8C8C;
            color: #FFFFFF;
            font-size: 15px;
            font-weight: bold;
            border-left: 1px solid gray;
        }
        .datagrid table thead th:first-child
        {
            border: none;
        }
        .datagrid table tbody td
        {
            /*color: #7D7D7D;*/
            border-left: 1px solid #DBDBDB;
            font-size: 12px;
            font-weight: normal;
        }
        .datagrid table tbody .alt td
        {
            background: #EBEBEB;
            color: #7D7D7D;
        }
        .datagrid table tbody td:first-child
        {
            border-left: none;
        }
        .datagrid table tbody tr:last-child td
        {
            border-bottom: none;
        }
        .datagrid table tfoot td div
        {
            border-top: 1px solid #8C8C8C;
            background: #EBEBEB;
        }
        .datagrid table tfoot td
        {
            padding: 0;
            font-size: 12px;
        }
        .datagrid table tfoot td div
        {
            padding: 2px;
        }
        .datagrid table tfoot td ul
        {
            margin: 0;
            padding: 0;
            list-style: none;
            text-align: right;
        }
        .datagrid table tfoot li
        {
            display: inline;
        }
        .datagrid table tfoot li a
        {
            text-decoration: none;
            display: inline-block;
            padding: 2px 8px;
            margin: 1px;
            color: #F5F5F5;
            border: 1px solid #8C8C8C;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );
            background: -moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');
            background-color: #8C8C8C;
        }
        .datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover
        {
            text-decoration: none;
            border-color: #7D7D7D;
            color: #F5F5F5;
            background: none;
            background-color: #8C8C8C;
        }
        div.dhtmlx_window_active, div.dhx_modal_cover_dv
        {
            position: fixed !important;
        }
        .swal2-popup.swal2-modal.swal2-show
        {
            margin: 146px;
            left: -17%;
            width: 35%;
            top: -8%;
            height: 163px;
        }
        #swal2-title
        {
            font-size: 15px;
            top: 38%;
        }
        .swal2-icon.swal2-warning.swal2-icon-show
        {
            left: 43%;
            width: 16%;
            height: 51px;
            top: 30%;
            background: orange;
            color: #f2eeea;
            border: 1px solid #f0c2c2;
        }
        .swal2-actions
        {
            margin-left: 41%;
            margin-top: 24px;
        }
        .swal2-x-mark-line-left
        {
            top: 19px !important;
            font-size: 9px !important;
            left: 7px !important;
        }
        .swal2-x-mark-line-right
        {
            top: 18px !important;
            font-size: 9px !important;
            left: 5px !important;
        }
        .swal2-icon.swal2-error.swal2-icon-show
        {
            width: 12% !important;
            background: #eec9c9 !important;
            height: 39px !important;
            top: 24% !important;
            left: 45% !important;
        }
        .swal2-icon.swal2-success.swal2-icon-show
        {
            display: flex;
            left: 142px;
            top: 14px;
            font-size: 10px;
        }
        
        #ddlPriority
        {
            width: 127px;
            color: black;
            background: #c8c8c845;
            min-width: 80px;
            width: 80px;
            height: 28px;
            text-indent: inherit;
            overflow: hidden;
            border: #aaa3a3 solid thin;
            -moz-border-radius: 6px;
            -webkit-border-radius: 6px;
            border-radius: 6px;
            cursor: pointer;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            font-weight: bold;
            color: #000;
            margin-top: 2px;
        }
        
        #ddlPriority:hover
        {
            background: #e19a41;
            color: #FFFFFF;
        }
        .autowidmovebut
        {
            margin-top: 1px !important;
            border-radius: 5px;
        }
        #editbu
        {
            margin-top: 2px;
        }
        #newbu
        {
            margin-top: 3px;
        }
        .alert-error
        {
            padding: 11px;
            margin: 1px 0;
            margin-bottom: 1px;
            border-radius: 5px;
            font-size: 16px;
            position: relative;
            width: 96%;
            color: red !important;
            max-width: 96%;
            background-color: #f8d7da;
            border: 1px solid #f5c6cb;
            opacity: 1.3;
            transition: opacity 0.5s ease;
            height: 13px;
            top: 8px;
            left: 4px;
            margin-bottom: 17px;
            line-height: 10px;
            display: none;
            border: 1px solid #ecbebe;
        }
         .close-alert
        {
            float: right;
            padding-top: 0px;
            background: #e13434d1;
            color: white;
            font-weight: bold;
            cursor:pointer;
        }
        .alert-success
        {
            display: none;
            padding: 11px;
            margin: 1px 0;
            margin-bottom: 1px;
            border-radius: 5px;
            font-size: 16px;
            position: relative;
            width: 96%;
            max-width: 96%;
            background-color: #39bb815e;
            color: #1e420a !important;
            border: 1px solid #f5c6cb;
            opacity: 1.3;
            transition: opacity 0.5s ease;
            height: 13px;
            top: 8px;
            left: 4px;
            margin-bottom: 17px;
            line-height: 10px;
            border: 1px solid #96ca96;
        }
        .alert-warning
        {
            display: none;
            padding: 11px;
            margin: 1px 0;
            margin-bottom: 1px;
            border-radius: 5px;
            font-size: 16px;
            position: relative;
            width: 96%;
            max-width: 96%;
            background-color: #d995954f;
            color: red !important;
            border: 1px solid #f5c6cb;
            opacity: 1.3;
            transition: opacity 0.5s ease;
            height: 13px;
            top: 8px;
            left: 4px;
            margin-bottom: 17px;
            line-height: 10px;
            border: 1px solid c8a3a3;
        }
        .alert-success-Message
        {
            color: #166222 !important;
             font-weight: bold;
        }
        .alert-error-Message
        {
            color: #c12a2a !important;
             font-weight: bold;
        }
        
        .alert-warning-Message
        {
            color: #red !important;
            font-weight: bold;
        }
    </style>
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();

            var PreallRowData = [];
            var rows = document.querySelectorAll('#gv_Details tr');
            rows.forEach(function (row) {
                var Subcheckbox = row.querySelector('input[type="checkbox"]');
                var prerowData = {};
                if (Subcheckbox) {
                    prerowData.schemeCodeid = row.querySelector('td:nth-child(5) input').id.trim();
                    prerowData.schemeCodeValue = row.querySelector('td:nth-child(5) input').value;
                    PreallRowData.push(prerowData);
                }
            });

            $('#GV_chkSelectAll').click(function () {
                var checkbox = document.getElementById('GV_chkSelectAll');
                var isChecked = checkbox.checked;
                var checkboxes = document.querySelectorAll('#gv_Details input[type="checkbox"]');
                var checkedValues = [];
                var rows = document.querySelectorAll('#gv_Details tr');
                var rowData = {};
                if (isChecked) {
                    checkboxes.forEach(function (checkbox) {
                        checkbox.checked = true;
                        checkedValues.push(checkbox.id);
                        rows.forEach(function (row) {
                            var checkbox = row.querySelector('input[type="checkbox"]:checked');
                            var CheckedrowData = {};
                            if (checkbox) {
                                CheckedrowData.schemeCode = row.querySelector('td:nth-child(5) input').id.trim();
                                var scheme = $('#ddl_Scheme').val().trim();
                                document.getElementById(CheckedrowData.schemeCode).value = scheme;
                                var schemeCode = row.querySelector('td:nth-child(5) input').id.trim();
                            }
                        });
                    });
                }
                else {
                    var Unchecked = [];
                    checkboxes.forEach(function (checkbox) {
                        checkbox.checked = false;
                        rows.forEach(function (row) {
                            var checkbox = row.querySelector('input[type="checkbox"]');
                            var unCheckedrowData = {};
                            if (checkbox) {
                                unCheckedrowData.schemeCode = row.querySelector('td:nth-child(5) input').id.trim();
                                Unchecked.push(unCheckedrowData);
                            }
                        });
                    });
                    PreallRowData.forEach(function (data, rowIndex) {
                        if (Unchecked[rowIndex].schemeCode === data.schemeCodeid) {
                            document.getElementById(Unchecked[rowIndex].schemeCode).value = data.schemeCodeValue;
                        }
                    });
                }
            });

            $('#gv_Details input[type="checkbox"]').click(function () {
                var checkboxes = document.querySelectorAll('#gv_Details input[type="checkbox"]');
                var checkedboxes = [];
                var unCheckedboxes = [];
                checkboxes.forEach(function (checkbox) {
                    var checkboxStatus = {
                        id: checkbox.id,
                        checked: checkbox.checked
                    };
                    var schemeidRow = checkbox.closest('tr');
                    var scheme = $('#ddl_Scheme').val().trim();
                    var Lic_no = $('#ddlinvno').text().split(':')[1].split(/\s+/)[1];
                    if (checkbox.checked) {
                        checkboxStatus.schemeid = schemeidRow.querySelector('td:nth-child(5) input').id.trim();
                        document.getElementById(checkboxStatus.schemeid).value = scheme;
                        checkedboxes.push(checkboxStatus);
                    }
                    else {
                        checkboxStatus.schemeid = schemeidRow.querySelector('td:nth-child(5) input').id.trim();
                        unCheckedboxes.push(checkboxStatus);
                        PreallRowData.forEach(function (data) {
                            unCheckedboxes.forEach(function (unchecked) {
                                if (unchecked.schemeid === data.schemeCodeid) {
                                    var schemeElement = document.getElementById(unchecked.schemeid);
                                    if (schemeElement) {
                                        schemeElement.value = data.schemeCodeValue;
                                    }
                                }
                            });
                        });
                    }

                });
            });
        });
        //-------------end---------------//
   </script> 
    <script type="text/javascript">
        //---------------------Show Alert-Msg----------------------//
        function close_popup(Msg) {
            $("." + Msg).css('display', 'none');
        }
        function ShowAlert(Msg) {
            console.log('Msg', Msg);
            if (Msg.includes('Already Exist License') || Msg.includes('Check your Item Quantity') || Msg.includes('Invalid Debit Amount') || Msg.includes('Invalid Debit Duty')) {
                $('.alert-warning').css('display', 'block');
                $('.alert-warning-Message').text(Msg + " !");
                setTimeout(function () {
                    $('.alert-warning').css('display', 'none');
                }, 5000);
            }
            else if (Msg === 'License Copied SuccessFully') {
            Swal.fire({
                position: "top-end",
                icon: 'success',
                title: Msg,
                showConfirmButton: true
            }).then(function () {
                window.parent.location.href = window.parent.location.origin + window.parent.location.pathname + '?ClosePop=true';
            });
            }
            else {
                $('.alert-error').css('display', 'block');
                $('.alert-error-Message').text(Msg + " !");
                setTimeout(function () {
                    $('.alert-error').css('display', 'none');
                }, 5000);
            }
        }
        function RefreshParent() {
            win_hide();
            parent.adcodewindow.hide();
            return false;
        }
     </script>
   <script type="text/javascript">

        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {
                return options.allrules.validate2fields.alertText;
            }
        }
        function close_button() {
            document.getElementById("General").click();
        }

        function ToCopy_Validation() {
            var Update_priority = $('#ddlPriority').val();
            var Inv_Lic_No = $('#ddlinvno').val();
            var Msg = '';
            var checkedCount = document.querySelectorAll('input[type="checkbox"]:checked').length;
            console.log('Update_priority', Update_priority);
            if (Inv_Lic_No == 'Select') {
                Msg = 'Select License RegisterNo \n';
            }
            if (Update_priority == 'Select') {
                Msg += 'Select Update Priority \n';
            }
            if (checkedCount == '0') {
                Msg += 'Please Select Items \n';
            }
            if (Msg != '') {
                alert(Msg);
                return false;
            }
            else {
                return true;
            }
        }
     </script>
    
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    <div class="alert-error">
        <strong>Error : &nbsp;  </strong><span class="alert-error-Message"></span>
        <button type="button" class="close-alert" onclick="close_popup('alert-error')">
            <span>&times;</span></button>
    </div>
    <div class="alert-warning">
        <strong>Warning : &nbsp; </strong><span class="alert-warning-Message"></span>
        <button type="button" class="close-alert" onclick="close_popup('alert-warning')">
            <span>&times;</span>
        </button>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain" style="height: 33px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 74px; margin-left:-10px;">
                        Lic. JobNo</div>
                    <div id="txt_container_Transact_Main_l" style="width: 78px;">
                        <div id="txtcon-m_Exchange" style="width: 77px;">
                            <asp:DropDownList ID="ddlJobNo" CssClass="listtxt_transac_item_gen_notn" AutoPostBack="true"  Height="24px"
                                Width="75px" runat="server" TabIndex="3" OnSelectedIndexChanged="ddlJobNo_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 50px;">
                        Lic.No</div>
                    <div id="txt_container_Transact_Main_l" style="width: 204px;">
                        <div id="txtcon-m_Exchange" style="width: 75px;">
                            <asp:DropDownList ID="ddlinvno" CssClass="listtxt_transac_item_gen_notn" AutoPostBack="true"  Height="24px"
                                Width="200px" runat="server" TabIndex="3" OnSelectedIndexChanged="ddlinvno_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 54px;">
                        Scheme</div>
                    <div id="txt_container_Transact_Main_l" style="width: 88px;">
                        <div id="txtcon-m_Exchange" style="width: 75px;">
                            <asp:TextBox ID="ddl_Scheme" runat="server" Width="96%" Enabled="false" ReadOnly="true"></asp:TextBox>
                        </div>
                    </div>
                    <div id="txtcon-m_transaction_Item_Schemecode"  style="width: 82px;">
                        <asp:DropDownList ID="ddlScheme_NOTN" runat="server" OnSelectedIndexChanged="ddlScheme_NOTN_SelectedIndexChanged" Height="24px"
                            AutoPostBack="true" CssClass="listtxt_transac_Item_Schemecode" TabIndex="10">
                        </asp:DropDownList>
                    </div>
                    <div id="txtcon-m_transaction_item_gen_notn_list1"  style="width: 72px;">
                                <asp:DropDownList ID="ddlScheme_NOTN_SL" runat="server" CssClass="listtxt_transac_item_gen_notn" Height="24px"
                                    TabIndex="11">
                                </asp:DropDownList>
                            </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 116px; margin-left: -2px;">
                        Search Scheme</div>
                    <div id="txt_container_Transact_Main_l" style="width: 98px;">
                        <asp:DropDownList ID="ddl_Item_Scheme" CssClass="listtxt_transac_item_gen_notn" AutoPostBack="true"  Height="24px"
                            OnSelectedIndexChanged="ddlItemScheme_SelectedIndexChanged" Width="90px" runat="server"
                            TabIndex="3">
                        </asp:DropDownList>
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
            </div>
            <div class="content" id="page-1" style="margin-left: -30px; margin-top: -15px; width: 1110px;">
                <div id="open_item" runat="server">
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 42px; width: 890px;
                            margin-top: -16px; overflow: hidden;">
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: hidden; height: 100px;
                                width: 888px;">
                                <asp:GridView ID="GV" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                    BackColor="White" BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="false"
                                    CssClass="grid-view" BorderWidth="1px" CellPadding="1" CellSpacing="1" AllowPaging="false"
                                    HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_RowCreated"
                                    OnRowDataBound="gv_Details_RowDataBound" Style="overflow: scroll;">
                                    <Columns>
                                        <asp:BoundField DataField="JOBNO" HeaderText="JOBNO" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="0%" ControlStyle-CssClass="column_style_left_border_2_new"/>
                                        <asp:BoundField DataField="d" HeaderText="INV-S" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="5%" ControlStyle-CssClass="column_style_left_border_2_new"/>
                                        <asp:BoundField DataField="b" HeaderText="ITEM-S" HeaderStyle-Font-Bold="true"
                                           HeaderStyle-Width="6%" ControlStyle-CssClass="column_style_left_border_2_new"  />
                                        <asp:BoundField DataField="SCHEME_CODE" HeaderText="SCHEME" HeaderStyle-Font-Bold="true"
                                           HeaderStyle-Width="0%" ControlStyle-CssClass="column_style_left_border_2_new"/>
                                        <asp:BoundField DataField="LICENSE_NO" HeaderText="LIC-NO" HeaderStyle-Font-Bold="true"
                                           HeaderStyle-Width="9%" ControlStyle-CssClass="column_style_left_border_2_new" />
                                        <asp:BoundField DataField="LICENSE_DATE" HeaderText="LIC-DATE" HeaderStyle-Font-Bold="true"
                                           HeaderStyle-Width="8%" ControlStyle-CssClass="column_style_left_border_2_new"/>
                                        <asp:BoundField DataField="TOTAL_QTY" HeaderText="T-QTY" HeaderStyle-Font-Bold="true"
                                           HeaderStyle-Width="5%" ControlStyle-CssClass="column_style_left_border_2_new"  />
                                        <asp:BoundField DataField="c" HeaderText="R-QTY" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="8%" ControlStyle-CssClass="column_style_left_border_2_new" />
                                        <asp:BoundField DataField="d" HeaderText="T-DEB-AMT" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="9%" ControlStyle-CssClass="column_style_left_border_2_new" />
                                        <asp:BoundField DataField="d" HeaderText="R-DEB-AMT" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="9%" ControlStyle-CssClass="column_style_left_border_2_new" />
                                        <asp:BoundField DataField="d" HeaderText="T-DEB-DUTY" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="0%" ControlStyle-CssClass="column_style_left_border_2_new" />
                                        <asp:BoundField DataField="d" HeaderText="R-DEB-DUTY" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="0%" ControlStyle-CssClass="column_style_left_border_2_new" />
                                        <asp:BoundField DataField="d" HeaderText="UNIT-CODE" HeaderStyle-Font-Bold="true"
                                            HeaderStyle-Width="0%" ControlStyle-CssClass="column_style_left_border_2_new" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 253px;
                            width: 890px; margin-top: -16px; overflow: hidden;">
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow-x: hidden; overflow-y: auto;
                                height: 250px; width: 888px;">
                                <asp:GridView ID="gv_Details" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    DataKeyNames="INVOICE_SLNO,ITEM_SLNO" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="#C8C8C8" BorderStyle="none" ShowFooter="True" BorderWidth="1px"
                                    CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false" HorizontalAlign="Left"
                                    ShowHeaderWhenEmpty="True" Width="100%" OnRowCreated="gv_Details_RowCreated"
                                    OnRowDataBound="gv_Details_RowDataBound" ShowHeader="false">
                                    <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ch_inv" ControlStyle-CssClass="column_style_left_border_2_new"
                                            HeaderStyle-Font-Bold="false" ItemStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chk_inv" runat="server" HeaderText="ch_inv" Width="44px" Checked='<%#bool.Parse(Eval("INV_CHECK").ToString())%>' />
                                            </ItemTemplate>
                                            <ItemStyle Width="5%" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="JOBNO" HeaderText="JOBNO" HeaderStyle-Font-Bold="false"
                                            ControlStyle-CssClass="column_style_left_border_2_new" ControlStyle-Width="30px"
                                            ItemStyle-Width="6%" />
                                        <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv.Slno" HeaderStyle-Font-Bold="false"
                                            ControlStyle-CssClass="column_style_left_border_2_new" ControlStyle-Width="30px"
                                            ItemStyle-Width="9%" />
                                        <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item.Slno" HeaderStyle-Font-Bold="false"
                                            ControlStyle-CssClass="column_style_left_border_2_new" ControlStyle-Width="30px"
                                            ItemStyle-Width="9%" />
                                        <asp:TemplateField HeaderText="Scheme" HeaderStyle-Font-Bold="false" ControlStyle-CssClass="column_style_left_border_2_new"
                                            ControlStyle-Width="63px" ItemStyle-Width="9%">
                                            <ItemTemplate>
                                                <asp:TextBox ID="scheme_txt" Text='<%# Bind("SCHEME_CODE") %>' Height="20px" Width="60px"
                                                    runat="server" ReadOnly></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:BoundField DataField="LICENSE_NO" HeaderText="Lic.No" HeaderStyle-Font-Bold="false" ControlStyle-CssClass="column_style_left_border_2_new"
                                            ControlStyle-Width="30px" ItemStyle-Width="9%" />
                                        <asp:BoundField DataField="LICENSE_DATE" HeaderText="Lic Date" HeaderStyle-Font-Bold="false"
                                            DataFormatString="{0:dd-MM-yyyy}" ControlStyle-CssClass="column_style_left_border_2_new"
                                            ControlStyle-Width="30px" ItemStyle-Width="9%" />
                                        <asp:TemplateField HeaderText="TOTAL QTY" HeaderStyle-Font-Bold="false" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_TOTAL_QTY" Text='<%# Bind("TOTAL_QTY") %>' onblur="extractNumber(this,2,false);"
                                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                    Height="20px" Width="44px" runat="server" ReadOnly Enabled="false"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="9%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remain Qty" HeaderStyle-Font-Bold="false" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Dbt_amt" Text='<%# Bind("Dbt_qty") %>' onblur="extractNumber(this,2,false);"
                                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                    Height="20px" Width="44px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="9%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TOT.DEBIT.AMT" HeaderStyle-Font-Bold="false" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_tot_Dbt_amt" Text='<%# Bind("TOTAL_CIF_AMOUNT") %>' onblur="extractNumber(this,2,false);"
                                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                    Height="20px" Width="70px" runat="server" ReadOnly Enabled="false"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="9%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="REM.DEBIT.AMT" HeaderStyle-Font-Bold="false" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Rem_Dbt_amt" Text='<%# Bind("REM_DEBIT_AMOUNT") %>' onblur="extractNumber(this,2,false);"
                                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                    Height="20px" Width="71px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="9%" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="TOT.DEBIT.DUTY" HeaderStyle-Font-Bold="false" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_TOT_Dbt_DUTY" Text='<%# Bind("TOTAL_DEBIT_DUTY_FINAL") %>' onblur="extractNumber(this,2,false);"
                                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                    Height="20px" Width="71px" runat="server" ReadOnly Enabled="false"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="9%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="REM.DEBIT.DUTY" HeaderStyle-Font-Bold="false" HeaderStyle-Width="150px">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txt_Rem_Dbt_DUTY" Text='<%# Bind("REM_DEBIT_DUTY_VALUE") %>' onblur="extractNumber(this,2,false);"
                                                    onkeyup="extractNumber(this,2,false);return Clear_Dot(this);" onkeypress="return blockNonNumbers(this, event, true, false);"
                                                    Height="20px" Width="71px" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="9%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type" HeaderStyle-Font-Bold="true" HeaderStyle-Width="80px">
                                            <ItemTemplate>
                                                <asp:DropDownList ID="ddldbt_Qty_code" Text='<%# Bind("Dbt_qty_code") %>' MaxLength="20"
                                                    runat="server" Width="60px" Height="22px" CssClass=" txtbox_trans_exp_drawback">
                                                    <asp:ListItem>BAG</asp:ListItem>
                                                    <asp:ListItem>BAL</asp:ListItem>
                                                    <asp:ListItem>BDL</asp:ListItem>
                                                    <asp:ListItem>BGS</asp:ListItem>
                                                    <asp:ListItem>BKL</asp:ListItem>
                                                    <asp:ListItem>BLK</asp:ListItem>
                                                    <asp:ListItem>BOU</asp:ListItem>
                                                    <asp:ListItem>BOX</asp:ListItem>
                                                    <asp:ListItem>BRL</asp:ListItem>
                                                    <asp:ListItem>BTL</asp:ListItem>
                                                    <asp:ListItem>BUN</asp:ListItem>
                                                    <asp:ListItem>CAN</asp:ListItem>
                                                    <asp:ListItem>CAS</asp:ListItem>
                                                    <asp:ListItem>CBM</asp:ListItem>
                                                    <asp:ListItem>CCM</asp:ListItem>
                                                    <asp:ListItem>CFT</asp:ListItem>
                                                    <asp:ListItem>CLS</asp:ListItem>
                                                    <asp:ListItem>CMS</asp:ListItem>
                                                    <asp:ListItem>COL</asp:ListItem>
                                                    <asp:ListItem>CON</asp:ListItem>
                                                    <asp:ListItem>CRT</asp:ListItem>
                                                    <asp:ListItem>CSK</asp:ListItem>
                                                    <asp:ListItem>CTN</asp:ListItem>
                                                    <asp:ListItem>DOZ</asp:ListItem>
                                                    <asp:ListItem>DRM</asp:ListItem>
                                                    <asp:ListItem>FTS</asp:ListItem>
                                                    <asp:ListItem>GGR</asp:ListItem>
                                                    <asp:ListItem>GMS</asp:ListItem>
                                                    <asp:ListItem>GRS</asp:ListItem>
                                                    <asp:ListItem>GYD</asp:ListItem>
                                                    <asp:ListItem>JRS</asp:ListItem>
                                                    <asp:ListItem>KGS</asp:ListItem>
                                                    <asp:ListItem>KIT</asp:ListItem>
                                                    <asp:ListItem>KLR</asp:ListItem>
                                                    <asp:ListItem>KME</asp:ListItem>
                                                    <asp:ListItem>LBS</asp:ListItem>
                                                    <asp:ListItem>LOT</asp:ListItem>
                                                    <asp:ListItem>LTR</asp:ListItem>
                                                    <asp:ListItem>MLT</asp:ListItem>
                                                    <asp:ListItem>MOU</asp:ListItem>
                                                    <asp:ListItem>MTR</asp:ListItem>
                                                    <asp:ListItem>MTS</asp:ListItem>
                                                    <asp:ListItem>MGS</asp:ListItem>
                                                    <asp:ListItem>NOS</asp:ListItem>
                                                    <asp:ListItem>PAC</asp:ListItem>
                                                    <asp:ListItem>PCS</asp:ListItem>
                                                    <asp:ListItem>PKG</asp:ListItem>
                                                    <asp:ListItem>PLT</asp:ListItem>
                                                    <asp:ListItem>PRS</asp:ListItem>
                                                    <asp:ListItem>QTL</asp:ListItem>
                                                    <asp:ListItem>RLS</asp:ListItem>
                                                    <asp:ListItem>ROL</asp:ListItem>
                                                    <asp:ListItem>SAC</asp:ListItem>
                                                    <asp:ListItem>SET</asp:ListItem>
                                                    <asp:ListItem>SHT</asp:ListItem>
                                                    <asp:ListItem>SQF</asp:ListItem>
                                                    <asp:ListItem>SQM</asp:ListItem>
                                                    <asp:ListItem>SQY</asp:ListItem>
                                                    <asp:ListItem>TBS</asp:ListItem>
                                                    <asp:ListItem>TGM</asp:ListItem>
                                                    <asp:ListItem>THD</asp:ListItem>
                                                    <asp:ListItem>TON</asp:ListItem>
                                                    <asp:ListItem>TUB</asp:ListItem>
                                                    <asp:ListItem>UGS</asp:ListItem>
                                                    <asp:ListItem>UNT</asp:ListItem>
                                                    <asp:ListItem>VLS</asp:ListItem>
                                                    <asp:ListItem>YDS</asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                            <ItemStyle Width="9%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <p id="pTotal" style="color: Red; font-size: large;">
                                    <%--CssClass=" txtbox_trans_exp_drawback"--%>
                            </div>
                            <%-----------------------Test--------------------------------------------------------%>
                        </div>
                    </div>
                    <%-------------------------------------------------------------------------------%>
                    <%--  </div>--%>
                    <%-- --------------------Test Start----------------------------%>
                    <div id="innerbox_MidMain_bot_transact" runat="server" style="height: 20px; margin-left: 20px;
                        margin-top: -14px;">
                        <div id="innerbox_transac_bot_inn">
                            <div id="newbu" style="margin-top: 3px;">
                                <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false" UseSubmitBehavior="false"
                                    TabIndex="61" OnClick="btnNew_Click1" />
                            </div>
                            <div id="mainmastop2container_rght_tag2_txt1" style="display: flex; width: 35%; margin-top: 0px;
                                margin-left: -7px;">
                                <div id="txt_container_Transact_Main_l" style="width: 117px; margin-top: 12px;">
                                    Update Priority</div>
                                <div id="autowidmovebut" style="width: 70px; margin-left: -3px; margin-top: 2px;">
                                    <div id="autowidmovebut" style="width: 75px;">
                                        <asp:DropDownList ID="ddlPriority" CssClass="listtxt_transac_item_gen_notn" AutoPostBack="false"
                                            Width="127px" runat="server" TabIndex="3" Style="font-weight: normal">
                                            <asp:ListItem>Select</asp:ListItem>
                                            <asp:ListItem>Delete and Insert</asp:ListItem>
                                            <asp:ListItem>Keep and Insert</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div id="editbu" style="margin-top: 3px; margin-left: -10px;">
                                <asp:Button ID="btncopy" runat="server" CausesValidation="false" UseSubmitBehavior="true"
                                    CssClass="autowidmovebut" Text="To Copy" OnClick="btncopy_Click" OnClientClick="return ToCopy_Validation()" />
                            </div>
                        </div>
                    </div>
                    <%-- --------------------Test End----------------------------%>
                </div>
            </div>
            <%-----------------------------------END----------------------------------------------------------------%>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
  
   
    <!-- VALIDATION SCRIPT -->
    <%--<script type="text/javascript">
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
        function ToCopy_Validation() {

            alert('');
            return false;
        }
    </script>--%>
   
    
</body>
</html>
