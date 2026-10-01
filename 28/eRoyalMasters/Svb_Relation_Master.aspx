<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Svb_Relation_Master.aspx.cs" Inherits="eRoyalMasters_Svb_Relation_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SVB Relation Master | Updation</title>
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
<body style="background: #f2f2f2; overflow: hidden;" onload="window.parent.parent.scrollTo(0,0);">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="false"
        LoadScriptsBeforeUI="false" EnablePageMethods="true">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
            <div id="innerbox_MidMain_popup_svb_Master">
                <div id="innerbox_MidMain_top_svb_Master">
                    <div id="innerbox_MidMain_top_svb_relation">
                        SVB RELATION MASTER
                        <div id="popupwindow_closebut_right">
                            <asp:Button ID="btnClose" runat="server" CssClass="clsicon_new" OnClientClick="RefreshParent();return false;"
                                CausesValidation="false" UseSubmitBehavior="false" />
                            <%--         <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();return false;" />--%>
                        </div>
                    </div>
                  
                  
                </div>
                <div id="innerbox_MidMain_Mid_Svb_RelationMaster" style="height:390px;">
                    <div id="pop_text_area_transac_popup_inn_svb_relation" style="height:340px;">
                        <div id="tag_transac_lft_svb_relation_in1">
                            <div id="tag_label_Clientname">
                                Importer
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                <asp:TextBox ID="txtimpexpname" runat="server" MaxLength="100" 
                                      onblur="ChangeCase(this);"
                                      ClientIDMode="Static"
                                       CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"
                                       Onkeypress="return numcharspl1(event)"
                                    TabIndex="1"  ></asp:TextBox>                          
                                                
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                              <div id="magnify_area">
                                <%--<a href="#"class="magnfy" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporter_Master(''); return false"></a>--%>

                                  <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupImporterDetails('SVB'); return false"
                                    class="magnfy"></a>
                                

                               <%-- <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('SVB'); return false"
                                    class="magnfy"></a>--%>
                            </div>
                        </div>
                        <div id="tag_transac_lft_svb_relation_in1">
                            <div id="tag_label_Clientname">
                                 Supplier
                            </div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                <asp:TextBox ID="txtsup_name" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big" ClientIDMode="Static"
                                    TabIndex="3" Onkeypress="return numcharspl1(event)" 
                                    ></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                              <div id="magnify_area">
                               
                                     <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupSupplier('SVB'); return false"
                                    class="magnfy"></a>
                            </div>
                        </div>
                        <div id="tag_transac_lft_svb_relation_in1">
                            <div id="tag_label_Clientname">
                                Relation
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                <asp:TextBox ID="txtRelation" runat="server" MaxLength="100" TabIndex="5" CssClass="validate[required] txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="tag_transac_lft_svb_relation_in1">
                            <div id="tag_label_Clientname">
                                Base
                            </div>
                           
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                <asp:TextBox ID="txtBase" runat="server" MaxLength="100" TabIndex="6" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                        <div id="tag_transac_lft_svb_relation_in1">
                            <div id="tag_label_Clientname">
                                Condition</div>
                            
                            <div id="txtcon-m_transaction_pop_gen1_srcic_new_add_big">
                                <asp:TextBox ID="txtCondition" runat="server" MaxLength="100" CssClass="txtbox_none_Mid_transac_pop_gen_srcic_new_add_big" TabIndex="7"
                                    onkeypress="return city1(event)"></asp:TextBox>
                            </div>
                            <div id="txtcon-r_src">
                            </div>
                        </div>
                                            
                       
                    <div id="tag_transac_lft_svb_relation_in1">
                        <div id="tag_label_transaction_MIS_empty1">
                            <asp:CheckBox ID="chkSVB_Relation" runat="server" TabIndex="8"></asp:CheckBox></div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="pop_text_area_transac_MIS_InnTitle1_chkbox" style="width:225px;">
                            SVB Relation
                        </div>

                        <div id="tag_label_transaction_MIS_empty1">
                            <asp:CheckBox ID="chkSVB_All_Suppliers" runat="server" TabIndex="8"></asp:CheckBox></div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="pop_text_area_transac_MIS_InnTitle1_chkbox">
                            SVB Applicable for All Suppliers
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            SVB Ref No
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                            <asp:TextBox ID="txtSVB_RefNo" runat="server" MaxLength="20" 
                                onkeyup="autotab(this);" CssClass="validate[required] txtbox_none_Mid_transac_Supp_Name"
                                Enabled="false" TabIndex="9"></asp:TextBox>
                        </div>
                        <%-- -------------------%>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM2_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Date</div>
                        <div id="txtcon-m_transaction_SVB_Date">
                            <%--txtcon-m_transaction_SVB_Date--%>
                            <asp:TextBox ID="txtSVBDate" runat="server" Width="95px" TabIndex="10" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                Enabled="False"></asp:TextBox>
                          
                             <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtSVBDate"
                                Mask="99/99/9999" MessageValidatorTip="true" OnInvalidCssClass="MaskedEditError"
                                MaskType="Date" DisplayMoney="Left" AcceptNegative="Left" ErrorTooltipEnabled="True">
                            </cc1:MaskedEditExtender>
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtSVBDate"
                                Format="dd/MM/yyyy">
                            </cc1:CalendarExtender>

                            <%-- <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RegularExpressionValidator5" PopupPosition="Right" ></asp:ValidatorCalloutExtender>
                   
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ForeColor="Red" Display="None"
                            runat="server" ControlToValidate="txtDate" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d$"
                            ErrorMessage="Invalid Date"></asp:RegularExpressionValidator>
                            --%>
                        </div>
                        <%-- -------------------%>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            SVB Custom House
                        </div>
                        <div id="txtcon-m_transaction_Supp_code">
                     
                                  <asp:TextBox ID="txtCustomsHouse" runat="server" TabIndex="11" CssClass="txtbox_none_Mid_transac_Supp_Name"
                                ClientIDMode="Static" ></asp:TextBox>
                                
                        </div>
                        <div id="magnify_area">
                              <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCustom_House_Details('SVB'); return false"
                                    class="magnfy"></a>
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Loading On
                        </div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlLoadingOn" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="12">
                               
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div id="tag_transac_lft_svb_relation_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Assessable Rate
                        </div>
                        <div id="txtcon-m_transaction_SVB_Rate">
                            <asp:TextBox ID="txtAssesable_Rate" runat="server" onkeypress="return numdot1(event)"
                                onkeyup="autotab(this);" CssClass="validate[custom[number]] txtbox_none_Mid_transac_SVB_Rate"
                                Enabled="false" MaxLength="6" TabIndex="13"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_SVB_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Status</div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlAssesable_Status" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="14">
                                <%-- <asp:ListItem>P</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                   <div id="tag_transac_lft_svb_relation_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Duty Rate
                        </div>
                        <div id="txtcon-m_transaction_SVB_Rate">
                            <asp:TextBox ID="txtDuty_Rate" runat="server" onkeypress="return numdot1(event)"
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_SVB_Rate" Enabled="false"
                                MaxLength="6" TabIndex="15"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_SVB_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Status</div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                            <asp:DropDownList ID="ddlDuty_Status" CssClass="listtxt_transac_LoadingOn" runat="server"
                                Enabled="false" TabIndex="16">
                                <%--  <asp:ListItem>P</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                    </div>
                 
                <div id="tag_transac_lft_svb_relation_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Bond No
                        </div>
                        <div id="txtcon-m_transaction_SVB_Rate">
                            <asp:TextBox ID="txtBond_No" runat="server" onkeypress="return numdot1(event)"
                                CssClass="validate[custom[number]] txtbox_none_Mid_transac_SVB_Rate" Enabled="false"
                                MaxLength="10" TabIndex="17"></asp:TextBox>
                        </div>
                        <div id="tag_label_transaction_popup_Invoice_SVB_empty">
                        </div>
                        <div id="tag_label_transaction_popup_IGM_Container_SVB">
                            Location</div>
                        <div id="txtcon-m_transaction_list1_LoadingOn">
                         <asp:TextBox ID="txtBondLocation" runat="server" 
                                CssClass="txtbox_none_Mid_transac_SVB_Rate" Enabled="false"
                                MaxLength="6" TabIndex="18"></asp:TextBox>
                            
                        </div>
                        <div id="magnify_area">
                                    <a href="#" onclick="jQuery('#form1').validationEngine('hideAll');OpenPopupCustom_House_Details('BOND_LOCATION'); return false"
                                    class="magnfy"></a>
                        </div>
                    </div>

                    <div id="tag_transac_lft_svb_relation_in1">
                        <div id="tag_label_transaction_popup_IGM_invoice_SVB">
                            Bond Type
                        </div>
                        <div id="txtcon-m_transaction_SVB_Rate">
                           <asp:DropDownList ID="ddlBondType" CssClass="listtxt_transac_LoadingOn" runat="server" Enabled="false" TabIndex="19">
                                <%--  <asp:ListItem>P</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>--%>
                            </asp:DropDownList>
                        </div>
                        </div>
                       
                    
                </div>
                <div id="innerbox_MidMain_top_svb_Master">
                    <div id="innerbox_ClientMaster_bot_inn">
                        <div id="newbu">
                            <asp:Button ID="btnNew" runat="server" CssClass="new" CausesValidation="false"   OnClick="btnNew_Click" 
                                UseSubmitBehavior="false" OnClientClick="jQuery('#form1').validationEngine('hide')"
                                TabIndex="23" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnSave" runat="server" CssClass="save" OnClick="btnSave_Click"  OnClientClick="return validate_Client();"
                                TabIndex="20" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnUpdate" runat="server" CssClass="updates" OnClick="btnUpdate_Click"
                                OnClientClick="return validate_Client();" TabIndex="21" />
                        </div>
                        <div id="editbu">
                            <asp:Button ID="btnDelete" runat="server" TabIndex="22" OnClientClick="jConfirm('Delete this Entry?', 'SVB RELATION MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" CssClass="dlete" />
                            <asp:Button ID="btn" runat="server" TabIndex="15"  CssClass="dlete" OnClick="btnDelete_Click"
                                Style="display: none;" />
                        </div>
                        <div id="editbu">
                            <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                                tabindex="24" id="btnCancel" />
                            <asp:HiddenField ID="hdn_id" runat="server" />
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <asp:HiddenField ID="hdfTransport_mode" runat="server" />
                            
                        </div>
                    </div>
                </div>
            </div>
            </div> 
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    <script src="../js/listpopup.js" type="text/javascript"></script>
    <script src="../js/Import_Jscript/Import_Bond.js" type="text/javascript"></script>

    <script src="../js/Validation.js" type="text/javascript"></script>
    <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script src="../js/eRoyalmaster_Jscript/Svb_Relation.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery.min.js" type="text/javascript"></script>
    <script src="../AutoComplete_JS/jquery-ui.min.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->
    <script src="../Validation Files/jquery_002.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation Files/jquery.js" type="text/javascript" charset="utf-8">
    </script>
    <script src="../Validation%20Files/Ascii.js" type="text/javascript"></script>
    <!-- VALIDATION SCRIPT -->

    <script src="../js/eRoyalmaster_Jscript/eRoyalMasters.js" type="text/javascript"></script>

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
            $("#txtCustomsHouse").autocomplete({

                source: function (request, response) {

                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Custom_House_List",
                        data: "{ 'mail': '" + request.term + "' ,'Trans_port':'" + document.getElementById("hdfTransport_mode").value + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtCustomsHouse').validationEngine('showPrompt', 'Invalid Port Code', 'error', 'topRight', true);
                            }

                            else {
                                jQuery('#txtCustomsHouse').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                            }
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                        }
                    });
                },
                minLength: 1

            });
            return false;
            scroll: true;

        });




        $(function () {
            $("#txtStateName").autocomplete({
                source: function (request, response) {
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
                                //jAlert('State Name is Incorrect', 'CLIENT MASTER', function (r) { document.getElementById('txtStateName').focus(); });
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

        function KeepSessionAlive(val) {
            $.post("../KeepSessionAlive.aspx?ses_id=" + val + "", null, function () {

            });
        }

        function CallServerside_IECNO(src, dest) {
            var ctrl = document.getElementById(src);

            // call server side method

            PageMethods.Get_IECNO_Details(ctrl.value, CallSuccess_IECNO, CallFailed, dest);

        }

        // call server side method

        // calling Importer

        // set the destination textbox value with the ContactName
        function CallSuccess_IECNO(res, destCtrl) {
            //                $("#btnDelete").css('visibility', 'hidden');
            //                $("#btnUpdate").css('visibility', 'hidden');
            //                $("#btnNew").css('visibility', 'visible');
            //                $("#btnSave").css('visibility', 'visible');
            var dest = document.getElementById(destCtrl);
            //dest.value = res;
            var data = res;
            if (data.indexOf("~~") != -1) {


                var s = data.split('~~');

                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];

                if (before == '1') {
                    //document.getElementById("ddlType").value = after2;

                    var ddlType = document.getElementById("ddlType");

                    addOption(document.getElementById("ddlType"), after2, after2);

                    var txtName = $('#txtName');

                    txtName.attr('disabled', true);
                    jAlert('IE Code is already exists!', 'GENERAL', function (r) { document.getElementById("txtBranchNO").focus(); });

                    document.getElementById("txtName").value = after1;
                }
                if (before == '2') {

                    document.getElementById("txtName").value = '';
                   var txtName1 = $('#txtName');
                    txtName1.attr('disabled', false);
                }
            }
            else {

                document.getElementById("txtName").value = "";
                document.getElementById("type").value = "";
            }

            document.getElementById("txtBranchNO").focus();
        }
        function CallServerside_ClientName(src, dest) {
            var ctrl = document.getElementById(src);

            // call server side method

            PageMethods.Get_ClientName_Details(ctrl.value, CallSuccess_ClientName, CallFailed, dest);

        }
        function CallSuccess_ClientName(res, destCtrl) {
            //                $("#btnDelete").css('visibility', 'hidden');
            //                $("#btnUpdate").css('visibility', 'hidden');
            //                $("#btnNew").css('visibility', 'visible');
            //                $("#btnSave").css('visibility', 'visible');
            var dest = document.getElementById(destCtrl);
            //dest.value = res;
            var data = res;
            if (data.indexOf("~~") != -1) {


                var s = data.split('~~');

                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];

                if (before == '1') {
                    document.getElementById("ddlType").value = after2;

                    var ddlType = document.getElementById("ddlType");
                    addOption(document.getElementById("ddlType"), after2, after2);

                    var txtName = $('#txtName');


                    jAlert('Party Already Exists!', 'GENERAL', function (r) { document.getElementById("txtName").focus(); });

                    // document.getElementById("txtName").value = after1;


                }
                if (before == '2') {
                    document.getElementById("txtName").value = '';
                    document.getElementById("txtName").focus();
                }
            }
            else {

                document.getElementById("txtName").value = "";
                document.getElementById("type").value = "";
            }
            document.getElementById("txtName").focus();

        }
        function CallServerside_Branch(src, dest) {
            var ctrl = document.getElementById(src);
            var ctrl1 = document.getElementById('txtIECNO');
            var ctrl2 = document.getElementById('txtName');

            // call server side method

            PageMethods.Get_Branch_Details(ctrl1.value, ctrl2.value, ctrl.value, CallSuccess_Branch, CallFailed, dest);

        }
        function CallSuccess_Branch(res, destCtrl) {
            //                $("#btnDelete").css('visibility', 'hidden');
            //                $("#btnUpdate").css('visibility', 'hidden');
            //                $("#btnNew").css('visibility', 'visible');
            //                $("#btnSave").css('visibility', 'visible');
            var dest = document.getElementById(destCtrl);
            //dest.value = res;
            var data = res;
            if (data.indexOf("~~") != -1) {
                var s = data.split('~~');

                var before = s[0];
                var after1 = s[1];
                if (after1 == 'UPDATE') {
                    document.getElementById("txtBranchNO").focus();
                }
                if (before == '1') {

                    jAlert('Branch Already Exists!', 'GENERAL', function (r) { document.getElementById("txtBranchNO").focus(); });
                }
                else {
                    document.getElementById("txtName").focus();
                }
            }
        }
        function CallFailed(res, destCtrl) {
            //alert(res.get_message());
        }

        function addOption(selectbox, text, value) {

            selectbox.options.length = 0;
            var optn = document.createElement("OPTION");
            if (text == 'OTHERS' && value == 'OTHERS') {

                optn.text = text;
                optn.value = value;
                selectbox.options.add(optn);
                selectbox.options.add(new Option("GOVERNMENT", "GOVERNMENT"));

            }
            else if (text == 'GOVERNMENT' && value == 'GOVERNMENT') {

                optn.text = text;
                optn.value = value;
                selectbox.options.add(optn);
                selectbox.options.add(new Option("OTHERS", "OTHERS"));
            }
        }

    </script>

    <script type="text/javascript">
    $(document).ready(function () {
        BindControls_RELATION();
    });

    function BindControls_RELATION() {
        var Notn_SIA = ['Yes','No'];
        $('#txtRelation').autocomplete({
            source: Notn_SIA,
            minLength: 0,
            scroll: true
        }).focus(function () {
            $(this).autocomplete("search", "");
        });
    }
      
    </script>
</body>
</html>
