<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_INV_Gen_Excel.aspx.cs" Inherits="Export_INV_Gen_Excel" %> 
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
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 160px;">
                        General Excel Upload
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 500px;">
                        <div id="tag_label_transact_Src" style="width: 90px;">
                            Buyer Name</div>
                        <div id="txtcon-m_Exchange" style="width: 120px;">
                            <asp:TextBox ID="txtBuyerName" runat="server" Width="160px" Font-Size="12px" CssClass=" txtbox_none_Mid_transac_IGM_Air_namenew BuyerName"></asp:TextBox>
                        </div>
                        <div id="magnify_area" style="padding-left: 40px;">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupBuyer('BUYER'); return false"
                                class="magnfy"></a>
                        </div>
                        <div id="txtcon-m_Exchange" style="width: 120px; margin-left: 30px;">
                            <asp:FileUpload ID="fileuploadExcel" runat="server" onchange="document.getElementById('btn_upload').click();" />
                            <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" Style="display: none;" />
                        </div>
                    </div>
                    <div id="verslic">
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnupload" runat="server" Width="180px" Text="Upload" CssClass="autowidmovebut"
                            OnClick="btnupload_Click" />
                    </div>

                      
                        <div id="editbu">
                        <asp:Button ID="btn_ConfirmUpload" runat="server" Text=""
       OnClick="btn_ConfirmUpload_Click" Style="display:none;" />
                    </div>




                    <div id="popupwindow_closebut_right_new">
                        <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();"
                            CausesValidation="false" UseSubmitBehavior="false" />
                    </div>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
            <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
            </div>
            <div class="content" id="page-1" style="margin-left: -30px; margin-top: -15px; width: 1110px;">
                <div id="open_item" runat="server">
                    <div class="content" id="page-6">
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 30px; width: width:926px;
                            margin-top: -16px; overflow: hidden;">
                            <span style="font-weight: bold;">Preview Data </span>
                        </div>
                        <div id="pop_text_area_transac_popup_inn_container_export" style="height: 280px;
                            width: width:926px; margin-top: 0px; overflow: auto;">
                            <div id="tag_transac_lft_Item_maindet_Grid_area" style="overflow: auto; height: 328px;
                                width: 926px;">
                                <asp:GridView ID="gv_Item_Details" runat="server" EmptyDataText="No Record Found"
                                    Font-Names="Verdana" AutoGenerateColumns="true" BackColor="LightGray" BorderColor="#C8C8C8"
                                    BorderStyle="none" ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1"
                                    CssClass="grid-view" AllowPaging="false" HorizontalAlign="Left" ShowHeaderWhenEmpty="True"
                                    Width="100%" HeaderStyle-Font-Bold="true" OnRowCreated="gv_Item_Details_RowCreated"
                                    OnRowDataBound="gv_Item_Details_RowDataBound">
                                    <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                    <PagerStyle ForeColor="Black" CssClass="pager" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Buyer_Name">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtBuyerName1" runat="server" Width="250px" CssClass="BuyerName"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="255px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <%-----------------------Test--------------------------------------------------------%>
                        </div>
                    </div>
                </div>
            </div>
            <%-----------------------------------END----------------------------------------------------------------%>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btn_upload" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
   
     <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width:300px; height:80px; ">
         <table width="100%" style="padding-top: 10px;">
             <tr>
                 <td align="center">
                     <asp:Label ID="lblUser_Msg" runat="server" Text="Delete Ur Previous Invoice for this Job ?"></asp:Label>
                 </td>
             </tr>
             <tr>
                 <td style="padding-left: 100px; padding-top:10px;">
                     <asp:Button ID="btnyes" runat="server" Text="Yes" 
                         CausesValidation="false" UseSubmitBehavior="false" OnClick="btnyes_Click" /> 
                           <asp:Button ID="btnNo" runat="server" Text="No" 
                         CausesValidation="false" UseSubmitBehavior="false" OnClientClick="return HideModalPopup_U()" /> 
                 </td>
             </tr>
         </table>
     </div>
    </asp:Panel>
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
        $(function () {
            $('.BuyerName').autocomplete({
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
                            var value1 = $('#txtBuyerName').val();
                            if (value1 != 'SAME AS CONSIGNEE') {
                                if (data.d == '') {
                                    jQuery('#txtBuyerName').validationEngine('showPrompt', 'Incorrect Buyer Name', 'error', 'topRight', true);
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
     
    <p>
&nbsp;</p>
     
</body>
</html>
