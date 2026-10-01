<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_INV_Gen_Excel.aspx.cs" Inherits="Import_INV_Gen_Excel" %> 
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
    <link href="../tabsIGMTrans/tabsIGMTrans.css" rel="stylesheet" type="text/css" />
    <link href="../Master_StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        jQuery(document).ready(function () {
            jQuery("#form1").validationEngine();
        });
        function updateProgress(percentage) {
            var split = percentage.split('*');
            var size = split.length;
            var val = '';
            for (var i = 0; i < size; i++) {
                val += split[i] + '\n';
            }
            alert('Duplicate Records Found: ' + '\n' + '------------------------------------' + '\n' + val);
        }



//------------------------------------------- Diana----------------------------------------------------------------------//
        function OpenPopup_IMP_QS(val) {
            console.log('val', val);
            document.getElementById(val).style.display = "block";
        }
     
        function closeQuickSearch(val) {
            document.getElementById(val).style.display = "none";
        }
        function filterSearch() {
            var input, filter, results, li, i, txtValue;
            input = document.getElementById("quickSearchInput");
            filter = input.value.toUpperCase();
            results = document.getElementById("searchResults");
            results.innerHTML = ''; // Clear previous results

            for (i = 0; i < searchData.length; i++) {
                txtValue = searchData[i];
                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                    li = document.createElement("li");
                    li.appendChild(document.createTextNode(txtValue));
                    li.onclick = function () { selectResult(this); };
                    results.appendChild(li);
                }
            }
        }
        function selectResult(resultItem) {
            // You can perform any action here with the selected result
            alert("You selected: " + resultItem.textContent);
            closeQuickSearch(); // Close the modal
        }

        //------------------------------------------- Diana End----------------------------------------------------------------------//
</script>

    <script type="text/javascript">

        function GetRowValue_ThirdParty_Export(val, val1, val2, val3, val4, val5, val6, val7, val8, val9, val10, val11) {
            window.opener.document.getElementById("txt_ThirdPartyName").value = val;
            window.opener.document.getElementById("txt_ThirdParty_Add1").value = val1;
            window.opener.document.getElementById("txt_ThirdParty_Add2").value = val2;
            window.opener.document.getElementById("txt_ThirdParty_City").value = val3;
            window.opener.document.getElementById("txt_Country_Division").value = val4;
            window.opener.document.getElementById("txt_CountryCode").value = val5;
            window.opener.document.getElementById("txt_ThirdParty_Pin").value = val6;
            window.opener.document.getElementById("txt_TermsPlace").value = val7;
            window.opener.document.getElementById("txt_Authrzd_Economic_Code").value = val8;
            window.opener.document.getElementById("txt_Authrzd_Economic_Country").value = val9;
            window.opener.document.getElementById("txt_Authrzd_Economic_Role").value = val10;
            window.close();
        }

        function showFileName() {
            document.getElementById('btn_upload').click();
        }

        function Spcl_Chars(percentage, Alt_type) {
            var split = percentage.split('*');
            var size = split.length;
            var val = '';
            for (var i = 0; i < size; i++) {
                val += split[i] + '\n';
            }
            var aa = '';
            if (Alt_type == 'alert') {
                aa = '                                ITEM DESCRIPTION-ERROR' + '\n' + '                        ==============================' + '\n';
            }
            else if (Alt_type == 'GeneralDesc_Alert') {
                aa = '                       GENERAL DESCRIPTION-ERROR' + '\n' + '                       ==============================' + '\n';
            }
            else if (Alt_type == 'Mnufactre_alert') {
                aa = '                        MANUFACTUTER NAME-ERROR' + '\n' + '                   ==============================' + '\n';
            }
            else {
                aa = '';
            }
            var msg = "Invalid Special Characters Found..Correct this and Again Upload !!!";
            alert(aa+msg + '\n' + '-------------------------------------------------------------------------------------------------' + '\n' + '\n' + val);
        }
</script>

<script type="text/javascript">
   
    function ShowModalPopup() {
        $find("MP_U").show();
        return false;
    }
    function HideModalPopup() {
        $find("MP_U").hide();
        return false;
    }

    window.onload = function () {
        var grid = document.getElementById('gv_Item_Details');
        var rows = grid.getElementsByTagName('tr');
        var maxWidths = [];

        // Loop through each column and find the max width required
        for (var i = 0; i < rows[0].cells.length; i++) {
            var maxWidth = 0;
            for (var j = 0; j < rows.length; j++) {
                var cell = rows[j].cells[i];
                if (cell.offsetWidth > maxWidth) {
                    maxWidth = cell.offsetWidth;
                }
            }
            maxWidths.push(maxWidth);
        }

        // Set the column widths based on the max width for each column
        for (var i = 0; i < rows[0].cells.length; i++) {
            for (var j = 0; j < rows.length; j++) {
                rows[j].cells[i].style.width = maxWidths[i] + 'px';
            }
        }
    };

</script>

  
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false" LoadScriptsBeforeUI="false" EnablePageMethods="true"> </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="popupwindow_closebut_right_new" style="margin-top: 3px; margin-right: 17px;">
                <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                    CausesValidation="false" UseSubmitBehavior="false" />
            </div>
            <div id="innerbox_MidMain" style="height: 68px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;padding-right: -9px;margin-left: -6px;">
                        Imp.XL Upload
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 312px;margin-left: -4px;">
                        <div id="tag_label_transact_Src">
                            Supplier Name</div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 129px;">
                            <asp:TextBox ID="txt_SupplierName_Gen" Font-Size="12px" runat="server" CssClass="validate txtbox_none_Mid_transac_Supp_Name"
                                ClientIDMode="Static" Width="127px" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('GSupplier'); return false"
                                class="magnfy"></a>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 303px; margin-left: -55px;">
                        <div id="tag_label_transact_Src" style="width: 105px;">
                            Third Party Name</div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 134px;">
                            <asp:TextBox ID="txt_ThirdPartyName" runat="server" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                onkeypress="return numcharspl1(event)" onpaste="return validatePaste(event);" Width="131px" MaxLength="70" TabIndex="78"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                           <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Exp_Thirdparty('Imp_ThirdParty_Main_Search'); return false"  class="magnfy"></a>
                         </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 245px;margin-left: -28px;">
                        <div id="tag_label_transact_Src" style="width: 106px;">
                            Select a Excel</div>
                        <div id="txtcon-m_Exchange" style="width: 115px; margin-left: -18px;">
                            <asp:FileUpload ID="fileuploadExcel" runat="server" onchange="showFileName()"/>
                            <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" Style="display: none;" />
                        </div>
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="editbu" style="margin-left: 87%;">
                        <asp:Button ID="btnUpload" runat="server" Width="100px" CssClass="autowidmovebut"  Text="Upload" OnClick="btnSaveProduct_Click" Visible="false" />
                        <asp:Button ID="btnUpload_Alert" runat="server" CssClass="autowidmovebut" Width="100px"  Text="Upload" OnClientClick="return ShowModalPopup()" Visible="false" />

                           <asp:Button ID="btn_ConfirmImport" runat="server" Text=""
       OnClick="btn_ConfirmImport_Click" Style="display:none;" />

                    </div>
                </div>
            </div>
           <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
            </div>
            <div class="content" id="page-1" style="margin-left: -30px; margin-top: -15px; width: 1110px;">
                <div id="open_item" runat="server">
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 30px; margin-top: -16px;
                            overflow: hidden;">
                            <%--width:width:926px;--%>
                            <span style="font-weight: bold;">Preview Data </span>
                        </div>
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 300px;
                            margin-top: 0px; overflow: hidden;">
                            <%--width:width:926px;--%>
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 290px;
                                width: 926px;">
                                <asp:GridView ID="gv_Item_Details" runat="server" BackColor="LightGray" BorderColor="#C8C8C8" EmptyDataText="No Record Found"
                                     ClientIDMode="Static" OnRowCreated="gv_Item_Details_RowCreated" Font-Names="Verdana" AutoGenerateColumns="true"
                                    BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" ShowHeaderWhenEmpty="True" AllowPaging="false"
                                    Width="100%"  HorizontalAlign="Left" HeaderStyle-Font-Bold="true">

                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                    <PagerStyle ForeColor="Black" CssClass="pager" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Supplier Name">
                                            <ItemTemplate>
                                                <div class="input-container" style="display: flex; align-items: center; width: 124%; margin-left: 39px;">
                                                    <asp:TextBox ID="txt_SupplierName_Gen1" Width="70%" Font-Size="12px" runat="server"  CssClass="Search1"></asp:TextBox>
                                                    <%--<div id="magnify_area">
                                                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('Supplier_Search'); return false" class="magnfy"></a>
                                                    </div>--%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Third Party Name">
                                            <ItemTemplate>
                                                <div class="input-container" style="display: flex; align-items: center;width: 112%; margin-left: 16px;">
                                                    <asp:TextBox ID="txt_Third_Party_Name" Width="70%" Font-Size="12px" runat="server" CssClass="Search"></asp:TextBox>
                                                    <%--<div id="magnify_area">
                                                        <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopup_Exp_Thirdparty('Imp_ThirdParty_Prv_Search'); return false"
                                                            class="magnfy"></a>
                                                    </div>--%>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <%-----------------------Test--------------------------------------------------------%>
                        </div>
                    </div>
                </div>
            </div>

                 <asp:HiddenField ID="hdn_BOND_NO" runat="server" />
                 <asp:HiddenField ID="hdn_BOND_TYPE" runat="server" />
                 <asp:HiddenField ID="hdn_BOND_LOCATION" runat="server" />

              
                <%-----------------------------------END----------------------------------------------------------------%>
          
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>

            <asp:HiddenField ID="hdinvslno" runat="server" ClientIDMode="Static"/>
            <asp:HiddenField ID="hdn_alert" runat="server"  />
            <p id="myP" style="color:red;">This is an example paragraph.</p>
           </ContentTemplate>
    </asp:UpdatePanel>
 
    
     <asp:ModalPopupExtender ID="MP_U" runat="server" TargetControlID="HDU" PopupControlID="MessageDivupdated_U"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU" runat="server" />
    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 330px; height: 75px;">
            <div id="tag_transac_lft_Inv_in1" style="width: 330px; height: 30px;">
                <div id="mainmastop2container_rght_tag2_txt1" style="width: 280px; color:Red;">
                    Do you want to Replace Ur XL Data ?
                </div>
                <div id="popupwindow_closebut_right_new">
                    <asp:Button ID="btnHide" runat="server" CssClass="clsicon_new" OnClientClick="return HideModalPopup()"
                        CausesValidation="false" UseSubmitBehavior="false" />
                </div>
            </div>
             <div id="tag_transac_lft_Inv_in1" style="width: 280px; height:5px;">
             </div>
           
            <div id="tag_transac_lft_Inv_in1" style="width: 330px;">
                 <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                 <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                  <div id="tag_label_transaction_popup_IGM2_empty">
                </div> 
                <div id="tag_label_transaction_popup_IGM_invoice">
                    <asp:Button ID="btnSaveProduct" Text="Yes" CssClass="autowidupdatebut" runat="server"
                        TabIndex="8" Height="20px" UseSubmitBehavior="false" Width="100px"  onclick="btnSaveProduct_Click" />
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:Button ID="btn_Hide" Text="No" CssClass="autowidupdatebut"
                        runat="server" Height="20px" TabIndex="9" Width="100px"
                        OnClientClick="return HideModalPopup()"
                        CausesValidation="false" UseSubmitBehavior="false"  />

                </div>
            </div>
        </div>
        
    </asp:Panel>


    </form>
  
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
        $(function () {
            $("#txt_SupplierName_Gen").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Supplier_Master_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                if (field == 'txt_SupplierName_Gen') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Supplier Name', 'error', 'topRight', true);
                                }

                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
            $("#txt_ThirdPartyName").autocomplete({
                source: function (request, response) {
                    var field = $(this.element).attr('id');
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_ThirdParty_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                if (field == 'txt_ThirdPartyName') {
                                    jQuery('#' + field).validationEngine('showPrompt', 'Incorrect ThirdParty Name', 'error', 'topRight', true);
                                }

                            }
                            else {
                                jQuery('#' + field).validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


    </script>

     <script type="text/javascript">
         $(function () {
             $(".Search").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Imp_ThirdParty_List",
                         data: "{ 'mail': '" + request.term + "' }",
                         dataType: "json",
                         type: "POST",
                         contentType: "application/json; charset=utf-8",
                         dataFilter: function (data) { return data; },
                         async: true,
                         success: function (data) {
                             response(data.d);
                             if (data.d == '') {

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
             $(".Search1").autocomplete({
                 source: function (request, response) {
                     $.ajax({
                         url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Supplier_Master_List",
                         data: "{ 'mail': '" + request.term + "' }",
                         dataType: "json",
                         type: "POST",
                         contentType: "application/json; charset=utf-8",
                         dataFilter: function (data) { return data; },
                         async: true,
                         success: function (data) {
                             response(data.d);
                             if (data.d == '') {

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
    </script>



<script type="text/javascript" language="javascript">


    function Go_IMP_EXCEL() {
        HideModalPopup();       

        PageMethods.IMP_Excel_Upload(document.getElementById("<%=txt_SupplierName_Gen.ClientID%>").value, OnSuccess);
            }
            function OnSuccess(response, userContext, methodName) {
                jAlert(response, 'Invoice', function (r) { });
            }

//            function QuickSearch_bind(row, type) {
//                var rowData = [];
//                for (var i = 0; i < row.cells.length; i++) {
//                    rowData.push(row.cells[i].innerText);
//                }
//                if (type == 'supplier') {
//                    $('#txt_SupplierName_Gen1').val(rowData[1]);
//                    $('#quickSearchModal').css('display', 'none');
//                }
//                else {
//                    $('#txt_Third_Party_Name').val(rowData[1]);
//                    $('#quickSearchModalThird_Party').css('display', 'none');
//                }
//               
//                
//            }
</script>

</body>
</html>
