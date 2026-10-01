<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EGM_Vessel_Master.aspx.cs" Inherits="EGM_Liner_Vessel_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Liner Master | Updation</title>
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
     <script src="../js/EGM/EGM_General.js" type="text/javascript"></script>

     

</head>
<body style="background: #f2f2f2; overflow: hidden;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
           
            <div id="innerbox_MidMain_popup_adcode" style="height:385px">
                <div id="innerbox_MidMain_top_adcode">
                   VESSEL MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                  <div id="innerbox_MidMain_Mid_adcode" style="height:100px" >
                    <div id="innerbox_MidMain_Mid_ClientMaster_l" style="height:100px">
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                  Vessel Code  </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtVeeselcode" runat="server" CssClass="txtbox_none" TabIndex="1"
                                    Onkeypress="return numchar(event)" MaxLength="40" Width="215px"></asp:TextBox>
                            </div>
                        </div>
                        <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                Vessel Name  </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txtVeeselName" runat="server" CssClass="validate[required] txtbox_none" TabIndex="2"
                                    Onkeypress="return numchar(event)" MaxLength="50"></asp:TextBox></div>
                        </div>
                         <div id="pop_text_area">
                            <div id="tag_label_adcode">
                                IMO Code  </div>
                            <div id="txtcon-m_src">
                                <asp:TextBox ID="txt_IMOCode" runat="server" CssClass="validate[required] txtbox_none" TabIndex="2"
                                    MaxLength="400"></asp:TextBox></div>
                        </div>
                    </div>
                     
            </div>
            <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="5" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" 
                            TabIndex="3" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            TabIndex="3" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="4" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'EGM MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="4" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu">
                    <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                            tabindex="6" id="btnCancel" />
                        <%--<input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                            tabindex="6" id="btnCancel" onclick="return btnCancel_onclick()" />--%>
                        <br />
                        &nbsp;<asp:HiddenField ID="hdn_EGM_Type" runat="server" />
                        <asp:HiddenField ID="hdn_check_adcode" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="hdn_new_update" runat="server" />
                        <asp:HiddenField ID="hdn_id" runat="server" />
                        <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" />

                    </div>
                </div>
                &nbsp;</div>

                <div id="tag_transac_exp_drawback_1" runat="server" style="overflow:scroll; width:440px; height:220px; margin-top:10px;">

                             <asp:GridView ID="gv_Expense" runat="server" DataKeyNames="ID" EmptyDataText="NO RECORD FOUND"
                                    AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="100%"
                                    ShowHeaderWhenEmpty="True"  AllowPaging="True"  PageSize="100"
                                    OnRowDataBound="gv_Expense_RowDataBound"
                                    OnSelectedIndexChanged="gv_Expense_SelectedIndexChanged"
                                    AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                                    CellPadding="1" CellSpacing="1" OnRowCreated="gv_Expense_RowCreated">

                                    <Columns>

                                      <asp:TemplateField HeaderText="S.No" ControlStyle-Width="20px">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--<asp:BoundField DataField="CODE" HeaderText="Vessel Code" ControlStyle-Width="100px">
                                         <ItemStyle CssClass="column_style_left" Width="100px" />
                                        </asp:BoundField> --%>  

                                        <asp:BoundField DataField="NAME" HeaderText="Vessel Name" ControlStyle-Width="200px">
                                            <ItemStyle CssClass="column_style_left" Width="200px" />
                                        </asp:BoundField>   

                                        <asp:BoundField DataField="IMO_CODE" HeaderText="IMO Code" ControlStyle-Width="100px">
                                         <ItemStyle CssClass="column_style_left" Width="100px" />
                                        </asp:BoundField> 
                                    </Columns>
                                    <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast"
                                    NextPageText="Next" Position="Top" PreviousPageText="Previous" />--%>
                                     <PagerStyle CssClass="pager" />
                                    <EmptyDataTemplate>
                                        NO RECORD FOUND
                                    </EmptyDataTemplate>
                                </asp:GridView>
                        </div>
            
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
//        $(window).bind("load", function () {
//            $('#load').hide(); ;
//        });
      
        jQuery(document).ready(function () {

            jQuery("#form1").validationEngine();
        });


        function checkHELLO(field, rules, i, options) {
            if (field.val() != "HELLO") {

                return options.allrules.validate2fields.alertText;
            }
        }

        $(function () {
            $("#txtStateName").autocomplete({
                source: function (request, response) {
                    var errorField = $(this.element).attr('id');
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


                                jQuery('#txtStateName').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);
                                //jAlert('State Name is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtStateName').focus(); });
                                //return false;
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

            $("#txtIec_Code").autocomplete({

                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_IECCode_NAME_List",
                        //                        data: "{ 'mail': '" + request.term + "' ,'IEC':''}",
                        data: "{ 'mail': '" + request.term + "' ,'IEC':'','Type':'" + document.getElementById('Hdn_STANDARD_TYPE').value + "'}",
                        
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);

                            if (data.d == '') {
                                jQuery('#txtIec_Code').validationEngine('showPrompt', 'Incorrect IEC Code', 'error', 'topRight', true);
                                //jAlert('IEC Code is Incorrect', 'ADCODE MASTER', function (r) { document.getElementById('txtIec_Code').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtIec_Code').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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

function btnCancel_onclick() {

}

    </script>

    
  <script type="text/javascript">
      $(document).ready(function () {

          $('#txtIec_Code').focus(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txtIec_Code').change(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txtIec_Code').keyup(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
          $('#txtIec_Code').keydown(function () {

              var data1 = $(this).val();
              Item_desc1(data1);

          });
      });

      function Item_desc1(val) {

          var data1 = val;
          if (data1 == '') {
              $('#txtIec_Code').val('');
          }
          if (data1.indexOf(" -") != -1) {

              var s = data1.split(' -');

              var before = s[0];
              var after = s[1];

              $('#txtIec_Code').val(before);
              $('#txtIec_Name').val(after);
          }
          else {

          }
      }
  </script>
</body>
</html>
