<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Imp_DSR_Excel.aspx.cs" Inherits="Imp_DSR_Excel" %> 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Import DSR Excel Upload </title>
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
            <div id="innerbox_MidMain" style="height:32px;">
                <div id="tag_srcinner1">
                
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 250px;">
                     Imp.DSR XL Upload </div>

                    <div id="verslic">
                    </div>
                    
                    <div id="txt_container_Transact_Main_l" style="width: 300px;">
                                <div id="tag_label_transact_Src" style="width: 106px;">
                                    Select a Excel</div>
                                <div id="txtcon-m_Exchange" style="width: 120px;">
                                    <asp:FileUpload ID="fileuploadExcel" runat="server" onchange="document.getElementById('btn_upload').click();"/>
                                         <asp:Button ID="btn_upload" runat="server" OnClick="btn_upload_Click" Style="display: none;" />
                                </div>
                    </div>

                    <div id="verslic">
                    </div>
                          
                    <div id="editbu"> 
                    <asp:Button ID="btnUpload" runat="server" Width="100px"  CssClass="autowidmovebut" Text="Upload"
                        onclick="btnSaveProduct_Click" Visible="false"/>

                    </div>
        
                    <div id="popupwindow_closebut_right_new">
                                <asp:Button ID="btnClose" runat="server"  CssClass="clsicon_new" OnClientClick="RefreshParent();"
                                CausesValidation="false"    UseSubmitBehavior="false" />
                                
                    </div>
           

                </div>
                
            </div>
           
            <script src="../activatables.js" type="text/javascript"></script>
           
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

     

<script type="text/javascript" language="javascript">
   
    function Go_IMP_EXCEL() {
        HideModalPopup();       

        PageMethods.IMP_Excel_Upload('', OnSuccess);
            }
            function OnSuccess(response, userContext, methodName) {
                jAlert(response, 'DSR', function (r) { });
            }
</script>

     
</body>
</html>
