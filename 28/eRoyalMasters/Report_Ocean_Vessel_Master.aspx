<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_Ocean_Vessel_Master.aspx.cs"
    Inherits="Report_Ocean_Vessel_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Consignee Master | Updation</title>
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

           
                <div id="innerbox_MidMain_popup_adcode"  style="height:100px">
                    <div id="innerbox_MidMain_top_adcode">
                        Report Ocean Vessel
                        <div id="popupwindow_closebut_right">
                            <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />
                        </div>
                    </div>
            

                  <div id="innerbox_MidMain_Mid_adcode" style="height:80px">
                  <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Ocean Vessel</div>
                        <div id="txtcon-m_Maxtxt">
                            <asp:TextBox ID="txt_OceanVessel" runat="server" MaxLength="200" TextMode="MultiLine"
                                CssClass="txtbox_none_Maxtxt_Client" onkeyDown="return checkTextAreaMaxLength(this,event,'200');"
                                onpaste="return checkTextAreaMaxLength(this,event,'200');" TabIndex="13" 
                               ></asp:TextBox>
                        </div>
                    </div>
                    </div>
                    </div>

                  <div id="innerbox_MidMain_top_ClientMaster">
                    <div id="innerbox_ClientMaster_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" CausesValidation="false"
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                TabIndex="20" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate_Client();"
                                TabIndex="17" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate_Client();" TabIndex="17" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="18" OnClientClick="jConfirm('Delete this Entry?', 'CLIENT MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" CssClass="dlete" />
                            <asp:Button ID="btn" runat="server" TabIndex="15" OnClick="btnDelete_Click" CssClass="dlete"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                                tabindex="19" id="btnCancel" />
                            <asp:HiddenField ID="hdn_id" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                             <asp:HiddenField ID="hdn_Update_Consignee_Name" runat="server" />
                            <asp:HiddenField ID="HiddenField2" runat="server" />
                            <asp:HiddenField ID="HiddenField3" runat="server" />
                            <asp:HiddenField ID="Hdn_check_result" runat="server" />

                        </div>
                    </div>
                </div>
               
             </div>
         </div>

        <%-- </div>--%>
          
           <%-- </div>--%>

            <%--  ********************** GRID PART ****************** --%>

             
                   <div id="tag_transac_exp_drawback_1" runat="server" style="overflow:scroll; width:450px; height:250px;">

                             <asp:GridView ID="gv_Expense" runat="server" DataKeyNames="RPT_ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                    ShowHeaderWhenEmpty="True"  AllowPaging="True" 
                                    OnRowDataBound="gv_Expense_RowDataBound"
                                    OnPageIndexChanging="gv_Expense_PageIndexChanging"  OnSelectedIndexChanged="gv_Expense_SelectedIndexChanged"
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="1" CellSpacing="1" OnRowCreated="gv_Expense_RowCreated">
                                   <%-- <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                                        BorderWidth="1px" />--%>
                                    <Columns>
                                       <%-- <asp:CommandField ShowSelectButton="True">
                                            <HeaderStyle CssClass="hideGridColumn" />
                                            <ItemStyle CssClass="hideGridColumn" />
                                        </asp:CommandField>--%>
                                        <asp:TemplateField HeaderText="S.No" ControlStyle-Width="70px">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                  
                                        <asp:BoundField DataField="OCEANVESSEL" HeaderText="Ocean Vessel" ControlStyle-Width="800px">
                                         <ItemStyle CssClass="column_style_left" Width="800px" />
                                        </asp:BoundField>   

                                       <%-- <asp:BoundField DataField="REMARKS">
                                             <HeaderStyle CssClass="hideGridColumn" />
                                        <ItemStyle CssClass="hideGridColumn" />
                                        </asp:BoundField>--%>


                                       
                                    </Columns>
                                    <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />
                                     <PagerStyle CssClass="pager" />--%>
                                    <EmptyDataTemplate>
                                        NO RECORD FOUND
                                    </EmptyDataTemplate>
                                </asp:GridView>
                        </div>
                        
                <%-- </div>--%>
                  
            
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
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

        $(function () {
            $("#txtCountryName").autocomplete({
                source: function (request, response) {
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
                                jQuery('#txtCountryName').validationEngine('showPrompt', 'Incorrect Country Name', 'error', 'topRight', true);

                                //jAlert('Country Name is Incorrect', 'CONSIGNEE MASTER', function (r) { document.getElementById('txtCountryName').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtCountryName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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


        $(document).ready(function () {
            $('#txtCountryName').focus(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryName').change(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryName').keyup(function () {

                var data = $(this).val();
                country(data);

            });
            $('#txtCountryName').keydown(function () {

                var data = $(this).val();
                country(data);

            });
        });

        function country(val) {

            var data = val;
            if (data == '') {
                $('#txtCountryCode').val('');
            }
            //$('#hdn_Autosearch').val(data);

            if (data.indexOf("-") != -1) {


                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtCountryCode').val(after);
                $('#txtCountryName').val(before);

            }
            else {

            }
        }

        function CallMe(src, dest) {
            var ctrl = document.getElementById(src);
            // call server side method
            //alert('l');
            PageMethods.GetCountry_code(ctrl.value, CallSuccess, CallFailed, dest);

        }
        // set the destination textbox value with the ContactName
        function CallSuccess(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            dest.value = res;
        }
        // alert message on some failure
        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }

    </script>
</body>
</html>
