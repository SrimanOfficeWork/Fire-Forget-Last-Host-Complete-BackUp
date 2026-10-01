<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_SAHI_ExcelUpload.aspx.cs" Inherits="Export_SAHI_ExcelUpload" %> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SAHI Export Excel Upload</title>
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
   <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
  

  <script type="text/javascript">
      function Avail_InvoiceNo_Alert_Msg() {
          var invno = document.getElementById("hdinvno").value;
          alert(invno);
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
            <div id="innerbox_MidMain" style="height: 32px;">
                <div id="tag_srcinner1">
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 230px;">
                        EXPORT-SHAHI Excel Upload
                    </div>
                    <div id="verslic">
                    </div>

                     <div id="txt_container_Transact_Main_l"  style="width: 190px; margin-top:0px;">
                     <div id="tag_label_transact_Src" style="width: 130px; color:Blue">
                            Download New Excel</div>
                   
                     <a href="../Submission/Export_Excel_Format/SHAHI_EXPORT_XL.xlsx"  target="_new">
                    <asp:Image ID="Image1" ImageUrl="~/images/icons/xl.png" ToolTip="Download Excel File Format"  Height="30px"  Width="30px" runat="server" /></a>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 300px;">
                        <div id="tag_label_transact_Src" style="width: 116px;">
                            Select a Excel</div>
                        <div id="txtcon-m_Exchange" style="width: 120px;">
                            <asp:FileUpload ID="fileuploadExcel" runat="server" onchange="document.getElementById('btn_upload').click();" />
                            <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" Style="display: none;" />
                        </div>
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnupload" runat="server" Width="110px" Text="Upload" CssClass="autowidmovebut"
                            OnClick="btnupload_Click" />
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" Width="20px" />
                    </div>
                </div>
            </div>

                <div id="tag_srcinne1">
                <div id="txt_container_Transact_Main_l" style="width: 296px;">
                        <div id="tag_label_transaction_Src">
                           Country</div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 173px;">
                            <asp:TextBox ID="txtCountryOrigin" Width="160px" Font-Size="12px" runat="server"
                                CssClass="validate txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                           <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCountry_Master('Item_Country'); return false">
                                            </a>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 296px;">
                        <div id="tag_label_transaction_Src">
                           Port Name</div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 175px;">
                            <asp:TextBox ID="txtPortShipment" Width="160px" Font-Size="12px" runat="server"
                                CssClass="validate txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupPort_Master('Jobwise_Excel_Port'); return false">
                                            </a>
                        </div>
                    </div>
                <div id="txt_container_Transact_Main_l" style="width: 306px;">
                        <div id="tag_label_transact_Src">
                            State of Export</div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 175px;">
                            <asp:TextBox ID="txtStateExport" Width="160px" Font-Size="12px" runat="server"
                                CssClass="validate txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static" TabIndex="1"></asp:TextBox>
                        </div>
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('GSupplier'); return false"
                                class="magnfy"></a>
                        </div>
                    </div>
                </div>
                
           
           <%-- -------------------------------------Tab--------------------------------------------------------%>

           <%-- <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
             </div>--%>

                <div class="content" id="page-1" style="margin-left:-30px; margin-top:-15px; width:1110px;">
                <div id="open_item" runat="server">
                <div class="content" id="page-6" >
                
                <div id="pop_text_area_transac_popup_inn_container_export" style="height:30px; width:width:926px; margin-top: -16px; overflow:hidden;">
                 <span  style="font-weight:bold;"> Preview Data </span>
                </div>
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 490px; width:width:926px; margin-top: 0px; overflow:hidden;">
                        <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow:auto; height:348px; width:926px; ">
                       <%-- <asp:Label ID="lbl_main" Text="Main Details" runat="server"></asp:Label>--%>
                           <asp:GridView ID="gv_Gen_Details" runat="server"  EmptyDataText="No Record Found" DataKeyNames="JOBNO"
                           AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"  
                                ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                 HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                 OnRowCreated="gv_Gen_Details_RowCreated" OnRowDataBound="gv_Gen_Details_RowDataBound"
                                >
                                 <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <PagerStyle  ForeColor="Black"  CssClass="pager" />
                                 <Columns>
                                  <asp:BoundField DataField="JOBNO" HeaderText="JobNo" HeaderStyle-Width="40px" FooterStyle-Font-Bold="true">
                                        <ItemStyle CssClass="column_style_left"   Width="40px" Font-Bold="true" />
                                      </asp:BoundField>

                                     <asp:BoundField DataField="EXPORTER_NAME" HeaderText="Exporter Name" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                      <asp:BoundField DataField="CONSIGNEE_NAME" HeaderText="Consignee Name" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                      <asp:BoundField DataField="COUNTRY_DISCHARGE" HeaderText="Country of Discharge" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                      <asp:BoundField DataField="PORT_DISCHARGE" HeaderText="Port of Discharge" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                      <asp:BoundField DataField="COUNTRY_FINAL_DEST" HeaderText="Country of Origin" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                      <asp:BoundField DataField="PORT_FINAL_DEST" HeaderText="Port of Origin" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>
                                      </Columns>
                                </asp:GridView>
                        
                           <asp:GridView ID="gv_Item_Details" runat="server"  EmptyDataText="No Record Found" DataKeyNames="INVOICE_SLNO"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"  
                                ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                 HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                OnRowCreated="gv_Item_Details_RowCreated" OnRowDataBound="gv_Item_Details_RowDataBound" >
                                
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <PagerStyle  ForeColor="Black"  CssClass="pager" />
                                <Columns>

                              <%--  <asp:BoundField DataField="JOBNO" HeaderText="JobNo" HeaderStyle-Width="40px">
                                        <ItemStyle CssClass="column_style_left"   Width="40px" />
                                      </asp:BoundField>--%>

                                     <asp:BoundField DataField="INVOICE_SLNO" HeaderText="Inv. Slno" HeaderStyle-Width="40px">
                                        <ItemStyle CssClass="column_style_left"   Width="40px" />
                                      </asp:BoundField>
                                      
                                      <asp:BoundField DataField="INVOICE_NO" HeaderText="Inv. No" HeaderStyle-Width="80px">
                                            <ItemStyle CssClass="column_style_left" Font-Size="12px" Width="80px" />
                                      </asp:BoundField>
                                       <asp:BoundField DataField="INV_Value" HeaderText="Inv. Value" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                      <asp:BoundField DataField="INVOICE_CURRENCY" HeaderText="Inv. Curreny" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                      <asp:BoundField DataField="EXCHANGE_RATE" HeaderText="Exch-Rate" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                       <asp:BoundField DataField="TERMS" HeaderText="Terms" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                      <asp:BoundField DataField="Item_cnt" HeaderText="Item Cnt" HeaderStyle-Width="50px">
                                        <ItemStyle CssClass="column_style_left"   Width="50px" />
                                      </asp:BoundField>

                                </Columns>
                            </asp:GridView>
                        </div>
                        <%-----------------------Test--------------------------------------------------------%>
                    </div>
                </div>

                   </div>
                 </div>
              
                <%-----------------------------------END----------------------------------------------------------------%>
          
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>

            <asp:HiddenField ID="hdinvno" runat="server" />
             <asp:HiddenField ID="hdfTransport_mode" runat="server" />
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
                        <asp:Label ID="lblUser_Msg" runat="server" Text="Add   Additional  Invoice ?"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 100px; padding-top: 10px;">
                        <asp:Button ID="btnyes" runat="server" Text="Yes" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnyes_Click" />
                       <asp:Button ID="btnNo" runat="server" Text="No" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="return HideModalPopup_Inv()" />
                            <%--<asp:Button ID="btnNo" runat="server" Text="No" CausesValidation="false" UseSubmitBehavior="false"
                             OnClick="btnNo_Click" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </asp:Panel>


    <asp:ModalPopupExtender ID="MP_U_job" runat="server" TargetControlID="HDU_job" PopupControlID="MessageDivupdated_U_job"
        BackgroundCssClass="modalBackground" DropShadow="false">
    </asp:ModalPopupExtender>
    <asp:HiddenField ID="HDU_job" runat="server" />
    <asp:Panel ID="MessageDivupdated_U_job" runat="server" CssClass="modalPopup12" align="left"
        BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 300px; height: 120px;">
            <table width="100%" style="padding-top: 10px;">
                <tr>
                    <td align="center">
                        <asp:Label ID="lblUser_job_Msg" runat="server" Text="JobNo Already Exists..!!" ForeColor="Red" ></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td align="center">
                         <asp:Label ID="Label3" runat="server" Text="Create New Job ?" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 100px; padding-top: 10px;">
                        <asp:Button ID="btnNewJobyes" runat="server" Text="Yes" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNewJobyes_Click" />
                        <asp:Button ID="btnNewJobNo" runat="server" Text="No" CausesValidation="false" UseSubmitBehavior="false"
                            OnClientClick="return HideModalPopup_U()" />
                    </td>
                </tr>
            </table>
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

              $find("MP_U_job").hide();
              return false;
          }
    </script>

          <script type="text/javascript">

              function HideModalPopup_Inv() {

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
              $("#txtPortShipment").autocomplete({

                  source: function (request, response) {
                      var field = $(this.element).attr('id');
                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Get_PORTMaster_UserWise_List",
                          data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById('hdfTransport_mode').value + "'}",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {

                                  if (field == 'txtPortShipment') {
                                      jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Port Name', 'error', 'topRight', true);

                                      //jAlert('Port Shipment is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                                      //return false;
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

              $("#txtCountryOrigin").autocomplete({

                  source: function (request, response) {
                      var field = $(this.element).attr('id');

                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Country_Master_List",
                          data: "{ 'mail': '" + request.term + "' }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {

                                  if (field == 'txtCountryOrigin') {
                                      jQuery('#' + field).validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);

                                      //jAlert('Country Shipment is Incorrect', 'GENERAL', function (r) { document.getElementById(field).focus(); });
                                      //return false;
                                  }
                              }
                              else {
                                  jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
              $("#txtStateExport").autocomplete({
                  source: function (request, response) {
                      $.ajax({
                          url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_List",
                          data: "{ 'mail': '" + request.term + "' }",
                          dataType: "json",
                          type: "POST",
                          contentType: "application/json; charset=utf-8",
                          dataFilter: function (data) { return data; },
                          async: true,
                          success: function (data) {
                              response(data.d);
                              if (data.d == '') {
                                  jQuery('#txtStateExport').validationEngine('showPrompt', 'Incorrect State Export', 'error', 'topRight', true);

                                  //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport").focus(); });
                                  //return false;
                              }
                              else {
                                  jQuery('#txtStateExport').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
     function country(val) {

         var data = val;
         if (data == '') {
             $('#txtCountryOrigin').val('');
         }
         //$('#hdn_Autosearch').val(data);

         if (data.indexOf("-") != -1) {

             var s = data.split('-');

             var before = s[0];
             var after = s[1];

             $('#txtCountryOrigin').val(before);

         }
         else {

         }
     }

     $(function () {
         $('#txtCountryOrigin').focus(function () {

             var data = $(this).val();
             country(data);

         });
         $('#txtCountryOrigin').change(function () {

             var data = $(this).val();
             country(data);

         });
         $('#txtCountryOrigin').keyup(function () {

             var data = $(this).val();
             country(data);

         });
         $('#txtCountryOrigin').keydown(function () {

             var data = $(this).val();
             country(data);

         });
     });
   </script>

   

     
</body>
</html>
