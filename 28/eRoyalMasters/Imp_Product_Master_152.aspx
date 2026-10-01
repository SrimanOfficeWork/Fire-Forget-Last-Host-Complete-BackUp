<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_Product_Master_152.aspx.cs" Inherits="Imp_Product_Master_152" %> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import Product Master</title>
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
            <div id="innerbox_MidMain" style="height:32px; margin-left:-20px;">
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 350px;">
                     Import Product Master Insert & Update </div>
        
                    <div id="popupwindow_closebut_right_new">
                               <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                                
                    </div>
           

                </div>
                
            </div>
           <%-- -------------------------------------Tab--------------------------------------------------------%>

            <div id="innerbox_MidMain_Trans" style="width: 1104px; height: 5px; margin-top: -12px;">
             </div>

                <div class="content" id="page-1" style="margin-left:-30px; margin-top:-15px; width:1110px;">
                <div id="open_item" runat="server">
                <div class="content" id="page-6" >
                
                <div id="pop_text_area_transac_popup_inn_container_export" style=" width:width:926px; margin-top: -16px; overflow:hidden;">
              <%--  <asp:Button ID="btnShow" runat="server" Text="New Partno" OnClientClick="return ShowModalPopup()" />--%>
                <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
                </div>

                <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
                 <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice">
                          Type
                        </div>
                        <div id="txtcon-m_transaction_Inv_No" style="width: 250px;">
                            <asp:RadioButtonList ID="Rd_Type" runat="server" RepeatDirection="Horizontal" TabIndex="1"
                                onselectedindexchanged="Rd_Type_SelectedIndexChanged" AutoPostBack="true" >
                            <asp:ListItem Text="Save" Selected="True" Value="S"></asp:ListItem>
                            <asp:ListItem Text="Update" Value="U"></asp:ListItem>
                            <asp:ListItem Text="Delete" Value="D"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 140px">
                       
                        </div>
                        <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                           
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                </div>

                <span id="Old_Partno" runat="server">
                <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
                 <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice" style="color:Red;">
                           Old Part No
                        </div>
                        <div id="txtcon-m_transaction_Inv_No">
                            <asp:TextBox ID="txtpart_no" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No" 
                                TabIndex="2" ontextchanged="txtpart_no_TextChanged" AutoPostBack="true" ></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 300px; color:Red; font-weight:bold;">
                            <asp:Literal ID="lblmsg" runat="server"></asp:Literal>
                        </div>
                        <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                           
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                </div>
                </span>

                <span id="New_Partno" runat="server">
                 <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
                 <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice" style="color:Green;">
                         New Part No
                        </div>
                        <div id="txtcon-m_transaction_Inv_No">
                            <asp:TextBox ID="txt_New_part_no" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"  
                                TabIndex="2" ontextchanged="txt_New_part_no_TextChanged" AutoPostBack="true"  ></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 300px; color:Red; font-weight:bold;">
                        <asp:Literal ID="lblmsg_new_part" runat="server"></asp:Literal>
                        </div>
                        <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                           
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                </div>
                
                </span>

                 <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice">
                           RITC NO
                        </div>
                        <div id="txtcon-m_transaction_Inv_No" style="width:170px;" ;>
                             <asp:TextBox ID="txt_RITCNO" runat="server" Width="165px" MaxLength="8" CssClass="txtbox_none_Mid_transac_Inv_No"
                                TabIndex="5"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 140px">
                             Basic Duty/Notn
                        </div>
                        <div id="txtcon-m_transaction_Inv_No" style="width: 145px">
                          <asp:TextBox ID="txtBasicNotn" runat="server" MaxLength="8" TabIndex="6" Width="120px" onkeypress="return notn(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_maindet" ></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice" style="width: 120px">
                             Notn Slno.
                        </div>
                        <div id="txtcon-m_transaction_Inv_No" style="width: 55px">
                          <asp:TextBox ID="txtBasicSLNO" runat="server" MaxLength="8" TabIndex="7" onkeypress="return NOTNSLNO(event)"
                                    ClientIDMode="Static" CssClass="txtbox_none_Mid_transac_item_maindet" ></asp:TextBox>
                        </div>
                    </div>
                    <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice">
                            Item Desc.
                        </div>
                        <div id="txtcon-m_transaction_Inv_No" style="width: 465px">
                            <asp:TextBox ID="txt_Item_dec" runat="server" Width="465px" MaxLength="500" CssClass="txtbox_none_Mid_transac_Inv_No"
                                TabIndex="10"></asp:TextBox>
                        </div>
                    </div>
                     <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_invoice">
                            General Desc.
                        </div>
                        <div id="txtcon-m_transaction_Inv_No" style="width: 465px">
                            <asp:TextBox ID="txt_General_dec" runat="server" Width="465px" MaxLength="500" CssClass="txtbox_none_Mid_transac_Inv_No"
                                TabIndex="11"></asp:TextBox>
                        </div>
                    </div>



             <div id="tag_transac_lft_Inv_in1" style="width: 850px;">
              <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice">
                   IGST Levy Notn.
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:TextBox ID="txt_IGST_Levy_Notn" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                        TabIndex="12"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 140px">
                    IGST Levy Notn. Slno
                </div>
                <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                    <asp:TextBox ID="txt_IGST_Levy_Notn_Slno" Width="165px" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                        TabIndex="14"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 140px;">
                    IGST Levy Notn. Rate
                </div>
                <div id="txtcon-m_transaction_Inv_No" style="width: 100px;">
                    <asp:TextBox ID="txt_IGST_Levy_Notn_Rate" Width="100px" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                      TabIndex="16"></asp:TextBox>
                </div>
            </div>

             <div id="tag_transac_lft_Inv_in1" style="width: 850px;">
              <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice">
                   IGST Levy Compensation Cess Notn.
                </div>
                <div id="txtcon-m_transaction_Inv_No">
                    <asp:TextBox ID="txt_IGST_Levy_Compen_Cess_Notn" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                        TabIndex="17"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 140px">
                   IGST Levy Compensation Cess Notn. Slno
                </div>
                <div id="txtcon-m_transaction_Inv_No" style="width: 165px">
                    <asp:TextBox ID="txt_IGST_Levy_Compen_Cess_Notn_Slno" Width="165px" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                        TabIndex="18"></asp:TextBox>
                </div>
                <div id="tag_label_transaction_popup_IGM2_empty">
                </div>
                <div id="tag_label_transaction_popup_IGM_invoice" style="width: 140px;">
                    IGST Levy Compensation Cess Notn. Rate
                </div>
                <div id="txtcon-m_transaction_Inv_No" style="width: 100px;">
                    <asp:TextBox ID="txt_IGST_Levy_Compen_Cess_Notn_Rate" Width="100px" runat="server" MaxLength="16" CssClass="txtbox_none_Mid_transac_Inv_No"
                      TabIndex="20"></asp:TextBox>
                </div>
            </div>
            
            <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
            </div>

            <div id="tag_transac_lft_Inv_in1" style="width: 790px;">
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
                    <asp:Button ID="btnSave_Update_Product"   CssClass="autowidupdatebut" 
                        runat="server" TabIndex="22"  Height="20px" UseSubmitBehavior="false"  Width="100px" 
                        onclick="btnSave_Update_Product_Click"  /> 
                </div>
           
            </div>

                </div>


                    
                </div>

                   </div>
                 </div>

                 
                 
  <asp:HiddenField ID="HDupdate_id" runat="server" />
              
                <%-----------------------------------END----------------------------------------------------------------%>
          
           
            <script src="../activatables.js" type="text/javascript"></script>
            <script type="text/javascript">
                activatables('page', ['page-1', 'page-2', 'page-3', 'page-4', 'page-5', 'page-6', 'page-7', 'page-8', 'page-9']);
            </script>
        
           </ContentTemplate>
    </asp:UpdatePanel>


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
                     
                  }
                  function OnSuccess(response, userContext, methodName) {
                      alert(response);
                  }
    </script>
     
</body>
</html>
