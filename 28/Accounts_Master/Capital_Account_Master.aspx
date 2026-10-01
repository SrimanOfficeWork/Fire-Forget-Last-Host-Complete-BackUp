<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Capital_Account_Master.aspx.cs" Inherits="Capital_Account_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Capital Account Master | Updation</title>
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
        LoadScriptsBeforeUI="false" EnablePageMethods="true" AsyncPostBackTimeout="0">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" Visible="true">
        <ContentTemplate>
            <div class="loading" align="center" id="load" style="display: none;">
                <img src="../Loading_Images/indicator_mozilla_blu.gif" alt="" />
            </div>
           
            <div id="innerbox_MidMain_popup_adcode">
                <div id="innerbox_MidMain_top_adcode">
                    Capital Account Master
                    <div id="popupwindow_closebut_right">
                        <input type="close" value="Submit" class="clsicon" onclick="parent.adcodewindow.hide();RefreshParent();return false;" />
                    </div>
                </div>
                <div id="innerbox_MidMain_Mid_adcode" style=" height:410px;">
                    
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                         </div>
                        <div id="txtcon-m_src" style="color:Blue;  font-weight:bold;">
                          Opening Balance : 
                          <asp:TextBox ID="txt_Opening_Bal" runat="server" CssClass="txtbox_none"  Width="80px"
                                TabIndex="1" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>

                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Ledger Name</div>
                        <div id="txtcon-m_src">
                            <asp:TextBox ID="txtLedger_Name" runat="server" CssClass="validate[required] txtbox_none"
                                TabIndex="2" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>

                     <div id="pop_text_area">
                        <div id="tag_label_adcode">
                           Under
                        </div>
                        <div id="txtcon-m_src" >
                            <asp:Literal ID="lbl_Under" Text="Capital Account" runat="server"></asp:Literal>
                        </div>
                    </div>

                       
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Address 1
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:TextBox ID="txt_add_1" runat="server" CssClass="txtbox_none" TabIndex="5"></asp:TextBox>
                        </div>
                    </div>
                      <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            Address 2
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:TextBox ID="txt_add_2" runat="server" CssClass="txtbox_none" TabIndex="6"></asp:TextBox>
                                 
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            District
                        </div>
                        <div id="txtcon-m_transaction_mode">
                           <asp:TextBox ID="txt_District" runat="server" CssClass="txtbox_none" TabIndex="7"></asp:TextBox>
                                 
                        </div>
                    </div>
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            State Name
                        </div>
                        <div id="txtcon-m_transaction_mode">
                            <asp:DropDownList ID="ddl_state_name" CssClass="listtxt_transac_item_gen_notn" Width="180px" TabIndex="10" ForeColor="Green" runat="server" >
                                    <asp:ListItem Text="" Value=""></asp:ListItem>
                                    <asp:ListItem Text="01--JAMMU & KASHMIR" Value="JAMMU & KASHMIR"></asp:ListItem>
                                    <asp:ListItem Text="02--HIMACHAL PRADESH" Value="HIMACHAL PRADESH"></asp:ListItem>
                                    <asp:ListItem Text="03--PUNJAB" Value="PUNJAB"></asp:ListItem>
                                    <asp:ListItem Text="04--CHANDIGARH" Value="CHANDIGARH"></asp:ListItem>
                                    <asp:ListItem Text="05--UTTARAKHAND" Value="UTTARAKHAND"></asp:ListItem>
                                    <asp:ListItem Text="06--HARYANA" Value="HARYANA"></asp:ListItem>
                                    <asp:ListItem Text="07--DELHI" Value="DELHI"></asp:ListItem>
                                    <asp:ListItem Text="08--RAJASTHAN" Value="RAJASTHAN"></asp:ListItem>
                                    <asp:ListItem Text="09--UTTAR PRADESH" Value="UTTAR PRADESH"></asp:ListItem>
                                    <asp:ListItem Text="10--BIHAR" Value="BIHAR"></asp:ListItem>
                                    <asp:ListItem Text="11--SIKKIM" Value="SIKKIM"></asp:ListItem>
                                    <asp:ListItem Text="12--ARUNACHAL PRADESH" Value="ARUNACHAL PRADESH"></asp:ListItem>
                                    <asp:ListItem Text="13--NAGALAND" Value="NAGALAND"></asp:ListItem>
                                    <asp:ListItem Text="14--MANIPUR" Value="MANIPUR"></asp:ListItem>
                                    <asp:ListItem Text="15--MIZORAM" Value="MIZORAM"></asp:ListItem>
                                    <asp:ListItem Text="16--TRIPURA" Value="TRIPURA"></asp:ListItem>
                                    <asp:ListItem Text="17--MEGHALAYA" Value="MEGHALAYA"></asp:ListItem>
                                    <asp:ListItem Text="18--ASSAM" Value="ASSAM"></asp:ListItem>
                                    <asp:ListItem Text="19--WEST BENGAL" Value="WEST BENGAL"></asp:ListItem>
                                    <asp:ListItem Text="20--JHARKHAND" Value="JHARKHAND"></asp:ListItem>
                                    <asp:ListItem Text="21--ORISSA" Value="ORISSA"></asp:ListItem>
                                    <asp:ListItem Text="22--CHATTISGARH" Value="CHATTISGARH"></asp:ListItem>
                                    <asp:ListItem Text="23--MADHYA PRADESH" Value="MADHYA PRADESH"></asp:ListItem>
                                    <asp:ListItem Text="24--GUJARAT" Value="GUJARAT"></asp:ListItem>
                                    <asp:ListItem Text="25--DAMAN & DIU" Value="DAMAN & DIU"></asp:ListItem>
                                    <asp:ListItem Text="26--DADRA & NAGAR HAVELI" Value="DADRA & NAGAR HAVELI"></asp:ListItem>
                                    <asp:ListItem Text="27--MAHARASHTRA" Value="MAHARASHTRA"></asp:ListItem>
                                    <asp:ListItem Text="29--KARNATAKA" Value="KARNATAKA"></asp:ListItem>
                                    <asp:ListItem Text="30--GOA" Value="GOA"></asp:ListItem>
                                    <asp:ListItem Text="31--LAKSHADWEEP" Value="LAKSHADWEEP"></asp:ListItem>
                                    <asp:ListItem Text="32--KERALA" Value="KERALA"></asp:ListItem>
                                    <asp:ListItem Text="33--TAMILNADU" Value="TAMILNADU"></asp:ListItem>
                                    <asp:ListItem Text="33--TAMIL NADU" Value="TAMIL NADU"></asp:ListItem>
                                    <asp:ListItem Text="34--PONDICHERRY" Value="PONDICHERRY"></asp:ListItem>
                                    <asp:ListItem Text="35--ANDAMAN & NICOBAR" Value="ANDAMAN & NICOBAR"></asp:ListItem>
                                    <asp:ListItem Text="36--TELANGANA" Value="TELANGANA"></asp:ListItem>
                                    <asp:ListItem Text="37--ANDHRA PRADESH" Value="ANDHRA PRADESH"></asp:ListItem>
                                    <asp:ListItem Text="97--OTHER TERRITORY" Value="OTHER TERRITORY"></asp:ListItem>
                                    </asp:DropDownList>
                        </div>
                    </div>
                    
                    <div id="pop_text_area">
                        <div id="tag_label_adcode">
                          Pin Code
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_Pin_Code" runat="server" CssClass="txtbox_none" 
                                 TabIndex="12"></asp:TextBox>

                        </div>
                    </div>

                      <div id="pop_text_area">
                        <div id="tag_label_adcode">
                            PAN Number
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_PAN_Number" runat="server" CssClass="txtbox_none" 
                                 TabIndex="15"></asp:TextBox>
                        </div>
                    </div>

                       <div id="pop_text_area">
                        <div id="tag_label_adcode">
                             GST Number
                        </div>
                        <div id="txtcon-m_transaction_mode">
                          <asp:TextBox ID="txt_GST_No" runat="server" CssClass="txtbox_none"  
                                 TabIndex="18"></asp:TextBox>
                        </div>
                    </div>
                 
                    <div id="pop_text_area"></div>
            </div>
            <div id="innerbox_MidMain_top_adcode">
                <div id="innerbox_adcode_bot_inn">
                    <div id="newbu">
                        <asp:Button ID="btnNew" runat="server" CausesValidation="false" UseSubmitBehavior="false"
                            OnClick="btnNew_Click" OnClientClick="jQuery('#form1').validationEngine('hideAll')"
                            CssClass="new" TabIndex="23" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" CssClass="save" 
                            TabIndex="20" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" CssClass="updates"
                            TabIndex="20" />
                    </div>
                    <div id="editbu">
                        <asp:Button ID="btnDelete" runat="server" TabIndex="18" CssClass="dlete" OnClientClick="jConfirm('Delete this Entry?', 'CHARGE MASTER', function(r) {
                  var i = r + 'ok';
          if(i == 'trueok')
          {
              document.getElementById('btn').click();
            
          }
          else {
          }
    
});return false;" />
                        <asp:Button ID="btn" runat="server" TabIndex="21" OnClick="btnDelete_Click" CssClass="dlete"
                            Style="display: none;" />
                    </div>
                    <div id="editbu">
                        <input type="submit" value="" class="scancel" onclick="RefreshParent();return false;"
                            tabindex="22" id="btnCancel" />

                        <asp:HiddenField ID="HDupdate_id" runat="server" />
                    </div>
                </div>
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
                        url: "../AutoComplete_Pages/Auto_Complete_Searching.asmx/Importer_Master_IECCode_List",
                        data: "{ 'mail': '" + request.term + "' ,'IEC':''}",
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


        function Call_Client_Name(src, dest) {
            var ctrl = document.getElementById(src);
            // call server side method
            //alert('l');
            var ieccode = document.getElementById("txtIec_Code").value;
            //if (ieccode.length == 10) {
            PageMethods.GetClient_Name(ctrl.value, CallSuccess, CallFailed, dest);

            //}

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

