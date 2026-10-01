<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Import_Bond_Master.aspx.cs" Inherits="Import_Bond_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Import Bond Master</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        /* Autocomplete Textbox Search Loading Image*/
        .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
        /* Autocomplete Textbox Search Loading Image*/
    </style>
    <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    <script src="../MessageBox_js/jquery.js" type="text/javascript"></script>
    <script src="../MessageBox_js/jquery.alerts.js" type="text/javascript"></script>
    <%--<script src="../js/Export_Jscript/Export_Product.js" type="text/javascript"></script>--%>
    <script src="../js/eRoyalmaster_Jscript/Export_Product.js" type="text/javascript"></script>
    <%--<script src="../js/Export_Jscript/Export_Item.js" type="text/javascript"></script>--%>
     <link href="../gridmain.css" rel="stylesheet" media="screen, projection" type="text/css" />
     <link href="../js/Grid_header_script/GridviewScroll.css" rel="stylesheet" />
     <link href="../css/MainStyle.css" rel="stylesheet" media="screen, projection" type="text/css" />
     <link rel="stylesheet" href="../Validation Files/validationEngine.css" type="text/css" />
    <link rel="stylesheet" href="../Validation Files/template.css" type="text/css" />
    <link href="../tabs/tabs.css" rel="stylesheet" type="text/css" />
    <link href="../MessageBox_js/jquery.alerts.css" rel="stylesheet" type="text/css" />
    
<script type="text/javascript">
    $(document).ready(function () {
        var aa = $('#ddlSTRYesNo').val();
        var xx = $('#Get_STR').val();
        if (aa == 'Yes') {
            $("#txtSTRCode").attr("disabled", false);
            $("#txtSTRCode").val(xx);
        }
        else {
            $("#txtSTRCode").attr("disabled", true);
        }
    });
</script>

    <script type="text/javascript">

        $(document).ready(function Calljs() {
            $('#ddlSTRYesNo').change(function () {
                var aa = $('#ddlSTRYesNo').val();
                var xx = $('#Get_STR').val();
                if (aa == 'Yes') {
                    $("#txtSTRCode").attr("disabled", false);
                    $("#str_lcd").show();
                    $("#txtSTRCode").val(xx);

                }
                else {
                    $("#txtSTRCode").attr("disabled", true);
                    $("#txtSTRCode").val('');
                    $("#str_lcd").hide();
                   
                }

            });
        });
      
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtDrawback_SLNo').keyup(function () {
                var RITC = $('#txtRITCNo').val();

                if (RITC != '') {
                    var aa = RITC.substring(0, 4);
                    $('#Hdn_RITC_4_digit').val(aa);                 
//                    alert(aa);
                }
            });
        });
    </script>

</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        EnablePageMethods="true" LoadScriptsBeforeUI="false">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_supplier">
                <div id="innerbox_MidMain_top_adcode">
                  IMPORT - BOND MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_supplier" style="height: 205px">
                    <div id="pop_text_area" style="margin-left: 10px; height: 15px;">
                        <div id="tag_label_adcode" style="width: 100px">
                            Bond No</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src" style="width: 105px">
                            <asp:TextBox ID="txtBondNo" runat="server" MaxLength="50" CssClass="validate[required] txtbox_none"
                                Width="180px" TabIndex="1" onkeypress="return pin(event)" AutoPostBack="true" onblur="Bond_aval_amt()"></asp:TextBox>
                        </div>
                    </div>
                    <div id="pop_text_area" style="margin-left: 10px; height: 15px;">
                        <div id="tag_label_adcode" style="width: 100px">
                            Bond Date</div>
                        <div id="txtcon-l_src">
                        </div>
                        <div id="txtcon-m_src" style="width: 105px">
                            <asp:TextBox ID="txtBond_date" runat="server" CssClass="validate[required] txtbox_none" Width="100px"
                                    Onkeypress="return numchar(event)" TabIndex="2" MaxLength="40"></asp:TextBox>
                                <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtBond_date"
                                    Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                    MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                                </asp:MaskedEditExtender>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtBond_date"
                                    Format="dd/MM/yyyy">
                                </asp:CalendarExtender>
                        </div>
                    </div>
                    <div id="pop_text_area" style="margin-left: 10px; height: 15px;">
                        <div id="tag_label_adcode" style="width: 100px">
                            Bond Location
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <asp:TextBox ID="txtBondLocation" runat="server" onkeyup="autotab(this);" CssClass="validate[required] txtbox_none"
                             Width="180px"   MaxLength="50" TabIndex="3" ClientIDMode="Static" onblur="Bond_aval_amt()"></asp:TextBox>
                        </div>
                        <div id="magnify_area" runat="server">
                            <a href="#" class="magnfy" onclick="OpenPopupCustom_House('BOND_LOCATION'); return false"
                                tabindex="6"></a>
                        </div>
                    </div>
                    <div id="pop_text_area" style="margin-left: 10px; height: 15px;">
                        <div id="tag_label_adcode" style="width: 100px">
                            Bond Type
                        </div>
                        <div id="txtcon-m_transaction_list1_bondtype">
                            <asp:DropDownList ID="ddlBondType" runat="server" CssClass="txtbox_none" onblur="Bond_aval_amt()"
                                TabIndex="4">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="pop_text_area" style="margin-left: 10px; height: 15px;">
                        <div id="tag_label_adcode" style="width: 100px">
                            Bond Amount
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <asp:TextBox ID="txtBondAmt" runat="server" onkeyup="autotab(this);" CssClass="txtbox_none"
                                MaxLength="50" TabIndex="5" ></asp:TextBox>
                        </div>
                       
                    </div>
                      <div id="pop_text_area" style="margin-left: 10px; height: 15px;">
                        <div id="tag_label_adcode" style="width: 100px">
                            Avil Amount
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <asp:TextBox ID="txt_avail" runat="server" onkeyup="autotab(this);" CssClass="txtbox_none" ReadOnly="true" 
                                MaxLength="50" TabIndex="5" ></asp:TextBox>
                        </div>
                       
                    </div>
                    <div id="pop_text_area" style="margin-left: 10px; height: 15px; visibility:hidden;">
                        <div id="tag_label_adcode" style="width: 100px">
                            Remaining Amt
                        </div>
                        <div id="txtcon-m_transaction_pop_gen1_srcic">
                            <asp:TextBox ID="txtRemainingAmt" runat="server" onkeyup="autotab(this);" CssClass="txtbox_none" ReadOnly="true"
                                MaxLength="50" TabIndex="6" ></asp:TextBox>
                        </div>
                       
                    </div>
                    <div id="tag_transac_lft_in1_export_marks" style="width: 400px; margin-left: 10px; margin-top:10px;
                        height: 60px;">
                        <div id="tag_label_transaction_popup_gen_export" style="width: 100px">
                            Remarks
                        </div>
                        <div id="txtcon-m_46px_trans_export_marks" style="width: 290px;">
                            <asp:TextBox ID="txt_Remarks" runat="server" MaxLength="200" onkeyDown="return checkTextAreaMaxLength(this,event,'200');"
                                Width="280px" onpaste="return checkTextAreaMaxLength(this,event,'200');" CssClass="txtbox_none_Mid_transac_item_other_rmarks_new1"
                                TextMode="MultiLine" TabIndex="7" Onkeypress="return numcharspl1(event)"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div id="innerbox_MidMain_top_adcode" style="margin-top:25px">
                    <div id="innerbox_adcode_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                                OnClick="btnNew_Click" CssClass="new" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                TabIndex="13" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick="return validate_Supplier(event)"
                                TabIndex="10" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                                OnClientClick="return validate_Supplier(event)" TabIndex="10" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'BOND MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" TabIndex="11" />
                            <asp:Button ID="btn" runat="server" TabIndex="15" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <%--onclick="parent.adcodewindow.hide()"--%>
                            <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                                tabindex="12" id="btnCancel" />
                            <asp:HiddenField ID="hdn_Update_SupName" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="Hdn_RITC_4_digit" runat="server" />
                            <asp:HiddenField ID="Get_STR" runat="server" />
                        </div>
                    </div>
                </div>
                  <div id="tag_transac_lft_Item_reimport_Grid_area" style="height: 150px; width: 430px">
                            <asp:GridView ID="gv_Details" runat="server" EmptyDataText="NO RECORD FOUND" DataKeyNames="ID"
                                AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                ShowHeaderWhenEmpty="True" OnRowDataBound="gv_Details_RowDataBound" OnPageIndexChanging="gv_Details_PageIndexChanging"
                                OnSelectedIndexChanged="gv_Details_SelectedIndexChanged" PageSize="12" AllowPaging="True"
                                AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                CellPadding="1" CellSpacing="1" OnRowCreated="gv_Details_RowCreated">
                                   <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                    BorderWidth="1px" />
                                     <HeaderStyle  Font-Underline="false" ForeColor="Black"   />
                                <Columns>
                                <%-- <asp:CommandField ShowSelectButton="True">
                                      <HeaderStyle CssClass="hideGridColumn" />
                                      <ItemStyle CssClass="hideGridColumn" />
                                  </asp:CommandField>--%>
                                   <asp:BoundField DataField="BOND_NO" HeaderText="BOND_NO" >
                                     <ItemStyle CssClass="column_style_left" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_DATE" HeaderText="DATE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <%--<asp:BoundField DataField="BOND_LOCATION" HeaderText="LOCATION">
                                       <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>--%>
                                     <asp:BoundField DataField="BOND_AMT" HeaderText="BOND AMT">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_TYPE" HeaderText="BOND_TYPE">
                                        <ItemStyle CssClass="column_style_left" />
                                    </asp:BoundField>
                                   <%-- <asp:BoundField DataField="REMAINING_AMT" HeaderText="BOND_TYPE">
                                        <HeaderStyle CssClass="hideGridColumn" />
                                      <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BOND_REMARKS" HeaderText="BOND_TYPE">
                                       <HeaderStyle CssClass="hideGridColumn" />
                                      <ItemStyle CssClass="hideGridColumn" />
                                    </asp:BoundField>--%>
                                    
                                </Columns>
                            </asp:GridView>
                        </div>
            </div>
           
           
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/Import_Jscript/Import_Bond.js" type="text/javascript"></script>
   
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
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
    </script>
    <script type="text/javascript">

        $(function () {
            $("#txtBondLocation").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List_NEW",
                        data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + '' + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtBondLocation').validationEngine('showPrompt', 'Incorrect Bond Location', 'error', 'topRight', true);

                                //jAlert('Bond Location is Incorrect', 'BOND', function (r) { document.getElementById("txtBondLocation").focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtBondLocation').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

                 function Bond_aval_amt() {
                     var bond_no = document.getElementById("txtBondNo").value;
                     var bond_location = document.getElementById("txtBondLocation").value;
                     var bond_type = document.getElementById("ddlBondType").value;
                     if (bond_no != "" && bond_location != "" && bond_type != "") {

                         PageMethods.GET_BOND_AVAILE_AMT(bond_no, bond_location, bond_type,
                function (result) {
                    document.getElementById('<%= txt_avail.ClientID %>').value = result;
                },
            function (error) {
                alert("Error: " + error.get_message());
            });
                     }

                 }

    </script>





</body>
</html>
