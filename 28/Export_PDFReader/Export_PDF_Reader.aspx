<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_PDF_Reader.aspx.cs" Inherits="Export_PDF_Reader" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Bill Invoice</title>
    <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
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
            <div id="innerbox_MidMain_Billing" style="height: 35px; width: 980px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 200px;">
                        Export - PDF Upload
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_transac_lft_in2" style="margin-top: 5px;">
                        <div id="txtcon-m_Exchange" style="width: 50px;">
                            <asp:ImageButton ID="btn_Refresh" UseSubmitBehavior="false" runat="server" ImageUrl="~/images/icons/Refresh.png"
                                ToolTip="Refresh" Height="25px" Width="35px" OnClick="btn_Refresh_Click" />
                        </div>
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="verslic" style="margin-top: -5px;">
                    </div>
                    <div id="tag_label_transaction_Src_new" style="width: 280px; margin-left: 20px; font-weight: bold;
                        color: Blue;">
                        Job No
                        <asp:TextBox ID="txtjobPS" runat="server" Font-Bold="true" MaxLength="10" Font-Size="12px"
                            CssClass="txtbox_none_Mid_transac_code" Width="130px" ReadOnly="True" TabIndex="1"
                            ClientIDMode="Static"></asp:TextBox>
                    </div>

                    <%--<div id="txtcon-m_src" style="width: 120px;">
                            <asp:FileUpload ID="FilePDF" runat="server" />
                        </div>
                        <div id="txtcon-m_src">
                            <asp:Button ID="btnSearch" Style="margin-top: -3px; margin-left: 50px" Text="Preview"
                                CssClass="autowidupdatebut" runat="server" UseSubmitBehavior="false" OnClick="btnSearch_Click" />
                        </div>--%>

                    <div id="popupwindow_closebut_right_new">
                        <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                </div>
            </div>
            <div id="tag_srcinne1" style="height: 36px;">
                <div id="txt_container_Transact_Main_l" style="width: 336px;">
                    <div id="tag_label_transaction_Src" style="width: 106px;">
                        Exporter Name
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 223px;">
                        <asp:DropDownList ID="ddl_ExporterName" runat="server" TabIndex="1" Width="220px" Height="25px">
                        </asp:DropDownList>
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 296px;">
                    <div id="tag_label_transaction_Src">
                        Consignee
                    </div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 195px;">
                        <asp:TextBox ID="txtConsigneeName" Width="190px" Font-Size="12px" runat="server"
                            CssClass="validate txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static" TabIndex="1" Height="25px"></asp:TextBox>
                    </div>
                </div>
                <div id="txt_container_Transact_Main_l" style="width: 306px;">
                    <div id="tag_label_transact_Src" style="width: 56px;">
                        Buyer</div>
                    <div id="txtcon-m_transaction_Supp_code" style="width: 215px;">
                        <asp:TextBox ID="txtBuyer" Width="210px" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                            ClientIDMode="Static" TabIndex="1" Height="25px"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div id="tag_transac_lft_in2" style="margin-top: 30px;">
            <div id="tag_label_transact_Src" style="width: 106px; font-weight:bold;">
                        Upload PDF File</div>
              <div id="txtcon-m_src" style="width: 260px;">
                            <asp:FileUpload ID="FilePDF" runat="server"  ForeColor="Blue" TabIndex="2"/>
                        </div>
                        <div id="txtcon-m_src" >
                            <asp:Button ID="btnPrevData" Style="margin-top: -3px; margin-left: 50px" Text="Preview" TabIndex="2"
                                CssClass="autowidupdatebut" runat="server" UseSubmitBehavior="false" OnClick="btnPrevData_Click" />
                        </div>
            </div>
                   

                <%--<div id="innerbox_MidMain_Trans_new" style="height: 150px; width: 954px;  margin-left:10px;">
                    <div id="tag_Exchange_inner_lft" style="width:945px; height: 150px; ">
                        <asp:TextBox ID="txtCommNarration" runat="server" PlaceHolder="Paste PDF Text.."
                            Height="450px" Width="1088px" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>--%>

                 <%--<div id="tag_transac_lft_in2" style="margin-top: 5px;">
                <div id="txtcon-m_Exchange" style="width: 400px;">
                </div>
                <div id="txtcon-m_Exchange" style="width: 300px;">
                <asp:Button ID="btnPrevData" runat="server" Style="width: 100px" Text="Preview" CssClass="autowidmovebut"
                            OnClick="btnPrevData_Click" />
                            
                <asp:Button ID="btn_Clear" runat="server" Style="width: 100px" Text="Clear Text" 
                        CssClass="autowidmovebut" onclick="btn_Clear_Click"
                          />

                    
                </div>
                <div id="txtcon-m_Exchange" style="width: 200px;">
                    <asp:Literal ID="lblmsg1" runat="server"></asp:Literal>
                </div>
            </div>--%>
                

            <div class="content" id="page-1" style="margin-left: -30px; margin-bottom:10px;">
                <div id="open_item" runat="server">
                    <div class="content" id="page-6" >
                      
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 300px;
                            width: 966px; margin-top: 0px;">
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 290px;
                                width: 960px;">
                                <asp:GridView ID="gv_ItemPDF" runat="server" AllowSorting="True" EmptyDataText="No Record Found"
                                    AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                    HorizontalAlign="Left" OnRowCreated="gv_ItemPDF_RowCreated" OnRowDataBound="gv_ItemPDF_RowDataBound"
                                    ShowHeaderWhenEmpty="True">
                                    <AlternatingRowStyle BorderColor="#5E5E5E" BorderStyle="Solid" BorderWidth="1px" />
                                    <SelectedRowStyle Font-Bold="true" />
                                    <Columns>
                                       <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Invoice SlNo" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="INVOICE_NO" HeaderText="Invoice No" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="120px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="120px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ITEM_SLNO" HeaderText="Item Slno" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ITEM_DESC" HeaderText="Item Description" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="450px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="450px" Font-Size="11px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="ITEM_QTY" HeaderText="Item Qty" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ITEM_QTY_CODE" HeaderText="Qty Code" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="60px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="60px" Font-Size="11px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="ITEM_UNITPRICE" HeaderText="Item Unit Price" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ITEM_AMOUNT" HeaderText="Item Amt" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                         <asp:BoundField DataField="INFO_MSR" HeaderText="Info MSR" HeaderStyle-HorizontalAlign="Left"
                                            HeaderStyle-Width="100px">
                                            <ItemStyle CssClass="column_style_left5" HorizontalAlign="Left" Width="100px" Font-Size="11px" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="innerbox_MidMain_Trans" style="width: 1051px; height: 5px;  margin-top:-20px;
                        margin-left: -40px;">
                    </div>
            <div id="tag_transac_lft_in2" style="margin-top: 25px;">
                <div id="txtcon-m_Exchange" style="width: 400px;">
                </div>
                <div id="txtcon-m_Exchange" style="width: 100px;">
                     <asp:Button ID="btnupload" runat="server" Width="100px"  Height="30px" Text="Upload" CssClass="autowidmovebut" TabIndex="4"
                            OnClick="btnupload_Click" />
                </div>
                <div id="txtcon-m_Exchange" style="width: 200px;">
                    <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                </div>
            </div>

            <%-----------------------------------END----------------------------------------------------------------%>
            
            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static" />
            <asp:HiddenField ID="hdn_alert" runat="server" />
            <asp:HiddenField ID="hdprefix" runat="server" />
                    <asp:HiddenField ID="hdsuffix" runat="server" />
                    <asp:HiddenField ID="hdn_JOBNO" runat="server" />
                    <asp:HiddenField ID="hdn_JOBNO_PS" runat="server" />
                    <asp:HiddenField ID="hdn_missed_Desc" runat="server" />
                    <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                    <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" />
                    <asp:HiddenField ID="hdn_JOBNO_digit" runat="server" />

           
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 80px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_Msg" runat="server" Text="Delete Ur Previous Invoice for this Job ?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 100px; padding-top: 10px;">
                        <asp:Button ID="btnyes" runat="server" Text="Yes" CausesValidation="false" UseSubmitBehavior="false" />
                        <asp:Button ID="btnNo" runat="server" Text="No" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="return HideModalPopup_U()" />
                        <%--OnClick="btnyes_Click"--%>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>
    </form>

     <script src="../js/Export_Jscript/Export_General.js" type="text/javascript"></script>
    <script src="../js/Billing/Billing_Invoice_auto_Search.js" type="text/javascript"></script>
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

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <script type="text/javascript">
        function RefreshParent() {
            window.parent.location.reload();
        }
        
    </script>
   

    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtConsigneeName').focus(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txtConsigneeName').focusout(function () {

                var data1 = $(this).val();
                Item_desc1(data1);


            });
            $('#txtConsigneeName').change(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txtConsigneeName').keyup(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
            $('#txtConsigneeName').click(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });

            $('#txtConsigneeName').keydown(function () {

                var data1 = $(this).val();
                Item_desc1(data1);

            });
        });

        function Item_desc1(val) {
            $('#lbl_consignee_cnt').val('44r');
            var data1 = val;
            if (data1 == '') {
                $('#txtConsigneeName').val('');
            }
            if (data1.indexOf("--") != -1) {

                var s = data1.split('--');
                var before = s[0];
                var after = s[1];

                $('#txtConsigneeName').val(after);

                $('#hdn_Consignee').val(after);
                $('#hdn_Consignee_brSlNo').val(before);
            }
            else {
                $('#hdn_Consignee_brSlNo').val('');

            }

            if ($('#hdn_CompanyID').val() == '624') {
                var len = $('#txtConsigneeName').val();
                document.getElementById('lbl_consignee_cnt').innerHTML = len.length;
            }
        }
    </script>

    <script type="text/javascript">


        $(function () {
            $("#txtConsigneeName").autocomplete({

                source: function (request, response) {
                 
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Consignee_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtConsigneeName').validationEngine('showPrompt', 'Incorrect Consignee Name', 'error', 'topRight', true);

                                //jAlert('ConsigneeName is Incorrect', 'GENERAL', function (r) { document.getElementById("txtConsigneeName").focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtConsigneeName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            ////alert(textStatus);
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;
        });



        $(function () {
            $('#txtBuyer').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Buyer_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            var value1 = $('#txtBuyer').val();
                            if (value1 != 'SAME AS CONSIGNEE') {
                                if (data.d == '') {
                                    jQuery('#txtBuyer').validationEngine('showPrompt', 'Incorrect Buyer Name', 'error', 'topRight', true);

                                    //jAlert('Buyer Name is Incorrect', 'INVOICE', function (r) { document.getElementById("txtBuyerName').focus(); });
                                    //return false;
                                }
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

    

</body>
</html>
