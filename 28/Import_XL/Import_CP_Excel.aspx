<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_CP_Excel.aspx.cs" Inherits="Import_CP_Excel" %> 
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

<script type="text/javascript">
    function ShowModalPopup() {
        $find("MP_U").show();
        return false;
    }
    function HideModalPopup() {
        $find("MP_U").hide();
        return false;
    }
</script>


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
            <div id="innerbox_MidMain" style="height:32px; margin-left:-20px;">
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 160px;">
                     CaterPillar XL Upload </div>

                    <div id="verslic">
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 316px;">
                        <div id="tag_label_transact_Src">
                            Supplier Name</div>
                        <div id="txtcon-m_transaction_Supp_code" style="width: 175px;">
                            <asp:TextBox ID="txt_SupplierName_Gen" Width="160px" Font-Size="12px" runat="server"
                                CssClass="validate txtbox_none_Mid_transac_Supp_Name" ClientIDMode="Static"
                                TabIndex="1"></asp:TextBox>
                        </div>
                      
                        <div id="magnify_area">
                            <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('GSupplier'); return false"
                                class="magnfy"></a>
                        </div>
                    </div>
                    <div id="txt_container_Transact_Main_l" style="width: 300px;">
                                <div id="tag_label_transact_Src" style="width: 106px;">
                                    Select a Excel</div>
                                <div id="txtcon-m_Exchange" style="width: 120px;">
                                    <asp:FileUpload ID="fileuploadExcel_CP" runat="server" onchange="document.getElementById('btn_upload').click();"/>
                                         <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" Style="display: none;" />
                                        <%-- <asp:FileUpload ID="fileuploadExcel_CP" runat="server"/>--%>
                                </div>
                    </div>

                    <div id="verslic">
                    </div>
                          
                    <div id="editbu">
                        <asp:Button ID="btnUpload" runat="server" Width="100px"  CssClass="autowidmovebut"  OnClick="btnUpload_Click" Visible="false"  />
                    </div>
        
                    <div id="popupwindow_closebut_right_new">
                                <asp:Button ID="btnClose" runat="server"  CssClass="clsicon_new" OnClientClick="RefreshParent();"
                                CausesValidation="false"    UseSubmitBehavior="false" />
                                
                    </div>
           

                </div>
                
            </div>
           <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
             </div>

                <div class="content" id="page-1" style="margin-left:-30px; margin-top:-15px; width:1110px;">
                <div id="open_item" runat="server">
                <div class="content" id="page-6" >
                
                <div id="pop_text_area_transac_popup_inn_container_export" style="height:30px; width:width:926px; margin-top: -16px; overflow:hidden;">
                <asp:Button ID="btnShow" runat="server" Text="New Partno" OnClientClick="return ShowModalPopup()" />
                 <span  style="font-weight:bold;"> 
                     <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                      </span>
                </div>
                    <div id="pop_text_area_transac_popup_inn_container_export" style="height: 280px; width:width:926px; margin-top: 0px; overflow:hidden;">
                        <div id="tag_transac_lft_Item_maindet_Grid_area"   style="overflow:auto; height:328px; width:926px; ">
                        
                           <asp:GridView ID="gv_Item_Details" runat="server"  EmptyDataText="No Record Found" DataKeyNames="PARTNO"
                                AutoGenerateColumns="False" BackColor="White" BorderColor="#C8C8C8" BorderStyle="none"  
                                ShowFooter="True" BorderWidth="1px" CellPadding="1" CellSpacing="1" CssClass="grid-view" AllowPaging="false"
                                 HorizontalAlign="Left" ShowHeaderWhenEmpty="True" Width="100%"
                                OnRowCreated="gv_Item_Details_RowCreated" Visible="false" >
                                
                                <RowStyle BorderWidth="0.1em" BorderColor="black" />
                                <PagerStyle  ForeColor="Black"  CssClass="pager" />
                                <Columns>

                                     <asp:BoundField DataField="PARTNO" HeaderText="Part No" HeaderStyle-Width="50px">
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
        
           </ContentTemplate>
    </asp:UpdatePanel>

    <asp:modalpopupextender ID="MP_U" runat="server" TargetControlID="HDU"
        PopupControlID="MessageDivupdated_U" 
        BackgroundCssClass="modalBackground" DropShadow="false"   >
    </asp:modalpopupextender>
 
    <asp:HiddenField ID="HDU" runat="server" />

    <asp:Panel ID="MessageDivupdated_U" runat="server" CssClass="modalPopup12" align="left"  BorderColor="Transparent">
        <div id="innerbox_MidMain_popup_adcode_ItemMove" style="width: 800px; height: 150px;">
        <div id="tag_transac_lft_Inv_in1" style="width: 790px; height:30px;">
          <div id="mainmastop2container_rght_tag2_txt1" style="width: 160px;"> Product Master </div>
                     
        <div id="popupwindow_closebut_right_new">
             <asp:Button ID="btnHide" runat="server"  CssClass="clsicon_new" OnClientClick="return HideModalPopup()"
              CausesValidation="false"    UseSubmitBehavior="false" />
        </div>
        </div>
            <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
             <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice">
                    Part No
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:TextBox ID="txtpart_no" runat="server"  MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                        TabIndex="1"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice">
                    Item Desc.
                </div>
                <div id="txtcon-m_transaction_Inv_No" style="width:250px">
                    <asp:TextBox ID="txt_Item_dec" runat="server" Width="250px" MaxLength="500" CssClass="txtbox_none_Mid_transac_Inv_No"
                        TabIndex="2"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>

            </div>

             <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
              <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice">
                    HSN Code
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:TextBox ID="txt_HSN_Code" runat="server" MaxLength="16" CssClass="validate[required] txtbox_none_Mid_transac_Inv_No"
                        TabIndex="3"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice">
                    Basic Notfn
                </div>
                <div id="txtcon-m_transaction_Inv_No" >
                    <asp:TextBox ID="txt_basic_Notn" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                        TabIndex="4"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 100px;">
                    Basic Notfn Slno
                </div>
                <div id="txtcon-m_transaction_Inv_No" style="width: 70px;">
                    <asp:TextBox ID="txt_basic_Notn_Slno" Width="70px" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                      TabIndex="5"></asp:TextBox>
                </div>
            </div>
            <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
             <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice">
                    IGST Notn
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:TextBox ID="txt_IGST_Notn" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                        TabIndex="6"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice">
                    IGST Notn Slno
                </div>
                <div id="txtcon-m_transaction_Inv_No" >
                    <asp:TextBox ID="txt_IGST_Notn_Slno" Width="70px" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                        TabIndex="7"></asp:TextBox>
                </div>
           
            </div>
            <div id="tag_transac_lft_Inv_in1" style="width: 790px;"></div>

            <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
             <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice">
                    
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice">
                         <asp:Button ID="btnSaveProduct"  Text="Save Master" CssClass="autowidupdatebut" runat="server" TabIndex="8"  Height="20px" UseSubmitBehavior="false"  Width="100px"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');Go_Product('S');return false;"   /> 
                </div>
                <div id="txtcon-m_transaction_Inv_No" >
                     <asp:Button ID="btnUpdateProduct"  Text="Update Master" CssClass="autowidupdatebut" runat="server" Height="20px" TabIndex="9" UseSubmitBehavior="false"  Width="100px"
                            OnClientClick="jQuery('#form1').validationEngine('hideAll');Go_Product('U');return false;" />
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
    </script>

              <script type="text/javascript">
                  function Go_Product(flag) {
                      PageMethods.Save_Product(document.getElementById("<%=txtpart_no.ClientID%>").value, document.getElementById("<%=txt_Item_dec.ClientID%>").value, document.getElementById("<%=txt_HSN_Code.ClientID%>").value, document.getElementById("<%=txt_basic_Notn.ClientID%>").value, document.getElementById("<%=txt_basic_Notn_Slno.ClientID%>").value, document.getElementById("<%=txt_IGST_Notn.ClientID%>").value, document.getElementById("<%=txt_IGST_Notn_Slno.ClientID%>").value, flag, OnSuccess);
                  }
                  function OnSuccess(response, userContext, methodName) {
                      alert(response);
                  }
    </script>
     
</body>
</html>
