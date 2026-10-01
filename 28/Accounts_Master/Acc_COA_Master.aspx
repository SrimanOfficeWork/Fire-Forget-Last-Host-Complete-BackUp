<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_COA_Master.aspx.cs" Inherits="Acc_COA_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>COA Master | Updation</title>
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
    <style type="text/css">
        fieldset
        {
            font-family: sans-serif;
            padding: 10px;
        }
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtGSTN_ID').keyup(function () {

                var a = $('#txtGSTN_ID').val();
                var Update_Val = document.getElementById("hdn_checkVal").value;

                if (Update_Val == 'New') {
                    var a = $('#txtGSTN_ID').val();
                    $('#txtCommercial_RegistrationNo').val(a);
                }
                else {

                }
            });
        });
     
    </script>

</head>
<body style="background-color: white; overflow: hidden;" onload="window.parent.parent.scrollTo(0,0);">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>

            <div id="innerbox_MidMain_Transact_popup_new" style="height:30px;width:1015px">
            <div id="tag_srcinner1_new">
                    <div id="editbu">
                        <a href="#" class="edit"></a>
                    </div>
                    <div id="mainmastop2container_rght_tag2_txt1">
                      COA Master
                    </div>
                    <div id="popupwindow_closebut_right_new">
                        <input type="close" value="Submit" CausesValidation="false" class="clsicon_new" onclick="win_hide();parent.adcodewindow.hide();return false;" />
                    </div>
                </div>
            </div>

            <div id="innerbox_MidMain_Trans_IGM" style="width:1015px; height:348px;">
                <ol id="toc">
                    <li style="height: 20px"><a href="#page-1" onclick="tab_page1('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="IGM"><span>General </span></a></li>
                  <li style="height: 20px"><a href="#page-2" onclick="tab_page2('0'); jQuery('#form1').validationEngine('hideAll')"
                        id="CONTAINER" runat="server" visible="false"><span> Billing Party</span></a></li>
                </ol>
                <div class="content" id="page-1">
                    <div id="innerbox_MidMain_popup_ClientMaster" style="height: 300px; width: 1012px;
                        margin-left: -15px; background-color: White;">
                        <div id="innerbox_MidMain_Mid_ClientMaster" style="height: 298px; width: 1012px;">
                            <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_Item" style="height: 135px;
                                width: 1010px;">
                                <div style="margin-left: 10px;">
                                    <div id="tag_transac_lft_trans_item_maindet_in1_">
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 1005px;">
                                        <div id="tag_label_transaction_export_Item_otherdet_new1">
                                            Name
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width: 500px">
                                            <asp:TextBox ID="txtCharge_Name" runat="server" Width="480px" MaxLength="300" TabIndex="3"
                                                CssClass="validate[required] txtbox_none"></asp:TextBox>
                                        </div>
                                    </div>
                                     <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 1005px;"></div>

                                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 1005px;">
                                        <div id="tag_label_transaction_export_Item_otherdet_new1">
                                            COA Type <span style="color: Red;">*</span>
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width: 300px">

                                             <asp:DropDownList ID="ddl_COA_Type" runat="server" class="chosen-select-deselect"
                                             Style="width: 200px;" data-placeholder="Choose a COA Type"  TabIndex="5" >
                                             </asp:DropDownList>

                                        </div>
                                        <div id="tag_label_transaction_export_Item_otherdet_new1">
                                            COA Category <span style="color: Red;">*</span>
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width: 300px">
                                            <asp:DropDownList ID="ddl_COA_Cat" runat="server" class="chosen-select-deselect"
                                             Style="width: 290px;" data-placeholder="Choose a COA Category"  TabIndex="8" >
                                             </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 1005px;"></div>
                                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 1005px;">
                                        <div id="tag_label_transaction_export_Item_otherdet_new1">
                                            COA Group <span style="color: Red;">*</span>
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width: 300px">
                                            <asp:DropDownList ID="ddl_COA_Group" runat="server" class="chosen-select-deselect"
                                             Style="width: 290px;" data-placeholder="Choose a COA Group"  TabIndex="9" >
                                             </asp:DropDownList>

                                        </div>
                                        <div id="tag_label_transaction_export_Item_otherdet_new1">
                                            COA Subgroup
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width: 300px">
                                           <asp:DropDownList ID="ddl_COA_Sup_Group" runat="server" class="chosen-select-deselect"
                                            Style="width: 290px;" data-placeholder="Choose a COA Group"  TabIndex="10" >
                                           </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 1005px;"></div>
                                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 1005px;">
                                        <div id="tag_label_transaction_export_Item_otherdet_new1">
                                            Description
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width: 500px">
                                            <asp:TextBox ID="txtCharge_Desc" runat="server" Width="480px" MaxLength="300" TabIndex="11"
                                                CssClass="txtbox_none"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 1005px;">
                                        <div id="tag_label_transaction_export_Item_otherdet_new1">
                                            Remarks
                                        </div>
                                        <div id="txtcon-m_transaction_item_maindet" style="width: 500px">
                                            <asp:TextBox ID="txt_Remarks" runat="server" Width="480px" MaxLength="300" TabIndex="12"
                                                CssClass="txtbox_none"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            
                            <%--------------------------------------------------%>
                        </div>
                    </div>



                        <div id="innerbox_MidMain_Mid_ClientMaster">
                            <div id="innerbox_ClientMaster_bot_inn">
                                <div id="newbu">
                                    <asp:Button ID="btnNew" runat="server" CssClass="new" OnClick="btnNew_Click" CausesValidation="false"
                                        UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                        TabIndex="54" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click" OnClientClick="return validate_Client();"
                                        TabIndex="50" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                        OnClientClick="return validate_Client();" TabIndex="51" />
                                </div>
                                <div id="editbu">
                                    <asp:Button ID="btnDelete" runat="server" TabIndex="52" OnClientClick="jConfirm('Delete this Entry?', 'CHARGE MASTER', function(r) {
                                          var i = r + 'ok';
                                          if(i == 'trueok')
                                          {
                                              document.getElementById('btn').click();
                                          }
                                          else {
                                          }
                                         });return false;" CssClass="dlete" />
                                    <asp:Button ID="btn" runat="server" TabIndex="52" OnClick="btnDelete_Click" CssClass="dlete"
                                        Style="display: none;" />
                                </div>
                                <div id="editbu">
                                    <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;" tabindex="53" id="btnCancel" />
                                        
                                    <asp:HiddenField ID="HDupdate_id" runat="server" />
                                </div>
                            </div>
                            </div>
                    </div>
                </div>
                <div class="content" id="page-2">
                    <iframe src="" name="trans_igm_container" style="width:910px; height:400px;" scrolling="no" id="trans_ETP_Container_iframe">
                    </iframe>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

     <script src="../activatables.js" type="text/javascript"></script>
    <script type="text/javascript">
        activatables('page', ['page-1', 'page-2']);
    </script>

    </form>
     <script src="../js/Export_Jscript/Export_ETP.js" type="text/javascript"></script> 

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
    
     <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
     <script type="text/javascript" src="../js/eRoyalmaster_Jscript/Client_Master.js"></script>
     <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
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
