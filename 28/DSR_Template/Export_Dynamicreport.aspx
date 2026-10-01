<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_Dynamicreport.aspx.cs" Inherits="DSR_Template_Export_Dynamicreport" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title> Export - Customized Report</title>
    <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />

     <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />
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
    <%--<script src="../js/Export_Rpt/BL_Generation.js" type="text/javascript"></script>--%>
    <script src="../js/EGM/EGM_General.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/listpopup.js"></script>

    <script type="text/javascript" src="../js/Export_Jscript/Export_General.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });

        function HideModalPopup_U() {

            $find("MP_U").hide();
            return false;
        }
    </script>
    <style type="text/css">
        .ListControl input[type=radio] + label
        {
            display: table-cell;
            width: 7.5em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .ListControlWidth input[type=radio] + label
        {
            display: table-cell;
            width: 10em;
            height: 5em;
            line-height: 0em;
            text-align: left;
        }
        
        .txtbox_none_Mid_transac_item_other_rmarks_new1_LC
        {
            color: #2b2b2b;
            font-family: Arial,Helvetica,sans-serif;
            font-size: 14px;
            margin-top: 2px;
            width: 385px;
            max-width: 385px;
            height: 350px;
            max-height: 350px;
            border: #c0e4f2 solid thin;
            -moz-border-radius-topleft: 5px;
            -moz-border-radius-topright: 5px;
            -moz-border-radius-bottomleft: 5px;
            -moz-border-radius-bottomright: 5px;
            -webkit-border-top-left-radius: 5px;
            -webkit-border-top-right-radius: 5px;
            -webkit-border-bottom-left-radius: 5px;
            -webkit-border-bottom-right-radius: 5px;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            overflow: auto;
        }
    </style>
    <script src="../js/js_bootstrap/jquery.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap.min.js" type="text/javascript"></script>
    <link href="../js/js_bootstrap/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
    <script src="../js/js_bootstrap/bootstrap-multiselect.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(function () {
            $('[id*=ListBox1]').multiselect({

                includeSelectAllOption: true
            });
        });
        //---------------------------------Diana added----------------------------------------//
        $(document).ready(function () {
            ListBoxSelect();
            $('#ListBox1').change(function () {
                var selectedValues = [];
                $('#ListBox1 option:selected').each(function () {
                    selectedValues.push($(this).text());
                });
                if (selectedValues.length > 0) {
                    $('.multiselect').text("(" + selectedValues.length + ")" + " Selected");
                }
                else {
                    $('.multiselect').text("None Selected");
                }

            });
        });
        function ListBoxSelect() {
            var selectedValues = [];
            $('#ListBox1 option:selected').each(function () {
                selectedValues.push($(this).text());
            });
            if (selectedValues.length > 0) {
                $('.multiselect').text("(" + selectedValues.length + ")" + " Selected");
            }
            else {
                $('.multiselect').text("None Selected");
            }
            console.log('selectedValuesLoad', selectedValues);
        }

        function ExcelLoading() {
            document.getElementById('loadingIcon').style.display = 'block';
        }
        function ExcelHiding() {
            document.getElementById('loadingIcon').style.display = 'block';
        }

        function showLoading() {
            document.getElementById('loadingIcon').style.display = 'block';
        }

        function hideLoading() {
            setTimeout(function () {
                document.getElementById('loadingIcon').style.display = 'none';
            }, 1000);
        }

        function validdate() {
            var rptname = $('#ddlrptname option:selected').text();
            var GroupName = $('#ListBox1 option:selected').text();
            var msg = "";
            var FocusID = "";
            console.log('rptname', rptname);
            console.log('GroupName', GroupName);
            if (rptname == "") {
                msg += "Please Select Rport Name \n";
                FocusID = "#ddlrptname";
            }
            if (GroupName == "") {
                msg += "Please Select  Group Name \n";
                FocusID = "#ListBox1";
            }
            if (msg != "") {
                alert(msg);
                var focusElement = document.getElementById(FocusID);
                if (focusElement) {
                    focusElement.focus();
                }
                return false;
            }
            else {
                $('#loadingIcon').css('display', 'block');
                return true;
            }

        }
        //////////////////////////////////////////////////// -------------------Diana added----------------------------------------//
</script> 
   
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
   
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
        <div id="loadingIcon" style="display: none; position: absolute; top: 11%; left: 47%;
            height: 21vh; transform: translate(-50%, -50%); z-index: 9999;">
            <img src="../images/Loading_img2.gif" alt="Loading..." width="86%" height="153px"
                style="margin-top: 64%; margin-left: 33px;" />
        </div>
        <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_Transact_popup_new" style="height:140px; overflow:visible; width:1150px;">
                <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1" style="width:250px">
                       Export - Customized Report
                    </div>
                    <div id="tag_label_transaction_popup_trans_cth_label2" style="width:100px; font-weight:bold; color:Blue; margin-top:5px;">
                                    Report Name
                                </div>
                                <div id="txtcon-m_transaction_code"  style="margin-top:5px;">
                                    <asp:DropDownList ID="ddlrptname" runat="server" CssClass="txtbox_none" Font-Size="12px">
                        </asp:DropDownList>
                                </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="tag_transact_src_inner" style="width: 965px; ">
                    <div id="tag_Exchange_inner_lft" ">
                        <div id="tag_transact_lft_in1">
                            <div id="tag_transac_exp_drawback" style="width: 1100px; margin-top:10px;">
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width:80px";>
                                    Job No
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 150px">
                                        <asp:DropDownList ID="ddlJobNo" runat="server" Width="150px" Height="23px" CssClass="listtxt_transac_Item_Schemecode">
                        </asp:DropDownList>
                                </div>
                                
                              
                                <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 80px">
                                    Exp. Name
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 150px">
                                     <asp:DropDownList ID="ddlExpname" runat="server" CssClass="txtbox_none"  Font-Size="12px" Width="150px" Height="23px">
                        </asp:DropDownList>
                                </div>
                                  <div id="tag_label_transaction_popup_IGM2_empty">
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 70px">
                                     Based on
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 130px">
                                     <asp:DropDownList ID="ddlbase" runat="server" Width="98px" CssClass="listtxt_transac_Item_Schemecode" Font-Size="12px">
                            <asp:ListItem Text="Jobno"></asp:ListItem>
                            <asp:ListItem Text="Invoice"></asp:ListItem>
                            <asp:ListItem Text="Item"></asp:ListItem>
                            <asp:ListItem Text="AR4_Details"></asp:ListItem>
                            <asp:ListItem Text="Container"></asp:ListItem>
                             <%--<asp:ListItem Text="BENO"></asp:ListItem>--%>
                        </asp:DropDownList>
                                </div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 60px">
                                     SB Type
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 110px">
                                    <asp:DropDownList ID="ddlSBType" runat="server" CssClass="listtxt_transac_mode_new"
                                        Width="110px">
                                        <asp:ListItem Text="" Value=""></asp:ListItem> 
                                        <asp:ListItem Text="Drawback" Value="Drawback"></asp:ListItem>
                                        <asp:ListItem Text="Free Duty" Value="Free Duty"></asp:ListItem>
                                        <asp:ListItem Text="License" Value="License"></asp:ListItem>
                                        <asp:ListItem Text="EOU" Value="EOU"></asp:ListItem>
                                        <asp:ListItem Text="98-Scheme" Value="98-Scheme"></asp:ListItem>
                                        <asp:ListItem Text="99-NFEI Scheme" Value="99-NFEI Scheme"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="tag_label_transaction_popup_IGM2_empty"></div>
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 90px">
                                     Sort Job No
                                </div>
                                <div id="txtcon-m_transaction_code"  style="Width:150px">
                                     <asp:DropDownList ID="ddlorederby" runat="server" Font-Size="12px" Width="130px" CssClass="listtxt_transac_Item_Schemecode">
                        <asp:ListItem Text="Ascending"></asp:ListItem>
                        <asp:ListItem Text="Descending"></asp:ListItem>
                        </asp:DropDownList>
                                </div>
                            </div>
                          
                             <div id="tag_transac_exp_drawback" style="width: 1100px; ">
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width:80px";>
                                    From Date
                                </div>
                                <div id="txtcon-m_transaction_code"  style="width: 150px">
                                       <asp:TextBox ID="txtFrom_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new" Width="150px"
                            MaxLength="10" TabIndex="3"></asp:TextBox>
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
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 80px">
                                     To Date
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 150px">
                                    <asp:TextBox ID="txtTo_Date" runat="server" CssClass="txtbox_none_Mid_transac_code_new" Width="150px"
                            MaxLength="10" TabIndex="4"></asp:TextBox>
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
                                <div id="tag_label_transaction_popup_trans_cth_label2" style="width: 80px">
                                      Group Name
                                </div>
                                <div id="txtcon-m_transaction_code" style="width: 350px">
                                    <asp:ListBox ID="ListBox1"  SelectionMode="Multiple" runat="server" Width="180px"></asp:ListBox>
                                </div>
                        
                                <div id="editbu">
                                <a href="#" class="srcbu" id="btnSearch" runat="server" onserverclick="btnSearch_Click"
                        onclick="return validdate();" tabindex="6"></a>
                                </div>
                                 <div id="editbu">
                                     <a href="#" onclick="win_hide();parent.adcodewindow.hide();return false;" class="cancelButt"
                                         tabindex="7"></a>
                                 </div>
                             </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="innerbox_MidMain_Grid">
                <div id="tag_srcinner1grid">
                    <div id="tag_transac_exp_drawback">
                        <a href="#" id="btnex" runat="server" style="display: block; width: 50px; height: 30px;
                            background-image: url('../images/xls.jpg'); background-repeat: no-repeat;" onserverclick="btnexcel_Click"
                            tabindex="7"></a>
                    </div>
                        <div id="tag_label_transaction_popup_trans_cth_label2"  style="width:150px; margin-top:5px;">
                            <asp:Label ID="lbl_count" runat="server" ForeColor="Blue" ></asp:Label>
                        </div>
                         <div id="tag_label_transaction_popup_trans_cth_label2"  style="width:150px; margin-top:5px;">
                            <asp:Label ID="lbl_cols_count" runat="server" ForeColor="Blue" ></asp:Label>
                        </div>
                </div>
                
                <div id="tag_srcinner1grid_table_Container">
                    <div id="Main_Grid_Container" style="height: 400px;">
                        <asp:GridView runat="server" ID="GvReport" EmptyDataText="NO RECORD FOUND" AutoGenerateColumns="false"
                            BorderStyle="Solid" CssClass="grid-view" ShowHeader="true" ShowHeaderWhenEmpty="true"
                            Width="100%" RowStyle-BorderColor="ActiveBorder" CellPadding="1" CellSpacing="1"
                            ShowFooter="true" OnRowCreated="GvReport_RowCreated" OnRowDataBound="GvReport_RowDataBound">
                        </asp:GridView>
                    </div>
                </div>
            </div>


        </ContentTemplate>
                           
    </asp:UpdatePanel>
    </form>
    <script type="text/javascript" src="../windowfiles/dhtmlwindow.js"></script>
    <script type="text/javascript" src="../modalfiles/modal.js"></script>
    <script type="text/javascript" src="../js/slide.js"></script>
    <script type="text/javascript" src="../js/jscolor.js"></script>
    <script type="text/javascript" src="../js/iframepopupwin.js"></script>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        body
        {
            font-size: 62.5%;
        }
    </style>
    <%--<script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>--%>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
   


</body>
</html>

