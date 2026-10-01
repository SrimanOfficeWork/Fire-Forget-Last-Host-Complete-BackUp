<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GST_Invoice_No_Edit.aspx.cs" Inherits="GST_Invoice_No_Edit" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Sales Invoice Edit</title>
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
function Char_Inv(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 65 || charCode > 90) && (charCode < 97 || charCode > 122) && (charCode < 45 || charCode > 45) && (charCode < 47 || charCode > 47))
        return false;
    return true;
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
            <div id="innerbox_MidMain" style=" height: 260px;width: 750px;" >
                <div id="tag_srcinner1" style="width: 750px;" >
                    <div id="mainmastop2container_rght_tag2_txt1" style="width: 100px;">
                      Sales Inv. No 
                    </div>
                    <div id="verslic">
                    </div>
                        <div id="txt_container_Transact_Main_l" style="width: 320px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                     Change To <span style="color:Red;" >* </span>
                                </div>
                                <div id="txtcon-m_Exchange">
                                     <asp:DropDownList ID="ddl_Convert_to" CssClass="listtxt_transac_item_gen_notn" Width="150px"
                                        runat="server" TabIndex="10" AutoPostBack="true" 
                                        onselectedindexchanged="ddl_Convert_to_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                </div>
                            </div>
                  
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>

           
                </div>
                <div id="tag_transact_src_inner" style="width: 750px">
                    <div id="tag_Exchange_inner_lft" style="width: 750px">
                        <div id="tag_transact_lft_in1" style="width: 750px;">
                            <div id="txt_container_Transact_Main_l" style="width: 320px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                     From Invoice No: <span style="color:Red;" >* </span>
                                </div>
                                <div id="txtcon-m_Exchange">
                                  <asp:DropDownList ID="ddlinv_no"  class="chosen-select-deselect"
                                        data-placeholder="Choose a Bill Inv no." Style="width: 190px;"
                                        runat="server" TabIndex="10" AutoPostBack="true" OnSelectedIndexChanged="ddlinv_no_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 380px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                   Party Name
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 250px;">
                                 <asp:Literal ID="lblImp_name" runat="server"></asp:Literal>
                               
                                </div>
                            </div>
                        </div>

                         <div id="tag_transact_lft_in1" style="width: 750px;">
                            <div id="txt_container_Transact_Main_l" style="width: 320px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                   To Invoice No
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <asp:TextBox ID="txt_InvoiceNo_New" runat="server" MaxLength="17" onkeyup="autotab(this);"
                                     ClientIDMode="Static" onblur="return ChangeCase(this);" onkeypress="return Char_Inv(event)"
                                     CssClass="txtbox_none_Mid_transac_Inv_No" TabIndex="25"></asp:TextBox>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 320px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                     Created By 
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 200px;">
                                       <span style="color: Green; font-size:12px;">
                                        <asp:Literal ID="lblCreatedby" runat="server"></asp:Literal></span>
                                </div>
                            </div>
                        </div>

                        <div id="tag_transact_lft_in1" style="width: 750px; height: 30px;">
                            <div id="txt_container_Transact_Main_l" style="width: 320px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                    To Inv. Date:
                                </div>
                                <div id="txtcon-m_Exchange">
                                    <span style="color: Green;">
                                        <asp:TextBox ID="txt_to_Inv_Date" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                            TabIndex="37"></asp:TextBox>
                                        <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_to_Inv_Date"
                                            Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                            CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                            Enabled="True">
                                        </asp:MaskedEditExtender>
                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to_Inv_Date"
                                            Format="dd/MM/yyyy" Enabled="True">
                                        </asp:CalendarExtender>
                                </div>
                            </div>
                            <div id="txt_container_Transact_Main_l" style="width: 320px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                    From Inv. Date
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 200px;">
                                    <asp:Literal ID="lbl_from_date" runat="server"></asp:Literal></span>
                                    <%--<asp:TextBox ID="txt_to_Inv_Date" runat="server" MaxLength="10" CssClass="validate[required] txtbox_none_Mid_transac_code"
                                        TabIndex="37"></asp:TextBox>
                                    <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txt_to_Inv_Date"
                                        Mask="99/99/9999" MaskType="Date" ErrorTooltipEnabled="True" CultureAMPMPlaceholder=""
                                        CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                        CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                        Enabled="True">
                                    </asp:MaskedEditExtender>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_to_Inv_Date"
                                        Format="dd/MM/yyyy" Enabled="True">
                                    </asp:CalendarExtender>--%>
                                </div>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 750px; height: 30px;">
                            <div id="txt_container_Transact_Main_l" style="width: 450px;">
                                <div id="tag_label_transact_Src" style="width: 120px;">
                                   Generate Bill
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 250px;">

                                <asp:RadioButtonList ID="Rd_Bill_Type" runat="server"  
                                        RepeatDirection="Horizontal"  TabIndex="6"  >
                                    <asp:ListItem Text="Local State" Value="L" Selected="True" ></asp:ListItem>
                                    <asp:ListItem Text="Other State" Value="O"></asp:ListItem>
                                    </asp:RadioButtonList>
                                        
                                </div>
                            </div>
                        </div>
                        <div id="tag_transact_lft_in1" style="width: 750px;">
                            <div id="txt_container_Transact_Main_l" style="width: 320px;">
                                <%--<div id="tag_label_transact_Src" style="width: 120px;">
                                    Created By
                                </div>
                                <div id="txtcon-m_Exchange" style="width: 190px;">
                                    <span style="color: Green;">
                                        <asp:Literal ID="lblCreatedby" runat="server"></asp:Literal></span>
                                </div>--%>
                            </div>
                        </div>
                        <%-- --------------------Other--------------------------------------------%>
                        <div id="tag_transact_lft_in1" style="width: 750px;">
                            <div id="txt_container_Transact_Main_l" style="width: 750px;">
                                <div id="tag_label_transact_Src" style="width: 200px;">
                                </div>
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    <asp:Button ID="btnupdate" TabIndex="22" runat="server" Text="Update" OnClick="btnupdate_Click" />
                                </div>
                               <%-- <div id="tag_label_transact_Src" style="width: 70px;">
                                </div>
                                <div id="tag_label_transact_Src" style="width: 70px;">
                                    <asp:Button ID="btn_duplicate" TabIndex="22" runat="server" Text="Inv. Duplicate"
                                        OnClick="btn_duplicate_Click" />
                                </div>--%>
                            </div>
                        </div>
                        <%-- ----------------------------------------------------------------%>
                    </div>
                </div>
                </div>
            </div>
            <%-- -------------------------------------Tab--------------------------------------------------------%>
          
             </ContentTemplate>
    </asp:UpdatePanel>
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
    </script>
   
    <link rel="Stylesheet" href="../Dropdown/chosen.css" />
    <link rel="Stylesheet" href="../Dropdown/chosen.min.css" />
    <script src="../Dropdown/chosen.jquery.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.jquery.min.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.js" type="text/javascript"></script>
    <script src="../Dropdown/chosen.proto.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var config = {
            '.chosen-select': {},
            '.chosen-select-deselect': { allow_single_deselect: true },
            '.chosen-select-no-single': { disable_search_threshold: 10 },
            '.chosen-select-no-results': { no_results_text: 'Oops, nothing found!' },
            '.chosen-select-width': { width: "95%" }

        }
        for (var selector in config) {
            $(selector).chosen(config[selector]);
        }
    </script>
    
</body>
</html>
