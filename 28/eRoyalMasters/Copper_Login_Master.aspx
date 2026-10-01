<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copper_Login_Master.aspx.cs"
    Inherits="eRoyalMasters_Copper_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Copper Master | Updation</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../main.css" rel="stylesheet" type="text/css" media="screen, projection" />
    <link href="../AutoComplete_CSS/jquery-ui.css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        
       .pop_text_area_transac_popup_inn_container_Copper_Bond2_grid{
            margin:auto;
            width:770px;
            height:190px;/*300*/
            background-color: #ffffff;
            overflow:scroll;
            border: solid #c8c8c8 thin;
            float:left;
            float:left;

           }  
        
          .hideGridColumn
        {
            display: none;
        }
        /* Autocomplete Textbox Search Loading Image*/
      /*  .ui-autocomplete-loading
        {
            background: white url('../images/ui-anim_basic_16x16.gif') right center no-repeat;
        } */
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
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_adcode" style="height: 415px">
                <div id="innerbox_MidMain_top_adcode">
                    COPPER MASTER
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode">
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            EROYAL CID</div>
                        <asp:TextBox ID="txtCID_Code" runat="server" TabIndex="1" MaxLength="10" Style="margin-left: 30px">
                        </asp:TextBox>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            COPPER URL</div>
                        <asp:TextBox ID="Copper_url" runat="server" TabIndex="1" Style="margin-left: 30px">
                        </asp:TextBox>
                       
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            USER NAME</div>
                        <asp:TextBox ID="User_Name" runat="server" TabIndex="1" Style="margin-left: 30px">
                        </asp:TextBox>
                        
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            PASSWORD
                        </div>
                        <asp:TextBox ID="Copp_Pass" runat="server" TabIndex="1" Style="margin-left: 30px">
                        </asp:TextBox>
                       
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            COPPER CID
                        </div>
                        <asp:TextBox ID="Copp_CID" runat="server" TabIndex="1" Style="margin-left: 30px">
                        </asp:TextBox>
                        
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            COPPER BRANCH</div>
                        <asp:TextBox ID="Copp_branch" runat="server" TabIndex="1" Style="margin-left: 30px">
                        </asp:TextBox>
                        
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            COPPER FY</div>
                        <asp:TextBox ID="Copp_fy" runat="server" TabIndex="1" Style="margin-left: 30px">
                        </asp:TextBox>
                       
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            COPPER BID</div>
                        <asp:TextBox ID="Copp_BID" runat="server" TabIndex="1" Style="margin-left: 30px">
                        </asp:TextBox>
                        
                    </div>
                    <div id="lblMsg2" style="display: none;">
                    </div>
                    <div id="innerbox_MidMain_top_adcode" style="margin-top: 15px">
                        <div id="innerbox_adcode_bot_inn">
                            <div id="newbu">
                                <asp:Button ID="btnNew" runat="server" OnClick="btnNew_Click" CausesValidation="false"
                                    UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                                    CssClass="new" TabIndex="17" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" OnClientClick=" return validate_Adcode();"
                                    TabIndex="14" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click" OnClientClick="return validate_Adcode();"
                                    TabIndex="14" />
                            </div>
                            <div id="editbu">
                                <asp:Button ID="btnDelete" runat="server" Visible="false" TabIndex="15" CssClass="dlete"  OnClientClick="jConfirm('Delete this Entry?', 'COPPER MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                                <asp:Button ID="btn" runat="server" TabIndex="27" CausesValidation="false" UseSubmitBehavior="false"
                                        OnClientClick="jQuery('#form1').validationEngine('hideAll');" OnClick="btnDelete_Click"
                                        CssClass="dlete" Style="display: none;" />
                            </div>       
                             <div id="editbu">
                                <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                                    tabindex="16" id="btnCancel" onclick="return btnCancel_onclick()" />
                                <br />
                                &nbsp;<asp:HiddenField ID="hdn_Update_Adcode" runat="server" />
                                <asp:HiddenField ID="hdn_check_adcode" runat="server" />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <asp:HiddenField ID="hdn_new_update" runat="server" />
                                <asp:HiddenField ID="hdn_Update_Val" runat="server" />
                                <asp:HiddenField ID="Hdn_STANDARD_TYPE" runat="server" />
                            </div>
                        </div>
                        &nbsp;</div>
                    <div id="pop_text_area_transac_popup_inn_container_Copper_Bond2_grid" style="width: 430px;
                        overflow: auto; height: 170px; border: 1px solid #c8c8c8;">
                        <asp:GridView ID="gv_BOND" runat="server" DataKeyNames="ID_TBL" EmptyDataText="NO RECORD FOUND"
                        AutoGenerateColumns="False" BackColor="WhiteSmoke" CssClass="grid-view" Width="430px"
                        ShowHeaderWhenEmpty="True"  OnRowDataBound="gv_BOND_RowDataBound"
                        OnPageIndexChanging="gv_BOND_PageIndexChanging" OnSelectedIndexChanged="gv_BOND_SelectedIndexChanged"
                        AllowSorting="True" BorderColor="#C8C8C8" BorderStyle="Solid" BorderWidth="1px"
                        CellPadding="1" CellSpacing="1" OnRowCreated="gv_BOND_RowCreated">
                        <AlternatingRowStyle BackColor="White" BorderColor="#C8C8C8" BorderStyle="Solid"
                            BorderWidth="1px" />
                        <Columns>
                   

                            <asp:CommandField ShowSelectButton="True">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:CommandField>
                            <asp:BoundField DataField="EROYAL_CID" HeaderText="EROYAL CID" ControlStyle-Width="70px">
                                <ItemStyle Width="70px" CssClass="column_style_left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COPPER_URL" >
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COPPER_USER_NAME" HeaderText="COPPER USER NAME">
                                <HeaderStyle CssClass="hideGridColumn" />
                                <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                            <asp:BoundField DataField="COPPER_PASSWORD" >
                                <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" /> 
                            </asp:BoundField>
                            <asp:BoundField DataField="COPPER_CID" HeaderText="COPPER CID" ControlStyle-Width="70px">
                                <ItemStyle  Width="70px"  CssClass="column_style_left"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="COPPER_BRANCH" HeaderText="COPPER BRANCH" ControlStyle-Width="50px"  >
                                 <ItemStyle CssClass="column_style_left" />
                            </asp:BoundField>
                             <asp:BoundField DataField="BRANCH_CODE">
                                <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                              <asp:BoundField DataField="COPPER_FY">
                                <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
                            </asp:BoundField>
                              <asp:BoundField DataField="COPPER_BID" >
                                <HeaderStyle CssClass="hideGridColumn" />
                                 <ItemStyle CssClass="hideGridColumn" />
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
                </div>
            </div>

              <asp:HiddenField ID="hdn_Grid_Disable" runat="server" />
            <asp:HiddenField ID="hdn_update_Bond" runat="server" />
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

        function btnCancel_onclick() {

        }

    </script>
</body>
</html>
