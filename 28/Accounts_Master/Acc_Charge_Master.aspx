<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Acc_Charge_Master.aspx.cs"  Inherits="Eroyal.Accounts_Trial.ChargeMasterPage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Charge Master | Updation</title>
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
                      Charge Master
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
                    <div id="innerbox_MidMain_popup_ClientMaster" style="height: 300px;width: 1012px; margin-left:-15px; background-color:White;">

                        <div id="innerbox_MidMain_Mid_ClientMaster" style="height: 298px;width: 1012px;">
                            <div id="tag_transac_lft_Trans_Invoice_Supp_in1_others_Item" style="height: 135px;  width: 1010px;">
                            <div style="margin-left: 10px;">
                            <div id="tag_transac_lft_trans_item_maindet_in1_">
                            </div>
                                <div id="tag_transac_lft_trans_item_maindet_in1_"  style="width: 1005px;">
                                   
                                    <div id="tag_label_transaction_export_Item_otherdet_new1" >
                                       Charge Name
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet" style="width:500px">
                                        <asp:TextBox ID="txtCharge_Name" runat="server" Width="480px" MaxLength="300" TabIndex="5" CssClass="validate[required] txtbox_none"></asp:TextBox>
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet" style="width:130px">
                                         <asp:RadioButtonList ID="Rd_Hsn_Sac" runat="server" RepeatDirection="Horizontal" TabIndex="40">
                                            <asp:ListItem Text="SAC" Value="S" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="HSN" Value="H"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                      <div id="txtcon-m_transaction_item_maindet" style="width:130px">
                                         <asp:TextBox ID="txt_HSN_SAC_Code" runat="server" Width="100px" MaxLength="20" TabIndex="6" CssClass="validate[required] txtbox_none"></asp:TextBox>
                                    </div>
                                </div>
                                 <div id="tag_transac_lft_trans_item_maindet_in1_"  style="width: 1005px;">
                                   
                                    <div id="tag_label_transaction_export_Item_otherdet_new1" >
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet" style="width:500px">
                                    </div>
                                </div>

                                 <div id="tag_transac_lft_trans_item_maindet_in1_"  style="width: 1005px;">
                                   
                                    <div id="tag_label_transaction_export_Item_otherdet_new1" >
                                       Charge Category
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet" style="width:500px">
                                           <asp:RadioButtonList ID="Rd_Ch_Cat" runat="server" RepeatDirection="Horizontal" TabIndex="10">
                                            <asp:ListItem Text="Margin" Value="M" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Revenue" Value="R"></asp:ListItem>
                                             <asp:ListItem Text="Cost" Value="C"></asp:ListItem>
                                              <asp:ListItem Text="Reimbursement" Value="RI"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                                 <div id="tag_transac_lft_trans_item_maindet_in1_"  style="width: 1005px;">
                                   
                                    <div id="tag_label_transaction_export_Item_otherdet_new1" >
                                      Tax Category
                                    </div>
                                    <div id="txtcon-m_transaction_item_maindet" style="width:500px">
                                           <asp:RadioButtonList ID="Rd_Tax_Cat" runat="server" RepeatDirection="Horizontal" TabIndex="11">
                                            <asp:ListItem Text="Taxable" Value="T" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Exempt" Value="E"></asp:ListItem>
                                             <asp:ListItem Text="Nil Rated" Value="R"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                               
                                
                                <div id="tag_transac_lft_trans_item_maindet_in1_">
                                    
                                </div>
                                
                                <div id="tag_transac_lft_trans_item_maindet_in1_">
                                    <div id="tag_label_transaction_export_Item_otherdet_new1">
                                    </div>
                                </div>
                            </div>
                       
                    </div>

                     <div id="pop_text_area_transac_popup_inn_container_new" style="height: 120px;width: 1000px; " >
                      <div id="pop_text_area_transac_popup_inn_container_left_new" style="height: 240px;">
                      <fieldset id="fld" style="width: 480px;" >
                                    <legend style="border: Black; border-collapse: collapse; width: 250px; text-align: center;">
                                        Import / Export / General </legend>
                                    <div style="margin-left: 10px;">
                                        <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 480px;" >
                                            <div id="tag_label_transaction_export_Item_otherdet_new1" style="height: 20px;">
                                            Import
                                            </div>
                                            <div id="txtcon-m_transaction_item_maindet" style="width: 330px">
                                                <asp:RadioButtonList ID="Rd_I_IE_Ledg" runat="server" RepeatDirection="Horizontal"
                                                    TabIndex="13">
                                                    <asp:ListItem Text="Income" Value="I"></asp:ListItem>
                                                    <asp:ListItem Text="Expense" Value="E"></asp:ListItem>
                                                    <asp:ListItem Text="Both" Value="B" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="In-Active" Value="IA"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 480px;" >
                                            <div id="tag_label_transaction_export_Item_otherdet_new1" style="height: 20px;">
                                            Export
                                            </div>
                                            <div id="txtcon-m_transaction_item_maindet" style="width: 330px">
                                                <asp:RadioButtonList ID="Rd_E_IE_Ledg" runat="server" RepeatDirection="Horizontal"
                                                    TabIndex="14">
                                                    <asp:ListItem Text="Income" Value="I"></asp:ListItem>
                                                    <asp:ListItem Text="Expense" Value="E"></asp:ListItem>
                                                    <asp:ListItem Text="Both" Value="B" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="In-Active" Value="IA"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                         <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 480px;" >
                                            <div id="tag_label_transaction_export_Item_otherdet_new1" style="height: 20px;">
                                            General
                                            </div>
                                            <div id="txtcon-m_transaction_item_maindet" style="width: 330px">
                                                <asp:RadioButtonList ID="Rd_G_IE_Ledg" runat="server" RepeatDirection="Horizontal" TabIndex="15">
                                                    <asp:ListItem Text="Income" Value="I"></asp:ListItem>
                                                    <asp:ListItem Text="Expense" Value="E"></asp:ListItem>
                                                    <asp:ListItem Text="Both" Value="B" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="In-Active" Value="IA"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                                <div id="tag_transac_lft_in1"></div>

                                 
                      
                      </div>
                       <div id="" style="height: 240px;">
                       <fieldset id="fld" style="width: 480px;" >
                                    <legend style="border: Black; border-collapse: collapse; width: 150px; text-align: center;">
                                        GST Rate  </legend>
                                    <div style="margin-left: 10px;">
                                        <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 480px;" >
                                            <div id="tag_label_transaction_export_Item_otherdet_new1" style="height: 20px;">
                                            CGST Rate
                                            </div>
                                            <div id="txtcon-m_transaction_item_maindet" style="width: 330px">
                                                <asp:TextBox ID="txt_CGST_Rate" runat="server" CssClass="txtbox_none" Width="60px"
                                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="16"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 480px;" >
                                            <div id="tag_label_transaction_export_Item_otherdet_new1" style="height: 20px;">
                                            SGST Rate
                                            </div>
                                            <div id="txtcon-m_transaction_item_maindet" style="width: 330px">
                                                <asp:TextBox ID="txt_SGST_Rate" runat="server" CssClass="txtbox_none" Width="60px"
                                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="17"></asp:TextBox>
                                            </div>
                                        </div>
                                         <div id="tag_transac_lft_trans_item_maindet_in1_" style="width: 480px;" >
                                            <div id="tag_label_transaction_export_Item_otherdet_new1" style="height: 20px;">
                                            IGST Rate
                                            </div>
                                            <div id="txtcon-m_transaction_item_maindet" style="width: 330px">
                                                <asp:TextBox ID="txt_IGST_Rate" runat="server" CssClass="txtbox_none" Width="60px"
                                                    onblur="extractNumber(this,2,false);" onkeyup="extractNumber(this,2,false);return Clear_Dot(this);"
                                                    onkeypress="return blockNonNumbers(this, event, true, false);" TabIndex="18"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                       
                       </div>


                     </div>

                          <div id="tag_label_transaction_export_Item_otherdet_new1">
                      Charge 
                        </div>
                      <div id="txtcon-m_transaction_item_maindet" style="width: 500px">
                        <asp:RadioButtonList ID="Rd_Charge_AI" runat="server" RepeatDirection="Horizontal" TabIndex="20">
                            <asp:ListItem Text="Active" Value="A" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="In-Active" Value="IA"></asp:ListItem>
                        </asp:RadioButtonList>
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
                                    <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                                        tabindex="53" id="btnCancel" />
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
            $("#txtStateName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_Name_List",
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
                            }
                            else {
                                var value = data.d;
                                if (value.indexOf("-") != -1) {
                                    var arr = value.split('-');
                                    alert(value);
                                    jQuery('#txtStateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                }
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
            $("#txtDistrict").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/District_Names_StateName_Wise_List",
                        //                        data: "{ 'mail': '" + request.term + "' }",
                        data: "{ 'mail': '" + request.term + "','StateName': '" + document.getElementById("txtStateName").value + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {

                                jQuery('#txtDistrict').validationEngine('showPrompt', 'Incorrect District Name', 'error', 'topRight', true);
                            }
                            else {
                                var value = data.d;
                                if (value.indexOf("-") != -1) {
                                    var arr = value.split('-');
                                    alert(value);
                                    jQuery('#txtDistrict').validationEngine('hidePrompt', '', 'error', 'topRight', true);
                                }
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
            $("#txtCommercial_StateName").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/State_Master_Name_List",
                        data: "{ 'mail': '" + request.term + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        async: true,
                        success: function (data) {
                            response(data.d);
                            if (data.d == '') {
                                jQuery('#txtCommercial_StateName').validationEngine('showPrompt', 'Incorrect State Name', 'error', 'topRight', true);

                                //jAlert('State Export is Incorrect', 'GENERAL', function (r) { document.getElementById("txtStateExport').focus(); });
                                //return false;
                            }
                            else {
                                jQuery('#txtCommercial_StateName').validationEngine('hidePrompt', '', 'error', 'topRight', true);
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
            PageMethods.Get_IECNO_Details(ctrl.value, CallSuccess_IECNO, CallFailed, dest);
        }

        function CallSuccess_IECNO(res, destCtrl) {
            var dest = document.getElementById(destCtrl);
            var data = res;
            if (data.indexOf("~~") != -1) {

                var s = data.split('~~');
                var before = s[0];
                var after1 = s[1];
                var after2 = s[2];

                if (before == '1') {

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

            var dest = document.getElementById(destCtrl);

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
            $('#txtStateName').focus(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtStateName').change(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtStateName').keyup(function () {

                var data = $(this).val();
                Item_desc(data);

            });
            $('#txtStateName').keydown(function () {

                var data = $(this).val();
                Item_desc(data);

            });
        });

        function Item_desc(val) {

            var data = val;

            if (data == '') {
                $('#txtStateName').val('');
            }
            if (data.indexOf("-") != -1) {

                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtStateName').val(before);
                $('#hdn_Txt_Statecode').val(after);
            }
            else {

            }
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtDistrict').focus(function () {

                var data = $(this).val();
                Item_District(data);

            });
            $('#txtDistrict').change(function () {

                var data = $(this).val();
                Item_District(data);

            });
            $('#txtDistrict').keyup(function () {

                var data = $(this).val();
                Item_District(data);

            });
            $('#txtDistrict').keydown(function () {

                var data = $(this).val();
                Item_District(data);

            });
        });

        function Item_District(val) {

            var data = val;

            if (data == '') {
                $('#txtDistrict').val('');
            }
            if (data.indexOf("-") != -1) {

                var s = data.split('-');

                var before = s[0];
                var after = s[1];

                $('#txtDistrict').val(after);
                //$('#hdn_Txt_District').val(after);
            }
            else {

            }
        }
    </script>

    <script type="text/javascript">
        $(document).ready(function () {

            if ($("#ddlCommercial_Tax_yn option:selected").text() == 'Y') {

                $("#txtCommercial_StateName").removeAttr("disabled");
                $("#txtCommercial_StateCode").removeAttr("disabled");
                $("#txtCommercial_Taxtype").removeAttr("disabled");
                $("#txtCommercial_RegistrationNo").removeAttr("disabled");

                document.getElementById('ST_Code').style.visibility = 'visible';
            }

            if ($("#ddlCommercial_Tax_yn option:selected").text() == 'N') {

                $("#txtCommercial_StateName").val('');
                $("#txtCommercial_StateCode").val('');
                $("#txtCommercial_Taxtype").val('');
                $("#txtCommercial_RegistrationNo").val('');

                $("#txtCommercial_StateName").attr("disabled", "disabled");
                $("#txtCommercial_StateCode").attr("disabled", "disabled");
                $("#txtCommercial_Taxtype").attr("disabled", "disabled");
                $("#txtCommercial_RegistrationNo").attr("disabled", "disabled");

                document.getElementById('ST_Code').style.visibility = 'hidden';

            }

            $('#ddlCommercial_Tax_yn').change(function () {

                if ($("#ddlCommercial_Tax_yn option:selected").text() == 'Y') {

                    $("#txtCommercial_StateName").removeAttr("disabled");
                    $("#txtCommercial_StateCode").removeAttr("disabled");
                    $("#txtCommercial_Taxtype").removeAttr("disabled");
                    $("#txtCommercial_RegistrationNo").removeAttr("disabled");

                    document.getElementById('ST_Code').style.visibility = 'visible';
                }
                else {

                    $("#txtCommercial_StateName").val('');
                    $("#txtCommercial_StateCode").val('');
                    $("#txtCommercial_Taxtype").val('');
                    $("#txtCommercial_RegistrationNo").val('');

                    $("#txtCommercial_StateName").attr("disabled", "disabled");
                    $("#txtCommercial_StateCode").attr("disabled", "disabled");
                    $("#txtCommercial_Taxtype").attr("disabled", "disabled");
                    $("#txtCommercial_RegistrationNo").attr("disabled", "disabled");

                    document.getElementById('ST_Code').style.visibility = 'hidden';
                }

            });
        });
    </script>

     <script type="text/javascript">
$(function () {

    $('#txtCommercial_StateName').bind('focus keyup keypress change keydown', function () {

        var data = $(this).val();
        commercial_state(data);

    });
});

function commercial_state(val) {

    var data = val;
    if (data == '') {
        $('#txtCommercial_StateCode').val('');
    }
    //$('#hdn_Autosearch').val(data);

   
    if (data.indexOf("-") != -1) {

        var s = data.split('-');

        var before = s[0];
        var after = s[1];

        $('#txtCommercial_StateCode').val(after);
        $('#txtCommercial_StateName').val(before);

    }
    else {
      
    }
}
 </script>
     <script src="../js/Import_Jscript/Import_General.js" type="text/javascript"></script>
     <script type="text/javascript" src="../js/eRoyalmaster_Jscript/Client_Master.js"></script>
     <script src="../js/JScript_validation_eRoyalMasters.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Iec_Track() {
            var C = document.getElementById("txtIECNO").value;
            var NN = document.getElementById("txtName").value;
            var N = NN.substring(0, 3);
            Iec_Status(C, N);
        }
    </script>
     <script type="text/javascript">
         $(document).ready(function () {

             $('#txtWarehouseCode').focus(function () {

                 var data = $(this).val();
                 WH_Code(data);

             });
             $('#txtWarehouseCode').change(function () {

                 var data = $(this).val();
                 WH_Code(data);

             });
             $('#txtWarehouseCode').keyup(function () {

                 var data = $(this).val();
                 WH_Code(data);

             });
             $('#txtWarehouseCode').keydown(function () {

                 var data = $(this).val();
                 WH_Code(data);

             });

         });

         function WH_Code(val) {

             var data = val;
             if (data == '') {
                 $('#txtWarehouseCode').val('');
             }
             if (data.indexOf("--") != -1) {

                 var s = data.split('--');
                 var before = s[0];
                 var after = s[1];
                 $('#txtWarehouseCode').val(before);
             }
             else {

             }
         }
  </script>
</body>
</html>
